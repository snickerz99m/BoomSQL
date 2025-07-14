using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x0200006B RID: 107
[DesignerGenerated]
public partial class DebugWin : Form
{
	// Token: 0x060003B5 RID: 949 RVA: 0x000038D9 File Offset: 0x00001AD9
	public DebugWin()
	{
		this.InitializeComponent();
	}

	// Token: 0x17000109 RID: 265
	// (get) Token: 0x060003B8 RID: 952 RVA: 0x000038E7 File Offset: 0x00001AE7
	// (set) Token: 0x060003B9 RID: 953 RVA: 0x000038EF File Offset: 0x00001AEF
	internal virtual TextBox txtOutput { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x060003BA RID: 954 RVA: 0x000038F8 File Offset: 0x00001AF8
	public void Append(string text)
	{
		this.txtOutput.AppendText(text + "\r\n");
	}
}
