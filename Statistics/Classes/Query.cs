using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statistics.Classes
{
    public static class Query
    {
        public enum  personalTypes { worker = 1, type2 = 2, type3 = 3, type4 = 4 };
        private static String AddQoutes(string value)
        {
            return string.Format("'{0}'", value);
        }
        public static string GetQuery(string rapportradDatum, string rapportadStart, string rapportadSlut, string personalTyp)
        {

            string query = String.Format("Select personalFornamn , rapportradStart,rapportradSlut,rapportradLunchStart,rapportradLunchSlut,rapportradDatum,personalTyp From snille_personaltabell" +
                " INNER JOIN  snille_rapportrader ON snille_personaltabell.personalID = snille_rapportrader.personalID AND" +
                " snille_rapportrader.rapportradStart = {0} AND snille_rapportrader.rapportradSlut = {1} AND personalTyp={2} AND rapportradDatum>={3}",
                AddQoutes(rapportadStart), AddQoutes(rapportadSlut), AddQoutes(personalTyp), AddQoutes(rapportradDatum));
            return query;
        }
        public static string GetQuery(string rapportradDatum, string rapportadStart, string personalTyp)
        {

            string query = String.Format("Select personalFornamn , rapportradStart,rapportradSlut,rapportradLunchStart,rapportradLunchSlut,rapportradDatum,personalTyp From snille_personaltabell" +
                " INNER JOIN  snille_rapportrader ON snille_personaltabell.personalID = snille_rapportrader.personalID AND" +
                " snille_rapportrader.rapportradStart = {0}  AND personalTyp={1} AND rapportradDatum>={2}",
                AddQoutes(rapportadStart), AddQoutes(personalTyp), AddQoutes(rapportradDatum));
            return query;
        }
        public static void GetQuery(string tableName,List<string> columnNames)
        {
            
        }
    }
}