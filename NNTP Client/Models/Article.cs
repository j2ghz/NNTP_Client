using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NNTP_Client.Models
{
    class Article
    {
        public Article(string data)
        {
            var indexOfSpace = data.IndexOf(' ');
            ID = ulong.Parse(data.Substring(0, indexOfSpace));
            var skip = data.Substring(indexOfSpace + 1);
            var dataArr = skip.Split('\t');
            Subject = dataArr[0];
            From = dataArr[1];
            Date = dataArr[2];
            ArticleID = ulong.Parse(dataArr[3]);
            Size = uint.Parse(dataArr[4]);
            Lines = uint.Parse(dataArr[5]);
        }

        public ulong ID { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }
        public string Date { get; set; }
        public ulong ArticleID { get; set; }
        public uint Size { get; set; }
        public uint Lines { get; set; }
        ```````
    }

    
}
