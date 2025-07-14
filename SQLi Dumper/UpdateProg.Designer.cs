// Token: 0x020000E6 RID: 230
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class UpdateProg : global::System.Windows.Forms.Form
{
	// Token: 0x06000FF6 RID: 4086 RVA: 0x0006D980 File Offset: 0x0006BB80
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

	// Token: 0x06000FF7 RID: 4087 RVA: 0x0006D9C4 File Offset: 0x0006BBC4
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.Cancel_Button = new global::System.Windows.Forms.Button();
		this.prbDownload = new global::System.Windows.Forms.ProgressBar();
		base.SuspendLayout();
		this.Cancel_Button.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
		this.Cancel_Button.Location = new global::System.Drawing.Point(370, 9);
		this.Cancel_Button.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.Cancel_Button.Name = "Cancel_Button";
		this.Cancel_Button.Size = new global::System.Drawing.Size(96, 30);
		this.Cancel_Button.TabIndex = 4;
		this.Cancel_Button.Text = "Cancel";
		this.prbDownload.Location = new global::System.Drawing.Point(9, 6);
		this.prbDownload.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.prbDownload.Name = "prbDownload";
		this.prbDownload.Size = new global::System.Drawing.Size(354, 35);
		this.prbDownload.TabIndex = 5;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(472, 49);
		base.ControlBox = false;
		base.Controls.Add(this.prbDownload);
		base.Controls.Add(this.Cancel_Button);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		base.MinimizeBox = false;
		base.Name = "UpdateProg";
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
		this.Text = "Updater";
		base.ResumeLayout(false);
	}

	// Token: 0x040007EF RID: 2031
	private global::System.ComponentModel.IContainer icontainer_0;
}
