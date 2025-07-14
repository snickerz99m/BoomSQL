// Token: 0x020000EC RID: 236
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class SocksCheck : global::System.Windows.Forms.Form
{
	// Token: 0x06001043 RID: 4163 RVA: 0x0006FF58 File Offset: 0x0006E158
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

	// Token: 0x06001044 RID: 4164 RVA: 0x0006FF9C File Offset: 0x0006E19C
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.ToolStrip1 = new global::System.Windows.Forms.ToolStrip();
		this.btnStart = new global::System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
		this.btnPause = new global::System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator3 = new global::System.Windows.Forms.ToolStripSeparator();
		this.btnStop = new global::System.Windows.Forms.ToolStripButton();
		this.btnOK = new global::System.Windows.Forms.ToolStripButton();
		this.Label2 = new global::System.Windows.Forms.Label();
		this.Label3 = new global::System.Windows.Forms.Label();
		this.stsMain = new global::System.Windows.Forms.StatusStrip();
		this.lblStatus = new global::System.Windows.Forms.ToolStripStatusLabel();
		this.pgbChecker = new global::System.Windows.Forms.ProgressBar();
		this.bckWorker = new global::System.ComponentModel.BackgroundWorker();
		this.numTimeout = new global::System.Windows.Forms.NumericUpDown();
		this.numThreads = new global::System.Windows.Forms.NumericUpDown();
		this.ToolStrip1.SuspendLayout();
		this.stsMain.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.numTimeout).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.numThreads).BeginInit();
		base.SuspendLayout();
		this.ToolStrip1.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.ToolStrip1.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.ToolStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.btnStart,
			this.ToolStripSeparator2,
			this.btnPause,
			this.ToolStripSeparator3,
			this.btnStop,
			this.btnOK
		});
		this.ToolStrip1.Location = new global::System.Drawing.Point(0, 0);
		this.ToolStrip1.Name = "ToolStrip1";
		this.ToolStrip1.Padding = new global::System.Windows.Forms.Padding(0, 0, 2, 0);
		this.ToolStrip1.Size = new global::System.Drawing.Size(390, 32);
		this.ToolStrip1.TabIndex = 0;
		this.ToolStrip1.Text = "ToolStrip1";
		this.btnStart.Image = global::ns0.Class6.Run_16x_24;
		this.btnStart.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnStart.Name = "btnStart";
		this.btnStart.Size = new global::System.Drawing.Size(76, 29);
		this.btnStart.Text = "&Start";
		this.ToolStripSeparator2.Name = "ToolStripSeparator2";
		this.ToolStripSeparator2.Size = new global::System.Drawing.Size(6, 32);
		this.btnPause.CheckOnClick = true;
		this.btnPause.Enabled = false;
		this.btnPause.Image = global::ns0.Class6.Pause_16x_24;
		this.btnPause.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnPause.Name = "btnPause";
		this.btnPause.Size = new global::System.Drawing.Size(85, 29);
		this.btnPause.Text = "&Pause";
		this.btnPause.Visible = false;
		this.ToolStripSeparator3.Name = "ToolStripSeparator3";
		this.ToolStripSeparator3.Size = new global::System.Drawing.Size(6, 32);
		this.ToolStripSeparator3.Visible = false;
		this.btnStop.Enabled = false;
		this.btnStop.Image = global::ns0.Class6.Stop_16x_24;
		this.btnStop.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnStop.Name = "btnStop";
		this.btnStop.Size = new global::System.Drawing.Size(77, 29);
		this.btnStop.Text = "&Stop";
		this.btnOK.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.btnOK.Enabled = false;
		this.btnOK.Image = global::ns0.Class6.AddAgent_16x_24;
		this.btnOK.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnOK.Name = "btnOK";
		this.btnOK.Size = new global::System.Drawing.Size(64, 29);
		this.btnOK.Text = "&OK";
		this.Label2.Location = new global::System.Drawing.Point(196, 43);
		this.Label2.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
		this.Label2.Name = "Label2";
		this.Label2.Size = new global::System.Drawing.Size(93, 26);
		this.Label2.TabIndex = 14;
		this.Label2.Text = "Timeout";
		this.Label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.Label3.Location = new global::System.Drawing.Point(6, 43);
		this.Label3.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
		this.Label3.Name = "Label3";
		this.Label3.Size = new global::System.Drawing.Size(93, 26);
		this.Label3.TabIndex = 12;
		this.Label3.Text = "Threads";
		this.Label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.stsMain.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.stsMain.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.lblStatus
		});
		this.stsMain.Location = new global::System.Drawing.Point(0, 132);
		this.stsMain.Name = "stsMain";
		this.stsMain.Padding = new global::System.Windows.Forms.Padding(2, 0, 21, 0);
		this.stsMain.Size = new global::System.Drawing.Size(390, 30);
		this.stsMain.SizingGrip = false;
		this.stsMain.TabIndex = 16;
		this.stsMain.Text = "Ready.";
		this.lblStatus.Name = "lblStatus";
		this.lblStatus.Size = new global::System.Drawing.Size(367, 25);
		this.lblStatus.Spring = true;
		this.lblStatus.Text = "Socks Checker";
		this.lblStatus.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
		this.pgbChecker.Location = new global::System.Drawing.Point(10, 83);
		this.pgbChecker.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		this.pgbChecker.Name = "pgbChecker";
		this.pgbChecker.Size = new global::System.Drawing.Size(366, 35);
		this.pgbChecker.TabIndex = 5;
		this.bckWorker.WorkerSupportsCancellation = true;
		global::System.Windows.Forms.NumericUpDown numTimeout = this.numTimeout;
		int[] array = new int[4];
		array[0] = 5;
		numTimeout.Increment = new decimal(array);
		this.numTimeout.Location = new global::System.Drawing.Point(298, 43);
		this.numTimeout.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		global::System.Windows.Forms.NumericUpDown numTimeout2 = this.numTimeout;
		int[] array2 = new int[4];
		array2[0] = 30;
		numTimeout2.Maximum = new decimal(array2);
		global::System.Windows.Forms.NumericUpDown numTimeout3 = this.numTimeout;
		int[] array3 = new int[4];
		array3[0] = 5;
		numTimeout3.Minimum = new decimal(array3);
		this.numTimeout.Name = "numTimeout";
		this.numTimeout.Size = new global::System.Drawing.Size(78, 26);
		this.numTimeout.TabIndex = 1;
		global::System.Windows.Forms.NumericUpDown numTimeout4 = this.numTimeout;
		int[] array4 = new int[4];
		array4[0] = 20;
		numTimeout4.Value = new decimal(array4);
		global::System.Windows.Forms.NumericUpDown numThreads = this.numThreads;
		int[] array5 = new int[4];
		array5[0] = 10;
		numThreads.Increment = new decimal(array5);
		this.numThreads.Location = new global::System.Drawing.Point(108, 43);
		this.numThreads.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		global::System.Windows.Forms.NumericUpDown numThreads2 = this.numThreads;
		int[] array6 = new int[4];
		array6[0] = 1;
		numThreads2.Minimum = new decimal(array6);
		this.numThreads.Name = "numThreads";
		this.numThreads.Size = new global::System.Drawing.Size(78, 26);
		this.numThreads.TabIndex = 2;
		global::System.Windows.Forms.NumericUpDown numThreads3 = this.numThreads;
		int[] array7 = new int[4];
		array7[0] = 30;
		numThreads3.Value = new decimal(array7);
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(390, 162);
		base.Controls.Add(this.pgbChecker);
		base.Controls.Add(this.stsMain);
		base.Controls.Add(this.numTimeout);
		base.Controls.Add(this.Label2);
		base.Controls.Add(this.numThreads);
		base.Controls.Add(this.Label3);
		base.Controls.Add(this.ToolStrip1);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "SocksCheck";
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Socks Check";
		this.ToolStrip1.ResumeLayout(false);
		this.ToolStrip1.PerformLayout();
		this.stsMain.ResumeLayout(false);
		this.stsMain.PerformLayout();
		((global::System.ComponentModel.ISupportInitialize)this.numTimeout).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.numThreads).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x04000807 RID: 2055
	private global::System.ComponentModel.IContainer icontainer_0;
}
