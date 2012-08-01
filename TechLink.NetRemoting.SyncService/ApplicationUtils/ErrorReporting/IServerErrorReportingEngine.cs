using System;
using System.Collections;

namespace ApplicationUtils.ErrorReporting
{
	public interface IServerErrorReportingEngine
	{
		event EventHandler<NewErrorReportEventArgs<ServerErrorReport>> NewErrorReport;
		void CreateServerErrorReport(ErrorReportBase clientErrorReport);
		Hashtable ProcessingErrorReportFiles{ get;}
	}
}