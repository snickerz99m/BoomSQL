using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace BoomSQL.Core
{
    public class DorkSearcher
    {
        public ConcurrentBag<string> Results { get; } = new();
        public HashSet<string> UniqueDomains { get; } = new();

        private int _totalProcessed;
        public int TotalProcessed => _totalProcessed;

        private readonly List<string> _dorks;
        private readonly List<Proxy> _proxies;
        private readonly List<string> _userAgents;
        private readonly List<SearchEngine> _searchEngines;
        private readonly Action<string> _updateCallback;
        private readonly Action _searchComplete;
        private readonly CancellationTokenSource _cts = new();

        public DorkSearcher(
            List<string> dorks,
            List<Proxy> proxies,
            List<string> userAgents,
            List<SearchEngine> searchEngines,
            Action<string> updateCallback,
            Action searchComplete)
        {
            _dorks = dorks;
            _proxies = proxies;
            _userAgents = userAgents;
            _searchEngines = searchEngines.Where(e => e.Enabled).ToList();
            _updateCallback = updateCallback;
            _searchComplete = searchComplete;
        }

        public async Task StartAsync()
        {
            var random = new Random();
            var tasks = new List<Task>();

            // Create HttpClient instances with different proxies
            var clients = new List<HttpClient>();
            foreach (var proxy in _proxies)
            {
                try
                {
                    var handler = new HttpClientHandler
                    {
                        Proxy = new WebProxy($"{proxy.Host}:{proxy.Port}")
                        {
                            Credentials = string.IsNullOrEmpty(proxy.Username)
                                ? null
                                : new NetworkCredential(proxy.Username, proxy.Password)
                        },
                        UseCookies = false,
                        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                    };

                    var client = new HttpClient(handler);
                    client.Timeout = TimeSpan.FromSeconds(30);
                    client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                    client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
                    client.DefaultRequestHeaders.Add("Connection", "keep-alive");
                    client.DefaultRequestHeaders.Add("User-Agent", _userAgents[random.Next(_userAgents.Count)]);

                    clients.Add(client);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error creating HttpClient for proxy: {ex.Message}");
                }
            }

            if (clients.Count == 0)
            {
                Debug.WriteLine("No valid HttpClient instances created");
                _searchComplete?.Invoke();
                return;
            }

            // Process each dork with each search engine
            foreach (var dork in _dorks)
            {
                if (_cts.IsCancellationRequested) break;

                foreach (var engine in _searchEngines)
                {
                    if (_cts.IsCancellationRequested) break;

                    // Get a random client (proxy)
                    var client = clients[random.Next(clients.Count)];

                    tasks.Add(ProcessSearchAsync(
                        engine.UrlFormat.Replace("{dork}", Uri.EscapeDataString(dork)),
                        client,
                        _cts.Token
                    ));
                }
            }

            await Task.WhenAll(tasks);
            _searchComplete?.Invoke();
        }

        private async Task ProcessSearchAsync(string searchUrl, HttpClient client, CancellationToken ct)
        {
            try
            {
                Debug.WriteLine($"Processing: {searchUrl}");
                var response = await client.GetAsync(searchUrl, ct);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ProcessContent(content);
                }
                else
                {
                    Debug.WriteLine($"Request failed: {response.StatusCode} - {searchUrl}");
                }
            }
            catch (OperationCanceledException)
            {
                Debug.WriteLine("Search was canceled");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Search error: {ex.Message}");
            }
            finally
            {
                Interlocked.Increment(ref _totalProcessed);
            }
        }

        private void ProcessContent(string html)
        {
            try
            {
                // More robust URL extraction
                var urlMatches = Regex.Matches(html, @"href\s*=\s*[""'](https?://[^""']+)[""']", RegexOptions.IgnoreCase);

                foreach (Match match in urlMatches)
                {
                    if (match.Success)
                    {
                        var url = match.Groups[1].Value;
                        ProcessUrl(url);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Content processing error: {ex.Message}");
            }
        }

        private void ProcessUrl(string url)
        {
            try
            {
                // Normalize URL
                if (url.Contains('?'))
                {
                    url = url.Substring(0, url.IndexOf('?'));
                }

                if (url.Contains('#'))
                {
                    url = url.Substring(0, url.IndexOf('#'));
                }

                // Extract root domain
                var uri = new Uri(url);
                var rootDomain = uri.Host;

                // Add only unique domains
                if (UniqueDomains.Add(rootDomain))
                {
                    Results.Add(url);
                    _updateCallback?.Invoke(url);
                }
            }
            catch (UriFormatException)
            {
                Debug.WriteLine($"Invalid URL format: {url}");
            }
        }

        public void Stop() => _cts.Cancel();
    }
}