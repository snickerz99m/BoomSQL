using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x020000C6 RID: 198
public class DataGP
{
	// Token: 0x06000B70 RID: 2928 RVA: 0x00006C15 File Offset: 0x00004E15
	public DataGP(MemoryStream ms, ImageList img = null)
	{
		this._MemoryStream = ms;
		if (img == null)
		{
			img = global::Globals.GMain.imgData;
		}
		this.imageList_0 = img;
	}

	// Token: 0x06000B71 RID: 2929 RVA: 0x000466E8 File Offset: 0x000448E8
	public DataGP(string FileLocation, ImageList oImagelist = null)
	{
		if (File.Exists(FileLocation))
		{
			FileStream fileStream = new FileStream(FileLocation, FileMode.Open, FileAccess.Read);
			this._MemoryStream = new MemoryStream();
			byte[] array = new byte[257];
			while (fileStream.Read(array, 0, array.Length) != 0)
			{
				this._MemoryStream.Write(array, 0, array.Length);
			}
			fileStream.Close();
		}
		this.imageList_0 = oImagelist;
	}

	// Token: 0x06000B72 RID: 2930 RVA: 0x00046754 File Offset: 0x00044954
	public static List<string> EnumerateCountry()
	{
		List<string> list = new List<string>();
		checked
		{
			int num = global::Globals.CountryName.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				list.Add("[" + global::Globals.CountryCode[i] + "] " + global::Globals.CountryName[i]);
			}
			return list;
		}
	}

	// Token: 0x06000B73 RID: 2931 RVA: 0x000467A4 File Offset: 0x000449A4
	public void Lookup(string sIP, ref string sCountry, ref Image oImage = null, ref string sCountryCode = "", bool bUnionContryCode = false)
	{
		try
		{
			sCountryCode = this.LookupCountryCode(sIP);
			if (bUnionContryCode)
			{
				sCountry = "[" + sCountryCode + "] " + this.LookupCountryName(sIP);
			}
			else
			{
				sCountry = this.LookupCountryName(sIP);
			}
			oImage = this.GetFlag(sCountryCode);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000B74 RID: 2932 RVA: 0x00046814 File Offset: 0x00044A14
	public string LookupCountry(string sIP)
	{
		return "[" + this.LookupCountryCode(sIP) + "] " + this.LookupCountryName(sIP);
	}

	// Token: 0x06000B75 RID: 2933 RVA: 0x00046840 File Offset: 0x00044A40
	public Image GetFlag(string sContryCode)
	{
		Image result;
		if (this.method_2(sContryCode))
		{
			result = this.imageList_0.Images[this.LookupCountryCode(sContryCode).ToLower() + ".png"];
		}
		else
		{
			result = this.imageList_0.Images[sContryCode.ToLower() + ".png"];
		}
		return result;
	}

	// Token: 0x06000B76 RID: 2934 RVA: 0x000468A4 File Offset: 0x00044AA4
	private long method_0(IPAddress ipaddress_0)
	{
		string[] array = Strings.Split(ipaddress_0.ToString(), ".", -1, CompareMethod.Binary);
		long result;
		if (Information.UBound(array, 1) == 3)
		{
			result = checked((long)Math.Round(unchecked(16777216.0 * Conversions.ToDouble(array[0]) + 65536.0 * Conversions.ToDouble(array[1]) + 256.0 * Conversions.ToDouble(array[2]) + Conversions.ToDouble(array[3]))));
		}
		else
		{
			result = 0L;
		}
		return result;
	}

	// Token: 0x06000B77 RID: 2935 RVA: 0x00046920 File Offset: 0x00044B20
	private string method_1(long long_0)
	{
		string text = Conversions.ToString(Conversion.Int((double)long_0 / 16777216.0) % 256.0);
		string text2 = Conversions.ToString(Conversion.Int((double)long_0 / 65536.0) % 256.0);
		string text3 = Conversions.ToString(Conversion.Int((double)long_0 / 256.0) % 256.0);
		string text4 = Conversions.ToString(Conversion.Int(long_0) % 256L);
		return string.Concat(new string[]
		{
			text,
			".",
			text2,
			".",
			text3,
			".",
			text4
		});
	}

	// Token: 0x06000B78 RID: 2936 RVA: 0x000469DC File Offset: 0x00044BDC
	private bool method_2(string string_0)
	{
		string pattern = "\\b(?:\\d{1,3}\\.){3}\\d{1,3}\\b";
		Regex regex = new Regex(pattern, RegexOptions.None);
		Match match = regex.Match(string_0);
		return match.Success;
	}

	// Token: 0x06000B79 RID: 2937 RVA: 0x00046A08 File Offset: 0x00044C08
	public static MemoryStream FileToMemory(string FileLocation)
	{
		FileStream fileStream = new FileStream(FileLocation, FileMode.Open, FileAccess.Read);
		MemoryStream memoryStream = new MemoryStream();
		byte[] array = new byte[257];
		while (fileStream.Read(array, 0, array.Length) != 0)
		{
			memoryStream.Write(array, 0, array.Length);
		}
		fileStream.Close();
		return memoryStream;
	}

	// Token: 0x06000B7A RID: 2938 RVA: 0x00046A58 File Offset: 0x00044C58
	public string LookupCountryCode(IPAddress _IPAddress)
	{
		return global::Globals.CountryCode[checked((int)this.method_5(0L, this.method_0(_IPAddress), 31))];
	}

	// Token: 0x06000B7B RID: 2939 RVA: 0x00046A80 File Offset: 0x00044C80
	public bool CountryCodeExist(string sCode)
	{
		bool result;
		foreach (string text in global::Globals.CountryCode)
		{
			if (text.ToLower().Equals(sCode.ToLower()))
			{
				result = true;
				return result;
			}
		}
		return result;
	}

	// Token: 0x06000B7C RID: 2940 RVA: 0x00046AC0 File Offset: 0x00044CC0
	public string CountryNameByCode(string sCode)
	{
		checked
		{
			int num = global::Globals.CountryCode.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				if (global::Globals.CountryCode[i].ToLower().Equals(sCode.ToLower()))
				{
					return "[" + global::Globals.CountryCode[i] + "] " + global::Globals.CountryName[i];
				}
			}
			return "";
		}
	}

	// Token: 0x06000B7D RID: 2941 RVA: 0x00046B24 File Offset: 0x00044D24
	public string LookupCountryCode(string _IPAddress)
	{
		string result;
		try
		{
			if (!this.method_2(_IPAddress))
			{
				result = "--";
			}
			else
			{
				IPAddress ipaddress = IPAddress.Parse(_IPAddress);
				result = this.LookupCountryCode(ipaddress);
			}
		}
		catch (FormatException ex)
		{
			result = "--";
		}
		return result;
	}

	// Token: 0x06000B7E RID: 2942 RVA: 0x00046B7C File Offset: 0x00044D7C
	public string LookupCountryName(IPAddress addr)
	{
		return global::Globals.CountryName[checked((int)this.method_5(0L, this.method_0(addr), 31))];
	}

	// Token: 0x06000B7F RID: 2943 RVA: 0x00046BA4 File Offset: 0x00044DA4
	public string LookupCountryName(string _IPAddress)
	{
		IPAddress addr;
		try
		{
			addr = IPAddress.Parse(_IPAddress);
		}
		catch (FormatException ex)
		{
			return "N/A";
		}
		return this.LookupCountryName(addr);
	}

	// Token: 0x06000B80 RID: 2944 RVA: 0x00046BE8 File Offset: 0x00044DE8
	private long method_3(long long_0, int int_0)
	{
		long num = long_0;
		checked
		{
			for (int i = 1; i <= int_0; i++)
			{
				num *= 2L;
			}
			return num;
		}
	}

	// Token: 0x06000B81 RID: 2945 RVA: 0x00046C0C File Offset: 0x00044E0C
	private long method_4(long long_0, int int_0)
	{
		long num = long_0;
		checked
		{
			for (int i = 1; i <= int_0; i++)
			{
				num /= 2L;
			}
			return num;
		}
	}

	// Token: 0x06000B82 RID: 2946 RVA: 0x00046C30 File Offset: 0x00044E30
	private long method_5(long long_0, long long_1, int int_0)
	{
		if (this._MemoryStream == null)
		{
			return 0L;
		}
		byte[] array = new byte[7];
		long[] array2 = new long[3];
		if (int_0 != 0)
		{
		}
		checked
		{
			try
			{
				this._MemoryStream.Seek(6L * long_0, SeekOrigin.Begin);
				this._MemoryStream.Read(array, 0, 6);
			}
			catch (IOException ex)
			{
			}
			int num = 0;
			array2[num] = 0L;
			int num2 = 0;
			do
			{
				int num3 = (int)array[num * 3 + num2];
				if (num3 < 0)
				{
					num3 += 256;
				}
				long[] array3 = array2;
				int num4 = num;
				ref long ptr = ref array3[num4];
				array3[num4] = ptr + this.method_3(unchecked((long)num3), num2 * 8);
				num2++;
			}
			while (num2 <= 2);
			num++;
			return 0L;
		}
	}

	// Token: 0x04000598 RID: 1432
	public MemoryStream _MemoryStream;

	// Token: 0x04000599 RID: 1433
	private ImageList imageList_0;
}
