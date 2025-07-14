using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ns0
{
	// Token: 0x02000032 RID: 50
	internal sealed class Class29
	{
		// Token: 0x060001D4 RID: 468 RVA: 0x000117FC File Offset: 0x0000F9FC
		public Class29(DataGridView dataGridView_1, string string_1, int int_2, int int_3)
		{
			this.enum2_0 = Class29.Enum2.const_0;
			this.dataGridView_0 = dataGridView_1;
			this.string_0 = string_1;
			this.int_0 = int_2;
			this.int_1 = int_3;
			this.dataGridView_0.Columns[0].DefaultCellStyle.NullValue = null;
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00002B66 File Offset: 0x00000D66
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x00002B6E File Offset: 0x00000D6E
		public bool AutoScroll { get; set; }

		// Token: 0x060001D7 RID: 471 RVA: 0x00002B77 File Offset: 0x00000D77
		public void method_0(Class29.Enum2 enum2_1)
		{
			this.enum2_0 = enum2_1;
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00011850 File Offset: 0x0000FA50
		public void method_1(object object_0)
		{
			if (this.dataGridView_0.InvokeRequired)
			{
				this.dataGridView_0.Invoke(new Class29.Delegate5(this.method_1), new object[]
				{
					object_0
				});
			}
			else if (!this.method_9(Conversions.ToString(NewLateBinding.LateIndexGet(object_0, new object[]
			{
				0
			}, null))))
			{
				Class29.Class30 @class = new Class29.Class30(this.dataGridView_0);
				@class.CountryIndex = this.int_0;
				@class.Items = (string[])object_0;
				this.list_0.Add(@class);
				this.dataGridView_0.Rows.Add(@class.method_0());
				if (this.AutoScroll)
				{
					this.dataGridView_0.FirstDisplayedScrollingRowIndex = checked(this.dataGridView_0.Rows.Count - 1);
				}
			}
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00011920 File Offset: 0x0000FB20
		public void method_2(object object_0)
		{
			if (this.dataGridView_0.InvokeRequired)
			{
				this.dataGridView_0.Invoke(new Class29.Delegate6(this.method_2), new object[]
				{
					object_0
				});
			}
			else
			{
				List<Class29.Class30> list = new List<Class29.Class30>();
				if (object_0 is List<DataGridViewRow>)
				{
					list.AddRange(Array.ConvertAll<DataGridViewRow, Class29.Class30>(((List<DataGridViewRow>)object_0).ToArray(), new Converter<DataGridViewRow, Class29.Class30>(this.method_22)));
				}
				else if (object_0 is DataGridViewRow)
				{
					list.Add((Class29.Class30)((DataGridViewRow)object_0).Tag);
				}
				else if (object_0 is List<Class29.Class30>)
				{
					list.AddRange(((List<Class29.Class30>)object_0).ToArray());
				}
				else if (object_0 is Class29.Class30)
				{
					list.Add((Class29.Class30)object_0);
				}
				if (list.Count > 100)
				{
					List<Class29.Class30> list2 = new List<Class29.Class30>();
					try
					{
						foreach (object obj in ((IEnumerable)this.dataGridView_0.Rows))
						{
							DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
							Class29.Class30 item = (Class29.Class30)dataGridViewRow.Tag;
							if (!list.Contains(item))
							{
								list2.Add(item);
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
					if (list.Count > 0)
					{
						while (list.Count > 0)
						{
							this.list_0.Remove(list[0]);
							list.RemoveAt(0);
						}
					}
					global::Globals.LockWindowUpdate(this.dataGridView_0.Handle);
					this.dataGridView_0.Rows.Clear();
					this.dataGridView_0.ClearSelection();
					if (list2.Count > 0)
					{
						this.dataGridView_0.Rows.AddRange(Array.ConvertAll<Class29.Class30, DataGridViewRow>(list2.ToArray(), new Converter<Class29.Class30, DataGridViewRow>(this.method_21)));
					}
					global::Globals.LockWindowUpdate(IntPtr.Zero);
				}
				else if (list.Count > 0)
				{
					while (list.Count > 0)
					{
						this.list_0.Remove(list[0]);
						this.dataGridView_0.Rows.Remove(list[0].Row);
						list.RemoveAt(0);
					}
				}
			}
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00011B60 File Offset: 0x0000FD60
		public void method_3(string string_1, int int_2, DataGridViewRow dataGridViewRow_0)
		{
			if (this.dataGridView_0.InvokeRequired)
			{
				this.dataGridView_0.Invoke(new Class29.Delegate7(this.method_3), new object[]
				{
					string_1,
					int_2,
					dataGridViewRow_0
				});
			}
			else
			{
				Class29.Class30 @class = (Class29.Class30)dataGridViewRow_0.Tag;
				if (this.list_0.Contains(@class))
				{
					@class.Items[int_2] = string_1;
					@class.method_3();
				}
			}
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00002B80 File Offset: 0x00000D80
		public void method_4()
		{
			if (this.dataGridView_0.SelectedRows.Count == this.list_0.Count)
			{
				this.method_7();
			}
			else
			{
				this.method_2(this.method_20());
			}
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00011BD4 File Offset: 0x0000FDD4
		public int method_5()
		{
			return this.list_0.Count;
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00011BF0 File Offset: 0x0000FDF0
		public int method_6()
		{
			return this.dataGridView_0.Rows.Count;
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00002BB5 File Offset: 0x00000DB5
		public void method_7()
		{
			this.list_0 = new List<Class29.Class30>();
			this.dataGridView_0.Rows.Clear();
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00002BD2 File Offset: 0x00000DD2
		public void method_8()
		{
			this.dataGridView_0.SelectAll();
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00011C10 File Offset: 0x0000FE10
		public bool method_9(string string_1)
		{
			Class29.Class31 @class = new Class29.Class31();
			@class.string_0 = string_1;
			Class29.Class30 class2 = null;
			try
			{
				class2 = this.list_0.Find(new Predicate<Class29.Class30>(@class.method_0));
			}
			catch (Exception ex)
			{
			}
			return class2 != null;
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00011C70 File Offset: 0x0000FE70
		public bool method_10(string string_1)
		{
			Class29.Class32 @class = new Class29.Class32();
			@class.string_0 = Class23.smethod_10(string_1);
			Class29.Class30 class2 = null;
			try
			{
				class2 = this.list_0.Find(new Predicate<Class29.Class30>(@class.method_0));
			}
			catch (Exception ex)
			{
			}
			return class2 != null;
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00011CD4 File Offset: 0x0000FED4
		public bool method_11()
		{
			bool result;
			try
			{
				if (File.Exists(this.string_0))
				{
					File.Delete(this.string_0);
				}
				StringBuilder stringBuilder = new StringBuilder();
				try
				{
					foreach (Class29.Class30 @class in this.list_0)
					{
						stringBuilder.Append(@class.method_1() + "\r\n");
					}
				}
				finally
				{
					List<Class29.Class30>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				if (!string.IsNullOrEmpty(Conversions.ToString(stringBuilder.Length)))
				{
					File.AppendAllText(this.string_0, stringBuilder.ToString());
				}
				result = true;
			}
			catch (Exception ex)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00002BDF File Offset: 0x00000DDF
		public void method_12(bool bool_1)
		{
			this.method_7();
			this.method_18();
			if (bool_1)
			{
				this.method_16();
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00011D9C File Offset: 0x0000FF9C
		public void method_13(string string_1, int int_2 = 0)
		{
			Class29.Class33 @class = new Class29.Class33();
			@class.string_0 = string_1;
			@class.int_0 = int_2;
			global::Globals.LockWindowUpdate(this.dataGridView_0.Handle);
			this.dataGridView_0.ClearSelection();
			this.dataGridView_0.Rows.Clear();
			if (string.IsNullOrEmpty(@class.string_0) & this.enum2_0 == Class29.Enum2.const_0)
			{
				this.method_16();
			}
			else
			{
				List<Class29.Class30> list;
				if (string.IsNullOrEmpty(@class.string_0))
				{
					list = this.list_0;
				}
				else
				{
					list = this.list_0.FindAll(new Predicate<Class29.Class30>(@class.method_0));
				}
				if (list.Count > 0)
				{
					list = list.FindAll(new Predicate<Class29.Class30>(this.method_14));
					if (list != null)
					{
						this.dataGridView_0.Rows.AddRange(Array.ConvertAll<Class29.Class30, DataGridViewRow>(list.ToArray(), new Converter<Class29.Class30, DataGridViewRow>(this.method_21)));
					}
				}
			}
			global::Globals.LockWindowUpdate(IntPtr.Zero);
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00011E8C File Offset: 0x0001008C
		private bool method_14(Class29.Class30 class30_0)
		{
			bool result;
			try
			{
				if (this.enum2_0 == Class29.Enum2.const_0)
				{
					result = true;
				}
				else if (this.enum2_0 == Class29.Enum2.const_1)
				{
					result = (Process.GetCurrentProcess().StartTime.Subtract(DateTime.Parse(class30_0.Items[this.int_1].ToString(), CultureInfo.InvariantCulture.DateTimeFormat)).TotalMinutes <= 1.0);
				}
				else
				{
					TimeSpan timeSpan = DateAndTime.Now.Subtract(DateTime.Parse(class30_0.Items[this.int_1].ToString(), CultureInfo.InvariantCulture.DateTimeFormat));
					if (this.enum2_0 == Class29.Enum2.const_2)
					{
						result = (timeSpan.TotalDays <= 1.0);
					}
					else if (this.enum2_0 == Class29.Enum2.const_3)
					{
						result = (timeSpan.TotalDays <= 7.0);
					}
					else if (this.enum2_0 == Class29.Enum2.const_4)
					{
						result = (timeSpan.TotalDays <= 30.0);
					}
					else if (this.enum2_0 == Class29.Enum2.const_5)
					{
						result = (timeSpan.TotalDays <= 90.0);
					}
					else if (this.enum2_0 == Class29.Enum2.const_6)
					{
						result = (timeSpan.TotalDays >= 90.0);
					}
				}
			}
			catch (Exception ex)
			{
				class30_0.Items[this.int_1] = DateAndTime.Now.ToString(CultureInfo.InvariantCulture.DateTimeFormat);
				result = false;
			}
			return result;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00012040 File Offset: 0x00010240
		public void method_15()
		{
			List<Class29.Class30> list = this.method_20();
			if (list.Count > 0)
			{
				this.dataGridView_0.Rows.Clear();
				this.dataGridView_0.Rows.AddRange(Array.ConvertAll<Class29.Class30, DataGridViewRow>(list.ToArray(), new Converter<Class29.Class30, DataGridViewRow>(this.method_21)));
			}
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00002BF6 File Offset: 0x00000DF6
		private void method_16()
		{
			if (this.list_0.Count > 0)
			{
				this.dataGridView_0.Rows.AddRange(Array.ConvertAll<Class29.Class30, DataGridViewRow>(this.list_0.ToArray(), new Converter<Class29.Class30, DataGridViewRow>(this.method_21)));
			}
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00012098 File Offset: 0x00010298
		public void method_17(List<Class29.Class30> list_1)
		{
			if (this.dataGridView_0.InvokeRequired)
			{
				this.dataGridView_0.Invoke(new Class29.Delegate5(this.method_23), new object[]
				{
					list_1
				});
			}
			else
			{
				this.list_0.AddRange(list_1.ToArray());
				this.dataGridView_0.Rows.AddRange(Array.ConvertAll<Class29.Class30, DataGridViewRow>(list_1.ToArray(), new Converter<Class29.Class30, DataGridViewRow>(this.method_21)));
			}
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00012110 File Offset: 0x00010310
		private void method_18()
		{
			List<Class29.Class30> list = new List<Class29.Class30>();
			try
			{
				foreach (string text in this.method_19())
				{
					text = text.Trim();
					if (text.Contains("|"))
					{
						string[] array = Strings.Split(text, "|", -1, CompareMethod.Binary);
						if (array.Length >= checked(this.dataGridView_0.Columns.Count - 2))
						{
							list.Add(new Class29.Class30(this.dataGridView_0)
							{
								CountryIndex = this.int_0,
								Items = array
							});
						}
					}
				}
			}
			finally
			{
				List<string>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			if (list.Count > 0)
			{
				this.list_0.AddRange(list);
			}
		}

		// Token: 0x060001EA RID: 490 RVA: 0x000121E4 File Offset: 0x000103E4
		private List<string> method_19()
		{
			List<string> list = new List<string>();
			if (File.Exists(this.string_0))
			{
				list.AddRange(File.ReadAllLines(this.string_0));
			}
			return list;
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00012218 File Offset: 0x00010418
		private List<Class29.Class30> method_20()
		{
			List<Class29.Class30> list = new List<Class29.Class30>();
			try
			{
				foreach (object obj in this.dataGridView_0.SelectedRows)
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
					if (dataGridViewRow.Selected)
					{
						list.Add((Class29.Class30)dataGridViewRow.Tag);
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

		// Token: 0x060001EC RID: 492 RVA: 0x00012294 File Offset: 0x00010494
		private DataGridViewRow method_21(Class29.Class30 class30_0)
		{
			return class30_0.method_0();
		}

		// Token: 0x060001ED RID: 493 RVA: 0x000122AC File Offset: 0x000104AC
		private Class29.Class30 method_22(DataGridViewRow dataGridViewRow_0)
		{
			return (Class29.Class30)dataGridViewRow_0.Tag;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00002C34 File Offset: 0x00000E34
		[DebuggerHidden]
		[CompilerGenerated]
		private void method_23(object object_0)
		{
			this.method_17((List<Class29.Class30>)object_0);
		}

		// Token: 0x04000120 RID: 288
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000121 RID: 289
		private List<Class29.Class30> list_0;

		// Token: 0x04000122 RID: 290
		private DataGridView dataGridView_0;

		// Token: 0x04000123 RID: 291
		private string string_0;

		// Token: 0x04000124 RID: 292
		private int int_0;

		// Token: 0x04000125 RID: 293
		private int int_1;

		// Token: 0x04000126 RID: 294
		private Class29.Enum2 enum2_0;

		// Token: 0x04000127 RID: 295
		private static char char_0;

		// Token: 0x02000033 RID: 51
		public enum Enum2
		{
			// Token: 0x04000129 RID: 297
			const_0,
			// Token: 0x0400012A RID: 298
			const_1,
			// Token: 0x0400012B RID: 299
			const_2,
			// Token: 0x0400012C RID: 300
			const_3,
			// Token: 0x0400012D RID: 301
			const_4,
			// Token: 0x0400012E RID: 302
			const_5,
			// Token: 0x0400012F RID: 303
			const_6
		}

		// Token: 0x02000034 RID: 52
		// (Invoke) Token: 0x060001F2 RID: 498
		private delegate void Delegate5(object arg);

		// Token: 0x02000035 RID: 53
		// (Invoke) Token: 0x060001F6 RID: 502
		private delegate void Delegate6(List<DataGridViewRow> o);

		// Token: 0x02000036 RID: 54
		// (Invoke) Token: 0x060001FA RID: 506
		private delegate void Delegate7(string value, int column, DataGridViewRow item);

		// Token: 0x02000037 RID: 55
		public sealed class Class30
		{
			// Token: 0x060001FB RID: 507 RVA: 0x00002C42 File Offset: 0x00000E42
			public Class30(DataGridView dataGridView_1)
			{
				this.CountryIndex = -1;
				this.Grid = dataGridView_1;
			}

			// Token: 0x170000A1 RID: 161
			// (get) Token: 0x060001FC RID: 508 RVA: 0x00002C58 File Offset: 0x00000E58
			// (set) Token: 0x060001FD RID: 509 RVA: 0x00002C60 File Offset: 0x00000E60
			public int CountryIndex { get; set; }

			// Token: 0x170000A2 RID: 162
			// (get) Token: 0x060001FE RID: 510 RVA: 0x00002C69 File Offset: 0x00000E69
			// (set) Token: 0x060001FF RID: 511 RVA: 0x00002C71 File Offset: 0x00000E71
			public string[] Items { get; set; }

			// Token: 0x170000A3 RID: 163
			// (get) Token: 0x06000200 RID: 512 RVA: 0x00002C7A File Offset: 0x00000E7A
			// (set) Token: 0x06000201 RID: 513 RVA: 0x00002C82 File Offset: 0x00000E82
			public DataGridViewRow Row { get; set; }

			// Token: 0x170000A4 RID: 164
			// (get) Token: 0x06000202 RID: 514 RVA: 0x00002C8B File Offset: 0x00000E8B
			// (set) Token: 0x06000203 RID: 515 RVA: 0x00002C93 File Offset: 0x00000E93
			public DataGridView Grid { get; set; }

			// Token: 0x06000204 RID: 516 RVA: 0x000122C8 File Offset: 0x000104C8
			public DataGridViewRow method_0()
			{
				DataGridViewRow row;
				try
				{
					this.Row = new DataGridViewRow();
					this.Row.CreateCells(this.Grid);
					if (this.CountryIndex != -1)
					{
						this.method_2(this.Row);
					}
					this.method_3();
					this.Row.Tag = this;
					row = this.Row;
				}
				catch (Exception ex)
				{
					Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
				}
				return row;
			}

			// Token: 0x06000205 RID: 517 RVA: 0x00012354 File Offset: 0x00010554
			public string method_1()
			{
				StringBuilder stringBuilder = new StringBuilder();
				checked
				{
					int num = this.Items.Length - 1;
					int num2 = num;
					for (int i = 0; i <= num2; i++)
					{
						if (i > 0)
						{
							stringBuilder.Append("|");
						}
						stringBuilder.Append(this.Items[i]);
					}
					return stringBuilder.ToString();
				}
			}

			// Token: 0x06000206 RID: 518 RVA: 0x000123AC File Offset: 0x000105AC
			private void method_2(DataGridViewRow dataGridViewRow_1)
			{
				int num;
				int num4;
				object obj;
				try
				{
					IL_02:
					ProjectData.ClearProjectError();
					num = -2;
					IL_0A:
					int num2 = 2;
					string text = this.Items[this.CountryIndex];
					IL_1A:
					num2 = 3;
					string text2 = this.Items[0];
					IL_25:
					num2 = 4;
					if (!(text.Contains("[") & text.Contains("]")))
					{
						goto IL_5A;
					}
					IL_40:
					num2 = 5;
					string text3 = text.Substring(1, checked(text.IndexOf("]") - 1));
					goto IL_CF;
					IL_5A:
					num2 = 7;
					text3 = Class23.smethod_12(text2);
					IL_64:
					num2 = 8;
					if (string.IsNullOrEmpty(text3))
					{
						goto IL_82;
					}
					IL_72:
					num2 = 9;
					text = global::Globals.G_DataGP.CountryNameByCode(text3);
					IL_82:
					num2 = 11;
					if (!string.IsNullOrEmpty(text))
					{
						goto IL_CF;
					}
					IL_8D:
					num2 = 12;
					string text4 = global::Globals.GMain.method_85(Class23.smethod_11(text2)).ToString();
					IL_A7:
					num2 = 13;
					if (string.IsNullOrEmpty(text4))
					{
						goto IL_CF;
					}
					IL_B6:
					num2 = 14;
					DataGP g_DataGP = global::Globals.G_DataGP;
					string sIP = text4;
					Image image = null;
					g_DataGP.Lookup(sIP, ref text, ref image, ref text3, true);
					IL_CF:
					num2 = 18;
					if (!string.IsNullOrEmpty(text3))
					{
						goto IL_F7;
					}
					IL_DB:
					num2 = 19;
					text3 = "??";
					IL_E5:
					num2 = 20;
					text = global::Globals.G_DataGP.CountryNameByCode(text3);
					goto IL_111;
					IL_F7:
					num2 = 22;
					this.Row.Cells[0].ToolTipText = text;
					IL_111:
					num2 = 24;
					this.Items[this.CountryIndex] = text;
					IL_122:
					num2 = 25;
					if (text3.Equals("??") || text3.Equals("EU"))
					{
						goto IL_182;
					}
					IL_144:
					num2 = 27;
					this.Row.Cells[0].Value = global::Globals.GMain.imgData.Images[text3.ToLower() + ".png"];
					IL_182:
					goto IL_254;
					IL_187:
					int num3 = num4 + 1;
					num4 = 0;
					@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
					IL_20B:
					goto IL_249;
					IL_20D:
					num4 = num2;
					@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
					IL_226:;
				}
				catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
				{
					Exception ex = (Exception)obj2;
					goto IL_20D;
				}
				IL_249:
				throw ProjectData.CreateProjectError(-2146828237);
				IL_254:
				if (num4 != 0)
				{
					ProjectData.ClearProjectError();
				}
			}

			// Token: 0x06000207 RID: 519 RVA: 0x00012634 File Offset: 0x00010834
			public void method_3()
			{
				checked
				{
					if (this.Row.Cells.Count > this.Items.Length)
					{
						this.Items = (string[])Utils.CopyArray(this.Items, new string[this.Row.Cells.Count - 2 + 1]);
					}
					int num = this.Row.Cells.Count - 1;
					for (int i = 1; i <= num; i++)
					{
						if (this.Items[i - 1] == null)
						{
							this.Items[i - 1] = "";
						}
						this.Row.Cells[i].Value = this.Items[i - 1];
					}
				}
			}

			// Token: 0x04000130 RID: 304
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			private int int_0;

			// Token: 0x04000131 RID: 305
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private string[] string_0;

			// Token: 0x04000132 RID: 306
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private DataGridViewRow dataGridViewRow_0;

			// Token: 0x04000133 RID: 307
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private DataGridView dataGridView_0;
		}

		// Token: 0x02000038 RID: 56
		[CompilerGenerated]
		internal sealed class Class31
		{
			// Token: 0x06000209 RID: 521 RVA: 0x00002C9C File Offset: 0x00000E9C
			internal bool method_0(Class29.Class30 class30_0)
			{
				return class30_0.Items[0].Equals(this.string_0);
			}

			// Token: 0x04000134 RID: 308
			public string string_0;
		}

		// Token: 0x02000039 RID: 57
		[CompilerGenerated]
		internal sealed class Class32
		{
			// Token: 0x0600020B RID: 523 RVA: 0x00002CB1 File Offset: 0x00000EB1
			internal bool method_0(Class29.Class30 class30_0)
			{
				return class30_0.Items[0].ToLower().Contains(this.string_0.ToLower());
			}

			// Token: 0x04000135 RID: 309
			public string string_0;
		}

		// Token: 0x0200003A RID: 58
		[CompilerGenerated]
		internal sealed class Class33
		{
			// Token: 0x0600020D RID: 525 RVA: 0x00002CD0 File Offset: 0x00000ED0
			internal bool method_0(Class29.Class30 class30_0)
			{
				return class30_0.Items[this.int_0].ToLower().Contains(this.string_0.ToLower());
			}

			// Token: 0x04000136 RID: 310
			public int int_0;

			// Token: 0x04000137 RID: 311
			public string string_0;
		}
	}
}
