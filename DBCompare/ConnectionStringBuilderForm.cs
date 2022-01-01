

#region using statements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataJuggler.Net6;
using DataJuggler.Net6.Connection;

#endregion

namespace DBCompare
{

    #region class ConnectionStringBuilderForm
    /// <summary>
    /// This class is used to test connection strings
    /// </summary>
    public partial class ConnectionStringBuilderForm : Form
    {
        
        #region Private Variables
        private string connectionString;
        private bool userCancelled;
        #endregion
        
        #region Constructor
        /// <summary>
        /// This constructor [enter description here].
        /// </summary>
        public ConnectionStringBuilderForm()
        {
            // Create Controls
            InitializeComponent();

            // Perform Initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
            #region BuildConnectionStringButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event builds a connection string from the values entered.
            /// </summary>
            private void BuildConnectionStringButton_Click(object sender, EventArgs e)
            {
                // locals
                string connectionString = "";

                // Capture the connection info 
                ConnectionInfo connectionInfo = this.CaptureConnectionInfo();

                // if the connection string should use IntegratedSecurity (Windows Authentication)
                if (connectionInfo.IntegratedSecurity)
                {
                    // Build the connectionString
                    connectionString = ConnectionStringHelper.BuildConnectionString(connectionInfo.DatabaseServer, connectionInfo.DatabaseName);
                }
                else
                {
                    // Build the connectionString
                    connectionString = ConnectionStringHelper.BuildConnectionString(connectionInfo.DatabaseServer, connectionInfo.DatabaseName, connectionInfo.DatabaseUserName, connectionInfo.DatabasePassword);
                }

                // display the connectionString
                this.ConnectionStringTextBox.Text = connectionString;
            }
            #endregion
            
            #region Button_MouseEnter(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Button _ Mouse Enter
            /// </summary>
            private void Button_MouseEnter(object sender, EventArgs e)
            {
                // Change to a hand
                this.Cursor = Cursors.Hand;
            }
            #endregion
            
            #region Button_MouseLeave(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Button _ Mouse Leave
            /// </summary>
            private void Button_MouseLeave(object sender, EventArgs e)
            {
                // Change to default
                this.Cursor = Cursors.Default;
            }
            #endregion
            
            #region CancelButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event unloads this form
            /// </summary>
            private void CancelButton_Click(object sender, EventArgs e)
            {
                // close this form 
                this.Close();
            }
            #endregion
            
            #region SelectButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is used to select the connection string.
            /// </summary>
            private void SelectButton_Click(object sender, EventArgs e)
            {
                // Set the connectionString
                string connectionString = this.ConnectionStringTextBox.Text;

                // test for a connectionString 
                bool hasConnectionString = (!String.IsNullOrEmpty(connectionString));
                
                // if a connection string has been established
                if (hasConnectionString)
                {
                    // Set the property
                    this.ConnectionString = connectionString;

                    // the user did not cancel
                    this.userCancelled = false;

                    // close this form
                    this.Close();
                }
                else
                {
                    // Show a warning message
                    MessageBox.Show("You must build or enter a connection string.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            #endregion
            
            #region SQLServerAuthenticationRadioButton_CheckedChanged(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the SQL Server radio button is checked.
            /// </summary>
            private void SQLServerAuthenticationRadioButton_CheckedChanged(object sender, EventArgs e)
            {
                // shortcut
                bool isChecked = this.SQLServerAuthenticationRadioButton.Checked;
                
                // Show or hide the controls based upon the value of isChecked
                this.DatabaseUserNameLabel.Visible = isChecked;
                this.DatabaseUserNameTextBox.Visible = isChecked;
                
                // Show the password label if checked
                this.DatabasePasswordLabel.Visible = isChecked;
                this.DatabasePasswordTextBox.Visible = isChecked;
            }
            #endregion
            
            #region TestDatabaseConnectionButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the Test Database Connection button is clieccked.
            /// </summary>
            private void TestDatabaseConnectionButton_Click(object sender, EventArgs e)
            {
                try
                {
                    // set the connectionTest
                    bool connectionTest = false;

                    // Set the connectionString
                    string connectionString = this.ConnectionStringTextBox.Text;

                    // test for a connectionString 
                    bool hasConnectionString = (!String.IsNullOrEmpty(connectionString));

                    // if a connection string has been established
                    if (hasConnectionString)
                    {
                        // set the dataConnector
                        SQLDatabaseConnector dataConnector = new SQLDatabaseConnector();

                        // set the connection string
                        dataConnector.ConnectionString = connectionString;

                        // Test the connection
                        connectionTest = SQLDatabaseTester.TestDatabaseConnection(dataConnector);

                        // if the connection test passed
                        if (connectionTest)
                        {
                            // Show success icon
                            PassedImage.Visible = true;
                        }
                        else
                        {
                            // Show a success message
                            FailedImage.Visible = false;
                        }
                        
                        // Start the timer to hide the images in 3 seconds
                        Timer.Start();
                    }
                    else
                    {
                        // Show a warning message
                        MessageBox.Show("You must build or enter a connection string.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();

                    // Show a success message
                    MessageBox.Show("A connection to the database count not be estalished.", "Connection Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            #endregion
            
            #region Timer_Tick(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Timer _ Tick
            /// </summary>
            private void Timer_Tick(object sender, EventArgs e)
            {
                // hide all                
                FailedImage.Visible = false;
                PassedImage.Visible = false;
            }
            #endregion
            
        #endregion

        #region Methods

            #region CaptureConnectionInfo()
            /// <summary>
            /// This method captures the data on this form.
            /// </summary>
            private ConnectionInfo CaptureConnectionInfo()
            {
                // initial value
                ConnectionInfo connectionInfo = new ConnectionInfo();

                // Create the connection info
                connectionInfo = new ConnectionInfo();

                // Set the values
                connectionInfo.DatabaseName = this.DatabaseNameTextBox.Text;
                connectionInfo.DatabaseServer = this.DatabaseServerTextBox.Text;
                connectionInfo.IntegratedSecurity = this.WindowsAuthenticationRadioButton.Checked;

                // if not Windows Authentication
                if (!connectionInfo.IntegratedSecurity)
                {
                    // Set the database user name & password
                    connectionInfo.DatabaseUserName = this.DatabaseUserNameTextBox.Text;
                    connectionInfo.DatabasePassword = this.DatabasePasswordTextBox.Text;
                }

                // return value
                return connectionInfo;
            }
            #endregion

            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // default to true
                this.UserCancelled = true;
            }
            #endregion
            
        #endregion

        #region Properties
            
            #region ConnectionString
            /// <summary>
            /// This property gets or sets the value for 'ConnectionString'.
            /// </summary>
            public string ConnectionString
            {
                get { return connectionString; }
                set { connectionString = value; }
            }
            #endregion
            
            #region HasConnectionString
            /// <summary>
            /// This property returns true if the 'ConnectionString' exists.
            /// </summary>
            public bool HasConnectionString
            {
                get
                {
                    // initial value
                    bool hasConnectionString = (!String.IsNullOrEmpty(this.ConnectionString));
                    
                    // return value
                    return hasConnectionString;
                }
            }
            #endregion
            
            #region UserCancelled
            /// <summary>
            /// This property gets or sets the value for 'UserCancelled'.
            /// </summary>
            public bool UserCancelled
            {
                get { return userCancelled; }
                set { userCancelled = value; }
            }
        #endregion

        #endregion
    }
    #endregion

}
