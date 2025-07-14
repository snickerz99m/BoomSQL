using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using Chilkat;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ns0
{
	// Token: 0x0200002A RID: 42
	internal sealed class Class23
	{
		// Token: 0x06000195 RID: 405 RVA: 0x000103A8 File Offset: 0x0000E5A8
		public static global::Globals.WebServer smethod_0(string string_0, string string_1, HTTP http_0)
		{
			global::Globals.WebServer result = global::Globals.WebServer.UNKNOW;
			if (http_0.o != null)
			{
				if (http_0.o.LastResponseHeader.ToLower().Contains("iis") | http_0.o.LastResponseHeader.ToLower().Contains("microsoft"))
				{
					result = global::Globals.WebServer.WINDOWS;
				}
				else if (string_0.Contains(".php"))
				{
					result = global::Globals.WebServer.LINUX;
				}
				else if (string_0.Contains(".asp"))
				{
					result = global::Globals.WebServer.WINDOWS;
				}
				else
				{
					result = global::Globals.WebServer.LINUX;
				}
			}
			return result;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00010424 File Offset: 0x0000E624
		public static string smethod_1(string string_0)
		{
			return SecurityElement.Escape(string_0);
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0001043C File Offset: 0x0000E63C
		public static string smethod_2(string string_0)
		{
			return SecurityElement.FromString(string_0).Text;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00010458 File Offset: 0x0000E658
		public static List<string> smethod_3(string string_0)
		{
			List<string> list = new List<string>();
			StringArray stringArray = new StringArray();
			HtmlUtil htmlUtil = new HtmlUtil();
			stringArray = htmlUtil.GetHyperlinkedUrls(string_0);
			checked
			{
				int num = stringArray.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string @string = stringArray.GetString(i);
					if (!list.Contains(@string))
					{
						list.Add(@string);
					}
				}
				return list;
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x000104BC File Offset: 0x0000E6BC
		public static List<string> smethod_4(string string_0)
		{
			List<string> list = new List<string>();
			try
			{
				string pattern = "href\\s*=\\s*(?:[\"'](?<1>[^\"']*)[\"']|(?<1>\\S+))";
				Match match = Regex.Match(string_0, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled, TimeSpan.FromSeconds(1.0));
				while (match.Success)
				{
					list.Add(match.Value);
					match = match.NextMatch();
				}
			}
			catch (Exception ex)
			{
			}
			return list;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0001052C File Offset: 0x0000E72C
		public static string smethod_5(string string_0)
		{
			return HttpUtility.HtmlDecode(string_0);
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00010544 File Offset: 0x0000E744
		public static string smethod_6(string string_0)
		{
			return HttpUtility.HtmlEncode(string_0);
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0001055C File Offset: 0x0000E75C
		public static string smethod_7(string string_0)
		{
			string result;
			if (string.IsNullOrEmpty(string_0))
			{
				result = "";
			}
			else
			{
				string_0 = string_0.Replace("  ", " ");
				result = HttpUtility.UrlEncode(string_0);
			}
			return result;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00010598 File Offset: 0x0000E798
		public static string smethod_8(string string_0)
		{
			return HttpUtility.UrlDecode(string_0);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00002A18 File Offset: 0x00000C18
		public static bool smethod_9(string string_0)
		{
			return string_0.Contains("=") && string_0.Contains("?");
		}

		// Token: 0x0600019F RID: 415 RVA: 0x000105B0 File Offset: 0x0000E7B0
		public static string smethod_10(string string_0)
		{
			Url url = new Url();
			string result;
			if (url.ParseUrl(string_0))
			{
				result = url.Host;
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x000105DC File Offset: 0x0000E7DC
		public static string smethod_11(string string_0)
		{
			string result;
			try
			{
				Uri uri = new Uri(string_0);
				result = uri.Host.Replace("www.", "");
			}
			catch (Exception ex)
			{
				result = Class23.smethod_10(string_0);
			}
			return result;
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00010630 File Offset: 0x0000E830
		public static string smethod_12(string string_0)
		{
			try
			{
				Uri uri = new Uri(string_0);
				int num = uri.Host.LastIndexOf(".");
				if (num > 0)
				{
					return uri.Host.Substring(checked(num + 1));
				}
			}
			catch (Exception ex)
			{
			}
			return "";
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00010694 File Offset: 0x0000E894
		public static bool smethod_13(string string_0, bool bool_0 = true)
		{
			try
			{
				string_0 = string_0.ToLower();
				if (bool_0)
				{
					if (string_0.Contains(".qwant."))
					{
						return false;
					}
					if (string_0.Contains(".startpage."))
					{
						return false;
					}
					if (string_0.Contains(".wenglor."))
					{
						return false;
					}
					if (string_0.Contains(".autarcon."))
					{
						return false;
					}
					if (string_0.Contains(".hyperoutlet."))
					{
						return false;
					}
					if (string_0.Contains(".utfkiev."))
					{
						return false;
					}
					if (string_0.Contains(".enermax."))
					{
						return false;
					}
					if (string_0.Contains(".cefetra."))
					{
						return false;
					}
					if (string_0.Contains("adw.sapo"))
					{
						return false;
					}
					if (string_0.Contains("pastebin."))
					{
						return false;
					}
					if (string_0.Contains("webcache."))
					{
						return false;
					}
					if (string_0.Contains("google."))
					{
						return false;
					}
					if (string_0.Contains("opera."))
					{
						return false;
					}
					if (string_0.Contains("mozilla"))
					{
						return false;
					}
					if (string_0.Contains("apple."))
					{
						return false;
					}
					if (string_0.Contains("twitter."))
					{
						return false;
					}
					if (string_0.Contains("paypal."))
					{
						return false;
					}
					if (string_0.Contains("yahoo."))
					{
						return false;
					}
					if (string_0.Contains("microsoft."))
					{
						return false;
					}
					if (string_0.Contains(".microsoft"))
					{
						return false;
					}
					if (string_0.Contains("bing."))
					{
						return false;
					}
					if (string_0.Contains("msn."))
					{
						return false;
					}
					if (string_0.Contains("youtube."))
					{
						return false;
					}
					if (string_0.Contains("ask."))
					{
						return false;
					}
					if (string_0.Contains("aol."))
					{
						return false;
					}
					if (string_0.Contains("nintendo."))
					{
						return false;
					}
					if (string_0.Contains("facebook."))
					{
						return false;
					}
					if (string_0.Contains("instagram."))
					{
						return false;
					}
					if (string_0.Contains("stackoverflow."))
					{
						return false;
					}
					if (string_0.Contains("cnet."))
					{
						return false;
					}
					if (string_0.Contains("ebay."))
					{
						return false;
					}
					if (string_0.Contains("amazon."))
					{
						return false;
					}
					if (string_0.Contains("yandex."))
					{
						return false;
					}
					if (string_0.Contains("exploit."))
					{
						return false;
					}
					if (string_0.Contains("ixquick"))
					{
						return false;
					}
					if (string_0.Contains("twitter."))
					{
						return false;
					}
					if (string_0.Contains("live."))
					{
						return false;
					}
					if (string_0.Contains("oracle."))
					{
						return false;
					}
					if (string_0.Contains("blogger."))
					{
						return false;
					}
					if (string_0.Contains("linkedin."))
					{
						return false;
					}
					if (string_0.Contains("symantec."))
					{
						return false;
					}
					if (string_0.Contains("vmware."))
					{
						return false;
					}
					if (string_0.Contains("github."))
					{
						return false;
					}
					if (string_0.Contains("sourceforge."))
					{
						return false;
					}
					if (string_0.Contains("wikipedia."))
					{
						return false;
					}
					if (string_0.Contains("rambler.ru"))
					{
						return false;
					}
					if (string_0.Contains("yandex"))
					{
						return false;
					}
					try
					{
						foreach (object value in ((IEnumerable)global::Globals.GetObjectValue(global::Globals.GMain.lstExcludeUrlWords)))
						{
							string value2 = Conversions.ToString(value);
							if (string_0.Contains(value2))
							{
								return false;
							}
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
				if (string_0.Length < 12)
				{
					return false;
				}
				if (string_0.StartsWith("http://") || string_0.StartsWith("https://"))
				{
					return true;
				}
			}
			catch (Exception ex)
			{
			}
			return false;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00010B28 File Offset: 0x0000ED28
		public static string smethod_14(string string_0)
		{
			NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(string_0);
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			checked
			{
				if (nameValueCollection != null)
				{
					int num = nameValueCollection.AllKeys.Count<string>() - 1;
					int num2 = num;
					for (int i = 0; i <= num2; i++)
					{
						string text = nameValueCollection.Keys[i];
						if (!string.IsNullOrEmpty(text))
						{
							stringBuilder.Append(text + "=");
						}
						if (i < num)
						{
							stringBuilder.Append("&");
						}
					}
				}
				string result;
				if (string.IsNullOrEmpty(stringBuilder.ToString()))
				{
					result = string_0;
				}
				else
				{
					result = stringBuilder.ToString();
				}
				return result;
			}
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00010BC8 File Offset: 0x0000EDC8
		public static string smethod_15(string string_0)
		{
			NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(string_0);
			checked
			{
				string text3;
				if (nameValueCollection != null)
				{
					int num = nameValueCollection.AllKeys.Count<string>() - 1;
					int num2 = num;
					for (int i = 0; i <= num2; i++)
					{
						string text = nameValueCollection.Keys[i];
						if (!string.IsNullOrEmpty(text))
						{
							string text2 = nameValueCollection[text].ToLower();
							if (text2.Contains("select") | text2.Contains("convert") | text2.Contains("cast(") | text2.Contains("into outfile") | text2.Contains("into dumpfile"))
							{
								string string_ = nameValueCollection[text];
								string_ = Class23.smethod_7(string_);
								Class54.smethod_1(ref string_);
								text3 = Class23.smethod_18(nameValueCollection, i, string_, false);
								break;
							}
						}
					}
				}
				if (string.IsNullOrEmpty(text3))
				{
					text3 = string_0;
				}
				return text3;
			}
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00010CA8 File Offset: 0x0000EEA8
		public static List<string> smethod_16(string string_0, string string_1, bool bool_0)
		{
			NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(string_0);
			List<string> list = new List<string>();
			checked
			{
				if (nameValueCollection != null)
				{
					int num = nameValueCollection.AllKeys.Count<string>() - 1;
					int num2 = num;
					for (int i = 0; i <= num2; i++)
					{
						string text = nameValueCollection.Keys[i];
						if (!string.IsNullOrEmpty(text) && (!bool_0 || !Versioned.IsNumeric(nameValueCollection[text])))
						{
							list.Add(Class23.smethod_18(nameValueCollection, i, string_1, false));
						}
					}
				}
				return list;
			}
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00010D2C File Offset: 0x0000EF2C
		public static List<string> smethod_17(string string_0, string string_1, bool bool_0, bool bool_1)
		{
			NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(string_0);
			List<string> list = new List<string>();
			checked
			{
				if (nameValueCollection != null)
				{
					int num = nameValueCollection.AllKeys.Count<string>() - 1;
					int num2 = num;
					for (int i = 0; i <= num2; i++)
					{
						string text = nameValueCollection.Keys[i];
						if (!string.IsNullOrEmpty(text))
						{
							if (bool_0 && Versioned.IsNumeric(nameValueCollection[text]))
							{
								list.Add(Class23.smethod_18(nameValueCollection, i, string_1, bool_1));
							}
							else if (!bool_0)
							{
								list.Add(Class23.smethod_18(nameValueCollection, i, string_1, bool_1));
							}
						}
					}
				}
				return list;
			}
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00010DC8 File Offset: 0x0000EFC8
		private static string smethod_18(NameValueCollection nameValueCollection_0, int int_0, string string_0, bool bool_0 = false)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			checked
			{
				int num = nameValueCollection_0.AllKeys.Count<string>() - 1;
				int num2 = num;
				for (int i = 0; i <= num2; i++)
				{
					string text = nameValueCollection_0.Keys[i];
					if (!string.IsNullOrEmpty(text))
					{
						if (i == int_0)
						{
							if (bool_0)
							{
								stringBuilder.Append(text + "=" + nameValueCollection_0[text] + string_0);
							}
							else
							{
								stringBuilder.Append(text + "=" + string_0);
							}
						}
						else
						{
							stringBuilder.Append(text + "=" + nameValueCollection_0[text]);
						}
					}
					if (i < num)
					{
						stringBuilder.Append("&");
					}
				}
				return stringBuilder.ToString();
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00010E8C File Offset: 0x0000F08C
		public static string smethod_19(string string_0)
		{
			checked
			{
				string result;
				try
				{
					if (string.IsNullOrEmpty(string_0))
					{
						result = "";
					}
					else
					{
						string text = string_0;
						string text2 = "";
						if (text.StartsWith("0x"))
						{
							text = text.Substring(2);
						}
						for (int i = 0; i < text.Length; i += 2)
						{
							string s = text.Substring(i, 2);
							text2 += Conversions.ToString(Strings.ChrW((int)uint.Parse(s, NumberStyles.HexNumber)));
						}
						if (text2.Contains("\u0012"))
						{
							text2 = Conversions.ToString(Conversion.Val("&H" + string_0));
						}
						result = text2;
					}
				}
				catch (Exception ex)
				{
					result = string_0;
				}
				return result;
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00010F58 File Offset: 0x0000F158
		public static string smethod_20(string string_0)
		{
			checked
			{
				string result;
				try
				{
					if (string.IsNullOrEmpty(string_0))
					{
						result = "";
					}
					else
					{
						char[] chars = string_0.ToCharArray();
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
					result = string_0;
				}
				return result;
			}
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00010FF0 File Offset: 0x0000F1F0
		public static string smethod_21(string string_0, bool bool_0, string string_1 = "+", string string_2 = "char")
		{
			checked
			{
				string result;
				try
				{
					if (string.IsNullOrEmpty(string_0))
					{
						result = "";
					}
					else
					{
						char[] chars = string_0.ToCharArray();
						byte[] bytes = Encoding.ASCII.GetBytes(chars);
						string text = "";
						int num = bytes.Length - 1;
						for (int i = 0; i <= num; i++)
						{
							if (bool_0)
							{
								if (i == 0)
								{
									text = text + string_2 + "(" + Convert.ToString(bytes[i]);
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
									string_2,
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
									string_1,
									string_2,
									"(",
									Convert.ToString(bytes[i]),
									")"
								});
							}
						}
						if (bool_0)
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

		// Token: 0x060001AB RID: 427 RVA: 0x00011144 File Offset: 0x0000F344
		public static string smethod_22(string string_0)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			CharacterCasing characterCasing = CharacterCasing.Normal;
			foreach (char c in string_0.ToCharArray())
			{
				if ("abcdefghijklmnopqrstuvwxyz".Contains(Conversions.ToString(c)))
				{
					switch (characterCasing)
					{
					case CharacterCasing.Normal:
					case CharacterCasing.Upper:
						stringBuilder.Append(char.ToLower(c));
						characterCasing = CharacterCasing.Lower;
						break;
					case CharacterCasing.Lower:
						stringBuilder.Append(char.ToUpper(c));
						characterCasing = CharacterCasing.Upper;
						break;
					}
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}
	}
}
