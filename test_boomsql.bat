@echo off
REM BoomSQL Functionality Test for Windows
REM This script tests all BoomSQL components and functionality

echo.
echo 🧪 BoomSQL Functionality Test (Windows)
echo =============================
echo.

echo 📋 Test 1: CLI Mode Functionality
echo ----------------------------------
python boomsql.py --help 2>nul
if %errorlevel% equ 0 (
    echo ✅ CLI mode works
) else (
    echo ❌ CLI mode failed
)
echo.

echo 🖥️  Test 2: GUI Mode Test
echo -------------------------
python -c "import tkinter; root = tkinter.Tk(); root.withdraw(); print('✅ GUI available'); root.destroy()" 2>nul
if %errorlevel% equ 0 (
    echo ✅ GUI components available
) else (
    echo ❌ GUI not available
)
echo.

echo 📦 Test 3: Module Import Test
echo -----------------------------

REM Test core modules
python -c "import core.config_manager; print('✅ core.config_manager')" 2>nul || echo ❌ core.config_manager
python -c "import core.logger; print('✅ core.logger')" 2>nul || echo ❌ core.logger
python -c "import core.sql_injection_engine; print('✅ core.sql_injection_engine')" 2>nul || echo ❌ core.sql_injection_engine
python -c "import core.web_crawler; print('✅ core.web_crawler')" 2>nul || echo ❌ core.web_crawler
python -c "import core.dork_searcher; print('✅ core.dork_searcher')" 2>nul || echo ❌ core.dork_searcher
python -c "import core.report_generator; print('✅ core.report_generator')" 2>nul || echo ❌ core.report_generator
python -c "import core.database_dumper; print('✅ core.database_dumper')" 2>nul || echo ❌ core.database_dumper

REM Test GUI modules
python -c "import gui.main_window; print('✅ gui.main_window')" 2>nul || echo ❌ gui.main_window

echo.
echo ⚙️  Test 4: Configuration Test
echo ------------------------------
if exist config.json (
    echo ✅ Configuration file found
) else (
    echo ❌ Configuration file missing
)

if exist payloads.xml (
    echo ✅ Payloads file found
) else (
    echo ❌ Payloads file missing
)

if exist error_signatures.xml (
    echo ✅ Error signatures file found
) else (
    echo ❌ Error signatures file missing
)

echo.
echo 🎯 All tests completed!
echo =======================
echo.
echo 💡 To run BoomSQL on Windows:
echo    run_gui.bat
echo.
echo 💡 To run BoomSQL in CLI mode:
echo    python boomsql.py
echo.
pause
