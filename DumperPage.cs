using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Net.Http;
using System.Threading;
using BoomSQL.Core;

namespace BoomSQL
{
    public partial class DumperPage : BasePage
    {
        private DatabaseStructure _database = new DatabaseStructure();
        private bool _isDumping = false;
        private System.Windows.Forms.Timer _progressTimer = new System.Windows.Forms.Timer();
        private int _maxThreads = 3;
        private HttpClient _httpClient = new HttpClient();
        private DatabaseDumper? _dumper;
        private VulnerabilityDetails? _currentVulnerability;
        private CancellationTokenSource? _cancellationTokenSource;
        // UI Controls are defined in Designer.cs

        public DumperPage()
        {
            InitializeComponent();
            InitializeEventHandlers();
            InitializeTimer();
            treeDatabase.ImageList = CreateImageList();
        }

        private ImageList CreateImageList()
        {
            var images = new ImageList();
            try
            {
                // Use generic icons if resources are not available
                images.Images.Add("server", SystemIcons.Application.ToBitmap());
                images.Images.Add("database", SystemIcons.Application.ToBitmap());
                images.Images.Add("table", SystemIcons.Application.ToBitmap());
                images.Images.Add("column", SystemIcons.Application.ToBitmap());
            }
            catch
            {
                // Fallback to simple icon list
                images.Images.Add("server", new Bitmap(16, 16));
                images.Images.Add("database", new Bitmap(16, 16));
                images.Images.Add("table", new Bitmap(16, 16));
                images.Images.Add("column", new Bitmap(16, 16));
            }
            return images;
        }

        private void InitializeEventHandlers()
        {
            btnStart.Click += BtnStart_Click;
            btnStop.Click += BtnStop_Click;
            btnSave.Click += BtnSave_Click;
            btnLoad.Click += BtnLoad_Click;
            treeDatabase.AfterSelect += TreeDatabase_AfterSelect;
            btnDumpSelected.Click += BtnDumpSelected_Click;
            btnDumpAll.Click += BtnDumpAll_Click;
        }

        private void InitializeTimer()
        {
            _progressTimer.Interval = 1000;
            _progressTimer.Tick += (s, e) => UpdateProgress();
        }

        public void SetVulnerability(VulnerabilityDetails vulnerability)
        {
            _currentVulnerability = vulnerability;
            if (_currentVulnerability != null)
            {
                var config = new SqlInjectionConfig
                {
                    MaxThreads = _maxThreads,
                    RequestTimeout = 30
                };
                
                _dumper = new DatabaseDumper(_httpClient, _currentVulnerability, config);
                LogMessage($"Vulnerability set: {_currentVulnerability.VulnerabilityType} on {_currentVulnerability.InjectionPoint.Name}");
            }
        }

        public void SetVulnerability(TestResult testResult)
        {
            if (testResult == null) return;
            
            // Convert TestResult to VulnerabilityDetails
            var vulnerability = new VulnerabilityDetails
            {
                VulnerabilityType = testResult.DetectionMethod,
                InjectionPoint = new InjectionPoint
                {
                    Name = testResult.Url,
                    Type = InjectionPointType.UrlParameter
                },
                Payload = testResult.Payload,
                ResponseTime = TimeSpan.FromMilliseconds(testResult.ResponseTime),
                ResponseCode = testResult.ResponseCode,
                DetectionMethod = testResult.DetectionMethod,
                Confidence = testResult.Confidence,
                DatabaseType = testResult.DatabaseType,
                Evidence = testResult.Evidence,
                Response = testResult.Response
            };

            SetVulnerability(vulnerability);
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            if (_isDumping || _currentVulnerability == null)
            {
                MessageBox.Show("Please select a vulnerability from the Tester page first");
                return;
            }

            _isDumping = true;
            _cancellationTokenSource = new CancellationTokenSource();
            SetControlsEnabled(false);
            btnStop.Enabled = true;
            _progressTimer.Start();

            try
            {
                LogMessage("Starting database enumeration...");
                _database = await _dumper.DumpDatabaseAsync(_cancellationTokenSource.Token);
                PopulateDatabaseTree();
                LogMessage("Database enumeration completed successfully");
            }
            catch (OperationCanceledException)
            {
                LogMessage("Database enumeration was cancelled");
            }
            catch (Exception ex)
            {
                LogMessage($"Error during database enumeration: {ex.Message}");
                MessageBox.Show($"Database enumeration failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isDumping = false;
                _progressTimer.Stop();
                SetControlsEnabled(true);
                btnStop.Enabled = false;
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            _isDumping = false;
            btnStop.Enabled = false;
            LogMessage("Database enumeration stopped by user");
        }

        private void PopulateDatabaseTree()
        {
            treeDatabase.Nodes.Clear();
            
            if (_database == null) return;

            var serverNode = new TreeNode($"Server ({_database.DatabaseType})")
            {
                ImageKey = "server",
                SelectedImageKey = "server"
            };

            var databaseNode = new TreeNode($"Database: {_database.DatabaseName}")
            {
                ImageKey = "database",
                SelectedImageKey = "database"
            };

            foreach (var table in _database.Tables)
            {
                var tableNode = new TreeNode($"Table: {table.Name} ({table.RowCount} rows)")
                {
                    ImageKey = "table",
                    SelectedImageKey = "table",
                    Tag = table
                };

                foreach (var column in table.Columns)
                {
                    var columnNode = new TreeNode($"{column.Name} ({column.DataType})")
                    {
                        ImageKey = "column",
                        SelectedImageKey = "column",
                        Tag = column
                    };
                    tableNode.Nodes.Add(columnNode);
                }

                databaseNode.Nodes.Add(tableNode);
            }

            serverNode.Nodes.Add(databaseNode);
            treeDatabase.Nodes.Add(serverNode);
            treeDatabase.ExpandAll();
        }

        private void TreeDatabase_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is DatabaseTable table)
            {
                DisplayTableData(table);
            }
        }

        private void DisplayTableData(DatabaseTable table)
        {
            try
            {
                var dataTable = new DataTable();
                
                // Add columns
                foreach (var column in table.Columns)
                {
                    dataTable.Columns.Add(column.Name, typeof(string));
                }

                // Add rows
                foreach (var row in table.Data)
                {
                    var dataRow = dataTable.NewRow();
                    foreach (var column in table.Columns)
                    {
                        if (row.ContainsKey(column.Name))
                        {
                            dataRow[column.Name] = row[column.Name]?.ToString() ?? "";
                        }
                    }
                    dataTable.Rows.Add(dataRow);
                }

                // Display in data grid (using txtData as display area)
                if (txtData != null)
                {
                    var sb = new StringBuilder();
                    foreach (var column in table.Columns)
                    {
                        sb.Append(column.Name + "\t");
                    }
                    sb.AppendLine();
                    
                    foreach (var row in table.Data)
                    {
                        foreach (var column in table.Columns)
                        {
                            if (row.ContainsKey(column.Name))
                            {
                                sb.Append(row[column.Name]?.ToString() + "\t");
                            }
                        }
                        sb.AppendLine();
                    }
                    
                    txtData.Text = sb.ToString();
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error displaying table data: {ex.Message}");
            }
        }

        private async void BtnDumpSelected_Click(object sender, EventArgs e)
        {
            if (treeDatabase.SelectedNode?.Tag is DatabaseTable table)
            {
                await DumpTableAsync(table);
            }
            else
            {
                MessageBox.Show("Please select a table to dump");
            }
        }

        private async void BtnDumpAll_Click(object sender, EventArgs e)
        {
            if (_database?.Tables == null || _database.Tables.Count == 0)
            {
                MessageBox.Show("No tables to dump");
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to dump all {_database.Tables.Count} tables?", 
                "Confirm Dump All", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                foreach (var table in _database.Tables)
                {
                    await DumpTableAsync(table);
                }
            }
        }

        private async Task DumpTableAsync(DatabaseTable table)
        {
            if (_dumper == null) return;

            try
            {
                LogMessage($"Dumping table: {table.Name}");
                var result = await _dumper.DumpTableAsync(table.Name);
                
                if (result.IsComplete)
                {
                    LogMessage($"Table {table.Name} dumped successfully: {result.ExtractedRows} rows");
                    table.Data = result.Data;
                    DisplayTableData(table);
                }
                else
                {
                    LogMessage($"Table {table.Name} partially dumped: {result.ExtractedRows}/{result.TotalRows} rows");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error dumping table {table.Name}: {ex.Message}");
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (_database == null || _database.Tables?.Count == 0)
            {
                MessageBox.Show("No data to save");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "JSON Files|*.json|CSV Files|*.csv|XML Files|*.xml|SQL Files|*.sql";
                sfd.FileName = $"database_dump_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var extension = Path.GetExtension(sfd.FileName).ToLower();
                        var format = extension switch
                        {
                            ".json" => "json",
                            ".csv" => "csv",
                            ".xml" => "xml",
                            ".sql" => "sql",
                            _ => "json"
                        };

                        if (_dumper != null)
                        {
                            await _dumper.ExportDataAsync(format, sfd.FileName);
                            MessageBox.Show($"Database dump saved to {sfd.FileName}", "Save Successful", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", "Save Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "JSON Files|*.json|All Files|*.*";
                ofd.FileName = "database_dump.json";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var json = File.ReadAllText(ofd.FileName);
                        _database = System.Text.Json.JsonSerializer.Deserialize<DatabaseStructure>(json);
                        PopulateDatabaseTree();
                        MessageBox.Show($"Database dump loaded from {ofd.FileName}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading file: {ex.Message}");
                    }
                }
            }
        }

        private void SetControlsEnabled(bool enabled)
        {
            btnStart.Enabled = enabled;
            btnSave.Enabled = enabled;
            btnLoad.Enabled = enabled;
            btnDumpSelected.Enabled = enabled;
            btnDumpAll.Enabled = enabled;
        }

        private void UpdateProgress()
        {
            if (_isDumping)
            {
                lblStatus.Text = $"Dumping database... Tables: {_database?.Tables?.Count ?? 0}";
            }
            else
            {
                lblStatus.Text = $"Ready. Database: {_database?.DatabaseName ?? "None"}, Tables: {_database?.Tables?.Count ?? 0}";
            }
        }

        protected override void LogMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogMessage), message);
                return;
            }

            txtLogs.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\r\n");
            txtLogs.ScrollToCaret();
        }
    }
}