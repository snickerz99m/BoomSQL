"""
Fallback implementations for missing dependencies and Unicode handling
"""
import sys
import asyncio
import warnings
from typing import Any, Dict, List, Optional, Union

# Unicode emoji fallbacks for Windows compatibility
EMOJI_FALLBACKS = {
    '🔍': '[Search]',
    '🎯': '[Target]',
    '🚀': '[Launch]',
    '⚡': '[Fast]',
    '🔧': '[Tools]',
    '📊': '[Stats]',
    '📝': '[Log]',
    '⚠️': '[Warning]',
    '✅': '[OK]',
    '❌': '[Error]',
    '🔐': '[Security]',
    '🌐': '[Web]',
    '💾': '[Save]',
    '🔄': '[Refresh]',
    '📋': '[Report]',
    '⚙️': '[Settings]',
    '🕷️': '[Spider]',
    '🛡️': '[Shield]',
    '🔑': '[Key]',
    '📄': '[Document]',
    '🗂️': '[Files]'
}

def safe_text(text: str, use_fallback: bool = None) -> str:
    """
    Convert text with emojis to safe version for display
    
    Args:
        text: Text that may contain emoji characters
        use_fallback: Force use of fallback (True) or emoji (False). 
                     If None, auto-detect based on system
    
    Returns:
        Safe text for display
    """
    if use_fallback is None:
        # Auto-detect: use fallback on Windows or if encoding issues are likely
        use_fallback = (
            sys.platform.startswith('win') or 
            (hasattr(sys.stdout, 'encoding') and 
             sys.stdout.encoding in ['cp1252', 'ascii', 'latin-1'])
        )
    
    if use_fallback:
        result = text
        for emoji, fallback in EMOJI_FALLBACKS.items():
            result = result.replace(emoji, fallback)
        return result
    else:
        return text

def safe_log_message(message: str) -> str:
    """
    Make log message safe for output by replacing problematic Unicode characters
    
    Args:
        message: Log message that may contain Unicode characters
    
    Returns:
        Safe log message
    """
    return safe_text(message, use_fallback=True)

# Fallback for aiohttp
class MockSession:
    """Mock session for when aiohttp is not available"""
    
    def __init__(self):
        self.closed = False
        
    def get(self, url: str, **kwargs):
        """Mock GET request - returns MockResponse directly"""
        return MockResponse(url)
    
    def post(self, url: str, **kwargs):
        """Mock POST request - returns MockResponse directly"""
        return MockResponse(url)
    
    async def close(self):
        """Mock close"""
        self.closed = True
        
    def __enter__(self):
        return self
        
    def __exit__(self, exc_type, exc_val, exc_tb):
        asyncio.create_task(self.close())

class MockResponse:
    """Mock response for when aiohttp is not available"""
    
    def __init__(self, url: str):
        self.url = url
        self.status = 200
        self.headers = {}
        
    async def text(self):
        """Mock text response"""
        return f"Mock response from {self.url}"
    
    async def json(self):
        """Mock JSON response"""
        return {"error": "Mock response - aiohttp not available"}
    
    async def __aenter__(self):
        return self
        
    async def __aexit__(self, exc_type, exc_val, exc_tb):
        pass

class MockClientSession:
    """Mock ClientSession for when aiohttp is not available"""
    
    def __init__(self, **kwargs):
        self.session = MockSession()
        
    async def __aenter__(self):
        return self.session
        
    async def __aexit__(self, exc_type, exc_val, exc_tb):
        pass
        
    def get(self, url: str, **kwargs):
        """Mock GET request"""
        return MockResponse(url)
    
    def post(self, url: str, **kwargs):
        """Mock POST request"""
        return MockResponse(url)
    
    async def close(self):
        """Mock close"""
        pass

# Try to import real aiohttp, fallback to mock
try:
    import aiohttp
    ClientSession = aiohttp.ClientSession
    AIOHTTP_AVAILABLE = True
except ImportError:
    warnings.warn("aiohttp not available, using mock implementation")
    class MockClientTimeout:
        def __init__(self, **kwargs):
            pass
    
    class MockTCPConnector:
        def __init__(self, **kwargs):
            pass
    
    aiohttp = type('MockAiohttp', (), {
        'ClientSession': MockClientSession,
        'ClientTimeout': MockClientTimeout,
        'TCPConnector': MockTCPConnector
    })()
    ClientSession = MockClientSession
    AIOHTTP_AVAILABLE = False

# Fallback for aiofiles
try:
    import aiofiles
    AIOFILES_AVAILABLE = True
except ImportError:
    warnings.warn("aiofiles not available, using synchronous file operations")
    
    class MockAiofiles:
        @staticmethod
        def open(filename, mode='r', **kwargs):
            return open(filename, mode, **kwargs)
    
    aiofiles = MockAiofiles()
    AIOFILES_AVAILABLE = False

# Fallback for BeautifulSoup4
try:
    from bs4 import BeautifulSoup
    BS4_AVAILABLE = True
except ImportError:
    warnings.warn("BeautifulSoup4 not available, using basic HTML parsing")
    
    class MockBeautifulSoup:
        """Mock BeautifulSoup for when bs4 is not available"""
        
        def __init__(self, markup="", features=None):
            self.markup = str(markup)
            self.text = self.markup
            
        def find(self, tag, **kwargs):
            """Mock find method"""
            return None
            
        def find_all(self, tag, **kwargs):
            """Mock find_all method"""
            return []
            
        def select(self, selector):
            """Mock select method"""
            return []
            
        def get_text(self, separator="", strip=False):
            """Mock get_text method"""
            return self.markup
            
        def get(self, key, default=None):
            """Mock get method"""
            return default
            
        @property
        def title(self):
            """Mock title property"""
            return MockTag("title", "Mock Title")
            
        @property
        def body(self):
            """Mock body property"""
            return MockTag("body", self.markup)
    
    class MockTag:
        """Mock HTML tag"""
        
        def __init__(self, name, text=""):
            self.name = name
            self.text = text
            self.attrs = {}
            
        def get(self, key, default=None):
            return self.attrs.get(key, default)
            
        def find(self, tag, **kwargs):
            return None
            
        def find_all(self, tag, **kwargs):
            return []
            
        def get_text(self, separator="", strip=False):
            return self.text
    
    BeautifulSoup = MockBeautifulSoup
    BS4_AVAILABLE = False

# Fallback for lxml
try:
    from lxml import etree as lxml_etree
    LXML_AVAILABLE = True
except ImportError:
    warnings.warn("lxml not available, using xml.etree.ElementTree")
    import xml.etree.ElementTree as lxml_etree
    LXML_AVAILABLE = False

# Enhanced XML parsing with fallbacks
def safe_parse_xml(xml_content, use_lxml=True):
    """
    Parse XML content with fallbacks for different parsers
    
    Args:
        xml_content: XML content to parse (string or file path)
        use_lxml: Whether to prefer lxml (if available)
        
    Returns:
        Parsed XML tree
    """
    import xml.etree.ElementTree as ET
    
    # Try lxml first if requested and available
    if use_lxml and LXML_AVAILABLE:
        try:
            if isinstance(xml_content, str) and xml_content.endswith('.xml'):
                return lxml_etree.parse(xml_content)
            else:
                return lxml_etree.fromstring(xml_content)
        except Exception as e:
            warnings.warn(f"lxml parsing failed, falling back to ElementTree: {e}")
    
    # Fall back to ElementTree
    try:
        if isinstance(xml_content, str) and xml_content.endswith('.xml'):
            return ET.parse(xml_content)
        else:
            return ET.fromstring(xml_content)
    except Exception as e:
        warnings.warn(f"XML parsing failed: {e}")
        return None

# Enhanced HTML parsing with fallbacks
def safe_parse_html(html_content, features=None):
    """
    Parse HTML content with fallbacks for different parsers
    
    Args:
        html_content: HTML content to parse
        features: Parser features (for BeautifulSoup compatibility)
        
    Returns:
        Parsed HTML object
    """
    if BS4_AVAILABLE:
        try:
            return BeautifulSoup(html_content, features or 'html.parser')
        except Exception as e:
            warnings.warn(f"BeautifulSoup parsing failed: {e}")
    
    # Fallback to mock implementation
    return BeautifulSoup(html_content, features)

# Export the imports and availability flags
__all__ = [
    'aiohttp', 'ClientSession', 'AIOHTTP_AVAILABLE',
    'aiofiles', 'AIOFILES_AVAILABLE',
    'BeautifulSoup', 'BS4_AVAILABLE',
    'lxml_etree', 'LXML_AVAILABLE',
    'MockSession', 'MockResponse', 'MockClientSession',
    'safe_text', 'safe_log_message', 'EMOJI_FALLBACKS',
    'safe_parse_xml', 'safe_parse_html'
]