using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x020000C1 RID: 193
[DesignerGenerated]
public partial class HttpLog : Form
{
	// Token: 0x06000B20 RID: 2848 RVA: 0x00044CB4 File Offset: 0x00042EB4
	public HttpLog(ToolStripButton t, Panel b, DataGridView g)
	{
		base.Closing += this.HttpLog_Closing;
		this.InitializeComponent();
		this.toolStripButton_0 = t;
		this.panel_0 = b;
		this.dataGridView_0 = g;
		Globals.AddMouseMoveForm(this);
		Globals.translate_0.Add(this, this.icontainer_0);
	}

	// Token: 0x06000B23 RID: 2851 RVA: 0x00044DC8 File Offset: 0x00042FC8
	private void HttpLog_Closing(object sender, CancelEventArgs e)
	{
		Globals.LockWindowUpdate(Globals.GMain.Handle);
		this.toolStripButton_0.Checked = false;
		this.panel_0.Visible = false;
		this.toolStripButton_0.Visible = true;
		this.panel_0.Controls.Add(this.dataGridView_0);
		Globals.LockWindowUpdate(IntPtr.Zero);
	}

	// Token: 0x04000575 RID: 1397
	private ToolStripButton toolStripButton_0;

	// Token: 0x04000576 RID: 1398
	private Panel panel_0;

	// Token: 0x04000577 RID: 1399
	private DataGridView dataGridView_0;
}
