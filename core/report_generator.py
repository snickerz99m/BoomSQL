"""
Report Generator for BoomSQL
Advanced report generation with multiple formats and detailed analysis
"""

import json
import csv
import xml.etree.ElementTree as ET
from pathlib import Path
from datetime import datetime
from typing import Dict, List, Optional, Any, Union
from dataclasses import dataclass, field
from enum import Enum
import html
import base64

from .sql_injection_engine import TestResult, VulnerabilityResult, InjectionType, DatabaseType
from .database_dumper import DatabaseInfo, TableInfo
# from .database_dumper import DumpProgress  # Temporarily disabled
from .web_crawler import CrawledUrl, Parameter, CrawlProgress
from .dork_searcher import SearchResult, SearchProgress
from .logger import LoggerMixin

class ReportFormat(Enum):
    """Report formats"""
    HTML = "html"
    PDF = "pdf"
    XML = "xml"
    JSON = "json"
    CSV = "csv"

class ReportType(Enum):
    """Report types"""
    EXECUTIVE = "executive"
    TECHNICAL = "technical"
    COMPLIANCE = "compliance"
    DETAILED = "detailed"

class SeverityLevel(Enum):
    """Severity levels"""
    CRITICAL = "critical"
    HIGH = "high"
    MEDIUM = "medium"
    LOW = "low"
    INFO = "info"

@dataclass
class ReportSummary:
    """Report summary information"""
    total_urls_tested: int
    total_vulnerabilities: int
    critical_vulnerabilities: int
    high_vulnerabilities: int
    medium_vulnerabilities: int
    low_vulnerabilities: int
    info_vulnerabilities: int
    unique_databases: int
    total_tables_dumped: int
    total_records_extracted: int
    scan_duration: float
    report_generated: datetime = field(default_factory=datetime.now)

@dataclass
class VulnerabilityStatistics:
    """Vulnerability statistics"""
    by_injection_type: Dict[InjectionType, int] = field(default_factory=dict)
    by_database_type: Dict[DatabaseType, int] = field(default_factory=dict)
    by_severity: Dict[SeverityLevel, int] = field(default_factory=dict)
    by_confidence: Dict[str, int] = field(default_factory=dict)
    
class ReportGenerator(LoggerMixin):
    """Advanced report generator"""
    
    def __init__(self, config: Dict[str, Any]):
        self.config = config
        self.test_results: List[TestResult] = []
        self.vulnerability_results: List[VulnerabilityResult] = []
        self.database_info: List[DatabaseInfo] = []
        self.crawl_results: List[CrawledUrl] = []
        self.search_results: List[SearchResult] = []
        self.summary: Optional[ReportSummary] = None
        self.statistics: Optional[VulnerabilityStatistics] = None
        
    def add_test_results(self, results: List[TestResult]):
        """Add test results to report"""
        self.test_results.extend(results)
        
        # Extract vulnerability results
        for test_result in results:
            self.vulnerability_results.extend(test_result.vulnerabilities)
            
        self.update_statistics()
        
    def add_database_info(self, database_info: List[DatabaseInfo]):
        """Add database information to report"""
        self.database_info.extend(database_info)
        
    def add_crawl_results(self, results: List[CrawledUrl]):
        """Add crawl results to report"""
        self.crawl_results.extend(results)
        
    def add_search_results(self, results: List[SearchResult]):
        """Add search results to report"""
        self.search_results.extend(results)
        
    def update_statistics(self):
        """Update vulnerability statistics"""
        if not self.vulnerability_results:
            return
            
        stats = VulnerabilityStatistics()
        
        # Count by injection type
        for vuln in self.vulnerability_results:
            injection_type = vuln.injection_type
            stats.by_injection_type[injection_type] = stats.by_injection_type.get(injection_type, 0) + 1
            
            # Count by database type
            db_type = vuln.database_type
            stats.by_database_type[db_type] = stats.by_database_type.get(db_type, 0) + 1
            
            # Count by severity
            severity = self.get_vulnerability_severity(vuln)
            stats.by_severity[severity] = stats.by_severity.get(severity, 0) + 1
            
            # Count by confidence
            confidence_range = self.get_confidence_range(vuln.confidence)
            stats.by_confidence[confidence_range] = stats.by_confidence.get(confidence_range, 0) + 1
            
        self.statistics = stats
        
        # Update summary
        self.summary = ReportSummary(
            total_urls_tested=len(self.test_results),
            total_vulnerabilities=len(self.vulnerability_results),
            critical_vulnerabilities=stats.by_severity.get(SeverityLevel.CRITICAL, 0),
            high_vulnerabilities=stats.by_severity.get(SeverityLevel.HIGH, 0),
            medium_vulnerabilities=stats.by_severity.get(SeverityLevel.MEDIUM, 0),
            low_vulnerabilities=stats.by_severity.get(SeverityLevel.LOW, 0),
            info_vulnerabilities=stats.by_severity.get(SeverityLevel.INFO, 0),
            unique_databases=len(set(vuln.database_type for vuln in self.vulnerability_results)),
            total_tables_dumped=sum(len(db.tables) for db in self.database_info),
            total_records_extracted=sum(len(table.data) for db in self.database_info for table in db.tables),
            scan_duration=sum(result.total_time for result in self.test_results)
        )
        
    def get_vulnerability_severity(self, vulnerability: VulnerabilityResult) -> SeverityLevel:
        """Get vulnerability severity level"""
        # Determine severity based on injection type, confidence, and database type
        if vulnerability.injection_type in [InjectionType.ERROR_BASED, InjectionType.UNION_BASED]:
            if vulnerability.confidence >= 0.9:
                return SeverityLevel.CRITICAL
            elif vulnerability.confidence >= 0.7:
                return SeverityLevel.HIGH
            else:
                return SeverityLevel.MEDIUM
        elif vulnerability.injection_type == InjectionType.TIME_BASED:
            if vulnerability.confidence >= 0.8:
                return SeverityLevel.HIGH
            else:
                return SeverityLevel.MEDIUM
        elif vulnerability.injection_type == InjectionType.BOOLEAN_BASED:
            if vulnerability.confidence >= 0.8:
                return SeverityLevel.MEDIUM
            else:
                return SeverityLevel.LOW
        else:
            return SeverityLevel.LOW
            
    def get_confidence_range(self, confidence: float) -> str:
        """Get confidence range string"""
        if confidence >= 0.9:
            return "Very High (90-100%)"
        elif confidence >= 0.7:
            return "High (70-89%)"
        elif confidence >= 0.5:
            return "Medium (50-69%)"
        elif confidence >= 0.3:
            return "Low (30-49%)"
        else:
            return "Very Low (<30%)"
            
    def generate_report(self, report_type: ReportType, format: ReportFormat, output_file: str) -> bool:
        """Generate report in specified format"""
        try:
            output_path = Path(output_file)
            output_path.parent.mkdir(parents=True, exist_ok=True)
            
            if format == ReportFormat.HTML:
                self.generate_html_report(report_type, output_path)
            elif format == ReportFormat.JSON:
                self.generate_json_report(report_type, output_path)
            elif format == ReportFormat.XML:
                self.generate_xml_report(report_type, output_path)
            elif format == ReportFormat.CSV:
                self.generate_csv_report(report_type, output_path)
            elif format == ReportFormat.PDF:
                self.generate_pdf_report(report_type, output_path)
            else:
                raise ValueError(f"Unsupported report format: {format}")
                
            self.log_info(f"Report generated: {output_path}")
            return True
            
        except Exception as e:
            self.log_error(f"Error generating report: {e}")
            return False
            
    def generate_html_report(self, report_type: ReportType, output_path: Path):
        """Generate HTML report"""
        with open(output_path, 'w', encoding='utf-8') as f:
            f.write(self.get_html_header(report_type))
            f.write(self.get_html_summary())
            
            if report_type == ReportType.EXECUTIVE:
                f.write(self.get_html_executive_summary())
            elif report_type == ReportType.TECHNICAL:
                f.write(self.get_html_technical_details())
            elif report_type == ReportType.COMPLIANCE:
                f.write(self.get_html_compliance_details())
            elif report_type == ReportType.DETAILED:
                f.write(self.get_html_detailed_report())
                
            f.write(self.get_html_footer())
            
    def get_html_header(self, report_type: ReportType) -> str:
        """Get HTML header"""
        title = f"BoomSQL {report_type.value.title()} Report"
        return f"""<!DOCTYPE html>
<html>
<head>
    <title>{title}</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <style>
        body {{
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 20px;
            background-color: #f5f5f5;
        }}
        .container {{
            max-width: 1200px;
            margin: 0 auto;
            background-color: white;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
        }}
        .header {{
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            padding: 30px;
            border-radius: 8px;
            margin-bottom: 30px;
        }}
        .header h1 {{
            margin: 0;
            font-size: 2.5em;
        }}
        .header .subtitle {{
            font-size: 1.2em;
            opacity: 0.9;
            margin-top: 10px;
        }}
        .summary-grid {{
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
            gap: 20px;
            margin-bottom: 30px;
        }}
        .summary-card {{
            background: white;
            padding: 20px;
            border-radius: 8px;
            border-left: 4px solid #667eea;
            box-shadow: 0 2px 5px rgba(0,0,0,0.1);
        }}
        .summary-card h3 {{
            margin: 0 0 10px 0;
            color: #333;
        }}
        .summary-card .value {{
            font-size: 2em;
            font-weight: bold;
            color: #667eea;
        }}
        .vulnerability-table {{
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
        }}
        .vulnerability-table th,
        .vulnerability-table td {{
            padding: 12px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }}
        .vulnerability-table th {{
            background-color: #f8f9fa;
            font-weight: bold;
        }}
        .severity-critical {{ background-color: #dc3545; color: white; }}
        .severity-high {{ background-color: #fd7e14; color: white; }}
        .severity-medium {{ background-color: #ffc107; color: black; }}
        .severity-low {{ background-color: #28a745; color: white; }}
        .severity-info {{ background-color: #17a2b8; color: white; }}
        .chart-container {{
            margin: 20px 0;
            padding: 20px;
            background-color: #f8f9fa;
            border-radius: 8px;
        }}
        .url-code {{
            font-family: monospace;
            background-color: #f8f9fa;
            padding: 2px 4px;
            border-radius: 3px;
        }}
        .footer {{
            margin-top: 40px;
            padding: 20px;
            background-color: #f8f9fa;
            border-radius: 8px;
            text-align: center;
            color: #666;
        }}
        .warning {{
            background-color: #fff3cd;
            border: 1px solid #ffeaa7;
            color: #856404;
            padding: 15px;
            border-radius: 5px;
            margin: 20px 0;
        }}
        .section {{
            margin: 30px 0;
        }}
        .section h2 {{
            color: #333;
            border-bottom: 2px solid #667eea;
            padding-bottom: 10px;
        }}
    </style>
</head>
<body>
    <div class="container">
        <div class="header">
            <h1>{title}</h1>
            <div class="subtitle">Generated on {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}</div>
        </div>
        
        <div class="warning">
            <strong>⚠️ CONFIDENTIAL SECURITY REPORT</strong><br>
            This report contains sensitive security information. Handle with care and distribute only to authorized personnel.
        </div>
"""
        
    def get_html_summary(self) -> str:
        """Get HTML summary section"""
        if not self.summary:
            return ""
            
        return f"""
        <div class="section">
            <h2>Executive Summary</h2>
            <div class="summary-grid">
                <div class="summary-card">
                    <h3>URLs Tested</h3>
                    <div class="value">{self.summary.total_urls_tested}</div>
                </div>
                <div class="summary-card">
                    <h3>Vulnerabilities Found</h3>
                    <div class="value">{self.summary.total_vulnerabilities}</div>
                </div>
                <div class="summary-card">
                    <h3>Critical Issues</h3>
                    <div class="value">{self.summary.critical_vulnerabilities}</div>
                </div>
                <div class="summary-card">
                    <h3>High Risk Issues</h3>
                    <div class="value">{self.summary.high_vulnerabilities}</div>
                </div>
                <div class="summary-card">
                    <h3>Unique Databases</h3>
                    <div class="value">{self.summary.unique_databases}</div>
                </div>
                <div class="summary-card">
                    <h3>Scan Duration</h3>
                    <div class="value">{self.summary.scan_duration:.1f}s</div>
                </div>
            </div>
        </div>
"""
        
    def get_html_executive_summary(self) -> str:
        """Get HTML executive summary"""
        if not self.summary:
            return ""
            
        risk_level = "CRITICAL" if self.summary.critical_vulnerabilities > 0 else \
                    "HIGH" if self.summary.high_vulnerabilities > 0 else \
                    "MEDIUM" if self.summary.medium_vulnerabilities > 0 else \
                    "LOW"
                    
        return f"""
        <div class="section">
            <h2>Risk Assessment</h2>
            <div class="summary-card">
                <h3>Overall Risk Level: <span class="severity-{risk_level.lower()}" style="padding: 5px 10px; border-radius: 3px;">{risk_level}</span></h3>
                <p>This assessment is based on the severity and number of vulnerabilities discovered during the security scan.</p>
            </div>
            
            <h3>Key Findings</h3>
            <ul>
                <li>Discovered {self.summary.total_vulnerabilities} SQL injection vulnerabilities across {self.summary.total_urls_tested} tested URLs</li>
                <li>Identified {self.summary.critical_vulnerabilities} critical and {self.summary.high_vulnerabilities} high-severity vulnerabilities requiring immediate attention</li>
                <li>Found {self.summary.unique_databases} different database systems potentially vulnerable to exploitation</li>
                <li>Successfully extracted {self.summary.total_records_extracted} database records from {self.summary.total_tables_dumped} tables</li>
            </ul>
            
            <h3>Recommendations</h3>
            <ul>
                <li>Immediately patch all critical and high-severity SQL injection vulnerabilities</li>
                <li>Implement input validation and parameterized queries</li>
                <li>Deploy Web Application Firewall (WAF) for additional protection</li>
                <li>Conduct regular security assessments and penetration testing</li>
                <li>Implement database access controls and monitoring</li>
            </ul>
        </div>
"""
        
    def get_html_technical_details(self) -> str:
        """Get HTML technical details"""
        html = """
        <div class="section">
            <h2>Technical Vulnerability Details</h2>
            <table class="vulnerability-table">
                <tr>
                    <th>URL</th>
                    <th>Parameter</th>
                    <th>Injection Type</th>
                    <th>Database</th>
                    <th>Severity</th>
                    <th>Confidence</th>
                    <th>Response Time</th>
                </tr>
"""
        
        for vuln in self.vulnerability_results:
            severity = self.get_vulnerability_severity(vuln)
            html += f"""
                <tr>
                    <td><code class="url-code">{html.escape(vuln.url)}</code></td>
                    <td>{html.escape(vuln.injection_point.name)}</td>
                    <td>{vuln.injection_type.value.replace('_', ' ').title()}</td>
                    <td>{vuln.database_type.value.upper()}</td>
                    <td><span class="severity-{severity.value}">{severity.value.upper()}</span></td>
                    <td>{vuln.confidence:.1%}</td>
                    <td>{vuln.response_time:.2f}s</td>
                </tr>
"""
        
        html += """
            </table>
        </div>
"""
        
        # Add vulnerability statistics
        if self.statistics:
            html += self.get_html_statistics()
            
        return html
        
    def get_html_statistics(self) -> str:
        """Get HTML statistics section"""
        if not self.statistics:
            return ""
            
        html = """
        <div class="section">
            <h2>Vulnerability Statistics</h2>
            
            <div class="chart-container">
                <h3>Vulnerabilities by Injection Type</h3>
                <table class="vulnerability-table">
                    <tr><th>Injection Type</th><th>Count</th><th>Percentage</th></tr>
"""
        
        total_vulns = len(self.vulnerability_results)
        for injection_type, count in self.statistics.by_injection_type.items():
            percentage = (count / total_vulns) * 100 if total_vulns > 0 else 0
            html += f"""
                    <tr>
                        <td>{injection_type.value.replace('_', ' ').title()}</td>
                        <td>{count}</td>
                        <td>{percentage:.1f}%</td>
                    </tr>
"""
        
        html += """
                </table>
            </div>
            
            <div class="chart-container">
                <h3>Vulnerabilities by Database Type</h3>
                <table class="vulnerability-table">
                    <tr><th>Database Type</th><th>Count</th><th>Percentage</th></tr>
"""
        
        for db_type, count in self.statistics.by_database_type.items():
            percentage = (count / total_vulns) * 100 if total_vulns > 0 else 0
            html += f"""
                    <tr>
                        <td>{db_type.value.upper()}</td>
                        <td>{count}</td>
                        <td>{percentage:.1f}%</td>
                    </tr>
"""
        
        html += """
                </table>
            </div>
        </div>
"""
        
        return html
        
    def get_html_compliance_details(self) -> str:
        """Get HTML compliance details"""
        return """
        <div class="section">
            <h2>Compliance Assessment</h2>
            
            <div class="chart-container">
                <h3>OWASP Top 10 Compliance</h3>
                <p>This assessment covers A03:2021 - Injection vulnerabilities from the OWASP Top 10.</p>
                <ul>
                    <li><strong>A03:2021 - Injection:</strong> FAILED - SQL injection vulnerabilities detected</li>
                    <li><strong>Remediation Required:</strong> Implement input validation and parameterized queries</li>
                </ul>
            </div>
            
            <div class="chart-container">
                <h3>PCI DSS Compliance</h3>
                <p>Payment Card Industry Data Security Standard requirements:</p>
                <ul>
                    <li><strong>Requirement 6.5.1:</strong> FAILED - Injection flaws detected</li>
                    <li><strong>Requirement 11.3:</strong> PASSED - Penetration testing conducted</li>
                </ul>
            </div>
            
            <div class="chart-container">
                <h3>ISO 27001 Compliance</h3>
                <p>Information Security Management System requirements:</p>
                <ul>
                    <li><strong>A.14.2.1:</strong> FAILED - Secure development lifecycle gaps identified</li>
                    <li><strong>A.12.6.1:</strong> PASSED - Vulnerability management process active</li>
                </ul>
            </div>
        </div>
"""
        
    def get_html_detailed_report(self) -> str:
        """Get HTML detailed report"""
        html = self.get_html_technical_details()
        
        # Add database dump information
        if self.database_info:
            html += """
        <div class="section">
            <h2>Database Enumeration Results</h2>
"""
            
            for db in self.database_info:
                html += f"""
            <div class="chart-container">
                <h3>Database: {html.escape(db.name)}</h3>
                <p><strong>Version:</strong> {html.escape(db.version)}</p>
                <p><strong>User:</strong> {html.escape(db.user)}</p>
                <p><strong>Hostname:</strong> {html.escape(db.hostname)}</p>
                <p><strong>Tables:</strong> {len(db.tables)}</p>
                
                <table class="vulnerability-table">
                    <tr><th>Table</th><th>Schema</th><th>Rows</th><th>Columns</th></tr>
"""
                
                for table in db.tables:
                    html += f"""
                    <tr>
                        <td>{html.escape(table.name)}</td>
                        <td>{html.escape(table.schema)}</td>
                        <td>{table.row_count}</td>
                        <td>{len(table.columns)}</td>
                    </tr>
"""
                
                html += """
                </table>
            </div>
"""
            
            html += """
        </div>
"""
        
        # Add crawl results
        if self.crawl_results:
            html += f"""
        <div class="section">
            <h2>Web Crawling Results</h2>
            <p>Discovered {len(self.crawl_results)} URLs with potential injection points.</p>
            
            <table class="vulnerability-table">
                <tr><th>URL</th><th>Title</th><th>Status</th><th>Parameters</th><th>Forms</th></tr>
"""
            
            for url in self.crawl_results[:50]:  # Limit to first 50 results
                html += f"""
                <tr>
                    <td><code class="url-code">{html.escape(url.url)}</code></td>
                    <td>{html.escape(url.title)}</td>
                    <td>{url.status_code}</td>
                    <td>{len(url.parameters)}</td>
                    <td>{len(url.forms)}</td>
                </tr>
"""
            
            html += """
            </table>
        </div>
"""
        
        # Add search results
        if self.search_results:
            html += f"""
        <div class="section">
            <h2>Dork Search Results</h2>
            <p>Found {len(self.search_results)} potential targets using Google dorking.</p>
            
            <table class="vulnerability-table">
                <tr><th>URL</th><th>Title</th><th>Search Engine</th><th>Dork</th></tr>
"""
            
            for result in self.search_results[:50]:  # Limit to first 50 results
                html += f"""
                <tr>
                    <td><code class="url-code">{html.escape(result.url)}</code></td>
                    <td>{html.escape(result.title)}</td>
                    <td>{result.search_engine.value}</td>
                    <td><code>{html.escape(result.dork)}</code></td>
                </tr>
"""
            
            html += """
            </table>
        </div>
"""
        
        return html
        
    def get_html_footer(self) -> str:
        """Get HTML footer"""
        return f"""
        <div class="footer">
            <p>Generated by BoomSQL v2.0.0 - Advanced SQL Injection Testing Tool</p>
            <p>Report generated on {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}</p>
            <p><strong>⚠️ FOR EDUCATIONAL AND AUTHORIZED TESTING ONLY</strong></p>
        </div>
    </div>
</body>
</html>
"""
        
    def generate_json_report(self, report_type: ReportType, output_path: Path):
        """Generate JSON report"""
        report_data = {
            "report_info": {
                "type": report_type.value,
                "format": "json",
                "generated": datetime.now().isoformat(),
                "generator": "BoomSQL v2.0.0"
            },
            "summary": self.summary.__dict__ if self.summary else {},
            "statistics": {
                "by_injection_type": {k.value: v for k, v in self.statistics.by_injection_type.items()} if self.statistics else {},
                "by_database_type": {k.value: v for k, v in self.statistics.by_database_type.items()} if self.statistics else {},
                "by_severity": {k.value: v for k, v in self.statistics.by_severity.items()} if self.statistics else {}
            },
            "vulnerabilities": []
        }
        
        # Add vulnerabilities
        for vuln in self.vulnerability_results:
            vuln_data = {
                "url": vuln.url,
                "injection_point": {
                    "vector": vuln.injection_point.vector.value,
                    "name": vuln.injection_point.name,
                    "value": vuln.injection_point.value
                },
                "payload": {
                    "title": vuln.payload.title,
                    "payload": vuln.payload.payload,
                    "risk": vuln.payload.risk,
                    "platform": vuln.payload.platform,
                    "category": vuln.payload.category
                },
                "injection_type": vuln.injection_type.value,
                "database_type": vuln.database_type.value,
                "confidence": vuln.confidence,
                "response_time": vuln.response_time,
                "evidence": vuln.evidence,
                "response_code": vuln.response_code,
                "severity": self.get_vulnerability_severity(vuln).value,
                "bypass_method": vuln.bypass_method,
                "timestamp": vuln.timestamp.isoformat()
            }
            report_data["vulnerabilities"].append(vuln_data)
            
        # Add database info if available
        if self.database_info:
            report_data["database_info"] = []
            for db in self.database_info:
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
                        "sample_data": table.data[:10]  # Include only first 10 rows
                    }
                    db_data["tables"].append(table_data)
                    
                report_data["database_info"].append(db_data)
                
        with open(output_path, 'w', encoding='utf-8') as f:
            json.dump(report_data, f, indent=2, ensure_ascii=False, default=str)
            
    def generate_xml_report(self, report_type: ReportType, output_path: Path):
        """Generate XML report"""
        root = ET.Element("report")
        root.set("type", report_type.value)
        root.set("format", "xml")
        root.set("generated", datetime.now().isoformat())
        root.set("generator", "BoomSQL v2.0.0")
        
        # Add summary
        if self.summary:
            summary_elem = ET.SubElement(root, "summary")
            ET.SubElement(summary_elem, "total_urls_tested").text = str(self.summary.total_urls_tested)
            ET.SubElement(summary_elem, "total_vulnerabilities").text = str(self.summary.total_vulnerabilities)
            ET.SubElement(summary_elem, "critical_vulnerabilities").text = str(self.summary.critical_vulnerabilities)
            ET.SubElement(summary_elem, "high_vulnerabilities").text = str(self.summary.high_vulnerabilities)
            ET.SubElement(summary_elem, "medium_vulnerabilities").text = str(self.summary.medium_vulnerabilities)
            ET.SubElement(summary_elem, "low_vulnerabilities").text = str(self.summary.low_vulnerabilities)
            
        # Add vulnerabilities
        vulns_elem = ET.SubElement(root, "vulnerabilities")
        for vuln in self.vulnerability_results:
            vuln_elem = ET.SubElement(vulns_elem, "vulnerability")
            vuln_elem.set("severity", self.get_vulnerability_severity(vuln).value)
            
            ET.SubElement(vuln_elem, "url").text = vuln.url
            ET.SubElement(vuln_elem, "injection_type").text = vuln.injection_type.value
            ET.SubElement(vuln_elem, "database_type").text = vuln.database_type.value
            ET.SubElement(vuln_elem, "confidence").text = str(vuln.confidence)
            ET.SubElement(vuln_elem, "response_time").text = str(vuln.response_time)
            ET.SubElement(vuln_elem, "evidence").text = vuln.evidence
            ET.SubElement(vuln_elem, "response_code").text = str(vuln.response_code)
            
            # Add injection point
            injection_elem = ET.SubElement(vuln_elem, "injection_point")
            injection_elem.set("vector", vuln.injection_point.vector.value)
            injection_elem.set("name", vuln.injection_point.name)
            injection_elem.set("value", vuln.injection_point.value)
            
            # Add payload
            payload_elem = ET.SubElement(vuln_elem, "payload")
            payload_elem.set("title", vuln.payload.title)
            payload_elem.set("risk", str(vuln.payload.risk))
            payload_elem.set("platform", vuln.payload.platform)
            payload_elem.text = vuln.payload.payload
            
        # Write to file
        tree = ET.ElementTree(root)
        tree.write(output_path, encoding='utf-8', xml_declaration=True)
        
    def generate_csv_report(self, report_type: ReportType, output_path: Path):
        """Generate CSV report"""
        with open(output_path, 'w', newline='', encoding='utf-8') as f:
            writer = csv.writer(f)
            
            # Header
            writer.writerow([
                'URL', 'Parameter', 'Injection Type', 'Database Type', 'Severity',
                'Confidence', 'Response Time', 'Response Code', 'Evidence',
                'Payload Title', 'Payload', 'Bypass Method', 'Timestamp'
            ])
            
            # Data
            for vuln in self.vulnerability_results:
                severity = self.get_vulnerability_severity(vuln)
                writer.writerow([
                    vuln.url,
                    vuln.injection_point.name,
                    vuln.injection_type.value,
                    vuln.database_type.value,
                    severity.value,
                    f"{vuln.confidence:.2f}",
                    f"{vuln.response_time:.2f}",
                    vuln.response_code,
                    vuln.evidence,
                    vuln.payload.title,
                    vuln.payload.payload,
                    vuln.bypass_method,
                    vuln.timestamp.isoformat()
                ])
                
    def generate_pdf_report(self, report_type: ReportType, output_path: Path):
        """Generate PDF report (placeholder - requires additional libraries)"""
        # This would require libraries like reportlab or weasyprint
        # For now, generate HTML and suggest conversion
        html_path = output_path.with_suffix('.html')
        self.generate_html_report(report_type, html_path)
        
        self.log_info(f"PDF generation not implemented. HTML report generated at {html_path}")
        self.log_info("Use a tool like wkhtmltopdf or Chrome headless to convert HTML to PDF")
        
    def get_risk_score(self) -> float:
        """Calculate overall risk score"""
        if not self.vulnerability_results:
            return 0.0
            
        total_score = 0.0
        for vuln in self.vulnerability_results:
            severity = self.get_vulnerability_severity(vuln)
            
            # Weight by severity
            if severity == SeverityLevel.CRITICAL:
                score = 10.0
            elif severity == SeverityLevel.HIGH:
                score = 7.0
            elif severity == SeverityLevel.MEDIUM:
                score = 4.0
            elif severity == SeverityLevel.LOW:
                score = 2.0
            else:
                score = 1.0
                
            # Multiply by confidence
            total_score += score * vuln.confidence
            
        # Normalize to 0-10 scale
        max_possible = len(self.vulnerability_results) * 10.0
        return min(total_score / max_possible * 10, 10.0) if max_possible > 0 else 0.0
        
    def get_cvss_score(self, vulnerability: VulnerabilityResult) -> Dict[str, Any]:
        """Calculate CVSS score for vulnerability (simplified)"""
        # This is a simplified CVSS calculation
        # In practice, you'd need more detailed analysis
        
        base_score = 0.0
        
        # Attack Vector (AV)
        av_score = 0.85  # Network accessible
        
        # Attack Complexity (AC)
        ac_score = 0.77 if vulnerability.confidence > 0.8 else 0.44
        
        # Privileges Required (PR)
        pr_score = 0.85  # None required
        
        # User Interaction (UI)
        ui_score = 0.85  # None required
        
        # Scope (S)
        scope_unchanged = True
        
        # Confidentiality (C)
        c_score = 0.56  # High impact
        
        # Integrity (I)
        i_score = 0.56  # High impact
        
        # Availability (A)
        a_score = 0.22  # Low impact
        
        # Calculate base score
        exploitability = 8.22 * av_score * ac_score * pr_score * ui_score
        
        if scope_unchanged:
            impact = 6.42 * (1 - (1 - c_score) * (1 - i_score) * (1 - a_score))
        else:
            impact = 7.52 * (6.42 * (1 - (1 - c_score) * (1 - i_score) * (1 - a_score)) - 0.029) - 3.25 * (6.42 * (1 - (1 - c_score) * (1 - i_score) * (1 - a_score)) - 0.02) ** 15
            
        if impact <= 0:
            base_score = 0
        elif scope_unchanged:
            base_score = min(1.08 * (impact + exploitability), 10)
        else:
            base_score = min(1.08 * (impact + exploitability), 10)
            
        return {
            "base_score": round(base_score, 1),
            "severity": "Critical" if base_score >= 9.0 else 
                       "High" if base_score >= 7.0 else 
                       "Medium" if base_score >= 4.0 else 
                       "Low",
            "vector": f"CVSS:3.1/AV:N/AC:L/PR:N/UI:N/S:U/C:H/I:H/A:L"
        }