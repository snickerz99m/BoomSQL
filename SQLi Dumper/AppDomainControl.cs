using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x0200000C RID: 12
public class AppDomainControl
{
	// Token: 0x06000098 RID: 152 RVA: 0x000025C5 File Offset: 0x000007C5
	public AppDomainControl()
	{
		this.FreeSlot = new List<HTTPExt>();
		this.InUseSlot = new List<HTTPExt>();
	}

	// Token: 0x17000071 RID: 113
	// (get) Token: 0x06000099 RID: 153 RVA: 0x000025E3 File Offset: 0x000007E3
	// (set) Token: 0x0600009A RID: 154 RVA: 0x000025EB File Offset: 0x000007EB
	public int ProcessCreated { get; set; }

	// Token: 0x0600009B RID: 155 RVA: 0x0000A7CC File Offset: 0x000089CC
	public HTTPExt GetHTTP()
	{
		object freeSlot = this.FreeSlot;
		checked
		{
			HTTPExt httpext;
			lock (freeSlot)
			{
				if (this.FreeSlot.Count == 0)
				{
					this.ProcessCreated++;
					httpext = new HTTPExt(true, false);
					this.InUseSlot.Add(httpext);
				}
				else
				{
					httpext = this.FreeSlot[0];
					this.FreeSlot.Remove(httpext);
					this.InUseSlot.Add(httpext);
				}
			}
			return httpext;
		}
	}

	// Token: 0x0600009C RID: 156 RVA: 0x0000A864 File Offset: 0x00008A64
	public void Abort()
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
			object inUseSlot = this.InUseSlot;
			lock (inUseSlot)
			{
				try
				{
					foreach (HTTPExt httpext in this.InUseSlot)
					{
						if (httpext != null)
						{
							httpext.Abort();
						}
					}
				}
				finally
				{
					List<HTTPExt>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_68:
			goto IL_CF;
			IL_6A:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_86:
			goto IL_C4;
			IL_88:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_A1:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_88;
		}
		IL_C4:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_CF:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x0600009D RID: 157 RVA: 0x0000A974 File Offset: 0x00008B74
	public void Terminate()
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
			object freeSlot = this.FreeSlot;
			lock (freeSlot)
			{
				try
				{
					foreach (HTTPExt httpext in this.FreeSlot)
					{
						if (httpext != null)
						{
							httpext.Dispose();
						}
					}
				}
				finally
				{
					List<HTTPExt>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_6B:
			num2 = 3;
			object inUseSlot = this.InUseSlot;
			lock (inUseSlot)
			{
				try
				{
					foreach (HTTPExt httpext2 in this.InUseSlot)
					{
						if (httpext2 != null)
						{
							httpext2.Dispose();
						}
					}
				}
				finally
				{
					List<HTTPExt>.Enumerator enumerator2;
					((IDisposable)enumerator2).Dispose();
				}
			}
			IL_D1:
			goto IL_13C;
			IL_D3:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_F3:
			goto IL_131;
			IL_F5:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_10E:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_F5;
		}
		IL_131:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_13C:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x0600009E RID: 158 RVA: 0x0000AB44 File Offset: 0x00008D44
	public void Dispose(HTTPExt h)
	{
		if (h != null)
		{
			this.InUseSlot.Remove(h);
			if (h.TotalRequest > 100 || h.TotalRequestFailed > 100)
			{
				h.Dispose();
				h = null;
			}
			else
			{
				object freeSlot = this.FreeSlot;
				lock (freeSlot)
				{
					this.FreeSlot.Add(h);
				}
			}
		}
	}

	// Token: 0x0600009F RID: 159 RVA: 0x0000ABC4 File Offset: 0x00008DC4
	public int GetTotalRunning()
	{
		return this.InUseSlot.Count;
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x0000ABE0 File Offset: 0x00008DE0
	public int GetProcessCreated()
	{
		return this.ProcessCreated;
	}

	// Token: 0x0400001C RID: 28
	public static int MAX_CALLER;

	// Token: 0x0400001D RID: 29
	private List<HTTPExt> FreeSlot;

	// Token: 0x0400001E RID: 30
	private List<HTTPExt> InUseSlot;
}
