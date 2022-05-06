using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WordAssistant.Models;

namespace WordAssistant.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository repo;

        public GameController(IGameRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult DeleteGame(Game game)     //IActionResult is an API endpoint
        {
            repo.DeleteGame(game);
            return RedirectToAction("Index");
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var games = repo.GetAllGames();
            return View(games);
        }
        public IActionResult InsertGame()
        {
            var game = new Game
            {
                Date = DateTime.Now
            };
            return View(game);
        }
        public IActionResult InsertGameToDatabase(Game gameToInsert)
        {
            var fetchID = repo.GetWordID(gameToInsert.WordName);
            gameToInsert.WordID = fetchID;//now have 4 properties of the Game object
            repo.InsertGame(gameToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateGame(int id)
        {
            Game game = repo.GetGame(id);
            if (game == null)
            {
                return View("GameNotFound");
            }
            return View(game);
        }
        public IActionResult UpdateGameToDatabase(Game game)
        {
            repo.UpdateGame(game);
            return RedirectToAction("ViewGame", new { id = game.GameID });
        }

        public IActionResult ValidateAnswer(string WordName)
        {
            var attempt = repo.CheckAnswer(WordName.ToLower());
            var valid = false;
            if (attempt == null)
            {
                valid = false;
            }
            else
            {
                valid = true;
            }
            return new JsonResult(valid);

            //var existingWords = new[] { "cigar", "awake", "humph" };
            //var valid = existingWords.Contains(WordName);
            //return new JsonResult(valid);
        }

        public IActionResult ViewGame(int id)
        {
            var game = repo.GetGame(id);
            return View(game);
        }
    }
}
