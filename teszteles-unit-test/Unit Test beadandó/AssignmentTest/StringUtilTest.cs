using Assignment.Strings;
using NUnit.Framework;
using System;

namespace AssignmentTest
{
    public class StringUtilTest
    {
        [Test]
        public void IsPalindrom_Should_ReturnTrue_When_CalledWithEmptyInput()
        {
            var util = new StringUtil();
            bool act() => util.IsPalindrom(string.Empty);
            Assert.AreEqual(true, act());
        }

        [Test]
        public void IsPalindrom_Should_ReturnTrue_When_CalledWithWhitespaceInput()
        {
            var util = new StringUtil();
            bool act() => util.IsPalindrom("     ");
            Assert.AreEqual(true, act());
        }

        [Test]
        public void IsPalindrom_Should_ThrowArgumentNullException_When_CalledWithNullInput()
        {
            var util = new StringUtil();
            void act() => util.IsPalindrom(null);
            Assert.Throws<ArgumentNullException>(act);
        }

        [TestCase("abc")]
        [TestCase("cba")]
        [TestCase("aab")]
        [TestCase("baa")]
        [TestCase(" aa")]
        [TestCase("aa ")]
        public void IsPalindrom_Should_ReturnFalse_When_CalledWithNonPalindromInput(string input)
        {
            var util = new StringUtil();
            bool act() => util.IsPalindrom(input);
            Assert.AreEqual(false, act());
        }

        [TestCase("Aaa")]
        [TestCase("aaa")]
        [TestCase("aba")]
        [TestCase("a a")]
        [TestCase(" a ")]
        [TestCase("a.a")]
        [TestCase(".a.")]
        public void IsPalindrom_Should_ReturnTrue_When_CalledWithPalindromInput(string input)
        {
            var util = new StringUtil();
            bool act() => util.IsPalindrom(input);
            Assert.AreEqual(true, act());
        }
    }
}
