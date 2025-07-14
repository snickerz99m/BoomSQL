// Token: 0x020000C2 RID: 194
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class NewSocks : global::System.Windows.Forms.Form
{
	// Token: 0x06000B25 RID: 2853 RVA: 0x00044E2C File Offset: 0x0004302C
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

	// Token: 0x06000B26 RID: 2854 RVA: 0x00044E70 File Offset: 0x00043070
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.txtIP = new global::System.Windows.Forms.TextBox();
		this.Label16 = new global::System.Windows.Forms.Label();
		this.Label1 = new global::System.Windows.Forms.Label();
		this.txtUser = new global::System.Windows.Forms.TextBox();
		this.Label2 = new global::System.Windows.Forms.Label();
		this.txtPwd = new global::System.Windows.Forms.TextBox();
		this.Label3 = new global::System.Windows.Forms.Label();
		this.btnCancel = new global::System.Windows.Forms.Button();
		this.btnOK = new global::System.Windows.Forms.Button();
		this.numPort = new global::System.Windows.Forms.NumericUpDown();
		this.Label4 = new global::System.Windows.Forms.Label();
		this.cmbProxy = new global::System.Windows.Forms.ComboBox();
		((global::System.ComponentModel.ISupportInitialize)this.numPort).BeginInit();
		base.SuspendLayout();
		this.txtIP.Location = new global::System.Drawing.Point(105, 10);
		this.txtIP.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.txtIP.Name = "txtIP";
		this.txtIP.Size = new global::System.Drawing.Size(184, 26);
		this.txtIP.TabIndex = 0;
		this.Label16.Location = new global::System.Drawing.Point(6, 10);
		this.Label16.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
		this.Label16.Name = "Label16";
		this.Label16.Size = new global::System.Drawing.Size(92, 24);
		this.Label16.TabIndex = 26;
		this.Label16.Text = "IP";
		this.Label16.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.Label1.Location = new global::System.Drawing.Point(6, 43);
		this.Label1.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
		this.Label1.Name = "Label1";
		this.Label1.Size = new global::System.Drawing.Size(92, 24);
		this.Label1.TabIndex = 28;
		this.Label1.Text = "Port";
		this.Label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.txtUser.Location = new global::System.Drawing.Point(105, 112);
		this.txtUser.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.txtUser.Name = "txtUser";
		this.txtUser.Size = new global::System.Drawing.Size(184, 26);
		this.txtUser.TabIndex = 3;
		this.Label2.Location = new global::System.Drawing.Point(6, 112);
		this.Label2.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
		this.Label2.Name = "Label2";
		this.Label2.Size = new global::System.Drawing.Size(92, 24);
		this.Label2.TabIndex = 30;
		this.Label2.Text = "Username";
		this.Label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.txtPwd.Location = new global::System.Drawing.Point(105, 145);
		this.txtPwd.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.txtPwd.Name = "txtPwd";
		this.txtPwd.Size = new global::System.Drawing.Size(184, 26);
		this.txtPwd.TabIndex = 4;
		this.Label3.Location = new global::System.Drawing.Point(6, 145);
		this.Label3.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
		this.Label3.Name = "Label3";
		this.Label3.Size = new global::System.Drawing.Size(92, 24);
		this.Label3.TabIndex = 32;
		this.Label3.Text = "Password";
		this.Label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.Location = new global::System.Drawing.Point(13, 179);
		this.btnCancel.Margin = new global::System.Windows.Forms.Padding(5);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new global::System.Drawing.Size(132, 30);
		this.btnCancel.TabIndex = 6;
		this.btnCancel.Text = "Close";
		this.btnCancel.UseVisualStyleBackColor = true;
		this.btnOK.Enabled = false;
		this.btnOK.Location = new global::System.Drawing.Point(157, 179);
		this.btnOK.Margin = new global::System.Windows.Forms.Padding(5);
		this.btnOK.Name = "btnOK";
		this.btnOK.Size = new global::System.Drawing.Size(132, 30);
		this.btnOK.TabIndex = 5;
		this.btnOK.Text = "Add";
		this.btnOK.UseVisualStyleBackColor = true;
		this.numPort.Location = new global::System.Drawing.Point(105, 43);
		global::System.Windows.Forms.NumericUpDown numPort = this.numPort;
		int[] array = new int[4];
		array[0] = 9999999;
		numPort.Maximum = new decimal(array);
		this.numPort.Name = "numPort";
		this.numPort.Size = new global::System.Drawing.Size(184, 26);
		this.numPort.TabIndex = 1;
		this.Label4.Location = new global::System.Drawing.Point(6, 81);
		this.Label4.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
		this.Label4.Name = "Label4";
		this.Label4.Size = new global::System.Drawing.Size(92, 24);
		this.Label4.TabIndex = 33;
		this.Label4.Text = "Type";
		this.Label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.cmbProxy.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.cmbProxy.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbProxy.FormattingEnabled = true;
		this.cmbProxy.Location = new global::System.Drawing.Point(105, 77);
		this.cmbProxy.Name = "cmbProxy";
		this.cmbProxy.Size = new global::System.Drawing.Size(184, 28);
		this.cmbProxy.TabIndex = 2;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(299, 219);
		base.Controls.Add(this.cmbProxy);
		base.Controls.Add(this.Label4);
		base.Controls.Add(this.numPort);
		base.Controls.Add(this.btnCancel);
		base.Controls.Add(this.btnOK);
		base.Controls.Add(this.txtPwd);
		base.Controls.Add(this.Label3);
		base.Controls.Add(this.txtUser);
		base.Controls.Add(this.Label2);
		base.Controls.Add(this.Label1);
		base.Controls.Add(this.txtIP);
		base.Controls.Add(this.Label16);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Margin = new global::System.Windows.Forms.Padding(1, 2, 1, 2);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "NewSocks";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Add Proxy";
		((global::System.ComponentModel.ISupportInitialize)this.numPort).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x04000578 RID: 1400
	private global::System.ComponentModel.IContainer icontainer_0;
}
