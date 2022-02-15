using LotteryWeb.Models.Entity;
using LotteryWeb.Controllers.Abstract;
using LotteryWeb.Models.Data.EFCoreRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LotteryWeb.Controllers.CrudController
{
    [Route("[controller]")]
    public class UserController : BaseController<User, UserRepository>
    {
        public UserController(UserRepository repository) : base(repository)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View(await Get()); // Get Metodu BaseController'dan geliyor.
        }
    }
}
