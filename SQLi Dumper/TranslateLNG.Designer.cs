// Token: 0x020000E5 RID: 229
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class TranslateLNG : global::System.Windows.Forms.Form
{
	// Token: 0x06000FE6 RID: 4070 RVA: 0x0006D47C File Offset: 0x0006B67C
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

	// Token: 0x06000FE7 RID: 4071 RVA: 0x0006D4C0 File Offset: 0x0006B6C0
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.tsChecked = new global::System.Windows.Forms.ToolStrip();
		this.cmbFileInclusaoSearch = new global::System.Windows.Forms.ToolStripTextBox();
		this.btnSave = new global::System.Windows.Forms.ToolStripButton();
		this.stMain = new global::System.Windows.Forms.StatusStrip();
		this.lblMainStatus = new global::System.Windows.Forms.ToolStripStatusLabel();
		this.pnlControls = new global::System.Windows.Forms.Panel();
		this.tsChecked.SuspendLayout();
		this.stMain.SuspendLayout();
		base.SuspendLayout();
		this.tsChecked.AutoSize = false;
		this.tsChecked.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.tsChecked.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.cmbFileInclusaoSearch,
			this.btnSave
		});
		this.tsChecked.Location = new global::System.Drawing.Point(0, 0);
		this.tsChecked.Name = "tsChecked";
		this.tsChecked.Padding = new global::System.Windows.Forms.Padding(0, 0, 2, 0);
		this.tsChecked.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.System;
		this.tsChecked.Size = new global::System.Drawing.Size(913, 48);
		this.tsChecked.TabIndex = 4;
		this.tsChecked.Text = "ToolStrip2";
		this.cmbFileInclusaoSearch.Name = "cmbFileInclusaoSearch";
		this.cmbFileInclusaoSearch.Size = new global::System.Drawing.Size(180, 48);
		this.btnSave.Image = global::ns0.Class6.SaveFileDialogControl_16x_24;
		this.btnSave.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnSave.Name = "btnSave";
		this.btnSave.Size = new global::System.Drawing.Size(77, 45);
		this.btnSave.Text = "Save";
		this.stMain.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.lblMainStatus
		});
		this.stMain.Location = new global::System.Drawing.Point(0, 623);
		this.stMain.Name = "stMain";
		this.stMain.Padding = new global::System.Windows.Forms.Padding(2, 0, 21, 0);
		this.stMain.Size = new global::System.Drawing.Size(913, 30);
		this.stMain.Stretch = false;
		this.stMain.TabIndex = 12;
		this.stMain.Text = "StatusStrip1";
		this.lblMainStatus.Name = "lblMainStatus";
		this.lblMainStatus.Size = new global::System.Drawing.Size(890, 25);
		this.lblMainStatus.Spring = true;
		this.lblMainStatus.Text = "Ready";
		this.lblMainStatus.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
		this.pnlControls.AutoScroll = true;
		this.pnlControls.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.pnlControls.Location = new global::System.Drawing.Point(0, 48);
		this.pnlControls.Name = "pnlControls";
		this.pnlControls.Size = new global::System.Drawing.Size(913, 575);
		this.pnlControls.TabIndex = 13;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(913, 653);
		base.Controls.Add(this.pnlControls);
		base.Controls.Add(this.stMain);
		base.Controls.Add(this.tsChecked);
		base.Name = "TranslateLNG";
		this.Text = "TranslateLNG";
		this.tsChecked.ResumeLayout(false);
		this.tsChecked.PerformLayout();
		this.stMain.ResumeLayout(false);
		this.stMain.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x040007E7 RID: 2023
	private global::System.ComponentModel.IContainer icontainer_0;
}
