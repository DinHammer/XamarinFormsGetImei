using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsGetImei.Staff;

namespace XamarinFormsGetImei
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var vImei = DependencyService.Get<IDevice>().GetImei();

            var vAndroidId = DependencyService.Get<IDevice>().GetAndroidId();

            
        }
    }
}
