using LotteryWeb.Controllers.Abstract;
using LotteryWeb.Filters;
using LotteryWeb.Models.Data.EFCoreRepository;
using LotteryWeb.Models.Entity;
using LotteryWeb.ViewModels.Bet;
using LotteryWeb.ViewModels.Lottery;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryWeb.Controllers
{
    public class LotteryController : Controller
    {
        private readonly LotteryRepository _lotteryRepository;
        private readonly BetRepository _betRepository;
        private readonly WinnerRepository _winnerRepository;
        private readonly UserRepository _userRepository;

        public LotteryController(
            LotteryRepository lotteryRepository, 
            BetRepository betRepository, 
            WinnerRepository winnerRepository,
            UserRepository userRepository)
        {
            _lotteryRepository = lotteryRepository;
            _betRepository = betRepository;
            _winnerRepository = winnerRepository;
            _userRepository = userRepository;   
        }

        [Login]
        public IActionResult PlanLottery()
        {

            return View();
        }

        [Login, HttpPost]
        public async Task<IActionResult> PlanLottery(LotteryPlanViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var lottery = new Lottery()
                {
                    DrawDate = vm.DrawDate,
                    Status = "Çekilmedi"
                };
                await _lotteryRepository.Add(lottery);
                TempData["successMessage"] = "Lottery başarıyla eklendi.";
                return RedirectToAction("AllLotteries");
            }
            return View();
        }
        public async Task<IActionResult> AllLotteries()
        {
            var lotteryList = await _lotteryRepository.GetAll();
            var model = lotteryList.Select(x => new LotteryDetailsViewModel()
            {
                Id = x.Id,
                CreateDate = x.CreateDate,
                DrawDate = x.DrawDate,
                Number1 = x.Number1,
                Number2 = x.Number2,
                Number3 = x.Number3,
                Number4 = x.Number4,
                Number5 = x.Number5,
                Number6 = x.Number6,
                IsBetable = x.Status == "Çekilmedi" ? true : false
            }).ToList();
            return View(model);
        }

        [Login]
        public async Task<IActionResult> Draw(int id)
        {
            var lottery = await _lotteryRepository.Get(id);
            if (lottery == null) return NotFound();

            if (lottery.DrawDate > DateTime.Now)
            {
                TempData["errorMessage"] = "Çekilişin planlanan vakti gelmedi!";
                return RedirectToAction("AllLotteries");
            }
            if (lottery.Status == "Çekildi")
            {
                TempData["errorMessage"] = "Çekiliş zaten yapıldı!";
                return RedirectToAction("AllLotteries");
            }

            List<byte> randomNumbers = new List<byte>();
            GenerateRandomNumbers(randomNumbers);

            lottery.Number1 = randomNumbers[0];
            lottery.Number2 = randomNumbers[1];
            lottery.Number3 = randomNumbers[2];
            lottery.Number4 = randomNumbers[3];
            lottery.Number5 = randomNumbers[4];
            lottery.Number6 = randomNumbers[5];
            lottery.Status = "Çekildi";

            await _lotteryRepository.Update(lottery);

            await AnnounceWinners(lottery.Id);

            return View(lottery);
        }

        public async Task<IActionResult> SeeResults(int id)
        {
            var lottery = await _lotteryRepository.Get(id);
            if (lottery == null) return NotFound();

            if (lottery.Status == "Çekilmedi")
            {
                TempData["errorMessage"] = "Çekiliş henüz yapılmadı.";
                return RedirectToAction("AllLotteries");
            }

            List<Bet> betListOfLottery = _betRepository.GetBetsByLotteryId(id);

            BetLotteryResultViewModel model = new BetLotteryResultViewModel();
            model.LotteryResultNumbers = lottery.GetNumbers();

            betListOfLottery.ForEach(x =>
            {
                model.SuccessCounts[x.GetMatchCount()]++;
            });

            return View(model);
        }

        private static void GenerateRandomNumbers(List<byte> randomNumbers)
        {
            Random rnd = new Random();
            while (randomNumbers.Count < 6)
            {
                byte randomNumber = (byte)rnd.Next(1, 50);
                if (!randomNumbers.Contains(randomNumber))
                    randomNumbers.Add(randomNumber);
            }
            randomNumbers.Sort();
        }

        private async Task AnnounceWinners(int lotteryId)
        {
            var bets = _betRepository.GetBetsByLotteryId(lotteryId);
            var winners = bets.Where(x => x.GetMatchCount() > 0);
            foreach (var bet in winners)
            {
                Winner winner = new Winner()
                {
                    Id = bet.Id,
                    Prize = (int)Math.Pow((bet.GetMatchCount() * 5), 2)

                };
                var user = await _userRepository.Get(bet.UserId);
                user.Balance += winner.Prize;
                await _winnerRepository.Add(winner);
            }
        }
    }
}
