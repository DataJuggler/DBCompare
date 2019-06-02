

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

}
