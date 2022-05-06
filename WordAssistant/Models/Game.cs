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

        public int GameID { get; set; }
        public int WordID { get; set; }
        public bool WinLoss { get; set; }
        public DateTime Date { get; set; }


        //[BindProperty, 
        //    Required(ErrorMessage ="A 5-letter answer is required."),
        //    MaxLength(5, ErrorMessage="Answer cannot exceed 5 letters."),
        //    MinLength(5, ErrorMessage ="Answer must contain 5 letters."),
        //    Remote("Bob", "GameController", ErrorMessage = "That word is not a valid answer.")
        //]
        [Required(ErrorMessage = "Code Required")]
        [Remote("Bob", "Game", ErrorMessage = "Please enter a valid code")]
        public string WordName { get; set; } //GetAllGames mapped by Dapper as WordName, GetGame not mapped by Dapper

        //public JsonResult OnPostCheckAnswer()
        //{
        //    var existingWords = new[] { "cigar", "sissy", "farts" };
        //    var valid = existingWords.Contains(WordName);
        //    return new JsonResult(valid);
        //}
    }
}
