using System;

namespace Statistics.Classes
{
    public static class Calculate
    {
        public  static double CalculateWorkinghours(DateTime startTime, DateTime endTime, DateTime lunchStartTime, DateTime lunchEndTime)
        {
            TimeSpan ts;
            TimeSpan tsLunch;
            if (endTime > startTime)
            {
                ts = endTime - startTime;
            }
            else
            {
                var endTime2 = endTime;
                endTime2 = endTime2.AddDays(1);


                ts = (endTime2 - startTime);
            }


            if (lunchEndTime > lunchStartTime)
            {
                tsLunch = lunchEndTime - lunchStartTime;
            }
            else
            {
                var lunchEndTime2 = lunchEndTime;
                lunchEndTime2 = lunchEndTime2.AddDays(1);


                tsLunch = (lunchEndTime2 - lunchStartTime);
            }


            if (lunchStartTime != lunchEndTime)
            {
                ts = ts - tsLunch;
            }


            var hours = ts.TotalHours;


            return hours;
        }
    }
}