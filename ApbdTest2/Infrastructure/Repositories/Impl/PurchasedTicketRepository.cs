using ApbdTest2.Domain.Models;
using ApbdTest2.Infrastructure.Database;

namespace ApbdTest2.Infrastructure.Repositories.Impl;

public class PurchasedTicketRepository(ConcertsDbContext dbContext) : IPurchasedTicketRepository
{
    public async Task<PurchasedTicket> CreatePurchasedTicket(PurchasedTicket purchasedTicket, CancellationToken cancellationToken)
    {
        var saved = await dbContext.PurchasedTickets.AddAsync(purchasedTicket, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return saved.Entity;
    }
}