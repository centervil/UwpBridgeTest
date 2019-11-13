using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using UwpApp.Core.Models;
using UwpApp.Core.Services;
using UwpApp.Helpers;
using Windows.ApplicationModel;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;

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
        private ICommand _sendCommand;
        private AppServiceConnection _appServiceConnection;
        private string sendResult = "initial";

        public ICommand LaunchCommand => _launchCommand ?? (_launchCommand = new RelayCommand(async () => {
            await OnLaunchedAsync();
            await OnSendCommanAsync();
        }));
        public ICommand SendCommand => _sendCommand ?? (_sendCommand = new RelayCommand(async () => { await OnSendCommanAsync(); }));


        public async Task OnLaunchedAsync()
        {
            await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync(Item.ExePath);
        }

        private async Task OnSendCommanAsync()
        {
            if (_appServiceConnection == null)
            {
                _appServiceConnection = new AppServiceConnection
                {
                    AppServiceName = "InProcessAppService",
                    PackageFamilyName = Package.Current.Id.FamilyName
                };
                var r = await _appServiceConnection.OpenAsync();
                if (r != AppServiceConnectionStatus.Success)
                {
                    Debug.WriteLine("Failed: {r}");
                    _appServiceConnection = null;
                    return;
                }
            }

            var res = await _appServiceConnection.SendMessageAsync(new ValueSet
            {
                ["Input"] = "AppServiceTest",
                ["Now"] = DateTime.Now.ToString()
            });

            //var s = res.Message["Result"] as string;
            //if (s != null)
            //{
            //    SendResult = s as string;
            //}
        }

        public string SendResult
        {
            get { return sendResult; }
            set { Set(ref sendResult, value); }
        }
    }
}
