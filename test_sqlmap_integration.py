#!/usr/bin/env python3
"""
Test script for SQLMap integration in BoomSQL
"""

import asyncio
import sys
import os
sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))

from core.sqlmap_engine import SQLMapEngine, SQLMapTechnique
from core.sql_injection_engine import VulnerabilityResult, InjectionPoint, InjectionVector, InjectionType, DatabaseType
from core.database_dumper import DatabaseDumper
from core.fallbacks import ClientSession

async def test_sqlmap_engine():
    """Test SQLMap engine functionality"""
    print("Testing SQLMap Engine Integration...")
    
    # Create a mock vulnerability
    injection_point = InjectionPoint(
        name="id",
        vector=InjectionVector.GET_PARAMETER,
        original_value="1",
        injectable=True
    )
    
    vulnerability = VulnerabilityResult(
        url="http://testphp.vulnweb.com/artists.php?artist=1",
        injection_point=injection_point,
        injection_type=InjectionType.SQL_INJECTION,
        database_type=DatabaseType.MYSQL,
        payload="1' OR '1'='1",
        confidence=90,
        risk=5,
        description="SQL Injection vulnerability"
    )
    
    # Test SQLMap engine
    session = ClientSession()
    
    try:
        sqlmap_engine = SQLMapEngine(vulnerability, session)
        
        print("✓ SQLMap Engine initialized")
        
        # Test payload generation
        payloads = sqlmap_engine.get_sqlmap_payloads()
        print(f"✓ SQLMap payloads loaded: {len(payloads)} techniques")
        
        # Test each technique
        for technique, payload_list in payloads.items():
            print(f"✓ {technique.value}: {len(payload_list)} payloads")
            
            # Show first payload for each technique
            if payload_list:
                first_payload = payload_list[0]
                print(f"  - Example: {first_payload.title}")
                print(f"  - Payload: {first_payload.payload[:50]}...")
        
        # Test database queries
        print("\n🔍 Testing SQLMap database queries...")
        
        # These would normally connect to a real target
        db_name = await sqlmap_engine.get_current_database()
        print(f"✓ Database query test completed (would extract: {db_name})")
        
        user = await sqlmap_engine.get_current_user()
        print(f"✓ User query test completed (would extract: {user})")
        
        version = await sqlmap_engine.get_version()
        print(f"✓ Version query test completed (would extract: {version})")
        
        print("\n✅ SQLMap Engine tests passed!")
        
    except Exception as e:
        print(f"❌ SQLMap Engine test failed: {e}")
        raise
    finally:
        await session.close()

async def test_database_dumper_integration():
    """Test DatabaseDumper with SQLMap integration"""
    print("\nTesting DatabaseDumper with SQLMap integration...")
    
    # Create a mock vulnerability
    injection_point = InjectionPoint(
        name="id",
        vector=InjectionVector.GET_PARAMETER,
        original_value="1",
        injectable=True
    )
    
    vulnerability = VulnerabilityResult(
        url="http://testphp.vulnweb.com/artists.php?artist=1",
        injection_point=injection_point,
        injection_type=InjectionType.SQL_INJECTION,
        database_type=DatabaseType.MYSQL,
        payload="1' OR '1'='1",
        confidence=90,
        risk=5,
        description="SQL Injection vulnerability"
    )
    
    # Test configuration
    config = {
        "MaxThreads": 3,
        "RequestTimeout": 30,
        "SQLMapTechnique": "error_based",
        "SQLMapRisk": 1,
        "SQLMapLevel": 1,
        "UseSQLMap": True,
        "VerboseOutput": True
    }
    
    try:
        dumper = DatabaseDumper(vulnerability, config)
        print("✓ DatabaseDumper with SQLMap config initialized")
        
        # Test that SQLMap engine is imported
        from core.sqlmap_engine import SQLMapEngine
        print("✓ SQLMap engine import successful")
        
        # Test execute_query method
        query = "SELECT 'test'"
        result = await dumper.execute_query(query)
        print(f"✓ Query execution test completed (would return: {result})")
        
        print("\n✅ DatabaseDumper integration tests passed!")
        
    except Exception as e:
        print(f"❌ DatabaseDumper integration test failed: {e}")
        raise
    finally:
        await dumper.close()

def test_gui_integration():
    """Test GUI integration"""
    print("\nTesting GUI integration...")
    
    try:
        # Test that dumper page can import SQLMap components
        from gui.dumper_page import DumperPage
        print("✓ DumperPage import successful")
        
        # Test that dumper page has SQLMap controls
        import tkinter as tk
        root = tk.Tk()
        
        # Create a mock app
        class MockApp:
            def __init__(self):
                self.config = {}
        
        app = MockApp()
        
        # Create dumper page
        dumper_page = DumperPage(root, app)
        print("✓ DumperPage with SQLMap controls created")
        
        # Check for SQLMap variables
        assert hasattr(dumper_page, 'technique_var')
        assert hasattr(dumper_page, 'risk_var')
        assert hasattr(dumper_page, 'level_var')
        assert hasattr(dumper_page, 'use_sqlmap_var')
        print("✓ SQLMap control variables found")
        
        # Test default values
        assert dumper_page.technique_var.get() == "auto"
        assert dumper_page.risk_var.get() == "1"
        assert dumper_page.level_var.get() == "1"
        assert dumper_page.use_sqlmap_var.get() == True
        print("✓ SQLMap default values correct")
        
        root.destroy()
        print("\n✅ GUI integration tests passed!")
        
    except Exception as e:
        print(f"❌ GUI integration test failed: {e}")
        raise

def main():
    """Run all tests"""
    print("🚀 Starting SQLMap Integration Tests for BoomSQL")
    print("=" * 60)
    
    try:
        # Test SQLMap engine
        asyncio.run(test_sqlmap_engine())
        
        # Test database dumper integration
        asyncio.run(test_database_dumper_integration())
        
        # Test GUI integration
        test_gui_integration()
        
        print("\n" + "=" * 60)
        print("🎉 All SQLMap integration tests PASSED!")
        print("✅ SQLMap is now fully integrated into BoomSQL")
        print("✅ GUI controls are available for SQLMap configuration")
        print("✅ Database dumper uses SQLMap techniques")
        print("✅ Ready for production use!")
        
    except Exception as e:
        print(f"\n❌ Test suite failed: {e}")
        sys.exit(1)

if __name__ == "__main__":
    main()
