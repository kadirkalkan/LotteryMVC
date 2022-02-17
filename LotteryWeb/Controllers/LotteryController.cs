using LotteryWeb.Controllers.Abstract;
using LotteryWeb.Models.Data.EFCoreRepository;
using LotteryWeb.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LotteryWeb.Controllers
{
    public class LotteryController : Controller
    {
        private readonly LotteryRepository _repository;
        public LotteryController(LotteryRepository repository)
        {
            _repository = repository;   
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
