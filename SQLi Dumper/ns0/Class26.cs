using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ns0
{
	// Token: 0x0200002D RID: 45
	internal sealed class Class26
	{
		// Token: 0x060001C2 RID: 450 RVA: 0x000111D4 File Offset: 0x0000F3D4
		public Class26()
		{
			this.dictionary_0 = new Dictionary<Class26.Enum1, ListViewGroup>();
			this.dictionary_1 = new Dictionary<Class26.Enum1, List<Class26.Class27>>();
			if (!Globals.IS_DUMP_INSTANCE)
			{
				this.dictionary_0.Add(Class26.Enum1.const_0, new ListViewGroup("Exploiter XSS Vectors"));
				this.dictionary_0.Add(Class26.Enum1.const_1, new ListViewGroup("Exploiter LFi Vectors"));
				this.dictionary_0.Add(Class26.Enum1.const_2, new ListViewGroup("Exploiter SQLi Vectors"));
				this.dictionary_0.Add(Class26.Enum1.const_3, new ListViewGroup("HTTP Status"));
				this.dictionary_0.Add(Class26.Enum1.const_5, new ListViewGroup("Application"));
				this.dictionary_0.Add(Class26.Enum1.const_6, new ListViewGroup("Virtualization"));
				Globals.GMain.lvwStatistics.Groups.AddRange(this.dictionary_0.Values.ToArray<ListViewGroup>());
				try
				{
					foreach (KeyValuePair<Class26.Enum1, ListViewGroup> keyValuePair in this.dictionary_0)
					{
						foreach (string text in Class50.smethod_5("Statistics", Conversions.ToString((int)keyValuePair.Key), "", null).Split(new char[]
						{
							'|'
						}))
						{
							string[] array2 = text.Split(new char[]
							{
								'§'
							});
							if (array2.Length == 2 && keyValuePair.Key != Class26.Enum1.const_4)
							{
								this.method_1(keyValuePair.Key, array2[0], array2[1]);
							}
						}
					}
				}
				finally
				{
					Dictionary<Class26.Enum1, ListViewGroup>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00011378 File Offset: 0x0000F578
		public void method_0()
		{
			if (!Globals.IS_DUMP_INSTANCE)
			{
				try
				{
					foreach (KeyValuePair<Class26.Enum1, List<Class26.Class27>> keyValuePair in this.dictionary_1)
					{
						if (keyValuePair.Key != Class26.Enum1.const_5)
						{
							StringBuilder stringBuilder = new StringBuilder();
							try
							{
								foreach (Class26.Class27 @class in keyValuePair.Value)
								{
									if (!string.IsNullOrEmpty(stringBuilder.ToString()))
									{
										stringBuilder.Append("|");
									}
									stringBuilder.Append(Operators.ConcatenateObject(@class.Name + "§", @class.Value));
								}
							}
							finally
							{
								List<Class26.Class27>.Enumerator enumerator2;
								((IDisposable)enumerator2).Dispose();
							}
							Class50.smethod_4("Statistics", Conversions.ToString((int)keyValuePair.Key), stringBuilder.ToString(), null);
						}
					}
				}
				finally
				{
					Dictionary<Class26.Enum1, List<Class26.Class27>>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00011484 File Offset: 0x0000F684
		public void method_1(Class26.Enum1 enum1_0, string string_1, object object_0)
		{
			Class26.Class28 @class = new Class26.Class28();
			@class.string_0 = string_1;
			if (!Globals.IS_DUMP_INSTANCE)
			{
				if (Globals.GMain.lvwStatistics.InvokeRequired)
				{
					Globals.GMain.lvwStatistics.Invoke(new Class26.Delegate4(this.method_1), new object[]
					{
						enum1_0,
						@class.string_0,
						object_0
					});
				}
				else
				{
					Class26.Class27 class2 = null;
					List<Class26.Class27> list = null;
					if (this.dictionary_1.ContainsKey(enum1_0))
					{
						list = this.dictionary_1[enum1_0];
						class2 = list.Find(new Predicate<Class26.Class27>(@class.method_0));
					}
					if (class2 != null)
					{
						switch (enum1_0)
						{
						case Class26.Enum1.const_4:
						case Class26.Enum1.const_5:
						case Class26.Enum1.const_6:
						case Class26.Enum1.const_7:
							class2.Value = RuntimeHelpers.GetObjectValue(object_0);
							break;
						default:
						{
							Class26.Class27 class3;
							(class3 = class2).Value = Operators.AddObject(class3.Value, object_0);
							break;
						}
						}
					}
					else
					{
						class2 = new Class26.Class27();
						class2.Name = @class.string_0;
						class2.Value = RuntimeHelpers.GetObjectValue(object_0);
						class2.Item = new ListViewItem(@class.string_0);
						object[] array;
						bool[] array2;
						NewLateBinding.LateCall(class2.Item.SubItems, null, "Add", array = new object[]
						{
							object_0
						}, null, null, array2 = new bool[]
						{
							true
						}, true);
						if (array2[0])
						{
							object_0 = RuntimeHelpers.GetObjectValue(array[0]);
						}
						class2.Item.Group = this.dictionary_0[enum1_0];
						if (list == null)
						{
							list = new List<Class26.Class27>();
						}
						list.Add(class2);
						Globals.GMain.lvwStatistics.Items.Add(class2.Item);
						if (!this.dictionary_1.ContainsKey(enum1_0))
						{
							this.dictionary_1.Add(enum1_0, list);
						}
					}
				}
			}
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00011650 File Offset: 0x0000F850
		public void method_2()
		{
			if (!Globals.IS_DUMP_INSTANCE)
			{
				if (Globals.GMain.lvwStatistics.InvokeRequired)
				{
					Globals.GMain.lvwStatistics.Invoke(new EventHandler(this.method_3));
				}
				else
				{
					try
					{
						foreach (KeyValuePair<Class26.Enum1, List<Class26.Class27>> keyValuePair in this.dictionary_1)
						{
							try
							{
								foreach (Class26.Class27 @class in keyValuePair.Value)
								{
									if (keyValuePair.Key == Class26.Enum1.const_4 | keyValuePair.Key == Class26.Enum1.const_5 | keyValuePair.Key == Class26.Enum1.const_6 | keyValuePair.Key == Class26.Enum1.const_7)
									{
										if (@class.Name.Equals(Globals.translate_0.GetStr(Globals.GMain, 107, "")))
										{
											@class.Item.SubItems[1].Text = Globals.FormatBytes(Conversions.ToDouble(@class.Value));
										}
										else
										{
											@class.Item.SubItems[1].Text = Conversions.ToString(@class.Value);
										}
									}
									else
									{
										@class.Item.SubItems[1].Text = Globals.FormatNumbers(Conversions.ToInteger(@class.Value), true);
									}
								}
							}
							finally
							{
								List<Class26.Class27>.Enumerator enumerator2;
								((IDisposable)enumerator2).Dispose();
							}
						}
					}
					finally
					{
						Dictionary<Class26.Enum1, List<Class26.Class27>>.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
				}
			}
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00002B13 File Offset: 0x00000D13
		[CompilerGenerated]
		[DebuggerHidden]
		private void method_3(object sender, EventArgs e)
		{
			this.method_2();
		}

		// Token: 0x04000110 RID: 272
		private static string string_0;

		// Token: 0x04000111 RID: 273
		private Dictionary<Class26.Enum1, ListViewGroup> dictionary_0;

		// Token: 0x04000112 RID: 274
		private Dictionary<Class26.Enum1, List<Class26.Class27>> dictionary_1;

		// Token: 0x0200002E RID: 46
		internal enum Enum1
		{
			// Token: 0x04000114 RID: 276
			const_0,
			// Token: 0x04000115 RID: 277
			const_1,
			// Token: 0x04000116 RID: 278
			const_2,
			// Token: 0x04000117 RID: 279
			const_3,
			// Token: 0x04000118 RID: 280
			const_4,
			// Token: 0x04000119 RID: 281
			const_5,
			// Token: 0x0400011A RID: 282
			const_6,
			// Token: 0x0400011B RID: 283
			const_7
		}

		// Token: 0x0200002F RID: 47
		// (Invoke) Token: 0x060001CA RID: 458
		public delegate void Delegate4(Class26.Enum1 k, string desc, object value);

		// Token: 0x02000030 RID: 48
		public sealed class Class27
		{
			// Token: 0x1700009D RID: 157
			// (get) Token: 0x060001CC RID: 460 RVA: 0x00002B1B File Offset: 0x00000D1B
			// (set) Token: 0x060001CD RID: 461 RVA: 0x00002B23 File Offset: 0x00000D23
			public string Name { get; set; }

			// Token: 0x1700009E RID: 158
			// (get) Token: 0x060001CE RID: 462 RVA: 0x00002B2C File Offset: 0x00000D2C
			// (set) Token: 0x060001CF RID: 463 RVA: 0x00002B34 File Offset: 0x00000D34
			public object Value
			{
				[CompilerGenerated]
				get
				{
					return this.object_0;
				}
				[CompilerGenerated]
				set
				{
					this.object_0 = RuntimeHelpers.GetObjectValue(value);
				}
			}

			// Token: 0x1700009F RID: 159
			// (get) Token: 0x060001D0 RID: 464 RVA: 0x00002B42 File Offset: 0x00000D42
			// (set) Token: 0x060001D1 RID: 465 RVA: 0x00002B4A File Offset: 0x00000D4A
			public ListViewItem Item { get; set; }

			// Token: 0x0400011C RID: 284
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			private string string_0;

			// Token: 0x0400011D RID: 285
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private object object_0;

			// Token: 0x0400011E RID: 286
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private ListViewItem listViewItem_0;
		}

		// Token: 0x02000031 RID: 49
		[CompilerGenerated]
		internal sealed class Class28
		{
			// Token: 0x060001D3 RID: 467 RVA: 0x00002B53 File Offset: 0x00000D53
			internal bool method_0(Class26.Class27 class27_0)
			{
				return class27_0.Name.Equals(this.string_0);
			}

			// Token: 0x0400011F RID: 287
			public string string_0;
		}
	}
}
