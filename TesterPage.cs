using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

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

        public event EventHandler<TestResult> OnSendToDumper;

        public TesterPage()
        {
            InitializeComponent();
            InitializeEventHandlers();
            InitializeTimer();
            LoadPayloads();
            LoadTampers();
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
                            Platform = p.Attribute("platform")?.Value
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

            var tasks = new List<Task>();
            for (int i = 0; i < _maxThreads; i++)
            {
                tasks.Add(Task.Run(ProcessTests));
            }

            await Task.WhenAll(tasks);

            TestingComplete();
        }

        private async Task ProcessTests()
        {
            while (_isTesting)
            {
                int currentIndex = Interlocked.Increment(ref _currentTestIndex) - 1;
                if (currentIndex >= _payloads.Count) break;

                var payload = _payloads[currentIndex];
                foreach (var url in txtUrls.Lines)
                {
                    if (!_isTesting) return;

                    try
                    {
                        var result = await TestUrl(url, payload);
                        if (result != null && result.IsVulnerable)
                        {
                            SafeAddResult(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogMessage($"Test error: {ex.Message}");
                    }
                }
            }
        }

        private async Task<TestResult> TestUrl(string url, SqlInjectionPayload payload)
        {
            // Actual SQL injection test implementation would go here
            // This is simplified for example purposes

            // Simulate test time
            await Task.Delay(1000);

            // Random result for demo
            var random = new Random();
            bool isVulnerable = random.Next(100) > 70;

            return new TestResult
            {
                Url = url,
                Payload = payload,
                IsVulnerable = isVulnerable,
                ResponseTime = random.Next(100, 1000),
                ResponseCode = 200
            };
        }

        private void SafeAddResult(TestResult result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<TestResult>(SafeAddResult), result);
                return;
            }

            _results.Add(result);
            lstResults.Items.Add($"[VULN] {result.Url} - {result.Payload.Title}");
            LogMessage($"Vulnerability found: {result.Url} with payload: {result.Payload.Title}");
        }

        private void UpdateProgress()
        {
            if (_payloads.Count == 0) return;

            int progress = (int)((double)_currentTestIndex / _payloads.Count * 100);
            progressBar.Value = Math.Min(100, progress);
            lblStatus.Text = $"Testing: {_currentTestIndex}/{_payloads.Count} payloads | Found: {_results.Count} vulnerabilities";
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
                MessageBox.Show($"URL: {result.Url}\nPayload: {result.Payload.PayloadString}\nRisk: {result.Payload.Risk}", "Vulnerability Details");
            }
        }
    }

    public class SqlInjectionPayload
    {
        public string Title { get; set; }
        public string PayloadString { get; set; }
        public int Risk { get; set; }
        public string Platform { get; set; }
    }

    public class TestResult
    {
        public string Url { get; set; }
        public SqlInjectionPayload Payload { get; set; }
        public bool IsVulnerable { get; set; }
        public int ResponseTime { get; set; }
        public int ResponseCode { get; set; }
    }
}