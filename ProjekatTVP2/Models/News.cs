using ProjekatTVP2.Factories;
using ProjekatTVP2.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTVP2.Models
{
    [DataContract]
    public enum TipVesti
    {
        Sve, Vesti, Sport, Zabava, Svet, Hronika
    }

    [DataContract]
    public class News : IModel, INotifyPropertyChanged
    {
        [DataMember(Name = "Id")]
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }
        [DataMember(Name = "Headline")]
        private string _headline;
        public string Headline
        {
            get { return _headline; }
            set { _headline = value; OnPropertyChanged("Headline"); }
        }
        [DataMember(Name = "Author")]
        private string _author;
        public string Author
        {
            get { return _author; }
            set { _author = value; OnPropertyChanged("Author"); }
        }
        [DataMember(Name = "NewsType")]
        private TipVesti _newsType;
        public TipVesti NewsType
        {
            get { return _newsType; }
            set { _newsType = value; OnPropertyChanged("NewsType"); }
        }
        [DataMember(Name = "ImagePath")]
        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; OnPropertyChanged("ImagePath"); }
        }
        [DataMember(Name = "PublishDate")]
        private DateTime _publishDate;
        public DateTime PublishDate
        {
            get { return _publishDate; }
            set { _publishDate = value; OnPropertyChanged("PublishDate"); }
        }
        [DataMember(Name = "Article")]
        private string _article;
        public string Article
        {
            get { return _article; }
            set { _article = value; OnPropertyChanged("Article"); }
        }

        [IgnoreDataMember]
        public string ArticleShort { get { return (Article.Length > 87 ? Article.Substring(0, 87) : Article) + "..."; } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class NewsFactory
    {
        private FileFactory _factory;

        public NewsFactory()
        {
            _factory = new FileFactory();
        }

        public async Task<ObservableCollection<News>> LoadAll()
        {
            ObservableCollection<News> NewsList = new ObservableCollection<News>();
            News tempNews = new News();
            int i = 0;
            while ((tempNews = await _factory.Read<News>("News-" + i + ".xml")) != null)
            {
                NewsList.Add(tempNews);
                i++;
            }
            return new ObservableCollection<News>(NewsList.OrderByDescending(x => x.PublishDate));
        }
    }
}
