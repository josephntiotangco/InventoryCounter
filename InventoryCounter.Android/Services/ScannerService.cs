using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ZXing.Mobile;
using Xamarin.Forms;
using System.Threading.Tasks;
using InventoryCounter.Services;

[assembly: Dependency(typeof(InventoryCounter.Droid.Services.ScannerService))]
namespace InventoryCounter.Droid.Services
{
    public class ScannerService : IScanner
    {
        public Task<string> ScanAsync()
        {
            return Task.Run(() =>
            {
                return Scan();
            });
        }
        public string Scan()
        {
            var optionsDefault = new MobileBarcodeScanningOptions();
            var options = new MobileBarcodeScanningOptions();

            var scanner = new MobileBarcodeScanner()
            {
                TopText = "scan barcode now",
                BottomText = "please wait",
            };

            var xzing_result = scanner.Scan(options);

            string result = xzing_result.Result.Text;

            return result;
        }
    }
}