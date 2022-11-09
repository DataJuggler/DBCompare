

#region using statements

using DataJuggler.UltimateHelper;
using DataJuggler.Net7;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime7.Objects;
using XmlMirror.Runtime7.Util;
using System.Text;

#endregion

namespace DBCompare.Xml.Writers
{

    #region class DatabasesWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'Database' objects to xml.
    /// </summary>
    public class DatabasesWriter
    {

        #region Methods

            #region ExportList(List<Database> databasesWriter, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'Database' objects to xml
            // </Summary>
            public string ExportList(List<Database> databasesWriter, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string databasesWriterXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open Database Node
                sb.Append("<Databases>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more Database objects
                if ((databasesWriter != null) && (databasesWriter.Count > 0))
                {
                    // Iterate the databasesWriter collection
                    foreach (Database database  in databasesWriter)
                    {
                        // Get the xml for this databasesWriter
                        databasesWriterXml = ExportDatabase(database, indent + 2);

                        // If the databasesWriterXml string exists
                        if (TextHelper.Exists(databasesWriterXml))
                        {
                            // Add this databasesWriter to the xml
                            sb.Append(databasesWriterXml);
                        }
                    }
                }

                // Add the close DatabasesWriter Node
                sb.Append(indentString);
                sb.Append("</Databases>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportDatabase(Database database, int indent = 0)
            // <Summary>
            // This method is used to export a Database object to xml.
            // </Summary>
            public string ExportDatabase(Database database, int indent = 0)
            {
                // initial value
                string databaseXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the database object exists
                if (NullHelper.Exists(database))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open database node
                    sb.Append("<Database>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for Functions

                    // Create the FunctionsWriter
                    FunctionsWriter functionsWriter = new FunctionsWriter();

                    // Export the Functions collection to xml
                    string functionXml = functionsWriter.ExportList(database.Functions, indent + 2);
                    sb.Append(functionXml);
                    sb.Append(Environment.NewLine);

                    // Write out the value for Name

                    sb.Append(indentString2);
                    sb.Append("<Name>" + database.Name + "</Name>" + Environment.NewLine);

                    // Write out the value for StoredProcedures

                    // Create the StoredProceduresWriter
                    StoredProceduresWriter storedProceduresWriter = new StoredProceduresWriter();

                    // Export the StoredProcedures collection to xml
                    string storedProcedureXml = storedProceduresWriter.ExportList(database.StoredProcedures, indent + 2);
                    sb.Append(storedProcedureXml);
                    sb.Append(Environment.NewLine);

                    // Write out the value for Tables

                    // Create the TablesWriter
                    TablesWriter tablesWriter = new TablesWriter();

                    // Export the Tables collection to xml
                    string dataTableXml = tablesWriter.ExportList(database.Tables, indent + 2);
                    sb.Append(dataTableXml);
                    sb.Append(Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close database node
                    sb.Append("</Database>" + Environment.NewLine);

                    // set the return value
                    databaseXml = sb.ToString();
                }
                // return value
                return databaseXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
