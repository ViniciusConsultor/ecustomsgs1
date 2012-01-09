using System;

namespace ECustoms.Utilities
{
    public static class GlobalInfo
    {
        public static bool IsDebug 
        {
            get { return Convert.ToBoolean(Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["IsDebugMode"].ToString())); }
        }
    }
}
