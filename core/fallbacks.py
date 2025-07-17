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
        
    async def get(self, url: str, **kwargs):
        """Mock GET request"""
        return MockResponse(url)
    
    async def post(self, url: str, **kwargs):
        """Mock POST request"""
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
    
    def __enter__(self):
        return self
        
    def __exit__(self, exc_type, exc_val, exc_tb):
        pass

class MockClientSession:
    """Mock ClientSession for when aiohttp is not available"""
    
    def __init__(self, **kwargs):
        pass
        
    async def __aenter__(self):
        return MockSession()
        
    async def __aexit__(self, exc_type, exc_val, exc_tb):
        pass

# Try to import real aiohttp, fallback to mock
try:
    import aiohttp
    ClientSession = aiohttp.ClientSession
    AIOHTTP_AVAILABLE = True
except ImportError:
    warnings.warn("aiohttp not available, using mock implementation")
    aiohttp = type('MockAiohttp', (), {
        'ClientSession': MockClientSession,
        'ClientTimeout': lambda **kwargs: None,
        'TCPConnector': lambda **kwargs: None
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

# Export the imports and availability flags
__all__ = [
    'aiohttp', 'ClientSession', 'AIOHTTP_AVAILABLE',
    'aiofiles', 'AIOFILES_AVAILABLE',
    'MockSession', 'MockResponse', 'MockClientSession',
    'safe_text', 'safe_log_message', 'EMOJI_FALLBACKS'
]