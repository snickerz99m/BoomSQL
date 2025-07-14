// Token: 0x020000BA RID: 186
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class SearchColumn : global::System.Windows.Forms.Form
{
	// Token: 0x06000AB9 RID: 2745 RVA: 0x00042518 File Offset: 0x00040718
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

	// Token: 0x06000ABA RID: 2746 RVA: 0x0004255C File Offset: 0x0004075C
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		this.stsMain = new global::System.Windows.Forms.StatusStrip();
		this.lblStatus = new global::System.Windows.Forms.ToolStripStatusLabel();
		this.mnuDumper = new global::System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.mnuDumper2 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuDumper1 = new global::System.Windows.Forms.ToolStripMenuItem();
		this.btnGoToDumper = new global::System.Windows.Forms.ToolStripDropDownButton();
		this.mnuListview = new global::System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.mnuShell = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuClipboard = new global::System.Windows.Forms.ToolStripMenuItem();
		this.mnuFocusItem = new global::System.Windows.Forms.ToolStripMenuItem();
		this.ColumnHeader5 = new global::System.Windows.Forms.ColumnHeader();
		this.ColumnHeader6 = new global::System.Windows.Forms.ColumnHeader();
		this.btnCopy = new global::System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
		this.btnSort = new global::System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
		this.cmbMinRows = new global::System.Windows.Forms.ToolStripComboBox();
		this.tsChecker2 = new global::System.Windows.Forms.ToolStrip();
		this.ToolStripLabel1 = new global::System.Windows.Forms.ToolStripLabel();
		this.cmbSearch = new global::System.Windows.Forms.ToolStripComboBox();
		this.lvwData = new global::ListViewExt();
		this.ColumnHeader1 = new global::System.Windows.Forms.ColumnHeader();
		this.ColumnHeader2 = new global::System.Windows.Forms.ColumnHeader();
		this.bckSort = new global::System.ComponentModel.BackgroundWorker();
		this.stsMain.SuspendLayout();
		this.mnuDumper.SuspendLayout();
		this.mnuListview.SuspendLayout();
		this.tsChecker2.SuspendLayout();
		base.SuspendLayout();
		this.stsMain.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.stsMain.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.lblStatus
		});
		this.stsMain.Location = new global::System.Drawing.Point(0, 538);
		this.stsMain.Name = "stsMain";
		this.stsMain.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.Professional;
		this.stsMain.Size = new global::System.Drawing.Size(488, 22);
		this.stsMain.TabIndex = 3;
		this.stsMain.Text = "StatusStrip1";
		this.lblStatus.Name = "lblStatus";
		this.lblStatus.Size = new global::System.Drawing.Size(473, 17);
		this.lblStatus.Spring = true;
		this.lblStatus.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
		this.mnuDumper.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.mnuDumper.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.mnuDumper2,
			this.mnuDumper1
		});
		this.mnuDumper.Name = "mnuListView";
		this.mnuDumper.OwnerItem = this.btnGoToDumper;
		this.mnuDumper.ShowImageMargin = false;
		this.mnuDumper.Size = new global::System.Drawing.Size(167, 48);
		this.mnuDumper2.Name = "mnuDumper2";
		this.mnuDumper2.Size = new global::System.Drawing.Size(166, 22);
		this.mnuDumper2.Text = "New Dumper Instance";
		this.mnuDumper1.Name = "mnuDumper1";
		this.mnuDumper1.Size = new global::System.Drawing.Size(166, 22);
		this.mnuDumper1.Text = "Dumper Form";
		this.btnGoToDumper.DropDown = this.mnuDumper;
		this.btnGoToDumper.Enabled = false;
		this.btnGoToDumper.Image = global::ns0.Class6.OpenTopic_16x_24;
		this.btnGoToDumper.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnGoToDumper.Name = "btnGoToDumper";
		this.btnGoToDumper.Size = new global::System.Drawing.Size(120, 22);
		this.btnGoToDumper.Text = "&Go To Dumper";
		this.mnuListview.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.mnuListview.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.mnuShell,
			this.mnuClipboard,
			this.mnuFocusItem
		});
		this.mnuListview.Name = "mnuListView";
		this.mnuListview.ShowImageMargin = false;
		this.mnuListview.Size = new global::System.Drawing.Size(133, 70);
		this.mnuShell.Name = "mnuShell";
		this.mnuShell.Size = new global::System.Drawing.Size(132, 22);
		this.mnuShell.Text = "Shell URL";
		this.mnuClipboard.Name = "mnuClipboard";
		this.mnuClipboard.Size = new global::System.Drawing.Size(132, 22);
		this.mnuClipboard.Text = "Clipboard URL";
		this.mnuFocusItem.Name = "mnuFocusItem";
		this.mnuFocusItem.Size = new global::System.Drawing.Size(132, 22);
		this.mnuFocusItem.Text = "Focus Grid Item";
		this.ColumnHeader5.Text = "Description";
		this.ColumnHeader5.Width = 89;
		this.ColumnHeader6.Text = "Value";
		this.ColumnHeader6.Width = 342;
		this.btnCopy.Image = global::ns0.Class6.clipboard_16xLG;
		this.btnCopy.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnCopy.Name = "btnCopy";
		this.btnCopy.Size = new global::System.Drawing.Size(87, 22);
		this.btnCopy.Text = "&Clipboard";
		this.ToolStripSeparator1.Name = "ToolStripSeparator1";
		this.ToolStripSeparator1.Size = new global::System.Drawing.Size(6, 25);
		this.btnSort.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.btnSort.Image = global::ns0.Class6.GetDynamicValuePropertyactivity_16x_24;
		this.btnSort.ImageTransparentColor = global::System.Drawing.Color.Magenta;
		this.btnSort.Name = "btnSort";
		this.btnSort.Size = new global::System.Drawing.Size(56, 22);
		this.btnSort.Text = "&Sort";
		this.ToolStripSeparator2.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.ToolStripSeparator2.Name = "ToolStripSeparator2";
		this.ToolStripSeparator2.Size = new global::System.Drawing.Size(6, 25);
		this.cmbMinRows.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.cmbMinRows.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbMinRows.Name = "cmbMinRows";
		this.cmbMinRows.Size = new global::System.Drawing.Size(75, 25);
		this.tsChecker2.AutoSize = false;
		this.tsChecker2.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.tsChecker2.ImageScalingSize = new global::System.Drawing.Size(24, 24);
		this.tsChecker2.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.btnCopy,
			this.ToolStripSeparator1,
			this.btnGoToDumper,
			this.btnSort,
			this.ToolStripSeparator2,
			this.cmbMinRows,
			this.ToolStripLabel1,
			this.cmbSearch
		});
		this.tsChecker2.Location = new global::System.Drawing.Point(0, 0);
		this.tsChecker2.Name = "tsChecker2";
		this.tsChecker2.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.Professional;
		this.tsChecker2.Size = new global::System.Drawing.Size(488, 25);
		this.tsChecker2.TabIndex = 4;
		this.tsChecker2.Text = "ToolStrip1";
		this.ToolStripLabel1.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.ToolStripLabel1.Name = "ToolStripLabel1";
		this.ToolStripLabel1.Size = new global::System.Drawing.Size(68, 22);
		this.ToolStripLabel1.Text = "Min.. Rows:";
		this.cmbSearch.Alignment = global::System.Windows.Forms.ToolStripItemAlignment.Right;
		this.cmbSearch.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbSearch.Name = "cmbSearch";
		this.cmbSearch.Size = new global::System.Drawing.Size(75, 23);
		this.lvwData.AccessibleDescription = "";
		this.lvwData.AccessibleName = "";
		this.lvwData.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
		{
			this.ColumnHeader1,
			this.ColumnHeader2
		});
		this.lvwData.ContextMenuStrip = this.mnuListview;
		this.lvwData.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.lvwData.Font = new global::System.Drawing.Font("Courier New", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
		this.lvwData.ForeColor = global::System.Drawing.SystemColors.ControlText;
		this.lvwData.FullRowSelect = true;
		this.lvwData.GridLines = true;
		this.lvwData.HeaderStyle = global::System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
		this.lvwData.HideSelection = false;
		this.lvwData.Location = new global::System.Drawing.Point(0, 25);
		this.lvwData.Name = "lvwData";
		this.lvwData.ShowItemToolTips = true;
		this.lvwData.Size = new global::System.Drawing.Size(488, 513);
		this.lvwData.TabIndex = 2;
		this.lvwData.UseCompatibleStateImageBehavior = false;
		this.lvwData.View = global::System.Windows.Forms.View.Details;
		this.ColumnHeader1.Text = "";
		this.ColumnHeader1.Width = 84;
		this.ColumnHeader2.Text = "";
		this.ColumnHeader2.Width = 369;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(488, 560);
		base.Controls.Add(this.lvwData);
		base.Controls.Add(this.tsChecker2);
		base.Controls.Add(this.stsMain);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		base.Name = "SearchColumn";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
		this.Text = "Search Column";
		this.stsMain.ResumeLayout(false);
		this.stsMain.PerformLayout();
		this.mnuDumper.ResumeLayout(false);
		this.mnuListview.ResumeLayout(false);
		this.tsChecker2.ResumeLayout(false);
		this.tsChecker2.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x04000541 RID: 1345
	private global::System.ComponentModel.IContainer icontainer_0;
}
