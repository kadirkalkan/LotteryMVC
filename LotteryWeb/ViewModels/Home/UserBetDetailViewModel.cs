using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryWeb.ViewModels.Home
{
    public class UserBetDetailViewModel
    {
        public int LotteryId { get; set; }
        public int BetId { get; set; }
        public DateTime LotteryDrawDate { get; set; }
        public string LotteryStatus { get; set; }
        public List<int> UserNumbers { get; set; }
        public int MatchCount { get; set; }

    }
    public class UserBetDetailViewModelData
    {
        public List<UserBetDetailViewModel> UserBets { get; set; }
        public decimal UserBalance { get; set; }
    }
}
