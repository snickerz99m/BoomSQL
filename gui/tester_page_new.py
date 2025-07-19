"""
Completely Redesigned SQL Injection Tester Page for BoomSQL
Clean, modern GUI with guaranteed button visibility
"""

import tkinter as tk
from tkinter import ttk, messagebox, filedialog
import asyncio
import threading
from typing import List, Dict, Any, Optional
from pathlib import Path

from core.sql_injection_engine import SqlInjectionEngine, TestResult, VulnerabilityResult

class TesterPageNew(ttk.Frame):
    """Redesigned SQL injection tester page with better layout"""
    
    def __init__(self, parent, app):
        super().__init__(parent)
        self.app = app
        self.sql_engine = None
        self.test_results: List[TestResult] = []
        self.vulnerability_results: List[VulnerabilityResult] = []
        self.is_testing = False
        
        self.create_widgets()
        
    def create_widgets(self):
        """Create redesigned page widgets with guaranteed button visibility"""
        
        # Configure main frame
        self.configure(padding="10")
        
        # Create main container with grid layout
        self.grid_columnconfigure(0, weight=1)
        self.grid_columnconfigure(1, weight=2)
        self.grid_rowconfigure(0, weight=1)
        
        # Left panel - Controls (fixed width, proper layout)
        self.create_left_panel()
        
        # Right panel - Results (expandable)
        self.create_right_panel()
        
    def create_left_panel(self):
        """Create left control panel with guaranteed button visibility"""
        
        # Left panel container
        left_container = ttk.Frame(self)
        left_container.grid(row=0, column=0, sticky="nsew", padx=(0, 10))
        left_container.grid_rowconfigure(4, weight=1)  # Make control section expand if needed
        
        # 1. URL Management Section
        url_frame = ttk.LabelFrame(left_container, text="Target URLs", padding="10")
        url_frame.grid(row=0, column=0, sticky="ew", pady=(0, 10))
        url_frame.grid_columnconfigure(0, weight=1)
        
        # URL input
        input_frame = ttk.Frame(url_frame)
        input_frame.grid(row=0, column=0, sticky="ew", pady=(0, 5))
        input_frame.grid_columnconfigure(0, weight=1)
        
        self.url_entry = ttk.Entry(input_frame, placeholder_text="Enter URL to test...")
        self.url_entry.grid(row=0, column=0, sticky="ew", padx=(0, 5))
        
        add_url_btn = ttk.Button(input_frame, text="Add", command=self.add_url, width=8)
        add_url_btn.grid(row=0, column=1)
        
        # URL list
        list_frame = ttk.Frame(url_frame)
        list_frame.grid(row=1, column=0, sticky="ew", pady=(5, 0))
        list_frame.grid_columnconfigure(0, weight=1)
        
        # URL listbox with scrollbar
        url_scroll = ttk.Scrollbar(list_frame)
        url_scroll.grid(row=0, column=1, sticky="ns")
        
        self.urls_listbox = tk.Listbox(list_frame, yscrollcommand=url_scroll.set, height=4)
        self.urls_listbox.grid(row=0, column=0, sticky="ew")
        url_scroll.config(command=self.urls_listbox.yview)
        
        # URL management buttons
        url_btn_frame = ttk.Frame(url_frame)
        url_btn_frame.grid(row=2, column=0, sticky="ew", pady=(5, 0))
        
        ttk.Button(url_btn_frame, text="Remove", command=self.remove_url).pack(side=tk.LEFT, padx=(0, 5))
        ttk.Button(url_btn_frame, text="Load File", command=self.load_urls_from_file).pack(side=tk.LEFT, padx=(0, 5))
        ttk.Button(url_btn_frame, text="Clear All", command=self.clear_urls).pack(side=tk.LEFT)
        
        # 2. Testing Options Section
        options_frame = ttk.LabelFrame(left_container, text="Testing Options", padding="10")
        options_frame.grid(row=1, column=0, sticky="ew", pady=(0, 10))
        options_frame.grid_columnconfigure(1, weight=1)
        
        # Create a grid for options
        row = 0
        
        # Threads
        ttk.Label(options_frame, text="Threads:").grid(row=row, column=0, sticky="w", pady=2)
        self.threads_var = tk.StringVar(value="3")
        ttk.Entry(options_frame, textvariable=self.threads_var, width=10).grid(row=row, column=1, sticky="w", padx=(10, 0), pady=2)
        row += 1
        
        # Timeout
        ttk.Label(options_frame, text="Timeout (s):").grid(row=row, column=0, sticky="w", pady=2)
        self.timeout_var = tk.StringVar(value="30")
        ttk.Entry(options_frame, textvariable=self.timeout_var, width=10).grid(row=row, column=1, sticky="w", padx=(10, 0), pady=2)
        row += 1
        
        # Max payloads
        ttk.Label(options_frame, text="Max Payloads:").grid(row=row, column=0, sticky="w", pady=2)
        self.max_payloads_var = tk.StringVar(value="50")
        ttk.Entry(options_frame, textvariable=self.max_payloads_var, width=10).grid(row=row, column=1, sticky="w", padx=(10, 0), pady=2)
        row += 1
        
        # Checkboxes
        self.waf_bypass_var = tk.BooleanVar(value=True)
        ttk.Checkbutton(options_frame, text="WAF Bypass", variable=self.waf_bypass_var).grid(row=row, column=0, columnspan=2, sticky="w", pady=2)
        row += 1
        
        self.ssl_verify_var = tk.BooleanVar(value=False)
        ttk.Checkbutton(options_frame, text="SSL Verify", variable=self.ssl_verify_var).grid(row=row, column=0, columnspan=2, sticky="w", pady=2)
        
        # 3. Smart Testing Section
        smart_frame = ttk.LabelFrame(left_container, text="Smart Testing", padding="10")
        smart_frame.grid(row=2, column=0, sticky="ew", pady=(0, 10))
        smart_frame.grid_columnconfigure(1, weight=1)
        
        row = 0
        ttk.Label(smart_frame, text="Max per domain:").grid(row=row, column=0, sticky="w", pady=2)
        self.max_vulns_per_domain_var = tk.StringVar(value="3")
        ttk.Entry(smart_frame, textvariable=self.max_vulns_per_domain_var, width=10).grid(row=row, column=1, sticky="w", padx=(10, 0), pady=2)
        row += 1
        
        self.stop_after_vuln_var = tk.BooleanVar(value=True)
        ttk.Checkbutton(smart_frame, text="Stop after finding vulnerability", variable=self.stop_after_vuln_var).grid(row=row, column=0, columnspan=2, sticky="w", pady=2)
        
        # 4. Workflow Instructions
        workflow_frame = ttk.LabelFrame(left_container, text="Workflow", padding="10")
        workflow_frame.grid(row=3, column=0, sticky="ew", pady=(0, 10))
        
        workflow_text = tk.Text(workflow_frame, height=4, wrap=tk.WORD, state=tk.DISABLED, 
                               bg='#f8f9fa', relief=tk.FLAT, font=('Arial', 9))
        workflow_instructions = """1. Add URLs to test above
2. Click 'START TESTING' below
3. View results in the right panel
4. Send vulnerabilities to Database Dumper"""
        workflow_text.config(state=tk.NORMAL)
        workflow_text.insert(tk.END, workflow_instructions)
        workflow_text.config(state=tk.DISABLED)
        workflow_text.pack(fill=tk.BOTH, expand=True)
        
        # 5. MAIN CONTROL BUTTONS (GUARANTEED VISIBLE)
        self.create_control_buttons(left_container)
        
    def create_control_buttons(self, parent):
        """Create main control buttons with guaranteed visibility"""
        
        # Control buttons frame - this is the most important part!
        control_frame = ttk.LabelFrame(parent, text="Controls", padding="15")
        control_frame.grid(row=4, column=0, sticky="ew", pady=(0, 10))
        control_frame.grid_columnconfigure(0, weight=1)
        
        # Create button container with proper spacing
        button_container = ttk.Frame(control_frame)
        button_container.grid(row=0, column=0, sticky="ew")
        button_container.grid_columnconfigure(0, weight=1)
        button_container.grid_columnconfigure(1, weight=1)
        button_container.grid_columnconfigure(2, weight=1)
        
        # START BUTTON - Large and prominent
        self.start_button = ttk.Button(
            button_container, 
            text="🚀 START TESTING", 
            command=self.start_testing,
            width=15,
            style="Accent.TButton"
        )
        self.start_button.grid(row=0, column=0, padx=5, pady=5, sticky="ew")
        
        # STOP BUTTON - Large and prominent
        self.stop_button = ttk.Button(
            button_container, 
            text="🛑 STOP", 
            command=self.stop_testing,
            width=15,
            state=tk.DISABLED
        )
        self.stop_button.grid(row=0, column=1, padx=5, pady=5, sticky="ew")
        
        # CLEAR BUTTON
        self.clear_button = ttk.Button(
            button_container, 
            text="🗑️ CLEAR", 
            command=self.clear_results,
            width=15
        )
        self.clear_button.grid(row=0, column=2, padx=5, pady=5, sticky="ew")
        
        # Status indicator
        status_frame = ttk.Frame(control_frame)
        status_frame.grid(row=1, column=0, sticky="ew", pady=(10, 0))
        
        ttk.Label(status_frame, text="Status:").pack(side=tk.LEFT)
        self.status_label = ttk.Label(status_frame, text="Ready", foreground="green")
        self.status_label.pack(side=tk.LEFT, padx=(5, 0))
        
        # Progress bar
        self.progress_bar = ttk.Progressbar(control_frame, mode='indeterminate')
        self.progress_bar.grid(row=2, column=0, sticky="ew", pady=(10, 0))
        
        # Send to Dumper button (secondary action)
        dumper_frame = ttk.Frame(control_frame)
        dumper_frame.grid(row=3, column=0, sticky="ew", pady=(10, 0))
        
        self.send_to_dumper_button = ttk.Button(
            dumper_frame, 
            text="📤 Send to Database Dumper", 
            command=self.send_to_dumper,
            state=tk.DISABLED
        )
        self.send_to_dumper_button.pack(fill=tk.X)
        
    def create_right_panel(self):
        """Create right results panel"""
        
        # Right panel container
        right_container = ttk.LabelFrame(self, text="Test Results", padding="10")
        right_container.grid(row=0, column=1, sticky="nsew")
        right_container.grid_rowconfigure(0, weight=1)
        right_container.grid_columnconfigure(0, weight=1)
        
        # Results notebook
        self.results_notebook = ttk.Notebook(right_container)
        self.results_notebook.grid(row=0, column=0, sticky="nsew")
        
        # Create result tabs
        self.create_vulnerabilities_tab()
        self.create_statistics_tab()
        self.create_logs_tab()
        
    def create_vulnerabilities_tab(self):
        """Create vulnerabilities results tab"""
        
        # Vulnerabilities tab
        vuln_frame = ttk.Frame(self.results_notebook)
        self.results_notebook.add(vuln_frame, text="Vulnerabilities")
        
        vuln_frame.grid_rowconfigure(0, weight=1)
        vuln_frame.grid_columnconfigure(0, weight=1)
        
        # Vulnerabilities treeview
        columns = ("URL", "Parameter", "Technique", "Risk", "Payload")
        self.vuln_tree = ttk.Treeview(vuln_frame, columns=columns, show="headings", height=15)
        
        # Configure columns
        self.vuln_tree.heading("URL", text="URL")
        self.vuln_tree.heading("Parameter", text="Parameter")
        self.vuln_tree.heading("Technique", text="Technique")
        self.vuln_tree.heading("Risk", text="Risk")
        self.vuln_tree.heading("Payload", text="Payload")
        
        # Column widths
        self.vuln_tree.column("URL", width=200)
        self.vuln_tree.column("Parameter", width=100)
        self.vuln_tree.column("Technique", width=100)
        self.vuln_tree.column("Risk", width=80)
        self.vuln_tree.column("Payload", width=150)
        
        # Scrollbars
        vuln_scroll_y = ttk.Scrollbar(vuln_frame, orient=tk.VERTICAL, command=self.vuln_tree.yview)
        vuln_scroll_x = ttk.Scrollbar(vuln_frame, orient=tk.HORIZONTAL, command=self.vuln_tree.xview)
        self.vuln_tree.configure(yscrollcommand=vuln_scroll_y.set, xscrollcommand=vuln_scroll_x.set)
        
        # Grid layout
        self.vuln_tree.grid(row=0, column=0, sticky="nsew")
        vuln_scroll_y.grid(row=0, column=1, sticky="ns")
        vuln_scroll_x.grid(row=1, column=0, sticky="ew")
        
    def create_statistics_tab(self):
        """Create statistics tab"""
        
        stats_frame = ttk.Frame(self.results_notebook)
        self.results_notebook.add(stats_frame, text="Statistics")
        
        # Statistics display
        self.stats_text = tk.Text(stats_frame, wrap=tk.WORD, state=tk.DISABLED)
        stats_scroll = ttk.Scrollbar(stats_frame, orient=tk.VERTICAL, command=self.stats_text.yview)
        self.stats_text.configure(yscrollcommand=stats_scroll.set)
        
        self.stats_text.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        stats_scroll.pack(side=tk.RIGHT, fill=tk.Y)
        
    def create_logs_tab(self):
        """Create logs tab"""
        
        logs_frame = ttk.Frame(self.results_notebook)
        self.results_notebook.add(logs_frame, text="Logs")
        
        # Logs display
        self.logs_text = tk.Text(logs_frame, wrap=tk.WORD, state=tk.DISABLED)
        logs_scroll = ttk.Scrollbar(logs_frame, orient=tk.VERTICAL, command=self.logs_text.yview)
        self.logs_text.configure(yscrollcommand=logs_scroll.set)
        
        self.logs_text.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        logs_scroll.pack(side=tk.RIGHT, fill=tk.Y)
        
    # URL Management Methods
    def add_url(self):
        """Add URL to test list"""
        url = self.url_entry.get().strip()
        if url:
            if not url.startswith(('http://', 'https://')):
                url = 'http://' + url
            self.urls_listbox.insert(tk.END, url)
            self.url_entry.delete(0, tk.END)
            self.log_message(f"Added URL: {url}")
        
    def remove_url(self):
        """Remove selected URL"""
        selection = self.urls_listbox.curselection()
        if selection:
            url = self.urls_listbox.get(selection[0])
            self.urls_listbox.delete(selection[0])
            self.log_message(f"Removed URL: {url}")
        
    def clear_urls(self):
        """Clear all URLs"""
        self.urls_listbox.delete(0, tk.END)
        self.log_message("Cleared all URLs")
        
    def load_urls_from_file(self):
        """Load URLs from file"""
        file_path = filedialog.askopenfilename(
            title="Select URL file",
            filetypes=[("Text files", "*.txt"), ("All files", "*.*")]
        )
        if file_path:
            try:
                with open(file_path, 'r') as f:
                    urls = [line.strip() for line in f if line.strip()]
                for url in urls:
                    if not url.startswith(('http://', 'https://')):
                        url = 'http://' + url
                    self.urls_listbox.insert(tk.END, url)
                self.log_message(f"Loaded {len(urls)} URLs from file")
            except Exception as e:
                messagebox.showerror("Error", f"Failed to load URLs: {str(e)}")
        
    # Testing Methods
    def start_testing(self):
        """Start SQL injection testing"""
        urls = [self.urls_listbox.get(i) for i in range(self.urls_listbox.size())]
        if not urls:
            messagebox.showwarning("Warning", "Please add URLs to test")
            return
            
        self.is_testing = True
        self.start_button.config(state=tk.DISABLED)
        self.stop_button.config(state=tk.NORMAL)
        self.status_label.config(text="Testing...", foreground="orange")
        self.progress_bar.start()
        
        # Start testing in background thread
        thread = threading.Thread(target=self._run_testing_async, args=(urls,))
        thread.daemon = True
        thread.start()
        
        self.log_message(f"Started testing {len(urls)} URLs")
        
    def _run_testing_async(self, urls):
        """Run testing in async loop"""
        try:
            # Create new event loop for this thread
            loop = asyncio.new_event_loop()
            asyncio.set_event_loop(loop)
            loop.run_until_complete(self._test_urls(urls))
        except Exception as e:
            self.after(0, lambda: self.log_message(f"Testing error: {str(e)}"))
        finally:
            self.after(0, self._testing_completed)
            
    async def _test_urls(self, urls):
        """Async testing method"""
        config = self._get_test_config()
        self.sql_engine = SqlInjectionEngine(config)
        
        for i, url in enumerate(urls):
            if not self.is_testing:
                break
                
            self.after(0, lambda u=url: self.log_message(f"Testing: {u}"))
            
            try:
                # Test the URL
                result = await self.sql_engine.test_url(url)
                if result.vulnerabilities:
                    self.after(0, lambda r=result: self._process_test_result(r))
                    
                    if self.stop_after_vuln_var.get():
                        break
                        
            except Exception as e:
                self.after(0, lambda u=url, e=e: self.log_message(f"Error testing {u}: {str(e)}"))
        
        await self.sql_engine.close()
        
    def _process_test_result(self, result: TestResult):
        """Process test result"""
        self.test_results.append(result)
        
        for vuln in result.vulnerabilities:
            self.vulnerability_results.append(vuln)
            
            # Add to vulnerabilities tree
            self.vuln_tree.insert("", "end", values=(
                vuln.url,
                vuln.injection_point.name if vuln.injection_point else "Unknown",
                vuln.technique.name if vuln.technique else "Unknown",
                vuln.risk_level.name if vuln.risk_level else "Unknown",
                vuln.injection_point.payload[:50] + "..." if vuln.injection_point and len(vuln.injection_point.payload) > 50 else (vuln.injection_point.payload if vuln.injection_point else "")
            ))
            
        self.log_message(f"Found {len(result.vulnerabilities)} vulnerabilities in {result.url}")
        self._update_statistics()
        
        # Enable send to dumper if we have vulnerabilities
        if self.vulnerability_results:
            self.send_to_dumper_button.config(state=tk.NORMAL)
        
    def stop_testing(self):
        """Stop testing"""
        self.is_testing = False
        self.log_message("Stopping tests...")
        
    def _testing_completed(self):
        """Called when testing is completed"""
        self.is_testing = False
        self.start_button.config(state=tk.NORMAL)
        self.stop_button.config(state=tk.DISABLED)
        self.status_label.config(text="Ready", foreground="green")
        self.progress_bar.stop()
        
        total_vulns = len(self.vulnerability_results)
        if total_vulns > 0:
            self.status_label.config(text=f"Found {total_vulns} vulnerabilities", foreground="red")
        
        self.log_message("Testing completed")
        
    def clear_results(self):
        """Clear all results"""
        self.test_results.clear()
        self.vulnerability_results.clear()
        
        # Clear treeview
        for item in self.vuln_tree.get_children():
            self.vuln_tree.delete(item)
            
        # Clear logs
        self.logs_text.config(state=tk.NORMAL)
        self.logs_text.delete(1.0, tk.END)
        self.logs_text.config(state=tk.DISABLED)
        
        # Clear stats
        self.stats_text.config(state=tk.NORMAL)
        self.stats_text.delete(1.0, tk.END)
        self.stats_text.config(state=tk.DISABLED)
        
        self.send_to_dumper_button.config(state=tk.DISABLED)
        self.status_label.config(text="Ready", foreground="green")
        self.log_message("Cleared all results")
        
    def send_to_dumper(self):
        """Send vulnerabilities to database dumper"""
        if not self.vulnerability_results:
            messagebox.showwarning("Warning", "No vulnerabilities to send")
            return
            
        # Switch to dumper tab and pass vulnerabilities
        try:
            # Get the main window and switch to dumper tab
            main_window = self.app
            if hasattr(main_window, 'notebook'):
                # Find dumper tab and switch to it
                for i in range(main_window.notebook.index("end")):
                    tab_text = main_window.notebook.tab(i, "text")
                    if "Dumper" in tab_text:
                        main_window.notebook.select(i)
                        break
                        
                # Set vulnerabilities in dumper page
                if hasattr(main_window, 'dumper_page'):
                    main_window.dumper_page.set_vulnerabilities(self.vulnerability_results)
                    self.log_message(f"Sent {len(self.vulnerability_results)} vulnerabilities to Database Dumper")
                    messagebox.showinfo("Success", f"Sent {len(self.vulnerability_results)} vulnerabilities to Database Dumper")
                    
        except Exception as e:
            self.log_message(f"Error sending to dumper: {str(e)}")
            messagebox.showerror("Error", f"Failed to send to dumper: {str(e)}")
        
    def _get_test_config(self):
        """Get testing configuration"""
        return {
            "MaxThreads": int(self.threads_var.get() or "3"),
            "RequestTimeout": int(self.timeout_var.get() or "30"),
            "MaxPayloadsPerURL": int(self.max_payloads_var.get() or "50"),
            "WAFBypassEnabled": self.waf_bypass_var.get(),
            "SSLVerify": self.ssl_verify_var.get(),
            "MaxVulnerabilitiesPerDomain": int(self.max_vulns_per_domain_var.get() or "3"),
            "StopAfterVulnerability": self.stop_after_vuln_var.get()
        }
        
    def _update_statistics(self):
        """Update statistics display"""
        total_tests = len(self.test_results)
        total_vulns = len(self.vulnerability_results)
        
        # Count by technique
        technique_counts = {}
        risk_counts = {}
        
        for vuln in self.vulnerability_results:
            technique = vuln.technique.name if vuln.technique else "Unknown"
            risk = vuln.risk_level.name if vuln.risk_level else "Unknown"
            
            technique_counts[technique] = technique_counts.get(technique, 0) + 1
            risk_counts[risk] = risk_counts.get(risk, 0) + 1
            
        stats = f"""Testing Statistics:
        
Total URLs Tested: {total_tests}
Total Vulnerabilities: {total_vulns}

Vulnerabilities by Technique:
"""
        for technique, count in technique_counts.items():
            stats += f"  {technique}: {count}\n"
            
        stats += "\nVulnerabilities by Risk Level:\n"
        for risk, count in risk_counts.items():
            stats += f"  {risk}: {count}\n"
            
        self.stats_text.config(state=tk.NORMAL)
        self.stats_text.delete(1.0, tk.END)
        self.stats_text.insert(tk.END, stats)
        self.stats_text.config(state=tk.DISABLED)
        
    def log_message(self, message):
        """Add message to logs"""
        import datetime
        timestamp = datetime.datetime.now().strftime("%H:%M:%S")
        log_entry = f"[{timestamp}] {message}\n"
        
        self.logs_text.config(state=tk.NORMAL)
        self.logs_text.insert(tk.END, log_entry)
        self.logs_text.see(tk.END)
        self.logs_text.config(state=tk.DISABLED)
