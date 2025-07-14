using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace My
{
	// Token: 0x0200000A RID: 10
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal sealed partial class MySettings : ApplicationSettingsBase
	{
		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000096 RID: 150 RVA: 0x0000A7A4 File Offset: 0x000089A4
		public static MySettings Default
		{
			get
			{
				return MySettings.defaultInstance;
			}
		}

		// Token: 0x0400001B RID: 27
		private static MySettings defaultInstance = (MySettings)SettingsBase.Synchronized(new MySettings());
	}
}
