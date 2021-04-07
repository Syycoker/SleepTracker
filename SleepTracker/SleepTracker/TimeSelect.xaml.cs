using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SleepTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeSelect : ContentPage
    {
        public static TimeSpan userSelectedTimeSpan;
        
        public TimeSelect()
        {
            InitializeComponent();
        }

        private async void SelectTime(object sender, EventArgs e)
        {
            userSelectedTimeSpan = UserTimePicker.Time;
            await Navigation.PushAsync(new MainPage());
        }
    }
}