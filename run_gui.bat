@echo off
REM BoomSQL GUI Launcher for Windows
REM Enhanced version with better error handling and GUI visibility

echo.
echo 🚀 Starting BoomSQL with Enhanced GUI support (Windows)...
echo ========================================

REM Check if Python is available
python --version >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ Python not found! Please install Python 3.8+ from https://python.org
    pause
    exit /b 1
)

REM Check if tkinter is available with better testing
python -c "import tkinter as tk; root = tk.Tk(); root.withdraw(); root.destroy(); print('✅ tkinter working')" 2>nul
if %errorlevel% neq 0 (
    echo ❌ tkinter not available! 
    echo    This usually means Python was installed without GUI support
    echo    💡 Solutions:
    echo       - Reinstall Python from python.org (full version)
    echo       - Make sure GUI components are included
    pause
    exit /b 1
)

echo ✅ Python and tkinter available
echo 🔍 Checking core dependencies...

REM Check if main dependencies are available
python -c "import aiohttp, requests, beautifulsoup4; print('✅ Core dependencies OK')" 2>nul
if %errorlevel% neq 0 (
    echo ⚠️  Installing missing dependencies...
    pip install -r requirements.txt
    if %errorlevel% neq 0 (
        echo ❌ Failed to install dependencies
        pause
        exit /b 1
    )
)

echo 🎯 Launching BoomSQL with enhanced GUI visibility...
echo.
echo 💡 If the GUI window doesn't appear:
echo    - Check your taskbar (it might be minimized)
echo    - Press Alt+Tab to cycle through windows
echo    - Try running as administrator
echo    - Check Windows display scaling settings
echo.

REM Set environment variables for better GUI behavior
set FORCE_GUI=1
set DISPLAY_MODE=enhanced

REM Launch BoomSQL with error handling
python boomsql.py
set EXIT_CODE=%errorlevel%

echo.
if %EXIT_CODE% equ 0 (
    echo 🏁 BoomSQL session ended successfully
) else (
    echo ❌ BoomSQL exited with error code: %EXIT_CODE%
    echo.
    echo 💡 Troubleshooting tips:
    echo    - Check the log file: logs\boomsql.log
    echo    - Verify all dependencies: pip install -r requirements.txt
    echo    - Test GUI manually: python -c "import tkinter; tkinter.Tk().mainloop()"
    echo    - Check if antivirus is blocking the application
    echo    - Try running in compatibility mode
)
echo.
pause
