using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LotteryWeb.ViewModels.Lottery
{
    public class LotteryPlanViewModel
    {
        [Required]
        public DateTime DrawDate { get; set; }
    }
}
