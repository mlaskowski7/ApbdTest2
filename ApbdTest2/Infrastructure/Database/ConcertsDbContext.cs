using ApbdTest2.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ApbdTest2.Infrastructure.Database;

public class ConcertsDbContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<Concert> Concerts { get; set; }
    
    public DbSet<Customer> Customers { get; set; }
    
    public DbSet<TicketConcert> TicketConcerts { get; set; }
    
    public DbSet<PurchasedTicket> PurchasedTickets { get; set; }
    
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConcertsDbContext).Assembly);
    }
}