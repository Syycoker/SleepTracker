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
    public partial class HomePage : ContentPage
    {
        public HomePage(String name, int age, int sleepHrs)
        {
            InitializeComponent();
            title.Text = "Welcome " + name;
        }

        private void OnButton1Clicked(object sender, EventArgs args)
        {
            button1.IsVisible = false;
            button2.IsVisible = false;
            button3.IsVisible = false;
            label2.Text = "You chose " + button1.Text;
            title.Text = "Your recent mood graph:";
        }

        private void OnButton2Clicked(object sender, EventArgs args)
        {
            button1.IsVisible = false;
            button2.IsVisible = false;
            button3.IsVisible = false;
            label2.Text = "You chose " + button2.Text;
            title.Text = "Your recent mood graph:";
        }

        private void OnButton3Clicked(object sender, EventArgs args)
        {
            button3.IsVisible = false;
            button2.IsVisible = false;
            button1.IsVisible = false;
            label2.Text = "You chose " + button3.Text;
            title.Text = "Your recent mood graph:";
        }
    }
}