using EpamWordCounter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


namespace EpamWordCounterTest
{
    [TestClass]
    public class ClassicCounterLogicTest
    {
        [TestMethod]
        public void CountWords_CorrectSentencePassed_CountsWordCorrectly()
        {
            var wordsCounter = new ClassicCounterLogic();
            var properDict = new Dictionary<string, int>
            {
                { "this", 2 },
                { "is", 2 },
                { "a", 1 },
                { "sentence", 1 },
                { "so", 1 }
            };

            var result = wordsCounter.CountWordsInSentence("This is a sentence, so is this.");

            Assert.IsTrue(properDict.All(e => result.Contains(e)));
        }

        [TestMethod]
        public void CountWords_IncorrectSentencePassed_CountsWordCorrectly()
        {
            var wordsCounter = new ClassicCounterLogic();
            var properDict = new Dictionary<string, int>
            {
                { "this", 2 },
                { "is", 2 },
                { "a", 1 },
                { "sentence", 1 },
                { "so", 1 }
            };

            var result = wordsCounter.CountWordsInSentence("This a different sentence, so is this.");

            Assert.IsFalse(properDict.All(e => result.Contains(e)));
        }

        [TestMethod]
        public void CountWords_EmptySentences_CountsWordCorrectly()
        {
            var wordsCounter = new ClassicCounterLogic();
            var properDict = new Dictionary<string, int>();

            var result = wordsCounter.CountWordsInSentence(string.Empty);

            Assert.IsTrue(properDict.All(e => result.Contains(e)));
        }

        [TestMethod]
        public void CountWords_NullPassed_CatchesException()
        {
            var wordsCounter = new ClassicCounterLogic();
            var properDict = new Dictionary<string, int>();

            var result = wordsCounter.CountWordsInSentence(null);

            Assert.IsFalse(result.Any());
        }
    }
}
