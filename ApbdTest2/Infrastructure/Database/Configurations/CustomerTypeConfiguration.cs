using ApbdTest2.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApbdTest2.Infrastructure.Database.Configurations;

public class CustomerTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
       builder.ToTable("Customer");
       
       builder.HasKey(c => c.CustomerId);
       
       builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
       builder.Property(c => c.LastName).HasMaxLength(100).IsRequired();
       builder.Property(c => c.PhoneNumber).HasMaxLength(100);
    }
}