

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

    #region class DatabasesParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'Database' objects.
    /// </summary>
    public partial class DatabasesParser : ParserBaseClass
    {

        #region Methods

            #region ParseDatabase(string databaseXmlText)
            /// <summary>
            /// This method is used to parse an object of type 'Database'.
            /// </summary>
            /// <param name="databaseXmlText">The source xml to be parsed.</param>
            /// <returns>An object of type 'Database'.</returns>
            public Database ParseDatabase(string databaseXmlText)
            {
                // initial value
                Database database = null;

                // if the sourceXmlText exists
                if (TextHelper.Exists(databaseXmlText))
                {
                    // create an instance of the parser
                    XmlParser parser = new XmlParser();

                    // Create the XmlDoc
                    this.XmlDoc = parser.ParseXmlDocument(databaseXmlText);

                    // If the XmlDoc exists and has a root node.
                    if ((this.HasXmlDoc) && (this.XmlDoc.HasRootNode))
                    {
                        // Create a new database
                        database = new Database();

                        // Perform preparsing operations
                        bool cancel = Parsing(this.XmlDoc.RootNode, ref database);

                        // if the parsing should not be cancelled
                        if (!cancel)
                        {
                            // Parse the 'Database' object
                            database = ParseDatabase(ref database, this.XmlDoc.RootNode);

                            // Perform post parsing operations
                            cancel = Parsed(this.XmlDoc.RootNode, ref database);

                            // if the parsing should be cancelled
                            if (cancel)
                            {
                                // Set the 'database' object to null
                                database = null;
                            }
                        }
                    }
                }

                // return value
                return database;
            }
            #endregion

            #region ParseDatabase(ref Database database, XmlNode xmlNode)
            /// <summary>
            /// This method is used to parse Database objects.
            /// </summary>
            public Database ParseDatabase(ref Database database, XmlNode xmlNode)
            {
                // if the database object exists and the xmlNode exists
                if ((database != null) && (xmlNode != null))
                {
                    // get the full name of this node
                    string fullName = xmlNode.GetFullName();

                    // Check the name of this node to see if it is mapped to a property
                    switch(fullName)
                    {
                        case "Database.ClassFileName":

                            // Set the value for database.ClassFileName
                            database.ClassFileName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.ClassName":

                            // Set the value for database.ClassName
                            database.ClassName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.ConnectionString":

                            // Set the value for database.ConnectionString
                            database.ConnectionString = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Name":

                            // Set the value for database.Name
                            database.Name = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Password":

                            // Set the value for database.Password
                            database.Password = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Path":

                            // Set the value for database.Path
                            database.Path = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Serializable":

                            // Set the value for database.Serializable
                            database.Serializable = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.XmlFileName":

                            // Set the value for database.XmlFileName
                            database.XmlFileName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                         foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // append to this Database
                            database = ParseDatabase(ref database, childNode);
                        }
                    }
                }

                // return value
                return database;
            }
            #endregion

        #endregion

    }
    #endregion

}
