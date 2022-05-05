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
            //foreach (var game in games)
            //{
            //    var word = repo.GetWord(game.WordID);
            //    game.WordName = word.Name;
            //}
            return View(games);
        }
        public IActionResult InsertGame()
        {
            //var game = repo.AssignWord();
            var game = new Game
            {
                Date = DateTime.Now
            };
            return View(game);
        }
        public IActionResult InsertGameToDatabase(Game gameToInsert)
        {
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
        public IActionResult ViewGame(int id)
        {
            var game = repo.GetGame(id);
            
            var word = repo.GetWord(game.WordID); //change SQL in GetGame means won't need these 2 lines
            game.WordName = word.Name;
            
            return View(game);
        }
    }
}
