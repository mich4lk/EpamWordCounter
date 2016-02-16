using EpamWordCounter.Intrefaces;
using EpamWordCounter.Utils;
using System;

namespace EpamWordCounter
{
    public class EpamWordCounter
    {
        public string Outcome = string.Empty;
        private ISentenceUtil _sentenceUtil;
        public EpamWordCounter(string[] args, ISentenceUtil sentenceUtil)
        {
            string message = string.Empty;
            if (!ParamUtil.CheckParams(args, out message))
            {
                Outcome = message;
                return;
            }

            var _sentenceUtil = sentenceUtil;
            Outcome = _sentenceUtil.CountWords(args[0]);
        }

        
    }
}
