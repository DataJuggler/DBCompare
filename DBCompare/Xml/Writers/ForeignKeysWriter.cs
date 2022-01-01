

#region using statements

using DataJuggler.Net6;
using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime6.Objects;
using XmlMirror.Runtime6.Util;
using System.Text;

#endregion

namespace DBCompare.Xml.Writers
{

    #region class ForeignKeyConstraintsWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'ForeignKeyConstraint' objects to xml.
    /// </summary>
    public class ForeignKeysWriter
    {

        #region Methods

            #region ExportList(List<ForeignKeyConstraint> foreignKeyConstraints, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'ForeignKeyConstraint' objects to xml
            // </Summary>
            public string ExportList(List<ForeignKeyConstraint> foreignKeyConstraints, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string foreignKeyConstraintsXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open ForeignKeys Node
                sb.Append("<ForeignKeys>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more ForeignKeyConstraint objects
                if ((foreignKeyConstraints != null) && (foreignKeyConstraints.Count > 0))
                {
                    // Iterate the foreignKeyConstraints collection
                    foreach (ForeignKeyConstraint foreignKeyConstraint  in foreignKeyConstraints)
                    {
                        // Get the xml for this foreignKeyConstraints
                        foreignKeyConstraintsXml = ExportForeignKeyConstraint(foreignKeyConstraint, indent + 2);

                        // If the foreignKeyConstraintsXml string exists
                        if (TextHelper.Exists(foreignKeyConstraintsXml))
                        {
                            // Add this foreignKeyConstraints to the xml
                            sb.Append(foreignKeyConstraintsXml);
                        }
                    }
                }

                // Add the close ForeignKeyConstraintsWriter Node
                sb.Append(indentString);
                sb.Append("</ForeignKeys>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportForeignKeyConstraint(ForeignKeyConstraint foreignKeyConstraint, int indent = 0)
            // <Summary>
            // This method is used to export a ForeignKeyConstraint object to xml.
            // </Summary>
            public string ExportForeignKeyConstraint(ForeignKeyConstraint foreignKeyConstraint, int indent = 0)
            {
                // initial value
                string foreignKeyConstraintXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the foreignKeyConstraint object exists
                if (NullHelper.Exists(foreignKeyConstraint))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open foreignKeyConstraint node
                    sb.Append("<ForeignKeyConstraint>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for ForeignKey

                    sb.Append(indentString2);
                    sb.Append("<ForeignKey>" + foreignKeyConstraint.ForeignKey + "</ForeignKey>" + Environment.NewLine);

                    // Write out the value for Name

                    sb.Append(indentString2);
                    sb.Append("<Name>" + foreignKeyConstraint.Name + "</Name>" + Environment.NewLine);

                    // Write out the value for ReferencedColumn

                    sb.Append(indentString2);
                    sb.Append("<ReferencedColumn>" + foreignKeyConstraint.ReferencedColumn + "</ReferencedColumn>" + Environment.NewLine);

                    // Write out the value for ReferencedTable

                    sb.Append(indentString2);
                    sb.Append("<ReferencedTable>" + foreignKeyConstraint.ReferencedTable + "</ReferencedTable>" + Environment.NewLine);

                    // Write out the value for Table

                    sb.Append(indentString2);
                    sb.Append("<Table>" + foreignKeyConstraint.Table + "</Table>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close foreignKeyConstraint node
                    sb.Append("</ForeignKeyConstraint>" + Environment.NewLine);

                    // set the return value
                    foreignKeyConstraintXml = sb.ToString();
                }
                // return value
                return foreignKeyConstraintXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
