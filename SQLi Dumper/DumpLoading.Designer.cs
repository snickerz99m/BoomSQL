// Token: 0x02000090 RID: 144
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class DumpLoading : global::System.Windows.Forms.Form
{
	// Token: 0x0600080A RID: 2058 RVA: 0x0003919C File Offset: 0x0003739C
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

	// Token: 0x0600080B RID: 2059 RVA: 0x000391E0 File Offset: 0x000373E0
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.grbBack = new global::System.Windows.Forms.GroupBox();
		this.prgStatus = new global::System.Windows.Forms.ProgressBar();
		this.tstMain = new global::System.Windows.Forms.ToolStrip();
		this.tsbPause = new global::System.Windows.Forms.ToolStripButton();
		this.tsbStop = new global::System.Windows.Forms.ToolStripButton();
		this.grbBack.SuspendLayout();
		this.tstMain.SuspendLayout();
		base.SuspendLayout();
		this.grbBack.Controls.Add(this.prgStatus);
		this.grbBack.Controls.Add(this.tstMain);
		this.grbBack.Dock = global::System.Windows.Forms.DockStyle.Bottom;
		this.grbBack.Font = new global::System.Drawing.Font("Tahoma", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.grbBack.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.grbBack.Location = new global::System.Drawing.Point(0, 33);
		this.grbBack.MinimumSize = new global::System.Drawing.Size(0, 16);
		this.grbBack.Name = "grbBack";
		this.grbBack.Size = new global::System.Drawing.Size(636, 45);
		this.grbBack.TabIndex = 0;
		this.grbBack.TabStop = false;
		this.grbBack.Text = "Loading, please wait..";
		this.prgStatus.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.prgStatus.Location = new global::System.Drawing.Point(10, 15);
		this.prgStatus.Name = "prgStatus";
		this.prgStatus.Size = new global::System.Drawing.Size(484, 19);
		this.prgStatus.Style = global::System.Windows.Forms.ProgressBarStyle.Continuous;
		this.prgStatus.TabIndex = 0;
		this.tstMain.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.tstMain.AutoSize = false;
		this.tstMain.Dock = global::System.Windows.Forms.DockStyle.None;
		this.tstMain.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.tstMain.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.tstMain.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.tsbPause,
			this.tsbStop
		});
		this.tstMain.Location = new global::System.Drawing.Point(4, 13);
		this.tstMain.Name = "tstMain";
		this.tstMain.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.System;
		this.tstMain.Size = new global::System.Drawing.Size(628, 25);
		this.tstMain.TabIndex = 1;
		this.tstMain.Text = "ToolStrip1";
		this.tsbPause.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.tsbPause.CheckOnClick = true;
		this.tsbPause.Image = global::ns0.Class6.Pause_16x_24;
		this.tsbPause.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.tsbPause.Name = "tsbPause";
		this.tsbPause.Size = new global::System.Drawing.Size(85, 22);
		this.tsbPause.Text = "&Pause";
		this.tsbStop.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.tsbStop.Image = global::ns0.Class6.Stop_16x_24;
		this.tsbStop.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.tsbStop.Name = "tsbStop";
		this.tsbStop.Size = new global::System.Drawing.Size(91, 22);
		this.tsbStop.Text = "&Cancel";
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 21f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = global::System.Drawing.SystemColors.Control;
		base.ClientSize = new global::System.Drawing.Size(636, 78);
		base.ControlBox = false;
		base.Controls.Add(this.grbBack);
		this.Font = new global::System.Drawing.Font("Tahoma", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.Name = "DumpLoading";
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
		this.grbBack.ResumeLayout(false);
		this.tstMain.ResumeLayout(false);
		this.tstMain.PerformLayout();
		base.ResumeLayout(false);
	}

	// Token: 0x0400043B RID: 1083
	private global::System.ComponentModel.IContainer icontainer_0;
}
