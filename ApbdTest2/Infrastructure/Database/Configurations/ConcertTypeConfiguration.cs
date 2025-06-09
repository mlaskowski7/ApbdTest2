using ApbdTest2.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApbdTest2.Infrastructure.Database.Configurations;

public class ConcertTypeConfiguration : IEntityTypeConfiguration<Concert>
{
    public void Configure(EntityTypeBuilder<Concert> builder)
    {
        builder.ToTable("Concert");
        
        builder.HasKey(c => c.ConcertId);
        
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Date).HasColumnType("datetime").IsRequired();
        builder.Property(c => c.AvailableTickets).IsRequired();
    }
}