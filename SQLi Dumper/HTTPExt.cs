using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using DataBase;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x02000019 RID: 25
[Serializable]
public class HTTPExt
{
	// Token: 0x060000D8 RID: 216 RVA: 0x0000BCF0 File Offset: 0x00009EF0
	public HTTPExt(bool bFullIsolated, bool bSkipLog = false)
	{
		this.FollowRedirects = true;
		this.Proxy = "";
		this.TotalRequest = 0;
		this.TotalRequestFailed = 0;
		this.TimeOut = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.numHTTPTimeout));
		this.LoginUser = "";
		this.LoginPassword = "";
		try
		{
			this.__FullIsolated = bFullIsolated;
			this.__SkipHttpLog = bSkipLog;
			AppDomainSetup appDomainSetup = new AppDomainSetup();
			appDomainSetup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
			this.__AppDomain = AppDomain.CreateDomain("SQLi_Dumper_" + Guid.NewGuid().ToString(), null, appDomainSetup);
			this.__Asm = Assembly.GetExecutingAssembly();
			this.__Type = this.__Asm.GetType("DUX4.Main");
			this.__Instance = RuntimeHelpers.GetObjectValue(Activator.CreateInstance(this.__Type));
			if (this.__FullIsolated)
			{
				this.__Setup = this.__Type.GetMethod("Setup");
				this.__QuickGet = this.__Type.GetMethod("QuickGetIsolated");
				this.__CheckKeyword = this.__Type.GetMethod("CheckKeyword");
				this.__CheckSyntaxError = this.__Type.GetMethod("CheckSyntaxError");
				this.__ParseHtmlData = this.__Type.GetMethod("ParseHtmlData");
				this.__WasRedirected = this.__Type.GetMethod("WasRedirected");
				this.__Status = this.__Type.GetMethod("Status");
				this.__ContextSize = this.__Type.GetMethod("ContextSize");
				this.__TotalCall = this.__Type.GetMethod("TotalCall");
				this.__TotalSize = this.__Type.GetMethod("TotalSize");
				this.__WebServer = this.__Type.GetMethod("WebServer");
				this.__AcceptCookies = this.__Type.GetMethod("AcceptCookies");
				this.__Abort = this.__Type.GetMethod("Abort");
				this.__TryUnionBasead = this.__Type.GetMethod("TryUnionBasead");
				this.__AddQuickHeader = this.__Type.GetMethod("AddQuickHeader");
				this.__QuickPost = this.__Type.GetMethod("QuickPost");
			}
			else
			{
				this.__QuickGet = this.__Type.GetMethod("QuickGet");
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x17000072 RID: 114
	// (get) Token: 0x060000D9 RID: 217 RVA: 0x00002626 File Offset: 0x00000826
	// (set) Token: 0x060000DA RID: 218 RVA: 0x0000262E File Offset: 0x0000082E
	public bool FollowRedirects { get; set; }

	// Token: 0x17000073 RID: 115
	// (get) Token: 0x060000DB RID: 219 RVA: 0x00002637 File Offset: 0x00000837
	// (set) Token: 0x060000DC RID: 220 RVA: 0x0000263F File Offset: 0x0000083F
	public string Proxy { get; set; }

	// Token: 0x17000074 RID: 116
	// (get) Token: 0x060000DD RID: 221 RVA: 0x00002648 File Offset: 0x00000848
	// (set) Token: 0x060000DE RID: 222 RVA: 0x00002650 File Offset: 0x00000850
	public int TotalRequest { get; set; }

	// Token: 0x17000075 RID: 117
	// (get) Token: 0x060000DF RID: 223 RVA: 0x00002659 File Offset: 0x00000859
	// (set) Token: 0x060000E0 RID: 224 RVA: 0x00002661 File Offset: 0x00000861
	public int TotalRequestFailed { get; set; }

	// Token: 0x17000076 RID: 118
	// (get) Token: 0x060000E1 RID: 225 RVA: 0x0000266A File Offset: 0x0000086A
	// (set) Token: 0x060000E2 RID: 226 RVA: 0x00002672 File Offset: 0x00000872
	public int TimeOut { get; set; }

	// Token: 0x17000077 RID: 119
	// (get) Token: 0x060000E3 RID: 227 RVA: 0x0000267B File Offset: 0x0000087B
	// (set) Token: 0x060000E4 RID: 228 RVA: 0x00002683 File Offset: 0x00000883
	public string LoginUser { get; set; }

	// Token: 0x17000078 RID: 120
	// (get) Token: 0x060000E5 RID: 229 RVA: 0x0000268C File Offset: 0x0000088C
	// (set) Token: 0x060000E6 RID: 230 RVA: 0x00002694 File Offset: 0x00000894
	public string LoginPassword { get; set; }

	// Token: 0x060000E7 RID: 231 RVA: 0x0000BF7C File Offset: 0x0000A17C
	public bool AddQuickHeader(string name, string value)
	{
		bool result;
		try
		{
			result = Conversions.ToBoolean(this.__AddQuickHeader.Invoke(RuntimeHelpers.GetObjectValue(this.__Instance), new object[]
			{
				name,
				value
			}));
		}
		catch (Exception ex)
		{
		}
		return result;
	}

	// Token: 0x060000E8 RID: 232 RVA: 0x0000BFD8 File Offset: 0x0000A1D8
	public void Abort()
	{
		try
		{
			this.__Abort.Invoke(RuntimeHelpers.GetObjectValue(this.__Instance), null);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060000E9 RID: 233 RVA: 0x0000C020 File Offset: 0x0000A220
	public void SetAcceptCookies(bool b)
	{
		try
		{
			this.__AcceptCookies.Invoke(RuntimeHelpers.GetObjectValue(this.__Instance), new object[]
			{
				b
			});
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060000EA RID: 234 RVA: 0x0000C078 File Offset: 0x0000A278
	private void Setup()
	{
		try
		{
			Class35 g_SOCKS = global::Globals.G_SOCKS;
			string proxy = this.Proxy;
			byte b;
			string text;
			int num;
			string text2;
			string text3;
			g_SOCKS.method_11(ref b, ref text, ref num, ref text2, ref text3, ref proxy);
			this.Proxy = proxy;
			object[] parameters = new object[]
			{
				this.TimeOut,
				this.FollowRedirects,
				global::Globals.GetObjectValue(global::Globals.GMain.txtUserAgent),
				global::Globals.GetObjectValue(global::Globals.GMain.txtAccept),
				this.LoginUser,
				this.LoginPassword,
				b,
				text,
				num,
				text2,
				text3
			};
			this.__Setup.Invoke(RuntimeHelpers.GetObjectValue(this.__Instance), parameters);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060000EB RID: 235 RVA: 0x0000C164 File Offset: 0x0000A364
	public int WebServer()
	{
		int result;
		try
		{
			result = Conversions.ToInteger(this.__WebServer.Invoke(RuntimeHelpers.GetObjectValue(this.__Instance), null));
		}
		catch (Exception ex)
		{
		}
		return result;
	}

	// Token: 0x060000EC RID: 236 RVA: 0x0000C1B4 File Offset: 0x0000A3B4
	public int MaxCaller()
	{
		int result;
		try
		{
			result = Conversions.ToInteger(this.__TotalCall.Invoke(RuntimeHelpers.GetObjectValue(this.__Instance), null));
		}
		catch (Exception ex)
		{
		}
		return result;
	}

	// Token: 0x060000ED RID: 237 RVA: 0x0000C204 File Offset: 0x0000A404
	public long TotalSize()
	{
		long result;
		try
		{
			result = Conversions.ToLong(this.__TotalSize.Invoke(RuntimeHelpers.GetObjectValue(this.__Instance), null));
		}
		catch (Exception ex)
		{
		}
		return result;
	}

	// Token: 0x060000EE RID: 238 RVA: 0x0000C254 File Offset: 0x0000A454
	public bool WasRedirected()
	{
		bool result;
		try
		{
			result = Conversions.ToBoolean(this.__WasRedirected.Invoke(RuntimeHelpers.GetObjectValue(this.__Instance), null));
		}
		catch (Exception ex)
		{
		}
		return result;
	}

	// Token: 0x060000EF RID: 239 RVA: 0x0000C2A4 File Offset: 0x0000A4A4
	public int Status()
	{
		int result;
		try
		{
			result = Conversions.ToInteger(this.__Status.Invoke(RuntimeHelpers.GetObjectValue(this.__Instance), null));
		}
		catch (Exception ex)
		{
		}
		return result;
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x0000C2F4 File Offset: 0x0000A4F4
	public long ContextSize()
	{
		long result;
		try
		{
			result = Conversions.ToLong(this.__ContextSize.Invoke(RuntimeHelpers.GetObjectValue(this.__Instance), null));
		}
		catch (Exception ex)
		{
		}
		return result;
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x0000C344 File Offset: 0x0000A544
	public bool CheckKeyword(string url, string Keyword)
	{
		checked
		{
			bool result;
			try
			{
				this.Setup();
				object[] parameters = new object[]
				{
					url,
					Keyword
				};
				this.AddLog(url);
				object objectValue = RuntimeHelpers.GetObjectValue(this.__CheckKeyword.Invoke(RuntimeHelpers.GetObjectValue(this.__Instance), parameters));
				this.UpdateLog(url);
				if (objectValue != null)
				{
					this.TotalRequest++;
					result = Conversions.ToBoolean(objectValue);
				}
				else
				{
					this.TotalRequestFailed++;
				}
			}
			catch (Exception ex)
			{
			}
			return result;
		}
	}

	// Token: 0x060000F2 RID: 242 RVA: 0x0000C3E0 File Offset: 0x0000A5E0
	public Types CheckSyntaxError(string url)
	{
		checked
		{
			Types result;
			try
			{
				this.Setup();
				object[] parameters = new object[]
				{
					url
				};
				this.AddLog(url);
				object objectValue = RuntimeHelpers.GetObjectValue(this.__CheckSyntaxError.Invoke(RuntimeHelpers.GetObjectValue(this.__Instance), parameters));
				this.UpdateLog(url);
				if (objectValue != null)
				{
					this.TotalRequest++;
					result = (Types)Conversions.ToInteger(objectValue);
				}
				else
				{
					this.TotalRequestFailed++;
				}
			}
			catch (Exception ex)
			{
			}
			return result;
		}
	}

	// Token: 0x060000F3 RID: 243 RVA: 0x0000C478 File Offset: 0x0000A678
	public string ParseHtmlData(string url, Types dbType)
	{
		checked
		{
			string result;
			try
			{
				this.Setup();
				object[] parameters = new object[]
				{
					url,
					dbType,
					Class54.string_0
				};
				this.AddLog(url);
				object objectValue = RuntimeHelpers.GetObjectValue(this.__ParseHtmlData.Invoke(RuntimeHelpers.GetObjectValue(this.__Instance), parameters));
				this.UpdateLog(url);
				if (objectValue != null)
				{
					this.TotalRequest++;
					result = Conversions.ToString(objectValue);
				}
				else
				{
					this.TotalRequestFailed++;
					result = null;
				}
			}
			catch (Exception ex)
			{
			}
			return result;
		}
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x0000C524 File Offset: 0x0000A724
	public string QuickGet(string url)
	{
		string result = null;
		checked
		{
			try
			{
				this.Setup();
				object[] parameters = new object[]
				{
					url
				};
				this.AddLog(url);
				object objectValue = RuntimeHelpers.GetObjectValue(this.__QuickGet.Invoke(RuntimeHelpers.GetObjectValue(this.__Instance), parameters));
				this.UpdateLog(url);
				if (objectValue != null && Conversions.ToString(objectValue) != "")
				{
					int num = this.TotalRequest;
					this.TotalRequest = num + 1;
					result = Conversions.ToString(objectValue);
				}
				else
				{
					int num = this.TotalRequestFailed;
					this.TotalRequestFailed = num + 1;
				}
			}
			catch (Exception)
			{
			}
			return result;
		}
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x0000C5C4 File Offset: 0x0000A7C4
	public string QuickGet(string url, object o)
	{
		string result = "";
		checked
		{
			try
			{
				object[] parameters = new object[]
				{
					url,
					o
				};
				this.AddLog(url);
				object objectValue = RuntimeHelpers.GetObjectValue(this.__QuickGet.Invoke(RuntimeHelpers.GetObjectValue(this.__Instance), parameters));
				this.UpdateLog(url);
				if (objectValue != null && Conversions.ToString(objectValue) != "")
				{
					int num = this.TotalRequest;
					this.TotalRequest = num + 1;
					result = Conversions.ToString(objectValue);
				}
				else
				{
					int num = this.TotalRequestFailed;
					this.TotalRequestFailed = num + 1;
				}
			}
			catch (Exception)
			{
			}
			return result;
		}
	}

	// Token: 0x060000F6 RID: 246 RVA: 0x0000C668 File Offset: 0x0000A868
	public string QuickPost(string sUrl, Dictionary<string, string> r)
	{
		string result;
		return result;
	}

	// Token: 0x060000F7 RID: 247 RVA: 0x0000C678 File Offset: 0x0000A878
	public int TryUnionBasead(string url, string key, Types dbType)
	{
		int result = -1;
		checked
		{
			try
			{
				object[] parameters = new object[]
				{
					url,
					key,
					(int)dbType
				};
				this.AddLog(url);
				object objectValue = RuntimeHelpers.GetObjectValue(this.__TryUnionBasead.Invoke(RuntimeHelpers.GetObjectValue(this.__Instance), parameters));
				this.UpdateLog(url);
				if (objectValue != null)
				{
					this.TotalRequest++;
					result = Conversions.ToInteger(objectValue);
				}
				else
				{
					this.TotalRequestFailed++;
				}
			}
			catch (Exception ex)
			{
			}
			return result;
		}
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x0000C71C File Offset: 0x0000A91C
	public void Dispose()
	{
		try
		{
			AppDomain.Unload(this.__AppDomain);
		}
		catch (Exception ex)
		{
		}
		finally
		{
			this.__AppDomain = null;
			this.__Instance = null;
		}
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x0000C774 File Offset: 0x0000A974
	private void AddLog(string url)
	{
		try
		{
			if (!this.__SkipHttpLog)
			{
				this.__Stopwatch = Stopwatch.StartNew();
				this.__LogID = global::Globals.GMain.method_207(url, this.Proxy);
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060000FA RID: 250 RVA: 0x0000C7D0 File Offset: 0x0000A9D0
	private void UpdateLog(string url)
	{
		try
		{
			if (!this.__SkipHttpLog)
			{
				string string_ = Strings.FormatNumber(this.__Stopwatch.Elapsed.TotalMilliseconds / 1000.0, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
				int num = this.Status();
				string text;
				if (num > 0 & num != 999999)
				{
					HttpStatusCode httpStatusCode;
					try
					{
						httpStatusCode = (HttpStatusCode)num;
					}
					catch (Exception ex)
					{
					}
					if (Operators.CompareString(num.ToString(), httpStatusCode.ToString(), false) == 0)
					{
						text = Conversions.ToString(num);
					}
					else
					{
						text = Conversions.ToString(num) + " " + httpStatusCode.ToString();
					}
				}
				else
				{
					text = Conversions.ToString(num) + " Unknown";
				}
				long num2 = this.ContextSize();
				if (num2 <= 0L)
				{
				}
				if (num > 0 && global::Globals.GStatistics != null)
				{
					global::Globals.GStatistics.method_1(Class26.Enum1.const_3, text, 1);
				}
				global::Globals.GMain.method_206(this.__LogID, url, global::Globals.FormatBytes((double)num2), string_, text, this.Proxy);
			}
		}
		catch (Exception ex2)
		{
		}
	}

	// Token: 0x04000031 RID: 49
	private static bool DEBUG_MSG;

	// Token: 0x04000032 RID: 50
	private AppDomain __AppDomain;

	// Token: 0x04000033 RID: 51
	private object __Instance;

	// Token: 0x04000034 RID: 52
	private Type __Type;

	// Token: 0x04000035 RID: 53
	private Assembly __Asm;

	// Token: 0x04000036 RID: 54
	private MethodInfo __Setup;

	// Token: 0x04000037 RID: 55
	private MethodInfo __QuickGet;

	// Token: 0x04000038 RID: 56
	private MethodInfo __CheckKeyword;

	// Token: 0x04000039 RID: 57
	private MethodInfo __CheckSyntaxError;

	// Token: 0x0400003A RID: 58
	private MethodInfo __ParseHtmlData;

	// Token: 0x0400003B RID: 59
	private MethodInfo __WasRedirected;

	// Token: 0x0400003C RID: 60
	private MethodInfo __Status;

	// Token: 0x0400003D RID: 61
	private MethodInfo __ContextSize;

	// Token: 0x0400003E RID: 62
	private MethodInfo __TotalCall;

	// Token: 0x0400003F RID: 63
	private MethodInfo __TotalSize;

	// Token: 0x04000040 RID: 64
	private MethodInfo __WebServer;

	// Token: 0x04000041 RID: 65
	private MethodInfo __AcceptCookies;

	// Token: 0x04000042 RID: 66
	private MethodInfo __Abort;

	// Token: 0x04000043 RID: 67
	private MethodInfo __AddQuickHeader;

	// Token: 0x04000044 RID: 68
	private MethodInfo __TryUnionBasead;

	// Token: 0x04000045 RID: 69
	private MethodInfo __QuickPost;

	// Token: 0x04000046 RID: 70
	private bool __FullIsolated;

	// Token: 0x04000047 RID: 71
	private bool __SkipHttpLog;

	// Token: 0x0400004F RID: 79
	private long __LogID;

	// Token: 0x04000050 RID: 80
	private Stopwatch __Stopwatch;
}
