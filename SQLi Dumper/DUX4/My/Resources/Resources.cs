using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace DUX4.My.Resources
{
	// Token: 0x02000113 RID: 275
	[StandardModule]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	[HideModuleName]
	internal sealed class Resources
	{
		// Token: 0x17000556 RID: 1366
		// (get) Token: 0x06001167 RID: 4455 RVA: 0x0000932D File Offset: 0x0000752D
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					Resources.resourceMan = new ResourceManager("DUX4.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000557 RID: 1367
		// (get) Token: 0x06001168 RID: 4456 RVA: 0x0000935F File Offset: 0x0000755F
		// (set) Token: 0x06001169 RID: 4457 RVA: 0x00009366 File Offset: 0x00007566
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x040008C6 RID: 2246
		private static ResourceManager resourceMan;

		// Token: 0x040008C7 RID: 2247
		private static CultureInfo resourceCulture;
	}
}
