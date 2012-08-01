using System;
using System.Collections.Generic;

namespace ApplicationUtils.ErrorReporting
{
	public interface IClientErrorReportingEngine
	{
		event EventHandler ErrorReportAvailable;
		event EventHandler<NewErrorReportEventArgs<ErrorReportBase>> NewErrorReport;

		List<ErrorReportBase> ErrorReportsList { get; }
		bool DisableErrorSending { get; set; }
		void Stop();
		void Clear();
		ErrorReportBase CreateErrorReport();
		void SendReports();
		
	}
}