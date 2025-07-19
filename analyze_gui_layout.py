#!/usr/bin/env python3
"""
Non-GUI test to analyze button layout issues
"""

import sys
import os

# Add current directory to path
sys.path.insert(0, os.path.dirname(__file__))

def analyze_tester_page():
    """Analyze tester page code for button layout issues"""
    print("=== Analyzing SQL Tester Page ===")
    
    try:
        with open('/workspaces/BoomSQL/gui/tester_page.py', 'r') as f:
            content = f.read()
        
        # Look for button creation and layout
        lines = content.split('\n')
        in_create_widgets = False
        button_section_found = False
        
        for i, line in enumerate(lines):
            if 'def create_widgets(self):' in line:
                in_create_widgets = True
                print(f"✅ Found create_widgets method at line {i+1}")
                
            if in_create_widgets and 'control_frame = ttk.Frame' in line:
                button_section_found = True
                print(f"✅ Found control_frame creation at line {i+1}")
                
                # Print the next 20 lines to see button creation
                print("📝 Control frame and button code:")
                for j in range(i, min(i+20, len(lines))):
                    if j < len(lines):
                        print(f"  {j+1}: {lines[j]}")
                        
                break
                
        if not button_section_found:
            print("❌ Control frame section not found!")
            
        # Look for button packing
        start_button_count = content.count('start_button')
        stop_button_count = content.count('stop_button')
        
        print(f"✅ start_button references: {start_button_count}")
        print(f"✅ stop_button references: {stop_button_count}")
        
    except Exception as e:
        print(f"❌ Error analyzing tester page: {e}")

def analyze_dumper_page():
    """Analyze dumper page code for button layout issues"""
    print("\n=== Analyzing Database Dumper Page ===")
    
    try:
        with open('/workspaces/BoomSQL/gui/dumper_page.py', 'r') as f:
            content = f.read()
        
        # Look for button creation and layout
        lines = content.split('\n')
        in_create_widgets = False
        button_section_found = False
        
        for i, line in enumerate(lines):
            if 'def create_widgets(self):' in line:
                in_create_widgets = True
                print(f"✅ Found create_widgets method at line {i+1}")
                
            if in_create_widgets and 'Control buttons' in line:
                button_section_found = True
                print(f"✅ Found Control buttons comment at line {i+1}")
                
                # Print the next 25 lines to see button creation
                print("📝 Control buttons code:")
                for j in range(i, min(i+25, len(lines))):
                    if j < len(lines):
                        print(f"  {j+1}: {lines[j]}")
                        
                break
                
        if not button_section_found:
            print("❌ Control buttons section not found!")
            
        # Look for button packing
        enumerate_button_count = content.count('enumerate_button')
        dump_button_count = content.count('dump_button')
        stop_button_count = content.count('stop_button')
        
        print(f"✅ enumerate_button references: {enumerate_button_count}")
        print(f"✅ dump_button references: {dump_button_count}")
        print(f"✅ stop_button references: {stop_button_count}")
        
    except Exception as e:
        print(f"❌ Error analyzing dumper page: {e}")

def check_layout_issues():
    """Check for common GUI layout issues"""
    print("\n=== Checking for Common Layout Issues ===")
    
    # Check both files for common layout problems
    files_to_check = [
        'gui/tester_page.py',
        'gui/dumper_page.py'
    ]
    
    for file_path in files_to_check:
        try:
            with open(f'/workspaces/BoomSQL/{file_path}', 'r') as f:
                content = f.read()
                
            print(f"\n📁 Checking {file_path}:")
            
            # Check for pack_propagate issues
            if 'pack_propagate(False)' in content:
                print("  ⚠️  Found pack_propagate(False) - might hide widgets")
            else:
                print("  ✅ No pack_propagate(False) found")
                
            # Check for missing pack() calls
            button_creations = content.count('ttk.Button(')
            pack_calls = content.count('.pack(')
            
            print(f"  📊 Button creations: {button_creations}")
            print(f"  📊 Pack calls: {pack_calls}")
            
            if pack_calls < button_creations:
                print("  ⚠️  Fewer pack calls than button creations - some buttons might not be visible")
            else:
                print("  ✅ Pack calls seem sufficient")
                
        except Exception as e:
            print(f"  ❌ Error checking {file_path}: {e}")

if __name__ == "__main__":
    print("=== BoomSQL GUI Layout Analysis ===")
    
    analyze_tester_page()
    analyze_dumper_page()
    check_layout_issues()
    
    print("\n=== Analysis Complete ===")
