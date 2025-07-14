using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x02000068 RID: 104
[DesignerGenerated]
public partial class AddURLs : Form
{
	// Token: 0x06000311 RID: 785 RVA: 0x000033B3 File Offset: 0x000015B3
	public AddURLs()
	{
		base.Load += this.AddURLs_Load;
		this.InitializeComponent();
		Globals.AddMouseMoveForm(this);
		Globals.translate_0.Add(this, this.icontainer_0);
	}

	// Token: 0x170000CF RID: 207
	// (get) Token: 0x06000314 RID: 788 RVA: 0x000033EA File Offset: 0x000015EA
	// (set) Token: 0x06000315 RID: 789 RVA: 0x00016D0C File Offset: 0x00014F0C
	internal virtual TextBox txtURLs
	{
		[CompilerGenerated]
		get
		{
			return this._txtURLs;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_2);
			TextBox txtURLs = this._txtURLs;
			if (txtURLs != null)
			{
				txtURLs.TextChanged -= value2;
			}
			this._txtURLs = value;
			txtURLs = this._txtURLs;
			if (txtURLs != null)
			{
				txtURLs.TextChanged += value2;
			}
		}
	}

	// Token: 0x170000D0 RID: 208
	// (get) Token: 0x06000316 RID: 790 RVA: 0x000033F2 File Offset: 0x000015F2
	// (set) Token: 0x06000317 RID: 791 RVA: 0x00016D50 File Offset: 0x00014F50
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
			EventHandler value2 = new EventHandler(this.method_0);
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

	// Token: 0x170000D1 RID: 209
	// (get) Token: 0x06000318 RID: 792 RVA: 0x000033FA File Offset: 0x000015FA
	// (set) Token: 0x06000319 RID: 793 RVA: 0x00016D94 File Offset: 0x00014F94
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
			EventHandler value2 = new EventHandler(this.method_1);
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

	// Token: 0x0600031A RID: 794 RVA: 0x00003402 File Offset: 0x00001602
	private void method_0(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		base.Close();
	}

	// Token: 0x0600031B RID: 795 RVA: 0x00003411 File Offset: 0x00001611
	private void method_1(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		base.Close();
	}

	// Token: 0x0600031C RID: 796 RVA: 0x00016DD8 File Offset: 0x00014FD8
	private void method_2(object sender, EventArgs e)
	{
		foreach (string string_ in this.txtURLs.Lines)
		{
			if (Class23.smethod_13(string_, true))
			{
				this.btnOK.Enabled = true;
				return;
			}
		}
		this.btnOK.Enabled = false;
	}

	// Token: 0x0600031D RID: 797 RVA: 0x00016E28 File Offset: 0x00015028
	private void AddURLs_Load(object sender, EventArgs e)
	{
		this.btnCancel.Text = Globals.translate_0.GetStr("PathAdd", "Cancel_Button", "Cancel");
		this.btnOK.Text = Globals.translate_0.GetStr("PathAdd", "OK_Button", "OK");
	}
}
