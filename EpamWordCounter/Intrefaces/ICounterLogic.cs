using System.Collections.Generic;

namespace EpamWordCounter
{
    public interface ICounterLogic
    {
        Dictionary<string, int> CountWordsInSentence(string sentence);
    }
}
