#!/usr/bin/env python3
"""
Simple test to check GUI button visibility
"""

import tkinter as tk
from tkinter import ttk
import sys
import os

# Add current directory to path
sys.path.insert(0, os.path.dirname(__file__))

def test_tester_buttons():
    """Test tester page buttons"""
    root = tk.Tk()
    root.title("BoomSQL Button Test - SQL Tester")
    root.geometry("800x600")
    
    # Import the tester page
    try:
        from gui.tester_page import TesterPage
        
        # Mock app object
        class MockApp:
            def __init__(self):
                self.config = type('obj', (object,), {'config': {}})
                
        mock_app = MockApp()
        
        # Create tester page
        tester = TesterPage(root, mock_app)
        tester.pack(fill=tk.BOTH, expand=True)
        
        print("✅ Tester page created successfully")
        print("✅ Looking for control buttons...")
        
        # Check if buttons exist
        if hasattr(tester, 'start_button'):
            print("✅ Start button found")
            print(f"   Text: {tester.start_button.cget('text')}")
            print(f"   State: {tester.start_button.cget('state')}")
        else:
            print("❌ Start button NOT found")
            
        if hasattr(tester, 'stop_button'):
            print("✅ Stop button found")
            print(f"   Text: {tester.stop_button.cget('text')}")
            print(f"   State: {tester.stop_button.cget('state')}")
        else:
            print("❌ Stop button NOT found")
            
        if hasattr(tester, 'clear_button'):
            print("✅ Clear button found")
            print(f"   Text: {tester.clear_button.cget('text')}")
        else:
            print("❌ Clear button NOT found")
        
        # Keep window open for inspection
        root.after(3000, root.destroy)  # Close after 3 seconds
        root.mainloop()
        
    except Exception as e:
        print(f"❌ Error creating tester page: {e}")
        import traceback
        traceback.print_exc()

def test_dumper_buttons():
    """Test dumper page buttons"""
    root = tk.Tk()
    root.title("BoomSQL Button Test - Database Dumper")
    root.geometry("800x600")
    
    # Import the dumper page
    try:
        from gui.dumper_page import DumperPage
        
        # Mock app object
        class MockApp:
            def __init__(self):
                self.config = type('obj', (object,), {'config': {}})
                
        mock_app = MockApp()
        
        # Create dumper page
        dumper = DumperPage(root, mock_app)
        dumper.pack(fill=tk.BOTH, expand=True)
        
        print("✅ Dumper page created successfully")
        print("✅ Looking for control buttons...")
        
        # Check if buttons exist
        if hasattr(dumper, 'enumerate_button'):
            print("✅ Enumerate button found")
            print(f"   Text: {dumper.enumerate_button.cget('text')}")
            print(f"   State: {dumper.enumerate_button.cget('state')}")
        else:
            print("❌ Enumerate button NOT found")
            
        if hasattr(dumper, 'dump_button'):
            print("✅ Dump button found")  
            print(f"   Text: {dumper.dump_button.cget('text')}")
            print(f"   State: {dumper.dump_button.cget('state')}")
        else:
            print("❌ Dump button NOT found")
            
        if hasattr(dumper, 'stop_button'):
            print("✅ Stop button found")
            print(f"   Text: {dumper.stop_button.cget('text')}")
            print(f"   State: {dumper.stop_button.cget('state')}")
        else:
            print("❌ Stop button NOT found")
            
        if hasattr(dumper, 'export_button'):
            print("✅ Export button found")
            print(f"   Text: {dumper.export_button.cget('text')}")
            print(f"   State: {dumper.export_button.cget('state')}")
        else:
            print("❌ Export button NOT found")
        
        # Keep window open for inspection
        root.after(3000, root.destroy)  # Close after 3 seconds
        root.mainloop()
        
    except Exception as e:
        print(f"❌ Error creating dumper page: {e}")
        import traceback
        traceback.print_exc()

if __name__ == "__main__":
    print("=== BoomSQL GUI Button Test ===")
    print()
    
    print("Testing SQL Tester buttons:")
    test_tester_buttons()
    
    print()
    print("Testing Database Dumper buttons:")
    test_dumper_buttons()
    
    print()
    print("=== Button Test Complete ===")
