using ApbdTest2.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApbdTest2.Infrastructure.Database.Configurations;

public class TicketTypeConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Ticket");
        
        builder.HasKey(t => t.TicketId);
        
        builder.Property(t => t.SerialNumber).HasMaxLength(50).IsRequired();
        builder.Property(t => t.SeatNumber).IsRequired();
    }
}