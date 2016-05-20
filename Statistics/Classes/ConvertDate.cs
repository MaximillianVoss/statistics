using System;
using System.Globalization;

namespace Statistics.Classes
{
    public static class ConvertDate
    {
        public static DateTime ConvertDayTime(string value)
        {
            try
            {
                return DateTime.Parse(value);
            }
            catch(Exception ex)
            {
                return new DateTime();
            }
        }

        public static String FormatConvert(string value,string formatTo)
        {
            //return DateTime.ParseExact(value, formatFrom, null).ToString(formatTo);
            return DateTime.Parse(value).ToString(formatTo);
        }
    }
}