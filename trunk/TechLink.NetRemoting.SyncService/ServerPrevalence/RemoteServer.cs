using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ApplicationUtils.ErrorReporting;
using ApplicationUtils.Utils;
using ECustoms.DAL;
using ExceptionHandler;
using GenericRemoteServer.General;

namespace ServerPrevalence
{
	public class RemoteServer : AbstractRemoteServer
	{
		private string _databaseFullPath = "";

		public RemoteServer(ServerSettings settings)
			: base(settings)
		{
			_databaseFullPath =
					Path.Combine(InstallationSpecificFolders.GetPath(InstallationSpecificFoldersEnum.Database), "GKData.mdb");

			ServerErrorReportingEngine.Instance.NewErrorReport += Instance_NewErrorReport;
		}

		private void Instance_NewErrorReport(object sender, NewErrorReportEventArgs<ServerErrorReport> e)
		{
			try
			{
				//e.ErrorReport.LastSnapshot = this.LastSnapshot;
				//foreach (FileInfo info in this.GetCommandLogsForLastSnapshot())
				//{
				//    e.ErrorReport.CommandLogs.Add(info.FullName);
				//}

				string officeTemplateslFolderPath = InstallationSpecificFolders.GetPath(InstallationSpecificFoldersEnum.OfficeTemplates);
				e.ErrorReport.ConfigFolders.Add(new DirectoryInfo(officeTemplateslFolderPath));

				string xmlFolderPath = InstallationSpecificFolders.GetPath(InstallationSpecificFoldersEnum.Xml);
				e.ErrorReport.ConfigFolders.Add(new DirectoryInfo(xmlFolderPath));

				string configFolderPath = InstallationSpecificFolders.GetPath(InstallationSpecificFoldersEnum.Config);
				e.ErrorReport.ConfigFolders.Add(new DirectoryInfo(configFolderPath));

				string viewsFolderPath = InstallationSpecificFolders.GetPath(InstallationSpecificFoldersEnum.Views);
				e.ErrorReport.ConfigFolders.Add(new DirectoryInfo(viewsFolderPath));

				string viewsCommonFolderPath = Path.Combine(InstallationSpecificFolders.GetPath(InstallationSpecificFoldersEnum.Views), "Common");
				e.ErrorReport.ConfigFolders.Add(new DirectoryInfo(viewsCommonFolderPath));

				string logsFolderPath = ServerEnvironment.Instance.GetPath(ServerFolders.Logs);
				e.ErrorReport.LogsDirectory = logsFolderPath;


				e.ErrorReport.AditionalInfo.Add(new ErrorReportBase.InfoItem("ProductVersion", Application.ProductVersion));
				e.ErrorReport.AditionalInfo.Add(new ErrorReportBase.InfoItem("InstallationName", ServerSettings.Instance.InstallationName));
				e.ErrorReport.AditionalInfo.Add(new ErrorReportBase.InfoItem("ServerDate", DateTime.Now.ToString()));

				ErrorReportBase errorReport = e.ErrorReport;

				try
				{
					errorReport.AddInfo("Machine Name", Environment.MachineName);
				}
				catch (Exception e1)
				{
					Debug.WriteLine(e1);
				}

				try
				{
					errorReport.AddInfo("Windows UserName", Environment.UserName);
				}
				catch (Exception e1)
				{
					Debug.WriteLine(e1);
				}

				try
				{
					errorReport.AddInfo("UserDomainName", Environment.UserDomainName);
				}
				catch (Exception e1)
				{
					Debug.WriteLine(e1);
				}

				try
				{
					errorReport.AddInfo("ProcessorCount", Environment.ProcessorCount.ToString());
				}
				catch (Exception e1)
				{
					Debug.WriteLine(e1);
				}

				try
				{
					errorReport.AddInfo("OSVersion", Environment.OSVersion.ToString());
				}
				catch (Exception e1)
				{
					Debug.WriteLine(e1);
				}

				try
				{
					errorReport.AddInfo("Server IP Address", NetHelper.GetIpAddress());
				}
				catch (Exception e1)
				{
					Debug.WriteLine(e1);
				}

				try
				{
					errorReport.AddInfo("CLR Version", Environment.Version.ToString());
				}
				catch (Exception e1)
				{
					Debug.WriteLine(e1);
				}

			}
			catch (Exception err)
			{
				Debug.WriteLine(err);
			}
		}

		#region Overrides of AbstractRemoteServer

		protected override void CreateDatabase()
		{
#if ACCESS_DATA
            IDataController remoteDatabase = null; //= new DataController(_databaseFullPath);
            genericServer = new AccessGenericServer(remoteDatabase);
            //genericServer.Onlogin += new ClientServerExchange.Delegates.OnLoginHandler(genericServer_Onlogin);
            //genericServer.Onlogout += new ClientServerExchange.Delegates.OnLogoutHandler(genericServer_Onlogout);
            //genericServer.DataDomainChanged += new ClientServerExchange.Interfaces.OnDataDomainChangedHandler(genericServer_DataDomainChanged);
            //Remain task need to be done in the future
            //1. Validate version
            //2. Init interval compact and backup data
#else

			IDataController remoteDatabase = new SQLDataController(settings.SqlServerName, settings.SqlDatabaseName, settings.SqlUserName,
																														 settings.SqlPassword);
			genericServer = new SQLGenericServer(remoteDatabase);
			//Remain task need to be done in the future
			//1. Validate version
			//2. Init interval compact and backup data
#endif
		}

		void genericServer_DataDomainChanged(object sender, string changedIn, EnumConstant.Enums.Methology methology)
		{
			ProcessException.WriteInfoLog("DataDomain changed at:\r\n" + DateTimeUtils.GetBaseDateTimeString(DateTime.Now) + "\r\nMethology: \r\n" +
				methology.ToString() + "\r\nChangedIn: \r\n" + changedIn + "\r\nInfo: \r\n" + sender.ToString(), "");

            //if (GlobalCache.IsInitialized)
            //    GlobalCache.SystemCacheData.UpdateCache(changedIn);
		}

		void genericServer_Onlogout(object sender, ClientServerExchange.Args.LoginArgs e)
		{
			//ProcessException.Notify("Login user: " + e.ToString());
		}

		void genericServer_Onlogin(object sender, ClientServerExchange.Args.LoginArgs e)
		{
            //ClientAppState clientAppState = (ClientAppState)sender;
            //ProcessException.WriteInfoLog(
            //        string.Format("User login:\r\n Username: {0} | SessionID: {1} | LoginDate: {2} | IPAddress: {3}",
            //        clientAppState.UserName, clientAppState.SessionId, DateTimeUtils.GetBaseDateTimeNowString(), clientAppState.IpAddress), "RemoteServer.genericServer_Onlogin()");
		}

		protected override void OnClose()
		{
			base.OnClose();
            //genericServer.Onlogin -= genericServer_Onlogin;
            //genericServer.Onlogout -= genericServer_Onlogout;
			genericServer.Close();
		}

		public override void BackupDatabase(string destinationFolder)
		{
			throw new NotImplementedException();
		}

		public override void UpgradeDatabase()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
