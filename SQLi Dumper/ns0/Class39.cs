using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace ns0
{
	// Token: 0x02000056 RID: 86
	internal sealed class Class39
	{
		// Token: 0x060002A6 RID: 678 RVA: 0x000020F8 File Offset: 0x000002F8
		private Class39()
		{
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x000150E4 File Offset: 0x000132E4
		internal static Interface0 Interface0_0
		{
			get
			{
				if (Class39.interface0_0 == null)
				{
					object obj = Class39.object_0;
					ObjectFlowControl.CheckForSyncLockOnValueType(obj);
					lock (obj)
					{
						if (Class39.interface0_0 == null)
						{
							Class39.interface0_0 = (Interface0)new Class38();
							Class39.interface0_0.imethod_0();
						}
					}
				}
				return Class39.interface0_0;
			}
		}

		// Token: 0x040001C3 RID: 451
		private static object object_0 = RuntimeHelpers.GetObjectValue(new object());

		// Token: 0x040001C4 RID: 452
		private static Interface0 interface0_0;
	}
}
