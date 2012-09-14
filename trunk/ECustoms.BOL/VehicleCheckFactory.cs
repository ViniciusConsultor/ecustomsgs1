using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using ECustoms.DAL;
using ECustoms.Utilities;
using log4net;

namespace ECustoms.BOL
{
    public class VehicleCheckFactory : IDataModelCommand
    {
        public const int CHECK_TYPE_EXPORT = 1;
        public const int CHECK_TYPE_IMPORT = 2;
        public const int CHECK_TYPE_IMPORT_LOCAL = 3;

        public  static  List<ViewAllCheckResult> SelectAll()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            List < ViewAllCheckResult >  list = db.ViewAllCheckResults.OrderByDescending(g => g.VehicleCheckID).ToList();
            db.Connection.Close();  
            return list;
        }

        public static ViewAllCheckResult SelectByID(int vehicleCheckID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            ViewAllCheckResult  allCheckResult = db.ViewAllCheckResults.Where(g => g.VehicleCheckID == vehicleCheckID).FirstOrDefault();
            db.Connection.Close();
            return allCheckResult;
        }

        public static tblVehicleCheck SelectVehicleCheckByID(int vehicleCheckID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            tblVehicleCheck vehicleCheck = db.tblVehicleChecks.Where(g => g.VehicleCheckID == vehicleCheckID).FirstOrDefault();
            db.Connection.Close();
            return vehicleCheck;
        }

        public static int Update(tblVehicleCheck vehicleCheck)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));            
            // Get orgin object
            var objOrginVehicleCheck = db.tblVehicleChecks.Where(g => g.VehicleCheckID == vehicleCheck.VehicleCheckID).FirstOrDefault();
            db.Attach(objOrginVehicleCheck);
            db.ApplyPropertyChanges("tblVehicleChecks", vehicleCheck);
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;        
        }

        public  static int Insert(tblVehicleCheck tblVehicleCheck)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            tblVehicleCheck.CreatedDate = CommonFactory.GetCurrentDate();
            db.AddTotblVehicleChecks(tblVehicleCheck);
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;
        }

        public  static List<ViewAllCheckResult> Search(DateTime checkFrom, DateTime checkTo)
        {
          var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            if( checkFrom > checkTo)
            {
             return db.ViewAllCheckResults.Where(g => (g.CheckFrom == null)).ToList();
            }
            //thoi gian kiem tra giao voi doan [checkFrom , checkTo] = n ngay
            List < ViewAllCheckResult >  list = db.ViewAllCheckResults.Where(g => (g.CheckFrom == null) || ((g.CheckFrom <= checkFrom) && (g.CheckTo >= checkTo)) ||
                                                     ((g.CheckFrom >= checkFrom) && (g.CheckFrom <= checkTo)) ||
                                                     ((g.CheckTo >= checkFrom) && (g.CheckTo <= checkTo))).ToList();
            db.Connection.Close();
            return list;
        }

        public  static  int Delete(int vehicleCheckID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var vehicleCheck = db.tblVehicleChecks.Where(g => g.VehicleCheckID == vehicleCheckID).FirstOrDefault();
            if (vehicleCheck == null)
            {
                return -1;
            }
            db.DeleteObject(vehicleCheck);
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;
        }

        public static bool IsExistingVehicle(long vehicleID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var vehicleCheck = db.tblVehicleChecks.Where(g => g.VehicleID == vehicleID).FirstOrDefault();
            db.Connection.Close();
            return vehicleCheck != null;
        }

        public static List<tblVehicleCheck> GetExistingVehicleHasChecked(long vehicleID)
        {
          var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
          List < tblVehicleCheck >  list = db.tblVehicleChecks.Where(g => g.VehicleID == vehicleID).ToList();
          db.Connection.Close();
          return list;
        }

        public static bool IsExistingVehicleInBothImportAndExport(long vehicleID)
        {
          var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

          bool hasImport =false;
          bool hasExport =false;

          var vehicleCheckResult = db.ViewAllVehicleHasGoods.Where(g => g.VehicleID == vehicleID).ToList();
          foreach (ViewAllVehicleHasGood obj in vehicleCheckResult)
          {
            if (obj.IsExport == true)
              hasExport = true;

            if (obj.IsImport == true)
              hasImport = true;
          }
          db.Connection.Close();
          return (hasExport && hasImport);
          
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
                    _db.tblVehicleChecks.FirstOrDefault(
                        item => item.VehicleCheckID == id && item.BranchId == branchId);
                if (deleteItem != null)
                {
                    _db.DeleteDirectly(deleteItem);
                    _db.SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                LogManager.GetLogger("ECustoms.VehicleCheckFactory").Error(exception.ToString());
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
