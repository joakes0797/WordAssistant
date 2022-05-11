using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace WordAssistant.Models
{
    public class Game
    {
        public Game()
        {
        }

        public int GameID { get; set; } //don't need for "Log a New Game" b/c auto-increment
        public int WordID { get; set; }
        public bool WinLoss { get; set; }
        public DateTime Date { get; set; }

                
        [Required(ErrorMessage = "A 5-letter answer is required.")]
        [Remote("ValidateAnswer", "Game", ErrorMessage = "That word is not in the Word List.")]
        public string WordName { get; set; }
    }
}
