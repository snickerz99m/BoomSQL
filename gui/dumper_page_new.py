"""
Completely Redesigned Database Dumper Page for BoomSQL
Clean, modern GUI with guaranteed button visibility
"""

import tkinter as tk
from tkinter import ttk, messagebox, filedialog
import asyncio
import threading
from typing import List, Dict, Any, Optional
from pathlib import Path

from core.database_dumper import DatabaseDumper, DatabaseInfo
from core.sql_injection_engine import VulnerabilityResult

class DumperPageNew(ttk.Frame):
    """Redesigned database dumper page with better layout"""
    
    def __init__(self, parent, app):
        super().__init__(parent)
        self.app = app
        self.dumper = None
        self.vulnerabilities: List[VulnerabilityResult] = []
        self.database_info: Optional[DatabaseInfo] = None
        self.is_dumping = False
        
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
        
        # 1. Vulnerability Selection Section
        vuln_frame = ttk.LabelFrame(left_container, text="Vulnerability Selection", padding="10")
        vuln_frame.grid(row=0, column=0, sticky="ew", pady=(0, 10))
        vuln_frame.grid_columnconfigure(0, weight=1)
        
        # Vulnerability list
        list_frame = ttk.Frame(vuln_frame)
        list_frame.grid(row=0, column=0, sticky="ew", pady=(0, 5))
        list_frame.grid_columnconfigure(0, weight=1)
        
        vuln_scroll = ttk.Scrollbar(list_frame)
        vuln_scroll.grid(row=0, column=1, sticky="ns")
        
        self.vuln_listbox = tk.Listbox(list_frame, yscrollcommand=vuln_scroll.set, height=4)
        self.vuln_listbox.grid(row=0, column=0, sticky="ew")
        vuln_scroll.config(command=self.vuln_listbox.yview)
        self.vuln_listbox.bind("<<ListboxSelect>>", self.on_vulnerability_select)
        
        # Vulnerability info
        info_frame = ttk.Frame(vuln_frame)
        info_frame.grid(row=1, column=0, sticky="ew", pady=(5, 0))
        
        self.vuln_info_label = ttk.Label(info_frame, text="Select a vulnerability to begin", foreground="gray")
        self.vuln_info_label.pack(anchor=tk.W)
        
        # 2. SQLMap Configuration Section
        config_frame = ttk.LabelFrame(left_container, text="SQLMap Configuration", padding="10")
        config_frame.grid(row=1, column=0, sticky="ew", pady=(0, 10))
        config_frame.grid_columnconfigure(1, weight=1)
        
        row = 0
        
        # Technique
        ttk.Label(config_frame, text="Technique:").grid(row=row, column=0, sticky="w", pady=2)
        self.technique_var = tk.StringVar(value="BEUTS")
        technique_combo = ttk.Combobox(config_frame, textvariable=self.technique_var, 
                                     values=["B", "E", "U", "T", "S", "BEUTS"], width=12)
        technique_combo.grid(row=row, column=1, sticky="w", padx=(10, 0), pady=2)
        row += 1
        
        # Risk level
        ttk.Label(config_frame, text="Risk Level:").grid(row=row, column=0, sticky="w", pady=2)
        self.risk_var = tk.StringVar(value="1")
        risk_combo = ttk.Combobox(config_frame, textvariable=self.risk_var, 
                                values=["1", "2", "3"], width=12)
        risk_combo.grid(row=row, column=1, sticky="w", padx=(10, 0), pady=2)
        row += 1
        
        # Level
        ttk.Label(config_frame, text="Level:").grid(row=row, column=0, sticky="w", pady=2)
        self.level_var = tk.StringVar(value="1")
        level_combo = ttk.Combobox(config_frame, textvariable=self.level_var, 
                                 values=["1", "2", "3", "4", "5"], width=12)
        level_combo.grid(row=row, column=1, sticky="w", padx=(10, 0), pady=2)
        row += 1
        
        # Timeout
        ttk.Label(config_frame, text="Timeout (s):").grid(row=row, column=0, sticky="w", pady=2)
        self.timeout_var = tk.StringVar(value="30")
        ttk.Entry(config_frame, textvariable=self.timeout_var, width=12).grid(row=row, column=1, sticky="w", padx=(10, 0), pady=2)
        
        # 3. Database Information Section
        db_info_frame = ttk.LabelFrame(left_container, text="Database Information", padding="10")
        db_info_frame.grid(row=2, column=0, sticky="ew", pady=(0, 10))
        
        self.db_info_text = tk.Text(db_info_frame, height=6, wrap=tk.WORD, state=tk.DISABLED, 
                                   bg='#f8f9fa', relief=tk.FLAT, font=('Arial', 9))
        self.db_info_text.pack(fill=tk.BOTH, expand=True)
        self._update_db_info_display()
        
        # 4. Workflow Instructions
        workflow_frame = ttk.LabelFrame(left_container, text="Workflow", padding="10")
        workflow_frame.grid(row=3, column=0, sticky="ew", pady=(0, 10))
        
        workflow_text = tk.Text(workflow_frame, height=4, wrap=tk.WORD, state=tk.DISABLED, 
                               bg='#f8f9fa', relief=tk.FLAT, font=('Arial', 9))
        workflow_instructions = """1. Select vulnerability above
2. Click 'ENUMERATE DATABASE'
3. Click 'DUMP DATA' to extract
4. View results in right panel"""
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
        
        # ENUMERATE BUTTON - Large and prominent
        self.enumerate_button = ttk.Button(
            button_container, 
            text="🔍 ENUMERATE DATABASE", 
            command=self.enumerate_database,
            width=20,
            style="Accent.TButton",
            state=tk.DISABLED
        )
        self.enumerate_button.grid(row=0, column=0, padx=5, pady=5, sticky="ew")
        
        # DUMP BUTTON - Large and prominent
        self.dump_button = ttk.Button(
            button_container, 
            text="📦 DUMP DATA", 
            command=self.dump_database,
            width=20,
            state=tk.DISABLED
        )
        self.dump_button.grid(row=0, column=1, padx=5, pady=5, sticky="ew")
        
        # Secondary buttons row
        button_container2 = ttk.Frame(control_frame)
        button_container2.grid(row=1, column=0, sticky="ew", pady=(10, 0))
        button_container2.grid_columnconfigure(0, weight=1)
        button_container2.grid_columnconfigure(1, weight=1)
        button_container2.grid_columnconfigure(2, weight=1)
        
        # STOP BUTTON
        self.stop_button = ttk.Button(
            button_container2, 
            text="🛑 STOP", 
            command=self.stop_dumping,
            width=15,
            state=tk.DISABLED
        )
        self.stop_button.grid(row=0, column=0, padx=2, pady=2, sticky="ew")
        
        # CLEAR BUTTON
        self.clear_button = ttk.Button(
            button_container2, 
            text="🗑️ CLEAR", 
            command=self.clear_results,
            width=15
        )
        self.clear_button.grid(row=0, column=1, padx=2, pady=2, sticky="ew")
        
        # EXPORT BUTTON
        self.export_button = ttk.Button(
            button_container2, 
            text="💾 EXPORT", 
            command=self.export_data,
            width=15,
            state=tk.DISABLED
        )
        self.export_button.grid(row=0, column=2, padx=2, pady=2, sticky="ew")
        
        # Status indicator
        status_frame = ttk.Frame(control_frame)
        status_frame.grid(row=2, column=0, sticky="ew", pady=(10, 0))
        
        ttk.Label(status_frame, text="Status:").pack(side=tk.LEFT)
        self.status_label = ttk.Label(status_frame, text="Ready", foreground="green")
        self.status_label.pack(side=tk.LEFT, padx=(5, 0))
        
        # Progress bar
        self.progress_bar = ttk.Progressbar(control_frame, mode='indeterminate')
        self.progress_bar.grid(row=3, column=0, sticky="ew", pady=(10, 0))
        
    def create_right_panel(self):
        """Create right results panel"""
        
        # Right panel container
        right_container = ttk.LabelFrame(self, text="Database Content", padding="10")
        right_container.grid(row=0, column=1, sticky="nsew")
        right_container.grid_rowconfigure(0, weight=1)
        right_container.grid_columnconfigure(0, weight=1)
        
        # Results notebook
        self.results_notebook = ttk.Notebook(right_container)
        self.results_notebook.grid(row=0, column=0, sticky="nsew")
        
        # Create result tabs
        self.create_database_tab()
        self.create_tables_tab()
        self.create_data_tab()
        self.create_logs_tab()
        
    def create_database_tab(self):
        """Create database overview tab"""
        
        # Database tab
        db_frame = ttk.Frame(self.results_notebook)
        self.results_notebook.add(db_frame, text="Database Overview")
        
        db_frame.grid_rowconfigure(0, weight=1)
        db_frame.grid_columnconfigure(0, weight=1)
        
        # Database info display
        self.db_overview_text = tk.Text(db_frame, wrap=tk.WORD, state=tk.DISABLED, font=('Consolas', 10))
        db_scroll = ttk.Scrollbar(db_frame, orient=tk.VERTICAL, command=self.db_overview_text.yview)
        self.db_overview_text.configure(yscrollcommand=db_scroll.set)
        
        self.db_overview_text.grid(row=0, column=0, sticky="nsew")
        db_scroll.grid(row=0, column=1, sticky="ns")
        
    def create_tables_tab(self):
        """Create tables tab"""
        
        # Tables tab
        tables_frame = ttk.Frame(self.results_notebook)
        self.results_notebook.add(tables_frame, text="Tables & Structure")
        
        tables_frame.grid_rowconfigure(0, weight=1)
        tables_frame.grid_columnconfigure(0, weight=1)
        
        # Tables treeview
        columns = ("Table", "Rows", "Columns")
        self.tables_tree = ttk.Treeview(tables_frame, columns=columns, show="headings", height=20)
        
        # Configure columns
        self.tables_tree.heading("Table", text="Table Name")
        self.tables_tree.heading("Rows", text="Row Count")
        self.tables_tree.heading("Columns", text="Column Count")
        
        # Column widths
        self.tables_tree.column("Table", width=200)
        self.tables_tree.column("Rows", width=100)
        self.tables_tree.column("Columns", width=100)
        
        # Scrollbars
        tables_scroll_y = ttk.Scrollbar(tables_frame, orient=tk.VERTICAL, command=self.tables_tree.yview)
        tables_scroll_x = ttk.Scrollbar(tables_frame, orient=tk.HORIZONTAL, command=self.tables_tree.xview)
        self.tables_tree.configure(yscrollcommand=tables_scroll_y.set, xscrollcommand=tables_scroll_x.set)
        
        # Grid layout
        self.tables_tree.grid(row=0, column=0, sticky="nsew")
        tables_scroll_y.grid(row=0, column=1, sticky="ns")
        tables_scroll_x.grid(row=1, column=0, sticky="ew")
        
        # Bind double-click to show table details
        self.tables_tree.bind("<Double-1>", self.show_table_details)
        
    def create_data_tab(self):
        """Create data tab"""
        
        # Data tab
        data_frame = ttk.Frame(self.results_notebook)
        self.results_notebook.add(data_frame, text="Data")
        
        data_frame.grid_rowconfigure(0, weight=1)
        data_frame.grid_columnconfigure(0, weight=1)
        
        # Data display (will be populated dynamically)
        self.data_text = tk.Text(data_frame, wrap=tk.NONE, state=tk.DISABLED, font=('Consolas', 9))
        data_scroll_y = ttk.Scrollbar(data_frame, orient=tk.VERTICAL, command=self.data_text.yview)
        data_scroll_x = ttk.Scrollbar(data_frame, orient=tk.HORIZONTAL, command=self.data_text.xview)
        self.data_text.configure(yscrollcommand=data_scroll_y.set, xscrollcommand=data_scroll_x.set)
        
        self.data_text.grid(row=0, column=0, sticky="nsew")
        data_scroll_y.grid(row=0, column=1, sticky="ns")
        data_scroll_x.grid(row=1, column=0, sticky="ew")
        
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
        
    def set_vulnerabilities(self, vulnerabilities: List[VulnerabilityResult]):
        """Set vulnerabilities from tester page"""
        self.vulnerabilities = vulnerabilities
        
        # Clear and populate vulnerability listbox
        self.vuln_listbox.delete(0, tk.END)
        
        for i, vuln in enumerate(vulnerabilities):
            display_text = f"{vuln.url} - {vuln.injection_point.name if vuln.injection_point else 'Unknown'}"
            self.vuln_listbox.insert(tk.END, display_text)
            
        if vulnerabilities:
            self.vuln_listbox.selection_set(0)  # Select first vulnerability
            self.on_vulnerability_select(None)
            
        self.log_message(f"Received {len(vulnerabilities)} vulnerabilities")
        
    def on_vulnerability_select(self, event):
        """Handle vulnerability selection"""
        selection = self.vuln_listbox.curselection()
        if selection:
            idx = selection[0]
            vuln = self.vulnerabilities[idx]
            
            # Update info label
            info_text = f"URL: {vuln.url}\\nParameter: {vuln.injection_point.name if vuln.injection_point else 'Unknown'}\\nTechnique: {vuln.technique.name if vuln.technique else 'Unknown'}"
            self.vuln_info_label.config(text=info_text, foreground="black")
            
            # Enable enumerate button
            self.enumerate_button.config(state=tk.NORMAL)
            
            self.log_message(f"Selected vulnerability: {vuln.url}")
        
    def enumerate_database(self):
        """Enumerate database structure"""
        selection = self.vuln_listbox.curselection()
        if not selection:
            messagebox.showwarning("Warning", "Please select a vulnerability first")
            return
            
        vuln = self.vulnerabilities[selection[0]]
        
        self.enumerate_button.config(state=tk.DISABLED)
        self.stop_button.config(state=tk.NORMAL)
        self.status_label.config(text="Enumerating...", foreground="orange")
        self.progress_bar.start()
        
        # Start enumeration in background thread
        thread = threading.Thread(target=self._run_enumeration_async, args=(vuln,))
        thread.daemon = True
        thread.start()
        
        self.log_message("Starting database enumeration...")
        
    def _run_enumeration_async(self, vulnerability):
        """Run enumeration in async loop"""
        try:
            # Create new event loop for this thread
            loop = asyncio.new_event_loop()
            asyncio.set_event_loop(loop)
            loop.run_until_complete(self._enumerate_database(vulnerability))
        except Exception as e:
            self.after(0, lambda: self.log_message(f"Enumeration error: {str(e)}"))
        finally:
            self.after(0, self._enumeration_completed)
            
    async def _enumerate_database(self, vulnerability):
        """Async enumeration method"""
        config = self._get_dumper_config()
        self.dumper = DatabaseDumper(vulnerability, config)
        
        try:
            # Enumerate database
            self.database_info = await self.dumper.enumerate_database(
                callback=lambda msg: self.after(0, lambda m=msg: self.log_message(m))
            )
            
            self.after(0, self._update_database_display)
            
        except Exception as e:
            self.after(0, lambda: self.log_message(f"Enumeration failed: {str(e)}"))
        finally:
            if self.dumper:
                await self.dumper.close()
        
    def _enumeration_completed(self):
        """Called when enumeration is completed"""
        self.enumerate_button.config(state=tk.NORMAL)
        self.stop_button.config(state=tk.DISABLED)
        self.progress_bar.stop()
        
        if self.database_info and self.database_info.tables:
            self.status_label.config(text=f"Found {len(self.database_info.tables)} tables", foreground="green")
            self.dump_button.config(state=tk.NORMAL)
        else:
            self.status_label.config(text="Enumeration failed", foreground="red")
            
        self.log_message("Database enumeration completed")
        
    def dump_database(self):
        """Dump database data"""
        if not self.database_info:
            messagebox.showwarning("Warning", "Please enumerate database first")
            return
            
        self.dump_button.config(state=tk.DISABLED)
        self.stop_button.config(state=tk.NORMAL)
        self.status_label.config(text="Dumping data...", foreground="orange")
        self.progress_bar.start()
        self.is_dumping = True
        
        # Start dumping in background thread
        thread = threading.Thread(target=self._run_dumping_async)
        thread.daemon = True
        thread.start()
        
        self.log_message("Starting database dump...")
        
    def _run_dumping_async(self):
        """Run dumping in async loop"""
        try:
            # Create new event loop for this thread
            loop = asyncio.new_event_loop()
            asyncio.set_event_loop(loop)
            loop.run_until_complete(self._dump_database())
        except Exception as e:
            self.after(0, lambda: self.log_message(f"Dumping error: {str(e)}"))
        finally:
            self.after(0, self._dumping_completed)
            
    async def _dump_database(self):
        """Async dumping method"""
        if not self.dumper:
            return
            
        try:
            # Dump database
            self.database_info = await self.dumper.dump_database(
                self.database_info,
                callback=lambda msg: self.after(0, lambda m=msg: self.log_message(m))
            )
            
            self.after(0, self._update_data_display)
            
        except Exception as e:
            self.after(0, lambda: self.log_message(f"Dumping failed: {str(e)}"))
        
    def _dumping_completed(self):
        """Called when dumping is completed"""
        self.dump_button.config(state=tk.NORMAL)
        self.stop_button.config(state=tk.DISABLED)
        self.progress_bar.stop()
        self.is_dumping = False
        
        if self.database_info:
            total_rows = sum(len(table.data) for table in self.database_info.tables)
            self.status_label.config(text=f"Dumped {total_rows} rows", foreground="green")
            self.export_button.config(state=tk.NORMAL)
        else:
            self.status_label.config(text="Dumping failed", foreground="red")
            
        self.log_message("Database dump completed")
        
    def stop_dumping(self):
        """Stop current operation"""
        self.is_dumping = False
        if self.dumper:
            asyncio.create_task(self.dumper.cancel_dump())
        self.log_message("Stopping operation...")
        
    def clear_results(self):
        """Clear all results"""
        self.database_info = None
        
        # Clear all displays
        for widget in [self.db_overview_text, self.data_text, self.logs_text]:
            widget.config(state=tk.NORMAL)
            widget.delete(1.0, tk.END)
            widget.config(state=tk.DISABLED)
            
        # Clear tables tree
        for item in self.tables_tree.get_children():
            self.tables_tree.delete(item)
            
        # Reset button states
        self.dump_button.config(state=tk.DISABLED)
        self.export_button.config(state=tk.DISABLED)
        self.status_label.config(text="Ready", foreground="green")
        
        self._update_db_info_display()
        self.log_message("Cleared all results")
        
    def export_data(self):
        """Export dumped data"""
        if not self.database_info:
            messagebox.showwarning("Warning", "No data to export")
            return
            
        file_path = filedialog.asksaveasfilename(
            title="Export Database Data",
            defaultextension=".json",
            filetypes=[
                ("JSON files", "*.json"),
                ("CSV files", "*.csv"),
                ("Text files", "*.txt"),
                ("All files", "*.*")
            ]
        )
        
        if file_path:
            try:
                if file_path.endswith('.json'):
                    self._export_json(file_path)
                elif file_path.endswith('.csv'):
                    self._export_csv(file_path)
                else:
                    self._export_text(file_path)
                    
                self.log_message(f"Data exported to: {file_path}")
                messagebox.showinfo("Success", f"Data exported to: {file_path}")
                
            except Exception as e:
                self.log_message(f"Export failed: {str(e)}")
                messagebox.showerror("Error", f"Export failed: {str(e)}")
        
    def _export_json(self, file_path):
        """Export data as JSON"""
        import json
        
        data = {
            "database": {
                "name": self.database_info.name,
                "version": self.database_info.version,
                "user": self.database_info.user,
                "hostname": self.database_info.hostname
            },
            "tables": []
        }
        
        for table in self.database_info.tables:
            table_data = {
                "name": table.name,
                "row_count": table.row_count,
                "columns": [col.name for col in table.columns],
                "data": table.data
            }
            data["tables"].append(table_data)
            
        with open(file_path, 'w', encoding='utf-8') as f:
            json.dump(data, f, indent=2, ensure_ascii=False)
        
    def _export_csv(self, file_path):
        """Export data as CSV (multiple files)"""
        import csv
        from pathlib import Path
        
        base_path = Path(file_path)
        base_name = base_path.stem
        base_dir = base_path.parent
        
        for table in self.database_info.tables:
            if table.data:
                table_file = base_dir / f"{base_name}_{table.name}.csv"
                with open(table_file, 'w', newline='', encoding='utf-8') as f:
                    if table.data:
                        fieldnames = table.data[0].keys()
                        writer = csv.DictWriter(f, fieldnames=fieldnames)
                        writer.writeheader()
                        writer.writerows(table.data)
        
    def _export_text(self, file_path):
        """Export data as text"""
        with open(file_path, 'w', encoding='utf-8') as f:
            f.write(f"Database: {self.database_info.name}\\n")
            f.write(f"Version: {self.database_info.version}\\n")
            f.write(f"User: {self.database_info.user}\\n")
            f.write(f"Hostname: {self.database_info.hostname}\\n\\n")
            
            for table in self.database_info.tables:
                f.write(f"Table: {table.name} ({table.row_count} rows)\\n")
                f.write("=" * 50 + "\\n")
                
                if table.data:
                    # Write headers
                    headers = list(table.data[0].keys())
                    f.write(" | ".join(headers) + "\\n")
                    f.write("-" * 50 + "\\n")
                    
                    # Write data
                    for row in table.data[:100]:  # Limit to first 100 rows
                        values = [str(row.get(h, "")) for h in headers]
                        f.write(" | ".join(values) + "\\n")
                        
                f.write("\\n")
        
    def show_table_details(self, event):
        """Show table details when double-clicked"""
        selection = self.tables_tree.selection()
        if selection and self.database_info:
            item = self.tables_tree.item(selection[0])
            table_name = item['values'][0]
            
            # Find table
            table = next((t for t in self.database_info.tables if t.name == table_name), None)
            if table:
                self._show_table_data(table)
        
    def _show_table_data(self, table):
        """Show table data in data tab"""
        self.results_notebook.select(2)  # Switch to data tab
        
        # Clear and populate data display
        self.data_text.config(state=tk.NORMAL)
        self.data_text.delete(1.0, tk.END)
        
        content = f"Table: {table.name}\\n"
        content += f"Rows: {table.row_count}\\n"
        content += f"Columns: {len(table.columns)}\\n\\n"
        
        if table.columns:
            content += "Columns:\\n"
            for col in table.columns:
                content += f"  - {col.name} ({col.type})\\n"
            content += "\\n"
            
        if table.data:
            content += "Data (first 50 rows):\\n"
            content += "=" * 80 + "\\n"
            
            # Headers
            headers = list(table.data[0].keys())
            content += " | ".join(f"{h:<15}" for h in headers) + "\\n"
            content += "-" * 80 + "\\n"
            
            # Data rows
            for i, row in enumerate(table.data[:50]):
                values = [str(row.get(h, ""))[:15] for h in headers]
                content += " | ".join(f"{v:<15}" for v in values) + "\\n"
                
        self.data_text.insert(tk.END, content)
        self.data_text.config(state=tk.DISABLED)
        
    def _update_database_display(self):
        """Update database information displays"""
        if not self.database_info:
            return
            
        # Update database overview
        self.db_overview_text.config(state=tk.NORMAL)
        self.db_overview_text.delete(1.0, tk.END)
        
        overview = f"""Database Information:
        
Name: {self.database_info.name}
Version: {self.database_info.version}
User: {self.database_info.user}
Hostname: {self.database_info.hostname}

Tables Found: {len(self.database_info.tables)}

Table Summary:
"""
        
        for table in self.database_info.tables:
            overview += f"  - {table.name}: {table.row_count} rows, {len(table.columns)} columns\\n"
            
        self.db_overview_text.insert(tk.END, overview)
        self.db_overview_text.config(state=tk.DISABLED)
        
        # Update tables tree
        for item in self.tables_tree.get_children():
            self.tables_tree.delete(item)
            
        for table in self.database_info.tables:
            self.tables_tree.insert("", "end", values=(
                table.name,
                table.row_count,
                len(table.columns)
            ))
            
        # Update db info display
        self._update_db_info_display()
        
    def _update_data_display(self):
        """Update data display after dumping"""
        if not self.database_info:
            return
            
        # Update data tab with summary
        self.data_text.config(state=tk.NORMAL)
        self.data_text.delete(1.0, tk.END)
        
        content = "Database Dump Summary:\\n\\n"
        
        total_rows = 0
        for table in self.database_info.tables:
            rows_dumped = len(table.data) if table.data else 0
            total_rows += rows_dumped
            content += f"{table.name}: {rows_dumped} rows dumped\\n"
            
        content += f"\\nTotal rows dumped: {total_rows}\\n\\n"
        content += "Double-click on a table in the 'Tables & Structure' tab to view its data."
        
        self.data_text.insert(tk.END, content)
        self.data_text.config(state=tk.DISABLED)
        
    def _update_db_info_display(self):
        """Update database info display in left panel"""
        self.db_info_text.config(state=tk.NORMAL)
        self.db_info_text.delete(1.0, tk.END)
        
        if self.database_info:
            info = f"""Database: {self.database_info.name}
Version: {self.database_info.version}
User: {self.database_info.user}
Host: {self.database_info.hostname}
Tables: {len(self.database_info.tables)}"""
        else:
            info = "No database information available.\\nSelect a vulnerability and click 'Enumerate Database' to begin."
            
        self.db_info_text.insert(tk.END, info)
        self.db_info_text.config(state=tk.DISABLED)
        
    def _get_dumper_config(self):
        """Get dumper configuration"""
        return {
            "SQLMapTechnique": self.technique_var.get(),
            "SQLMapRisk": int(self.risk_var.get()),
            "SQLMapLevel": int(self.level_var.get()),
            "SQLMapTimeout": int(self.timeout_var.get()),
            "RequestTimeout": 30,
            "MaxThreads": 3
        }
        
    def log_message(self, message):
        """Add message to logs"""
        import datetime
        timestamp = datetime.datetime.now().strftime("%H:%M:%S")
        log_entry = f"[{timestamp}] {message}\\n"
        
        self.logs_text.config(state=tk.NORMAL)
        self.logs_text.insert(tk.END, log_entry)
        self.logs_text.see(tk.END)
        self.logs_text.config(state=tk.DISABLED)
