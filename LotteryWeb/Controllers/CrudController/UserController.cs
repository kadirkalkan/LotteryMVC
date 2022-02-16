using LotteryWeb.Models.Entity;
using LotteryWeb.Controllers.Abstract;
using LotteryWeb.Models.Data.EFCoreRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LotteryWeb.ModelViews.User;

namespace LotteryWeb.Controllers.CrudController
{
    public class UserController : BaseController<User, UserRepository>
    {
        public UserController(UserRepository repository) : base(repository)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View(await Get()); // Get Metodu BaseController'dan geliyor.
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

                await Post(user);

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
