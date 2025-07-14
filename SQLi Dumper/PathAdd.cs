using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x020000C4 RID: 196
[DesignerGenerated]
public partial class PathAdd : Form
{
	// Token: 0x06000B52 RID: 2898 RVA: 0x00006B49 File Offset: 0x00004D49
	public PathAdd(List<string> l, bool bWin, bool bVector)
	{
		this.InitializeComponent();
		this.list_0 = l;
		this.bool_0 = bWin;
		this.bool_1 = bVector;
		Globals.AddMouseMoveForm(this);
		Globals.translate_0.Add(this, this.icontainer_0);
	}

	// Token: 0x17000373 RID: 883
	// (get) Token: 0x06000B55 RID: 2901 RVA: 0x00006B83 File Offset: 0x00004D83
	// (set) Token: 0x06000B56 RID: 2902 RVA: 0x00006B8B File Offset: 0x00004D8B
	internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000374 RID: 884
	// (get) Token: 0x06000B57 RID: 2903 RVA: 0x00006B94 File Offset: 0x00004D94
	// (set) Token: 0x06000B58 RID: 2904 RVA: 0x00046120 File Offset: 0x00044320
	internal virtual TextBox txtPath
	{
		[CompilerGenerated]
		get
		{
			return this._txtPath;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_0);
			EventHandler value3 = new EventHandler(this.method_1);
			TextBox txtPath = this._txtPath;
			if (txtPath != null)
			{
				txtPath.TextChanged -= value2;
				txtPath.Leave -= value3;
			}
			this._txtPath = value;
			txtPath = this._txtPath;
			if (txtPath != null)
			{
				txtPath.TextChanged += value2;
				txtPath.Leave += value3;
			}
		}
	}

	// Token: 0x17000375 RID: 885
	// (get) Token: 0x06000B59 RID: 2905 RVA: 0x00006B9C File Offset: 0x00004D9C
	// (set) Token: 0x06000B5A RID: 2906 RVA: 0x00006BA4 File Offset: 0x00004DA4
	internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000376 RID: 886
	// (get) Token: 0x06000B5B RID: 2907 RVA: 0x00006BAD File Offset: 0x00004DAD
	// (set) Token: 0x06000B5C RID: 2908 RVA: 0x00046180 File Offset: 0x00044380
	internal virtual TextBox txtKeyword
	{
		[CompilerGenerated]
		get
		{
			return this._txtKeyword;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_0);
			EventHandler value3 = new EventHandler(this.method_1);
			TextBox txtKeyword = this._txtKeyword;
			if (txtKeyword != null)
			{
				txtKeyword.TextChanged -= value2;
				txtKeyword.Leave -= value3;
			}
			this._txtKeyword = value;
			txtKeyword = this._txtKeyword;
			if (txtKeyword != null)
			{
				txtKeyword.TextChanged += value2;
				txtKeyword.Leave += value3;
			}
		}
	}

	// Token: 0x17000377 RID: 887
	// (get) Token: 0x06000B5D RID: 2909 RVA: 0x00006BB5 File Offset: 0x00004DB5
	// (set) Token: 0x06000B5E RID: 2910 RVA: 0x000461E0 File Offset: 0x000443E0
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

	// Token: 0x17000378 RID: 888
	// (get) Token: 0x06000B5F RID: 2911 RVA: 0x00006BBD File Offset: 0x00004DBD
	// (set) Token: 0x06000B60 RID: 2912 RVA: 0x00006BC5 File Offset: 0x00004DC5
	internal virtual Button Cancel_Button { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x06000B61 RID: 2913 RVA: 0x00046224 File Offset: 0x00044424
	private void method_0(object sender, EventArgs e)
	{
		this.OK_Button.Enabled = (!string.IsNullOrEmpty(this.txtPath.Text) && !string.IsNullOrEmpty(this.txtKeyword.Text) && !this.list_0.Contains(this.txtPath.Text));
	}

	// Token: 0x06000B62 RID: 2914 RVA: 0x0004627C File Offset: 0x0004447C
	private void method_1(object sender, EventArgs e)
	{
		if (!this.bool_1)
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
	}

	// Token: 0x06000B63 RID: 2915 RVA: 0x000462E4 File Offset: 0x000444E4
	private void method_2(object sender, EventArgs e)
	{
		if (this.method_3())
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}
		else
		{
			using (new Class8(this))
			{
				MessageBox.Show("Invalid filename\\path.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			this.txtPath.Focus();
		}
	}

	// Token: 0x06000B64 RID: 2916 RVA: 0x0004634C File Offset: 0x0004454C
	private bool method_3()
	{
		bool result;
		if (this.bool_1)
		{
			result = true;
		}
		else
		{
			List<char> list = new List<char>();
			list.AddRange(Path.GetInvalidFileNameChars());
			if (list.Contains('/'))
			{
				list.Remove('/');
			}
			if (list.Contains('\\'))
			{
				list.Remove('\\');
			}
			if (this.bool_0 && list.Contains(':'))
			{
				list.Remove(':');
			}
			foreach (char item in this.txtPath.Text.ToCharArray())
			{
				if (list.Contains(item))
				{
					return false;
				}
			}
			result = true;
		}
		return result;
	}

	// Token: 0x04000592 RID: 1426
	private List<string> list_0;

	// Token: 0x04000593 RID: 1427
	private bool bool_0;

	// Token: 0x04000594 RID: 1428
	private bool bool_1;
}
