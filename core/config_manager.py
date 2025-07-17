"""
Configuration manager for BoomSQL
Handles loading and saving application configuration
"""

import json
import os
import logging
from pathlib import Path
from typing import Dict, Any, List

class ConfigManager:
    """Manages application configuration"""
    
    def __init__(self, config_file: str = "config.json"):
        self.config_file = Path(config_file)
        self.logger = logging.getLogger(__name__)
        self._config = {}
        self.load_config()
        
    def load_config(self):
        """Load configuration from JSON file"""
        try:
            if self.config_file.exists():
                with open(self.config_file, 'r', encoding='utf-8') as f:
                    self._config = json.load(f)
                self.logger.info(f"Configuration loaded from {self.config_file}")
            else:
                self._config = self.get_default_config()
                self.save_config()
                self.logger.info("Default configuration created")
        except Exception as e:
            self.logger.error(f"Error loading configuration: {e}")
            self._config = self.get_default_config()
            
    def save_config(self):
        """Save configuration to JSON file"""
        try:
            with open(self.config_file, 'w', encoding='utf-8') as f:
                json.dump(self._config, f, indent=2, ensure_ascii=False)
            self.logger.info(f"Configuration saved to {self.config_file}")
        except Exception as e:
            self.logger.error(f"Error saving configuration: {e}")
            
    def get(self, key: str, default=None):
        """Get configuration value"""
        keys = key.split('.')
        value = self._config
        for k in keys:
            if isinstance(value, dict) and k in value:
                value = value[k]
            else:
                return default
        return value
        
    def set(self, key: str, value: Any):
        """Set configuration value"""
        keys = key.split('.')
        config = self._config
        for k in keys[:-1]:
            if k not in config:
                config[k] = {}
            config = config[k]
        config[keys[-1]] = value
        
    def get_default_config(self) -> Dict[str, Any]:
        """Get default configuration"""
        return {
            "Application": {
                "Name": "BoomSQL",
                "Version": "2.0.0",
                "Description": "Advanced SQL Injection Testing Tool",
                "Author": "Security Research Team",
                "License": "Educational Use Only"
            },
            "Database": {
                "SupportedDatabases": [
                    "mysql", "mssql", "oracle", "postgresql", "sqlite",
                    "mongodb", "db2", "firebird", "sybase", "informix", 
                    "mariadb", "access"
                ],
                "DefaultTimeout": 30,
                "MaxRetries": 3,
                "ConnectionPoolSize": 10
            },
            "Testing": {
                "MaxThreads": 5,
                "RequestTimeout": 30,
                "TimeBasedThreshold": 3.0,
                "MaxPayloadsPerUrl": 100,
                "RequestDelay": 1000,
                "MaxRedirects": 5,
                "EnableWafBypasses": True,
                "EnableTimeBasedDetection": True,
                "EnableErrorBasedDetection": True,
                "EnableBooleanBasedDetection": True,
                "EnableUnionBasedDetection": True,
                "EnableContentLengthDetection": True,
                "EnableHeaderInjection": True,
                "EnableCookieInjection": True,
                "EnableJsonInjection": True,
                "EnableXmlInjection": True,
                "EnableSecondOrderDetection": False,
                "EnableFileInclusionDetection": False,
                "EnableCommandInjectionDetection": False,
                "EnableLdapInjectionDetection": False,
                "EnableXpathInjectionDetection": False,
                "EnableNoSqlInjectionDetection": False
            },
            "Payloads": {
                "PayloadFile": "payloads.xml",
                "ErrorSignatureFile": "error_signatures.xml",
                "WafBypassFile": "waf_bypasses.xml",
                "MaxPayloadLength": 4096,
                "EnablePayloadEncoding": True,
                "EnablePayloadObfuscation": True,
                "Categories": [
                    "error", "boolean", "time", "union", "stacked",
                    "outofband", "secondorder", "nosql", "xml", "ldap",
                    "command", "file", "auth", "information", "advanced"
                ]
            },
            "WafBypasses": {
                "EnableUrlEncoding": True,
                "EnableHtmlEncoding": True,
                "EnableBase64Encoding": True,
                "EnableHexEncoding": True,
                "EnableCaseManipulation": True,
                "EnableCommentInjection": True,
                "EnableWhitespaceManipulation": True,
                "EnableOperatorAlternatives": True,
                "EnableStringConcatenation": True,
                "EnableFunctionAlternatives": True,
                "EnableNullByteInjection": True,
                "EnableHttpParameterPollution": True,
                "EnableHttpVerbTampering": True,
                "EnableCharsetConfusion": True,
                "EnableRateLimitingBypass": True,
                "EnableIpRotation": True,
                "EnableUserAgentRotation": True,
                "EnableHeaderManipulation": True,
                "Categories": [
                    "url_encoding", "html_encoding", "base64_encoding",
                    "hex_encoding", "case_manipulation", "comment_injection",
                    "whitespace_manipulation", "operator_alternatives",
                    "string_concatenation", "function_alternatives",
                    "null_byte_injection", "hpp", "http_verb_tampering",
                    "charset_confusion", "rate_limiting", "ip_rotation",
                    "user_agent_rotation", "header_manipulation"
                ]
            },
            "Crawler": {
                "MaxDepth": 5,
                "MaxUrls": 1000,
                "RequestDelay": 1000,
                "FollowRedirects": True,
                "MaxRedirects": 5,
                "UserAgent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36",
                "AcceptLanguage": "en-US,en;q=0.9",
                "AcceptEncoding": "gzip, deflate",
                "Connection": "keep-alive",
                "EnableJavaScriptParsing": False,
                "EnableFormDetection": True,
                "EnableParameterExtraction": True,
                "EnableCookieExtraction": True,
                "EnableHeaderExtraction": True,
                "FileExtensions": [
                    ".php", ".asp", ".aspx", ".jsp", ".cfm", ".py", ".rb", ".pl", ".cgi"
                ],
                "ExcludedExtensions": [
                    ".css", ".js", ".jpg", ".jpeg", ".png", ".gif", ".pdf",
                    ".doc", ".docx", ".xls", ".xlsx", ".zip", ".rar", ".tar", ".gz"
                ]
            },
            "DorkSearch": {
                "MaxResults": 1000,
                "SearchEngines": [
                    {"Name": "Google", "UrlFormat": "https://www.google.com/search?q={dork}", "Enabled": True, "Delay": 2000},
                    {"Name": "Bing", "UrlFormat": "https://www.bing.com/search?q={dork}", "Enabled": True, "Delay": 1500},
                    {"Name": "Yahoo", "UrlFormat": "https://search.yahoo.com/search?p={dork}", "Enabled": True, "Delay": 2000},
                    {"Name": "DuckDuckGo", "UrlFormat": "https://duckduckgo.com/?q={dork}", "Enabled": True, "Delay": 1000},
                    {"Name": "AOL", "UrlFormat": "https://search.aol.com/aol/search?q={dork}", "Enabled": False, "Delay": 2000},
                    {"Name": "Ask", "UrlFormat": "https://www.ask.com/web?q={dork}", "Enabled": False, "Delay": 2000},
                    {"Name": "Startpage", "UrlFormat": "https://www.startpage.com/sp/search?q={dork}", "Enabled": False, "Delay": 2000},
                    {"Name": "Dogpile", "UrlFormat": "https://www.dogpile.com/serp?q={dork}", "Enabled": False, "Delay": 2000},
                    {"Name": "Yandex", "UrlFormat": "https://yandex.com/search/?text={dork}", "Enabled": False, "Delay": 2000},
                    {"Name": "Baidu", "UrlFormat": "https://www.baidu.com/s?wd={dork}", "Enabled": False, "Delay": 2000}
                ],
                "DorkFile": "dorks.txt",
                "EnableResultFiltering": True,
                "EnableDuplicateRemoval": True,
                "MaxPagesPerEngine": 10,
                "RequestTimeout": 30
            },
            "Dumper": {
                "MaxThreads": 3,
                "PageSize": 100,
                "MaxPages": 1000,
                "RequestDelay": 1000,
                "EnableResume": True,
                "EnableCompression": False,
                "EnableEncryption": False,
                "ExportFormats": ["json", "csv", "xml", "sql", "html"],
                "MaxTableSize": 10000,
                "MaxColumnLength": 1000,
                "EnableBinaryHandling": True,
                "EnableProgressTracking": True,
                "EnableEtaCalculation": True
            },
            "Proxy": {
                "EnableProxyRotation": False,
                "ProxyFile": "proxies.txt",
                "ProxyTimeout": 10,
                "MaxProxyRetries": 3,
                "ProxyTestUrl": "http://httpbin.org/ip",
                "EnableProxyValidation": True,
                "SupportedTypes": ["HTTP", "HTTPS", "SOCKS4", "SOCKS5"]
            },
            "UserAgents": {
                "EnableRotation": False,
                "UserAgentFile": "useragents.txt",
                "Default": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36",
                "RotationInterval": 10
            },
            "Logging": {
                "EnableVerboseLogging": False,
                "LogLevel": "INFO",
                "LogFile": "boomsql.log",
                "MaxLogSize": 10485760,
                "MaxLogFiles": 5,
                "EnableConsoleLogging": True,
                "EnableFileLogging": True,
                "LogFormat": "[{timestamp}] [{level}] {message}",
                "DateFormat": "yyyy-MM-dd HH:mm:ss"
            },
            "Security": {
                "EnableSslCertificateValidation": False,
                "EnableRequestSigning": False,
                "EnableAuditLogging": True,
                "EnableRateLimiting": True,
                "EnableThrottling": True,
                "MaxRequestsPerSecond": 10,
                "MaxRequestsPerMinute": 100,
                "MaxRequestsPerHour": 1000,
                "EnableCredentialStorage": False,
                "CredentialEncryptionKey": "",
                "EnableSecureHeaders": True,
                "RequiredHeaders": [
                    "User-Agent", "Accept", "Accept-Language", 
                    "Accept-Encoding", "Connection"
                ]
            },
            "UI": {
                "Theme": "dark",
                "Language": "en",
                "EnableAnimations": True,
                "EnableSounds": False,
                "EnableNotifications": True,
                "EnableAutoSave": True,
                "AutoSaveInterval": 300,
                "EnableSessionRestore": True,
                "EnableMultiTabbing": False,
                "EnableDocking": False,
                "EnableToolTips": True,
                "EnableStatusBar": True,
                "EnableProgressBar": True,
                "EnableMenuBar": True,
                "EnableToolBar": True,
                "EnableContextMenu": True,
                "EnableKeyboardShortcuts": True,
                "EnableMouseGestures": False,
                "EnableTouchSupport": False,
                "EnableHighDpiSupport": True,
                "EnableAccessibility": True
            }
        }
        
    @property
    def config(self) -> Dict[str, Any]:
        """Get full configuration dictionary"""
        return self._config
        
    def get_supported_databases(self) -> List[str]:
        """Get list of supported databases"""
        return self.get("Database.SupportedDatabases", [])
        
    def get_search_engines(self) -> List[Dict[str, Any]]:
        """Get list of search engines"""
        return self.get("DorkSearch.SearchEngines", [])
        
    def get_testing_config(self) -> Dict[str, Any]:
        """Get testing configuration"""
        return self.get("Testing", {})
        
    def get_crawler_config(self) -> Dict[str, Any]:
        """Get crawler configuration"""
        return self.get("Crawler", {})
        
    def get_dumper_config(self) -> Dict[str, Any]:
        """Get dumper configuration"""
        return self.get("Dumper", {})
        
    def get_proxy_config(self) -> Dict[str, Any]:
        """Get proxy configuration"""
        return self.get("Proxy", {})
        
    def get_logging_config(self) -> Dict[str, Any]:
        """Get logging configuration"""
        return self.get("Logging", {})
        
    def get_ui_config(self) -> Dict[str, Any]:
        """Get UI configuration"""
        return self.get("UI", {})