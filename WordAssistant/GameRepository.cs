using Dapper;
using System.Collections.Generic;
using System.Data;
using WordAssistant.Models;

namespace WordAssistant
{
    public class GameRepository : IGameRepository  //this talks directly to database (database context)
    {
        private readonly IDbConnection _conn;
        public GameRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public Word CheckAnswer(string WordName)
        {
            return _conn.QuerySingleOrDefault<Word>("SELECT * FROM words WHERE Name = @WordName",
                new { WordName = WordName });
            //QuerySingleorDefault can return 1 or 0 (null)
        }

        public void DeleteGame(Game game)
        {
            _conn.Execute("DELETE FROM games WHERE GameID = @id;", new { id = game.GameID });
        }
        public IEnumerable<Game> GetAllGames()
        {
            //return _conn.Query<Game>("SELECT * FROM games;");
            return _conn.Query<Game>("SELECT games.GameID, games.WordID, games.WinLoss, games.Date, words.Name AS WordName FROM games JOIN words ON words.WordID = games.WordID;");
        }
        public Word GetWord(int id)
        {
            return _conn.QuerySingle<Word>("SELECT * FROM words WHERE WordID = @id", new { id = id });
        }
        public int GetWordID(string WordName)
        {
            var word = _conn.QuerySingleOrDefault<Word>("SELECT * FROM words WHERE Name = @WordName",
                new { WordName = WordName });
            return word.WordID;
            //return _conn.QuerySingle<Word>("SELECT * FROM words WHERE WordName = @WordName", new { id = id });
        }

        public Game GetGame(int id)
        {
            //return _conn.QuerySingle<Game>("SELECT * FROM games WHERE GameID = @id", new { id = id });
            return _conn.QuerySingle<Game>("SELECT games.GameID, games.WordID, games.WinLoss, games.Date, words.Name AS WordName FROM games JOIN words ON words.WordID = games.WordID WHERE GameID = @id", new { id = id });
        }

        public void InsertGame(Game gameToInsert)
        {
            _conn.Execute("INSERT INTO games (WordID, WinLoss, Date) VALUES (@WordID, @WinLoss, @Date);",
            new { WordID = gameToInsert.WordID, WinLoss = gameToInsert.WinLoss, Date = gameToInsert.Date });
        }

        public void UpdateGame(Game game)
        {
            _conn.Execute("UPDATE games SET WordID = @WordID, WinLoss = @WinLoss, Date = @Date WHERE GameID = @id",
            new { WordID = game.WordID, WinLoss = game.WinLoss, Date = game.Date, id = game.GameID });
        }
    }
}
