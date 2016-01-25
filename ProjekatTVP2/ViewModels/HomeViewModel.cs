using ProjekatTVP2.Factories;
using ProjekatTVP2.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ProjekatTVP2.ViewModels
{
    class HomeViewModel : INotifyPropertyChanged
    {
        private KurirNewsRssFactory _newsFactory;
        private CommentFactory _commentFactory;
        private ObservableCollection<KurirNews> _news;
        private ObservableCollection<Comment> _comments;
        private KurirNews _currentNews;

        public HomeViewModel()
        {
            IsLoadingData = true;
            _news = new ObservableCollection<KurirNews>();
            _comments = new ObservableCollection<Comment>();
            _newsFactory = new KurirNewsRssFactory();
            _commentFactory = new CommentFactory();
            InitializeData();
        }

        public async void InitializeData()
        {
            List<KurirNews> kurirNews = await _newsFactory.ReadRssVesti("http://www.kurir.rs/rss/najvaznije-vesti/", NewsType.Vesti);
            kurirNews.Sort((x, y) => y.PublishedDateTime.CompareTo(x.PublishedDateTime));
            _news = new ObservableCollection<KurirNews>(kurirNews);
            List<Comment> comments = await _commentFactory.LoadAllComments();
            comments.Sort((x, y) => y.PublishDate.CompareTo(x.PublishDate));
            _comments = new ObservableCollection<Comment>(comments);
            IsLoadingData = false;
            OnPropertyChanged("News");
            OnPropertyChanged("LatestNews");
            OnPropertyChanged("IsLoadingData");
        }

        public ObservableCollection<KurirNews> News { get { return _news; } }
        
        public KurirNews CurrentNews
        {
            get { return _currentNews; }
            set
            {
                _currentNews = value;
                OnPropertyChanged("CurrentNews");
            }
        }

        public ObservableCollection<Comment> LastComments
        {
            get
            {
                return new ObservableCollection<Comment>(new List<Comment>(_comments).GetRange(0, _comments.Count > 5 ? 5 : _comments.Count));
            }
        }

        public ObservableCollection<Comment> Comments
        {
            get { return _comments; }
        }

        public bool IsLoadingData { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
