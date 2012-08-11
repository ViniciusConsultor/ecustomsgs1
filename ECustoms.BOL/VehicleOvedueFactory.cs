using System;
using System.Collections.Generic;
using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;
using System.Configuration;
using ECustoms.Utilities.Enums;


namespace ECustoms.BOL
{
    public class VehicleOvedueFactory
    {
        public static List<ViewVehicleOverdue> GetAllVehicleNotCompleted()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            List<ViewVehicleOverdue> data = db.ViewVehicleOverdues.Where(g => g.IsCompleted != true).ToList();
            db.Connection.Close();
            return data;
        }

        public static List<ViewVehicleOverdue> GetVehicleOverdue(int overdueDate)
        {
            DateTime today = DateTime.Now;
            List<ViewVehicleOverdue> data = GetAllVehicleNotCompleted();

            data = data.Where(g => ((g.IsChineseVehicle == true) && (g.IsImport == true) && (g.IsExport == false) && (g.ImportDate.Value < today.AddDays(-overdueDate)))
                                || ((g.IsChineseVehicle == false) && (g.IsExport == true) && (g.IsImport == false) && (g.ExportDate.Value < today.AddDays(-overdueDate)))).ToList();
            return data;
        }
    }
}
