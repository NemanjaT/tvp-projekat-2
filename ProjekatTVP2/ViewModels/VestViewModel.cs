using ProjekatTVP2.Factories;
using ProjekatTVP2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ProjekatTVP2.ViewModels
{
    class VestViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Comment> _comments;
        private CommentFactory _commentFactory;

        private string _commentName;
        private string _commentContent;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public VestViewModel()
        {
            _commentFactory = new CommentFactory();
            LoadComments();
        }

        private async void LoadComments()
        {
            //List<Comment> comments = await _commentFactory.LoadAllComments();
            //comments = comments.FindAll(x => x.NewsId == MainViewModel.Instance.CurrentNews.Id);
            _comments = new ObservableCollection<Comment>(((List<Comment>)await _commentFactory.LoadAllComments())
                .FindAll(x => x.NewsId == MainViewModel.Instance.CurrentNews.Id));
            OnPropertyChanged("Comments");
        }

        public KurirNews News
        {
            get { return MainViewModel.Instance.CurrentNews; }
        }

        public void WriteComment()
        {
            Comment com = new Comment()
            {
                Content = _commentContent,
                Name = _commentName,
                Id = 2561,
                NewsId = MainViewModel.Instance.CurrentNews.Id,
                PublishDate = DateTime.Now
            };
            Comments.Add(com);
            _commentFactory.WriteComment(com);
        }

        public ObservableCollection<Comment> Comments
        {
            get { return _comments; }
        }

        public string CommentName
        {
            get { return _commentName; }
            set
            {
                _commentName = value;
                OnPropertyChanged("CommentName");
            }
        }

        public string CommentContent
        {
            get { return _commentContent; }
            set
            {
                _commentContent = value;
                OnPropertyChanged("CommentContent");
            }
        }
    }
}
