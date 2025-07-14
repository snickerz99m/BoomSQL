using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Chilkat;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

// Token: 0x020000EC RID: 236
[DesignerGenerated]
public partial class SocksCheck : Form
{
	// Token: 0x06001042 RID: 4162 RVA: 0x0006FEC4 File Offset: 0x0006E0C4
	public SocksCheck()
	{
		base.FormClosing += this.SocksCheck_FormClosing;
		base.Load += this.SocksCheck_Load;
		this.arrayList_0 = new ArrayList();
		this.string_0 = Conversions.ToString(global::Globals.GetObjectValue(global::Globals.GMain.txtUserAgent));
		this.string_1 = Conversions.ToString(global::Globals.GetObjectValue(global::Globals.GMain.txtAccept));
		this.InitializeComponent();
		global::Globals.AddMouseMoveForm(this);
		global::Globals.translate_0.Add(this, this.icontainer_0);
	}

	// Token: 0x17000510 RID: 1296
	// (get) Token: 0x06001045 RID: 4165 RVA: 0x00008CB9 File Offset: 0x00006EB9
	// (set) Token: 0x06001046 RID: 4166 RVA: 0x00008CC1 File Offset: 0x00006EC1
	internal virtual ToolStrip ToolStrip1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000511 RID: 1297
	// (get) Token: 0x06001047 RID: 4167 RVA: 0x00008CCA File Offset: 0x00006ECA
	// (set) Token: 0x06001048 RID: 4168 RVA: 0x00070840 File Offset: 0x0006EA40
	internal virtual ToolStripButton btnStart
	{
		[CompilerGenerated]
		get
		{
			return this._btnStart;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_2);
			ToolStripButton btnStart = this._btnStart;
			if (btnStart != null)
			{
				btnStart.Click -= value2;
			}
			this._btnStart = value;
			btnStart = this._btnStart;
			if (btnStart != null)
			{
				btnStart.Click += value2;
			}
		}
	}

	// Token: 0x17000512 RID: 1298
	// (get) Token: 0x06001049 RID: 4169 RVA: 0x00008CD2 File Offset: 0x00006ED2
	// (set) Token: 0x0600104A RID: 4170 RVA: 0x00008CDA File Offset: 0x00006EDA
	internal virtual ToolStripSeparator ToolStripSeparator2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000513 RID: 1299
	// (get) Token: 0x0600104B RID: 4171 RVA: 0x00008CE3 File Offset: 0x00006EE3
	// (set) Token: 0x0600104C RID: 4172 RVA: 0x00070884 File Offset: 0x0006EA84
	internal virtual ToolStripButton btnPause
	{
		[CompilerGenerated]
		get
		{
			return this._btnPause;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_3);
			ToolStripButton btnPause = this._btnPause;
			if (btnPause != null)
			{
				btnPause.Click -= value2;
			}
			this._btnPause = value;
			btnPause = this._btnPause;
			if (btnPause != null)
			{
				btnPause.Click += value2;
			}
		}
	}

	// Token: 0x17000514 RID: 1300
	// (get) Token: 0x0600104D RID: 4173 RVA: 0x00008CEB File Offset: 0x00006EEB
	// (set) Token: 0x0600104E RID: 4174 RVA: 0x00008CF3 File Offset: 0x00006EF3
	internal virtual ToolStripSeparator ToolStripSeparator3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000515 RID: 1301
	// (get) Token: 0x0600104F RID: 4175 RVA: 0x00008CFC File Offset: 0x00006EFC
	// (set) Token: 0x06001050 RID: 4176 RVA: 0x000708C8 File Offset: 0x0006EAC8
	internal virtual ToolStripButton btnStop
	{
		[CompilerGenerated]
		get
		{
			return this._btnStop;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_4);
			ToolStripButton btnStop = this._btnStop;
			if (btnStop != null)
			{
				btnStop.Click -= value2;
			}
			this._btnStop = value;
			btnStop = this._btnStop;
			if (btnStop != null)
			{
				btnStop.Click += value2;
			}
		}
	}

	// Token: 0x17000516 RID: 1302
	// (get) Token: 0x06001051 RID: 4177 RVA: 0x00008D04 File Offset: 0x00006F04
	// (set) Token: 0x06001052 RID: 4178 RVA: 0x00008D0C File Offset: 0x00006F0C
	internal virtual NumericUpDown numTimeout { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000517 RID: 1303
	// (get) Token: 0x06001053 RID: 4179 RVA: 0x00008D15 File Offset: 0x00006F15
	// (set) Token: 0x06001054 RID: 4180 RVA: 0x00008D1D File Offset: 0x00006F1D
	internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000518 RID: 1304
	// (get) Token: 0x06001055 RID: 4181 RVA: 0x00008D26 File Offset: 0x00006F26
	// (set) Token: 0x06001056 RID: 4182 RVA: 0x00008D2E File Offset: 0x00006F2E
	internal virtual NumericUpDown numThreads { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x17000519 RID: 1305
	// (get) Token: 0x06001057 RID: 4183 RVA: 0x00008D37 File Offset: 0x00006F37
	// (set) Token: 0x06001058 RID: 4184 RVA: 0x00008D3F File Offset: 0x00006F3F
	internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700051A RID: 1306
	// (get) Token: 0x06001059 RID: 4185 RVA: 0x00008D48 File Offset: 0x00006F48
	// (set) Token: 0x0600105A RID: 4186 RVA: 0x00008D50 File Offset: 0x00006F50
	internal virtual StatusStrip stsMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700051B RID: 1307
	// (get) Token: 0x0600105B RID: 4187 RVA: 0x00008D59 File Offset: 0x00006F59
	// (set) Token: 0x0600105C RID: 4188 RVA: 0x00008D61 File Offset: 0x00006F61
	internal virtual ToolStripStatusLabel lblStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700051C RID: 1308
	// (get) Token: 0x0600105D RID: 4189 RVA: 0x00008D6A File Offset: 0x00006F6A
	// (set) Token: 0x0600105E RID: 4190 RVA: 0x00008D72 File Offset: 0x00006F72
	internal virtual ProgressBar pgbChecker { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

	// Token: 0x1700051D RID: 1309
	// (get) Token: 0x0600105F RID: 4191 RVA: 0x00008D7B File Offset: 0x00006F7B
	// (set) Token: 0x06001060 RID: 4192 RVA: 0x0007090C File Offset: 0x0006EB0C
	public virtual BackgroundWorker bckWorker
	{
		[CompilerGenerated]
		get
		{
			return this.backgroundWorker_0;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			DoWorkEventHandler value2 = new DoWorkEventHandler(this.method_5);
			RunWorkerCompletedEventHandler value3 = new RunWorkerCompletedEventHandler(this.method_6);
			BackgroundWorker backgroundWorker = this.backgroundWorker_0;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
				backgroundWorker.RunWorkerCompleted -= value3;
			}
			this.backgroundWorker_0 = value;
			backgroundWorker = this.backgroundWorker_0;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
				backgroundWorker.RunWorkerCompleted += value3;
			}
		}
	}

	// Token: 0x1700051E RID: 1310
	// (get) Token: 0x06001061 RID: 4193 RVA: 0x00008D83 File Offset: 0x00006F83
	// (set) Token: 0x06001062 RID: 4194 RVA: 0x0007096C File Offset: 0x0006EB6C
	internal virtual ToolStripButton btnOK
	{
		[CompilerGenerated]
		get
		{
			return this._btnOK;
		}
		[CompilerGenerated]
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = new EventHandler(this.method_8);
			ToolStripButton btnOK = this._btnOK;
			if (btnOK != null)
			{
				btnOK.Click -= value2;
			}
			this._btnOK = value;
			btnOK = this._btnOK;
			if (btnOK != null)
			{
				btnOK.Click += value2;
			}
		}
	}

	// Token: 0x06001063 RID: 4195 RVA: 0x000709B0 File Offset: 0x0006EBB0
	private void method_0(string string_2)
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
			if (!this.stsMain.InvokeRequired)
			{
				goto IL_3F;
			}
			IL_19:
			num2 = 3;
			this.stsMain.Invoke(new SocksCheck.Delegate54(this.method_0), new object[]
			{
				string_2
			});
			goto IL_4D;
			IL_3F:
			num2 = 5;
			this.lblStatus.Text = string_2;
			IL_4D:
			goto IL_C0;
			IL_4F:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_79:
			goto IL_B5;
			IL_7B:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_93:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_7B;
		}
		IL_B5:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_C0:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06001064 RID: 4196 RVA: 0x00070A98 File Offset: 0x0006EC98
	private void method_1(int int_2)
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
			if (!this.stsMain.InvokeRequired)
			{
				goto IL_44;
			}
			IL_19:
			num2 = 3;
			this.stsMain.Invoke(new SocksCheck.Delegate53(this.method_1), new object[]
			{
				int_2
			});
			goto IL_52;
			IL_44:
			num2 = 5;
			this.pgbChecker.Value = int_2;
			IL_52:
			goto IL_C5;
			IL_54:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_7E:
			goto IL_BA;
			IL_80:
			num4 = num2;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
			IL_98:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_80;
		}
		IL_BA:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_C5:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	// Token: 0x06001065 RID: 4197 RVA: 0x00070B84 File Offset: 0x0006ED84
	private void method_2(object sender, EventArgs e)
	{
		if (!this.bool_1)
		{
			this.btnStart.Enabled = false;
			this.btnPause.Enabled = true;
			this.btnStop.Enabled = true;
			this.btnOK.Enabled = false;
			this.numThreads.Enabled = false;
			this.numTimeout.Enabled = false;
			this.int_0 = Convert.ToInt32(this.numThreads.Value);
			this.int_1 = Convert.ToInt32(this.numTimeout.Value);
			this.arrayList_3 = new ArrayList();
			this.arrayList_1 = new ArrayList();
			this.arrayList_2 = new ArrayList();
			try
			{
				foreach (object value in this.arrayList_0)
				{
					string value2 = Conversions.ToString(value);
					this.arrayList_3.Add(value2);
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
			this.bckWorker.RunWorkerAsync();
		}
	}

	// Token: 0x06001066 RID: 4198 RVA: 0x00008D8B File Offset: 0x00006F8B
	private void method_3(object sender, EventArgs e)
	{
		this.bool_0 = !this.bool_0;
		this.btnStop.Enabled = !this.bool_0;
	}

	// Token: 0x06001067 RID: 4199 RVA: 0x00008DB0 File Offset: 0x00006FB0
	private void method_4(object sender, EventArgs e)
	{
		if (!this.bckWorker.CancellationPending)
		{
			this.bckWorker.CancelAsync();
		}
		this.btnPause.Enabled = false;
		this.btnStop.Enabled = false;
	}

	// Token: 0x06001068 RID: 4200 RVA: 0x00070C94 File Offset: 0x0006EE94
	private void method_5(object sender, DoWorkEventArgs e)
	{
		checked
		{
			try
			{
				int num = 1;
				int count = this.arrayList_3.Count;
				this.bool_1 = true;
				int maxThreadCount;
				if (this.int_0 > count)
				{
					maxThreadCount = count;
				}
				else
				{
					maxThreadCount = this.int_0;
				}
				this.threadPool_0 = new global::ThreadPool(maxThreadCount);
				try
				{
					foreach (object value in this.arrayList_3)
					{
						string text = Conversions.ToString(value);
						if (!this.bckWorker.CancellationPending)
						{
							if (this.threadPool_0.Status != global::ThreadPool.ThreadStatus.Stopped)
							{
								this.threadPool_0.Paused = true;
								while (this.bool_0)
								{
									Thread.Sleep(500);
								}
								this.threadPool_0.Paused = false;
								lock (this)
								{
									int int_ = (int)Math.Round(Math.Round((double)(100 * num) / (double)count));
									this.method_0(string.Concat(new string[]
									{
										"[",
										Conversions.ToString(num),
										"/",
										Conversions.ToString(count),
										"] Checking, checked: ",
										Conversions.ToString(this.arrayList_1.Count)
									}));
									this.method_1(int_);
								}
								Thread thread = new Thread(new ParameterizedThreadStart(this.method_9));
								thread.Name = "Pos : " + num.ToString();
								thread.Start(new SocksCheck.Class53(num)
								{
									thread_0 = thread,
									string_0 = text
								});
								this.threadPool_0.Open(thread);
								this.threadPool_0.WaitForThreads();
								num++;
								continue;
							}
						}
						else
						{
							this.threadPool_0.AbortThreads();
						}
						break;
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
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				this.threadPool_0.AllJobsPushed();
				for (;;)
				{
					this.method_0("[" + Conversions.ToString(this.threadPool_0.ThreadCount) + "] Finishing, checked: " + Conversions.ToString(this.arrayList_1.Count));
					if (this.bckWorker.CancellationPending)
					{
						break;
					}
					if (this.threadPool_0.Finished)
					{
						goto IL_24C;
					}
				}
				this.threadPool_0.AbortThreads();
				IL_24C:;
			}
		}
	}

	// Token: 0x06001069 RID: 4201 RVA: 0x00070F54 File Offset: 0x0006F154
	private void method_6(object sender, RunWorkerCompletedEventArgs e)
	{
		try
		{
			this.btnStart.Enabled = true;
			this.btnPause.Enabled = false;
			this.btnStop.Enabled = false;
			this.btnOK.Enabled = true;
			this.numThreads.Enabled = true;
			this.numTimeout.Enabled = true;
			this.pgbChecker.Value = 0;
			this.bool_1 = false;
			this.method_0("Done, Checked: " + Conversions.ToString(this.arrayList_1.Count));
		}
		catch (Exception ex)
		{
			Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
		}
	}

	// Token: 0x0600106A RID: 4202 RVA: 0x0007100C File Offset: 0x0006F20C
	private void method_7(SocksCheck.Class53 class53_0)
	{
		try
		{
			using (Http http = new Http())
			{
				http.UserAgent = this.string_0;
				http.Accept = this.string_1;
				string[] array = class53_0.string_0.Split(new char[]
				{
					'|'
				});
				if (array.Length > 1)
				{
					int num = Conversions.ToInteger(array[2]);
					if (num == 0)
					{
						http.ProxyDomain = array[0];
						http.ProxyPort = Conversions.ToInteger(array[1]);
						if (array.Length == 5)
						{
							http.ProxyLogin = array[3];
							http.ProxyPassword = array[4];
						}
					}
					else
					{
						http.SocksVersion = num;
						http.SocksHostname = array[0];
						http.SocksPort = Conversions.ToInteger(array[1]);
						if (array.Length == 5)
						{
							http.SocksUsername = array[3];
							http.SocksPassword = array[4];
						}
					}
					http.ConnectTimeout = this.int_1;
					http.ReadTimeout = this.int_1;
					string text = http.QuickGetStr("http://www.google.com/");
					if (!string.IsNullOrEmpty(text) && text.Length > 10)
					{
						bool flag = http.LastStatus == 200;
					}
				}
			}
		}
		catch (Exception ex)
		{
			if (ex is ThreadAbortException)
			{
			}
		}
		finally
		{
			try
			{
				bool flag;
				if (flag)
				{
					this.arrayList_1.Add(class53_0.string_0);
				}
				else
				{
					this.arrayList_2.Add(class53_0.string_0);
				}
			}
			catch (Exception ex2)
			{
			}
			try
			{
				this.threadPool_0.Close(class53_0.thread_0);
			}
			catch (Exception ex3)
			{
			}
		}
	}

	// Token: 0x0600106B RID: 4203 RVA: 0x00003402 File Offset: 0x00001602
	private void method_8(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		base.Close();
	}

	// Token: 0x0600106C RID: 4204 RVA: 0x00008DE5 File Offset: 0x00006FE5
	private void SocksCheck_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (this.bool_1)
		{
			e.Cancel = true;
			Interaction.Beep();
		}
		else
		{
			Class50.smethod_3(this, null);
		}
	}

	// Token: 0x0600106D RID: 4205 RVA: 0x00071224 File Offset: 0x0006F424
	private void SocksCheck_Load(object sender, EventArgs e)
	{
		this.numThreads.Maximum = new decimal(this.arrayList_0.Count);
		if (decimal.Compare(this.numThreads.Maximum, 300m) > 0)
		{
			this.numThreads.Maximum = 300m;
		}
		this.numTimeout.Focus();
		Class50.smethod_2(this, null);
	}

	// Token: 0x0600106E RID: 4206 RVA: 0x00008E04 File Offset: 0x00007004
	[DebuggerHidden]
	[CompilerGenerated]
	private void method_9(object object_0)
	{
		this.method_7((SocksCheck.Class53)object_0);
	}

	// Token: 0x04000815 RID: 2069
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bckWorker")]
	[CompilerGenerated]
	private BackgroundWorker backgroundWorker_0;

	// Token: 0x04000817 RID: 2071
	internal ArrayList arrayList_0;

	// Token: 0x04000818 RID: 2072
	internal ArrayList arrayList_1;

	// Token: 0x04000819 RID: 2073
	internal ArrayList arrayList_2;

	// Token: 0x0400081A RID: 2074
	private ArrayList arrayList_3;

	// Token: 0x0400081B RID: 2075
	private bool bool_0;

	// Token: 0x0400081C RID: 2076
	private global::ThreadPool threadPool_0;

	// Token: 0x0400081D RID: 2077
	private bool bool_1;

	// Token: 0x0400081E RID: 2078
	private int int_0;

	// Token: 0x0400081F RID: 2079
	private int int_1;

	// Token: 0x04000820 RID: 2080
	private string string_0;

	// Token: 0x04000821 RID: 2081
	private string string_1;

	// Token: 0x020000ED RID: 237
	// (Invoke) Token: 0x06001072 RID: 4210
	private delegate void Delegate53(int iValue);

	// Token: 0x020000EE RID: 238
	// (Invoke) Token: 0x06001076 RID: 4214
	private delegate void Delegate54(string sMessage);

	// Token: 0x020000EF RID: 239
	private sealed class Class53
	{
		// Token: 0x06001077 RID: 4215 RVA: 0x00008E12 File Offset: 0x00007012
		public Class53(int int_1)
		{
			int_1 = int_1;
		}

		// Token: 0x04000822 RID: 2082
		internal int int_0;

		// Token: 0x04000823 RID: 2083
		internal Thread thread_0;

		// Token: 0x04000824 RID: 2084
		internal string string_0;
	}
}
