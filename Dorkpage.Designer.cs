#nullable disable  // Disable nullable warnings for this file

using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Bunifu.UI.WinForms;

namespace BoomSQL
{
    public partial class DorkPage : BasePage
    {
        private Guna2TextBox txtDorkInput;
        private Guna2CheckBox chkGoogle, chkBing, chkYahoo, chkDuckDuckGo, chkAOL, chkAsk, chkStartpage, chkDogpile;
        private Guna2ToggleSwitch toggleProxy;
        private Guna2Button btnStart, btnStop, btnSendToTester, btnLoadDorks, btnSaveResult;
        private ListBox lstResults;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripProgressBar toolStripProgressBar1;
        private BunifuGroupBox bunifuGroupBox1;
        private Guna2HtmlLabel lblProxy;
        private Guna2HtmlLabel lblTitle;
        private Guna2Panel pnlResults;
        private Guna2Separator separator1;
        private Guna2Panel panelActions;



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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtDorkInput = new Guna2TextBox();
            chkGoogle = new Guna2CheckBox();
            chkBing = new Guna2CheckBox();
            chkYahoo = new Guna2CheckBox();
            chkDuckDuckGo = new Guna2CheckBox();
            chkAOL = new Guna2CheckBox();
            chkAsk = new Guna2CheckBox();
            chkStartpage = new Guna2CheckBox();
            chkDogpile = new Guna2CheckBox();
            toggleProxy = new Guna2ToggleSwitch();
            btnStart = new Guna2Button();
            btnStop = new Guna2Button();
            btnSendToTester = new Guna2Button();
            btnLoadDorks = new Guna2Button();
            lstResults = new ListBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            bunifuGroupBox1 = new BunifuGroupBox();
            guna2CheckBox4 = new Guna2CheckBox();
            guna2CheckBox3 = new Guna2CheckBox();
            guna2CheckBox2 = new Guna2CheckBox();
            guna2CheckBox1 = new Guna2CheckBox();
            lblProxy = new Guna2HtmlLabel();
            lblTitle = new Guna2HtmlLabel();
            pnlResults = new Guna2Panel();
            separator1 = new Guna2Separator();
            panelActions = new Guna2Panel();
            btnSaveResult = new Guna2Button();
            statusStrip1.SuspendLayout();
            bunifuGroupBox1.SuspendLayout();
            pnlResults.SuspendLayout();
            panelActions.SuspendLayout();
            SuspendLayout();
            // 
            // txtDorkInput
            // 
            txtDorkInput.BackColor = Color.FromArgb(30, 30, 30);
            txtDorkInput.BorderColor = Color.Blue;
            txtDorkInput.BorderRadius = 5;
            txtDorkInput.Cursor = Cursors.IBeam;
            txtDorkInput.CustomizableEdges = customizableEdges1;
            txtDorkInput.DefaultText = "";
            txtDorkInput.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtDorkInput.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtDorkInput.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtDorkInput.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtDorkInput.FillColor = Color.FromArgb(40, 40, 40);
            txtDorkInput.FocusedState.BorderColor = Color.Aqua;
            txtDorkInput.Font = new Font("Segoe UI", 10F);
            txtDorkInput.ForeColor = Color.White;
            txtDorkInput.HoverState.BorderColor = Color.Silver;
            txtDorkInput.Location = new Point(0, 80);
            txtDorkInput.Margin = new Padding(6, 6, 6, 6);
            txtDorkInput.Multiline = true;
            txtDorkInput.Name = "txtDorkInput";
            txtDorkInput.PlaceholderForeColor = Color.Gray;
            txtDorkInput.PlaceholderText = "Enter one dork per line\nExample: inurl:admin.php\nfiletype:sql\nsite:example.com";
            txtDorkInput.SelectedText = "";
            txtDorkInput.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtDorkInput.Size = new Size(814, 331);
            txtDorkInput.TabIndex = 0;
            // 
            // chkGoogle
            // 
            chkGoogle.AutoSize = true;
            chkGoogle.Checked = true;
            chkGoogle.CheckedState.BorderColor = Color.Aqua;
            chkGoogle.CheckedState.BorderRadius = 0;
            chkGoogle.CheckedState.BorderThickness = 0;
            chkGoogle.CheckedState.FillColor = Color.Aqua;
            chkGoogle.CheckState = CheckState.Checked;
            chkGoogle.Font = new Font("Segoe UI", 9F);
            chkGoogle.ForeColor = Color.White;
            chkGoogle.Location = new Point(15, 35);
            chkGoogle.Name = "chkGoogle";
            chkGoogle.Size = new Size(123, 36);
            chkGoogle.TabIndex = 2;
            chkGoogle.Text = "Google";
            chkGoogle.UncheckedState.BorderRadius = 0;
            chkGoogle.UncheckedState.BorderThickness = 0;
            // 
            // chkBing
            // 
            chkBing.AutoSize = true;
            chkBing.Checked = true;
            chkBing.CheckedState.BorderColor = Color.Aqua;
            chkBing.CheckedState.BorderRadius = 0;
            chkBing.CheckedState.BorderThickness = 0;
            chkBing.CheckedState.FillColor = Color.Aqua;
            chkBing.CheckState = CheckState.Checked;
            chkBing.Font = new Font("Segoe UI", 9F);
            chkBing.ForeColor = Color.White;
            chkBing.Location = new Point(15, 80);
            chkBing.Name = "chkBing";
            chkBing.Size = new Size(94, 36);
            chkBing.TabIndex = 3;
            chkBing.Text = "Bing";
            chkBing.UncheckedState.BorderRadius = 0;
            chkBing.UncheckedState.BorderThickness = 0;
            // 
            // chkYahoo
            // 
            chkYahoo.AutoSize = true;
            chkYahoo.Checked = true;
            chkYahoo.CheckedState.BorderColor = Color.Aqua;
            chkYahoo.CheckedState.BorderRadius = 0;
            chkYahoo.CheckedState.BorderThickness = 0;
            chkYahoo.CheckedState.FillColor = Color.Aqua;
            chkYahoo.CheckState = CheckState.Checked;
            chkYahoo.Font = new Font("Segoe UI", 9F);
            chkYahoo.ForeColor = Color.White;
            chkYahoo.Location = new Point(15, 125);
            chkYahoo.Name = "chkYahoo";
            chkYahoo.Size = new Size(111, 36);
            chkYahoo.TabIndex = 4;
            chkYahoo.Text = "Yahoo";
            chkYahoo.UncheckedState.BorderRadius = 0;
            chkYahoo.UncheckedState.BorderThickness = 0;
            // 
            // chkDuckDuckGo
            // 
            chkDuckDuckGo.AutoSize = true;
            chkDuckDuckGo.Checked = true;
            chkDuckDuckGo.CheckedState.BorderColor = Color.Aqua;
            chkDuckDuckGo.CheckedState.BorderRadius = 0;
            chkDuckDuckGo.CheckedState.BorderThickness = 0;
            chkDuckDuckGo.CheckedState.FillColor = Color.Aqua;
            chkDuckDuckGo.CheckState = CheckState.Checked;
            chkDuckDuckGo.Font = new Font("Segoe UI", 9F);
            chkDuckDuckGo.ForeColor = Color.White;
            chkDuckDuckGo.Location = new Point(15, 170);
            chkDuckDuckGo.Name = "chkDuckDuckGo";
            chkDuckDuckGo.Size = new Size(184, 36);
            chkDuckDuckGo.TabIndex = 5;
            chkDuckDuckGo.Text = "DuckDuckGo";
            chkDuckDuckGo.UncheckedState.BorderRadius = 0;
            chkDuckDuckGo.UncheckedState.BorderThickness = 0;
            // 
            // chkAOL
            // 
            chkAOL.AutoSize = true;
            chkAOL.Checked = true;
            chkAOL.CheckedState.BorderColor = Color.Aqua;
            chkAOL.CheckedState.BorderRadius = 0;
            chkAOL.CheckedState.BorderThickness = 0;
            chkAOL.CheckedState.FillColor = Color.Aqua;
            chkAOL.CheckState = CheckState.Checked;
            chkAOL.Font = new Font("Segoe UI", 9F);
            chkAOL.ForeColor = Color.White;
            chkAOL.Location = new Point(15, 215);
            chkAOL.Name = "chkAOL";
            chkAOL.Size = new Size(90, 36);
            chkAOL.TabIndex = 15;
            chkAOL.Text = "AOL";
            chkAOL.UncheckedState.BorderRadius = 0;
            chkAOL.UncheckedState.BorderThickness = 0;
            // 
            // chkAsk
            // 
            chkAsk.AutoSize = true;
            chkAsk.Checked = true;
            chkAsk.CheckedState.BorderColor = Color.Aqua;
            chkAsk.CheckedState.BorderRadius = 0;
            chkAsk.CheckedState.BorderThickness = 0;
            chkAsk.CheckedState.FillColor = Color.Aqua;
            chkAsk.CheckState = CheckState.Checked;
            chkAsk.Font = new Font("Segoe UI", 9F);
            chkAsk.ForeColor = Color.White;
            chkAsk.Location = new Point(15, 260);
            chkAsk.Name = "chkAsk";
            chkAsk.Size = new Size(83, 36);
            chkAsk.TabIndex = 16;
            chkAsk.Text = "Ask";
            chkAsk.UncheckedState.BorderRadius = 0;
            chkAsk.UncheckedState.BorderThickness = 0;
            // 
            // chkStartpage
            // 
            chkStartpage.AutoSize = true;
            chkStartpage.Checked = true;
            chkStartpage.CheckedState.BorderColor = Color.Aqua;
            chkStartpage.CheckedState.BorderRadius = 0;
            chkStartpage.CheckedState.BorderThickness = 0;
            chkStartpage.CheckedState.FillColor = Color.Aqua;
            chkStartpage.CheckState = CheckState.Checked;
            chkStartpage.Font = new Font("Segoe UI", 9F);
            chkStartpage.ForeColor = Color.White;
            chkStartpage.Location = new Point(15, 305);
            chkStartpage.Name = "chkStartpage";
            chkStartpage.Size = new Size(147, 36);
            chkStartpage.TabIndex = 17;
            chkStartpage.Text = "Startpage";
            chkStartpage.UncheckedState.BorderRadius = 0;
            chkStartpage.UncheckedState.BorderThickness = 0;
            // 
            // chkDogpile
            // 
            chkDogpile.AutoSize = true;
            chkDogpile.Checked = true;
            chkDogpile.CheckedState.BorderColor = Color.Aqua;
            chkDogpile.CheckedState.BorderRadius = 0;
            chkDogpile.CheckedState.BorderThickness = 0;
            chkDogpile.CheckedState.FillColor = Color.Aqua;
            chkDogpile.CheckState = CheckState.Checked;
            chkDogpile.Font = new Font("Segoe UI", 9F);
            chkDogpile.ForeColor = Color.White;
            chkDogpile.Location = new Point(15, 350);
            chkDogpile.Name = "chkDogpile";
            chkDogpile.Size = new Size(130, 36);
            chkDogpile.TabIndex = 18;
            chkDogpile.Text = "Dogpile";
            chkDogpile.UncheckedState.BorderRadius = 0;
            chkDogpile.UncheckedState.BorderThickness = 0;
            // 
            // toggleProxy
            // 
            toggleProxy.Checked = true;
            toggleProxy.CheckedState.BorderColor = Color.Aqua;
            toggleProxy.CheckedState.FillColor = Color.Aqua;
            toggleProxy.CheckedState.InnerBorderColor = Color.Black;
            toggleProxy.CheckedState.InnerColor = Color.Black;
            toggleProxy.CustomizableEdges = customizableEdges3;
            toggleProxy.Location = new Point(677, 436);
            toggleProxy.Name = "toggleProxy";
            toggleProxy.ShadowDecoration.CustomizableEdges = customizableEdges4;
            toggleProxy.Size = new Size(50, 25);
            toggleProxy.TabIndex = 1;
            toggleProxy.UncheckedState.BorderColor = Color.Gray;
            toggleProxy.UncheckedState.FillColor = Color.DarkGray;
            toggleProxy.UncheckedState.InnerBorderColor = Color.Black;
            toggleProxy.UncheckedState.InnerColor = Color.Black;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Transparent;
            btnStart.BorderRadius = 5;
            btnStart.CustomizableEdges = customizableEdges5;
            btnStart.DisabledState.BorderColor = Color.DarkGray;
            btnStart.DisabledState.CustomBorderColor = Color.DarkGray;
            btnStart.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnStart.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnStart.FillColor = Color.Green;
            btnStart.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(0, 10);
            btnStart.Name = "btnStart";
            btnStart.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnStart.Size = new Size(180, 40);
            btnStart.TabIndex = 5;
            btnStart.Text = "Start Search";
            btnStart.Click += btnStart_Click_1;
            // 
            // btnStop
            // 
            btnStop.BorderRadius = 5;
            btnStop.CustomizableEdges = customizableEdges7;
            btnStop.DisabledState.BorderColor = Color.DarkGray;
            btnStop.DisabledState.CustomBorderColor = Color.DarkGray;
            btnStop.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnStop.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnStop.FillColor = Color.FromArgb(192, 0, 0);
            btnStop.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(301, 10);
            btnStop.Name = "btnStop";
            btnStop.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnStop.Size = new Size(180, 40);
            btnStop.TabIndex = 6;
            btnStop.Text = "Stop";
            // 
            // btnSendToTester
            // 
            btnSendToTester.BorderRadius = 5;
            btnSendToTester.CustomizableEdges = customizableEdges9;
            btnSendToTester.DisabledState.BorderColor = Color.DarkGray;
            btnSendToTester.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSendToTester.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSendToTester.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSendToTester.FillColor = Color.FromArgb(0, 100, 192);
            btnSendToTester.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSendToTester.ForeColor = Color.White;
            btnSendToTester.Location = new Point(603, 10);
            btnSendToTester.Name = "btnSendToTester";
            btnSendToTester.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnSendToTester.Size = new Size(220, 40);
            btnSendToTester.TabIndex = 20;
            btnSendToTester.Text = "Send to Tester";
            // 
            // btnLoadDorks
            // 
            btnLoadDorks.BorderRadius = 5;
            btnLoadDorks.CustomizableEdges = customizableEdges11;
            btnLoadDorks.DisabledState.BorderColor = Color.DarkGray;
            btnLoadDorks.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLoadDorks.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLoadDorks.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLoadDorks.FillColor = Color.FromArgb(70, 70, 70);
            btnLoadDorks.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLoadDorks.ForeColor = Color.Silver;
            btnLoadDorks.Location = new Point(0, 421);
            btnLoadDorks.Name = "btnLoadDorks";
            btnLoadDorks.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnLoadDorks.Size = new Size(180, 40);
            btnLoadDorks.TabIndex = 14;
            btnLoadDorks.Text = "Load Dorks from File";
            // 
            // lstResults
            // 
            lstResults.BackColor = Color.FromArgb(40, 40, 40);
            lstResults.BorderStyle = BorderStyle.None;
            lstResults.Dock = DockStyle.Fill;
            lstResults.Font = new Font("Consolas", 10F);
            lstResults.ForeColor = Color.White;
            lstResults.FormattingEnabled = true;
            lstResults.Location = new Point(0, 0);
            lstResults.Name = "lstResults";
            lstResults.Size = new Size(2534, 507);
            lstResults.TabIndex = 7;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(30, 30, 30);
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 1224);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(2534, 42);
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.BackColor = Color.Transparent;
            toolStripStatusLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            toolStripStatusLabel1.ForeColor = Color.Aqua;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(337, 32);
            toolStripStatusLabel1.Text = "Status: Ready | Progress: 0%";
            toolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.BackColor = Color.Black;
            toolStripProgressBar1.ForeColor = Color.LawnGreen;
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.RightToLeft = RightToLeft.No;
            toolStripProgressBar1.Size = new Size(300, 30);
            toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            // 
            // bunifuGroupBox1
            // 
            bunifuGroupBox1.BackColor = Color.FromArgb(30, 30, 30);
            bunifuGroupBox1.BorderColor = Color.Blue;
            bunifuGroupBox1.BorderRadius = 5;
            bunifuGroupBox1.BorderThickness = 1;
            bunifuGroupBox1.Controls.Add(guna2CheckBox4);
            bunifuGroupBox1.Controls.Add(guna2CheckBox3);
            bunifuGroupBox1.Controls.Add(guna2CheckBox2);
            bunifuGroupBox1.Controls.Add(guna2CheckBox1);
            bunifuGroupBox1.Controls.Add(chkGoogle);
            bunifuGroupBox1.Controls.Add(chkBing);
            bunifuGroupBox1.Controls.Add(chkYahoo);
            bunifuGroupBox1.Controls.Add(chkDuckDuckGo);
            bunifuGroupBox1.Controls.Add(chkAOL);
            bunifuGroupBox1.Controls.Add(chkAsk);
            bunifuGroupBox1.Controls.Add(chkStartpage);
            bunifuGroupBox1.Controls.Add(chkDogpile);
            bunifuGroupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            bunifuGroupBox1.ForeColor = Color.Aqua;
            bunifuGroupBox1.LabelAlign = HorizontalAlignment.Left;
            bunifuGroupBox1.LabelIndent = 10;
            bunifuGroupBox1.LineStyle = BunifuGroupBox.LineStyles.Solid;
            bunifuGroupBox1.Location = new Point(835, 64);
            bunifuGroupBox1.Name = "bunifuGroupBox1";
            bunifuGroupBox1.Size = new Size(424, 411);
            bunifuGroupBox1.TabIndex = 10;
            bunifuGroupBox1.TabStop = false;
            bunifuGroupBox1.Text = "Search Engines";
            // 
            // guna2CheckBox4
            // 
            guna2CheckBox4.AutoSize = true;
            guna2CheckBox4.Checked = true;
            guna2CheckBox4.CheckedState.BorderColor = Color.Aqua;
            guna2CheckBox4.CheckedState.BorderRadius = 0;
            guna2CheckBox4.CheckedState.BorderThickness = 0;
            guna2CheckBox4.CheckedState.FillColor = Color.Aqua;
            guna2CheckBox4.CheckState = CheckState.Checked;
            guna2CheckBox4.Font = new Font("Segoe UI", 9F);
            guna2CheckBox4.ForeColor = Color.White;
            guna2CheckBox4.Location = new Point(240, 170);
            guna2CheckBox4.Name = "guna2CheckBox4";
            guna2CheckBox4.Size = new Size(144, 36);
            guna2CheckBox4.TabIndex = 22;
            guna2CheckBox4.Text = "Gigablast";
            guna2CheckBox4.UncheckedState.BorderRadius = 0;
            guna2CheckBox4.UncheckedState.BorderThickness = 0;
            // 
            // guna2CheckBox3
            // 
            guna2CheckBox3.AutoSize = true;
            guna2CheckBox3.Checked = true;
            guna2CheckBox3.CheckedState.BorderColor = Color.Aqua;
            guna2CheckBox3.CheckedState.BorderRadius = 0;
            guna2CheckBox3.CheckedState.BorderThickness = 0;
            guna2CheckBox3.CheckedState.FillColor = Color.Aqua;
            guna2CheckBox3.CheckState = CheckState.Checked;
            guna2CheckBox3.Font = new Font("Segoe UI", 9F);
            guna2CheckBox3.ForeColor = Color.White;
            guna2CheckBox3.Location = new Point(240, 125);
            guna2CheckBox3.Name = "guna2CheckBox3";
            guna2CheckBox3.Size = new Size(138, 36);
            guna2CheckBox3.TabIndex = 21;
            guna2CheckBox3.Text = "MetaGer";
            guna2CheckBox3.UncheckedState.BorderRadius = 0;
            guna2CheckBox3.UncheckedState.BorderThickness = 0;
            // 
            // guna2CheckBox2
            // 
            guna2CheckBox2.AutoSize = true;
            guna2CheckBox2.Checked = true;
            guna2CheckBox2.CheckedState.BorderColor = Color.Aqua;
            guna2CheckBox2.CheckedState.BorderRadius = 0;
            guna2CheckBox2.CheckedState.BorderThickness = 0;
            guna2CheckBox2.CheckedState.FillColor = Color.Aqua;
            guna2CheckBox2.CheckState = CheckState.Checked;
            guna2CheckBox2.Font = new Font("Segoe UI", 9F);
            guna2CheckBox2.ForeColor = Color.White;
            guna2CheckBox2.Location = new Point(240, 80);
            guna2CheckBox2.Name = "guna2CheckBox2";
            guna2CheckBox2.Size = new Size(106, 36);
            guna2CheckBox2.TabIndex = 20;
            guna2CheckBox2.Text = "Baidu";
            guna2CheckBox2.UncheckedState.BorderRadius = 0;
            guna2CheckBox2.UncheckedState.BorderThickness = 0;
            // 
            // guna2CheckBox1
            // 
            guna2CheckBox1.AutoSize = true;
            guna2CheckBox1.Checked = true;
            guna2CheckBox1.CheckedState.BorderColor = Color.Aqua;
            guna2CheckBox1.CheckedState.BorderRadius = 0;
            guna2CheckBox1.CheckedState.BorderThickness = 0;
            guna2CheckBox1.CheckedState.FillColor = Color.Aqua;
            guna2CheckBox1.CheckState = CheckState.Checked;
            guna2CheckBox1.Font = new Font("Segoe UI", 9F);
            guna2CheckBox1.ForeColor = Color.White;
            guna2CheckBox1.Location = new Point(240, 35);
            guna2CheckBox1.Name = "guna2CheckBox1";
            guna2CheckBox1.Size = new Size(121, 36);
            guna2CheckBox1.TabIndex = 19;
            guna2CheckBox1.Text = "Yandex";
            guna2CheckBox1.UncheckedState.BorderRadius = 0;
            guna2CheckBox1.UncheckedState.BorderThickness = 0;
            // 
            // lblProxy
            // 
            lblProxy.BackColor = Color.Transparent;
            lblProxy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProxy.ForeColor = Color.Aqua;
            lblProxy.Location = new Point(494, 422);
            lblProxy.Name = "lblProxy";
            lblProxy.Size = new Size(177, 39);
            lblProxy.TabIndex = 11;
            lblProxy.Text = "Enable Proxy:";
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Aqua;
            lblTitle.Location = new Point(12, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(472, 61);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "DORK SEARCH ENGINE";
            // 
            // pnlResults
            // 
            pnlResults.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlResults.BackColor = Color.Transparent;
            pnlResults.BorderColor = Color.Blue;
            pnlResults.BorderRadius = 5;
            pnlResults.BorderThickness = 1;
            pnlResults.Controls.Add(lstResults);
            pnlResults.CustomizableEdges = customizableEdges13;
            pnlResults.Dock = DockStyle.Bottom;
            pnlResults.ForeColor = Color.YellowGreen;
            pnlResults.Location = new Point(0, 717);
            pnlResults.Name = "pnlResults";
            pnlResults.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlResults.Size = new Size(2534, 507);
            pnlResults.TabIndex = 13;
            // 
            // separator1
            // 
            separator1.BackColor = Color.Blue;
            separator1.FillColor = Color.Gray;
            separator1.Location = new Point(0, 516);
            separator1.Name = "separator1";
            separator1.Size = new Size(1552, 10);
            separator1.TabIndex = 12;
            // 
            // panelActions
            // 
            panelActions.Controls.Add(btnSaveResult);
            panelActions.Controls.Add(btnStart);
            panelActions.Controls.Add(btnStop);
            panelActions.Controls.Add(btnSendToTester);
            panelActions.CustomizableEdges = customizableEdges17;
            panelActions.Location = new Point(0, 571);
            panelActions.Name = "panelActions";
            panelActions.ShadowDecoration.CustomizableEdges = customizableEdges18;
            panelActions.Size = new Size(1213, 60);
            panelActions.TabIndex = 19;
            // 
            // btnSaveResult
            // 
            btnSaveResult.BorderRadius = 5;
            btnSaveResult.CustomizableEdges = customizableEdges15;
            btnSaveResult.DisabledState.BorderColor = Color.DarkGray;
            btnSaveResult.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSaveResult.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSaveResult.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSaveResult.FillColor = Color.SlateBlue;
            btnSaveResult.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSaveResult.ForeColor = Color.White;
            btnSaveResult.Location = new Point(941, 10);
            btnSaveResult.Name = "btnSaveResult";
            btnSaveResult.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnSaveResult.Size = new Size(220, 40);
            btnSaveResult.TabIndex = 21;
            btnSaveResult.Text = "Save Results";
            // 
            // DorkPage
            // 
            AllowDrop = true;
            BackColor = Color.Transparent;
            Controls.Add(bunifuGroupBox1);
            Controls.Add(pnlResults);
            Controls.Add(separator1);
            Controls.Add(panelActions);
            Controls.Add(btnLoadDorks);
            Controls.Add(lblProxy);
            Controls.Add(toggleProxy);
            Controls.Add(txtDorkInput);
            Controls.Add(lblTitle);
            Controls.Add(statusStrip1);
            Name = "DorkPage";
            Size = new Size(2534, 1266);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            bunifuGroupBox1.ResumeLayout(false);
            bunifuGroupBox1.PerformLayout();
            pnlResults.ResumeLayout(false);
            panelActions.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {
            // Event handler logic
        }
        private Guna2CheckBox guna2CheckBox1;
        private Guna2CheckBox guna2CheckBox4;
        private Guna2CheckBox guna2CheckBox3;
        private Guna2CheckBox guna2CheckBox2;
        // btnSaveResult already declared on line 15
    }
}