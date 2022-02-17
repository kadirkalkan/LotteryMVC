using LotteryWeb.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LotteryWeb.Models.EntityConfiguration
{
    public class BetEntityConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.ToTable("Bets");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Number1).IsRequired();
            builder.Property(x => x.Number2).IsRequired();
            builder.Property(x => x.Number3).IsRequired();
            builder.Property(x => x.Number4).IsRequired();
            builder.Property(x => x.Number5).IsRequired();
            builder.Property(x => x.Number6).IsRequired();
            
            builder.Property(x=> x.UserId).IsRequired();
            builder.Property(x=> x.LotteryId).IsRequired();

            builder.HasOne(bet => bet.User).WithMany(user => user.Bets).HasForeignKey(bet => bet.UserId);
            builder.HasOne(bet => bet.Lottery).WithMany(lottery => lottery.Bets).HasForeignKey(bet => bet.LotteryId);
        }
    }
}
