using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExceptionHandler
{
public class ErrorNotify:IErrorNotify
    {
    #region Implementation of IErrorNotify

    public void NotifyUser(string message)
    {
        string appName = "TechLinkServiceLog";

        try
        {
          //MessageBox.Show(message, "Error - TechLink Sync", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            EventLog objEventLog = new EventLog();
            try
            {
                if (!(EventLog.SourceExists(appName)))
                {
                    EventLog.CreateEventSource(appName, "Error");
                }
                objEventLog.Source = appName;
                objEventLog.WriteEntry("ErrorLog", EventLogEntryType.Error);
            }
            catch (Exception Ex)
            {
            }
        }
        catch
        {
        }
    }

    #endregion
    }
}
