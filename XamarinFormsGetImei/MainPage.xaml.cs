using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinFormsGetImei.Staff;
using Plugin.Messaging;
using Newtonsoft.Json;

namespace XamarinFormsGetImei
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();            

        }

        

        private async void Send_Clicked(object sender, EventArgs e)
        {            
            string phone = "+7916xxx";
            
            var smsMessage = CrossMessaging.Current.SmsMessenger;

            bool isCanSend = smsMessage.CanSendSmsInBackground;
            if (isCanSend == false)
            {
                PermissionStatus permissionStatus = await Permissions.RequestAsync<Permissions.Sms>();
                if (permissionStatus != PermissionStatus.Granted)
                {
                    ShowErrorMessage();
                    return;
                }
            }

            var vAndroidId = DependencyService.Get<IDevice>().GetAndroidId();
            if (vAndroidId.IsValid == false)
            { 
                ShowErrorMessage(); 
                return;
            }
            
            try
            {
                string message = JsonConvert.SerializeObject(vAndroidId.Data);
                smsMessage.SendSmsInBackground(phone, message);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                ShowErrorMessage();
            }            

        }

        private void ShowErrorMessage()
        {
            //ErrorMessage
        }
    }
}
