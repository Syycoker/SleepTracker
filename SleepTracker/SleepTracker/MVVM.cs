using System;
using System.Collections.Generic;
using System.Text;

namespace SleepTracker
{
    public class MVVM
    {
        TimeSpan userSpan = TimeSelect.userSelectedTimeSpan;
        public static DateTime futureDate;
        public void calc()
        {
            //add user selected time to today's time to give future time
            DateTime today = DateTime.Today;
            DateTime AlarmDate = System.DateTime.Now + userSpan;
            futureDate = AlarmDate;
        }

    }
}
