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

using InventoryCounter.Droid.Services;
using InventoryCounter.Services;
using Xamarin.Forms;
using Android.Telephony;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceService))]
namespace InventoryCounter.Droid.Services
{
    public class DeviceService : IDeviceID
    {
        public string GetId()
        {
            string deviceId;
            var deviceContext = Android.App.Application.Context;
            TelephonyManager mTelephonyMgr = (TelephonyManager)deviceContext.GetSystemService(Android.Content.Context.TelephonyService);

            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Q)
            {
                deviceId = Android.Provider.Settings.Secure.GetString(deviceContext.ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            }
            else
            {
                deviceId = mTelephonyMgr.GetImei(0).ToString();
            }

            return deviceId;
        }
    }
}