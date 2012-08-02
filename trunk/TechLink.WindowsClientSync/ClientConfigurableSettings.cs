using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;

namespace TechLink.WindowsClientSync
{
	public class ClientConfigurableSettings
	{
		private const string ServerUrlSettingsKey = "serverURL";
		private const string ServerPortSettingsKey = "serverPort";
		private const string ClientPortSettingsKey = "clientPort";
		private const string DisplayApplicationInfoSettingsKey = "DisplayApplicationInfo";
		private const string ApplicationsAtServerSettingsKey = "ApplicationsAtServer";
		private const string UseClientCacheSettingsKey = "useClientChache";
		private const string CacheFolderNameSettingsKey = "cacheFolderName";
		private const string CacheFullPathSettingsKey = "cacheFullPath";
		private const string ClientCacheLocationSettingsKey = "clientCacheLocation";
		private const string ApplicationCacheFolder = "Promova";
		private const string TopMostApplication = "TopMost";

		#region members

		private bool applicationsAtServer = true;
		private string serverURL = "localhost";
		private string serverPORT = "8080";
		private string clientPort = "0";
		private bool displayApplicationInfo = false;

		//cache settings
		private bool useClientChache = false;
		private string cacheFullPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		private string cacheFolderName = "";
		private bool topMost = false;

		#endregion

		public ClientConfigurableSettings()
		{
		}

		public ClientConfigurableSettings(NameValueCollection appSettings)
		{
			ReadSettings(appSettings);
		}

		#region properties

		public bool ApplicationsAtServer
		{
			get
			{
				return applicationsAtServer;
			}
		}

		public string ServerURL
		{
			get
			{
				return serverURL;
			}
		}

		public string ServerPORT
		{
			get
			{
				return serverPORT;
			}
		}

		public bool TopMost
		{
			get { return topMost; }
		}

		public string ClientPort
		{
			get
			{
				return clientPort;
			}
		}

		public bool DisplayApplicationInfo
		{
			get
			{
				return displayApplicationInfo;
			}
		}

		public bool UseClientChache
		{
			get
			{
				return useClientChache;
			}
		}

		public string CacheFullPath
		{
			get
			{
				return cacheFullPath;
			}
		}

		public string CacheFolderName
		{
			get
			{
				return cacheFolderName;
			}
		}
		#endregion

		private void ReadSettings(NameValueCollection settings)
		{
			if (settings[ServerUrlSettingsKey] != null)
			{
#if DEBUG && !REMOTE_TESTING
				//serverURL = ApplicationConstants.DebugServerURL;
				serverURL = settings["serverURL"];
#else
				serverURL = settings["serverURL"];
#endif
			}

			if (settings[ServerPortSettingsKey] != null)
			{
#if DEBUG && !REMOTE_TESTING
				serverPORT = settings["serverPort"]; // ApplicationConstants.DebugServerPORT;
#else
				serverPORT = settings["serverPort"];
#endif
			}
			if (settings[DisplayApplicationInfoSettingsKey] != null)
			{
				displayApplicationInfo = settings[DisplayApplicationInfoSettingsKey].ToLower() == "true";
			}


			if (settings[ApplicationsAtServerSettingsKey] != null)
			{
				applicationsAtServer = settings[ApplicationsAtServerSettingsKey].ToLower() == "true";
			}

			if (settings[ClientPortSettingsKey] != null)
			{
				clientPort = settings[ClientPortSettingsKey];
			}

			if (settings[UseClientCacheSettingsKey] != null)
			{
				this.useClientChache = settings[UseClientCacheSettingsKey].ToLower() == "true";
			}

			if (settings[CacheFolderNameSettingsKey] != null)
			{
				this.cacheFolderName = settings[CacheFolderNameSettingsKey];
			}

			if (settings[TopMostApplication] != null)
			{
				this.topMost = settings[TopMostApplication].ToLower()=="true";
			}

			if (!string.IsNullOrEmpty(settings[CacheFullPathSettingsKey]))
			{
				this.cacheFullPath = settings[CacheFullPathSettingsKey];
			}
			else if (!string.IsNullOrEmpty(settings[ClientCacheLocationSettingsKey]))
			{
				this.cacheFullPath = settings[ClientCacheLocationSettingsKey];
			}
			else
			{
				this.cacheFullPath = Path.Combine(cacheFullPath, ApplicationCacheFolder);
				this.cacheFullPath = Path.Combine(cacheFullPath, this.cacheFolderName);
			}
		}
	}
}
