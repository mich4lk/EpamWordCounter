using EpamWordCounter.Intrefaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamWordCounter.Utils
{
    public class SentenceUtil : ISentenceUtil
    {
        private ICounterLogic _counterLogic;
        private DictUtil _dictUtil;
        public SentenceUtil(ICounterLogic counterLogic, string formatString, bool newLines = true)
        {
            _counterLogic = counterLogic;
            _dictUtil = new DictUtil(formatString, newLines);
        }

        public string CountWords(string sentence)
        {
            var result = ExecuteCounter(sentence);
            return _dictUtil.ConvertDictToSortedString(result);
        }

        private Dictionary<string, int> ExecuteCounter(string sentence)
        {
            return _counterLogic.CountWordsInSentence(sentence);
        }
    }
}
