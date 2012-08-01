using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ApplicationUtils.Profiling;

namespace ApplicationUtils.ApplicationUtilities.Profiling
{
  public class XmlSerializableToolProfilingData
  {
    [XmlIgnore]
    private ToolProfilingData source;

    private string toolName;
    private long secondsOfUsage = 0;
  	private long minutesOfUsage = 0;
    private int enterCounter = 0;

    private List<SerializableServerMethodCallProfilingData> commandsCallsCount = new List<SerializableServerMethodCallProfilingData>();
    private List<SerializableServerMethodCallProfilingData> queriesCallsCount = new List<SerializableServerMethodCallProfilingData>();


    public List<SerializableServerMethodCallProfilingData> CommandsCallsCount
    {
      get { return commandsCallsCount; }
      set { commandsCallsCount = value; }
    }

    public List<SerializableServerMethodCallProfilingData> QueriesCallsCount
    {
      get { return queriesCallsCount; }
      set { queriesCallsCount = value; }
    }

    public string ToolName
    {
      get { return toolName; }
      set { toolName = value; }
    }

    public long SecondsOfUsage
    {
      get { return secondsOfUsage; }
      set
      {
      	secondsOfUsage = value;
        minutesOfUsage = value/60;

      }
    }

  	public long MinutesOfUsage
  	{
  		get
  		{
  			return minutesOfUsage;
  		}
  		set
  		{
  			minutesOfUsage = value;
				
  		}
  	}

  	public int EnterCounter
    {
      get { return enterCounter; }
      set { enterCounter = value; }
    }
       

    public XmlSerializableToolProfilingData()
    {
    }

    public XmlSerializableToolProfilingData(ToolProfilingData source)
    {
      this.source = source;
      this.toolName = source.ToolName;
      this.secondsOfUsage = source.SecondsUsage;
    	this.minutesOfUsage = secondsOfUsage/60;
      this.enterCounter = source.EnterCounter;

			foreach (KeyValuePair<string, ServerMethodCallProfilingData> pair in source.QueriesCallsCount)
      {
        queriesCallsCount.Add(new SerializableServerMethodCallProfilingData(pair.Key,pair.Value));
      }

			foreach (KeyValuePair<string, ServerMethodCallProfilingData> pair in source.CommandsCallsCount)
      {
        commandsCallsCount.Add(new SerializableServerMethodCallProfilingData(pair.Key, pair.Value));
      }
    }

		[Serializable]
    public class SerializableServerMethodCallProfilingData
    {
    	private string commandName;
    	private string callsCounter;
    	private string processorTime;

    	public string CommandName
    	{
    		get
    		{
    			return commandName;
    		}
    		set
    		{
    			commandName = value;
    		}
    	}

    	public string CallsCounter
    	{
    		get
    		{
    			return callsCounter;
    		}
    		set
    		{
    			callsCounter = value;
    		}
    	}

    	public string ProcessorTime
    	{
    		get
    		{
    			return processorTime;
    		}
    		set
    		{
    			processorTime = value;
    		}
    	}

    	public SerializableServerMethodCallProfilingData()
    	{
    	}

			public SerializableServerMethodCallProfilingData(string commandName, ServerMethodCallProfilingData serverMethodCallProfilingData)
    	{
    		this.commandName = commandName;
				this.callsCounter = serverMethodCallProfilingData.CallCounter.ToString();
				this.processorTime = serverMethodCallProfilingData.ProcessorTime.ToString();
    	}

    	public SerializableServerMethodCallProfilingData(string commandName, string callsCounter, string processorTime)
    	{
    		this.commandName = commandName;
    		this.callsCounter = callsCounter;
    		this.processorTime = processorTime;
    	}


    	
    }
    
  }
}
