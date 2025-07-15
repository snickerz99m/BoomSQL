using System;
using System.Collections.Generic;

namespace BoomSQL.Core
{
    public class SqlInjectionPayload
    {
        public string Title { get; set; } = "";
        public string PayloadString { get; set; } = "";
        public int Risk { get; set; } = 1;
        public string Platform { get; set; } = "generic";
        public string Category { get; set; } = "generic";
    }

    public class SqlInjectionResult
    {
        public string Url { get; set; } = "";
        public bool IsVulnerable { get; set; } = false;
        public List<VulnerabilityDetails> Vulnerabilities { get; set; } = new();
        public List<string> Errors { get; set; } = new();
        public int TotalPayloadsTested { get; set; } = 0;
        public DateTime TestStartTime { get; set; } = DateTime.UtcNow;
        public TimeSpan TestDuration { get; set; } = TimeSpan.Zero;
    }

    public class VulnerabilityDetails
    {
        public SqlInjectionPayload Payload { get; set; } = new();
        public InjectionPoint InjectionPoint { get; set; } = new();
        public string HttpMethod { get; set; } = "";
        public TimeSpan ResponseTime { get; set; } = TimeSpan.Zero;
        public int ResponseCode { get; set; } = 0;
        public string DetectionMethod { get; set; } = "";
        public double Confidence { get; set; } = 0.0;
        public string DatabaseType { get; set; } = "";
        public string VulnerabilityType { get; set; } = "";
        public string Evidence { get; set; } = "";
        public string Response { get; set; } = "";
        public string BypassMethod { get; set; } = "";
    }

    public class InjectionPoint
    {
        public InjectionPointType Type { get; set; } = InjectionPointType.UrlParameter;
        public string Name { get; set; } = "";
        public string Value { get; set; } = "";
    }

    public enum InjectionPointType
    {
        UrlParameter,
        PostParameter,
        Header,
        Cookie,
        JsonParameter,
        XmlParameter
    }

    public class DetectionResult
    {
        public bool IsVulnerable { get; set; } = false;
        public string DetectionMethod { get; set; } = "";
        public double Confidence { get; set; } = 0.0;
        public string DatabaseType { get; set; } = "";
        public string VulnerabilityType { get; set; } = "";
        public string Evidence { get; set; } = "";
    }

    public class ErrorSignature
    {
        public string Database { get; set; } = "";
        public string Severity { get; set; } = "";
        public List<string> Patterns { get; set; } = new();
    }

    public class WafBypass
    {
        public string Category { get; set; } = "";
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public Func<string, string> Apply { get; set; } = payload => payload;
    }

    public class SqlInjectionConfig
    {
        public bool EnableWafBypasses { get; set; } = true;
        public bool EnableTimeBasedDetection { get; set; } = true;
        public bool EnableErrorBasedDetection { get; set; } = true;
        public bool EnableBooleanBasedDetection { get; set; } = true;
        public bool EnableUnionBasedDetection { get; set; } = true;
        public bool EnableContentLengthDetection { get; set; } = true;
        public bool EnableHeaderInjection { get; set; } = true;
        public bool EnableCookieInjection { get; set; } = true;
        public bool EnableJsonInjection { get; set; } = true;
        public bool EnableXmlInjection { get; set; } = true;
        public int MaxThreads { get; set; } = 5;
        public int RequestTimeout { get; set; } = 30;
        public double TimeBasedThreshold { get; set; } = 3.0;
        public bool UseProxyRotation { get; set; } = false;
        public bool UseUserAgentRotation { get; set; } = false;
        public int RequestDelay { get; set; } = 1000;
        public bool EnableVerboseLogging { get; set; } = false;
        public string[] AllowedDatabases { get; set; } = { "mysql", "mssql", "oracle", "postgresql", "sqlite", "mongodb" };
        public string[] AllowedCategories { get; set; } = { "error", "boolean", "time", "union", "stacked", "outofband" };
        public int MaxPayloadsPerUrl { get; set; } = 100;
        public bool EnableSecondOrderDetection { get; set; } = false;
        public bool EnableFileInclusionDetection { get; set; } = false;
        public bool EnableCommandInjectionDetection { get; set; } = false;
        public bool EnableLdapInjectionDetection { get; set; } = false;
        public bool EnableXpathInjectionDetection { get; set; } = false;
        public bool EnableNoSqlInjectionDetection { get; set; } = false;
    }

    public class TestResult
    {
        public string Url { get; set; } = "";
        public SqlInjectionPayload Payload { get; set; } = new();
        public bool IsVulnerable { get; set; } = false;
        public int ResponseTime { get; set; } = 0;
        public int ResponseCode { get; set; } = 0;
        public string DetectionMethod { get; set; } = "";
        public double Confidence { get; set; } = 0.0;
        public string DatabaseType { get; set; } = "";
        public string Evidence { get; set; } = "";
        public string Response { get; set; } = "";
        public DateTime TestTime { get; set; } = DateTime.UtcNow;
    }

    public class DatabaseStructure
    {
        public string DatabaseName { get; set; } = "";
        public string DatabaseType { get; set; } = "";
        public string Version { get; set; } = "";
        public string CurrentUser { get; set; } = "";
        public List<string> Privileges { get; set; } = new();
        public List<DatabaseTable> Tables { get; set; } = new();
        public List<DatabaseUser> Users { get; set; } = new();
        public Dictionary<string, string> SystemVariables { get; set; } = new();
    }

    public class DatabaseTable
    {
        public string Name { get; set; } = "";
        public string Schema { get; set; } = "";
        public List<DatabaseColumn> Columns { get; set; } = new();
        public int RowCount { get; set; } = 0;
        public List<Dictionary<string, object>> Data { get; set; } = new();
    }

    public class DatabaseColumn
    {
        public string Name { get; set; } = "";
        public string DataType { get; set; } = "";
        public bool IsNullable { get; set; } = true;
        public bool IsPrimaryKey { get; set; } = false;
        public bool IsUnique { get; set; } = false;
        public string DefaultValue { get; set; } = "";
    }

    public class DatabaseUser
    {
        public string Username { get; set; } = "";
        public string Host { get; set; } = "";
        public List<string> Privileges { get; set; } = new();
        public bool IsAdmin { get; set; } = false;
    }

    public class Proxy
    {
        public string Host { get; set; } = "";
        public int Port { get; set; } = 8080;
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Type { get; set; } = "HTTP";
        public bool IsActive { get; set; } = true;
    }

    public class CrawlerResult
    {
        public string Url { get; set; } = "";
        public List<string> DiscoveredUrls { get; set; } = new();
        public List<string> Forms { get; set; } = new();
        public List<string> Parameters { get; set; } = new();
        public List<string> Cookies { get; set; } = new();
        public List<string> Headers { get; set; } = new();
        public int Depth { get; set; } = 0;
        public DateTime CrawlTime { get; set; } = DateTime.UtcNow;
        public List<string> Errors { get; set; } = new();
    }

    public class DumpResult
    {
        public string TableName { get; set; } = "";
        public List<Dictionary<string, object>> Data { get; set; } = new();
        public int TotalRows { get; set; } = 0;
        public int ExtractedRows { get; set; } = 0;
        public TimeSpan DumpDuration { get; set; } = TimeSpan.Zero;
        public bool IsComplete { get; set; } = false;
        public List<string> Errors { get; set; } = new();
    }

    public class ExploitResult
    {
        public string ExploitType { get; set; } = "";
        public bool IsSuccessful { get; set; } = false;
        public string Output { get; set; } = "";
        public string Command { get; set; } = "";
        public List<string> Evidence { get; set; } = new();
        public DateTime ExploitTime { get; set; } = DateTime.UtcNow;
        public string Error { get; set; } = "";
    }

    public class ReportData
    {
        public string TargetUrl { get; set; } = "";
        public List<VulnerabilityDetails> Vulnerabilities { get; set; } = new();
        public DatabaseStructure Database { get; set; } = new();
        public List<ExploitResult> Exploits { get; set; } = new();
        public DateTime ScanStartTime { get; set; } = DateTime.UtcNow;
        public DateTime ScanEndTime { get; set; } = DateTime.UtcNow;
        public TimeSpan TotalDuration { get; set; } = TimeSpan.Zero;
        public int TotalPayloadsTested { get; set; } = 0;
        public int TotalVulnerabilitiesFound { get; set; } = 0;
        public string ScannerVersion { get; set; } = "BoomSQL 1.0";
        public List<string> RecommendedFixes { get; set; } = new();
        public Dictionary<string, object> Metadata { get; set; } = new();
    }
}