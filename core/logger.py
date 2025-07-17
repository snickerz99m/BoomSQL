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
    
    # Configure logging format
    formatter = logging.Formatter(
        '%(asctime)s - %(name)s - %(levelname)s - %(message)s',
        datefmt='%Y-%m-%d %H:%M:%S'
    )
    
    # Setup root logger
    root_logger = logging.getLogger()
    root_logger.setLevel(getattr(logging, log_level.upper()))
    
    # Remove existing handlers
    for handler in root_logger.handlers[:]:
        root_logger.removeHandler(handler)
    
    # Console handler
    console_handler = logging.StreamHandler()
    console_handler.setLevel(getattr(logging, log_level.upper()))
    console_handler.setFormatter(formatter)
    root_logger.addHandler(console_handler)
    
    # File handler with rotation
    file_handler = logging.handlers.RotatingFileHandler(
        log_file_path, maxBytes=max_size, backupCount=max_files
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
        self.logger.info(message)
        
    def log_warning(self, message: str):
        """Log warning message"""
        self.logger.warning(message)
        
    def log_error(self, message: str):
        """Log error message"""
        self.logger.error(message)
        
    def log_debug(self, message: str):
        """Log debug message"""
        self.logger.debug(message)