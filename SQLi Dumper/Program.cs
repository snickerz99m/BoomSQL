using System;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using ns0;

// Token: 0x020000E3 RID: 227
internal sealed class Program : MarshalByRefObject
{
	// Token: 0x06000FD6 RID: 4054 RVA: 0x00008A11 File Offset: 0x00006C11
	private static void smethod_2(object sender, NetworkAvailabilityEventArgs e)
	{
		global::Globals.NETWORK_AVAILABLE = e.IsAvailable;
	}

	// Token: 0x06000FD7 RID: 4055 RVA: 0x0006CDAC File Offset: 0x0006AFAC
	[STAThread]
	public static void Main()
	{
		int num;
		int num4;
		object obj;
		try
		{
			IL_02:
			ProjectData.ClearProjectError();
			num = -2;
			IL_0A:
			int num2 = 2;
			if (Debugger.IsAttached)
			{
				goto IL_18;
			}
			IL_16:
			num2 = 3;
			IL_18:
			num2 = 5;
			Form form = new Form();
			IL_20:
			num2 = 6;
			form.StartPosition = FormStartPosition.CenterScreen;
			IL_29:
			num2 = 7;
			form.TopMost = true;
			IL_32:
			num2 = 8;
			form.FormBorderStyle = FormBorderStyle.None;
			IL_3B:
			num2 = 9;
			form.BackgroundImage = Class6.lol;
			IL_49:
			num2 = 10;
			form.Size = Class6.lol.Size;
			IL_5C:
			num2 = 11;
			form.Opacity = 0.8;
			IL_6E:
			num2 = 12;
			form.ShowInTaskbar = false;
			IL_78:
			num2 = 13;
			Application.Run(form);
			IL_81:
			goto IL_113;
			IL_86:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_CC:
			goto IL_108;
			IL_CE:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_E6:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_CE;
		}
		IL_108:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_113:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06000FD8 RID: 4056 RVA: 0x0006CEE4 File Offset: 0x0006B0E4
	public static object smethod_0()
	{
		System.Threading.ThreadPool threadPool = new global::ThreadPool(300);
		Versioned.CallByName(global::Globals.GMain, "Tag", CallType.Set, new object[]
		{
			"c4rl0s@jabber.ru"
		});
		return global::Globals.GMain;
	}

	// Token: 0x06000FD9 RID: 4057 RVA: 0x0006CF28 File Offset: 0x0006B128
	public static bool smethod_3()
	{
		bool result;
		try
		{
			bool flag;
			bool flag2;
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Installer\\Dependencies"))
			{
				foreach (string name in registryKey.GetSubKeyNames())
				{
					using (RegistryKey registryKey2 = registryKey.OpenSubKey(name))
					{
						string text = (string)registryKey2.GetValue("DisplayName");
						if (!string.IsNullOrEmpty(text))
						{
							if (text.Contains("Microsoft Visual C++ 2015 Redistributable (x64)"))
							{
								flag = true;
							}
							if (text.Contains("Microsoft Visual C++ 2015 Redistributable (x86)"))
							{
								flag2 = true;
							}
						}
					}
				}
			}
			if (flag && flag2)
			{
				result = true;
			}
			else
			{
				MessageBox.Show("Please Install 'Microsoft Visual C++ 2015 Redistributable' x64 and x86", "SQLi Dumper Dependencies", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				global::Globals.ShellUrl("https://www.microsoft.com/en-us/download/details.aspx?id=48145");
				result = false;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "IsVC2015RedistInstalled", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return result;
	}

	// Token: 0x06000FDA RID: 4058 RVA: 0x0006D044 File Offset: 0x0006B244
	private static void smethod_4(object sender, ThreadExceptionEventArgs e)
	{
		DialogResult dialogResult = DialogResult.Cancel;
		try
		{
			dialogResult = Program.smethod_6("SQLi Dumper Error", e.Exception);
		}
		catch (Exception ex)
		{
			try
			{
				MessageBox.Show("SQLi Dumper Error", "SQLi Dumper", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand);
			}
			finally
			{
				Application.Exit();
			}
		}
		if (dialogResult == DialogResult.Abort)
		{
			Application.Exit();
		}
	}

	// Token: 0x06000FDB RID: 4059 RVA: 0x0006D0B4 File Offset: 0x0006B2B4
	private static void smethod_5(object sender, UnhandledExceptionEventArgs e)
	{
		try
		{
			Exception ex = (Exception)e.ExceptionObject;
			using (StreamWriter streamWriter = File.AppendText(Class2.Class0_0.Info.DirectoryPath + "\\ErrLog.log"))
			{
				streamWriter.WriteLine("[" + DateAndTime.Now.ToString() + "]" + ex.ToString());
			}
			MessageBox.Show("Ops, an error was thrown, but not handled. The error was: \r\n" + ex.Message + "\r\n(For me information about this exception, please see 'ErrLog.log')", "SQLi Dumper Error, Please Report Bug", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		catch (Exception ex2)
		{
			try
			{
				MessageBox.Show("Fatal Non-UI Error", "Fatal Non-UI Error. Could not write the error to the event log. Reason: " + ex2.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			finally
			{
				Application.Exit();
			}
		}
	}

	// Token: 0x06000FDC RID: 4060 RVA: 0x0006D1A8 File Offset: 0x0006B3A8
	private static DialogResult smethod_6(string string_0, Exception exception_0)
	{
		string text = "An application error occurred. Please contact the adminstrator with the following information:\n\n";
		text = text + exception_0.Message + "\n\nStack Trace:\n" + exception_0.StackTrace;
		return MessageBox.Show(text, string_0, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand);
	}

	// Token: 0x06000FDD RID: 4061 RVA: 0x00008A1E File Offset: 0x00006C1E
	public static bool smethod_1(string[] arg)
	{
		return true;
	}

	// Token: 0x06000FDE RID: 4062 RVA: 0x0006D1E0 File Offset: 0x0006B3E0
	[STAThread]
	public static void MyMethod()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(true);
		Application.ThreadException += Program.smethod_4;
		Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
		AppDomain.CurrentDomain.UnhandledException += Program.smethod_5;
		Application.Run((MainForm)Program.smethod_0());
	}
}
