using ApbdTest2.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApbdTest2.Infrastructure.Database.Configurations;

public class PurchasedTicketTypeConfiguration : IEntityTypeConfiguration<PurchasedTicket>
{
    public void Configure(EntityTypeBuilder<PurchasedTicket> builder)
    {
        builder.ToTable("Purchased_Ticket");

        builder.HasKey(pt => new { pt.TicketConcertId, pt.CustomerId });
        
        builder.Property(pt => pt.PurchaseDate).HasColumnType("datetime").IsRequired();
        
        builder.HasOne(pt => pt.TicketConcert).WithMany(tc => tc.PurchasedTickets).HasForeignKey(pt => pt.TicketConcertId).IsRequired();
        builder.HasOne(pt => pt.Customer).WithMany(c => c.PurchasedTickets).HasForeignKey(pt => pt.CustomerId).IsRequired();
    }
}