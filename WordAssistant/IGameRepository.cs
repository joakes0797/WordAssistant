using System.Collections.Generic;
using WordAssistant.Models;

namespace WordAssistant
{
    public interface IGameRepository
    {
        public IEnumerable<Game> GetAllGames();
        public Game GetGame(int id);  //to the user, parameter will be a string, but here I need it to be an int
        public void UpdateGame(Game game);
    }
}
