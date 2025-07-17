"""
Event Loop Manager for BoomSQL
Handles async operations in GUI context and provides proper event loop management
"""

import asyncio
import threading
import queue
import logging
from typing import Any, Callable, Optional, Coroutine
from concurrent.futures import ThreadPoolExecutor
import functools
import weakref
from datetime import datetime, timedelta


class EventLoopManager:
    """
    Manages async operations for GUI applications.
    Provides a bridge between sync GUI code and async operations.
    """
    
    def __init__(self):
        self.logger = logging.getLogger(__name__)
        self.loop = None
        self.thread = None
        self.executor = ThreadPoolExecutor(max_workers=4, thread_name_prefix="BoomSQL-Async")
        self.result_queue = queue.Queue()
        self.running = False
        self.tasks = weakref.WeakSet()
        
    def start(self):
        """Start the event loop in a separate thread"""
        if self.running:
            return
            
        self.running = True
        self.thread = threading.Thread(target=self._run_event_loop, daemon=True)
        self.thread.start()
        
        # Wait for the loop to start
        for _ in range(50):  # Wait up to 5 seconds
            if self.loop and self.loop.is_running():
                break
            threading.Event().wait(0.1)
        
        if not self.loop or not self.loop.is_running():
            raise RuntimeError("Failed to start event loop")
            
        self.logger.info("Event loop started successfully")
    
    def _run_event_loop(self):
        """Run the event loop in the background thread"""
        try:
            self.loop = asyncio.new_event_loop()
            asyncio.set_event_loop(self.loop)
            
            # Run until stopped
            self.loop.run_forever()
            
        except Exception as e:
            self.logger.error(f"Event loop error: {e}")
        finally:
            if self.loop:
                self.loop.close()
            self.logger.info("Event loop stopped")
    
    def stop(self):
        """Stop the event loop and cleanup"""
        if not self.running:
            return
            
        self.running = False
        
        # Cancel all running tasks
        self.cancel_all_tasks()
        
        # Stop the event loop
        if self.loop and self.loop.is_running():
            self.loop.call_soon_threadsafe(self.loop.stop)
        
        # Wait for thread to finish
        if self.thread and self.thread.is_alive():
            self.thread.join(timeout=5.0)
        
        # Shutdown executor
        self.executor.shutdown(wait=True)
        
        self.logger.info("Event loop manager stopped")
    
    def run_async(self, coro: Coroutine, callback: Optional[Callable] = None, 
                  error_callback: Optional[Callable] = None) -> Any:
        """
        Run an async coroutine from sync context.
        
        Args:
            coro: The coroutine to run
            callback: Optional callback for successful completion
            error_callback: Optional callback for errors
            
        Returns:
            Future object that can be used to get the result
        """
        if not self.running:
            self.start()
        
        if not self.loop or not self.loop.is_running():
            raise RuntimeError("Event loop not running")
        
        # Create a future to track the task
        future = asyncio.run_coroutine_threadsafe(coro, self.loop)
        
        # Add completion handling
        def handle_completion(fut):
            try:
                result = fut.result()
                if callback:
                    callback(result)
                self.result_queue.put(('success', result))
            except Exception as e:
                if error_callback:
                    error_callback(e)
                self.result_queue.put(('error', e))
                self.logger.error(f"Async operation failed: {e}")
        
        future.add_done_callback(handle_completion)
        
        # Keep weak reference to task
        self.tasks.add(future)
        
        return future
    
    def run_async_blocking(self, coro: Coroutine, timeout: Optional[float] = None) -> Any:
        """
        Run an async coroutine and block until completion.
        
        Args:
            coro: The coroutine to run
            timeout: Optional timeout in seconds
            
        Returns:
            The result of the coroutine
            
        Raises:
            asyncio.TimeoutError: If timeout is exceeded
            Any exception raised by the coroutine
        """
        if not self.running:
            self.start()
        
        if not self.loop or not self.loop.is_running():
            raise RuntimeError("Event loop not running")
        
        future = asyncio.run_coroutine_threadsafe(coro, self.loop)
        self.tasks.add(future)
        
        try:
            return future.result(timeout=timeout)
        except Exception as e:
            self.logger.error(f"Blocking async operation failed: {e}")
            raise
    
    def cancel_all_tasks(self):
        """Cancel all running tasks"""
        cancelled_count = 0
        
        # Cancel futures
        for task in list(self.tasks):
            if not task.done():
                task.cancel()
                cancelled_count += 1
        
        # Cancel tasks in the event loop
        if self.loop and self.loop.is_running():
            def cancel_loop_tasks():
                tasks = [task for task in asyncio.all_tasks(self.loop) if not task.done()]
                for task in tasks:
                    task.cancel()
                return len(tasks)
            
            try:
                future = asyncio.run_coroutine_threadsafe(
                    asyncio.coroutine(cancel_loop_tasks)(), 
                    self.loop
                )
                cancelled_count += future.result(timeout=2.0)
            except Exception as e:
                self.logger.error(f"Error cancelling loop tasks: {e}")
        
        if cancelled_count > 0:
            self.logger.info(f"Cancelled {cancelled_count} tasks")
    
    def get_result(self, timeout: Optional[float] = None) -> tuple:
        """
        Get a result from the result queue.
        
        Args:
            timeout: Optional timeout in seconds
            
        Returns:
            Tuple of (status, result) where status is 'success' or 'error'
        """
        try:
            return self.result_queue.get(timeout=timeout)
        except queue.Empty:
            return ('timeout', None)
    
    def has_results(self) -> bool:
        """Check if there are results available"""
        return not self.result_queue.empty()
    
    def clear_results(self):
        """Clear all results from the queue"""
        while not self.result_queue.empty():
            try:
                self.result_queue.get_nowait()
            except queue.Empty:
                break
    
    def create_task_with_callback(self, coro: Coroutine, 
                                 success_callback: Optional[Callable] = None,
                                 error_callback: Optional[Callable] = None,
                                 progress_callback: Optional[Callable] = None) -> Any:
        """
        Create a task with callbacks for different events.
        
        Args:
            coro: The coroutine to run
            success_callback: Called on successful completion
            error_callback: Called on error
            progress_callback: Called for progress updates (if supported)
            
        Returns:
            Future object
        """
        return self.run_async(coro, success_callback, error_callback)
    
    def is_running(self) -> bool:
        """Check if the event loop is running"""
        return (self.running and 
                self.loop is not None and 
                self.loop.is_running())
    
    def __enter__(self):
        """Context manager entry"""
        self.start()
        return self
    
    def __exit__(self, exc_type, exc_val, exc_tb):
        """Context manager exit"""
        self.stop()


# Global event loop manager instance
_event_loop_manager = None


def get_event_loop_manager() -> EventLoopManager:
    """Get the global event loop manager instance"""
    global _event_loop_manager
    if _event_loop_manager is None:
        _event_loop_manager = EventLoopManager()
    return _event_loop_manager


def run_async_in_gui(coro: Coroutine, callback: Optional[Callable] = None, 
                    error_callback: Optional[Callable] = None) -> Any:
    """
    Convenience function to run async code from GUI context.
    
    Args:
        coro: The coroutine to run
        callback: Optional success callback
        error_callback: Optional error callback
        
    Returns:
        Future object
    """
    manager = get_event_loop_manager()
    return manager.run_async(coro, callback, error_callback)


def run_async_blocking_in_gui(coro: Coroutine, timeout: Optional[float] = None) -> Any:
    """
    Convenience function to run async code and block until completion.
    
    Args:
        coro: The coroutine to run
        timeout: Optional timeout in seconds
        
    Returns:
        The result of the coroutine
    """
    manager = get_event_loop_manager()
    return manager.run_async_blocking(coro, timeout)


def shutdown_event_loop():
    """Shutdown the global event loop manager"""
    global _event_loop_manager
    if _event_loop_manager:
        _event_loop_manager.stop()
        _event_loop_manager = None


# Helper decorator for async methods that need to work in GUI context
def gui_async(timeout: Optional[float] = None):
    """
    Decorator to make async methods work in GUI context.
    
    Args:
        timeout: Optional timeout in seconds
        
    Usage:
        @gui_async(timeout=30)
        async def my_async_method(self, param):
            # async code here
            return result
    """
    def decorator(func):
        @functools.wraps(func)
        def wrapper(*args, **kwargs):
            coro = func(*args, **kwargs)
            if asyncio.iscoroutine(coro):
                return run_async_blocking_in_gui(coro, timeout)
            else:
                return coro
        return wrapper
    return decorator