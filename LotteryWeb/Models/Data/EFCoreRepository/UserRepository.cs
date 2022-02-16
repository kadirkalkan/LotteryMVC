using LotteryWeb.Models.Entity;
using LotteryWeb.Models.Data.EFCoreRepository.Abstract;
using System.Threading.Tasks;
using System.Linq;

namespace LotteryWeb.Models.Data.EFCoreRepository
{
    public class UserRepository : Repository<User, DatabaseContext>
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public User GetByUsername(string username)
        {
            return _context.Set<User>().FirstOrDefault(x=> x.Username.Equals(username));
        }
        public bool IsLoginValid(string username, string password)
        {
            return _context.Set<User>().FirstOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password)) != null;
        }
        public User GetLoggedUser(string username, string password)
        {
            return _context.Set<User>().FirstOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password));
        }

    }
}
