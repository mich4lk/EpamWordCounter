using EpamWordCounter.Exceptions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EpamWordCounter.Utils
{
    public class DictUtil
    {
        public bool EachLineInNewLine { get; }
        
        private string _sortFormat;

        public DictUtil(string sortFormat, bool eachLineInNewLine)
        {
            if (!sortFormat.Contains("{0}") || !sortFormat.Contains("{1}"))
                throw new InvalidSortFormatException();

            var tmpSortFormat = sortFormat.Replace("{0}", "").Replace("{1}", "");
            if (Regex.IsMatch(tmpSortFormat, ("{[\\d]}")))
                throw new InvalidSortFormatException();


            _sortFormat = eachLineInNewLine ? sortFormat + "\n" : sortFormat;
            EachLineInNewLine = eachLineInNewLine;
        }

        public string ConvertDictToSortedString(Dictionary<string, int> dictionaryToSort)
        {
            using (var sw = new StringWriter())
            {
                foreach (var entry in dictionaryToSort.OrderByDescending(i => i.Value))
                    sw.Write(string.Format(_sortFormat, entry.Key, entry.Value));
                return sw.ToString();
            }
        }
    }
}
