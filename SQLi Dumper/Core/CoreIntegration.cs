using System;
using System.Collections.Generic;
using System.Linq;
using DataBase;
using SQLi_Dumper.Core;

namespace SQLi_Dumper.Core
{
    /// <summary>
    /// Integration helper class to bridge new Core functionality with existing analyzer
    /// Provides backward compatibility while enabling new enhanced features
    /// </summary>
    public static class CoreIntegration
    {
        /// <summary>
        /// Convert legacy Types enum to new ExtendedTypes
        /// </summary>
        /// <param name="legacyType">Legacy database type</param>
        /// <returns>Extended database type</returns>
        public static DbTypes.ExtendedTypes ConvertLegacyType(Types legacyType)
        {
            return (DbTypes.ExtendedTypes)((int)legacyType);
        }

        /// <summary>
        /// Convert extended type back to legacy Types enum
        /// </summary>
        /// <param name="extendedType">Extended database type</param>
        /// <returns>Legacy database type</returns>
        public static Types ConvertToLegacyType(DbTypes.ExtendedTypes extendedType)
        {
            int typeValue = (int)extendedType;
            if (typeValue <= 15) // Only return legacy types
            {
                return (Types)typeValue;
            }
            return Types.Unknown;
        }

        /// <summary>
        /// Get enhanced error detection for existing analyzer
        /// </summary>
        /// <param name="response">HTTP response content</param>
        /// <returns>Detected database type or Unknown</returns>
        public static Types DetectDatabaseFromResponse(string response)
        {
            if (string.IsNullOrEmpty(response))
                return Types.Unknown;

            var signatures = ErrorSignatures.DetectDatabaseFromError(response);
            if (signatures.Count == 0)
                return Types.Unknown;

            // Get the first detected database family
            var detectedFamily = signatures[0].Database;
            
            // Map database families to legacy Types enum
            switch (detectedFamily)
            {
                case DbTypes.DatabaseFamily.MySQL:
                    return Types.MySQL_Unknown;
                case DbTypes.DatabaseFamily.MSSQL:
                    return Types.MSSQL_Unknown;
                case DbTypes.DatabaseFamily.Oracle:
                    return Types.Oracle_Unknown;
                case DbTypes.DatabaseFamily.PostgreSQL:
                    return Types.PostgreSQL_Unknown;
                case DbTypes.DatabaseFamily.SQLite:
                    return Types.SQLite_Unknown;
                case DbTypes.DatabaseFamily.MongoDB:
                    return Types.MongoDB_Unknown;
                case DbTypes.DatabaseFamily.DB2:
                    return Types.DB2_Unknown;
                case DbTypes.DatabaseFamily.Firebird:
                    return Types.Firebird_Unknown;
                case DbTypes.DatabaseFamily.Informix:
                    return Types.Informix_Unknown;
                case DbTypes.DatabaseFamily.MariaDB:
                    return Types.MariaDB_Unknown;
                case DbTypes.DatabaseFamily.Sybase:
                    return Types.Sybase;
                case DbTypes.DatabaseFamily.MsAccess:
                    return Types.MsAccess;
                default:
                    return Types.Unknown;
            }
        }

        /// <summary>
        /// Get enhanced payloads for existing analyzer
        /// </summary>
        /// <param name="dbType">Database type</param>
        /// <param name="category">Payload category</param>
        /// <returns>List of payload strings</returns>
        public static List<string> GetPayloadsForAnalyzer(Types dbType, Payloads.PayloadCategory category)
        {
            var databaseFamily = GetDatabaseFamily(dbType);
            if (databaseFamily == DbTypes.DatabaseFamily.Unknown)
                return new List<string>();

            return Payloads.GetPayloads(category, databaseFamily)
                          .SelectMany(p => new[] { p.PayloadString }.Concat(p.Variations))
                          .ToList();
        }

        /// <summary>
        /// Get error-based payloads for existing analyzer
        /// </summary>
        /// <param name="dbType">Database type</param>
        /// <returns>List of error-based payload strings</returns>
        public static List<string> GetErrorBasedPayloads(Types dbType)
        {
            return GetPayloadsForAnalyzer(dbType, Payloads.PayloadCategory.Error_Based);
        }

        /// <summary>
        /// Get union-based payloads for existing analyzer
        /// </summary>
        /// <param name="dbType">Database type</param>
        /// <returns>List of union-based payload strings</returns>
        public static List<string> GetUnionBasedPayloads(Types dbType)
        {
            return GetPayloadsForAnalyzer(dbType, Payloads.PayloadCategory.Union_Based);
        }

        /// <summary>
        /// Get time-based payloads for existing analyzer
        /// </summary>
        /// <param name="dbType">Database type</param>
        /// <returns>List of time-based payload strings</returns>
        public static List<string> GetTimeBasedPayloads(Types dbType)
        {
            return GetPayloadsForAnalyzer(dbType, Payloads.PayloadCategory.Time_Based);
        }

        /// <summary>
        /// Get boolean-based payloads for existing analyzer
        /// </summary>
        /// <param name="dbType">Database type</param>
        /// <returns>List of boolean-based payload strings</returns>
        public static List<string> GetBooleanBasedPayloads(Types dbType)
        {
            return GetPayloadsForAnalyzer(dbType, Payloads.PayloadCategory.Boolean_Based);
        }

        /// <summary>
        /// Apply WAF bypass techniques to payload
        /// </summary>
        /// <param name="payload">Original payload</param>
        /// <param name="dbType">Database type</param>
        /// <param name="maxVariations">Maximum number of variations to return</param>
        /// <returns>List of bypass variations</returns>
        public static List<string> ApplyWAFBypass(string payload, Types dbType, int maxVariations = 10)
        {
            var databaseFamily = GetDatabaseFamily(dbType);
            if (databaseFamily == DbTypes.DatabaseFamily.Unknown)
                return new List<string> { payload };

            return WAFBypass.GenerateBypassVariations(payload, databaseFamily, maxVariations);
        }

        /// <summary>
        /// Check if database type supports specific detection method
        /// </summary>
        /// <param name="dbType">Database type</param>
        /// <param name="method">Detection method</param>
        /// <returns>True if supported</returns>
        public static bool SupportsDetectionMethod(Types dbType, DetectionMethods.DetectionType method)
        {
            var extendedType = ConvertLegacyType(dbType);
            return DbTypes.SupportsInjectionMethod(extendedType, method.ToString().ToLower().Replace("_", ""));
        }

        /// <summary>
        /// Get enhanced detection methods for database type
        /// </summary>
        /// <param name="dbType">Database type</param>
        /// <returns>List of applicable detection methods</returns>
        public static List<DetectionMethods.DetectionMethod> GetDetectionMethods(Types dbType)
        {
            var databaseFamily = GetDatabaseFamily(dbType);
            if (databaseFamily == DbTypes.DatabaseFamily.Unknown)
                return new List<DetectionMethods.DetectionMethod>();

            return DetectionMethods.GetMethodsForDatabase(databaseFamily);
        }

        /// <summary>
        /// Get all available payloads for database type
        /// </summary>
        /// <param name="dbType">Database type</param>
        /// <returns>List of all applicable payloads</returns>
        public static List<Payloads.Payload> GetAllPayloads(Types dbType)
        {
            var databaseFamily = GetDatabaseFamily(dbType);
            if (databaseFamily == DbTypes.DatabaseFamily.Unknown)
                return new List<Payloads.Payload>();

            return Payloads.GetPayloadsForDatabase(databaseFamily);
        }

        /// <summary>
        /// Get error signatures for database type
        /// </summary>
        /// <param name="dbType">Database type</param>
        /// <returns>List of error signatures</returns>
        public static List<ErrorSignatures.ErrorSignature> GetErrorSignatures(Types dbType)
        {
            var databaseFamily = GetDatabaseFamily(dbType);
            if (databaseFamily == DbTypes.DatabaseFamily.Unknown)
                return new List<ErrorSignatures.ErrorSignature>();

            return ErrorSignatures.GetErrorSignaturesForDatabase(databaseFamily);
        }

        /// <summary>
        /// Check if response contains SQL injection vulnerability indicators
        /// </summary>
        /// <param name="response">HTTP response content</param>
        /// <returns>True if indicators found</returns>
        public static bool ContainsSQLInjectionIndicators(string response)
        {
            return ErrorSignatures.ContainsSQLInjectionIndicators(response);
        }

        /// <summary>
        /// Get database family from legacy Types enum
        /// </summary>
        /// <param name="dbType">Database type</param>
        /// <returns>Database family</returns>
        private static DbTypes.DatabaseFamily GetDatabaseFamily(Types dbType)
        {
            switch (dbType)
            {
                case Types.MySQL_Unknown:
                case Types.MySQL_No_Error:
                case Types.MySQL_With_Error:
                    return DbTypes.DatabaseFamily.MySQL;
                
                case Types.MSSQL_Unknown:
                case Types.MSSQL_No_Error:
                case Types.MSSQL_With_Error:
                    return DbTypes.DatabaseFamily.MSSQL;
                
                case Types.Oracle_Unknown:
                case Types.Oracle_No_Error:
                case Types.Oracle_With_Error:
                    return DbTypes.DatabaseFamily.Oracle;
                
                case Types.PostgreSQL_Unknown:
                case Types.PostgreSQL_No_Error:
                case Types.PostgreSQL_With_Error:
                    return DbTypes.DatabaseFamily.PostgreSQL;
                
                case Types.SQLite_Unknown:
                case Types.SQLite_No_Error:
                case Types.SQLite_With_Error:
                    return DbTypes.DatabaseFamily.SQLite;
                
                case Types.MongoDB_Unknown:
                case Types.MongoDB_No_Error:
                case Types.MongoDB_With_Error:
                    return DbTypes.DatabaseFamily.MongoDB;
                
                case Types.DB2_Unknown:
                case Types.DB2_No_Error:
                case Types.DB2_With_Error:
                    return DbTypes.DatabaseFamily.DB2;
                
                case Types.Firebird_Unknown:
                case Types.Firebird_No_Error:
                case Types.Firebird_With_Error:
                    return DbTypes.DatabaseFamily.Firebird;
                
                case Types.Informix_Unknown:
                case Types.Informix_No_Error:
                case Types.Informix_With_Error:
                    return DbTypes.DatabaseFamily.Informix;
                
                case Types.MariaDB_Unknown:
                case Types.MariaDB_No_Error:
                case Types.MariaDB_With_Error:
                    return DbTypes.DatabaseFamily.MariaDB;
                
                case Types.MsAccess:
                    return DbTypes.DatabaseFamily.MsAccess;
                
                case Types.Sybase:
                    return DbTypes.DatabaseFamily.Sybase;
                
                default:
                    return DbTypes.DatabaseFamily.Unknown;
            }
        }

        /// <summary>
        /// Get friendly name for database type
        /// </summary>
        /// <param name="dbType">Database type</param>
        /// <returns>Friendly name</returns>
        public static string GetFriendlyName(Types dbType)
        {
            var extendedType = ConvertLegacyType(dbType);
            return DbTypes.GetFriendlyName(extendedType);
        }

        /// <summary>
        /// Initialize Core modules (called during application startup)
        /// </summary>
        public static void Initialize()
        {
            // Initialize Core modules
            // This ensures all static collections are loaded
            var _ = Payloads.AllPayloads.Count;
            var __ = ErrorSignatures.AllErrorSignatures.Count;
            var ___ = DetectionMethods.Methods.Count;
            var ____ = WAFBypass.BypassTechniques.Count;
        }

        /// <summary>
        /// Get statistics about loaded Core modules
        /// </summary>
        /// <returns>Dictionary with module statistics</returns>
        public static Dictionary<string, int> GetCoreStatistics()
        {
            return new Dictionary<string, int>
            {
                ["Payloads"] = Payloads.AllPayloads.Count,
                ["ErrorSignatures"] = ErrorSignatures.AllErrorSignatures.Count,
                ["DetectionMethods"] = DetectionMethods.Methods.Count,
                ["WAFBypassTechniques"] = WAFBypass.BypassTechniques.Count,
                ["SupportedDatabases"] = Enum.GetValues(typeof(DbTypes.DatabaseFamily)).Length - 1 // Exclude Unknown
            };
        }
    }
}