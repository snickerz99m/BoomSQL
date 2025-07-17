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
import threading
import json
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
    
    # GUI imports (may fail if tkinter not available)
    if TKINTER_AVAILABLE:
        from gui.main_window import MainWindow
        from gui.disclaimer_dialog import DisclaimerDialog
    else:
        MainWindow = None
        DisclaimerDialog = None
        
except ImportError as e:
    print(f"Error importing modules: {e}")
    sys.exit(1)

class BoomSQLApplication:
    """Main BoomSQL application class"""
    
    def __init__(self):
        self.root = tk.Tk()
        self.root.withdraw()  # Hide main window initially
        
        # Setup logging
        setup_logging()
        self.logger = logging.getLogger(__name__)
        
        # Initialize event loop manager
        self.event_loop_manager = get_event_loop_manager()
        
        # Load configuration
        self.config = ConfigManager()
        
        # Initialize components
        self.sql_engine = None
        self.database_dumper = None
        self.web_crawler = None
        self.dork_searcher = None
        self.report_generator = None
        
        # Setup GUI
        self.setup_gui()
        
    def setup_gui(self):
        """Setup the main GUI"""
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
        
        # Set window icon (if available)
        try:
            icon_path = project_root / "assets" / "icon.ico"
            if icon_path.exists():
                self.root.iconbitmap(str(icon_path))
        except:
            pass
        
        # Apply theme
        self.apply_theme()
        
        # Create main window
        if TKINTER_AVAILABLE and MainWindow:
            self.main_window = MainWindow(self.root, self)
        else:
            self.main_window = None
        
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
            return True
            
        disclaimer = DisclaimerDialog(self.root)
        if not disclaimer.accepted:
            self.root.destroy()
            return False
        return True
        
    def run(self):
        """Run the application"""
        self.logger.info("Starting BoomSQL application")
        
        # Show disclaimer first
        if not self.show_disclaimer():
            return
            
        # Show main window with enhanced Windows visibility
        self.root.deiconify()
        self.root.lift()
        self.root.focus_force()
        
        # Enhanced Windows GUI visibility fixes
        try:
            # Force window to be visible and on top
            self.root.attributes('-topmost', True)
            self.root.update()
            self.root.after(200, lambda: self.root.attributes('-topmost', False))
            
            # Additional Windows-specific fixes
            self.root.state('normal')  # Ensure not minimized
            self.root.focus_set()      # Set focus
            self.root.grab_set()       # Grab focus (temporary)
            self.root.after(500, lambda: self.root.grab_release())  # Release grab after 500ms
            
            # Force window to front on Windows
            if sys.platform.startswith('win'):
                import ctypes
                try:
                    hwnd = ctypes.windll.user32.GetParent(self.root.winfo_id())
                    ctypes.windll.user32.SetWindowPos(hwnd, -1, 0, 0, 0, 0, 0x0001 | 0x0002)
                except:
                    pass  # Ignore if ctypes approach fails
                    
        except Exception as e:
            self.logger.warning(f"Could not apply Windows visibility fixes: {e}")
        
        # Start main loop
        try:
            self.root.mainloop()
        except KeyboardInterrupt:
            self.logger.info("Application interrupted by user")
        except Exception as e:
            self.logger.error(f"Unexpected error: {e}")
            messagebox.showerror("Error", f"An unexpected error occurred: {e}")
        finally:
            self.cleanup()
            
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
    print("Starting application...")
    print()
    
    # Check if display is available
    if not TKINTER_AVAILABLE:
        display_available = False
        print("tkinter not available in this environment.")
        print("GUI mode not available.")
        print()
    else:
        try:
            root = tk.Tk()
            root.withdraw()  # Hide immediately
            display_available = True
            root.destroy()
        except Exception as e:
            display_available = False
            print(f"Display not available: {e}")
            print("GUI mode not available in this environment.")
            print("Please run in an environment with X11 display support.")
            print()
    
    if display_available:
        try:
            app = BoomSQLApplication()
            app.run()
        except Exception as e:
            print(f"Failed to start GUI application: {e}")
            print("Falling back to command line mode...")
            run_cli_mode()
    else:
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
        print("GUI mode is required for full functionality.")
        print("Please run in an environment with display support to use the GUI.")
        
    except Exception as e:
        print(f"Error testing core functionality: {e}")
        import traceback
        traceback.print_exc()
        sys.exit(1)

if __name__ == "__main__":
    main()