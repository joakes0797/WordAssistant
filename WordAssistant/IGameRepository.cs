﻿using System.Collections.Generic;
using WordAssistant.Models;

namespace WordAssistant
{
    public interface IGameRepository
    {
        public void DeleteGame(Game game);
        public IEnumerable<Game> GetAllGames();
        public Game GetGame(int id);
        public void UpdateGame(Game game);
        public void InsertGame(Game gameToInsert);
        public IEnumerable<Words> GetWords();  
        public Game AssignWord(); //needs more work
    }
}
