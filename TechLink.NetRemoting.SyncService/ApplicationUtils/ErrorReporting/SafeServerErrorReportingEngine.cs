using System;
using System.Collections;
using ApplicationUtils.Logging.Log4Net;
using log4net;

namespace ApplicationUtils.ErrorReporting
{
	internal class SafeServerErrorReportingEngine : IServerErrorReportingEngine
	{
		private readonly IServerErrorReportingEngine instance = null;
		private static readonly ILog errorLog = Log4NetManager.GetPermanentLog("ErrorReportingLog");

		private SafeServerErrorReportingEngine(IServerErrorReportingEngine instance)
		{
			this.instance = instance;
		}

		public static IServerErrorReportingEngine GetSafeInstance(IServerErrorReportingEngine instance)
		{
			return new SafeServerErrorReportingEngine(instance);
		}

		public void CreateServerErrorReport(ErrorReportBase clientErrorReport)
		{
			try
			{
				instance.CreateServerErrorReport(clientErrorReport);
			}
			catch (Exception e)
			{
				errorLog.Error(e);
#if DEBUG
				throw e;
#endif
			}
		}

		public Hashtable ProcessingErrorReportFiles
		{
			get
			{
				return instance.ProcessingErrorReportFiles;
			}
		}

		public event EventHandler<NewErrorReportEventArgs<ServerErrorReport>> NewErrorReport
		{
			add
			{
				try
				{
					instance.NewErrorReport += value;
				}
				catch (Exception e)
				{
					errorLog.Error(e);
#if DEBUG
					throw e;
#endif
				}
			}
			remove
			{
				try
				{
					instance.NewErrorReport -= value;
				}
				catch (Exception e)
				{
					errorLog.Error(e);
#if DEBUG
					throw e;
#endif
				}
			}
		}
	}
}