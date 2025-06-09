using ApbdTest2.Domain.Models;

namespace ApbdTest2.Infrastructure.Repositories;

public interface IPurchasedTicketRepository
{
    Task<PurchasedTicket> CreatePurchasedTicket(PurchasedTicket purchasedTicket, CancellationToken cancellationToken);
}