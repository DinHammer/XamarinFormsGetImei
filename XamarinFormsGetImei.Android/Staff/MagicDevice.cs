using Android.App;
using Android.Content;
using Android.Icu.Util;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamarinFormsGetImei.Droid.Staff;
using XamarinFormsGetImei.Models;
using XamarinFormsGetImei.Staff;
using static Android.Provider.Settings;
using Settings = Android.Provider.Settings;

[assembly: Xamarin.Forms.Dependency(typeof(MagicDevice))]
namespace XamarinFormsGetImei.Droid.Staff
{
    public class MagicDevice : IDevice
    {                

        public RequestResult<MdlAndroidIdentificator> GetAndroidId()
        {
            string output = string.Empty;

            try
            {                
                BuildVersionCodes buildVersionCodes = Build.VERSION.SdkInt;

                if (buildVersionCodes >= BuildVersionCodes.Q)
                {
                    //android_id
                    output = Settings.Secure.GetString(Android.App.Application.Context.ContentResolver, Settings.Secure.AndroidId);
                    return new RequestResult<MdlAndroidIdentificator>(new MdlAndroidIdentificator(Constants.TypeAndroidId.android_id, output), RequestStatus.Ok);
                }
                else
                {
                    //imei
                    TelephonyManager manager = (TelephonyManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.TelephonyService);
                    output = manager.GetImei(0);

                    return new RequestResult<MdlAndroidIdentificator>(new MdlAndroidIdentificator(Constants.TypeAndroidId.imei, output), RequestStatus.Ok);
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<MdlAndroidIdentificator>(null, RequestStatus.SomethingWrong, ex);
            }
        }                

    }
}