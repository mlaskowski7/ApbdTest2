using ApbdTest2.Api.Contracts.Response;
using ApbdTest2.Domain.Models;

namespace ApbdTest2.Application.Mappers.Impl;

public class CustomerMapper(IPurchasedTicketMapper purchasedTicketMapper) : ICustomerMapper
{
    public CustomerPurchasesResponseDto ToCustomerPurchasesDto(Customer customer)
    {
        var purchases = customer.PurchasedTickets.Select(purchasedTicketMapper.ToPurchaseResponseDto).ToList();
        
        return new CustomerPurchasesResponseDto(customer.FirstName, customer.LastName, customer.PhoneNumber, purchases);
    }
}