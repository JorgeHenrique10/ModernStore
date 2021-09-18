using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class OrderItemMap
    {
        public OrderItemMap(ModelBuilder modelBuilder)
        {
            modelBuilder
           .Entity<OrderItem>(builder =>
           {
               builder.ToTable("OrderItem");
               builder.HasKey(x => x.Id);
               builder.Property(x => x.Price).HasColumnType("money");
               builder.Property(x => x.Quantity);
           });
        }
    }
}