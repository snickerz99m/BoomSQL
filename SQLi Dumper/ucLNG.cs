using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x02000060 RID: 96
[DesignerGenerated]
public class ucLNG : UserControl
{
	// Token: 0x060002D4 RID: 724 RVA: 0x00015840 File Offset: 0x00013A40
	public ucLNG(int index, string section, string key, string value)
	{
		this.InitializeComponent();
		this.lblSection.Text = section;
		this.lblKey.Text = key;
		this.txtValue.Text = value;
		this.lblIndex.Text = Conversions.ToString(index);
	}

	// Token: 0x060002D5 RID: 725 RVA: 0x00015890 File Offset: 0x00013A90
	[DebuggerNonUserCode]
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

	// Token: 0x060002D6 RID: 726 RVA: 0x000158D4 File Offset: 0x00013AD4
	[DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.TableLayoutPanel1 = new TableLayoutPanel();
		this.txtValue = new TextBox();
		this.lblSection = new Label();
		this.lblKey = new Label();
		this.lblIndex = new Label();
		this.TableLayoutPanel1.SuspendLayout();
		base.SuspendLayout();
		this.TableLayoutPanel1.ColumnCount = 4;
		this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.30303f));
		this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.09925f));
		this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.2367f));
		this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.36102f));
		this.TableLayoutPanel1.Controls.Add(this.lblIndex, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.txtValue, 3, 0);
		this.TableLayoutPanel1.Controls.Add(this.lblSection, 1, 0);
		this.TableLayoutPanel1.Controls.Add(this.lblKey, 2, 0);
		this.TableLayoutPanel1.Dock = DockStyle.Fill;
		this.TableLayoutPanel1.Location = new Point(0, 0);
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		this.TableLayoutPanel1.Size = new Size(913, 32);
		this.TableLayoutPanel1.TabIndex = 0;
		this.txtValue.Dock = DockStyle.Fill;
		this.txtValue.Location = new Point(382, 3);
		this.txtValue.Name = "txtValue";
		this.txtValue.Size = new Size(528, 26);
		this.txtValue.TabIndex = 0;
		this.lblSection.AutoSize = true;
		this.lblSection.Dock = DockStyle.Fill;
		this.lblSection.Location = new Point(51, 0);
		this.lblSection.Name = "lblSection";
		this.lblSection.Size = new Size(159, 32);
		this.lblSection.TabIndex = 1;
		this.lblSection.Text = "lblSection";
		this.lblSection.TextAlign = ContentAlignment.MiddleRight;
		this.lblKey.AutoSize = true;
		this.lblKey.Dock = DockStyle.Fill;
		this.lblKey.Location = new Point(216, 0);
		this.lblKey.Name = "lblKey";
		this.lblKey.Size = new Size(160, 32);
		this.lblKey.TabIndex = 2;
		this.lblKey.Text = "lblKey";
		this.lblKey.TextAlign = ContentAlignment.MiddleRight;
		this.lblIndex.AutoSize = true;
		this.lblIndex.Dock = DockStyle.Fill;
		this.lblIndex.Location = new Point(3, 0);
		this.lblIndex.Name = "lblIndex";
		this.lblIndex.Size = new Size(42, 32);
		this.lblIndex.TabIndex = 3;
		this.lblIndex.Text = "0";
		this.lblIndex.TextAlign = ContentAlignment.MiddleRight;
		base.AutoScaleDimensions = new SizeF(9f, 20f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(this.TableLayoutPanel1);
		base.Name = "ucLNG";
		base.Size = new Size(913, 32);
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		base.ResumeLayout(false);
	}

	// Token: 0x170000BF RID: 191
	// (get) Token: 0x060002D7 RID: 727 RVA: 0x0000327B File Offset: 0x0000147B
	// (set) Token: 0x060002D8 RID: 728 RVA: 0x00003283 File Offset: 0x00001483
	internal virtual TableLayoutPanel TableLayoutPanel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000C0 RID: 192
	// (get) Token: 0x060002D9 RID: 729 RVA: 0x0000328C File Offset: 0x0000148C
	// (set) Token: 0x060002DA RID: 730 RVA: 0x00003294 File Offset: 0x00001494
	internal virtual TextBox txtValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000C1 RID: 193
	// (get) Token: 0x060002DB RID: 731 RVA: 0x0000329D File Offset: 0x0000149D
	// (set) Token: 0x060002DC RID: 732 RVA: 0x000032A5 File Offset: 0x000014A5
	internal virtual Label lblSection { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000C2 RID: 194
	// (get) Token: 0x060002DD RID: 733 RVA: 0x000032AE File Offset: 0x000014AE
	// (set) Token: 0x060002DE RID: 734 RVA: 0x000032B6 File Offset: 0x000014B6
	internal virtual Label lblKey { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000C3 RID: 195
	// (get) Token: 0x060002DF RID: 735 RVA: 0x000032BF File Offset: 0x000014BF
	// (set) Token: 0x060002E0 RID: 736 RVA: 0x000032C7 File Offset: 0x000014C7
	internal virtual Label lblIndex { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170000C4 RID: 196
	// (get) Token: 0x060002E1 RID: 737 RVA: 0x00015CAC File Offset: 0x00013EAC
	public string Section
	{
		get
		{
			return this.lblSection.Text;
		}
	}

	// Token: 0x170000C5 RID: 197
	// (get) Token: 0x060002E2 RID: 738 RVA: 0x00015CC8 File Offset: 0x00013EC8
	public string Key
	{
		get
		{
			return this.lblKey.Text;
		}
	}

	// Token: 0x170000C6 RID: 198
	// (get) Token: 0x060002E3 RID: 739 RVA: 0x00015CE4 File Offset: 0x00013EE4
	public string Value
	{
		get
		{
			return this.txtValue.Text;
		}
	}

	// Token: 0x040001DE RID: 478
	private IContainer icontainer_0;
}
