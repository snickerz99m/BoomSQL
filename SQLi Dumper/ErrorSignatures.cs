using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DataBase;

namespace SQLi_Dumper
{
    /// <summary>
    /// Comprehensive error signature detection system for SQL injection testing
    /// </summary>
    public class ErrorSignatures
    {
        private static ErrorSignatures _instance;
        private readonly Dictionary<Types, List<ErrorSignature>> _errorSignatures;
        private readonly Dictionary<Types, List<Regex>> _compiledRegexes;

        public static ErrorSignatures Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ErrorSignatures();
                return _instance;
            }
        }

        private ErrorSignatures()
        {
            _errorSignatures = new Dictionary<Types, List<ErrorSignature>>();
            _compiledRegexes = new Dictionary<Types, List<Regex>>();
            InitializeErrorSignatures();
            CompileRegexes();
        }

        public class ErrorSignature
        {
            public string Pattern { get; set; }
            public string Description { get; set; }
            public Types DatabaseType { get; set; }
            public int ConfidenceScore { get; set; } // 1-100
            public bool IsRegex { get; set; }
            public bool CaseSensitive { get; set; }

            public ErrorSignature(string pattern, string description, Types dbType, int confidence = 80, bool isRegex = false, bool caseSensitive = false)
            {
                Pattern = pattern;
                Description = description;
                DatabaseType = dbType;
                ConfidenceScore = confidence;
                IsRegex = isRegex;
                CaseSensitive = caseSensitive;
            }
        }

        public class DetectionResult
        {
            public Types DatabaseType { get; set; }
            public int ConfidenceScore { get; set; }
            public List<string> MatchedSignatures { get; set; }
            public string ErrorMessage { get; set; }

            public DetectionResult()
            {
                MatchedSignatures = new List<string>();
            }
        }

        /// <summary>
        /// Analyzes response content for SQL error signatures
        /// </summary>
        public DetectionResult AnalyzeResponse(string response)
        {
            if (string.IsNullOrEmpty(response))
                return new DetectionResult();

            var results = new Dictionary<Types, DetectionResult>();

            // Check each database type
            foreach (var dbType in _errorSignatures.Keys)
            {
                var matches = DetectSignatures(response, dbType);
                if (matches.MatchedSignatures.Count > 0)
                {
                    results[dbType] = matches;
                }
            }

            // Return the result with highest confidence score
            if (results.Count > 0)
            {
                var bestMatch = results.Values.OrderByDescending(r => r.ConfidenceScore).First();
                return bestMatch;
            }

            return new DetectionResult();
        }

        /// <summary>
        /// Detects error signatures for a specific database type
        /// </summary>
        public DetectionResult DetectSignatures(string response, Types dbType)
        {
            var result = new DetectionResult { DatabaseType = dbType };

            if (!_errorSignatures.ContainsKey(dbType))
                return result;

            var signatures = _errorSignatures[dbType];
            var regexes = _compiledRegexes.ContainsKey(dbType) ? _compiledRegexes[dbType] : new List<Regex>();

            int totalConfidence = 0;
            int matchCount = 0;

            foreach (var signature in signatures)
            {
                bool matched = false;

                if (signature.IsRegex)
                {
                    var regex = regexes.FirstOrDefault(r => r.ToString().Contains(signature.Pattern));
                    if (regex != null && regex.IsMatch(response))
                    {
                        matched = true;
                    }
                }
                else
                {
                    var comparison = signature.CaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
                    matched = response.IndexOf(signature.Pattern, comparison) >= 0;
                }

                if (matched)
                {
                    result.MatchedSignatures.Add(signature.Description);
                    totalConfidence += signature.ConfidenceScore;
                    matchCount++;
                }
            }

            if (matchCount > 0)
            {
                result.ConfidenceScore = Math.Min(100, totalConfidence / matchCount);
                result.ErrorMessage = $"Detected {matchCount} signature(s) for {dbType}";
            }

            return result;
        }

        /// <summary>
        /// Adds a custom error signature
        /// </summary>
        public void AddSignature(ErrorSignature signature)
        {
            if (!_errorSignatures.ContainsKey(signature.DatabaseType))
                _errorSignatures[signature.DatabaseType] = new List<ErrorSignature>();

            _errorSignatures[signature.DatabaseType].Add(signature);

            // Recompile regexes for this database type
            CompileRegexesForType(signature.DatabaseType);
        }

        private void InitializeErrorSignatures()
        {
            InitializeMySQLSignatures();
            InitializeMSSQLSignatures();
            InitializeOracleSignatures();
            InitializePostgreSQLSignatures();
            InitializeSQLiteSignatures();
            InitializeMongoDBSignatures();
            InitializeDB2Signatures();
        }

        private void InitializeMySQLSignatures()
        {
            var mysqlSignatures = new List<ErrorSignature>
            {
                // MySQL specific errors
                new ErrorSignature("You have an error in your SQL syntax", "MySQL Syntax Error", Types.MySQL_With_Error, 95),
                new ErrorSignature("mysql_fetch_array()", "MySQL Fetch Array Error", Types.MySQL_With_Error, 90),
                new ErrorSignature("mysql_fetch_assoc()", "MySQL Fetch Assoc Error", Types.MySQL_With_Error, 90),
                new ErrorSignature("mysql_fetch_row()", "MySQL Fetch Row Error", Types.MySQL_With_Error, 90),
                new ErrorSignature("mysql_num_rows()", "MySQL Num Rows Error", Types.MySQL_With_Error, 90),
                new ErrorSignature("Warning: mysql_", "MySQL Warning", Types.MySQL_With_Error, 85),
                new ErrorSignature("function.mysql", "MySQL Function Error", Types.MySQL_With_Error, 85),
                new ErrorSignature("MySQL server version for the right syntax to use", "MySQL Version Error", Types.MySQL_With_Error, 95),
                new ErrorSignature("supplied argument is not a valid MySQL", "MySQL Invalid Argument", Types.MySQL_With_Error, 90),
                new ErrorSignature("Column count doesn't match value count at row", "MySQL Column Count Error", Types.MySQL_With_Error, 90),
                new ErrorSignature("mysql_query()", "MySQL Query Error", Types.MySQL_With_Error, 90),
                new ErrorSignature("ORA-00936: missing expression", "Oracle Missing Expression", Types.Oracle_With_Error, 95),
                new ErrorSignature("Duplicate entry", "MySQL Duplicate Entry", Types.MySQL_With_Error, 85),
                new ErrorSignature("The used SELECT statements have a different number of columns", "MySQL Union Column Mismatch", Types.MySQL_With_Error, 90),
                new ErrorSignature("Table '.*' doesn't exist", "MySQL Table Not Found", Types.MySQL_With_Error, 85, true),
                new ErrorSignature("Unknown column '.*' in 'field list'", "MySQL Unknown Column", Types.MySQL_With_Error, 85, true),
                new ErrorSignature("ERROR 1064 \\(42000\\)", "MySQL Error 1064", Types.MySQL_With_Error, 95, true),
                new ErrorSignature("ERROR 1054 \\(42S22\\)", "MySQL Error 1054", Types.MySQL_With_Error, 95, true),
                new ErrorSignature("ERROR 1146 \\(42S02\\)", "MySQL Error 1146", Types.MySQL_With_Error, 95, true),
                new ErrorSignature("XPATH syntax error", "MySQL XPATH Error", Types.MySQL_With_Error, 90),
                new ErrorSignature("ERROR 1062 \\(23000\\)", "MySQL Duplicate Entry Error", Types.MySQL_With_Error, 90, true),
                new ErrorSignature("subquery returns more than 1 row", "MySQL Subquery Error", Types.MySQL_With_Error, 85)
            };

            _errorSignatures[Types.MySQL_With_Error] = mysqlSignatures;
            _errorSignatures[Types.MySQL_Unknown] = mysqlSignatures;
        }

        private void InitializeMSSQLSignatures()
        {
            var mssqlSignatures = new List<ErrorSignature>
            {
                // MSSQL specific errors
                new ErrorSignature("Microsoft SQL Server", "MSSQL Server Error", Types.MSSQL_With_Error, 95),
                new ErrorSignature("OLE DB provider", "MSSQL OLE DB Error", Types.MSSQL_With_Error, 90),
                new ErrorSignature("SQL Server", "MSSQL Server", Types.MSSQL_With_Error, 85),
                new ErrorSignature("Driver.*SQL Server", "MSSQL Driver Error", Types.MSSQL_With_Error, 90, true),
                new ErrorSignature("SQLServer JDBC Driver", "MSSQL JDBC Driver", Types.MSSQL_With_Error, 90),
                new ErrorSignature("SqlException", "MSSQL Exception", Types.MSSQL_With_Error, 85),
                new ErrorSignature("System.Data.SqlClient.SqlException", "MSSQL SqlClient Exception", Types.MSSQL_With_Error, 95),
                new ErrorSignature("Unclosed quotation mark after the character string", "MSSQL Unclosed Quote", Types.MSSQL_With_Error, 90),
                new ErrorSignature("'80040e14'", "MSSQL Error 80040e14", Types.MSSQL_With_Error, 90),
                new ErrorSignature("mssql_query()", "MSSQL Query Function", Types.MSSQL_With_Error, 90),
                new ErrorSignature("odbc_exec()", "MSSQL ODBC Exec", Types.MSSQL_With_Error, 85),
                new ErrorSignature("Microsoft Access Driver", "MSSQL Access Driver", Types.MSSQL_With_Error, 80),
                new ErrorSignature("JET Database Engine", "MSSQL JET Engine", Types.MSSQL_With_Error, 85),
                new ErrorSignature("microsoft jet database", "MSSQL JET Database", Types.MSSQL_With_Error, 85),
                new ErrorSignature("Syntax error in query expression", "MSSQL Query Syntax Error", Types.MSSQL_With_Error, 90),
                new ErrorSignature("Data type mismatch in criteria expression", "MSSQL Data Type Mismatch", Types.MSSQL_With_Error, 85),
                new ErrorSignature("Microsoft VBScript compilation error", "MSSQL VBScript Error", Types.MSSQL_With_Error, 80),
                new ErrorSignature("ADODB.Field error", "MSSQL ADODB Field Error", Types.MSSQL_With_Error, 85),
                new ErrorSignature("BOF or EOF", "MSSQL BOF/EOF Error", Types.MSSQL_With_Error, 80),
                new ErrorSignature("ADODB.Command error", "MSSQL ADODB Command Error", Types.MSSQL_With_Error, 85),
                new ErrorSignature("JET Database Engine error", "MSSQL JET Engine Error", Types.MSSQL_With_Error, 85),
                new ErrorSignature("Invalid column name", "MSSQL Invalid Column", Types.MSSQL_With_Error, 85),
                new ErrorSignature("Invalid object name", "MSSQL Invalid Object", Types.MSSQL_With_Error, 85),
                new ErrorSignature("Incorrect syntax near", "MSSQL Syntax Error", Types.MSSQL_With_Error, 90),
                new ErrorSignature("Conversion failed when converting", "MSSQL Conversion Error", Types.MSSQL_With_Error, 85)
            };

            _errorSignatures[Types.MSSQL_With_Error] = mssqlSignatures;
            _errorSignatures[Types.MSSQL_Unknown] = mssqlSignatures;
        }

        private void InitializeOracleSignatures()
        {
            var oracleSignatures = new List<ErrorSignature>
            {
                // Oracle specific errors
                new ErrorSignature("ORA-00936", "Oracle Missing Expression", Types.Oracle_With_Error, 95),
                new ErrorSignature("ORA-00942", "Oracle Table/View Not Found", Types.Oracle_With_Error, 95),
                new ErrorSignature("ORA-00933", "Oracle SQL Command Not Properly Ended", Types.Oracle_With_Error, 95),
                new ErrorSignature("ORA-15005", "Oracle ASM Error", Types.Oracle_With_Error, 90),
                new ErrorSignature("ORA-00904", "Oracle Invalid Identifier", Types.Oracle_With_Error, 95),
                new ErrorSignature("ORA-00918", "Oracle Column Ambiguously Defined", Types.Oracle_With_Error, 90),
                new ErrorSignature("ORA-00911", "Oracle Invalid Character", Types.Oracle_With_Error, 90),
                new ErrorSignature("ORA-00907", "Oracle Missing Right Parenthesis", Types.Oracle_With_Error, 90),
                new ErrorSignature("ORA-00906", "Oracle Missing Left Parenthesis", Types.Oracle_With_Error, 90),
                new ErrorSignature("ORA-00903", "Oracle Invalid Table Name", Types.Oracle_With_Error, 90),
                new ErrorSignature("ORA-00920", "Oracle Invalid Relational Operator", Types.Oracle_With_Error, 90),
                new ErrorSignature("ORA-00921", "Oracle Unexpected End of SQL Command", Types.Oracle_With_Error, 90),
                new ErrorSignature("ORA-00923", "Oracle FROM keyword not found", Types.Oracle_With_Error, 90),
                new ErrorSignature("ORA-00924", "Oracle Missing BY keyword", Types.Oracle_With_Error, 90),
                new ErrorSignature("ORA-00925", "Oracle Missing INTO keyword", Types.Oracle_With_Error, 90),
                new ErrorSignature("ORA-00926", "Oracle Missing VALUES keyword", Types.Oracle_With_Error, 90),
                new ErrorSignature("ORA-00927", "Oracle Missing equal sign", Types.Oracle_With_Error, 90),
                new ErrorSignature("ORA-00928", "Oracle Missing SELECT keyword", Types.Oracle_With_Error, 90),
                new ErrorSignature("ORA-00929", "Oracle Missing period", Types.Oracle_With_Error, 90),
                new ErrorSignature("ORA-00930", "Oracle Missing asterisk", Types.Oracle_With_Error, 90),
                new ErrorSignature("Oracle.*Driver", "Oracle Driver Error", Types.Oracle_With_Error, 85, true),
                new ErrorSignature("Warning.*\\Woci_", "Oracle OCI Warning", Types.Oracle_With_Error, 85, true),
                new ErrorSignature("Warning.*\\Wora_", "Oracle ORA Warning", Types.Oracle_With_Error, 85, true),
                new ErrorSignature("oracle", "Oracle Generic", Types.Oracle_With_Error, 70),
                new ErrorSignature("TNS:", "Oracle TNS Error", Types.Oracle_With_Error, 85),
                new ErrorSignature("ORA-\\d+", "Oracle Error Code", Types.Oracle_With_Error, 95, true)
            };

            _errorSignatures[Types.Oracle_With_Error] = oracleSignatures;
            _errorSignatures[Types.Oracle_Unknown] = oracleSignatures;
        }

        private void InitializePostgreSQLSignatures()
        {
            var postgresSignatures = new List<ErrorSignature>
            {
                // PostgreSQL specific errors
                new ErrorSignature("PostgreSQL query failed", "PostgreSQL Query Failed", Types.PostgreSQL_With_Error, 95),
                new ErrorSignature("supplied argument is not a valid PostgreSQL result", "PostgreSQL Invalid Argument", Types.PostgreSQL_With_Error, 90),
                new ErrorSignature("unterminated quoted string at or near", "PostgreSQL Unterminated String", Types.PostgreSQL_With_Error, 90),
                new ErrorSignature("pg_query()", "PostgreSQL Query Function", Types.PostgreSQL_With_Error, 90),
                new ErrorSignature("pg_exec()", "PostgreSQL Exec Function", Types.PostgreSQL_With_Error, 90),
                new ErrorSignature("Query failed: ERROR: syntax error at or near", "PostgreSQL Syntax Error", Types.PostgreSQL_With_Error, 95),
                new ErrorSignature("Warning: pg_", "PostgreSQL Warning", Types.PostgreSQL_With_Error, 85),
                new ErrorSignature("valid PostgreSQL result", "PostgreSQL Valid Result", Types.PostgreSQL_With_Error, 85),
                new ErrorSignature("Npgsql.", "PostgreSQL Npgsql Error", Types.PostgreSQL_With_Error, 85),
                new ErrorSignature("PG::Error", "PostgreSQL PG Error", Types.PostgreSQL_With_Error, 90),
                new ErrorSignature("ERROR: relation \".*\" does not exist", "PostgreSQL Relation Error", Types.PostgreSQL_With_Error, 90, true),
                new ErrorSignature("ERROR: column \".*\" does not exist", "PostgreSQL Column Error", Types.PostgreSQL_With_Error, 90, true),
                new ErrorSignature("ERROR: function .* does not exist", "PostgreSQL Function Error", Types.PostgreSQL_With_Error, 90, true),
                new ErrorSignature("ERROR: operator does not exist", "PostgreSQL Operator Error", Types.PostgreSQL_With_Error, 85),
                new ErrorSignature("ERROR: syntax error at end of input", "PostgreSQL Syntax Error at End", Types.PostgreSQL_With_Error, 90),
                new ErrorSignature("ERROR: invalid input syntax", "PostgreSQL Invalid Input", Types.PostgreSQL_With_Error, 85),
                new ErrorSignature("ERROR: invalid byte sequence", "PostgreSQL Invalid Byte Sequence", Types.PostgreSQL_With_Error, 85),
                new ErrorSignature("FATAL: database .* does not exist", "PostgreSQL Database Not Found", Types.PostgreSQL_With_Error, 90, true),
                new ErrorSignature("FATAL: password authentication failed", "PostgreSQL Auth Failed", Types.PostgreSQL_With_Error, 80),
                new ErrorSignature("FATAL: role .* does not exist", "PostgreSQL Role Not Found", Types.PostgreSQL_With_Error, 85, true),
                new ErrorSignature("ERROR: permission denied", "PostgreSQL Permission Denied", Types.PostgreSQL_With_Error, 80),
                new ErrorSignature("ERROR: current transaction is aborted", "PostgreSQL Transaction Aborted", Types.PostgreSQL_With_Error, 80),
                new ErrorSignature("PostgreSQL", "PostgreSQL Generic", Types.PostgreSQL_With_Error, 70)
            };

            _errorSignatures[Types.PostgreSQL_With_Error] = postgresSignatures;
            _errorSignatures[Types.PostgreSQL_Unknown] = postgresSignatures;
        }

        private void InitializeSQLiteSignatures()
        {
            var sqliteSignatures = new List<ErrorSignature>
            {
                // SQLite specific errors
                new ErrorSignature("SQLite error", "SQLite Error", Types.Unknown, 95),
                new ErrorSignature("sqlite3.OperationalError", "SQLite Operational Error", Types.Unknown, 90),
                new ErrorSignature("sqlite3.DatabaseError", "SQLite Database Error", Types.Unknown, 90),
                new ErrorSignature("sqlite3.IntegrityError", "SQLite Integrity Error", Types.Unknown, 90),
                new ErrorSignature("sqlite3.ProgrammingError", "SQLite Programming Error", Types.Unknown, 90),
                new ErrorSignature("SQLite3::SQLException", "SQLite Exception", Types.Unknown, 90),
                new ErrorSignature("System.Data.SQLite.SQLiteException", "SQLite System Exception", Types.Unknown, 95),
                new ErrorSignature("Warning: SQLite3::", "SQLite Warning", Types.Unknown, 85),
                new ErrorSignature("sqlite_query", "SQLite Query Function", Types.Unknown, 85),
                new ErrorSignature("sqlite_exec", "SQLite Exec Function", Types.Unknown, 85),
                new ErrorSignature("sqlite_fetch", "SQLite Fetch Function", Types.Unknown, 85),
                new ErrorSignature("no such table", "SQLite Table Not Found", Types.Unknown, 90),
                new ErrorSignature("no such column", "SQLite Column Not Found", Types.Unknown, 90),
                new ErrorSignature("SQL logic error", "SQLite Logic Error", Types.Unknown, 85),
                new ErrorSignature("sqlite3_prepare", "SQLite Prepare Error", Types.Unknown, 85),
                new ErrorSignature("sqlite3_step", "SQLite Step Error", Types.Unknown, 85),
                new ErrorSignature("sqlite3_exec", "SQLite Exec Error", Types.Unknown, 85),
                new ErrorSignature("SQLITE_ERROR", "SQLite Error Code", Types.Unknown, 85),
                new ErrorSignature("SQLITE_MISUSE", "SQLite Misuse", Types.Unknown, 85),
                new ErrorSignature("unrecognized token", "SQLite Unrecognized Token", Types.Unknown, 90),
                new ErrorSignature("incomplete input", "SQLite Incomplete Input", Types.Unknown, 85)
            };

            _errorSignatures[Types.Unknown] = sqliteSignatures;
        }

        private void InitializeMongoDBSignatures()
        {
            var mongoSignatures = new List<ErrorSignature>
            {
                // MongoDB specific errors
                new ErrorSignature("MongoError", "MongoDB Error", Types.Unknown, 95),
                new ErrorSignature("MongoDB.*Error", "MongoDB Error", Types.Unknown, 90, true),
                new ErrorSignature("BSONError", "MongoDB BSON Error", Types.Unknown, 90),
                new ErrorSignature("WriteError", "MongoDB Write Error", Types.Unknown, 85),
                new ErrorSignature("ValidationError", "MongoDB Validation Error", Types.Unknown, 85),
                new ErrorSignature("CastError", "MongoDB Cast Error", Types.Unknown, 85),
                new ErrorSignature("DocumentNotFoundError", "MongoDB Document Not Found", Types.Unknown, 85),
                new ErrorSignature("DuplicateKeyError", "MongoDB Duplicate Key", Types.Unknown, 85),
                new ErrorSignature("MongoNetworkError", "MongoDB Network Error", Types.Unknown, 80),
                new ErrorSignature("MongoTimeoutError", "MongoDB Timeout", Types.Unknown, 80),
                new ErrorSignature("MongoWriteConcernError", "MongoDB Write Concern Error", Types.Unknown, 80),
                new ErrorSignature("MongoServerError", "MongoDB Server Error", Types.Unknown, 85),
                new ErrorSignature("MongoParseError", "MongoDB Parse Error", Types.Unknown, 85),
                new ErrorSignature("assert.*failed", "MongoDB Assert Failed", Types.Unknown, 85, true),
                new ErrorSignature("Invalid BSON", "MongoDB Invalid BSON", Types.Unknown, 85),
                new ErrorSignature("failed to connect to", "MongoDB Connection Failed", Types.Unknown, 80),
                new ErrorSignature("errmsg", "MongoDB Error Message", Types.Unknown, 75),
                new ErrorSignature("\\$where", "MongoDB $where", Types.Unknown, 70, true),
                new ErrorSignature("\\$regex", "MongoDB $regex", Types.Unknown, 70, true),
                new ErrorSignature("ObjectId", "MongoDB ObjectId", Types.Unknown, 70)
            };

            if (!_errorSignatures.ContainsKey(Types.Unknown))
                _errorSignatures[Types.Unknown] = new List<ErrorSignature>();

            _errorSignatures[Types.Unknown].AddRange(mongoSignatures);
        }

        private void InitializeDB2Signatures()
        {
            var db2Signatures = new List<ErrorSignature>
            {
                // IBM DB2 specific errors
                new ErrorSignature("DB2 SQL Error", "DB2 SQL Error", Types.Unknown, 95),
                new ErrorSignature("SQLCODE", "DB2 SQLCODE", Types.Unknown, 90),
                new ErrorSignature("SQLSTATE", "DB2 SQLSTATE", Types.Unknown, 90),
                new ErrorSignature("com.ibm.db2.jcc", "DB2 JCC Error", Types.Unknown, 90),
                new ErrorSignature("DB2Exception", "DB2 Exception", Types.Unknown, 90),
                new ErrorSignature("CLI0006E", "DB2 CLI Error", Types.Unknown, 85),
                new ErrorSignature("CLI0010E", "DB2 CLI Connection Error", Types.Unknown, 85),
                new ErrorSignature("SQL0104N", "DB2 SQL0104N", Types.Unknown, 95),
                new ErrorSignature("SQL0204N", "DB2 SQL0204N", Types.Unknown, 95),
                new ErrorSignature("SQL0206N", "DB2 SQL0206N", Types.Unknown, 95),
                new ErrorSignature("SQL0208N", "DB2 SQL0208N", Types.Unknown, 95),
                new ErrorSignature("SQL0401N", "DB2 SQL0401N", Types.Unknown, 95),
                new ErrorSignature("SQL0407N", "DB2 SQL0407N", Types.Unknown, 95),
                new ErrorSignature("SQL0501N", "DB2 SQL0501N", Types.Unknown, 95),
                new ErrorSignature("SQL0551N", "DB2 SQL0551N", Types.Unknown, 95),
                new ErrorSignature("SQL0803N", "DB2 SQL0803N", Types.Unknown, 95),
                new ErrorSignature("SQL1001N", "DB2 SQL1001N", Types.Unknown, 95),
                new ErrorSignature("Dynamic SQL Error", "DB2 Dynamic SQL Error", Types.Unknown, 85),
                new ErrorSignature("SQLJ1002", "DB2 SQLJ Error", Types.Unknown, 85),
                new ErrorSignature("A syntax error has occurred", "DB2 Syntax Error", Types.Unknown, 85),
                new ErrorSignature("An unexpected token", "DB2 Unexpected Token", Types.Unknown, 85),
                new ErrorSignature("DB2 Driver", "DB2 Driver Error", Types.Unknown, 80),
                new ErrorSignature("ibm.db2", "DB2 Generic", Types.Unknown, 70)
            };

            if (!_errorSignatures.ContainsKey(Types.Unknown))
                _errorSignatures[Types.Unknown] = new List<ErrorSignature>();

            _errorSignatures[Types.Unknown].AddRange(db2Signatures);
        }

        private void CompileRegexes()
        {
            foreach (var dbType in _errorSignatures.Keys)
            {
                CompileRegexesForType(dbType);
            }
        }

        private void CompileRegexesForType(Types dbType)
        {
            if (!_errorSignatures.ContainsKey(dbType))
                return;

            var regexes = new List<Regex>();
            var signatures = _errorSignatures[dbType];

            foreach (var signature in signatures.Where(s => s.IsRegex))
            {
                try
                {
                    var options = RegexOptions.Compiled | RegexOptions.Multiline;
                    if (!signature.CaseSensitive)
                        options |= RegexOptions.IgnoreCase;

                    regexes.Add(new Regex(signature.Pattern, options));
                }
                catch (ArgumentException)
                {
                    // Invalid regex pattern, skip
                }
            }

            _compiledRegexes[dbType] = regexes;
        }

        /// <summary>
        /// Gets all error signatures for a specific database type
        /// </summary>
        public List<ErrorSignature> GetSignatures(Types dbType)
        {
            if (_errorSignatures.ContainsKey(dbType))
                return new List<ErrorSignature>(_errorSignatures[dbType]);
            return new List<ErrorSignature>();
        }

        /// <summary>
        /// Gets count of signatures for a specific database type
        /// </summary>
        public int GetSignatureCount(Types dbType)
        {
            if (_errorSignatures.ContainsKey(dbType))
                return _errorSignatures[dbType].Count;
            return 0;
        }

        /// <summary>
        /// Gets total count of all signatures
        /// </summary>
        public int GetTotalSignatureCount()
        {
            return _errorSignatures.Values.Sum(signatures => signatures.Count);
        }
    }
}