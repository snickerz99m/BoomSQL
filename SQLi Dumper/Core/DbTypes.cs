using System;
using System.Collections.Generic;
using DataBase;

namespace SQLi_Dumper.Core
{
    /// <summary>
    /// Extended database types and related utilities for comprehensive DBMS support
    /// </summary>
    public static class DbTypes
    {
        /// <summary>
        /// Extended database type enumeration including new database systems
        /// </summary>
        public enum ExtendedTypes
        {
            // Existing types from DataBase.Types
            None = 0,
            Unknown = 1,
            MySQL_Unknown = 2,
            MySQL_No_Error = 3,
            MySQL_With_Error = 4,
            MSSQL_Unknown = 5,
            MSSQL_No_Error = 6,
            MSSQL_With_Error = 7,
            Oracle_Unknown = 8,
            Oracle_No_Error = 9,
            Oracle_With_Error = 10,
            PostgreSQL_Unknown = 11,
            PostgreSQL_No_Error = 12,
            PostgreSQL_With_Error = 13,
            MsAccess = 14,
            Sybase = 15,
            
            // New database types
            SQLite_Unknown = 16,
            SQLite_No_Error = 17,
            SQLite_With_Error = 18,
            MongoDB_Unknown = 19,
            MongoDB_No_Error = 20,
            MongoDB_With_Error = 21,
            DB2_Unknown = 22,
            DB2_No_Error = 23,
            DB2_With_Error = 24,
            Firebird_Unknown = 25,
            Firebird_No_Error = 26,
            Firebird_With_Error = 27,
            Informix_Unknown = 28,
            Informix_No_Error = 29,
            Informix_With_Error = 30,
            MariaDB_Unknown = 31,
            MariaDB_No_Error = 32,
            MariaDB_With_Error = 33
        }

        /// <summary>
        /// Database family groupings for easier classification
        /// </summary>
        public enum DatabaseFamily
        {
            Unknown,
            MySQL,
            MSSQL,
            Oracle,
            PostgreSQL,
            SQLite,
            MongoDB,
            DB2,
            Firebird,
            Informix,
            MariaDB,
            MsAccess,
            Sybase
        }

        /// <summary>
        /// Database identification patterns for detection
        /// </summary>
        public static readonly Dictionary<DatabaseFamily, string[]> DatabaseSignatures = new Dictionary<DatabaseFamily, string[]>
        {
            [DatabaseFamily.MySQL] = new string[]
            {
                "mysql", "MariaDB", "MySQL", "maria", "percona", "@@version_comment",
                "version()", "connection_id()", "database()", "user()", "current_user()",
                "information_schema.tables", "information_schema.columns"
            },
            [DatabaseFamily.MSSQL] = new string[]
            {
                "Microsoft SQL Server", "MSSQL", "@@version", "@@servername", "@@microsoftversion",
                "sys.databases", "sys.tables", "sys.columns", "master.dbo.sysdatabases",
                "OPENROWSET", "xp_cmdshell"
            },
            [DatabaseFamily.Oracle] = new string[]
            {
                "Oracle", "ORA-", "dual", "v$version", "all_tables", "all_tab_columns",
                "user_tables", "user_tab_columns", "sys.user_objects", "rownum",
                "sysdate", "systimestamp"
            },
            [DatabaseFamily.PostgreSQL] = new string[]
            {
                "PostgreSQL", "postgres", "pg_", "version()", "current_database()",
                "current_user", "pg_tables", "information_schema.tables",
                "pg_class", "pg_namespace"
            },
            [DatabaseFamily.SQLite] = new string[]
            {
                "SQLite", "sqlite_", "sqlite_master", "sqlite_version()",
                "pragma", "PRAGMA", "sqlite_temp_master"
            },
            [DatabaseFamily.MongoDB] = new string[]
            {
                "MongoDB", "mongo", "db.", "ObjectId", "ISODate", "NumberLong",
                "find()", "aggregate()", "mapReduce", "$where", "eval("
            },
            [DatabaseFamily.DB2] = new string[]
            {
                "DB2", "IBM", "SYSIBM", "SYSCAT", "SYSSTAT", "VALUES",
                "CURRENT TIMESTAMP", "CURRENT USER", "CURRENT SCHEMA"
            },
            [DatabaseFamily.Firebird] = new string[]
            {
                "Firebird", "InterBase", "RDB$", "CURRENT_TIMESTAMP", "CURRENT_USER",
                "CURRENT_CONNECTION", "CURRENT_TRANSACTION"
            },
            [DatabaseFamily.Informix] = new string[]
            {
                "Informix", "IBM Informix", "SYSTABLES", "SYSCOLUMNS", "SYSMASTER",
                "CURRENT", "TODAY", "DBSERVERNAME"
            },
            [DatabaseFamily.MariaDB] = new string[]
            {
                "MariaDB", "maria", "@@version_comment", "version()", "connection_id()",
                "information_schema.tables", "performance_schema"
            },
            [DatabaseFamily.MsAccess] = new string[]
            {
                "Microsoft Access", "MSysObjects", "MSysQueries", "MSysRelationships",
                "Jet", "ACE", "OLEDB"
            },
            [DatabaseFamily.Sybase] = new string[]
            {
                "Sybase", "ASE", "@@version", "@@servername", "sysdatabases",
                "systables", "syscolumns", "sysprocesses"
            }
        };

        /// <summary>
        /// Default ports for database systems
        /// </summary>
        public static readonly Dictionary<DatabaseFamily, int[]> DefaultPorts = new Dictionary<DatabaseFamily, int[]>
        {
            [DatabaseFamily.MySQL] = new int[] { 3306 },
            [DatabaseFamily.MariaDB] = new int[] { 3306 },
            [DatabaseFamily.MSSQL] = new int[] { 1433, 1434 },
            [DatabaseFamily.Oracle] = new int[] { 1521, 1522 },
            [DatabaseFamily.PostgreSQL] = new int[] { 5432 },
            [DatabaseFamily.MongoDB] = new int[] { 27017, 27018, 27019 },
            [DatabaseFamily.DB2] = new int[] { 50000, 50001 },
            [DatabaseFamily.Firebird] = new int[] { 3050 },
            [DatabaseFamily.Informix] = new int[] { 9088, 9089 },
            [DatabaseFamily.Sybase] = new int[] { 5000, 5001 }
        };

        /// <summary>
        /// Convert legacy Types enum to ExtendedTypes
        /// </summary>
        /// <param name="legacyType">Legacy database type</param>
        /// <returns>Extended database type</returns>
        public static ExtendedTypes ConvertLegacyType(Types legacyType)
        {
            return (ExtendedTypes)((int)legacyType);
        }

        /// <summary>
        /// Convert ExtendedTypes to legacy Types enum
        /// </summary>
        /// <param name="extendedType">Extended database type</param>
        /// <returns>Legacy database type</returns>
        public static Types ConvertToLegacyType(ExtendedTypes extendedType)
        {
            int typeValue = (int)extendedType;
            if (typeValue <= 15) // Only return legacy types
            {
                return (Types)typeValue;
            }
            return Types.Unknown;
        }

        /// <summary>
        /// Get database family from extended type
        /// </summary>
        /// <param name="dbType">Database type</param>
        /// <returns>Database family</returns>
        public static DatabaseFamily GetDatabaseFamily(ExtendedTypes dbType)
        {
            switch (dbType)
            {
                case ExtendedTypes.MySQL_Unknown:
                case ExtendedTypes.MySQL_No_Error:
                case ExtendedTypes.MySQL_With_Error:
                    return DatabaseFamily.MySQL;
                
                case ExtendedTypes.MSSQL_Unknown:
                case ExtendedTypes.MSSQL_No_Error:
                case ExtendedTypes.MSSQL_With_Error:
                    return DatabaseFamily.MSSQL;
                
                case ExtendedTypes.Oracle_Unknown:
                case ExtendedTypes.Oracle_No_Error:
                case ExtendedTypes.Oracle_With_Error:
                    return DatabaseFamily.Oracle;
                
                case ExtendedTypes.PostgreSQL_Unknown:
                case ExtendedTypes.PostgreSQL_No_Error:
                case ExtendedTypes.PostgreSQL_With_Error:
                    return DatabaseFamily.PostgreSQL;
                
                case ExtendedTypes.SQLite_Unknown:
                case ExtendedTypes.SQLite_No_Error:
                case ExtendedTypes.SQLite_With_Error:
                    return DatabaseFamily.SQLite;
                
                case ExtendedTypes.MongoDB_Unknown:
                case ExtendedTypes.MongoDB_No_Error:
                case ExtendedTypes.MongoDB_With_Error:
                    return DatabaseFamily.MongoDB;
                
                case ExtendedTypes.DB2_Unknown:
                case ExtendedTypes.DB2_No_Error:
                case ExtendedTypes.DB2_With_Error:
                    return DatabaseFamily.DB2;
                
                case ExtendedTypes.Firebird_Unknown:
                case ExtendedTypes.Firebird_No_Error:
                case ExtendedTypes.Firebird_With_Error:
                    return DatabaseFamily.Firebird;
                
                case ExtendedTypes.Informix_Unknown:
                case ExtendedTypes.Informix_No_Error:
                case ExtendedTypes.Informix_With_Error:
                    return DatabaseFamily.Informix;
                
                case ExtendedTypes.MariaDB_Unknown:
                case ExtendedTypes.MariaDB_No_Error:
                case ExtendedTypes.MariaDB_With_Error:
                    return DatabaseFamily.MariaDB;
                
                case ExtendedTypes.MsAccess:
                    return DatabaseFamily.MsAccess;
                
                case ExtendedTypes.Sybase:
                    return DatabaseFamily.Sybase;
                
                default:
                    return DatabaseFamily.Unknown;
            }
        }

        /// <summary>
        /// Check if database type supports specific injection method
        /// </summary>
        /// <param name="dbType">Database type</param>
        /// <param name="method">Injection method</param>
        /// <returns>True if supported</returns>
        public static bool SupportsInjectionMethod(ExtendedTypes dbType, string method)
        {
            DatabaseFamily family = GetDatabaseFamily(dbType);
            
            switch (method.ToLower())
            {
                case "union":
                    return family != DatabaseFamily.MongoDB; // Most SQL databases support UNION
                
                case "boolean":
                    return true; // All databases support boolean-based
                
                case "time":
                    return true; // All databases support time-based
                
                case "error":
                    return family != DatabaseFamily.MongoDB; // NoSQL typically doesn't have SQL errors
                
                case "stacked":
                    return family == DatabaseFamily.MSSQL || family == DatabaseFamily.PostgreSQL ||
                           family == DatabaseFamily.Oracle || family == DatabaseFamily.DB2;
                
                case "outofband":
                    return family == DatabaseFamily.MSSQL || family == DatabaseFamily.Oracle ||
                           family == DatabaseFamily.MySQL || family == DatabaseFamily.MariaDB;
                
                default:
                    return false;
            }
        }

        /// <summary>
        /// Get friendly name for database type
        /// </summary>
        /// <param name="dbType">Database type</param>
        /// <returns>Friendly name</returns>
        public static string GetFriendlyName(ExtendedTypes dbType)
        {
            DatabaseFamily family = GetDatabaseFamily(dbType);
            string errorSuffix = dbType.ToString().Contains("With_Error") ? " (With Error)" : 
                                dbType.ToString().Contains("No_Error") ? " (No Error)" : 
                                dbType.ToString().Contains("Unknown") ? " (Unknown)" : "";
            
            return family.ToString() + errorSuffix;
        }
    }
}