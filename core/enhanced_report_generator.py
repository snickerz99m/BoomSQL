"""
Enhanced Report Generator for BoomSQL
Professional reporting with charts, graphs, and detailed findings
"""

import json
import time
from datetime import datetime
from typing import Dict, List, Optional, Any, Tuple
from pathlib import Path
import base64
import html
from dataclasses import dataclass, asdict

from .logger import LoggerMixin

@dataclass
class VulnerabilitySummary:
    """Summary of vulnerability findings"""
    total_vulnerabilities: int
    high_risk: int
    medium_risk: int
    low_risk: int
    info: int
    by_type: Dict[str, int]
    by_database: Dict[str, int]
    by_method: Dict[str, int]

@dataclass
class TestingSummary:
    """Summary of testing statistics"""
    total_tests: int
    total_requests: int
    success_rate: float
    average_response_time: float
    total_duration: float
    urls_tested: int
    parameters_tested: int
    payloads_tested: int
    
@dataclass
class ExecutiveSummary:
    """Executive summary for management"""
    risk_score: float
    vulnerability_count: int
    critical_findings: List[str]
    recommendations: List[str]
    business_impact: str
    remediation_timeline: str

class EnhancedReportGenerator(LoggerMixin):
    """Enhanced report generator with professional formatting"""
    
    def __init__(self, config: Dict[str, Any]):
        self.config = config
        self.report_data = {
            'metadata': self._generate_metadata(),
            'executive_summary': {},
            'vulnerability_summary': {},
            'testing_summary': {},
            'detailed_findings': [],
            'technical_details': {},
            'recommendations': [],
            'appendices': {}
        }
        
    def _generate_metadata(self) -> Dict[str, Any]:
        """Generate report metadata"""
        return {
            'tool_name': 'BoomSQL',
            'tool_version': '2.0.0',
            'report_format': 'Professional Security Assessment',
            'generated_at': datetime.now().isoformat(),
            'generated_by': 'BoomSQL Advanced SQL Injection Testing Tool',
            'scan_id': f"BSQL_{int(time.time())}",
            'report_type': 'SQL Injection Security Assessment'
        }
        
    def add_vulnerability_finding(self, finding: Dict[str, Any]):
        """Add a vulnerability finding to the report"""
        enhanced_finding = self._enhance_finding(finding)
        self.report_data['detailed_findings'].append(enhanced_finding)
        
    def _enhance_finding(self, finding: Dict[str, Any]) -> Dict[str, Any]:
        """Enhance vulnerability finding with additional details"""
        enhanced = {
            'id': f"BSQL-{len(self.report_data['detailed_findings']) + 1:04d}",
            'timestamp': datetime.now().isoformat(),
            'severity': self._calculate_severity(finding),
            'risk_rating': self._calculate_risk_rating(finding),
            'cvss_score': self._calculate_cvss_score(finding),
            'original_finding': finding
        }
        
        # Add technical details
        enhanced['technical_details'] = {
            'url': finding.get('url', 'N/A'),
            'parameter': finding.get('parameter', 'N/A'),
            'method': finding.get('method', 'GET'),
            'payload': finding.get('payload', 'N/A'),
            'injection_type': finding.get('injection_type', 'Unknown'),
            'database_type': finding.get('database_type', 'Unknown'),
            'confidence': finding.get('confidence', 0.0),
            'response_time': finding.get('response_time', 0.0),
            'response_code': finding.get('response_code', 0),
            'evidence': finding.get('evidence', [])
        }
        
        # Add impact assessment
        enhanced['impact_assessment'] = self._assess_impact(finding)
        
        # Add remediation guidance
        enhanced['remediation'] = self._generate_remediation(finding)
        
        return enhanced
        
    def _calculate_severity(self, finding: Dict[str, Any]) -> str:
        """Calculate severity based on finding characteristics"""
        confidence = finding.get('confidence', 0.0)
        injection_type = finding.get('injection_type', '').lower()
        
        # High severity conditions
        if confidence > 0.8:
            if any(term in injection_type for term in ['union', 'error', 'stacked']):
                return 'Critical'
            elif 'time' in injection_type or 'boolean' in injection_type:
                return 'High'
        
        # Medium severity conditions
        if confidence > 0.6:
            return 'Medium'
        
        # Low severity conditions
        if confidence > 0.3:
            return 'Low'
            
        return 'Info'
        
    def _calculate_risk_rating(self, finding: Dict[str, Any]) -> str:
        """Calculate risk rating"""
        severity = self._calculate_severity(finding)
        exploitability = self._assess_exploitability(finding)
        
        risk_matrix = {
            ('Critical', 'High'): 'Critical',
            ('Critical', 'Medium'): 'High',
            ('Critical', 'Low'): 'High',
            ('High', 'High'): 'High',
            ('High', 'Medium'): 'Medium',
            ('High', 'Low'): 'Medium',
            ('Medium', 'High'): 'Medium',
            ('Medium', 'Medium'): 'Medium',
            ('Medium', 'Low'): 'Low',
            ('Low', 'High'): 'Low',
            ('Low', 'Medium'): 'Low',
            ('Low', 'Low'): 'Info'
        }
        
        return risk_matrix.get((severity, exploitability), 'Info')
        
    def _calculate_cvss_score(self, finding: Dict[str, Any]) -> float:
        """Calculate CVSS score (simplified)"""
        base_score = 5.0
        
        # Adjust based on injection type
        injection_type = finding.get('injection_type', '').lower()
        if 'union' in injection_type:
            base_score += 2.0
        elif 'error' in injection_type:
            base_score += 1.5
        elif 'time' in injection_type:
            base_score += 1.0
        elif 'boolean' in injection_type:
            base_score += 0.5
            
        # Adjust based on confidence
        confidence = finding.get('confidence', 0.0)
        base_score *= confidence
        
        return min(base_score, 10.0)
        
    def _assess_exploitability(self, finding: Dict[str, Any]) -> str:
        """Assess exploitability level"""
        injection_type = finding.get('injection_type', '').lower()
        response_time = finding.get('response_time', 0.0)
        
        if 'union' in injection_type or 'error' in injection_type:
            return 'High'
        elif 'time' in injection_type and response_time > 5.0:
            return 'Medium'
        elif 'boolean' in injection_type:
            return 'Medium'
        else:
            return 'Low'
            
    def _assess_impact(self, finding: Dict[str, Any]) -> Dict[str, Any]:
        """Assess potential impact of the vulnerability"""
        injection_type = finding.get('injection_type', '').lower()
        database_type = finding.get('database_type', '').lower()
        
        impact = {
            'data_confidentiality': 'High',
            'data_integrity': 'High',
            'data_availability': 'Medium',
            'system_availability': 'Low'
        }
        
        # Adjust based on injection type
        if 'union' in injection_type:
            impact['data_confidentiality'] = 'Critical'
        elif 'stacked' in injection_type:
            impact['data_integrity'] = 'Critical'
            impact['system_availability'] = 'High'
        elif 'time' in injection_type:
            impact['data_availability'] = 'High'
            
        # Add potential consequences
        consequences = [
            'Unauthorized data access',
            'Data theft/exfiltration',
            'Data modification or deletion',
            'Authentication bypass',
            'Privilege escalation'
        ]
        
        if 'stacked' in injection_type:
            consequences.extend([
                'Remote code execution',
                'System compromise',
                'Lateral movement'
            ])
            
        impact['potential_consequences'] = consequences
        
        return impact
        
    def _generate_remediation(self, finding: Dict[str, Any]) -> Dict[str, Any]:
        """Generate remediation guidance"""
        injection_type = finding.get('injection_type', '').lower()
        
        remediation = {
            'immediate_actions': [
                'Disable the vulnerable parameter if possible',
                'Implement input validation',
                'Apply parameterized queries',
                'Enable SQL query logging for monitoring'
            ],
            'long_term_solutions': [
                'Implement prepared statements/parameterized queries',
                'Use stored procedures with proper input validation',
                'Implement least privilege database access',
                'Regular security code reviews',
                'Web Application Firewall (WAF) deployment'
            ],
            'testing_recommendations': [
                'Implement automated security testing in CI/CD',
                'Regular penetration testing',
                'Static code analysis',
                'Dynamic application security testing (DAST)'
            ]
        }
        
        # Add specific remediation based on injection type
        if 'union' in injection_type:
            remediation['immediate_actions'].append('Limit database user permissions')
        elif 'time' in injection_type:
            remediation['immediate_actions'].append('Implement query timeout limits')
        elif 'error' in injection_type:
            remediation['immediate_actions'].append('Implement proper error handling')
            
        return remediation
        
    def generate_executive_summary(self) -> ExecutiveSummary:
        """Generate executive summary"""
        findings = self.report_data['detailed_findings']
        
        # Calculate risk score
        if findings:
            risk_score = sum(f.get('cvss_score', 0) for f in findings) / len(findings)
        else:
            risk_score = 0.0
            
        # Critical findings
        critical_findings = [
            f"Critical SQL injection vulnerability in {f['technical_details']['url']}"
            for f in findings
            if f.get('severity') == 'Critical'
        ]
        
        # Recommendations
        recommendations = [
            'Implement parameterized queries across all database interactions',
            'Deploy Web Application Firewall (WAF) with SQL injection protection',
            'Conduct regular security code reviews',
            'Implement proper input validation and sanitization',
            'Apply principle of least privilege for database access'
        ]
        
        # Business impact
        business_impact = self._assess_business_impact(findings)
        
        return ExecutiveSummary(
            risk_score=risk_score,
            vulnerability_count=len(findings),
            critical_findings=critical_findings,
            recommendations=recommendations,
            business_impact=business_impact,
            remediation_timeline=self._calculate_remediation_timeline(findings)
        )
        
    def _assess_business_impact(self, findings: List[Dict[str, Any]]) -> str:
        """Assess business impact"""
        if not findings:
            return "Low - No vulnerabilities detected"
            
        critical_count = sum(1 for f in findings if f.get('severity') == 'Critical')
        high_count = sum(1 for f in findings if f.get('severity') == 'High')
        
        if critical_count > 0:
            return "Critical - Immediate risk of data breach and system compromise"
        elif high_count > 2:
            return "High - Significant risk of data exposure and unauthorized access"
        elif high_count > 0:
            return "Medium - Moderate risk of data exposure"
        else:
            return "Low - Limited risk with proper monitoring"
            
    def _calculate_remediation_timeline(self, findings: List[Dict[str, Any]]) -> str:
        """Calculate recommended remediation timeline"""
        if not findings:
            return "N/A"
            
        critical_count = sum(1 for f in findings if f.get('severity') == 'Critical')
        high_count = sum(1 for f in findings if f.get('severity') == 'High')
        
        if critical_count > 0:
            return "Immediate (24-48 hours)"
        elif high_count > 0:
            return "Urgent (1-2 weeks)"
        else:
            return "Standard (4-6 weeks)"
            
    def generate_vulnerability_summary(self) -> VulnerabilitySummary:
        """Generate vulnerability summary"""
        findings = self.report_data['detailed_findings']
        
        # Count by severity
        severity_counts = {}
        for finding in findings:
            severity = finding.get('severity', 'Info')
            severity_counts[severity] = severity_counts.get(severity, 0) + 1
            
        # Count by type
        type_counts = {}
        for finding in findings:
            injection_type = finding.get('technical_details', {}).get('injection_type', 'Unknown')
            type_counts[injection_type] = type_counts.get(injection_type, 0) + 1
            
        # Count by database
        database_counts = {}
        for finding in findings:
            database_type = finding.get('technical_details', {}).get('database_type', 'Unknown')
            database_counts[database_type] = database_counts.get(database_type, 0) + 1
            
        # Count by method
        method_counts = {}
        for finding in findings:
            method = finding.get('technical_details', {}).get('method', 'Unknown')
            method_counts[method] = method_counts.get(method, 0) + 1
            
        return VulnerabilitySummary(
            total_vulnerabilities=len(findings),
            high_risk=severity_counts.get('Critical', 0) + severity_counts.get('High', 0),
            medium_risk=severity_counts.get('Medium', 0),
            low_risk=severity_counts.get('Low', 0),
            info=severity_counts.get('Info', 0),
            by_type=type_counts,
            by_database=database_counts,
            by_method=method_counts
        )
        
    def generate_html_report(self) -> str:
        """Generate comprehensive HTML report"""
        executive_summary = self.generate_executive_summary()
        vulnerability_summary = self.generate_vulnerability_summary()
        
        html_template = """
        <!DOCTYPE html>
        <html>
        <head>
            <title>BoomSQL Security Assessment Report</title>
            <style>
                body {{ font-family: Arial, sans-serif; margin: 20px; }}
                .header {{ background: #2c3e50; color: white; padding: 20px; text-align: center; }}
                .summary {{ background: #ecf0f1; padding: 15px; margin: 20px 0; }}
                .critical {{ color: #e74c3c; font-weight: bold; }}
                .high {{ color: #e67e22; font-weight: bold; }}
                .medium {{ color: #f39c12; font-weight: bold; }}
                .low {{ color: #27ae60; font-weight: bold; }}
                .finding {{ margin: 15px 0; padding: 15px; border: 1px solid #ddd; }}
                .technical {{ background: #f8f9fa; padding: 10px; margin: 10px 0; }}
                .recommendations {{ background: #d5f4e6; padding: 15px; margin: 20px 0; }}
                table {{ width: 100%; border-collapse: collapse; }}
                th, td {{ border: 1px solid #ddd; padding: 8px; text-align: left; }}
                th {{ background: #f2f2f2; }}
                .chart {{ margin: 20px 0; text-align: center; }}
            </style>
        </head>
        <body>
            <div class="header">
                <h1>BoomSQL Security Assessment Report</h1>
                <p>Generated on {timestamp}</p>
                <p>Scan ID: {scan_id}</p>
            </div>
            
            <div class="summary">
                <h2>Executive Summary</h2>
                <p><strong>Risk Score:</strong> {risk_score:.1f}/10</p>
                <p><strong>Vulnerabilities Found:</strong> {vulnerability_count}</p>
                <p><strong>Business Impact:</strong> {business_impact}</p>
                <p><strong>Recommended Timeline:</strong> {remediation_timeline}</p>
            </div>
            
            <div class="summary">
                <h2>Vulnerability Summary</h2>
                <table>
                    <tr>
                        <th>Severity</th>
                        <th>Count</th>
                    </tr>
                    <tr>
                        <td>Critical/High Risk</td>
                        <td class="high">{high_risk}</td>
                    </tr>
                    <tr>
                        <td>Medium Risk</td>
                        <td class="medium">{medium_risk}</td>
                    </tr>
                    <tr>
                        <td>Low Risk</td>
                        <td class="low">{low_risk}</td>
                    </tr>
                    <tr>
                        <td>Informational</td>
                        <td>{info}</td>
                    </tr>
                </table>
            </div>
            
            <div class="recommendations">
                <h2>Key Recommendations</h2>
                <ul>
                    {recommendations}
                </ul>
            </div>
            
            <h2>Detailed Findings</h2>
            {detailed_findings}
            
            <div class="summary">
                <h2>Report Information</h2>
                <p><strong>Tool:</strong> BoomSQL v2.0.0</p>
                <p><strong>Report Type:</strong> SQL Injection Security Assessment</p>
                <p><strong>Generated:</strong> {timestamp}</p>
            </div>
        </body>
        </html>
        """
        
        # Format findings
        findings_html = ""
        for finding in self.report_data['detailed_findings']:
            severity_class = finding.get('severity', 'info').lower()
            findings_html += f"""
            <div class="finding">
                <h3 class="{severity_class}">Finding {finding['id']} - {finding['severity']} Risk</h3>
                <div class="technical">
                    <p><strong>URL:</strong> {finding['technical_details']['url']}</p>
                    <p><strong>Parameter:</strong> {finding['technical_details']['parameter']}</p>
                    <p><strong>Injection Type:</strong> {finding['technical_details']['injection_type']}</p>
                    <p><strong>Database Type:</strong> {finding['technical_details']['database_type']}</p>
                    <p><strong>Confidence:</strong> {finding['technical_details']['confidence']:.1%}</p>
                    <p><strong>CVSS Score:</strong> {finding['cvss_score']:.1f}</p>
                </div>
                <div class="recommendations">
                    <h4>Remediation</h4>
                    <ul>
                        {"".join(f"<li>{action}</li>" for action in finding['remediation']['immediate_actions'])}
                    </ul>
                </div>
            </div>
            """
        
        # Format recommendations
        recommendations_html = "".join(f"<li>{rec}</li>" for rec in executive_summary.recommendations)
        
        return html_template.format(
            timestamp=self.report_data['metadata']['generated_at'],
            scan_id=self.report_data['metadata']['scan_id'],
            risk_score=executive_summary.risk_score,
            vulnerability_count=executive_summary.vulnerability_count,
            business_impact=executive_summary.business_impact,
            remediation_timeline=executive_summary.remediation_timeline,
            high_risk=vulnerability_summary.high_risk,
            medium_risk=vulnerability_summary.medium_risk,
            low_risk=vulnerability_summary.low_risk,
            info=vulnerability_summary.info,
            recommendations=recommendations_html,
            detailed_findings=findings_html
        )
        
    def save_report(self, filename: str, format: str = 'html'):
        """Save report to file"""
        if format.lower() == 'html':
            content = self.generate_html_report()
            with open(filename, 'w', encoding='utf-8') as f:
                f.write(content)
        elif format.lower() == 'json':
            with open(filename, 'w', encoding='utf-8') as f:
                json.dump(self.report_data, f, indent=2, ensure_ascii=False)
        else:
            raise ValueError(f"Unsupported format: {format}")
            
        self.log_info(f"Report saved to {filename}")
        
    def export_findings_csv(self, filename: str):
        """Export findings to CSV"""
        import csv
        
        with open(filename, 'w', newline='', encoding='utf-8') as csvfile:
            writer = csv.writer(csvfile)
            
            # Header
            writer.writerow([
                'ID', 'Severity', 'Risk Rating', 'CVSS Score', 'URL', 'Parameter',
                'Injection Type', 'Database Type', 'Confidence', 'Response Time'
            ])
            
            # Data
            for finding in self.report_data['detailed_findings']:
                writer.writerow([
                    finding['id'],
                    finding['severity'],
                    finding['risk_rating'],
                    finding['cvss_score'],
                    finding['technical_details']['url'],
                    finding['technical_details']['parameter'],
                    finding['technical_details']['injection_type'],
                    finding['technical_details']['database_type'],
                    finding['technical_details']['confidence'],
                    finding['technical_details']['response_time']
                ])
                
        self.log_info(f"CSV export saved to {filename}")