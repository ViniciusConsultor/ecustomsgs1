using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Niq.Msd.Common
{
    public static class NiqExtentions
    {
        public static string ToLicenceNumber(this string value)
        {
            if (value.IndexOf('-') >= 0) return string.Empty;

            char[] chars = value.ToCharArray();
            int i = 0, kp = -1;
            foreach (var c in chars)
            {
                if ((c >= '0') && (c <= '9'))
                {

                }
                else
                {
                    kp = i;
                }

                i++;
            }

            if (kp >= 0)
                value = value.Insert(kp + 1, "-");

            return value;
        }
    }
}
