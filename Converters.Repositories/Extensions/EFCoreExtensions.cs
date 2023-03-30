using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Converters.Repositories.Extensions;

public static class EFCoreExtensions
{
    public static DbContextOptions ToDbContextOptions(
        this Action<DbContextOptionsBuilder> optionsAction)
    {
        var builder = new DbContextOptionsBuilder(
            new DbContextOptions<DbContext>(
                new Dictionary<Type, IDbContextOptionsExtension>()
            )
        );

        optionsAction.Invoke(builder);

        return builder.Options;
    }
}
