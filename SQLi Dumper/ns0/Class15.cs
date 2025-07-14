using System;
using System.Text;

namespace ns0
{
	// Token: 0x02000017 RID: 23
	internal sealed class Class15
	{
		// Token: 0x060000CD RID: 205 RVA: 0x0000B80C File Offset: 0x00009A0C
		public static string smethod_0(string string_0)
		{
			ASCIIEncoding asciiencoding = new ASCIIEncoding();
			byte[] array = asciiencoding.GetBytes(string_0);
			array = Class15.smethod_2(array);
			return asciiencoding.GetString(array);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000B838 File Offset: 0x00009A38
		public static string smethod_1(string string_0)
		{
			ASCIIEncoding asciiencoding = new ASCIIEncoding();
			byte[] array = asciiencoding.GetBytes(string_0);
			array = Class15.smethod_3(array);
			return asciiencoding.GetString(array);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000B864 File Offset: 0x00009A64
		public static byte[] smethod_2(byte[] byte_0)
		{
			ASCIIEncoding asciiencoding = new ASCIIEncoding();
			return asciiencoding.GetBytes(Convert.ToBase64String(byte_0));
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000B888 File Offset: 0x00009A88
		public static byte[] smethod_3(byte[] byte_0)
		{
			ASCIIEncoding asciiencoding = new ASCIIEncoding();
			return Convert.FromBase64String(asciiencoding.GetString(byte_0));
		}
	}
}
