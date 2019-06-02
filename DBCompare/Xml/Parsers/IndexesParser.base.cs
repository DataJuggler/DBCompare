

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Net;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime.Objects;
using XmlMirror.Runtime.Util;

#endregion

namespace DBCompare.Xml.Parsers
{

    #region class IndexesParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'DataIndex' objects.
    /// </summary>
    public partial class IndexesParser : ParserBaseClass
    {

        #region Methods

            #region LoadDataIndexs(string sourceXmlText)
            /// <summary>
            /// This method is used to load a list of 'DataIndex' objects.
            /// </summary>
            /// <param name="sourceXmlText">The source xml to be parsed.</param>
            /// <returns>A list of 'DataIndex' objects.</returns>
            public List<DataIndex> LoadDataIndexs(string sourceXmlText)
            {
                // initial value
                List<DataIndex> dataIndexs = null;

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
                        // parse the dataIndexs
                        dataIndexs = ParseDataIndexs(this.XmlDoc.RootNode);
                    }
                }

                // return value
                return dataIndexs;
            }
            #endregion

            #region ParseDataIndex(ref DataIndex dataIndex, XmlNode xmlNode)
            /// <summary>
            /// This method is used to parse DataIndex objects.
            /// </summary>
            public DataIndex ParseDataIndex(ref DataIndex dataIndex, XmlNode xmlNode)
            {
                // if the dataIndex object exists and the xmlNode exists
                if ((dataIndex != null) && (xmlNode != null))
                {
                    // get the full name of this node
                    string fullName = xmlNode.GetFullName();

                    // Check the name of this node to see if it is mapped to a property
                    switch(fullName)
                    {
                        case "Database.Tables.DataTable.Indexes.DataIndex.AllowPageLocks":

                            // Set the value for dataIndex.AllowPageLocks
                            dataIndex.AllowPageLocks = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Indexes.DataIndex.AllowRowLocks":

                            // Set the value for dataIndex.AllowRowLocks
                            dataIndex.AllowRowLocks = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Indexes.DataIndex.Clustered":

                            // Set the value for dataIndex.Clustered
                            dataIndex.Clustered = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Indexes.DataIndex.DataSpaceId":

                            // Set the value for dataIndex.DataSpaceId
                            dataIndex.DataSpaceId = NumericHelper.ParseInteger(xmlNode.FormattedNodeValue, 0, -1);

                            // required
                            break;

                        case "Database.Tables.DataTable.Indexes.DataIndex.FillFactor":

                            // Set the value for dataIndex.FillFactor
                            dataIndex.FillFactor = NumericHelper.ParseInteger(xmlNode.FormattedNodeValue, 0, -1);

                            // required
                            break;

                        case "Database.Tables.DataTable.Indexes.DataIndex.FilterDefinition":

                            // Set the value for dataIndex.FilterDefinition
                            dataIndex.FilterDefinition = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Tables.DataTable.Indexes.DataIndex.HasFilter":

                            // Set the value for dataIndex.HasFilter
                            dataIndex.HasFilter = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Indexes.DataIndex.IgnoreDuplicateKey":

                            // Set the value for dataIndex.IgnoreDuplicateKey
                            dataIndex.IgnoreDuplicateKey = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Indexes.DataIndex.IndexId":

                            // Set the value for dataIndex.IndexId
                            dataIndex.IndexId = NumericHelper.ParseInteger(xmlNode.FormattedNodeValue, 0, -1);

                            // required
                            break;

                        case "Database.Tables.DataTable.Indexes.DataIndex.IndexType":

                            // Set the value for dataIndex.IndexType
                            dataIndex.IndexType = EnumHelper.GetEnumValue<DataJuggler.Net.Enumerations.IndexTypeEnum>(xmlNode.FormattedNodeValue, DataJuggler.Net.Enumerations.IndexTypeEnum.Unknown);

                            // required
                            break;

                        case "Database.Tables.DataTable.Indexes.DataIndex.IsDisabled":

                            // Set the value for dataIndex.IsDisabled
                            dataIndex.IsDisabled = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Indexes.DataIndex.IsHypothetical":

                            // Set the value for dataIndex.IsHypothetical
                            dataIndex.IsHypothetical = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Indexes.DataIndex.IsPadded":

                            // Set the value for dataIndex.IsPadded
                            dataIndex.IsPadded = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Indexes.DataIndex.IsPrimary":

                            // Set the value for dataIndex.IsPrimary
                            dataIndex.IsPrimary = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Indexes.DataIndex.IsUnique":

                            // Set the value for dataIndex.IsUnique
                            dataIndex.IsUnique = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Indexes.DataIndex.IsUniqueConstraint":

                            // Set the value for dataIndex.IsUniqueConstraint
                            dataIndex.IsUniqueConstraint = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Indexes.DataIndex.Name":

                            // Set the value for dataIndex.Name
                            dataIndex.Name = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Tables.DataTable.Indexes.DataIndex.ObjectId":

                            // Set the value for dataIndex.ObjectId
                            dataIndex.ObjectId = NumericHelper.ParseInteger(xmlNode.FormattedNodeValue, 0, -1);

                            // required
                            break;

                        case "Database.Tables.DataTable.Indexes.DataIndex.TypeDescription":

                            // Set the value for dataIndex.TypeDescription
                            dataIndex.TypeDescription = xmlNode.FormattedNodeValue;

                            // required
                            break;

                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                         foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // append to this DataIndex
                            dataIndex = ParseDataIndex(ref dataIndex, childNode);
                        }
                    }
                }

                // return value
                return dataIndex;
            }
            #endregion

            #region ParseDataIndexs(XmlNode xmlNode, List<DataIndex> dataIndexs = null)
            /// <summary>
            /// This method is used to parse a list of 'DataIndex' objects.
            /// </summary>
            /// <param name="XmlNode">The XmlNode to be parsed.</param>
            /// <returns>A list of 'DataIndex' objects.</returns>
            public List<DataIndex> ParseDataIndexs(XmlNode xmlNode, List<DataIndex> dataIndexs = null)
            {
                // locals
                DataIndex dataIndex = null;
                bool cancel = false;

                // if the xmlNode exists
                if (xmlNode != null)
                {
                    // get the full name for this node
                    string fullName = xmlNode.GetFullName();

                    // if this is the new collection line
                    if (fullName == "Database.Tables.DataTable.Indexes")
                    {
                        // Raise event Parsing is starting.
                        cancel = Parsing(xmlNode);

                        // If not cancelled
                        if (!cancel)
                        {
                            // create the return collection
                            dataIndexs = new List<DataIndex>();
                        }
                    }
                    // if this is the new object line and the return collection exists
                    else if ((fullName == "Database.Tables.DataTable.Indexes.DataIndex") && (dataIndexs != null))
                    {
                        // Create a new object
                        dataIndex = new DataIndex();

                        // Perform pre parse operations
                        cancel = Parsing(xmlNode, ref dataIndex);

                        // If not cancelled
                        if (!cancel)
                        {
                            // parse this object
                            dataIndex = ParseDataIndex(ref dataIndex, xmlNode);
                        }

                        // Perform post parse operations
                        cancel = Parsed(xmlNode, ref dataIndex);

                        // If not cancelled
                        if (!cancel)
                        {
                            // Add this object to the return value
                            dataIndexs.Add(dataIndex);
                        }
                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                        foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // self call this method for each childNode
                            dataIndexs = ParseDataIndexs(childNode, dataIndexs);
                        }
                    }
                }

                // return value
                return dataIndexs;
            }
            #endregion

        #endregion

    }
    #endregion

}
