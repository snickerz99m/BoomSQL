"""
Completely Redesigned Main Window for BoomSQL
Clean, modern GUI with guaranteed button visibility
"""

import tkinter as tk
from tkinter import ttk
import asyncio
import sys
from pathlib import Path

# Add the project root to the path
project_root = Path(__file__).parent.parent
sys.path.insert(0, str(project_root))

from gui.tester_page_new import TesterPageNew
from gui.dumper_page_new import DumperPageNew
from gui.disclaimer_dialog import DisclaimerDialog

class BoomSQLMainWindowNew:
    """Redesigned main window with guaranteed button visibility"""
    
    def __init__(self):
        self.root = tk.Tk()
        self.setup_window()
        self.create_widgets()
        
    def setup_window(self):
        """Setup main window properties"""
        self.root.title("BoomSQL v2.0 - Professional SQL Injection Testing Suite")
        self.root.geometry("1400x900")
        self.root.minsize(1200, 700)
        
        # Configure style
        style = ttk.Style()
        
        # Use a modern theme
        try:
            style.theme_use('clam')  # Modern looking theme
        except:
            style.theme_use('default')
            
        # Configure custom styles
        style.configure('Accent.TButton', foreground='white', background='#0078d4')
        style.map('Accent.TButton', 
                 background=[('active', '#106ebe'), ('pressed', '#005a9e')])
        
        # Configure the main window
        self.root.configure(bg='#f0f0f0')
        
        # Center window on screen
        self.center_window()
        
    def center_window(self):
        """Center the window on screen"""
        self.root.update_idletasks()
        width = self.root.winfo_width()
        height = self.root.winfo_height()
        x = (self.root.winfo_screenwidth() // 2) - (width // 2)
        y = (self.root.winfo_screenheight() // 2) - (height // 2)
        self.root.geometry(f'{width}x{height}+{x}+{y}')
        
    def create_widgets(self):
        """Create main window widgets"""
        
        # Create main container
        main_container = ttk.Frame(self.root, padding="5")
        main_container.pack(fill=tk.BOTH, expand=True)
        
        # Create title bar
        self.create_title_bar(main_container)
        
        # Create main content area
        self.create_main_content(main_container)
        
        # Create status bar
        self.create_status_bar(main_container)
        
    def create_title_bar(self, parent):
        """Create title bar with logo and info"""
        
        title_frame = ttk.Frame(parent, style='Title.TFrame')
        title_frame.pack(fill=tk.X, pady=(0, 10))
        
        # Configure title style
        style = ttk.Style()
        style.configure('Title.TFrame', background='#2d3142')
        style.configure('Title.TLabel', background='#2d3142', foreground='white', font=('Arial', 16, 'bold'))
        style.configure('Subtitle.TLabel', background='#2d3142', foreground='#a8a8a8', font=('Arial', 10))
        
        # Title and subtitle
        title_content = ttk.Frame(title_frame, style='Title.TFrame', padding="15")
        title_content.pack(fill=tk.X)
        
        title_label = ttk.Label(title_content, text="🚀 BoomSQL v2.0", style='Title.TLabel')
        title_label.pack(anchor=tk.W)
        
        subtitle_label = ttk.Label(title_content, text="Professional SQL Injection Testing Suite with SQLMap Integration", style='Subtitle.TLabel')
        subtitle_label.pack(anchor=tk.W)
        
    def create_main_content(self, parent):
        """Create main content area with notebook"""
        
        # Create notebook for different pages
        self.notebook = ttk.Notebook(parent, style='Main.TNotebook')
        self.notebook.pack(fill=tk.BOTH, expand=True, pady=(0, 10))
        
        # Configure notebook style
        style = ttk.Style()
        style.configure('Main.TNotebook', tabposition='n')
        style.configure('Main.TNotebook.Tab', padding=[20, 10])
        
        # Create pages
        self.create_pages()
        
    def create_pages(self):
        """Create all application pages"""
        
        # SQL Injection Tester Page
        self.tester_page = TesterPageNew(self.notebook, self)
        self.notebook.add(self.tester_page, text="🔍 SQL Injection Tester")
        
        # Database Dumper Page
        self.dumper_page = DumperPageNew(self.notebook, self)
        self.notebook.add(self.dumper_page, text="📦 Database Dumper")
        
        # Additional pages can be added here
        self.create_about_page()
        
    def create_about_page(self):
        """Create about page"""
        
        about_frame = ttk.Frame(self.notebook, padding="20")
        self.notebook.add(about_frame, text="ℹ️ About")
        
        # About content
        about_text = tk.Text(about_frame, wrap=tk.WORD, state=tk.DISABLED, 
                           font=('Arial', 11), bg='#f8f9fa', relief=tk.FLAT)
        
        about_content = """BoomSQL v2.0 - Professional SQL Injection Testing Suite

🎯 Features:
• Advanced SQL injection detection using multiple techniques
• Real SQLMap integration for professional-grade testing
• Automated database enumeration and data extraction
• WAF bypass capabilities
• Comprehensive reporting and export options
• Modern, user-friendly interface

🔧 Technical Details:
• Supports all major SQL injection techniques (Boolean, Error, Union, Time-based, Stacked)
• SQLMap 1.9.7.7#dev integrated locally
• Multi-threaded testing for improved performance
• Smart testing algorithms to reduce false positives
• Professional vulnerability reporting

⚖️ Legal Notice:
This tool is intended for authorized security testing only. Users are responsible for ensuring they have proper authorization before testing any systems. Unauthorized access to computer systems is illegal and may result in severe legal consequences.

🛡️ Responsible Disclosure:
Always follow responsible disclosure practices when reporting vulnerabilities. Ensure you have explicit permission before testing any systems you do not own.

💻 Technical Support:
For technical support, documentation, and updates, please refer to the project repository.

Version: 2.0
SQLMap Version: 1.9.7.7#dev
License: Educational and Authorized Testing Only
"""
        
        about_text.config(state=tk.NORMAL)
        about_text.insert(tk.END, about_content)
        about_text.config(state=tk.DISABLED)
        
        # Add scrollbar
        about_scroll = ttk.Scrollbar(about_frame, orient=tk.VERTICAL, command=about_text.yview)
        about_text.configure(yscrollcommand=about_scroll.set)
        
        about_text.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        about_scroll.pack(side=tk.RIGHT, fill=tk.Y)
        
    def create_status_bar(self, parent):
        """Create status bar"""
        
        status_frame = ttk.Frame(parent, relief=tk.SUNKEN, borderwidth=1)
        status_frame.pack(fill=tk.X, side=tk.BOTTOM)
        
        # Status label
        self.status_label = ttk.Label(status_frame, text="Ready - BoomSQL v2.0 with SQLMap Integration", padding="5")
        self.status_label.pack(side=tk.LEFT)
        
        # Version info
        version_label = ttk.Label(status_frame, text="SQLMap: 1.9.7.7#dev", padding="5")
        version_label.pack(side=tk.RIGHT)
        
    def show_disclaimer(self):
        """Show disclaimer dialog"""
        return DisclaimerDialog(self.root).show()
        
    def run(self):
        """Run the application"""
        
        # Show disclaimer first
        if not self.show_disclaimer():
            return  # User declined, exit
            
        # Start main loop
        try:
            self.root.mainloop()
        except KeyboardInterrupt:
            self.root.quit()
            
    def update_status(self, message):
        """Update status bar message"""
        self.status_label.config(text=message)
        
def main():
    """Main entry point"""
    try:
        app = BoomSQLMainWindowNew()
        app.run()
    except Exception as e:
        print(f"Error starting BoomSQL: {e}")
        input("Press Enter to exit...")

if __name__ == "__main__":
    main()
