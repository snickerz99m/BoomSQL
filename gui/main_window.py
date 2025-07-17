"""
Main window for BoomSQL
Modern GUI with tabbed interface
"""

import tkinter as tk
from tkinter import ttk, messagebox, filedialog
import asyncio
import threading
import logging
from typing import Dict, Any, Optional

from .dork_page import DorkPage
from .crawler_page import CrawlerPage
from .tester_page import TesterPage
from .dumper_page import DumperPage
from .settings_page import SettingsPage

class MainWindow:
    """Main application window"""
    
    def __init__(self, root: tk.Tk, app):
        self.root = root
        self.app = app
        self.logger = logging.getLogger(__name__)
        
        # Pages
        self.dork_page = None
        self.crawler_page = None
        self.tester_page = None
        self.dumper_page = None
        self.settings_page = None
        
        # Setup window
        self.setup_window()
        self.create_widgets()
        
        # Setup event loop for async operations
        self.setup_async_loop()
        
    def setup_window(self):
        """Setup main window properties"""
        self.root.title("BoomSQL - Advanced SQL Injection Testing Tool v2.0.0")
        self.root.geometry("1400x900")
        self.root.minsize(1200, 800)
        
        # Apply dark theme
        self.apply_dark_theme()
        
        # Configure grid weights
        self.root.grid_rowconfigure(0, weight=1)
        self.root.grid_columnconfigure(0, weight=1)
        
        # Center window
        self.root.update_idletasks()
        x = (self.root.winfo_screenwidth() // 2) - (1400 // 2)
        y = (self.root.winfo_screenheight() // 2) - (900 // 2)
        self.root.geometry(f"1400x900+{x}+{y}")
        
        # Handle window close
        self.root.protocol("WM_DELETE_WINDOW", self.on_closing)
        
        # Add keyboard shortcuts
        self.setup_keyboard_shortcuts()
    
    def apply_dark_theme(self):
        """Apply professional dark theme"""
        # Configure colors
        self.colors = {
            'bg': '#2b2b2b',
            'fg': '#ffffff',
            'select_bg': '#404040',
            'select_fg': '#ffffff',
            'entry_bg': '#404040',
            'entry_fg': '#ffffff',
            'button_bg': '#404040',
            'button_fg': '#ffffff',
            'frame_bg': '#2b2b2b',
            'accent': '#007acc',
            'success': '#4caf50',
            'warning': '#ff9800',
            'error': '#f44336'
        }
        
        # Configure root window
        self.root.configure(bg=self.colors['bg'])
        
        # Configure ttk styles
        style = ttk.Style()
        style.theme_use('clam')
        
        # Configure notebook (tabs)
        style.configure('TNotebook', background=self.colors['bg'])
        style.configure('TNotebook.Tab', 
                       background=self.colors['button_bg'],
                       foreground=self.colors['fg'],
                       padding=[10, 5])
        style.map('TNotebook.Tab',
                 background=[('selected', self.colors['accent'])])
        
        # Configure frames
        style.configure('TFrame', background=self.colors['bg'])
        style.configure('TLabelframe', background=self.colors['bg'],
                       foreground=self.colors['fg'])
        
        # Configure labels
        style.configure('TLabel', background=self.colors['bg'],
                       foreground=self.colors['fg'])
        
        # Configure buttons
        style.configure('TButton', 
                       background=self.colors['button_bg'],
                       foreground=self.colors['fg'],
                       padding=[10, 5])
        style.map('TButton',
                 background=[('active', self.colors['accent'])])
        
        # Configure entries
        style.configure('TEntry',
                       fieldbackground=self.colors['entry_bg'],
                       foreground=self.colors['entry_fg'],
                       bordercolor=self.colors['accent'])
        
        # Configure text widgets
        style.configure('TText',
                       background=self.colors['entry_bg'],
                       foreground=self.colors['entry_fg'])
        
        # Configure treeview
        style.configure('Treeview',
                       background=self.colors['entry_bg'],
                       foreground=self.colors['entry_fg'],
                       fieldbackground=self.colors['entry_bg'])
        style.map('Treeview',
                 background=[('selected', self.colors['accent'])])
        
        # Configure progressbar
        style.configure('TProgressbar',
                       background=self.colors['accent'],
                       troughcolor=self.colors['entry_bg'])
    
    def setup_keyboard_shortcuts(self):
        """Setup keyboard shortcuts for power users"""
        # File operations
        self.root.bind('<Control-o>', lambda e: self.show_open_dialog())
        self.root.bind('<Control-s>', lambda e: self.show_save_dialog())
        self.root.bind('<Control-q>', lambda e: self.on_closing())
        
        # Tab navigation
        self.root.bind('<Control-1>', lambda e: self.switch_to_tab(0))
        self.root.bind('<Control-2>', lambda e: self.switch_to_tab(1))
        self.root.bind('<Control-3>', lambda e: self.switch_to_tab(2))
        self.root.bind('<Control-4>', lambda e: self.switch_to_tab(3))
        self.root.bind('<Control-5>', lambda e: self.switch_to_tab(4))
        
        # Tool operations
        self.root.bind('<F1>', lambda e: self.show_help())
        self.root.bind('<F5>', lambda e: self.refresh_current_tab())
        self.root.bind('<Control-r>', lambda e: self.refresh_current_tab())
        
        # Advanced shortcuts
        self.root.bind('<Control-Shift-t>', lambda e: self.new_tab())
        self.root.bind('<Control-w>', lambda e: self.close_current_tab())
        self.root.bind('<Control-f>', lambda e: self.show_search_dialog())
        
    def create_widgets(self):
        """Create main window widgets"""
        # Main frame
        main_frame = ttk.Frame(self.root)
        main_frame.grid(row=0, column=0, sticky="nsew", padx=10, pady=10)
        main_frame.grid_rowconfigure(1, weight=1)
        main_frame.grid_columnconfigure(0, weight=1)
        
        # Header frame
        header_frame = ttk.Frame(main_frame)
        header_frame.grid(row=0, column=0, sticky="ew", pady=(0, 10))
        header_frame.grid_columnconfigure(1, weight=1)
        
        # Logo/Title
        title_label = ttk.Label(
            header_frame,
            text="BoomSQL",
            font=("Arial", 24, "bold")
        )
        title_label.grid(row=0, column=0, sticky="w")
        
        # Version
        version_label = ttk.Label(
            header_frame,
            text="v2.0.0 - Python Edition",
            font=("Arial", 10)
        )
        version_label.grid(row=1, column=0, sticky="w")
        
        # Menu buttons frame
        menu_frame = ttk.Frame(header_frame)
        menu_frame.grid(row=0, column=1, sticky="e", rowspan=2)
        
        # Menu buttons
        self.create_menu_buttons(menu_frame)
        
        # Notebook for tabs
        self.notebook = ttk.Notebook(main_frame)
        self.notebook.grid(row=1, column=0, sticky="nsew")
        
        # Create tabs
        self.create_tabs()
        
        # Status bar
        self.create_status_bar(main_frame)
        
    def create_menu_buttons(self, parent):
        """Create menu buttons"""
        # File menu
        file_button = ttk.Button(
            parent,
            text="File",
            command=self.show_file_menu
        )
        file_button.grid(row=0, column=0, padx=5)
        
        # Tools menu
        tools_button = ttk.Button(
            parent,
            text="Tools",
            command=self.show_tools_menu
        )
        tools_button.grid(row=0, column=1, padx=5)
        
        # Help menu
        help_button = ttk.Button(
            parent,
            text="Help",
            command=self.show_help_menu
        )
        help_button.grid(row=0, column=2, padx=5)
        
    def create_tabs(self):
        """Create notebook tabs"""
        # Dork Search Tab
        self.dork_page = DorkPage(self.notebook, self.app)
        self.notebook.add(self.dork_page, text="🔍 Dork Search")
        
        # Web Crawler Tab
        self.crawler_page = CrawlerPage(self.notebook, self.app)
        self.notebook.add(self.crawler_page, text="🕷️ Web Crawler")
        
        # SQL Tester Tab
        self.tester_page = TesterPage(self.notebook, self.app)
        self.notebook.add(self.tester_page, text="🎯 SQL Tester")
        
        # Database Dumper Tab
        self.dumper_page = DumperPage(self.notebook, self.app)
        self.notebook.add(self.dumper_page, text="💾 Database Dumper")
        
        # Settings Tab
        self.settings_page = SettingsPage(self.notebook, self.app)
        self.notebook.add(self.settings_page, text="⚙️ Settings")
        
        # Bind tab change event
        self.notebook.bind("<<NotebookTabChanged>>", self.on_tab_changed)
        
    def create_status_bar(self, parent):
        """Create status bar"""
        status_frame = ttk.Frame(parent)
        status_frame.grid(row=2, column=0, sticky="ew", pady=(10, 0))
        status_frame.grid_columnconfigure(0, weight=1)
        
        # Status label
        self.status_var = tk.StringVar()
        self.status_var.set("Ready")
        
        status_label = ttk.Label(
            status_frame,
            textvariable=self.status_var,
            relief=tk.SUNKEN,
            anchor=tk.W
        )
        status_label.grid(row=0, column=0, sticky="ew", padx=(0, 10))
        
        # Progress bar
        self.progress_var = tk.DoubleVar()
        self.progress_bar = ttk.Progressbar(
            status_frame,
            variable=self.progress_var,
            maximum=100,
            length=200
        )
        self.progress_bar.grid(row=0, column=1, sticky="e")
        
    def setup_async_loop(self):
        """Setup async event loop"""
        self.loop = asyncio.new_event_loop()
        
        def run_loop():
            asyncio.set_event_loop(self.loop)
            self.loop.run_forever()
            
        self.loop_thread = threading.Thread(target=run_loop, daemon=True)
        self.loop_thread.start()
        
    def show_file_menu(self):
        """Show file menu"""
        menu = tk.Menu(self.root, tearoff=0)
        
        menu.add_command(label="New Project", command=self.new_project)
        menu.add_command(label="Open Project", command=self.open_project)
        menu.add_command(label="Save Project", command=self.save_project)
        menu.add_separator()
        menu.add_command(label="Import URLs", command=self.import_urls)
        menu.add_command(label="Export Results", command=self.export_results)
        menu.add_separator()
        menu.add_command(label="Exit", command=self.on_closing)
        
        # Show menu at cursor position
        try:
            menu.tk_popup(self.root.winfo_pointerx(), self.root.winfo_pointery())
        finally:
            menu.grab_release()
            
    def show_tools_menu(self):
        """Show tools menu"""
        menu = tk.Menu(self.root, tearoff=0)
        
        menu.add_command(label="Payload Generator", command=self.show_payload_generator)
        menu.add_command(label="WAF Detector", command=self.show_waf_detector)
        menu.add_command(label="Error Classifier", command=self.show_error_classifier)
        menu.add_separator()
        menu.add_command(label="Proxy Manager", command=self.show_proxy_manager)
        menu.add_command(label="User Agent Manager", command=self.show_ua_manager)
        menu.add_separator()
        menu.add_command(label="Report Generator", command=self.show_report_generator)
        
        try:
            menu.tk_popup(self.root.winfo_pointerx(), self.root.winfo_pointery())
        finally:
            menu.grab_release()
            
    def show_help_menu(self):
        """Show help menu"""
        menu = tk.Menu(self.root, tearoff=0)
        
        menu.add_command(label="Documentation", command=self.show_documentation)
        menu.add_command(label="Tutorial", command=self.show_tutorial)
        menu.add_command(label="FAQ", command=self.show_faq)
        menu.add_separator()
        menu.add_command(label="Report Bug", command=self.report_bug)
        menu.add_command(label="Feature Request", command=self.feature_request)
        menu.add_separator()
        menu.add_command(label="About", command=self.show_about)
        
        try:
            menu.tk_popup(self.root.winfo_pointerx(), self.root.winfo_pointery())
        finally:
            menu.grab_release()
            
    def on_tab_changed(self, event):
        """Handle tab change"""
        selected_tab = self.notebook.select()
        tab_text = self.notebook.tab(selected_tab, "text")
        self.update_status(f"Switched to {tab_text}")
        
    def new_project(self):
        """Create new project"""
        result = messagebox.askyesno(
            "New Project",
            "Are you sure you want to create a new project?\nAll unsaved data will be lost."
        )
        
        if result:
            # Clear all pages
            if self.dork_page:
                self.dork_page.clear_results()
            if self.crawler_page:
                self.crawler_page.clear_results()
            if self.tester_page:
                self.tester_page.clear_results()
            if self.dumper_page:
                self.dumper_page.clear_results()
                
            self.update_status("New project created")
            
    def open_project(self):
        """Open project file"""
        file_path = filedialog.askopenfilename(
            title="Open Project",
            filetypes=[("JSON files", "*.json"), ("All files", "*.*")]
        )
        
        if file_path:
            try:
                # Load project data
                import json
                with open(file_path, 'r', encoding='utf-8') as f:
                    project_data = json.load(f)
                    
                # Apply project data to pages
                self.load_project_data(project_data)
                self.update_status(f"Project loaded: {file_path}")
                
            except Exception as e:
                messagebox.showerror("Error", f"Failed to open project:\n{str(e)}")
                
    def save_project(self):
        """Save project file"""
        file_path = filedialog.asksaveasfilename(
            title="Save Project",
            defaultextension=".json",
            filetypes=[("JSON files", "*.json"), ("All files", "*.*")]
        )
        
        if file_path:
            try:
                # Collect project data
                project_data = self.collect_project_data()
                
                # Save project data
                import json
                with open(file_path, 'w', encoding='utf-8') as f:
                    json.dump(project_data, f, indent=2, ensure_ascii=False)
                    
                self.update_status(f"Project saved: {file_path}")
                
            except Exception as e:
                messagebox.showerror("Error", f"Failed to save project:\n{str(e)}")
                
    def import_urls(self):
        """Import URLs from file"""
        file_path = filedialog.askopenfilename(
            title="Import URLs",
            filetypes=[("Text files", "*.txt"), ("CSV files", "*.csv"), ("All files", "*.*")]
        )
        
        if file_path:
            try:
                urls = []
                with open(file_path, 'r', encoding='utf-8') as f:
                    for line in f:
                        line = line.strip()
                        if line and line.startswith('http'):
                            urls.append(line)
                            
                # Send URLs to current tab
                current_tab = self.notebook.select()
                tab_text = self.notebook.tab(current_tab, "text")
                
                if "Tester" in tab_text and self.tester_page:
                    self.tester_page.import_urls(urls)
                elif "Crawler" in tab_text and self.crawler_page:
                    self.crawler_page.import_urls(urls)
                else:
                    messagebox.showinfo("Info", f"Imported {len(urls)} URLs")
                    
                self.update_status(f"Imported {len(urls)} URLs")
                
            except Exception as e:
                messagebox.showerror("Error", f"Failed to import URLs:\n{str(e)}")
                
    def export_results(self):
        """Export results"""
        # Get current tab
        current_tab = self.notebook.select()
        tab_text = self.notebook.tab(current_tab, "text")
        
        if "Dork" in tab_text and self.dork_page:
            self.dork_page.export_results()
        elif "Crawler" in tab_text and self.crawler_page:
            self.crawler_page.export_results()
        elif "Tester" in tab_text and self.tester_page:
            self.tester_page.export_results()
        elif "Dumper" in tab_text and self.dumper_page:
            self.dumper_page.export_results()
        else:
            messagebox.showinfo("Info", "No results to export in current tab")
            
    def collect_project_data(self) -> Dict[str, Any]:
        """Collect project data from all pages"""
        project_data = {
            "version": "2.0.0",
            "created": str(tk.datetime.now()),
            "dork_page": self.dork_page.get_state() if self.dork_page else {},
            "crawler_page": self.crawler_page.get_state() if self.crawler_page else {},
            "tester_page": self.tester_page.get_state() if self.tester_page else {},
            "dumper_page": self.dumper_page.get_state() if self.dumper_page else {},
            "settings": self.settings_page.get_state() if self.settings_page else {}
        }
        return project_data
        
    def load_project_data(self, project_data: Dict[str, Any]):
        """Load project data into pages"""
        if "dork_page" in project_data and self.dork_page:
            self.dork_page.set_state(project_data["dork_page"])
        if "crawler_page" in project_data and self.crawler_page:
            self.crawler_page.set_state(project_data["crawler_page"])
        if "tester_page" in project_data and self.tester_page:
            self.tester_page.set_state(project_data["tester_page"])
        if "dumper_page" in project_data and self.dumper_page:
            self.dumper_page.set_state(project_data["dumper_page"])
        if "settings" in project_data and self.settings_page:
            self.settings_page.set_state(project_data["settings"])
            
    def show_payload_generator(self):
        """Show payload generator tool"""
        messagebox.showinfo("Coming Soon", "Payload Generator tool will be available in a future update")
        
    def show_waf_detector(self):
        """Show WAF detector tool"""
        messagebox.showinfo("Coming Soon", "WAF Detector tool will be available in a future update")
        
    def show_error_classifier(self):
        """Show error classifier tool"""
        messagebox.showinfo("Coming Soon", "Error Classifier tool will be available in a future update")
        
    def show_proxy_manager(self):
        """Show proxy manager"""
        messagebox.showinfo("Coming Soon", "Proxy Manager will be available in a future update")
        
    def show_ua_manager(self):
        """Show user agent manager"""
        messagebox.showinfo("Coming Soon", "User Agent Manager will be available in a future update")
        
    def show_report_generator(self):
        """Show report generator"""
        messagebox.showinfo("Coming Soon", "Report Generator will be available in a future update")
        
    def show_documentation(self):
        """Show documentation"""
        messagebox.showinfo("Documentation", "Documentation will be available at https://github.com/boomsql/docs")
        
    def show_tutorial(self):
        """Show tutorial"""
        messagebox.showinfo("Tutorial", "Tutorial will be available at https://github.com/boomsql/tutorial")
        
    def show_faq(self):
        """Show FAQ"""
        messagebox.showinfo("FAQ", "FAQ will be available at https://github.com/boomsql/faq")
        
    def report_bug(self):
        """Report bug"""
        messagebox.showinfo("Report Bug", "Please report bugs at https://github.com/boomsql/issues")
        
    def feature_request(self):
        """Feature request"""
        messagebox.showinfo("Feature Request", "Please submit feature requests at https://github.com/boomsql/features")
        
    def show_about(self):
        """Show about dialog"""
        about_text = """BoomSQL - Advanced SQL Injection Testing Tool
Version 2.0.0 - Python Edition

An advanced SQL injection testing tool designed for security professionals and researchers.

Features:
• 13 SQL injection detection methods
• 12 database system support
• 16 WAF bypass categories
• 500+ SQL injection payloads
• 200+ database error signatures
• Multi-threaded operation
• Modern GUI interface
• Comprehensive reporting

⚠️ FOR EDUCATIONAL AND AUTHORIZED TESTING ONLY

© 2024 BoomSQL Development Team
All Rights Reserved"""
        
        messagebox.showinfo("About BoomSQL", about_text)
        
    def update_status(self, message: str):
        """Update status bar"""
        self.status_var.set(message)
        self.logger.info(message)
        
    def update_progress(self, value: float):
        """Update progress bar"""
        self.progress_var.set(value)
        
    def run_async(self, coro):
        """Run async coroutine"""
        future = asyncio.run_coroutine_threadsafe(coro, self.loop)
        return future
        
    def cancel_all_tasks(self):
        """Cancel all running tasks"""
        if hasattr(self, 'loop') and self.loop.is_running():
            # Cancel all tasks
            for task in asyncio.all_tasks(self.loop):
                task.cancel()
                
            # Cancel page-specific tasks
            if self.dork_page:
                self.dork_page.cancel_operation()
            if self.crawler_page:
                self.crawler_page.cancel_operation()
            if self.tester_page:
                self.tester_page.cancel_operation()
            if self.dumper_page:
                self.dumper_page.cancel_operation()
                
    def on_closing(self):
        """Handle window closing"""
        # Ask for confirmation if operations are running
        if self.is_operation_running():
            result = messagebox.askyesno(
                "Confirm Exit",
                "Operations are currently running. Are you sure you want to exit?"
            )
            if not result:
                return
                
        # Cancel all operations
        self.cancel_all_tasks()
        
        # Stop async loop
        if hasattr(self, 'loop') and self.loop.is_running():
            self.loop.call_soon_threadsafe(self.loop.stop)
            
        # Close application
        self.root.destroy()
        
    def is_operation_running(self) -> bool:
        """Check if any operation is running"""
        return (
            (self.dork_page and self.dork_page.is_running()) or
            (self.crawler_page and self.crawler_page.is_running()) or
            (self.tester_page and self.tester_page.is_running()) or
            (self.dumper_page and self.dumper_page.is_running())
        )
    
    def show_open_dialog(self):
        """Show file open dialog"""
        file_path = filedialog.askopenfilename(
            title="Open Configuration",
            filetypes=[("JSON files", "*.json"), ("All files", "*.*")]
        )
        if file_path:
            self.load_configuration(file_path)
    
    def show_save_dialog(self):
        """Show file save dialog"""
        file_path = filedialog.asksaveasfilename(
            title="Save Configuration",
            filetypes=[("JSON files", "*.json"), ("All files", "*.*")]
        )
        if file_path:
            self.save_configuration(file_path)
    
    def switch_to_tab(self, tab_index: int):
        """Switch to specified tab"""
        if hasattr(self, 'notebook') and tab_index < self.notebook.index("end"):
            self.notebook.select(tab_index)
    
    def show_help(self):
        """Show help dialog"""
        help_text = """
BoomSQL - Advanced SQL Injection Testing Tool

Keyboard Shortcuts:
• Ctrl+O: Open configuration
• Ctrl+S: Save configuration
• Ctrl+Q: Quit application
• F1: Show help
• F5 or Ctrl+R: Refresh current tab
• Ctrl+1-5: Switch to tab 1-5
• Ctrl+Shift+T: New tab
• Ctrl+W: Close current tab
• Ctrl+F: Search

Advanced Features:
• 15+ SQL injection techniques
• 12 database systems supported
• 16 WAF bypass categories
• Multi-threaded testing
• Real-time progress tracking
• Professional reporting
• Session management
        """
        messagebox.showinfo("Help - BoomSQL", help_text)
    
    def refresh_current_tab(self):
        """Refresh current tab"""
        try:
            current_tab = self.notebook.select()
            tab_text = self.notebook.tab(current_tab, "text")
            
            if tab_text == "Dork Search" and self.dork_page:
                self.dork_page.refresh()
            elif tab_text == "Web Crawler" and self.crawler_page:
                self.crawler_page.refresh()
            elif tab_text == "SQL Tester" and self.tester_page:
                self.tester_page.refresh()
            elif tab_text == "DB Dumper" and self.dumper_page:
                self.dumper_page.refresh()
        except Exception as e:
            self.logger.error(f"Error refreshing tab: {e}")
    
    def new_tab(self):
        """Create new tab (placeholder for future implementation)"""
        messagebox.showinfo("New Tab", "New tab functionality will be available in future versions")
    
    def close_current_tab(self):
        """Close current tab (placeholder for future implementation)"""
        messagebox.showinfo("Close Tab", "Close tab functionality will be available in future versions")
    
    def show_search_dialog(self):
        """Show search dialog"""
        search_window = tk.Toplevel(self.root)
        search_window.title("Search")
        search_window.geometry("400x100")
        search_window.configure(bg=self.colors['bg'])
        
        # Search entry
        search_frame = ttk.Frame(search_window)
        search_frame.pack(fill=tk.X, padx=10, pady=10)
        
        ttk.Label(search_frame, text="Search:").pack(side=tk.LEFT)
        
        search_entry = ttk.Entry(search_frame, width=30)
        search_entry.pack(side=tk.LEFT, padx=(5, 0), fill=tk.X, expand=True)
        search_entry.focus()
        
        # Search button
        ttk.Button(search_frame, text="Search", 
                  command=lambda: self.perform_search(search_entry.get())).pack(side=tk.RIGHT, padx=(5, 0))
        
        # Enter key binding
        search_entry.bind('<Return>', lambda e: self.perform_search(search_entry.get()))
    
    def perform_search(self, query: str):
        """Perform search in current tab"""
        if not query:
            return
            
        try:
            current_tab = self.notebook.select()
            tab_text = self.notebook.tab(current_tab, "text")
            
            if tab_text == "Dork Search" and self.dork_page:
                self.dork_page.search(query)
            elif tab_text == "Web Crawler" and self.crawler_page:
                self.crawler_page.search(query)
            elif tab_text == "SQL Tester" and self.tester_page:
                self.tester_page.search(query)
            elif tab_text == "DB Dumper" and self.dumper_page:
                self.dumper_page.search(query)
        except Exception as e:
            self.logger.error(f"Error performing search: {e}")
    
    def load_configuration(self, file_path: str):
        """Load configuration from file"""
        try:
            import json
            with open(file_path, 'r') as f:
                config = json.load(f)
            
            # Apply configuration to app
            self.app.config.update(config)
            messagebox.showinfo("Success", f"Configuration loaded from {file_path}")
        except Exception as e:
            messagebox.showerror("Error", f"Failed to load configuration: {e}")
    
    def save_configuration(self, file_path: str):
        """Save configuration to file"""
        try:
            import json
            with open(file_path, 'w') as f:
                json.dump(self.app.config, f, indent=2)
            
            messagebox.showinfo("Success", f"Configuration saved to {file_path}")
        except Exception as e:
            messagebox.showerror("Error", f"Failed to save configuration: {e}")