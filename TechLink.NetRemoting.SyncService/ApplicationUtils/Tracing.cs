#define USE_TRACING
using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;

// all internal tracing uses those helpers. This makes it easy
// to change the tracing code to use log4Net or NLog or other libraries

namespace ApplicationUtils.Utils
{
	/// <summary>
	/// Tracing helper class. Uses conditional compilation to 
	///  exclude tracing code in release builds
	/// </summary>
	public sealed class Tracing
	{
		private Tracing()
		{
		}

		[Conditional("USE_TRACING")]
		private static void LogLine(string line)
		{
			Debug.WriteLine(line);
		}

		/// <summary>Method to trace the current call with an additional message</summary> 
		/// <param name="msg"> msg string to display</param>
		[Conditional("USE_TRACING")]
		public static void TraceCall(string msg)
		{
			// puts out the callstack and the msg
			try
			{
				StackTrace trace = new StackTrace();
				if (trace != null && trace.GetFrame(1) != null)
				{
					MethodBase method = trace.GetFrame(1).GetMethod();
					string threadInfo = "[" + Thread.CurrentThread.ManagedThreadId + "] ";
					string line = threadInfo + ExtractInfo(method) + ": " + msg;
					LogLine(line);
				}
				else
				{
					LogLine("Method Unknown: " + msg);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}

		/// <summary>Method to trace the caller of the current call with an additional message</summary> 
		/// <param name="msg"> msg string to display</param>
		[Conditional("USE_TRACING")]
		public static void TraceCaller(string msg)
		{
			// puts out the callstack and the msg
			try
			{
				StackTrace trace = new StackTrace();
				if (trace != null && trace.GetFrame(1) != null)
				{
					MethodBase method = trace.GetFrame(1).GetMethod();
					string line = ExtractInfo(method) + ": " + msg + "\n" + " caller is:";
					if (trace.GetFrame(2) != null)
					{
						method = trace.GetFrame(2).GetMethod();
						line += ExtractInfo(method);
					}
					LogLine(line);
				}
				else
				{
					LogLine("Method Unknown: " + msg);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}

		[Conditional("USE_TRACING")]
		public static void PrintStack(string msg)
		{
			// puts out the callstack and the msg
			try
			{
				StackTrace trace = new StackTrace();
				if (trace != null)
				{
					string threadInfo = "[" + Thread.CurrentThread.ManagedThreadId + "] ";
					string line = threadInfo + msg + "\n" + trace;
					LogLine(line);
				}
				else
				{
					LogLine("Method Unknown: " + msg);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}

		/// <summary>Method to trace the current call with an additional message</summary> 
		[Conditional("USE_TRACING")]
		public static void TraceCall()
		{
			try
			{
				StackTrace trace = new StackTrace();
				if (trace != null && trace.GetFrame(1) != null)
				{
					MethodBase method = trace.GetFrame(1).GetMethod();
					string threadInfo = "[" + Thread.CurrentThread.ManagedThreadId + "] ";
					string line = threadInfo + ExtractInfo(method);
					LogLine(line);
				}
				else
				{
					LogLine("Method Unknown: ");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
		}
        

		public static string GetTraceCallMessage(int stackLevel)
		{
			StringBuilder stringBuilder = new StringBuilder();
			try
			{
				StackTrace trace = new StackTrace();
				if (trace != null && trace.GetFrame(stackLevel) != null)
				{
					MethodBase method = trace.GetFrame(stackLevel).GetMethod();
					string threadInfo = "[" + Thread.CurrentThread.ManagedThreadId + "] ";
					string line = threadInfo + ExtractInfo(method);
					stringBuilder.Append(line);
				}
				else
				{
					stringBuilder.Append("Method Unknown: ");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		/// Method to trace the called method present on the stack at the specefied level from the peak with an additional message.
		/// </summary>
		/// <param name="stackLevel">The stack level.</param>
		[Conditional("USE_TRACING")]
		public static void TraceCall(int stackLevel, string msg)
		{
			try
			{
				StackTrace trace = new StackTrace();
				if (trace != null && trace.GetFrame(stackLevel) != null)
				{
					MethodBase method = trace.GetFrame(stackLevel).GetMethod();
					string threadInfo = "[" + Thread.CurrentThread.ManagedThreadId + "] ";
					string line = threadInfo + ExtractInfo(method);
					LogLine(line + " " + msg);
				}
				else
				{
					LogLine("Method Unknown: ");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
		}

		/// <summary>
		/// Method to trace the called method present on the stack at the specefied level from the peak.
		/// 
		/// </summary>
		/// <param name="stackLevel">The stack level.</param>
		[Conditional("USE_TRACING")]
		public static void TraceCall(int stackLevel)
		{
			try
			{
				StackTrace trace = new StackTrace();
				if (trace != null && trace.GetFrame(stackLevel) != null)
				{
					MethodBase method = trace.GetFrame(stackLevel).GetMethod();
					string line = ExtractInfo(method);
					LogLine(line);
				}
				else
				{
					LogLine("Method Unknown: ");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
		}

		private static string ExtractInfo(MethodBase method)
		{
			return method.DeclaringType.Name + "." + method.Name + "()";
		}


		/// <summary>Method to trace a message</summary> 
		/// <param name="msg"> msg string to display</param>
		[Conditional("USE_TRACING")]
		public static void TraceMsg(string msg)
		{
			try
			{
        string fullMsg = "[" + Thread.CurrentThread.ManagedThreadId + "]: "+ msg;
        LogLine(fullMsg);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}

		[Conditional("USE_TRACING")]
		public static void TraceMsg(double durration)
		{
			try
			{
				LogLine(durration + " seconds");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}

		/// <summary>Method to trace a message</summary> 
		/// <param name="err"> Exception to display</param>
		[Conditional("USE_TRACING")]
		public static void TraceErr(Exception err)
		{
			StackTrace stack = new StackTrace();
			string newLine = "\r\n";
			string excetionMessage = "Exception message: " + err.Message;
			string errorType = " Error type: " + err.GetType().Name;
			string stackTrace = "Error Stack Trace: " + err.StackTrace;
			string machineStackTtrace = "Machine Stack Trace :" + newLine + stack;
			string lineToDisplay = excetionMessage + newLine
			                       + errorType + newLine
			                       + stackTrace + newLine
			                       + machineStackTtrace;
			if (err.InnerException != null)
			{
				TraceErr(err.InnerException);
			}
			try
			{
				LogLine(lineToDisplay);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.StackTrace);
			}
		}

		/// <summary>Method to assert + trace a message</summary> 
		/// <param name="condition"> if false, raises assert</param>
		/// <param name="msg"> msg string to display</param>
		[Conditional("USE_TRACING")]
		public static void Assert(bool condition, string msg)
		{
			if (condition == false)
			{
				TraceCall(2);
				LogLine("Assertion failed:" + msg);
			}
		}

		public static string GetCurrentMethodInfo()
		{
			StackTrace trace = new StackTrace();
			if (trace != null && trace.GetFrame(1) != null)
			{
				MethodBase method = trace.GetFrame(1).GetMethod();
				return ExtractInfo(method);
			}
			return string.Empty;
		}
	}
}