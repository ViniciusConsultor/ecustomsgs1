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
    public class DeclarationLoanFactory : IDataModelCommand
    {
        public static int Insert(tblDeclarationLoan loan)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            _db.Connection.Open();
            loan.CreatedDate = CommonFactory.GetCurrentDate();
            loan.ModifiedDate = CommonFactory.GetCurrentDate();
            _db.AddTotblDeclarationLoans(loan);
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

        public static int Update(tblDeclarationLoan loan)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            loan.ModifiedDate = CommonFactory.GetCurrentDate();
            // Get orgin object
            var objOrginDeclaration = db.tblDeclarationLoans.Where(g => g.ID.Equals(loan.ID)).FirstOrDefault();
            db.Attach(objOrginDeclaration);
            db.ApplyPropertyChanges("tblDeclarationLoans", loan);
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;
        }

        public static List<tblDeclarationLoan> getAll()
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblDeclarationLoans.OrderByDescending(g => g.ModifiedDate).ToList();
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

        public static List<tblDeclarationLoan> getAllByDeclarationID(long declarationID)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblDeclarationLoans.Where(g => g.DeclarationID == declarationID).OrderByDescending(g => g.ModifiedDate).ToList();
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

        public static List<viewDeclarationLoan> getViewByDeclarationID(long declarationID)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.viewDeclarationLoans.Where(g => g.DeclarationID == declarationID).OrderByDescending(g => g.ModifiedDate).ToList();
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

        public static tblDeclarationLoan getLastLoanByDeclarationID(long declarationID)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblDeclarationLoans.Where(g => g.DeclarationID == declarationID).OrderByDescending(g => g.ModifiedDate).FirstOrDefault();
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
                    _db.tblDeclarationLoans.FirstOrDefault(
                        item => item.ID == id && item.BranchId == branchId);
                if (deleteItem != null)
                {
                    _db.DeleteDirectly(deleteItem);
                    _db.SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                LogManager.GetLogger("ECustoms.DeclarationLoanFactory").Error(exception.ToString());
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
                    _db.AddObjectDirectly("tblDeclarationLoans", item);
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
                var lstUnSyncedItems = (from item in _db.tblDeclarationLoans
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
                var updateItems = items.OfType<tblDeclarationLoan>().ToList();

                foreach (var updateItem in updateItems)
                {
                    var item =
                        _db.tblDeclarationLoans.FirstOrDefault(
                            p => p.BranchId == updateItem.BranchId && p.ID == updateItem.ID);
                    item.IsSynced = true;
                }
                _db.SaveChanges();
                _db.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("ECustoms.CustomFactory").Error(ex.ToString());
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
