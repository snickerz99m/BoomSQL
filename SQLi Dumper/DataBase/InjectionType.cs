using System;

namespace DataBase
{
	// Token: 0x020000FB RID: 251
	public enum InjectionType
	{
		// Token: 0x0400088C RID: 2188
		None,
		// Token: 0x0400088D RID: 2189
		Union,
		// Token: 0x0400088E RID: 2190
		Error,
		// Extended injection types for enhanced detection
		// Token: 0x0400088F RID: 2191
		Boolean,
		// Token: 0x04000890 RID: 2192
		Time,
		// Token: 0x04000891 RID: 2193
		Stacked,
		// Token: 0x04000892 RID: 2194
		OutOfBand,
		// Token: 0x04000893 RID: 2195
		Blind,
		// Token: 0x04000894 RID: 2196
		SecondOrder
	}
}
