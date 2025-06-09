using ApbdTest2.Api.Contracts.Request;
using ApbdTest2.Api.Contracts.Response;

namespace ApbdTest2.Application.Services;

public interface ICustomerService
{
    Task<CustomerPurchasesResponseDto?> GetCustomerPurchasesByIdAsync(int customerId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// returns null when ticket limit exceeded.
    /// </summary>
    /// <param name="customerPurchasesRequestDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<CustomerPurchasesResponseDto?> CreatePurchasesForCustomerAsync(CreateCustomerPurchasesRequestDto customerPurchasesRequestDto, CancellationToken cancellationToken = default);
}