using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ns0
{
	// Token: 0x02000013 RID: 19
	internal sealed class Class11
	{
		// Token: 0x060000BB RID: 187 RVA: 0x0000B2EC File Offset: 0x000094EC
		public static byte[] smethod_0(byte[] byte_0, string string_0)
		{
			checked
			{
				byte[] array2;
				using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
				{
					rijndaelManaged.KeySize = 256;
					rijndaelManaged.Key = Class11.smethod_2(string_0);
					rijndaelManaged.IV = Class11.smethod_3(string_0);
					using (MemoryStream memoryStream = new MemoryStream(byte_0))
					{
						using (CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateDecryptor(), CryptoStreamMode.Read))
						{
							byte[] array = new byte[byte_0.Length + 1];
							int num = cryptoStream.Read(array, 0, byte_0.Length);
							array2 = new byte[num + 1];
							Array.Copy(array, array2, num);
							cryptoStream.Close();
						}
						memoryStream.Close();
					}
				}
				return array2;
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000B3C8 File Offset: 0x000095C8
		public static byte[] smethod_1(byte[] byte_0, string string_0)
		{
			byte[] result;
			using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
			{
				rijndaelManaged.KeySize = 256;
				rijndaelManaged.Key = Class11.smethod_2(string_0);
				rijndaelManaged.IV = Class11.smethod_3(string_0);
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateEncryptor(), CryptoStreamMode.Write))
					{
						cryptoStream.Write(byte_0, 0, byte_0.Length);
						cryptoStream.FlushFinalBlock();
						result = memoryStream.ToArray();
						cryptoStream.Close();
					}
					memoryStream.Close();
				}
			}
			return result;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000B48C File Offset: 0x0000968C
		private static byte[] smethod_2(string string_0)
		{
			string_0 = "\0" + string_0 + "\0";
			byte[] result;
			using (SHA256Managed sha256Managed = new SHA256Managed())
			{
				string str = Convert.ToBase64String(sha256Managed.ComputeHash(Encoding.UTF8.GetBytes(string_0)));
				string s = string_0 + str;
				result = sha256Managed.ComputeHash(Encoding.UTF8.GetBytes(s));
				sha256Managed.Clear();
			}
			return result;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000B50C File Offset: 0x0000970C
		private static byte[] smethod_3(string string_0)
		{
			string_0 = "\0" + string_0 + "\0";
			byte[] result;
			using (MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider())
			{
				string str = Convert.ToBase64String(md5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(string_0)));
				string s = string_0 + str;
				result = md5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(s));
				md5CryptoServiceProvider.Clear();
			}
			return result;
		}
	}
}
