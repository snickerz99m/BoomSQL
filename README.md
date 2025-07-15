# BoomSQL - Advanced SQL Injection Testing Tool

BoomSQL (also known as SQLi Dumper) is a comprehensive SQL injection testing tool designed for security professionals and researchers. It provides automated SQL injection detection and exploitation capabilities across multiple database systems with advanced WAF bypass techniques.

## 🚀 Features

### Database Support
- **12 Database Systems**: MySQL, Microsoft SQL Server, Oracle, PostgreSQL, SQLite, MongoDB, DB2, Firebird, Sybase, Informix, MariaDB, and MS Access
- **Comprehensive Detection**: Automatic database type identification from error responses
- **Database-Specific Payloads**: Optimized injection techniques for each database system

### Detection Methods
- **13 Detection Techniques**: Error-based, Boolean-based, Time-based, Union-based, Stacked queries, Out-of-band, Content-length, Response-time, Header-based, Cookie-based, Second-order, and Blind injection variants
- **Advanced Testing**: Comprehensive vulnerability assessment with confidence scoring
- **Multi-Vector Testing**: Support for GET, POST, Cookie, and Header-based injection vectors

### Advanced Capabilities
- **WAF Bypass**: 16 bypass categories including encoding, case manipulation, comments, whitespace, operators, and more
- **Payload Library**: 500+ SQL injection payloads across 15 categories
- **Error Signatures**: 200+ error signatures for accurate database detection
- **Automated Exploitation**: Data extraction, privilege escalation, and command execution
- **Custom Themes**: Multiple UI themes for better user experience

## ⚠️ Important Disclaimer

**FOR EDUCATIONAL AND AUTHORIZED TESTING ONLY**

This tool is designed for:
- Educational purposes and learning about SQL injection vulnerabilities
- Authorized penetration testing and security assessments
- Bug bounty programs with proper authorization
- Security research in controlled environments

**UNAUTHORIZED USE IS STRICTLY PROHIBITED**

Using this tool against systems without explicit written permission is illegal and unethical. Users are solely responsible for complying with all applicable laws and regulations. The developers assume no liability for misuse of this software.

## 🛠️ Prerequisites

### System Requirements
- **Operating System**: Windows 7/8/10/11 (x64)
- **Framework**: .NET Framework 4.6 or higher
- **Architecture**: x64 (64-bit)

### Development Requirements
- **Visual Studio**: 2010 or higher (2019/2022 recommended)
- **Build Tools**: MSBuild (included with Visual Studio)
- **Alternative**: Visual Studio Build Tools (standalone)

### Dependencies
- **ChilkatDotNet46.dll**: HTTP/HTTPS communication library
- **SkinSoft.VisualStyler.dll**: UI theming library
- **Microsoft Visual C++ 2015 Redistributable**: Both x64 and x86 versions

## 📦 Installation and Setup

