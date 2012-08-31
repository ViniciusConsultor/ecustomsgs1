using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECustoms.DAL;
using ECustoms.Utilities;
using System.Configuration;
using System.Data;

namespace ECustoms.BOL
{
    public class DeclarationLoanFactory
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
    }
}
