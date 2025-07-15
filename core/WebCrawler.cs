using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace BoomSQL.Core
{
    public class WebCrawler
    {
        private readonly HttpClient _httpClient;
        private readonly WebCrawlerConfig _config;
        private readonly ConcurrentDictionary<string, bool> _visitedUrls;
        private readonly ConcurrentQueue<CrawlTask> _crawlQueue;
        private readonly ConcurrentBag<CrawlerResult> _results;
        private readonly SemaphoreSlim _semaphore;
        private readonly Action<string> _logCallback;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public WebCrawler(HttpClient httpClient, WebCrawlerConfig config, Action<string> logCallback)
        {
            _httpClient = httpClient;
            _config = config;
            _logCallback = logCallback;
            _visitedUrls = new ConcurrentDictionary<string, bool>();
            _crawlQueue = new ConcurrentQueue<CrawlTask>();
            _results = new ConcurrentBag<CrawlerResult>();
            _semaphore = new SemaphoreSlim(config.MaxConcurrentRequests, config.MaxConcurrentRequests);
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public async Task<List<CrawlerResult>> CrawlAsync(string startUrl, CancellationToken cancellationToken = default)
        {
            try
            {
                var linkedCancellation = CancellationTokenSource.CreateLinkedTokenSource(
                    cancellationToken, _cancellationTokenSource.Token);

                // Add initial URL to queue
                _crawlQueue.Enqueue(new CrawlTask { Url = startUrl, Depth = 0 });
                _logCallback($"Starting crawl from: {startUrl}");

                // Process queue
                var tasks = new List<Task>();
                for (int i = 0; i < _config.MaxConcurrentRequests; i++)
                {
                    tasks.Add(ProcessCrawlQueueAsync(linkedCancellation.Token));
                }

                await Task.WhenAll(tasks);

                var resultList = _results.ToList();
                _logCallback($"Crawl completed. Found {resultList.Count} unique URLs");
                return resultList;
            }
            catch (OperationCanceledException)
            {
                _logCallback("Crawl was cancelled");
                return _results.ToList();
            }
            catch (Exception ex)
            {
                _logCallback($"Crawl error: {ex.Message}");
                return _results.ToList();
            }
        }

        private async Task ProcessCrawlQueueAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (!_crawlQueue.TryDequeue(out var task))
                {
                    await Task.Delay(100, cancellationToken);
                    continue;
                }

                await _semaphore.WaitAsync(cancellationToken);
                try
                {
                    await ProcessUrlAsync(task, cancellationToken);
                }
                finally
                {
                    _semaphore.Release();
                }

                // Add delay between requests
                if (_config.RequestDelay > 0)
                {
                    await Task.Delay(_config.RequestDelay, cancellationToken);
                }
            }
        }

        private async Task ProcessUrlAsync(CrawlTask task, CancellationToken cancellationToken)
        {
            try
            {
                // Check if URL was already visited
                if (!_visitedUrls.TryAdd(task.Url, true))
                {
                    return;
                }

                // Check depth limit
                if (task.Depth >= _config.MaxDepth)
                {
                    return;
                }

                // Check URL limit
                if (_results.Count >= _config.MaxUrls)
                {
                    return;
                }

                _logCallback($"Crawling: {task.Url} (depth: {task.Depth})");

                // Make HTTP request
                var response = await _httpClient.GetAsync(task.Url, cancellationToken);
                if (!response.IsSuccessStatusCode)
                {
                    _logCallback($"Failed to fetch {task.Url}: {response.StatusCode}");
                    return;
                }

                var content = await response.Content.ReadAsStringAsync();
                var contentType = response.Content.Headers.ContentType?.MediaType ?? "";

                // Only process HTML content
                if (!contentType.Contains("text/html"))
                {
                    return;
                }

                // Create result
                var result = new CrawlerResult
                {
                    Url = task.Url,
                    Depth = task.Depth,
                    CrawlTime = DateTime.UtcNow
                };

                // Extract URLs
                var extractedUrls = ExtractUrls(content, task.Url);
                result.DiscoveredUrls = extractedUrls;

                // Extract forms
                var forms = ExtractForms(content);
                result.Forms = forms;

                // Extract parameters
                var parameters = ExtractParameters(content, task.Url);
                result.Parameters = parameters;

                // Extract cookies
                var cookies = ExtractCookies(response);
                result.Cookies = cookies;

                // Extract headers
                var headers = ExtractHeaders(response);
                result.Headers = headers;

                _results.Add(result);

                // Queue discovered URLs for crawling
                if (task.Depth < _config.MaxDepth)
                {
                    foreach (var url in extractedUrls.Take(_config.MaxUrlsPerPage))
                    {
                        if (IsValidUrl(url) && !_visitedUrls.ContainsKey(url))
                        {
                            _crawlQueue.Enqueue(new CrawlTask { Url = url, Depth = task.Depth + 1 });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logCallback($"Error processing {task.Url}: {ex.Message}");
            }
        }

        private List<string> ExtractUrls(string html, string baseUrl)
        {
            var urls = new HashSet<string>();
            var baseUri = new Uri(baseUrl);

            // Extract href attributes
            var hrefMatches = Regex.Matches(html, @"href\s*=\s*[""']([^""']+)[""']", RegexOptions.IgnoreCase);
            foreach (Match match in hrefMatches)
            {
                var url = match.Groups[1].Value;
                var absoluteUrl = ConvertToAbsoluteUrl(url, baseUri);
                if (absoluteUrl != null)
                {
                    urls.Add(absoluteUrl);
                }
            }

            // Extract src attributes
            var srcMatches = Regex.Matches(html, @"src\s*=\s*[""']([^""']+)[""']", RegexOptions.IgnoreCase);
            foreach (Match match in srcMatches)
            {
                var url = match.Groups[1].Value;
                var absoluteUrl = ConvertToAbsoluteUrl(url, baseUri);
                if (absoluteUrl != null && IsValidFileExtension(absoluteUrl))
                {
                    urls.Add(absoluteUrl);
                }
            }

            // Extract action attributes from forms
            var actionMatches = Regex.Matches(html, @"action\s*=\s*[""']([^""']+)[""']", RegexOptions.IgnoreCase);
            foreach (Match match in actionMatches)
            {
                var url = match.Groups[1].Value;
                var absoluteUrl = ConvertToAbsoluteUrl(url, baseUri);
                if (absoluteUrl != null)
                {
                    urls.Add(absoluteUrl);
                }
            }

            return urls.ToList();
        }

        private List<string> ExtractForms(string html)
        {
            var forms = new List<string>();
            var formMatches = Regex.Matches(html, @"<form[^>]*>.*?</form>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            
            foreach (Match match in formMatches)
            {
                forms.Add(match.Value);
            }

            return forms;
        }

        private List<string> ExtractParameters(string html, string baseUrl)
        {
            var parameters = new HashSet<string>();
            var uri = new Uri(baseUrl);

            // Extract URL parameters
            var query = HttpUtility.ParseQueryString(uri.Query);
            foreach (string key in query.AllKeys)
            {
                if (key != null)
                {
                    parameters.Add(key);
                }
            }

            // Extract form input parameters
            var inputMatches = Regex.Matches(html, @"<input[^>]*name\s*=\s*[""']([^""']+)[""'][^>]*>", RegexOptions.IgnoreCase);
            foreach (Match match in inputMatches)
            {
                parameters.Add(match.Groups[1].Value);
            }

            // Extract select parameters
            var selectMatches = Regex.Matches(html, @"<select[^>]*name\s*=\s*[""']([^""']+)[""'][^>]*>", RegexOptions.IgnoreCase);
            foreach (Match match in selectMatches)
            {
                parameters.Add(match.Groups[1].Value);
            }

            // Extract textarea parameters
            var textareaMatches = Regex.Matches(html, @"<textarea[^>]*name\s*=\s*[""']([^""']+)[""'][^>]*>", RegexOptions.IgnoreCase);
            foreach (Match match in textareaMatches)
            {
                parameters.Add(match.Groups[1].Value);
            }

            return parameters.ToList();
        }

        private List<string> ExtractCookies(HttpResponseMessage response)
        {
            var cookies = new List<string>();
            
            if (response.Headers.TryGetValues("Set-Cookie", out var cookieHeaders))
            {
                foreach (var cookieHeader in cookieHeaders)
                {
                    cookies.Add(cookieHeader);
                }
            }

            return cookies;
        }

        private List<string> ExtractHeaders(HttpResponseMessage response)
        {
            var headers = new List<string>();
            
            foreach (var header in response.Headers)
            {
                headers.Add($"{header.Key}: {string.Join(", ", header.Value)}");
            }

            foreach (var header in response.Content.Headers)
            {
                headers.Add($"{header.Key}: {string.Join(", ", header.Value)}");
            }

            return headers;
        }

        private string ConvertToAbsoluteUrl(string url, Uri baseUri)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                    return null;

                // Remove anchor fragments
                var anchorIndex = url.IndexOf('#');
                if (anchorIndex >= 0)
                    url = url.Substring(0, anchorIndex);

                // Skip javascript: and mailto: links
                if (url.StartsWith("javascript:", StringComparison.OrdinalIgnoreCase) ||
                    url.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase))
                    return null;

                // Convert to absolute URL
                var absoluteUri = new Uri(baseUri, url);
                return absoluteUri.ToString();
            }
            catch
            {
                return null;
            }
        }

        private bool IsValidUrl(string url)
        {
            try
            {
                var uri = new Uri(url);
                
                // Check if it's HTTP/HTTPS
                if (uri.Scheme != "http" && uri.Scheme != "https")
                    return false;

                // Check if it's within the same domain (if configured)
                if (_config.StayInDomain)
                {
                    var baseUri = new Uri(_config.BaseUrl);
                    if (uri.Host != baseUri.Host)
                        return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidFileExtension(string url)
        {
            try
            {
                var uri = new Uri(url);
                var extension = Path.GetExtension(uri.AbsolutePath).ToLower();
                
                // Check if it's an allowed file extension
                return _config.AllowedExtensions.Contains(extension) || 
                       !_config.ExcludedExtensions.Contains(extension);
            }
            catch
            {
                return true;
            }
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }
    }

    public class CrawlTask
    {
        public string Url { get; set; } = "";
        public int Depth { get; set; } = 0;
    }

    public class WebCrawlerConfig
    {
        public int MaxDepth { get; set; } = 3;
        public int MaxUrls { get; set; } = 1000;
        public int MaxUrlsPerPage { get; set; } = 100;
        public int MaxConcurrentRequests { get; set; } = 5;
        public int RequestDelay { get; set; } = 1000;
        public bool StayInDomain { get; set; } = true;
        public string BaseUrl { get; set; } = "";
        public List<string> AllowedExtensions { get; set; } = new()
        {
            ".php", ".asp", ".aspx", ".jsp", ".cfm", ".py", ".rb", ".pl", ".cgi", ".html", ".htm"
        };
        public List<string> ExcludedExtensions { get; set; } = new()
        {
            ".css", ".js", ".jpg", ".jpeg", ".png", ".gif", ".pdf", ".doc", ".docx", 
            ".xls", ".xlsx", ".zip", ".rar", ".tar", ".gz", ".mp3", ".mp4", ".avi", 
            ".wmv", ".mov", ".swf", ".ico", ".svg", ".woff", ".woff2", ".ttf", ".eot"
        };
        public string UserAgent { get; set; } = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36";
        public bool FollowRedirects { get; set; } = true;
        public int MaxRedirects { get; set; } = 5;
        public int RequestTimeout { get; set; } = 30;
        public bool EnableJavaScriptParsing { get; set; } = false;
        public bool EnableFormDetection { get; set; } = true;
        public bool EnableParameterExtraction { get; set; } = true;
        public bool EnableCookieExtraction { get; set; } = true;
        public bool EnableHeaderExtraction { get; set; } = true;
        public bool RespectRobotsTxt { get; set; } = false;
        public bool ParseSitemap { get; set; } = false;
        public List<string> CustomHeaders { get; set; } = new();
        public Dictionary<string, string> CustomCookies { get; set; } = new();
        public bool EnableDeduplication { get; set; } = true;
        public bool EnableUrlNormalization { get; set; } = true;
        public bool EnableContentTypeFiltering { get; set; } = true;
        public List<string> AllowedContentTypes { get; set; } = new()
        {
            "text/html", "text/plain", "application/xhtml+xml"
        };
        public bool EnableSizeLimit { get; set; } = true;
        public long MaxContentSize { get; set; } = 10 * 1024 * 1024; // 10MB
        public bool EnableCompressionSupport { get; set; } = true;
        public bool EnableCookieSupport { get; set; } = true;
        public bool EnableSessionSupport { get; set; } = false;
        public bool EnableAuthenticationSupport { get; set; } = false;
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public bool EnableProxySupport { get; set; } = false;
        public string ProxyHost { get; set; } = "";
        public int ProxyPort { get; set; } = 8080;
        public string ProxyUsername { get; set; } = "";
        public string ProxyPassword { get; set; } = "";
        public bool EnableRetryOnFailure { get; set; } = true;
        public int MaxRetries { get; set; } = 3;
        public int RetryDelay { get; set; } = 1000;
        public bool EnableProgressTracking { get; set; } = true;
        public bool EnableStatistics { get; set; } = true;
        public bool EnableLogging { get; set; } = true;
        public bool EnableVerboseLogging { get; set; } = false;
        public bool EnableErrorHandling { get; set; } = true;
        public bool EnableGracefulShutdown { get; set; } = true;
        public bool EnableMemoryOptimization { get; set; } = true;
        public bool EnableCaching { get; set; } = false;
        public int CacheSize { get; set; } = 1000;
        public int CacheTimeout { get; set; } = 3600;
        public bool EnableUrlFiltering { get; set; } = true;
        public List<string> UrlFilters { get; set; } = new();
        public List<string> UrlExclusions { get; set; } = new();
        public bool EnableDomainFiltering { get; set; } = false;
        public List<string> AllowedDomains { get; set; } = new();
        public List<string> ExcludedDomains { get; set; } = new();
        public bool EnablePathFiltering { get; set; } = false;
        public List<string> AllowedPaths { get; set; } = new();
        public List<string> ExcludedPaths { get; set; } = new();
        public bool EnableQueryFiltering { get; set; } = false;
        public List<string> AllowedParameters { get; set; } = new();
        public List<string> ExcludedParameters { get; set; } = new();
        public bool EnableFragmentFiltering { get; set; } = true;
        public bool EnableSchemeFiltering { get; set; } = true;
        public List<string> AllowedSchemes { get; set; } = new() { "http", "https" };
        public bool EnablePortFiltering { get; set; } = false;
        public List<int> AllowedPorts { get; set; } = new() { 80, 443 };
        public List<int> ExcludedPorts { get; set; } = new();
        public bool EnableIpFiltering { get; set; } = false;
        public List<string> AllowedIps { get; set; } = new();
        public List<string> ExcludedIps { get; set; } = new();
        public bool EnableSubdomainCrawling { get; set; } = true;
        public bool EnableWildcardMatching { get; set; } = true;
        public bool EnableRegexFiltering { get; set; } = false;
        public List<string> RegexFilters { get; set; } = new();
        public bool EnableCustomParsing { get; set; } = false;
        public List<string> CustomParsers { get; set; } = new();
        public bool EnablePluginSupport { get; set; } = false;
        public List<string> Plugins { get; set; } = new();
        public bool EnableExtensionSupport { get; set; } = false;
        public List<string> Extensions { get; set; } = new();
        public bool EnableHookSupport { get; set; } = false;
        public List<string> Hooks { get; set; } = new();
        public bool EnableEventSupport { get; set; } = false;
        public List<string> Events { get; set; } = new();
        public bool EnableCallbackSupport { get; set; } = false;
        public List<string> Callbacks { get; set; } = new();
        public bool EnableMiddlewareSupport { get; set; } = false;
        public List<string> Middlewares { get; set; } = new();
        public bool EnableInterceptorSupport { get; set; } = false;
        public List<string> Interceptors { get; set; } = new();
        public bool EnableFilterSupport { get; set; } = false;
        public List<string> Filters { get; set; } = new();
        public bool EnableTransformerSupport { get; set; } = false;
        public List<string> Transformers { get; set; } = new();
        public bool EnableValidatorSupport { get; set; } = false;
        public List<string> Validators { get; set; } = new();
        public bool EnableSerializerSupport { get; set; } = false;
        public List<string> Serializers { get; set; } = new();
        public bool EnableDeserializerSupport { get; set; } = false;
        public List<string> Deserializers { get; set; } = new();
        public bool EnableEncoderSupport { get; set; } = false;
        public List<string> Encoders { get; set; } = new();
        public bool EnableDecoderSupport { get; set; } = false;
        public List<string> Decoders { get; set; } = new();
        public bool EnableCompressorSupport { get; set; } = false;
        public List<string> Compressors { get; set; } = new();
        public bool EnableDecompressorSupport { get; set; } = false;
        public List<string> Decompressors { get; set; } = new();
        public bool EnableHasherSupport { get; set; } = false;
        public List<string> Hashers { get; set; } = new();
        public bool EnableEncryptorSupport { get; set; } = false;
        public List<string> Encryptors { get; set; } = new();
        public bool EnableDecryptorSupport { get; set; } = false;
        public List<string> Decryptors { get; set; } = new();
    }
}