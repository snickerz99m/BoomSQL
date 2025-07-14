using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Chilkat;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x02000069 RID: 105
[DesignerGenerated]
public partial class Analizer : Form
{
	// Token: 0x0600031E RID: 798 RVA: 0x00016E80 File Offset: 0x00015080
	public Analizer()
	{
		base.Load += this.Analizer_Load;
		this.toolStripSpringTextBox_0 = new ToolStripSpringTextBox(0);
		this.toolStripSpringTextBox_1 = new ToolStripSpringTextBox(0);
		this.toolStripControl_0 = new ToolStripControl(new NumericUpDown());
		this.toolStripSpringTextBox_2 = new ToolStripSpringTextBox(1);
		this.InitializeComponent();
		global::Globals.translate_0.Add(this, this.icontainer_0);
		global::Globals.AddMouseMoveForm(this);
		this.cmbUnionStyle.Items.Add(global::Globals.translate_0.GetStr(base.Name + ".Strings", 0, "Numeric"));
		this.cmbUnionStyle.Items.Add(global::Globals.translate_0.GetStr(base.Name + ".Strings", 1, "Hex"));
		this.cmbUnionStyle.Items.Add(global::Globals.translate_0.GetStr(base.Name + ".Strings", 2, "Null"));
		this.cmbUnionStyle.Items.Add(global::Globals.translate_0.GetStr(base.Name + ".Strings", 3, "Custom"));
		this.cmbUnionStyle.SelectedIndex = 0;
		this.toolStripControl_0.Control.AutoSize = false;
		this.toolStripControl_0.Control.Minimum = 1m;
		this.toolStripControl_0.Control.Maximum = 100m;
		this.toolStripControl_0.Value = 1m;
		this.toolStripControl_0.Alignment = ToolStripItemAlignment.Right;
		ToolStripControl toolStripControl;
		(toolStripControl = this.toolStripControl_0).Width = checked(toolStripControl.Width + 30);
		this.toolStripControl_0.Control.ContextMenuStrip = this.mnuCount;
		this.cmbUnionPosition.AutoSize = false;
		this.cmbUnionPosition.Width = 50;
		this.cmbUnionStyle.AutoSize = false;
		this.cmbUnionStyle.Width = 75;
		this.txtUnionStyle.AutoSize = false;
		this.txtUnionStyle.Width = this.cmbUnionStyle.Width;
		this.chkWafs.CheckOnClick = true;
		try
		{
			foreach (object value in global::Globals.GMain.lstAnalizerUnion.Items)
			{
				string item = Conversions.ToString(value);
				this.toolStripSpringTextBox_2.Items.Add(item);
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
		if (!this.toolStripSpringTextBox_2.Items.Contains("999999.9 union all select [t]--"))
		{
			this.toolStripSpringTextBox_2.Items.Insert(0, "999999.9 union all select [t]--");
		}
		this.toolStripSpringTextBox_2.SelectedItem = "999999.9 union all select [t]--";
		this.tslMain_1.Items.Insert(1, new ToolStripSeparator());
		this.tslMain_1.Items.Insert(2, this.toolStripSpringTextBox_0);
		this.tslMain_3.Items.Insert(3, new ToolStripSeparator());
		this.tslMain_3.Items.Insert(4, this.toolStripSpringTextBox_2);
		this.tslMain_3.Items.Insert(8, this.toolStripControl_0);
		this.tslMain_4.Items.Insert(2, this.toolStripSpringTextBox_1);
		this.toolStripSpringTextBox_2.Focus();
		this.tslMain_1.Focus();
		this.toolStripSpringTextBox_0.Focus();
		this.toolStripSpringTextBox_1.KeyDown += this.toolStripSpringTextBox_1_KeyDown;
		this.toolStripSpringTextBox_1.TextChanged += this.toolStripSpringTextBox_1_TextChanged;
		this.toolStripSpringTextBox_0.TextChanged += this.toolStripSpringTextBox_0_TextChanged;
		this.toolStripControl_0.ValueChanged += this.numUnionCount_ValueChanged;
		this.toolStripSpringTextBox_2.SelectedIndexChanged += this.numUnionCount_ValueChanged;
		this.mnuCount.Closing += this.method_12;
		this.mnuCount.ShowCheckMargin = true;
		this.method_2(this.wbBrowser);
	}

	// Token: 0x170000D2 RID: 210
	// (get) Token: 0x06000321 RID: 801 RVA: 0x00003420 File Offset: 0x00001620
	// (set) Token: 0x06000322 RID: 802 RVA: 0x00003428 File Offset: 0x00001628
	internal virtual ToolStrip tslMain_1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000D3 RID: 211
	// (get) Token: 0x06000323 RID: 803 RVA: 0x00003431 File Offset: 0x00001631
	// (set) Token: 0x06000324 RID: 804 RVA: 0x00018EE4 File Offset: 0x000170E4
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
			EventHandler value2 = new EventHandler(this.method_14);
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

	// Token: 0x170000D4 RID: 212
	// (get) Token: 0x06000325 RID: 805 RVA: 0x00003439 File Offset: 0x00001639
	// (set) Token: 0x06000326 RID: 806 RVA: 0x00003441 File Offset: 0x00001641
	internal virtual ToolStrip tslMain_4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000D5 RID: 213
	// (get) Token: 0x06000327 RID: 807 RVA: 0x0000344A File Offset: 0x0000164A
	// (set) Token: 0x06000328 RID: 808 RVA: 0x00018F28 File Offset: 0x00017128
	internal virtual ToolStripComboBox cmbUnionStyle
	{
		[CompilerGenerated]
		get
		{
			return this._cmbUnionStyle;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_9);
			ToolStripComboBox cmbUnionStyle = this._cmbUnionStyle;
			if (cmbUnionStyle != null)
			{
				cmbUnionStyle.SelectedIndexChanged -= value2;
			}
			this._cmbUnionStyle = value;
			cmbUnionStyle = this._cmbUnionStyle;
			if (cmbUnionStyle != null)
			{
				cmbUnionStyle.SelectedIndexChanged += value2;
			}
		}
	}

	// Token: 0x170000D6 RID: 214
	// (get) Token: 0x06000329 RID: 809 RVA: 0x00003452 File Offset: 0x00001652
	// (set) Token: 0x0600032A RID: 810 RVA: 0x00018F6C File Offset: 0x0001716C
	internal virtual ToolStripButton btnNext
	{
		[CompilerGenerated]
		get
		{
			return this._btnNext;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_17);
			ToolStripButton btnNext = this._btnNext;
			if (btnNext != null)
			{
				btnNext.Click -= value2;
			}
			this._btnNext = value;
			btnNext = this._btnNext;
			if (btnNext != null)
			{
				btnNext.Click += value2;
			}
		}
	}

	// Token: 0x170000D7 RID: 215
	// (get) Token: 0x0600032B RID: 811 RVA: 0x0000345A File Offset: 0x0000165A
	// (set) Token: 0x0600032C RID: 812 RVA: 0x00018FB0 File Offset: 0x000171B0
	internal virtual ToolStripButton btnBackward
	{
		[CompilerGenerated]
		get
		{
			return this._btnBackward;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_16);
			ToolStripButton btnBackward = this._btnBackward;
			if (btnBackward != null)
			{
				btnBackward.Click -= value2;
			}
			this._btnBackward = value;
			btnBackward = this._btnBackward;
			if (btnBackward != null)
			{
				btnBackward.Click += value2;
			}
		}
	}

	// Token: 0x170000D8 RID: 216
	// (get) Token: 0x0600032D RID: 813 RVA: 0x00003462 File Offset: 0x00001662
	// (set) Token: 0x0600032E RID: 814 RVA: 0x0000346A File Offset: 0x0000166A
	internal virtual ToolStrip tslMain_3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000D9 RID: 217
	// (get) Token: 0x0600032F RID: 815 RVA: 0x00003473 File Offset: 0x00001673
	// (set) Token: 0x06000330 RID: 816 RVA: 0x00018FF4 File Offset: 0x000171F4
	internal virtual ToolStripComboBox txtUnionStyle
	{
		[CompilerGenerated]
		get
		{
			return this._txtUnionStyle;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_9);
			ToolStripComboBox txtUnionStyle = this._txtUnionStyle;
			if (txtUnionStyle != null)
			{
				txtUnionStyle.TextChanged -= value2;
			}
			this._txtUnionStyle = value;
			txtUnionStyle = this._txtUnionStyle;
			if (txtUnionStyle != null)
			{
				txtUnionStyle.TextChanged += value2;
			}
		}
	}

	// Token: 0x170000DA RID: 218
	// (get) Token: 0x06000331 RID: 817 RVA: 0x0000347B File Offset: 0x0000167B
	// (set) Token: 0x06000332 RID: 818 RVA: 0x00003483 File Offset: 0x00001683
	internal virtual ToolStripSeparator ToolStripSeparator1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000DB RID: 219
	// (get) Token: 0x06000333 RID: 819 RVA: 0x0000348C File Offset: 0x0000168C
	// (set) Token: 0x06000334 RID: 820 RVA: 0x00019038 File Offset: 0x00017238
	internal virtual ContextMenuStrip mnuCount
	{
		[CompilerGenerated]
		get
		{
			return this._mnuCount;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			CancelEventHandler value2 = new CancelEventHandler(this.method_11);
			ContextMenuStrip mnuCount = this._mnuCount;
			if (mnuCount != null)
			{
				mnuCount.Opening -= value2;
			}
			this._mnuCount = value;
			mnuCount = this._mnuCount;
			if (mnuCount != null)
			{
				mnuCount.Opening += value2;
			}
		}
	}

	// Token: 0x170000DC RID: 220
	// (get) Token: 0x06000335 RID: 821 RVA: 0x00003494 File Offset: 0x00001694
	// (set) Token: 0x06000336 RID: 822 RVA: 0x0000349C File Offset: 0x0000169C
	internal virtual ToolStripMenuItem ToolStripMenuItem1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000DD RID: 221
	// (get) Token: 0x06000337 RID: 823 RVA: 0x000034A5 File Offset: 0x000016A5
	// (set) Token: 0x06000338 RID: 824 RVA: 0x000034AD File Offset: 0x000016AD
	internal virtual UxTabControl tbcMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000DE RID: 222
	// (get) Token: 0x06000339 RID: 825 RVA: 0x000034B6 File Offset: 0x000016B6
	// (set) Token: 0x0600033A RID: 826 RVA: 0x000034BE File Offset: 0x000016BE
	internal virtual TabPage tpWB { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000DF RID: 223
	// (get) Token: 0x0600033B RID: 827 RVA: 0x000034C7 File Offset: 0x000016C7
	// (set) Token: 0x0600033C RID: 828 RVA: 0x000034CF File Offset: 0x000016CF
	internal virtual TabPage tpSource { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000E0 RID: 224
	// (get) Token: 0x0600033D RID: 829 RVA: 0x000034D8 File Offset: 0x000016D8
	// (set) Token: 0x0600033E RID: 830 RVA: 0x000034E0 File Offset: 0x000016E0
	internal virtual StatusStrip stsMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000E1 RID: 225
	// (get) Token: 0x0600033F RID: 831 RVA: 0x000034E9 File Offset: 0x000016E9
	// (set) Token: 0x06000340 RID: 832 RVA: 0x000034F1 File Offset: 0x000016F1
	internal virtual TabPage tpSetup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000E2 RID: 226
	// (get) Token: 0x06000341 RID: 833 RVA: 0x000034FA File Offset: 0x000016FA
	// (set) Token: 0x06000342 RID: 834 RVA: 0x00003502 File Offset: 0x00001702
	internal virtual WebBrowser wbBrowser { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000E3 RID: 227
	// (get) Token: 0x06000343 RID: 835 RVA: 0x0000350B File Offset: 0x0000170B
	// (set) Token: 0x06000344 RID: 836 RVA: 0x0001907C File Offset: 0x0001727C
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
			DoWorkEventHandler value2 = new DoWorkEventHandler(this.method_22);
			ProgressChangedEventHandler value3 = new ProgressChangedEventHandler(this.method_23);
			RunWorkerCompletedEventHandler value4 = new RunWorkerCompletedEventHandler(this.method_24);
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

	// Token: 0x170000E4 RID: 228
	// (get) Token: 0x06000345 RID: 837 RVA: 0x00003513 File Offset: 0x00001713
	// (set) Token: 0x06000346 RID: 838 RVA: 0x0000351B File Offset: 0x0000171B
	internal virtual ToolStripStatusLabel lblStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000E5 RID: 229
	// (get) Token: 0x06000347 RID: 839 RVA: 0x00003524 File Offset: 0x00001724
	// (set) Token: 0x06000348 RID: 840 RVA: 0x000190F8 File Offset: 0x000172F8
	internal virtual ToolStripComboBox cmbUnionPosition
	{
		[CompilerGenerated]
		get
		{
			return this._cmbUnionPosition;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_15);
			ToolStripComboBox cmbUnionPosition = this._cmbUnionPosition;
			if (cmbUnionPosition != null)
			{
				cmbUnionPosition.SelectedIndexChanged -= value2;
			}
			this._cmbUnionPosition = value;
			cmbUnionPosition = this._cmbUnionPosition;
			if (cmbUnionPosition != null)
			{
				cmbUnionPosition.SelectedIndexChanged += value2;
			}
		}
	}

	// Token: 0x170000E6 RID: 230
	// (get) Token: 0x06000349 RID: 841 RVA: 0x0000352C File Offset: 0x0000172C
	// (set) Token: 0x0600034A RID: 842 RVA: 0x00003534 File Offset: 0x00001734
	internal virtual ToolStripSeparator ToolStripSeparator3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000E7 RID: 231
	// (get) Token: 0x0600034B RID: 843 RVA: 0x0000353D File Offset: 0x0000173D
	// (set) Token: 0x0600034C RID: 844 RVA: 0x00003545 File Offset: 0x00001745
	internal virtual TabPage tpRaw { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000E8 RID: 232
	// (get) Token: 0x0600034D RID: 845 RVA: 0x0000354E File Offset: 0x0000174E
	// (set) Token: 0x0600034E RID: 846 RVA: 0x00003556 File Offset: 0x00001756
	internal virtual ToolStripSeparator ToolStripSeparator5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000E9 RID: 233
	// (get) Token: 0x0600034F RID: 847 RVA: 0x0000355F File Offset: 0x0000175F
	// (set) Token: 0x06000350 RID: 848 RVA: 0x00003567 File Offset: 0x00001767
	internal virtual ToolStripSeparator ToolStripSeparator7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000EA RID: 234
	// (get) Token: 0x06000351 RID: 849 RVA: 0x00003570 File Offset: 0x00001770
	// (set) Token: 0x06000352 RID: 850 RVA: 0x00003578 File Offset: 0x00001778
	internal virtual ToolStripProgressBar prbStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000EB RID: 235
	// (get) Token: 0x06000353 RID: 851 RVA: 0x00003581 File Offset: 0x00001781
	// (set) Token: 0x06000354 RID: 852 RVA: 0x00003589 File Offset: 0x00001789
	internal virtual TextBox txtSourceCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000EC RID: 236
	// (get) Token: 0x06000355 RID: 853 RVA: 0x00003592 File Offset: 0x00001792
	// (set) Token: 0x06000356 RID: 854 RVA: 0x0000359A File Offset: 0x0000179A
	internal virtual TextBox txtRaw { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000ED RID: 237
	// (get) Token: 0x06000357 RID: 855 RVA: 0x000035A3 File Offset: 0x000017A3
	// (set) Token: 0x06000358 RID: 856 RVA: 0x000035AB File Offset: 0x000017AB
	internal virtual GroupBox grbLogin { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000EE RID: 238
	// (get) Token: 0x06000359 RID: 857 RVA: 0x000035B4 File Offset: 0x000017B4
	// (set) Token: 0x0600035A RID: 858 RVA: 0x000035BC File Offset: 0x000017BC
	internal virtual TextBox txtUserName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000EF RID: 239
	// (get) Token: 0x0600035B RID: 859 RVA: 0x000035C5 File Offset: 0x000017C5
	// (set) Token: 0x0600035C RID: 860 RVA: 0x000035CD File Offset: 0x000017CD
	internal virtual TextBox txtPassword { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000F0 RID: 240
	// (get) Token: 0x0600035D RID: 861 RVA: 0x000035D6 File Offset: 0x000017D6
	// (set) Token: 0x0600035E RID: 862 RVA: 0x000035DE File Offset: 0x000017DE
	internal virtual Label lblUser { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000F1 RID: 241
	// (get) Token: 0x0600035F RID: 863 RVA: 0x000035E7 File Offset: 0x000017E7
	// (set) Token: 0x06000360 RID: 864 RVA: 0x000035EF File Offset: 0x000017EF
	internal virtual Label lblPassword { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000F2 RID: 242
	// (get) Token: 0x06000361 RID: 865 RVA: 0x000035F8 File Offset: 0x000017F8
	// (set) Token: 0x06000362 RID: 866 RVA: 0x00003600 File Offset: 0x00001800
	internal virtual ToolStripSeparator ToolStripSeparator9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000F3 RID: 243
	// (get) Token: 0x06000363 RID: 867 RVA: 0x00003609 File Offset: 0x00001809
	// (set) Token: 0x06000364 RID: 868 RVA: 0x00003611 File Offset: 0x00001811
	internal virtual ToolStrip tslMain_2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000F4 RID: 244
	// (get) Token: 0x06000365 RID: 869 RVA: 0x0000361A File Offset: 0x0000181A
	// (set) Token: 0x06000366 RID: 870 RVA: 0x0001913C File Offset: 0x0001733C
	internal virtual ToolStripButton btnWorker
	{
		[CompilerGenerated]
		get
		{
			return this._btnWorker;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_20);
			ToolStripButton btnWorker = this._btnWorker;
			if (btnWorker != null)
			{
				btnWorker.Click -= value2;
			}
			this._btnWorker = value;
			btnWorker = this._btnWorker;
			if (btnWorker != null)
			{
				btnWorker.Click += value2;
			}
		}
	}

	// Token: 0x170000F5 RID: 245
	// (get) Token: 0x06000367 RID: 871 RVA: 0x00003622 File Offset: 0x00001822
	// (set) Token: 0x06000368 RID: 872 RVA: 0x0000362A File Offset: 0x0000182A
	internal virtual ToolStripLabel lblHttpStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000F6 RID: 246
	// (get) Token: 0x06000369 RID: 873 RVA: 0x00003633 File Offset: 0x00001833
	// (set) Token: 0x0600036A RID: 874 RVA: 0x0000363B File Offset: 0x0000183B
	internal virtual ToolStripSeparator tsSp1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000F7 RID: 247
	// (get) Token: 0x0600036B RID: 875 RVA: 0x00003644 File Offset: 0x00001844
	// (set) Token: 0x0600036C RID: 876 RVA: 0x0000364C File Offset: 0x0000184C
	internal virtual ToolStripSeparator tsSp2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000F8 RID: 248
	// (get) Token: 0x0600036D RID: 877 RVA: 0x00003655 File Offset: 0x00001855
	// (set) Token: 0x0600036E RID: 878 RVA: 0x0000365D File Offset: 0x0000185D
	internal virtual ToolStripLabel lblIP { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000F9 RID: 249
	// (get) Token: 0x0600036F RID: 879 RVA: 0x00003666 File Offset: 0x00001866
	// (set) Token: 0x06000370 RID: 880 RVA: 0x0000366E File Offset: 0x0000186E
	internal virtual ToolStripLabel tsSp4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000FA RID: 250
	// (get) Token: 0x06000371 RID: 881 RVA: 0x00003677 File Offset: 0x00001877
	// (set) Token: 0x06000372 RID: 882 RVA: 0x0000367F File Offset: 0x0000187F
	internal virtual ToolStripLabel lblCountry { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000FB RID: 251
	// (get) Token: 0x06000373 RID: 883 RVA: 0x00003688 File Offset: 0x00001888
	// (set) Token: 0x06000374 RID: 884 RVA: 0x00003690 File Offset: 0x00001890
	internal virtual ToolStripSeparator tsSp3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000FC RID: 252
	// (get) Token: 0x06000375 RID: 885 RVA: 0x00003699 File Offset: 0x00001899
	// (set) Token: 0x06000376 RID: 886 RVA: 0x000036A1 File Offset: 0x000018A1
	internal virtual ToolStripSeparator ToolStripSeparator6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000FD RID: 253
	// (get) Token: 0x06000377 RID: 887 RVA: 0x000036AA File Offset: 0x000018AA
	// (set) Token: 0x06000378 RID: 888 RVA: 0x000036B2 File Offset: 0x000018B2
	internal virtual ToolStripButton chkWafs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000FE RID: 254
	// (get) Token: 0x06000379 RID: 889 RVA: 0x000036BB File Offset: 0x000018BB
	// (set) Token: 0x0600037A RID: 890 RVA: 0x000036C3 File Offset: 0x000018C3
	internal virtual ToolStripSeparator ToolStripSeparator2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000FF RID: 255
	// (get) Token: 0x0600037B RID: 891 RVA: 0x000036CC File Offset: 0x000018CC
	// (set) Token: 0x0600037C RID: 892 RVA: 0x00019180 File Offset: 0x00017380
	internal virtual ToolStripButton chkIE
	{
		[CompilerGenerated]
		get
		{
			return this._chkIE;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_8);
			ToolStripButton chkIE = this._chkIE;
			if (chkIE != null)
			{
				chkIE.Click -= value2;
			}
			this._chkIE = value;
			chkIE = this._chkIE;
			if (chkIE != null)
			{
				chkIE.Click += value2;
			}
		}
	}

	// Token: 0x17000100 RID: 256
	// (get) Token: 0x0600037D RID: 893 RVA: 0x000036D4 File Offset: 0x000018D4
	// (set) Token: 0x0600037E RID: 894 RVA: 0x000036DC File Offset: 0x000018DC
	internal virtual ToolStripSeparator ToolStripSeparator4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000101 RID: 257
	// (get) Token: 0x0600037F RID: 895 RVA: 0x000036E5 File Offset: 0x000018E5
	// (set) Token: 0x06000380 RID: 896 RVA: 0x000036ED File Offset: 0x000018ED
	internal virtual ToolStripButton chkFlowRedirects { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000102 RID: 258
	// (get) Token: 0x06000381 RID: 897 RVA: 0x000036F6 File Offset: 0x000018F6
	// (set) Token: 0x06000382 RID: 898 RVA: 0x000191C4 File Offset: 0x000173C4
	internal virtual ToolStripButton btnClearForm
	{
		[CompilerGenerated]
		get
		{
			return this._btnClearForm;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_7);
			ToolStripButton btnClearForm = this._btnClearForm;
			if (btnClearForm != null)
			{
				btnClearForm.Click -= value2;
			}
			this._btnClearForm = value;
			btnClearForm = this._btnClearForm;
			if (btnClearForm != null)
			{
				btnClearForm.Click += value2;
			}
		}
	}

	// Token: 0x17000103 RID: 259
	// (get) Token: 0x06000383 RID: 899 RVA: 0x000036FE File Offset: 0x000018FE
	// (set) Token: 0x06000384 RID: 900 RVA: 0x00003706 File Offset: 0x00001906
	internal virtual ToolStripSeparator tsSp5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000104 RID: 260
	// (get) Token: 0x06000385 RID: 901 RVA: 0x0000370F File Offset: 0x0000190F
	// (set) Token: 0x06000386 RID: 902 RVA: 0x00019208 File Offset: 0x00017408
	internal virtual ToolStripButton btnGoToDumper
	{
		[CompilerGenerated]
		get
		{
			return this._btnGoToDumper;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_18);
			ToolStripButton btnGoToDumper = this._btnGoToDumper;
			if (btnGoToDumper != null)
			{
				btnGoToDumper.Click -= value2;
			}
			this._btnGoToDumper = value;
			btnGoToDumper = this._btnGoToDumper;
			if (btnGoToDumper != null)
			{
				btnGoToDumper.Click += value2;
			}
		}
	}

	// Token: 0x17000105 RID: 261
	// (get) Token: 0x06000387 RID: 903 RVA: 0x00003717 File Offset: 0x00001917
	// (set) Token: 0x06000388 RID: 904 RVA: 0x0000371F File Offset: 0x0000191F
	internal virtual ToolStripSeparator btnGoToDumperSP { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000106 RID: 262
	// (get) Token: 0x06000389 RID: 905 RVA: 0x00003728 File Offset: 0x00001928
	// (set) Token: 0x0600038A RID: 906 RVA: 0x00003730 File Offset: 0x00001930
	internal virtual GroupBox grbSetup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000107 RID: 263
	// (get) Token: 0x0600038B RID: 907 RVA: 0x00003739 File Offset: 0x00001939
	// (set) Token: 0x0600038C RID: 908 RVA: 0x00003741 File Offset: 0x00001941
	internal virtual CheckBox chkBypassProxy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000108 RID: 264
	// (get) Token: 0x0600038D RID: 909 RVA: 0x0000374A File Offset: 0x0000194A
	// (set) Token: 0x0600038E RID: 910 RVA: 0x00003752 File Offset: 0x00001952
	internal virtual ImageList ImageList1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x0600038F RID: 911 RVA: 0x0001924C File Offset: 0x0001744C
	private void method_0(string string_0)
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
			if (!this.stsMain.InvokeRequired)
			{
				goto IL_3F;
			}
			IL_19:
			num2 = 3;
			this.stsMain.Invoke(new Analizer.Delegate15(this.method_0), new object[]
			{
				string_0
			});
			goto IL_4D;
			IL_3F:
			num2 = 5;
			this.lblStatus.Text = string_0;
			IL_4D:
			goto IL_C0;
			IL_4F:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_79:
			goto IL_B5;
			IL_7B:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_93:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_7B;
		}
		IL_B5:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_C0:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000390 RID: 912 RVA: 0x00019334 File Offset: 0x00017534
	private void method_1(bool bool_1)
	{
		this.prbStatus.Visible = !bool_1;
		this.prbStatus.Style = ProgressBarStyle.Marquee;
		this.prbStatus.Value = 0;
		this.tslMain_1.Enabled = bool_1;
		this.tslMain_3.Enabled = bool_1;
		this.tslMain_4.Enabled = bool_1;
		this.btnWorker.Enabled = true;
		if (bool_1)
		{
			this.btnWorker.Image = Class6.Run_16x_24;
			this.btnWorker.Text = global::Globals.translate_0.GetStr(base.Name + ".Strings", 4, "Load");
		}
		else
		{
			this.wbBrowser.DocumentStream = null;
			this.wbBrowser.DocumentText = "";
			this.txtSourceCode.Text = "";
			this.txtRaw.Text = "";
			this.btnWorker.Image = Class6.Stop_16x_24;
			this.btnWorker.Text = global::Globals.translate_0.GetStr(base.Name + ".Strings", 5, "Stop");
			this.lblHttpStatus.Text = "";
			this.lblIP.Text = "";
			this.lblIP.Image = null;
			this.lblCountry.Text = "";
			this.tsSp4.Text = "";
		}
		this.tsSp1.Visible = !string.IsNullOrEmpty(this.lblIP.Text);
		this.tsSp2.Visible = !string.IsNullOrEmpty(this.lblIP.Text);
		this.tsSp3.Visible = !string.IsNullOrEmpty(this.lblIP.Text);
		this.tsSp4.Visible = !string.IsNullOrEmpty(this.lblIP.Text);
		this.tsSp5.Visible = !string.IsNullOrEmpty(this.lblIP.Text);
	}

	// Token: 0x06000391 RID: 913 RVA: 0x00019534 File Offset: 0x00017734
	public void SaveSettings()
	{
		this.txtSourceCode.Text = "";
		this.txtRaw.Text = "";
		Class50.smethod_4(base.Name, "txtURL", this.toolStripSpringTextBox_0.Text, null);
		Class50.smethod_4(base.Name, "txtURL_Out", this.toolStripSpringTextBox_1.Text, null);
		Class50.smethod_4(base.Name, "numUnionCount", Conversions.ToString(this.toolStripControl_0.Value), null);
		Class50.smethod_4(base.Name, "cmbUnion", this.toolStripSpringTextBox_2.Text, null);
		Class50.smethod_3(this, null);
	}

	// Token: 0x06000392 RID: 914 RVA: 0x000195E0 File Offset: 0x000177E0
	public void LoadSettings()
	{
		this.toolStripSpringTextBox_0.Text = Class50.smethod_5(base.Name, "txtURL", "", null);
		this.toolStripSpringTextBox_1.Text = Class50.smethod_5(base.Name, "txtURL_Out", "", null);
		this.toolStripControl_0.Text = Conversions.ToString(Conversions.ToInteger(Class50.smethod_5(base.Name, "numUnionCount", "1", null)));
		if (this.toolStripSpringTextBox_2.Items.Contains(Class50.smethod_5(base.Name, "cmbUnion", "", null)))
		{
			this.toolStripSpringTextBox_2.SelectedItem = Class50.smethod_5(base.Name, "cmbUnion", "", null);
		}
		Class50.smethod_2(this, null);
	}

	// Token: 0x06000393 RID: 915 RVA: 0x0000375B File Offset: 0x0000195B
	private void Analizer_Load(object sender, EventArgs e)
	{
		this.method_0("");
		this.method_1(false);
		this.method_1(true);
		base.KeyPreview = true;
	}

	// Token: 0x06000394 RID: 916 RVA: 0x000196AC File Offset: 0x000178AC
	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		bool flag;
		if (base.Visible)
		{
			switch (keyData)
			{
			case Keys.F5:
				this.method_20(null, null);
				flag = true;
				break;
			case Keys.F7:
				if (!this.bool_0)
				{
					this.method_16(null, null);
					flag = true;
				}
				break;
			case Keys.F8:
				if (!this.bool_0)
				{
					this.method_17(null, null);
					flag = true;
				}
				break;
			}
		}
		return flag || base.ProcessCmdKey(ref msg, keyData);
	}

	// Token: 0x06000395 RID: 917 RVA: 0x0000377D File Offset: 0x0000197D
	private void method_2(WebBrowser webBrowser_0)
	{
		webBrowser_0.ScriptErrorsSuppressed = true;
		webBrowser_0.DocumentCompleted += this.method_5;
		webBrowser_0.StatusTextChanged += this.method_4;
		webBrowser_0.ProgressChanged += this.method_3;
	}

	// Token: 0x06000396 RID: 918 RVA: 0x00019728 File Offset: 0x00017928
	private void method_3(object sender, WebBrowserProgressChangedEventArgs e)
	{
		if (e.CurrentProgress > 0L && !Conversions.ToBoolean(Operators.NotObject(global::Globals.GetObjectValue(this.chkIE))) && this.bool_0 && e.CurrentProgress <= e.MaximumProgress)
		{
			int num = checked((int)Math.Round(Math.Round((double)(100L * e.CurrentProgress) / (double)e.MaximumProgress)));
			if (this.prbStatus.Style == ProgressBarStyle.Marquee & (num > 0 & num < 100))
			{
				this.prbStatus.Style = ProgressBarStyle.Blocks;
			}
			this.prbStatus.Value = num;
			if (e.CurrentProgress > 0L & num < 100)
			{
				this.method_0(global::Globals.translate_0.GetStr(base.Name + ".Strings", 7, "Downloading") + Conversions.ToString(num) + " %");
			}
			else
			{
				this.method_0(global::Globals.translate_0.GetStr(base.Name + ".Strings", 7, "Downloading"));
			}
		}
	}

	// Token: 0x06000397 RID: 919 RVA: 0x00019844 File Offset: 0x00017A44
	private void method_4(object sender, EventArgs e)
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
			if (string.IsNullOrEmpty(this.wbBrowser.DocumentText))
			{
				goto IL_80;
			}
			IL_21:
			num2 = 3;
			if (this.wbBrowser.DocumentText.StartsWith("<HTML></HTML>") || this.wbBrowser.DocumentText.Length < 15)
			{
				goto IL_80;
			}
			IL_56:
			num2 = 4;
			if (string.IsNullOrEmpty(this.wbBrowser.StatusText))
			{
				goto IL_80;
			}
			IL_6D:
			num2 = 5;
			this.method_0(this.wbBrowser.StatusText);
			IL_80:
			goto IL_FB;
			IL_82:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_B4:
			goto IL_F0;
			IL_B6:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_CE:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_B6;
		}
		IL_F0:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_FB:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000398 RID: 920 RVA: 0x00019964 File Offset: 0x00017B64
	private void method_5(object sender, WebBrowserDocumentCompletedEventArgs e)
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
			this.txtSourceCode.Text = this.wbBrowser.DocumentText.Replace("\n", "\r\n");
			IL_31:
			num2 = 3;
			this.txtRaw.Text = "";
			IL_43:
			num2 = 4;
			this.tpWB.Text = this.wbBrowser.DocumentTitle;
			IL_5B:
			num2 = 5;
			((WebBrowser)sender).Document.Window.Error += this.method_6;
			IL_7E:
			goto IL_ED;
			IL_80:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_A6:
			goto IL_E2;
			IL_A8:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_C0:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_A8;
		}
		IL_E2:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_ED:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000399 RID: 921 RVA: 0x000037BC File Offset: 0x000019BC
	private void method_6(object sender, HtmlElementErrorEventArgs e)
	{
		e.Handled = true;
	}

	// Token: 0x0600039A RID: 922 RVA: 0x00019A78 File Offset: 0x00017C78
	private void method_7(object sender, EventArgs e)
	{
		global::Globals.GMain.pnlAnalizer.SuspendLayout();
		global::Globals.LockWindowUpdateForced(false);
		global::Globals.GMain.method_61(false);
		global::Globals.GMain.method_58(false);
		global::Globals.LockWindowUpdateForced(true);
		global::Globals.GMain.pnlAnalizer.ResumeLayout();
		global::Globals.GMain.pnlAnalizer.Refresh();
	}

	// Token: 0x0600039B RID: 923 RVA: 0x000037C5 File Offset: 0x000019C5
	private void method_8(object sender, EventArgs e)
	{
		this.grbLogin.Enabled = !this.chkIE.Checked;
		this.chkFlowRedirects.Enabled = !this.chkIE.Checked;
	}

	// Token: 0x0600039C RID: 924 RVA: 0x000037F9 File Offset: 0x000019F9
	private void toolStripSpringTextBox_1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			this.method_21();
		}
	}

	// Token: 0x0600039D RID: 925 RVA: 0x0000380D File Offset: 0x00001A0D
	private void method_9(object sender, EventArgs e)
	{
		this.txtUnionStyle.Enabled = (this.cmbUnionStyle.SelectedIndex == 3);
		this.method_15(null, null);
	}

	// Token: 0x0600039E RID: 926 RVA: 0x00003830 File Offset: 0x00001A30
	private void method_10(object sender, EventArgs e)
	{
		this.chkFlowRedirects.Enabled = !this.chkIE.Checked;
	}

	// Token: 0x0600039F RID: 927 RVA: 0x00019AD8 File Offset: 0x00017CD8
	private void method_11(object sender, CancelEventArgs e)
	{
		checked
		{
			if (decimal.Compare(this.toolStripControl_0.Value, 1m) <= 0)
			{
				e.Cancel = true;
			}
			else if (decimal.Compare(this.toolStripControl_0.Value, new decimal(this.mnuCount.Items.Count - 2)) != 0)
			{
				this.mnuCount.Items.Clear();
				this.mnuCount.ShowCheckMargin = false;
				int num = Convert.ToInt32(this.toolStripControl_0.Value);
				ToolStripMenuItem toolStripMenuItem;
				for (int i = 1; i <= num; i++)
				{
					toolStripMenuItem = (ToolStripMenuItem)this.mnuCount.Items.Add(i.ToString());
					toolStripMenuItem.Click += this.method_13;
				}
				toolStripMenuItem.Click += this.method_13;
			}
		}
	}

	// Token: 0x060003A0 RID: 928 RVA: 0x000027EC File Offset: 0x000009EC
	private void method_12(object sender, ToolStripDropDownClosingEventArgs e)
	{
	}

	// Token: 0x060003A1 RID: 929 RVA: 0x00019BB4 File Offset: 0x00017DB4
	private void method_13(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(sender, null, "text", new object[0], null, null, null))))
		{
			List<int> list = new List<int>();
			list.Add(Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "text", new object[0], null, null, null)));
			this.toolStripSpringTextBox_1.Text = this.method_19(list);
		}
	}

	// Token: 0x060003A2 RID: 930 RVA: 0x00019C1C File Offset: 0x00017E1C
	private void method_14(object sender, EventArgs e)
	{
		try
		{
			if (Clipboard.ContainsText())
			{
				string text = Clipboard.GetText().Trim();
				if (Class23.smethod_13(text, false))
				{
					this.toolStripSpringTextBox_0.Text = text;
				}
			}
		}
		catch (Exception ex)
		{
			Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
		}
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x0000384B File Offset: 0x00001A4B
	private void toolStripSpringTextBox_1_TextChanged(object sender, EventArgs e)
	{
		this.btnGoToDumper.Enabled = this.toolStripSpringTextBox_1.Text.Contains("[t]");
		this.btnGoToDumperSP.Enabled = this.btnGoToDumper.Visible;
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x00019C80 File Offset: 0x00017E80
	private void toolStripSpringTextBox_0_TextChanged(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				string text = this.toolStripSpringTextBox_0.Text;
				this.cmbUnionPosition.Items.Clear();
				this.wbBrowser.DocumentStream = null;
				this.wbBrowser.DocumentText = "";
				this.txtSourceCode.Text = "";
				this.txtRaw.Text = "";
				if (Class23.smethod_13(text, false))
				{
					List<string> list = Class23.smethod_17(text, "[t]", false, false);
					int count = list.Count;
					for (int i = 1; i <= count; i++)
					{
						this.cmbUnionPosition.Items.Add(i);
					}
					this.cmbUnionPosition.SelectedIndex = 0;
				}
				this.method_15(null, null);
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
			}
		}
	}

	// Token: 0x060003A5 RID: 933 RVA: 0x00003883 File Offset: 0x00001A83
	public void numUnionCount_ValueChanged(object sender, EventArgs e)
	{
		this.btnBackward.Enabled = (decimal.Compare(this.toolStripControl_0.Value, 1m) > 0);
		this.method_15(null, null);
	}

	// Token: 0x060003A6 RID: 934 RVA: 0x00019D6C File Offset: 0x00017F6C
	private void method_15(object sender, EventArgs e)
	{
		try
		{
			this.toolStripSpringTextBox_1.Text = this.method_19(new List<int>());
			this.btnBackward.Enabled = (this.cmbUnionPosition.Items.Count > 0 & decimal.Compare(this.toolStripControl_0.Value, 1m) > 0);
			this.btnNext.Enabled = (this.cmbUnionPosition.Items.Count > 0);
			this.btnWorker.Enabled = (this.cmbUnionPosition.Items.Count > 0);
		}
		catch (Exception ex)
		{
			Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
		}
	}

	// Token: 0x060003A7 RID: 935 RVA: 0x00019E34 File Offset: 0x00018034
	private void method_16(object sender, EventArgs e)
	{
		if (decimal.Compare(this.toolStripControl_0.Value, 0m) > 0)
		{
			ToolStripControl toolStripControl;
			(toolStripControl = this.toolStripControl_0).Value = decimal.Subtract(toolStripControl.Value, 1m);
			this.method_21();
		}
	}

	// Token: 0x060003A8 RID: 936 RVA: 0x00019E80 File Offset: 0x00018080
	private void method_17(object sender, EventArgs e)
	{
		if (decimal.Compare(this.toolStripControl_0.Value, 101m) < 0)
		{
			ToolStripControl toolStripControl;
			(toolStripControl = this.toolStripControl_0).Value = decimal.Add(toolStripControl.Value, 1m);
			this.method_21();
		}
	}

	// Token: 0x060003A9 RID: 937 RVA: 0x00019ED0 File Offset: 0x000180D0
	private void method_18(object sender, EventArgs e)
	{
		if (!global::Globals.GMain.DumperForm.Boolean_0)
		{
			if (global::Globals.GMain.bool_3)
			{
				global::Globals.GMain.mdiTabControl.SelectItem(2);
			}
			else
			{
				global::Globals.GMain.twMain.SelectedNode = global::Globals.GMain.treeNode_3;
			}
			global::Globals.GMain.DumperForm.method_76();
			global::Globals.GMain.DumperForm.txtURL.Text = this.toolStripSpringTextBox_1.Text;
			if (!this.toolStripSpringTextBox_1.Text.Contains(".asp"))
			{
				global::Globals.GMain.DumperForm.cmbSqlType.Text = Conversions.ToString(global::Globals.GMain.DumperForm.cmbSqlType.Items[0]);
			}
			else
			{
				global::Globals.GMain.DumperForm.cmbSqlType.Text = Conversions.ToString(global::Globals.GMain.DumperForm.cmbSqlType.Items[2]);
			}
			global::Globals.GMain.DumperForm.method_90(null, null);
		}
	}

	// Token: 0x060003AA RID: 938 RVA: 0x00019FEC File Offset: 0x000181EC
	private string method_19(List<int> list_0)
	{
		checked
		{
			string result;
			try
			{
				if (this.cmbUnionPosition.Items.Count > 0)
				{
					string text = "";
					int num = Convert.ToInt32(this.toolStripControl_0.Value);
					for (int i = 1; i <= num; i++)
					{
						if (!string.IsNullOrEmpty(text))
						{
							text += ",";
						}
						if (list_0.Contains(i))
						{
							text += "[t]";
						}
						else
						{
							switch (this.cmbUnionStyle.SelectedIndex)
							{
							case 0:
								text += Conversions.ToString(i);
								break;
							case 1:
								text += Class23.smethod_20(i.ToString());
								break;
							case 2:
								text += "null";
								break;
							case 3:
								if (list_0.Count == 0)
								{
									text += Class23.smethod_20(this.txtUnionStyle.Text.Replace("[t]", Conversions.ToString(i)));
								}
								else
								{
									text += Conversions.ToString(i);
								}
								break;
							}
						}
					}
					string str = "";
					string text2 = this.toolStripSpringTextBox_2.Text;
					if (text2.EndsWith("--"))
					{
						str = "--";
						text2 = text2.Remove(text2.Length - 2);
					}
					text2 = text2.Replace("[t]", text) + str;
					List<string> list = Class23.smethod_17(this.toolStripSpringTextBox_0.Text, text2, false, false);
					if (this.cmbUnionPosition.SelectedIndex + 1 > list.Count)
					{
						result = "";
					}
					else
					{
						result = list[this.cmbUnionPosition.SelectedIndex];
					}
				}
				else
				{
					result = "";
				}
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}
	}

	// Token: 0x060003AB RID: 939 RVA: 0x000038B0 File Offset: 0x00001AB0
	private void method_20(object sender, EventArgs e)
	{
		if (this.bool_0)
		{
			this.bckWorker.CancelAsync();
			this.btnWorker.Enabled = false;
		}
		else
		{
			this.method_21();
		}
	}

	// Token: 0x060003AC RID: 940 RVA: 0x0001A1E0 File Offset: 0x000183E0
	private void method_21()
	{
		if (!this.bool_0)
		{
			if (Class23.smethod_13(this.toolStripSpringTextBox_0.Text, true))
			{
				this.method_1(false);
				this.bckWorker.RunWorkerAsync();
			}
			else
			{
				this.method_0(global::Globals.translate_0.GetStr("Dumper.Strings", 61, "Invalid URL"));
			}
		}
	}

	// Token: 0x060003AD RID: 941 RVA: 0x0001A238 File Offset: 0x00018438
	private static MemoryStream smethod_0(string string_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		StreamWriter streamWriter = new StreamWriter(memoryStream);
		streamWriter.Write(string_0);
		streamWriter.Flush();
		memoryStream.Position = 0L;
		return memoryStream;
	}

	// Token: 0x060003AE RID: 942 RVA: 0x0001A26C File Offset: 0x0001846C
	private void method_22(object sender, DoWorkEventArgs e)
	{
		string string_ = "";
		this.bool_0 = true;
		this.method_0(global::Globals.translate_0.GetStr(base.Name + ".Strings", 6, "Connecting.."));
		checked
		{
			try
			{
				string text = Conversions.ToString(global::Globals.GetObjectValue(this.toolStripSpringTextBox_1));
				Http http;
				if (Conversions.ToBoolean(global::Globals.GetObjectValue(this.chkIE)))
				{
					this.wbBrowser.Navigate(text);
					do
					{
						Thread.Sleep(100);
						if (this.bckWorker.CancellationPending)
						{
							e.Result = global::Globals.translate_0.GetStr(base.Name + ".Strings", 8, "Worker Canceled");
							this.wbBrowser.Stop();
						}
						else
						{
							this.bckWorker.ReportProgress(0);
						}
					}
					while (this.wbBrowser.IsBusy | this.bckWorker.CancellationPending);
				}
				else
				{
					http = new Http();
					e.Result = "";
					Stopwatch stopwatch = Stopwatch.StartNew();
					if (this.chkWafs.Checked)
					{
						text = Class23.smethod_15(text);
					}
					http.UserAgent = Conversions.ToString(global::Globals.GetObjectValue(global::Globals.GMain.txtUserAgent));
					http.Accept = Conversions.ToString(global::Globals.GetObjectValue(global::Globals.GMain.txtAccept));
					http.ConnectTimeout = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.numHTTPTimeout));
					http.ReadTimeout = http.ConnectTimeout;
					http.FollowRedirects = Conversions.ToBoolean(global::Globals.GetObjectValue(this.chkFlowRedirects));
					http.AutoAddHostHeader = true;
					http.AllowGzip = true;
					http.SendCookies = true;
					http.SaveCookies = true;
					http.CookieDir = "memory";
					http.UseIEProxy = false;
					http.MaxConnections = 500;
					http.MaxResponseSize = 5242880U;
					http.EnableEvents = true;
					http.KeepEventLog = false;
					http.Login = Conversions.ToString(global::Globals.GetObjectValue(this.txtUserName));
					http.Password = Conversions.ToString(global::Globals.GetObjectValue(this.txtPassword));
					if (Conversions.ToBoolean(Operators.NotObject(global::Globals.GetObjectValue(this.chkBypassProxy))))
					{
						global::Globals.G_SOCKS.method_12(ref http, ref string_);
					}
					long long_ = global::Globals.GMain.method_207(text, string_);
					Task task = http.QuickGetObjAsync(text);
					if (http.LastMethodSuccess)
					{
						if (task.Run())
						{
							do
							{
								task.SleepMs(100);
								if (this.bckWorker.CancellationPending)
								{
									e.Result = global::Globals.translate_0.GetStr(base.Name + ".Strings", 8, "Worker Canceled");
									task.Cancel();
								}
								else
								{
									this.bckWorker.ReportProgress(task.PercentDone);
								}
							}
							while (!(task.Finished | this.bckWorker.CancellationPending));
							if (task.StatusInt == 7)
							{
								HttpResponse httpResponse = new HttpResponse();
								if (httpResponse.LoadTaskResult(task))
								{
									System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
									if (!string.IsNullOrEmpty(http.LastHeader))
									{
										stringBuilder.Append(http.LastHeader);
										stringBuilder.AppendLine();
										stringBuilder.Append(new string('-', 50));
										stringBuilder.AppendLine();
									}
									stringBuilder.Append(httpResponse.Header);
									stringBuilder.AppendLine();
									if (httpResponse.NumCookies > 0)
									{
										stringBuilder.Append(new string('-', 50));
										stringBuilder.AppendLine();
										int num = httpResponse.NumCookies - 1;
										for (int i = 0; i <= num; i++)
										{
											stringBuilder.AppendLine("Name:" + httpResponse.GetCookieName(i));
											stringBuilder.Append(", Value:" + httpResponse.GetCookieValue(i));
											stringBuilder.Append(", Expires:" + httpResponse.GetCookieExpiresStr(i));
										}
									}
									global::Globals.SetObjectValue(this.txtRaw, stringBuilder.ToString());
									global::Globals.SetObjectValue(this.txtSourceCode, httpResponse.BodyStr);
									global::Globals.SetObjectValue(this.wbBrowser, httpResponse.BodyStr);
									if (httpResponse.StatusCode > 0 & httpResponse.StatusCode != 999999)
									{
										HttpStatusCode statusCode;
										try
										{
											statusCode = (HttpStatusCode)httpResponse.StatusCode;
										}
										catch (Exception ex)
										{
										}
										if (Operators.CompareString(httpResponse.StatusCode.ToString(), statusCode.ToString(), false) == 0)
										{
											string text2 = text2;
										}
										else
										{
											string text2 = text2 + " " + statusCode.ToString();
										}
									}
									else
									{
										string text2 = "Unknown";
									}
									int length = httpResponse.BodyStr.Length;
									string text3 = "";
									string v = "";
									Image v2 = null;
									string text4 = Class23.smethod_12(text);
									if (global::Globals.G_DataGP.CountryCodeExist(text4))
									{
										v = global::Globals.G_DataGP.CountryNameByCode(text4);
										v2 = global::Globals.GMain.imgData.Images[text4 + ".png"];
									}
									else
									{
										text3 = global::Globals.GMain.method_85(Class23.smethod_11(text)).ToString();
										if (!string.IsNullOrEmpty(text3))
										{
											DataGP g_DataGP = global::Globals.G_DataGP;
											string sIP = text3;
											string text5 = "";
											g_DataGP.Lookup(sIP, ref v, ref v2, ref text5, true);
										}
									}
									global::Globals.SetObjectValue(this.lblIP, text3);
									global::Globals.SetObjectValue(this.lblHttpStatus, httpResponse.StatusLine);
									global::Globals.SetObjectValue(this.lblCountry, v);
									global::Globals.SetObjectValue(this.lblCountry, v2);
									global::Globals.SetObjectValue(this.tsSp4, global::Globals.FormatBytes((double)httpResponse.BodyStr.Length));
								}
								else
								{
									e.Result = httpResponse.LastErrorText;
								}
							}
							else
							{
								e.Result = task.Status;
							}
						}
						else
						{
							e.Result = task.LastErrorText;
						}
					}
					else
					{
						e.Result = http.LastErrorText;
					}
				}
				http.CloseAllConnections();
			}
			catch (Exception ex2)
			{
				e.Result = ex2.ToString();
			}
			finally
			{
				try
				{
					global::Globals.SetObjectValue(this.tpWB, this.wbBrowser.DocumentTitle);
				}
				catch (Exception ex3)
				{
				}
				if (Conversions.ToBoolean(Operators.NotObject(global::Globals.GetObjectValue(this.chkIE))))
				{
					Stopwatch stopwatch;
					stopwatch.Stop();
					string text2;
					if (string.IsNullOrEmpty(text2) && !string.IsNullOrEmpty(Conversions.ToString(e.Result)))
					{
						text2 = Conversions.ToString(e.Result);
					}
					string text;
					long long_;
					int length;
					global::Globals.GMain.method_206(long_, text, global::Globals.FormatBytes((double)length), Strings.FormatNumber(stopwatch.Elapsed.TotalMilliseconds / 1000.0, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault), text2, "");
					Http http;
					http.Dispose();
				}
				this.bool_0 = false;
			}
		}
	}

	// Token: 0x060003AF RID: 943 RVA: 0x0001A98C File Offset: 0x00018B8C
	private void method_23(object sender, ProgressChangedEventArgs e)
	{
		if (this.prbStatus.Style == ProgressBarStyle.Marquee & (e.ProgressPercentage > 0 & e.ProgressPercentage < 100))
		{
			this.prbStatus.Style = ProgressBarStyle.Blocks;
		}
		this.prbStatus.Value = e.ProgressPercentage;
		if (e.ProgressPercentage > 0 & e.ProgressPercentage < 100)
		{
			this.method_0(global::Globals.translate_0.GetStr(base.Name + ".Strings", 7, "Downloading") + Conversions.ToString(e.ProgressPercentage) + " %");
		}
		else
		{
			this.method_0(global::Globals.translate_0.GetStr(base.Name + ".Strings", 7, "Downloading"));
		}
	}

	// Token: 0x060003B0 RID: 944 RVA: 0x0001AA54 File Offset: 0x00018C54
	private void method_24(object sender, RunWorkerCompletedEventArgs e)
	{
		if (!string.IsNullOrEmpty(Conversions.ToString(e.Result)))
		{
			this.txtSourceCode.Text = Conversions.ToString(e.Result);
		}
		this.method_1(true);
		this.method_0(global::Globals.translate_0.GetStr(base.Name + ".Strings", 9, "Done"));
	}

	// Token: 0x0400021C RID: 540
	[AccessedThroughProperty("bckWorker")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private BackgroundWorker backgroundWorker_0;

	// Token: 0x04000241 RID: 577
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ImageList1")]
	[CompilerGenerated]
	private ImageList imageList_0;

	// Token: 0x04000242 RID: 578
	private ToolStripSpringTextBox toolStripSpringTextBox_0;

	// Token: 0x04000243 RID: 579
	private ToolStripSpringTextBox toolStripSpringTextBox_1;

	// Token: 0x04000244 RID: 580
	private ToolStripControl toolStripControl_0;

	// Token: 0x04000245 RID: 581
	private ToolStripSpringTextBox toolStripSpringTextBox_2;

	// Token: 0x04000246 RID: 582
	private bool bool_0;

	// Token: 0x0200006A RID: 106
	// (Invoke) Token: 0x060003B4 RID: 948
	private delegate void Delegate15(string sMessage);
}
