using LotteryWeb.Controllers.Abstract;
using LotteryWeb.Models.Data.EFCoreRepository;
using LotteryWeb.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LotteryWeb.Controllers.CrudController
{
    public class LotteryController : BaseController<Lottery, LotteryRepository>
    {
        public LotteryController(LotteryRepository repository) : base(repository)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
