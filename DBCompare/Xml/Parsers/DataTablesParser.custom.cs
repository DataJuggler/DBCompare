

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Net;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime.Objects;
using XmlMirror.Runtime.Util;

#endregion

namespace DBCompare.Xml.Parsers
{

    #region class DataTablesParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'DataTable' objects.
    /// </summary>
    public partial class DataTablesParser : ParserBaseClass
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

            #region Parsing(XmlNode xmlNode, ref DataTable dataTable)
            /// <summary>
            /// This event is fired when a single object is initialized.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <param name="dataTable"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsing(XmlNode xmlNode, ref DataTable dataTable)
            {
                // initial value
                bool cancel = false;

                // Add any pre processing code here. Set cancel to true to abort adding this object.

                // return value
                return cancel;
            }
            #endregion

            #region Parsed(XmlNode xmlNode, ref DataTable dataTable)
            /// <summary>
            /// This event is fired AFTER the dataTable is parsed.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <param name="dataTable"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsed(XmlNode xmlNode, ref DataTable dataTable)
            {
                // initial value
                bool cancel = false;

                // If the dataTable object exists
                if (NullHelper.Exists(xmlNode, dataTable))
                {
                    // Create a new instance of an 'IndexesParser' object.
                    IndexesParser indexesParser = new IndexesParser();

                    // Parse the Indexes
                    dataTable.Indexes = indexesParser.ParseDataIndexs(xmlNode);

                    // Create a new instance of a 'DataFieldsParser' object.
                    DataFieldsParser dataFieldsParser = new DataFieldsParser();

                    // Parse the Fields
                    dataTable.Fields = dataFieldsParser.ParseDataFields(xmlNode);

                    // Create a new instance of a 'CheckConstraintsParser' object.
                    CheckConstraintsParser checkConstraintsParser = new CheckConstraintsParser();

                    // Parse the CheckConstraints
                    dataTable.CheckConstraints = checkConstraintsParser.ParseCheckConstraints(xmlNode);

                    // Create a new instance of a 'ForeignKeyConstraintsParser' object.
                    ForeignKeyConstraintsParser foreignKeysParser = new ForeignKeyConstraintsParser();

                    // Parse the ForeignKeys
                    dataTable.ForeignKeys = foreignKeysParser.ParseForeignKeyConstraints(xmlNode);
                }

                // return value
                return cancel;
            }
            #endregion

        #endregion

    }
    #endregion

}
