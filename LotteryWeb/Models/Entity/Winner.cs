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
    [Table("Winners")]
    public class Winner : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Bet")]
        public int BetId { get; set; }
        public Bet Bet { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Prize { get; set; }
    }
}
