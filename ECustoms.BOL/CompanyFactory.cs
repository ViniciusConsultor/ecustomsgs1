using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using ECustoms.DAL;
using ECustoms.Utilities;
using System.Configuration;
using System.Data;
using log4net;

namespace ECustoms.BOL
{
    public class CompanyFactory : IDataModelCommand
    {
        public static List<tblCompany> getAllCompany()
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblCompanies.ToList();
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


        public static tblCompany FindByCode(string code)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblCompanies.Where(g => g.CompanyCode == code).FirstOrDefault();
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

        public static int Insert(tblCompany company)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            _db.Connection.Open();
            company.CreatedDate = CommonFactory.GetCurrentDate();
            company.ModifiedDate = CommonFactory.GetCurrentDate();
            _db.AddTotblCompanies(company);
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

        public static int Update(tblCompany companyObj)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            _db.Connection.Open();

            tblCompany originCompany = _db.tblCompanies.Where(g => g.CompanyCode == companyObj.CompanyCode).FirstOrDefault();

            if (originCompany == null)
            {
                return -1;
            }

            originCompany.CompanyName = companyObj.CompanyName;
            originCompany.Description = companyObj.Description;
            originCompany.ModifiedBy = companyObj.ModifiedBy;
            originCompany.ModifiedDate = CommonFactory.GetCurrentDate();

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

        public static int Delete(String companyCode)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                var company = _db.tblCompanies.FirstOrDefault(vt => vt.CompanyCode == companyCode);
                _db.DeleteObject(company);
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
                    _db.tblCompanies.FirstOrDefault(
                        item => item.CompanyCode == id && item.BranchId == branchId);
                if (deleteItem != null)
                {
                    _db.DeleteDirectly(deleteItem);
                    _db.SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                LogManager.GetLogger("ECustoms.CompanyFactory").Error(exception.ToString());
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
                    if (item is tblCompany)
                    {
                        
                        _db.AddObjectDirectly("tblCompanies", item);
                    }
                }

                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("ECustoms.CompanyFactory").Error(ex.ToString());
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
                var lstUnSyncedItems = (from item in _db.tblCompanies
                                        where item.IsSynced == false
                                        select item).ToList();
                _db.Connection.Close();
                return lstUnSyncedItems.ToArray();
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("ECustoms.CompanyFactory").Error(ex.ToString());
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

                foreach (object item in items)
                {
                    tblCompany company = item as tblCompany;
                    var updateItem =
                        _db.tblCompanies.FirstOrDefault(
                            p => p.CompanyCode == company.CompanyCode && p.BranchId == company.BranchId);
                    if(updateItem!=null)
                    {

                        updateItem.CompanyName = company.CompanyName;
                        updateItem.CreatedBy = company.CreatedBy;
                        updateItem.CreatedDate = company.CreatedDate;
                        updateItem.Description = company.Description;
                        updateItem.IsSynced = company.IsSynced;
                        updateItem.ModifiedBy = company.ModifiedBy;
                        updateItem.ModifiedDate = company.ModifiedDate;
                    }
                }

                _db.SaveChanges();
                _db.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("ECustoms.CompanyFactory").Error(ex.ToString());
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
