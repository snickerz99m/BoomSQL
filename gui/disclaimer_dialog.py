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
        
        print("📋 Creating disclaimer dialog...")
        
        try:
            # Create dialog window
            self.dialog = tk.Toplevel(parent)
            self.dialog.title("BoomSQL - Legal Disclaimer")
            self.dialog.geometry("800x600")
            self.dialog.resizable(False, False)
            self.dialog.transient(parent)
            
            print("📋 Disclaimer dialog window created")
            
            # Windows-specific visibility improvements
            import sys
            if sys.platform.startswith('win'):
                print("📋 Applying Windows-specific disclaimer fixes...")
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
                    print("📋 Windows disclaimer fixes applied")
                except Exception as e:
                    print(f"📋 Windows disclaimer fixes failed: {e}")
            
            # Center dialog
            self.dialog.update_idletasks()
            x = (self.dialog.winfo_screenwidth() // 2) - (800 // 2)
            y = (self.dialog.winfo_screenheight() // 2) - (600 // 2)
            self.dialog.geometry(f"800x600+{x}+{y}")
            
            print("📋 Creating disclaimer widgets...")
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
            # Auto-decline after 60 seconds if no user interaction (increased from 30)
            self.timeout_id = self.dialog.after(60000, self.timeout_disclaimer)
            print("📋 Auto-timeout set for 60 seconds")
            
            print("📋 Showing disclaimer dialog - waiting for user response...")
            
            # Wait for user response
            self.dialog.wait_window()
            
            print(f"📋 Disclaimer dialog closed - accepted: {self.accepted}")
            
        except Exception as e:
            print(f"📋 Error creating disclaimer dialog: {e}")
            # If dialog creation fails, auto-accept
            self.accepted = True
            
    def timeout_disclaimer(self):
        """Handle timeout - auto decline to prevent hanging"""
        print("📋 Auto-declining disclaimer after 60 seconds timeout...")
        if hasattr(self, 'dialog') and self.dialog.winfo_exists():
            self.accepted = False
            self.dialog.destroy()
        
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
        
        print("📋 Disclaimer checkbox created")
        
        # Button frame
        button_frame = ttk.Frame(main_frame)
        button_frame.pack(fill=tk.X, pady=(10, 0))
        
        print("📋 Creating disclaimer buttons...")
        
        # Buttons with enhanced visibility
        self.accept_button = ttk.Button(
            button_frame,
            text="Accept and Continue",
            command=self.accept_disclaimer,
            state=tk.DISABLED
        )
        self.accept_button.pack(side=tk.RIGHT, padx=(10, 0), pady=5)
        
        decline_button = ttk.Button(
            button_frame,
            text="Decline and Exit",
            command=self.decline_disclaimer
        )
        decline_button.pack(side=tk.RIGHT, pady=5)
        
        # Windows-specific button styling and visibility fixes
        import sys
        if sys.platform.startswith('win'):
            try:
                # Force button style refresh on Windows
                style = ttk.Style()
                style.configure('Disclaimer.TButton', padding=(10, 5))
                
                self.accept_button.configure(style='Disclaimer.TButton')
                decline_button.configure(style='Disclaimer.TButton')
                
                # Make buttons more visible
                button_frame.configure(relief='raised', borderwidth=1)
                
                print("📋 Windows-specific button styling applied")
            except Exception as e:
                print(f"📋 Button styling failed: {e}")
        
        # EMERGENCY: Add fallback buttons using tk.Button for Windows compatibility
        if sys.platform.startswith('win'):
            try:
                print("📋 Adding emergency fallback buttons for Windows...")
                
                # Emergency button frame
                emergency_frame = tk.Frame(main_frame, bg="#f0f0f0", relief="raised", bd=2)
                emergency_frame.pack(fill=tk.X, pady=(10, 0))
                
                # Emergency label
                emergency_label = tk.Label(
                    emergency_frame,
                    text="If buttons above don't work, use these emergency buttons:",
                    font=("Arial", 9),
                    bg="#f0f0f0",
                    fg="#666666"
                )
                emergency_label.pack(pady=(5, 0))
                
                # Emergency button frame
                emergency_button_frame = tk.Frame(emergency_frame, bg="#f0f0f0")
                emergency_button_frame.pack(fill=tk.X, pady=(5, 5))
                
                # Emergency accept button
                self.emergency_accept_button = tk.Button(
                    emergency_button_frame,
                    text="✅ ACCEPT & CONTINUE",
                    command=self.emergency_accept,
                    font=("Arial", 10, "bold"),
                    bg="#4CAF50",
                    fg="white",
                    padx=15,
                    pady=5,
                    state=tk.DISABLED
                )
                self.emergency_accept_button.pack(side=tk.RIGHT, padx=(10, 5))
                
                # Emergency decline button
                emergency_decline_button = tk.Button(
                    emergency_button_frame,
                    text="❌ DECLINE & EXIT",
                    command=self.decline_disclaimer,
                    font=("Arial", 10, "bold"),
                    bg="#f44336",
                    fg="white",
                    padx=15,
                    pady=5
                )
                emergency_decline_button.pack(side=tk.RIGHT, padx=5)
                
                print("📋 Emergency fallback buttons created")
                
            except Exception as e:
                print(f"📋 Emergency button creation failed: {e}")
        
        print("📋 Disclaimer buttons created successfully")
        
        # Bind escape key
        self.dialog.bind("<Escape>", lambda e: self.decline_disclaimer())
        
        # Add keyboard shortcuts for accessibility
        self.dialog.bind("<Return>", lambda e: self.try_accept_disclaimer())
        self.dialog.bind("<space>", lambda e: self.toggle_agreement())
        
        # Focus on the checkbox initially for keyboard navigation
        agreement_checkbox.focus_set()
        
        print("📋 Keyboard shortcuts added (Enter=accept, Space=toggle, Esc=decline)")
        
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
        print(f"📋 Checkbox state changed: {self.agreement_var.get()}")
        if self.agreement_var.get():
            print("📋 Enabling accept button")
            self.accept_button.config(state=tk.NORMAL)
            # Also enable emergency button if it exists
            if hasattr(self, 'emergency_accept_button'):
                self.emergency_accept_button.config(state=tk.NORMAL)
                print("📋 Emergency accept button enabled")
        else:
            print("📋 Disabling accept button")
            self.accept_button.config(state=tk.DISABLED)
            # Also disable emergency button if it exists
            if hasattr(self, 'emergency_accept_button'):
                self.emergency_accept_button.config(state=tk.DISABLED)
                print("📋 Emergency accept button disabled")
            
    def try_accept_disclaimer(self):
        """Try to accept disclaimer (for Enter key)"""
        if self.agreement_var.get():
            print("📋 Enter key pressed - accepting disclaimer")
            self.accept_disclaimer()
        else:
            print("📋 Enter key pressed but agreement not checked")
            
    def toggle_agreement(self):
        """Toggle agreement checkbox (for Space key)"""
        current_state = self.agreement_var.get()
        self.agreement_var.set(not current_state)
        self.on_agreement_change()
        print(f"📋 Space key pressed - agreement toggled to {self.agreement_var.get()}")
        
    def emergency_accept(self):
        """Emergency accept method for Windows compatibility"""
        print("📋 Emergency accept button clicked")
        if not self.agreement_var.get():
            print("📋 Agreement checkbox not checked - cannot accept")
            try:
                messagebox.showerror("Error", "You must check the agreement checkbox above to continue.")
            except:
                print("📋 Cannot show error dialog")
            return
        
        # Same logic as regular accept
        self.accept_disclaimer()
            
    def accept_disclaimer(self):
        """Accept disclaimer and continue"""
        print("📋 Accept button clicked")
        if not self.agreement_var.get():
            print("📋 Agreement checkbox not checked")
            messagebox.showerror("Error", "You must agree to the terms to continue.")
            return
            
        # Cancel timeout
        if hasattr(self, 'timeout_id'):
            self.dialog.after_cancel(self.timeout_id)
        
        print("📋 Showing final confirmation dialog...")
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
            print("📋 User confirmed agreement - accepting disclaimer")
            self.accepted = True
            self.dialog.destroy()
        else:
            print("📋 User declined final confirmation")
            
    def decline_disclaimer(self):
        """Decline disclaimer and exit"""
        # Cancel timeout
        if hasattr(self, 'timeout_id'):
            self.dialog.after_cancel(self.timeout_id)
        
        print("📋 Disclaimer declined - exiting")
        self.accepted = False
        self.dialog.destroy()