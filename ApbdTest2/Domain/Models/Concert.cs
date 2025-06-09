namespace ApbdTest2.Domain.Models;

public class Concert
{
    public int ConcertId { get; set; }
    
    public required string Name { get; set; }
    
    public required DateTime Date { get; set; }
    
    public required int AvailableTickets { get; set; }

    public virtual List<TicketConcert> TicketConcerts { get; set; } = [];
}