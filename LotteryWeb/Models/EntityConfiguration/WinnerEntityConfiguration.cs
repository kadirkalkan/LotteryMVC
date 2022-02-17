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
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Prize).HasColumnType("decimal(18, 2)");

            builder.HasOne(winner => winner.Bet).WithMany(bet => bet.Winners).HasForeignKey(winner => winner.BetId);

        }
    }
}
