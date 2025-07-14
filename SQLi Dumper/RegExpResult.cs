using System;

// Token: 0x020000B3 RID: 179
public class RegExpResult
{
	// Token: 0x17000320 RID: 800
	// (get) Token: 0x06000A4B RID: 2635 RVA: 0x0003FA10 File Offset: 0x0003DC10
	// (set) Token: 0x06000A4C RID: 2636 RVA: 0x0000646E File Offset: 0x0000466E
	public int Index
	{
		get
		{
			return this.int_0;
		}
		set
		{
			this.int_0 = value;
		}
	}

	// Token: 0x17000321 RID: 801
	// (get) Token: 0x06000A4D RID: 2637 RVA: 0x0003FA28 File Offset: 0x0003DC28
	// (set) Token: 0x06000A4E RID: 2638 RVA: 0x00006477 File Offset: 0x00004677
	public string Value
	{
		get
		{
			return this.string_0;
		}
		set
		{
			this.string_0 = value;
		}
	}

	// Token: 0x04000510 RID: 1296
	private int int_0;

	// Token: 0x04000511 RID: 1297
	private string string_0;
}
