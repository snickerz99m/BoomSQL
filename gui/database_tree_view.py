"""
Advanced Database Tree View GUI - Similar to SQLi Dumper
"""

import tkinter as tk
from tkinter import ttk, messagebox, filedialog, scrolledtext
from typing import Dict, List, Optional, Any
import threading
import json
from pathlib import Path
from datetime import datetime
import asyncio

try:
    from ..core.database_dumper import DatabaseDumper, DatabaseInfo, TableInfo, ColumnInfo, ExportFormat
    from ..core.advanced_sql_engine import AdvancedSqlInjectionEngine, AdvancedVulnResult
    from ..core.sql_injection_engine import VulnerabilityResult, DatabaseType
    from ..core.event_loop_manager import get_event_loop_manager
except ImportError:
    # Fallback for direct execution
    import sys
    import os
    sys.path.insert(0, os.path.join(os.path.dirname(__file__), '..'))
    from core.database_dumper import DatabaseDumper, DatabaseInfo, TableInfo, ColumnInfo, ExportFormat
    from core.advanced_sql_engine import AdvancedSqlInjectionEngine, AdvancedVulnResult
    from core.sql_injection_engine import VulnerabilityResult, DatabaseType
    from core.event_loop_manager import get_event_loop_manager

class DatabaseTreeView:
    """Advanced database tree view with professional interface"""
    
    def __init__(self, parent):
        self.parent = parent
        self.database_info = None
        self.dumper = None
        self.vulnerability = None
        self.event_loop_manager = get_event_loop_manager()
        
        self.setup_ui()
        self.setup_context_menu()
        
    def setup_ui(self):
        """Setup the user interface"""
        # Main frame
        self.main_frame = ttk.Frame(self.parent)
        self.main_frame.pack(fill=tk.BOTH, expand=True, padx=5, pady=5)
        
        # Create paned window for tree and details
        self.paned_window = ttk.PanedWindow(self.main_frame, orient=tk.HORIZONTAL)
        self.paned_window.pack(fill=tk.BOTH, expand=True)
        
        # Left panel - Tree view
        self.setup_tree_panel()
        
        # Right panel - Details view
        self.setup_details_panel()
        
        # Bottom panel - Action buttons and status
        self.setup_bottom_panel()
    
    def setup_tree_panel(self):
        """Setup the tree view panel"""
        # Tree frame
        tree_frame = ttk.Frame(self.paned_window)
        self.paned_window.add(tree_frame, weight=1)
        
        # Tree label and toolbar
        tree_header = ttk.Frame(tree_frame)
        tree_header.pack(fill=tk.X, pady=(0, 5))
        
        ttk.Label(tree_header, text="Database Structure", font=("Arial", 12, "bold")).pack(side=tk.LEFT)
        
        # Tree toolbar
        tree_toolbar = ttk.Frame(tree_header)
        tree_toolbar.pack(side=tk.RIGHT)
        
        ttk.Button(tree_toolbar, text="↻", width=3, command=self.refresh_tree).pack(side=tk.LEFT, padx=2)
        ttk.Button(tree_toolbar, text="🔍", width=3, command=self.search_tree).pack(side=tk.LEFT, padx=2)
        ttk.Button(tree_toolbar, text="📁", width=3, command=self.expand_all).pack(side=tk.LEFT, padx=2)
        ttk.Button(tree_toolbar, text="📂", width=3, command=self.collapse_all).pack(side=tk.LEFT, padx=2)
        
        # Tree view with scrollbars
        tree_container = ttk.Frame(tree_frame)
        tree_container.pack(fill=tk.BOTH, expand=True)
        
        # Create treeview with custom columns
        self.tree = ttk.Treeview(tree_container, columns=("type", "info", "status"), show="tree headings")
        
        # Configure columns
        self.tree.heading("#0", text="Name")
        self.tree.heading("type", text="Type")
        self.tree.heading("info", text="Info")
        self.tree.heading("status", text="Status")
        
        self.tree.column("#0", width=200, minwidth=150)
        self.tree.column("type", width=80, minwidth=60)
        self.tree.column("info", width=120, minwidth=80)
        self.tree.column("status", width=80, minwidth=60)
        
        # Scrollbars
        v_scrollbar = ttk.Scrollbar(tree_container, orient=tk.VERTICAL, command=self.tree.yview)
        h_scrollbar = ttk.Scrollbar(tree_container, orient=tk.HORIZONTAL, command=self.tree.xview)
        
        self.tree.configure(yscrollcommand=v_scrollbar.set, xscrollcommand=h_scrollbar.set)
        
        # Pack scrollbars and tree
        v_scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
        h_scrollbar.pack(side=tk.BOTTOM, fill=tk.X)
        self.tree.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        
        # Bind events
        self.tree.bind("<Double-1>", self.on_tree_double_click)
        self.tree.bind("<Button-3>", self.on_tree_right_click)
        self.tree.bind("<<TreeviewSelect>>", self.on_tree_select)
    
    def setup_details_panel(self):
        """Setup the details panel"""
        # Details frame
        details_frame = ttk.Frame(self.paned_window)
        self.paned_window.add(details_frame, weight=1)
        
        # Details notebook
        self.details_notebook = ttk.Notebook(details_frame)
        self.details_notebook.pack(fill=tk.BOTH, expand=True)
        
        # Structure tab
        self.setup_structure_tab()
        
        # Data tab
        self.setup_data_tab()
        
        # Query tab
        self.setup_query_tab()
        
        # Export tab
        self.setup_export_tab()
    
    def setup_structure_tab(self):
        """Setup the structure details tab"""
        structure_frame = ttk.Frame(self.details_notebook)
        self.details_notebook.add(structure_frame, text="Structure")
        
        # Structure info
        info_frame = ttk.LabelFrame(structure_frame, text="Object Information")
        info_frame.pack(fill=tk.X, padx=5, pady=5)
        
        # Object details
        self.object_details = ttk.Treeview(info_frame, columns=("property", "value"), show="headings", height=8)
        self.object_details.heading("property", text="Property")
        self.object_details.heading("value", text="Value")
        self.object_details.column("property", width=120)
        self.object_details.column("value", width=200)
        self.object_details.pack(fill=tk.X, padx=5, pady=5)
        
        # Column details (for tables)
        columns_frame = ttk.LabelFrame(structure_frame, text="Columns")
        columns_frame.pack(fill=tk.BOTH, expand=True, padx=5, pady=5)
        
        self.columns_tree = ttk.Treeview(columns_frame, columns=("type", "length", "nullable", "default", "pk"), show="tree headings")
        
        # Configure columns
        self.columns_tree.heading("#0", text="Column Name")
        self.columns_tree.heading("type", text="Type")
        self.columns_tree.heading("length", text="Length")
        self.columns_tree.heading("nullable", text="Nullable")
        self.columns_tree.heading("default", text="Default")
        self.columns_tree.heading("pk", text="PK")
        
        self.columns_tree.column("#0", width=120)
        self.columns_tree.column("type", width=80)
        self.columns_tree.column("length", width=60)
        self.columns_tree.column("nullable", width=60)
        self.columns_tree.column("default", width=80)
        self.columns_tree.column("pk", width=40)
        
        # Scrollbar for columns
        columns_scrollbar = ttk.Scrollbar(columns_frame, orient=tk.VERTICAL, command=self.columns_tree.yview)
        self.columns_tree.configure(yscrollcommand=columns_scrollbar.set)
        
        columns_scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
        self.columns_tree.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
    
    def setup_data_tab(self):
        """Setup the data view tab"""
        data_frame = ttk.Frame(self.details_notebook)
        self.details_notebook.add(data_frame, text="Data")
        
        # Data controls
        controls_frame = ttk.Frame(data_frame)
        controls_frame.pack(fill=tk.X, padx=5, pady=5)
        
        ttk.Label(controls_frame, text="Rows:").pack(side=tk.LEFT)
        self.rows_var = tk.StringVar(value="100")
        ttk.Entry(controls_frame, textvariable=self.rows_var, width=10).pack(side=tk.LEFT, padx=5)
        
        ttk.Label(controls_frame, text="Offset:").pack(side=tk.LEFT, padx=(20, 0))
        self.offset_var = tk.StringVar(value="0")
        ttk.Entry(controls_frame, textvariable=self.offset_var, width=10).pack(side=tk.LEFT, padx=5)
        
        ttk.Button(controls_frame, text="Load Data", command=self.load_table_data).pack(side=tk.LEFT, padx=20)
        ttk.Button(controls_frame, text="Export Data", command=self.export_table_data).pack(side=tk.LEFT, padx=5)
        
        # Data grid
        data_container = ttk.Frame(data_frame)
        data_container.pack(fill=tk.BOTH, expand=True, padx=5, pady=5)
        
        self.data_tree = ttk.Treeview(data_container, show="tree headings")
        
        # Data scrollbars
        data_v_scrollbar = ttk.Scrollbar(data_container, orient=tk.VERTICAL, command=self.data_tree.yview)
        data_h_scrollbar = ttk.Scrollbar(data_container, orient=tk.HORIZONTAL, command=self.data_tree.xview)
        
        self.data_tree.configure(yscrollcommand=data_v_scrollbar.set, xscrollcommand=data_h_scrollbar.set)
        
        data_v_scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
        data_h_scrollbar.pack(side=tk.BOTTOM, fill=tk.X)
        self.data_tree.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        
        # Data status
        self.data_status = ttk.Label(data_frame, text="No data loaded")
        self.data_status.pack(fill=tk.X, padx=5, pady=2)
    
    def setup_query_tab(self):
        """Setup the custom query tab"""
        query_frame = ttk.Frame(self.details_notebook)
        self.details_notebook.add(query_frame, text="Query")
        
        # Query input
        ttk.Label(query_frame, text="Custom Query:").pack(anchor=tk.W, padx=5, pady=5)
        
        self.query_text = scrolledtext.ScrolledText(query_frame, height=8, width=60)
        self.query_text.pack(fill=tk.X, padx=5, pady=5)
        
        # Query buttons
        query_buttons = ttk.Frame(query_frame)
        query_buttons.pack(fill=tk.X, padx=5, pady=5)
        
        ttk.Button(query_buttons, text="Execute", command=self.execute_custom_query).pack(side=tk.LEFT)
        ttk.Button(query_buttons, text="Clear", command=self.clear_query).pack(side=tk.LEFT, padx=5)
        ttk.Button(query_buttons, text="Save", command=self.save_query).pack(side=tk.LEFT, padx=5)
        ttk.Button(query_buttons, text="Load", command=self.load_query).pack(side=tk.LEFT, padx=5)
        
        # Query results
        ttk.Label(query_frame, text="Results:").pack(anchor=tk.W, padx=5, pady=(20, 5))
        
        self.query_results = scrolledtext.ScrolledText(query_frame, height=15, width=60)
        self.query_results.pack(fill=tk.BOTH, expand=True, padx=5, pady=5)
    
    def setup_export_tab(self):
        """Setup the export tab"""
        export_frame = ttk.Frame(self.details_notebook)
        self.details_notebook.add(export_frame, text="Export")
        
        # Export options
        options_frame = ttk.LabelFrame(export_frame, text="Export Options")
        options_frame.pack(fill=tk.X, padx=5, pady=5)
        
        # Format selection
        ttk.Label(options_frame, text="Format:").grid(row=0, column=0, sticky=tk.W, padx=5, pady=5)
        self.export_format = tk.StringVar(value="JSON")
        format_combo = ttk.Combobox(options_frame, textvariable=self.export_format, 
                                   values=["JSON", "CSV", "XML", "SQL", "HTML"], state="readonly")
        format_combo.grid(row=0, column=1, padx=5, pady=5)
        
        # Table selection
        ttk.Label(options_frame, text="Tables:").grid(row=1, column=0, sticky=tk.W, padx=5, pady=5)
        self.export_tables = tk.StringVar(value="Selected")
        table_combo = ttk.Combobox(options_frame, textvariable=self.export_tables,
                                  values=["Selected", "All", "Custom"], state="readonly")
        table_combo.grid(row=1, column=1, padx=5, pady=5)
        
        # Include options
        include_frame = ttk.LabelFrame(export_frame, text="Include")
        include_frame.pack(fill=tk.X, padx=5, pady=5)
        
        self.include_structure = tk.BooleanVar(value=True)
        ttk.Checkbutton(include_frame, text="Table Structure", variable=self.include_structure).pack(anchor=tk.W)
        
        self.include_data = tk.BooleanVar(value=True)
        ttk.Checkbutton(include_frame, text="Table Data", variable=self.include_data).pack(anchor=tk.W)
        
        self.include_indexes = tk.BooleanVar(value=False)
        ttk.Checkbutton(include_frame, text="Indexes", variable=self.include_indexes).pack(anchor=tk.W)
        
        # Export buttons
        export_buttons = ttk.Frame(export_frame)
        export_buttons.pack(fill=tk.X, padx=5, pady=20)
        
        ttk.Button(export_buttons, text="Export Selected", command=self.export_selected).pack(side=tk.LEFT)
        ttk.Button(export_buttons, text="Export All", command=self.export_all).pack(side=tk.LEFT, padx=5)
        ttk.Button(export_buttons, text="Quick Export", command=self.quick_export).pack(side=tk.LEFT, padx=5)
        
        # Export progress
        self.export_progress = ttk.Progressbar(export_frame, mode='determinate')
        self.export_progress.pack(fill=tk.X, padx=5, pady=5)
        
        self.export_status = ttk.Label(export_frame, text="Ready to export")
        self.export_status.pack(fill=tk.X, padx=5, pady=2)
    
    def setup_bottom_panel(self):
        """Setup the bottom panel with buttons and status"""
        bottom_frame = ttk.Frame(self.main_frame)
        bottom_frame.pack(fill=tk.X, pady=(5, 0))
        
        # Action buttons
        button_frame = ttk.Frame(bottom_frame)
        button_frame.pack(side=tk.LEFT)
        
        ttk.Button(button_frame, text="Enumerate Database", command=self.enumerate_database).pack(side=tk.LEFT, padx=2)
        ttk.Button(button_frame, text="Dump Database", command=self.dump_database).pack(side=tk.LEFT, padx=2)
        ttk.Button(button_frame, text="Load Database", command=self.load_database).pack(side=tk.LEFT, padx=2)
        ttk.Button(button_frame, text="Save Database", command=self.save_database).pack(side=tk.LEFT, padx=2)
        
        # Status bar
        self.status_bar = ttk.Label(bottom_frame, text="Ready", relief=tk.SUNKEN, anchor=tk.W)
        self.status_bar.pack(side=tk.RIGHT, fill=tk.X, expand=True, padx=(10, 0))
    
    def setup_context_menu(self):
        """Setup context menu for tree items"""
        self.context_menu = tk.Menu(self.parent, tearoff=0)
        self.context_menu.add_command(label="Enumerate", command=self.enumerate_selected)
        self.context_menu.add_command(label="Dump Data", command=self.dump_selected)
        self.context_menu.add_separator()
        self.context_menu.add_command(label="Export...", command=self.export_selected)
        self.context_menu.add_command(label="Copy Name", command=self.copy_name)
        self.context_menu.add_separator()
        self.context_menu.add_command(label="Properties", command=self.show_properties)
    
    def set_vulnerability(self, vulnerability: VulnerabilityResult):
        """Set the vulnerability to work with"""
        self.vulnerability = vulnerability
        self.dumper = DatabaseDumper(vulnerability, {})
        self.update_status(f"Vulnerability set: {vulnerability.url}")
    
    def populate_tree(self, database_info: DatabaseInfo):
        """Populate the tree with database information"""
        self.database_info = database_info
        
        # Clear existing tree
        self.tree.delete(*self.tree.get_children())
        
        # Add database root
        db_icon = "🗄️"
        db_id = self.tree.insert("", "end", text=f"{db_icon} {database_info.name}", 
                                values=("Database", f"v{database_info.version}", "Ready"))
        
        # Group tables by schema
        schemas = {}
        for table in database_info.tables:
            schema = table.schema or "default"
            if schema not in schemas:
                schemas[schema] = []
            schemas[schema].append(table)
        
        # Add schemas and tables
        for schema_name, tables in schemas.items():
            schema_icon = "📁"
            schema_id = self.tree.insert(db_id, "end", text=f"{schema_icon} {schema_name}",
                                       values=("Schema", f"{len(tables)} tables", "Ready"))
            
            for table in tables:
                table_icon = "📋"
                table_id = self.tree.insert(schema_id, "end", text=f"{table_icon} {table.name}",
                                          values=("Table", f"{table.row_count} rows", "Ready"))
                
                # Add columns
                for column in table.columns:
                    col_icon = "🔸" if column.primary_key else "🔹"
                    col_type = f"{column.type}({column.length})" if column.length > 0 else column.type
                    col_info = f"{col_type} {'NOT NULL' if not column.nullable else 'NULL'}"
                    
                    self.tree.insert(table_id, "end", text=f"{col_icon} {column.name}",
                                   values=("Column", col_info, "Ready"))
        
        # Expand database node
        self.tree.item(db_id, open=True)
        
        self.update_status(f"Database structure loaded: {len(database_info.tables)} tables")
    
    def on_tree_select(self, event):
        """Handle tree selection"""
        selection = self.tree.selection()
        if selection:
            item = selection[0]
            item_text = self.tree.item(item, "text")
            item_values = self.tree.item(item, "values")
            
            if item_values:
                item_type = item_values[0]
                self.update_object_details(item_text, item_type, item)
    
    def update_object_details(self, name: str, obj_type: str, tree_item: str):
        """Update object details in the structure tab"""
        # Clear existing details
        self.object_details.delete(*self.object_details.get_children())
        self.columns_tree.delete(*self.columns_tree.get_children())
        
        # Add basic info
        self.object_details.insert("", "end", values=("Name", name.split(" ", 1)[-1]))
        self.object_details.insert("", "end", values=("Type", obj_type))
        
        if obj_type == "Table":
            # Find table info
            table_info = self.find_table_info(name)
            if table_info:
                self.object_details.insert("", "end", values=("Rows", table_info.row_count))
                self.object_details.insert("", "end", values=("Columns", len(table_info.columns)))
                self.object_details.insert("", "end", values=("Schema", table_info.schema))
                
                # Populate columns
                for column in table_info.columns:
                    col_values = (
                        column.type,
                        str(column.length) if column.length > 0 else "",
                        "Yes" if column.nullable else "No",
                        column.default or "",
                        "Yes" if column.primary_key else "No"
                    )
                    self.columns_tree.insert("", "end", text=column.name, values=col_values)
    
    def find_table_info(self, name: str) -> Optional[TableInfo]:
        """Find table info by name"""
        if not self.database_info:
            return None
        
        table_name = name.split(" ", 1)[-1]  # Remove icon
        for table in self.database_info.tables:
            if table.name == table_name:
                return table
        return None
    
    def on_tree_double_click(self, event):
        """Handle double-click on tree item"""
        selection = self.tree.selection()
        if selection:
            item = selection[0]
            item_values = self.tree.item(item, "values")
            
            if item_values and item_values[0] == "Table":
                self.load_table_data()
    
    def on_tree_right_click(self, event):
        """Handle right-click on tree item"""
        item = self.tree.identify_row(event.y)
        if item:
            self.tree.selection_set(item)
            self.context_menu.post(event.x_root, event.y_root)
    
    def load_table_data(self):
        """Load data for selected table"""
        selection = self.tree.selection()
        if not selection:
            messagebox.showwarning("Warning", "Please select a table")
            return
        
        item = selection[0]
        item_values = self.tree.item(item, "values")
        
        if not item_values or item_values[0] != "Table":
            messagebox.showwarning("Warning", "Please select a table")
            return
        
        table_name = self.tree.item(item, "text").split(" ", 1)[-1]
        table_info = self.find_table_info(table_name)
        
        if not table_info:
            messagebox.showerror("Error", "Table information not found")
            return
        
        # Configure data tree columns
        columns = [col.name for col in table_info.columns]
        self.data_tree.configure(columns=columns)
        
        # Set headings
        self.data_tree.heading("#0", text="Row")
        for col in columns:
            self.data_tree.heading(col, text=col)
            self.data_tree.column(col, width=100)
        
        # Clear existing data
        self.data_tree.delete(*self.data_tree.get_children())
        
        # Load data (placeholder - would integrate with dumper)
        if table_info.data:
            for i, row in enumerate(table_info.data[:int(self.rows_var.get())]):
                values = [str(row.get(col, "")) for col in columns]
                self.data_tree.insert("", "end", text=str(i + 1), values=values)
        
        self.data_status.config(text=f"Loaded {len(table_info.data)} rows")
        self.details_notebook.select(1)  # Switch to data tab
    
    def enumerate_database(self):
        """Enumerate database structure"""
        if not self.dumper:
            messagebox.showerror("Error", "No vulnerability set")
            return
        
        self.update_status("Enumerating database structure...")
        
        # Run enumeration in background
        def enumerate_task():
            try:
                async def run_enumeration():
                    database_info = await self.dumper.enumerate_database()
                    return database_info
                
                database_info = self.event_loop_manager.run_async_blocking(run_enumeration(), timeout=300)
                
                # Update UI in main thread
                self.parent.after(0, lambda: self.on_enumeration_complete(database_info))
                
            except Exception as e:
                self.parent.after(0, lambda: self.on_enumeration_error(str(e)))
        
        threading.Thread(target=enumerate_task, daemon=True).start()
    
    def on_enumeration_complete(self, database_info: DatabaseInfo):
        """Handle enumeration completion"""
        self.populate_tree(database_info)
        self.update_status("Database enumeration completed successfully")
    
    def on_enumeration_error(self, error: str):
        """Handle enumeration error"""
        messagebox.showerror("Enumeration Error", f"Failed to enumerate database: {error}")
        self.update_status("Enumeration failed")
    
    def dump_database(self):
        """Dump entire database"""
        if not self.database_info:
            messagebox.showwarning("Warning", "Please enumerate database first")
            return
        
        self.update_status("Dumping database...")
        
        # Run dump in background
        def dump_task():
            try:
                async def run_dump():
                    database_info = await self.dumper.dump_database(self.database_info)
                    return database_info
                
                database_info = self.event_loop_manager.run_async_blocking(run_dump(), timeout=600)
                
                # Update UI in main thread
                self.parent.after(0, lambda: self.on_dump_complete(database_info))
                
            except Exception as e:
                self.parent.after(0, lambda: self.on_dump_error(str(e)))
        
        threading.Thread(target=dump_task, daemon=True).start()
    
    def on_dump_complete(self, database_info: DatabaseInfo):
        """Handle dump completion"""
        self.database_info = database_info
        self.populate_tree(database_info)
        self.update_status("Database dump completed successfully")
        messagebox.showinfo("Success", "Database dump completed successfully")
    
    def on_dump_error(self, error: str):
        """Handle dump error"""
        messagebox.showerror("Dump Error", f"Failed to dump database: {error}")
        self.update_status("Dump failed")
    
    def save_database(self):
        """Save database information to file"""
        if not self.database_info:
            messagebox.showwarning("Warning", "No database information to save")
            return
        
        filename = filedialog.asksaveasfilename(
            defaultextension=".json",
            filetypes=[("JSON files", "*.json"), ("All files", "*.*")]
        )
        
        if filename:
            try:
                # Convert to JSON-serializable format
                data = {
                    "name": self.database_info.name,
                    "version": self.database_info.version,
                    "user": self.database_info.user,
                    "hostname": self.database_info.hostname,
                    "tables": [
                        {
                            "name": table.name,
                            "schema": table.schema,
                            "row_count": table.row_count,
                            "columns": [
                                {
                                    "name": col.name,
                                    "type": col.type,
                                    "length": col.length,
                                    "nullable": col.nullable,
                                    "default": col.default,
                                    "primary_key": col.primary_key
                                }
                                for col in table.columns
                            ],
                            "data": table.data
                        }
                        for table in self.database_info.tables
                    ]
                }
                
                with open(filename, 'w') as f:
                    json.dump(data, f, indent=2, default=str)
                
                self.update_status(f"Database saved to {filename}")
                messagebox.showinfo("Success", f"Database saved to {filename}")
                
            except Exception as e:
                messagebox.showerror("Error", f"Failed to save database: {e}")
    
    def load_database(self):
        """Load database information from file"""
        filename = filedialog.askopenfilename(
            filetypes=[("JSON files", "*.json"), ("All files", "*.*")]
        )
        
        if filename:
            try:
                with open(filename, 'r') as f:
                    data = json.load(f)
                
                # Convert to DatabaseInfo
                tables = []
                for table_data in data.get("tables", []):
                    columns = []
                    for col_data in table_data.get("columns", []):
                        columns.append(ColumnInfo(
                            name=col_data["name"],
                            type=col_data["type"],
                            length=col_data.get("length", 0),
                            nullable=col_data.get("nullable", True),
                            default=col_data.get("default", ""),
                            primary_key=col_data.get("primary_key", False)
                        ))
                    
                    tables.append(TableInfo(
                        name=table_data["name"],
                        schema=table_data.get("schema", ""),
                        row_count=table_data.get("row_count", 0),
                        columns=columns,
                        data=table_data.get("data", [])
                    ))
                
                self.database_info = DatabaseInfo(
                    name=data.get("name", ""),
                    version=data.get("version", ""),
                    user=data.get("user", ""),
                    hostname=data.get("hostname", ""),
                    tables=tables
                )
                
                self.populate_tree(self.database_info)
                self.update_status(f"Database loaded from {filename}")
                
            except Exception as e:
                messagebox.showerror("Error", f"Failed to load database: {e}")
    
    def execute_custom_query(self):
        """Execute custom query"""
        query = self.query_text.get(1.0, tk.END).strip()
        if not query:
            messagebox.showwarning("Warning", "Please enter a query")
            return
        
        if not self.dumper:
            messagebox.showerror("Error", "No vulnerability set")
            return
        
        self.update_status("Executing custom query...")
        
        # Run query in background
        def query_task():
            try:
                async def run_query():
                    result = await self.dumper.execute_query(query)
                    return result
                
                result = self.event_loop_manager.run_async_blocking(run_query(), timeout=60)
                
                # Update UI in main thread
                self.parent.after(0, lambda: self.on_query_complete(result))
                
            except Exception as e:
                self.parent.after(0, lambda: self.on_query_error(str(e)))
        
        threading.Thread(target=query_task, daemon=True).start()
    
    def on_query_complete(self, result: str):
        """Handle query completion"""
        self.query_results.delete(1.0, tk.END)
        self.query_results.insert(tk.END, result or "No results")
        self.update_status("Query executed successfully")
    
    def on_query_error(self, error: str):
        """Handle query error"""
        self.query_results.delete(1.0, tk.END)
        self.query_results.insert(tk.END, f"Error: {error}")
        self.update_status("Query failed")
    
    def export_selected(self):
        """Export selected item"""
        selection = self.tree.selection()
        if not selection:
            messagebox.showwarning("Warning", "Please select an item to export")
            return
        
        self.export_data()
    
    def export_all(self):
        """Export entire database"""
        if not self.database_info:
            messagebox.showwarning("Warning", "No database information to export")
            return
        
        self.export_data()
    
    def export_data(self):
        """Export data with current settings"""
        if not self.database_info:
            messagebox.showwarning("Warning", "No database information to export")
            return
        
        # Get export format
        format_map = {
            "JSON": ExportFormat.JSON,
            "CSV": ExportFormat.CSV,
            "XML": ExportFormat.XML,
            "SQL": ExportFormat.SQL,
            "HTML": ExportFormat.HTML
        }
        
        export_format = format_map.get(self.export_format.get(), ExportFormat.JSON)
        
        # Get filename
        extensions = {
            ExportFormat.JSON: ".json",
            ExportFormat.CSV: ".csv",
            ExportFormat.XML: ".xml",
            ExportFormat.SQL: ".sql",
            ExportFormat.HTML: ".html"
        }
        
        filename = filedialog.asksaveasfilename(
            defaultextension=extensions[export_format],
            filetypes=[(f"{self.export_format.get()} files", f"*{extensions[export_format]}"), 
                      ("All files", "*.*")]
        )
        
        if filename:
            try:
                self.dumper.export_data(self.database_info, export_format, filename)
                self.update_status(f"Data exported to {filename}")
                messagebox.showinfo("Success", f"Data exported to {filename}")
                
            except Exception as e:
                messagebox.showerror("Error", f"Failed to export data: {e}")
    
    def quick_export(self):
        """Quick export to JSON"""
        if not self.database_info:
            messagebox.showwarning("Warning", "No database information to export")
            return
        
        timestamp = datetime.now().strftime("%Y%m%d_%H%M%S")
        filename = f"database_export_{timestamp}.json"
        
        try:
            self.dumper.export_data(self.database_info, ExportFormat.JSON, filename)
            self.update_status(f"Data exported to {filename}")
            messagebox.showinfo("Success", f"Data exported to {filename}")
            
        except Exception as e:
            messagebox.showerror("Error", f"Failed to export data: {e}")
    
    # Tree operations
    def refresh_tree(self):
        """Refresh tree view"""
        if self.database_info:
            self.populate_tree(self.database_info)
    
    def search_tree(self):
        """Search in tree"""
        search_term = tk.simpledialog.askstring("Search", "Enter search term:")
        if search_term:
            self.highlight_search_results(search_term)
    
    def highlight_search_results(self, search_term: str):
        """Highlight search results in tree"""
        # Clear previous highlights
        for item in self.tree.get_children():
            self.clear_highlight(item)
        
        # Search and highlight
        for item in self.tree.get_children():
            self.search_item(item, search_term.lower())
    
    def search_item(self, item: str, search_term: str):
        """Search in tree item and children"""
        text = self.tree.item(item, "text").lower()
        if search_term in text:
            self.tree.set(item, "status", "Found")
            self.tree.selection_add(item)
            self.tree.see(item)
        
        # Search children
        for child in self.tree.get_children(item):
            self.search_item(child, search_term)
    
    def clear_highlight(self, item: str):
        """Clear highlight from item"""
        self.tree.set(item, "status", "Ready")
        for child in self.tree.get_children(item):
            self.clear_highlight(child)
    
    def expand_all(self):
        """Expand all tree items"""
        for item in self.tree.get_children():
            self.expand_item(item)
    
    def expand_item(self, item: str):
        """Expand tree item and children"""
        self.tree.item(item, open=True)
        for child in self.tree.get_children(item):
            self.expand_item(child)
    
    def collapse_all(self):
        """Collapse all tree items"""
        for item in self.tree.get_children():
            self.collapse_item(item)
    
    def collapse_item(self, item: str):
        """Collapse tree item and children"""
        self.tree.item(item, open=False)
        for child in self.tree.get_children(item):
            self.collapse_item(child)
    
    # Context menu actions
    def enumerate_selected(self):
        """Enumerate selected item"""
        self.enumerate_database()
    
    def dump_selected(self):
        """Dump selected item"""
        selection = self.tree.selection()
        if selection:
            item = selection[0]
            item_values = self.tree.item(item, "values")
            
            if item_values and item_values[0] == "Table":
                self.load_table_data()
            else:
                self.dump_database()
    
    def copy_name(self):
        """Copy selected item name to clipboard"""
        selection = self.tree.selection()
        if selection:
            item = selection[0]
            name = self.tree.item(item, "text").split(" ", 1)[-1]
            self.parent.clipboard_clear()
            self.parent.clipboard_append(name)
            self.update_status(f"Copied: {name}")
    
    def show_properties(self):
        """Show properties dialog for selected item"""
        selection = self.tree.selection()
        if selection:
            item = selection[0]
            self.details_notebook.select(0)  # Switch to structure tab
    
    def clear_query(self):
        """Clear query text"""
        self.query_text.delete(1.0, tk.END)
    
    def save_query(self):
        """Save query to file"""
        query = self.query_text.get(1.0, tk.END).strip()
        if not query:
            messagebox.showwarning("Warning", "No query to save")
            return
        
        filename = filedialog.asksaveasfilename(
            defaultextension=".sql",
            filetypes=[("SQL files", "*.sql"), ("Text files", "*.txt"), ("All files", "*.*")]
        )
        
        if filename:
            try:
                with open(filename, 'w') as f:
                    f.write(query)
                self.update_status(f"Query saved to {filename}")
            except Exception as e:
                messagebox.showerror("Error", f"Failed to save query: {e}")
    
    def load_query(self):
        """Load query from file"""
        filename = filedialog.askopenfilename(
            filetypes=[("SQL files", "*.sql"), ("Text files", "*.txt"), ("All files", "*.*")]
        )
        
        if filename:
            try:
                with open(filename, 'r') as f:
                    query = f.read()
                self.query_text.delete(1.0, tk.END)
                self.query_text.insert(tk.END, query)
                self.update_status(f"Query loaded from {filename}")
            except Exception as e:
                messagebox.showerror("Error", f"Failed to load query: {e}")
    
    def export_table_data(self):
        """Export data for selected table"""
        selection = self.tree.selection()
        if not selection:
            messagebox.showwarning("Warning", "Please select a table")
            return
        
        item = selection[0]
        item_values = self.tree.item(item, "values")
        
        if not item_values or item_values[0] != "Table":
            messagebox.showwarning("Warning", "Please select a table")
            return
        
        # Export just this table
        table_name = self.tree.item(item, "text").split(" ", 1)[-1]
        table_info = self.find_table_info(table_name)
        
        if table_info:
            # Create temporary database info with just this table
            temp_db_info = DatabaseInfo(
                name=self.database_info.name,
                version=self.database_info.version,
                user=self.database_info.user,
                hostname=self.database_info.hostname,
                tables=[table_info]
            )
            
            # Save original and replace temporarily
            original_db_info = self.database_info
            self.database_info = temp_db_info
            
            try:
                self.export_data()
            finally:
                self.database_info = original_db_info
    
    def update_status(self, message: str):
        """Update status bar"""
        self.status_bar.config(text=message)
        self.parent.update_idletasks()
