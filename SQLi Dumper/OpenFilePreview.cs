using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x020000C3 RID: 195
[DesignerGenerated]
public partial class OpenFilePreview : Form
{
	// Token: 0x06000B43 RID: 2883 RVA: 0x00006AE1 File Offset: 0x00004CE1
	public OpenFilePreview()
	{
		this.InitializeComponent();
		Globals.AddMouseMoveForm(this);
		Globals.translate_0.Add(this, this.icontainer_0);
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x06000B46 RID: 2886 RVA: 0x00006B06 File Offset: 0x00004D06
	// (set) Token: 0x06000B47 RID: 2887 RVA: 0x00045CA4 File Offset: 0x00043EA4
	internal virtual Button btnOK
	{
		[CompilerGenerated]
		get
		{
			return this._btnOK;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_1);
			Button btnOK = this._btnOK;
			if (btnOK != null)
			{
				btnOK.Click -= value2;
			}
			this._btnOK = value;
			btnOK = this._btnOK;
			if (btnOK != null)
			{
				btnOK.Click += value2;
			}
		}
	}

	// Token: 0x1700036F RID: 879
	// (get) Token: 0x06000B48 RID: 2888 RVA: 0x00006B0E File Offset: 0x00004D0E
	// (set) Token: 0x06000B49 RID: 2889 RVA: 0x00045CE8 File Offset: 0x00043EE8
	internal virtual Button btnCancel
	{
		[CompilerGenerated]
		get
		{
			return this._btnCancel;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_0);
			Button btnCancel = this._btnCancel;
			if (btnCancel != null)
			{
				btnCancel.Click -= value2;
			}
			this._btnCancel = value;
			btnCancel = this._btnCancel;
			if (btnCancel != null)
			{
				btnCancel.Click += value2;
			}
		}
	}

	// Token: 0x17000370 RID: 880
	// (get) Token: 0x06000B4A RID: 2890 RVA: 0x00006B16 File Offset: 0x00004D16
	// (set) Token: 0x06000B4B RID: 2891 RVA: 0x00006B1E File Offset: 0x00004D1E
	internal virtual TextBox txtPreview { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000371 RID: 881
	// (get) Token: 0x06000B4C RID: 2892 RVA: 0x00006B27 File Offset: 0x00004D27
	// (set) Token: 0x06000B4D RID: 2893 RVA: 0x00006B2F File Offset: 0x00004D2F
	internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000372 RID: 882
	// (get) Token: 0x06000B4E RID: 2894 RVA: 0x00006B38 File Offset: 0x00004D38
	// (set) Token: 0x06000B4F RID: 2895 RVA: 0x00006B40 File Offset: 0x00004D40
	internal virtual NumericUpDown numLineIndex { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x06000B50 RID: 2896 RVA: 0x00003411 File Offset: 0x00001611
	private void method_0(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		base.Close();
	}

	// Token: 0x06000B51 RID: 2897 RVA: 0x00003402 File Offset: 0x00001602
	private void method_1(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		base.Close();
	}
}
