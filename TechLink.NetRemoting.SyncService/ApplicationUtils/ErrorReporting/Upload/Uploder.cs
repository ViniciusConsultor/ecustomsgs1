//#define USE_TRACING
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml;
using ApplicationUtils.Utils;
using ApplicationUtils.Utils.FileServer;
using ApplicationUtils.Utils.XMLProcessing;
using ExceptionHandler;


namespace ApplicationUtils.ErrorReporting.Upload
{
	public class Uploder
	{
		private readonly IPackageUploadManager packageUploadManager;
		private string myServiceUrl = string.Empty;
		private static IServiceInvoker serviceInvoker = null;
		private static int maxContentLength = 2097151;
		private static string fileExt = ".zip";
		private static UploadingFiles uploadingFiles = null;

		public Uploder()
		{
			string xmlServiceDefinedPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
			                                                      "ServiceMethodsDefined.xml");

			XMLProcessing xmlProcessing= new XMLProcessing(xmlServiceDefinedPath);
			XmlNodeList nodeList = xmlProcessing.GetNodeList("/Services/Service");
			if(nodeList.Count>0)
			{
				foreach (var list in nodeList)
				{
					bool retValue = false;
					if(bool.TryParse(((XmlNode)list).Attributes["Active"].Value,out retValue))
					{
						if (retValue)
						{
							myServiceUrl = ((XmlNode)list).Attributes["Url"].Value;
							maxContentLength = int.Parse(((XmlNode)list).Attributes["MaxContentLengthSupporting"].Value);
							fileExt = ((XmlNode)list).Attributes["FileExt"].Value;
							break;	
						}
					}
				}
			}
		}

		public Uploder(IPackageUploadManager packageUploadManager):this()
		{
			this.packageUploadManager = packageUploadManager;
		}

		public void TryDoUploads()
		{
			int k = 100;

			string errorType = string.Empty;
			string metaFileName = string.Empty;
			SummaryField[] summaryItems = new SummaryField[0];
			string[] filesUploading = new string[0];
      
			PackageForUpload packageForUpload = packageUploadManager.GetPackageForUpload(maxContentLength, fileExt, out metaFileName,
			                                                                             out errorType, out summaryItems,
			                                                                             out filesUploading);
			//ReLoad uploading queue
			string uploadingQueueFileName = string.Empty;
			if(filesUploading.Length>0)
			{
				uploadingQueueFileName = System.IO.Path.GetDirectoryName(filesUploading[0]);
				uploadingQueueFileName = uploadingQueueFileName.Substring(0, uploadingQueueFileName.LastIndexOf(@"\"));
				uploadingQueueFileName = System.IO.Path.Combine(uploadingQueueFileName, "UploadingQueue.xml");

				if (System.IO.File.Exists(uploadingQueueFileName))
					uploadingFiles = UploadingFileManager.LoadUploadingInfo(uploadingQueueFileName);	
			}
			
			while (k-- > 0 && packageForUpload != null)
			{
				string errorID = null;
				try
				{
					if (serviceInvoker == null)
					{
						serviceInvoker = new WebServiceInvoker();
						serviceInvoker.SetServiceUrl(myServiceUrl);
					}

					if (filesUploading.Length > 0)
					{
						errorID = null;

						if (uploadingFiles != null)
							errorID = uploadingFiles.GetErrorIDByFileName(filesUploading[0]);
						
						if(errorID == null)
						{
							errorID = serviceInvoker.CreateError(metaFileName, errorType, packageForUpload.ShortVersion);	
						}
						else
						{
							serviceInvoker.InitLastErrorInfo(errorID);
						}
            
						if (errorID != null)
						{

							if (uploadingFiles == null)
							{
								uploadingFiles = new UploadingFiles(errorID, filesUploading);
							}
							else
							{
								uploadingFiles.AddUploadingFiles(errorID, filesUploading);
							}

							//Save the Queue before upload data
							UploadingFileManager.SaveUploadingInfo(uploadingFiles, uploadingQueueFileName);

							if(summaryItems.Length > 0)
								serviceInvoker.InsertSummaryInfo(errorID, summaryItems);

							#region Upload File

							int uploadedFilesCount = 0;
								for (int i = 0; i < filesUploading.Length; i++)
								{
									string uploading = filesUploading[i];

									//Thread thread = new Thread(new ParameterizedThreadStart(ThreadUploadFile));
									//thread.Start(errorID, uploading, FileUtils.GetFileContent(uploading));

									int numberOfUploadingTimes = 10;
									bool resultUploading = false;
									int times = 0;
									while (times < numberOfUploadingTimes && !resultUploading)
									{
										times++;
										resultUploading = serviceInvoker.UploadErrorFile(System.IO.Path.GetFileName(uploading), FileUtils.GetFileContent(uploading));
									}

									if (!resultUploading)
									{
										//packageUploadManager.PutPackageBack(packageForUpload.PackageName);
									}
									else
									{
										uploadedFilesCount++;
										uploadingFiles.MarkUploaded(errorID, uploading);
										System.IO.File.Delete(uploading);
									}
								}
							#endregion
								if (uploadedFilesCount > 0)
									packageUploadManager.MarkFinishedUpload(packageForUpload.PackageName);
							//Save the Queue again
							UploadingFileManager.SaveUploadingInfo(uploadingFiles, uploadingQueueFileName);
						}
					}
				}
				catch (Exception exception)
				{
                    try
                    {
                        //If the error processed but did not upload any file, we have to push back to upload later.
                        if (errorID == null)
                        {
                            packageUploadManager.PutPackageBack(packageForUpload.PackageName);
                            errorID = "null";
                        }
					else
					{
						packageUploadManager.MarkFinishedUpload(packageForUpload.PackageName);
					}
                        ProcessException.Handle(exception,"ApplicationUtils.ErrorReporting.Upload.Uploader.TryDoUpLoad()",
                                                          string.Format("Uploder.TryDoUploads({0}) Error", errorID));
                    }
                    catch {
                    }
				}
				packageForUpload = packageUploadManager.GetPackageForUpload(maxContentLength, fileExt, out metaFileName, out errorType,
				                                                            out summaryItems, out filesUploading);				
			}

			return;
		}

		private void ThreadUploadFile(IServiceInvoker serviceInvoker, string errorId, string fileName, byte[] content)
		{
			int numberOfUploadingTimes = 10;
			bool resultUploading = false;
			int times = 0;
			while (times < numberOfUploadingTimes && !resultUploading)
			{
				times++;
				resultUploading = serviceInvoker.UploadErrorFile(System.IO.Path.GetFileName(fileName), content);
			}

			if (!resultUploading)
			{
				//packageUploadManager.PutPackageBack(packageForUpload.PackageName);
			}
			else
			{
				uploadingFiles.MarkUploaded(errorId, fileName);
				System.IO.File.Delete(fileName);
			}
		}


		//public void TryDoUploads()
		//{
		//  int k = 10;
		//  PackageForUpload packageForUpload = packageUploadManager.GetPackageForUpload();
		//  while (k-- > 0 && packageForUpload != null)
		//  {
		//    Tracing.TraceCall("Trying to upload " + packageForUpload.PackageName);
		//    if (WebFilePoster.UploadErrorReportFile(packageForUpload.PackageContent, packageForUpload.PackageName))
		//    {
		//      Tracing.TraceCall("Upload of " + packageForUpload.PackageName + " was succesfull");
		//      packageUploadManager.MarkFinishedUpload(packageForUpload.PackageName);
		//    }
		//    else if ((packageForUpload.ShortVersion != null) && (WebFilePoster.UploadErrorReportFile(packageForUpload.ShortVersion, packageForUpload.ShortVersionPackageName)))
		//    {
		//      Tracing.TraceCall("Upload of " + packageForUpload.PackageName + " was succesfull in SHORT VERSION");
		//      packageUploadManager.MarkFinishedUpload(packageForUpload.PackageName);
		//    }
		//    else
		//    {
		//      Tracing.TraceCall("Upload of " + packageForUpload.PackageName + " was NOT succesfull");
		//      packageUploadManager.PutPackageBack(packageForUpload.PackageName);
		//    }
		//    packageForUpload = packageUploadManager.GetPackageForUpload();
		//  }
		//}
	}
}

