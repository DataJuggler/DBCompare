

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Net;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime.Objects;
using XmlMirror.Runtime.Util;
using DataJuggler.Net.Enumerations;

#endregion

namespace DBCompare.Xml.Parsers
{

    #region class StoredProceduresParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'StoredProcedure' objects.
    /// </summary>
    public partial class StoredProceduresParser : ParserBaseClass
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

            #region Parsing(XmlNode xmlNode, ref StoredProcedure storedProcedure)
            /// <summary>
            /// This event is fired when a single object is initialized.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <param name="storedProcedure"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsing(XmlNode xmlNode, ref StoredProcedure storedProcedure)
            {
                // initial value
                bool cancel = false;

                // Add any pre processing code here. Set cancel to true to abort adding this object.

                // return value
                return cancel;
            }
            #endregion

            #region Parsed(XmlNode xmlNode, ref StoredProcedure storedProcedure)
            /// <summary>
            /// This event is fired AFTER the storedProcedure is parsed.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <param name="storedProcedure"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsed(XmlNode xmlNode, ref StoredProcedure storedProcedure)
            {
                // initial value
                bool cancel = false;

                // If the storedProcedure object exists
                if (NullHelper.Exists(storedProcedure))
                {
                    // Decode the text
                    storedProcedure.Text = XmlPatternHelper.Decode(storedProcedure.Text);

                    // Create a new instance of a 'StoredProcedureParametersParser' object.
                    StoredProcedureParametersParser parametersParser = new StoredProcedureParametersParser();

                    // load the parameters if available
                    storedProcedure.Parameters = parametersParser.ParseStoredProcedureParameters(xmlNode);

                    // Create a new instance of a 'DataFieldsParser' object.
                    ReturnSetSchemaParser returnSetSchemaParser = new ReturnSetSchemaParser();

                    // load the ReturnSetSchema if available
                    storedProcedure.ReturnSetSchema = returnSetSchemaParser.ParseDataFields(xmlNode);
                }

                // return value
                return cancel;
            }
            #endregion

        #endregion

    }
    #endregion

}
