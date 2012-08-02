using System;
using System.ComponentModel;
using System.IO;
using ApplicationUtils.Utils;
using ExceptionHandler;
using log4net;

namespace GenericRemoteServer.General
{
    /// <summary>
    /// Summary description for InstallationSpecificFolders.
    /// </summary>
    public enum InstallationSpecificFoldersEnum
    {
        [Description("Data\\Storage\\Attachments/NotVital")]
        Attachments,
        Config,
        [Description("/NotVital")]
        DbFiles,
        [Description("Data/NotVital")]
        Database,
        Help,
        Resources,
        Translations,
        Views,
        [Description("WebRoot")]
        WebRoot,
        [Description("WebRoot\\Tmp/NotVital")]
        WebRootTemp,
        Xml,
				[Description("/NotVital")]
				ClientAssemply,
        //Storage-Data
        [Description("Data\\Storage\\OfficeTemplates/NotVital")]
        OfficeTemplates,
        [Description("Data\\Storage\\OfficeToolTemplates/NotVital")]
        OfficeToolTemplates,
        [Description("Data\\Storage\\GridFilters/NotVital")]
        GridFilters,
        [Description("Data\\Storage/NotVital")]
        DatabaseOutsideStorage,
        [Description("Data\\Storage\\Office/NotVital")]
        OfficeFiles,
        [Description("Data\\Storage\\EvaluationAttachments/NotVital")]
        EvaluationAttachments,

        [Description("Data\\Storage\\EditableSettings/NotVital")]
        EditableSettings
    }

    public class InstallationSpecificFolders
    {
        private static string installtionPath = string.Empty;

        public static void SetBasePath(string basePath, bool validate)
        {
            installtionPath = basePath;
            if (validate)
            {
                Validate();
            }
        }

        public static void SetBasePath(string basePath)
        {
            ProcessException.Handle("InstallationSpecificFolders.SetBasePath(" + basePath + ")");
            SetBasePath(basePath, true);
        }

        public static void Validate()
        {
            if (!Directory.Exists(installtionPath))
            {
                throw new DirectoryNotFoundException(installtionPath);
            }

            Array serverFolders = Enum.GetValues(typeof(InstallationSpecificFoldersEnum));

            foreach (Enum serverFolder in serverFolders)
            {
                string path = GetPath((InstallationSpecificFoldersEnum)serverFolder);

                if ((IsVital((InstallationSpecificFoldersEnum)serverFolder)) && (!Directory.Exists(path)))
                {
                    throw new DirectoryNotFoundException(path);
                }
            }
        }

        public static string GetPath(InstallationSpecificFoldersEnum serverFolder)
        {
            string descr = EnumHelper.GetAssociatedDescription(serverFolder);
            string path = descr.Replace("/NotVital", "");
            if (path == string.Empty)
            {
                path = Enum.GetName(serverFolder.GetType(), serverFolder);
            }
            string finalPath = Path.Combine(installtionPath, path);
            PathUtils.TryCreatePath(finalPath);
            return finalPath;
        }


        private static bool IsVital(InstallationSpecificFoldersEnum serverFolder)
        {
            string descr = EnumHelper.GetAssociatedDescription(serverFolder);
            if (descr.EndsWith("/NotVital"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string GetConfigFilePath(string fileName, bool throwException)
        {
            string asmFolderPath = GetPath(InstallationSpecificFoldersEnum.Config);
            if (File.Exists(Path.Combine(asmFolderPath, fileName)))
            {
                return Path.Combine(asmFolderPath, fileName);
            }

            if (throwException)
            {
                throw new FileNotFoundException("FileNotFoundException: " + Path.Combine(asmFolderPath, fileName));
            }

            return fileName;
        }

        public static string GetClassificationXmlFileFullPath()
        {
            return
                Path.Combine(InstallationSpecificFolders.GetPath(InstallationSpecificFoldersEnum.DbFiles),
                                         ServerStaticData.Settings.ClassificationXmlFile);
        }


        public static string GetClassificationXmlDeletedNodesFileFullPath()
        {
            string fullPath = GetClassificationXmlFileFullPath();
            fullPath = Path.ChangeExtension(fullPath, "deleted");
            return fullPath;
        }
    }
}