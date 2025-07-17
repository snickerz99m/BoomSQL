#!/bin/bash

# BoomSQL Test Script
# This script tests BoomSQL functionality in both CLI and GUI modes

echo "🧪 BoomSQL Functionality Test"
echo "============================="
echo ""

# Test 1: CLI Mode
echo "📋 Test 1: CLI Mode Functionality"
echo "----------------------------------"
python3 boomsql.py
echo ""

# Test 2: GUI Mode (if display available)
echo "🖥️  Test 2: GUI Mode Test"
echo "-------------------------"

# Check if we can create a simple tkinter window
python3 -c "
import tkinter as tk
try:
    root = tk.Tk()
    root.withdraw()
    print('✅ tkinter available')
    root.destroy()
    gui_available = True
except Exception as e:
    print(f'❌ GUI not available: {e}')
    gui_available = False
"

# Test 3: Module Import Test
echo ""
echo "📦 Test 3: Module Import Test"
echo "-----------------------------"
python3 -c "
import sys
import os
sys.path.append('/workspaces/BoomSQL')

modules = [
    'core.config_manager',
    'core.logger', 
    'core.sql_injection_engine',
    'core.web_crawler',
    'core.dork_searcher',
    'core.report_generator',
    'core.database_dumper',
    'core.advanced_sql_engine',
    'core.enhanced_network',
    'gui.main_window'
]

for module in modules:
    try:
        __import__(module)
        print(f'✅ {module}')
    except Exception as e:
        print(f'❌ {module}: {e}')
"

# Test 4: Configuration Test
echo ""
echo "⚙️  Test 4: Configuration Test"
echo "------------------------------"
python3 -c "
import sys
sys.path.append('/workspaces/BoomSQL')

try:
    from core.config_manager import ConfigManager
    config = ConfigManager()
    print(f'✅ Configuration loaded')
    print(f'   - Payloads: {len(config.payloads) if hasattr(config, \"payloads\") else \"N/A\"}')
    print(f'   - Error signatures: {len(config.error_signatures) if hasattr(config, \"error_signatures\") else \"N/A\"}')
    print(f'   - User agents: {len(config.user_agents) if hasattr(config, \"user_agents\") else \"N/A\"}')
except Exception as e:
    print(f'❌ Configuration test failed: {e}')
"

echo ""
echo "🎯 All tests completed!"
echo "======================="
echo ""
echo "💡 To run BoomSQL with GUI:"
echo "   ./run_gui.sh"
echo ""
echo "💡 To run BoomSQL in CLI mode:"
echo "   python3 boomsql.py"
