using System.Collections;
using System.Collections.Generic;

namespace ApplicationUtils.Utils
{
	/// <summary>
	/// Summary description for CultureHelper.
	/// </summary>
	public class CultureHelper
	{
		public static string GetResourceText(IDictionary<string, string> resources, string resourceName, string defaultText)
		{
			if (resources != null && resourceName != null && resources.ContainsKey(resourceName))
			{
				
				string translation = resources[resourceName].ToString();
				if(translation == string.Empty)
				{
					translation = defaultText;
				}
				return translation; 
			}
			else
			{
				return defaultText;
			}
		}

		public static string GetResourceText(IDictionary<string,string> resources, string resourceName)
		{
			return GetResourceText(resources, resourceName, resourceName);
		}

		public static string GetResourceText(IDictionary<string,string> resources, string resourceName, string[] injectedTexts)
		{
			string translatedText = GetResourceText(resources, resourceName, resourceName);
			int pos = 0;
			pos = translatedText.IndexOf("%s", pos);
			int encounter = 0;
			string resultText = translatedText;
			while (pos != -1)
			{
				if (encounter > injectedTexts.Length - 1) break;
				string injectedText = injectedTexts[encounter];
				resultText = resultText.Substring(0, pos) + injectedText + resultText.Substring(pos + 2);
				pos = resultText.IndexOf("%s", pos);
				encounter++;
			}
			return resultText;
		}
		
	}
}