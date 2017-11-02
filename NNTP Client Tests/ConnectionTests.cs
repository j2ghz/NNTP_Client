using System.Text.RegularExpressions;
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
        public void ConnectReadMessage()
        {
            var connection = new Connection("news.dotsrc.org", 119);
            var message = connection.WelcomeMessage;
            Assert.AreEqual("200 news.sunsite.dk NNRP Service Ready - staff@sunsite.dk (posting ok).", message);
        }

        [TestMethod]
        public void GetHelpMessage()
        {
            var connection = new Connection("news.dotsrc.org", 119);
            var result = connection.Execute("help");
            Assert.IsTrue(result.StartsWith("100"), $"result should start with 100\n{result}");
            Assert.IsTrue(Regex.Split(result, "\r\n|\r|\n").Length > 1,
                $"result should have more than one line\n{result}");
        }
    }
}