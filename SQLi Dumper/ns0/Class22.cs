using System;
using System.Net.Sockets;

namespace ns0
{
	// Token: 0x02000029 RID: 41
	internal sealed class Class22
	{
		// Token: 0x06000193 RID: 403 RVA: 0x00010308 File Offset: 0x0000E508
		public static bool smethod_0(string string_0, int int_1, string string_1 = "")
		{
			bool result;
			try
			{
				using (TcpClient tcpClient = new TcpClient())
				{
					tcpClient.SendTimeout = 5000;
					tcpClient.ReceiveTimeout = 5000;
					IAsyncResult asyncResult = tcpClient.BeginConnect(string_0, int_1, null, null);
					asyncResult.AsyncWaitHandle.WaitOne(5000, false);
					if (tcpClient != null && tcpClient.Connected)
					{
						result = true;
						tcpClient.Close();
					}
				}
			}
			catch (Exception ex)
			{
				string_1 = ex.Message;
			}
			return result;
		}

		// Token: 0x04000105 RID: 261
		private static int int_0;
	}
}
