using MockPractice.StringManipulator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockPracticeTest
{
    public class StringManipulatorTest
    {
        private StringManipulator stringManipulator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.stringManipulator = new StringManipulator();
        }

        [TestCase("ebed", "eebd")]
        [TestCase("Ebed", "eebd")]
        [TestCase("alap", "aalp")]
        [TestCase("alAp", "aalp")]
        [TestCase("pici", "iipc")]
        [TestCase("picI", "iipc")]
        [TestCase("ollo", "ooll")]
        [TestCase("Owo", "oow")]
        [TestCase("uwu", "uuw")]
        [TestCase("UwU", "uuw")]
        [TestCase("why", "ywh")]
        public void Transform_Should_ReturnCorrectOutput(string input, string output)
        {
            Assert.AreEqual(output, this.stringManipulator.Transform(input));
        }

        [TestCase('b')]
        [TestCase('B')]
        [TestCase('c')]
        [TestCase('C')]
        [TestCase('d')]
        [TestCase('D')]
        [TestCase('f')]
        [TestCase('F')]
        [TestCase('g')]
        [TestCase('G')]
        [TestCase('h')]
        [TestCase('H')]
        [TestCase('j')]
        [TestCase('J')]
        [TestCase('k')]
        [TestCase('K')]
        [TestCase('l')]
        [TestCase('L')]
        [TestCase('m')]
        [TestCase('M')]
        [TestCase('n')]
        [TestCase('N')]
        [TestCase('p')]
        [TestCase('P')]
        [TestCase('q')]
        [TestCase('Q')]
        [TestCase('r')]
        [TestCase('R')]
        [TestCase('s')]
        [TestCase('S')]
        [TestCase('t')]
        [TestCase('T')]
        [TestCase('v')]
        [TestCase('V')]
        [TestCase('w')]
        [TestCase('W')]
        [TestCase('x')]
        [TestCase('X')]
        [TestCase('z')]
        [TestCase('Z')]
        public void IsVowel_Should_ReturnFalse_When_CalledWithConsonant(char consonant)
        {
            Assert.False(this.stringManipulator.IsVowel(consonant));
        }

        [TestCase('a')]
        [TestCase('A')]
        [TestCase('e')]
        [TestCase('E')]
        [TestCase('i')]
        [TestCase('I')]
        [TestCase('o')]
        [TestCase('O')]
        [TestCase('u')]
        [TestCase('U')]
        [TestCase('y')]
        [TestCase('Y')]
        public void IsVowel_Should_ReturnTrue_When_CalledWithVowel(char vowel)
        {
            Assert.True(this.stringManipulator.IsVowel(vowel));
        }
    }
}
