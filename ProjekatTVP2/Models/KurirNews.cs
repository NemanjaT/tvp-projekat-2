using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ProjekatTVP2.Models
{
    public enum NewsType
    {
        All, Vesti, Zabava, Sport, Sex, Region, Planeta, Stars, Hronika, News
    }

    [DataContract]
    public class KurirNews : INotifyPropertyChanged
    {
        [DataMember(Name = "Id")]
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }
        [DataMember(Name = "Title")]
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged("Title"); }
        }
        [DataMember(Name = "Url")]
        private string _url;
        public string Url
        {
            get { return _url; }
            set { _url = value; OnPropertyChanged("Url"); }
        }
        [DataMember(Name = "Summary")]
        private string _summary;
        public string Summary
        {
            get { return _summary; }
            set { _summary = value; OnPropertyChanged("Summary"); }
        }
        [DataMember(Name = "PublishedDateTime")]
        private DateTime _publishedDatetime;
        public DateTime PublishedDateTime
        {
            get { return _publishedDatetime; }
            set { _publishedDatetime = value; OnPropertyChanged("PublishedDateTime"); }
        }
        [DataMember(Name = "ImagePath")]
        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; OnPropertyChanged("ImagePath"); }
        }
        [DataMember(Name = "NewsType")]
        private NewsType _newsType;
        public string NewsType
        {
            get { return _newsType.ToString(); }
            set { _newsType = (NewsType)Enum.Parse(typeof(NewsType), value); OnPropertyChanged("NewsType"); }
        }

        [IgnoreDataMember]
        public string SummaryShort
        {
            get { return (Summary.Length > 78 ? Summary.Substring(0, 78) : Summary) + "..."; }
        }

        [IgnoreDataMember]
        public static string[] NewsTypeString =
        {
            "http://www.kurir.rs/rss/najnovije-vesti/", //NewsType.All
            "http://www.kurir.rs/rss/vesti/",           //NewsType.Vesti
            "http://www.kurir.rs/rss/zabava/",          //NewsType.Zabava
            "http://www.kurir.rs/rss/sport/",           //NewsType.Sport
            "http://www.kurir.rs/rss/sex/",             //NewsType.Sex
            "http://www.kurir.rs/rss/region/",          //NewsType.Region
            "http://www.kurir.rs/rss/planeta/",         //NewsType.Planeta
            "http://www.kurir.rs/rss/stars/",           //NewsType.Stars
            "http://www.kurir.rs/rss/crna-hronika/"     //NewsType.Hronika
        };

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
