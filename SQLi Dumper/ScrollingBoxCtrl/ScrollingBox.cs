using System;
using System.ComponentModel;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace ScrollingBoxCtrl
{
	// Token: 0x0200004F RID: 79
	[ToolboxBitmap("ScrollBoxToolIcon")]
	public class ScrollingBox : Control
	{
		// Token: 0x06000279 RID: 633 RVA: 0x00014928 File Offset: 0x00012B28
		public ScrollingBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.scrollingBoxCollection_0 = new ScrollingBoxCollection();
			this.scrollingBoxCollection_0.OnCollectionChanged += this.scrollingBoxCollection_0_OnCollectionChanged;
			this.arrowDirection_0 = ArrowDirection.Up;
			this.bool_0 = false;
			this.stringFormat_0 = new StringFormat();
			this.int_0 = 0;
			this.point_0 = default(Point);
			this.bool_1 = false;
			this.timer_0 = new System.Timers.Timer();
			this.timer_0.Elapsed += this.timer_0_Elapsed;
			this.timer_0.Interval = 25.0;
			this.timer_0.Enabled = true;
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00002F12 File Offset: 0x00001112
		private void scrollingBoxCollection_0_OnCollectionChanged(object sender, EventArgs e)
		{
			this.method_0();
		}

		// Token: 0x0600027B RID: 635 RVA: 0x000149E0 File Offset: 0x00012BE0
		private void method_0()
		{
			SizeF sizeF = default(SizeF);
			Graphics graphics = base.CreateGraphics();
			checked
			{
				int num = base.Width - base.Padding.Left - base.Padding.Right;
				int num2 = this.scrollingBoxCollection_0.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					ScrollingBoxItem scrollingBoxItem = this.scrollingBoxCollection_0[i];
					scrollingBoxItem.rectangleF_0.X = (float)base.Padding.Left;
					scrollingBoxItem.rectangleF_0.Width = (float)num;
					unchecked
					{
						if (scrollingBoxItem is ScrollingBoxText)
						{
							ScrollingBoxText scrollingBoxText = (ScrollingBoxText)scrollingBoxItem;
							sizeF = graphics.MeasureString(scrollingBoxText.Text, this.Font, num, this.stringFormat_0);
						}
						else if (scrollingBoxItem is ScrollingBoxImage)
						{
							ScrollingBoxImage scrollingBoxImage = (ScrollingBoxImage)scrollingBoxItem;
							sizeF = scrollingBoxImage.Image.Size;
							scrollingBoxImage.rectangleF_0.Width = sizeF.Width;
							switch (this.Alignment)
							{
							case StringAlignment.Near:
								scrollingBoxItem.rectangleF_0.X = (float)base.Padding.Left;
								break;
							case StringAlignment.Center:
								scrollingBoxItem.rectangleF_0.X = (float)((double)num / 2.0 - (double)(sizeF.Width / 2f) + (double)base.Padding.Left);
								break;
							case StringAlignment.Far:
								scrollingBoxItem.rectangleF_0.X = (float)base.Width - sizeF.Width - (float)base.Padding.Right;
								break;
							}
						}
						scrollingBoxItem.rectangleF_0.Height = sizeF.Height;
						if (i == 0)
						{
							if (!this.bool_1)
							{
								scrollingBoxItem.rectangleF_0.Y = (float)base.Height;
								this.bool_1 = true;
							}
						}
						else
						{
							scrollingBoxItem.rectangleF_0.Y = this.scrollingBoxCollection_0[checked(i - 1)].rectangleF_0.Y + this.scrollingBoxCollection_0[checked(i - 1)].rectangleF_0.Height;
						}
					}
				}
			}
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00014C14 File Offset: 0x00012E14
		private void method_1()
		{
			checked
			{
				int num = this.scrollingBoxCollection_0.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					ScrollingBoxItem scrollingBoxItem = this.scrollingBoxCollection_0[i];
					unchecked
					{
						if (this.arrowDirection_0 == ArrowDirection.Up)
						{
							if (scrollingBoxItem.rectangleF_0.Y + scrollingBoxItem.rectangleF_0.Height < 0f)
							{
								if (i == 0)
								{
									scrollingBoxItem.rectangleF_0.Y = this.scrollingBoxCollection_0[checked(this.scrollingBoxCollection_0.Count - 1)].rectangleF_0.Y + (float)base.Height + scrollingBoxItem.rectangleF_0.Height;
								}
								else
								{
									scrollingBoxItem.rectangleF_0.Y = this.scrollingBoxCollection_0[checked(i - 1)].rectangleF_0.Y + this.scrollingBoxCollection_0[checked(i - 1)].rectangleF_0.Height;
								}
							}
							else
							{
								ScrollingBoxItem scrollingBoxItem2 = scrollingBoxItem;
								ref RectangleF ptr = ref scrollingBoxItem2.rectangleF_0;
								scrollingBoxItem2.rectangleF_0.Y = ptr.Y - 1f;
							}
						}
						else if (this.arrowDirection_0 == ArrowDirection.Down)
						{
							if (scrollingBoxItem.rectangleF_0.Y > (float)base.Height)
							{
								if (i == checked(this.scrollingBoxCollection_0.Count - 1))
								{
									scrollingBoxItem.rectangleF_0.Y = this.scrollingBoxCollection_0[0].rectangleF_0.Y - (float)base.Height - scrollingBoxItem.rectangleF_0.Height;
								}
								else
								{
									scrollingBoxItem.rectangleF_0.Y = this.scrollingBoxCollection_0[checked(i + 1)].rectangleF_0.Y - scrollingBoxItem.rectangleF_0.Height;
								}
							}
							else
							{
								ScrollingBoxItem scrollingBoxItem3 = scrollingBoxItem;
								ref RectangleF ptr = ref scrollingBoxItem3.rectangleF_0;
								scrollingBoxItem3.rectangleF_0.Y = ptr.Y + 1f;
							}
						}
					}
				}
				base.Invalidate();
			}
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00002F1A File Offset: 0x0000111A
		private void timer_0_Elapsed(object sender, ElapsedEventArgs e)
		{
			this.method_1();
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00014DE8 File Offset: 0x00012FE8
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			SolidBrush brush = new SolidBrush(this.ForeColor);
			RectangleF rectangleF = new RectangleF((float)e.ClipRectangle.X, (float)e.ClipRectangle.Y, (float)e.ClipRectangle.Width, (float)e.ClipRectangle.Height);
			if (!this.bool_0)
			{
				graphics.Clear(this.BackColor);
			}
			else
			{
				graphics.DrawImageUnscaled(this.BackgroundImage, 0, 0);
			}
			checked
			{
				int num = this.scrollingBoxCollection_0.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					ScrollingBoxItem scrollingBoxItem = this.scrollingBoxCollection_0[i];
					if (rectangleF.IntersectsWith(scrollingBoxItem.rectangleF_0))
					{
						if (scrollingBoxItem is ScrollingBoxText)
						{
							graphics.DrawString(((ScrollingBoxText)scrollingBoxItem).Text, this.Font, brush, scrollingBoxItem.rectangleF_0, this.stringFormat_0);
						}
						else if (scrollingBoxItem is ScrollingBoxImage)
						{
							graphics.DrawImage(((ScrollingBoxImage)scrollingBoxItem).Image, scrollingBoxItem.rectangleF_0);
						}
					}
				}
				ControlPaint.DrawBorder(graphics, base.ClientRectangle, ControlPaint.Dark(this.BackColor), ButtonBorderStyle.Solid);
			}
		}

		// Token: 0x0600027F RID: 639 RVA: 0x000027EC File Offset: 0x000009EC
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00002F22 File Offset: 0x00001122
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.method_0();
			base.Invalidate();
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00002F37 File Offset: 0x00001137
		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			this.method_0();
			base.Invalidate();
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00002F4C File Offset: 0x0000114C
		protected override void OnBackgroundImageChanged(EventArgs e)
		{
			base.OnBackgroundImageChanged(e);
			if (this.BackgroundImage == null)
			{
				this.bool_0 = false;
			}
			else
			{
				this.bool_0 = true;
			}
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00002F70 File Offset: 0x00001170
		protected override void OnPaddingChanged(EventArgs e)
		{
			base.OnPaddingChanged(e);
			this.method_0();
			base.Invalidate();
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000284 RID: 644 RVA: 0x00014F28 File Offset: 0x00013128
		// (set) Token: 0x06000285 RID: 645 RVA: 0x00002F85 File Offset: 0x00001185
		[Browsable(false)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000286 RID: 646 RVA: 0x00014F40 File Offset: 0x00013140
		// (set) Token: 0x06000287 RID: 647 RVA: 0x00002F8E File Offset: 0x0000118E
		[Browsable(false)]
		public ScrollingBoxCollection Items
		{
			get
			{
				return this.scrollingBoxCollection_0;
			}
			set
			{
				this.scrollingBoxCollection_0 = value;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000288 RID: 648 RVA: 0x00002F97 File Offset: 0x00001197
		// (set) Token: 0x06000289 RID: 649 RVA: 0x00002FA4 File Offset: 0x000011A4
		[Browsable(true)]
		[DefaultValue(true)]
		public bool ScrollEnabled
		{
			get
			{
				return this.timer_0.Enabled;
			}
			set
			{
				this.int_0 = 0;
				this.timer_0.Enabled = value;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x0600028A RID: 650 RVA: 0x00014F58 File Offset: 0x00013158
		// (set) Token: 0x0600028B RID: 651 RVA: 0x00002FB9 File Offset: 0x000011B9
		[DefaultValue(2)]
		[Browsable(true)]
		public StringAlignment Alignment
		{
			get
			{
				return this.stringFormat_0.Alignment;
			}
			set
			{
				this.stringFormat_0.Alignment = value;
				this.method_0();
				base.Invalidate();
			}
		}

		// Token: 0x040001B7 RID: 439
		private System.Timers.Timer timer_0;

		// Token: 0x040001B8 RID: 440
		private ScrollingBoxCollection scrollingBoxCollection_0;

		// Token: 0x040001B9 RID: 441
		private ArrowDirection arrowDirection_0;

		// Token: 0x040001BA RID: 442
		private bool bool_0;

		// Token: 0x040001BB RID: 443
		private StringFormat stringFormat_0;

		// Token: 0x040001BC RID: 444
		private int int_0;

		// Token: 0x040001BD RID: 445
		private Point point_0;

		// Token: 0x040001BE RID: 446
		private bool bool_1;
	}
}
