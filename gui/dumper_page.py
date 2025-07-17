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

from ..core.database_dumper import DatabaseDumper, DatabaseInfo, ExportFormat
from ..core.sql_injection_engine import VulnerabilityResult

class DumperPage(ttk.Frame):
    """Database dumper page"""
    
    def __init__(self, parent, app):
        super().__init__(parent)
        self.app = app
        self.database_dumper = None
        self.vulnerabilities: List[VulnerabilityResult] = []
        self.database_info: List[DatabaseInfo] = []
        self.is_dumping = False
        
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
        self.format_var = tk.StringVar(value="json")
        format_combo = ttk.Combobox(options_frame, textvariable=self.format_var, 
                                   values=["json", "csv", "xml", "sql", "html"], state="readonly")
        format_combo.pack(anchor=tk.W, pady=(0, 5))
        
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
        
        # Database treeview
        self.db_tree = ttk.Treeview(right_frame, columns=("Type", "Count", "Size"), show="tree headings")
        
        self.db_tree.heading("#0", text="Name")
        self.db_tree.heading("Type", text="Type")
        self.db_tree.heading("Count", text="Count")
        self.db_tree.heading("Size", text="Size")
        
        self.db_tree.column("#0", width=200)
        self.db_tree.column("Type", width=100)
        self.db_tree.column("Count", width=80)
        self.db_tree.column("Size", width=80)
        
        # Scrollbar
        db_scrollbar = ttk.Scrollbar(right_frame, orient=tk.VERTICAL, command=self.db_tree.yview)
        self.db_tree.configure(yscrollcommand=db_scrollbar.set)
        
        self.db_tree.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        db_scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
        
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
        """Run enumeration in background"""
        try:
            config = {
                "MaxThreads": int(self.threads_var.get()),
                "PageSize": int(self.page_size_var.get()),
                "RequestDelay": int(self.delay_var.get()),
                "RequestTimeout": 30
            }
            
            self.database_dumper = DatabaseDumper(vulnerability, config)
            
            # Run enumeration
            loop = asyncio.new_event_loop()
            asyncio.set_event_loop(loop)
            
            try:
                db_info = loop.run_until_complete(
                    self.database_dumper.enumerate_database(self.enum_progress_callback)
                )
                
                self.database_info = [db_info]
                self.update_database_tree()
                
            finally:
                loop.close()
                
        except Exception as e:
            self.after(0, lambda: messagebox.showerror("Error", f"Enumeration failed:\n{str(e)}"))
            
        finally:
            self.after(0, self.enumeration_completed)
            
    def enum_progress_callback(self, message: str):
        """Enumeration progress callback"""
        self.after(0, lambda: self.status_var.set(message))
        
    def enumeration_completed(self):
        """Enumeration completed"""
        self.enumerate_button.config(state=tk.NORMAL)
        self.dump_button.config(state=tk.NORMAL)
        self.stop_button.config(state=tk.DISABLED)
        self.export_button.config(state=tk.NORMAL)
        self.progress_var.set(100)
        self.status_var.set("Enumeration completed")
        
    def dump_database(self):
        """Dump database data"""
        if not self.database_info:
            messagebox.showwarning("Warning", "No database structure available")
            return
            
        # Update UI
        self.dump_button.config(state=tk.DISABLED)
        self.stop_button.config(state=tk.NORMAL)
        self.is_dumping = True
        
        # Start dump
        self.dump_thread = threading.Thread(target=self.run_dump)
        self.dump_thread.daemon = True
        self.dump_thread.start()
        
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
        """Dump progress callback"""
        self.after(0, lambda: self.status_var.set(message))
        
        if self.database_dumper and self.database_dumper.progress:
            progress = self.database_dumper.progress.progress_percentage
            self.after(0, lambda: self.progress_var.set(progress))
            
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
            db_node = self.db_tree.insert("", tk.END, text=db.name or "Database", 
                                        values=("Database", len(db.tables), f"{db.version}"))
            
            # Add tables
            for table in db.tables:
                table_node = self.db_tree.insert(db_node, tk.END, text=table.name,
                                               values=("Table", table.row_count, f"{len(table.columns)} cols"))
                
                # Add columns
                for column in table.columns:
                    self.db_tree.insert(table_node, tk.END, text=column.name,
                                      values=("Column", column.type, f"{column.length}"))
                    
        # Expand all
        self.expand_all()
        
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