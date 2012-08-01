using System;
using System.Collections.Generic;
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
        try
        {
          MessageBox.Show(message, "Error - TechLink Sync", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }
        catch
        {
        }
    }

    #endregion
    }
}
