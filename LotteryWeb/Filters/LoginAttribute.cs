using LotteryWeb.DTOs;
using LotteryWeb.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LotteryWeb.Filters
{
    public class LoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.Session.GetObject<LoginSessionDTO>("user");
            if (user == null)
                context.Result = new RedirectToActionResult("Login", "User", new { message = "Bu Sayfaya Giriş Yetkin Yok" });
        }
    }
}
