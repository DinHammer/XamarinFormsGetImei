using System;
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

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
