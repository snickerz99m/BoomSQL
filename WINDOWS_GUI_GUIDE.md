# BoomSQL Windows GUI Setup Guide

## Quick Start for Windows Users

BoomSQL now includes enhanced Windows GUI support with automatic fixes for common display issues.

### Installation & Setup

1. **Download and Extract**
   - Extract BoomSQL to a folder like `D:\my-tools\BoomSQL\`
   - Open Command Prompt or PowerShell

2. **Install Dependencies**
   ```cmd
   pip install -r requirements.txt
   ```

3. **Run BoomSQL**
   ```cmd
   cd D:\my-tools\BoomSQL
   python boomsql.py
   ```

### GUI Troubleshooting

If the GUI doesn't appear, try these solutions:

#### Option 1: GUI Diagnostic Test
```cmd
python boomsql.py --gui-test
```
This will test if your GUI works and help identify issues.

#### Option 2: Force GUI Mode
```cmd
python boomsql.py --force-gui
```
Forces GUI mode even if auto-detection fails.

#### Option 3: Windows GUI Test Tool
```cmd
python windows_gui_test.py
```
Standalone GUI test that isolates display issues.

#### Option 4: Command Line Mode
```cmd
python boomsql.py --skip-gui
```
Use BoomSQL without GUI for guaranteed functionality.

### Common Issues & Solutions

#### "GUI not available" Error
- **Solution**: Run `python boomsql.py --force-gui`
- **Cause**: Auto-detection failed but GUI actually works

#### GUI Window Not Visible
- **Solution**: Check taskbar, try Alt+Tab, or minimize other windows
- **Cause**: Window might be behind other applications

#### "tkinter module not available"
- **Solution**: Install Python with tkinter support
- **Command**: `pip install tk` (if available) or reinstall Python

#### MainWindow Interface Failed
- **Solution**: BoomSQL will show a fallback interface automatically
- **Features**: Basic GUI with instructions for command-line usage

### Command Line Usage

Even with GUI issues, BoomSQL's core functionality works via command line:

```cmd
# Test a URL for SQL injection
python boomsql.py --url "http://example.com/page?id=1"

# Crawl a website for parametrized URLs
python boomsql.py --crawl "http://example.com"

# Dump database from vulnerable URL
python boomsql.py --dump "http://vulnerable-site.com/page?id=1"

# Skip GUI entirely
python boomsql.py --skip-gui
```

### GUI Features

When working properly, the BoomSQL GUI includes:

- **Dork Search**: Google dorking for SQL injection targets
- **Web Crawler**: Find parametrized URLs automatically
- **SQL Tester**: Test URLs for injection vulnerabilities
- **Database Dumper**: Extract data from vulnerable databases
- **Settings**: Configure payloads, delays, and preferences

### Windows-Specific Enhancements

BoomSQL includes several Windows-specific fixes:

- **Window Positioning**: Uses Windows API for proper display
- **Focus Management**: Ensures windows appear in foreground
- **Visibility Fixes**: Multiple strategies to guarantee window appears
- **Error Recovery**: Fallback interfaces when main GUI fails
- **Flash Window**: Attracts attention if window is hidden

### Getting Help

If you're still having issues:

1. **Check Logs**: Look in `logs/boomsql.log` for error details
2. **Run Diagnostic**: Use `python boomsql.py --gui-test`
3. **Use Command Line**: All features work via CLI with `--skip-gui`
4. **Report Issues**: Include log files and system information

### System Requirements

- **OS**: Windows 7/8/10/11
- **Python**: 3.7 or higher with tkinter
- **Memory**: 512MB RAM minimum
- **Display**: Any resolution (GUI scales automatically)

The enhanced BoomSQL should now work reliably on Windows systems with proper GUI display!
