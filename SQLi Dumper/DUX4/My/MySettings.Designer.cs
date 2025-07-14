using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace DUX4.My
{
	// Token: 0x02000111 RID: 273
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal sealed partial class MySettings : ApplicationSettingsBase
	{
		// Token: 0x17000554 RID: 1364
		// (get) Token: 0x06001165 RID: 4453 RVA: 0x0000931F File Offset: 0x0000751F
		public static MySettings Default
		{
			get
			{
				return MySettings.defaultInstance;
			}
		}

		// Token: 0x040008C5 RID: 2245
		private static MySettings defaultInstance = (MySettings)SettingsBase.Synchronized(new MySettings());
	}
}
