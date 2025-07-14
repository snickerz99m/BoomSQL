using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x020000F0 RID: 240
internal sealed class ThreadPool
{
	// Token: 0x06001078 RID: 4216 RVA: 0x00008E1F File Offset: 0x0000701F
	public ThreadPool(int maxThreadCount)
	{
		this.__CountLock = RuntimeHelpers.GetObjectValue(new object());
		this.__PushLock = RuntimeHelpers.GetObjectValue(new object());
		this.MaxThreadCount = maxThreadCount;
		this.__ActiveThreads = new List<Thread>(this.MaxThreadCount);
	}

	// Token: 0x1700051F RID: 1311
	// (get) Token: 0x06001079 RID: 4217 RVA: 0x00071298 File Offset: 0x0006F498
	public int ThreadCount
	{
		get
		{
			int num;
			int count;
			int num4;
			object obj;
			try
			{
				int num2;
				List<Thread>.Enumerator enumerator;
				for (;;)
				{
					IL_3E:
					ProjectData.ClearProjectError();
					num = -2;
					IL_04:
					num2 = 2;
					enumerator = this.__ActiveThreads.GetEnumerator();
					while (enumerator.MoveNext())
					{
						Thread thread = enumerator.Current;
						IL_23:
						num2 = 3;
						if (thread.ThreadState == ThreadState.Stopped)
						{
							IL_35:
							num2 = 4;
							this.Close(thread);
							goto IL_3E;
						}
						IL_31:
						num2 = 7;
					}
					break;
				}
				IL_48:
				num2 = 8;
				((IDisposable)enumerator).Dispose();
				IL_57:
				num2 = 9;
				count = this.__ActiveThreads.Count;
				IL_67:
				goto IL_ED;
				IL_6C:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_A4:
				goto IL_E2;
				IL_A6:
				num4 = num2;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
				IL_BF:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_A6;
			}
			IL_E2:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_ED:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return count;
		}
	}

	// Token: 0x17000520 RID: 1312
	// (get) Token: 0x0600107A RID: 4218 RVA: 0x000713B0 File Offset: 0x0006F5B0
	// (set) Token: 0x0600107B RID: 4219 RVA: 0x00008E5F File Offset: 0x0000705F
	public int MaxThreadCount
	{
		get
		{
			return this.__MaxThreadCount;
		}
		set
		{
			this.__MaxThreadCount = value;
		}
	}

	// Token: 0x17000521 RID: 1313
	// (get) Token: 0x0600107C RID: 4220 RVA: 0x00008E68 File Offset: 0x00007068
	public bool Finished
	{
		get
		{
			return this.AllPushed && this.ThreadCount <= 0;
		}
	}

	// Token: 0x17000522 RID: 1314
	// (get) Token: 0x0600107D RID: 4221 RVA: 0x000713C8 File Offset: 0x0006F5C8
	// (set) Token: 0x0600107E RID: 4222 RVA: 0x00008E81 File Offset: 0x00007081
	public global::ThreadPool.ThreadStatus Status
	{
		get
		{
			return this.__Status;
		}
		set
		{
			this.__Status = value;
		}
	}

	// Token: 0x17000523 RID: 1315
	// (get) Token: 0x0600107F RID: 4223 RVA: 0x000713E0 File Offset: 0x0006F5E0
	private bool AllPushed
	{
		get
		{
			object _PushLock = this.__PushLock;
			ObjectFlowControl.CheckForSyncLockOnValueType(_PushLock);
			bool result;
			lock (_PushLock)
			{
				result = (this.__AllPushed | this.Status == global::ThreadPool.ThreadStatus.Stopped);
			}
			return result;
		}
	}

	// Token: 0x17000524 RID: 1316
	// (get) Token: 0x06001080 RID: 4224 RVA: 0x00071434 File Offset: 0x0006F634
	// (set) Token: 0x06001081 RID: 4225 RVA: 0x00008E8A File Offset: 0x0000708A
	public bool Paused
	{
		get
		{
			return !this.Finished && this.__Status == global::ThreadPool.ThreadStatus.Paused;
		}
		set
		{
			if (!this.Finished)
			{
				if (value)
				{
					this.__Status = global::ThreadPool.ThreadStatus.Paused;
				}
				else
				{
					this.__Status = global::ThreadPool.ThreadStatus.Started;
				}
			}
		}
	}

	// Token: 0x06001082 RID: 4226 RVA: 0x00008EAA File Offset: 0x000070AA
	public void Open(Thread thread = null)
	{
		if (thread != null)
		{
			this.__ActiveThreads.Add(thread);
		}
	}

	// Token: 0x06001083 RID: 4227 RVA: 0x0007145C File Offset: 0x0006F65C
	public void AllJobsPushed()
	{
		object _PushLock = this.__PushLock;
		ObjectFlowControl.CheckForSyncLockOnValueType(_PushLock);
		lock (_PushLock)
		{
			this.__AllPushed = true;
		}
	}

	// Token: 0x06001084 RID: 4228 RVA: 0x000714A4 File Offset: 0x0006F6A4
	public void Close(Thread thread = null)
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
			if (!this.__ActiveThreads.Contains(thread))
			{
				goto IL_29;
			}
			IL_1A:
			num2 = 3;
			this.__ActiveThreads.Remove(thread);
			IL_29:
			num2 = 5;
			thread = null;
			IL_30:
			goto IL_9F;
			IL_32:
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

	// Token: 0x06001085 RID: 4229 RVA: 0x00008EBE File Offset: 0x000070BE
	public void WaitForThreads()
	{
		while ((this.ThreadCount >= this.MaxThreadCount || this.Status == global::ThreadPool.ThreadStatus.Paused) && this.Status != global::ThreadPool.ThreadStatus.Stopped)
		{
			Thread.Sleep(200);
		}
	}

	// Token: 0x06001086 RID: 4230 RVA: 0x00071568 File Offset: 0x0006F768
	public void AbortThreads()
	{
		object _PushLock = this.__PushLock;
		ObjectFlowControl.CheckForSyncLockOnValueType(_PushLock);
		lock (_PushLock)
		{
			this.__AllPushed = true;
			this.Status = global::ThreadPool.ThreadStatus.Stopped;
			this.__ActiveThreads.Clear();
		}
	}

	// Token: 0x04000825 RID: 2085
	private object __CountLock;

	// Token: 0x04000826 RID: 2086
	private object __PushLock;

	// Token: 0x04000827 RID: 2087
	private bool __AllPushed;

	// Token: 0x04000828 RID: 2088
	private int __MaxThreadCount;

	// Token: 0x04000829 RID: 2089
	private global::ThreadPool.ThreadStatus __Status;

	// Token: 0x0400082A RID: 2090
	private List<Thread> __ActiveThreads;

	// Token: 0x020000F1 RID: 241
	public enum ThreadStatus
	{
		// Token: 0x0400082C RID: 2092
		Started,
		// Token: 0x0400082D RID: 2093
		Stopped,
		// Token: 0x0400082E RID: 2094
		Paused
	}
}
