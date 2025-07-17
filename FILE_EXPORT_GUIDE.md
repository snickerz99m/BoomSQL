# 📥 BoomSQL File Saving & Download Guide

## Overview
BoomSQL provides comprehensive file export and download capabilities for all scan results, reports, and data. Here's how to save and download files in different formats.

## 🎯 Quick Summary - Save Options

| Component | File Formats | Location in GUI |
|-----------|-------------|-----------------|
| **SQL Injection Results** | HTML, JSON, CSV, XML | Tester Page → Export Results |
| **Database Dumps** | JSON, CSV, XML, SQL, HTML | Dumper Page → Export Results |
| **Web Crawl Results** | JSON, CSV, HTML | Crawler Page → Export Results |
| **Dork Search Results** | JSON, CSV, HTML, TXT | Dork Page → Export Results |
| **Comprehensive Reports** | HTML, JSON, CSV, XML | Reports → Generate Report |

---

## 🔍 1. SQL Injection Test Results

### Export Locations
- **GUI**: Tester Page → "Export Results" button
- **Formats**: HTML, JSON, CSV, XML

### File Contents
- **HTML**: Professional report with vulnerability details, statistics, charts
- **JSON**: Structured data with complete vulnerability information
- **CSV**: Spreadsheet-friendly format for analysis
- **XML**: Structured format for integration with other tools

### Example File Structure
```
SQL_Injection_Report_2025-07-17_12-30-45.html
├── Executive Summary
├── Vulnerability Details (URL, Parameter, Injection Type, etc.)
├── Database Information
├── Statistics and Charts
└── Recommendations
```

---

## 🗄️ 2. Database Dump Results

### Export Locations
- **GUI**: Dumper Page → "Export Results" button
- **Formats**: JSON, CSV, XML, SQL, HTML

### File Contents
- **SQL**: Complete database recreation scripts
- **JSON**: Structured database schema and data
- **CSV**: Separate files for each table
- **HTML**: Formatted database documentation
- **XML**: Structured database information

### Example Export
```
Database_Dump_2025-07-17_12-30-45.sql
├── CREATE DATABASE statements
├── CREATE TABLE statements
├── INSERT statements with data
└── Indexes and constraints
```

---

## 🕷️ 3. Web Crawl Results

### Export Locations
- **GUI**: Crawler Page → "Export Results" button
- **Formats**: JSON, CSV, HTML

### File Contents
- **JSON**: Complete crawl data with URLs, parameters, forms
- **CSV**: Two files - URLs and Parameters separately
- **HTML**: Visual report with crawled pages and discovered parameters

### Example Files
```
Web_Crawl_Results_2025-07-17.json
Web_Crawl_URLs_2025-07-17.csv
Web_Crawl_Parameters_2025-07-17.csv
```

---

## 🔎 4. Dork Search Results

### Export Locations
- **GUI**: Dork Page → "Export Results" button
- **Formats**: JSON, CSV, HTML, TXT

### File Contents
- **JSON**: Structured search results with metadata
- **CSV**: Spreadsheet format with URLs, titles, descriptions
- **HTML**: Formatted search results page
- **TXT**: Plain text list of results

### Example Content
```
Google_Dork_Results_2025-07-17.html
├── Search Statistics
├── Found URLs with titles
├── Descriptions and snippets
└── Search metadata
```

---

## 📊 5. Comprehensive Reports

### Export Locations
- **GUI**: Main interface → Reports section
- **Report Types**:
  - **Executive**: High-level summary for management
  - **Technical**: Detailed technical findings
  - **Compliance**: Regulatory compliance assessment
  - **Detailed**: Complete comprehensive report

### File Formats
- **HTML**: Professional formatted reports
- **JSON**: Complete structured data
- **CSV**: Data tables for analysis
- **XML**: Structured report data

---

## 💾 How to Save Files (Step-by-Step)

### Method 1: Using GUI Export Buttons

1. **Complete your scan** (SQL injection, crawling, dorking, etc.)
2. **Navigate to the relevant page**:
   - Tester Page for SQL injection results
   - Dumper Page for database dumps
   - Crawler Page for web crawl results
   - Dork Page for search results
3. **Click "Export Results"** button
4. **Choose file format** from dropdown
5. **Select save location** in file dialog
6. **Click Save** - file will be downloaded to your chosen location

### Method 2: Using Report Generator

1. **Go to Reports section** in main interface
2. **Select report type**:
   - Executive (for management)
   - Technical (for security teams)
   - Compliance (for audits)
   - Detailed (comprehensive)
3. **Choose format**: HTML, JSON, CSV, or XML
4. **Click "Generate Report"**
5. **Save to desired location**

### Method 3: CLI Mode Export (Advanced)

```python
# Example: Export SQL injection results
sql_engine = SqlInjectionEngine(config)
results = sql_engine.test_url("http://example.com")

# Generate report
report_generator = ReportGenerator(config)
report_generator.add_vulnerability_results(results)
report_generator.generate_html_report(ReportType.TECHNICAL, "report.html")
```

---

## 📁 Default Save Locations

### Windows
```
%USERPROFILE%\Downloads\BoomSQL_Reports\
```

### Linux/Mac
```
~/Downloads/BoomSQL_Reports/
```

### Custom Locations
- Use file dialog to choose any location
- Network drives supported
- Relative paths supported

---

## 📋 File Naming Convention

```
[Component]_[Type]_[Date]_[Time].[extension]

Examples:
- SQL_Injection_Report_2025-07-17_12-30-45.html
- Database_Dump_MySQL_2025-07-17_12-30-45.sql
- Web_Crawl_Results_2025-07-17_12-30-45.json
- Dork_Search_Results_2025-07-17_12-30-45.csv
```

---

## 🔧 Programmatic Export (Advanced Users)

### SQL Injection Results
```python
from core.report_generator import ReportGenerator, ReportType, ReportFormat

# Create report generator
report_gen = ReportGenerator(config)
report_gen.add_vulnerability_results(vulnerability_results)

# Export HTML report
report_gen.generate_html_report(ReportType.TECHNICAL, "report.html")

# Export JSON data
report_gen.generate_json_report(ReportType.DETAILED, "data.json")

# Export CSV for analysis
report_gen.generate_csv_report(ReportType.TECHNICAL, "results.csv")
```

### Database Dumps
```python
from core.database_dumper import DatabaseDumper, ExportFormat

# Create dumper
dumper = DatabaseDumper(config)

# Export to different formats
dumper.export_data(database_info, ExportFormat.SQL, "database.sql")
dumper.export_data(database_info, ExportFormat.JSON, "database.json")
dumper.export_data(database_info, ExportFormat.HTML, "database.html")
```

### Web Crawl Results
```python
from core.web_crawler import WebCrawler

# Create crawler
crawler = WebCrawler(config)

# Export results
crawler.export_results('json', 'crawl_results.json')
crawler.export_results('csv', 'crawl_results.csv')
crawler.export_results('html', 'crawl_results.html')
```

---

## ⚡ Quick Export Tips

### 📌 **Best Practices**
1. **Always export immediately** after completing scans
2. **Use HTML format** for sharing with teams
3. **Use JSON format** for integration with other tools
4. **Use CSV format** for spreadsheet analysis
5. **Include timestamps** in filenames for tracking

### 🎯 **Recommended Workflow**
1. Complete your security assessment
2. Export technical report as HTML for immediate review
3. Export raw data as JSON for backup
4. Export CSV for statistical analysis
5. Generate executive summary for management reporting

### 💡 **Pro Tips**
- **Batch Export**: Export all results at once using comprehensive reports
- **Automation**: Use CLI mode for automated report generation
- **Integration**: JSON format works best with CI/CD pipelines
- **Archival**: Keep multiple format exports for different audiences

---

## 🚀 Current Status

✅ **All export functions are working and ready to use!**

You can start saving files immediately using any of the methods above. The GUI is currently running with virtual display support, so all export buttons should be functional.

Would you like me to demonstrate a specific export process or help you with any particular file format?
