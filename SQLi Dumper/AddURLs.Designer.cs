// Token: 0x02000068 RID: 104
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class AddURLs : global::System.Windows.Forms.Form
{
	// Token: 0x06000312 RID: 786 RVA: 0x00016A10 File Offset: 0x00014C10
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

	// Token: 0x06000313 RID: 787 RVA: 0x00016A54 File Offset: 0x00014C54
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.txtURLs = new global::System.Windows.Forms.TextBox();
		this.btnOK = new global::System.Windows.Forms.Button();
		this.btnCancel = new global::System.Windows.Forms.Button();
		base.SuspendLayout();
		this.txtURLs.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.txtURLs.Location = new global::System.Drawing.Point(12, 12);
		this.txtURLs.MaxLength = 999999999;
		this.txtURLs.Multiline = true;
		this.txtURLs.Name = "txtURLs";
		this.txtURLs.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
		this.txtURLs.Size = new global::System.Drawing.Size(381, 453);
		this.txtURLs.TabIndex = 0;
		this.txtURLs.WordWrap = false;
		this.btnOK.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.btnOK.Enabled = false;
		this.btnOK.Location = new global::System.Drawing.Point(282, 472);
		this.btnOK.Margin = new global::System.Windows.Forms.Padding(4);
		this.btnOK.Name = "btnOK";
		this.btnOK.Size = new global::System.Drawing.Size(111, 30);
		this.btnOK.TabIndex = 1;
		this.btnOK.Text = "OK";
		this.btnOK.UseVisualStyleBackColor = true;
		this.btnCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.Location = new global::System.Drawing.Point(168, 472);
		this.btnCancel.Margin = new global::System.Windows.Forms.Padding(4);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new global::System.Drawing.Size(111, 30);
		this.btnCancel.TabIndex = 2;
		this.btnCancel.Text = "Cancel";
		this.btnCancel.UseVisualStyleBackColor = true;
		base.AcceptButton = this.btnOK;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.btnCancel;
		base.ClientSize = new global::System.Drawing.Size(404, 513);
		base.Controls.Add(this.txtURLs);
		base.Controls.Add(this.btnOK);
		base.Controls.Add(this.btnCancel);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		this.MinimumSize = new global::System.Drawing.Size(269, 382);
		base.Name = "AddURLs";
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Add URL's";
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x04000206 RID: 518
	private global::System.ComponentModel.IContainer icontainer_0;
}
