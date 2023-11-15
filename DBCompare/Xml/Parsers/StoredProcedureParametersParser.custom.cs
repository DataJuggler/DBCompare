

#region using statements

using DataJuggler.NET8;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime7.Objects;
using XmlMirror.Runtime7.Util;
using DataJuggler.NET8.Enumerations;

#endregion

namespace DBCompare.Xml.Parsers
{

    #region class StoredProcedureParametersParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'StoredProcedureParameter' objects.
    /// </summary>
    public partial class StoredProcedureParametersParser : ParserBaseClass
    {

        #region Events

            #region Parsing(XmlNode xmlNode)
            /// <summary>
            /// This event is fired BEFORE the collection is initialized.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsing(XmlNode xmlNode)
            {
                // initial value
                bool cancel = false;

                // Add any pre processing code here. Set cancel to true to abort parsing this collection.

                // return value
                return cancel;
            }
            #endregion

            #region Parsing(XmlNode xmlNode, ref StoredProcedureParameter storedProcedureParameter)
            /// <summary>
            /// This event is fired when a single object is initialized.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <param name="storedProcedureParameter"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsing(XmlNode xmlNode, ref StoredProcedureParameter storedProcedureParameter)
            {
                // initial value
                bool cancel = false;

                // Add any pre processing code here. Set cancel to true to abort adding this object.

                // return value
                return cancel;
            }
            #endregion

            #region Parsed(XmlNode xmlNode, ref StoredProcedureParameter storedProcedureParameter)
            /// <summary>
            /// This event is fired AFTER the storedProcedureParameter is parsed.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <param name="storedProcedureParameter"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsed(XmlNode xmlNode, ref StoredProcedureParameter storedProcedureParameter)
            {
                // initial value
                bool cancel = false;

                // Add any post processing code here. Set cancel to true to abort adding this object.

                // return value
                return cancel;
            }
            #endregion

        #endregion
            
    }
    #endregion

}
