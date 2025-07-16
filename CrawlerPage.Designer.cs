using Guna.UI2.WinForms;
using System.Windows.Forms;
using System.Drawing;

namespace BoomSQL
{
    partial class CrawlerPage
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2TextBox txtBaseUrl;
        private Guna2Button btnStart;
        private Guna2Button btnStop;
        private Guna2Button btnSave;
        private Guna2Button btnSendToTester;
        private ListBox lstResults;
        private Guna2ProgressBar progressBar;
        private Label lblStatus;
        private Guna2Button btnLoad;
        private Guna2Button btnShowLogs;
        private TextBox txtLogs;
        private SplitContainer splitContainer;
        private NumericUpDown nudThreads;
        private Label lblThreads;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtBaseUrl = new Guna2TextBox();
            btnStart = new Guna2Button();
            btnStop = new Guna2Button();
            btnSave = new Guna2Button();
            btnSendToTester = new Guna2Button();
            lstResults = new ListBox();
            progressBar = new Guna2ProgressBar();
            lblStatus = new Label();
            btnLoad = new Guna2Button();
            btnShowLogs = new Guna2Button();
            txtLogs = new TextBox();
            splitContainer = new SplitContainer();
            nudThreads = new NumericUpDown();
            lblThreads = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudThreads).BeginInit();
            SuspendLayout();
            // 
            // txtBaseUrl
            // 
            txtBaseUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBaseUrl.BackColor = Color.FromArgb(30, 30, 30);
            txtBaseUrl.BorderColor = Color.Blue;
            txtBaseUrl.BorderRadius = 5;
            txtBaseUrl.CustomizableEdges = customizableEdges1;
            txtBaseUrl.DefaultText = "";
            txtBaseUrl.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtBaseUrl.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtBaseUrl.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtBaseUrl.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtBaseUrl.FillColor = Color.FromArgb(40, 40, 40);
            txtBaseUrl.FocusedState.BorderColor = Color.Aqua;
            txtBaseUrl.Font = new Font("Segoe UI", 10F);
            txtBaseUrl.ForeColor = Color.White;
            txtBaseUrl.HoverState.BorderColor = Color.Silver;
            txtBaseUrl.Location = new Point(20, 70);
            txtBaseUrl.Margin = new Padding(6, 6, 6, 6);
            txtBaseUrl.Name = "txtBaseUrl";
            txtBaseUrl.PlaceholderForeColor = Color.Gray;
            txtBaseUrl.PlaceholderText = "Enter base URL (e.g., https://example.com)";
            txtBaseUrl.SelectedText = "";
            txtBaseUrl.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtBaseUrl.Size = new Size(2418, 50);
            txtBaseUrl.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStart.BackColor = Color.Transparent;
            btnStart.BorderRadius = 5;
            btnStart.CustomizableEdges = customizableEdges3;
            btnStart.DisabledState.BorderColor = Color.DarkGray;
            btnStart.DisabledState.CustomBorderColor = Color.DarkGray;
            btnStart.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnStart.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnStart.FillColor = Color.Green;
            btnStart.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(2448, 70);
            btnStart.Name = "btnStart";
            btnStart.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnStart.Size = new Size(150, 50);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start Crawl";
            // 
            // btnStop
            // 
            btnStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStop.BorderRadius = 5;
            btnStop.CustomizableEdges = customizableEdges5;
            btnStop.DisabledState.BorderColor = Color.DarkGray;
            btnStop.DisabledState.CustomBorderColor = Color.DarkGray;
            btnStop.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnStop.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnStop.Enabled = false;
            btnStop.FillColor = Color.FromArgb(192, 0, 0);
            btnStop.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(2448, 130);
            btnStop.Name = "btnStop";
            btnStop.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnStop.Size = new Size(150, 50);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BorderRadius = 5;
            btnSave.CustomizableEdges = customizableEdges7;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.SlateBlue;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(2448, 1096);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save Results";
            // 
            // btnSendToTester
            // 
            btnSendToTester.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSendToTester.BorderRadius = 5;
            btnSendToTester.CustomizableEdges = customizableEdges9;
            btnSendToTester.DisabledState.BorderColor = Color.DarkGray;
            btnSendToTester.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSendToTester.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSendToTester.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSendToTester.FillColor = Color.FromArgb(0, 100, 192);
            btnSendToTester.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSendToTester.ForeColor = Color.White;
            btnSendToTester.Location = new Point(2448, 1146);
            btnSendToTester.Name = "btnSendToTester";
            btnSendToTester.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnSendToTester.Size = new Size(150, 40);
            btnSendToTester.TabIndex = 4;
            btnSendToTester.Text = "Send to Tester";
            // 
            // lstResults
            // 
            lstResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstResults.BackColor = Color.FromArgb(40, 40, 40);
            lstResults.BorderStyle = BorderStyle.None;
            lstResults.Font = new Font("Consolas", 10F);
            lstResults.ForeColor = Color.White;
            lstResults.FormattingEnabled = true;
            lstResults.Location = new Point(20, 180);
            lstResults.Name = "lstResults";
            lstResults.Size = new Size(2418, 1024);
            lstResults.TabIndex = 5;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.CustomizableEdges = customizableEdges11;
            progressBar.Location = new Point(20, 130);
            progressBar.Name = "progressBar";
            progressBar.ShadowDecoration.CustomizableEdges = customizableEdges12;
            progressBar.Size = new Size(2418, 20);
            progressBar.TabIndex = 6;
            progressBar.Text = "guna2ProgressBar1";
            progressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.ForeColor = Color.Aqua;
            lblStatus.Location = new Point(20, 155);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(166, 32);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Status: Ready";
            // 
            // btnLoad
            // 
            btnLoad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLoad.BorderRadius = 5;
            btnLoad.CustomizableEdges = customizableEdges13;
            btnLoad.DisabledState.BorderColor = Color.DarkGray;
            btnLoad.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLoad.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLoad.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLoad.FillColor = Color.FromArgb(70, 70, 70);
            btnLoad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLoad.ForeColor = Color.Silver;
            btnLoad.Location = new Point(2608, 70);
            btnLoad.Name = "btnLoad";
            btnLoad.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnLoad.Size = new Size(220, 50);
            btnLoad.TabIndex = 8;
            btnLoad.Text = "Load from File";
            // 
            // btnShowLogs
            // 
            btnShowLogs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnShowLogs.BorderRadius = 5;
            btnShowLogs.CustomizableEdges = customizableEdges15;
            btnShowLogs.DisabledState.BorderColor = Color.DarkGray;
            btnShowLogs.DisabledState.CustomBorderColor = Color.DarkGray;
            btnShowLogs.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnShowLogs.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnShowLogs.FillColor = Color.DimGray;
            btnShowLogs.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnShowLogs.ForeColor = Color.White;
            btnShowLogs.Location = new Point(20, 1216);
            btnShowLogs.Name = "btnShowLogs";
            btnShowLogs.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnShowLogs.Size = new Size(150, 40);
            btnShowLogs.TabIndex = 9;
            btnShowLogs.Text = "Show Logs";
            // 
            // txtLogs
            // 
            txtLogs.BackColor = Color.FromArgb(30, 30, 30);
            txtLogs.Dock = DockStyle.Fill;
            txtLogs.Font = new Font("Consolas", 9F);
            txtLogs.ForeColor = Color.White;
            txtLogs.Location = new Point(0, 0);
            txtLogs.Multiline = true;
            txtLogs.Name = "txtLogs";
            txtLogs.ReadOnly = true;
            txtLogs.ScrollBars = ScrollBars.Vertical;
            txtLogs.Size = new Size(150, 46);
            txtLogs.TabIndex = 10;
            // 
            // splitContainer
            // 
            splitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer.Location = new Point(20, 180);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(lstResults);
            splitContainer.Panel1.Controls.Add(progressBar);
            splitContainer.Panel1.Controls.Add(lblStatus);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(txtLogs);
            splitContainer.Panel2Collapsed = true;
            splitContainer.Size = new Size(2818, 1026);
            splitContainer.SplitterDistance = 400;
            splitContainer.TabIndex = 11;
            // 
            // nudThreads
            // 
            nudThreads.BackColor = Color.FromArgb(40, 40, 40);
            nudThreads.ForeColor = Color.White;
            nudThreads.Location = new Point(990, 140);
            nudThreads.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudThreads.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudThreads.Name = "nudThreads";
            nudThreads.Size = new Size(100, 39);
            nudThreads.TabIndex = 13;
            nudThreads.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblThreads
            // 
            lblThreads.AutoSize = true;
            lblThreads.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblThreads.ForeColor = Color.Aqua;
            lblThreads.Location = new Point(990, 115);
            lblThreads.Name = "lblThreads";
            lblThreads.Size = new Size(111, 32);
            lblThreads.TabIndex = 12;
            lblThreads.Text = "Threads:";
            // 
            // CrawlerPage
            // 
            BackColor = Color.Transparent;
            Controls.Add(lblThreads);
            Controls.Add(nudThreads);
            Controls.Add(splitContainer);
            Controls.Add(btnShowLogs);
            Controls.Add(btnLoad);
            Controls.Add(btnSendToTester);
            Controls.Add(btnSave);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(txtBaseUrl);
            Name = "CrawlerPage";
            Size = new Size(2868, 1296);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel1.PerformLayout();
            splitContainer.Panel2.ResumeLayout(false);
            splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudThreads).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}