using LotteryWeb.DTOs;
using LotteryWeb.Extensions;
using LotteryWeb.Filters;
using LotteryWeb.Models;
using LotteryWeb.Models.Data.EFCoreRepository;
using LotteryWeb.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BetRepository _betRepository;
        private readonly UserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, BetRepository betRepository, UserRepository userRepository)
        {
            _logger = logger;
            _betRepository = betRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Login]
        public async Task<IActionResult> Play()
        {
            var user = HttpContext.Session.GetObject<LoginSessionDTO>("user");
            var dbUser = await _userRepository.Get(user.Id);

            var dataList = (await _betRepository.GetAll())
                .Where(x=> x.UserId.Equals(user.Id))
                .Select(x => new PlayViewModelData()
                {
                    Id = x.Id,
                    Number1 = x.Number1,
                    Number2 = x.Number2,
                    Number3 = x.Number3,
                    Number4 = x.Number4,
                    Number5 = x.Number5,
                    Number6 = x.Number6,
                    MatchCount = x.GetMatchCount()
                }).ToList();

            var vm = new PlayViewModel()
            {
                Balance = dbUser.Balance,
                Data = dataList
            };
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
