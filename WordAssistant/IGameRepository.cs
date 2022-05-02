using System.Collections.Generic;
using WordAssistant.Models;

namespace WordAssistant
{
    public interface IGameRepository
    {
        public IEnumerable<Game> GetAllGames();
    }
}
