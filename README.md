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

### 1. Clone the Repository
```bash
git clone https://github.com/snickerz99m/BoomSQL.git
cd BoomSQL
```

### 2. Install Prerequisites

#### Install .NET Framework 4.6+
Download and install from the [Microsoft .NET Framework page](https://dotnet.microsoft.com/download/dotnet-framework).

#### Install Visual Studio or Build Tools
- **Visual Studio Community** (free): https://visualstudio.microsoft.com/vs/community/
- **Build Tools for Visual Studio**: https://visualstudio.microsoft.com/downloads/#build-tools-for-visual-studio-2022

#### Install Visual C++ Redistributables
The application will prompt you to install these if missing:
- Download from: https://www.microsoft.com/en-us/download/details.aspx?id=48145
- Install both x64 and x86 versions

### 3. Obtain Required Dependencies

The project references external libraries that need to be obtained separately:

#### ChilkatDotNet46.dll
- **Purpose**: HTTP/HTTPS communication and networking
- **Source**: https://www.chilkatsoft.com/
- **Note**: This is a commercial library that requires a license for production use

#### SkinSoft.VisualStyler.dll
- **Purpose**: UI theming and visual styling
- **Source**: https://www.skinsoft.com/
- **Note**: This is a commercial library for enhanced UI appearance

**Important**: Place these DLL files in the appropriate directory structure referenced by the project file, or update the project references to point to your local copies.

## 🔨 Building the Project

### Using Visual Studio
1. Open `SQLi Dumper.sln` in Visual Studio
2. Select **x64** platform configuration
3. Choose **Release** or **Debug** configuration
4. Build → Build Solution (or press Ctrl+Shift+B)

### Using Command Line (MSBuild)
```batch
# Navigate to the project directory
cd "SQLi Dumper"

# Build using MSBuild
msbuild "SQLi Dumper.csproj" /p:Configuration=Release /p:Platform=x64

# Alternative: Build the entire solution
msbuild "SQLi Dumper.sln" /p:Configuration=Release /p:Platform=x64
```

### Using Developer Command Prompt
```batch
# Open Developer Command Prompt for VS
# Navigate to project directory
cd /d "C:\path\to\BoomSQL\SQLi Dumper"

# Build the project
msbuild "SQLi Dumper.csproj" /p:Configuration=Release /p:Platform=x64
```

## 🚨 Troubleshooting

### Common Build Issues

#### MSBuild Not Found
**Error**: `'msbuild' is not recognized as an internal or external command`

**Solutions**:
1. Use Developer Command Prompt for Visual Studio
2. Add MSBuild to PATH: `C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin`
3. Install Visual Studio Build Tools
4. Use full path: `"C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe"`

#### Missing Dependencies
**Error**: `Could not load file or assembly 'ChilkatDotNet46'` or similar

**Solutions**:
1. Obtain the required DLL files from their respective vendors
2. Update project references to point to correct paths
3. Consider using NuGet packages if available
4. Check if evaluation/trial versions are available

#### Missing Braces Error
**Error**: `Unexpected character '{'` or similar parsing errors

**Solutions**:
1. Ensure all code files have proper encoding (UTF-8 with BOM)
2. Check for corrupted files in the project
3. Verify all braces are properly matched in code files
4. Clean and rebuild the solution

#### x64 Platform Issues
**Error**: `Platform 'x64' is not supported`

**Solutions**:
1. Ensure x64 platform is selected in Configuration Manager
2. Check that .NET Framework 4.6 supports x64
3. Verify all references are compatible with x64 architecture

### Runtime Issues

#### Visual C++ Redistributable Missing
**Error**: Application fails to start with DLL errors

**Solution**: Install Microsoft Visual C++ 2015 Redistributable (both x64 and x86)

#### .NET Framework Version Issues
**Error**: Application requires newer .NET Framework

**Solution**: Install .NET Framework 4.6 or higher

#### Permission Issues
**Error**: Access denied or security warnings

**Solutions**:
1. Run as Administrator
2. Add application to antivirus exceptions
3. Check Windows UAC settings

## 💡 Usage

### Basic Usage
1. Launch the application from the built executable
2. Configure proxy settings if needed
3. Enter target URL for testing
4. Select database type or use automatic detection
5. Choose injection method(s)
6. Configure payload options
7. Start the testing process

### Advanced Features
- **WAF Bypass**: Enable advanced bypass techniques for protected targets
- **Custom Payloads**: Add custom injection payloads for specific scenarios
- **Export Results**: Save test results and extracted data
- **Proxy Support**: Route traffic through proxy servers
- **Multi-threading**: Concurrent testing for improved performance

### Best Practices
1. Always test on authorized targets only
2. Use rate limiting to avoid overwhelming target systems
3. Monitor network traffic and system resources
4. Keep detailed logs of testing activities
5. Follow responsible disclosure practices for found vulnerabilities

## 🔧 Configuration

### Application Settings
- **Timeout Settings**: Adjust request timeout values
- **Thread Pool**: Configure concurrent request limits
- **Proxy Configuration**: Set up proxy servers for testing
- **UI Themes**: Select from available visual themes

### Database Settings
- **Connection Strings**: Configure database connections for testing
- **Detection Methods**: Enable/disable specific detection techniques
- **Payload Categories**: Select relevant payload types

## 📚 Documentation

### Core Documentation
Detailed technical documentation is available in the `SQLi Dumper/Core/README.md` file, which covers:
- Core module architecture
- Database-specific implementations
- WAF bypass techniques
- Payload categories and examples
- Extension methods and integration

### Code Structure
```
SQLi Dumper/
├── Core/                 # Enhanced core functionality
├── DataBase/            # Database-specific implementations
├── Cryptor/             # Encryption and obfuscation
├── Taskbar/             # Windows taskbar integration
├── Properties/          # Assembly information
└── Resources/           # UI themes and resources
```

## 🤝 Contributing

While this appears to be a specialized security tool, contributions should focus on:
- Bug fixes and stability improvements
- Additional database support
- Enhanced detection methods
- Improved WAF bypass techniques
- Documentation improvements

Please ensure all contributions maintain the educational and authorized testing focus of the project.

## 📄 License

This project appears to be for educational and research purposes. Please respect all applicable laws and regulations regarding security testing tools.

## 🔗 Additional Resources

- [OWASP SQL Injection Guide](https://owasp.org/www-community/attacks/SQL_Injection)
- [SQL Injection Prevention Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/SQL_Injection_Prevention_Cheat_Sheet.html)
- [Microsoft SQL Server Security](https://docs.microsoft.com/en-us/sql/relational-databases/security/)
- [MySQL Security Guidelines](https://dev.mysql.com/doc/refman/8.0/en/security.html)

## 📞 Support

For technical issues:
1. Check the troubleshooting section above
2. Review the Core documentation
3. Verify all dependencies are properly installed
4. Ensure you have the required permissions and authorization

---

**Remember**: This tool is for educational and authorized testing purposes only. Always ensure you have explicit permission before testing any system. Unauthorized use is illegal and unethical.