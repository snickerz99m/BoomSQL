using System;

// Token: 0x02000097 RID: 151
public class Link
{
	// Token: 0x0600083A RID: 2106 RVA: 0x00005752 File Offset: 0x00003952
	public Link(string sUrlSite, string sUrl, RegExpResult oResult)
	{
		this.string_0 = sUrlSite;
		this.string_1 = sUrl;
		this.regExpResult_0 = oResult;
	}

	// Token: 0x17000292 RID: 658
	// (get) Token: 0x0600083B RID: 2107 RVA: 0x00039938 File Offset: 0x00037B38
	// (set) Token: 0x0600083C RID: 2108 RVA: 0x0000576F File Offset: 0x0000396F
	public string UrlSite
	{
		get
		{
			return this.string_0;
		}
		set
		{
			this.string_0 = value;
		}
	}

	// Token: 0x17000293 RID: 659
	// (get) Token: 0x0600083D RID: 2109 RVA: 0x00039950 File Offset: 0x00037B50
	// (set) Token: 0x0600083E RID: 2110 RVA: 0x00005778 File Offset: 0x00003978
	public string Url
	{
		get
		{
			return this.string_1;
		}
		set
		{
			this.string_1 = value;
		}
	}

	// Token: 0x17000294 RID: 660
	// (get) Token: 0x0600083F RID: 2111 RVA: 0x00039968 File Offset: 0x00037B68
	// (set) Token: 0x06000840 RID: 2112 RVA: 0x00005781 File Offset: 0x00003981
	public RegExpResult Result
	{
		get
		{
			return this.regExpResult_0;
		}
		set
		{
			this.regExpResult_0 = value;
		}
	}

	// Token: 0x04000446 RID: 1094
	private string string_0;

	// Token: 0x04000447 RID: 1095
	private string string_1;

	// Token: 0x04000448 RID: 1096
	private RegExpResult regExpResult_0;
}
