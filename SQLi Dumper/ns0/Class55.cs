using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ns0
{
	// Token: 0x02000108 RID: 264
	[CompilerGenerated]
	internal sealed class Class55
	{
		// Token: 0x06001152 RID: 4434 RVA: 0x00079B6C File Offset: 0x00077D6C
		internal static uint smethod_0(string string_0)
		{
			uint num = 2166136261U;
			if (string_0 != null)
			{
				for (int i = 0; i < string_0.Length; i++)
				{
					num = ((uint)string_0[i] ^ num) * 16777619U;
				}
			}
			return num;
		}

		// Token: 0x040008BD RID: 2237 RVA: 0x00002048 File Offset: 0x00000248
		internal static readonly Class55.Struct11 struct11_0;

		// Token: 0x040008BE RID: 2238 RVA: 0x00002060 File Offset: 0x00000260
		internal static readonly Class55.Struct13 struct13_0;

		// Token: 0x040008BF RID: 2239 RVA: 0x00002090 File Offset: 0x00000290
		internal static readonly Class55.Struct12 struct12_0;

		// Token: 0x02000109 RID: 265
		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 19)]
		private struct Struct11
		{
		}

		// Token: 0x0200010A RID: 266
		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 26)]
		private struct Struct12
		{
		}

		// Token: 0x0200010B RID: 267
		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 48)]
		private struct Struct13
		{
		}
	}
}
