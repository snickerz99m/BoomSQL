#!/usr/bin/env python3
"""
Windows GUI Test for BoomSQL
Diagnostic tool to test if GUI works on Windows
"""

import sys
import platform

def test_windows_gui():
    """Test GUI functionality on Windows"""
    print("=" * 60)
    print("BoomSQL Windows GUI Diagnostic Test")
    print("=" * 60)
    print()
    
    print(f"Python Version: {sys.version}")
    print(f"Platform: {platform.system()} {platform.release()}")
    print()
    
    # Test 1: Import tkinter
    print("🔍 Test 1: Importing tkinter...")
    try:
        import tkinter as tk
        from tkinter import ttk, messagebox
        print("✅ tkinter imported successfully")
    except ImportError as e:
        print(f"❌ Failed to import tkinter: {e}")
        return False
    
    # Test 2: Create root window
    print("\n🔍 Test 2: Creating root window...")
    try:
        root = tk.Tk()
        root.withdraw()
        print("✅ Root window created successfully")
    except Exception as e:
        print(f"❌ Failed to create root window: {e}")
        return False
    
    # Test 3: Configure window
    print("\n🔍 Test 3: Configuring window...")
    try:
        root.title("BoomSQL Test Window")
        root.geometry("400x300")
        root.configure(bg="#2b2b2b")
        print("✅ Window configured successfully")
    except Exception as e:
        print(f"❌ Failed to configure window: {e}")
        return False
    
    # Test 4: Windows-specific visibility
    print("\n🔍 Test 4: Testing Windows-specific visibility...")
    if sys.platform.startswith('win'):
        try:
            import ctypes
            
            # Show window
            root.deiconify()
            root.update()
            
            # Get window handle
            hwnd = root.winfo_id()
            
            # Apply Windows fixes
            ctypes.windll.user32.ShowWindow(hwnd, 1)  # SW_SHOWNORMAL
            ctypes.windll.user32.SetForegroundWindow(hwnd)
            ctypes.windll.user32.BringWindowToTop(hwnd)
            
            print("✅ Windows-specific visibility applied")
        except Exception as e:
            print(f"⚠️ Windows fixes failed (but tkinter still works): {e}")
    else:
        print("⚠️ Not on Windows, skipping Windows-specific tests")
    
    # Test 5: Create widgets
    print("\n🔍 Test 5: Creating widgets...")
    try:
        # Main frame
        main_frame = tk.Frame(root, bg="#2b2b2b")
        main_frame.pack(fill=tk.BOTH, expand=True, padx=20, pady=20)
        
        # Title label
        title_label = tk.Label(
            main_frame,
            text="BoomSQL GUI Test",
            font=("Arial", 16, "bold"),
            bg="#2b2b2b",
            fg="#ffffff"
        )
        title_label.pack(pady=(0, 20))
        
        # Info label
        info_label = tk.Label(
            main_frame,
            text="If you can see this window, the GUI works!",
            font=("Arial", 12),
            bg="#2b2b2b",
            fg="#ffffff"
        )
        info_label.pack(pady=(0, 20))
        
        # Test button
        def on_button_click():
            messagebox.showinfo("Success", "GUI is working correctly!")
            root.quit()
        
        test_button = tk.Button(
            main_frame,
            text="Click to Confirm GUI Works",
            command=on_button_click,
            font=("Arial", 12),
            bg="#ff6b35",
            fg="#ffffff",
            padx=20,
            pady=10
        )
        test_button.pack(pady=(0, 20))
        
        # Close button
        close_button = tk.Button(
            main_frame,
            text="Close Test",
            command=root.quit,
            font=("Arial", 10),
            bg="#404040",
            fg="#ffffff",
            padx=15,
            pady=5
        )
        close_button.pack()
        
        print("✅ Widgets created successfully")
    except Exception as e:
        print(f"❌ Failed to create widgets: {e}")
        return False
    
    # Test 6: Show window and run main loop
    print("\n🔍 Test 6: Showing window...")
    try:
        # Final visibility push
        root.lift()
        root.focus_force()
        root.attributes('-topmost', True)
        root.update()
        
        # Remove topmost after a moment
        root.after(500, lambda: root.attributes('-topmost', False))
        
        print("✅ Window should now be visible!")
        print("\n📱 GUI Test Window should appear on your screen.")
        print("   If you see the window, click the button to confirm.")
        print("   If you don't see anything, there may be a display issue.")
        print("\n⏳ Starting GUI main loop...")
        
        # Run main loop
        root.mainloop()
        
        print("\n✅ GUI test completed successfully!")
        return True
        
    except Exception as e:
        print(f"❌ Failed to show window: {e}")
        return False
    finally:
        try:
            root.destroy()
        except:
            pass

if __name__ == "__main__":
    success = test_windows_gui()
    
    print("\n" + "=" * 60)
    if success:
        print("🎉 GUI TEST PASSED - BoomSQL GUI should work on your system!")
    else:
        print("❌ GUI TEST FAILED - There may be issues with GUI display")
    print("=" * 60)
