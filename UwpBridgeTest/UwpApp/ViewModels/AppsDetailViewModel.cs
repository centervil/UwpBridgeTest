using System;
using System.Linq;
using System.Threading.Tasks;

using UwpApp.Core.Models;
using UwpApp.Core.Services;
using UwpApp.Helpers;

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
    }
}
