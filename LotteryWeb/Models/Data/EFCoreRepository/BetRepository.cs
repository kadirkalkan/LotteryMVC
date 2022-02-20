using LotteryWeb.Models.Entity;
using LotteryWeb.Models.Data.EFCoreRepository.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace LotteryWeb.Models.Data.EFCoreRepository
{
    public class BetRepository : Repository<Bet, DatabaseContext>
    {
        public BetRepository(DatabaseContext context) : base(context)
        {
        }
        public List<Bet> GetBetsByLotteryId(int lotteryId)
        {
            return _context.Bets.Where(x => x.LotteryId == lotteryId).ToList();
        } 
    }
}
