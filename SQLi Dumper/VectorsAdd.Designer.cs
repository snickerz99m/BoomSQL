// Token: 0x020000E7 RID: 231
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class VectorsAdd : global::System.Windows.Forms.Form
{
	// Token: 0x06001000 RID: 4096 RVA: 0x0006DB9C File Offset: 0x0006BD9C
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

	// Token: 0x06001001 RID: 4097 RVA: 0x0006DBE0 File Offset: 0x0006BDE0
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.OK_Button = new global::System.Windows.Forms.Button();
		this.Cancel_Button = new global::System.Windows.Forms.Button();
		this.txtVector = new global::System.Windows.Forms.TextBox();
		base.SuspendLayout();
		this.OK_Button.Enabled = false;
		this.OK_Button.Location = new global::System.Drawing.Point(240, 44);
		this.OK_Button.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.OK_Button.Name = "OK_Button";
		this.OK_Button.Size = new global::System.Drawing.Size(132, 30);
		this.OK_Button.TabIndex = 1;
		this.OK_Button.Text = "OK";
		this.Cancel_Button.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
		this.Cancel_Button.Location = new global::System.Drawing.Point(9, 44);
		this.Cancel_Button.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.Cancel_Button.Name = "Cancel_Button";
		this.Cancel_Button.Size = new global::System.Drawing.Size(132, 30);
		this.Cancel_Button.TabIndex = 2;
		this.Cancel_Button.Text = "Cancel";
		this.txtVector.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Lower;
		this.txtVector.Location = new global::System.Drawing.Point(9, 9);
		this.txtVector.Name = "txtVector";
		this.txtVector.Size = new global::System.Drawing.Size(361, 26);
		this.txtVector.TabIndex = 0;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.Cancel_Button;
		base.ClientSize = new global::System.Drawing.Size(382, 84);
		base.Controls.Add(this.OK_Button);
		base.Controls.Add(this.Cancel_Button);
		base.Controls.Add(this.txtVector);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "VectorsAdd";
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Add Vector";
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x040007F3 RID: 2035
	private global::System.ComponentModel.IContainer icontainer_0;
}
