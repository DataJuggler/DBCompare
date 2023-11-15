

#region using statements

using DataJuggler.UltimateHelper;
using DataJuggler.NET8;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime7.Objects;
using XmlMirror.Runtime7.Util;
using System.Text;

#endregion

namespace DBCompare.Xml.Writers
{

    #region class TablesWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'DataTable' objects to xml.
    /// </summary>
    public class TablesWriter
    {

        #region Methods

            #region ExportList(List<DataTable> tablesWriter, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'DataTable' objects to xml
            // </Summary>
            public string ExportList(List<DataTable> tablesWriter, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string tablesWriterXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open DataTable Node
                sb.Append("<Tables>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more DataTable objects
                if ((tablesWriter != null) && (tablesWriter.Count > 0))
                {
                    // Iterate the tablesWriter collection
                    foreach (DataTable dataTable  in tablesWriter)
                    {
                        // Get the xml for this tablesWriter
                        tablesWriterXml = ExportDataTable(dataTable, indent + 2);

                        // If the tablesWriterXml string exists
                        if (TextHelper.Exists(tablesWriterXml))
                        {
                            // Add this tablesWriter to the xml
                            sb.Append(tablesWriterXml);
                        }
                    }
                }

                // Add the close TablesWriter Node
                sb.Append(indentString);
                sb.Append("</Tables>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportDataTable(DataTable dataTable, int indent = 0)
            // <Summary>
            // This method is used to export a DataTable object to xml.
            // </Summary>
            public string ExportDataTable(DataTable dataTable, int indent = 0)
            {
                // initial value
                string dataTableXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the dataTable object exists
                if (NullHelper.Exists(dataTable))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open dataTable node
                    sb.Append("<DataTable>" + Environment.NewLine);

                    // Write out each property

                    // (Manually added Name to the top so you do not have to scroll down to find the name
                    
                    // Write out the value for Name

                    sb.Append(indentString2);
                    sb.Append("<Name>" + dataTable.Name + "</Name>" + Environment.NewLine);

                    // Write out the value for CheckConstraints

                    // Create the CheckConstraintsWriter
                    CheckConstraintsWriter checkConstraintsWriter = new CheckConstraintsWriter();

                    // Export the CheckConstraints collection to xml
                    string checkConstraintXml = checkConstraintsWriter.ExportList(dataTable.CheckConstraints, indent + 2);
                    sb.Append(checkConstraintXml);
                    sb.Append(Environment.NewLine);

                    // Write out the value for Fields

                    // Create the FieldsWriter
                    FieldsWriter fieldsWriter = new FieldsWriter();

                    // Export the Fields collection to xml
                    string dataFieldXml = fieldsWriter.ExportList(dataTable.Fields, indent + 2);
                    sb.Append(dataFieldXml);
                    sb.Append(Environment.NewLine);
                    
                    // Write out the value for ForeignKeys
                    
                    // Create the foreignKeyWriter
                    ForeignKeysWriter foreignKeyWriter = new ForeignKeysWriter();

                    // Write out the value for ForeignKeys
                    string foreignKeyXml = foreignKeyWriter.ExportList(dataTable.ForeignKeys, indent + 2);
                    sb.Append(foreignKeyXml);
                    sb.Append(Environment.NewLine);

                    // Write out the value for Indexes

                    // Create the IndexesWriter
                    IndexesWriter indexesWriter = new IndexesWriter();

                    // Export the Indexes collection to xml
                    string dataIndexXml = indexesWriter.ExportList(dataTable.Indexes, indent + 2);
                    sb.Append(dataIndexXml);
                    sb.Append(Environment.NewLine);

                    // Write out the value for IsView

                    sb.Append(indentString2);
                    sb.Append("<IsView>" + dataTable.IsView + "</IsView>" + Environment.NewLine);

                  

                    // Write out the value for SchemaName

                    sb.Append(indentString2);
                    sb.Append("<SchemaName>" + dataTable.SchemaName + "</SchemaName>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close dataTable node
                    sb.Append("</DataTable>" + Environment.NewLine);

                    // set the return value
                    dataTableXml = sb.ToString();
                }
                // return value
                return dataTableXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
