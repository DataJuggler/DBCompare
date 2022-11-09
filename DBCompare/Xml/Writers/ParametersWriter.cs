

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

    #region class ParametersWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'StoredProcedureParameter' objects to xml.
    /// </summary>
    public class ParametersWriter
    {

        #region Methods

            #region ExportList(List<StoredProcedureParameter> parametersWriter, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'StoredProcedureParameter' objects to xml
            // </Summary>
            public string ExportList(List<StoredProcedureParameter> parametersWriter, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string parametersWriterXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open StoredProcedureParameter Node
                sb.Append("<Parameters>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more StoredProcedureParameter objects
                if ((parametersWriter != null) && (parametersWriter.Count > 0))
                {
                    // Iterate the parametersWriter collection
                    foreach (StoredProcedureParameter storedProcedureParameter  in parametersWriter)
                    {
                        // Get the xml for this parametersWriter
                        parametersWriterXml = ExportStoredProcedureParameter(storedProcedureParameter, indent + 2);

                        // If the parametersWriterXml string exists
                        if (TextHelper.Exists(parametersWriterXml))
                        {
                            // Add this parametersWriter to the xml
                            sb.Append(parametersWriterXml);
                        }
                    }
                }

                // Add the close ParametersWriter Node
                sb.Append(indentString);
                sb.Append("</Parameters>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportStoredProcedureParameter(StoredProcedureParameter storedProcedureParameter, int indent = 0)
            // <Summary>
            // This method is used to export a StoredProcedureParameter object to xml.
            // </Summary>
            public string ExportStoredProcedureParameter(StoredProcedureParameter storedProcedureParameter, int indent = 0)
            {
                // initial value
                string storedProcedureParameterXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the storedProcedureParameter object exists
                if (NullHelper.Exists(storedProcedureParameter))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open storedProcedureParameter node
                    sb.Append("<StoredProcedureParameter>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for DataType

                    sb.Append(indentString2);
                    sb.Append("<DataType>" + storedProcedureParameter.DataType + "</DataType>" + Environment.NewLine);

                    // Write out the value for Length

                    sb.Append(indentString2);
                    sb.Append("<Length>" + storedProcedureParameter.Length + "</Length>" + Environment.NewLine);

                    // Write out the value for ParameterName

                    sb.Append(indentString2);
                    sb.Append("<ParameterName>" + storedProcedureParameter.ParameterName + "</ParameterName>" + Environment.NewLine);

                    // Write out the value for ParameterValue

                    sb.Append(indentString2);
                    sb.Append("<ParameterValue>" + storedProcedureParameter.ParameterValue + "</ParameterValue>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close storedProcedureParameter node
                    sb.Append("</StoredProcedureParameter>" + Environment.NewLine);

                    // set the return value
                    storedProcedureParameterXml = sb.ToString();
                }
                // return value
                return storedProcedureParameterXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
