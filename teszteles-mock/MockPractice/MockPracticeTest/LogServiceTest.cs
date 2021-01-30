using MockPractice.Challenge;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockPracticeTest
{
    public class LogServiceTest
    {
        [Test]
        public void RegisterLogger_Should_ThrowArgumentNullException_When_CalledWithNull()
        {
            ILogger logger = null;
            var logService = new LogService();
            Assert.Throws<ArgumentNullException>(() => logService.RegisterLogger(logger));
        }

        [Test]
        public void RegisterLogger_ShouldNot_ThrowException_WhenCalledWithNotNull()
        {
            ILogger logger = Helper.GetLoggerMock().Object;
            var logService = new LogService();
            Assert.That(() => logService.RegisterLogger(logger), Throws.Nothing);
        }

        [Test]
        [Combinatorial]
        public void Log_Should_CallOnlySupportedLogLevel([Values(null, "", " ", "message", "\r\n")] string message, [Values(1, 2, 3, 4, 5, 6, 7)] LogLevel supportedLogLevel, [Values(1, 2, 3, 4, 5, 6, 7)] LogLevel loglevel)
        {
            bool supportsLogLevel(LogLevel l) => supportedLogLevel.HasFlag(l);
            var logService = new LogService();
            var loggerMock = Helper.GetLoggerMock(supportsLogLevel: supportsLogLevel);
            logService.RegisterLogger(loggerMock.Object);
            logService.Log(message, loglevel);
            loggerMock.Verify(l => l.Log(It.IsAny<string>(), It.IsAny<LogLevel>()), supportsLogLevel(loglevel) ? Times.Once() : Times.Never());
        }
    }
}
