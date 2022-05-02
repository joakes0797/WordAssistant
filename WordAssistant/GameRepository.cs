using Dapper;
using System.Collections.Generic;
using System.Data;
using WordAssistant.Models;

namespace WordAssistant
{
    public class GameRepository : IGameRepository
    {
        private readonly IDbConnection _conn;
        public GameRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Game> GetAllGames()
        {
            return _conn.Query<Game>("SELECT * FROM games;");
        }

        public Game GetGame(int id)
        {
            return _conn.QuerySingle<Game>("SELECT * FROM games WHERE WordID = @id", new { id = id });
        }

        public void UpdateGame(Game game)
        {
            _conn.Execute("UPDATE games SET WordID = @WordID, WinLoss = @WinLoss, Date = @Date WHERE WordID = @id",
            new { WordID = game.WordID, WinLoss = game.WinLoss, Date = game.Date, id = game.WordID });
        }
    }
}
