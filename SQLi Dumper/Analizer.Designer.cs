// Token: 0x02000069 RID: 105
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class Analizer : global::System.Windows.Forms.Form
{
	// Token: 0x0600031F RID: 799 RVA: 0x0001729C File Offset: 0x0001549C
	[global::System.Diagnostics.DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	// Token: 0x06000320 RID: 800 RVA: 0x000172E0 File Offset: 0x000154E0
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Analizer));
		this.tslMain_1 = new global::System.Windows.Forms.ToolStrip();
		this.btnPasteURL = new global::System.Windows.Forms.ToolStripButton();
		this.cmbUnionPosition = new global::System.Windows.Forms.ToolStripComboBox();
		this.ToolStripSeparator3 = new global::System.Windows.Forms.ToolStripSeparator();
		this.tslMain_4 = new global::System.Windows.Forms.ToolStrip();
		this.txtUnionStyle = new global::System.Windows.Forms.ToolStripComboBox();
		this.ToolStripSeparator7 = new global::System.Windows.Forms.ToolStripSeparator();
		this.btnGoToDumper = new global::System.Windows.Forms.ToolStripButton();
		this.btnGoToDumperSP = new global::System.Windows.Forms.ToolStripSeparator();
		this.cmbUnionStyle = new global::System.Windows.Forms.ToolStripComboBox();
		this.btnNext = new global::System.Windows.Forms.ToolStripButton();
		this.btnBackward = new global::System.Windows.Forms.ToolStripButton();
		this.tslMain_3 = new global::System.Windows.Forms.ToolStrip();
		this.ToolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
		this.ToolStripSeparator5 = new global::System.Windows.Forms.ToolStripSeparator();
		this.ToolStripSeparator9 = new global::System.Windows.Forms.ToolStripSeparator();
		this.mnuCount = new global::System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.ToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.tbcMain = new global::UxTabControl();
		this.tpWB = new global::System.Windows.Forms.TabPage();
		this.wbBrowser = new global::System.Windows.Forms.WebBrowser();
		this.tpSource = new global::System.Windows.Forms.TabPage();
		this.txtSourceCode = new global::System.Windows.Forms.TextBox();
		this.tpRaw = new global::System.Windows.Forms.TabPage();
		this.txtRaw = new global::System.Windows.Forms.TextBox();
		this.tpSetup = new global::System.Windows.Forms.TabPage();
		this.grbSetup = new global::System.Windows.Forms.GroupBox();
		this.chkBypassProxy = new global::System.Windows.Forms.CheckBox();
		this.grbLogin = new global::System.Windows.Forms.GroupBox();
		this.txtUserName = new global::System.Windows.Forms.TextBox();
		this.txtPassword = new global::System.Windows.Forms.TextBox();
		this.lblUser = new global::System.Windows.Forms.Label();
		this.lblPassword = new global::System.Windows.Forms.Label();
		this.ImageList1 = new global::System.Windows.Forms.ImageList(this.icontainer_0);
		this.stsMain = new global::System.Windows.Forms.StatusStrip();
		this.lblStatus = new global::System.Windows.Forms.ToolStripStatusLabel();
		this.prbStatus = new global::System.Windows.Forms.ToolStripProgressBar();
		this.bckWorker = new global::System.ComponentModel.BackgroundWorker();
		this.tslMain_2 = new global::System.Windows.Forms.ToolStrip();
		this.btnWorker = new global::System.Windows.Forms.ToolStripButton();
		this.btnClearForm = new global::System.Windows.Forms.ToolStripButton();
		this.tsSp1 = new global::System.Windows.Forms.ToolStripSeparator();
		this.lblHttpStatus = new global::System.Windows.Forms.ToolStripLabel();
		this.tsSp2 = new global::System.Windows.Forms.ToolStripSeparator();
		this.lblIP = new global::System.Windows.Forms.ToolStripLabel();
		this.tsSp3 = new global::System.Windows.Forms.ToolStripSeparator();
		this.lblCountry = new global::System.Windows.Forms.ToolStripLabel();
		this.tsSp5 = new global::System.Windows.Forms.ToolStripSeparator();
		this.tsSp4 = new global::System.Windows.Forms.ToolStripLabel();
		this.ToolStripSeparator6 = new global::System.Windows.Forms.ToolStripSeparator();
		this.chkWafs = new global::System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
		this.chkIE = new global::System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator4 = new global::System.Windows.Forms.ToolStripSeparator();
		this.chkFlowRedirects = new global::System.Windows.Forms.ToolStripButton();
		this.tslMain_1.SuspendLayout();
		this.tslMain_4.SuspendLayout();
		this.tslMain_3.SuspendLayout();
		this.mnuCount.SuspendLayout();
		this.tbcMain.SuspendLayout();
		this.tpWB.SuspendLayout();
		this.tpSource.SuspendLayout();
		this.tpRaw.SuspendLayout();
		this.tpSetup.SuspendLayout();
		this.grbSetup.SuspendLayout();
		this.grbLogin.SuspendLayout();
		this.stsMain.SuspendLayout();
		this.tslMain_2.SuspendLayout();
		base.SuspendLayout();
		this.tslMain_1.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.tslMain_1.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.tslMain_1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.btnPasteURL,
			this.cmbUnionPosition,
			this.ToolStripSeparator3
		});
		this.tslMain_1.Location = new global::System.Drawing.Point(0, 0);
		this.tslMain_1.Name = "tslMain_1";
		this.tslMain_1.Padding = new global::System.Windows.Forms.Padding(0, 0, 4, 0);
		this.tslMain_1.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.System;
		this.tslMain_1.Size = new global::System.Drawing.Size(994, 33);
		this.tslMain_1.Stretch = true;
		this.tslMain_1.TabIndex = 21;
		this.tslMain_1.Text = "ToolStrip2";
		this.btnPasteURL.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnPasteURL.Image = global::ns0.Class6.URLInputBox_16x_24;
		this.btnPasteURL.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnPasteURL.Name = "btnPasteURL";
		this.btnPasteURL.Size = new global::System.Drawing.Size(28, 30);
		this.btnPasteURL.Text = "Paste URL";
		this.cmbUnionPosition.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.cmbUnionPosition.AutoSize = false;
		this.cmbUnionPosition.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbUnionPosition.Name = "cmbUnionPosition";
		this.cmbUnionPosition.Size = new global::System.Drawing.Size(60, 33);
		this.ToolStripSeparator3.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.ToolStripSeparator3.Name = "ToolStripSeparator3";
		this.ToolStripSeparator3.Size = new global::System.Drawing.Size(6, 33);
		this.tslMain_4.AutoSize = false;
		this.tslMain_4.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.tslMain_4.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.tslMain_4.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.txtUnionStyle,
			this.ToolStripSeparator7,
			this.btnGoToDumper,
			this.btnGoToDumperSP
		});
		this.tslMain_4.Location = new global::System.Drawing.Point(0, 97);
		this.tslMain_4.Name = "tslMain_4";
		this.tslMain_4.Padding = new global::System.Windows.Forms.Padding(0, 0, 4, 0);
		this.tslMain_4.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.System;
		this.tslMain_4.Size = new global::System.Drawing.Size(994, 32);
		this.tslMain_4.Stretch = true;
		this.tslMain_4.TabIndex = 23;
		this.tslMain_4.Text = "ToolStrip2";
		this.txtUnionStyle.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.Simple;
		this.txtUnionStyle.Name = "txtUnionStyle";
		this.txtUnionStyle.Size = new global::System.Drawing.Size(160, 32);
		this.txtUnionStyle.Text = "~SQLI:[t]~";
		this.ToolStripSeparator7.Name = "ToolStripSeparator7";
		this.ToolStripSeparator7.Size = new global::System.Drawing.Size(6, 32);
		this.btnGoToDumper.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.btnGoToDumper.Checked = true;
		this.btnGoToDumper.CheckOnClick = true;
		this.btnGoToDumper.CheckState = global::System.Windows.Forms.CheckState.Checked;
		this.btnGoToDumper.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnGoToDumper.Enabled = false;
		this.btnGoToDumper.Image = global::ns0.Class6.UpdatePanel_16x_24;
		this.btnGoToDumper.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnGoToDumper.Name = "btnGoToDumper";
		this.btnGoToDumper.Size = new global::System.Drawing.Size(28, 29);
		this.btnGoToDumper.Text = "Go To Dumper";
		this.btnGoToDumperSP.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.btnGoToDumperSP.Name = "btnGoToDumperSP";
		this.btnGoToDumperSP.Size = new global::System.Drawing.Size(6, 32);
		this.cmbUnionStyle.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbUnionStyle.Name = "cmbUnionStyle";
		this.cmbUnionStyle.Size = new global::System.Drawing.Size(160, 32);
		this.btnNext.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.btnNext.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnNext.Enabled = false;
		this.btnNext.Image = global::ns0.Class6.NextFrameArrow_16x;
		this.btnNext.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnNext.Name = "btnNext";
		this.btnNext.Size = new global::System.Drawing.Size(28, 29);
		this.btnNext.Text = "Next [F8]";
		this.btnBackward.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.btnBackward.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnBackward.Enabled = false;
		this.btnBackward.Image = global::ns0.Class6.PreviousFrame_16x;
		this.btnBackward.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnBackward.Name = "btnBackward";
		this.btnBackward.Size = new global::System.Drawing.Size(28, 29);
		this.btnBackward.Text = "Backward [F7]";
		this.btnBackward.ToolTipText = "Load";
		this.tslMain_3.AutoSize = false;
		this.tslMain_3.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.tslMain_3.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.tslMain_3.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.cmbUnionStyle,
			this.btnNext,
			this.ToolStripSeparator1,
			this.btnBackward,
			this.ToolStripSeparator5,
			this.ToolStripSeparator9
		});
		this.tslMain_3.Location = new global::System.Drawing.Point(0, 65);
		this.tslMain_3.Name = "tslMain_3";
		this.tslMain_3.Padding = new global::System.Windows.Forms.Padding(0, 0, 4, 0);
		this.tslMain_3.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.System;
		this.tslMain_3.Size = new global::System.Drawing.Size(994, 32);
		this.tslMain_3.Stretch = true;
		this.tslMain_3.TabIndex = 22;
		this.tslMain_3.Text = "ToolStrip2";
		this.ToolStripSeparator1.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.ToolStripSeparator1.Name = "ToolStripSeparator1";
		this.ToolStripSeparator1.Size = new global::System.Drawing.Size(6, 32);
		this.ToolStripSeparator5.Name = "ToolStripSeparator5";
		this.ToolStripSeparator5.Size = new global::System.Drawing.Size(6, 32);
		this.ToolStripSeparator9.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.ToolStripSeparator9.Name = "ToolStripSeparator9";
		this.ToolStripSeparator9.Size = new global::System.Drawing.Size(6, 32);
		this.mnuCount.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.mnuCount.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.ToolStripMenuItem1
		});
		this.mnuCount.Name = "mnuCount";
		this.mnuCount.ShowImageMargin = false;
		this.mnuCount.Size = new global::System.Drawing.Size(220, 34);
		this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
		this.ToolStripMenuItem1.Size = new global::System.Drawing.Size(219, 30);
		this.ToolStripMenuItem1.Text = "ToolStripMenuItem1";
		this.tbcMain.Controls.Add(this.tpWB);
		this.tbcMain.Controls.Add(this.tpSource);
		this.tbcMain.Controls.Add(this.tpRaw);
		this.tbcMain.Controls.Add(this.tpSetup);
		this.tbcMain.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.tbcMain.ImageList = this.ImageList1;
		this.tbcMain.Location = new global::System.Drawing.Point(0, 129);
		this.tbcMain.Multiline = true;
		this.tbcMain.Name = "tbcMain";
		this.tbcMain.SelectedIndex = 0;
		this.tbcMain.Size = new global::System.Drawing.Size(994, 546);
		this.tbcMain.TabIndex = 24;
		this.tpWB.Controls.Add(this.wbBrowser);
		this.tpWB.ImageIndex = 0;
		this.tpWB.Location = new global::System.Drawing.Point(4, 4);
		this.tpWB.Name = "tpWB";
		this.tpWB.Padding = new global::System.Windows.Forms.Padding(3);
		this.tpWB.Size = new global::System.Drawing.Size(986, 513);
		this.tpWB.TabIndex = 0;
		this.tpWB.Text = "Web View";
		this.tpWB.UseVisualStyleBackColor = true;
		this.wbBrowser.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.wbBrowser.Location = new global::System.Drawing.Point(3, 3);
		this.wbBrowser.MinimumSize = new global::System.Drawing.Size(20, 20);
		this.wbBrowser.Name = "wbBrowser";
		this.wbBrowser.Size = new global::System.Drawing.Size(980, 507);
		this.wbBrowser.TabIndex = 2;
		this.tpSource.Controls.Add(this.txtSourceCode);
		this.tpSource.ImageIndex = 1;
		this.tpSource.Location = new global::System.Drawing.Point(4, 4);
		this.tpSource.Name = "tpSource";
		this.tpSource.Padding = new global::System.Windows.Forms.Padding(3);
		this.tpSource.Size = new global::System.Drawing.Size(986, 513);
		this.tpSource.TabIndex = 1;
		this.tpSource.Text = "Page Source";
		this.tpSource.UseVisualStyleBackColor = true;
		this.txtSourceCode.BackColor = global::System.Drawing.SystemColors.Control;
		this.txtSourceCode.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
		this.txtSourceCode.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.txtSourceCode.Font = new global::System.Drawing.Font("Courier New", 9.75f);
		this.txtSourceCode.Location = new global::System.Drawing.Point(3, 3);
		this.txtSourceCode.Multiline = true;
		this.txtSourceCode.Name = "txtSourceCode";
		this.txtSourceCode.ReadOnly = true;
		this.txtSourceCode.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
		this.txtSourceCode.Size = new global::System.Drawing.Size(980, 507);
		this.txtSourceCode.TabIndex = 1;
		this.tpRaw.Controls.Add(this.txtRaw);
		this.tpRaw.ImageIndex = 2;
		this.tpRaw.Location = new global::System.Drawing.Point(4, 4);
		this.tpRaw.Name = "tpRaw";
		this.tpRaw.Padding = new global::System.Windows.Forms.Padding(3);
		this.tpRaw.Size = new global::System.Drawing.Size(986, 513);
		this.tpRaw.TabIndex = 3;
		this.tpRaw.Text = "Raw";
		this.tpRaw.UseVisualStyleBackColor = true;
		this.txtRaw.BackColor = global::System.Drawing.SystemColors.Control;
		this.txtRaw.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
		this.txtRaw.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.txtRaw.Font = new global::System.Drawing.Font("Courier New", 9.75f);
		this.txtRaw.Location = new global::System.Drawing.Point(3, 3);
		this.txtRaw.Multiline = true;
		this.txtRaw.Name = "txtRaw";
		this.txtRaw.ReadOnly = true;
		this.txtRaw.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
		this.txtRaw.Size = new global::System.Drawing.Size(980, 507);
		this.txtRaw.TabIndex = 2;
		this.tpSetup.Controls.Add(this.grbSetup);
		this.tpSetup.Controls.Add(this.grbLogin);
		this.tpSetup.ImageIndex = 3;
		this.tpSetup.Location = new global::System.Drawing.Point(4, 4);
		this.tpSetup.Name = "tpSetup";
		this.tpSetup.Padding = new global::System.Windows.Forms.Padding(3);
		this.tpSetup.Size = new global::System.Drawing.Size(986, 513);
		this.tpSetup.TabIndex = 2;
		this.tpSetup.Text = "Setup";
		this.tpSetup.UseVisualStyleBackColor = true;
		this.grbSetup.Controls.Add(this.chkBypassProxy);
		this.grbSetup.Location = new global::System.Drawing.Point(6, 112);
		this.grbSetup.Name = "grbSetup";
		this.grbSetup.Size = new global::System.Drawing.Size(330, 63);
		this.grbSetup.TabIndex = 47;
		this.grbSetup.TabStop = false;
		this.chkBypassProxy.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkBypassProxy.Location = new global::System.Drawing.Point(14, 14);
		this.chkBypassProxy.Name = "chkBypassProxy";
		this.chkBypassProxy.Size = new global::System.Drawing.Size(298, 34);
		this.chkBypassProxy.TabIndex = 0;
		this.chkBypassProxy.Text = "Bypass proxy";
		this.chkBypassProxy.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkBypassProxy.UseVisualStyleBackColor = true;
		this.grbLogin.Controls.Add(this.txtUserName);
		this.grbLogin.Controls.Add(this.txtPassword);
		this.grbLogin.Controls.Add(this.lblUser);
		this.grbLogin.Controls.Add(this.lblPassword);
		this.grbLogin.Location = new global::System.Drawing.Point(6, 6);
		this.grbLogin.Name = "grbLogin";
		this.grbLogin.Size = new global::System.Drawing.Size(330, 100);
		this.grbLogin.TabIndex = 46;
		this.grbLogin.TabStop = false;
		this.grbLogin.Text = "Network Credential (Login)";
		this.txtUserName.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.txtUserName.Location = new global::System.Drawing.Point(130, 25);
		this.txtUserName.Name = "txtUserName";
		this.txtUserName.Size = new global::System.Drawing.Size(182, 26);
		this.txtUserName.TabIndex = 16;
		this.txtPassword.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.txtPassword.Location = new global::System.Drawing.Point(130, 60);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Size = new global::System.Drawing.Size(182, 26);
		this.txtPassword.TabIndex = 17;
		this.lblUser.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lblUser.Location = new global::System.Drawing.Point(9, 26);
		this.lblUser.Name = "lblUser";
		this.lblUser.Size = new global::System.Drawing.Size(116, 29);
		this.lblUser.TabIndex = 3;
		this.lblUser.Text = "UserName";
		this.lblUser.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.lblPassword.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lblPassword.Location = new global::System.Drawing.Point(9, 58);
		this.lblPassword.Name = "lblPassword";
		this.lblPassword.Size = new global::System.Drawing.Size(116, 29);
		this.lblPassword.TabIndex = 27;
		this.lblPassword.Text = "Password";
		this.lblPassword.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.ImageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("ImageList1.ImageStream");
		this.ImageList1.TransparentColor = global::System.Drawing.Color.Fuchsia;
		this.ImageList1.Images.SetKeyName(0, "VBWebAddNewBrowser_16x_24.bmp");
		this.ImageList1.Images.SetKeyName(1, "BlockSelection_16x_24.bmp");
		this.ImageList1.Images.SetKeyName(2, "HeaderFile_12x_24.bmp");
		this.ImageList1.Images.SetKeyName(3, "ConfigurationEditor_16x_24.bmp");
		this.stsMain.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.stsMain.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.lblStatus,
			this.prbStatus
		});
		this.stsMain.Location = new global::System.Drawing.Point(0, 675);
		this.stsMain.Name = "stsMain";
		this.stsMain.Padding = new global::System.Windows.Forms.Padding(2, 0, 14, 0);
		this.stsMain.Size = new global::System.Drawing.Size(994, 30);
		this.stsMain.SizingGrip = false;
		this.stsMain.TabIndex = 25;
		this.stsMain.Text = "StatusStrip1";
		this.lblStatus.Name = "lblStatus";
		this.lblStatus.Size = new global::System.Drawing.Size(978, 25);
		this.lblStatus.Spring = true;
		this.lblStatus.Text = "lblStatus";
		this.lblStatus.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
		this.prbStatus.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.prbStatus.Name = "prbStatus";
		this.prbStatus.Size = new global::System.Drawing.Size(100, 25);
		this.prbStatus.Visible = false;
		this.bckWorker.WorkerReportsProgress = true;
		this.bckWorker.WorkerSupportsCancellation = true;
		this.tslMain_2.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.tslMain_2.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.tslMain_2.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.btnWorker,
			this.btnClearForm,
			this.tsSp1,
			this.lblHttpStatus,
			this.tsSp2,
			this.lblIP,
			this.tsSp3,
			this.lblCountry,
			this.tsSp5,
			this.tsSp4,
			this.ToolStripSeparator6,
			this.chkWafs,
			this.ToolStripSeparator2,
			this.chkIE,
			this.ToolStripSeparator4,
			this.chkFlowRedirects
		});
		this.tslMain_2.Location = new global::System.Drawing.Point(0, 33);
		this.tslMain_2.Name = "tslMain_2";
		this.tslMain_2.Padding = new global::System.Windows.Forms.Padding(0, 0, 4, 0);
		this.tslMain_2.Size = new global::System.Drawing.Size(994, 32);
		this.tslMain_2.Stretch = true;
		this.tslMain_2.TabIndex = 26;
		this.tslMain_2.Text = "ToolStrip2";
		this.btnWorker.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.btnWorker.Enabled = false;
		this.btnWorker.Image = global::ns0.Class6.Run_16x_24;
		this.btnWorker.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnWorker.Name = "btnWorker";
		this.btnWorker.Size = new global::System.Drawing.Size(113, 29);
		this.btnWorker.Text = "Load [F5]";
		this.btnWorker.ToolTipText = "F5";
		this.btnClearForm.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnClearForm.Image = global::ns0.Class6.delete;
		this.btnClearForm.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnClearForm.Name = "btnClearForm";
		this.btnClearForm.Size = new global::System.Drawing.Size(28, 29);
		this.btnClearForm.Text = "Clear Form";
		this.btnClearForm.ToolTipText = "Clear Form";
		this.tsSp1.Name = "tsSp1";
		this.tsSp1.Size = new global::System.Drawing.Size(6, 32);
		this.lblHttpStatus.Name = "lblHttpStatus";
		this.lblHttpStatus.Size = new global::System.Drawing.Size(115, 29);
		this.lblHttpStatus.Text = "lblHttpStatus";
		this.tsSp2.Name = "tsSp2";
		this.tsSp2.Size = new global::System.Drawing.Size(6, 32);
		this.lblIP.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
		this.lblIP.Name = "lblIP";
		this.lblIP.Size = new global::System.Drawing.Size(46, 29);
		this.lblIP.Text = "lblIP";
		this.tsSp3.Name = "tsSp3";
		this.tsSp3.Size = new global::System.Drawing.Size(6, 32);
		this.lblCountry.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
		this.lblCountry.Name = "lblCountry";
		this.lblCountry.Size = new global::System.Drawing.Size(94, 29);
		this.lblCountry.Text = "lblCountry";
		this.tsSp5.Name = "tsSp5";
		this.tsSp5.Size = new global::System.Drawing.Size(6, 32);
		this.tsSp4.Name = "tsSp4";
		this.tsSp4.Size = new global::System.Drawing.Size(62, 29);
		this.tsSp4.Text = "lblSize";
		this.ToolStripSeparator6.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.ToolStripSeparator6.Name = "ToolStripSeparator6";
		this.ToolStripSeparator6.Size = new global::System.Drawing.Size(6, 32);
		this.chkWafs.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.chkWafs.Checked = true;
		this.chkWafs.CheckOnClick = true;
		this.chkWafs.CheckState = global::System.Windows.Forms.CheckState.Checked;
		this.chkWafs.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.chkWafs.Image = global::ns0.Class6.AddStyleRule_16x_24;
		this.chkWafs.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.chkWafs.Name = "chkWafs";
		this.chkWafs.Size = new global::System.Drawing.Size(28, 29);
		this.chkWafs.Text = "Enable Wafs";
		this.chkWafs.ToolTipText = "Load";
		this.ToolStripSeparator2.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.ToolStripSeparator2.Name = "ToolStripSeparator2";
		this.ToolStripSeparator2.Size = new global::System.Drawing.Size(6, 32);
		this.chkIE.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.chkIE.CheckOnClick = true;
		this.chkIE.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.chkIE.Image = global::ns0.Class6.DownloadWebSetting_16x;
		this.chkIE.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.chkIE.Name = "chkIE";
		this.chkIE.Size = new global::System.Drawing.Size(28, 29);
		this.chkIE.Text = "IE Browser Component";
		this.chkIE.ToolTipText = "IE Browser";
		this.ToolStripSeparator4.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.ToolStripSeparator4.Name = "ToolStripSeparator4";
		this.ToolStripSeparator4.Size = new global::System.Drawing.Size(6, 32);
		this.chkFlowRedirects.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.chkFlowRedirects.Checked = true;
		this.chkFlowRedirects.CheckOnClick = true;
		this.chkFlowRedirects.CheckState = global::System.Windows.Forms.CheckState.Checked;
		this.chkFlowRedirects.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.chkFlowRedirects.Image = global::ns0.Class6.PageRedirect_16x;
		this.chkFlowRedirects.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.chkFlowRedirects.Name = "chkFlowRedirects";
		this.chkFlowRedirects.Size = new global::System.Drawing.Size(28, 29);
		this.chkFlowRedirects.Text = "Follow HTTP Redirects";
		this.chkFlowRedirects.ToolTipText = "Follow HTTP Redirects";
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(994, 705);
		base.Controls.Add(this.tbcMain);
		base.Controls.Add(this.tslMain_4);
		base.Controls.Add(this.tslMain_3);
		base.Controls.Add(this.stsMain);
		base.Controls.Add(this.tslMain_2);
		base.Controls.Add(this.tslMain_1);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.Name = "Analizer";
		this.tslMain_1.ResumeLayout(false);
		this.tslMain_1.PerformLayout();
		this.tslMain_4.ResumeLayout(false);
		this.tslMain_4.PerformLayout();
		this.tslMain_3.ResumeLayout(false);
		this.tslMain_3.PerformLayout();
		this.mnuCount.ResumeLayout(false);
		this.tbcMain.ResumeLayout(false);
		this.tpWB.ResumeLayout(false);
		this.tpSource.ResumeLayout(false);
		this.tpSource.PerformLayout();
		this.tpRaw.ResumeLayout(false);
		this.tpRaw.PerformLayout();
		this.tpSetup.ResumeLayout(false);
		this.grbSetup.ResumeLayout(false);
		this.grbLogin.ResumeLayout(false);
		this.grbLogin.PerformLayout();
		this.stsMain.ResumeLayout(false);
		this.stsMain.PerformLayout();
		this.tslMain_2.ResumeLayout(false);
		this.tslMain_2.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x0400020A RID: 522
	private global::System.ComponentModel.IContainer icontainer_0;
}
