using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace SleepTracker
{
    internal class MainPageViewModel : INotifyPropertyChanged
    {
        private double height = 180;
        private double weight = 70;
        private const double STEP = 1.0;

        public double Height
        {
            get => height;
            set
            {
                height = NextStep(value);
                UpdateResults();
            }
        }

        public double Weight
        {
            get => weight;
            set
            {
                weight = NextStep(value);
                UpdateResults();
            }
        }

        public double Bmi
            => Math.Round(Weight / Math.Pow(Height / 100, 2), 2);

        public string Classification
        {
            get
            {
                if (Bmi < 18.5) return "You are underweight - Recommended 8 hours sleep";
                else if (Bmi < 25) return "You have a normal weight - Recommended 7 hours sleep";
                else if (Bmi < 30) return "You are overweight - Recommended 6 hours sleep";
                else return "You are obese";
            }
        }

        private void UpdateResults()
        {
            RaisedPropertyChanged(nameof(Bmi));
            RaisedPropertyChanged(nameof(Classification));
        }

        private double NextStep(double value)
            => Math.Round(value / STEP) * STEP;

        private void RaisedPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
