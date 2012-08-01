using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using ApplicationUtils.Logging.Log4Net;
using ApplicationUtils.Utils;
using ApplicationUtils.Utils.ZipUtils.Zip;
using log4net;

namespace ApplicationUtils.ErrorReporting.Upload
{
	public class ReportProcessingJob
	{
		private static readonly ILog log = Log4NetManager.GetPermanentLog("ErrorReportingLog");
		private readonly ProcessingJobsSharedTools tools;
		private readonly ServerErrorReport report;
		private readonly string reportHashCode;

		private readonly List<ReportProcessingTicket> inProcessingTicketsList;
		private readonly List<ReportProcessingTicket> sentTicketsList;
		private readonly List<ReportProcessingTicket> toBeUploadedTicketsList;
		private readonly List<ReportProcessingTicket> uploadingTicketsList;

		private readonly List<ReportProcessingTicket> allTicketsList;
		private readonly ReportProcessingTicket ticket;

		public ReportProcessingJob(ProcessingJobsSharedTools processingJobsSharedTools, ServerErrorReport report)
		{
			this.tools = processingJobsSharedTools;
			this.report = report;
			reportHashCode = tools.GetReportHashCode(this.report);

			inProcessingTicketsList = new List<ReportProcessingTicket>(tools.GetTicketsOfTypeInProcessing(reportHashCode));
			sentTicketsList = new List<ReportProcessingTicket>(tools.GetTicketsOfTypeAlreadySent(reportHashCode));
			toBeUploadedTicketsList = new List<ReportProcessingTicket>(tools.GetTicketsOfTypeToBeUploaded(reportHashCode));
			uploadingTicketsList = new List<ReportProcessingTicket>(tools.GetAllUploadingTicketsOfType(reportHashCode));

			allTicketsList = new List<ReportProcessingTicket>();
			allTicketsList.AddRange(sentTicketsList);
			allTicketsList.AddRange(inProcessingTicketsList);
			allTicketsList.AddRange(toBeUploadedTicketsList);
			allTicketsList.AddRange(uploadingTicketsList);

			ticket = new ReportProcessingTicket();
			ticket.ReportHashcode = reportHashCode;
		}
    
		public void StartProcessing()
		{
			log.Info("Start processing " + this.reportHashCode);

			if(!ShouldStartJob())
			{
				return;
			}
			else
			{
				tools.AddProcessingTicket(ticket);	
			}

			try
			{
				bool shouldAddSnapshot = tools.AddSnapshotToReport & ShouldAddSnapshot();
				ticket.HasSnapshot = shouldAddSnapshot;
        
				//create the name of the package
				string packageName = string.Format("err-ID_{4}-{0}-v.{1}-{2}{3}{5}", report.InstallationName, report.InstallationVersion, DateTime.Now.ToString("yyyy.MM.dd_HH_mm_ss"), (shouldAddSnapshot ? "-s" : string.Empty), reportHashCode, (report.ClientErrorReport.IsCrush ? "-c" : string.Empty));
#if DEBUG
				packageName = string.Format("err_TEST-ID_{4}-{0}-v.{1}-{2}{3}{5}", report.InstallationName, report.InstallationVersion, DateTime.Now.ToString("yyyy.MM.dd_HH_mm_ss"), (shouldAddSnapshot ? "-s" : string.Empty), reportHashCode, (report.ClientErrorReport.IsCrush ? "-c" : string.Empty));
#endif

				//if it is issues, use other name format
				if(report.ClientErrorReport.IsIssue)
				{
					packageName = "issue" + "-" + report.InstallationName + "-" + "v." + report.InstallationVersion + "-" + DateTime.Now.ToString("yyyy.MM.dd_HH_mm_ss") + "-" + report.ClientErrorReport.GetAdditionalItemValue("ApplicationName").Replace(" ", "_")+"-"+reportHashCode;
					shouldAddSnapshot = true;
					ticket.HasSnapshot = shouldAddSnapshot;
#if DEBUG
          packageName = "issue" + "-" + "TEST" + "-" + report.InstallationName + "-" + "v." + report.InstallationVersion + "-" + DateTime.Now.ToString("yyyy.MM.dd_HH_mm_ss") + "-" + report.ClientErrorReport.GetAdditionalItemValue("ApplicationName").Replace(" ", "_") + "-" + reportHashCode;
#endif
				}

        DirectoryInfo packageDir = new DirectoryInfo(Path.Combine(tools.ProcessingFolderPath, packageName));
				if(packageDir.Exists)
				{
					return;
				}

				packageDir.Create();
        
        //save the screenshot image into the package folder
				if (report.ClientErrorReport.ScreenCaptureImageContent != null)
				{
					try
					{
						FileUtils.SaveToFile(Path.Combine(packageDir.FullName, report.ClientErrorReport.ScreenCaptureImageName),
						                     report.ClientErrorReport.ScreenCaptureImageContent);
					}
					catch (Exception e)
					{
						log.Error(e);
						Debug.WriteLine(e);
					}
				}

				//save the xml containg the error report details
				report.ToXml(Path.Combine(packageDir.FullName, "ReportDetails.xml"));
				//save the xslt transform file in the package to have a nice quick view of the xml error report
				ErrorReportXLST.SaveToFile(Path.Combine(packageDir.FullName, "ReportDetails.xslt"));

				//add the snapshot into the package if necessary
				if (shouldAddSnapshot)
				{
					DirectoryInfo dataDir = packageDir.CreateSubdirectory("Data");
					if (File.Exists(report.LastSnapshot))
					{
						File.Copy(report.LastSnapshot,
						          Path.Combine(dataDir.FullName, Path.GetFileName(report.LastSnapshot)));
					}

					foreach (string commandLog in report.CommandLogs)
					{
						if (File.Exists(commandLog))
						{
							File.Copy(commandLog,
							          Path.Combine(dataDir.FullName, Path.GetFileName(commandLog)));
						}
					}

          //add config into the package
          DirectoryInfo configDir = packageDir.CreateSubdirectory("Config");
          foreach (DirectoryInfo cfg in report.ConfigFolders)
          {
            if(!cfg.Exists)
            {
              continue; 
            }
            DirectoryInfo destDir = configDir.CreateSubdirectory(cfg.Name);

            foreach (FileInfo fileInfo in cfg.GetFiles())
            {
              fileInfo.CopyTo(Path.Combine(destDir.FullName, fileInfo.Name));
            }
          }
				}

        

        DirectoryInfo logsDir = packageDir.CreateSubdirectory("Logs");

        if (Directory.Exists(report.LogsDirectory))
        {
          string[] logFiles = Directory.GetFiles(report.LogsDirectory);
          foreach (string logFile in logFiles)
          {
            File.Copy(logFile,
                    Path.Combine(logsDir.FullName, Path.GetFileName(logFile)));
          }
        }

				//create the zip package in processing folder
				FastZip zip = new FastZip();
				zip.CreateEmptyDirectories = true;

				string zipFileFullName = Path.Combine(tools.ProcessingFolderPath, packageName  + ".zip");

				zip.CreateZip(zipFileFullName, packageDir.FullName, true, "");
				
				//detele the package folder from processing folder
				try
				{
					packageDir.Delete(true);
				}
				catch { }

				tools.MovePackageToBeUploaded(zipFileFullName);
			}
			catch (Exception ex)
			{
				log.Error(ex);
				Debug.WriteLine(ex);
			}
			finally
			{
				tools.RemoveProcessingTicket(ticket);
			}
		}

		private bool ShouldAddSnapshot()
		{
			return allTicketsList.FindAll(delegate(ReportProcessingTicket processingTicket) { return processingTicket.HasSnapshot; }).Count == 0;
		}

		private bool ShouldStartJob()
		{
			if (allTicketsList.Count < tools.MaxNumberErrReport)
			{
				return true;
			}

			log.Info("This error report will not be processed.(allTicketsList.Count >= tools.MaxNumberErrReport)");
			return false;
		}
	}
}
