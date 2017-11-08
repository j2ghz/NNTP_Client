using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NNTP_Client.Annotations;
using NNTP_Client.Models;

namespace NNTP_Client
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Article articleSelectedArticle;
        public Client client = new Client("news.dotsrc.org", 119, "j2.00ghz@gmail.com", "209742");
        private string groupSelected;
        private ArticleFull fullArticle;

        public ArticleFull FullArticle
        {
            get { return fullArticle; }
            set { fullArticle = value;OnPropertyChanged(); }
        }


        public MainWindowViewModel()
        {
            foreach (var group in client.ListGroups())
                Groups.Add(group);


        }

        public ObservableCollection<string> Groups { get; } = new ObservableCollection<string>();
        public ObservableCollection<Article> Articles { get; } = new ObservableCollection<Article>();

        public Article ArticleSelected
        {
            get => articleSelectedArticle;
            set
            {
                articleSelectedArticle = value;
                OnPropertyChanged();
            }
        }

        public string GroupSelected
        {
            get => groupSelected;
            set
            {
                groupSelected = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}