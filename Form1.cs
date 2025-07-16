using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using BoomSQL.Core;

namespace BoomSQL
{
    public partial class Form1 : Form
    {
        private DorkPage? _dorkPage;
        private CrawlerPage? _crawlerPage;
        private TesterPage? _testerPage;
        private DumperPage? _dumperPage;
        private SettingsPage? _settingsPage;

        public Form1()
        {
            // Prevent designer from initializing pages at design time
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                InitializeComponent();
                contentPanel.Dock = DockStyle.Fill;
                SetupNavigation();
                SetupInterPageCommunication();
            }
        }

        private void SetupNavigation()
        {
            // Wire up navigation events
            Dorkbutton.Click += (s, e) => ShowDorkPage();
            crawlerbutton.Click += (s, e) => ShowCrawlerPage();
            Testerbutton.Click += (s, e) => ShowTesterPage();
            dumperbutton.Click += (s, e) => ShowDumperPage();
            settingsbutton.Click += (s, e) => ShowSettingsPage();
        }

        private void SetupInterPageCommunication()
        {
            // Set up communication between pages
            // This will be called when pages are created
        }

        private void ShowDorkPage()
        {
            if (_dorkPage == null)
            {
                _dorkPage = new DorkPage();
                _dorkPage.OnSendToTester += (sender, urls) => {
                    ShowTesterPage();
                    _testerPage?.LoadUrls(urls);
                };
            }
            ShowPage(_dorkPage);
        }

        private void ShowCrawlerPage()
        {
            if (_crawlerPage == null)
            {
                _crawlerPage = new CrawlerPage();
                _crawlerPage.OnSendToTester += (sender, urls) => {
                    ShowTesterPage();
                    _testerPage?.LoadUrls(urls);
                };
            }
            ShowPage(_crawlerPage);
        }

        private void ShowTesterPage()
        {
            if (_testerPage == null)
            {
                _testerPage = new TesterPage();
                _testerPage.OnSendToDumper += (sender, result) => {
                    ShowDumperPage();
                    _dumperPage?.SetVulnerability(result);
                };
            }
            ShowPage(_testerPage);
        }

        private void ShowDumperPage()
        {
            if (_dumperPage == null)
            {
                _dumperPage = new DumperPage();
            }
            ShowPage(_dumperPage);
        }

        private void ShowSettingsPage()
        {
            if (_settingsPage == null)
            {
                _settingsPage = new SettingsPage();
            }
            ShowPage(_settingsPage);
        }

        private void ShowPage(UserControl page)
        {
            contentPanel.Controls.Clear();
            page.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(page);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            guna2ControlBox1.BringToFront();
            guna2ControlBox2.BringToFront();
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://myboom.vip");
        }

        private void Dorkbutton_Click(object sender, EventArgs e)
        {
            ShowDorkPage();
        }
    }

    // Base page class with transparency handling
    public class BasePage : UserControl
    {
        public BasePage()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;
            this.Dock = DockStyle.Fill;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (Parent != null)
            {
                InvokePaintBackground(Parent, e);
                InvokePaint(Parent, e);
            }
            else
            {
                base.OnPaintBackground(e);
            }
        }

        protected void LogMessage(string message)
        {
            // Base logging method that can be overridden
            System.Diagnostics.Debug.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
        }
    }
}


