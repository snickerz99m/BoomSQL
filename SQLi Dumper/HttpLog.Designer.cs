// Token: 0x020000C1 RID: 193
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class HttpLog : global::System.Windows.Forms.Form
{
	// Token: 0x06000B21 RID: 2849 RVA: 0x00044D0C File Offset: 0x00042F0C
	[global::System.Diagnostics.DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	// Token: 0x06000B22 RID: 2850 RVA: 0x00044D50 File Offset: 0x00042F50
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		base.SuspendLayout();
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(863, 395);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		base.Name = "HttpLog";
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
		this.Text = "HTTP Debugger";
		base.ResumeLayout(false);
	}

	// Token: 0x04000574 RID: 1396
	private global::System.ComponentModel.IContainer icontainer_0;
}
