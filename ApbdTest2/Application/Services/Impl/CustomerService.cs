using ApbdTest2.Api.Contracts.Request;
using ApbdTest2.Api.Contracts.Response;
using ApbdTest2.Application.Exceptions;
using ApbdTest2.Application.Mappers;
using ApbdTest2.Domain.Models;
using ApbdTest2.Infrastructure.Persistance;
using ApbdTest2.Infrastructure.Repositories;

namespace ApbdTest2.Application.Services.Impl;

public class CustomerService(IUnitOfWork unitOfWork, ICustomerRepository customerRepository, ICustomerMapper customerMapper, IConcertRepository concertRepository, DateTimeProvider dateTimeProvider, IPurchasedTicketRepository purchasedTicketRepository) : ICustomerService
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

    public async Task<CustomerPurchasesResponseDto?> CreatePurchasesForCustomerAsync(CreateCustomerPurchasesRequestDto customerPurchasesRequestDto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await unitOfWork.BeginAsync(cancellationToken);
            var customer = await customerRepository.FindCustomerWithPurchasesByIdAsync(customerPurchasesRequestDto.Customer.Id, cancellationToken);
            if (customer == null)
            {
                customer = await customerRepository.CreateCustomerAsync(new Customer()
                {
                    FirstName = customerPurchasesRequestDto.Customer.FirstName,
                    LastName = customerPurchasesRequestDto.Customer.LastName,
                    PhoneNumber = customerPurchasesRequestDto.Customer.PhoneNumber,
                }, cancellationToken);
            }

            var purchasedTicketsEnumerable = customerPurchasesRequestDto.Purchases.Select(async p =>
            {
                var concert = await concertRepository.FindConcertByNameAsync(p.ConcertName, cancellationToken);
                if (concert == null)
                {
                    throw new NotFoundException($"Concert with name = '{p.ConcertName}' does not exist");
                }

                if (customer.PurchasedTickets.Count(pt => pt.TicketConcert.ConcertId == concert.ConcertId) >= 5)
                {
                    throw new ConflictException($"Customer can not purchase more than 5 tickets for a concert");
                }

                var ticket = new Ticket()
                {
                    SerialNumber = Guid.NewGuid().ToString(),
                    SeatNumber = p.SeatNumber,
                };

                var ticketConcert = new TicketConcert()
                {
                    Concert = concert,
                    Ticket = ticket,
                    ConcertId = concert.ConcertId,
                    TicketId = ticket.TicketId,
                    Price = p.Price,
                };

                var purchasedTicket = new PurchasedTicket()
                {
                    Customer = customer,
                    TicketConcert = ticketConcert,
                    PurchaseDate = dateTimeProvider.Now,
                };

                return await purchasedTicketRepository.CreatePurchasedTicket(purchasedTicket, cancellationToken);
            });
            
            customer.PurchasedTickets = (await Task.WhenAll(purchasedTicketsEnumerable)).ToList();
            await unitOfWork.CommitAsync(cancellationToken);
            
            return customerMapper.ToCustomerPurchasesDto(customer);
        }
        catch (Exception ex)
        {
            await unitOfWork.RollbackAsync(cancellationToken);
            throw;
        }
    }
}