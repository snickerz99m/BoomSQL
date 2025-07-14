// Token: 0x020000E4 RID: 228
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public sealed partial class Splash : global::System.Windows.Forms.Form
{
	// Token: 0x06000FE0 RID: 4064 RVA: 0x0006D234 File Offset: 0x0006B434
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

	// Token: 0x06000FE1 RID: 4065 RVA: 0x0006D278 File Offset: 0x0006B478
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		base.SuspendLayout();
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = global::System.Drawing.Color.Black;
		this.BackgroundImage = global::ns0.Class6.about;
		this.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
		base.ClientSize = new global::System.Drawing.Size(284, 268);
		this.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 0);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Splash";
		base.Opacity = 0.7;
		base.Padding = new global::System.Windows.Forms.Padding(14);
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Splash";
		base.ResumeLayout(false);
	}

	// Token: 0x040007E5 RID: 2021
	private global::System.ComponentModel.IContainer icontainer_0;
}
