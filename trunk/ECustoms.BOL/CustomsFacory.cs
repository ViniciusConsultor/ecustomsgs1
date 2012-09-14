using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECustoms.DAL;
using ECustoms.Utilities;
using System.Configuration;
using System.Data;
using log4net;

namespace ECustoms.BOL
{
    public class CustomsFacory : IDataModelCommand
    {
        public static List<tblCustom> getAll()
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblCustoms.ToList();
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


        public static tblCustom FindByCode(string code)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblCustoms.Where(g => g.CustomsCode == code).FirstOrDefault();
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

        public static int Insert(tblCustom customs)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            _db.Connection.Open();
            customs.CreatedDate = CommonFactory.GetCurrentDate();
            customs.ModifiedDate = CommonFactory.GetCurrentDate();
            customs.BranchId= FDHelper.RgCodeOfUnit();
            _db.AddTotblCustoms(customs);
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                _db.Connection.Close();
            }
        }

        public static int Update(tblCustom customsObj)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            _db.Connection.Open();

            tblCustom originCustoms = _db.tblCustoms.Where(g => g.CustomsCode == customsObj.CustomsCode).FirstOrDefault();

            if (originCustoms == null)
            {
                return -1;
            }

            originCustoms.CustomsName = customsObj.CustomsName;
            originCustoms.Description = customsObj.Description;
            originCustoms.ModifiedBy = customsObj.ModifiedBy;
            originCustoms.ModifiedDate = CommonFactory.GetCurrentDate();

            try
            {
                return _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                _db.Connection.Close();
            }
        }

        public static int Delete(String customsCode)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                var customs = _db.tblCustoms.FirstOrDefault(g => g.CustomsCode == customsCode);
                _db.DeleteObject(customs);
                return _db.SaveChanges();
            }
            catch
            {
                return -1;
            }
            finally
            {
                _db.Connection.Close();
            }
        }

        #region Implementation of IDataModelCommand

        public bool DeleteItem(string[] itemParams)
        {
            if (itemParams.Length < 2) return false;

            string id = itemParams[0];
            string branchId = itemParams[1];

            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

            try
            {
                var deleteItem =
                    _db.tblCustoms.FirstOrDefault(
                        item => item.CustomsCode == id && item.BranchId == branchId);
                if (deleteItem != null)
                {
                    _db.DeleteDirectly(deleteItem);
                    _db.SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                LogManager.GetLogger("ECustoms.CustomFactory").Error(exception.ToString());
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
                    _db.AddObjectDirectly("tblCustoms", item);
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
                var lstUnSyncedItems = (from item in _db.tblCustoms
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
                var updateItems = items.OfType<tblCustom>().ToList();

                foreach (var updateItem in updateItems)
                {
                    var item =
                        _db.tblCustoms.FirstOrDefault(
                            p => p.BranchId == updateItem.BranchId && p.CustomsCode == updateItem.CustomsCode);
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
