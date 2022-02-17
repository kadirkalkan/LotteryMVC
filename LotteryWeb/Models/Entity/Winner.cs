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
    public class Winner : IEntity
    {
        public int Id { get; set; }
        public decimal Prize { get; set; }

        public int BetId { get; set; }
        public Bet Bet { get; set; }
    }
}
