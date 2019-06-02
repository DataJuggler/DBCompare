

#region using statements

using DataJuggler.Net;
using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime.Objects;
using XmlMirror.Runtime.Util;

#endregion

namespace DBCompare.Xml.Parsers
{

    #region class CheckConstraintsParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'CheckConstraint' objects.
    /// </summary>
    public partial class CheckConstraintsParser : ParserBaseClass
    {

        #region Methods

            #region LoadCheckConstraints(string sourceXmlText)
            /// <summary>
            /// This method is used to load a list of 'CheckConstraint' objects.
            /// </summary>
            /// <param name="sourceXmlText">The source xml to be parsed.</param>
            /// <returns>A list of 'CheckConstraint' objects.</returns>
            public List<CheckConstraint> LoadCheckConstraints(string sourceXmlText)
            {
                // initial value
                List<CheckConstraint> checkConstraints = null;

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
                        // parse the checkConstraints
                        checkConstraints = ParseCheckConstraints(this.XmlDoc.RootNode);
                    }
                }

                // return value
                return checkConstraints;
            }
            #endregion

            #region ParseCheckConstraint(ref CheckConstraint checkConstraint, XmlNode xmlNode)
            /// <summary>
            /// This method is used to parse CheckConstraint objects.
            /// </summary>
            public CheckConstraint ParseCheckConstraint(ref CheckConstraint checkConstraint, XmlNode xmlNode)
            {
                // if the checkConstraint object exists and the xmlNode exists
                if ((checkConstraint != null) && (xmlNode != null))
                {
                    // get the full name of this node
                    string fullName = xmlNode.GetFullName();

                    // Check the name of this node to see if it is mapped to a property
                    switch(fullName)
                    {
                        case "Database.Tables.DataTable.CheckConstraints.CheckConstraint.CheckClause":

                            // Set the value for checkConstraint.CheckClause
                            checkConstraint.CheckClause = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Tables.DataTable.CheckConstraints.CheckConstraint.ColumnName":

                            // Set the value for checkConstraint.ColumnName
                            checkConstraint.ColumnName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Tables.DataTable.CheckConstraints.CheckConstraint.ConstraintName":

                            // Set the value for checkConstraint.ConstraintName
                            checkConstraint.ConstraintName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Tables.DataTable.CheckConstraints.CheckConstraint.TableName":

                            // Set the value for checkConstraint.TableName
                            checkConstraint.TableName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                         foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // append to this CheckConstraint
                            checkConstraint = ParseCheckConstraint(ref checkConstraint, childNode);
                        }
                    }
                }

                // return value
                return checkConstraint;
            }
            #endregion

            #region ParseCheckConstraints(XmlNode xmlNode, List<CheckConstraint> checkConstraints = null)
            /// <summary>
            /// This method is used to parse a list of 'CheckConstraint' objects.
            /// </summary>
            /// <param name="XmlNode">The XmlNode to be parsed.</param>
            /// <returns>A list of 'CheckConstraint' objects.</returns>
            public List<CheckConstraint> ParseCheckConstraints(XmlNode xmlNode, List<CheckConstraint> checkConstraints = null)
            {
                // locals
                CheckConstraint checkConstraint = null;
                bool cancel = false;

                // if the xmlNode exists
                if (xmlNode != null)
                {
                    // get the full name for this node
                    string fullName = xmlNode.GetFullName();

                    // if this is the new collection line
                    if (fullName == "Database.Tables.DataTable.CheckConstraints")
                    {
                        // Raise event Parsing is starting.
                        cancel = Parsing(xmlNode);

                        // If not cancelled
                        if (!cancel)
                        {
                            // create the return collection
                            checkConstraints = new List<CheckConstraint>();
                        }
                    }
                    // if this is the new object line and the return collection exists
                    else if ((fullName == "Database.Tables.DataTable.CheckConstraints.CheckConstraint") && (checkConstraints != null))
                    {
                        // Create a new object
                        checkConstraint = new CheckConstraint();

                        // Perform pre parse operations
                        cancel = Parsing(xmlNode, ref checkConstraint);

                        // If not cancelled
                        if (!cancel)
                        {
                            // parse this object
                            checkConstraint = ParseCheckConstraint(ref checkConstraint, xmlNode);
                        }

                        // Perform post parse operations
                        cancel = Parsed(xmlNode, ref checkConstraint);

                        // If not cancelled
                        if (!cancel)
                        {
                            // Add this object to the return value
                            checkConstraints.Add(checkConstraint);
                        }
                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                        foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // self call this method for each childNode
                            checkConstraints = ParseCheckConstraints(childNode, checkConstraints);
                        }
                    }
                }

                // return value
                return checkConstraints;
            }
            #endregion

        #endregion

    }
    #endregion

}
