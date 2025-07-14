using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.MyServices.Internal;

namespace DUX4.My
{
	// Token: 0x0200010E RID: 270
	[StandardModule]
	[HideModuleName]
	[GeneratedCode("MyTemplate", "11.0.0.0")]
	internal sealed class MyProject
	{
		// Token: 0x1700054F RID: 1359
		// (get) Token: 0x06001156 RID: 4438 RVA: 0x000092AA File Offset: 0x000074AA
		[HelpKeyword("My.Computer")]
		internal static MyComputer Computer
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_ComputerObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000550 RID: 1360
		// (get) Token: 0x06001157 RID: 4439 RVA: 0x000092B6 File Offset: 0x000074B6
		[HelpKeyword("My.Application")]
		internal static MyApplication Application
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_AppObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000551 RID: 1361
		// (get) Token: 0x06001158 RID: 4440 RVA: 0x000092C2 File Offset: 0x000074C2
		[HelpKeyword("My.User")]
		internal static User User
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_UserObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000552 RID: 1362
		// (get) Token: 0x06001159 RID: 4441 RVA: 0x000092CE File Offset: 0x000074CE
		[HelpKeyword("My.WebServices")]
		internal static MyProject.MyWebServices WebServices
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_MyWebServicesObjectProvider.GetInstance;
			}
		}

		// Token: 0x040008C0 RID: 2240
		private static readonly MyProject.ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new MyProject.ThreadSafeObjectProvider<MyComputer>();

		// Token: 0x040008C1 RID: 2241
		private static readonly MyProject.ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new MyProject.ThreadSafeObjectProvider<MyApplication>();

		// Token: 0x040008C2 RID: 2242
		private static readonly MyProject.ThreadSafeObjectProvider<User> m_UserObjectProvider = new MyProject.ThreadSafeObjectProvider<User>();

		// Token: 0x040008C3 RID: 2243
		private static readonly MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices> m_MyWebServicesObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices>();

		// Token: 0x0200010F RID: 271
		[EditorBrowsable(EditorBrowsableState.Never)]
		[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
		internal sealed class MyWebServices
		{
			// Token: 0x0600115A RID: 4442 RVA: 0x00002115 File Offset: 0x00000315
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public override bool Equals(object o)
			{
				return base.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			// Token: 0x0600115B RID: 4443 RVA: 0x000092DA File Offset: 0x000074DA
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x0600115C RID: 4444 RVA: 0x000092E2 File Offset: 0x000074E2
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			internal new Type GetType()
			{
				return typeof(MyProject.MyWebServices);
			}

			// Token: 0x0600115D RID: 4445 RVA: 0x000092EE File Offset: 0x000074EE
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public override string ToString()
			{
				return base.ToString();
			}

			// Token: 0x0600115E RID: 4446 RVA: 0x00079BA4 File Offset: 0x00077DA4
			[DebuggerHidden]
			private static T Create__Instance__<T>(T instance) where T : new()
			{
				T result;
				if (instance == null)
				{
					result = Activator.CreateInstance<T>();
				}
				else
				{
					result = instance;
				}
				return result;
			}

			// Token: 0x0600115F RID: 4447 RVA: 0x00002596 File Offset: 0x00000796
			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance)
			{
				instance = default(T);
			}

			// Token: 0x06001160 RID: 4448 RVA: 0x000020F8 File Offset: 0x000002F8
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public MyWebServices()
			{
			}
		}

		// Token: 0x02000110 RID: 272
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComVisible(false)]
		internal sealed class ThreadSafeObjectProvider<T> where T : new()
		{
			// Token: 0x17000553 RID: 1363
			// (get) Token: 0x06001161 RID: 4449 RVA: 0x00079BC4 File Offset: 0x00077DC4
			internal T GetInstance
			{
				[DebuggerHidden]
				get
				{
					T t = this.m_Context.Value;
					if (t == null)
					{
						t = Activator.CreateInstance<T>();
						this.m_Context.Value = t;
					}
					return t;
				}
			}

			// Token: 0x06001162 RID: 4450 RVA: 0x000092F6 File Offset: 0x000074F6
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public ThreadSafeObjectProvider()
			{
				this.m_Context = new ContextValue<T>();
			}

			// Token: 0x040008C4 RID: 2244
			private readonly ContextValue<T> m_Context;
		}
	}
}
