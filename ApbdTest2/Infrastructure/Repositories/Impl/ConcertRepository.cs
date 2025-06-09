using ApbdTest2.Domain.Models;
using ApbdTest2.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace ApbdTest2.Infrastructure.Repositories.Impl;

public class ConcertRepository(ConcertsDbContext dbContext) : IConcertRepository
{
    private readonly DbSet<Concert> _concerts = dbContext.Concerts;
    
    public async Task<Concert?> FindConcertByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _concerts.FirstOrDefaultAsync(c => c.Name == name, cancellationToken);
    }
}