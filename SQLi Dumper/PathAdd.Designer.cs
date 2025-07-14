// Token: 0x020000C4 RID: 196
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class PathAdd : global::System.Windows.Forms.Form
{
	// Token: 0x06000B53 RID: 2899 RVA: 0x00045D2C File Offset: 0x00043F2C
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

	// Token: 0x06000B54 RID: 2900 RVA: 0x00045D70 File Offset: 0x00043F70
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.Label10 = new global::System.Windows.Forms.Label();
		this.txtPath = new global::System.Windows.Forms.TextBox();
		this.Label1 = new global::System.Windows.Forms.Label();
		this.txtKeyword = new global::System.Windows.Forms.TextBox();
		this.OK_Button = new global::System.Windows.Forms.Button();
		this.Cancel_Button = new global::System.Windows.Forms.Button();
		base.SuspendLayout();
		this.Label10.Location = new global::System.Drawing.Point(8, 12);
		this.Label10.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
		this.Label10.Name = "Label10";
		this.Label10.Size = new global::System.Drawing.Size(90, 26);
		this.Label10.TabIndex = 40;
		this.Label10.Text = "Path";
		this.Label10.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.txtPath.CharacterCasing = global::System.Windows.Forms.CharacterCasing.Lower;
		this.txtPath.Location = new global::System.Drawing.Point(105, 12);
		this.txtPath.Name = "txtPath";
		this.txtPath.Size = new global::System.Drawing.Size(274, 26);
		this.txtPath.TabIndex = 0;
		this.Label1.Location = new global::System.Drawing.Point(8, 44);
		this.Label1.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
		this.Label1.Name = "Label1";
		this.Label1.Size = new global::System.Drawing.Size(90, 26);
		this.Label1.TabIndex = 42;
		this.Label1.Text = "Keyword";
		this.Label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.txtKeyword.Location = new global::System.Drawing.Point(105, 44);
		this.txtKeyword.Name = "txtKeyword";
		this.txtKeyword.Size = new global::System.Drawing.Size(274, 26);
		this.txtKeyword.TabIndex = 1;
		this.OK_Button.Enabled = false;
		this.OK_Button.Location = new global::System.Drawing.Point(247, 78);
		this.OK_Button.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.OK_Button.Name = "OK_Button";
		this.OK_Button.Size = new global::System.Drawing.Size(132, 30);
		this.OK_Button.TabIndex = 2;
		this.OK_Button.Text = "OK";
		this.Cancel_Button.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
		this.Cancel_Button.Location = new global::System.Drawing.Point(105, 78);
		this.Cancel_Button.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.Cancel_Button.Name = "Cancel_Button";
		this.Cancel_Button.Size = new global::System.Drawing.Size(132, 30);
		this.Cancel_Button.TabIndex = 3;
		this.Cancel_Button.Text = "Cancel";
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.Cancel_Button;
		base.ClientSize = new global::System.Drawing.Size(388, 123);
		base.Controls.Add(this.OK_Button);
		base.Controls.Add(this.Cancel_Button);
		base.Controls.Add(this.Label1);
		base.Controls.Add(this.txtKeyword);
		base.Controls.Add(this.Label10);
		base.Controls.Add(this.txtPath);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "PathAdd";
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "New Path";
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x0400058B RID: 1419
	private global::System.ComponentModel.IContainer icontainer_0;
}
