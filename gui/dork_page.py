"""
Dork Search Page for BoomSQL
Google dorking interface with multiple search engines
"""

import tkinter as tk
from tkinter import ttk, messagebox, filedialog
import asyncio
import threading
from typing import List, Dict, Any, Optional
from pathlib import Path

from ..core.dork_searcher import DorkSearcher, SearchEngine, SearchResult

class DorkPage(ttk.Frame):
    """Dork search page"""
    
    def __init__(self, parent, app):
        super().__init__(parent)
        self.app = app
        self.dork_searcher = None
        self.search_results: List[SearchResult] = []
        self.is_searching = False
        
        self.create_widgets()
        self.load_dorks()
        
    def create_widgets(self):
        """Create page widgets"""
        # Main container
        main_frame = ttk.Frame(self)
        main_frame.pack(fill=tk.BOTH, expand=True, padx=10, pady=10)
        
        # Left panel - Configuration
        left_frame = ttk.LabelFrame(main_frame, text="Search Configuration", padding=10)
        left_frame.pack(side=tk.LEFT, fill=tk.Y, padx=(0, 10))
        left_frame.configure(width=300)
        left_frame.pack_propagate(False)
        
        # Dorks section
        dorks_frame = ttk.LabelFrame(left_frame, text="Dorks", padding=5)
        dorks_frame.pack(fill=tk.BOTH, expand=True, pady=(0, 10))
        
        # Dorks listbox with scrollbar
        dorks_list_frame = ttk.Frame(dorks_frame)
        dorks_list_frame.pack(fill=tk.BOTH, expand=True)
        
        dorks_scrollbar = ttk.Scrollbar(dorks_list_frame)
        dorks_scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
        
        self.dorks_listbox = tk.Listbox(
            dorks_list_frame,
            yscrollcommand=dorks_scrollbar.set,
            selectmode=tk.EXTENDED,
            height=8
        )
        self.dorks_listbox.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        dorks_scrollbar.config(command=self.dorks_listbox.yview)
        
        # Dorks buttons
        dorks_button_frame = ttk.Frame(dorks_frame)
        dorks_button_frame.pack(fill=tk.X, pady=(5, 0))
        
        ttk.Button(dorks_button_frame, text="Load", command=self.load_dorks_file).pack(side=tk.LEFT, padx=(0, 5))
        ttk.Button(dorks_button_frame, text="Add", command=self.add_dork).pack(side=tk.LEFT, padx=(0, 5))
        ttk.Button(dorks_button_frame, text="Remove", command=self.remove_dork).pack(side=tk.LEFT, padx=(0, 5))
        ttk.Button(dorks_button_frame, text="Clear", command=self.clear_dorks).pack(side=tk.LEFT)
        
        # Search Engines section
        engines_frame = ttk.LabelFrame(left_frame, text="Search Engines", padding=5)
        engines_frame.pack(fill=tk.X, pady=(0, 10))
        
        # Search engine checkboxes
        self.engine_vars = {}
        for engine in SearchEngine:
            var = tk.BooleanVar()
            if engine in [SearchEngine.GOOGLE, SearchEngine.BING, SearchEngine.YAHOO, SearchEngine.DUCKDUCKGO]:
                var.set(True)
            self.engine_vars[engine] = var
            
            ttk.Checkbutton(
                engines_frame,
                text=engine.value.title(),
                variable=var
            ).pack(anchor=tk.W)
        
        # Options section
        options_frame = ttk.LabelFrame(left_frame, text="Options", padding=5)
        options_frame.pack(fill=tk.X, pady=(0, 10))
        
        # Max results
        ttk.Label(options_frame, text="Max Results:").pack(anchor=tk.W)
        self.max_results_var = tk.StringVar(value="100")
        ttk.Entry(options_frame, textvariable=self.max_results_var, width=10).pack(anchor=tk.W, pady=(0, 5))
        
        # Request delay
        ttk.Label(options_frame, text="Request Delay (ms):").pack(anchor=tk.W)
        self.delay_var = tk.StringVar(value="2000")
        ttk.Entry(options_frame, textvariable=self.delay_var, width=10).pack(anchor=tk.W, pady=(0, 5))
        
        # Filter results
        self.filter_var = tk.BooleanVar(value=True)
        ttk.Checkbutton(options_frame, text="Filter Results", variable=self.filter_var).pack(anchor=tk.W)
        
        # Remove duplicates
        self.dedup_var = tk.BooleanVar(value=True)
        ttk.Checkbutton(options_frame, text="Remove Duplicates", variable=self.dedup_var).pack(anchor=tk.W)
        
        # Use proxies
        self.proxy_var = tk.BooleanVar(value=False)
        ttk.Checkbutton(options_frame, text="Use Proxies", variable=self.proxy_var).pack(anchor=tk.W)
        
        # Control buttons
        control_frame = ttk.Frame(left_frame)
        control_frame.pack(fill=tk.X, pady=(0, 10))
        
        self.start_button = ttk.Button(control_frame, text="Start Search", command=self.start_search)
        self.start_button.pack(side=tk.LEFT, padx=(0, 5))
        
        self.stop_button = ttk.Button(control_frame, text="Stop", command=self.stop_search, state=tk.DISABLED)
        self.stop_button.pack(side=tk.LEFT, padx=(0, 5))
        
        self.clear_button = ttk.Button(control_frame, text="Clear Results", command=self.clear_results)
        self.clear_button.pack(side=tk.LEFT)
        
        # Right panel - Results
        right_frame = ttk.LabelFrame(main_frame, text="Search Results", padding=10)
        right_frame.pack(side=tk.RIGHT, fill=tk.BOTH, expand=True)
        
        # Results summary
        summary_frame = ttk.Frame(right_frame)
        summary_frame.pack(fill=tk.X, pady=(0, 10))
        
        self.summary_var = tk.StringVar(value="No results yet")\n        ttk.Label(summary_frame, textvariable=self.summary_var).pack(side=tk.LEFT)
        
        # Export button
        ttk.Button(summary_frame, text="Export Results", command=self.export_results).pack(side=tk.RIGHT)
        
        # Progress bar
        self.progress_var = tk.DoubleVar()
        self.progress_bar = ttk.Progressbar(
            right_frame,
            variable=self.progress_var,
            maximum=100,
            length=400
        )
        self.progress_bar.pack(fill=tk.X, pady=(0, 10))
        
        # Results treeview
        columns = ("URL", "Title", "Engine", "Dork", "Position")
        self.results_tree = ttk.Treeview(right_frame, columns=columns, show="headings")
        
        # Configure columns
        self.results_tree.heading("URL", text="URL")
        self.results_tree.heading("Title", text="Title")
        self.results_tree.heading("Engine", text="Engine")
        self.results_tree.heading("Dork", text="Dork")
        self.results_tree.heading("Position", text="Position")
        
        self.results_tree.column("URL", width=300)
        self.results_tree.column("Title", width=200)
        self.results_tree.column("Engine", width=100)
        self.results_tree.column("Dork", width=150)
        self.results_tree.column("Position", width=80)
        
        # Treeview scrollbar
        tree_scrollbar = ttk.Scrollbar(right_frame, orient=tk.VERTICAL, command=self.results_tree.yview)
        self.results_tree.configure(yscrollcommand=tree_scrollbar.set)
        
        self.results_tree.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        tree_scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
        
        # Bind double-click
        self.results_tree.bind("<Double-1>", self.on_result_double_click)
        
        # Context menu
        self.create_context_menu()
        
    def create_context_menu(self):
        """Create context menu for results"""
        self.context_menu = tk.Menu(self, tearoff=0)
        self.context_menu.add_command(label="Open URL", command=self.open_url)
        self.context_menu.add_command(label="Copy URL", command=self.copy_url)
        self.context_menu.add_separator()
        self.context_menu.add_command(label="Send to Crawler", command=self.send_to_crawler)
        self.context_menu.add_command(label="Send to Tester", command=self.send_to_tester)
        self.context_menu.add_separator()
        self.context_menu.add_command(label="Remove", command=self.remove_result)
        
        self.results_tree.bind("<Button-3>", self.show_context_menu)
        
    def show_context_menu(self, event):
        """Show context menu"""
        item = self.results_tree.identify_row(event.y)
        if item:
            self.results_tree.selection_set(item)
            self.context_menu.post(event.x_root, event.y_root)
            
    def load_dorks(self):
        """Load default dorks"""
        default_dorks = [
            'inurl:admin',
            'inurl:login',
            'inurl:admin/login',
            'inurl:admin.php',
            'inurl:login.php',
            'inurl:phpmyadmin',
            'inurl:mysql',
            'inurl:database',
            'inurl:config',
            'inurl:sql',
            'intitle:"index of"',
            'intitle:"phpMyAdmin"',
            'intitle:"MySQL"',
            'intitle:"Database"',
            'filetype:sql',
            'filetype:db',
            'filetype:bak',
            'filetype:config',
            'filetype:log'
        ]
        
        self.dorks_listbox.delete(0, tk.END)
        for dork in default_dorks:
            self.dorks_listbox.insert(tk.END, dork)
            
    def load_dorks_file(self):
        """Load dorks from file"""
        file_path = filedialog.askopenfilename(
            title="Load Dorks",
            filetypes=[("Text files", "*.txt"), ("All files", "*.*")]
        )
        
        if file_path:
            try:
                with open(file_path, 'r', encoding='utf-8') as f:
                    dorks = [line.strip() for line in f if line.strip() and not line.startswith('#')]
                    
                self.dorks_listbox.delete(0, tk.END)
                for dork in dorks:
                    self.dorks_listbox.insert(tk.END, dork)
                    
                messagebox.showinfo("Success", f"Loaded {len(dorks)} dorks from {file_path}")
                
            except Exception as e:
                messagebox.showerror("Error", f"Failed to load dorks:\n{str(e)}")
                
    def add_dork(self):
        """Add new dork"""
        from tkinter.simpledialog import askstring
        
        dork = askstring("Add Dork", "Enter dork:")
        if dork:
            self.dorks_listbox.insert(tk.END, dork)
            
    def remove_dork(self):
        """Remove selected dork"""
        selection = self.dorks_listbox.curselection()
        for index in reversed(selection):
            self.dorks_listbox.delete(index)
            
    def clear_dorks(self):
        """Clear all dorks"""
        result = messagebox.askyesno("Confirm", "Clear all dorks?")
        if result:
            self.dorks_listbox.delete(0, tk.END)
            
    def start_search(self):
        """Start dork search"""
        # Get dorks
        dorks = [self.dorks_listbox.get(i) for i in range(self.dorks_listbox.size())]
        if not dorks:
            messagebox.showwarning("Warning", "No dorks selected")
            return
            
        # Get selected engines
        engines = [engine for engine, var in self.engine_vars.items() if var.get()]
        if not engines:
            messagebox.showwarning("Warning", "No search engines selected")
            return
            
        # Update UI
        self.is_searching = True
        self.start_button.config(state=tk.DISABLED)
        self.stop_button.config(state=tk.NORMAL)
        self.progress_var.set(0)
        self.summary_var.set("Starting search...")
        
        # Clear previous results
        self.search_results.clear()
        self.results_tree.delete(*self.results_tree.get_children())
        
        # Start search in background
        self.search_thread = threading.Thread(target=self.run_search, args=(dorks, engines))
        self.search_thread.daemon = True
        self.search_thread.start()
        
    def run_search(self, dorks: List[str], engines: List[SearchEngine]):
        """Run search in background thread"""
        try:
            # Create config
            config = {
                "MaxResults": int(self.max_results_var.get()),
                "RequestTimeout": 30,
                "EnableResultFiltering": self.filter_var.get(),
                "EnableDuplicateRemoval": self.dedup_var.get(),
                "EnableProxyRotation": self.proxy_var.get(),
                "UserAgentFile": "useragents.txt",
                "ProxyFile": "proxies.txt"
            }
            
            # Create searcher
            self.dork_searcher = DorkSearcher(config)
            
            # Run search
            loop = asyncio.new_event_loop()
            asyncio.set_event_loop(loop)
            
            try:
                results = loop.run_until_complete(
                    self.dork_searcher.search(dorks, engines, self.search_progress_callback)
                )
                
                # Update results
                self.search_results = results
                self.update_results_display()
                
            finally:
                loop.close()
                
        except Exception as e:
            self.after(0, lambda: messagebox.showerror("Error", f"Search failed:\n{str(e)}"))
            
        finally:
            # Update UI
            self.after(0, self.search_completed)
            
    def search_progress_callback(self, message: str):
        """Search progress callback"""
        self.after(0, lambda: self.summary_var.set(message))
        
        # Update progress
        if self.dork_searcher and self.dork_searcher.progress:
            progress = self.dork_searcher.progress.progress_percentage
            self.after(0, lambda: self.progress_var.set(progress))
            
    def search_completed(self):
        """Search completed"""
        self.is_searching = False
        self.start_button.config(state=tk.NORMAL)
        self.stop_button.config(state=tk.DISABLED)
        self.progress_var.set(100)
        
        # Update summary
        if self.search_results:
            unique_domains = len(set(result.url.split('/')[2] for result in self.search_results))
            self.summary_var.set(f"Found {len(self.search_results)} results from {unique_domains} unique domains")
        else:
            self.summary_var.set("No results found")
            
    def stop_search(self):
        """Stop search"""
        if self.dork_searcher:
            self.dork_searcher.cancel_search()
            
    def update_results_display(self):
        """Update results display"""
        self.after(0, self._update_results_display)
        
    def _update_results_display(self):
        """Update results display (main thread)"""
        # Clear existing results
        self.results_tree.delete(*self.results_tree.get_children())
        
        # Add new results
        for result in self.search_results:
            self.results_tree.insert("", tk.END, values=(
                result.url,
                result.title[:50] + "..." if len(result.title) > 50 else result.title,
                result.search_engine.value,
                result.dork[:30] + "..." if len(result.dork) > 30 else result.dork,
                result.position
            ))
            
    def clear_results(self):
        """Clear search results"""
        self.search_results.clear()
        self.results_tree.delete(*self.results_tree.get_children())
        self.summary_var.set("No results yet")
        self.progress_var.set(0)
        
    def export_results(self):
        """Export search results"""
        if not self.search_results:
            messagebox.showwarning("Warning", "No results to export")
            return
            
        file_path = filedialog.asksaveasfilename(
            title="Export Results",
            defaultextension=".json",
            filetypes=[
                ("JSON files", "*.json"),
                ("CSV files", "*.csv"),
                ("HTML files", "*.html"),
                ("Text files", "*.txt")
            ]
        )
        
        if file_path:
            try:
                file_ext = Path(file_path).suffix.lower()
                
                if file_ext == '.json':
                    format_type = 'json'
                elif file_ext == '.csv':
                    format_type = 'csv'
                elif file_ext == '.html':
                    format_type = 'html'
                else:
                    format_type = 'txt'
                    
                self.dork_searcher.export_results(format_type, file_path)
                messagebox.showinfo("Success", f"Results exported to {file_path}")
                
            except Exception as e:
                messagebox.showerror("Error", f"Failed to export results:\n{str(e)}")
                
    def on_result_double_click(self, event):
        """Handle result double-click"""
        self.open_url()
        
    def open_url(self):
        """Open selected URL"""
        selection = self.results_tree.selection()
        if selection:
            item = selection[0]
            url = self.results_tree.item(item, "values")[0]
            
            import webbrowser
            webbrowser.open(url)
            
    def copy_url(self):
        """Copy selected URL"""
        selection = self.results_tree.selection()
        if selection:
            item = selection[0]
            url = self.results_tree.item(item, "values")[0]
            
            self.clipboard_clear()
            self.clipboard_append(url)
            messagebox.showinfo("Info", "URL copied to clipboard")
            
    def send_to_crawler(self):
        """Send selected URLs to crawler"""
        selection = self.results_tree.selection()
        if selection:
            urls = [self.results_tree.item(item, "values")[0] for item in selection]
            
            # Get crawler page
            crawler_page = self.app.main_window.crawler_page
            if crawler_page:
                crawler_page.import_urls(urls)
                messagebox.showinfo("Success", f"Sent {len(urls)} URLs to crawler")
            else:
                messagebox.showerror("Error", "Crawler page not available")
                
    def send_to_tester(self):
        """Send selected URLs to tester"""
        selection = self.results_tree.selection()
        if selection:
            urls = [self.results_tree.item(item, "values")[0] for item in selection]
            
            # Get tester page
            tester_page = self.app.main_window.tester_page
            if tester_page:
                tester_page.import_urls(urls)
                messagebox.showinfo("Success", f"Sent {len(urls)} URLs to tester")
            else:
                messagebox.showerror("Error", "Tester page not available")
                
    def remove_result(self):
        """Remove selected result"""
        selection = self.results_tree.selection()
        if selection:
            for item in selection:
                self.results_tree.delete(item)
                
    def is_running(self) -> bool:
        """Check if search is running"""
        return self.is_searching
        
    def cancel_operation(self):
        """Cancel current operation"""
        if self.is_searching:
            self.stop_search()
            
    def get_state(self) -> Dict[str, Any]:
        """Get current state"""
        return {
            "dorks": [self.dorks_listbox.get(i) for i in range(self.dorks_listbox.size())],
            "engines": {engine.value: var.get() for engine, var in self.engine_vars.items()},
            "max_results": self.max_results_var.get(),
            "delay": self.delay_var.get(),
            "filter": self.filter_var.get(),
            "dedup": self.dedup_var.get(),
            "proxy": self.proxy_var.get()
        }
        
    def set_state(self, state: Dict[str, Any]):
        """Set state"""
        if "dorks" in state:
            self.dorks_listbox.delete(0, tk.END)
            for dork in state["dorks"]:
                self.dorks_listbox.insert(tk.END, dork)
                
        if "engines" in state:
            for engine, var in self.engine_vars.items():
                if engine.value in state["engines"]:
                    var.set(state["engines"][engine.value])
                    
        if "max_results" in state:
            self.max_results_var.set(state["max_results"])
        if "delay" in state:
            self.delay_var.set(state["delay"])
        if "filter" in state:
            self.filter_var.set(state["filter"])
        if "dedup" in state:
            self.dedup_var.set(state["dedup"])
        if "proxy" in state:
            self.proxy_var.set(state["proxy"])
            
    def import_urls(self, urls: List[str]):
        """Import URLs (not applicable for dork page)"""
        pass