using ApbdTest2.Api.Contracts.Response;
using ApbdTest2.Domain.Models;

namespace ApbdTest2.Application.Mappers.Impl;

public class PurchasedTicketMapper(ITicketMapper ticketMapper, IConcertMapper concertMapper) : IPurchasedTicketMapper
{
    public PurchaseResponseDto ToPurchaseResponseDto(PurchasedTicket purchasedTicket)
    {
        var ticket = ticketMapper.ToTicketResponseDto(purchasedTicket.TicketConcert.Ticket);
        var concert = concertMapper.ToConcertResponseDto(purchasedTicket.TicketConcert.Concert);
        
        return new PurchaseResponseDto(purchasedTicket.PurchaseDate, purchasedTicket.TicketConcert.Price, ticket, concert);
    }
}