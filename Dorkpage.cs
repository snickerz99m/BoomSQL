using BoomSQL.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoomSQL
{
    public partial class DorkPage : BasePage
    {
        private DorkSearcher? _searcher;
        private List<Proxy> _proxies = new();
        private List<string> _userAgents = new();
        private List<SearchEngine> _searchEngines = new()
        {
            new SearchEngine { Name = "Google", UrlFormat = "https://www.google.com/search?q={dork}" },
            new SearchEngine { Name = "Bing", UrlFormat = "https://www.bing.com/search?q={dork}" },
            new SearchEngine { Name = "Yahoo", UrlFormat = "https://search.yahoo.com/search?p={dork}" },
            new SearchEngine { Name = "DuckDuckGo", UrlFormat = "https://duckduckgo.com/?q={dork}" },
            new SearchEngine { Name = "AOL", UrlFormat = "https://search.aol.com/aol/search?q={dork}" },
            new SearchEngine { Name = "Ask", UrlFormat = "https://www.ask.com/web?q={dork}" },
            new SearchEngine { Name = "Startpage", UrlFormat = "https://www.startpage.com/sp/search?query={dork}" },
            new SearchEngine { Name = "Dogpile", UrlFormat = "https://www.dogpile.com/serp?q={dork}" },
            new SearchEngine { Name = "Yandex", UrlFormat = "https://yandex.com/search/?text={dork}" },
            new SearchEngine { Name = "Baidu", UrlFormat = "https://www.baidu.com/s?wd={dork}" },
            new SearchEngine { Name = "MetaGer", UrlFormat = "https://metager.org/meta/meta.ger3?eingabe={dork}" },
            new SearchEngine { Name = "Gigablast", UrlFormat = "https://www.gigablast.com/search?q={dork}" }
        };

        private System.Windows.Forms.Timer _progressTimer = new();
        private List<string>? _currentDorks;
        private bool _isSearching = false;


        public DorkPage()
        {
            InitializeComponent();

            // Proper event wiring
            btnStart.Click += BtnStart_Click;
            btnStop.Click += BtnStop_Click;
            btnSaveResult.Click += BtnSaveResult_Click;
            btnLoadDorks.Click += BtnLoadDorks_Click;
            btnSendToTester.Click += BtnSendToTester_Click;

            InitializeTimer();
            LoadSettings();
            LoadDorks();

            // Ensure buttons are clickable
            btnStart.BringToFront();
            btnStop.BringToFront();
            btnSaveResult.BringToFront();
            btnLoadDorks.BringToFront();
            btnSendToTester.BringToFront();
        }

        private void InitializeTimer()
        {
            _progressTimer.Interval = 500;
            _progressTimer.Tick += UpdateProgressTimer_Tick;
        }

        private void LoadDorks()
        {
            try
            {
                var dorkFile = Path.Combine(Application.StartupPath, "dorks.txt");
                if (File.Exists(dorkFile))
                {
                    _currentDorks = File.ReadAllLines(dorkFile)
                        .Where(line => !string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                        .Select(line => line.Trim())
                        .ToList();
                    
                    LogMessage($"Loaded {_currentDorks.Count} dorks from file");
                }
                else
                {
                    LogMessage("Dorks file not found, using default dorks");
                    _currentDorks = GetDefaultDorks();
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error loading dorks: {ex.Message}");
                _currentDorks = GetDefaultDorks();
            }
        }

        private List<string> GetDefaultDorks()
        {
            return new List<string>
            {
                "inurl:login.php",
                "inurl:admin.php",
                "inurl:index.php?id=",
                "inurl:page.php?id=",
                "\"mysql_fetch_array()\"",
                "\"You have an error in your SQL syntax\"",
                "\"Microsoft OLE DB Provider for SQL Server\"",
                "\"ORA-00933: SQL command not properly ended\"",
                "\"PostgreSQL query failed\"",
                "inurl:gallery.php?id=",
                "inurl:article.php?id=",
                "inurl:show.php?id=",
                "inurl:view.php?id=",
                "inurl:product.php?id=",
                "inurl:category.php?id=",
                "inurl:news.php?id=",
                "inurl:item.php?id=",
                "inurl:forum.php?id=",
                "inurl:thread.php?id=",
                "inurl:post.php?id="
            };
        }

        private void LoadSettings()
        {
            try
            {
                // Load proxies
                var proxyPath = Path.Combine(Application.StartupPath, "proxies.txt");
                if (File.Exists(proxyPath))
                {
                    _proxies = ProxyManager.LoadProxies(proxyPath);
                    Debug.WriteLine($"Loaded {_proxies.Count} proxies");
                }
                else
                {
                    Debug.WriteLine("proxies.txt not found");
                }

                // Load user agents
                var uaPath = Path.Combine(Application.StartupPath, "useragents.txt");
                if (File.Exists(uaPath))
                {
                    _userAgents = File.ReadLines(uaPath)
                        .Where(l => !string.IsNullOrWhiteSpace(l))
                        .ToList();
                    Debug.WriteLine($"Loaded {_userAgents.Count} user agents");
                }
                else
                {
                    Debug.WriteLine("useragents.txt not found");
                }

                // Apply UI toggle states to search engines
                ApplySearchEngineStates();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading settings: {ex.Message}");
            }
        }

        private void ApplySearchEngineStates()
        {
            _searchEngines[0].Enabled = chkGoogle.Checked;
            _searchEngines[1].Enabled = chkBing.Checked;
            _searchEngines[2].Enabled = chkYahoo.Checked;
            _searchEngines[3].Enabled = chkDuckDuckGo.Checked;
            _searchEngines[4].Enabled = chkAOL.Checked;
            _searchEngines[5].Enabled = chkAsk.Checked;
            _searchEngines[6].Enabled = chkStartpage.Checked;
            _searchEngines[7].Enabled = chkDogpile.Checked;
        }

        private async void BtnStart_Click(object? sender, EventArgs e)
        {
            if (_isSearching) return;

            try
            {
                _isSearching = true;
                await StartSearchAsync();
            }
            finally
            {
                _isSearching = false;
            }
        }

        private async Task StartSearchAsync()
        {
            // Validate proxy toggle
            if (!toggleProxy.Checked)
            {
                MessageBox.Show("Please enable proxy to start search");
                return;
            }

            // Validate proxies
            if (_proxies.Count == 0)
            {
                MessageBox.Show("No proxies loaded! Please add proxies to proxies.txt");
                return;
            }

            // Validate user agents
            if (_userAgents.Count == 0)
            {
                MessageBox.Show("No user agents loaded! Please add user agents to useragents.txt");
                return;
            }

            // Get dorks
            var dorks = txtDorkInput.Text.Split(
                new[] { '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries
            );

            if (dorks.Length == 0)
            {
                MessageBox.Show("Please enter at least one dork");
                return;
            }

            // Update UI
            SetControlsEnabled(false);
            lstResults.Items.Clear();
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel1.Text = "Starting search...";
            _currentDorks = dorks.ToList();

            // Apply current checkbox states
            ApplySearchEngineStates();

            // Initialize searcher
            _searcher = new DorkSearcher(
                _currentDorks,
                _proxies,
                _userAgents,
                _searchEngines,
                url => SafeAddResult(url),
                () => SafeSearchComplete()
            );

            // Start progress timer
            _progressTimer.Start();

            try
            {
                // Start search
                await Task.Run(() => _searcher.StartAsync());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search error: {ex.Message}");
            }
            finally
            {
                _progressTimer.Stop();
            }
        }

        private void SafeAddResult(string url)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SafeAddResult), url);
                return;
            }

            if (!lstResults.Items.Contains(url))
            {
                lstResults.Items.Add(url);
                UpdateStatus($"Found: {lstResults.Items.Count} URLs");
            }
        }

        private void SafeSearchComplete()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(SafeSearchComplete));
                return;
            }

            SetControlsEnabled(true);
            UpdateStatus($"Search complete. Found: {lstResults.Items.Count} URLs");
        }

        private void UpdateStatus(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateStatus), message);
                return;
            }

            toolStripStatusLabel1.Text = message;
        }

        private void BtnStop_Click(object? sender, EventArgs e)
        {
            if (_searcher == null) return;

            _searcher.Stop();
            UpdateStatus("Search stopped by user");
            SetControlsEnabled(true);
            _progressTimer.Stop();
        }

        private void BtnSaveResult_Click(object? sender, EventArgs e)
        {
            if (lstResults.Items.Count == 0)
            {
                MessageBox.Show("No results to save");
                return;
            }

            using var sfd = new SaveFileDialog();
            sfd.Filter = "Text Files|*.txt|All Files|*.*";
            sfd.FileName = "dork-results.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllLines(sfd.FileName, lstResults.Items.Cast<string>());
                    MessageBox.Show($"Saved {lstResults.Items.Count} URLs to {sfd.FileName}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}");
                }
            }
        }

        private void BtnLoadDorks_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Text Files|*.txt|All Files|*.*";
            ofd.FileName = "dorks.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtDorkInput.Text = File.ReadAllText(ofd.FileName);
                    MessageBox.Show($"Loaded dorks from {ofd.FileName}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading file: {ex.Message}");
                }
            }
        }

        private void BtnSendToTester_Click(object? sender, EventArgs e)
        {
            var urls = lstResults.Items.Cast<string>().ToList();
            if (urls.Count == 0)
            {
                MessageBox.Show("No results to send");
                return;
            }

            // Implement sending to tester page
            MessageBox.Show($"Prepared to send {urls.Count} URLs to SQL injection tester");
        }

        private void SetControlsEnabled(bool enabled)
        {
            btnStart.Enabled = enabled;
            btnStop.Enabled = !enabled;
            btnLoadDorks.Enabled = enabled;
            btnSendToTester.Enabled = enabled;
            btnSaveResult.Enabled = enabled;
            txtDorkInput.Enabled = enabled;
            toggleProxy.Enabled = enabled;

            // Search engine checkboxes
            chkGoogle.Enabled = enabled;
            chkBing.Enabled = enabled;
            chkYahoo.Enabled = enabled;
            chkDuckDuckGo.Enabled = enabled;
            chkAOL.Enabled = enabled;
            chkAsk.Enabled = enabled;
            chkStartpage.Enabled = enabled;
            chkDogpile.Enabled = enabled;
        }

        private void UpdateProgressTimer_Tick(object? sender, EventArgs e)
        {
            if (_searcher == null || _currentDorks == null) return;

            var processed = _searcher.TotalProcessed;
            var totalTasks = _currentDorks.Count * _searchEngines.Count(e => e.Enabled);
            var percent = totalTasks > 0 ? Math.Min(100, (int)((double)processed / totalTasks * 100)) : 0;

            toolStripProgressBar1.Value = percent;
            UpdateStatus($"Searching... Found: {_searcher.Results.Count} | Processed: {processed}/{totalTasks}");
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {

        }
    }
}