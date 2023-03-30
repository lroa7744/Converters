using Converters.Domain.Abstractions.Repositories;
using Converters.Domain.Abstractions.Services;
using Converters.Domain.Models.Database;

namespace Converters.Services;

public class MicroURLService : BaseService, IMicroURLService
{
    private readonly IMicroURLRepository _microURLRepository;

    public MicroURLService(
        IMicroURLRepository microURLRepository)
    {
        _microURLRepository = microURLRepository;
    }

    public Task<URL?> GetURLAsync(int id)
    {
        return Task.FromResult(_microURLRepository.Find(id));
    }

    public Task<int> SaveURLAsync(string value)
    {
        var url = new URL
        {
            Value = value
        };

        return Task.FromResult(_microURLRepository.Add(url));
    }
}
