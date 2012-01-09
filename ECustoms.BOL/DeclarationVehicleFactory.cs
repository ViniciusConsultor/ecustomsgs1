using System.Configuration;
using System.Linq;
using ECustoms.DAL;

namespace ECustoms.BOL
{
    public class DeclarationVehicleFactory
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


    }
}
