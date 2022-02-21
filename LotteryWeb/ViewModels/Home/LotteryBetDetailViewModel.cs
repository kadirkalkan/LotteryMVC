using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryWeb.ViewModels.Home
{
    public class LotteryBetDetailViewModel
    {
        public Models.Entity.Bet Bet { get; set; }
        public Models.Entity.Lottery Lottery { get; set; }
        public bool IsDrawed { get; set; }
    }
}
