using System.Collections.Generic;
using WordAssistant.Models;

namespace WordAssistant
{
    public interface IGuessRepository
    {
        public IEnumerable<Word> GetGreenResults(string green);
    }
}
