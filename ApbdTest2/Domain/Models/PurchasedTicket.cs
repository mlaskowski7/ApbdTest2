namespace ApbdTest2.Domain.Models;

public class PurchasedTicket
{
    public int TicketConcertId { get; set; }
    
    public int CustomerId { get; set; }
    
    public required DateTime PurchaseDate { get; set; }
    
    public virtual TicketConcert TicketConcert { get; set; }
    
    public virtual Customer Customer { get; set; }
}