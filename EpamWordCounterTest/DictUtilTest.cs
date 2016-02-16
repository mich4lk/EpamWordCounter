using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamWordCounter.Utils;
using EpamWordCounter.Exceptions;
using System.Collections.Generic;

namespace EpamWordCounterTest
{
    [TestClass]
    public class DictUtilTest
    {
        [TestMethod]
        public void DictUtil_Constructor_ThrowsSortFormatException()
        {
            InvalidSortFormatException exceptionCought = null;

            try
            {
                var dictUtil0 = new DictUtil("{3} - {1} {2}", true);
            }
            catch (InvalidSortFormatException isfe) { exceptionCought = isfe; }
            Assert.IsNotNull(exceptionCought);
            exceptionCought = null;

            try
            {
                var dictUtil1 = new DictUtil("{0} - {2}", true);
            }
            catch (InvalidSortFormatException isfe) { exceptionCought = isfe; }
            Assert.IsNotNull(exceptionCought);
            exceptionCought = null;

            try
            {
                var dictUtil2 = new DictUtil("", true);
            }
            catch (InvalidSortFormatException isfe) { exceptionCought = isfe; }
            Assert.IsNotNull(exceptionCought);
            exceptionCought = null;

            try
            {
                var dictUtil3 = new DictUtil("{1} - {2}", true);
            }
            catch (InvalidSortFormatException isfe) { exceptionCought = isfe; }
            Assert.IsNotNull(exceptionCought);
            exceptionCought = null;

            try
            {
                var dictUtil4 = new DictUtil("{2}", true);
            }
            catch (InvalidSortFormatException isfe) { exceptionCought = isfe; }
            Assert.IsNotNull(exceptionCought);
            exceptionCought = null;

            try
            {
                var dictUtil5 = new DictUtil("{0}", true);
            }
            catch (InvalidSortFormatException isfe) { exceptionCought = isfe; }
            Assert.IsNotNull(exceptionCought);
            exceptionCought = null;

            try
            {
                var dictUtil6 = new DictUtil("{1}", true);
            }
            catch (InvalidSortFormatException isfe) { exceptionCought = isfe; }
            Assert.IsNotNull(exceptionCought);
            exceptionCought = null;

            try
            {
                var dictUtil7 = new DictUtil("{0{1}}", true);
            }
            catch (InvalidSortFormatException isfe) { exceptionCought = isfe; }
            Assert.IsNotNull(exceptionCought);
            exceptionCought = null;

            try
            { var dictUtil7 = new DictUtil("{0} - {1} {2}", true); }
            catch (InvalidSortFormatException isfe) { exceptionCought = isfe; }
            Assert.IsNotNull(exceptionCought);
            exceptionCought = null;
        }

        [TestMethod]
        public void DictUtil_Constructor_NotThrowsSortFormatException()
        {
            DictUtil dictUtil = null;
            try
            {
                dictUtil = new DictUtil("{0} - {1}", true);
            }
            catch (InvalidSortFormatException) { }
            
            Assert.IsNotNull(dictUtil);
            dictUtil = null;

            dictUtil = null;
            try
            {
                dictUtil = new DictUtil("{1} - {0}", true);
            }
            catch (InvalidSortFormatException){ }
            Assert.IsNotNull(dictUtil);
        }

        [TestMethod]
        public void DictUtil_Constructor_SetNewLineIndicatorDefault()
        {
            DictUtil dictUtil = null;
            
            dictUtil = new DictUtil("{0} - {1}", true);

            Assert.IsTrue(dictUtil.EachLineInNewLine);
        }

        [TestMethod]
        public void DictUtil_Constructor_SetNewLineIndicatorTrue()
        {
            DictUtil dictUtil = null;

            dictUtil = new DictUtil("{0} - {1}", true);

            Assert.IsTrue(dictUtil.EachLineInNewLine);
        }

        [TestMethod]
        public void DictUtil_Constructor_SetNewLineIndicatorFalse()
        {
            DictUtil dictUtil = null;

            dictUtil = new DictUtil("{0} - {1}", false);

            Assert.IsFalse(dictUtil.EachLineInNewLine);
        }

        [TestMethod]
        public void DictUtil_ConvertDictToSortedString_ConvertToCorrectStringFalse()
        {
            var dict = new Dictionary<string, int>
            {
                { "this", 2 },
                { "is", 2 },
                { "a", 1 },
                { "sentence", 1 },
                { "so", 1 }
            };
            var properString = "2 - this2 - is1 - a1 - sentence1 - so";
            var dictUtil = new DictUtil("{1} - {0}", false);
            var computedString = dictUtil.ConvertDictToSortedString(dict);

            Assert.IsTrue(properString.Equals(computedString));
        }

        [TestMethod]
        public void DictUtil_ConvertDictToSortedString_ConvertToInCorrectStringFalse()
        {
            var dict = new Dictionary<string, int>
            {
                { "this", 2 },
                { "is", 2 },
                { "a", 1 },
                { "sentence", 1 },
                { "so", 1 }
            };
            var properString = "2 - this\n2 - is\n1 - a\n1 - sentence\n1 - so";
            var dictUtil = new DictUtil("{1} - {0}", false);
            var computedString = dictUtil.ConvertDictToSortedString(dict);

            Assert.IsFalse(properString.Equals(computedString));
        }

        [TestMethod]
        public void DictUtil_ConvertDictToSortedString_ConvertToCorrectStringTrue()
        {
            var dict = new Dictionary<string, int>
            {
                { "this", 2 },
                { "is", 2 },
                { "a", 1 },
                { "sentence", 1 },
                { "so", 1 }
            };
            var properString = "this - 2\nis - 2\na - 1\nsentence - 1\nso - 1\n";
            var dictUtil = new DictUtil("{0} - {1}", true);
            var computedString = dictUtil.ConvertDictToSortedString(dict);

            Assert.IsTrue(properString.Equals(computedString));
        }

        [TestMethod]
        public void DictUtil_ConvertDictToSortedString_ConvertToInCorrectStringTrue()
        {
            var dict = new Dictionary<string, int>
            {
                { "this", 2 },
                { "is", 2 },
                { "a", 1 },
                { "sentence", 1 },
                { "so", 1 }
            };
            var properString = "this - 2is - 2a - 1sentence - 1so - 1";
            var dictUtil = new DictUtil("{0} - {1}", true);
            var computedString = dictUtil.ConvertDictToSortedString(dict);

            Assert.IsFalse(properString.Equals(computedString));
        }
    }
}
