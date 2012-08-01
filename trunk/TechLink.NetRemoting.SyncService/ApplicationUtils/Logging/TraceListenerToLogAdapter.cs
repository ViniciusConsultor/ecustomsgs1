using System.Diagnostics;

namespace ApplicationUtils.Logging
{
    /// <summary>
    /// Redirects Trace messages to the specefied log.
    /// </summary>
    public class TraceListenerToLogAdapter : TraceListener
    {
        private readonly ILog log;
        private readonly TraceLevel traceLevel = TraceLevel.Info;

        public TraceListenerToLogAdapter(ILog log, TraceLevel traceLevel)
        {
            this.log = log;

            this.traceLevel = traceLevel;
            this.log.LogLine(traceLevel,
                             "Trace listener adapter initialized. All message sent to Trace will be captured and added in this log with a 'T: ' in front.");
#if !DEBUG
Trace.Listeners.Add(this);
#endif

        }

        public override void Write(string message)
        {
            log.LogLine(traceLevel, "T: " + message);
        }

        public override void WriteLine(string message)
        {
            log.LogLine(traceLevel, "T: " + message);
        }
    }
}