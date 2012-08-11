using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECustoms.DAL;
using ECustoms.Utilities;
using System.Configuration;

namespace ECustoms.BOL
{
    public class PermissionTypeFactory
    {
        public static List<tblPermissionType> GetAllPermissionType()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            List<tblPermissionType> list = db.tblPermissionTypes.ToList();
            db.Connection.Close();
            return list;
        }
    }
}
