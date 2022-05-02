using System;

namespace WordAssistant.Models
{
    public class Game
    {
        public Game()
        {
        }

        //properties with getters and setters go here
        public int WordID { get; set; }
        public bool WinLoss { get; set; }
        public DateTime Date { get; set; } //research how to do dates properly
    }
}
