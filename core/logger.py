"""
Logging configuration for BoomSQL
"""

import logging
import logging.handlers
import os
from datetime import datetime
from pathlib import Path

def setup_logging(log_level: str = "INFO", log_file: str = "boomsql.log", 
                 max_size: int = 10*1024*1024, max_files: int = 5):
    """Setup logging configuration"""
    
    # Create logs directory if it doesn't exist
    log_dir = Path("logs")
    log_dir.mkdir(exist_ok=True)
    
    # Full path to log file
    log_file_path = log_dir / log_file
    
    # Import Unicode handling
    from .fallbacks import safe_log_message
    
    # Custom formatter that handles Unicode safely
    class SafeFormatter(logging.Formatter):
        def format(self, record):
            result = super().format(record)
            return safe_log_message(result)
    
    # Configure logging format
    formatter = SafeFormatter(
        '%(asctime)s - %(name)s - %(levelname)s - %(message)s',
        datefmt='%Y-%m-%d %H:%M:%S'
    )
    
    # Setup root logger
    root_logger = logging.getLogger()
    root_logger.setLevel(getattr(logging, log_level.upper()))
    
    # Remove existing handlers
    for handler in root_logger.handlers[:]:
        root_logger.removeHandler(handler)
    
    # Console handler with UTF-8 encoding
    console_handler = logging.StreamHandler()
    console_handler.setLevel(getattr(logging, log_level.upper()))
    console_handler.setFormatter(formatter)
    # Ensure UTF-8 encoding for console output
    if hasattr(console_handler.stream, 'reconfigure'):
        try:
            console_handler.stream.reconfigure(encoding='utf-8')
        except Exception:
            pass  # Fallback for systems where reconfigure is not available
    root_logger.addHandler(console_handler)
    
    # File handler with rotation and UTF-8 encoding
    file_handler = logging.handlers.RotatingFileHandler(
        log_file_path, maxBytes=max_size, backupCount=max_files, encoding='utf-8'
    )
    file_handler.setLevel(getattr(logging, log_level.upper()))
    file_handler.setFormatter(formatter)
    root_logger.addHandler(file_handler)
    
    # Log startup message
    logger = logging.getLogger(__name__)
    logger.info("=" * 50)
    logger.info("BoomSQL Logging System Started")
    logger.info(f"Log Level: {log_level}")
    logger.info(f"Log File: {log_file_path}")
    logger.info("=" * 50)
    
    return logger

def get_logger(name: str) -> logging.Logger:
    """Get logger for a specific module"""
    return logging.getLogger(name)

class LoggerMixin:
    """Mixin class to add logging capabilities"""
    
    @property
    def logger(self) -> logging.Logger:
        """Get logger for this class"""
        return logging.getLogger(self.__class__.__name__)
        
    def log_info(self, message: str):
        """Log info message"""
        from .fallbacks import safe_log_message
        self.logger.info(safe_log_message(message))
        
    def log_warning(self, message: str):
        """Log warning message"""
        from .fallbacks import safe_log_message
        self.logger.warning(safe_log_message(message))
        
    def log_error(self, message: str):
        """Log error message"""
        from .fallbacks import safe_log_message
        self.logger.error(safe_log_message(message))
        
    def log_debug(self, message: str):
        """Log debug message"""
        from .fallbacks import safe_log_message
        self.logger.debug(safe_log_message(message))