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

        //public IEnumerable<Word> GetResults(string totalQuery)
        //{
        //    return _conn.Query<Word>(totalQuery);
        //    //throw new System.NotImplementedException();
        //}

        public IEnumerable<Word> GetResults(string green, string y1, string y2, string y3, string y4, string y5, string g1, string g2, string g3, string g4, string g5)
        {
            return _conn.Query<Word>("SELECT * FROM words WHERE Name LIKE @green AND Name LIKE @y1 AND Name LIKE @y2 AND Name LIKE @y3 AND Name LIKE @y4 AND Name LIKE @y5 AND Name NOT LIKE @g1 AND Name NOT LIKE @g2 AND Name NOT LIKE @g3 AND Name NOT LIKE @g4 AND Name NOT LIKE @g5", new { green, y1, y2, y3, y4, y5, g1, g2, g3, g4, g5 });
        }
    }
}
