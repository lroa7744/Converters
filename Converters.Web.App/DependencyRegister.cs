using Converters.Domain.Abstractions.Repositories;
using Converters.Domain.Abstractions.Services;
using Converters.Repositories;
using Converters.Services;

namespace Converters.Web.App;

public static class DependencyRegister
{
    public static IServiceCollection AddDefaultServices(this IServiceCollection services)
    {
        services.AddRepositories();
        services.AddServices();

        return services;
    }

    #region Helpers
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IMicroURLRepository, MicroURLRepository>();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IMicroURLService, MicroURLService>();

        return services;
    }
    #endregion
}
