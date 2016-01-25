using ProjekatTVP2.Models;
using ProjekatTVP2.ViewModels.Commands;
using ProjekatTVP2.Views;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace ProjekatTVP2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        private bool _paneOpen;
        private NewsType _lastPage;
        private NewsType _page;
        private KurirNews _currentNews;

        private static MainViewModel _instance;
        
        private MainViewModel()
        {
            PaneOpen = false;
        }

        #region getters/setters
        public static MainViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainViewModel();
                return _instance;
            }
        }

        public bool PaneOpen
        {
            get { return _paneOpen; }
            set
            {
                _paneOpen = value;
                OnPropertyChanged("PaneOpen");
            }
        }

        public int Page
        {
            get { return (int)_page; }
            set
            {
                _lastPage = _page;
                if (value >= 0 && value < Enum.GetNames(typeof(NewsType)).Length)
                    _page = (NewsType)value;
                else
                    _page = NewsType.All;
                //OnPropertyChanged("Page");
                OnPropertyChanged("PageName");
                OnPropertyChanged("CurrentPage");
            }
        }

        public int LastPage
        {
            get { return (int)_lastPage; }
        }

        public string PageName
        {
            get
            {
                switch (_page)
                {
                    case NewsType.All:
                        return "Početna";
                    case NewsType.News:
                        return "Vest";
                    default:
                        return _page.ToString();
                }
            }
        }

        public Type PageViewName
        {
            get
            {
                switch (_page)
                {
                    case NewsType.All:
                        return typeof(HomeView);
                    case NewsType.News:
                        return typeof(VestView);
                    default:
                        return typeof(VestiView);
                }
            }
        }

        public Page CurrentPage
        {
            get
            {
                if (_page == NewsType.All)
                    return new HomeView();
                else if (_page == NewsType.News)
                    return new VestView();
                else
                    return new VestiView(PageName);
            }
        }

        public KurirNews CurrentNews { get { return _currentNews; } set { _currentNews = value; OnPropertyChanged("CurrentNews"); } }

        public ICommand ChangePaneOpen
        {
            get { return new SimpleCommand(() => { PaneOpen = !PaneOpen; }); }
        }
        #endregion
    }
}
