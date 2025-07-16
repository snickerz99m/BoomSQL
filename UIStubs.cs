using System;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;

namespace System.Windows.Forms
{
    // Basic stubs for Windows Forms controls to allow compilation
    public class Form : Control
    {
        public virtual void Show() { }
        public virtual void Hide() { }
        public virtual DialogResult ShowDialog() => DialogResult.OK;
        public event EventHandler? Load;
        protected virtual void OnLoad(EventArgs e) => Load?.Invoke(this, e);
    }

    public class UserControl : Control
    {
        public override void BringToFront() { }
        public override void SendToBack() { }
        protected override void Dispose(bool disposing) { }
    }

    public class Control
    {
        public virtual string Text { get; set; } = "";
        public virtual Color BackColor { get; set; } = Color.White;
        public virtual Color ForeColor { get; set; } = Color.Black;
        public virtual Font Font { get; set; } = new Font("Arial", 10);
        public virtual Size Size { get; set; } = new Size(100, 20);
        public virtual Point Location { get; set; } = new Point(0, 0);
        public virtual bool Visible { get; set; } = true;
        public virtual bool Enabled { get; set; } = true;
        public virtual DockStyle Dock { get; set; } = DockStyle.None;
        public virtual AnchorStyles Anchor { get; set; } = AnchorStyles.Top | AnchorStyles.Left;
        public virtual Padding Margin { get; set; } = new Padding(3);
        public virtual int TabIndex { get; set; } = 0;
        public virtual string Name { get; set; } = "";
        public virtual object Tag { get; set; } = null;
        public virtual bool InvokeRequired => false;
        public virtual Control Parent { get; set; } = null;
        public virtual ControlCollection Controls { get; } = new ControlCollection();
        
        public virtual void Invoke(Delegate method, params object[] args) => method.DynamicInvoke(args);
        public virtual void BringToFront() { }
        public virtual void SendToBack() { }
        public virtual void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        
        public event EventHandler? Click;
        protected virtual void OnClick(EventArgs e) => Click?.Invoke(this, e);
    }

    public class ControlCollection : List<Control>
    {
        public new virtual void Clear() => base.Clear();
        public new virtual void Add(Control control) => base.Add(control);
        public new virtual void Remove(Control control) => base.Remove(control);
    }

    public class Button : Control
    {
        public virtual DialogResult DialogResult { get; set; } = DialogResult.None;
        public virtual void PerformClick() => OnClick(EventArgs.Empty);
    }

    public class Label : Control { }
    
    public class TextBox : Control
    {
        public virtual string[] Lines { get; set; } = new string[0];
        public virtual bool Multiline { get; set; } = false;
        public virtual bool ReadOnly { get; set; } = false;
        public virtual ScrollBars ScrollBars { get; set; } = ScrollBars.None;
        public virtual void AppendText(string text) { }
        public virtual void ScrollToCaret() { }
    }

    public class ListBox : Control
    {
        public virtual ListBox.ObjectCollection Items { get; } = new ListBox.ObjectCollection();
        public virtual int SelectedIndex { get; set; } = -1;
        public virtual object SelectedItem { get; set; } = null;
        public event EventHandler? SelectedIndexChanged;
        public event MouseEventHandler? MouseClick;
        public event MouseEventHandler? MouseDoubleClick;
        
        public class ObjectCollection : List<object>
        {
            public virtual void Clear() => base.Clear();
            public virtual void Add(object item) => base.Add(item);
            public virtual void Remove(object item) => base.Remove(item);
        }
    }

    public class CheckBox : Control
    {
        public virtual bool Checked { get; set; } = false;
        public virtual CheckState CheckState { get; set; } = CheckState.Unchecked;
        public event EventHandler? CheckedChanged;
    }

    public class NumericUpDown : Control
    {
        public virtual decimal Value { get; set; } = 0;
        public virtual decimal Minimum { get; set; } = 0;
        public virtual decimal Maximum { get; set; } = 100;
        public virtual int DecimalPlaces { get; set; } = 0;
        public event EventHandler? ValueChanged;
    }

    public class ProgressBar : Control
    {
        public virtual int Value { get; set; } = 0;
        public virtual int Minimum { get; set; } = 0;
        public virtual int Maximum { get; set; } = 100;
        public virtual ProgressBarStyle Style { get; set; } = ProgressBarStyle.Blocks;
    }

    public class TreeView : Control
    {
        public virtual TreeNodeCollection Nodes { get; } = new TreeNodeCollection();
        public virtual TreeNode SelectedNode { get; set; } = null;
        public virtual ImageList ImageList { get; set; } = null;
        public virtual void ExpandAll() { }
        public virtual void CollapseAll() { }
        public event TreeViewEventHandler? AfterSelect;
    }

    public class TreeNode
    {
        public virtual string Text { get; set; } = "";
        public virtual object Tag { get; set; } = null;
        public virtual string ImageKey { get; set; } = "";
        public virtual string SelectedImageKey { get; set; } = "";
        public virtual TreeNodeCollection Nodes { get; } = new TreeNodeCollection();
        public TreeNode() { }
        public TreeNode(string text) { Text = text; }
    }

    public class TreeNodeCollection : List<TreeNode>
    {
        public virtual void Clear() => base.Clear();
        public virtual void Add(TreeNode node) => base.Add(node);
        public virtual void Remove(TreeNode node) => base.Remove(node);
    }

    public class DataGridView : Control
    {
        public virtual object DataSource { get; set; } = null;
        public virtual DataGridViewColumnCollection Columns { get; } = new DataGridViewColumnCollection();
        public virtual DataGridViewRowCollection Rows { get; } = new DataGridViewRowCollection();
    }

    public class DataGridViewColumnCollection : List<object> { }
    public class DataGridViewRowCollection : List<object> { }

    public class Panel : Control { }
    public class SplitContainer : Control
    {
        public virtual SplitterPanel Panel1 { get; } = new SplitterPanel();
        public virtual SplitterPanel Panel2 { get; } = new SplitterPanel();
    }
    public class SplitterPanel : Panel { }

    public class Timer : IDisposable
    {
        public virtual int Interval { get; set; } = 100;
        public virtual bool Enabled { get; set; } = false;
        public virtual void Start() => Enabled = true;
        public virtual void Stop() => Enabled = false;
        public virtual void Dispose() { }
        public event EventHandler? Tick;
    }

    public class ImageList : IDisposable
    {
        public virtual ImageCollection Images { get; } = new ImageCollection();
        public virtual void Dispose() { }
        
        public class ImageCollection : Dictionary<string, object>
        {
            public virtual void Add(string key, object image) => this[key] = image;
        }
    }

    public class ContextMenuStrip : Control
    {
        public virtual ToolStripItemCollection Items { get; } = new ToolStripItemCollection();
        public virtual void Show(Control control, Point position) { }
    }

    public class ToolStripItemCollection : List<ToolStripItem> { }
    public class ToolStripItem
    {
        public virtual string Text { get; set; } = "";
        public virtual bool Enabled { get; set; } = true;
        public virtual bool Visible { get; set; } = true;
        public event EventHandler? Click;
    }
    public class ToolStripMenuItem : ToolStripItem { }

    public class OpenFileDialog : IDisposable
    {
        public virtual string Filter { get; set; } = "";
        public virtual string FileName { get; set; } = "";
        public virtual string InitialDirectory { get; set; } = "";
        public virtual DialogResult ShowDialog() => DialogResult.OK;
        public virtual void Dispose() { }
    }

    public class SaveFileDialog : IDisposable
    {
        public virtual string Filter { get; set; } = "";
        public virtual string FileName { get; set; } = "";
        public virtual string InitialDirectory { get; set; } = "";
        public virtual DialogResult ShowDialog() => DialogResult.OK;
        public virtual void Dispose() { }
    }

    public class MessageBox
    {
        public static DialogResult Show(string text) => DialogResult.OK;
        public static DialogResult Show(string text, string caption) => DialogResult.OK;
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons) => DialogResult.OK;
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon) => DialogResult.OK;
    }

    public class Application
    {
        public static string StartupPath => Environment.CurrentDirectory;
        public static void Exit() { }
    }

    public class StatusStrip : Control
    {
        public virtual ToolStripItemCollection Items { get; } = new ToolStripItemCollection();
    }

    public class ToolStripStatusLabel : ToolStripItem { }
    public class ToolStripProgressBar : ToolStripItem
    {
        public int Value { get; set; } = 0;
        public int Maximum { get; set; } = 100;
        public int Minimum { get; set; } = 0;
    }

    public class DataGridViewTextBoxColumn : Control
    {
        public string HeaderText { get; set; } = "";
        public string Name { get; set; } = "";
        public int Width { get; set; } = 100;
    }

    public class Clipboard
    {
        public static void SetText(string text) { }
        public static string GetText() => "";
    }

    public delegate void MouseEventHandler(object sender, MouseEventArgs e);
    public delegate void TreeViewEventHandler(object sender, TreeViewEventArgs e);

    public class MouseEventArgs : EventArgs
    {
        public MouseButtons Button { get; set; }
        public Point Location { get; set; }
        public MouseEventArgs(MouseButtons button, int clicks, int x, int y, int delta) 
        { 
            Button = button; 
            Location = new Point(x, y); 
        }
    }

    public class TreeViewEventArgs : EventArgs
    {
        public TreeNode Node { get; set; }
        public TreeViewEventArgs(TreeNode node) { Node = node; }
    }

    public class PaintEventArgs : EventArgs
    {
        public Graphics Graphics { get; set; }
        public Rectangle ClipRectangle { get; set; }
        public PaintEventArgs(Graphics graphics, Rectangle clipRectangle) 
        { 
            Graphics = graphics; 
            ClipRectangle = clipRectangle; 
        }
    }

    public class Graphics : IDisposable
    {
        public void Dispose() { }
    }

    public enum MouseButtons { Left, Right, Middle }
    public enum DialogResult { None, OK, Cancel, Yes, No }
    public enum DockStyle { None, Top, Bottom, Left, Right, Fill }
    public enum AnchorStyles { None = 0, Top = 1, Bottom = 2, Left = 4, Right = 8 }
    public enum CheckState { Unchecked, Checked, Indeterminate }
    public enum ScrollBars { None, Horizontal, Vertical, Both }
    public enum ProgressBarStyle { Blocks, Continuous, Marquee }
    public enum MessageBoxButtons { OK, OKCancel, YesNo, YesNoCancel }
    public enum MessageBoxIcon { None, Information, Warning, Error, Question }
}

namespace System.Data
{
    public class DataTable
    {
        public virtual DataColumnCollection Columns { get; } = new DataColumnCollection();
        public virtual DataRowCollection Rows { get; } = new DataRowCollection();
        public virtual DataRow NewRow() => new DataRow();
    }

    public class DataColumnCollection : List<DataColumn>
    {
        public virtual void Add(string columnName, Type dataType) => Add(new DataColumn(columnName, dataType));
    }

    public class DataRowCollection : List<DataRow>
    {
        public virtual void Add(DataRow row) => base.Add(row);
    }

    public class DataColumn
    {
        public virtual string ColumnName { get; set; } = "";
        public virtual Type DataType { get; set; } = typeof(string);
        public DataColumn() { }
        public DataColumn(string columnName, Type dataType) { ColumnName = columnName; DataType = dataType; }
    }

    public class DataRow
    {
        private Dictionary<string, object> _data = new Dictionary<string, object>();
        public virtual object this[string columnName] 
        { 
            get => _data.ContainsKey(columnName) ? _data[columnName] : null; 
            set => _data[columnName] = value; 
        }
    }
}

namespace System.Drawing
{
    public struct Color
    {
        public static Color White => new Color();
        public static Color Black => new Color();
        public static Color Transparent => new Color();
        public static Color FromArgb(int argb) => new Color();
        public static Color FromArgb(int alpha, int red, int green, int blue) => new Color();
        public static Color FromArgb(int red, int green, int blue) => new Color();
        public static Color Blue => new Color();
        public static Color Red => new Color();
        public static Color Green => new Color();
        public static Color Yellow => new Color();
        public static Color Gray => new Color();
        public static Color Silver => new Color();
        public static Color Aqua => new Color();
    }

    public struct Size
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Size(int width, int height) { Width = width; Height = height; }
    }

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y) { X = x; Y = y; }
    }

    public struct Rectangle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle(int x, int y, int width, int height) { X = x; Y = y; Width = width; Height = height; }
    }

    public struct Padding
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
        public Padding(int all) { Left = Top = Right = Bottom = all; }
        public Padding(int left, int top, int right, int bottom) { Left = left; Top = top; Right = right; Bottom = bottom; }
    }

    public class Font : IDisposable
    {
        public string Name { get; set; } = "";
        public float Size { get; set; } = 10f;
        public Font(string name, float size) { Name = name; Size = size; }
        public void Dispose() { }
    }

    public class Bitmap : IDisposable
    {
        public Bitmap(int width, int height) { }
        public void Dispose() { }
    }

    public class SystemIcons
    {
        public static Icon Application => new Icon();
        public static Icon Error => new Icon();
        public static Icon Warning => new Icon();
        public static Icon Information => new Icon();
    }

    public class Icon
    {
        public Bitmap ToBitmap() => new Bitmap(16, 16);
    }
}

namespace Guna.UI2.WinForms
{
    public class Guna2Button : System.Windows.Forms.Button { }
    public class Guna2TextBox : System.Windows.Forms.TextBox { }
    public class Guna2ProgressBar : System.Windows.Forms.ProgressBar { }
    public class Guna2ControlBox : System.Windows.Forms.Control { }
    public class Guna2CheckBox : System.Windows.Forms.CheckBox { }
    public class Guna2ToggleSwitch : System.Windows.Forms.Control 
    {
        public bool Checked { get; set; } = false;
        public event EventHandler CheckedChanged;
    }
    public class Guna2HtmlLabel : System.Windows.Forms.Label { }
    public class Guna2Panel : System.Windows.Forms.Panel { }
    public class Guna2Separator : System.Windows.Forms.Control { }
    public class Guna2ResizeForm : System.Windows.Forms.Control { }
    
    namespace Suite
    {
        public class CustomizableEdges { }
    }
}

namespace Bunifu.UI.WinForms
{
    public class BunifuGroupBox : System.Windows.Forms.Panel { }
    public class BunifuTextBox : System.Windows.Forms.TextBox { }
    public class BunifuButton : System.Windows.Forms.Button { }
    public class BunifuCheckBox : System.Windows.Forms.CheckBox { }
    public class BunifuDropdown : System.Windows.Forms.Control { }
    public class BunifuPages : System.Windows.Forms.Control { }
    public class BunifuImageButton : System.Windows.Forms.Button { }
    public class BunifuCards : System.Windows.Forms.Panel { }
    public class BunifuTransition : System.Windows.Forms.Control { }
    public class BunifuFormDock : System.Windows.Forms.Control { }
    public class BunifuFormDrag : System.Windows.Forms.Control { }
    public class BunifuDragControl : System.Windows.Forms.Control { }
    public class BunifuElipse : System.Windows.Forms.Control { }
    public class BunifuGradientPanel : System.Windows.Forms.Panel { }
    public class BunifuSeparator : System.Windows.Forms.Control { }
    public class BunifuToolTip : System.Windows.Forms.Control { }
    public class BunifuSnackbar : System.Windows.Forms.Control { }
    public class BunifuLoader : System.Windows.Forms.Control { }
    public class BunifuSlider : System.Windows.Forms.Control { }
    public class BunifuColorTransition : System.Windows.Forms.Control { }
    public class BunifuProgressBar : System.Windows.Forms.ProgressBar { }
    public class BunifuDataGridView : System.Windows.Forms.DataGridView { }
}

namespace System.ComponentModel
{
    public class LicenseManager
    {
        public static LicenseUsageMode UsageMode => LicenseUsageMode.Runtime;
    }
    
    public enum LicenseUsageMode
    {
        Runtime,
        Designtime
    }
}