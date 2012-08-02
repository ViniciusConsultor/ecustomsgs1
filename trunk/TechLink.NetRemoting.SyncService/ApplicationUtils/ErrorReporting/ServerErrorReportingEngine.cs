#define TEST_REPORT_UPLOADER
using System;
using System.Collections;
using System.IO;
using System.Threading;
using ApplicationUtils.Utils;
using ExceptionHandler;

namespace ApplicationUtils.ErrorReporting
{
	public class ServerErrorReportingEngine : IServerErrorReportingEngine
	{
		private static IServerErrorReportingEngine instance = null;
    
		public static IServerErrorReportingEngine Instance
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
            
		public static void Initialize(string reportsFolderPath, int intervalOfDays, int maxNumberErrReport, bool addSnapshotToReport)
		{
			try
			{
				instance = SafeServerErrorReportingEngine.GetSafeInstance(new ServerErrorReportingEngine(reportsFolderPath,intervalOfDays, maxNumberErrReport,false));
				ProcessException.Handle(string.Format("Initializing ServerErrorReportingEngine. reportsFolderPath={0}, intervalOfDays={1}, maxNumberErrReport={2}",reportsFolderPath,intervalOfDays,maxNumberErrReport));
				UploableErrorReportingEngine.Initialize(reportsFolderPath, intervalOfDays, maxNumberErrReport, addSnapshotToReport);
			}
			catch (Exception)
			{
				instance = new NullServerErrorReportingEngine();
			}
		}

		private ServerErrorReportingEngine(string reportsFolderPath, int intervalOfDays, int maxNumberErrReport,bool addSnapshotToReport)
		{
			if(intervalOfDays <= 0)
			{
				throw new ArgumentException("intervalOfDays must be greated then 0");
			}
			if(maxNumberErrReport <=0)
			{
				throw new ArgumentException("maxNumberErrReport  must be greated then 0");
			}
      
			PathUtils.TryCreatePath(reportsFolderPath);
			if (!Directory.Exists(reportsFolderPath))
			{
				throw new IOException("Path not found: " + reportsFolderPath);
			}
		}
    
		private readonly Hashtable processingErrorReportFiles = Hashtable.Synchronized(new Hashtable());

		public Hashtable ProcessingErrorReportFiles
		{
			get
			{
				return processingErrorReportFiles;
			}
		}

		public event EventHandler<NewErrorReportEventArgs<ServerErrorReport>> NewErrorReport;

		private void OnNewErrorReport(ServerErrorReport errorReport)
		{
			if (NewErrorReport != null)
			{
				NewErrorReport(this, new NewErrorReportEventArgs<ServerErrorReport>(errorReport));
			}
		}

		public void CreateServerErrorReport(ErrorReportBase clientErrorReport)
		{
			ProcessException.Handle("ServerErrorReportingEngine.CreateServerErrorReport() :" + clientErrorReport.ToString());
      ServerErrorReport serverErrorReport = new ServerErrorReport();
			serverErrorReport.ClientErrorReport = clientErrorReport;
			OnNewErrorReport(serverErrorReport);

			ThreadPool.QueueUserWorkItem(delegate(object state) { UploableErrorReportingEngine.Instance.CreateProcessingJob((ServerErrorReport)state); }, serverErrorReport);

		}
	}

	public class NullServerErrorReportingEngine : IServerErrorReportingEngine
	{
		#region IServerErrorReportingEngine Members

		public event EventHandler<NewErrorReportEventArgs<ServerErrorReport>> NewErrorReport;

		protected void OnNewErroReport()
		{
			if (NewErrorReport != null)
			{
			}
		}

		public void CreateServerErrorReport(ErrorReportBase clientErrorReport)
		{
		}

		public Hashtable ProcessingErrorReportFiles
		{
			get
			{
				return new Hashtable();
			}
		}

		#endregion
	}
}