using LotteryWeb.Models.Abstracts;
using LotteryWeb.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryWeb.Models.Entity
{
    public class Lottery : AbstractNumber, IEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime DrawDate { get; set; }
        public string Status { get; set; }

        public ICollection<Bet> Bets { get; set; }

    }
}
