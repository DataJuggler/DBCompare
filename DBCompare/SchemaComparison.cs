

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataJuggler.Net6;

#endregion

namespace DBCompare
{

    #region class SchemaComparison
    /// <summary>
    /// This class is used to contain the differences between two databases.
    /// </summary>
    public class SchemaComparison
    {
        
        #region Private Variables
        private bool isEqual;
        private List<SchemaDifference> schemaDifferences;
        private Database sourceDatabase;
        private Database targetDatabase;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a SchemaComparison object.
        /// </summary>
        public SchemaComparison()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Methods
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Create the ChangedTables collection
                this.SchemaDifferences = new List<SchemaDifference>();
            }
            #endregion
            
        #endregion

        #region Properties
            
            #region HasSchemaDifferences
            /// <summary>
            /// This property returns true if this object has a 'SchemaDifferences'.
            /// </summary>
            public bool HasSchemaDifferences
            {
                get
                {
                    // initial value
                    bool hasSchemaDifferences = (this.SchemaDifferences != null);
                    
                    // return value
                    return hasSchemaDifferences;
                }
            }
            #endregion
            
            #region HasSourceDatabase
            /// <summary>
            /// This property returns true if this object has a 'SourceDatabase'.
            /// </summary>
            public bool HasSourceDatabase
            {
                get
                {
                    // initial value
                    bool hasSourceDatabase = (this.SourceDatabase != null);
                    
                    // return value
                    return hasSourceDatabase;
                }
            }
            #endregion
            
            #region HasTargetDatabase
            /// <summary>
            /// This property returns true if this object has a 'TargetDatabase'.
            /// </summary>
            public bool HasTargetDatabase
            {
                get
                {
                    // initial value
                    bool hasTargetDatabase = (this.TargetDatabase != null);
                    
                    // return value
                    return hasTargetDatabase;
                }
            }
            #endregion
            
            #region IsEqual
            /// <summary>
            /// This property gets or sets the value for 'IsEqual'.
            /// </summary>
            public bool IsEqual
            {
                get { return isEqual; }
                set { isEqual = value; }
            }
            #endregion
            
            #region SchemaDifferences
            /// <summary>
            /// This property gets or sets the value for 'SchemaDifferences'.
            /// </summary>
            public List<SchemaDifference> SchemaDifferences
            {
                get { return schemaDifferences; }
                set { schemaDifferences = value; }
            }
            #endregion
            
            #region SourceDatabase
            /// <summary>
            /// This property gets or sets the value for 'SourceDatabase'.
            /// </summary>
            public Database SourceDatabase
            {
                get { return sourceDatabase; }
                set { sourceDatabase = value; }
            }
            #endregion
            
            #region TargetDatabase
            /// <summary>
            /// This property gets or sets the value for 'TargetDatabase'.
            /// </summary>
            public Database TargetDatabase
            {
                get { return targetDatabase; }
                set { targetDatabase = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
