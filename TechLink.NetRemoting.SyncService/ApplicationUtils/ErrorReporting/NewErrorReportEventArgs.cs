using System;

namespace ApplicationUtils.ErrorReporting
{
	public class NewErrorReportEventArgs<T> : EventArgs where T : ErrorReportBase
	{
		private readonly T errorReport = null;

		public T ErrorReport
		{
			get
			{
				return errorReport;
			}
		}


		public NewErrorReportEventArgs(T errorReport)
		{
			this.errorReport = errorReport;
		}
	}
}