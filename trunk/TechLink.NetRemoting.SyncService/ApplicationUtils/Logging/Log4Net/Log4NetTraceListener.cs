using System.Diagnostics;

namespace ApplicationUtils.Logging.Log4Net
{
	/// <summary>
	/// Summary description for Log4NetTraceListener.
	/// </summary>
	public class Log4NetTraceListener : TraceListener
	{
		private static readonly log4net.ILog log = Log4NetManager.GetLog("DebugLog");

		public override void Write(string message)
		{
			log.Info(message);
		}

		public override void WriteLine(string message)
		{
			log.Info(message);
		}
	}
}