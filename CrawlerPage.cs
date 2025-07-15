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
using System.Net.Http;
using System.Threading;

namespace BoomSQL
{
    public partial class CrawlerPage : BasePage
    {
        private WebCrawler _crawler;
        private HttpClient _httpClient;
        private List<CrawlerResult> _crawlResults = new List<CrawlerResult>();
        private bool _isCrawling = false;
        private System.Windows.Forms.Timer _progressTimer = new System.Windows.Forms.Timer();
        private CancellationTokenSource _cancellationTokenSource;
        private TextBox txtBaseUrl;
        private NumericUpDown nudDepth;
        private NumericUpDown nudMaxUrls;
        private NumericUpDown nudThreads;
        private NumericUpDown nudDelay;
        private CheckBox chkStayInDomain;
        private Button btnStart;
        private Button btnStop;
        private Button btnSave;
        private Button btnSendToTester;
        private Button btnLoad;
        private Button btnShowLogs;
        private ListBox lstResults;
        private Label lblStatus;
        private TextBox txtLogs;

        public event EventHandler<List<string>> OnSendToTester;

        public CrawlerPage()
        {
            InitializeComponent();
            InitializeEventHandlers();
            InitializeTimer();
            InitializeCrawler();
        }

        private void InitializeCrawler()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", 
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
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

            _isCrawling = true;
            _crawlResults.Clear();
            lstResults.Items.Clear();
            txtLogs.Clear();
            SetControlsEnabled(false);
            btnStop.Enabled = true;
            _cancellationTokenSource = new CancellationTokenSource();

            // Configure crawler
            var config = new WebCrawlerConfig
            {
                MaxDepth = (int)nudDepth.Value,
                MaxUrls = (int)nudMaxUrls.Value,
                MaxConcurrentRequests = (int)nudThreads.Value,
                RequestDelay = (int)nudDelay.Value,
                StayInDomain = chkStayInDomain.Checked,
                BaseUrl = baseUrl,
                EnableFormDetection = true,
                EnableParameterExtraction = true,
                EnableCookieExtraction = true,
                EnableHeaderExtraction = true,
                FollowRedirects = true,
                MaxRedirects = 5,
                RequestTimeout = 30
            };

            _crawler = new WebCrawler(_httpClient, config, LogMessage);
            _progressTimer.Start();

            try
            {
                LogMessage($"Starting crawl of: {baseUrl}");
                var results = await _crawler.CrawlAsync(baseUrl, _cancellationTokenSource.Token);
                _crawlResults = results;
                
                PopulateResults();
                LogMessage($"Crawl completed. Found {results.Count} URLs, {results.Sum(r => r.Parameters.Count)} parameters");
            }
            catch (OperationCanceledException)
            {
                LogMessage("Crawl was cancelled");
            }
            catch (Exception ex)
            {
                LogMessage($"Crawl error: {ex.Message}");
                MessageBox.Show($"Crawl error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isCrawling = false;
                _progressTimer.Stop();
                SetControlsEnabled(true);
                btnStop.Enabled = false;
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (_crawler != null)
            {
                _crawler.Stop();
            }
            _cancellationTokenSource?.Cancel();
            _isCrawling = false;
            btnStop.Enabled = false;
            LogMessage("Crawl stopped by user");
        }

        private void PopulateResults()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(PopulateResults));
                return;
            }

            lstResults.Items.Clear();
            
            foreach (var result in _crawlResults)
            {
                var displayText = $"{result.Url} (Depth: {result.Depth}, Params: {result.Parameters.Count})";
                lstResults.Items.Add(displayText);
            }

            lblStatus.Text = $"Found {_crawlResults.Count} URLs with {_crawlResults.Sum(r => r.Parameters.Count)} parameters";
        }

        private void UpdateProgress()
        {
            if (_isCrawling)
            {
                lblStatus.Text = $"Crawling... Found {_crawlResults.Count} URLs";
            }
        }

        private void BtnSendToTester_Click(object sender, EventArgs e)
        {
            if (_crawlResults.Count == 0)
            {
                MessageBox.Show("No URLs to send");
                return;
            }

            var urlsWithParams = _crawlResults
                .Where(r => r.Parameters.Count > 0)
                .Select(r => r.Url)
                .ToList();

            if (urlsWithParams.Count == 0)
            {
                MessageBox.Show("No URLs with parameters found");
                return;
            }

            OnSendToTester?.Invoke(this, urlsWithParams);
            MessageBox.Show($"Sent {urlsWithParams.Count} URLs to Tester");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (_crawlResults.Count == 0)
            {
                MessageBox.Show("No URLs to save");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text Files|*.txt|All Files|*.*";
                sfd.FileName = "crawled-urls.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var urls = _crawlResults.Select(r => r.Url).ToList();
                        File.WriteAllLines(sfd.FileName, urls);
                        MessageBox.Show($"Saved {urls.Count} URLs to {sfd.FileName}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}");
                    }
                }
            }
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
                        if (urls.Length > 0)
                        {
                            txtBaseUrl.Text = urls[0];
                            MessageBox.Show($"Loaded base URL from {ofd.FileName}");
                        }
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
            if (txtLogs.Visible)
            {
                txtLogs.Visible = false;
                btnShowLogs.Text = "Show Logs";
            }
            else
            {
                txtLogs.Visible = true;
                btnShowLogs.Text = "Hide Logs";
            }
        }

        private void SetControlsEnabled(bool enabled)
        {
            txtBaseUrl.Enabled = enabled;
            nudDepth.Enabled = enabled;
            nudMaxUrls.Enabled = enabled;
            nudThreads.Enabled = enabled;
            nudDelay.Enabled = enabled;
            chkStayInDomain.Enabled = enabled;
            btnStart.Enabled = enabled;
            btnLoad.Enabled = enabled;
            btnSave.Enabled = enabled;
            btnSendToTester.Enabled = enabled;
        }

        private void LogMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogMessage), message);
                return;
            }

            txtLogs.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\r\n");
            txtLogs.ScrollToCaret();
        }
    }
}