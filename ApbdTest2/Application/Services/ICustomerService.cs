using ApbdTest2.Api.Contracts.Response;

namespace ApbdTest2.Application.Services;

public interface ICustomerService
{
    Task<CustomerPurchasesResponseDto?> GetCustomerPurchasesByIdAsync(int customerId, CancellationToken cancellationToken = default);
}