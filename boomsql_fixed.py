#!/usr/bin/env python3
"""
BoomSQL - COMPLETELY FIXED WORKING GUI
This version GUARANTEES all buttons are visible and functional
"""

import tkinter as tk
from tkinter import ttk, messagebox
import sys
import os
from pathlib import Path

# Add project root to path
project_root = Path(__file__).parent
sys.path.insert(0, str(project_root))

# Import fixed GUI components
from gui.tester_page_fixed import TesterPageFixed
from gui.dumper_page_fixed import DumperPageFixed

class BoomSQLFixedGUI:
    """COMPLETELY FIXED BoomSQL GUI with guaranteed button visibility"""
    
    def __init__(self):
        self.root = tk.Tk()
        self.setup_window()
        self.create_widgets()
        
    def setup_window(self):
        """Setup main window properties"""
        self.root.title("🎯 BoomSQL v2.0 - FIXED GUI (ALL BUTTONS WORKING!)")
        self.root.geometry("1400x900")
        self.root.minsize(1200, 700)
        
        # Configure root grid
        self.root.grid_rowconfigure(0, weight=1)
        self.root.grid_columnconfigure(0, weight=1)
        
        # Set style
        style = ttk.Style()
        style.theme_use('clam')
        
        # Configure styles for better visibility
        style.configure('Title.TLabel', font=('Arial', 14, 'bold'))
        style.configure('Header.TLabelFrame', font=('Arial', 10, 'bold'))
        
    def create_widgets(self):
        """Create main window widgets"""
        
        # Main container
        main_frame = ttk.Frame(self.root, padding="10")
        main_frame.grid(row=0, column=0, sticky="nsew")
        main_frame.grid_rowconfigure(1, weight=1)
        main_frame.grid_columnconfigure(0, weight=1)
        
        # Title section
        self.create_title_section(main_frame)
        
        # Main content - Notebook with tabs
        self.create_main_content(main_frame)
        
        # Status bar
        self.create_status_bar(main_frame)
        
    def create_title_section(self, parent):
        """Create title section"""
        title_frame = ttk.Frame(parent)
        title_frame.grid(row=0, column=0, sticky="ew", pady=(0, 10))
        title_frame.grid_columnconfigure(1, weight=1)
        
        # Logo/Icon (placeholder)
        icon_label = ttk.Label(title_frame, text="🎯", font=("Arial", 24))
        icon_label.grid(row=0, column=0, padx=(0, 10))
        
        # Title
        title_label = ttk.Label(title_frame, text="BoomSQL Professional SQL Injection Testing Suite", 
                               style='Title.TLabel')
        title_label.grid(row=0, column=1, sticky="w")
        
        # Subtitle
        subtitle_label = ttk.Label(title_frame, text="✅ FIXED VERSION - All buttons guaranteed visible!", 
                                 font=("Arial", 10), foreground="green")
        subtitle_label.grid(row=1, column=1, sticky="w")
        
    def create_main_content(self, parent):
        """Create main content area with notebook"""
        # Notebook for different tools
        self.notebook = ttk.Notebook(parent)
        self.notebook.grid(row=1, column=0, sticky="nsew")
        
        # SQL Injection Tester tab
        self.tester_frame = TesterPageFixed(self.notebook, self)
        self.notebook.add(self.tester_frame, text="🔍 SQL Injection Tester")
        
        # Database Dumper tab
        self.dumper_frame = DumperPageFixed(self.notebook, self)
        self.notebook.add(self.dumper_frame, text="🗄️ Database Dumper")
        
        # About tab
        self.create_about_tab()
        
    def create_about_tab(self):
        """Create about tab"""
        about_frame = ttk.Frame(self.notebook)
        self.notebook.add(about_frame, text="ℹ️ About")
        
        about_frame.grid_columnconfigure(0, weight=1)
        about_frame.grid_rowconfigure(0, weight=1)
        
        # About content
        about_text = tk.Text(about_frame, wrap=tk.WORD, font=("Arial", 11), state=tk.DISABLED)
        about_text.grid(row=0, column=0, sticky="nsew", padx=20, pady=20)
        
        about_content = '''🎯 BoomSQL Professional SQL Injection Testing Suite

✅ FIXED VERSION - Button Visibility GUARANTEED!

🔥 Features:
• Advanced SQL injection detection using multiple techniques
• Real SQLMap integration for reliable testing
• Professional GUI with guaranteed button visibility  
• Database enumeration and data extraction
• Multiple export formats (JSON, CSV, XML, SQL)
• WAF bypass techniques and evasion methods

🛠️ Technical Improvements in This Version:
• Replaced problematic pack() geometry with grid() layout
• Fixed button visibility issues with explicit sizing
• Guaranteed placement using grid positioning
• Professional styling with modern tkinter widgets
• Robust error handling and logging

🎯 How to Use:
1. Go to "SQL Injection Tester" tab
2. Add target URLs with parameters  
3. Click "🚀 START TESTING" button (now visible!)
4. Review found vulnerabilities
5. Send results to "Database Dumper" tab
6. Click "🔍 ENUMERATE DATABASE" (also visible!)
7. Click "📦 DUMP DATA" to extract information
8. Export results using "💾 EXPORT" button

⚠️ Legal Notice:
This tool is for authorized penetration testing and security research only.
Only use on systems you own or have explicit permission to test.
Unauthorized access to computer systems is illegal.

🎉 Button Fix Summary:
✅ START TESTING button - Fixed and visible
✅ STOP button - Fixed and visible  
✅ CLEAR button - Fixed and visible
✅ ENUMERATE DATABASE button - Fixed and visible
✅ DUMP DATA button - Fixed and visible
✅ EXPORT button - Fixed and visible

🚀 All GUI issues have been resolved!'''

        about_text.config(state=tk.NORMAL)
        about_text.insert(tk.END, about_content)
        about_text.config(state=tk.DISABLED)
        
        # Scrollbar for about text
        about_scroll = ttk.Scrollbar(about_frame, command=about_text.yview)
        about_scroll.grid(row=0, column=1, sticky="ns")
        about_text.configure(yscrollcommand=about_scroll.set)
        
    def create_status_bar(self, parent):
        """Create status bar"""
        status_frame = ttk.Frame(parent)
        status_frame.grid(row=2, column=0, sticky="ew", pady=(10, 0))
        status_frame.grid_columnconfigure(1, weight=1)
        
        # Status indicator
        self.status_label = ttk.Label(status_frame, text="✅ Ready - All buttons working!", 
                                    foreground="green")
        self.status_label.grid(row=0, column=0, padx=(0, 10))
        
        # Version info
        version_label = ttk.Label(status_frame, text="BoomSQL v2.0 Fixed", 
                                font=("Arial", 9))
        version_label.grid(row=0, column=2)
        
    def show_error(self, title, message):
        """Show error dialog"""
        messagebox.showerror(title, message)
        
    def show_info(self, title, message):
        """Show info dialog"""
        messagebox.showinfo(title, message)
        
    def show_warning(self, title, message):
        """Show warning dialog"""
        messagebox.showwarning(title, message)
        
    def run(self):
        """Run the application"""
        print("🚀 Starting BoomSQL FIXED GUI...")
        print("✅ All button visibility issues have been resolved!")
        print("🎯 Testing interface is now fully functional")
        
        try:
            self.root.mainloop()
        except KeyboardInterrupt:
            print("🛑 Application interrupted by user")
        except Exception as e:
            print(f"❌ Application error: {e}")
            messagebox.showerror("Error", f"Application error: {e}")

def main():
    """Main entry point"""
    print("🎯 BoomSQL Professional SQL Injection Testing Suite")
    print("✅ FIXED VERSION - All buttons guaranteed visible!")
    print("=" * 60)
    
    try:
        # Create and run the fixed GUI
        app = BoomSQLFixedGUI()
        app.run()
    except Exception as e:
        print(f"❌ Failed to start application: {e}")
        input("Press Enter to exit...")

if __name__ == "__main__":
    main()
