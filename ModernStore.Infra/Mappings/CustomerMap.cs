using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class CustomerMap
    {

        public CustomerMap(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Customer>(builder =>
            {
                builder.ToTable("Customer");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.BirthDate);
                //builder.Property(x => x.Document.Number);
                //builder.Property(x => x.Email.Address);
                //builder.Property(x => x.Name.FirstName);
                //builder.Property(x => x.Name.LastName);

                builder.OwnsOne(x => x.Document)
                .Property(x => x.Number).IsRequired().HasMaxLength(11).IsFixedLength()
                .HasColumnName("Number")
                .IsRequired();

                builder.OwnsOne(x => x.Email)
                .Property(x => x.Address).IsRequired().HasMaxLength(160)
                .HasColumnName("Address")
                .IsRequired();

                builder.OwnsOne(x => x.Name)
                .Property(x => x.FirstName).IsRequired().HasMaxLength(60)
                .HasColumnName("FirstName")
                .IsRequired();

                builder.OwnsOne(x => x.Name)
                .Property(x => x.LastName).IsRequired().HasMaxLength(60)
                .HasColumnName("LastName")
                .IsRequired();

            });
        }

    }
}