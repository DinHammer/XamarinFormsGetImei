using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsGetImei.Staff;

namespace XamarinFormsGetImei
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            DependencyService.Register<IDevice>();            

            MainPage = new MainPage();
        }

        protected override async void OnStart()
        {
            PermissionStatus permissionStatus;
            permissionStatus = await Permissions.CheckStatusAsync<Permissions.Sms>();
            if (permissionStatus != PermissionStatus.Granted)
            {                
                permissionStatus = await Permissions.RequestAsync<Permissions.Sms>();                
            }
        }
        

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
