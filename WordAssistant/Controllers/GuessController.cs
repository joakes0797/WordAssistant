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

            if (yellowLetters != "")
            {
                foreach (var x in yellowLetters)
                {
                    var filter = from word in greenAttempt
                               where word.Name.Contains(x)
                               select word;
                    yellowAttempt.AddRange(filter.ToList());
                }
            }
            IEnumerable<Word> yellowDuplicates = yellowAttempt.GroupBy(x => x)
                                        .Where(g => g.Count() > 1)
                                        .Select(x => x.Key);

            var grayAttempt = new List<Word>();
            var grayLetters = "";

            if (answer.B11 != null)
            {
                grayLetters += answer.B11;
            }
            if (answer.B12 != null)
            {
                grayLetters += answer.B12;
            }
            if (answer.B13 != null)
            {
                grayLetters += answer.B13;
            }
            if (answer.B14 != null)
            {
                grayLetters += answer.B14;
            }
            if (answer.B15 != null)
            {
                grayLetters += answer.B15;
            }

            if (grayLetters == "" && yellowLetters == "")
            {
                return View("../Home/Index", greenAttempt);
            }
            else if (grayLetters == "")
            {
                return View("../Home/Index", yellowDuplicates);
            }
            else
            {
                foreach (var x in grayLetters)
                {
                    var withGrays = from word in yellowAttempt
                                 where word.Name.Contains(x)
                                 select word;
                    grayAttempt.AddRange(withGrays.ToList());
                }
            }
            var totalSort = yellowDuplicates.Except(grayAttempt);  //yellowDuplicates minus grayAttempts


            return View("../Home/Index", totalSort);
            //return Ok();


            //submit empty form:  return greenAttempt
            //any greens but no yellow or gray:  return greenAttempt

            //any yellow but no green or gray:  greenAttempt, then yellowDuplicates
            //greens and yellows but no gray:  greenAttempt, then yellowDuplicates

            //any gray but no green or yellow:  greenAttempt, then greyAttempt
            //greens and grays but no yellow:  greenAttempt, then greyAttempt

            //yellows and grays but no green:  greenAttempt, then totalSort
            //greens, yellows, and grays:  greenAttempt, then totalSort

        }
    }
}
