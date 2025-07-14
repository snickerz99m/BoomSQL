using System;
using System.IO;
using System.IO.Compression;

namespace ns0
{
	// Token: 0x02000012 RID: 18
	internal sealed class Class10
	{
		// Token: 0x060000B8 RID: 184 RVA: 0x0000B1C8 File Offset: 0x000093C8
		public static byte[] smethod_0(byte[] byte_0)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionLevel.Optimal))
				{
					gzipStream.Write(byte_0, 0, byte_0.Length);
					gzipStream.Close();
					byte_0 = new byte[checked(memoryStream.ToArray().Length - 1 + 1)];
					byte_0 = memoryStream.ToArray();
				}
				memoryStream.Close();
			}
			return byte_0;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000B250 File Offset: 0x00009450
		public static byte[] smethod_1(byte[] byte_0)
		{
			byte[] result;
			using (GZipStream gzipStream = new GZipStream(new MemoryStream(byte_0), CompressionMode.Decompress))
			{
				int num = 4096;
				byte[] array = new byte[checked(num - 1 + 1)];
				using (MemoryStream memoryStream = new MemoryStream())
				{
					int num2;
					do
					{
						num2 = gzipStream.Read(array, 0, num);
						if (num2 > 0)
						{
							memoryStream.Write(array, 0, num2);
						}
					}
					while (num2 > 0);
					result = memoryStream.ToArray();
				}
			}
			return result;
		}
	}
}
