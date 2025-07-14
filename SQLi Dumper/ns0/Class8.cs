using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ns0
{
	// Token: 0x0200000D RID: 13
	internal sealed class Class8 : IDisposable
	{
		// Token: 0x060000A1 RID: 161 RVA: 0x000025F4 File Offset: 0x000007F4
		public Class8(Form form_1)
		{
			this.int_0 = 0;
			this.form_0 = form_1;
			form_1.BeginInvoke(new MethodInvoker(this.method_0));
		}

		// Token: 0x060000A2 RID: 162
		[DllImport("user32.dll")]
		private static extern bool EnumThreadWindows(int int_1, Class8.Delegate0 delegate0_0, IntPtr intptr_0);

		// Token: 0x060000A3 RID: 163
		[DllImport("kernel32.dll")]
		private static extern int GetCurrentThreadId();

		// Token: 0x060000A4 RID: 164
		[DllImport("user32.dll")]
		private static extern int GetClassName(IntPtr intptr_0, StringBuilder stringBuilder_0, int int_1);

		// Token: 0x060000A5 RID: 165
		[DllImport("user32.dll")]
		private static extern bool GetWindowRect(IntPtr intptr_0, ref Class8.Struct0 struct0_0);

		// Token: 0x060000A6 RID: 166
		[DllImport("user32.dll")]
		private static extern bool MoveWindow(IntPtr intptr_0, int int_1, int int_2, int int_3, int int_4, bool bool_0);

		// Token: 0x060000A7 RID: 167 RVA: 0x0000ABF8 File Offset: 0x00008DF8
		private void method_0()
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
				if (this.int_0 < 0)
				{
					goto IL_67;
				}
				IL_17:
				num2 = 5;
				Class8.Delegate0 delegate0_ = new Class8.Delegate0(this.method_1);
				IL_26:
				num2 = 6;
				if (!Class8.EnumThreadWindows(Class8.GetCurrentThreadId(), delegate0_, IntPtr.Zero))
				{
					goto IL_67;
				}
				IL_3A:
				num2 = 7;
				if (Interlocked.Increment(ref this.int_0) >= 10)
				{
					goto IL_67;
				}
				IL_4D:
				num2 = 8;
				this.form_0.BeginInvoke(new MethodInvoker(this.method_0));
				IL_67:
				goto IL_ED;
				IL_6C:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_A6:
				goto IL_E2;
				IL_A8:
				num4 = num2;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
				IL_C0:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_A8;
			}
			IL_E2:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_ED:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000AD0C File Offset: 0x00008F0C
		private bool method_1(IntPtr intptr_0, IntPtr intptr_1)
		{
			int num;
			bool result;
			int num4;
			object obj;
			try
			{
				IL_02:
				ProjectData.ClearProjectError();
				num = -2;
				IL_0A:
				int num2 = 2;
				StringBuilder stringBuilder = new StringBuilder(260);
				IL_17:
				num2 = 3;
				Class8.GetClassName(intptr_0, stringBuilder, stringBuilder.Capacity);
				IL_27:
				num2 = 4;
				if (Operators.CompareString(stringBuilder.ToString(), "#32770", false) == 0)
				{
					goto IL_48;
				}
				IL_3F:
				num2 = 5;
				result = true;
				goto IL_E2;
				IL_48:
				num2 = 7;
				Rectangle rectangle = new Rectangle(this.form_0.Location, this.form_0.Size);
				IL_67:
				num2 = 8;
				Class8.Struct0 @struct;
				Class8.GetWindowRect(intptr_0, ref @struct);
				IL_72:
				num2 = 9;
				checked
				{
					Class8.MoveWindow(intptr_0, rectangle.Left + (rectangle.Width - @struct.int_2 + @struct.int_0) / 2, rectangle.Top + (rectangle.Height - @struct.int_3 + @struct.int_1) / 2, @struct.int_2 - @struct.int_0, @struct.int_3 - @struct.int_1, true);
					IL_DD:
					num2 = 10;
					result = false;
					IL_E2:
					goto IL_16C;
					IL_E7:;
				}
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_123:
				goto IL_161;
				IL_125:
				num4 = num2;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
				IL_13E:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_125;
			}
			IL_161:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_16C:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000261D File Offset: 0x0000081D
		public void Dispose()
		{
			this.int_0 = -1;
		}

		// Token: 0x04000020 RID: 32
		private int int_0;

		// Token: 0x04000021 RID: 33
		private Form form_0;

		// Token: 0x0200000E RID: 14
		// (Invoke) Token: 0x060000AD RID: 173
		private delegate bool Delegate0(IntPtr hWnd, IntPtr lp);

		// Token: 0x0200000F RID: 15
		private struct Struct0
		{
			// Token: 0x04000022 RID: 34
			public int int_0;

			// Token: 0x04000023 RID: 35
			public int int_1;

			// Token: 0x04000024 RID: 36
			public int int_2;

			// Token: 0x04000025 RID: 37
			public int int_3;
		}
	}
}
