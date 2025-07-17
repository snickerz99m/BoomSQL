"""
Dork Searcher for BoomSQL
Advanced Google dorking with multiple search engines
"""

import asyncio
import re
import random
import time
from typing import Dict, List, Optional, Set, Any
from urllib.parse import urljoin, urlparse, quote_plus
from pathlib import Path
from dataclasses import dataclass, field
from enum import Enum
from bs4 import BeautifulSoup
import json

from .logger import LoggerMixin
from .fallbacks import aiohttp, ClientSession, AIOHTTP_AVAILABLE

class SearchEngine(Enum):
    """Supported search engines"""
    GOOGLE = "google"
    BING = "bing"
    YAHOO = "yahoo"
    DUCKDUCKGO = "duckduckgo"
    AOL = "aol"
    ASK = "ask"
    STARTPAGE = "startpage"
    DOGPILE = "dogpile"
    YANDEX = "yandex"
    BAIDU = "baidu"

@dataclass
class SearchResult:
    """Search result information"""
    url: str
    title: str
    description: str
    search_engine: SearchEngine
    dork: str
    position: int
    timestamp: float
    
@dataclass
class SearchProgress:
    """Search progress information"""
    dorks_processed: int
    total_dorks: int
    engines_processed: int
    total_engines: int
    results_found: int
    unique_domains: int
    current_dork: str
    current_engine: str
    start_time: float
    
    @property
    def progress_percentage(self) -> float:
        """Calculate progress percentage"""
        if self.total_dorks == 0:
            return 0.0
        return (self.dorks_processed / self.total_dorks) * 100
        
    @property
    def elapsed_time(self) -> float:
        """Get elapsed time in seconds"""
        return time.time() - self.start_time
        
    @property
    def search_rate(self) -> float:
        """Get search rate (dorks per second)"""
        if self.elapsed_time == 0:
            return 0.0
        return self.dorks_processed / self.elapsed_time

class DorkSearcher(LoggerMixin):
    """Advanced dork searcher with multiple search engines"""
    
    def __init__(self, config: Dict[str, Any]):
        self.config = config
        self.session = None
        self.results: List[SearchResult] = []
        self.unique_domains: Set[str] = set()
        self.user_agents: List[str] = []
        self.proxies: List[Dict[str, str]] = []
        self.progress = None
        self.is_searching = False
        self.cancel_requested = False
        
        # Search engine configurations
        self.search_engines = self.get_search_engine_configs()
        
        # Load user agents and proxies
        self.load_user_agents()
        self.load_proxies()
        
        # Initialize session
        self.init_session()
        
    def init_session(self):
        """Initialize aiohttp session"""
        timeout = aiohttp.ClientTimeout(total=self.config.get("RequestTimeout", 30))
        connector = aiohttp.TCPConnector(
            limit=self.config.get("MaxThreads", 3),
            ssl=False
        )
        
        self.session = aiohttp.ClientSession(
            timeout=timeout,
            connector=connector
        )
        
    async def close(self):
        """Close the session"""
        if self.session:
            await self.session.close()
            
    def get_search_engine_configs(self) -> Dict[SearchEngine, Dict[str, Any]]:
        """Get search engine configurations"""
        return {
            SearchEngine.GOOGLE: {
                'url_format': 'https://www.google.com/search?q={query}&start={start}',
                'result_selector': 'div.g',
                'title_selector': 'h3',
                'url_selector': 'a',
                'description_selector': 'span.st',
                'next_page_param': 'start',
                'results_per_page': 10,
                'max_pages': 10,
                'delay': 2000,
                'headers': {
                    'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8',
                    'Accept-Language': 'en-US,en;q=0.5',
                    'Accept-Encoding': 'gzip, deflate'
                }
            },
            SearchEngine.BING: {
                'url_format': 'https://www.bing.com/search?q={query}&first={start}',
                'result_selector': 'li.b_algo',
                'title_selector': 'h2',
                'url_selector': 'h2 a',
                'description_selector': 'div.b_caption p',
                'next_page_param': 'first',
                'results_per_page': 10,
                'max_pages': 10,
                'delay': 1500,
                'headers': {
                    'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8',
                    'Accept-Language': 'en-US,en;q=0.5'
                }
            },
            SearchEngine.YAHOO: {
                'url_format': 'https://search.yahoo.com/search?p={query}&b={start}',
                'result_selector': 'div.dd.algo',
                'title_selector': 'h3.title',
                'url_selector': 'h3.title a',
                'description_selector': 'div.compText',
                'next_page_param': 'b',
                'results_per_page': 10,
                'max_pages': 10,
                'delay': 2000,
                'headers': {
                    'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8',
                    'Accept-Language': 'en-US,en;q=0.5'
                }
            },
            SearchEngine.DUCKDUCKGO: {
                'url_format': 'https://duckduckgo.com/html/?q={query}',
                'result_selector': 'div.result',
                'title_selector': 'h2.result__title',
                'url_selector': 'h2.result__title a',
                'description_selector': 'div.result__snippet',
                'next_page_param': None,  # DuckDuckGo doesn't support pagination in HTML
                'results_per_page': 30,
                'max_pages': 1,
                'delay': 1000,
                'headers': {
                    'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8',
                    'Accept-Language': 'en-US,en;q=0.5'
                }
            },
            SearchEngine.AOL: {
                'url_format': 'https://search.aol.com/aol/search?q={query}&s_it=sb-top&v_t=comsearch&s_chn=hp',
                'result_selector': 'div.algo',
                'title_selector': 'h3',
                'url_selector': 'h3 a',
                'description_selector': 'div.compText',
                'next_page_param': None,
                'results_per_page': 10,
                'max_pages': 5,
                'delay': 2000,
                'headers': {
                    'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8',
                    'Accept-Language': 'en-US,en;q=0.5'
                }
            },
            SearchEngine.ASK: {
                'url_format': 'https://www.ask.com/web?q={query}',
                'result_selector': 'div.PartialSearchResults-item',
                'title_selector': 'a.PartialSearchResults-item-title',
                'url_selector': 'a.PartialSearchResults-item-title',
                'description_selector': 'p.PartialSearchResults-item-abstract',
                'next_page_param': None,
                'results_per_page': 10,
                'max_pages': 5,
                'delay': 2000,
                'headers': {
                    'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8',
                    'Accept-Language': 'en-US,en;q=0.5'
                }
            },
            SearchEngine.STARTPAGE: {
                'url_format': 'https://www.startpage.com/sp/search?query={query}',
                'result_selector': 'div.w-gl__result',
                'title_selector': 'h3',
                'url_selector': 'h3 a',
                'description_selector': 'p.w-gl__description',
                'next_page_param': None,
                'results_per_page': 10,
                'max_pages': 5,
                'delay': 2000,
                'headers': {
                    'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8',
                    'Accept-Language': 'en-US,en;q=0.5'
                }
            },
            SearchEngine.DOGPILE: {
                'url_format': 'https://www.dogpile.com/serp?q={query}',
                'result_selector': 'div.web-bing__result',
                'title_selector': 'h3',
                'url_selector': 'h3 a',
                'description_selector': 'div.web-bing__description',
                'next_page_param': None,
                'results_per_page': 10,
                'max_pages': 5,
                'delay': 2000,
                'headers': {
                    'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8',
                    'Accept-Language': 'en-US,en;q=0.5'
                }
            },
            SearchEngine.YANDEX: {
                'url_format': 'https://yandex.com/search/?text={query}',
                'result_selector': 'div.serp-item',
                'title_selector': 'h2',
                'url_selector': 'h2 a',
                'description_selector': 'div.text-container',
                'next_page_param': None,
                'results_per_page': 10,
                'max_pages': 5,
                'delay': 2000,
                'headers': {
                    'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8',
                    'Accept-Language': 'en-US,en;q=0.5'
                }
            },
            SearchEngine.BAIDU: {
                'url_format': 'https://www.baidu.com/s?wd={query}',
                'result_selector': 'div.result',
                'title_selector': 'h3',
                'url_selector': 'h3 a',
                'description_selector': 'div.c-abstract',
                'next_page_param': None,
                'results_per_page': 10,
                'max_pages': 5,
                'delay': 2000,
                'headers': {
                    'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8',
                    'Accept-Language': 'zh-CN,zh;q=0.8,en;q=0.6'
                }
            }
        }
        
    def load_user_agents(self):
        """Load user agents from file"""
        try:
            ua_file = Path(self.config.get("UserAgentFile", "useragents.txt"))
            if ua_file.exists():
                with open(ua_file, 'r', encoding='utf-8') as f:
                    self.user_agents = [line.strip() for line in f if line.strip()]
            else:
                self.user_agents = self.get_default_user_agents()
                
            self.log_info(f"Loaded {len(self.user_agents)} user agents")
            
        except Exception as e:
            self.log_error(f"Error loading user agents: {e}")
            self.user_agents = self.get_default_user_agents()
            
    def load_proxies(self):
        """Load proxies from file"""
        try:
            proxy_file = Path(self.config.get("ProxyFile", "proxies.txt"))
            if proxy_file.exists():
                with open(proxy_file, 'r', encoding='utf-8') as f:
                    for line in f:
                        line = line.strip()
                        if line and ':' in line:
                            parts = line.split(':')
                            if len(parts) >= 2:
                                proxy = {
                                    'host': parts[0],
                                    'port': int(parts[1]),
                                    'username': parts[2] if len(parts) > 2 else None,
                                    'password': parts[3] if len(parts) > 3 else None
                                }
                                self.proxies.append(proxy)
                                
            self.log_info(f"Loaded {len(self.proxies)} proxies")
            
        except Exception as e:
            self.log_error(f"Error loading proxies: {e}")
            
    def get_default_user_agents(self) -> List[str]:
        """Get default user agents"""
        return [
            'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36',
            'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36',
            'Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36',
            'Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:89.0) Gecko/20100101 Firefox/89.0',
            'Mozilla/5.0 (Macintosh; Intel Mac OS X 10.15; rv:89.0) Gecko/20100101 Firefox/89.0',
            'Mozilla/5.0 (X11; Linux x86_64; rv:89.0) Gecko/20100101 Firefox/89.0',
            'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36 Edg/91.0.864.59',
            'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.1.1 Safari/605.1.15'
        ]
        
    def load_dorks(self, dork_file: str = None) -> List[str]:
        """Load dorks from file"""
        dorks = []
        
        try:
            if dork_file is None:
                dork_file = self.config.get("DorkFile", "dorks.txt")
                
            dork_path = Path(dork_file)
            if dork_path.exists():
                with open(dork_path, 'r', encoding='utf-8') as f:
                    for line in f:
                        line = line.strip()
                        if line and not line.startswith('#'):
                            dorks.append(line)
                            
            self.log_info(f"Loaded {len(dorks)} dorks from {dork_file}")
            
        except Exception as e:
            self.log_error(f"Error loading dorks: {e}")
            dorks = self.get_default_dorks()
            
        return dorks
        
    def get_default_dorks(self) -> List[str]:
        """Get default dorks"""
        return [
            'inurl:admin',
            'inurl:login',
            'inurl:admin/login',
            'inurl:admin.php',
            'inurl:login.php',
            'inurl:admin/index.php',
            'inurl:phpmyadmin',
            'inurl:mysql',
            'inurl:database',
            'inurl:config',
            'inurl:sql',
            'inurl:backup',
            'inurl:dump',
            'inurl:install',
            'inurl:setup',
            'intitle:"index of"',
            'intitle:"phpMyAdmin"',
            'intitle:"MySQL"',
            'intitle:"Database"',
            'intitle:"Admin"',
            'intitle:"Login"',
            'filetype:sql',
            'filetype:db',
            'filetype:bak',
            'filetype:config',
            'filetype:log',
            'filetype:txt password',
            'filetype:xls password',
            'filetype:doc password',
            'site:target.com inurl:admin',
            'site:target.com inurl:login',
            'site:target.com inurl:sql',
            'site:target.com filetype:sql',
            'site:target.com filetype:db'
        ]
        
    async def search(self, dorks: List[str], engines: List[SearchEngine] = None, callback=None) -> List[SearchResult]:
        """Search using dorks across multiple engines"""
        if engines is None:
            engines = [SearchEngine.GOOGLE, SearchEngine.BING, SearchEngine.YAHOO, SearchEngine.DUCKDUCKGO]
            
        self.log_info(f"Starting search with {len(dorks)} dorks across {len(engines)} engines")
        
        self.is_searching = True
        self.cancel_requested = False
        self.results.clear()
        self.unique_domains.clear()
        
        # Initialize progress
        self.progress = SearchProgress(
            dorks_processed=0,
            total_dorks=len(dorks),
            engines_processed=0,
            total_engines=len(engines),
            results_found=0,
            unique_domains=0,
            current_dork="",
            current_engine="",
            start_time=time.time()
        )
        
        # Process each dork with each engine
        for dork in dorks:
            if self.cancel_requested:
                break
                
            self.progress.current_dork = dork
            self.progress.engines_processed = 0
            
            for engine in engines:
                if self.cancel_requested:
                    break
                    
                self.progress.current_engine = engine.value
                
                if callback:
                    callback(f"Searching: {dork} ({engine.value})")
                    
                try:
                    results = await self.search_engine(dork, engine)
                    self.results.extend(results)
                    self.progress.results_found = len(self.results)
                    self.progress.unique_domains = len(self.unique_domains)
                    
                    # Add delay between engines
                    engine_config = self.search_engines[engine]
                    delay = engine_config.get('delay', 2000) / 1000
                    await asyncio.sleep(delay)
                    
                except Exception as e:
                    self.log_error(f"Error searching {engine.value} for '{dork}': {e}")
                    
                self.progress.engines_processed += 1
                
            self.progress.dorks_processed += 1
            
        self.is_searching = False
        self.log_info(f"Search completed. Found {len(self.results)} results from {len(self.unique_domains)} unique domains")
        
        return self.results
        
    async def search_engine(self, dork: str, engine: SearchEngine) -> List[SearchResult]:
        """Search a single engine for a dork"""
        engine_config = self.search_engines[engine]
        results = []
        
        max_pages = engine_config.get('max_pages', 5)
        results_per_page = engine_config.get('results_per_page', 10)
        
        for page in range(max_pages):
            if self.cancel_requested:
                break
                
            # Calculate start parameter
            start = page * results_per_page
            
            # Build search URL
            query = quote_plus(dork)
            if engine_config.get('next_page_param'):
                search_url = engine_config['url_format'].format(query=query, start=start)
            else:
                search_url = engine_config['url_format'].format(query=query)
                
            # Prepare headers
            headers = engine_config.get('headers', {}).copy()
            headers['User-Agent'] = self.get_random_user_agent()
            
            # Add proxy if available
            proxy = self.get_random_proxy()
            
            try:
                async with self.session.get(search_url, headers=headers, proxy=proxy) as response:
                    if response.status == 200:
                        content = await response.text()
                        page_results = self.parse_search_results(content, engine, dork, start)
                        results.extend(page_results)
                        
                        # If no results on this page, stop pagination
                        if not page_results:
                            break
                            
                    elif response.status == 429:
                        # Rate limited, wait longer
                        self.log_warning(f"Rate limited by {engine.value}, waiting...")
                        await asyncio.sleep(10)
                        break
                        
                    else:
                        self.log_warning(f"HTTP {response.status} from {engine.value}")
                        break
                        
            except Exception as e:
                self.log_error(f"Error searching {engine.value}: {e}")
                break
                
            # Add delay between pages
            if page < max_pages - 1:
                await asyncio.sleep(random.uniform(1, 3))
                
        return results
        
    def parse_search_results(self, html: str, engine: SearchEngine, dork: str, start_position: int) -> List[SearchResult]:
        """Parse search results from HTML"""
        results = []
        
        try:
            soup = BeautifulSoup(html, 'html.parser')
            engine_config = self.search_engines[engine]
            
            # Find result containers
            result_containers = soup.select(engine_config['result_selector'])
            
            for i, container in enumerate(result_containers):
                try:
                    # Extract title
                    title_elem = container.select_one(engine_config['title_selector'])
                    title = title_elem.get_text().strip() if title_elem else ""
                    
                    # Extract URL
                    url_elem = container.select_one(engine_config['url_selector'])
                    url = ""
                    if url_elem:
                        url = url_elem.get('href', '')
                        
                        # Clean up URL
                        if url.startswith('/url?'):
                            # Google URL format
                            url_match = re.search(r'url=([^&]+)', url)
                            if url_match:
                                url = url_match.group(1)
                        elif url.startswith('/aclk?'):
                            # Google Ad URL format
                            continue
                            
                    # Extract description
                    desc_elem = container.select_one(engine_config['description_selector'])
                    description = desc_elem.get_text().strip() if desc_elem else ""
                    
                    # Skip if no URL or title
                    if not url or not title:
                        continue
                        
                    # Filter results
                    if self.should_include_result(url, title, description):
                        result = SearchResult(
                            url=url,
                            title=title,
                            description=description,
                            search_engine=engine,
                            dork=dork,
                            position=start_position + i + 1,
                            timestamp=time.time()
                        )
                        results.append(result)
                        
                        # Add domain to unique domains
                        domain = self.extract_domain(url)
                        if domain:
                            self.unique_domains.add(domain)
                            
                except Exception as e:
                    self.log_error(f"Error parsing result: {e}")
                    continue
                    
        except Exception as e:
            self.log_error(f"Error parsing {engine.value} results: {e}")
            
        return results
        
    def should_include_result(self, url: str, title: str, description: str) -> bool:
        """Check if result should be included"""
        # Skip if duplicate result filtering is enabled
        if self.config.get("EnableDuplicateRemoval", True):
            for result in self.results:
                if result.url == url:
                    return False
                    
        # Skip unwanted domains
        excluded_domains = [
            'google.com', 'bing.com', 'yahoo.com', 'duckduckgo.com',
            'wikipedia.org', 'github.com', 'stackoverflow.com',
            'youtube.com', 'twitter.com', 'facebook.com'
        ]
        
        domain = self.extract_domain(url)
        if domain and any(excluded in domain for excluded in excluded_domains):
            return False
            
        # Filter by result content if enabled
        if self.config.get("EnableResultFiltering", True):
            # Look for potential vulnerable indicators
            vulnerable_indicators = [
                'admin', 'login', 'sql', 'database', 'mysql', 'phpmyadmin',
                'config', 'backup', 'dump', 'install', 'setup', 'test',
                'dev', 'staging', 'debug', 'error', 'exception'
            ]
            
            combined_text = f"{title} {description} {url}".lower()
            if any(indicator in combined_text for indicator in vulnerable_indicators):
                return True
                
        return True
        
    def extract_domain(self, url: str) -> Optional[str]:
        """Extract domain from URL"""
        try:
            parsed = urlparse(url)
            return parsed.netloc.lower()
        except:
            return None
            
    def get_random_user_agent(self) -> str:
        """Get random user agent"""
        if self.user_agents:
            return random.choice(self.user_agents)
        return "BoomSQL/2.0"
        
    def get_random_proxy(self) -> Optional[str]:
        """Get random proxy"""
        if self.proxies and self.config.get("EnableProxyRotation", False):
            proxy = random.choice(self.proxies)
            if proxy['username'] and proxy['password']:
                return f"http://{proxy['username']}:{proxy['password']}@{proxy['host']}:{proxy['port']}"
            else:
                return f"http://{proxy['host']}:{proxy['port']}"
        return None
        
    def cancel_search(self):
        """Cancel the current search operation"""
        self.cancel_requested = True
        self.log_info("Search cancellation requested")
        
    def get_progress(self) -> Optional[SearchProgress]:
        """Get current search progress"""
        return self.progress
        
    def get_results(self) -> List[SearchResult]:
        """Get all search results"""
        return self.results
        
    def get_unique_domains(self) -> Set[str]:
        """Get unique domains found"""
        return self.unique_domains
        
    def get_results_by_engine(self, engine: SearchEngine) -> List[SearchResult]:
        """Get results by search engine"""
        return [result for result in self.results if result.search_engine == engine]
        
    def get_results_by_dork(self, dork: str) -> List[SearchResult]:
        """Get results by dork"""
        return [result for result in self.results if result.dork == dork]
        
    def export_results(self, format: str, output_file: str):
        """Export search results to file"""
        output_path = Path(output_file)
        output_path.parent.mkdir(parents=True, exist_ok=True)
        
        if format.lower() == 'json':
            self.export_json(output_path)
        elif format.lower() == 'csv':
            self.export_csv(output_path)
        elif format.lower() == 'html':
            self.export_html(output_path)
        elif format.lower() == 'txt':
            self.export_txt(output_path)
            
        self.log_info(f"Search results exported to {output_path}")
        
    def export_json(self, output_path: Path):
        """Export results to JSON format"""
        data = {
            'search_info': {
                'total_results': len(self.results),
                'unique_domains': len(self.unique_domains),
                'search_time': self.progress.elapsed_time if self.progress else 0
            },
            'results': []
        }
        
        for result in self.results:
            result_data = {
                'url': result.url,
                'title': result.title,
                'description': result.description,
                'search_engine': result.search_engine.value,
                'dork': result.dork,
                'position': result.position,
                'timestamp': result.timestamp
            }
            data['results'].append(result_data)
            
        with open(output_path, 'w', encoding='utf-8') as f:
            json.dump(data, f, indent=2, ensure_ascii=False)
            
    def export_csv(self, output_path: Path):
        """Export results to CSV format"""
        import csv
        
        with open(output_path, 'w', newline='', encoding='utf-8') as f:
            writer = csv.writer(f)
            writer.writerow(['URL', 'Title', 'Description', 'Search Engine', 'Dork', 'Position', 'Timestamp'])
            
            for result in self.results:
                writer.writerow([
                    result.url, result.title, result.description,
                    result.search_engine.value, result.dork,
                    result.position, result.timestamp
                ])
                
    def export_html(self, output_path: Path):
        """Export results to HTML format"""
        import html
        
        with open(output_path, 'w', encoding='utf-8') as f:
            f.write("""<!DOCTYPE html>
<html>
<head>
    <title>Dork Search Results - BoomSQL</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; }
        .header { background-color: #f0f0f0; padding: 10px; border-radius: 5px; margin-bottom: 20px; }
        .result { margin: 15px 0; padding: 10px; border-left: 3px solid #007acc; background-color: #f9f9f9; }
        .url { font-family: monospace; color: #006600; }
        .title { font-size: 18px; font-weight: bold; color: #1a0dab; }
        .description { color: #545454; margin-top: 5px; }
        .meta { font-size: 12px; color: #808080; margin-top: 5px; }
        .dork { background-color: #ffffcc; padding: 2px 5px; border-radius: 3px; }
    </style>
</head>
<body>
""")
            
            # Header
            f.write(f"""
    <div class="header">
        <h1>Dork Search Results</h1>
        <p><strong>Total Results:</strong> {len(self.results)}</p>
        <p><strong>Unique Domains:</strong> {len(self.unique_domains)}</p>
        <p><strong>Search Time:</strong> {self.progress.elapsed_time:.2f} seconds</p>
    </div>
""")
            
            # Results
            for result in self.results:
                f.write(f"""
    <div class="result">
        <div class="title">{html.escape(result.title)}</div>
        <div class="url">{html.escape(result.url)}</div>
        <div class="description">{html.escape(result.description)}</div>
        <div class="meta">
            <span class="dork">{html.escape(result.dork)}</span> |
            Engine: {result.search_engine.value} |
            Position: {result.position}
        </div>
    </div>
""")
            
            f.write("""
</body>
</html>
""")
            
    def export_txt(self, output_path: Path):
        """Export results to text format"""
        with open(output_path, 'w', encoding='utf-8') as f:
            f.write(f"Dork Search Results - BoomSQL\n")
            f.write(f"{'=' * 40}\n\n")
            f.write(f"Total Results: {len(self.results)}\n")
            f.write(f"Unique Domains: {len(self.unique_domains)}\n")
            f.write(f"Search Time: {self.progress.elapsed_time:.2f} seconds\n\n")
            
            for result in self.results:
                f.write(f"Title: {result.title}\n")
                f.write(f"URL: {result.url}\n")
                f.write(f"Description: {result.description}\n")
                f.write(f"Dork: {result.dork}\n")
                f.write(f"Engine: {result.search_engine.value}\n")
                f.write(f"Position: {result.position}\n")
                f.write(f"{'-' * 40}\n")
                
    def get_injection_candidates(self) -> List[Dict[str, Any]]:
        """Get potential injection candidates from results"""
        candidates = []
        
        for result in self.results:
            # Check if URL has parameters
            if '?' in result.url:
                parsed = urlparse(result.url)
                if parsed.query:
                    candidate = {
                        'url': result.url,
                        'title': result.title,
                        'description': result.description,
                        'dork': result.dork,
                        'search_engine': result.search_engine.value,
                        'has_parameters': True,
                        'domain': self.extract_domain(result.url)
                    }
                    candidates.append(candidate)
                    
        return candidates