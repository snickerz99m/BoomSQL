using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x020000C2 RID: 194
[DesignerGenerated]
public partial class NewSocks : Form
{
	// Token: 0x06000B24 RID: 2852 RVA: 0x000069A8 File Offset: 0x00004BA8
	public NewSocks()
	{
		base.Load += this.NewSocks_Load;
		this.InitializeComponent();
		global::Globals.AddMouseMoveForm(this);
		global::Globals.translate_0.Add(this, this.icontainer_0);
	}

	// Token: 0x17000362 RID: 866
	// (get) Token: 0x06000B27 RID: 2855 RVA: 0x000069DF File Offset: 0x00004BDF
	// (set) Token: 0x06000B28 RID: 2856 RVA: 0x000455B0 File Offset: 0x000437B0
	internal virtual TextBox txtIP
	{
		[CompilerGenerated]
		get
		{
			return this._txtIP;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_1);
			EventHandler value3 = new EventHandler(this.method_2);
			TextBox txtIP = this._txtIP;
			if (txtIP != null)
			{
				txtIP.Leave -= value2;
				txtIP.TextChanged -= value3;
			}
			this._txtIP = value;
			txtIP = this._txtIP;
			if (txtIP != null)
			{
				txtIP.Leave += value2;
				txtIP.TextChanged += value3;
			}
		}
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x06000B29 RID: 2857 RVA: 0x000069E7 File Offset: 0x00004BE7
	// (set) Token: 0x06000B2A RID: 2858 RVA: 0x000069EF File Offset: 0x00004BEF
	internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x06000B2B RID: 2859 RVA: 0x000069F8 File Offset: 0x00004BF8
	// (set) Token: 0x06000B2C RID: 2860 RVA: 0x00006A00 File Offset: 0x00004C00
	internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000365 RID: 869
	// (get) Token: 0x06000B2D RID: 2861 RVA: 0x00006A09 File Offset: 0x00004C09
	// (set) Token: 0x06000B2E RID: 2862 RVA: 0x00045610 File Offset: 0x00043810
	internal virtual TextBox txtUser
	{
		[CompilerGenerated]
		get
		{
			return this._txtUser;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_1);
			TextBox txtUser = this._txtUser;
			if (txtUser != null)
			{
				txtUser.Leave -= value2;
			}
			this._txtUser = value;
			txtUser = this._txtUser;
			if (txtUser != null)
			{
				txtUser.Leave += value2;
			}
		}
	}

	// Token: 0x17000366 RID: 870
	// (get) Token: 0x06000B2F RID: 2863 RVA: 0x00006A11 File Offset: 0x00004C11
	// (set) Token: 0x06000B30 RID: 2864 RVA: 0x00006A19 File Offset: 0x00004C19
	internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000367 RID: 871
	// (get) Token: 0x06000B31 RID: 2865 RVA: 0x00006A22 File Offset: 0x00004C22
	// (set) Token: 0x06000B32 RID: 2866 RVA: 0x00045654 File Offset: 0x00043854
	internal virtual TextBox txtPwd
	{
		[CompilerGenerated]
		get
		{
			return this._txtPwd;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_1);
			TextBox txtPwd = this._txtPwd;
			if (txtPwd != null)
			{
				txtPwd.Leave -= value2;
			}
			this._txtPwd = value;
			txtPwd = this._txtPwd;
			if (txtPwd != null)
			{
				txtPwd.Leave += value2;
			}
		}
	}

	// Token: 0x17000368 RID: 872
	// (get) Token: 0x06000B33 RID: 2867 RVA: 0x00006A2A File Offset: 0x00004C2A
	// (set) Token: 0x06000B34 RID: 2868 RVA: 0x00006A32 File Offset: 0x00004C32
	internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000369 RID: 873
	// (get) Token: 0x06000B35 RID: 2869 RVA: 0x00006A3B File Offset: 0x00004C3B
	// (set) Token: 0x06000B36 RID: 2870 RVA: 0x00006A43 File Offset: 0x00004C43
	internal virtual Button btnCancel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700036A RID: 874
	// (get) Token: 0x06000B37 RID: 2871 RVA: 0x00006A4C File Offset: 0x00004C4C
	// (set) Token: 0x06000B38 RID: 2872 RVA: 0x00045698 File Offset: 0x00043898
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

	// Token: 0x1700036B RID: 875
	// (get) Token: 0x06000B39 RID: 2873 RVA: 0x00006A54 File Offset: 0x00004C54
	// (set) Token: 0x06000B3A RID: 2874 RVA: 0x000456DC File Offset: 0x000438DC
	internal virtual NumericUpDown numPort
	{
		[CompilerGenerated]
		get
		{
			return this._numPort;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_2);
			EventHandler value3 = new EventHandler(this.method_2);
			NumericUpDown numPort = this._numPort;
			if (numPort != null)
			{
				numPort.ValueChanged -= value2;
				numPort.TextChanged -= value3;
			}
			this._numPort = value;
			numPort = this._numPort;
			if (numPort != null)
			{
				numPort.ValueChanged += value2;
				numPort.TextChanged += value3;
			}
		}
	}

	// Token: 0x1700036C RID: 876
	// (get) Token: 0x06000B3B RID: 2875 RVA: 0x00006A5C File Offset: 0x00004C5C
	// (set) Token: 0x06000B3C RID: 2876 RVA: 0x00006A64 File Offset: 0x00004C64
	internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700036D RID: 877
	// (get) Token: 0x06000B3D RID: 2877 RVA: 0x00006A6D File Offset: 0x00004C6D
	// (set) Token: 0x06000B3E RID: 2878 RVA: 0x00006A75 File Offset: 0x00004C75
	internal virtual ComboBox cmbProxy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x06000B3F RID: 2879 RVA: 0x0004573C File Offset: 0x0004393C
	private void method_0(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		int value;
		switch (this.cmbProxy.SelectedIndex)
		{
		case 0:
			value = 0;
			break;
		case 1:
			value = 4;
			break;
		case 2:
			value = 5;
			break;
		}
		global::Globals.G_SOCKS.method_3(string.Concat(new string[]
		{
			this.txtIP.Text,
			":",
			Conversions.ToString(this.numPort.Value),
			":",
			Conversions.ToString(value),
			":",
			this.txtUser.Text,
			":",
			this.txtPwd.Text
		}));
		this.txtIP.Clear();
		this.numPort.Value = 0m;
		this.txtUser.Clear();
		this.txtPwd.Clear();
	}

	// Token: 0x06000B40 RID: 2880 RVA: 0x00006A7E File Offset: 0x00004C7E
	private void NewSocks_Load(object sender, EventArgs e)
	{
		this.cmbProxy.Items.AddRange(new string[]
		{
			"WEB PROXY",
			"SOCKS 4",
			"SOCKS 5"
		});
		base.CancelButton = this.btnCancel;
	}

	// Token: 0x06000B41 RID: 2881 RVA: 0x00006ABA File Offset: 0x00004CBA
	private void method_1(object sender, EventArgs e)
	{
		((TextBox)sender).Text = ((TextBox)sender).Text.Replace(" ", "");
	}

	// Token: 0x06000B42 RID: 2882 RVA: 0x00045828 File Offset: 0x00043A28
	private void method_2(object sender, EventArgs e)
	{
		this.btnOK.Enabled = ((global::Globals.ValideIP(this.txtIP.Text) && decimal.Compare(this.numPort.Value, 0m) > 0) & !Information.IsNothing(RuntimeHelpers.GetObjectValue(this.cmbProxy.SelectedItem)));
	}
}
