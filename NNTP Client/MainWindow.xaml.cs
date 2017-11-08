using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace NNTP_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        MainWindowViewModel VM = new MainWindowViewModel();
        public MainWindow()
        {
            this.DataContext = VM;
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VM.Articles.Clear();
            foreach (var artice in VM.client.ListArticles(VM.GroupSelected))
            {
                VM.Articles.Add(artice);
            }
        }

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (VM.ArticleSelected == null) return;
            if (VM.GroupSelected == null) return;
            VM.FullArticle = VM.client.RetriveArticle(VM.ArticleSelected.ID, VM.GroupSelected);
        }
    }
}
