using System;
using System.Drawing;

namespace ScrollingBoxCtrl
{
	// Token: 0x02000053 RID: 83
	public class ScrollingBoxImage : ScrollingBoxItem
	{
		// Token: 0x06000299 RID: 665 RVA: 0x00003029 File Offset: 0x00001229
		public ScrollingBoxImage(Image Image)
		{
			this.image_0 = Image;
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600029A RID: 666 RVA: 0x000150CC File Offset: 0x000132CC
		// (set) Token: 0x0600029B RID: 667 RVA: 0x00003038 File Offset: 0x00001238
		public Image Image
		{
			get
			{
				return this.image_0;
			}
			set
			{
				this.image_0 = value;
			}
		}

		// Token: 0x040001C2 RID: 450
		private Image image_0;
	}
}
