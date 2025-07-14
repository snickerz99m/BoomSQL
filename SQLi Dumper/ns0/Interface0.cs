using System;
using System.Runtime.InteropServices;

namespace ns0
{
	// Token: 0x02000055 RID: 85
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("c43dc798-95d1-4bea-9030-bb99e2983a1a")]
	[ComImport]
	internal interface Interface0
	{
		// Token: 0x0600029D RID: 669
		[PreserveSig]
		void imethod_0();

		// Token: 0x0600029E RID: 670
		[PreserveSig]
		void imethod_1(IntPtr intptr_0);

		// Token: 0x0600029F RID: 671
		[PreserveSig]
		void imethod_2(IntPtr intptr_0);

		// Token: 0x060002A0 RID: 672
		[PreserveSig]
		void imethod_3(IntPtr intptr_0);

		// Token: 0x060002A1 RID: 673
		[PreserveSig]
		void imethod_4(IntPtr intptr_0);

		// Token: 0x060002A2 RID: 674
		[PreserveSig]
		void imethod_5(IntPtr intptr_0, [MarshalAs(UnmanagedType.Bool)] bool bool_0);

		// Token: 0x060002A3 RID: 675
		[PreserveSig]
		void imethod_6(IntPtr intptr_0, ulong ulong_0, ulong ulong_1);

		// Token: 0x060002A4 RID: 676
		[PreserveSig]
		void imethod_7(IntPtr intptr_0, Enum3 enum3_0);
	}
}
