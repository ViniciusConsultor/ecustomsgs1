using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECustoms.Utilities
{
    public static class TechLinkExt
    {
        /// <summary>
        /// Convert DataTime value to Vietnamese date format: dd/MM/yyyy hh:mm:ss
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToVnDate(this DateTime value)
        {
            string formatDate = "{0}/{1}/{2} {3}:{4}:{5}";
            return string.Format(formatDate, value.Day, value.Month, value.Year, value.Hour, value.Minute, value.Millisecond);
        }

        /// <summary>
        /// Return Hour of a string 12:15, value return is 12
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToHour(this string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                return "00";
            }
            else
            {
                return value.Split(':')[0];
            }
        }

        /// <summary>
        /// Return Minute of a string 12:15, value return is 15
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMinute(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "00";
            }
            else
            {
                return value.Split(':')[1];
            }
        }

        /// <summary>
        /// Convert a string number to int
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int StringToInt(this string value)
        {
            int v = 0;
            if(int.TryParse(value,out v))
            {
                return v;
            }

            return 0;
        }
    }
}
