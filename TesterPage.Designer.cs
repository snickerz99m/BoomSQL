using Guna.UI2.WinForms;
using System.Windows.Forms;
using System.Drawing;

namespace BoomSQL
{
    partial class TesterPage
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2TextBox txtUrls;
        private Guna2Button btnStart;
        private Guna2Button btnStop;
        private Guna2Button btnLoad;
        private Guna2Button btnSendToDumper;
        private ListBox lstResults;
        private Guna2ProgressBar progressBar;
        private Label lblStatus;
        private TextBox txtLogs;
        private NumericUpDown nudThreads;
        private Label lblThreads;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem sendToDumperToolStripMenuItem;
        private ToolStripMenuItem copyURLToolStripMenuItem;
        private ToolStripMenuItem viewDetailsToolStripMenuItem;

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
            components = new System.ComponentModel.Container();
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
            txtUrls = new Guna2TextBox();
            btnStart = new Guna2Button();
            btnStop = new Guna2Button();
            btnLoad = new Guna2Button();
            btnSendToDumper = new Guna2Button();
            lstResults = new ListBox();
            progressBar = new Guna2ProgressBar();
            lblStatus = new Label();
            txtLogs = new TextBox();
            nudThreads = new NumericUpDown();
            lblThreads = new Label();
            contextMenuStrip = new ContextMenuStrip(components);
            sendToDumperToolStripMenuItem = new ToolStripMenuItem();
            copyURLToolStripMenuItem = new ToolStripMenuItem();
            viewDetailsToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)nudThreads).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // txtUrls
            // 
            txtUrls.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUrls.BackColor = Color.FromArgb(30, 30, 30);
            txtUrls.BorderColor = Color.Blue;
            txtUrls.BorderRadius = 5;
            txtUrls.CustomizableEdges = customizableEdges1;
            txtUrls.DefaultText = "";
            txtUrls.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtUrls.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtUrls.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtUrls.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtUrls.FillColor = Color.FromArgb(40, 40, 40);
            txtUrls.FocusedState.BorderColor = Color.Aqua;
            txtUrls.Font = new Font("Segoe UI", 10F);
            txtUrls.ForeColor = Color.White;
            txtUrls.HoverState.BorderColor = Color.Silver;
            txtUrls.Location = new Point(20, 70);
            txtUrls.Margin = new Padding(6, 6, 6, 6);
            txtUrls.Multiline = true;
            txtUrls.Name = "txtUrls";
            txtUrls.PlaceholderForeColor = Color.Gray;
            txtUrls.PlaceholderText = "Enter one URL per line";
            txtUrls.SelectedText = "";
            txtUrls.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtUrls.Size = new Size(2668, 150);
            txtUrls.TabIndex = 0;
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
            btnStart.Location = new Point(2698, 70);
            btnStart.Name = "btnStart";
            btnStart.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnStart.Size = new Size(150, 50);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start Test";
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
            btnStop.Location = new Point(2698, 130);
            btnStop.Name = "btnStop";
            btnStop.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnStop.Size = new Size(150, 50);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            // 
            // btnLoad
            // 
            btnLoad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLoad.BorderRadius = 5;
            btnLoad.CustomizableEdges = customizableEdges7;
            btnLoad.DisabledState.BorderColor = Color.DarkGray;
            btnLoad.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLoad.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLoad.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLoad.FillColor = Color.FromArgb(70, 70, 70);
            btnLoad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLoad.ForeColor = Color.Silver;
            btnLoad.Location = new Point(2698, 190);
            btnLoad.Name = "btnLoad";
            btnLoad.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnLoad.Size = new Size(150, 50);
            btnLoad.TabIndex = 3;
            btnLoad.Text = "Load URLs";
            // 
            // btnSendToDumper
            // 
            btnSendToDumper.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSendToDumper.BorderRadius = 5;
            btnSendToDumper.CustomizableEdges = customizableEdges9;
            btnSendToDumper.DisabledState.BorderColor = Color.DarkGray;
            btnSendToDumper.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSendToDumper.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSendToDumper.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSendToDumper.FillColor = Color.FromArgb(0, 100, 192);
            btnSendToDumper.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSendToDumper.ForeColor = Color.White;
            btnSendToDumper.Location = new Point(2698, 1050);
            btnSendToDumper.Name = "btnSendToDumper";
            btnSendToDumper.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnSendToDumper.Size = new Size(150, 40);
            btnSendToDumper.TabIndex = 4;
            btnSendToDumper.Text = "Send to Dumper";
            // 
            // lstResults
            // 
            lstResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstResults.BackColor = Color.FromArgb(40, 40, 40);
            lstResults.BorderStyle = BorderStyle.None;
            lstResults.Font = new Font("Consolas", 10F);
            lstResults.ForeColor = Color.White;
            lstResults.FormattingEnabled = true;
            lstResults.Location = new Point(20, 250);
            lstResults.Name = "lstResults";
            lstResults.Size = new Size(2668, 832);
            lstResults.TabIndex = 5;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.CustomizableEdges = customizableEdges11;
            progressBar.Location = new Point(20, 220);
            progressBar.Name = "progressBar";
            progressBar.ShadowDecoration.CustomizableEdges = customizableEdges12;
            progressBar.Size = new Size(2668, 20);
            progressBar.TabIndex = 6;
            progressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.ForeColor = Color.Aqua;
            lblStatus.Location = new Point(20, 670);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(166, 32);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Status: Ready";
            // 
            // txtLogs
            // 
            txtLogs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtLogs.BackColor = Color.FromArgb(30, 30, 30);
            txtLogs.Font = new Font("Consolas", 9F);
            txtLogs.ForeColor = Color.White;
            txtLogs.Location = new Point(20, 1120);
            txtLogs.Multiline = true;
            txtLogs.Name = "txtLogs";
            txtLogs.ReadOnly = true;
            txtLogs.ScrollBars = ScrollBars.Vertical;
            txtLogs.Size = new Size(2668, 70);
            txtLogs.TabIndex = 8;
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
            nudThreads.TabIndex = 10;
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
            lblThreads.TabIndex = 9;
            lblThreads.Text = "Threads:";
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(32, 32);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { sendToDumperToolStripMenuItem, copyURLToolStripMenuItem, viewDetailsToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(266, 118);
            // 
            // sendToDumperToolStripMenuItem
            // 
            sendToDumperToolStripMenuItem.Name = "sendToDumperToolStripMenuItem";
            sendToDumperToolStripMenuItem.Size = new Size(265, 38);
            sendToDumperToolStripMenuItem.Text = "Send to Dumper";
            sendToDumperToolStripMenuItem.Click += sendToDumperToolStripMenuItem_Click;
            // 
            // copyURLToolStripMenuItem
            // 
            copyURLToolStripMenuItem.Name = "copyURLToolStripMenuItem";
            copyURLToolStripMenuItem.Size = new Size(265, 38);
            copyURLToolStripMenuItem.Text = "Copy URL";
            copyURLToolStripMenuItem.Click += copyURLToolStripMenuItem_Click;
            // 
            // viewDetailsToolStripMenuItem
            // 
            viewDetailsToolStripMenuItem.Name = "viewDetailsToolStripMenuItem";
            viewDetailsToolStripMenuItem.Size = new Size(265, 38);
            viewDetailsToolStripMenuItem.Text = "View Details";
            viewDetailsToolStripMenuItem.Click += viewDetailsToolStripMenuItem_Click;
            // 
            // TesterPage
            // 
            BackColor = Color.Transparent;
            Controls.Add(lblThreads);
            Controls.Add(nudThreads);
            Controls.Add(txtLogs);
            Controls.Add(lblStatus);
            Controls.Add(progressBar);
            Controls.Add(lstResults);
            Controls.Add(btnSendToDumper);
            Controls.Add(btnLoad);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(txtUrls);
            Name = "TesterPage";
            Size = new Size(2868, 1200);
            ((System.ComponentModel.ISupportInitialize)nudThreads).EndInit();
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}