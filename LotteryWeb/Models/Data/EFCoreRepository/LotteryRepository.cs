using LotteryWeb.Models.Entity;
using LotteryWeb.Models.Data.EFCoreRepository.Abstract;

namespace LotteryWeb.Models.Data.EFCoreRepository
{
    public class LotteryRepository : Repository<Lottery, DatabaseContext>
    {
        public LotteryRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
