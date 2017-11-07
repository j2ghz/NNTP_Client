using Microsoft.VisualStudio.TestTools.UnitTesting;
using NNTP_Client.Models;

namespace NNTP_Client.Tests.Models
{
    [TestClass]
    public class ArticleTests
    {
        [TestMethod]
        [DataRow(
            "25394 Re: Denier Thinks Hitler Was Assassinated in 1943\tHillbilly Davis <hillbilly@appalachia.com>\tSat, 7 Oct 2017 21:34:46 -0500\t<MPG.34434abfa80b6358989700@news.eternal-september.org>\t<bd6cebbc-a210 -49f2-ba1d-52ee4e9cbbc7@googlegroups.com>\t<462c0adc-5cb2-410e-a8f5-131bf1dfc186@googlegroups.com>\t<8140375c-e211-4216-b762-b3939e620761@googlegroups.com>\t2002\t24\tXref: dotsrc.org alt.politics.trump:25394",
            25394UL, "Re: Denier Thinks Hitler Was Assassinated in 1943", "Hillbilly Davis <hillbilly@appalachia.com>",
            "Sat, 7 Oct 2017 21:34:46 -0500")]
        public void Article(string articleString, ulong id, string subject, string author, string date)
        {
            var article = new Article(articleString);
            Assert.AreEqual(id, article.ID);
            Assert.AreEqual(subject, article.Subject);
            Assert.AreEqual(author, article.From);
            Assert.AreEqual(date, article.Date);
        }
    }
}