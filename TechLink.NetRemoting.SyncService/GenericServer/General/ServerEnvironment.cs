#define USE_TRACING
using System;
using System.Collections;
using System.IO;
using ApplicationUtils.Utils;
using ExceptionHandler;
using log4net;

namespace GenericRemoteServer.General
{
    public class ServerEnvironment : IServerEnvironment, IServerEnvironmentInitializer
    {
        private static ServerEnvironment singletonInstance = new ServerEnvironment();

        private static ServerEnvironment SingletonInstance
        {
            get
            {
                if (!singletonInstance.IsInitialized)
                {
                    throw new Exception("Singleton is not initialized");
                }
                return singletonInstance;
            }
        }

        public static IServerEnvironment Instance
        {
            get
            {
                return SingletonInstance;
            }
        }

        public static IServerEnvironmentInitializer _Initializer
        {
            get
            {
                return singletonInstance;
            }
        }

        #region private fields

        private Hashtable exactPaths = null;
        private readonly string basePath = string.Empty;
        private readonly bool isInitialized;

        #endregion

        private Hashtable ExactPaths
        {
            get
            {
                if (exactPaths == null)
                {
                    exactPaths = new Hashtable();
                    foreach (ServerFolders value in Enum.GetValues(typeof(ServerFolders)))
                    {
                        exactPaths[value] = string.Empty;
                    }
                }
                return exactPaths;
            }
        }


        public string BasePath
        {
            get
            {
                return basePath;
            }
        }


        public void SetExactPath(ServerFolders serverFolder, string path)
        {
            ProcessException.Handle(serverFolder + " " + path);
            ExactPaths[serverFolder] = path;
        }


        /// <summary>
        /// Gets the exact path which was setted for the specefied serverFolder in the config file.
        /// Use GetPath()
        /// </summary>
        /// <param name="serverFolder">The server folder.</param>
        /// <returns></returns>
        public string GetExactPath(ServerFolders serverFolder)
        {
            return (string)ExactPaths[serverFolder];
        }

        #region c-tors

        private ServerEnvironment(string basePath, bool validate)
        {
            Tracing.TraceCall(basePath);
            this.basePath = basePath;
            if (validate)
            {
                Validate();
            }
            isInitialized = true;
        }

        private ServerEnvironment(string basePath)
            : this(basePath, true)
        {
            isInitialized = true;
        }

        private ServerEnvironment()
        {
            isInitialized = false;
        }

        #endregion

        public void Validate()
        {
            if (!Directory.Exists(basePath))
            {
                throw new DirectoryNotFoundException(basePath);
            }

            Array serverFolders = Enum.GetValues(typeof(ServerFolders));

            foreach (Enum serverFolder in serverFolders)
            {
                string path = GetPath((ServerFolders)serverFolder);

                if ((IsVital((ServerFolders)serverFolder)) && (!Directory.Exists(path)))
                {
                    Directory.CreateDirectory(path);
                    DirectoryNotFoundException exception = new DirectoryNotFoundException(path);
                    ProcessException.WriteErrorLog(exception.StackTrace, exception.Message);
                    ProcessException.WriteInfoLog("\r\nCreated folder: " + path,"ServerEnviroment.Validate()");
                }
            }
        }

        public void CreateInstance(string basePath, bool validate)
        {
            singletonInstance = new ServerEnvironment(basePath, validate);
        }

        public void CreateInstance(string basePath)
        {
            ProcessException.Handle("ServerEnvironment.CreateInstance(" + basePath + ")");
            singletonInstance = new ServerEnvironment(basePath);
        }

        public bool IsInitialized
        {
            get
            {
                return isInitialized;
            }
        }

        public string GetPath(ServerFolders serverFolder)
        {
            string path = (string)ExactPaths[serverFolder];
            if ((string)ExactPaths[serverFolder] == string.Empty)
            {
                string descr = EnumHelper.GetAssociatedDescription(serverFolder);
                path = descr.Replace("/NotVital", "");
                if (path == string.Empty)
                {
                    path = Enum.GetName(serverFolder.GetType(), serverFolder);
                }
            }
            return Path.Combine(basePath, path);
        }

        private bool IsVital(ServerFolders serverFolder)
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

        public string GetFilePath(string fileName)
        {
            string asmFolderPath = GetPath(ServerFolders.CommonAssemblies);
            if (File.Exists(Path.Combine(asmFolderPath, fileName)))
            {
                return Path.Combine(asmFolderPath, fileName);
            }

            asmFolderPath = GetPath(ServerFolders.ClientAssemblies);
            if (File.Exists(Path.Combine(asmFolderPath, fileName)))
            {
                return Path.Combine(asmFolderPath, fileName);
            }

            asmFolderPath = GetPath(ServerFolders.ServerAssemblies);
            if (File.Exists(Path.Combine(asmFolderPath, fileName)))
            {
                return Path.Combine(asmFolderPath, fileName);
            }

            return fileName;
        }
    }
}
