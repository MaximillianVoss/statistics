using System;
using System.Collections.Generic;

namespace Statistics.Classes
{
    public static class Common
    {
        #region Queries
        public static class Queries
        {
            public static String TimmarOdebiteradeQuery =
"WITH resultTabel(rapportradDatum, rapportradStart, rapportradSlut, rapportradLunchStart, rapportradLunchSlut, ejdebiterbar) " +
"AS(SELECT rapportradDatum, rapportradStart, rapportradSlut, rapportradLunchStart, rapportradLunchSlut, ejdebiterbar " +
"FROM snille_rapportrader " +
"INNER JOIN snille_personaltabell " +
"ON snille_rapportrader.personalID = snille_personaltabell.personalID " +
"INNER JOIN snille_uppdragstabell " +
"ON snille_uppdragstabell.uppdragsID = snille_rapportrader.uppdragsID " +
"WHERE snille_personaltabell.personalTyp = 2 AND snille_uppdragstabell.ejdebiterbar = 1) " +
"Select SUM(ejdebiterbar)as summa from resultTabel ";
            public static String UtläggQuery =
    "WITH resultTabel(personalTyp, ersattningsDatum, ersattningsTyp, ersattningsKostnadInkl, " +
    "ersattningsKostnadExkl, sum)" +
    "AS(SELECT personalTyp, ersattningsDatum, ersattningsTyp, ersattningsKostnadInkl, " +
    "ersattningsKostnadExkl, ersattningsKostnadInkl+ersattningsKostnadExkl as Sum " +
    "FROM snille_personaltabell " +
    "INNER JOIN snille_ersattningstabell " +
    "ON snille_ersattningstabell.personalID = snille_personaltabell.personalID " +
    "WHERE ersattningsTyp = 1 AND personalTyp={1}) " +
    "Select SUM(sum) as summa from resultTabel {0}";
            public static String MilersättningQuery =
    "WITH resultTabel(personalTyp, ersattningsDatum, ersattningsTyp, ersattningsAntal, ersattningsKostnadInkl,ersattningsKostnadExkl, sum) " +
"AS(SELECT personalTyp, ersattningsDatum, ersattningsTyp, ersattningsAntal, ersattningsKostnadInkl, " +
"ersattningsKostnadExkl, ersattningsAntal* ersattningsKostnadExkl as Sum " +
"FROM snille_personaltabell INNER JOIN snille_ersattningstabell " +
"ON snille_ersattningstabell.personalID = snille_personaltabell.personalID " +
"WHERE ersattningsTyp = 3 AND personalTyp={1})Select SUM(sum) as summa from resultTabel {0} ";
            public static String TraktamenteQuery =
"WITH resultTabel(personalTyp, ersattningsDatum, ersattningsTyp,  " +
"ersattningsKostnadInkl, ersattningsKostnadExkl, " +
 "ersattningHeldagAntal, ersattningHeldagBelopp,  " +
 "ersattningHalvdagAntal, ersattningHalvdagBelopp, " +
 "ersattningNattAntal, ersattningNattBelopp, ersattningFruAntal,  " +
 "ersattningFruBelopp, ersattningMiddagAntal, " +
 "ersattningMiddagBelopp, sum) " +
 "AS (SELECT " +
"personalTyp, ersattningsDatum, ersattningsTyp, ersattningsKostnadInkl, " +
"ersattningsKostnadExkl, ersattningHeldagAntal, ersattningHeldagBelopp, " +
"ersattningHalvdagAntal, ersattningHalvdagBelopp, " +
"ersattningNattAntal, ersattningNattBelopp, " +
"ersattningFruAntal, ersattningFruBelopp, " +
"ersattningMiddagAntal, ersattningMiddagBelopp, " +
"(ersattningHeldagAntal* ersattningHeldagBelopp) +  " +
"(ersattningHalvdagAntal* ersattningHalvdagBelopp) +  " +
"(ersattningNattAntal* ersattningNattBelopp) +   " +
"(ersattningFruAntal* ersattningFruBelopp) +  " +
"(ersattningLunchAntal* ersattningLunchBelopp) +  " +
"(ersattningMiddagAntal* ersattningMiddagBelopp) as Sum " +
"FROM snille_personaltabell " +
"INNER JOIN snille_ersattningstabell " +
"ON snille_ersattningstabell.personalID = snille_personaltabell.personalID " +
"WHERE ersattningsTyp= 2 AND personalTyp={1}) Select SUM(sum) as summa from resultTabel {0} ";





        }

        #endregion
        #region Enums
        public static class Enums
        {
            /// <summary>
            /// Workers types
            /// </summary>
            public enum personalTypes { type1 = 1, type2 = 2, type3 = 3, type4 = 4 };
            /// <summary>
            ///  ersattning types
            /// </summary>
            public enum ersattningsTypes { type1 = 1, type2 = 2, type3 = 3 };
        }
        #endregion
        #region ColumnsNames
        public static class ColumnNames
        {
            /// <summary>
            /// columns names for query
            /// </summary>
            public static List<string> columnNamesPersonal = new List<string>
        {
                Constants.QueryColumnNames.personalFornamn,
                Constants.QueryColumnNames.rapportradStart,
                Constants.QueryColumnNames.rapportradSlut,
                Constants.QueryColumnNames.rapportradLunchSlut,
                Constants.QueryColumnNames.rapportradLunchStart,
                Constants.QueryColumnNames.rapportradDatum,
                Constants.QueryColumnNames.rapportradDebitering,
                Constants.QueryColumnNames.rapportradLonegrund,
                Constants.QueryColumnNames.personalTyp
        };

            public static List<string> columnNamesErsattnings = new List<string>
        {
                Constants.QueryColumnNames.personalTyp,
                Constants.QueryColumnNames.ersattningsDatum,
                Constants.QueryColumnNames.ersattningsTyp
        };

            /// <summary>
            /// columns names to add in result table
            /// </summary>
            public static List<string> columnsToAdd = new List<string>
        {
                Constants.ColumnNames.Hours,
                Constants.ColumnNames.DebiteringBemanning,
                Constants.ColumnNames.LöneOchUKKostnader,
                Constants.ColumnNames.ArbetadeTimmar,
                Constants.ColumnNames.TimmarOdebiterade,
                Constants.ColumnNames.TimmarTotalt
        };
            /// <summary>
            /// statistik tabell columns
            /// </summary>
            public static List<String> statistikTabelColumnNames = new List<string> {
            Constants.ColumnNames.IntäkterOchKostnader,
            Constants.ColumnNames.DebiteringBemanning,
            Constants.ColumnNames.Lönekonstnader,
            Constants.ColumnNames.UKkonstnader,
            Constants.ColumnNames.Timmar,
            Constants.ColumnNames.TimmarDebiterade,
            //Constants.ColumnNames.ArbetadeTimmar,
            Constants.ColumnNames.TimmarOdebiterade,
            Constants.ColumnNames.TimmarKomptid,
            Constants.ColumnNames.TimmarTotalt,
            Constants.ColumnNames.ManmanaderTotalt,
            Constants.ColumnNames.Ersättning,
            Constants.ColumnNames.UltaggKonstad,
            Constants.ColumnNames.Milersättning,
            Constants.ColumnNames.Traktamente,
            Constants.ColumnNames.SummaTotalt
        };
            public static List<String> statistikTabelHeaderColumns = new List<string>
        {
                Constants.ColumnNames.IntäkterOchKostnader,
                Constants.ColumnNames.Timmar,
                Constants.ColumnNames.Ersättning
        };
        }

        #endregion
        #region Units
        public static class Units
        {
            public static Dictionary<String,String> statistikTabelColumnUnits = new Dictionary<String, String> {
            {Constants.ColumnNames.DebiteringBemanning, Constants.Unit.kron },
           { Constants.ColumnNames.Lönekonstnader, Constants.Unit.kron },
           { Constants.ColumnNames.UKkonstnader,Constants.Unit.kron },
           { Constants.ColumnNames.TimmarDebiterade,Constants.Unit.hours },
           { Constants.ColumnNames.TimmarOdebiterade,Constants.Unit.hours },
           { Constants.ColumnNames.TimmarKomptid,Constants.Unit.hours },
           { Constants.ColumnNames.TimmarTotalt,Constants.Unit.hours },
           { Constants.ColumnNames.ManmanaderTotalt,Constants.Unit.manader },
           { Constants.ColumnNames.UltaggKonstad,Constants.Unit.kron },
           { Constants.ColumnNames.Milersättning,Constants.Unit.kron },
           { Constants.ColumnNames.Traktamente,Constants.Unit.kron },
           { Constants.ColumnNames.SummaTotalt,Constants.Unit.kron }
        };
        }
        #endregion
    }
}