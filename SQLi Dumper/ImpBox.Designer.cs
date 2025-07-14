// Token: 0x020000B6 RID: 182
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class ImpBox : global::System.Windows.Forms.Form
{
	// Token: 0x06000A77 RID: 2679 RVA: 0x00040F58 File Offset: 0x0003F158
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

	// Token: 0x06000A78 RID: 2680 RVA: 0x00040F9C File Offset: 0x0003F19C
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.OK_Button = new global::System.Windows.Forms.Button();
		this.Cancel_Button = new global::System.Windows.Forms.Button();
		this.txtValue = new global::System.Windows.Forms.TextBox();
		base.SuspendLayout();
		this.OK_Button.Enabled = false;
		this.OK_Button.Location = new global::System.Drawing.Point(241, 48);
		this.OK_Button.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.OK_Button.Name = "OK_Button";
		this.OK_Button.Size = new global::System.Drawing.Size(132, 30);
		this.OK_Button.TabIndex = 1;
		this.OK_Button.Text = "OK";
		this.Cancel_Button.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
		this.Cancel_Button.Location = new global::System.Drawing.Point(10, 48);
		this.Cancel_Button.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.Cancel_Button.Name = "Cancel_Button";
		this.Cancel_Button.Size = new global::System.Drawing.Size(132, 30);
		this.Cancel_Button.TabIndex = 2;
		this.Cancel_Button.Text = "Cancel";
		this.txtValue.Location = new global::System.Drawing.Point(9, 9);
		this.txtValue.Name = "txtValue";
		this.txtValue.Size = new global::System.Drawing.Size(361, 26);
		this.txtValue.TabIndex = 0;
		base.AcceptButton = this.OK_Button;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.Cancel_Button;
		base.ClientSize = new global::System.Drawing.Size(382, 89);
		base.Controls.Add(this.OK_Button);
		base.Controls.Add(this.Cancel_Button);
		base.Controls.Add(this.txtValue);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ImpBox";
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Add Value";
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x0400052B RID: 1323
	private global::System.ComponentModel.IContainer icontainer_0;
}
