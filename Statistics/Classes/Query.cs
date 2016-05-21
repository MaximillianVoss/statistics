using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statistics.Classes
{
    public static class Query
    {
        private static String AddQoutes(string value)
        {
            return string.Format("'{0}'", value);
        }
        public static String AddDates(string rapportradDatumFrom, string rapportradDatumTo)
        {
            if (String.IsNullOrEmpty(rapportradDatumFrom) && String.IsNullOrEmpty(rapportradDatumTo))
                return String.Empty;
            else if (String.IsNullOrEmpty(rapportradDatumTo))
                return String.Format(" AND rapportradDatum>={0}", AddQoutes(rapportradDatumFrom));

            else if (String.IsNullOrEmpty(rapportradDatumFrom))
                return String.Format(" AND rapportradDatum<={0}", AddQoutes(rapportradDatumTo));
            else
                return String.Format("AND rapportradDatum>={0} AND rapportradDatum<={1}",
                    AddQoutes(rapportradDatumFrom), AddQoutes(rapportradDatumTo));

        }
        public static String AddDates(string rapportradDatumFrom, string rapportradDatumTo, string dateColumnName)
        {
            if (String.IsNullOrEmpty(rapportradDatumFrom) && String.IsNullOrEmpty(rapportradDatumTo))
                return String.Empty;
            else if (String.IsNullOrEmpty(rapportradDatumTo))
                return String.Format(" AND {0}>={1}", dateColumnName, AddQoutes(rapportradDatumFrom));

            else if (String.IsNullOrEmpty(rapportradDatumFrom))
                return String.Format(" AND {0}<={1}", dateColumnName, AddQoutes(rapportradDatumTo));
            else
                return String.Format("AND {0}>={1} AND {0}<={2}",
                    dateColumnName, AddQoutes(rapportradDatumFrom), AddQoutes(rapportradDatumTo));

        }
        public static string GetPersonalQuery(string rapportradDatumFrom, string rapportradDatumTo, int personalTyp, List<string> columnNames)
        {
            return String.Format("Select " + String.Join(",", columnNames.ToArray()) + " From snille_personaltabell" +
                 " INNER JOIN  snille_rapportrader ON snille_personaltabell.personalID = snille_rapportrader.personalID" +
                 " AND personalTyp={0} {1}", AddQoutes(personalTyp.ToString()), AddDates(rapportradDatumFrom, rapportradDatumTo));
        }
        public static string GetErastingsQuery(string rapportradDatumFrom, string rapportradDatumTo, int ersattningsTyp, List<string> columnNames)
        {
            return String.Format(
            "SELECT " + String.Join(",", columnNames.ToArray()) + " FROM snille_personaltabell" +
            " INNER JOIN  snille_ersattningstabell ON snille_personaltabell.personalID = snille_ersattningstabell.personalID"+
            " WHERE ersattningsTyp = {0} {1}", AddQoutes(ersattningsTyp.ToString()), AddDates(rapportradDatumFrom, rapportradDatumTo, "ersattningsDatum")
                );
        }
    }
}