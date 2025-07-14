// Token: 0x020000C5 RID: 197
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class ProxyType : global::System.Windows.Forms.Form
{
	// Token: 0x06000B66 RID: 2918 RVA: 0x00046478 File Offset: 0x00044678
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

	// Token: 0x06000B67 RID: 2919 RVA: 0x000464BC File Offset: 0x000446BC
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.cmbProxy = new global::System.Windows.Forms.ComboBox();
		this.btnOK = new global::System.Windows.Forms.Button();
		base.SuspendLayout();
		this.cmbProxy.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.cmbProxy.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbProxy.FormattingEnabled = true;
		this.cmbProxy.Location = new global::System.Drawing.Point(12, 9);
		this.cmbProxy.Name = "cmbProxy";
		this.cmbProxy.Size = new global::System.Drawing.Size(175, 28);
		this.cmbProxy.TabIndex = 0;
		this.btnOK.Enabled = false;
		this.btnOK.Location = new global::System.Drawing.Point(12, 43);
		this.btnOK.Name = "btnOK";
		this.btnOK.Size = new global::System.Drawing.Size(175, 30);
		this.btnOK.TabIndex = 46;
		this.btnOK.Text = "&OK";
		this.btnOK.UseVisualStyleBackColor = true;
		base.AcceptButton = this.btnOK;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(199, 83);
		base.Controls.Add(this.btnOK);
		base.Controls.Add(this.cmbProxy);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "ProxyType";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Proxy Type";
		base.ResumeLayout(false);
	}

	// Token: 0x04000595 RID: 1429
	private global::System.ComponentModel.IContainer icontainer_0;
}
