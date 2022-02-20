using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryWeb.ViewModels.Bet
{
    public class BetLotteryResultViewModel
    {
        public List<int> LotteryResultNumbers { get; set; } = new List<int>();
        public int[] SuccessCounts { get; set; } = new int[7];

    }

}
