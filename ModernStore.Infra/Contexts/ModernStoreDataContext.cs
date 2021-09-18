using System;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;
using ModernStore.Infra.Mappings;

namespace ModernStore.Infra.Contexts
{
    public class ModernStoreDataContext : DbContext
    {
        public ModernStoreDataContext(DbContextOptions<ModernStoreDataContext> options)
        : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CustomerMap(modelBuilder);
            new OrderMap(modelBuilder);
            new OrderItemMap(modelBuilder);
            new ProductMap(modelBuilder);
            new UserMap(modelBuilder);

        }
    }
}
