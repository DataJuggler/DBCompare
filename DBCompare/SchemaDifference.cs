

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataJuggler.NET.Data;
using DBCompare.Enumerations;

#endregion

namespace DBCompare
{

    #region class SchemaDifference
    /// <summary>
    /// This class is used so the SchemaDifference doesn't have to be parsed from a string
    /// like my original bad design.
    /// </summary>
    public class SchemaDifference
    {
        
        #region Private Variables
        private string message;
        private DataTable table;
        private DataField field;
        private StoredProcedure procedure;
        private DifferenceTypeEnum differenceType;
        private ForeignKeyConstraint foreignKey;
        private DataIndex index;
        private string name;
        private double _value;
        private string referenceTableName;
        private string referenceColumnName;
        private string invalidForeignKeyName;
        private CheckConstraint checkConstraint;
        private DefaultValueConstraint defaultValueConstraint;
        private string invalidConstraintName;
        #endregion

        #region Methods

            #region ToString()
            /// <summary>
            /// method returns a String to provide info about this object
            /// </summary>
            public override string ToString()
            {
                // initial value
                string toString = base.ToString();

                if ((HasTable) && (HasField))
                {
                    // set the return value
                    toString = DifferenceType.ToString() + " " + this.Table.Name + " " + Field.FieldName;
                }
                else if (HasTable)
                {
                    // return value
                    toString = DifferenceType.ToString() + " " + this.Table.Name;
                }
                else if (HasField)
                {
                    // return value
                    toString = DifferenceType.ToString() + " " + this.Field.FieldName;
                }

                // return value
                return toString;
            }
            #endregion
            
        #endregion

        #region Properties

            #region CheckConstraint
            /// <summary>
            /// This property gets or sets the value for 'CheckConstraint'.
            /// </summary>
            public CheckConstraint CheckConstraint
            {
                get { return checkConstraint; }
                set { checkConstraint = value; }
            }
            #endregion
            
            #region DefaultValueConstraint
            /// <summary>
            /// This property gets or sets the value for 'DefaultValueConstraint'.
            /// </summary>
            public DefaultValueConstraint DefaultValueConstraint
            {
                get { return defaultValueConstraint; }
                set { defaultValueConstraint = value; }
            }
            #endregion
            
            #region DifferenceType
            /// <summary>
            /// This property gets or sets the value for 'DifferenceType'.
            /// </summary>
            public DifferenceTypeEnum DifferenceType
            {
                get { return differenceType; }
                set { differenceType = value; }
            }
            #endregion
            
            #region Field
            /// <summary>
            /// This property gets or sets the value for 'Field'.
            /// </summary>
            public DataField Field
            {
                get { return field; }
                set { field = value; }
            }
            #endregion
            
            #region ForeignKey
            /// <summary>
            /// This property gets or sets the value for 'ForeignKey'.
            /// </summary>
            public ForeignKeyConstraint ForeignKey
            {
                get { return foreignKey; }
                set { foreignKey = value; }
            }
            #endregion
            
            #region HasCheckConstraint
            /// <summary>
            /// This property returns true if this object has a 'CheckConstraint'.
            /// </summary>
            public bool HasCheckConstraint
            {
                get
                {
                    // initial value
                    bool hasCheckConstraint = (CheckConstraint != null);

                    // return value
                    return hasCheckConstraint;
                }
            }
            #endregion
            
            #region HasDefaultValueConstraint
            /// <summary>
            /// This property returns true if this object has a 'DefaultValueConstraint'.
            /// </summary>
            public bool HasDefaultValueConstraint
            {
                get
                {
                    // initial value
                    bool hasDefaultValueConstraint = (DefaultValueConstraint != null);

                    // return value
                    return hasDefaultValueConstraint;
                }
            }
            #endregion
            
            #region HasField
            /// <summary>
            /// This property returns true if this object has a 'Field'.
            /// </summary>
            public bool HasField
            {
                get
                {
                    // initial value
                    bool hasField = (this.Field != null);
                    
                    // return value
                    return hasField;
                }
            }
            #endregion
            
            #region HasForeignKey
            /// <summary>
            /// This property returns true if this object has a 'ForeignKey'.
            /// </summary>
            public bool HasForeignKey
            {
                get
                {
                    // initial value
                    bool hasForeignKey = (ForeignKey != null);

                    // return value
                    return hasForeignKey;
                }
            }
            #endregion
            
            #region HasIndex
            /// <summary>
            /// This property returns true if this object has an 'Index'.
            /// </summary>
            public bool HasIndex
            {
                get
                {
                    // initial value
                    bool hasIndex = (Index != null);

                    // return value
                    return hasIndex;
                }
            }
            #endregion
            
            #region HasProcedure
            /// <summary>
            /// This property returns true if this object has a 'Procedure'.
            /// </summary>
            public bool HasProcedure
            {
                get
                {
                    // initial value
                    bool hasProcedure = (this.Procedure != null);
                    
                    // return value
                    return hasProcedure;
                }
            }
            #endregion
            
            #region HasTable
            /// <summary>
            /// This property returns true if this object has a 'Table'.
            /// </summary>
            public bool HasTable
            {
                get
                {
                    // initial value
                    bool hasTable = (this.Table != null);
                    
                    // return value
                    return hasTable;
                }
            }
            #endregion
            
            #region Index
            /// <summary>
            /// This property gets or sets the value for 'Index'.
            /// </summary>
            public DataIndex Index
            {
                get { return index; }
                set { index = value; }
            }
            #endregion
            
            #region InvalidConstraintName
            /// <summary>
            /// This property gets or sets the value for 'InvalidConstraintName'.
            /// </summary>
            public string InvalidConstraintName
            {
                get { return invalidConstraintName; }
                set { invalidConstraintName = value; }
            }
            #endregion
            
            #region InvalidForeignKeyName
            /// <summary>
            /// This property gets or sets the value for 'InvalidForeignKeyName'.
            /// </summary>
            public string InvalidForeignKeyName
            {
                get { return invalidForeignKeyName; }
                set { invalidForeignKeyName = value; }
            }
            #endregion
            
            #region Message
            /// <summary>
            /// This property gets or sets the value for 'Message'.
            /// </summary>
            public string Message
            {
                get { return message; }
                set { message = value; }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// This is only used for DefaultValue constraints for now.
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
            
            #region Procedure
            /// <summary>
            /// This property gets or sets the value for 'Procedure'.
            /// </summary>
            public StoredProcedure Procedure
            {
                get { return procedure; }
                set { procedure = value; }
            }
            #endregion
            
            #region ReferenceColumnName
            /// <summary>
            /// This property gets or sets the value for 'ReferenceColumnName'.
            /// </summary>
            public string ReferenceColumnName
            {
                get { return referenceColumnName; }
                set { referenceColumnName = value; }
            }
            #endregion
            
            #region ReferenceTableName
            /// <summary>
            /// This property gets or sets the value for 'ReferenceTableName'.
            /// </summary>
            public string ReferenceTableName
            {
                get { return referenceTableName; }
                set { referenceTableName = value; }
            }
            #endregion
            
            #region Table
            /// <summary>
            /// This property gets or sets the value for 'Table'.
            /// </summary>
            public DataTable Table
            {
                get { return table; }
                set { table = value; }
            }
            #endregion
            
            #region Value
            /// <summary>
            /// This property gets or sets the value for 'Value'.
            /// </summary>
            public double Value
            {
                get { return _value; }
                set { _value = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
