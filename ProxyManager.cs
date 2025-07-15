using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BoomSQL.Core
{
    public static class ProxyManager
    {
        public static bool UseProxy { get; set; } = true;
        private static List<Proxy> _proxies = new List<Proxy>();
        private static List<string> _userAgents = new List<string>();
        private static Random _random = new Random();

        public static void LoadProxies()
        {
            try
            {
                var proxyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "proxies.txt");
                if (File.Exists(proxyPath))
                {
                    _proxies = File.ReadLines(proxyPath)
                        .Select(line => line.Trim())
                        .Where(line => !string.IsNullOrWhiteSpace(line))
                        .Select(line => ParseProxy(line))
                        .Where(p => p != null)
                        .ToList();
                }
            }
            catch { }
        }

        public static void LoadUserAgents()
        {
            try
            {
                var uaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "useragents.txt");
                if (File.Exists(uaPath))
                {
                    _userAgents = File.ReadLines(uaPath)
                        .Select(line => line.Trim())
                        .Where(line => !string.IsNullOrWhiteSpace(line))
                        .ToList();
                }
            }
            catch { }
        }

        private static Proxy ParseProxy(string line)
        {
            try
            {
                var parts = line.Split(':');
                if (parts.Length >= 2)
                {
                    var proxy = new Proxy
                    {
                        Host = parts[0],
                        Port = int.Parse(parts[1])
                    };

                    if (parts.Length >= 4)
                    {
                        proxy.Username = parts[2];
                        proxy.Password = parts[3];
                    }

                    return proxy;
                }
            }
            catch { }
            return null;
        }

        public static Proxy GetRandomProxy()
        {
            if (_proxies.Count == 0) return null;
            return _proxies[_random.Next(_proxies.Count)];
        }

        public static string GetRandomUserAgent()
        {
            if (_userAgents.Count == 0) return "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36";
            return _userAgents[_random.Next(_userAgents.Count)];
        }

        public static List<Proxy> LoadProxies(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    return File.ReadLines(filePath)
                        .Select(line => line.Trim())
                        .Where(line => !string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                        .Select(line => ParseProxy(line))
                        .Where(p => p != null)
                        .ToList()!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading proxies: {ex.Message}");
            }
            return new List<Proxy>();
        }
    }
}