using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ScrollingBoxCtrl
{
	// Token: 0x02000050 RID: 80
	public class ScrollingBoxCollection : CollectionBase
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600028D RID: 653 RVA: 0x00014F74 File Offset: 0x00013174
		// (remove) Token: 0x0600028E RID: 654 RVA: 0x00014FAC File Offset: 0x000131AC
		public event EventHandler OnCollectionChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00014FE4 File Offset: 0x000131E4
		public int Add(ScrollingBoxItem value)
		{
			int result = base.InnerList.Add(value);
			EventHandler eventHandler = this.eventHandler_0;
			if (eventHandler != null)
			{
				eventHandler(this, new EventArgs());
			}
			return result;
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00015018 File Offset: 0x00013218
		public int Add(string Text)
		{
			return this.Add(new ScrollingBoxText(Text));
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00015034 File Offset: 0x00013234
		public void InsertAt(int index, ScrollingBoxItem value)
		{
			base.InnerList.Insert(index, value);
			EventHandler eventHandler = this.eventHandler_0;
			if (eventHandler != null)
			{
				eventHandler(this, new EventArgs());
			}
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00015064 File Offset: 0x00013264
		public void Remove(ScrollingBoxItem value)
		{
			base.InnerList.Remove(value);
			EventHandler eventHandler = this.eventHandler_0;
			if (eventHandler != null)
			{
				eventHandler(this, new EventArgs());
			}
		}

		// Token: 0x170000B4 RID: 180
		public ScrollingBoxItem this[int index]
		{
			get
			{
				return (ScrollingBoxItem)base.InnerList[index];
			}
			set
			{
				base.InnerList[index] = value;
			}
		}

		// Token: 0x040001BF RID: 447
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler eventHandler_0;
	}
}
