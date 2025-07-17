# 🪟 Running BoomSQL on Windows

## ❌ Can't run `./run_gui.sh` on Windows?

**No, you cannot run `.sh` files directly on Windows!** `.sh` files are shell scripts for Linux/Mac. But don't worry - I've created Windows equivalents for you!

---

## ✅ **Windows Solutions**

### 🚀 **Option 1: Use Windows Batch Files (Recommended)**

I've created Windows-compatible scripts for you:

#### **To Start BoomSQL with GUI:**
```cmd
run_gui.bat
```

#### **To Test BoomSQL:**
```cmd
test_boomsql.bat
```

### 🎯 **Option 2: Direct Python Command**
```cmd
python boomsql.py
```

### 🔧 **Option 3: Use Git Bash (if installed)**
If you have Git for Windows installed:
```bash
bash run_gui.sh
```

---

## 📋 **Step-by-Step Windows Setup**

### 1. **Download Your Project**
- Download ZIP from: https://github.com/snickerz99m/BoomSQL
- Extract to a folder like `C:\BoomSQL\`

### 2. **Install Python Dependencies**
```cmd
cd C:\BoomSQL
pip install -r requirements.txt
```

### 3. **Run BoomSQL**
```cmd
# Option A: Use the Windows batch file
run_gui.bat

# Option B: Direct Python command
python boomsql.py

# Option C: Test everything first
test_boomsql.bat
```

---

## 🔍 **Windows vs Linux Differences**

| Feature | Linux/Mac | Windows |
|---------|-----------|---------|
| **GUI Support** | Needs Xvfb virtual display | Native GUI support |
| **Script Files** | `.sh` shell scripts | `.bat` batch files |
| **Python Command** | `python3` | `python` |
| **File Paths** | `/home/user/` | `C:\Users\User\` |

---

## 🎯 **Windows Advantages**

✅ **Better GUI Support** - Windows has native tkinter support  
✅ **No Virtual Display Needed** - GUI works directly  
✅ **Easier Setup** - Less dependencies to install  
✅ **Native File Dialogs** - Better save/export experience  

---

## 🚨 **Troubleshooting Windows Issues**

### **Problem: "Python not found"**
**Solution:**
1. Install Python from https://python.org
2. Make sure to check "Add Python to PATH" during installation
3. Restart Command Prompt

### **Problem: "tkinter not available"**
**Solution:**
1. Reinstall Python with "tcl/tk and IDLE" option checked
2. Or use: `pip install tk`

### **Problem: "Module not found"**
**Solution:**
```cmd
pip install -r requirements.txt
```

### **Problem: Permission denied**
**Solution:**
- Run Command Prompt as Administrator
- Or change to your user directory first

---

## 💻 **Windows Command Examples**

### **Basic Usage:**
```cmd
# Navigate to project
cd C:\BoomSQL

# Start with GUI
run_gui.bat

# Or start directly
python boomsql.py
```

### **Testing:**
```cmd
# Test all functionality
test_boomsql.bat

# Test specific module
python -c "import core.sql_injection_engine; print('SQL engine works!')"
```

### **Export Results:**
```cmd
# BoomSQL will save files to:
# C:\Users\YourName\Downloads\BoomSQL_Reports\
```

---

## 🎉 **Ready to Go on Windows!**

You now have **Windows-compatible scripts** that do exactly what the Linux `.sh` files do:

✅ **`run_gui.bat`** - Starts BoomSQL with GUI  
✅ **`test_boomsql.bat`** - Tests all functionality  
✅ **Native Windows GUI** - Better than virtual display  
✅ **Easy file exports** - Native Windows file dialogs  

Just download your project and run `run_gui.bat` - it's that simple!

---

## 🔄 **Quick Start Commands**

```cmd
# Download and extract your project, then:
cd BoomSQL
pip install -r requirements.txt
run_gui.bat
```

That's it! Your enhanced BoomSQL will run perfectly on Windows! 🚀
