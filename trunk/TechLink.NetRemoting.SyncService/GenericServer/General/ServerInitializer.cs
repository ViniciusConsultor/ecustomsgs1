#define USE_TRACING
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using ApplicationUtils.ErrorReporting;
using ApplicationUtils.Logging.Log4Net;
using ApplicationUtils.Utils;
using ExceptionHandler;
using log4net;
using log4net.Config;

namespace GenericRemoteServer.General
{
	/// <summary>
	/// Summary description for ServerInitializer.
	/// </summary>
	public class ServerInitializer
	{
		private static readonly ILog log = Log4NetManager.GetLog();

		/// <summary>
		/// Does the server initializations.Inialize 	ServerEnvironment base path, InstallationSpecificFolders base path, reads server settings
		/// </summary>
		public static void DoServerInitializations()
		{
			XmlConfigurator.Configure();
			Trace.Listeners.Add(new Log4NetTraceListener());
			Trace.AutoFlush = true;
			log.Info("DoServerInitializations call");
			//init folders base paths
			try
			{
				ServerEnvironment._Initializer.CreateInstance(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
				log.Info("ServerEnveroniment static instance initialized");
				string installationPath = ServerEnvironment.Instance.GetPath(ServerFolders.InstallationsBasePath);
				log.Info("Installation path is " + installationPath);
//#if DEBUG

				foreach (string name in Enum.GetNames(typeof (ServerFolders)))
				{
					string configValue =
						ConfigurationSettings.GetAppSettings(string.Concat(Assembly.GetEntryAssembly().Location, ".config"))[name];
					if (configValue != null)
					{
						ServerEnvironment._Initializer.SetExactPath((ServerFolders) Enum.Parse(typeof (ServerFolders), name), configValue);
					}
				}
        
				if (ServerEnvironment._Initializer.GetExactPath(ServerFolders.InstallationsBasePath) != string.Empty)
				{
					installationPath = ServerEnvironment._Initializer.GetExactPath(ServerFolders.InstallationsBasePath);
				}
//#endif
				log.Info("Server folders configurations completed.");

				InstallationSpecificFolders.SetBasePath(
					Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), installationPath));

				log.Info("InstallationSpecificFolders configured");

				string serverConfigPath = InstallationSpecificFolders.GetConfigFilePath("Server.config", true);
				ServerSettings.Init(ConfigurationSettings.GetAppSettings(serverConfigPath));
				log.Info("ServerSettings initialized");
				log.Info("The server was started with the folowing .exe.config file content.");
				log.Info(ServerSettings.Instance.ToString());
                //ServerErrorReportingEngine.Initialize(ServerEnvironment.Instance.GetPath(ServerFolders.ErrorReports),
                //    ServerSettings.Instance.DaysIntervalToUploadTheSameReport, ServerSettings.Instance.NumberOfSameReportToUploadInInterval,
                //    ServerSettings.Instance.AddSnapshotToUploadedReport);
                ServerErrorReportingEngine.Initialize(ServerEnvironment.Instance.GetPath(ServerFolders.ErrorReports),
                    1, 100, false);
				CheckVitalFilesExistence();
			}
			catch (DirectoryNotFoundException e)
			{
				ProcessException.ErrorNotify.NotifyUser("Could not start application. Directory not found. " + e.Message);
				Process.GetCurrentProcess().Kill();
			}

			Tracing.TraceCall();
			//---
		}

		private static void CheckVitalFilesExistence()
		{
			log.Info("CheckVitalFilesExistence call");
            InstallationSpecificFolders.GetConfigFilePath("goldkeeper.exe.config", true);
			log.Info("CheckVitalFilesExistence call ended");
		}
	}
}