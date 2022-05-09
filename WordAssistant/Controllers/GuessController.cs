using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WordAssistant.Models;

namespace WordAssistant.Controllers
{
    public class GuessController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly IGuessRepository repo;

        public GuessController(IGuessRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult GuessCheck(Guess answer)
        {
            var greenCheck = "";
            if (answer.B1 is null)
            {
                greenCheck += "_";
            }
            else
            {
                greenCheck += answer.B1.ToString();
            }

            if (answer.B2 is null)
            {
                greenCheck += "_";
            }
            else
            {
                greenCheck += answer.B2.ToString();
            }

            if (answer.B3 is null)
            {
                greenCheck += "_";
            }
            else
            {
                greenCheck += answer.B3.ToString();
            }

            if (answer.B4 is null)
            {
                greenCheck += "_";
            }
            else
            {
                greenCheck += answer.B4.ToString();
            }

            if (answer.B5 is null)
            {
                greenCheck += "_";
            }
            else
            {
                greenCheck += answer.B5.ToString();
            }
            var greenAttempt = repo.GetGreenResults(greenCheck);
            return View("../Home/Index", greenAttempt);
            //return Ok();

            //var fetchID = repo.GetWordID(gameToInsert.WordName);
            //gameToInsert.WordID = fetchID;//now have 4 properties of the Game object
            //repo.InsertGame(gameToInsert);
            //return RedirectToAction("Index");
        }
    }
}
