using System;
using System.Diagnostics;
using System.Reflection;

namespace ApplicationUtils.Logging
{
	/// <summary>
	/// Summary description for Utils.
	/// </summary>
	internal class Utils
	{
		public static string GetTraceCallMessage(int stackLevel)
		{
			MethodBase methodInfo = GetMethodInfoFromLevel(stackLevel + 1);
			if (methodInfo != null)
			{
				return ExtractInfo(methodInfo);
			}
			else
			{
				return "Unkonown method";
			}
		}

		public static MethodBase GetMethodInfoFromLevel(int stackLevel)
		{
			try
			{
				StackTrace trace = new StackTrace();
				if (trace != null &&
				    trace.GetFrame(stackLevel) != null)
				{
					MethodBase method = trace.GetFrame(stackLevel).GetMethod();
					return method;
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			return null;
		}

		public static string ExtractInfo(MethodBase method)
		{
			return method.DeclaringType.Name + "." + method.Name + "()";
		}
	}
}