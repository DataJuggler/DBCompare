

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

    #region class CheckConstraintsWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'CheckConstraint' objects to xml.
    /// </summary>
    public class CheckConstraintsWriter
    {

        #region Methods

            #region ExportList(List<CheckConstraint> checkConstraintsWriter, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'CheckConstraint' objects to xml
            // </Summary>
            public string ExportList(List<CheckConstraint> checkConstraintsWriter, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string checkConstraintsWriterXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open CheckConstraint Node
                sb.Append("<CheckConstraints>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more CheckConstraint objects
                if ((checkConstraintsWriter != null) && (checkConstraintsWriter.Count > 0))
                {
                    // Iterate the checkConstraintsWriter collection
                    foreach (CheckConstraint checkConstraint  in checkConstraintsWriter)
                    {
                        // Get the xml for this checkConstraintsWriter
                        checkConstraintsWriterXml = ExportCheckConstraint(checkConstraint, indent + 2);

                        // If the checkConstraintsWriterXml string exists
                        if (TextHelper.Exists(checkConstraintsWriterXml))
                        {
                            // Add this checkConstraintsWriter to the xml
                            sb.Append(checkConstraintsWriterXml);
                        }
                    }
                }

                // Add the close CheckConstraintsWriter Node
                sb.Append(indentString);
                sb.Append("</CheckConstraints>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportCheckConstraint(CheckConstraint checkConstraint, int indent = 0)
            // <Summary>
            // This method is used to export a CheckConstraint object to xml.
            // </Summary>
            public string ExportCheckConstraint(CheckConstraint checkConstraint, int indent = 0)
            {
                // initial value
                string checkConstraintXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the checkConstraint object exists
                if (NullHelper.Exists(checkConstraint))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open checkConstraint node
                    sb.Append("<CheckConstraint>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for CheckClause

                    sb.Append(indentString2);
                    sb.Append("<CheckClause>" + checkConstraint.CheckClause + "</CheckClause>" + Environment.NewLine);

                    // Write out the value for ColumnName

                    sb.Append(indentString2);
                    sb.Append("<ColumnName>" + checkConstraint.ColumnName + "</ColumnName>" + Environment.NewLine);

                    // Write out the value for ConstraintName

                    sb.Append(indentString2);
                    sb.Append("<ConstraintName>" + checkConstraint.ConstraintName + "</ConstraintName>" + Environment.NewLine);

                    // Write out the value for TableName

                    sb.Append(indentString2);
                    sb.Append("<TableName>" + checkConstraint.TableName + "</TableName>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close checkConstraint node
                    sb.Append("</CheckConstraint>" + Environment.NewLine);

                    // set the return value
                    checkConstraintXml = sb.ToString();
                }
                // return value
                return checkConstraintXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
