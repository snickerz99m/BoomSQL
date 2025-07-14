using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace UxTabControlHelpers
{
	// Token: 0x02000064 RID: 100
	[StandardModule]
	internal sealed class NativeMethods
	{
		// Token: 0x06000306 RID: 774
		[DllImport("gdi32.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr CreateCompatibleDC(IntPtr intptr_0);

		// Token: 0x06000307 RID: 775
		[DllImport("gdi32.dll", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteDC(IntPtr intptr_0);

		// Token: 0x06000308 RID: 776
		[DllImport("gdi32.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr CreateCompatibleBitmap(IntPtr intptr_0, int int_10, int int_11);

		// Token: 0x06000309 RID: 777
		[DllImport("gdi32.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr SelectObject(IntPtr intptr_0, IntPtr intptr_1);

		// Token: 0x0600030A RID: 778
		[DllImport("gdi32.dll", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteObject(IntPtr intptr_0);

		// Token: 0x0600030B RID: 779
		[DllImport("gdi32.dll", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool StretchBlt(IntPtr intptr_0, int int_10, int int_11, int int_12, int int_13, IntPtr intptr_1, int int_14, int int_15, int int_16, int int_17, uint uint_1);

		// Token: 0x0600030C RID: 780
		[DllImport("gdi32.dll", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool BitBlt(IntPtr intptr_0, int int_10, int int_11, int int_12, int int_13, IntPtr intptr_1, int int_14, int int_15, uint uint_1);

		// Token: 0x0600030D RID: 781
		[DllImport("gdi32.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern uint GetPixel(IntPtr intptr_0, int int_10, int int_11);

		// Token: 0x0600030E RID: 782
		[DllImport("gdi32.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern uint SetPixel(IntPtr intptr_0, int int_10, int int_11, uint uint_1);

		// Token: 0x0600030F RID: 783
		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
		public static extern IntPtr SendMessageW(IntPtr intptr_0, uint uint_1, IntPtr intptr_1, IntPtr intptr_2);

		// Token: 0x06000310 RID: 784
		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
		public static extern uint RealGetWindowClassW(IntPtr intptr_0, StringBuilder stringBuilder_0, uint uint_1);

		// Token: 0x040001F0 RID: 496
		public static uint uint_0;

		// Token: 0x040001F1 RID: 497
		public static int int_0;

		// Token: 0x040001F2 RID: 498
		public static int int_1;

		// Token: 0x040001F3 RID: 499
		public static int int_2;

		// Token: 0x040001F4 RID: 500
		public static int int_3;

		// Token: 0x040001F5 RID: 501
		public static int int_4;

		// Token: 0x040001F6 RID: 502
		public static int int_5;

		// Token: 0x040001F7 RID: 503
		public static int int_6;

		// Token: 0x040001F8 RID: 504
		public static int int_7;

		// Token: 0x040001F9 RID: 505
		public static int int_8;

		// Token: 0x040001FA RID: 506
		public static int int_9;

		// Token: 0x02000065 RID: 101
		public struct Struct5
		{
			// Token: 0x040001FB RID: 507
			public int int_0;

			// Token: 0x040001FC RID: 508
			public int int_1;
		}

		// Token: 0x02000066 RID: 102
		public struct Struct6
		{
			// Token: 0x040001FD RID: 509
			public NativeMethods.Struct5 struct5_0;

			// Token: 0x040001FE RID: 510
			public uint uint_0;
		}

		// Token: 0x02000067 RID: 103
		public struct Struct7
		{
			// Token: 0x040001FF RID: 511
			public IntPtr intptr_0;

			// Token: 0x04000200 RID: 512
			public IntPtr intptr_1;

			// Token: 0x04000201 RID: 513
			public int int_0;

			// Token: 0x04000202 RID: 514
			public int int_1;

			// Token: 0x04000203 RID: 515
			public int int_2;

			// Token: 0x04000204 RID: 516
			public int int_3;

			// Token: 0x04000205 RID: 517
			public int int_4;
		}
	}
}
