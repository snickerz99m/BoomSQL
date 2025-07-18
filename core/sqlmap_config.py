"""
SQLMap Configuration for BoomSQL
Controls real SQLMap binary execution through GUI
"""

from dataclasses import dataclass
from typing import Dict, List, Optional, Any
from enum import Enum

class SQLMapTechnique(Enum):
    """SQLMap injection techniques"""
    BOOLEAN_BASED = "B"
    ERROR_BASED = "E"
    UNION_BASED = "U"
    STACKED_QUERIES = "S"
    TIME_BASED = "T"
    ALL = "BEUTS"

class SQLMapRisk(Enum):
    """SQLMap risk levels"""
    LOW = "1"
    MEDIUM = "2"
    HIGH = "3"

class SQLMapLevel(Enum):
    """SQLMap test levels"""
    LEVEL_1 = "1"
    LEVEL_2 = "2"
    LEVEL_3 = "3"
    LEVEL_4 = "4"
    LEVEL_5 = "5"

@dataclass
class SQLMapConfig:
    """SQLMap configuration for GUI control"""
    
    # Basic settings
    technique: SQLMapTechnique = SQLMapTechnique.ALL
    risk: SQLMapRisk = SQLMapRisk.LOW
    level: SQLMapLevel = SQLMapLevel.LEVEL_1
    
    # Database settings
    current_db: bool = True
    current_user: bool = True
    hostname: bool = True
    banner: bool = True
    
    # Enumeration settings
    enumerate_dbs: bool = False
    enumerate_tables: bool = True
    enumerate_columns: bool = True
    enumerate_data: bool = True
    
    # Performance settings
    threads: int = 1
    timeout: int = 30
    retries: int = 3
    
    # Output settings
    batch_mode: bool = True
    verbose: int = 1
    no_logging: bool = True
    flush_session: bool = True
    
    # Advanced settings
    tamper: Optional[str] = None
    user_agent: Optional[str] = None
    proxy: Optional[str] = None
    
    # Custom parameters
    custom_params: Dict[str, str] = None
    
    def __post_init__(self):
        if self.custom_params is None:
            self.custom_params = {}
    
    def to_cmdline_args(self, url: str, target_param: str = None) -> List[str]:
        """Convert config to SQLMap command line arguments"""
        import os
        
        # Use local SQLMap in core folder
        sqlmap_path = os.path.join(os.path.dirname(__file__), 'sqlmap', 'sqlmap.py')
        args = ['python', sqlmap_path, '-u', url]
        
        # Basic settings
        args.extend(['--technique', self.technique.value])
        args.extend(['--risk', self.risk.value])
        args.extend(['--level', self.level.value])
        
        # Target parameter
        if target_param:
            args.extend(['-p', target_param])
        
        # Database info
        if self.current_db:
            args.append('--current-db')
        if self.current_user:
            args.append('--current-user')
        if self.hostname:
            args.append('--hostname')
        if self.banner:
            args.append('--banner')
        
        # Enumeration
        if self.enumerate_dbs:
            args.append('--dbs')
        if self.enumerate_tables:
            args.append('--tables')
        if self.enumerate_columns:
            args.append('--columns')
        
        # Performance
        args.extend(['--threads', str(self.threads)])
        args.extend(['--timeout', str(self.timeout)])
        args.extend(['--retries', str(self.retries)])
        
        # Output
        if self.batch_mode:
            args.append('--batch')
        if self.no_logging:
            args.append('--no-logging')
        if self.flush_session:
            args.append('--flush-session')
        
        # Verbose
        if self.verbose > 1:
            args.extend(['-v', str(self.verbose)])
        
        # Advanced
        if self.tamper:
            args.extend(['--tamper', self.tamper])
        if self.user_agent:
            args.extend(['--user-agent', self.user_agent])
        if self.proxy:
            args.extend(['--proxy', self.proxy])
        
        # Custom parameters
        for key, value in self.custom_params.items():
            args.extend([f'--{key}', value])
        
        # Default answers
        args.extend(['--answers', 'quit=N,crack=N,dict=N,continue=Y'])
        
        return args
    
    def to_gui_dict(self) -> Dict[str, Any]:
        """Convert config to dictionary for GUI display"""
        return {
            'technique': self.technique.value,
            'risk': self.risk.value,
            'level': self.level.value,
            'current_db': self.current_db,
            'current_user': self.current_user,
            'hostname': self.hostname,
            'banner': self.banner,
            'enumerate_dbs': self.enumerate_dbs,
            'enumerate_tables': self.enumerate_tables,
            'enumerate_columns': self.enumerate_columns,
            'enumerate_data': self.enumerate_data,
            'threads': self.threads,
            'timeout': self.timeout,
            'retries': self.retries,
            'batch_mode': self.batch_mode,
            'verbose': self.verbose,
            'no_logging': self.no_logging,
            'flush_session': self.flush_session,
            'tamper': self.tamper,
            'user_agent': self.user_agent,
            'proxy': self.proxy,
            'custom_params': self.custom_params
        }
    
    @classmethod
    def from_gui_dict(cls, data: Dict[str, Any]) -> 'SQLMapConfig':
        """Create config from GUI dictionary"""
        config = cls()
        
        # Basic settings
        if 'technique' in data:
            config.technique = SQLMapTechnique(data['technique'])
        if 'risk' in data:
            config.risk = SQLMapRisk(data['risk'])
        if 'level' in data:
            config.level = SQLMapLevel(data['level'])
        
        # Database settings
        config.current_db = data.get('current_db', True)
        config.current_user = data.get('current_user', True)
        config.hostname = data.get('hostname', True)
        config.banner = data.get('banner', True)
        
        # Enumeration settings
        config.enumerate_dbs = data.get('enumerate_dbs', False)
        config.enumerate_tables = data.get('enumerate_tables', True)
        config.enumerate_columns = data.get('enumerate_columns', True)
        config.enumerate_data = data.get('enumerate_data', True)
        
        # Performance settings
        config.threads = data.get('threads', 1)
        config.timeout = data.get('timeout', 30)
        config.retries = data.get('retries', 3)
        
        # Output settings
        config.batch_mode = data.get('batch_mode', True)
        config.verbose = data.get('verbose', 1)
        config.no_logging = data.get('no_logging', True)
        config.flush_session = data.get('flush_session', True)
        
        # Advanced settings
        config.tamper = data.get('tamper')
        config.user_agent = data.get('user_agent')
        config.proxy = data.get('proxy')
        config.custom_params = data.get('custom_params', {})
        
        return config

# Default configurations for different use cases
DEFAULT_CONFIGS = {
    'fast': SQLMapConfig(
        technique=SQLMapTechnique.ERROR_BASED,
        risk=SQLMapRisk.LOW,
        level=SQLMapLevel.LEVEL_1,
        threads=1,
        timeout=15,
        retries=1
    ),
    'thorough': SQLMapConfig(
        technique=SQLMapTechnique.ALL,
        risk=SQLMapRisk.HIGH,
        level=SQLMapLevel.LEVEL_5,
        threads=3,
        timeout=60,
        retries=5,
        enumerate_dbs=True
    ),
    'stealth': SQLMapConfig(
        technique=SQLMapTechnique.TIME_BASED,
        risk=SQLMapRisk.LOW,
        level=SQLMapLevel.LEVEL_1,
        threads=1,
        timeout=45,
        retries=2
    )
}
