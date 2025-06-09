using System.Data.Common;
using ApbdTest2.Infrastructure.Database;
using Microsoft.EntityFrameworkCore.Storage;

namespace ApbdTest2.Infrastructure.Persistance;

public class UnitOfWork(ConcertsDbContext dbContext) : IUnitOfWork
{
    private IDbContextTransaction? _transaction;
    
    public async Task BeginAsync(CancellationToken cancellationToken = default)
    {
        _transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync(cancellationToken);
            await _transaction.DisposeAsync();
        }
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync(cancellationToken);
            await _transaction.DisposeAsync();
        }
    }
}