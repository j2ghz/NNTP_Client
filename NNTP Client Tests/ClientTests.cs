using NNTP_Client;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NNTP_Client.Tests
{
    [TestClass]
    public class ClientTests
    {
        private readonly Client client;
        public ClientTests()
        {
            client = new Client("news.dotsrc.org", 119, "j2.00ghz@gmail.com", "209742");
        }
        [TestMethod]
        public void ClientLoginTest()
        {
            Assert.IsNotNull(client);
        }

        [TestMethod]
        public static void ClientTest()
        {
            Assert.ThrowsException<Exception>(() =>
                new Client("news.dotsrc.org", 119, "lpnielsen@hotmail.com", "wrongPass"));
        }

        [TestMethod]
        public void ListGroupsTest()
        {
            var groups = client.ListGroups();
            Assert.IsNotNull(groups);
            foreach (var group in groups)
                Assert.IsFalse(string.IsNullOrWhiteSpace(group));
        }

        [TestMethod]
        public void ChangeGroupTest()
        {
            client.ChangeGroup("alt.politics.trump");
        }
    }
}