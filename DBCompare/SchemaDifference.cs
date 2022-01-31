

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataJuggler.Net6;
using DBCompare.Enumerations;

#endregion

namespace DBCompare
{

    #region class SchemaDifference
    /// <summary>
    /// This class is used so the SchemaDifference doesn't have to be parsed from a string
    /// like my original bad design.
    /// </summary>
    public class SchemaDifference
    {
        
        #region Private Variables
        private string message;
        private DataTable table;
        private DataField field;
        private DifferenceTypeEnum differenceType;
        #endregion

        #region Properties
        
            #region DifferenceType
            /// <summary>
            /// This property gets or sets the value for 'DifferenceType'.
            /// </summary>
            public DifferenceTypeEnum DifferenceType
            {
                get { return differenceType; }
                set { differenceType = value; }
            }
            #endregion
            
            #region Field
            /// <summary>
            /// This property gets or sets the value for 'Field'.
            /// </summary>
            public DataField Field
            {
                get { return field; }
                set { field = value; }
            }
            #endregion
            
            #region HasField
            /// <summary>
            /// This property returns true if this object has a 'Field'.
            /// </summary>
            public bool HasField
            {
                get
                {
                    // initial value
                    bool hasField = (this.Field != null);
                    
                    // return value
                    return hasField;
                }
            }
            #endregion
            
            #region HasTable
            /// <summary>
            /// This property returns true if this object has a 'Table'.
            /// </summary>
            public bool HasTable
            {
                get
                {
                    // initial value
                    bool hasTable = (this.Table != null);
                    
                    // return value
                    return hasTable;
                }
            }
            #endregion
            
            #region Message
            /// <summary>
            /// This property gets or sets the value for 'Message'.
            /// </summary>
            public string Message
            {
                get { return message; }
                set { message = value; }
            }
            #endregion
            
            #region Table
            /// <summary>
            /// This property gets or sets the value for 'Table'.
            /// </summary>
            public DataTable Table
            {
                get { return table; }
                set { table = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
