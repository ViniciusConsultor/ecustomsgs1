using System;
using System.Linq;
using ECustoms.DAL;
using System.Configuration;

namespace ECustoms.BOL
{
    public class CommonFactory
    {
        public static DateTime GetCurrentDate()
        {
            var db = new dbEcustomEntities(Utilities.Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var objCurentDate = db.ViewGetCurrentDates.FirstOrDefault();
            db.Connection.Close();
            return objCurentDate.CurrentDateTime;
        }
    }
}
