﻿using ProjekatTVP2.Models;
using ProjekatTVP2.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatTVP2.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomeView : Page
    {
        public HomeView()
        {
            this.InitializeComponent();
            this.DataContext = new HomeViewModel();
            Window.Current.SizeChanged += (sender, args) =>
            {
                OptimizeLook(sender, null);
            };
        }

        //page resize
        private void OptimizeLook(object sender, SizeChangedEventArgs e)
        {
            ItemsWrapGrid appItemsPanel = (ItemsWrapGrid)NewsList.ItemsPanelRoot;
            if(appItemsPanel != null)
            {
                double screenWidth = Window.Current.Bounds.Width;
                //privremeno...
                if (screenWidth >= 1500)
                {
                    appItemsPanel.ItemWidth = screenWidth / 4 - 30;
                }
                else if (screenWidth >= 1100)
                {
                    appItemsPanel.ItemWidth = screenWidth / 3 - 40;
                }
                else if (screenWidth >= 700)
                {
                    appItemsPanel.ItemWidth = screenWidth / 2 - 80;
                }
                else
                {
                    appItemsPanel.ItemWidth = screenWidth - 60;
                }
                //double moduo300 = Math.Round((screenWidth - 700) / 300);
                //appItemsPanel.ItemWidth = (screenWidth / (moduo300 + 2)) - (60 - 10 * moduo300);
            }
        }

        //layout updated
        private void GridLoaded(object sender, object e)
        {
            OptimizeLook(sender, null);
        }

        //kliknut gridview item
        private void ItemClicked(object sender, ItemClickEventArgs e)
        {
            //((HomeViewModel)this.DataContext).CurrentNews = (KurirNews)((GridView)sender).SelectedItem;
            //((HomeViewModel)this.DataContext).CurrentNews = (KurirNews)NewsList.SelectedItem;
            //this.Frame.Navigate(typeof(VestView), ((HomeViewModel)this.DataContext).CurrentNews);
        }

        private void ItemSelected(object sender, SelectionChangedEventArgs e)
        {
            //((HomeViewModel)this.DataContext).CurrentNews = (KurirNews)NewsList.SelectedItem;
            //this.Frame?.Navigate(typeof(VestView), ((HomeViewModel)this.DataContext).CurrentNews);
            int newsType = (int)NewsType.News;
            MainViewModel.Instance.CurrentNews = (KurirNews)NewsList.SelectedItem;
            MainViewModel.Instance.Page = newsType;
        }
    }
}
