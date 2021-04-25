using System;
using Microcharts;
using SkiaSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SleepTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChartPage : ContentPage
    {
        public DateTime TimesleptVar;
        public DateTime TimewokeVar;
        //Hello Sylas welcome to the test demo of the user input and charting portion. This is an idea of how we can do it but obvsiouly the rest is in your capable hands

        private ChartEntry[] entries = new[] //chart entries are in a array , //User input can be done with an array - change array into non read only
        {
            //you would need to have Microcharts and Microcharts form
            //So label is the date
            //valuelabel is the amount of hours sleep the user got
            //colour is only determined by hex values
            //https://www.youtube.com/watch?v=tLDxMKub5WA check this quick video out


            new ChartEntry((float)6.38) //In C# can calculate time between two datetimes using TimeSpan ts = date2-date1 and then ts.TotalHours and convert to float
            {
                Label = "23/04/2021", //label is date
                ValueLabel = "23/04/2021", //valuelable is date of sleep
                Color = SKColor.Parse("#90ee90") //colour is in hex
            },
            new ChartEntry((float)5.3)
            {
                Label = "24/04/2021",
                ValueLabel = "24/04/2021",
                Color = SKColor.Parse("#FF00FF")
            }
        };
        public ChartPage()
        {
            InitializeComponent();
            ChartView.Chart = new BarChart { Entries = entries };
        }

        void SleepButton_Clicked(object sender, EventArgs e) //button to start tracking sleep
        {
            TimesleptVar = DateTime.Now;
            DisplayAlert("Press Ok", "Sleep tracking has started", "OK");
        }

        void Button_Clicked(object sender, EventArgs e) //button to stop tracking sleep
        {
            TimewokeVar = DateTime.Now; //hopefully different 
            DisplayAlert("Press Ok", "Sleep tracking has ended", "OK");
            TimeSpan ts = TimewokeVar - TimesleptVar; //gets difference between two date times
            var hours = ts.TotalHours; //convert this shit to hours 
            ChartEntry chartEntry = new ChartEntry((float)hours);
            chartEntry.Label = TimewokeVar.Date.ToString();
            chartEntry.ValueLabel = TimewokeVar.Date.ToString();
            chartEntry.Color = SKColor.Parse("#FF00FF"); //COULD MAKE TWO DIFFERENT COLOURS FOR POOR OR GOOD SLEEP
            Array.Resize(ref entries, entries.Length + 1); //incrases array one size biggers
            entries[entries.Length - 1] = chartEntry;

        }
    }
}