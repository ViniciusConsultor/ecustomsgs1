using System;
using ApplicationUtils.PromovaErrorService;
using ApplicationUtils.Utils.XMLProcessing;

namespace ApplicationUtils.Utils.FileServer
{
	public class WebServiceInvoker : IServiceInvoker
	{
		private string _url = string.Empty;
		private PromovaService promovaService = null;
		private ErrorInfo lastErrorInfo = null;


		public void SetServiceUrl(string url)
		{
			_url = url;
			promovaService = new PromovaService();
			promovaService.Url = _url;
			promovaService.UseDefaultCredentials = true;
		}

		public string CreateError(string metaZipFileName, string errorType, byte[] content)
		{
			ErrorInfo errorInfo = new ErrorInfo();
			errorInfo.CreationDate = DateTime.Now;
			errorInfo.IsDeleted = false;
			errorInfo.IsDownloaded = false;
			errorInfo.MetaZipFile = metaZipFileName;
			errorInfo.Type = (errorType.ToLower().Equals("client") ? 0 : 1);
			errorInfo.Description = "";

			lastErrorInfo =
				promovaService.CreateError(errorInfo, content);
			string errorIdRet = null;
			if (lastErrorInfo != null)
			{
				errorIdRet = lastErrorInfo.ErrorId;
			}
			return errorIdRet;
		}

		public void InitLastErrorInfo(string errorId)
		{
			lastErrorInfo =
				promovaService.GetErrorInfo(errorId);
		}

		public bool InsertSummaryInfo(string errorId, SummaryField[] summaries)
		{
			SummaryItem[] summaryItems = new SummaryItem[summaries.Length];

			int i = 0;
			foreach (SummaryField field in summaries)
			{
				summaryItems[i] = new SummaryItem();
				summaryItems[i].Key = field.Name;
				summaryItems[i].Value = field.Value;
				summaryItems[i].DataType = field.Type;
				i++;
			}

			ErrorShortInfo errorShortInfo = new ErrorShortInfo();
			errorShortInfo.ErrorId = errorId;
			errorShortInfo.Summary = summaryItems;

			return (promovaService.InsertSummaryInfo(errorShortInfo) == summaryItems.Length ? true : false);
		}

		public bool UploadErrorFile(string fileName, byte[] content)
		{
			if (lastErrorInfo == null) return false;
			bool result = promovaService.UploadErrorFile(fileName, lastErrorInfo, content);
			return result;
		}
	}
}
