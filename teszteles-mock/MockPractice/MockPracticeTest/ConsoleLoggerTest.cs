using MockPractice.Challenge;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MockPracticeTest
{
    public class ConsoleLoggerTest
    {
        private readonly StringWriter textWriter = new StringWriter();
        private readonly ConsoleLogger consoleLogger = new ConsoleLogger();
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1);

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Console.SetOut(this.textWriter);
        }

        [SetUp]
        public void SetUp()
        {
            this.semaphore.Wait();
        }

        [TearDown]
        public void TearDown()
        {
            this.textWriter.GetStringBuilder().Clear();
            this.semaphore.Release();
        }

        [TestCase(DayOfWeek.Sunday)]
        [TestCase(DayOfWeek.Monday)]
        [TestCase(DayOfWeek.Tuesday)]
        [TestCase(DayOfWeek.Wednesday)]
        [TestCase(DayOfWeek.Thursday)]
        [TestCase(DayOfWeek.Friday)]
        [TestCase(DayOfWeek.Saturday)]
        public void PrintNextWeekday_Should_ReturnCorrectValue(DayOfWeek input)
        {
            int addition = (int)input - (int)DateTime.Now.DayOfWeek;
            var nextDay = DateTime.Now.AddDays((addition <= 0) ? addition + 7 : addition);
            this.consoleLogger.PrintNextWeekday(input);
            Assert.AreEqual(nextDay.Date, DateTime.Parse(this.textWriter.ToString()).Date);
        }
    }
}
