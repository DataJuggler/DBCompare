

#region using statements

using System.Collections.Generic;
using DataJuggler.UltimateHelper;
using DataJuggler.UltimateHelper.Objects;
using DataJuggler.Net6;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using DBCompare.Enumerations;
using DBCompare.Security;
using DBCompare.Xml.Parsers;
using DBCompare.Xml.Writers;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBCompare.Util;
using System.Linq;

#endregion

namespace DBCompare
{

    #region class MainForm
    /// <summary>
    /// This class is the MainForm for this application.
    /// </summary>
    public partial class MainForm : Form, ICheckChangedListener
    {
        
        #region Private Variables
        private SecureUserData settings;
        private CompareInfo compareInfo;
        private SchemaComparison comparison;
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
                string message = "-- This script is meant to be a time saver. Use only if the generated sql looks safe for your environment";
                message += Environment.NewLine + "-- This tool is a work in progress. For now it does tables and fields. Stored Procedures";
                message += Environment.NewLine + "-- are easy to update, and constraints and indexes are harder to script, so I put them off.";
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
                    
                    // Append each
                    if (TextHelper.Exists(tablesSQL))
                    {
                        sb.Append(tablesSQL);
                    }
                    if (TextHelper.Exists(fieldsSQL))
                    {
                        sb.Append(fieldsSQL);
                    }
                    if (TextHelper.Exists(storedProceduresSQL))
                    {
                        sb.Append(storedProceduresSQL);
                    }
                    if (TextHelper.Exists(defaultValueConstraintsSQL))
                    {
                        sb.Append(defaultValueConstraintsSQL);
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
                    MessageBoxHelper.ShowMessage("The sql has been copied to your clipboard.", "SQL Created");
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
            
            #region YouTubeButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'YouTubeButton' is clicked.
            /// </summary>
            private void YouTubeButton_Click(object sender, EventArgs e)
            {
                // open to my website
                System.Diagnostics.Process.Start(YouTubePath);
            }
            #endregion
            
        #endregion

        #region Methods
    
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
            public string CreateFieldSQL(DataTable table, DataField field, bool addNew)
            {
                // initial value
                string sql = "";

                // Create a new instance of a 'StringBuilder' object.
                StringBuilder sb = new StringBuilder();

                // locals
                string adjustment = "Alter Column ";

                // first line
                sb.Append("Alter Table ");
                sb.Append(table.Name);
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
                sb.Append("[");
                sb.Append(field.DBFieldName);
                sb.Append("]");

                sb.Append(" ");
                sb.Append(field.DBDataType);
                   
                // if a string
                if (field.DataType == DataManager.DataTypeEnum.String)
                {
                    // append the size
                    sb.Append("(");
                    sb.Append(field.Size);
                    sb.Append(")");
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
            
            #region CreateTableSQL(DataTable table)
            /// <summary>
            /// Create Table SQL
            /// </summary>
            public string CreateTableSQL(DataTable table)
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
                int count = 0;

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
                        // first add the primaryKey(s)
                        if (table.HasMultiplePrimaryKeys())
                        {
                            // to do: Handle multiple primary keys
                            // I never create these, but sometimes I have to work with client DB's with this
                            // so it is on my someday list.
                        }
                        else if (table.HasPrimaryKey)
                        {  
                            // this field has been added
                            count++;

                            // Append 8 spaces then Column
                            sb.Append(TextHelper.Indent(8));
                            sb.Append("[");
                            sb.Append(table.PrimaryKey.DBFieldName);
                            sb.Append("] [");
                            sb.Append(table.PrimaryKey.DBDataType);
                            sb.Append("] ");

                            // if identity insert
                            if (table.PrimaryKey.IsAutoIncrement)
                            {
                                // Idenity Primary Key can't be null
                                sb.Append("IDENTITY(1,1) ");                                
                            }                            
                            
                            // add null
                            sb.Append("not null,");                                

                            // add a new line
                            sb.Append(newLine);
                        }

                        // now iterate the fields
                        foreach (DataField field in table.Fields)
                        {
                            if (!field.PrimaryKey)
                            {
                                // set the count
                                count++;

                                sb.Append(TextHelper.Indent(8));
                                sb.Append('[');
                                sb.Append(field.DBFieldName);
                                sb.Append("] [");
                                sb.Append(field.DBDataType);
                                sb.Append("]");

                                // if string
                                if (field.DataType == DataManager.DataTypeEnum.String)
                                {
                                    sb.Append('(');
                                    sb.Append(field.Size);
                                    sb.Append(')');
                                }

                                // if this field is nullable
                                if (field.IsNullable)
                                { 
                                    // null
                                    sb.Append(" null");
                                }
                                else
                                {
                                    // not null
                                    sb.Append(" not null");
                                }

                                // if not the last field
                                if (count < table.Fields.Count)
                                {
                                    // Add a comma
                                    sb.Append(",");
                                }
                                else if ((count == table.Fields.Count) && (table.HasPrimaryKey) && (table.PrimaryKey.IsAutoIncrement))
                                {
                                    // Add a comma
                                    sb.Append(",");
                                }

                                // start a new line
                                sb.Append(newLine);
                            }
                        }

                        // If the table has an Identity (Auto Number) Primary Key
                        if ((table.HasPrimaryKey) && (table.PrimaryKey.IsAutoIncrement) && (table.HasIndexes))
                        {
                            // First version of this is only for Identity constraints

                            /*
                             
                            CONSTRAINT [PK_ActivityLog] PRIMARY KEY CLUSTERED 
                            (
	                            [Id] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

                            */

                            // create the identityConstraint, the only one being handled for now
                            string endConstraint = "  ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]" + newLine;
                            string identityConstraint = "  CONSTRAINT [[ConstraintName]] PRIMARY KEY CLUSTERED" + newLine + "  (" + newLine + "    [" + "[ConstraintColumnName]] ASC" + newLine + endConstraint;
                            

                            // Create the column
                            DataField column = table.PrimaryKey;
                            
                            // If the column object exists
                            if (NullHelper.Exists(column))
                            {                                    
                                // This is the only constraint we are handling, for now
                                string indexName = table.Indexes[0].Name;
                                string identity = identityConstraint.Replace("[ConstraintName]", indexName).Replace("[ConstraintColumnName]", column.FieldName);
                                        
                                // add this
                                sb.Append(identity);                                    
                            }  
                        }
                    }

                    // append the closijng on primary
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
            public string CreateViewSQL(DataTable table)
            {
                // initial value
                string sql = "";

                // If the table object exists
                if ((NullHelper.Exists(table)) && (table.IsView))
                {
                    //SQLDatabaseConnector connector = new SQLDatabaseConnector();
                    //connector.ConnectionString = SourceConnectionStringControl.Text;
                    //connector.Open();
                    sql = table.ViewText;

                    // close the connection
                    // connector.Close();

                    // If the sql string exists
                    if (TextHelper.Exists(sql))
                    {
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
                           
                           // hide the button if up to date
                           GenerateScriptsButton.Visible = false;
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
            
            #region GetDefaultValueConstraintsSQL()
            /// <summary>
            /// returns the Default Value Constraints SQL
            /// </summary>
            public string GetDefaultValueConstraintsSQL()
            {
                // initial value
                string defaultValueConstraintsSQL = "";

                // local
                string sql = "";

                // if the Comparison.SchemaDifferences exists
                if ((HasComparison) && (Comparison.HasSchemaDifferences))
                {
                    // iterate the SchemaDifferences
                    foreach (SchemaDifference difference in Comparison.SchemaDifferences)
                    {
                        if (difference.DifferenceType == DifferenceTypeEnum.TargetTableHasNoDefaultValueConstraints)
                        {
                            // We must create the SQL for all the DefaultValueConstraints for this table
                            DataTable source = Comparison.SourceDatabase.Tables.FirstOrDefault(x => x.Name == difference.Table.Name);

                            // If the source object exists
                            if (NullHelper.Exists(source))
                            {
                                // generate all DefaultValueConstraints for this table

                                foreach (DefaultValueConstraint constraint in source.DefaultValueConstraints)
                                {
                                    // Create the SQL For this update
                                    sql = "Alter Table " + constraint.TableName + " Add CONSTRAINT " + constraint.ConstraintName + " DEFAULT " + constraint.DefaultValue + " FOR " + constraint.ColumnName + Environment.NewLine + "Go" + Environment.NewLine;

                                    // Add this sql
                                    defaultValueConstraintsSQL += sql;
                                }
                            }
                        }
                        else if (difference.DifferenceType == DifferenceTypeEnum.DefaultValueConstraintNotFound)
                        {
                            // We must create the SQL for this DefaultValueConstraing

                            // Create the SQL For this update
                            sql = "Alter Table " + difference.Table + " Add CONSTRAINT " + difference.Name + " DEFAULT " + difference.Value + " FOR " + difference.Field.FieldName + Environment.NewLine + "Go" + Environment.NewLine;

                            // Add this sql
                            defaultValueConstraintsSQL += sql;
                        }
                        else if (difference.DifferenceType == DifferenceTypeEnum.DefaultValueConstraintWrongValue)
                        {
                            // We must alter the default value, so we must drop the constraint first and add it back

                            // find the existing target table
                            DataTable existingTargetTable = Comparison.TargetDatabase.Tables.FirstOrDefault(x => x.Name == difference.Table.Name);

                            // if found
                            if (NullHelper.Exists(existingTargetTable))
                            {  
                                // find the constraint
                                DefaultValueConstraint existingConstraint = existingTargetTable.DefaultValueConstraints.FirstOrDefault(x => x.ColumnName == difference.Field.FieldName);

                                // If the existingConstraint object exists
                                if (NullHelper.Exists(existingConstraint))
                                {
                                    // get the sql to drop this constraint
                                    sql = "Alter table " + difference.Table.Name + " drop constraint " +  existingConstraint.ConstraintName + " Go " + Environment.NewLine;

                                    // Set the value so far
                                    defaultValueConstraintsSQL = sql;

                                    // now we must create the insert statement
                                    
                                    // Create the SQL For this update
                                    sql = "Alter Table " + difference.Table + " Add CONSTRAINT " + difference.Name + " DEFAULT " + difference.Value + " FOR " + difference.Field.FieldName + Environment.NewLine + "Go" + Environment.NewLine;

                                    // Now add this Create Default Value Constraint
                                    defaultValueConstraintsSQL += sql;
                                }
                            }
                        }
                    }
                }
                
                // return value
                return defaultValueConstraintsSQL;
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
                    // set the table and field
                    table = difference.Table;
                    field = difference.Field;

                    // If the 'table' object and the 'field' objects both exist.
                    if (NullHelper.Exists(table, field))
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

                        // Add the fieldSQL
                        sb.Append(fieldSQL);                    
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
                        }
                       
                        // If the storedProcedureText string exists
                        if (TextHelper.Exists(storedProcedureText))
                        {
                            sb.Append("Drop Procedure ");
                            sb.Append(difference.Procedure.ProcedureName);
                            sb.Append(Environment.NewLine);
                            sb.Append("Go");
                            sb.Append(Environment.NewLine);
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
            /// returns the Update Tables SQL
            /// </summary>
            public string GetUpdateTablesSQL()
            {
                // initial value
                string sql = "";

                // Create a new instance of a 'StringBuilder' object.
                StringBuilder sb = new StringBuilder("Use [");
                sb.Append(Comparison.TargetDatabase.Name);
                sb.Append("]");
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
                        // set the table
                        DataTable table = difference.Table;

                        // if this table is a view
                        if (table.IsView)
                        {
                            // create the SQL to create this View
                            string viewSQL = CreateViewSQL(table);
                            sb.Append(viewSQL);
                        }
                        else
                        {
                            // create the SQL to create this table
                            string tableSQL = CreateTableSQL(table);
                            sb.Append(tableSQL);
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

                        // decode the xml text
                        xmlText = XmlPatternHelper.Decode(xmlText);

                        // Create a new instance of a 'DatabasesParser' object.
                        DatabasesParser parser = new DatabasesParser();

                        // Load the database from xml
                        database = parser.ParseDatabase(xmlText);
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
