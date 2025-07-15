using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoomSQL.Core
{
    public class ReportGenerator
    {
        private readonly ReportConfig _config;

        public ReportGenerator(ReportConfig config)
        {
            _config = config;
        }

        public async Task<string> GenerateReportAsync(ReportData reportData, string format, string outputPath)
        {
            try
            {
                return format.ToLower() switch
                {
                    "html" => await GenerateHtmlReportAsync(reportData, outputPath),
                    "json" => await GenerateJsonReportAsync(reportData, outputPath),
                    "xml" => await GenerateXmlReportAsync(reportData, outputPath),
                    "csv" => await GenerateCsvReportAsync(reportData, outputPath),
                    "txt" => await GenerateTextReportAsync(reportData, outputPath),
                    _ => throw new ArgumentException($"Unsupported format: {format}")
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Report generation failed: {ex.Message}", ex);
            }
        }

        private async Task<string> GenerateHtmlReportAsync(ReportData reportData, string outputPath)
        {
            var html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html>");
            html.AppendLine("<head>");
            html.AppendLine("    <title>BoomSQL Security Assessment Report</title>");
            html.AppendLine("    <meta charset=\"UTF-8\">");
            html.AppendLine("    <style>");
            html.AppendLine(GetHtmlStyles());
            html.AppendLine("    </style>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");
            html.AppendLine("    <div class=\"container\">");
            
            // Header
            html.AppendLine("        <div class=\"header\">");
            html.AppendLine("            <h1>BoomSQL Security Assessment Report</h1>");
            html.AppendLine($"            <p>Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}</p>");
            html.AppendLine($"            <p>Target: {reportData.TargetUrl}</p>");
            html.AppendLine("        </div>");
            
            // Executive Summary
            html.AppendLine("        <div class=\"section\">");
            html.AppendLine("            <h2>Executive Summary</h2>");
            html.AppendLine($"            <p><strong>Total Vulnerabilities Found:</strong> {reportData.TotalVulnerabilitiesFound}</p>");
            html.AppendLine($"            <p><strong>Scan Duration:</strong> {reportData.TotalDuration}</p>");
            html.AppendLine($"            <p><strong>Payloads Tested:</strong> {reportData.TotalPayloadsTested}</p>");
            html.AppendLine("        </div>");
            
            // Risk Assessment
            html.AppendLine("        <div class=\"section\">");
            html.AppendLine("            <h2>Risk Assessment</h2>");
            html.AppendLine("            <table class=\"risk-table\">");
            html.AppendLine("                <tr><th>Severity</th><th>Count</th><th>Risk Level</th></tr>");
            
            var riskLevels = new Dictionary<string, int>
            {
                { "Critical", reportData.Vulnerabilities.Count(v => v.Payload.Risk >= 4) },
                { "High", reportData.Vulnerabilities.Count(v => v.Payload.Risk == 3) },
                { "Medium", reportData.Vulnerabilities.Count(v => v.Payload.Risk == 2) },
                { "Low", reportData.Vulnerabilities.Count(v => v.Payload.Risk == 1) }
            };
            
            foreach (var risk in riskLevels)
            {
                var cssClass = risk.Key.ToLower();
                html.AppendLine($"                <tr class=\"{cssClass}\"><td>{risk.Key}</td><td>{risk.Value}</td><td>{GetRiskDescription(risk.Key)}</td></tr>");
            }
            
            html.AppendLine("            </table>");
            html.AppendLine("        </div>");
            
            // Vulnerabilities
            html.AppendLine("        <div class=\"section\">");
            html.AppendLine("            <h2>Vulnerabilities Found</h2>");
            
            foreach (var vulnerability in reportData.Vulnerabilities)
            {
                html.AppendLine("            <div class=\"vulnerability\">");
                html.AppendLine($"                <h3>{vulnerability.VulnerabilityType}</h3>");
                html.AppendLine($"                <p><strong>URL:</strong> {vulnerability.InjectionPoint.Name}</p>");
                html.AppendLine($"                <p><strong>Parameter:</strong> {vulnerability.InjectionPoint.Name}</p>");
                html.AppendLine($"                <p><strong>Payload:</strong> <code>{vulnerability.Payload.PayloadString}</code></p>");
                html.AppendLine($"                <p><strong>Detection Method:</strong> {vulnerability.DetectionMethod}</p>");
                html.AppendLine($"                <p><strong>Confidence:</strong> {vulnerability.Confidence:P0}</p>");
                html.AppendLine($"                <p><strong>Database Type:</strong> {vulnerability.DatabaseType}</p>");
                html.AppendLine($"                <p><strong>Risk Level:</strong> {GetRiskName(vulnerability.Payload.Risk)}</p>");
                html.AppendLine($"                <p><strong>Response Time:</strong> {vulnerability.ResponseTime.TotalMilliseconds:F0}ms</p>");
                html.AppendLine($"                <p><strong>Evidence:</strong> {vulnerability.Evidence}</p>");
                if (!string.IsNullOrEmpty(vulnerability.BypassMethod))
                {
                    html.AppendLine($"                <p><strong>WAF Bypass Method:</strong> {vulnerability.BypassMethod}</p>");
                }
                html.AppendLine("            </div>");
            }
            
            html.AppendLine("        </div>");
            
            // Database Structure
            if (reportData.Database != null && reportData.Database.Tables.Any())
            {
                html.AppendLine("        <div class=\"section\">");
                html.AppendLine("            <h2>Database Structure</h2>");
                html.AppendLine($"            <p><strong>Database Type:</strong> {reportData.Database.DatabaseType}</p>");
                html.AppendLine($"            <p><strong>Database Name:</strong> {reportData.Database.DatabaseName}</p>");
                html.AppendLine($"            <p><strong>Current User:</strong> {reportData.Database.CurrentUser}</p>");
                html.AppendLine($"            <p><strong>Tables Found:</strong> {reportData.Database.Tables.Count}</p>");
                
                html.AppendLine("            <h3>Tables</h3>");
                foreach (var table in reportData.Database.Tables)
                {
                    html.AppendLine("            <div class=\"table-info\">");
                    html.AppendLine($"                <h4>{table.Name} ({table.RowCount} rows)</h4>");
                    html.AppendLine("                <table class=\"columns-table\">");
                    html.AppendLine("                    <tr><th>Column</th><th>Type</th><th>Nullable</th></tr>");
                    
                    foreach (var column in table.Columns)
                    {
                        html.AppendLine($"                    <tr><td>{column.Name}</td><td>{column.DataType}</td><td>{column.IsNullable}</td></tr>");
                    }
                    
                    html.AppendLine("                </table>");
                    html.AppendLine("            </div>");
                }
                
                html.AppendLine("        </div>");
            }
            
            // Recommendations
            html.AppendLine("        <div class=\"section\">");
            html.AppendLine("            <h2>Recommendations</h2>");
            html.AppendLine(GetRecommendationsHtml(reportData));
            html.AppendLine("        </div>");
            
            // Footer
            html.AppendLine("        <div class=\"footer\">");
            html.AppendLine($"            <p>Report generated by {reportData.ScannerVersion}</p>");
            html.AppendLine($"            <p>Scan completed on {reportData.ScanEndTime:yyyy-MM-dd HH:mm:ss}</p>");
            html.AppendLine("        </div>");
            
            html.AppendLine("    </div>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");
            
            await File.WriteAllTextAsync(outputPath, html.ToString());
            return outputPath;
        }

        private async Task<string> GenerateJsonReportAsync(ReportData reportData, string outputPath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var json = JsonSerializer.Serialize(reportData, options);
            await File.WriteAllTextAsync(outputPath, json);
            return outputPath;
        }

        private async Task<string> GenerateXmlReportAsync(ReportData reportData, string outputPath)
        {
            var doc = new XDocument(
                new XElement("SecurityReport",
                    new XAttribute("generated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    new XAttribute("target", reportData.TargetUrl),
                    new XAttribute("scanner", reportData.ScannerVersion),
                    
                    new XElement("Summary",
                        new XElement("TotalVulnerabilities", reportData.TotalVulnerabilitiesFound),
                        new XElement("ScanDuration", reportData.TotalDuration.ToString()),
                        new XElement("PayloadsTested", reportData.TotalPayloadsTested)
                    ),
                    
                    new XElement("Vulnerabilities",
                        reportData.Vulnerabilities.Select(v =>
                            new XElement("Vulnerability",
                                new XElement("Type", v.VulnerabilityType),
                                new XElement("DetectionMethod", v.DetectionMethod),
                                new XElement("Confidence", v.Confidence),
                                new XElement("DatabaseType", v.DatabaseType),
                                new XElement("InjectionPoint", v.InjectionPoint.Name),
                                new XElement("Payload", v.Payload.PayloadString),
                                new XElement("Risk", v.Payload.Risk),
                                new XElement("Platform", v.Payload.Platform),
                                new XElement("ResponseTime", v.ResponseTime.TotalMilliseconds),
                                new XElement("Evidence", v.Evidence),
                                new XElement("BypassMethod", v.BypassMethod ?? "")
                            )
                        )
                    ),
                    
                    new XElement("Database",
                        new XElement("Type", reportData.Database?.DatabaseType ?? ""),
                        new XElement("Name", reportData.Database?.DatabaseName ?? ""),
                        new XElement("CurrentUser", reportData.Database?.CurrentUser ?? ""),
                        new XElement("Tables",
                            reportData.Database?.Tables.Select(t =>
                                new XElement("Table",
                                    new XAttribute("name", t.Name),
                                    new XAttribute("rows", t.RowCount),
                                    new XElement("Columns",
                                        t.Columns.Select(c =>
                                            new XElement("Column",
                                                new XAttribute("name", c.Name),
                                                new XAttribute("type", c.DataType),
                                                new XAttribute("nullable", c.IsNullable)
                                            )
                                        )
                                    )
                                )
                            )
                        )
                    ),
                    
                    new XElement("Recommendations",
                        reportData.RecommendedFixes.Select(fix =>
                            new XElement("Recommendation", fix)
                        )
                    )
                )
            );

            await File.WriteAllTextAsync(outputPath, doc.ToString());
            return outputPath;
        }

        private async Task<string> GenerateCsvReportAsync(ReportData reportData, string outputPath)
        {
            var csv = new StringBuilder();
            csv.AppendLine("URL,Vulnerability Type,Detection Method,Confidence,Database Type,Risk Level,Response Time,Evidence,Bypass Method");
            
            foreach (var vulnerability in reportData.Vulnerabilities)
            {
                csv.AppendLine($"\"{vulnerability.InjectionPoint.Name}\"," +
                              $"\"{vulnerability.VulnerabilityType}\"," +
                              $"\"{vulnerability.DetectionMethod}\"," +
                              $"{vulnerability.Confidence:P0}," +
                              $"\"{vulnerability.DatabaseType}\"," +
                              $"{vulnerability.Payload.Risk}," +
                              $"{vulnerability.ResponseTime.TotalMilliseconds:F0}," +
                              $"\"{vulnerability.Evidence}\"," +
                              $"\"{vulnerability.BypassMethod ?? ""}\"");
            }
            
            await File.WriteAllTextAsync(outputPath, csv.ToString());
            return outputPath;
        }

        private async Task<string> GenerateTextReportAsync(ReportData reportData, string outputPath)
        {
            var text = new StringBuilder();
            text.AppendLine("BoomSQL Security Assessment Report");
            text.AppendLine("===================================");
            text.AppendLine();
            text.AppendLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            text.AppendLine($"Target: {reportData.TargetUrl}");
            text.AppendLine($"Scanner: {reportData.ScannerVersion}");
            text.AppendLine();
            
            text.AppendLine("EXECUTIVE SUMMARY");
            text.AppendLine("-----------------");
            text.AppendLine($"Total Vulnerabilities: {reportData.TotalVulnerabilitiesFound}");
            text.AppendLine($"Scan Duration: {reportData.TotalDuration}");
            text.AppendLine($"Payloads Tested: {reportData.TotalPayloadsTested}");
            text.AppendLine();
            
            text.AppendLine("VULNERABILITIES FOUND");
            text.AppendLine("---------------------");
            
            foreach (var vulnerability in reportData.Vulnerabilities)
            {
                text.AppendLine($"• {vulnerability.VulnerabilityType}");
                text.AppendLine($"  URL: {vulnerability.InjectionPoint.Name}");
                text.AppendLine($"  Detection Method: {vulnerability.DetectionMethod}");
                text.AppendLine($"  Confidence: {vulnerability.Confidence:P0}");
                text.AppendLine($"  Database Type: {vulnerability.DatabaseType}");
                text.AppendLine($"  Risk Level: {GetRiskName(vulnerability.Payload.Risk)}");
                text.AppendLine($"  Response Time: {vulnerability.ResponseTime.TotalMilliseconds:F0}ms");
                text.AppendLine($"  Evidence: {vulnerability.Evidence}");
                if (!string.IsNullOrEmpty(vulnerability.BypassMethod))
                {
                    text.AppendLine($"  WAF Bypass: {vulnerability.BypassMethod}");
                }
                text.AppendLine();
            }
            
            if (reportData.Database != null && reportData.Database.Tables.Any())
            {
                text.AppendLine("DATABASE STRUCTURE");
                text.AppendLine("------------------");
                text.AppendLine($"Database Type: {reportData.Database.DatabaseType}");
                text.AppendLine($"Database Name: {reportData.Database.DatabaseName}");
                text.AppendLine($"Current User: {reportData.Database.CurrentUser}");
                text.AppendLine($"Tables Found: {reportData.Database.Tables.Count}");
                text.AppendLine();
                
                foreach (var table in reportData.Database.Tables)
                {
                    text.AppendLine($"Table: {table.Name} ({table.RowCount} rows)");
                    foreach (var column in table.Columns)
                    {
                        text.AppendLine($"  - {column.Name} ({column.DataType})");
                    }
                    text.AppendLine();
                }
            }
            
            text.AppendLine("RECOMMENDATIONS");
            text.AppendLine("---------------");
            foreach (var fix in reportData.RecommendedFixes)
            {
                text.AppendLine($"• {fix}");
            }
            
            await File.WriteAllTextAsync(outputPath, text.ToString());
            return outputPath;
        }

        private string GetHtmlStyles()
        {
            return @"
                body { font-family: Arial, sans-serif; margin: 0; padding: 20px; background-color: #f5f5f5; }
                .container { max-width: 1200px; margin: 0 auto; background-color: white; padding: 20px; border-radius: 8px; box-shadow: 0 2px 4px rgba(0,0,0,0.1); }
                .header { text-align: center; border-bottom: 2px solid #333; padding-bottom: 20px; margin-bottom: 30px; }
                .header h1 { color: #333; margin: 0; }
                .section { margin-bottom: 30px; }
                .section h2 { color: #333; border-bottom: 1px solid #ccc; padding-bottom: 10px; }
                .vulnerability { border: 1px solid #ddd; padding: 15px; margin-bottom: 15px; border-radius: 5px; background-color: #fafafa; }
                .vulnerability h3 { color: #d32f2f; margin-top: 0; }
                .risk-table, .columns-table { width: 100%; border-collapse: collapse; margin-top: 10px; }
                .risk-table th, .risk-table td, .columns-table th, .columns-table td { padding: 8px; border: 1px solid #ddd; text-align: left; }
                .risk-table th, .columns-table th { background-color: #f0f0f0; font-weight: bold; }
                .critical { background-color: #ffebee; }
                .high { background-color: #fff3e0; }
                .medium { background-color: #f3e5f5; }
                .low { background-color: #e8f5e8; }
                .table-info { margin-bottom: 20px; }
                .table-info h4 { color: #555; margin-bottom: 10px; }
                code { background-color: #f5f5f5; padding: 2px 4px; border-radius: 3px; font-family: monospace; }
                .footer { text-align: center; margin-top: 30px; padding-top: 20px; border-top: 1px solid #ccc; color: #666; }
            ";
        }

        private string GetRiskName(int risk)
        {
            return risk switch
            {
                4 => "Critical",
                3 => "High",
                2 => "Medium",
                1 => "Low",
                _ => "Unknown"
            };
        }

        private string GetRiskDescription(string risk)
        {
            return risk switch
            {
                "Critical" => "Immediate action required. Severe security risk.",
                "High" => "High priority. Significant security risk.",
                "Medium" => "Medium priority. Moderate security risk.",
                "Low" => "Low priority. Minor security risk.",
                _ => "Unknown risk level."
            };
        }

        private string GetRecommendationsHtml(ReportData reportData)
        {
            var recommendations = new List<string>
            {
                "Implement parameterized queries (prepared statements) to prevent SQL injection",
                "Use input validation and sanitization for all user inputs",
                "Apply the principle of least privilege to database connections",
                "Implement proper error handling to avoid information disclosure",
                "Use Web Application Firewalls (WAF) to filter malicious requests",
                "Regularly update and patch database management systems",
                "Implement proper logging and monitoring for security events",
                "Conduct regular security assessments and penetration testing",
                "Use stored procedures where appropriate",
                "Implement proper authentication and authorization mechanisms"
            };

            var html = new StringBuilder();
            html.AppendLine("<ul>");
            foreach (var recommendation in recommendations)
            {
                html.AppendLine($"<li>{recommendation}</li>");
            }
            html.AppendLine("</ul>");
            return html.ToString();
        }
    }

    public class ReportConfig
    {
        public bool EnableDetailedReports { get; set; } = true;
        public bool EnableRiskAssessment { get; set; } = true;
        public bool EnableCvssScoring { get; set; } = true;
        public bool EnableRemediationSuggestions { get; set; } = true;
        public bool EnableProofOfConcept { get; set; } = true;
        public bool EnableTimelineAnalysis { get; set; } = true;
        public bool EnableAttackVectorMapping { get; set; } = true;
        public bool EnableComplianceReporting { get; set; } = true;
        public List<string> ReportFormats { get; set; } = new() { "html", "json", "xml", "csv", "txt" };
        public string DefaultFormat { get; set; } = "html";
        public string OutputDirectory { get; set; } = "reports";
        public string ReportTemplate { get; set; } = "standard";
        public bool EnableAutoExport { get; set; } = false;
        public bool IncludeScreenshots { get; set; } = false;
        public bool IncludePayloads { get; set; } = true;
        public bool IncludeResponses { get; set; } = false;
        public bool IncludeDatabaseStructure { get; set; } = true;
        public bool IncludeRecommendations { get; set; } = true;
        public bool IncludeExecutiveSummary { get; set; } = true;
        public bool IncludeRiskAssessment { get; set; } = true;
        public bool IncludeVulnerabilityDetails { get; set; } = true;
        public bool IncludeTimelineAnalysis { get; set; } = true;
        public bool IncludeAttackVectors { get; set; } = true;
        public bool IncludeComplianceSection { get; set; } = true;
        public bool IncludeAppendix { get; set; } = true;
        public bool IncludeGlossary { get; set; } = true;
        public bool IncludeReferences { get; set; } = true;
        public bool IncludeContactInfo { get; set; } = true;
        public bool IncludeDisclaimer { get; set; } = true;
        public bool IncludeMetadata { get; set; } = true;
        public bool IncludeStatistics { get; set; } = true;
        public bool IncludeCharts { get; set; } = true;
        public bool IncludeGraphs { get; set; } = true;
        public bool IncludeTables { get; set; } = true;
        public bool IncludeImages { get; set; } = true;
        public bool IncludeCode { get; set; } = true;
        public bool IncludeCommands { get; set; } = true;
        public bool IncludeConfigurations { get; set; } = true;
        public bool IncludeSettings { get; set; } = true;
        public bool IncludeOptions { get; set; } = true;
        public bool IncludeParameters { get; set; } = true;
        public bool IncludeVariables { get; set; } = true;
        public bool IncludeConstants { get; set; } = true;
        public bool IncludeEnums { get; set; } = true;
        public bool IncludeStructures { get; set; } = true;
        public bool IncludeClasses { get; set; } = true;
        public bool IncludeInterfaces { get; set; } = true;
        public bool IncludeMethods { get; set; } = true;
        public bool IncludeFunctions { get; set; } = true;
        public bool IncludeProcedures { get; set; } = true;
        public bool IncludeRoutines { get; set; } = true;
        public bool IncludeSubroutines { get; set; } = true;
        public bool IncludeMacros { get; set; } = true;
        public bool IncludeTemplates { get; set; } = true;
        public bool IncludePatterns { get; set; } = true;
        public bool IncludeModels { get; set; } = true;
        public bool IncludeEntities { get; set; } = true;
        public bool IncludeRecords { get; set; } = true;
        public bool IncludeRows { get; set; } = true;
        public bool IncludeColumns { get; set; } = true;
        public bool IncludeFields { get; set; } = true;
        public bool IncludeAttributes { get; set; } = true;
        public bool IncludeProperties { get; set; } = true;
        public bool IncludeValues { get; set; } = true;
        public bool IncludeData { get; set; } = true;
        public bool IncludeInformation { get; set; } = true;
        public bool IncludeContent { get; set; } = true;
        public bool IncludeText { get; set; } = true;
        public bool IncludeStrings { get; set; } = true;
        public bool IncludeNumbers { get; set; } = true;
        public bool IncludeIntegers { get; set; } = true;
        public bool IncludeFloats { get; set; } = true;
        public bool IncludeDecimals { get; set; } = true;
        public bool IncludeBooleans { get; set; } = true;
        public bool IncludeDates { get; set; } = true;
        public bool IncludeTimes { get; set; } = true;
        public bool IncludeTimestamps { get; set; } = true;
        public bool IncludeDatetimes { get; set; } = true;
        public bool IncludeYears { get; set; } = true;
        public bool IncludeMonths { get; set; } = true;
        public bool IncludeDays { get; set; } = true;
        public bool IncludeHours { get; set; } = true;
        public bool IncludeMinutes { get; set; } = true;
        public bool IncludeSeconds { get; set; } = true;
        public bool IncludeMilliseconds { get; set; } = true;
        public bool IncludeMicroseconds { get; set; } = true;
        public bool IncludeNanoseconds { get; set; } = true;
        public bool IncludeTimezones { get; set; } = true;
        public bool IncludeLocales { get; set; } = true;
        public bool IncludeLanguages { get; set; } = true;
        public bool IncludeCountries { get; set; } = true;
        public bool IncludeRegions { get; set; } = true;
        public bool IncludeCurrencies { get; set; } = true;
        public bool IncludeMoney { get; set; } = true;
        public bool IncludePrices { get; set; } = true;
        public bool IncludeCosts { get; set; } = true;
        public bool IncludeAmounts { get; set; } = true;
        public bool IncludeQuantities { get; set; } = true;
        public bool IncludeCounts { get; set; } = true;
        public bool IncludeSums { get; set; } = true;
        public bool IncludeAverages { get; set; } = true;
        public bool IncludeMinimums { get; set; } = true;
        public bool IncludeMaximums { get; set; } = true;
        public bool IncludeTotals { get; set; } = true;
        public bool IncludeSubtotals { get; set; } = true;
        public bool IncludeGrandTotals { get; set; } = true;
        public bool IncludeBalances { get; set; } = true;
        public bool IncludeCredits { get; set; } = true;
        public bool IncludeDebits { get; set; } = true;
        public bool IncludeTransactions { get; set; } = true;
        public bool IncludePayments { get; set; } = true;
        public bool IncludeInvoices { get; set; } = true;
        public bool IncludeReceipts { get; set; } = true;
        public bool IncludeOrders { get; set; } = true;
        public bool IncludePurchases { get; set; } = true;
        public bool IncludeSales { get; set; } = true;
        public bool IncludeProducts { get; set; } = true;
        public bool IncludeItems { get; set; } = true;
        public bool IncludeServices { get; set; } = true;
        public bool IncludeCategories { get; set; } = true;
        public bool IncludeGroups { get; set; } = true;
        public bool IncludeTypes { get; set; } = true;
        public bool IncludeKinds { get; set; } = true;
        public bool IncludeSorts { get; set; } = true;
        public bool IncludeStatuses { get; set; } = true;
        public bool IncludeStates { get; set; } = true;
        public bool IncludeConditions { get; set; } = true;
        public bool IncludeFlags { get; set; } = true;
        public bool IncludeMarkers { get; set; } = true;
        public bool IncludeIndicators { get; set; } = true;
        public bool IncludeSignals { get; set; } = true;
        public bool IncludeAlerts { get; set; } = true;
        public bool IncludeNotifications { get; set; } = true;
        public bool IncludeMessages { get; set; } = true;
        public bool IncludeEmails { get; set; } = true;
        public bool IncludeMails { get; set; } = true;
        public bool IncludeAddresses { get; set; } = true;
        public bool IncludePhones { get; set; } = true;
        public bool IncludeFaxes { get; set; } = true;
        public bool IncludeMobiles { get; set; } = true;
        public bool IncludeContacts { get; set; } = true;
        public bool IncludePersons { get; set; } = true;
        public bool IncludeIndividuals { get; set; } = true;
        public bool IncludeCustomers { get; set; } = true;
        public bool IncludeClients { get; set; } = true;
        public bool IncludeUsers { get; set; } = true;
        public bool IncludeMembers { get; set; } = true;
        public bool IncludeAccounts { get; set; } = true;
        public bool IncludeProfiles { get; set; } = true;
        public bool IncludeIdentities { get; set; } = true;
        public bool IncludeCredentials { get; set; } = true;
        public bool IncludeAuthentications { get; set; } = true;
        public bool IncludeAuthorizations { get; set; } = true;
        public bool IncludeAccesses { get; set; } = true;
        public bool IncludePermissions { get; set; } = true;
        public bool IncludePrivileges { get; set; } = true;
        public bool IncludeRights { get; set; } = true;
        public bool IncludePolicies { get; set; } = true;
        public bool IncludeRules { get; set; } = true;
        public bool IncludeConstraints { get; set; } = true;
        public bool IncludeValidations { get; set; } = true;
        public bool IncludeVerifications { get; set; } = true;
        public bool IncludeChecks { get; set; } = true;
        public bool IncludeTests { get; set; } = true;
        public bool IncludeAudits { get; set; } = true;
        public bool IncludeLogs { get; set; } = true;
        public bool IncludeHistories { get; set; } = true;
        public bool IncludeTraces { get; set; } = true;
        public bool IncludeDebugs { get; set; } = true;
        public bool IncludeErrors { get; set; } = true;
        public bool IncludeExceptions { get; set; } = true;
        public bool IncludeWarnings { get; set; } = true;
        public bool IncludeInfos { get; set; } = true;
        public bool IncludeNotices { get; set; } = true;
        public bool IncludeEvents { get; set; } = true;
        public bool IncludeActions { get; set; } = true;
        public bool IncludeOperations { get; set; } = true;
        public bool IncludeActivities { get; set; } = true;
        public bool IncludeBehaviors { get; set; } = true;
        public bool IncludeWorkflows { get; set; } = true;
        public bool IncludeProcesses { get; set; } = true;
        public bool IncludeProtocols { get; set; } = true;
        public bool IncludeStandards { get; set; } = true;
        public bool IncludeSpecifications { get; set; } = true;
        public bool IncludeRequirements { get; set; } = true;
        public bool IncludeDesigns { get; set; } = true;
        public bool IncludeArchitectures { get; set; } = true;
        public bool IncludeStructures { get; set; } = true;
        public bool IncludeOrganizations { get; set; } = true;
        public bool IncludeHierarchies { get; set; } = true;
        public bool IncludeTrees { get; set; } = true;
        public bool IncludeGraphs { get; set; } = true;
        public bool IncludeNetworks { get; set; } = true;
        public bool IncludeConnections { get; set; } = true;
        public bool IncludeRelationships { get; set; } = true;
        public bool IncludeAssociations { get; set; } = true;
        public bool IncludeLinks { get; set; } = true;
        public bool IncludeReferences { get; set; } = true;
        public bool IncludePointers { get; set; } = true;
        public bool IncludeIndexes { get; set; } = true;
        public bool IncludeKeys { get; set; } = true;
        public bool IncludeIdentifiers { get; set; } = true;
        public bool IncludeIds { get; set; } = true;
        public bool IncludeUuids { get; set; } = true;
        public bool IncludeGuids { get; set; } = true;
        public bool IncludeHashes { get; set; } = true;
        public bool IncludeChecksums { get; set; } = true;
        public bool IncludeSignatures { get; set; } = true;
        public bool IncludeTokens { get; set; } = true;
        public bool IncludeTickets { get; set; } = true;
        public bool IncludeVouchers { get; set; } = true;
        public bool IncludeCoupons { get; set; } = true;
        public bool IncludeCodes { get; set; } = true;
        public bool IncludeSerials { get; set; } = true;
        public bool IncludeVersions { get; set; } = true;
        public bool IncludeRevisions { get; set; } = true;
        public bool IncludeBuilds { get; set; } = true;
        public bool IncludeReleases { get; set; } = true;
        public bool IncludeTags { get; set; } = true;
        public bool IncludeLabels { get; set; } = true;
        public bool IncludeNames { get; set; } = true;
        public bool IncludeTitles { get; set; } = true;
        public bool IncludeCaptions { get; set; } = true;
        public bool IncludeDescriptions { get; set; } = true;
        public bool IncludeSummaries { get; set; } = true;
        public bool IncludeAbstracts { get; set; } = true;
        public bool IncludeOverviews { get; set; } = true;
        public bool IncludeIntroductions { get; set; } = true;
        public bool IncludePrefaces { get; set; } = true;
        public bool IncludeForewords { get; set; } = true;
        public bool IncludePrologues { get; set; } = true;
        public bool IncludeEpilogues { get; set; } = true;
        public bool IncludeConclusions { get; set; } = true;
        public bool IncludeResults { get; set; } = true;
        public bool IncludeOutcomes { get; set; } = true;
        public bool IncludeOutputs { get; set; } = true;
        public bool IncludeReports { get; set; } = true;
        public bool IncludeDocuments { get; set; } = true;
        public bool IncludeFiles { get; set; } = true;
        public bool IncludeAttachments { get; set; } = true;
        public bool IncludeResources { get; set; } = true;
        public bool IncludeAssets { get; set; } = true;
        public bool IncludeMedias { get; set; } = true;
        public bool IncludePictures { get; set; } = true;
        public bool IncludePhotos { get; set; } = true;
        public bool IncludeGraphics { get; set; } = true;
        public bool IncludeIcons { get; set; } = true;
        public bool IncludeLogos { get; set; } = true;
        public bool IncludeBanners { get; set; } = true;
        public bool IncludeHeaders { get; set; } = true;
        public bool IncludeFooters { get; set; } = true;
        public bool IncludeSidebars { get; set; } = true;
        public bool IncludeMenus { get; set; } = true;
        public bool IncludeNavigations { get; set; } = true;
        public bool IncludeButtons { get; set; } = true;
        public bool IncludeForms { get; set; } = true;
        public bool IncludeInputs { get; set; } = true;
        public bool IncludeControls { get; set; } = true;
        public bool IncludeWidgets { get; set; } = true;
        public bool IncludeComponents { get; set; } = true;
        public bool IncludeElements { get; set; } = true;
        public bool IncludeArguments { get; set; } = true;
        public bool IncludeExpressions { get; set; } = true;
        public bool IncludeFormulas { get; set; } = true;
        public bool IncludeEquations { get; set; } = true;
        public bool IncludeCalculations { get; set; } = true;
        public bool IncludeComputations { get; set; } = true;
        public bool IncludeAlgorithms { get; set; } = true;
        public bool IncludeLogics { get; set; } = true;
        public bool IncludeCriterias { get; set; } = true;
        public bool IncludeFilters { get; set; } = true;
        public bool IncludeSearches { get; set; } = true;
        public bool IncludeQueries { get; set; } = true;
        public bool IncludeStatements { get; set; } = true;
        public bool IncludeCommands { get; set; } = true;
        public bool IncludeInstructions { get; set; } = true;
        public bool IncludeDirectives { get; set; } = true;
        public bool IncludeRequests { get; set; } = true;
        public bool IncludeResponses { get; set; } = true;
        public bool IncludeReplies { get; set; } = true;
        public bool IncludeAnswers { get; set; } = true;
        public bool IncludeSolutions { get; set; } = true;
        public bool IncludeFixes { get; set; } = true;
        public bool IncludePatches { get; set; } = true;
        public bool IncludeUpdates { get; set; } = true;
        public bool IncludeUpgrades { get; set; } = true;
        public bool IncludeMigrations { get; set; } = true;
        public bool IncludeConversions { get; set; } = true;
        public bool IncludeTransformations { get; set; } = true;
        public bool IncludeTranslations { get; set; } = true;
        public bool IncludeMappings { get; set; } = true;
        public bool IncludeBindings { get; set; } = true;
    }
}