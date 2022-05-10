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
            //------------------------------------------------------green letters
            var greenLetters = "";
            if (answer.B01 is null)
            {
                greenLetters += "_";
            }
            else
            {
                greenLetters += answer.B01.ToString();
            }

            if (answer.B02 is null)
            {
                greenLetters += "_";
            }
            else
            {
                greenLetters += answer.B02.ToString();
            }

            if (answer.B03 is null)
            {
                greenLetters += "_";
            }
            else
            {
                greenLetters += answer.B03.ToString();
            }

            if (answer.B04 is null)
            {
                greenLetters += "_";
            }
            else
            {
                greenLetters += answer.B04.ToString();
            }

            if (answer.B05 is null)
            {
                greenLetters += "_";
            }
            else
            {
                greenLetters += answer.B05.ToString();
            }

            //var greenAttempt = repo.GetGreenResults(greenLetters);

            //------------------------------------------------------yellow letters
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

            //var yellowAttempt = new List<Word>();

            //if (yellowLetters != "")
            //{
            //    foreach (var x in yellowLetters)
            //    {
            //        var filter = from word in greenAttempt
            //                   where word.Name.Contains(x)
            //                   select word;
            //        yellowAttempt.AddRange(filter.ToList());
            //    }
            //}
            //IEnumerable<Word> yellowDuplicates = yellowAttempt.GroupBy(x => x)
            //                            .Where(g => g.Count() > 1)
            //                            .Select(x => x.Key);

            //------------------------------------------------------gray letters
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

            //var grayAttempt = new List<Word>();

            //if (grayLetters != "")
            //{
            //    foreach (var x in grayLetters)
            //    {
            //        var withGrays = from word in yellowAttempt
            //                        where word.Name.Contains(x)
            //                        select word;
            //        grayAttempt.AddRange(withGrays.ToList());
            //    }
            //}
            //var totalSort = yellowDuplicates.Except(grayAttempt);  //yellowDuplicates minus grayAttempts



            //------------------------------------------------------View Logic
            var totalSort = new IEnumerable<Word>();
            //submit empty form:  return greenAttempt                               --done
            //any greens but no yellow or gray:  return greenAttempt                --done

            if (greenLetters == "" && yellowLetters == "" && grayLetters == "")
            {
                var greenAttempt = repo.GetGreenResults(greenLetters);
                totalSort = greenAttempt;
            }
            if (greenLetters != "" && yellowLetters == "" && grayLetters == "")
            {
                var greenAttempt = repo.GetGreenResults(greenLetters);
                totalSort = greenAttempt;
            }

            //any yellow but no green or gray:  greenAttempt, then yellowDuplicates     --done
            //greens and yellows but no gray:  greenAttempt, then yellowDuplicates      --done

            if (yellowLetters != "" && greenLetters == "" && grayLetters == "")
            {
                var greenAttempt = repo.GetGreenResults(greenLetters);

                var yellowAttempt = new List<Word>();
                foreach (var x in yellowLetters)
                {
                    var filter = from word in greenAttempt
                                 where word.Name.Contains(x)
                                 select word;
                    yellowAttempt.AddRange(filter.ToList());
                }
                IEnumerable<Word> yellowDuplicates = yellowAttempt.GroupBy(x => x)
                                        .Where(g => g.Count() > 1)
                                        .Select(x => x.Key);

                totalSort = yellowDuplicates;
            }
            if (greenLetters != "" && yellowLetters != "" && grayLetters == "")
            {
                var greenAttempt = repo.GetGreenResults(greenLetters);

                var yellowAttempt = new List<Word>();
                foreach (var x in yellowLetters)
                {
                    var filter = from word in greenAttempt
                                 where word.Name.Contains(x)
                                 select word;
                    yellowAttempt.AddRange(filter.ToList());
                }
                IEnumerable<Word> yellowDuplicates = yellowAttempt.GroupBy(x => x)
                                        .Where(g => g.Count() > 1)
                                        .Select(x => x.Key);

                totalSort = yellowDuplicates;
            }

            //any gray but no green or yellow:  greenAttempt, then grayAttempt      --done
            //greens and grays but no yellow:  greenAttempt, then grayAttempt       --done

            if (grayLetters != "" && greenLetters == "" && yellowLetters == "")
            {
                var greenAttempt = repo.GetGreenResults(greenLetters);
                
                var grayAttempt = new List<Word>();
                foreach (var x in grayLetters)
                {
                    var withGrays = from word in greenAttempt
                                    where word.Name.Contains(x)
                                    select word;
                    grayAttempt.AddRange(withGrays.ToList());
                }
                totalSort = greenAttempt.Except(grayAttempt);  //greens minus yellows
            }
            if (greenLetters != "" && grayLetters != "" && yellowLetters == "")
            {
                var greenAttempt = repo.GetGreenResults(greenLetters);

                var grayAttempt = new List<Word>();
                foreach (var x in grayLetters)
                {
                    var withGrays = from word in greenAttempt
                                    where word.Name.Contains(x)
                                    select word;
                    grayAttempt.AddRange(withGrays.ToList());
                }
                totalSort = greenAttempt.Except(grayAttempt);  //greens minus yellows
            }

            //yellows and grays but no green:  greenAttempt, then totalSort         --done
            //greens, yellows, and grays:  greenAttempt, then totalSort             --done
            if (yellowLetters != "" && grayLetters != "" && greenLetters == "")
            {
                var greenAttempt = repo.GetGreenResults(greenLetters);

                var yellowAttempt = new List<Word>();
                foreach (var x in yellowLetters)
                {
                    var filter = from word in greenAttempt
                                 where word.Name.Contains(x)
                                 select word;
                    yellowAttempt.AddRange(filter.ToList());
                }
                IEnumerable<Word> yellowDuplicates = yellowAttempt.GroupBy(x => x)
                                        .Where(g => g.Count() > 1)
                                        .Select(x => x.Key);

                var grayAttempt = new List<Word>();
                foreach (var x in grayLetters)
                {
                    var withGrays = from word in yellowAttempt
                                    where word.Name.Contains(x)
                                    select word;
                    grayAttempt.AddRange(withGrays.ToList());
                }
                totalSort = yellowDuplicates.Except(grayAttempt);  //yellowDuplicates minus grayAttempts
            }
            if (greenLetters != "" && yellowLetters != "" && grayLetters != "")
            {
                var greenAttempt = repo.GetGreenResults(greenLetters);
                
                var yellowAttempt = new List<Word>();
                foreach (var x in yellowLetters)
                {
                    var filter = from word in greenAttempt
                                 where word.Name.Contains(x)
                                 select word;
                    yellowAttempt.AddRange(filter.ToList());
                }
                IEnumerable<Word> yellowDuplicates = yellowAttempt.GroupBy(x => x)
                                        .Where(g => g.Count() > 1)
                                        .Select(x => x.Key);

                var grayAttempt = new List<Word>();
                foreach (var x in grayLetters)
                {
                    var withGrays = from word in yellowAttempt
                                    where word.Name.Contains(x)
                                    select word;
                    grayAttempt.AddRange(withGrays.ToList());
                }
                totalSort = yellowDuplicates.Except(grayAttempt);  //yellowDuplicates minus grayAttempts
            }


            return View("../Home/Index", totalSort);
            //return Ok();
        }
    }
}
