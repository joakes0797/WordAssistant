using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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


        //[BindProperty, 
        //    Required(ErrorMessage ="A 5-letter answer is required."),
        //    MaxLength(5, ErrorMessage="Answer cannot exceed 5 letters."),
        //    MinLength(5, ErrorMessage ="Answer must contain 5 letters."),
        //    Remote("Bob", "GameController", ErrorMessage = "That word is not a valid answer.")
        //]
        [Required(ErrorMessage = "A 5-letter answer is required.")]
        [Remote("ValidateAnswer", "Game", ErrorMessage = "That word is not in the Word List.")]
        public string WordName { get; set; } //GetAllGames mapped by Dapper as WordName, GetGame not mapped by Dapper
    }
}
