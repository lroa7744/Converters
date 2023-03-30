using Converters.Domain.Abstractions;
using Converters.Domain.Abstractions.Models.Database;
using Converters.Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Converters.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : class, IDatabaseObject, new()
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;
    private bool disposedValue;

    public BaseRepository(
        IUnitOfWork unitOfWork)
    {
        _context = (DbContext)unitOfWork;
        _dbSet = _context.Set<T>();
    }

    #region Dispose
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
                _context.Dispose();

            disposedValue = true;
        }
    }

    //~BaseRepository()
    //{
    //    // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method.
    //    Dispose(disposing: false);
    //}

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method.
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
    #endregion

    public int Commit() => _context.SaveChanges();

    public virtual int Add(T item)
    {
        Save(item);
        Commit();

        return item.Id;
    }

    public virtual T? Find(int id)
    {
        return _dbSet.Find(id);
    }

    #region Helpers
    private void Save(T entity)
    {
        var entry = _context.Entry(entity);

        if (entry == null || entry.State == EntityState.Detached)
            _dbSet.Add(entity);
    }
    #endregion
}
