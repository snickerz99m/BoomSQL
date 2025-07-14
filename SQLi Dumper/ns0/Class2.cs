using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace ns0
{
	// Token: 0x02000005 RID: 5
	[HideModuleName]
	[StandardModule]
	[GeneratedCode("MyTemplate", "11.0.0.0")]
	internal sealed class Class2
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x0000955C File Offset: 0x0000775C
		[HelpKeyword("My.Computer")]
		internal static Class1 Class1_0
		{
			[DebuggerHidden]
			get
			{
				return Class2.class5_0.Prop_0;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000006 RID: 6 RVA: 0x00009578 File Offset: 0x00007778
		[HelpKeyword("My.Application")]
		internal static Class0 Class0_0
		{
			[DebuggerHidden]
			get
			{
				return Class2.class5_1.Prop_0;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00009594 File Offset: 0x00007794
		[HelpKeyword("My.User")]
		internal static User User_0
		{
			[DebuggerHidden]
			get
			{
				return Class2.class5_2.Prop_0;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000095B0 File Offset: 0x000077B0
		[HelpKeyword("My.Forms")]
		internal static Class2.Class3 Class3_0
		{
			[DebuggerHidden]
			get
			{
				return Class2.class5_3.Prop_0;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000095CC File Offset: 0x000077CC
		[HelpKeyword("My.WebServices")]
		internal static Class2.Class4 Class4_0
		{
			[DebuggerHidden]
			get
			{
				return Class2.class5_4.Prop_0;
			}
		}

		// Token: 0x04000001 RID: 1
		private static readonly Class2.Class5<Class1> class5_0 = new Class2.Class5<Class1>();

		// Token: 0x04000002 RID: 2
		private static readonly Class2.Class5<Class0> class5_1 = new Class2.Class5<Class0>();

		// Token: 0x04000003 RID: 3
		private static readonly Class2.Class5<User> class5_2 = new Class2.Class5<User>();

		// Token: 0x04000004 RID: 4
		private static Class2.Class5<Class2.Class3> class5_3 = new Class2.Class5<Class2.Class3>();

		// Token: 0x04000005 RID: 5
		private static readonly Class2.Class5<Class2.Class4> class5_4 = new Class2.Class5<Class2.Class4>();

		// Token: 0x02000006 RID: 6
		[EditorBrowsable(EditorBrowsableState.Never)]
		[MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
		internal sealed class Class3
		{
			// Token: 0x0600000A RID: 10 RVA: 0x000020F8 File Offset: 0x000002F8
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public Class3()
			{
			}

			// Token: 0x0600000B RID: 11 RVA: 0x000095E8 File Offset: 0x000077E8
			[DebuggerHidden]
			private static T smethod_0<T>(T gparam_0) where T : Form, new()
			{
				if (gparam_0 == null || gparam_0.IsDisposed)
				{
					if (Class2.Class3.hashtable_0 != null)
					{
						if (Class2.Class3.hashtable_0.ContainsKey(typeof(T)))
						{
							throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
						}
					}
					else
					{
						Class2.Class3.hashtable_0 = new Hashtable();
					}
					Class2.Class3.hashtable_0.Add(typeof(T), null);
					try
					{
						return Activator.CreateInstance<T>();
					}
					catch (TargetInvocationException ex) when (ex.InnerException != null)
					{
						string resourceString = Utils.GetResourceString("WinForms_SeeInnerException", new string[]
						{
							ex.InnerException.Message
						});
						throw new InvalidOperationException(resourceString, ex.InnerException);
					}
					finally
					{
						Class2.Class3.hashtable_0.Remove(typeof(T));
					}
				}
				return gparam_0;
			}

			// Token: 0x0600000C RID: 12 RVA: 0x00002100 File Offset: 0x00000300
			[DebuggerHidden]
			private void method_0<T>(ref T gparam_0) where T : Form
			{
				gparam_0.Dispose();
				gparam_0 = default(T);
			}

			// Token: 0x0600000D RID: 13 RVA: 0x00002115 File Offset: 0x00000315
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override bool Equals(object o)
			{
				return base.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			// Token: 0x0600000E RID: 14 RVA: 0x000096F4 File Offset: 0x000078F4
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x0600000F RID: 15 RVA: 0x0000970C File Offset: 0x0000790C
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal Type method_1()
			{
				return typeof(Class2.Class3);
			}

			// Token: 0x06000010 RID: 16 RVA: 0x00009728 File Offset: 0x00007928
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override string ToString()
			{
				return base.ToString();
			}

			// Token: 0x17000006 RID: 6
			// (get) Token: 0x06000011 RID: 17 RVA: 0x00002123 File Offset: 0x00000323
			// (set) Token: 0x06000022 RID: 34 RVA: 0x000022CC File Offset: 0x000004CC
			public AddURLs AddURLs_0
			{
				[DebuggerHidden]
				get
				{
					this.addURLs_0 = Class2.Class3.smethod_0<AddURLs>(this.addURLs_0);
					return this.addURLs_0;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.addURLs_0)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.method_0<AddURLs>(ref this.addURLs_0);
					}
				}
			}

			// Token: 0x17000007 RID: 7
			// (get) Token: 0x06000012 RID: 18 RVA: 0x0000213C File Offset: 0x0000033C
			// (set) Token: 0x06000023 RID: 35 RVA: 0x000022F6 File Offset: 0x000004F6
			public Analizer Analizer_0
			{
				[DebuggerHidden]
				get
				{
					this.analizer_0 = Class2.Class3.smethod_0<Analizer>(this.analizer_0);
					return this.analizer_0;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.analizer_0)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.method_0<Analizer>(ref this.analizer_0);
					}
				}
			}

			// Token: 0x17000008 RID: 8
			// (get) Token: 0x06000013 RID: 19 RVA: 0x00002155 File Offset: 0x00000355
			// (set) Token: 0x06000024 RID: 36 RVA: 0x00002320 File Offset: 0x00000520
			public DebugWin DebugWin_0
			{
				[DebuggerHidden]
				get
				{
					this.debugWin_0 = Class2.Class3.smethod_0<DebugWin>(this.debugWin_0);
					return this.debugWin_0;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.debugWin_0)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.method_0<DebugWin>(ref this.debugWin_0);
					}
				}
			}

			// Token: 0x17000009 RID: 9
			// (get) Token: 0x06000014 RID: 20 RVA: 0x0000216E File Offset: 0x0000036E
			// (set) Token: 0x06000025 RID: 37 RVA: 0x0000234A File Offset: 0x0000054A
			public Dumper Dumper_0
			{
				[DebuggerHidden]
				get
				{
					this.dumper_0 = Class2.Class3.smethod_0<Dumper>(this.dumper_0);
					return this.dumper_0;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.dumper_0)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.method_0<Dumper>(ref this.dumper_0);
					}
				}
			}

			// Token: 0x1700000A RID: 10
			// (get) Token: 0x06000015 RID: 21 RVA: 0x00002187 File Offset: 0x00000387
			// (set) Token: 0x06000026 RID: 38 RVA: 0x00002374 File Offset: 0x00000574
			public ImpBox ImpBox_0
			{
				[DebuggerHidden]
				get
				{
					this.impBox_0 = Class2.Class3.smethod_0<ImpBox>(this.impBox_0);
					return this.impBox_0;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.impBox_0)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.method_0<ImpBox>(ref this.impBox_0);
					}
				}
			}

			// Token: 0x1700000B RID: 11
			// (get) Token: 0x06000016 RID: 22 RVA: 0x000021A0 File Offset: 0x000003A0
			// (set) Token: 0x06000027 RID: 39 RVA: 0x0000239E File Offset: 0x0000059E
			public LoginFinder LoginFinder_0
			{
				[DebuggerHidden]
				get
				{
					this.loginFinder_0 = Class2.Class3.smethod_0<LoginFinder>(this.loginFinder_0);
					return this.loginFinder_0;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.loginFinder_0)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.method_0<LoginFinder>(ref this.loginFinder_0);
					}
				}
			}

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x06000017 RID: 23 RVA: 0x000021B9 File Offset: 0x000003B9
			// (set) Token: 0x06000028 RID: 40 RVA: 0x000023C8 File Offset: 0x000005C8
			public MainForm MainForm_0
			{
				[DebuggerHidden]
				get
				{
					this.mainForm_0 = Class2.Class3.smethod_0<MainForm>(this.mainForm_0);
					return this.mainForm_0;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.mainForm_0)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.method_0<MainForm>(ref this.mainForm_0);
					}
				}
			}

			// Token: 0x1700000D RID: 13
			// (get) Token: 0x06000018 RID: 24 RVA: 0x000021D2 File Offset: 0x000003D2
			// (set) Token: 0x06000029 RID: 41 RVA: 0x000023F2 File Offset: 0x000005F2
			public NewSocks NewSocks_0
			{
				[DebuggerHidden]
				get
				{
					this.newSocks_0 = Class2.Class3.smethod_0<NewSocks>(this.newSocks_0);
					return this.newSocks_0;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.newSocks_0)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.method_0<NewSocks>(ref this.newSocks_0);
					}
				}
			}

			// Token: 0x1700000E RID: 14
			// (get) Token: 0x06000019 RID: 25 RVA: 0x000021EB File Offset: 0x000003EB
			// (set) Token: 0x0600002A RID: 42 RVA: 0x0000241C File Offset: 0x0000061C
			public OpenFilePreview OpenFilePreview_0
			{
				[DebuggerHidden]
				get
				{
					this.openFilePreview_0 = Class2.Class3.smethod_0<OpenFilePreview>(this.openFilePreview_0);
					return this.openFilePreview_0;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.openFilePreview_0)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.method_0<OpenFilePreview>(ref this.openFilePreview_0);
					}
				}
			}

			// Token: 0x1700000F RID: 15
			// (get) Token: 0x0600001A RID: 26 RVA: 0x00002204 File Offset: 0x00000404
			// (set) Token: 0x0600002B RID: 43 RVA: 0x00002446 File Offset: 0x00000646
			public ProxyType ProxyType_0
			{
				[DebuggerHidden]
				get
				{
					this.proxyType_0 = Class2.Class3.smethod_0<ProxyType>(this.proxyType_0);
					return this.proxyType_0;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.proxyType_0)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.method_0<ProxyType>(ref this.proxyType_0);
					}
				}
			}

			// Token: 0x17000010 RID: 16
			// (get) Token: 0x0600001B RID: 27 RVA: 0x0000221D File Offset: 0x0000041D
			// (set) Token: 0x0600002C RID: 44 RVA: 0x00002470 File Offset: 0x00000670
			public ReExploiter ReExploiter_0
			{
				[DebuggerHidden]
				get
				{
					this.reExploiter_0 = Class2.Class3.smethod_0<ReExploiter>(this.reExploiter_0);
					return this.reExploiter_0;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.reExploiter_0)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.method_0<ReExploiter>(ref this.reExploiter_0);
					}
				}
			}

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x0600001C RID: 28 RVA: 0x00002236 File Offset: 0x00000436
			// (set) Token: 0x0600002D RID: 45 RVA: 0x0000249A File Offset: 0x0000069A
			public SearchColumn SearchColumn_0
			{
				[DebuggerHidden]
				get
				{
					this.searchColumn_0 = Class2.Class3.smethod_0<SearchColumn>(this.searchColumn_0);
					return this.searchColumn_0;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.searchColumn_0)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.method_0<SearchColumn>(ref this.searchColumn_0);
					}
				}
			}

			// Token: 0x17000012 RID: 18
			// (get) Token: 0x0600001D RID: 29 RVA: 0x0000224F File Offset: 0x0000044F
			// (set) Token: 0x0600002E RID: 46 RVA: 0x000024C4 File Offset: 0x000006C4
			public SocksCheck SocksCheck_0
			{
				[DebuggerHidden]
				get
				{
					this.socksCheck_0 = Class2.Class3.smethod_0<SocksCheck>(this.socksCheck_0);
					return this.socksCheck_0;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.socksCheck_0)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.method_0<SocksCheck>(ref this.socksCheck_0);
					}
				}
			}

			// Token: 0x17000013 RID: 19
			// (get) Token: 0x0600001E RID: 30 RVA: 0x00002268 File Offset: 0x00000468
			// (set) Token: 0x0600002F RID: 47 RVA: 0x000024EE File Offset: 0x000006EE
			public Splash Splash_0
			{
				[DebuggerHidden]
				get
				{
					this.splash_0 = Class2.Class3.smethod_0<Splash>(this.splash_0);
					return this.splash_0;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.splash_0)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.method_0<Splash>(ref this.splash_0);
					}
				}
			}

			// Token: 0x17000014 RID: 20
			// (get) Token: 0x0600001F RID: 31 RVA: 0x00002281 File Offset: 0x00000481
			// (set) Token: 0x06000030 RID: 48 RVA: 0x00002518 File Offset: 0x00000718
			public TranslateLNG TranslateLNG_0
			{
				[DebuggerHidden]
				get
				{
					this.translateLNG_0 = Class2.Class3.smethod_0<TranslateLNG>(this.translateLNG_0);
					return this.translateLNG_0;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.translateLNG_0)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.method_0<TranslateLNG>(ref this.translateLNG_0);
					}
				}
			}

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x06000020 RID: 32 RVA: 0x0000229A File Offset: 0x0000049A
			// (set) Token: 0x06000031 RID: 49 RVA: 0x00002542 File Offset: 0x00000742
			public UpdateProg UpdateProg_0
			{
				[DebuggerHidden]
				get
				{
					this.updateProg_0 = Class2.Class3.smethod_0<UpdateProg>(this.updateProg_0);
					return this.updateProg_0;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.updateProg_0)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.method_0<UpdateProg>(ref this.updateProg_0);
					}
				}
			}

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x06000021 RID: 33 RVA: 0x000022B3 File Offset: 0x000004B3
			// (set) Token: 0x06000032 RID: 50 RVA: 0x0000256C File Offset: 0x0000076C
			public WafAdd WafAdd_0
			{
				[DebuggerHidden]
				get
				{
					this.wafAdd_0 = Class2.Class3.smethod_0<WafAdd>(this.wafAdd_0);
					return this.wafAdd_0;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.wafAdd_0)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.method_0<WafAdd>(ref this.wafAdd_0);
					}
				}
			}

			// Token: 0x04000006 RID: 6
			[ThreadStatic]
			private static Hashtable hashtable_0;

			// Token: 0x04000007 RID: 7
			[EditorBrowsable(EditorBrowsableState.Never)]
			public AddURLs addURLs_0;

			// Token: 0x04000008 RID: 8
			[EditorBrowsable(EditorBrowsableState.Never)]
			public Analizer analizer_0;

			// Token: 0x04000009 RID: 9
			[EditorBrowsable(EditorBrowsableState.Never)]
			public DebugWin debugWin_0;

			// Token: 0x0400000A RID: 10
			[EditorBrowsable(EditorBrowsableState.Never)]
			public Dumper dumper_0;

			// Token: 0x0400000B RID: 11
			[EditorBrowsable(EditorBrowsableState.Never)]
			public ImpBox impBox_0;

			// Token: 0x0400000C RID: 12
			[EditorBrowsable(EditorBrowsableState.Never)]
			public LoginFinder loginFinder_0;

			// Token: 0x0400000D RID: 13
			[EditorBrowsable(EditorBrowsableState.Never)]
			public MainForm mainForm_0;

			// Token: 0x0400000E RID: 14
			[EditorBrowsable(EditorBrowsableState.Never)]
			public NewSocks newSocks_0;

			// Token: 0x0400000F RID: 15
			[EditorBrowsable(EditorBrowsableState.Never)]
			public OpenFilePreview openFilePreview_0;

			// Token: 0x04000010 RID: 16
			[EditorBrowsable(EditorBrowsableState.Never)]
			public ProxyType proxyType_0;

			// Token: 0x04000011 RID: 17
			[EditorBrowsable(EditorBrowsableState.Never)]
			public ReExploiter reExploiter_0;

			// Token: 0x04000012 RID: 18
			[EditorBrowsable(EditorBrowsableState.Never)]
			public SearchColumn searchColumn_0;

			// Token: 0x04000013 RID: 19
			[EditorBrowsable(EditorBrowsableState.Never)]
			public SocksCheck socksCheck_0;

			// Token: 0x04000014 RID: 20
			[EditorBrowsable(EditorBrowsableState.Never)]
			public Splash splash_0;

			// Token: 0x04000015 RID: 21
			[EditorBrowsable(EditorBrowsableState.Never)]
			public TranslateLNG translateLNG_0;

			// Token: 0x04000016 RID: 22
			[EditorBrowsable(EditorBrowsableState.Never)]
			public UpdateProg updateProg_0;

			// Token: 0x04000017 RID: 23
			[EditorBrowsable(EditorBrowsableState.Never)]
			public WafAdd wafAdd_0;
		}

		// Token: 0x02000007 RID: 7
		[EditorBrowsable(EditorBrowsableState.Never)]
		[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
		internal sealed class Class4
		{
			// Token: 0x06000033 RID: 51 RVA: 0x000020F8 File Offset: 0x000002F8
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public Class4()
			{
			}

			// Token: 0x06000034 RID: 52 RVA: 0x00002115 File Offset: 0x00000315
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override bool Equals(object o)
			{
				return base.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			// Token: 0x06000035 RID: 53 RVA: 0x000096F4 File Offset: 0x000078F4
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x06000036 RID: 54 RVA: 0x00009740 File Offset: 0x00007940
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal Type method_0()
			{
				return typeof(Class2.Class4);
			}

			// Token: 0x06000037 RID: 55 RVA: 0x00009728 File Offset: 0x00007928
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override string ToString()
			{
				return base.ToString();
			}

			// Token: 0x06000038 RID: 56 RVA: 0x0000975C File Offset: 0x0000795C
			[DebuggerHidden]
			private static T smethod_0<T>(T gparam_0) where T : new()
			{
				T result;
				if (gparam_0 == null)
				{
					result = Activator.CreateInstance<T>();
				}
				else
				{
					result = gparam_0;
				}
				return result;
			}

			// Token: 0x06000039 RID: 57 RVA: 0x00002596 File Offset: 0x00000796
			[DebuggerHidden]
			private void method_1<T>(ref T gparam_0)
			{
				gparam_0 = default(T);
			}
		}

		// Token: 0x02000008 RID: 8
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComVisible(false)]
		internal sealed class Class5<T> where T : new()
		{
			// Token: 0x0600003A RID: 58 RVA: 0x000020F8 File Offset: 0x000002F8
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public Class5()
			{
			}

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x0600003B RID: 59 RVA: 0x00009780 File Offset: 0x00007980
			internal T Prop_0
			{
				[DebuggerHidden]
				get
				{
					if (Class2.Class5<T>.gparam_0 == null)
					{
						Class2.Class5<T>.gparam_0 = Activator.CreateInstance<T>();
					}
					return Class2.Class5<T>.gparam_0;
				}
			}

			// Token: 0x04000018 RID: 24
			[CompilerGenerated]
			[ThreadStatic]
			private static T gparam_0;
		}
	}
}
