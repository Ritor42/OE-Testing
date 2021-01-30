using Assignment.Numbers;
using Assignment.Strings;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTest
{
    public class StringGeneratorTest
    {
        private INumberGenerator numberGenerator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var mock = new Mock<INumberGenerator>();
            mock.Setup(m => m.GenerateOdd(It.IsAny<int>())).Returns(1);
            mock.Setup(m => m.GenerateEven(It.IsAny<int>())).Returns(0);
            this.numberGenerator = mock.Object;
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public void GenerateEvenOddPairs_Should_ReturnCorrectCountOfPairs_When_CalledWithCorrectPairCountInput(int input)
        {
            var generator = new StringGenerator(this.numberGenerator);
            int act() => generator.GenerateEvenOddPairs(input, int.MaxValue).Count;
            Assert.AreEqual(input, act());
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public void GenerateEvenOddPairs_Should_ReturnCorrectFormattedPairs_When_CalledWithCorrectInput(int input)
        {
            var generator = new StringGenerator(this.numberGenerator);
            List<string> act() => generator.GenerateEvenOddPairs(input, int.MaxValue);
            Assert.That(act().All(pair =>
            {
                string[] parts = pair.Split(',');
                if (parts.Length == 2)
                {
                    if (int.TryParse(parts[0], out int first) && int.TryParse(parts[1], out int last) &&
                        (first % 2 == 0 && last % 2 == 1 || first % 2 == 1 && last % 2 == 0))
                    {
                        return true;
                    }
                }
                return false;
            }));
        }
    }
}
