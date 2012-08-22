using System;
using System.Collections.Generic;
using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;
using System.Configuration;
using ECustoms.Utilities.Enums;

namespace ECustoms.BOL
{
    public class DeclarationManagementFactory
    {
        public static List<ViewDeclarationManagement> GetAll()
        {
            
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                List<ViewDeclarationManagement> list = db.ViewDeclarationManagements.ToList();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.Connection.Close();
            }
        }

        public static List<ViewDeclarationManagement> GetDeclarationNew()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                List<ViewDeclarationManagement> list = db.ViewDeclarationManagements.Where(g => g.DateHandover == null && g.PersonHandoverID == null && g.PersonReceive == null && g.PageNumbers == null).ToList();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.Connection.Close();
            }
        }

        public static List<ViewDeclarationManagement> GetDeclarationHandover()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                List<ViewDeclarationManagement> list = db.ViewDeclarationManagements.Where(g => g.DateHandover != null && g.DateHandoverSecond == null).ToList();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.Connection.Close();
            }
        }

        public static List<ViewDeclarationManagement> GetDeclarationSaved()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                List<ViewDeclarationManagement> list = db.ViewDeclarationManagements.Where(g => g.DateHandover != null && g.PageNumbers != null && g.DateHandoverSecond != null && g.PersonHandoverSecondID != null).ToList();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.Connection.Close();
            }
        }

        public static bool DeclarationIsLoaned(long id)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                var declarationLoanList = db.tblDeclarationLoans.Where(g => g.DeclarationID == id).ToList();
                foreach (var declarationLoan in declarationLoanList)
                {
                    if (declarationLoan.ReturnDate == null)
                        return true;
                        
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                db.Connection.Close();
            }
        }
    }
}
