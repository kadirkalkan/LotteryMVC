using LotteryWeb.Controllers.Abstract;
using LotteryWeb.Models.Data.EFCoreRepository;
using LotteryWeb.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LotteryWeb.Controllers.CrudController
{
    public class BetController : BaseController<Bet, BetRepository>
    {
        public BetController(BetRepository repository) : base(repository)
        {

        }

        public async Task<IActionResult> Index()
        {
            return View(await Get());
        }
    }
}
