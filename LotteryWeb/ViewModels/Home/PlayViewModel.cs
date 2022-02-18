using System.Collections.Generic;

namespace LotteryWeb.ViewModels.Home
{
    public class PlayViewModel
    {
        public decimal Balance { get; set; }
        public List<PlayViewModelData> Data { get; set; }
    }

    public class PlayViewModelData
    {
        public int Id { get; set; }
        public int LotteryId { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Number3 { get; set; }
        public int Number4 { get; set; }
        public int Number5 { get; set; }
        public int Number6 { get; set; }
        public int MatchCount { get; set; }
    }
}
