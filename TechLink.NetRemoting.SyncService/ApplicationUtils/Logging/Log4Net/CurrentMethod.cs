using System.Reflection;

namespace ApplicationUtils.Logging.Log4Net
{
	/// <summary>
	/// Summary description for CurrentMethod.
	/// </summary>
	public class CurrentMethod
	{
		public override string ToString()
		{
            MethodBase method = Utils.GetMethodInfoFromLevel(18);
			if (method != null)
			{
				return method.Name;
			}
			else
			{
				return "unknown method";
			}
		}
	}
}