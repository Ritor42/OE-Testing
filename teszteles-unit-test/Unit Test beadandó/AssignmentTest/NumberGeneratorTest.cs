using Assignment.Numbers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTest
{
    public class NumberGeneratorTest
    {
        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-10)]
        public void GenerateEven_Should_ReturnArgumentOutOfRangeException_When_CalledWithNegativeInput(int input)
        {
            var generator = new NumberGenerator();
            void act() => generator.GenerateEven(input);
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [TestCase(0)]
        [TestCase(5)]
        [TestCase(10)]
        public void GenerateEven_Should_ReturnEvenNumber_When_CalledWithNonNegativeInput(int input)
        {
            var generator = new NumberGenerator();
            bool act() => generator.GenerateEven(input) % 2 == 0;
            Assert.AreEqual(true, act());
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-5)]
        public void GenerateOdd_Should_ReturnArgumentOutOfRangeException_When_CalledWithNonPositiveInput(int input)
        {
            var generator = new NumberGenerator();
            void act() => generator.GenerateOdd(input);
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public void GenerateOdd_Should_ReturnOddNumber_When_CalledWithPositiveInput(int input)
        {
            var generator = new NumberGenerator();
            bool act() => generator.GenerateOdd(input) % 2 == 1;
            Assert.AreEqual(true, act());
        }
    }
}
