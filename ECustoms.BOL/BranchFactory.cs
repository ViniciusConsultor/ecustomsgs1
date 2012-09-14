using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using ECustoms.DAL;
using ECustoms.Utilities;

namespace ECustoms.BOL
{
    public class BranchFactory
    {
        public static bool IsExistingBranch(string branchId, string serialNumber)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                var branch = _db.tblBranchDatabases.FirstOrDefault(item => item.Id.Equals(branchId) && item.RegisterSerial.Equals(serialNumber));

                return branch != null;
            }
            catch
            {
                return false;
            }
            finally
            {
                _db.Connection.Close();
            }
            return false;
        }

        public static List<tblBranchDatabas> getAllBranchDatabas()
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblBranchDatabases.ToList();
            }
            catch
            {
                return null;
            }
            finally
            {
                _db.Connection.Close();
            }
        }
    }
}
