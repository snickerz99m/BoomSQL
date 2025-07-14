using System;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

namespace Taskbar
{
	// Token: 0x02000059 RID: 89
	public class Manager
	{
		// Token: 0x060002A8 RID: 680 RVA: 0x00003052 File Offset: 0x00001252
		public Manager()
		{
			this.bool_0 = Manager.Boolean_0;
			this.intptr_0 = this.IntPtr_0;
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00003071 File Offset: 0x00001271
		public Manager(IntPtr p)
		{
			this.intptr_0 = p;
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00015158 File Offset: 0x00013358
		public void SetProgressValue(int currentValue, int maximumValue)
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
				if (currentValue >= 0)
				{
					goto IL_19;
				}
				IL_12:
				num2 = 3;
				currentValue = 0;
				IL_19:
				num2 = 4;
				if (currentValue <= maximumValue)
				{
					goto IL_28;
				}
				IL_21:
				num2 = 5;
				currentValue = maximumValue;
				IL_28:
				num2 = 6;
				if (this.intptr_0 == IntPtr.Zero)
				{
					goto IL_5F;
				}
				IL_3F:
				num2 = 7;
				Class39.Interface0_0.imethod_6(this.intptr_0, (ulong)Convert.ToUInt32(currentValue), (ulong)Convert.ToUInt32(maximumValue));
				IL_5F:
				goto IL_DA;
				IL_61:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_93:
				goto IL_CF;
				IL_95:
				num4 = num2;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
				IL_AD:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_95;
			}
			IL_CF:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_DA:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00015258 File Offset: 0x00013458
		public void SetProgressState(ProgressBarState state)
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
				if (this.intptr_0 == IntPtr.Zero)
				{
					goto IL_34;
				}
				IL_21:
				num2 = 3;
				Class39.Interface0_0.imethod_7(this.intptr_0, (Enum3)state);
				IL_34:
				goto IL_9F;
				IL_36:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_58:
				goto IL_94;
				IL_5A:
				num4 = num2;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
				IL_72:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_5A;
			}
			IL_94:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_9F:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060002AC RID: 684 RVA: 0x0001531C File Offset: 0x0001351C
		internal IntPtr IntPtr_0
		{
			get
			{
				IntPtr result;
				if (Manager.Boolean_0)
				{
					Process currentProcess = Process.GetCurrentProcess();
					if (currentProcess == null || currentProcess.MainWindowHandle == IntPtr.Zero)
					{
						result = IntPtr.Zero;
					}
					else
					{
						result = currentProcess.MainWindowHandle;
					}
				}
				else
				{
					result = IntPtr.Zero;
				}
				return result;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060002AD RID: 685 RVA: 0x00003080 File Offset: 0x00001280
		private static bool Boolean_0
		{
			get
			{
				return Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.CompareTo(new Version(6, 1)) >= 0;
			}
		}

		// Token: 0x040001D1 RID: 465
		private bool bool_0;

		// Token: 0x040001D2 RID: 466
		private IntPtr intptr_0;
	}
}
