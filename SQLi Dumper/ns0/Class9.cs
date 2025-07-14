using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Cryptor;
using Microsoft.VisualBasic.CompilerServices;

namespace ns0
{
	// Token: 0x02000011 RID: 17
	internal sealed class Class9
	{
		// Token: 0x060000AF RID: 175 RVA: 0x0000AEAC File Offset: 0x000090AC
		public static byte[] smethod_0(string string_0)
		{
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			return unicodeEncoding.GetBytes(string_0);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000AEC8 File Offset: 0x000090C8
		public static string smethod_1(byte[] byte_0)
		{
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			return unicodeEncoding.GetString(byte_0);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000AEE4 File Offset: 0x000090E4
		public static byte[] smethod_2(string string_0, string string_1, Method method_0 = Method.RC4, bool bool_0 = false)
		{
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			byte[] array = unicodeEncoding.GetBytes(string_0);
			switch (method_0)
			{
			case Method.RijnDael:
				array = Class11.smethod_1(array, string_1);
				break;
			case Method.RC4:
				array = Class12.smethod_0(array, string_1);
				break;
			case Method.MD5:
				array = Class13.smethod_0(array, string_1, CipherMode.ECB, PaddingMode.PKCS7);
				break;
			case Method.const_3:
				array = Class14.smethod_0(array, string_1);
				break;
			}
			if (bool_0)
			{
				array = Class10.smethod_0(array);
			}
			return array;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000AF50 File Offset: 0x00009150
		public static string smethod_3(string string_0, string string_1, Method method_0 = Method.RC4, bool bool_0 = false)
		{
			ASCIIEncoding asciiencoding = new ASCIIEncoding();
			byte[] array = asciiencoding.GetBytes(string_0);
			switch (method_0)
			{
			case Method.RijnDael:
				array = Class11.smethod_1(array, string_1);
				break;
			case Method.RC4:
				array = Class12.smethod_0(array, string_1);
				break;
			case Method.MD5:
				array = Class13.smethod_0(array, string_1, CipherMode.ECB, PaddingMode.PKCS7);
				break;
			case Method.const_3:
				array = Class14.smethod_0(array, string_1);
				break;
			}
			if (bool_0)
			{
				array = Class10.smethod_0(array);
			}
			return Convert.ToBase64String(array);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000AFC0 File Offset: 0x000091C0
		public static string smethod_4(byte[] byte_0, string string_0, Method method_0 = Method.RC4, bool bool_0 = false)
		{
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			byte[] array = byte_0;
			if (bool_0)
			{
				array = Class10.smethod_1(array);
			}
			switch (method_0)
			{
			case Method.RijnDael:
				array = Class11.smethod_0(array, string_0);
				break;
			case Method.RC4:
				array = Class12.smethod_1(array, string_0);
				break;
			case Method.MD5:
				array = Class13.smethod_1(array, string_0, CipherMode.ECB, PaddingMode.PKCS7);
				break;
			case Method.const_3:
				array = Class14.smethod_1(array, string_0);
				break;
			}
			return unicodeEncoding.GetString(array);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000B02C File Offset: 0x0000922C
		public static string smethod_5(string string_0, string string_1, Method method_0 = Method.RC4, bool bool_0 = false)
		{
			ASCIIEncoding asciiencoding = new ASCIIEncoding();
			byte[] array = Convert.FromBase64String(string_0);
			if (bool_0)
			{
				array = Class10.smethod_1(array);
			}
			switch (method_0)
			{
			case Method.RijnDael:
				array = Class11.smethod_0(array, string_1);
				break;
			case Method.RC4:
				array = Class12.smethod_1(array, string_1);
				break;
			case Method.MD5:
				array = Class13.smethod_1(array, string_1, CipherMode.ECB, PaddingMode.PKCS7);
				break;
			case Method.const_3:
				array = Class14.smethod_1(array, string_1);
				break;
			}
			return asciiencoding.GetString(array);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000B09C File Offset: 0x0000929C
		public static bool smethod_6(string string_0, Method method_0, string string_1)
		{
			bool result;
			if (!File.Exists(string_0))
			{
				result = true;
			}
			else
			{
				byte[] array = File.ReadAllBytes(string_0);
				if (array.Length == 0)
				{
					result = true;
				}
				else
				{
					switch (method_0)
					{
					case Method.RijnDael:
						array = Class11.smethod_1(array, string_1);
						break;
					case Method.RC4:
						array = Class12.smethod_0(array, string_1);
						break;
					case Method.MD5:
						array = Class13.smethod_0(array, string_1, CipherMode.ECB, PaddingMode.PKCS7);
						break;
					case Method.const_3:
						array = Class14.smethod_0(array, string_1);
						break;
					}
					array = (byte[])Utils.CopyArray(array, new byte[checked(array.Length - 1 + 1)]);
					array = Class10.smethod_0(array);
					File.Delete(string_0);
					File.WriteAllBytes(string_0, array);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000B140 File Offset: 0x00009340
		public static bool smethod_7(string string_0, Method method_0, string string_1)
		{
			bool result;
			if (!File.Exists(string_0))
			{
				result = true;
			}
			else
			{
				byte[] array = File.ReadAllBytes(string_0);
				if (array.Length == 0)
				{
					result = true;
				}
				else
				{
					array = Class10.smethod_1(array);
					switch (method_0)
					{
					case Method.RijnDael:
						array = Class11.smethod_0(array, string_1);
						break;
					case Method.RC4:
						array = Class12.smethod_1(array, string_1);
						break;
					case Method.MD5:
						array = Class13.smethod_1(array, string_1, CipherMode.ECB, PaddingMode.PKCS7);
						break;
					case Method.const_3:
						array = Class14.smethod_1(array, string_1);
						break;
					}
					File.Delete(string_0);
					File.WriteAllBytes(string_0, array);
					result = true;
				}
			}
			return result;
		}
	}
}
