using Statistics.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics.Interfaces
{
    interface IStatistikTabel
    {
        String name { set; get; }
        Dictionary<String, String> statistikTabel { set; get; }
        //StatistikTabel GetErastingValues(StatistikTabel tabel, string startDatum, string slutDatum);
        //StatistikTabel AddCalculateColumns(StatistikTabel tabel, DataTable table, List<string> columnsNamesToAdd);         
        StatistikTabel FillTabel(string startDatum, string slutDatum, DataTable table, List<string> columnsNamesToAdd);
    }
}
