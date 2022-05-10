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
                greenLetters += answer.B01;
            }

            if (answer.B02 is null)
            {
                greenLetters += "_";
            }
            else
            {
                greenLetters += answer.B02;
            }

            if (answer.B03 is null)
            {
                greenLetters += "_";
            }
            else
            {
                greenLetters += answer.B03;
            }

            if (answer.B04 is null)
            {
                greenLetters += "_";
            }
            else
            {
                greenLetters += answer.B04;
            }

            if (answer.B05 is null)
            {
                greenLetters += "_";
            }
            else
            {
                greenLetters += answer.B05;
            }

            //var greenAttempt = repo.GetGreenResults(greenLetters);

            //------------------------------------------------------yellow letters
            //var yellowLetters = "";
            //if (answer.B06 != null)
            //{
            //    yellowLetters += answer.B06;
            //}
            //if (answer.B07 != null)
            //{
            //    yellowLetters += answer.B07;
            //}
            //if (answer.B08 != null)
            //{
            //    yellowLetters += answer.B08;
            //}
            //if (answer.B09 != null)
            //{
            //    yellowLetters += answer.B09;
            //}
            //if (answer.B10 != null)
            //{
            //    yellowLetters += answer.B10;
            //}

            //var totalQuery = $"SELECT * FROM words WHERE Name LIKE '{greenLetters}'";

            //if (answer.B06 != null)
            //{
            //    totalQuery += $" AND Name LIKE '%{answer.B06}%'";
            //}
            //if (answer.B07 != null)
            //{
            //    totalQuery += $" AND Name LIKE '%{answer.B07}%'";
            //}
            //if (answer.B08 != null)
            //{
            //    totalQuery += $" AND Name LIKE '%{answer.B08}%'";
            //}
            //if (answer.B09 != null)
            //{
            //    totalQuery += $" AND Name LIKE '%{answer.B09}%'";
            //}
            //if (answer.B10 != null)
            //{
            //    totalQuery += $" AND Name LIKE '%{answer.B10}%'";
            //}
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
            //var grayLetters = "";
            //if (answer.B11 != null)
            //{
            //    grayLetters += answer.B11;
            //}
            //if (answer.B12 != null)
            //{
            //    grayLetters += answer.B12;
            //}
            //if (answer.B13 != null)
            //{
            //    grayLetters += answer.B13;
            //}
            //if (answer.B14 != null)
            //{
            //    grayLetters += answer.B14;
            //}
            //if (answer.B15 != null)
            //{
            //    grayLetters += answer.B15;
            //}

            //if (answer.B11 != null)
            //{
            //    totalQuery += $" AND Name NOT LIKE '%{answer.B11}%'";
            //}
            //if (answer.B12 != null)
            //{
            //    totalQuery += $" AND Name NOT LIKE '%{answer.B12}%'";
            //}
            //if (answer.B13 != null)
            //{
            //    totalQuery += $" AND Name NOT LIKE '%{answer.B13}%'";
            //}
            //if (answer.B14 != null)
            //{
            //    totalQuery += $" AND Name NOT LIKE '%{answer.B14}%'";
            //}
            //if (answer.B15 != null)
            //{
            //    totalQuery += $" AND Name NOT LIKE '%{answer.B15}%'";
            //}

            //var foo = repo.GetResults(totalQuery);

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
            var y1 = $"%{answer.B06}%";
            var y2 = $"%{answer.B07}%";
            var y3 = $"%{answer.B08}%";
            var y4 = $"%{answer.B09}%";
            var y5 = $"%{answer.B10}%";
            string g1 = answer.B11 is null ? "" : $"%{answer.B11}%";
            string g2 = answer.B12 is null ? "" : $"%{answer.B12}%";
            string g3 = answer.B13 is null ? "" : $"%{answer.B13}%";
            string g4 = answer.B14 is null ? "" : $"%{answer.B14}%";
            string g5 = answer.B15 is null ? "" : $"%{answer.B15}%";
            
            var foo = repo.GetResults(greenLetters, y1, y2, y3, y4, y5, g1, g2, g3, g4, g5);


            //------------------------------------------------------View Logic

            //var totalSort = new List<Word>();

            //submit empty form:  return greenAttempt                               --done
            //any greens but no yellow or gray:  return greenAttempt                --done

            //if (greenLetters == "" && yellowLetters == "" && grayLetters == "")
            //{
            //    var greenAttempt = repo.GetGreenResults(greenLetters);
            //    totalSort = greenAttempt.ToList();
            //}
            //if (greenLetters != "" && yellowLetters == "" && grayLetters == "")
            //{
            //    var greenAttempt = repo.GetGreenResults(greenLetters);
            //    totalSort = greenAttempt.ToList();
            //}

            //any yellow but no green or gray:  greenAttempt, then yellowDuplicates     --done
            //greens and yellows but no gray:  greenAttempt, then yellowDuplicates      --done

            //if (yellowLetters != "" && greenLetters == "" && grayLetters == "")
            //{
            //    var greenAttempt = repo.GetGreenResults(greenLetters);

            //    var yellowAttempt = new List<Word>();
            //    foreach (var x in yellowLetters)
            //    {
            //        var filter = from word in greenAttempt
            //                     where word.Name.Contains(x)
            //                     select word;
            //        yellowAttempt.AddRange(filter.ToList());
            //    }
            //    IEnumerable<Word> yellowDuplicates = yellowAttempt.GroupBy(x => x)
            //                            .Where(g => g.Count() > 1)
            //                            .Select(x => x.Key);

            //    totalSort = yellowDuplicates.ToList();
            //}
            //if (greenLetters != "" && yellowLetters != "" && grayLetters == "")
            //{
            //    var greenAttempt = repo.GetGreenResults(greenLetters);

            //    var yellowAttempt = new List<Word>();
            //    foreach (var x in yellowLetters)
            //    {
            //        var filter = from word in greenAttempt
            //                     where word.Name.Contains(x)
            //                     select word;
            //        yellowAttempt.AddRange(filter.ToList());
            //    }
            //    IEnumerable<Word> yellowDuplicates = yellowAttempt.GroupBy(x => x)
            //                            .Where(g => g.Count() > 1)
            //                            .Select(x => x.Key);

            //    totalSort = yellowDuplicates.ToList();
            //}

            //any gray but no green or yellow:  greenAttempt, then grayAttempt      --done
            //greens and grays but no yellow:  greenAttempt, then grayAttempt       --done

            //if (grayLetters != "" && greenLetters == "" && yellowLetters == "")
            //{
            //    var greenAttempt = repo.GetGreenResults(greenLetters);

            //    var grayAttempt = new List<Word>();
            //    foreach (var x in grayLetters)
            //    {
            //        var withGrays = from word in greenAttempt
            //                        where word.Name.Contains(x)
            //                        select word;
            //        grayAttempt.AddRange(withGrays.ToList());
            //    }
            //    totalSort = greenAttempt.Except(grayAttempt).ToList();  //greens minus yellows
            //}
            //if (greenLetters != "" && grayLetters != "" && yellowLetters == "")
            //{
            //    var greenAttempt = repo.GetGreenResults(greenLetters);

            //    var grayAttempt = new List<Word>();
            //    foreach (var x in grayLetters)
            //    {
            //        var withGrays = from word in greenAttempt
            //                        where word.Name.Contains(x)
            //                        select word;
            //        grayAttempt.AddRange(withGrays.ToList());
            //    }
            //    totalSort = greenAttempt.Except(grayAttempt).ToList();  //greens minus yellows
            //}

            //yellows and grays but no green:  greenAttempt, then totalSort         --done
            //greens, yellows, and grays:  greenAttempt, then totalSort             --done
            //if (yellowLetters != "" && grayLetters != "" && greenLetters == "")
            //{
            //    var greenAttempt = repo.GetGreenResults(greenLetters);

            //    var yellowAttempt = new List<Word>();
            //    foreach (var x in yellowLetters)
            //    {
            //        var filter = from word in greenAttempt
            //                     where word.Name.Contains(x)
            //                     select word;
            //        yellowAttempt.AddRange(filter.ToList());
            //    }
            //    IEnumerable<Word> yellowDuplicates = yellowAttempt.GroupBy(x => x)
            //                            .Where(g => g.Count() > 1)
            //                            .Select(x => x.Key);

            //    var grayAttempt = new List<Word>();
            //    foreach (var x in grayLetters)
            //    {
            //        var withGrays = from word in yellowAttempt
            //                        where word.Name.Contains(x)
            //                        select word;
            //        grayAttempt.AddRange(withGrays.ToList());
            //    }
            //    totalSort = yellowDuplicates.Except(grayAttempt).ToList();  //yellowDuplicates minus grays
            //}
            //if (greenLetters != "" && yellowLetters != "" && grayLetters != "")
            //{
            //    var greenAttempt = repo.GetGreenResults(greenLetters);

            //    var yellowAttempt = new List<Word>();
            //    foreach (var x in yellowLetters)
            //    {
            //        var filter = from word in greenAttempt
            //                     where word.Name.Contains(x)
            //                     select word;
            //        yellowAttempt.AddRange(filter.ToList());
            //    }
            //    IEnumerable<Word> yellowDuplicates = yellowAttempt.GroupBy(x => x)
            //                            .Where(g => g.Count() > 1)
            //                            .Select(x => x.Key);

            //    var grayAttempt = new List<Word>();
            //    foreach (var x in grayLetters)
            //    {
            //        var withGrays = from word in yellowAttempt
            //                        where word.Name.Contains(x)
            //                        select word;
            //        grayAttempt.AddRange(withGrays.ToList());
            //    }
            //    totalSort = yellowDuplicates.Except(grayAttempt).ToList();  //yellowDuplicates minus grays
            //}


            return View("../Home/Index", foo);
            //return View("../Home/Index", totalSort);
            //return Ok();
        }
    }
}
