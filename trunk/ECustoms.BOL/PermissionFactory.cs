using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;

namespace ECustoms.BOL
{
    public class PermissionFactory
    {
        public static List<tblPermission> GetAllPermission()
        {
          var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
          List < tblPermission >  list = db.tblPermissions.ToList();
          db.Connection.Close();
          return list;
        }

    }
}
