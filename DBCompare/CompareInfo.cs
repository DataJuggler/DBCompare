

#region using statements

using DataJuggler.UltimateHelper;
using DataJuggler.Net5;
using DBCompare.Enumerations;
using System;
using System.IO;

#endregion

namespace DBCompare
{

    #region class CompareInfo
    /// <summary>
    /// This class is used to compare the information for how a comparison is performed.
    /// </summary>
    public class CompareInfo
    {
        
        #region Private Variables
        private string sourceDatabaseConnectionString;
        private string targetDatabaseConnectionString;
        private string sourceXmlFilePath;
        private string outputXmlFilePath;
        private SQLDatabaseConnector sourceDatabaseConnector;
        private SQLDatabaseConnector targetDatabaseConnector;
        private CompareTypeEnum compareType;
        private string invalidReason;
        #endregion

        #region Methods

            #region IsValid()
            /// <summary>
            /// This method returns true if the CompareInfo is valid
            /// </summary>
            public bool IsValid()
            {
                // initial value
                bool isValid = false;

                // Clear this value
                this.InvalidReason = "";

                // If we are in CompareTwoSQLDatabases
                if (this.CompareType == CompareTypeEnum.CompareTwoSQLDatabases)
                {
                    // Validate the two SQL Databases
                    isValid = ValidateTwoSQLDatabases();
                }
                else if (CompareType == CompareTypeEnum.CompareXmlFileAndSQLDatabase)
                {
                    // Validate the two SQL Databases
                    isValid = ValidateXmlFileAndSQLDatabase();
                }
                else if (CompareType == CompareTypeEnum.CreateXmlFile)
                {
                    // Validate the two SQL Databases
                    isValid = ValidateCreateXmlFile();
                }
                
                // return value
                return isValid;
            }
            #endregion
            
            #region ValidateCreateXmlFile()
            /// <summary>
            /// This method returns the Create Xml File
            /// </summary>
            public bool ValidateCreateXmlFile()
            {
                // initial value
                bool isValid = false;

                // locals
                bool validXmlFile = false;
                bool sourceDatabaseConnectionPassed = false;

                // if the SourceDatabaseConnectionString exists and the OutputXmlFilePath exists
                if ((this.HasSourceDatabaseConnectionString) && (this.HasOutputXmlFilePath))
                {
                    // Create the SourceDatabaseConnector
                    this.SourceDatabaseConnector = new SQLDatabaseConnector();

                    // Set the database connector
                    this.SourceDatabaseConnector.ConnectionString = this.SourceDatabaseConnectionString;

                    // Test the SourceDatabaseConnection
                    sourceDatabaseConnectionPassed = SQLDatabaseTester.TestDatabaseConnection(this.SourceDatabaseConnector);

                    // validate a valid Xml File Path 
                    validXmlFile = ValidateXmlFile(this.OutputXmlFilePath, false);

                    // if the sourceDatabaseConnectionPassed and the validXmlFile
                    if ((sourceDatabaseConnectionPassed) && (validXmlFile))
                    {
                        // Set to true
                        isValid = true;
                    }
                    else if ((!sourceDatabaseConnectionPassed) && (!validXmlFile))
                    {
                        // Set to true
                        this.InvalidReason = "The 'Source Database Connection' failed to connect and the 'Output Xml File' is not valid.";
                    }
                    else if (!sourceDatabaseConnectionPassed)
                    {
                        // Set to true
                        this.InvalidReason = "The 'Source Database Connection' failed to connect.";
                    }
                    else if (!validXmlFile)
                    {
                        // Set to true
                        this.InvalidReason = "The 'Output Xml File' is not valid.";
                    }
                }
                else if ((!this.HasSourceDatabaseConnectionString) && (!HasOutputXmlFilePath))
                {
                    // Set to true
                    this.InvalidReason = "The 'Source Database Connection' must be set and 'Output Xml File' must be set.";
                }
                else if (!this.HasSourceDatabaseConnectionString)
                {
                    // Set to true
                    this.InvalidReason = "The 'Source Database Connection' must be set.";
                }
                else if (!this.HasOutputXmlFilePath)
                {
                    // Set to true
                    this.InvalidReason = "The 'Output Xml File' must be set.";
                }
                
                // return value
                return isValid;
            }
            #endregion
            
            #region ValidateTwoSQLDatabases()
            /// <summary>
            /// This method returns the Two SQL Databases
            /// </summary>
            public bool ValidateTwoSQLDatabases()
            {
                // initial value
                bool isValid = false;

                // if the SourceDatabaseConnectionString and the TargetDatabaseConnectionString
                if ((this.HasSourceDatabaseConnectionString) && (this.HasTargetDatabaseConnectionString))
                {
                    // Create a new instance of a 'SQLDatabaseConnector' object.
                    this.SourceDatabaseConnector = new SQLDatabaseConnector();
                    this.TargetDatabaseConnector = new SQLDatabaseConnector();

                    // Set the Source & Target ConnectionString
                    this.SourceDatabaseConnector.ConnectionString = this.SourceDatabaseConnectionString;
                    this.TargetDatabaseConnector.ConnectionString = this.TargetDatabaseConnectionString;

                    // test the sourceConnectionTested
                    bool sourceConnectionTested = SQLDatabaseTester.TestDatabaseConnection(this.SourceDatabaseConnector);
                    bool targetConnectionTested = SQLDatabaseTester.TestDatabaseConnection(this.TargetDatabaseConnector);

                    // if both connections tested
                    if ((sourceConnectionTested) && (targetConnectionTested))
                    {
                        // this is a valid connection
                        isValid = true;
                    }
                    else if ((!sourceConnectionTested) && (targetConnectionTested))
                    {
                        // Set the InvalidReason
                        this.InvalidReason = "The source and target connections failed to connect.";
                    }
                    else if (!sourceConnectionTested)
                    {
                        // Set the InvalidReason
                        this.InvalidReason = "The source connection failed to connect.";
                    }
                    else
                    {
                        // The Target Connection Failed
                        this.InvalidReason = "The target connection failed to connect.";
                    }
                }
                else if ((!this.HasSourceDatabaseConnectionString) && (!this.HasTargetDatabaseConnectionString))
                {  
                    // Set the InvalidReason
                    this.InvalidReason = "The 'Source Connection String' and the 'Target Connection String' must both be set";
                }
                else if (!this.HasSourceDatabaseConnectionString)
                {
                    // Set the InvalidReason
                    this.InvalidReason = "The 'Source Connection String' must be set";
                }
                else if (!this.HasTargetDatabaseConnectionString)
                {
                    // Set the InvalidReason
                    this.InvalidReason = "The 'Target Connection String' must be set";
                }
                
                // return value
                return isValid;
            }
            #endregion
            
            #region ValidateXmlFile(string filePath, bool fileMustExist)
            /// <summary>
            /// This method returns the Xml File
            /// </summary>
            public bool ValidateXmlFile(string xmlFilePath, bool fileMustExist)
            {
                // initial value
                bool validXmlFile = false;

                // if the SourceXmlFilePath exists
                if (TextHelper.Exists(xmlFilePath))
                {
                    // Create a new instance of a 'FileInfo' object.
                    FileInfo fileInfo = new FileInfo(xmlFilePath);

                    // if the extensio nis .xml
                    if (fileInfo.Extension == ".xml")
                    {
                        // for now set this to true; I think the Source Database needs to be loaded here by Xml
                        // And set to true if the Source Database is loaded
                        validXmlFile = true;
                    }

                    // if this is a validXmlFile
                    if (validXmlFile)
                    {
                        // if the file must exist
                        if (fileMustExist)
                        {
                            // if the file does not exist
                            if (!File.Exists(xmlFilePath))
                            {
                                // This is not valid
                                validXmlFile = false;
                            }
                        }
                    }
                }
                
                // return value
                return validXmlFile;
            }
            #endregion
            
            #region ValidateXmlFileAndSQLDatabase()
            /// <summary>
            /// This method returns the Xml File And SQL Database
            /// </summary>
            public bool ValidateXmlFileAndSQLDatabase()
            {
                // initial value
                bool isValid = false;

                // local
                bool targetDatabaseConnectionPassed = false;
                bool sourceXmlFileIsValid = false;

                // if the SourceXmlFilePath exists and the TargetDatabaseConnectionString exists
                if ((this.HasSourceXmlFilePath) && (this.HasTargetDatabaseConnectionString))
                {
                    // Create The TargetDatabaseConnector
                    this.targetDatabaseConnector = new SQLDatabaseConnector();

                    // Set the ConnectionString
                    this.TargetDatabaseConnector.ConnectionString = this.TargetDatabaseConnectionString;

                    // test the TargetDatabaseConnector
                    targetDatabaseConnectionPassed = SQLDatabaseTester.TestDatabaseConnection(this.TargetDatabaseConnector);

                    // set the sourceXmlFileIsValid
                    sourceXmlFileIsValid = ValidateXmlFile(this.SourceXmlFilePath, true);
                    
                    // For now set this to valid, the Xml
                    isValid = ((targetDatabaseConnectionPassed) && (sourceXmlFileIsValid));

                    // if the value for isValid is false
                    if (!isValid)
                    {
                        // if the TargetDatabaseConnectionPassed is false and the sourceXmlFile is not valid
                        if ((!targetDatabaseConnectionPassed) && (!sourceXmlFileIsValid))
                        {
                            // The Source Xml File is not valid
                            this.InvalidReason = "The 'Source Xml File' is not valid and the 'Target Database Connection' failed to connect";
                        }
                        else if (!targetDatabaseConnectionPassed)
                        {
                            // The Source Xml File is not valid
                            this.InvalidReason = "The 'Target Database Connection' failed to connect";
                        }
                        else
                        {
                            // The Source Xml File is not valid
                            this.InvalidReason = "The 'Source Xml File' is not valid";
                        }
                    }
                }
                else if ((!this.HasTargetDatabaseConnectionString) && (!sourceXmlFileIsValid))
                {
                    // If the InvalidReason
                    this.InvalidReason = "The 'Target Connection String' and the 'Source Xml File' must both be set";
                }
                else if (!this.HasTargetDatabaseConnectionString)
                {
                    // If the InvalidReason
                    this.InvalidReason = "The 'Target Connection String' must be set.";
                }
                else if (!this.HasSourceXmlFilePath)
                {
                    // If the InvalidReason
                    this.InvalidReason = "The 'Source Xml File' must be set";
                }
                
                // return value
                return isValid;
            }
            #endregion
            
        #endregion

        #region Properties

            #region CompareType
            /// <summary>
            /// This property gets or sets the value for 'CompareType'.
            /// </summary>
            public CompareTypeEnum CompareType
            {
                get { return compareType; }
                set { compareType = value; }
            }
            #endregion
            
            #region HasOutputXmlFilePath
            /// <summary>
            /// This property returns true if the 'OutputXmlFilePath' exists.
            /// </summary>
            public bool HasOutputXmlFilePath
            {
                get
                {
                    // initial value
                    bool hasOutputXmlFilePath = (!String.IsNullOrEmpty(this.OutputXmlFilePath));
                    
                    // return value
                    return hasOutputXmlFilePath;
                }
            }
            #endregion
            
            #region HasSourceDatabaseConnectionString
            /// <summary>
            /// This property returns true if the 'SourceDatabaseConnectionString' exists.
            /// </summary>
            public bool HasSourceDatabaseConnectionString
            {
                get
                {
                    // initial value
                    bool hasSourceDatabaseConnectionString = (!String.IsNullOrEmpty(this.SourceDatabaseConnectionString));
                    
                    // return value
                    return hasSourceDatabaseConnectionString;
                }
            }
            #endregion
            
            #region HasSourceXmlFilePath
            /// <summary>
            /// This property returns true if the 'SourceXmlFilePath' exists.
            /// </summary>
            public bool HasSourceXmlFilePath
            {
                get
                {
                    // initial value
                    bool hasSourceXmlFilePath = (!String.IsNullOrEmpty(this.SourceXmlFilePath));
                    
                    // return value
                    return hasSourceXmlFilePath;
                }
            }
            #endregion
            
            #region HasTargetDatabaseConnectionString
            /// <summary>
            /// This property returns true if the 'TargetDatabaseConnectionString' exists.
            /// </summary>
            public bool HasTargetDatabaseConnectionString
            {
                get
                {
                    // initial value
                    bool hasTargetDatabaseConnectionString = (!String.IsNullOrEmpty(this.TargetDatabaseConnectionString));
                    
                    // return value
                    return hasTargetDatabaseConnectionString;
                }
            }
            #endregion
            
            #region InvalidReason
            /// <summary>
            /// This property gets or sets the value for 'InvalidReason'.
            /// </summary>
            public string InvalidReason
            {
                get { return invalidReason; }
                set { invalidReason = value; }
            }
            #endregion
            
            #region OutputXmlFilePath
            /// <summary>
            /// This property gets or sets the value for 'OutputXmlFilePath'.
            /// </summary>
            public string OutputXmlFilePath
            {
                get { return outputXmlFilePath; }
                set { outputXmlFilePath = value; }
            }
            #endregion
            
            #region SourceDatabaseConnectionString
            /// <summary>
            /// This property gets or sets the value for 'SourceDatabaseConnectionString'.
            /// </summary>
            public string SourceDatabaseConnectionString
            {
                get { return sourceDatabaseConnectionString; }
                set { sourceDatabaseConnectionString = value; }
            }
            #endregion
            
            #region SourceDatabaseConnector
            /// <summary>
            /// This property gets or sets the value for 'SourceDatabaseConnector'.
            /// </summary>
            public SQLDatabaseConnector SourceDatabaseConnector
            {
                get { return sourceDatabaseConnector; }
                set { sourceDatabaseConnector = value; }
            }
            #endregion
            
            #region SourceXmlFilePath
            /// <summary>
            /// This property gets or sets the value for 'SourceXmlFilePath'.
            /// </summary>
            public string SourceXmlFilePath
            {
                get { return sourceXmlFilePath; }
                set { sourceXmlFilePath = value; }
            }
            #endregion
            
            #region TargetDatabaseConnectionString
            /// <summary>
            /// This property gets or sets the value for 'TargetDatabaseConnectionString'.
            /// </summary>
            public string TargetDatabaseConnectionString
            {
                get { return targetDatabaseConnectionString; }
                set { targetDatabaseConnectionString = value; }
            }
            #endregion
            
            #region TargetDatabaseConnector
            /// <summary>
            /// This property gets or sets the value for 'TargetDatabaseConnector'.
            /// </summary>
            public SQLDatabaseConnector TargetDatabaseConnector
            {
                get { return targetDatabaseConnector; }
                set { targetDatabaseConnector = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
