using ApbdTest2.Api.Contracts.Response;
using ApbdTest2.Domain.Models;

namespace ApbdTest2.Application.Mappers;

public interface ICustomerMapper
{
    CustomerPurchasesResponseDto ToCustomerPurchasesDto(Customer customer);
}