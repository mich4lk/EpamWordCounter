using EpamWordCounter.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamWordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var ewc = new EpamWordCounter(args, new SentenceUtil(new ClassicCounterLogic(), "{0} - {1}"));
            Console.WriteLine(ewc.Outcome);
            Console.ReadLine();
        }
    }
}
