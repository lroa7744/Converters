using Converters.Domain.Models.Database;

namespace Converters.Domain.Abstractions.Services;

public interface IMicroURLService : IBaseService
{
    Task<URL?> GetURLAsync(int id);
    Task<int> SaveURLAsync(string value);
}
