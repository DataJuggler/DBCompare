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


