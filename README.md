# DBCompare
DB Compare is used to compare two SQL Server databases and view a report of any schema differences. DB Compare was originally a sample of DataTier.Net and uses the same class SQLDatabaseConnector.cs to read the database schema.

<a href='https://youtu.be/13HipAOyAqU'>This is the most recent video on YouTube:</a>

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


