using System.Collections;
using System.Diagnostics;

namespace ApplicationUtils.Logging
{
	/// <summary>
	/// Summary description for LogAgregator.
	/// </summary>
	public class LogCollection : BaseLog, IEnumerable
	{
		private readonly ArrayList logs = new ArrayList();

		public ILog[] Logs
		{
			get
			{
				return (ILog[]) logs.ToArray(typeof (ILog));
			}
		}

		public void Add(ILog log)
		{
			this.logs.Add(log);
		}


		public IEnumerator GetEnumerator()
		{
			return this.logs.GetEnumerator();
		}

		public override TraceLevel TraceLevel
		{
			get
			{
				return base.TraceLevel;
			}
			set
			{
				foreach (BaseLog log in logs)
				{
					log.TraceLevel = value;
				}
				base.TraceLevel = value;
			}
		}


		public override void LogLine(TraceLevel traceLevel, string message)
		{
			foreach (ILog log in logs)
			{
				log.LogLine(traceLevel, message);
			}
		}

		protected override void LogLine(string message)
		{
//			foreach (ILog log in logs)
//			{
//				log.LogLine(TraceLevel.Verbose,message);
//			}
		}

		public override void Close()
		{
			foreach (ILog log in logs)
			{
				log.Close();
			}
		}
	}
}