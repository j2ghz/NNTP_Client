using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NNTP_Client.Models;

namespace NNTP_Client_Tests.Models
{
    [TestClass]
    public class GroupTests
    {
        [TestMethod]
        [DataRow("alt.1d 0000001252 000000459 y", "alt.1d", 1252UL, 459UL, true)]
        [DataRow("alt.0d 0000001257 000000364 y", "alt.0d", 1257UL, 364UL, true)]
        [DataRow("alt.2600 0000024553 000001183 y", "alt.2600", 24553UL, 1183UL, true)]
        public void Parse(string groupstring,string name, ulong first,ulong last,bool available)
        {
            var group = new Group(groupstring);
            Assert.AreEqual(name,group.Name);
            Assert.AreEqual(first, group.FirstArticle);
            Assert.AreEqual(last, group.LastArticle);
            Assert.AreEqual(available, group.ArticleAvailable);
        }


    }
}
