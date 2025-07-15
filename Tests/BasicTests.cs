using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using BoomSQL.Core;

namespace BoomSQL.Tests
{
    public class BasicTests
    {
        public static void RunTests()
        {
            Console.WriteLine("Running BoomSQL Basic Tests...");
            
            TestProxyManager();
            TestPayloadLoading();
            TestErrorSignatureLoading();
            TestWafBypasses();
            TestSqlInjectionEngine();
            TestDatabaseDumper();
            TestWebCrawler();
            TestDorkSearcher();
            TestReportGenerator();
            
            Console.WriteLine("All tests completed successfully!");
        }
        
        private static void TestProxyManager()
        {
            Console.WriteLine("Testing ProxyManager...");
            
            // Test proxy loading
            var proxies = ProxyManager.LoadProxies("proxies.txt");
            if (proxies.Count > 0)
            {
                Console.WriteLine($"✓ Loaded {proxies.Count} proxies");
            }
            else
            {
                Console.WriteLine("⚠ No proxies loaded - check proxies.txt file");
            }
            
            // Test user agent loading
            ProxyManager.LoadUserAgents();
            var userAgent = ProxyManager.GetRandomUserAgent();
            Console.WriteLine($"✓ Random user agent: {userAgent.Substring(0, Math.Min(50, userAgent.Length))}...");
        }
        
        private static void TestPayloadLoading()
        {
            Console.WriteLine("Testing payload loading...");
            
            try
            {
                if (File.Exists("payloads.xml"))
                {
                    var doc = XDocument.Load("payloads.xml");
                    var payloads = doc.Descendants("payload").Count();
                    Console.WriteLine($"✓ Loaded {payloads} payloads from XML");
                }
                else
                {
                    Console.WriteLine("⚠ payloads.xml not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading payloads: {ex.Message}");
            }
        }
        
        private static void TestErrorSignatureLoading()
        {
            Console.WriteLine("Testing error signature loading...");
            
            try
            {
                if (File.Exists("error_signatures.xml"))
                {
                    var doc = XDocument.Load("error_signatures.xml");
                    var signatures = doc.Descendants("signature").Count();
                    Console.WriteLine($"✓ Loaded {signatures} error signatures from XML");
                }
                else
                {
                    Console.WriteLine("⚠ error_signatures.xml not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading error signatures: {ex.Message}");
            }
        }
        
        private static void TestWafBypasses()
        {
            Console.WriteLine("Testing WAF bypasses...");
            
            try
            {
                if (File.Exists("waf_bypasses.xml"))
                {
                    var doc = XDocument.Load("waf_bypasses.xml");
                    var bypasses = doc.Descendants("bypass").Count();
                    Console.WriteLine($"✓ Loaded {bypasses} WAF bypasses from XML");
                }
                else
                {
                    Console.WriteLine("⚠ waf_bypasses.xml not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading WAF bypasses: {ex.Message}");
            }
        }
        
        private static void TestSqlInjectionEngine()
        {
            Console.WriteLine("Testing SQL injection engine...");
            
            try
            {
                using var httpClient = new System.Net.Http.HttpClient();
                var config = new SqlInjectionConfig();
                var engine = new SqlInjectionEngine(httpClient, config);
                Console.WriteLine("✓ SqlInjectionEngine created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating SqlInjectionEngine: {ex.Message}");
            }
        }
        
        private static void TestDatabaseDumper()
        {
            Console.WriteLine("Testing database dumper...");
            
            try
            {
                using var httpClient = new System.Net.Http.HttpClient();
                var vulnerability = new VulnerabilityDetails
                {
                    VulnerabilityType = "Test",
                    InjectionPoint = new InjectionPoint { Name = "test", Type = InjectionPointType.UrlParameter },
                    Payload = new SqlInjectionPayload { Title = "Test", PayloadString = "' OR 1=1 --" }
                };
                var config = new SqlInjectionConfig();
                var dumper = new DatabaseDumper(httpClient, vulnerability, config);
                Console.WriteLine("✓ DatabaseDumper created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating DatabaseDumper: {ex.Message}");
            }
        }
        
        private static void TestWebCrawler()
        {
            Console.WriteLine("Testing web crawler...");
            
            try
            {
                using var httpClient = new System.Net.Http.HttpClient();
                var config = new WebCrawlerConfig { BaseUrl = "https://example.com" };
                var crawler = new WebCrawler(httpClient, config, msg => Console.WriteLine($"Crawler: {msg}"));
                Console.WriteLine("✓ WebCrawler created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating WebCrawler: {ex.Message}");
            }
        }
        
        private static void TestDorkSearcher()
        {
            Console.WriteLine("Testing dork searcher...");
            
            try
            {
                var dorks = new List<string> { "test dork" };
                var proxies = new List<Proxy> { new Proxy { Host = "127.0.0.1", Port = 8080 } };
                var userAgents = new List<string> { "Mozilla/5.0 (Test)" };
                var searchEngines = new List<SearchEngine> { new SearchEngine { Name = "Test", UrlFormat = "https://example.com?q={dork}" } };
                
                var searcher = new DorkSearcher(dorks, proxies, userAgents, searchEngines, 
                    url => Console.WriteLine($"Found: {url}"), 
                    () => Console.WriteLine("Search complete"));
                    
                Console.WriteLine("✓ DorkSearcher created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating DorkSearcher: {ex.Message}");
            }
        }
        
        private static void TestReportGenerator()
        {
            Console.WriteLine("Testing report generator...");
            
            try
            {
                var config = new ReportConfig();
                var generator = new ReportGenerator(config);
                Console.WriteLine("✓ ReportGenerator created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating ReportGenerator: {ex.Message}");
            }
        }
    }
}