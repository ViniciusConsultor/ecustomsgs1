using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ApplicationUtils.Environment
{
    public class EnvironmentHelper
    {

        //Get AppData folder
        public static string GetAppDataFolder()
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
        }

        public static string GetAppDataFolderForCK2011()
        {
          return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),"KC.2011");
        }
    }
}
