namespace LotteryWeb.ViewModels.Bet
{
    public class BetViewModel
    {
        public int Id { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Number3 { get; set; }
        public int Number4 { get; set; }
        public int Number5 { get; set; }
        public int Number6 { get; set; }

        public int UserId { get; set; }
        public int LotteryId { get; set; }
    }
}
