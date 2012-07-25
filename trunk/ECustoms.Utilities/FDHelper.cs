using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace ECustoms.Utilities
{
    public class FDHelper
    {
        public static string RunningDir()
        {
            return Environment.CurrentDirectory;
        }
        public static string GetAppData()
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
        }

        public static string TechlinkAppData()
        {
            return System.IO.Path.Combine(GetAppData(), "Techlink2012");
        }

        public static bool CreateFolderIfDoesnotExisted(string path)
        {
            try
            {
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static void DeleteAllFilesInFolder(string folderPath)
        {
            System.IO.Directory.Delete(folderPath, true);
            CreateFolderIfDoesnotExisted(folderPath);
        }

        public static string RgGetTechlinkAppDataPath()
        {
            var app = Registry.LocalMachine.OpenSubKey(ConstantInfo.RgKeyApp);
            if (app != null)
            {
                var s = app.GetValue(ConstantInfo.RgKeyAppDataPath);
                if (s == null) return string.Empty;

                return s.ToString();
            }
            return string.Empty;
        }

        public static string RgGetUserProfilePath()
        {
            var app = Registry.LocalMachine.OpenSubKey(ConstantInfo.RgKeyApp);
            if (app != null)
            {
                var s = app.GetValue(ConstantInfo.RgKeyAppDataPath);
                var s1 = app.GetValue(ConstantInfo.RgKeyAppUserProfilePath);

                if (s == null || s1 == null) return string.Empty;
                string ss = s.ToString();
                return System.IO.Path.Combine(ss, s1.ToString());
            }
            return string.Empty;
        }

        public static long RgGetTimeStamp()
        {
            var app = Registry.LocalMachine.OpenSubKey(ConstantInfo.RgKeyApp);
            if (app != null)
            {
                var ss = app.GetValue(ConstantInfo.RgKeyAppUserTimeStampPath);
                if (ss == null) return 0;

                long s = Convert.ToInt64(ss.ToString());
                return s;
            }
            return 0;
        }

        /// <summary>
        /// Save data into SOFTWARE\\TechLink
        /// </summary>
        /// <param name="path"></param>
        public static void SaveTechLinkAppDataPath(string path)
        {
            var app = Registry.LocalMachine.OpenSubKey(ConstantInfo.RgKeyApp, true);
            if (app == null)
            {
                var sig = Registry.LocalMachine.CreateSubKey(ConstantInfo.RgKeyApp);
                sig.SetValue(ConstantInfo.RgKeyAppDataPath, path);
            }
            else
            {
                app.SetValue(ConstantInfo.RgKeyAppDataPath, path);
            }
        }

        public static void SaveTechLinkUserProfile(string fileName)
        {
            var app = Registry.LocalMachine.OpenSubKey(ConstantInfo.RgKeyApp, true);
            if (app == null)
            {
                var sig = Registry.LocalMachine.CreateSubKey(ConstantInfo.RgKeyApp);
                sig.SetValue(ConstantInfo.RgKeyAppUserProfilePath, fileName);
            }
            else
            {
                app.SetValue(ConstantInfo.RgKeyAppUserProfilePath, fileName);
            }
        }

        public static void SaveTechLinkTimeStamp(long time)
        {
            var app = Registry.LocalMachine.OpenSubKey(ConstantInfo.RgKeyApp, true);
            if (app == null)
            {
                var sig = Registry.LocalMachine.CreateSubKey(ConstantInfo.RgKeyApp);
                sig.SetValue(ConstantInfo.RgKeyAppUserTimeStampPath, time);
            }
            else
            {
                app.SetValue(ConstantInfo.RgKeyAppUserTimeStampPath, time);
            }
        }
    }

}
