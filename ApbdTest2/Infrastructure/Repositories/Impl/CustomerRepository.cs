using ApbdTest2.Domain.Models;
using ApbdTest2.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace ApbdTest2.Infrastructure.Repositories.Impl;

public class CustomerRepository(ConcertsDbContext dbContext) : ICustomerRepository
{
    private readonly DbSet<Customer> _customers = dbContext.Customers;
    
    public async Task<Customer?> FindCustomerWithPurchasesByIdAsync(int customerId, CancellationToken cancellationToken = default)
    {
        return await _customers.Include(c => c.PurchasedTickets)
            .ThenInclude(pt => pt.TicketConcert)
            .ThenInclude(tc => tc.Ticket)
            .Include(c => c.PurchasedTickets)
            .ThenInclude(pt => pt.TicketConcert)
            .ThenInclude(tc => tc.Concert)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Customer> CreateCustomerAsync(Customer customer, CancellationToken cancellationToken = default)
    {
       var saved = await _customers.AddAsync(customer, cancellationToken); 
       await dbContext.SaveChangesAsync(cancellationToken);
       return saved.Entity;
    }
}