using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ExceptionHandler.Logging
{
    public class WindowsServiceLog
    {
        private System.Diagnostics.EventLog ooDriveLog;

        public WindowsServiceLog()
        {
            
            if (!EventLog.SourceExists("eCustomService"))
            {
                EventLog.CreateEventSource("eCustomService", "eCustomService");
            }
            ooDriveLog = new System.Diagnostics.EventLog();
            ooDriveLog.Source = "eCustomService";            
        }

        public WindowsServiceLog(System.Diagnostics.EventLog evLog)
        {
            ooDriveLog = evLog;
        }

        public void WriteEntry(string strLogMsg)
        {
            ooDriveLog.WriteEntry(strLogMsg,System.Diagnostics.EventLogEntryType.Information);
            Debug.WriteLine(strLogMsg);
        }

        public void WriteEntry(System.Exception exc)
        {
            string strLogMsg = string.Format("{0}: msg:{1} trace:{2}", "eCustom Error", exc.Message, exc.StackTrace);
            ooDriveLog.WriteEntry(strLogMsg, System.Diagnostics.EventLogEntryType.Error);
        }

        public void WriteEntry(System.Exception exc, string caption)
        {
            string strLogMsg = string.Format("{0}: msg:{1} trace:{2}", caption, exc.Message, exc.StackTrace);
            ooDriveLog.WriteEntry(strLogMsg, System.Diagnostics.EventLogEntryType.Error);
        }
    }
}
