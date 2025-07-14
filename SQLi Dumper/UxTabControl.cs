using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using UxTabControlHelpers;

// Token: 0x02000061 RID: 97
public class UxTabControl : TabControl
{
	// Token: 0x060002E4 RID: 740 RVA: 0x00015D00 File Offset: 0x00013F00
	public UxTabControl()
	{
		base.SelectedIndexChanged += this.UxTabControl_SelectedIndexChanged;
		this.intptr_0 = IntPtr.Zero;
		this.int_0 = -1;
		this.Alignment = TabAlignment.Bottom;
		this.HotTrack = true;
		this.class42_0 = new UxTabControl.Class42(this);
	}

	// Token: 0x060002E5 RID: 741 RVA: 0x000032D0 File Offset: 0x000014D0
	protected override void Dispose(bool disposing)
	{
		if (this.intptr_0 != IntPtr.Zero)
		{
			NativeMethods.DeleteObject(this.intptr_0);
			this.intptr_0 = IntPtr.Zero;
		}
		this.class42_0.ReleaseHandle();
		base.Dispose(disposing);
	}

	// Token: 0x170000C7 RID: 199
	// (get) Token: 0x060002E6 RID: 742 RVA: 0x00015D54 File Offset: 0x00013F54
	// (set) Token: 0x060002E7 RID: 743 RVA: 0x0000330D File Offset: 0x0000150D
	[Browsable(true)]
	[DefaultValue(1)]
	public new TabAlignment Alignment
	{
		get
		{
			return base.Alignment;
		}
		set
		{
			if (value <= TabAlignment.Bottom)
			{
				base.Alignment = value;
			}
		}
	}

	// Token: 0x170000C8 RID: 200
	// (get) Token: 0x060002E8 RID: 744 RVA: 0x0000331F File Offset: 0x0000151F
	// (set) Token: 0x060002E9 RID: 745 RVA: 0x00003327 File Offset: 0x00001527
	[Browsable(true)]
	[DefaultValue(true)]
	public new bool HotTrack
	{
		get
		{
			return base.HotTrack;
		}
		set
		{
			base.HotTrack = value;
		}
	}

	// Token: 0x170000C9 RID: 201
	// (get) Token: 0x060002EA RID: 746 RVA: 0x00015D6C File Offset: 0x00013F6C
	// (set) Token: 0x060002EB RID: 747 RVA: 0x00003330 File Offset: 0x00001530
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new TabAppearance Appearance
	{
		get
		{
			return base.Appearance;
		}
		set
		{
			if (value == TabAppearance.Normal)
			{
				base.Appearance = value;
			}
		}
	}

	// Token: 0x170000CA RID: 202
	// (get) Token: 0x060002EC RID: 748 RVA: 0x00015D84 File Offset: 0x00013F84
	// (set) Token: 0x060002ED RID: 749 RVA: 0x0000333F File Offset: 0x0000153F
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public new TabDrawMode DrawMode
	{
		get
		{
			return base.DrawMode;
		}
		set
		{
			if (value == TabDrawMode.Normal)
			{
				base.DrawMode = value;
			}
		}
	}

	// Token: 0x060002EE RID: 750 RVA: 0x00015D9C File Offset: 0x00013F9C
	private void method_0()
	{
		this.bool_0 = (Application.RenderWithVisualStyles && TabRenderer.IsSupported);
		base.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque, this.bool_0);
		base.UpdateStyles();
		if (this.bool_0)
		{
			if (this.intptr_0 == IntPtr.Zero)
			{
				this.intptr_0 = this.Font.ToHfont();
			}
			NativeMethods.SendMessageW(base.Handle, 48U, this.intptr_0, (IntPtr)1);
		}
		else
		{
			NativeMethods.SendMessageW(base.Handle, 48U, this.Font.ToHfont(), (IntPtr)1);
			if (this.intptr_0 != IntPtr.Zero)
			{
				NativeMethods.DeleteObject(this.intptr_0);
				this.intptr_0 = IntPtr.Zero;
			}
		}
	}

	// Token: 0x060002EF RID: 751 RVA: 0x0000334E File Offset: 0x0000154E
	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		this.method_0();
	}

	// Token: 0x060002F0 RID: 752 RVA: 0x00015E60 File Offset: 0x00014060
	protected override void OnFontChanged(EventArgs e)
	{
		base.OnFontChanged(e);
		if (this.bool_0)
		{
			if (this.intptr_0 != IntPtr.Zero)
			{
				NativeMethods.DeleteObject(this.intptr_0);
			}
			this.intptr_0 = this.Font.ToHfont();
			NativeMethods.SendMessageW(base.Handle, 48U, this.intptr_0, (IntPtr)1);
		}
	}

	// Token: 0x060002F1 RID: 753 RVA: 0x00015EC8 File Offset: 0x000140C8
	protected override void WndProc(ref Message m)
	{
		if (m.Msg == 794)
		{
			this.method_0();
		}
		else if (m.Msg == 528 && (m.WParam.ToInt32() & 65535) == 1)
		{
			StringBuilder stringBuilder = new StringBuilder(16);
			if ((ulong)NativeMethods.RealGetWindowClassW(m.LParam, stringBuilder, 16U) > 0UL && Operators.CompareString(stringBuilder.ToString(), "msctls_updown32", false) == 0)
			{
				this.class42_0.ReleaseHandle();
				this.class42_0.AssignHandle(m.LParam);
			}
		}
		base.WndProc(ref m);
	}

	// Token: 0x060002F2 RID: 754 RVA: 0x00015F6C File Offset: 0x0001416C
	private void method_1(Graphics graphics_0, Rectangle rectangle_0)
	{
		checked
		{
			if (base.Visible)
			{
				int selectedIndex = base.SelectedIndex;
				object obj = Interaction.IIf(selectedIndex != -1, base.GetTabRect(selectedIndex), Rectangle.Empty);
				Rectangle rectangle_ = (obj != null) ? ((Rectangle)obj) : default(Rectangle);
				Rectangle clientRectangle = base.ClientRectangle;
				TabAlignment alignment = this.Alignment;
				if (alignment != TabAlignment.Top)
				{
					if (alignment == TabAlignment.Bottom)
					{
						clientRectangle.Height -= rectangle_.Height * base.RowCount + 1;
					}
				}
				else
				{
					int num = rectangle_.Height * base.RowCount + 2;
					clientRectangle.Y += num;
					clientRectangle.Height -= num;
				}
				if (clientRectangle.IntersectsWith(rectangle_0))
				{
					TabRenderer.DrawTabPage(graphics_0, clientRectangle);
				}
				int tabCount = base.TabCount;
				if (tabCount != 0)
				{
					this.int_0 = this.method_4();
					VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Normal);
					int num2 = tabCount - 1;
					for (int i = 0; i <= num2; i++)
					{
						if (i != selectedIndex)
						{
							Rectangle tabRect = base.GetTabRect(i);
							if (tabRect.Right >= 3 && tabRect.IntersectsWith(rectangle_0))
							{
								TabItemState state = (TabItemState)Conversions.ToInteger(Interaction.IIf(i == this.int_0, TabItemState.Hot, TabItemState.Normal));
								visualStyleRenderer.SetParameters(visualStyleRenderer.Class, visualStyleRenderer.Part, (int)state);
								this.method_2(graphics_0, i, tabRect, visualStyleRenderer);
							}
						}
					}
					rectangle_.Inflate(2, 2);
					if (selectedIndex != -1 && rectangle_.IntersectsWith(rectangle_0))
					{
						visualStyleRenderer.SetParameters(visualStyleRenderer.Class, visualStyleRenderer.Part, 3);
						this.method_2(graphics_0, selectedIndex, rectangle_, visualStyleRenderer);
					}
				}
			}
		}
	}

	// Token: 0x060002F3 RID: 755 RVA: 0x00016134 File Offset: 0x00014334
	private void method_2(Graphics graphics_0, int int_1, Rectangle rectangle_0, VisualStyleRenderer visualStyleRenderer_0)
	{
		checked
		{
			if (this.class42_0.Int32_0 <= 0 || rectangle_0.X < this.class42_0.Int32_0)
			{
				bool flag = visualStyleRenderer_0.State == 3;
				using (GdiMemoryContext gdiMemoryContext = new GdiMemoryContext(graphics_0, rectangle_0.Width, rectangle_0.Height))
				{
					Rectangle bounds = new Rectangle(0, 0, rectangle_0.Width, rectangle_0.Height);
					visualStyleRenderer_0.DrawBackground(gdiMemoryContext.Graphics_0, bounds);
					if (flag && rectangle_0.X == 0)
					{
						int num = gdiMemoryContext.Int32_1 - 1;
						gdiMemoryContext.method_2(0, num, gdiMemoryContext.method_1(0, num - 1));
					}
					if (this.Alignment == TabAlignment.Bottom)
					{
						gdiMemoryContext.method_0();
					}
					TabPage tabPage = base.TabPages[int_1];
					Image image = this.method_3(tabPage.ImageIndex, tabPage.ImageKey);
					if (!Information.IsNothing(image))
					{
						Point point = new Point(Conversions.ToInteger(Interaction.IIf(flag, 8, 6)), 2);
						int num2 = point.X + image.Width;
						if (this.Alignment == TabAlignment.Bottom)
						{
							point.Y = Conversions.ToInteger(Operators.SubtractObject(bounds.Bottom - image.Height, Interaction.IIf(flag, 4, 2)));
						}
						if (this.RightToLeftLayout)
						{
							point.X = bounds.Right - num2;
						}
						gdiMemoryContext.Graphics_0.DrawImageUnscaled(image, point);
						bounds.X += num2;
						bounds.Width -= num2;
					}
					TextRenderer.DrawText(gdiMemoryContext.Graphics_0, tabPage.Text, this.Font, bounds, visualStyleRenderer_0.GetColor(ColorProperty.TextColor), TextFormatFlags.HorizontalCenter | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter);
					if (this.class42_0.Int32_0 > 0 && this.class42_0.Int32_0 >= rectangle_0.X && this.class42_0.Int32_0 < rectangle_0.Right)
					{
						rectangle_0.Width -= rectangle_0.Right - this.class42_0.Int32_0;
					}
					gdiMemoryContext.method_3(graphics_0, rectangle_0);
				}
			}
		}
	}

	// Token: 0x060002F4 RID: 756 RVA: 0x00016394 File Offset: 0x00014594
	private Image method_3(int int_1, string string_0)
	{
		Image result;
		if (Information.IsNothing(base.ImageList))
		{
			result = null;
		}
		else if (int_1 > -1)
		{
			result = base.ImageList.Images[int_1];
		}
		else if (string_0.Length > 0)
		{
			result = base.ImageList.Images[string_0];
		}
		else
		{
			result = null;
		}
		return result;
	}

	// Token: 0x060002F5 RID: 757 RVA: 0x000163F0 File Offset: 0x000145F0
	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Point location = base.Location;
		checked
		{
			e.Graphics.TranslateTransform((float)(0 - location.X), (float)(0 - location.Y));
			base.InvokePaintBackground(base.Parent, e);
			e.Graphics.TranslateTransform((float)location.X, (float)location.Y);
			this.method_1(e.Graphics, e.ClipRectangle);
		}
	}

	// Token: 0x060002F6 RID: 758 RVA: 0x00016464 File Offset: 0x00014664
	private int method_4()
	{
		NativeMethods.Struct6 @struct = default(NativeMethods.Struct6);
		Point point = base.PointToClient(Control.MousePosition);
		@struct.struct5_0.int_0 = point.X;
		@struct.struct5_0.int_1 = point.Y;
		GCHandle gchandle = GCHandle.Alloc(@struct, GCHandleType.Pinned);
		int result = NativeMethods.SendMessageW(base.Handle, 4877U, IntPtr.Zero, gchandle.AddrOfPinnedObject()).ToInt32();
		gchandle.Free();
		return result;
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x000164EC File Offset: 0x000146EC
	private void UxTabControl_SelectedIndexChanged(object sender, EventArgs e)
	{
		global::Globals.LockWindowUpdate(base.Handle);
		if (base.SelectedTab.Controls.Count > 0)
		{
			base.SelectedTab.Controls[0].Focus();
		}
		global::Globals.LockWindowUpdate(IntPtr.Zero);
	}

	// Token: 0x040001E4 RID: 484
	private bool bool_0;

	// Token: 0x040001E5 RID: 485
	private IntPtr intptr_0;

	// Token: 0x040001E6 RID: 486
	private int int_0;

	// Token: 0x040001E7 RID: 487
	private UxTabControl.Class42 class42_0;

	// Token: 0x02000062 RID: 98
	[SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
	private sealed class Class42 : NativeWindow
	{
		// Token: 0x060002F8 RID: 760 RVA: 0x0000335D File Offset: 0x0000155D
		public Class42(UxTabControl uxTabControl_1)
		{
			this.uxTabControl_0 = uxTabControl_1;
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x0001653C File Offset: 0x0001473C
		public int Int32_0
		{
			get
			{
				return this.int_0;
			}
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00016554 File Offset: 0x00014754
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 2 || m.Msg == 130)
			{
				this.ReleaseHandle();
			}
			else if (m.Msg == 70)
			{
				object lparam = m.GetLParam(typeof(NativeMethods.Struct7));
				NativeMethods.Struct7 @struct = (lparam != null) ? ((NativeMethods.Struct7)lparam) : default(NativeMethods.Struct7);
				this.int_0 = @struct.int_0;
			}
			else
			{
				if (m.Msg == 512 && this.uxTabControl_0.int_0 > 0 && this.uxTabControl_0.int_0 != this.uxTabControl_0.SelectedIndex)
				{
					using (Graphics graphics = Graphics.FromHwnd(this.uxTabControl_0.Handle))
					{
						VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Normal);
						this.uxTabControl_0.method_2(graphics, this.uxTabControl_0.int_0, this.uxTabControl_0.GetTabRect(this.uxTabControl_0.int_0), visualStyleRenderer);
						if (checked(this.uxTabControl_0.int_0 - this.uxTabControl_0.SelectedIndex) == 1)
						{
							Rectangle tabRect = this.uxTabControl_0.GetTabRect(this.uxTabControl_0.SelectedIndex);
							tabRect.Inflate(2, 2);
							visualStyleRenderer.SetParameters(visualStyleRenderer.Class, visualStyleRenderer.Part, 3);
							this.uxTabControl_0.method_2(graphics, this.uxTabControl_0.SelectedIndex, tabRect, visualStyleRenderer);
						}
						goto IL_1B3;
					}
				}
				if (m.Msg == 513)
				{
					Rectangle tabRect2 = this.uxTabControl_0.GetTabRect(this.uxTabControl_0.SelectedIndex);
					tabRect2.X = 0;
					tabRect2.Width = 2;
					tabRect2.Inflate(0, 2);
					this.uxTabControl_0.Invalidate(tabRect2);
				}
			}
			IL_1B3:
			base.WndProc(ref m);
		}

		// Token: 0x040001E8 RID: 488
		private int int_0;

		// Token: 0x040001E9 RID: 489
		private UxTabControl uxTabControl_0;
	}
}
