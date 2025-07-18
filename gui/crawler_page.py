"""
Web Crawler Page for BoomSQL
Web crawler interface with parameter extraction
"""

import tkinter as tk
from tkinter import ttk, messagebox, filedialog
import asyncio
import threading
from typing import List, Dict, Any, Optional
from pathlib import Path

from core.web_crawler import WebCrawler, CrawledUrl, Parameter

class CrawlerPage(ttk.Frame):
    """Web crawler page"""
    
    def __init__(self, parent, app):
        super().__init__(parent)
        self.app = app
        self.web_crawler = None
        self.crawl_results: List[CrawledUrl] = []
        self.is_crawling = False
        
        self.create_widgets()
        
    def create_widgets(self):
        """Create page widgets"""
        # Main container
        main_frame = ttk.Frame(self)
        main_frame.pack(fill=tk.BOTH, expand=True, padx=10, pady=10)
        
        # Left panel - Configuration
        left_frame = ttk.LabelFrame(main_frame, text="Crawler Configuration", padding=10)
        left_frame.pack(side=tk.LEFT, fill=tk.Y, padx=(0, 10))
        left_frame.configure(width=300)
        left_frame.pack_propagate(False)
        
        # Target URLs (multiple)
        ttk.Label(left_frame, text="Target URLs (one per line):").pack(anchor=tk.W)
        
        # URLs text area
        urls_frame = ttk.Frame(left_frame)
        urls_frame.pack(fill=tk.X, pady=(0, 5))
        
        self.urls_text = tk.Text(urls_frame, height=6, width=40)
        urls_scrollbar = ttk.Scrollbar(urls_frame, command=self.urls_text.yview)
        self.urls_text.config(yscrollcommand=urls_scrollbar.set)
        
        self.urls_text.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        urls_scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
        
        # URL management buttons
        url_buttons_frame = ttk.Frame(left_frame)
        url_buttons_frame.pack(fill=tk.X, pady=(5, 10))
        
        ttk.Button(url_buttons_frame, text="Load URLs", command=self.load_urls).pack(side=tk.LEFT, padx=(0, 5))
        ttk.Button(url_buttons_frame, text="Clear URLs", command=self.clear_urls).pack(side=tk.LEFT)
        
        # Crawl options
        options_frame = ttk.LabelFrame(left_frame, text="Crawl Options", padding=5)
        options_frame.pack(fill=tk.X, pady=(0, 10))
        
        # Max depth
        ttk.Label(options_frame, text="Max Depth:").pack(anchor=tk.W)
        self.depth_var = tk.StringVar(value="3")
        ttk.Entry(options_frame, textvariable=self.depth_var, width=10).pack(anchor=tk.W, pady=(0, 5))
        
        # Max URLs per domain
        ttk.Label(options_frame, text="Max URLs per domain:").pack(anchor=tk.W)
        self.max_urls_var = tk.StringVar(value="50")
        ttk.Entry(options_frame, textvariable=self.max_urls_var, width=10).pack(anchor=tk.W, pady=(0, 5))
        
        # Max parameters per domain (stop when found enough)
        ttk.Label(options_frame, text="Stop after finding parameters:").pack(anchor=tk.W)
        self.max_params_var = tk.StringVar(value="5")
        ttk.Entry(options_frame, textvariable=self.max_params_var, width=10).pack(anchor=tk.W, pady=(0, 5))
        
        # Request delay
        ttk.Label(options_frame, text="Request Delay (ms):").pack(anchor=tk.W)
        self.delay_var = tk.StringVar(value="1000")
        ttk.Entry(options_frame, textvariable=self.delay_var, width=10).pack(anchor=tk.W, pady=(0, 5))
        
        # Checkboxes
        self.follow_redirects_var = tk.BooleanVar(value=True)
        ttk.Checkbutton(options_frame, text="Follow Redirects", variable=self.follow_redirects_var).pack(anchor=tk.W)
        
        self.extract_params_var = tk.BooleanVar(value=True)
        ttk.Checkbutton(options_frame, text="Extract Parameters", variable=self.extract_params_var).pack(anchor=tk.W)
        
        self.extract_forms_var = tk.BooleanVar(value=True)
        ttk.Checkbutton(options_frame, text="Extract Forms", variable=self.extract_forms_var).pack(anchor=tk.W)
        
        self.extract_cookies_var = tk.BooleanVar(value=True)
        ttk.Checkbutton(options_frame, text="Extract Cookies", variable=self.extract_cookies_var).pack(anchor=tk.W)
        
        # Smart crawling option
        self.smart_crawl_var = tk.BooleanVar(value=True)
        ttk.Checkbutton(options_frame, text="Smart Stop (stop when parameters found)", variable=self.smart_crawl_var).pack(anchor=tk.W)
        
        # Control buttons
        control_frame = ttk.Frame(left_frame)
        control_frame.pack(fill=tk.X, pady=(0, 10))
        
        self.start_button = ttk.Button(control_frame, text="Start Crawl", command=self.start_crawl)
        self.start_button.pack(side=tk.LEFT, padx=(0, 5))
        
        self.stop_button = ttk.Button(control_frame, text="Stop", command=self.stop_crawl, state=tk.DISABLED)
        self.stop_button.pack(side=tk.LEFT, padx=(0, 5))
        
        self.clear_button = ttk.Button(control_frame, text="Clear Results", command=self.clear_results)
        self.clear_button.pack(side=tk.LEFT)
        
        # Right panel - Results
        right_frame = ttk.LabelFrame(main_frame, text="Crawl Results", padding=10)
        right_frame.pack(side=tk.RIGHT, fill=tk.BOTH, expand=True)
        
        # Notebook for different result views
        self.results_notebook = ttk.Notebook(right_frame)
        self.results_notebook.pack(fill=tk.BOTH, expand=True)
        
        # URLs tab
        self.create_urls_tab()
        
        # Parameters tab
        self.create_parameters_tab()
        
        # Forms tab
        self.create_forms_tab()
        
        # Progress frame
        progress_frame = ttk.Frame(right_frame)
        progress_frame.pack(fill=tk.X, pady=(10, 0))
        
        # Progress bar
        self.progress_var = tk.DoubleVar()
        self.progress_bar = ttk.Progressbar(
            progress_frame,
            variable=self.progress_var,
            maximum=100,
            length=400
        )
        self.progress_bar.pack(side=tk.LEFT, fill=tk.X, expand=True, padx=(0, 10))
        
        # Status
        self.status_var = tk.StringVar(value="Ready")
        ttk.Label(progress_frame, textvariable=self.status_var).pack(side=tk.RIGHT)
        
    def create_urls_tab(self):
        """Create URLs tab"""
        urls_frame = ttk.Frame(self.results_notebook)
        self.results_notebook.add(urls_frame, text="URLs")
        
        # Summary and action buttons
        summary_frame = ttk.Frame(urls_frame)
        summary_frame.pack(fill=tk.X, pady=(0, 10))
        
        self.urls_summary_var = tk.StringVar(value="No URLs crawled yet")
        ttk.Label(summary_frame, textvariable=self.urls_summary_var).pack(side=tk.LEFT)
        
        # Action buttons
        button_frame = ttk.Frame(summary_frame)
        button_frame.pack(side=tk.RIGHT)
        
        ttk.Button(button_frame, text="Send to Tester", command=self.send_to_tester).pack(side=tk.RIGHT, padx=(5, 0))
        ttk.Button(button_frame, text="Export URLs", command=self.export_urls).pack(side=tk.RIGHT)
        
        # URLs treeview
        columns = ("URL", "Title", "Status", "Depth", "Parameters", "Forms")
        self.urls_tree = ttk.Treeview(urls_frame, columns=columns, show="headings")
        
        for col in columns:
            self.urls_tree.heading(col, text=col)
            
        self.urls_tree.column("URL", width=300)
        self.urls_tree.column("Title", width=200)
        self.urls_tree.column("Status", width=80)
        self.urls_tree.column("Depth", width=60)
        self.urls_tree.column("Parameters", width=90)
        self.urls_tree.column("Forms", width=60)
        
        # Scrollbar
        urls_scrollbar = ttk.Scrollbar(urls_frame, orient=tk.VERTICAL, command=self.urls_tree.yview)
        self.urls_tree.configure(yscrollcommand=urls_scrollbar.set)
        
        self.urls_tree.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        urls_scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
        
        # Bind events
        self.urls_tree.bind("<Double-1>", self.on_url_double_click)
        
    def create_parameters_tab(self):
        """Create parameters tab"""
        params_frame = ttk.Frame(self.results_notebook)
        self.results_notebook.add(params_frame, text="Parameters")
        
        # Summary
        summary_frame = ttk.Frame(params_frame)
        summary_frame.pack(fill=tk.X, pady=(0, 10))
        
        self.params_summary_var = tk.StringVar(value="No parameters found yet")
        ttk.Label(summary_frame, textvariable=self.params_summary_var).pack(side=tk.LEFT)
        
        ttk.Button(summary_frame, text="Send to Tester", command=self.send_params_to_tester).pack(side=tk.RIGHT, padx=(5, 0))
        ttk.Button(summary_frame, text="Export Parameters", command=self.export_parameters).pack(side=tk.RIGHT)
        
        # Parameters treeview
        columns = ("Parameter", "Value", "Type", "Source URL", "Method", "Required")
        self.params_tree = ttk.Treeview(params_frame, columns=columns, show="headings")
        
        for col in columns:
            self.params_tree.heading(col, text=col)
            
        self.params_tree.column("Parameter", width=150)
        self.params_tree.column("Value", width=150)
        self.params_tree.column("Type", width=80)
        self.params_tree.column("Source URL", width=250)
        self.params_tree.column("Method", width=70)
        self.params_tree.column("Required", width=70)
        
        # Scrollbar
        params_scrollbar = ttk.Scrollbar(params_frame, orient=tk.VERTICAL, command=self.params_tree.yview)
        self.params_tree.configure(yscrollcommand=params_scrollbar.set)
        
        self.params_tree.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        params_scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
        
    def create_forms_tab(self):
        """Create forms tab"""
        forms_frame = ttk.Frame(self.results_notebook)
        self.results_notebook.add(forms_frame, text="Forms")
        
        # Summary
        summary_frame = ttk.Frame(forms_frame)
        summary_frame.pack(fill=tk.X, pady=(0, 10))
        
        self.forms_summary_var = tk.StringVar(value="No forms found yet")
        ttk.Label(summary_frame, textvariable=self.forms_summary_var).pack(side=tk.LEFT)
        
        ttk.Button(summary_frame, text="Export Forms", command=self.export_forms).pack(side=tk.RIGHT)
        
        # Forms treeview
        columns = ("Action", "Method", "Inputs", "Source URL")
        self.forms_tree = ttk.Treeview(forms_frame, columns=columns, show="headings")
        
        for col in columns:
            self.forms_tree.heading(col, text=col)
            
        self.forms_tree.column("Action", width=250)
        self.forms_tree.column("Method", width=80)
        self.forms_tree.column("Inputs", width=80)
        self.forms_tree.column("Source URL", width=250)
        
        # Scrollbar
        forms_scrollbar = ttk.Scrollbar(forms_frame, orient=tk.VERTICAL, command=self.forms_tree.yview)
        self.forms_tree.configure(yscrollcommand=forms_scrollbar.set)
        
        self.forms_tree.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        forms_scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
        
    def load_urls(self):
        """Load URLs from file"""
        file_path = filedialog.askopenfilename(
            title="Load URLs",
            filetypes=[("Text files", "*.txt"), ("All files", "*.*")]
        )
        
        if file_path:
            try:
                with open(file_path, 'r') as f:
                    urls = f.read()
                self.urls_text.delete(1.0, tk.END)
                self.urls_text.insert(1.0, urls)
            except Exception as e:
                messagebox.showerror("Error", f"Failed to load URLs:\n{str(e)}")
    
    def clear_urls(self):
        """Clear URL list"""
        self.urls_text.delete(1.0, tk.END)
    
    def get_target_urls(self):
        """Get list of target URLs"""
        urls_text = self.urls_text.get(1.0, tk.END).strip()
        if not urls_text:
            return []
        
        urls = []
        for line in urls_text.split('\n'):
            url = line.strip()
            if url:
                if not url.startswith(('http://', 'https://')):
                    url = 'http://' + url
                urls.append(url)
        
        return urls

    def start_crawl(self):
        """Start web crawl"""
        urls = self.get_target_urls()
        if not urls:
            messagebox.showwarning("Warning", "Please enter target URLs")
            return
            
        # Update UI
        self.is_crawling = True
        self.start_button.config(state=tk.DISABLED)
        self.stop_button.config(state=tk.NORMAL)
        self.progress_var.set(0)
        self.status_var.set("Starting crawl...")
        
        # Clear previous results
        self.crawl_results.clear()
        self.clear_displays()
        
        # Start crawl in background
        self.crawl_thread = threading.Thread(target=self.run_smart_crawl, args=(urls,))
        self.crawl_thread.daemon = True
        self.crawl_thread.start()
        
    def run_smart_crawl(self, urls: List[str]):
        """Run smart crawl for multiple URLs"""
        try:
            all_results = []
            total_urls = len(urls)
            
            for i, url in enumerate(urls):
                if not self.is_crawling:  # Check if stopped
                    break
                
                # Update status
                self.after(0, lambda u=url, idx=i+1, total=total_urls: 
                          self.status_var.set(f"Crawling {idx}/{total}: {u}"))
                
                # Create config for this domain
                config = {
                    "MaxDepth": int(self.depth_var.get()),
                    "MaxUrls": int(self.max_urls_var.get()),
                    "RequestDelay": int(self.delay_var.get()),
                    "FollowRedirects": self.follow_redirects_var.get(),
                    "EnableParameterExtraction": self.extract_params_var.get(),
                    "EnableFormDetection": self.extract_forms_var.get(),
                    "EnableCookieExtraction": self.extract_cookies_var.get(),
                    "RequestTimeout": 30,
                    "UserAgent": "BoomSQL/2.0 Web Crawler",
                    "SmartStop": self.smart_crawl_var.get(),
                    "MaxParametersPerDomain": int(self.max_params_var.get())
                }
                
                # Create crawler for this domain
                self.web_crawler = WebCrawler(config)
                
                # Run crawl for this URL
                loop = asyncio.new_event_loop()
                asyncio.set_event_loop(loop)
                
                try:
                    results = loop.run_until_complete(
                        self.web_crawler.crawl_smart(url, self.crawl_progress_callback)
                    )
                    
                    # Add results
                    all_results.extend(results)
                    
                    # Update progress
                    progress = ((i + 1) / total_urls) * 100
                    self.after(0, lambda p=progress: self.progress_var.set(p))
                    
                    # Check if we found enough parameters and smart stop is enabled
                    if self.smart_crawl_var.get():
                        param_count = sum(len(r.parameters) for r in results)
                        if param_count >= int(self.max_params_var.get()):
                            self.after(0, lambda: self.status_var.set(
                                f"Found {param_count} parameters for {url}, stopping..."))
                    
                finally:
                    loop.close()
                
            # Update final results
            self.crawl_results = all_results
            self.update_results_display()
                
        except Exception as e:
            self.after(0, lambda: messagebox.showerror("Error", f"Crawl failed:\n{str(e)}"))
            
        finally:
            # Update UI
            self.after(0, self.crawl_completed)
            
    def crawl_progress_callback(self, message: str):
        """Crawl progress callback"""
        self.after(0, lambda: self.status_var.set(message))
        
        # Update progress
        if self.web_crawler and self.web_crawler.progress:
            progress = self.web_crawler.progress.progress_percentage
            self.after(0, lambda: self.progress_var.set(progress))
            
    def crawl_completed(self):
        """Crawl completed"""
        self.is_crawling = False
        self.start_button.config(state=tk.NORMAL)
        self.stop_button.config(state=tk.DISABLED)
        self.progress_var.set(100)
        self.status_var.set("Crawl completed")
        
    def stop_crawl(self):
        """Stop crawl"""
        if self.web_crawler:
            self.web_crawler.cancel_crawl()
            
    def update_results_display(self):
        """Update results display"""
        self.after(0, self._update_results_display)
        
    def _update_results_display(self):
        """Update results display (main thread)"""
        # Update URLs
        self.urls_tree.delete(*self.urls_tree.get_children())
        for url in self.crawl_results:
            self.urls_tree.insert("", tk.END, values=(
                url.url,
                url.title[:50] + "..." if len(url.title) > 50 else url.title,
                url.status_code,
                url.depth,
                len(url.parameters),
                len(url.forms)
            ))
            
        # Update parameters
        self.params_tree.delete(*self.params_tree.get_children())
        all_params = []
        for url in self.crawl_results:
            all_params.extend(url.parameters)
            
        for param in all_params:
            self.params_tree.insert("", tk.END, values=(
                param.name,
                param.value[:30] + "..." if len(param.value) > 30 else param.value,
                param.type.value,
                param.source_url,
                param.method,
                "Yes" if param.required else "No"
            ))
            
        # Update forms
        self.forms_tree.delete(*self.forms_tree.get_children())
        all_forms = []
        for url in self.crawl_results:
            for form in url.forms:
                form['source_url'] = url.url
                all_forms.append(form)
                
        for form in all_forms:
            self.forms_tree.insert("", tk.END, values=(
                form.get('action', ''),
                form.get('method', ''),
                len(form.get('inputs', {})),
                form.get('source_url', '')
            ))
            
        # Update summaries
        self.urls_summary_var.set(f"Found {len(self.crawl_results)} URLs")
        self.params_summary_var.set(f"Found {len(all_params)} parameters")
        self.forms_summary_var.set(f"Found {len(all_forms)} forms")
        
    def clear_displays(self):
        """Clear all displays"""
        self.urls_tree.delete(*self.urls_tree.get_children())
        self.params_tree.delete(*self.params_tree.get_children())
        self.forms_tree.delete(*self.forms_tree.get_children())
        
    def clear_results(self):
        """Clear crawl results"""
        self.crawl_results.clear()
        self.clear_displays()
        self.urls_summary_var.set("No URLs crawled yet")
        self.params_summary_var.set("No parameters found yet")
        self.forms_summary_var.set("No forms found yet")
        self.progress_var.set(0)
        self.status_var.set("Ready")
        
    def export_urls(self):
        """Export URLs"""
        if not self.crawl_results:
            messagebox.showwarning("Warning", "No URLs to export")
            return
            
        file_path = filedialog.asksaveasfilename(
            title="Export URLs",
            defaultextension=".json",
            filetypes=[
                ("JSON files", "*.json"),
                ("CSV files", "*.csv"),
                ("HTML files", "*.html")
            ]
        )
        
        if file_path:
            try:
                format_type = Path(file_path).suffix.lower()[1:]
                self.web_crawler.export_results(format_type, file_path)
                messagebox.showinfo("Success", f"URLs exported to {file_path}")
            except Exception as e:
                messagebox.showerror("Error", f"Failed to export URLs:\n{str(e)}")
                
    def export_parameters(self):
        """Export parameters"""
        messagebox.showinfo("Info", "Parameter export functionality will be implemented")
        
    def export_forms(self):
        """Export forms"""
        messagebox.showinfo("Info", "Form export functionality will be implemented")
        
    def send_params_to_tester(self):
        """Send parameters to tester"""
        if not self.crawl_results:
            messagebox.showwarning("Warning", "No parameters to send")
            return
            
        # Collect injection candidates
        candidates = []
        for url in self.crawl_results:
            for param in url.parameters:
                candidates.append({
                    'url': url.url,
                    'parameter': param.name,
                    'value': param.value,
                    'type': param.type.value,
                    'method': param.method
                })
                
        if candidates:
            # Get tester page
            tester_page = self.app.main_window.tester_page
            if tester_page:
                tester_page.import_candidates(candidates)
                messagebox.showinfo("Success", f"Sent {len(candidates)} injection candidates to tester")
            else:
                messagebox.showerror("Error", "Tester page not available")
        else:
            messagebox.showwarning("Warning", "No injection candidates found")
            
    def on_url_double_click(self, event):
        """Handle URL double-click"""
        selection = self.urls_tree.selection()
        if selection:
            item = selection[0]
            url = self.urls_tree.item(item, "values")[0]
            
            import webbrowser
            webbrowser.open(url)
            
    def is_running(self) -> bool:
        """Check if crawl is running"""
        return self.is_crawling
        
    def cancel_operation(self):
        """Cancel current operation"""
        if self.is_crawling:
            self.stop_crawl()
            
    def get_state(self) -> Dict[str, Any]:
        """Get current state"""
        return {
            "url": self.url_var.get(),
            "depth": self.depth_var.get(),
            "max_urls": self.max_urls_var.get(),
            "delay": self.delay_var.get(),
            "follow_redirects": self.follow_redirects_var.get(),
            "extract_params": self.extract_params_var.get(),
            "extract_forms": self.extract_forms_var.get(),
            "extract_cookies": self.extract_cookies_var.get()
        }
        
    def set_state(self, state: Dict[str, Any]):
        """Set state"""
        if "url" in state:
            self.url_var.set(state["url"])
        if "depth" in state:
            self.depth_var.set(state["depth"])
        if "max_urls" in state:
            self.max_urls_var.set(state["max_urls"])
        if "delay" in state:
            self.delay_var.set(state["delay"])
        if "follow_redirects" in state:
            self.follow_redirects_var.set(state["follow_redirects"])
        if "extract_params" in state:
            self.extract_params_var.set(state["extract_params"])
        if "extract_forms" in state:
            self.extract_forms_var.set(state["extract_forms"])
        if "extract_cookies" in state:
            self.extract_cookies_var.set(state["extract_cookies"])
            
    def send_to_tester(self):
        """Send crawled URLs with parameters to SQL tester"""
        if not self.crawl_results:
            messagebox.showwarning("Warning", "No crawl results to send")
            return
        
        # Filter URLs with parameters
        urls_with_params = []
        for result in self.crawl_results:
            if result.parameters:
                urls_with_params.append(result.url)
        
        if not urls_with_params:
            messagebox.showwarning("Warning", "No URLs with parameters found")
            return
        
        # Get the SQL tester page
        try:
            main_window = self.app.main_window
            if hasattr(main_window, 'tester_page'):
                # Send URLs to tester
                main_window.tester_page.import_urls(urls_with_params)
                
                # Switch to tester tab
                for i, tab_text in enumerate([main_window.notebook.tab(i, "text") for i in range(main_window.notebook.index("end"))]):
                    if "Tester" in tab_text:
                        main_window.notebook.select(i)
                        break
                
                messagebox.showinfo("Success", f"Sent {len(urls_with_params)} URLs with parameters to SQL Tester")
            else:
                messagebox.showerror("Error", "SQL Tester not available")
        except Exception as e:
            messagebox.showerror("Error", f"Failed to send to tester:\n{str(e)}")
    
    def import_urls(self, urls: List[str]):
        """Import URLs to crawl"""
        if urls:
            # Clear existing URLs and add new ones
            self.urls_text.delete(1.0, tk.END)
            self.urls_text.insert(1.0, '\n'.join(urls))
                
    def export_results(self):
        """Export current results"""
        self.export_urls()