using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x02000087 RID: 135
[DesignerGenerated]
public partial class DumpGrid : Form
{
	// Token: 0x0600076C RID: 1900 RVA: 0x000359B0 File Offset: 0x00033BB0
	public DumpGrid(Dumper o)
	{
		base.FormClosing += this.DumpGrid_FormClosing;
		this.InitializeComponent();
		this.dtgData.AllowDrop = false;
		this.dtgData.AllowUserToAddRows = false;
		this.dtgData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		this.dtgData.AllowUserToResizeRows = false;
		this.dtgData.SelectionMode = DataGridViewSelectionMode.CellSelect;
		this.dtgData.ShowCellErrors = false;
		this.dtgData.ShowRowErrors = false;
		this.btnFullView.Tag = this;
		this.btnCloseAllGrids.Tag = this;
		this.btnCloseAllButThis.Tag = this;
		this.btnCloseGrid.Tag = this;
		this.dumper_0 = o;
		Globals.AddMouseMoveForm(this);
		Globals.translate_0.Add(this, this.icontainer_0);
	}

	// Token: 0x1700025A RID: 602
	// (get) Token: 0x0600076F RID: 1903 RVA: 0x00005368 File Offset: 0x00003568
	// (set) Token: 0x06000770 RID: 1904 RVA: 0x00036490 File Offset: 0x00034690
	internal virtual ContextMenuStrip mnuListView
	{
		[CompilerGenerated]
		get
		{
			return this._mnuListView;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			CancelEventHandler value2 = new CancelEventHandler(this.method_7);
			ContextMenuStrip mnuListView = this._mnuListView;
			if (mnuListView != null)
			{
				mnuListView.Opening -= value2;
			}
			this._mnuListView = value;
			mnuListView = this._mnuListView;
			if (mnuListView != null)
			{
				mnuListView.Opening += value2;
			}
		}
	}

	// Token: 0x1700025B RID: 603
	// (get) Token: 0x06000771 RID: 1905 RVA: 0x00005370 File Offset: 0x00003570
	// (set) Token: 0x06000772 RID: 1906 RVA: 0x00005378 File Offset: 0x00003578
	internal virtual ToolStripMenuItem mnuClipboard { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700025C RID: 604
	// (get) Token: 0x06000773 RID: 1907 RVA: 0x00005381 File Offset: 0x00003581
	// (set) Token: 0x06000774 RID: 1908 RVA: 0x00005389 File Offset: 0x00003589
	internal virtual ToolStripMenuItem mnuClipboardAll { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700025D RID: 605
	// (get) Token: 0x06000775 RID: 1909 RVA: 0x00005392 File Offset: 0x00003592
	// (set) Token: 0x06000776 RID: 1910 RVA: 0x0000539A File Offset: 0x0000359A
	internal virtual ToolStripSeparator mnuNewWindowsSP { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700025E RID: 606
	// (get) Token: 0x06000777 RID: 1911 RVA: 0x000053A3 File Offset: 0x000035A3
	// (set) Token: 0x06000778 RID: 1912 RVA: 0x000053AB File Offset: 0x000035AB
	internal virtual ToolStripMenuItem munClipboardCell { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700025F RID: 607
	// (get) Token: 0x06000779 RID: 1913 RVA: 0x000053B4 File Offset: 0x000035B4
	// (set) Token: 0x0600077A RID: 1914 RVA: 0x000364D4 File Offset: 0x000346D4
	internal virtual DataGridView dtgData
	{
		[CompilerGenerated]
		get
		{
			return this._dtgData;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			DataGridViewRowPostPaintEventHandler value2 = new DataGridViewRowPostPaintEventHandler(this.method_9);
			DataGridView dtgData = this._dtgData;
			if (dtgData != null)
			{
				dtgData.RowPostPaint -= value2;
			}
			this._dtgData = value;
			dtgData = this._dtgData;
			if (dtgData != null)
			{
				dtgData.RowPostPaint += value2;
			}
		}
	}

	// Token: 0x17000260 RID: 608
	// (get) Token: 0x0600077B RID: 1915 RVA: 0x000053BC File Offset: 0x000035BC
	// (set) Token: 0x0600077C RID: 1916 RVA: 0x000053C4 File Offset: 0x000035C4
	internal virtual ToolStrip ToolStrip5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000261 RID: 609
	// (get) Token: 0x0600077D RID: 1917 RVA: 0x000053CD File Offset: 0x000035CD
	// (set) Token: 0x0600077E RID: 1918 RVA: 0x000053D5 File Offset: 0x000035D5
	public virtual ToolStripButton btnFullView { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000262 RID: 610
	// (get) Token: 0x0600077F RID: 1919 RVA: 0x000053DE File Offset: 0x000035DE
	// (set) Token: 0x06000780 RID: 1920 RVA: 0x000053E6 File Offset: 0x000035E6
	internal virtual ToolStripSeparator tsSP { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000263 RID: 611
	// (get) Token: 0x06000781 RID: 1921 RVA: 0x000053EF File Offset: 0x000035EF
	// (set) Token: 0x06000782 RID: 1922 RVA: 0x00036518 File Offset: 0x00034718
	internal virtual ToolStripButton btnExpTXT
	{
		[CompilerGenerated]
		get
		{
			return this._btnExpTXT;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_6);
			ToolStripButton btnExpTXT = this._btnExpTXT;
			if (btnExpTXT != null)
			{
				btnExpTXT.Click -= value2;
			}
			this._btnExpTXT = value;
			btnExpTXT = this._btnExpTXT;
			if (btnExpTXT != null)
			{
				btnExpTXT.Click += value2;
			}
		}
	}

	// Token: 0x17000264 RID: 612
	// (get) Token: 0x06000783 RID: 1923 RVA: 0x000053F7 File Offset: 0x000035F7
	// (set) Token: 0x06000784 RID: 1924 RVA: 0x000053FF File Offset: 0x000035FF
	internal virtual ToolStripSeparator tsSP2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000265 RID: 613
	// (get) Token: 0x06000785 RID: 1925 RVA: 0x00005408 File Offset: 0x00003608
	// (set) Token: 0x06000786 RID: 1926 RVA: 0x0003655C File Offset: 0x0003475C
	internal virtual ToolStripButton btnClipboard
	{
		[CompilerGenerated]
		get
		{
			return this._btnClipboard;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_8);
			ToolStripButton btnClipboard = this._btnClipboard;
			if (btnClipboard != null)
			{
				btnClipboard.Click -= value2;
			}
			this._btnClipboard = value;
			btnClipboard = this._btnClipboard;
			if (btnClipboard != null)
			{
				btnClipboard.Click += value2;
			}
		}
	}

	// Token: 0x17000266 RID: 614
	// (get) Token: 0x06000787 RID: 1927 RVA: 0x00005410 File Offset: 0x00003610
	// (set) Token: 0x06000788 RID: 1928 RVA: 0x00005418 File Offset: 0x00003618
	public virtual ToolStripButton btnCloseGrid { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000267 RID: 615
	// (get) Token: 0x06000789 RID: 1929 RVA: 0x00005421 File Offset: 0x00003621
	// (set) Token: 0x0600078A RID: 1930 RVA: 0x00005429 File Offset: 0x00003629
	public virtual ToolStripButton btnCloseAllGrids { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000268 RID: 616
	// (get) Token: 0x0600078B RID: 1931 RVA: 0x00005432 File Offset: 0x00003632
	// (set) Token: 0x0600078C RID: 1932 RVA: 0x0000543A File Offset: 0x0000363A
	public virtual ToolStripButton btnCloseAllButThis { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000269 RID: 617
	// (get) Token: 0x0600078D RID: 1933 RVA: 0x00005443 File Offset: 0x00003643
	// (set) Token: 0x0600078E RID: 1934 RVA: 0x0000544B File Offset: 0x0000364B
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn_0 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700026A RID: 618
	// (get) Token: 0x0600078F RID: 1935 RVA: 0x00005454 File Offset: 0x00003654
	// (set) Token: 0x06000790 RID: 1936 RVA: 0x0000545C File Offset: 0x0000365C
	internal virtual ToolStripButton btnAutoScroll { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700026B RID: 619
	// (get) Token: 0x06000791 RID: 1937 RVA: 0x00005465 File Offset: 0x00003665
	// (set) Token: 0x06000792 RID: 1938 RVA: 0x0000546D File Offset: 0x0000366D
	internal virtual ToolStripSeparator ToolStripSeparator15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700026C RID: 620
	// (get) Token: 0x06000793 RID: 1939 RVA: 0x00005476 File Offset: 0x00003676
	// (set) Token: 0x06000794 RID: 1940 RVA: 0x0000547E File Offset: 0x0000367E
	internal virtual ToolStripSeparator ToolStripSeparator3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700026D RID: 621
	// (get) Token: 0x06000795 RID: 1941 RVA: 0x00005487 File Offset: 0x00003687
	// (set) Token: 0x06000796 RID: 1942 RVA: 0x0000548F File Offset: 0x0000368F
	internal virtual TextBox txtResult { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700026E RID: 622
	// (get) Token: 0x06000797 RID: 1943 RVA: 0x00005498 File Offset: 0x00003698
	// (set) Token: 0x06000798 RID: 1944 RVA: 0x000054A0 File Offset: 0x000036A0
	internal virtual ToolStripSeparator tsSP3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700026F RID: 623
	// (get) Token: 0x06000799 RID: 1945 RVA: 0x000054A9 File Offset: 0x000036A9
	// (set) Token: 0x0600079A RID: 1946 RVA: 0x000054B1 File Offset: 0x000036B1
	internal string DataBase { get; set; }

	// Token: 0x17000270 RID: 624
	// (get) Token: 0x0600079B RID: 1947 RVA: 0x000054BA File Offset: 0x000036BA
	// (set) Token: 0x0600079C RID: 1948 RVA: 0x000054C2 File Offset: 0x000036C2
	internal string Table { get; set; }

	// Token: 0x17000271 RID: 625
	// (get) Token: 0x0600079D RID: 1949 RVA: 0x000054CB File Offset: 0x000036CB
	// (set) Token: 0x0600079E RID: 1950 RVA: 0x000054D3 File Offset: 0x000036D3
	internal List<string> Columns { get; set; }

	// Token: 0x0600079F RID: 1951 RVA: 0x000365A0 File Offset: 0x000347A0
	private string method_0(string string_3)
	{
		string result;
		if (string.IsNullOrEmpty(string_3))
		{
			result = "";
		}
		else
		{
			if (string_3.StartsWith("?~!"))
			{
				string_3 = string_3.Substring("?~!".Length);
			}
			if (string_3.EndsWith("?~!"))
			{
				string_3 = string_3.Substring(0, checked(string_3.Length - "?~!".Length));
			}
			if (string_3.Equals("'"))
			{
				string_3 = "";
			}
			result = string_3;
		}
		return result;
	}

	// Token: 0x060007A0 RID: 1952 RVA: 0x00036620 File Offset: 0x00034820
	private string method_1()
	{
		string result;
		try
		{
			result = this.Text.Substring(checked(this.Text.LastIndexOf("/") + 1)).Replace("/", "");
		}
		catch (Exception ex)
		{
			result = "";
		}
		return result;
	}

	// Token: 0x060007A1 RID: 1953 RVA: 0x00036684 File Offset: 0x00034884
	internal void method_2()
	{
		if (this.dtgData.InvokeRequired)
		{
			this.dtgData.Invoke(new DumpGrid.Delegate31(this.method_2));
		}
		else if (this.Columns != null)
		{
			try
			{
				foreach (string headerText in this.Columns)
				{
					DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
					dataGridViewTextBoxColumn.HeaderText = headerText;
					this.dtgData.Columns.Add(dataGridViewTextBoxColumn);
				}
			}
			finally
			{
				List<string>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
		}
	}

	// Token: 0x060007A2 RID: 1954 RVA: 0x00036724 File Offset: 0x00034924
	internal string method_3(List<string> list_1)
	{
		checked
		{
			string result;
			if (base.InvokeRequired)
			{
				result = Conversions.ToString(base.Invoke(new DumpGrid.Delegate32(this.method_3), new object[]
				{
					list_1
				}));
			}
			else if (this.txtResult.Visible)
			{
				this.txtResult.Text = list_1[0];
				result = "";
			}
			else
			{
				string[] array = new string[list_1.Count + 1];
				array[0] = Guid.NewGuid().ToString();
				int num = list_1.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					array[i + 1] = this.method_0(list_1[i]);
				}
				this.dtgData.Rows.Add(array);
				if (this.dtgData.Rows.Count > 2 & this.btnAutoScroll.Checked)
				{
					try
					{
						this.dtgData.FirstDisplayedScrollingRowIndex = this.dtgData.Rows.Count - 1;
					}
					catch (Exception ex)
					{
					}
				}
				result = array[0];
			}
			return result;
		}
	}

	// Token: 0x060007A3 RID: 1955 RVA: 0x00036854 File Offset: 0x00034A54
	internal bool method_4(string string_3)
	{
		checked
		{
			bool result;
			if (base.InvokeRequired)
			{
				result = Conversions.ToBoolean(base.Invoke(new DumpGrid.Delegate34(this.method_10), new object[]
				{
					string_3
				}));
			}
			else
			{
				int num = this.dtgData.Rows.Count - 1;
				if (num <= 0)
				{
					result = false;
				}
				else
				{
					DataGridViewRow dataGridViewRow;
					for (;;)
					{
						dataGridViewRow = this.dtgData.Rows[num];
						if (dataGridViewRow.Cells["ID"].Value.ToString().Equals(string_3))
						{
							break;
						}
						num--;
						if (num < 0)
						{
							return result;
						}
					}
					int num2 = dataGridViewRow.Cells.Count - 1;
					bool flag;
					for (int i = 1; i <= num2; i++)
					{
						if (i == 1)
						{
							flag = string.IsNullOrEmpty(dataGridViewRow.Cells[i].Value.ToString().Trim());
						}
						else
						{
							flag &= string.IsNullOrEmpty(dataGridViewRow.Cells[i].Value.ToString().Trim());
						}
					}
					result = flag;
				}
			}
			return result;
		}
	}

	// Token: 0x060007A4 RID: 1956 RVA: 0x00036968 File Offset: 0x00034B68
	internal bool method_5(string string_3, int int_0, string string_4)
	{
		checked
		{
			bool result;
			if (base.InvokeRequired)
			{
				result = Conversions.ToBoolean(base.Invoke(new DumpGrid.Delegate33(this.method_5), new object[]
				{
					string_3,
					int_0,
					string_4
				}));
			}
			else
			{
				int num = this.dtgData.Rows.Count - 1;
				DataGridViewRow dataGridViewRow;
				for (;;)
				{
					dataGridViewRow = this.dtgData.Rows[num];
					if (dataGridViewRow.Cells["ID"].Value.ToString().Equals(string_3))
					{
						break;
					}
					num--;
					if (num < 0)
					{
						return result;
					}
				}
				dataGridViewRow.Cells[int_0 + 1].Value = this.method_0(string_4);
				result = true;
			}
			return result;
		}
	}

	// Token: 0x060007A5 RID: 1957 RVA: 0x00036A20 File Offset: 0x00034C20
	internal void method_6(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				if (this.txtResult.Visible)
				{
					using (SaveFileDialog saveFileDialog = new SaveFileDialog())
					{
						saveFileDialog.FileName = this.method_1();
						if (saveFileDialog.ShowDialog() == DialogResult.OK)
						{
							File.WriteAllText(saveFileDialog.FileName, this.txtResult.Text);
						}
						goto IL_19D;
					}
				}
				if (this.dtgData.Columns.Count != 0)
				{
					this.dumpExporter_0 = new DumpExporter(this.dtgData, string.Concat(new string[]
					{
						Class23.smethod_11(this.dumper_0.txtURL.Text),
						" - ",
						this.DataBase,
						".",
						this.Table,
						".txt"
					}), this.dumper_0.txtURL.Text, this.dumper_0);
					this.dumpExporter_0.Text = this.Text;
					this.dumpExporter_0.StartPosition = FormStartPosition.Manual;
					this.dumpExporter_0.Top = (int)Math.Round(unchecked((double)Globals.GMain.Top + (double)Globals.GMain.Height / 2.0 - (double)this.dumpExporter_0.Height / 2.0));
					this.dumpExporter_0.Left = (int)Math.Round(unchecked((double)Globals.GMain.Left + (double)Globals.GMain.Width / 2.0 - (double)this.dumpExporter_0.Width / 2.0));
					this.dumpExporter_0.Show(Globals.GMain);
				}
				IL_19D:;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Class2.Class0_0.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	// Token: 0x060007A6 RID: 1958 RVA: 0x000054DC File Offset: 0x000036DC
	private void method_7(object sender, CancelEventArgs e)
	{
		e.Cancel = (this.dtgData.RowCount == 0);
	}

	// Token: 0x060007A7 RID: 1959 RVA: 0x00036C2C File Offset: 0x00034E2C
	private void method_8(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				if (this.txtResult.Visible)
				{
					Clipboard.SetText(this.txtResult.Text);
				}
				else
				{
					string text = "";
					int num = this.dtgData.SelectedCells.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						DataGridViewCell dataGridViewCell = this.dtgData.SelectedCells[i];
						if (i == 0)
						{
							text = dataGridViewCell.Value.ToString();
						}
						else
						{
							text = text + "\r\n" + dataGridViewCell.Value.ToString();
						}
					}
					if (!string.IsNullOrEmpty(text))
					{
						Clipboard.SetText(text);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Class2.Class0_0.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	// Token: 0x060007A8 RID: 1960 RVA: 0x00036D10 File Offset: 0x00034F10
	private void method_9(object sender, DataGridViewRowPostPaintEventArgs e)
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
			checked
			{
				using (SolidBrush solidBrush = new SolidBrush(this.dtgData.RowHeadersDefaultCellStyle.ForeColor))
				{
					e.Graphics.DrawString((e.RowIndex + 1).ToString(CultureInfo.CurrentUICulture), this.dtgData.DefaultCellStyle.Font, solidBrush, (float)(e.RowBounds.Location.X + 14), (float)(e.RowBounds.Location.Y + 4));
				}
				IL_97:
				goto IL_FA;
				IL_99:;
			}
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_B3:
			goto IL_EF;
			IL_B5:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_CD:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_B5;
		}
		IL_EF:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_FA:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x060007A9 RID: 1961 RVA: 0x000054F2 File Offset: 0x000036F2
	private void DumpGrid_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (this.dumpExporter_0 != null)
		{
			this.dumpExporter_0.Dispose();
			this.dumpExporter_0 = null;
		}
	}

	// Token: 0x060007AA RID: 1962 RVA: 0x00005511 File Offset: 0x00003711
	[CompilerGenerated]
	[DebuggerHidden]
	private string method_10(string string_3)
	{
		return Conversions.ToString(this.method_4(string_3));
	}

	// Token: 0x04000403 RID: 1027
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ID")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	// Token: 0x04000409 RID: 1033
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_0;

	// Token: 0x0400040A RID: 1034
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_1;

	// Token: 0x0400040B RID: 1035
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<string> list_0;

	// Token: 0x0400040C RID: 1036
	private DumpExporter dumpExporter_0;

	// Token: 0x0400040D RID: 1037
	private Dumper dumper_0;

	// Token: 0x0400040E RID: 1038
	private static string string_2;

	// Token: 0x02000088 RID: 136
	// (Invoke) Token: 0x060007AE RID: 1966
	private delegate void Delegate31();

	// Token: 0x02000089 RID: 137
	// (Invoke) Token: 0x060007B2 RID: 1970
	private delegate string Delegate32(List<string> lValues);

	// Token: 0x0200008A RID: 138
	// (Invoke) Token: 0x060007B6 RID: 1974
	private delegate bool Delegate33(string sID, int iColumn, string sValue);

	// Token: 0x0200008B RID: 139
	// (Invoke) Token: 0x060007BA RID: 1978
	private delegate string Delegate34(string sID);
}
