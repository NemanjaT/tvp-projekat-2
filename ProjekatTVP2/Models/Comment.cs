using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatTVP2.Models
{
    [DataContract]
    public class Comment : IModel, INotifyPropertyChanged
    {
        [DataMember(Name = "Id")]
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }
        [DataMember(Name = "Name")]
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        [DataMember(Name = "Content")]
        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; OnPropertyChanged("Content"); }
        }
        [DataMember(Name = "PublishDate")]
        private DateTime _publishDate;
        public DateTime PublishDate
        {
            get { return _publishDate; }
            set { _publishDate = value; OnPropertyChanged("PublishDate"); }
        }
        [DataMember(Name = "NewsId")]
        private int _newsId;
        public int NewsId
        {
            get { return _newsId; }
            set { _newsId = value; OnPropertyChanged("NewsId"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
