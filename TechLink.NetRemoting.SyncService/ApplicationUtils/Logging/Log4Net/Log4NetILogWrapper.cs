using System;
using log4net.Core;

namespace ApplicationUtils.Logging.Log4Net
{
	/// <summary>
	/// Adds calling method info to the origianl messages when logging.
	/// </summary>
	public class Log4NetILogWrapper : log4net.ILog
	{
		private readonly log4net.ILog instance = null;

		public Log4NetILogWrapper(log4net.ILog instance)
		{
			this.instance = instance;
		}

		public void Debug(object message)
		{
			instance.Debug(GetFormatedMessage(message));
		}

		public void Debug(object message, Exception exception)
		{
			instance.Debug(message, exception);
		}

		public void DebugFormat(string format, params object[] args)
		{
			instance.DebugFormat(format, args);
		}

		public void DebugFormat(IFormatProvider provider, string format, params object[] args)
		{
			instance.DebugFormat(provider, format, args);
		}

		public void Info(object message)
		{
			instance.Info(GetFormatedMessage(message));
		}

		public void Info(object message, Exception exception)
		{
			instance.Info(message, exception);
		}

		public void InfoFormat(string format, params object[] args)
		{
			instance.InfoFormat(format, args);
		}

		public void InfoFormat(IFormatProvider provider, string format, params object[] args)
		{
			instance.InfoFormat(provider, format, args);
		}

		public void Warn(object message)
		{
			instance.Warn(GetFormatedMessage(message));
		}

		public void Warn(object message, Exception exception)
		{
			instance.Warn(message, exception);
		}

		public void WarnFormat(string format, params object[] args)
		{
			instance.WarnFormat(format, args);
		}

		public void WarnFormat(IFormatProvider provider, string format, params object[] args)
		{
			instance.WarnFormat(provider, format, args);
		}

		public void Error(object message)
		{
			instance.Error(GetFormatedMessage(message));
		}

		public void Error(object message, Exception exception)
		{
			instance.Error(message, exception);
		}

		public void ErrorFormat(string format, params object[] args)
		{
			instance.ErrorFormat(format, args);
		}

		public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
		{
			instance.ErrorFormat(provider, format, args);
		}

		public void Fatal(object message)
		{
			instance.Fatal(GetFormatedMessage(message));
		}

		public void Fatal(object message, Exception exception)
		{
			instance.Fatal(message, exception);
		}

		public void FatalFormat(string format, params object[] args)
		{
			instance.FatalFormat(format, args);
		}

		public void FatalFormat(IFormatProvider provider, string format, params object[] args)
		{
			instance.FatalFormat(provider, format, args);
		}

		private string GetFormatedMessage(object originalMessage)
		{
			string methodName = Utils.GetMethodInfoFromLevel(3).Name;
			return methodName + " " + originalMessage;
		}

		public bool IsDebugEnabled
		{
			get
			{
				return instance.IsDebugEnabled;
			}
		}

		public bool IsInfoEnabled
		{
			get
			{
				return instance.IsInfoEnabled;
			}
		}

		public bool IsWarnEnabled
		{
			get
			{
				return instance.IsWarnEnabled;
			}
		}

		public bool IsErrorEnabled
		{
			get
			{
				return instance.IsErrorEnabled;
			}
		}

		public bool IsFatalEnabled
		{
			get
			{
				return instance.IsFatalEnabled;
			}
		}

		public ILogger Logger
		{
			get
			{
				return instance.Logger;
			}
		}
	}
}