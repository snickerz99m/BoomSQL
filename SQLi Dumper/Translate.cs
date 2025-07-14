using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x0200001C RID: 28
public class Translate
{
	// Token: 0x06000123 RID: 291 RVA: 0x0000DC30 File Offset: 0x0000BE30
	public Translate()
	{
		this.__Languages = new List<string>();
		this.__Index = -1;
		this.__Languages = new List<string>();
		if (!File.Exists(global::Globals.LNG_PATH + "\\Portuguese.xml"))
		{
			File.WriteAllText(global::Globals.LNG_PATH + "\\Portuguese.xml", Class6.Portuguese);
		}
		if (!File.Exists(global::Globals.LNG_PATH + "\\Russian.xml"))
		{
			File.WriteAllText(global::Globals.LNG_PATH + "\\Russian.xml", Class6.Russian);
		}
		if (!File.Exists(global::Globals.LNG_PATH + "\\German.xml"))
		{
			File.WriteAllText(global::Globals.LNG_PATH + "\\German.xml", Class6.German);
		}
		if (!File.Exists(global::Globals.LNG_PATH + "\\Persian.xml"))
		{
			File.WriteAllText(global::Globals.LNG_PATH + "\\Persian.xml", Class6.Persian);
		}
		if (!File.Exists(global::Globals.LNG_PATH + "\\French.xml"))
		{
			File.WriteAllText(global::Globals.LNG_PATH + "\\French.xml", Class6.French);
		}
		foreach (string item in Directory.GetFiles(global::Globals.LNG_PATH, "*.xml"))
		{
			this.__Languages.Add(item);
		}
	}

	// Token: 0x06000124 RID: 292 RVA: 0x0000DD8C File Offset: 0x0000BF8C
	public bool SetLanguage(string n)
	{
		checked
		{
			int num = this.__Languages.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				string path = this.__Languages[i];
				if (Path.GetFileNameWithoutExtension(path).Equals(n))
				{
					return this.SetLanguage(i);
				}
			}
			return this.SetLanguage(0);
		}
	}

	// Token: 0x06000125 RID: 293 RVA: 0x0000DDE4 File Offset: 0x0000BFE4
	public bool SetLanguage(int i)
	{
		bool result;
		if (i <= checked(this.__Languages.Count - 1) && i != this.__Index)
		{
			this.class51_0 = new Class51(this.__Languages[i], "SQLi_Dumper", ';', 0);
			this.__Index = i;
			result = true;
		}
		return result;
	}

	// Token: 0x06000126 RID: 294 RVA: 0x0000DE40 File Offset: 0x0000C040
	public List<string> GetLanguages()
	{
		List<string> list = new List<string>();
		try
		{
			foreach (string path in this.__Languages)
			{
				list.Add(Path.GetFileNameWithoutExtension(path));
			}
		}
		finally
		{
			List<string>.Enumerator enumerator;
			((IDisposable)enumerator).Dispose();
		}
		return list;
	}

	// Token: 0x06000127 RID: 295 RVA: 0x0000DEA4 File Offset: 0x0000C0A4
	public string GetLanguage()
	{
		string result;
		if (this.__Index <= checked(this.__Languages.Count - 1))
		{
			result = Path.GetFileNameWithoutExtension(this.__Languages[this.__Index]);
		}
		else
		{
			result = "";
		}
		return result;
	}

	// Token: 0x06000128 RID: 296 RVA: 0x0000DEEC File Offset: 0x0000C0EC
	public void Add(Form oForm, IContainer oComp)
	{
		checked
		{
			try
			{
				object obj = oForm;
				List<object> list = this.FindAllControls(ref obj);
				oForm = (Form)obj;
				List<object> list2 = list;
				if (oComp != null && oComp.Components != null)
				{
					list2.AddRange(this.FindAllComponents(oComp.Components));
				}
				try
				{
					foreach (object obj2 in list2)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(obj2);
						if (objectValue != null)
						{
							string text = Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null));
							string text2 = Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Text", new object[0], null, null, null));
							if (!string.IsNullOrEmpty(text))
							{
								bool flag;
								if ((flag = true) == objectValue is ListViewExt || flag == objectValue is ListViewExt)
								{
									int num = ((ListViewExt)objectValue).Columns.Count - 1;
									for (int i = 0; i <= num; i++)
									{
										((ListViewExt)objectValue).Columns[i].Text = global::Globals.FormatStr(Class50.smethod_5(oForm.Name + "." + text, i.ToString(), ((ListViewExt)objectValue).Columns[i].Text, this.class51_0));
									}
								}
								else if (flag == objectValue is DataGridView)
								{
									int num2 = 0;
									int num3 = ((DataGridView)objectValue).ColumnCount - 1;
									for (int j = 0; j <= num3; j++)
									{
										if (((DataGridView)objectValue).Columns[j].CellType == typeof(DataGridViewTextBoxCell))
										{
											((DataGridView)objectValue).Columns[j].HeaderText = global::Globals.FormatStr(Class50.smethod_5(oForm.Name + "." + text, num2.ToString(), ((DataGridView)objectValue).Columns[j].HeaderText, this.class51_0));
											num2++;
										}
									}
								}
								else if (flag == objectValue is TabControl)
								{
									int num4 = ((TabControl)objectValue).TabPages.Count - 1;
									for (int k = 0; k <= num4; k++)
									{
										((TabControl)objectValue).TabPages[k].Text = global::Globals.FormatStr(Class50.smethod_5(oForm.Name + "." + text, k.ToString(), ((TabControl)objectValue).TabPages[k].Text, this.class51_0));
									}
								}
								else if (!string.IsNullOrEmpty(text2))
								{
									text2 = global::Globals.FormatStr(Class50.smethod_5(oForm.Name, text, text2, this.class51_0));
									if (!string.IsNullOrEmpty(text2))
									{
										NewLateBinding.LateSet(objectValue, null, "Text", new object[]
										{
											text2
										}, null, null);
										if (objectValue is ToolStripItem)
										{
											((ToolStripItem)objectValue).ToolTipText = text2;
										}
									}
								}
							}
						}
					}
				}
				finally
				{
					List<object>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.Message, (MsgBoxStyle)Conversions.ToInteger("Translate Error"), null);
				this.SetLanguage("English");
			}
		}
	}

	// Token: 0x06000129 RID: 297 RVA: 0x000027EC File Offset: 0x000009EC
	public void Save()
	{
	}

	// Token: 0x0600012A RID: 298 RVA: 0x0000E290 File Offset: 0x0000C490
	public string GetStr(string n, int i, string sDefValue = "")
	{
		string result;
		if (this.__Index == -1)
		{
			result = sDefValue;
		}
		else
		{
			string text = Class50.smethod_5(n, i.ToString(), sDefValue, this.class51_0);
			if (text.EndsWith(":"))
			{
				text += " ";
			}
			if (string.IsNullOrEmpty(text))
			{
				Interaction.MsgBox(string.Concat(new string[]
				{
					"GetStr(",
					n,
					", ",
					i.ToString(),
					") NOT FOUND STRING!"
				}), MsgBoxStyle.OkOnly, null);
			}
			result = global::Globals.FormatStr(text);
		}
		return result;
	}

	// Token: 0x0600012B RID: 299 RVA: 0x0000E324 File Offset: 0x0000C524
	public string GetStr(Form f, int i, string sDefValue = "")
	{
		string result;
		if (string.IsNullOrEmpty(f.Name))
		{
			result = sDefValue;
		}
		else
		{
			result = this.GetStr(f.Name + ".Strings", i, sDefValue);
		}
		return result;
	}

	// Token: 0x0600012C RID: 300 RVA: 0x0000E35C File Offset: 0x0000C55C
	public string GetStr(string form, string name, string sDefValue = "")
	{
		string result;
		if (string.IsNullOrEmpty(name) | string.IsNullOrEmpty(form))
		{
			result = sDefValue;
		}
		else
		{
			result = Class50.smethod_5(form, name, sDefValue, this.class51_0);
		}
		return result;
	}

	// Token: 0x0600012D RID: 301 RVA: 0x0000E38C File Offset: 0x0000C58C
	private List<object> FindAllControls(ref object o)
	{
		List<object> list = new List<object>();
		Control.ControlCollection controls;
		if (o is Form)
		{
			controls = ((Form)o).Controls;
		}
		else
		{
			controls = ((Control)o).Controls;
		}
		try
		{
			foreach (object obj in controls)
			{
				Control control = (Control)obj;
				bool flag;
				if ((flag = true) == control is ToolStrip)
				{
					try
					{
						foreach (object obj2 in ((ToolStrip)control).Items)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(obj2);
							if (objectValue is ToolStripButton | objectValue is ToolStripLabel)
							{
								list.Add(RuntimeHelpers.GetObjectValue(objectValue));
							}
						}
						continue;
					}
					finally
					{
						IEnumerator enumerator2;
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
				}
				if (flag == control is ContextMenuStrip)
				{
					try
					{
						foreach (object obj3 in ((ContextMenuStrip)control).Items)
						{
							object objectValue2 = RuntimeHelpers.GetObjectValue(obj3);
							if (objectValue2 is ToolStripButton | objectValue2 is ToolStripLabel)
							{
								list.Add(RuntimeHelpers.GetObjectValue(objectValue2));
							}
							list.Add(RuntimeHelpers.GetObjectValue(objectValue2));
						}
						continue;
					}
					finally
					{
						IEnumerator enumerator3;
						if (enumerator3 is IDisposable)
						{
							(enumerator3 as IDisposable).Dispose();
						}
					}
				}
				if (flag == control is DataGridView)
				{
					list.Add(control);
				}
				else if (flag == control is TabControl)
				{
					list.Add(control);
					List<object> list2 = list;
					object obj4 = control;
					List<object> collection = this.FindAllControls(ref obj4);
					control = (Control)obj4;
					list2.AddRange(collection);
				}
				else if (flag == control is TabPage)
				{
					List<object> list3 = list;
					object obj4 = control;
					List<object> collection = this.FindAllControls(ref obj4);
					control = (Control)obj4;
					list3.AddRange(collection);
				}
				else if (flag == control.HasChildren)
				{
					if (control is GroupBox)
					{
						list.Add(control);
					}
					List<object> list4 = list;
					object obj4 = control;
					List<object> collection = this.FindAllControls(ref obj4);
					control = (Control)obj4;
					list4.AddRange(collection);
				}
				else if (flag == control.Controls.Count > 0)
				{
					List<object> list5 = list;
					object obj4 = control;
					List<object> collection = this.FindAllControls(ref obj4);
					control = (Control)obj4;
					list5.AddRange(collection);
				}
				else
				{
					list.Add(control);
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
		return list;
	}

	// Token: 0x0600012E RID: 302 RVA: 0x0000E650 File Offset: 0x0000C850
	private List<object> FindAllComponents(ComponentCollection c)
	{
		List<object> list = new List<object>();
		try
		{
			foreach (object obj in c)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(obj);
				bool flag;
				if ((flag = true) == objectValue is ToolStrip || flag == objectValue is ContextMenuStrip)
				{
					try
					{
						foreach (object obj2 in ((IEnumerable)NewLateBinding.LateGet(objectValue, null, "Items", new object[0], null, null, null)))
						{
							object objectValue2 = RuntimeHelpers.GetObjectValue(obj2);
							if (objectValue2 is ToolStripButton | objectValue2 is ToolStripLabel | objectValue2 is ToolStripMenuItem)
							{
								list.Add(RuntimeHelpers.GetObjectValue(objectValue2));
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
		return list;
	}

	// Token: 0x0600012F RID: 303 RVA: 0x0000E764 File Offset: 0x0000C964
	public string OSLanguage()
	{
		string result;
		try
		{
			long systemDefaultLCID = Translate.GetSystemDefaultLCID();
			result = this.GetUserLocaleInfo(systemDefaultLCID, 4097L);
		}
		catch (Exception ex)
		{
			result = "English";
		}
		return result;
	}

	// Token: 0x06000130 RID: 304
	[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern long GetThreadLocale();

	// Token: 0x06000131 RID: 305
	[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern long GetSystemDefaultLCID();

	// Token: 0x06000132 RID: 306
	[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern long GetLocaleInfoA(long Locale, long LCType, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpLCData, long cchData);

	// Token: 0x06000133 RID: 307 RVA: 0x0000E7B0 File Offset: 0x0000C9B0
	public string GetUserLocaleInfo(long dwLocaleID, long dwLCType)
	{
		string text;
		long localeInfoA = Translate.GetLocaleInfoA(dwLocaleID, dwLCType, ref text, (long)Strings.Len(text));
		string result;
		if (localeInfoA != 0L)
		{
			text = Strings.Space(checked((int)localeInfoA));
			localeInfoA = Translate.GetLocaleInfoA(dwLocaleID, dwLCType, ref text, (long)Strings.Len(text));
			if (localeInfoA != 0L)
			{
				result = Strings.Left(text, checked((int)(localeInfoA - 1L)));
			}
		}
		return result;
	}

	// Token: 0x04000067 RID: 103
	private List<string> __Languages;

	// Token: 0x04000068 RID: 104
	private int __Index;

	// Token: 0x04000069 RID: 105
	private Class51 class51_0;

	// Token: 0x0400006A RID: 106
	public static long LOCALE_ILANGUAGE;

	// Token: 0x0400006B RID: 107
	public static long LOCALE_SLANGUAGE;

	// Token: 0x0400006C RID: 108
	public static long LOCALE_SENGLANGUAGE;

	// Token: 0x0400006D RID: 109
	public static long LOCALE_SABBREVLANGNAME;

	// Token: 0x0400006E RID: 110
	public static long LOCALE_SNATIVELANGNAME;

	// Token: 0x0400006F RID: 111
	public static long LOCALE_ICOUNTRY;

	// Token: 0x04000070 RID: 112
	public static long LOCALE_SCOUNTRY;

	// Token: 0x04000071 RID: 113
	public static long LOCALE_SENGCOUNTRY;

	// Token: 0x04000072 RID: 114
	public static long LOCALE_SABBREVCTRYNAME;

	// Token: 0x04000073 RID: 115
	public static long LOCALE_SNATIVECTRYNAME;

	// Token: 0x04000074 RID: 116
	public static long LOCALE_IDEFAULTLANGUAGE;

	// Token: 0x04000075 RID: 117
	public static long LOCALE_IDEFAULTCOUNTRY;

	// Token: 0x04000076 RID: 118
	public static long LOCALE_IDEFAULTCODEPAGE;

	// Token: 0x04000077 RID: 119
	public static long LOCALE_IDEFAULTANSICODEPAGE;

	// Token: 0x04000078 RID: 120
	public static long LOCALE_IDEFAULTMACCODEPAGE;

	// Token: 0x04000079 RID: 121
	public static long LOCALE_SLIST;

	// Token: 0x0400007A RID: 122
	public static long LOCALE_IMEASURE;

	// Token: 0x0400007B RID: 123
	public static long LOCALE_SDECIMAL;

	// Token: 0x0400007C RID: 124
	public static long LOCALE_STHOUSAND;

	// Token: 0x0400007D RID: 125
	public static long LOCALE_SGROUPING;

	// Token: 0x0400007E RID: 126
	public static long LOCALE_IDIGITS;

	// Token: 0x0400007F RID: 127
	public static long LOCALE_ILZERO;

	// Token: 0x04000080 RID: 128
	public static long LOCALE_INEGNUMBER;

	// Token: 0x04000081 RID: 129
	public static long LOCALE_SNATIVEDIGITS;

	// Token: 0x04000082 RID: 130
	public static long LOCALE_SCURRENCY;

	// Token: 0x04000083 RID: 131
	public static long LOCALE_SINTLSYMBOL;

	// Token: 0x04000084 RID: 132
	public static long LOCALE_SMONDECIMALSEP;

	// Token: 0x04000085 RID: 133
	public static long LOCALE_SMONTHOUSANDSEP;

	// Token: 0x04000086 RID: 134
	public static long LOCALE_SMONGROUPING;

	// Token: 0x04000087 RID: 135
	public static long LOCALE_ICURRDIGITS;

	// Token: 0x04000088 RID: 136
	public static long LOCALE_IINTLCURRDIGITS;

	// Token: 0x04000089 RID: 137
	public static long LOCALE_ICURRENCY;

	// Token: 0x0400008A RID: 138
	public static long LOCALE_INEGCURR;

	// Token: 0x0400008B RID: 139
	public static long LOCALE_SDATE;

	// Token: 0x0400008C RID: 140
	public static long LOCALE_STIME;

	// Token: 0x0400008D RID: 141
	public static long LOCALE_SSHORTDATE;

	// Token: 0x0400008E RID: 142
	public static long LOCALE_SLONGDATE;

	// Token: 0x0400008F RID: 143
	public static long LOCALE_STIMEFORMAT;

	// Token: 0x04000090 RID: 144
	public static long LOCALE_IDATE;

	// Token: 0x04000091 RID: 145
	public static long LOCALE_ILDATE;

	// Token: 0x04000092 RID: 146
	public static long LOCALE_ITIME;

	// Token: 0x04000093 RID: 147
	public static long LOCALE_ITIMEMARKPOSN;

	// Token: 0x04000094 RID: 148
	public static long LOCALE_ICENTURY;

	// Token: 0x04000095 RID: 149
	public static long LOCALE_ITLZERO;

	// Token: 0x04000096 RID: 150
	public static long LOCALE_IDAYLZERO;

	// Token: 0x04000097 RID: 151
	public static long LOCALE_IMONLZERO;

	// Token: 0x04000098 RID: 152
	public static long LOCALE_S1159;

	// Token: 0x04000099 RID: 153
	public static long LOCALE_S2359;

	// Token: 0x0400009A RID: 154
	public static long LOCALE_ICALENDARTYPE;

	// Token: 0x0400009B RID: 155
	public static long LOCALE_IOPTIONALCALENDAR;

	// Token: 0x0400009C RID: 156
	public static long LOCALE_IFIRSTDAYOFWEEK;

	// Token: 0x0400009D RID: 157
	public static long LOCALE_IFIRSTWEEKOFYEAR;

	// Token: 0x0400009E RID: 158
	public static long LOCALE_SDAYNAME1;

	// Token: 0x0400009F RID: 159
	public static long LOCALE_SDAYNAME2;

	// Token: 0x040000A0 RID: 160
	public static long LOCALE_SDAYNAME3;

	// Token: 0x040000A1 RID: 161
	public static long LOCALE_SDAYNAME4;

	// Token: 0x040000A2 RID: 162
	public static long LOCALE_SDAYNAME5;

	// Token: 0x040000A3 RID: 163
	public static long LOCALE_SDAYNAME6;

	// Token: 0x040000A4 RID: 164
	public static long LOCALE_SDAYNAME7;

	// Token: 0x040000A5 RID: 165
	public static long LOCALE_SABBREVDAYNAME1;

	// Token: 0x040000A6 RID: 166
	public static long LOCALE_SABBREVDAYNAME2;

	// Token: 0x040000A7 RID: 167
	public static long LOCALE_SABBREVDAYNAME3;

	// Token: 0x040000A8 RID: 168
	public static long LOCALE_SABBREVDAYNAME4;

	// Token: 0x040000A9 RID: 169
	public static long LOCALE_SABBREVDAYNAME5;

	// Token: 0x040000AA RID: 170
	public static long LOCALE_SABBREVDAYNAME6;

	// Token: 0x040000AB RID: 171
	public static long LOCALE_SABBREVDAYNAME7;

	// Token: 0x040000AC RID: 172
	public static long LOCALE_SMONTHNAME1;

	// Token: 0x040000AD RID: 173
	public static long LOCALE_SMONTHNAME2;

	// Token: 0x040000AE RID: 174
	public static long LOCALE_SMONTHNAME3;

	// Token: 0x040000AF RID: 175
	public static long LOCALE_SMONTHNAME4;

	// Token: 0x040000B0 RID: 176
	public static long LOCALE_SMONTHNAME5;

	// Token: 0x040000B1 RID: 177
	public static long LOCALE_SMONTHNAME6;

	// Token: 0x040000B2 RID: 178
	public static long LOCALE_SMONTHNAME7;

	// Token: 0x040000B3 RID: 179
	public static long LOCALE_SMONTHNAME8;

	// Token: 0x040000B4 RID: 180
	public static long LOCALE_SMONTHNAME9;

	// Token: 0x040000B5 RID: 181
	public static long LOCALE_SMONTHNAME10;

	// Token: 0x040000B6 RID: 182
	public static long LOCALE_SMONTHNAME11;

	// Token: 0x040000B7 RID: 183
	public static long LOCALE_SMONTHNAME12;

	// Token: 0x040000B8 RID: 184
	public static long LOCALE_SMONTHNAME13;

	// Token: 0x040000B9 RID: 185
	public static long LOCALE_SABBREVMONTHNAME1;

	// Token: 0x040000BA RID: 186
	public static long LOCALE_SABBREVMONTHNAME2;

	// Token: 0x040000BB RID: 187
	public static long LOCALE_SABBREVMONTHNAME3;

	// Token: 0x040000BC RID: 188
	public static long LOCALE_SABBREVMONTHNAME4;

	// Token: 0x040000BD RID: 189
	public static long LOCALE_SABBREVMONTHNAME5;

	// Token: 0x040000BE RID: 190
	public static long LOCALE_SABBREVMONTHNAME6;

	// Token: 0x040000BF RID: 191
	public static long LOCALE_SABBREVMONTHNAME7;

	// Token: 0x040000C0 RID: 192
	public static long LOCALE_SABBREVMONTHNAME8;

	// Token: 0x040000C1 RID: 193
	public static long LOCALE_SABBREVMONTHNAME9;

	// Token: 0x040000C2 RID: 194
	public static long LOCALE_SABBREVMONTHNAME10;

	// Token: 0x040000C3 RID: 195
	public static long LOCALE_SABBREVMONTHNAME11;

	// Token: 0x040000C4 RID: 196
	public static long LOCALE_SABBREVMONTHNAME12;

	// Token: 0x040000C5 RID: 197
	public static long LOCALE_SABBREVMONTHNAME13;

	// Token: 0x040000C6 RID: 198
	public static long LOCALE_SPOSITIVESIGN;

	// Token: 0x040000C7 RID: 199
	public static long LOCALE_SNEGATIVESIGN;

	// Token: 0x040000C8 RID: 200
	public static long LOCALE_IPOSSIGNPOSN;

	// Token: 0x040000C9 RID: 201
	public static long LOCALE_INEGSIGNPOSN;

	// Token: 0x040000CA RID: 202
	public static long LOCALE_IPOSSYMPRECEDES;

	// Token: 0x040000CB RID: 203
	public static long LOCALE_IPOSSEPBYSPACE;

	// Token: 0x040000CC RID: 204
	public static long LOCALE_INEGSYMPRECEDES;

	// Token: 0x040000CD RID: 205
	public static long LOCALE_INEGSEPBYSPACE;

	// Token: 0x040000CE RID: 206
	public static long LOCALE_FONTSIGNATURE;

	// Token: 0x040000CF RID: 207
	public static long LOCALE_SISO639LANGNAME;

	// Token: 0x040000D0 RID: 208
	public static long LOCALE_SISO3166CTRYNAME;

	// Token: 0x040000D1 RID: 209
	public static long LOCALE_IDEFAULTEBCDICCODEPAGE;

	// Token: 0x040000D2 RID: 210
	public static long LOCALE_IPAPERSIZE;

	// Token: 0x040000D3 RID: 211
	public static long LOCALE_SENGCURRNAME;

	// Token: 0x040000D4 RID: 212
	public static long LOCALE_SNATIVECURRNAME;

	// Token: 0x040000D5 RID: 213
	public static long LOCALE_SYEARMONTH;

	// Token: 0x040000D6 RID: 214
	public static long LOCALE_SSORTNAME;

	// Token: 0x040000D7 RID: 215
	public static long LOCALE_IDIGITSUBSTITUTION;
}
