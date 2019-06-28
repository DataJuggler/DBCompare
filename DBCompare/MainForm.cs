

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Net;
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
        private const string XmlFilter = "XML files (*.xml)|*.xml";
        private const string YouTubePath = "https://www.youtube.com/channel/UCaw0joqvisKr3lYJ9Pd2vHA";
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
                            
                        // Create a new database comparer
                        DatabaseComparer comparer = new DatabaseComparer(sourceDatabase, targetDatabase, ignoreDiagramProcedures);

                        // Compare the two database schemas
                        schemaComparison = comparer.Compare();
                    }
                    else
                    {
                        // Add this as a message
                        schemaComparison.SchemaDifferences.Add("The source database does not contain any tables; the comparison cannot continue.");
                    }

                    // compare the two schemas
                    if (schemaComparison != null)
                    {
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
                            foreach (string schemaDifference in schemaComparison.SchemaDifferences)
                            {
                                // Append an indention
                                sb.Append("    ");
                                sb.Append(schemaDifference);
                                sb.Append(Environment.NewLine);
                            }

                            // Show the schema differences
                            this.ResultsTextBox.Text = sb.ToString();

                            // This is a stub for an update for Version 3.0 that isn't ready to be released
                            //// create a message for how to 
                            //message = "Would you like to attempt to fix any errors if possible?";
                                    
                            //// Get the users response
                            //DialogResult result = MessageBoxHelper.GetUserResponse(message, "Fix Schema Differences?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            //// if the user choose yes
                            //if (result == DialogResult.Yes)
                            //{
                            //    // attempt to fix any schema differences
                            //    int fixedCount = SqlUpdater.FixSchemaDifferences(schemaComparison.SchemaDifferences, targetDatabaseConnector, sourceDatabase);
                            //}
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
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // set the version
                string version = "2.1.0";

                // Display the version number
                this.Text = "DB Compare " + version;

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
