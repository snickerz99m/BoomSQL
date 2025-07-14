// Token: 0x0200008C RID: 140
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class DumpExporter : global::System.Windows.Forms.Form
{
	// Token: 0x060007BC RID: 1980 RVA: 0x00036EA8 File Offset: 0x000350A8
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

	// Token: 0x060007BD RID: 1981 RVA: 0x00036EEC File Offset: 0x000350EC
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		this.OK_Button = new global::System.Windows.Forms.Button();
		this.Cancel_Button = new global::System.Windows.Forms.Button();
		this.grbDelimiter = new global::System.Windows.Forms.GroupBox();
		this.chkReplaceLines = new global::System.Windows.Forms.CheckBox();
		this.txtDeli = new global::System.Windows.Forms.TextBox();
		this.txtReplaceLine = new global::System.Windows.Forms.TextBox();
		this.rdbOpt2 = new global::System.Windows.Forms.RadioButton();
		this.rdbOpt1 = new global::System.Windows.Forms.RadioButton();
		this.stsMain = new global::System.Windows.Forms.StatusStrip();
		this.lblStatus = new global::System.Windows.Forms.ToolStripStatusLabel();
		this.bwSave = new global::System.ComponentModel.BackgroundWorker();
		this.grbColumns = new global::System.Windows.Forms.GroupBox();
		this.lsColumns = new global::System.Windows.Forms.CheckedListBox();
		this.mnuColumns = new global::System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.mnuMoveUP = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuMoveDown = new global::System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
		this.mmnCheck = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mmnUnCheck = new global::System.Windows.Forms.ToolStripMenuItem();
		this.grbType = new global::System.Windows.Forms.GroupBox();
		this.rdpType_3 = new global::System.Windows.Forms.RadioButton();
		this.rdpType_2 = new global::System.Windows.Forms.RadioButton();
		this.rdpType_1 = new global::System.Windows.Forms.RadioButton();
		this.Panel1 = new global::System.Windows.Forms.Panel();
		this.prbStatus = new global::System.Windows.Forms.ProgressBar();
		this.grbDelimiter.SuspendLayout();
		this.stsMain.SuspendLayout();
		this.grbColumns.SuspendLayout();
		this.mnuColumns.SuspendLayout();
		this.grbType.SuspendLayout();
		this.Panel1.SuspendLayout();
		base.SuspendLayout();
		this.OK_Button.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
		this.OK_Button.Location = new global::System.Drawing.Point(203, 9);
		this.OK_Button.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.OK_Button.Name = "OK_Button";
		this.OK_Button.Size = new global::System.Drawing.Size(100, 30);
		this.OK_Button.TabIndex = 3;
		this.OK_Button.Text = "OK";
		this.Cancel_Button.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
		this.Cancel_Button.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
		this.Cancel_Button.Location = new global::System.Drawing.Point(203, 45);
		this.Cancel_Button.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.Cancel_Button.Name = "Cancel_Button";
		this.Cancel_Button.Size = new global::System.Drawing.Size(100, 30);
		this.Cancel_Button.TabIndex = 4;
		this.Cancel_Button.Text = "Exit";
		this.grbDelimiter.Controls.Add(this.chkReplaceLines);
		this.grbDelimiter.Controls.Add(this.txtDeli);
		this.grbDelimiter.Controls.Add(this.txtReplaceLine);
		this.grbDelimiter.Controls.Add(this.rdbOpt2);
		this.grbDelimiter.Controls.Add(this.rdbOpt1);
		this.grbDelimiter.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.grbDelimiter.Location = new global::System.Drawing.Point(0, 66);
		this.grbDelimiter.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbDelimiter.Name = "grbDelimiter";
		this.grbDelimiter.Padding = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbDelimiter.Size = new global::System.Drawing.Size(309, 140);
		this.grbDelimiter.TabIndex = 0;
		this.grbDelimiter.TabStop = false;
		this.grbDelimiter.Text = "Delimiter";
		this.chkReplaceLines.AutoSize = true;
		this.chkReplaceLines.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.chkReplaceLines.Checked = true;
		this.chkReplaceLines.CheckState = global::System.Windows.Forms.CheckState.Checked;
		this.chkReplaceLines.Location = new global::System.Drawing.Point(9, 105);
		this.chkReplaceLines.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.chkReplaceLines.Name = "chkReplaceLines";
		this.chkReplaceLines.Size = new global::System.Drawing.Size(136, 24);
		this.chkReplaceLines.TabIndex = 3;
		this.chkReplaceLines.Text = "Replace Lines";
		this.chkReplaceLines.UseVisualStyleBackColor = true;
		this.txtDeli.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.txtDeli.Enabled = false;
		this.txtDeli.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.txtDeli.Location = new global::System.Drawing.Point(159, 60);
		this.txtDeli.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.txtDeli.Name = "txtDeli";
		this.txtDeli.Size = new global::System.Drawing.Size(146, 26);
		this.txtDeli.TabIndex = 2;
		this.txtDeli.Text = ":";
		this.txtReplaceLine.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.txtReplaceLine.Enabled = false;
		this.txtReplaceLine.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.txtReplaceLine.Location = new global::System.Drawing.Point(159, 100);
		this.txtReplaceLine.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.txtReplaceLine.Name = "txtReplaceLine";
		this.txtReplaceLine.Size = new global::System.Drawing.Size(144, 26);
		this.txtReplaceLine.TabIndex = 2;
		this.txtReplaceLine.Text = "{NewLine}";
		this.rdbOpt2.AutoSize = true;
		this.rdbOpt2.Location = new global::System.Drawing.Point(9, 65);
		this.rdbOpt2.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.rdbOpt2.Name = "rdbOpt2";
		this.rdbOpt2.Size = new global::System.Drawing.Size(89, 24);
		this.rdbOpt2.TabIndex = 1;
		this.rdbOpt2.Text = "Custom";
		this.rdbOpt2.UseVisualStyleBackColor = true;
		this.rdbOpt1.AutoSize = true;
		this.rdbOpt1.Checked = true;
		this.rdbOpt1.Location = new global::System.Drawing.Point(9, 29);
		this.rdbOpt1.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.rdbOpt1.Name = "rdbOpt1";
		this.rdbOpt1.Size = new global::System.Drawing.Size(99, 24);
		this.rdbOpt1.TabIndex = 0;
		this.rdbOpt1.TabStop = true;
		this.rdbOpt1.Text = "Char Tab";
		this.rdbOpt1.UseVisualStyleBackColor = true;
		this.stsMain.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.stsMain.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.lblStatus
		});
		this.stsMain.Location = new global::System.Drawing.Point(0, 477);
		this.stsMain.Name = "stsMain";
		this.stsMain.Padding = new global::System.Windows.Forms.Padding(2, 0, 21, 0);
		this.stsMain.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.Professional;
		this.stsMain.Size = new global::System.Drawing.Size(309, 30);
		this.stsMain.TabIndex = 3;
		this.stsMain.Text = "StatusStrip1";
		this.lblStatus.AutoToolTip = true;
		this.lblStatus.Name = "lblStatus";
		this.lblStatus.Size = new global::System.Drawing.Size(286, 25);
		this.lblStatus.Spring = true;
		this.lblStatus.Text = "Ready";
		this.lblStatus.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
		this.bwSave.WorkerReportsProgress = true;
		this.bwSave.WorkerSupportsCancellation = true;
		this.grbColumns.Controls.Add(this.lsColumns);
		this.grbColumns.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.grbColumns.Location = new global::System.Drawing.Point(0, 206);
		this.grbColumns.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbColumns.Name = "grbColumns";
		this.grbColumns.Padding = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbColumns.Size = new global::System.Drawing.Size(309, 188);
		this.grbColumns.TabIndex = 1;
		this.grbColumns.TabStop = false;
		this.grbColumns.Text = "Columns";
		this.lsColumns.ContextMenuStrip = this.mnuColumns;
		this.lsColumns.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.lsColumns.FormattingEnabled = true;
		this.lsColumns.Location = new global::System.Drawing.Point(4, 24);
		this.lsColumns.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.lsColumns.Name = "lsColumns";
		this.lsColumns.Size = new global::System.Drawing.Size(301, 159);
		this.lsColumns.TabIndex = 0;
		this.mnuColumns.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.mnuColumns.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.mnuMoveUP,
			this.mnuMoveDown,
			this.ToolStripSeparator1,
			this.mmnCheck,
			this.mmnUnCheck
		});
		this.mnuColumns.Name = "mnuColumns";
		this.mnuColumns.ShowImageMargin = false;
		this.mnuColumns.Size = new global::System.Drawing.Size(157, 130);
		this.mnuMoveUP.Name = "mnuMoveUP";
		this.mnuMoveUP.Size = new global::System.Drawing.Size(156, 30);
		this.mnuMoveUP.Text = "Move UP";
		this.mnuMoveDown.Name = "mnuMoveDown";
		this.mnuMoveDown.Size = new global::System.Drawing.Size(156, 30);
		this.mnuMoveDown.Text = "Move Down";
		this.ToolStripSeparator1.Name = "ToolStripSeparator1";
		this.ToolStripSeparator1.Size = new global::System.Drawing.Size(153, 6);
		this.mmnCheck.Name = "mmnCheck";
		this.mmnCheck.Size = new global::System.Drawing.Size(156, 30);
		this.mmnCheck.Text = "Check All";
		this.mmnUnCheck.Name = "mmnUnCheck";
		this.mmnUnCheck.Size = new global::System.Drawing.Size(156, 30);
		this.mmnUnCheck.Text = "UnCheck All";
		this.grbType.Controls.Add(this.rdpType_3);
		this.grbType.Controls.Add(this.rdpType_2);
		this.grbType.Controls.Add(this.rdpType_1);
		this.grbType.Dock = global::System.Windows.Forms.DockStyle.Top;
		this.grbType.Location = new global::System.Drawing.Point(0, 0);
		this.grbType.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbType.Name = "grbType";
		this.grbType.Padding = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.grbType.Size = new global::System.Drawing.Size(309, 66);
		this.grbType.TabIndex = 6;
		this.grbType.TabStop = false;
		this.grbType.Text = "File Type";
		this.rdpType_3.AutoSize = true;
		this.rdpType_3.Location = new global::System.Drawing.Point(220, 29);
		this.rdpType_3.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.rdpType_3.Name = "rdpType_3";
		this.rdpType_3.Size = new global::System.Drawing.Size(67, 24);
		this.rdpType_3.TabIndex = 2;
		this.rdpType_3.Text = "XML";
		this.rdpType_3.UseVisualStyleBackColor = true;
		this.rdpType_2.AutoSize = true;
		this.rdpType_2.Location = new global::System.Drawing.Point(125, 29);
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
		this.Panel1.Controls.Add(this.prbStatus);
		this.Panel1.Controls.Add(this.OK_Button);
		this.Panel1.Controls.Add(this.Cancel_Button);
		this.Panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
		this.Panel1.Location = new global::System.Drawing.Point(0, 394);
		this.Panel1.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new global::System.Drawing.Size(309, 83);
		this.Panel1.TabIndex = 7;
		this.prbStatus.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.prbStatus.Location = new global::System.Drawing.Point(4, 9);
		this.prbStatus.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.prbStatus.Name = "prbStatus";
		this.prbStatus.Size = new global::System.Drawing.Size(191, 66);
		this.prbStatus.Style = global::System.Windows.Forms.ProgressBarStyle.Continuous;
		this.prbStatus.TabIndex = 4;
		this.prbStatus.Visible = false;
		base.AcceptButton = this.OK_Button;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.Cancel_Button;
		base.ClientSize = new global::System.Drawing.Size(309, 507);
		base.ControlBox = false;
		base.Controls.Add(this.grbColumns);
		base.Controls.Add(this.Panel1);
		base.Controls.Add(this.stsMain);
		base.Controls.Add(this.grbDelimiter);
		base.Controls.Add(this.grbType);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		base.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		this.MinimumSize = new global::System.Drawing.Size(300, 478);
		base.Name = "DumpExporter";
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Data Exporter";
		this.grbDelimiter.ResumeLayout(false);
		this.grbDelimiter.PerformLayout();
		this.stsMain.ResumeLayout(false);
		this.stsMain.PerformLayout();
		this.grbColumns.ResumeLayout(false);
		this.mnuColumns.ResumeLayout(false);
		this.grbType.ResumeLayout(false);
		this.grbType.PerformLayout();
		this.Panel1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x0400040F RID: 1039
	private global::System.ComponentModel.IContainer icontainer_0;
}
