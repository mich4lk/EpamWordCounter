using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamWordCounter;
using EpamWordCounter.Utils;

namespace EpamWordCounterTest
{
    [TestClass]
    public class SentenceUtilTest
    {
        [TestMethod]
        public void SentenceUtil_Constructor_CreatesCorrectObject()
        {
            var classicCounterLogic = new ClassicCounterLogic();

            var senteceUtil = new SentenceUtil(classicCounterLogic, "{0} - {1}");

            Assert.IsNotNull(senteceUtil);

            senteceUtil = null;
        }

        [TestMethod]
        public void SentenceUtil_CountWord_ReturnInvertedStringWithNewLines()
        {
            var classicCounterLogic = new ClassicCounterLogic();
            var expectedString = "2 - this\n2 - is\n1 - a\n1 - sentence\n1 - so\n";
            var senteceUtil = new SentenceUtil(classicCounterLogic, "{1} - {0}");

            var computedString = senteceUtil.CountWords("This is a sentence, so is this.");

            Assert.IsTrue(expectedString.Equals(computedString));
        }

        [TestMethod]
        public void SentenceUtil_CountWord_ReturnInvertedStringWithOutNewLines()
        {
            var classicCounterLogic = new ClassicCounterLogic();
            var expectedString = "2 - this2 - is1 - a1 - sentence1 - so";
            var senteceUtil = new SentenceUtil(classicCounterLogic, "{1} - {0}", false);

            var computedString = senteceUtil.CountWords("This is a sentence, so is this.");

            Assert.IsTrue(expectedString.Equals(computedString));
        }

        [TestMethod]
        public void SentenceUtil_CountWord_ReturnStringWithNewLines()
        {
            var classicCounterLogic = new ClassicCounterLogic();
            var expectedString = "this - 2\nis - 2\na - 1\nsentence - 1\nso - 1\n";
            var senteceUtil = new SentenceUtil(classicCounterLogic, "{0} - {1}");

            var computedString = senteceUtil.CountWords("This is a sentence, so is this.");

            Assert.IsTrue(expectedString.Equals(computedString));
        }

        [TestMethod]
        public void SentenceUtil_CountWord_ReturnStringWithOutNewLines()
        {
            var classicCounterLogic = new ClassicCounterLogic();
            var expectedString = "this - 2is - 2a - 1sentence - 1so - 1";
            var senteceUtil = new SentenceUtil(classicCounterLogic, "{0} - {1}", false);

            var computedString = senteceUtil.CountWords("This is a sentence, so is this.");

            Assert.IsTrue(expectedString.Equals(computedString));
        }


    }
}
