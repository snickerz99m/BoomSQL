using Guna.UI2.WinForms;

namespace BoomSQL
{
    partial class SettingsPage
    {
        private System.ComponentModel.IContainer components = null;

        private TabControl tabControl;
        private TabPage tabProxy;
        private TabPage tabThreads;
        private DataGridView dgvProxies;
        private Guna2TextBox txtHost;
        private NumericUpDown nudPort;
        private Guna2TextBox txtUsername;
        private Guna2TextBox txtPassword;
        private Guna2Button btnAddProxy;
        private Guna2Button btnRemoveProxy;
        private Guna2Button btnLoadProxies;
        private Guna2Button btnSaveProxies;
        private Guna2Button btnTestProxies;
        private CheckBox chkRemoveDead;
        private NumericUpDown nudDorkThreads;
        private NumericUpDown nudCrawlerThreads;
        private NumericUpDown nudTesterThreads;
        private NumericUpDown nudDumperThreads;
        private Label lblDorkThreads;
        private Label lblCrawlerThreads;
        private Label lblTesterThreads;
        private Label lblDumperThreads;
        private Guna2Button btnSaveSettings;
        private TextBox txtLogs;

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tabControl = new TabControl();
            tabProxy = new TabPage();
            dgvProxies = new DataGridView();
            txtHost = new Guna2TextBox();
            nudPort = new NumericUpDown();
            txtUsername = new Guna2TextBox();
            txtPassword = new Guna2TextBox();
            btnAddProxy = new Guna2Button();
            btnRemoveProxy = new Guna2Button();
            btnLoadProxies = new Guna2Button();
            btnSaveProxies = new Guna2Button();
            btnTestProxies = new Guna2Button();
            chkRemoveDead = new CheckBox();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            tabThreads = new TabPage();
            nudDorkThreads = new NumericUpDown();
            nudCrawlerThreads = new NumericUpDown();
            nudTesterThreads = new NumericUpDown();
            nudDumperThreads = new NumericUpDown();
            lblDorkThreads = new Label();
            lblCrawlerThreads = new Label();
            lblTesterThreads = new Label();
            lblDumperThreads = new Label();
            btnSaveSettings = new Guna2Button();
            txtLogs = new TextBox();
            tabControl.SuspendLayout();
            tabProxy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProxies).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPort).BeginInit();
            tabThreads.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDorkThreads).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCrawlerThreads).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTesterThreads).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDumperThreads).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabProxy);
            tabControl.Controls.Add(tabThreads);
            tabControl.Location = new Point(20, 20);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(2818, 1196);
            tabControl.TabIndex = 0;
            // 
            // tabProxy
            // 
            tabProxy.Controls.Add(dgvProxies);
            tabProxy.Controls.Add(txtHost);
            tabProxy.Controls.Add(nudPort);
            tabProxy.Controls.Add(txtUsername);
            tabProxy.Controls.Add(txtPassword);
            tabProxy.Controls.Add(btnAddProxy);
            tabProxy.Controls.Add(btnRemoveProxy);
            tabProxy.Controls.Add(btnLoadProxies);
            tabProxy.Controls.Add(btnSaveProxies);
            tabProxy.Controls.Add(btnTestProxies);
            tabProxy.Controls.Add(chkRemoveDead);
            tabProxy.Location = new Point(8, 46);
            tabProxy.Name = "tabProxy";
            tabProxy.Size = new Size(2802, 1142);
            tabProxy.TabIndex = 0;
            tabProxy.Text = "Proxy Settings";
            // 
            // dgvProxies
            // 
            dgvProxies.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProxies.BackgroundColor = Color.FromArgb(40, 40, 40);
            dgvProxies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProxies.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvProxies.Location = new Point(20, 20);
            dgvProxies.Name = "dgvProxies";
            dgvProxies.RowHeadersWidth = 82;
            dgvProxies.Size = new Size(3402, 1442);
            dgvProxies.TabIndex = 0;
            // 
            // txtHost
            // 
            txtHost.CustomizableEdges = customizableEdges1;
            txtHost.DefaultText = "";
            txtHost.Font = new Font("Segoe UI", 9F);
            txtHost.Location = new Point(20, 440);
            txtHost.Margin = new Padding(6, 6, 6, 6);
            txtHost.Name = "txtHost";
            txtHost.PlaceholderText = "Host/IP";
            txtHost.SelectedText = "";
            txtHost.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtHost.Size = new Size(150, 30);
            txtHost.TabIndex = 1;
            // 
            // nudPort
            // 
            nudPort.Location = new Point(180, 440);
            nudPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudPort.Name = "nudPort";
            nudPort.Size = new Size(80, 39);
            nudPort.TabIndex = 2;
            nudPort.Value = new decimal(new int[] { 8080, 0, 0, 0 });
            // 
            // txtUsername
            // 
            txtUsername.CustomizableEdges = customizableEdges3;
            txtUsername.DefaultText = "";
            txtUsername.Font = new Font("Segoe UI", 9F);
            txtUsername.Location = new Point(270, 440);
            txtUsername.Margin = new Padding(6, 6, 6, 6);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.SelectedText = "";
            txtUsername.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtUsername.Size = new Size(150, 30);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.CustomizableEdges = customizableEdges5;
            txtPassword.DefaultText = "";
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.Location = new Point(430, 440);
            txtPassword.Margin = new Padding(6, 6, 6, 6);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtPassword.Size = new Size(150, 30);
            txtPassword.TabIndex = 4;
            // 
            // btnAddProxy
            // 
            btnAddProxy.CustomizableEdges = customizableEdges7;
            btnAddProxy.Font = new Font("Segoe UI", 9F);
            btnAddProxy.ForeColor = Color.White;
            btnAddProxy.Location = new Point(590, 440);
            btnAddProxy.Name = "btnAddProxy";
            btnAddProxy.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnAddProxy.Size = new Size(100, 30);
            btnAddProxy.TabIndex = 5;
            btnAddProxy.Text = "Add";
            // 
            // btnRemoveProxy
            // 
            btnRemoveProxy.CustomizableEdges = customizableEdges9;
            btnRemoveProxy.Font = new Font("Segoe UI", 9F);
            btnRemoveProxy.ForeColor = Color.White;
            btnRemoveProxy.Location = new Point(700, 440);
            btnRemoveProxy.Name = "btnRemoveProxy";
            btnRemoveProxy.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnRemoveProxy.Size = new Size(100, 30);
            btnRemoveProxy.TabIndex = 6;
            btnRemoveProxy.Text = "Remove";
            // 
            // btnLoadProxies
            // 
            btnLoadProxies.CustomizableEdges = customizableEdges11;
            btnLoadProxies.Font = new Font("Segoe UI", 9F);
            btnLoadProxies.ForeColor = Color.White;
            btnLoadProxies.Location = new Point(20, 480);
            btnLoadProxies.Name = "btnLoadProxies";
            btnLoadProxies.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnLoadProxies.Size = new Size(150, 40);
            btnLoadProxies.TabIndex = 7;
            btnLoadProxies.Text = "Load Proxies";
            // 
            // btnSaveProxies
            // 
            btnSaveProxies.CustomizableEdges = customizableEdges13;
            btnSaveProxies.Font = new Font("Segoe UI", 9F);
            btnSaveProxies.ForeColor = Color.White;
            btnSaveProxies.Location = new Point(180, 480);
            btnSaveProxies.Name = "btnSaveProxies";
            btnSaveProxies.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnSaveProxies.Size = new Size(150, 40);
            btnSaveProxies.TabIndex = 8;
            btnSaveProxies.Text = "Save Proxies";
            // 
            // btnTestProxies
            // 
            btnTestProxies.CustomizableEdges = customizableEdges15;
            btnTestProxies.Font = new Font("Segoe UI", 9F);
            btnTestProxies.ForeColor = Color.White;
            btnTestProxies.Location = new Point(340, 480);
            btnTestProxies.Name = "btnTestProxies";
            btnTestProxies.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnTestProxies.Size = new Size(150, 40);
            btnTestProxies.TabIndex = 9;
            btnTestProxies.Text = "Test Proxies";
            // 
            // chkRemoveDead
            // 
            chkRemoveDead.AutoSize = true;
            chkRemoveDead.ForeColor = Color.White;
            chkRemoveDead.Location = new Point(500, 490);
            chkRemoveDead.Name = "chkRemoveDead";
            chkRemoveDead.Size = new Size(377, 36);
            chkRemoveDead.TabIndex = 10;
            chkRemoveDead.Text = "Remove dead proxies after test";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Host";
            dataGridViewTextBoxColumn1.MinimumWidth = 10;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Port";
            dataGridViewTextBoxColumn2.MinimumWidth = 10;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Username";
            dataGridViewTextBoxColumn3.MinimumWidth = 10;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Password";
            dataGridViewTextBoxColumn4.MinimumWidth = 10;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Status";
            dataGridViewTextBoxColumn5.MinimumWidth = 10;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 200;
            // 
            // tabThreads
            // 
            tabThreads.Controls.Add(nudDorkThreads);
            tabThreads.Controls.Add(nudCrawlerThreads);
            tabThreads.Controls.Add(nudTesterThreads);
            tabThreads.Controls.Add(nudDumperThreads);
            tabThreads.Controls.Add(lblDorkThreads);
            tabThreads.Controls.Add(lblCrawlerThreads);
            tabThreads.Controls.Add(lblTesterThreads);
            tabThreads.Controls.Add(lblDumperThreads);
            tabThreads.Location = new Point(8, 46);
            tabThreads.Name = "tabThreads";
            tabThreads.Size = new Size(2802, 1142);
            tabThreads.TabIndex = 1;
            tabThreads.Text = "Thread Settings";
            // 
            // nudDorkThreads
            // 
            nudDorkThreads.Location = new Point(250, 50);
            nudDorkThreads.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudDorkThreads.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDorkThreads.Name = "nudDorkThreads";
            nudDorkThreads.Size = new Size(100, 39);
            nudDorkThreads.TabIndex = 0;
            nudDorkThreads.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // nudCrawlerThreads
            // 
            nudCrawlerThreads.Location = new Point(250, 100);
            nudCrawlerThreads.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nudCrawlerThreads.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCrawlerThreads.Name = "nudCrawlerThreads";
            nudCrawlerThreads.Size = new Size(100, 39);
            nudCrawlerThreads.TabIndex = 1;
            nudCrawlerThreads.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // nudTesterThreads
            // 
            nudTesterThreads.Location = new Point(250, 150);
            nudTesterThreads.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nudTesterThreads.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudTesterThreads.Name = "nudTesterThreads";
            nudTesterThreads.Size = new Size(100, 39);
            nudTesterThreads.TabIndex = 2;
            nudTesterThreads.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // nudDumperThreads
            // 
            nudDumperThreads.Location = new Point(250, 200);
            nudDumperThreads.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudDumperThreads.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDumperThreads.Name = "nudDumperThreads";
            nudDumperThreads.Size = new Size(100, 39);
            nudDumperThreads.TabIndex = 3;
            nudDumperThreads.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // lblDorkThreads
            // 
            lblDorkThreads.AutoSize = true;
            lblDorkThreads.ForeColor = Color.White;
            lblDorkThreads.Location = new Point(50, 55);
            lblDorkThreads.Name = "lblDorkThreads";
            lblDorkThreads.Size = new Size(239, 32);
            lblDorkThreads.TabIndex = 4;
            lblDorkThreads.Text = "Dork Search Threads:";
            // 
            // lblCrawlerThreads
            // 
            lblCrawlerThreads.AutoSize = true;
            lblCrawlerThreads.ForeColor = Color.White;
            lblCrawlerThreads.Location = new Point(50, 105);
            lblCrawlerThreads.Name = "lblCrawlerThreads";
            lblCrawlerThreads.Size = new Size(189, 32);
            lblCrawlerThreads.TabIndex = 5;
            lblCrawlerThreads.Text = "Crawler Threads:";
            // 
            // lblTesterThreads
            // 
            lblTesterThreads.AutoSize = true;
            lblTesterThreads.ForeColor = Color.White;
            lblTesterThreads.Location = new Point(50, 155);
            lblTesterThreads.Name = "lblTesterThreads";
            lblTesterThreads.Size = new Size(222, 32);
            lblTesterThreads.TabIndex = 6;
            lblTesterThreads.Text = "SQL Tester Threads:";
            // 
            // lblDumperThreads
            // 
            lblDumperThreads.AutoSize = true;
            lblDumperThreads.ForeColor = Color.White;
            lblDumperThreads.Location = new Point(50, 205);
            lblDumperThreads.Name = "lblDumperThreads";
            lblDumperThreads.Size = new Size(197, 32);
            lblDumperThreads.TabIndex = 7;
            lblDumperThreads.Text = "Dumper Threads:";
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveSettings.CustomizableEdges = customizableEdges17;
            btnSaveSettings.Font = new Font("Segoe UI", 9F);
            btnSaveSettings.ForeColor = Color.White;
            btnSaveSettings.Location = new Point(2718, 1226);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnSaveSettings.Size = new Size(150, 40);
            btnSaveSettings.TabIndex = 1;
            btnSaveSettings.Text = "Save All Settings";
            // 
            // txtLogs
            // 
            txtLogs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtLogs.BackColor = Color.FromArgb(30, 30, 30);
            txtLogs.Font = new Font("Consolas", 9F);
            txtLogs.ForeColor = Color.White;
            txtLogs.Location = new Point(20, 1226);
            txtLogs.Multiline = true;
            txtLogs.Name = "txtLogs";
            txtLogs.ReadOnly = true;
            txtLogs.ScrollBars = ScrollBars.Vertical;
            txtLogs.Size = new Size(2688, 40);
            txtLogs.TabIndex = 1;
            // 
            // SettingsPage
            // 
            BackColor = Color.Transparent;
            Controls.Add(tabControl);
            Controls.Add(btnSaveSettings);
            Controls.Add(txtLogs);
            Name = "SettingsPage";
            Size = new Size(2868, 1296);
            tabControl.ResumeLayout(false);
            tabProxy.ResumeLayout(false);
            tabProxy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProxies).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPort).EndInit();
            tabThreads.ResumeLayout(false);
            tabThreads.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDorkThreads).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCrawlerThreads).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTesterThreads).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDumperThreads).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}