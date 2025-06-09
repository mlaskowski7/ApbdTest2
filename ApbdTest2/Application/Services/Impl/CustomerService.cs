using ApbdTest2.Api.Contracts.Response;
using ApbdTest2.Application.Mappers;
using ApbdTest2.Infrastructure.Repositories;

namespace ApbdTest2.Application.Services.Impl;

public class CustomerService(ICustomerRepository customerRepository, ICustomerMapper customerMapper) : ICustomerService
{
    public async Task<CustomerPurchasesResponseDto?> GetCustomerPurchasesByIdAsync(int customerId, CancellationToken cancellationToken = default)
    {
        var customer = await customerRepository.FindCustomerWithPurchasesByIdAsync(customerId, cancellationToken);
        if (customer == null)
        {
            return null;
        }
        
        return customerMapper.ToCustomerPurchasesDto(customer);
    }
}