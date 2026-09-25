<p align="center">
  <img src="https://raw.githubusercontent.com/DataJuggler/SharedRepo/master/Shared/Images/DBCompare.png" alt="DB Compare" width="512" height="512">
</p>

# DB Compare 10.1.2

**DB Compare 10.1.2 is a major upgrade.**

DB Compare compares two SQL Server databases and generates a report of any schema differences. **Generate Scripts** is no longer a work in progress and now works really well.

**Purpose:** Ensure all copies of a database have the same schema.

## Download

Installers are available on the [Releases](../../releases) page.

## What Gets Compared

1. **Tables**
   - **Fields:** data type, size, nullable, and other information about each field
   - **Indexes**
   - **Foreign Key Constraints**
   - **Default Value Constraints**
2. **Views**
3. **Stored Procedures**
4. **Functions**

## What's New in Version 10

### Composite Indexes and Foreign Keys
Indexes and Foreign Key Constraints have been completely overhauled. The previous version only handled single-field indexes and foreign keys. Now composite Indexes and Foreign Key Constraints made up of one or more fields are loaded and compared.

### Smarter Default Value Constraints
Default Value Constraints now check non-numeric defaults, such as `GETDATE()`, `NEWID()`, or string defaults like `'Pending'`.

### Generate Scripts
Generate Scripts has also gone through a major upgrade:

- Generated tables now keep the same field ordinal order as the source table.
- Indexes and Foreign Key Constraints are now scripted in one pass. Before, this either took two passes or wasn't supported.

## Requirements

- .NET 10
- SQL Server
- NuGet package [DataJuggler.NET.Data](https://www.nuget.org/packages/DataJuggler.NET.Data) version 10.1.2, which matches this release

## History

This project has been around since about 2010, when it was built on the .NET Framework. It has since been updated to .NET 10.

## Credits

I have to give Claude credit for helping me overhaul how Indexes and Foreign Key Constraints work. This project now does a much better job of comparing two databases.
