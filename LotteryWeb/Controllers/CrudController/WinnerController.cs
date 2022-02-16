using LotteryWeb.Controllers.Abstract;
using LotteryWeb.Models.Data.EFCoreRepository;
using LotteryWeb.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LotteryWeb.Controllers.CrudController
{
    public class WinnerController : BaseController<Winner, WinnerRepository>
    {
        public WinnerController(WinnerRepository repository) : base(repository)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
