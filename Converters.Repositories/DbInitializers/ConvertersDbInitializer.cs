using Converters.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Converters.Repositories.DbInitializers;

public static class ConvertersDbInitializer
{
    public static async Task InitializeAsync(ConvertersContext context)
    {
        context.Database.EnsureCreated();

        if (context.URLs.Any())
            return; // DB has been seeded.

        var databaseName = context.Database.GetDbConnection().Database;

        await context.Database.ExecuteSqlRawAsync($"USE {databaseName}; ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = OFF;"); // Temporary.

        // Add code to seed DB here.
    }
}
