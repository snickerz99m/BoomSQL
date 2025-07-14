using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x020000E5 RID: 229
[DesignerGenerated]
public partial class TranslateLNG : Form
{
	// Token: 0x06000FE5 RID: 4069 RVA: 0x0006D42C File Offset: 0x0006B62C
	public TranslateLNG()
	{
		base.Load += this.TranslateLNG_Load;
		this.class51_0 = new Class51(Globals.LNG_PATH + "\\Russian.xml", "SQLi_Dumper", ';', 0);
		this.InitializeComponent();
	}

	// Token: 0x170004F7 RID: 1271
	// (get) Token: 0x06000FE8 RID: 4072 RVA: 0x00008A77 File Offset: 0x00006C77
	// (set) Token: 0x06000FE9 RID: 4073 RVA: 0x00008A7F File Offset: 0x00006C7F
	internal virtual ToolStrip tsChecked { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004F8 RID: 1272
	// (get) Token: 0x06000FEA RID: 4074 RVA: 0x00008A88 File Offset: 0x00006C88
	// (set) Token: 0x06000FEB RID: 4075 RVA: 0x00008A90 File Offset: 0x00006C90
	internal virtual ToolStripTextBox cmbFileInclusaoSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004F9 RID: 1273
	// (get) Token: 0x06000FEC RID: 4076 RVA: 0x00008A99 File Offset: 0x00006C99
	// (set) Token: 0x06000FED RID: 4077 RVA: 0x00008AA1 File Offset: 0x00006CA1
	internal virtual ToolStripButton btnSave { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004FA RID: 1274
	// (get) Token: 0x06000FEE RID: 4078 RVA: 0x00008AAA File Offset: 0x00006CAA
	// (set) Token: 0x06000FEF RID: 4079 RVA: 0x00008AB2 File Offset: 0x00006CB2
	internal virtual StatusStrip stMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004FB RID: 1275
	// (get) Token: 0x06000FF0 RID: 4080 RVA: 0x00008ABB File Offset: 0x00006CBB
	// (set) Token: 0x06000FF1 RID: 4081 RVA: 0x00008AC3 File Offset: 0x00006CC3
	internal virtual ToolStripStatusLabel lblMainStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004FC RID: 1276
	// (get) Token: 0x06000FF2 RID: 4082 RVA: 0x00008ACC File Offset: 0x00006CCC
	// (set) Token: 0x06000FF3 RID: 4083 RVA: 0x00008AD4 File Offset: 0x00006CD4
	internal virtual Panel pnlControls { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x06000FF4 RID: 4084 RVA: 0x0006D85C File Offset: 0x0006BA5C
	private void TranslateLNG_Load(object sender, EventArgs e)
	{
		base.SuspendLayout();
		List<ucLNG> list = new List<ucLNG>();
		int num = 1;
		checked
		{
			try
			{
				foreach (object value in this.class51_0.method_1().Keys)
				{
					string string_ = Conversions.ToString(value);
					try
					{
						foreach (object obj in this.class51_0.method_2(string_).Values)
						{
							Class52 @class = (Class52)obj;
							list.Add(new ucLNG(num, @class.String_2, @class.String_0, @class.String_1)
							{
								Dock = DockStyle.Top
							});
							num++;
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
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			this.pnlControls.Controls.AddRange(list.ToArray());
			base.ResumeLayout();
			base.Invalidate();
			this.Refresh();
		}
	}

	// Token: 0x040007EE RID: 2030
	private Class51 class51_0;
}
