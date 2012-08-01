using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ApplicationUtils.Profiling
{
	[Serializable]
	public class PromovaProfilingData
	{
		private string profilingStartingDate;

    private IDictionary<string, ToolProfilingData> toolNameToProfilingData = new Dictionary<string, ToolProfilingData>();
	  
	  public IDictionary<string, ToolProfilingData> ToolNameToProfilingData
	  {
	    get { return toolNameToProfilingData; }
    }

		public string ProfilingStartingDate
		{
			get
			{
				if (profilingStartingDate==null)
				{
					profilingStartingDate = DateTime.Now.ToString();
				}
				return profilingStartingDate;
			}
		}

		public PromovaProfilingData()
		{
			profilingStartingDate = DateTime.Now.ToString();
		}


		public ToolProfilingData GetProfilingData(string toolName)
    {
      if(string.IsNullOrEmpty( toolName))
      {
        throw new ArgumentNullException("toolName");
      }
      if(!toolNameToProfilingData.ContainsKey(toolName))
      {
        toolNameToProfilingData.Add(toolName, new ToolProfilingData(toolName));
      }

      return toolNameToProfilingData[toolName];
    }

    public XmlSerializablePromovaProfilingData GetXmlSerializablePromovaProfilingData()
    {
      return new XmlSerializablePromovaProfilingData(this);
    }


		public void Reset()
		{
			toolNameToProfilingData.Clear();
			profilingStartingDate = DateTime.Now.ToString();
		}
	}
}
