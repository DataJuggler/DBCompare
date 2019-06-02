You can help support this project by:
1. Leaving a kind word on any of our YouTube videos or Open Source Projects
2. Purchasing NFlate from the Windows Store
3. Make a donation at www.gofundme.com/teeth-a-thon

At the moment I have 3 front teeth missing due to 15 years of working at software companies that thought they were cool having free coke machines. If you know someone that is truly needy help them instead, but If you can spare a $1 or more, collectively I could raise enough to fill like a real human again. Open source doesn't pay very well so help if you can please.

Update for 1.7.1: (Includes cummlative updates for 1.6.2 - 1.6.3 - 1.7.0 which were not published)
1. Check Constraints are now compared, and if a constraint returns multiple rows (Fields) than only one schema difference is reported.
2. I just recently found out Default Values are not populated so I have to query for that separately, so it may seem a little slower now on larger databases as it queries each field that is not auto increment for the default value.
3. There is now a checkbox 'Exclude Diagram Procedures' that is checked by default. If you view a diagram in a database it adds about 8 procedures to the database that probably would not get rolled out to production or test databases.

Update for version 1.6.1: Azure SQL does not support the table SysComments so my method for finding the function text had
to change to use Sys.all_sql_modules; further testing for Azure may be needed; when I move to production on our next release cycle I will do more Azure testing.

Updates for version 1.6.0: I now clear the text of the last comparison when a new comparison is started.
I also added a counter to list the number of schema differences.

I also started a Sync tool, I have this code commented out, but it is on my todo list
to create functionality to propegate the changes or create sql scripts to update the target database.

Updates for version 1.5.1: The UI was updated to be consistent with other Data Juggler products as well as the font sizes was increased

Also the Random Banner control was added to randomly show a few of my commercial products.
Check Constraints Are Compared (and working, the 1.4 Release I thought I had done this but it was planned and not implemented)
A Swap Button was added to swap the Source & Target Connection Strings (this was on my to do list for a year)
A link to the DB Compare movie on YouTube; a like or a few kind words here is appreciated! This is the open source equivalent of making a sale.

Updates for version 1.4.0: Check Constraints are compared (but didn't work, they are fixed in 1.5)

Updates for version 1.3.0: For the first time indexes were compared to ensure they were deployed with the database

Updates for version 1.2.0: Fixed the Stored Procedure Comparison

I tested the new stored procedure comparison module for any changes in the text, 
however I had an else in the wrong place if the stored procedure was not found. My QA department (me also) only comes
in on the weekend. 

Also, since I had to do a new update, I added an option to store the source and target connection strings any time you
compare. If you do not like this feature just uncheck the box and it will not store any settings.
I know the proper way to do it would be to allow saving sets of connection strings, but I only have so much time.

Updates for version 1.1.9: The original version of DB Compare was not 100% accurate for comparing stored procedures.

This version executes the procedure sp_helptext for each source and target procedure and if the text is different a comparison difference will be reported.

The text comparison is very sensitive so any comments or localizations in your procedures will report a difference that may not be a true schema difference. Any parameter or select field differences will accurately be reported now, so that is a trade off I felt is worth it.


Please support my web site www.daily-click.com 

I hope you enjoy DB Compare.


