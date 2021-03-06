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
    public class Bet : AbstractNumber, IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int LotteryId { get; set; }
        public Lottery Lottery { get; set; }

        public int WinnerId { get; set; }
        public Winner Winner { get; set; }


        public int GetMatchCount()
        {
            int matchCount = 0;
            List<int> numbers = new List<int>() {
                Number1,
                Number2,
                Number3,
                Number4,
                Number5,
                Number6,
            };
            List<int> luckyNumbers = new List<int>() {
                Lottery.Number1,
                Lottery.Number2,
                Lottery.Number3,
                Lottery.Number4,
                Lottery.Number5,
                Lottery.Number6,
            };
            foreach (var item in numbers)
            {
                if (luckyNumbers.Contains(item))
                    matchCount++;
            }
            return matchCount;
        }

    }
}
