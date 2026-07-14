using System;
using System.Collections.Generic;

namespace Statistics.Classes
{
    public class StatistikTabel
    {
        #region Fields
        public String name { set; get; }
        public Dictionary<String, String> tabel = new Dictionary<String, String>();
        public bool showColumns { set; get; }
        //{
        //    //{"Arbetare","" },
        //    { "Intäkter och kostnader",""},
        //    { "Debitering bemanning",""},
        //    { "Löne och UK kostnader",""},
        //    { "Timmar",""},
        //    { "Arbetade timmar",""},
        //    { "Timmar odebiterade",""},
        //    { "Timmar totalt",""},
        //    { "Ersättning",""},
        //    { "Utlägg",""},
        //    { "Milersättning",""},
        //    { "Traktamente",""},
        //    { "Summa",""}
        //};
        #endregion
        #region Public methods
        public StatistikTabel(String _name,params String[] columnsNames)
        {
            //statistikTabel.Add(name, String.Empty);
            foreach (var item in columnsNames)
                tabel.Add(item, String.Empty);
            name = _name;
        }
        public void AddValue(String columnName, object value)
        {
            if (tabel.ContainsKey(columnName))
                tabel[columnName] = value.ToString();
            else
                tabel.Add(columnName, value.ToString());
        }
        public String GetValue(String columnName)
        {
            if (tabel.ContainsKey(columnName))
                return (String)tabel[columnName];
            else
                return String.Empty;
        }
        #endregion
        #region Construstors
        public StatistikTabel(List<String> ColumnNames)
        {
            if (ColumnNames != null)
                foreach (var item in ColumnNames)
                    tabel.Add(item, String.Empty);
        }
        #endregion
    }
}