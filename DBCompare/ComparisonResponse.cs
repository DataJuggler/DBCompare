

#region using statements

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace DBCompare
{

    #region class ComparisonResponse
    /// <summary>
    /// This class is used to return info from any thing type of comparison.
    /// </summary>
    internal class ComparisonResponse
    {
        
        #region Private Variables
        private string invalidReason;
        private bool valid;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ComparisonResponse' object.
        /// </summary>
        public ComparisonResponse()
        {
            
        }
        #endregion
        
        #region Parameterized Constructor
        /// <summary>
        /// Create a new instance of a 'ComparisonResponse' object.
        /// </summary>
        public ComparisonResponse(bool isValid, string invalidReason)
        {
            // store the args
            Valid = isValid;
            InvalidReason = invalidReason;
        }
        #endregion
        
        #region Properties
            
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
            
            #region Valid
            /// <summary>
            /// This property gets or sets the value for 'Valid'.
            /// </summary>
            public bool Valid
            {
                get { return valid; }
                set { valid = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
