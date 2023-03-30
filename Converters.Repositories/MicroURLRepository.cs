using Converters.Domain.Abstractions;
using Converters.Domain.Abstractions.Repositories;
using Converters.Domain.Models.Database;

namespace Converters.Repositories;

public class MicroURLRepository : BaseRepository<URL>, IMicroURLRepository
{
    public MicroURLRepository(
        IUnitOfWork unitOfWork)
        : base(unitOfWork)
    {
        //
    }
}
