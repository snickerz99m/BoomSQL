using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Web;
using Chilkat;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x02000028 RID: 40
internal sealed class HTTP
{
	// Token: 0x06000176 RID: 374 RVA: 0x0000FC0C File Offset: 0x0000DE0C
	public HTTP()
	{
		this.FollowRedirects = true;
		this.o = new Http();
		this.o.UserAgent = Conversions.ToString(global::Globals.GetObjectValue(global::Globals.GMain.txtUserAgent));
		this.o.Accept = Conversions.ToString(global::Globals.GetObjectValue(global::Globals.GMain.txtAccept));
		this.o.ConnectTimeout = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.numHTTPTimeout));
		this.o.ReadTimeout = this.o.ConnectTimeout;
		this.o.FollowRedirects = this.FollowRedirects;
		this.o.AutoAddHostHeader = true;
		this.o.AllowGzip = true;
		this.o.SendCookies = true;
		this.o.SaveCookies = true;
		this.o.CookieDir = "memory";
		this.o.UseIEProxy = false;
		this.o.MaxConnections = 500;
		this.o.MaxResponseSize = 5242880U;
		this.o.EnableEvents = true;
		this.o.KeepEventLog = false;
		this.o.OnReceiveRate += this.OnReceiveRate;
	}

	// Token: 0x17000089 RID: 137
	// (get) Token: 0x06000177 RID: 375 RVA: 0x00002960 File Offset: 0x00000B60
	// (set) Token: 0x06000178 RID: 376 RVA: 0x00002968 File Offset: 0x00000B68
	public Http o { get; set; }

	// Token: 0x1700008A RID: 138
	// (get) Token: 0x06000179 RID: 377 RVA: 0x00002971 File Offset: 0x00000B71
	// (set) Token: 0x0600017A RID: 378 RVA: 0x00002979 File Offset: 0x00000B79
	public int Status { get; set; }

	// Token: 0x1700008B RID: 139
	// (get) Token: 0x0600017B RID: 379 RVA: 0x00002982 File Offset: 0x00000B82
	// (set) Token: 0x0600017C RID: 380 RVA: 0x0000298A File Offset: 0x00000B8A
	public string StatusString { get; set; }

	// Token: 0x1700008C RID: 140
	// (get) Token: 0x0600017D RID: 381 RVA: 0x00002993 File Offset: 0x00000B93
	// (set) Token: 0x0600017E RID: 382 RVA: 0x0000299B File Offset: 0x00000B9B
	public Chilkat.HttpResponse Response { get; set; }

	// Token: 0x1700008D RID: 141
	// (get) Token: 0x0600017F RID: 383 RVA: 0x000029A4 File Offset: 0x00000BA4
	// (set) Token: 0x06000180 RID: 384 RVA: 0x000029AC File Offset: 0x00000BAC
	public Chilkat.HttpRequest Request { get; set; }

	// Token: 0x1700008E RID: 142
	// (get) Token: 0x06000181 RID: 385 RVA: 0x000029B5 File Offset: 0x00000BB5
	// (set) Token: 0x06000182 RID: 386 RVA: 0x000029BD File Offset: 0x00000BBD
	public string Proxy { get; set; }

	// Token: 0x1700008F RID: 143
	// (get) Token: 0x06000183 RID: 387 RVA: 0x000029C6 File Offset: 0x00000BC6
	// (set) Token: 0x06000184 RID: 388 RVA: 0x000029CE File Offset: 0x00000BCE
	public bool FollowRedirects { get; set; }

	// Token: 0x17000090 RID: 144
	// (get) Token: 0x06000185 RID: 389 RVA: 0x000029D7 File Offset: 0x00000BD7
	// (set) Token: 0x06000186 RID: 390 RVA: 0x000029DF File Offset: 0x00000BDF
	public string Elapsed { get; set; }

	// Token: 0x17000091 RID: 145
	// (get) Token: 0x06000187 RID: 391 RVA: 0x000029E8 File Offset: 0x00000BE8
	// (set) Token: 0x06000188 RID: 392 RVA: 0x000029F0 File Offset: 0x00000BF0
	public bool WasRedirected { get; set; }

	// Token: 0x17000092 RID: 146
	// (get) Token: 0x06000189 RID: 393 RVA: 0x000029F9 File Offset: 0x00000BF9
	// (set) Token: 0x0600018A RID: 394 RVA: 0x00002A01 File Offset: 0x00000C01
	public bool ProxyChecked { get; set; }

	// Token: 0x0600018B RID: 395 RVA: 0x00002A0A File Offset: 0x00000C0A
	private void OnReceiveRate(object sender, DataRateEventArgs e)
	{
		this.__Size = e.ByteCount;
	}

	// Token: 0x0600018C RID: 396 RVA: 0x0000FD50 File Offset: 0x0000DF50
	public string CheckProxy()
	{
		this.ProxyChecked = true;
		Class35 g_SOCKS = global::Globals.G_SOCKS;
		Http o = this.o;
		string proxy = this.Proxy;
		g_SOCKS.method_12(ref o, ref proxy);
		this.Proxy = proxy;
		this.o = o;
		return this.Proxy;
	}

	// Token: 0x0600018D RID: 397 RVA: 0x0000FD98 File Offset: 0x0000DF98
	public string QuickGet(string sUrl)
	{
		if (!this.ProxyChecked)
		{
			this.CheckProxy();
		}
		return this.ChilkatDoWork(sUrl, new List<Class24>());
	}

	// Token: 0x0600018E RID: 398 RVA: 0x0000FDC8 File Offset: 0x0000DFC8
	public string QuickPost(string sUrl, List<Class24> r)
	{
		if (!this.ProxyChecked)
		{
			this.CheckProxy();
		}
		return this.ChilkatDoWork(sUrl, r);
	}

	// Token: 0x0600018F RID: 399 RVA: 0x0000FDF4 File Offset: 0x0000DFF4
	private string ChilkatDoWork(string sUrl, List<Class24> lPost)
	{
		string text = "";
		this.StatusString = "";
		this.Status = 0;
		this.__Size = 0L;
		long long_ = global::Globals.GMain.method_207(sUrl, this.Proxy);
		this.__Elapsed = Stopwatch.StartNew();
		if (lPost.Count == 0)
		{
			try
			{
				using (StringBuilder stringBuilder = new StringBuilder())
				{
					this.o.QuickGetSb(sUrl, stringBuilder);
					text = stringBuilder.ToString();
				}
			}
			catch (Exception ex)
			{
			}
			this.WasRedirected = this.o.WasRedirected;
			this.Status = this.o.LastStatus;
			if (string.IsNullOrEmpty(text))
			{
				text = this.o.LastResponseBody;
			}
		}
		else
		{
			this.Request = new Chilkat.HttpRequest();
			this.Request.UsePost();
			this.Request.SendCharset = true;
			try
			{
				foreach (Class24 @class in lPost)
				{
					this.Request.AddParam(@class.Name, Class23.smethod_6(@class.Value));
				}
			}
			finally
			{
				List<Class24>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			try
			{
				this.Response = this.o.PostUrlEncoded(sUrl, this.Request);
			}
			catch (Exception ex2)
			{
			}
			if (this.Response != null)
			{
				text = this.Response.BodyStr;
				this.Status = this.Response.StatusCode;
			}
			else
			{
				text = "";
			}
		}
		this.o.CloseAllConnections();
		this.__Elapsed.Stop();
		if (this.__Size <= 0L)
		{
		}
		if (this.Status > 0 & this.Status != 999999)
		{
			HttpStatusCode status;
			try
			{
				status = (HttpStatusCode)this.Status;
			}
			catch (Exception ex3)
			{
			}
			if (Operators.CompareString(this.Status.ToString(), status.ToString(), false) == 0)
			{
				this.StatusString = Conversions.ToString(this.Status);
			}
			else
			{
				this.StatusString = Conversions.ToString(this.Status) + " " + status.ToString();
			}
		}
		else
		{
			this.StatusString = this.GetConnectFailReason();
		}
		this.Elapsed = Strings.FormatNumber(this.__Elapsed.Elapsed.TotalMilliseconds / 1000.0, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
		global::Globals.GMain.method_206(long_, sUrl, global::Globals.FormatBytes((double)this.__Size), this.Elapsed, this.StatusString, "");
		if (global::Globals.GStatistics != null)
		{
			global::Globals.GStatistics.method_1(Class26.Enum1.const_3, this.StatusString, 1);
		}
		if (!string.IsNullOrEmpty(text))
		{
			text = HttpUtility.HtmlDecode(text).Trim();
		}
		return text;
	}

	// Token: 0x06000190 RID: 400 RVA: 0x00010124 File Offset: 0x0000E324
	private string GetConnectFailReason()
	{
		int connectFailReason = this.o.ConnectFailReason;
		string result;
		switch (connectFailReason)
		{
		case 1:
			result = "Empty hostname";
			break;
		case 2:
			result = "DNS lookup failed";
			break;
		case 3:
			result = "DNS timeout";
			break;
		case 4:
			result = "Timeout";
			break;
		case 5:
			result = "Internal failure";
			break;
		case 6:
			result = "Timed Out";
			break;
		case 7:
			result = "Rejected";
			break;
		default:
			if (connectFailReason != 50)
			{
				switch (connectFailReason)
				{
				case 98:
					return "Async operation in progress";
				case 99:
					return "Product is not unlocked";
				case 100:
					return "TLS Error";
				case 101:
					return "Failed to send client hello";
				case 102:
					return "Unexpected handshake message";
				case 103:
					return "Failed to read server hello";
				case 104:
					return "No server certificate";
				case 105:
					return "Unexpected TLS protocol version";
				case 106:
					return "Server certificate verify failed (the server certificate is expired or the cert's signature verification failed)";
				case 107:
					return "Unacceptable TLS protocol version";
				case 109:
					return "Failed to read handshake messages";
				case 110:
					return "Failed to send client certificate handshake message";
				case 111:
					return "Failed to send client key exchange handshake message";
				case 112:
					return "Client certificate's private key not accessible";
				case 113:
					return "Failed to send client cert verify handshake message";
				case 114:
					return "Failed to send change cipher spec handshake message";
				case 115:
					return "Failed to send finished handshake message";
				case 116:
					return "Server's Finished message is invalid";
				}
				result = "Unknown\\Blocked";
			}
			else
			{
				result = "HTTP proxy authentication failure";
			}
			break;
		}
		return result;
	}

	// Token: 0x06000191 RID: 401 RVA: 0x000102B8 File Offset: 0x0000E4B8
	public void Dispose()
	{
		if (this.Request != null)
		{
			this.Request.Dispose();
		}
		if (this.Response != null)
		{
			this.Response.Dispose();
		}
		if (this.o != null)
		{
			this.o.Dispose();
		}
	}

	// Token: 0x04000102 RID: 258
	private Stopwatch __Elapsed;

	// Token: 0x04000103 RID: 259
	private long __Size;

	// Token: 0x04000104 RID: 260
	public long DW_SIZE;
}
