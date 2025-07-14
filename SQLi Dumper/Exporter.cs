using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x020000B4 RID: 180
[DesignerGenerated]
public partial class Exporter : Form
{
	// Token: 0x06000A4F RID: 2639 RVA: 0x0003FA40 File Offset: 0x0003DC40
	public Exporter(DataGridView grid)
	{
		base.FormClosing += this.Exporter_FormClosing;
		base.Load += this.Exporter_Load;
		this.InitializeComponent();
		this.dataGridView_0 = grid;
		global::Globals.AddMouseMoveForm(this);
		global::Globals.translate_0.Add(this, this.icontainer_0);
	}

	// Token: 0x17000322 RID: 802
	// (get) Token: 0x06000A52 RID: 2642 RVA: 0x00006480 File Offset: 0x00004680
	// (set) Token: 0x06000A53 RID: 2643 RVA: 0x000404F0 File Offset: 0x0003E6F0
	internal virtual Button OK_Button
	{
		[CompilerGenerated]
		get
		{
			return this._OK_Button;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_2);
			Button ok_Button = this._OK_Button;
			if (ok_Button != null)
			{
				ok_Button.Click -= value2;
			}
			this._OK_Button = value;
			ok_Button = this._OK_Button;
			if (ok_Button != null)
			{
				ok_Button.Click += value2;
			}
		}
	}

	// Token: 0x17000323 RID: 803
	// (get) Token: 0x06000A54 RID: 2644 RVA: 0x00006488 File Offset: 0x00004688
	// (set) Token: 0x06000A55 RID: 2645 RVA: 0x00040534 File Offset: 0x0003E734
	internal virtual Button Cancel_Button
	{
		[CompilerGenerated]
		get
		{
			return this._Cancel_Button;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_3);
			Button cancel_Button = this._Cancel_Button;
			if (cancel_Button != null)
			{
				cancel_Button.Click -= value2;
			}
			this._Cancel_Button = value;
			cancel_Button = this._Cancel_Button;
			if (cancel_Button != null)
			{
				cancel_Button.Click += value2;
			}
		}
	}

	// Token: 0x17000324 RID: 804
	// (get) Token: 0x06000A56 RID: 2646 RVA: 0x00006490 File Offset: 0x00004690
	// (set) Token: 0x06000A57 RID: 2647 RVA: 0x00006498 File Offset: 0x00004698
	internal virtual GroupBox grbDelimiter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000325 RID: 805
	// (get) Token: 0x06000A58 RID: 2648 RVA: 0x000064A1 File Offset: 0x000046A1
	// (set) Token: 0x06000A59 RID: 2649 RVA: 0x00040578 File Offset: 0x0003E778
	internal virtual RadioButton rdbOpt1
	{
		[CompilerGenerated]
		get
		{
			return this._rdbOpt1;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_4);
			EventHandler value3 = new EventHandler(this.method_4);
			RadioButton rdbOpt = this._rdbOpt1;
			if (rdbOpt != null)
			{
				rdbOpt.CheckedChanged -= value2;
				rdbOpt.CheckedChanged -= value3;
			}
			this._rdbOpt1 = value;
			rdbOpt = this._rdbOpt1;
			if (rdbOpt != null)
			{
				rdbOpt.CheckedChanged += value2;
				rdbOpt.CheckedChanged += value3;
			}
		}
	}

	// Token: 0x17000326 RID: 806
	// (get) Token: 0x06000A5A RID: 2650 RVA: 0x000064A9 File Offset: 0x000046A9
	// (set) Token: 0x06000A5B RID: 2651 RVA: 0x000064B1 File Offset: 0x000046B1
	internal virtual RadioButton rdbOpt2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000327 RID: 807
	// (get) Token: 0x06000A5C RID: 2652 RVA: 0x000064BA File Offset: 0x000046BA
	// (set) Token: 0x06000A5D RID: 2653 RVA: 0x000064C2 File Offset: 0x000046C2
	internal virtual TextBox txtDeli { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000328 RID: 808
	// (get) Token: 0x06000A5E RID: 2654 RVA: 0x000064CB File Offset: 0x000046CB
	// (set) Token: 0x06000A5F RID: 2655 RVA: 0x000064D3 File Offset: 0x000046D3
	internal virtual BackgroundWorker bwSave { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000329 RID: 809
	// (get) Token: 0x06000A60 RID: 2656 RVA: 0x000064DC File Offset: 0x000046DC
	// (set) Token: 0x06000A61 RID: 2657 RVA: 0x000064E4 File Offset: 0x000046E4
	internal virtual GroupBox grbColumns { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700032A RID: 810
	// (get) Token: 0x06000A62 RID: 2658 RVA: 0x000064ED File Offset: 0x000046ED
	// (set) Token: 0x06000A63 RID: 2659 RVA: 0x000064F5 File Offset: 0x000046F5
	internal virtual CheckedListBox lsColumns { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700032B RID: 811
	// (get) Token: 0x06000A64 RID: 2660 RVA: 0x000064FE File Offset: 0x000046FE
	// (set) Token: 0x06000A65 RID: 2661 RVA: 0x00006506 File Offset: 0x00004706
	internal virtual GroupBox grbType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700032C RID: 812
	// (get) Token: 0x06000A66 RID: 2662 RVA: 0x0000650F File Offset: 0x0000470F
	// (set) Token: 0x06000A67 RID: 2663 RVA: 0x000405D8 File Offset: 0x0003E7D8
	internal virtual RadioButton rdpType_2
	{
		[CompilerGenerated]
		get
		{
			return this._rdpType_2;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_5);
			RadioButton rdpType_ = this._rdpType_2;
			if (rdpType_ != null)
			{
				rdpType_.CheckedChanged -= value2;
			}
			this._rdpType_2 = value;
			rdpType_ = this._rdpType_2;
			if (rdpType_ != null)
			{
				rdpType_.CheckedChanged += value2;
			}
		}
	}

	// Token: 0x1700032D RID: 813
	// (get) Token: 0x06000A68 RID: 2664 RVA: 0x00006517 File Offset: 0x00004717
	// (set) Token: 0x06000A69 RID: 2665 RVA: 0x0004061C File Offset: 0x0003E81C
	internal virtual RadioButton rdpType_1
	{
		[CompilerGenerated]
		get
		{
			return this._rdpType_1;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_5);
			RadioButton rdpType_ = this._rdpType_1;
			if (rdpType_ != null)
			{
				rdpType_.CheckedChanged -= value2;
			}
			this._rdpType_1 = value;
			rdpType_ = this._rdpType_1;
			if (rdpType_ != null)
			{
				rdpType_.CheckedChanged += value2;
			}
		}
	}

	// Token: 0x1700032E RID: 814
	// (get) Token: 0x06000A6A RID: 2666 RVA: 0x0000651F File Offset: 0x0000471F
	// (set) Token: 0x06000A6B RID: 2667 RVA: 0x00040660 File Offset: 0x0003E860
	internal virtual RadioButton rdpType_3
	{
		[CompilerGenerated]
		get
		{
			return this._rdpType_3;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_5);
			RadioButton rdpType_ = this._rdpType_3;
			if (rdpType_ != null)
			{
				rdpType_.CheckedChanged -= value2;
			}
			this._rdpType_3 = value;
			rdpType_ = this._rdpType_3;
			if (rdpType_ != null)
			{
				rdpType_.CheckedChanged += value2;
			}
		}
	}

	// Token: 0x1700032F RID: 815
	// (get) Token: 0x06000A6C RID: 2668 RVA: 0x00006527 File Offset: 0x00004727
	// (set) Token: 0x06000A6D RID: 2669 RVA: 0x0000652F File Offset: 0x0000472F
	internal virtual Panel Panel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x06000A6E RID: 2670 RVA: 0x000406A4 File Offset: 0x0003E8A4
	private string method_0(string string_3)
	{
		return SecurityElement.Escape(string_3);
	}

	// Token: 0x06000A6F RID: 2671 RVA: 0x000406BC File Offset: 0x0003E8BC
	private void method_1(string string_3)
	{
		StreamWriter streamWriter = null;
		checked
		{
			try
			{
				this.bool_0 = true;
				streamWriter = new StreamWriter(string_3);
				int num = this.lsColumns.Items.Count - 1;
				bool flag;
				for (int i = 0; i <= num; i++)
				{
					if (this.lsColumns.GetItemChecked(i))
					{
						switch (this.enFileTytpe_0)
						{
						case Exporter.enFileTytpe.const_0:
							if (flag)
							{
								streamWriter.Write(Operators.ConcatenateObject(this.string_2, this.lsColumns.Items[i]));
							}
							else
							{
								streamWriter.Write(this.method_0(global::Globals.APP_VERSION));
								streamWriter.WriteLine();
								streamWriter.Write(DateAndTime.Now.ToString());
								streamWriter.WriteLine();
								streamWriter.WriteLine();
								streamWriter.Write(RuntimeHelpers.GetObjectValue(this.lsColumns.Items[i]));
							}
							break;
						case Exporter.enFileTytpe.HTML:
							if (!flag)
							{
								streamWriter.WriteLine("<html>");
								streamWriter.WriteLine("<title>" + this.method_0(global::Globals.APP_VERSION) + "</title>");
								streamWriter.WriteLine("<body>");
								streamWriter.WriteLine("<table border>");
								streamWriter.WriteLine("<tr>");
							}
							streamWriter.WriteLine(Operators.ConcatenateObject(Operators.ConcatenateObject("<td>", this.lsColumns.Items[i]), "</td>"));
							break;
						case Exporter.enFileTytpe.const_2:
							if (!flag)
							{
								streamWriter.WriteLine("<DocumentElement>");
								streamWriter.WriteLine("<AppVersion>" + this.method_0(global::Globals.APP_VERSION) + "</AppVersion>");
							}
							break;
						}
						flag = true;
					}
				}
				switch (this.enFileTytpe_0)
				{
				case Exporter.enFileTytpe.const_0:
					streamWriter.WriteLine();
					break;
				case Exporter.enFileTytpe.HTML:
					streamWriter.WriteLine("</tr>");
					break;
				}
				flag = false;
				int num2 = this.dataGridView_0.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					int num3 = this.lsColumns.Items.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						if (this.lsColumns.GetItemChecked(k))
						{
							string text = Conversions.ToString(this.dataGridView_0.Rows[j].Cells[k + 1].Value);
							switch (this.enFileTytpe_0)
							{
							case Exporter.enFileTytpe.const_0:
								if (flag)
								{
									streamWriter.Write(this.string_2 + text);
								}
								else
								{
									streamWriter.Write(text);
								}
								break;
							case Exporter.enFileTytpe.HTML:
								if (!flag)
								{
									streamWriter.WriteLine("<tr>");
								}
								streamWriter.WriteLine("<td>" + SecurityElement.Escape(text) + "</td>");
								break;
							case Exporter.enFileTytpe.const_2:
								if (!flag)
								{
									streamWriter.WriteLine("<item>");
								}
								streamWriter.WriteLine(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("<", this.lsColumns.Items[k]), ">"), this.method_0(text)), "</"), this.lsColumns.Items[k]), ">"));
								break;
							}
						}
						flag = true;
					}
					switch (this.enFileTytpe_0)
					{
					case Exporter.enFileTytpe.const_0:
						streamWriter.WriteLine();
						break;
					case Exporter.enFileTytpe.HTML:
						streamWriter.WriteLine("</tr>");
						break;
					case Exporter.enFileTytpe.const_2:
						streamWriter.WriteLine("</item>");
						break;
					}
					flag = false;
				}
				switch (this.enFileTytpe_0)
				{
				case Exporter.enFileTytpe.HTML:
					streamWriter.WriteLine("</body>");
					streamWriter.WriteLine("</html>");
					break;
				case Exporter.enFileTytpe.const_2:
					streamWriter.WriteLine("</DocumentElement>");
					break;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			finally
			{
				if (streamWriter != null)
				{
					streamWriter.Close();
				}
			}
		}
	}

	// Token: 0x06000A70 RID: 2672 RVA: 0x00040B08 File Offset: 0x0003ED08
	private void method_2(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				int num = this.lsColumns.Items.Count - 1;
				bool flag;
				for (int i = 0; i <= num; i++)
				{
					if (this.lsColumns.GetItemChecked(i))
					{
						flag = true;
					}
				}
				if (!unchecked(-(flag > false)))
				{
					Interaction.Beep();
					Interaction.MsgBox("Selected the column(s).", MsgBoxStyle.OkOnly, null);
				}
				else
				{
					if (this.rdbOpt1.Checked)
					{
						this.string_2 = "\t";
					}
					else
					{
						this.string_2 = this.txtDeli.Text;
					}
					using (SaveFileDialog saveFileDialog = new SaveFileDialog())
					{
						saveFileDialog.Title = "Save as..";
						saveFileDialog.FileName = this.string_1;
						saveFileDialog.InitialDirectory = this.string_0;
						bool flag2;
						if ((flag2 = true) == this.rdpType_1.Checked)
						{
							this.enFileTytpe_0 = Exporter.enFileTytpe.const_0;
							saveFileDialog.Filter = "Text File|*.txt";
							saveFileDialog.FileName = Path.ChangeExtension(saveFileDialog.FileName, "txt");
						}
						else if (flag2 == this.rdpType_2.Checked)
						{
							this.enFileTytpe_0 = Exporter.enFileTytpe.HTML;
							saveFileDialog.Filter = "HTML File|*.html";
							saveFileDialog.FileName = Path.ChangeExtension(saveFileDialog.FileName, "html");
						}
						else if (flag2 == this.rdpType_3.Checked)
						{
							this.enFileTytpe_0 = Exporter.enFileTytpe.const_2;
							saveFileDialog.Filter = "XML File|*.xml";
							saveFileDialog.FileName = Path.ChangeExtension(saveFileDialog.FileName, "xml");
						}
						if (saveFileDialog.ShowDialog() == DialogResult.OK)
						{
							this.Cursor = Cursors.WaitCursor;
							Application.DoEvents();
							this.string_0 = saveFileDialog.FileName.Substring(0, saveFileDialog.FileName.LastIndexOf("\\"));
							this.string_1 = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf("\\") + 1);
							this.method_1(saveFileDialog.FileName);
							this.Cursor = Cursors.Default;
							MessageBox.Show("Data export completed successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}

	// Token: 0x06000A71 RID: 2673 RVA: 0x00003411 File Offset: 0x00001611
	private void method_3(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		base.Close();
	}

	// Token: 0x06000A72 RID: 2674 RVA: 0x00006538 File Offset: 0x00004738
	private void method_4(object sender, EventArgs e)
	{
		this.txtDeli.Enabled = this.rdbOpt2.Checked;
	}

	// Token: 0x06000A73 RID: 2675 RVA: 0x00040D60 File Offset: 0x0003EF60
	private void Exporter_FormClosing(object sender, FormClosingEventArgs e)
	{
		checked
		{
			try
			{
				Class50.smethod_4(this.dataGridView_0.Name, "LastPath", this.string_0, null);
				Class50.smethod_4(this.dataGridView_0.Name, "LastFileName", this.string_1, null);
				Class50.smethod_3(this, null);
				int num = this.lsColumns.Items.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string text = Conversions.ToString(this.lsColumns.Items[i]);
					Class50.smethod_4(this.lsColumns.Name, text, this.lsColumns.GetItemChecked(i).ToString(), null);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	// Token: 0x06000A74 RID: 2676 RVA: 0x00040E40 File Offset: 0x0003F040
	private void Exporter_Load(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				Class50.smethod_2(this, null);
				this.string_0 = Class50.smethod_5(this.dataGridView_0.Name, "LastPath", global::Globals.APP_PATH, null);
				this.string_1 = Class50.smethod_5(this.dataGridView_0.Name, "LastFileName", "Checkeds", null);
				this.lsColumns.Items.Clear();
				int num = this.dataGridView_0.Columns.Count - 1;
				for (int i = 1; i <= num; i++)
				{
					string headerText = this.dataGridView_0.Columns[i].HeaderText;
					this.lsColumns.Items.Add(headerText);
					this.lsColumns.SetItemChecked(i - 1, Conversions.ToBoolean(Class50.smethod_5(this.lsColumns.Name, headerText, (i < 3).ToString(), null)));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	// Token: 0x06000A75 RID: 2677 RVA: 0x00006550 File Offset: 0x00004750
	private void method_5(object sender, EventArgs e)
	{
		global::Globals.LockWindowUpdate(base.Handle);
		this.grbDelimiter.Visible = this.rdpType_1.Checked;
		global::Globals.LockWindowUpdate(IntPtr.Zero);
	}

	// Token: 0x04000519 RID: 1305
	[AccessedThroughProperty("bwSave")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BackgroundWorker backgroundWorker_0;

	// Token: 0x04000521 RID: 1313
	private string string_0;

	// Token: 0x04000522 RID: 1314
	private string string_1;

	// Token: 0x04000523 RID: 1315
	private bool bool_0;

	// Token: 0x04000524 RID: 1316
	private Exporter.enFileTytpe enFileTytpe_0;

	// Token: 0x04000525 RID: 1317
	private string string_2;

	// Token: 0x04000526 RID: 1318
	private DataGridView dataGridView_0;

	// Token: 0x020000B5 RID: 181
	public enum enFileTytpe
	{
		// Token: 0x04000528 RID: 1320
		const_0,
		// Token: 0x04000529 RID: 1321
		HTML,
		// Token: 0x0400052A RID: 1322
		const_2
	}
}
