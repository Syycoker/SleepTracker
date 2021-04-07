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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        /*
        private async void GoToQuestionsPage(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new QuestionsPage());
        }
        */
    }
}