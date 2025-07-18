"""
Database Dumper Page for BoomSQL
Database enumeration and dumping interface
"""

import tkinter as tk
from tkinter import ttk, messagebox, filedialog
import asyncio
import threading
from typing import List, Dict, Any, Optional
from pathlib import Path

from core.database_dumper import DatabaseDumper, DatabaseInfo, ExportFormat
from core.sql_injection_engine import VulnerabilityResult
from core.sqlmap_config import SQLMapConfig, DEFAULT_CONFIGS

class DumperPage(ttk.Frame):
    """Database dumper page"""
    
    def __init__(self, parent, app):
        super().__init__(parent)
        self.app = app
        self.database_dumper = None
        self.vulnerabilities: List[VulnerabilityResult] = []
        self.database_info: List[DatabaseInfo] = []
        self.is_dumping = False
        self.selected_items = set()  # Track selected items for export
        
        self.create_widgets()
        
    def create_widgets(self):
        """Create page widgets"""
        # Main container
        main_frame = ttk.Frame(self)
        main_frame.pack(fill=tk.BOTH, expand=True, padx=10, pady=10)
        
        # Left panel - Configuration
        left_frame = ttk.LabelFrame(main_frame, text="Dumper Configuration", padding=10)
        left_frame.pack(side=tk.LEFT, fill=tk.Y, padx=(0, 10))
        left_frame.configure(width=300)
        left_frame.pack_propagate(False)
        
        # Vulnerability selection
        vuln_frame = ttk.LabelFrame(left_frame, text="Vulnerability", padding=5)
        vuln_frame.pack(fill=tk.X, pady=(0, 10))
        
        # Vulnerability listbox
        self.vuln_listbox = tk.Listbox(vuln_frame, height=4)
        self.vuln_listbox.pack(fill=tk.X, pady=(0, 5))
        
        ttk.Button(vuln_frame, text="Select Vulnerability", command=self.select_vulnerability).pack(fill=tk.X)
        
        # SQLMap Configuration
        sqlmap_frame = ttk.LabelFrame(left_frame, text="SQLMap Configuration", padding=5)
        sqlmap_frame.pack(fill=tk.X, pady=(0, 10))
        
        # SQLMap technique selection
        ttk.Label(sqlmap_frame, text="Injection Technique:").pack(anchor=tk.W)
        self.technique_var = tk.StringVar(value="BEUTS")
        technique_combo = ttk.Combobox(sqlmap_frame, textvariable=self.technique_var, 
                                     values=["BEUTS", "B", "E", "U", "T", "S"],
                                     state="readonly")
        technique_combo.pack(fill=tk.X, pady=(0, 5))
        
        # SQLMap risk level
        ttk.Label(sqlmap_frame, text="Risk Level:").pack(anchor=tk.W)
        self.risk_var = tk.StringVar(value="1")
        risk_combo = ttk.Combobox(sqlmap_frame, textvariable=self.risk_var, 
                                values=["1", "2", "3"], state="readonly")
        risk_combo.pack(fill=tk.X, pady=(0, 5))
        
        # SQLMap level
        ttk.Label(sqlmap_frame, text="Level:").pack(anchor=tk.W)
        self.level_var = tk.StringVar(value="1")
        level_combo = ttk.Combobox(sqlmap_frame, textvariable=self.level_var, 
                                 values=["1", "2", "3", "4", "5"], state="readonly")
        level_combo.pack(fill=tk.X, pady=(0, 5))
        
        # SQLMap timeout
        ttk.Label(sqlmap_frame, text="Timeout (seconds):").pack(anchor=tk.W)
        self.timeout_var = tk.StringVar(value="30")
        timeout_entry = ttk.Entry(sqlmap_frame, textvariable=self.timeout_var)
        timeout_entry.pack(fill=tk.X, pady=(0, 5))
        
        # SQLMap thread count
        ttk.Label(sqlmap_frame, text="Max Threads:").pack(anchor=tk.W)
        self.threads_var = tk.StringVar(value="3")
        threads_entry = ttk.Entry(sqlmap_frame, textvariable=self.threads_var)
        threads_entry.pack(fill=tk.X, pady=(0, 5))
        
        # SQLMap options
        self.use_sqlmap_var = tk.BooleanVar(value=True)
        ttk.Checkbutton(sqlmap_frame, text="Use SQLMap Engine", 
                       variable=self.use_sqlmap_var).pack(anchor=tk.W)
        
        self.verbose_var = tk.BooleanVar(value=False)
        ttk.Checkbutton(sqlmap_frame, text="Verbose Output", 
                       variable=self.verbose_var).pack(anchor=tk.W)
        
        # SQLMap presets
        presets_frame = ttk.Frame(sqlmap_frame)
        presets_frame.pack(fill=tk.X, pady=(5, 0))
        
        ttk.Button(presets_frame, text="Fast", 
                  command=lambda: self.load_sqlmap_preset('fast')).pack(side=tk.LEFT, padx=(0, 5))
        ttk.Button(presets_frame, text="Thorough", 
                  command=lambda: self.load_sqlmap_preset('thorough')).pack(side=tk.LEFT, padx=(0, 5))
        ttk.Button(presets_frame, text="Stealth", 
                  command=lambda: self.load_sqlmap_preset('stealth')).pack(side=tk.LEFT)
        
        # Dump options
        options_frame = ttk.LabelFrame(left_frame, text="Dump Options", padding=5)
        options_frame.pack(fill=tk.X, pady=(0, 10))
        
        # Max threads
        ttk.Label(options_frame, text="Max Threads:").pack(anchor=tk.W)
        self.threads_var = tk.StringVar(value="2")
        ttk.Entry(options_frame, textvariable=self.threads_var, width=10).pack(anchor=tk.W, pady=(0, 5))
        
        # Page size
        ttk.Label(options_frame, text="Page Size:").pack(anchor=tk.W)
        self.page_size_var = tk.StringVar(value="100")
        ttk.Entry(options_frame, textvariable=self.page_size_var, width=10).pack(anchor=tk.W, pady=(0, 5))
        
        # Request delay
        ttk.Label(options_frame, text="Request Delay (ms):").pack(anchor=tk.W)
        self.delay_var = tk.StringVar(value="1000")
        ttk.Entry(options_frame, textvariable=self.delay_var, width=10).pack(anchor=tk.W, pady=(0, 5))
        
        # Export format
        ttk.Label(options_frame, text="Export Format:").pack(anchor=tk.W)
        self.export_format_var = tk.StringVar(value="json")
        format_combo = ttk.Combobox(options_frame, textvariable=self.export_format_var, 
                                   values=["json", "csv", "xml", "sql", "html"], state="readonly")
        format_combo.pack(anchor=tk.W, pady=(0, 5))
        
        # Advanced options frame
        advanced_frame = ttk.LabelFrame(left_frame, text="Advanced Options", padding=5)
        advanced_frame.pack(fill=tk.X, pady=(0, 10))
        
        # Smart dumping options
        self.smart_dump_var = tk.BooleanVar(value=True)
        ttk.Checkbutton(advanced_frame, text="Smart Dumping", variable=self.smart_dump_var).pack(anchor=tk.W)
        
        self.skip_empty_var = tk.BooleanVar(value=True) 
        ttk.Checkbutton(advanced_frame, text="Skip Empty Tables", variable=self.skip_empty_var).pack(anchor=tk.W)
        
        self.resume_dump_var = tk.BooleanVar(value=False)
        ttk.Checkbutton(advanced_frame, text="Resume Previous Dump", variable=self.resume_dump_var).pack(anchor=tk.W)
        
        # Data filtering
        filter_frame = ttk.LabelFrame(advanced_frame, text="Data Filtering", padding=3)
        filter_frame.pack(fill=tk.X, pady=(5, 0))
        
        ttk.Label(filter_frame, text="Max Rows per Table:").pack(anchor=tk.W)
        self.max_rows_var = tk.StringVar(value="1000")
        ttk.Entry(filter_frame, textvariable=self.max_rows_var, width=10).pack(anchor=tk.W, pady=(0, 3))
        
        ttk.Label(filter_frame, text="Table Name Filter:").pack(anchor=tk.W)
        self.table_filter_var = tk.StringVar(value="")
        ttk.Entry(filter_frame, textvariable=self.table_filter_var, width=20).pack(anchor=tk.W, pady=(0, 3))
        
        ttk.Label(filter_frame, text="Exclude Tables:").pack(anchor=tk.W)
        self.exclude_tables_var = tk.StringVar(value="log,temp,cache")
        ttk.Entry(filter_frame, textvariable=self.exclude_tables_var, width=20).pack(anchor=tk.W)
        
        # Control buttons
        control_frame = ttk.Frame(left_frame)
        control_frame.pack(fill=tk.X, pady=(0, 10))
        
        self.enumerate_button = ttk.Button(control_frame, text="Enumerate DB", command=self.enumerate_database)
        self.enumerate_button.pack(side=tk.LEFT, padx=(0, 5))
        
        self.dump_button = ttk.Button(control_frame, text="Dump Data", command=self.dump_database, state=tk.DISABLED)
        self.dump_button.pack(side=tk.LEFT, padx=(0, 5))
        
        self.stop_button = ttk.Button(control_frame, text="Stop", command=self.stop_dump, state=tk.DISABLED)
        self.stop_button.pack(side=tk.LEFT)
        
        # Export button
        export_frame = ttk.Frame(left_frame)
        export_frame.pack(fill=tk.X, pady=(0, 10))
        
        self.export_button = ttk.Button(export_frame, text="Export Results", command=self.export_results, state=tk.DISABLED)
        self.export_button.pack(fill=tk.X)
        
        # Right panel - Results
        right_frame = ttk.LabelFrame(main_frame, text="Database Structure", padding=10)
        right_frame.pack(side=tk.RIGHT, fill=tk.BOTH, expand=True)

        # Tree control frame
        tree_control_frame = ttk.Frame(right_frame)
        tree_control_frame.pack(fill=tk.X, pady=(0, 10))
        
        # Tree controls
        ttk.Button(tree_control_frame, text="Expand All", command=self.expand_all).pack(side=tk.LEFT, padx=(0, 5))
        ttk.Button(tree_control_frame, text="Collapse All", command=self.collapse_all).pack(side=tk.LEFT, padx=(0, 5))
        ttk.Button(tree_control_frame, text="Refresh", command=self.refresh_tree).pack(side=tk.LEFT, padx=(0, 5))
        
        # Selection controls
        ttk.Separator(tree_control_frame, orient=tk.VERTICAL).pack(side=tk.LEFT, fill=tk.Y, padx=10)
        ttk.Button(tree_control_frame, text="Select All", command=self.select_all_items).pack(side=tk.LEFT, padx=(0, 5))
        ttk.Button(tree_control_frame, text="Select None", command=self.select_no_items).pack(side=tk.LEFT, padx=(0, 5))
        ttk.Button(tree_control_frame, text="Export Selected", command=self.export_selected).pack(side=tk.LEFT, padx=(0, 5))

        # Database treeview with checkboxes
        tree_frame = ttk.Frame(right_frame)
        tree_frame.pack(fill=tk.BOTH, expand=True)
        
        self.db_tree = ttk.Treeview(tree_frame, columns=("Type", "Count", "Size", "Status", "Selected"), show="tree headings")

        self.db_tree.heading("#0", text="Name")
        self.db_tree.heading("Type", text="Type")
        self.db_tree.heading("Count", text="Count")
        self.db_tree.heading("Size", text="Size")
        self.db_tree.heading("Status", text="Status")
        self.db_tree.heading("Selected", text="Export")

        self.db_tree.column("#0", width=200)
        self.db_tree.column("Type", width=100)
        self.db_tree.column("Count", width=80)
        self.db_tree.column("Size", width=80)
        self.db_tree.column("Status", width=100)
        self.db_tree.column("Selected", width=60)

        # Scrollbars
        db_scrollbar_v = ttk.Scrollbar(tree_frame, orient=tk.VERTICAL, command=self.db_tree.yview)
        db_scrollbar_h = ttk.Scrollbar(tree_frame, orient=tk.HORIZONTAL, command=self.db_tree.xview)
        self.db_tree.configure(yscrollcommand=db_scrollbar_v.set, xscrollcommand=db_scrollbar_h.set)

        # Pack tree and scrollbars
        self.db_tree.grid(row=0, column=0, sticky="nsew")
        db_scrollbar_v.grid(row=0, column=1, sticky="ns")
        db_scrollbar_h.grid(row=1, column=0, sticky="ew")
        
        tree_frame.grid_rowconfigure(0, weight=1)
        tree_frame.grid_columnconfigure(0, weight=1)
        
        # Bind tree events
        self.db_tree.bind("<Double-1>", self.on_tree_double_click)
        self.db_tree.bind("<Button-1>", self.on_tree_click)
        self.db_tree.bind("<Key-space>", self.on_tree_space)
        
        # Selection tracking
        self.selected_items = set()        # Progress frame
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
        
    def select_vulnerability(self):
        """Select vulnerability for dumping"""
        if not self.vulnerabilities:
            messagebox.showwarning("Warning", "No vulnerabilities available")
            return
            
        # Simple selection for now
        if self.vulnerabilities:
            self.vuln_listbox.delete(0, tk.END)
            for i, vuln in enumerate(self.vulnerabilities):
                self.vuln_listbox.insert(tk.END, f"{i+1}. {vuln.url} - {vuln.injection_type.value}")
    
    def load_sqlmap_preset(self, preset_name):
        """Load SQLMap preset configuration"""
        if preset_name not in DEFAULT_CONFIGS:
            messagebox.showerror("Error", f"Unknown preset: {preset_name}")
            return
            
        config = DEFAULT_CONFIGS[preset_name]
        
        # Update GUI controls with preset values
        self.technique_var.set(config.technique.value)
        self.risk_var.set(config.risk.value)
        self.level_var.set(config.level.value)
        self.timeout_var.set(str(config.timeout))
        self.threads_var.set(str(config.threads))
        self.verbose_var.set(config.verbose > 1)
        
        # Show success message
        messagebox.showinfo("Success", f"Loaded {preset_name.title()} preset configuration")
                
    def enumerate_database(self):
        """Enumerate database structure"""
        if not self.vulnerabilities:
            messagebox.showwarning("Warning", "No vulnerability selected")
            return
            
        selected = self.vuln_listbox.curselection()
        if not selected:
            messagebox.showwarning("Warning", "Please select a vulnerability")
            return
            
        vuln = self.vulnerabilities[selected[0]]
        
        # Update UI
        self.enumerate_button.config(state=tk.DISABLED)
        self.dump_button.config(state=tk.DISABLED)
        self.stop_button.config(state=tk.NORMAL)
        self.progress_var.set(0)
        self.status_var.set("Enumerating database...")
        
        # Start enumeration
        self.enum_thread = threading.Thread(target=self.run_enumeration, args=(vuln,))
        self.enum_thread.daemon = True
        self.enum_thread.start()
        
    def run_enumeration(self, vulnerability: VulnerabilityResult):
        """Run enumeration in background using SQLMap"""
        try:
            config = {
                "MaxThreads": int(self.threads_var.get()),
                "PageSize": int(self.page_size_var.get()) if hasattr(self, 'page_size_var') else 50,
                "RequestDelay": int(self.delay_var.get()) if hasattr(self, 'delay_var') else 0,
                "RequestTimeout": int(self.timeout_var.get()),
                "SQLMapTechnique": self.technique_var.get(),
                "SQLMapRisk": int(self.risk_var.get()),
                "SQLMapLevel": int(self.level_var.get()),
                "UseSQLMap": self.use_sqlmap_var.get(),
                "VerboseOutput": self.verbose_var.get(),
                # SQLMap configuration for real SQLMap integration
                "sqlmap_config": {
                    'technique': self.technique_var.get(),
                    'risk': self.risk_var.get(),
                    'level': self.level_var.get(),
                    'timeout': int(self.timeout_var.get()) if self.timeout_var.get().isdigit() else 30,
                    'threads': int(self.threads_var.get()) if self.threads_var.get().isdigit() else 3,
                    'current_db': True,
                    'current_user': True,
                    'hostname': True,
                    'banner': True,
                    'enumerate_tables': True,
                    'enumerate_columns': True,
                    'enumerate_data': True,
                    'batch_mode': True,
                    'no_logging': True,
                    'flush_session': True,
                    'verbose': 1 if self.verbose_var.get() else 0
                }
            }
            
            self.database_dumper = DatabaseDumper(vulnerability, config)
            
            # Run enumeration with SQLMap
            asyncio.run(self.run_async_enumeration())
            
        except Exception as e:
            self.status_var.set(f"Error: {str(e)}")
            messagebox.showerror("Error", f"Enumeration failed: {str(e)}")
        finally:
            self.enumerate_button.config(state=tk.NORMAL)
            self.dump_button.config(state=tk.NORMAL)
            self.stop_button.config(state=tk.DISABLED)
            
    async def run_async_enumeration(self):
        """Run async enumeration with SQLMap"""
        try:
            # Update status
            self.status_var.set("Initializing SQLMap engine...")
            
            # Enumerate database
            database_info = await self.database_dumper.enumerate_database(
                callback=self.update_progress_callback
            )
            
            if database_info:
                self.database_info = [database_info]
                self.status_var.set(f"SQLMap enumeration completed: {len(database_info.tables)} tables found")
                
                # Update tree view
                self.after(0, self.update_tree_view)
            else:
                self.status_var.set("SQLMap enumeration failed")
                
        except Exception as e:
            self.status_var.set(f"SQLMap error: {str(e)}")
            raise
        finally:
            if self.database_dumper:
                await self.database_dumper.close()
                
    def update_progress_callback(self, message: str):
        """Update progress with SQLMap messages"""
        self.status_var.set(f"SQLMap: {message}")
        self.progress_var.set(self.progress_var.get() + 1)
        
    def update_tree_view(self):
        """Update tree view with database information"""
        if not self.database_info:
            return
            
        # Clear existing items
        for item in self.tree.get_children():
            self.tree.delete(item)
            
        # Add database info
        for db_info in self.database_info:
            db_item = self.tree.insert("", "end", text=f"Database: {db_info.name}", 
                                     values=("database", f"Version: {db_info.version}", f"User: {db_info.user}"))
            
            # Add tables
            for table in db_info.tables:
                table_item = self.tree.insert(db_item, "end", text=f"Table: {table.name}", 
                                            values=("table", f"Rows: {table.row_count}", f"Columns: {len(table.columns)}"))
                
                # Add columns
                for column in table.columns:
                    self.tree.insert(table_item, "end", text=f"Column: {column.name}", 
                                   values=("column", f"Type: {column.data_type}", f"Nullable: {column.nullable}"))
        
        # Expand all items
        self.tree.item("", open=True)
        for item in self.tree.get_children():
            self.tree.item(item, open=True)
        
    def enumeration_completed(self):
        """Enumeration completed"""
        self.enumerate_button.config(state=tk.NORMAL)
        self.dump_button.config(state=tk.NORMAL)
        self.stop_button.config(state=tk.DISABLED)
        self.export_button.config(state=tk.NORMAL)
        self.progress_var.set(100)
        self.status_var.set("Enumeration completed")
        
    def dump_database(self):
        """Dump database data with advanced options"""
        if not self.database_info:
            messagebox.showwarning("Warning", "No database structure available")
            return
            
        # Validate advanced options
        try:
            max_rows = int(self.max_rows_var.get()) if self.max_rows_var.get() else 1000
            delay = int(self.delay_var.get()) if self.delay_var.get() else 1000
            page_size = int(self.page_size_var.get()) if self.page_size_var.get() else 100
        except ValueError:
            messagebox.showerror("Error", "Invalid numeric values in configuration")
            return
            
        # Prepare dump configuration with SQLMap settings
        dump_config = {
            'smart_dump': self.smart_dump_var.get(),
            'skip_empty': self.skip_empty_var.get(),
            'resume_dump': self.resume_dump_var.get(),
            'max_rows': max_rows,
            'delay': delay,
            'page_size': page_size,
            'table_filter': self.table_filter_var.get().strip(),
            'exclude_tables': [t.strip() for t in self.exclude_tables_var.get().split(',') if t.strip()],
            'selected_items': self.selected_items.copy(),
            # SQLMap configuration
            'sqlmap_config': {
                'technique': self.technique_var.get(),
                'risk': self.risk_var.get(),
                'level': self.level_var.get(),
                'timeout': int(self.timeout_var.get()) if self.timeout_var.get().isdigit() else 30,
                'threads': int(self.threads_var.get()) if self.threads_var.get().isdigit() else 3,
                'use_sqlmap': self.use_sqlmap_var.get(),
                'verbose': self.verbose_var.get()
            }
        }
        
        # Update UI
        self.dump_button.config(state=tk.DISABLED)
        self.stop_button.config(state=tk.NORMAL)
        self.is_dumping = True
        
        # Start enhanced dump
        self.dump_thread = threading.Thread(target=self.run_advanced_dump, args=(dump_config,))
        self.dump_thread.daemon = True
        self.dump_thread.start()
        
    def run_advanced_dump(self, config):
        """Run advanced database dump with smart features"""
        try:
            if not self.database_dumper:
                self.dump_progress_callback("Initializing dumper...")
                return
                
            # Apply configuration to dumper
            self.configure_dumper(config)
            
            # Smart dumping logic
            if config['smart_dump']:
                self.dump_progress_callback("Starting smart dump analysis...")
                filtered_data = self.apply_smart_filters(config)
            else:
                filtered_data = self.database_info
                
            # Dump filtered data
            for db_idx, db in enumerate(filtered_data):
                if not self.is_dumping:
                    break
                    
                self.dump_progress_callback(f"Dumping database: {db.name}")
                
                for table_idx, table in enumerate(db.tables):
                    if not self.is_dumping:
                        break
                        
                    # Check if table should be processed
                    if self.should_process_table(table, config):
                        self.dump_progress_callback(f"Dumping table: {table.name}")
                        
                        # Update tree status
                        self.mark_item_in_progress(f"table_{db.name}_{table.name}")
                        
                        # Dump table data
                        success = self.dump_table_data(db, table, config)
                        
                        if success:
                            self.mark_item_completed(f"table_{db.name}_{table.name}")
                        else:
                            self.mark_item_error(f"table_{db.name}_{table.name}")
                            
                    # Update progress
                    progress = ((db_idx * len(db.tables) + table_idx + 1) / 
                              sum(len(db.tables) for db in filtered_data)) * 100
                    self.after(0, lambda p=progress: self.progress_var.set(p))
                    
            self.after(0, self.dump_completed)
            
        except Exception as e:
            self.after(0, lambda: messagebox.showerror("Dump Error", f"Dump failed: {str(e)}"))
            self.after(0, self.dump_completed)
            
    def configure_dumper(self, config):
        """Configure dumper with advanced options"""
        if hasattr(self.database_dumper, 'set_config'):
            self.database_dumper.set_config({
                'max_rows_per_table': config['max_rows'],
                'request_delay': config['delay'] / 1000.0,  # Convert to seconds
                'page_size': config['page_size'],
                'resume_enabled': config['resume_dump']
            })
            
    def apply_smart_filters(self, config):
        """Apply smart filtering to reduce dump size"""
        filtered_data = []
        
        for db in self.database_info:
            filtered_db = DatabaseInfo(db.name, db.version)
            
            for table in db.tables:
                # Smart filtering logic
                if self.is_table_interesting(table, config):
                    filtered_db.tables.append(table)
                    
            if filtered_db.tables:
                filtered_data.append(filtered_db)
                
        return filtered_data
        
    def is_table_interesting(self, table, config):
        """Determine if table is interesting for dumping"""
        table_name = table.name.lower()
        
        # Skip excluded tables
        excluded = [name.lower() for name in config['exclude_tables']]
        if any(exc in table_name for exc in excluded):
            return False
            
        # Apply table filter
        if config['table_filter']:
            filter_terms = [term.strip().lower() for term in config['table_filter'].split(',')]
            if not any(term in table_name for term in filter_terms):
                return False
                
        # Skip empty tables if configured
        if config['skip_empty'] and hasattr(table, 'row_count') and table.row_count == 0:
            return False
            
        # Check if selected for export
        if config['selected_items']:
            table_tag = f"table_{table.name}"  # Simplified for this check
            db_selected = any('db_' in tag for tag in config['selected_items'])
            table_selected = any(table_tag in tag for tag in config['selected_items'])
            if not (db_selected or table_selected):
                return False
                
        return True
        
    def should_process_table(self, table, config):
        """Check if table should be processed based on configuration"""
        return self.is_table_interesting(table, config)
        
    def dump_table_data(self, db, table, config):
        """Dump individual table data"""
        try:
            # Simulate table dumping (in real implementation, this would call the dumper)
            import time
            time.sleep(config['delay'] / 1000.0)  # Respect delay
            
            # Update table with dump status
            table.is_dumped = True
            
            return True
        except Exception as e:
            print(f"Table dump error: {e}")
            return False
            
    def mark_item_in_progress(self, item_tag):
        """Mark tree item as in progress"""
        self.after(0, lambda: self.update_item_status(item_tag, "🔄 Dumping..."))
        
    def mark_item_completed(self, item_tag):
        """Mark tree item as completed"""
        self.after(0, lambda: self.update_item_status(item_tag, "✅ Completed"))
        
    def mark_item_error(self, item_tag):
        """Mark tree item as error"""
        self.after(0, lambda: self.update_item_status(item_tag, "❌ Error"))
        
    def update_item_status(self, item_tag, status):
        """Update tree item status"""
        try:
            for item in self.db_tree.get_children():
                self.find_and_update_item(item, item_tag, status)
        except Exception as e:
            print(f"Status update error: {e}")
            
    def find_and_update_item(self, item, target_tag, status):
        """Recursively find and update tree item"""
        try:
            tags = self.db_tree.item(item, "tags")
            if tags and target_tag in tags[0]:
                values = list(self.db_tree.item(item, "values"))
                if len(values) >= 4:
                    values[3] = status
                    self.db_tree.item(item, values=values)
                return True
                
            # Check children
            for child in self.db_tree.get_children(item):
                if self.find_and_update_item(child, target_tag, status):
                    return True
                    
        except Exception as e:
            print(f"Item update error: {e}")
            
        return False
        
    def run_dump(self):
        """Run dump in background"""
        try:
            if self.database_dumper and self.database_info:
                loop = asyncio.new_event_loop()
                asyncio.set_event_loop(loop)
                
                try:
                    dumped_db = loop.run_until_complete(
                        self.database_dumper.dump_database(self.database_info[0], self.dump_progress_callback)
                    )
                    
                    self.database_info = [dumped_db]
                    self.update_database_tree()
                    
                finally:
                    loop.close()
                    
        except Exception as e:
            self.after(0, lambda: messagebox.showerror("Error", f"Dump failed:\n{str(e)}"))
            
        finally:
            self.after(0, self.dump_completed)
            
    def dump_progress_callback(self, message: str):
        """Dump progress callback with real-time tree updates"""
        self.after(0, lambda: self.status_var.set(message))
        
        if self.database_dumper and self.database_dumper.progress:
            progress = self.database_dumper.progress.progress_percentage
            self.after(0, lambda: self.progress_var.set(progress))
            
            # Update tree view with real-time progress
            self.after(0, self.update_tree_progress)
            
    def update_tree_progress(self):
        """Update tree items with current dumping progress"""
        if not self.database_dumper or not hasattr(self.database_dumper, 'progress'):
            return
            
        # Update tree items based on dumper progress
        try:
            for item in self.db_tree.get_children():
                self.update_item_progress(item)
        except Exception as e:
            print(f"Tree progress update error: {e}")
            
    def update_item_progress(self, item):
        """Update individual tree item progress"""
        try:
            values = list(self.db_tree.item(item, "values"))
            tags = self.db_tree.item(item, "tags")
            
            if len(values) >= 4 and tags:
                tag = tags[0]
                
                # Determine progress status
                if self.database_dumper and hasattr(self.database_dumper, 'current_operation'):
                    current_op = self.database_dumper.current_operation or ""
                    
                    if tag.replace("_", " ") in current_op.lower():
                        values[3] = "🔄 Dumping..."
                    elif hasattr(self.database_dumper, 'completed_items'):
                        completed = getattr(self.database_dumper, 'completed_items', set())
                        if tag in completed:
                            values[3] = "✅ Completed"
                        
                self.db_tree.item(item, values=values)
                
            # Update children recursively
            for child in self.db_tree.get_children(item):
                self.update_item_progress(child)
                
        except Exception as e:
            print(f"Item progress update error: {e}")
            
    def dump_completed(self):
        """Dump completed"""
        self.dump_button.config(state=tk.NORMAL)
        self.stop_button.config(state=tk.DISABLED)
        self.is_dumping = False
        self.progress_var.set(100)
        self.status_var.set("Dump completed")
        
    def stop_dump(self):
        """Stop dump operation"""
        if self.database_dumper:
            self.database_dumper.cancel_dump()
        self.is_dumping = False
        
    def update_database_tree(self):
        """Update database tree display"""
        self.after(0, self._update_database_tree)
        
    def _update_database_tree(self):
        """Update database tree (main thread)"""
        self.db_tree.delete(*self.db_tree.get_children())
        
        for db in self.database_info:
            # Add database node
            status = "✓ Dumped" if hasattr(db, 'is_dumped') and db.is_dumped else "⏳ Pending"
            selected = "☑" if f"db_{db.name}" in self.selected_items else "☐"
            
            db_node = self.db_tree.insert("", tk.END, text=db.name or "Database", 
                                        values=("Database", len(db.tables), f"{db.version}", status, selected),
                                        tags=(f"db_{db.name}",))

            # Add tables
            for table in db.tables:
                table_status = "✓ Dumped" if hasattr(table, 'is_dumped') and table.is_dumped else "⏳ Pending"
                table_selected = "☑" if f"table_{db.name}_{table.name}" in self.selected_items else "☐"
                
                table_node = self.db_tree.insert(db_node, tk.END, text=table.name,
                                               values=("Table", table.row_count, f"{len(table.columns)} cols", table_status, table_selected),
                                               tags=(f"table_{db.name}_{table.name}",))

                # Add columns
                for column in table.columns:
                    col_status = "✓ Info" if hasattr(column, 'is_analyzed') and column.is_analyzed else "📋 Ready"
                    col_selected = "☑" if f"col_{db.name}_{table.name}_{column.name}" in self.selected_items else "☐"
                    
                    self.db_tree.insert(table_node, tk.END, text=column.name,
                                      values=("Column", column.type, f"{column.length}", col_status, col_selected),
                                      tags=(f"col_{db.name}_{table.name}_{column.name}",))

        # Apply selection styling
        self.update_tree_styling()
        
        # Auto-expand first level by default
        for db_node in self.db_tree.get_children():
            self.db_tree.item(db_node, open=True)
            
    def update_tree_styling(self):
        """Update tree styling based on selection and status"""
        # Configure tags for different states
        self.db_tree.tag_configure("selected", background="#E3F2FD")
        self.db_tree.tag_configure("dumped", foreground="#4CAF50")
        self.db_tree.tag_configure("pending", foreground="#FF9800")
        self.db_tree.tag_configure("error", foreground="#F44336")
        
    def on_tree_click(self, event):
        """Handle tree click events"""
        item = self.db_tree.identify("item", event.x, event.y)
        column = self.db_tree.identify("column", event.x, event.y)
        
        # If clicked on "Selected" column, toggle selection
        if column == "#6" and item:  # Selected column
            self.toggle_item_selection(item)
            
    def on_tree_double_click(self, event):
        """Handle tree double-click events"""
        item = self.db_tree.selection()[0] if self.db_tree.selection() else None
        if item:
            # Show detailed information
            self.show_item_details(item)
            
    def on_tree_space(self, event):
        """Handle space key press on tree"""
        selection = self.db_tree.selection()
        if selection:
            self.toggle_item_selection(selection[0])
            
    def toggle_item_selection(self, item):
        """Toggle selection state of tree item"""
        if not item:
            return
            
        tags = self.db_tree.item(item, "tags")
        if tags:
            tag = tags[0]
            if tag in self.selected_items:
                self.selected_items.remove(tag)
                # Update display
                values = list(self.db_tree.item(item, "values"))
                if len(values) >= 5:
                    values[4] = "☐"
                    self.db_tree.item(item, values=values)
            else:
                self.selected_items.add(tag)
                # Update display
                values = list(self.db_tree.item(item, "values"))
                if len(values) >= 5:
                    values[4] = "☑"
                    self.db_tree.item(item, values=values)
                    
        # Auto-select/deselect children
        self.update_child_selection(item)
        
    def update_child_selection(self, parent_item):
        """Update child selection based on parent"""
        parent_tags = self.db_tree.item(parent_item, "tags")
        if parent_tags:
            parent_tag = parent_tags[0]
            is_selected = parent_tag in self.selected_items
            
            # Update all children
            for child in self.db_tree.get_children(parent_item):
                child_tags = self.db_tree.item(child, "tags")
                if child_tags:
                    child_tag = child_tags[0]
                    if is_selected:
                        self.selected_items.add(child_tag)
                    else:
                        self.selected_items.discard(child_tag)
                        
                    # Update display
                    values = list(self.db_tree.item(child, "values"))
                    if len(values) >= 5:
                        values[4] = "☑" if is_selected else "☐"
                        self.db_tree.item(child, values=values)
                        
                    # Recursively update grandchildren
                    self.update_child_selection(child)
                    
    def show_item_details(self, item):
        """Show detailed information about selected item"""
        values = self.db_tree.item(item, "values")
        text = self.db_tree.item(item, "text")
        
        if len(values) >= 3:
            item_type = values[0]
            details = f"Name: {text}\nType: {item_type}\n"
            
            if item_type == "Database":
                details += f"Version: {values[2]}\nTables: {values[1]}"
            elif item_type == "Table":
                details += f"Columns: {values[2]}\nRows: {values[1]}"
            elif item_type == "Column":
                details += f"Data Type: {values[1]}\nLength: {values[2]}"
                
            messagebox.showinfo(f"{item_type} Details", details)
            
    def collapse_all(self):
        """Collapse all tree nodes"""
        def collapse_node(node):
            self.db_tree.item(node, open=False)
            for child in self.db_tree.get_children(node):
                collapse_node(child)
                
        for node in self.db_tree.get_children():
            collapse_node(node)
            
    def refresh_tree(self):
        """Refresh the tree view"""
        self.update_database_tree()
        
    def select_all_items(self):
        """Select all items in tree"""
        def select_node(node):
            tags = self.db_tree.item(node, "tags")
            if tags:
                self.selected_items.add(tags[0])
                # Update display
                values = list(self.db_tree.item(node, "values"))
                if len(values) >= 5:
                    values[4] = "☑"
                    self.db_tree.item(node, values=values)
                    
            for child in self.db_tree.get_children(node):
                select_node(child)
                
        for node in self.db_tree.get_children():
            select_node(node)
            
    def select_no_items(self):
        """Deselect all items in tree"""
        self.selected_items.clear()
        
        def deselect_node(node):
            values = list(self.db_tree.item(node, "values"))
            if len(values) >= 5:
                values[4] = "☐"
                self.db_tree.item(node, values=values)
                
            for child in self.db_tree.get_children(node):
                deselect_node(child)
                
        for node in self.db_tree.get_children():
            deselect_node(node)
            
    def export_selected(self):
        """Export only selected items"""
        if not self.selected_items:
            messagebox.showwarning("Warning", "No items selected for export")
            return
            
        # Get export format
        export_format = self.export_format_var.get()
        
        # Get save location
        file_types = {
            "json": [("JSON files", "*.json")],
            "xml": [("XML files", "*.xml")], 
            "csv": [("CSV files", "*.csv")],
            "sql": [("SQL files", "*.sql")]
        }.get(export_format, [("All files", "*.*")])
        
        filename = filedialog.asksaveasfilename(
            title="Export Selected Data",
            filetypes=file_types,
            defaultextension=f".{export_format}"
        )
        
        if filename:
            try:
                # Filter data based on selection
                selected_data = self.filter_selected_data()
                
                # Export using appropriate format
                success = self.export_data_to_file(selected_data, filename, export_format)
                
                if success:
                    messagebox.showinfo("Success", f"Selected data exported to {filename}")
                else:
                    messagebox.showerror("Error", "Failed to export selected data")
                    
            except Exception as e:
                messagebox.showerror("Error", f"Export failed: {str(e)}")
                
    def filter_selected_data(self):
        """Filter database info based on selected items"""
        filtered_data = []
        
        for db in self.database_info:
            db_tag = f"db_{db.name}"
            
            # Check if database or any of its children are selected
            if (db_tag in self.selected_items or 
                any(f"table_{db.name}_" in tag for tag in self.selected_items) or
                any(f"col_{db.name}_" in tag for tag in self.selected_items)):
                
                # Create filtered database copy
                filtered_db = DatabaseInfo(db.name, db.version)
                
                for table in db.tables:
                    table_tag = f"table_{db.name}_{table.name}"
                    
                    # Check if table or any of its columns are selected
                    if (db_tag in self.selected_items or 
                        table_tag in self.selected_items or
                        any(f"col_{db.name}_{table.name}_" in tag for tag in self.selected_items)):
                        
                        # Create filtered table copy
                        filtered_table = type(table)(table.name)
                        filtered_table.row_count = table.row_count
                        
                        for column in table.columns:
                            col_tag = f"col_{db.name}_{table.name}_{column.name}"
                            
                            # Include column if selected or parent is selected
                            if (db_tag in self.selected_items or 
                                table_tag in self.selected_items or
                                col_tag in self.selected_items):
                                filtered_table.columns.append(column)
                                
                        if filtered_table.columns:
                            filtered_db.tables.append(filtered_table)
                            
                if filtered_db.tables:
                    filtered_data.append(filtered_db)
                    
        return filtered_data
        
    def export_data_to_file(self, data, filename, format_type):
        """Export filtered data to file"""
        try:
            if self.database_dumper:
                # Use existing dumper export functionality
                export_format = ExportFormat[format_type.upper()]
                return self.database_dumper.export_data(data, Path(filename), export_format)
            else:
                # Fallback basic export
                import json
                with open(filename, 'w') as f:
                    # Convert to serializable format
                    export_data = []
                    for db in data:
                        db_data = {
                            "name": db.name,
                            "version": db.version,
                            "tables": []
                        }
                        for table in db.tables:
                            table_data = {
                                "name": table.name,
                                "row_count": table.row_count,
                                "columns": [{"name": col.name, "type": col.type, "length": col.length} 
                                          for col in table.columns]
                            }
                            db_data["tables"].append(table_data)
                        export_data.append(db_data)
                    
                    json.dump(export_data, f, indent=2)
                return True
                
        except Exception as e:
            print(f"Export error: {e}")
            return False
            
    def expand_all(self):
        """Expand all tree nodes"""
        def expand_node(node):
            self.db_tree.item(node, open=True)
            for child in self.db_tree.get_children(node):
                expand_node(child)
                
        for node in self.db_tree.get_children():
            expand_node(node)
            
    def export_results(self):
        """Export dump results"""
        if not self.database_info:
            messagebox.showwarning("Warning", "No data to export")
            return
            
        file_path = filedialog.asksaveasfilename(
            title="Export Database",
            defaultextension=f".{self.format_var.get()}",
            filetypes=[
                ("JSON files", "*.json"),
                ("CSV files", "*.csv"),
                ("XML files", "*.xml"),
                ("SQL files", "*.sql"),
                ("HTML files", "*.html")
            ]
        )
        
        if file_path:
            try:
                format_type = ExportFormat(self.format_var.get())
                self.database_dumper.export_data(self.database_info[0], format_type, file_path)
                messagebox.showinfo("Success", f"Data exported to {file_path}")
                
            except Exception as e:
                messagebox.showerror("Error", f"Failed to export data:\n{str(e)}")
                
    def clear_results(self):
        """Clear dump results"""
        self.vulnerabilities.clear()
        self.database_info.clear()
        self.vuln_listbox.delete(0, tk.END)
        self.db_tree.delete(*self.db_tree.get_children())
        self.progress_var.set(0)
        self.status_var.set("Ready")
        self.enumerate_button.config(state=tk.NORMAL)
        self.dump_button.config(state=tk.DISABLED)
        self.export_button.config(state=tk.DISABLED)
        
    def is_running(self) -> bool:
        """Check if dumping is running"""
        return self.is_dumping
        
    def cancel_operation(self):
        """Cancel current operation"""
        if self.is_dumping:
            self.stop_dump()
            
    def get_state(self) -> Dict[str, Any]:
        """Get current state"""
        return {
            "threads": self.threads_var.get(),
            "page_size": self.page_size_var.get(),
            "delay": self.delay_var.get(),
            "format": self.format_var.get()
        }
        
    def set_state(self, state: Dict[str, Any]):
        """Set state"""
        if "threads" in state:
            self.threads_var.set(state["threads"])
        if "page_size" in state:
            self.page_size_var.set(state["page_size"])
        if "delay" in state:
            self.delay_var.set(state["delay"])
        if "format" in state:
            self.format_var.set(state["format"])
            
    def import_vulnerabilities(self, vulnerabilities: List[VulnerabilityResult]):
        """Import vulnerabilities from tester"""
        self.vulnerabilities = vulnerabilities
        self.select_vulnerability()
        
    def export_results(self):
        """Export current results"""
        self.export_results()  # Already implemented above