using LotteryWeb.Models.Entity;
using LotteryWeb.Models.Data.EFCoreRepository.Abstract;
using System.Linq;

namespace LotteryWeb.Models.Data.EFCoreRepository
{
    public class LotteryRepository : Repository<Lottery, DatabaseContext>
    {
        public LotteryRepository(DatabaseContext context) : base(context)
        {
        }

       
    }
}
