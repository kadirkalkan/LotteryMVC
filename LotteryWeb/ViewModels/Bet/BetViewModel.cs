using LotteryWeb.Models.Abstracts;
using System.Collections.Generic;

namespace LotteryWeb.ViewModels.Bet
{
    public class BetViewModel : AbstractNumber
    {
        public int Id { get; set; }
       
        public int UserId { get; set; }
        public int LotteryId { get; set; }

    }
}
