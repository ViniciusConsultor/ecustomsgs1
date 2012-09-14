using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;
using log4net;

namespace ECustoms.BOL
{
    public class RoleFactory : IDataModelCommand
    {
        private readonly string _dbConnectionString;
        private dbEcustomEntities _db;
        public RoleFactory()
        {
            _dbConnectionString = Utilities.Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true);
            _db = new dbEcustomEntities(_dbConnectionString);

        }

        public void SaveGroup(tblGroup group)
        {
            _db.Connection.Open();
            _db.AddTotblGroups(group);
            _db.SaveChanges();
            _db.Connection.Close();
        }

        public int  UpdateGroup(tblGroup group)
        {
            _db.Connection.Open();
            var objOrginGroup = _db.tblGroups.Where(g => g.GroupID.Equals(group.GroupID)).FirstOrDefault();
            _db.Attach(objOrginGroup);
            _db.ApplyPropertyChanges("tblGroups", group);
            int re = _db.SaveChanges();
            _db.Connection.Close();
            return re;
        }

        public List<tblGroup> GetAllGroups()
        {
            _db.Connection.Open();
            List < tblGroup >  list = _db.tblGroups.ToList();
            _db.Connection.Close();
            return list;
        }

        //public List<tlbRole> GetAllRoles()
        //{
        //  _db.Connection.Open();
        //  List < tlbRole >  list = _db.tlbRoles.ToList();
        //  _db.Connection.Close();
        //  return list;

        //}

        public int DeleteGroup(int groupID)
        {
            _db.Connection.Open();
            var group = _db.tblGroups.Where(g => g.GroupID == groupID).FirstOrDefault();
            _db.DeleteObject(group);
            int re = _db.SaveChanges();
            _db.Connection.Close();
            return re;
        }

        public tblGroup GetGroupById(int groupID)
        {
            throw new NotImplementedException();
        }

        #region Implementation of IDataModelCommand

        public bool DeleteItem(string[] itemParams)
        {
            if (itemParams.Length < 2) return false;

            int id = itemParams[0].StringToInt();
            string branchId = itemParams[1];

            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

            try
            {
                var deleteItem =
                    _db.tlbRoles.FirstOrDefault(
                        item => item.RoleID == id && item.BranchId == branchId);
                if (deleteItem != null)
                {
                    _db.DeleteDirectly(deleteItem);
                    _db.SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                LogManager.GetLogger("ECustoms.RoleFactory").Error(exception.ToString());
                throw;
            }
            finally
            {
                _db.Connection.Close();
            }
        }

        public bool BatchInsert(object[] items)
        {
            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

            try
            {
                _db.Connection.Open();
                foreach (object item in items)
                {
                    _db.AddObjectDirectly("tlbRoles", item);
                }

                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("ECustoms.AllFactory").Error(ex.ToString());
                throw;
            }
            finally
            {
                _db.Connection.Close();
            }

            return false;
        }

        public object[] GetUnSyncedItems()
        {

            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                _db.Connection.Open();
                var lstUnSyncedItems = (from item in _db.tlbRoles
                                        where item.IsSynced == false
                                        select item).ToArray();
                _db.Connection.Close();
                return lstUnSyncedItems;
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("ECustoms.AllFactory").Error(ex.ToString());
                throw;
            }
            finally
            {
                _db.Connection.Close();
            }

        }

        public bool UpdatePatch(object[] items)
        {
            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

            try
            {
                _db.Connection.Open();
                var updateItems = items.OfType<tlbRole>().ToList();

                foreach (var updateItem in updateItems)
                {
                    var item =
                        _db.tlbRoles.FirstOrDefault(
                            p => p.BranchId == updateItem.BranchId && p.RoleID == updateItem.RoleID);
                    item.IsSynced = true;
                }
                _db.SaveChanges();
                _db.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("ECustoms.AllFactory").Error(ex.ToString());
                throw;
            }
            finally
            {
                _db.Connection.Close();
            }
        }

        #endregion
    }
}
