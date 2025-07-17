"""
SQL Injection Tester Page for BoomSQL
SQL injection testing interface
"""

import tkinter as tk
from tkinter import ttk, messagebox, filedialog
import asyncio
import threading
from typing import List, Dict, Any, Optional
from pathlib import Path

from core.sql_injection_engine import SqlInjectionEngine, TestResult, VulnerabilityResult

class TesterPage(ttk.Frame):
    """SQL injection tester page"""
    
    def __init__(self, parent, app):
        super().__init__(parent)
        self.app = app
        self.sql_engine = None
        self.test_results: List[TestResult] = []
        self.vulnerability_results: List[VulnerabilityResult] = []
        self.is_testing = False
        
        self.create_widgets()
        
    def create_widgets(self):
        """Create page widgets"""
        # Main container
        main_frame = ttk.Frame(self)
        main_frame.pack(fill=tk.BOTH, expand=True, padx=10, pady=10)
        
        # Left panel - Configuration
        left_frame = ttk.LabelFrame(main_frame, text="Testing Configuration", padding=10)
        left_frame.pack(side=tk.LEFT, fill=tk.Y, padx=(0, 10))
        left_frame.configure(width=350)
        left_frame.pack_propagate(False)
        
        # Targets section
        targets_frame = ttk.LabelFrame(left_frame, text="Target URLs", padding=5)
        targets_frame.pack(fill=tk.BOTH, expand=True, pady=(0, 10))
        
        # URLs listbox with scrollbar
        urls_list_frame = ttk.Frame(targets_frame)
        urls_list_frame.pack(fill=tk.BOTH, expand=True)
        
        urls_scrollbar = ttk.Scrollbar(urls_list_frame)
        urls_scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
        
        self.urls_listbox = tk.Listbox(
            urls_list_frame,
            yscrollcommand=urls_scrollbar.set,
            selectmode=tk.EXTENDED,
            height=6
        )
        self.urls_listbox.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        urls_scrollbar.config(command=self.urls_listbox.yview)
        
        # URL management buttons
        url_buttons_frame = ttk.Frame(targets_frame)
        url_buttons_frame.pack(fill=tk.X, pady=(5, 0))
        
        ttk.Button(url_buttons_frame, text="Add URL", command=self.add_url).pack(side=tk.LEFT, padx=(0, 5))
        ttk.Button(url_buttons_frame, text="Import", command=self.import_urls_file).pack(side=tk.LEFT, padx=(0, 5))
        ttk.Button(url_buttons_frame, text="Remove", command=self.remove_url).pack(side=tk.LEFT, padx=(0, 5))
        ttk.Button(url_buttons_frame, text="Clear", command=self.clear_urls).pack(side=tk.LEFT)
        
        # Detection methods section
        detection_frame = ttk.LabelFrame(left_frame, text="Detection Methods", padding=5)
        detection_frame.pack(fill=tk.X, pady=(0, 10))
        
        # Detection checkboxes
        self.detection_vars = {}
        detection_methods = [
            ("Error-based", "EnableErrorBasedDetection", True),
            ("Boolean-based", "EnableBooleanBasedDetection", True),
            ("Time-based", "EnableTimeBasedDetection", True),
            ("Union-based", "EnableUnionBasedDetection", True),
            ("Content-length", "EnableContentLengthDetection", True),
            ("Header injection", "EnableHeaderInjection", True),
            ("Cookie injection", "EnableCookieInjection", True),
            ("JSON injection", "EnableJsonInjection", False),
            ("XML injection", "EnableXmlInjection", False),
            ("Second-order", "EnableSecondOrderDetection", False)
        ]
        
        for name, key, default in detection_methods:
            var = tk.BooleanVar(value=default)
            self.detection_vars[key] = var
            ttk.Checkbutton(detection_frame, text=name, variable=var).pack(anchor=tk.W)
            
        # Testing options
        options_frame = ttk.LabelFrame(left_frame, text="Testing Options", padding=5)
        options_frame.pack(fill=tk.X, pady=(0, 10))
        
        # Max threads
        ttk.Label(options_frame, text="Max Threads:").pack(anchor=tk.W)
        self.threads_var = tk.StringVar(value="3")
        ttk.Entry(options_frame, textvariable=self.threads_var, width=10).pack(anchor=tk.W, pady=(0, 5))
        
        # Request timeout
        ttk.Label(options_frame, text="Request Timeout (s):").pack(anchor=tk.W)
        self.timeout_var = tk.StringVar(value="30")
        ttk.Entry(options_frame, textvariable=self.timeout_var, width=10).pack(anchor=tk.W, pady=(0, 5))
        
        # Time-based threshold
        ttk.Label(options_frame, text="Time-based Threshold (s):").pack(anchor=tk.W)
        self.time_threshold_var = tk.StringVar(value="3.0")
        ttk.Entry(options_frame, textvariable=self.time_threshold_var, width=10).pack(anchor=tk.W, pady=(0, 5))
        
        # Max payloads per URL
        ttk.Label(options_frame, text="Max Payloads per URL:").pack(anchor=tk.W)
        self.max_payloads_var = tk.StringVar(value="50")
        ttk.Entry(options_frame, textvariable=self.max_payloads_var, width=10).pack(anchor=tk.W, pady=(0, 5))
        
        # Request delay
        ttk.Label(options_frame, text="Request Delay (ms):").pack(anchor=tk.W)
        self.delay_var = tk.StringVar(value="1000")
        ttk.Entry(options_frame, textvariable=self.delay_var, width=10).pack(anchor=tk.W, pady=(0, 5))
        
        # Checkboxes
        self.waf_bypass_var = tk.BooleanVar(value=True)
        ttk.Checkbutton(options_frame, text="Enable WAF Bypasses", variable=self.waf_bypass_var).pack(anchor=tk.W)
        
        self.ssl_verify_var = tk.BooleanVar(value=False)
        ttk.Checkbutton(options_frame, text="SSL Certificate Verification", variable=self.ssl_verify_var).pack(anchor=tk.W)
        
        # Control buttons
        control_frame = ttk.Frame(left_frame)
        control_frame.pack(fill=tk.X, pady=(0, 10))
        
        self.start_button = ttk.Button(control_frame, text="Start Testing", command=self.start_testing)
        self.start_button.pack(side=tk.LEFT, padx=(0, 5))
        
        self.stop_button = ttk.Button(control_frame, text="Stop", command=self.stop_testing, state=tk.DISABLED)
        self.stop_button.pack(side=tk.LEFT, padx=(0, 5))
        
        self.clear_button = ttk.Button(control_frame, text="Clear Results", command=self.clear_results)
        self.clear_button.pack(side=tk.LEFT)
        
        # Right panel - Results
        right_frame = ttk.LabelFrame(main_frame, text="Test Results", padding=10)
        right_frame.pack(side=tk.RIGHT, fill=tk.BOTH, expand=True)
        
        # Results notebook
        self.results_notebook = ttk.Notebook(right_frame)
        self.results_notebook.pack(fill=tk.BOTH, expand=True)
        
        # Vulnerabilities tab
        self.create_vulnerabilities_tab()
        
        # Statistics tab
        self.create_statistics_tab()
        
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
        
    def create_vulnerabilities_tab(self):
        """Create vulnerabilities tab"""
        vulns_frame = ttk.Frame(self.results_notebook)
        self.results_notebook.add(vulns_frame, text="Vulnerabilities")
        
        # Summary
        summary_frame = ttk.Frame(vulns_frame)
        summary_frame.pack(fill=tk.X, pady=(0, 10))
        
        self.vulns_summary_var = tk.StringVar(value="No vulnerabilities found yet")
        ttk.Label(summary_frame, textvariable=self.vulns_summary_var).pack(side=tk.LEFT)
        
        ttk.Button(summary_frame, text="Generate Report", command=self.generate_report).pack(side=tk.RIGHT, padx=(5, 0))
        ttk.Button(summary_frame, text="Send to Dumper", command=self.send_to_dumper).pack(side=tk.RIGHT, padx=(5, 0))
        ttk.Button(summary_frame, text="Export Results", command=self.export_vulnerabilities).pack(side=tk.RIGHT)
        
        # Vulnerabilities treeview
        columns = ("URL", "Parameter", "Type", "Database", "Severity", "Confidence", "Response Time")
        self.vulns_tree = ttk.Treeview(vulns_frame, columns=columns, show="headings")
        
        for col in columns:
            self.vulns_tree.heading(col, text=col)
            
        self.vulns_tree.column("URL", width=200)
        self.vulns_tree.column("Parameter", width=100)
        self.vulns_tree.column("Type", width=100)
        self.vulns_tree.column("Database", width=80)
        self.vulns_tree.column("Severity", width=80)
        self.vulns_tree.column("Confidence", width=80)
        self.vulns_tree.column("Response Time", width=100)
        
        # Scrollbar
        vulns_scrollbar = ttk.Scrollbar(vulns_frame, orient=tk.VERTICAL, command=self.vulns_tree.yview)
        self.vulns_tree.configure(yscrollcommand=vulns_scrollbar.set)
        
        self.vulns_tree.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        vulns_scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
        
        # Bind events
        self.vulns_tree.bind("<Double-1>", self.on_vulnerability_double_click)
        
    def create_statistics_tab(self):
        """Create statistics tab"""
        stats_frame = ttk.Frame(self.results_notebook)
        self.results_notebook.add(stats_frame, text="Statistics")
        
        # Statistics text
        self.stats_text = tk.Text(stats_frame, wrap=tk.WORD, state=tk.DISABLED)
        
        # Scrollbar
        stats_scrollbar = ttk.Scrollbar(stats_frame, orient=tk.VERTICAL, command=self.stats_text.yview)
        self.stats_text.configure(yscrollcommand=stats_scrollbar.set)
        
        self.stats_text.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        stats_scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
        
    def add_url(self):
        """Add new URL"""
        from tkinter.simpledialog import askstring
        
        url = askstring("Add URL", "Enter URL to test:")
        if url:
            if not url.startswith(('http://', 'https://')):
                url = 'http://' + url
            self.urls_listbox.insert(tk.END, url)
            
    def import_urls_file(self):
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
                            
                self.urls_listbox.delete(0, tk.END)
                for url in urls:
                    self.urls_listbox.insert(tk.END, url)
                    
                messagebox.showinfo("Success", f"Imported {len(urls)} URLs")
                
            except Exception as e:
                messagebox.showerror("Error", f"Failed to import URLs:\n{str(e)}")
                
    def remove_url(self):
        """Remove selected URL"""
        selection = self.urls_listbox.curselection()
        for index in reversed(selection):
            self.urls_listbox.delete(index)
            
    def clear_urls(self):
        """Clear all URLs"""
        result = messagebox.askyesno("Confirm", "Clear all URLs?")
        if result:
            self.urls_listbox.delete(0, tk.END)
            
    def start_testing(self):
        """Start SQL injection testing"""
        # Get URLs
        urls = [self.urls_listbox.get(i) for i in range(self.urls_listbox.size())]
        if not urls:
            messagebox.showwarning("Warning", "No URLs to test")
            return
            
        # Update UI
        self.is_testing = True
        self.start_button.config(state=tk.DISABLED)
        self.stop_button.config(state=tk.NORMAL)
        self.progress_var.set(0)
        self.status_var.set("Starting tests...")
        
        # Clear previous results
        self.test_results.clear()
        self.vulnerability_results.clear()
        self.clear_displays()
        
        # Start testing in background
        self.test_thread = threading.Thread(target=self.run_testing, args=(urls,))
        self.test_thread.daemon = True
        self.test_thread.start()
        
    def run_testing(self, urls: List[str]):
        """Run testing in background thread"""
        try:
            # Create config
            config = {
                "MaxThreads": int(self.threads_var.get()),
                "RequestTimeout": int(self.timeout_var.get()),
                "TimeBasedThreshold": float(self.time_threshold_var.get()),
                "MaxPayloadsPerUrl": int(self.max_payloads_var.get()),
                "RequestDelay": int(self.delay_var.get()),
                "EnableWafBypasses": self.waf_bypass_var.get(),
                "EnableSslCertificateValidation": self.ssl_verify_var.get(),
                "PayloadFile": "payloads.xml",
                "ErrorSignatureFile": "error_signatures.xml",
                "WafBypassFile": "waf_bypasses.xml",
                "UserAgent": "BoomSQL/2.0 SQL Tester"
            }
            
            # Add detection method config
            for key, var in self.detection_vars.items():
                config[key] = var.get()
                
            # Create engine
            self.sql_engine = SqlInjectionEngine(config)
            
            # Run tests
            loop = asyncio.new_event_loop()
            asyncio.set_event_loop(loop)
            
            try:
                for i, url in enumerate(urls):
                    if not self.is_testing:
                        break
                        
                    self.after(0, lambda u=url: self.status_var.set(f"Testing: {u}"))
                    
                    # Test URL
                    result = loop.run_until_complete(self.sql_engine.test_url(url))
                    
                    self.test_results.append(result)
                    self.vulnerability_results.extend(result.vulnerabilities)
                    
                    # Update progress
                    progress = ((i + 1) / len(urls)) * 100
                    self.after(0, lambda p=progress: self.progress_var.set(p))
                    
                    # Update display
                    self.after(0, self.update_results_display)
                    
                # Close engine
                loop.run_until_complete(self.sql_engine.close())
                
            finally:
                loop.close()
                
        except Exception as e:
            self.after(0, lambda: messagebox.showerror("Error", f"Testing failed:\n{str(e)}"))
            
        finally:
            # Update UI
            self.after(0, self.testing_completed)
            
    def testing_completed(self):
        """Testing completed"""
        self.is_testing = False
        self.start_button.config(state=tk.NORMAL)
        self.stop_button.config(state=tk.DISABLED)
        self.progress_var.set(100)
        self.status_var.set("Testing completed")
        
        # Update statistics
        self.update_statistics()
        
    def stop_testing(self):
        """Stop testing"""
        self.is_testing = False
        if self.sql_engine:
            # Engine should handle cancellation
            pass
            
    def update_results_display(self):
        """Update results display"""
        # Update vulnerabilities
        self.vulns_tree.delete(*self.vulns_tree.get_children())
        
        for vuln in self.vulnerability_results:
            # Determine severity
            if vuln.injection_type.value in ['error_based', 'union_based'] and vuln.confidence >= 0.9:
                severity = "Critical"
            elif vuln.injection_type.value in ['error_based', 'union_based'] and vuln.confidence >= 0.7:
                severity = "High"
            elif vuln.injection_type.value == 'time_based' and vuln.confidence >= 0.8:
                severity = "High"
            elif vuln.injection_type.value == 'boolean_based' and vuln.confidence >= 0.8:
                severity = "Medium"
            else:
                severity = "Low"
                
            self.vulns_tree.insert("", tk.END, values=(
                vuln.url,
                vuln.injection_point.name,
                vuln.injection_type.value.replace('_', ' ').title(),
                vuln.database_type.value.upper(),
                severity,
                f"{vuln.confidence:.1%}",
                f"{vuln.response_time:.2f}s"
            ))
            
        # Update summary
        total_vulns = len(self.vulnerability_results)
        if total_vulns > 0:
            critical = sum(1 for v in self.vulnerability_results if v.confidence >= 0.9)
            high = sum(1 for v in self.vulnerability_results if 0.7 <= v.confidence < 0.9)
            medium = sum(1 for v in self.vulnerability_results if 0.5 <= v.confidence < 0.7)
            low = sum(1 for v in self.vulnerability_results if v.confidence < 0.5)
            
            self.vulns_summary_var.set(
                f"Found {total_vulns} vulnerabilities (Critical: {critical}, High: {high}, Medium: {medium}, Low: {low})"
            )
        else:
            self.vulns_summary_var.set("No vulnerabilities found")
            
    def update_statistics(self):
        """Update statistics display"""
        if not self.test_results:
            return
            
        stats = []
        stats.append("=== SQL Injection Testing Statistics ===\n")
        
        # General statistics
        total_urls = len(self.test_results)
        total_vulns = len(self.vulnerability_results)
        vulnerable_urls = sum(1 for r in self.test_results if r.is_vulnerable)
        
        stats.append(f"Total URLs Tested: {total_urls}")
        stats.append(f"Vulnerable URLs: {vulnerable_urls}")
        stats.append(f"Total Vulnerabilities: {total_vulns}")
        stats.append(f"Vulnerability Rate: {(vulnerable_urls/total_urls)*100:.1f}%\n")
        
        # Injection type statistics
        stats.append("=== Vulnerabilities by Injection Type ===")
        injection_types = {}
        for vuln in self.vulnerability_results:
            injection_type = vuln.injection_type.value
            injection_types[injection_type] = injection_types.get(injection_type, 0) + 1
            
        for injection_type, count in sorted(injection_types.items()):
            stats.append(f"{injection_type.replace('_', ' ').title()}: {count}")
            
        stats.append("")
        
        # Database type statistics
        stats.append("=== Vulnerabilities by Database Type ===")
        database_types = {}
        for vuln in self.vulnerability_results:
            db_type = vuln.database_type.value
            database_types[db_type] = database_types.get(db_type, 0) + 1
            
        for db_type, count in sorted(database_types.items()):
            stats.append(f"{db_type.upper()}: {count}")
            
        stats.append("")
        
        # Confidence statistics
        stats.append("=== Vulnerabilities by Confidence Level ===")
        confidence_levels = {
            "Very High (90-100%)": 0,
            "High (70-89%)": 0,
            "Medium (50-69%)": 0,
            "Low (30-49%)": 0,
            "Very Low (<30%)": 0
        }
        
        for vuln in self.vulnerability_results:
            conf = vuln.confidence
            if conf >= 0.9:
                confidence_levels["Very High (90-100%)"] += 1
            elif conf >= 0.7:
                confidence_levels["High (70-89%)"] += 1
            elif conf >= 0.5:
                confidence_levels["Medium (50-69%)"] += 1
            elif conf >= 0.3:
                confidence_levels["Low (30-49%)"] += 1
            else:
                confidence_levels["Very Low (<30%)"] += 1
                
        for level, count in confidence_levels.items():
            stats.append(f"{level}: {count}")
            
        stats.append("")
        
        # Performance statistics
        stats.append("=== Performance Statistics ===")
        total_time = sum(r.total_time for r in self.test_results)
        avg_time = total_time / len(self.test_results)
        total_payloads = sum(r.total_payloads_tested for r in self.test_results)
        
        stats.append(f"Total Testing Time: {total_time:.2f}s")
        stats.append(f"Average Time per URL: {avg_time:.2f}s")
        stats.append(f"Total Payloads Tested: {total_payloads}")
        stats.append(f"Average Payloads per URL: {total_payloads/len(self.test_results):.1f}")
        
        # Update text widget
        self.stats_text.config(state=tk.NORMAL)
        self.stats_text.delete(1.0, tk.END)
        self.stats_text.insert(tk.END, "\n".join(stats))
        self.stats_text.config(state=tk.DISABLED)
        
    def clear_displays(self):
        """Clear all displays"""
        self.vulns_tree.delete(*self.vulns_tree.get_children())
        self.stats_text.config(state=tk.NORMAL)
        self.stats_text.delete(1.0, tk.END)
        self.stats_text.config(state=tk.DISABLED)
        
    def clear_results(self):
        """Clear test results"""
        self.test_results.clear()
        self.vulnerability_results.clear()
        self.clear_displays()
        self.vulns_summary_var.set("No vulnerabilities found yet")
        self.progress_var.set(0)
        self.status_var.set("Ready")
        
    def export_vulnerabilities(self):
        """Export vulnerabilities"""
        if not self.vulnerability_results:
            messagebox.showwarning("Warning", "No vulnerabilities to export")
            return
            
        file_path = filedialog.asksaveasfilename(
            title="Export Vulnerabilities",
            defaultextension=".json",
            filetypes=[
                ("JSON files", "*.json"),
                ("CSV files", "*.csv"),
                ("HTML files", "*.html"),
                ("XML files", "*.xml")
            ]
        )
        
        if file_path:
            try:
                # Create report generator
                from core.report_generator import ReportGenerator, ReportType, ReportFormat
                
                generator = ReportGenerator(self.app.config.config)
                generator.add_test_results(self.test_results)
                
                # Determine format
                file_ext = Path(file_path).suffix.lower()
                if file_ext == '.json':
                    format_type = ReportFormat.JSON
                elif file_ext == '.csv':
                    format_type = ReportFormat.CSV
                elif file_ext == '.html':
                    format_type = ReportFormat.HTML
                elif file_ext == '.xml':
                    format_type = ReportFormat.XML
                else:
                    format_type = ReportFormat.JSON
                    
                generator.generate_report(ReportType.TECHNICAL, format_type, file_path)
                messagebox.showinfo("Success", f"Vulnerabilities exported to {file_path}")
                
            except Exception as e:
                messagebox.showerror("Error", f"Failed to export vulnerabilities:\n{str(e)}")
                
    def generate_report(self):
        """Generate vulnerability report"""
        if not self.vulnerability_results:
            messagebox.showwarning("Warning", "No vulnerabilities to report")
            return
            
        # Report generation dialog
        from tkinter.simpledialog import askstring
        
        file_path = filedialog.asksaveasfilename(
            title="Generate Report",
            defaultextension=".html",
            filetypes=[
                ("HTML files", "*.html"),
                ("JSON files", "*.json"),
                ("XML files", "*.xml")
            ]
        )
        
        if file_path:
            try:
                from core.report_generator import ReportGenerator, ReportType, ReportFormat
                
                generator = ReportGenerator(self.app.config.config)
                generator.add_test_results(self.test_results)
                
                # Determine format
                file_ext = Path(file_path).suffix.lower()
                if file_ext == '.html':
                    format_type = ReportFormat.HTML
                elif file_ext == '.json':
                    format_type = ReportFormat.JSON
                elif file_ext == '.xml':
                    format_type = ReportFormat.XML
                else:
                    format_type = ReportFormat.HTML
                    
                generator.generate_report(ReportType.DETAILED, format_type, file_path)
                messagebox.showinfo("Success", f"Report generated: {file_path}")
                
            except Exception as e:
                messagebox.showerror("Error", f"Failed to generate report:\n{str(e)}")
                
    def send_to_dumper(self):
        """Send vulnerabilities to dumper"""
        if not self.vulnerability_results:
            messagebox.showwarning("Warning", "No vulnerabilities to send")
            return
            
        # Get dumper page
        dumper_page = self.app.main_window.dumper_page
        if dumper_page:
            dumper_page.import_vulnerabilities(self.vulnerability_results)
            messagebox.showinfo("Success", f"Sent {len(self.vulnerability_results)} vulnerabilities to dumper")
        else:
            messagebox.showerror("Error", "Dumper page not available")
            
    def on_vulnerability_double_click(self, event):
        """Handle vulnerability double-click"""
        selection = self.vulns_tree.selection()
        if selection:
            item = selection[0]
            url = self.vulns_tree.item(item, "values")[0]
            
            # Show vulnerability details
            self.show_vulnerability_details(url)
            
    def show_vulnerability_details(self, url: str):
        """Show vulnerability details"""
        # Find vulnerability
        vuln = None
        for v in self.vulnerability_results:
            if v.url == url:
                vuln = v
                break
                
        if not vuln:
            return
            
        # Create details window
        details_window = tk.Toplevel(self)
        details_window.title("Vulnerability Details")
        details_window.geometry("800x600")
        
        # Details text
        details_text = tk.Text(details_window, wrap=tk.WORD)
        details_text.pack(fill=tk.BOTH, expand=True, padx=10, pady=10)
        
        # Format vulnerability details
        details = []
        details.append(f"URL: {vuln.url}")
        details.append(f"Parameter: {vuln.injection_point.name}")
        details.append(f"Injection Type: {vuln.injection_type.value.replace('_', ' ').title()}")
        details.append(f"Database Type: {vuln.database_type.value.upper()}")
        details.append(f"Confidence: {vuln.confidence:.1%}")
        details.append(f"Response Time: {vuln.response_time:.2f}s")
        details.append(f"Response Code: {vuln.response_code}")
        details.append(f"Evidence: {vuln.evidence}")
        details.append(f"Payload: {vuln.payload.payload}")
        details.append(f"Payload Title: {vuln.payload.title}")
        details.append(f"Payload Risk: {vuln.payload.risk}")
        details.append(f"Payload Platform: {vuln.payload.platform}")
        if vuln.bypass_method:
            details.append(f"Bypass Method: {vuln.bypass_method}")
        details.append(f"Timestamp: {vuln.timestamp}")
        details.append("")
        details.append("Response Body (first 1000 chars):")
        details.append(vuln.response_body[:1000])
        
        details_text.insert(tk.END, "\n".join(details))
        details_text.config(state=tk.DISABLED)
        
    def is_running(self) -> bool:
        """Check if testing is running"""
        return self.is_testing
        
    def cancel_operation(self):
        """Cancel current operation"""
        if self.is_testing:
            self.stop_testing()
            
    def get_state(self) -> Dict[str, Any]:
        """Get current state"""
        return {
            "urls": [self.urls_listbox.get(i) for i in range(self.urls_listbox.size())],
            "detection_methods": {key: var.get() for key, var in self.detection_vars.items()},
            "threads": self.threads_var.get(),
            "timeout": self.timeout_var.get(),
            "time_threshold": self.time_threshold_var.get(),
            "max_payloads": self.max_payloads_var.get(),
            "delay": self.delay_var.get(),
            "waf_bypass": self.waf_bypass_var.get(),
            "ssl_verify": self.ssl_verify_var.get()
        }
        
    def set_state(self, state: Dict[str, Any]):
        """Set state"""
        if "urls" in state:
            self.urls_listbox.delete(0, tk.END)
            for url in state["urls"]:
                self.urls_listbox.insert(tk.END, url)
                
        if "detection_methods" in state:
            for key, var in self.detection_vars.items():
                if key in state["detection_methods"]:
                    var.set(state["detection_methods"][key])
                    
        if "threads" in state:
            self.threads_var.set(state["threads"])
        if "timeout" in state:
            self.timeout_var.set(state["timeout"])
        if "time_threshold" in state:
            self.time_threshold_var.set(state["time_threshold"])
        if "max_payloads" in state:
            self.max_payloads_var.set(state["max_payloads"])
        if "delay" in state:
            self.delay_var.set(state["delay"])
        if "waf_bypass" in state:
            self.waf_bypass_var.set(state["waf_bypass"])
        if "ssl_verify" in state:
            self.ssl_verify_var.set(state["ssl_verify"])
            
    def import_urls(self, urls: List[str]):
        """Import URLs to test"""
        self.urls_listbox.delete(0, tk.END)
        for url in urls:
            self.urls_listbox.insert(tk.END, url)
            
    def import_candidates(self, candidates: List[Dict[str, Any]]):
        """Import injection candidates"""
        urls = list(set(candidate['url'] for candidate in candidates))
        self.import_urls(urls)
        
    def export_results(self):
        """Export current results"""
        self.export_vulnerabilities()