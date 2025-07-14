using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ns0
{
	// Token: 0x0200004A RID: 74
	internal sealed class Class37
	{
		// Token: 0x0600025E RID: 606 RVA: 0x00002E54 File Offset: 0x00001054
		public Class37()
		{
			this.dictionary_0 = new Dictionary<string, string>();
			this.list_0 = new List<string>();
			this.list_1 = new List<string>();
			this.struct4_0 = default(Class37.Struct4);
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00013EF4 File Offset: 0x000120F4
		public Dictionary<string, string> method_0()
		{
			return this.dictionary_0;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00013F0C File Offset: 0x0001210C
		public int method_1()
		{
			return this.dictionary_0.Count;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00013F28 File Offset: 0x00012128
		public bool method_2(string string_0)
		{
			bool result;
			if (this.dictionary_0.ContainsValue(string_0))
			{
				result = true;
			}
			else
			{
				string key = Class23.smethod_14(string_0);
				if (this.dictionary_0.ContainsKey(key))
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00013F60 File Offset: 0x00012160
		public int method_3(List<string> list_2)
		{
			int num2;
			int result;
			int num5;
			object obj2;
			try
			{
				IL_02:
				int num = 1;
				List<string> list = new List<string>();
				IL_0A:
				ProjectData.ClearProjectError();
				num2 = -2;
				IL_12:
				num = 3;
				List<string>.Enumerator enumerator = list_2.GetEnumerator();
				checked
				{
					int ptr;
					int num3;
					while (enumerator.MoveNext())
					{
						string text = enumerator.Current;
						IL_30:
						num = 4;
						if (!string.IsNullOrEmpty(text))
						{
							IL_3E:
							num = 6;
							string text2 = Class23.smethod_14(text);
							IL_49:
							num = 7;
							bool flag = true;
							IL_4E:
							num = 9;
							if (flag == !Class23.smethod_13(text, true))
							{
								IL_62:
								num = 10;
								ptr = ref this.struct4_0.int_6;
								this.struct4_0.int_6 = ptr + 1;
							}
							else
							{
								IL_7E:
								num = 12;
								if (flag == this.dictionary_0.ContainsValue(text) || flag == this.dictionary_0.ContainsKey(text2) || flag == this.dictionary_0.ContainsKey(text))
								{
									IL_B9:
									num = 13;
									ptr = ref this.struct4_0.int_1;
									this.struct4_0.int_1 = ptr + 1;
								}
								else
								{
									IL_D5:
									num = 15;
									if (flag == this.dictionary_0.ContainsKey(text2))
									{
										IL_EB:
										num = 16;
										ptr = ref this.struct4_0.int_1;
										this.struct4_0.int_1 = ptr + 1;
									}
									else
									{
										IL_107:
										num = 18;
										if (flag == Globals.GTrash.method_2(text) || flag == Globals.GTrash.method_2(text2))
										{
											IL_12F:
											num = 19;
											ptr = ref this.struct4_0.int_5;
											this.struct4_0.int_5 = ptr + 1;
										}
										else
										{
											IL_14B:
											num = 21;
											if (flag == Globals.DG_SQLi.method_10(text))
											{
												IL_160:
												num = 22;
												ptr = ref this.struct4_0.int_2;
												this.struct4_0.int_2 = ptr + 1;
											}
											else
											{
												IL_17C:
												num = 24;
												if (flag == Globals.DG_SQLiNoInjectable.method_9(text))
												{
													IL_191:
													num = 25;
													ptr = ref this.struct4_0.int_3;
													this.struct4_0.int_3 = ptr + 1;
												}
												else
												{
													IL_1AD:
													num = 27;
													if (flag == Globals.DG_FileInclusao.method_10(text))
													{
														IL_1C2:
														num = 28;
														ptr = ref this.struct4_0.int_4;
														this.struct4_0.int_4 = ptr + 1;
													}
													else
													{
														IL_1DE:
														num = 30;
														if (Conversions.ToBoolean(Globals.GetObjectValue(Globals.GMain.btnSearchFilter)))
														{
															IL_1FA:
															num = 31;
															string[] array = Globals.GetObjectValue(Globals.GMain.txtSearchFilter).ToString().Split(new char[]
															{
																';'
															});
															IL_223:
															num = 32;
															foreach (string text3 in array)
															{
																IL_23E:
																num = 33;
																if (!string.IsNullOrEmpty(text3))
																{
																	IL_24D:
																	num = 34;
																	if (!text.ToLower().Contains(text3.ToLower()))
																	{
																		IL_273:
																		num = 35;
																		ptr = ref this.struct4_0.int_6;
																		this.struct4_0.int_6 = ptr + 1;
																		goto IL_2BC;
																	}
																}
																IL_268:
																num = 39;
															}
														}
														IL_28C:
														num = 41;
														this.dictionary_0.Add(text2, text);
														IL_29E:
														num = 42;
														list.Add(text);
														IL_2A9:
														num = 43;
														num3++;
													}
												}
											}
										}
									}
								}
							}
							IL_2BC:
							num = 44;
							ptr = ref this.struct4_0.int_7;
							this.struct4_0.int_7 = ptr + 1;
						}
						IL_2B4:
						num = 45;
					}
					IL_2D5:
					num = 46;
					((IDisposable)enumerator).Dispose();
					IL_2E5:
					num = 47;
					if (list.Count <= 0)
					{
						goto IL_345;
					}
					IL_2F3:
					num = 48;
					ptr = ref this.struct4_0.int_0;
					this.struct4_0.int_0 = ptr + list.Count;
					IL_30F:
					num = 49;
					object obj = this.list_0;
					lock (obj)
					{
						this.list_0.AddRange(list.ToArray());
					}
					IL_345:
					num = 51;
					result = num3;
					IL_34C:
					goto IL_47A;
					IL_351:;
				}
				int num4 = num5 + 1;
				num5 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_431:
				goto IL_46F;
				IL_433:
				num5 = num;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num2 > -2) ? num2 : 1);
				IL_44C:;
			}
			catch when (endfilter(obj2 is Exception & num2 != 0 & num5 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_433;
			}
			IL_46F:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_47A:
			if (num5 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00014428 File Offset: 0x00012628
		public void method_4()
		{
			int num2;
			int num4;
			object obj5;
			try
			{
				IL_02:
				int num = 1;
				if (!Globals.GMain.dtgQueue.InvokeRequired)
				{
					goto IL_38;
				}
				IL_15:
				num = 2;
				Globals.GMain.dtgQueue.Invoke(new Class37.Delegate11(this.method_4));
				goto IL_1B7;
				IL_38:
				ProjectData.ClearProjectError();
				num2 = -2;
				IL_40:
				num = 5;
				object obj = this.list_0;
				lock (obj)
				{
					if (this.list_0.Count > 0)
					{
						Globals.GMain.dtgQueue.Rows.AddRange(Array.ConvertAll<string, DataGridViewRow>(this.list_0.ToArray(), new Converter<string, DataGridViewRow>(this.method_10)));
						this.list_0.Clear();
						if (Globals.GMain.method_21() == MainForm.Enum6.const_1)
						{
							Globals.GMain.method_32();
						}
					}
				}
				IL_C3:
				num = 6;
				object obj2 = this.list_1;
				lock (obj2)
				{
					if (this.list_1.Count > 0)
					{
						try
						{
							foreach (string obj3 in this.list_1)
							{
								try
								{
									foreach (object obj4 in ((IEnumerable)Globals.GMain.dtgQueue.Rows))
									{
										DataGridViewRow dataGridViewRow = (DataGridViewRow)obj4;
										if (dataGridViewRow.Cells[0].Value.Equals(obj3))
										{
											Globals.GMain.dtgQueue.Rows.Remove(dataGridViewRow);
											break;
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
						finally
						{
							List<string>.Enumerator enumerator;
							((IDisposable)enumerator).Dispose();
						}
						this.list_1.Clear();
					}
				}
				IL_1B7:
				goto IL_232;
				IL_1B9:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_1E9:
				goto IL_227;
				IL_1EB:
				num4 = num;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num2 > -2) ? num2 : 1);
				IL_204:;
			}
			catch when (endfilter(obj5 is Exception & num2 != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj6;
				goto IL_1EB;
			}
			IL_227:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_232:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00002E89 File Offset: 0x00001089
		public void method_5(string string_0)
		{
			this.method_6(new string[]
			{
				string_0
			});
		}

		// Token: 0x06000265 RID: 613 RVA: 0x000146EC File Offset: 0x000128EC
		public void method_6(string[] string_0)
		{
			new List<string>();
			object obj = this.list_1;
			lock (obj)
			{
				foreach (string text in string_0)
				{
					string key = Class23.smethod_14(text);
					if (this.dictionary_0.ContainsKey(key))
					{
						this.dictionary_0.Remove(key);
					}
					this.list_1.Add(text);
				}
			}
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00002E9B File Offset: 0x0000109B
		public void method_7()
		{
			this.dictionary_0 = new Dictionary<string, string>();
			this.list_0 = new List<string>();
			this.list_1 = new List<string>();
			Globals.GMain.dtgQueue.Rows.Clear();
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00014778 File Offset: 0x00012978
		public void method_8()
		{
			int num;
			int num4;
			object obj2;
			try
			{
				IL_02:
				ProjectData.ClearProjectError();
				num = -2;
				IL_0A:
				int num2 = 2;
				object obj = this.dictionary_0;
				lock (obj)
				{
					this.dictionary_0 = null;
				}
				IL_32:
				goto IL_95;
				IL_34:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_4E:
				goto IL_8A;
				IL_50:
				num4 = num2;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
				IL_68:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_50;
			}
			IL_8A:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_95:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00014840 File Offset: 0x00012A40
		public void method_9()
		{
			if (File.Exists(Globals.QUEUE_PATH))
			{
				string[] array = File.ReadAllLines(Globals.QUEUE_PATH);
				foreach (string text in array)
				{
					string key = Class23.smethod_14(text);
					if (!this.dictionary_0.ContainsKey(key))
					{
						this.dictionary_0.Add(key, text);
					}
				}
			}
			Globals.GMain.dtgQueue.Rows.AddRange(Array.ConvertAll<string, DataGridViewRow>(this.dictionary_0.Values.ToArray<string>(), new Converter<string, DataGridViewRow>(this.method_10)));
		}

		// Token: 0x06000269 RID: 617 RVA: 0x000148D8 File Offset: 0x00012AD8
		private DataGridViewRow method_10(string string_0)
		{
			DataGridViewRow dataGridViewRow = new DataGridViewRow();
			dataGridViewRow.CreateCells(Globals.GMain.dtgQueue);
			dataGridViewRow.SetValues(new object[]
			{
				string_0
			});
			return dataGridViewRow;
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00002ED2 File Offset: 0x000010D2
		public void method_11()
		{
			if (File.Exists(Globals.QUEUE_PATH))
			{
				File.Delete(Globals.QUEUE_PATH);
			}
			File.WriteAllLines(Globals.QUEUE_PATH, this.dictionary_0.Values.ToArray<string>());
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00002F04 File Offset: 0x00001104
		public void method_12()
		{
			this.struct4_0 = default(Class37.Struct4);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00014910 File Offset: 0x00012B10
		public Class37.Struct4 method_13()
		{
			return this.struct4_0;
		}

		// Token: 0x040001AB RID: 427
		private Class37.Struct4 struct4_0;

		// Token: 0x040001AC RID: 428
		private Dictionary<string, string> dictionary_0;

		// Token: 0x040001AD RID: 429
		private List<string> list_0;

		// Token: 0x040001AE RID: 430
		private List<string> list_1;

		// Token: 0x0200004B RID: 75
		// (Invoke) Token: 0x06000270 RID: 624
		private delegate void Delegate11();

		// Token: 0x0200004C RID: 76
		// (Invoke) Token: 0x06000274 RID: 628
		private delegate void Delegate12(List<string> urls);

		// Token: 0x0200004D RID: 77
		// (Invoke) Token: 0x06000278 RID: 632
		private delegate void Delegate13(string url);

		// Token: 0x0200004E RID: 78
		public struct Struct4
		{
			// Token: 0x040001AF RID: 431
			public int int_0;

			// Token: 0x040001B0 RID: 432
			public int int_1;

			// Token: 0x040001B1 RID: 433
			public int int_2;

			// Token: 0x040001B2 RID: 434
			public int int_3;

			// Token: 0x040001B3 RID: 435
			public int int_4;

			// Token: 0x040001B4 RID: 436
			public int int_5;

			// Token: 0x040001B5 RID: 437
			public int int_6;

			// Token: 0x040001B6 RID: 438
			public int int_7;
		}
	}
}
