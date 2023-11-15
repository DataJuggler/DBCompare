# DBCompare
DB Compare is used to compare two SQL Server databases and view a report of any schema differences. DB Compare was originally a sample of DataTier.Net and uses the same class SQLDatabaseConnector.cs to read the database schema.

<a href='https://youtu.be/13HipAOyAqU'>This is the most recent video on YouTube:</a>

Update 11.15.2023: This project has been updated to .NET 8.

Update 10.20.2022: This project has been updated to .NET 7.
You must use Visual Studio 2022 Preview until the full version comes out.

Breaking change: Microsoft.Data.SqlClient version 5.0 (same with 4.0) has encryption turned on by default.
If your database is not encrypted, you must add Encrypt=false to your connection string.
If you build your connection string using the Connection String Builder Form, there is an option
'Turn Off Encryption'.

I just published a video that demonstrates how to use this.

Please like and subscribe to my channel if you find this useful.

https://youtu.be/0dMvALbl6MA

To run this project as a Nuget package, follow these steps.

Modify your Program.cs.

Step 1: 

Change the line that runs this app to this:

Application.Run(new DBCompare.MainForm());


Step 2:

Run the application.

Step 3: 

Enter or Build Your Source and Target Connection Strings.

Step 4:

Click the Compare Button

Step 5:

View the report that was created.

I am working on changes for creating the SQL to update, but I wanted to convert to .Net 5 before I did this.

Watch for a new 'Create Update Scripts' button coming in the coming days hopefully. Or by 2029. I get busy sometimes
and have too many projects.

Enjoy. Please report any bug on Git Hub:

https://github.com/DataJuggler/DBCompare



As will all my open source, they come with triple your money back if you are not happy, after a small $1.50 restocking fee.





Update 9.12.2019: DBCompare install can not be downloaded here: https://datajuggler.com/Downloads/DBCompare.msi

Update 6.29.2019: 
Version 2.1 New Features
1. Ignore DataSync - My boss installed SQL DataSync on our servers so we can run our websites on SQL Express, which is much faster than Azure SQL, but he likes Azure SQL for backups so now we have the database on the VM backed up and mirred to Azure SQL.
Works pretty well and every 10 minutes they sync up any changes.

SQL DataSync added 717 tables / procedures to my comparisons, so now I ignore these by default unless you turn it on.

2. Ignore Firewall Rules - Azure SQL adds a view database_firewall_rules. This is ignored by default unless you turn it on.

3. I made the compare method async, and it helps a little as far as you no longer see (NotResponding), but the hourglass stays on so I might need to rethink the hourglass when hovering over the main form title bar for movement.

4. I updated the Nuget package DataJuggler.Net to version 5.5.0 to handle this optional parameters for IgnoreDataSync and IgnoreFirewallRules.

The only possible breaking change is if you have a table or view with (underscore)dss in the name it will not be added for comparison. (if I type _dss it goes to italics for some dumb reason). 

I just rented a virtual machine, so soon I am going to build a DB Compare online. 

It will be easy to build the Azure to Azure comparision, for the comparision of your home machine vs an Azure I haven't figure that out yet. Suggestions anyone?

This project now has Git Hub Pages setup. Book mark this and I will try and keep it up to date with the latest news:

<a href='https://datajuggler.github.io/DBCompare/'>DB Compare Home - Git Hub Pages</a>

The video lists the URL incorrectly, now DB Compare is in its own repo:

<a href='https://github.com/DataJuggler/DBCompare'>DB Compare on Git Hub<a/>

The main engine of DB Compare and the project DataTier.Net is a class library called DataJuggler.Net.

For any projects that need to read the database schema of a SQL Server database, DataJuggler.Net is available as a Nuget Package:

Update 6.29.2019:
Install-Package DataJuggler.Net -Version 5.5.0

Or install the package using NuGet Package Manager (which is what I do).

I am building a website this weekend, so I will have an install version available soon (I took the install out of the repo).

Please visit my YouTube channel as I make new videos often:

<a href='https://www.youtube.com/channel/UCaw0joqvisKr3lYJ9Pd2vHA'>Data Juggler YouTube Channel</a>


