using System;
using System.Collections.Generic;
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
        public static  void AddCalculateColumns(DataTable table,List<string> columnsNamesToAdd)
        {
            foreach (var item in columnsNamesToAdd)
                table.Columns.Add(item);
            double debitering=0, löne=0, timmar=0;
            foreach (DataRow item in table.Rows)
            {
                
                String raportStart = ConvertDate.FormatConvert(item["rapportradDatum"].ToString(), "yyyy-MM-dd") + ' ' + item["rapportradStart"].ToString();
                String raportEnd = ConvertDate.FormatConvert(item["rapportradDatum"].ToString(), "yyyy-MM-dd") + ' ' + item["rapportradSlut"].ToString();
                String lunchStart = ConvertDate.FormatConvert(item["rapportradDatum"].ToString(), "yyyy-MM-dd") + ' ' + item["rapportradLunchStart"].ToString();
                String lunchEnd = ConvertDate.FormatConvert(item["rapportradDatum"].ToString(), "yyyy-MM-dd") + ' ' + item["rapportradLunchSlut"].ToString();
                double hours = CalculateWorkinghours(ConvertDate.ConvertDayTime(raportStart), ConvertDate.ConvertDayTime(raportEnd),
                    ConvertDate.ConvertDayTime(lunchStart), ConvertDate.ConvertDayTime(lunchEnd));
                item["Hours"] = hours.ToString();
                item["Debitering bemanning"] = Convert.ToDouble(item["rapportradDebitering"]) * hours;
                item["Löne och UK kostnader"] = Convert.ToDouble(item["rapportradLonegrund"]) * hours;
                item["Arbetade timmar"] = new TimeSpan(
                    (Convert.ToDateTime(raportEnd) - Convert.ToDateTime(raportStart)).Ticks -
                    (Convert.ToDateTime(lunchEnd) - Convert.ToDateTime(lunchStart)).Ticks).TotalHours;
                //item["Timmar odebiterade"] = ;
                //item["Arbetade timmar"] = ;
                debitering += Convert.ToDouble(item["Debitering bemanning"].ToString());
                löne += Convert.ToDouble(item["Löne och UK kostnader"].ToString());
                timmar += Convert.ToDouble(item["Arbetade timmar"].ToString());
            }
            Common.statistikTabel["Debitering bemanning"] = debitering.ToString();
            Common.statistikTabel["Löne och UK kostnader"] = löne.ToString();
            Common.statistikTabel["Arbetade timmar"] = timmar.ToString();
        }
    }
}