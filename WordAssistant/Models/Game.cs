using System;
using System.Collections.Generic;

namespace WordAssistant.Models
{
    public class Game
    {
        public Game()
        {
        }

        public int GameID { get; set; }
        public int WordID { get; set; }
        public bool WinLoss { get; set; }
        public DateTime Date { get; set; } //research how to do dates properly
        public IEnumerable<Words> Word { get; set; } //want to get but not set, the Words table is immutable
    }
}
