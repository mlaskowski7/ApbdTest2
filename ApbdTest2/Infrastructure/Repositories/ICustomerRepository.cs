using ApbdTest2.Domain.Models;

namespace ApbdTest2.Infrastructure.Repositories;

public interface ICustomerRepository
{
   Task<Customer?> FindCustomerWithPurchasesByIdAsync(int customerId, CancellationToken cancellationToken = default);
}