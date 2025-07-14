using System;
using System.Collections;
using System.IO;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ns0
{
	// Token: 0x020000EA RID: 234
	internal sealed class Class51
	{
		// Token: 0x06001029 RID: 4137 RVA: 0x0006F6D0 File Offset: 0x0006D8D0
		public Class51(string string_2, string string_3 = "SQLi_Dumper", char char_1 = ';', int int_0 = 0)
		{
			this.string_1 = string_3.Trim();
			this.char_0 = char_1;
			if (int_0 == 0)
			{
				this.string_0 = string_2;
				this.method_0();
			}
			else
			{
				this.xmlDocument_0 = new XmlDocument();
				this.xmlDocument_0.LoadXml(string_2);
			}
		}

		// Token: 0x0600102A RID: 4138 RVA: 0x00008C6A File Offset: 0x00006E6A
		protected override void Finalize()
		{
			this.xmlDocument_0 = null;
			base.Finalize();
		}

		// Token: 0x0600102B RID: 4139 RVA: 0x0006F724 File Offset: 0x0006D924
		private void method_0()
		{
			try
			{
				if (File.Exists(this.string_0) || this.string_0.ToLower().StartsWith("http"))
				{
					XmlTextReader xmlTextReader = new XmlTextReader(this.string_0);
					this.xmlDocument_0 = new XmlDocument();
					this.xmlDocument_0.Load(xmlTextReader);
					xmlTextReader.Close();
				}
			}
			catch (XmlException ex)
			{
			}
			if (this.xmlDocument_0 == null)
			{
				this.xmlDocument_0 = new XmlDocument();
				this.xmlDocument_0.LoadXml(string.Concat(new string[]
				{
					"<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<",
					this.string_1,
					">\r\n</",
					this.string_1,
					">"
				}));
			}
		}

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x0600102C RID: 4140 RVA: 0x0006F7FC File Offset: 0x0006D9FC
		// (set) Token: 0x0600102D RID: 4141 RVA: 0x00008C79 File Offset: 0x00006E79
		public string String_0
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value.Trim();
			}
		}

		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x0600102E RID: 4142 RVA: 0x0006F814 File Offset: 0x0006DA14
		// (set) Token: 0x0600102F RID: 4143 RVA: 0x00008C87 File Offset: 0x00006E87
		public string String_1
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value.Trim();
			}
		}

		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x06001030 RID: 4144 RVA: 0x0006F82C File Offset: 0x0006DA2C
		// (set) Token: 0x06001031 RID: 4145 RVA: 0x00008C95 File Offset: 0x00006E95
		public char Char_0
		{
			get
			{
				return this.char_0;
			}
			set
			{
				this.char_0 = value;
			}
		}

		// Token: 0x06001032 RID: 4146 RVA: 0x0006F844 File Offset: 0x0006DA44
		internal Hashtable method_1()
		{
			Hashtable hashtable = new Hashtable();
			XmlNodeList xmlNodeList = this.xmlDocument_0.SelectNodes("//Section");
			if (xmlNodeList != null)
			{
				try
				{
					foreach (object obj in xmlNodeList)
					{
						XmlNode xmlNode = (XmlNode)obj;
						hashtable.Add(xmlNode.Attributes["Name"].Value, xmlNode);
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
			return hashtable;
		}

		// Token: 0x06001033 RID: 4147 RVA: 0x0006F8D8 File Offset: 0x0006DAD8
		internal Hashtable method_2(string string_2)
		{
			Hashtable hashtable = new Hashtable();
			string[] array;
			if (Strings.InStr(string_2, Conversions.ToString(this.char_0), CompareMethod.Binary) != 0)
			{
				array = Strings.Split(string_2, Conversions.ToString(this.char_0), -1, CompareMethod.Binary);
			}
			else
			{
				array = new string[]
				{
					string_2
				};
			}
			try
			{
				foreach (string text in array)
				{
					XmlNode xmlNode = this.xmlDocument_0.SelectSingleNode("//Section[@Name='" + text + "']");
					if (xmlNode != null)
					{
						XmlNodeList xmlNodeList = xmlNode.SelectNodes("descendant::Key");
						if (xmlNodeList != null)
						{
							try
							{
								foreach (object obj in xmlNodeList)
								{
									XmlNode xmlNode2 = (XmlNode)obj;
									Class52 @class = new Class52();
									@class.String_0 = xmlNode2.Attributes["Name"].Value;
									@class.String_1 = xmlNode2.Attributes["Value"].Value;
									@class.String_2 = text;
									hashtable.Add(xmlNode2.Attributes["Name"].Value, @class);
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
					}
				}
			}
			catch (Exception ex)
			{
			}
			return hashtable;
		}

		// Token: 0x06001034 RID: 4148 RVA: 0x0006FA74 File Offset: 0x0006DC74
		internal string method_3(string string_2, string string_3, string string_4)
		{
			string text = this.method_4(string_2, string_3);
			string result;
			if (string.IsNullOrEmpty(text))
			{
				result = string_4;
			}
			else
			{
				result = text;
			}
			return result;
		}

		// Token: 0x06001035 RID: 4149 RVA: 0x0006FA9C File Offset: 0x0006DC9C
		internal string method_4(string string_2, string string_3)
		{
			string result = string.Empty;
			XmlNode xmlNode = this.xmlDocument_0.SelectSingleNode("//Section[@Name='" + string_2 + "']");
			if (xmlNode != null)
			{
				XmlNode xmlNode2 = xmlNode.SelectSingleNode("descendant::Key[@Name='" + string_3 + "']");
				if (xmlNode2 != null)
				{
					result = xmlNode2.Attributes["Value"].Value;
				}
			}
			return result;
		}

		// Token: 0x06001036 RID: 4150 RVA: 0x0006FB0C File Offset: 0x0006DD0C
		public string method_5(string string_2, string string_3, string string_4 = "")
		{
			string text = "";
			try
			{
				XmlNodeList elementsByTagName = this.xmlDocument_0.GetElementsByTagName(string_2);
				if (elementsByTagName.Count > 0)
				{
					text = elementsByTagName[0].Attributes[string_3].Value;
					if (Versioned.IsNumeric(text))
					{
						text = Strings.FormatNumber(Conversions.ToDouble(text), 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault).ToString();
					}
				}
				if (string.IsNullOrEmpty(text))
				{
					text = string_4;
				}
			}
			catch (Exception ex)
			{
			}
			return text;
		}

		// Token: 0x06001037 RID: 4151 RVA: 0x0006FBA4 File Offset: 0x0006DDA4
		internal void method_6(string string_2, string string_3, string string_4)
		{
			if (this.xmlDocument_0.DocumentElement == null)
			{
				this.xmlDocument_0.LoadXml(string.Concat(new string[]
				{
					"<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<",
					this.string_1,
					">\r\n</",
					this.string_1,
					">"
				}));
			}
			else
			{
				XmlNode xmlNode = this.xmlDocument_0.SelectSingleNode("//Section[@Name='" + string_2 + "']");
				if (xmlNode == null)
				{
					try
					{
						xmlNode = this.xmlDocument_0.CreateNode(XmlNodeType.Element, "Section", "");
						XmlAttribute xmlAttribute = this.xmlDocument_0.CreateAttribute("Name");
						xmlAttribute.Value = string_2;
						xmlNode.Attributes.SetNamedItem(xmlAttribute);
						XmlNode documentElement = this.xmlDocument_0.DocumentElement;
						documentElement.AppendChild(xmlNode);
					}
					catch (XmlException ex)
					{
					}
				}
				XmlNode xmlNode2 = xmlNode.SelectSingleNode("descendant::Key[@Name='" + string_3 + "']");
				if (xmlNode2 == null)
				{
					try
					{
						xmlNode2 = this.xmlDocument_0.CreateNode(XmlNodeType.Element, "Key", "");
						XmlAttribute xmlAttribute = this.xmlDocument_0.CreateAttribute("Name");
						xmlAttribute.Value = string_3;
						xmlNode2.Attributes.SetNamedItem(xmlAttribute);
						xmlAttribute = this.xmlDocument_0.CreateAttribute("Value");
						xmlAttribute.Value = string_4;
						xmlNode2.Attributes.SetNamedItem(xmlAttribute);
						xmlNode.AppendChild(xmlNode2);
						goto IL_187;
					}
					catch (XmlException ex2)
					{
						goto IL_187;
					}
				}
				xmlNode2.Attributes["Value"].Value = string_4;
				IL_187:
				xmlNode = null;
			}
		}

		// Token: 0x06001038 RID: 4152 RVA: 0x0006FD58 File Offset: 0x0006DF58
		internal void method_7(string string_2, string string_3)
		{
			XmlNode xmlNode = this.xmlDocument_0.SelectSingleNode("//Section[@Name='" + string_2 + "']");
			if (xmlNode != null)
			{
				XmlNode xmlNode2 = xmlNode.SelectSingleNode("descendant::Key[@Name='" + string_3 + "']");
				if (xmlNode2 != null)
				{
					xmlNode.RemoveChild(xmlNode2);
				}
			}
		}

		// Token: 0x06001039 RID: 4153 RVA: 0x0006FDB0 File Offset: 0x0006DFB0
		internal void method_8(string string_2)
		{
			XmlNode xmlNode = this.xmlDocument_0.SelectSingleNode("//Section[@Name='" + string_2 + "']");
			if (xmlNode != null)
			{
				XmlNode documentElement = this.xmlDocument_0.DocumentElement;
				documentElement.RemoveChild(xmlNode);
			}
		}

		// Token: 0x0600103A RID: 4154 RVA: 0x0006FDF8 File Offset: 0x0006DFF8
		internal void method_9(bool bool_0 = true, bool bool_1 = true)
		{
			try
			{
				if (bool_1 && (File.Exists(this.string_0) && bool_0))
				{
					File.Delete(this.string_0);
				}
				this.xmlDocument_0.Save(this.string_0);
			}
			catch (Exception ex)
			{
				try
				{
					File.Delete(this.string_0);
				}
				catch (Exception ex2)
				{
				}
			}
		}

		// Token: 0x04000800 RID: 2048
		private string string_0;

		// Token: 0x04000801 RID: 2049
		private string string_1;

		// Token: 0x04000802 RID: 2050
		private char char_0;

		// Token: 0x04000803 RID: 2051
		private XmlDocument xmlDocument_0;
	}
}
