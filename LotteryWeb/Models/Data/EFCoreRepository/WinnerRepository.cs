using LotteryWeb.Models.Entity;
using LotteryWeb.Models.Data.EFCoreRepository.Abstract;

namespace LotteryWeb.Models.Data.EFCoreRepository
{
    public class WinnerRepository : Repository<Winner, DatabaseContext>
    {
        public WinnerRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
