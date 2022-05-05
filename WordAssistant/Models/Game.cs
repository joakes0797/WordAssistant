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


        public string WordName { get; set; } //not mapped by Dapper b/c this isn't a column
    }
}
