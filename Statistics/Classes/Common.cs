using System;
using System.Collections.Generic;

namespace Statistics.Classes
{
    public static class Common
    {
        #region Queries
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
"WHERE ersattningsTyp = 1) " +
"Select SUM(sum) as summa from resultTabel ";
        public static String MilersättningQuery =
"WITH resultTabel(personalTyp, ersattningsDatum, ersattningsTyp, ersattningsKostnadInkl, " +
"ersattningsKostnadExkl, sum)" +
"AS(SELECT personalTyp, ersattningsDatum, ersattningsTyp, ersattningsKostnadInkl, " +
"ersattningsKostnadExkl, ersattningsKostnadInkl+ersattningsKostnadExkl as Sum " +
"FROM snille_personaltabell " +
"INNER JOIN snille_ersattningstabell " +
"ON snille_ersattningstabell.personalID = snille_personaltabell.personalID " +
"WHERE ersattningsTyp = 3)Select SUM(sum) as summa from resultTabel ";
        public static String TraktamenteQuery =
"WITH resultTabel(personalTyp, ersattningsDatum, ersattningsTyp, ersattningsKostnadInkl, " +
"ersattningsKostnadExkl, sum) " +
"AS(SELECT personalTyp, ersattningsDatum, ersattningsTyp, ersattningsKostnadInkl, " +
"ersattningsKostnadExkl, ersattningsKostnadInkl+ersattningsKostnadExkl as Sum " +
"FROM snille_personaltabell " +
"INNER JOIN snille_ersattningstabell " +
"ON snille_ersattningstabell.personalID = snille_personaltabell.personalID " +
"WHERE ersattningsTyp = 2)Select SUM(sum) as summa from resultTabel ";
        #endregion
        #region Enums
        /// <summary>
        /// Workers types
        /// </summary>
        public enum personalTypes { worker = 1, type2 = 2, type3 = 3, type4 = 4 };
        /// <summary>
        ///  ersattning types
        /// </summary>
        public enum ersattningsTypes { type1 = 1, type2 = 2, type3 = 3 };
        #endregion
        #region ColumnsNames
        /// <summary>
        /// columns names for query
        /// </summary>
        public static List<string> columnNamesPersonal = new List<string>
        {
            "personalFornamn","rapportradStart",
            "rapportradSlut","rapportradLunchStart",
            "rapportradLunchSlut","rapportradDatum",
            "rapportradDebitering", "rapportradLonegrund",
            "personalTyp"
        };

        public static List<string> columnNamesErsattnings = new List<string>
        {
            "personalTyp","ersattningsDatum","ersattningsTyp"
        };

        /// <summary>
        /// columns names to add in result table
        /// </summary>
        public static List<string> columnsToAdd = new List<string>
        {
            "Hours","Debitering bemanning",
            "Löne och UK kostnader","Arbetade timmar",
            "Timmar odebiterade","Timmar totalt"
        };
        /// <summary>
        /// statistik tabell columns
        /// </summary>
        public static Dictionary<string, string> statistikTabel = new Dictionary<string, string>
        {
            {"Arbetare","" },
            { "Intäkter och kostnader",""},
            { "Debitering bemanning","c"},
            { "Löne och UK kostnader","c"},
            { "Timmar",""},
            { "Arbetade timmar","c"},
            { "Timmar odebiterade","c"},
            { "Timmar totalt","c"},
            { "Ersättning",""},
            { "Utlägg","c"},
            { "Milersättning","c"},
            { "Traktamente","c"},
            { "Summa","c"}
        };
        #endregion
    }
}