namespace NNTP_Client.Models
{
    public class Article
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
        }

        public ulong ID { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }
        public string Date { get; set; }
    }
}