using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NNTP_Client.Tests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void ClientLoginTest()
        {
            var client = new Client("news.dotsrc.org", 119, "j2.00ghz@gmail.com", "209742");
            Assert.IsNotNull(client);
        }

        [TestMethod]
        public void ClientTest()
        {
            Assert.ThrowsException<Exception>(() =>
                new Client("news.dotsrc.org", 119, "lpnielsen@hotmail.com", "wrongPass"));
        }

        [TestMethod]
        public void ListGroupsTest()
        {
            var client = new Client("news.dotsrc.org", 119, "j2.00ghz@gmail.com", "209742");
            var groups = client.ListGroups();
            Assert.IsNotNull(groups);
            foreach (var group in groups)
                Assert.IsNotNull(group.Name);
        }
    }
}