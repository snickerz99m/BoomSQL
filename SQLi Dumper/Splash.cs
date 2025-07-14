using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x020000E4 RID: 228
[DesignerGenerated]
public sealed partial class Splash : Form
{
	// Token: 0x06000FDF RID: 4063 RVA: 0x00008A21 File Offset: 0x00006C21
	public Splash()
	{
		base.Paint += this.Splash_Paint;
		base.Load += this.Splash_Load;
		this.string_0 = "";
		this.InitializeComponent();
	}

	// Token: 0x06000FE2 RID: 4066 RVA: 0x00008A5E File Offset: 0x00006C5E
	public void SetLoading(string sMsg)
	{
		if (!Globals.IS_DUMP_INSTANCE)
		{
			this.string_0 = sMsg;
			this.Refresh();
		}
	}

	// Token: 0x06000FE3 RID: 4067 RVA: 0x0006D35C File Offset: 0x0006B55C
	private void Splash_Paint(object sender, PaintEventArgs e)
	{
		if (!string.IsNullOrEmpty(this.string_0))
		{
			e.Graphics.DrawString(this.string_0.ToString(), new Font("Courier New", 9f, FontStyle.Bold), new SolidBrush(this.ForeColor), new Point(11, 165));
		}
	}

	// Token: 0x06000FE4 RID: 4068 RVA: 0x0006D3BC File Offset: 0x0006B5BC
	private void Splash_Load(object sender, EventArgs e)
	{
		base.UseWaitCursor = true;
		this.Cursor = Cursors.WaitCursor;
		base.Size = checked(new Size((int)Math.Round((double)Class6.about.Size.Width / 1.2), (int)Math.Round((double)Class6.about.Size.Height / 1.2)));
	}

	// Token: 0x040007E6 RID: 2022
	private string string_0;
}
