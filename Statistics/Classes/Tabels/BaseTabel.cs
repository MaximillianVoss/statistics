using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

namespace Statistics.Classes.Tabels
{
    public class BaseTabel
    {
        #region Fields
        public String name { set; get; }
        public StatistikTabel statistikTabel { set; get; }
        public Control htmlTabel { set; get; }
        public bool showColumnsNames { set; get; }
        #endregion
        #region Methods
        public double CalculateWorkinghours(DateTime startTime, DateTime endTime, DateTime lunchStartTime, DateTime lunchEndTime)
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
        public String GetCorrectValue(String value)
        {
            if (String.IsNullOrEmpty(value))
                return "0";
            else
                return value;
        }
        public String GetValueFromResultTable(DataTable table, string ColumnName)
        {
            if (table.Rows.Count > 0 && !String.IsNullOrEmpty(table.Rows[0]["summa"].ToString()))
            {
                return table.Rows[0]["summa"].ToString();
            }
            else
                return String.Empty;
        }
        private static Dictionary<String, String> AddValueToTabel(Dictionary<String, String> dictionary, String name, String value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                if (value == "0")
                    dictionary.Add(name, value);
                else
                    dictionary.Add(name, Convert.ToDouble(value).ToString("### ### ###.##"));
            }
            else
                dictionary.Add(name, String.Empty);
            return dictionary;
        }
        public static StatistikTabel FromatTableValues(StatistikTabel tabel)
        {
            Dictionary<String, String> result = new Dictionary<string, string>();
            foreach (var item in tabel.tabel)
            {
                result =AddValueToTabel(result, item.Key, item.Value);
            }
            tabel.tabel = result;
            return tabel;
        }
        public void Init(String _name, List<String> columnNames,bool showColumns)
        {
            name = _name;
            showColumnsNames = showColumns;
            statistikTabel = new StatistikTabel(_name, columnNames.ToArray());
        }
        #endregion
    }
}