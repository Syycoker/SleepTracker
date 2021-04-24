using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("SEGOEUI.ttf", Alias = "RegularFont")]
[assembly: ExportFont("SEGOEUIL.ttf", Alias = "LightFont")]
[assembly: ExportFont("SEGUISB.ttf", Alias = "MediumFont")]

namespace SleepTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
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
