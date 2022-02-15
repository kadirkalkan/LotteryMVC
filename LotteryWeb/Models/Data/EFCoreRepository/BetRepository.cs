using LotteryWeb.Models.Entity;
using LotteryWeb.Models.Data.EFCoreRepository.Abstract;

namespace LotteryWeb.Models.Data.EFCoreRepository
{
    public class BetRepository : Repository<Bet, DatabaseContext>
    {
        public BetRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
