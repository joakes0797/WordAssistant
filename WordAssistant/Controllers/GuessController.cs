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
            if (answer.B01 is null)
            {
                greenCheck += "_";
            }
            else
            {
                greenCheck += answer.B01.ToString();
            }

            if (answer.B02 is null)
            {
                greenCheck += "_";
            }
            else
            {
                greenCheck += answer.B02.ToString();
            }

            if (answer.B03 is null)
            {
                greenCheck += "_";
            }
            else
            {
                greenCheck += answer.B03.ToString();
            }

            if (answer.B04 is null)
            {
                greenCheck += "_";
            }
            else
            {
                greenCheck += answer.B04.ToString();
            }

            if (answer.B05 is null)
            {
                greenCheck += "_";
            }
            else
            {
                greenCheck += answer.B05.ToString();
            }
            var greenAttempt = repo.GetGreenResults(greenCheck);

            var yellowAttempt = new List<Word>();
            var yellowLetters = "";

            if (answer.B06 != null)
            {
                yellowLetters += answer.B06;
            }
            if (answer.B07 != null)
            {
                yellowLetters += answer.B07;
            }
            if (answer.B08 != null)
            {
                yellowLetters += answer.B08;
            }
            if (answer.B09 != null)
            {
                yellowLetters += answer.B09;
            }
            if (answer.B10 != null)
            {
                yellowLetters += answer.B10;
            }

            if (yellowLetters == "")
            {
                return View("../Home/Index", greenAttempt);
            }
            else
            {
                foreach (var x in yellowLetters)
                {
                    var filter = from word in greenAttempt
                               where word.Name.Contains(x)
                               select word;
                    yellowAttempt.AddRange(filter.ToList());
                }
            }
            IEnumerable<Word> duplicates = yellowAttempt.GroupBy(x => x)
                                        .Where(g => g.Count() > 1)
                                        .Select(x => x.Key);



            return View("../Home/Index", duplicates);
            //return Ok();
        }
    }
}
