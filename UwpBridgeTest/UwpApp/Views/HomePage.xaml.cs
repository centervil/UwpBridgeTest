using System;

using UwpApp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UwpApp.Views
{
    public sealed partial class HomePage : Page
    {
        public HomeViewModel ViewModel { get; } = new HomeViewModel();

        public HomePage()
        {
            InitializeComponent();
        }
    }
}
