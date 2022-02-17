using LotteryWeb.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LotteryWeb.Models.EntityConfiguration
{
    public class LotteryEntityConfiguration : IEntityTypeConfiguration<Lottery>
    {
        public void Configure(EntityTypeBuilder<Lottery> builder)
        {
            builder.ToTable("Lotteries");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Number1).IsRequired();
            builder.Property(x => x.Number2).IsRequired();
            builder.Property(x => x.Number3).IsRequired();
            builder.Property(x => x.Number4).IsRequired();
            builder.Property(x => x.Number5).IsRequired();
            builder.Property(x => x.Number6).IsRequired();

            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");
        }
    }
}
