using Dapper;
using System.Collections.Generic;
using System.Data;
using WordAssistant.Models;

namespace WordAssistant
{
    public class GuessRepository : IGuessRepository
    {
        private readonly IDbConnection _conn;
        public GuessRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Word> GetGreenResults(string green)
        {
            return _conn.Query<Word>("SELECT * FROM words WHERE Name LIKE @green", new { green });
            //return _conn.Query<Word>("SELECT * FROM words WHERE Name LIKE '@WordName';",
            //    new { WordName = "c__g_" });
                    //throw new System.NotImplementedException();
        }

    }
}
