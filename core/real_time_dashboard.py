"""
Real-time Dashboard Module for BoomSQL
Provides live monitoring and visualization of security testing activities
"""

import json
import time
import threading
from typing import Dict, List, Optional, Any, Callable
from dataclasses import dataclass, asdict
from datetime import datetime, timedelta
import statistics
from collections import deque, defaultdict

from .ai_vulnerability_analyzer import AIVulnerabilityAnalyzer, AIAnalysisResult, SecurityMetrics
from .sql_injection_engine import VulnerabilityResult
from .logger import LoggerMixin

@dataclass
class DashboardMetrics:
    """Real-time dashboard metrics"""
    timestamp: str
    total_requests: int
    vulnerabilities_found: int
    success_rate: float
    average_response_time: float
    active_scans: int
    security_score: float
    risk_distribution: Dict[str, int]
    performance_metrics: Dict[str, float]
    system_status: str

@dataclass
class ScanActivity:
    """Individual scan activity record"""
    timestamp: str
    target_url: str
    scan_type: str
    status: str
    vulnerabilities_found: int
    duration: float
    risk_level: str

class RealTimeDashboard(LoggerMixin):
    """Real-time dashboard for BoomSQL operations"""
    
    def __init__(self):
        self.ai_analyzer = AIVulnerabilityAnalyzer()
        
        # Data storage
        self.metrics_history = deque(maxlen=1000)  # Last 1000 metrics
        self.scan_activities = deque(maxlen=500)   # Last 500 activities
        self.vulnerabilities = []
        self.active_scans = {}
        
        # Performance tracking
        self.request_times = deque(maxlen=100)
        self.response_times = deque(maxlen=100)
        self.error_count = 0
        self.success_count = 0
        
        # Real-time monitoring
        self.is_monitoring = False
        self.monitoring_thread = None
        self.update_callbacks = []
        
        # Statistics
        self.session_start_time = time.time()
        self.total_requests = 0
        self.total_vulnerabilities = 0
        
        self.log_info("Real-time dashboard initialized")
    
    def start_monitoring(self, update_interval: float = 1.0):
        """Start real-time monitoring"""
        if self.is_monitoring:
            return
        
        self.is_monitoring = True
        self.monitoring_thread = threading.Thread(
            target=self._monitoring_loop,
            args=(update_interval,),
            daemon=True
        )
        self.monitoring_thread.start()
        self.log_info("Real-time monitoring started")
    
    def stop_monitoring(self):
        """Stop real-time monitoring"""
        self.is_monitoring = False
        if self.monitoring_thread:
            self.monitoring_thread.join(timeout=2.0)
        self.log_info("Real-time monitoring stopped")
    
    def _monitoring_loop(self, update_interval: float):
        """Main monitoring loop"""
        while self.is_monitoring:
            try:
                metrics = self._collect_metrics()
                self.metrics_history.append(metrics)
                
                # Notify callbacks
                for callback in self.update_callbacks:
                    try:
                        callback(metrics)
                    except Exception as e:
                        self.log_error(f"Dashboard callback error: {e}")
                
                time.sleep(update_interval)
                
            except Exception as e:
                self.log_error(f"Monitoring loop error: {e}")
                time.sleep(update_interval)
    
    def _collect_metrics(self) -> DashboardMetrics:
        """Collect current metrics"""
        now = datetime.now().isoformat()
        
        # Calculate success rate
        total_ops = self.success_count + self.error_count
        success_rate = (self.success_count / total_ops * 100) if total_ops > 0 else 0
        
        # Calculate average response time
        avg_response_time = statistics.mean(self.response_times) if self.response_times else 0
        
        # Get security metrics
        security_metrics = self.ai_analyzer.generate_security_metrics(self.vulnerabilities)
        
        # Risk distribution
        risk_distribution = {
            "critical": security_metrics.critical_count,
            "high": security_metrics.high_count,
            "medium": security_metrics.medium_count,
            "low": security_metrics.low_count
        }
        
        # Performance metrics
        performance_metrics = {
            "requests_per_second": self._calculate_requests_per_second(),
            "average_scan_time": self._calculate_average_scan_time(),
            "memory_usage": self._estimate_memory_usage(),
            "cpu_usage": self._estimate_cpu_usage()
        }
        
        # System status
        system_status = self._determine_system_status(security_metrics, performance_metrics)
        
        return DashboardMetrics(
            timestamp=now,
            total_requests=self.total_requests,
            vulnerabilities_found=len(self.vulnerabilities),
            success_rate=success_rate,
            average_response_time=avg_response_time,
            active_scans=len(self.active_scans),
            security_score=security_metrics.security_score,
            risk_distribution=risk_distribution,
            performance_metrics=performance_metrics,
            system_status=system_status
        )
    
    def _calculate_requests_per_second(self) -> float:
        """Calculate current requests per second"""
        if len(self.request_times) < 2:
            return 0.0
        
        recent_requests = [t for t in self.request_times if time.time() - t < 60]  # Last minute
        return len(recent_requests) / 60.0
    
    def _calculate_average_scan_time(self) -> float:
        """Calculate average scan time"""
        if not self.scan_activities:
            return 0.0
        
        recent_scans = [a for a in self.scan_activities if a.status == "completed"]
        if not recent_scans:
            return 0.0
        
        return statistics.mean(scan.duration for scan in recent_scans[-10:])  # Last 10 scans
    
    def _estimate_memory_usage(self) -> float:
        """Estimate memory usage (simplified)"""
        # Simple estimation based on data structures
        base_memory = 50.0  # MB base usage
        vuln_memory = len(self.vulnerabilities) * 0.1  # 0.1 MB per vulnerability
        metrics_memory = len(self.metrics_history) * 0.05  # 0.05 MB per metric
        return base_memory + vuln_memory + metrics_memory
    
    def _estimate_cpu_usage(self) -> float:
        """Estimate CPU usage (simplified)"""
        # Simple estimation based on active operations
        base_cpu = 5.0  # 5% base usage
        scan_cpu = len(self.active_scans) * 15.0  # 15% per active scan
        return min(base_cpu + scan_cpu, 100.0)
    
    def _determine_system_status(self, security_metrics: SecurityMetrics, 
                                performance_metrics: Dict[str, float]) -> str:
        """Determine overall system status"""
        # Check security issues
        if security_metrics.critical_count > 0:
            return "critical_vulnerabilities"
        elif security_metrics.high_count > 5:
            return "high_risk"
        
        # Check performance issues
        if performance_metrics["memory_usage"] > 500:  # 500 MB
            return "high_memory_usage"
        elif performance_metrics["cpu_usage"] > 80:
            return "high_cpu_usage"
        
        # Check scan activity
        if len(self.active_scans) > 10:
            return "high_load"
        elif len(self.active_scans) == 0:
            return "idle"
        
        return "normal"
    
    def record_request(self, url: str, response_time: float, success: bool):
        """Record a request for monitoring"""
        self.total_requests += 1
        self.request_times.append(time.time())
        self.response_times.append(response_time)
        
        if success:
            self.success_count += 1
        else:
            self.error_count += 1
        
        self.log_debug(f"Request recorded: {url} ({response_time:.2f}s, {'success' if success else 'error'})")
    
    def start_scan(self, scan_id: str, target_url: str, scan_type: str):
        """Record start of a scan"""
        self.active_scans[scan_id] = {
            "target_url": target_url,
            "scan_type": scan_type,
            "start_time": time.time(),
            "status": "running"
        }
        
        activity = ScanActivity(
            timestamp=datetime.now().isoformat(),
            target_url=target_url,
            scan_type=scan_type,
            status="started",
            vulnerabilities_found=0,
            duration=0.0,
            risk_level="unknown"
        )
        self.scan_activities.append(activity)
        
        self.log_info(f"Scan started: {scan_id} -> {target_url}")
    
    def complete_scan(self, scan_id: str, vulnerabilities: List[VulnerabilityResult]):
        """Record completion of a scan"""
        if scan_id not in self.active_scans:
            return
        
        scan_info = self.active_scans.pop(scan_id)
        duration = time.time() - scan_info["start_time"]
        
        # Add vulnerabilities to our collection
        self.vulnerabilities.extend(vulnerabilities)
        self.total_vulnerabilities += len(vulnerabilities)
        
        # Determine risk level
        if vulnerabilities:
            analyses = [self.ai_analyzer.analyze_vulnerability(v) for v in vulnerabilities]
            max_risk = max(a.risk_level.value for a in analyses)
        else:
            max_risk = "none"
        
        activity = ScanActivity(
            timestamp=datetime.now().isoformat(),
            target_url=scan_info["target_url"],
            scan_type=scan_info["scan_type"],
            status="completed",
            vulnerabilities_found=len(vulnerabilities),
            duration=duration,
            risk_level=max_risk
        )
        self.scan_activities.append(activity)
        
        self.log_info(f"Scan completed: {scan_id} -> {len(vulnerabilities)} vulnerabilities found")
    
    def add_update_callback(self, callback: Callable[[DashboardMetrics], None]):
        """Add callback for dashboard updates"""
        self.update_callbacks.append(callback)
    
    def remove_update_callback(self, callback: Callable[[DashboardMetrics], None]):
        """Remove callback for dashboard updates"""
        if callback in self.update_callbacks:
            self.update_callbacks.remove(callback)
    
    def get_current_metrics(self) -> Optional[DashboardMetrics]:
        """Get current metrics"""
        if self.metrics_history:
            return self.metrics_history[-1]
        return self._collect_metrics()
    
    def get_metrics_history(self, minutes: int = 60) -> List[DashboardMetrics]:
        """Get metrics history for specified time period"""
        cutoff_time = datetime.now() - timedelta(minutes=minutes)
        
        return [
            metric for metric in self.metrics_history
            if datetime.fromisoformat(metric.timestamp) > cutoff_time
        ]
    
    def get_recent_activities(self, count: int = 20) -> List[ScanActivity]:
        """Get recent scan activities"""
        return list(self.scan_activities)[-count:]
    
    def get_vulnerability_summary(self) -> Dict[str, Any]:
        """Get vulnerability summary"""
        if not self.vulnerabilities:
            return {
                "total": 0,
                "by_type": {},
                "by_database": {},
                "by_risk": {},
                "trending": []
            }
        
        # Group by type
        by_type = defaultdict(int)
        for vuln in self.vulnerabilities:
            if vuln.injection_type:
                by_type[vuln.injection_type.value] += 1
        
        # Group by database
        by_database = defaultdict(int)
        for vuln in self.vulnerabilities:
            if vuln.database_type:
                by_database[vuln.database_type.value] += 1
        
        # Analyze with AI for risk distribution
        analyses = [self.ai_analyzer.analyze_vulnerability(v) for v in self.vulnerabilities]
        by_risk = defaultdict(int)
        for analysis in analyses:
            by_risk[analysis.risk_level.value] += 1
        
        # Trending analysis (simplified)
        recent_vulns = self.vulnerabilities[-50:]  # Last 50 vulnerabilities
        trending = []
        if recent_vulns:
            recent_types = [v.injection_type.value for v in recent_vulns if v.injection_type]
            if recent_types:
                from collections import Counter
                most_common = Counter(recent_types).most_common(3)
                trending = [{"type": t, "count": c} for t, c in most_common]
        
        return {
            "total": len(self.vulnerabilities),
            "by_type": dict(by_type),
            "by_database": dict(by_database),
            "by_risk": dict(by_risk),
            "trending": trending
        }
    
    def get_performance_summary(self) -> Dict[str, Any]:
        """Get performance summary"""
        current_metrics = self.get_current_metrics()
        if not current_metrics:
            return {}
        
        session_duration = time.time() - self.session_start_time
        
        return {
            "session_duration": session_duration,
            "total_requests": self.total_requests,
            "success_rate": current_metrics.success_rate,
            "average_response_time": current_metrics.average_response_time,
            "requests_per_second": current_metrics.performance_metrics["requests_per_second"],
            "active_scans": current_metrics.active_scans,
            "system_status": current_metrics.system_status,
            "resource_usage": {
                "memory_mb": current_metrics.performance_metrics["memory_usage"],
                "cpu_percent": current_metrics.performance_metrics["cpu_usage"]
            }
        }
    
    def export_dashboard_data(self) -> Dict[str, Any]:
        """Export all dashboard data"""
        return {
            "session_info": {
                "start_time": datetime.fromtimestamp(self.session_start_time).isoformat(),
                "duration": time.time() - self.session_start_time,
                "export_time": datetime.now().isoformat()
            },
            "current_metrics": asdict(self.get_current_metrics()) if self.get_current_metrics() else {},
            "metrics_history": [asdict(m) for m in self.metrics_history],
            "scan_activities": [asdict(a) for a in self.scan_activities],
            "vulnerability_summary": self.get_vulnerability_summary(),
            "performance_summary": self.get_performance_summary(),
            "security_metrics": asdict(self.ai_analyzer.generate_security_metrics(self.vulnerabilities))
        }
    
    def generate_text_dashboard(self) -> str:
        """Generate text-based dashboard for CLI"""
        current = self.get_current_metrics()
        if not current:
            return "Dashboard not available"
        
        vuln_summary = self.get_vulnerability_summary()
        perf_summary = self.get_performance_summary()
        
        dashboard_text = f"""
╔════════════════════════════════════════════════════════════════════════════════╗
║                           🚀 BoomSQL Real-time Dashboard                      ║
╠════════════════════════════════════════════════════════════════════════════════╣
║ Time: {current.timestamp[:19]}                     Status: {current.system_status.upper():>15} ║
╠════════════════════════════════════════════════════════════════════════════════╣
║                                📊 SECURITY METRICS                            ║
║ Security Score: {current.security_score:>6.1f}/100          Vulnerabilities Found: {current.vulnerabilities_found:>6} ║
║ Critical: {current.risk_distribution['critical']:>3}  High: {current.risk_distribution['high']:>3}  Medium: {current.risk_distribution['medium']:>3}  Low: {current.risk_distribution['low']:>3}          ║
╠════════════════════════════════════════════════════════════════════════════════╣
║                               ⚡ PERFORMANCE METRICS                           ║
║ Total Requests: {current.total_requests:>8}           Success Rate: {current.success_rate:>6.1f}%        ║
║ Avg Response: {current.average_response_time:>8.2f}s          Active Scans: {current.active_scans:>6}         ║
║ Requests/sec: {current.performance_metrics['requests_per_second']:>8.1f}           Memory: {current.performance_metrics['memory_usage']:>6.1f} MB       ║
║ CPU Usage: {current.performance_metrics['cpu_usage']:>8.1f}%           Session: {perf_summary.get('session_duration', 0)/60:>6.1f} min       ║
╠════════════════════════════════════════════════════════════════════════════════╣
║                              🎯 RECENT ACTIVITY                               ║"""
        
        # Add recent activities
        recent_activities = self.get_recent_activities(5)
        if recent_activities:
            for activity in recent_activities[-5:]:
                timestamp = activity.timestamp[11:19]  # HH:MM:SS
                status_icon = "✅" if activity.status == "completed" else "🔄"
                risk_icon = {"critical": "🔴", "high": "🟠", "medium": "🟡", "low": "🟢"}.get(activity.risk_level, "⚪")
                
                url_short = activity.target_url[:40] + "..." if len(activity.target_url) > 43 else activity.target_url
                dashboard_text += f"""
║ {timestamp} {status_icon} {url_short:<43} {risk_icon} {activity.vulnerabilities_found:>2} vulns ║"""
        else:
            dashboard_text += """
║ No recent activity                                                            ║"""
        
        dashboard_text += """
╚════════════════════════════════════════════════════════════════════════════════╝
"""
        return dashboard_text
