namespace ApbdTest2.Domain.Models;

public class Customer
{
    public int CustomerId { get; set; }
    
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
    
    public string? PhoneNumber { get; set; }

    public virtual List<PurchasedTicket> PurchasedTickets { get; set; } = [];
}