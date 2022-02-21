using System.Collections.Generic;

namespace LotteryWeb.Models.Abstracts
{
    public abstract class AbstractNumber
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Number3 { get; set; }
        public int Number4 { get; set; }
        public int Number5 { get; set; }
        public int Number6 { get; set; }

        public List<int> GetNumbers()
        {
            return new List<int>() {
                Number1,
                Number2,
                Number3,
                Number4,
                Number5,
                Number6
            };
        }
    }
}
