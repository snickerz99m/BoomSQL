using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ns0
{
	// Token: 0x020000E9 RID: 233
	[StandardModule]
	internal sealed class Class50
	{
		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x0600101D RID: 4125 RVA: 0x0006E480 File Offset: 0x0006C680
		public static Class51 Class51_0
		{
			get
			{
				return Class50.class51_0;
			}
		}

		// Token: 0x0600101E RID: 4126 RVA: 0x00008C29 File Offset: 0x00006E29
		public static void smethod_0()
		{
			Class50.class51_0 = new Class51(Globals.XML_PATH, "SQLi_Dumper", ';', 0);
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x00008C42 File Offset: 0x00006E42
		public static void smethod_1()
		{
			Class50.class51_0.method_9(true, true);
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x0006E494 File Offset: 0x0006C694
		public static void smethod_2(Form form_0, Class51 class51_1 = null)
		{
			int num2;
			int num4;
			object obj;
			try
			{
				IL_02:
				int num = 1;
				if (class51_1 != null)
				{
					goto IL_15;
				}
				IL_0A:
				num = 2;
				class51_1 = Class50.class51_0;
				IL_15:
				num = 3;
				Hashtable hashtable = Class50.smethod_6(form_0);
				IL_1E:
				ProjectData.ClearProjectError();
				num2 = -2;
				IL_26:
				num = 5;
				IEnumerator enumerator = class51_1.method_2(form_0.Name).Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Class52 @class = (Class52)enumerator.Current;
					IL_57:
					num = 6;
					if (hashtable.Contains(@class.String_0))
					{
						IL_6B:
						num = 7;
						object objectValue = RuntimeHelpers.GetObjectValue(hashtable[@class.String_0]);
						IL_81:
						num = 8;
						if (objectValue != null)
						{
							IL_8D:
							num = 9;
							if (Class50.smethod_10(RuntimeHelpers.GetObjectValue(objectValue)))
							{
								IL_A1:
								num = 10;
								bool flag = true;
								IL_A7:
								num = 12;
								if (flag == objectValue is TextBox)
								{
									IL_BA:
									num = 13;
									((TextBox)objectValue).Text = @class.String_1;
								}
								else
								{
									IL_D5:
									num = 15;
									if (flag == objectValue is ComboBox)
									{
										IL_E8:
										num = 16;
										((ComboBox)objectValue).Text = @class.String_1;
									}
									else
									{
										IL_103:
										num = 18;
										if (flag == objectValue is CheckBox)
										{
											IL_116:
											num = 19;
											((CheckBox)objectValue).Checked = Conversions.ToBoolean(@class.String_1);
										}
										else
										{
											IL_136:
											num = 21;
											if (flag == objectValue is RadioButton)
											{
												IL_149:
												num = 22;
												((RadioButton)objectValue).Checked = Conversions.ToBoolean(@class.String_1);
											}
											else
											{
												IL_169:
												num = 24;
												if (flag == objectValue is NumericUpDown)
												{
													IL_17C:
													num = 25;
													((NumericUpDown)objectValue).Value = new decimal(Conversions.ToInteger(@class.String_1));
												}
												else
												{
													IL_1A1:
													num = 27;
													if (flag == objectValue is TrackBar)
													{
														IL_1B4:
														num = 28;
														((TrackBar)objectValue).Value = Conversions.ToInteger(@class.String_1);
													}
													else
													{
														IL_1D4:
														num = 30;
														if (flag == objectValue is ToolStripTextBox)
														{
															IL_1E7:
															num = 31;
															((ToolStripTextBox)objectValue).Text = @class.String_1;
														}
														else
														{
															IL_202:
															num = 33;
															if (flag == objectValue is ToolStripComboBox)
															{
																IL_215:
																num = 34;
																((ToolStripTextBox)objectValue).Text = @class.String_1;
															}
															else
															{
																IL_230:
																num = 36;
																if (flag == objectValue is ToolStripSpringTextBox)
																{
																	IL_243:
																	num = 37;
																	((ToolStripSpringTextBox)objectValue).Text = @class.String_1;
																}
																else
																{
																	IL_25E:
																	num = 39;
																	if (flag == objectValue is ToolStripControl)
																	{
																		IL_271:
																		num = 40;
																		((ToolStripControl)objectValue).Value = Conversions.ToDecimal(@class.String_1);
																	}
																	else
																	{
																		IL_28E:
																		num = 42;
																		if (flag == objectValue is ToolStripButton)
																		{
																			IL_2A1:
																			num = 43;
																			if (((ToolStripButton)objectValue).CheckOnClick)
																			{
																				IL_2B2:
																				num = 44;
																				((ToolStripButton)objectValue).Checked = Conversions.ToBoolean(@class.String_1);
																			}
																		}
																		else
																		{
																			IL_2CF:
																			num = 47;
																			if (flag == objectValue is TreeViewExt)
																			{
																				IL_2E2:
																				num = 48;
																				Class50.smethod_9((TreeViewExt)objectValue, @class.String_1);
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					IL_2F8:
					num = 53;
				}
				IL_300:
				num = 54;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
				IL_316:
				goto IL_450;
				IL_31B:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_407:
				goto IL_445;
				IL_409:
				num4 = num;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num2 > -2) ? num2 : 1);
				IL_422:;
			}
			catch when (endfilter(obj is Exception & num2 != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_409;
			}
			IL_445:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_450:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x06001021 RID: 4129 RVA: 0x0006E918 File Offset: 0x0006CB18
		public static void smethod_3(Form form_0, Class51 class51_1 = null)
		{
			int num2;
			int num4;
			object obj;
			try
			{
				IL_02:
				int num = 1;
				if (class51_1 != null)
				{
					goto IL_15;
				}
				IL_0A:
				num = 2;
				class51_1 = Class50.class51_0;
				IL_15:
				ProjectData.ClearProjectError();
				num2 = -2;
				IL_1D:
				num = 4;
				IEnumerator enumerator = Class50.smethod_6(form_0).Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
					IL_47:
					num = 5;
					if (objectValue != null)
					{
						IL_52:
						num = 6;
						if (Class50.smethod_10(RuntimeHelpers.GetObjectValue(objectValue)))
						{
							IL_64:
							num = 7;
							bool flag = true;
							IL_69:
							num = 9;
							if (flag == objectValue is TextBox)
							{
								IL_7B:
								num = 10;
								class51_1.method_6(form_0.Name, Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null)), ((TextBox)objectValue).Text);
							}
							else
							{
								IL_B4:
								num = 12;
								if (flag == objectValue is ComboBox)
								{
									IL_C6:
									num = 13;
									class51_1.method_6(form_0.Name, Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null)), ((ComboBox)objectValue).Text);
								}
								else
								{
									IL_FF:
									num = 15;
									if (flag == objectValue is CheckBox)
									{
										IL_111:
										num = 16;
										class51_1.method_6(form_0.Name, Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null)), ((CheckBox)objectValue).Checked.ToString());
									}
									else
									{
										IL_153:
										num = 18;
										if (flag == objectValue is RadioButton)
										{
											IL_165:
											num = 19;
											class51_1.method_6(form_0.Name, Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null)), ((RadioButton)objectValue).Checked.ToString());
										}
										else
										{
											IL_1A7:
											num = 21;
											if (flag == objectValue is NumericUpDown)
											{
												IL_1B9:
												num = 22;
												class51_1.method_6(form_0.Name, Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null)), ((NumericUpDown)objectValue).Value.ToString());
											}
											else
											{
												IL_1FB:
												num = 24;
												if (flag == objectValue is TrackBar)
												{
													IL_20D:
													num = 25;
													class51_1.method_6(form_0.Name, Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null)), ((TrackBar)objectValue).Value.ToString());
												}
												else
												{
													IL_24F:
													num = 27;
													if (flag == objectValue is ToolStripTextBox)
													{
														IL_261:
														num = 28;
														class51_1.method_6(form_0.Name, Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null)), ((ToolStripTextBox)objectValue).Text);
													}
													else
													{
														IL_29A:
														num = 30;
														if (flag == objectValue is ToolStripComboBox)
														{
															IL_2AC:
															num = 31;
															class51_1.method_6(form_0.Name, Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null)), ((ToolStripComboBox)objectValue).Text);
														}
														else
														{
															IL_2E5:
															num = 33;
															if (flag == objectValue is ToolStripButton)
															{
																IL_2F7:
																num = 34;
																if (((ToolStripButton)objectValue).CheckOnClick)
																{
																	IL_30A:
																	num = 35;
																	class51_1.method_6(form_0.Name, Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null)), ((ToolStripButton)objectValue).Checked.ToString());
																}
															}
															else
															{
																IL_34C:
																num = 38;
																if (flag == objectValue is TreeViewExt)
																{
																	IL_35E:
																	num = 39;
																	Class50.smethod_8(form_0.Name, (TreeViewExt)objectValue, class51_1);
																}
																else
																{
																	IL_379:
																	num = 41;
																	if (flag == objectValue is ToolStripSpringTextBox)
																	{
																		IL_38B:
																		num = 42;
																		class51_1.method_6(form_0.Name, Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null)), ((ToolStripSpringTextBox)objectValue).Text);
																	}
																	else
																	{
																		IL_3C1:
																		num = 44;
																		if (flag == objectValue is ToolStripControl)
																		{
																			IL_3D3:
																			num = 45;
																			class51_1.method_6(form_0.Name, Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null)), Conversions.ToString(((ToolStripControl)objectValue).Value));
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					IL_40C:
					num = 49;
				}
				IL_414:
				num = 50;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
				IL_42A:
				goto IL_554;
				IL_42F:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_50B:
				goto IL_549;
				IL_50D:
				num4 = num;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num2 > -2) ? num2 : 1);
				IL_526:;
			}
			catch when (endfilter(obj is Exception & num2 != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_50D;
			}
			IL_549:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_554:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x06001022 RID: 4130 RVA: 0x00008C50 File Offset: 0x00006E50
		public static void smethod_4(string string_0, string string_1, string string_2, Class51 class51_1 = null)
		{
			if (class51_1 == null)
			{
				class51_1 = Class50.class51_0;
			}
			class51_1.method_6(string_0, string_1, string_2);
		}

		// Token: 0x06001023 RID: 4131 RVA: 0x0006EEA0 File Offset: 0x0006D0A0
		public static string smethod_5(string string_0, string string_1, string string_2, Class51 class51_1 = null)
		{
			if (class51_1 == null)
			{
				class51_1 = Class50.class51_0;
			}
			return class51_1.method_3(string_0, string_1, string_2);
		}

		// Token: 0x06001024 RID: 4132 RVA: 0x0006EEC8 File Offset: 0x0006D0C8
		public static Hashtable smethod_6(Form form_0)
		{
			Hashtable hashtable = new Hashtable();
			try
			{
				foreach (object obj in form_0.Controls)
				{
					Control control = (Control)obj;
					if (control != null && !string.IsNullOrEmpty(control.Name))
					{
						if (!hashtable.Contains(control.Name))
						{
							hashtable.Add(control.Name, control);
						}
						if (control is ToolStrip)
						{
							try
							{
								foreach (object obj2 in ((ToolStrip)control).Items)
								{
									ToolStripItem toolStripItem = (ToolStripItem)obj2;
									bool flag;
									if ((!hashtable.Contains(toolStripItem.Name) & !string.IsNullOrEmpty(toolStripItem.Name)) && ((flag = true) == toolStripItem is ToolStripTextBox || flag == toolStripItem is ToolStripComboBox || flag == toolStripItem is ToolStripSeparator || flag == toolStripItem is ToolStripLabel || flag == toolStripItem is ToolStripButton) && !hashtable.Contains(toolStripItem.Name))
									{
										hashtable.Add(toolStripItem.Name, toolStripItem);
									}
								}
								continue;
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
						if (control is SplitContainer)
						{
							if (((SplitContainer)control).Panel1.Controls.Count > 0)
							{
								Class50.smethod_7(((SplitContainer)control).Panel1, ref hashtable);
							}
							if (((SplitContainer)control).Panel2.Controls.Count > 0)
							{
								Class50.smethod_7(((SplitContainer)control).Panel2, ref hashtable);
							}
						}
						else if (control.Controls.Count > 0)
						{
							Class50.smethod_7(control, ref hashtable);
						}
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
			return hashtable;
		}

		// Token: 0x06001025 RID: 4133 RVA: 0x0006F0F4 File Offset: 0x0006D2F4
		public static void smethod_7(Control control_0, ref Hashtable hashtable_0)
		{
			try
			{
				foreach (object obj in control_0.Controls)
				{
					Control control = (Control)obj;
					if (control != null && !string.IsNullOrEmpty(control.Name))
					{
						if (!hashtable_0.Contains(control.Name))
						{
							hashtable_0.Add(control.Name, control);
						}
						if (control.Controls.Count > 0)
						{
							if (control is SplitContainer)
							{
								Class50.smethod_7(((SplitContainer)control).Panel1, ref hashtable_0);
								Class50.smethod_7(((SplitContainer)control).Panel2, ref hashtable_0);
							}
							else
							{
								Class50.smethod_7(control, ref hashtable_0);
							}
						}
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
		}

		// Token: 0x06001026 RID: 4134 RVA: 0x0006F1CC File Offset: 0x0006D3CC
		public static string smethod_8(string string_0, TreeViewExt treeViewExt_0, Class51 class51_1 = null)
		{
			string result;
			try
			{
				string text = "";
				try
				{
					foreach (object obj in treeViewExt_0.Nodes)
					{
						TreeNode treeNode = (TreeNode)obj;
						if (treeNode.Nodes.Count == 0)
						{
							if (Operators.CompareString(text, "", false) == 0)
							{
								text = treeNode.FullPath;
							}
							else
							{
								text = text + "|" + treeNode.FullPath;
							}
						}
						else
						{
							try
							{
								foreach (object obj2 in treeNode.Nodes)
								{
									TreeNode treeNode2 = (TreeNode)obj2;
									if (treeNode2.Nodes.Count == 0)
									{
										if (Operators.CompareString(text, "", false) == 0)
										{
											text = treeNode2.FullPath;
										}
										else
										{
											text = text + "|" + treeNode2.FullPath;
										}
									}
									else
									{
										try
										{
											foreach (object obj3 in treeNode2.Nodes)
											{
												TreeNode treeNode3 = (TreeNode)obj3;
												if (treeNode3.Nodes.Count == 0)
												{
													if (Operators.CompareString(text, "", false) == 0)
													{
														text = treeNode3.FullPath;
													}
													else
													{
														text = text + "|" + treeNode3.FullPath;
													}
												}
												else
												{
													try
													{
														foreach (object obj4 in treeNode3.Nodes)
														{
															TreeNode treeNode4 = (TreeNode)obj4;
															if (Operators.CompareString(text, "", false) == 0)
															{
																text = treeNode4.FullPath;
															}
															else
															{
																text = text + "|" + treeNode4.FullPath;
															}
														}
													}
													finally
													{
														IEnumerator enumerator4;
														if (enumerator4 is IDisposable)
														{
															(enumerator4 as IDisposable).Dispose();
														}
													}
												}
												text = text + "\\" + treeNode3.Checked.ToString();
											}
										}
										finally
										{
											IEnumerator enumerator3;
											if (enumerator3 is IDisposable)
											{
												(enumerator3 as IDisposable).Dispose();
											}
										}
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
				}
				finally
				{
					IEnumerator enumerator;
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				if (class51_1 != null)
				{
					class51_1.method_6(string_0, treeViewExt_0.Name, text);
				}
				result = text;
			}
			catch (Exception ex)
			{
			}
			return result;
		}

		// Token: 0x06001027 RID: 4135 RVA: 0x0006F4A4 File Offset: 0x0006D6A4
		public static void smethod_9(TreeViewExt treeViewExt_0, string string_0)
		{
			try
			{
				string[] array = string_0.Split(new char[]
				{
					'|'
				});
				treeViewExt_0.BeginUpdate();
				treeViewExt_0.Nodes.Clear();
				foreach (string text in array)
				{
					string[] array3 = text.Split(new char[]
					{
						'\\'
					});
					int num = array3.Length;
					if (num != 1)
					{
						if (num != 2)
						{
							TreeNode treeNode = treeViewExt_0.Nodes[array3[0]];
							if (treeNode == null)
							{
								treeNode = treeViewExt_0.Nodes.Add(array3[0], array3[0], 0);
							}
							TreeNode treeNode2 = treeNode.Nodes[array3[1]];
							if (treeNode2 == null)
							{
								treeNode = treeNode.Nodes.Add(array3[1], array3[1], 1);
								treeNode.SelectedImageIndex = 1;
							}
							else
							{
								treeNode = treeNode2;
							}
							if (treeNode != null)
							{
								treeNode = treeNode.Nodes.Add(array3[2], array3[2], 2);
								treeNode.SelectedImageIndex = 2;
								if (array3.Length > 3)
								{
									treeNode.Checked = Conversions.ToBoolean(array3[3]);
								}
							}
						}
						else
						{
							TreeNode treeNode = treeViewExt_0.Nodes[array3[0]];
							if (treeNode == null)
							{
								treeNode = treeViewExt_0.Nodes.Add(array3[0], array3[0], 0);
							}
							TreeNode treeNode2 = treeNode.Nodes[array3[1]];
							if (treeNode2 == null)
							{
								treeNode = treeNode.Nodes.Add(array3[1], array3[1], 1);
								treeNode.SelectedImageIndex = 1;
							}
						}
					}
					else if (!string.IsNullOrEmpty(array3[0]))
					{
						treeViewExt_0.Nodes.Add(array3[0], array3[0], 0);
					}
				}
			}
			catch (Exception ex)
			{
			}
			finally
			{
				treeViewExt_0.EndUpdate();
			}
		}

		// Token: 0x06001028 RID: 4136 RVA: 0x0006F6A8 File Offset: 0x0006D8A8
		private static bool smethod_10(object object_0)
		{
			return true != (object_0 == Globals.GMain.twMain);
		}

		// Token: 0x040007FF RID: 2047
		private static Class51 class51_0;
	}
}
