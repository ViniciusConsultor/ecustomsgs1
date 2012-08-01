using System.Diagnostics;
using log4net;

namespace ApplicationUtils.Logging.Log4Net
{
	/// <summary>
	/// Uses LogManager.GetLogger method to retreive log4net.ILog instances. If "useMethodInfoWhenLogging" booleanSwitch is enabled in config file,
	/// then the retreived log4net.ILog is wrapped into a Log4NetILogWrapper whitch will add the callding method name tot he original message to be logged.
	/// If "disableLog4NetLogging"  booleanSwitch is enabled in config file, the retreived log4net.ILog will be a NullLog4NetILog instance. 
	/// Use GetPermanentLog to obtain a log instance that cannot be disabled by "disableLog4NetLogging" switch.
	/// </summary>
	public class Log4NetManager
	{
		private static readonly BooleanSwitch useMethodInfoWhenLogging = new BooleanSwitch("useMethodInfoWhenLogging", "useMethodInfoWhenLogging");
		private static readonly BooleanSwitch disableLog4NetLogging = new BooleanSwitch("disableLog4NetLogging", "disableLog4NetLogging");

		private static bool initialized = false;

		public static log4net.ILog GetLog(string name)
		{
			if (!initialized)
			{
				Initialize();
			}
			if (disableLog4NetLogging.Enabled)
			{
				return new NullLog4NetILog();
			}
			return _GetLog(name);
		}

		public static void Initialize()
		{
			if (initialized)
			{
				return;
			}
			if (useMethodInfoWhenLogging.Enabled)
			{
				GlobalContext.Properties["currentMethod"] = new CurrentMethod();
			}
		}

		/// <summary>
		/// A permanent log cannod by disabled by using the "disableLog4NetLogging" boolean switch.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public static log4net.ILog GetPermanentLog(string name)
		{
			if (!initialized)
			{
				Initialize();
			}
			return _GetLog(name);
		}

		/// <summary>
		/// Gets the log using as name the DeclaringType fot he calling method
		/// </summary>
		/// <returns></returns>
		public static log4net.ILog GetLog()
		{
			if (disableLog4NetLogging.Enabled)
			{
				return new NullLog4NetILog();
			}
			return _GetLog(Utils.GetMethodInfoFromLevel(2).DeclaringType.FullName);
		}

		private static log4net.ILog _GetLog(string name)
		{
			if (!initialized)
			{
				Initialize();
			}
			return LogManager.GetLogger(name);
		}
	}
}