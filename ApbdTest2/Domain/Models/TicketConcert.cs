namespace ApbdTest2.Domain.Models;

public class TicketConcert
{
    public int TicketConcertId { get; set; }
    
    public int TicketId { get; set; }
    
    public int ConcertId { get; set; }
    
    public required decimal Price { get; set; }
    
    public virtual Ticket Ticket { get; set; }
    
    public virtual Concert Concert { get; set; }
}