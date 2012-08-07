using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;

namespace ECustoms.Utilities
{
    public class PrinterChecking
    {
        public static bool IsValid (string printerName)
        {

                bool retVal = false;
                try
                {
                    PrintDocument pd = new PrintDocument();
                    pd.PrinterSettings.PrinterName = printerName;
                    retVal = pd.PrinterSettings.IsValid;
                }
                catch (System.Exception ex)
                {
                    retVal = false;
                }
                return retVal;
            }
        
    }
}
