using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

        public IActionResult GuessCheck(GuessViewModel answer) //can i put a Word message param in here for TableHeadMessage?
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

            //------------------------------------------------------yellow letters

            var y1 = $"%{answer.B06}%";
            var y2 = $"%{answer.B07}%";
            var y3 = $"%{answer.B08}%";
            var y4 = $"%{answer.B09}%";
            var y5 = $"%{answer.B10}%";

            //------------------------------------------------------gray letters

            string g01 = answer.B11 is null ? "" : $"%{answer.B11}%";
            string g02 = answer.B12 is null ? "" : $"%{answer.B12}%";
            string g03 = answer.B13 is null ? "" : $"%{answer.B13}%";
            string g04 = answer.B14 is null ? "" : $"%{answer.B14}%";
            string g05 = answer.B15 is null ? "" : $"%{answer.B15}%";
            string g06 = answer.B16 is null ? "" : $"%{answer.B16}%";
            string g07 = answer.B17 is null ? "" : $"%{answer.B17}%";
            string g08 = answer.B18 is null ? "" : $"%{answer.B18}%";
            string g09 = answer.B19 is null ? "" : $"%{answer.B19}%";
            string g10 = answer.B20 is null ? "" : $"%{answer.B20}%";

            //------------------------------------------------------View Logic

            var results = repo.GetResults(greenLetters, y1, y2, y3, y4, y5, g01, g02, g03, g04, g05, g06, g07, g08, g09, g10);
            var count = results.Count();
            var viewModel = new ResultViewModel();
            if (count == 1)
            {
                viewModel.TableHeadMessage = "Best result";
            }
            else if (count == 0)
            {
                viewModel.TableHeadMessage = "No results found.";
            }
            else
            {
                viewModel.TableHeadMessage = $"{count} Potential Answers";
            }
            
            viewModel.Words = results;
            return View("../Home/Results", viewModel);

        }
    }
}
