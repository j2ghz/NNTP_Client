namespace NNTP_Client.Models
{
    public class Article
    {
        public Article(string data)
        {
            var dataArr = data.Split('\t');
            ID = ulong.Parse(dataArr[0]);
            Subject = dataArr[1];
            From = dataArr[2];
            Date = dataArr[3];
        }

        public ulong ID { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }
        public string Date { get; set; }
    }
}