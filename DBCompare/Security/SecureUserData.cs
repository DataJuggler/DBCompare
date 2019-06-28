

#region using statements

using System;
using System.Configuration;
using System.Drawing;
using DBCompare.Enumerations;
using DataJuggler.Core.UltimateHelper;

#endregion

namespace DBCompare.Security
{

    #region class SecureUserData
    /// <summary>
    /// This class is used to store values such as PlayerName and Password, and settings such as
    /// preferred club & room. Game settings and options as well as timer preferences may be stored here.
    /// </summary>
    public class SecureUserData : ApplicationSettingsBase
    {  

        #region Properties

            #region CompareCount
            /// <summary>
            /// This property gets or sets the value for CompareCount
            /// </summary>
            [UserScopedSetting()]
            public int CompareCount
            {
                get
                {
                    // initial value
                    int compareCount = 0;

                    // if the CompareCount exists
                    if (this["CompareCount"] != null)
                    {
                        // set the return value
                        compareCount = NumericHelper.ParseInteger(this["CompareCount"].ToString(), 0, -1);
                    }

                    // return the value for CompareCount
                    return compareCount;
                }
                set
                {
                    // set the value for CompareCount
                    this["CompareCount"] = value;
                }   
            }
            #endregion

            #region CompareType
            /// <summary>
            /// This property gets or sets the value for CompareType
            /// </summary>
            [UserScopedSetting()]
            public string CompareType
            {
                get
                {
                    // initial value
                    string compareType = CompareTypeEnum.CompareTwoSQLDatabases.ToString(); 

                    // if the CompareType exists
                    if (this["CompareType"] != null)
                    {
                        // set the return value
                        compareType = (string) this["CompareType"];
                    }

                    // return the value for CompareType
                    return compareType;
                }
                set
                {
                    // set the value for CompareType
                    this["CompareType"] = value;
                }   
            }
            #endregion

            #region CreateXmlFile
            /// <summary>
            /// This property gets or sets the value for CreateXmlFile
            /// </summary>
            [UserScopedSetting()]
            [DefaultSettingValue("False")]
            public bool CreateXmlFile
            {
                get
                {
                    // return the value for RemoteComparison
                    return (bool) this["CreateXmlFile"];
                }
                set
                {
                    // set the value for RemoteComparison
                    this["CreateXmlFile"] = value;
                }   
            }
            #endregion

            #region IgnoreDiagramProcedures
            /// <summary>
            /// This property gets or sets the value for IgnoreDiagramProcedures
            /// </summary>
            [UserScopedSetting()]
            [DefaultSettingValue("True")]
            public bool IgnoreDiagramProcedures
            {
                get
                {
                    // return the value for IgnoreDiagramProcedures
                    return (bool) this["IgnoreDiagramProcedures"];
                }
                set
                {
                    // set the value
                    this["IgnoreDiagramProcedures"] = value;
                }   
            }
            #endregion

            #region IgnoreDataSync
            /// <summary>
            /// This property gets or sets the value for IgnoreDataSync
            /// </summary>
            [UserScopedSetting()]
            [DefaultSettingValue("True")]
            public bool IgnoreDataSync
            {
                get
                {
                    // return the value for IgnoreDataSync
                    return (bool) this["IgnoreDataSync"];
                }
                set
                {
                    // set the value
                    this["IgnoreDataSync"] = value;
                }   
            }
            #endregion

            #region IgnoreFirewallRules
            /// <summary>
            /// This property gets or sets the value for IgnoreFirewallRules
            /// </summary>
            [UserScopedSetting()]
            [DefaultSettingValue("True")]
            public bool IgnoreFirewallRules
            {
                get
                {
                    // return the value for IgnoreFirewallRules
                    return (bool) this["IgnoreFirewallRules"];
                }
                set
                {
                    // set the value
                    this["IgnoreFirewallRules"] = value;
                }   
            }
            #endregion

            #region OutputXmlFilePath
            /// <summary>
            /// This property gets or sets the value for 'OutputXmlFilePath'
            /// </summary>
            [UserScopedSetting()]
            public string OutputXmlFilePath
            {
                get
                {  
                    // initial value
                    string outputXmlFilePath = "";
                        
                    // if the OutputXmlFilePath exists
                    if (this["OutputXmlFilePath"] != null)
                    {
                        // set the outputFilePath
                        outputXmlFilePath = this["OutputXmlFilePath"].ToString();
                    }

                    // return value
                    return outputXmlFilePath;
                }
                set
                {  
                    // set the value
                    this["OutputXmlFilePath"] = value;
                }
            }
            #endregion
            
            #region RemoteComparison
            /// <summary>
            /// This property gets or sets the value for RemoteComparison
            /// </summary>
            [UserScopedSetting()]
            [DefaultSettingValue("False")]
            public bool RemoteComparison
            {
                get
                {
                    // return the value for RemoteComparison
                    return (bool) this["RemoteComparison"];
                }
                set
                {
                    // set the value for RemoteComparison
                    this["RemoteComparison"] = value;
                }   
            }
            #endregion
            
            #region StoreConnectionStrings
            /// <summary>
            /// This property gets or sets the value for StoreConnectionStrings
            /// </summary>
            [UserScopedSetting()]
            [DefaultSettingValue("True")]
            public bool StoreConnectionStrings
            {
                get
                {
                    // return the value for StoreConnectionStrings
                    return (bool) this["StoreConnectionStrings"];
                }
                set
                {
                    // set the value
                    this["StoreConnectionStrings"] = value;

                    // if set to false
                    if (!value)
                    {
                        // null out
                        this.SourceConnectionString = null;
                        this.TargetConnectionString = null;
                    }
                }   
            }
            #endregion

            #region SourceConnectionString
            /// <summary>
            /// This property gets or sets the value for 'SourceConnectionString'
            /// </summary>
            [UserScopedSetting()]
            public string SourceConnectionString
            {
                get
                {
                    // initial value
                    string sourceConnectionString = "";

                    // if this property is not true, nothing is saved or returned
                    if (this.StoreConnectionStrings)
                    {
                        // if the SourceConnectionString exists
                        if (this["SourceConnectionString"] != null)
                        {
                            // set the sourceConnectionString
                            sourceConnectionString = this["SourceConnectionString"].ToString();
                        }
                    }

                    // return value
                    return sourceConnectionString;
                }
                set
                {
                    // if this property is not true, nothing is saved or returned
                    if (this.StoreConnectionStrings)
                    {
                        // set the value
                        this["SourceConnectionString"] = value;
                    }
                    else
                    {
                        // set the value
                        this["SourceConnectionString"] = null;
                    }
                }
            }
            #endregion

            #region SourceXmlFilePath
            /// <summary>
            /// This property gets or sets the value for 'SourceXmlFilePath'
            /// </summary>
            [UserScopedSetting()]
            public string SourceXmlFilePath
            {
                get
                {  
                    // initial value
                    string sourceXmlFilePath = "";
                        
                    // if the OutputXmlFilePath exists
                    if (this["SourceXmlFilePath"] != null)
                    {
                        // set the sourceXmlFilePath
                        sourceXmlFilePath = this["SourceXmlFilePath"].ToString();
                    }

                    // return value
                    return sourceXmlFilePath;
                }
                set
                {  
                    // set the value
                    this["SourceXmlFilePath"] = value;
                }
            }
            #endregion

            #region TargetConnectionString
            /// <summary>
            /// This property gets or sets the value for 'TargetConnectionString'
            /// </summary>
            [UserScopedSetting()]
            public string TargetConnectionString
            {
                get
                {
                    // initial value
                    string targetConnectionString = "";

                    // if this property is not true, nothing is saved or returned
                    if (this.StoreConnectionStrings)
                    {
                        // if the TargetConnectionString exists
                        if (this["TargetConnectionString"] != null)
                        {
                            // set the targetConnectionString
                            targetConnectionString = this["TargetConnectionString"].ToString();
                        }
                    }

                    // return value
                    return targetConnectionString;
                }
                set
                {
                    // if this property is not true, nothing is saved or returned
                    if (this.StoreConnectionStrings)
                    {
                        // set the value
                        this["TargetConnectionString"] = value;
                    }
                    else
                    {
                        // set the value
                        this["TargetConnectionString"] = null;
                    }
                }
            }
            #endregion

        #endregion
        
    }
    #endregion

}
