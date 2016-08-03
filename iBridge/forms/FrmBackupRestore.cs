using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace iBridge
{
    public partial class FrmBackupRestore : DevExpress.XtraEditors.XtraForm
    {
        public enum OpType
        {
            Backup,
            Restore,
        }
        
        public OpType OperationType;

        MySqlConnection conn;
        MySqlCommand cmd;

        MySqlBackup mbExport;
        MySqlBackup mbImport;

        Timer timerExport;
        Timer timerImport;

        BackgroundWorker bwExport;
        BackgroundWorker bwImport;

        string _currentTableName = "";
        int _totalRowsInCurrentTable = 0;
        int _totalRowsInAllTables = 0;
        int _currentRowIndexInCurrentTable = 0;
        int _currentRowIndexInAllTable = 0;
        int _totalTables = 0;
        int _currentTableIndex = 0;
        bool cancel = false;


        
        public FrmBackupRestore()
        {
            InitializeComponent();


            mbExport = new MySqlBackup();
            mbExport.ExportProgressChanged += mb_ExportProgressChanged;

            bwExport = new BackgroundWorker();
            bwExport.DoWork += bwExport_DoWork;
            bwExport.RunWorkerCompleted += bwExport_RunWorkerCompleted;

            //bwImport = new BackgroundWorker();
            //bwImport.DoWork += bwExport_DoWork;
            //bwImport.RunWorkerCompleted += bwImport_RunWorkerCompleted;

            timerExport = new Timer();
            timerExport.Interval = 100; // Refresh Progress Bar 10 times in 1 second
            timerExport.Tick += new EventHandler(timerExport_Tick);


            //timerImport = new Timer();
            //timerImport.Interval = 100; // Refresh Progress Bar 10 times in 1 second
            //timerImport.Tick += new EventHandler(timerImport_Tick);

            openFileDialog1.SupportMultiDottedExtensions = false;
            openFileDialog1.Title = "Restore From";
            openFileDialog1.Filter = "SQL Files (.sql)|*.sql";

            saveFileDialog1.SupportMultiDottedExtensions = false;
            saveFileDialog1.Title = "Backup To";
            saveFileDialog1.Filter = "SQL Files (.sql)|*.sql";
            saveFileDialog1.DefaultExt = "sql";


        }


        void timerExport_Tick(object sender, EventArgs e)
        {
            if (cancel)
            {
                timerExport.Stop();
                return;
            }

            pbTable.Maximum = _totalTables;
            if (_currentTableIndex <= pbTable.Maximum)
                pbTable.Value = _currentTableIndex;

            pbRowInCurTable.Maximum = _totalRowsInCurrentTable;
            if (_currentRowIndexInCurrentTable <= pbRowInCurTable.Maximum)
                pbRowInCurTable.Value = _currentRowIndexInCurrentTable;

            pbRowInAllTable.Maximum = _totalRowsInAllTables;
            if (_currentRowIndexInAllTable <= pbRowInAllTable.Maximum)
                pbRowInAllTable.Value = _currentRowIndexInAllTable;

            lbCurrentTableName.Text = "Current Processing Table = " + _currentTableName;
            lbRowInCurTable.Text = pbRowInCurTable.Value + " of " + pbRowInCurTable.Maximum;
            lbRowInAllTable.Text = pbRowInAllTable.Value + " of " + pbRowInAllTable.Maximum;
            lbTableCount.Text = _currentTableIndex + " of " + _totalTables;
        }

        private void FrmBackupRestore_Load(object sender, EventArgs e)
        {
            
            if (OperationType == OpType.Backup)
            {
                btnOperation.Text = "&Backup";
                lblFile.Text = "Backup To :";
                
            }
            else
            { 
                btnOperation.Text = "&Restore";
                lblFile.Text = "Restore From :";
               
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (OperationType == OpType.Backup)
            {
                

                saveFileDialog1.ShowDialog();

            }
            else
            {
                openFileDialog1.ShowDialog();
            }
        
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtFileName.Text = openFileDialog1.FileName;
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtFileName.Text = saveFileDialog1.FileName;
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            btnOperation.Enabled = false;
            btnBrowse.Enabled = false;
            pbRowInAllTable.Value = 0;
            pbRowInCurTable.Value = 0;
            pbTable.Value = 0;
            // Set cursor as hourglass
            Cursor.Current = Cursors.WaitCursor;
            
            if (OperationType == OpType.Backup)
            {
                Backup();
            }
            else
            {
                Restore();
            }

            btnBrowse.Enabled = true;
            btnOperation.Enabled = true;
            // Set cursor as hourglass
            Cursor.Current = Cursors.Default;
        }

        private void Backup()
        {
            //check the filename
            if(string.IsNullOrEmpty(txtFileName.Text.Trim()))
            {

                MessageBox.Show("Please Provide a filename to save","error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            _currentTableName = "";
            _totalRowsInCurrentTable = 0;
            _totalRowsInAllTables = 0;
            _currentRowIndexInCurrentTable = 0;
            _currentRowIndexInAllTable = 0;
            _totalTables = 0;
            _currentTableIndex = 0;


            string constring = Globals.ConnectionString;

            // Initialize MySqlConnection and MySqlCommand components
            conn = new MySqlConnection(constring);
            cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();

            // Start the Timer here
            timerExport.Start();

            mbExport.ExportInfo.AddCreateDatabase = true;
            mbExport.ExportInfo.ExportTableStructure = true;
            mbExport.ExportInfo.ExportRows = true;
            mbExport.ExportInfo.ExportFunctions = true;
            mbExport.ExportInfo.ExportProcedures = true;
            mbExport.ExportInfo.ExportViews = true;
            mbExport.ExportInfo.EnableEncryption = true;
            mbExport.ExportInfo.EncryptionPassword = "iBridge";
            mbExport.ExportInfo.RowsExportMode = RowsDataExportMode.Replace;
                        
            // Start the Timer here
            timerExport.Start();

            mbExport.ExportInfo.IntervalForProgressReport = 50;

            // This option is required for progress report.
            mbExport.ExportInfo.GetTotalRowsBeforeExport = true;
            // However, it might takes some times to retrieve the total rows if
            // your database contains thousands millions of rows.

            mbExport.Command = cmd;

            bwExport.RunWorkerAsync();
                        
              
        }

        void mb_ExportProgressChanged(object sender, ExportProgressArgs e)
        {
            if (cancel)
            {
                // Calling mb to halt
                mbExport.StopAllProcess();
                return;
            }

            _currentRowIndexInAllTable = (int)e.CurrentRowIndexInAllTables;
            _currentRowIndexInCurrentTable = (int)e.CurrentRowIndexInCurrentTable;
            _currentTableIndex = e.CurrentTableIndex;
            _currentTableName = e.CurrentTableName;
            _totalRowsInAllTables = (int)e.TotalRowsInAllTables;
            _totalRowsInCurrentTable = (int)e.TotalRowsInCurrentTable;
            _totalTables = e.TotalTables;
        }

        void bwExport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CloseConnection();

            if (cancel)
            {
                MessageBox.Show("Cancel by user.");
            }
            else
            {
                if (mbExport.LastError == null)
                {
                    pbRowInAllTable.Value = pbRowInAllTable.Maximum;
                    pbRowInCurTable.Value = pbRowInCurTable.Maximum;
                    pbTable.Value = pbTable.Maximum;
                    this.Refresh();
                    MessageBox.Show("Completed.");
                }
                else
                    MessageBox.Show("Completed with error(s)." + Environment.NewLine + Environment.NewLine + mbExport.LastError.ToString());
            }

            timerExport.Stop();
        }


        private void Restore()
        {
            //check the filename
            if (string.IsNullOrEmpty(txtFileName.Text.Trim()))
            {
                MessageBox.Show("Please Provide a filename to save", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _currentTableName = "";
            _totalRowsInCurrentTable = 0;
            _totalRowsInAllTables = 0;
            _currentRowIndexInCurrentTable = 0;
            _currentRowIndexInAllTable = 0;
            _totalTables = 0;
            _currentTableIndex = 0;
        }

        void bwExport_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string tpath = Path.Combine(txtFileName.Text.Trim());
                mbExport.ExportToFile(tpath);
            }
            catch (Exception ex)
            {
                cancel = true;
                CloseConnection();
                MessageBox.Show(ex.ToString());
            }
        }

        void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }

            if (cmd != null)
                cmd.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancel = true;
        }
    }

    

}