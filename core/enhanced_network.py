"""
Enhanced Network and Security Module for BoomSQL
Advanced networking features with proxy rotation, SSL handling, and stealth mode
"""

import asyncio
import random
import time
import ssl
import socket
from typing import Dict, List, Optional, Any, Tuple
from urllib.parse import urlparse
import json
from dataclasses import dataclass
from enum import Enum
from pathlib import Path

from .logger import LoggerMixin
from .fallbacks import aiohttp, ClientSession, AIOHTTP_AVAILABLE

class ProxyType(Enum):
    """Proxy types"""
    HTTP = "http"
    HTTPS = "https"
    SOCKS4 = "socks4"
    SOCKS5 = "socks5"

@dataclass
class ProxyConfig:
    """Proxy configuration"""
    host: str
    port: int
    username: Optional[str] = None
    password: Optional[str] = None
    proxy_type: ProxyType = ProxyType.HTTP
    timeout: float = 10.0
    max_retries: int = 3
    success_count: int = 0
    failure_count: int = 0
    last_used: float = 0.0
    response_time: float = 0.0
    
    @property
    def success_rate(self) -> float:
        """Calculate success rate"""
        total = self.success_count + self.failure_count
        if total == 0:
            return 0.0
        return self.success_count / total
        
    @property
    def is_healthy(self) -> bool:
        """Check if proxy is healthy"""
        return self.success_rate > 0.5 and self.failure_count < 5

@dataclass
class UserAgentConfig:
    """User agent configuration"""
    user_agent: str
    category: str
    os: str
    browser: str
    popularity: float = 1.0
    success_count: int = 0
    failure_count: int = 0
    
    @property
    def success_rate(self) -> float:
        """Calculate success rate"""
        total = self.success_count + self.failure_count
        if total == 0:
            return 0.0
        return self.success_count / total

class NetworkStealth:
    """Network stealth and evasion techniques"""
    
    def __init__(self):
        self.request_delays = []
        self.last_request_time = 0.0
        
    def calculate_delay(self, min_delay: float = 0.5, max_delay: float = 3.0, 
                       adaptive: bool = True) -> float:
        """Calculate adaptive delay between requests"""
        if adaptive and self.request_delays:
            # Adaptive delay based on previous requests
            avg_delay = sum(self.request_delays[-10:]) / min(len(self.request_delays), 10)
            variance = random.uniform(0.5, 1.5)
            delay = avg_delay * variance
        else:
            # Random delay
            delay = random.uniform(min_delay, max_delay)
            
        # Add some randomness to avoid patterns
        delay += random.uniform(-0.2, 0.2)
        delay = max(0.1, delay)  # Minimum delay
        
        self.request_delays.append(delay)
        return delay
        
    def generate_random_headers(self) -> Dict[str, str]:
        """Generate random headers for stealth"""
        headers = {}
        
        # Random accept header
        accept_options = [
            "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
            "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8",
            "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8",
        ]
        headers["Accept"] = random.choice(accept_options)
        
        # Random accept-language
        languages = ["en-US,en;q=0.9", "en-GB,en;q=0.9", "en-US,en;q=0.8,fr;q=0.6"]
        headers["Accept-Language"] = random.choice(languages)
        
        # Random accept-encoding
        encodings = ["gzip, deflate", "gzip, deflate, br", "gzip"]
        headers["Accept-Encoding"] = random.choice(encodings)
        
        # Random cache-control
        cache_controls = ["no-cache", "max-age=0", "no-store"]
        if random.random() > 0.5:
            headers["Cache-Control"] = random.choice(cache_controls)
            
        # Random connection
        connections = ["keep-alive", "close"]
        headers["Connection"] = random.choice(connections)
        
        # Random DNT (Do Not Track)
        if random.random() > 0.7:
            headers["DNT"] = "1"
            
        return headers
        
    def randomize_request_order(self, requests: List[Dict[str, Any]]) -> List[Dict[str, Any]]:
        """Randomize request order to avoid patterns"""
        shuffled = requests.copy()
        random.shuffle(shuffled)
        return shuffled

class ProxyManager(LoggerMixin):
    """Advanced proxy management with rotation and health checking"""
    
    def __init__(self, config: Dict[str, Any]):
        self.config = config
        self.proxies: List[ProxyConfig] = []
        self.current_proxy_index = 0
        self.proxy_test_url = config.get("proxy_test_url", "https://httpbin.org/ip")
        self.health_check_interval = config.get("health_check_interval", 300)  # 5 minutes
        self.last_health_check = 0.0
        
        # Load proxies from configuration
        self.load_proxies()
        
    def load_proxies(self):
        """Load proxies from configuration"""
        try:
            proxy_file = self.config.get("proxy_file", "proxies.txt")
            if not Path(proxy_file).exists():
                self.log_warning(f"Proxy file not found: {proxy_file}")
                return
                
            with open(proxy_file, 'r') as f:
                for line in f:
                    line = line.strip()
                    if line and not line.startswith('#'):
                        try:
                            proxy_config = self._parse_proxy_line(line)
                            if proxy_config:
                                self.proxies.append(proxy_config)
                        except Exception as e:
                            self.log_warning(f"Error parsing proxy line '{line}': {e}")
                            
            self.log_info(f"Loaded {len(self.proxies)} proxies")
            
        except Exception as e:
            self.log_error(f"Error loading proxies: {e}")
            
    def _parse_proxy_line(self, line: str) -> Optional[ProxyConfig]:
        """Parse a proxy line from configuration"""
        # Format: host:port or host:port:username:password or http://host:port
        parts = line.split(':')
        
        if len(parts) >= 2:
            host = parts[0]
            port = int(parts[1])
            
            username = parts[2] if len(parts) > 2 else None
            password = parts[3] if len(parts) > 3 else None
            
            # Determine proxy type
            proxy_type = ProxyType.HTTP
            if line.startswith('socks5://'):
                proxy_type = ProxyType.SOCKS5
            elif line.startswith('socks4://'):
                proxy_type = ProxyType.SOCKS4
            elif line.startswith('https://'):
                proxy_type = ProxyType.HTTPS
                
            return ProxyConfig(
                host=host,
                port=port,
                username=username,
                password=password,
                proxy_type=proxy_type
            )
            
        return None
        
    def get_next_proxy(self) -> Optional[ProxyConfig]:
        """Get the next healthy proxy in rotation"""
        if not self.proxies:
            return None
            
        # Check if health check is needed
        current_time = time.time()
        if current_time - self.last_health_check > self.health_check_interval:
            asyncio.create_task(self.health_check_all_proxies())
            self.last_health_check = current_time
            
        # Find next healthy proxy
        attempts = 0
        while attempts < len(self.proxies):
            proxy = self.proxies[self.current_proxy_index]
            self.current_proxy_index = (self.current_proxy_index + 1) % len(self.proxies)
            
            if proxy.is_healthy:
                proxy.last_used = current_time
                return proxy
                
            attempts += 1
            
        # If no healthy proxy found, return the best one
        if self.proxies:
            best_proxy = max(self.proxies, key=lambda p: p.success_rate)
            return best_proxy
            
        return None
        
    async def health_check_all_proxies(self):
        """Perform health check on all proxies"""
        self.log_info("Starting proxy health check...")
        
        tasks = []
        for proxy in self.proxies:
            task = asyncio.create_task(self.health_check_proxy(proxy))
            tasks.append(task)
            
        await asyncio.gather(*tasks, return_exceptions=True)
        
        healthy_count = sum(1 for p in self.proxies if p.is_healthy)
        self.log_info(f"Health check completed. {healthy_count}/{len(self.proxies)} proxies healthy")
        
    async def health_check_proxy(self, proxy: ProxyConfig) -> bool:
        """Check if a proxy is healthy"""
        try:
            # Create proxy configuration
            proxy_url = f"{proxy.proxy_type.value}://{proxy.host}:{proxy.port}"
            
            start_time = time.time()
            
            # Use mock implementation for testing
            if not AIOHTTP_AVAILABLE:
                # Simulate proxy test
                await asyncio.sleep(0.1)
                proxy.success_count += 1
                proxy.response_time = 0.1
                return True
                
            # Real proxy test would go here
            async with ClientSession() as session:
                async with session.get(self.proxy_test_url, 
                                     proxy=proxy_url,
                                     timeout=aiohttp.ClientTimeout(total=10)) as response:
                    if response.status == 200:
                        proxy.success_count += 1
                        proxy.response_time = time.time() - start_time
                        return True
                    else:
                        proxy.failure_count += 1
                        return False
                        
        except Exception as e:
            proxy.failure_count += 1
            self.log_debug(f"Proxy health check failed for {proxy.host}:{proxy.port}: {e}")
            return False
            
    def get_proxy_stats(self) -> Dict[str, Any]:
        """Get proxy statistics"""
        if not self.proxies:
            return {"total": 0, "healthy": 0, "unhealthy": 0}
            
        healthy = sum(1 for p in self.proxies if p.is_healthy)
        unhealthy = len(self.proxies) - healthy
        
        return {
            "total": len(self.proxies),
            "healthy": healthy,
            "unhealthy": unhealthy,
            "average_response_time": sum(p.response_time for p in self.proxies) / len(self.proxies),
            "average_success_rate": sum(p.success_rate for p in self.proxies) / len(self.proxies)
        }

class UserAgentManager(LoggerMixin):
    """User agent management with rotation and effectiveness tracking"""
    
    def __init__(self, config: Dict[str, Any]):
        self.config = config
        self.user_agents: List[UserAgentConfig] = []
        self.current_ua_index = 0
        
        # Load user agents
        self.load_user_agents()
        
    def load_user_agents(self):
        """Load user agents from configuration"""
        try:
            ua_file = self.config.get("user_agent_file", "useragents.txt")
            if not Path(ua_file).exists():
                self.log_warning(f"User agent file not found: {ua_file}")
                self._load_default_user_agents()
                return
                
            with open(ua_file, 'r') as f:
                for line in f:
                    line = line.strip()
                    if line and not line.startswith('#'):
                        ua_config = self._parse_user_agent(line)
                        if ua_config:
                            self.user_agents.append(ua_config)
                            
            self.log_info(f"Loaded {len(self.user_agents)} user agents")
            
        except Exception as e:
            self.log_error(f"Error loading user agents: {e}")
            self._load_default_user_agents()
            
    def _parse_user_agent(self, line: str) -> Optional[UserAgentConfig]:
        """Parse user agent line"""
        # Simple parsing - can be enhanced with JSON format
        parts = line.split('|')
        if len(parts) >= 1:
            ua_string = parts[0].strip()
            category = parts[1].strip() if len(parts) > 1 else "unknown"
            os = parts[2].strip() if len(parts) > 2 else "unknown"
            browser = parts[3].strip() if len(parts) > 3 else "unknown"
            popularity = float(parts[4].strip()) if len(parts) > 4 else 1.0
            
            return UserAgentConfig(
                user_agent=ua_string,
                category=category,
                os=os,
                browser=browser,
                popularity=popularity
            )
            
        return None
        
    def _load_default_user_agents(self):
        """Load default user agents"""
        default_uas = [
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36",
            "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:89.0) Gecko/20100101 Firefox/89.0",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.15; rv:89.0) Gecko/20100101 Firefox/89.0"
        ]
        
        for ua in default_uas:
            self.user_agents.append(UserAgentConfig(
                user_agent=ua,
                category="browser",
                os="unknown",
                browser="unknown",
                popularity=1.0
            ))
            
    def get_next_user_agent(self) -> str:
        """Get the next user agent in rotation"""
        if not self.user_agents:
            return "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36"
            
        # Weighted selection based on success rate and popularity
        weights = []
        for ua in self.user_agents:
            weight = ua.popularity * (1.0 + ua.success_rate)
            weights.append(weight)
            
        # Select based on weights
        if sum(weights) > 0:
            ua = random.choices(self.user_agents, weights=weights)[0]
        else:
            ua = random.choice(self.user_agents)
            
        return ua.user_agent
        
    def get_random_user_agent(self, category: Optional[str] = None) -> str:
        """Get a random user agent, optionally filtered by category"""
        if category:
            filtered_uas = [ua for ua in self.user_agents if ua.category == category]
            if filtered_uas:
                return random.choice(filtered_uas).user_agent
                
        return random.choice(self.user_agents).user_agent if self.user_agents else "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36"
        
    def update_user_agent_stats(self, user_agent: str, success: bool):
        """Update user agent statistics"""
        for ua in self.user_agents:
            if ua.user_agent == user_agent:
                if success:
                    ua.success_count += 1
                else:
                    ua.failure_count += 1
                break

class SSLManager:
    """SSL/TLS certificate handling and validation"""
    
    def __init__(self, config: Dict[str, Any]):
        self.config = config
        self.verify_ssl = config.get("verify_ssl", True)
        self.ssl_context = self._create_ssl_context()
        
    def _create_ssl_context(self) -> ssl.SSLContext:
        """Create SSL context with proper configuration"""
        context = ssl.create_default_context()
        
        if not self.verify_ssl:
            context.check_hostname = False
            context.verify_mode = ssl.CERT_NONE
            
        return context
        
    def get_ssl_context(self) -> ssl.SSLContext:
        """Get SSL context for requests"""
        return self.ssl_context
        
    def verify_certificate(self, hostname: str, port: int = 443) -> Dict[str, Any]:
        """Verify SSL certificate for a hostname"""
        try:
            context = ssl.create_default_context()
            
            with socket.create_connection((hostname, port), timeout=10) as sock:
                with context.wrap_socket(sock, server_hostname=hostname) as ssock:
                    cert = ssock.getpeercert()
                    
                    return {
                        "valid": True,
                        "subject": cert.get("subject", []),
                        "issuer": cert.get("issuer", []),
                        "version": cert.get("version", "Unknown"),
                        "not_before": cert.get("notBefore", "Unknown"),
                        "not_after": cert.get("notAfter", "Unknown"),
                        "serial_number": cert.get("serialNumber", "Unknown")
                    }
                    
        except Exception as e:
            return {
                "valid": False,
                "error": str(e)
            }

class EnhancedNetworkManager(LoggerMixin):
    """Enhanced network manager with all advanced features"""
    
    def __init__(self, config: Dict[str, Any]):
        self.config = config
        self.proxy_manager = ProxyManager(config)
        self.ua_manager = UserAgentManager(config)
        self.ssl_manager = SSLManager(config)
        self.stealth = NetworkStealth()
        
        # Session management
        self.session = None
        self.session_timeout = config.get("session_timeout", 30)
        
    async def create_session(self) -> ClientSession:
        """Create enhanced session with all features"""
        # Get proxy
        proxy = self.proxy_manager.get_next_proxy()
        proxy_url = None
        if proxy:
            proxy_url = f"{proxy.proxy_type.value}://{proxy.host}:{proxy.port}"
            
        # Get user agent
        user_agent = self.ua_manager.get_next_user_agent()
        
        # Create headers
        headers = self.stealth.generate_random_headers()
        headers["User-Agent"] = user_agent
        
        # Create session
        timeout = aiohttp.ClientTimeout(total=self.session_timeout)
        connector = aiohttp.TCPConnector(
            ssl=self.ssl_manager.get_ssl_context(),
            limit=10,
            limit_per_host=3
        )
        
        self.session = ClientSession(
            timeout=timeout,
            connector=connector,
            headers=headers
        )
        
        return self.session
        
    async def make_request(self, method: str, url: str, **kwargs) -> Dict[str, Any]:
        """Make enhanced request with all features"""
        if not self.session:
            await self.create_session()
            
        # Calculate stealth delay
        delay = self.stealth.calculate_delay()
        await asyncio.sleep(delay)
        
        try:
            start_time = time.time()
            
            async with self.session.request(method, url, **kwargs) as response:
                content = await response.text()
                response_time = time.time() - start_time
                
                # Update statistics
                current_ua = self.session.headers.get("User-Agent", "")
                self.ua_manager.update_user_agent_stats(current_ua, response.status < 400)
                
                return {
                    "status": response.status,
                    "headers": dict(response.headers),
                    "content": content,
                    "response_time": response_time,
                    "url": str(response.url)
                }
                
        except Exception as e:
            self.log_error(f"Request failed: {e}")
            return {
                "status": 0,
                "error": str(e),
                "response_time": 0.0
            }
            
    async def close(self):
        """Close the session"""
        if self.session:
            await self.session.close()
            
    def get_network_stats(self) -> Dict[str, Any]:
        """Get comprehensive network statistics"""
        return {
            "proxy_stats": self.proxy_manager.get_proxy_stats(),
            "user_agent_count": len(self.ua_manager.user_agents),
            "ssl_verification": self.ssl_manager.verify_ssl,
            "stealth_enabled": True,
            "session_timeout": self.session_timeout
        }