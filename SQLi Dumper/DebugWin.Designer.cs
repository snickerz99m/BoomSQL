// Token: 0x0200006B RID: 107
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class DebugWin : global::System.Windows.Forms.Form
{
	// Token: 0x060003B6 RID: 950 RVA: 0x0001AABC File Offset: 0x00018CBC
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

	// Token: 0x060003B7 RID: 951 RVA: 0x0001AB00 File Offset: 0x00018D00
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.txtOutput = new global::System.Windows.Forms.TextBox();
		base.SuspendLayout();
		this.txtOutput.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.txtOutput.Font = new global::System.Drawing.Font("Courier New", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.txtOutput.Location = new global::System.Drawing.Point(0, 0);
		this.txtOutput.Multiline = true;
		this.txtOutput.Name = "txtOutput";
		this.txtOutput.ReadOnly = true;
		this.txtOutput.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.txtOutput.Size = new global::System.Drawing.Size(826, 510);
		this.txtOutput.TabIndex = 0;
		this.txtOutput.WordWrap = false;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(826, 510);
		base.Controls.Add(this.txtOutput);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		base.Name = "DebugWin";
		this.Text = "Debug";
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x04000247 RID: 583
	private global::System.ComponentModel.IContainer icontainer_0;
}
