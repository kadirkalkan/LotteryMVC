using LotteryWeb.Models.Entity;
using LotteryWeb.Models.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace LotteryWeb.Models.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Lottery> Lotteries { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Winner> Winners { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BetEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LotteryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new WinnerEntityConfiguration());
        }
    }
}
