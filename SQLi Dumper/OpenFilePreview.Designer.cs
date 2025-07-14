// Token: 0x020000C3 RID: 195
[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
public partial class OpenFilePreview : global::System.Windows.Forms.Form
{
	// Token: 0x06000B44 RID: 2884 RVA: 0x00045888 File Offset: 0x00043A88
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

	// Token: 0x06000B45 RID: 2885 RVA: 0x000458CC File Offset: 0x00043ACC
	[global::System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.btnOK = new global::System.Windows.Forms.Button();
		this.btnCancel = new global::System.Windows.Forms.Button();
		this.txtPreview = new global::System.Windows.Forms.TextBox();
		this.Label1 = new global::System.Windows.Forms.Label();
		this.numLineIndex = new global::System.Windows.Forms.NumericUpDown();
		((global::System.ComponentModel.ISupportInitialize)this.numLineIndex).BeginInit();
		base.SuspendLayout();
		this.btnOK.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.btnOK.Location = new global::System.Drawing.Point(395, 413);
		this.btnOK.Margin = new global::System.Windows.Forms.Padding(4);
		this.btnOK.Name = "btnOK";
		this.btnOK.Size = new global::System.Drawing.Size(111, 30);
		this.btnOK.TabIndex = 3;
		this.btnOK.Text = "Start Worker";
		this.btnOK.UseVisualStyleBackColor = true;
		this.btnCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.Location = new global::System.Drawing.Point(281, 413);
		this.btnCancel.Margin = new global::System.Windows.Forms.Padding(4);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new global::System.Drawing.Size(111, 30);
		this.btnCancel.TabIndex = 4;
		this.btnCancel.Text = "Cancel";
		this.btnCancel.UseVisualStyleBackColor = true;
		this.txtPreview.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.txtPreview.Location = new global::System.Drawing.Point(4, 4);
		this.txtPreview.Multiline = true;
		this.txtPreview.Name = "txtPreview";
		this.txtPreview.ReadOnly = true;
		this.txtPreview.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
		this.txtPreview.Size = new global::System.Drawing.Size(502, 405);
		this.txtPreview.TabIndex = 5;
		this.txtPreview.WordWrap = false;
		this.Label1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.Label1.Location = new global::System.Drawing.Point(131, 418);
		this.Label1.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
		this.Label1.Name = "Label1";
		this.Label1.Size = new global::System.Drawing.Size(142, 26);
		this.Label1.TabIndex = 6;
		this.Label1.Text = "Start Line Index";
		this.Label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
		this.numLineIndex.Location = new global::System.Drawing.Point(4, 419);
		global::System.Windows.Forms.NumericUpDown numLineIndex = this.numLineIndex;
		int[] array = new int[4];
		array[0] = 1;
		numLineIndex.Minimum = new decimal(array);
		this.numLineIndex.Name = "numLineIndex";
		this.numLineIndex.Size = new global::System.Drawing.Size(120, 26);
		this.numLineIndex.TabIndex = 7;
		global::System.Windows.Forms.NumericUpDown numLineIndex2 = this.numLineIndex;
		int[] array2 = new int[4];
		array2[0] = 1;
		numLineIndex2.Value = new decimal(array2);
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.btnCancel;
		base.ClientSize = new global::System.Drawing.Size(511, 449);
		base.Controls.Add(this.numLineIndex);
		base.Controls.Add(this.Label1);
		base.Controls.Add(this.txtPreview);
		base.Controls.Add(this.btnOK);
		base.Controls.Add(this.btnCancel);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "OpenFilePreview";
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "OpenFilePreview";
		((global::System.ComponentModel.ISupportInitialize)this.numLineIndex).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x04000585 RID: 1413
	private global::System.ComponentModel.IContainer icontainer_0;
}
