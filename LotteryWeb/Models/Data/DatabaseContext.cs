using LotteryWeb.Models.Entity;
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
    }
}
