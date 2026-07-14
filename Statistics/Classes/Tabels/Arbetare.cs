using Statistics.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Statistics.Classes.Tabels
{
    public class Arbetare : BaseTabel
    {
        #region Fields
        #endregion
        #region Methods
        #region private
        private StatistikTabel GetErastingValues(StatistikTabel tabel, string startDatum, string slutDatum,string type)
        {
            var UtläggQuery = String.Format(Common.Queries.UtläggQuery, 
                Query.AddDatesWithWhere(startDatum, slutDatum, Constants.QueryColumnNames.ersattningsDatum), type);
            var TraktamenteQuery = String.Format(Common.Queries.TraktamenteQuery, 
                Query.AddDatesWithWhere(startDatum, slutDatum, Constants.QueryColumnNames.ersattningsDatum), type); ;
            var MilersättningQuery = String.Format(Common.Queries.MilersättningQuery, 
                Query.AddDatesWithWhere(startDatum, slutDatum, Constants.QueryColumnNames.ersattningsDatum), type); ;

            var UtläggTabel = Calculate.GetValueFromResultTable(SQLController.GetDataTable(UtläggQuery), "summa");
            var Milersättning = Calculate.GetValueFromResultTable(SQLController.GetDataTable(MilersättningQuery), "summa");
            var Traktamente = Calculate.GetValueFromResultTable(SQLController.GetDataTable(TraktamenteQuery), "summa");

            tabel.AddValue(Constants.ColumnNames.UltaggKonstad, GetCorrectValue(UtläggTabel));
            tabel.AddValue(Constants.ColumnNames.Milersättning, GetCorrectValue(Milersättning));
            tabel.AddValue(Constants.ColumnNames.Traktamente, GetCorrectValue(Traktamente));
            tabel.AddValue(Constants.ColumnNames.SummaTotalt, (Convert.ToDouble(tabel.GetValue(Constants.ColumnNames.UltaggKonstad))
                 + Convert.ToDouble(tabel.GetValue(Constants.ColumnNames.Milersättning))
                 + Convert.ToDouble(tabel.GetValue(Constants.ColumnNames.Traktamente))));
            return tabel;
        }
        private StatistikTabel AddCalculateColumns(StatistikTabel tabel, DataTable table, List<string> columnsNamesToAdd)
        {
            foreach (var item in columnsNamesToAdd)
                table.Columns.Add(item);
            double debitering = 0, löne = 0, timmar = 0, odebiterade = 0;
            foreach (DataRow item in table.Rows)
            {
                String raportStart = ConvertDate.FormatConvert(item[Constants.QueryColumnNames.rapportradDatum].ToString(), "yyyy-MM-dd") + ' ' + item[Constants.QueryColumnNames.rapportradStart].ToString();
                String raportEnd = ConvertDate.FormatConvert(item[Constants.QueryColumnNames.rapportradDatum].ToString(), "yyyy-MM-dd") + ' ' + item[Constants.QueryColumnNames.rapportradSlut].ToString();
                String lunchStart = ConvertDate.FormatConvert(item[Constants.QueryColumnNames.rapportradDatum].ToString(), "yyyy-MM-dd") + ' ' + item[Constants.QueryColumnNames.rapportradLunchStart].ToString();
                String lunchEnd = ConvertDate.FormatConvert(item[Constants.QueryColumnNames.rapportradDatum].ToString(), "yyyy-MM-dd") + ' ' + item[Constants.QueryColumnNames.rapportradLunchSlut].ToString();
                double hours = CalculateWorkinghours(ConvertDate.ConvertDayTime(raportStart), ConvertDate.ConvertDayTime(raportEnd),
                    ConvertDate.ConvertDayTime(lunchStart), ConvertDate.ConvertDayTime(lunchEnd));
                item[Constants.ColumnNames.Hours] = hours.ToString();
                item[Constants.ColumnNames.DebiteringBemanning] = Convert.ToDouble(item[Constants.QueryColumnNames.rapportradDebitering]) * hours;
                item[Constants.ColumnNames.LöneOchUKKostnader] = Convert.ToDouble(item[Constants.QueryColumnNames.rapportradLonegrund]) * hours;
                item[Constants.ColumnNames.ArbetadeTimmar] = new TimeSpan(
                    (Convert.ToDateTime(raportEnd) - Convert.ToDateTime(raportStart)).Ticks -
                    (Convert.ToDateTime(lunchEnd) - Convert.ToDateTime(lunchStart)).Ticks).TotalHours;
                debitering += Convert.ToDouble(item[Constants.ColumnNames.DebiteringBemanning].ToString());
                löne += Convert.ToDouble(item[Constants.ColumnNames.LöneOchUKKostnader].ToString());
                timmar += Convert.ToDouble(item[Constants.ColumnNames.ArbetadeTimmar].ToString());
            }
            tabel.AddValue(Constants.ColumnNames.TimmarDebiterade, timmar);
            tabel.AddValue(Constants.ColumnNames.UKkonstnader, String.Empty);
            tabel.AddValue(Constants.ColumnNames.TimmarKomptid, String.Empty);
            tabel.AddValue(Constants.ColumnNames.ManmanaderTotalt, timmar / 176);
            tabel.AddValue(Constants.ColumnNames.DebiteringBemanning, debitering);
            tabel.AddValue(Constants.ColumnNames.Lönekonstnader, löne);
            tabel.AddValue(Constants.ColumnNames.UKkonstnader, String.Empty);
            tabel.AddValue(Constants.ColumnNames.ArbetadeTimmar, timmar);
            var TimmarOdebiterade = Calculate.GetValueFromResultTable(SQLController.GetDataTable(Common.Queries.TimmarOdebiteradeQuery), "summa");
            tabel.AddValue(Constants.ColumnNames.TimmarOdebiterade, odebiterade);
            tabel.AddValue(Constants.ColumnNames.TimmarTotalt, (Convert.ToDouble(GetCorrectValue(TimmarOdebiterade))
                + Convert.ToDouble(GetCorrectValue(tabel.GetValue(Constants.ColumnNames.ArbetadeTimmar)))));

            return tabel;
        }
        #endregion
        #region public
        public StatistikTabel GetStatistikTabel(string startDatum, string slutDatum,string type, DataTable dataTabel, List<string> columnsNamesToAdd)
        {
            StatistikTabel result = new StatistikTabel(name);
            result = AddCalculateColumns(result, dataTabel, columnsNamesToAdd);
            result = GetErastingValues(result, startDatum, slutDatum, type);
            return result;
        }
        #endregion
        #endregion
        #region Contructors
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="_name">table name</param>
        /// <param name="columnNames">table columns</param>
        public Arbetare(String _name, List<String> columnNames)
        {
            Init(_name, columnNames,true);
        }
        /// <summary>
        /// Create object with statictic table in it
        /// </summary>
        /// <param name="_name">table name</param>
        /// <param name="type">worker type</param>
        /// <param name="queryColumns">column nnames for "select" query</param>
        /// <param name="columnNames">table column names</param>
        /// <param name="startDatum">start date</param>
        /// <param name="slutDatum">end date</param>
        /// <param name="columnsNamesToAdd">columns names that? need to add</param>
        public Arbetare(String _name, int type, List<String> queryColumns, List<String> columnNames,
            string startDatum, string slutDatum, List<string> columnsNamesToAdd,bool showColumns)
        {
            Init(_name, columnNames,showColumns);
            var dataTabel = SQLController.GetDataTable(Query.GetPersonalQuery(startDatum, slutDatum, type, queryColumns));
            statistikTabel = GetStatistikTabel(startDatum, slutDatum,type.ToString(), dataTabel, columnsNamesToAdd);
            statistikTabel=FromatTableValues(statistikTabel);
            statistikTabel.showColumns = showColumns;
        }
        #endregion
    }
}