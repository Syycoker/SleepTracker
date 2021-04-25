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
        public static DateTime userSelectedDateTime;
        public TimeSelect()
        {
            InitializeComponent();    
        }

        private async void SelectTime(object sender, EventArgs e)
        {
            userSelectedTimeSpan = UserTimePicker.Time;
            userSelectedDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, userSelectedTimeSpan.Hours, userSelectedTimeSpan.Minutes, userSelectedTimeSpan.Seconds);
            userSelectedDateTime = overlapCheck(userSelectedDateTime);
            await Navigation.PushAsync(new MainPage());
        }

        private DateTime overlapCheck(DateTime overallTime)
        {
            if (overallTime <= DateTime.Now)
            {
                return new DateTime(overallTime.Year, overallTime.Month, overallTime.Day + 1, overallTime.Hour, overallTime.Minute, overallTime.Second);
            }
            else
                return overallTime;
        }
    }
}