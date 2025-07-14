// Token: 0x02000087 RID: 135
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class DumpGrid : global::System.Windows.Forms.Form
{
	// Token: 0x0600076D RID: 1901 RVA: 0x00035A80 File Offset: 0x00033C80
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

	// Token: 0x0600076E RID: 1902 RVA: 0x00035AC4 File Offset: 0x00033CC4
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		this.mnuListView = new global::System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.mnuClipboard = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuClipboardAll = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuNewWindowsSP = new global::System.Windows.Forms.ToolStripSeparator();
		this.munClipboardCell = new global::System.Windows.Forms.ToolStripMenuItem();
		this.dtgData = new global::System.Windows.Forms.DataGridView();
		this.DataGridViewTextBoxColumn_0 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.ToolStrip5 = new global::System.Windows.Forms.ToolStrip();
		this.btnFullView = new global::System.Windows.Forms.ToolStripButton();
		this.tsSP = new global::System.Windows.Forms.ToolStripSeparator();
		this.btnAutoScroll = new global::System.Windows.Forms.ToolStripButton();
		this.tsSP2 = new global::System.Windows.Forms.ToolStripSeparator();
		this.btnExpTXT = new global::System.Windows.Forms.ToolStripButton();
		this.tsSP3 = new global::System.Windows.Forms.ToolStripSeparator();
		this.btnClipboard = new global::System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator15 = new global::System.Windows.Forms.ToolStripSeparator();
		this.btnCloseGrid = new global::System.Windows.Forms.ToolStripButton();
		this.btnCloseAllButThis = new global::System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator3 = new global::System.Windows.Forms.ToolStripSeparator();
		this.btnCloseAllGrids = new global::System.Windows.Forms.ToolStripButton();
		this.txtResult = new global::System.Windows.Forms.TextBox();
		this.mnuListView.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.dtgData).BeginInit();
		this.ToolStrip5.SuspendLayout();
		base.SuspendLayout();
		this.mnuListView.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.mnuListView.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.mnuClipboard,
			this.mnuClipboardAll,
			this.mnuNewWindowsSP,
			this.munClipboardCell
		});
		this.mnuListView.Name = "mnuListView";
		this.mnuListView.ShowImageMargin = false;
		this.mnuListView.Size = new global::System.Drawing.Size(210, 100);
		this.mnuClipboard.Name = "mnuClipboard";
		this.mnuClipboard.Size = new global::System.Drawing.Size(209, 30);
		this.mnuClipboard.Text = "&Clipboard";
		this.mnuClipboardAll.Name = "mnuClipboardAll";
		this.mnuClipboardAll.Size = new global::System.Drawing.Size(209, 30);
		this.mnuClipboardAll.Text = "Clipboard &All Rows";
		this.mnuNewWindowsSP.Name = "mnuNewWindowsSP";
		this.mnuNewWindowsSP.Size = new global::System.Drawing.Size(206, 6);
		this.munClipboardCell.Name = "munClipboardCell";
		this.munClipboardCell.Size = new global::System.Drawing.Size(209, 30);
		this.munClipboardCell.Text = "Clipboard &Cell(s)";
		this.dtgData.AllowDrop = true;
		this.dtgData.AllowUserToAddRows = false;
		this.dtgData.BackgroundColor = global::System.Drawing.SystemColors.Window;
		this.dtgData.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
		this.dtgData.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dtgData.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
		{
			this.DataGridViewTextBoxColumn_0
		});
		this.dtgData.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.dtgData.Location = new global::System.Drawing.Point(0, 32);
		this.dtgData.Name = "dtgData";
		this.dtgData.RowHeadersWidth = 60;
		this.dtgData.ShowCellErrors = false;
		this.dtgData.ShowCellToolTips = false;
		this.dtgData.ShowEditingIcon = false;
		this.dtgData.ShowRowErrors = false;
		this.dtgData.Size = new global::System.Drawing.Size(825, 463);
		this.dtgData.TabIndex = 15;
		this.DataGridViewTextBoxColumn_0.HeaderText = "ID";
		this.DataGridViewTextBoxColumn_0.Name = "ID";
		this.DataGridViewTextBoxColumn_0.Visible = false;
		this.ToolStrip5.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.ToolStrip5.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.ToolStrip5.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.btnFullView,
			this.tsSP,
			this.btnAutoScroll,
			this.tsSP2,
			this.btnExpTXT,
			this.tsSP3,
			this.btnClipboard,
			this.ToolStripSeparator15,
			this.btnCloseGrid,
			this.btnCloseAllButThis,
			this.ToolStripSeparator3,
			this.btnCloseAllGrids
		});
		this.ToolStrip5.Location = new global::System.Drawing.Point(0, 0);
		this.ToolStrip5.Name = "ToolStrip5";
		this.ToolStrip5.Size = new global::System.Drawing.Size(825, 32);
		this.ToolStrip5.TabIndex = 17;
		this.ToolStrip5.Text = "ToolStrip5";
		this.btnFullView.CheckOnClick = true;
		this.btnFullView.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.btnFullView.Image = global::ns0.Class6.ViewLandscape_16x_24;
		this.btnFullView.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnFullView.Name = "btnFullView";
		this.btnFullView.Size = new global::System.Drawing.Size(109, 29);
		this.btnFullView.Text = "&Full View";
		this.tsSP.Name = "tsSP";
		this.tsSP.Size = new global::System.Drawing.Size(6, 32);
		this.btnAutoScroll.CheckOnClick = true;
		this.btnAutoScroll.Image = global::ns0.Class6.Download_grey_inverse_24;
		this.btnAutoScroll.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnAutoScroll.Name = "btnAutoScroll";
		this.btnAutoScroll.Size = new global::System.Drawing.Size(127, 29);
		this.btnAutoScroll.Text = "&Auto Scroll";
		this.tsSP2.Name = "tsSP2";
		this.tsSP2.Size = new global::System.Drawing.Size(6, 32);
		this.btnExpTXT.Image = global::ns0.Class6.SaveFileDialogControl_16x_24;
		this.btnExpTXT.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnExpTXT.Name = "btnExpTXT";
		this.btnExpTXT.Size = new global::System.Drawing.Size(133, 29);
		this.btnExpTXT.Text = "&Export Data";
		this.tsSP3.Name = "tsSP3";
		this.tsSP3.Size = new global::System.Drawing.Size(6, 32);
		this.btnClipboard.Image = global::ns0.Class6.clipboard_16xLG;
		this.btnClipboard.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnClipboard.Name = "btnClipboard";
		this.btnClipboard.Size = new global::System.Drawing.Size(118, 29);
		this.btnClipboard.Text = "&Clipboard";
		this.ToolStripSeparator15.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.ToolStripSeparator15.Name = "ToolStripSeparator15";
		this.ToolStripSeparator15.Size = new global::System.Drawing.Size(6, 32);
		this.btnCloseGrid.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.btnCloseGrid.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.btnCloseGrid.Image = global::ns0.Class6.CloseSolution_inverse_16x_24;
		this.btnCloseGrid.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnCloseGrid.Name = "btnCloseGrid";
		this.btnCloseGrid.Size = new global::System.Drawing.Size(121, 29);
		this.btnCloseGrid.Text = "&Close Grid";
		this.btnCloseAllButThis.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.btnCloseAllButThis.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.btnCloseAllButThis.Image = global::ns0.Class6.CloseDocumentGroup_16x_24;
		this.btnCloseAllButThis.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnCloseAllButThis.Name = "btnCloseAllButThis";
		this.btnCloseAllButThis.Size = new global::System.Drawing.Size(175, 29);
		this.btnCloseAllButThis.Text = "&Close All But This";
		this.ToolStripSeparator3.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.ToolStripSeparator3.Name = "ToolStripSeparator3";
		this.ToolStripSeparator3.Size = new global::System.Drawing.Size(6, 25);
		this.btnCloseAllGrids.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.btnCloseAllGrids.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.btnCloseAllGrids.Image = global::ns0.Class6.CloseGroup_16x_24;
		this.btnCloseAllGrids.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnCloseAllGrids.Name = "btnCloseAllGrids";
		this.btnCloseAllGrids.Size = new global::System.Drawing.Size(154, 29);
		this.btnCloseAllGrids.Text = "&Close All Grids";
		this.txtResult.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.txtResult.Font = new global::System.Drawing.Font("Courier New", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.txtResult.Location = new global::System.Drawing.Point(0, 32);
		this.txtResult.MaxLength = 999999999;
		this.txtResult.Multiline = true;
		this.txtResult.Name = "txtResult";
		this.txtResult.ReadOnly = true;
		this.txtResult.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
		this.txtResult.Size = new global::System.Drawing.Size(825, 463);
		this.txtResult.TabIndex = 18;
		this.txtResult.Visible = false;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 21f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = global::System.Drawing.SystemColors.Control;
		base.ClientSize = new global::System.Drawing.Size(825, 495);
		base.Controls.Add(this.txtResult);
		base.Controls.Add(this.dtgData);
		base.Controls.Add(this.ToolStrip5);
		this.Font = new global::System.Drawing.Font("Tahoma", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		base.MaximizeBox = false;
		base.Name = "DumpGrid";
		base.ShowInTaskbar = false;
		this.Text = "Dump";
		this.mnuListView.ResumeLayout(false);
		((global::System.ComponentModel.ISupportInitialize)this.dtgData).EndInit();
		this.ToolStrip5.ResumeLayout(false);
		this.ToolStrip5.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x040003F3 RID: 1011
	private global::System.ComponentModel.IContainer icontainer_0;
}
