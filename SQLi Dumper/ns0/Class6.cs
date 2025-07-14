using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ns0
{
	// Token: 0x02000009 RID: 9
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[HideModuleName]
	[CompilerGenerated]
	[StandardModule]
	internal sealed class Class6
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600003C RID: 60 RVA: 0x000097B0 File Offset: 0x000079B0
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Class6.resourceManager_0, null))
				{
					ResourceManager resourceManager = new ResourceManager("Resources", typeof(Class6).Assembly);
					Class6.resourceManager_0 = resourceManager;
				}
				return Class6.resourceManager_0;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600003D RID: 61 RVA: 0x000097F4 File Offset: 0x000079F4
		// (set) Token: 0x0600003E RID: 62 RVA: 0x0000259F File Offset: 0x0000079F
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Class6.cultureInfo_0;
			}
			set
			{
				Class6.cultureInfo_0 = value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00009808 File Offset: 0x00007A08
		internal static Bitmap _Stop
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("_Stop", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00009838 File Offset: 0x00007A38
		internal static Bitmap about
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("about", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00009868 File Offset: 0x00007A68
		internal static Bitmap add
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("add", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00009898 File Offset: 0x00007A98
		internal static Bitmap AddAgent_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("AddAgent_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000043 RID: 67 RVA: 0x000098C8 File Offset: 0x00007AC8
		internal static Bitmap AddStyleRule_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("AddStyleRule_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000044 RID: 68 RVA: 0x000098F8 File Offset: 0x00007AF8
		internal static Bitmap AddToCollection_ActionGray_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("AddToCollection_ActionGray_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00009928 File Offset: 0x00007B28
		internal static Bitmap appwindow_info_annotation_16
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("appwindow_info_annotation_16", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00009958 File Offset: 0x00007B58
		internal static Bitmap AutoArrangeShapes_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("AutoArrangeShapes_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00009988 File Offset: 0x00007B88
		internal static Bitmap BuilderDialog_delete
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("BuilderDialog_delete", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000099B8 File Offset: 0x00007BB8
		internal static Bitmap CascadeWindows
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("CascadeWindows", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000049 RID: 73 RVA: 0x000099E8 File Offset: 0x00007BE8
		internal static Bitmap ChartFilter_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("ChartFilter_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00009A18 File Offset: 0x00007C18
		internal static Bitmap CheckSpellingHS
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("CheckSpellingHS", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00009A48 File Offset: 0x00007C48
		internal static Bitmap claspe
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("claspe", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600004C RID: 76 RVA: 0x00009A78 File Offset: 0x00007C78
		internal static Bitmap clipboard
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("clipboard", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00009AA8 File Offset: 0x00007CA8
		internal static Bitmap clipboard_16xLG
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("clipboard_16xLG", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00009AD8 File Offset: 0x00007CD8
		internal static Bitmap CloseDocumentGroup_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("CloseDocumentGroup_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00009B08 File Offset: 0x00007D08
		internal static Bitmap CloseGroup_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("CloseGroup_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00009B38 File Offset: 0x00007D38
		internal static Bitmap CloseSolution_inverse_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("CloseSolution_inverse_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00009B68 File Offset: 0x00007D68
		internal static Bitmap ConfirmButton_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("ConfirmButton_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00009B98 File Offset: 0x00007D98
		internal static Bitmap Control_PrintPreviewDialog
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("Control_PrintPreviewDialog", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00009BC8 File Offset: 0x00007DC8
		internal static Bitmap DatabaseSchema_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("DatabaseSchema_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00009BF8 File Offset: 0x00007DF8
		internal static Bitmap DataSet_TableView
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("DataSet_TableView", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00009C28 File Offset: 0x00007E28
		internal static Bitmap delete
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("delete", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00009C58 File Offset: 0x00007E58
		internal static Bitmap deletered
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("deletered", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00009C88 File Offset: 0x00007E88
		internal static Bitmap DeleteTable
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("DeleteTable", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00009CB8 File Offset: 0x00007EB8
		internal static string dic_login_finder
		{
			get
			{
				return Class6.ResourceManager.GetString("dic_login_finder", Class6.cultureInfo_0);
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00009CDC File Offset: 0x00007EDC
		internal static Bitmap downarrowhover
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("downarrowhover", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00009D0C File Offset: 0x00007F0C
		internal static Bitmap Download_grey_inverse_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("Download_grey_inverse_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00009D3C File Offset: 0x00007F3C
		internal static Bitmap DownloadWebSetting_16x
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("DownloadWebSetting_16x", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00009D6C File Offset: 0x00007F6C
		internal static Bitmap DynamicMenu_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("DynamicMenu_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00009D9C File Offset: 0x00007F9C
		internal static string English
		{
			get
			{
				return Class6.ResourceManager.GetString("English", Class6.cultureInfo_0);
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00009DC0 File Offset: 0x00007FC0
		internal static Bitmap Entry_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("Entry_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00009DF0 File Offset: 0x00007FF0
		internal static Bitmap expand
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("expand", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00009E20 File Offset: 0x00008020
		internal static Bitmap FillDown
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("FillDown", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00009E50 File Offset: 0x00008050
		internal static Bitmap FillUp
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("FillUp", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00009E80 File Offset: 0x00008080
		internal static Bitmap find_and_replace
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("find_and_replace", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00009EB0 File Offset: 0x000080B0
		internal static Bitmap formalines
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("formalines", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00009EE0 File Offset: 0x000080E0
		internal static string French
		{
			get
			{
				return Class6.ResourceManager.GetString("French", Class6.cultureInfo_0);
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00009F04 File Offset: 0x00008104
		internal static string German
		{
			get
			{
				return Class6.ResourceManager.GetString("German", Class6.cultureInfo_0);
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00009F28 File Offset: 0x00008128
		internal static Bitmap GetDynamicValuePropertyactivity_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("GetDynamicValuePropertyactivity_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00009F58 File Offset: 0x00008158
		internal static Bitmap help
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("help", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00009F88 File Offset: 0x00008188
		internal static Bitmap HTMLSubmit
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("HTMLSubmit", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00009FB8 File Offset: 0x000081B8
		internal static Icon icon
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("icon", Class6.cultureInfo_0));
				return (Icon)objectValue;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00009FE8 File Offset: 0x000081E8
		internal static Bitmap infohover
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("infohover", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600006B RID: 107 RVA: 0x0000A018 File Offset: 0x00008218
		internal static Bitmap IPAddressControl_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("IPAddressControl_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600006C RID: 108 RVA: 0x0000A048 File Offset: 0x00008248
		internal static Bitmap log_about
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("log_about", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600006D RID: 109 RVA: 0x0000A078 File Offset: 0x00008278
		internal static Bitmap lol
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("lol", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600006E RID: 110 RVA: 0x0000A0A8 File Offset: 0x000082A8
		internal static Bitmap NewDocument
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("NewDocument", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600006F RID: 111 RVA: 0x0000A0D8 File Offset: 0x000082D8
		internal static Bitmap NextFrameArrow_16x
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("NextFrameArrow_16x", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000070 RID: 112 RVA: 0x0000A108 File Offset: 0x00008308
		internal static Bitmap Bitmap_0
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("OK", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000071 RID: 113 RVA: 0x0000A138 File Offset: 0x00008338
		internal static Bitmap open_file
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("open_file", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000072 RID: 114 RVA: 0x0000A168 File Offset: 0x00008368
		internal static Bitmap OpenTopic_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("OpenTopic_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000073 RID: 115 RVA: 0x0000A198 File Offset: 0x00008398
		internal static Bitmap PageNumber
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("PageNumber", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000074 RID: 116 RVA: 0x0000A1C8 File Offset: 0x000083C8
		internal static Bitmap PageRedirect_16x
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("PageRedirect_16x", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000075 RID: 117 RVA: 0x0000A1F8 File Offset: 0x000083F8
		internal static Bitmap Pause
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("Pause", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000076 RID: 118 RVA: 0x0000A228 File Offset: 0x00008428
		internal static Bitmap Pause_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("Pause_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000077 RID: 119 RVA: 0x0000A258 File Offset: 0x00008458
		internal static string Persian
		{
			get
			{
				return Class6.ResourceManager.GetString("Persian", Class6.cultureInfo_0);
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000078 RID: 120 RVA: 0x0000A27C File Offset: 0x0000847C
		internal static string Portuguese
		{
			get
			{
				return Class6.ResourceManager.GetString("Portuguese", Class6.cultureInfo_0);
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000079 RID: 121 RVA: 0x0000A2A0 File Offset: 0x000084A0
		internal static Bitmap PreviousFrame_16x
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("PreviousFrame_16x", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600007A RID: 122 RVA: 0x0000A2D0 File Offset: 0x000084D0
		internal static Bitmap progress_go
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("progress_go", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600007B RID: 123 RVA: 0x0000A300 File Offset: 0x00008500
		internal static Bitmap progress_stop
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("progress_stop", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600007C RID: 124 RVA: 0x0000A330 File Offset: 0x00008530
		internal static Bitmap ProjectSystemModelRefresh_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("ProjectSystemModelRefresh_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600007D RID: 125 RVA: 0x0000A360 File Offset: 0x00008560
		internal static Bitmap Refresh
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("Refresh", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600007E RID: 126 RVA: 0x0000A390 File Offset: 0x00008590
		internal static Bitmap reg
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("reg", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600007F RID: 127 RVA: 0x0000A3C0 File Offset: 0x000085C0
		internal static Bitmap Retry
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("Retry", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000080 RID: 128 RVA: 0x0000A3F0 File Offset: 0x000085F0
		internal static Bitmap Run
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("Run", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000081 RID: 129 RVA: 0x0000A420 File Offset: 0x00008620
		internal static Bitmap Run_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("Run_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000082 RID: 130 RVA: 0x0000A450 File Offset: 0x00008650
		internal static Bitmap RunThread_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("RunThread_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000083 RID: 131 RVA: 0x0000A480 File Offset: 0x00008680
		internal static Bitmap RunUpdate_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("RunUpdate_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000084 RID: 132 RVA: 0x0000A4B0 File Offset: 0x000086B0
		internal static string Russian
		{
			get
			{
				return Class6.ResourceManager.GetString("Russian", Class6.cultureInfo_0);
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000085 RID: 133 RVA: 0x0000A4D4 File Offset: 0x000086D4
		internal static Bitmap Save_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("Save_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000086 RID: 134 RVA: 0x0000A504 File Offset: 0x00008704
		internal static Bitmap SaveFileDialogControl_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("SaveFileDialogControl_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000087 RID: 135 RVA: 0x0000A534 File Offset: 0x00008734
		internal static Bitmap search
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("search", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000088 RID: 136 RVA: 0x0000A564 File Offset: 0x00008764
		internal static Bitmap SearchContract_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("SearchContract_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000089 RID: 137 RVA: 0x0000A594 File Offset: 0x00008794
		internal static Bitmap speed_test
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("speed_test", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600008A RID: 138 RVA: 0x0000A5C4 File Offset: 0x000087C4
		internal static Bitmap StepIntoArrow_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("StepIntoArrow_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600008B RID: 139 RVA: 0x0000A5F4 File Offset: 0x000087F4
		internal static Bitmap Stop_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("Stop_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600008C RID: 140 RVA: 0x0000A624 File Offset: 0x00008824
		internal static Bitmap Template_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("Template_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600008D RID: 141 RVA: 0x0000A654 File Offset: 0x00008854
		internal static Bitmap Text_align_left
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("Text_align_left", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600008E RID: 142 RVA: 0x0000A684 File Offset: 0x00008884
		internal static Bitmap UpdatePanel_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("UpdatePanel_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600008F RID: 143 RVA: 0x0000A6B4 File Offset: 0x000088B4
		internal static Bitmap Upload_gray_inverse_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("Upload_gray_inverse_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000090 RID: 144 RVA: 0x0000A6E4 File Offset: 0x000088E4
		internal static Bitmap URLInputBox_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("URLInputBox_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000091 RID: 145 RVA: 0x0000A714 File Offset: 0x00008914
		internal static Bitmap ViewFull_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("ViewFull_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000092 RID: 146 RVA: 0x0000A744 File Offset: 0x00008944
		internal static Bitmap ViewLandscape_16x_24
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("ViewLandscape_16x_24", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000093 RID: 147 RVA: 0x0000A774 File Offset: 0x00008974
		internal static Bitmap Windows
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Class6.ResourceManager.GetObject("Windows", Class6.cultureInfo_0));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x04000019 RID: 25
		private static ResourceManager resourceManager_0;

		// Token: 0x0400001A RID: 26
		private static CultureInfo cultureInfo_0;
	}
}
