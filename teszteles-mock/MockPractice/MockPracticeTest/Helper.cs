using MockPractice.Challenge;
using MockPractice.Practice;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockPracticeTest
{
    internal static class Helper
    {
        internal static Mock<IService> GetServiceMock(string name, bool connected, IDisposable connectResult = null, Func<long, string> getContent = null)
        {
            getContent = getContent ?? ((long l) => null);
            var mockService = new Mock<IService>();
            mockService.SetupGet(s => s.Name).Returns(name).Verifiable();
            mockService.SetupGet(s => s.IsConnected).Returns(connected).Verifiable();
            mockService.Setup(s => s.Connect()).Returns(connectResult).Verifiable();
            mockService.Setup(s => s.GetContent(It.IsAny<long>())).Returns(getContent).Verifiable();
            return mockService;
        }

        internal static Mock<IContentFormatter> GetContentFormatterMock(Func<string, string> format = null)
        {
            format = format ?? ((string s) => null);
            var mockContentFormatter = new Mock<IContentFormatter>();
            mockContentFormatter.Setup(c => c.Format(It.IsAny<string>())).Returns(format).Verifiable();
            return mockContentFormatter;
        }

        internal static Mock<ILogger> GetLoggerMock(Action<string, LogLevel> log = null, Func<LogLevel, bool> supportsLogLevel = null)
        {
            log = log ?? ((string s, LogLevel l) => { });
            supportsLogLevel = supportsLogLevel ?? ((LogLevel l) => false);
            var mockLogger = new Mock<ILogger>();
            mockLogger.Setup(l => l.Log(It.IsAny<string>(), It.IsAny<LogLevel>())).Callback(log).Verifiable();
            mockLogger.Setup(l => l.SupportsLogLevel(It.IsAny<LogLevel>())).Returns(supportsLogLevel).Verifiable();
            return mockLogger;
        }
    }
}
