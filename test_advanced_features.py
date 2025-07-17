"""
Test file for advanced BoomSQL features
"""

import pytest
import asyncio
from unittest.mock import Mock, patch
from core.advanced_sql_engine import AdvancedSqlInjectionEngine, AdvancedTechnique
from core.advanced_enumeration import AdvancedEnumeration, EnumerationTarget
from core.os_command_executor import OSCommandExecutor, OSCommandTechnique
from core.sql_injection_engine import DatabaseType, VulnerabilityResult

class TestAdvancedFeatures:
    """Test advanced SQL injection features"""
    
    def test_advanced_sql_engine_init(self):
        """Test advanced SQL engine initialization"""
        config = {
            "RequestTimeout": 30,
            "MaxThreads": 5,
            "RequestDelay": 1000,
            "Retries": 3,
            "EnableWafBypass": True,
            "RiskLevel": 3,
            "PayloadFile": "payloads.xml",
            "ErrorSignatureFile": "error_signatures.xml",
            "WafBypassFile": "waf_bypasses.xml"
        }
        
        # This should not raise an exception
        try:
            engine = AdvancedSqlInjectionEngine(config)
            assert engine is not None
            assert engine.config == config
        except Exception as e:
            pytest.fail(f"Advanced SQL engine initialization failed: {e}")
    
    def test_enumeration_payloads(self):
        """Test enumeration payloads structure"""
        from core.enhanced_network import EnhancedNetworkManager
        
        # Mock network manager
        mock_network = Mock(spec=EnhancedNetworkManager)
        enumeration = AdvancedEnumeration(mock_network)
        
        # Test that payloads exist for all database types
        assert DatabaseType.MYSQL in enumeration.payloads
        assert DatabaseType.MSSQL in enumeration.payloads
        assert DatabaseType.POSTGRESQL in enumeration.payloads
        assert DatabaseType.ORACLE in enumeration.payloads
        
        # Test that all enumeration targets have payloads
        for db_type in [DatabaseType.MYSQL, DatabaseType.MSSQL, DatabaseType.POSTGRESQL]:
            db_payloads = enumeration.payloads[db_type]
            assert EnumerationTarget.DATABASES in db_payloads
            assert EnumerationTarget.TABLES in db_payloads
            assert EnumerationTarget.COLUMNS in db_payloads
    
    def test_os_command_payloads(self):
        """Test OS command execution payloads"""
        from core.enhanced_network import EnhancedNetworkManager
        
        # Mock network manager
        mock_network = Mock(spec=EnhancedNetworkManager)
        executor = OSCommandExecutor(mock_network)
        
        # Test that command payloads exist
        assert DatabaseType.MYSQL in executor.command_payloads
        assert DatabaseType.MSSQL in executor.command_payloads
        assert DatabaseType.POSTGRESQL in executor.command_payloads
        
        # Test MSSQL xp_cmdshell payloads
        mssql_payloads = executor.command_payloads[DatabaseType.MSSQL]
        assert OSCommandTechnique.XP_CMDSHELL in mssql_payloads
        assert len(mssql_payloads[OSCommandTechnique.XP_CMDSHELL]) > 0
    
    def test_technique_detection(self):
        """Test technique detection"""
        from core.enhanced_network import EnhancedNetworkManager
        
        mock_network = Mock(spec=EnhancedNetworkManager)
        executor = OSCommandExecutor(mock_network)
        
        # Test technique detection for different database types
        assert executor._detect_best_technique(DatabaseType.MSSQL) == OSCommandTechnique.XP_CMDSHELL
        assert executor._detect_best_technique(DatabaseType.MYSQL) == OSCommandTechnique.SHELL_EXEC
        assert executor._detect_best_technique(DatabaseType.POSTGRESQL) == OSCommandTechnique.SYSTEM_FUNC
    
    def test_vulnerability_result_creation(self):
        """Test vulnerability result creation"""
        from core.sql_injection_engine import InjectionPoint, SqlPayload, InjectionType, InjectionVector
        
        # Create required objects
        injection_point = InjectionPoint(
            vector=InjectionVector.GET_PARAMETER,
            name="id",
            value="1",
            original_value="1"
        )
        
        payload = SqlPayload(
            title="Test Payload",
            payload="1' OR '1'='1",
            risk=3,
            platform="MySQL",
            category="union",
            injection_type=InjectionType.UNION_BASED,
            description="Test union-based payload"
        )
        
        vuln = VulnerabilityResult(
            url="http://example.com/test.php",
            injection_point=injection_point,
            payload=payload,
            injection_type=InjectionType.UNION_BASED,
            database_type=DatabaseType.MYSQL,
            confidence=0.95,
            response_time=0.5,
            evidence="MySQL syntax error",
            response_code=200,
            response_headers={"Content-Type": "text/html"},
            response_body="<html>Error</html>"
        )
        
        assert vuln.url == "http://example.com/test.php"
        assert vuln.injection_point.name == "id"
        assert vuln.database_type == DatabaseType.MYSQL
        assert vuln.confidence == 0.95
    
    def test_advanced_techniques_enum(self):
        """Test advanced techniques enumeration"""
        # Test that all expected techniques are available
        techniques = [
            AdvancedTechnique.BLIND_BOOLEAN,
            AdvancedTechnique.BLIND_TIME,
            AdvancedTechnique.UNION_BASED,
            AdvancedTechnique.ERROR_BASED,
            AdvancedTechnique.STACKED_QUERIES,
            AdvancedTechnique.SECOND_ORDER,
            AdvancedTechnique.DNS_EXFILTRATION
        ]
        
        for technique in techniques:
            assert isinstance(technique, AdvancedTechnique)
    
    def test_system_commands_structure(self):
        """Test system commands structure"""
        from core.enhanced_network import EnhancedNetworkManager
        
        mock_network = Mock(spec=EnhancedNetworkManager)
        executor = OSCommandExecutor(mock_network)
        
        # Test that system commands exist for both platforms
        assert "windows" in executor.system_commands
        assert "linux" in executor.system_commands
        
        # Test command categories
        for os_type in ["windows", "linux"]:
            commands = executor.system_commands[os_type]
            assert "info" in commands
            assert "network" in commands
            assert "processes" in commands
            assert "users" in commands
            assert "files" in commands
    
    def test_file_payload_structure(self):
        """Test file operation payload structure"""
        from core.enhanced_network import EnhancedNetworkManager
        
        mock_network = Mock(spec=EnhancedNetworkManager)
        executor = OSCommandExecutor(mock_network)
        
        # Test file payloads exist
        for db_type in [DatabaseType.MYSQL, DatabaseType.MSSQL, DatabaseType.POSTGRESQL]:
            assert db_type in executor.file_payloads
            file_ops = executor.file_payloads[db_type]
            assert "read" in file_ops
            assert "write" in file_ops
            assert "list" in file_ops
    
    def test_blind_technique_structure(self):
        """Test blind technique structure"""
        from core.enhanced_network import EnhancedNetworkManager
        
        mock_network = Mock(spec=EnhancedNetworkManager)
        enumeration = AdvancedEnumeration(mock_network)
        
        # Test blind techniques structure
        assert "boolean" in enumeration.blind_techniques
        assert "time" in enumeration.blind_techniques
        
        boolean_tech = enumeration.blind_techniques["boolean"]
        assert "true_condition" in boolean_tech
        assert "false_condition" in boolean_tech
        assert "string_length" in boolean_tech
        
        time_tech = enumeration.blind_techniques["time"]
        assert "delay_function" in time_tech
        assert "conditional_delay" in time_tech

if __name__ == "__main__":
    pytest.main([__file__, "-v"])
