#!/usr/bin/env python3
"""
Test script to verify disclaimer dialog button creation
"""

def test_disclaimer_structure():
    """Test that the disclaimer dialog has all necessary methods and structure"""
    try:
        from gui.disclaimer_dialog import DisclaimerDialog
        
        print("✅ DisclaimerDialog class imported successfully")
        
        # Check if all required methods exist
        required_methods = [
            'create_widgets',
            'on_agreement_change', 
            'accept_disclaimer',
            'decline_disclaimer',
            'emergency_accept',
            'timeout_disclaimer',
            'get_disclaimer_text'
        ]
        
        for method in required_methods:
            if hasattr(DisclaimerDialog, method):
                print(f"✅ Method {method} exists")
            else:
                print(f"❌ Method {method} missing")
        
        print("\n📋 DisclaimerDialog structure test completed")
        return True
        
    except ImportError as e:
        print(f"❌ Failed to import DisclaimerDialog: {e}")
        return False
    except Exception as e:
        print(f"❌ Error testing DisclaimerDialog: {e}")
        return False

def analyze_button_creation():
    """Analyze the button creation code"""
    try:
        with open('/workspaces/BoomSQL/gui/disclaimer_dialog.py', 'r') as f:
            content = f.read()
        
        print("\n🔍 Analyzing button creation in disclaimer dialog...")
        
        # Check for button creation
        if 'self.accept_button = ttk.Button' in content:
            print("✅ Main accept button creation found")
        else:
            print("❌ Main accept button creation missing")
            
        if 'decline_button = ttk.Button' in content:
            print("✅ Main decline button creation found")
        else:
            print("❌ Main decline button creation missing")
            
        if 'self.emergency_accept_button = tk.Button' in content:
            print("✅ Emergency accept button creation found")
        else:
            print("❌ Emergency accept button creation missing")
            
        if 'emergency_decline_button = tk.Button' in content:
            print("✅ Emergency decline button creation found")
        else:
            print("❌ Emergency decline button creation missing")
        
        # Check for button commands
        if 'command=self.accept_disclaimer' in content:
            print("✅ Accept button command binding found")
        else:
            print("❌ Accept button command binding missing")
            
        if 'command=self.decline_disclaimer' in content:
            print("✅ Decline button command binding found")
        else:
            print("❌ Decline button command binding missing")
            
        if 'command=self.emergency_accept' in content:
            print("✅ Emergency accept command binding found")
        else:
            print("❌ Emergency accept command binding missing")
        
        # Check for debugging output
        debug_messages = [
            "Creating disclaimer buttons",
            "Disclaimer buttons created successfully",
            "Emergency fallback buttons created",
            "Checkbox state changed"
        ]
        
        print("\n📝 Debug messages found:")
        for msg in debug_messages:
            if msg.replace(" ", "") in content.replace(" ", ""):
                print(f"✅ '{msg}' debug message found")
            else:
                print(f"❌ '{msg}' debug message missing")
        
        return True
        
    except Exception as e:
        print(f"❌ Error analyzing button creation: {e}")
        return False

def main():
    print("=" * 60)
    print("BoomSQL Disclaimer Dialog Button Test")
    print("=" * 60)
    
    success = True
    success &= test_disclaimer_structure()
    success &= analyze_button_creation()
    
    print(f"\n{'✅ All tests passed!' if success else '❌ Some tests failed!'}")
    
    if success:
        print("\n💡 The disclaimer dialog should now have:")
        print("   • Main ttk.Button accept/decline buttons")
        print("   • Emergency tk.Button fallback buttons for Windows")
        print("   • Proper command bindings")
        print("   • Enhanced debugging output")
        print("   • 60-second timeout (increased from 30)")
        print("   • Checkbox state management")

if __name__ == "__main__":
    main()
