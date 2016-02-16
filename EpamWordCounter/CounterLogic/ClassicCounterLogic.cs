using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EpamWordCounter
{
    public class ClassicCounterLogic: ICounterLogic
    {
        private string _regexPattern = @"([\d\w\-\']+)";

        public Dictionary<string, int> CountWordsInSentence(string sentence)
        {
            var toReturn = new Dictionary<string, int>();

            if (string.IsNullOrWhiteSpace(sentence))
                return toReturn;

            var regex = new Regex(_regexPattern);
            var splitted = regex.Split(sentence.ToLowerInvariant());

            foreach (var word in splitted)
            {
                if (!regex.IsMatch(word))
                    continue;
                if (toReturn.ContainsKey(word))
                    toReturn[word]++;
                else
                    toReturn.Add(word, 1);
            }

            return toReturn;
        }
    }
}
