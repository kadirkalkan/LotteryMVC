using LotteryWeb.Controllers.Abstract;
using LotteryWeb.Models.Data.EFCoreRepository;
using LotteryWeb.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LotteryWeb.Controllers
{
    public class BetController : Controller
    {
        private readonly BetRepository _repository;
        public BetController(BetRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _repository.GetAll();
            return View(list);
        }
    }
}
