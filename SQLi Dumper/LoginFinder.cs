using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x0200006C RID: 108
[DesignerGenerated]
public partial class LoginFinder : Form
{
	// Token: 0x060003BB RID: 955 RVA: 0x0001AC2C File Offset: 0x00018E2C
	public LoginFinder()
	{
		base.Load += this.LoginFinder_Load;
		this.InitializeComponent();
		this.txtURL = new ToolStripSpringTextBox(0);
		this.tlsMenu.Items.Insert(2, this.txtURL);
		global::Globals.AddMouseMoveForm(this);
		global::Globals.translate_0.Add(this, this.icontainer_0);
	}

	// Token: 0x1700010A RID: 266
	// (get) Token: 0x060003BE RID: 958 RVA: 0x00003910 File Offset: 0x00001B10
	// (set) Token: 0x060003BF RID: 959 RVA: 0x00003918 File Offset: 0x00001B18
	internal virtual ToolStrip tlsMenu { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700010B RID: 267
	// (get) Token: 0x060003C0 RID: 960 RVA: 0x00003921 File Offset: 0x00001B21
	// (set) Token: 0x060003C1 RID: 961 RVA: 0x0001CD40 File Offset: 0x0001AF40
	internal virtual ToolStripButton btnPasteURL
	{
		[CompilerGenerated]
		get
		{
			return this._btnPasteURL;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_21);
			ToolStripButton btnPasteURL = this._btnPasteURL;
			if (btnPasteURL != null)
			{
				btnPasteURL.Click -= value2;
			}
			this._btnPasteURL = value;
			btnPasteURL = this._btnPasteURL;
			if (btnPasteURL != null)
			{
				btnPasteURL.Click += value2;
			}
		}
	}

	// Token: 0x1700010C RID: 268
	// (get) Token: 0x060003C2 RID: 962 RVA: 0x00003929 File Offset: 0x00001B29
	// (set) Token: 0x060003C3 RID: 963 RVA: 0x00003931 File Offset: 0x00001B31
	internal virtual ToolStripSeparator toolStripSeparator18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700010D RID: 269
	// (get) Token: 0x060003C4 RID: 964 RVA: 0x0000393A File Offset: 0x00001B3A
	// (set) Token: 0x060003C5 RID: 965 RVA: 0x00003942 File Offset: 0x00001B42
	internal virtual ToolStrip tsMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700010E RID: 270
	// (get) Token: 0x060003C6 RID: 966 RVA: 0x0000394B File Offset: 0x00001B4B
	// (set) Token: 0x060003C7 RID: 967 RVA: 0x0001CD84 File Offset: 0x0001AF84
	internal virtual ToolStripButton btnWorkerStart
	{
		[CompilerGenerated]
		get
		{
			return this._btnWorkerStart;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_6);
			ToolStripButton btnWorkerStart = this._btnWorkerStart;
			if (btnWorkerStart != null)
			{
				btnWorkerStart.Click -= value2;
			}
			this._btnWorkerStart = value;
			btnWorkerStart = this._btnWorkerStart;
			if (btnWorkerStart != null)
			{
				btnWorkerStart.Click += value2;
			}
		}
	}

	// Token: 0x1700010F RID: 271
	// (get) Token: 0x060003C8 RID: 968 RVA: 0x00003953 File Offset: 0x00001B53
	// (set) Token: 0x060003C9 RID: 969 RVA: 0x0001CDC8 File Offset: 0x0001AFC8
	internal virtual ToolStripButton btnWorkerPause
	{
		[CompilerGenerated]
		get
		{
			return this._btnWorkerPause;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_7);
			ToolStripButton btnWorkerPause = this._btnWorkerPause;
			if (btnWorkerPause != null)
			{
				btnWorkerPause.Click -= value2;
			}
			this._btnWorkerPause = value;
			btnWorkerPause = this._btnWorkerPause;
			if (btnWorkerPause != null)
			{
				btnWorkerPause.Click += value2;
			}
		}
	}

	// Token: 0x17000110 RID: 272
	// (get) Token: 0x060003CA RID: 970 RVA: 0x0000395B File Offset: 0x00001B5B
	// (set) Token: 0x060003CB RID: 971 RVA: 0x00003963 File Offset: 0x00001B63
	internal virtual ToolStripSeparator btnSearchColumnSP { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000111 RID: 273
	// (get) Token: 0x060003CC RID: 972 RVA: 0x0000396C File Offset: 0x00001B6C
	// (set) Token: 0x060003CD RID: 973 RVA: 0x0001CE0C File Offset: 0x0001B00C
	internal virtual ToolStripButton btnWorkerStop
	{
		[CompilerGenerated]
		get
		{
			return this._btnWorkerStop;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_8);
			ToolStripButton btnWorkerStop = this._btnWorkerStop;
			if (btnWorkerStop != null)
			{
				btnWorkerStop.Click -= value2;
			}
			this._btnWorkerStop = value;
			btnWorkerStop = this._btnWorkerStop;
			if (btnWorkerStop != null)
			{
				btnWorkerStop.Click += value2;
			}
		}
	}

	// Token: 0x17000112 RID: 274
	// (get) Token: 0x060003CE RID: 974 RVA: 0x00003974 File Offset: 0x00001B74
	// (set) Token: 0x060003CF RID: 975 RVA: 0x0000397C File Offset: 0x00001B7C
	internal virtual ToolStripProgressBar prbWorker { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000113 RID: 275
	// (get) Token: 0x060003D0 RID: 976 RVA: 0x00003985 File Offset: 0x00001B85
	// (set) Token: 0x060003D1 RID: 977 RVA: 0x0000398D File Offset: 0x00001B8D
	internal virtual ToolStripLabel lblStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000114 RID: 276
	// (get) Token: 0x060003D2 RID: 978 RVA: 0x00003996 File Offset: 0x00001B96
	// (set) Token: 0x060003D3 RID: 979 RVA: 0x0000399E File Offset: 0x00001B9E
	internal virtual Panel pnlSetupDump { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000115 RID: 277
	// (get) Token: 0x060003D4 RID: 980 RVA: 0x000039A7 File Offset: 0x00001BA7
	// (set) Token: 0x060003D5 RID: 981 RVA: 0x000039AF File Offset: 0x00001BAF
	internal virtual Panel pnlSetupDump2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000116 RID: 278
	// (get) Token: 0x060003D6 RID: 982 RVA: 0x000039B8 File Offset: 0x00001BB8
	// (set) Token: 0x060003D7 RID: 983 RVA: 0x000039C0 File Offset: 0x00001BC0
	internal virtual ToolStrip tsBottom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000117 RID: 279
	// (get) Token: 0x060003D8 RID: 984 RVA: 0x000039C9 File Offset: 0x00001BC9
	// (set) Token: 0x060003D9 RID: 985 RVA: 0x0001CE50 File Offset: 0x0001B050
	internal virtual ToolStripButton btnLoadDefautSettings
	{
		[CompilerGenerated]
		get
		{
			return this._btnLoadDefautSettings;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_2);
			ToolStripButton btnLoadDefautSettings = this._btnLoadDefautSettings;
			if (btnLoadDefautSettings != null)
			{
				btnLoadDefautSettings.Click -= value2;
			}
			this._btnLoadDefautSettings = value;
			btnLoadDefautSettings = this._btnLoadDefautSettings;
			if (btnLoadDefautSettings != null)
			{
				btnLoadDefautSettings.Click += value2;
			}
		}
	}

	// Token: 0x17000118 RID: 280
	// (get) Token: 0x060003DA RID: 986 RVA: 0x000039D1 File Offset: 0x00001BD1
	// (set) Token: 0x060003DB RID: 987 RVA: 0x000039D9 File Offset: 0x00001BD9
	internal virtual GroupBox grbSetup_5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000119 RID: 281
	// (get) Token: 0x060003DC RID: 988 RVA: 0x000039E2 File Offset: 0x00001BE2
	// (set) Token: 0x060003DD RID: 989 RVA: 0x000039EA File Offset: 0x00001BEA
	internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700011A RID: 282
	// (get) Token: 0x060003DE RID: 990 RVA: 0x000039F3 File Offset: 0x00001BF3
	// (set) Token: 0x060003DF RID: 991 RVA: 0x000039FB File Offset: 0x00001BFB
	internal virtual TextBox txtAddHeaderValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700011B RID: 283
	// (get) Token: 0x060003E0 RID: 992 RVA: 0x00003A04 File Offset: 0x00001C04
	// (set) Token: 0x060003E1 RID: 993 RVA: 0x00003A0C File Offset: 0x00001C0C
	internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700011C RID: 284
	// (get) Token: 0x060003E2 RID: 994 RVA: 0x00003A15 File Offset: 0x00001C15
	// (set) Token: 0x060003E3 RID: 995 RVA: 0x00003A1D File Offset: 0x00001C1D
	internal virtual TextBox txtAddHeaderName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700011D RID: 285
	// (get) Token: 0x060003E4 RID: 996 RVA: 0x00003A26 File Offset: 0x00001C26
	// (set) Token: 0x060003E5 RID: 997 RVA: 0x00003A2E File Offset: 0x00001C2E
	internal virtual TextBox txtCookies { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700011E RID: 286
	// (get) Token: 0x060003E6 RID: 998 RVA: 0x00003A37 File Offset: 0x00001C37
	// (set) Token: 0x060003E7 RID: 999 RVA: 0x00003A3F File Offset: 0x00001C3F
	internal virtual Label Label12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700011F RID: 287
	// (get) Token: 0x060003E8 RID: 1000 RVA: 0x00003A48 File Offset: 0x00001C48
	// (set) Token: 0x060003E9 RID: 1001 RVA: 0x00003A50 File Offset: 0x00001C50
	internal virtual CheckBox chkAddHearder { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000120 RID: 288
	// (get) Token: 0x060003EA RID: 1002 RVA: 0x00003A59 File Offset: 0x00001C59
	// (set) Token: 0x060003EB RID: 1003 RVA: 0x00003A61 File Offset: 0x00001C61
	internal virtual GroupBox grbSetup_4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000121 RID: 289
	// (get) Token: 0x060003EC RID: 1004 RVA: 0x00003A6A File Offset: 0x00001C6A
	// (set) Token: 0x060003ED RID: 1005 RVA: 0x00003A72 File Offset: 0x00001C72
	internal virtual TextBox txtUserName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000122 RID: 290
	// (get) Token: 0x060003EE RID: 1006 RVA: 0x00003A7B File Offset: 0x00001C7B
	// (set) Token: 0x060003EF RID: 1007 RVA: 0x00003A83 File Offset: 0x00001C83
	internal virtual TextBox txtPassword { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000123 RID: 291
	// (get) Token: 0x060003F0 RID: 1008 RVA: 0x00003A8C File Offset: 0x00001C8C
	// (set) Token: 0x060003F1 RID: 1009 RVA: 0x00003A94 File Offset: 0x00001C94
	internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000124 RID: 292
	// (get) Token: 0x060003F2 RID: 1010 RVA: 0x00003A9D File Offset: 0x00001C9D
	// (set) Token: 0x060003F3 RID: 1011 RVA: 0x00003AA5 File Offset: 0x00001CA5
	internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000125 RID: 293
	// (get) Token: 0x060003F4 RID: 1012 RVA: 0x00003AAE File Offset: 0x00001CAE
	// (set) Token: 0x060003F5 RID: 1013 RVA: 0x00003AB6 File Offset: 0x00001CB6
	internal virtual GroupBox grbSetup_3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000126 RID: 294
	// (get) Token: 0x060003F6 RID: 1014 RVA: 0x00003ABF File Offset: 0x00001CBF
	// (set) Token: 0x060003F7 RID: 1015 RVA: 0x00003AC7 File Offset: 0x00001CC7
	internal virtual ComboBox cmbCharCasing { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000127 RID: 295
	// (get) Token: 0x060003F8 RID: 1016 RVA: 0x00003AD0 File Offset: 0x00001CD0
	// (set) Token: 0x060003F9 RID: 1017 RVA: 0x00003AD8 File Offset: 0x00001CD8
	internal virtual GroupBox grbSetup_1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000128 RID: 296
	// (get) Token: 0x060003FA RID: 1018 RVA: 0x00003AE1 File Offset: 0x00001CE1
	// (set) Token: 0x060003FB RID: 1019 RVA: 0x00003AE9 File Offset: 0x00001CE9
	internal virtual CheckBox chkHttpRedirect { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000129 RID: 297
	// (get) Token: 0x060003FC RID: 1020 RVA: 0x00003AF2 File Offset: 0x00001CF2
	// (set) Token: 0x060003FD RID: 1021 RVA: 0x00003AFA File Offset: 0x00001CFA
	internal virtual NumericUpDown numDelay { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700012A RID: 298
	// (get) Token: 0x060003FE RID: 1022 RVA: 0x00003B03 File Offset: 0x00001D03
	// (set) Token: 0x060003FF RID: 1023 RVA: 0x00003B0B File Offset: 0x00001D0B
	internal virtual CheckBox chkThreads { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700012B RID: 299
	// (get) Token: 0x06000400 RID: 1024 RVA: 0x00003B14 File Offset: 0x00001D14
	// (set) Token: 0x06000401 RID: 1025 RVA: 0x00003B1C File Offset: 0x00001D1C
	internal virtual NumericUpDown numThreads { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700012C RID: 300
	// (get) Token: 0x06000402 RID: 1026 RVA: 0x00003B25 File Offset: 0x00001D25
	// (set) Token: 0x06000403 RID: 1027 RVA: 0x00003B2D File Offset: 0x00001D2D
	internal virtual NumericUpDown numTimeOut { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700012D RID: 301
	// (get) Token: 0x06000404 RID: 1028 RVA: 0x00003B36 File Offset: 0x00001D36
	// (set) Token: 0x06000405 RID: 1029 RVA: 0x00003B3E File Offset: 0x00001D3E
	internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700012E RID: 302
	// (get) Token: 0x06000406 RID: 1030 RVA: 0x00003B47 File Offset: 0x00001D47
	// (set) Token: 0x06000407 RID: 1031 RVA: 0x00003B4F File Offset: 0x00001D4F
	internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700012F RID: 303
	// (get) Token: 0x06000408 RID: 1032 RVA: 0x00003B58 File Offset: 0x00001D58
	// (set) Token: 0x06000409 RID: 1033 RVA: 0x00003B60 File Offset: 0x00001D60
	internal virtual GroupBox grbSetup_2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000130 RID: 304
	// (get) Token: 0x0600040A RID: 1034 RVA: 0x00003B69 File Offset: 0x00001D69
	// (set) Token: 0x0600040B RID: 1035 RVA: 0x0001CE94 File Offset: 0x0001B094
	internal virtual Button btnDictPath
	{
		[CompilerGenerated]
		get
		{
			return this._btnDictPath;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_3);
			Button btnDictPath = this._btnDictPath;
			if (btnDictPath != null)
			{
				btnDictPath.Click -= value2;
			}
			this._btnDictPath = value;
			btnDictPath = this._btnDictPath;
			if (btnDictPath != null)
			{
				btnDictPath.Click += value2;
			}
		}
	}

	// Token: 0x17000131 RID: 305
	// (get) Token: 0x0600040C RID: 1036 RVA: 0x00003B71 File Offset: 0x00001D71
	// (set) Token: 0x0600040D RID: 1037 RVA: 0x00003B79 File Offset: 0x00001D79
	internal virtual TextBox txtDictPath { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000132 RID: 306
	// (get) Token: 0x0600040E RID: 1038 RVA: 0x00003B82 File Offset: 0x00001D82
	// (set) Token: 0x0600040F RID: 1039 RVA: 0x00003B8A File Offset: 0x00001D8A
	internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000133 RID: 307
	// (get) Token: 0x06000410 RID: 1040 RVA: 0x00003B93 File Offset: 0x00001D93
	// (set) Token: 0x06000411 RID: 1041 RVA: 0x00003B9B File Offset: 0x00001D9B
	internal virtual TextBox txtWebApps { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000134 RID: 308
	// (get) Token: 0x06000412 RID: 1042 RVA: 0x00003BA4 File Offset: 0x00001DA4
	// (set) Token: 0x06000413 RID: 1043 RVA: 0x00003BAC File Offset: 0x00001DAC
	internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000135 RID: 309
	// (get) Token: 0x06000414 RID: 1044 RVA: 0x00003BB5 File Offset: 0x00001DB5
	// (set) Token: 0x06000415 RID: 1045 RVA: 0x0001CED8 File Offset: 0x0001B0D8
	public virtual BackgroundWorker bckWorker
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
			DoWorkEventHandler value2 = new DoWorkEventHandler(this.method_9);
			ProgressChangedEventHandler value3 = new ProgressChangedEventHandler(this.method_10);
			RunWorkerCompletedEventHandler value4 = new RunWorkerCompletedEventHandler(this.method_11);
			BackgroundWorker backgroundWorker = this.backgroundWorker_0;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
				backgroundWorker.ProgressChanged -= value3;
				backgroundWorker.RunWorkerCompleted -= value4;
			}
			this.backgroundWorker_0 = value;
			backgroundWorker = this.backgroundWorker_0;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
				backgroundWorker.ProgressChanged += value3;
				backgroundWorker.RunWorkerCompleted += value4;
			}
		}
	}

	// Token: 0x17000136 RID: 310
	// (get) Token: 0x06000416 RID: 1046 RVA: 0x00003BBD File Offset: 0x00001DBD
	// (set) Token: 0x06000417 RID: 1047 RVA: 0x0001CF54 File Offset: 0x0001B154
	internal virtual CheckBox chkWebApps
	{
		[CompilerGenerated]
		get
		{
			return this._chkWebApps;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_17);
			CheckBox chkWebApps = this._chkWebApps;
			if (chkWebApps != null)
			{
				chkWebApps.CheckedChanged -= value2;
			}
			this._chkWebApps = value;
			chkWebApps = this._chkWebApps;
			if (chkWebApps != null)
			{
				chkWebApps.CheckedChanged += value2;
			}
		}
	}

	// Token: 0x17000137 RID: 311
	// (get) Token: 0x06000418 RID: 1048 RVA: 0x00003BC5 File Offset: 0x00001DC5
	// (set) Token: 0x06000419 RID: 1049 RVA: 0x00003BCD File Offset: 0x00001DCD
	internal virtual ListBox lstResult { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000138 RID: 312
	// (get) Token: 0x0600041A RID: 1050 RVA: 0x00003BD6 File Offset: 0x00001DD6
	// (set) Token: 0x0600041B RID: 1051 RVA: 0x0001CF98 File Offset: 0x0001B198
	internal virtual ContextMenuStrip mnuResult
	{
		[CompilerGenerated]
		get
		{
			return this._mnuResult;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			CancelEventHandler value2 = new CancelEventHandler(this.method_18);
			ContextMenuStrip mnuResult = this._mnuResult;
			if (mnuResult != null)
			{
				mnuResult.Opening -= value2;
			}
			this._mnuResult = value;
			mnuResult = this._mnuResult;
			if (mnuResult != null)
			{
				mnuResult.Opening += value2;
			}
		}
	}

	// Token: 0x17000139 RID: 313
	// (get) Token: 0x0600041C RID: 1052 RVA: 0x00003BDE File Offset: 0x00001DDE
	// (set) Token: 0x0600041D RID: 1053 RVA: 0x0001CFDC File Offset: 0x0001B1DC
	internal virtual ToolStripMenuItem mnuShell
	{
		[CompilerGenerated]
		get
		{
			return this._mnuShell;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_20);
			ToolStripMenuItem mnuShell = this._mnuShell;
			if (mnuShell != null)
			{
				mnuShell.Click -= value2;
			}
			this._mnuShell = value;
			mnuShell = this._mnuShell;
			if (mnuShell != null)
			{
				mnuShell.Click += value2;
			}
		}
	}

	// Token: 0x1700013A RID: 314
	// (get) Token: 0x0600041E RID: 1054 RVA: 0x00003BE6 File Offset: 0x00001DE6
	// (set) Token: 0x0600041F RID: 1055 RVA: 0x0001D020 File Offset: 0x0001B220
	internal virtual ToolStripMenuItem mnuClipboard
	{
		[CompilerGenerated]
		get
		{
			return this._mnuClipboard;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_19);
			ToolStripMenuItem mnuClipboard = this._mnuClipboard;
			if (mnuClipboard != null)
			{
				mnuClipboard.Click -= value2;
			}
			this._mnuClipboard = value;
			mnuClipboard = this._mnuClipboard;
			if (mnuClipboard != null)
			{
				mnuClipboard.Click += value2;
			}
		}
	}

	// Token: 0x1700013B RID: 315
	// (get) Token: 0x06000420 RID: 1056 RVA: 0x00003BEE File Offset: 0x00001DEE
	// (set) Token: 0x06000421 RID: 1057 RVA: 0x00003BF6 File Offset: 0x00001DF6
	internal virtual CheckBox chkStopWhenDetects { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700013C RID: 316
	// (get) Token: 0x06000422 RID: 1058 RVA: 0x00003BFF File Offset: 0x00001DFF
	// (set) Token: 0x06000423 RID: 1059 RVA: 0x0001D064 File Offset: 0x0001B264
	internal virtual ToolStripSpringTextBox txtURL
	{
		[CompilerGenerated]
		get
		{
			return this.toolStripSpringTextBox_0;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_16);
			ToolStripSpringTextBox toolStripSpringTextBox = this.toolStripSpringTextBox_0;
			if (toolStripSpringTextBox != null)
			{
				toolStripSpringTextBox.TextChanged -= value2;
			}
			this.toolStripSpringTextBox_0 = value;
			toolStripSpringTextBox = this.toolStripSpringTextBox_0;
			if (toolStripSpringTextBox != null)
			{
				toolStripSpringTextBox.TextChanged += value2;
			}
		}
	}

	// Token: 0x1700013D RID: 317
	// (get) Token: 0x06000424 RID: 1060 RVA: 0x00003C07 File Offset: 0x00001E07
	// (set) Token: 0x06000425 RID: 1061 RVA: 0x00003C0F File Offset: 0x00001E0F
	internal int RunningProgress { get; set; }

	// Token: 0x1700013F RID: 319
	// (get) Token: 0x06000426 RID: 1062 RVA: 0x0001D0A8 File Offset: 0x0001B2A8
	internal int Int32_0
	{
		get
		{
			int result;
			if (this.threadPool_0 == null)
			{
				result = 0;
			}
			else
			{
				result = this.threadPool_0.ThreadCount;
			}
			return result;
		}
	}

	// Token: 0x1700013E RID: 318
	// (get) Token: 0x06000427 RID: 1063 RVA: 0x00003C18 File Offset: 0x00001E18
	// (set) Token: 0x06000428 RID: 1064 RVA: 0x00003C20 File Offset: 0x00001E20
	internal bool RunningWorker { get; set; }

	// Token: 0x06000429 RID: 1065 RVA: 0x00003C29 File Offset: 0x00001E29
	public void LoadingOnCancel()
	{
		if (this.RunningWorker)
		{
			this.bckWorker.CancelAsync();
		}
	}

	// Token: 0x0600042A RID: 1066 RVA: 0x00003C3E File Offset: 0x00001E3E
	public void SaveSettings()
	{
		Class50.smethod_4(base.Name, this.txtURL.Name, this.txtURL.Text, null);
		Class50.smethod_3(this, null);
	}

	// Token: 0x0600042B RID: 1067 RVA: 0x00003C69 File Offset: 0x00001E69
	public void LoadSettings()
	{
		this.txtURL.Text = Class50.smethod_5(base.Name, this.txtURL.Name, "", null);
		Class50.smethod_2(this, null);
	}

	// Token: 0x0600042C RID: 1068 RVA: 0x00003C99 File Offset: 0x00001E99
	private void method_0(string string_1)
	{
		if (this.tsMain.InvokeRequired)
		{
			this.tsMain.Invoke(new LoginFinder.Delegate17(this.method_0), new object[]
			{
				string_1
			});
		}
		else
		{
			this.lblStatus.Text = string_1;
		}
	}

	// Token: 0x0600042D RID: 1069 RVA: 0x0001D0D4 File Offset: 0x0001B2D4
	private void method_1(string string_1)
	{
		if (this.lstResult.InvokeRequired)
		{
			this.lstResult.Invoke(new LoginFinder.Delegate18(this.method_1), new object[]
			{
				string_1
			});
		}
		else
		{
			this.lstResult.Items.Add(string_1);
		}
	}

	// Token: 0x0600042E RID: 1070 RVA: 0x0001D124 File Offset: 0x0001B324
	private void method_2(object sender, EventArgs e)
	{
		global::Globals.GMain.pnlLoginFinder.SuspendLayout();
		global::Globals.LockWindowUpdateForced(false);
		global::Globals.GMain.method_62(false);
		global::Globals.GMain.method_59(false);
		global::Globals.LockWindowUpdateForced(true);
		global::Globals.GMain.pnlLoginFinder.ResumeLayout();
		global::Globals.GMain.pnlLoginFinder.Refresh();
	}

	// Token: 0x0600042F RID: 1071 RVA: 0x0001D184 File Offset: 0x0001B384
	private void LoginFinder_Load(object sender, EventArgs e)
	{
		this.lblStatus.Text = "";
		this.cmbCharCasing.Items.AddRange(new string[]
		{
			"Normal",
			"lower".ToLower(),
			"upper".ToUpper()
		});
		this.cmbCharCasing.SelectedIndex = 0;
		this.txtWebApps.Text = "php;asp;html";
		this.grbSetup_5.Visible = false;
		this.mnuClipboard.Text = global::Globals.GMain.mnuLWClipboard.Text;
		this.mnuShell.Text = global::Globals.GMain.mnuLWShell.Text;
		if (!File.Exists(this.txtDictPath.Text))
		{
			this.txtDictPath.Text = global::Globals.DIC_LOGIN_FINDER;
		}
		if (!File.Exists(global::Globals.DIC_LOGIN_FINDER))
		{
			File.WriteAllText(global::Globals.DIC_LOGIN_FINDER, Class6.dic_login_finder);
		}
	}

	// Token: 0x06000430 RID: 1072 RVA: 0x0001D278 File Offset: 0x0001B478
	private void method_3(object sender, EventArgs e)
	{
		try
		{
			string text = this.txtDictPath.Text;
			if (!string.IsNullOrEmpty(text))
			{
				global::Globals.ShellUrl(text);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	// Token: 0x06000431 RID: 1073 RVA: 0x0001D2D4 File Offset: 0x0001B4D4
	private void method_4(bool bool_1)
	{
		this.btnWorkerStart.Visible = bool_1;
		this.btnWorkerPause.Visible = !bool_1;
		this.btnWorkerStop.Visible = !bool_1;
		this.btnWorkerStop.Enabled = !bool_1;
		this.btnWorkerPause.Enabled = !bool_1;
		this.chkThreads.Enabled = bool_1;
		this.numThreads.Enabled = bool_1;
		this.grbSetup_2.Enabled = bool_1;
		this.grbSetup_4.Enabled = bool_1;
		this.grbSetup_5.Enabled = bool_1;
		this.prbWorker.Visible = !bool_1;
		this.lblStatus.Text = "";
		this.btnLoadDefautSettings.Enabled = bool_1;
		this.method_16(null, null);
	}

	// Token: 0x06000432 RID: 1074 RVA: 0x0001D398 File Offset: 0x0001B598
	private bool method_5()
	{
		bool result;
		if (base.InvokeRequired)
		{
			result = Conversions.ToBoolean(base.Invoke(new LoginFinder.Delegate19(this.method_5)));
		}
		else
		{
			if (this.btnWorkerPause.Checked)
			{
				this.threadPool_0.Paused = true;
				while (this.btnWorkerPause.Checked)
				{
					Thread.Sleep(500);
					Application.DoEvents();
					if (this.bckWorker.CancellationPending)
					{
						break;
					}
				}
				this.threadPool_0.Paused = false;
			}
			result = this.bckWorker.CancellationPending;
		}
		return result;
	}

	// Token: 0x06000433 RID: 1075 RVA: 0x0001D424 File Offset: 0x0001B624
	private void method_6(object sender, EventArgs e)
	{
		try
		{
			this.method_4(false);
			List<string> list = new List<string>();
			foreach (string text in File.ReadAllLines(this.txtDictPath.Text))
			{
				if (!string.IsNullOrEmpty(text))
				{
					text = text.Trim();
					if (!list.Contains(text))
					{
						list.Add(text);
					}
				}
			}
			if (this.chkThreads.Checked)
			{
				this.int_0 = Convert.ToInt32(this.numThreads.Value);
			}
			else
			{
				this.int_0 = 1;
			}
			if (list.Count != 0)
			{
				this.lstResult.Items.Clear();
				this.int_1 = 0;
				this.bckWorker.RunWorkerAsync(list);
			}
		}
		catch (Exception ex)
		{
			Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
		}
	}

	// Token: 0x06000434 RID: 1076 RVA: 0x000027EC File Offset: 0x000009EC
	private void method_7(object sender, EventArgs e)
	{
	}

	// Token: 0x06000435 RID: 1077 RVA: 0x00003CD8 File Offset: 0x00001ED8
	private void method_8(object sender, EventArgs e)
	{
		this.btnWorkerStop.Enabled = false;
		this.btnWorkerPause.Checked = false;
		this.btnWorkerPause.Enabled = false;
		this.LoadingOnCancel();
	}

	// Token: 0x06000436 RID: 1078 RVA: 0x0001D518 File Offset: 0x0001B718
	private void method_9(object sender, DoWorkEventArgs e)
	{
		checked
		{
			try
			{
				this.RunningWorker = true;
				List<string> list = (List<string>)e.Argument;
				int num = 1;
				int count = list.Count;
				int num2;
				if (this.int_0 > count)
				{
					num2 = count;
				}
				else
				{
					num2 = this.int_0;
				}
				this.threadPool_0 = new global::ThreadPool(num2);
				this.method_12();
				try
				{
					foreach (string text in list)
					{
						if (this.method_5())
						{
							this.threadPool_0.AbortThreads();
							if (this.int_1 != 1)
							{
								e.Result = global::Globals.translate_0.GetStr(global::Globals.GMain, 25, "");
							}
							break;
						}
						int percentProgress = (int)Math.Round(Math.Round((double)(100 * num) / (double)count));
						if (num2 > 1)
						{
							this.method_0(string.Concat(new string[]
							{
								"[",
								Conversions.ToString(num),
								"/",
								Conversions.ToString(count),
								"] ",
								global::Globals.translate_0.GetStr(global::Globals.GMain, 18, ""),
								Conversions.ToString(this.int_1)
							}));
						}
						else
						{
							this.method_0(string.Concat(new string[]
							{
								"[",
								Conversions.ToString(num),
								"/",
								Conversions.ToString(count),
								"] ",
								global::Globals.translate_0.GetStr(global::Globals.GMain, 20, ""),
								text.Replace(".%EXT%", ""),
								", ",
								global::Globals.translate_0.GetStr(global::Globals.GMain, 24, ""),
								Conversions.ToString(this.int_1)
							}));
						}
						this.bckWorker.ReportProgress(percentProgress);
						Thread thread = new Thread(new ParameterizedThreadStart(this.method_22));
						thread.Name = "Pos : " + num.ToString();
						thread.Start(new LoginFinder.Class43
						{
							Thread = thread,
							Page = text,
							Url = Conversions.ToString(global::Globals.GetObjectValue(this.txtURL))
						});
						this.threadPool_0.Open(thread);
						this.threadPool_0.WaitForThreads();
						num++;
					}
				}
				finally
				{
					List<string>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				this.threadPool_0.AllJobsPushed();
				for (;;)
				{
					this.method_0(string.Concat(new string[]
					{
						"[",
						Conversions.ToString(this.threadPool_0.ThreadCount),
						"] ",
						global::Globals.translate_0.GetStr(global::Globals.GMain, 23, ""),
						global::Globals.translate_0.GetStr(global::Globals.GMain, 24, ""),
						global::Globals.FormatNumbers(this.int_1, true)
					}));
					if (this.bckWorker.CancellationPending)
					{
						break;
					}
					if (this.threadPool_0.Finished)
					{
						goto IL_30E;
					}
				}
				this.threadPool_0.AbortThreads();
				IL_30E:;
			}
			catch (Exception ex)
			{
				e.Result = global::Globals.translate_0.GetStr(global::Globals.GMain, 27, "") + ex.Message;
			}
		}
	}

	// Token: 0x06000437 RID: 1079 RVA: 0x00003D04 File Offset: 0x00001F04
	private void method_10(object sender, ProgressChangedEventArgs e)
	{
		this.prbWorker.Value = e.ProgressPercentage;
		this.RunningProgress = e.ProgressPercentage;
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x0001D8A0 File Offset: 0x0001BAA0
	private void method_11(object sender, RunWorkerCompletedEventArgs e)
	{
		this.RunningWorker = false;
		this.method_4(true);
		if (e.Result == null)
		{
			this.method_0(global::Globals.translate_0.GetStr(global::Globals.GMain, 25, "") + " " + global::Globals.translate_0.GetStr(global::Globals.GMain, 24, "") + Conversions.ToString(this.int_1));
		}
		else
		{
			this.method_0(e.Result.ToString() + " " + global::Globals.translate_0.GetStr(global::Globals.GMain, 24, "") + Conversions.ToString(this.int_1));
		}
	}

	// Token: 0x06000439 RID: 1081 RVA: 0x0001D94C File Offset: 0x0001BB4C
	private void method_12()
	{
		if (Conversions.ToBoolean(global::Globals.GetObjectValue(this.chkWebApps)))
		{
			string text = Conversions.ToString(global::Globals.GetObjectValue(this.txtURL));
			string[] array = Strings.Split(text, "//", -1, CompareMethod.Binary);
			if (array.Length == 2)
			{
				int num = array[1].IndexOf("/");
				if (num > 3)
				{
					array[1] = array[1].Substring(0, num);
				}
				text = array[0] + "//" + array[1];
			}
			HTTP http = new HTTP();
			this.method_14(text, ref http);
			string string_;
			this.webServer_0 = Class23.smethod_0(text, string_, http);
			http.Dispose();
		}
		else
		{
			this.webServer_0 = global::Globals.WebServer.UNKNOW;
		}
	}

	// Token: 0x0600043A RID: 1082 RVA: 0x0001D9F8 File Offset: 0x0001BBF8
	private void method_13(LoginFinder.Class43 class43_0)
	{
		try
		{
			string text = Conversions.ToString(global::Globals.GetObjectValue(this.txtWebApps));
			HTTP http = new HTTP();
			object objectValue = global::Globals.GetObjectValue(this.cmbCharCasing);
			if (!Operators.ConditionalCompareObjectEqual(objectValue, 0, false))
			{
				if (Operators.ConditionalCompareObjectEqual(objectValue, 1, false))
				{
					class43_0.Page = class43_0.Page.ToLower();
				}
				else if (Operators.ConditionalCompareObjectEqual(objectValue, 2, false))
				{
					class43_0.Page = class43_0.Page.ToUpper();
				}
			}
			switch (this.webServer_0)
			{
			case global::Globals.WebServer.LINUX:
				text = "php;html";
				break;
			case global::Globals.WebServer.WINDOWS:
				text = "asp;html";
				break;
			}
			string string_;
			if (class43_0.Page.Contains("%EXT%"))
			{
				foreach (string newValue in text.Split(new char[]
				{
					';'
				}))
				{
					string_ = class43_0.Url + class43_0.Page.Replace("%EXT%", newValue);
					this.method_14(string_, ref http);
					if (http.o.LastStatus == 200)
					{
						break;
					}
				}
			}
			else
			{
				string_ = class43_0.Url + class43_0.Page;
				this.method_14(string_, ref http);
			}
			if (!this.method_5() && http.o.LastStatus == 200)
			{
				lock (this)
				{
					if (Conversions.ToBoolean(Operators.AndObject(this.int_1 > 0, global::Globals.GetObjectValue(this.chkStopWhenDetects))))
					{
						this.LoadingOnCancel();
					}
					else
					{
						this.method_1(string_);
						ref int ptr = ref this.int_1;
						this.int_1 = checked(ptr + 1);
					}
				}
			}
			http.Dispose();
		}
		catch (Exception ex)
		{
			if (ex is ThreadAbortException)
			{
			}
		}
		finally
		{
			try
			{
				this.threadPool_0.Close(class43_0.Thread);
			}
			catch (Exception ex2)
			{
			}
		}
	}

	// Token: 0x0600043B RID: 1083 RVA: 0x0001DC70 File Offset: 0x0001BE70
	private string method_14(string string_1, ref HTTP http_0)
	{
		string text = "";
		http_0.o.FollowRedirects = Conversions.ToBoolean(global::Globals.GetObjectValue(this.chkHttpRedirect));
		http_0.o.ConnectTimeout = Conversions.ToInteger(global::Globals.GetObjectValue(this.numTimeOut));
		http_0.o.ReadTimeout = http_0.o.ConnectTimeout;
		int num = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.numHTTPRetry));
		checked
		{
			for (int i = 0; i <= num; i++)
			{
				this.method_15();
				text = http_0.QuickGet(string_1);
				if (!string.IsNullOrEmpty(text) || http_0.Status > 0 || this.method_5())
				{
					break;
				}
			}
			return text;
		}
	}

	// Token: 0x0600043C RID: 1084 RVA: 0x0001DD28 File Offset: 0x0001BF28
	private void method_15()
	{
		if (this.$STATIC$CheckRequestDelay$2001$LastTick$Init == null)
		{
			Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$CheckRequestDelay$2001$LastTick$Init, new StaticLocalInitFlag(), null);
		}
		bool flag = false;
		try
		{
			Monitor.Enter(this.$STATIC$CheckRequestDelay$2001$LastTick$Init, ref flag);
			if (this.$STATIC$CheckRequestDelay$2001$LastTick$Init.State == 0)
			{
				this.$STATIC$CheckRequestDelay$2001$LastTick$Init.State = 2;
				this.$STATIC$CheckRequestDelay$2001$LastTick = DateAndTime.Now.AddHours(-1.0);
			}
			else if (this.$STATIC$CheckRequestDelay$2001$LastTick$Init.State == 2)
			{
				throw new IncompleteInitialization();
			}
			goto IL_A0;
		}
		finally
		{
			this.$STATIC$CheckRequestDelay$2001$LastTick$Init.State = 1;
			if (flag)
			{
				Monitor.Exit(this.$STATIC$CheckRequestDelay$2001$LastTick$Init);
			}
		}
		IL_91:
		if (this.method_5())
		{
			goto IL_D3;
		}
		Thread.Sleep(100);
		IL_A0:
		if (!Operators.ConditionalCompareObjectGreater(DateAndTime.Now.Subtract(this.$STATIC$CheckRequestDelay$2001$LastTick).TotalMilliseconds, global::Globals.GetObjectValue(this.numDelay), false))
		{
			goto IL_91;
		}
		IL_D3:
		this.$STATIC$CheckRequestDelay$2001$LastTick = DateAndTime.Now;
	}

	// Token: 0x0600043D RID: 1085 RVA: 0x0001DE24 File Offset: 0x0001C024
	private void method_16(object sender, EventArgs e)
	{
		this.btnWorkerStart.Enabled = (Class23.smethod_13(this.txtURL.Text, false) && this.txtURL.Text.EndsWith("/") && !this.RunningWorker);
	}

	// Token: 0x0600043E RID: 1086 RVA: 0x00003D23 File Offset: 0x00001F23
	private void method_17(object sender, EventArgs e)
	{
		this.txtWebApps.ReadOnly = this.chkWebApps.Checked;
	}

	// Token: 0x0600043F RID: 1087 RVA: 0x00003D3B File Offset: 0x00001F3B
	private void method_18(object sender, CancelEventArgs e)
	{
		e.Cancel = (this.lstResult.SelectedItems.Count == 0);
		this.mnuShell.Visible = (this.lstResult.SelectedItems.Count == 1);
	}

	// Token: 0x06000440 RID: 1088 RVA: 0x0001DE74 File Offset: 0x0001C074
	private void method_19(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				int num = this.lstResult.SelectedItems.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (i > 0)
					{
						stringBuilder.AppendLine();
					}
					stringBuilder.Append(RuntimeHelpers.GetObjectValue(this.lstResult.SelectedItems[i]));
				}
				Clipboard.SetText(stringBuilder.ToString());
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
			}
		}
	}

	// Token: 0x06000441 RID: 1089 RVA: 0x0001DF0C File Offset: 0x0001C10C
	private void method_20(object sender, EventArgs e)
	{
		try
		{
			global::Globals.ShellUrl(Conversions.ToString(this.lstResult.SelectedItems[0]));
		}
		catch (Exception ex)
		{
			Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
		}
	}

	// Token: 0x06000442 RID: 1090 RVA: 0x0001DF64 File Offset: 0x0001C164
	private void method_21(object sender, EventArgs e)
	{
		try
		{
			if (Clipboard.ContainsText())
			{
				string text = Clipboard.GetText();
				if (Class23.smethod_13(text, false))
				{
					if (!text.EndsWith("/"))
					{
						int num = text.LastIndexOf("/");
						if (num > 0)
						{
							text = text.Substring(0, checked(num + 1));
						}
					}
					this.txtURL.Text = text;
				}
			}
		}
		catch (Exception ex)
		{
			Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
		}
	}

	// Token: 0x06000443 RID: 1091 RVA: 0x00003D74 File Offset: 0x00001F74
	[DebuggerHidden]
	[CompilerGenerated]
	private void method_22(object object_0)
	{
		this.method_13((LoginFinder.Class43)object_0);
	}

	// Token: 0x04000275 RID: 629
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bckWorker")]
	[CompilerGenerated]
	private BackgroundWorker backgroundWorker_0;

	// Token: 0x0400027C RID: 636
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("txtURL")]
	private ToolStripSpringTextBox toolStripSpringTextBox_0;

	// Token: 0x0400027D RID: 637
	private global::ThreadPool threadPool_0;

	// Token: 0x0400027E RID: 638
	private int int_0;

	// Token: 0x0400027F RID: 639
	private int int_1;

	// Token: 0x04000280 RID: 640
	private global::Globals.WebServer webServer_0;

	// Token: 0x04000281 RID: 641
	private static string string_0;

	// Token: 0x04000282 RID: 642
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int int_2;

	// Token: 0x04000283 RID: 643
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool bool_0;

	// Token: 0x04000284 RID: 644
	private DateTime $STATIC$CheckRequestDelay$2001$LastTick;

	// Token: 0x04000285 RID: 645
	private StaticLocalInitFlag $STATIC$CheckRequestDelay$2001$LastTick$Init;

	// Token: 0x0200006D RID: 109
	// (Invoke) Token: 0x06000447 RID: 1095
	private delegate void Delegate16(int iValue);

	// Token: 0x0200006E RID: 110
	// (Invoke) Token: 0x0600044B RID: 1099
	private delegate void Delegate17(string sMessage);

	// Token: 0x0200006F RID: 111
	// (Invoke) Token: 0x0600044F RID: 1103
	private delegate void Delegate18(string url);

	// Token: 0x02000070 RID: 112
	// (Invoke) Token: 0x06000453 RID: 1107
	private delegate bool Delegate19();

	// Token: 0x02000071 RID: 113
	private sealed class Class43
	{
		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000455 RID: 1109 RVA: 0x00003D82 File Offset: 0x00001F82
		// (set) Token: 0x06000456 RID: 1110 RVA: 0x00003D8A File Offset: 0x00001F8A
		public Thread Thread { get; set; }

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x00003D93 File Offset: 0x00001F93
		// (set) Token: 0x06000458 RID: 1112 RVA: 0x00003D9B File Offset: 0x00001F9B
		public string Page { get; set; }

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000459 RID: 1113 RVA: 0x00003DA4 File Offset: 0x00001FA4
		// (set) Token: 0x0600045A RID: 1114 RVA: 0x00003DAC File Offset: 0x00001FAC
		public string Url { get; set; }

		// Token: 0x04000286 RID: 646
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Thread thread_0;

		// Token: 0x04000287 RID: 647
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_0;

		// Token: 0x04000288 RID: 648
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_1;
	}
}
