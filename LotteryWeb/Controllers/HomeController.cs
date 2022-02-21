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
        private readonly LotteryRepository _lotteryRepository;

        public HomeController(ILogger<HomeController> logger, BetRepository betRepository, UserRepository userRepository, LotteryRepository lotteryRepository)
        {
            _logger = logger;
            _betRepository = betRepository;
            _userRepository = userRepository;
            _lotteryRepository = lotteryRepository;
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

            var userBetList = _betRepository.GetBetsByUserId(dbUser.Id);
            List<UserBetDetailViewModel> subModel = new List<UserBetDetailViewModel>();

            foreach (var userBet in userBetList)
            {
                List<int> userNumbers = userBet.GetNumbers();
                userNumbers.Sort();
                subModel.Add(new UserBetDetailViewModel()
                {
                    LotteryId = userBet.LotteryId,
                    BetId = userBet.Id,
                    UserNumbers = userNumbers,
                    LotteryDrawDate = userBet.Lottery.DrawDate,
                    MatchCount = userBet.GetMatchCount(),
                    LotteryStatus = userBet.Lottery.Status

                });
            }

            var model = new UserBetDetailViewModelData()
            {
                UserBets = subModel,
                UserBalance = dbUser.Balance
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var bet = _betRepository.GetBetById(id);
            var lottery = bet.Lottery;
            var winner = bet.Winner;

            LotteryBetDetailViewModel model = new LotteryBetDetailViewModel()
            {
                Bet = bet,
                Lottery = lottery,
                Winner = winner,
                IsDrawed = lottery.Status == "Çekilmedi" ? false : true
            };



            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
