# BoomSQL Python Edition - Installation & Usage Guide

## Overview

BoomSQL has been successfully converted from C# to Python with a modern tkinter GUI. This implementation provides all the features of the original C# version with additional enhancements and cross-platform compatibility.

## Features Implemented

### ✅ Complete Feature Set
- **12 Database Systems**: MySQL, Microsoft SQL Server, Oracle, PostgreSQL, SQLite, MongoDB, DB2, Firebird, Sybase, Informix, MariaDB, MS Access
- **13 Detection Methods**: Error-based, Boolean-based, Time-based, Union-based, Stacked queries, Out-of-band, Content-length, Response-time, Header-based, Cookie-based, Second-order, Multiple blind variants
- **16 WAF Bypass Categories**: URL encoding, HTML encoding, Base64 encoding, Hex encoding, Case manipulation, Comment injection, Whitespace manipulation, Operator alternatives, String concatenation, Function alternatives, Null byte injection, HTTP Parameter Pollution, HTTP verb tampering, Charset confusion, Rate limiting bypass, IP rotation, User agent rotation, Header manipulation
- **500+ SQL Injection Payloads**: Organized across 15 categories in payloads.xml
- **200+ Error Signatures**: Database-specific error patterns for accurate detection
- **4 Main Modules**: Dork Search, Web Crawler, SQL Injection Tester, Database Dumper

### ✅ Modern GUI Interface
- **Tabbed Interface**: Clean, organized layout with separate tabs for each module
- **Dark Theme**: Professional dark theme for better usability
- **Real-time Progress**: Progress bars and status updates for all operations
- **Comprehensive Settings**: Full configuration management with GUI controls
- **Legal Disclaimer**: Built-in legal disclaimer and usage agreement
- **Export Capabilities**: Multiple export formats (JSON, CSV, HTML, XML, SQL)

### ✅ Core Modules

#### 1. Dork Search Module
- **10 Search Engines**: Google, Bing, Yahoo, DuckDuckGo, AOL, Ask, Startpage, Dogpile, Yandex, Baidu
- **Multi-threaded Search**: Concurrent search across multiple engines
- **Proxy Support**: Proxy rotation and user agent rotation
- **Result Filtering**: Automatic filtering and duplicate removal
- **Export Options**: JSON, CSV, HTML, TXT formats

#### 2. Web Crawler Module
- **Recursive Crawling**: Depth-controlled website crawling
- **Parameter Extraction**: Automatic extraction of GET/POST parameters
- **Form Detection**: HTML form parsing and input extraction
- **Cookie Extraction**: Session cookie collection
- **Multi-threading**: Concurrent crawling with configurable limits
- **Smart Filtering**: Injection point identification

#### 3. SQL Injection Tester Module
- **13 Detection Methods**: Comprehensive vulnerability detection
- **Confidence Scoring**: Vulnerability confidence assessment
- **Real-time Testing**: Live progress updates during testing
- **Detailed Reporting**: Comprehensive vulnerability reports
- **WAF Bypass Integration**: Automatic WAF bypass attempts
- **Database Type Detection**: Automatic database identification

#### 4. Database Dumper Module
- **Structure Enumeration**: Complete database structure mapping
- **Data Extraction**: Table and column data dumping
- **Multiple Export Formats**: JSON, CSV, XML, SQL, HTML
- **Progress Tracking**: Real-time dump progress monitoring
- **Resume Support**: Ability to resume interrupted dumps
- **Tree View**: Hierarchical database structure display

### ✅ Technical Features
- **Async/Await Support**: Asynchronous HTTP requests with aiohttp
- **Configuration Management**: Comprehensive JSON-based configuration
- **Logging System**: File and console logging with rotation
- **Error Handling**: Robust error handling and recovery
- **Cross-platform**: Works on Windows, Linux, macOS
- **Professional Code**: Clean, documented, maintainable code

## Installation

### Prerequisites
- Python 3.8 or higher
- tkinter (usually included with Python)
- Required Python packages (see requirements.txt)

### Step 1: Clone Repository
```bash
git clone https://github.com/snickerz99m/BoomSQL.git
cd BoomSQL
```

### Step 2: Install Dependencies
```bash
# Install Python dependencies
pip install -r requirements.txt

# On Ubuntu/Debian, you may need:
sudo apt-get install python3-tk

# On CentOS/RHEL:
sudo yum install tkinter
```

### Step 3: Run Application
```bash
python3 boomsql.py
```

## Usage

### First Run
1. **Legal Disclaimer**: Read and accept the legal disclaimer
2. **Configuration**: Review settings in the Settings tab
3. **Data Files**: Ensure payloads.xml, error_signatures.xml, and config.json are present

### Dork Search
1. Navigate to the "🔍 Dork Search" tab
2. Load or add dorks to test
3. Select search engines to use
4. Configure options (max results, delays, etc.)
5. Click "Start Search"
6. Export results when complete

### Web Crawler
1. Navigate to the "🕷️ Web Crawler" tab
2. Enter target URL
3. Configure crawl options (depth, max URLs, etc.)
4. Click "Start Crawl"
5. Review discovered URLs, parameters, and forms
6. Send results to SQL Tester if needed

### SQL Injection Testing
1. Navigate to the "🎯 SQL Tester" tab
2. Add target URLs or import from crawler
3. Configure detection methods
4. Set testing options (threads, timeouts, etc.)
5. Click "Start Testing"
6. Review vulnerabilities found
7. Generate reports or send to dumper

### Database Dumping
1. Navigate to the "💾 Database Dumper" tab
2. Select vulnerability from tester results
3. Configure dump options
4. Click "Enumerate DB" to map structure
5. Click "Dump Data" to extract data
6. Export results in desired format

## Configuration

### Settings Tab
The Settings tab provides comprehensive configuration options:

- **General**: Theme, language, logging settings
- **Testing**: Detection methods, performance settings
- **Crawler**: Crawling limits, extraction options
- **Dumper**: Database dumping configuration
- **Proxy**: Proxy and user agent settings
- **Security**: SSL, rate limiting, audit options

### Configuration Files
- **config.json**: Main application configuration
- **payloads.xml**: SQL injection payloads
- **error_signatures.xml**: Database error signatures
- **waf_bypasses.xml**: WAF bypass techniques
- **dorks.txt**: Google dorks list
- **proxies.txt**: Proxy server list
- **useragents.txt**: User agent strings

## Testing

### Core Functionality Test
```bash
python3 test_simple.py
```

### Full Test Suite
```bash
python3 test_core.py
```

## Legal & Security

### ⚠️ IMPORTANT DISCLAIMER
This tool is for **EDUCATIONAL AND AUTHORIZED TESTING ONLY**. 

**Authorized Use:**
- Educational purposes and learning
- Authorized penetration testing with written permission
- Bug bounty programs with proper authorization
- Security research in controlled environments

**Prohibited Use:**
- Unauthorized testing of systems without permission
- Malicious purposes or causing harm
- Violating terms of service or applicable laws
- Accessing systems without explicit authorization

### Security Features
- **Legal Disclaimer**: Built-in usage agreement
- **Audit Logging**: Comprehensive activity logging
- **Rate Limiting**: Built-in request throttling
- **SSL Support**: Secure communications
- **Responsible Disclosure**: Encourages ethical reporting

## Troubleshooting

### Common Issues

1. **tkinter not found**: Install python3-tk package
2. **aiohttp missing**: Install with `pip install aiohttp`
3. **XML parsing errors**: Check XML file formatting
4. **Permission denied**: Ensure proper file permissions

### Performance Tips
- Reduce max threads for slower systems
- Increase request delays for rate limiting
- Use proxy rotation for large-scale testing
- Monitor system resources during operation

## Support

For issues and questions:
- Check the troubleshooting section
- Review log files in the logs/ directory
- Test with simplified configurations first
- Report bugs through appropriate channels

## License

Educational Use Only - See disclaimer for full terms.

---

**BoomSQL Python Edition v2.0.0**  
*Advanced SQL Injection Testing Tool*  
*Converted from C# to Python with modern GUI*