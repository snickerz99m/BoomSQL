using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using Chilkat;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x0200001A RID: 26
public class SearchEngine
{
	// Token: 0x060000FB RID: 251 RVA: 0x0000C93C File Offset: 0x0000AB3C
	public SearchEngine(byte host, List<string> rBlackListProxy = null)
	{
		this.__Delay = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.numScanningDelay));
		this.__ProxyIP = "MyIP";
		this.Domain = "com";
		this.MaxPages = 10;
		this.__Host = (global::Globals.SearchHost)host;
		this.__DelayControl = new Dictionary<string, Stopwatch>();
		this.BlackListProxy = rBlackListProxy;
		if (this.BlackListProxy == null)
		{
			this.ClearBlackList();
		}
		this.__HTTP = new HTTP();
	}

	// Token: 0x17000079 RID: 121
	// (get) Token: 0x060000FC RID: 252 RVA: 0x0000269D File Offset: 0x0000089D
	// (set) Token: 0x060000FD RID: 253 RVA: 0x000026A5 File Offset: 0x000008A5
	private string Domain { get; set; }

	// Token: 0x1700007A RID: 122
	// (get) Token: 0x060000FE RID: 254 RVA: 0x000026AE File Offset: 0x000008AE
	// (set) Token: 0x060000FF RID: 255 RVA: 0x000026B6 File Offset: 0x000008B6
	public bool IPS_BLACK_LISTED { get; set; }

	// Token: 0x1700007B RID: 123
	// (get) Token: 0x06000100 RID: 256 RVA: 0x000026BF File Offset: 0x000008BF
	// (set) Token: 0x06000101 RID: 257 RVA: 0x000026C7 File Offset: 0x000008C7
	public int LinksLoaded { get; set; }

	// Token: 0x1700007C RID: 124
	// (get) Token: 0x06000102 RID: 258 RVA: 0x000026D0 File Offset: 0x000008D0
	// (set) Token: 0x06000103 RID: 259 RVA: 0x000026D8 File Offset: 0x000008D8
	public int LinksLoadedLastTime { get; set; }

	// Token: 0x1700007D RID: 125
	// (get) Token: 0x06000104 RID: 260 RVA: 0x000026E1 File Offset: 0x000008E1
	// (set) Token: 0x06000105 RID: 261 RVA: 0x000026E9 File Offset: 0x000008E9
	public int DorkIndex { get; set; }

	// Token: 0x1700007E RID: 126
	// (get) Token: 0x06000106 RID: 262 RVA: 0x000026F2 File Offset: 0x000008F2
	// (set) Token: 0x06000107 RID: 263 RVA: 0x000026FA File Offset: 0x000008FA
	public int Percentage { get; set; }

	// Token: 0x1700007F RID: 127
	// (get) Token: 0x06000108 RID: 264 RVA: 0x00002703 File Offset: 0x00000903
	// (set) Token: 0x06000109 RID: 265 RVA: 0x0000270B File Offset: 0x0000090B
	public List<string> BlackListProxy { get; set; }

	// Token: 0x17000080 RID: 128
	// (get) Token: 0x0600010A RID: 266 RVA: 0x00002714 File Offset: 0x00000914
	// (set) Token: 0x0600010B RID: 267 RVA: 0x0000271C File Offset: 0x0000091C
	public int MaxPages { get; set; }

	// Token: 0x17000081 RID: 129
	// (get) Token: 0x0600010C RID: 268 RVA: 0x0000C9BC File Offset: 0x0000ABBC
	public string Host
	{
		get
		{
			return this.__Host.ToString();
		}
	}

	// Token: 0x17000082 RID: 130
	// (get) Token: 0x0600010D RID: 269 RVA: 0x0000C9DC File Offset: 0x0000ABDC
	public int HostInt
	{
		get
		{
			return (int)this.__Host;
		}
	}

	// Token: 0x17000083 RID: 131
	// (get) Token: 0x0600010E RID: 270 RVA: 0x00002725 File Offset: 0x00000925
	// (set) Token: 0x0600010F RID: 271 RVA: 0x0000272D File Offset: 0x0000092D
	public bool Canceled { get; set; }

	// Token: 0x06000110 RID: 272 RVA: 0x00002736 File Offset: 0x00000936
	public void ClearBlackList()
	{
		this.BlackListProxy = new List<string>();
		this.IPS_BLACK_LISTED = false;
	}

	// Token: 0x06000111 RID: 273 RVA: 0x0000274A File Offset: 0x0000094A
	public void Dispose()
	{
		if (this.__HTTP != null)
		{
			this.__HTTP.Dispose();
			this.__HTTP = null;
		}
	}

	// Token: 0x06000112 RID: 274 RVA: 0x00002769 File Offset: 0x00000969
	public void StopScanning()
	{
		this.__State = SearchEngine.Worker.Ide;
	}

	// Token: 0x06000113 RID: 275 RVA: 0x00002772 File Offset: 0x00000972
	public void StartScanning(string dork)
	{
		this.__NextSearchPOST = new List<Class24>();
		this.__Dork = dork;
		this.Worker_Scanner();
	}

	// Token: 0x06000114 RID: 276 RVA: 0x0000278C File Offset: 0x0000098C
	public void PauseScanning(bool state)
	{
		if (this.__State > SearchEngine.Worker.Ide)
		{
			if (state)
			{
				this.__State = SearchEngine.Worker.Paused;
			}
			else
			{
				this.__State = SearchEngine.Worker.Working;
			}
		}
	}

	// Token: 0x06000115 RID: 277 RVA: 0x000027AC File Offset: 0x000009AC
	public bool IsComplete()
	{
		return this.__State == SearchEngine.Worker.Ide;
	}

	// Token: 0x06000116 RID: 278 RVA: 0x0000C9F4 File Offset: 0x0000ABF4
	private void Worker_Delay()
	{
		if (this.__DelayControl.ContainsKey(this.__ProxyIP))
		{
			Stopwatch stopwatch = this.__DelayControl[this.__ProxyIP];
			do
			{
				Thread.Sleep(100);
				if (this.Worker_PausedOrStoped())
				{
					break;
				}
			}
			while ((long)this.__Delay > stopwatch.ElapsedMilliseconds);
		}
		else
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			this.__DelayControl.Add(this.__ProxyIP, stopwatch);
		}
	}

	// Token: 0x06000117 RID: 279 RVA: 0x0000CA64 File Offset: 0x0000AC64
	private void Worker_Proxy()
	{
		if (global::Globals.G_SOCKS.method_9() == 0)
		{
			this.__ProxyIP = "MyIP";
			this.IPS_BLACK_LISTED = this.BlackListProxy.Contains("MyIP");
		}
		else
		{
			this.__HTTP.ProxyChecked = true;
			Class35 g_SOCKS = global::Globals.G_SOCKS;
			HTTP _HTTP;
			Http o = (_HTTP = this.__HTTP).o;
			int num = g_SOCKS.method_13(ref o, ref this.__ProxyIP, this.BlackListProxy) ? 1 : 0;
			_HTTP.o = o;
			this.IPS_BLACK_LISTED = (num == 0);
			if (string.IsNullOrEmpty(this.__ProxyIP))
			{
				this.__ProxyIP = "MyIP";
			}
			else
			{
				this.__HTTP.Proxy = this.__ProxyIP;
			}
		}
		if (this.IPS_BLACK_LISTED)
		{
			this.StopScanning();
		}
	}

	// Token: 0x06000118 RID: 280 RVA: 0x000027B7 File Offset: 0x000009B7
	private bool Worker_PausedOrStoped()
	{
		while (this.__State != SearchEngine.Worker.Ide && this.__State != SearchEngine.Worker.Working)
		{
			Thread.Sleep(500);
		}
		return this.__State == SearchEngine.Worker.Ide | this.IPS_BLACK_LISTED;
	}

	// Token: 0x06000119 RID: 281 RVA: 0x0000CB20 File Offset: 0x0000AD20
	private void Worker_Scanner()
	{
		checked
		{
			try
			{
				this.__State = SearchEngine.Worker.Working;
				int maxPages = this.MaxPages;
				for (int i = 0; i <= maxPages; i++)
				{
					bool flag = false;
					List<string> links = this.GetLinks(this.__Dork, i, ref flag);
					if (links.Count <= 0 || global::Globals.GQueue.method_3(links) == 0 || !flag || this.Worker_PausedOrStoped())
					{
						break;
					}
					Thread.Sleep(100);
				}
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, null);
			}
			finally
			{
				this.StopScanning();
			}
		}
	}

	// Token: 0x0600011A RID: 282 RVA: 0x0000CBD0 File Offset: 0x0000ADD0
	private List<string> GetLinks(string sQuery, int iPage, ref bool bNextPage)
	{
		List<string> list = new List<string>();
		string address = this.GetAddress(sQuery, iPage);
		if (iPage == 0)
		{
			if (this.__Host == global::Globals.SearchHost.DuckDuckGo)
			{
				this.__NextSearchPOST = new List<Class24>();
				this.AddNextSearchPOST("q", sQuery);
				this.AddNextSearchPOST("b", "");
				this.AddNextSearchPOST("kl", "us-en");
			}
			if (this.__Host == global::Globals.SearchHost.StartPage)
			{
				this.__NextSearchPOST = new List<Class24>();
				this.AddNextSearchPOST("cmd", "process_search");
				this.AddNextSearchPOST("language", "english");
				this.AddNextSearchPOST("enginecount", "1");
				this.AddNextSearchPOST("query", sQuery.Replace("?", ""));
				this.AddNextSearchPOST("pg", "0");
			}
		}
		string text = this.LoadPage(address);
		if ((this.__Host == global::Globals.SearchHost.DuckDuckGo | this.__Host == global::Globals.SearchHost.StartPage) && this.IsValidePage(text, ref bNextPage))
		{
			this.ProcNextSearchPOST(text);
		}
		this.IsValidePage(text, ref bNextPage);
		list = this.ParseURLs(text);
		checked
		{
			this.LinksLoaded += list.Count;
			return list;
		}
	}

	// Token: 0x0600011B RID: 283 RVA: 0x0000CD00 File Offset: 0x0000AF00
	private string LoadPage(string sUrl)
	{
		string text = "";
		int num = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.numHTTPRetry));
		if (this.__TotalCalls > 50)
		{
			this.__HTTP.Dispose();
			this.__HTTP = new HTTP();
			global::Globals.ReleaseMemory();
			this.__TotalCalls = 0;
		}
		global::Globals.SearchHost _Host = this.__Host;
		switch (_Host)
		{
		case global::Globals.SearchHost.Google:
		case global::Globals.SearchHost.DuckDuckGo:
		case global::Globals.SearchHost.Bing:
			break;
		default:
			if (_Host != global::Globals.SearchHost.StartPage)
			{
				goto IL_83;
			}
			break;
		}
		this.__HTTP.o.AddQuickHeader("Upgrade-Insecure-Requests", "1");
		IL_83:
		int num2 = num;
		int i = 0;
		checked
		{
			while (i <= num2)
			{
				this.Worker_Proxy();
				this.Worker_Delay();
				if (!this.Worker_PausedOrStoped() && !this.BlackListProxy.Contains(this.__ProxyIP))
				{
					this.__HTTP.o.ClearInMemoryCookies();
					ref int ptr = ref this.__TotalCalls;
					this.__TotalCalls = ptr + 1;
					global::Globals.SearchHost _Host2 = this.__Host;
					if (_Host2 != global::Globals.SearchHost.DuckDuckGo && _Host2 != global::Globals.SearchHost.StartPage)
					{
						text = this.__HTTP.QuickGet(sUrl);
					}
					else
					{
						text = this.__HTTP.QuickPost(sUrl, this.__NextSearchPOST);
					}
					if (this.CheckedCaptcha(text))
					{
					}
					if (this.__HTTP.Status != 200)
					{
						if (this.__HTTP.Status >= 10 && true && !this.BlackListProxy.Contains(this.__ProxyIP) && Conversions.ToBoolean(global::Globals.GetObjectValue(global::Globals.GMain.chkScanningBlackListProxy)))
						{
							this.BlackListProxy.Add(this.__ProxyIP);
						}
						i++;
						continue;
					}
					this.__DelayControl[this.__ProxyIP] = Stopwatch.StartNew();
				}
				return text;
			}
			return text;
		}
	}

	// Token: 0x0600011C RID: 284 RVA: 0x0000CEB8 File Offset: 0x0000B0B8
	private void ProcNextSearchPOST(string sHtml)
	{
		this.__NextSearchPOST = new List<Class24>();
		StringBuilder stringBuilder = new StringBuilder();
		if (this.__Host == global::Globals.SearchHost.DuckDuckGo)
		{
			int num = sHtml.IndexOf("value=\"Next\"");
			if (num > 0)
			{
				sHtml = sHtml.Substring(num);
				int num2 = sHtml.IndexOf("<input name=");
				if (num2 > 0)
				{
					sHtml = sHtml.Substring(0, num2).Trim();
					foreach (string text in sHtml.Split(new char[]
					{
						'\n'
					}))
					{
						if (text.Contains("name=") & text.Contains("value="))
						{
							stringBuilder.Append(text);
						}
					}
					this.RegExpNextSearchPOST(stringBuilder.ToString());
					if (this.__NextSearchPOST.Count > 0)
					{
						this.AddNextSearchPOST("kl", "us-en");
					}
				}
			}
		}
		else if (this.__Host == global::Globals.SearchHost.StartPage)
		{
			int num3 = sHtml.IndexOf("'Searchpage pagination'>");
			if (num3 > 0)
			{
				sHtml = sHtml.Substring(num3);
				int num4 = sHtml.IndexOf("</form>");
				if (num4 > 0)
				{
					sHtml = sHtml.Substring(0, num4).Trim();
					foreach (string text2 in sHtml.Split(new char[]
					{
						'\n'
					}))
					{
						if (text2.StartsWith("<input"))
						{
							stringBuilder.Append(text2);
						}
					}
					this.RegExpNextSearchPOST(sHtml);
				}
			}
		}
	}

	// Token: 0x0600011D RID: 285 RVA: 0x0000D064 File Offset: 0x0000B264
	public void RegExpNextSearchPOST(string html)
	{
		try
		{
			foreach (object obj in Regex.Matches(html, "<input type=\"hidden\" name=\"([^\"]+)\" value=\"([^\"]+)\" /", RegexOptions.IgnoreCase))
			{
				Match match = (Match)obj;
				this.AddNextSearchPOST(match.Groups[1].Value, Class23.smethod_5(match.Groups[2].Value));
			}
		}
		finally
		{
			IEnumerator enumerator;
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
	}

	// Token: 0x0600011E RID: 286 RVA: 0x0000D0F0 File Offset: 0x0000B2F0
	private void AddNextSearchPOST(string sName, string sValue)
	{
		Class24 @class = new Class24();
		@class.Name = sName;
		@class.Value = sValue;
		this.__NextSearchPOST.Add(@class);
	}

	// Token: 0x0600011F RID: 287 RVA: 0x0000D120 File Offset: 0x0000B320
	private string GetAddress(string sQuery, int iPage)
	{
		StringBuilder stringBuilder = new StringBuilder();
		checked
		{
			switch (this.__Host)
			{
			case global::Globals.SearchHost.Google:
				stringBuilder.Append("https://www.google." + this.Domain + "/search?");
				stringBuilder.Append("newwindow=1");
				stringBuilder.Append("&site=");
				stringBuilder.Append("&q=" + Class23.smethod_7(sQuery));
				stringBuilder.Append("&start=" + Conversions.ToString(iPage * 100));
				stringBuilder.Append("&num=100");
				break;
			case global::Globals.SearchHost.DuckDuckGo:
				stringBuilder.Append("https://duckduckgo." + this.Domain + "/html/");
				break;
			case global::Globals.SearchHost.Bing:
				stringBuilder.Append("http://www.bing." + this.Domain + "/search?");
				stringBuilder.Append("q=" + Class23.smethod_7(sQuery));
				if (iPage > 0)
				{
					stringBuilder.Append("&first=" + Conversions.ToString(iPage * 50));
				}
				stringBuilder.Append("&count=50");
				break;
			case global::Globals.SearchHost.Yahoo:
				stringBuilder.Append("http://search.yahoo." + this.Domain + "/search?");
				stringBuilder.Append("&p=" + Class23.smethod_7(sQuery));
				if (iPage > 0)
				{
					stringBuilder.Append("&b=" + Conversions.ToString(iPage + 10));
				}
				break;
			case global::Globals.SearchHost.Ask:
				stringBuilder.Append("http://www.ask." + this.Domain + "/web?");
				stringBuilder.Append("q=" + Class23.smethod_7(sQuery));
				if (iPage > 0)
				{
					stringBuilder.Append("&page=" + Conversions.ToString(iPage + 1));
				}
				break;
			case global::Globals.SearchHost.AOL:
				stringBuilder.Append("http://search.aol." + this.Domain + "/aol/search?");
				stringBuilder.Append("query=" + Class23.smethod_7(sQuery));
				if (iPage > 0)
				{
					stringBuilder.Append("&page=" + Conversions.ToString(iPage + 1));
				}
				break;
			case global::Globals.SearchHost.WOW:
				stringBuilder.Append("http://search.wow." + this.Domain + "/search?");
				stringBuilder.Append("q=" + Class23.smethod_7(sQuery));
				if (iPage > 0)
				{
					stringBuilder.Append("&page=" + Conversions.ToString(iPage + 1));
				}
				break;
			case global::Globals.SearchHost.StartPage:
				stringBuilder.Append("https://s2-eu4.startpage.com/do/search");
				break;
			case global::Globals.SearchHost.Yandex:
				stringBuilder.Append("https://www.yandex.com/search/?");
				stringBuilder.Append("text=" + Class23.smethod_7(sQuery));
				if (iPage > 0)
				{
					stringBuilder.Append("&p=" + Conversions.ToString(iPage));
				}
				break;
			case global::Globals.SearchHost.Rambler:
				stringBuilder.Append("https://nova.rambler.ru/search?");
				stringBuilder.Append("query=" + Class23.smethod_7(sQuery));
				stringBuilder.Append("&suggest=false");
				stringBuilder.Append("&page=" + Conversions.ToString(iPage));
				break;
			case global::Globals.SearchHost.Search:
				stringBuilder.Append("https://www.search.com/web?");
				stringBuilder.Append("q=" + Class23.smethod_7(sQuery));
				if (iPage > 0)
				{
					stringBuilder.Append("&page=" + Conversions.ToString(iPage + 1));
				}
				break;
			}
			return stringBuilder.ToString();
		}
	}

	// Token: 0x06000120 RID: 288 RVA: 0x0000D4C0 File Offset: 0x0000B6C0
	private bool IsValidePage(string sData, ref bool bNextPage)
	{
		bool result;
		switch (this.__Host)
		{
		case global::Globals.SearchHost.Google:
			bNextPage = sData.ToLower().Contains("display:block;margin-left:53px".ToLower());
			result = sData.ToLower().Contains("resultStats".ToLower());
			break;
		case global::Globals.SearchHost.DuckDuckGo:
			bNextPage = sData.ToLower().Contains("value=\"Next\"".ToLower());
			result = sData.ToLower().Contains("id=\"search_button_homepage\"".ToLower());
			break;
		case global::Globals.SearchHost.Bing:
			bNextPage = sData.ToLower().Contains("sb_pagN".ToLower());
			result = sData.ToLower().Contains("schemas.live.com/Web/".ToLower());
			break;
		case global::Globals.SearchHost.Yahoo:
			bNextPage = sData.ToLower().Contains("class=\"next".ToLower());
			result = sData.ToLower().Contains(".query.yahoo.com".ToLower());
			break;
		case global::Globals.SearchHost.Ask:
			bNextPage = sData.ToLower().Contains("pagination-next".ToLower());
			result = sData.ToLower().Contains("ask-search.xml".ToLower());
			break;
		case global::Globals.SearchHost.AOL:
			bNextPage = sData.ToLower().Contains(">Next</".ToLower());
			result = sData.ToLower().Contains("compPagination".ToLower());
			break;
		case global::Globals.SearchHost.WOW:
			bNextPage = sData.ToLower().Contains(">Next</".ToLower());
			result = sData.ToLower().Contains(".compImageProfile".ToLower());
			break;
		case global::Globals.SearchHost.StartPage:
			bNextPage = sData.ToLower().Contains("pagination__next-prev-button".ToLower());
			result = sData.ToLower().Contains("data-component-base".ToLower());
			break;
		case global::Globals.SearchHost.Yandex:
			bNextPage = sData.ToLower().Contains(">next<".ToLower());
			result = sData.ToLower().Contains("class=i-ua_js_no".ToLower());
			break;
		case global::Globals.SearchHost.Rambler:
			bNextPage = sData.ToLower().Contains("pager::page_next".ToLower());
			result = sData.ToLower().Contains("images.rambler.ru".ToLower());
			break;
		case global::Globals.SearchHost.Search:
			bNextPage = sData.ToLower().Contains("\"show-more-button\"".ToLower());
			result = sData.ToLower().Contains("og:description".ToLower());
			break;
		}
		return result;
	}

	// Token: 0x06000121 RID: 289 RVA: 0x0000D728 File Offset: 0x0000B928
	private bool CheckedCaptcha(string sData)
	{
		if (!string.IsNullOrEmpty(sData))
		{
			switch (this.__Host)
			{
			case global::Globals.SearchHost.Google:
				return sData.ToLower().Contains("google.com/websearch/answer/86640".ToLower());
			case global::Globals.SearchHost.Yandex:
				return sData.ToLower().Contains("action=\"/checkcaptcha".ToLower());
			}
		}
		return false;
	}

	// Token: 0x06000122 RID: 290 RVA: 0x0000D7A8 File Offset: 0x0000B9A8
	private List<string> ParseURLs(string sData)
	{
		int num2;
		List<string> result;
		int num4;
		object obj;
		try
		{
			IL_02:
			int num = 1;
			List<string> list = new List<string>();
			IL_0A:
			num = 2;
			sData = Class23.smethod_5(sData);
			IL_16:
			num = 3;
			if (this.__Host != global::Globals.SearchHost.StartPage)
			{
				goto IL_2E;
			}
			IL_23:
			num = 4;
			List<string> list2 = Class23.smethod_4(sData);
			goto IL_37;
			IL_2E:
			num = 6;
			list2 = Class23.smethod_3(sData);
			IL_37:
			ProjectData.ClearProjectError();
			num2 = -2;
			IL_3F:
			num = 9;
			List<string>.Enumerator enumerator = list2.GetEnumerator();
			checked
			{
				while (enumerator.MoveNext())
				{
					string text = enumerator.Current;
					IL_5F:
					num = 10;
					switch (this.__Host)
					{
					case global::Globals.SearchHost.Google:
					case global::Globals.SearchHost.DuckDuckGo:
					case global::Globals.SearchHost.Bing:
					case global::Globals.SearchHost.Ask:
					case global::Globals.SearchHost.Rambler:
						goto IL_2D7;
					case global::Globals.SearchHost.Yahoo:
						IL_A2:
						num = 15;
						if (!text.Contains("srpcache"))
						{
							IL_B6:
							num = 17;
							if (text.Contains("RU="))
							{
								IL_C7:
								num = 18;
								text = text.Substring(text.IndexOf("RU=") + "RU=".Length);
							}
							IL_EA:
							num = 20;
							if (text.IndexOf("RK=") > 1)
							{
								IL_FE:
								num = 21;
								text = text.Substring(0, text.IndexOf("RK=") - 1);
							}
							IL_119:
							num = 23;
							text = Class23.smethod_8(text);
							goto IL_2D7;
						}
						break;
					case global::Globals.SearchHost.AOL:
					case global::Globals.SearchHost.WOW:
						IL_12A:
						num = 26;
						if (text.Contains("RU="))
						{
							IL_13B:
							num = 27;
							text = text.Substring(text.IndexOf("RU=") + "RU=".Length);
						}
						IL_15E:
						num = 29;
						if (text.IndexOf("/RK=") > 1)
						{
							IL_172:
							num = 30;
							text = text.Substring(0, text.IndexOf("/RK=") - 1);
						}
						IL_18D:
						num = 32;
						text = Class23.smethod_8(text);
						goto IL_2D7;
					case global::Globals.SearchHost.StartPage:
						IL_19E:
						num = 34;
						text = text.Replace("href=", "");
						IL_1B4:
						num = 35;
						text = text.Replace("\"", "");
						goto IL_2D7;
					case global::Globals.SearchHost.Yandex:
						IL_1CF:
						num = 37;
						if (text.Contains("url="))
						{
							IL_1E0:
							num = 38;
							text = text.Substring(text.IndexOf("url=") + "url=".Length);
						}
						IL_203:
						num = 40;
						if (text.IndexOf("&") > 1)
						{
							IL_217:
							num = 41;
							text = text.Substring(0, text.IndexOf("&") - 1);
						}
						IL_232:
						num = 43;
						text = Class23.smethod_8(text);
						goto IL_2D7;
					case global::Globals.SearchHost.Search:
						IL_243:
						num = 46;
						if (text.Contains("surl="))
						{
							IL_254:
							num = 47;
							text = text.Substring(text.IndexOf("surl=") + "surl=".Length);
						}
						IL_277:
						num = 49;
						if (text.IndexOf("&") > 1)
						{
							IL_28B:
							num = 50;
							text = text.Substring(0, text.IndexOf("&") - 1);
						}
						IL_2A6:
						num = 52;
						text = Class23.smethod_8(text);
						goto IL_2D7;
					default:
						goto IL_2D7;
					}
					IL_2CF:
					num = 59;
					continue;
					IL_2D7:
					num = 54;
					if (!Class23.smethod_13(text, true))
					{
						goto IL_2CF;
					}
					IL_2B4:
					num = 55;
					if (!list.Contains(text))
					{
						IL_2C4:
						num = 56;
						list.Add(text);
						goto IL_2CF;
					}
					goto IL_2CF;
				}
				IL_2E6:
				num = 60;
				((IDisposable)enumerator).Dispose();
				IL_2F6:
				num = 61;
				result = list;
				IL_2FC:
				goto IL_452;
				IL_301:;
			}
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_409:
			goto IL_447;
			IL_40B:
			num4 = num;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num2 > -2) ? num2 : 1);
			IL_424:;
		}
		catch when (endfilter(obj is Exception & num2 != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_40B;
		}
		IL_447:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_452:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
		return result;
	}

	// Token: 0x04000051 RID: 81
	private global::Globals.SearchHost __Host;

	// Token: 0x04000052 RID: 82
	private SearchEngine.Worker __State;

	// Token: 0x04000053 RID: 83
	private string __Dork;

	// Token: 0x04000054 RID: 84
	private Dictionary<string, Stopwatch> __DelayControl;

	// Token: 0x04000055 RID: 85
	private int __Delay;

	// Token: 0x04000056 RID: 86
	private List<Class24> __NextSearchPOST;

	// Token: 0x04000057 RID: 87
	private HTTP __HTTP;

	// Token: 0x04000058 RID: 88
	private string __ProxyIP;

	// Token: 0x04000059 RID: 89
	private int __TotalCalls;

	// Token: 0x0200001B RID: 27
	public enum Worker
	{
		// Token: 0x04000064 RID: 100
		Ide,
		// Token: 0x04000065 RID: 101
		Working,
		// Token: 0x04000066 RID: 102
		Paused
	}
}
