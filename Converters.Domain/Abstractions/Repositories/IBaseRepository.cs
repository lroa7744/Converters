
namespace Converters.Domain.Abstractions.Repositories;

public interface IBaseRepository<T> : IDisposable where T : class, new()
{
    int Commit();
    int Add(T item);
    T? Find(int id);
}
