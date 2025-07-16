using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BoomSQL.Core;

namespace BoomSQL
{
    public partial class TesterPage : BasePage
    {
        private List<SqlInjectionPayload> _payloads = new List<SqlInjectionPayload>();
        private List<string> _tampers = new List<string>();
        private List<TestResult> _results = new List<TestResult>();
        private bool _isTesting = false;
        private int _currentTestIndex = 0;
        private System.Windows.Forms.Timer _progressTimer = new System.Windows.Forms.Timer();
        private int _maxThreads = 5;
        private HttpClient _httpClient = new HttpClient();
        private SqlInjectionEngine _sqlEngine;
        private CancellationTokenSource _cancellationTokenSource;

        public void LoadUrls(List<string> urls)
        {
            if (urls == null || urls.Count == 0) return;

            if (InvokeRequired)
            {
                Invoke(new Action<List<string>>(LoadUrls), urls);
                return;
            }

            if (txtUrls != null)
            {
                txtUrls.Text = string.Join(Environment.NewLine, urls);
                LogMessage($"Loaded {urls.Count} URLs from external source");
            }
        }

        public void SetVulnerability(VulnerabilityDetails vulnerability)
        {
            // This method can be used to set a specific vulnerability for testing
            _currentVulnerability = vulnerability;
            LogMessage($"Set vulnerability: {vulnerability.VulnerabilityType} on {vulnerability.InjectionPoint.Name}");
        }

        private VulnerabilityDetails? _currentVulnerability;

        public TesterPage()
        {
            InitializeComponent();
            InitializeEventHandlers();
            InitializeTimer();
            LoadPayloads();
            LoadTampers();
            InitializeSqlEngine();
        }

        private void InitializeSqlEngine()
        {
            var config = new SqlInjectionConfig
            {
                MaxThreads = _maxThreads,
                EnableWafBypasses = true,
                EnableTimeBasedDetection = true,
                EnableErrorBasedDetection = true,
                EnableBooleanBasedDetection = true,
                EnableUnionBasedDetection = true,
                TimeBasedThreshold = 3.0,
                RequestTimeout = 30
            };

            _sqlEngine = new SqlInjectionEngine(_httpClient, config);
        }

        private void InitializeEventHandlers()
        {
            btnStart.Click += BtnStart_Click;
            btnStop.Click += BtnStop_Click;
            btnLoad.Click += BtnLoad_Click;
            btnSendToDumper.Click += BtnSendToDumper_Click;
            lstResults.MouseDoubleClick += LstResults_MouseDoubleClick;
            lstResults.MouseClick += LstResults_MouseClick;
        }

        private void InitializeTimer()
        {
            _progressTimer.Interval = 500;
            _progressTimer.Tick += (s, e) => UpdateProgress();
        }

        private void LoadPayloads()
        {
            try
            {
                var payloadFile = Path.Combine(Application.StartupPath, "payloads.xml");
                if (File.Exists(payloadFile))
                {
                    var doc = XDocument.Load(payloadFile);
                    _payloads = doc.Descendants("payload")
                        .Select(p => new SqlInjectionPayload
                        {
                            Title = p.Attribute("title")?.Value,
                            PayloadString = p.Value,
                            Risk = int.Parse(p.Attribute("risk")?.Value ?? "1"),
                            Platform = p.Attribute("platform")?.Value,
                            Category = p.Attribute("category")?.Value
                        })
                        .ToList();

                    LogMessage($"Loaded {_payloads.Count} payloads");
                }
                else
                {
                    LogMessage("Payloads.xml not found");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error loading payloads: {ex.Message}");
            }
        }

        private void LoadTampers()
        {
            try
            {
                var tamperDir = Path.Combine(Application.StartupPath, "tampers");
                if (Directory.Exists(tamperDir))
                {
                    _tampers = Directory.GetFiles(tamperDir, "*.py")
                        .Select(Path.GetFileNameWithoutExtension)
                        .ToList();

                    LogMessage($"Loaded {_tampers.Count} tampers");
                }
                else
                {
                    LogMessage("Tampers directory not found");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error loading tampers: {ex.Message}");
            }
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            if (_isTesting) return;

            var urls = txtUrls.Lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
            if (urls.Count == 0)
            {
                MessageBox.Show("Please enter at least one URL");
                return;
            }

            _isTesting = true;
            _currentTestIndex = 0;
            _results.Clear();
            lstResults.Items.Clear();
            SetControlsEnabled(false);
            btnStop.Enabled = true;

            _maxThreads = (int)nudThreads.Value;
            _progressTimer.Start();
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await ProcessUrlsAsync(urls, _cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                LogMessage("Testing was cancelled");
            }
            catch (Exception ex)
            {
                LogMessage($"Error during testing: {ex.Message}");
            }
            finally
            {
                TestingComplete();
            }
        }

        private async Task ProcessUrlsAsync(List<string> urls, CancellationToken cancellationToken)
        {
            var semaphore = new SemaphoreSlim(_maxThreads, _maxThreads);
            var tasks = urls.Select(async url =>
            {
                await semaphore.WaitAsync(cancellationToken);
                try
                {
                    return await ProcessSingleUrlAsync(url, cancellationToken);
                }
                finally
                {
                    semaphore.Release();
                }
            });

            var results = await Task.WhenAll(tasks);
            
            foreach (var result in results.Where(r => r != null))
            {
                ProcessSqlInjectionResult(result);
            }
        }

        private async Task<SqlInjectionResult> ProcessSingleUrlAsync(string url, CancellationToken cancellationToken)
        {
            try
            {
                LogMessage($"Testing URL: {url}");
                var result = await _sqlEngine.TestUrlAsync(url, cancellationToken);
                
                if (result.IsVulnerable)
                {
                    LogMessage($"Vulnerabilities found in {url}: {result.Vulnerabilities.Count}");
                }
                
                Interlocked.Increment(ref _currentTestIndex);
                return result;
            }
            catch (Exception ex)
            {
                LogMessage($"Error testing {url}: {ex.Message}");
                return null;
            }
        }

        private void ProcessSqlInjectionResult(SqlInjectionResult result)
        {
            if (result?.Vulnerabilities == null) return;

            foreach (var vulnerability in result.Vulnerabilities)
            {
                var testResult = new TestResult
                {
                    Url = result.Url,
                    Payload = new SqlInjectionPayload
                    {
                        Title = vulnerability.Payload.Title,
                        PayloadString = vulnerability.Payload.PayloadString,
                        Risk = vulnerability.Payload.Risk,
                        Platform = vulnerability.Payload.Platform,
                        Category = vulnerability.Payload.Category
                    },
                    IsVulnerable = true,
                    ResponseTime = (int)vulnerability.ResponseTime.TotalMilliseconds,
                    ResponseCode = vulnerability.ResponseCode,
                    DetectionMethod = vulnerability.DetectionMethod,
                    Confidence = vulnerability.Confidence,
                    DatabaseType = vulnerability.DatabaseType,
                    Evidence = vulnerability.Evidence,
                    Response = vulnerability.Response
                };

                SafeAddResult(testResult);
            }
        }

        private void SafeAddResult(TestResult result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<TestResult>(SafeAddResult), result);
                return;
            }

            _results.Add(result);
            var displayText = $"[{result.DetectionMethod}] {result.Url} - {result.Payload.Title} (Confidence: {result.Confidence:P0})";
            lstResults.Items.Add(displayText);
            LogMessage($"Vulnerability found: {result.Url} with payload: {result.Payload.Title} (Method: {result.DetectionMethod})");
        }

        private void UpdateProgress()
        {
            if (_payloads.Count == 0) return;

            int progress = Math.Min(100, (_currentTestIndex * 100) / Math.Max(1, _payloads.Count));
            progressBar.Value = progress;
            lblStatus.Text = $"Testing: {_currentTestIndex} URLs processed | Found: {_results.Count} vulnerabilities";
        }

        private void TestingComplete()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(TestingComplete));
                return;
            }

            _isTesting = false;
            _progressTimer.Stop();
            SetControlsEnabled(true);
            btnStop.Enabled = false;

            LogMessage($"Testing complete! Found {_results.Count} vulnerabilities");
            MessageBox.Show($"Testing complete! Found {_results.Count} vulnerabilities");
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _isTesting = false;
            _cancellationTokenSource?.Cancel();
            btnStop.Enabled = false;
            LogMessage("Testing stopped by user");
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
                        txtUrls.Text = File.ReadAllText(ofd.FileName);
                        MessageBox.Show($"Loaded URLs from {ofd.FileName}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading file: {ex.Message}");
                    }
                }
            }
        }

        private void BtnSendToDumper_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a vulnerability");
                return;
            }

            var result = _results[lstResults.SelectedIndex];
            OnSendToDumper?.Invoke(this, result);
            MessageBox.Show("Vulnerability sent to Dumper");
        }

        private void LstResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstResults.SelectedIndex != -1)
            {
                var result = _results[lstResults.SelectedIndex];
                OnSendToDumper?.Invoke(this, result);
                MessageBox.Show("Vulnerability sent to Dumper");
            }
        }

        private void LstResults_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lstResults.SelectedIndex != -1)
            {
                contextMenuStrip.Show(lstResults, e.Location);
            }
        }

        private void SetControlsEnabled(bool enabled)
        {
            txtUrls.Enabled = enabled;
            nudThreads.Enabled = enabled;
            btnStart.Enabled = enabled;
            btnLoad.Enabled = enabled;
            btnSendToDumper.Enabled = enabled;
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

        // Context menu handlers
        private void sendToDumperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnSendToDumper_Click(sender, e);
        }

        private void copyURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedIndex != -1)
            {
                var result = _results[lstResults.SelectedIndex];
                Clipboard.SetText(result.Url);
            }
        }

        private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedIndex != -1)
            {
                var result = _results[lstResults.SelectedIndex];
                var details = $"URL: {result.Url}\n" +
                             $"Payload: {result.Payload.PayloadString}\n" +
                             $"Risk: {result.Payload.Risk}\n" +
                             $"Platform: {result.Payload.Platform}\n" +
                             $"Category: {result.Payload.Category}\n" +
                             $"Detection Method: {result.DetectionMethod}\n" +
                             $"Confidence: {result.Confidence:P0}\n" +
                             $"Database Type: {result.DatabaseType}\n" +
                             $"Response Time: {result.ResponseTime}ms\n" +
                             $"Response Code: {result.ResponseCode}\n" +
                             $"Evidence: {result.Evidence}";
                
                MessageBox.Show(details, "Vulnerability Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}