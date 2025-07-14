using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x0200005A RID: 90
public class ToolStripSpringTextBox : ToolStripComboBox
{
	// Token: 0x060002AE RID: 686 RVA: 0x000030AE File Offset: 0x000012AE
	public ToolStripSpringTextBox(int Style = 0)
	{
		base.Leave += this.ToolStripSpringTextBox_Leave;
		base.GotFocus += this.ToolStripSpringTextBox_GotFocus;
		base.DropDownStyle = (ComboBoxStyle)Style;
	}

	// Token: 0x060002AF RID: 687 RVA: 0x000030E1 File Offset: 0x000012E1
	private void ToolStripSpringTextBox_Leave(object sender, EventArgs e)
	{
		base.SelectionStart = 0;
	}

	// Token: 0x060002B0 RID: 688 RVA: 0x000030E1 File Offset: 0x000012E1
	private void ToolStripSpringTextBox_GotFocus(object sender, EventArgs e)
	{
		base.SelectionStart = 0;
	}

	// Token: 0x060002B1 RID: 689 RVA: 0x00015368 File Offset: 0x00013568
	public override Size GetPreferredSize(Size constrainingSize)
	{
		checked
		{
			Size result;
			if (base.IsOnOverflow | base.Owner.Orientation == Orientation.Vertical)
			{
				result = this.DefaultSize;
			}
			else
			{
				int num = base.Owner.DisplayRectangle.Width;
				if (base.Owner.OverflowButton.Visible)
				{
					num = num - base.Owner.OverflowButton.Width - base.Owner.OverflowButton.Margin.Horizontal;
				}
				int num2 = 0;
				try
				{
					foreach (object obj in base.Owner.Items)
					{
						ToolStripItem toolStripItem = (ToolStripItem)obj;
						if (!toolStripItem.IsOnOverflow)
						{
							if (toolStripItem is ToolStripSpringTextBox)
							{
								num2++;
								num -= toolStripItem.Margin.Horizontal;
							}
							else
							{
								num = num - toolStripItem.Width - toolStripItem.Margin.Horizontal;
							}
						}
					}
				}
				finally
				{
					IEnumerator enumerator;
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				if (num2 > 1)
				{
					num = (int)Math.Round((double)num / (double)num2);
				}
				if (num < this.DefaultSize.Width)
				{
					num = this.DefaultSize.Width;
				}
				Size preferredSize = base.GetPreferredSize(constrainingSize);
				preferredSize.Width = num;
				result = preferredSize;
			}
			return result;
		}
	}

	// Token: 0x040001D3 RID: 467
	private ComboBoxStyle comboBoxStyle_0;

	// Token: 0x0200005B RID: 91
	// (Invoke) Token: 0x060002B5 RID: 693
	private delegate void Delegate14(object sender, EventArgs e);
}
