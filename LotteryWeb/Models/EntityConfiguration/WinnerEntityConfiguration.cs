using LotteryWeb.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LotteryWeb.Models.EntityConfiguration
{
    public class WinnerEntityConfiguration : IEntityTypeConfiguration<Winner>
    {
        public void Configure(EntityTypeBuilder<Winner> builder)
        {
            builder.ToTable("Winners");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Prize).HasColumnType("decimal(18, 2)");

            builder.HasOne(winner => winner.Bet).WithOne(bet => bet.Winner).HasForeignKey<Winner>(winner => winner.Id);

        }
    }
}
