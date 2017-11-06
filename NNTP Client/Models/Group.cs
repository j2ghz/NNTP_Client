namespace NNTP_Client.Models
{
    public class Group
    {
        public Group(string data)
        {
            var dataArr = data.Split(' ');
            Name = dataArr[0];
            FirstArticle =ulong.Parse(dataArr[1]);
            LastArticle = ulong.Parse(dataArr[2]);
            ArticleAvailable =  dataArr[3] == "y";
        }

        public string Name { get; private set; }
        public ulong FirstArticle { get; private set; }
        public ulong LastArticle { get; private set; }
        public bool ArticleAvailable { get; private set; }
    }
}