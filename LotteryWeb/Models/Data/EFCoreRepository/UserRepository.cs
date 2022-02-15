using LotteryWeb.Models.Entity;
using LotteryWeb.Models.Data.EFCoreRepository.Abstract;

namespace LotteryWeb.Models.Data.EFCoreRepository
{
    public class UserRepository : Repository<User, DatabaseContext>
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
