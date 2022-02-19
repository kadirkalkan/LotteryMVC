using LotteryWeb.Models.Entity;
using LotteryWeb.Controllers.Abstract;
using LotteryWeb.Models.Data.EFCoreRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LotteryWeb.ViewModels.User;
using LotteryWeb.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using LotteryWeb.Extensions;
using LotteryWeb.DTOs;

namespace LotteryWeb.Controllers
{
    public class UserController : Controller
    {
        private UserRepository _repository;
        public UserController(UserRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Login(string message)
        {
            TempData["alert"] = message;
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = _repository.GetLoggedUser(vm.Username, vm.Password);
                if (user != null)
                {
                    HttpContext.Session.SetObject("user", new LoginSessionDTO(user.Id, user.Username));

                    TempData["message"] = "You have successfully logged in.";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "This User Couldn't Find in Database");
                }
            }
            return View(vm);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (_repository.GetByUsername(vm.Username) != null)
                {
                    ModelState.AddModelError("", "This User Already Registered");
                    return View(vm);
                }

                var user = new User()
                {
                    Username = vm.Username,
                    Password = vm.Password
                };

                await _repository.Add(user);

                TempData["message"] = "You have successfully registered.";
                return RedirectToAction("Login", "User");
            }
            return View(vm);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Profile()
        {
            var loggedUser = HttpContext.Session.GetObject<LoginSessionDTO>("user");
            var userDb = await _repository.Get(loggedUser.Id);
            UserProfileViewModel model = new UserProfileViewModel()
            {
                User = userDb
            };
            return View(model);
        }

        public async Task<IActionResult> AddBalance(int id)
        {
            var userDb = await _repository.Get(id);
            userDb.Balance += 5;
            userDb = await _repository.Update(userDb);

            return Content(userDb.Balance.ToString());
        }
    }
}
