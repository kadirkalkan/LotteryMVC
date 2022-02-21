using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryWeb.ViewModels.Lottery
{
    public class LotteryDetailsViewModel
    {
        public int Id { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Number3 { get; set; }
        public int Number4 { get; set; }
        public int Number5 { get; set; }
        public int Number6 { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime DrawDate { get; set; }
        public string Status { get; set; }
        public bool IsBetable { get; set; }

    }
}
