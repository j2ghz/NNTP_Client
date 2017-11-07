using System;

namespace NNTP_Client.Models
{
    public class Group
    {
        public Group(string data)
        {
            var dataArr = data.Split(' ');
            Name = dataArr[4];
            FirstArticle =ulong.Parse(dataArr[2]);
            LastArticle = ulong.Parse(dataArr[3]);
            NumberOfArticles =  ulong.Parse(dataArr[1]);
        }

        public string Name { get; private set; }
        public ulong FirstArticle { get; private set; }
        public ulong LastArticle { get; private set; }
        public ulong NumberOfArticles { get; private set; }
    }
}