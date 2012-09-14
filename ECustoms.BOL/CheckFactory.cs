using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;
using log4net;

namespace ECustoms.BOL
{
    public class CheckFactory:IDataModelCommand
    {
        public  const int  DECLARATION_TYPE_EXPORT= 0;
        public  const int DECLARATION_TYPE_IMPORTT = 1;
        public  const int DECLARATION_TYPE_EXPORT_AND_IMPORT = 2;
        public static List<ViewAllCheck> SelectAll()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            List < ViewAllCheck > list = db.ViewAllChecks.OrderByDescending(g => g.ModifedDate).ToList();
            db.Connection.Close();
            return list;
        }

        public static int Insert(tblCheck check)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            check.CreateDate = CommonFactory.GetCurrentDate();
            check.ModifedDate = CommonFactory.GetCurrentDate();
            db.AddTotblChecks(check);
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;
        }

        public static int Update(tblCheck check)
        {
            check.ModifedDate = CommonFactory.GetCurrentDate();
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var checkOrgin = db.tblChecks.Where(g => g.CheckID == check.CheckID).FirstOrDefault();
            if (checkOrgin == null) return -1;
            db.Attach(checkOrgin);
            db.ApplyPropertyChanges("tblChecks", check);
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;
        }

        public static tblCheck SelectByID(long checkID) {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            tblCheck check = db.tblChecks.Where(g => g.CheckID == checkID).FirstOrDefault();
            db.Connection.Close();
            return check;
        }

        public static int Delete(long checkID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var check = db.tblChecks.Where(g => g.CheckID == checkID).FirstOrDefault();
            if (check == null) return -1;
            db.DeleteObject(check);
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;
        }

        public static string GetCheckCode()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var check = db.tblChecks.OrderByDescending(g => g.CheckID).FirstOrDefault();
            db.Connection.Close();
            if (check != null)
            {
              return "KT_" + string.Format("{0:00000}", check.CheckID);
            }
            else
            {
              return "KT_" + string.Format("{0:00000}", 1);
            }
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
                    _db.tblChecks.FirstOrDefault(
                        item => item.CheckID == id && item.BranchId == branchId);
                if (deleteItem != null)
                {
                    _db.DeleteDirectly(deleteItem);
                    _db.SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                LogManager.GetLogger("ECustoms.CheckFactory").Error(exception.ToString());
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
                    if (item is tblCheck)
                    {
                        _db.AddObjectDirectly("tblCheck", item);
                    }
                }

                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("ECustoms.CheckFactory").Error(ex.ToString());
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
                var lstUnSyncedItems = (from item in _db.tblChecks
                                        where item.IsSynced == false
                                        select item).ToArray();
                _db.Connection.Close();
                return lstUnSyncedItems;
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("ECustoms.CheckFactory").Error(ex.ToString());
                throw;
            }
            finally
            {
                _db.Connection.Close();
            }
        }

        public bool UpdatePatch(object[] items)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
