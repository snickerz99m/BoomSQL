#!/usr/bin/env python3
"""
GUI Test Script for BoomSQL
Tests if GUI will work on the current platform
"""

import sys
import os
import platform
from pathlib import Path

# Add the project root to Python path
project_root = Path(__file__).parent
sys.path.insert(0, str(project_root))

# Try to import tkinter
try:
    import tkinter as tk
    from tkinter import ttk
    TKINTER_AVAILABLE = True
    print("✓ tkinter module is available")
except ImportError as e:
    TKINTER_AVAILABLE = False
    print(f"✗ tkinter module not available: {e}")

def test_gui():
    """Test GUI availability"""
    print("\n=== BoomSQL GUI Compatibility Test ===")
    print(f"Platform: {platform.system()} {platform.release()}")
    print(f"Machine: {platform.machine()}")
    print(f"Python: {platform.python_version()}")
    
    if not TKINTER_AVAILABLE:
        print("\n❌ GUI NOT AVAILABLE: tkinter module missing")
        print("To fix on Ubuntu/Debian: sudo apt-get install python3-tk")
        print("To fix on CentOS/RHEL: sudo yum install tkinter")
        print("To fix on Windows: Reinstall Python with 'tcl/tk and IDLE' option")
        return False
    
    try:
        print(f"\n🔍 Testing GUI on {platform.system()}...")
        
        # Platform-specific checks
        if platform.system() == "Linux":
            display = os.environ.get("DISPLAY", "Not set")
            wayland = os.environ.get("WAYLAND_DISPLAY", "Not set")
            print(f"DISPLAY environment: {display}")
            print(f"WAYLAND_DISPLAY environment: {wayland}")
            
            if display == "Not set" and wayland == "Not set":
                print("⚠️  Warning: No display environment variables found")
        
        # Try to create a test window
        print("Creating test window...")
        root = tk.Tk()
        root.title("BoomSQL GUI Test")
        root.geometry("300x200")
        
        # Add some test widgets
        label = ttk.Label(root, text="BoomSQL GUI Test")
        label.pack(pady=20)
        
        button = ttk.Button(root, text="Click to close", command=root.destroy)
        button.pack(pady=10)
        
        status_label = ttk.Label(root, text="✓ GUI is working correctly!")
        status_label.pack(pady=10)
        
        print("✓ Test window created successfully")
        print("✓ GUI widgets working")
        print("\n🎉 GUI IS AVAILABLE!")
        print("BoomSQL should display GUI when run on this system.")
        
        # Show the window briefly
        root.after(3000, root.destroy)  # Auto-close after 3 seconds
        print("\nShowing test window for 3 seconds...")
        root.mainloop()
        
        return True
        
    except tk.TclError as e:
        print(f"\n❌ GUI NOT AVAILABLE: {e}")
        if "no display name" in str(e).lower():
            print("Fix: Set up X11 forwarding or run on a system with a display")
        elif "couldn't connect" in str(e).lower():
            print("Fix: Ensure X11 server is running and accessible")
        return False
        
    except Exception as e:
        print(f"\n❌ GUI NOT AVAILABLE: Unexpected error: {e}")
        return False

def print_recommendations():
    """Print platform-specific recommendations"""
    print("\n=== Platform-Specific Recommendations ===")
    
    system = platform.system()
    
    if system == "Windows":
        print("Windows:")
        print("- GUI should work out of the box")
        print("- If not working, reinstall Python with tkinter support")
        print("- Download from: https://python.org")
        
    elif system == "Darwin":  # macOS
        print("macOS:")
        print("- GUI should work with standard Python installation")
        print("- If using Homebrew: brew install python-tk")
        print("- If using pyenv: pyenv install --enable-framework")
        
    elif system == "Linux":
        print("Linux:")
        print("- For GUI on desktop: install python3-tk package")
        print("  Ubuntu/Debian: sudo apt-get install python3-tk")
        print("  CentOS/RHEL: sudo yum install tkinter")
        print("  Fedora: sudo dnf install python3-tkinter")
        print("- For SSH/remote: use X11 forwarding")
        print("  ssh -X username@hostname")
        print("- For headless servers: use --skip-gui flag")
        
    else:
        print(f"{system}:")
        print("- Ensure tkinter is installed for your Python distribution")
        print("- Check your system's package manager for python-tk packages")

if __name__ == "__main__":
    gui_works = test_gui()
    print_recommendations()
    
    if gui_works:
        print(f"\n✅ RESULT: GUI should work on this {platform.system()} system")
        sys.exit(0)
    else:
        print(f"\n❌ RESULT: GUI will NOT work on this {platform.system()} system")
        print("BoomSQL will run in command-line mode")
        sys.exit(1)
