// Token: 0x020000B4 RID: 180
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class Exporter : global::System.Windows.Forms.Form
{
	// Token: 0x06000A50 RID: 2640 RVA: 0x0003FA9C File Offset: 0x0003DC9C
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

	// Token: 0x06000A51 RID: 2641 RVA: 0x0003FAE0 File Offset: 0x0003DCE0
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.OK_Button = new global::System.Windows.Forms.Button();
		this.Cancel_Button = new global::System.Windows.Forms.Button();
		this.grbDelimiter = new global::System.Windows.Forms.GroupBox();
		this.txtDeli = new global::System.Windows.Forms.TextBox();
		this.rdbOpt2 = new global::System.Windows.Forms.RadioButton();
		this.rdbOpt1 = new global::System.Windows.Forms.RadioButton();
		this.bwSave = new global::System.ComponentModel.BackgroundWorker();
		this.grbColumns = new global::System.Windows.Forms.GroupBox();
		this.lsColumns = new global::System.Windows.Forms.CheckedListBox();
		this.grbType = new global::System.Windows.Forms.GroupBox();
		this.rdpType_3 = new global::System.Windows.Forms.RadioButton();
		this.rdpType_2 = new global::System.Windows.Forms.RadioButton();
		this.rdpType_1 = new global::System.Windows.Forms.RadioButton();
		this.Panel1 = new global::System.Windows.Forms.Panel();
		this.grbDelimiter.SuspendLayout();
		this.grbColumns.SuspendLayout();
		this.grbType.SuspendLayout();
		this.Panel1.SuspendLayout();
		base.SuspendLayout();
		this.OK_Button.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
		this.OK_Button.Location = new global::System.Drawing.Point(168, 12);
		this.OK_Button.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.OK_Button.Name = "OK_Button";
		this.OK_Button.Size = new global::System.Drawing.Size(132, 30);
		this.OK_Button.TabIndex = 3;
		this.OK_Button.Text = "OK";
		this.Cancel_Button.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
		this.Cancel_Button.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
		this.Cancel_Button.Location = new global::System.Drawing.Point(7, 12);
		this.Cancel_Button.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.Cancel_Button.Name = "Cancel_Button";
		this.Cancel_Button.Size = new global::System.Drawing.Size(132, 30);
		this.Cancel_Button.TabIndex = 4;
		this.Cancel_Button.Text = "Exit";
		this.grbDelimiter.Controls.Add(this.txtDeli);
		this.grbDelimiter.Controls.Add(this.rdbOpt2);
		this.grbDelimiter.Controls.Add(this.rdbOpt1);
		this.grbDelimiter.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.grbDelimiter.Location = new global::System.Drawing.Point(0, 66);
		this.grbDelimiter.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbDelimiter.Name = "grbDelimiter";
		this.grbDelimiter.Padding = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbDelimiter.Size = new global::System.Drawing.Size(307, 105);
		this.grbDelimiter.TabIndex = 0;
		this.grbDelimiter.TabStop = false;
		this.grbDelimiter.Text = "Delimiter";
		this.txtDeli.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.txtDeli.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.txtDeli.Location = new global::System.Drawing.Point(153, 60);
		this.txtDeli.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.txtDeli.Name = "txtDeli";
		this.txtDeli.Size = new global::System.Drawing.Size(150, 26);
		this.txtDeli.TabIndex = 2;
		this.txtDeli.Text = ":";
		this.rdbOpt2.AutoSize = true;
		this.rdbOpt2.Checked = true;
		this.rdbOpt2.Location = new global::System.Drawing.Point(9, 65);
		this.rdbOpt2.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.rdbOpt2.Name = "rdbOpt2";
		this.rdbOpt2.Size = new global::System.Drawing.Size(89, 24);
		this.rdbOpt2.TabIndex = 1;
		this.rdbOpt2.TabStop = true;
		this.rdbOpt2.Text = "Custom";
		this.rdbOpt2.UseVisualStyleBackColor = true;
		this.rdbOpt1.AutoSize = true;
		this.rdbOpt1.Location = new global::System.Drawing.Point(9, 29);
		this.rdbOpt1.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.rdbOpt1.Name = "rdbOpt1";
		this.rdbOpt1.Size = new global::System.Drawing.Size(99, 24);
		this.rdbOpt1.TabIndex = 0;
		this.rdbOpt1.Text = "Char Tab";
		this.rdbOpt1.UseVisualStyleBackColor = true;
		this.bwSave.WorkerReportsProgress = true;
		this.bwSave.WorkerSupportsCancellation = true;
		this.grbColumns.Controls.Add(this.lsColumns);
		this.grbColumns.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.grbColumns.Location = new global::System.Drawing.Point(0, 171);
		this.grbColumns.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbColumns.Name = "grbColumns";
		this.grbColumns.Padding = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbColumns.Size = new global::System.Drawing.Size(307, 222);
		this.grbColumns.TabIndex = 1;
		this.grbColumns.TabStop = false;
		this.grbColumns.Text = "Columns";
		this.lsColumns.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.lsColumns.FormattingEnabled = true;
		this.lsColumns.Items.AddRange(new object[]
		{
			"Email",
			"Password",
			"MailBoxCount",
			"Host",
			"Date"
		});
		this.lsColumns.Location = new global::System.Drawing.Point(4, 24);
		this.lsColumns.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.lsColumns.Name = "lsColumns";
		this.lsColumns.Size = new global::System.Drawing.Size(299, 193);
		this.lsColumns.TabIndex = 0;
		this.grbType.Controls.Add(this.rdpType_3);
		this.grbType.Controls.Add(this.rdpType_2);
		this.grbType.Controls.Add(this.rdpType_1);
		this.grbType.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.grbType.Location = new global::System.Drawing.Point(0, 0);
		this.grbType.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbType.Name = "grbType";
		this.grbType.Padding = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbType.Size = new global::System.Drawing.Size(307, 66);
		this.grbType.TabIndex = 6;
		this.grbType.TabStop = false;
		this.grbType.Text = "File Type";
		this.rdpType_3.AutoSize = true;
		this.rdpType_3.Location = new global::System.Drawing.Point(226, 29);
		this.rdpType_3.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.rdpType_3.Name = "rdpType_3";
		this.rdpType_3.Size = new global::System.Drawing.Size(67, 24);
		this.rdpType_3.TabIndex = 2;
		this.rdpType_3.Text = "XML";
		this.rdpType_3.UseVisualStyleBackColor = true;
		this.rdpType_2.AutoSize = true;
		this.rdpType_2.Location = new global::System.Drawing.Point(128, 29);
		this.rdpType_2.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.rdpType_2.Name = "rdpType_2";
		this.rdpType_2.Size = new global::System.Drawing.Size(77, 24);
		this.rdpType_2.TabIndex = 1;
		this.rdpType_2.Text = "HTML";
		this.rdpType_2.UseVisualStyleBackColor = true;
		this.rdpType_1.AutoSize = true;
		this.rdpType_1.Checked = true;
		this.rdpType_1.Location = new global::System.Drawing.Point(9, 29);
		this.rdpType_1.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.rdpType_1.Name = "rdpType_1";
		this.rdpType_1.Size = new global::System.Drawing.Size(98, 24);
		this.rdpType_1.TabIndex = 0;
		this.rdpType_1.TabStop = true;
		this.rdpType_1.Text = "PlainText";
		this.rdpType_1.UseVisualStyleBackColor = true;
		this.Panel1.Controls.Add(this.OK_Button);
		this.Panel1.Controls.Add(this.Cancel_Button);
		this.Panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
		this.Panel1.Location = new global::System.Drawing.Point(0, 393);
		this.Panel1.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new global::System.Drawing.Size(307, 55);
		this.Panel1.TabIndex = 7;
		base.AcceptButton = this.OK_Button;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.Cancel_Button;
		base.ClientSize = new global::System.Drawing.Size(307, 448);
		base.ControlBox = false;
		base.Controls.Add(this.grbColumns);
		base.Controls.Add(this.Panel1);
		base.Controls.Add(this.grbDelimiter);
		base.Controls.Add(this.grbType);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Exporter";
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Data Exporter";
		this.grbDelimiter.ResumeLayout(false);
		this.grbDelimiter.PerformLayout();
		this.grbColumns.ResumeLayout(false);
		this.grbType.ResumeLayout(false);
		this.grbType.PerformLayout();
		this.Panel1.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	// Token: 0x04000512 RID: 1298
	private global::System.ComponentModel.IContainer icontainer_0;
}
