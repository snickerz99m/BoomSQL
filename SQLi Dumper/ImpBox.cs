using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x020000B6 RID: 182
[DesignerGenerated]
public partial class ImpBox : Form
{
	// Token: 0x06000A76 RID: 2678 RVA: 0x0000657F File Offset: 0x0000477F
	public ImpBox()
	{
		base.Load += this.ImpBox_Load;
		this.MinLengh = 1;
		this.InitializeComponent();
	}

	// Token: 0x17000330 RID: 816
	// (get) Token: 0x06000A79 RID: 2681 RVA: 0x000065A6 File Offset: 0x000047A6
	// (set) Token: 0x06000A7A RID: 2682 RVA: 0x000411C8 File Offset: 0x0003F3C8
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
			EventHandler value2 = new EventHandler(this.method_0);
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

	// Token: 0x17000331 RID: 817
	// (get) Token: 0x06000A7B RID: 2683 RVA: 0x000065AE File Offset: 0x000047AE
	// (set) Token: 0x06000A7C RID: 2684 RVA: 0x0004120C File Offset: 0x0003F40C
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
			EventHandler value2 = new EventHandler(this.method_1);
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

	// Token: 0x17000332 RID: 818
	// (get) Token: 0x06000A7D RID: 2685 RVA: 0x000065B6 File Offset: 0x000047B6
	// (set) Token: 0x06000A7E RID: 2686 RVA: 0x00041250 File Offset: 0x0003F450
	internal virtual TextBox txtValue
	{
		[CompilerGenerated]
		get
		{
			return this._txtValue;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_2);
			TextBox txtValue = this._txtValue;
			if (txtValue != null)
			{
				txtValue.TextChanged -= value2;
			}
			this._txtValue = value;
			txtValue = this._txtValue;
			if (txtValue != null)
			{
				txtValue.TextChanged += value2;
			}
		}
	}

	// Token: 0x17000333 RID: 819
	// (get) Token: 0x06000A7F RID: 2687 RVA: 0x000065BE File Offset: 0x000047BE
	// (set) Token: 0x06000A80 RID: 2688 RVA: 0x000065C6 File Offset: 0x000047C6
	public int MinLengh { get; set; }

	// Token: 0x06000A81 RID: 2689 RVA: 0x00003402 File Offset: 0x00001602
	private void method_0(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		base.Close();
	}

	// Token: 0x06000A82 RID: 2690 RVA: 0x00003411 File Offset: 0x00001611
	private void method_1(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		base.Close();
	}

	// Token: 0x06000A83 RID: 2691 RVA: 0x00041294 File Offset: 0x0003F494
	private void method_2(object sender, EventArgs e)
	{
		this.txtValue.Text = this.txtValue.Text.Replace(" ", "");
		this.OK_Button.Enabled = (!string.IsNullOrEmpty(this.txtValue.Text) & this.txtValue.Text.Length >= this.MinLengh);
	}

	// Token: 0x06000A84 RID: 2692 RVA: 0x00041300 File Offset: 0x0003F500
	private void ImpBox_Load(object sender, EventArgs e)
	{
		Globals.AddMouseMoveForm(this);
		this.Cancel_Button.Text = Globals.translate_0.GetStr("PathAdd", "Cancel_Button", "Cancel");
		this.OK_Button.Text = Globals.translate_0.GetStr("PathAdd", "OK_Button", "OK");
	}

	// Token: 0x0400052F RID: 1327
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int int_0;
}
