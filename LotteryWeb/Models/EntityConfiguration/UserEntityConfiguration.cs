using LotteryWeb.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LotteryWeb.Models.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // OnModelCreating Metodunun içerisinde kullanılan modelBuilder.Entity yapısı ile EntityTypeBuilder aynıdır.
            //modelBuilder.Entity<User>() == EntityTypeBuilder<User>

            builder.ToTable("Users");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.Username).HasMaxLength(50);

            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(50);

            builder.Property(x => x.Balance).HasColumnType("decimal(18, 2)");


            builder.HasData(
                new User() { Id = 1, Username = "admin", Password = "123456789", Balance = 1000 }
                );
        }
    }
}
