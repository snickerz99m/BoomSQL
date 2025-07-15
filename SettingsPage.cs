using BoomSQL.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BoomSQL
{
    public partial class SettingsPage : BasePage
    {
        private BindingList<Proxy> _proxies = new BindingList<Proxy>();
        private List<string> _userAgents = new List<string>();
        private bool _isTestingProxies = false;

        public SettingsPage()
        {
            InitializeComponent();
            InitializeEventHandlers();
            LoadSettings();
        }

        private void InitializeEventHandlers()
        {
            btnLoadProxies.Click += BtnLoadProxies_Click;
            btnSaveProxies.Click += BtnSaveProxies_Click;
            btnAddProxy.Click += BtnAddProxy_Click;
            btnRemoveProxy.Click += BtnRemoveProxy_Click;
            btnTestProxies.Click += BtnTestProxies_Click;
            btnSaveSettings.Click += BtnSaveSettings_Click;
        }

        private void LoadSettings()
        {
            // Load proxies
            var proxyPath = Path.Combine(Application.StartupPath, "proxies.txt");
            if (File.Exists(proxyPath))
            {
                _proxies = new BindingList<Proxy>(ProxyManager.LoadProxies(proxyPath).ToList());
                dgvProxies.DataSource = _proxies;
                LogMessage($"Loaded {_proxies.Count} proxies");
            }

            // Load user agents
            var uaPath = Path.Combine(Application.StartupPath, "useragents.txt");
            if (File.Exists(uaPath))
            {
                _userAgents = File.ReadLines(uaPath)
                    .Where(l => !string.IsNullOrWhiteSpace(l))
                    .ToList();
                LogMessage($"Loaded {_userAgents.Count} user agents");
            }

            // Load thread settings
            nudDorkThreads.Value = Properties.Settings.Default.DorkThreads;
            nudCrawlerThreads.Value = Properties.Settings.Default.CrawlerThreads;
            nudTesterThreads.Value = Properties.Settings.Default.TesterThreads;
            nudDumperThreads.Value = Properties.Settings.Default.DumperThreads;
        }

        private void BtnLoadProxies_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text Files|*.txt|All Files|*.*";
                ofd.FileName = "proxies.txt";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _proxies = new BindingList<Proxy>(ProxyManager.LoadProxies(ofd.FileName).ToList());
                        dgvProxies.DataSource = _proxies;
                        MessageBox.Show($"Loaded {_proxies.Count} proxies from {ofd.FileName}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading proxies: {ex.Message}");
                    }
                }
            }
        }

        private void BtnSaveProxies_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text Files|*.txt|All Files|*.*";
                sfd.FileName = "proxies.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var lines = _proxies.Select(p =>
                            string.IsNullOrEmpty(p.Username) ?
                                $"{p.Host}:{p.Port}" :
                                $"{p.Host}:{p.Port}:{p.Username}:{p.Password}");

                        File.WriteAllLines(sfd.FileName, lines);
                        MessageBox.Show($"Saved {_proxies.Count} proxies to {sfd.FileName}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving proxies: {ex.Message}");
                    }
                }
            }
        }

        private void BtnAddProxy_Click(object sender, EventArgs e)
        {
            var proxy = new Proxy
            {
                Host = txtHost.Text,
                Port = (int)nudPort.Value,
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            _proxies.Add(proxy);
            LogMessage($"Added proxy: {proxy.Host}:{proxy.Port}");
        }

        private void BtnRemoveProxy_Click(object sender, EventArgs e)
        {
            if (dgvProxies.SelectedRows.Count > 0)
            {
                var selected = dgvProxies.SelectedRows[0].DataBoundItem as Proxy;
                if (selected != null)
                {
                    _proxies.Remove(selected);
                    LogMessage($"Removed proxy: {selected.Host}:{selected.Port}");
                }
            }
        }

        private async void BtnTestProxies_Click(object sender, EventArgs e)
        {
            if (_isTestingProxies) return;

            _isTestingProxies = true;
            btnTestProxies.Enabled = false;
            dgvProxies.Columns["Status"].Visible = true;

            foreach (DataGridViewRow row in dgvProxies.Rows)
            {
                var proxy = row.DataBoundItem as Proxy;
                if (proxy == null) continue;

                row.Cells["Status"].Value = "Testing...";
                await Task.Delay(100); // Yield to UI thread

                bool isAlive = await TestProxy(proxy);
                row.Cells["Status"].Value = isAlive ? "Alive" : "Dead";
                row.DefaultCellStyle.BackColor = isAlive ? Color.FromArgb(40, 80, 40) : Color.FromArgb(80, 40, 40);
            }

            // Remove dead proxies if requested
            if (chkRemoveDead.Checked)
            {
                for (int i = _proxies.Count - 1; i >= 0; i--)
                {
                    if (dgvProxies.Rows[i].Cells["Status"].Value?.ToString() == "Dead")
                    {
                        _proxies.RemoveAt(i);
                    }
                }
            }

            _isTestingProxies = false;
            btnTestProxies.Enabled = true;
        }

        private async Task<bool> TestProxy(Proxy proxy)
        {
            try
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(5);

                    if (!string.IsNullOrEmpty(proxy.Username))
                    {
                        client.DefaultRequestHeaders.ProxyAuthorization =
                            new System.Net.Http.Headers.AuthenticationHeaderValue(
                                "Basic", Convert.ToBase64String(
                                    System.Text.Encoding.ASCII.GetBytes(
                                        $"{proxy.Username}:{proxy.Password}")));
                    }

                    var response = await client.GetAsync("http://www.google.com");
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }

        private void BtnSaveSettings_Click(object sender, EventArgs e)
        {
            // Save thread settings
            Properties.Settings.Default.DorkThreads = (int)nudDorkThreads.Value;
            Properties.Settings.Default.CrawlerThreads = (int)nudCrawlerThreads.Value;
            Properties.Settings.Default.TesterThreads = (int)nudTesterThreads.Value;
            Properties.Settings.Default.DumperThreads = (int)nudDumperThreads.Value;
            Properties.Settings.Default.Save();

            // Save proxies
            var proxyPath = Path.Combine(Application.StartupPath, "proxies.txt");
            var lines = _proxies.Select(p =>
                string.IsNullOrEmpty(p.Username) ?
                    $"{p.Host}:{p.Port}" :
                    $"{p.Host}:{p.Port}:{p.Username}:{p.Password}");
            File.WriteAllLines(proxyPath, lines);

            MessageBox.Show("Settings saved successfully");
        }

        private void LogMessage(string message)
        {
            txtLogs.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\r\n");
        }
    }
}