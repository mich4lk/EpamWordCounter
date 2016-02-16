using System;
using EpamWordCounter.Intrefaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpamWordCounterTest
{
    [TestClass]
    public class EpamWordCounterTest
    {
        internal class MockedSentenceUtil : ISentenceUtil
        {
            string ISentenceUtil.CountWords(string sentence)
            {
                return "This is to return";
            }
        }

        [TestMethod]
        public void EpamWordCounter_Constructor_ArgsAreNull()
        {
            var epamWordCounter = new EpamWordCounter.EpamWordCounter(null, new MockedSentenceUtil());

            Assert.IsTrue("No sentence provided".Equals(epamWordCounter.Outcome));
        }

        [TestMethod]
        public void EpamWordCounter_Constructor_TooFewArgs()
        {
            var args = new string[0];
            var epamWordCounter = new EpamWordCounter.EpamWordCounter(args, new MockedSentenceUtil());

            Assert.IsTrue("No sentence provided".Equals(epamWordCounter.Outcome));
        }

        [TestMethod]
        public void EpamWordCounter_Constructor_TooManyArgs()
        {
            var args = new string[2];
            var epamWordCounter = new EpamWordCounter.EpamWordCounter(args, new MockedSentenceUtil());

            Assert.IsTrue("No sentence provided".Equals(epamWordCounter.Outcome));
        }

        [TestMethod]
        public void EpamWordCounter_Constructor_SentenceIsEmpty()
        {
            var args = new string[1] { "" };
            var epamWordCounter = new EpamWordCounter.EpamWordCounter(args, new MockedSentenceUtil());

            Assert.IsTrue("This is to return".Equals(epamWordCounter.Outcome));
        }

        [TestMethod]
        public void EpamWordCounter_Constructor_SentenceIsCorrect()
        {
            var args = new string[1] { "This is some sentence" };
            var epamWordCounter = new EpamWordCounter.EpamWordCounter(args, new MockedSentenceUtil());

            Assert.IsTrue("This is to return".Equals(epamWordCounter.Outcome));
        }
    }
}
