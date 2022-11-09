

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

    #region class IndexesWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'DataIndex' objects to xml.
    /// </summary>
    public class IndexesWriter
    {

        #region Methods

            #region ExportList(List<DataIndex> indexesWriter, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'DataIndex' objects to xml
            // </Summary>
            public string ExportList(List<DataIndex> indexesWriter, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string indexesWriterXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open DataIndex Node
                sb.Append("<Indexes>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more DataIndex objects
                if ((indexesWriter != null) && (indexesWriter.Count > 0))
                {
                    // Iterate the indexesWriter collection
                    foreach (DataIndex dataIndex  in indexesWriter)
                    {
                        // Get the xml for this indexesWriter
                        indexesWriterXml = ExportDataIndex(dataIndex, indent + 2);

                        // If the indexesWriterXml string exists
                        if (TextHelper.Exists(indexesWriterXml))
                        {
                            // Add this indexesWriter to the xml
                            sb.Append(indexesWriterXml);
                        }
                    }
                }

                // Add the close IndexesWriter Node
                sb.Append(indentString);
                sb.Append("</Indexes>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportDataIndex(DataIndex dataIndex, int indent = 0)
            // <Summary>
            // This method is used to export a DataIndex object to xml.
            // </Summary>
            public string ExportDataIndex(DataIndex dataIndex, int indent = 0)
            {
                // initial value
                string dataIndexXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the dataIndex object exists
                if (NullHelper.Exists(dataIndex))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open dataIndex node
                    sb.Append("<DataIndex>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for AllowPageLocks

                    sb.Append(indentString2);
                    sb.Append("<AllowPageLocks>" + dataIndex.AllowPageLocks + "</AllowPageLocks>" + Environment.NewLine);

                    // Write out the value for AllowRowLocks

                    sb.Append(indentString2);
                    sb.Append("<AllowRowLocks>" + dataIndex.AllowRowLocks + "</AllowRowLocks>" + Environment.NewLine);

                    // Write out the value for Clustered

                    sb.Append(indentString2);
                    sb.Append("<Clustered>" + dataIndex.Clustered + "</Clustered>" + Environment.NewLine);

                    // Write out the value for DataSpaceId

                    sb.Append(indentString2);
                    sb.Append("<DataSpaceId>" + dataIndex.DataSpaceId + "</DataSpaceId>" + Environment.NewLine);

                    // Write out the value for FillFactor

                    sb.Append(indentString2);
                    sb.Append("<FillFactor>" + dataIndex.FillFactor + "</FillFactor>" + Environment.NewLine);

                    // Write out the value for FilterDefinition

                    sb.Append(indentString2);
                    sb.Append("<FilterDefinition>" + dataIndex.FilterDefinition + "</FilterDefinition>" + Environment.NewLine);

                    // Write out the value for HasFilter

                    sb.Append(indentString2);
                    sb.Append("<HasFilter>" + dataIndex.HasFilter + "</HasFilter>" + Environment.NewLine);

                    // Write out the value for IgnoreDuplicateKey

                    sb.Append(indentString2);
                    sb.Append("<IgnoreDuplicateKey>" + dataIndex.IgnoreDuplicateKey + "</IgnoreDuplicateKey>" + Environment.NewLine);
                    
                    // Write out the value for IndexType

                    sb.Append(indentString2);
                    sb.Append("<IndexType>" + dataIndex.IndexType + "</IndexType>" + Environment.NewLine);

                    // Write out the value for IsDisabled

                    sb.Append(indentString2);
                    sb.Append("<IsDisabled>" + dataIndex.IsDisabled + "</IsDisabled>" + Environment.NewLine);

                    // Write out the value for IsHypothetical

                    sb.Append(indentString2);
                    sb.Append("<IsHypothetical>" + dataIndex.IsHypothetical + "</IsHypothetical>" + Environment.NewLine);

                    // Write out the value for IsPadded

                    sb.Append(indentString2);
                    sb.Append("<IsPadded>" + dataIndex.IsPadded + "</IsPadded>" + Environment.NewLine);

                    // Write out the value for IsPrimary

                    sb.Append(indentString2);
                    sb.Append("<IsPrimary>" + dataIndex.IsPrimary + "</IsPrimary>" + Environment.NewLine);

                    // Write out the value for IsUnique

                    sb.Append(indentString2);
                    sb.Append("<IsUnique>" + dataIndex.IsUnique + "</IsUnique>" + Environment.NewLine);

                    // Write out the value for IsUniqueConstraint

                    sb.Append(indentString2);
                    sb.Append("<IsUniqueConstraint>" + dataIndex.IsUniqueConstraint + "</IsUniqueConstraint>" + Environment.NewLine);

                    // Write out the value for Name

                    sb.Append(indentString2);
                    sb.Append("<Name>" + dataIndex.Name + "</Name>" + Environment.NewLine);

                    // Write out the value for TypeDescription

                    sb.Append(indentString2);
                    sb.Append("<TypeDescription>" + dataIndex.TypeDescription + "</TypeDescription>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close dataIndex node
                    sb.Append("</DataIndex>" + Environment.NewLine);

                    // set the return value
                    dataIndexXml = sb.ToString();
                }
                // return value
                return dataIndexXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
