

#region using statements

using DataJuggler.UltimateHelper;
using DataJuggler.NET8;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime7.Objects;
using XmlMirror.Runtime7.Util;

#endregion

namespace DBCompare.Xml.Parsers
{

    #region class StoredProcedureParametersParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'StoredProcedureParameter' objects.
    /// </summary>
    public partial class StoredProcedureParametersParser : ParserBaseClass
    {

        #region Methods

            #region LoadStoredProcedureParameters(string sourceXmlText)
            /// <summary>
            /// This method is used to load a list of 'StoredProcedureParameter' objects.
            /// </summary>
            /// <param name="sourceXmlText">The source xml to be parsed.</param>
            /// <returns>A list of 'StoredProcedureParameter' objects.</returns>
            public List<StoredProcedureParameter> LoadStoredProcedureParameters(string sourceXmlText)
            {
                // initial value
                List<StoredProcedureParameter> storedProcedureParameters = null;

                // if the source text exists
                if (TextHelper.Exists(sourceXmlText))
                {
                    // create an instance of the parser
                    XmlParser parser = new XmlParser();

                    // Create the XmlDoc
                    this.XmlDoc = parser.ParseXmlDocument(sourceXmlText);

                    // If the XmlDoc exists and has a root node.
                    if ((this.HasXmlDoc) && (this.XmlDoc.HasRootNode))
                    {
                        // parse the storedProcedureParameters
                        storedProcedureParameters = ParseStoredProcedureParameters(this.XmlDoc.RootNode);
                    }
                }

                // return value
                return storedProcedureParameters;
            }
            #endregion

            #region ParseStoredProcedureParameter(ref StoredProcedureParameter storedProcedureParameter, XmlNode xmlNode)
            /// <summary>
            /// This method is used to parse StoredProcedureParameter objects.
            /// </summary>
            public StoredProcedureParameter ParseStoredProcedureParameter(ref StoredProcedureParameter storedProcedureParameter, XmlNode xmlNode)
            {
                // if the storedProcedureParameter object exists and the xmlNode exists
                if ((storedProcedureParameter != null) && (xmlNode != null))
                {
                    // get the full name of this node
                    string fullName = xmlNode.GetFullName();

                    // Check the name of this node to see if it is mapped to a property
                    switch(fullName)
                    {
                        case "Database.StoredProcedures.StoredProcedure.Parameters.StoredProcedureParameter.DataType":

                            // Set the value for storedProcedureParameter.DataType
                            storedProcedureParameter.DataType = EnumHelper.GetEnumValue<DataManager.DataTypeEnum>(xmlNode.FormattedNodeValue, DataManager.DataTypeEnum.NotSupported);

                            // required
                            break;

                        case "Database.StoredProcedures.StoredProcedure.Parameters.StoredProcedureParameter.Length":

                            // Set the value for storedProcedureParameter.Length
                            storedProcedureParameter.Length = NumericHelper.ParseInteger(xmlNode.FormattedNodeValue, 0, -1);

                            // required
                            break;

                        case "Database.StoredProcedures.StoredProcedure.Parameters.StoredProcedureParameter.ParameterName":

                            // Set the value for storedProcedureParameter.ParameterName
                            storedProcedureParameter.ParameterName = xmlNode.FormattedNodeValue;

                            // required
                            break;
                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                         foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // append to this StoredProcedureParameter
                            storedProcedureParameter = ParseStoredProcedureParameter(ref storedProcedureParameter, childNode);
                        }
                    }
                }

                // return value
                return storedProcedureParameter;
            }
            #endregion

            #region ParseStoredProcedureParameters(XmlNode xmlNode, List<StoredProcedureParameter> storedProcedureParameters = null)
            /// <summary>
            /// This method is used to parse a list of 'StoredProcedureParameter' objects.
            /// </summary>
            /// <param name="XmlNode">The XmlNode to be parsed.</param>
            /// <returns>A list of 'StoredProcedureParameter' objects.</returns>
            public List<StoredProcedureParameter> ParseStoredProcedureParameters(XmlNode xmlNode, List<StoredProcedureParameter> storedProcedureParameters = null)
            {
                // locals
                StoredProcedureParameter storedProcedureParameter = null;
                bool cancel = false;

                // if the xmlNode exists
                if (xmlNode != null)
                {
                    // get the full name for this node
                    string fullName = xmlNode.GetFullName();

                    // if this is the new collection line
                    if (fullName == "Database.StoredProcedures.StoredProcedure.Parameters")
                    {
                        // Raise event Parsing is starting.
                        cancel = Parsing(xmlNode);

                        // If not cancelled
                        if (!cancel)
                        {
                            // create the return collection
                            storedProcedureParameters = new List<StoredProcedureParameter>();
                        }
                    }
                    // if this is the new object line and the return collection exists
                    else if ((fullName == "Database.StoredProcedures.StoredProcedure.Parameters.StoredProcedureParameter") && (storedProcedureParameters != null))
                    {
                        // Create a new object
                        storedProcedureParameter = new StoredProcedureParameter();

                        // Perform pre parse operations
                        cancel = Parsing(xmlNode, ref storedProcedureParameter);

                        // If not cancelled
                        if (!cancel)
                        {
                            // parse this object
                            storedProcedureParameter = ParseStoredProcedureParameter(ref storedProcedureParameter, xmlNode);
                        }

                        // Perform post parse operations
                        cancel = Parsed(xmlNode, ref storedProcedureParameter);

                        // If not cancelled
                        if (!cancel)
                        {
                            // Add this object to the return value
                            storedProcedureParameters.Add(storedProcedureParameter);
                        }
                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                        foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // self call this method for each childNode
                            storedProcedureParameters = ParseStoredProcedureParameters(childNode, storedProcedureParameters);
                        }
                    }
                }

                // return value
                return storedProcedureParameters;
            }
            #endregion

        #endregion

    }
    #endregion

}
