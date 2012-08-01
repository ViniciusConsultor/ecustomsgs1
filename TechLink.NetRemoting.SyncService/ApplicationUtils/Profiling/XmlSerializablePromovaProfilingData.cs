using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ApplicationUtils.ApplicationUtilities.Profiling;

namespace ApplicationUtils.Profiling
{
  public class XmlSerializablePromovaProfilingData
  {
    private List<XmlSerializableToolProfilingData> list = new List<XmlSerializableToolProfilingData>();
    [XmlIgnore]
    private PromovaProfilingData source;

  	private string profilingStartingDate;

    public XmlSerializablePromovaProfilingData()
    {
    }


    public List<XmlSerializableToolProfilingData> List
    {
      get { return list; }
    }

  	public string ProfilingStartingDate
  	{
  		get
  		{
  			return profilingStartingDate;
  		}
  		set
  		{
  			profilingStartingDate = value;
  		}
  	}

  	public	XmlSerializablePromovaProfilingData(PromovaProfilingData source)
    {
      this.source = source;
      foreach (KeyValuePair<string, ToolProfilingData> pair in source.ToolNameToProfilingData)
      {
        list.Add(pair.Value.GetXmlSerializableToolProfilingData());
      }
  		this.profilingStartingDate = this.source.ProfilingStartingDate;

    }
  }
}
