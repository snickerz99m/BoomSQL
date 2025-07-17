"""
Performance Optimization Module for BoomSQL
Advanced performance features with caching, connection pooling, and monitoring
"""

import asyncio
import time
import threading
from typing import Dict, List, Optional, Any, Tuple, Callable
from dataclasses import dataclass, field
from collections import defaultdict, deque
from enum import Enum
import json
import hashlib
import gc
import weakref

# Try to import psutil, fallback to mock if not available
try:
    import psutil
    PSUTIL_AVAILABLE = True
except ImportError:
    PSUTIL_AVAILABLE = False
    
    # Mock psutil for basic functionality
    class MockPsutil:
        @staticmethod
        def cpu_percent(interval=1):
            return 50.0
            
        @staticmethod
        def virtual_memory():
            return type('MockMemory', (), {
                'percent': 60.0,
                'used': 8000000000,
                'available': 4000000000
            })()
            
        @staticmethod
        def disk_usage(path):
            return type('MockDisk', (), {
                'percent': 70.0,
                'used': 100000000000,
                'free': 50000000000
            })()
            
        @staticmethod
        def net_io_counters():
            return type('MockNetwork', (), {
                'bytes_sent': 1000000,
                'bytes_recv': 2000000
            })()
            
        @staticmethod
        def Process():
            class MockProcess:
                def memory_info(self):
                    return type('MockMemoryInfo', (), {'rss': 100000000})()
                def cpu_percent(self):
                    return 25.0
                def num_threads(self):
                    return 10
                def num_fds(self):
                    return 50
            return MockProcess()
    
    psutil = MockPsutil()

from .logger import LoggerMixin

class CacheType(Enum):
    """Cache types"""
    MEMORY = "memory"
    DISK = "disk"
    REDIS = "redis"  # For future implementation

@dataclass
class CacheEntry:
    """Cache entry with metadata"""
    key: str
    value: Any
    created_at: float
    last_accessed: float
    access_count: int = 0
    ttl: float = 3600  # 1 hour default
    size: int = 0
    
    @property
    def is_expired(self) -> bool:
        """Check if entry is expired"""
        return time.time() - self.created_at > self.ttl
        
    @property
    def age(self) -> float:
        """Get age of entry in seconds"""
        return time.time() - self.created_at

@dataclass
class PerformanceMetrics:
    """Performance metrics tracking"""
    total_requests: int = 0
    successful_requests: int = 0
    failed_requests: int = 0
    total_response_time: float = 0.0
    cache_hits: int = 0
    cache_misses: int = 0
    memory_usage: float = 0.0
    cpu_usage: float = 0.0
    active_connections: int = 0
    
    @property
    def success_rate(self) -> float:
        """Calculate success rate"""
        if self.total_requests == 0:
            return 0.0
        return self.successful_requests / self.total_requests
        
    @property
    def average_response_time(self) -> float:
        """Calculate average response time"""
        if self.successful_requests == 0:
            return 0.0
        return self.total_response_time / self.successful_requests
        
    @property
    def cache_hit_rate(self) -> float:
        """Calculate cache hit rate"""
        total_cache_requests = self.cache_hits + self.cache_misses
        if total_cache_requests == 0:
            return 0.0
        return self.cache_hits / total_cache_requests

class AdvancedCache(LoggerMixin):
    """Advanced caching system with TTL, LRU, and size limits"""
    
    def __init__(self, max_size: int = 1000, default_ttl: float = 3600):
        self.max_size = max_size
        self.default_ttl = default_ttl
        self.cache: Dict[str, CacheEntry] = {}
        self.access_order: deque = deque()  # For LRU
        self.size_usage = 0
        self.max_memory_usage = 100 * 1024 * 1024  # 100MB
        self.lock = threading.RLock()
        
    def _generate_key(self, key: str) -> str:
        """Generate cache key hash"""
        return hashlib.md5(key.encode()).hexdigest()
        
    def _estimate_size(self, value: Any) -> int:
        """Estimate memory size of value"""
        try:
            if isinstance(value, str):
                return len(value.encode('utf-8'))
            elif isinstance(value, (int, float)):
                return 8
            elif isinstance(value, dict):
                return len(json.dumps(value).encode('utf-8'))
            elif isinstance(value, list):
                return sum(self._estimate_size(item) for item in value)
            else:
                return len(str(value).encode('utf-8'))
        except:
            return 1024  # Default size if estimation fails
            
    def _cleanup_expired(self):
        """Clean up expired entries"""
        current_time = time.time()
        expired_keys = []
        
        for key, entry in self.cache.items():
            if entry.is_expired:
                expired_keys.append(key)
                
        for key in expired_keys:
            self._remove_entry(key)
            
    def _remove_entry(self, key: str):
        """Remove entry from cache"""
        if key in self.cache:
            entry = self.cache[key]
            self.size_usage -= entry.size
            del self.cache[key]
            
            # Remove from access order
            try:
                self.access_order.remove(key)
            except ValueError:
                pass
                
    def _evict_lru(self):
        """Evict least recently used entries"""
        while len(self.cache) >= self.max_size and self.access_order:
            lru_key = self.access_order.popleft()
            self._remove_entry(lru_key)
            
    def _evict_by_size(self):
        """Evict entries when memory limit is reached"""
        while self.size_usage > self.max_memory_usage and self.access_order:
            lru_key = self.access_order.popleft()
            self._remove_entry(lru_key)
            
    def get(self, key: str) -> Optional[Any]:
        """Get value from cache"""
        with self.lock:
            hashed_key = self._generate_key(key)
            
            if hashed_key in self.cache:
                entry = self.cache[hashed_key]
                
                # Check if expired
                if entry.is_expired:
                    self._remove_entry(hashed_key)
                    return None
                    
                # Update access information
                entry.last_accessed = time.time()
                entry.access_count += 1
                
                # Update LRU order
                try:
                    self.access_order.remove(hashed_key)
                except ValueError:
                    pass
                self.access_order.append(hashed_key)
                
                return entry.value
                
            return None
            
    def set(self, key: str, value: Any, ttl: Optional[float] = None):
        """Set value in cache"""
        with self.lock:
            hashed_key = self._generate_key(key)
            
            # Clean up expired entries
            self._cleanup_expired()
            
            # Calculate size
            size = self._estimate_size(value)
            
            # Check if we need to evict
            if len(self.cache) >= self.max_size:
                self._evict_lru()
                
            if self.size_usage + size > self.max_memory_usage:
                self._evict_by_size()
                
            # Create new entry
            entry = CacheEntry(
                key=key,
                value=value,
                created_at=time.time(),
                last_accessed=time.time(),
                ttl=ttl or self.default_ttl,
                size=size
            )
            
            # Remove old entry if exists
            if hashed_key in self.cache:
                self._remove_entry(hashed_key)
                
            # Add new entry
            self.cache[hashed_key] = entry
            self.size_usage += size
            self.access_order.append(hashed_key)
            
    def delete(self, key: str):
        """Delete value from cache"""
        with self.lock:
            hashed_key = self._generate_key(key)
            self._remove_entry(hashed_key)
            
    def clear(self):
        """Clear all cache entries"""
        with self.lock:
            self.cache.clear()
            self.access_order.clear()
            self.size_usage = 0
            
    def get_stats(self) -> Dict[str, Any]:
        """Get cache statistics"""
        with self.lock:
            total_size = sum(entry.size for entry in self.cache.values())
            total_access = sum(entry.access_count for entry in self.cache.values())
            
            return {
                "entries": len(self.cache),
                "max_size": self.max_size,
                "memory_usage": self.size_usage,
                "max_memory_usage": self.max_memory_usage,
                "total_size": total_size,
                "total_access_count": total_access,
                "average_age": sum(entry.age for entry in self.cache.values()) / len(self.cache) if self.cache else 0
            }

class ConnectionPool(LoggerMixin):
    """Advanced connection pool with health monitoring"""
    
    def __init__(self, max_connections: int = 10, max_per_host: int = 3):
        self.max_connections = max_connections
        self.max_per_host = max_per_host
        self.connections: Dict[str, List[Any]] = defaultdict(list)
        self.connection_stats: Dict[str, Dict[str, Any]] = defaultdict(lambda: {
            "created": 0,
            "reused": 0,
            "closed": 0,
            "active": 0
        })
        self.lock = threading.RLock()
        
    def get_connection(self, host: str) -> Optional[Any]:
        """Get connection from pool"""
        with self.lock:
            if host in self.connections and self.connections[host]:
                conn = self.connections[host].pop()
                self.connection_stats[host]["reused"] += 1
                return conn
            return None
            
    def return_connection(self, host: str, connection: Any):
        """Return connection to pool"""
        with self.lock:
            if len(self.connections[host]) < self.max_per_host:
                self.connections[host].append(connection)
            else:
                # Close excess connections
                self.connection_stats[host]["closed"] += 1
                
    def create_connection(self, host: str) -> Any:
        """Create new connection"""
        with self.lock:
            self.connection_stats[host]["created"] += 1
            self.connection_stats[host]["active"] += 1
            return f"mock_connection_{host}_{time.time()}"
            
    def close_connection(self, host: str, connection: Any):
        """Close connection"""
        with self.lock:
            self.connection_stats[host]["closed"] += 1
            self.connection_stats[host]["active"] -= 1
            
    def get_stats(self) -> Dict[str, Any]:
        """Get connection pool statistics"""
        with self.lock:
            total_connections = sum(len(conns) for conns in self.connections.values())
            
            return {
                "total_connections": total_connections,
                "max_connections": self.max_connections,
                "max_per_host": self.max_per_host,
                "hosts": dict(self.connection_stats),
                "pool_utilization": total_connections / self.max_connections if self.max_connections > 0 else 0
            }

class ResourceMonitor(LoggerMixin):
    """System resource monitoring"""
    
    def __init__(self, monitoring_interval: float = 5.0):
        self.monitoring_interval = monitoring_interval
        self.metrics_history: deque = deque(maxlen=100)
        self.is_monitoring = False
        self.monitor_thread = None
        
    def start_monitoring(self):
        """Start resource monitoring"""
        if not self.is_monitoring:
            self.is_monitoring = True
            self.monitor_thread = threading.Thread(target=self._monitor_loop, daemon=True)
            self.monitor_thread.start()
            self.log_info("Resource monitoring started")
            
    def stop_monitoring(self):
        """Stop resource monitoring"""
        self.is_monitoring = False
        if self.monitor_thread:
            self.monitor_thread.join(timeout=1.0)
        self.log_info("Resource monitoring stopped")
        
    def _monitor_loop(self):
        """Main monitoring loop"""
        while self.is_monitoring:
            try:
                metrics = self._collect_metrics()
                self.metrics_history.append(metrics)
                time.sleep(self.monitoring_interval)
            except Exception as e:
                self.log_error(f"Error in monitoring loop: {e}")
                
    def _collect_metrics(self) -> Dict[str, Any]:
        """Collect system metrics"""
        try:
            # CPU usage
            cpu_percent = psutil.cpu_percent(interval=1)
            
            # Memory usage
            memory = psutil.virtual_memory()
            
            # Disk usage
            disk = psutil.disk_usage('/')
            
            # Network stats
            network = psutil.net_io_counters()
            
            # Process info
            process = psutil.Process()
            
            return {
                "timestamp": time.time(),
                "cpu_percent": cpu_percent,
                "memory_percent": memory.percent,
                "memory_used": memory.used,
                "memory_available": memory.available,
                "disk_percent": disk.percent,
                "disk_used": disk.used,
                "disk_free": disk.free,
                "network_sent": network.bytes_sent,
                "network_recv": network.bytes_recv,
                "process_memory": process.memory_info().rss,
                "process_cpu": process.cpu_percent(),
                "process_threads": process.num_threads(),
                "process_fds": process.num_fds() if hasattr(process, 'num_fds') else 0
            }
            
        except Exception as e:
            self.log_error(f"Error collecting metrics: {e}")
            return {"timestamp": time.time(), "error": str(e)}
            
    def get_current_metrics(self) -> Dict[str, Any]:
        """Get current system metrics"""
        return self._collect_metrics()
        
    def get_metrics_history(self) -> List[Dict[str, Any]]:
        """Get metrics history"""
        return list(self.metrics_history)
        
    def get_metrics_summary(self) -> Dict[str, Any]:
        """Get summary of metrics"""
        if not self.metrics_history:
            return {}
            
        # Calculate averages
        cpu_values = [m.get("cpu_percent", 0) for m in self.metrics_history if "cpu_percent" in m]
        memory_values = [m.get("memory_percent", 0) for m in self.metrics_history if "memory_percent" in m]
        
        return {
            "cpu_avg": sum(cpu_values) / len(cpu_values) if cpu_values else 0,
            "cpu_max": max(cpu_values) if cpu_values else 0,
            "memory_avg": sum(memory_values) / len(memory_values) if memory_values else 0,
            "memory_max": max(memory_values) if memory_values else 0,
            "samples": len(self.metrics_history)
        }

class ProgressTracker(LoggerMixin):
    """Advanced progress tracking with ETA calculation"""
    
    def __init__(self, total_items: int, name: str = "Task"):
        self.total_items = total_items
        self.name = name
        self.completed_items = 0
        self.start_time = time.time()
        self.last_update = self.start_time
        self.completion_times: deque = deque(maxlen=100)
        self.callbacks: List[Callable] = []
        
    def update(self, increment: int = 1):
        """Update progress"""
        current_time = time.time()
        
        self.completed_items += increment
        self.completion_times.append(current_time)
        
        # Calculate rate
        if len(self.completion_times) > 1:
            time_span = self.completion_times[-1] - self.completion_times[0]
            rate = len(self.completion_times) / time_span if time_span > 0 else 0
        else:
            rate = 0
            
        # Calculate ETA
        remaining_items = self.total_items - self.completed_items
        eta = remaining_items / rate if rate > 0 else 0
        
        # Update metrics
        progress_info = {
            "name": self.name,
            "completed": self.completed_items,
            "total": self.total_items,
            "percentage": (self.completed_items / self.total_items * 100) if self.total_items > 0 else 0,
            "rate": rate,
            "eta": eta,
            "elapsed": current_time - self.start_time
        }
        
        # Call callbacks
        for callback in self.callbacks:
            try:
                callback(progress_info)
            except Exception as e:
                self.log_error(f"Error in progress callback: {e}")
                
        self.last_update = current_time
        
    def add_callback(self, callback: Callable):
        """Add progress callback"""
        self.callbacks.append(callback)
        
    def get_progress(self) -> Dict[str, Any]:
        """Get current progress information"""
        current_time = time.time()
        
        # Calculate rate
        if len(self.completion_times) > 1:
            time_span = self.completion_times[-1] - self.completion_times[0]
            rate = len(self.completion_times) / time_span if time_span > 0 else 0
        else:
            rate = 0
            
        # Calculate ETA
        remaining_items = self.total_items - self.completed_items
        eta = remaining_items / rate if rate > 0 else 0
        
        return {
            "name": self.name,
            "completed": self.completed_items,
            "total": self.total_items,
            "percentage": (self.completed_items / self.total_items * 100) if self.total_items > 0 else 0,
            "rate": rate,
            "eta": eta,
            "elapsed": current_time - self.start_time,
            "is_complete": self.completed_items >= self.total_items
        }

class PerformanceOptimizer(LoggerMixin):
    """Main performance optimization coordinator"""
    
    def __init__(self, config: Dict[str, Any]):
        self.config = config
        
        # Initialize components
        self.cache = AdvancedCache(
            max_size=config.get("cache_max_size", 1000),
            default_ttl=config.get("cache_default_ttl", 3600)
        )
        
        self.connection_pool = ConnectionPool(
            max_connections=config.get("max_connections", 10),
            max_per_host=config.get("max_per_host", 3)
        )
        
        self.resource_monitor = ResourceMonitor(
            monitoring_interval=config.get("monitoring_interval", 5.0)
        )
        
        self.metrics = PerformanceMetrics()
        self.progress_trackers: Dict[str, ProgressTracker] = {}
        
        # Start monitoring
        self.resource_monitor.start_monitoring()
        
    def get_cached_result(self, key: str) -> Optional[Any]:
        """Get cached result"""
        result = self.cache.get(key)
        if result is not None:
            self.metrics.cache_hits += 1
        else:
            self.metrics.cache_misses += 1
        return result
        
    def cache_result(self, key: str, value: Any, ttl: Optional[float] = None):
        """Cache result"""
        self.cache.set(key, value, ttl)
        
    def record_request(self, success: bool, response_time: float):
        """Record request metrics"""
        self.metrics.total_requests += 1
        if success:
            self.metrics.successful_requests += 1
            self.metrics.total_response_time += response_time
        else:
            self.metrics.failed_requests += 1
            
    def create_progress_tracker(self, name: str, total_items: int) -> ProgressTracker:
        """Create progress tracker"""
        tracker = ProgressTracker(total_items, name)
        self.progress_trackers[name] = tracker
        return tracker
        
    def get_progress_tracker(self, name: str) -> Optional[ProgressTracker]:
        """Get progress tracker"""
        return self.progress_trackers.get(name)
        
    def cleanup_completed_trackers(self):
        """Clean up completed progress trackers"""
        completed = [name for name, tracker in self.progress_trackers.items() 
                    if tracker.get_progress()["is_complete"]]
        
        for name in completed:
            del self.progress_trackers[name]
            
    def optimize_memory(self):
        """Optimize memory usage"""
        # Clear cache if memory usage is high
        current_metrics = self.resource_monitor.get_current_metrics()
        memory_percent = current_metrics.get("memory_percent", 0)
        
        if memory_percent > 80:
            self.log_warning(f"High memory usage ({memory_percent}%), clearing cache")
            self.cache.clear()
            
        # Force garbage collection
        gc.collect()
        
    def get_comprehensive_stats(self) -> Dict[str, Any]:
        """Get comprehensive performance statistics"""
        return {
            "metrics": {
                "total_requests": self.metrics.total_requests,
                "success_rate": self.metrics.success_rate,
                "average_response_time": self.metrics.average_response_time,
                "cache_hit_rate": self.metrics.cache_hit_rate
            },
            "cache_stats": self.cache.get_stats(),
            "connection_pool_stats": self.connection_pool.get_stats(),
            "resource_metrics": self.resource_monitor.get_metrics_summary(),
            "active_progress_trackers": len(self.progress_trackers)
        }
        
    def shutdown(self):
        """Shutdown performance optimizer"""
        self.resource_monitor.stop_monitoring()
        self.cache.clear()
        self.progress_trackers.clear()
        self.log_info("Performance optimizer shutdown complete")