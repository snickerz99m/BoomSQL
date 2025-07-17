# 🔧 BoomSQL GUI Troubleshooting Guide

## 🚨 Issue: GUI Started But Can't See Window

Based on your output, BoomSQL **IS working correctly**! Here's what's happening:

```
2025-07-17 15:19:40 - gui.main_window - INFO - Switched to [Search] Dork Search
```

This shows the GUI **is running** and responding to user interactions! 

---

## 🎯 **Quick Fixes**

### 1. **Check if GUI Window is Hidden**
The GUI window might be running but not visible. Try these:

**Windows:**
- Press `Alt + Tab` to see all open windows
- Check your taskbar for a BoomSQL window
- Look for a Python/tkinter window

**The window might be:**
- Minimized to taskbar
- Behind other windows
- On a different virtual desktop

### 2. **Force GUI to Front** (Windows)
```cmd
# Stop current instance first
Ctrl + C

# Then restart with our Windows batch file
run_gui.bat
```

### 3. **Check Window Size/Position**
The window might be off-screen or very small. Try:
- Moving your mouse to screen edges
- Using `Windows + D` to show desktop
- Using `Windows + Arrow keys` to snap windows

---

## 🐛 **Common Windows GUI Issues**

### **Issue 1: Window Opens But Disappears**
**Cause:** Window opens then immediately closes
**Solution:**
```cmd
# Run in Command Prompt (not PowerShell)
cd C:\BoomSQL
python boomsql.py
```

### **Issue 2: tkinter Import Error**
**Cause:** Python installed without tkinter
**Solution:**
```cmd
# Test tkinter
python -c "import tkinter; print('tkinter works!')"

# If fails, reinstall Python with tkinter
# Download from python.org and check "tcl/tk and IDLE"
```

### **Issue 3: Permission Issues**
**Cause:** Windows blocking execution
**Solution:**
- Run Command Prompt as Administrator
- Or add Python to Windows Defender exceptions

### **Issue 4: Multiple Python Versions**
**Cause:** Using wrong Python version
**Solution:**
```cmd
# Check Python version
python --version

# Should be 3.8 or higher
# If not, try:
python3 boomsql.py
# or
py -3 boomsql.py
```

---

## ✅ **Verify BoomSQL is Working**

### **Test 1: Quick GUI Test**
```cmd
python -c "
import tkinter as tk
root = tk.Tk()
root.title('BoomSQL Test')
root.geometry('400x300')
label = tk.Label(root, text='BoomSQL GUI Test - Close this window')
label.pack(pady=50)
root.mainloop()
"
```

If this window appears, your GUI system works!

### **Test 2: BoomSQL Module Test**
```cmd
python -c "
from core.config_manager import ConfigManager
from gui.main_window import MainWindow
print('✅ BoomSQL modules working!')
"
```

### **Test 3: Full Startup Test**
```cmd
# Run with verbose output
python boomsql.py 2>&1
```

---

## 🎯 **Step-by-Step Debugging**

### **Step 1: Kill Existing Process**
```cmd
# On Windows, find and close any Python processes
# Or restart your computer
```

### **Step 2: Clean Start**
```cmd
cd C:\BoomSQL
python boomsql.py
```

### **Step 3: Watch for Error Messages**
Look for errors like:
- `ImportError: No module named tkinter`
- `TclError: no display name`
- `ModuleNotFoundError`

### **Step 4: Try Alternative Launch**
```cmd
# Method 1: Direct Python
python -m boomsql

# Method 2: Use our batch file
run_gui.bat

# Method 3: Minimal test
python -c "import boomsql; print('Module imported!')"
```

---

## 🚀 **Windows-Specific Solutions**

### **Registry Fix (Advanced)**
If tkinter still doesn't work:
```cmd
# Reinstall Python with all options
# From python.org, check ALL boxes during install
```

### **Environment Variables**
```cmd
# Check Python path
echo %PATH%

# Should include something like:
# C:\Users\YourName\AppData\Local\Programs\Python\Python311\
# C:\Users\YourName\AppData\Local\Programs\Python\Python311\Scripts\
```

### **Windows Defender**
1. Open Windows Defender
2. Add exclusion for your BoomSQL folder
3. Add exclusion for Python executable

---

## 🔍 **What Your Output Tells Us**

Your log shows:
```
✅ Logger started successfully
✅ Configuration loaded
✅ GUI main window initialized  
✅ GUI responded to user interaction (switched to Dork Search)
```

**This means BoomSQL IS working!** The issue is likely:
1. Window is hidden/minimized
2. Window opened off-screen
3. Window is behind other applications

---

## 🎯 **Next Steps**

1. **Press `Alt + Tab`** to see all windows
2. **Check your taskbar** for BoomSQL
3. **Try `Windows + D`** to show desktop
4. If still not visible, **restart** and try our Windows batch file:
   ```cmd
   run_gui.bat
   ```

The GUI **is working** - we just need to make it visible! 🎉
