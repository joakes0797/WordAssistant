﻿using Dapper;
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

        public Game AssignWord()
        {
            var wordList = GetWords();
            var game = new Game();
            game.Word = wordList;
            return game;
        }
        public IEnumerable<Game> GetAllGames()
        {
            return _conn.Query<Game>("SELECT * FROM games;");
        }

        public IEnumerable<Words> GetWords()
        {
            return _conn.Query<Words>("SELECT * FROM words;");
        }

        public Game GetGame(int id)
        {
            return _conn.QuerySingle<Game>("SELECT * FROM games WHERE GameID = @id", new { id = id });
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
