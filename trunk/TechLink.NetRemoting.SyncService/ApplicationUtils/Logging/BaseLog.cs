using System;
using System.Diagnostics;

namespace ApplicationUtils.Logging
{
	/// <summary>
	/// Summary description for BaseLog.
	/// </summary>
	public abstract class BaseLog : ILog
	{
		private TraceLevel traceLevel = TraceLevel.Info;
		private readonly bool showMethodInfo = false;

		public virtual TraceLevel TraceLevel
		{
			get
			{
				return traceLevel;
			}
			set
			{
				traceLevel = value;
			}
		}

		public BaseLog(TraceLevel traceLevel)
		{
			this.traceLevel = traceLevel;
		}

		public BaseLog()
		{
		}

		protected BaseLog(bool showMethodInfo)
		{
			this.showMethodInfo = showMethodInfo;
		}

		public virtual void LogLine(TraceLevel traceLevel, string message)
		{
			if (traceLevel <= this.traceLevel)
			{
				if (showMethodInfo)
				{
					message = Utils.GetTraceCallMessage(3) + " message";
				}

				message = "[" + Enum.GetName(typeof (TraceLevel), traceLevel) + "]  " + message;
				LogLine(message);
			}
		}

		public void LogLineVerbose(string message)
		{
			LogLine(TraceLevel.Verbose, message);
		}

		public abstract void Close();

		protected abstract void LogLine(string message);
	}
}