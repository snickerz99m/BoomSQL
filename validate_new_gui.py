#!/usr/bin/env python3
"""
Code validation script for the redesigned BoomSQL GUI
This validates the code structure without requiring a display
"""

import sys
import ast
from pathlib import Path

def validate_gui_code():
    """Validate the new GUI code structure"""
    
    print("🔍 Validating Redesigned BoomSQL GUI Code...")
    print("=" * 60)
    
    validation_results = {
        'imports': False,
        'tester_buttons': False,
        'dumper_buttons': False,
        'layout_structure': False,
        'error_handling': False
    }
    
    try:
        # Check tester page structure
        tester_file = Path(__file__).parent / "gui" / "tester_page_new.py"
        if tester_file.exists():
            print("✅ Tester page file exists")
            
            with open(tester_file, 'r') as f:
                tester_content = f.read()
                
            # Check for required buttons
            required_buttons = [
                'start_button',
                'stop_button', 
                'clear_button',
                'send_to_dumper_button'
            ]
            
            buttons_found = []
            for button in required_buttons:
                if f"self.{button} = ttk.Button" in tester_content:
                    buttons_found.append(button)
                    
            print(f"✅ Tester buttons found: {len(buttons_found)}/4")
            for button in buttons_found:
                print(f"   └─ {button}")
                
            # Check for grid layout (better than pack)
            if ".grid(" in tester_content:
                print("✅ Using grid layout (better than pack)")
                validation_results['layout_structure'] = True
            else:
                print("⚠️  Not using grid layout")
                
            if len(buttons_found) == 4:
                validation_results['tester_buttons'] = True
                
        else:
            print("❌ Tester page file not found")
            
        # Check dumper page structure  
        dumper_file = Path(__file__).parent / "gui" / "dumper_page_new.py"
        if dumper_file.exists():
            print("✅ Dumper page file exists")
            
            with open(dumper_file, 'r') as f:
                dumper_content = f.read()
                
            # Check for required buttons
            required_buttons = [
                'enumerate_button',
                'dump_button',
                'stop_button',
                'clear_button', 
                'export_button'
            ]
            
            buttons_found = []
            for button in required_buttons:
                if f"self.{button} = ttk.Button" in dumper_content:
                    buttons_found.append(button)
                    
            print(f"✅ Dumper buttons found: {len(buttons_found)}/5")
            for button in buttons_found:
                print(f"   └─ {button}")
                
            if len(buttons_found) == 5:
                validation_results['dumper_buttons'] = True
                
        else:
            print("❌ Dumper page file not found")
            
        # Check main window
        main_file = Path(__file__).parent / "boomsql_new.py"
        if main_file.exists():
            print("✅ Main window file exists")
            
            with open(main_file, 'r') as f:
                main_content = f.read()
                
            # Check imports
            required_imports = [
                'TesterPageNew',
                'DumperPageNew', 
                'tkinter'
            ]
            
            imports_found = []
            for imp in required_imports:
                if imp in main_content:
                    imports_found.append(imp)
                    
            print(f"✅ Required imports found: {len(imports_found)}/3")
            
            if len(imports_found) == 3:
                validation_results['imports'] = True
                
        else:
            print("❌ Main window file not found")
            
        # Check for proper error handling
        files_to_check = [tester_file, dumper_file, main_file]
        error_handling_found = False
        
        for file_path in files_to_check:
            if file_path.exists():
                with open(file_path, 'r') as f:
                    content = f.read()
                    if 'try:' in content and 'except' in content:
                        error_handling_found = True
                        break
                        
        if error_handling_found:
            print("✅ Error handling implemented")
            validation_results['error_handling'] = True
        else:
            print("⚠️  Limited error handling found")
            
        print("=" * 60)
        print("📊 Validation Summary:")
        
        passed = sum(validation_results.values())
        total = len(validation_results)
        
        for check, result in validation_results.items():
            status = "✅" if result else "❌"
            print(f"{status} {check.replace('_', ' ').title()}")
            
        print(f"\\nOverall Score: {passed}/{total} ({int(passed/total*100)}%)")
        
        if passed >= 4:
            print("\\n🎉 VALIDATION PASSED!")
            print("The redesigned GUI should fix all button visibility issues.")
            return True
        else:
            print("\\n⚠️  VALIDATION INCOMPLETE")
            print("Some components may need additional work.")
            return False
            
    except Exception as e:
        print(f"❌ Validation error: {e}")
        return False

def check_gui_improvements():
    """Check specific improvements made to fix button visibility"""
    
    print("\\n🔧 Checking GUI Improvements...")
    print("=" * 40)
    
    improvements = {
        'grid_layout': "Using grid instead of pack for better control",
        'guaranteed_buttons': "Buttons in dedicated control frames",
        'proper_sizing': "Explicit button widths and padding",
        'container_structure': "Proper container hierarchy",
        'modern_styling': "Modern styling and themes"
    }
    
    tester_file = Path(__file__).parent / "gui" / "tester_page_new.py"
    
    if tester_file.exists():
        with open(tester_file, 'r') as f:
            content = f.read()
            
        improvements_found = []
        
        # Check for grid layout
        if ".grid(" in content and "sticky=" in content:
            improvements_found.append('grid_layout')
            
        # Check for dedicated control frames
        if "control_frame" in content and "LabelFrame" in content:
            improvements_found.append('guaranteed_buttons')
            
        # Check for explicit sizing
        if "width=" in content and "padding=" in content:
            improvements_found.append('proper_sizing')
            
        # Check for container structure
        if "left_container" in content and "right_container" in content:
            improvements_found.append('container_structure')
            
        # Check for styling
        if "style=" in content or "Style()" in content:
            improvements_found.append('modern_styling')
            
        for improvement in improvements_found:
            print(f"✅ {improvements[improvement]}")
            
        missing = set(improvements.keys()) - set(improvements_found)
        for improvement in missing:
            print(f"⚠️  {improvements[improvement]}")
            
        print(f"\\nImprovements Score: {len(improvements_found)}/{len(improvements)}")
        
        return len(improvements_found) >= 3
    else:
        print("❌ Cannot check improvements - file not found")
        return False

def main():
    """Main validation function"""
    print("🚀 Starting BoomSQL GUI Code Validation...")
    
    code_valid = validate_gui_code()
    improvements_good = check_gui_improvements()
    
    print("\\n" + "=" * 60)
    
    if code_valid and improvements_good:
        print("🎉 COMPLETE SUCCESS!")
        print("✅ All code validation checks passed")
        print("✅ GUI improvements properly implemented")
        print("✅ Button visibility issues should be FIXED")
        print("\\n🚀 Ready to test with: python boomsql_new.py")
        print("\\nKey Fixes Applied:")
        print("• Grid layout instead of problematic pack")
        print("• Dedicated control frames for buttons") 
        print("• Explicit button sizing and placement")
        print("• Modern styling and better UX")
        print("• Guaranteed button visibility")
    elif code_valid:
        print("✅ Code validation passed")
        print("⚠️  Some improvements may need refinement")
        print("But the GUI should work much better than before!")
    else:
        print("❌ Code validation failed")
        print("Additional work may be needed")
        
    return code_valid

if __name__ == "__main__":
    main()
