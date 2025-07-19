# BoomSQL - Advanced SQL Injection Testing Tool

## 🎯 Overview

BoomSQL is a powerful SQL injection testing framework with an integrated GUI interface and real SQLMap binary support. This tool provides comprehensive SQL injection detection, database enumeration, and data extraction capabilities.

## ✨ Features

### 🔍 SQL Injection Detection
- **Automated vulnerability scanning** with multiple injection techniques
- **Real SQLMap integration** for advanced testing
- **Error-based, time-based, and union-based injection support**
- **WAF bypass techniques** and payload obfuscation

### 🖥️ Modern GUI Interface
- **Professional tkinter-based interface** with grid layout system
- **SQL Injection Tester** - Test URLs and parameters for vulnerabilities
- **Database Dumper** - Extract database structure and data
- **Web Crawler** - Discover injection points automatically
- **Dork Searcher** - Find vulnerable targets using Google dorks

### 🛠️ Core Components
- **Enhanced SQL Engine** - Advanced injection detection algorithms
- **Database Dumper** - Real SQLMap-powered data extraction
- **Network Layer** - Robust HTTP handling with proxy support
- **Report Generator** - Comprehensive vulnerability reports

## 🚀 Quick Start

### Installation
```bash
git clone https://github.com/snickerz99m/BoomSQL.git
cd BoomSQL
pip install -r requirements.txt
```

### Running the Application
```bash
# Launch GUI interface (auto-detects display availability)
python boomsql.py

# Force GUI mode (will use enhanced fallback if main GUI fails)
python boomsql.py --force-gui

# Skip GUI and run in command line mode
python boomsql.py --skip-gui

# Test GUI functionality
python boomsql.py --gui-test
```

## 🎯 GUI Usage

### SQL Injection Tester
1. **Enter target URL** with parameters
2. **Configure injection settings** (technique, risk level, timeout)
3. **Click "🚀 START TESTING"** to begin vulnerability scan
4. **View results** in the output area
5. **Send vulnerable targets to Database Dumper** for extraction

### Database Dumper
1. **Load vulnerable target** from SQL Tester or manual entry
2. **Click "🔍 ENUMERATE DATABASE"** to discover structure
3. **Review discovered tables and columns**
4. **Click "📦 DUMP DATA"** to extract database contents
5. **Export results** in multiple formats (JSON, CSV, XML, SQL)

## 🔧 Configuration

### SQLMap Integration
- **Local SQLMap binary** included in `core/sqlmap/`
- **Configurable techniques**: BEUTS (Boolean, Error, Union, Time, Stacked)
- **Adjustable risk and level settings**
- **Custom payload and tamper script support**

### Network Settings
- **Proxy support** for anonymity and traffic routing
- **Custom user agents** for evasion
- **Request timeout and retry configuration**
- **Thread control** for performance optimization

## 📁 Project Structure

```
BoomSQL/
├── boomsql_new.py          # Main GUI application (recommended)
├── boomsql.py             # Original GUI application
├── core/                  # Core functionality modules
│   ├── sqlmap/           # Local SQLMap installation
│   ├── database_dumper.py # Database extraction engine
│   ├── sql_injection_engine.py # Injection detection
│   ├── web_crawler.py    # Web crawling and discovery
│   └── ...               # Other core modules
├── gui/                   # GUI interface components
│   ├── tester_page_new.py # Modern SQL tester interface
│   ├── dumper_page_new.py # Modern database dumper interface
│   └── ...               # Other GUI components
├── config.json           # Application configuration
├── requirements.txt      # Python dependencies
└── README.md             # This file
```

## 🛡️ Features in Detail

### Advanced Injection Detection
- **Multiple injection vectors**: GET, POST, Headers, Cookies
- **Database fingerprinting**: MySQL, PostgreSQL, MSSQL, Oracle
- **WAF detection and bypass**: Automated evasion techniques
- **Payload optimization**: Context-aware injection payloads

### Real-World Data Extraction
- **SQLMap-powered enumeration**: Leverage battle-tested extraction
- **Database structure discovery**: Tables, columns, relationships
- **Data dumping**: Selective or complete database extraction
- **Progress tracking**: Real-time extraction status

### Professional Interface
- **Grid-based layout**: Guaranteed button visibility and responsiveness
- **Modern styling**: Professional appearance with ttk widgets
- **Workflow integration**: Seamless tester-to-dumper workflow
- **Export capabilities**: Multiple output formats for results

## 🔍 Troubleshooting

### GUI Issues
- **Main interface failed to load**: Application now automatically falls back to enhanced basic GUI
- **Buttons not visible**: All layout issues have been fixed with proper grid-based positioning
- **Import hanging**: GUI module imports now have proper error handling and timeout protection
- **Display scaling**: Interface adapts to different screen sizes and environments

### Current Status
- **✅ GUI imports fixed**: All GUI modules now import correctly without hanging
- **✅ Syntax errors resolved**: Fixed duplicate self.self.left_frame references
- **✅ Enhanced fallback**: Created comprehensive fallback GUI with SQL testing capabilities
- **✅ Command line working**: Full functionality available via command line interface
- **✅ Auto-detection**: Application automatically detects GUI availability and falls back gracefully

### SQLMap Issues
- **Permission errors**: Ensure SQLMap binary has execute permissions
- **Python path**: SQLMap requires Python 2.7+ or 3.x
- **Network timeouts**: Adjust timeout settings in configuration

## 📊 Technical Specifications

- **Python Version**: 3.8+
- **GUI Framework**: tkinter/ttk
- **SQL Engine**: SQLMap 1.9.7.7#dev
- **Supported Databases**: MySQL, PostgreSQL, MSSQL, Oracle, SQLite
- **Network**: aiohttp for async operations
- **Export Formats**: JSON, CSV, XML, SQL, HTML

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly
5. Submit a pull request

## 📄 License

This project is for educational and authorized testing purposes only. Users are responsible for compliance with applicable laws and regulations.

## ⚠️ Disclaimer

BoomSQL is designed for authorized penetration testing and security research. Only use this tool on systems you own or have explicit permission to test. Unauthorized access to computer systems is illegal.

---

**🎉 GUI Issues RESOLVED**: All import and initialization problems fixed!
**🚀 Enhanced Fallback**: Comprehensive fallback GUI ensures functionality in all environments!
**✅ Production Ready**: Complete SQLMap integration with robust error handling!
