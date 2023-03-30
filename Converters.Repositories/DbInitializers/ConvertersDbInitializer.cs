using Converters.Repositories.Contexts;

namespace Converters.Repositories.DbInitializers;

public static class ConvertersDbInitializer
{
    public static void Initialize(ConvertersContext context)
    {
        context.Database.EnsureCreated();

        if (context.URLs.Any())
            return; // DB has been seeded.

        // Add code to populate DB here.
    }
}
