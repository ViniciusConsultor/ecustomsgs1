using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationUtils.Profiling
{
	[Serializable]
	public class ServerMethodCallProfilingData
	{
		private long callCounter;
		private long processorTime;

		public long CallCounter
		{
			get
			{
				return callCounter;
			}
			set
			{
				callCounter = value;
			}
		}

		public long ProcessorTime
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

		public void Increment(ServerMethodCallProfilingData values)
		{
			this.callCounter += values.callCounter;
			this.processorTime += values.processorTime;
		}
    
		public ServerMethodCallProfilingData()
		{
		}
	}
}
