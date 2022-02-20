using LotteryWeb.Controllers.Abstract;
using LotteryWeb.DTOs;
using LotteryWeb.Extensions;
using LotteryWeb.Filters;
using LotteryWeb.Models.Data.EFCoreRepository;
using LotteryWeb.Models.Entity;
using LotteryWeb.ViewModels.Bet;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryWeb.Controllers
{
    [Login]
    public class BetController : Controller
    {
        private readonly BetRepository _betRepository;
        private readonly UserRepository _userRepository;
        private readonly LotteryRepository _lotteryRepository;

        public BetController(BetRepository betRepository, UserRepository userRepository, LotteryRepository lotteryRepository)
        {
            _betRepository = betRepository;
            _userRepository = userRepository;
            _lotteryRepository = lotteryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _betRepository.GetAll();
            return View(list);
        }

        public async Task<IActionResult> Play(int id)
        {
            var lottery = await _lotteryRepository.Get(id);
            var model = new BetViewModel() { LotteryId = id };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Play(BetViewModel vm)
        {
            var loggedUser = HttpContext.Session.GetObject<LoginSessionDTO>("user");
            if (loggedUser == null) return BadRequest();
            if (ModelState.IsValid)
            {
                HashSet<int> userNumbers = new HashSet<int>() { vm.Number1, vm.Number2, vm.Number3, vm.Number4, vm.Number5, vm.Number6 };
                if (userNumbers.Count !=6)
                {
                    ModelState.AddModelError("", "Lütfen birbirinden farklı 6 adet sayı girin!");
                    return View();
                }
                Bet bet = new Bet()
                {
                    Number1 = userNumbers.ElementAt(0),
                    Number2 = userNumbers.ElementAt(1),
                    Number3 = userNumbers.ElementAt(2),
                    Number4 = userNumbers.ElementAt(3),
                    Number5 = userNumbers.ElementAt(4),
                    Number6 = userNumbers.ElementAt(5),
                    UserId = loggedUser.Id,
                    LotteryId = vm.LotteryId
                };

                await _betRepository.Add(bet);
             decimal newBalance =   await UpdateUserBalance(loggedUser.Id);

                TempData["successMessage"] = $"Bahis başarıyla oynandı. Yeni bakiyeniz ${newBalance}";
                return RedirectToAction("AllLotteries","Lottery");
            }

            return View();
        }

        private async Task<decimal> UpdateUserBalance(int id)
        {
            var user = await _userRepository.Get(id);
            user.Balance -= 5;
            await _userRepository.Update(user);
            return user.Balance;
        }
    }
}
