using System;

using UwpApp.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UwpApp.Views
{
    public sealed partial class AppsPage : Page
    {
        public AppsViewModel ViewModel { get; } = new AppsViewModel();

        public AppsPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.LoadDataAsync();
        }
    }
}
