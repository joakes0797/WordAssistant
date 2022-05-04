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
        public DateTime Date { get; set; }
        public IEnumerable<Word> Obsolete { get; set; } //delete me later, the Words table is immutable
        public string Answer { get; set; }
    }
}
