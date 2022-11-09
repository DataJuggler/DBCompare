

#region using statements

using DataJuggler.Net7;
using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime7.Objects;
using XmlMirror.Runtime7.Util;
using System.Text;

#endregion

namespace DBCompare.Xml.Writers
{

    #region class StoredProceduresWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'StoredProcedure' objects to xml.
    /// </summary>
    public class StoredProceduresWriter
    {

        #region Methods

            #region ExportList(List<StoredProcedure> storedProcedures, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'StoredProcedure' objects to xml
            // </Summary>
            public string ExportList(List<StoredProcedure> storedProcedures, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string storedProceduresXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open StoredProcedure Node
                sb.Append("<StoredProcedures>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more StoredProcedure objects
                if ((storedProcedures != null) && (storedProcedures.Count > 0))
                {
                    // Iterate the storedProcedures collection
                    foreach (StoredProcedure storedProcedure  in storedProcedures)
                    {
                        // Get the xml for this storedProcedures
                        storedProceduresXml = ExportStoredProcedure(storedProcedure, indent + 2);

                        // If the storedProceduresXml string exists
                        if (TextHelper.Exists(storedProceduresXml))
                        {
                            // Add this storedProcedures to the xml
                            sb.Append(storedProceduresXml);
                        }
                    }
                }

                // Add the close StoredProceduresWriter Node
                sb.Append(indentString);
                sb.Append("</StoredProcedures>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportStoredProcedure(StoredProcedure storedProcedure, int indent = 0)
            // <Summary>
            // This method is used to export a StoredProcedure object to xml.
            // </Summary>
            public string ExportStoredProcedure(StoredProcedure storedProcedure, int indent = 0)
            {
                // initial value
                string storedProcedureXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the storedProcedure object exists
                if (NullHelper.Exists(storedProcedure))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open storedProcedure node
                    sb.Append("<StoredProcedure>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for DoesNotHaveParameters

                    sb.Append(indentString2);
                    sb.Append("<DoesNotHaveParameters>" + storedProcedure.DoesNotHaveParameters + "</DoesNotHaveParameters>" + Environment.NewLine);

                    // Write out the value for Parameters

                    // Create the ParametersWriter
                    ParametersWriter parametersWriter = new ParametersWriter();

                    // Export the Parameters collection to xml
                    string storedProcedureParameterXml = parametersWriter.ExportList(storedProcedure.Parameters, indent + 2);
                    sb.Append(storedProcedureParameterXml);
                    sb.Append(Environment.NewLine);

                    // Write out the value for ProcedureName

                    sb.Append(indentString2);
                    sb.Append("<ProcedureName>" + storedProcedure.ProcedureName + "</ProcedureName>" + Environment.NewLine);

                    // Write out the value for ReturnSetSchema

                    // Create the ReturnSetSchemaWriter
                    ReturnSetSchemaWriter returnSetSchemaWriter = new ReturnSetSchemaWriter();

                    // Export the ReturnSetSchemas collection to xml
                    string dataFieldXml = returnSetSchemaWriter.ExportList(storedProcedure.ReturnSetSchema, indent + 2);
                    sb.Append(dataFieldXml);
                    sb.Append(Environment.NewLine);

                    // Write out the value for StoredProcedureType

                    sb.Append(indentString2);
                    sb.Append("<StoredProcedureType>" + storedProcedure.StoredProcedureType + "</StoredProcedureType>" + Environment.NewLine);

                    // Write out the value for Text

                    // I accidently overwrote this line making the video:
                    // The xml has to be formatted if the procedure text contains any greater than or less than symbos or ampersands:
                    string encodedText = XmlPatternHelper.Encode(storedProcedure.Text);

                    sb.Append(indentString2);
                    sb.Append("<Text>" + encodedText + "</Text>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close storedProcedure node
                    sb.Append("</StoredProcedure>" + Environment.NewLine);

                    // set the return value
                    storedProcedureXml = sb.ToString();
                }
                // return value
                return storedProcedureXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
