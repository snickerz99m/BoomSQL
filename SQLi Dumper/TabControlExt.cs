using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x0200009A RID: 154
[DesignerGenerated]
[DesignTimeVisible(true)]
public class TabControlExt : UserControl
{
	// Token: 0x06000857 RID: 2135 RVA: 0x00039D5C File Offset: 0x00037F5C
	public TabControlExt()
	{
		base.FontChanged += this.__TabControl_FontChanged;
		base.ForeColorChanged += this.__TabControl_ForeColorChanged;
		base.Paint += this.__TabControl_Paint;
		base.Resize += this.__TabControl_Resize;
		this.__LeftOffset = 3;
		this.__IsDelete = false;
		this.__Background = new Panel();
		this.__Items = new TabControlExt.__TabPageCollection(this);
		this.__TabsDirection = TabControlExt.FlowDirection.LeftToRight;
		this.__TabMaximumWidth = 200;
		this.__TabMinimumWidth = 100;
		this.__TopSeparator = true;
		this.__TabTop = 3;
		this.__TabHeight = 28;
		this.__TabOffset = 3;
		this.__TabPadLeft = 5;
		this.__TabPadRight = 5;
		this.__TabSmoothingMode = SmoothingMode.None;
		this.__TabIconSize = new Size(16, 16);
		this.__Alignment = TabControlExt.TabAlignment.Top;
		this.__FontBoldOnSelect = true;
		this.__HotTrack = true;
		this.__TabCloseButtonSize = new Size(17, 17);
		this.__TabCloseButtonVisible = true;
		this.__AllowTabReorder = true;
		this.__TabGlassGradient = false;
		this.__TabBorderEnhanced = false;
		this.__TabBorderEnhanceWeight = TabControlExt.Weight.Medium;
		this.defaultPadding = new Padding(0, 0, 0, 0);
		this.defaultBackLowColor = SystemColors.ControlLightLight;
		this.defaultBackHighColor = SystemColors.Control;
		this.defaultBorderColor = SystemColors.ControlDarkDark;
		this.defaultTabBackHighColor = SystemColors.Window;
		this.defaultTabBackLowColor = SystemColors.Control;
		this.defaultTabBackHighColorDisabled = SystemColors.Control;
		this.defaultTabBackLowColorDisabled = SystemColors.ControlDark;
		this.defaultBorderColorDisabled = SystemColors.ControlDark;
		this.defaultForeColorDisabled = SystemColors.ControlText;
		this.defaultControlButtonBackHighColor = SystemColors.GradientInactiveCaption;
		this.defaultControlButtonBackLowColor = SystemColors.GradientInactiveCaption;
		this.defaultControlButtonBorderColor = SystemColors.HotTrack;
		this.defaultControlButtonForeColor = SystemColors.ControlText;
		this.defaultTabCloseButtonSize = new Size(17, 17);
		this.defaultTabIconSize = new Size(16, 16);
		this.defaultTabCloseButtonBackHighColor = Color.IndianRed;
		this.defaultTabCloseButtonBackHighColorDisabled = Color.LightGray;
		this.defaultTabCloseButtonBackHighColorHot = Color.LightCoral;
		this.defaultTabCloseButtonBackLowColor = Color.Firebrick;
		this.defaultTabCloseButtonBackLowColorDisabled = Color.DarkGray;
		this.defaultTabCloseButtonBackLowColorHot = Color.IndianRed;
		this.defaultTabCloseButtonBorderColor = Color.DarkRed;
		this.defaultTabCloseButtonBorderColorDisabled = Color.Gray;
		this.defaultTabCloseButtonBorderColorHot = Color.Firebrick;
		this.defaultTabCloseButtonForeColor = Color.White;
		this.defaultTabCloseButtonForeColorDisabled = Color.White;
		this.defaultTabCloseButtonForeColorHot = Color.White;
		this.defaultRenderMode = ToolStripRenderMode.ManagerRenderMode;
		this.InitializeComponent();
		base.SuspendLayout();
		base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		this.__Background.BackColor = SystemColors.AppWorkspace;
		this.__Background.BorderStyle = BorderStyle.Fixed3D;
		this.__Background.Dock = DockStyle.Fill;
		base.Controls.Add(this.__Background);
		this.__Background.BringToFront();
		this.ResetBackLowColor();
		this.ResetBackHighColor();
		this.ResetBorderColor();
		this.ResetTabBackHighColor();
		this.ResetTabBackLowColor();
		this.ResetTabBackHighColorDisabled();
		this.ResetTabBackLowColorDisabled();
		this.ResetBorderColorDisabled();
		this.ResetForeColorDisabled();
		this.ResetControlButtonBackHighColor();
		this.ResetControlButtonBackLowColor();
		this.ResetControlButtonBorderColor();
		this.ResetControlButtonForeColor();
		this.ResetTabCloseButtonBackHighColor();
		this.ResetTabCloseButtonBackLowColor();
		this.ResetTabCloseButtonBorderColor();
		this.ResetTabCloseButtonForeColor();
		this.ResetTabCloseButtonBackHighColorDisabled();
		this.ResetTabCloseButtonBackLowColorDisabled();
		this.ResetTabCloseButtonBorderColorDisabled();
		this.ResetTabCloseButtonForeColorDisabled();
		this.ResetTabCloseButtonBackHighColorHot();
		this.ResetTabCloseButtonBackLowColorHot();
		this.ResetTabCloseButtonBorderColorHot();
		this.ResetTabCloseButtonForeColorHot();
		this.ResetPadding();
		this.ResetTabCloseButtonSize();
		this.ResetTabIconSize();
		this.ResetRenderMode();
		this.AdjustHeight();
		this.DropButton.RenderMode = this.RenderMode;
		this.CloseButton.RenderMode = this.RenderMode;
		base.ResumeLayout();
	}

	// Token: 0x06000858 RID: 2136 RVA: 0x00005870 File Offset: 0x00003A70
	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.components != null)
		{
			this.components.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x06000859 RID: 2137 RVA: 0x0003A104 File Offset: 0x00038304
	[DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.components = new Container();
		this.pnlTop = new Panel();
		this.pnlControls = new Panel();
		this.DropButton = new ControlButton();
		this.CloseButton = new ControlButton();
		this.pnlTabs = new Panel();
		this.pnlBottom = new Panel();
		this.WinMenu = new ContextMenuStrip(this.components);
		this.TabToolTip = new ToolTip(this.components);
		this.pnlTop.SuspendLayout();
		this.pnlControls.SuspendLayout();
		base.SuspendLayout();
		this.pnlTop.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.pnlTop.BackColor = Color.Transparent;
		this.pnlTop.Controls.Add(this.pnlControls);
		this.pnlTop.Controls.Add(this.pnlTabs);
		this.pnlTop.Location = new Point(0, 0);
		this.pnlTop.Name = "pnlTop";
		this.pnlTop.Size = new Size(200, 31);
		this.pnlTop.TabIndex = 6;
		this.pnlControls.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
		this.pnlControls.Controls.Add(this.DropButton);
		this.pnlControls.Controls.Add(this.CloseButton);
		this.pnlControls.Location = new Point(175, 0);
		this.pnlControls.Name = "pnlControls";
		this.pnlControls.Size = new Size(25, 30);
		this.pnlControls.TabIndex = 1;
		this.DropButton.BackColor = Color.Transparent;
		this.DropButton.Location = new Point(4, 8);
		this.DropButton.Name = "DropButton";
		this.DropButton.Size = new Size(17, 15);
		this.DropButton.Style = ControlButton.ButtonStyle.Drop;
		this.DropButton.TabIndex = 0;
		this.CloseButton.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.CloseButton.BackColor = Color.Transparent;
		this.CloseButton.Location = new Point(4, 8);
		this.CloseButton.Name = "CloseButton";
		this.CloseButton.Size = new Size(17, 15);
		this.CloseButton.Style = ControlButton.ButtonStyle.Close;
		this.CloseButton.TabIndex = 0;
		this.CloseButton.Visible = false;
		this.pnlTabs.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		this.pnlTabs.BackColor = Color.Transparent;
		this.pnlTabs.Location = new Point(0, 3);
		this.pnlTabs.Name = "pnlTabs";
		this.pnlTabs.Size = new Size(200, 28);
		this.pnlTabs.TabIndex = 0;
		this.pnlBottom.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.pnlBottom.Location = new Point(0, 31);
		this.pnlBottom.Name = "pnlBottom";
		this.pnlBottom.Size = new Size(200, 99);
		this.pnlBottom.TabIndex = 7;
		this.WinMenu.Name = "WinMenu";
		this.WinMenu.Size = new Size(153, 26);
		base.AutoScaleMode = AutoScaleMode.None;
		base.Controls.Add(this.pnlTop);
		base.Controls.Add(this.pnlBottom);
		base.Name = "TabControl";
		base.Size = new Size(200, 130);
		this.pnlTop.ResumeLayout(false);
		this.pnlControls.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	// Token: 0x1700029A RID: 666
	// (get) Token: 0x0600085A RID: 2138 RVA: 0x00005895 File Offset: 0x00003A95
	// (set) Token: 0x0600085B RID: 2139 RVA: 0x0003A4C4 File Offset: 0x000386C4
	internal virtual Panel pnlTop
	{
		[CompilerGenerated]
		get
		{
			return this._pnlTop;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.pnlTop_SizeChanged);
			PaintEventHandler value3 = new PaintEventHandler(this.pnlTop_Paint);
			Panel pnlTop = this._pnlTop;
			if (pnlTop != null)
			{
				pnlTop.SizeChanged -= value2;
				pnlTop.Paint -= value3;
			}
			this._pnlTop = value;
			pnlTop = this._pnlTop;
			if (pnlTop != null)
			{
				pnlTop.SizeChanged += value2;
				pnlTop.Paint += value3;
			}
		}
	}

	// Token: 0x1700029B RID: 667
	// (get) Token: 0x0600085C RID: 2140 RVA: 0x0000589D File Offset: 0x00003A9D
	// (set) Token: 0x0600085D RID: 2141 RVA: 0x000058A5 File Offset: 0x00003AA5
	internal virtual Panel pnlTabs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700029C RID: 668
	// (get) Token: 0x0600085E RID: 2142 RVA: 0x000058AE File Offset: 0x00003AAE
	// (set) Token: 0x0600085F RID: 2143 RVA: 0x000058B6 File Offset: 0x00003AB6
	internal virtual Panel pnlBottom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700029D RID: 669
	// (get) Token: 0x06000860 RID: 2144 RVA: 0x000058BF File Offset: 0x00003ABF
	// (set) Token: 0x06000861 RID: 2145 RVA: 0x000058C7 File Offset: 0x00003AC7
	internal virtual ContextMenuStrip WinMenu { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700029E RID: 670
	// (get) Token: 0x06000862 RID: 2146 RVA: 0x000058D0 File Offset: 0x00003AD0
	// (set) Token: 0x06000863 RID: 2147 RVA: 0x0003A524 File Offset: 0x00038724
	internal virtual ControlButton DropButton
	{
		[CompilerGenerated]
		get
		{
			return this._DropButton;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			MouseEventHandler value2 = new MouseEventHandler(this.DropButton_MouseDown);
			ControlButton dropButton = this._DropButton;
			if (dropButton != null)
			{
				dropButton.MouseDown -= value2;
			}
			this._DropButton = value;
			dropButton = this._DropButton;
			if (dropButton != null)
			{
				dropButton.MouseDown += value2;
			}
		}
	}

	// Token: 0x1700029F RID: 671
	// (get) Token: 0x06000864 RID: 2148 RVA: 0x000058D8 File Offset: 0x00003AD8
	// (set) Token: 0x06000865 RID: 2149 RVA: 0x000058E0 File Offset: 0x00003AE0
	internal virtual ToolTip TabToolTip { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170002A0 RID: 672
	// (get) Token: 0x06000866 RID: 2150 RVA: 0x000058E9 File Offset: 0x00003AE9
	// (set) Token: 0x06000867 RID: 2151 RVA: 0x0003A568 File Offset: 0x00038768
	internal virtual ControlButton CloseButton
	{
		[CompilerGenerated]
		get
		{
			return this._CloseButton;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			MouseEventHandler value2 = new MouseEventHandler(this.CloseButton_MouseDown);
			ControlButton closeButton = this._CloseButton;
			if (closeButton != null)
			{
				closeButton.MouseDown -= value2;
			}
			this._CloseButton = value;
			closeButton = this._CloseButton;
			if (closeButton != null)
			{
				closeButton.MouseDown += value2;
			}
		}
	}

	// Token: 0x170002A1 RID: 673
	// (get) Token: 0x06000868 RID: 2152 RVA: 0x000058F1 File Offset: 0x00003AF1
	// (set) Token: 0x06000869 RID: 2153 RVA: 0x000058F9 File Offset: 0x00003AF9
	internal virtual Panel pnlControls { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170002A2 RID: 674
	// (get) Token: 0x0600086A RID: 2154 RVA: 0x00005902 File Offset: 0x00003B02
	// (set) Token: 0x0600086B RID: 2155 RVA: 0x0003A5AC File Offset: 0x000387AC
	private virtual TabControlExt.__TabPageCollection __Items
	{
		[CompilerGenerated]
		get
		{
			return this.___Items;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			TabControlExt.__TabPageCollection.GetTabRegionEventHandler value2 = new TabControlExt.__TabPageCollection.GetTabRegionEventHandler(this.__ItemsGetTabRegion);
			TabControlExt.__TabPageCollection.TabPaint__BackgroundEventHandler value3 = new TabControlExt.__TabPageCollection.TabPaint__BackgroundEventHandler(this.__ItemsTabPaint__Background);
			TabControlExt.__TabPageCollection.TabPaintBorderEventHandler value4 = new TabControlExt.__TabPageCollection.TabPaintBorderEventHandler(this.__ItemsTabPaintBorder);
			TabControlExt.__TabPageCollection __Items = this.___Items;
			if (__Items != null)
			{
				__Items.GetTabRegion -= value2;
				__Items.TabPaint__Background -= value3;
				__Items.TabPaintBorder -= value4;
			}
			this.___Items = value;
			__Items = this.___Items;
			if (__Items != null)
			{
				__Items.GetTabRegion += value2;
				__Items.TabPaint__Background += value3;
				__Items.TabPaintBorder += value4;
			}
		}
	}

	// Token: 0x14000005 RID: 5
	// (add) Token: 0x0600086C RID: 2156 RVA: 0x0003A628 File Offset: 0x00038828
	// (remove) Token: 0x0600086D RID: 2157 RVA: 0x0003A660 File Offset: 0x00038860
	[Description("Occurs when the Tab Page requests the tab region.")]
	public event TabControlExt.GetTabRegionEventHandler GetTabRegion;

	// Token: 0x14000006 RID: 6
	// (add) Token: 0x0600086E RID: 2158 RVA: 0x0003A698 File Offset: 0x00038898
	// (remove) Token: 0x0600086F RID: 2159 RVA: 0x0003A6D0 File Offset: 0x000388D0
	[Description("Occurs when the Tab __Background has been painted.")]
	public event TabControlExt.TabPaintBackgroundEventHandler TabPaintBackground;

	// Token: 0x14000007 RID: 7
	// (add) Token: 0x06000870 RID: 2160 RVA: 0x0003A708 File Offset: 0x00038908
	// (remove) Token: 0x06000871 RID: 2161 RVA: 0x0003A740 File Offset: 0x00038940
	[Description("Occurs when the Tab Border has been painted.")]
	public event TabControlExt.TabPaintBorderEventHandler TabPaintBorder;

	// Token: 0x14000008 RID: 8
	// (add) Token: 0x06000872 RID: 2162 RVA: 0x0003A778 File Offset: 0x00038978
	// (remove) Token: 0x06000873 RID: 2163 RVA: 0x0003A7B0 File Offset: 0x000389B0
	public event TabControlExt.TabSelectedFormEventHandler TabSelectedForm;

	// Token: 0x170002A3 RID: 675
	// (get) Token: 0x06000874 RID: 2164 RVA: 0x0000590A File Offset: 0x00003B0A
	// (set) Token: 0x06000875 RID: 2165 RVA: 0x00005912 File Offset: 0x00003B12
	public Form SelectedFormIndex { get; set; }

	// Token: 0x06000876 RID: 2166 RVA: 0x0003A7E8 File Offset: 0x000389E8
	public Panel GetBackground()
	{
		return this.__Background;
	}

	// Token: 0x170002A4 RID: 676
	// (get) Token: 0x06000877 RID: 2167 RVA: 0x0003A800 File Offset: 0x00038A00
	[Browsable(false)]
	public object SelectedForm
	{
		get
		{
			object result;
			if (this.pnlBottom.Controls.Count > 0)
			{
				result = this.pnlBottom.Controls[0];
			}
			else
			{
				result = null;
			}
			return result;
		}
	}

	// Token: 0x170002A5 RID: 677
	// (get) Token: 0x06000878 RID: 2168 RVA: 0x0003A83C File Offset: 0x00038A3C
	// (set) Token: 0x06000879 RID: 2169 RVA: 0x0000591B File Offset: 0x00003B1B
	[Description("Gets or sets the the direction which the tabs are drawn.")]
	[Category("Layout")]
	[DefaultValue(0)]
	[Browsable(true)]
	public TabControlExt.FlowDirection TabsDirection
	{
		get
		{
			return this.__TabsDirection;
		}
		set
		{
			this.__TabsDirection = value;
			this.SelectItem(-1);
		}
	}

	// Token: 0x170002A6 RID: 678
	// (get) Token: 0x0600087A RID: 2170 RVA: 0x0000592B File Offset: 0x00003B2B
	// (set) Token: 0x0600087B RID: 2171 RVA: 0x0003A854 File Offset: 0x00038A54
	[Description("Gets or sets if the tab __Background will paint with glass style.")]
	[DefaultValue(false)]
	[Category("Appearance")]
	[Browsable(true)]
	public bool TabGlassGradient
	{
		get
		{
			return this.__TabGlassGradient;
		}
		set
		{
			this.__TabGlassGradient = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.GlassGradient = value;
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
		}
	}

	// Token: 0x170002A7 RID: 679
	// (get) Token: 0x0600087C RID: 2172 RVA: 0x00005933 File Offset: 0x00003B33
	// (set) Token: 0x0600087D RID: 2173 RVA: 0x0003A8B8 File Offset: 0x00038AB8
	[Browsable(true)]
	[Description("Gets or sets if the tab border will paint with enhanced style.")]
	[DefaultValue(false)]
	[Category("Appearance")]
	public bool TabBorderEnhanced
	{
		get
		{
			return this.__TabBorderEnhanced;
		}
		set
		{
			this.__TabBorderEnhanced = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.BorderEnhanced = value;
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
		}
	}

	// Token: 0x170002A8 RID: 680
	// (get) Token: 0x0600087E RID: 2174 RVA: 0x0003A91C File Offset: 0x00038B1C
	// (set) Token: 0x0600087F RID: 2175 RVA: 0x0000593B File Offset: 0x00003B3B
	[Description("Gets or sets the System.Drawing.Color structure that represents the starting color of the __Background linear gradient for the tab close button.")]
	[Browsable(true)]
	[Category("Appearance")]
	public Color TabCloseButtonBackHighColor
	{
		get
		{
			return this.__TabCloseButtonBackHighColor;
		}
		set
		{
			this.__TabCloseButtonBackHighColor = value;
		}
	}

	// Token: 0x06000880 RID: 2176 RVA: 0x00005944 File Offset: 0x00003B44
	public bool ShouldSerializeTabCloseButtonBackHighColor()
	{
		return this.__TabCloseButtonBackHighColor != this.defaultTabCloseButtonBackHighColor;
	}

	// Token: 0x06000881 RID: 2177 RVA: 0x00005957 File Offset: 0x00003B57
	public void ResetTabCloseButtonBackHighColor()
	{
		this.__TabCloseButtonBackHighColor = this.defaultTabCloseButtonBackHighColor;
	}

	// Token: 0x170002A9 RID: 681
	// (get) Token: 0x06000882 RID: 2178 RVA: 0x0003A934 File Offset: 0x00038B34
	// (set) Token: 0x06000883 RID: 2179 RVA: 0x00005965 File Offset: 0x00003B65
	[Browsable(true)]
	[Description("Gets or sets the System.Drawing.Color structure that represents the ending color of the __Background linear gradient for the tab close button.")]
	[Category("Appearance")]
	public Color TabCloseButtonBackLowColor
	{
		get
		{
			return this.__TabCloseButtonBackLowColor;
		}
		set
		{
			this.__TabCloseButtonBackLowColor = value;
		}
	}

	// Token: 0x06000884 RID: 2180 RVA: 0x0000596E File Offset: 0x00003B6E
	public bool ShouldSerializeTabCloseButtonBackLowColor()
	{
		return this.__TabCloseButtonBackLowColor != this.defaultTabCloseButtonBackLowColor;
	}

	// Token: 0x06000885 RID: 2181 RVA: 0x00005981 File Offset: 0x00003B81
	public void ResetTabCloseButtonBackLowColor()
	{
		this.__TabCloseButtonBackLowColor = this.defaultTabCloseButtonBackLowColor;
	}

	// Token: 0x170002AA RID: 682
	// (get) Token: 0x06000886 RID: 2182 RVA: 0x0003A94C File Offset: 0x00038B4C
	// (set) Token: 0x06000887 RID: 2183 RVA: 0x0000598F File Offset: 0x00003B8F
	[Description("Gets or sets the System.Drawing.Color structure that represents the border color for the tab close button.")]
	[Browsable(true)]
	[Category("Appearance")]
	public Color TabCloseButtonBorderColor
	{
		get
		{
			return this.__TabCloseButtonBorderColor;
		}
		set
		{
			this.__TabCloseButtonBorderColor = value;
		}
	}

	// Token: 0x06000888 RID: 2184 RVA: 0x00005998 File Offset: 0x00003B98
	public bool ShouldSerializeTabCloseButtonBorderColor()
	{
		return this.__TabCloseButtonBorderColor != this.defaultTabCloseButtonBorderColor;
	}

	// Token: 0x06000889 RID: 2185 RVA: 0x000059AB File Offset: 0x00003BAB
	public void ResetTabCloseButtonBorderColor()
	{
		this.__TabCloseButtonBorderColor = this.defaultTabCloseButtonBorderColor;
	}

	// Token: 0x170002AB RID: 683
	// (get) Token: 0x0600088A RID: 2186 RVA: 0x0003A964 File Offset: 0x00038B64
	// (set) Token: 0x0600088B RID: 2187 RVA: 0x000059B9 File Offset: 0x00003BB9
	[Browsable(true)]
	[Category("Appearance")]
	[Description("Gets or sets the System.Drawing.Color structure that represents the fore color for the tab close button.")]
	public Color TabCloseButtonForeColor
	{
		get
		{
			return this.__TabCloseButtonForeColor;
		}
		set
		{
			this.__TabCloseButtonForeColor = value;
		}
	}

	// Token: 0x0600088C RID: 2188 RVA: 0x000059C2 File Offset: 0x00003BC2
	public bool ShouldSerializeTabCloseButtonForeColor()
	{
		return this.__TabCloseButtonForeColor != this.defaultTabCloseButtonForeColor;
	}

	// Token: 0x0600088D RID: 2189 RVA: 0x000059D5 File Offset: 0x00003BD5
	public void ResetTabCloseButtonForeColor()
	{
		this.__TabCloseButtonForeColor = this.defaultTabCloseButtonForeColor;
	}

	// Token: 0x170002AC RID: 684
	// (get) Token: 0x0600088E RID: 2190 RVA: 0x0003A97C File Offset: 0x00038B7C
	// (set) Token: 0x0600088F RID: 2191 RVA: 0x000059E3 File Offset: 0x00003BE3
	[Description("Gets or sets the System.Drawing.Color structure that represents the starting color of the __Background linear gradient for the disabled tab close button.")]
	[Category("Appearance")]
	[Browsable(true)]
	public Color TabCloseButtonBackHighColorDisabled
	{
		get
		{
			return this.__TabCloseButtonBackHighColorDisabled;
		}
		set
		{
			this.__TabCloseButtonBackHighColorDisabled = value;
		}
	}

	// Token: 0x06000890 RID: 2192 RVA: 0x000059EC File Offset: 0x00003BEC
	public bool ShouldSerializeTabCloseButtonBackHighColorDisabled()
	{
		return this.__TabCloseButtonBackHighColorDisabled != this.defaultTabCloseButtonBackHighColorDisabled;
	}

	// Token: 0x06000891 RID: 2193 RVA: 0x000059FF File Offset: 0x00003BFF
	public void ResetTabCloseButtonBackHighColorDisabled()
	{
		this.__TabCloseButtonBackHighColorDisabled = this.defaultTabCloseButtonBackHighColorDisabled;
	}

	// Token: 0x170002AD RID: 685
	// (get) Token: 0x06000892 RID: 2194 RVA: 0x0003A994 File Offset: 0x00038B94
	// (set) Token: 0x06000893 RID: 2195 RVA: 0x00005A0D File Offset: 0x00003C0D
	[Description("Gets or sets the System.Drawing.Color structure that represents the ending color of the __Background linear gradient for the disabled tab close button.")]
	[Category("Appearance")]
	[Browsable(true)]
	public Color TabCloseButtonBackLowColorDisabled
	{
		get
		{
			return this.__TabCloseButtonBackLowColorDisabled;
		}
		set
		{
			this.__TabCloseButtonBackLowColorDisabled = value;
		}
	}

	// Token: 0x06000894 RID: 2196 RVA: 0x00005A16 File Offset: 0x00003C16
	public bool ShouldSerializeTabCloseButtonBackLowColorDisabled()
	{
		return this.__TabCloseButtonBackLowColorDisabled != this.defaultTabCloseButtonBackLowColorDisabled;
	}

	// Token: 0x06000895 RID: 2197 RVA: 0x00005A29 File Offset: 0x00003C29
	public void ResetTabCloseButtonBackLowColorDisabled()
	{
		this.__TabCloseButtonBackLowColorDisabled = this.defaultTabCloseButtonBackLowColorDisabled;
	}

	// Token: 0x170002AE RID: 686
	// (get) Token: 0x06000896 RID: 2198 RVA: 0x0003A9AC File Offset: 0x00038BAC
	// (set) Token: 0x06000897 RID: 2199 RVA: 0x00005A37 File Offset: 0x00003C37
	[Description("Gets or sets the System.Drawing.Color structure that represents the border color for the disabled tab close button.")]
	[Category("Appearance")]
	[Browsable(true)]
	public Color TabCloseButtonBorderColorDisabled
	{
		get
		{
			return this.__TabCloseButtonBorderColorDisabled;
		}
		set
		{
			this.__TabCloseButtonBorderColorDisabled = value;
		}
	}

	// Token: 0x06000898 RID: 2200 RVA: 0x00005A40 File Offset: 0x00003C40
	public bool ShouldSerializeTabCloseButtonBorderColorDisabled()
	{
		return this.__TabCloseButtonBorderColorDisabled != this.defaultTabCloseButtonBorderColorDisabled;
	}

	// Token: 0x06000899 RID: 2201 RVA: 0x00005A53 File Offset: 0x00003C53
	public void ResetTabCloseButtonBorderColorDisabled()
	{
		this.__TabCloseButtonBorderColorDisabled = this.defaultTabCloseButtonBorderColorDisabled;
	}

	// Token: 0x170002AF RID: 687
	// (get) Token: 0x0600089A RID: 2202 RVA: 0x0003A9C4 File Offset: 0x00038BC4
	// (set) Token: 0x0600089B RID: 2203 RVA: 0x00005A61 File Offset: 0x00003C61
	[Browsable(true)]
	[Category("Appearance")]
	[Description("Gets or sets the System.Drawing.Color structure that represents the disabled fore color for the tab close button.")]
	public Color TabCloseButtonForeColorDisabled
	{
		get
		{
			return this.__TabCloseButtonForeColorDisabled;
		}
		set
		{
			this.__TabCloseButtonForeColorDisabled = value;
		}
	}

	// Token: 0x0600089C RID: 2204 RVA: 0x00005A6A File Offset: 0x00003C6A
	public bool ShouldSerializeTabCloseButtonForeColorDisabled()
	{
		return this.__TabCloseButtonForeColorDisabled != this.defaultTabCloseButtonForeColorDisabled;
	}

	// Token: 0x0600089D RID: 2205 RVA: 0x00005A7D File Offset: 0x00003C7D
	public void ResetTabCloseButtonForeColorDisabled()
	{
		this.__TabCloseButtonForeColorDisabled = this.defaultTabCloseButtonForeColorDisabled;
	}

	// Token: 0x170002B0 RID: 688
	// (get) Token: 0x0600089E RID: 2206 RVA: 0x0003A9DC File Offset: 0x00038BDC
	// (set) Token: 0x0600089F RID: 2207 RVA: 0x00005A8B File Offset: 0x00003C8B
	[Category("Appearance")]
	[Description("Gets or sets the System.Drawing.Color structure that represents the starting color of the __Background linear gradient for the Hot tab close button.")]
	[Browsable(true)]
	public Color TabCloseButtonBackHighColorHot
	{
		get
		{
			return this.__TabCloseButtonBackHighColorHot;
		}
		set
		{
			this.__TabCloseButtonBackHighColorHot = value;
		}
	}

	// Token: 0x060008A0 RID: 2208 RVA: 0x00005A94 File Offset: 0x00003C94
	public bool ShouldSerializeTabCloseButtonBackHighColorHot()
	{
		return this.__TabCloseButtonBackHighColorHot != this.defaultTabCloseButtonBackHighColorHot;
	}

	// Token: 0x060008A1 RID: 2209 RVA: 0x00005AA7 File Offset: 0x00003CA7
	public void ResetTabCloseButtonBackHighColorHot()
	{
		this.__TabCloseButtonBackHighColorHot = this.defaultTabCloseButtonBackHighColorHot;
	}

	// Token: 0x170002B1 RID: 689
	// (get) Token: 0x060008A2 RID: 2210 RVA: 0x0003A9F4 File Offset: 0x00038BF4
	// (set) Token: 0x060008A3 RID: 2211 RVA: 0x00005AB5 File Offset: 0x00003CB5
	[Browsable(true)]
	[Category("Appearance")]
	[Description("Gets or sets the System.Drawing.Color structure that represents the ending color of the __Background linear gradient for the Hot tab close button.")]
	public Color TabCloseButtonBackLowColorHot
	{
		get
		{
			return this.__TabCloseButtonBackLowColorHot;
		}
		set
		{
			this.__TabCloseButtonBackLowColorHot = value;
		}
	}

	// Token: 0x060008A4 RID: 2212 RVA: 0x00005ABE File Offset: 0x00003CBE
	public bool ShouldSerializeTabCloseButtonBackLowColorHot()
	{
		return this.__TabCloseButtonBackLowColorHot != this.defaultTabCloseButtonBackLowColorHot;
	}

	// Token: 0x060008A5 RID: 2213 RVA: 0x00005AD1 File Offset: 0x00003CD1
	public void ResetTabCloseButtonBackLowColorHot()
	{
		this.__TabCloseButtonBackLowColorHot = this.defaultTabCloseButtonBackLowColorHot;
	}

	// Token: 0x170002B2 RID: 690
	// (get) Token: 0x060008A6 RID: 2214 RVA: 0x0003AA0C File Offset: 0x00038C0C
	// (set) Token: 0x060008A7 RID: 2215 RVA: 0x00005ADF File Offset: 0x00003CDF
	[Description("Gets or sets the System.Drawing.Color structure that represents the border color for the Hot tab close button.")]
	[Browsable(true)]
	[Category("Appearance")]
	public Color TabCloseButtonBorderColorHot
	{
		get
		{
			return this.__TabCloseButtonBorderColorHot;
		}
		set
		{
			this.__TabCloseButtonBorderColorHot = value;
		}
	}

	// Token: 0x060008A8 RID: 2216 RVA: 0x00005AE8 File Offset: 0x00003CE8
	public bool ShouldSerializeTabCloseButtonBorderColorHot()
	{
		return this.__TabCloseButtonBorderColorHot != this.defaultTabCloseButtonBorderColorHot;
	}

	// Token: 0x060008A9 RID: 2217 RVA: 0x00005AFB File Offset: 0x00003CFB
	public void ResetTabCloseButtonBorderColorHot()
	{
		this.__TabCloseButtonBorderColorHot = this.defaultTabCloseButtonBorderColorHot;
	}

	// Token: 0x170002B3 RID: 691
	// (get) Token: 0x060008AA RID: 2218 RVA: 0x0003AA24 File Offset: 0x00038C24
	// (set) Token: 0x060008AB RID: 2219 RVA: 0x00005B09 File Offset: 0x00003D09
	[Browsable(true)]
	[Category("Appearance")]
	[Description("Gets or sets the System.Drawing.Color structure that represents the Hot fore color for the tab close button.")]
	public Color TabCloseButtonForeColorHot
	{
		get
		{
			return this.__TabCloseButtonForeColorHot;
		}
		set
		{
			this.__TabCloseButtonForeColorHot = value;
		}
	}

	// Token: 0x060008AC RID: 2220 RVA: 0x00005B12 File Offset: 0x00003D12
	public bool ShouldSerializeTabCloseButtonForeColorHot()
	{
		return this.__TabCloseButtonForeColorHot != this.defaultTabCloseButtonForeColorHot;
	}

	// Token: 0x060008AD RID: 2221 RVA: 0x00005B25 File Offset: 0x00003D25
	public void ResetTabCloseButtonForeColorHot()
	{
		this.__TabCloseButtonForeColorHot = this.defaultTabCloseButtonForeColorHot;
	}

	// Token: 0x170002B4 RID: 692
	// (get) Token: 0x060008AE RID: 2222 RVA: 0x0003AA3C File Offset: 0x00038C3C
	// (set) Token: 0x060008AF RID: 2223 RVA: 0x0003AA54 File Offset: 0x00038C54
	[Browsable(true)]
	[Description("Gets or sets the tab close button image.")]
	[Category("Appearance")]
	public Image TabCloseButtonImage
	{
		get
		{
			return this.__TabCloseButtonImage;
		}
		set
		{
			this.__TabCloseButtonImage = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.CloseButtonImage = value;
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
		}
	}

	// Token: 0x170002B5 RID: 693
	// (get) Token: 0x060008B0 RID: 2224 RVA: 0x0003AAB8 File Offset: 0x00038CB8
	// (set) Token: 0x060008B1 RID: 2225 RVA: 0x0003AAD0 File Offset: 0x00038CD0
	[Description("Gets or sets the tab close button image in hot state.")]
	[Category("Appearance")]
	[Browsable(true)]
	public Image TabCloseButtonImageHot
	{
		get
		{
			return this.__TabCloseButtonImageHot;
		}
		set
		{
			this.__TabCloseButtonImageHot = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.CloseButtonImageHot = value;
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
		}
	}

	// Token: 0x170002B6 RID: 694
	// (get) Token: 0x060008B2 RID: 2226 RVA: 0x0003AB34 File Offset: 0x00038D34
	// (set) Token: 0x060008B3 RID: 2227 RVA: 0x0003AB4C File Offset: 0x00038D4C
	[Browsable(true)]
	[Category("Appearance")]
	[Description("Gets or sets the tab close button image in disabled state.")]
	public Image TabCloseButtonImageDisabled
	{
		get
		{
			return this.__TabCloseButtonImageDisabled;
		}
		set
		{
			this.__TabCloseButtonImageDisabled = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.CloseButtonImageDisabled = value;
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
		}
	}

	// Token: 0x170002B7 RID: 695
	// (get) Token: 0x060008B4 RID: 2228 RVA: 0x00005B33 File Offset: 0x00003D33
	// (set) Token: 0x060008B5 RID: 2229 RVA: 0x0003ABB0 File Offset: 0x00038DB0
	[Description("Gets or sets whether the tab close button is visble or not.")]
	[DefaultValue(true)]
	[Category("Layout")]
	[Browsable(true)]
	public bool TabCloseButtonVisible
	{
		get
		{
			return this.__TabCloseButtonVisible;
		}
		set
		{
			this.__TabCloseButtonVisible = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.CloseButtonVisible = value;
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
		}
	}

	// Token: 0x170002B8 RID: 696
	// (get) Token: 0x060008B6 RID: 2230 RVA: 0x0003AC14 File Offset: 0x00038E14
	// (set) Token: 0x060008B7 RID: 2231 RVA: 0x0003AC2C File Offset: 0x00038E2C
	[Category("Appearance")]
	[Description("Gets or sets the size of the icon displayed at the tab.")]
	[Browsable(true)]
	public Size TabIconSize
	{
		get
		{
			return this.__TabIconSize;
		}
		set
		{
			this.__TabIconSize = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.IconSize = value;
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
		}
	}

	// Token: 0x060008B8 RID: 2232 RVA: 0x00005B3B File Offset: 0x00003D3B
	public bool ShouldSerializeTabIconSize()
	{
		return this.__TabIconSize != this.defaultTabIconSize;
	}

	// Token: 0x060008B9 RID: 2233 RVA: 0x00005B4E File Offset: 0x00003D4E
	public void ResetTabIconSize()
	{
		this.__TabIconSize = this.defaultTabIconSize;
	}

	// Token: 0x170002B9 RID: 697
	// (get) Token: 0x060008BA RID: 2234 RVA: 0x0003AC90 File Offset: 0x00038E90
	// (set) Token: 0x060008BB RID: 2235 RVA: 0x0003ACA8 File Offset: 0x00038EA8
	[Category("Appearance")]
	[Description("Gets or sets the size of the close button displayed at the tab.")]
	[Browsable(true)]
	public Size TabCloseButtonSize
	{
		get
		{
			return this.__TabCloseButtonSize;
		}
		set
		{
			this.__TabCloseButtonSize = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.CloseButtonSize = value;
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
		}
	}

	// Token: 0x060008BC RID: 2236 RVA: 0x00005B5C File Offset: 0x00003D5C
	public bool ShouldSerializeTabCloseButtonSize()
	{
		return this.__TabCloseButtonSize != this.defaultTabCloseButtonSize;
	}

	// Token: 0x060008BD RID: 2237 RVA: 0x00005B6F File Offset: 0x00003D6F
	public void ResetTabCloseButtonSize()
	{
		this.__TabCloseButtonSize = this.defaultTabCloseButtonSize;
	}

	// Token: 0x170002BA RID: 698
	// (get) Token: 0x060008BE RID: 2238 RVA: 0x0003AD0C File Offset: 0x00038F0C
	// (set) Token: 0x060008BF RID: 2239 RVA: 0x0003AD28 File Offset: 0x00038F28
	[Category("Appearance")]
	[DefaultValue(3)]
	[Description("Specifies whether smoothing (antialiasing) is applied to lines and curves and the edges of filled areas.")]
	[Browsable(true)]
	public SmoothingMode SmoothingMode
	{
		get
		{
			return (SmoothingMode)Conversions.ToInteger(this.__TabSmoothingMode);
		}
		set
		{
			this.__TabSmoothingMode = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.SmoothingMode = value;
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
		}
	}

	// Token: 0x170002BB RID: 699
	// (get) Token: 0x060008C0 RID: 2240 RVA: 0x0003AD90 File Offset: 0x00038F90
	// (set) Token: 0x060008C1 RID: 2241 RVA: 0x0003ADA8 File Offset: 0x00038FA8
	[Category("Layout")]
	[DefaultValue(5)]
	[Browsable(true)]
	[Description("Gets or sets the amount of space on the right side of the tab.")]
	public int TabPadRight
	{
		get
		{
			return this.__TabPadRight;
		}
		set
		{
			this.__TabPadRight = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.PadRight = value;
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
		}
	}

	// Token: 0x170002BC RID: 700
	// (get) Token: 0x060008C2 RID: 2242 RVA: 0x0003AE0C File Offset: 0x0003900C
	// (set) Token: 0x060008C3 RID: 2243 RVA: 0x0003AE24 File Offset: 0x00039024
	[DefaultValue(5)]
	[Category("Layout")]
	[Browsable(true)]
	[Description("Gets or sets the amount of space on the left side of the tab.")]
	public int TabPadLeft
	{
		get
		{
			return this.__TabPadLeft;
		}
		set
		{
			this.__TabPadLeft = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.PadLeft = value;
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
		}
	}

	// Token: 0x170002BD RID: 701
	// (get) Token: 0x060008C4 RID: 2244 RVA: 0x0003AE88 File Offset: 0x00039088
	// (set) Token: 0x060008C5 RID: 2245 RVA: 0x00005B7D File Offset: 0x00003D7D
	[Browsable(true)]
	[Description("Gets or sets the amount of space between the tabs.")]
	[DefaultValue(3)]
	[Category("Layout")]
	public int TabOffset
	{
		get
		{
			return this.__TabOffset;
		}
		set
		{
			this.__TabOffset = value;
			this.Arrange__Items();
		}
	}

	// Token: 0x170002BE RID: 702
	// (get) Token: 0x060008C6 RID: 2246 RVA: 0x0003AEA0 File Offset: 0x000390A0
	// (set) Token: 0x060008C7 RID: 2247 RVA: 0x0003AEB8 File Offset: 0x000390B8
	[Category("Layout")]
	[DefaultValue(28)]
	[Description("Gets or sets the height of the tab.")]
	[Browsable(true)]
	public int TabHeight
	{
		get
		{
			return this.__TabHeight;
		}
		set
		{
			if (this.__TabHeight != value)
			{
				this.__TabHeight = value;
				this.pnlTabs.Height = this.__TabHeight;
				this.pnlTabs.Top = checked(this.pnlTop.Height - this.pnlTabs.Height);
				this.AdjustHeight();
				try
				{
					foreach (object obj in this.TabPages)
					{
						TabPageExt tabPageExt = (TabPageExt)obj;
						tabPageExt.Height = value;
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
			}
		}
	}

	// Token: 0x170002BF RID: 703
	// (get) Token: 0x060008C8 RID: 2248 RVA: 0x0003AF64 File Offset: 0x00039164
	// (set) Token: 0x060008C9 RID: 2249 RVA: 0x00005B8C File Offset: 0x00003D8C
	[Description("Gets or sets the distance between the top of the control and the top of the tab.")]
	[Browsable(true)]
	[Category("Layout")]
	[DefaultValue(3)]
	public int TabTop
	{
		get
		{
			return this.__TabTop;
		}
		set
		{
			this.__TabTop = value;
			this.AdjustHeight();
		}
	}

	// Token: 0x170002C0 RID: 704
	// (get) Token: 0x060008CA RID: 2250 RVA: 0x0003AF7C File Offset: 0x0003917C
	// (set) Token: 0x060008CB RID: 2251 RVA: 0x0003AF94 File Offset: 0x00039194
	[Browsable(true)]
	[Category("Appearance")]
	[Description("Gets or sets the System.Drawing.Color structure that represents the starting color of the __Background linear gradient.")]
	public Color TabBackHighColor
	{
		get
		{
			return this.__TabBackHighColor;
		}
		set
		{
			this.__TabBackHighColor = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.BackHighColor = value;
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
		}
	}

	// Token: 0x060008CC RID: 2252 RVA: 0x00005B9B File Offset: 0x00003D9B
	public bool ShouldSerializeTabBackHighColor()
	{
		return this.__TabBackHighColor != this.defaultTabBackHighColor;
	}

	// Token: 0x060008CD RID: 2253 RVA: 0x00005BAE File Offset: 0x00003DAE
	public void ResetTabBackHighColor()
	{
		this.__TabBackHighColor = this.defaultTabBackHighColor;
	}

	// Token: 0x170002C1 RID: 705
	// (get) Token: 0x060008CE RID: 2254 RVA: 0x0003AFF8 File Offset: 0x000391F8
	// (set) Token: 0x060008CF RID: 2255 RVA: 0x0003B010 File Offset: 0x00039210
	[Browsable(true)]
	[Category("Appearance")]
	[Description("Gets or sets the System.Drawing.Color structure that represents the ending color of the __Background linear gradient.")]
	public Color TabBackLowColor
	{
		get
		{
			return this.__TabBackLowColor;
		}
		set
		{
			this.__TabBackLowColor = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.BackLowColor = value;
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
		}
	}

	// Token: 0x060008D0 RID: 2256 RVA: 0x00005BBC File Offset: 0x00003DBC
	public bool ShouldSerializeTabBackLowColor()
	{
		return this.__TabBackLowColor != this.defaultTabBackLowColor;
	}

	// Token: 0x060008D1 RID: 2257 RVA: 0x00005BCF File Offset: 0x00003DCF
	public void ResetTabBackLowColor()
	{
		this.__TabBackLowColor = this.defaultTabBackLowColor;
	}

	// Token: 0x170002C2 RID: 706
	// (get) Token: 0x060008D2 RID: 2258 RVA: 0x0003B074 File Offset: 0x00039274
	// (set) Token: 0x060008D3 RID: 2259 RVA: 0x0003B08C File Offset: 0x0003928C
	[Browsable(true)]
	[Category("Appearance")]
	[Description("Gets or sets the System.Drawing.Color structure that represents the starting color of the __Background linear gradient for a non selected tab.")]
	public Color TabBackHighColorDisabled
	{
		get
		{
			return this.__TabBackHighColorDisabled;
		}
		set
		{
			this.__TabBackHighColorDisabled = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.BackHighColorDisabled = value;
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
		}
	}

	// Token: 0x060008D4 RID: 2260 RVA: 0x00005BDD File Offset: 0x00003DDD
	public bool ShouldSerializeTabBackHighColorDisabled()
	{
		return this.__TabBackHighColorDisabled != this.defaultTabBackHighColorDisabled;
	}

	// Token: 0x060008D5 RID: 2261 RVA: 0x00005BF0 File Offset: 0x00003DF0
	public void ResetTabBackHighColorDisabled()
	{
		this.__TabBackHighColorDisabled = this.defaultTabBackHighColorDisabled;
	}

	// Token: 0x170002C3 RID: 707
	// (get) Token: 0x060008D6 RID: 2262 RVA: 0x0003B0F0 File Offset: 0x000392F0
	// (set) Token: 0x060008D7 RID: 2263 RVA: 0x0003B108 File Offset: 0x00039308
	[Category("Appearance")]
	[Browsable(true)]
	[Description("Gets or sets the System.Drawing.Color structure that represents the ending color of the __Background linear gradient for a non selected tab.")]
	public Color TabBackLowColorDisabled
	{
		get
		{
			return this.__TabBackLowColorDisabled;
		}
		set
		{
			this.__TabBackLowColorDisabled = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.BackLowColorDisabled = value;
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
		}
	}

	// Token: 0x060008D8 RID: 2264 RVA: 0x00005BFE File Offset: 0x00003DFE
	public bool ShouldSerializeTabBackLowColorDisabled()
	{
		return this.__TabBackLowColorDisabled != this.defaultTabBackLowColorDisabled;
	}

	// Token: 0x060008D9 RID: 2265 RVA: 0x00005C11 File Offset: 0x00003E11
	public void ResetTabBackLowColorDisabled()
	{
		this.__TabBackLowColorDisabled = this.defaultTabBackLowColorDisabled;
	}

	// Token: 0x170002C4 RID: 708
	// (get) Token: 0x060008DA RID: 2266 RVA: 0x0003B16C File Offset: 0x0003936C
	// (set) Token: 0x060008DB RID: 2267 RVA: 0x0003B184 File Offset: 0x00039384
	[Browsable(true)]
	[Category("Appearance")]
	[Description("Gets or sets the System.Drawing.Color structure that represents the border color of the tab when not selected.")]
	public Color BorderColorDisabled
	{
		get
		{
			return this.__BorderColorDisabled;
		}
		set
		{
			this.__BorderColorDisabled = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.BorderColorDisabled = value;
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
		}
	}

	// Token: 0x060008DC RID: 2268 RVA: 0x00005C1F File Offset: 0x00003E1F
	public bool ShouldSerializeBorderColorDisabled()
	{
		return this.__BorderColorDisabled != this.defaultBorderColorDisabled;
	}

	// Token: 0x060008DD RID: 2269 RVA: 0x00005C32 File Offset: 0x00003E32
	public void ResetBorderColorDisabled()
	{
		this.__BorderColorDisabled = this.defaultBorderColorDisabled;
	}

	// Token: 0x170002C5 RID: 709
	// (get) Token: 0x060008DE RID: 2270 RVA: 0x0003B1E8 File Offset: 0x000393E8
	// (set) Token: 0x060008DF RID: 2271 RVA: 0x0003B200 File Offset: 0x00039400
	[Category("Appearance")]
	[Browsable(true)]
	[Description("Gets or sets the System.Drawing.Color structure that represents the fore color of the tab when not selected.")]
	public Color ForeColorDisabled
	{
		get
		{
			return this.__ForeColorDisabled;
		}
		set
		{
			this.__ForeColorDisabled = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.ForeColorDisabled = value;
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
		}
	}

	// Token: 0x060008E0 RID: 2272 RVA: 0x00005C40 File Offset: 0x00003E40
	public bool ShouldSerializeForeColorDisabled()
	{
		return this.__ForeColorDisabled != this.defaultForeColorDisabled;
	}

	// Token: 0x060008E1 RID: 2273 RVA: 0x00005C53 File Offset: 0x00003E53
	public void ResetForeColorDisabled()
	{
		this.__ForeColorDisabled = this.defaultForeColorDisabled;
	}

	// Token: 0x170002C6 RID: 710
	// (get) Token: 0x060008E2 RID: 2274 RVA: 0x0003B264 File Offset: 0x00039464
	// (set) Token: 0x060008E3 RID: 2275 RVA: 0x0003B27C File Offset: 0x0003947C
	[Description("Gets or sets the minimum width for the tab.")]
	[Browsable(true)]
	[DefaultValue(100)]
	[Category("Layout")]
	public int TabMinimumWidth
	{
		get
		{
			return this.__TabMinimumWidth;
		}
		set
		{
			this.__TabMinimumWidth = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.MinimumWidth = value;
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
		}
	}

	// Token: 0x170002C7 RID: 711
	// (get) Token: 0x060008E4 RID: 2276 RVA: 0x0003B2E0 File Offset: 0x000394E0
	// (set) Token: 0x060008E5 RID: 2277 RVA: 0x0003B2F8 File Offset: 0x000394F8
	[DefaultValue(200)]
	[Description("Gets or sets the maximum width for the tab.")]
	[Browsable(true)]
	[Category("Layout")]
	public int TabMaximumWidth
	{
		get
		{
			return this.__TabMaximumWidth;
		}
		set
		{
			this.__TabMaximumWidth = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.MaximumWidth = value;
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
		}
	}

	// Token: 0x170002C8 RID: 712
	// (get) Token: 0x060008E6 RID: 2278 RVA: 0x00005C61 File Offset: 0x00003E61
	// (set) Token: 0x060008E7 RID: 2279 RVA: 0x0003B35C File Offset: 0x0003955C
	[Description("Gets or sets whether the font on the selected tab is displayed in bold.")]
	[Browsable(true)]
	[DefaultValue(true)]
	[Category("Appearance")]
	public bool FontBoldOnSelect
	{
		get
		{
			return this.__FontBoldOnSelect;
		}
		set
		{
			this.__FontBoldOnSelect = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.FontBoldOnSelect = value;
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
		}
	}

	// Token: 0x170002C9 RID: 713
	// (get) Token: 0x060008E8 RID: 2280 RVA: 0x00005C69 File Offset: 0x00003E69
	// (set) Token: 0x060008E9 RID: 2281 RVA: 0x0003B3C0 File Offset: 0x000395C0
	[Browsable(true)]
	[Category("Behavior")]
	[DefaultValue(true)]
	[Description("Gets or sets a value indicating whether the control's tabs change in appearance when the mouse passes over them.")]
	public bool HotTrack
	{
		get
		{
			return this.__HotTrack;
		}
		set
		{
			this.__HotTrack = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.HotTrack = value;
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
		}
	}

	// Token: 0x170002CA RID: 714
	// (get) Token: 0x060008EA RID: 2282 RVA: 0x00005C71 File Offset: 0x00003E71
	// (set) Token: 0x060008EB RID: 2283 RVA: 0x00005C79 File Offset: 0x00003E79
	[DefaultValue(true)]
	[Description("Gets or sets a value indicating whether the user can reorder tabs draging.")]
	[Browsable(true)]
	[Category("Behavior")]
	public bool AllowTabReorder
	{
		get
		{
			return this.__AllowTabReorder;
		}
		set
		{
			this.__AllowTabReorder = value;
		}
	}

	// Token: 0x170002CB RID: 715
	// (get) Token: 0x060008EC RID: 2284 RVA: 0x00005C82 File Offset: 0x00003E82
	// (set) Token: 0x060008ED RID: 2285 RVA: 0x00005C8F File Offset: 0x00003E8F
	[DefaultValue(false)]
	[Browsable(true)]
	[Description("Gets or sets a value indicating whether the close button is displayed or not.")]
	[Category("Layout")]
	public bool CloseButtonVisible
	{
		get
		{
			return this.CloseButton.Visible;
		}
		set
		{
			if (this.CloseButton.Visible != value)
			{
				this.CloseButton.Visible = value;
				this.SetControlsSizeLocation();
			}
		}
	}

	// Token: 0x170002CC RID: 716
	// (get) Token: 0x060008EE RID: 2286 RVA: 0x00005CB6 File Offset: 0x00003EB6
	// (set) Token: 0x060008EF RID: 2287 RVA: 0x00005CC3 File Offset: 0x00003EC3
	[Browsable(true)]
	[Description("Gets or sets a value indicating whether the drop button is displayed or not.")]
	[DefaultValue(true)]
	[Category("Layout")]
	public bool DropButtonVisible
	{
		get
		{
			return this.DropButton.Visible;
		}
		set
		{
			if (this.DropButton.Visible != value)
			{
				this.DropButton.Visible = value;
				this.SetControlsSizeLocation();
			}
		}
	}

	// Token: 0x170002CD RID: 717
	// (get) Token: 0x060008F0 RID: 2288 RVA: 0x00005CEA File Offset: 0x00003EEA
	// (set) Token: 0x060008F1 RID: 2289 RVA: 0x00005CF2 File Offset: 0x00003EF2
	[Description("Gets or sets a value indicating whether a double line separator is displayed at the top of the control.")]
	[Browsable(true)]
	[DefaultValue(true)]
	[Category("Appearance")]
	public bool TopSeparator
	{
		get
		{
			return this.__TopSeparator;
		}
		set
		{
			this.__TopSeparator = value;
			this.AdjustHeight();
		}
	}

	// Token: 0x170002CE RID: 718
	// (get) Token: 0x060008F2 RID: 2290 RVA: 0x0003B424 File Offset: 0x00039624
	// (set) Token: 0x060008F3 RID: 2291 RVA: 0x0003B43C File Offset: 0x0003963C
	[DefaultValue(0)]
	[Description("Gets or sets the area of the control (for example, along the top) where the tabs are aligned.")]
	[Browsable(true)]
	[Category("Behavior")]
	public TabControlExt.TabAlignment Alignment
	{
		get
		{
			return this.__Alignment;
		}
		set
		{
			this.__Alignment = value;
			this.AdjustHeight();
			this.PositionButtons();
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.Alignment = value;
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
		}
	}

	// Token: 0x170002CF RID: 719
	// (get) Token: 0x060008F4 RID: 2292 RVA: 0x0003B4AC File Offset: 0x000396AC
	// (set) Token: 0x060008F5 RID: 2293 RVA: 0x00005D01 File Offset: 0x00003F01
	[Browsable(true)]
	[Description("Gets or sets the amount of space around the form on the control's tab pages.")]
	[Category("Layout")]
	public new Padding Padding
	{
		get
		{
			return this.pnlBottom.Padding;
		}
		set
		{
			this.pnlBottom.Padding = value;
		}
	}

	// Token: 0x060008F6 RID: 2294 RVA: 0x00005D0F File Offset: 0x00003F0F
	public bool ShouldSerializePadding()
	{
		return this.pnlBottom.Padding != this.defaultPadding;
	}

	// Token: 0x060008F7 RID: 2295 RVA: 0x00005D27 File Offset: 0x00003F27
	public void ResetPadding()
	{
		this.pnlBottom.Padding = this.defaultPadding;
	}

	// Token: 0x170002D0 RID: 720
	// (get) Token: 0x060008F8 RID: 2296 RVA: 0x0003B4C8 File Offset: 0x000396C8
	// (set) Token: 0x060008F9 RID: 2297 RVA: 0x00005D3A File Offset: 0x00003F3A
	[Browsable(true)]
	[Category("Appearance")]
	[Description("Gets or sets the System.Drawing.Color structure that represents the starting color of the __Background linear gradient for the control button.")]
	public Color ControlButtonBackHighColor
	{
		get
		{
			return this.DropButton.BackHighColor;
		}
		set
		{
			this.DropButton.BackHighColor = value;
			this.CloseButton.BackHighColor = value;
		}
	}

	// Token: 0x060008FA RID: 2298 RVA: 0x00005D54 File Offset: 0x00003F54
	public bool ShouldSerializeControlButtonBackHighColor()
	{
		return this.DropButton.BackHighColor != this.defaultControlButtonBackHighColor;
	}

	// Token: 0x060008FB RID: 2299 RVA: 0x00005D6C File Offset: 0x00003F6C
	public void ResetControlButtonBackHighColor()
	{
		this.DropButton.BackHighColor = this.defaultControlButtonBackHighColor;
		this.CloseButton.BackHighColor = this.defaultControlButtonBackHighColor;
	}

	// Token: 0x170002D1 RID: 721
	// (get) Token: 0x060008FC RID: 2300 RVA: 0x0003B4E4 File Offset: 0x000396E4
	// (set) Token: 0x060008FD RID: 2301 RVA: 0x00005D90 File Offset: 0x00003F90
	[Browsable(true)]
	[Description("Gets or sets the System.Drawing.Color structure that represents the ending color of the __Background linear gradient for the control button.")]
	[Category("Appearance")]
	public Color ControlButtonBackLowColor
	{
		get
		{
			return this.DropButton.BackLowColor;
		}
		set
		{
			this.DropButton.BackLowColor = value;
			this.CloseButton.BackLowColor = value;
		}
	}

	// Token: 0x060008FE RID: 2302 RVA: 0x00005DAA File Offset: 0x00003FAA
	public bool ShouldSerializeControlButtonBackLowColor()
	{
		return this.DropButton.BackLowColor != this.defaultControlButtonBackLowColor;
	}

	// Token: 0x060008FF RID: 2303 RVA: 0x00005DC2 File Offset: 0x00003FC2
	public void ResetControlButtonBackLowColor()
	{
		this.DropButton.BackLowColor = this.defaultControlButtonBackLowColor;
		this.CloseButton.BackLowColor = this.defaultControlButtonBackLowColor;
	}

	// Token: 0x170002D2 RID: 722
	// (get) Token: 0x06000900 RID: 2304 RVA: 0x0003B500 File Offset: 0x00039700
	// (set) Token: 0x06000901 RID: 2305 RVA: 0x00005DE6 File Offset: 0x00003FE6
	[Category("Appearance")]
	[Description("Gets or sets the System.Drawing.Color structure that represents the border color for the control button.")]
	[Browsable(true)]
	public Color ControlButtonBorderColor
	{
		get
		{
			return this.DropButton.BorderColor;
		}
		set
		{
			this.DropButton.BorderColor = value;
			this.CloseButton.BorderColor = value;
		}
	}

	// Token: 0x06000902 RID: 2306 RVA: 0x00005E00 File Offset: 0x00004000
	public bool ShouldSerializeControlButtonBorderColor()
	{
		return this.DropButton.BorderColor != this.defaultControlButtonBorderColor;
	}

	// Token: 0x06000903 RID: 2307 RVA: 0x00005E18 File Offset: 0x00004018
	public void ResetControlButtonBorderColor()
	{
		this.DropButton.BorderColor = this.defaultControlButtonBorderColor;
		this.CloseButton.BorderColor = this.defaultControlButtonBorderColor;
	}

	// Token: 0x170002D3 RID: 723
	// (get) Token: 0x06000904 RID: 2308 RVA: 0x0003B51C File Offset: 0x0003971C
	// (set) Token: 0x06000905 RID: 2309 RVA: 0x00005E3C File Offset: 0x0000403C
	[Category("Appearance")]
	[Browsable(true)]
	[Description("Gets or sets the System.Drawing.Color structure that represents the ForeColor for the control button.")]
	public Color ControlButtonForeColor
	{
		get
		{
			return this.DropButton.ForeColor;
		}
		set
		{
			this.DropButton.ForeColor = value;
			this.CloseButton.ForeColor = value;
		}
	}

	// Token: 0x06000906 RID: 2310 RVA: 0x00005E56 File Offset: 0x00004056
	public bool ShouldSerializeControlButtonForeColor()
	{
		return this.DropButton.ForeColor != this.defaultControlButtonForeColor;
	}

	// Token: 0x06000907 RID: 2311 RVA: 0x00005E6E File Offset: 0x0000406E
	public void ResetControlButtonForeColor()
	{
		this.DropButton.ForeColor = this.defaultControlButtonForeColor;
		this.CloseButton.ForeColor = this.defaultControlButtonForeColor;
	}

	// Token: 0x170002D4 RID: 724
	// (get) Token: 0x06000908 RID: 2312 RVA: 0x0003B538 File Offset: 0x00039738
	// (set) Token: 0x06000909 RID: 2313 RVA: 0x00005E92 File Offset: 0x00004092
	[Category("Appearance")]
	[Description("Gets or sets the System.Drawing.Color structure that represents the ending color of the __Background linear gradient for the tabs region.")]
	[Browsable(true)]
	public Color BackLowColor
	{
		get
		{
			return this.__BackLowColor;
		}
		set
		{
			this.__BackLowColor = value;
			base.Invalidate();
		}
	}

	// Token: 0x0600090A RID: 2314 RVA: 0x00005EA1 File Offset: 0x000040A1
	public bool ShouldSerializeBackLowColor()
	{
		return this.__BackLowColor != this.defaultBackLowColor;
	}

	// Token: 0x0600090B RID: 2315 RVA: 0x00005EB4 File Offset: 0x000040B4
	public void ResetBackLowColor()
	{
		this.__BackLowColor = this.defaultBackLowColor;
	}

	// Token: 0x170002D5 RID: 725
	// (get) Token: 0x0600090C RID: 2316 RVA: 0x0003B550 File Offset: 0x00039750
	// (set) Token: 0x0600090D RID: 2317 RVA: 0x00005EC2 File Offset: 0x000040C2
	[Browsable(true)]
	[Description("Gets or sets the System.Drawing.Color structure that represents the starting color of the __Background linear gradient for the tabs region.")]
	[Category("Appearance")]
	public Color BackHighColor
	{
		get
		{
			return this.__BackHighColor;
		}
		set
		{
			this.__BackHighColor = value;
			base.Invalidate();
		}
	}

	// Token: 0x0600090E RID: 2318 RVA: 0x00005ED1 File Offset: 0x000040D1
	public bool ShouldSerializeBackHighColor()
	{
		return this.__BackHighColor != this.defaultBackHighColor;
	}

	// Token: 0x0600090F RID: 2319 RVA: 0x00005EE4 File Offset: 0x000040E4
	public void ResetBackHighColor()
	{
		this.__BackHighColor = this.defaultBackHighColor;
	}

	// Token: 0x170002D6 RID: 726
	// (get) Token: 0x06000910 RID: 2320 RVA: 0x0003B568 File Offset: 0x00039768
	// (set) Token: 0x06000911 RID: 2321 RVA: 0x0003B580 File Offset: 0x00039780
	[Browsable(true)]
	[Category("Appearance")]
	[Description("Gets or sets the System.Drawing.Color structure that represents the border color.")]
	public Color BorderColor
	{
		get
		{
			return this.__BorderColor;
		}
		set
		{
			this.__BorderColor = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.BorderColor = value;
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
			this.pnlTabs.Invalidate();
			this.pnlTop.Invalidate();
		}
	}

	// Token: 0x06000912 RID: 2322 RVA: 0x00005EF2 File Offset: 0x000040F2
	public bool ShouldSerializeBorderColor()
	{
		return this.__BorderColor != this.defaultBorderColor;
	}

	// Token: 0x06000913 RID: 2323 RVA: 0x00005F05 File Offset: 0x00004105
	public void ResetBorderColor()
	{
		this.__BorderColor = this.defaultBorderColor;
	}

	// Token: 0x170002D7 RID: 727
	// (get) Token: 0x06000914 RID: 2324 RVA: 0x0003B5FC File Offset: 0x000397FC
	[Description("Gets the collection of tab pages in this tab control.")]
	[Browsable(false)]
	public TabControlExt.__TabPageCollection TabPages
	{
		get
		{
			return this.__Items;
		}
	}

	// Token: 0x170002D8 RID: 728
	// (get) Token: 0x06000915 RID: 2325 RVA: 0x0003B614 File Offset: 0x00039814
	// (set) Token: 0x06000916 RID: 2326 RVA: 0x0003B62C File Offset: 0x0003982C
	[Category("Appearance")]
	[Description("The painting style applied to the control.")]
	[Browsable(true)]
	public ToolStripRenderMode RenderMode
	{
		get
		{
			return this.__RenderMode;
		}
		set
		{
			this.__RenderMode = value;
			this.DropButton.RenderMode = value;
			this.CloseButton.RenderMode = value;
			this.WinMenu.RenderMode = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.RenderMode = value;
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
		}
	}

	// Token: 0x170002D9 RID: 729
	// (get) Token: 0x06000917 RID: 2327 RVA: 0x0003B6B4 File Offset: 0x000398B4
	// (set) Token: 0x06000918 RID: 2328 RVA: 0x00005F13 File Offset: 0x00004113
	[Browsable(false)]
	public ToolStripRenderer MenuRenderer
	{
		get
		{
			return this.__ContextMenuRenderer;
		}
		set
		{
			this.__ContextMenuRenderer = value;
			this.WinMenu.Renderer = this.__ContextMenuRenderer;
		}
	}

	// Token: 0x170002DA RID: 730
	// (get) Token: 0x06000919 RID: 2329 RVA: 0x0003B6CC File Offset: 0x000398CC
	// (set) Token: 0x0600091A RID: 2330 RVA: 0x0003B6E4 File Offset: 0x000398E4
	[Category("Appearance")]
	[Browsable(true)]
	[Description("The weight of the border.")]
	[DefaultValue(3)]
	public TabControlExt.Weight TabBorderEnhanceWeight
	{
		get
		{
			return this.__TabBorderEnhanceWeight;
		}
		set
		{
			this.__TabBorderEnhanceWeight = value;
			try
			{
				foreach (object obj in this.TabPages)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					tabPageExt.BorderEnhanceWeight = value;
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
		}
	}

	// Token: 0x0600091B RID: 2331 RVA: 0x00005F2D File Offset: 0x0000412D
	public bool ShouldSerializeRenderMode()
	{
		return this.__RenderMode != this.defaultRenderMode;
	}

	// Token: 0x0600091C RID: 2332 RVA: 0x00005F40 File Offset: 0x00004140
	public void ResetRenderMode()
	{
		this.__RenderMode = this.defaultRenderMode;
	}

	// Token: 0x0600091D RID: 2333 RVA: 0x0003B748 File Offset: 0x00039948
	private void SetControlsSizeLocation()
	{
		if (this.DropButton.Visible & this.CloseButton.Visible)
		{
			this.pnlControls.Width = 43;
		}
		else if (this.DropButton.Visible | this.CloseButton.Visible)
		{
			this.pnlControls.Width = 25;
		}
		else
		{
			this.pnlControls.Width = 3;
		}
		this.pnlControls.Left = checked(base.Width - this.pnlControls.Width);
		this.CheckVisibility();
	}

	// Token: 0x0600091E RID: 2334 RVA: 0x0003B7D4 File Offset: 0x000399D4
	private void AdjustHeight()
	{
		checked
		{
			if (this.Alignment == TabControlExt.TabAlignment.Top)
			{
				this.pnlTop.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
				this.pnlTop.Height = this.pnlTabs.Height + this.__TabTop;
				this.pnlTop.Top = Conversions.ToInteger(Interaction.IIf(this.__TopSeparator, 2, 0));
				this.pnlTabs.Top = this.__TabTop;
				this.pnlBottom.Height = Conversions.ToInteger(Operators.SubtractObject(base.Height, Operators.AddObject(this.pnlTop.Height, Interaction.IIf(this.__TopSeparator, 2, 0))));
				this.pnlBottom.Top = base.Height - this.pnlBottom.Height;
			}
			else
			{
				this.pnlTop.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
				this.pnlTop.Height = this.pnlTabs.Height + this.__TabTop;
				this.pnlTop.Top = base.Height - this.pnlTop.Height;
				this.pnlTabs.Top = 0;
				this.pnlBottom.Height = Conversions.ToInteger(Operators.SubtractObject(base.Height, Operators.AddObject(this.pnlTop.Height, Interaction.IIf(this.__TopSeparator, 2, 0))));
				this.pnlBottom.Top = Conversions.ToInteger(Interaction.IIf(this.__TopSeparator, 2, 0));
			}
			this.pnlTop.Invalidate();
		}
	}

	// Token: 0x0600091F RID: 2335 RVA: 0x0003B990 File Offset: 0x00039B90
	private void Arrange__Items()
	{
		this.pnlTabs.SuspendLayout();
		checked
		{
			if (this.__Items.Count != 0)
			{
				int num = this.__LeftOffset;
				int num2 = this.__Items.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					this.__Items[i].TabVisible = (num + this.__Items[i].Width < this.pnlControls.Left);
					if (this.__Items[i].IsSelected & !this.__Items[i].TabVisible)
					{
						this.SelectItem(this.__Items[i]);
						return;
					}
					this.__Items[i].TabLeft = num;
					num += this.__Items[i].Width + this.__TabOffset - 1;
				}
				if (!this.__AddingPage)
				{
					if (this.__IsDelete)
					{
						int num3 = this.__Items.Count - 1;
						for (int j = num3; j >= 0; j += -1)
						{
							this.ShowTab(j);
						}
						this.__IsDelete = false;
					}
					else
					{
						int num4 = this.__Items.Count - 1;
						for (int k = 0; k <= num4; k++)
						{
							this.ShowTab(k);
						}
					}
				}
				this.pnlTabs.ResumeLayout();
			}
		}
	}

	// Token: 0x06000920 RID: 2336 RVA: 0x0003BAF8 File Offset: 0x00039CF8
	private void CheckVisibility()
	{
		checked
		{
			if (this.__Items != null)
			{
				int num = this.__LeftOffset;
				int num2 = this.__Items.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (this.__Items[i].TabVisible != num + this.__Items[i].Width < this.pnlControls.Left)
					{
						if (!this.__Items[i].TabVisible)
						{
							this.__Items[i].TabVisible = true;
							this.__Items[i].TabLeft = num;
							this.ShowTab(i);
						}
						else
						{
							this.__Items[i].TabVisible = false;
							if (this.__Items[i].IsSelected)
							{
								this.SelectItem(this.__Items[i]);
								break;
							}
							this.ShowTab(i);
							break;
						}
					}
					else if (!this.__Items[i].TabVisible)
					{
						break;
					}
					num += this.__Items[i].Width + this.__TabOffset - 1;
					if (num > this.pnlControls.Left)
					{
						break;
					}
				}
			}
		}
	}

	// Token: 0x06000921 RID: 2337 RVA: 0x0003BC38 File Offset: 0x00039E38
	private void ShowTab(int i)
	{
		this.__Items[i].Visible = this.__Items[i].TabVisible;
		if (this.__Items[0].Width != 1)
		{
			this.__Items[i].Left = this.__Items[i].TabLeft;
		}
	}

	// Token: 0x06000922 RID: 2338 RVA: 0x0003BCA4 File Offset: 0x00039EA4
	public int SelectedIndex()
	{
		checked
		{
			int num = this.TabPages.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (this.TabPages[i].IsSelected)
				{
					return i;
				}
			}
			return -1;
		}
	}

	// Token: 0x06000923 RID: 2339 RVA: 0x00005F4E File Offset: 0x0000414E
	public void SelectItem(int index)
	{
		if (index < 0)
		{
			index = 0;
		}
		this.SelectItem(this.TabPages[index]);
	}

	// Token: 0x06000924 RID: 2340 RVA: 0x0003BCE8 File Offset: 0x00039EE8
	public void SelectItem(TabPageExt __TabPage)
	{
		global::Globals.LockWindowUpdate(this.pnlControls.Handle);
		try
		{
			foreach (object obj in this.TabPages)
			{
				TabPageExt tabPageExt = (TabPageExt)obj;
				tabPageExt.IsSelected = false;
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
		if (__TabPage != null)
		{
			try
			{
				foreach (object obj2 in this.TabPages)
				{
					TabPageExt tabPageExt2 = (TabPageExt)obj2;
					if (this.__TabsDirection == TabControlExt.FlowDirection.LeftToRight)
					{
						tabPageExt2.SendToBack();
					}
					else
					{
						tabPageExt2.BringToFront();
					}
				}
			}
			finally
			{
				IEnumerator enumerator2;
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
			__TabPage.Form.Dock = DockStyle.Fill;
			__TabPage.Form.Visible = true;
			__TabPage.BringToFront();
			__TabPage.Form.BringToFront();
			__TabPage.Form.Focus();
			if (this.pnlBottom.Controls.Count > 1)
			{
				this.pnlBottom.Controls[1].Visible = false;
				this.pnlBottom.Controls[1].Dock = DockStyle.None;
			}
			__TabPage.IsSelected = true;
			if (!__TabPage.TabVisible & this.TabPages.get_IndexOf(__TabPage) != 0)
			{
				this.TabPages.set_IndexOf(__TabPage, 0);
			}
			this.SelectedFormIndex = __TabPage.Form;
			this.SelectedFormIndex.Tag = __TabPage;
			TabControlExt.TabSelectedFormEventHandler tabSelectedFormEvent = this.TabSelectedFormEvent;
			if (tabSelectedFormEvent != null)
			{
				tabSelectedFormEvent(this, this.SelectedFormIndex);
			}
		}
		else if (this.pnlTabs.Controls.Count > 0)
		{
			try
			{
				foreach (object obj3 in this.__Items)
				{
					TabPageExt tabPageExt3 = (TabPageExt)obj3;
					if (tabPageExt3.Form.Equals(this.pnlBottom.Controls[0]))
					{
						tabPageExt3.Select();
						break;
					}
				}
			}
			finally
			{
				IEnumerator enumerator3;
				if (enumerator3 is IDisposable)
				{
					(enumerator3 as IDisposable).Dispose();
				}
			}
		}
		global::Globals.LockWindowUpdate(IntPtr.Zero);
	}

	// Token: 0x06000925 RID: 2341 RVA: 0x0003BF30 File Offset: 0x0003A130
	private void __TabControl_FontChanged(object sender, EventArgs e)
	{
		try
		{
			foreach (object obj in this.TabPages)
			{
				TabPageExt tabPageExt = (TabPageExt)obj;
				tabPageExt.Font = this.Font;
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
	}

	// Token: 0x06000926 RID: 2342 RVA: 0x0003BF94 File Offset: 0x0003A194
	private void __TabControl_ForeColorChanged(object sender, EventArgs e)
	{
		try
		{
			foreach (object obj in this.TabPages)
			{
				TabPageExt tabPageExt = (TabPageExt)obj;
				tabPageExt.ForeColor = this.ForeColor;
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
	}

	// Token: 0x06000927 RID: 2343 RVA: 0x00005F6D File Offset: 0x0000416D
	private void __TabControl_Paint(object sender, PaintEventArgs e)
	{
		if (this.__TopSeparator)
		{
			ControlPaint.DrawBorder3D(e.Graphics, new Rectangle(-2, 0, checked(base.Width + 4), -2));
		}
	}

	// Token: 0x06000928 RID: 2344 RVA: 0x00005F94 File Offset: 0x00004194
	private void __TabControl_Resize(object sender, EventArgs e)
	{
		this.CheckVisibility();
	}

	// Token: 0x06000929 RID: 2345 RVA: 0x00005F9C File Offset: 0x0000419C
	private void pnlTop_SizeChanged(object sender, EventArgs e)
	{
		this.PositionButtons();
	}

	// Token: 0x0600092A RID: 2346 RVA: 0x0003BFF8 File Offset: 0x0003A1F8
	private void PositionButtons()
	{
		this.DropButton.Top = Conversions.ToInteger(Operators.AddObject(Math.Ceiling((double)(checked(this.pnlTop.Height - this.DropButton.Height)) / 2.0), Interaction.IIf(this.Alignment == TabControlExt.TabAlignment.Top & this.TopSeparator, -1, 0)));
		this.CloseButton.Top = this.DropButton.Top;
	}

	// Token: 0x0600092B RID: 2347 RVA: 0x0003C080 File Offset: 0x0003A280
	private void pnlTop_Paint(object sender, PaintEventArgs e)
	{
		LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, this.pnlTop.Height), Helper.RenderColors.BackHighColor(this.__RenderMode, this.BackHighColor), Helper.RenderColors.BackLowColor(this.__RenderMode, this.BackLowColor));
		e.Graphics.FillRectangle(linearGradientBrush, new Rectangle(0, 0, this.pnlTop.Width, this.pnlTop.Height));
		Pen pen = new Pen(Helper.RenderColors.BorderColor(this.__RenderMode, this.BorderColor));
		if (this.Alignment == TabControlExt.TabAlignment.Top)
		{
			object graphics = e.Graphics;
			Type type = null;
			string memberName = "DrawLine";
			object[] array;
			object[] arguments = array = new object[]
			{
				pen,
				0,
				Operators.SubtractObject(NewLateBinding.LateGet(sender, null, "Height", new object[0], null, null, null), 1),
				Operators.AddObject(NewLateBinding.LateGet(sender, null, "Width", new object[0], null, null, null), 1),
				Operators.SubtractObject(NewLateBinding.LateGet(sender, null, "Height", new object[0], null, null, null), 1)
			};
			string[] argumentNames = null;
			Type[] typeArguments = null;
			bool[] array2 = new bool[5];
			array2[0] = true;
			bool[] array3 = array2;
			NewLateBinding.LateCall(graphics, type, memberName, arguments, argumentNames, typeArguments, array2, true);
			if (array3[0])
			{
				pen = (Pen)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(Pen));
			}
		}
		else
		{
			object graphics2 = e.Graphics;
			Type type2 = null;
			string memberName2 = "DrawLine";
			object[] array;
			object[] arguments2 = array = new object[]
			{
				pen,
				0,
				0,
				Operators.AddObject(NewLateBinding.LateGet(sender, null, "Width", new object[0], null, null, null), 1),
				0
			};
			string[] argumentNames2 = null;
			Type[] typeArguments2 = null;
			bool[] array4 = new bool[5];
			array4[0] = true;
			bool[] array3 = array4;
			NewLateBinding.LateCall(graphics2, type2, memberName2, arguments2, argumentNames2, typeArguments2, array4, true);
			if (array3[0])
			{
				pen = (Pen)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(Pen));
			}
		}
		pen.Dispose();
		linearGradientBrush.Dispose();
	}

	// Token: 0x0600092C RID: 2348 RVA: 0x0003C28C File Offset: 0x0003A48C
	private void DropButton_MouseDown(object sender, MouseEventArgs e)
	{
		this.WinMenu.Items.Clear();
		checked
		{
			int num = this.__Items.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				this.WinMenu.Items.Add(this.__Items[i].MenuItem);
				this.__Items[i].MenuItem.Click += this.MenuClick;
			}
			this.WinMenu.ShowImageMargin = false;
			this.WinMenu.Show(this.pnlTop, this.pnlTop.Width - this.WinMenu.Width, this.pnlTop.Height - 1);
		}
	}

	// Token: 0x0600092D RID: 2349 RVA: 0x00005FA4 File Offset: 0x000041A4
	private void MenuClick(object sender, EventArgs e)
	{
		NewLateBinding.LateCall(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null), null, "Select", new object[0], null, null, null, true);
	}

	// Token: 0x0600092E RID: 2350 RVA: 0x00005FD1 File Offset: 0x000041D1
	private void CloseButton_MouseDown(object sender, MouseEventArgs e)
	{
		this.__Items.SelectedTab().Form.Close();
	}

	// Token: 0x0600092F RID: 2351 RVA: 0x0003C348 File Offset: 0x0003A548
	private void __ItemsGetTabRegion(object sender, TabControlExt.GetTabRegionEventArgs e)
	{
		TabControlExt.GetTabRegionEventHandler getTabRegionEvent = this.GetTabRegionEvent;
		if (getTabRegionEvent != null)
		{
			getTabRegionEvent(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	// Token: 0x06000930 RID: 2352 RVA: 0x0003C36C File Offset: 0x0003A56C
	private void __ItemsTabPaint__Background(object sender, TabControlExt.TabPaintEventArgs e)
	{
		TabControlExt.TabPaintBackgroundEventHandler tabPaintBackgroundEvent = this.TabPaintBackgroundEvent;
		if (tabPaintBackgroundEvent != null)
		{
			tabPaintBackgroundEvent(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	// Token: 0x06000931 RID: 2353 RVA: 0x0003C390 File Offset: 0x0003A590
	private void __ItemsTabPaintBorder(object sender, TabControlExt.TabPaintEventArgs e)
	{
		TabControlExt.TabPaintBorderEventHandler tabPaintBorderEvent = this.TabPaintBorderEvent;
		if (tabPaintBorderEvent != null)
		{
			tabPaintBorderEvent(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	// Token: 0x06000932 RID: 2354 RVA: 0x0003C3B4 File Offset: 0x0003A5B4
	public void SetColors(ProfessionalColorTable ColorTable)
	{
		this.BackHighColor = ColorTable.ToolStripGradientEnd;
		this.BackLowColor = ColorTable.ToolStripGradientBegin;
		this.BorderColor = ColorTable.GripDark;
		this.BorderColorDisabled = ColorTable.SeparatorDark;
		this.ControlButtonBackHighColor = ColorTable.ButtonSelectedGradientBegin;
		this.ControlButtonBackLowColor = ColorTable.ButtonSelectedGradientEnd;
		this.ControlButtonBorderColor = ColorTable.ButtonPressedBorder;
		this.TabBackHighColor = ColorTable.MenuItemPressedGradientBegin;
		this.TabBackLowColor = ColorTable.MenuItemPressedGradientEnd;
		this.TabBackHighColorDisabled = ColorTable.ToolStripDropDownBackground;
		this.TabBackLowColorDisabled = ColorTable.ToolStripGradientMiddle;
		this.TabCloseButtonBackHighColor = Color.Transparent;
		this.TabCloseButtonBackHighColorDisabled = Color.Transparent;
		this.TabCloseButtonBackHighColorHot = Color.WhiteSmoke;
		this.TabCloseButtonBackLowColor = Color.Transparent;
		this.TabCloseButtonBackLowColorDisabled = Color.Transparent;
		this.TabCloseButtonBackLowColorHot = Color.LightGray;
		this.TabCloseButtonBorderColor = Color.Transparent;
		this.TabCloseButtonBorderColorDisabled = Color.Transparent;
		this.TabCloseButtonBorderColorHot = Color.Gray;
		this.TabCloseButtonForeColor = Color.Gray;
		this.TabCloseButtonForeColorDisabled = Color.Gray;
		this.TabCloseButtonForeColorHot = Color.Firebrick;
	}

	// Token: 0x170002DB RID: 731
	// (get) Token: 0x06000933 RID: 2355 RVA: 0x0003C4CC File Offset: 0x0003A6CC
	// (set) Token: 0x06000934 RID: 2356 RVA: 0x000027EC File Offset: 0x000009EC
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Category("Appearance")]
	public new BorderStyle BorderStyle
	{
		get
		{
			BorderStyle result;
			return result;
		}
		set
		{
		}
	}

	// Token: 0x04000456 RID: 1110
	private IContainer components;

	// Token: 0x0400045F RID: 1119
	private bool __AddingPage;

	// Token: 0x04000460 RID: 1120
	private int __LeftOffset;

	// Token: 0x04000461 RID: 1121
	private bool __IsDelete;

	// Token: 0x04000462 RID: 1122
	private Panel __Background;

	// Token: 0x04000464 RID: 1124
	private TabControlExt.FlowDirection __TabsDirection;

	// Token: 0x04000465 RID: 1125
	private int __TabMaximumWidth;

	// Token: 0x04000466 RID: 1126
	private int __TabMinimumWidth;

	// Token: 0x04000467 RID: 1127
	private Color __BackLowColor;

	// Token: 0x04000468 RID: 1128
	private Color __BackHighColor;

	// Token: 0x04000469 RID: 1129
	private Color __BorderColor;

	// Token: 0x0400046A RID: 1130
	private Color __TabBackHighColor;

	// Token: 0x0400046B RID: 1131
	private Color __TabBackLowColor;

	// Token: 0x0400046C RID: 1132
	private Color __TabBackHighColorDisabled;

	// Token: 0x0400046D RID: 1133
	private Color __TabBackLowColorDisabled;

	// Token: 0x0400046E RID: 1134
	private Color __BorderColorDisabled;

	// Token: 0x0400046F RID: 1135
	private Color __ForeColorDisabled;

	// Token: 0x04000470 RID: 1136
	private bool __TopSeparator;

	// Token: 0x04000471 RID: 1137
	private int __TabTop;

	// Token: 0x04000472 RID: 1138
	private int __TabHeight;

	// Token: 0x04000473 RID: 1139
	private int __TabOffset;

	// Token: 0x04000474 RID: 1140
	private int __TabPadLeft;

	// Token: 0x04000475 RID: 1141
	private int __TabPadRight;

	// Token: 0x04000476 RID: 1142
	private object __TabSmoothingMode;

	// Token: 0x04000477 RID: 1143
	private Size __TabIconSize;

	// Token: 0x04000478 RID: 1144
	private TabControlExt.TabAlignment __Alignment;

	// Token: 0x04000479 RID: 1145
	private bool __FontBoldOnSelect;

	// Token: 0x0400047A RID: 1146
	private bool __HotTrack;

	// Token: 0x0400047B RID: 1147
	private Size __TabCloseButtonSize;

	// Token: 0x0400047C RID: 1148
	private bool __TabCloseButtonVisible;

	// Token: 0x0400047D RID: 1149
	private Image __TabCloseButtonImage;

	// Token: 0x0400047E RID: 1150
	private Image __TabCloseButtonImageHot;

	// Token: 0x0400047F RID: 1151
	private Image __TabCloseButtonImageDisabled;

	// Token: 0x04000480 RID: 1152
	private Color __TabCloseButtonBackHighColor;

	// Token: 0x04000481 RID: 1153
	private Color __TabCloseButtonBackLowColor;

	// Token: 0x04000482 RID: 1154
	private Color __TabCloseButtonBorderColor;

	// Token: 0x04000483 RID: 1155
	private Color __TabCloseButtonForeColor;

	// Token: 0x04000484 RID: 1156
	private Color __TabCloseButtonBackHighColorDisabled;

	// Token: 0x04000485 RID: 1157
	private Color __TabCloseButtonBackLowColorDisabled;

	// Token: 0x04000486 RID: 1158
	private Color __TabCloseButtonBorderColorDisabled;

	// Token: 0x04000487 RID: 1159
	private Color __TabCloseButtonForeColorDisabled;

	// Token: 0x04000488 RID: 1160
	private Color __TabCloseButtonBackHighColorHot;

	// Token: 0x04000489 RID: 1161
	private Color __TabCloseButtonBackLowColorHot;

	// Token: 0x0400048A RID: 1162
	private Color __TabCloseButtonBorderColorHot;

	// Token: 0x0400048B RID: 1163
	private Color __TabCloseButtonForeColorHot;

	// Token: 0x0400048C RID: 1164
	private bool __AllowTabReorder;

	// Token: 0x0400048D RID: 1165
	private bool __TabGlassGradient;

	// Token: 0x0400048E RID: 1166
	private bool __TabBorderEnhanced;

	// Token: 0x0400048F RID: 1167
	private ToolStripRenderMode __RenderMode;

	// Token: 0x04000490 RID: 1168
	private ToolStripRenderer __ContextMenuRenderer;

	// Token: 0x04000491 RID: 1169
	private TabControlExt.Weight __TabBorderEnhanceWeight;

	// Token: 0x04000492 RID: 1170
	public readonly Padding defaultPadding;

	// Token: 0x04000493 RID: 1171
	public readonly Color defaultBackLowColor;

	// Token: 0x04000494 RID: 1172
	public readonly Color defaultBackHighColor;

	// Token: 0x04000495 RID: 1173
	public readonly Color defaultBorderColor;

	// Token: 0x04000496 RID: 1174
	public readonly Color defaultTabBackHighColor;

	// Token: 0x04000497 RID: 1175
	public readonly Color defaultTabBackLowColor;

	// Token: 0x04000498 RID: 1176
	public readonly Color defaultTabBackHighColorDisabled;

	// Token: 0x04000499 RID: 1177
	public readonly Color defaultTabBackLowColorDisabled;

	// Token: 0x0400049A RID: 1178
	public readonly Color defaultBorderColorDisabled;

	// Token: 0x0400049B RID: 1179
	public readonly Color defaultForeColorDisabled;

	// Token: 0x0400049C RID: 1180
	public readonly Color defaultControlButtonBackHighColor;

	// Token: 0x0400049D RID: 1181
	public readonly Color defaultControlButtonBackLowColor;

	// Token: 0x0400049E RID: 1182
	public readonly Color defaultControlButtonBorderColor;

	// Token: 0x0400049F RID: 1183
	public readonly Color defaultControlButtonForeColor;

	// Token: 0x040004A0 RID: 1184
	public readonly Size defaultTabCloseButtonSize;

	// Token: 0x040004A1 RID: 1185
	public readonly Size defaultTabIconSize;

	// Token: 0x040004A2 RID: 1186
	public readonly Color defaultTabCloseButtonBackHighColor;

	// Token: 0x040004A3 RID: 1187
	public readonly Color defaultTabCloseButtonBackHighColorDisabled;

	// Token: 0x040004A4 RID: 1188
	public readonly Color defaultTabCloseButtonBackHighColorHot;

	// Token: 0x040004A5 RID: 1189
	public readonly Color defaultTabCloseButtonBackLowColor;

	// Token: 0x040004A6 RID: 1190
	public readonly Color defaultTabCloseButtonBackLowColorDisabled;

	// Token: 0x040004A7 RID: 1191
	public readonly Color defaultTabCloseButtonBackLowColorHot;

	// Token: 0x040004A8 RID: 1192
	public readonly Color defaultTabCloseButtonBorderColor;

	// Token: 0x040004A9 RID: 1193
	public readonly Color defaultTabCloseButtonBorderColorDisabled;

	// Token: 0x040004AA RID: 1194
	public readonly Color defaultTabCloseButtonBorderColorHot;

	// Token: 0x040004AB RID: 1195
	public readonly Color defaultTabCloseButtonForeColor;

	// Token: 0x040004AC RID: 1196
	public readonly Color defaultTabCloseButtonForeColorDisabled;

	// Token: 0x040004AD RID: 1197
	public readonly Color defaultTabCloseButtonForeColorHot;

	// Token: 0x040004AE RID: 1198
	public readonly ToolStripRenderMode defaultRenderMode;

	// Token: 0x0200009B RID: 155
	[Description("Provides data for the MdiTabControl.TabControl.GetTabRegion event.")]
	public class GetTabRegionEventArgs : EventArgs
	{
		// Token: 0x06000935 RID: 2357 RVA: 0x00005FE8 File Offset: 0x000041E8
		private GetTabRegionEventArgs()
		{
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x00005FF0 File Offset: 0x000041F0
		[Description("Initializes a new instance of the MdiTabControl.TabControl.GetTabRegionEventArgs class.")]
		public GetTabRegionEventArgs(Point[] Points, int Width, int Height, bool Selected)
		{
			this.__Points = Points;
			this.__TabWidth = Width;
			this.__TabHeight = Height;
			this.__Selected = Selected;
		}

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x06000937 RID: 2359 RVA: 0x0003C4DC File Offset: 0x0003A6DC
		[Description("Returns whether the tab is selected or not.")]
		public int Selected
		{
			get
			{
				return (-((this.__Selected > false) ? 1 : 0)) ? 1 : 0;
			}
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x06000938 RID: 2360 RVA: 0x0003C4F8 File Offset: 0x0003A6F8
		[Description("Returns the tab width.")]
		public int TabWidth
		{
			get
			{
				return this.__TabWidth;
			}
		}

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x06000939 RID: 2361 RVA: 0x0003C510 File Offset: 0x0003A710
		[Description("Returns the tab height.")]
		public int TabHeight
		{
			get
			{
				return this.__TabHeight;
			}
		}

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x0600093A RID: 2362 RVA: 0x0003C528 File Offset: 0x0003A728
		// (set) Token: 0x0600093B RID: 2363 RVA: 0x00006015 File Offset: 0x00004215
		[Description("Gets or sets an array of System.Drawing.Point structures that represents the points through which the tab path is constructed.")]
		public Point[] Points
		{
			get
			{
				return this.__Points;
			}
			set
			{
				this.__Points = value;
			}
		}

		// Token: 0x040004B4 RID: 1204
		private Point[] __Points;

		// Token: 0x040004B5 RID: 1205
		private int __TabWidth;

		// Token: 0x040004B6 RID: 1206
		private int __TabHeight;

		// Token: 0x040004B7 RID: 1207
		private bool __Selected;
	}

	// Token: 0x0200009C RID: 156
	[Description("Provides data for the MdiTabControl.TabControl.TabPaint event.")]
	public class TabPaintEventArgs : PaintEventArgs
	{
		// Token: 0x0600093C RID: 2364 RVA: 0x0003C540 File Offset: 0x0003A740
		[Description("Initializes a new instance of the MdiTabControl.TabControl.GetTabRegionEventArgs class.")]
		public TabPaintEventArgs(Graphics graphics, Rectangle clipRect, bool Selected, bool Hot, GraphicsPath GraphicPath, int Width, int Height) : base(graphics, clipRect)
		{
			this.__Handled = false;
			this.__Selected = false;
			this.__Hot = false;
			this.__Selected = Selected;
			this.__Hot = Hot;
			this.__GraphicPath = GraphicPath;
			this.__TabWidth = Width;
			this.__TabHeight = Height;
		}

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x0600093D RID: 2365 RVA: 0x0000601E File Offset: 0x0000421E
		[Description("Returns the tab's hot state.")]
		public bool Hot
		{
			get
			{
				return this.__Hot;
			}
		}

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x0600093E RID: 2366 RVA: 0x00006026 File Offset: 0x00004226
		[Description("Returns whether the tab is selected or not.")]
		public bool Selected
		{
			get
			{
				return this.__Selected;
			}
		}

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x0600093F RID: 2367 RVA: 0x0000602E File Offset: 0x0000422E
		// (set) Token: 0x06000940 RID: 2368 RVA: 0x00006036 File Offset: 0x00004236
		[Description("Gets or sets a value that indicates whether the event handler has completely handled the paint or whether the system should continue its own processing.")]
		public bool Handled
		{
			get
			{
				return this.__Handled;
			}
			set
			{
				this.__Handled = value;
			}
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x06000941 RID: 2369 RVA: 0x0003C594 File Offset: 0x0003A794
		[Description("Returns the tab width.")]
		public int TabWidth
		{
			get
			{
				return this.__TabWidth;
			}
		}

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x06000942 RID: 2370 RVA: 0x0003C5AC File Offset: 0x0003A7AC
		[Description("Returns the tab height.")]
		public int TabHeight
		{
			get
			{
				return this.__TabHeight;
			}
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x06000943 RID: 2371 RVA: 0x0003C5C4 File Offset: 0x0003A7C4
		[Description("Represents a series of connected lines and curves which the tab path is constructed.")]
		public GraphicsPath GraphicPath
		{
			get
			{
				return this.__GraphicPath;
			}
		}

		// Token: 0x040004B8 RID: 1208
		private bool __Handled;

		// Token: 0x040004B9 RID: 1209
		private bool __Selected;

		// Token: 0x040004BA RID: 1210
		private bool __Hot;

		// Token: 0x040004BB RID: 1211
		private GraphicsPath __GraphicPath;

		// Token: 0x040004BC RID: 1212
		private int __TabWidth;

		// Token: 0x040004BD RID: 1213
		private int __TabHeight;
	}

	// Token: 0x0200009D RID: 157
	[Description("Contains a collection of MdiTabControl.__TabPage objects.")]
	public class __TabPageCollection : CollectionBase
	{
		// Token: 0x06000944 RID: 2372 RVA: 0x0000603F File Offset: 0x0000423F
		public __TabPageCollection(TabControlExt Owner)
		{
			this.__IsReorder = false;
			this.__EnabledToolTip = true;
			this.__TabControl = Owner;
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000945 RID: 2373 RVA: 0x0003C5DC File Offset: 0x0003A7DC
		// (remove) Token: 0x06000946 RID: 2374 RVA: 0x0003C614 File Offset: 0x0003A814
		public event TabControlExt.__TabPageCollection.GetTabRegionEventHandler GetTabRegion;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000947 RID: 2375 RVA: 0x0003C64C File Offset: 0x0003A84C
		// (remove) Token: 0x06000948 RID: 2376 RVA: 0x0003C684 File Offset: 0x0003A884
		[Description("Occurs when the Tab __Background has been painted.")]
		public event TabControlExt.__TabPageCollection.TabPaint__BackgroundEventHandler TabPaint__Background;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06000949 RID: 2377 RVA: 0x0003C6BC File Offset: 0x0003A8BC
		// (remove) Token: 0x0600094A RID: 2378 RVA: 0x0003C6F4 File Offset: 0x0003A8F4
		[Description("Occurs when the Tab Border has been painted.")]
		public event TabControlExt.__TabPageCollection.TabPaintBorderEventHandler TabPaintBorder;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x0600094B RID: 2379 RVA: 0x0003C72C File Offset: 0x0003A92C
		// (remove) Token: 0x0600094C RID: 2380 RVA: 0x0003C764 File Offset: 0x0003A964
		public event TabControlExt.__TabPageCollection.OnVisibleChangedEventHandler OnVisibleChanged;

		// Token: 0x0600094D RID: 2381 RVA: 0x0003C79C File Offset: 0x0003A99C
		[Description("Create a new TabPage and adds it to the collection whit the Form associated and returns the created __TabPage.")]
		public TabPageExt Add(object Form, string sText = "", Bitmap icon = null)
		{
			this.__TabPage = new TabPageExt(RuntimeHelpers.GetObjectValue(Form), sText, icon);
			this.__TabPage.SuspendLayout();
			this.__TabControl.SuspendLayout();
			this.__TabControl.__AddingPage = true;
			this.__TabPage.BackHighColor = this.__TabControl.TabBackHighColor;
			this.__TabPage.BackHighColorDisabled = this.__TabControl.TabBackHighColorDisabled;
			this.__TabPage.BackLowColor = this.__TabControl.TabBackLowColor;
			this.__TabPage.BackLowColorDisabled = this.__TabControl.TabBackLowColorDisabled;
			this.__TabPage.BorderColor = this.__TabControl.BorderColor;
			this.__TabPage.BorderColorDisabled = this.__TabControl.BorderColorDisabled;
			this.__TabPage.ForeColor = this.__TabControl.ForeColor;
			this.__TabPage.ForeColorDisabled = this.__TabControl.ForeColorDisabled;
			this.__TabPage.MaximumWidth = this.__TabControl.TabMaximumWidth;
			this.__TabPage.MinimumWidth = this.__TabControl.TabMinimumWidth;
			this.__TabPage.PadLeft = this.__TabControl.TabPadLeft;
			this.__TabPage.PadRight = this.__TabControl.TabPadRight;
			this.__TabPage.CloseButtonVisible = this.__TabControl.TabCloseButtonVisible;
			this.__TabPage.CloseButtonImage = this.__TabControl.TabCloseButtonImage;
			this.__TabPage.CloseButtonImageHot = this.__TabControl.TabCloseButtonImageHot;
			this.__TabPage.CloseButtonImageDisabled = this.__TabControl.TabCloseButtonImageDisabled;
			this.__TabPage.CloseButtonSize = this.__TabControl.TabCloseButtonSize;
			this.__TabPage.CloseButtonBackHighColor = this.__TabControl.TabCloseButtonBackHighColor;
			this.__TabPage.CloseButtonBackLowColor = this.__TabControl.TabCloseButtonBackLowColor;
			this.__TabPage.CloseButtonBorderColor = this.__TabControl.TabCloseButtonBorderColor;
			this.__TabPage.CloseButtonForeColor = this.__TabControl.TabCloseButtonForeColor;
			this.__TabPage.CloseButtonBackHighColorDisabled = this.__TabControl.TabCloseButtonBackHighColorDisabled;
			this.__TabPage.CloseButtonBackLowColorDisabled = this.__TabControl.TabCloseButtonBackLowColorDisabled;
			this.__TabPage.CloseButtonBorderColorDisabled = this.__TabControl.TabCloseButtonBorderColorDisabled;
			this.__TabPage.CloseButtonForeColorDisabled = this.__TabControl.TabCloseButtonForeColorDisabled;
			this.__TabPage.CloseButtonBackHighColorHot = this.__TabControl.TabCloseButtonBackHighColorHot;
			this.__TabPage.CloseButtonBackLowColorHot = this.__TabControl.TabCloseButtonBackLowColorHot;
			this.__TabPage.CloseButtonBorderColorHot = this.__TabControl.TabCloseButtonBorderColorHot;
			this.__TabPage.CloseButtonForeColorHot = this.__TabControl.TabCloseButtonForeColorHot;
			this.__TabPage.HotTrack = this.__TabControl.HotTrack;
			this.__TabPage.Font = this.__TabControl.Font;
			this.__TabPage.FontBoldOnSelect = this.__TabControl.FontBoldOnSelect;
			this.__TabPage.IconSize = this.__TabControl.TabIconSize;
			this.__TabPage.SmoothingMode = this.__TabControl.SmoothingMode;
			this.__TabPage.Alignment = this.__TabControl.Alignment;
			this.__TabPage.GlassGradient = this.__TabControl.TabGlassGradient;
			this.__TabPage.BorderEnhanced = this.__TabControl.__TabBorderEnhanced;
			this.__TabPage.RenderMode = this.__TabControl.RenderMode;
			this.__TabPage.BorderEnhanceWeight = this.__TabControl.TabBorderEnhanceWeight;
			this.__TabPage.Top = 0;
			this.__TabPage.Left = this.__TabControl.__LeftOffset;
			this.__TabPage.Height = this.__TabControl.TabHeight;
			this.__TabPage.Click += this.__TabPage_Clicked;
			this.__TabPage.Close += this.__TabPage_Closed;
			this.__TabPage.GetTabRegion += this.__TabPage_GetTabRegion;
			this.__TabPage.TabPaintBackground += this.__TabPage_TabPaint__Background;
			this.__TabPage.TabPaintBorder += this.__TabPage_TabPaintBorder;
			this.__TabPage.SizeChanged += this.__TabPage_SizeChanged;
			this.__TabPage.Draging += this.__TabPage_Draging;
			base.List.Add(this.__TabPage);
			this.__TabControl.ResumeLayout();
			this.__TabPage.ResumeLayout();
			TabControlExt.__TabPageCollection.OnVisibleChangedEventHandler onVisibleChangedEvent = this.OnVisibleChangedEvent;
			if (onVisibleChangedEvent != null)
			{
				onVisibleChangedEvent(this, true);
			}
			return this.__TabPage;
		}

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x0600094E RID: 2382 RVA: 0x0000605C File Offset: 0x0000425C
		// (set) Token: 0x0600094F RID: 2383 RVA: 0x0003CC54 File Offset: 0x0003AE54
		public bool EnabledToolTip
		{
			get
			{
				return this.__EnabledToolTip;
			}
			set
			{
				this.__EnabledToolTip = value;
				if (value)
				{
					this.__TabControl.TabToolTip.SetToolTip(this.__TabPage, this.__TabPage.Form.Text);
				}
				else
				{
					this.__TabControl.TabToolTip.RemoveAll();
				}
			}
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x0003CCA4 File Offset: 0x0003AEA4
		[Description("Removes a __TabPage from the collection.")]
		public void Remove(TabPageExt __TabPage)
		{
			try
			{
				this.__TabControl.__IsDelete = true;
				if (this.__TabControl.pnlBottom.Controls.Count > 1)
				{
					this.__TabControl.pnlBottom.Controls[1].Dock = DockStyle.Fill;
					this.__TabControl.pnlBottom.Controls[1].Visible = true;
				}
				TabControlExt.__TabPageCollection.OnVisibleChangedEventHandler onVisibleChangedEvent = this.OnVisibleChangedEvent;
				if (onVisibleChangedEvent != null)
				{
					onVisibleChangedEvent(this, base.List.Count > 1);
				}
				base.List.Remove(__TabPage);
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x170002E7 RID: 743
		[Description("Gets a __TabPage in the position Index from the collection.")]
		public TabPageExt this[int Index]
		{
			get
			{
				TabPageExt result;
				if (base.List.Count > 0)
				{
					result = (TabPageExt)base.List[Index];
				}
				return result;
			}
		}

		// Token: 0x170002E8 RID: 744
		[Description("Gets a __TabPage associated with the Form from the collection.")]
		public TabPageExt this[Form Form]
		{
			get
			{
				int num = this.get_IndexOf(Form);
				TabPageExt result;
				if (num == -1)
				{
					result = null;
				}
				else
				{
					result = (TabPageExt)base.List[num];
				}
				return result;
			}
		}

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x06000953 RID: 2387 RVA: 0x0003CDC0 File Offset: 0x0003AFC0
		// (set) Token: 0x06000954 RID: 2388 RVA: 0x00006064 File Offset: 0x00004264
		[Description("Returns the index of the specified __TabPage in the collection.")]
		public int IndexOf
		{
			get
			{
				return base.List.IndexOf(__TabPage);
			}
			set
			{
				this.__IsReorder = true;
				base.List.Remove(__TabPage);
				base.List.Insert(value, __TabPage);
				this.__TabControl.Arrange__Items();
				this.__IsReorder = false;
			}
		}

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x06000955 RID: 2389 RVA: 0x0003CDDC File Offset: 0x0003AFDC
		[Description("Returns the index of the specified __TabPage associated with the Form in the collection.")]
		public int IndexOf
		{
			get
			{
				int result = -1;
				checked
				{
					int num = base.List.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (((TabPageExt)base.List[i]).Form.Equals(Form))
						{
							result = i;
							return result;
						}
					}
					return result;
				}
			}
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x0003CE2C File Offset: 0x0003B02C
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete(index, RuntimeHelpers.GetObjectValue(value));
			if (!this.__IsReorder)
			{
				this.__TabControl.pnlBottom.Controls.Add(((TabPageExt)value).Form);
				this.__TabControl.pnlTabs.Controls.Add((TabPageExt)value);
				((TabPageExt)value).Select();
				this.__TabControl.__AddingPage = false;
				this.__TabControl.Arrange__Items();
				this.__TabControl.__Background.Visible = false;
			}
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x0003CEBC File Offset: 0x0003B0BC
		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete(index, RuntimeHelpers.GetObjectValue(value));
			if (!this.__IsReorder)
			{
				if (base.List.Count == 0)
				{
					this.__TabControl.__Background.Visible = true;
				}
				this.__TabControl.Arrange__Items();
				this.__TabControl.pnlBottom.Controls.Remove(((TabPageExt)value).Form);
				((TabPageExt)value).Form.Dispose();
				this.__TabControl.pnlTabs.Controls.Remove((TabPageExt)value);
				((TabPageExt)value).Dispose();
				this.__TabControl.SelectItem(-1);
			}
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x00006098 File Offset: 0x00004298
		protected override void OnClear()
		{
			base.OnClear();
			this.__TabControl.__Background.Visible = true;
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x000060B1 File Offset: 0x000042B1
		protected override void OnClearComplete()
		{
			base.OnClearComplete();
			this.__TabControl.pnlBottom.Controls.Clear();
			this.__TabControl.pnlTabs.Controls.Clear();
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0003CF70 File Offset: 0x0003B170
		[Description("Returns the selected __TabPage.")]
		public TabPageExt SelectedTab()
		{
			try
			{
				foreach (object obj in base.List)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					if (tabPageExt.IsSelected)
					{
						return tabPageExt;
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
			return null;
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0003CFD8 File Offset: 0x0003B1D8
		[Description("Returns the index of the selected __TabPage.")]
		public int SelectedIndex()
		{
			int result;
			try
			{
				foreach (object obj in base.List)
				{
					TabPageExt tabPageExt = (TabPageExt)obj;
					if (tabPageExt.IsSelected)
					{
						result = base.List.IndexOf(tabPageExt);
						break;
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
			return result;
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0003D048 File Offset: 0x0003B248
		private void __TabPage_Clicked(object sender, EventArgs e)
		{
			object[] array;
			bool[] array2;
			NewLateBinding.LateCall(this.__TabControl, null, "SelectItem", array = new object[]
			{
				sender
			}, null, null, array2 = new bool[]
			{
				true
			}, true);
			if (array2[0])
			{
				sender = RuntimeHelpers.GetObjectValue(array[0]);
			}
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x000060E3 File Offset: 0x000042E3
		private void __TabPage_Closed(object sender, EventArgs e)
		{
			this.Remove((TabPageExt)sender);
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x0003D094 File Offset: 0x0003B294
		private void __TabPage_GetTabRegion(object sender, TabControlExt.GetTabRegionEventArgs e)
		{
			TabControlExt.__TabPageCollection.GetTabRegionEventHandler getTabRegionEvent = this.GetTabRegionEvent;
			if (getTabRegionEvent != null)
			{
				getTabRegionEvent(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x0003D0B8 File Offset: 0x0003B2B8
		private void __TabPage_TabPaint__Background(object sender, TabControlExt.TabPaintEventArgs e)
		{
			TabControlExt.__TabPageCollection.TabPaint__BackgroundEventHandler tabPaint__BackgroundEvent = this.TabPaint__BackgroundEvent;
			if (tabPaint__BackgroundEvent != null)
			{
				tabPaint__BackgroundEvent(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x0003D0DC File Offset: 0x0003B2DC
		private void __TabPage_TabPaintBorder(object sender, TabControlExt.TabPaintEventArgs e)
		{
			TabControlExt.__TabPageCollection.TabPaintBorderEventHandler tabPaintBorderEvent = this.TabPaintBorderEvent;
			if (tabPaintBorderEvent != null)
			{
				tabPaintBorderEvent(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x000060F1 File Offset: 0x000042F1
		private void __TabPage_SizeChanged(object sender, EventArgs e)
		{
			this.__TabControl.Arrange__Items();
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x0003D100 File Offset: 0x0003B300
		private void __TabPage_Draging(object sender, MouseEventArgs e)
		{
			if (this.__TabControl.AllowTabReorder && e.Button == MouseButtons.Left)
			{
				TabPageExt tabPageExt = this.Get__TabPage((TabPageExt)sender, e.X, e.Y);
				if (tabPageExt != null)
				{
					this.set_IndexOf(tabPageExt, this.get_IndexOf((TabPageExt)sender));
				}
			}
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x0003D160 File Offset: 0x0003B360
		private TabPageExt Get__TabPage(TabPageExt __TabPage, int x, int y)
		{
			checked
			{
				int num = base.List.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if ((TabPageExt)base.List[i] != __TabPage && ((TabPageExt)base.List[i]).TabVisible && ((TabPageExt)base.List[i]).RectangleToScreen(((TabPageExt)base.List[i]).ClientRectangle).Contains(__TabPage.PointToScreen(new Point(x, y))))
					{
						return (TabPageExt)base.List[i];
					}
				}
				return null;
			}
		}

		// Token: 0x040004BE RID: 1214
		private TabPageExt __TabPage;

		// Token: 0x040004BF RID: 1215
		private TabControlExt __TabControl;

		// Token: 0x040004C0 RID: 1216
		private bool __IsReorder;

		// Token: 0x040004C1 RID: 1217
		private bool __EnabledToolTip;

		// Token: 0x0200009E RID: 158
		// (Invoke) Token: 0x06000967 RID: 2407
		public delegate void GetTabRegionEventHandler(object sender, TabControlExt.GetTabRegionEventArgs e);

		// Token: 0x0200009F RID: 159
		// (Invoke) Token: 0x0600096B RID: 2411
		public delegate void TabPaint__BackgroundEventHandler(object sender, TabControlExt.TabPaintEventArgs e);

		// Token: 0x020000A0 RID: 160
		// (Invoke) Token: 0x0600096F RID: 2415
		public delegate void TabPaintBorderEventHandler(object sender, TabControlExt.TabPaintEventArgs e);

		// Token: 0x020000A1 RID: 161
		// (Invoke) Token: 0x06000973 RID: 2419
		public delegate void OnVisibleChangedEventHandler(object sender, bool b);
	}

	// Token: 0x020000A2 RID: 162
	[Description("Gets or sets the specified alignment for the control.")]
	public enum TabAlignment : byte
	{
		// Token: 0x040004C7 RID: 1223
		Top,
		// Token: 0x040004C8 RID: 1224
		Bottom
	}

	// Token: 0x020000A3 RID: 163
	[Description("Gets or sets the specified direction for the control.")]
	public enum FlowDirection : byte
	{
		// Token: 0x040004CA RID: 1226
		LeftToRight,
		// Token: 0x040004CB RID: 1227
		RightToLeft = 2
	}

	// Token: 0x020000A4 RID: 164
	public enum Weight : byte
	{
		// Token: 0x040004CD RID: 1229
		Soft = 2,
		// Token: 0x040004CE RID: 1230
		Medium,
		// Token: 0x040004CF RID: 1231
		Strong,
		// Token: 0x040004D0 RID: 1232
		Strongest
	}

	// Token: 0x020000A5 RID: 165
	// (Invoke) Token: 0x06000977 RID: 2423
	public delegate void GetTabRegionEventHandler(object sender, TabControlExt.GetTabRegionEventArgs e);

	// Token: 0x020000A6 RID: 166
	// (Invoke) Token: 0x0600097B RID: 2427
	public delegate void TabPaintBackgroundEventHandler(object sender, TabControlExt.TabPaintEventArgs e);

	// Token: 0x020000A7 RID: 167
	// (Invoke) Token: 0x0600097F RID: 2431
	public delegate void TabPaintBorderEventHandler(object sender, TabControlExt.TabPaintEventArgs e);

	// Token: 0x020000A8 RID: 168
	// (Invoke) Token: 0x06000983 RID: 2435
	public delegate void TabSelectedFormEventHandler(object sender, object e);
}
