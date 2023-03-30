using Converters.Domain;
using Converters.Domain.Abstractions;
using Converters.Domain.Models.Database;
using Converters.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Converters.Repositories.Contexts;

public class ConvertersContext : DbContext, IUnitOfWork
{
    public virtual DbSet<URL> URLs { get; set; }

    public ConvertersContext()
    {
        //
    }

    public ConvertersContext(
        Action<DbContextOptionsBuilder> optionsAction)
        : base(optionsAction.ToDbContextOptions())
    {
        //
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .Build();

        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(configuration.GetConnectionString(DefaultConstants.ConnectionStringKey));
    }
}
