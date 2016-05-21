using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statistics.Classes
{
    public static  class Common
    {
        #region Enums
        /// <summary>
        /// Workers types
        /// </summary>
        public enum personalTypes { worker = 1, type2 = 2, type3 = 3, type4 = 4 };
        /// <summary>
        ///  ersattning types
        /// </summary>
        public enum ersattningsTypes {type1 =1,type2=2,type3=3 };
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
        #endregion
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
    }
}