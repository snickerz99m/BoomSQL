using System;
using System.Drawing;
using Microsoft.VisualBasic;

namespace UxTabControlHelpers
{
	// Token: 0x02000063 RID: 99
	internal sealed class GdiMemoryContext : IDisposable
	{
		// Token: 0x060002FB RID: 763 RVA: 0x0001672C File Offset: 0x0001492C
		public GdiMemoryContext(Graphics graphics_1, int int_2, int int_3)
		{
			if (Information.IsNothing(graphics_1) || int_2 <= 0 || int_3 <= 0)
			{
				throw new ArgumentException("Arguments are unacceptable");
			}
			IntPtr hdc = graphics_1.GetHdc();
			bool flag = true;
			this.intptr_0 = NativeMethods.CreateCompatibleDC(hdc);
			if (!(this.intptr_0 == IntPtr.Zero))
			{
				this.intptr_1 = NativeMethods.CreateCompatibleBitmap(hdc, int_2, int_3);
				if (this.intptr_1 == IntPtr.Zero)
				{
					NativeMethods.DeleteDC(this.intptr_0);
				}
				else
				{
					this.intptr_2 = NativeMethods.SelectObject(this.intptr_0, this.intptr_1);
					if (this.intptr_2 == IntPtr.Zero)
					{
						NativeMethods.DeleteObject(this.intptr_1);
						NativeMethods.DeleteDC(this.intptr_0);
					}
					else
					{
						flag = false;
					}
				}
			}
			graphics_1.ReleaseHdc(hdc);
			if (flag)
			{
				throw new SystemException("GDI error occured while creating context");
			}
			this.graphics_0 = Graphics.FromHdc(this.intptr_0);
			this.int_0 = int_2;
			this.int_1 = int_3;
		}

		// Token: 0x060002FC RID: 764 RVA: 0x0000336C File Offset: 0x0000156C
		protected override void Finalize()
		{
			this.vmethod_0(false);
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00016834 File Offset: 0x00014A34
		protected void vmethod_0(bool bool_0)
		{
			if (bool_0 && !Information.IsNothing(this.graphics_0))
			{
				this.graphics_0.Dispose();
			}
			NativeMethods.SelectObject(this.intptr_0, this.intptr_2);
			NativeMethods.DeleteDC(this.intptr_0);
			this.intptr_0 = (IntPtr)((-(((this.intptr_2 == IntPtr.Zero) > false) ? 1L : 0L)) ? 1L : 0L);
			NativeMethods.DeleteObject(this.intptr_1);
			this.intptr_1 = IntPtr.Zero;
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00003375 File Offset: 0x00001575
		public void Dispose()
		{
			this.vmethod_0(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060002FF RID: 767 RVA: 0x000168B8 File Offset: 0x00014AB8
		public Graphics Graphics_0
		{
			get
			{
				return this.graphics_0;
			}
		}

		// Token: 0x06000300 RID: 768 RVA: 0x000168D0 File Offset: 0x00014AD0
		public void method_0()
		{
			checked
			{
				if (this.intptr_0 != IntPtr.Zero)
				{
					NativeMethods.StretchBlt(this.intptr_0, 0, this.int_1 - 1, this.int_0, 0 - this.int_1, this.intptr_0, 0, 0, this.int_0, this.int_1, 13369376U);
				}
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000301 RID: 769 RVA: 0x0001692C File Offset: 0x00014B2C
		public int Int32_0
		{
			get
			{
				return this.int_0;
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000302 RID: 770 RVA: 0x00016944 File Offset: 0x00014B44
		public int Int32_1
		{
			get
			{
				return this.int_1;
			}
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0001695C File Offset: 0x00014B5C
		public uint method_1(int int_2, int int_3)
		{
			if (!(this.intptr_0 != IntPtr.Zero))
			{
				throw new ObjectDisposedException(null, "GDI context seems to be disposed.");
			}
			return NativeMethods.GetPixel(this.intptr_0, int_2, int_3);
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00003384 File Offset: 0x00001584
		public void method_2(int int_2, int int_3, uint uint_0)
		{
			if (!(this.intptr_0 != IntPtr.Zero))
			{
				throw new ObjectDisposedException(null, "GDI context seems to be disposed.");
			}
			NativeMethods.SetPixel(this.intptr_0, int_2, int_3, uint_0);
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00016998 File Offset: 0x00014B98
		public void method_3(Graphics graphics_1, Rectangle rectangle_0)
		{
			if (!Information.IsNothing(graphics_1) && !(this.intptr_0 == IntPtr.Zero))
			{
				IntPtr hdc = graphics_1.GetHdc();
				if (!(hdc == IntPtr.Zero))
				{
					NativeMethods.BitBlt(hdc, rectangle_0.Left, rectangle_0.Top, rectangle_0.Width, rectangle_0.Height, this.intptr_0, 0, 0, 13369376U);
					graphics_1.ReleaseHdc(hdc);
				}
			}
		}

		// Token: 0x040001EA RID: 490
		private IntPtr intptr_0;

		// Token: 0x040001EB RID: 491
		private IntPtr intptr_1;

		// Token: 0x040001EC RID: 492
		private IntPtr intptr_2;

		// Token: 0x040001ED RID: 493
		private int int_0;

		// Token: 0x040001EE RID: 494
		private int int_1;

		// Token: 0x040001EF RID: 495
		private Graphics graphics_0;
	}
}
