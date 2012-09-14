using System;
using System.Configuration;
using System.Linq;
using ECustoms.BOL;
using ECustoms.DAL;
using ECustoms.Utilities;
using log4net;

namespace ECustoms.BOL
{
    public class RoleInGroupFactory : IDataModelCommand
    {
        #region Implementation of IDataModelCommand

        public bool DeleteItem(string[] itemParams)
        {
            if (itemParams.Length < 3) return false;

            int id = itemParams[0].StringToInt();
            int roleId = itemParams[1].StringToInt();
            string branchId = itemParams[2];

            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

            try
            {
                var deleteItem =
                    _db.tblRoleInGroups.FirstOrDefault(
                        item => item.GroupID == id && item.RoleID == roleId && item.BranchId == branchId);
                if (deleteItem != null)
                {
                    _db.DeleteDirectly(deleteItem);
                    _db.SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                LogManager.GetLogger("ECustoms.RoleInGroupFactory").Error(exception.ToString());
                throw;
            }
            finally
            {
                _db.Connection.Close();
            }
        }

        public bool BatchInsert(object[] items)
        {
            throw new NotImplementedException();
        }

        public object[] GetUnSyncedItems()
        {
            throw new NotImplementedException();
        }

        public bool UpdatePatch(object[] items)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}