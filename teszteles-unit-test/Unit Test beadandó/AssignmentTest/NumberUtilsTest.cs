using Assignment.Numbers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTest
{
    public class NumberUtilsTest
    {
        [TestCase(-2)]
        [TestCase(0)]
        [TestCase(2)]
        public void EvenOrOdd_Should_ReturnEven_When_CalledWithEvenInput(int input)
        {
            var utils = new NumberUtils();
            string act() => utils.EvenOrOdd(input);
            Assert.AreEqual("even", act());
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void EvenOrOdd_Should_ReturnOdd_When_CalledWithOddInput(int input)
        {
            var utils = new NumberUtils();
            string act() => utils.EvenOrOdd(input);
            Assert.AreEqual("odd", act());
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(7)]
        public void GetDivisors_Should_ReturnTwoDivisors_When_CalledWithPrimeInput(int input)
        {
            var utils = new NumberUtils();
            int act() => utils.GetDivisors(input).Count;
            Assert.AreEqual(2, act());
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(7)]
        public void IsPrime_Should_ReturnTrue_When_CalledWithPrimeInput(int input)
        {
            var utils = new NumberUtils();
            bool act() => utils.IsPrime(input);
            Assert.AreEqual(true, act());
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(10)]
        [TestCase(20)]
        public void IsPrime_Should_ReturnFalse_When_CalledWithNonPrimeInput(int input)
        {
            var utils = new NumberUtils();
            bool act() => utils.IsPrime(input);
            Assert.AreEqual(false, act());
        }
    }
}
