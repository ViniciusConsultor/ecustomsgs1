using System;
using System.Collections.Generic;
using System.Text;
using ApplicationUtils.ApplicationUtilities.Profiling;

namespace ApplicationUtils.Profiling
{
	[Serializable]
	public class ToolProfilingData
	{
		private string toolName;
		private long seconds = 0;
	  private int enterCounter = 0;

		private readonly IDictionary<string, ServerMethodCallProfilingData> commandsCallsCount = new Dictionary<string, ServerMethodCallProfilingData>();
		private readonly IDictionary<string, ServerMethodCallProfilingData> queriesCallsCount = new Dictionary<string, ServerMethodCallProfilingData>();


	  public ToolProfilingData()
	  {
	  }

	  public ToolProfilingData(string toolName)
		{
			this.toolName = toolName;
		}

		public string ToolName
		{
			get
			{
				return toolName;
			}
      set
      {
        toolName = value;
      }
		}
    
	  public int EnterCounter
	  {
	    get { return enterCounter; }
	  }

	  public long SecondsUsage
		{
			get
			{
				return seconds;
			}
		}

		public IDictionary<string, ServerMethodCallProfilingData> CommandsCallsCount
		{
			get
			{
				return commandsCallsCount;
			}
		}

		public IDictionary<string, ServerMethodCallProfilingData> QueriesCallsCount
		{
			get
			{
				return queriesCallsCount;
			}
		}

    public void SecondsOfUsageIncrement(long val)
    {
      this.seconds += val;
    }

    public void EnterCounterIncrement()
    {
      this.enterCounter += 1;
    }

    public XmlSerializableToolProfilingData GetXmlSerializableToolProfilingData()
    {
      return new XmlSerializableToolProfilingData(this);
    }

   }
}
