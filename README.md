# DBCompare
DB Compare is used to compare two instances of a SQL Server database and view a report of any schema differences. DB Compare was originally a sample of DataTier.Net and uses the same class, 
SQLDatabaseConnector.cs to read the database schema.

This project has been updated to .NET6.

4.14.2022 New Feature: Create a system EnvironmentVariable named SQLServerName. 
This will populate the server name when you build a connection string on the ConnectionStringBuilderForm. A time saver if you often use the same server.

Connection String Builder that ships with DataTier.Net will have this feature on the next update also.

--
Archive:

This project is also now a Nuget package, and you can create a complete Windows Form Application for .Net 5 in minutes, as shown here in this video:

https://youtu.be/IVzx8sCXxYY
