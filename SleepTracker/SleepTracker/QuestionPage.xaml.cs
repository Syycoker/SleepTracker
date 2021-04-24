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
    public partial class QuestionPage : ContentPage
    {
        public QuestionPage()
        {
            InitializeComponent();
        }

        private async void OnClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage(NameEntry.Text, Int32.Parse(AgeEntry.Text), Int32.Parse(SleepHrs.Text)));
        }
    }
}