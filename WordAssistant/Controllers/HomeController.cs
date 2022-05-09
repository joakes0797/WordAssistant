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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult GuessCheck(Guess answer)
        {
            //var greenCheck = "";
            //if (B1 is null)
            //{
            //    greenCheck += "_";
            //}
            return Ok();
            //var fetchID = repo.GetWordID(gameToInsert.WordName);
            //gameToInsert.WordID = fetchID;//now have 4 properties of the Game object
            //repo.InsertGame(gameToInsert);
            //return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
