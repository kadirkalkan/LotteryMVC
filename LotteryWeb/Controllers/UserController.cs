using LotteryWeb.Models.Entity;
using LotteryWeb.Controllers.Abstract;
using LotteryWeb.Models.Data.EFCoreRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LotteryWeb.ModelViews.User;
using LotteryWeb.Models.Interfaces;

namespace LotteryWeb.Controllers
{
    public class UserController : Controller
    {
        private UserRepository _repository;
        public UserController(UserRepository repository) 
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _repository.GetAll();
            return View(list);
        }

        public IActionResult Login()
        {
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
                    HttpContext.Response.Cookies.Append("user", vm.Username);
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
            HttpContext.Response.Cookies.Delete("user");
            return RedirectToAction("Index", "Home");
        }
    }
}
