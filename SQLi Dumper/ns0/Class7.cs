using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using My;

namespace ns0
{
	// Token: 0x0200000B RID: 11
	[DebuggerNonUserCode]
	[StandardModule]
	[HideModuleName]
	[CompilerGenerated]
	internal sealed class Class7
	{
		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000097 RID: 151 RVA: 0x0000A7B8 File Offset: 0x000089B8
		[HelpKeyword("My.Settings")]
		internal static MySettings Settings
		{
			get
			{
				return MySettings.Default;
			}
		}
	}
}
