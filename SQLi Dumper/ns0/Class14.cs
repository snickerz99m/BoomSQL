using System;
using Microsoft.VisualBasic;

namespace ns0
{
	// Token: 0x02000016 RID: 22
	internal sealed class Class14
	{
		// Token: 0x060000C9 RID: 201 RVA: 0x0000B794 File Offset: 0x00009994
		public static byte[] smethod_0(byte[] byte_0, string string_0)
		{
			return Class14.smethod_2(byte_0, string_0);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000B794 File Offset: 0x00009994
		public static byte[] smethod_1(byte[] byte_0, string string_0)
		{
			return Class14.smethod_2(byte_0, string_0);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000B7AC File Offset: 0x000099AC
		private static byte[] smethod_2(byte[] byte_0, string string_0)
		{
			checked
			{
				byte[] array = new byte[byte_0.Length - 1 + 1];
				string_0 = "\0" + string_0 + "\0";
				int num = byte_0.Length - 1;
				for (int i = 0; i <= num; i++)
				{
					array[i] = (byte)((int)byte_0[i] ^ Strings.Asc(string_0.Substring(i % string_0.Length, 1)));
				}
				return array;
			}
		}
	}
}
