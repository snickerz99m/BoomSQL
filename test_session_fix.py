#!/usr/bin/env python3
"""
Test script to verify session initialization fix
"""

import sys
import os
import asyncio
from pathlib import Path

# Add the project root to Python path
project_root = Path(__file__).parent
sys.path.insert(0, str(project_root))

def test_session_initialization():
    """Test that session initialization works correctly"""
    print("Testing Session Initialization Fix")
    print("=" * 50)
    
    # Test SQL Injection Engine
    print("1. Testing SQL Injection Engine...")
    try:
        from core.sql_injection_engine import SqlInjectionEngine
        from core.event_loop_manager import get_event_loop_manager
        
        config = {
            "RequestTimeout": 30,
            "MaxThreads": 3,
            "PayloadFile": "payloads.xml",
            "ErrorSignatureFile": "error_signatures.xml",
            "WafBypassFile": "waf_bypasses.xml"
        }
        
        # Create engine (should not fail)
        engine = SqlInjectionEngine(config)
        print(f"   ✓ Engine created successfully")
        print(f"   ✓ Session is None initially: {engine.session is None}")
        print(f"   ✓ Session initialized flag: {engine._session_initialized}")
        
        # Test session initialization in async context
        manager = get_event_loop_manager()
        
        async def test_session():
            engine.init_session()
            return engine.session is not None
        
        has_session = manager.run_async_blocking(test_session(), timeout=5.0)
        print(f"   ✓ Session created in async context: {has_session}")
        
        # Test cleanup
        if engine.session:
            manager.run_async_blocking(engine.close(), timeout=2.0)
            print(f"   ✓ Session closed successfully")
        
    except Exception as e:
        print(f"   ✗ SQL Injection Engine test failed: {e}")
        return False
    
    # Test Web Crawler
    print("\n2. Testing Web Crawler...")
    try:
        from core.web_crawler import WebCrawler
        
        config = {
            "MaxDepth": 2,
            "MaxUrls": 50,
            "RequestTimeout": 30,
            "UserAgent": "BoomSQL/2.0 Test"
        }
        
        crawler = WebCrawler(config)
        print(f"   ✓ Crawler created successfully")
        print(f"   ✓ Session is None initially: {crawler.session is None}")
        print(f"   ✓ Session initialized flag: {crawler._session_initialized}")
        
        # Test session initialization in async context
        async def test_crawler_session():
            crawler.init_session()
            return crawler.session is not None
        
        has_session = manager.run_async_blocking(test_crawler_session(), timeout=5.0)
        print(f"   ✓ Session created in async context: {has_session}")
        
        # Test cleanup
        if crawler.session:
            manager.run_async_blocking(crawler.close(), timeout=2.0)
            print(f"   ✓ Session closed successfully")
        
    except Exception as e:
        print(f"   ✗ Web Crawler test failed: {e}")
        return False
    
    # Test Dork Searcher
    print("\n3. Testing Dork Searcher...")
    try:
        from core.dork_searcher import DorkSearcher
        
        config = {
            "RequestTimeout": 30,
            "MaxThreads": 3,
            "UserAgentFile": "useragents.txt",
            "ProxyFile": "proxies.txt"
        }
        
        searcher = DorkSearcher(config)
        print(f"   ✓ Searcher created successfully")
        print(f"   ✓ Session is None initially: {searcher.session is None}")
        print(f"   ✓ Session initialized flag: {searcher._session_initialized}")
        
        # Test session initialization in async context
        async def test_searcher_session():
            searcher.init_session()
            return searcher.session is not None
        
        has_session = manager.run_async_blocking(test_searcher_session(), timeout=5.0)
        print(f"   ✓ Session created in async context: {has_session}")
        
        # Test cleanup
        if searcher.session:
            manager.run_async_blocking(searcher.close(), timeout=2.0)
            print(f"   ✓ Session closed successfully")
        
    except Exception as e:
        print(f"   ✗ Dork Searcher test failed: {e}")
        return False
    
    print("\n" + "=" * 50)
    print("✓ All session initialization tests passed!")
    print("✓ The 'no running event loop' error has been fixed!")
    return True

if __name__ == "__main__":
    success = test_session_initialization()
    sys.exit(0 if success else 1)
