

#region using statements

using DataJuggler.Net7;
using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime7.Objects;
using XmlMirror.Runtime7.Util;

#endregion

namespace DBCompare.Xml.Parsers
{

    #region class StoredProceduresParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'StoredProcedure' objects.
    /// </summary>
    public partial class StoredProceduresParser : ParserBaseClass
    {

        #region Methods

            #region LoadStoredProcedures(string sourceXmlText)
            /// <summary>
            /// This method is used to load a list of 'StoredProcedure' objects.
            /// </summary>
            /// <param name="sourceXmlText">The source xml to be parsed.</param>
            /// <returns>A list of 'StoredProcedure' objects.</returns>
            public List<StoredProcedure> LoadStoredProcedures(string sourceXmlText)
            {
                // initial value
                List<StoredProcedure> storedProcedures = null;

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
                        // parse the storedProcedures
                        storedProcedures = ParseStoredProcedures(this.XmlDoc.RootNode);
                    }
                }

                // return value
                return storedProcedures;
            }
            #endregion

            #region ParseStoredProcedure(ref StoredProcedure storedProcedure, XmlNode xmlNode)
            /// <summary>
            /// This method is used to parse StoredProcedure objects.
            /// </summary>
            public StoredProcedure ParseStoredProcedure(ref StoredProcedure storedProcedure, XmlNode xmlNode)
            {
                // if the storedProcedure object exists and the xmlNode exists
                if ((storedProcedure != null) && (xmlNode != null))
                {
                    // get the full name of this node
                    string fullName = xmlNode.GetFullName();

                    // Check the name of this node to see if it is mapped to a property
                    switch(fullName)
                    {
                        case "Database.StoredProcedures.StoredProcedure.DoesNotHaveParameters":

                            // Set the value for storedProcedure.DoesNotHaveParameters
                            storedProcedure.DoesNotHaveParameters = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.StoredProcedures.StoredProcedure.Parameters":

                            // Set the value for storedProcedure.Parameters
                            // storedProcedure.Parameters = // this field must be parsed manually.

                            // required
                            break;

                        case "Database.StoredProcedures.StoredProcedure.ProcedureName":

                            // Set the value for storedProcedure.ProcedureName
                            storedProcedure.ProcedureName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.StoredProcedures.StoredProcedure.ReturnSetSchema":

                            // Set the value for storedProcedure.ReturnSetSchema
                            // storedProcedure.ReturnSetSchema = // this field must be parsed manually.

                            // required
                            break;

                        case "Database.StoredProcedures.StoredProcedure.StoredProcedureType":

                            // Set the value for storedProcedure.StoredProcedureType
                            storedProcedure.StoredProcedureType = EnumHelper.GetEnumValue<DataJuggler.Net7.Enumerations.StoredProcedureTypes>(xmlNode.FormattedNodeValue, DataJuggler.Net7.Enumerations.StoredProcedureTypes.NotSet);

                            // required
                            break;

                        case "Database.StoredProcedures.StoredProcedure.Text":

                            // Set the value for storedProcedure.Text
                            storedProcedure.Text = xmlNode.FormattedNodeValue;

                            // required
                            break;

                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                         foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // append to this StoredProcedure
                            storedProcedure = ParseStoredProcedure(ref storedProcedure, childNode);
                        }
                    }
                }

                // return value
                return storedProcedure;
            }
            #endregion

            #region ParseStoredProcedures(XmlNode xmlNode, List<StoredProcedure> storedProcedures = null)
            /// <summary>
            /// This method is used to parse a list of 'StoredProcedure' objects.
            /// </summary>
            /// <param name="XmlNode">The XmlNode to be parsed.</param>
            /// <returns>A list of 'StoredProcedure' objects.</returns>
            public List<StoredProcedure> ParseStoredProcedures(XmlNode xmlNode, List<StoredProcedure> storedProcedures = null)
            {
                // locals
                StoredProcedure storedProcedure = null;
                bool cancel = false;

                // if the xmlNode exists
                if (xmlNode != null)
                {
                    // get the full name for this node
                    string fullName = xmlNode.GetFullName();

                    // if this is the new collection line
                    if (fullName == "Database.StoredProcedures")
                    {
                        // Raise event Parsing is starting.
                        cancel = Parsing(xmlNode);

                        // If not cancelled
                        if (!cancel)
                        {
                            // create the return collection
                            storedProcedures = new List<StoredProcedure>();
                        }
                    }
                    // if this is the new object line and the return collection exists
                    else if ((fullName == "Database.StoredProcedures.StoredProcedure") && (storedProcedures != null))
                    {
                        // Create a new object
                        storedProcedure = new StoredProcedure();

                        // Perform pre parse operations
                        cancel = Parsing(xmlNode, ref storedProcedure);

                        // If not cancelled
                        if (!cancel)
                        {
                            // parse this object
                            storedProcedure = ParseStoredProcedure(ref storedProcedure, xmlNode);
                        }

                        // Perform post parse operations
                        cancel = Parsed(xmlNode, ref storedProcedure);

                        // If not cancelled
                        if (!cancel)
                        {
                            // Add this object to the return value
                            storedProcedures.Add(storedProcedure);
                        }
                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                        foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // self call this method for each childNode
                            storedProcedures = ParseStoredProcedures(childNode, storedProcedures);
                        }
                    }
                }

                // return value
                return storedProcedures;
            }
            #endregion

        #endregion

    }
    #endregion

}
