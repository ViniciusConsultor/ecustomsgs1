using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using ApplicationUtils.Utils;
using ApplicationUtils.Utils.XMLProcessing;

namespace ApplicationUtils.ErrorReporting.Upload
{
    [Serializable]
    public class ProcessingJobsSharedTools
    {
        private readonly object synhObj_reportsToUploadFolder = new object();
        private readonly DirectoryInfo processingFolder;
        private readonly DirectoryInfo reportsToUploadFolder;
        private readonly DirectoryInfo uploadingReportsFolder;

        private readonly object synhObj_lastSentItemsFileInfo = new object();
        private readonly FileInfo lastSentItemsFileInfo;

        //number of days interval for which to send the same kind of error report more then once
        private readonly int intervalOfDays = -1;
        //the maximum number of error reports of the same kind in the interval;
        private readonly int maxNumberErrReport = -1;
        private readonly bool addSnapshotToReport = true;

        private readonly object synhObj_inProcessingReportsList = new object();
        private readonly List<ReportProcessingTicket> inProcessingReports = new List<ReportProcessingTicket>();

        public ProcessingJobsSharedTools(int intervalOfDays, int maxNumberErrReport, bool addSnapshotToReport,
            DirectoryInfo processingFolder, DirectoryInfo reportsToUploadFolder,
            DirectoryInfo uploadingReportsFolder, FileInfo lastSentItemsFileInfo)
        {
            this.intervalOfDays = intervalOfDays;
            this.maxNumberErrReport = maxNumberErrReport;
            this.addSnapshotToReport = addSnapshotToReport;
            this.processingFolder = processingFolder;
            this.reportsToUploadFolder = reportsToUploadFolder;
            this.uploadingReportsFolder = uploadingReportsFolder;
            this.lastSentItemsFileInfo = lastSentItemsFileInfo;
        }

        public int IntervalOfDays
        {
            get
            {
                return intervalOfDays;
            }
        }

        public int MaxNumberErrReport
        {
            get
            {
                return maxNumberErrReport;
            }
        }

        public bool AddSnapshotToReport
        {
            get
            {
                return addSnapshotToReport;
            }
        }

        public string ProcessingFolderPath
        {
            get
            {
                return processingFolder.FullName;
            }
        }

        public string GetReportHashCode(ServerErrorReport serverErrorReport)
        {
            //the hashcode of the error report is the hascode of the stack trace string. 
            //2 errors with the same stack trace will have the same error report
            return ((uint)(serverErrorReport.GetHashCode())).ToString();
        }

        public void AddProcessingTicket(ReportProcessingTicket reportProcessingTicket)
        {
            lock (synhObj_inProcessingReportsList)
            {
                inProcessingReports.Add(reportProcessingTicket);
            }
        }

        public void RemoveProcessingTicket(ReportProcessingTicket reportProcessingTicket)
        {
            lock (synhObj_inProcessingReportsList)
            {
                inProcessingReports.Remove(reportProcessingTicket);
            }
        }

        public ReportProcessingTicket[] GetTicketsOfTypeInProcessing(string hashcode)
        {
            lock (synhObj_inProcessingReportsList)
            {
                List<ReportProcessingTicket> res = new List<ReportProcessingTicket>();
                foreach (ReportProcessingTicket item in inProcessingReports)
                {
                    if (item.ReportHashcode == hashcode)
                    {
                        res.Add(item);
                    }
                }
                return res.ToArray();
            }
        }

        public ReportProcessingTicket[] GetTicketsOfTypeAlreadySent(string hashcode)
        {
            List<ReportProcessingTicket> sentItemList = GetSentItemList();
            List<ReportProcessingTicket> res = new List<ReportProcessingTicket>();
            foreach (ReportProcessingTicket item in sentItemList)
            {
                if (item.ReportHashcode == hashcode)
                {
                    res.Add(item);
                }
            }
            return res.ToArray();
        }

        public ReportProcessingTicket[] GetAllUploadingTicketsOfType(string hashcode)
        {
            List<ReportProcessingTicket> uploadingTickets = new List<ReportProcessingTicket>(GetAllUploadingTickets());
            List<ReportProcessingTicket> res = new List<ReportProcessingTicket>();
            foreach (ReportProcessingTicket item in uploadingTickets)
            {
                if (item.ReportHashcode == hashcode)
                {
                    res.Add(item);
                }
            }
            return res.ToArray();
        }

        public ReportProcessingTicket[] GetAllUploadingTickets()
        {
            List<ReportProcessingTicket> tickets = new List<ReportProcessingTicket>();

            lock (uploadingReportsFolder)
            {
                FileInfo[] files = this.uploadingReportsFolder.GetFiles("*err*.zip");

                foreach (FileInfo reportPackage in files)
                {
                    ReportProcessingTicket ticket = new ReportProcessingTicket();
                    ticket.InProcessing = true;
                    ticket.IsSent = false;
                    ticket.PackageName = reportPackage.Name;
                    ticket.ReportHashcode = GetHashCodeFromPackageFileName(reportPackage.Name);
                    ticket.HasSnapshot = PackageHasSnapshot(reportPackage.Name);
                    tickets.Add(ticket);
                }
            }

            return tickets.ToArray();
        }

        public void AddSentPackage(string packageName)
        {
            lock (synhObj_lastSentItemsFileInfo)
            {
                List<ReportProcessingTicket> sentItemList = GetSentItemList();
                ReportProcessingTicket ticket = new ReportProcessingTicket();
                ticket.DateSent = DateTime.Now;
                ticket.InProcessing = false;
                ticket.IsSent = true;
                ticket.PackageName = packageName;
                ticket.ReportHashcode = GetHashCodeFromPackageFileName(packageName);
                ticket.HasSnapshot = PackageHasSnapshot(packageName);
                sentItemList.Add(ticket);
                XmlSerializationUtils<List<ReportProcessingTicket>>.Serialize(sentItemList, lastSentItemsFileInfo.FullName);
            }
        }

        public ReportProcessingTicket[] GetTicketsOfTypeToBeUploaded(string hashcode)
        {
            List<ReportProcessingTicket> toBeUploade = new List<ReportProcessingTicket>(GetTicketsToBeUploaded());
            List<ReportProcessingTicket> res = new List<ReportProcessingTicket>();
            foreach (ReportProcessingTicket item in toBeUploade)
            {
                if (item.ReportHashcode == hashcode)
                {
                    res.Add(item);
                }
            }
            return res.ToArray();
        }

        public ReportProcessingTicket[] GetTicketsToBeUploaded()
        {
            List<ReportProcessingTicket> tickets = new List<ReportProcessingTicket>();

            lock (synhObj_reportsToUploadFolder)
            {
                List<FileInfo> files = new List<FileInfo>();
                files.AddRange(this.reportsToUploadFolder.GetFiles("*err*.zip"));

                foreach (FileInfo reportPackage in files)
                {
                    ReportProcessingTicket ticket = new ReportProcessingTicket();
                    ticket.IsSent = false;
                    ticket.PackageName = reportPackage.Name;
                    ticket.ReportHashcode = GetHashCodeFromPackageFileName(reportPackage.Name);
                    ticket.HasSnapshot = PackageHasSnapshot(reportPackage.Name);
                    tickets.Add(ticket);
                }
            }

            return tickets.ToArray();
        }

        private bool PackageHasSnapshot(string packageFileName)
        {
            return packageFileName.Contains("-s");
        }

        //the hashcode is the last part
        private string GetHashCodeFromPackageFileName(string packageFileName)
        {
            try
            {
                packageFileName = Path.GetFileNameWithoutExtension(packageFileName);
                int indexOfID = packageFileName.IndexOf("ID_") + 3;
                int indexOf_ = packageFileName.IndexOf("-", indexOfID);
                if (indexOf_ < 0)
                {
                    indexOf_ = packageFileName.Length - 1;
                }
                return packageFileName.Substring(indexOfID, indexOf_ - indexOfID);
            }
            catch { }
            return string.Empty;

        }

        private List<ReportProcessingTicket> GetSentItemList()
        {
            lock (synhObj_lastSentItemsFileInfo)
            {
                //read last sent reports list from the disk
                List<ReportProcessingTicket> lastSentMinireports = null;
                try
                {
                    lastSentMinireports = XmlSerializationUtils<List<ReportProcessingTicket>>.DeserializeObj(lastSentItemsFileInfo.FullName);
                }
                catch (Exception)
                {
                    lastSentMinireports = new List<ReportProcessingTicket>();
                    FileUtils.TryDelete(lastSentItemsFileInfo.FullName);
                }

                //remove all sent reports from the list if they are older then 'intervalOfDays' days.
                //if you change here, make sure you change also in GenericRemoteServer.General.GenericServer.MarkReportSent
                DateTimeUtils.TimeInterval interval = new DateTimeUtils.TimeInterval(DateTime.Now.AddDays(-intervalOfDays),
                                                                                                                                                         DateTime.Now, true);
                List<ReportProcessingTicket> toRemove = new List<ReportProcessingTicket>();

                lastSentMinireports.ForEach(delegate(ReportProcessingTicket item)
                {
                    if (!interval.Contains(item.DateSent))
                    {
                        toRemove.Add(item);
                    }
                });

                toRemove.ForEach(delegate(ReportProcessingTicket item) { lastSentMinireports.Remove(item); });

                XmlSerializationUtils<List<ReportProcessingTicket>>.Serialize(lastSentMinireports, lastSentItemsFileInfo.FullName);

                return lastSentMinireports;
            }
        }

        public void MovePackageToBeUploaded(string fileFullPath)
        {
            lock (reportsToUploadFolder)
            {
                string fileName = Path.GetFileName(fileFullPath);
                try
                {
                    File.Move(fileFullPath, Path.Combine(this.reportsToUploadFolder.FullName, fileName));
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

        public void DeleteUploadedPackage(string packageName)
        {
            lock (uploadingReportsFolder)
            {
                FileUtils.TryDelete(Path.Combine(uploadingReportsFolder.FullName, packageName));
            }
        }


        public string PickPackageForUpload()
        {
            lock (reportsToUploadFolder)
            {
                string packageName = null;

                List<FileInfo> files = new List<FileInfo>();
                //files.AddRange(this.reportsToUploadFolder.GetFiles("*err*.zip")); Hacked by Huypt to make some test upload data through WebService
                files.AddRange(this.reportsToUploadFolder.GetFiles("*err*.*"));
#if !DEBUG
				files.AddRange(this.reportsToUploadFolder.GetFiles("*err*.zip"));
#endif
                files.AddRange(this.reportsToUploadFolder.GetFiles("*issue*.zip"));
                if (files.Count > 0)
                {
                    packageName = files[0].Name;
                }
                else
                {
                    return null;
                }

                FileInfo fi = files[0];

                lock (uploadingReportsFolder)
                {
                    if (fi.Exists)
                    {
                        try
                        {
                            fi.MoveTo(Path.Combine(uploadingReportsFolder.FullName, packageName));
                            return fi.FullName;
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e);
                        }
                    }
                }

                return null;

            }
        }
    }
}
