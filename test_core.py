#!/usr/bin/env python3
"""
Test script for BoomSQL core functionality (no GUI)
"""

import sys
import os
from pathlib import Path

# Add the project root to Python path
project_root = Path(__file__).parent
sys.path.insert(0, str(project_root))

def test_basic_imports():
    """Test basic imports"""
    try:
        from core.config_manager import ConfigManager
        from core.logger import setup_logging
        print("✓ Core imports successful")
        return True
    except Exception as e:
        print(f"✗ Core import failed: {e}")
        return False

def test_config_manager():
    """Test configuration manager"""
    try:
        from core.config_manager import ConfigManager
        config = ConfigManager()
        
        # Test basic config operations
        test_value = config.get("Application.Name", "Unknown")
        print(f"✓ Config manager working - App name: {test_value}")
        
        # Test setting and getting values
        config.set("Test.Value", "test123")
        retrieved = config.get("Test.Value")
        assert retrieved == "test123", f"Expected 'test123', got '{retrieved}'"
        print("✓ Config set/get working")
        
        # Test supported databases
        databases = config.get_supported_databases()
        print(f"✓ Supported databases: {len(databases)} ({', '.join(databases[:5])}...)")
        
        return True
    except Exception as e:
        print(f"✗ Config manager test failed: {e}")
        return False

def test_logging():
    """Test logging system"""
    try:
        from core.logger import setup_logging
        logger = setup_logging()
        logger.info("Test log message")
        print("✓ Logging system working")
        return True
    except Exception as e:
        print(f"✗ Logging test failed: {e}")
        return False

def test_sql_engine():
    """Test SQL injection engine"""
    try:
        from core.sql_injection_engine import SqlInjectionEngine
        
        # Test basic initialization
        config = {
            "RequestTimeout": 30, 
            "MaxThreads": 3,
            "PayloadFile": "payloads.xml",
            "ErrorSignatureFile": "error_signatures.xml",
            "WafBypassFile": "waf_bypasses.xml"
        }
        engine = SqlInjectionEngine(config)
        
        # Test payload loading
        assert len(engine.payloads) > 0, "No payloads loaded"
        print(f"✓ SQL engine working - Loaded {len(engine.payloads)} payloads")
        
        # Test error signature loading
        assert len(engine.error_signatures) > 0, "No error signatures loaded"
        print(f"✓ SQL engine working - Loaded {len(engine.error_signatures)} error signatures")
        
        # Test WAF bypass loading
        assert len(engine.waf_bypasses) > 0, "No WAF bypasses loaded"
        print(f"✓ SQL engine working - Loaded {len(engine.waf_bypasses)} WAF bypasses")
        
        return True
    except Exception as e:
        print(f"✗ SQL engine test failed: {e}")
        return False

def test_web_crawler():
    """Test web crawler"""
    try:
        from core.web_crawler import WebCrawler
        
        config = {
            "MaxDepth": 3,
            "MaxUrls": 100,
            "RequestTimeout": 30,
            "UserAgent": "BoomSQL/2.0 Test"
        }
        crawler = WebCrawler(config)
        
        print("✓ Web crawler initialized successfully")
        return True
    except Exception as e:
        print(f"✗ Web crawler test failed: {e}")
        return False

def test_dork_searcher():
    """Test dork searcher"""
    try:
        from core.dork_searcher import DorkSearcher
        
        config = {
            "MaxResults": 100,
            "RequestTimeout": 30,
            "UserAgentFile": "useragents.txt",
            "ProxyFile": "proxies.txt"
        }
        searcher = DorkSearcher(config)
        
        print("✓ Dork searcher initialized successfully")
        return True
    except Exception as e:
        print(f"✗ Dork searcher test failed: {e}")
        return False

def test_report_generator():
    """Test report generator"""
    try:
        from core.report_generator import ReportGenerator
        
        config = {}
        generator = ReportGenerator(config)
        
        print("✓ Report generator initialized successfully")
        return True
    except Exception as e:
        print(f"✗ Report generator test failed: {e}")
        return False

def test_xml_files():
    """Test XML file loading"""
    try:
        import xml.etree.ElementTree as ET
        
        # Test payloads.xml
        if Path("payloads.xml").exists():
            tree = ET.parse("payloads.xml")
            root = tree.getroot()
            payload_count = len(root.findall("payload"))
            print(f"✓ payloads.xml loaded - {payload_count} payloads")
        else:
            print("⚠ payloads.xml not found")
            
        # Test error_signatures.xml
        if Path("error_signatures.xml").exists():
            tree = ET.parse("error_signatures.xml")
            root = tree.getroot()
            signature_count = len(root.findall("signature"))
            print(f"✓ error_signatures.xml loaded - {signature_count} signatures")
        else:
            print("⚠ error_signatures.xml not found")
            
        # Test waf_bypasses.xml
        if Path("waf_bypasses.xml").exists():
            tree = ET.parse("waf_bypasses.xml")
            root = tree.getroot()
            bypass_count = len(root.findall("bypass"))
            print(f"✓ waf_bypasses.xml loaded - {bypass_count} bypasses")
        else:
            print("⚠ waf_bypasses.xml not found")
        
        return True
    except Exception as e:
        print(f"✗ XML file test failed: {e}")
        return False

def main():
    """Run all tests"""
    print("BoomSQL - Core Functionality Test")
    print("=" * 40)
    
    tests = [
        ("Basic Imports", test_basic_imports),
        ("Configuration Manager", test_config_manager),
        ("Logging System", test_logging),
        ("XML Files", test_xml_files),
        ("SQL Injection Engine", test_sql_engine),
        ("Web Crawler", test_web_crawler),
        ("Dork Searcher", test_dork_searcher),
        ("Report Generator", test_report_generator),
    ]
    
    passed = 0
    total = len(tests)
    
    for test_name, test_func in tests:
        print(f"\nTesting {test_name}...")
        try:
            if test_func():
                passed += 1
        except Exception as e:
            print(f"✗ {test_name} failed with exception: {e}")
    
    print(f"\n" + "=" * 40)
    print(f"Test Results: {passed}/{total} tests passed")
    
    if passed == total:
        print("✓ All tests passed! BoomSQL core functionality is working.")
        return 0
    else:
        print("✗ Some tests failed. Check the errors above.")
        return 1

if __name__ == "__main__":
    sys.exit(main())