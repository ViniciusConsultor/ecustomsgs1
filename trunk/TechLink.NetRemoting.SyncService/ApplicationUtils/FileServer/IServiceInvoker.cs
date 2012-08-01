using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationUtils.Utils.XMLProcessing;

namespace ApplicationUtils.Utils.FileServer
{
	public interface IServiceInvoker
	{
		void SetServiceUrl(string url);

		string CreateError(string metaZipFileName, string errorType, byte[] content);

		bool InsertSummaryInfo(string errorId, SummaryField[] summaries);

		bool UploadErrorFile(string fileName, byte[] content);

		void InitLastErrorInfo(string errorId);
	}
}
