using System;

namespace ScrollingBoxCtrl
{
	// Token: 0x02000052 RID: 82
	public class ScrollingBoxText : ScrollingBoxItem
	{
		// Token: 0x06000296 RID: 662 RVA: 0x00003011 File Offset: 0x00001211
		public ScrollingBoxText(string Text)
		{
			this.string_0 = Text;
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000297 RID: 663 RVA: 0x000150B4 File Offset: 0x000132B4
		// (set) Token: 0x06000298 RID: 664 RVA: 0x00003020 File Offset: 0x00001220
		public string Text
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

		// Token: 0x040001C1 RID: 449
		private string string_0;
	}
}
