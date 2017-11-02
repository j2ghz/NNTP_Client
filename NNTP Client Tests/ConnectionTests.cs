using System;
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
            var connection = new Connection("news.dotsrc.org",119);
            Assert.IsNotNull(connection);
            Assert.IsNotNull(connection.ns);
        }
    }
}
