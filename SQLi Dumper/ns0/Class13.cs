using System;
using System.Security.Cryptography;
using System.Text;

namespace ns0
{
	// Token: 0x02000015 RID: 21
	internal sealed class Class13
	{
		// Token: 0x060000C6 RID: 198 RVA: 0x0000B6C4 File Offset: 0x000098C4
		public static byte[] smethod_0(byte[] byte_0, string string_0, CipherMode cipherMode_0 = CipherMode.ECB, PaddingMode paddingMode_0 = PaddingMode.PKCS7)
		{
			MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] key = md5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(string_0));
			md5CryptoServiceProvider.Clear();
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			tripleDESCryptoServiceProvider.Key = key;
			tripleDESCryptoServiceProvider.Mode = cipherMode_0;
			tripleDESCryptoServiceProvider.Padding = paddingMode_0;
			ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor();
			byte[] result = cryptoTransform.TransformFinalBlock(byte_0, 0, byte_0.Length);
			tripleDESCryptoServiceProvider.Clear();
			return result;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000B72C File Offset: 0x0000992C
		public static byte[] smethod_1(byte[] byte_0, string string_0, CipherMode cipherMode_0 = CipherMode.ECB, PaddingMode paddingMode_0 = PaddingMode.PKCS7)
		{
			MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] key = md5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(string_0));
			md5CryptoServiceProvider.Clear();
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			tripleDESCryptoServiceProvider.Key = key;
			tripleDESCryptoServiceProvider.Mode = cipherMode_0;
			tripleDESCryptoServiceProvider.Padding = paddingMode_0;
			ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
			byte[] result = cryptoTransform.TransformFinalBlock(byte_0, 0, byte_0.Length);
			tripleDESCryptoServiceProvider.Clear();
			return result;
		}
	}
}
