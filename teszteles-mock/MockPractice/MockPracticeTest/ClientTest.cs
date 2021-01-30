using MockPractice.Practice;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockPracticeTest
{
    public class ClientTest
    {
        [Test]
        public void Constructor_Should_ThrowArgumentNullException_WhenCalledWithNull()
        {
            var mockService = Helper.GetServiceMock("TestService", false);
            var mockContentFormatter = Helper.GetContentFormatterMock();
            Assert.Throws<ArgumentNullException>(() => new Client(null, null));
            Assert.Throws<ArgumentNullException>(() => new Client(mockService.Object, null));
            Assert.Throws<ArgumentNullException>(() => new Client(null, mockContentFormatter.Object));
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void GetIdentity_Should_ReturnIdentity(int identity)
        {
            var mockService = Helper.GetServiceMock("TestService", false);
            var mockContentFormatter = Helper.GetContentFormatterMock();
            var client = new Client(mockService.Object, mockContentFormatter.Object, identity);
            Assert.AreEqual(identity.ToString(), client.GetIdentity());
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void GetIdentityFormatted_Should_ReturnFormattedIdentity(int identity)
        {
            var mockService = Helper.GetServiceMock("TestService", false);
            var mockContentFormatter = Helper.GetContentFormatterMock();
            var client = new Client(mockService.Object, mockContentFormatter.Object, identity);
            Assert.IsTrue(client.GetIdentityFormatted().Contains(identity.ToString()));
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("TestService")]
        public void GetServiceName_Should_ReturnServiceName(string serviceName)
        {
            var mockService = Helper.GetServiceMock(serviceName, false);
            var mockContentFormatter = Helper.GetContentFormatterMock();
            var client = new Client(mockService.Object, mockContentFormatter.Object);
            Assert.AreEqual(serviceName, client.GetServiceName());
            mockService.VerifyGet(s => s.Name, Times.Once);
        }

        [Test]
        public void Dispose_Should_CallDispose()
        {
            var mockService = Helper.GetServiceMock("TestService", false);
            var mockContentFormatter = Helper.GetContentFormatterMock();
            var client = new Client(mockService.Object, mockContentFormatter.Object);
            client.Dispose();
            mockService.Verify(s => s.Dispose(), Times.Once);
        }

        [TestCase(-666)]
        [TestCase(0)]
        [TestCase(666)]
        public void GetContent_Should_CallConnect_When_ServiceIsNotConnected(long id)
        {
            var mockService = Helper.GetServiceMock("TestService", false);
            var mockContentFormatter = Helper.GetContentFormatterMock();
            var client = new Client(mockService.Object, mockContentFormatter.Object);
            client.GetContent(id);
            mockService.VerifyGet(s => s.IsConnected, Times.Once);
            mockService.Verify(s => s.Connect(), Times.Once);
        }

        [TestCase(-666)]
        [TestCase(0)]
        [TestCase(666)]
        public void GetContent_ShouldNot_CallConnect_When_ServiceIsConnected(long id)
        {
            var mockService = Helper.GetServiceMock("TestService", true);
            var mockContentFormatter = Helper.GetContentFormatterMock();
            var client = new Client(mockService.Object, mockContentFormatter.Object);
            client.GetContent(id);
            mockService.VerifyGet(s => s.IsConnected, Times.Once);
            mockService.Verify(s => s.Connect(), Times.Never);
        }

        [TestCase(-666, "")]
        [TestCase(-1, " ")]
        [TestCase(0, null)]
        [TestCase(666, "TestContent")]
        public void GetContent_Should_ReturnCorrectValue(long id, string content)
        {
            Func<long, string> getContent = ((long l) => content);
            var mockService = Helper.GetServiceMock("TestService", true, getContent: getContent);
            var mockContentFormatter = Helper.GetContentFormatterMock();
            var client = new Client(mockService.Object, mockContentFormatter.Object);
            Assert.AreEqual(getContent(id), client.GetContent(id));
            mockService.Verify(s => s.GetContent(It.IsAny<long>()), Times.Once);
        }

        [TestCase(-666)]
        [TestCase(0)]
        [TestCase(666)]
        public void GetContentFormatted_Should_CallGetContent_And_CallFormat(long id)
        {
            var mockService = Helper.GetServiceMock("TestService", true);
            var mockContentFormatter = Helper.GetContentFormatterMock();
            var client = new Client(mockService.Object, mockContentFormatter.Object);
            client.GetContentFormatted(id);
            mockService.Verify(s => s.GetContent(It.IsAny<long>()), Times.Once);
            mockContentFormatter.Verify(c => c.Format(It.IsAny<string>()), Times.Once);
        }

        [TestCase(-666, "", "formatted")]
        [TestCase(-1, " ", "")]
        [TestCase(0, null, "non existing content")]
        [TestCase(666, "TestContent", null)]
        public void GetContentFormatted_Should_ReturnCorrectValue(long id, string content, string formattedContent)
        {
            Func<long, string> getContent = ((long l) => content);
            Func<string, string> format = ((string s) => formattedContent);
            var mockService = Helper.GetServiceMock("TestService", true);
            var mockContentFormatter = Helper.GetContentFormatterMock(format);
            var client = new Client(mockService.Object, mockContentFormatter.Object);
            Assert.AreEqual(format(content), client.GetContentFormatted(id));
        }
    }
}
