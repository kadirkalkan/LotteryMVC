using LotteryWeb.Models.Entity;
using LotteryWeb.Models.Data.EFCoreRepository.Abstract;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public List<Bet> GetBetsByUserId(int userId)
        {
            return _context.Bets.Include(x => x.Lottery).Where(x => x.UserId == userId).ToList();
        }

        public Bet GetBetById(int userId)
        {
            return _context.Bets.Include(x => x.Lottery).FirstOrDefault(x => x.Id == userId);
        }
    }
}
