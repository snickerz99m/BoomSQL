#!/usr/bin/env python3
"""
Test script for BoomSQL core functionality (simplified)
"""

import sys
import os
from pathlib import Path

# Add the project root to Python path
project_root = Path(__file__).parent
sys.path.insert(0, str(project_root))

def test_basic_functionality():
    """Test basic functionality without complex dependencies"""
    print("Testing basic core functionality...")
    
    # Test config manager
    try:
        from core.config_manager import ConfigManager
        config = ConfigManager()
        
        app_name = config.get("Application.Name", "Unknown")
        print(f"✓ Config manager working - App: {app_name}")
        
        databases = config.get_supported_databases()
        print(f"✓ Supported databases: {len(databases)}")
        
    except Exception as e:
        print(f"✗ Config test failed: {e}")
        return False
    
    # Test logging
    try:
        from core.logger import setup_logging
        logger = setup_logging()
        logger.info("Test message")
        print("✓ Logging system working")
        
    except Exception as e:
        print(f"✗ Logging test failed: {e}")
        return False
    
    # Test SQL engine without aiohttp
    try:
        from core.sql_injection_engine import (
            SqlPayload, ErrorSignature, WafBypass, InjectionType, 
            DatabaseType, InjectionVector
        )
        
        # Test basic classes
        payload = SqlPayload(
            title="Test Payload",
            payload="' OR 1=1 --",
            risk=3,
            platform="generic",
            category="boolean",
            injection_type=InjectionType.BOOLEAN_BASED
        )
        
        signature = ErrorSignature(
            database=DatabaseType.MYSQL,
            patterns=["You have an error in your SQL syntax"],
            severity="high"
        )
        
        bypass = WafBypass(
            title="Test Bypass",
            category="encoding",
            description="Test bypass method",
            transform_function="test"
        )
        
        print("✓ SQL injection classes working")
        
    except Exception as e:
        print(f"✗ SQL injection classes test failed: {e}")
        return False
    
    # Test data structures
    try:
        from core.database_dumper import DatabaseInfo, TableInfo, ColumnInfo
        
        # Test database structures
        db_info = DatabaseInfo(
            name="test_db",
            version="1.0",
            user="test_user",
            hostname="localhost"
        )
        
        table_info = TableInfo(
            name="test_table",
            schema="test_schema",
            row_count=100
        )
        
        column_info = ColumnInfo(
            name="test_column",
            type="VARCHAR",
            length=255,
            nullable=True
        )
        
        print("✓ Database structures working")
        
    except Exception as e:
        print(f"✗ Database structures test failed: {e}")
        return False
    
    print("\n✓ All basic functionality tests passed!")
    return True

def test_file_loading():
    """Test file loading capabilities"""
    print("\nTesting file loading...")
    
    # Test payload file loading
    try:
        import xml.etree.ElementTree as ET
        
        if Path("payloads.xml").exists():
            tree = ET.parse("payloads.xml")
            root = tree.getroot()
            payload_count = len(root.findall("payload"))
            print(f"✓ payloads.xml loaded - {payload_count} payloads")
        else:
            print("⚠ payloads.xml not found")
            
    except Exception as e:
        print(f"✗ Payload file loading failed: {e}")
        return False
    
    # Test error signature file loading
    try:
        if Path("error_signatures.xml").exists():
            tree = ET.parse("error_signatures.xml")
            root = tree.getroot()
            signature_count = len(root.findall("signature"))
            print(f"✓ error_signatures.xml loaded - {signature_count} signatures")
        else:
            print("⚠ error_signatures.xml not found")
            
    except Exception as e:
        print(f"✗ Error signature file loading failed: {e}")
        return False
    
    # Test config file loading
    try:
        if Path("config.json").exists():
            import json
            with open("config.json", 'r') as f:
                config_data = json.load(f)
            print(f"✓ config.json loaded - {len(config_data)} sections")
        else:
            print("⚠ config.json not found")
            
    except Exception as e:
        print(f"✗ Config file loading failed: {e}")
        return False
    
    print("✓ File loading tests passed!")
    return True

def main():
    """Run all tests"""
    print("BoomSQL - Simplified Core Test")
    print("=" * 40)
    
    success = True
    
    if not test_basic_functionality():
        success = False
    
    if not test_file_loading():
        success = False
    
    print("\n" + "=" * 40)
    if success:
        print("✓ All tests passed! BoomSQL core is working.")
        return 0
    else:
        print("✗ Some tests failed.")
        return 1

if __name__ == "__main__":
    sys.exit(main())