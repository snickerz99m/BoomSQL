using Guna.UI2.WinForms;
using System.Windows.Forms;
using System.Drawing;

namespace BoomSQL
{
    partial class DumperPage
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2TextBox txtUrl;
        private Guna2Button btnStart;
        private Guna2Button btnStop;
        private Guna2Button btnSave;
        private Guna2Button btnLoad;
        private TreeView treeDatabase;
        private TextBox txtData;
        private Guna2ProgressBar progressBar;
        private Label lblStatus;
        private TextBox txtLogs;
        private Guna2Button btnDumpSelected;
        private Guna2Button btnDumpAll;
        private NumericUpDown nudThreads;
        private Label lblThreads;
        private SplitContainer splitContainer;

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
            txtUrl = new Guna2TextBox();
            btnStart = new Guna2Button();
            btnStop = new Guna2Button();
            btnSave = new Guna2Button();
            btnLoad = new Guna2Button();
            treeDatabase = new TreeView();
            txtData = new TextBox();
            progressBar = new Guna2ProgressBar();
            lblStatus = new Label();
            txtLogs = new TextBox();
            btnDumpSelected = new Guna2Button();
            btnDumpAll = new Guna2Button();
            nudThreads = new NumericUpDown();
            lblThreads = new Label();
            splitContainer = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)nudThreads).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // txtUrl
            // 
            txtUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUrl.BackColor = Color.FromArgb(30, 30, 30);
            txtUrl.BorderColor = Color.Blue;
            txtUrl.BorderRadius = 5;
            txtUrl.CustomizableEdges = customizableEdges1;
            txtUrl.DefaultText = "";
            txtUrl.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtUrl.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtUrl.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtUrl.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtUrl.FillColor = Color.FromArgb(40, 40, 40);
            txtUrl.FocusedState.BorderColor = Color.Aqua;
            txtUrl.Font = new Font("Segoe UI", 10F);
            txtUrl.ForeColor = Color.White;
            txtUrl.HoverState.BorderColor = Color.Silver;
            txtUrl.Location = new Point(20, 70);
            txtUrl.Margin = new Padding(6, 6, 6, 6);
            txtUrl.Name = "txtUrl";
            txtUrl.PlaceholderForeColor = Color.Gray;
            txtUrl.PlaceholderText = "Enter vulnerable URL";
            txtUrl.SelectedText = "";
            txtUrl.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtUrl.Size = new Size(2468, 50);
            txtUrl.TabIndex = 0;
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
            btnStart.Location = new Point(2498, 70);
            btnStart.Name = "btnStart";
            btnStart.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnStart.Size = new Size(150, 50);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start Dumping";
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
            btnStop.Location = new Point(2498, 130);
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
            btnSave.Location = new Point(2498, 1146);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save Data";
            // 
            // btnLoad
            // 
            btnLoad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLoad.BorderRadius = 5;
            btnLoad.CustomizableEdges = customizableEdges9;
            btnLoad.DisabledState.BorderColor = Color.DarkGray;
            btnLoad.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLoad.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLoad.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLoad.FillColor = Color.FromArgb(70, 70, 70);
            btnLoad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLoad.ForeColor = Color.Silver;
            btnLoad.Location = new Point(2658, 70);
            btnLoad.Name = "btnLoad";
            btnLoad.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnLoad.Size = new Size(150, 50);
            btnLoad.TabIndex = 4;
            btnLoad.Text = "Load URL";
            // 
            // treeDatabase
            // 
            treeDatabase.BackColor = Color.FromArgb(40, 40, 40);
            treeDatabase.BorderStyle = BorderStyle.None;
            treeDatabase.Dock = DockStyle.Fill;
            treeDatabase.Font = new Font("Segoe UI", 10F);
            treeDatabase.ForeColor = Color.White;
            treeDatabase.Location = new Point(0, 0);
            treeDatabase.Name = "treeDatabase";
            treeDatabase.Size = new Size(1067, 1046);
            treeDatabase.TabIndex = 5;
            // 
            // txtData
            // 
            txtData.BackColor = Color.FromArgb(30, 30, 30);
            txtData.Dock = DockStyle.Fill;
            txtData.Font = new Font("Consolas", 10F);
            txtData.ForeColor = Color.White;
            txtData.Location = new Point(0, 0);
            txtData.Multiline = true;
            txtData.Name = "txtData";
            txtData.ScrollBars = ScrollBars.Both;
            txtData.Size = new Size(1597, 1046);
            txtData.TabIndex = 6;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.CustomizableEdges = customizableEdges11;
            progressBar.Location = new Point(20, 1216);
            progressBar.Name = "progressBar";
            progressBar.ShadowDecoration.CustomizableEdges = customizableEdges12;
            progressBar.Size = new Size(2468, 20);
            progressBar.TabIndex = 7;
            progressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.ForeColor = Color.Aqua;
            lblStatus.Location = new Point(20, 1186);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(166, 32);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Status: Ready";
            // 
            // txtLogs
            // 
            txtLogs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtLogs.BackColor = Color.FromArgb(30, 30, 30);
            txtLogs.Font = new Font("Consolas", 9F);
            txtLogs.ForeColor = Color.White;
            txtLogs.Location = new Point(20, 1246);
            txtLogs.Multiline = true;
            txtLogs.Name = "txtLogs";
            txtLogs.ReadOnly = true;
            txtLogs.ScrollBars = ScrollBars.Vertical;
            txtLogs.Size = new Size(2468, 40);
            txtLogs.TabIndex = 9;
            // 
            // btnDumpSelected
            // 
            btnDumpSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDumpSelected.BorderRadius = 5;
            btnDumpSelected.CustomizableEdges = customizableEdges13;
            btnDumpSelected.DisabledState.BorderColor = Color.DarkGray;
            btnDumpSelected.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDumpSelected.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDumpSelected.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDumpSelected.FillColor = Color.FromArgb(0, 100, 192);
            btnDumpSelected.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDumpSelected.ForeColor = Color.White;
            btnDumpSelected.Location = new Point(2498, 1046);
            btnDumpSelected.Name = "btnDumpSelected";
            btnDumpSelected.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnDumpSelected.Size = new Size(150, 40);
            btnDumpSelected.TabIndex = 10;
            btnDumpSelected.Text = "Dump Selected";
            // 
            // btnDumpAll
            // 
            btnDumpAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDumpAll.BorderRadius = 5;
            btnDumpAll.CustomizableEdges = customizableEdges15;
            btnDumpAll.DisabledState.BorderColor = Color.DarkGray;
            btnDumpAll.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDumpAll.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDumpAll.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDumpAll.FillColor = Color.Purple;
            btnDumpAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDumpAll.ForeColor = Color.White;
            btnDumpAll.Location = new Point(2498, 1096);
            btnDumpAll.Name = "btnDumpAll";
            btnDumpAll.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnDumpAll.Size = new Size(150, 40);
            btnDumpAll.TabIndex = 11;
            btnDumpAll.Text = "Dump All";
            // 
            // nudThreads
            // 
            nudThreads.BackColor = Color.FromArgb(40, 40, 40);
            nudThreads.ForeColor = Color.White;
            nudThreads.Location = new Point(990, 140);
            nudThreads.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudThreads.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudThreads.Name = "nudThreads";
            nudThreads.Size = new Size(100, 39);
            nudThreads.TabIndex = 14;
            nudThreads.Value = new decimal(new int[] { 3, 0, 0, 0 });
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
            // splitContainer
            // 
            splitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer.Location = new Point(20, 130);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(treeDatabase);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(txtData);
            splitContainer.Size = new Size(2668, 1046);
            splitContainer.SplitterDistance = 1067;
            splitContainer.TabIndex = 13;
            // 
            // DumperPage
            // 
            BackColor = Color.Transparent;
            Controls.Add(splitContainer);
            Controls.Add(lblThreads);
            Controls.Add(nudThreads);
            Controls.Add(btnDumpAll);
            Controls.Add(btnDumpSelected);
            Controls.Add(txtLogs);
            Controls.Add(lblStatus);
            Controls.Add(progressBar);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(txtUrl);
            Name = "DumperPage";
            Size = new Size(2868, 1296);
            ((System.ComponentModel.ISupportInitialize)nudThreads).EndInit();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}