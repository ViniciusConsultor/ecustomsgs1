using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ApplicationUtils.Logging.Log4Net;
using ApplicationUtils.Utils.ZipUtils.Zip;
using log4net;
using ApplicationUtils.Utils;
using ApplicationUtils.Utils.XMLProcessing;

namespace ApplicationUtils.ErrorReporting.Upload
{
    public interface IPackageUploadManager
    {
        PackageForUpload GetPackageForUpload();
        PackageForUpload GetPackageForUpload(int maxContentLength, string fileExt, out string metaFileName, out string errorType, out SummaryField[] summaryItems, out string[] splittedFiles);
        void MarkFinishedUpload(string packageName);
        void PutPackageBack(string packageName);
    }
    [Serializable]
    public class PackageUploadManager : IPackageUploadManager
    {
        private static readonly ILog log = Log4NetManager.GetPermanentLog("ErrorReportingLog");
        private static PackageUploadManager instance;

        public static PackageUploadManager Instance
        {
            get
            {
                return instance;
            }
        }

        public static void Initialize(ProcessingJobsSharedTools tools)
        {
            instance = new PackageUploadManager(tools);
        }

        private readonly object synchRoot = new object();
        private ProcessingJobsSharedTools tools;

        //full file path -> DateTime when upload started
        private Hashtable uploadingPackages = Hashtable.Synchronized(new Hashtable());

        private PackageUploadManager(ProcessingJobsSharedTools tools)
        {
            this.tools = tools;
        }

        public PackageForUpload GetPackageForUpload()
        {
            lock (synchRoot)
            {
                RecycleTimeoutUploads();
                if (uploadingPackages.Count > 2)
                {
                    return null;
                }
                string fullFilePath = tools.PickPackageForUpload();
                if (fullFilePath == null)
                {
                    return null;
                }

                byte[] packageContent = FileUtils.GetFileContent(fullFilePath);
                byte[] shortVersionContent = null;

                try
                {
                    //if the size of the package is bigger then let's say 100.000 bytes, create a short-version of the package too

                    if (packageContent.Length > 100000)
                    {
                        FastZip zipFile = new FastZip();

                        //get a temporary directory name
                        string tmpDirName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

                        //unzip the archive
                        zipFile.ExtractZip(fullFilePath, tmpDirName, "");

                        //add -short to the name of the package
                        string shortFileName = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(fullFilePath) + "-short.zip");


                        try
                        {
                            DirectoryInfo tmpLogsDir = new DirectoryInfo(Path.Combine(tmpDirName, "Logs"));
                            if (tmpLogsDir.Exists)
                            {
                                FileInfo[] files = tmpLogsDir.GetFiles();
                                foreach (FileInfo logFile in files)
                                {
                                    logFile.CopyTo(Path.Combine(tmpDirName, logFile.Name));
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            log.Error(e);
                            Debug.Fail(e.Message);
                        }

                        //create a new package, but without Data folder
                        zipFile.CreateZip(shortFileName, tmpDirName, false, string.Empty);

                        shortVersionContent = FileUtils.GetFileContent(shortFileName);

                        try
                        {
                            //clean up
                            Directory.Delete(tmpDirName, true);
                            File.Delete(shortFileName);
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex);
                            Debug.Fail(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    Debug.Fail(ex.Message);
                }

                uploadingPackages.Add(fullFilePath, DateTime.Now);
                PackageForUpload packageForUpload = new PackageForUpload(Path.GetFileName(fullFilePath), packageContent, shortVersionContent);

                return packageForUpload;
            }
        }

        public PackageForUpload GetPackageForUpload(int maxContentLength, string fileExt, out string metaFileName, out string errorType, out SummaryField[] summaryItems, out string[] splittedFiles)
        {
            lock (synchRoot)
            {
                #region Validate info
                RecycleTimeoutUploads();

                metaFileName = null;
                summaryItems = new SummaryField[0];
                errorType = string.Empty;
                splittedFiles = new string[0];
                byte[] shortVersionContent = null;

                PackageForUpload packageForUpload = null;

                string fullFilePath = tools.PickPackageForUpload();
                if (fullFilePath == null)
                {
                    return null;
                }

                if (System.IO.Path.GetExtension(fullFilePath).ToLower().Equals(fileExt.ToLower()))
                {
                    uploadingPackages.Add(fullFilePath, DateTime.Now);
                    shortVersionContent = FileUtils.GetFileContent(fullFilePath);
                    packageForUpload = new PackageForUpload(Path.GetFileName(fullFilePath), null, shortVersionContent);
                    splittedFiles = new string[1];
                    splittedFiles[0] = fullFilePath;
                    return packageForUpload;

                }
                string storeFolder = Path.GetDirectoryName(fullFilePath);
                #endregion

                byte[] packageContent = FileUtils.GetFileContent(fullFilePath);


                try
                {
                    FastZip zipFile = new FastZip();

                    //get a temporary directory name
                    string tmpDirName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

                    //unzip the archive
                    zipFile.ExtractZip(fullFilePath, tmpDirName, "");

                    string xmlFilename = System.IO.Path.Combine(tmpDirName, "ReportDetails.xml");

                    //add -short to the name of the package
                    metaFileName = Path.GetFileNameWithoutExtension(fullFilePath) + "-meta.zip";
                    string shortFilePath = Path.Combine(Path.GetTempPath(), metaFileName);

                    #region Get Summary information from ReportDetails.xml
                    string xmlDefineFields = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SummaryFields.xml");

                    XmlMetaProcessing metaProcessing = new XmlMetaProcessing(xmlDefineFields, xmlFilename);
                    summaryItems = metaProcessing.SummaryFields;

                    string snapShotFolderName = System.IO.Path.Combine(tmpDirName, "Data");

                    string hasSnapShot = "False";
                    if (System.IO.Directory.Exists(snapShotFolderName))
                        hasSnapShot = "True";


                    if (summaryItems.Length > 0)
                    {
                        foreach (SummaryField item in summaryItems)
                        {
                            if (item.Name.ToLower().Equals("errorlocation"))
                            {
                                errorType = (item.Value != null ? item.Value.ToString() : "");
                            }
                            else if (item.Name.ToLower().Equals("hassnapshot"))
                            {
                                item.Value = hasSnapShot;
                            }
                        }
                    }

                    #endregion

#if SHORT_INFO_INCLUDE_LOG
						try
						{
							DirectoryInfo tmpLogsDir = new DirectoryInfo(Path.Combine(tmpDirName, "Logs"));
							if (tmpLogsDir.Exists)
							{
								FileInfo[] files = tmpLogsDir.GetFiles();
								foreach (FileInfo logFile in files)
								{
									logFile.CopyTo(Path.Combine(tmpDirName, logFile.Name));
								}
							}
						}
						catch (Exception e)
						{
							log.Error(e);
							Debug.Fail(e.Message);
						}
#endif
                    //create a new package, but without Data folder - this is Meta package
                    zipFile.CreateZip(shortFilePath, tmpDirName, false, string.Empty);

                    shortVersionContent = FileUtils.GetFileContent(shortFilePath);
                    if (packageContent.Length > maxContentLength)
                    {
                        splittedFiles = SplitFile(maxContentLength, fullFilePath, fileExt);
                    }
                    else
                    {
                        splittedFiles = new string[1];
                        splittedFiles[0] = fullFilePath;
                    }

                    try
                    {
                        //clean up
                        Directory.Delete(tmpDirName, true);
                        File.Delete(shortFilePath);
                        //Delete the main file after splited
                        File.Delete(fullFilePath);
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        Debug.Fail(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    Debug.Fail(ex.Message);
                }

                uploadingPackages.Add(fullFilePath, DateTime.Now);
                packageForUpload = new PackageForUpload(Path.GetFileName(fullFilePath), null, shortVersionContent);

                return packageForUpload;
            }
        }

        public void MarkFinishedUpload(string packageName)
        {
            tools.DeleteUploadedPackage(packageName);
            tools.AddSentPackage(packageName);

            lock (synchRoot)
            {
                List<string> packageToRemove = new List<string>();
                foreach (DictionaryEntry entry in uploadingPackages)
                {
                    string packageFullPath = (string)entry.Key;
                    if (Path.GetFileName(packageFullPath) == packageName)
                    {
                        packageToRemove.Add(packageFullPath);
                    }
                }

                foreach (string package in packageToRemove)
                {
                    uploadingPackages.Remove(package);
                }
            }
        }

        public void PutPackageBack(string packageName)
        {
            lock (synchRoot)
            {
                List<string> packageToRemove = new List<string>();
                foreach (DictionaryEntry entry in uploadingPackages)
                {
                    string packageFullPath = (string)entry.Key;
                    if (Path.GetFileName(packageFullPath) == packageName)
                    {
                        packageToRemove.Add(packageFullPath);
                    }
                }

                foreach (string package in packageToRemove)
                {
                    uploadingPackages.Remove(package);
                    tools.MovePackageToBeUploaded(package);
                }
            }
        }

        private void RecycleTimeoutUploads()
        {
            lock (synchRoot)
            {
                List<string> timeoutUploads = new List<string>();
                foreach (DictionaryEntry entry in uploadingPackages)
                {
                    string packageFullPath = (string)entry.Key;
                    DateTime timeUploadStarted = (DateTime)entry.Value;
                    TimeSpan timeSpan = DateTime.Now - timeUploadStarted;
                    if (timeSpan.TotalMinutes > 30)
                    {
                        timeoutUploads.Add(packageFullPath);
                    }
                }

                foreach (string timeoutUploadPackageFullPath in timeoutUploads)
                {
                    uploadingPackages.Remove(timeoutUploadPackageFullPath);
                    tools.MovePackageToBeUploaded(timeoutUploadPackageFullPath);
                }
            }
        }


        private string[] SplitFile(int maxContentLengthOfEachFile, string fileFullPath, string fileExt)
        {
            FileStream fs = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read);

            int numberOfFiles = (int)Math.Ceiling((double)fs.Length / maxContentLengthOfEachFile);

            if (numberOfFiles * maxContentLengthOfEachFile < fs.Length)
            {
                numberOfFiles++;
            }

            int sizeOfEachFile = maxContentLengthOfEachFile;

            string baseFileName = Path.GetFileNameWithoutExtension(fileFullPath);
            string extension = fileExt;

            string[] files = new string[numberOfFiles];

            for (int j = 1; j <= numberOfFiles; j++)
            {
                int i = j - 1;
                string fileName = Path.GetDirectoryName(fileFullPath) + "\\" + baseFileName + "." +
                                                    j.ToString().PadLeft(5 - j.ToString().Length, Convert.ToChar("0")) + extension;
                files[i] = fileName;
                FileStream outputFile = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                int bytesRead = 0;
                byte[] buffer = new byte[sizeOfEachFile];

                if ((bytesRead = fs.Read(buffer, 0, sizeOfEachFile)) > 0)
                {
                    outputFile.Write(buffer, 0, bytesRead);
                }
                outputFile.Close();
            }
            fs.Close();
            return files;
        }
    }
}
