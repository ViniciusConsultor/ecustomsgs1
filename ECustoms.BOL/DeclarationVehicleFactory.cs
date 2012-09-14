using System;
using System.Configuration;
using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;
using log4net;

namespace ECustoms.BOL
{
    public class DeclarationVehicleFactory : IDataModelCommand
    {
        public static int DeleteByVehicleDeclarationID(long vehicleID, long declarationID)
        {
            var db = new dbEcustomEntities(Utilities.Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var declarationVehicle =
                db.tblDeclarationVehicles.Where((g => g.DeclarationID == declarationID && g.VehicleID == vehicleID)).
                    FirstOrDefault();
            if (declarationVehicle != null)
            {
                db.DeleteObject(declarationVehicle);
                int re = db.SaveChanges();
                db.Connection.Close();
                return re;
            }
            return -1;

        }


        public static void DeleteVehicleByDecarationID(long declarationID)
        {
            var db = new dbEcustomEntities(Utilities.Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var declarationVehicles =
                db.tblDeclarationVehicles.Where((g => g.DeclarationID == declarationID)).ToList();

            foreach (var tblDeclarationVehicle in declarationVehicles)
            {
                db.DeleteObject(tblDeclarationVehicle);
                db.SaveChanges();
            }
            db.Connection.Close();
        }

        public static  bool IsExisting(long vehicleID, long declarationID)
        {
            var db = new dbEcustomEntities(Utilities.Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var temp =
                db.tblDeclarationVehicles.Where(g => g.VehicleID == vehicleID && g.DeclarationID == declarationID).
                    FirstOrDefault();
            db.Connection.Close();
            return temp != null;
        }

        public  static int Insert(long vehicleID, long declarationID)
        {
            var db = new dbEcustomEntities(Utilities.Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var declarationVehicle = new tblDeclarationVehicle();
            declarationVehicle.VehicleID = vehicleID;
            declarationVehicle.DeclarationID = declarationID;
            db.AddTotblDeclarationVehicles(declarationVehicle);
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;
        }

        #region Implementation of IDataModelCommand

        public bool DeleteItem(string[] itemParams)
        {
            if (itemParams.Length < 3) return false;

            int id = itemParams[0].StringToInt();
            int verhiceId = itemParams[1].StringToInt();
            string branchId = itemParams[2];

            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

            try
            {
                var deleteItem =
                    _db.tblDeclarationVehicles.FirstOrDefault(
                        item => item.DeclarationID == id && item.VehicleID == verhiceId && item.BranchId == branchId);
                if (deleteItem != null)
                {
                    _db.DeleteDirectly(deleteItem);
                    _db.SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                LogManager.GetLogger("ECustoms.DeclarationVehicleFactory").Error(exception.ToString());
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
                    if (item is tblDeclarationVehicle)
                    {
                        _db.AddObjectDirectly("tblDeclarationVehicle", item);
                    }
                }

                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("ECustoms.DeclarationVehicleFactory").Error(ex.ToString());
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
                var lstUnSyncedItems = (from item in _db.tblDeclarationVehicles
                                        where item.IsSynced == false
                                        select item).ToArray();
                _db.Connection.Close();
                return lstUnSyncedItems;
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("ECustoms.DeclarationVehicleFactory").Error(ex.ToString());
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
