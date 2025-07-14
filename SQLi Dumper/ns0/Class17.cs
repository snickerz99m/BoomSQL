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
	// Token: 0x0200001E RID: 30
	internal sealed class Class17
	{
		// Token: 0x06000139 RID: 313 RVA: 0x0000ECEC File Offset: 0x0000CEEC
		public Class17(ListView listView_0, string string_1, int int_2 = -1, int int_3 = -1)
		{
			this.enum0_0 = Class17.Enum0.const_0;
			this.listViewExt_0 = (ListViewExt)listView_0;
			this.string_0 = string_1;
			this.int_0 = int_2;
			this.int_1 = int_3;
			if (int_2 != -1)
			{
				this.listViewExt_0.SmallImageList = global::Globals.GMain.imgData;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600013A RID: 314 RVA: 0x0000280B File Offset: 0x00000A0B
		// (set) Token: 0x0600013B RID: 315 RVA: 0x00002813 File Offset: 0x00000A13
		public bool AutoScroll { get; set; }

		// Token: 0x0600013C RID: 316 RVA: 0x0000281C File Offset: 0x00000A1C
		public void method_0(Class17.Enum0 enum0_1)
		{
			this.enum0_0 = enum0_1;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000ED48 File Offset: 0x0000CF48
		public void method_1(object object_0)
		{
			checked
			{
				if (this.listViewExt_0.InvokeRequired)
				{
					this.listViewExt_0.Invoke(new Class17.Delegate1(this.method_1), new object[]
					{
						object_0
					});
				}
				else if (!this.method_10(Conversions.ToString(NewLateBinding.LateIndexGet(object_0, new object[]
				{
					0
				}, null))))
				{
					if (this.listViewExt_0.CheckBoxes)
					{
						object_0 = Utils.CopyArray((Array)object_0, new object[Conversions.ToInteger(NewLateBinding.LateGet(object_0, null, "Length", new object[0], null, null, null)) + 1]);
						NewLateBinding.LateIndexSet(object_0, new object[]
						{
							Operators.SubtractObject(NewLateBinding.LateGet(object_0, null, "Length", new object[0], null, null, null), 1),
							"False"
						}, null);
					}
					Class17.Class18 @class = new Class17.Class18();
					@class.CountryIndex = this.int_0;
					@class.Items = (string[])object_0;
					this.list_0.Add(@class);
					global::Globals.LockWindowUpdate(this.listViewExt_0.Handle);
					this.listViewExt_0.Items.Add(@class.method_0());
					if (this.AutoScroll)
					{
						this.listViewExt_0.EnsureVisible(this.listViewExt_0.Items.Count - 1);
					}
					global::Globals.LockWindowUpdate(IntPtr.Zero);
				}
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000EEA8 File Offset: 0x0000D0A8
		public void method_2(List<ListViewItem> list_1)
		{
			if (this.listViewExt_0.InvokeRequired)
			{
				this.listViewExt_0.Invoke(new Class17.Delegate2(this.method_2), new object[]
				{
					list_1
				});
			}
			else
			{
				global::Globals.LockWindowUpdate(this.listViewExt_0.Handle);
				while (list_1.Count > 0)
				{
					this.list_0.Remove((Class17.Class18)list_1[0].Tag);
					this.listViewExt_0.Items.Remove(list_1[0]);
					list_1.RemoveAt(0);
				}
				global::Globals.LockWindowUpdate(IntPtr.Zero);
			}
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000EF4C File Offset: 0x0000D14C
		public void method_3(string string_1, int int_2, ListViewItem listViewItem_0)
		{
			if (this.listViewExt_0.InvokeRequired)
			{
				this.listViewExt_0.Invoke(new Class17.Delegate3(this.method_3), new object[]
				{
					string_1,
					int_2,
					listViewItem_0
				});
			}
			else
			{
				Class17.Class18 @class = (Class17.Class18)listViewItem_0.Tag;
				if (this.list_0.Contains(@class))
				{
					@class.Items[int_2] = string_1;
					@class.method_3();
				}
			}
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000EFC0 File Offset: 0x0000D1C0
		public void method_4()
		{
			if (this.listViewExt_0.SelectedItems.Count == this.list_0.Count)
			{
				this.method_8();
			}
			else
			{
				List<Class17.Class18> list = this.method_21();
				if (list.Count > 0)
				{
					global::Globals.LockWindowUpdate(this.listViewExt_0.Handle);
					while (list.Count > 0)
					{
						this.list_0.Remove(list[0]);
						this.listViewExt_0.Items.Remove(list[0].ViewItem);
						list.RemoveAt(0);
					}
					global::Globals.LockWindowUpdate(IntPtr.Zero);
				}
			}
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000F068 File Offset: 0x0000D268
		public int method_5()
		{
			return this.list_0.Count;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000F084 File Offset: 0x0000D284
		public int method_6()
		{
			return this.listViewExt_0.Items.Count;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000F0A4 File Offset: 0x0000D2A4
		public int method_7()
		{
			List<Class17.Class18> list = this.list_0.FindAll((Class17._Closure$__.predicate_0 == null) ? (Class17._Closure$__.predicate_0 = new Predicate<Class17.Class18>(Class17._Closure$__._Closure$___0.method_0)) : Class17._Closure$__.predicate_0);
			int result;
			if (list == null)
			{
				result = list.Count;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000F0F4 File Offset: 0x0000D2F4
		public void method_8()
		{
			this.list_0 = new List<Class17.Class18>();
			global::Globals.LockWindowUpdate(this.listViewExt_0.Handle);
			this.listViewExt_0.BeginUpdate();
			this.listViewExt_0.Items.Clear();
			this.listViewExt_0.EndUpdate();
			global::Globals.LockWindowUpdate(IntPtr.Zero);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00002825 File Offset: 0x00000A25
		public void method_9()
		{
			this.listViewExt_0.SelectAllItems();
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0000F150 File Offset: 0x0000D350
		public bool method_10(string string_1)
		{
			Class17.Class19 @class = new Class17.Class19();
			@class.string_0 = string_1;
			Class17.Class18 class2 = null;
			try
			{
				class2 = this.list_0.Find(new Predicate<Class17.Class18>(@class.method_0));
			}
			catch (Exception ex)
			{
			}
			return class2 != null;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000F1B0 File Offset: 0x0000D3B0
		public bool method_11(string string_1)
		{
			Class17.Class20 @class = new Class17.Class20();
			@class.string_0 = Class23.smethod_10(string_1);
			Class17.Class18 class2 = null;
			try
			{
				class2 = this.list_0.Find(new Predicate<Class17.Class18>(@class.method_0));
			}
			catch (Exception ex)
			{
			}
			return class2 != null;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0000F214 File Offset: 0x0000D414
		public bool method_12()
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
					foreach (Class17.Class18 @class in this.list_0)
					{
						stringBuilder.Append(@class.method_1() + "\r\n");
					}
				}
				finally
				{
					List<Class17.Class18>.Enumerator enumerator;
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

		// Token: 0x06000149 RID: 329 RVA: 0x00002832 File Offset: 0x00000A32
		public void method_13(bool bool_1)
		{
			this.method_8();
			this.method_19();
			if (bool_1)
			{
				this.method_17();
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000F2DC File Offset: 0x0000D4DC
		public void method_14(string string_1, int int_2 = 0)
		{
			Class17.Class21 @class = new Class17.Class21();
			@class.string_0 = string_1;
			@class.int_0 = int_2;
			global::Globals.LockWindowUpdate(this.listViewExt_0.Handle);
			this.listViewExt_0.SetSelectedColumn(null);
			this.listViewExt_0.BeginUpdate();
			this.listViewExt_0.Items.Clear();
			if (string.IsNullOrEmpty(@class.string_0) & this.enum0_0 == Class17.Enum0.const_0)
			{
				this.method_17();
			}
			else
			{
				List<Class17.Class18> list;
				if (string.IsNullOrEmpty(@class.string_0))
				{
					list = this.list_0;
				}
				else
				{
					list = this.list_0.FindAll(new Predicate<Class17.Class18>(@class.method_0));
				}
				if (list.Count > 0)
				{
					list = list.FindAll(new Predicate<Class17.Class18>(this.method_15));
					if (list != null)
					{
						this.listViewExt_0.Items.AddRange(Array.ConvertAll<Class17.Class18, ListViewItem>(list.ToArray(), new Converter<Class17.Class18, ListViewItem>(this.method_22)));
					}
				}
			}
			this.listViewExt_0.EndUpdate();
			global::Globals.LockWindowUpdate(IntPtr.Zero);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000F3E4 File Offset: 0x0000D5E4
		private bool method_15(Class17.Class18 class18_0)
		{
			bool result;
			try
			{
				if (this.enum0_0 == Class17.Enum0.const_0)
				{
					result = true;
				}
				else if (this.enum0_0 == Class17.Enum0.const_1)
				{
					result = (Process.GetCurrentProcess().StartTime.Subtract(DateTime.Parse(class18_0.Items[this.int_1].ToString(), CultureInfo.InvariantCulture.DateTimeFormat)).TotalMinutes <= 1.0);
				}
				else
				{
					TimeSpan timeSpan = DateAndTime.Now.Subtract(DateTime.Parse(class18_0.Items[this.int_1].ToString(), CultureInfo.InvariantCulture.DateTimeFormat));
					if (this.enum0_0 == Class17.Enum0.const_2)
					{
						result = (timeSpan.TotalDays <= 1.0);
					}
					else if (this.enum0_0 == Class17.Enum0.const_3)
					{
						result = (timeSpan.TotalDays <= 7.0);
					}
					else if (this.enum0_0 == Class17.Enum0.const_4)
					{
						result = (timeSpan.TotalDays <= 30.0);
					}
					else if (this.enum0_0 == Class17.Enum0.const_5)
					{
						result = (timeSpan.TotalDays <= 90.0);
					}
					else if (this.enum0_0 == Class17.Enum0.const_6)
					{
						result = (timeSpan.TotalDays >= 90.0);
					}
				}
			}
			catch (Exception ex)
			{
				class18_0.Items[this.int_1] = DateAndTime.Now.ToString(CultureInfo.InvariantCulture.DateTimeFormat);
				result = false;
			}
			return result;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000F598 File Offset: 0x0000D798
		public void method_16()
		{
			List<Class17.Class18> list = this.method_21();
			if (list.Count > 0)
			{
				global::Globals.LockWindowUpdate(this.listViewExt_0.Handle);
				this.listViewExt_0.Items.Clear();
				this.listViewExt_0.Items.AddRange(Array.ConvertAll<Class17.Class18, ListViewItem>(list.ToArray(), new Converter<Class17.Class18, ListViewItem>(this.method_22)));
				global::Globals.LockWindowUpdate(IntPtr.Zero);
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00002849 File Offset: 0x00000A49
		private void method_17()
		{
			if (this.list_0.Count > 0)
			{
				this.listViewExt_0.Items.AddRange(Array.ConvertAll<Class17.Class18, ListViewItem>(this.list_0.ToArray(), new Converter<Class17.Class18, ListViewItem>(this.method_22)));
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000F60C File Offset: 0x0000D80C
		public void method_18(List<Class17.Class18> list_1)
		{
			if (this.listViewExt_0.InvokeRequired)
			{
				this.listViewExt_0.Invoke(new Class17.Delegate1(this.method_23), new object[]
				{
					list_1
				});
			}
			else
			{
				this.list_0.AddRange(list_1.ToArray());
				this.listViewExt_0.Items.AddRange(Array.ConvertAll<Class17.Class18, ListViewItem>(list_1.ToArray(), new Converter<Class17.Class18, ListViewItem>(this.method_22)));
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0000F684 File Offset: 0x0000D884
		private void method_19()
		{
			List<Class17.Class18> list = new List<Class17.Class18>();
			try
			{
				foreach (string text in this.method_20())
				{
					text = text.Trim();
					if (text.Contains("|"))
					{
						string[] array = Strings.Split(text, "|", -1, CompareMethod.Binary);
						if (array.Length >= this.listViewExt_0.Columns.Count)
						{
							list.Add(new Class17.Class18
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

		// Token: 0x06000150 RID: 336 RVA: 0x0000F750 File Offset: 0x0000D950
		private List<string> method_20()
		{
			List<string> list = new List<string>();
			if (File.Exists(this.string_0))
			{
				list.AddRange(File.ReadAllLines(this.string_0));
			}
			return list;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000F784 File Offset: 0x0000D984
		private List<Class17.Class18> method_21()
		{
			List<Class17.Class18> list = new List<Class17.Class18>();
			try
			{
				foreach (object obj in this.listViewExt_0.SelectedItems)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					if (listViewItem.Selected)
					{
						list.Add((Class17.Class18)listViewItem.Tag);
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

		// Token: 0x06000152 RID: 338 RVA: 0x0000F800 File Offset: 0x0000DA00
		private ListViewItem method_22(Class17.Class18 class18_0)
		{
			return class18_0.method_0();
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00002887 File Offset: 0x00000A87
		[DebuggerHidden]
		[CompilerGenerated]
		private void method_23(object object_0)
		{
			this.method_18((List<Class17.Class18>)object_0);
		}

		// Token: 0x040000DE RID: 222
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x040000DF RID: 223
		private List<Class17.Class18> list_0;

		// Token: 0x040000E0 RID: 224
		private ListViewExt listViewExt_0;

		// Token: 0x040000E1 RID: 225
		private string string_0;

		// Token: 0x040000E2 RID: 226
		private int int_0;

		// Token: 0x040000E3 RID: 227
		private int int_1;

		// Token: 0x040000E4 RID: 228
		private Class17.Enum0 enum0_0;

		// Token: 0x040000E5 RID: 229
		private static char char_0;

		// Token: 0x0200001F RID: 31
		public enum Enum0
		{
			// Token: 0x040000E7 RID: 231
			const_0,
			// Token: 0x040000E8 RID: 232
			const_1,
			// Token: 0x040000E9 RID: 233
			const_2,
			// Token: 0x040000EA RID: 234
			const_3,
			// Token: 0x040000EB RID: 235
			const_4,
			// Token: 0x040000EC RID: 236
			const_5,
			// Token: 0x040000ED RID: 237
			const_6
		}

		// Token: 0x02000020 RID: 32
		// (Invoke) Token: 0x06000157 RID: 343
		private delegate void Delegate1(object arg);

		// Token: 0x02000021 RID: 33
		// (Invoke) Token: 0x0600015B RID: 347
		private delegate void Delegate2(List<ListViewItem> o);

		// Token: 0x02000022 RID: 34
		// (Invoke) Token: 0x0600015F RID: 351
		private delegate void Delegate3(string value, int column, ListViewItem item);

		// Token: 0x02000023 RID: 35
		public sealed class Class18
		{
			// Token: 0x06000160 RID: 352 RVA: 0x00002895 File Offset: 0x00000A95
			public Class18()
			{
				this.UseChecked = false;
				this.CountryIndex = -1;
			}

			// Token: 0x17000085 RID: 133
			// (get) Token: 0x06000161 RID: 353 RVA: 0x000028AB File Offset: 0x00000AAB
			// (set) Token: 0x06000162 RID: 354 RVA: 0x000028B3 File Offset: 0x00000AB3
			public bool UseChecked { get; set; }

			// Token: 0x17000086 RID: 134
			// (get) Token: 0x06000163 RID: 355 RVA: 0x000028BC File Offset: 0x00000ABC
			// (set) Token: 0x06000164 RID: 356 RVA: 0x000028C4 File Offset: 0x00000AC4
			public int CountryIndex { get; set; }

			// Token: 0x17000087 RID: 135
			// (get) Token: 0x06000165 RID: 357 RVA: 0x000028CD File Offset: 0x00000ACD
			// (set) Token: 0x06000166 RID: 358 RVA: 0x000028D5 File Offset: 0x00000AD5
			public string[] Items { get; set; }

			// Token: 0x17000088 RID: 136
			// (get) Token: 0x06000167 RID: 359 RVA: 0x000028DE File Offset: 0x00000ADE
			// (set) Token: 0x06000168 RID: 360 RVA: 0x000028E6 File Offset: 0x00000AE6
			public ListViewItem ViewItem { get; set; }

			// Token: 0x06000169 RID: 361 RVA: 0x0000F818 File Offset: 0x0000DA18
			public ListViewItem method_0()
			{
				this.ViewItem = new ListViewItem(this.Items[0]);
				if (this.CountryIndex != -1)
				{
					this.method_2(this.ViewItem);
				}
				checked
				{
					int num = this.Items.Length - 1;
					if (this.UseChecked)
					{
						num--;
					}
					int num2 = num;
					for (int i = 1; i <= num2; i++)
					{
						this.ViewItem.SubItems.Add(this.Items[i]);
					}
					this.ViewItem.Tag = this;
					if (this.UseChecked)
					{
						this.ViewItem.Checked = Conversions.ToBoolean(this.Items[this.Items.Length - 1]);
					}
					return this.ViewItem;
				}
			}

			// Token: 0x0600016A RID: 362 RVA: 0x0000F8D0 File Offset: 0x0000DAD0
			public string method_1()
			{
				StringBuilder stringBuilder = new StringBuilder();
				checked
				{
					int num = this.Items.Length - 1;
					if (this.UseChecked)
					{
						num--;
					}
					int num2 = num;
					for (int i = 0; i <= num2; i++)
					{
						if (i > 0)
						{
							stringBuilder.Append("|");
						}
						stringBuilder.Append(this.Items[i]);
					}
					if (this.UseChecked)
					{
						stringBuilder.Append(this.ViewItem.Checked.ToString());
					}
					return stringBuilder.ToString();
				}
			}

			// Token: 0x0600016B RID: 363 RVA: 0x0000F958 File Offset: 0x0000DB58
			private void method_2(ListViewItem listViewItem_1)
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
						goto IL_F5;
					}
					IL_DB:
					num2 = 19;
					text3 = "??";
					IL_E5:
					num2 = 20;
					text = global::Globals.G_DataGP.CountryNameByCode(text3);
					IL_F5:
					num2 = 22;
					this.Items[this.CountryIndex] = text;
					IL_106:
					num2 = 23;
					if (!text3.Equals("??") && !text3.Equals("EU"))
					{
						goto IL_13D;
					}
					IL_128:
					num2 = 24;
					this.ViewItem.ImageKey = "--.png";
					goto IL_15C;
					IL_13D:
					num2 = 26;
					this.ViewItem.ImageKey = text3.ToLower() + ".png";
					IL_15C:
					goto IL_22A;
					IL_161:
					int num3 = num4 + 1;
					num4 = 0;
					@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
					IL_1E1:
					goto IL_21F;
					IL_1E3:
					num4 = num2;
					@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
					IL_1FC:;
				}
				catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
				{
					Exception ex = (Exception)obj2;
					goto IL_1E3;
				}
				IL_21F:
				throw ProjectData.CreateProjectError(-2146828237);
				IL_22A:
				if (num4 != 0)
				{
					ProjectData.ClearProjectError();
				}
			}

			// Token: 0x0600016C RID: 364 RVA: 0x0000FBB4 File Offset: 0x0000DDB4
			public void method_3()
			{
				this.ViewItem.Text = this.Items[0];
				checked
				{
					int num = this.Items.Length - 1;
					for (int i = 1; i <= num; i++)
					{
						this.ViewItem.SubItems[i].Text = this.Items[i];
					}
				}
			}

			// Token: 0x040000EE RID: 238
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private bool bool_0;

			// Token: 0x040000EF RID: 239
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private int int_0;

			// Token: 0x040000F0 RID: 240
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			private string[] string_0;

			// Token: 0x040000F1 RID: 241
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			private ListViewItem listViewItem_0;
		}

		// Token: 0x02000025 RID: 37
		[CompilerGenerated]
		internal sealed class Class19
		{
			// Token: 0x06000171 RID: 369 RVA: 0x00002908 File Offset: 0x00000B08
			internal bool method_0(Class17.Class18 class18_0)
			{
				return class18_0.Items[0].Equals(this.string_0);
			}

			// Token: 0x040000F4 RID: 244
			public string string_0;
		}

		// Token: 0x02000026 RID: 38
		[CompilerGenerated]
		internal sealed class Class20
		{
			// Token: 0x06000173 RID: 371 RVA: 0x0000291D File Offset: 0x00000B1D
			internal bool method_0(Class17.Class18 class18_0)
			{
				return class18_0.Items[0].ToLower().Contains(this.string_0.ToLower());
			}

			// Token: 0x040000F5 RID: 245
			public string string_0;
		}

		// Token: 0x02000027 RID: 39
		[CompilerGenerated]
		internal sealed class Class21
		{
			// Token: 0x06000175 RID: 373 RVA: 0x0000293C File Offset: 0x00000B3C
			internal bool method_0(Class17.Class18 class18_0)
			{
				return class18_0.Items[this.int_0].ToLower().Contains(this.string_0.ToLower());
			}

			// Token: 0x040000F6 RID: 246
			public int int_0;

			// Token: 0x040000F7 RID: 247
			public string string_0;
		}
	}
}
