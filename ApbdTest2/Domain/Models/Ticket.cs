namespace ApbdTest2.Domain.Models;

public class Ticket
{
    public int TicketId { get; set; }
    
    public required string SerialNumber { get; set; }
    
    public required int SeatNumber { get; set; }

    public virtual List<TicketConcert> TicketConcerts { get; set; } = [];
}