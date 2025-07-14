using System;
using System.Text;

namespace ns0
{
	// Token: 0x02000014 RID: 20
	internal sealed class Class12
	{
		// Token: 0x060000C0 RID: 192 RVA: 0x0000B58C File Offset: 0x0000978C
		public static byte[] smethod_0(byte[] byte_0, string string_0)
		{
			return Class12.smethod_2(byte_0, Class12.smethod_4(string_0));
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000B58C File Offset: 0x0000978C
		public static byte[] smethod_1(byte[] byte_0, string string_0)
		{
			return Class12.smethod_2(byte_0, Class12.smethod_4(string_0));
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000B5A8 File Offset: 0x000097A8
		private static byte[] smethod_2(byte[] byte_0, byte[] byte_1)
		{
			checked
			{
				new byte[byte_0.Length + 1];
				int[] array = new int[257];
				int num = 0;
				int num2 = 0;
				Class12.smethod_3(byte_1, ref array);
				int num3 = byte_0.Length - 1;
				for (int i = 0; i <= num3; i++)
				{
					num = (num + 1) % 256;
					num2 = (num2 + array[num]) % 256;
					int num4 = array[num];
					array[num] = array[num2];
					array[num2] = num4;
					int value = array[(array[num] + array[num2]) % 256];
					byte_0[i] ^= Convert.ToByte(value);
				}
				return byte_0;
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000B63C File Offset: 0x0000983C
		protected static void smethod_3(byte[] byte_0, ref int[] int_0)
		{
			int num = byte_0.Length;
			int num2 = 0;
			checked
			{
				do
				{
					int_0[num2] = num2;
					num2++;
				}
				while (num2 <= 255);
				int num3 = 0;
				num2 = 0;
				do
				{
					num3 = (num3 + int_0[num2] + (int)byte_0[num2 % num]) % 256;
					int num4 = int_0[num2];
					int_0[num2] = int_0[num3];
					int_0[num3] = num4;
					num2++;
				}
				while (num2 <= 255);
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000B698 File Offset: 0x00009898
		private static byte[] smethod_4(string string_0)
		{
			ASCIIEncoding asciiencoding = new ASCIIEncoding();
			return asciiencoding.GetBytes("\0" + string_0 + "\0");
		}
	}
}
