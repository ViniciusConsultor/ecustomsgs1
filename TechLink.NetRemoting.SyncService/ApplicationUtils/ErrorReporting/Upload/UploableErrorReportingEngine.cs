using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using ApplicationUtils.ErrorReporting.Upload;
using ApplicationUtils.Logging.Log4Net;
using ApplicationUtils.Utils;
using log4net;

namespace ApplicationUtils.ErrorReporting
{
	public interface IUploableErrorReportingEngine
	{
		void CreateProcessingJob(ServerErrorReport errorReport);
	}

	public class NullUploableErrorReportingEngine:IUploableErrorReportingEngine
	{
		public void CreateProcessingJob(ServerErrorReport errorReport)
		{
			
		}
	}

	public class SafeUploableErrorReportingEngine:IUploableErrorReportingEngine
	{
		private IUploableErrorReportingEngine realInstance;

		public SafeUploableErrorReportingEngine(IUploableErrorReportingEngine realInstance)
		{
			this.realInstance = realInstance;
		}

		public void CreateProcessingJob(ServerErrorReport errorReport)
		{
			try
			{
				realInstance.CreateProcessingJob(errorReport);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
		}
	}
  
	public class UploableErrorReportingEngine : IUploableErrorReportingEngine
	{
		private static readonly ILog log = Log4NetManager.GetPermanentLog("ErrorReportingLog");

		private const string LAST_SENT_ITEMS_FILE_NAME ="lastSentItems.xml";

		private readonly DirectoryInfo reportsFolder;
		private readonly DirectoryInfo processingFolder;
		private readonly DirectoryInfo reportsToUploadFolder;
		private readonly DirectoryInfo uploadingReportsFolder;
		private readonly FileInfo lastSentItemsFileInfo;
		
		private ProcessingJobsSharedTools tools;
    
		private UploableErrorReportingEngine(string reportsFolderPath, int intervalOfDays, int maxNumberErrReport,bool addSnapshotToReport)
		{
			reportsFolder = new DirectoryInfo(Path.Combine(reportsFolderPath, "MiniReports"));
			PathUtils.TryCreatePath(reportsFolder.FullName);
			reportsToUploadFolder = reportsFolder.CreateSubdirectory("ToUpload");
			uploadingReportsFolder = reportsFolder.CreateSubdirectory("Uploading");
			processingFolder = reportsFolder.CreateSubdirectory("Processing");
			lastSentItemsFileInfo = new FileInfo(Path.Combine(reportsFolder.FullName, LAST_SENT_ITEMS_FILE_NAME));

			//try clear processing and uploading folder
			try
			{
				List<FileInfo> files = new List<FileInfo>();
				//files.AddRange(uploadingReportsFolder.GetFiles("err*.zip"));
				//files.AddRange(uploadingReportsFolder.GetFiles("issue*.zip"));
				files.AddRange(uploadingReportsFolder.GetFiles("err*.*"));
				files.AddRange(uploadingReportsFolder.GetFiles("issue*.*"));

				foreach (FileInfo file in files)
				{
					file.MoveTo(Path.Combine(reportsToUploadFolder.FullName, file.Name));
				}
				processingFolder.Delete(true);
				uploadingReportsFolder.Delete(true);
				processingFolder = reportsFolder.CreateSubdirectory("Processing");
				uploadingReportsFolder = reportsFolder.CreateSubdirectory("Uploading");
			}
			catch (Exception e)
			{
				log.Error(e);
				Debug.WriteLine(e);
			}
      
			tools = new ProcessingJobsSharedTools(intervalOfDays, maxNumberErrReport, addSnapshotToReport, 
			                                      processingFolder, reportsToUploadFolder, uploadingReportsFolder,
			                                      lastSentItemsFileInfo);
			PackageUploadManager.Initialize(tools);

			//Uploder uploader = new Uploder(PackageUploadManager.Instance);
			//uploader.TryDoUploads();

			//return;

			ThreadPool.QueueUserWorkItem(delegate(object state)
			{
				Uploder uploader = new Uploder(PackageUploadManager.Instance);
				uploader.TryDoUploads();
			});
		}


		private static IUploableErrorReportingEngine instance;

		public static IUploableErrorReportingEngine Instance
		{
			get
			{
				return instance;
			}
		}

		public static void Initialize(string reportsFolderPath, int intervalOfDays, int maxNumberErrReport,bool addSnapshotToReport)
		{
			try
			{
				instance =
					new SafeUploableErrorReportingEngine(new UploableErrorReportingEngine(reportsFolderPath, intervalOfDays,
					                                                                      maxNumberErrReport, addSnapshotToReport));
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
				instance = new NullUploableErrorReportingEngine(); 
			}
		}

		public void CreateProcessingJob(ServerErrorReport errorReport)
		{
			log.Info("CreateProcessingJob() -error report: " + errorReport);
			ReportProcessingJob processingJob =new ReportProcessingJob(tools, errorReport);
			processingJob.StartProcessing();

			Uploder uploader = new Uploder(PackageUploadManager.Instance);
			uploader.TryDoUploads();
		}  
	}


}
