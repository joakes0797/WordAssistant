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


        public string WordName { get; set; } //GetAllGames mapped by Dapper as WordName, GetGame not mapped by Dapper
    }
}
