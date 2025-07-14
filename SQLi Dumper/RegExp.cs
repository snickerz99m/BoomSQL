using System;
using System.Collections;
using System.Text.RegularExpressions;

// Token: 0x020000B2 RID: 178
public class RegExp : IDisposable
{
	// Token: 0x06000A42 RID: 2626 RVA: 0x00006448 File Offset: 0x00004648
	protected virtual void Dispose(bool b)
	{
		if (this.bool_0 || !b)
		{
		}
		this.bool_0 = true;
	}

	// Token: 0x06000A43 RID: 2627 RVA: 0x0000645F File Offset: 0x0000465F
	public void Dispose()
	{
		this.Dispose(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x06000A44 RID: 2628 RVA: 0x0003F5F0 File Offset: 0x0003D7F0
	public string Replace(string sPattern, string sInput, string sValue)
	{
		Regex regex = new Regex(sPattern, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
		regex.Match(sInput);
		string text = regex.Replace(sInput, sValue);
		string result;
		if (string.IsNullOrEmpty(text))
		{
			result = sInput;
		}
		else
		{
			result = text;
		}
		return result;
	}

	// Token: 0x06000A45 RID: 2629 RVA: 0x0003F628 File Offset: 0x0003D828
	public Hashtable Match(string sPattern, string sData, RegexOptions o)
	{
		Hashtable hashtable = new Hashtable();
		Regex regex = new Regex(sPattern, o);
		Match match = regex.Match(sData);
		while (match.Success)
		{
			RegExpResult regExpResult = new RegExpResult();
			regExpResult.Index = match.Index;
			regExpResult.Value = match.Groups[1].Value;
			hashtable.Add(match.Index.ToString(), regExpResult);
			match = match.NextMatch();
		}
		return hashtable;
	}

	// Token: 0x06000A46 RID: 2630 RVA: 0x0003F6A0 File Offset: 0x0003D8A0
	public Hashtable GetData(string sData, string sRegExPattern)
	{
		Hashtable hashtable = this.Match(sRegExPattern, sData, RegexOptions.IgnoreCase);
		Hashtable hashtable2 = new Hashtable();
		Hashtable result;
		if (hashtable.Count == 0)
		{
			result = hashtable2;
		}
		else
		{
			try
			{
				foreach (object obj in hashtable.Values)
				{
					RegExpResult regExpResult = (RegExpResult)obj;
					hashtable2.Add(hashtable2.Count.ToString(), regExpResult.Value);
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
			result = hashtable2;
		}
		return result;
	}

	// Token: 0x06000A47 RID: 2631 RVA: 0x0003F738 File Offset: 0x0003D938
	public string GetItemData(string sData, string sPattern, string sDefautValue = "")
	{
		Regex regex = new Regex(sPattern, RegexOptions.IgnoreCase);
		Match match = regex.Match(sData);
		while (match.Success)
		{
			if (!string.IsNullOrEmpty(match.Groups[1].Value))
			{
				return match.Groups[1].Value;
			}
			match = match.NextMatch();
		}
		return sDefautValue;
	}

	// Token: 0x06000A48 RID: 2632 RVA: 0x0003F798 File Offset: 0x0003D998
	public Hashtable SplitData(string sData, string sFind)
	{
		Hashtable hashtable = new Hashtable();
		foreach (string text in Regex.Split(sData, sFind))
		{
			if (!hashtable.Contains(text))
			{
				hashtable.Add(text, text);
			}
		}
		return hashtable;
	}

	// Token: 0x06000A49 RID: 2633 RVA: 0x0003F7E0 File Offset: 0x0003D9E0
	public Hashtable GetLinks(string sUrl, string sData, string sRegExPattern)
	{
		Hashtable hashtable = this.Match(sRegExPattern, sData, RegexOptions.IgnoreCase);
		Hashtable hashtable2 = new Hashtable();
		Hashtable result;
		if (hashtable.Count == 0)
		{
			result = hashtable2;
		}
		else if (string.IsNullOrEmpty(sUrl))
		{
			try
			{
				foreach (object obj in hashtable.Values)
				{
					RegExpResult regExpResult = (RegExpResult)obj;
					hashtable2.Add(hashtable2.Count.ToString(), regExpResult.Value);
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
			result = hashtable2;
		}
		else
		{
			string[] array = Regex.Split(sUrl, "/");
			string str = array[0] + "//" + array[2];
			try
			{
				foreach (object obj2 in hashtable.Values)
				{
					RegExpResult regExpResult2 = (RegExpResult)obj2;
					if (regExpResult2.Value.StartsWith("http://"))
					{
						hashtable2.Add(hashtable2.Count.ToString(), new Link(regExpResult2.Value, regExpResult2.Value, regExpResult2));
					}
					else
					{
						if (regExpResult2.Value.StartsWith("./"))
						{
							regExpResult2.Value = regExpResult2.Value.Replace("./", "/");
						}
						if (regExpResult2.Value.StartsWith("/") | regExpResult2.Value.StartsWith("./"))
						{
							hashtable2.Add(hashtable2.Count.ToString(), new Link(regExpResult2.Value, str + regExpResult2.Value, regExpResult2));
						}
						else
						{
							hashtable2.Add(hashtable2.Count.ToString(), new Link(regExpResult2.Value, str + "/" + regExpResult2.Value, regExpResult2));
						}
					}
				}
			}
			finally
			{
				IEnumerator enumerator2;
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
			result = hashtable2;
		}
		return result;
	}

	// Token: 0x0400050F RID: 1295
	private bool bool_0;
}
