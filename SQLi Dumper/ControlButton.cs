using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x02000098 RID: 152
[DesignerGenerated]
internal sealed class ControlButton : Control
{
	// Token: 0x06000841 RID: 2113 RVA: 0x00039980 File Offset: 0x00037B80
	public ControlButton()
	{
		base.MouseEnter += this.MdiTab_MouseEnter;
		base.MouseLeave += this.MdiTab_MouseLeave;
		this.m_hot = false;
		this.defaultBackHighColor = SystemColors.ControlLightLight;
		this.defaultBackLowColor = SystemColors.ControlDark;
		this.defaultBorderColor = SystemColors.ControlDarkDark;
		this.InitializeComponent();
		base.SuspendLayout();
		base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		base.BackColor = Color.Transparent;
		this.ResetBackHighColor();
		this.ResetBackLowColor();
		this.ResetBorderColor();
		base.ResumeLayout();
	}

	// Token: 0x06000842 RID: 2114 RVA: 0x0000578A File Offset: 0x0000398A
	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.components != null)
		{
			this.components.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x06000843 RID: 2115 RVA: 0x000057AF File Offset: 0x000039AF
	[DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.components = new Container();
	}

	// Token: 0x17000295 RID: 661
	// (get) Token: 0x06000844 RID: 2116 RVA: 0x00039A1C File Offset: 0x00037C1C
	// (set) Token: 0x06000845 RID: 2117 RVA: 0x000057BC File Offset: 0x000039BC
	internal ToolStripRenderMode RenderMode
	{
		get
		{
			return this.m_RenderMode;
		}
		set
		{
			this.m_RenderMode = value;
			base.Invalidate();
		}
	}

	// Token: 0x17000296 RID: 662
	// (get) Token: 0x06000846 RID: 2118 RVA: 0x00039A34 File Offset: 0x00037C34
	// (set) Token: 0x06000847 RID: 2119 RVA: 0x000057CB File Offset: 0x000039CB
	public ControlButton.ButtonStyle Style
	{
		get
		{
			return this.m_style;
		}
		set
		{
			this.m_style = value;
		}
	}

	// Token: 0x17000297 RID: 663
	// (get) Token: 0x06000848 RID: 2120 RVA: 0x00039A4C File Offset: 0x00037C4C
	// (set) Token: 0x06000849 RID: 2121 RVA: 0x000057D4 File Offset: 0x000039D4
	[Browsable(true)]
	[Category("Appearance")]
	public Color BackHighColor
	{
		get
		{
			return this.m_BackHighColor;
		}
		set
		{
			this.m_BackHighColor = value;
		}
	}

	// Token: 0x0600084A RID: 2122 RVA: 0x000057DD File Offset: 0x000039DD
	public bool ShouldSerializeBackHighColor()
	{
		return this.m_BackHighColor != this.defaultBackHighColor;
	}

	// Token: 0x0600084B RID: 2123 RVA: 0x000057F0 File Offset: 0x000039F0
	public void ResetBackHighColor()
	{
		this.m_BackHighColor = this.defaultBackHighColor;
	}

	// Token: 0x17000298 RID: 664
	// (get) Token: 0x0600084C RID: 2124 RVA: 0x00039A64 File Offset: 0x00037C64
	// (set) Token: 0x0600084D RID: 2125 RVA: 0x000057FE File Offset: 0x000039FE
	[Category("Appearance")]
	[Browsable(true)]
	public Color BackLowColor
	{
		get
		{
			return this.m_BackLowColor;
		}
		set
		{
			this.m_BackLowColor = value;
		}
	}

	// Token: 0x0600084E RID: 2126 RVA: 0x00005807 File Offset: 0x00003A07
	public bool ShouldSerializeBackLowColor()
	{
		return this.m_BackLowColor != this.defaultBackLowColor;
	}

	// Token: 0x0600084F RID: 2127 RVA: 0x0000581A File Offset: 0x00003A1A
	public void ResetBackLowColor()
	{
		this.m_BackLowColor = this.defaultBackLowColor;
	}

	// Token: 0x17000299 RID: 665
	// (get) Token: 0x06000850 RID: 2128 RVA: 0x00039A7C File Offset: 0x00037C7C
	// (set) Token: 0x06000851 RID: 2129 RVA: 0x00005828 File Offset: 0x00003A28
	[Browsable(true)]
	[Category("Appearance")]
	public Color BorderColor
	{
		get
		{
			return this.m_BorderColor;
		}
		set
		{
			this.m_BorderColor = value;
		}
	}

	// Token: 0x06000852 RID: 2130 RVA: 0x00005831 File Offset: 0x00003A31
	public bool ShouldSerializeBorderColor()
	{
		return this.m_BorderColor != this.defaultBorderColor;
	}

	// Token: 0x06000853 RID: 2131 RVA: 0x00005844 File Offset: 0x00003A44
	public void ResetBorderColor()
	{
		this.m_BorderColor = this.defaultBorderColor;
	}

	// Token: 0x06000854 RID: 2132 RVA: 0x00039A94 File Offset: 0x00037C94
	[DebuggerStepThrough]
	protected override void OnPaint(PaintEventArgs e)
	{
		Point[] points = new Point[]
		{
			new Point(0, 0),
			new Point(11, 0),
			new Point(5, 6)
		};
		Point[] points2 = new Point[]
		{
			new Point(0, 0),
			new Point(2, 0),
			new Point(5, 3),
			new Point(8, 0),
			new Point(10, 0),
			new Point(6, 4),
			new Point(10, 8),
			new Point(8, 8),
			new Point(5, 5),
			new Point(2, 8),
			new Point(0, 8),
			new Point(4, 4)
		};
		Rectangle rect = default(Rectangle);
		checked
		{
			rect.Size = new Size(base.Width - 1, base.Height - 1);
			if (this.m_hot)
			{
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				e.Graphics.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height), Helper.RenderColors.ControlButtonBackHighColor(this.m_RenderMode, this.m_BackHighColor), Helper.RenderColors.ControlButtonBackLowColor(this.m_RenderMode, this.m_BackLowColor)), rect);
				e.Graphics.DrawRectangle(new Pen(Helper.RenderColors.ControlButtonBorderColor(this.m_RenderMode, this.m_BorderColor)), rect);
				e.Graphics.SmoothingMode = SmoothingMode.Default;
			}
			GraphicsPath graphicsPath = new GraphicsPath();
			Matrix matrix = new Matrix();
			int num = (int)Math.Round((double)(base.Width - 11) / 2.0);
			int num2 = (int)Math.Round(unchecked((double)(checked(base.Height - 11)) / 2.0 + 1.0));
			if (this.m_style == ControlButton.ButtonStyle.Drop)
			{
				e.Graphics.FillRectangle(new SolidBrush(this.ForeColor), num, num2, 11, 2);
				graphicsPath.AddPolygon(points);
				matrix.Translate((float)num, (float)(num2 + 3));
				graphicsPath.Transform(matrix);
				e.Graphics.FillPolygon(new SolidBrush(this.ForeColor), graphicsPath.PathPoints);
			}
			else
			{
				graphicsPath.AddPolygon(points2);
				matrix.Translate((float)num, (float)num2);
				graphicsPath.Transform(matrix);
				e.Graphics.DrawPolygon(new Pen(this.ForeColor), graphicsPath.PathPoints);
				e.Graphics.FillPolygon(new SolidBrush(this.ForeColor), graphicsPath.PathPoints);
			}
			graphicsPath.Dispose();
			matrix.Dispose();
		}
	}

	// Token: 0x06000855 RID: 2133 RVA: 0x00005852 File Offset: 0x00003A52
	private void MdiTab_MouseEnter(object sender, EventArgs e)
	{
		this.m_hot = true;
		base.Invalidate();
	}

	// Token: 0x06000856 RID: 2134 RVA: 0x00005861 File Offset: 0x00003A61
	private void MdiTab_MouseLeave(object sender, EventArgs e)
	{
		this.m_hot = false;
		base.Invalidate();
	}

	// Token: 0x04000449 RID: 1097
	private IContainer components;

	// Token: 0x0400044A RID: 1098
	private bool m_hot;

	// Token: 0x0400044B RID: 1099
	private Color m_BackHighColor;

	// Token: 0x0400044C RID: 1100
	private Color m_BackLowColor;

	// Token: 0x0400044D RID: 1101
	private Color m_BorderColor;

	// Token: 0x0400044E RID: 1102
	private ControlButton.ButtonStyle m_style;

	// Token: 0x0400044F RID: 1103
	private ToolStripRenderMode m_RenderMode;

	// Token: 0x04000450 RID: 1104
	private readonly Color defaultBackHighColor;

	// Token: 0x04000451 RID: 1105
	private readonly Color defaultBackLowColor;

	// Token: 0x04000452 RID: 1106
	private readonly Color defaultBorderColor;

	// Token: 0x02000099 RID: 153
	public enum ButtonStyle
	{
		// Token: 0x04000454 RID: 1108
		Close,
		// Token: 0x04000455 RID: 1109
		Drop
	}
}
