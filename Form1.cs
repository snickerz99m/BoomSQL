using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace BoomSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Prevent designer from initializing pages at design time
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                InitializeComponent();
                contentPanel.Dock = DockStyle.Fill;
                SetupNavigation();
            }
        }

        private void SetupNavigation()
        {
            // Wire up navigation events
            Dorkbutton.Click += (s, e) => ShowPage(new DorkPage());
            crawlerbutton.Click += (s, e) => ShowPage(new CrawlerPage());
            Testerbutton.Click += (s, e) => ShowPage(new TesterPage());
            dumperbutton.Click += (s, e) => ShowPage(new DumperPage());
            settingsbutton.Click += (s, e) => ShowPage(new SettingsPage());
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
    }
}


