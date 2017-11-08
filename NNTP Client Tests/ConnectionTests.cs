using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NNTP_Client;

namespace NNTP_Client_Tests
{
    [TestClass]
    public class ConnectionTests
    {
        [TestMethod]
        public void ConnectTest()
        {
            var connection = new Connection("news.dotsrc.org", 119);
            Assert.IsNotNull(connection);
            Assert.IsNotNull(connection.ns);
        }

        [TestMethod]
        public void ConnectReadMessageTest()
        {
            var connection = new Connection("news.dotsrc.org", 119);
            var message = connection.WelcomeMessage;
            Assert.AreEqual("200 news.sunsite.dk NNRP Service Ready - staff@sunsite.dk (posting ok).", message);
        }

        [TestMethod]
        public void InvalidCommandTest()
        {
            var connection = new Connection("news.dotsrc.org", 119);
            var result = connection.Execute(".");
            Assert.IsTrue(result.StartsWith("500"), $"result should start with 500\n{result}");
        }


        [TestMethod]
        public void InvalidMultilineTest()
        {
            var connection = new Connection("news.dotsrc.org", 119);
            var result = connection.ExecuteMultiline(".");
            result.Should().HaveCount(1);
            result.First().Should().StartWith("5");
        }
    }
}