using ProjekatTVP2.Factories;
using ProjekatTVP2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTVP2.ViewModels
{
    public class VestiViewModel : INotifyPropertyChanged
    {
        private string _pageName;
        private bool _isLoadingData;
        private KurirNewsRssFactory _factory;
        private ObservableCollection<KurirNews> _news;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public VestiViewModel(string pageName)
        {
            IsLoadingData = true;
            _pageName = pageName;
            _factory = new KurirNewsRssFactory();
            LoadData();
        }

        private async void LoadData()
        {
            NewsType newsType = (NewsType)Enum.Parse(typeof(NewsType), _pageName);
            List<KurirNews> kurirNews = await _factory.ReadRssVesti(KurirNews.NewsTypeString[(int)newsType], newsType);
            kurirNews.Sort((x, y) => y.PublishedDateTime.CompareTo(x.PublishedDateTime));
            _news = new ObservableCollection<KurirNews>(kurirNews);
            OnPropertyChanged("News");
            IsLoadingData = false;
        }

        public string PageName { get { return _pageName; } }

        public ObservableCollection<KurirNews> News { get { return _news; } }

        public bool IsLoadingData
        {
            get { return _isLoadingData; }
            private set { _isLoadingData = value; OnPropertyChanged("IsLoadingData"); }
        }
    }
}
