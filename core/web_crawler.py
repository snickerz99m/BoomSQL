"""
Web Crawler for BoomSQL
Advanced web crawler with parameter extraction and injection point detection
"""

import asyncio
import re
import time
from typing import Dict, List, Optional, Set, Tuple, Any
from urllib.parse import urljoin, urlparse, parse_qs, urlencode
from urllib.robotparser import RobotFileParser
from pathlib import Path
from dataclasses import dataclass, field
from enum import Enum
import json

from .logger import LoggerMixin
from .fallbacks import aiohttp, ClientSession, AIOHTTP_AVAILABLE, BeautifulSoup, BS4_AVAILABLE
from .event_loop_manager import get_event_loop_manager, gui_async

class ParameterType(Enum):
    """Parameter types"""
    GET = "get"
    POST = "post"
    COOKIE = "cookie"
    HEADER = "header"
    JSON = "json"
    XML = "xml"

@dataclass
class Parameter:
    """Web parameter information"""
    name: str
    value: str
    type: ParameterType
    source_url: str
    form_action: str = ""
    method: str = "GET"
    required: bool = False
    
@dataclass
class CrawledUrl:
    """Crawled URL information"""
    url: str
    title: str
    status_code: int
    content_type: str
    parameters: List[Parameter] = field(default_factory=list)
    forms: List[Dict[str, Any]] = field(default_factory=list)
    cookies: Dict[str, str] = field(default_factory=dict)
    headers: Dict[str, str] = field(default_factory=dict)
    depth: int = 0
    parent_url: str = ""
    response_time: float = 0.0
    content_length: int = 0
    
@dataclass
class CrawlProgress:
    """Crawling progress information"""
    urls_found: int
    urls_crawled: int
    urls_pending: int
    current_url: str
    current_depth: int
    max_depth: int
    start_time: float
    parameters_found: int
    forms_found: int
    
    @property
    def progress_percentage(self) -> float:
        """Calculate progress percentage"""
        if self.urls_found == 0:
            return 0.0
        return (self.urls_crawled / self.urls_found) * 100
        
    @property
    def elapsed_time(self) -> float:
        """Get elapsed time in seconds"""
        return time.time() - self.start_time
        
    @property
    def crawl_rate(self) -> float:
        """Get crawling rate (URLs per second)"""
        if self.elapsed_time == 0:
            return 0.0
        return self.urls_crawled / self.elapsed_time

class WebCrawler(LoggerMixin):
    """Advanced web crawler with parameter extraction"""
    
    def __init__(self, config: Dict[str, Any]):
        self.config = config
        self.session = None
        self.visited_urls: Set[str] = set()
        self.crawled_urls: List[CrawledUrl] = []
        self.parameters: List[Parameter] = []
        self.pending_urls: List[Tuple[str, int, str]] = []  # (url, depth, parent)
        self.robots_cache: Dict[str, RobotFileParser] = {}
        self.progress = None
        self.is_crawling = False
        self.cancel_requested = False
        
        # Initialize session variables (but don't create session yet)
        self.session = None
        self._session_initialized = False
        
    def init_session(self):
        """Initialize aiohttp session (only when event loop is running)"""
        if self._session_initialized:
            return
            
        try:
            # Check if we have a running event loop
            loop = None
            try:
                loop = asyncio.get_running_loop()
            except RuntimeError:
                # No running loop, we'll create session later when needed
                return
                
            timeout = aiohttp.ClientTimeout(total=self.config.get("RequestTimeout", 30))
            connector = aiohttp.TCPConnector(
                limit=self.config.get("MaxThreads", 5),
                ssl=False
            )
            
            headers = {
                'User-Agent': self.config.get("UserAgent", "BoomSQL/2.0 Web Crawler"),
                'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8',
                'Accept-Language': self.config.get("AcceptLanguage", "en-US,en;q=0.5"),
                'Accept-Encoding': self.config.get("AcceptEncoding", "gzip, deflate"),
                'Connection': self.config.get("Connection", "keep-alive")
            }
            
            self.session = aiohttp.ClientSession(
                timeout=timeout,
                connector=connector,
                headers=headers
            )
            
            self._session_initialized = True
            
        except Exception as e:
            print(f"Failed to initialize web crawler session: {e}")
            self._session_initialized = True  # Mark as initialized to avoid retries
        
    async def close(self):
        """Close the session"""
        if self.session:
            await self.session.close()
            self.session = None
            self._session_initialized = False
    
    def __del__(self):
        """Cleanup when object is destroyed"""
        if hasattr(self, 'session') and self.session and not self.session.closed:
            # Schedule cleanup for next event loop iteration
            try:
                import asyncio
                loop = asyncio.get_running_loop()
                if loop.is_running():
                    loop.create_task(self.close())
            except RuntimeError:
                # No running loop, which is fine during cleanup
                pass
            except:
                pass  # Ignore other errors during cleanup
            
    async def crawl(self, start_url: str, callback=None) -> List[CrawledUrl]:
        """Crawl website starting from given URL"""
        self.log_info(f"Starting crawl from: {start_url}")
        
        # Ensure session is initialized
        self.init_session()
        
        try:
            self.is_crawling = True
            self.cancel_requested = False
            self.visited_urls.clear()
            self.crawled_urls.clear()
            self.parameters.clear()
            self.pending_urls.clear()
            
            # Initialize progress
            self.progress = CrawlProgress(
                urls_found=1,
                urls_crawled=0,
                urls_pending=1,
                current_url=start_url,
                current_depth=0,
                max_depth=self.config.get("MaxDepth", 5),
                start_time=time.time(),
                parameters_found=0,
                forms_found=0
            )
            
            # Add start URL to pending
            self.pending_urls.append((start_url, 0, ""))
            
            max_urls = self.config.get("MaxUrls", 1000)
            max_depth = self.config.get("MaxDepth", 5)
            
            # Process URLs
            while self.pending_urls and not self.cancel_requested:
                if len(self.crawled_urls) >= max_urls:
                    break
                    
                url, depth, parent = self.pending_urls.pop(0)
                
                if depth > max_depth:
                    continue
                    
                if url in self.visited_urls:
                    continue
                    
                self.visited_urls.add(url)
                self.progress.current_url = url
                self.progress.current_depth = depth
                self.progress.urls_pending = len(self.pending_urls)
                
                if callback:
                    callback(f"Crawling: {url}")
                    
                try:
                    crawled_url = await self.crawl_url(url, depth, parent)
                    if crawled_url:
                        self.crawled_urls.append(crawled_url)
                        self.progress.urls_crawled += 1
                        self.progress.parameters_found += len(crawled_url.parameters)
                        self.progress.forms_found += len(crawled_url.forms)
                        
                        # Extract new URLs
                        new_urls = await self.extract_urls(crawled_url)
                        for new_url in new_urls:
                            if new_url not in self.visited_urls and len(self.pending_urls) < max_urls:
                                self.pending_urls.append((new_url, depth + 1, url))
                                self.progress.urls_found += 1
                                
                except Exception as e:
                    self.log_error(f"Error crawling {url}: {e}")
                    
                # Add delay between requests
                await asyncio.sleep(self.config.get("RequestDelay", 1000) / 1000)
                
        except Exception as e:
            self.log_error(f"Error during crawling: {e}")
        finally:
            # Ensure proper cleanup
            self.is_crawling = False
            try:
                if self.session and not self.session.closed:
                    await self.close()
            except Exception as cleanup_error:
                self.log_warning(f"Error during session cleanup: {cleanup_error}")
            
        self.log_info(f"Crawling completed. Found {len(self.crawled_urls)} URLs with {len(self.parameters)} parameters")
        
        return self.crawled_urls
        
    async def crawl_url(self, url: str, depth: int, parent: str) -> Optional[CrawledUrl]:
        """Crawl a single URL"""
        # Ensure session is initialized
        self.init_session()
        
        # If session is still None, return None
        if self.session is None:
            self.log_info("Session not available, skipping URL crawl")
            return None
        
        try:
            # Check robots.txt
            if not await self.is_allowed_by_robots(url):
                self.log_info(f"URL blocked by robots.txt: {url}")
                return None
                
            start_time = time.time()
            
            async with self.session.get(url) as response:
                content = await response.text()
                response_time = time.time() - start_time
                
                # Create crawled URL object
                crawled_url = CrawledUrl(
                    url=url,
                    title=self.extract_title(content),
                    status_code=response.status,
                    content_type=response.headers.get('Content-Type', ''),
                    depth=depth,
                    parent_url=parent,
                    response_time=response_time,
                    content_length=len(content),
                    headers=dict(response.headers),
                    cookies=dict(response.cookies) if response.cookies else {}
                )
                
                # Extract parameters and forms
                if response.status == 200 and 'text/html' in crawled_url.content_type:
                    # Extract GET parameters from URL
                    crawled_url.parameters.extend(self.extract_get_parameters(url))
                    
                    # Extract forms and POST parameters
                    forms = self.extract_forms(content, url)
                    crawled_url.forms = forms
                    
                    for form in forms:
                        for param_name, param_value in form.get('inputs', {}).items():
                            parameter = Parameter(
                                name=param_name,
                                value=param_value,
                                type=ParameterType.POST,
                                source_url=url,
                                form_action=form.get('action', ''),
                                method=form.get('method', 'GET'),
                                required=form.get('required_fields', {}).get(param_name, False)
                            )
                            crawled_url.parameters.append(parameter)
                            self.parameters.append(parameter)
                            
                    # Extract potential injection points from JavaScript
                    if self.config.get("EnableJavaScriptParsing", False):
                        js_params = self.extract_js_parameters(content, url)
                        crawled_url.parameters.extend(js_params)
                        self.parameters.extend(js_params)
                        
                    # Extract cookie parameters
                    if self.config.get("EnableCookieExtraction", True):
                        for cookie_name, cookie_value in crawled_url.cookies.items():
                            parameter = Parameter(
                                name=cookie_name,
                                value=cookie_value,
                                type=ParameterType.COOKIE,
                                source_url=url
                            )
                            crawled_url.parameters.append(parameter)
                            self.parameters.append(parameter)
                            
                    # Extract header parameters
                    if self.config.get("EnableHeaderExtraction", True):
                        for header_name in ['User-Agent', 'Referer', 'X-Forwarded-For']:
                            if header_name in crawled_url.headers:
                                parameter = Parameter(
                                    name=header_name,
                                    value=crawled_url.headers[header_name],
                                    type=ParameterType.HEADER,
                                    source_url=url
                                )
                                crawled_url.parameters.append(parameter)
                                self.parameters.append(parameter)
                                
                return crawled_url
                
        except Exception as e:
            self.log_error(f"Error crawling URL {url}: {e}")
            return None
            
    def extract_title(self, content: str) -> str:
        """Extract page title from HTML content"""
        try:
            soup = BeautifulSoup(content, 'html.parser')
            title_tag = soup.find('title')
            if title_tag:
                return title_tag.get_text().strip()
        except Exception:
            pass
        return ""
        
    def extract_get_parameters(self, url: str) -> List[Parameter]:
        """Extract GET parameters from URL"""
        parameters = []
        
        try:
            parsed_url = urlparse(url)
            if parsed_url.query:
                params = parse_qs(parsed_url.query)
                for param_name, param_values in params.items():
                    if param_values:
                        parameter = Parameter(
                            name=param_name,
                            value=param_values[0],
                            type=ParameterType.GET,
                            source_url=url
                        )
                        parameters.append(parameter)
                        
        except Exception as e:
            self.log_error(f"Error extracting GET parameters from {url}: {e}")
            
        return parameters
        
    def extract_forms(self, content: str, base_url: str) -> List[Dict[str, Any]]:
        """Extract forms from HTML content"""
        forms = []
        
        try:
            soup = BeautifulSoup(content, 'html.parser')
            
            for form in soup.find_all('form'):
                form_data = {
                    'action': urljoin(base_url, form.get('action', '')),
                    'method': form.get('method', 'GET').upper(),
                    'inputs': {},
                    'required_fields': {}
                }
                
                # Extract form inputs
                for input_tag in form.find_all(['input', 'textarea', 'select']):
                    input_name = input_tag.get('name')
                    if input_name:
                        input_value = input_tag.get('value', '')
                        input_type = input_tag.get('type', 'text')
                        
                        # Skip certain input types
                        if input_type in ['submit', 'reset', 'button', 'image']:
                            continue
                            
                        form_data['inputs'][input_name] = input_value
                        form_data['required_fields'][input_name] = input_tag.get('required') is not None
                        
                        # Handle select options
                        if input_tag.name == 'select':
                            options = input_tag.find_all('option')
                            if options:
                                selected_option = input_tag.find('option', selected=True)
                                if selected_option:
                                    form_data['inputs'][input_name] = selected_option.get('value', '')
                                else:
                                    form_data['inputs'][input_name] = options[0].get('value', '')
                                    
                forms.append(form_data)
                
        except Exception as e:
            self.log_error(f"Error extracting forms from {base_url}: {e}")
            
        return forms
        
    def extract_js_parameters(self, content: str, base_url: str) -> List[Parameter]:
        """Extract parameters from JavaScript code"""
        parameters = []
        
        try:
            # Look for common JavaScript patterns
            js_patterns = [
                r'\.get\(["\']([^"\']+)["\']',  # jQuery get
                r'\.post\(["\']([^"\']+)["\']',  # jQuery post
                r'ajax\(["\']([^"\']+)["\']',    # AJAX calls
                r'fetch\(["\']([^"\']+)["\']',   # Fetch API
                r'XMLHttpRequest.*open\(["\'][^"\']*["\'],\s*["\']([^"\']+)["\']',  # XMLHttpRequest
                r'location\.href\s*=\s*["\']([^"\']+)["\']',  # Location changes
                r'window\.location\s*=\s*["\']([^"\']+)["\']'  # Window location
            ]
            
            for pattern in js_patterns:
                matches = re.findall(pattern, content, re.IGNORECASE)
                for match in matches:
                    if '?' in match:
                        # Extract parameters from URL
                        params = self.extract_get_parameters(match)
                        for param in params:
                            param.source_url = base_url
                            parameters.append(param)
                            
        except Exception as e:
            self.log_error(f"Error extracting JS parameters from {base_url}: {e}")
            
        return parameters
        
    async def extract_urls(self, crawled_url: CrawledUrl) -> List[str]:
        """Extract URLs from crawled content"""
        # Ensure session is initialized
        self.init_session()
        
        # If session is still None, return empty list
        if self.session is None:
            self.log_info("Session not available, skipping URL extraction")
            return []
        
        urls = []
        
        try:
            # Get the content again (this is simplified - in practice you'd cache it)
            async with self.session.get(crawled_url.url) as response:
                content = await response.text()
                
            soup = BeautifulSoup(content, 'html.parser')
            
            # Extract URLs from various elements
            for tag in soup.find_all(['a', 'form', 'script', 'link']):
                url = None
                
                if tag.name == 'a':
                    url = tag.get('href')
                elif tag.name == 'form':
                    url = tag.get('action')
                elif tag.name == 'script':
                    url = tag.get('src')
                elif tag.name == 'link':
                    url = tag.get('href')
                    
                if url:
                    # Make URL absolute
                    absolute_url = urljoin(crawled_url.url, url)
                    
                    # Filter URLs
                    if self.should_crawl_url(absolute_url):
                        urls.append(absolute_url)
                        
        except Exception as e:
            self.log_error(f"Error extracting URLs from {crawled_url.url}: {e}")
            
        return urls
        
    def should_crawl_url(self, url: str) -> bool:
        """Check if URL should be crawled"""
        try:
            parsed_url = urlparse(url)
            
            # Check scheme
            if parsed_url.scheme not in ['http', 'https']:
                return False
                
            # Check file extension
            path = parsed_url.path.lower()
            excluded_extensions = self.config.get("ExcludedExtensions", [])
            
            for ext in excluded_extensions:
                if path.endswith(ext):
                    return False
                    
            # Check if it's a relevant file type
            file_extensions = self.config.get("FileExtensions", [])
            if file_extensions:
                has_relevant_extension = any(path.endswith(ext) for ext in file_extensions)
                has_parameters = '?' in url
                
                # Allow URLs with parameters or relevant extensions
                if not (has_relevant_extension or has_parameters or path.endswith('/')):
                    return False
                    
            return True
            
        except Exception:
            return False
            
    async def is_allowed_by_robots(self, url: str) -> bool:
        """Check if URL is allowed by robots.txt"""
        # Ensure session is initialized
        self.init_session()
        
        # If session is still None, allow by default
        if self.session is None:
            return True
        
        try:
            parsed_url = urlparse(url)
            base_url = f"{parsed_url.scheme}://{parsed_url.netloc}"
            
            if base_url not in self.robots_cache:
                robots_url = urljoin(base_url, '/robots.txt')
                
                try:
                    async with self.session.get(robots_url) as response:
                        if response.status == 200:
                            robots_content = await response.text()
                            
                            # Parse robots.txt
                            robot_parser = RobotFileParser()
                            robot_parser.set_url(robots_url)
                            robot_parser.parse(robots_content.splitlines())
                            
                            self.robots_cache[base_url] = robot_parser
                        else:
                            self.robots_cache[base_url] = None
                            
                except Exception:
                    self.robots_cache[base_url] = None
                    
            robot_parser = self.robots_cache[base_url]
            if robot_parser:
                user_agent = self.config.get("UserAgent", "BoomSQL/2.0")
                return robot_parser.can_fetch(user_agent, url)
                
        except Exception:
            pass
            
        return True
        
    def cancel_crawl(self):
        """Cancel the current crawling operation"""
        self.cancel_requested = True
        self.log_info("Crawl cancellation requested")
        
    def get_progress(self) -> Optional[CrawlProgress]:
        """Get current crawl progress"""
        return self.progress
        
    def get_parameters(self) -> List[Parameter]:
        """Get all discovered parameters"""
        return self.parameters
        
    def get_urls_with_parameters(self) -> List[CrawledUrl]:
        """Get URLs that have parameters"""
        return [url for url in self.crawled_urls if url.parameters]
        
    def get_forms(self) -> List[Dict[str, Any]]:
        """Get all discovered forms"""
        forms = []
        for url in self.crawled_urls:
            for form in url.forms:
                form['source_url'] = url.url
                forms.append(form)
        return forms
        
    def export_results(self, format: str, output_file: str):
        """Export crawl results to file"""
        output_path = Path(output_file)
        output_path.parent.mkdir(parents=True, exist_ok=True)
        
        if format.lower() == 'json':
            self.export_json(output_path)
        elif format.lower() == 'csv':
            self.export_csv(output_path)
        elif format.lower() == 'html':
            self.export_html(output_path)
            
        self.log_info(f"Crawl results exported to {output_path}")
        
    def export_json(self, output_path: Path):
        """Export results to JSON format"""
        data = {
            'crawl_info': {
                'urls_crawled': len(self.crawled_urls),
                'parameters_found': len(self.parameters),
                'forms_found': len(self.get_forms()),
                'crawl_time': self.progress.elapsed_time if self.progress else 0
            },
            'urls': [],
            'parameters': []
        }
        
        for url in self.crawled_urls:
            url_data = {
                'url': url.url,
                'title': url.title,
                'status_code': url.status_code,
                'content_type': url.content_type,
                'depth': url.depth,
                'parent_url': url.parent_url,
                'response_time': url.response_time,
                'content_length': url.content_length,
                'parameters': len(url.parameters),
                'forms': len(url.forms)
            }
            data['urls'].append(url_data)
            
        for param in self.parameters:
            param_data = {
                'name': param.name,
                'value': param.value,
                'type': param.type.value,
                'source_url': param.source_url,
                'form_action': param.form_action,
                'method': param.method,
                'required': param.required
            }
            data['parameters'].append(param_data)
            
        with open(output_path, 'w', encoding='utf-8') as f:
            json.dump(data, f, indent=2, ensure_ascii=False)
            
    def export_csv(self, output_path: Path):
        """Export results to CSV format"""
        import csv
        
        # Export URLs
        urls_file = output_path.parent / f"{output_path.stem}_urls.csv"
        with open(urls_file, 'w', newline='', encoding='utf-8') as f:
            writer = csv.writer(f)
            writer.writerow(['URL', 'Title', 'Status Code', 'Content Type', 'Depth', 'Parent URL', 'Response Time', 'Content Length', 'Parameters', 'Forms'])
            
            for url in self.crawled_urls:
                writer.writerow([
                    url.url, url.title, url.status_code, url.content_type,
                    url.depth, url.parent_url, url.response_time, url.content_length,
                    len(url.parameters), len(url.forms)
                ])
                
        # Export parameters
        params_file = output_path.parent / f"{output_path.stem}_parameters.csv"
        with open(params_file, 'w', newline='', encoding='utf-8') as f:
            writer = csv.writer(f)
            writer.writerow(['Name', 'Value', 'Type', 'Source URL', 'Form Action', 'Method', 'Required'])
            
            for param in self.parameters:
                writer.writerow([
                    param.name, param.value, param.type.value, param.source_url,
                    param.form_action, param.method, param.required
                ])
                
    def export_html(self, output_path: Path):
        """Export results to HTML format"""
        import html
        
        with open(output_path, 'w', encoding='utf-8') as f:
            f.write("""<!DOCTYPE html>
<html>
<head>
    <title>Web Crawl Results - BoomSQL</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; }
        .header { background-color: #f0f0f0; padding: 10px; border-radius: 5px; margin-bottom: 20px; }
        .section { margin: 20px 0; }
        table { border-collapse: collapse; width: 100%; }
        th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }
        th { background-color: #f2f2f2; }
        .url { font-family: monospace; }
        .parameter { background-color: #e9f5ff; }
    </style>
</head>
<body>
""")
            
            # Header
            f.write(f"""
    <div class="header">
        <h1>Web Crawl Results</h1>
        <p><strong>URLs Crawled:</strong> {len(self.crawled_urls)}</p>
        <p><strong>Parameters Found:</strong> {len(self.parameters)}</p>
        <p><strong>Forms Found:</strong> {len(self.get_forms())}</p>
        <p><strong>Crawl Time:</strong> {self.progress.elapsed_time:.2f} seconds</p>
    </div>
""")
            
            # URLs section
            f.write("""
    <div class="section">
        <h2>Crawled URLs</h2>
        <table>
            <tr>
                <th>URL</th>
                <th>Title</th>
                <th>Status</th>
                <th>Content Type</th>
                <th>Depth</th>
                <th>Parameters</th>
                <th>Forms</th>
            </tr>
""")
            
            for url in self.crawled_urls:
                f.write(f"""
            <tr>
                <td class="url">{html.escape(url.url)}</td>
                <td>{html.escape(url.title)}</td>
                <td>{url.status_code}</td>
                <td>{html.escape(url.content_type)}</td>
                <td>{url.depth}</td>
                <td>{len(url.parameters)}</td>
                <td>{len(url.forms)}</td>
            </tr>
""")
            
            f.write("        </table>\n    </div>\n")
            
            # Parameters section
            f.write("""
    <div class="section">
        <h2>Parameters Found</h2>
        <table>
            <tr>
                <th>Name</th>
                <th>Value</th>
                <th>Type</th>
                <th>Source URL</th>
                <th>Method</th>
                <th>Required</th>
            </tr>
""")
            
            for param in self.parameters:
                f.write(f"""
            <tr class="parameter">
                <td><strong>{html.escape(param.name)}</strong></td>
                <td>{html.escape(param.value)}</td>
                <td>{param.type.value.upper()}</td>
                <td class="url">{html.escape(param.source_url)}</td>
                <td>{param.method}</td>
                <td>{'Yes' if param.required else 'No'}</td>
            </tr>
""")
            
            f.write("        </table>\n    </div>\n")
            
            f.write("""
</body>
</html>
""")
            
    def get_injection_candidates(self) -> List[Dict[str, Any]]:
        """Get potential injection candidates"""
        candidates = []
        
        for url in self.crawled_urls:
            for param in url.parameters:
                candidate = {
                    'url': url.url,
                    'parameter': param.name,
                    'value': param.value,
                    'type': param.type.value,
                    'method': param.method,
                    'form_action': param.form_action,
                    'required': param.required,
                    'source_url': param.source_url
                }
                candidates.append(candidate)
                
        return candidates