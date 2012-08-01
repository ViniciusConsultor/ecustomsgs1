using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ApplicationUtils.Utils;

namespace ApplicationUtils.ErrorReporting
{
	public class ClientErrorReportingEngine : IClientErrorReportingEngine
	{
		private static IClientErrorReportingEngine instance = null;

		public static IClientErrorReportingEngine Instance
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

		public static void Initialize(string reportsFolderPath)
		{
			try
			{
				instance = SafeClientErrorReportingEngine.GetSafeInstance(new ClientErrorReportingEngine(reportsFolderPath));
			}
			catch (Exception)
			{
				if (instance == null)
				{
					instance = new NullClientErrorReportingEngine();
				}
			}
		}

		#region IClientErrorReportingEngine Members

		public event EventHandler ErrorReportAvailable;


		public event EventHandler<NewErrorReportEventArgs<ErrorReportBase>> NewErrorReport;

		#endregion

		private void OnErrorReportAvailable()
		{
			if (ErrorReportAvailable != null)
			{
				ErrorReportAvailable(this, EventArgs.Empty);
			}
		}

		private void OnNewErrorReport(ErrorReportBase errorReportBase)
		{
			if (this.NewErrorReport != null)
			{
				this.NewErrorReport(this, new NewErrorReportEventArgs<ErrorReportBase>(errorReportBase));
			}
		}

		private DirectoryInfo reportsTempDir = null;
		private readonly string fileName = "errors.xml";
		private List<ErrorReportBase> errorReportsList = new List<ErrorReportBase>();
		private bool disableErrorSending = false;

		public List<ErrorReportBase> ErrorReportsList
		{
			get
			{
				return errorReportsList;
			}
		}

		public bool DisableErrorSending
		{
			get
			{
				return this.disableErrorSending;
			}
			set
			{
				this.disableErrorSending = value;
			}
		}

		public ClientErrorReportingEngine(string reportsTempDir)
		{
			Init(reportsTempDir);
		}

		private void Init(string repotsTempDir)
		{
			PathUtils.TryCreatePath(repotsTempDir);
			DirectoryInfo di = new DirectoryInfo(repotsTempDir);
			if (!di.Exists)
			{
				throw new IOException("Path not found: " + repotsTempDir);
			}
			else
			{
				this.reportsTempDir = new DirectoryInfo(repotsTempDir);
			}
			DeserializeReportsQueue();
		}

		public void Stop()
		{
			SerializeReportsQueue();
			errorReportsList.Clear();
		}

		public void Clear()
		{
			errorReportsList.Clear();
			string filePath = Path.Combine(reportsTempDir.FullName, fileName);
			if (File.Exists(filePath))
			{
				try
				{
					File.Delete(filePath);
				}
				catch
				{
				}
			}
		}


		private void DeserializeReportsQueue()
		{
			XmlSerializer serializer = new XmlSerializer(errorReportsList.GetType());
			string filePath = Path.Combine(reportsTempDir.FullName, fileName);
			if (File.Exists(filePath))
			{
				using (Stream reader = new FileStream(filePath, FileMode.Open))
				{
					errorReportsList = (List<ErrorReportBase>) serializer.Deserialize(reader);
				}
			}
			if (this.errorReportsList.Count > 0)
			{
				OnErrorReportAvailable();
			}
		}

		private void SerializeReportsQueue()
		{
			XmlSerializer serializer = new XmlSerializer(errorReportsList.GetType());
			using (StreamWriter streamWriter = File.CreateText(Path.Combine(reportsTempDir.FullName, fileName)))
			{
				serializer.Serialize(streamWriter, errorReportsList);
				streamWriter.Flush();
				streamWriter.Close();
			}
		}

		public ErrorReportBase CreateErrorReport()
		{
			ErrorReportBase errorReport = new ErrorReportBase();
			this.errorReportsList.Add(errorReport);
			OnNewErrorReport(errorReport);
			return errorReport;
		}

		public void SendReports()
		{
			if (disableErrorSending)
			{
				return;
			}
			if (this.errorReportsList.Count > 0)
			{
				OnErrorReportAvailable();
			}
		}
    
	}

	public class NullClientErrorReportingEngine : IClientErrorReportingEngine
	{
		#region IClientErrorReportingEngine Members

		public event EventHandler ErrorReportAvailable;
		public event EventHandler<NewErrorReportEventArgs<ErrorReportBase>> NewErrorReport;

		protected void OnErrorReportAvailable()
		{
			if (ErrorReportAvailable != null)
			{
			}
		}

		protected void OnNewErroReport()
		{
			if (NewErrorReport != null)
			{
			}
		}

		public List<ErrorReportBase> ErrorReportsList
		{
			get
			{
				return new List<ErrorReportBase>();
			}
		}

		public bool DisableErrorSending
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void Stop()
		{
		}

		public void Clear()
		{
		}

		public ErrorReportBase CreateErrorReport()
		{
			return new ErrorReportBase();
		}

		public void SendReports()
		{
		}
    
		#endregion
	}
}