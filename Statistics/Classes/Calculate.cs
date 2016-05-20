using System;
using System.Data;

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

        public static void DateTimeToStr(string dayTime, string dateTime)
        {
            string[] time = dayTime.Split(':');
            string[] date = dayTime.Split('-');
            DateTime result = new DateTime(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]), Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), 0);
        }

        public static  void AddCalculateColumns(DataTable table)
        {
            table.Columns.Add("Hours");
            foreach (DataRow item in table.Rows)
            {
                
                string raportStart = ConvertDate.FormatConvert(item["rapportradDatum"].ToString(), "yyyy-MM-dd") + ' ' + item["rapportradStart"].ToString();
                string raportEnd = ConvertDate.FormatConvert(item["rapportradDatum"].ToString(), "yyyy-MM-dd") + ' ' + item["rapportradSlut"].ToString();
                string lunchStart = ConvertDate.FormatConvert(item["rapportradDatum"].ToString(), "yyyy-MM-dd") + ' ' + item["rapportradLunchStart"].ToString();
                string lunchEnd = ConvertDate.FormatConvert(item["rapportradDatum"].ToString(), "yyyy-MM-dd") + ' ' + item["rapportradLunchSlut"].ToString();               
                item["Hours"] = CalculateWorkinghours(ConvertDate.ConvertDayTime(raportStart), ConvertDate.ConvertDayTime(raportEnd),
                    ConvertDate.ConvertDayTime(lunchStart), ConvertDate.ConvertDayTime(lunchEnd)).ToString();
            }
        }
    }
}