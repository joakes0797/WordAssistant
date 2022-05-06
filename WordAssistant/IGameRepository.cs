using System.Collections.Generic;
using WordAssistant.Models;

namespace WordAssistant
{
    public interface IGameRepository
    {
        public Word CheckAnswer(string WordName);
        public void DeleteGame(Game game);
        public IEnumerable<Game> GetAllGames();
        public Game GetGame(int id);
        public void UpdateGame(Game game);
        public void InsertGame(Game gameToInsert);
        public Word GetWord(int id);
        public int GetWordID(string WordName);
    }
}
