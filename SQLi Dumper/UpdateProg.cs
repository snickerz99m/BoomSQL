using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x020000E6 RID: 230
[DesignerGenerated]
public partial class UpdateProg : Form
{
	// Token: 0x06000FF5 RID: 4085 RVA: 0x00008ADD File Offset: 0x00006CDD
	public UpdateProg()
	{
		this.InitializeComponent();
		Globals.AddMouseMoveForm(this);
		Globals.translate_0.Add(this, this.icontainer_0);
	}

	// Token: 0x170004FD RID: 1277
	// (get) Token: 0x06000FF8 RID: 4088 RVA: 0x00008B02 File Offset: 0x00006D02
	// (set) Token: 0x06000FF9 RID: 4089 RVA: 0x0006DB58 File Offset: 0x0006BD58
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
			EventHandler value2 = new EventHandler(this.method_0);
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

	// Token: 0x170004FE RID: 1278
	// (get) Token: 0x06000FFA RID: 4090 RVA: 0x00008B0A File Offset: 0x00006D0A
	// (set) Token: 0x06000FFB RID: 4091 RVA: 0x00008B12 File Offset: 0x00006D12
	internal virtual ProgressBar prbDownload { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170004FF RID: 1279
	// (get) Token: 0x06000FFC RID: 4092 RVA: 0x00008B1B File Offset: 0x00006D1B
	// (set) Token: 0x06000FFD RID: 4093 RVA: 0x00008B23 File Offset: 0x00006D23
	public bool Cancel { get; set; }

	// Token: 0x06000FFE RID: 4094 RVA: 0x00008B2C File Offset: 0x00006D2C
	private void method_0(object sender, EventArgs e)
	{
		this.Cancel = true;
		this.Cancel_Button.Enabled = false;
	}

	// Token: 0x040007F2 RID: 2034
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool bool_0;
}
