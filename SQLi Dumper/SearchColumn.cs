using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DataBase;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x020000BA RID: 186
[DesignerGenerated]
public partial class SearchColumn : Form
{
	// Token: 0x06000AB7 RID: 2743 RVA: 0x000066F1 File Offset: 0x000048F1
	public SearchColumn()
	{
		base.FormClosing += this.SearchColumn_FormClosing;
		this.CanClose = true;
		this.InitializeComponent();
		global::Globals.AddMouseMoveForm(this);
		global::Globals.translate_0.Add(this, this.icontainer_0);
	}

	// Token: 0x06000AB8 RID: 2744 RVA: 0x00042378 File Offset: 0x00040578
	public SearchColumn(bool bExploiter, DataGridView url)
	{
		base.FormClosing += this.SearchColumn_FormClosing;
		this.CanClose = true;
		this.InitializeComponent();
		this.lvwData.ShowGroups = true;
		this.lvwData.ShowItemToolTips = true;
		this.cmbSearch.Items.Add(global::Globals.translate_0.GetStr(base.Name, "mnuAll", "All"));
		this.cmbSearch.SelectedIndex = 0;
		this.dataGridView_0 = url;
		this.engine_0 = new SearchColumn.Engine(bExploiter, this.lvwData, this.cmbSearch);
		this.cmbMinRows.Items.AddRange(new string[]
		{
			"1k",
			"5k",
			"10k",
			"30k",
			"50k",
			"100k",
			global::Globals.translate_0.GetStr(base.Name, "mnuAll", "All")
		});
		this.cmbMinRows.SelectedIndex = checked(this.cmbMinRows.Items.Count - 1);
		this.lvwData.ShowGroups = true;
		this.lvwData.View = View.Details;
		this.lvwData.HeaderStyle = ColumnHeaderStyle.None;
		global::Globals.AddMouseMoveForm(this);
		global::Globals.translate_0.Add(this, this.icontainer_0);
		this.cmbSearch.Visible = (this.cmbSearch.Items.Count > 2);
		this.size_0 = base.Size;
		base.FormBorderStyle = FormBorderStyle.None;
		base.Size = new Size(0, 0);
		this.bool_0 = true;
	}

	// Token: 0x17000341 RID: 833
	// (get) Token: 0x06000ABB RID: 2747 RVA: 0x0000672F File Offset: 0x0000492F
	// (set) Token: 0x06000ABC RID: 2748 RVA: 0x00042F4C File Offset: 0x0004114C
	internal virtual ListViewExt lvwData
	{
		[CompilerGenerated]
		get
		{
			return this._lvwData;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_3);
			ListViewExt lvwData = this._lvwData;
			if (lvwData != null)
			{
				lvwData.SelectedIndexChanged -= value2;
			}
			this._lvwData = value;
			lvwData = this._lvwData;
			if (lvwData != null)
			{
				lvwData.SelectedIndexChanged += value2;
			}
		}
	}

	// Token: 0x17000342 RID: 834
	// (get) Token: 0x06000ABD RID: 2749 RVA: 0x00006737 File Offset: 0x00004937
	// (set) Token: 0x06000ABE RID: 2750 RVA: 0x0000673F File Offset: 0x0000493F
	internal virtual ColumnHeader ColumnHeader5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000343 RID: 835
	// (get) Token: 0x06000ABF RID: 2751 RVA: 0x00006748 File Offset: 0x00004948
	// (set) Token: 0x06000AC0 RID: 2752 RVA: 0x00006750 File Offset: 0x00004950
	internal virtual ColumnHeader ColumnHeader6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000344 RID: 836
	// (get) Token: 0x06000AC1 RID: 2753 RVA: 0x00006759 File Offset: 0x00004959
	// (set) Token: 0x06000AC2 RID: 2754 RVA: 0x00006761 File Offset: 0x00004961
	public virtual StatusStrip stsMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000345 RID: 837
	// (get) Token: 0x06000AC3 RID: 2755 RVA: 0x0000676A File Offset: 0x0000496A
	// (set) Token: 0x06000AC4 RID: 2756 RVA: 0x00006772 File Offset: 0x00004972
	public virtual ToolStripStatusLabel lblStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000346 RID: 838
	// (get) Token: 0x06000AC5 RID: 2757 RVA: 0x0000677B File Offset: 0x0000497B
	// (set) Token: 0x06000AC6 RID: 2758 RVA: 0x00042F90 File Offset: 0x00041190
	internal virtual ContextMenuStrip mnuListview
	{
		[CompilerGenerated]
		get
		{
			return this._mnuListView_1;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			CancelEventHandler value2 = new CancelEventHandler(this.method_5);
			ContextMenuStrip mnuListView_ = this._mnuListView_1;
			if (mnuListView_ != null)
			{
				mnuListView_.Opening -= value2;
			}
			this._mnuListView_1 = value;
			mnuListView_ = this._mnuListView_1;
			if (mnuListView_ != null)
			{
				mnuListView_.Opening += value2;
			}
		}
	}

	// Token: 0x17000347 RID: 839
	// (get) Token: 0x06000AC7 RID: 2759 RVA: 0x00006783 File Offset: 0x00004983
	// (set) Token: 0x06000AC8 RID: 2760 RVA: 0x00042FD4 File Offset: 0x000411D4
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
			EventHandler value2 = new EventHandler(this.method_6);
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

	// Token: 0x17000348 RID: 840
	// (get) Token: 0x06000AC9 RID: 2761 RVA: 0x0000678B File Offset: 0x0000498B
	// (set) Token: 0x06000ACA RID: 2762 RVA: 0x00043018 File Offset: 0x00041218
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
			EventHandler value2 = new EventHandler(this.method_6);
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

	// Token: 0x17000349 RID: 841
	// (get) Token: 0x06000ACB RID: 2763 RVA: 0x00006793 File Offset: 0x00004993
	// (set) Token: 0x06000ACC RID: 2764 RVA: 0x0000679B File Offset: 0x0000499B
	internal virtual ColumnHeader ColumnHeader1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700034A RID: 842
	// (get) Token: 0x06000ACD RID: 2765 RVA: 0x000067A4 File Offset: 0x000049A4
	// (set) Token: 0x06000ACE RID: 2766 RVA: 0x000067AC File Offset: 0x000049AC
	internal virtual ColumnHeader ColumnHeader2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700034B RID: 843
	// (get) Token: 0x06000ACF RID: 2767 RVA: 0x000067B5 File Offset: 0x000049B5
	// (set) Token: 0x06000AD0 RID: 2768 RVA: 0x000067BD File Offset: 0x000049BD
	internal virtual ContextMenuStrip mnuDumper { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700034C RID: 844
	// (get) Token: 0x06000AD1 RID: 2769 RVA: 0x000067C6 File Offset: 0x000049C6
	// (set) Token: 0x06000AD2 RID: 2770 RVA: 0x0004305C File Offset: 0x0004125C
	internal virtual ToolStripMenuItem mnuDumper1
	{
		[CompilerGenerated]
		get
		{
			return this._mnuDumper1;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_4);
			ToolStripMenuItem mnuDumper = this._mnuDumper1;
			if (mnuDumper != null)
			{
				mnuDumper.Click -= value2;
			}
			this._mnuDumper1 = value;
			mnuDumper = this._mnuDumper1;
			if (mnuDumper != null)
			{
				mnuDumper.Click += value2;
			}
		}
	}

	// Token: 0x1700034D RID: 845
	// (get) Token: 0x06000AD3 RID: 2771 RVA: 0x000067CE File Offset: 0x000049CE
	// (set) Token: 0x06000AD4 RID: 2772 RVA: 0x000430A0 File Offset: 0x000412A0
	internal virtual ToolStripMenuItem mnuDumper2
	{
		[CompilerGenerated]
		get
		{
			return this._mnuDumper2;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_4);
			ToolStripMenuItem mnuDumper = this._mnuDumper2;
			if (mnuDumper != null)
			{
				mnuDumper.Click -= value2;
			}
			this._mnuDumper2 = value;
			mnuDumper = this._mnuDumper2;
			if (mnuDumper != null)
			{
				mnuDumper.Click += value2;
			}
		}
	}

	// Token: 0x1700034E RID: 846
	// (get) Token: 0x06000AD5 RID: 2773 RVA: 0x000067D6 File Offset: 0x000049D6
	// (set) Token: 0x06000AD6 RID: 2774 RVA: 0x000067DE File Offset: 0x000049DE
	internal virtual ToolStripDropDownButton btnGoToDumper { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700034F RID: 847
	// (get) Token: 0x06000AD7 RID: 2775 RVA: 0x000067E7 File Offset: 0x000049E7
	// (set) Token: 0x06000AD8 RID: 2776 RVA: 0x000430E4 File Offset: 0x000412E4
	internal virtual ToolStripButton btnCopy
	{
		[CompilerGenerated]
		get
		{
			return this._btnCopy;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_2);
			ToolStripButton btnCopy = this._btnCopy;
			if (btnCopy != null)
			{
				btnCopy.Click -= value2;
			}
			this._btnCopy = value;
			btnCopy = this._btnCopy;
			if (btnCopy != null)
			{
				btnCopy.Click += value2;
			}
		}
	}

	// Token: 0x17000350 RID: 848
	// (get) Token: 0x06000AD9 RID: 2777 RVA: 0x000067EF File Offset: 0x000049EF
	// (set) Token: 0x06000ADA RID: 2778 RVA: 0x000067F7 File Offset: 0x000049F7
	internal virtual ToolStripSeparator ToolStripSeparator1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000351 RID: 849
	// (get) Token: 0x06000ADB RID: 2779 RVA: 0x00006800 File Offset: 0x00004A00
	// (set) Token: 0x06000ADC RID: 2780 RVA: 0x00043128 File Offset: 0x00041328
	internal virtual ToolStripButton btnSort
	{
		[CompilerGenerated]
		get
		{
			return this._btnSort;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_9);
			ToolStripButton btnSort = this._btnSort;
			if (btnSort != null)
			{
				btnSort.Click -= value2;
			}
			this._btnSort = value;
			btnSort = this._btnSort;
			if (btnSort != null)
			{
				btnSort.Click += value2;
			}
		}
	}

	// Token: 0x17000352 RID: 850
	// (get) Token: 0x06000ADD RID: 2781 RVA: 0x00006808 File Offset: 0x00004A08
	// (set) Token: 0x06000ADE RID: 2782 RVA: 0x00006810 File Offset: 0x00004A10
	internal virtual ToolStripSeparator ToolStripSeparator2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000353 RID: 851
	// (get) Token: 0x06000ADF RID: 2783 RVA: 0x00006819 File Offset: 0x00004A19
	// (set) Token: 0x06000AE0 RID: 2784 RVA: 0x0004316C File Offset: 0x0004136C
	internal virtual ToolStripComboBox cmbMinRows
	{
		[CompilerGenerated]
		get
		{
			return this._cmbMinRows;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_7);
			ToolStripComboBox cmbMinRows = this._cmbMinRows;
			if (cmbMinRows != null)
			{
				cmbMinRows.SelectedIndexChanged -= value2;
			}
			this._cmbMinRows = value;
			cmbMinRows = this._cmbMinRows;
			if (cmbMinRows != null)
			{
				cmbMinRows.SelectedIndexChanged += value2;
			}
		}
	}

	// Token: 0x17000354 RID: 852
	// (get) Token: 0x06000AE1 RID: 2785 RVA: 0x00006821 File Offset: 0x00004A21
	// (set) Token: 0x06000AE2 RID: 2786 RVA: 0x00006829 File Offset: 0x00004A29
	public virtual ToolStrip tsChecker2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000355 RID: 853
	// (get) Token: 0x06000AE3 RID: 2787 RVA: 0x00006832 File Offset: 0x00004A32
	// (set) Token: 0x06000AE4 RID: 2788 RVA: 0x0000683A File Offset: 0x00004A3A
	internal virtual ToolStripLabel ToolStripLabel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000356 RID: 854
	// (get) Token: 0x06000AE5 RID: 2789 RVA: 0x00006843 File Offset: 0x00004A43
	// (set) Token: 0x06000AE6 RID: 2790 RVA: 0x000431B0 File Offset: 0x000413B0
	internal virtual ToolStripComboBox cmbSearch
	{
		[CompilerGenerated]
		get
		{
			return this._cmbSearch;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_7);
			ToolStripComboBox cmbSearch = this._cmbSearch;
			if (cmbSearch != null)
			{
				cmbSearch.SelectedIndexChanged -= value2;
			}
			this._cmbSearch = value;
			cmbSearch = this._cmbSearch;
			if (cmbSearch != null)
			{
				cmbSearch.SelectedIndexChanged += value2;
			}
		}
	}

	// Token: 0x17000357 RID: 855
	// (get) Token: 0x06000AE7 RID: 2791 RVA: 0x0000684B File Offset: 0x00004A4B
	// (set) Token: 0x06000AE8 RID: 2792 RVA: 0x000431F4 File Offset: 0x000413F4
	internal virtual ToolStripMenuItem mnuFocusItem
	{
		[CompilerGenerated]
		get
		{
			return this._mnuFocusItem;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_8);
			ToolStripMenuItem mnuFocusItem = this._mnuFocusItem;
			if (mnuFocusItem != null)
			{
				mnuFocusItem.Click -= value2;
			}
			this._mnuFocusItem = value;
			mnuFocusItem = this._mnuFocusItem;
			if (mnuFocusItem != null)
			{
				mnuFocusItem.Click += value2;
			}
		}
	}

	// Token: 0x17000358 RID: 856
	// (get) Token: 0x06000AE9 RID: 2793 RVA: 0x00006853 File Offset: 0x00004A53
	// (set) Token: 0x06000AEA RID: 2794 RVA: 0x00043238 File Offset: 0x00041438
	internal virtual BackgroundWorker bckSort
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
			DoWorkEventHandler value2 = new DoWorkEventHandler(this.method_10);
			RunWorkerCompletedEventHandler value3 = new RunWorkerCompletedEventHandler(this.method_11);
			BackgroundWorker backgroundWorker = this.backgroundWorker_0;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
				backgroundWorker.RunWorkerCompleted -= value3;
			}
			this.backgroundWorker_0 = value;
			backgroundWorker = this.backgroundWorker_0;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
				backgroundWorker.RunWorkerCompleted += value3;
			}
		}
	}

	// Token: 0x17000359 RID: 857
	// (get) Token: 0x06000AEB RID: 2795 RVA: 0x0000685B File Offset: 0x00004A5B
	// (set) Token: 0x06000AEC RID: 2796 RVA: 0x00006863 File Offset: 0x00004A63
	public bool CanClose { get; set; }

	// Token: 0x06000AED RID: 2797 RVA: 0x00043298 File Offset: 0x00041498
	public void ShowMe()
	{
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.Size = this.size_0;
		checked
		{
			base.Top = (int)Math.Round(unchecked((double)global::Globals.GMain.Top + (double)global::Globals.GMain.Height / 2.0 - (double)base.Height / 2.0));
			base.Left = (int)Math.Round(unchecked((double)global::Globals.GMain.Left + (double)global::Globals.GMain.Width / 2.0 - (double)base.Width / 2.0));
			base.Visible = true;
			this.CanClose = false;
		}
	}

	// Token: 0x06000AEE RID: 2798 RVA: 0x00043344 File Offset: 0x00041544
	private void method_0()
	{
		if (base.InvokeRequired)
		{
			base.Invoke(new EventHandler(this.method_12));
		}
		else
		{
			this.lblStatus.Text = global::Globals.translate_0.GetStr(base.Name, "mnuRowsCount", "Total Rows:") + " " + Strings.FormatNumber(this.int_0, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
		}
	}

	// Token: 0x06000AEF RID: 2799 RVA: 0x000433B4 File Offset: 0x000415B4
	internal void method_1(string string_0, string string_1, string string_2, int int_2, List<string> list_0)
	{
		try
		{
			this.engine_0.Add(string_0, string_1, string_2, int_2, list_0);
			ref int ptr = ref this.int_0;
			this.int_0 = checked(ptr + int_2);
			this.method_0();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, Class2.Class0_0.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	// Token: 0x06000AF0 RID: 2800 RVA: 0x00043428 File Offset: 0x00041628
	private void method_2(object sender, EventArgs e)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			try
			{
				foreach (object obj in this.lvwData.Groups)
				{
					ListViewGroup listViewGroup = (ListViewGroup)obj;
					stringBuilder.AppendLine(listViewGroup.Header);
					try
					{
						foreach (object obj2 in listViewGroup.Items)
						{
							ListViewItem listViewItem = (ListViewItem)obj2;
							if (!string.IsNullOrEmpty(listViewItem.Text))
							{
								stringBuilder.AppendLine(listViewItem.Text + ":" + listViewItem.SubItems[1].Text);
							}
							else
							{
								stringBuilder.AppendLine(listViewItem.SubItems[1].Text);
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
					stringBuilder.AppendLine();
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
			if (!string.IsNullOrEmpty(stringBuilder.ToString()))
			{
				Clipboard.SetText(stringBuilder.ToString());
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, Class2.Class0_0.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	// Token: 0x06000AF1 RID: 2801 RVA: 0x0000686C File Offset: 0x00004A6C
	private void method_3(object sender, EventArgs e)
	{
		this.btnGoToDumper.Enabled = (this.lvwData.SelectedItems.Count == 1);
	}

	// Token: 0x06000AF2 RID: 2802 RVA: 0x000435BC File Offset: 0x000417BC
	private void method_4(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			string string_ = "";
			List<string> list = new List<string>();
			this.btnGoToDumper.Enabled = false;
			try
			{
				foreach (object obj in this.lvwData.SelectedItems[0].Group.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					string text2 = listViewItem.Text;
					if (Operators.CompareString(text2, "URL", false) != 0)
					{
						if (Operators.CompareString(text2, "Method", false) != 0)
						{
							if (Operators.CompareString(text2, "", false) == 0)
							{
								list.Add(listViewItem.SubItems[1].Text);
							}
						}
						else
						{
							string_ = listViewItem.SubItems[1].Text;
						}
					}
					else
					{
						text = listViewItem.SubItems[1].Text;
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
			if (sender == this.mnuDumper2)
			{
				global::Globals.GMain.method_9(text, string_, list);
			}
			else if (!global::Globals.GMain.DumperForm.Boolean_0)
			{
				int selectedIndex;
				switch (Class54.smethod_6(string_))
				{
				case Types.MySQL_No_Error:
					selectedIndex = 0;
					break;
				case Types.MySQL_With_Error:
					selectedIndex = 1;
					break;
				case Types.MSSQL_No_Error:
					selectedIndex = 2;
					break;
				case Types.MSSQL_With_Error:
					selectedIndex = 3;
					break;
				case Types.Oracle_No_Error:
					selectedIndex = 4;
					break;
				case Types.Oracle_With_Error:
					selectedIndex = 5;
					break;
				case Types.PostgreSQL_No_Error:
					selectedIndex = 6;
					break;
				case Types.PostgreSQL_With_Error:
					selectedIndex = 7;
					break;
				}
				global::Globals.GMain.DumperForm.method_76();
				global::Globals.GMain.DumperForm.txtURL.Text = text;
				global::Globals.GMain.DumperForm.cmbSqlType.SelectedIndex = selectedIndex;
				try
				{
					foreach (string text3 in list)
					{
						text3 = text3.Substring(text3.LastIndexOf(" ")).Trim();
						string[] array = Strings.Split(text3, ".", -1, CompareMethod.Binary);
						if (array.Length > 1)
						{
							global::Globals.GMain.DumperForm.method_47(array[0]);
							global::Globals.GMain.DumperForm.method_48(array[0], array[1]);
						}
					}
				}
				finally
				{
					List<string>.Enumerator enumerator2;
					((IDisposable)enumerator2).Dispose();
				}
				global::Globals.GMain.DumperForm.method_90(null, null);
				global::Globals.GMain.twMain.SelectedNode = global::Globals.GMain.treeNode_3;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			this.btnGoToDumper.Enabled = true;
		}
	}

	// Token: 0x06000AF3 RID: 2803 RVA: 0x0000688C File Offset: 0x00004A8C
	private void method_5(object sender, CancelEventArgs e)
	{
		e.Cancel = (this.lvwData.SelectedItems.Count == 0);
	}

	// Token: 0x06000AF4 RID: 2804 RVA: 0x000438D4 File Offset: 0x00041AD4
	private void method_6(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			try
			{
				foreach (object obj in this.lvwData.SelectedItems[0].Group.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					string text2 = listViewItem.Text;
					if (Operators.CompareString(text2, "URL", false) == 0)
					{
						text = listViewItem.SubItems[1].Text;
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
			if (!string.IsNullOrEmpty(text))
			{
				if (sender == this.mnuShell)
				{
					global::Globals.ShellUrl(text.Replace("[t]", "99"));
				}
				else
				{
					Clipboard.SetText(text.Replace("[t]", "99"));
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	// Token: 0x06000AF5 RID: 2805 RVA: 0x000439E4 File Offset: 0x00041BE4
	private void method_7(object sender, EventArgs e)
	{
		try
		{
			switch (this.cmbMinRows.SelectedIndex)
			{
			case 0:
				this.engine_0.MiniRows = 1000;
				break;
			case 1:
				this.engine_0.MiniRows = 5000;
				break;
			case 2:
				this.engine_0.MiniRows = 10000;
				break;
			case 3:
				this.engine_0.MiniRows = 30000;
				break;
			case 4:
				this.engine_0.MiniRows = 50000;
				break;
			case 5:
				this.engine_0.MiniRows = 100000;
				break;
			case 6:
				this.engine_0.MiniRows = 0;
				break;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	// Token: 0x06000AF6 RID: 2806 RVA: 0x00043AD0 File Offset: 0x00041CD0
	private void method_8(object sender, EventArgs e)
	{
		try
		{
			string value = "";
			try
			{
				foreach (object obj in this.lvwData.SelectedItems[0].Group.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					string text = listViewItem.Text;
					if (Operators.CompareString(text, "URL", false) == 0)
					{
						this.dataGridView_0.FirstDisplayedScrollingRowIndex = listViewItem.Index;
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
			if (string.IsNullOrEmpty(value))
			{
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	// Token: 0x06000AF7 RID: 2807 RVA: 0x000068A7 File Offset: 0x00004AA7
	private void SearchColumn_FormClosing(object sender, FormClosingEventArgs e)
	{
		e.Cancel = !this.CanClose;
	}

	// Token: 0x06000AF8 RID: 2808 RVA: 0x00043BA8 File Offset: 0x00041DA8
	internal void method_9(object sender, EventArgs e)
	{
		try
		{
			if (this.bool_0)
			{
				this.engine_0.AddItems = false;
				this.lvwData.Groups.Clear();
				this.lvwData.Items.Clear();
				this.btnSort.Enabled = false;
				Application.DoEvents();
				this.bckSort.RunWorkerAsync();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	// Token: 0x06000AF9 RID: 2809 RVA: 0x00043C3C File Offset: 0x00041E3C
	private void method_10(object sender, DoWorkEventArgs e)
	{
		if (base.InvokeRequired)
		{
			base.Invoke(new SearchColumn.Delegate43(this.method_10), new object[]
			{
				sender,
				e
			});
		}
		else
		{
			if (!this.engine_0.AddItems && this.cmbSearch.Items.Count == 1)
			{
				this.cmbSearch.Items.AddRange(this.engine_0.Search.ToArray());
			}
			List<ListViewGroup> list = null;
			List<ListViewItem> list2 = null;
			string sSearch;
			if (this.cmbSearch.SelectedIndex == 0)
			{
				sSearch = "";
			}
			else
			{
				sSearch = Conversions.ToString(this.cmbSearch.SelectedItem);
			}
			this.engine_0.GetItems(ref list2, ref list, sSearch);
			global::Globals.LockWindowUpdate(this.lvwData.Handle);
			this.lvwData.Items.AddRange(list2.ToArray());
			this.lvwData.Groups.AddRange(list.ToArray());
			global::Globals.LockWindowUpdate(IntPtr.Zero);
		}
	}

	// Token: 0x06000AFA RID: 2810 RVA: 0x000068B8 File Offset: 0x00004AB8
	private void method_11(object sender, RunWorkerCompletedEventArgs e)
	{
		this.btnSort.Enabled = true;
		this.engine_0.AddItems = true;
	}

	// Token: 0x06000AFB RID: 2811 RVA: 0x00043D44 File Offset: 0x00041F44
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
				goto IL_29;
			}
			IL_1A:
			num2 = 4;
			SearchColumn.smethod_0(this, m.LParam, 0);
			IL_29:
			num2 = 6;
			base.WndProc(ref m);
			IL_32:
			goto IL_A5;
			IL_34:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_5E:
			goto IL_9A;
			IL_60:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_78:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_60;
		}
		IL_9A:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_A5:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000AFC RID: 2812 RVA: 0x00043E10 File Offset: 0x00042010
	private static void smethod_0(Form form_0, IntPtr intptr_0, int int_2)
	{
		checked
		{
			try
			{
				SearchColumn.Struct8 @struct = default(SearchColumn.Struct8);
				object obj = Marshal.PtrToStructure(intptr_0, typeof(SearchColumn.Struct8));
				@struct = ((obj != null) ? ((SearchColumn.Struct8)obj) : default(SearchColumn.Struct8));
				if (@struct.int_1 != 0 && @struct.int_0 != 0)
				{
					Rectangle rectangle = form_0.RectangleToScreen(form_0.ClientRectangle);
					rectangle.Width += SystemInformation.FrameBorderSize.Width - int_2;
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
					Marshal.StructureToPtr<SearchColumn.Struct8>(@struct, intptr_0, true);
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x06000AFD RID: 2813 RVA: 0x000068D2 File Offset: 0x00004AD2
	[CompilerGenerated]
	[DebuggerHidden]
	private void method_12(object sender, EventArgs e)
	{
		this.method_0();
	}

	// Token: 0x04000543 RID: 1347
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ColumnHeader5")]
	private ColumnHeader columnHeader_0;

	// Token: 0x04000544 RID: 1348
	[AccessedThroughProperty("ColumnHeader6")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ColumnHeader columnHeader_1;

	// Token: 0x04000547 RID: 1351
	[AccessedThroughProperty("mnuListview")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ContextMenuStrip _mnuListView_1;

	// Token: 0x0400054A RID: 1354
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ColumnHeader1")]
	private ColumnHeader columnHeader_2;

	// Token: 0x0400054B RID: 1355
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ColumnHeader2")]
	private ColumnHeader columnHeader_3;

	// Token: 0x0400054C RID: 1356
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mnuDumper")]
	private ContextMenuStrip _mnuListView;

	// Token: 0x04000559 RID: 1369
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bckSort")]
	[CompilerGenerated]
	private BackgroundWorker backgroundWorker_0;

	// Token: 0x0400055A RID: 1370
	private int int_0;

	// Token: 0x0400055B RID: 1371
	private SearchColumn.Engine engine_0;

	// Token: 0x0400055C RID: 1372
	private DataGridView dataGridView_0;

	// Token: 0x0400055D RID: 1373
	private Size size_0;

	// Token: 0x0400055E RID: 1374
	private bool bool_0;

	// Token: 0x0400055F RID: 1375
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool bool_1;

	// Token: 0x04000560 RID: 1376
	private static int int_1;

	// Token: 0x020000BB RID: 187
	public class Engine
	{
		// Token: 0x06000AFE RID: 2814 RVA: 0x000068DA File Offset: 0x00004ADA
		public Engine(bool bItems, ListViewExt lw, ToolStripComboBox cb)
		{
			this.Search = new List<string>();
			this.dictionary_0 = new Dictionary<string, SearchColumn.Engine.Macth>();
			this.AddItems = bItems;
			this.listViewExt_0 = lw;
			this.toolStripComboBox_0 = cb;
		}

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x06000AFF RID: 2815 RVA: 0x0000690D File Offset: 0x00004B0D
		// (set) Token: 0x06000B00 RID: 2816 RVA: 0x00006915 File Offset: 0x00004B15
		public int MiniRows { get; set; }

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x06000B01 RID: 2817 RVA: 0x0000691E File Offset: 0x00004B1E
		// (set) Token: 0x06000B02 RID: 2818 RVA: 0x00006926 File Offset: 0x00004B26
		public bool AddItems { get; set; }

		// Token: 0x06000B03 RID: 2819 RVA: 0x00044070 File Offset: 0x00042270
		public void GetItems(ref List<ListViewItem> oItems, ref List<ListViewGroup> oGroups, string sSearch)
		{
			oItems = new List<ListViewItem>();
			oGroups = new List<ListViewGroup>();
			Dictionary<string, SearchColumn.Engine.Macth> dictionary = new Dictionary<string, SearchColumn.Engine.Macth>();
			try
			{
				foreach (KeyValuePair<string, SearchColumn.Engine.Macth> keyValuePair in this.dictionary_0)
				{
					try
					{
						foreach (KeyValuePair<string, SearchColumn.Engine.Traget> keyValuePair2 in keyValuePair.Value.Detalhes)
						{
							if ((string.IsNullOrEmpty(sSearch) || keyValuePair2.Value.Search.Equals(sSearch)) && keyValuePair2.Value.Rows >= this.MiniRows)
							{
								dictionary.Add(keyValuePair.Key, keyValuePair.Value);
								if (!string.IsNullOrEmpty(sSearch))
								{
									keyValuePair.Value.TotalRows = keyValuePair2.Value.Rows;
								}
								break;
							}
						}
					}
					finally
					{
						Dictionary<string, SearchColumn.Engine.Traget>.Enumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
					}
				}
			}
			finally
			{
				Dictionary<string, SearchColumn.Engine.Macth>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			dictionary = this.method_1(dictionary);
			try
			{
				foreach (KeyValuePair<string, SearchColumn.Engine.Macth> keyValuePair3 in dictionary)
				{
					string text = Class23.smethod_11(keyValuePair3.Key);
					ListViewGroup listViewGroup = null;
					try
					{
						foreach (ListViewGroup listViewGroup2 in oGroups)
						{
							if (listViewGroup2.Header.Equals(text))
							{
								listViewGroup = listViewGroup2;
								break;
							}
						}
					}
					finally
					{
						List<ListViewGroup>.Enumerator enumerator4;
						((IDisposable)enumerator4).Dispose();
					}
					if (listViewGroup == null)
					{
						listViewGroup = new ListViewGroup(text);
						oGroups.Add(listViewGroup);
					}
					ListViewItem listViewItem = new ListViewItem("URL");
					listViewItem.SubItems.Add(keyValuePair3.Key);
					listViewItem.Group = listViewGroup;
					oItems.Add(listViewItem);
					listViewItem = new ListViewItem("Method");
					listViewItem.SubItems.Add(keyValuePair3.Value.Method);
					listViewItem.Group = listViewGroup;
					oItems.Add(listViewItem);
					if (string.IsNullOrEmpty(sSearch))
					{
						listViewItem = new ListViewItem("Total Rows");
						listViewItem.SubItems.Add(Strings.FormatNumber(keyValuePair3.Value.TotalRows, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault));
						listViewItem.Group = listViewGroup;
						oItems.Add(listViewItem);
					}
					keyValuePair3.Value.Detalhes = this.method_0(keyValuePair3.Value.Detalhes);
					try
					{
						foreach (KeyValuePair<string, SearchColumn.Engine.Traget> keyValuePair4 in keyValuePair3.Value.Detalhes)
						{
							if (string.IsNullOrEmpty(sSearch) || keyValuePair4.Value.Search.Equals(sSearch))
							{
								if (string.IsNullOrEmpty(sSearch))
								{
									listViewItem = new ListViewItem("Search");
									listViewItem.SubItems.Add(keyValuePair4.Value.Search);
									listViewItem.Group = listViewGroup;
									oItems.Add(listViewItem);
								}
								listViewItem = new ListViewItem("Rows");
								listViewItem.SubItems.Add(Strings.FormatNumber(keyValuePair4.Value.Rows, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault));
								listViewItem.Group = listViewGroup;
								oItems.Add(listViewItem);
								try
								{
									foreach (string text2 in keyValuePair4.Value.Schema)
									{
										listViewItem = new ListViewItem("");
										listViewItem.SubItems.Add(text2);
										listViewItem.Group = listViewGroup;
										oItems.Add(listViewItem);
									}
								}
								finally
								{
									List<string>.Enumerator enumerator6;
									((IDisposable)enumerator6).Dispose();
								}
							}
						}
					}
					finally
					{
						Dictionary<string, SearchColumn.Engine.Traget>.Enumerator enumerator5;
						((IDisposable)enumerator5).Dispose();
					}
				}
			}
			finally
			{
				Dictionary<string, SearchColumn.Engine.Macth>.Enumerator enumerator3;
				((IDisposable)enumerator3).Dispose();
			}
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x000444CC File Offset: 0x000426CC
		public ListViewGroup GetGroupByHeader(ListViewExt lvw, string name)
		{
			try
			{
				foreach (object obj in lvw.Groups)
				{
					ListViewGroup listViewGroup = (ListViewGroup)obj;
					if (listViewGroup.Header.Equals(name))
					{
						return listViewGroup;
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
			return null;
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x00044538 File Offset: 0x00042738
		public void Sort()
		{
			this.dictionary_0 = this.method_1(this.dictionary_0);
			try
			{
				foreach (KeyValuePair<string, SearchColumn.Engine.Macth> keyValuePair in this.dictionary_0)
				{
					keyValuePair.Value.Detalhes = this.method_0(keyValuePair.Value.Detalhes);
					try
					{
						foreach (KeyValuePair<string, SearchColumn.Engine.Traget> keyValuePair2 in keyValuePair.Value.Detalhes)
						{
							keyValuePair2.Value.Schema = this.method_2(keyValuePair2.Value.Schema);
						}
					}
					finally
					{
						Dictionary<string, SearchColumn.Engine.Traget>.Enumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
					}
				}
			}
			finally
			{
				Dictionary<string, SearchColumn.Engine.Macth>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x00044618 File Offset: 0x00042818
		public void Add(string sURL, string sMethod, string sSearch, int iCount, List<string> lTables)
		{
			if (this.listViewExt_0.InvokeRequired)
			{
				this.listViewExt_0.Invoke(new SearchColumn.Engine.DAdd(this.Add), new object[]
				{
					sURL,
					sMethod,
					sSearch,
					iCount,
					lTables
				});
			}
			else
			{
				SearchColumn.Engine.Macth macth;
				if (this.dictionary_0.ContainsKey(sURL))
				{
					macth = this.dictionary_0[sURL];
				}
				else
				{
					macth = new SearchColumn.Engine.Macth();
					this.dictionary_0.Add(sURL, macth);
				}
				SearchColumn.Engine.Macth macth2;
				(macth2 = macth).TotalRows = checked(macth2.TotalRows + iCount);
				macth.Method = sMethod;
				SearchColumn.Engine.Traget traget;
				if (macth.Detalhes.ContainsKey(sSearch))
				{
					traget = macth.Detalhes[sSearch];
					traget.Schema.AddRange(lTables.ToArray());
				}
				else
				{
					traget = new SearchColumn.Engine.Traget();
					traget.Search = sSearch;
					traget.Rows = iCount;
					traget.Schema = lTables;
					macth.Detalhes.Add(sSearch, traget);
				}
				traget.Schema = this.method_2(traget.Schema);
				if (!this.Search.Contains(sSearch))
				{
					this.Search.Add(sSearch);
				}
				if (this.AddItems)
				{
					object obj = this.listViewExt_0;
					lock (obj)
					{
						if (!this.toolStripComboBox_0.Items.Contains(sSearch))
						{
							this.toolStripComboBox_0.Items.Add(sSearch);
						}
						if (this.toolStripComboBox_0.SelectedIndex <= 0 || this.toolStripComboBox_0.SelectedItem.Equals(sSearch))
						{
							if (traget.Rows >= this.MiniRows)
							{
								string text = Class23.smethod_11(sURL);
								ListViewGroup listViewGroup = this.GetGroupByHeader(this.listViewExt_0, text);
								global::Globals.LockWindowUpdate(this.listViewExt_0.Handle);
								if (listViewGroup == null)
								{
									listViewGroup = new ListViewGroup(text);
									this.listViewExt_0.Groups.Add(listViewGroup);
									ListViewItem listViewItem = new ListViewItem("URL");
									listViewItem.SubItems.Add(sURL);
									listViewItem.Group = listViewGroup;
									this.listViewExt_0.Items.Add(listViewItem);
									listViewItem = new ListViewItem("Method");
									listViewItem.SubItems.Add(macth.Method);
									listViewItem.Group = listViewGroup;
									this.listViewExt_0.Items.Add(listViewItem);
								}
								if (macth.Detalhes.Count > 1)
								{
									ListViewItem listViewItem = new ListViewItem("Total Rows");
									listViewItem.SubItems.Add(Strings.FormatNumber(macth.TotalRows, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault));
									listViewItem.Group = listViewGroup;
									this.listViewExt_0.Items.Add(listViewItem);
								}
								try
								{
									foreach (KeyValuePair<string, SearchColumn.Engine.Traget> keyValuePair in macth.Detalhes)
									{
										if (keyValuePair.Value.Search.Equals(sSearch))
										{
											ListViewItem listViewItem = new ListViewItem("Search");
											listViewItem.SubItems.Add(keyValuePair.Value.Search);
											listViewItem.Group = listViewGroup;
											this.listViewExt_0.Items.Add(listViewItem);
											listViewItem = new ListViewItem("Rows");
											listViewItem.SubItems.Add(Strings.FormatNumber(keyValuePair.Value.Rows, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault));
											listViewItem.Group = listViewGroup;
											this.listViewExt_0.Items.Add(listViewItem);
											try
											{
												foreach (string text2 in keyValuePair.Value.Schema)
												{
													listViewItem = new ListViewItem("");
													listViewItem.SubItems.Add(text2);
													listViewItem.Group = listViewGroup;
													this.listViewExt_0.Items.Add(listViewItem);
												}
											}
											finally
											{
												List<string>.Enumerator enumerator2;
												((IDisposable)enumerator2).Dispose();
											}
										}
									}
								}
								finally
								{
									Dictionary<string, SearchColumn.Engine.Traget>.Enumerator enumerator;
									((IDisposable)enumerator).Dispose();
								}
								global::Globals.LockWindowUpdate(IntPtr.Zero);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x00044A98 File Offset: 0x00042C98
		private Dictionary<string, SearchColumn.Engine.Traget> method_0(Dictionary<string, SearchColumn.Engine.Traget> dictionary_1)
		{
			Dictionary<string, SearchColumn.Engine.Traget> dictionary = new Dictionary<string, SearchColumn.Engine.Traget>();
			int num = 0;
			KeyValuePair<string, SearchColumn.Engine.Traget> keyValuePair = default(KeyValuePair<string, SearchColumn.Engine.Traget>);
			while (dictionary_1.Count > 0)
			{
				try
				{
					foreach (KeyValuePair<string, SearchColumn.Engine.Traget> keyValuePair2 in dictionary_1)
					{
						if (keyValuePair2.Value.Rows > num)
						{
							num = keyValuePair2.Value.Rows;
							keyValuePair = keyValuePair2;
						}
					}
				}
				finally
				{
					Dictionary<string, SearchColumn.Engine.Traget>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				dictionary.Add(keyValuePair.Key, keyValuePair.Value);
				dictionary_1.Remove(keyValuePair.Key);
				num = 0;
			}
			return dictionary;
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x00044B4C File Offset: 0x00042D4C
		private Dictionary<string, SearchColumn.Engine.Macth> method_1(Dictionary<string, SearchColumn.Engine.Macth> dictionary_1)
		{
			Dictionary<string, SearchColumn.Engine.Macth> dictionary = new Dictionary<string, SearchColumn.Engine.Macth>();
			int num = 0;
			KeyValuePair<string, SearchColumn.Engine.Macth> keyValuePair = default(KeyValuePair<string, SearchColumn.Engine.Macth>);
			while (dictionary_1.Count > 0)
			{
				try
				{
					foreach (KeyValuePair<string, SearchColumn.Engine.Macth> keyValuePair2 in dictionary_1)
					{
						if (keyValuePair2.Value.TotalRows > num)
						{
							num = keyValuePair2.Value.TotalRows;
							keyValuePair = keyValuePair2;
						}
					}
				}
				finally
				{
					Dictionary<string, SearchColumn.Engine.Macth>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				dictionary.Add(keyValuePair.Key, keyValuePair.Value);
				dictionary_1.Remove(keyValuePair.Key);
				num = 0;
			}
			return dictionary;
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x00044C00 File Offset: 0x00042E00
		private List<string> method_2(List<string> list_0)
		{
			List<string> list = new List<string>();
			int num = 0;
			string item = "";
			while (list_0.Count > 0)
			{
				try
				{
					foreach (string text in list_0)
					{
						int num2 = Conversions.ToInteger(checked(text.Substring(text.IndexOf("[") + 1, text.IndexOf("]") - 1)));
						if (num2 > num)
						{
							num = num2;
							item = text;
						}
					}
				}
				finally
				{
					List<string>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				list.Add(item);
				list_0.Remove(item);
				num = 0;
			}
			return list;
		}

		// Token: 0x04000561 RID: 1377
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04000562 RID: 1378
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000563 RID: 1379
		public List<string> Search;

		// Token: 0x04000564 RID: 1380
		private Dictionary<string, SearchColumn.Engine.Macth> dictionary_0;

		// Token: 0x04000565 RID: 1381
		private ListViewExt listViewExt_0;

		// Token: 0x04000566 RID: 1382
		private ToolStripComboBox toolStripComboBox_0;

		// Token: 0x020000BC RID: 188
		// (Invoke) Token: 0x06000B0D RID: 2829
		public delegate void DAdd(string sURL, string sMethod, string sSearch, int iCount, List<string> lTables);

		// Token: 0x020000BD RID: 189
		public class Macth
		{
			// Token: 0x06000B0E RID: 2830 RVA: 0x0000692F File Offset: 0x00004B2F
			public Macth()
			{
				this.Detalhes = new Dictionary<string, SearchColumn.Engine.Traget>();
			}

			// Token: 0x1700035C RID: 860
			// (get) Token: 0x06000B0F RID: 2831 RVA: 0x00006942 File Offset: 0x00004B42
			// (set) Token: 0x06000B10 RID: 2832 RVA: 0x0000694A File Offset: 0x00004B4A
			public string Method { get; set; }

			// Token: 0x1700035D RID: 861
			// (get) Token: 0x06000B11 RID: 2833 RVA: 0x00006953 File Offset: 0x00004B53
			// (set) Token: 0x06000B12 RID: 2834 RVA: 0x0000695B File Offset: 0x00004B5B
			public int TotalRows { get; set; }

			// Token: 0x1700035E RID: 862
			// (get) Token: 0x06000B13 RID: 2835 RVA: 0x00006964 File Offset: 0x00004B64
			// (set) Token: 0x06000B14 RID: 2836 RVA: 0x0000696C File Offset: 0x00004B6C
			public Dictionary<string, SearchColumn.Engine.Traget> Detalhes { get; set; }

			// Token: 0x04000567 RID: 1383
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private string string_0;

			// Token: 0x04000568 RID: 1384
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			private int int_0;

			// Token: 0x04000569 RID: 1385
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			private Dictionary<string, SearchColumn.Engine.Traget> dictionary_0;
		}

		// Token: 0x020000BE RID: 190
		public class Traget
		{
			// Token: 0x1700035F RID: 863
			// (get) Token: 0x06000B16 RID: 2838 RVA: 0x00006975 File Offset: 0x00004B75
			// (set) Token: 0x06000B17 RID: 2839 RVA: 0x0000697D File Offset: 0x00004B7D
			public string Search { get; set; }

			// Token: 0x17000360 RID: 864
			// (get) Token: 0x06000B18 RID: 2840 RVA: 0x00006986 File Offset: 0x00004B86
			// (set) Token: 0x06000B19 RID: 2841 RVA: 0x0000698E File Offset: 0x00004B8E
			public int Rows { get; set; }

			// Token: 0x17000361 RID: 865
			// (get) Token: 0x06000B1A RID: 2842 RVA: 0x00006997 File Offset: 0x00004B97
			// (set) Token: 0x06000B1B RID: 2843 RVA: 0x0000699F File Offset: 0x00004B9F
			public List<string> Schema { get; set; }

			// Token: 0x0400056A RID: 1386
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private string string_0;

			// Token: 0x0400056B RID: 1387
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			private int int_0;

			// Token: 0x0400056C RID: 1388
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private List<string> list_0;
		}
	}

	// Token: 0x020000BF RID: 191
	// (Invoke) Token: 0x06000B1F RID: 2847
	private delegate void Delegate43(object sender, DoWorkEventArgs e);

	// Token: 0x020000C0 RID: 192
	private struct Struct8
	{
		// Token: 0x0400056D RID: 1389
		public IntPtr intptr_0;

		// Token: 0x0400056E RID: 1390
		public IntPtr intptr_1;

		// Token: 0x0400056F RID: 1391
		public int int_0;

		// Token: 0x04000570 RID: 1392
		public int int_1;

		// Token: 0x04000571 RID: 1393
		public int int_2;

		// Token: 0x04000572 RID: 1394
		public int int_3;

		// Token: 0x04000573 RID: 1395
		public int int_4;
	}
}
