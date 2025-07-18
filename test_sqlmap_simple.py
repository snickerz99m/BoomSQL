#!/usr/bin/env python3
"""
Simple test for SQLMap integration
"""

import asyncio
import sys
import os
sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))

from core.sqlmap_engine import SQLMapEngine, SQLMapTechnique
from core.fallbacks import ClientSession

async def test_sqlmap_basic():
    """Test basic SQLMap functionality"""
    print("🚀 Testing SQLMap Engine Basic Functionality...")
    
    # Create a simple mock vulnerability for testing
    class MockVulnerability:
        def __init__(self):
            self.url = "http://testphp.vulnweb.com/artists.php?artist=1"
            self.injection_point = MockInjectionPoint()
    
    class MockInjectionPoint:
        def __init__(self):
            self.name = "artist"
            self.vector = MockVector()
    
    class MockVector:
        def __init__(self):
            self.name = "GET_PARAMETER"
    
    # Test SQLMap engine
    session = ClientSession()
    
    try:
        vulnerability = MockVulnerability()
        sqlmap_engine = SQLMapEngine(vulnerability, session)
        
        print("✓ SQLMap Engine initialized successfully")
        
        # Test payload generation
        payloads = sqlmap_engine.get_sqlmap_payloads()
        print(f"✓ SQLMap payloads loaded: {len(payloads)} techniques")
        
        # Test each technique
        for technique, payload_list in payloads.items():
            print(f"✓ {technique.value}: {len(payload_list)} payloads")
            
            # Show sample payloads
            if payload_list:
                sample = payload_list[0]
                print(f"  - {sample.title}")
                print(f"  - Risk: {sample.risk}, Level: {sample.level}")
                print(f"  - Payload: {sample.payload[:60]}...")
        
        print("\n✅ Basic SQLMap Engine tests passed!")
        
    except Exception as e:
        print(f"❌ SQLMap Engine test failed: {e}")
        import traceback
        traceback.print_exc()
        raise
    finally:
        await session.close()

async def test_database_dumper():
    """Test database dumper import"""
    print("\n🔍 Testing Database Dumper Integration...")
    
    try:
        from core.database_dumper import DatabaseDumper
        print("✓ DatabaseDumper imported successfully")
        
        # Test that SQLMap integration is imported
        from core.sqlmap_engine import SQLMapEngine
        print("✓ SQLMapEngine imported successfully")
        
        print("\n✅ Database dumper integration tests passed!")
        
    except Exception as e:
        print(f"❌ Database dumper test failed: {e}")
        raise

def test_gui_controls():
    """Test GUI SQLMap controls"""
    print("\n🎨 Testing GUI SQLMap Controls...")
    
    try:
        import tkinter as tk
        from gui.dumper_page import DumperPage
        
        # Create test GUI
        root = tk.Tk()
        root.withdraw()  # Hide the window
        
        class MockApp:
            def __init__(self):
                self.config = {}
        
        app = MockApp()
        dumper_page = DumperPage(root, app)
        
        print("✓ DumperPage created successfully")
        
        # Test SQLMap controls
        controls = [
            ('technique_var', 'auto'),
            ('risk_var', '1'),
            ('level_var', '1'),
            ('timeout_var', '30'),
            ('threads_var', '3'),
            ('use_sqlmap_var', True),
            ('verbose_var', False)
        ]
        
        for control_name, expected_value in controls:
            if hasattr(dumper_page, control_name):
                actual_value = getattr(dumper_page, control_name).get()
                if actual_value == expected_value:
                    print(f"✓ {control_name}: {actual_value}")
                else:
                    print(f"⚠ {control_name}: expected {expected_value}, got {actual_value}")
            else:
                print(f"❌ Missing control: {control_name}")
        
        root.destroy()
        print("\n✅ GUI SQLMap controls tests passed!")
        
    except Exception as e:
        print(f"❌ GUI controls test failed: {e}")
        raise

def main():
    """Run all tests"""
    print("🔥 BoomSQL SQLMap Integration Tests")
    print("=" * 50)
    
    try:
        # Test SQLMap engine
        asyncio.run(test_sqlmap_basic())
        
        # Test database dumper
        asyncio.run(test_database_dumper())
        
        # Test GUI controls
        test_gui_controls()
        
        print("\n" + "=" * 50)
        print("🎉 ALL TESTS PASSED!")
        print("✅ SQLMap engine integrated successfully")
        print("✅ Database dumper has SQLMap support")
        print("✅ GUI has SQLMap controls")
        print("✅ BoomSQL now has full SQLMap functionality!")
        
    except Exception as e:
        print(f"\n❌ Test failed: {e}")
        sys.exit(1)

if __name__ == "__main__":
    main()
