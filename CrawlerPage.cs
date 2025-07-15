using BoomSQL.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoomSQL
{
    public partial class CrawlerPage : BasePage
    {
        private ConcurrentQueue<string> _urlQueue = new ConcurrentQueue<string>();
        private ConcurrentDictionary<string, bool> _visitedUrls = new ConcurrentDictionary<string, bool>();
        private ConcurrentDictionary<string, bool> _parameterizedUrls = new ConcurrentDictionary<string, bool>();
        private int _totalUrls = 0;
        private int _processedUrls = 0;
        private bool _isCrawling = false;
        private System.Windows.Forms.Timer _progressTimer = new System.Windows.Forms.Timer();
        private int _maxThreads = 5;

        public event EventHandler<List<string>> OnSendToTester;

        public CrawlerPage()
        {
            InitializeComponent();
            InitializeEventHandlers();
            InitializeTimer();
        }

        private void InitializeEventHandlers()
        {
            btnStart.Click += BtnStart_Click;
            btnStop.Click += BtnStop_Click;
            btnSave.Click += BtnSave_Click;
            btnSendToTester.Click += BtnSendToTester_Click;
            btnLoad.Click += BtnLoad_Click;
            btnShowLogs.Click += BtnShowLogs_Click;
        }

        private void InitializeTimer()
        {
            _progressTimer.Interval = 500;
            _progressTimer.Tick += (s, e) => UpdateProgress();
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            if (_isCrawling) return;

            var baseUrl = txtBaseUrl.Text.Trim();
            if (string.IsNullOrEmpty(baseUrl) || !Uri.IsWellFormedUriString(baseUrl, UriKind.Absolute))
            {
                MessageBox.Show("Please enter a valid base URL");
                return;
            }

            _maxThreads = (int)nudThreads.Value;
            _isCrawling = true;
            SetControlsEnabled(false);
            btnStop.Enabled = true;

            _urlQueue = new ConcurrentQueue<string>();
            _visitedUrls = new ConcurrentDictionary<string, bool>();
            _parameterizedUrls = new ConcurrentDictionary<string, bool>();
            lstResults.Items.Clear();
            txtLogs.Clear();

            _urlQueue.Enqueue(baseUrl);
            _visitedUrls[baseUrl] = true;
            _totalUrls = 1;
            _processedUrls = 0;

            _progressTimer.Start();
            LogMessage($"Starting crawl from: {baseUrl}");

            var tasks = new List<Task>();
            for (int i = 0; i < _maxThreads; i++)
            {
                tasks.Add(Task.Run(ProcessUrls));
            }

            await Task.WhenAll(tasks);

            CrawlComplete();
        }

        private async Task ProcessUrls()
        {
            while (_isCrawling && _urlQueue.TryDequeue(out string currentUrl))
            {
                try
                {
                    var html = await DownloadHtml(currentUrl);
                    if (!string.IsNullOrEmpty(html))
                    {
                        ProcessHtml(currentUrl, html);
                    }
                }
                catch (Exception ex)
                {
                    LogMessage($"Error processing {currentUrl}: {ex.Message}");
                }
                finally
                {
                    Interlocked.Increment(ref _processedUrls);
                }
            }
        }

        private async Task<string> DownloadHtml(string url)
        {
            try
            {
                using (var client = CreateWebClient())
                {
                    return await client.DownloadStringTaskAsync(url);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Download error: {url} - {ex.Message}");
                return null;
            }
        }

        private WebClient CreateWebClient()
        {
            var client = new WebClient();
            client.Headers.Add("User-Agent", ProxyManager.GetRandomUserAgent());

            if (ProxyManager.UseProxy)
            {
                var proxy = ProxyManager.GetRandomProxy();
                if (proxy != null)
                {
                    client.Proxy = new WebProxy($"{proxy.Host}:{proxy.Port}");
                    if (!string.IsNullOrEmpty(proxy.Username))
                    {
                        client.Proxy.Credentials = new NetworkCredential(proxy.Username, proxy.Password);
                    }
                }
            }

            return client;
        }

        private void ProcessHtml(string baseUrl, string html)
        {
            // Extract links
            var linkMatches = Regex.Matches(html, @"<a\s+[^>]*href\s*=\s*[""']([^""']+)[""'][^>]*>", RegexOptions.IgnoreCase);
            foreach (Match match in linkMatches)
            {
                if (!_isCrawling) return;

                var href = match.Groups[1].Value;
                var absoluteUrl = GetAbsoluteUrl(baseUrl, href);

                if (!string.IsNullOrEmpty(absoluteUrl) &&
                    IsSameDomain(baseUrl, absoluteUrl) &&
                    !_visitedUrls.ContainsKey(absoluteUrl))
                {
                    _urlQueue.Enqueue(absoluteUrl);
                    _visitedUrls[absoluteUrl] = true;
                    Interlocked.Increment(ref _totalUrls);
                }
            }

            // Extract parameterized URLs
            var paramMatches = Regex.Matches(html, @"<a\s+[^>]*href\s*=\s*[""']([^""'?]+\?[^""']+)[""'][^>]*>", RegexOptions.IgnoreCase);
            foreach (Match match in paramMatches)
            {
                if (!_isCrawling) return;

                var href = match.Groups[1].Value;
                var absoluteUrl = GetAbsoluteUrl(baseUrl, href);

                if (!string.IsNullOrEmpty(absoluteUrl) &&
                    IsSameDomain(baseUrl, absoluteUrl) &&
                    !_parameterizedUrls.ContainsKey(absoluteUrl))
                {
                    _parameterizedUrls[absoluteUrl] = true;
                    SafeAddResult(absoluteUrl);
                }
            }
        }

        private string GetAbsoluteUrl(string baseUrl, string relativeUrl)
        {
            try
            {
                var baseUri = new Uri(baseUrl);
                var uri = new Uri(baseUri, relativeUrl);
                return uri.AbsoluteUri;
            }
            catch
            {
                return null;
            }
        }

        private bool IsSameDomain(string url1, string url2)
        {
            try
            {
                var uri1 = new Uri(url1);
                var uri2 = new Uri(url2);
                return uri1.Host == uri2.Host;
            }
            catch
            {
                return false;
            }
        }

        private void SafeAddResult(string url)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SafeAddResult), url);
                return;
            }

            lstResults.Items.Add(url);
            LogMessage($"Found parameterized URL: {url}");
        }

        private void LogMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogMessage), message);
                return;
            }

            txtLogs.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\r\n");
        }

        private void UpdateProgress()
        {
            if (_totalUrls == 0) return;

            int progress = (int)((double)_processedUrls / _totalUrls * 100);
            progressBar.Value = Math.Min(100, progress);
            lblStatus.Text = $"Crawling: {_processedUrls}/{_totalUrls} URLs | Found: {lstResults.Items.Count} parameterized URLs";
        }

        private void CrawlComplete()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(CrawlComplete));
                return;
            }

            _isCrawling = false;
            _progressTimer.Stop();
            SetControlsEnabled(true);
            btnStop.Enabled = false;

            LogMessage($"Crawl complete! Found {lstResults.Items.Count} parameterized URLs");
            MessageBox.Show($"Crawl complete! Found {lstResults.Items.Count} parameterized URLs");
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _isCrawling = false;
            btnStop.Enabled = false;
            LogMessage("Crawl stopped by user");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (lstResults.Items.Count == 0)
            {
                MessageBox.Show("No results to save");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text Files|*.txt|All Files|*.*";
                sfd.FileName = "crawler-results.txt";

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
        }

        private void BtnSendToTester_Click(object sender, EventArgs e)
        {
            if (lstResults.Items.Count == 0)
            {
                MessageBox.Show("No results to send");
                return;
            }

            var urls = lstResults.Items.Cast<string>().ToList();
            OnSendToTester?.Invoke(this, urls);
            MessageBox.Show($"{urls.Count} URLs sent to SQL Injection Tester");
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text Files|*.txt|All Files|*.*";
                ofd.FileName = "urls.txt";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var urls = File.ReadAllLines(ofd.FileName);
                        txtBaseUrl.Text = urls.FirstOrDefault() ?? "";
                        MessageBox.Show($"Loaded base URL from {ofd.FileName}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading file: {ex.Message}");
                    }
                }
            }
        }

        private void BtnShowLogs_Click(object sender, EventArgs e)
        {
            splitContainer.Panel2Collapsed = !splitContainer.Panel2Collapsed;
            btnShowLogs.Text = splitContainer.Panel2Collapsed ? "Show Logs" : "Hide Logs";
        }

        private void SetControlsEnabled(bool enabled)
        {
            txtBaseUrl.Enabled = enabled;
            nudThreads.Enabled = enabled;
            btnStart.Enabled = enabled;
            btnLoad.Enabled = enabled;
            btnSave.Enabled = enabled;
            btnSendToTester.Enabled = enabled;
        }

        private void lstResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstResults.SelectedItem != null)
            {
                var urls = new List<string> { lstResults.SelectedItem.ToString() };
                OnSendToTester?.Invoke(this, urls);
                MessageBox.Show("URL sent to SQL Injection Tester");
            }
        }
    }
}