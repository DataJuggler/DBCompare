

#region using statements

using DataJuggler.UltimateHelper;
using DataJuggler.Net5;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime5.Objects;
using XmlMirror.Runtime5.Util;
using System.Text;

#endregion

namespace DBCompare.Xml.Writers
{

    #region class RowsWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'DataRow' objects to xml.
    /// </summary>
    public class RowsWriter
    {

        #region Methods

            #region ExportList(List<DataRow> rowsWriter, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'DataRow' objects to xml
            // </Summary>
            public string ExportList(List<DataRow> rowsWriter, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string rowsWriterXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open DataRow Node
                sb.Append("<Rows>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more DataRow objects
                if ((rowsWriter != null) && (rowsWriter.Count > 0))
                {
                    // Iterate the rowsWriter collection
                    foreach (DataRow dataRow  in rowsWriter)
                    {
                        // Get the xml for this rowsWriter
                        rowsWriterXml = ExportDataRow(dataRow, indent + 2);

                        // If the rowsWriterXml string exists
                        if (TextHelper.Exists(rowsWriterXml))
                        {
                            // Add this rowsWriter to the xml
                            sb.Append(rowsWriterXml);
                        }
                    }
                }

                // Add the close RowsWriter Node
                sb.Append(indentString);
                sb.Append("</Rows>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportDataRow(DataRow dataRow, int indent = 0)
            // <Summary>
            // This method is used to export a DataRow object to xml.
            // </Summary>
            public string ExportDataRow(DataRow dataRow, int indent = 0)
            {
                // initial value
                string dataRowXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the dataRow object exists
                if (NullHelper.Exists(dataRow))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open dataRow node
                    sb.Append("<DataRow>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for Changes

                    sb.Append(indentString2);
                    sb.Append("<Changes>" + dataRow.Changes + "</Changes>" + Environment.NewLine);

                    // Write out the value for Delete

                    sb.Append(indentString2);
                    sb.Append("<Delete>" + dataRow.Delete + "</Delete>" + Environment.NewLine);

                    // Write out the value for Fields

                    // Create the FieldsWriter
                    FieldsWriter fieldsWriter = new FieldsWriter();

                    // Export the Fields collection to xml
                    string dataFieldXml = fieldsWriter.ExportList(dataRow.Fields, indent + 2);
                    sb.Append(dataFieldXml);
                    sb.Append(Environment.NewLine);

                    // Write out the value for Index

                    sb.Append(indentString2);
                    sb.Append("<Index>" + dataRow.Index + "</Index>" + Environment.NewLine);

                    // Write out the value for ParentTable

                    sb.Append(indentString2);
                    sb.Append("<ParentTable>" + dataRow.ParentTable + "</ParentTable>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close dataRow node
                    sb.Append("</DataRow>" + Environment.NewLine);

                    // set the return value
                    dataRowXml = sb.ToString();
                }
                // return value
                return dataRowXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
