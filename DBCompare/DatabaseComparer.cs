

#region using statements

using DataJuggler.Net5;
using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using System.Text;
using DataJuggler.UltimateHelper.Objects;
using System.Linq;

#endregion

namespace DBCompare
{

    #region class DatabaseComparer
    /// <summary>
    /// This class is used to comparison two Databases and reports and changes differences.
    /// </summary>
    public class DatabaseComparer
    {
        
        #region Private Variables
        private Database sourceDatabase;
        private Database targetDatabase;
        private bool ignoreDiagramProcedures;
        private string failedReason;
        private bool ignoreIndexes;
        #endregion

        #region Parameterized Constructor(Database sourceDatabase, Database targetDatabase, bool ignoreDiagramProcedures bool, ignoreIndexes)
        /// <summary>
        /// Create a new instance of a SQLDatabaseComparer object.
        /// </summary>
        public DatabaseComparer(Database sourceDatabase, Database targetDatabase, bool ignoreDiagramProcedures, bool ignoreIndexes)
        {
            // if both databases exist
            if (NullHelper.Exists(sourceDatabase, targetDatabase))
            {
                // set the properties
                SourceDatabase = sourceDatabase;
                TargetDatabase = targetDatabase;
                
                // store the args
                this.IgnoreDiagramProcedures = ignoreDiagramProcedures;
                this.IgnoreIndexes = ignoreIndexes;
            }
            else
            {
                // Raise an error that a null database was passed in.
                throw new Exception("Both databases must exist.");
            }
        }
        #endregion

        #region Methods

            #region Compare(DataTable sourceTable, DataTable targetTable)
            /// <summary>
            /// This method compares two tables
            /// </summary>
            private SchemaComparison Compare(DataTable sourceTable, DataTable targetTable)
            {
                // initial value
                SchemaComparison comparison = new SchemaComparison();
                
                // verify both objects exist
                if ((sourceTable != null) && (targetTable != null) && (sourceTable.Fields != null) && (targetTable.Fields != null))
                {  
                    // Compare the fields for this table
                    CompareTableFields(sourceTable, targetTable, ref comparison);

                    // Do a backwards comparison to see if there are any fields in the target table that are not in the source table.
                    DoBackwardsComparison(targetTable, sourceTable, ref comparison);
                    
                    // should indexes be ignored
                    if (!IgnoreIndexes)
                    {
                        // Compare the indexes
                        CompareIndexesForTable(sourceTable, targetTable, ref comparison);
                    }

                    // Compare the CheckConstraints for a table
                    CompareCheckConstraintsForTable(sourceTable, targetTable, ref comparison);

                    // Update for Version 2 - Compare Foreign Keys
                    CompareForeignKeys(sourceTable, targetTable, ref comparison);
                }
                else if (NullHelper.IsNull(targetTable))
                {
                    // if this table is a view
                    if (sourceTable.IsView)
                    {
                        // change the message to say view instead of table

                        // Add this table was not found to the schema differences collection
                        comparison.SchemaDifferences.Add("The view '" + sourceTable.Name + "' does not exist in the target database.");
                    }
                    else
                    {
                         // Add this table was not found to the schema differences collection
                        comparison.SchemaDifferences.Add("The table '" + sourceTable.Name + "' does not exist in the target database.");
                    }
                }
                else if (!ListHelper.HasOneOrMoreItems(sourceTable.Fields))
                {
                    // if the sourceTable is a view
                    if (sourceTable.IsView)
                    {
                         // Add this table was not found to the schema differences collection
                        comparison.SchemaDifferences.Add("The source database view '" + sourceTable.Name + "' does not contain any fields.");
                    }
                    else
                    {
                         // Add this table was not found to the schema differences collection
                        comparison.SchemaDifferences.Add("The source database table '" + sourceTable.Name + "' does not contain any fields.");
                    }
                }
                else if (!ListHelper.HasOneOrMoreItems(targetTable.Fields))
                {
                    // if the targetTable is a view
                    if (targetTable.IsView)
                    {
                        // Add this table was not found to the schema differences collection
                        comparison.SchemaDifferences.Add("The target database view '" + targetTable.Name + "' does not contain any fields.");
                    }
                    else
                    {
                        // Add this table was not found to the schema differences collection
                        comparison.SchemaDifferences.Add("The target database table '" + targetTable.Name + "' does not contain any fields.");
                    }
                }

                //if there are not any schema differences
                if (comparison.SchemaDifferences.Count < 1)
                {
                    // This is an equal
                    comparison.IsEqual = true;
                }
                
                // return value
                return comparison;
            }
            #endregion
            
            #region Compare()
            /// <summary>
            /// This method compares the two databases.
            /// </summary>
            public SchemaComparison Compare()
            {
                // initial value
                SchemaComparison comparison = new SchemaComparison();

                // if the SourceDatabase & TargetDatabase exist
                if ((this.HasSourceDatabase) && (this.HasTargetDatabase))
                {
                    // Do Comparison
                    comparison = DoComparison();
                }
                else if (!this.HasSourceDatabase)
                {
                    // Add to the schema differences
                    comparison.SchemaDifferences.Add("Unable to load the 'Target Database.'");
                }
                else if (!this.HasTargetDatabase)
                {
                    // Add to the schema differences
                    comparison.SchemaDifferences.Add("Unable to load the 'Source Database.'");
                }
                else
                {
                    // Add to the schema differences
                    comparison.SchemaDifferences.Add("Unable to load the 'Source Database.' & 'Target Database.'");
                }

                // return value
                return comparison;
            }
            #endregion

            #region CompareCheckConstraints(CheckConstraint sourceCheckConstraint, CheckConstraint targetCheckConstraint)
            /// <summary>
            /// This method returns the Check Constraints
            /// </summary>
            private bool CompareCheckConstraints(CheckConstraint sourceCheckConstraint, CheckConstraint targetCheckConstraint)
            {
                // initial value
                bool isValid = false;

                // if both CheckConstraint objects exist
                if (NullHelper.Exists(sourceCheckConstraint, targetCheckConstraint))
                {
                    // set isValid to true
                    isValid = true;
                    
                    // if the CheckClause is not the same
                    if (XmlPatternHelper.Decode(sourceCheckConstraint.CheckClause) != targetCheckConstraint.CheckClause)
                    {
                        // set isValid to false
                        isValid = false;
                    }
                    else if (sourceCheckConstraint.ColumnName != targetCheckConstraint.ColumnName)
                    {
                        // set isValid to false
                        isValid = false;
                    }
                    else if (sourceCheckConstraint.ConstraintName != targetCheckConstraint.ConstraintName)
                    {
                        // set isValid to false
                        isValid = false;
                    }
                    else if (sourceCheckConstraint.TableName != targetCheckConstraint.TableName)
                    {
                        // set isValid to false
                        isValid = false;
                    }
                }
                
                // return value
                return isValid;
            }
            #endregion

            #region CompareCheckConstraintsForTable(DataTable sourceTable, DataTable targetTable, ref SchemaComparison comparison)
            /// <summary>
            /// This method is sued to compare all the CheckConstraints for a table
            /// </summary>
            /// <param name="sourceTable"></param>
            /// <param name="targetTable"></param>
            /// <param name="comparison"></param>
            public void CompareCheckConstraintsForTable(DataTable sourceTable, DataTable targetTable, ref SchemaComparison comparison)
            {
                // verify all the objects exist
                if (NullHelper.Exists(sourceTable, targetTable, comparison))
                {
                     // if the sourceTable Has Check Constraints
                    if (sourceTable.HasCheckConstraints)
                    {
                        // local
                        int number = 0;
                        string constraintName = "";
                        string schemaDifference = "";
                        
                        // iterate the CheckConstraints in the sourceTable
                        foreach (CheckConstraint sourceCheckConstraint in sourceTable.CheckConstraints)
                        {
                            // if this name is the same
                            if (TextHelper.IsEqual(constraintName, sourceCheckConstraint.ConstraintName))
                            {
                                // Increment the value for number
                                number++;    
                            }
                            else
                            {
                                // reset the value for number
                                number = 1;
                            }

                            // set the constraintName
                            constraintName = sourceCheckConstraint.ConstraintName;

                            // find the CheckConstraint in the target table
                            CheckConstraint targetCheckConstraint = targetTable.FindCheckConstraintByNameAndNumber(sourceCheckConstraint.ConstraintName, number);

                            // if the targetCheckConstraint exists
                            if (NullHelper.Exists(targetCheckConstraint))
                            {
                                // compare the checkConstraint
                                bool validCheckConstraints = CompareCheckConstraints(sourceCheckConstraint, targetCheckConstraint);

                                // if not a valid CheckConstraint
                                if (!validCheckConstraints)
                                {
                                    // create the schemaDifference
                                    schemaDifference = "The check constraint '" + sourceCheckConstraint.ConstraintName + "' in the target database table '" + targetTable.Name + "' is not valid.";

                                    // see if this item is already in the comparison report (some constraints take up more than one field)
                                    int index = comparison.SchemaDifferences.IndexOf(schemaDifference);

                                    // if the index was not found
                                    if (index < 0)
                                    {
                                        // Add an entry for this missing Check Constraint
                                        comparison.SchemaDifferences.Add(schemaDifference);
                                    }
                                }
                            }
                            else
                            {
                                // create the schemaDifference
                                schemaDifference = "The check constraint  '" + sourceCheckConstraint.ConstraintName + "' was not found in the target database table '" + targetTable.Name + "'.";

                                // see if this item is already in the comparison report (some constraints take up more than one field)
                                int index = comparison.SchemaDifferences.IndexOf(schemaDifference);

                                // if the index was not found
                                if (index < 0)
                                {
                                    // Add an entry for this missing Check Constraint
                                    comparison.SchemaDifferences.Add(schemaDifference);
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region CompareFields(DataField sourceField, DataField targetField, ref string failedDescription)
            /// <summary>
            /// This method compares two fields
            /// </summary>
            private bool CompareFields(DataField sourceField, DataField targetField, ref string failedDescription)
            {
                // initial value
                bool fieldsMatch = false;

                // if the sourceField and targetField both exist
                if ((sourceField != null) && (targetField != null))
                {
                    // default to true
                    fieldsMatch = true;
                    
                    // if the data types do not match
                    if (sourceField.DataType != targetField.DataType)
                    {
                        // the fields do not match
                        fieldsMatch = false;

                        // set the failedDescription
                        failedDescription = "The target field value for 'DataType' does not match.";
                    }
                    else if (sourceField.DBDataType != targetField.DBDataType)
                    {
                        // the fields do not match
                        fieldsMatch = false;

                        // set the failedDescription (fixing message above usually fixes this, but not always)
                        failedDescription = "The target field value for 'DB DataType' does not match.";
                    }
                    else if (sourceField.DBFieldName != targetField.DBFieldName)
                    {
                        // the fields do not match
                        fieldsMatch = false;

                        // set the failedDescription (This is the raw name for the field in the database, they should always match when comparing)
                        failedDescription = "The target field value for 'DBFieldName' does not match.";
                    }
                    else if (sourceField.DecimalPlaces != targetField.DecimalPlaces)
                    {
                        // the fields do not match
                        fieldsMatch = false;

                        // set the failedDescription
                        failedDescription = "The target field value for 'Decimal Places' do not match";
                    }                   
                    else if (sourceField.IsAutoIncrement != targetField.IsAutoIncrement)
                    {
                        // the fields do not match
                        fieldsMatch = false;

                        // set the failedDescription
                        failedDescription = "The target field value for 'IsAutoIncremnt' does not match.";
                    }
                    else if (sourceField.IsNullable != targetField.IsNullable)
                    {
                        // the fields do not match
                        fieldsMatch = false;

                        // set the failedDescription
                        failedDescription = "The target field value for 'IsNullable' does not match.";
                    }
                    else if (sourceField.IsReadOnly != targetField.IsReadOnly)
                    {
                        // the fields do not match
                        fieldsMatch = false;

                        // set the failedDescription
                        failedDescription = "The target field value for 'IsReadOnly' does not match.";
                    }
                    else if (sourceField.Precision != targetField.Precision)
                    {
                        // the fields do not match
                        fieldsMatch = false;

                        // set the failedDescription
                        failedDescription = "The target field value for 'Precision' does not match: Decimal(Precision, Scale)";
                    }
                    else if (sourceField.PrimaryKey != targetField.PrimaryKey)
                    {
                        // the fields do not match
                        fieldsMatch = false;

                        // set the failedDescription
                        failedDescription = "The target field value for 'PrimaryKey' does not match";
                    }
                    else if (sourceField.Scale != targetField.Scale)
                    {
                        // the fields do not match
                        fieldsMatch = false;

                        // set the failedDescription
                        failedDescription = "The target field value for 'Scale' does not match: Decimal(Precision, Scale)";
                    }
                    else if(sourceField.Size != targetField.Size)
                    {
                        // the fields do not match
                        fieldsMatch = false;

                        // set the failedDescription
                        failedDescription = "The target field value for 'Size' does not match";
                    }
                    else if (TextHelper.Exists(sourceField.DefaultValue))
                    {
                        // if the targetField does not exist
                        if (!TextHelper.Exists(targetField.DefaultValue))
                        {
                             // the fields do not match
                            fieldsMatch = false;

                            // set the failedDescription
                            failedDescription = "The target field value for 'DefaultValue' is null.";
                        }
                        else 
                        {
                            // replace out the parens
                            string sourceFieldVallue = sourceField.DefaultValue.Replace("(", "").Replace(")", "");
                            string targetFieldValue = targetField.DefaultValue.Replace("(", "").Replace(")", "");

                            // if the fields do not match
                            if (!TextHelper.IsEqual(sourceFieldVallue, targetFieldValue))
                            {
                                // the fields do not match
                                fieldsMatch = false;

                                // set the failedDescription
                                failedDescription = "The target field value for 'DefaultValue' does not match.";
                            }
                        }
                    }
                }

                // return value
                return fieldsMatch;
            }
            #endregion

            #region CompareForeignKeys(DataTable sourceTable, DataTable targetTable, ref SchemaComparison comparison)
            /// <summary>
            /// This method is used to compare the foreign keys for a table
            /// </summary>
            /// <param name="sourceTable"></param>
            /// <param name="targetTable"></param>
            /// <param name="comparison"></param>
            public void CompareForeignKeys(DataTable sourceTable, DataTable targetTable, ref SchemaComparison comparison)
            {
                // local
                ForeignKeyConstraint targetForeignKey = null;

                // verify all the objects exist
                if (NullHelper.Exists(sourceTable, targetTable, comparison))
                {
                    // if both tables have foreign keys
                    if (ListHelper.HasOneOrMoreItems(sourceTable.ForeignKeys))
                    {
                        // iterate the foreignKeys for the sourceTable
                        foreach (ForeignKeyConstraint foreignKey in sourceTable.ForeignKeys)
                        {
                            // Attempt to find this foreign key in the target table
                            targetForeignKey = ForeignKeyConstraintHelper.FindForeignKey(foreignKey.Name, targetTable);

                            // if the foreign key was found in the target database
                            if (NullHelper.Exists(targetForeignKey))
                            {
                                // compare the table name (should always be true)
                                if (!TextHelper.IsEqual(foreignKey.Table, targetForeignKey.Table))
                                {
                                    // Add a schemaDifference because the Table name does not match
                                    comparison.SchemaDifferences.Add("The foreign key " + foreignKey.Name + " has a different value for Table name in the target database.");
                                }
                                else if (!TextHelper.IsEqual(foreignKey.ReferencedTable, targetForeignKey.ReferencedTable))
                                {
                                    // Add a schemaDifference because the Referenced Table name does not match
                                    comparison.SchemaDifferences.Add("The foreign key " + foreignKey.Name + " has a different value for Referenced Table name in the target database.");
                                }
                                else if (!TextHelper.IsEqual(foreignKey.ReferencedColumn, targetForeignKey.ReferencedColumn))
                                {
                                    // Add a schemaDifference because the Referenced Column name does not match
                                    comparison.SchemaDifferences.Add("The foreign key " + foreignKey.Name + " has a different value for Referenced Column name in the target database.");
                                }
                            }
                            else
                            {
                                // Add a schemaDifference the foreign key does not exist in the target database
                                comparison.SchemaDifferences.Add("The foreign key " + foreignKey.Name + " does not exist in the target database.");  
                            }
                        }
                    }
                }
            }
            #endregion

            #region CompareFunctions(SchemaComparison comparison)
            /// <summary>
            /// This method returns the Functions
            /// </summary>
            private void CompareFunctions(SchemaComparison comparison)
            {
                // local
                Function targetFunction = null;

                // verify both objects exist
                if ((this.HasSourceDatabase) && (this.HasTargetDatabase) && (comparison != null))
                {
                    // if the SourceDatabase.Functions exists and has 1 or more functions
                    if (this.SourceDatabase.HasOneOrMoreFunctions)
                    {
                        // iterate the functions
                        foreach (Function function in this.SourceDatabase.Functions)
                        {
                            // Attempt to find the target function
                            targetFunction = FindFunction(function.Name, this.TargetDatabase.Functions);

                            // if the targetFunction exists
                            if (targetFunction != null)
                            {
                                // set the text of each 
                                string sourceFunctionText = function.Text;

                                // set the targetProcedureText
                                string targetFunctionText = targetFunction.Text;

                                // if the text was found for both functions
                                if (TextHelper.Exists(sourceFunctionText, targetFunctionText))
                                {
                                    // replace out any double spaces and new line characters and replace commas with spaces so fields parse as words
                                    sourceFunctionText = sourceFunctionText.Replace("\r\n", " ").Replace("  ", " ").Replace(",", " ").Replace("dbo", "").Replace("[", "").Replace("]", "");
                                    targetFunctionText = targetFunctionText.Replace("\r\n", " ").Replace("  ", " ").Replace(",", " ").Replace("dbo", "").Replace("[", "").Replace("]", "");

                                    // Compare Stored Procedure Text
                                    CompareFunctionText(function.Name, sourceFunctionText, targetFunctionText, comparison);
                                }
                                else 
                                {
                                    // This stored procedure is not valid
                                    comparison.SchemaDifferences.Add("The function '" + function.Name + "' is not valid.");
                                }
                            }
                            else
                            {
                                // This stored procedure is not valid
                                comparison.SchemaDifferences.Add("The function '" + function.Name + "' was not found.");
                            }
                        }
                    }
                }
            }
            #endregion

            #region CompareFunctionText(string sourceFunctionName, string sourceFunctionText, string targetFunctionText, SchemaComparison comparison)
            /// <summary>
            /// This method compares the text of two SQL Functions
            /// </summary>
            private void CompareFunctionText(string sourceFunctionName, string sourceFunctionText, string targetFunctionText, SchemaComparison comparison)
            {
                // locals
                bool isEqual = true; // (Default to true)
                string failedReason = "";
                string sourceWordText = "";
                string targetWordText = "";
                int wordCompare = 0;

                // if the sourceProcedureText exists and the targetProcedureText exists and the comparison object exists
                if ((TextHelper.Exists(sourceFunctionText, targetFunctionText)) && (comparison != null))
                {
                    // Get the words for the source procedure text
                    List<Word> sourceWords = WordParser.GetWords(sourceFunctionText);

                    // Get the words for the target procedure text
                    List<Word> targetWords = WordParser.GetWords(targetFunctionText);

                    // if both sets of words exist
                    if ((sourceWords != null) && (targetWords != null))
                    {
                        // if the number of words is different
                        if (sourceWords.Count != targetWords.Count)
                        {
                            // not equal
                            isEqual = false;

                            // set the failedReason
                            failedReason = "The function '" + sourceFunctionName + "' is not valid.";
                        }
                        else
                        {
                            // check the text of each word
                            for (int x = 0; x < sourceWords.Count; x++)
                            {
                                // get the text of this word
                                sourceWordText = sourceWords[x].Text.ToLower();
                                targetWordText = targetWords[x].Text.ToLower();

                                // compare this word
                                wordCompare = String.Compare(sourceWordText, targetWordText);

                                // if the words did not match
                                if (wordCompare != 0)
                                {
                                    // not equal
                                    isEqual = false;

                                    // set the failedReason
                                    failedReason = "The function '" + sourceFunctionName + "' is not valid.";
                                }
                            }
                        }
                    }
                    else if (sourceWords != null)
                    {
                        // not equal
                        isEqual = false;

                        // set the failedReason
                        failedReason = "The source function '" + sourceFunctionName + "' could not be analyzed.";
                    }
                    else if (targetWords != null)
                    {
                        // not equal
                        isEqual = false;

                        // set the failedReason
                        failedReason = "The target function '" + sourceFunctionName + "' could not be analyzed.";
                    }

                    // if the text is not the same
                    if (!isEqual)
                    {
                        // This stored procedure is not valid
                        comparison.SchemaDifferences.Add("The function '" + sourceFunctionName + "' is not valid.");
                    }
                }
            }
            #endregion
            
            #region CompareIndexes(DataIndex sourceIndex, DataIndex targetIndex)
            /// <summary>
            /// This method returns the Indexes
            /// </summary>
            private bool CompareIndexes(DataIndex sourceIndex, DataIndex targetIndex)
            {
                // initial value
                bool isValid = false;

                // if both indexes exist
                if (NullHelper.Exists(sourceDatabase, targetIndex))
                {
                    // set isValid to true
                    isValid = true;

                    // if the names do not match
                    if (sourceIndex.Name != targetIndex.Name)
                    {
                        // not valid
                        isValid = false;
                    }
                    else if (sourceIndex.IsUniqueConstraint != targetIndex.IsUniqueConstraint)
                    {
                        // not valid
                        isValid = false;
                    }
                    else if (sourceIndex.IsPrimary != targetIndex.IsPrimary)
                    {
                        // not valid
                        isValid = false;
                    }
                    else if (sourceIndex.Clustered != targetIndex.Clustered)
                    {
                        // not valid
                        isValid = false;
                    }
                    else if (sourceIndex.IgnoreDuplicateKey != targetIndex.IgnoreDuplicateKey)
                    {
                        // not valid
                        isValid = false;
                    }
                }
                else if (NullHelper.Exists(sourceDatabase))
                {
                    // Not valid
                }
                else if (NullHelper.Exists(targetIndex))
                {
                    // Not valid
                }

                // return value
                return isValid;
            }
            #endregion

            #region CompareIndexesForTable(DataTable sourceTable, DataTable targetTable, ref SchemaComparison comparison)
            /// <summary>
            /// This method is used to compare all the indees for agiven table
            /// </summary>
            /// <param name="sourceTable"></param>
            /// <param name="targetTable"></param>
            /// <param name="comparison"></param>
            public void CompareIndexesForTable(DataTable sourceTable, DataTable targetTable, ref SchemaComparison comparison)
            {
                // see if al 
                if (NullHelper.Exists(sourceTable, targetTable, comparison))
                {
                    // If the sourceTable has an indexes collection
                    if (sourceTable.HasIndexes)
                    {
                        // iterate the indexes in the sourceTable
                        foreach (DataIndex sourceIndex in sourceTable.Indexes)
                        {
                            // find the index in the target table
                            DataIndex targetIndex = targetTable.FindIndexByName(sourceIndex.Name);

                            // if the targetIndex exists
                            if (NullHelper.Exists(targetIndex))
                            {
                                // compare the index
                                bool validIndex = CompareIndexes(sourceIndex, targetIndex);

                                // if not a valid index
                                if (!validIndex)
                                {
                                    // Add an entry for this index
                                    comparison.SchemaDifferences.Add("The index '" + sourceIndex.Name + "' in the target database table '" + targetTable.Name + "' is not valid.");
                                }
                            }
                            else
                            {
                                // Add an entry for this index
                                comparison.SchemaDifferences.Add("The index '" + sourceIndex.Name + "' was not found in the target database table '" + targetTable.Name + "'.");
                            }
                        }
                    }
                }
            }
            #endregion

            #region CompareStoredProcedures(StoredProcedure sourceProcedure, Database database, SchemaComparison comparison)
            /// <summary>
            /// This method returns the Stored Procedures
            /// </summary>
            private void CompareStoredProcedures(StoredProcedure sourceProcedure, Database database, SchemaComparison comparison)
            {
                // locals
                StoredProcedure targetProcedure = null;
                
                // verify the sourceProcedure and the database both exist
                if ((sourceProcedure != null) && (database != null) && (comparison != null))
                {
                    // if this procedure should not be skipped
                    if (!SkipProcedure(sourceProcedure.ProcedureName))
                    {
                        // attempt to find
                        targetProcedure = database.StoredProcedures.FirstOrDefault(x => x.ProcedureName == sourceProcedure.ProcedureName);

                        // if the targetProcedure exists
                        if (targetProcedure != null)
                        {
                            // set the text of each 
                            string sourceProcedureText = sourceProcedure.Text;

                            // set the targetProcedureText
                            string targetProcedureText = targetProcedure.Text;

                            // if the text was found for both procedures
                            if (TextHelper.Exists(sourceProcedureText, targetProcedureText))
                            {
                                // replace out any double spaces and new line characters and replace commas with spaces so fields parse as words
                                sourceProcedureText = sourceProcedureText.Replace("\r\n", " ").Replace("  ", " ").Replace(",", " ");
                                targetProcedureText = targetProcedureText.Replace("\r\n", " ").Replace("  ", " ").Replace(",", " ");
                            
                                // Compare Stored Procedure Text
                                CompareStoredProcedureText(sourceProcedure.ProcedureName, sourceProcedureText, targetProcedureText, comparison);
                            }
                            else if (TextHelper.Exists(sourceProcedureText))
                            {
                                // This stored procedure is not valid
                                comparison.SchemaDifferences.Add("The stored procedure '" + sourceProcedure.ProcedureName + "' was not found in the target database.");
                            }
                            else if (TextHelper.Exists(targetProcedureText))
                            {
                                // This stored procedure is not valid
                                comparison.SchemaDifferences.Add("The stored procedure '" + sourceProcedure.ProcedureName + "' was not found in the source database.");
                            }
                        }
                        else
                        {
                            // This stored procedure is not valid
                            comparison.SchemaDifferences.Add("The procedure '" + sourceProcedure.ProcedureName + "' was not found.");
                        }
                    }
                }
            }
            #endregion
            
            #region CompareStoredProcedures(SchemaComparison comparison)
            /// <summary>
            /// This method compares the StoredProcedures from the SourceDatabase against the 
            /// stored procedures from the TargetDatabase.
            /// </summary>
            private void CompareStoredProcedures(SchemaComparison comparison)
            {   
                // if the SourceDatabase and the TargetDatabase exist
                if ((this.HasSourceDatabase) && (this.HasTargetDatabase) && (comparison != null))
                {
                    // if there are one or more stored procedures
                    if (this.SourceDatabase.HasOneOrMoreStoredProcedures)
                    {
                        // if the target database has at least one stored procedure
                        if (this.TargetDatabase.HasOneOrMoreStoredProcedures)
                        {
                            // do compareisons here

                            // iterate the stored procedures
                            foreach (StoredProcedure sourceProcedure in this.SourceDatabase.StoredProcedures)
                            {
                                // Compare stored procedures
                                CompareStoredProcedures(sourceProcedure, this.TargetDatabase, comparison);
                            }

                            // Update 5.14.2013: Check for extra stored procedures in the TargetDatabase

                            // iterate the stored procedures
                            foreach (StoredProcedure targetProcedure in this.TargetDatabase.StoredProcedures)
                            {
                                // if this Procedure Should Not Be Skipped
                                if (!SkipProcedure(targetProcedure.ProcedureName))
                                {
                                    // attempt to 
                                    StoredProcedure sourceProcedure = this.SourceDatabase.StoredProcedures.FirstOrDefault(x => x.ProcedureName == targetProcedure.ProcedureName);

                                    // if the sourceProcedure was not found
                                    if (sourceProcedure == null)
                                    {
                                        // if the comparisionObject hasSchemaDifferences object
                                        if (comparison.HasSchemaDifferences)
                                        {
                                            // Show this extra procedure
                                            comparison.SchemaDifferences.Add("The target database contains an extra stored procedure: '" + targetProcedure.ProcedureName + "'.");
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            // The TargetDatabase does not have any stored procedures
                            comparison.SchemaDifferences.Add("The target database does not have any stored procedures.");
                        }
                    }
                }
            }
            #endregion
            
            #region CompareStoredProcedureText(string sourceProcedureName, string sourceProcedureText, string targetProcedureText, SchemaComparison comparison)
            /// <summary>
            /// This method returns the Stored Procedure Text
            /// </summary>
            private void CompareStoredProcedureText(string sourceProcedureName, string sourceProcedureText, string targetProcedureText, SchemaComparison comparison)
            {
                // locals
                bool isEqual = true; // (Default to true)
                string failedReason = "";
                string sourceWordText = "";
                string targetWordText = "";
                int wordCompare = 0;

                // if the sourceProcedureText exists and the targetProcedureText exists and the comparison object exists
                if ((TextHelper.Exists(sourceProcedureText, targetProcedureText)) && (comparison != null))
                {
                    // Get the words for the source procedure text
                    List<Word> sourceWords = WordParser.GetWords(sourceProcedureText);

                    // Get the words for the target procedure text
                    List<Word> targetWords = WordParser.GetWords(targetProcedureText);

                    // if both sets of words exist
                    if ((sourceWords != null) && (targetWords != null))
                    {
                        // if the number of words is different
                        if (sourceWords.Count != targetWords.Count)
                        {
                            // not equal
                            isEqual = false;

                            // set the failedReason
                            failedReason = "The procedure '" + sourceProcedureName + "' is not valid.";
                        }
                        else
                        {
                            // check the text of each word
                            for (int x = 0; x < sourceWords.Count; x++)
                            {
                                // get the text of this word
                                sourceWordText = sourceWords[x].Text.ToLower();
                                targetWordText = targetWords[x].Text.ToLower();

                                // compare this word
                                wordCompare = String.Compare(sourceWordText, targetWordText);

                                // if the words did not match
                                if (wordCompare != 0)
                                {
                                    // not equal
                                    isEqual = false;

                                    // set the failedReason
                                    failedReason = "The procedure '" + sourceProcedureName + "' is not valid.";
                                }
                            }
                        }
                    }
                    else if (sourceWords != null)
                    {
                        // not equal
                        isEqual = false;

                        // set the failedReason
                        failedReason = "The source stored procedure '" + sourceProcedureName + "' could not be analyzed.";
                    }
                    else if (targetWords != null)
                    {
                        // not equal
                        isEqual = false;

                        // set the failedReason
                        failedReason = "The target stored procedure '" + sourceProcedureName + "' could not be analyzed.";
                    }

                    // if the text is not the same
                    if (!isEqual)
                    {
                        // This stored procedure is not valid
                        comparison.SchemaDifferences.Add("The procedure '" + sourceProcedureName + "' is not valid.");
                    }
                }
            }
            #endregion
            
            #region CompareTableFields(DataTable sourceTable, DataTable targetTable, ref SchemaComparison comparison)
            /// <summary>
            /// This method compares the fields of two tables
            /// </summary>
            /// <param name="sourceTable"></param>
            /// <param name="targetTable"></param>
            /// <param name="comparison"></param>
            public void CompareTableFields(DataTable sourceTable, DataTable targetTable, ref SchemaComparison comparison)
            {
                // locals
                DataField targetField = null;
                string failedDescription = "";
                
                // verify all 3 objects exist
                if (NullHelper.Exists(sourceDatabase, targetTable, comparison))
                {
                    // compare each field
                    foreach (DataField sourceField in sourceTable.Fields)
                    {
                        // attempt to find the targetField
                        targetField = SQLDatabaseConnector.FindField(targetTable.Fields, sourceField.FieldName);

                        // if the targetField exists
                        if (targetField != null)
                        {
                            // Compare the fields
                            bool validField = CompareFields(sourceField, targetField, ref failedDescription);

                            // if the field is not valid
                            if (!validField)
                            {
                                // Add this table was not found to the schema differences collection
                                comparison.SchemaDifferences.Add("The field '" + sourceTable.Name + "." + sourceField.FieldName + "' is not valid: " + failedDescription);
                            }
                        }
                        else
                        {
                            // Add this table was not found to the schema differences collection
                            comparison.SchemaDifferences.Add("The field '" + sourceTable.Name + "." + sourceField.FieldName + "' was not found in the target database.");
                        }
                    }
                }
            }
            #endregion

            #region CompareTables()
            /// <summary>
            /// This method compares the tables from the SourceDatabase and the TargetDatabase.
            /// </summary>
            private SchemaComparison CompareTables()
            {
                // initial value
                SchemaComparison comparison = new SchemaComparison();

                // local
                SchemaComparison tempComparison = null;
                DataTable targetTable = null;

                // if there are one or more tables
                if ((this.HasSourceDatabase) && (this.HasTargetDatabase) && (this.SourceDatabase.HasOneOrMoreTables) && (this.TargetDatabase.HasOneOrMoreTables))
                {   
                    // iterate the tables in the database
                    foreach (DataTable sourceTable in this.SourceDatabase.Tables)
                    {
                        // Find the table by name
                        targetTable = this.TargetDatabase.Tables.FirstOrDefault(x => x.Name == sourceTable.Name);

                        // if the targetTable was found
                        if (targetTable != null)
                        {
                            // compare the two tables
                            tempComparison = Compare(sourceTable, targetTable);

                            // if the tempComparison is not equal
                            if (!tempComparison.IsEqual)
                            {
                                // copy the schemaDifferences from the tempComparison to this comparison object.
                                foreach (string schemaDifference in tempComparison.SchemaDifferences)
                                {
                                    // Add this SchemaDifference
                                    comparison.SchemaDifferences.Add(schemaDifference);
                                }
                            }
                        }
                        else
                        {
                            // if the sourceTable is a view
                            if (sourceTable.IsView)
                            {
                                // Add this schema difference
                                comparison.SchemaDifferences.Add("The view '" + sourceTable.Name + "' does not exist in the target database.");
                            }
                            else
                            {
                                // Add this schema difference
                                comparison.SchemaDifferences.Add("The table '" + sourceTable.Name + "' does not exist in the target database.");
                            }
                        }
                    }

                    // Update 5.14.2013: Do backwards comparison for extra tables
                    foreach (DataTable tempTable in targetDatabase.Tables)
                    {
                        // attempt to find the sourceTable
                        DataTable sourceTable = this.SourceDatabase.Tables.FirstOrDefault(x => x.Name == tempTable.Name);

                        // if the sourceTable was not found
                        if (sourceTable == null)
                        {
                            // if this is a view
                            if (tempTable.IsView)
                            {
                                // Add this is an extra field to the schema differences collection
                                comparison.SchemaDifferences.Add("The TARGET database contains an extra view: '" + tempTable.Name + "'.");
                            }
                            else
                            {
                                // Add this is an extra field to the schema differences collection
                                comparison.SchemaDifferences.Add("The TARGET database contains an extra table: '" + tempTable.Name + "'.");
                            }
                        }
                    }
                }

                // return value
                return comparison;
            }
            #endregion

            #region DoBackwardsComparison(DataTable targetTable, DataTable sourceTable, ref SchemaComparison comparison)
            /// <summary>
            /// This method performs a backwards comparison to see if there are any extra fields in the targetTable
            /// // that rae not in hte soureTable
            /// </summary>
            /// <param name="targetTable"></param>
            /// <param name="sourceTable"></param>
            /// <param name="comparison"></param>
            public void DoBackwardsComparison(DataTable targetTable, DataTable sourceTable, ref SchemaComparison comparison)
            {
                // verify all 3 objects exist
                if (NullHelper.Exists(targetTable, sourceTable, comparison))
                {
                    // Update 5.14.2013: Do backwards comparison for extra fields
                    foreach (DataField tempField in targetTable.Fields)
                    {
                        // attempt to find the sourceField
                        DataField sourceField = SQLDatabaseConnector.FindField(sourceTable.Fields, tempField.FieldName);

                        // if the sourceField was not found
                        if (sourceField == null)
                        {
                            // if this is a view
                            if (targetTable.IsView)
                            {
                                // Add this is an extra field to the schema differences collection
                                comparison.SchemaDifferences.Add("The view '" + targetTable.Name + "' in the TARGET database contains an extra field: '" + tempField.FieldName + "'.");
                            }
                            else
                            {
                                // Add this is an extra field to the schema differences collection
                                comparison.SchemaDifferences.Add("The table '" + targetTable.Name + "' in the TARGET database contains an extra field: '" + tempField.FieldName + "'.");
                            }
                        }
                    }
                }
            }
            #endregion
            
            #region DoComparison()
            /// <summary>
            /// This method performs the database schema comparison check and adds any 
            /// differences to the SchemaDifferences
            /// </summary>
            private SchemaComparison DoComparison()
            {
                // initial value
                SchemaComparison comparison = null;

                // if the SourceDatabase & TargetDatabase exist
                if ((this.HasSourceDatabase) && (this.HasTargetDatabase))
                {
                    // Compare the tables
                    comparison = CompareTables();

                    // Compare the stored procedures
                    CompareStoredProcedures(comparison);

                    // Compare the functions
                    CompareFunctions(comparison);

                    // The databases are equal if there are not any schema differences
                    comparison.IsEqual = (comparison.SchemaDifferences.Count < 1);
                }

                // return value
                return comparison;
            }
            #endregion

            #region FindFunction(string name, List<Function> functions)
            /// <summary>
            /// This method returns a list of Function
            /// </summary>
            private Function FindFunction(string name, List<Function> functions)
            {
                // initial value
                Function function = null;

                // If the functions collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(functions))
                {
                    // iterate the functions
                    foreach (Function tempFunction in functions)
                    {
                        // if the function names match
                        if (tempFunction.Name == name)
                        {
                            // set the return value
                            function = tempFunction;

                            // break out of the loop
                            break;
                        }
                    }
                }

                // return value
                return function;
            }
            #endregion
            
            #region SkipProcedure(string procedureName)
            /// <summary>
            /// This method returns the Procedure
            /// </summary>
            private bool SkipProcedure(string procedureName)
            {
                // initial value
                bool skipProcedure = false;

                // IgnoreDiagramProcedures is true
                if ((this.IgnoreDiagramProcedures) && (TextHelper.Exists(procedureName)))
                {
                    // Determine the action by the procedureName
                    switch (procedureName)
                    {
                        case "sp_alterdiagram":
                        case "sp_creatediagram":
                        case "sp_dropdiagram":
                        case "sp_helpdiagramdefinition":
                        case "sp_helpdiagrams":
                        case "sp_renamediagram":
                        case "sp_upgraddiagrams":

                            // ignore any of the diagram procedures
                            skipProcedure = true;

                            // required
                            break;
                    }
                }

                // to do: Add custom IgnoreProcedures logic

                // return value
                return skipProcedure;
            }
            #endregion
            
        #endregion

        #region Properties
            
            #region FailedReason
            /// <summary>
            /// This property gets or sets the value for 'FailedReason'.
            /// </summary>
            public string FailedReason
            {
                get { return failedReason; }
                set { failedReason = value; }
            }
            #endregion
            
            #region HasSourceDatabase
            /// <summary>
            /// This property returns true if this object has a 'SourceDatabase'.
            /// </summary>
            public bool HasSourceDatabase
            {
                get
                {
                    // initial value
                    bool hasSourceDatabase = (this.SourceDatabase != null);
                    
                    // return value
                    return hasSourceDatabase;
                }
            }
            #endregion
            
            #region HasTargetDatabase
            /// <summary>
            /// This property returns true if this object has a 'TargetDatabase'.
            /// </summary>
            public bool HasTargetDatabase
            {
                get
                {
                    // initial value
                    bool hasTargetDatabase = (this.TargetDatabase != null);
                    
                    // return value
                    return hasTargetDatabase;
                }
            }
            #endregion
            
            #region IgnoreDiagramProcedures
            /// <summary>
            /// This property gets or sets the value for 'IgnoreDiagramProcedures'.
            /// </summary>
            public bool IgnoreDiagramProcedures
            {
                get { return ignoreDiagramProcedures; }
                set { ignoreDiagramProcedures = value; }
            }
            #endregion
            
            #region IgnoreIndexes
            /// <summary>
            /// This property gets or sets the value for 'IgnoreIndexes'.
            /// </summary>
            public bool IgnoreIndexes
            {
                get { return ignoreIndexes; }
                set { ignoreIndexes = value; }
            }
            #endregion
            
            #region SourceDatabase
            /// <summary>
            /// This property gets or sets the value for 'SourceDatabase'.
            /// </summary>
            public Database SourceDatabase
            {
                get { return sourceDatabase; }
                set { sourceDatabase = value; }
            }
            #endregion
            
            #region TargetDatabase
            /// <summary>
            /// This property gets or sets the value for 'TargetDatabase'.
            /// </summary>
            public Database TargetDatabase
            {
                get { return targetDatabase; }
                set { targetDatabase = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
