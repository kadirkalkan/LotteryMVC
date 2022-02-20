using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryWeb.ViewModels.Lottery
{
    public class LotteryDetailsViewModel
    {
        public byte Number1 { get; set; }
        public byte Number2 { get; set; }
        public byte Number3 { get; set; }
        public byte Number4 { get; set; }
        public byte Number5 { get; set; }
        public byte Number6 { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DrawDate { get; set; }
        public bool IsDrawed { get; set; }

    }
}
