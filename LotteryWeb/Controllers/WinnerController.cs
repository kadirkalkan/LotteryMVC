using LotteryWeb.Controllers.Abstract;
using LotteryWeb.Models.Data.EFCoreRepository;
using LotteryWeb.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LotteryWeb.Controllers
{
    public class WinnerController : Controller
    {
        private readonly WinnerRepository _repository;
        public WinnerController(WinnerRepository repository) 
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
