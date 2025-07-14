using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x020000AB RID: 171
[DesignerGenerated]
[DesignTimeVisible(false)]
[Description("Represents a single tab page in a MdiTabControl.TabControl.")]
public class TabPageExt : Control
{
	// Token: 0x0600099E RID: 2462 RVA: 0x0003D6A0 File Offset: 0x0003B8A0
	public TabPageExt(object o, string sText = "", Bitmap icon = null)
	{
		base.MouseDown += this.Tab_MouseDown;
		base.MouseEnter += this.Tab_MouseEnter;
		base.MouseLeave += this.Tab_MouseLeave;
		base.MouseMove += this.Tab_MouseMove;
		this.__Selected = false;
		this.__Hot = false;
		this.MenuItem = new ToolStripMenuItem();
		this.__MouseOverCloseButton = false;
		this.InitializeComponent();
		base.SuspendLayout();
		base.SetStyle(ControlStyles.DoubleBuffer, true);
		base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		base.SetStyle(ControlStyles.UserPaint, true);
		base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		base.BackColor = Color.Transparent;
		base.Visible = false;
		base.Size = new Size(1, 1);
		Form form;
		if (o is Form)
		{
			form = (Form)o;
		}
		else
		{
			if (!(o is Panel))
			{
				throw new Exception("Tab Add Form Error: " + Versioned.TypeName(RuntimeHelpers.GetObjectValue(o)));
			}
			form = new Form();
			form.Name = Conversions.ToString(NewLateBinding.LateGet(o, null, "Name", new object[0], null, null, null));
			form.Text = sText;
			if (icon != null)
			{
				this.__Icon = this.IconFromImage(icon);
			}
			form.Icon = this.__Icon;
			Panel panel = new Panel();
			panel.Height = 2;
			form.Controls.Add(panel);
			form.Controls.Add((Control)o);
			NewLateBinding.LateSet(o, null, "Dock", new object[]
			{
				DockStyle.Fill
			}, null, null);
			NewLateBinding.LateSet(o, null, "Visible", new object[]
			{
				true
			}, null, null);
			panel.Dock = DockStyle.Top;
			panel.SendToBack();
		}
		form.TopLevel = false;
		form.MdiParent = null;
		form.FormBorderStyle = FormBorderStyle.None;
		form.Dock = DockStyle.Fill;
		form.Show();
		this.__Form = form;
		this.MenuItem.Text = form.Text;
		this.MenuItem.Image = form.Icon.ToBitmap();
		this.MenuItem.Tag = this;
		this.MenuItem.Image = null;
		base.ResumeLayout(false);
	}

	// Token: 0x0600099F RID: 2463 RVA: 0x0000610A File Offset: 0x0000430A
	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.components != null)
		{
			this.components.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x060009A0 RID: 2464 RVA: 0x0003D8E0 File Offset: 0x0003BAE0
	[DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TabPageExt));
		this.imgAnimate = new ImageList(this.components);
		this.tmrAnimate = new System.Windows.Forms.Timer(this.components);
		base.SuspendLayout();
		this.imgAnimate.ImageStream = (ImageListStreamer)componentResourceManager.GetObject("imgAnimate.ImageStream");
		this.imgAnimate.TransparentColor = Color.Transparent;
		this.imgAnimate.Images.SetKeyName(0, "1.ico");
		this.imgAnimate.Images.SetKeyName(1, "2.ico");
		this.imgAnimate.Images.SetKeyName(2, "3.ico");
		this.imgAnimate.Images.SetKeyName(3, "4.ico");
		this.imgAnimate.Images.SetKeyName(4, "5.ico");
		this.imgAnimate.Images.SetKeyName(5, "6.ico");
		this.imgAnimate.Images.SetKeyName(6, "7.ico");
		this.imgAnimate.Images.SetKeyName(7, "8.ico");
		this.tmrAnimate.Interval = 500;
		base.ResumeLayout(false);
	}

	// Token: 0x170002EB RID: 747
	// (get) Token: 0x060009A1 RID: 2465 RVA: 0x0000612F File Offset: 0x0000432F
	// (set) Token: 0x060009A2 RID: 2466 RVA: 0x00006137 File Offset: 0x00004337
	internal virtual ImageList imgAnimate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x170002EC RID: 748
	// (get) Token: 0x060009A3 RID: 2467 RVA: 0x00006140 File Offset: 0x00004340
	// (set) Token: 0x060009A4 RID: 2468 RVA: 0x0003DA24 File Offset: 0x0003BC24
	internal virtual System.Windows.Forms.Timer tmrAnimate
	{
		[CompilerGenerated]
		get
		{
			return this._tmrAnimate;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.tmrAnimate_Tick);
			System.Windows.Forms.Timer tmrAnimate = this._tmrAnimate;
			if (tmrAnimate != null)
			{
				tmrAnimate.Tick -= value2;
			}
			this._tmrAnimate = value;
			tmrAnimate = this._tmrAnimate;
			if (tmrAnimate != null)
			{
				tmrAnimate.Tick += value2;
			}
		}
	}

	// Token: 0x170002ED RID: 749
	// (get) Token: 0x060009A5 RID: 2469 RVA: 0x00006148 File Offset: 0x00004348
	// (set) Token: 0x060009A6 RID: 2470 RVA: 0x0003DA68 File Offset: 0x0003BC68
	internal virtual Form __Form
	{
		[CompilerGenerated]
		get
		{
			return this.___Form;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			FormClosedEventHandler value2 = new FormClosedEventHandler(this.TabContent_FormClosed);
			EventHandler value3 = new EventHandler(this.TabContent_TextChanged);
			Form __Form = this.___Form;
			if (__Form != null)
			{
				__Form.FormClosed -= value2;
				__Form.TextChanged -= value3;
			}
			this.___Form = value;
			__Form = this.___Form;
			if (__Form != null)
			{
				__Form.FormClosed += value2;
				__Form.TextChanged += value3;
			}
		}
	}

	// Token: 0x1400000D RID: 13
	// (add) Token: 0x060009A7 RID: 2471 RVA: 0x0003DAC8 File Offset: 0x0003BCC8
	// (remove) Token: 0x060009A8 RID: 2472 RVA: 0x0003DB00 File Offset: 0x0003BD00
	[Description("Occurs when the user clicks the Tab Control.")]
	public new event TabPageExt.ClickEventHandler Click;

	// Token: 0x1400000E RID: 14
	// (add) Token: 0x060009A9 RID: 2473 RVA: 0x0003DB38 File Offset: 0x0003BD38
	// (remove) Token: 0x060009AA RID: 2474 RVA: 0x0003DB70 File Offset: 0x0003BD70
	internal event TabPageExt.CloseEventHandler Close;

	// Token: 0x1400000F RID: 15
	// (add) Token: 0x060009AB RID: 2475 RVA: 0x0003DBA8 File Offset: 0x0003BDA8
	// (remove) Token: 0x060009AC RID: 2476 RVA: 0x0003DBE0 File Offset: 0x0003BDE0
	internal event TabPageExt.GetTabRegionEventHandler GetTabRegion;

	// Token: 0x14000010 RID: 16
	// (add) Token: 0x060009AD RID: 2477 RVA: 0x0003DC18 File Offset: 0x0003BE18
	// (remove) Token: 0x060009AE RID: 2478 RVA: 0x0003DC50 File Offset: 0x0003BE50
	internal event TabPageExt.TabPaintBackgroundEventHandler TabPaintBackground;

	// Token: 0x14000011 RID: 17
	// (add) Token: 0x060009AF RID: 2479 RVA: 0x0003DC88 File Offset: 0x0003BE88
	// (remove) Token: 0x060009B0 RID: 2480 RVA: 0x0003DCC0 File Offset: 0x0003BEC0
	internal event TabPageExt.TabPaintBorderEventHandler TabPaintBorder;

	// Token: 0x14000012 RID: 18
	// (add) Token: 0x060009B1 RID: 2481 RVA: 0x0003DCF8 File Offset: 0x0003BEF8
	// (remove) Token: 0x060009B2 RID: 2482 RVA: 0x0003DD30 File Offset: 0x0003BF30
	internal event TabPageExt.DragingEventHandler Draging;

	// Token: 0x060009B3 RID: 2483 RVA: 0x0003DD68 File Offset: 0x0003BF68
	public Icon IconFromImage(Image img)
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write(0);
		binaryWriter.Write(1);
		binaryWriter.Write(1);
		int num = img.Width;
		if (num >= 256)
		{
			num = 0;
		}
		checked
		{
			binaryWriter.Write((byte)num);
			int num2 = img.Height;
			if (num2 >= 256)
			{
				num2 = 0;
			}
			binaryWriter.Write((byte)num2);
			binaryWriter.Write(0);
			binaryWriter.Write(0);
			binaryWriter.Write(0);
			binaryWriter.Write(0);
			long position = memoryStream.Position;
			binaryWriter.Write(0);
			int num3 = (int)memoryStream.Position + 4;
			binaryWriter.Write(num3);
			img.Save(memoryStream, ImageFormat.Png);
			int value = (int)memoryStream.Position - num3;
			memoryStream.Seek(position, SeekOrigin.Begin);
			binaryWriter.Write(value);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			return new Icon(memoryStream);
		}
	}

	// Token: 0x170002EE RID: 750
	// (get) Token: 0x060009B4 RID: 2484 RVA: 0x0003DE50 File Offset: 0x0003C050
	[Description("Gets the form associated with the tab page")]
	public Form Form
	{
		get
		{
			return this.__Form;
		}
	}

	// Token: 0x170002EF RID: 751
	// (get) Token: 0x060009B5 RID: 2485 RVA: 0x0003DE68 File Offset: 0x0003C068
	// (set) Token: 0x060009B6 RID: 2486 RVA: 0x00006150 File Offset: 0x00004350
	[Description("Gets or sets the System.Drawing.Color structure that represents the starting color of the Background linear gradient for the tab.")]
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

	// Token: 0x170002F0 RID: 752
	// (get) Token: 0x060009B7 RID: 2487 RVA: 0x0003DE80 File Offset: 0x0003C080
	// (set) Token: 0x060009B8 RID: 2488 RVA: 0x0000615F File Offset: 0x0000435F
	[Description("Gets or sets the System.Drawing.Color structure that represents the ending color of the Background linear gradient for the tab.")]
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

	// Token: 0x170002F1 RID: 753
	// (get) Token: 0x060009B9 RID: 2489 RVA: 0x0003DE98 File Offset: 0x0003C098
	// (set) Token: 0x060009BA RID: 2490 RVA: 0x0000616E File Offset: 0x0000436E
	[Description("Gets or sets the System.Drawing.Color structure that represents the border color.")]
	internal Color BorderColor
	{
		get
		{
			return this.__BorderColor;
		}
		set
		{
			this.__BorderColor = value;
			base.Invalidate();
		}
	}

	// Token: 0x170002F2 RID: 754
	// (get) Token: 0x060009BB RID: 2491 RVA: 0x0003DEB0 File Offset: 0x0003C0B0
	// (set) Token: 0x060009BC RID: 2492 RVA: 0x0000617D File Offset: 0x0000437D
	[Description("Gets or sets the System.Drawing.Color structure that represents the starting color of the Background linear gradient for a non selected tab.")]
	public Color BackHighColorDisabled
	{
		get
		{
			return this.__BackHighColorDisabled;
		}
		set
		{
			this.__BackHighColorDisabled = value;
			base.Invalidate();
		}
	}

	// Token: 0x170002F3 RID: 755
	// (get) Token: 0x060009BD RID: 2493 RVA: 0x0003DEC8 File Offset: 0x0003C0C8
	// (set) Token: 0x060009BE RID: 2494 RVA: 0x0000618C File Offset: 0x0000438C
	[Description("Gets or sets the System.Drawing.Color structure that represents the ending color of the Background linear gradient for a non selected tab.")]
	public Color BackLowColorDisabled
	{
		get
		{
			return this.__BackLowColorDisabled;
		}
		set
		{
			this.__BackLowColorDisabled = value;
			base.Invalidate();
		}
	}

	// Token: 0x170002F4 RID: 756
	// (get) Token: 0x060009BF RID: 2495 RVA: 0x0003DEE0 File Offset: 0x0003C0E0
	// (set) Token: 0x060009C0 RID: 2496 RVA: 0x0000619B File Offset: 0x0000439B
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
			base.Invalidate();
		}
	}

	// Token: 0x170002F5 RID: 757
	// (get) Token: 0x060009C1 RID: 2497 RVA: 0x0003DEF8 File Offset: 0x0003C0F8
	// (set) Token: 0x060009C2 RID: 2498 RVA: 0x000061AA File Offset: 0x000043AA
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
			base.Invalidate();
		}
	}

	// Token: 0x170002F6 RID: 758
	// (get) Token: 0x060009C3 RID: 2499 RVA: 0x000061B9 File Offset: 0x000043B9
	// (set) Token: 0x060009C4 RID: 2500 RVA: 0x000061C1 File Offset: 0x000043C1
	internal bool IsSelected
	{
		get
		{
			return this.__Selected;
		}
		set
		{
			if (this.__Selected != value)
			{
				this.__Selected = value;
				if (this.__Selected)
				{
					this.__Hot = false;
				}
				base.Invalidate();
			}
		}
	}

	// Token: 0x170002F7 RID: 759
	// (get) Token: 0x060009C5 RID: 2501 RVA: 0x000061ED File Offset: 0x000043ED
	[Description("Returns whether the tab is selected or not.")]
	public bool Selected
	{
		get
		{
			return this.IsSelected;
		}
	}

	// Token: 0x170002F8 RID: 760
	// (get) Token: 0x060009C6 RID: 2502 RVA: 0x0003DF10 File Offset: 0x0003C110
	// (set) Token: 0x060009C7 RID: 2503 RVA: 0x000061F5 File Offset: 0x000043F5
	internal int MaximumWidth
	{
		get
		{
			return this.__MaximumWidth;
		}
		set
		{
			this.__MaximumWidth = value;
			this.CalculateWidth();
			base.Invalidate();
		}
	}

	// Token: 0x170002F9 RID: 761
	// (get) Token: 0x060009C8 RID: 2504 RVA: 0x0003DF28 File Offset: 0x0003C128
	// (set) Token: 0x060009C9 RID: 2505 RVA: 0x0000620A File Offset: 0x0000440A
	internal int MinimumWidth
	{
		get
		{
			return this.__MinimumWidth;
		}
		set
		{
			this.__MinimumWidth = value;
			this.CalculateWidth();
			base.Invalidate();
		}
	}

	// Token: 0x170002FA RID: 762
	// (get) Token: 0x060009CA RID: 2506 RVA: 0x0003DF40 File Offset: 0x0003C140
	// (set) Token: 0x060009CB RID: 2507 RVA: 0x0000621F File Offset: 0x0000441F
	internal int PadLeft
	{
		get
		{
			return this.__PadLeft;
		}
		set
		{
			this.__PadLeft = value;
			this.CalculateWidth();
			base.Invalidate();
		}
	}

	// Token: 0x170002FB RID: 763
	// (get) Token: 0x060009CC RID: 2508 RVA: 0x0003DF58 File Offset: 0x0003C158
	// (set) Token: 0x060009CD RID: 2509 RVA: 0x00006234 File Offset: 0x00004434
	internal int PadRight
	{
		get
		{
			return this.__PadRight;
		}
		set
		{
			this.__PadRight = value;
			this.CalculateWidth();
			base.Invalidate();
		}
	}

	// Token: 0x170002FC RID: 764
	// (get) Token: 0x060009CE RID: 2510 RVA: 0x00006249 File Offset: 0x00004449
	// (set) Token: 0x060009CF RID: 2511 RVA: 0x00006251 File Offset: 0x00004451
	[Description("Gets or sets whether the tab close button is visble or not.")]
	public bool CloseButtonVisible
	{
		get
		{
			return this.__CloseButtonVisible;
		}
		set
		{
			value = false;
			if (this.__CloseButtonVisible != value)
			{
				this.__CloseButtonVisible = value;
				this.CalculateWidth();
				base.Invalidate();
			}
		}
	}

	// Token: 0x170002FD RID: 765
	// (get) Token: 0x060009D0 RID: 2512 RVA: 0x0003DF70 File Offset: 0x0003C170
	// (set) Token: 0x060009D1 RID: 2513 RVA: 0x00006279 File Offset: 0x00004479
	public Image CloseButtonImage
	{
		get
		{
			return this.__CloseButton;
		}
		set
		{
			this.__CloseButton = value;
			base.Invalidate();
		}
	}

	// Token: 0x170002FE RID: 766
	// (get) Token: 0x060009D2 RID: 2514 RVA: 0x0003DF88 File Offset: 0x0003C188
	// (set) Token: 0x060009D3 RID: 2515 RVA: 0x00006288 File Offset: 0x00004488
	public Image CloseButtonImageHot
	{
		get
		{
			return this.__CloseButtonImageHot;
		}
		set
		{
			this.__CloseButtonImageHot = value;
			base.Invalidate();
		}
	}

	// Token: 0x170002FF RID: 767
	// (get) Token: 0x060009D4 RID: 2516 RVA: 0x0003DFA0 File Offset: 0x0003C1A0
	// (set) Token: 0x060009D5 RID: 2517 RVA: 0x00006297 File Offset: 0x00004497
	public Image CloseButtonImageDisabled
	{
		get
		{
			return this.__CloseButtonImageDisabled;
		}
		set
		{
			this.__CloseButtonImageDisabled = value;
			base.Invalidate();
		}
	}

	// Token: 0x17000300 RID: 768
	// (get) Token: 0x060009D6 RID: 2518 RVA: 0x0003DFB8 File Offset: 0x0003C1B8
	// (set) Token: 0x060009D7 RID: 2519 RVA: 0x000062A6 File Offset: 0x000044A6
	public Color CloseButtonBackHighColor
	{
		get
		{
			return this.__CloseButtonBackHighColor;
		}
		set
		{
			this.__CloseButtonBackHighColor = value;
		}
	}

	// Token: 0x17000301 RID: 769
	// (get) Token: 0x060009D8 RID: 2520 RVA: 0x0003DFD0 File Offset: 0x0003C1D0
	// (set) Token: 0x060009D9 RID: 2521 RVA: 0x000062AF File Offset: 0x000044AF
	public Color CloseButtonBackLowColor
	{
		get
		{
			return this.__CloseButtonBackLowColor;
		}
		set
		{
			this.__CloseButtonBackLowColor = value;
		}
	}

	// Token: 0x17000302 RID: 770
	// (get) Token: 0x060009DA RID: 2522 RVA: 0x0003DFE8 File Offset: 0x0003C1E8
	// (set) Token: 0x060009DB RID: 2523 RVA: 0x000062B8 File Offset: 0x000044B8
	public Color CloseButtonBorderColor
	{
		get
		{
			return this.__CloseButtonBorderColor;
		}
		set
		{
			this.__CloseButtonBorderColor = value;
		}
	}

	// Token: 0x17000303 RID: 771
	// (get) Token: 0x060009DC RID: 2524 RVA: 0x0003E000 File Offset: 0x0003C200
	// (set) Token: 0x060009DD RID: 2525 RVA: 0x000062C1 File Offset: 0x000044C1
	public Color CloseButtonForeColor
	{
		get
		{
			return this.__CloseButtonForeColor;
		}
		set
		{
			this.__CloseButtonForeColor = value;
		}
	}

	// Token: 0x17000304 RID: 772
	// (get) Token: 0x060009DE RID: 2526 RVA: 0x0003E018 File Offset: 0x0003C218
	// (set) Token: 0x060009DF RID: 2527 RVA: 0x000062CA File Offset: 0x000044CA
	public Color CloseButtonBackHighColorDisabled
	{
		get
		{
			return this.__CloseButtonBackHighColorDisabled;
		}
		set
		{
			this.__CloseButtonBackHighColorDisabled = value;
		}
	}

	// Token: 0x17000305 RID: 773
	// (get) Token: 0x060009E0 RID: 2528 RVA: 0x0003E030 File Offset: 0x0003C230
	// (set) Token: 0x060009E1 RID: 2529 RVA: 0x000062D3 File Offset: 0x000044D3
	public Color CloseButtonBackLowColorDisabled
	{
		get
		{
			return this.__CloseButtonBackLowColorDisabled;
		}
		set
		{
			this.__CloseButtonBackLowColorDisabled = value;
		}
	}

	// Token: 0x17000306 RID: 774
	// (get) Token: 0x060009E2 RID: 2530 RVA: 0x0003E048 File Offset: 0x0003C248
	// (set) Token: 0x060009E3 RID: 2531 RVA: 0x000062DC File Offset: 0x000044DC
	public Color CloseButtonBorderColorDisabled
	{
		get
		{
			return this.__CloseButtonBorderColorDisabled;
		}
		set
		{
			this.__CloseButtonBorderColorDisabled = value;
		}
	}

	// Token: 0x17000307 RID: 775
	// (get) Token: 0x060009E4 RID: 2532 RVA: 0x0003E060 File Offset: 0x0003C260
	// (set) Token: 0x060009E5 RID: 2533 RVA: 0x000062E5 File Offset: 0x000044E5
	public Color CloseButtonForeColorDisabled
	{
		get
		{
			return this.__CloseButtonForeColorDisabled;
		}
		set
		{
			this.__CloseButtonForeColorDisabled = value;
		}
	}

	// Token: 0x17000308 RID: 776
	// (get) Token: 0x060009E6 RID: 2534 RVA: 0x0003E078 File Offset: 0x0003C278
	// (set) Token: 0x060009E7 RID: 2535 RVA: 0x000062EE File Offset: 0x000044EE
	public Color CloseButtonBackHighColorHot
	{
		get
		{
			return this.__CloseButtonBackHighColorHot;
		}
		set
		{
			this.__CloseButtonBackHighColorHot = value;
		}
	}

	// Token: 0x17000309 RID: 777
	// (get) Token: 0x060009E8 RID: 2536 RVA: 0x0003E090 File Offset: 0x0003C290
	// (set) Token: 0x060009E9 RID: 2537 RVA: 0x000062F7 File Offset: 0x000044F7
	public Color CloseButtonBackLowColorHot
	{
		get
		{
			return this.__CloseButtonBackLowColorHot;
		}
		set
		{
			this.__CloseButtonBackLowColorHot = value;
		}
	}

	// Token: 0x1700030A RID: 778
	// (get) Token: 0x060009EA RID: 2538 RVA: 0x0003E0A8 File Offset: 0x0003C2A8
	// (set) Token: 0x060009EB RID: 2539 RVA: 0x00006300 File Offset: 0x00004500
	public Color CloseButtonBorderColorHot
	{
		get
		{
			return this.__CloseButtonBorderColorHot;
		}
		set
		{
			this.__CloseButtonBorderColorHot = value;
		}
	}

	// Token: 0x1700030B RID: 779
	// (get) Token: 0x060009EC RID: 2540 RVA: 0x0003E0C0 File Offset: 0x0003C2C0
	// (set) Token: 0x060009ED RID: 2541 RVA: 0x00006309 File Offset: 0x00004509
	public Color CloseButtonForeColorHot
	{
		get
		{
			return this.__CloseButtonForeColorHot;
		}
		set
		{
			this.__CloseButtonForeColorHot = value;
		}
	}

	// Token: 0x1700030C RID: 780
	// (get) Token: 0x060009EE RID: 2542 RVA: 0x00006312 File Offset: 0x00004512
	// (set) Token: 0x060009EF RID: 2543 RVA: 0x0000631A File Offset: 0x0000451A
	internal bool HotTrack
	{
		get
		{
			return this.__HotTrack;
		}
		set
		{
			this.__HotTrack = value;
			base.Invalidate();
		}
	}

	// Token: 0x1700030D RID: 781
	// (get) Token: 0x060009F0 RID: 2544 RVA: 0x0003E0D8 File Offset: 0x0003C2D8
	// (set) Token: 0x060009F1 RID: 2545 RVA: 0x00006329 File Offset: 0x00004529
	internal Size CloseButtonSize
	{
		get
		{
			return this.__CloseButtonSize;
		}
		set
		{
			this.__CloseButtonSize = value;
			this.CalculateWidth();
			base.Invalidate();
		}
	}

	// Token: 0x1700030E RID: 782
	// (get) Token: 0x060009F2 RID: 2546 RVA: 0x0000633E File Offset: 0x0000453E
	// (set) Token: 0x060009F3 RID: 2547 RVA: 0x00006346 File Offset: 0x00004546
	internal bool FontBoldOnSelect
	{
		get
		{
			return this.__FontBoldOnSelect;
		}
		set
		{
			this.__FontBoldOnSelect = value;
			this.CalculateWidth();
			base.Invalidate();
		}
	}

	// Token: 0x1700030F RID: 783
	// (get) Token: 0x060009F4 RID: 2548 RVA: 0x0003E0F0 File Offset: 0x0003C2F0
	// (set) Token: 0x060009F5 RID: 2549 RVA: 0x0000635B File Offset: 0x0000455B
	internal Size IconSize
	{
		get
		{
			return this.__IconSize;
		}
		set
		{
			this.__IconSize = value;
			this.CalculateWidth();
			base.Invalidate();
		}
	}

	// Token: 0x17000310 RID: 784
	// (get) Token: 0x060009F6 RID: 2550 RVA: 0x0003E108 File Offset: 0x0003C308
	// (set) Token: 0x060009F7 RID: 2551 RVA: 0x00006370 File Offset: 0x00004570
	internal SmoothingMode SmoothingMode
	{
		get
		{
			return this.__SmoothingMode;
		}
		set
		{
			this.__SmoothingMode = value;
			base.Invalidate();
		}
	}

	// Token: 0x17000311 RID: 785
	// (get) Token: 0x060009F8 RID: 2552 RVA: 0x0003E120 File Offset: 0x0003C320
	// (set) Token: 0x060009F9 RID: 2553 RVA: 0x0000637F File Offset: 0x0000457F
	internal TabControlExt.TabAlignment Alignment
	{
		get
		{
			return this.__Alignment;
		}
		set
		{
			this.__Alignment = value;
			base.Invalidate();
		}
	}

	// Token: 0x17000312 RID: 786
	// (get) Token: 0x060009FA RID: 2554 RVA: 0x0000638E File Offset: 0x0000458E
	// (set) Token: 0x060009FB RID: 2555 RVA: 0x00006396 File Offset: 0x00004596
	internal bool GlassGradient
	{
		get
		{
			return this.__GlassGradient;
		}
		set
		{
			this.__GlassGradient = value;
		}
	}

	// Token: 0x17000313 RID: 787
	// (get) Token: 0x060009FC RID: 2556 RVA: 0x0000639F File Offset: 0x0000459F
	// (set) Token: 0x060009FD RID: 2557 RVA: 0x000063A7 File Offset: 0x000045A7
	internal bool BorderEnhanced
	{
		get
		{
			return this.__BorderEnhanced;
		}
		set
		{
			this.__BorderEnhanced = value;
		}
	}

	// Token: 0x17000314 RID: 788
	// (get) Token: 0x060009FE RID: 2558 RVA: 0x0003E138 File Offset: 0x0003C338
	// (set) Token: 0x060009FF RID: 2559 RVA: 0x000063B0 File Offset: 0x000045B0
	internal ToolStripRenderMode RenderMode
	{
		get
		{
			return this.__RenderMode;
		}
		set
		{
			this.__RenderMode = value;
			base.Invalidate();
		}
	}

	// Token: 0x17000315 RID: 789
	// (get) Token: 0x06000A00 RID: 2560 RVA: 0x0003E150 File Offset: 0x0003C350
	// (set) Token: 0x06000A01 RID: 2561 RVA: 0x000063BF File Offset: 0x000045BF
	internal TabControlExt.Weight BorderEnhanceWeight
	{
		get
		{
			return this.__BorderEnhanceWeight;
		}
		set
		{
			this.__BorderEnhanceWeight = value;
		}
	}

	// Token: 0x17000316 RID: 790
	// (get) Token: 0x06000A02 RID: 2562 RVA: 0x0003E168 File Offset: 0x0003C368
	// (set) Token: 0x06000A03 RID: 2563 RVA: 0x0003E184 File Offset: 0x0003C384
	public Icon Icon
	{
		get
		{
			return this.__Form.Icon;
		}
		set
		{
			if (value != null)
			{
				this.__Form.Icon = value;
				if (this.IconVisible)
				{
					Region region = new Region(new Rectangle(this.PadLeft, checked((int)Math.Round(unchecked((double)base.Height / 2.0 - (double)this.__IconSize.Height / 2.0))), this.__IconSize.Width, this.__IconSize.Height));
					base.Invalidate(region);
					region.Dispose();
					this.MenuItem.Image = value.ToBitmap();
				}
			}
			else
			{
				this.MenuItem.Image = null;
				this.__Form.Icon = null;
			}
		}
	}

	// Token: 0x17000317 RID: 791
	// (get) Token: 0x06000A04 RID: 2564 RVA: 0x000063C8 File Offset: 0x000045C8
	// (set) Token: 0x06000A05 RID: 2565 RVA: 0x0003E240 File Offset: 0x0003C440
	public bool IconVisible
	{
		get
		{
			return this.__IconVisible;
		}
		set
		{
			this.__IconVisible = value;
			if (!value)
			{
				using (Icon icon = new Icon(this.__Form.Icon, this.__IconSize))
				{
					TabPageExt.DestroyIcon(icon.Handle);
				}
			}
			this.Icon = this.__Form.Icon;
			base.Invalidate();
		}
	}

	// Token: 0x17000318 RID: 792
	// (get) Token: 0x06000A06 RID: 2566 RVA: 0x000063D0 File Offset: 0x000045D0
	// (set) Token: 0x06000A07 RID: 2567 RVA: 0x000063D8 File Offset: 0x000045D8
	public bool ConfirmeClose
	{
		get
		{
			return this.__ConfirmeClose;
		}
		set
		{
			this.__ConfirmeClose = value;
		}
	}

	// Token: 0x06000A08 RID: 2568 RVA: 0x0003E2B0 File Offset: 0x0003C4B0
	[Description("Selects the TabPage.")]
	public new void Select()
	{
		if (!this.IsSelected)
		{
			TabPageExt.ClickEventHandler clickEvent = this.ClickEvent;
			if (clickEvent != null)
			{
				clickEvent(this, new EventArgs());
			}
		}
	}

	// Token: 0x06000A09 RID: 2569 RVA: 0x0003E2E0 File Offset: 0x0003C4E0
	private LinearGradientBrush CreateGradientBrush(Rectangle Rectangle, Color Color1, Color Color2)
	{
		LinearGradientBrush result;
		if (this.__GlassGradient)
		{
			result = Helper.CreateGlassGradientBrush(Rectangle, Color1, Color2);
		}
		else
		{
			result = new LinearGradientBrush(Rectangle, Color1, Color2, LinearGradientMode.Vertical);
		}
		return result;
	}

	// Token: 0x06000A0A RID: 2570 RVA: 0x0003E30C File Offset: 0x0003C50C
	private void TabContent_FormClosed(object sender, FormClosedEventArgs e)
	{
		TabPageExt.CloseEventHandler closeEvent = this.CloseEvent;
		if (closeEvent != null)
		{
			closeEvent(this, new EventArgs());
		}
	}

	// Token: 0x06000A0B RID: 2571 RVA: 0x000063E1 File Offset: 0x000045E1
	private void TabContent_TextChanged(object sender, EventArgs e)
	{
		this.CalculateWidth();
		base.Invalidate();
		this.MenuItem.Text = this.__Form.Text;
	}

	// Token: 0x06000A0C RID: 2572 RVA: 0x0003E330 File Offset: 0x0003C530
	private void Tab_MouseDown(object sender, MouseEventArgs e)
	{
		if (!(this.__Selected & !(this.__MouseOverCloseButton & this.__CloseButtonVisible)) && e.Button == MouseButtons.Left)
		{
			if (this.__MouseOverCloseButton & this.__CloseButtonVisible)
			{
				this.__Form.Close();
			}
			else
			{
				this.Select();
			}
		}
	}

	// Token: 0x06000A0D RID: 2573 RVA: 0x00006405 File Offset: 0x00004605
	private void Tab_MouseEnter(object sender, EventArgs e)
	{
		if (!this.__Selected)
		{
			if (this.__HotTrack)
			{
				this.__Hot = true;
			}
			base.Invalidate();
		}
	}

	// Token: 0x06000A0E RID: 2574 RVA: 0x00006424 File Offset: 0x00004624
	private void Tab_MouseLeave(object sender, EventArgs e)
	{
		this.__MouseOverCloseButton = false;
		this.__Hot = false;
		base.Invalidate();
	}

	// Token: 0x06000A0F RID: 2575 RVA: 0x0003E388 File Offset: 0x0003C588
	private void Tab_MouseMove(object sender, MouseEventArgs e)
	{
		if (this.$STATIC$Tab_MouseMove$20211C128381$State$Init == null)
		{
			Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$Tab_MouseMove$20211C128381$State$Init, new StaticLocalInitFlag(), null);
		}
		bool flag = false;
		try
		{
			Monitor.Enter(this.$STATIC$Tab_MouseMove$20211C128381$State$Init, ref flag);
			if (this.$STATIC$Tab_MouseMove$20211C128381$State$Init.State == 0)
			{
				this.$STATIC$Tab_MouseMove$20211C128381$State$Init.State = 2;
				this.$STATIC$Tab_MouseMove$20211C128381$State = false;
			}
			else if (this.$STATIC$Tab_MouseMove$20211C128381$State$Init.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			this.$STATIC$Tab_MouseMove$20211C128381$State$Init.State = 1;
			if (flag)
			{
				Monitor.Exit(this.$STATIC$Tab_MouseMove$20211C128381$State$Init);
			}
		}
		checked
		{
			if (this.__CloseButtonVisible)
			{
				int num = base.Width - this.PadRight - this.__CloseButtonSize.Width - 2;
				int num2 = (int)Math.Round(unchecked((double)base.Height / 2.0 - (double)this.__CloseButtonSize.Height / 2.0));
				this.__MouseOverCloseButton = (e.X >= num & e.X <= num + this.__CloseButtonSize.Width - 1 & e.Y >= num2 & e.Y <= num2 + this.__CloseButtonSize.Height - 1);
				if (this.$STATIC$Tab_MouseMove$20211C128381$State != this.__MouseOverCloseButton & this.__CloseButtonVisible)
				{
					this.$STATIC$Tab_MouseMove$20211C128381$State = this.__MouseOverCloseButton;
					Region region = new Region(new Rectangle(num, num2, this.__CloseButtonSize.Width, this.__CloseButtonSize.Height));
					base.Invalidate(region);
					region.Dispose();
				}
			}
			if (base.RectangleToScreen(base.ClientRectangle).Contains(base.PointToScreen(new Point(e.X, e.Y))))
			{
				this.Cursor = Cursors.Default;
			}
			else
			{
				TabPageExt.DragingEventHandler dragingEvent = this.DragingEvent;
				if (dragingEvent != null)
				{
					dragingEvent(this, e);
				}
			}
		}
	}

	// Token: 0x06000A10 RID: 2576 RVA: 0x0003E574 File Offset: 0x0003C774
	private void DrawText(Graphics g)
	{
		Font font = new Font(this.Font, (FontStyle)Conversions.ToInteger(Interaction.IIf(this.__Selected & this.__FontBoldOnSelect, FontStyle.Bold, FontStyle.Regular)));
		object obj = Interaction.IIf(this.__Selected | this.__Hot, this.ForeColor, this.__ForeColorDisabled);
		Brush brush = new SolidBrush((obj != null) ? ((Color)obj) : default(Color));
		RectangleF layoutRectangle = new RectangleF(Conversions.ToSingle(Operators.AddObject(Operators.AddObject(this.PadLeft, Interaction.IIf(this.__Form.Icon == null, 0, this.__IconSize.Width)), 2)), 1f, Conversions.ToSingle(Operators.SubtractObject(Operators.SubtractObject(Operators.SubtractObject(Operators.SubtractObject(checked(base.Width - this.PadLeft), Interaction.IIf(this.__Form.Icon == null, 0, this.__IconSize.Height)), 5), Interaction.IIf(this.__CloseButtonVisible, this.__CloseButtonSize.Width, 0)), this.PadRight)), (float)this.DisplayRectangle.Height);
		StringFormat stringFormat = new StringFormat();
		stringFormat.FormatFlags = StringFormatFlags.NoWrap;
		stringFormat.LineAlignment = StringAlignment.Center;
		stringFormat.Trimming = StringTrimming.EllipsisCharacter;
		g.DrawString(this.__Form.Text, font, brush, layoutRectangle, stringFormat);
		stringFormat.Dispose();
		brush.Dispose();
		font.Dispose();
	}

	// Token: 0x06000A11 RID: 2577 RVA: 0x0003E72C File Offset: 0x0003C92C
	private void DrawIcon(Graphics g)
	{
		try
		{
			if (this.__IconVisible)
			{
				if (this.__Form.Icon != null)
				{
					Rectangle targetRect = new Rectangle(this.PadLeft, checked((int)Math.Round(unchecked((double)base.Height / 2.0 - (double)this.__IconSize.Height / 2.0))), this.__IconSize.Width, this.__IconSize.Height);
					Icon icon = new Icon(this.__Form.Icon, this.__IconSize);
					g.DrawIcon(icon, targetRect);
					TabPageExt.DestroyIcon(icon.Handle);
					icon.Dispose();
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000A12 RID: 2578
	[DllImport("user32.dll")]
	private static extern bool DestroyIcon(IntPtr handle);

	// Token: 0x06000A13 RID: 2579 RVA: 0x0003E804 File Offset: 0x0003CA04
	private void DrawCloseButton(Graphics g)
	{
		checked
		{
			try
			{
				int x = base.Width - (this.__CloseButtonSize.Width + this.PadRight + 2);
				int y = (int)Math.Round(unchecked((double)base.Height / 2.0 - (double)this.__CloseButtonSize.Height / 2.0));
				Bitmap bitmap;
				if (this.__MouseOverCloseButton)
				{
					bitmap = (Bitmap)this.__CloseButtonImageHot;
				}
				else if (this.__Selected)
				{
					bitmap = (Bitmap)this.__CloseButton;
				}
				else
				{
					bitmap = (Bitmap)this.__CloseButtonImageDisabled;
				}
				bool flag = false;
				if (bitmap == null)
				{
					bitmap = this.GetButton();
					flag = true;
				}
				Icon icon = Icon.FromHandle(bitmap.GetHicon());
				Rectangle targetRect = new Rectangle(x, y, this.__CloseButtonSize.Width, this.__CloseButtonSize.Height);
				g.DrawIcon(icon, targetRect);
				if (flag)
				{
					bitmap.Dispose();
				}
				TabPageExt.DestroyIcon(icon.Handle);
				icon.Dispose();
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x06000A14 RID: 2580 RVA: 0x0003E920 File Offset: 0x0003CB20
	private Bitmap GetButton()
	{
		Point[] points = new Point[]
		{
			new Point(1, 0),
			new Point(3, 0),
			new Point(5, 2),
			new Point(7, 0),
			new Point(9, 0),
			new Point(6, 3),
			new Point(6, 4),
			new Point(9, 7),
			new Point(7, 7),
			new Point(5, 5),
			new Point(3, 7),
			new Point(1, 7),
			new Point(4, 4),
			new Point(4, 3)
		};
		GraphicsPath graphicsPath = new GraphicsPath();
		Matrix matrix = new Matrix();
		Point[] points2 = new Point[]
		{
			new Point(0, 1),
			new Point(1, 0),
			new Point(15, 0),
			new Point(16, 1),
			new Point(16, 14),
			new Point(15, 15),
			new Point(1, 15),
			new Point(0, 14)
		};
		Color color;
		Color color2;
		Color color3;
		Color color4;
		if (this.__MouseOverCloseButton)
		{
			color = Helper.RenderColors.TabCloseButtonBackHighColorHot(this.__RenderMode, this.CloseButtonBackHighColorHot);
			color2 = Helper.RenderColors.TabCloseButtonBackLowColorHot(this.__RenderMode, this.CloseButtonBackLowColorHot);
			color3 = Helper.RenderColors.TabCloseButtonBorderColorHot(this.__RenderMode, this.CloseButtonBorderColorHot);
			color4 = Helper.RenderColors.TabCloseButtonForeColorHot(this.__RenderMode, this.CloseButtonForeColorHot);
		}
		else if (this.__Selected)
		{
			color = Helper.RenderColors.TabCloseButtonBackHighColor(this.__RenderMode, this.CloseButtonBackHighColor);
			color2 = Helper.RenderColors.TabCloseButtonBackLowColor(this.__RenderMode, this.CloseButtonBackLowColor);
			color3 = Helper.RenderColors.TabCloseButtonBorderColor(this.__RenderMode, this.CloseButtonBorderColor);
			color4 = Helper.RenderColors.TabCloseButtonForeColor(this.__RenderMode, this.CloseButtonForeColor);
		}
		else
		{
			color = Helper.RenderColors.TabCloseButtonBackHighColorDisabled(this.__RenderMode, this.CloseButtonBackHighColorDisabled);
			color2 = Helper.RenderColors.TabCloseButtonBackLowColorDisabled(this.__RenderMode, this.CloseButtonBackLowColorDisabled);
			color3 = Helper.RenderColors.TabCloseButtonBorderColorDisabled(this.__RenderMode, this.CloseButtonBorderColorDisabled);
			color4 = Helper.RenderColors.TabCloseButtonForeColorDisabled(this.__RenderMode, this.CloseButtonForeColorDisabled);
		}
		Bitmap bitmap = new Bitmap(17, 17);
		bitmap.MakeTransparent();
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, 15), color, color2);
		graphics.FillPolygon(brush, points2);
		Pen pen = new Pen(color3);
		graphics.DrawPolygon(pen, points2);
		graphics.SmoothingMode = SmoothingMode.Default;
		graphicsPath.AddPolygon(points);
		matrix.Translate(3f, 4f);
		graphicsPath.Transform(matrix);
		pen.Dispose();
		pen = new Pen(color4);
		graphics.DrawPolygon(pen, graphicsPath.PathPoints);
		SolidBrush solidBrush = new SolidBrush(color4);
		graphics.FillPolygon(solidBrush, graphicsPath.PathPoints);
		solidBrush.Dispose();
		pen.Dispose();
		graphicsPath.Dispose();
		graphics.Dispose();
		matrix.Dispose();
		return bitmap;
	}

	// Token: 0x06000A15 RID: 2581 RVA: 0x0003ECA0 File Offset: 0x0003CEA0
	private void CalculateWidth()
	{
		Graphics graphics = base.CreateGraphics();
		int num = 0;
		int num2 = 0;
		int num3 = base.Width;
		if (this.__Form.Icon != null)
		{
			num = this.__IconSize.Width;
		}
		if (this.__CloseButtonVisible)
		{
			num2 = this.__CloseButtonSize.Width;
		}
		Font font = new Font(this.Font, (FontStyle)Conversions.ToInteger(Interaction.IIf(this.__FontBoldOnSelect, FontStyle.Bold, FontStyle.Regular)));
		checked
		{
			num3 = (int)Math.Round((double)(unchecked((float)(checked(this.PadLeft + num + 3)) + graphics.MeasureString(this.__Form.Text, font).Width + 3f + (float)num2 + (float)this.__PadRight + 2f)));
			font.Dispose();
			if (num3 < this.__MinimumWidth + 1)
			{
				num3 = this.__MinimumWidth + 1;
			}
			else if (num3 > this.__MaximumWidth + 1)
			{
				num3 = this.__MaximumWidth + 1;
			}
			if (num3 != base.Width)
			{
				base.Width = num3;
			}
			graphics.Dispose();
		}
	}

	// Token: 0x06000A16 RID: 2582 RVA: 0x0003EDB0 File Offset: 0x0003CFB0
	private Point[] GetRegion(int int_0, int int_1, int H1)
	{
		checked
		{
			Point[] points = new Point[]
			{
				new Point(0, int_1),
				new Point(0, 2),
				new Point(2, 0),
				new Point(int_0 - 3, 0),
				new Point(int_0 - 1, 2),
				new Point(int_0 - 1, int_1)
			};
			TabControlExt.GetTabRegionEventArgs getTabRegionEventArgs = new TabControlExt.GetTabRegionEventArgs(points, int_0, int_1, this.IsSelected);
			TabPageExt.GetTabRegionEventHandler getTabRegionEvent = this.GetTabRegionEvent;
			if (getTabRegionEvent != null)
			{
				getTabRegionEvent(this, getTabRegionEventArgs);
			}
			TabControlExt.GetTabRegionEventArgs getTabRegionEventArgs2 = getTabRegionEventArgs;
			Point[] points2 = getTabRegionEventArgs2.Points;
			Array.Resize<Point>(ref points2, getTabRegionEventArgs.Points.Length + 2);
			getTabRegionEventArgs2.Points = points2;
			Array.Copy(getTabRegionEventArgs.Points, 0, getTabRegionEventArgs.Points, 1, getTabRegionEventArgs.Points.Length - 1);
			getTabRegionEventArgs.Points[0] = new Point(getTabRegionEventArgs.Points[1].X, H1);
			getTabRegionEventArgs.Points[getTabRegionEventArgs.Points.Length - 1] = new Point(getTabRegionEventArgs.Points[getTabRegionEventArgs.Points.Length - 2].X, H1);
			return getTabRegionEventArgs.Points;
		}
	}

	// Token: 0x06000A17 RID: 2583 RVA: 0x0003EEE0 File Offset: 0x0003D0E0
	private void MirrorPath(GraphicsPath GraphicPath)
	{
		Matrix matrix = new Matrix();
		matrix.Translate(0f, (float)(checked(base.Height - 1)));
		matrix.Scale(1f, -1f);
		GraphicPath.Transform(matrix);
		matrix.Dispose();
	}

	// Token: 0x06000A18 RID: 2584 RVA: 0x0003EF24 File Offset: 0x0003D124
	protected override void OnPaint(PaintEventArgs e)
	{
		checked
		{
			if (!false)
			{
				base.SuspendLayout();
				GraphicsPath graphicsPath = new GraphicsPath();
				int width = base.Width;
				this.CalculateWidth();
				if (width != base.Width)
				{
					graphicsPath.Dispose();
				}
				else
				{
					Color color;
					Color color2;
					Color color3;
					Color color4;
					if (this.__Selected)
					{
						color = Helper.RenderColors.BorderColor(this.__RenderMode, this.BorderColor);
						color2 = Helper.RenderColors.TabBackHighColor(this.__RenderMode, this.BackHighColor);
						color3 = Helper.RenderColors.TabBackLowColor(this.__RenderMode, this.BackLowColor);
						color4 = Helper.RenderColors.TabBackLowColor(this.__RenderMode, this.BackLowColor);
					}
					else if (this.__Hot)
					{
						color = Helper.RenderColors.BorderColor(this.__RenderMode, this.BorderColor);
						color2 = Helper.RenderColors.TabBackHighColor(this.__RenderMode, this.BackHighColor);
						color3 = Helper.RenderColors.TabBackLowColor(this.__RenderMode, this.BackLowColor);
						color4 = Helper.RenderColors.BorderColor(this.__RenderMode, this.BorderColor);
					}
					else
					{
						color = Helper.RenderColors.BorderColorDisabled(this.__RenderMode, this.BorderColorDisabled);
						color2 = Helper.RenderColors.TabBackHighColorDisabled(this.__RenderMode, this.BackHighColorDisabled);
						color3 = Helper.RenderColors.TabBackLowColorDisabled(this.__RenderMode, this.BackLowColorDisabled);
						color4 = Helper.RenderColors.BorderColor(this.__RenderMode, this.BorderColor);
					}
					e.Graphics.SmoothingMode = this.__SmoothingMode;
					graphicsPath.AddPolygon(this.GetRegion(base.Width - 1, base.Height - 1, Conversions.ToInteger(Interaction.IIf(this.IsSelected, base.Height, base.Height - 1))));
					if (this.__Alignment == TabControlExt.TabAlignment.Bottom)
					{
						this.MirrorPath(graphicsPath);
						Color color5 = color2;
						color2 = color3;
						color3 = color5;
					}
					Region region = new Region(graphicsPath);
					Region region2 = new Region(graphicsPath);
					Region region3 = new Region(graphicsPath);
					Region region4 = new Region(graphicsPath);
					Matrix matrix = new Matrix();
					Matrix matrix2 = new Matrix();
					Matrix matrix3 = new Matrix();
					matrix.Translate(0f, -0.5f);
					matrix2.Translate(0f, 0.5f);
					matrix3.Translate(1f, 0f);
					region2.Transform(matrix);
					region3.Transform(matrix2);
					region4.Transform(matrix3);
					region.Union(region2);
					region.Union(region3);
					region.Union(region4);
					base.Region = region;
					RectangleF bounds = region.GetBounds(e.Graphics);
					Rectangle clipRect = new Rectangle(0, 0, (int)Math.Round((double)bounds.Width), (int)Math.Round((double)bounds.Height));
					TabControlExt.TabPaintEventArgs tabPaintEventArgs = new TabControlExt.TabPaintEventArgs(e.Graphics, clipRect, this.__Selected, this.__Hot, graphicsPath, base.Width, base.Height);
					TabPageExt.TabPaintBackgroundEventHandler tabPaintBackgroundEvent = this.TabPaintBackgroundEvent;
					if (tabPaintBackgroundEvent != null)
					{
						tabPaintBackgroundEvent(this, tabPaintEventArgs);
					}
					LinearGradientBrush linearGradientBrush = this.CreateGradientBrush(new Rectangle(0, 0, base.Width, base.Height), color2, color3);
					if (!tabPaintEventArgs.Handled)
					{
						e.Graphics.FillPath(linearGradientBrush, graphicsPath);
					}
					linearGradientBrush.Dispose();
					tabPaintEventArgs.Dispose();
					tabPaintEventArgs = new TabControlExt.TabPaintEventArgs(e.Graphics, clipRect, this.__Selected, this.__Hot, graphicsPath, base.Width, base.Height);
					TabPageExt.TabPaintBorderEventHandler tabPaintBorderEvent = this.TabPaintBorderEvent;
					if (tabPaintBorderEvent != null)
					{
						tabPaintBorderEvent(this, tabPaintEventArgs);
					}
					if (!tabPaintEventArgs.Handled)
					{
						if (this.__BorderEnhanced)
						{
							object obj = Interaction.IIf(this.__Alignment == TabControlExt.TabAlignment.Bottom, color3, color2);
							Color color6 = (obj != null) ? ((Color)obj) : default(Color);
							Pen pen = new Pen(color6, (float)this.__BorderEnhanceWeight);
							e.Graphics.DrawLines(pen, graphicsPath.PathPoints);
							pen.Dispose();
						}
						Pen pen2 = new Pen(color);
						e.Graphics.DrawLines(pen2, graphicsPath.PathPoints);
						pen2.Dispose();
					}
					tabPaintEventArgs.Dispose();
					e.Graphics.SmoothingMode = SmoothingMode.None;
					e.Graphics.DrawLine(new Pen(color4), graphicsPath.PathPoints[0], graphicsPath.PathPoints[graphicsPath.PointCount - 1]);
					e.Graphics.SmoothingMode = this.__SmoothingMode;
					this.DrawIcon(e.Graphics);
					this.DrawText(e.Graphics);
					if (this.__CloseButtonVisible)
					{
						this.DrawCloseButton(e.Graphics);
					}
					base.ResumeLayout();
					graphicsPath.Dispose();
					matrix.Dispose();
					matrix2.Dispose();
					matrix3.Dispose();
					region2.Dispose();
					region3.Dispose();
					region4.Dispose();
					region.Dispose();
					tabPaintEventArgs.Dispose();
				}
			}
		}
	}

	// Token: 0x17000319 RID: 793
	// (get) Token: 0x06000A19 RID: 2585 RVA: 0x0003F408 File Offset: 0x0003D608
	// (set) Token: 0x06000A1A RID: 2586 RVA: 0x000027EC File Offset: 0x000009EC
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override Size MinimumSize
	{
		get
		{
			Size result;
			return result;
		}
		set
		{
		}
	}

	// Token: 0x1700031A RID: 794
	// (get) Token: 0x06000A1B RID: 2587 RVA: 0x0003F408 File Offset: 0x0003D608
	// (set) Token: 0x06000A1C RID: 2588 RVA: 0x000027EC File Offset: 0x000009EC
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override Size MaximumSize
	{
		get
		{
			Size result;
			return result;
		}
		set
		{
		}
	}

	// Token: 0x1700031B RID: 795
	// (get) Token: 0x06000A1D RID: 2589 RVA: 0x0003F418 File Offset: 0x0003D618
	// (set) Token: 0x06000A1E RID: 2590 RVA: 0x000027EC File Offset: 0x000009EC
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Padding Padding
	{
		get
		{
			Padding result;
			return result;
		}
		set
		{
		}
	}

	// Token: 0x1700031C RID: 796
	// (get) Token: 0x06000A1F RID: 2591 RVA: 0x0003F428 File Offset: 0x0003D628
	// (set) Token: 0x06000A20 RID: 2592 RVA: 0x000027EC File Offset: 0x000009EC
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override Color BackColor
	{
		get
		{
			Color result;
			return result;
		}
		set
		{
		}
	}

	// Token: 0x1700031D RID: 797
	// (get) Token: 0x06000A21 RID: 2593 RVA: 0x0003F438 File Offset: 0x0003D638
	// (set) Token: 0x06000A22 RID: 2594 RVA: 0x000027EC File Offset: 0x000009EC
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override DockStyle Dock
	{
		get
		{
			DockStyle result;
			return result;
		}
		set
		{
		}
	}

	// Token: 0x1700031E RID: 798
	// (get) Token: 0x06000A23 RID: 2595 RVA: 0x0003F448 File Offset: 0x0003D648
	// (set) Token: 0x06000A24 RID: 2596 RVA: 0x000027EC File Offset: 0x000009EC
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override AnchorStyles Anchor
	{
		get
		{
			AnchorStyles result;
			return result;
		}
		set
		{
		}
	}

	// Token: 0x1700031F RID: 799
	// (get) Token: 0x06000A25 RID: 2597 RVA: 0x0003F458 File Offset: 0x0003D658
	// (set) Token: 0x06000A26 RID: 2598 RVA: 0x0000643A File Offset: 0x0000463A
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string Text
	{
		get
		{
			return this.__Form.Text;
		}
		set
		{
			this.__Form.Text = value;
		}
	}

	// Token: 0x06000A27 RID: 2599 RVA: 0x0003F474 File Offset: 0x0003D674
	public void Animate(bool b)
	{
		checked
		{
			if (b)
			{
				if (!this.tmrAnimate.Enabled)
				{
					if (this.__Icons == null)
					{
						int num = this.imgAnimate.Images.Count - 1;
						this.__Icons = new Icon[num + 1];
						int num2 = num;
						for (int i = 0; i <= num2; i++)
						{
							using (Bitmap bitmap = (Bitmap)this.imgAnimate.Images[i])
							{
								this.__Icons[i] = Icon.FromHandle(bitmap.GetHicon());
							}
						}
					}
					this.Icon = this.__Icons[0];
					this.IconVisible = true;
					this.tmrAnimate.Start();
				}
			}
			else if (this.tmrAnimate.Enabled)
			{
				this.tmrAnimate.Stop();
				this.Icon = this.__Icon;
				this.IconVisible = true;
			}
		}
	}

	// Token: 0x06000A28 RID: 2600 RVA: 0x0003F568 File Offset: 0x0003D768
	private void tmrAnimate_Tick(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				if (this.$STATIC$tmrAnimate_Tick$20211C12819D$iTick < this.__Icons.Length)
				{
					this.Icon = this.__Icons[this.$STATIC$tmrAnimate_Tick$20211C12819D$iTick];
				}
				if (this.$STATIC$tmrAnimate_Tick$20211C12819D$iTick < this.__Icons.Length)
				{
					this.$STATIC$tmrAnimate_Tick$20211C12819D$iTick++;
				}
				else
				{
					this.$STATIC$tmrAnimate_Tick$20211C12819D$iTick = 0;
				}
			}
			catch (Exception ex)
			{
				this.tmrAnimate.Stop();
			}
		}
	}

	// Token: 0x040004D2 RID: 1234
	private IContainer components;

	// Token: 0x040004D5 RID: 1237
	private Color __BackHighColor;

	// Token: 0x040004D6 RID: 1238
	private Color __BackHighColorDisabled;

	// Token: 0x040004D7 RID: 1239
	private Color __BackLowColor;

	// Token: 0x040004D8 RID: 1240
	private Color __BackLowColorDisabled;

	// Token: 0x040004D9 RID: 1241
	private Color __BorderColor;

	// Token: 0x040004DA RID: 1242
	private Color __BorderColorDisabled;

	// Token: 0x040004DB RID: 1243
	private Color __ForeColorDisabled;

	// Token: 0x040004DC RID: 1244
	private bool __Selected;

	// Token: 0x040004DD RID: 1245
	private bool __Hot;

	// Token: 0x040004DE RID: 1246
	private int __MaximumWidth;

	// Token: 0x040004DF RID: 1247
	private int __MinimumWidth;

	// Token: 0x040004E0 RID: 1248
	private int __PadLeft;

	// Token: 0x040004E1 RID: 1249
	private int __PadRight;

	// Token: 0x040004E2 RID: 1250
	private bool __CloseButtonVisible;

	// Token: 0x040004E3 RID: 1251
	private Image __CloseButton;

	// Token: 0x040004E4 RID: 1252
	private Image __CloseButtonImageHot;

	// Token: 0x040004E5 RID: 1253
	private Image __CloseButtonImageDisabled;

	// Token: 0x040004E6 RID: 1254
	private Color __CloseButtonBackHighColor;

	// Token: 0x040004E7 RID: 1255
	private Color __CloseButtonBackLowColor;

	// Token: 0x040004E8 RID: 1256
	private Color __CloseButtonBorderColor;

	// Token: 0x040004E9 RID: 1257
	private Color __CloseButtonForeColor;

	// Token: 0x040004EA RID: 1258
	private Color __CloseButtonBackHighColorDisabled;

	// Token: 0x040004EB RID: 1259
	private Color __CloseButtonBackLowColorDisabled;

	// Token: 0x040004EC RID: 1260
	private Color __CloseButtonBorderColorDisabled;

	// Token: 0x040004ED RID: 1261
	private Color __CloseButtonForeColorDisabled;

	// Token: 0x040004EE RID: 1262
	private Color __CloseButtonBackHighColorHot;

	// Token: 0x040004EF RID: 1263
	private Color __CloseButtonBackLowColorHot;

	// Token: 0x040004F0 RID: 1264
	private Color __CloseButtonBorderColorHot;

	// Token: 0x040004F1 RID: 1265
	private Color __CloseButtonForeColorHot;

	// Token: 0x040004F2 RID: 1266
	private bool __HotTrack;

	// Token: 0x040004F3 RID: 1267
	private Size __CloseButtonSize;

	// Token: 0x040004F4 RID: 1268
	private bool __FontBoldOnSelect;

	// Token: 0x040004F5 RID: 1269
	private Size __IconSize;

	// Token: 0x040004F6 RID: 1270
	private SmoothingMode __SmoothingMode;

	// Token: 0x040004F7 RID: 1271
	private TabControlExt.TabAlignment __Alignment;

	// Token: 0x040004F8 RID: 1272
	private bool __GlassGradient;

	// Token: 0x040004F9 RID: 1273
	private bool __BorderEnhanced;

	// Token: 0x040004FA RID: 1274
	private ToolStripRenderMode __RenderMode;

	// Token: 0x040004FB RID: 1275
	private TabControlExt.Weight __BorderEnhanceWeight;

	// Token: 0x040004FC RID: 1276
	private bool __IconVisible;

	// Token: 0x040004FD RID: 1277
	private bool __ConfirmeClose;

	// Token: 0x040004FE RID: 1278
	private int __Index;

	// Token: 0x040004FF RID: 1279
	private Icon __Icon;

	// Token: 0x04000501 RID: 1281
	internal bool TabVisible;

	// Token: 0x04000502 RID: 1282
	internal int TabLeft;

	// Token: 0x04000503 RID: 1283
	internal ToolStripMenuItem MenuItem;

	// Token: 0x04000504 RID: 1284
	private bool __MouseOverCloseButton;

	// Token: 0x0400050B RID: 1291
	private Icon[] __Icons;

	// Token: 0x0400050C RID: 1292
	private bool $STATIC$Tab_MouseMove$20211C128381$State;

	// Token: 0x0400050D RID: 1293
	private StaticLocalInitFlag $STATIC$Tab_MouseMove$20211C128381$State$Init;

	// Token: 0x0400050E RID: 1294
	private int $STATIC$tmrAnimate_Tick$20211C12819D$iTick;

	// Token: 0x020000AC RID: 172
	// (Invoke) Token: 0x06000A2C RID: 2604
	public delegate void ClickEventHandler(object sender, EventArgs e);

	// Token: 0x020000AD RID: 173
	// (Invoke) Token: 0x06000A30 RID: 2608
	internal delegate void CloseEventHandler(object sender, EventArgs e);

	// Token: 0x020000AE RID: 174
	// (Invoke) Token: 0x06000A34 RID: 2612
	internal delegate void GetTabRegionEventHandler(object sender, TabControlExt.GetTabRegionEventArgs e);

	// Token: 0x020000AF RID: 175
	// (Invoke) Token: 0x06000A38 RID: 2616
	internal delegate void TabPaintBackgroundEventHandler(object sender, TabControlExt.TabPaintEventArgs e);

	// Token: 0x020000B0 RID: 176
	// (Invoke) Token: 0x06000A3C RID: 2620
	internal delegate void TabPaintBorderEventHandler(object sender, TabControlExt.TabPaintEventArgs e);

	// Token: 0x020000B1 RID: 177
	// (Invoke) Token: 0x06000A40 RID: 2624
	internal delegate void DragingEventHandler(object sender, MouseEventArgs e);
}
