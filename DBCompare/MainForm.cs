

#region using statements

using System.Collections.Generic;
using DataJuggler.UltimateHelper;
using DataJuggler.UltimateHelper.Objects;
using DataJuggler.NET.Data;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using DBCompare.Enumerations;
using DBCompare.Security;
using DBCompare.Xml.Parsers;
using DBCompare.Xml.Writers;
using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBCompare.Util;
using System.Linq;
using System.Runtime.Versioning;
using System.Diagnostics;

#endregion

namespace DBCompare
{

    #region class MainForm
    /// <summary>
    /// This class is the MainForm for this application.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public partial class MainForm : Form, ICheckChangedListener
    {

        #region Private Variables
        private SecureUserData settings;
        private CompareInfo compareInfo;
        private SchemaComparison comparison;
        private List<string> ignoreItems;
        private const string XmlFilter = "XML files (*.xml)|*.xml";
        private const string YouTubePath = "https://youtu.be/13HipAOyAqU";
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a MainForm object.
        /// </summary>
        public MainForm()
        {
            // Create controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

        #region BuildSourceConnectionStringButton_Click(object sender, EventArgs e)
        /// <summary>
        /// This event launches the ConnectionStringForm
        /// </summary>
        private void BuildSourceConnectionStringButton_Click(object sender, EventArgs e)
        {
            // If the CompareInfo object exists
            if ((HasCompareInfo) && (this.HasSettings))
            {
                // if the CompareType is CompareTwoSQLDatabases or CreateXmlFile
                if ((CompareInfo.CompareType == CompareTypeEnum.CompareTwoSQLDatabases) || (CompareInfo.CompareType == CompareTypeEnum.CreateXmlFile))
                {
                    // Create an instance of the ConnectionStringBuilderForm
                    ConnectionStringBuilderForm connectionForm = new ConnectionStringBuilderForm();

                    // Show the form
                    connectionForm.ShowDialog();

                    // if the user did not cancel
                    if (!connectionForm.UserCancelled)
                    {
                        // Set the SourceConnectionStringControl
                        this.SourceConnectionStringControl.Text = connectionForm.ConnectionString;
                    }
                }
                else if (CompareInfo.CompareType == CompareTypeEnum.CompareXmlFileAndSQLDatabase)
                {
                    // Choose the file
                    DialogHelper.ChooseFile(this.SourceConnectionStringControl.GetTextBox(), XmlFilter, this.Settings.SourceXmlFilePath);
                }
            }
        }
        #endregion

        #region BuildTargetConnectionStringButton_Click(object sender, EventArgs e)
        /// <summary>
        /// This event builds the target connection.
        /// </summary>
        private void BuildTargetConnectionStringButton_Click(object sender, EventArgs e)
        {
            // If the CompareInfo object exists and the Settings exist
            if ((HasCompareInfo) && (HasSettings))
            {
                // if the CompareType is CompareTwoSQLDatabases or CreateXmlFile
                if ((CompareInfo.CompareType == CompareTypeEnum.CompareTwoSQLDatabases) || (CompareInfo.CompareType == CompareTypeEnum.CompareXmlFileAndSQLDatabase))
                {
                    // Create an instance of the ConnectionStringBuilderForm
                    ConnectionStringBuilderForm connectionForm = new ConnectionStringBuilderForm();

                    // Show the form
                    connectionForm.ShowDialog();

                    // if the user did not cancel
                    if (!connectionForm.UserCancelled)
                    {
                        // Set the TargetConnectionStringControl
                        this.TargetConnectionStringControl.Text = connectionForm.ConnectionString;
                    }
                }
                else if (CompareInfo.CompareType == CompareTypeEnum.CompareXmlFileAndSQLDatabase)
                {
                    // local
                    string folderName = "";

                    // if the OutputXmlFilePath exists
                    if ((TextHelper.Exists(Settings.OutputXmlFilePath)) && (File.Exists(Settings.OutputXmlFilePath)))
                    {
                        // Crete the directory
                        FileInfo file = new FileInfo(Settings.OutputXmlFilePath);

                        // if the file exists
                        if (file.Exists)
                        {
                            // get the folderName
                            folderName = file.Directory.FullName;
                        }
                    }

                    // Choose the folder
                    DialogHelper.ChooseFolder(this.TargetConnectionStringControl.GetTextBox(), folderName);

                    // if a folder was selected
                    if (TargetConnectionStringControl.HasText)
                    {
                        // Add [Enter The File Name] to the choosen folder
                        this.TargetConnectionStringControl.Text += "[Enter The File Name].xml";
                    }
                }
            }
        }
        #endregion

        #region Button_MouseEnter(object sender, EventArgs e)
        /// <summary>
        /// This event is fired when Button _ Mouse Enter
        /// </summary>
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            // change the cursor to a hand
            this.Cursor = Cursors.Hand;
        }
        #endregion

        #region Button_MouseLeave(object sender, EventArgs e)
        /// <summary>
        /// This event is fired when Button _ Mouse Leave
        /// </summary>
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            // change the cursor back to a pointer
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region CompareDatabasesButton_Click(object sender, EventArgs e)
        /// <summary>
        /// This event is fired when the user clicks the CompareDatabases button.
        /// </summary>
        private async void CompareDatabasesButton_Click(object sender, EventArgs e)
        {
            // Remove the focus from this button
            this.HiddenButton.Focus();

            // Run the comparison async
            bool compare = await RunComparison();

            // hide in case something went wrong
            Graph.Visible = false;
        }
        #endregion

        #region CopiedTimer_Tick(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Copied Timer _ Tick
        /// </summary>
        private void CopiedTimer_Tick(object sender, EventArgs e)
        {
            // stop the timer
            CopiedTimer.Stop();

            // Hide the image
            CopiedImage.Visible = false;
            ExtraLabel.Visible = false;
            ScriptDropExtrasCheckbox.Visible = false;
        }
        #endregion

        #region CreateIfProcExists(string procedureName)
        /// <summary>
        /// This method creates the line that checks if a stored proc already exists
        /// </summary>
        /// <param name="procedureName"></param>
        /// <returns></returns>
        private static string CreateIfProcExists(string procedureName)
        {
            // Create StringBuilder
            StringBuilder sb = new StringBuilder();

            // Initialize String builder
            sb.Append("IF EXISTS (select * from syscomments where id = object_id ('");

            // Append Procure Name
            sb.Append(procedureName);

            // Append close single quote and closing braces
            sb.Append("'))");

            // return value
            return sb.ToString();
        }
        #endregion

        #region CreateXmlFileButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'CreateXmlFileButton' is clicked.
        /// </summary>
        private void CreateXmlFileButton_Click(object sender, EventArgs e)
        {
            // Create the XmlFile                
            CreateXmlFile();
        }
        #endregion

        #region GenerateScriptsButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'GenerateScriptsButton' is clicked.
        /// </summary>
        private void GenerateScriptsButton_Click(object sender, EventArgs e)
        {
            // Remove focus
            HiddenButton.Focus();
            Refresh();
            Application.DoEvents();

            // locals
            string message = "-- This script is meant to be a time saver. Review it before running, and use it only if it looks safe for your environment.";
            message += Environment.NewLine + "-- This tool is a work in progress. It scripts tables, fields, stored procedures, default value constraints,";
            message += Environment.NewLine + "-- indexes, check constraints and foreign keys.";
            message += Environment.NewLine + "-- Recreating indexes rebuilds them, which can take time and lock large tables. Recreated check constraints and";
            message += Environment.NewLine + "-- foreign keys use WITH CHECK, so existing rows that violate a constraint will cause that statement to fail.";
            message += Environment.NewLine + "-- By using this script, you acknowledge I am not responsible for any damage to your database.";
            message += Environment.NewLine + "-- Thank you for using DB Compare." + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
            StringBuilder sb = new StringBuilder(message);

            // if the Comparison object exists and has one or more differences
            if ((HasComparison) && (Comparison.HasSchemaDifferences) && (Comparison.HasSourceDatabase) && (Comparison.SourceDatabase.HasOneOrMoreTables))
            {
                // Get the tablesSQL
                string tablesSQL = GetUpdateTablesSQL();



                // Get the fieldsSQL
                string fieldsSQL = GetUpdateFieldsSQL();

                // get updated fields
                string storedProceduresSQL = GetUpdateStoredProceduresSQL();

                // Generate the sql for default value constraints not found
                string defaultValueConstraintsSQL = GetDefaultValueConstraintsSQL();

                // Generate Indexes (before foreign keys, since a composite foreign key needs its unique key to exist)
                string indexSQL = GenerateIndexSQL();

                // Generate Check Constraints
                string checkConstraintSQL = GenerateCheckConstraintSQL();

                // Generate Foreign Keys
                string foreignKeyConstraintSQL = GenerateForeignKeyConstraintSQL();

                // local
                string dropExtraAssetsSQL = "";

                // if checked
                if (ScriptDropExtrasCheckbox.Checked)
                {
                    // get the sql for the extra assets
                    dropExtraAssetsSQL = GenerateDropExtraAssetsSQL();
                }

                // Append each if they exist

                // If the tablesSQL string exists
                if (TextHelper.Exists(tablesSQL))
                {
                    // add the tablesSQL
                    sb.Append(tablesSQL);
                }

                // If the fieldsSQL string exists
                if (TextHelper.Exists(fieldsSQL))
                {
                    // add the fieldsSQL
                    sb.Append(fieldsSQL);
                }

                // If the storedProceduresSQL string exists
                if (TextHelper.Exists(storedProceduresSQL))
                {
                    // add the storedProceduresSQL  
                    sb.Append(storedProceduresSQL);
                }

                // If the defaultValueConstraintsSQL string exists
                if (TextHelper.Exists(defaultValueConstraintsSQL))
                {
                    // Add the defaultValueConstraintsSQL
                    sb.Append(defaultValueConstraintsSQL);
                }

                // If the indexSQL string exists
                if (TextHelper.Exists(indexSQL))
                {
                    // Add the indexSQL
                    sb.Append(indexSQL);
                }

                // If the checkConstraintSQL string exists
                if (TextHelper.Exists(checkConstraintSQL))
                {
                    // Add the checkConstraintSQL
                    sb.Append(checkConstraintSQL);
                }

                // If the foreignKeyConstraintSQL string exists
                if (TextHelper.Exists(foreignKeyConstraintSQL))
                {
                    // Add the foreignKeyConstraintSQL
                    sb.Append(foreignKeyConstraintSQL);
                }

                // If the dropExtraAssetsSQL string exists
                if (TextHelper.Exists(dropExtraAssetsSQL))
                {
                    // append the dropExtraAssetsSQL
                    sb.Append(dropExtraAssetsSQL);
                }
            }

            // get the sql
            string sql = sb.ToString();

            // if the sql exists
            if (TextHelper.Exists(sql))
            {
                // Copy to clipboard
                Clipboard.SetText(sql);

                // Show a message
                CopiedImage.Visible = true;

                // Force update
                Refresh();
                Application.DoEvents();

                // Now start the timer so the image goes away
                CopiedTimer.Start();
            }
            else
            {
                // Show a message
                MessageBoxHelper.ShowMessage("Something must have gone wrong.", "Oops");
            }
        }
        #endregion

        #region MainForm_Load(object sender, EventArgs e)
        /// <summary>
        /// This event is fired when Main Form _ Load
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Create the Settings objects
            this.Settings = new SecureUserData();

            // Display the settings
            DisplaySettings();
        }
        #endregion

        #region OnCheckChanged(LabelCheckBoxControl labelCheckBox, bool isChecked)
        /// <summary>
        /// This event is fired when a checkbox is checked or unchecked.
        /// </summary>
        /// <param name="labelCheckBox"></param>
        /// <param name="isChecked"></param>
        public void OnCheckChanged(LabelCheckBoxControl labelCheckBox, bool isChecked)
        {
            // If the CompareInfo object exists
            if (this.HasCompareInfo)
            {
                // only handle this event for the RemoteCompareCheckBox
                if (labelCheckBox.Name == "RemoteCompareCheckBox")
                {
                    // if checked
                    if (labelCheckBox.Checked)
                    {
                        // Set the CompareType
                        CompareInfo.CompareType = CompareTypeEnum.CompareXmlFileAndSQLDatabase;

                        // turn off Create Xml File until checked
                        CreateXmlFileCheckBox.Checked = false;
                    }
                    else
                    {
                        // Set the CompareType
                        this.CompareInfo.CompareType = CompareTypeEnum.CompareTwoSQLDatabases;
                    }
                }
                else if (labelCheckBox.Name == "CreateXmlFileCheckBox")
                {
                    // if checked
                    if (labelCheckBox.Checked)
                    {
                        // Set the CompareType
                        this.CompareInfo.CompareType = CompareTypeEnum.CreateXmlFile;
                    }
                    else
                    {
                        // Set the CompareType
                        this.CompareInfo.CompareType = CompareTypeEnum.CompareXmlFileAndSQLDatabase;
                    }
                }
            }

            // Control how the UI is setup
            UIControl();
        }
        #endregion

        #region ResultsTextBox_MouseClick(object sender, MouseEventArgs e)
        /// <summary>
        /// event is fired when Results Text Box _ Mouse Click
        /// </summary>
        private void ResultsTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = new Point(800, 600);

                // Show the items
                IgnoreDifferenceStrip.Show(this.ResultsTextBox, p, ToolStripDropDownDirection.Default);
            }
        }
        #endregion

        #region SwapButton_Click(object sender, EventArgs e)
        /// <summary>
        /// This event is fired when the 'SwapButton' is clicked.
        /// </summary>
        private void SwapButton_Click(object sender, EventArgs e)
        {
            // set the source and target values
            string source = this.SourceConnectionStringControl.Text;
            string target = this.TargetConnectionStringControl.Text;

            // now swap out the values
            this.SourceConnectionStringControl.Text = target;
            this.TargetConnectionStringControl.Text = source;

            // refresh
            this.Refresh();
        }
        #endregion

        #region WriteDeleteProcIfExists(string procedureName)
        /// <summary>
        /// This method writes the sql needed to check if
        /// a stored proc already exists, and if yes delete it.
        /// </summary>
        /// <param name="procedureName"></param>
        private static string CreateDeleteProcIfExistsSQL(string procedureName)
        {
            // initial value
            string sql = "";

            // Create a new instance of a 'StringBuilder' object.
            StringBuilder sb = new StringBuilder();

            // Write Comment Check if the procedure already exists
            sb.Append("-- Check if the procedure already exists");
            sb.Append(Environment.NewLine);

            // Get If Exists Line
            string ifExists = CreateIfProcExists(procedureName);

            // If Exists Line
            sb.Append(ifExists);

            // end the line
            sb.Append(Environment.NewLine);

            // add a blank line
            sb.Append(Environment.NewLine);

            // Increase Indent
            sb.Append(TextHelper.Indent(4));

            // Write Comment Procedure Does Exist, Drop First
            sb.Append("-- Procedure Does Exist, Drop First");

            // End the line
            sb.Append(Environment.NewLine);

            // add a blank line
            sb.Append(Environment.NewLine);

            // Increase Indent
            sb.Append(TextHelper.Indent(4));

            // Write Comment Execute Drop
            sb.Append("-- Execute Drop");

            // End the line
            sb.Append(Environment.NewLine);

            // Increase Indent
            sb.Append(TextHelper.Indent(4));

            // Write drop procedure line
            sb.Append("Drop Procedure " + procedureName);

            // End the line
            sb.Append(Environment.NewLine);

            // add a blank line
            sb.Append(Environment.NewLine);

            // Write Go
            sb.Append("GO");

            // add a blank line
            sb.Append(Environment.NewLine);

            // set the return value
            sql = sb.ToString();

            // return value
            return sql;
        }
        #endregion

        #region YouTubeButton_Click(object sender, EventArgs e)
        /// <summary>
        /// This event is fired when the 'YouTubeButton' is clicked.
        /// </summary>
        private void YouTubeButton_Click(object sender, EventArgs e)
        {
            // launch to YouTube
            ProcessStartInfo info = new ProcessStartInfo { FileName = YouTubePath, UseShellExecute = true };

            // launch
            System.Diagnostics.Process.Start(info);
        }
        #endregion

        #endregion

        #region Methods

        #region BuildAddDefaultSQL(string tableName, DefaultValueConstraint constraint)
        /// <summary>
        /// Builds the ADD CONSTRAINT ... DEFAULT ... FOR sql for the constraint given. Uses the Definition text
        /// when available; falls back to the numeric DefaultValue for older schemas without a Definition.
        /// </summary>
        private string BuildAddDefaultSQL(string tableName, DefaultValueConstraint constraint)
        {
            // initial value
            string sql = "";

            // local
            string definition = "";

            // if the constraint exists and has a column
            if ((NullHelper.Exists(constraint)) && (TextHelper.Exists(constraint.ColumnName)))
            {
                // prefer the raw definition, e.g. ((1)), (getdate()), ('Pending')
                if (TextHelper.Exists(constraint.Definition))
                {
                    definition = constraint.Definition;
                }
                else
                {
                    // older schema: numeric value only
                    definition = "(" + constraint.DefaultValue + ")";
                }

                // build the sql
                sql = "ALTER TABLE [" + tableName + "] ADD CONSTRAINT [" + constraint.ConstraintName + "] DEFAULT " + definition + " FOR [" + constraint.ColumnName + "]" + Environment.NewLine + "Go" + Environment.NewLine;
            }

            // return value
            return sql;
        }
        #endregion

        #region BuildCreateForeignKeySQL(SchemaDifference difference)
        /// <summary>
        /// Builds the ADD CONSTRAINT sql for a foreign key. Uses the full ForeignKeyConstraint when
        /// available (all columns, named, with cascade rules); falls back to the single Field if not.
        /// </summary>
        private string BuildCreateForeignKeySQL(SchemaDifference difference)
        {
            // initial value
            string sql = "";

            // locals
            ForeignKeyConstraint fk = difference.ForeignKey;
            string tableName = difference.Table.Name;
            List<ForeignKeyColumnPair> columns = null;
            string fieldList = "";
            string referencedList = "";

            // preferred: the full constraint
            if ((difference.HasForeignKey) && (ListHelper.HasOneOrMoreItems(fk.Columns)))
            {
                // columns in order
                columns = fk.Columns.OrderBy(x => x.Ordinal).ToList();

                // build the column lists
                fieldList = String.Join(", ", columns.Select(x => "[" + x.FieldName + "]"));
                referencedList = String.Join(", ", columns.Select(x => "[" + x.ReferencedColumn + "]"));

                // named constraint, all columns, validated against existing rows
                sql = "ALTER TABLE [" + tableName + "] WITH CHECK ADD CONSTRAINT [" + fk.Name + "] FOREIGN KEY (" + fieldList + ") REFERENCES [" + fk.ReferencedTable + "] (" + referencedList + ")";

                // cascade rules: NO_ACTION is the default, so only script the others (SET_NULL -> SET NULL)
                if ((TextHelper.Exists(fk.OnDelete)) && (!TextHelper.IsEqual(fk.OnDelete, "NO_ACTION")))
                {
                    sql += " ON DELETE " + fk.OnDelete.Replace("_", " ");
                }

                if ((TextHelper.Exists(fk.OnUpdate)) && (!TextHelper.IsEqual(fk.OnUpdate, "NO_ACTION")))
                {
                    sql += " ON UPDATE " + fk.OnUpdate.Replace("_", " ");
                }

                // add the batch separator
                sql += Environment.NewLine + "Go" + Environment.NewLine;
            }
            // fallback: the old single-field way, only if Field is actually set
            else if ((difference.HasField) && (TextHelper.Exists(difference.ReferenceTableName, difference.ReferenceColumnName)))
            {
                sql = "ALTER TABLE [" + tableName + "] ADD FOREIGN KEY ([" + difference.Field.FieldName + "]) REFERENCES [" + difference.ReferenceTableName + "] ([" + difference.ReferenceColumnName + "])" + Environment.NewLine + "Go" + Environment.NewLine;
            }

            // return value
            return sql;
        }
        #endregion

        #region BuildCreateIndexSQL(DataIndex index, string tableName, bool isConstraint)
        /// <summary>
        /// Builds the CREATE INDEX or ADD CONSTRAINT sql for the index given, including
        /// column order, sort direction, included columns and filter.
        /// </summary>
        private string BuildCreateIndexSQL(DataIndex index, string tableName, bool isConstraint)
        {
            // initial value
            string sql = "";

            // locals
            string clustered = index.TypeDescription.ToUpper();
            List<IndexColumn> keyColumns = index.Columns.Where(x => !x.IsIncludedColumn).OrderBy(x => x.Ordinal).ToList();
            List<IndexColumn> includedColumns = index.Columns.Where(x => x.IsIncludedColumn).ToList();
            string keyList = String.Join(", ", keyColumns.Select(x => "[" + x.FieldName + "] " + (x.IsDescendingKey ? "DESC" : "ASC")));

            // Primary Key or Unique Constraint
            if (isConstraint)
            {
                sql = "ALTER TABLE [" + tableName + "] ADD CONSTRAINT [" + index.Name + "] " + (index.IsPrimary ? "PRIMARY KEY" : "UNIQUE") + " " + clustered + " (" + keyList + ")";
            }
            else
            {
                sql = "CREATE " + (index.IsUnique ? "UNIQUE " : "") + clustered + " INDEX [" + index.Name + "] ON [" + tableName + "] (" + keyList + ")";

                // included columns
                if (includedColumns.Count > 0)
                {
                    sql += " INCLUDE (" + String.Join(", ", includedColumns.Select(x => "[" + x.FieldName + "]")) + ")";
                }

                // filter
                if ((index.HasFilter) && (TextHelper.Exists(index.FilterDefinition)))
                {
                    sql += " WHERE " + index.FilterDefinition;
                }
            }

            // add the batch separator
            sql += Environment.NewLine + "Go" + Environment.NewLine;

            // return value
            return sql;
        }
        #endregion

        #region CaptureCompareInfo()
        /// <summary>
        /// This method returns the Compare Info
        /// </summary>
        public void CaptureCompareInfo()
        {
            // If the CompareInfo object exists
            if (this.HasCompareInfo)
            {
                // if this is Comparing Two SQL Databases
                if (this.CompareInfo.CompareType == CompareTypeEnum.CompareTwoSQLDatabases)
                {
                    // Set the ConnectionStrings
                    this.CompareInfo.SourceDatabaseConnectionString = this.SourceConnectionStringControl.Text;
                    this.CompareInfo.TargetDatabaseConnectionString = this.TargetConnectionStringControl.Text;
                }
                else if (this.CompareInfo.CompareType == CompareTypeEnum.CompareXmlFileAndSQLDatabase)
                {
                    // Set the SourceXmlFilePath and the TargetDatabaseConnectionString
                    this.CompareInfo.SourceXmlFilePath = this.SourceConnectionStringControl.Text;
                    this.CompareInfo.TargetDatabaseConnectionString = this.TargetConnectionStringControl.Text;
                }
                else if (this.CompareInfo.CompareType == CompareTypeEnum.CreateXmlFile)
                {
                    // Set the SourceXmlFilePath and the 
                    this.CompareInfo.SourceDatabaseConnectionString = this.SourceConnectionStringControl.Text;
                    this.CompareInfo.OutputXmlFilePath = this.TargetConnectionStringControl.Text;
                }
            }
        }
        #endregion

        #region Clear()
        /// <summary>
        /// This method Clear
        /// </summary>
        private void Clear()
        {
            if (this.CompareInfo.CompareType == CompareTypeEnum.CompareTwoSQLDatabases)
            {
                // Clear the text box
                this.ResultsTextBox.Text = "Comparing Databases...";
            }
            else if (this.CompareInfo.CompareType == CompareTypeEnum.CompareXmlFileAndSQLDatabase)
            {
                // Clear the text box
                this.ResultsTextBox.Text = "Comparing Databases...";
            }
            else
            {
                // Clear the text box
                this.ResultsTextBox.Text = "Creating Xml File...";
            }

            // Display a count of zero
            this.CountLabel.Text = "Count: 0";

            // Refresh everything
            this.ResultsTextBox.Refresh();
            this.CountLabel.Refresh();
            this.Refresh();
            Application.DoEvents();
            this.Refresh();
        }
        #endregion

        #region CompareDatabases()
        /// <summary>
        /// This method loads the database schema and compares the two databases.
        /// </summary>
        private void CompareDatabases()
        {
            try
            {
                // clear the text
                this.Clear();

                // locals
                string message = "";
                string title = "Validation Failed";
                Database sourceDatabase = new Database();
                Database targetDatabase = new Database();
                SchemaComparison schemaComparison = new SchemaComparison();

                // Disable the button
                this.CompareDatabasesButton.Enabled = false;

                // Change the Cursor
                this.Cursor = Cursors.WaitCursor;

                // Hide
                GenerateScriptsButton.Visible = false;
                ExtraLabel.Visible = false;
                ScriptDropExtrasCheckbox.Visible = false;

                // Refresh the UI
                this.Refresh();

                // Set Focus to this button
                this.HiddenButton.Focus();

                // Capture the CompareInfo
                CaptureCompareInfo();

                // Save the current settings
                SaveSettings();

                // Is this valid
                bool validConnections = this.CompareInfo.IsValid();

                // if the validConnections
                if (validConnections)
                {
                    // Load the Schema for both databases
                    LoadDatabaseSchema(this.CompareInfo.SourceDatabaseConnector, ref sourceDatabase);
                    LoadDatabaseSchema(this.CompareInfo.TargetDatabaseConnector, ref targetDatabase);

                    // Compare the database structure
                    CompareDatabaseStructure(sourceDatabase, targetDatabase);

                    // Increment the CompareCount
                    this.Settings.CompareCount++;

                    // Save the Settings
                    this.Settings.Save();
                }
                else
                {
                    // Show a failed reason
                    message = this.CompareInfo.InvalidReason;

                    // Show the user a message
                    MessageBoxHelper.ShowMessage(message, title);
                }
            }
            catch (Exception error)
            {
                // for debugging only
                string err = error.ToString();

                // Show the error
                this.ResultsTextBox.Text = "An error occurred: " + Environment.NewLine + err;
            }
            finally
            {
                // Renable the button
                CompareDatabasesButton.Enabled = true;
                this.Cursor = Cursors.Default;
                this.Refresh();
            }
        }
        #endregion

        #region CreateFieldSQL(DataTable table, DataField field, bool addNew)
        /// <summary>
        /// returns the Field SQL
        /// </summary>
        public static string CreateFieldSQL(DataTable table, DataField field, bool addNew)
        {
            // initial value
            string sql = "";

            // Create a new instance of a 'StringBuilder' object.
            StringBuilder sb = new StringBuilder();

            // locals
            string adjustment = "Alter Column ";

            // fixing bug where table names like User or Sales Records do not work.
            sb.Append("Alter Table [");
            sb.Append(table.Name);
            sb.Append("]");
            sb.Append(Environment.NewLine);

            // if new
            if (addNew)
            {
                // Only difference is add or Al
                adjustment = "Add ";
            }

            // Append Alter or Add
            sb.Append(adjustment);

            // Update: Adding brackes around the field name for certain fields needed it (spaces, reserve words)
            sb.Append('[');
            sb.Append(field.DBFieldName);
            sb.Append(']');

            sb.Append(' ');
            sb.Append(field.DBDataType);

            // if a string
            if (field.DataType == DataManager.DataTypeEnum.String)
            {
                // append the size
                sb.Append('(');
                sb.Append(field.Size);
                sb.Append(')');
            }

            // not handlng identity columns here, because I just can't see that
            // being added as a column update. If an Identity column needs renaming
            // I am going to leave that as something you can do manual in SSMS for now.

            // if this field cannot be null
            if (!field.IsNullable)
            {
                // prepend the not before null
                sb.Append(" not");
            }

            // now add null
            sb.Append(" null");

            // Append a new line
            sb.Append(Environment.NewLine);

            // Append a Go
            sb.Append("Go");
            sb.Append(Environment.NewLine);

            sb.Append(Environment.NewLine);

            // set the return value
            sql = sb.ToString();

            // return value
            return sql;
        }
        #endregion

        #region CreateTableChildObjectsSQL(DataTable table)
        /// <summary>
        /// returns the SQL for a newly created table's default value constraints, check constraints,
        /// indexes and foreign keys (the primary key is already part of the CREATE TABLE).
        /// </summary>
        private string CreateTableChildObjectsSQL(DataTable table)
        {
            // initial value
            StringBuilder sb = new StringBuilder();

            // locals
            HashSet<string> scripted = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            string checkClause = "";

            // if the table exists
            if (NullHelper.Exists(table))
            {
                // default value constraints
                if (ListHelper.HasOneOrMoreItems(table.DefaultValueConstraints))
                {
                    foreach (DefaultValueConstraint defaultValueConstraint in table.DefaultValueConstraints)
                    {
                        sb.Append(BuildAddDefaultSQL(table.Name, defaultValueConstraint));
                    }
                }

                // check constraints (a multi-column check loads once per column, so script each name once)
                if (table.HasCheckConstraints)
                {
                    foreach (CheckConstraint checkConstraint in table.CheckConstraints)
                    {
                        // if this constraint name has not been scripted yet
                        if (scripted.Add(checkConstraint.ConstraintName))
                        {
                            // the expression
                            checkClause = XmlPatternHelper.Decode(checkConstraint.CheckClause);

                            // if it exists
                            if (TextHelper.Exists(checkClause))
                            {
                                sb.Append("ALTER TABLE [" + table.Name + "] WITH CHECK ADD CONSTRAINT [" + checkConstraint.ConstraintName + "] CHECK " + checkClause + Environment.NewLine + "Go" + Environment.NewLine);
                            }
                        }
                    }
                }

                // indexes, except the primary key (already in the CREATE TABLE)
                if (table.HasIndexes)
                {
                    foreach (DataIndex index in table.Indexes)
                    {
                        // if this is not the primary key, and it has columns
                        if ((!index.IsPrimary) && (ListHelper.HasOneOrMoreItems(index.Columns)))
                        {
                            // only clustered and nonclustered rowstore indexes are scripted
                            if ((TextHelper.IsEqual(index.TypeDescription, "CLUSTERED")) || (TextHelper.IsEqual(index.TypeDescription, "NONCLUSTERED")))
                            {
                                // unique constraints are scripted as constraints, everything else as indexes
                                sb.Append(BuildCreateIndexSQL(index, table.Name, index.IsUniqueConstraint));
                            }
                            else
                            {
                                sb.Append("-- Unable to script " + index.TypeDescription + " index [" + index.Name + "] on [" + table.Name + "]. Script this one manually." + Environment.NewLine);
                            }
                        }
                    }
                }

                // foreign keys
                if (ListHelper.HasOneOrMoreItems(table.ForeignKeys))
                {
                    foreach (ForeignKeyConstraint foreignKey in table.ForeignKeys)
                    {
                        // a temporary difference, so the existing builder can be reused
                        SchemaDifference tableForeignKey = new SchemaDifference();
                        tableForeignKey.Table = table;
                        tableForeignKey.ForeignKey = foreignKey;

                        // add the foreign key
                        sb.Append(BuildCreateForeignKeySQL(tableForeignKey));
                    }
                }
            }

            // return value
            return sb.ToString();
        }
        #endregion

        #region CreateTableSQL(DataTable table)
        /// <summary>
        /// Create Table SQL. Writes every field in table order (FieldOrdinal), then the primary key constraint,
        /// built from the table's primary key index (so single, composite, identity or not, clustered or
        /// nonclustered are all handled). Falls back to the fields marked PrimaryKey if no index information was loaded.
        /// </summary>
        public static string CreateTableSQL(DataTable table)
        {
            // initial value
            string sql = "";

            // locals
            StringBuilder sb = new StringBuilder();
            string newLine = Environment.NewLine;
            string go = "Go" + Environment.NewLine + newLine;
            string onPrimary = ") ON [PRIMARY]" + newLine + go;
            string ansiNulls = "SET ANSI_NULLS ON" + newLine + go;
            string quotedIdentifier = "SET QUOTED_IDENTIFIER ON" + newLine + go;
            List<string> lines = new List<string>();
            List<string> keyColumns = new List<string>();
            StringBuilder line = null;
            DataIndex primaryIndex = null;
            string sortDirection = "";

            // If the table object exists
            if (NullHelper.Exists(table))
            {
                // Is this a view?
                if (table.IsView)
                {
                    sb.Append("/****** Object:  View [dbo].[");
                }
                else
                {
                    sb.Append("/****** Object:  Table [dbo].[");
                }
                sb.Append(table.Name);
                sb.Append("]    Script Date: ");
                sb.Append(DateTime.Now);
                sb.Append(" ******/");
                sb.Append(newLine);

                // Now ANSI Nulls
                sb.Append(ansiNulls);
                sb.Append(quotedIdentifier);

                // Is this a view?
                if (table.IsView)
                {
                    // create the view
                    sb.Append("CREATE View [dbo].[");
                }
                else
                {
                    // create the table
                    sb.Append("CREATE TABLE [dbo].[");
                }
                sb.Append(table.Name);
                sb.Append("](");
                sb.Append(newLine);

                // if there are fields
                if (ListHelper.HasOneOrMoreItems(table.Fields))
                {
                    // write the fields in table order
                    List<DataField> orderedFields = table.Fields.OrderBy(x => x.FieldOrdinal).ToList();

                    // write every field, in order, including all primary key fields
                    foreach (DataField field in orderedFields)
                    {
                        // start this column line
                        line = new StringBuilder();

                        // Append 8 spaces then Column
                        line.Append(TextHelper.Indent(8));
                        line.Append('[');
                        line.Append(field.DBFieldName);
                        line.Append("] [");
                        line.Append(field.DBDataType);
                        line.Append(']');

                        // if string
                        if (field.DataType == DataManager.DataTypeEnum.String)
                        {
                            line.Append('(');

                            // max length columns report a size of -1
                            if (field.Size == -1)
                            {
                                line.Append("max");
                            }
                            else
                            {
                                line.Append(field.Size);
                            }

                            line.Append(')');
                        }

                        // if decimal or numeric, add the precision and scale, e.g. decimal(18,2)
                        if ((TextHelper.IsEqual(field.DBDataType, "decimal")) || (TextHelper.IsEqual(field.DBDataType, "numeric")))
                        {
                            line.Append('(');
                            line.Append(field.Precision);
                            line.Append(',');
                            line.Append(field.Scale);
                            line.Append(')');
                        }

                        // if identity
                        if (field.IsAutoIncrement)
                        {
                            line.Append(" IDENTITY(1,1)");
                        }

                        // primary key fields and identity fields can never be null
                        if ((field.IsNullable) && (!field.PrimaryKey) && (!field.IsAutoIncrement))
                        {
                            line.Append(" null");
                        }
                        else
                        {
                            line.Append(" not null");
                        }

                        // add this column
                        lines.Add(line.ToString());
                    }

                    // find the primary key index, if indexes were loaded
                    if (table.HasIndexes)
                    {
                        primaryIndex = table.Indexes.FirstOrDefault(x => x.IsPrimary);
                    }

                    // if the primary key index was found, build the constraint from its key columns (in key order)
                    if ((NullHelper.Exists(primaryIndex)) && (ListHelper.HasOneOrMoreItems(primaryIndex.Columns)))
                    {
                        // iterate the key columns, in key order
                        foreach (IndexColumn column in primaryIndex.Columns.Where(x => !x.IsIncludedColumn).OrderBy(x => x.Ordinal))
                        {
                            // set the sort direction
                            if (column.IsDescendingKey)
                            {
                                sortDirection = "DESC";
                            }
                            else
                            {
                                sortDirection = "ASC";
                            }

                            // add this key column
                            keyColumns.Add("[" + column.FieldName + "] " + sortDirection);
                        }

                        // add the constraint
                        lines.Add(TextHelper.Indent(8) + "CONSTRAINT [" + primaryIndex.Name + "] PRIMARY KEY " + primaryIndex.TypeDescription.ToUpper() + " (" + String.Join(", ", keyColumns) + ")");
                    }
                    else
                    {
                        // fallback: no index information, so use the fields marked as primary key, in table order
                        foreach (DataField field in orderedFields)
                        {
                            // if this field is part of the primary key
                            if (field.PrimaryKey)
                            {
                                // add this key column
                                keyColumns.Add("[" + field.DBFieldName + "] ASC");
                            }
                        }

                        // if there are any
                        if (keyColumns.Count > 0)
                        {
                            // add the constraint, using the conventional name
                            lines.Add(TextHelper.Indent(8) + "CONSTRAINT [PK_" + table.Name + "] PRIMARY KEY CLUSTERED (" + String.Join(", ", keyColumns) + ")");
                        }
                    }

                    // join every column and the constraint with commas, so the last line never has a trailing comma
                    sb.Append(String.Join("," + newLine, lines));
                    sb.Append(newLine);
                }

                // append the closing on primary
                sb.Append(onPrimary);

                // Extra Blank Line Separator
                sb.Append(newLine);

                // set the return value
                sql = sb.ToString();
            }

            // return value
            return sql;
        }
        #endregion

        #region CreateViewSQL(DataTable table)
        /// <summary>
        /// returns the View SQL
        /// </summary>
        public static string CreateViewSQL(DataTable table, bool alter = false)
        {
            // initial value
            string sql = "";

            // local
            bool replacementMade = false;

            // If the table object exists
            if ((NullHelper.Exists(table)) && (table.IsView))
            {
                // get the sql
                sql = table.ViewText;

                // If the sql string exists
                if (TextHelper.Exists(sql))
                {
                    // If this is an Alter not a create
                    if (alter)
                    {
                        // string.Replace is case sensitive, so did it this way, not most efficient
                        List<TextLine> lines = TextHelper.GetTextLines(sql);

                        // If the lines collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(lines))
                        {
                            // Iterate the collection of TextLine objects
                            foreach (TextLine line in lines)
                            {
                                // if this is the Create view statement
                                if (line.Text.ToLower().Contains("create view"))
                                {
                                    // set the text
                                    line.Text = line.Text.ToLower().Replace("create view", "ALTER VIEW");

                                    // change to alter
                                    replacementMade = true;
                                }
                            }

                            // if a replacement was made
                            if (replacementMade)
                            {
                                // get the sql updated
                                sql = TextHelper.ExportTextLines(lines);
                            }
                        }

                        // turn this into an Alter View
                        sql = sql.Replace("Create View", "Alter View");
                    }

                    // Each view must be in its own block
                    sql += Environment.NewLine;
                    sql += "Go";

                    // Add a new line twice
                    sql += Environment.NewLine;
                    sql += Environment.NewLine;
                }
            }

            // return value
            return sql;
        }
        #endregion

        #region CreateXmlFile()
        /// <summary>
        /// This method Create Xml File
        /// </summary>
        public void CreateXmlFile()
        {
            // clear the text
            this.Clear();

            // Capture the CompareInfo
            CaptureCompareInfo();

            // Remove the focus from this button
            this.HiddenButton.Focus();

            try
            {
                // Save the current settings
                SaveSettings();

                // Verify we have everything needed to create an XmlFile
                bool isValid = CompareInfo.IsValid();

                // If we have a valid connection
                if (isValid)
                {
                    // Create the sourceDatabase
                    Database sourceDatabase = new Database();

                    // Load the database schema
                    LoadDatabaseSchema(CompareInfo.SourceDatabaseConnector, ref sourceDatabase);

                    // Create the Xml File
                    DatabasesWriter writer = new DatabasesWriter();

                    // Create the xml file
                    string xml = writer.ExportDatabase(sourceDatabase);

                    // If the xml string exists
                    if (TextHelper.Exists(xml))
                    {
                        // if the Output Xml File Path
                        if (File.Exists(this.CompareInfo.OutputXmlFilePath))
                        {
                            // Delete the existing file
                            File.Delete(this.CompareInfo.OutputXmlFilePath);
                        }

                        // Write out the xml to a file
                        File.AppendAllText(this.CompareInfo.OutputXmlFilePath, xml);

                        // Show a message
                        this.ResultsTextBox.Text = "The file '" + this.CompareInfo.OutputXmlFilePath + "' was saved successfully";
                    }
                }
                else if (TextHelper.Exists(this.CompareInfo.InvalidReason))
                {
                    // Show the user a message
                    this.ResultsTextBox.Text = this.CompareInfo.InvalidReason;
                }
            }
            catch (Exception error)
            {
                // for debugging only
                string err = error.ToString();

                // Show the user a message
                MessageBoxHelper.ShowMessage("An error occurred creating the xml file", "Create Failed");
            }
        }
        #endregion

        #region DisplaySettings()
        /// <summary>
        /// This method Display the Settings
        /// </summary>
        private void DisplaySettings()
        {
            // if the settings object exist
            if (this.HasSettings)
            {
                // parse the CompareType
                CompareTypeEnum compareType = EnumHelper.GetEnumValue<CompareTypeEnum>(this.Settings.CompareType, CompareTypeEnum.CompareTwoSQLDatabases);

                // If the CompareType is CompareTwoSQLDatabases
                if (compareType == CompareTypeEnum.CompareTwoSQLDatabases)
                {
                    // if StoreConnectionStrings is true
                    if (this.Settings.StoreConnectionStrings)
                    {
                        // Display the Source ConnectionString
                        this.SourceConnectionStringControl.Text = Settings.SourceConnectionString;

                        // Display the Target ConnectionString
                        this.TargetConnectionStringControl.Text = Settings.TargetConnectionString;
                    }
                }
                else if (compareType == CompareTypeEnum.CompareXmlFileAndSQLDatabase)
                {
                    // if StoreConnectionStrings is true
                    if (this.Settings.StoreConnectionStrings)
                    {
                        // Display the Target ConnectionString
                        this.TargetConnectionStringControl.Text = Settings.TargetConnectionString;
                    }
                    else
                    {
                        // Display the Target ConnectionString
                        this.TargetConnectionStringControl.Text = null;
                    }

                    // Display the SourceXmlFilePath
                    this.SourceConnectionStringControl.Text = Settings.SourceXmlFilePath;
                }
                else if (compareType == CompareTypeEnum.CreateXmlFile)
                {
                    // if StoreConnectionStrings is true
                    if (this.Settings.StoreConnectionStrings)
                    {
                        // Display the Target ConnectionString
                        this.SourceConnectionStringControl.Text = Settings.SourceConnectionString;
                    }
                    else
                    {
                        // Display the Target ConnectionString
                        this.TargetConnectionStringControl.Text = null;
                    }

                    // Display the SourceXmlFilePath
                    this.TargetConnectionStringControl.Text = Settings.OutputXmlFilePath;
                }

                // Set the value for IgnoreDiagramProceduresCheckBox.Checked
                this.IgnoreDiagramProceduresCheckBox.Checked = Settings.IgnoreDiagramProcedures;
                this.IgnoreDataSyncCheckBox.Checked = Settings.IgnoreDataSync;
                this.IgnoreFirewallRulesCheckBox.Checked = Settings.IgnoreFirewallRules;

                // Set the value for StoreConnectionStringsCheckBox
                this.StoreConnectionStringsCheckBox.Checked = true;

                // Set the value for 
                this.RemoteCompareCheckBox.Checked = Settings.RemoteComparison;
                this.CreateXmlFileCheckBox.Checked = Settings.CreateXmlFile;
            }

            // Control the UI
            UIControl();
        }
        #endregion

        #region CompareDatabaseStructure(Database sourceDatabase, Database targetDatabase)
        /// <summary>
        /// This method does the actual comparison; it is called by the RemoteCompare and the normal comparison
        /// </summary>
        private void CompareDatabaseStructure(Database sourceDatabase, Database targetDatabase)
        {
            // local
            SchemaComparison schemaComparison = new SchemaComparison();

            // verify both objects exist
            if (NullHelper.Exists(sourceDatabase, targetDatabase))
            {
                // test if any data was loaded before showing 'The target database is up to date message incorrectly'
                if (sourceDatabase.Tables.Count > 0)
                {
                    // Get the value for IgnoreDiagramProcedures
                    bool ignoreDiagramProcedures = this.IgnoreDiagramProceduresCheckBox.Checked;
                    bool ignoreIndexes = this.IgnoreIndexesCheckBox.Checked;

                    // Create a new database comparer
                    DatabaseComparer comparer = new DatabaseComparer(sourceDatabase, targetDatabase, ignoreDiagramProcedures, ignoreIndexes, UpdateStatus);

                    // Compare the two database schemas
                    schemaComparison = comparer.Compare();
                }
                else
                {
                    // Create a SchemaDifference
                    SchemaDifference schemaDifference = new SchemaDifference();

                    // Set the DifferenceType
                    schemaDifference.DifferenceType = DifferenceTypeEnum.SourceDatabaseContainsNoTables;

                    // Set the Message
                    schemaDifference.Message = "The source database does not contain any tables; the comparison cannot continue.";

                    // Add this as a message
                    schemaComparison.SchemaDifferences.Add(schemaDifference);
                }

                // compare the two schemas
                if (schemaComparison != null)
                {
                    // Store the Comparison. Needed for the Generate Scripts
                    Comparison = schemaComparison;

                    // Store the sourceDatabase
                    Comparison.SourceDatabase = sourceDatabase;
                    Comparison.TargetDatabase = targetDatabase;

                    // if the two database are equal
                    if (schemaComparison.IsEqual)
                    {
                        // Show the two databases are equal
                        this.ResultsTextBox.Text = "The target database is up to date.";
                    }
                    else
                    {
                        // Display the count
                        this.CountLabel.Text = "Count: " + schemaComparison.SchemaDifferences.Count;
                        this.CountLabel.Visible = true;

                        // Create a string builder
                        StringBuilder sb = new StringBuilder("The target database is not valid.");

                        // Append a new line
                        sb.Append(Environment.NewLine);

                        // iterate the errors
                        foreach (SchemaDifference schemaDifference in schemaComparison.SchemaDifferences)
                        {
                            // Append an indention
                            sb.Append("    ");
                            sb.Append(schemaDifference.Message);
                            sb.Append(Environment.NewLine);
                        }

                        // Show the schema differences
                        this.ResultsTextBox.Text = sb.ToString();

                        // Show the button
                        GenerateScriptsButton.Visible = true;
                        ExtraLabel.Visible = true;
                        ScriptDropExtrasCheckbox.Visible = true;
                    }
                }
            }
            else if (NullHelper.IsNull(sourceDatabase))
            {
                // Show the user a message
                this.ResultsTextBox.Text = "The source database could not be loaded.";
            }
            else if (NullHelper.IsNull(targetDatabase))
            {
                // Show the user a message
                this.ResultsTextBox.Text = "The target database could not be loaded.";
            }
        }
        #endregion

        #region FixReserveWordsInSelect(string storedProcedureText)
        /// <summary>
        /// returns the Reserve Words In Select
        /// </summary>
        public static string FixReserveWordsInSelect(string storedProcedureText)
        {
            // locals
            char[] delimiters = new char[] { ',' };
            int index = -1;
            int lineNumber = 0;
            int targetLineNumber = 0;
            int fieldCount = -1;
            bool updateRequired = false;
            StringBuilder sb = null;

            // If the storedProcedureText string exists
            if (TextHelper.Exists(storedProcedureText))
            {
                // get the text lines
                List<TextLine> lines = TextHelper.GetTextLines(storedProcedureText);

                // If the lines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(lines))
                {
                    // Iterate the collection of TextLine objects
                    foreach (TextLine line in lines)
                    {
                        // Increment the value for lineNumber
                        lineNumber++;

                        // Set the lineNumber
                        line.LineNumber = lineNumber;

                        // get the index of SQL comments
                        index = line.Text.IndexOf("--");

                        // if the line is not a SQL Comment
                        if (index < 0)
                        {
                            // if this is a select line
                            if (line.Text.Trim().StartsWith("Select"))
                            {
                                // might be needed
                                targetLineNumber = lineNumber;

                                // get the words for this line
                                List<Word> words = TextHelper.GetWords(line.Text);

                                // iterate the words
                                if (ListHelper.HasOneOrMoreItems(words))
                                {
                                    // Iterate the collection of Word objects
                                    foreach (Word word in words)
                                    {
                                        // Increment the value for fieldCount
                                        fieldCount++;

                                        // if this is after Select
                                        if (fieldCount > 0)
                                        {
                                            // verify this is not already surrounded by a bracket
                                            if (!word.Text.StartsWith("["))
                                            {
                                                // Change the word text
                                                word.Text = "[" + word.Text + "]";

                                                // Text was changed
                                                updateRequired = true;
                                            }
                                        }
                                    }

                                    // reset
                                    fieldCount = 0;

                                    // Now rebuild this line
                                    int indent = TextHelper.GetSpacesCount(line.Text);
                                    string tab = TextHelper.Indent(indent);
                                    sb = new StringBuilder(tab);

                                    // Iterate the collection of Word objects
                                    foreach (Word word in words)
                                    {
                                        // Increment the value for fieldCount
                                        fieldCount++;

                                        // append this word
                                        sb.Append(word.Text);

                                        // if not the last word
                                        if ((fieldCount > 1) && (fieldCount < words.Count))
                                        {
                                            // add the comma
                                            sb.Append(", ");
                                        }
                                        else if (fieldCount == 1)
                                        {
                                            // add a space
                                            sb.Append(' ');
                                        }
                                    }

                                    // Get the new text
                                    string newLineText = sb.ToString();

                                    // update the text
                                    line.Text = newLineText;
                                }
                            }
                        }
                    }

                    // if the value for updateRequired is true
                    if (updateRequired)
                    {
                        // recreate
                        sb = new StringBuilder();

                        // Iterate the collection of TextLine objects
                        foreach (TextLine line in lines)
                        {
                            // Add this line
                            sb.Append(line.Text);
                            sb.Append(Environment.NewLine);
                        }

                        // set the return value
                        storedProcedureText = sb.ToString();
                    }
                }
            }

            // return value
            return storedProcedureText;
        }
        #endregion

        #region GenerateDropExtraAssetsSQL()
        /// <summary>
        /// returns the Drop Extra Assets SQL
        /// </summary>
        public string GenerateDropExtraAssetsSQL()
        {
            // initial value
            string dropExtraAssetsSQL = "";

            // local
            string sql = "";

            // Create a new instance of a 'StringBuilder' object.
            StringBuilder sb = new StringBuilder(Environment.NewLine);

            // iterate the differences
            foreach (SchemaDifference difference in Comparison.SchemaDifferences)
            {
                switch (difference.DifferenceType)
                {
                    case DifferenceTypeEnum.TargetDatabaseContainsExtraField:

                        // both are required to generate the drop SQL
                        if ((difference.HasTable) && (difference.HasField))
                        {
                            // Get the sql for the drop
                            sql = "Alter Table " + difference.Table.Name + Environment.NewLine + "Drop Column " + difference.Field.FieldName;
                            sb.Append(sql);
                            sb.Append(Environment.NewLine);
                            sb.Append("GO");
                            sb.Append(Environment.NewLine);
                            // Add a blank line
                            sb.Append(Environment.NewLine);
                        }

                        // required
                        break;

                    case DifferenceTypeEnum.TargetDatabaseContainsExtraProcedure:

                        // if the procedure exists
                        if (difference.HasProcedure)
                        {
                            // Create the drop sql
                            sql = "Drop Procedure " + difference.Procedure.ProcedureName;
                            sb.Append(sql);
                            sb.Append(Environment.NewLine);
                            sb.Append("GO");
                            sb.Append(Environment.NewLine);
                            // Add a blank line
                            sb.Append(Environment.NewLine);
                        }

                        // required
                        break;

                    case DifferenceTypeEnum.TargetDatabaseContainsExtraTable:

                        // If the value for the property difference.HasTable is true
                        if (difference.HasTable)
                        {
                            // if a view
                            if (difference.Table.IsView)
                            {
                                // Create the drop sql
                                sql = "Drop View " + difference.Procedure.ProcedureName;
                            }
                            else
                            {
                                // Create the drop sql
                                sql = "Drop Table " + difference.Procedure.ProcedureName;
                            }

                            sb.Append(sql);
                            sb.Append(Environment.NewLine);
                            sb.Append("GO");
                            sb.Append(Environment.NewLine);
                            // Add a blank line
                            sb.Append(Environment.NewLine);
                        }

                        // required
                        break;
                }
            }

            // Get the drop sql
            dropExtraAssetsSQL = sb.ToString();

            // return value
            return dropExtraAssetsSQL;
        }
        #endregion

        #region GenerateCheckConstraintSQL()
        /// <summary>
        /// returns the Check Constraint SQL. Missing check constraints are added; invalid ones are
        /// dropped and re-added with the source expression. A check that references more than one
        /// column loads as one row per column, so each constraint name is only scripted once.
        /// </summary>
        public string GenerateCheckConstraintSQL()
        {
            // initial value
            StringBuilder sb = new StringBuilder();

            // locals
            HashSet<string> scripted = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            CheckConstraint checkConstraint = null;
            string tableName = "";
            string checkClause = "";

            // if the Comparison.SchemaDifferences exists
            if ((HasComparison) && (Comparison.HasSchemaDifferences))
            {
                // iterate the SchemaDifferences
                foreach (SchemaDifference difference in Comparison.SchemaDifferences)
                {
                    // only check constraint differences are handled here
                    if ((difference.DifferenceType != DifferenceTypeEnum.CheckConstraintNotFound) && (difference.DifferenceType != DifferenceTypeEnum.CheckConstraintNotValid))
                    {
                        continue;
                    }

                    // must have the table and the source check constraint to script it
                    if ((!difference.HasTable) || (!difference.HasCheckConstraint))
                    {
                        sb.Append("-- Unable to script check constraint: table or constraint information missing." + Environment.NewLine);
                        continue;
                    }

                    // set the locals
                    checkConstraint = difference.CheckConstraint;
                    tableName = difference.Table.Name;
                    checkClause = XmlPatternHelper.Decode(checkConstraint.CheckClause);

                    // skip if this constraint was already scripted (multi-column checks load once per column)
                    if (!scripted.Add(tableName + "." + checkConstraint.ConstraintName))
                    {
                        continue;
                    }

                    // must have an expression to script it
                    if (!TextHelper.Exists(checkClause))
                    {
                        sb.Append("-- Unable to script check constraint [" + checkConstraint.ConstraintName + "] on [" + tableName + "]: no check clause." + Environment.NewLine);
                        continue;
                    }

                    // if invalid, drop the existing one first
                    if (difference.DifferenceType == DifferenceTypeEnum.CheckConstraintNotValid)
                    {
                        sb.Append("ALTER TABLE [" + tableName + "] DROP CONSTRAINT [" + checkConstraint.ConstraintName + "]" + Environment.NewLine + "Go" + Environment.NewLine);
                    }

                    // add it with the source expression (WITH CHECK validates existing rows)
                    sb.Append("ALTER TABLE [" + tableName + "] WITH CHECK ADD CONSTRAINT [" + checkConstraint.ConstraintName + "] CHECK " + checkClause + Environment.NewLine + "Go" + Environment.NewLine);
                }
            }

            // return value
            return sb.ToString();
        }
        #endregion

        #region GenerateForeignKeyConstraintSQL()
        /// <summary>
        /// returns the Foreign Key Constraint SQL for foreign key differences on existing tables.
        /// (Foreign keys for a missing table are scripted with the table, in CreateTableChildObjectsSQL.)
        /// </summary>
        public string GenerateForeignKeyConstraintSQL()
        {
            // initial value
            StringBuilder sb = new StringBuilder();

            // locals
            bool isForeignKeyDifference = false;
            string tableName = "";
            string checkState = "";
            string createSQL = "";

            // if the Comparison.SchemaDifferences exists
            if ((HasComparison) && (Comparison.HasSchemaDifferences))
            {
                // iterate the SchemaDifferences
                foreach (SchemaDifference difference in Comparison.SchemaDifferences)
                {
                    // only foreign key differences are handled here
                    isForeignKeyDifference = ((difference.DifferenceType == DifferenceTypeEnum.ForeignKeyNotFound) ||
                                              (difference.DifferenceType == DifferenceTypeEnum.ForeignKeyWrongReferencedColumn) ||
                                              (difference.DifferenceType == DifferenceTypeEnum.ForeignKeyWrongTableName) ||
                                              (difference.DifferenceType == DifferenceTypeEnum.ForeignKeyWrongAction) ||
                                              (difference.DifferenceType == DifferenceTypeEnum.ForeignKeyDisabled));

                    // if this is a foreign key difference with a table
                    if ((isForeignKeyDifference) && (difference.HasTable))
                    {
                        // the table name
                        tableName = difference.Table.Name;

                        // Disabled / Enabled: no drop needed, just change the check state
                        if (difference.DifferenceType == DifferenceTypeEnum.ForeignKeyDisabled)
                        {
                            // if we have the source constraint and the name
                            if ((difference.HasForeignKey) && (TextHelper.Exists(difference.InvalidForeignKeyName)))
                            {
                                // match the source
                                if (difference.ForeignKey.IsDisabled)
                                {
                                    // disable it
                                    checkState = "NOCHECK";
                                }
                                else
                                {
                                    // re-enable it, and re-validate existing rows
                                    checkState = "WITH CHECK CHECK";
                                }

                                // append this sql
                                sb.Append("ALTER TABLE [" + tableName + "] " + checkState + " CONSTRAINT [" + difference.InvalidForeignKeyName + "]" + Environment.NewLine + "Go" + Environment.NewLine);
                            }
                        }
                        else
                        {
                            // for everything except NotFound, drop the existing (wrong) constraint first
                            if ((difference.DifferenceType != DifferenceTypeEnum.ForeignKeyNotFound) && (TextHelper.Exists(difference.InvalidForeignKeyName)))
                            {
                                // append the drop sql
                                sb.Append("ALTER TABLE [" + tableName + "] DROP CONSTRAINT [" + difference.InvalidForeignKeyName + "]" + Environment.NewLine + "Go" + Environment.NewLine);
                            }

                            // create the constraint
                            createSQL = BuildCreateForeignKeySQL(difference);

                            // if the create sql was built
                            if (TextHelper.Exists(createSQL))
                            {
                                // append the create sql
                                sb.Append(createSQL);
                            }
                            else
                            {
                                // not enough info to script this one; leave a comment instead of crashing
                                sb.Append("-- Unable to script foreign key for table [" + tableName + "]: column information missing." + Environment.NewLine);
                            }
                        }
                    }
                }
            }

            // return value
            return sb.ToString();
        }
        #endregion

        #region GenerateIndexSQL()
        /// <summary>
        /// returns the Index SQL. Missing indexes are created; invalid indexes are dropped and recreated
        /// to match the source. Primary keys and unique constraints are scripted as constraints,
        /// everything else as indexes.
        /// </summary>
        public string GenerateIndexSQL()
        {
            // initial value
            StringBuilder sb = new StringBuilder();

            // locals
            DataIndex index = null;
            string tableName = "";
            bool isConstraint = false;

            // if the Comparison.SchemaDifferences exists
            if ((HasComparison) && (Comparison.HasSchemaDifferences))
            {
                // iterate the SchemaDifferences
                foreach (SchemaDifference difference in Comparison.SchemaDifferences)
                {
                    // only index differences are handled here
                    if ((difference.DifferenceType != DifferenceTypeEnum.IndexNotFound) && (difference.DifferenceType != DifferenceTypeEnum.IndexNotValid))
                    {
                        continue;
                    }

                    // must have the table and the source index to script it
                    if ((!difference.HasTable) || (!difference.HasIndex) || (!ListHelper.HasOneOrMoreItems(difference.Index.Columns)))
                    {
                        sb.Append("-- Unable to script index: table or column information missing." + Environment.NewLine);
                        continue;
                    }

                    // set the locals
                    index = difference.Index;
                    tableName = difference.Table.Name;
                    isConstraint = (index.IsPrimary || index.IsUniqueConstraint);

                    // only clustered and nonclustered rowstore indexes are scripted
                    if ((!TextHelper.IsEqual(index.TypeDescription, "CLUSTERED")) && (!TextHelper.IsEqual(index.TypeDescription, "NONCLUSTERED")))
                    {
                        sb.Append("-- Unable to script " + index.TypeDescription + " index [" + index.Name + "] on [" + tableName + "]. Script this one manually." + Environment.NewLine);
                        continue;
                    }

                    // if invalid, drop the existing one first
                    if (difference.DifferenceType == DifferenceTypeEnum.IndexNotValid)
                    {
                        if (isConstraint)
                        {
                            // primary keys and unique constraints are dropped as constraints
                            sb.Append("ALTER TABLE [" + tableName + "] DROP CONSTRAINT [" + index.Name + "]" + Environment.NewLine + "Go" + Environment.NewLine);
                        }
                        else
                        {
                            // regular indexes are dropped as indexes
                            sb.Append("DROP INDEX [" + index.Name + "] ON [" + tableName + "]" + Environment.NewLine + "Go" + Environment.NewLine);
                        }
                    }

                    // create it to match the source
                    sb.Append(BuildCreateIndexSQL(index, tableName, isConstraint));
                }
            }

            // return value
            return sb.ToString();
        }
        #endregion

        #region GetDefaultValueConstraintsSQL()
        /// <summary>
        /// returns the Default Value Constraints SQL. Missing defaults are added; wrong defaults are
        /// dropped (using the target's constraint name, which may differ) and added back.
        /// Uses the Definition text, so numeric, date, guid and text defaults are all handled.
        /// </summary>
        public string GetDefaultValueConstraintsSQL()
        {
            // initial value
            StringBuilder sb = new StringBuilder();

            // locals
            DefaultValueConstraint constraint = null;
            string tableName = "";
            string dropName = "";

            // if the Comparison.SchemaDifferences exists
            if ((HasComparison) && (Comparison.HasSchemaDifferences))
            {
                // iterate the SchemaDifferences
                foreach (SchemaDifference difference in Comparison.SchemaDifferences)
                {
                    // older type: the target table has no defaults, so add all of the source table's defaults
                    if (difference.DifferenceType == DifferenceTypeEnum.TargetTableHasNoDefaultValueConstraints)
                    {
                        // must have the table
                        if (!difference.HasTable)
                        {
                            continue;
                        }

                        // find the source table
                        DataTable source = Comparison.SourceDatabase.Tables.FirstOrDefault(x => x.Name == difference.Table.Name);

                        // If the source table and its defaults exist
                        if ((NullHelper.Exists(source)) && (ListHelper.HasOneOrMoreItems(source.DefaultValueConstraints)))
                        {
                            // add each default
                            foreach (DefaultValueConstraint sourceConstraint in source.DefaultValueConstraints)
                            {
                                sb.Append(BuildAddDefaultSQL(source.Name, sourceConstraint));
                            }
                        }

                        // done with this difference
                        continue;
                    }

                    // only default value differences are handled below
                    if ((difference.DifferenceType != DifferenceTypeEnum.DefaultValueConstraintNotFound) && (difference.DifferenceType != DifferenceTypeEnum.DefaultValueConstraintWrongValue))
                    {
                        continue;
                    }

                    // must have the table and the source constraint to script it
                    if ((!difference.HasTable) || (!difference.HasDefaultValueConstraint))
                    {
                        sb.Append("-- Unable to script default value constraint: table or constraint information missing." + Environment.NewLine);
                        continue;
                    }

                    // set the locals
                    constraint = difference.DefaultValueConstraint;
                    tableName = difference.Table.Name;

                    // if the value is wrong, drop the target's existing constraint first
                    if (difference.DifferenceType == DifferenceTypeEnum.DefaultValueConstraintWrongValue)
                    {
                        // the target's constraint name (it can differ from the source's)
                        dropName = difference.InvalidConstraintName;

                        // if the name exists
                        if (TextHelper.Exists(dropName))
                        {
                            sb.Append("ALTER TABLE [" + tableName + "] DROP CONSTRAINT [" + dropName + "]" + Environment.NewLine + "Go" + Environment.NewLine);
                        }
                        else
                        {
                            // without the name the add would fail, since the column already has a default
                            sb.Append("-- Unable to drop the existing default for [" + tableName + "].[" + constraint.ColumnName + "]: target constraint name missing." + Environment.NewLine);
                            continue;
                        }
                    }

                    // add the source default
                    sb.Append(BuildAddDefaultSQL(tableName, constraint));
                }
            }

            // return value
            return sb.ToString();
        }
        #endregion

        #region GetUpdateFieldsSQL()
        /// <summary>
        /// returns the Update Fields SQL
        /// </summary>
        public string GetUpdateFieldsSQL()
        {
            // initial value
            string sql = "";

            // locals                
            DataTable table = null;
            DataField field = null;
            string fieldSQL = "";

            // Create a new instance of a 'StringBuilder' object.
            StringBuilder sb = new StringBuilder();

            // iterate the differences
            foreach (SchemaDifference difference in Comparison.SchemaDifferences)
            {
                // erase after each difference
                fieldSQL = "";

                // set the table and field
                table = difference.Table;
                field = difference.Field;

                // If the 'table' object and the 'field' objects both exist.
                if (NullHelper.Exists(table, field))
                {
                    // fixing error of trying to add a column to a view
                    if (!table.IsView)
                    {
                        // if Field 
                        if (difference.DifferenceType == DifferenceTypeEnum.FieldIsMissing)
                        {
                            // create the SQL to create this field
                            fieldSQL = CreateFieldSQL(table, field, true);
                        }
                        else if (difference.DifferenceType == DifferenceTypeEnum.FieldInvalid)
                        {
                            // create the SQL to create this field
                            fieldSQL = CreateFieldSQL(table, field, false);
                        }

                        if (TextHelper.Exists(fieldSQL))
                        {
                            // Add the fieldSQL
                            sb.Append(fieldSQL);
                        }
                    }
                    else
                    {
                        // to do: drop view and recreate it with the new field
                    }
                }

                // set the return value
                sql = sb.ToString();
            }

            // return value
            return sql;
        }
        #endregion

        #region GetUpdateStoredProceduresSQL()
        /// <summary>
        /// returns the Update Stored Procedures SQL
        /// </summary>
        public string GetUpdateStoredProceduresSQL()
        {
            // initial value
            string sql = "";

            // local                
            string storedProcedureText = "";

            // Create a new instance of a 'StringBuilder' object.
            StringBuilder sb = new StringBuilder();

            // iterate the differences
            foreach (SchemaDifference difference in Comparison.SchemaDifferences)
            {
                // reset
                storedProcedureText = "";

                // if a StoredProcedure is missing or invalid
                if (difference.DifferenceType == DifferenceTypeEnum.StoredProcedureMissingOrInvalid)
                {
                    // if the procedure has been loaded
                    if (difference.HasProcedure)
                    {
                        // Get the text
                        storedProcedureText = difference.Procedure.Text;

                        // Fix reserve words by surrounding Select statement with braces
                        storedProcedureText = FixReserveWordsInSelect(storedProcedureText);
                    }

                    // If the storedProcedureText string exists
                    if (TextHelper.Exists(storedProcedureText))
                    {
                        // get the drop if it exists text
                        string dropIfExists = CreateDeleteProcIfExistsSQL(difference.Procedure.ProcedureName);

                        // Get the next text
                        sb.Append(dropIfExists);

                        // Drop the procedure text
                        sb.Append(Environment.NewLine);

                        // add the stored procedure text
                        sb.Append(storedProcedureText);

                        // Each sql item be in its own block
                        sb.Append(Environment.NewLine);
                        sb.Append("Go");

                        // Add a new line twice
                        sb.Append(Environment.NewLine);
                        sb.Append(Environment.NewLine);
                    }
                }
            }

            // set the return value
            sql = sb.ToString();

            // return value
            return sql;
        }
        #endregion

        #region GetUpdateTablesSQL()
        /// <summary>
        /// returns the Update Tables SQL. For a missing table, the table is created (with its primary key),
        /// followed by its default value constraints, check constraints and indexes, all from the source table.
        /// </summary>
        public string GetUpdateTablesSQL()
        {
            // initial value
            string sql = "";

            // local
            string viewSQL = "";

            // Create a new instance of a 'StringBuilder' object.
            StringBuilder sb = new StringBuilder("Use [");
            sb.Append(Comparison.TargetDatabase.Name);
            sb.Append(']');
            sb.Append(Environment.NewLine);
            sb.Append("Go");
            sb.Append(Environment.NewLine);

            // Add a blank line
            sb.Append(Environment.NewLine);

            // iterate the differences
            foreach (SchemaDifference difference in Comparison.SchemaDifferences)
            {
                if (difference.DifferenceType == DifferenceTypeEnum.TableIsMissing)
                {
                    // if this table is a view
                    if (difference.Table.IsView)
                    {
                        // create the SQL to create this View
                        viewSQL = CreateViewSQL(difference.Table);
                        sb.Append(viewSQL);
                    }
                    else
                    {
                        // create the SQL to create this table
                        string tableSQL = CreateTableSQL(difference.Table);
                        sb.Append(tableSQL);

                        // add the table's child objects from the source
                        sb.Append(CreateTableChildObjectsSQL(difference.Table));
                    }
                }
                else if ((difference.DifferenceType == DifferenceTypeEnum.FieldInvalid) || (difference.DifferenceType == DifferenceTypeEnum.FieldIsMissing))
                {
                    if ((difference.HasTable) && (difference.Table.IsView))
                    {
                        // create the SQL to create this View
                        viewSQL = CreateViewSQL(difference.Table, true);
                        sb.Append(viewSQL);
                    }
                }
            }

            // get the return value
            sql = sb.ToString();

            // return value
            return sql;
        }
        #endregion

        #region Init()
        /// <summary>
        /// This method performs initializations for this object.
        /// </summary>
        public void Init()
        {
            // Setup the listeners
            this.RemoteCompareCheckBox.CheckChangedListener = this;
            this.CreateXmlFileCheckBox.CheckChangedListener = this;

            // Create a new instance of a 'CompareInfo' object.
            this.CompareInfo = new CompareInfo();

            // Set the version.
            Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = $"DB Compare {v.Major}.{v.Minor}.{v.Build}";

            // Create a new collection of 'string' objects.
            IgnoreItems = new List<string>();
        }
        #endregion

        #region LoadDatabaseSchema(SQLDatabaseConnector connector, ref Database database)
        /// <summary>
        /// This method loads the Database Schema for the database given.
        /// </summary>
        private void LoadDatabaseSchema(SQLDatabaseConnector connector, ref Database database)
        {
            // local
            bool ignoreDataSync = IgnoreDataSyncCheckBox.Checked;
            bool ignoreFirewallRules = IgnoreFirewallRulesCheckBox.Checked;

            try
            {
                // if the database exists
                if ((connector != null) && (database != null))
                {
                    // Open the connection
                    connector.Open();

                    // if the connector is open
                    if (connector.Connected)
                    {
                        // Load the database schema
                        connector.LoadDatabaseSchema(database, ignoreDataSync, ignoreFirewallRules);
                    }

                    // Close the connection
                    connector.Close();
                }
            }
            catch (Exception error)
            {
                // for debugging only
                string err = error.ToString();
            }
        }
        #endregion

        #region LoadDatabaseSchema(string xmlFilePath, ref Database database)
        /// <summary>
        /// This method loads the Database Schema for the database given.
        /// </summary>
        private void LoadDatabaseSchema(string xmlFilePath, ref Database database)
        {
            try
            {
                // if the database exists
                if (TextHelper.Exists(xmlFilePath))
                {
                    // read all the text of the xml file
                    string xmlText = File.ReadAllText(xmlFilePath);

                    // Decoding the text as one line string was not working.

                    // If the xmlText string exists
                    if (TextHelper.Exists(xmlText))
                    {
                        // Create a new instance of a 'DatabasesParser' object.
                        DatabasesParser parser = new DatabasesParser();

                        // Load the database from xml
                        database = parser.ParseDatabase(xmlText);
                    }
                }
            }
            catch (Exception error)
            {
                // for debugging only
                string err = error.ToString();

                // Write a message to the output window
                DebugHelper.WriteDebugError("LoadDatabaseSchema", "MainForm", error);

                // Show the user a message
                this.ResultsTextBox.Text = "An error occurred load the database from the xml file '" + xmlFilePath + "'.";
            }
        }
        #endregion

        #region RemoteCompareDatabases()
        /// <summary>
        /// This method Remote Compare Databases
        /// </summary>
        public void RemoteCompareDatabases()
        {
            try
            {
                // clear the text
                Clear();

                // locals
                string message = "";
                string title = "Validation Failed";
                Database sourceDatabase = new Database();
                Database targetDatabase = new Database();
                SchemaComparison schemaComparison = new SchemaComparison();

                // Set Focus to this button
                this.HiddenButton.Focus();

                // Disable the button
                this.CompareDatabasesButton.Enabled = false;

                // Change the Cursor
                this.Cursor = Cursors.WaitCursor;

                // Refresh the UI
                this.Refresh();

                // Capture the CompareInfo
                CaptureCompareInfo();

                // Save the current settings
                SaveSettings();

                // Is this valid
                bool validConnections = this.CompareInfo.IsValid();

                // if the validConnections
                if (validConnections)
                {
                    // Load the Schema for both databases
                    LoadDatabaseSchema(this.CompareInfo.SourceXmlFilePath, ref sourceDatabase);
                    LoadDatabaseSchema(this.CompareInfo.TargetDatabaseConnector, ref targetDatabase);

                    // Compare the database structure
                    CompareDatabaseStructure(sourceDatabase, targetDatabase);

                    // Increment the CompareCount
                    this.Settings.CompareCount++;

                    // Save the Settings
                    this.Settings.Save();
                }
                else
                {
                    // Show a failed reason
                    message = this.CompareInfo.InvalidReason;

                    // Show the user a message
                    MessageBoxHelper.ShowMessage(message, title);
                }
            }
            catch (Exception error)
            {
                // for debugging only
                string err = error.ToString();

                // Show the error
                this.ResultsTextBox.Text = "An error occurred: " + Environment.NewLine + err;
            }
            finally
            {
                // Renable the button
                CompareDatabasesButton.Enabled = true;
                this.Cursor = Cursors.Default;
                this.Refresh();
            }
        }
        #endregion

        #region RunComparison()
        /// <summary>
        /// This method Run Comparison
        /// </summary>
        public Task<bool> RunComparison()
        {
            // if the RemoteCompareMode is true
            if ((this.HasCompareInfo) && (this.CompareInfo.CompareType == CompareTypeEnum.CompareXmlFileAndSQLDatabase))
            {
                // Perform the comparison on the Remote database
                RemoteCompareDatabases();
            }
            else
            {
                // Compare the databases
                CompareDatabases();
            }

            // return value
            return Task.FromResult<bool>(true);
        }
        #endregion

        #region SaveSettings()
        /// <summary>
        /// This method saves the settings
        /// </summary>
        public void SaveSettings()
        {
            // local
            bool storeConnectionStrings = this.StoreConnectionStringsCheckBox.Checked;

            // save these values
            if (this.HasSettings)
            {
                // Store the CompareType
                settings.CompareType = this.CompareInfo.CompareType.ToString();

                // set the value
                this.Settings.StoreConnectionStrings = storeConnectionStrings;

                // Deteremine which settings to save based upon the CompareType
                if (this.CompareInfo.CompareType == CompareTypeEnum.CompareTwoSQLDatabases)
                {
                    // if store connection strings
                    if (storeConnectionStrings)
                    {
                        // store the connection strings
                        this.Settings.SourceConnectionString = this.CompareInfo.SourceDatabaseConnectionString;
                        this.Settings.TargetConnectionString = this.CompareInfo.TargetDatabaseConnectionString;
                    }
                    else
                    {
                        // store the connection strings
                        this.Settings.SourceConnectionString = null;
                        this.Settings.TargetConnectionString = null;
                    }

                    // Not a remote comparision
                    this.Settings.RemoteComparison = false;
                    this.Settings.CreateXmlFile = false;
                    this.Settings.OutputXmlFilePath = null;
                    this.Settings.SourceXmlFilePath = null;
                }
                else if (this.CompareInfo.CompareType == CompareTypeEnum.CompareXmlFileAndSQLDatabase)
                {
                    // if store connection strings
                    if (storeConnectionStrings)
                    {
                        // store the connection strings
                        this.Settings.SourceConnectionString = null;
                        this.Settings.TargetConnectionString = this.CompareInfo.TargetDatabaseConnectionString;
                    }
                    else
                    {
                        // store the connection strings
                        this.Settings.SourceConnectionString = null;
                        this.Settings.TargetConnectionString = null;
                    }

                    // Set the SourceXmlFilePath
                    this.Settings.SourceXmlFilePath = this.SourceConnectionStringControl.Text;

                    // Not a remote comparision
                    this.Settings.RemoteComparison = true;
                    this.Settings.CreateXmlFile = false;
                    this.Settings.OutputXmlFilePath = null;
                }
                else if (this.CompareInfo.CompareType == CompareTypeEnum.CreateXmlFile)
                {
                    // if store connection strings
                    if (storeConnectionStrings)
                    {
                        // store the connection strings
                        this.Settings.SourceConnectionString = this.CompareInfo.SourceDatabaseConnectionString;
                        this.Settings.TargetConnectionString = null;
                    }
                    else
                    {
                        // store the connection strings
                        this.Settings.SourceConnectionString = null;
                        this.Settings.TargetConnectionString = null;
                    }

                    // Set the OutputXmlFilePath
                    this.Settings.OutputXmlFilePath = this.CompareInfo.OutputXmlFilePath;

                    // Not a remote comparision
                    this.Settings.RemoteComparison = true;
                    this.Settings.CreateXmlFile = true;
                    this.Settings.SourceXmlFilePath = null;
                }

                // Store the value for IgnoreDiagramProcedures, IgnoreDataSync and IgnoreFirewallRules
                this.Settings.IgnoreDiagramProcedures = this.IgnoreDiagramProceduresCheckBox.Checked;
                this.Settings.IgnoreDataSync = this.IgnoreDataSyncCheckBox.Checked;
                this.Settings.IgnoreFirewallRules = this.IgnoreFirewallRulesCheckBox.Checked;

                // Save the settings
                this.Settings.Save();
            }
        }
        #endregion

        #region UIControl()
        /// <summary>
        /// This method controls the User Interface
        /// </summary>
        public void UIControl()
        {
            // If the CompareInfo object exists
            if (this.HasCompareInfo)
            {
                // if we are in Remote Compare Mode
                if (this.CompareInfo.CompareType == CompareTypeEnum.CompareXmlFileAndSQLDatabase)
                {
                    // Always show the Create Xml File Checkbox
                    this.CreateXmlFileCheckBox.Visible = true;

                    // Change the connection string to read
                    this.SourceConnectionStringControl.LabelText = "Source Xml File:";
                    this.TargetConnectionStringControl.LabelText = "Target Conn. String:";
                    this.CreateXmlFileButton.Visible = false;
                    this.BuildTargetConnectionStringButton.Visible = true;
                }
                else if (CompareInfo.CompareType == CompareTypeEnum.CreateXmlFile)
                {
                    // Change the connection string to read
                    this.SourceConnectionStringControl.LabelText = "Source Conn. String:";
                    this.TargetConnectionStringControl.LabelText = "Output Xml File:";
                    this.CreateXmlFileButton.Visible = true;
                    this.BuildTargetConnectionStringButton.Visible = false;
                }
                else
                {
                    // This is compare two SQL databases mode
                    this.SourceConnectionStringControl.LabelText = "Source Conn. String:";
                    this.TargetConnectionStringControl.LabelText = "Target Conn. String:";
                    this.CreateXmlFileCheckBox.Visible = false;
                    this.CreateXmlFileButton.Visible = false;
                    this.BuildTargetConnectionStringButton.Visible = true;
                }
            }
        }
        #endregion

        #region UpdateStatus(string message, int value)
        /// <summary>
        /// Update Status
        /// </summary>
        public void UpdateStatus(string message, int value)
        {
            // determine the action by the message
            if (message == "SetGraphMax")
            {
                // set the value
                Graph.Maximum = value;

                // Show
                Graph.Visible = true;

                // Refresh everything
                Refresh();
                Application.DoEvents();
            }
            else if (message == "Done")
            {
                // hide
                Graph.Visible = false;

                // Refresh everything
                Refresh();
                Application.DoEvents();
            }
            else if (message == "Progress")
            {
                if (Graph.Maximum < value)
                {
                    // reset
                    Graph.Maximum = value + 10;
                }

                // set the value
                Graph.Value = value;

                // only update every 10 records. Since converting to .NET6, this is really fast
                // but you can take this out if this makes it too slow
                if (value % 10 == 0)
                {
                    // Refresh everything
                    Refresh();
                    Application.DoEvents();
                }
            }
            else if (value == Graph.Maximum)
            {
                // hide
                Graph.Visible = false;

                // Refresh everything
                Refresh();
                Application.DoEvents();
            }
        }
        #endregion

        #endregion

        #region Properties

        #region CompareInfo
        /// <summary>
        /// This property gets or sets the value for 'CompareInfo'.
        /// </summary>
        public CompareInfo CompareInfo
        {
            get { return compareInfo; }
            set { compareInfo = value; }
        }
        #endregion

        #region Comparison
        /// <summary>
        /// This property gets or sets the value for 'Comparison'.
        /// </summary>
        public SchemaComparison Comparison
        {
            get { return comparison; }
            set { comparison = value; }
        }
        #endregion

        #region CreateParams
        /// <summary>
        /// This property here is what did the trick to reduce the flickering.
        /// I also needed to make all of the controls Double Buffered, but
        /// this was the final touch. It is a little slow when you switch tabs
        /// but that is because the repainting is finishing before control is
        /// returned.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                // initial value
                CreateParams cp = base.CreateParams;

                // Apparently this interrupts Paint to finish before showing
                cp.ExStyle |= 0x02000000;

                // return value
                return cp;
            }
        }
        #endregion

        #region HasCompareInfo
        /// <summary>
        /// This property returns true if this object has a 'CompareInfo'.
        /// </summary>
        public bool HasCompareInfo
        {
            get
            {
                // initial value
                bool hasCompareInfo = (this.CompareInfo != null);

                // return value
                return hasCompareInfo;
            }
        }
        #endregion

        #region HasComparison
        /// <summary>
        /// This property returns true if this object has a 'Comparison'.
        /// </summary>
        public bool HasComparison
        {
            get
            {
                // initial value
                bool hasComparison = (this.Comparison != null);

                // return value
                return hasComparison;
            }
        }
        #endregion

        #region HasSettings
        /// <summary>
        /// This property returns true if this object has a 'Settings'.
        /// </summary>
        public bool HasSettings
        {
            get
            {
                // initial value
                bool hasSettings = (this.Settings != null);

                // return value
                return hasSettings;
            }
        }
        #endregion

        #region IgnoreItems
        /// <summary>
        /// This property gets or sets the value for 'IgnoreItems'.
        /// </summary>
        public List<string> IgnoreItems
        {
            get { return ignoreItems; }
            set { ignoreItems = value; }
        }
        #endregion

        #region Settings
        /// <summary>
        /// This property gets or sets the value for 'Settings'.
        /// </summary>
        public SecureUserData Settings
        {
            get { return settings; }
            set { settings = value; }
        }
        #endregion

        #endregion

    }
    #endregion

}
