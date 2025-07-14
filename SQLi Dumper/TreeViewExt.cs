using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// Token: 0x0200005E RID: 94
public class TreeViewExt : TreeView
{
	// Token: 0x060002CC RID: 716 RVA: 0x00003216 File Offset: 0x00001416
	public TreeViewExt()
	{
		base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		if (!TreeViewExt.Class41.Boolean_1)
		{
			base.SetStyle(ControlStyles.UserPaint, true);
		}
	}

	// Token: 0x060002CD RID: 717 RVA: 0x00015780 File Offset: 0x00013980
	private void method_0()
	{
		int num = 0;
		if (this.DoubleBuffered)
		{
			num |= 4;
		}
		if (num != 0)
		{
			TreeViewExt.Class41.SendMessage(base.Handle, 4396, (IntPtr)4, (IntPtr)num);
		}
	}

	// Token: 0x060002CE RID: 718 RVA: 0x0000323C File Offset: 0x0000143C
	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		this.method_0();
		if (!TreeViewExt.Class41.Boolean_0)
		{
			TreeViewExt.Class41.SendMessage(base.Handle, 4381, IntPtr.Zero, (IntPtr)ColorTranslator.ToWin32(this.BackColor));
		}
	}

	// Token: 0x060002CF RID: 719 RVA: 0x000127CC File Offset: 0x000109CC
	protected override void OnPaint(PaintEventArgs e)
	{
		if (base.GetStyle(ControlStyles.UserPaint))
		{
			Message message = default(Message);
			message.HWnd = base.Handle;
			message.Msg = 792;
			message.WParam = e.Graphics.GetHdc();
			message.LParam = (IntPtr)4;
			this.DefWndProc(ref message);
			e.Graphics.ReleaseHdc(message.WParam);
		}
		base.OnPaint(e);
	}

	// Token: 0x040001D8 RID: 472
	private static int int_0;

	// Token: 0x040001D9 RID: 473
	private static int int_1;

	// Token: 0x040001DA RID: 474
	private static int int_2;

	// Token: 0x040001DB RID: 475
	private static int int_3;

	// Token: 0x0200005F RID: 95
	internal sealed class Class41
	{
		// Token: 0x060002D1 RID: 721
		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr intptr_0, int int_2, IntPtr intptr_1, IntPtr intptr_2);

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x000157C0 File Offset: 0x000139C0
		public static bool Boolean_0
		{
			get
			{
				OperatingSystem osversion = Environment.OSVersion;
				return osversion.Platform == PlatformID.Win32NT && (osversion.Version.Major > 5 || (osversion.Version.Major == 5 && osversion.Version.Minor == 1));
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060002D3 RID: 723 RVA: 0x00015810 File Offset: 0x00013A10
		public static bool Boolean_1
		{
			get
			{
				OperatingSystem osversion = Environment.OSVersion;
				return osversion.Platform == PlatformID.Win32NT && osversion.Version.Major >= 6;
			}
		}

		// Token: 0x040001DC RID: 476
		public static int int_0;

		// Token: 0x040001DD RID: 477
		public static int int_1;
	}
}
