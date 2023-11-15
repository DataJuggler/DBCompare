

#region using statements

using DataJuggler.NET8;
using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime7.Objects;
using XmlMirror.Runtime7.Util;

#endregion

namespace DBCompare.Xml.Parsers
{

    #region class ForeignKeyConstraintsParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'ForeignKeyConstraint' objects.
    /// </summary>
    public partial class ForeignKeyConstraintsParser : ParserBaseClass
    {

        #region Methods

            #region LoadForeignKeyConstraints(string sourceXmlText)
            /// <summary>
            /// This method is used to load a list of 'ForeignKeyConstraint' objects.
            /// </summary>
            /// <param name="sourceXmlText">The source xml to be parsed.</param>
            /// <returns>A list of 'ForeignKeyConstraint' objects.</returns>
            public List<ForeignKeyConstraint> LoadForeignKeyConstraints(string sourceXmlText)
            {
                // initial value
                List<ForeignKeyConstraint> foreignKeyConstraints = null;

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
                        // parse the foreignKeyConstraints
                        foreignKeyConstraints = ParseForeignKeyConstraints(this.XmlDoc.RootNode);
                    }
                }

                // return value
                return foreignKeyConstraints;
            }
            #endregion

            #region ParseForeignKeyConstraint(ref ForeignKeyConstraint foreignKeyConstraint, XmlNode xmlNode)
            /// <summary>
            /// This method is used to parse ForeignKeyConstraint objects.
            /// </summary>
            public ForeignKeyConstraint ParseForeignKeyConstraint(ref ForeignKeyConstraint foreignKeyConstraint, XmlNode xmlNode)
            {
                // if the foreignKeyConstraint object exists and the xmlNode exists
                if ((foreignKeyConstraint != null) && (xmlNode != null))
                {
                    // get the full name of this node
                    string fullName = xmlNode.GetFullName();

                    // Check the name of this node to see if it is mapped to a property
                    switch(fullName)
                    {
                        case "Database.Tables.DataTable.ForeignKeys.ForeignKeyConstraint.ForeignKey":

                            // Set the value for foreignKeyConstraint.ForeignKey
                            foreignKeyConstraint.ForeignKey = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Tables.DataTable.ForeignKeys.ForeignKeyConstraint.Name":

                            // Set the value for foreignKeyConstraint.Name
                            foreignKeyConstraint.Name = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Tables.DataTable.ForeignKeys.ForeignKeyConstraint.ReferencedColumn":

                            // Set the value for foreignKeyConstraint.ReferencedColumn
                            foreignKeyConstraint.ReferencedColumn = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Tables.DataTable.ForeignKeys.ForeignKeyConstraint.ReferencedTable":

                            // Set the value for foreignKeyConstraint.ReferencedTable
                            foreignKeyConstraint.ReferencedTable = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Tables.DataTable.ForeignKeys.ForeignKeyConstraint.Table":

                            // Set the value for foreignKeyConstraint.Table
                            foreignKeyConstraint.Table = xmlNode.FormattedNodeValue;

                            // required
                            break;

                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                         foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // append to this ForeignKeyConstraint
                            foreignKeyConstraint = ParseForeignKeyConstraint(ref foreignKeyConstraint, childNode);
                        }
                    }
                }

                // return value
                return foreignKeyConstraint;
            }
            #endregion

            #region ParseForeignKeyConstraints(XmlNode xmlNode, List<ForeignKeyConstraint> foreignKeyConstraints = null)
            /// <summary>
            /// This method is used to parse a list of 'ForeignKeyConstraint' objects.
            /// </summary>
            /// <param name="XmlNode">The XmlNode to be parsed.</param>
            /// <returns>A list of 'ForeignKeyConstraint' objects.</returns>
            public List<ForeignKeyConstraint> ParseForeignKeyConstraints(XmlNode xmlNode, List<ForeignKeyConstraint> foreignKeyConstraints = null)
            {
                // locals
                ForeignKeyConstraint foreignKeyConstraint = null;
                bool cancel = false;

                // if the xmlNode exists
                if (xmlNode != null)
                {
                    // get the full name for this node
                    string fullName = xmlNode.GetFullName();

                    // if this is the new collection line
                    if (fullName == "Database.Tables.DataTable.ForeignKeys")
                    {
                        // Raise event Parsing is starting.
                        cancel = Parsing(xmlNode);

                        // If not cancelled
                        if (!cancel)
                        {
                            // create the return collection
                            foreignKeyConstraints = new List<ForeignKeyConstraint>();
                        }
                    }
                    // if this is the new object line and the return collection exists
                    else if ((fullName == "Database.Tables.DataTable.ForeignKeys.ForeignKeyConstraint") && (foreignKeyConstraints != null))
                    {
                        // Create a new object
                        foreignKeyConstraint = new ForeignKeyConstraint();

                        // Perform pre parse operations
                        cancel = Parsing(xmlNode, ref foreignKeyConstraint);

                        // If not cancelled
                        if (!cancel)
                        {
                            // parse this object
                            foreignKeyConstraint = ParseForeignKeyConstraint(ref foreignKeyConstraint, xmlNode);
                        }

                        // Perform post parse operations
                        cancel = Parsed(xmlNode, ref foreignKeyConstraint);

                        // If not cancelled
                        if (!cancel)
                        {
                            // Add this object to the return value
                            foreignKeyConstraints.Add(foreignKeyConstraint);
                        }
                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                        foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // self call this method for each childNode
                            foreignKeyConstraints = ParseForeignKeyConstraints(childNode, foreignKeyConstraints);
                        }
                    }
                }

                // return value
                return foreignKeyConstraints;
            }
            #endregion

        #endregion

    }
    #endregion

}
