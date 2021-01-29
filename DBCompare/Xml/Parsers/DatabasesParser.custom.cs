

#region using statements

using DataJuggler.UltimateHelper;
using DataJuggler.Net5;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime5.Objects;
using XmlMirror.Runtime5.Util;

#endregion

namespace DBCompare.Xml.Parsers
{

    #region class DatabasesParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'Database' objects.
    /// </summary>
    public partial class DatabasesParser : ParserBaseClass
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

            #region Parsing(XmlNode xmlNode, ref Database database)
            /// <summary>
            /// This event is fired when a single object is initialized.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <param name="database"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsing(XmlNode xmlNode, ref Database database)
            {
                // initial value
                bool cancel = false;

                // Add any pre processing code here. Set cancel to true to abort adding this object.

                // return value
                return cancel;
            }
            #endregion

            #region Parsed(XmlNode xmlNode, ref Database database)
            /// <summary>
            /// This event is fired AFTER the database is parsed.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <param name="database"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsed(XmlNode xmlNode, ref Database database)
            {
                // initial value
                bool cancel = false;

                // Add any post processing code here. Set cancel to true to abort adding this object.
                if (NullHelper.Exists(database, xmlNode))
                {
                    // Parse the DataTables
                    DataTablesParser tablesParser = new DataTablesParser();

                    // Parse the DataTables
                    database.Tables = tablesParser.ParseDataTables(xmlNode);

                    // Create a new instance of a 'StoredProceduresParser' object.
                    StoredProceduresParser storedProcedureParser = new StoredProceduresParser();

                    // Load the stored procedures for this database
                    database.StoredProcedures = storedProcedureParser.ParseStoredProcedures(xmlNode);
                }

                // return value
                return cancel;
            }
            #endregion

        #endregion

    }
    #endregion

}
