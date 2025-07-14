using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Chilkat;
using Microsoft.VisualBasic.CompilerServices;
using SkinSoft.VisualStyler;

namespace ns0
{
	// Token: 0x02000047 RID: 71
	internal sealed class Class35
	{
		// Token: 0x0600023B RID: 571 RVA: 0x00012E4C File Offset: 0x0001104C
		public Class35()
		{
			this.list_0 = new List<Class35.Class36>();
			this.dictionary_0 = new Dictionary<string, Class35.Class36>();
			Globals.GMain.dtgSocks.CellValueChanged += this.method_0;
			Globals.GMain.dtgSocks.DoubleClick += this.method_1;
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600023C RID: 572 RVA: 0x00002DCF File Offset: 0x00000FCF
		// (set) Token: 0x0600023D RID: 573 RVA: 0x00002DD7 File Offset: 0x00000FD7
		public bool UseMyIP { get; set; }

		// Token: 0x0600023E RID: 574 RVA: 0x00012EAC File Offset: 0x000110AC
		private void method_0(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				Class35.Class36 @class = (Class35.Class36)Globals.GMain.dtgSocks.Rows[e.RowIndex].Tag;
				@class.Checked = Conversions.ToBoolean(Globals.GMain.dtgSocks.Rows[e.RowIndex].Cells[0].Value);
				if (@class.Checked)
				{
					if (!this.list_0.Contains(@class))
					{
						this.list_0.Add(@class);
					}
				}
				else
				{
					this.list_0.Remove(@class);
				}
			}
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00012F58 File Offset: 0x00011158
		private void method_1(object sender, EventArgs e)
		{
			if (Globals.GMain.dtgSocks.SelectedRows.Count == 1)
			{
				Globals.GMain.dtgSocks.SelectedRows[0].Cells[0].Value = Operators.NotObject(Globals.GMain.dtgSocks.SelectedRows[0].Cells[0].Value);
			}
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00012FD0 File Offset: 0x000111D0
		private void method_2(DataGridViewRow dataGridViewRow_0)
		{
			if (Globals.GMain.chkSkin.Checked)
			{
				DataGridViewCellStyle dataGridViewCellStyle = Globals.GMain.dtgSocks.DefaultCellStyle.Clone();
				if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dataGridViewRow_0.Cells[0].Value, true, false), Globals.GMain.chkSkin.Checked)))
				{
					dataGridViewCellStyle.BackColor = VisualStyler.GetSystemColor(KnownColor.ControlLightLight);
				}
				dataGridViewRow_0.DefaultCellStyle = dataGridViewCellStyle;
			}
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00013054 File Offset: 0x00011254
		public void method_3(string string_1)
		{
			try
			{
				string[] array;
				if (string_1.Contains("|"))
				{
					array = string_1.Split(new char[]
					{
						'|'
					});
				}
				else
				{
					if (!string_1.Contains(":"))
					{
						return;
					}
					array = string_1.Split(new char[]
					{
						':'
					});
				}
				if (!this.dictionary_0.ContainsKey(string_1))
				{
					int num = array.Length;
					Class35.Class36 @class;
					if (num == 3)
					{
						@class = new Class35.Class36(array[0], Conversions.ToInteger(array[1]), Conversions.ToInteger(array[2]), "", "", false);
					}
					else if (num == 6)
					{
						@class = new Class35.Class36(array[0], Conversions.ToInteger(array[1]), Conversions.ToInteger(array[2]), array[3], array[4], Conversions.ToBoolean(array[5]));
						if (Conversions.ToBoolean(array[5]))
						{
							this.list_0.Add(@class);
						}
					}
					else
					{
						if (num <= 3)
						{
							return;
						}
						@class = new Class35.Class36(array[0], Conversions.ToInteger(array[1]), Conversions.ToInteger(array[2]), array[3], array[4], false);
					}
					if (!this.dictionary_0.ContainsKey(@class.method_1(false)))
					{
						this.dictionary_0.Add(@class.method_1(false), @class);
					}
					Globals.GMain.dtgSocks.Rows.Add(@class);
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000242 RID: 578 RVA: 0x000131C8 File Offset: 0x000113C8
		public void method_4(string[] string_1)
		{
			if (string_1.Length > 10)
			{
				foreach (string key in string_1)
				{
					if (this.dictionary_0.ContainsKey(key))
					{
						Class35.Class36 item = this.dictionary_0[key];
						if (this.list_0.Contains(item))
						{
							this.list_0.Remove(item);
						}
						this.dictionary_0.Remove(key);
					}
				}
				this.method_5();
			}
			else
			{
				foreach (string string_2 in string_1)
				{
					this.method_6(string_2);
				}
			}
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00013268 File Offset: 0x00011468
		private void method_5()
		{
			int num;
			if (Globals.GMain.dtgSocks.SelectedRows.Count > 0)
			{
				num = Globals.GMain.dtgSocks.SelectedRows[0].Index;
			}
			Globals.GMain.dtgSocks.Rows.Clear();
			if (this.dictionary_0.Count > 0)
			{
				List<DataGridViewRow> list = new List<DataGridViewRow>();
				try
				{
					foreach (Class35.Class36 item in this.dictionary_0.Values)
					{
						list.Add(item);
					}
				}
				finally
				{
					Dictionary<string, Class35.Class36>.ValueCollection.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				Globals.GMain.dtgSocks.Rows.AddRange(list.ToArray());
				if (num > checked(Globals.GMain.dtgSocks.RowCount + 1))
				{
					num = 0;
				}
				Globals.GMain.dtgSocks.FirstDisplayedScrollingRowIndex = num;
			}
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00013364 File Offset: 0x00011564
		public void method_6(string string_1)
		{
			if (!string.IsNullOrEmpty(string_1) && this.dictionary_0.ContainsKey(string_1))
			{
				Class35.Class36 @class = this.dictionary_0[string_1];
				Globals.GMain.dtgSocks.Rows.Remove(@class);
				this.dictionary_0.Remove(string_1);
				if (this.list_0.Contains(@class))
				{
					this.list_0.Remove(@class);
				}
			}
		}

		// Token: 0x06000245 RID: 581 RVA: 0x00002DE0 File Offset: 0x00000FE0
		public void method_7()
		{
			this.dictionary_0.Clear();
			this.list_0.Clear();
			this.int_0 = 0;
			Globals.GMain.dtgSocks.Rows.Clear();
		}

		// Token: 0x06000246 RID: 582 RVA: 0x000133D4 File Offset: 0x000115D4
		public List<string> method_8()
		{
			List<string> list = new List<string>();
			try
			{
				foreach (Class35.Class36 @class in this.dictionary_0.Values)
				{
					list.Add(string.Concat(new string[]
					{
						@class.String_0,
						"|",
						@class.Port.ToString(),
						"|",
						Conversions.ToString(@class.Version),
						"|",
						@class.Username,
						"|",
						@class.Password
					}));
				}
			}
			finally
			{
				Dictionary<string, Class35.Class36>.ValueCollection.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0001349C File Offset: 0x0001169C
		public int method_9()
		{
			checked
			{
				int result;
				if (Globals.GMain.dtgSocks.InvokeRequired)
				{
					result = Conversions.ToInteger(Globals.GMain.dtgSocks.Invoke(new Class35.Delegate10(this.method_9)));
				}
				else
				{
					int num;
					try
					{
						foreach (Class35.Class36 @class in this.dictionary_0.Values)
						{
							if (@class.Checked)
							{
								num++;
							}
						}
					}
					finally
					{
						Dictionary<string, Class35.Class36>.ValueCollection.Enumerator enumerator;
						((IDisposable)enumerator).Dispose();
					}
					result = num;
				}
				return result;
			}
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00013534 File Offset: 0x00011734
		public int method_10()
		{
			int result;
			if (Globals.GMain.dtgSocks.InvokeRequired)
			{
				result = Conversions.ToInteger(Globals.GMain.dtgSocks.Invoke(new Class35.Delegate10(this.method_10)));
			}
			else
			{
				result = this.dictionary_0.Count;
			}
			return result;
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00013584 File Offset: 0x00011784
		public void method_11(ref byte byte_0, ref string string_1, ref int int_1, ref string string_2, ref string string_3, ref string string_4)
		{
			string_4 = "";
			byte_0 = 0;
			string_1 = "";
			int_1 = 0;
			string_2 = "";
			string_3 = "";
			checked
			{
				if (this.list_0.Count > 0)
				{
					lock (this)
					{
						if (this.int_0 >= this.list_0.Count)
						{
							this.int_0 = 0;
						}
						if (this.UseMyIP & this.int_0 - 1 < 0)
						{
							string_4 = "MyIP";
						}
						else
						{
							Class35.Class36 @class = this.list_0[this.int_0];
							if (@class.Version == 0)
							{
								byte_0 = 1;
								string_1 = @class.String_0;
								int_1 = @class.Port;
								string_2 = @class.Username;
								string_3 = @class.Password;
							}
							else
							{
								byte_0 = (byte)@class.Version;
								string_1 = @class.String_0;
								int_1 = @class.Port;
								string_2 = @class.Username;
								string_3 = @class.Password;
							}
							string_4 = @class.String_0 + ":" + Conversions.ToString(@class.Port);
						}
						ref int ptr = ref this.int_0;
						this.int_0 = ptr + 1;
					}
				}
			}
		}

		// Token: 0x0600024A RID: 586 RVA: 0x000136CC File Offset: 0x000118CC
		public void method_12(ref Http http_0, ref string string_1)
		{
			string_1 = "";
			http_0.ProxyDomain = "";
			http_0.ProxyPort = 0;
			http_0.ProxyLogin = "";
			http_0.ProxyPassword = "";
			http_0.SocksVersion = 0;
			http_0.SocksHostname = "";
			http_0.SocksPort = 0;
			http_0.SocksUsername = "";
			http_0.SocksPassword = "";
			checked
			{
				if (this.list_0.Count > 0)
				{
					lock (this)
					{
						if (this.int_0 >= this.list_0.Count)
						{
							this.int_0 = 0;
						}
						if (this.UseMyIP & this.int_0 - 1 < 0)
						{
							string_1 = "MyIP";
						}
						else
						{
							Class35.Class36 @class = this.list_0[this.int_0];
							if (@class.Version == 0)
							{
								http_0.ProxyDomain = @class.String_0;
								http_0.ProxyPort = @class.Port;
								http_0.ProxyLogin = @class.Username;
								http_0.ProxyPassword = @class.Password;
							}
							else
							{
								http_0.SocksVersion = @class.Version;
								http_0.SocksHostname = @class.String_0;
								http_0.SocksPort = @class.Port;
								http_0.SocksUsername = @class.Username;
								http_0.SocksPassword = @class.Password;
							}
							string_1 = @class.String_0 + ":" + Conversions.ToString(@class.Port);
						}
						ref int ptr = ref this.int_0;
						this.int_0 = ptr + 1;
					}
				}
			}
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00013884 File Offset: 0x00011A84
		public bool method_13(ref Http http_0, ref string string_1, List<string> list_1)
		{
			string_1 = "";
			http_0.ProxyDomain = "";
			http_0.ProxyPort = 0;
			http_0.ProxyLogin = "";
			http_0.ProxyPassword = "";
			http_0.SocksVersion = 0;
			http_0.SocksHostname = "";
			http_0.SocksPort = 0;
			http_0.SocksUsername = "";
			http_0.SocksPassword = "";
			List<Class35.Class36> list = new List<Class35.Class36>();
			try
			{
				foreach (Class35.Class36 @class in this.list_0)
				{
					if (!list_1.Contains(@class.String_0 + ":" + Conversions.ToString(@class.Port)))
					{
						list.Add(@class);
					}
				}
			}
			finally
			{
				List<Class35.Class36>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
			checked
			{
				bool result;
				if (this.list_0.Count > 0 & list.Count == 0)
				{
					result = false;
				}
				else
				{
					lock (this)
					{
						if (this.int_0 >= list.Count)
						{
							this.int_0 = 0;
						}
						if (this.UseMyIP & this.int_0 - 1 < 0)
						{
							string_1 = "MyIP";
						}
						else
						{
							Class35.Class36 class2 = list[this.int_0];
							if (class2.Version == 0)
							{
								http_0.ProxyDomain = class2.String_0;
								http_0.ProxyPort = class2.Port;
								http_0.ProxyLogin = class2.Username;
								http_0.ProxyPassword = class2.Password;
							}
							else
							{
								http_0.SocksVersion = class2.Version;
								http_0.SocksHostname = class2.String_0;
								http_0.SocksPort = class2.Port;
								http_0.SocksUsername = class2.Username;
								http_0.SocksPassword = class2.Password;
							}
							string_1 = class2.String_0 + ":" + Conversions.ToString(class2.Port);
						}
						ref int ptr = ref this.int_0;
						this.int_0 = ptr + 1;
					}
					result = true;
				}
				return result;
			}
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00013AD4 File Offset: 0x00011CD4
		private int method_14(int int_1, int int_2)
		{
			if (this.$STATIC$GetRandom$202888$r$Init == null)
			{
				Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.$STATIC$GetRandom$202888$r$Init, new StaticLocalInitFlag(), null);
			}
			bool flag = false;
			try
			{
				Monitor.Enter(this.$STATIC$GetRandom$202888$r$Init, ref flag);
				if (this.$STATIC$GetRandom$202888$r$Init.State == 0)
				{
					this.$STATIC$GetRandom$202888$r$Init.State = 2;
					this.$STATIC$GetRandom$202888$r = new Random();
				}
				else if (this.$STATIC$GetRandom$202888$r$Init.State == 2)
				{
					throw new IncompleteInitialization();
				}
			}
			finally
			{
				this.$STATIC$GetRandom$202888$r$Init.State = 1;
				if (flag)
				{
					Monitor.Exit(this.$STATIC$GetRandom$202888$r$Init);
				}
			}
			checked
			{
				int_2++;
				return this.$STATIC$GetRandom$202888$r.Next((int_1 > int_2) ? int_2 : int_1, (int_1 > int_2) ? int_1 : int_2);
			}
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00013B98 File Offset: 0x00011D98
		public void method_15()
		{
			try
			{
				if (File.Exists(Globals.SOCKS_PATH))
				{
					File.Delete(Globals.SOCKS_PATH);
				}
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				try
				{
					foreach (Class35.Class36 @class in this.dictionary_0.Values)
					{
						stringBuilder.Append(@class.method_1(true).Replace("\n", " ") + "\r\n");
					}
				}
				finally
				{
					Dictionary<string, Class35.Class36>.ValueCollection.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				if (!string.IsNullOrEmpty(stringBuilder.ToString()))
				{
					File.AppendAllText(Globals.SOCKS_PATH, stringBuilder.ToString());
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00013C68 File Offset: 0x00011E68
		public void method_16()
		{
			if (File.Exists(Globals.SOCKS_PATH))
			{
				foreach (string string_ in File.ReadAllLines(Globals.SOCKS_PATH))
				{
					this.method_3(string_);
				}
			}
		}

		// Token: 0x0400019D RID: 413
		public static string string_0;

		// Token: 0x0400019E RID: 414
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool bool_0;

		// Token: 0x0400019F RID: 415
		private List<Class35.Class36> list_0;

		// Token: 0x040001A0 RID: 416
		private Dictionary<string, Class35.Class36> dictionary_0;

		// Token: 0x040001A1 RID: 417
		private int int_0;

		// Token: 0x040001A2 RID: 418
		private Random $STATIC$GetRandom$202888$r;

		// Token: 0x040001A3 RID: 419
		private StaticLocalInitFlag $STATIC$GetRandom$202888$r$Init;

		// Token: 0x02000048 RID: 72
		// (Invoke) Token: 0x06000252 RID: 594
		public delegate int Delegate10();

		// Token: 0x02000049 RID: 73
		public sealed class Class36 : DataGridViewRow
		{
			// Token: 0x06000253 RID: 595 RVA: 0x00013CA8 File Offset: 0x00011EA8
			public Class36(string string_4, int int_2, int int_3, string string_5, string string_6, bool bool_1 = false)
			{
				this.String_0 = string_4;
				this.Port = int_2;
				this.Version = int_3;
				this.Username = string_5;
				this.Password = string_6;
				this.Checked = bool_1;
				base.CreateCells(Globals.GMain.dtgSocks);
				DataGP g_DataGP = Globals.G_DataGP;
				string sIP = this.String_0;
				string country = this.Country;
				DataGridViewCell dataGridViewCell;
				Image value = (Image)(dataGridViewCell = base.Cells[1]).Value;
				string text = null;
				g_DataGP.Lookup(sIP, ref country, ref value, ref text, true);
				dataGridViewCell.Value = value;
				this.Country = country;
				base.Cells[0].Value = this.Checked;
				base.Cells[1].ToolTipText = this.Country;
				base.Cells[2].Value = this.String_0 + ":" + int_2.ToString();
				base.Cells[3].Value = this.method_0();
				base.Cells[4].Value = this.Username;
				base.Cells[5].Value = this.Password;
				base.Cells[6].Value = this.Country;
				base.Tag = this;
			}

			// Token: 0x170000A9 RID: 169
			// (get) Token: 0x06000254 RID: 596 RVA: 0x00002E13 File Offset: 0x00001013
			public string String_0 { get; }

			// Token: 0x170000AA RID: 170
			// (get) Token: 0x06000255 RID: 597 RVA: 0x00002E1B File Offset: 0x0000101B
			public int Port { get; }

			// Token: 0x170000AB RID: 171
			// (get) Token: 0x06000256 RID: 598 RVA: 0x00002E23 File Offset: 0x00001023
			public int Version { get; }

			// Token: 0x170000AC RID: 172
			// (get) Token: 0x06000257 RID: 599 RVA: 0x00002E2B File Offset: 0x0000102B
			public string Username { get; }

			// Token: 0x170000AD RID: 173
			// (get) Token: 0x06000258 RID: 600 RVA: 0x00002E33 File Offset: 0x00001033
			public string Password { get; }

			// Token: 0x170000AE RID: 174
			// (get) Token: 0x06000259 RID: 601 RVA: 0x00002E3B File Offset: 0x0000103B
			public string Country { get; }

			// Token: 0x170000AF RID: 175
			// (get) Token: 0x0600025A RID: 602 RVA: 0x00002E43 File Offset: 0x00001043
			// (set) Token: 0x0600025B RID: 603 RVA: 0x00002E4B File Offset: 0x0000104B
			public bool Checked { get; set; }

			// Token: 0x0600025C RID: 604 RVA: 0x00013E00 File Offset: 0x00012000
			public string method_0()
			{
				int version = this.Version;
				string result;
				if (version != 0)
				{
					if (version != 4)
					{
						if (version == 5)
						{
							result = "SOCKS 5";
						}
					}
					else
					{
						result = "SOCKS 4";
					}
				}
				else
				{
					result = "WEB PROXY";
				}
				return result;
			}

			// Token: 0x0600025D RID: 605 RVA: 0x00013E38 File Offset: 0x00012038
			public string method_1(bool bool_1 = true)
			{
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				stringBuilder.Append(this.String_0);
				stringBuilder.Append("|" + this.Port.ToString());
				stringBuilder.Append("|" + Conversions.ToString(this.Version));
				stringBuilder.Append("|" + this.Username);
				stringBuilder.Append("|" + this.Password);
				if (bool_1)
				{
					stringBuilder.Append("|" + base.Cells[0].Value.ToString());
				}
				return stringBuilder.ToString();
			}

			// Token: 0x040001A4 RID: 420
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			private string string_0;

			// Token: 0x040001A5 RID: 421
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			private int int_0;

			// Token: 0x040001A6 RID: 422
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private int int_1;

			// Token: 0x040001A7 RID: 423
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private string string_1;

			// Token: 0x040001A8 RID: 424
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private string string_2;

			// Token: 0x040001A9 RID: 425
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			private string string_3;

			// Token: 0x040001AA RID: 426
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			private bool bool_0;
		}
	}
}
