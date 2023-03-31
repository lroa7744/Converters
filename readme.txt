Hello reader!

INTRODUCTION
This solution contains all the projects required to make the Converters application
a reality. The application has been built using the ASP.NET Core Web App project type,
and some supporting Class Libraries.

REQUIREMENTS
The application has the following dependencies:

1. .NET 7.0
2. Microsoft SQL Server database

NOTES
Please host this app on a webserver that has the relevant runtime(s) installed.

There is an "appsettings.json" file in the "Converters.Web.App" project. In there you
will find a "Default" connection string. This will need updating so it points to
your Microsoft SQL Server.

I hope you enjoy using this application as much as I did making it!

FUTURE ENHANCEMENTS
I chose the application name "Converters" because I believe the "MicroURL" converter
is just the beginning. Additional converters could be added such as:

1. Weight
2. Temperature
3. Speed
etc...

Other enhancements include:

1. Move the "Base64EncodeAsync" and "Base64DecodeAsync" methods from the
   "MicroURLController.cs" into a reusable extensions class.
2. Add a button to copy the result URL to the clients clipboard.
3. Jazz the application design up.
4. Add account creation functionality so a user can set their favourite
   converters, choose a theme etc.
5. Add error handling/logging.
6. Ensure the application is WCAG compliant.
