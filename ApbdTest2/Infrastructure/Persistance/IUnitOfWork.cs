namespace ApbdTest2.Infrastructure.Persistance;

public interface IUnitOfWork
{
    Task BeginAsync(CancellationToken cancellationToken = default);
    
    Task RollbackAsync(CancellationToken cancellationToken = default);
    
    Task CommitAsync(CancellationToken cancellationToken = default);
}