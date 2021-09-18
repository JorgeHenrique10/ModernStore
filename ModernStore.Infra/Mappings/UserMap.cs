using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class UserMap
    {
        public UserMap(ModelBuilder modelBuilder)
        {

            modelBuilder
            .Entity<User>(builder =>
            {
                builder.ToTable("User");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.UserName).IsRequired().HasMaxLength(20);
                builder.Property(x => x.Password).IsRequired().HasMaxLength(32).IsFixedLength();
                builder.Property(x => x.Active);

            });

        }
    }
}