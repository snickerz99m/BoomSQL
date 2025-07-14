using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x020000E8 RID: 232
[DesignerGenerated]
public partial class WafAdd : Form
{
	// Token: 0x0600100B RID: 4107 RVA: 0x00008B85 File Offset: 0x00006D85
	public WafAdd()
	{
		this.InitializeComponent();
		Globals.AddMouseMoveForm(this);
		Globals.translate_0.Add(this, this.icontainer_0);
	}

	// Token: 0x17000503 RID: 1283
	// (get) Token: 0x0600100E RID: 4110 RVA: 0x00008BAA File Offset: 0x00006DAA
	// (set) Token: 0x0600100F RID: 4111 RVA: 0x0006E31C File Offset: 0x0006C51C
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

	// Token: 0x17000504 RID: 1284
	// (get) Token: 0x06001010 RID: 4112 RVA: 0x00008BB2 File Offset: 0x00006DB2
	// (set) Token: 0x06001011 RID: 4113 RVA: 0x00008BBA File Offset: 0x00006DBA
	internal virtual Button Cancel_Button { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000505 RID: 1285
	// (get) Token: 0x06001012 RID: 4114 RVA: 0x00008BC3 File Offset: 0x00006DC3
	// (set) Token: 0x06001013 RID: 4115 RVA: 0x00008BCB File Offset: 0x00006DCB
	internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000506 RID: 1286
	// (get) Token: 0x06001014 RID: 4116 RVA: 0x00008BD4 File Offset: 0x00006DD4
	// (set) Token: 0x06001015 RID: 4117 RVA: 0x0006E360 File Offset: 0x0006C560
	internal virtual TextBox txtEnding
	{
		[CompilerGenerated]
		get
		{
			return this._txtEnding;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_0);
			EventHandler value3 = new EventHandler(this.method_1);
			TextBox txtEnding = this._txtEnding;
			if (txtEnding != null)
			{
				txtEnding.TextChanged -= value2;
				txtEnding.Leave -= value3;
			}
			this._txtEnding = value;
			txtEnding = this._txtEnding;
			if (txtEnding != null)
			{
				txtEnding.TextChanged += value2;
				txtEnding.Leave += value3;
			}
		}
	}

	// Token: 0x17000507 RID: 1287
	// (get) Token: 0x06001016 RID: 4118 RVA: 0x00008BDC File Offset: 0x00006DDC
	// (set) Token: 0x06001017 RID: 4119 RVA: 0x00008BE4 File Offset: 0x00006DE4
	internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000508 RID: 1288
	// (get) Token: 0x06001018 RID: 4120 RVA: 0x00008BED File Offset: 0x00006DED
	// (set) Token: 0x06001019 RID: 4121 RVA: 0x0006E3C0 File Offset: 0x0006C5C0
	internal virtual TextBox txtOutset
	{
		[CompilerGenerated]
		get
		{
			return this._txtOutset;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_0);
			EventHandler value3 = new EventHandler(this.method_1);
			TextBox txtOutset = this._txtOutset;
			if (txtOutset != null)
			{
				txtOutset.TextChanged -= value2;
				txtOutset.Leave -= value3;
			}
			this._txtOutset = value;
			txtOutset = this._txtOutset;
			if (txtOutset != null)
			{
				txtOutset.TextChanged += value2;
				txtOutset.Leave += value3;
			}
		}
	}

	// Token: 0x0600101A RID: 4122 RVA: 0x00008BF5 File Offset: 0x00006DF5
	private void method_0(object sender, EventArgs e)
	{
		this.OK_Button.Enabled = (!string.IsNullOrEmpty(this.txtOutset.Text) | !string.IsNullOrEmpty(this.txtEnding.Text));
	}

	// Token: 0x0600101B RID: 4123 RVA: 0x0006E420 File Offset: 0x0006C620
	private void method_1(object sender, EventArgs e)
	{
		NewLateBinding.LateSet(sender, null, "Text", new object[]
		{
			NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Text", new object[0], null, null, null), null, "Replace", new object[]
			{
				" ",
				""
			}, null, null, null)
		}, null, null);
	}

	// Token: 0x0600101C RID: 4124 RVA: 0x00003402 File Offset: 0x00001602
	private void method_2(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		base.Close();
	}
}
