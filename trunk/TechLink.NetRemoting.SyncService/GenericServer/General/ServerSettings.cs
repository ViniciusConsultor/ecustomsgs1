using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using ApplicationUtils.Logging.Log4Net;
using log4net;

namespace GenericRemoteServer.General
{
	public class ServerSettings
	{
		#region private fields
		private static readonly ILog log = Log4NetManager.GetLog();
		private readonly NameValueCollection settingsSource = null;

		private string securityEnabled = "yes";
		private string clientServerEventsEnabled = "yes";
		private string version = "1.0";
		private string initialVersion = "1.0";
		private string port = "8085";
		private string applicationDefinitionDataFile = "ApplicationDefinitionData.xml";
		private string applicationsPath = "";
		private DateTime currentDate = DateTime.Today;
		private bool currentDateAlreadyParsed = false;
		private bool blockMultipleLoggins = false;
		private bool allowChangeCurrentDate = false;
		private string policyFile = "Policy.xml";
		private string serverType = "ServerPrevalence";
		private string migrationSearchPath = "C:\\Temp";
		private string monitorUrl = "";
		private int monitorInterval = 0;
		private string debugHtmlReport = string.Empty;
		private string classificationXmlFile = string.Empty;
		private string licenseFile = "license.xml";
		private bool warnOnlyExceedingConcurrentUsers = false;

		#endregion

		private static ServerSettings instance = null;
		private string installationName = "unknown";

		private bool logBusinessLogicCalls = false;
		private string gridFiltersPath = string.Empty;
		private string connectionString = string.Empty;
		private string sqlUserName = string.Empty;
		private string sqlPassword = string.Empty;
		private string sqlDatabaseName = string.Empty;

		public static ServerSettings Instance
		{
			get
			{
				if (instance == null)
				{
					throw new Exception("Singleton not initialized!");
				}
				return instance;
			}
		}

		public static void Init(NameValueCollection settingsSource)
		{
			log.Info("ServerSettings.Init()");
			instance = new ServerSettings(settingsSource);
		}

		private ServerSettings(NameValueCollection settingsSource)
		{
			this.settingsSource = settingsSource;
			ReadSettingsFrom(settingsSource);
		}

		private void SetValue(ref string variable, string valName, NameValueCollection config)
		{
			if (config[valName] != null)
			{
				variable = config[valName];
			}
		}

		private void SetValue(ref int variable, string valName, NameValueCollection config, int min, int max)
		{
			if (max < min)
			{
				throw new ArgumentException("max value is less them min value");
			}
			string valStr = config[valName];
			if (valStr != null)
			{
				int.TryParse(valStr, out variable);
			}

			variable = Math.Max(variable, min);
			variable = Math.Min(variable, max);
		}

		private void SetValue(ref bool variable, string valName, NameValueCollection config)
		{
			string valStr = config[valName];
			if (!string.IsNullOrEmpty(valStr))
			{
				variable = valStr.Trim().ToLower() == "yes" || valStr.Trim().ToLower() == "true" || valStr.Trim().ToLower() == "y";
			}
		}

		private void ReadSettingsFrom(NameValueCollection config)
		{
			SetValue(ref securityEnabled, "SecurityEnabled", config);
			SetValue(ref clientServerEventsEnabled, "ClientServerEventsEnabled", config);
			SetValue(ref version, "Version", config);
			initialVersion = version;
			SetValue(ref port, "port", config);
#if !DEBUG
			SetValue(ref port, "port", config);
#endif

			SetValue(ref applicationDefinitionDataFile, "ApplicationDefinitionData", config);
			SetValue(ref policyFile, "PolicyFilePath", config);
			SetValue(ref serverType, "ServerType", config);
			SetValue(ref applicationsPath, "ApplicationsPath", config);
			SetValue(ref migrationSearchPath, "MigrationSearchPath", config);

#if DEBUG
			debugHtmlReport = @"C:\Temp\PIS.1.0";
#else
			SetValue(ref debugHtmlReport, "DebugHtmlReport", config);
#endif

			SetValue(ref monitorUrl, "MonitorUrl", config);
			SetValue(ref monitorInterval, "MonitorInterval", config, 0, int.MaxValue);
			SetValue(ref blockMultipleLoggins, "BlockMultipleLoggins", config);
			SetValue(ref classificationXmlFile, "ClassificationXmlFile", config);
#if !DEBUG
						//SetValue(ref webServerPort, "WebServerPort", config);
#endif

			SetValue(ref installationName, "InstallationName", config);
			SetValue(ref licenseFile, "LicenseFile", config);
			SetValue(ref logBusinessLogicCalls, "LogBusinessLogicCalls", config);
			SetValue(ref warnOnlyExceedingConcurrentUsers, "WarnOnlyExceedingConcurrentUsers", config);
			SetValue(ref gridFiltersPath, "GridFiltersPath", config);
			SetValue(ref connectionString, "SqlServerName", config);
			SetValue(ref sqlDatabaseName, "SqlDatabaseName", config);
			SetValue(ref sqlUserName, "SqlUserName", config);
			SetValue(ref sqlPassword, "SqlPassword", config);

			if (config["CurrentDate"] != null)
			{
				try
				{
					IFormatProvider format = CultureInfo.CurrentCulture;
					currentDate = DateTime.Parse(config["CurrentDate"], format);
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex);
				}
			}
		}

		#region public accesors

		public string InstallationName
		{
			get
			{
				return installationName;
			}
		}

		public string SecurityEnabled
		{
			get
			{
				return securityEnabled;
			}
		}

		public string ClientServerEventsEnabled
		{
			get
			{
				return clientServerEventsEnabled;
			}
		}

		public string Version
		{
			get
			{
				return version;
			}
			set
			{
				version = value;
			}
		}

		public string InitialVersion
		{
			get { return initialVersion; }
		}

		public string Port
		{
			get
			{
				return port;
			}
		}

		public string ApplicationDefinitionDataFile
		{
			get
			{
				return applicationDefinitionDataFile;
			}
		}

		public string ApplicationsPath
		{
			get
			{
				return applicationsPath;
			}
		}


		public DateTime CurrentDate
		{
			get
			{
				if (allowChangeCurrentDate)
				{
					return currentDate;
				}
				if (settingsSource["CurrentDate"] == null)
				{
					currentDate = DateTime.Now;
				}
				else
				{
					if (!currentDateAlreadyParsed)
					{
						currentDateAlreadyParsed = true;
						string dateString = settingsSource["CurrentDate"].Trim();
						if (!DateTime.TryParseExact(dateString, "dd.MM.yyyy", CultureInfo.CurrentCulture, DateTimeStyles.RoundtripKind,
																			out currentDate))
						{
							currentDate = DateTime.Now;
							Debug.Fail("Could not parse string " + dateString + " into a valid date.");
						}
						currentDateAlreadyParsed = true;
					}
				}
				DateTime now = DateTime.Now;
				currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, now.Hour, now.Minute, now.Second);
				return currentDate;
			}
			set
			{
				if (allowChangeCurrentDate)
				{
					currentDate = value;
				}
			}
		}

		public bool BlockMultipleLoggins
		{
			get
			{
				return blockMultipleLoggins;
			}
		}

		public bool AllowChangeCurrentDate
		{
			set
			{
				allowChangeCurrentDate = value;
			}
		}

		public string PolicyFile
		{
			get
			{
				return policyFile;
			}
		}

		public string ServerType
		{
			get
			{
				return serverType;
			}
		}

		public string MigrationSearchPath
		{
			get
			{
				return migrationSearchPath;
			}
		}

		public string MonitorUrl
		{
			get
			{
				return monitorUrl;
			}
		}

		public int MonitorInterval
		{
			get
			{
				return monitorInterval;
			}
		}

		public string DebugHtmlReport
		{
			get
			{
				return debugHtmlReport;
			}
		}

		public string ClassificationXmlFile
		{
			get
			{
				return classificationXmlFile;
			}
		}

		public string SqlServerName
		{
			get
			{
				return connectionString;
			}
		}

		public string SqlDatabaseName
		{
			get
			{
				return sqlDatabaseName;
			}
		}

		public string SqlUserName
		{
			get
			{
				return sqlUserName;
			}
		}

		public string SqlPassword
		{
			get
			{
				return sqlPassword;
			}
		}


		public string LicenseFile
		{
			get
			{
				return licenseFile;
			}
		}

		public bool LogBusinessLogicCalls
		{
			get
			{
				return logBusinessLogicCalls;
			}
		}

		public bool WarnOnlyExceedingConcurrentUsers
		{
			get
			{
				return warnOnlyExceedingConcurrentUsers;
			}
		}

		public string GridFiltersPath
		{
			get { return gridFiltersPath; }
		}

		#endregion

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			PropertyInfo[] props = this.GetType().GetProperties();

			foreach (PropertyInfo prop in props)
			{
				try
				{
					if (prop.CanRead)
					{
						object objVal = prop.GetValue(this, null);
						if (objVal != this) // stack overflow if call is made to "ToString" method for the static property Instance which is actualy the actual instantce.
						{
							string val = objVal.ToString();
							if (val != null)
							{
								sb.AppendLine(prop.Name + "='" + val + "'");
							}
							else
							{
								sb.AppendLine(prop.Name + "=null");
							}
						}
					}
				}
				catch
				{
					sb.AppendLine(prop.Name + " -> value could not be read.");
				}
			}

			return sb.ToString();
		}
	}
}
