"""
Settings Page for BoomSQL
Application configuration interface
"""

import tkinter as tk
from tkinter import ttk, messagebox, filedialog
from typing import Dict, Any, Optional
from pathlib import Path

class SettingsPage(ttk.Frame):
    """Settings page"""
    
    def __init__(self, parent, app):
        super().__init__(parent)
        self.app = app
        self.config = app.config
        
        self.create_widgets()
        self.load_settings()
        
    def create_widgets(self):
        """Create page widgets"""
        # Main container
        main_frame = ttk.Frame(self)
        main_frame.pack(fill=tk.BOTH, expand=True, padx=10, pady=10)
        
        # Settings notebook
        self.settings_notebook = ttk.Notebook(main_frame)
        self.settings_notebook.pack(fill=tk.BOTH, expand=True)
        
        # Create tabs
        self.create_general_tab()
        self.create_testing_tab()
        self.create_crawler_tab()
        self.create_dumper_tab()
        self.create_proxy_tab()
        self.create_security_tab()
        
        # Buttons frame
        buttons_frame = ttk.Frame(main_frame)
        buttons_frame.pack(fill=tk.X, pady=(10, 0))
        
        ttk.Button(buttons_frame, text="Load Config", command=self.load_config).pack(side=tk.LEFT, padx=(0, 5))
        ttk.Button(buttons_frame, text="Save Config", command=self.save_config).pack(side=tk.LEFT, padx=(0, 5))
        ttk.Button(buttons_frame, text="Reset to Defaults", command=self.reset_defaults).pack(side=tk.LEFT, padx=(0, 5))
        ttk.Button(buttons_frame, text="Apply", command=self.apply_settings).pack(side=tk.RIGHT)
        
    def create_general_tab(self):
        """Create general settings tab"""
        general_frame = ttk.Frame(self.settings_notebook)
        self.settings_notebook.add(general_frame, text="General")
        
        # Create scrollable frame
        canvas = tk.Canvas(general_frame)
        scrollbar = ttk.Scrollbar(general_frame, orient="vertical", command=canvas.yview)
        scrollable_frame = ttk.Frame(canvas)
        
        scrollable_frame.bind(
            "<Configure>",
            lambda e: canvas.configure(scrollregion=canvas.bbox("all"))
        )
        
        canvas.create_window((0, 0), window=scrollable_frame, anchor="nw")
        canvas.configure(yscrollcommand=scrollbar.set)
        
        # Application settings
        app_frame = ttk.LabelFrame(scrollable_frame, text="Application Settings", padding=10)
        app_frame.pack(fill=tk.X, pady=(0, 10))
        
        # Theme
        ttk.Label(app_frame, text="Theme:").grid(row=0, column=0, sticky=tk.W, pady=5)
        self.theme_var = tk.StringVar(value=self.config.get("UI.Theme", "dark"))
        theme_combo = ttk.Combobox(app_frame, textvariable=self.theme_var, values=["dark", "light"], state="readonly")
        theme_combo.grid(row=0, column=1, sticky=tk.W, padx=(10, 0), pady=5)
        
        # Language
        ttk.Label(app_frame, text="Language:").grid(row=1, column=0, sticky=tk.W, pady=5)
        self.language_var = tk.StringVar(value=self.config.get("UI.Language", "en"))
        language_combo = ttk.Combobox(app_frame, textvariable=self.language_var, values=["en", "es", "fr", "de"], state="readonly")
        language_combo.grid(row=1, column=1, sticky=tk.W, padx=(10, 0), pady=5)
        
        # Logging settings
        log_frame = ttk.LabelFrame(scrollable_frame, text="Logging Settings", padding=10)
        log_frame.pack(fill=tk.X, pady=(0, 10))
        
        # Log level
        ttk.Label(log_frame, text="Log Level:").grid(row=0, column=0, sticky=tk.W, pady=5)
        self.log_level_var = tk.StringVar(value=self.config.get("Logging.LogLevel", "INFO"))
        log_level_combo = ttk.Combobox(log_frame, textvariable=self.log_level_var, 
                                     values=["DEBUG", "INFO", "WARNING", "ERROR", "CRITICAL"], state="readonly")
        log_level_combo.grid(row=0, column=1, sticky=tk.W, padx=(10, 0), pady=5)
        
        # Enable file logging
        self.enable_file_logging_var = tk.BooleanVar(value=self.config.get("Logging.EnableFileLogging", True))
        ttk.Checkbutton(log_frame, text="Enable File Logging", variable=self.enable_file_logging_var).grid(row=1, column=0, sticky=tk.W, pady=5)
        
        # Enable console logging
        self.enable_console_logging_var = tk.BooleanVar(value=self.config.get("Logging.EnableConsoleLogging", True))
        ttk.Checkbutton(log_frame, text="Enable Console Logging", variable=self.enable_console_logging_var).grid(row=1, column=1, sticky=tk.W, pady=5)
        
        # Max log size
        ttk.Label(log_frame, text="Max Log Size (MB):").grid(row=2, column=0, sticky=tk.W, pady=5)
        self.max_log_size_var = tk.StringVar(value=str(self.config.get("Logging.MaxLogSize", 10485760) // 1024 // 1024))
        ttk.Entry(log_frame, textvariable=self.max_log_size_var, width=10).grid(row=2, column=1, sticky=tk.W, padx=(10, 0), pady=5)
        
        canvas.pack(side="left", fill="both", expand=True)
        scrollbar.pack(side="right", fill="y")
        
    def create_testing_tab(self):
        """Create testing settings tab"""
        testing_frame = ttk.Frame(self.settings_notebook)
        self.settings_notebook.add(testing_frame, text="Testing")
        
        # Performance settings
        perf_frame = ttk.LabelFrame(testing_frame, text="Performance Settings", padding=10)
        perf_frame.pack(fill=tk.X, pady=(0, 10))
        
        # Max threads
        ttk.Label(perf_frame, text="Max Threads:").grid(row=0, column=0, sticky=tk.W, pady=5)
        self.max_threads_var = tk.StringVar(value=str(self.config.get("Testing.MaxThreads", 5)))
        ttk.Entry(perf_frame, textvariable=self.max_threads_var, width=10).grid(row=0, column=1, sticky=tk.W, padx=(10, 0), pady=5)
        
        # Request timeout
        ttk.Label(perf_frame, text="Request Timeout (s):").grid(row=1, column=0, sticky=tk.W, pady=5)
        self.request_timeout_var = tk.StringVar(value=str(self.config.get("Testing.RequestTimeout", 30)))
        ttk.Entry(perf_frame, textvariable=self.request_timeout_var, width=10).grid(row=1, column=1, sticky=tk.W, padx=(10, 0), pady=5)
        
        # Request delay
        ttk.Label(perf_frame, text="Request Delay (ms):").grid(row=2, column=0, sticky=tk.W, pady=5)
        self.request_delay_var = tk.StringVar(value=str(self.config.get("Testing.RequestDelay", 1000)))
        ttk.Entry(perf_frame, textvariable=self.request_delay_var, width=10).grid(row=2, column=1, sticky=tk.W, padx=(10, 0), pady=5)
        
        # Time-based threshold
        ttk.Label(perf_frame, text="Time-based Threshold (s):").grid(row=3, column=0, sticky=tk.W, pady=5)
        self.time_threshold_var = tk.StringVar(value=str(self.config.get("Testing.TimeBasedThreshold", 3.0)))
        ttk.Entry(perf_frame, textvariable=self.time_threshold_var, width=10).grid(row=3, column=1, sticky=tk.W, padx=(10, 0), pady=5)
        
        # Max payloads per URL
        ttk.Label(perf_frame, text="Max Payloads per URL:").grid(row=4, column=0, sticky=tk.W, pady=5)
        self.max_payloads_var = tk.StringVar(value=str(self.config.get("Testing.MaxPayloadsPerUrl", 100)))
        ttk.Entry(perf_frame, textvariable=self.max_payloads_var, width=10).grid(row=4, column=1, sticky=tk.W, padx=(10, 0), pady=5)
        
        # Detection settings
        detection_frame = ttk.LabelFrame(testing_frame, text="Detection Settings", padding=10)
        detection_frame.pack(fill=tk.X, pady=(0, 10))
        
        # Enable detection methods
        self.enable_error_based_var = tk.BooleanVar(value=self.config.get("Testing.EnableErrorBasedDetection", True))
        ttk.Checkbutton(detection_frame, text="Error-based Detection", variable=self.enable_error_based_var).grid(row=0, column=0, sticky=tk.W, pady=2)
        
        self.enable_boolean_based_var = tk.BooleanVar(value=self.config.get("Testing.EnableBooleanBasedDetection", True))
        ttk.Checkbutton(detection_frame, text="Boolean-based Detection", variable=self.enable_boolean_based_var).grid(row=0, column=1, sticky=tk.W, pady=2)
        
        self.enable_time_based_var = tk.BooleanVar(value=self.config.get("Testing.EnableTimeBasedDetection", True))
        ttk.Checkbutton(detection_frame, text="Time-based Detection", variable=self.enable_time_based_var).grid(row=1, column=0, sticky=tk.W, pady=2)
        
        self.enable_union_based_var = tk.BooleanVar(value=self.config.get("Testing.EnableUnionBasedDetection", True))
        ttk.Checkbutton(detection_frame, text="Union-based Detection", variable=self.enable_union_based_var).grid(row=1, column=1, sticky=tk.W, pady=2)
        
        self.enable_waf_bypasses_var = tk.BooleanVar(value=self.config.get("Testing.EnableWafBypasses", True))
        ttk.Checkbutton(detection_frame, text="WAF Bypasses", variable=self.enable_waf_bypasses_var).grid(row=2, column=0, sticky=tk.W, pady=2)
        
        self.enable_header_injection_var = tk.BooleanVar(value=self.config.get("Testing.EnableHeaderInjection", True))
        ttk.Checkbutton(detection_frame, text="Header Injection", variable=self.enable_header_injection_var).grid(row=2, column=1, sticky=tk.W, pady=2)
        
    def create_crawler_tab(self):
        """Create crawler settings tab"""
        crawler_frame = ttk.Frame(self.settings_notebook)
        self.settings_notebook.add(crawler_frame, text="Crawler")
        
        # Crawler settings
        crawler_settings_frame = ttk.LabelFrame(crawler_frame, text="Crawler Settings", padding=10)
        crawler_settings_frame.pack(fill=tk.X, pady=(0, 10))
        
        # Max depth
        ttk.Label(crawler_settings_frame, text="Max Depth:").grid(row=0, column=0, sticky=tk.W, pady=5)
        self.max_depth_var = tk.StringVar(value=str(self.config.get("Crawler.MaxDepth", 5)))
        ttk.Entry(crawler_settings_frame, textvariable=self.max_depth_var, width=10).grid(row=0, column=1, sticky=tk.W, padx=(10, 0), pady=5)
        
        # Max URLs
        ttk.Label(crawler_settings_frame, text="Max URLs:").grid(row=1, column=0, sticky=tk.W, pady=5)
        self.max_urls_var = tk.StringVar(value=str(self.config.get("Crawler.MaxUrls", 1000)))
        ttk.Entry(crawler_settings_frame, textvariable=self.max_urls_var, width=10).grid(row=1, column=1, sticky=tk.W, padx=(10, 0), pady=5)
        
        # Crawler options
        self.follow_redirects_var = tk.BooleanVar(value=self.config.get("Crawler.FollowRedirects", True))
        ttk.Checkbutton(crawler_settings_frame, text="Follow Redirects", variable=self.follow_redirects_var).grid(row=2, column=0, sticky=tk.W, pady=2)
        
        self.enable_form_detection_var = tk.BooleanVar(value=self.config.get("Crawler.EnableFormDetection", True))
        ttk.Checkbutton(crawler_settings_frame, text="Form Detection", variable=self.enable_form_detection_var).grid(row=2, column=1, sticky=tk.W, pady=2)
        
        self.enable_param_extraction_var = tk.BooleanVar(value=self.config.get("Crawler.EnableParameterExtraction", True))
        ttk.Checkbutton(crawler_settings_frame, text="Parameter Extraction", variable=self.enable_param_extraction_var).grid(row=3, column=0, sticky=tk.W, pady=2)
        
        self.enable_cookie_extraction_var = tk.BooleanVar(value=self.config.get("Crawler.EnableCookieExtraction", True))
        ttk.Checkbutton(crawler_settings_frame, text="Cookie Extraction", variable=self.enable_cookie_extraction_var).grid(row=3, column=1, sticky=tk.W, pady=2)
        
    def create_dumper_tab(self):
        """Create dumper settings tab"""
        dumper_frame = ttk.Frame(self.settings_notebook)
        self.settings_notebook.add(dumper_frame, text="Dumper")
        
        # Dumper settings
        dumper_settings_frame = ttk.LabelFrame(dumper_frame, text="Dumper Settings", padding=10)
        dumper_settings_frame.pack(fill=tk.X, pady=(0, 10))
        
        # Max threads
        ttk.Label(dumper_settings_frame, text="Max Threads:").grid(row=0, column=0, sticky=tk.W, pady=5)
        self.dumper_max_threads_var = tk.StringVar(value=str(self.config.get("Dumper.MaxThreads", 3)))
        ttk.Entry(dumper_settings_frame, textvariable=self.dumper_max_threads_var, width=10).grid(row=0, column=1, sticky=tk.W, padx=(10, 0), pady=5)
        
        # Page size
        ttk.Label(dumper_settings_frame, text="Page Size:").grid(row=1, column=0, sticky=tk.W, pady=5)
        self.page_size_var = tk.StringVar(value=str(self.config.get("Dumper.PageSize", 100)))
        ttk.Entry(dumper_settings_frame, textvariable=self.page_size_var, width=10).grid(row=1, column=1, sticky=tk.W, padx=(10, 0), pady=5)
        
        # Max pages
        ttk.Label(dumper_settings_frame, text="Max Pages:").grid(row=2, column=0, sticky=tk.W, pady=5)
        self.max_pages_var = tk.StringVar(value=str(self.config.get("Dumper.MaxPages", 1000)))
        ttk.Entry(dumper_settings_frame, textvariable=self.max_pages_var, width=10).grid(row=2, column=1, sticky=tk.W, padx=(10, 0), pady=5)
        
        # Dumper options
        self.enable_resume_var = tk.BooleanVar(value=self.config.get("Dumper.EnableResume", True))
        ttk.Checkbutton(dumper_settings_frame, text="Enable Resume", variable=self.enable_resume_var).grid(row=3, column=0, sticky=tk.W, pady=2)
        
        self.enable_progress_tracking_var = tk.BooleanVar(value=self.config.get("Dumper.EnableProgressTracking", True))
        ttk.Checkbutton(dumper_settings_frame, text="Progress Tracking", variable=self.enable_progress_tracking_var).grid(row=3, column=1, sticky=tk.W, pady=2)
        
    def create_proxy_tab(self):
        """Create proxy settings tab"""
        proxy_frame = ttk.Frame(self.settings_notebook)
        self.settings_notebook.add(proxy_frame, text="Proxy")
        
        # Proxy settings
        proxy_settings_frame = ttk.LabelFrame(proxy_frame, text="Proxy Settings", padding=10)
        proxy_settings_frame.pack(fill=tk.X, pady=(0, 10))
        
        # Enable proxy rotation
        self.enable_proxy_rotation_var = tk.BooleanVar(value=self.config.get("Proxy.EnableProxyRotation", False))
        ttk.Checkbutton(proxy_settings_frame, text="Enable Proxy Rotation", variable=self.enable_proxy_rotation_var).grid(row=0, column=0, sticky=tk.W, pady=5)
        
        # Proxy file
        ttk.Label(proxy_settings_frame, text="Proxy File:").grid(row=1, column=0, sticky=tk.W, pady=5)
        self.proxy_file_var = tk.StringVar(value=self.config.get("Proxy.ProxyFile", "proxies.txt"))
        proxy_file_frame = ttk.Frame(proxy_settings_frame)
        proxy_file_frame.grid(row=1, column=1, sticky=tk.W, padx=(10, 0), pady=5)
        ttk.Entry(proxy_file_frame, textvariable=self.proxy_file_var, width=20).pack(side=tk.LEFT)
        ttk.Button(proxy_file_frame, text="Browse", command=self.browse_proxy_file).pack(side=tk.LEFT, padx=(5, 0))
        
        # Proxy timeout
        ttk.Label(proxy_settings_frame, text="Proxy Timeout (s):").grid(row=2, column=0, sticky=tk.W, pady=5)
        self.proxy_timeout_var = tk.StringVar(value=str(self.config.get("Proxy.ProxyTimeout", 10)))
        ttk.Entry(proxy_settings_frame, textvariable=self.proxy_timeout_var, width=10).grid(row=2, column=1, sticky=tk.W, padx=(10, 0), pady=5)
        
        # User agent settings
        ua_frame = ttk.LabelFrame(proxy_frame, text="User Agent Settings", padding=10)
        ua_frame.pack(fill=tk.X, pady=(0, 10))
        
        # Enable UA rotation
        self.enable_ua_rotation_var = tk.BooleanVar(value=self.config.get("UserAgents.EnableRotation", False))
        ttk.Checkbutton(ua_frame, text="Enable User Agent Rotation", variable=self.enable_ua_rotation_var).grid(row=0, column=0, sticky=tk.W, pady=5)
        
        # User agent file
        ttk.Label(ua_frame, text="User Agent File:").grid(row=1, column=0, sticky=tk.W, pady=5)
        self.ua_file_var = tk.StringVar(value=self.config.get("UserAgents.UserAgentFile", "useragents.txt"))
        ua_file_frame = ttk.Frame(ua_frame)
        ua_file_frame.grid(row=1, column=1, sticky=tk.W, padx=(10, 0), pady=5)
        ttk.Entry(ua_file_frame, textvariable=self.ua_file_var, width=20).pack(side=tk.LEFT)
        ttk.Button(ua_file_frame, text="Browse", command=self.browse_ua_file).pack(side=tk.LEFT, padx=(5, 0))
        
    def create_security_tab(self):
        """Create security settings tab"""
        security_frame = ttk.Frame(self.settings_notebook)
        self.settings_notebook.add(security_frame, text="Security")
        
        # Security settings
        security_settings_frame = ttk.LabelFrame(security_frame, text="Security Settings", padding=10)
        security_settings_frame.pack(fill=tk.X, pady=(0, 10))
        
        # SSL certificate validation
        self.enable_ssl_validation_var = tk.BooleanVar(value=self.config.get("Security.EnableSslCertificateValidation", False))
        ttk.Checkbutton(security_settings_frame, text="Enable SSL Certificate Validation", variable=self.enable_ssl_validation_var).grid(row=0, column=0, sticky=tk.W, pady=5)
        
        # Rate limiting
        self.enable_rate_limiting_var = tk.BooleanVar(value=self.config.get("Security.EnableRateLimiting", True))
        ttk.Checkbutton(security_settings_frame, text="Enable Rate Limiting", variable=self.enable_rate_limiting_var).grid(row=1, column=0, sticky=tk.W, pady=5)
        
        # Max requests per second
        ttk.Label(security_settings_frame, text="Max Requests/Second:").grid(row=2, column=0, sticky=tk.W, pady=5)
        self.max_requests_per_second_var = tk.StringVar(value=str(self.config.get("Security.MaxRequestsPerSecond", 10)))
        ttk.Entry(security_settings_frame, textvariable=self.max_requests_per_second_var, width=10).grid(row=2, column=1, sticky=tk.W, padx=(10, 0), pady=5)
        
        # Enable audit logging
        self.enable_audit_logging_var = tk.BooleanVar(value=self.config.get("Security.EnableAuditLogging", True))
        ttk.Checkbutton(security_settings_frame, text="Enable Audit Logging", variable=self.enable_audit_logging_var).grid(row=3, column=0, sticky=tk.W, pady=5)
        
    def browse_proxy_file(self):
        """Browse for proxy file"""
        file_path = filedialog.askopenfilename(
            title="Select Proxy File",
            filetypes=[("Text files", "*.txt"), ("All files", "*.*")]
        )
        if file_path:
            self.proxy_file_var.set(file_path)
            
    def browse_ua_file(self):
        """Browse for user agent file"""
        file_path = filedialog.askopenfilename(
            title="Select User Agent File",
            filetypes=[("Text files", "*.txt"), ("All files", "*.*")]
        )
        if file_path:
            self.ua_file_var.set(file_path)
            
    def load_settings(self):
        """Load settings from config"""
        # Settings are loaded in create_*_tab methods
        pass
        
    def apply_settings(self):
        """Apply current settings"""
        try:
            # Update config
            self.config.set("UI.Theme", self.theme_var.get())
            self.config.set("UI.Language", self.language_var.get())
            
            # Logging
            self.config.set("Logging.LogLevel", self.log_level_var.get())
            self.config.set("Logging.EnableFileLogging", self.enable_file_logging_var.get())
            self.config.set("Logging.EnableConsoleLogging", self.enable_console_logging_var.get())
            self.config.set("Logging.MaxLogSize", int(self.max_log_size_var.get()) * 1024 * 1024)
            
            # Testing
            self.config.set("Testing.MaxThreads", int(self.max_threads_var.get()))
            self.config.set("Testing.RequestTimeout", int(self.request_timeout_var.get()))
            self.config.set("Testing.RequestDelay", int(self.request_delay_var.get()))
            self.config.set("Testing.TimeBasedThreshold", float(self.time_threshold_var.get()))
            self.config.set("Testing.MaxPayloadsPerUrl", int(self.max_payloads_var.get()))
            self.config.set("Testing.EnableErrorBasedDetection", self.enable_error_based_var.get())
            self.config.set("Testing.EnableBooleanBasedDetection", self.enable_boolean_based_var.get())
            self.config.set("Testing.EnableTimeBasedDetection", self.enable_time_based_var.get())
            self.config.set("Testing.EnableUnionBasedDetection", self.enable_union_based_var.get())
            self.config.set("Testing.EnableWafBypasses", self.enable_waf_bypasses_var.get())
            self.config.set("Testing.EnableHeaderInjection", self.enable_header_injection_var.get())
            
            # Crawler
            self.config.set("Crawler.MaxDepth", int(self.max_depth_var.get()))
            self.config.set("Crawler.MaxUrls", int(self.max_urls_var.get()))
            self.config.set("Crawler.FollowRedirects", self.follow_redirects_var.get())
            self.config.set("Crawler.EnableFormDetection", self.enable_form_detection_var.get())
            self.config.set("Crawler.EnableParameterExtraction", self.enable_param_extraction_var.get())
            self.config.set("Crawler.EnableCookieExtraction", self.enable_cookie_extraction_var.get())
            
            # Dumper
            self.config.set("Dumper.MaxThreads", int(self.dumper_max_threads_var.get()))
            self.config.set("Dumper.PageSize", int(self.page_size_var.get()))
            self.config.set("Dumper.MaxPages", int(self.max_pages_var.get()))
            self.config.set("Dumper.EnableResume", self.enable_resume_var.get())
            self.config.set("Dumper.EnableProgressTracking", self.enable_progress_tracking_var.get())
            
            # Proxy
            self.config.set("Proxy.EnableProxyRotation", self.enable_proxy_rotation_var.get())
            self.config.set("Proxy.ProxyFile", self.proxy_file_var.get())
            self.config.set("Proxy.ProxyTimeout", int(self.proxy_timeout_var.get()))
            self.config.set("UserAgents.EnableRotation", self.enable_ua_rotation_var.get())
            self.config.set("UserAgents.UserAgentFile", self.ua_file_var.get())
            
            # Security
            self.config.set("Security.EnableSslCertificateValidation", self.enable_ssl_validation_var.get())
            self.config.set("Security.EnableRateLimiting", self.enable_rate_limiting_var.get())
            self.config.set("Security.MaxRequestsPerSecond", int(self.max_requests_per_second_var.get()))
            self.config.set("Security.EnableAuditLogging", self.enable_audit_logging_var.get())
            
            messagebox.showinfo("Success", "Settings applied successfully")
            
        except Exception as e:
            messagebox.showerror("Error", f"Failed to apply settings:\n{str(e)}")
            
    def save_config(self):
        """Save configuration to file"""
        try:
            self.apply_settings()
            self.config.save_config()
            messagebox.showinfo("Success", "Configuration saved successfully")
        except Exception as e:
            messagebox.showerror("Error", f"Failed to save configuration:\n{str(e)}")
            
    def load_config(self):
        """Load configuration from file"""
        file_path = filedialog.askopenfilename(
            title="Load Configuration",
            filetypes=[("JSON files", "*.json"), ("All files", "*.*")]
        )
        
        if file_path:
            try:
                import json
                with open(file_path, 'r', encoding='utf-8') as f:
                    config_data = json.load(f)
                    
                # Update config
                self.config._config = config_data
                
                # Reload settings
                self.load_settings()
                
                messagebox.showinfo("Success", f"Configuration loaded from {file_path}")
                
            except Exception as e:
                messagebox.showerror("Error", f"Failed to load configuration:\n{str(e)}")
                
    def reset_defaults(self):
        """Reset to default configuration"""
        result = messagebox.askyesno("Confirm", "Reset all settings to defaults?")
        if result:
            try:
                self.config._config = self.config.get_default_config()
                self.load_settings()
                messagebox.showinfo("Success", "Settings reset to defaults")
            except Exception as e:
                messagebox.showerror("Error", f"Failed to reset settings:\n{str(e)}")
                
    def get_state(self) -> Dict[str, Any]:
        """Get current state"""
        return {
            "selected_tab": self.settings_notebook.index(self.settings_notebook.select())
        }
        
    def set_state(self, state: Dict[str, Any]):
        """Set state"""
        if "selected_tab" in state:
            try:
                self.settings_notebook.select(state["selected_tab"])
            except:
                pass