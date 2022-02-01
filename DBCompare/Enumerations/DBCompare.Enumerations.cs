

namespace DBCompare.Enumerations
{

	#region CompareTypeEnum : int
	/// <summary>
    /// This enumeration is used to determine which type of comparison is to be performed.
    /// </summary>
    public enum CompareTypeEnum : int
    {
		CompareTwoSQLDatabases = 0,
		CreateXmlFile = 1,
		CompareXmlFileAndSQLDatabase = 2
	}
	#endregion

	#region DifferenceTypeEnum : int
	/// <summary>
    /// This enumeration is used to set what type of difference it is
    /// </summary>
    public enum DifferenceTypeEnum : int
    {
		UnableToLoadSourceAndTarget = -3,
		UnableToLoadTarget = -2,
		UnableToLoadSource = -1,		
		NoDifferences = 0,
		FieldIsMissing = 1,
		FieldInvalid = 2,
		TableIsMissing = 3,
		StoredProcedureMissingOrInvalid = 5,
		SourceTableHasNoFields = 6,
		TargetDatabaseHasNoFields = 7,
		CheckConstraintNotFound = 10,
		CheckConstraintNotValid = 11,
		ForeignKeyNotFound = 20,
		ForeignKeyWrongTableName = 21,
		ForeignKeyWrongReferencedColumn = 22,
		FunctionNotFound = 30,
		FunctionNotValid = 31,
		IndexNotFound = 40,
		IndexNotValid = 41,
		TargetDatabaseContainsExtraProcedure = 50,
		TargetDatabaseContainsNoProcedures = 51,
		TargetDatabaseContainsExtraTable = 60,
		TargetDatabaseContainsExtraField = 61,
		TargetDatabaseDoesNotContainAnyFields = 62,
		SourceDatabaseContainsNoTables = 70
	}
	#endregion

}
