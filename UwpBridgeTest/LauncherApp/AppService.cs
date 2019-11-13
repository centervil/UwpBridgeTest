using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.AppService;

namespace LauncherApp
{
    class AppService : Observable
    {
        private AppServiceConnection _appServiceConnection;
        private string receivedStr;

        public string ReceivedStr
        {
            get { return receivedStr; }
            set { Set(ref receivedStr, value); }
        }

        public AppService()
        {
            Task.Run(async () =>
            {
                await ConnectAsync();
            });
        }

        private async Task<bool> ConnectAsync()
        {
            if (_appServiceConnection != null)
            {
                return true;
            }

            var appServiceConnection = new AppServiceConnection();
            appServiceConnection.AppServiceName = "InProcessAppService";
            appServiceConnection.PackageFamilyName = Package.Current.Id.FamilyName;
            appServiceConnection.RequestReceived += AppServiceConnection_RequestReceived;
            var r = await appServiceConnection.OpenAsync() == AppServiceConnectionStatus.Success;
            if (r)
            {
                _appServiceConnection = appServiceConnection;
            }

            return r;
        }

        private void AppServiceConnection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            receivedStr = (string)args.Request.Message["Now"];
        }
    }
}
