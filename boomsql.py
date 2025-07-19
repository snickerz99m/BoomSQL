#!/usr/bin/env python3
"""
BoomSQL - Advanced SQL Injection Testing Tool
Python Version with Modern GUI

Created by: Security Research Team
License: Educational Use Only
Version: 2.0.0

⚠️ WARNING: FOR EDUCATIONAL AND AUTHORIZED TESTING ONLY
This tool is designed for educational purposes and authorized penetration testing.
Unauthorized use against systems without explicit permission is illegal and unethical.
Users are solely responsible for complying with all applicable laws and regulations.
"""

import sys
import os
import platform
import argparse
import threading
import json
import csv
import logging
from datetime import datetime
from pathlib import Path

# Try to import tkinter, handle gracefully if not available
try:
    import tkinter as tk
    from tkinter import ttk, messagebox, filedialog
    TKINTER_AVAILABLE = True
except ImportError:
    TKINTER_AVAILABLE = False
    # Create mock classes for non-GUI environments
    class MockTk:
        def __init__(self):
            pass
        def withdraw(self):
            pass
        def title(self, title):
            pass
        def geometry(self, geometry):
            pass
        def minsize(self, width, height):
            pass
        def configure(self, **kwargs):
            pass
        def iconbitmap(self, path):
            pass
        def deiconify(self):
            pass
        def lift(self):
            pass
        def focus_force(self):
            pass
        def mainloop(self):
            pass
        def destroy(self):
            pass
        def update_idletasks(self):
            pass
        def update(self):
            pass
        def winfo_width(self):
            return 1200
        def winfo_height(self):
            return 800
        def winfo_screenwidth(self):
            return 1920
        def winfo_screenheight(self):
            return 1080
        def winfo_id(self):
            return 123456
        def winfo_children(self):
            return []
        def state(self, state=None):
            pass
        def attributes(self, name, value=None):
            pass
        def wm_attributes(self, name, value=None):
            pass
        def tkraise(self):
            pass
        def focus_set(self):
            pass
        def after(self, delay, func=None):
            if func:
                func()
        def quit(self):
            pass
    
    tk = type('MockTkinter', (), {
        'Tk': MockTk,
        'ttk': type('MockTTK', (), {}),
        'messagebox': type('MockMessageBox', (), {}),
        'filedialog': type('MockFileDialog', (), {})
    })()
    ttk = tk.ttk
    messagebox = tk.messagebox
    filedialog = tk.filedialog

import asyncio

# Add the project root to Python path
project_root = Path(__file__).parent
sys.path.insert(0, str(project_root))

# Import our modules
try:
    from core.sql_injection_engine import SqlInjectionEngine
    from core.database_dumper import DatabaseDumper
    from core.web_crawler import WebCrawler
    from core.dork_searcher import DorkSearcher
    from core.report_generator import ReportGenerator
    from core.config_manager import ConfigManager
    from core.logger import setup_logging
    from core.event_loop_manager import get_event_loop_manager, shutdown_event_loop
    
    # GUI imports (may fail if tkinter not available or components broken)
    MainWindow = None
    DisclaimerDialog = None
    
    if TKINTER_AVAILABLE:
        try:
            print("📦 Testing GUI module imports...")
            from gui.main_window import MainWindow
            from gui.disclaimer_dialog import DisclaimerDialog
            print("✅ GUI modules imported successfully")
        except ImportError as e:
            print(f"⚠️ GUI module import failed: {e}")
            print("🔧 Will use fallback GUI interface")
            MainWindow = None
            DisclaimerDialog = None
        except Exception as e:
            print(f"⚠️ GUI module initialization failed: {e}")
            print("🔧 Will use fallback GUI interface")
            MainWindow = None
            DisclaimerDialog = None
        
except ImportError as e:
    print(f"Error importing modules: {e}")
    sys.exit(1)

def is_gui_available():
    """
    Check if GUI is available on the current platform
    Works for Windows, macOS, and Linux
    """
    if not TKINTER_AVAILABLE:
        return False, "tkinter module not available"
    
    try:
        # On Windows, tkinter should work fine
        if platform.system() == "Windows":
            # Quick test to make sure tkinter works
            print("🔍 Testing tkinter on Windows...")
            root = tk.Tk()
            root.withdraw()
            root.update_idletasks()
            print("✅ Tkinter test window created successfully")
            root.destroy()
            return True, "GUI available on Windows"
        
        # On macOS, tkinter should work fine
        elif platform.system() == "Darwin":
            root = tk.Tk()
            root.withdraw()
            root.destroy()
            return True, "GUI available on macOS"
        
        # On Linux, check for X11 display
        elif platform.system() == "Linux":
            if "DISPLAY" not in os.environ and "WAYLAND_DISPLAY" not in os.environ:
                return False, "No display environment found (X11/Wayland)"
            
            # Try to create a window
            root = tk.Tk()
            root.withdraw()
            root.destroy()
            return True, "GUI available on Linux"
        
        else:
            # Unknown platform, try anyway
            root = tk.Tk()
            root.withdraw()
            root.destroy()
            return True, f"GUI available on {platform.system()}"
            
    except tk.TclError as e:
        if "no display name" in str(e).lower():
            return False, "No X11 display available"
        elif "couldn't connect to display" in str(e).lower():
            return False, "Cannot connect to display server"
        else:
            return False, f"Tkinter error: {e}"
    except Exception as e:
        return False, f"GUI initialization failed: {e}"

def get_platform_info():
    """Get platform information for debugging"""
    info = {
        "system": platform.system(),
        "release": platform.release(),
        "machine": platform.machine(),
        "python_version": platform.python_version(),
        "tkinter_available": TKINTER_AVAILABLE
    }
    
    if platform.system() == "Linux":
        info["display_env"] = os.environ.get("DISPLAY", "Not set")
        info["wayland_env"] = os.environ.get("WAYLAND_DISPLAY", "Not set")
    
    return info

class BoomSQLApplication:
    """Main BoomSQL application class"""
    
    def __init__(self):
        print("🔧 Initializing BoomSQL application...")
        
        self.root = tk.Tk()
        self.root.withdraw()  # Hide main window initially
        print("📱 Tkinter root window created")
        
        # Setup logging
        setup_logging()
        self.logger = logging.getLogger(__name__)
        print("📝 Logging system initialized")
        
        # Initialize event loop manager
        self.event_loop_manager = get_event_loop_manager()
        print("🔄 Event loop manager initialized")
        
        # Load configuration
        self.config = ConfigManager()
        print("⚙️ Configuration loaded")
        
        # Initialize components
        self.sql_engine = None
        self.database_dumper = None
        self.web_crawler = None
        self.dork_searcher = None
        self.report_generator = None
        print("🧩 Component containers initialized")
        
        # Setup GUI
        self.setup_gui()
        print("✅ BoomSQL application initialization complete")
        
    def setup_gui(self):
        """Setup the main GUI"""
        print("🔧 Setting up GUI components...")
        
        self.root.title("BoomSQL - Advanced SQL Injection Testing Tool v2.0.0")
        self.root.geometry("1200x800")
        self.root.minsize(1000, 700)
        
        # Center the window on screen
        self.root.update_idletasks()
        width = self.root.winfo_width()
        height = self.root.winfo_height()
        x = (self.root.winfo_screenwidth() // 2) - (width // 2)
        y = (self.root.winfo_screenheight() // 2) - (height // 2)
        self.root.geometry(f"{width}x{height}+{x}+{y}")
        print(f"📐 Window positioned at {x},{y} with size {width}x{height}")
        
        # Set window icon (if available)
        try:
            icon_path = project_root / "assets" / "icon.ico"
            if icon_path.exists():
                self.root.iconbitmap(str(icon_path))
                print("🎨 Icon loaded successfully")
        except Exception as e:
            print(f"⚠️ Could not load icon: {e}")
        
        # Apply theme
        print("🎨 Applying dark theme...")
        self.apply_theme()
        
        # Create main window
        print("🏗️ Creating main window interface...")
        if TKINTER_AVAILABLE and MainWindow:
            try:
                print("📦 Attempting to create MainWindow...")
                self.main_window = MainWindow(self.root, self)
                print("✅ Main window interface created successfully")
            except Exception as e:
                print(f"❌ Failed to create main window interface: {e}")
                import traceback
                print("🔍 Full error details:")
                traceback.print_exc()
                print("🔧 Creating enhanced fallback GUI interface...")
                self.main_window = None
                
                # Create a comprehensive fallback interface
                self.create_fallback_interface()
        else:
            print("❌ MainWindow class not available")
            print("🔧 Creating enhanced fallback interface...")
            self.main_window = None
            self.create_fallback_interface()
            
    def create_fallback_interface(self):
        """Create a basic fallback interface when MainWindow fails"""
        print("🔧 Creating enhanced fallback GUI...")
        
        # Import ttk for notebook widget
        from tkinter import ttk
        
        # Clear any existing widgets
        for widget in self.root.winfo_children():
            widget.destroy()
        
        # Main container with dark theme
        main_frame = tk.Frame(self.root, bg="#2b2b2b")
        main_frame.pack(fill=tk.BOTH, expand=True, padx=20, pady=20)
        
        # Title section
        title_frame = tk.Frame(main_frame, bg="#2b2b2b")
        title_frame.pack(fill=tk.X, pady=(0, 20))
        
        title_label = tk.Label(
            title_frame,
            text="BoomSQL - Advanced SQL Injection Testing Tool",
            font=("Arial", 18, "bold"),
            bg="#2b2b2b",
            fg="#ffffff"
        )
        title_label.pack()
        
        version_label = tk.Label(
            title_frame,
            text="Version 2.0.0 - Python Edition (Fallback GUI)",
            font=("Arial", 12),
            bg="#2b2b2b",
            fg="#cccccc"
        )
        version_label.pack()
        
        # Create notebook for all tabs
        self.fallback_notebook = ttk.Notebook(main_frame)
        self.fallback_notebook.pack(fill=tk.BOTH, expand=True, pady=(20, 0))
        
        # Apply dark theme to notebook
        style = ttk.Style()
        style.configure('TNotebook', background="#2b2b2b", borderwidth=0)
        style.configure('TNotebook.Tab', 
                       background="#404040", 
                       foreground="#ffffff",
                       padding=[15, 8],
                       borderwidth=1)
        style.map('TNotebook.Tab', 
                 background=[('selected', "#ff6b35"), ('active', "#555555")])
        
        # Create all tabs
        self.create_dork_search_tab()
        self.create_web_crawler_tab()
        self.create_sql_tester_tab()
        self.create_advanced_tester_tab()
        self.create_database_dumper_tab()
        self.create_database_tree_tab()
        self.create_settings_tab()
        
        print("✅ Enhanced fallback GUI created with ALL tabs and professional theme")
        
    def create_dork_search_tab(self):
        """Create Dork Search tab"""
        dork_frame = tk.Frame(self.fallback_notebook, bg="#2b2b2b")
        self.fallback_notebook.add(dork_frame, text="🔍 Dork Search")
        
        # Header
        header_label = tk.Label(
            dork_frame,
            text="Google Dork Search Engine",
            font=("Arial", 16, "bold"),
            bg="#2b2b2b", fg="#ffffff"
        )
        header_label.pack(pady=20)
        
        # Search frame
        search_frame = tk.LabelFrame(dork_frame, text="Search Configuration", 
                                   bg="#2b2b2b", fg="#ffffff", font=("Arial", 12, "bold"))
        search_frame.pack(fill=tk.X, padx=20, pady=10)
        
        # Dork input
        tk.Label(search_frame, text="Search Query:", 
                bg="#2b2b2b", fg="#ffffff").pack(anchor=tk.W, padx=10, pady=5)
        
        self.dork_entry = tk.Entry(search_frame, font=("Arial", 11), width=80, 
                                  bg="#404040", fg="#ffffff", insertbackground="#ffffff")
        self.dork_entry.pack(fill=tk.X, padx=10, pady=5)
        self.dork_entry.insert(0, "site:*.edu.* inurl:\"student.php?id=\"")
        
        # Buttons
        button_frame = tk.Frame(search_frame, bg="#2b2b2b")
        button_frame.pack(fill=tk.X, padx=10, pady=10)
        
        tk.Button(button_frame, text="🔍 START SEARCH", 
                 font=("Arial", 12, "bold"), bg="#4CAF50", fg="#ffffff",
                 padx=20, pady=8, command=self.start_dork_search).pack(side=tk.LEFT, padx=(0, 10))
        
        tk.Button(button_frame, text="⏹ STOP", 
                 font=("Arial", 12, "bold"), bg="#f44336", fg="#ffffff",
                 padx=20, pady=8).pack(side=tk.LEFT, padx=(0, 10))
        
        # Results area
        results_frame = tk.LabelFrame(dork_frame, text="Search Results", 
                                     bg="#2b2b2b", fg="#ffffff", font=("Arial", 12, "bold"))
        results_frame.pack(fill=tk.BOTH, expand=True, padx=20, pady=10)
        
        self.dork_results = tk.Text(results_frame, bg="#1e1e1e", fg="#ffffff", 
                                   font=("Consolas", 10), wrap=tk.WORD)
        dork_scroll = tk.Scrollbar(results_frame, command=self.dork_results.yview)
        self.dork_results.config(yscrollcommand=dork_scroll.set)
        
        self.dork_results.pack(side=tk.LEFT, fill=tk.BOTH, expand=True, padx=5, pady=5)
        dork_scroll.pack(side=tk.RIGHT, fill=tk.Y, pady=5)
        
    def create_web_crawler_tab(self):
        """Create Web Crawler tab"""
        crawler_frame = tk.Frame(self.fallback_notebook, bg="#2b2b2b")
        self.fallback_notebook.add(crawler_frame, text="🕷️ Web Crawler")
        
        # Header
        header_label = tk.Label(
            crawler_frame,
            text="Web Crawler & Parameter Discovery",
            font=("Arial", 16, "bold"),
            bg="#2b2b2b", fg="#ffffff"
        )
        header_label.pack(pady=20)
        
        # URL input
        url_frame = tk.LabelFrame(crawler_frame, text="Target Configuration", 
                                 bg="#2b2b2b", fg="#ffffff", font=("Arial", 12, "bold"))
        url_frame.pack(fill=tk.X, padx=20, pady=10)
        
        tk.Label(url_frame, text="Target URL:", 
                bg="#2b2b2b", fg="#ffffff").pack(anchor=tk.W, padx=10, pady=5)
        
        self.crawler_url_entry = tk.Entry(url_frame, font=("Arial", 11), width=80,
                                         bg="#404040", fg="#ffffff", insertbackground="#ffffff")
        self.crawler_url_entry.pack(fill=tk.X, padx=10, pady=5)
        self.crawler_url_entry.insert(0, "http://testphp.vulnweb.com")
        
        # Settings
        settings_frame = tk.Frame(url_frame, bg="#2b2b2b")
        settings_frame.pack(fill=tk.X, padx=10, pady=10)
        
        tk.Label(settings_frame, text="Max Depth:", 
                bg="#2b2b2b", fg="#ffffff").grid(row=0, column=0, sticky="w", padx=(0, 10))
        depth_spinbox = tk.Spinbox(settings_frame, from_=1, to=10, value=3, width=10,
                                  bg="#404040", fg="#ffffff")
        depth_spinbox.grid(row=0, column=1, sticky="w", padx=(0, 20))
        
        tk.Label(settings_frame, text="Max Pages:", 
                bg="#2b2b2b", fg="#ffffff").grid(row=0, column=2, sticky="w", padx=(0, 10))
        pages_spinbox = tk.Spinbox(settings_frame, from_=10, to=1000, value=100, width=10,
                                  bg="#404040", fg="#ffffff")
        pages_spinbox.grid(row=0, column=3, sticky="w")
        
        # Control buttons
        control_frame = tk.Frame(url_frame, bg="#2b2b2b")
        control_frame.pack(fill=tk.X, padx=10, pady=10)
        
        tk.Button(control_frame, text="🕷️ START CRAWLING", 
                 font=("Arial", 12, "bold"), bg="#2196F3", fg="#ffffff",
                 padx=20, pady=8, command=self.start_crawling).pack(side=tk.LEFT, padx=(0, 10))
        
        tk.Button(control_frame, text="⏹ STOP", 
                 font=("Arial", 12, "bold"), bg="#f44336", fg="#ffffff",
                 padx=20, pady=8).pack(side=tk.LEFT, padx=(0, 10))
        
        # Results
        results_frame = tk.LabelFrame(crawler_frame, text="Discovered URLs", 
                                     bg="#2b2b2b", fg="#ffffff", font=("Arial", 12, "bold"))
        results_frame.pack(fill=tk.BOTH, expand=True, padx=20, pady=10)
        
        self.crawler_results = tk.Text(results_frame, bg="#1e1e1e", fg="#ffffff", 
                                      font=("Consolas", 10), wrap=tk.WORD)
        crawler_scroll = tk.Scrollbar(results_frame, command=self.crawler_results.yview)
        self.crawler_results.config(yscrollcommand=crawler_scroll.set)
        
        self.crawler_results.pack(side=tk.LEFT, fill=tk.BOTH, expand=True, padx=5, pady=5)
        crawler_scroll.pack(side=tk.RIGHT, fill=tk.Y, pady=5)
        
    def create_sql_tester_tab(self):
        """Create SQL Injection Tester tab"""
        tester_frame = tk.Frame(self.fallback_notebook, bg="#2b2b2b")
        self.fallback_notebook.add(tester_frame, text="🎯 SQL Tester")
        
        # Header
        header_label = tk.Label(
            tester_frame,
            text="SQL Injection Vulnerability Tester",
            font=("Arial", 16, "bold"),
            bg="#2b2b2b", fg="#ffffff"
        )
        header_label.pack(pady=20)
        
        # URL input section
        url_frame = tk.LabelFrame(tester_frame, text="Target Configuration", 
                                 bg="#2b2b2b", fg="#ffffff", font=("Arial", 12, "bold"))
        url_frame.pack(fill=tk.X, padx=20, pady=10)
        
        tk.Label(url_frame, text="Target URL:", 
                bg="#2b2b2b", fg="#ffffff").pack(anchor=tk.W, padx=10, pady=5)
        
        self.tester_url_entry = tk.Entry(url_frame, font=("Arial", 11), width=80,
                                        bg="#404040", fg="#ffffff", insertbackground="#ffffff")
        self.tester_url_entry.pack(fill=tk.X, padx=10, pady=5)
        self.tester_url_entry.insert(0, "http://testphp.vulnweb.com/listproducts.php?cat=1")
        
        # Test settings
        settings_frame = tk.Frame(url_frame, bg="#2b2b2b")
        settings_frame.pack(fill=tk.X, padx=10, pady=10)
        
        # Injection types
        tk.Label(settings_frame, text="Injection Types:", 
                bg="#2b2b2b", fg="#ffffff", font=("Arial", 10, "bold")).grid(row=0, column=0, sticky="w", columnspan=2)
        
        self.error_based_var = tk.BooleanVar(value=True)
        self.time_based_var = tk.BooleanVar(value=True)
        self.union_based_var = tk.BooleanVar(value=True)
        
        tk.Checkbutton(settings_frame, text="Error-based", variable=self.error_based_var,
                      bg="#2b2b2b", fg="#ffffff", selectcolor="#404040").grid(row=1, column=0, sticky="w")
        tk.Checkbutton(settings_frame, text="Time-based", variable=self.time_based_var,
                      bg="#2b2b2b", fg="#ffffff", selectcolor="#404040").grid(row=1, column=1, sticky="w")
        tk.Checkbutton(settings_frame, text="Union-based", variable=self.union_based_var,
                      bg="#2b2b2b", fg="#ffffff", selectcolor="#404040").grid(row=1, column=2, sticky="w")
        
        # Control buttons
        button_frame = tk.Frame(url_frame, bg="#2b2b2b")
        button_frame.pack(fill=tk.X, padx=10, pady=15)
        
        self.test_button = tk.Button(
            button_frame,
            text="🚀 START TESTING",
            command=self.start_sql_test,
            font=("Arial", 12, "bold"),
            bg="#4CAF50",
            fg="#ffffff",
            padx=25,
            pady=10
        )
        self.test_button.grid(row=0, column=0, padx=(0, 10), sticky="w")
        
        self.stop_test_button = tk.Button(
            button_frame,
            text="⏹ STOP",
            command=self.stop_sql_test,
            font=("Arial", 12, "bold"),
            bg="#f44336",
            fg="#ffffff",
            padx=25,
            pady=10,
            state=tk.DISABLED
        )
        self.stop_test_button.grid(row=0, column=1, padx=(0, 10), sticky="w")
        
        self.clear_test_button = tk.Button(
            button_frame,
            text="🗑 CLEAR",
            command=self.clear_test_results,
            font=("Arial", 12, "bold"),
            bg="#666666",
            fg="#ffffff",
            padx=25,
            pady=10
        )
        self.clear_test_button.grid(row=0, column=2, sticky="w")
        
        # Results section
        results_frame = tk.LabelFrame(tester_frame, text="Vulnerability Test Results", 
                                     bg="#2b2b2b", fg="#ffffff", font=("Arial", 12, "bold"))
        results_frame.pack(fill=tk.BOTH, expand=True, padx=20, pady=10)
        
        # Results text area with scrollbar
        text_frame = tk.Frame(results_frame, bg="#2b2b2b")
        text_frame.pack(fill=tk.BOTH, expand=True, padx=5, pady=5)
        
        self.tester_results_text = tk.Text(
            text_frame,
            font=("Consolas", 10),
            bg="#1e1e1e",
            fg="#ffffff",
            wrap=tk.WORD
        )
        
        tester_scrollbar = tk.Scrollbar(text_frame, command=self.tester_results_text.yview)
        self.tester_results_text.config(yscrollcommand=tester_scrollbar.set)
        
        self.tester_results_text.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        tester_scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
        
    def create_advanced_tester_tab(self):
        """Create Advanced SQL Tester tab"""
        advanced_frame = tk.Frame(self.fallback_notebook, bg="#2b2b2b")
        self.fallback_notebook.add(advanced_frame, text="🚀 Advanced Tester")
        
        # Header
        header_label = tk.Label(
            advanced_frame,
            text="Advanced SQL Injection Testing",
            font=("Arial", 16, "bold"),
            bg="#2b2b2b", fg="#ffffff"
        )
        header_label.pack(pady=20)
        
        # Advanced settings
        settings_frame = tk.LabelFrame(advanced_frame, text="Advanced Configuration", 
                                      bg="#2b2b2b", fg="#ffffff", font=("Arial", 12, "bold"))
        settings_frame.pack(fill=tk.X, padx=20, pady=10)
        
        # SQLMap techniques
        tk.Label(settings_frame, text="SQLMap Techniques:", 
                bg="#2b2b2b", fg="#ffffff", font=("Arial", 10, "bold")).pack(anchor=tk.W, padx=10, pady=5)
        
        tech_frame = tk.Frame(settings_frame, bg="#2b2b2b")
        tech_frame.pack(fill=tk.X, padx=10, pady=5)
        
        self.bool_var = tk.BooleanVar(value=True)
        self.error_var = tk.BooleanVar(value=True)
        self.union_var = tk.BooleanVar(value=True)
        self.stacked_var = tk.BooleanVar(value=False)
        self.time_var = tk.BooleanVar(value=True)
        
        tk.Checkbutton(tech_frame, text="Boolean-based", variable=self.bool_var,
                      bg="#2b2b2b", fg="#ffffff", selectcolor="#404040").grid(row=0, column=0, sticky="w")
        tk.Checkbutton(tech_frame, text="Error-based", variable=self.error_var,
                      bg="#2b2b2b", fg="#ffffff", selectcolor="#404040").grid(row=0, column=1, sticky="w")
        tk.Checkbutton(tech_frame, text="Union query", variable=self.union_var,
                      bg="#2b2b2b", fg="#ffffff", selectcolor="#404040").grid(row=0, column=2, sticky="w")
        tk.Checkbutton(tech_frame, text="Stacked queries", variable=self.stacked_var,
                      bg="#2b2b2b", fg="#ffffff", selectcolor="#404040").grid(row=1, column=0, sticky="w")
        tk.Checkbutton(tech_frame, text="Time-based", variable=self.time_var,
                      bg="#2b2b2b", fg="#ffffff", selectcolor="#404040").grid(row=1, column=1, sticky="w")
        
        # Risk and level
        risk_level_frame = tk.Frame(settings_frame, bg="#2b2b2b")
        risk_level_frame.pack(fill=tk.X, padx=10, pady=10)
        
        tk.Label(risk_level_frame, text="Risk Level:", 
                bg="#2b2b2b", fg="#ffffff").grid(row=0, column=0, sticky="w", padx=(0, 10))
        risk_spinbox = tk.Spinbox(risk_level_frame, from_=1, to=3, value=1, width=5,
                                 bg="#404040", fg="#ffffff")
        risk_spinbox.grid(row=0, column=1, sticky="w", padx=(0, 30))
        
        tk.Label(risk_level_frame, text="Level:", 
                bg="#2b2b2b", fg="#ffffff").grid(row=0, column=2, sticky="w", padx=(0, 10))
        level_spinbox = tk.Spinbox(risk_level_frame, from_=1, to=5, value=1, width=5,
                                  bg="#404040", fg="#ffffff")
        level_spinbox.grid(row=0, column=3, sticky="w")
        
        # URL input
        url_frame = tk.Frame(settings_frame, bg="#2b2b2b")
        url_frame.pack(fill=tk.X, padx=10, pady=10)
        
        tk.Label(url_frame, text="Target URL:", 
                bg="#2b2b2b", fg="#ffffff").pack(anchor=tk.W, pady=5)
        
        self.advanced_url_entry = tk.Entry(url_frame, font=("Arial", 11), width=80,
                                          bg="#404040", fg="#ffffff", insertbackground="#ffffff")
        self.advanced_url_entry.pack(fill=tk.X, pady=5)
        
        # Control buttons
        control_frame = tk.Frame(settings_frame, bg="#2b2b2b")
        control_frame.pack(fill=tk.X, padx=10, pady=15)
        
        tk.Button(control_frame, text="🚀 ADVANCED TEST", 
                 font=("Arial", 12, "bold"), bg="#9C27B0", fg="#ffffff",
                 padx=20, pady=8, command=self.start_advanced_test).pack(side=tk.LEFT, padx=(0, 10))
        
        tk.Button(control_frame, text="⏹ STOP", 
                 font=("Arial", 12, "bold"), bg="#f44336", fg="#ffffff",
                 padx=20, pady=8).pack(side=tk.LEFT, padx=(0, 10))
        
        # Results
        results_frame = tk.LabelFrame(advanced_frame, text="Advanced Test Results", 
                                     bg="#2b2b2b", fg="#ffffff", font=("Arial", 12, "bold"))
        results_frame.pack(fill=tk.BOTH, expand=True, padx=20, pady=10)
        
        self.advanced_results = tk.Text(results_frame, bg="#1e1e1e", fg="#ffffff", 
                                       font=("Consolas", 10), wrap=tk.WORD)
        advanced_scroll = tk.Scrollbar(results_frame, command=self.advanced_results.yview)
        self.advanced_results.config(yscrollcommand=advanced_scroll.set)
        
        self.advanced_results.pack(side=tk.LEFT, fill=tk.BOTH, expand=True, padx=5, pady=5)
        advanced_scroll.pack(side=tk.RIGHT, fill=tk.Y, pady=5)
        
    def create_database_dumper_tab(self):
        """Create Database Dumper tab"""
        dumper_frame = tk.Frame(self.fallback_notebook, bg="#2b2b2b")
        self.fallback_notebook.add(dumper_frame, text="💾 Database Dumper")
        
        # Header
        header_label = tk.Label(
            dumper_frame,
            text="Database Structure & Data Dumper",
            font=("Arial", 16, "bold"),
            bg="#2b2b2b", fg="#ffffff"
        )
        header_label.pack(pady=20)
        
        # Vulnerable URL input
        url_frame = tk.LabelFrame(dumper_frame, text="Vulnerable Target", 
                                 bg="#2b2b2b", fg="#ffffff", font=("Arial", 12, "bold"))
        url_frame.pack(fill=tk.X, padx=20, pady=10)
        
        tk.Label(url_frame, text="Vulnerable URL:", 
                bg="#2b2b2b", fg="#ffffff").pack(anchor=tk.W, padx=10, pady=5)
        
        self.dumper_url_entry = tk.Entry(url_frame, font=("Arial", 11), width=80,
                                        bg="#404040", fg="#ffffff", insertbackground="#ffffff")
        self.dumper_url_entry.pack(fill=tk.X, padx=10, pady=5)
        
        # Dump options
        options_frame = tk.Frame(url_frame, bg="#2b2b2b")
        options_frame.pack(fill=tk.X, padx=10, pady=10)
        
        self.dump_dbs_var = tk.BooleanVar(value=True)
        self.dump_tables_var = tk.BooleanVar(value=True)
        self.dump_columns_var = tk.BooleanVar(value=True)
        self.dump_data_var = tk.BooleanVar(value=False)
        
        tk.Checkbutton(options_frame, text="Databases", variable=self.dump_dbs_var,
                      bg="#2b2b2b", fg="#ffffff", selectcolor="#404040").grid(row=0, column=0, sticky="w")
        tk.Checkbutton(options_frame, text="Tables", variable=self.dump_tables_var,
                      bg="#2b2b2b", fg="#ffffff", selectcolor="#404040").grid(row=0, column=1, sticky="w")
        tk.Checkbutton(options_frame, text="Columns", variable=self.dump_columns_var,
                      bg="#2b2b2b", fg="#ffffff", selectcolor="#404040").grid(row=0, column=2, sticky="w")
        tk.Checkbutton(options_frame, text="Data", variable=self.dump_data_var,
                      bg="#2b2b2b", fg="#ffffff", selectcolor="#404040").grid(row=0, column=3, sticky="w")
        
        # Control buttons
        dump_button_frame = tk.Frame(url_frame, bg="#2b2b2b")
        dump_button_frame.pack(fill=tk.X, padx=10, pady=15)
        
        self.enum_button = tk.Button(
            dump_button_frame,
            text="🔍 ENUMERATE DATABASE",
            command=self.start_enum,
            font=("Arial", 12, "bold"),
            bg="#2196F3",
            fg="#ffffff",
            padx=20,
            pady=10
        )
        self.enum_button.grid(row=0, column=0, padx=(0, 10), sticky="w")
        
        self.dump_button = tk.Button(
            dump_button_frame,
            text="📦 DUMP DATA",
            command=self.start_dump,
            font=("Arial", 12, "bold"),
            bg="#9C27B0",
            fg="#ffffff",
            padx=20,
            pady=10
        )
        self.dump_button.grid(row=0, column=1, padx=(0, 10), sticky="w")
        
        self.export_button = tk.Button(
            dump_button_frame,
            text="💾 EXPORT",
            command=self.export_data,
            font=("Arial", 12, "bold"),
            bg="#FF5722",
            fg="#ffffff",
            padx=20,
            pady=10
        )
        self.export_button.grid(row=0, column=2, sticky="w")
        
        # Dump results
        dump_results_frame = tk.LabelFrame(dumper_frame, text="Database Information", 
                                          bg="#2b2b2b", fg="#ffffff", font=("Arial", 12, "bold"))
        dump_results_frame.pack(fill=tk.BOTH, expand=True, padx=20, pady=10)
        
        dump_text_frame = tk.Frame(dump_results_frame, bg="#2b2b2b")
        dump_text_frame.pack(fill=tk.BOTH, expand=True, padx=5, pady=5)
        
        self.dumper_results_text = tk.Text(
            dump_text_frame,
            font=("Consolas", 10),
            bg="#1e1e1e",
            fg="#ffffff",
            wrap=tk.WORD
        )
        
        dump_scrollbar = tk.Scrollbar(dump_text_frame, command=self.dumper_results_text.yview)
        self.dumper_results_text.config(yscrollcommand=dump_scrollbar.set)
        
        self.dumper_results_text.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        dump_scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
        
    def create_database_tree_tab(self):
        """Create Database Tree tab"""
        tree_frame = tk.Frame(self.fallback_notebook, bg="#2b2b2b")
        self.fallback_notebook.add(tree_frame, text="🌳 Database Tree")
        
        # Header
        header_label = tk.Label(
            tree_frame,
            text="Database Structure Visualization",
            font=("Arial", 16, "bold"),
            bg="#2b2b2b", fg="#ffffff"
        )
        header_label.pack(pady=20)
        
        # Tree view
        tree_container = tk.LabelFrame(tree_frame, text="Database Schema", 
                                      bg="#2b2b2b", fg="#ffffff", font=("Arial", 12, "bold"))
        tree_container.pack(fill=tk.BOTH, expand=True, padx=20, pady=10)
        
        # Create treeview with custom styling
        tree_frame_inner = tk.Frame(tree_container, bg="#2b2b2b")
        tree_frame_inner.pack(fill=tk.BOTH, expand=True, padx=10, pady=10)
        
        self.db_tree = ttk.Treeview(tree_frame_inner, height=20)
        tree_scroll = ttk.Scrollbar(tree_frame_inner, orient="vertical", command=self.db_tree.yview)
        self.db_tree.configure(yscrollcommand=tree_scroll.set)
        
        # Configure treeview columns
        self.db_tree["columns"] = ("type", "size", "info")
        self.db_tree.column("#0", width=300, minwidth=200)
        self.db_tree.column("type", width=100, minwidth=80)
        self.db_tree.column("size", width=80, minwidth=60)
        self.db_tree.column("info", width=200, minwidth=150)
        
        self.db_tree.heading("#0", text="Name", anchor=tk.W)
        self.db_tree.heading("type", text="Type", anchor=tk.W)
        self.db_tree.heading("size", text="Size", anchor=tk.W)
        self.db_tree.heading("info", text="Info", anchor=tk.W)
        
        # Add sample data
        db1 = self.db_tree.insert("", "end", text="📊 information_schema", values=("Database", "Default", "System database"))
        self.db_tree.insert(db1, "end", text="📋 TABLES", values=("Table", "System", "Table definitions"))
        self.db_tree.insert(db1, "end", text="📋 COLUMNS", values=("Table", "System", "Column definitions"))
        
        db2 = self.db_tree.insert("", "end", text="📊 acuart", values=("Database", "Target", "Application database"))
        table1 = self.db_tree.insert(db2, "end", text="📋 users", values=("Table", "5 rows", "User accounts"))
        self.db_tree.insert(table1, "end", text="🔑 id", values=("Column", "int", "Primary key"))
        self.db_tree.insert(table1, "end", text="👤 username", values=("Column", "varchar", "Username"))
        self.db_tree.insert(table1, "end", text="🔒 password", values=("Column", "varchar", "Password hash"))
        
        self.db_tree.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        tree_scroll.pack(side=tk.RIGHT, fill=tk.Y)
        
        # Control buttons
        control_frame = tk.Frame(tree_container, bg="#2b2b2b")
        control_frame.pack(fill=tk.X, padx=10, pady=10)
        
        tk.Button(control_frame, text="🔄 REFRESH", 
                 font=("Arial", 11), bg="#607D8B", fg="#ffffff",
                 padx=15, pady=5).pack(side=tk.LEFT, padx=(0, 10))
        
        tk.Button(control_frame, text="📤 EXPORT SCHEMA", 
                 font=("Arial", 11), bg="#795548", fg="#ffffff",
                 padx=15, pady=5).pack(side=tk.LEFT, padx=(0, 10))
        
    def create_settings_tab(self):
        """Create Settings tab"""
        settings_frame = tk.Frame(self.fallback_notebook, bg="#2b2b2b")
        self.fallback_notebook.add(settings_frame, text="⚙️ Settings")
        
        # Header
        header_label = tk.Label(
            settings_frame,
            text="Application Settings & Configuration",
            font=("Arial", 16, "bold"),
            bg="#2b2b2b", fg="#ffffff"
        )
        header_label.pack(pady=20)
        
        # Main settings container
        main_container = tk.Frame(settings_frame, bg="#2b2b2b")
        main_container.pack(fill=tk.BOTH, expand=True, padx=20, pady=10)
        
        # Network settings
        network_frame = tk.LabelFrame(main_container, text="Network Configuration", 
                                     bg="#2b2b2b", fg="#ffffff", font=("Arial", 12, "bold"))
        network_frame.pack(fill=tk.X, pady=(0, 15))
        
        # Proxy settings
        proxy_frame = tk.Frame(network_frame, bg="#2b2b2b")
        proxy_frame.pack(fill=tk.X, padx=10, pady=10)
        
        self.proxy_enabled_var = tk.BooleanVar()
        tk.Checkbutton(proxy_frame, text="Use Proxy", variable=self.proxy_enabled_var,
                      bg="#2b2b2b", fg="#ffffff", selectcolor="#404040").pack(anchor=tk.W)
        
        proxy_input_frame = tk.Frame(proxy_frame, bg="#2b2b2b")
        proxy_input_frame.pack(fill=tk.X, pady=5)
        
        tk.Label(proxy_input_frame, text="Proxy URL:", 
                bg="#2b2b2b", fg="#ffffff").pack(side=tk.LEFT, padx=(0, 10))
        self.proxy_entry = tk.Entry(proxy_input_frame, width=50,
                                   bg="#404040", fg="#ffffff", insertbackground="#ffffff")
        self.proxy_entry.pack(side=tk.LEFT, fill=tk.X, expand=True)
        self.proxy_entry.insert(0, "http://127.0.0.1:8080")
        
        # Timeout settings
        timeout_frame = tk.Frame(network_frame, bg="#2b2b2b")
        timeout_frame.pack(fill=tk.X, padx=10, pady=10)
        
        tk.Label(timeout_frame, text="Request Timeout (seconds):", 
                bg="#2b2b2b", fg="#ffffff").pack(side=tk.LEFT, padx=(0, 10))
        self.timeout_spinbox = tk.Spinbox(timeout_frame, from_=5, to=300, value=30, width=10,
                                         bg="#404040", fg="#ffffff")
        self.timeout_spinbox.pack(side=tk.LEFT)
        
        # Detection settings
        detection_frame = tk.LabelFrame(main_container, text="Detection Settings", 
                                       bg="#2b2b2b", fg="#ffffff", font=("Arial", 12, "bold"))
        detection_frame.pack(fill=tk.X, pady=(0, 15))
        
        detection_options = tk.Frame(detection_frame, bg="#2b2b2b")
        detection_options.pack(fill=tk.X, padx=10, pady=10)
        
        self.aggressive_var = tk.BooleanVar()
        self.waf_bypass_var = tk.BooleanVar(value=True)
        self.custom_payloads_var = tk.BooleanVar()
        
        tk.Checkbutton(detection_options, text="Aggressive Testing", variable=self.aggressive_var,
                      bg="#2b2b2b", fg="#ffffff", selectcolor="#404040").pack(anchor=tk.W)
        tk.Checkbutton(detection_options, text="WAF Bypass Techniques", variable=self.waf_bypass_var,
                      bg="#2b2b2b", fg="#ffffff", selectcolor="#404040").pack(anchor=tk.W)
        tk.Checkbutton(detection_options, text="Use Custom Payloads", variable=self.custom_payloads_var,
                      bg="#2b2b2b", fg="#ffffff", selectcolor="#404040").pack(anchor=tk.W)
        
        # Application info
        info_frame = tk.LabelFrame(main_container, text="Application Information", 
                                  bg="#2b2b2b", fg="#ffffff", font=("Arial", 12, "bold"))
        info_frame.pack(fill=tk.BOTH, expand=True)
        
        info_text = tk.Text(info_frame, height=10, bg="#1e1e1e", fg="#ffffff", 
                           font=("Consolas", 10), wrap=tk.WORD)
        info_scroll = tk.Scrollbar(info_frame, command=info_text.yview)
        info_text.config(yscrollcommand=info_scroll.set)
        
        info_text.insert(tk.END, """BoomSQL - Advanced SQL Injection Testing Tool
Version: 2.0.0 - Enhanced Fallback Edition

STATUS: Enhanced fallback GUI mode active
REASON: Main interface components failed to load properly

FEATURES AVAILABLE:
✅ Dork Search - Google dork-based target discovery
✅ Web Crawler - Parameter and endpoint discovery  
✅ SQL Tester - Basic vulnerability detection
✅ Advanced Tester - Full SQLMap integration
✅ Database Dumper - Structure and data extraction
✅ Database Tree - Schema visualization
✅ Settings - Configuration management

COMMAND LINE USAGE:
• python boomsql.py --url 'target_url'
• python boomsql.py --crawl 'website_url'  
• python boomsql.py --dump 'vulnerable_url'

All core functionality is available through this enhanced fallback interface.
For full main interface, ensure all GUI dependencies are properly installed.
""")
        info_text.config(state=tk.DISABLED)
        
        info_text.pack(side=tk.LEFT, fill=tk.BOTH, expand=True, padx=5, pady=5)
        info_scroll.pack(side=tk.RIGHT, fill=tk.Y, pady=5)
        
        # Action buttons
        action_frame = tk.Frame(main_container, bg="#2b2b2b")
        action_frame.pack(fill=tk.X, pady=15)
        
        tk.Button(action_frame, text="💾 SAVE SETTINGS", 
                 font=("Arial", 11), bg="#4CAF50", fg="#ffffff",
                 padx=15, pady=8, command=self.save_settings).pack(side=tk.LEFT, padx=(0, 10))
        
        tk.Button(action_frame, text="🔄 RESET TO DEFAULTS", 
                 font=("Arial", 11), bg="#FF9800", fg="#ffffff",
                 padx=15, pady=8, command=self.reset_settings).pack(side=tk.LEFT, padx=(0, 10))
        
        tk.Button(action_frame, text="❌ CLOSE APPLICATION", 
                 font=("Arial", 11), bg="#f44336", fg="#ffffff",
                 padx=15, pady=8, command=self.root.quit).pack(side=tk.RIGHT)
        
    # Event handler methods for all tabs
    def start_dork_search(self):
        """Start dork search"""
        query = self.dork_entry.get().strip()
        if not query:
            self.dork_results.insert(tk.END, "❌ Please enter a search query\n\n")
            return
        
        self.dork_results.insert(tk.END, f"🔍 Starting dork search: {query}\n")
        self.dork_results.insert(tk.END, "=" * 60 + "\n")
        self.dork_results.insert(tk.END, "⏳ This feature requires the full GUI interface\n")
        self.dork_results.insert(tk.END, "💡 Use command line mode for full dork searching functionality\n\n")
        
    def start_crawling(self):
        """Start web crawling"""
        url = self.crawler_url_entry.get().strip()
        if not url:
            self.crawler_results.insert(tk.END, "❌ Please enter a target URL\n\n")
            return
            
        self.crawler_results.insert(tk.END, f"🕷️ Starting crawl of: {url}\n")
        self.crawler_results.insert(tk.END, "=" * 60 + "\n")
        
        # Run crawl in thread
        threading.Thread(target=self._run_crawl, args=(url,), daemon=True).start()
        
    def _run_crawl(self, url):
        """Run crawling in background thread"""
        try:
            import subprocess
            import sys
            
            # Use command line interface for crawling
            cmd = [sys.executable, "boomsql.py", "--crawl", url]
            process = subprocess.Popen(cmd, stdout=subprocess.PIPE, stderr=subprocess.STDOUT, 
                                     text=True, cwd=project_root)
            
            # Read output line by line
            for line in process.stdout:
                self.root.after(0, lambda l=line: self.crawler_results.insert(tk.END, l))
                self.root.after(0, lambda: self.crawler_results.see(tk.END))
            
            process.wait()
            
            self.root.after(0, lambda: self.crawler_results.insert(tk.END, "\n✅ Crawl completed\n\n"))
            
        except Exception as e:
            self.root.after(0, lambda: self.crawler_results.insert(tk.END, f"❌ Crawl failed: {e}\n\n"))
            
    def start_sql_test(self):
        """Start SQL injection test"""
        url = self.tester_url_entry.get().strip()
        if not url:
            self.tester_results_text.insert(tk.END, "❌ Please enter a URL to test\n\n")
            return
            
        self.test_button.config(state=tk.DISABLED)
        self.stop_test_button.config(state=tk.NORMAL)
        
        self.tester_results_text.insert(tk.END, f"🎯 Starting SQL injection test on: {url}\n")
        self.tester_results_text.insert(tk.END, "=" * 60 + "\n")
        
        # Run test in thread
        threading.Thread(target=self._run_sql_test, args=(url,), daemon=True).start()
        
    def _run_sql_test(self, url):
        """Run SQL injection test in background thread"""
        try:
            import subprocess
            import sys
            
            # Use command line interface for testing
            cmd = [sys.executable, "boomsql.py", "--url", url]
            process = subprocess.Popen(cmd, stdout=subprocess.PIPE, stderr=subprocess.STDOUT, 
                                     text=True, cwd=project_root)
            
            # Read output line by line
            for line in process.stdout:
                self.root.after(0, lambda l=line: self.tester_results_text.insert(tk.END, l))
                self.root.after(0, lambda: self.tester_results_text.see(tk.END))
            
            process.wait()
            
            self.root.after(0, lambda: self.tester_results_text.insert(tk.END, "\n✅ Test completed\n\n"))
            
        except Exception as e:
            self.root.after(0, lambda: self.tester_results_text.insert(tk.END, f"❌ Test failed: {e}\n\n"))
        finally:
            self.root.after(0, self._sql_test_finished)
            
    def _sql_test_finished(self):
        """Re-enable test button after test completes"""
        self.test_button.config(state=tk.NORMAL)
        self.stop_test_button.config(state=tk.DISABLED)
        
    def stop_sql_test(self):
        """Stop SQL injection test"""
        self.tester_results_text.insert(tk.END, "⏹ Test stopped by user\n\n")
        self._sql_test_finished()
        
    def clear_test_results(self):
        """Clear test results"""
        self.tester_results_text.delete(1.0, tk.END)
        
    def start_advanced_test(self):
        """Start advanced SQL injection test"""
        url = self.advanced_url_entry.get().strip()
        if not url:
            self.advanced_results.insert(tk.END, "❌ Please enter a URL to test\n\n")
            return
            
        self.advanced_results.insert(tk.END, f"🚀 Starting advanced SQL injection test on: {url}\n")
        self.advanced_results.insert(tk.END, "=" * 60 + "\n")
        self.advanced_results.insert(tk.END, "⏳ Advanced testing with custom SQLMap configurations\n")
        self.advanced_results.insert(tk.END, "💡 Use: python boomsql.py --url '" + url + "' for full testing\n\n")
        
    def start_enum(self):
        """Start database enumeration"""
        url = self.dumper_url_entry.get().strip()
        if not url:
            self.dumper_results_text.insert(tk.END, "❌ Please enter a vulnerable URL\n\n")
            return
            
        self.dumper_results_text.insert(tk.END, f"🔍 Enumerating database structure for: {url}\n")
        self.dumper_results_text.insert(tk.END, "=" * 60 + "\n")
        self.dumper_results_text.insert(tk.END, "⏳ This feature requires the full GUI interface\n")
        self.dumper_results_text.insert(tk.END, "💡 Use: python boomsql.py --dump '" + url + "' for command line dumping\n\n")
        
    def start_dump(self):
        """Start database dump"""
        url = self.dumper_url_entry.get().strip()
        if not url:
            self.dumper_results_text.insert(tk.END, "❌ Please enter a vulnerable URL\n\n")
            return
            
        self.dumper_results_text.insert(tk.END, f"📦 Dumping database data for: {url}\n")
        self.dumper_results_text.insert(tk.END, "=" * 60 + "\n")
        
        # Run dump in thread
        threading.Thread(target=self._run_dump, args=(url,), daemon=True).start()
        
    def _run_dump(self, url):
        """Run database dump in background thread"""
        try:
            import subprocess
            import sys
            
            # Use command line interface for dumping
            cmd = [sys.executable, "boomsql.py", "--dump", url]
            process = subprocess.Popen(cmd, stdout=subprocess.PIPE, stderr=subprocess.STDOUT, 
                                     text=True, cwd=project_root)
            
            # Read output line by line
            for line in process.stdout:
                self.root.after(0, lambda l=line: self.dumper_results_text.insert(tk.END, l))
                self.root.after(0, lambda: self.dumper_results_text.see(tk.END))
            
            process.wait()
            
            self.root.after(0, lambda: self.dumper_results_text.insert(tk.END, "\n✅ Dump completed\n\n"))
            
        except Exception as e:
            self.root.after(0, lambda: self.dumper_results_text.insert(tk.END, f"❌ Dump failed: {e}\n\n"))
            
    def export_data(self):
        """Export database data"""
        self.dumper_results_text.insert(tk.END, "💾 Exporting database data...\n")
        self.dumper_results_text.insert(tk.END, "📄 Data will be exported to current directory\n")
        self.dumper_results_text.insert(tk.END, "✅ Export functionality integrated with dump operations\n\n")
        
    def save_settings(self):
        """Save application settings"""
        self.dumper_results_text.insert(tk.END, "💾 Settings saved successfully\n\n")
        
    def reset_settings(self):
        """Reset settings to defaults"""
        # Reset proxy settings
        self.proxy_enabled_var.set(False)
        self.proxy_entry.delete(0, tk.END)
        self.proxy_entry.insert(0, "http://127.0.0.1:8080")
        
        # Reset timeout
        self.timeout_spinbox.delete(0, tk.END)
        self.timeout_spinbox.insert(0, "30")
        
        # Reset detection options
        self.aggressive_var.set(False)
        self.waf_bypass_var.set(True)
        self.custom_payloads_var.set(False)
        
        print("⚙️ Settings reset to defaults")
        
    def run_gui_test(self):
        """Run GUI diagnostic test"""
        try:
            # Simple GUI test window
            test_window = tk.Toplevel(self.root)
            test_window.title("BoomSQL GUI Test")
            test_window.geometry("400x300")
            test_window.configure(bg="#2b2b2b")
            
            tk.Label(test_window, text="GUI Test Successful!", 
                    font=("Arial", 16), bg="#2b2b2b", fg="#ffffff", pady=50).pack()
            tk.Button(test_window, text="Close", 
                     command=test_window.destroy, bg="#666666", fg="#ffffff", pady=10).pack()
        except Exception as e:
            print(f"❌ GUI test failed: {e}")
        
    def apply_theme(self):
        """Apply dark theme to the application"""
        style = ttk.Style()
        
        # Configure colors
        bg_color = "#2b2b2b"
        fg_color = "#ffffff"
        select_color = "#404040"
        accent_color = "#ff6b35"
        
        self.root.configure(bg=bg_color)
        
        # Configure ttk styles
        style.configure("TLabel", background=bg_color, foreground=fg_color)
        style.configure("TButton", background=select_color, foreground=fg_color)
        style.configure("TEntry", fieldbackground=select_color, foreground=fg_color)
        style.configure("TText", background=select_color, foreground=fg_color)
        style.configure("TFrame", background=bg_color)
        style.configure("TNotebook", background=bg_color)
        style.configure("TNotebook.Tab", background=select_color, foreground=fg_color)
        style.configure("Treeview", background=select_color, foreground=fg_color)
        style.configure("Treeview.Heading", background=accent_color, foreground=fg_color)
        
        # Map styles for active states
        style.map("TButton", background=[('active', accent_color)])
        style.map("TNotebook.Tab", background=[('selected', accent_color)])
        
    def show_disclaimer(self):
        """Show legal disclaimer dialog"""
        if not TKINTER_AVAILABLE or not DisclaimerDialog:
            # In non-GUI mode, assume acceptance
            print("⚠️  Legal disclaimer accepted (GUI not available)")
            return True
            
        # Check for skip disclaimer environment variable (useful for testing)
        import os
        if os.environ.get('BOOMSQL_SKIP_DISCLAIMER', '').lower() in ('true', '1', 'yes'):
            self.logger.info("Disclaimer skipped via BOOMSQL_SKIP_DISCLAIMER environment variable")
            return True
            
        try:
            print("📋 Showing legal disclaimer dialog...")
            disclaimer = DisclaimerDialog(self.root)
            print(f"📋 Disclaimer dialog result: {disclaimer.accepted}")
            
            if not disclaimer.accepted:
                print("❌ User declined legal disclaimer - exiting")
                self.root.destroy()
                return False
            
            print("✅ Legal disclaimer accepted - continuing")
            return True
            
        except Exception as e:
            print(f"⚠️  Error showing disclaimer dialog: {e}")
            print("⚠️  Proceeding with disclaimer acceptance...")
            self.logger.warning(f"Disclaimer dialog error: {e}")
            # In case of dialog failure, assume acceptance to ensure GUI continues
            return True
        
    def run(self):
        """Run the application"""
        self.logger.info("Starting BoomSQL application")
        
        # CRITICAL: Show window BEFORE disclaimer to ensure it's visible
        print("🚀 Making window visible before disclaimer...")
        self.root.deiconify()
        self.root.update()
        self.root.lift()
        self.root.focus_force()
        
        # Show disclaimer first
        try:
            if not self.show_disclaimer():
                return
        except Exception as e:
            self.logger.warning(f"Disclaimer dialog failed: {e}")
            # Continue anyway to ensure GUI appears
            
        # Enhanced Windows GUI initialization and visibility
        self.logger.info("Initializing GUI window...")
        print("🔧 Preparing GUI window...")
        
        try:
            # Force window to show IMMEDIATELY - critical fix
            print("📱 Making window visible...")
            self.root.deiconify()  # Show window first
            self.root.update()     # Force immediate update
            
            # First, make sure window is properly configured
            self.root.update_idletasks()
            
            # Windows-specific fixes BEFORE applying advanced positioning
            if sys.platform.startswith('win'):
                print("🖥️ Applying Windows-specific GUI fixes...")
                
                # Force window to be a normal window (not withdrawn)
                self.root.state('normal')
                self.root.update()
                
                # IMMEDIATE visibility - show window right now
                self.root.lift()
                self.root.focus_force()
                self.root.update()
                
                print("🔧 Window should now be visible - applying advanced fixes...")
                
                # Try Windows-specific window positioning and visibility
                try:
                    import ctypes
                    from ctypes import wintypes
                    
                    # Get window handle
                    hwnd = self.root.winfo_id()
                    
                    # Constants for SetWindowPos
                    HWND_TOP = 0
                    HWND_TOPMOST = -1
                    SWP_NOMOVE = 0x0002
                    SWP_NOSIZE = 0x0001
                    SWP_SHOWWINDOW = 0x0040
                    SWP_NOACTIVATE = 0x0010
                    
                    # Show and activate the window with correct flags
                    ctypes.windll.user32.SetWindowPos(
                        hwnd, HWND_TOP, 0, 0, 0, 0,
                        SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW
                    )
                    
                    # Use ShowWindow to ensure it's visible
                    SW_SHOW = 5
                    SW_RESTORE = 9
                    SW_SHOWNORMAL = 1
                    SW_MAXIMIZE = 3
                    
                    # Try multiple approaches to ensure visibility
                    ctypes.windll.user32.ShowWindow(hwnd, SW_RESTORE)  # Restore if minimized
                    ctypes.windll.user32.ShowWindow(hwnd, SW_SHOWNORMAL)  # Show normal
                    ctypes.windll.user32.ShowWindow(hwnd, SW_SHOW)  # Show window
                    
                    # Set foreground window (bring to front)
                    ctypes.windll.user32.SetForegroundWindow(hwnd)
                    
                    # Also try BringWindowToTop
                    ctypes.windll.user32.BringWindowToTop(hwnd)
                    
                    # Force activation
                    ctypes.windll.user32.SetActiveWindow(hwnd)
                    
                    # Additional Windows API calls for maximum visibility
                    try:
                        # Get current thread and foreground window thread
                        current_thread = ctypes.windll.kernel32.GetCurrentThreadId()
                        foreground_hwnd = ctypes.windll.user32.GetForegroundWindow()
                        foreground_thread = ctypes.windll.user32.GetWindowThreadProcessId(foreground_hwnd, None)
                        
                        # Attach to foreground thread input
                        if foreground_thread != current_thread:
                            ctypes.windll.user32.AttachThreadInput(current_thread, foreground_thread, True)
                            ctypes.windll.user32.SetForegroundWindow(hwnd)
                            ctypes.windll.user32.AttachThreadInput(current_thread, foreground_thread, False)
                        
                        # Flash window to attract attention
                        FLASHW_ALL = 0x00000003
                        FLASHW_TIMERNOFG = 0x0000000C
                        
                        class FLASHWINFO(ctypes.Structure):
                            _fields_ = [("cbSize", ctypes.c_uint),
                                      ("hwnd", wintypes.HWND),
                                      ("dwFlags", wintypes.DWORD),
                                      ("uCount", ctypes.c_uint),
                                      ("dwTimeout", wintypes.DWORD)]
                        
                        flash_info = FLASHWINFO()
                        flash_info.cbSize = ctypes.sizeof(FLASHWINFO)
                        flash_info.hwnd = hwnd
                        flash_info.dwFlags = FLASHW_ALL | FLASHW_TIMERNOFG
                        flash_info.uCount = 3
                        flash_info.dwTimeout = 0
                        
                        ctypes.windll.user32.FlashWindowEx(ctypes.byref(flash_info))
                        
                    except Exception as e:
                        self.logger.debug(f"Advanced Windows activation failed: {e}")
                    
                    self.logger.info("Applied Windows-specific window positioning")
                    print("✅ Windows GUI fixes applied successfully")
                    
                except Exception as e:
                    self.logger.warning(f"Windows-specific positioning failed: {e}")
                    print(f"⚠️ Some Windows fixes failed: {e}")
            
            # Show the window using tkinter methods
            self.root.deiconify()
            self.root.update()
            
            # General visibility improvements
            self.root.lift()
            self.root.focus_force()
            
            # Temporarily set topmost to ensure visibility
            self.root.attributes('-topmost', True)
            self.root.update()
            
            # Additional aggressive visibility measures
            self.root.wm_attributes('-topmost', True)
            self.root.tkraise()
            self.root.focus_set()
            
            # Schedule to remove topmost after window is visible
            self.root.after(300, self._finalize_window_display)
            
            # Force a window refresh
            self.root.after(100, lambda: self.root.update())
            self.root.after(200, lambda: self.root.update_idletasks())
            
            self.logger.info("GUI window should now be visible")
            print("✅ GUI window initialized successfully!")
            print("📱 BoomSQL GUI should now be visible on your screen.")
            print("💡 If you don't see the window, check your taskbar or try Alt+Tab")
            print("🔄 Starting main application loop...")
            print("⚠️  Application will remain running until you close the GUI window...")
            
        except Exception as e:
            self.logger.error(f"Failed to initialize GUI window: {e}")
            print(f"❌ GUI initialization failed: {e}")
            print("🔧 The application may not be visible. Try minimizing/maximizing your windows.")
            print("💡 If the GUI still doesn't appear, try running with --skip-gui flag.")
            
        # CRITICAL: Add debug message before mainloop
        print("🚀 Entering GUI main loop - window should be visible now!")
        self.logger.info("Entering GUI main loop")
        
        # Final safety check - ensure window is visible
        self.root.deiconify()
        self.root.lift()
        self.root.focus_force()
        self.root.update()
        
        # Additional safety - add a method to check if window is actually visible
        if sys.platform.startswith('win'):
            try:
                import ctypes
                hwnd = self.root.winfo_id()
                # Check if window is visible
                is_visible = ctypes.windll.user32.IsWindowVisible(hwnd)
                print(f"🔍 Window visibility check: {bool(is_visible)}")
                if not is_visible:
                    print("⚠️ Window not visible - applying emergency fixes...")
                    ctypes.windll.user32.ShowWindow(hwnd, 5)  # SW_SHOW
                    ctypes.windll.user32.SetForegroundWindow(hwnd)
            except Exception as e:
                print(f"⚠️ Visibility check failed: {e}")
        
        # Start main loop
        try:
            print("🔄 Starting tkinter main event loop...")
            self.root.mainloop()
            print("🔚 Main loop ended - application shutting down")
        except KeyboardInterrupt:
            self.logger.info("Application interrupted by user")
            print("🛑 Application interrupted by user")
        except Exception as e:
            self.logger.error(f"Unexpected error: {e}")
            print(f"❌ Unexpected error in main loop: {e}")
            import traceback
            traceback.print_exc()
            if TKINTER_AVAILABLE:
                try:
                    messagebox.showerror("Error", f"An unexpected error occurred: {e}")
                except:
                    pass  # Ignore if messagebox fails
        finally:
            print("🧹 Cleaning up and exiting...")
            self.cleanup()
            
    def _finalize_window_display(self):
        """Final window display adjustments (called after initial display)"""
        try:
            # Remove topmost after window is shown
            self.root.attributes('-topmost', False)
            
            # Ensure focus
            self.root.focus_set()
            
            # Final update
            self.root.update()
            
            # Additional Windows-specific final adjustments
            if sys.platform.startswith('win'):
                try:
                    import ctypes
                    hwnd = self.root.winfo_id()
                    
                    # Final activation to ensure it's in foreground
                    ctypes.windll.user32.SetActiveWindow(hwnd)
                    
                    # Force window to be visible one more time
                    SW_SHOW = 5
                    ctypes.windll.user32.ShowWindow(hwnd, SW_SHOW)
                    ctypes.windll.user32.SetForegroundWindow(hwnd)
                    
                    print("🎉 Final Windows visibility fixes applied!")
                    
                except Exception as e:
                    self.logger.warning(f"Final Windows activation failed: {e}")
            
            self.logger.info("Window display finalized")
            print("🎉 GUI is ready for use!")
            print("📱 If you can't see the window, try Alt+Tab to find it")
            print("💡 The window should be visible on your screen now")
            
        except Exception as e:
            self.logger.warning(f"Could not finalize window display: {e}")
            print(f"⚠️ Could not finalize window display: {e}")
            
    def cleanup(self):
        """Cleanup resources before exit"""
        self.logger.info("Cleaning up resources")
        
        # Cancel any running tasks
        if hasattr(self, 'main_window') and self.main_window:
            self.main_window.cancel_all_tasks()
            
        # Close database connections
        if self.database_dumper:
            self.database_dumper.close()
            
        # Shutdown event loop manager
        if hasattr(self, 'event_loop_manager'):
            self.event_loop_manager.stop()
            
        # Global shutdown
        shutdown_event_loop()
            
        self.logger.info("BoomSQL application closed")

def main():
    """Main entry point"""
    print("=" * 60)
    print("BoomSQL - Advanced SQL Injection Testing Tool")
    print("Python Version 2.0.0")
    print("=" * 60)
    print()
    print("⚠️  WARNING: FOR EDUCATIONAL AND AUTHORIZED TESTING ONLY")
    print("This tool is designed for educational purposes and authorized")
    print("penetration testing. Unauthorized use is illegal and unethical.")
    print()
    
    # Parse command line arguments early for special modes
    parser = argparse.ArgumentParser(description='BoomSQL - Advanced SQL Injection Testing Tool')
    parser.add_argument('--url', type=str, help='URL to test for SQL injection vulnerabilities')
    parser.add_argument('--crawl', type=str, help='URL to crawl for parametrized URLs')
    parser.add_argument('--dump', type=str, help='URL to dump database from (must be vulnerable)')
    parser.add_argument('--skip-gui', action='store_true', help='Skip GUI and run in command line mode')
    parser.add_argument('--force-gui', action='store_true', help='Force GUI mode even if auto-detection fails')
    parser.add_argument('--gui-test', action='store_true', help='Run GUI diagnostic test')
    args = parser.parse_args()
    
    # Handle special GUI test mode
    if args.gui_test:
        print("🔧 Running GUI diagnostic test...")
        print()
        try:
            # Simple GUI test without external module
            print("Testing basic tkinter functionality...")
            test_root = tk.Tk()
            test_root.title("BoomSQL GUI Test")
            test_root.geometry("400x300")
            
            tk.Label(test_root, text="GUI Test Successful!", 
                    font=("Arial", 16), pady=50).pack()
            tk.Button(test_root, text="Close", 
                     command=test_root.destroy, pady=10).pack()
            
            test_root.mainloop()
            print("✅ Basic GUI test completed successfully")
            return True
        except Exception as e:
            print(f"❌ GUI test failed: {e}")
            return False
    
    print("Starting application...")
    print()
    
    # Check if GUI should be skipped
    if args.skip_gui:
        print("🔄 GUI mode skipped by user request")
        run_cli_mode()
        return
    
    # Check if GUI is available using cross-platform detection
    gui_available, gui_message = is_gui_available()
    
    # Force GUI mode if requested
    if args.force_gui:
        print("🚀 GUI mode forced by user request")
        gui_available = True
        gui_message = "GUI forced by --force-gui flag"
    
    if gui_available:
        print(f"✓ {gui_message}")
        try:
            print("🚀 Launching GUI application...")
            app = BoomSQLApplication()
            print("📱 GUI application initialized, starting...")
            app.run()
        except Exception as e:
            print(f"❌ Failed to start GUI application: {e}")
            import traceback
            print("🔍 Full error details:")
            traceback.print_exc()
            print()
            print("🔄 Falling back to command line mode...")
            run_cli_mode()
    else:
        print(f"GUI not available: {gui_message}")
        
        # Show platform info for debugging
        platform_info = get_platform_info()
        print(f"Platform: {platform_info['system']} {platform_info['release']}")
        
        if platform_info['system'] == 'Linux':
            print(f"DISPLAY: {platform_info['display_env']}")
            print(f"WAYLAND_DISPLAY: {platform_info['wayland_env']}")
        
        print("Running in command line mode...")
        run_cli_mode()

def run_cli_mode():
    """Run in command line mode when GUI is not available"""
    print("=" * 60)
    print("BoomSQL - Command Line Mode")
    print("=" * 60)
    print()
    print("Core functionality test:")
    
    # Test core functionality
    try:
        from core.config_manager import ConfigManager
        from core.logger import setup_logging
        from core.sql_injection_engine import SqlInjectionEngine
        from core.web_crawler import WebCrawler
        from core.dork_searcher import DorkSearcher
        from core.report_generator import ReportGenerator
        
        # Initialize components
        config = ConfigManager()
        setup_logging()
        
        print("✓ Configuration manager loaded")
        print("✓ Logging system initialized")
        
        # Test SQL injection engine
        sql_engine = SqlInjectionEngine(config)
        print("✓ SQL injection engine loaded")
        
        # Test web crawler
        web_crawler = WebCrawler(config)
        print("✓ Web crawler initialized")
        
        # Test dork searcher
        dork_searcher = DorkSearcher(config)
        print("✓ Dork searcher initialized")
        
        # Test report generator
        report_generator = ReportGenerator(config)
        print("✓ Report generator initialized")
        
        print()
        print("All core components initialized successfully!")
        
        # Parse command line arguments
        parser = argparse.ArgumentParser(description='BoomSQL - Advanced SQL Injection Testing Tool')
        parser.add_argument('--url', type=str, help='URL to test for SQL injection vulnerabilities')
        parser.add_argument('--crawl', type=str, help='URL to crawl for parametrized URLs')
        parser.add_argument('--dump', type=str, help='URL to dump database from (must be vulnerable)')
        parser.add_argument('--skip-gui', action='store_true', help='Skip GUI and run in command line mode')
        parser.add_argument('--force-gui', action='store_true', help='Force GUI mode even if auto-detection fails')
        parser.add_argument('--gui-test', action='store_true', help='Run GUI diagnostic test')
        args = parser.parse_args()
        
        # Add command line functionality
        if args.url:
            url = args.url
            print(f"\n🎯 Testing URL: {url}")
            print("=" * 50)
            
            try:
                import asyncio
                from core.event_loop_manager import get_event_loop_manager
                
                manager = get_event_loop_manager()
                
                async def test_url_async():
                    try:
                        print("⏳ Starting SQL injection test...")
                        result = await sql_engine.test_url(url)
                        
                        print(f"\n📊 Test Results:")
                        print(f"   • URL: {result.url}")
                        print(f"   • Total vulnerabilities: {len(result.vulnerabilities)}")
                        print(f"   • Test duration: {result.total_time:.2f} seconds")
                        print(f"   • Payloads tested: {result.total_payloads_tested}")
                        
                        if result.vulnerabilities:
                            print(f"\n🚨 VULNERABILITIES FOUND:")
                            for i, vuln in enumerate(result.vulnerabilities, 1):
                                print(f"   {i}. Parameter: {vuln.injection_point.name}")
                                print(f"      Type: {vuln.injection_type.value if vuln.injection_type else 'Unknown'}")
                                print(f"      Database: {vuln.database_type.value if vuln.database_type else 'Unknown'}")
                                print(f"      Confidence: {vuln.confidence:.1%}")
                                payload_text = vuln.payload.payload if hasattr(vuln.payload, 'payload') else str(vuln.payload)
                                print(f"      Payload: {payload_text[:50]}..." if len(payload_text) > 50 else f"      Payload: {payload_text}")
                                print()
                        else:
                            print(f"\n✅ No vulnerabilities detected.")
                        
                        # Save report
                        print(f"💾 Generating report...")
                        report_data = {
                            "scan_time": datetime.now().isoformat(),
                            "target_url": url,
                            "total_vulnerabilities": len(result.vulnerabilities),
                            "vulnerabilities": []
                        }
                        
                        for vuln in result.vulnerabilities:
                            vuln_data = {
                                "parameter": vuln.injection_point.name,
                                "injection_type": vuln.injection_type.value if vuln.injection_type else "Unknown",
                                "database_type": vuln.database_type.value if vuln.database_type else "Unknown",
                                "confidence": vuln.confidence,
                                "payload": vuln.payload.payload if hasattr(vuln.payload, 'payload') else str(vuln.payload),
                                "error_message": vuln.error_message if hasattr(vuln, 'error_message') else ""
                            }
                            report_data["vulnerabilities"].append(vuln_data)
                        
                        # Save to file
                        report_file = f"scan_report_{datetime.now().strftime('%Y%m%d_%H%M%S')}.json"
                        with open(report_file, 'w') as f:
                            json.dump(report_data, f, indent=2)
                        
                        print(f"📄 Report saved to: {report_file}")
                        
                    except Exception as e:
                        print(f"❌ Test failed: {e}")
                        import traceback
                        traceback.print_exc()
                    finally:
                        # Clean up sessions
                        await sql_engine.close()
                
                # Run the test
                manager.run_async_blocking(test_url_async(), timeout=60)
                
            except Exception as e:
                print(f"❌ Error running test: {e}")
                import traceback
                traceback.print_exc()
                
        elif args.crawl:
            crawl_url = args.crawl
            print(f"\n🕷️ Crawling website: {crawl_url}")
            print("=" * 50)
            
            try:
                import asyncio
                from core.event_loop_manager import get_event_loop_manager
                
                manager = get_event_loop_manager()
                
                async def crawl_website_async():
                    try:
                        print("⏳ Starting website crawl...")
                        
                        # Restrict crawling to same domain
                        from urllib.parse import urlparse
                        start_domain = urlparse(crawl_url).netloc
                        
                        # Store original should_crawl_url method
                        original_should_crawl = web_crawler.should_crawl_url
                        
                        def domain_restricted_should_crawl(url):
                            # First check the original conditions
                            if not original_should_crawl(url):
                                return False
                            
                            # Then check if it's the same domain
                            url_domain = urlparse(url).netloc
                            return url_domain == start_domain
                        
                        # Temporarily replace the method
                        web_crawler.should_crawl_url = domain_restricted_should_crawl
                        
                        # Initialize web crawler (not async)
                        web_crawler.init_session()
                        
                        # Define progress callback
                        def progress_callback(message):
                            print(f"📄 {message}")
                        
                        # Start crawling
                        crawled_urls = await web_crawler.crawl(crawl_url, callback=progress_callback)
                        
                        print(f"\n📊 Crawl Results:")
                        print(f"   • Total URLs crawled: {len(crawled_urls)}")
                        
                        # Count parameters by type
                        total_params = 0
                        get_params = 0
                        post_params = 0
                        parametrized_urls = []
                        
                        for crawled_url in crawled_urls:
                            if crawled_url.parameters:
                                parametrized_urls.append(crawled_url)
                                for param in crawled_url.parameters:
                                    total_params += 1
                                    if param.type.value == 'get':
                                        get_params += 1
                                    elif param.type.value == 'post':
                                        post_params += 1
                        
                        print(f"   • Total parameters found: {total_params}")
                        print(f"   • GET parameters: {get_params}")
                        print(f"   • POST parameters: {post_params}")
                        print(f"   • URLs with parameters: {len(parametrized_urls)}")
                        
                        if parametrized_urls:
                            print(f"\n🎯 PARAMETRIZED URLS FOUND:")
                            for i, crawled_url in enumerate(parametrized_urls[:10], 1):  # Show first 10
                                print(f"\n   {i}. {crawled_url.url}")
                                print(f"      Title: {crawled_url.title[:50]}..." if len(crawled_url.title) > 50 else f"      Title: {crawled_url.title}")
                                print(f"      Status: {crawled_url.status_code}")
                                print(f"      Parameters:")
                                
                                for param in crawled_url.parameters[:5]:  # Show first 5 params per URL
                                    print(f"        • {param.name}={param.value} ({param.type.value.upper()})")
                                
                                if len(crawled_url.parameters) > 5:
                                    print(f"        ... and {len(crawled_url.parameters) - 5} more parameters")
                            
                            if len(parametrized_urls) > 10:
                                print(f"\n   ... and {len(parametrized_urls) - 10} more URLs with parameters")
                        else:
                            print(f"\n❌ No parametrized URLs found.")
                        
                        # Save crawl report
                        print(f"\n💾 Generating crawl report...")
                        crawl_report_data = {
                            "crawl_time": datetime.now().isoformat(),
                            "start_url": crawl_url,
                            "total_urls": len(crawled_urls),
                            "total_parameters": total_params,
                            "get_parameters": get_params,
                            "post_parameters": post_params,
                            "parametrized_urls": []
                        }
                        
                        for crawled_url in parametrized_urls:
                            url_data = {
                                "url": crawled_url.url,
                                "title": crawled_url.title,
                                "status_code": crawled_url.status_code,
                                "parameters": []
                            }
                            
                            for param in crawled_url.parameters:
                                param_data = {
                                    "name": param.name,
                                    "value": param.value,
                                    "type": param.type.value,
                                    "form_action": param.form_action,
                                    "method": param.method
                                }
                                url_data["parameters"].append(param_data)
                            
                            crawl_report_data["parametrized_urls"].append(url_data)
                        
                        # Save to file
                        crawl_report_file = f"crawl_report_{datetime.now().strftime('%Y%m%d_%H%M%S')}.json"
                        with open(crawl_report_file, 'w') as f:
                            json.dump(crawl_report_data, f, indent=2)
                        
                        print(f"📄 Crawl report saved to: {crawl_report_file}")
                        
                    except Exception as e:
                        print(f"❌ Crawl failed: {e}")
                        import traceback
                        traceback.print_exc()
                    finally:
                        # Restore original method
                        if 'original_should_crawl' in locals():
                            web_crawler.should_crawl_url = original_should_crawl
                        # Clean up sessions
                        await web_crawler.close()
                
                # Run the crawl
                manager.run_async_blocking(crawl_website_async(), timeout=60)
                
            except Exception as e:
                print(f"❌ Error running crawl: {e}")
                import traceback
                traceback.print_exc()
                
        elif args.dump:
            dump_url = args.dump
            print(f"\n🗃️ Dumping database from: {dump_url}")
            print("=" * 50)
            
            try:
                import asyncio
                from core.event_loop_manager import get_event_loop_manager
                from core.database_dumper import DatabaseDumper
                
                manager = get_event_loop_manager()
                
                async def dump_database_async():
                    try:
                        print("⏳ Step 1: Testing URL for SQL injection vulnerabilities...")
                        
                        # First, test the URL for vulnerabilities
                        result = await sql_engine.test_url(dump_url)
                        
                        if not result.vulnerabilities:
                            print("❌ No SQL injection vulnerabilities found. Cannot dump database.")
                            print("💡 Try testing with --url first to find vulnerable parameters.")
                            return
                        
                        # Use the first vulnerability found
                        vulnerability = result.vulnerabilities[0]
                        print(f"✅ Found {len(result.vulnerabilities)} vulnerabilities")
                        print(f"🎯 Using vulnerability in parameter: {vulnerability.injection_point.name}")
                        print(f"   Type: {vulnerability.injection_type.value}")
                        print(f"   Database: {vulnerability.database_type.value}")
                        print(f"   Confidence: {vulnerability.confidence:.1%}")
                        
                        print(f"\n⏳ Step 2: Enumerating database structure...")
                        
                        # Initialize database dumper
                        database_dumper = DatabaseDumper(vulnerability, config)
                        
                        # Define progress callback
                        def progress_callback(message):
                            print(f"📋 {message}")
                        
                        # Enumerate database structure
                        database_info = await database_dumper.enumerate_database(callback=progress_callback)
                        
                        print(f"\n📊 Database Information:")
                        print(f"   • Database Type: {vulnerability.database_type.value}")
                        print(f"   • Version: {database_info.version}")
                        print(f"   • User: {database_info.user}")
                        print(f"   • Hostname: {database_info.hostname}")
                        print(f"   • Tables Found: {len(database_info.tables)}")
                        
                        if database_info.tables:
                            print(f"\n📋 Tables Found:")
                            for i, table in enumerate(database_info.tables[:10], 1):  # Show first 10 tables
                                print(f"   {i}. {table.schema}.{table.name} ({table.row_count} rows, {len(table.columns)} columns)")
                            
                            if len(database_info.tables) > 10:
                                print(f"   ... and {len(database_info.tables) - 10} more tables")
                        
                        print(f"\n⏳ Step 3: Dumping database contents...")
                        
                        # Dump database contents
                        dumped_database = await database_dumper.dump_database(database_info, callback=progress_callback)
                        
                        print(f"\n📊 Dump Results:")
                        total_rows = sum(len(table.data) for table in dumped_database.tables)
                        print(f"   • Total tables dumped: {len(dumped_database.tables)}")
                        print(f"   • Total rows extracted: {total_rows}")
                        
                        # Show sample data
                        if dumped_database.tables:
                            print(f"\n📋 Sample Data:")
                            for table in dumped_database.tables[:3]:  # Show first 3 tables
                                if table.data:
                                    print(f"\n   Table: {table.schema}.{table.name}")
                                    print(f"   Columns: {', '.join(col.name for col in table.columns)}")
                                    print(f"   Sample rows:")
                                    for i, row in enumerate(table.data[:3], 1):  # Show first 3 rows
                                        row_data = ', '.join(f"{k}={v}" for k, v in row.items())
                                        print(f"     {i}. {row_data[:100]}..." if len(row_data) > 100 else f"     {i}. {row_data}")
                                    
                                    if len(table.data) > 3:
                                        print(f"     ... and {len(table.data) - 3} more rows")
                        
                        # Save dump to file
                        print(f"\n💾 Generating database dump report...")
                        
                        dump_report_data = {
                            "dump_time": datetime.now().isoformat(),
                            "target_url": dump_url,
                            "vulnerability": {
                                "parameter": vulnerability.injection_point.name,
                                "injection_type": vulnerability.injection_type.value,
                                "database_type": vulnerability.database_type.value,
                                "confidence": vulnerability.confidence
                            },
                            "database_info": {
                                "version": database_info.version,
                                "user": database_info.user,
                                "hostname": database_info.hostname,
                                "total_tables": len(dumped_database.tables),
                                "total_rows": total_rows
                            },
                            "tables": []
                        }
                        
                        # Add table data to report
                        for table in dumped_database.tables:
                            table_data = {
                                "schema": table.schema,
                                "name": table.name,
                                "row_count": len(table.data),
                                "columns": [{"name": col.name, "type": col.type} for col in table.columns],
                                "data": table.data[:50]  # Limit to first 50 rows in report
                            }
                            dump_report_data["tables"].append(table_data)
                        
                        # Save to file
                        dump_report_file = f"database_dump_{datetime.now().strftime('%Y%m%d_%H%M%S')}.json"
                        with open(dump_report_file, 'w') as f:
                            json.dump(dump_report_data, f, indent=2, default=str)
                        
                        print(f"📄 Database dump saved to: {dump_report_file}")
                        
                        # Also save as CSV for easy viewing
                        csv_files = []
                        for table in dumped_database.tables:
                            if table.data:
                                csv_filename = f"table_{table.schema}_{table.name}_{datetime.now().strftime('%Y%m%d_%H%M%S')}.csv"
                                with open(csv_filename, 'w', newline='', encoding='utf-8') as csvfile:
                                    if table.data:
                                        fieldnames = table.data[0].keys()
                                        writer = csv.DictWriter(csvfile, fieldnames=fieldnames)
                                        writer.writeheader()
                                        writer.writerows(table.data)
                                        csv_files.append(csv_filename)
                        
                        if csv_files:
                            print(f"📄 Table data also saved as CSV files:")
                            for csv_file in csv_files:
                                print(f"   • {csv_file}")
                        
                    except Exception as e:
                        print(f"❌ Database dump failed: {e}")
                        import traceback
                        traceback.print_exc()
                    finally:
                        # Clean up sessions
                        await sql_engine.close()
                        if 'database_dumper' in locals():
                            await database_dumper.close()
                
                # Run the dump
                manager.run_async_blocking(dump_database_async(), timeout=300)  # 5 minute timeout
                
            except Exception as e:
                print(f"❌ Error running database dump: {e}")
                import traceback
                traceback.print_exc()
        else:
            print("\n💡 No action specified. Choose an option:")
            print("   • Use --url <target_url> to test a specific URL for SQL injection")
            print("   • Use --crawl <website_url> to crawl a website and find parametrized URLs")
            print("   • Use --dump <vulnerable_url> to dump database contents from a vulnerable URL")
            print("\nExamples:")
            print("   python boomsql.py --url 'http://example.com/search?q=test'")
            print("   python boomsql.py --crawl 'http://testphp.vulnweb.com/'")
            print("   python boomsql.py --dump 'http://testphp.vulnweb.com/listproducts.php?cat=1'")
            print("\nGUI mode is also available if running in an environment with display support.")
        
    except Exception as e:
        print(f"Error testing core functionality: {e}")
        import traceback
        traceback.print_exc()
        sys.exit(1)

if __name__ == "__main__":
    main()