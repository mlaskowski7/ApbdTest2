using ApbdTest2.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApbdTest2.Infrastructure.Database.Configurations;

public class TicketConcertTypeConfiguration : IEntityTypeConfiguration<TicketConcert>
{
    public void Configure(EntityTypeBuilder<TicketConcert> builder)
    {
       builder.ToTable("Ticket_Concert");
       
       builder.HasKey(tc => tc.TicketConcertId);
       
       builder.Property(tc => tc.Price).HasColumnType("decimal(10,2)").IsRequired();
       
       builder.HasOne(tc => tc.Ticket).WithMany(t => t.TicketConcerts).HasForeignKey(tc => tc.TicketId).IsRequired();
       builder.HasOne(tc => tc.Concert).WithMany(c => c.TicketConcerts).HasForeignKey(tc => tc.ConcertId).IsRequired();
    }
}