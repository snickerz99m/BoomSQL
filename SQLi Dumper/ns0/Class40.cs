using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ns0
{
	// Token: 0x0200005D RID: 93
	internal sealed class Class40
	{
		// Token: 0x060002C1 RID: 705 RVA: 0x00003172 File Offset: 0x00001372
		public Class40()
		{
			this.list_0 = new List<string>();
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x000155B4 File Offset: 0x000137B4
		public void method_0(string string_0)
		{
			string item = Class23.smethod_14(string_0);
			if (!this.list_0.Contains(item))
			{
				this.list_0.Add(item);
			}
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x00003185 File Offset: 0x00001385
		public void method_1(string string_0)
		{
			if (this.list_0.Contains(string_0))
			{
				this.list_0.Remove(string_0);
			}
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x000031A2 File Offset: 0x000013A2
		public bool method_2(string string_0)
		{
			return this.list_0.Contains(string_0);
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x000155E8 File Offset: 0x000137E8
		public int method_3()
		{
			return this.list_0.Count;
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x000031B0 File Offset: 0x000013B0
		public void method_4()
		{
			this.list_0.Clear();
			Globals.GMain.dtgTrash.Rows.Clear();
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00015604 File Offset: 0x00013804
		public void method_5()
		{
			if (File.Exists(Globals.TRASH_PATH))
			{
				string[] collection = File.ReadAllLines(Globals.TRASH_PATH);
				this.list_0.AddRange(collection);
			}
			this.method_7();
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x000031D1 File Offset: 0x000013D1
		public void method_6()
		{
			if (File.Exists(Globals.TRASH_PATH))
			{
				File.Delete(Globals.TRASH_PATH);
			}
			if (this.list_0.Count > 0)
			{
				File.WriteAllLines(Globals.TRASH_PATH, this.list_0.ToArray());
			}
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0001563C File Offset: 0x0001383C
		public void method_7()
		{
			checked
			{
				if (Globals.GMain.dtgTrash.InvokeRequired)
				{
					Globals.GMain.dtgTrash.Invoke(new EventHandler(this.method_9));
				}
				else if (this.list_0.Count > 0)
				{
					int num = 2000;
					if (num > this.list_0.Count)
					{
						num = this.list_0.Count;
					}
					List<string> list = new List<string>();
					int num2 = num - 1;
					for (int i = 0; i <= num2; i++)
					{
						list.Add(this.list_0[this.list_0.Count - 1 - i]);
					}
					Globals.LockWindowUpdate(Globals.GMain.dtgTrash.Handle);
					Globals.GMain.dtgTrash.Rows.Clear();
					Globals.GMain.dtgTrash.Rows.AddRange(Array.ConvertAll<string, DataGridViewRow>(list.ToArray(), new Converter<string, DataGridViewRow>(this.method_8)));
					Globals.LockWindowUpdate(IntPtr.Zero);
				}
			}
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00015748 File Offset: 0x00013948
		private DataGridViewRow method_8(string string_0)
		{
			DataGridViewRow dataGridViewRow = new DataGridViewRow();
			dataGridViewRow.CreateCells(Globals.GMain.dtgTrash);
			dataGridViewRow.SetValues(new object[]
			{
				string_0
			});
			return dataGridViewRow;
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000320E File Offset: 0x0000140E
		[CompilerGenerated]
		[DebuggerHidden]
		private void method_9(object sender, EventArgs e)
		{
			this.method_7();
		}

		// Token: 0x040001D6 RID: 470
		private List<string> list_0;

		// Token: 0x040001D7 RID: 471
		private static int int_0;
	}
}
