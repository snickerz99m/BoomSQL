using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x020000E7 RID: 231
[DesignerGenerated]
public partial class VectorsAdd : Form
{
	// Token: 0x06000FFF RID: 4095 RVA: 0x00008B41 File Offset: 0x00006D41
	public VectorsAdd(List<string> vectors)
	{
		this.InitializeComponent();
		this.list_0 = vectors;
		Globals.AddMouseMoveForm(this);
		Globals.translate_0.Add(this, this.icontainer_0);
	}

	// Token: 0x17000500 RID: 1280
	// (get) Token: 0x06001002 RID: 4098 RVA: 0x00008B6D File Offset: 0x00006D6D
	// (set) Token: 0x06001003 RID: 4099 RVA: 0x0006DE00 File Offset: 0x0006C000
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
			EventHandler value2 = new EventHandler(this.method_1);
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

	// Token: 0x17000501 RID: 1281
	// (get) Token: 0x06001004 RID: 4100 RVA: 0x00008B75 File Offset: 0x00006D75
	// (set) Token: 0x06001005 RID: 4101 RVA: 0x0006DE44 File Offset: 0x0006C044
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
			EventHandler value2 = new EventHandler(this.method_2);
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

	// Token: 0x17000502 RID: 1282
	// (get) Token: 0x06001006 RID: 4102 RVA: 0x00008B7D File Offset: 0x00006D7D
	// (set) Token: 0x06001007 RID: 4103 RVA: 0x0006DE88 File Offset: 0x0006C088
	internal virtual TextBox txtVector
	{
		[CompilerGenerated]
		get
		{
			return this._txtVector;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_0);
			TextBox txtVector = this._txtVector;
			if (txtVector != null)
			{
				txtVector.TextChanged -= value2;
			}
			this._txtVector = value;
			txtVector = this._txtVector;
			if (txtVector != null)
			{
				txtVector.TextChanged += value2;
			}
		}
	}

	// Token: 0x06001008 RID: 4104 RVA: 0x0006DECC File Offset: 0x0006C0CC
	private void method_0(object sender, EventArgs e)
	{
		this.OK_Button.Enabled = (!string.IsNullOrEmpty(this.txtVector.Text) && !this.list_0.Contains(this.txtVector.Text) && this.txtVector.Text.Contains("[t]"));
	}

	// Token: 0x06001009 RID: 4105 RVA: 0x00003402 File Offset: 0x00001602
	private void method_1(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		base.Close();
	}

	// Token: 0x0600100A RID: 4106 RVA: 0x00003411 File Offset: 0x00001611
	private void method_2(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		base.Close();
	}

	// Token: 0x040007F7 RID: 2039
	private List<string> list_0;
}
