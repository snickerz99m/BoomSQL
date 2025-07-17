"""
Disclaimer dialog for BoomSQL
Legal disclaimer and usage agreement
"""

import tkinter as tk
from tkinter import ttk
from tkinter import messagebox

class DisclaimerDialog:
    """Legal disclaimer dialog"""
    
    def __init__(self, parent):
        self.parent = parent
        self.accepted = False
        
        # Create dialog window
        self.dialog = tk.Toplevel(parent)
        self.dialog.title("BoomSQL - Legal Disclaimer")
        self.dialog.geometry("800x600")
        self.dialog.resizable(False, False)
        self.dialog.transient(parent)
        
        # Windows-specific visibility improvements
        import sys
        if sys.platform.startswith('win'):
            try:
                import ctypes
                # Make sure dialog appears on top
                self.dialog.attributes('-topmost', True)
                self.dialog.lift()
                self.dialog.focus_force()
                
                # Windows API calls for better visibility
                hwnd = self.dialog.winfo_id()
                ctypes.windll.user32.SetWindowPos(hwnd, -1, 0, 0, 0, 0, 0x0003)
                ctypes.windll.user32.SetForegroundWindow(hwnd)
            except:
                pass  # Ignore if ctypes fails
        
        # Center dialog
        self.dialog.update_idletasks()
        x = (self.dialog.winfo_screenwidth() // 2) - (800 // 2)
        y = (self.dialog.winfo_screenheight() // 2) - (600 // 2)
        self.dialog.geometry(f"800x600+{x}+{y}")
        
        self.create_widgets()
        
        # Enhanced focus and visibility
        self.dialog.grab_set()
        self.dialog.focus_set()
        self.dialog.lift()
        
        # Windows-specific final visibility push
        if sys.platform.startswith('win'):
            self.dialog.after(100, lambda: self.dialog.attributes('-topmost', False))
            self.dialog.after(50, lambda: self.dialog.focus_force())
        
        # Add timeout to prevent hanging in headless environments
        # Auto-decline after 30 seconds if no user interaction
        self.timeout_id = self.dialog.after(30000, self.timeout_disclaimer)
        
        # Wait for user response
        self.dialog.wait_window()
        
    def create_widgets(self):
        """Create dialog widgets"""
        # Main frame
        main_frame = ttk.Frame(self.dialog)
        main_frame.pack(fill=tk.BOTH, expand=True, padx=20, pady=20)
        
        # Title
        title_label = ttk.Label(
            main_frame, 
            text="BoomSQL - Advanced SQL Injection Testing Tool",
            font=("Arial", 16, "bold")
        )
        title_label.pack(pady=(0, 10))
        
        # Version info
        version_label = ttk.Label(
            main_frame,
            text="Version 2.0.0 - Python Edition",
            font=("Arial", 12)
        )
        version_label.pack(pady=(0, 20))
        
        # Warning header
        warning_frame = ttk.Frame(main_frame)
        warning_frame.pack(fill=tk.X, pady=(0, 20))
        
        warning_label = ttk.Label(
            warning_frame,
            text="⚠️ IMPORTANT LEGAL DISCLAIMER ⚠️",
            font=("Arial", 14, "bold"),
            foreground="red"
        )
        warning_label.pack()
        
        # Disclaimer text
        disclaimer_frame = ttk.Frame(main_frame)
        disclaimer_frame.pack(fill=tk.BOTH, expand=True, pady=(0, 20))
        
        # Scrollable text
        text_frame = ttk.Frame(disclaimer_frame)
        text_frame.pack(fill=tk.BOTH, expand=True)
        
        scrollbar = ttk.Scrollbar(text_frame)
        scrollbar.pack(side=tk.RIGHT, fill=tk.Y)
        
        self.text_widget = tk.Text(
            text_frame,
            wrap=tk.WORD,
            yscrollcommand=scrollbar.set,
            font=("Arial", 10),
            bg="white",
            fg="black",
            state=tk.DISABLED
        )
        self.text_widget.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        scrollbar.config(command=self.text_widget.yview)
        
        # Insert disclaimer text
        disclaimer_text = self.get_disclaimer_text()
        self.text_widget.config(state=tk.NORMAL)
        self.text_widget.insert(tk.END, disclaimer_text)
        self.text_widget.config(state=tk.DISABLED)
        
        # Checkbox frame
        checkbox_frame = ttk.Frame(main_frame)
        checkbox_frame.pack(fill=tk.X, pady=(0, 20))
        
        self.agreement_var = tk.BooleanVar()
        agreement_checkbox = ttk.Checkbutton(
            checkbox_frame,
            text="I have read and agree to the terms above. I understand that this tool is for educational and authorized testing purposes only.",
            variable=self.agreement_var,
            command=self.on_agreement_change
        )
        agreement_checkbox.pack(anchor=tk.W)
        
        # Button frame
        button_frame = ttk.Frame(main_frame)
        button_frame.pack(fill=tk.X)
        
        # Buttons
        self.accept_button = ttk.Button(
            button_frame,
            text="Accept and Continue",
            command=self.accept_disclaimer,
            state=tk.DISABLED
        )
        self.accept_button.pack(side=tk.RIGHT, padx=(10, 0))
        
        decline_button = ttk.Button(
            button_frame,
            text="Decline and Exit",
            command=self.decline_disclaimer
        )
        decline_button.pack(side=tk.RIGHT)
        
        # Bind escape key
        self.dialog.bind("<Escape>", lambda e: self.decline_disclaimer())
        
    def get_disclaimer_text(self):
        """Get the disclaimer text"""
        return """FOR EDUCATIONAL AND AUTHORIZED TESTING ONLY

BoomSQL is an advanced SQL injection testing tool designed specifically for:
• Educational purposes and learning about SQL injection vulnerabilities
• Authorized penetration testing and security assessments
• Bug bounty programs with proper authorization
• Security research in controlled environments

LEGAL REQUIREMENTS AND RESTRICTIONS:

1. AUTHORIZED USE ONLY
   - You may only use this tool on systems you own or have explicit written permission to test
   - Unauthorized testing of systems without permission is illegal and may result in criminal charges
   - You must obtain proper authorization before testing any system

2. EDUCATIONAL PURPOSE
   - This tool is intended for educational purposes to understand SQL injection vulnerabilities
   - Use for learning about web application security and defensive measures
   - Not intended for malicious purposes or unauthorized access

3. LEGAL COMPLIANCE
   - Users must comply with all applicable laws and regulations
   - Respect terms of service of target systems
   - Follow responsible disclosure practices for discovered vulnerabilities

4. LIABILITY DISCLAIMER
   - The developers of BoomSQL assume no liability for misuse of this software
   - Users are solely responsible for their actions and any consequences
   - Use of this tool is at your own risk

5. NO WARRANTY
   - This software is provided "as is" without warranty of any kind
   - No guarantee of accuracy, reliability, or suitability for any purpose
   - Users assume all risks associated with the use of this software

6. PROHIBITED ACTIVITIES
   - Do not use this tool for unauthorized penetration testing
   - Do not use for malicious purposes or to cause harm
   - Do not use to access systems without proper authorization
   - Do not use to violate privacy or confidentiality

7. REPORTING VULNERABILITIES
   - Follow responsible disclosure practices
   - Report vulnerabilities to system owners or appropriate authorities
   - Do not exploit vulnerabilities for personal gain

8. MODIFICATION AND DISTRIBUTION
   - Modifications must retain this disclaimer
   - Distribution must include this legal notice
   - Commercial use requires explicit permission

INTERNATIONAL USERS:
Different countries have different laws regarding penetration testing and security research. 
It is your responsibility to understand and comply with the laws in your jurisdiction.

EXAMPLES OF AUTHORIZED USE:
• Testing your own web applications
• Authorized penetration testing with written permission
• Educational exercises in controlled environments
• Bug bounty programs that explicitly allow such tools
• Security research with proper ethics approval

EXAMPLES OF PROHIBITED USE:
• Testing websites without permission
• Accessing databases without authorization
• Exploiting vulnerabilities for personal gain
• Causing damage to systems or data
• Violating terms of service

ADDITIONAL WARNINGS:
• This tool can cause significant load on target systems
• Improper use may trigger security alerts and investigations
• Legal consequences can include fines and imprisonment
• Civil liability may apply for damages caused

By using this software, you acknowledge that you have read, understood, and agree to be bound by these terms. You confirm that you will use this tool only for lawful purposes and in accordance with all applicable laws and regulations.

If you do not agree to these terms, you must not use this software.

Remember: "With great power comes great responsibility." Use this tool ethically and legally.

© 2024 BoomSQL Development Team - All Rights Reserved
Version 2.0.0 - Python Edition"""

    def on_agreement_change(self):
        """Handle agreement checkbox change"""
        if self.agreement_var.get():
            self.accept_button.config(state=tk.NORMAL)
        else:
            self.accept_button.config(state=tk.DISABLED)
            
    def accept_disclaimer(self):
        """Accept disclaimer and continue"""
        if not self.agreement_var.get():
            messagebox.showerror("Error", "You must agree to the terms to continue.")
            return
            
        # Cancel timeout
        if hasattr(self, 'timeout_id'):
            self.dialog.after_cancel(self.timeout_id)
            
        # Show final confirmation
        result = messagebox.askyesno(
            "Final Confirmation",
            "Are you sure you want to proceed?\n\n" +
            "By clicking 'Yes', you confirm that:\n" +
            "• You will use this tool only for authorized testing\n" +
            "• You understand the legal implications\n" +
            "• You accept full responsibility for your actions\n" +
            "• You will comply with all applicable laws"
        )
        
        if result:
            self.accepted = True
            self.dialog.destroy()
            
    def decline_disclaimer(self):
        """Decline disclaimer and exit"""
        # Cancel timeout
        if hasattr(self, 'timeout_id'):
            self.dialog.after_cancel(self.timeout_id)
            
        self.accepted = False
        self.dialog.destroy()
        
    def timeout_disclaimer(self):
        """Handle timeout - auto decline to prevent hanging"""
        self.accepted = False
        self.dialog.destroy()