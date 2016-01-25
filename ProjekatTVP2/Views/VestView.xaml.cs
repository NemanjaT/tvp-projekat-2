using ProjekatTVP2.Models;
using ProjekatTVP2.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatTVP2.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VestView : Page
    {
        public VestView()
        {
            this.InitializeComponent();
            this.DataContext = new VestViewModel();
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    this.DataContext = new VestViewModel();
        //}

        private void GoBack(object sender, RoutedEventArgs e)
        {
            MainViewModel.Instance.Page = MainViewModel.Instance.LastPage;
        }

        private void SendComment(object sender, RoutedEventArgs e)
        {
            ((VestViewModel)this.DataContext).WriteComment();
        }
        
    }
}
