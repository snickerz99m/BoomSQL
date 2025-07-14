using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SQLi_Dumper.Core
{
    /// <summary>
    /// Comprehensive error signature detection for multiple database management systems
    /// </summary>
    public static class ErrorSignatures
    {
        /// <summary>
        /// Error signature structure for pattern matching
        /// </summary>
        public class ErrorSignature
        {
            public string Pattern { get; set; }
            public DbTypes.DatabaseFamily Database { get; set; }
            public string ErrorType { get; set; }
            public RegexOptions Options { get; set; }
            public string Description { get; set; }
            
            public ErrorSignature(string pattern, DbTypes.DatabaseFamily database, string errorType, 
                                 RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Multiline,
                                 string description = "")
            {
                Pattern = pattern;
                Database = database;
                ErrorType = errorType;
                Options = options;
                Description = description;
            }
        }

        /// <summary>
        /// MySQL error signatures
        /// </summary>
        public static readonly List<ErrorSignature> MySQLErrors = new List<ErrorSignature>
        {
            new ErrorSignature(@"You have an error in your SQL syntax", DbTypes.DatabaseFamily.MySQL, "Syntax Error", 
                RegexOptions.IgnoreCase, "Common MySQL syntax error"),
            new ErrorSignature(@"mysql_fetch_array\(\)", DbTypes.DatabaseFamily.MySQL, "Function Error", 
                RegexOptions.IgnoreCase, "MySQL function error"),
            new ErrorSignature(@"mysql_num_rows\(\)", DbTypes.DatabaseFamily.MySQL, "Function Error", 
                RegexOptions.IgnoreCase, "MySQL function error"),
            new ErrorSignature(@"Warning.*mysql_.*", DbTypes.DatabaseFamily.MySQL, "Warning", 
                RegexOptions.IgnoreCase, "MySQL warning"),
            new ErrorSignature(@"Unknown column '.*' in 'field list'", DbTypes.DatabaseFamily.MySQL, "Column Error", 
                RegexOptions.IgnoreCase, "MySQL unknown column"),
            new ErrorSignature(@"Table '.*' doesn't exist", DbTypes.DatabaseFamily.MySQL, "Table Error", 
                RegexOptions.IgnoreCase, "MySQL table doesn't exist"),
            new ErrorSignature(@"Duplicate entry '.*' for key", DbTypes.DatabaseFamily.MySQL, "Duplicate Error", 
                RegexOptions.IgnoreCase, "MySQL duplicate key"),
            new ErrorSignature(@"ERROR 1064 \(42000\)", DbTypes.DatabaseFamily.MySQL, "Syntax Error", 
                RegexOptions.IgnoreCase, "MySQL syntax error 1064"),
            new ErrorSignature(@"ERROR 1146 \(42S02\)", DbTypes.DatabaseFamily.MySQL, "Table Error", 
                RegexOptions.IgnoreCase, "MySQL table doesn't exist 1146"),
            new ErrorSignature(@"ERROR 1054 \(42S22\)", DbTypes.DatabaseFamily.MySQL, "Column Error", 
                RegexOptions.IgnoreCase, "MySQL unknown column 1054"),
            new ErrorSignature(@"Column count doesn't match value count", DbTypes.DatabaseFamily.MySQL, "Column Count Error", 
                RegexOptions.IgnoreCase, "MySQL column count mismatch"),
            new ErrorSignature(@"Subquery returns more than 1 row", DbTypes.DatabaseFamily.MySQL, "Subquery Error", 
                RegexOptions.IgnoreCase, "MySQL subquery error"),
            new ErrorSignature(@"Access denied for user", DbTypes.DatabaseFamily.MySQL, "Access Error", 
                RegexOptions.IgnoreCase, "MySQL access denied"),
            new ErrorSignature(@"Can't connect to MySQL server", DbTypes.DatabaseFamily.MySQL, "Connection Error", 
                RegexOptions.IgnoreCase, "MySQL connection error")
        };

        /// <summary>
        /// Microsoft SQL Server error signatures
        /// </summary>
        public static readonly List<ErrorSignature> MSSQLErrors = new List<ErrorSignature>
        {
            new ErrorSignature(@"Incorrect syntax near", DbTypes.DatabaseFamily.MSSQL, "Syntax Error", 
                RegexOptions.IgnoreCase, "MSSQL syntax error"),
            new ErrorSignature(@"Unclosed quotation mark", DbTypes.DatabaseFamily.MSSQL, "Quote Error", 
                RegexOptions.IgnoreCase, "MSSQL unclosed quote"),
            new ErrorSignature(@"Invalid column name", DbTypes.DatabaseFamily.MSSQL, "Column Error", 
                RegexOptions.IgnoreCase, "MSSQL invalid column"),
            new ErrorSignature(@"Invalid object name", DbTypes.DatabaseFamily.MSSQL, "Object Error", 
                RegexOptions.IgnoreCase, "MSSQL invalid object"),
            new ErrorSignature(@"Microsoft OLE DB Provider for SQL Server", DbTypes.DatabaseFamily.MSSQL, "Provider Error", 
                RegexOptions.IgnoreCase, "MSSQL OLE DB provider"),
            new ErrorSignature(@"System\.Data\.SqlClient\.SqlException", DbTypes.DatabaseFamily.MSSQL, "Exception", 
                RegexOptions.IgnoreCase, "MSSQL .NET exception"),
            new ErrorSignature(@"Conversion failed when converting", DbTypes.DatabaseFamily.MSSQL, "Conversion Error", 
                RegexOptions.IgnoreCase, "MSSQL conversion error"),
            new ErrorSignature(@"The multi-part identifier", DbTypes.DatabaseFamily.MSSQL, "Identifier Error", 
                RegexOptions.IgnoreCase, "MSSQL multi-part identifier"),
            new ErrorSignature(@"String or binary data would be truncated", DbTypes.DatabaseFamily.MSSQL, "Truncation Error", 
                RegexOptions.IgnoreCase, "MSSQL data truncation"),
            new ErrorSignature(@"Login failed for user", DbTypes.DatabaseFamily.MSSQL, "Login Error", 
                RegexOptions.IgnoreCase, "MSSQL login failed"),
            new ErrorSignature(@"A network-related or instance-specific error", DbTypes.DatabaseFamily.MSSQL, "Network Error", 
                RegexOptions.IgnoreCase, "MSSQL network error"),
            new ErrorSignature(@"Timeout expired", DbTypes.DatabaseFamily.MSSQL, "Timeout Error", 
                RegexOptions.IgnoreCase, "MSSQL timeout"),
            new ErrorSignature(@"Cannot open database", DbTypes.DatabaseFamily.MSSQL, "Database Error", 
                RegexOptions.IgnoreCase, "MSSQL cannot open database")
        };

        /// <summary>
        /// Oracle error signatures
        /// </summary>
        public static readonly List<ErrorSignature> OracleErrors = new List<ErrorSignature>
        {
            new ErrorSignature(@"ORA-\d+", DbTypes.DatabaseFamily.Oracle, "Oracle Error", 
                RegexOptions.IgnoreCase, "Oracle error code"),
            new ErrorSignature(@"ORA-00942: table or view does not exist", DbTypes.DatabaseFamily.Oracle, "Table Error", 
                RegexOptions.IgnoreCase, "Oracle table doesn't exist"),
            new ErrorSignature(@"ORA-00904: invalid identifier", DbTypes.DatabaseFamily.Oracle, "Identifier Error", 
                RegexOptions.IgnoreCase, "Oracle invalid identifier"),
            new ErrorSignature(@"ORA-01756: quoted string not properly terminated", DbTypes.DatabaseFamily.Oracle, "Quote Error", 
                RegexOptions.IgnoreCase, "Oracle unterminated string"),
            new ErrorSignature(@"ORA-00933: SQL command not properly ended", DbTypes.DatabaseFamily.Oracle, "Command Error", 
                RegexOptions.IgnoreCase, "Oracle command not ended"),
            new ErrorSignature(@"ORA-00936: missing expression", DbTypes.DatabaseFamily.Oracle, "Expression Error", 
                RegexOptions.IgnoreCase, "Oracle missing expression"),
            new ErrorSignature(@"ORA-01722: invalid number", DbTypes.DatabaseFamily.Oracle, "Number Error", 
                RegexOptions.IgnoreCase, "Oracle invalid number"),
            new ErrorSignature(@"ORA-01790: expression must have same datatype", DbTypes.DatabaseFamily.Oracle, "Datatype Error", 
                RegexOptions.IgnoreCase, "Oracle datatype mismatch"),
            new ErrorSignature(@"ORA-00979: not a GROUP BY expression", DbTypes.DatabaseFamily.Oracle, "Group By Error", 
                RegexOptions.IgnoreCase, "Oracle GROUP BY error"),
            new ErrorSignature(@"ORA-00907: missing right parenthesis", DbTypes.DatabaseFamily.Oracle, "Parenthesis Error", 
                RegexOptions.IgnoreCase, "Oracle missing parenthesis"),
            new ErrorSignature(@"oracle\.jdbc\.driver\.OracleDriver", DbTypes.DatabaseFamily.Oracle, "Driver Error", 
                RegexOptions.IgnoreCase, "Oracle JDBC driver"),
            new ErrorSignature(@"Oracle Database Error", DbTypes.DatabaseFamily.Oracle, "Database Error", 
                RegexOptions.IgnoreCase, "Oracle database error")
        };

        /// <summary>
        /// PostgreSQL error signatures
        /// </summary>
        public static readonly List<ErrorSignature> PostgreSQLErrors = new List<ErrorSignature>
        {
            new ErrorSignature(@"ERROR.*syntax error at or near", DbTypes.DatabaseFamily.PostgreSQL, "Syntax Error", 
                RegexOptions.IgnoreCase, "PostgreSQL syntax error"),
            new ErrorSignature(@"ERROR.*column.*does not exist", DbTypes.DatabaseFamily.PostgreSQL, "Column Error", 
                RegexOptions.IgnoreCase, "PostgreSQL column doesn't exist"),
            new ErrorSignature(@"ERROR.*relation.*does not exist", DbTypes.DatabaseFamily.PostgreSQL, "Relation Error", 
                RegexOptions.IgnoreCase, "PostgreSQL relation doesn't exist"),
            new ErrorSignature(@"ERROR.*unterminated quoted string", DbTypes.DatabaseFamily.PostgreSQL, "Quote Error", 
                RegexOptions.IgnoreCase, "PostgreSQL unterminated string"),
            new ErrorSignature(@"ERROR.*invalid input syntax", DbTypes.DatabaseFamily.PostgreSQL, "Input Error", 
                RegexOptions.IgnoreCase, "PostgreSQL invalid input"),
            new ErrorSignature(@"ERROR.*operator does not exist", DbTypes.DatabaseFamily.PostgreSQL, "Operator Error", 
                RegexOptions.IgnoreCase, "PostgreSQL operator doesn't exist"),
            new ErrorSignature(@"ERROR.*function.*does not exist", DbTypes.DatabaseFamily.PostgreSQL, "Function Error", 
                RegexOptions.IgnoreCase, "PostgreSQL function doesn't exist"),
            new ErrorSignature(@"ERROR.*permission denied", DbTypes.DatabaseFamily.PostgreSQL, "Permission Error", 
                RegexOptions.IgnoreCase, "PostgreSQL permission denied"),
            new ErrorSignature(@"ERROR.*division by zero", DbTypes.DatabaseFamily.PostgreSQL, "Division Error", 
                RegexOptions.IgnoreCase, "PostgreSQL division by zero"),
            new ErrorSignature(@"FATAL.*database.*does not exist", DbTypes.DatabaseFamily.PostgreSQL, "Database Error", 
                RegexOptions.IgnoreCase, "PostgreSQL database doesn't exist"),
            new ErrorSignature(@"org\.postgresql\.util\.PSQLException", DbTypes.DatabaseFamily.PostgreSQL, "Exception", 
                RegexOptions.IgnoreCase, "PostgreSQL JDBC exception"),
            new ErrorSignature(@"Warning.*pg_.*", DbTypes.DatabaseFamily.PostgreSQL, "Warning", 
                RegexOptions.IgnoreCase, "PostgreSQL warning")
        };

        /// <summary>
        /// SQLite error signatures
        /// </summary>
        public static readonly List<ErrorSignature> SQLiteErrors = new List<ErrorSignature>
        {
            new ErrorSignature(@"SQLite error.*near", DbTypes.DatabaseFamily.SQLite, "Syntax Error", 
                RegexOptions.IgnoreCase, "SQLite syntax error"),
            new ErrorSignature(@"no such table", DbTypes.DatabaseFamily.SQLite, "Table Error", 
                RegexOptions.IgnoreCase, "SQLite table doesn't exist"),
            new ErrorSignature(@"no such column", DbTypes.DatabaseFamily.SQLite, "Column Error", 
                RegexOptions.IgnoreCase, "SQLite column doesn't exist"),
            new ErrorSignature(@"ambiguous column name", DbTypes.DatabaseFamily.SQLite, "Column Error", 
                RegexOptions.IgnoreCase, "SQLite ambiguous column"),
            new ErrorSignature(@"unrecognized token", DbTypes.DatabaseFamily.SQLite, "Token Error", 
                RegexOptions.IgnoreCase, "SQLite unrecognized token"),
            new ErrorSignature(@"incomplete input", DbTypes.DatabaseFamily.SQLite, "Input Error", 
                RegexOptions.IgnoreCase, "SQLite incomplete input"),
            new ErrorSignature(@"SQL logic error", DbTypes.DatabaseFamily.SQLite, "Logic Error", 
                RegexOptions.IgnoreCase, "SQLite logic error"),
            new ErrorSignature(@"database is locked", DbTypes.DatabaseFamily.SQLite, "Lock Error", 
                RegexOptions.IgnoreCase, "SQLite database locked"),
            new ErrorSignature(@"constraint failed", DbTypes.DatabaseFamily.SQLite, "Constraint Error", 
                RegexOptions.IgnoreCase, "SQLite constraint failed"),
            new ErrorSignature(@"sqlite3\.OperationalError", DbTypes.DatabaseFamily.SQLite, "Operational Error", 
                RegexOptions.IgnoreCase, "SQLite operational error")
        };

        /// <summary>
        /// MongoDB error signatures
        /// </summary>
        public static readonly List<ErrorSignature> MongoDBErrors = new List<ErrorSignature>
        {
            new ErrorSignature(@"MongoError", DbTypes.DatabaseFamily.MongoDB, "MongoDB Error", 
                RegexOptions.IgnoreCase, "MongoDB error"),
            new ErrorSignature(@"E11000.*duplicate key", DbTypes.DatabaseFamily.MongoDB, "Duplicate Key Error", 
                RegexOptions.IgnoreCase, "MongoDB duplicate key"),
            new ErrorSignature(@"SyntaxError.*unexpected token", DbTypes.DatabaseFamily.MongoDB, "Syntax Error", 
                RegexOptions.IgnoreCase, "MongoDB syntax error"),
            new ErrorSignature(@"ReferenceError.*is not defined", DbTypes.DatabaseFamily.MongoDB, "Reference Error", 
                RegexOptions.IgnoreCase, "MongoDB reference error"),
            new ErrorSignature(@"TypeError.*Cannot read property", DbTypes.DatabaseFamily.MongoDB, "Type Error", 
                RegexOptions.IgnoreCase, "MongoDB type error"),
            new ErrorSignature(@"ValidationError", DbTypes.DatabaseFamily.MongoDB, "Validation Error", 
                RegexOptions.IgnoreCase, "MongoDB validation error"),
            new ErrorSignature(@"CastError", DbTypes.DatabaseFamily.MongoDB, "Cast Error", 
                RegexOptions.IgnoreCase, "MongoDB cast error"),
            new ErrorSignature(@"MongoServerError", DbTypes.DatabaseFamily.MongoDB, "Server Error", 
                RegexOptions.IgnoreCase, "MongoDB server error"),
            new ErrorSignature(@"namespace.*not found", DbTypes.DatabaseFamily.MongoDB, "Namespace Error", 
                RegexOptions.IgnoreCase, "MongoDB namespace not found"),
            new ErrorSignature(@"failed to connect to server", DbTypes.DatabaseFamily.MongoDB, "Connection Error", 
                RegexOptions.IgnoreCase, "MongoDB connection failed")
        };

        /// <summary>
        /// DB2 error signatures
        /// </summary>
        public static readonly List<ErrorSignature> DB2Errors = new List<ErrorSignature>
        {
            new ErrorSignature(@"SQLSTATE.*SQLCODE", DbTypes.DatabaseFamily.DB2, "SQL Error", 
                RegexOptions.IgnoreCase, "DB2 SQL error"),
            new ErrorSignature(@"SQL0204N.*is an undefined name", DbTypes.DatabaseFamily.DB2, "Undefined Name", 
                RegexOptions.IgnoreCase, "DB2 undefined name"),
            new ErrorSignature(@"SQL0206N.*is not valid in the context", DbTypes.DatabaseFamily.DB2, "Invalid Context", 
                RegexOptions.IgnoreCase, "DB2 invalid context"),
            new ErrorSignature(@"SQL0104N.*An unexpected token", DbTypes.DatabaseFamily.DB2, "Unexpected Token", 
                RegexOptions.IgnoreCase, "DB2 unexpected token"),
            new ErrorSignature(@"SQL0180N.*The syntax of the string representation", DbTypes.DatabaseFamily.DB2, "Syntax Error", 
                RegexOptions.IgnoreCase, "DB2 syntax error"),
            new ErrorSignature(@"SQL0401N.*The operands of a numeric operation", DbTypes.DatabaseFamily.DB2, "Numeric Error", 
                RegexOptions.IgnoreCase, "DB2 numeric error"),
            new ErrorSignature(@"SQL0803N.*One or more values in the INSERT", DbTypes.DatabaseFamily.DB2, "Duplicate Error", 
                RegexOptions.IgnoreCase, "DB2 duplicate key"),
            new ErrorSignature(@"COM.ibm.db2.jdbc", DbTypes.DatabaseFamily.DB2, "JDBC Error", 
                RegexOptions.IgnoreCase, "DB2 JDBC error"),
            new ErrorSignature(@"DB2 SQL Error", DbTypes.DatabaseFamily.DB2, "SQL Error", 
                RegexOptions.IgnoreCase, "DB2 SQL error")
        };

        /// <summary>
        /// Firebird error signatures
        /// </summary>
        public static readonly List<ErrorSignature> FirebirdErrors = new List<ErrorSignature>
        {
            new ErrorSignature(@"Dynamic SQL Error", DbTypes.DatabaseFamily.Firebird, "Dynamic SQL Error", 
                RegexOptions.IgnoreCase, "Firebird dynamic SQL error"),
            new ErrorSignature(@"Table unknown", DbTypes.DatabaseFamily.Firebird, "Table Error", 
                RegexOptions.IgnoreCase, "Firebird table unknown"),
            new ErrorSignature(@"Column unknown", DbTypes.DatabaseFamily.Firebird, "Column Error", 
                RegexOptions.IgnoreCase, "Firebird column unknown"),
            new ErrorSignature(@"Token unknown", DbTypes.DatabaseFamily.Firebird, "Token Error", 
                RegexOptions.IgnoreCase, "Firebird token unknown"),
            new ErrorSignature(@"GDS Exception", DbTypes.DatabaseFamily.Firebird, "GDS Exception", 
                RegexOptions.IgnoreCase, "Firebird GDS exception"),
            new ErrorSignature(@"isc_dsql_prepare", DbTypes.DatabaseFamily.Firebird, "Prepare Error", 
                RegexOptions.IgnoreCase, "Firebird prepare error"),
            new ErrorSignature(@"violation of FOREIGN KEY constraint", DbTypes.DatabaseFamily.Firebird, "Foreign Key Error", 
                RegexOptions.IgnoreCase, "Firebird foreign key violation"),
            new ErrorSignature(@"org\.firebirdsql\.jdbc", DbTypes.DatabaseFamily.Firebird, "JDBC Error", 
                RegexOptions.IgnoreCase, "Firebird JDBC error"),
            new ErrorSignature(@"FirebirdSql\.Data\.FirebirdClient", DbTypes.DatabaseFamily.Firebird, ".NET Error", 
                RegexOptions.IgnoreCase, "Firebird .NET error")
        };

        /// <summary>
        /// Informix error signatures
        /// </summary>
        public static readonly List<ErrorSignature> InformixErrors = new List<ErrorSignature>
        {
            new ErrorSignature(@"SQLCODE.*SQLERRD", DbTypes.DatabaseFamily.Informix, "SQL Error", 
                RegexOptions.IgnoreCase, "Informix SQL error"),
            new ErrorSignature(@"A syntax error has occurred", DbTypes.DatabaseFamily.Informix, "Syntax Error", 
                RegexOptions.IgnoreCase, "Informix syntax error"),
            new ErrorSignature(@"Table.*not found", DbTypes.DatabaseFamily.Informix, "Table Error", 
                RegexOptions.IgnoreCase, "Informix table not found"),
            new ErrorSignature(@"Column.*not found", DbTypes.DatabaseFamily.Informix, "Column Error", 
                RegexOptions.IgnoreCase, "Informix column not found"),
            new ErrorSignature(@"Informix Dynamic Server", DbTypes.DatabaseFamily.Informix, "Server Error", 
                RegexOptions.IgnoreCase, "Informix server error"),
            new ErrorSignature(@"com\.informix\.jdbc", DbTypes.DatabaseFamily.Informix, "JDBC Error", 
                RegexOptions.IgnoreCase, "Informix JDBC error"),
            new ErrorSignature(@"IBM\.Data\.Informix", DbTypes.DatabaseFamily.Informix, ".NET Error", 
                RegexOptions.IgnoreCase, "Informix .NET error")
        };

        /// <summary>
        /// MariaDB error signatures (similar to MySQL but specific to MariaDB)
        /// </summary>
        public static readonly List<ErrorSignature> MariaDBErrors = new List<ErrorSignature>
        {
            new ErrorSignature(@"You have an error in your SQL syntax.*MariaDB", DbTypes.DatabaseFamily.MariaDB, "Syntax Error", 
                RegexOptions.IgnoreCase, "MariaDB syntax error"),
            new ErrorSignature(@"Unknown column.*MariaDB", DbTypes.DatabaseFamily.MariaDB, "Column Error", 
                RegexOptions.IgnoreCase, "MariaDB unknown column"),
            new ErrorSignature(@"Table.*doesn't exist.*MariaDB", DbTypes.DatabaseFamily.MariaDB, "Table Error", 
                RegexOptions.IgnoreCase, "MariaDB table doesn't exist"),
            new ErrorSignature(@"MariaDB server version", DbTypes.DatabaseFamily.MariaDB, "Version Error", 
                RegexOptions.IgnoreCase, "MariaDB version error"),
            new ErrorSignature(@"MariaDB.*Connection.*failed", DbTypes.DatabaseFamily.MariaDB, "Connection Error", 
                RegexOptions.IgnoreCase, "MariaDB connection failed")
        };

        /// <summary>
        /// Sybase error signatures
        /// </summary>
        public static readonly List<ErrorSignature> SybaseErrors = new List<ErrorSignature>
        {
            new ErrorSignature(@"Sybase message.*", DbTypes.DatabaseFamily.Sybase, "Message Error", 
                RegexOptions.IgnoreCase, "Sybase message error"),
            new ErrorSignature(@"Incorrect syntax near", DbTypes.DatabaseFamily.Sybase, "Syntax Error", 
                RegexOptions.IgnoreCase, "Sybase syntax error"),
            new ErrorSignature(@"Invalid column name", DbTypes.DatabaseFamily.Sybase, "Column Error", 
                RegexOptions.IgnoreCase, "Sybase invalid column"),
            new ErrorSignature(@"Table.*not found", DbTypes.DatabaseFamily.Sybase, "Table Error", 
                RegexOptions.IgnoreCase, "Sybase table not found"),
            new ErrorSignature(@"com\.sybase\.jdbc", DbTypes.DatabaseFamily.Sybase, "JDBC Error", 
                RegexOptions.IgnoreCase, "Sybase JDBC error"),
            new ErrorSignature(@"Sybase\.Data\.AseClient", DbTypes.DatabaseFamily.Sybase, ".NET Error", 
                RegexOptions.IgnoreCase, "Sybase .NET error")
        };

        /// <summary>
        /// Microsoft Access error signatures
        /// </summary>
        public static readonly List<ErrorSignature> AccessErrors = new List<ErrorSignature>
        {
            new ErrorSignature(@"Microsoft Access Database Engine", DbTypes.DatabaseFamily.MsAccess, "Engine Error", 
                RegexOptions.IgnoreCase, "Access engine error"),
            new ErrorSignature(@"Microsoft Office Access Database Engine", DbTypes.DatabaseFamily.MsAccess, "Engine Error", 
                RegexOptions.IgnoreCase, "Access office engine error"),
            new ErrorSignature(@"Syntax error in.*statement", DbTypes.DatabaseFamily.MsAccess, "Syntax Error", 
                RegexOptions.IgnoreCase, "Access syntax error"),
            new ErrorSignature(@"No value given for one or more required parameters", DbTypes.DatabaseFamily.MsAccess, "Parameter Error", 
                RegexOptions.IgnoreCase, "Access parameter error"),
            new ErrorSignature(@"Could not find file", DbTypes.DatabaseFamily.MsAccess, "File Error", 
                RegexOptions.IgnoreCase, "Access file not found"),
            new ErrorSignature(@"System\.Data\.OleDb\.OleDbException", DbTypes.DatabaseFamily.MsAccess, "OLE DB Error", 
                RegexOptions.IgnoreCase, "Access OLE DB error")
        };

        /// <summary>
        /// Master list of all error signatures
        /// </summary>
        public static readonly List<ErrorSignature> AllErrorSignatures = new List<ErrorSignature>();

        /// <summary>
        /// Initialize all error signatures
        /// </summary>
        static ErrorSignatures()
        {
            AllErrorSignatures.AddRange(MySQLErrors);
            AllErrorSignatures.AddRange(MSSQLErrors);
            AllErrorSignatures.AddRange(OracleErrors);
            AllErrorSignatures.AddRange(PostgreSQLErrors);
            AllErrorSignatures.AddRange(SQLiteErrors);
            AllErrorSignatures.AddRange(MongoDBErrors);
            AllErrorSignatures.AddRange(DB2Errors);
            AllErrorSignatures.AddRange(FirebirdErrors);
            AllErrorSignatures.AddRange(InformixErrors);
            AllErrorSignatures.AddRange(MariaDBErrors);
            AllErrorSignatures.AddRange(SybaseErrors);
            AllErrorSignatures.AddRange(AccessErrors);
        }

        /// <summary>
        /// Detect database type from error response
        /// </summary>
        /// <param name="response">HTTP response content</param>
        /// <returns>List of matching error signatures</returns>
        public static List<ErrorSignature> DetectDatabaseFromError(string response)
        {
            var matches = new List<ErrorSignature>();
            
            if (string.IsNullOrEmpty(response))
                return matches;

            foreach (var signature in AllErrorSignatures)
            {
                try
                {
                    if (Regex.IsMatch(response, signature.Pattern, signature.Options))
                    {
                        matches.Add(signature);
                    }
                }
                catch (RegexMatchTimeoutException)
                {
                    // Skip patterns that timeout
                    continue;
                }
                catch (ArgumentException)
                {
                    // Skip invalid regex patterns
                    continue;
                }
            }

            return matches;
        }

        /// <summary>
        /// Get error signatures for specific database family
        /// </summary>
        /// <param name="family">Database family</param>
        /// <returns>List of error signatures</returns>
        public static List<ErrorSignature> GetErrorSignaturesForDatabase(DbTypes.DatabaseFamily family)
        {
            switch (family)
            {
                case DbTypes.DatabaseFamily.MySQL:
                    return MySQLErrors;
                case DbTypes.DatabaseFamily.MSSQL:
                    return MSSQLErrors;
                case DbTypes.DatabaseFamily.Oracle:
                    return OracleErrors;
                case DbTypes.DatabaseFamily.PostgreSQL:
                    return PostgreSQLErrors;
                case DbTypes.DatabaseFamily.SQLite:
                    return SQLiteErrors;
                case DbTypes.DatabaseFamily.MongoDB:
                    return MongoDBErrors;
                case DbTypes.DatabaseFamily.DB2:
                    return DB2Errors;
                case DbTypes.DatabaseFamily.Firebird:
                    return FirebirdErrors;
                case DbTypes.DatabaseFamily.Informix:
                    return InformixErrors;
                case DbTypes.DatabaseFamily.MariaDB:
                    return MariaDBErrors;
                case DbTypes.DatabaseFamily.Sybase:
                    return SybaseErrors;
                case DbTypes.DatabaseFamily.MsAccess:
                    return AccessErrors;
                default:
                    return new List<ErrorSignature>();
            }
        }

        /// <summary>
        /// Check if response contains SQL injection vulnerability indicators
        /// </summary>
        /// <param name="response">HTTP response content</param>
        /// <returns>True if SQL injection indicators are found</returns>
        public static bool ContainsSQLInjectionIndicators(string response)
        {
            if (string.IsNullOrEmpty(response))
                return false;

            // Generic SQL injection indicators
            var indicators = new string[]
            {
                "SQL syntax", "syntax error", "mysql_fetch", "ORA-", "Microsoft OLE DB",
                "ODBC", "SQLException", "PostgreSQL", "SQLite", "MongoDB", "DB2",
                "Firebird", "Informix", "MariaDB", "Sybase", "Access Database Engine"
            };

            foreach (var indicator in indicators)
            {
                if (response.IndexOf(indicator, StringComparison.OrdinalIgnoreCase) >= 0)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Add custom error signature
        /// </summary>
        /// <param name="signature">Error signature to add</param>
        public static void AddCustomErrorSignature(ErrorSignature signature)
        {
            AllErrorSignatures.Add(signature);
        }

        /// <summary>
        /// Remove error signature
        /// </summary>
        /// <param name="pattern">Pattern to remove</param>
        /// <returns>True if removed</returns>
        public static bool RemoveErrorSignature(string pattern)
        {
            return AllErrorSignatures.RemoveAll(s => s.Pattern == pattern) > 0;
        }
    }
}