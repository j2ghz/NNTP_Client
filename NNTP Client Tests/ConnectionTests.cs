using System.Linq;
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
        public void GetHelpMessageTest()
        {
            var connection = new Connection("news.dotsrc.org", 119);
            var result = connection.ExecuteMultiline("help");
            Assert.IsTrue(result.First().StartsWith("100"), $"result should start with 100\n{result}");
            Assert.IsTrue(result.Count() > 1,
                $"result should have more than one line\n{result}");
            Assert.IsFalse(result.Last() ==".", "there should not be . at the end");
        }
    }
}