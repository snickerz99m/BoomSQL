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
            root = tk.Tk()
            root.withdraw()
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
    
    # Check if GUI is available using cross-platform detection
    gui_available, gui_message = is_gui_available()
    
    if gui_available:
        print(f"✓ {gui_message}")
        try:
            app = BoomSQLApplication()
            app.run()
        except Exception as e:
            print(f"Failed to start GUI application: {e}")
            print("Falling back to command line mode...")
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