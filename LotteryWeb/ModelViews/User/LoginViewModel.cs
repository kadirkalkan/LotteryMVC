using System.ComponentModel.DataAnnotations;

namespace LotteryWeb.ModelViews.User
{
    public class LoginViewModel
    {
        [Required, MaxLength(50)]
        public string Username { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
    }
}
