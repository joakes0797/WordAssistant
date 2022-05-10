using System.Collections.Generic;
using WordAssistant.Models;

namespace WordAssistant
{
    public interface IGuessRepository
    {
        public IEnumerable<Word> GetGreenResults(string green);
        public IEnumerable<Word> GetResults(string green, string y1, string y2, string y3, string y4, string y5, string g1, string g2, string g3, string g4, string g5);
    }
}
