using ApbdTest2.Domain.Models;

namespace ApbdTest2.Infrastructure.Repositories;

public interface IConcertRepository
{
    Task<Concert?> FindConcertByNameAsync(string name, CancellationToken cancellationToken = default);
}