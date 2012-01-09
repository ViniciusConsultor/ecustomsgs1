using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using ECustoms.DAL;
using ECustoms.Utilities;

namespace ECustoms.BOL
{
    public class VehicleCheckFactory
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
    }
}
