using System.Diagnostics;

namespace ApplicationUtils.Logging
{
	/// <summary>
	/// Summary description for ILog.
	/// </summary>
	public interface ILog
	{
		void LogLine(TraceLevel traceLevel, string message);
		void LogLineVerbose(string message);
		void Close();
	}
}