namespace LotteryWeb.DTOs
{
    public class LoginSessionDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public LoginSessionDTO(int id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}
