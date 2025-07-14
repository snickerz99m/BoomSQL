using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

// Token: 0x0200005C RID: 92
public class ToolStripControl : ToolStripControlHost
{
	// Token: 0x060002B6 RID: 694 RVA: 0x000030EA File Offset: 0x000012EA
	public ToolStripControl(NumericUpDown n) : base(n)
	{
		this.numericUpDown_0 = n;
	}

	// Token: 0x170000BA RID: 186
	// (get) Token: 0x060002B7 RID: 695 RVA: 0x000154D8 File Offset: 0x000136D8
	// (set) Token: 0x060002B8 RID: 696 RVA: 0x000030FA File Offset: 0x000012FA
	public decimal Value
	{
		get
		{
			return this.numericUpDown_0.Value;
		}
		set
		{
			this.numericUpDown_0.Value = value;
		}
	}

	// Token: 0x170000BB RID: 187
	// (get) Token: 0x060002B9 RID: 697 RVA: 0x000154F4 File Offset: 0x000136F4
	public new NumericUpDown Control
	{
		get
		{
			return this.numericUpDown_0;
		}
	}

	// Token: 0x060002BA RID: 698 RVA: 0x00003108 File Offset: 0x00001308
	private void method_0(object sender, EventArgs e)
	{
		base.Visible = ((NumericUpDown)sender).Visible;
	}

	// Token: 0x060002BB RID: 699 RVA: 0x0000311B File Offset: 0x0000131B
	protected override void OnSubscribeControlEvents(Control control)
	{
		base.OnSubscribeControlEvents(control);
		((NumericUpDown)control).ValueChanged += this.OnValueChanged;
	}

	// Token: 0x060002BC RID: 700 RVA: 0x0000313B File Offset: 0x0000133B
	protected override void OnUnsubscribeControlEvents(Control control)
	{
		base.OnUnsubscribeControlEvents(control);
		((NumericUpDown)control).ValueChanged += this.OnValueChanged;
		((NumericUpDown)control).VisibleChanged += this.method_0;
	}

	// Token: 0x14000002 RID: 2
	// (add) Token: 0x060002BD RID: 701 RVA: 0x0001550C File Offset: 0x0001370C
	// (remove) Token: 0x060002BE RID: 702 RVA: 0x00015544 File Offset: 0x00013744
	public event EventHandler ValueChanged
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

	// Token: 0x170000BC RID: 188
	// (get) Token: 0x060002BF RID: 703 RVA: 0x0001557C File Offset: 0x0001377C
	public Control NumericUpDownControl
	{
		get
		{
			return this.Control;
		}
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x00015594 File Offset: 0x00013794
	public void OnValueChanged(object sender, EventArgs e)
	{
		EventHandler eventHandler = this.eventHandler_0;
		if (eventHandler != null)
		{
			eventHandler(this, e);
		}
	}

	// Token: 0x040001D4 RID: 468
	private NumericUpDown numericUpDown_0;

	// Token: 0x040001D5 RID: 469
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EventHandler eventHandler_0;
}
