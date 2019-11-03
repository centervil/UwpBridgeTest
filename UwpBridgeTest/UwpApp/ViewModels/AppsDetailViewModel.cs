using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using UwpApp.Core.Models;
using UwpApp.Core.Services;
using UwpApp.Helpers;
using Windows.ApplicationModel;

namespace UwpApp.ViewModels
{
    public class AppsDetailViewModel : Observable
    {
        private SampleOrder _item;

        public SampleOrder Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public AppsDetailViewModel()
        {
        }

        public async Task InitializeAsync(long orderID)
        {
            var data = await SampleDataService.GetContentGridDataAsync();
            Item = data.First(i => i.OrderID == orderID);
        }

        private ICommand _launchCommand;

        public ICommand LaunchCommand => _launchCommand ?? (_launchCommand = new RelayCommand(async () => { await OnLaunchedAsync(); } ));

        public async Task OnLaunchedAsync()
        {
            await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync(Item.ExePath);
        }
    }
}
