using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class ProductMap
    {
        public ProductMap(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Product>(builder =>
           {
               builder.ToTable("Products");
               builder.Property(x => x.Image).IsRequired().HasMaxLength(1024);
               builder.Property(x => x.Price);
               builder.Property(x => x.QuantityOnHand);
               builder.Property(x => x.Title).HasMaxLength(80);
           });

        }
    }
}