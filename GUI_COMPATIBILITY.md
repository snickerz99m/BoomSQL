# BoomSQL GUI Compatibility Guide

## Platform Support

BoomSQL includes a modern graphical user interface (GUI) that works across multiple platforms:

### ✅ Windows
- **Status**: Fully Supported
- **Requirements**: Python 3.7+ with tkinter (included by default)
- **Installation**: Download Python from [python.org](https://python.org) with "tcl/tk and IDLE" option checked

### ✅ macOS
- **Status**: Fully Supported  
- **Requirements**: Python 3.7+ with tkinter
- **Installation**: 
  - Standard Python: Included by default
  - Homebrew: `brew install python-tk`
  - pyenv: `pyenv install --enable-framework`

### ⚠️ Linux
- **Status**: Supported with additional setup
- **Requirements**: Python 3.7+ and python3-tk package
- **Installation**:
  - Ubuntu/Debian: `sudo apt-get install python3-tk`
  - CentOS/RHEL: `sudo yum install tkinter`
  - Fedora: `sudo dnf install python3-tkinter`
- **Remote Access**: Use X11 forwarding with `ssh -X username@hostname`

## Automatic Detection

BoomSQL automatically detects GUI availability:

```bash
# On Windows/macOS with GUI support:
python boomsql.py
# → Opens GUI interface

# On headless Linux servers:
python boomsql.py 
# → Automatically switches to CLI mode

# Force CLI mode on any platform:
python boomsql.py --skip-gui
```

## Testing GUI Compatibility

Use the included compatibility tester:

```bash
python test_gui_compatibility.py
```

This will:
- ✅ Check if tkinter is available
- 🔍 Test GUI window creation
- 📋 Show platform-specific recommendations
- ⚡ Display a test window (if GUI works)

## Troubleshooting

### Windows Issues
```bash
# If GUI doesn't work on Windows:
# 1. Reinstall Python from python.org
# 2. Ensure "tcl/tk and IDLE" is checked during installation
# 3. Restart command prompt/PowerShell
```

### macOS Issues
```bash
# If using Homebrew Python:
brew install python-tk

# If using system Python but GUI doesn't work:
# Install Python from python.org instead
```

### Linux Issues
```bash
# Install tkinter package:
sudo apt-get install python3-tk  # Ubuntu/Debian
sudo yum install tkinter          # CentOS/RHEL
sudo dnf install python3-tkinter  # Fedora

# For SSH/remote access:
ssh -X username@hostname
# or
ssh -Y username@hostname  # for trusted connections

# Test X11 forwarding:
xclock  # Should show a clock window
```

### Virtual Environments
```bash
# If using virtual environments, tkinter might need system packages
# On Linux, install python3-tk on the HOST system first:
sudo apt-get install python3-tk

# Then activate your virtual environment:
source venv/bin/activate
python boomsql.py
```

## Command Line Mode

If GUI is not available or desired, BoomSQL provides full CLI functionality:

```bash
# Test a URL for SQL injection
python boomsql.py --url "https://example.com/page?id=1" --skip-gui

# Crawl for parametrized URLs
python boomsql.py --crawl "https://example.com" --skip-gui

# Dump database from vulnerable URL
python boomsql.py --dump "https://vulnerable-site.com/page?id=1" --skip-gui
```

## GUI Features

When GUI is available, BoomSQL provides:

- 🎯 **SQL Injection Tester**: Interactive vulnerability testing
- 🕷️ **Web Crawler**: Visual progress and results
- 🗃️ **Database Dumper**: Real-time extraction progress  
- 🔍 **Dork Searcher**: Google dork automation
- 📊 **Results Dashboard**: Comprehensive reporting
- ⚙️ **Settings Manager**: Configuration interface

## FAQ

**Q: Why doesn't GUI work on my Linux server?**
A: Most Linux servers don't have a display. Use `--skip-gui` or set up X11 forwarding.

**Q: Can I run GUI over SSH?**
A: Yes, use `ssh -X` for X11 forwarding on Linux/macOS.

**Q: Does GUI work in Docker containers?**
A: Only with X11 forwarding setup. Usually better to use CLI mode.

**Q: What if I get "no display name" error?**
A: This means no GUI environment is available. The tool will automatically use CLI mode.
