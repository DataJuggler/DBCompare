

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

    #region class FunctionsWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'Function' objects to xml.
    /// </summary>
    public class FunctionsWriter
    {

        #region Methods

            #region ExportList(List<Function> functionsWriter, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'Function' objects to xml
            // </Summary>
            public string ExportList(List<Function> functionsWriter, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string functionsWriterXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open Function Node
                sb.Append("<Functions>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more Function objects
                if ((functionsWriter != null) && (functionsWriter.Count > 0))
                {
                    // Iterate the functionsWriter collection
                    foreach (Function function  in functionsWriter)
                    {
                        // Get the xml for this functionsWriter
                        functionsWriterXml = ExportFunction(function, indent + 2);

                        // If the functionsWriterXml string exists
                        if (TextHelper.Exists(functionsWriterXml))
                        {
                            // Add this functionsWriter to the xml
                            sb.Append(functionsWriterXml);
                        }
                    }
                }

                // Add the close FunctionsWriter Node
                sb.Append(indentString);
                sb.Append("</Functions>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportFunction(Function function, int indent = 0)
            // <Summary>
            // This method is used to export a Function object to xml.
            // </Summary>
            public string ExportFunction(Function function, int indent = 0)
            {
                // initial value
                string functionXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the function object exists
                if (NullHelper.Exists(function))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open function node
                    sb.Append("<Function>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for FunctionType

                    sb.Append(indentString2);
                    sb.Append("<FunctionType>" + function.FunctionType + "</FunctionType>" + Environment.NewLine);

                    // Write out the value for Name

                    sb.Append(indentString2);
                    sb.Append("<Name>" + function.Name + "</Name>" + Environment.NewLine);

                    // Write out the value for Text

                    sb.Append(indentString2);
                    sb.Append("<Text>" + function.Text + "</Text>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close function node
                    sb.Append("</Function>" + Environment.NewLine);

                    // set the return value
                    functionXml = sb.ToString();
                }
                // return value
                return functionXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
