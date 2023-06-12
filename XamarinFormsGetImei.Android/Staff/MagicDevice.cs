using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamarinFormsGetImei.Droid.Staff;
using XamarinFormsGetImei.Models;
using XamarinFormsGetImei.Staff;
using static Android.Provider.Settings;

[assembly: Xamarin.Forms.Dependency(typeof(MagicDevice))]
namespace XamarinFormsGetImei.Droid.Staff
{
    public class MagicDevice : IDevice
    {        

        public RequestResult<string> GetAndroidId()
        {
            string output = string.Empty;
            try
            {
                output = Settings.Secure.GetString(Android.App.Application.Context.ContentResolver, Settings.Secure.AndroidId);
                return new RequestResult<string>(output, RequestStatus.Ok);
            }
            catch (Exception ex)
            {
                return new RequestResult<string>(output, RequestStatus.SomethingWrong, ex);
            }
        }
        
        public RequestResult<string> GetImei()
        {
            string output = string.Empty;
            try
            {
                TelephonyManager manager = (TelephonyManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.TelephonyService);
                output = manager.GetImei(0);
                
                return new RequestResult<string>(output, RequestStatus.Ok);
            }
            catch (Exception ex)
            {
                return new RequestResult<string>(output, RequestStatus.SomethingWrong, ex);
            }
        }

        
    }
}