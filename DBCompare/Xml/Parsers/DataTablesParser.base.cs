

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

    #region class DataTablesParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'DataTable' objects.
    /// </summary>
    public partial class DataTablesParser : ParserBaseClass
    {

        #region Methods

            #region LoadDataTables(string sourceXmlText)
            /// <summary>
            /// This method is used to load a list of 'DataTable' objects.
            /// </summary>
            /// <param name="sourceXmlText">The source xml to be parsed.</param>
            /// <returns>A list of 'DataTable' objects.</returns>
            public List<DataTable> LoadDataTables(string sourceXmlText)
            {
                // initial value
                List<DataTable> dataTables = null;

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
                        // parse the dataTables
                        dataTables = ParseDataTables(this.XmlDoc.RootNode);
                    }
                }

                // return value
                return dataTables;
            }
            #endregion

            #region ParseDataTable(ref DataTable dataTable, XmlNode xmlNode)
            /// <summary>
            /// This method is used to parse DataTable objects.
            /// </summary>
            public DataTable ParseDataTable(ref DataTable dataTable, XmlNode xmlNode)
            {
                // if the dataTable object exists and the xmlNode exists
                if ((dataTable != null) && (xmlNode != null))
                {
                    // get the full name of this node
                    string fullName = xmlNode.GetFullName();

                    // Check the name of this node to see if it is mapped to a property
                    switch(fullName)
                    {

                        case "Database.Tables.DataTable.IsView":

                            // Set the value for dataTable.IsView
                            dataTable.IsView = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Name":

                            // Set the value for dataTable.Name
                            dataTable.Name = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Tables.DataTable.ObjectNameSpaceName":

                            // Set the value for dataTable.ObjectNameSpaceName
                            dataTable.ObjectNameSpaceName = xmlNode.FormattedNodeValue;

                            // required
                            break;
                            
                        case "Database.Tables.DataTable.SchemaName":

                            // Set the value for dataTable.SchemaName
                            dataTable.SchemaName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Tables.DataTable.Scope":

                            // Set the value for dataTable.Scope
                            dataTable.Scope = EnumHelper.GetEnumValue<DataManager.Scope>(xmlNode.FormattedNodeValue, DataManager.Scope.Public);

                            // required
                            break;

                        case "Database.Tables.DataTable.Serializable":

                            // Set the value for dataTable.Serializable
                            dataTable.Serializable = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;
                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                         foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // append to this DataTable
                            dataTable = ParseDataTable(ref dataTable, childNode);
                        }
                    }
                }

                // return value
                return dataTable;
            }
            #endregion

            #region ParseDataTables(XmlNode xmlNode, List<DataTable> dataTables = null)
            /// <summary>
            /// This method is used to parse a list of 'DataTable' objects.
            /// </summary>
            /// <param name="XmlNode">The XmlNode to be parsed.</param>
            /// <returns>A list of 'DataTable' objects.</returns>
            public List<DataTable> ParseDataTables(XmlNode xmlNode, List<DataTable> dataTables = null)
            {
                // locals
                DataTable dataTable = null;
                bool cancel = false;

                // if the xmlNode exists
                if (xmlNode != null)
                {
                    // get the full name for this node
                    string fullName = xmlNode.GetFullName();

                    // if this is the new collection line
                    if (fullName == "Database.Tables")
                    {
                        // Raise event Parsing is starting.
                        cancel = Parsing(xmlNode);

                        // If not cancelled
                        if (!cancel)
                        {
                            // create the return collection
                            dataTables = new List<DataTable>();
                        }
                    }
                    // if this is the new object line and the return collection exists
                    else if ((fullName == "Database.Tables.DataTable") && (dataTables != null))
                    {
                        // Create a new object
                        dataTable = new DataTable();

                        // Perform pre parse operations
                        cancel = Parsing(xmlNode, ref dataTable);

                        // If not cancelled
                        if (!cancel)
                        {
                            // parse this object
                            dataTable = ParseDataTable(ref dataTable, xmlNode);
                        }

                        // Perform post parse operations
                        cancel = Parsed(xmlNode, ref dataTable);

                        // If not cancelled
                        if (!cancel)
                        {
                            // Add this object to the return value
                            dataTables.Add(dataTable);
                        }
                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                        foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // self call this method for each childNode
                            dataTables = ParseDataTables(childNode, dataTables);
                        }
                    }
                }

                // return value
                return dataTables;
            }
            #endregion

        #endregion

    }
    #endregion

}
