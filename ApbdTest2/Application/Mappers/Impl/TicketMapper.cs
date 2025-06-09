using ApbdTest2.Api.Contracts.Response;
using ApbdTest2.Domain.Models;

namespace ApbdTest2.Application.Mappers.Impl;

public class TicketMapper : ITicketMapper
{
    public TicketResponseDto ToTicketResponseDto(Ticket ticket)
    {
        return new TicketResponseDto(ticket.SerialNumber, ticket.SeatNumber);
    }
}