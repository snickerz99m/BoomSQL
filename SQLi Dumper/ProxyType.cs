using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x020000C5 RID: 197
[DesignerGenerated]
public partial class ProxyType : Form
{
	// Token: 0x06000B65 RID: 2917 RVA: 0x000463F4 File Offset: 0x000445F4
	public ProxyType()
	{
		base.FormClosing += this.ProxyType_FormClosing;
		base.Load += this.ProxyType_Load;
		this.InitializeComponent();
		this.cmbProxy.Items.AddRange(new string[]
		{
			"WEB PROXY",
			"SOCKS 4",
			"SOCKS 5"
		});
		global::Globals.AddMouseMoveForm(this);
		global::Globals.translate_0.Add(this, this.icontainer_0);
	}

	// Token: 0x17000379 RID: 889
	// (get) Token: 0x06000B68 RID: 2920 RVA: 0x00006BCE File Offset: 0x00004DCE
	// (set) Token: 0x06000B69 RID: 2921 RVA: 0x00046660 File Offset: 0x00044860
	internal virtual ComboBox cmbProxy
	{
		[CompilerGenerated]
		get
		{
			return this._cmbProxy;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_0);
			ComboBox cmbProxy = this._cmbProxy;
			if (cmbProxy != null)
			{
				cmbProxy.SelectedIndexChanged -= value2;
			}
			this._cmbProxy = value;
			cmbProxy = this._cmbProxy;
			if (cmbProxy != null)
			{
				cmbProxy.SelectedIndexChanged += value2;
			}
		}
	}

	// Token: 0x1700037A RID: 890
	// (get) Token: 0x06000B6A RID: 2922 RVA: 0x00006BD6 File Offset: 0x00004DD6
	// (set) Token: 0x06000B6B RID: 2923 RVA: 0x000466A4 File Offset: 0x000448A4
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

	// Token: 0x06000B6C RID: 2924 RVA: 0x00006BDE File Offset: 0x00004DDE
	private void ProxyType_FormClosing(object sender, FormClosingEventArgs e)
	{
		Class50.smethod_3(this, null);
	}

	// Token: 0x06000B6D RID: 2925 RVA: 0x00006BE7 File Offset: 0x00004DE7
	private void ProxyType_Load(object sender, EventArgs e)
	{
		Class50.smethod_2(this, null);
	}

	// Token: 0x06000B6E RID: 2926 RVA: 0x00006BF0 File Offset: 0x00004DF0
	private void method_0(object sender, EventArgs e)
	{
		this.btnOK.Enabled = !Information.IsNothing(RuntimeHelpers.GetObjectValue(this.cmbProxy.SelectedItem));
	}

	// Token: 0x06000B6F RID: 2927 RVA: 0x00003402 File Offset: 0x00001602
	private void method_1(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		base.Close();
	}
}
