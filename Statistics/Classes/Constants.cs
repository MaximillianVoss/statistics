using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Statistics.Classes
{
    public static class Constants
    {
        public static class Unit
        {
            public const String kron = "kr.";
            public const String hours = "h.";
            public const String manader = "månader";
        }
        public static class ColumnNames
        {
            public const String UltaggKonstad = "utlägg kostnad EXKL";
            public const String SummaTotalt = "Summa Totalt";
            public const String IntäkterOchKostnader = "Intäkter och kostnader";
            public const String DebiteringBemanning = "Debitering bemanning";
            public const String LöneOchUKKostnader = "Löne och UK kostnader";
            public const String Lönekonstnader = "Lönekostnader";
            public const String Timmar = "Timmar";
            public const String ArbetadeTimmar = "Arbetade timmar";
            public const String TimmarDebiterade = "Timmar debiterade";
            public const String TimmarOdebiterade = "Timmar odebiterade";
            public const String TimmarKomptid = "Timmar komptid";
            public const String TimmarTotalt = "Timmar totalt";
            public const String ManmanaderTotalt = "Manmänader totalt";
            public const String Ersättning = "Ersättning";
            public const String Utlägg = "Utlägg";
            public const String Milersättning = "Milersättning";
            public const String Traktamente = "Traktamente";
            public const String Summa = "Summa";
            public const String Hours = "Hours";
            public const String UKkonstnader = "UK-konstnader";
        }
        public static class QueryColumnNames
        {
            public const String personalFornamn = "personalFornamn";
            public const String rapportradStart = "rapportradStart";
            public const String rapportradSlut = "rapportradSlut";
            public const String rapportradLunchStart = "rapportradLunchStart";
            public const String rapportradLunchSlut = "rapportradLunchSlut";
            public const String rapportradDatum = "rapportradDatum";
            public const String rapportradDebitering = "rapportradDebitering";
            public const String rapportradLonegrund = "rapportradLonegrund";
            public const String personalTyp = "personalTyp";
            public const String ersattningsDatum = "ersattningsDatum";
            public const String ersattningsTyp = "ersattningsTyp";
        }


    }
}