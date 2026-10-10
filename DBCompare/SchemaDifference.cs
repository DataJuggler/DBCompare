

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
        private double _value;
        private CheckConstraint checkConstraint;
        private DefaultValueConstraint defaultValueConstraint;
        private DifferenceTypeEnum differenceType;
        private DataField field;
        private ForeignKeyConstraint foreignKey;
        private List<ForeignKeyConstraint> foreignKeysToRecreate;
        private DataIndex index;
        private string invalidConstraintName;
        private string invalidForeignKeyName;
        private string message;
        private string name;
        private StoredProcedure procedure;
        private string referenceColumnName;
        private string referenceTableName;
        private DataTable table;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a SchemaDifference object
        /// </summary>
        public SchemaDifference()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Methods
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Create a new collection of 'ForeignKeyConstraint' objects.
                ForeignKeysToRecreate = new List<ForeignKeyConstraint>();
            }
            #endregion
            
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
            
            #region ForeignKeysToRecreate
            /// <summary>
            /// This property gets or sets the value for 'ForeignKeysToRecreate'.
            /// </summary>
            public List<ForeignKeyConstraint> ForeignKeysToRecreate
            {
                get { return foreignKeysToRecreate; }
                set { foreignKeysToRecreate = value; }
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
            
            #region HasForeignKeysToRecreate
            /// <summary>
            /// This property returns true if this object has a 'ForeignKeysToRecreate'.
            /// </summary>
            public bool HasForeignKeysToRecreate
            {
                get
                {
                    // initial value
                    bool hasForeignKeysToRecreate = (ForeignKeysToRecreate != null);

                    // return value
                    return hasForeignKeysToRecreate;
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
