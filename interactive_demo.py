#!/usr/bin/env python3
"""
BoomSQL Interactive CLI with AI Analysis and Real-time Dashboard
Demonstrates innovative features including AI-powered vulnerability analysis
"""

import sys
import os
import time
import asyncio
from pathlib import Path

# Add the project root to Python path
project_root = Path(__file__).parent
sys.path.insert(0, str(project_root))

from core.config_manager import ConfigManager
from core.sql_injection_engine import SqlInjectionEngine, VulnerabilityResult, DatabaseType, InjectionType
from core.ai_vulnerability_analyzer import AIVulnerabilityAnalyzer, VulnerabilityRisk
from core.real_time_dashboard import RealTimeDashboard
from core.event_loop_manager import get_event_loop_manager
import json
import random

class BoomSQLCLI:
    """Interactive CLI for BoomSQL with innovative features"""
    
    def __init__(self):
        print("🚀 Initializing BoomSQL Advanced CLI...")
        
        # Load configuration
        self.config = ConfigManager().get_config()
        
        # Initialize components
        self.sql_engine = SqlInjectionEngine(self.config)
        self.ai_analyzer = AIVulnerabilityAnalyzer()
        self.dashboard = RealTimeDashboard()
        self.event_manager = get_event_loop_manager()
        
        # Demo data
        self.demo_vulnerabilities = []
        
        print("✅ BoomSQL Advanced CLI Ready!")
    
    def run(self):
        """Run the interactive CLI"""
        print("""
╔══════════════════════════════════════════════════════════════════════════════════╗
║                  🎯 BoomSQL Advanced CLI - Innovative Demo                      ║
║                                                                                  ║
║  Features:                                                                       ║
║  • 🤖 AI-Powered Vulnerability Analysis                                         ║
║  • 📊 Real-time Security Dashboard                                              ║
║  • 🔍 Advanced SQL Injection Testing                                            ║
║  • 📈 Comprehensive Risk Assessment                                             ║
║                                                                                  ║
╚══════════════════════════════════════════════════════════════════════════════════╝
""")
        
        while True:
            try:
                choice = self.show_menu()
                
                if choice == '1':
                    self.demo_ai_analysis()
                elif choice == '2':
                    self.demo_real_time_dashboard()
                elif choice == '3':
                    self.demo_vulnerability_testing()
                elif choice == '4':
                    self.demo_security_metrics()
                elif choice == '5':
                    self.demo_automated_scanning()
                elif choice == '6':
                    self.show_system_status()
                elif choice == '0':
                    print("\n👋 Thank you for using BoomSQL Advanced CLI!")
                    break
                else:
                    print("❌ Invalid choice. Please try again.")
                    
            except KeyboardInterrupt:
                print("\n\n🛑 Interrupted by user. Goodbye!")
                break
            except Exception as e:
                print(f"\n❌ Error: {e}")
                input("Press Enter to continue...")
    
    def show_menu(self):
        """Show the main menu"""
        print("""
┌─────────────────────────────────────────────────────────────────────────────────┐
│                           🎮 BoomSQL Advanced Menu                             │
├─────────────────────────────────────────────────────────────────────────────────┤
│  1. 🤖 AI-Powered Vulnerability Analysis Demo                                  │
│  2. 📊 Real-time Security Dashboard                                            │
│  3. 🔍 Advanced SQL Injection Testing                                          │
│  4. 📈 Security Metrics & Risk Assessment                                      │
│  5. 🚀 Automated Multi-target Scanning                                         │
│  6. 🛠️  System Status & Configuration                                           │
│  0. 🚪 Exit                                                                     │
└─────────────────────────────────────────────────────────────────────────────────┘
""")
        return input("🎯 Choose an option: ").strip()
    
    def demo_ai_analysis(self):
        """Demonstrate AI-powered vulnerability analysis"""
        print("\n🤖 AI-Powered Vulnerability Analysis Demo")
        print("=" * 60)
        
        # Create demo vulnerabilities
        demo_vulns = self.create_demo_vulnerabilities()
        
        print(f"\n📋 Analyzing {len(demo_vulns)} vulnerabilities with AI engine...")
        time.sleep(1)
        
        for i, vuln in enumerate(demo_vulns, 1):
            print(f"\n🔍 Analysis {i}/{len(demo_vulns)}: {vuln.url}")
            print("-" * 50)
            
            # Perform AI analysis
            analysis = self.ai_analyzer.analyze_vulnerability(vuln)
            
            # Display results
            self.display_ai_analysis(analysis, vuln)
            
            if i < len(demo_vulns):
                input("\n⏸️  Press Enter for next analysis...")
        
        print("\n✅ AI Analysis Demo Complete!")
        input("Press Enter to continue...")
    
    def create_demo_vulnerabilities(self):
        """Create demo vulnerabilities for testing"""
        demo_data = [
            {
                "url": "https://bank.example.com/login?user_id=1",
                "parameter": "user_id",
                "payload": "1' UNION SELECT username,password FROM users--",
                "database_type": DatabaseType.MYSQL,
                "injection_type": InjectionType.UNION_BASED,
                "confidence": 0.95,
                "error_message": "You have an error in your SQL syntax"
            },
            {
                "url": "https://admin.corp.com/dashboard?id=1",
                "parameter": "id",
                "payload": "1; EXEC xp_cmdshell('whoami')",
                "database_type": DatabaseType.MSSQL,
                "injection_type": InjectionType.ERROR_BASED,
                "confidence": 0.89,
                "error_message": "Conversion failed when converting"
            },
            {
                "url": "https://shop.example.com/product?item=123",
                "parameter": "item",
                "payload": "123 AND (SELECT SUBSTRING(@@version,1,1))='5'",
                "database_type": DatabaseType.MYSQL,
                "injection_type": InjectionType.BLIND_BOOLEAN,
                "confidence": 0.78,
                "error_message": None
            }
        ]
        
        vulnerabilities = []
        for data in demo_data:
            vuln = VulnerabilityResult()
            vuln.url = data["url"]
            vuln.parameter = data["parameter"]
            vuln.payload = data["payload"]
            vuln.database_type = data["database_type"]
            vuln.injection_type = data["injection_type"]
            vuln.confidence = data["confidence"]
            vuln.error_message = data["error_message"]
            vulnerabilities.append(vuln)
        
        return vulnerabilities
    
    def display_ai_analysis(self, analysis, vuln):
        """Display AI analysis results"""
        risk_colors = {
            VulnerabilityRisk.CRITICAL: "🔴",
            VulnerabilityRisk.HIGH: "🟠",
            VulnerabilityRisk.MEDIUM: "🟡",
            VulnerabilityRisk.LOW: "🟢",
            VulnerabilityRisk.INFO: "🔵"
        }
        
        risk_icon = risk_colors.get(analysis.risk_level, "⚪")
        
        print(f"🆔 Vulnerability ID: {analysis.vulnerability_id}")
        print(f"{risk_icon} Risk Level: {analysis.risk_level.value.upper()} (Score: {analysis.risk_score:.1f}/10)")
        print(f"🎯 Confidence: {analysis.confidence:.1%}")
        print(f"⚙️  Complexity: {analysis.exploitation_complexity}")
        
        print(f"\n🎯 Attack Vectors:")
        for vector in analysis.attack_vectors:
            print(f"   • {vector.value.replace('_', ' ').title()}")
        
        print(f"\n💥 Impact Analysis:")
        print(f"   • Business Impact: {analysis.impact_analysis['business_impact']}")
        print(f"   • Data Breach Risk: {analysis.impact_analysis['data_breach_risk']:.1f}%")
        
        print(f"\n🛡️  Top Remediation Suggestions:")
        for i, suggestion in enumerate(analysis.remediation_suggestions[:3], 1):
            print(f"   {i}. {suggestion}")
        
        print(f"\n⚠️  Compliance Violations:")
        violations = analysis.impact_analysis.get('compliance_violations', [])
        for violation in violations[:3]:
            print(f"   • {violation}")
    
    def demo_real_time_dashboard(self):
        """Demonstrate real-time dashboard"""
        print("\n📊 Real-time Security Dashboard Demo")
        print("=" * 60)
        
        # Start dashboard monitoring
        self.dashboard.start_monitoring()
        
        # Simulate some scanning activity
        print("\n🎬 Simulating scanning activity...")
        self.simulate_scanning_activity()
        
        # Display dashboard for 10 seconds
        print("\n📊 Live Dashboard (updating every 2 seconds)")
        print("Press Ctrl+C to stop dashboard...")
        
        try:
            for i in range(5):  # Show for 10 seconds
                os.system('clear' if os.name == 'posix' else 'cls')
                dashboard_text = self.dashboard.generate_text_dashboard()
                print(dashboard_text)
                time.sleep(2)
        except KeyboardInterrupt:
            pass
        
        print("\n📈 Dashboard Summary:")
        summary = self.dashboard.export_dashboard_data()
        print(json.dumps(summary['performance_summary'], indent=2))
        
        self.dashboard.stop_monitoring()
        input("\nPress Enter to continue...")
    
    def simulate_scanning_activity(self):
        """Simulate scanning activity for dashboard demo"""
        targets = [
            "https://example.com/login",
            "https://test.com/admin",
            "https://demo.com/api/users",
            "https://app.com/dashboard"
        ]
        
        # Start some scans
        for i, target in enumerate(targets):
            scan_id = f"scan_{i+1}"
            self.dashboard.start_scan(scan_id, target, "sql_injection")
            time.sleep(0.5)
            
            # Simulate requests
            for j in range(random.randint(5, 15)):
                self.dashboard.record_request(
                    f"{target}?id={j}",
                    random.uniform(0.1, 2.0),
                    random.choice([True, True, True, False])  # 75% success rate
                )
            
            # Complete scan with some vulnerabilities
            vulns = []
            if random.random() > 0.3:  # 70% chance of finding vulnerabilities
                vulns = self.create_demo_vulnerabilities()[:random.randint(1, 2)]
            
            self.dashboard.complete_scan(scan_id, vulns)
    
    def demo_vulnerability_testing(self):
        """Demonstrate advanced vulnerability testing"""
        print("\n🔍 Advanced SQL Injection Testing Demo")
        print("=" * 60)
        
        test_urls = [
            "https://example.com/login?user=admin&pass=123",
            "https://test.com/search?q=test&category=1",
            "https://demo.com/profile?id=1&action=view"
        ]
        
        print("\n🎯 Testing URLs for SQL injection vulnerabilities...")
        
        for url in test_urls:
            print(f"\n🌐 Testing: {url}")
            print("-" * 50)
            
            # Simulate testing
            print("⏳ Scanning for injection points...")
            time.sleep(1)
            
            print("🔍 Testing payloads...")
            time.sleep(1)
            
            # Simulate results
            if random.random() > 0.4:  # 60% chance of vulnerability
                vuln = random.choice(self.create_demo_vulnerabilities())
                vuln.url = url
                
                print(f"🚨 VULNERABILITY FOUND!")
                print(f"   Type: {vuln.injection_type.value}")
                print(f"   Database: {vuln.database_type.value}")
                print(f"   Parameter: {vuln.parameter}")
                print(f"   Confidence: {vuln.confidence:.1%}")
                
                # Perform AI analysis
                analysis = self.ai_analyzer.analyze_vulnerability(vuln)
                print(f"   AI Risk Score: {analysis.risk_score:.1f}/10")
                print(f"   Risk Level: {analysis.risk_level.value.upper()}")
            else:
                print("✅ No vulnerabilities detected")
        
        print("\n✅ Vulnerability Testing Demo Complete!")
        input("Press Enter to continue...")
    
    def demo_security_metrics(self):
        """Demonstrate security metrics and risk assessment"""
        print("\n📈 Security Metrics & Risk Assessment Demo")
        print("=" * 60)
        
        # Generate demo vulnerabilities
        all_vulns = []
        for _ in range(random.randint(8, 15)):
            vuln = random.choice(self.create_demo_vulnerabilities())
            # Randomize some properties
            vuln.confidence = random.uniform(0.6, 0.98)
            all_vulns.append(vuln)
        
        print(f"\n📊 Analyzing {len(all_vulns)} vulnerabilities for security metrics...")
        
        # Generate security metrics
        metrics = self.ai_analyzer.generate_security_metrics(all_vulns)
        
        print(f"""
╔══════════════════════════════════════════════════════════════════════════════════╗
║                            🛡️  SECURITY ASSESSMENT REPORT                       ║
╠══════════════════════════════════════════════════════════════════════════════════╣
║ Overall Security Score: {metrics.security_score:>6.1f}/100                                     ║
║                                                                                  ║
║ Vulnerability Distribution:                                                      ║
║   🔴 Critical: {metrics.critical_count:>3}                                                           ║
║   🟠 High:     {metrics.high_count:>3}                                                           ║
║   🟡 Medium:   {metrics.medium_count:>3}                                                           ║
║   🟢 Low:      {metrics.low_count:>3}                                                           ║
║                                                                                  ║
║ Compliance Status:                                                               ║""")
        
        for standard, compliant in metrics.compliance_status.items():
            status = "✅ PASS" if compliant else "❌ FAIL"
            print(f"║   {standard.replace('_', ' ')}: {status:>15}                                     ║")
        
        print(f"""║                                                                                  ║
║ Risk Trending: {metrics.trending_analysis['risk_trend'].upper():>15}                                  ║
║ Most Common Vuln: {metrics.trending_analysis['most_common_type'][:20]:>20}                        ║
║ Average Risk Score: {metrics.trending_analysis['average_risk_score']:>13.1f}                                ║
╚══════════════════════════════════════════════════════════════════════════════════╝
""")
        
        # Show detailed analysis for highest risk vulnerability
        if all_vulns:
            print("\n🔍 Detailed Analysis of Highest Risk Vulnerability:")
            print("-" * 60)
            
            analyses = [self.ai_analyzer.analyze_vulnerability(v) for v in all_vulns]
            highest_risk = max(analyses, key=lambda a: a.risk_score)
            highest_vuln = all_vulns[analyses.index(highest_risk)]
            
            self.display_ai_analysis(highest_risk, highest_vuln)
        
        input("\nPress Enter to continue...")
    
    def demo_automated_scanning(self):
        """Demonstrate automated multi-target scanning"""
        print("\n🚀 Automated Multi-target Scanning Demo")
        print("=" * 60)
        
        targets = [
            "https://corp.example.com/api/v1/users",
            "https://admin.testsite.com/login",
            "https://secure.bank.com/transfer",
            "https://ecommerce.shop.com/checkout",
            "https://portal.company.com/dashboard"
        ]
        
        print(f"\n🎯 Launching automated scan against {len(targets)} targets...")
        
        # Start dashboard
        self.dashboard.start_monitoring()
        
        all_vulnerabilities = []
        
        for i, target in enumerate(targets, 1):
            print(f"\n📡 [{i}/{len(targets)}] Scanning: {target}")
            
            # Start scan
            scan_id = f"auto_scan_{i}"
            self.dashboard.start_scan(scan_id, target, "comprehensive")
            
            # Simulate scanning process
            print("   ⏳ Crawling target...")
            time.sleep(0.5)
            
            print("   🔍 Testing injection points...")
            time.sleep(1)
            
            print("   🧠 AI analysis in progress...")
            time.sleep(0.5)
            
            # Simulate finding vulnerabilities
            found_vulns = []
            vuln_count = random.randint(0, 3)
            
            if vuln_count > 0:
                for j in range(vuln_count):
                    vuln = random.choice(self.create_demo_vulnerabilities())
                    vuln.url = target
                    found_vulns.append(vuln)
                
                print(f"   🚨 Found {vuln_count} vulnerabilities!")
                
                # Show AI analysis for first vulnerability
                if found_vulns:
                    analysis = self.ai_analyzer.analyze_vulnerability(found_vulns[0])
                    risk_colors = {
                        VulnerabilityRisk.CRITICAL: "🔴",
                        VulnerabilityRisk.HIGH: "🟠", 
                        VulnerabilityRisk.MEDIUM: "🟡",
                        VulnerabilityRisk.LOW: "🟢"
                    }
                    risk_icon = risk_colors.get(analysis.risk_level, "⚪")
                    print(f"   {risk_icon} Highest Risk: {analysis.risk_level.value.upper()} (Score: {analysis.risk_score:.1f}/10)")
            else:
                print("   ✅ No vulnerabilities detected")
            
            # Complete scan
            self.dashboard.complete_scan(scan_id, found_vulns)
            all_vulnerabilities.extend(found_vulns)
            
            # Record some requests for dashboard
            for k in range(random.randint(3, 8)):
                self.dashboard.record_request(
                    f"{target}?param={k}",
                    random.uniform(0.2, 1.5),
                    random.choice([True, True, False])
                )
        
        # Show final results
        print(f"\n📊 Scan Complete! Summary:")
        print("=" * 40)
        print(f"🎯 Targets scanned: {len(targets)}")
        print(f"🚨 Total vulnerabilities: {len(all_vulnerabilities)}")
        
        if all_vulnerabilities:
            metrics = self.ai_analyzer.generate_security_metrics(all_vulnerabilities)
            print(f"🛡️  Security Score: {metrics.security_score:.1f}/100")
            print(f"🔴 Critical: {metrics.critical_count}")
            print(f"🟠 High: {metrics.high_count}")
            print(f"🟡 Medium: {metrics.medium_count}")
            print(f"🟢 Low: {metrics.low_count}")
        
        # Show dashboard
        print(f"\n📊 Final Dashboard View:")
        dashboard_text = self.dashboard.generate_text_dashboard()
        print(dashboard_text)
        
        self.dashboard.stop_monitoring()
        input("\nPress Enter to continue...")
    
    def show_system_status(self):
        """Show system status and configuration"""
        print("\n🛠️  System Status & Configuration")
        print("=" * 60)
        
        print(f"🚀 BoomSQL Version: 2.0.0")
        print(f"🐍 Python Version: {sys.version.split()[0]}")
        print(f"📁 Working Directory: {os.getcwd()}")
        
        print(f"\n📊 Component Status:")
        print(f"   ✅ SQL Injection Engine: {len(self.sql_engine.payloads)} payloads loaded")
        print(f"   ✅ Error Signatures: {len(self.sql_engine.error_signatures)} signatures loaded")
        print(f"   ✅ WAF Bypasses: {len(self.sql_engine.waf_bypasses)} bypasses loaded")
        print(f"   ✅ AI Analyzer: Ready")
        print(f"   ✅ Real-time Dashboard: Ready")
        
        print(f"\n⚙️  Configuration:")
        print(f"   • Request Timeout: {self.config.get('RequestTimeout', 30)}s")
        print(f"   • Max Threads: {self.config.get('MaxThreads', 3)}")
        print(f"   • Max Payloads per URL: {self.config.get('MaxPayloadsPerUrl', 100)}")
        
        print(f"\n📈 Session Statistics:")
        metrics = self.dashboard.get_current_metrics()
        if metrics:
            print(f"   • Total Requests: {metrics.total_requests}")
            print(f"   • Success Rate: {metrics.success_rate:.1f}%")
            print(f"   • Active Scans: {metrics.active_scans}")
            print(f"   • System Status: {metrics.system_status}")
        else:
            print(f"   • No metrics available")
        
        input("\nPress Enter to continue...")

def main():
    """Main function"""
    try:
        cli = BoomSQLCLI()
        cli.run()
    except KeyboardInterrupt:
        print("\n\n🛑 Interrupted by user. Goodbye!")
    except Exception as e:
        print(f"\n❌ Fatal error: {e}")
        import traceback
        traceback.print_exc()

if __name__ == "__main__":
    main()
