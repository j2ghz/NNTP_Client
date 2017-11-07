using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NNTP_Client.Tests.Models
{
    [TestClass]
    public class ArticleTests
    {
        [TestMethod]
        [DataRow(@"25394   Re: Denier Thinks Hitler Was Assassinated in 1943       Hillbilly Davis <hillbilly@appalachia.com>      Sat, 7 Oct 2017 21:34:46 -0500  <MPG.34434abfa80b6358989700@news.eternal-september.org> <bd6cebbc-a
210-49f2-ba1d-52ee4e9cbbc7@googlegroups.com> <462c0adc-5cb2-410e-a8f5-131bf1dfc186@googlegroups.com> <8140375c-e211-4216-b762-b3939e620761@googlegroups.com>    2002    24      Xref: dotsrc.org alt.politics.trump
:25394", 25394, "Hillbilly Davis", "Sat, 7 Oct 2017", 25394, 2002, 24)]
        public void Article(string )
        {

        }
    }
}
