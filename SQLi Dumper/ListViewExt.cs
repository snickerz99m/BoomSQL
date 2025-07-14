using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x0200003B RID: 59
public class ListViewExt : ListView
{
	// Token: 0x0600020E RID: 526 RVA: 0x000126EC File Offset: 0x000108EC
	public ListViewExt()
	{
		base.ColumnClick += this.ListViewExt_ColumnClick;
		this.class34_0 = new ListViewExt.Class34();
		this.int_13 = -1;
		base.ListViewItemSorter = this.class34_0;
		base.View = View.Details;
		base.DoubleBuffered = true;
		base.FullRowSelect = true;
		base.HideSelection = false;
		base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		base.Refresh();
	}

	// Token: 0x0600020F RID: 527 RVA: 0x00012760 File Offset: 0x00010960
	public ListViewGroup GetGroupByHeader(string name)
	{
		try
		{
			foreach (object obj in base.Groups)
			{
				ListViewGroup listViewGroup = (ListViewGroup)obj;
				if (listViewGroup.Header.Equals(name))
				{
					return listViewGroup;
				}
			}
		}
		finally
		{
			IEnumerator enumerator;
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		return null;
	}

	// Token: 0x06000210 RID: 528
	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern int SendMessage(IntPtr intptr_0, int int_16, int int_17, ListViewExt.LVGROUP lvgroup_0);

	// Token: 0x06000211 RID: 529
	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
	private static extern IntPtr SendMessage_1(IntPtr intptr_0, uint uint_0, IntPtr intptr_1, IntPtr intptr_2);

	// Token: 0x06000212 RID: 530
	[DllImport("user32.dll", EntryPoint = "SendMessage")]
	private static extern IntPtr SendMessage_2(IntPtr intptr_0, int int_16, IntPtr intptr_1, ref ListViewExt.Struct1 struct1_0);

	// Token: 0x06000213 RID: 531
	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
	private static extern IntPtr SendMessage_3(IntPtr intptr_0, int int_16, int int_17, ref ListViewExt.Struct2 struct2_0);

	// Token: 0x06000214 RID: 532
	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
	private static extern IntPtr SendMessage_4(IntPtr intptr_0, int int_16, int int_17, ref ListViewExt.Struct3 struct3_0);

	// Token: 0x06000215 RID: 533 RVA: 0x000127CC File Offset: 0x000109CC
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

	// Token: 0x06000216 RID: 534 RVA: 0x00012844 File Offset: 0x00010A44
	private void method_0(int int_16, int int_17)
	{
		IntPtr intptr_ = ListViewExt.SendMessage_1(base.Handle, 4127U, IntPtr.Zero, IntPtr.Zero);
		IntPtr intptr_2 = new IntPtr(int_17);
		IntPtr intptr_3 = new IntPtr(int_16);
		ListViewExt.Struct1 @struct = default(ListViewExt.Struct1);
		@struct.uint_0 = 4U;
		ListViewExt.SendMessage_2(intptr_, 4619, intptr_3, ref @struct);
		@struct.int_2 = (@struct.int_2 & -513 & -1025);
		ListViewExt.SendMessage_2(intptr_, 4620, intptr_3, ref @struct);
		@struct = default(ListViewExt.Struct1);
		@struct.uint_0 = 4U;
		ListViewExt.SendMessage_2(intptr_, 4619, intptr_2, ref @struct);
		if (this.class34_0.SortOrder_0 == SortOrder.Ascending)
		{
			@struct.int_2 |= 1024;
		}
		else
		{
			@struct.int_2 |= 512;
		}
		ListViewExt.SendMessage_2(intptr_, 4620, intptr_2, ref @struct);
		int_16 = int_17;
	}

	// Token: 0x06000217 RID: 535 RVA: 0x00012930 File Offset: 0x00010B30
	private void method_1(ListViewExt listViewExt_0, int int_16, int int_17, int int_18)
	{
		ListViewExt.Struct2 @struct = default(ListViewExt.Struct2);
		@struct.int_4 = int_17;
		@struct.int_3 = int_18;
		ListViewExt.SendMessage_3(listViewExt_0.Handle, 4139, int_16, ref @struct);
	}

	// Token: 0x06000218 RID: 536 RVA: 0x0001296C File Offset: 0x00010B6C
	private bool method_2()
	{
		ListViewExt.Struct3 @struct = default(ListViewExt.Struct3);
		Bitmap bitmap = this.image_0 as Bitmap;
		if (bitmap == null)
		{
			@struct.int_0 = 0;
		}
		else
		{
			@struct.intptr_0 = bitmap.GetHbitmap();
			@struct.int_0 = 268435456;
		}
		Application.OleRequired();
		IntPtr value = ListViewExt.SendMessage_4(base.Handle, 4234, 0, ref @struct);
		return value != IntPtr.Zero;
	}

	// Token: 0x06000219 RID: 537 RVA: 0x000129DC File Offset: 0x00010BDC
	private void ListViewExt_ColumnClick(object sender, ColumnClickEventArgs e)
	{
		if (e.Column == this.class34_0.Int32_0)
		{
			if (this.class34_0.SortOrder_0 == SortOrder.Ascending)
			{
				this.class34_0.SortOrder_0 = SortOrder.Descending;
			}
			else
			{
				this.class34_0.SortOrder_0 = SortOrder.Ascending;
			}
		}
		else
		{
			this.class34_0.Int32_0 = e.Column;
			this.class34_0.SortOrder_0 = SortOrder.Ascending;
		}
		base.Sort();
		this.method_0(this.int_13, e.Column);
		this.SetSelectedColumn(base.Columns[e.Column]);
		this.int_13 = e.Column;
	}

	// Token: 0x0600021A RID: 538 RVA: 0x00002CF4 File Offset: 0x00000EF4
	public void ShowCollapseGroupVisible()
	{
		if (base.ShowGroups)
		{
			ListViewExt.ListViewHelper.smethod_1(this, ListViewExt.ListViewGroupState.Collapsible);
		}
	}

	// Token: 0x0600021B RID: 539 RVA: 0x00012A84 File Offset: 0x00010C84
	public ListViewItem GetSelectedItem()
	{
		ListViewItem result;
		if (base.SelectedItems.Count > 0)
		{
			result = base.SelectedItems[0];
		}
		else
		{
			result = null;
		}
		return result;
	}

	// Token: 0x0600021C RID: 540 RVA: 0x00012AB4 File Offset: 0x00010CB4
	public bool ContainsItemCD(string sText)
	{
		bool result;
		if (base.InvokeRequired)
		{
			result = Conversions.ToBoolean(base.Invoke(new ListViewExt.Delegate8(this.GetItem), new object[]
			{
				sText
			}));
		}
		else
		{
			try
			{
				foreach (object obj in base.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					if (listViewItem.Text.Equals(sText))
					{
						return true;
					}
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			result = false;
		}
		return result;
	}

	// Token: 0x0600021D RID: 541 RVA: 0x00012B4C File Offset: 0x00010D4C
	public ListViewItem GetItem(string sURL)
	{
		ListViewItem result;
		if (base.InvokeRequired)
		{
			result = (ListViewItem)base.Invoke(new ListViewExt.Delegate9(this.GetItem), new object[]
			{
				sURL
			});
		}
		else
		{
			try
			{
				foreach (object obj in base.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					if (listViewItem.Text.Equals(sURL))
					{
						return listViewItem;
					}
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			result = new ListViewItem
			{
				SubItems = 
				{
					""
				}
			};
		}
		return result;
	}

	// Token: 0x0600021E RID: 542 RVA: 0x00002D05 File Offset: 0x00000F05
	public void DeselectAllItems()
	{
		this.method_1(this, -1, 2, 0);
	}

	// Token: 0x0600021F RID: 543 RVA: 0x00002D11 File Offset: 0x00000F11
	public void SelectAllItems()
	{
		this.method_1(this, -1, 2, 2);
	}

	// Token: 0x06000220 RID: 544 RVA: 0x00002D1D File Offset: 0x00000F1D
	public void SetSelectedColumn(ColumnHeader value)
	{
		ListViewExt.SendMessage_1(base.Handle, 4236U, (IntPtr)((value == null) ? -1 : value.Index), (IntPtr)0);
	}

	// Token: 0x170000A5 RID: 165
	// (get) Token: 0x06000221 RID: 545 RVA: 0x00002D47 File Offset: 0x00000F47
	public bool IsSelectedSomeItem
	{
		get
		{
			return base.SelectedItems.Count > 0;
		}
	}

	// Token: 0x06000222 RID: 546 RVA: 0x00012BFC File Offset: 0x00010DFC
	public ListViewItem SelectedItem()
	{
		ListViewItem result;
		if (this.IsSelectedSomeItem)
		{
			result = base.SelectedItems[0];
		}
		else
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000223 RID: 547 RVA: 0x00002D57 File Offset: 0x00000F57
	public bool Scroll(int dx, int dy)
	{
		return ListViewExt.SendMessage_1(base.Handle, 4116U, (IntPtr)dx, (IntPtr)dy) != IntPtr.Zero;
	}

	// Token: 0x04000138 RID: 312
	private static int int_0;

	// Token: 0x04000139 RID: 313
	private static int int_1;

	// Token: 0x0400013A RID: 314
	private static int int_2;

	// Token: 0x0400013B RID: 315
	private static int int_3;

	// Token: 0x0400013C RID: 316
	private static int int_4;

	// Token: 0x0400013D RID: 317
	private static int int_5;

	// Token: 0x0400013E RID: 318
	private static int int_6;

	// Token: 0x0400013F RID: 319
	private static int int_7;

	// Token: 0x04000140 RID: 320
	private static int int_8;

	// Token: 0x04000141 RID: 321
	private static int int_9;

	// Token: 0x04000142 RID: 322
	private static int int_10;

	// Token: 0x04000143 RID: 323
	private static int int_11;

	// Token: 0x04000144 RID: 324
	private static int int_12;

	// Token: 0x04000145 RID: 325
	private ListViewExt.Class34 class34_0;

	// Token: 0x04000146 RID: 326
	private int int_13;

	// Token: 0x04000147 RID: 327
	private Image image_0;

	// Token: 0x04000148 RID: 328
	private static int int_14;

	// Token: 0x04000149 RID: 329
	private static int int_15;

	// Token: 0x0200003C RID: 60
	private struct Struct1
	{
		// Token: 0x0400014A RID: 330
		public uint uint_0;

		// Token: 0x0400014B RID: 331
		public int int_0;

		// Token: 0x0400014C RID: 332
		public IntPtr intptr_0;

		// Token: 0x0400014D RID: 333
		public IntPtr intptr_1;

		// Token: 0x0400014E RID: 334
		public int int_1;

		// Token: 0x0400014F RID: 335
		public int int_2;

		// Token: 0x04000150 RID: 336
		public IntPtr intptr_2;

		// Token: 0x04000151 RID: 337
		public int int_3;

		// Token: 0x04000152 RID: 338
		public int int_4;

		// Token: 0x04000153 RID: 339
		public uint uint_1;

		// Token: 0x04000154 RID: 340
		public IntPtr intptr_3;
	}

	// Token: 0x0200003D RID: 61
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	private struct Struct2
	{
		// Token: 0x04000155 RID: 341
		public int int_0;

		// Token: 0x04000156 RID: 342
		public int int_1;

		// Token: 0x04000157 RID: 343
		public int int_2;

		// Token: 0x04000158 RID: 344
		public int int_3;

		// Token: 0x04000159 RID: 345
		public int int_4;

		// Token: 0x0400015A RID: 346
		[MarshalAs(UnmanagedType.LPTStr)]
		public string string_0;

		// Token: 0x0400015B RID: 347
		public int int_5;

		// Token: 0x0400015C RID: 348
		public int int_6;

		// Token: 0x0400015D RID: 349
		public IntPtr intptr_0;

		// Token: 0x0400015E RID: 350
		public int int_7;

		// Token: 0x0400015F RID: 351
		public int int_8;

		// Token: 0x04000160 RID: 352
		public int int_9;

		// Token: 0x04000161 RID: 353
		public IntPtr intptr_1;
	}

	// Token: 0x0200003E RID: 62
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	private struct Struct3
	{
		// Token: 0x04000162 RID: 354
		public int int_0;

		// Token: 0x04000163 RID: 355
		public IntPtr intptr_0;

		// Token: 0x04000164 RID: 356
		[MarshalAs(UnmanagedType.LPTStr)]
		public string string_0;

		// Token: 0x04000165 RID: 357
		public int int_1;

		// Token: 0x04000166 RID: 358
		public int int_2;

		// Token: 0x04000167 RID: 359
		public int int_3;
	}

	// Token: 0x0200003F RID: 63
	public enum ListViewGroupMask
	{
		// Token: 0x04000169 RID: 361
		None,
		// Token: 0x0400016A RID: 362
		Header,
		// Token: 0x0400016B RID: 363
		Footer,
		// Token: 0x0400016C RID: 364
		State = 4,
		// Token: 0x0400016D RID: 365
		Align = 8,
		// Token: 0x0400016E RID: 366
		GroupId = 16,
		// Token: 0x0400016F RID: 367
		SubTitle = 256,
		// Token: 0x04000170 RID: 368
		Task = 512,
		// Token: 0x04000171 RID: 369
		DescriptionTop = 1024,
		// Token: 0x04000172 RID: 370
		DescriptionBottom = 2048,
		// Token: 0x04000173 RID: 371
		TitleImage = 4096,
		// Token: 0x04000174 RID: 372
		ExtendedImage = 8192,
		// Token: 0x04000175 RID: 373
		Items = 16384,
		// Token: 0x04000176 RID: 374
		Subset = 32768,
		// Token: 0x04000177 RID: 375
		SubsetItems = 65536
	}

	// Token: 0x02000040 RID: 64
	public enum ListViewGroupState
	{
		// Token: 0x04000179 RID: 377
		Normal,
		// Token: 0x0400017A RID: 378
		Collapsed,
		// Token: 0x0400017B RID: 379
		Hidden,
		// Token: 0x0400017C RID: 380
		NoHeader = 4,
		// Token: 0x0400017D RID: 381
		Collapsible = 8,
		// Token: 0x0400017E RID: 382
		Focused = 16,
		// Token: 0x0400017F RID: 383
		Selected = 32,
		// Token: 0x04000180 RID: 384
		SubSeted = 64,
		// Token: 0x04000181 RID: 385
		SubSetLinkFocused = 128
	}

	// Token: 0x02000041 RID: 65
	// (Invoke) Token: 0x06000227 RID: 551
	private delegate ListViewItem Delegate8(string sURL);

	// Token: 0x02000042 RID: 66
	// (Invoke) Token: 0x0600022B RID: 555
	private delegate ListViewItem Delegate9(string sURL);

	// Token: 0x02000043 RID: 67
	[Description("LVGROUP StructureUsed to set and retrieve groups.")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class LVGROUP
	{
		// Token: 0x0600022C RID: 556 RVA: 0x00002D7F File Offset: 0x00000F7F
		public LVGROUP()
		{
			this.CbSize = Marshal.SizeOf(typeof(ListViewExt.LVGROUP));
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00012C24 File Offset: 0x00010E24
		public override string ToString()
		{
			return "LVGROUP: header = " + this.PszHeader.ToString() + ", iGroupId = " + this.IGroupId.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x04000182 RID: 386
		[Description("Size of this structure, in bytes.")]
		public int CbSize;

		// Token: 0x04000183 RID: 387
		[Description("Mask that specifies which members of the structure are valid input. One or more of the following values:LVGF_NONE No other items are valid.")]
		public ListViewExt.ListViewGroupMask Mask;

		// Token: 0x04000184 RID: 388
		[Description("Pointer to a null-terminated string that contains the header text when item information is being set. If group information is being retrieved, this member specifies the address of the buffer that receives the header text.")]
		[MarshalAs(UnmanagedType.LPWStr)]
		public string PszHeader;

		// Token: 0x04000185 RID: 389
		[Description("Size in TCHARs of the buffer pointed to by the pszHeader member. If the structure is not receiving information about a group, this member is ignored.")]
		public int CchHeader;

		// Token: 0x04000186 RID: 390
		[Description("Pointer to a null-terminated string that contains the footer text when item information is being set. If group information is being retrieved, this member specifies the address of the buffer that receives the footer text.")]
		[MarshalAs(UnmanagedType.LPWStr)]
		public string PszFooter;

		// Token: 0x04000187 RID: 391
		[Description("Size in TCHARs of the buffer pointed to by the pszFooter member. If the structure is not receiving information about a group, this member is ignored.")]
		public int CchFooter;

		// Token: 0x04000188 RID: 392
		[Description("ID of the group.")]
		public int IGroupId;

		// Token: 0x04000189 RID: 393
		[Description("Mask used with LVM_GETGROUPINFO (Microsoft Windows XP and Windows Vista) and LVM_SETGROUPINFO (Windows Vista only) to specify which flags in the state value are being retrieved or set.")]
		public int StateMask;

		// Token: 0x0400018A RID: 394
		[Description("Flag that can have one of the following values:LVGS_NORMAL Groups are expanded, the group name is displayed, and all items in the group are displayed.")]
		public ListViewExt.ListViewGroupState State;

		// Token: 0x0400018B RID: 395
		[Description("Indicates the alignment of the header or footer text for the group. It can have one or more of the following values. Use one of the header flags. Footer flags are optional. Windows XP: Footer flags are reserved.LVGA_FOOTER_CENTERReserved.")]
		public uint UAlign;

		// Token: 0x0400018C RID: 396
		[Description("Windows Vista. Pointer to a null-terminated string that contains the subtitle text when item information is being set. If group information is being retrieved, this member specifies the address of the buffer that receives the subtitle text. This element is drawn under the header text.")]
		public IntPtr PszSubtitle;

		// Token: 0x0400018D RID: 397
		[Description("Windows Vista. Size, in TCHARs, of the buffer pointed to by the pszSubtitle member. If the structure is not receiving information about a group, this member is ignored.")]
		public uint CchSubtitle;

		// Token: 0x0400018E RID: 398
		[Description("Windows Vista. Pointer to a null-terminated string that contains the text for a task link when item information is being set. If group information is being retrieved, this member specifies the address of the buffer that receives the task text. This item is drawn right-aligned opposite the header text. When clicked by the user, the task link generates an LVN_LINKCLICK notification.")]
		[MarshalAs(UnmanagedType.LPWStr)]
		public string PszTask;

		// Token: 0x0400018F RID: 399
		[Description("Windows Vista. Size in TCHARs of the buffer pointed to by the pszTask member. If the structure is not receiving information about a group, this member is ignored.")]
		public uint CchTask;

		// Token: 0x04000190 RID: 400
		[Description("Windows Vista. Pointer to a null-terminated string that contains the top description text when item information is being set. If group information is being retrieved, this member specifies the address of the buffer that receives the top description text. This item is drawn opposite the title image when there is a title image, no extended image, and uAlign==LVGA_HEADER_CENTER.")]
		[MarshalAs(UnmanagedType.LPWStr)]
		public string PszDescriptionTop;

		// Token: 0x04000191 RID: 401
		[Description("Windows Vista. Size in TCHARs of the buffer pointed to by the pszDescriptionTop member. If the structure is not receiving information about a group, this member is ignored.")]
		public uint CchDescriptionTop;

		// Token: 0x04000192 RID: 402
		[Description("Windows Vista. Pointer to a null-terminated string that contains the bottom description text when item information is being set. If group information is being retrieved, this member specifies the address of the buffer that receives the bottom description text. This item is drawn under the top description text when there is a title image, no extended image, and uAlign==LVGA_HEADER_CENTER.")]
		[MarshalAs(UnmanagedType.LPWStr)]
		public string PszDescriptionBottom;

		// Token: 0x04000193 RID: 403
		[Description("Windows Vista. Size in TCHARs of the buffer pointed to by the pszDescriptionBottom member. If the structure is not receiving information about a group, this member is ignored.")]
		public uint CchDescriptionBottom;

		// Token: 0x04000194 RID: 404
		[Description("Windows Vista. Index of the title image in the control imagelist.")]
		public int ITitleImage;

		// Token: 0x04000195 RID: 405
		[Description("Windows Vista. Index of the extended image in the control imagelist.")]
		public int IExtendedImage;

		// Token: 0x04000196 RID: 406
		[Description("Windows Vista. Read-only.")]
		public int IFirstItem;

		// Token: 0x04000197 RID: 407
		[Description("Windows Vista. Read-only in non-owner data mode.")]
		public IntPtr CItems;

		// Token: 0x04000198 RID: 408
		[Description("Windows Vista. NULL if group is not a subset. Pointer to a null-terminated string that contains the subset title text when item information is being set. If group information is being retrieved, this member specifies the address of the buffer that receives the subset title text.")]
		public IntPtr PszSubsetTitle;

		// Token: 0x04000199 RID: 409
		[Description("Windows Vista. Size in TCHARs of the buffer pointed to by the pszSubsetTitle member. If the structure is not receiving information about a group, this member is ignored.")]
		public IntPtr CchSubsetTitle;
	}

	// Token: 0x02000044 RID: 68
	public class ListViewHelper
	{
		// Token: 0x0600022F RID: 559 RVA: 0x00012C60 File Offset: 0x00010E60
		internal static int smethod_0(ListViewGroup listViewGroup_0)
		{
			int result = 0;
			Type type = listViewGroup_0.GetType();
			if (type != null)
			{
				PropertyInfo property = type.GetProperty("ID", BindingFlags.Instance | BindingFlags.NonPublic);
				if (property != null)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(property.GetValue(listViewGroup_0, null));
					if (objectValue != null)
					{
						result = Conversions.ToInteger(objectValue);
					}
				}
			}
			return result;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00012CB0 File Offset: 0x00010EB0
		internal static void smethod_1(ListViewExt listViewExt_0, ListViewExt.ListViewGroupState listViewGroupState_0)
		{
			int num = 4096;
			checked
			{
				int int_ = num + 147;
				if (Environment.OSVersion.Version.Major >= 6)
				{
					if (listViewExt_0.InvokeRequired)
					{
						listViewExt_0.Invoke(new ListViewExt.ListViewHelper.CallSetLVGroups(ListViewExt.ListViewHelper.smethod_1), new object[]
						{
							listViewExt_0,
							listViewGroupState_0
						});
					}
					else if (listViewExt_0 != null)
					{
						for (int i = 0; i < listViewExt_0.Groups.Count; i++)
						{
							int num2 = ListViewExt.ListViewHelper.smethod_0(listViewExt_0.Groups[i]);
							ListViewExt.LVGROUP lvgroup = new ListViewExt.LVGROUP();
							lvgroup.State = listViewGroupState_0;
							lvgroup.Mask = ListViewExt.ListViewGroupMask.State;
							if (num2 > 0)
							{
								lvgroup.IGroupId = num2;
								ListViewExt.SendMessage(listViewExt_0.Handle, int_, num2, lvgroup);
							}
							else
							{
								lvgroup.IGroupId = i;
								ListViewExt.SendMessage(listViewExt_0.Handle, int_, i, lvgroup);
							}
						}
					}
				}
			}
		}

		// Token: 0x02000045 RID: 69
		// (Invoke) Token: 0x06000234 RID: 564
		public delegate void CallSetLVGroups(ListViewExt lstvw, ListViewExt.ListViewGroupState state);
	}

	// Token: 0x02000046 RID: 70
	internal sealed class Class34 : IComparer
	{
		// Token: 0x06000235 RID: 565 RVA: 0x00002D9C File Offset: 0x00000F9C
		public Class34()
		{
			this.int_0 = 0;
			this.sortOrder_0 = SortOrder.None;
			this.caseInsensitiveComparer_0 = new CaseInsensitiveComparer();
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00012D94 File Offset: 0x00010F94
		public int Compare(object x, object y)
		{
			ListViewItem listViewItem = (ListViewItem)x;
			ListViewItem listViewItem2 = (ListViewItem)y;
			int result;
			if (listViewItem2 == null || listViewItem2 == null)
			{
				result = 0;
			}
			else
			{
				int num = this.caseInsensitiveComparer_0.Compare(listViewItem.SubItems[this.int_0].Text, listViewItem2.SubItems[this.int_0].Text);
				if (this.sortOrder_0 == SortOrder.Ascending)
				{
					result = num;
				}
				else if (this.sortOrder_0 == SortOrder.Descending)
				{
					result = checked(0 - num);
				}
				else
				{
					result = 0;
				}
			}
			return result;
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000237 RID: 567 RVA: 0x00012E1C File Offset: 0x0001101C
		// (set) Token: 0x06000238 RID: 568 RVA: 0x00002DBD File Offset: 0x00000FBD
		public int Int32_0
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

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000239 RID: 569 RVA: 0x00012E34 File Offset: 0x00011034
		// (set) Token: 0x0600023A RID: 570 RVA: 0x00002DC6 File Offset: 0x00000FC6
		public SortOrder SortOrder_0
		{
			get
			{
				return this.sortOrder_0;
			}
			set
			{
				this.sortOrder_0 = value;
			}
		}

		// Token: 0x0400019A RID: 410
		private int int_0;

		// Token: 0x0400019B RID: 411
		private SortOrder sortOrder_0;

		// Token: 0x0400019C RID: 412
		private CaseInsensitiveComparer caseInsensitiveComparer_0;
	}
}
