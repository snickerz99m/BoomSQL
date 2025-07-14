// Token: 0x020000E8 RID: 232
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class WafAdd : global::System.Windows.Forms.Form
{
	// Token: 0x0600100C RID: 4108 RVA: 0x0006DF28 File Offset: 0x0006C128
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

	// Token: 0x0600100D RID: 4109 RVA: 0x0006DF6C File Offset: 0x0006C16C
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.OK_Button = new global::System.Windows.Forms.Button();
		this.Cancel_Button = new global::System.Windows.Forms.Button();
		this.Label1 = new global::System.Windows.Forms.Label();
		this.txtEnding = new global::System.Windows.Forms.TextBox();
		this.Label10 = new global::System.Windows.Forms.Label();
		this.txtOutset = new global::System.Windows.Forms.TextBox();
		base.SuspendLayout();
		this.OK_Button.Enabled = false;
		this.OK_Button.Location = new global::System.Drawing.Point(248, 77);
		this.OK_Button.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.OK_Button.Name = "OK_Button";
		this.OK_Button.Size = new global::System.Drawing.Size(132, 30);
		this.OK_Button.TabIndex = 45;
		this.OK_Button.Text = "OK";
		this.Cancel_Button.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
		this.Cancel_Button.Location = new global::System.Drawing.Point(106, 77);
		this.Cancel_Button.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.Cancel_Button.Name = "Cancel_Button";
		this.Cancel_Button.Size = new global::System.Drawing.Size(132, 30);
		this.Cancel_Button.TabIndex = 46;
		this.Cancel_Button.Text = "Cancel";
		this.Label1.Location = new global::System.Drawing.Point(9, 43);
		this.Label1.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
		this.Label1.Name = "Label1";
		this.Label1.Size = new global::System.Drawing.Size(90, 26);
		this.Label1.TabIndex = 48;
		this.Label1.Text = "Ending";
		this.Label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.txtEnding.Location = new global::System.Drawing.Point(106, 43);
		this.txtEnding.Name = "txtEnding";
		this.txtEnding.Size = new global::System.Drawing.Size(274, 26);
		this.txtEnding.TabIndex = 44;
		this.Label10.Location = new global::System.Drawing.Point(9, 11);
		this.Label10.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
		this.Label10.Name = "Label10";
		this.Label10.Size = new global::System.Drawing.Size(90, 26);
		this.Label10.TabIndex = 47;
		this.Label10.Text = "Outset";
		this.Label10.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.txtOutset.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Lower;
		this.txtOutset.Location = new global::System.Drawing.Point(106, 11);
		this.txtOutset.Name = "txtOutset";
		this.txtOutset.Size = new global::System.Drawing.Size(274, 26);
		this.txtOutset.TabIndex = 43;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.Cancel_Button;
		base.ClientSize = new global::System.Drawing.Size(388, 115);
		base.Controls.Add(this.OK_Button);
		base.Controls.Add(this.Cancel_Button);
		base.Controls.Add(this.Label1);
		base.Controls.Add(this.txtEnding);
		base.Controls.Add(this.Label10);
		base.Controls.Add(this.txtOutset);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		base.MinimizeBox = false;
		base.Name = "WafAdd";
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Add WAF";
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x040007F8 RID: 2040
	private global::System.ComponentModel.IContainer icontainer_0;
}
